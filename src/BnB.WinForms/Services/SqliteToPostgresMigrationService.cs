using System.Reflection;
using BnB.Core.Models;
using BnB.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Services;

/// <summary>
/// Service to migrate data from SQLite to PostgreSQL
/// </summary>
public class SqliteToPostgresMigrationService
{
    private readonly List<string> _skippedTables = new();

    /// <summary>
    /// Migrates all data from SQLite to PostgreSQL
    /// </summary>
    public void MigrateData(string sqlitePath, string postgresConnectionString, IProgress<string>? progress = null)
    {
        _skippedTables.Clear();
        progress?.Report("Initializing migration...");

        // Create SQLite context
        var sqliteOptions = new DbContextOptionsBuilder<BnBDbContext>()
            .UseSqlite($"Data Source={sqlitePath}")
            .Options;

        // Create PostgreSQL context
        var postgresOptions = new DbContextOptionsBuilder<BnBDbContext>()
            .UseNpgsql(postgresConnectionString)
            .Options;

        using var sqliteContext = new BnBDbContext(sqliteOptions);
        using var postgresContext = new BnBDbContext(postgresOptions);

        // Recreate PostgreSQL database schema
        // Use EnsureDeleted + EnsureCreated instead of Migrate because the migrations
        // were generated for SQLite and contain SQLite-specific type mappings (e.g., INTEGER for bool)
        progress?.Report("Dropping existing PostgreSQL tables (if any)...");
        postgresContext.Database.EnsureDeleted();
        progress?.Report("Creating PostgreSQL schema...");
        postgresContext.Database.EnsureCreated();

        // Migrate in dependency order (tables with no foreign keys first)
        MigrateTableSafe("Tax Rates", () => MigrateTaxRates(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Tax Plans", () => MigrateTaxPlans(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Company Info", () => MigrateCompanyInfo(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Common Texts", () => MigrateCommonTexts(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Check Number Configs", () => MigrateCheckNumberConfigs(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Facts", () => MigrateFacts(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Guests", () => MigrateGuests(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Properties", () => MigrateProperties(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Room Types", () => MigrateRoomTypes(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Accommodations", () => MigrateAccommodations(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Payments", () => MigratePayments(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Checks", () => MigrateChecks(sqliteContext, postgresContext), progress);
        MigrateTableSafe("Property Facts", () => MigratePropertyFacts(sqliteContext, postgresContext), progress);

        progress?.Report("Resetting PostgreSQL sequences...");
        ResetSequences(postgresContext);

        if (_skippedTables.Count > 0)
        {
            progress?.Report($"Migration completed. Skipped tables (not in source): {string.Join(", ", _skippedTables)}");
        }
        else
        {
            progress?.Report("Migration completed successfully!");
        }
    }

    private void MigrateTableSafe(string tableName, Action migrateAction, IProgress<string>? progress)
    {
        try
        {
            progress?.Report($"Migrating {tableName}...");
            migrateAction();
        }
        catch (Exception ex) when (ContainsMessage(ex, "no such table"))
        {
            _skippedTables.Add(tableName);
            progress?.Report($"Skipping {tableName} (table not found in source)...");
        }
        catch (Exception ex)
        {
            // Re-throw with more context about which table failed
            throw new Exception($"Failed to migrate {tableName}: {GetInnerMostMessage(ex)}", ex);
        }
    }

    private static bool ContainsMessage(Exception ex, string text)
    {
        var current = ex;
        while (current != null)
        {
            if (current.Message.Contains(text, StringComparison.OrdinalIgnoreCase))
                return true;
            current = current.InnerException;
        }
        return false;
    }

    private static string GetInnerMostMessage(Exception ex)
    {
        var current = ex;
        while (current.InnerException != null)
            current = current.InnerException;
        return current.Message;
    }

    /// <summary>
    /// Process DateTime properties for PostgreSQL compatibility.
    /// With Npgsql.EnableLegacyTimestampBehavior=true, we keep dates as-is (no UTC conversion needed).
    /// </summary>
    private static List<T> FixDateTimeKinds<T>(List<T> items) where T : class
    {
        // With legacy timestamp behavior enabled, no conversion is needed
        // Dates are stored as timestamp without time zone
        return items;
    }

    private void MigrateTaxRates(BnBDbContext source, BnBDbContext target)
    {
        var items = FixDateTimeKinds(source.TaxRates.AsNoTracking().ToList());
        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.TaxRates.Any(x => x.Id == item.Id))
            {
                target.TaxRates.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigrateTaxPlans(BnBDbContext source, BnBDbContext target)
    {
        var items = FixDateTimeKinds(source.TaxPlans.AsNoTracking().ToList());
        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.TaxPlans.Any(x => x.Id == item.Id))
            {
                target.TaxPlans.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigrateCompanyInfo(BnBDbContext source, BnBDbContext target)
    {
        // Use raw SQL to handle missing Logo column in older databases
        var connection = source.Database.GetDbConnection();
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT Id, CompanyName, Address, City, State, ZipCode, Phone, Fax, Email, WebUrl
            FROM CompanyInfo";

        var items = new List<CompanyInfo>();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                items.Add(new CompanyInfo
                {
                    Id = reader.GetInt32(0),
                    CompanyName = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Address = reader.IsDBNull(2) ? null : reader.GetString(2),
                    City = reader.IsDBNull(3) ? null : reader.GetString(3),
                    State = reader.IsDBNull(4) ? null : reader.GetString(4),
                    ZipCode = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Phone = reader.IsDBNull(6) ? null : reader.GetString(6),
                    Fax = reader.IsDBNull(7) ? null : reader.GetString(7),
                    Email = reader.IsDBNull(8) ? null : reader.GetString(8),
                    WebUrl = reader.IsDBNull(9) ? null : reader.GetString(9),
                    Logo = null // Logo column may not exist in source
                });
            }
        }

        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.CompanyInfo.Any(x => x.Id == item.Id))
            {
                target.CompanyInfo.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigrateCommonTexts(BnBDbContext source, BnBDbContext target)
    {
        // Use raw SQL to handle missing CreatedDate/ModifiedDate columns in older databases
        var connection = source.Database.GetDbConnection();
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"SELECT Id, Title, Text FROM CommonTexts";

        var items = new List<CommonText>();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                items.Add(new CommonText
                {
                    Id = reader.GetInt32(0),
                    Title = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                    Text = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    CreatedDate = null, // Column may not exist in source
                    ModifiedDate = null // Column may not exist in source
                });
            }
        }

        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.CommonTexts.Any(x => x.Id == item.Id))
            {
                target.CommonTexts.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigrateCheckNumberConfigs(BnBDbContext source, BnBDbContext target)
    {
        // Use raw SQL to handle missing columns in older databases
        var connection = source.Database.GetDbConnection();
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();

        // First, check what columns exist in the table
        using var schemaCommand = connection.CreateCommand();
        schemaCommand.CommandText = "PRAGMA table_info(CheckNumberConfigs)";
        var columns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        using (var schemaReader = schemaCommand.ExecuteReader())
        {
            while (schemaReader.Read())
            {
                columns.Add(schemaReader.GetString(1)); // Column name is at index 1
            }
        }

        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id FROM CheckNumberConfigs";

        var items = new List<CheckNumberConfig>();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                items.Add(new CheckNumberConfig
                {
                    Id = reader.GetInt32(0),
                    HostCheckNum = 1,    // Default values for columns that may not exist
                    TravelCheckNum = 1,
                    MiscCheckNum = 1,
                    SharedAccounts = 0
                });
            }
        }

        // If we have the new columns, read them in a second pass
        if (columns.Contains("HostCheckNum") && items.Count > 0)
        {
            using var detailCommand = connection.CreateCommand();
            detailCommand.CommandText = "SELECT Id, HostCheckNum, TravelCheckNum, MiscCheckNum, SharedAccounts FROM CheckNumberConfigs";
            items.Clear();
            using var detailReader = detailCommand.ExecuteReader();
            while (detailReader.Read())
            {
                items.Add(new CheckNumberConfig
                {
                    Id = detailReader.GetInt32(0),
                    HostCheckNum = detailReader.IsDBNull(1) ? 1 : detailReader.GetInt32(1),
                    TravelCheckNum = detailReader.IsDBNull(2) ? 1 : detailReader.GetInt32(2),
                    MiscCheckNum = detailReader.IsDBNull(3) ? 1 : detailReader.GetInt32(3),
                    SharedAccounts = detailReader.IsDBNull(4) ? 0 : detailReader.GetInt32(4)
                });
            }
        }

        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.CheckNumberConfigs.Any(x => x.Id == item.Id))
            {
                target.CheckNumberConfigs.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigrateFacts(BnBDbContext source, BnBDbContext target)
    {
        // Use raw SQL to handle missing IsActive column in older databases
        var connection = source.Database.GetDbConnection();
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();

        // Check what columns exist
        using var schemaCommand = connection.CreateCommand();
        schemaCommand.CommandText = "PRAGMA table_info(Facts)";
        var columns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        using (var schemaReader = schemaCommand.ExecuteReader())
        {
            while (schemaReader.Read())
            {
                columns.Add(schemaReader.GetString(1));
            }
        }

        using var command = connection.CreateCommand();
        var hasIsActive = columns.Contains("IsActive");
        command.CommandText = hasIsActive
            ? "SELECT FactId, Category, Description, IsActive FROM Facts"
            : "SELECT FactId, Category, Description FROM Facts";

        var items = new List<Fact>();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                items.Add(new Fact
                {
                    FactId = reader.GetInt32(0),
                    Category = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                    Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    IsActive = hasIsActive ? (!reader.IsDBNull(3) && reader.GetBoolean(3)) : true
                });
            }
        }

        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.Facts.Any(x => x.FactId == item.FactId))
            {
                target.Facts.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigrateGuests(BnBDbContext source, BnBDbContext target)
    {
        var items = FixDateTimeKinds(source.Guests.AsNoTracking().ToList());
        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.Guests.Any(x => x.Id == item.Id))
            {
                target.Guests.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigrateProperties(BnBDbContext source, BnBDbContext target)
    {
        var items = FixDateTimeKinds(source.Properties.AsNoTracking().ToList());
        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.Properties.Any(x => x.AccountNumber == item.AccountNumber))
            {
                target.Properties.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigrateRoomTypes(BnBDbContext source, BnBDbContext target)
    {
        var items = FixDateTimeKinds(source.RoomTypes.AsNoTracking().ToList());
        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.RoomTypes.Any(x => x.Id == item.Id))
            {
                target.RoomTypes.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigrateAccommodations(BnBDbContext source, BnBDbContext target)
    {
        var items = FixDateTimeKinds(source.Accommodations.AsNoTracking().ToList());
        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.Accommodations.Any(x => x.Id == item.Id))
            {
                target.Accommodations.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigratePayments(BnBDbContext source, BnBDbContext target)
    {
        var items = FixDateTimeKinds(source.Payments.AsNoTracking().ToList());
        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.Payments.Any(x => x.Id == item.Id))
            {
                target.Payments.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigrateChecks(BnBDbContext source, BnBDbContext target)
    {
        // Use raw SQL to handle missing Category/ConfirmationNumber columns in older databases
        var connection = source.Database.GetDbConnection();
        if (connection.State != System.Data.ConnectionState.Open)
            connection.Open();

        using var command = connection.CreateCommand();
        // Join with Accommodations to get ConfirmationNumber since it may not exist in Checks table
        command.CommandText = @"
            SELECT c.Id, c.AccommodationId, a.ConfirmationNumber, c.CheckNumber, c.Amount,
                   c.CheckDate, c.PayableTo, c.Memo, c.IsVoid, c.Comments
            FROM Checks c
            LEFT JOIN Accommodations a ON c.AccommodationId = a.Id";

        var items = new List<Check>();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                items.Add(new Check
                {
                    Id = reader.GetInt32(0),
                    AccommodationId = reader.GetInt32(1),
                    ConfirmationNumber = reader.IsDBNull(2) ? 0 : reader.GetInt64(2),
                    CheckNumber = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    Amount = reader.GetDecimal(4),
                    CheckDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5),
                    PayableTo = reader.IsDBNull(6) ? null : reader.GetString(6),
                    Memo = reader.IsDBNull(7) ? null : reader.GetString(7),
                    IsVoid = !reader.IsDBNull(8) && reader.GetBoolean(8),
                    Comments = reader.IsDBNull(9) ? null : reader.GetString(9),
                    Category = null // Category column may not exist in source
                });
            }
        }

        items = FixDateTimeKinds(items);
        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.Checks.Any(x => x.Id == item.Id))
            {
                target.Checks.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void MigratePropertyFacts(BnBDbContext source, BnBDbContext target)
    {
        var items = FixDateTimeKinds(source.PropertyFacts.AsNoTracking().ToList());
        if (items.Count == 0) return;

        foreach (var item in items)
        {
            if (!target.PropertyFacts.Any(x => x.PropertyFactId == item.PropertyFactId))
            {
                target.PropertyFacts.Add(item);
            }
        }
        target.SaveChanges();
    }

    private void ResetSequences(BnBDbContext context)
    {
        // PostgreSQL uses sequences for auto-increment columns
        // We need to reset them after inserting data with explicit IDs
        var sequences = new[]
        {
            ("TaxRates", "Id"),
            ("TaxPlans", "Id"),
            ("CompanyInfo", "Id"),
            ("CommonTexts", "Id"),
            ("CheckNumberConfigs", "Id"),
            ("Facts", "FactId"),
            ("Guests", "Id"),
            ("Properties", "AccountNumber"),
            ("RoomTypes", "Id"),
            ("Accommodations", "Id"),
            ("Payments", "Id"),
            ("Checks", "Id"),
            ("PropertyFacts", "PropertyFactId")
        };

        foreach (var (table, column) in sequences)
        {
            try
            {
                // Get the sequence name (PostgreSQL convention: tablename_columnname_seq)
                var sql = $@"
                    SELECT setval(
                        pg_get_serial_sequence('""{table}""', '{column}'),
                        COALESCE((SELECT MAX(""{column}"") FROM ""{table}""), 0) + 1,
                        false
                    )";
                context.Database.ExecuteSqlRaw(sql);
            }
            catch
            {
                // Some tables may not have sequences (e.g., if they use natural keys)
                // Continue with other sequences
            }
        }
    }
}
