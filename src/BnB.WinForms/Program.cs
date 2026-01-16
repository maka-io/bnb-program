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
                // For PostgreSQL, use EnsureCreated since migrations were generated for SQLite
                dbContext.Database.EnsureCreated();

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
            // Add RoomCount column to RoomTypes if it doesn't exist
            dbContext.Database.ExecuteSqlRaw(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE table_name = 'RoomTypes' AND column_name = 'RoomCount'
                    ) THEN
                        ALTER TABLE ""RoomTypes"" ADD COLUMN ""RoomCount"" INTEGER DEFAULT 1 NOT NULL;
                    END IF;
                END $$;
            ");
        }
        catch
        {
            // Ignore errors - column may already exist or table may not exist yet
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

        try
        {
            // Add RoomCount column to RoomTypes if it doesn't exist
            dbContext.Database.ExecuteSqlRaw("ALTER TABLE RoomTypes ADD COLUMN RoomCount INTEGER DEFAULT 1");
        }
        catch
        {
            // Column already exists
        }
    }
}
