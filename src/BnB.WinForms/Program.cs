using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BnB.Data.Context;
using BnB.WinForms.Forms;
using QuestPDF.Infrastructure;

namespace BnB.WinForms;

static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Configure QuestPDF license (Community license for open source/small business)
        QuestPDF.Settings.License = LicenseType.Community;

        ApplicationConfiguration.Initialize();

        // Configure services
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        // Ensure database is created
        using (var scope = ServiceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<BnBDbContext>();
            dbContext.Database.Migrate();
        }

        // Run the main form
        var mainForm = ServiceProvider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Get database path in user's local app data folder
        var dbPath = GetDatabasePath();

        // Register DbContext with SQLite
        services.AddDbContext<BnBDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath}"));

        // Register forms
        services.AddTransient<MainForm>(sp => new MainForm(sp));
    }

    private static string GetDatabasePath()
    {
        // Store database in LocalApplicationData folder
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var bnbDataPath = Path.Combine(appDataPath, "BnB");

        // Ensure directory exists
        Directory.CreateDirectory(bnbDataPath);

        return Path.Combine(bnbDataPath, "bnb.db");
    }
}
