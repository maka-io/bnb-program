using Microsoft.EntityFrameworkCore;
using BnB.Core.Models;

namespace BnB.Data.Context;

/// <summary>
/// Entity Framework Core database context for the BnB application.
/// Replaces the legacy DAO/Access database connection (gBNB in BNB1.BAS).
/// </summary>
public class BnBDbContext : DbContext
{
    public BnBDbContext(DbContextOptions<BnBDbContext> options) : base(options)
    {
    }

    // DbSets for each entity
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<Accommodation> Accommodations => Set<Accommodation>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<TaxRate> TaxRates => Set<TaxRate>();
    public DbSet<RoomType> RoomTypes => Set<RoomType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Guest configuration
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.ConfirmationNumber);
            entity.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(20);
            entity.Property(e => e.ZipCode).HasMaxLength(20);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(100);
        });

        // Property (Host) configuration
        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.AccountNumber);
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.ContactName).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(20);
            entity.Property(e => e.ZipCode).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Fax).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PercentToHost).HasPrecision(5, 2);
            entity.Property(e => e.FuturePercent).HasPrecision(5, 2);
            entity.Property(e => e.TaxPlanCode).HasMaxLength(10);
        });

        // Accommodation configuration
        modelBuilder.Entity<Accommodation>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DailyGrossRate).HasPrecision(10, 2);
            entity.Property(e => e.DailyNetRate).HasPrecision(10, 2);
            entity.Property(e => e.TotalGrossWithTax).HasPrecision(10, 2);
            entity.Property(e => e.TotalNetWithTax).HasPrecision(10, 2);
            entity.Property(e => e.TotalTax).HasPrecision(10, 2);
            entity.Property(e => e.Tax1).HasPrecision(10, 2);
            entity.Property(e => e.Tax2).HasPrecision(10, 2);
            entity.Property(e => e.Tax3).HasPrecision(10, 2);
            entity.Property(e => e.ServiceFee).HasPrecision(10, 2);
            entity.Property(e => e.OverridePercentToHost).HasPrecision(5, 2);
            entity.Property(e => e.PaymentType).HasMaxLength(20);
            entity.Property(e => e.OverrideTaxPlanCode).HasMaxLength(10);
            entity.Property(e => e.RoomType).HasMaxLength(50);

            // Relationships
            entity.HasOne(e => e.Guest)
                .WithMany(g => g.Accommodations)
                .HasForeignKey(e => e.ConfirmationNumber);

            entity.HasOne(e => e.Property)
                .WithMany(p => p.Accommodations)
                .HasForeignKey(e => e.PropertyAccountNumber);
        });

        // Payment configuration
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount).HasPrecision(10, 2);
            entity.Property(e => e.CheckNumber).HasMaxLength(50);
            entity.Property(e => e.ReceivedFrom).HasMaxLength(100);
            entity.Property(e => e.AppliedTo).HasMaxLength(100);

            // Relationship
            entity.HasOne(e => e.Guest)
                .WithMany(g => g.Payments)
                .HasForeignKey(e => e.ConfirmationNumber);
        });

        // TaxRate configuration
        modelBuilder.Entity<TaxRate>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.TaxOne).HasPrecision(5, 4);
            entity.Property(e => e.TaxTwo).HasPrecision(5, 4);
            entity.Property(e => e.TaxThree).HasPrecision(5, 4);
            entity.Property(e => e.FutureTaxOne).HasPrecision(5, 4);
            entity.Property(e => e.FutureTaxTwo).HasPrecision(5, 4);
            entity.Property(e => e.FutureTaxThree).HasPrecision(5, 4);
            entity.Property(e => e.TaxOneDescription).HasMaxLength(50);
            entity.Property(e => e.TaxTwoDescription).HasMaxLength(50);
            entity.Property(e => e.TaxThreeDescription).HasMaxLength(50);
        });

        // RoomType configuration
        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.DefaultRate).HasPrecision(10, 2);

            // Relationship
            entity.HasOne(e => e.Property)
                .WithMany(p => p.RoomTypes)
                .HasForeignKey(e => e.PropertyAccountNumber);
        });
    }
}
