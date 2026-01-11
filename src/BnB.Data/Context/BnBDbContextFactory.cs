using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BnB.Data.Context;

/// <summary>
/// Design-time factory for EF Core migrations.
/// Used by 'dotnet ef migrations' commands.
/// </summary>
public class BnBDbContextFactory : IDesignTimeDbContextFactory<BnBDbContext>
{
    public BnBDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BnBDbContext>();

        // Use SQLite for development/migrations
        // Database file will be created in the output directory
        optionsBuilder.UseSqlite("Data Source=bnb.db");

        return new BnBDbContext(optionsBuilder.Options);
    }
}
