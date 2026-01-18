using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BnB.Data.Context;
using BnB.WinForms.Forms;
using BnB.WinForms.Services;
using BnB.Core.Services;
using QuestPDF.Infrastructure;

namespace BnB.WinForms;

static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;
    public static IConfiguration Configuration { get; private set; } = null!;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Enable legacy timestamp behavior for Npgsql to handle DateTime with Kind=Unspecified
        // This allows DateTime values without explicit UTC kind to work with PostgreSQL
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        // Configure QuestPDF license (Community license for open source/small business)
        QuestPDF.Settings.License = LicenseType.Community;

        // Check for database reset marker (created by Reset Database menu option)
        CheckAndPerformDatabaseReset();

        ApplicationConfiguration.Initialize();

        // Load configuration
        Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Configure services
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        // Ensure database is created and migrated
        using (var scope = ServiceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<BnBDbContext>();
            var provider = Configuration["Database:Provider"] ?? "SQLite";

            if (provider.Equals("PostgreSQL", StringComparison.OrdinalIgnoreCase))
            {
                // For PostgreSQL, ensure all tables exist
                // EnsureCreated() creates database and schema if needed
                var created = dbContext.Database.EnsureCreated();
                if (created)
                {
                    System.Diagnostics.Debug.WriteLine("PostgreSQL database and schema created.");
                }

                // Apply schema updates for new columns
                ApplyPostgresSchemaUpdates(dbContext);
            }
            else
            {
                // For SQLite, use Migrate to apply migrations
                dbContext.Database.Migrate();

                // Apply schema updates for columns that may be missing
                ApplySqliteSchemaUpdates(dbContext);
            }
        }

        // Run the main form
        var mainForm = ServiceProvider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register configuration
        services.AddSingleton(Configuration);

        // Get database provider from configuration
        var provider = Configuration["Database:Provider"] ?? "SQLite";

        // Register DbContext based on provider
        services.AddDbContext<BnBDbContext>(options =>
        {
            if (provider.Equals("PostgreSQL", StringComparison.OrdinalIgnoreCase))
            {
                var connectionString = BuildPostgreSQLConnectionString();
                options.UseNpgsql(connectionString);
            }
            else
            {
                var dbPath = GetSQLiteDatabasePath();
                options.UseSqlite($"Data Source={dbPath}");
            }
        });

        // Register business logic services
        services.AddSingleton<ITaxCalculationService, TaxCalculationService>();
        services.AddSingleton<ICurrencyToWordsService, CurrencyToWordsService>();
        services.AddSingleton<IValidationService, ValidationService>();
        services.AddSingleton<IChartService, ChartService>();
        services.AddSingleton<FormStateManager>();

        // Register forms
        services.AddTransient<MainForm>(sp => new MainForm(sp));
    }

    private static string BuildPostgreSQLConnectionString()
    {
        var host = Configuration["Database:PostgreSQL:Host"] ?? "localhost";
        var port = Configuration["Database:PostgreSQL:Port"] ?? "5432";
        var database = Configuration["Database:PostgreSQL:Database"] ?? "bnb";
        var username = Configuration["Database:PostgreSQL:Username"] ?? "postgres";
        var password = Configuration["Database:PostgreSQL:Password"] ?? "";

        return $"Host={host};Port={port};Database={database};Username={username};Password={password}";
    }

    public static string GetSQLiteDatabasePath()
    {
        // Check if custom path is specified in config
        var customPath = Configuration["Database:SQLite:DatabasePath"];
        if (!string.IsNullOrWhiteSpace(customPath))
        {
            return customPath;
        }

        // Default: Store database in LocalApplicationData folder
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var bnbDataPath = Path.Combine(appDataPath, "BnB");

        // Ensure directory exists
        Directory.CreateDirectory(bnbDataPath);

        return Path.Combine(bnbDataPath, "bnb.db");
    }

    /// <summary>
    /// Gets the current database provider name
    /// </summary>
    public static string GetCurrentDatabaseProvider()
    {
        return Configuration["Database:Provider"] ?? "SQLite";
    }

    /// <summary>
    /// Gets the path to the appsettings.json file
    /// </summary>
    public static string GetSettingsFilePath()
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
    }

    /// <summary>
    /// Gets the path to the database reset marker file
    /// </summary>
    public static string GetDatabaseResetMarkerPath()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var bnbDataPath = Path.Combine(appDataPath, "BnB");
        Directory.CreateDirectory(bnbDataPath);
        return Path.Combine(bnbDataPath, ".reset_database");
    }

    /// <summary>
    /// Checks for database reset marker and deletes the database if found.
    /// Called at application startup before EF opens the database.
    /// Creates an automatic backup before deleting.
    /// </summary>
    private static void CheckAndPerformDatabaseReset()
    {
        try
        {
            var markerPath = GetDatabaseResetMarkerPath();
            if (!File.Exists(markerPath))
                return;

            // Marker exists - backup and delete the database
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var bnbDataPath = Path.Combine(appDataPath, "BnB");
            var dbPath = Path.Combine(bnbDataPath, "bnb.db");

            string? backupPath = null;

            // Create automatic backup before deleting
            if (File.Exists(dbPath))
            {
                var backupFolder = Path.Combine(bnbDataPath, "Backups");
                Directory.CreateDirectory(backupFolder);

                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                backupPath = Path.Combine(backupFolder, $"bnb_prereset_{timestamp}.db");

                File.Copy(dbPath, backupPath, overwrite: true);
                System.Diagnostics.Debug.WriteLine($"Pre-reset backup created: {backupPath}");

                // Now delete the database
                File.Delete(dbPath);
            }

            // Delete WAL files if present
            var shmPath = dbPath + "-shm";
            var walPath = dbPath + "-wal";
            if (File.Exists(shmPath)) File.Delete(shmPath);
            if (File.Exists(walPath)) File.Delete(walPath);

            // Delete the marker file
            File.Delete(markerPath);

            // Show message about backup location
            if (backupPath != null)
            {
                MessageBox.Show(
                    $"Database has been reset.\n\n" +
                    $"A backup was saved to:\n{backupPath}\n\n" +
                    "A fresh database will now be created.",
                    "Database Reset Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            System.Diagnostics.Debug.WriteLine("Database reset completed successfully.");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error during database reset: {ex.Message}");
            MessageBox.Show(
                $"Error during database reset: {ex.Message}\n\n" +
                "The application will continue but you may need to reset manually.",
                "Reset Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    /// <summary>
    /// Apply schema updates for PostgreSQL that EnsureCreated doesn't handle
    /// </summary>
    private static void ApplyPostgresSchemaUpdates(BnBDbContext dbContext)
    {
        try
        {
            // Add Logo column to CompanyInfo if it doesn't exist
            dbContext.Database.ExecuteSqlRaw(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'CompanyInfo' AND column_name = 'Logo'
                    ) THEN
                        ALTER TABLE ""CompanyInfo"" ADD COLUMN ""Logo"" BYTEA;
                    END IF;
                END $$;
            ");
        }
        catch
        {
            // Ignore errors - column may already exist or table may not exist yet
        }

        try
        {
            // Add Category and ConfirmationNumber columns to Checks if they don't exist
            dbContext.Database.ExecuteSqlRaw(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'Checks' AND column_name = 'Category'
                    ) THEN
                        ALTER TABLE ""Checks"" ADD COLUMN ""Category"" VARCHAR(50);
                    END IF;
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'Checks' AND column_name = 'ConfirmationNumber'
                    ) THEN
                        ALTER TABLE ""Checks"" ADD COLUMN ""ConfirmationNumber"" BIGINT DEFAULT 0;
                    END IF;
                END $$;
            ");
        }
        catch
        {
            // Ignore errors - columns may already exist or table may not exist yet
        }

        try
        {
            // Add TaxPlan rate fields if they don't exist
            dbContext.Database.ExecuteSqlRaw(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'Tax1Rate') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""Tax1Rate"" DECIMAL(10,4) DEFAULT 0;
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'Tax1Description') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""Tax1Description"" VARCHAR(50);
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'Tax1Application') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""Tax1Application"" INTEGER DEFAULT 2;
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'FutureTax1Rate') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""FutureTax1Rate"" DECIMAL(10,4);
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'FutureTax1EffectiveDate') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""FutureTax1EffectiveDate"" TIMESTAMP;
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'Tax2Rate') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""Tax2Rate"" DECIMAL(10,4) DEFAULT 0;
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'Tax2Description') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""Tax2Description"" VARCHAR(50);
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'Tax2Application') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""Tax2Application"" INTEGER DEFAULT 2;
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'FutureTax2Rate') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""FutureTax2Rate"" DECIMAL(10,4);
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'FutureTax2EffectiveDate') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""FutureTax2EffectiveDate"" TIMESTAMP;
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'Tax3Rate') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""Tax3Rate"" DECIMAL(10,4) DEFAULT 0;
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'Tax3Description') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""Tax3Description"" VARCHAR(50);
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'Tax3Application') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""Tax3Application"" INTEGER DEFAULT 2;
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'FutureTax3Rate') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""FutureTax3Rate"" DECIMAL(10,4);
                    END IF;
                    IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'TaxPlans' AND column_name = 'FutureTax3EffectiveDate') THEN
                        ALTER TABLE ""TaxPlans"" ADD COLUMN ""FutureTax3EffectiveDate"" TIMESTAMP;
                    END IF;
                END $$;
            ");
        }
        catch
        {
            // Ignore errors - columns may already exist or table may not exist yet
        }

        // Create RoomBlackouts table if it doesn't exist
        try
        {
            dbContext.Database.ExecuteSqlRaw(@"
                CREATE TABLE IF NOT EXISTS ""RoomBlackouts"" (
                    ""Id"" SERIAL PRIMARY KEY,
                    ""RoomTypeId"" INTEGER NOT NULL,
                    ""StartDate"" TIMESTAMP NOT NULL,
                    ""EndDate"" TIMESTAMP NOT NULL,
                    ""Reason"" VARCHAR(200) NOT NULL,
                    ""EntryDate"" TIMESTAMP,
                    ""EntryUser"" VARCHAR(50),
                    FOREIGN KEY (""RoomTypeId"") REFERENCES ""RoomTypes""(""Id"") ON DELETE CASCADE
                );

                CREATE INDEX IF NOT EXISTS ""IX_RoomBlackouts_RoomTypeId_StartDate_EndDate""
                ON ""RoomBlackouts"" (""RoomTypeId"", ""StartDate"", ""EndDate"");
            ");
        }
        catch
        {
            // Table already exists or other error
        }

        // Add GuestId column to Accommodations if it doesn't exist
        // This is a required foreign key linking accommodations to guests
        try
        {
            dbContext.Database.ExecuteSqlRaw(@"
                DO $$
                BEGIN
                    -- Add GuestId column if it doesn't exist
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'Accommodations' AND column_name = 'GuestId'
                    ) THEN
                        ALTER TABLE ""Accommodations"" ADD COLUMN ""GuestId"" BIGINT NOT NULL DEFAULT 0;

                        -- Populate GuestId from ConfirmationNumber for existing records
                        -- (Previously accommodations linked to guests via ConfirmationNumber)
                        UPDATE ""Accommodations"" SET ""GuestId"" = ""ConfirmationNumber""
                        WHERE ""GuestId"" = 0 AND EXISTS (
                            SELECT 1 FROM ""Guests"" WHERE ""ConfirmationNumber"" = ""Accommodations"".""ConfirmationNumber""
                        );
                    END IF;
                END $$;
            ");
        }
        catch
        {
            // Column already exists or other error
        }

        // Add DefaultRate column to RoomTypes if it doesn't exist
        try
        {
            dbContext.Database.ExecuteSqlRaw(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'RoomTypes' AND column_name = 'DefaultRate'
                    ) THEN
                        ALTER TABLE ""RoomTypes"" ADD COLUMN ""DefaultRate"" DECIMAL(10,2);
                    END IF;
                END $$;
            ");
        }
        catch
        {
            // Column already exists or other error
        }

        // Migrate Guest table to use Id as primary key (if needed)
        try
        {
            dbContext.Database.ExecuteSqlRaw(@"
                DO $$
                BEGIN
                    -- Add Id column to Guests if it doesn't exist
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'Guests' AND column_name = 'Id'
                    ) THEN
                        -- Add Id column as serial (auto-increment)
                        ALTER TABLE ""Guests"" ADD COLUMN ""Id"" SERIAL;

                        -- Make ConfirmationNumber not the primary key anymore
                        -- and add unique constraint instead
                        ALTER TABLE ""Guests"" DROP CONSTRAINT IF EXISTS ""PK_Guests"";
                        ALTER TABLE ""Guests"" ADD PRIMARY KEY (""Id"");
                        CREATE UNIQUE INDEX IF NOT EXISTS ""IX_Guests_ConfirmationNumber"" ON ""Guests""(""ConfirmationNumber"");
                    END IF;

                    -- Add GuestId to Accommodations if it doesn't exist
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'Accommodations' AND column_name = 'GuestId'
                    ) THEN
                        ALTER TABLE ""Accommodations"" ADD COLUMN ""GuestId"" INTEGER NOT NULL DEFAULT 0;
                        -- Populate GuestId from Guest.Id based on ConfirmationNumber
                        UPDATE ""Accommodations"" a SET ""GuestId"" = g.""Id""
                        FROM ""Guests"" g WHERE g.""ConfirmationNumber"" = a.""ConfirmationNumber"";
                    END IF;

                    -- Add GuestId to Payments if it doesn't exist
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'Payments' AND column_name = 'GuestId'
                    ) THEN
                        ALTER TABLE ""Payments"" ADD COLUMN ""GuestId"" INTEGER NOT NULL DEFAULT 0;
                        UPDATE ""Payments"" p SET ""GuestId"" = g.""Id""
                        FROM ""Guests"" g WHERE g.""ConfirmationNumber"" = p.""ConfirmationNumber"";
                    END IF;

                    -- Add GuestId to TravelAgentBookings if it doesn't exist
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'TravelAgentBookings' AND column_name = 'GuestId'
                    ) THEN
                        ALTER TABLE ""TravelAgentBookings"" ADD COLUMN ""GuestId"" INTEGER NOT NULL DEFAULT 0;
                        UPDATE ""TravelAgentBookings"" t SET ""GuestId"" = g.""Id""
                        FROM ""Guests"" g WHERE g.""ConfirmationNumber"" = t.""ConfirmationNumber"";
                    END IF;

                    -- Add GuestId to CarRentals if it doesn't exist
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'CarRentals' AND column_name = 'GuestId'
                    ) THEN
                        ALTER TABLE ""CarRentals"" ADD COLUMN ""GuestId"" INTEGER NOT NULL DEFAULT 0;
                        UPDATE ""CarRentals"" c SET ""GuestId"" = g.""Id""
                        FROM ""Guests"" g WHERE g.""ConfirmationNumber"" = c.""ConfirmationNumber"";
                    END IF;
                END $$;
            ");
        }
        catch
        {
            // Migration already done or other error
        }
    }

    /// <summary>
    /// Apply schema updates for SQLite that migrations may have missed
    /// </summary>
    private static void ApplySqliteSchemaUpdates(BnBDbContext dbContext)
    {
        // SQLite doesn't support checking if column exists easily, so we try to add and catch errors
        try
        {
            // Add Category column to Checks if it doesn't exist
            dbContext.Database.ExecuteSqlRaw("ALTER TABLE Checks ADD COLUMN Category TEXT");
        }
        catch
        {
            // Column already exists
        }

        try
        {
            // Add ConfirmationNumber column to Checks if it doesn't exist
            dbContext.Database.ExecuteSqlRaw("ALTER TABLE Checks ADD COLUMN ConfirmationNumber INTEGER DEFAULT 0");
        }
        catch
        {
            // Column already exists
        }

        // Add TaxPlan rate fields if they don't exist
        var taxPlanColumns = new[]
        {
            "ALTER TABLE TaxPlans ADD COLUMN Tax1Rate TEXT DEFAULT '0'",
            "ALTER TABLE TaxPlans ADD COLUMN Tax1Description TEXT",
            "ALTER TABLE TaxPlans ADD COLUMN Tax1Application INTEGER DEFAULT 2",
            "ALTER TABLE TaxPlans ADD COLUMN FutureTax1Rate TEXT",
            "ALTER TABLE TaxPlans ADD COLUMN FutureTax1EffectiveDate TEXT",
            "ALTER TABLE TaxPlans ADD COLUMN Tax2Rate TEXT DEFAULT '0'",
            "ALTER TABLE TaxPlans ADD COLUMN Tax2Description TEXT",
            "ALTER TABLE TaxPlans ADD COLUMN Tax2Application INTEGER DEFAULT 2",
            "ALTER TABLE TaxPlans ADD COLUMN FutureTax2Rate TEXT",
            "ALTER TABLE TaxPlans ADD COLUMN FutureTax2EffectiveDate TEXT",
            "ALTER TABLE TaxPlans ADD COLUMN Tax3Rate TEXT DEFAULT '0'",
            "ALTER TABLE TaxPlans ADD COLUMN Tax3Description TEXT",
            "ALTER TABLE TaxPlans ADD COLUMN Tax3Application INTEGER DEFAULT 2",
            "ALTER TABLE TaxPlans ADD COLUMN FutureTax3Rate TEXT",
            "ALTER TABLE TaxPlans ADD COLUMN FutureTax3EffectiveDate TEXT"
        };

        foreach (var sql in taxPlanColumns)
        {
            try
            {
                dbContext.Database.ExecuteSqlRaw(sql);
            }
            catch
            {
                // Column already exists
            }
        }

        // Add DefaultRate column to RoomTypes if it doesn't exist
        try
        {
            dbContext.Database.ExecuteSqlRaw("ALTER TABLE RoomTypes ADD COLUMN DefaultRate TEXT");
        }
        catch
        {
            // Column already exists
        }

        // Add IsActive column to RoomTypes if it doesn't exist
        try
        {
            dbContext.Database.ExecuteSqlRaw("ALTER TABLE RoomTypes ADD COLUMN IsActive INTEGER NOT NULL DEFAULT 1");
        }
        catch
        {
            // Column already exists
        }

        // Create RoomBlackouts table if it doesn't exist
        try
        {
            dbContext.Database.ExecuteSqlRaw(@"
                CREATE TABLE IF NOT EXISTS RoomBlackouts (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomTypeId INTEGER NOT NULL,
                    StartDate TEXT NOT NULL,
                    EndDate TEXT NOT NULL,
                    Reason TEXT NOT NULL,
                    EntryDate TEXT,
                    EntryUser TEXT,
                    FOREIGN KEY (RoomTypeId) REFERENCES RoomTypes(Id) ON DELETE CASCADE
                )");

            // Create index if it doesn't exist
            dbContext.Database.ExecuteSqlRaw(@"
                CREATE INDEX IF NOT EXISTS IX_RoomBlackouts_RoomTypeId_StartDate_EndDate
                ON RoomBlackouts (RoomTypeId, StartDate, EndDate)");
        }
        catch
        {
            // Table already exists or other error
        }

        // Add GuestId column to Accommodations if it doesn't exist
        // This is a required foreign key linking accommodations to guests
        try
        {
            dbContext.Database.ExecuteSqlRaw("ALTER TABLE Accommodations ADD COLUMN GuestId INTEGER NOT NULL DEFAULT 0");
        }
        catch
        {
            // Column already exists
        }

        // Populate GuestId from ConfirmationNumber for existing records where GuestId is 0
        // (Previously accommodations linked to guests via ConfirmationNumber)
        try
        {
            dbContext.Database.ExecuteSqlRaw(@"
                UPDATE Accommodations SET GuestId = ConfirmationNumber
                WHERE GuestId = 0 AND ConfirmationNumber IN (SELECT ConfirmationNumber FROM Guests)");
        }
        catch
        {
            // Ignore errors
        }

        // Add Property payment policy columns if they don't exist
        var propertyPaymentPolicyColumns = new[]
        {
            "ALTER TABLE Properties ADD COLUMN DefaultDepositPercent TEXT",
            "ALTER TABLE Properties ADD COLUMN DefaultDepositDueDays INTEGER",
            "ALTER TABLE Properties ADD COLUMN DefaultPrepaymentDueDays INTEGER",
            "ALTER TABLE Properties ADD COLUMN DefaultCancellationNoticeDays INTEGER",
            "ALTER TABLE Properties ADD COLUMN DefaultCancellationFeePercent TEXT",
            "ALTER TABLE Properties ADD COLUMN CancellationProcessingFee TEXT",
            "ALTER TABLE Properties ADD COLUMN HasPeakPeriodPolicy INTEGER DEFAULT 0",
            "ALTER TABLE Properties ADD COLUMN PeakPeriodPrepaymentDueDays INTEGER",
            "ALTER TABLE Properties ADD COLUMN PeakPeriodCancellationNoticeDays INTEGER",
            "ALTER TABLE Properties ADD COLUMN PeakPeriodCancellationFeePercent TEXT",
            "ALTER TABLE Properties ADD COLUMN PeakPeriodStartMonth INTEGER",
            "ALTER TABLE Properties ADD COLUMN PeakPeriodStartDay INTEGER",
            "ALTER TABLE Properties ADD COLUMN PeakPeriodEndMonth INTEGER",
            "ALTER TABLE Properties ADD COLUMN PeakPeriodEndDay INTEGER"
        };

        foreach (var sql in propertyPaymentPolicyColumns)
        {
            try
            {
                dbContext.Database.ExecuteSqlRaw(sql);
            }
            catch
            {
                // Column already exists
            }
        }

        // Migrate to new Guest.Id as primary key (instead of ConfirmationNumber)
        // This is a major schema change that affects multiple tables
        MigrateToGuestIdPrimaryKey(dbContext);
    }

    /// <summary>
    /// Migrates the database to use Guest.Id (auto-increment) as the primary key.
    /// Guest no longer has ConfirmationNumber - that is now only on Accommodation.
    /// </summary>
    private static void MigrateToGuestIdPrimaryKey(BnBDbContext dbContext)
    {
        try
        {
            // Check if Guest table exists and what columns it has
            var guestTableInfo = dbContext.Database.SqlQueryRaw<string>(
                "SELECT sql FROM sqlite_master WHERE type='table' AND name='Guests'").ToList();

            if (guestTableInfo.Count == 0 || guestTableInfo[0] == null)
                return;

            var guestCreateSql = guestTableInfo[0];

            // Check if migration is needed:
            // 1. If table has ConfirmationNumber column, we need to remove it
            // 2. If table doesn't have Id as primary key, we need to add it
            bool hasConfirmationNumber = guestCreateSql.Contains("ConfirmationNumber");
            bool hasIdAsPrimaryKey = guestCreateSql.Contains("\"Id\" INTEGER") && guestCreateSql.Contains("PRIMARY KEY");

            if (!hasConfirmationNumber && hasIdAsPrimaryKey)
            {
                System.Diagnostics.Debug.WriteLine("Guest table already migrated - has Id PK and no ConfirmationNumber.");
                return;
            }

            System.Diagnostics.Debug.WriteLine("Migrating Guest table to remove ConfirmationNumber and use Id as primary key...");

            // Disable foreign keys temporarily
            dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=OFF");

            // Step 1: Create new Guests table with Id as PK and NO ConfirmationNumber
            dbContext.Database.ExecuteSqlRaw(@"
                DROP TABLE IF EXISTS Guests_new");
            dbContext.Database.ExecuteSqlRaw(@"
                CREATE TABLE Guests_new (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    Address TEXT,
                    BusinessAddress TEXT,
                    City TEXT,
                    State TEXT,
                    ZipCode TEXT,
                    Country TEXT,
                    HomePhone TEXT,
                    BusinessPhone TEXT,
                    FaxNumber TEXT,
                    Email TEXT,
                    DateBooked TEXT,
                    BookedBy TEXT,
                    Referral TEXT,
                    ReservationFee TEXT,
                    TravelingWith TEXT,
                    Comments TEXT,
                    LabelFlag INTEGER NOT NULL DEFAULT 0,
                    Closure TEXT,
                    EntryDate TEXT,
                    EntryUser TEXT,
                    UpdateDate TEXT,
                    UpdateUser TEXT,
                    RevisionDate TEXT,
                    Revision INTEGER
                )");

            // Step 2: Copy data from old Guests table (Id will auto-increment)
            // We need to keep track of the mapping from old ConfirmationNumber to new Id
            if (hasConfirmationNumber)
            {
                // Create a temporary mapping table
                dbContext.Database.ExecuteSqlRaw(@"
                    DROP TABLE IF EXISTS _ConfToIdMapping");
                dbContext.Database.ExecuteSqlRaw(@"
                    CREATE TABLE _ConfToIdMapping (
                        ConfirmationNumber INTEGER PRIMARY KEY,
                        NewGuestId INTEGER
                    )");

                // Copy guests and build mapping
                dbContext.Database.ExecuteSqlRaw(@"
                    INSERT INTO Guests_new (FirstName, LastName, Address, BusinessAddress,
                        City, State, ZipCode, Country, HomePhone, BusinessPhone, FaxNumber, Email,
                        DateBooked, BookedBy, Referral, ReservationFee, TravelingWith, Comments,
                        LabelFlag, Closure, EntryDate, EntryUser, UpdateDate, UpdateUser, RevisionDate, Revision)
                    SELECT FirstName, LastName, Address, BusinessAddress,
                        City, State, ZipCode, Country, HomePhone, BusinessPhone, FaxNumber, Email,
                        DateBooked, BookedBy, Referral, ReservationFee, TravelingWith, Comments,
                        LabelFlag, Closure, EntryDate, EntryUser, UpdateDate, UpdateUser, RevisionDate, Revision
                    FROM Guests ORDER BY ConfirmationNumber");

                // Build the mapping by matching order (both sorted by ConfirmationNumber/Id)
                dbContext.Database.ExecuteSqlRaw(@"
                    INSERT INTO _ConfToIdMapping (ConfirmationNumber, NewGuestId)
                    SELECT g.ConfirmationNumber, gn.Id
                    FROM (SELECT ConfirmationNumber, ROW_NUMBER() OVER (ORDER BY ConfirmationNumber) as rn FROM Guests) g
                    JOIN (SELECT Id, ROW_NUMBER() OVER (ORDER BY Id) as rn FROM Guests_new) gn ON g.rn = gn.rn");
            }

            // Step 3: Drop old Guests table and rename new one
            dbContext.Database.ExecuteSqlRaw("DROP TABLE Guests");
            dbContext.Database.ExecuteSqlRaw("ALTER TABLE Guests_new RENAME TO Guests");

            if (hasConfirmationNumber)
            {
                // Step 4: Update Accommodations.GuestId using the mapping
                try { dbContext.Database.ExecuteSqlRaw("ALTER TABLE Accommodations ADD COLUMN GuestId INTEGER NOT NULL DEFAULT 0"); } catch { }
                dbContext.Database.ExecuteSqlRaw(@"
                    UPDATE Accommodations
                    SET GuestId = (SELECT NewGuestId FROM _ConfToIdMapping WHERE _ConfToIdMapping.ConfirmationNumber = Accommodations.ConfirmationNumber)
                    WHERE EXISTS (SELECT 1 FROM _ConfToIdMapping WHERE _ConfToIdMapping.ConfirmationNumber = Accommodations.ConfirmationNumber)");

                // Step 5: Update Payments.GuestId
                try { dbContext.Database.ExecuteSqlRaw("ALTER TABLE Payments ADD COLUMN GuestId INTEGER NOT NULL DEFAULT 0"); } catch { }
                dbContext.Database.ExecuteSqlRaw(@"
                    UPDATE Payments
                    SET GuestId = (SELECT NewGuestId FROM _ConfToIdMapping WHERE _ConfToIdMapping.ConfirmationNumber = Payments.ConfirmationNumber)
                    WHERE EXISTS (SELECT 1 FROM _ConfToIdMapping WHERE _ConfToIdMapping.ConfirmationNumber = Payments.ConfirmationNumber)");

                // Step 6: Update TravelAgentBookings.GuestId
                try { dbContext.Database.ExecuteSqlRaw("ALTER TABLE TravelAgentBookings ADD COLUMN GuestId INTEGER NOT NULL DEFAULT 0"); } catch { }
                dbContext.Database.ExecuteSqlRaw(@"
                    UPDATE TravelAgentBookings
                    SET GuestId = (SELECT NewGuestId FROM _ConfToIdMapping WHERE _ConfToIdMapping.ConfirmationNumber = TravelAgentBookings.ConfirmationNumber)
                    WHERE EXISTS (SELECT 1 FROM _ConfToIdMapping WHERE _ConfToIdMapping.ConfirmationNumber = TravelAgentBookings.ConfirmationNumber)");

                // Step 7: Update CarRentals.GuestId
                try { dbContext.Database.ExecuteSqlRaw("ALTER TABLE CarRentals ADD COLUMN GuestId INTEGER NOT NULL DEFAULT 0"); } catch { }
                dbContext.Database.ExecuteSqlRaw(@"
                    UPDATE CarRentals
                    SET GuestId = (SELECT NewGuestId FROM _ConfToIdMapping WHERE _ConfToIdMapping.ConfirmationNumber = CarRentals.ConfirmationNumber)
                    WHERE EXISTS (SELECT 1 FROM _ConfToIdMapping WHERE _ConfToIdMapping.ConfirmationNumber = CarRentals.ConfirmationNumber)");

                // Clean up mapping table
                dbContext.Database.ExecuteSqlRaw("DROP TABLE IF EXISTS _ConfToIdMapping");
            }

            // Re-enable foreign keys
            dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=ON");

            System.Diagnostics.Debug.WriteLine("Migration to Guest.Id as primary key completed successfully.");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error migrating to Guest.Id PK: {ex.Message}");
            // Re-enable foreign keys even on error
            try { dbContext.Database.ExecuteSqlRaw("PRAGMA foreign_keys=ON"); } catch { }
        }
    }
}
