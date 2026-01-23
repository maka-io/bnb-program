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

    // Core entities
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<Accommodation> Accommodations => Set<Accommodation>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Check> Checks => Set<Check>();

    // Lookup tables
    public DbSet<TaxRate> TaxRates => Set<TaxRate>();
    public DbSet<TaxPlan> TaxPlans => Set<TaxPlan>();
    public DbSet<RoomType> RoomTypes => Set<RoomType>();
    public DbSet<RoomBlackout> RoomBlackouts => Set<RoomBlackout>();

    // Property facts
    public DbSet<Fact> Facts => Set<Fact>();
    public DbSet<PropertyFact> PropertyFacts => Set<PropertyFact>();

    // Configuration
    public DbSet<CompanyInfo> CompanyInfo => Set<CompanyInfo>();
    public DbSet<CommonText> CommonTexts => Set<CommonText>();
    public DbSet<CheckNumberConfig> CheckNumberConfigs => Set<CheckNumberConfig>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Guest configuration (guesttbl)
        // Guest has 1:many relationship with Accommodations (a guest can have multiple bookings)
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id);  // Auto-increment primary key
            entity.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.BusinessAddress).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.HomePhone).HasMaxLength(50);
            entity.Property(e => e.BusinessPhone).HasMaxLength(50);
            entity.Property(e => e.FaxNumber).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.BookedBy).HasMaxLength(50);
            entity.Property(e => e.Referral).HasMaxLength(100);
            // ReservationFee moved to Accommodation
            entity.Property(e => e.TravelingWith).HasMaxLength(200);
            entity.Property(e => e.Comments).HasMaxLength(2000);
            entity.Property(e => e.Closure).HasMaxLength(2000);  // Long confirmation text
            entity.Property(e => e.EntryUser).HasMaxLength(50);
            entity.Property(e => e.UpdateUser).HasMaxLength(50);
        });

        // Property (Host) configuration (proptbl)
        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.AccountNumber);
            entity.Property(e => e.Location).HasMaxLength(100).IsRequired();
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.DBA).HasMaxLength(100);
            entity.Property(e => e.PropertyAddress).HasMaxLength(100);
            entity.Property(e => e.PropertyCity).HasMaxLength(50);
            entity.Property(e => e.PropertyState).HasMaxLength(50);
            entity.Property(e => e.PropertyZipCode).HasMaxLength(50);
            entity.Property(e => e.PropertyPhone).HasMaxLength(50);
            entity.Property(e => e.PropertyFax).HasMaxLength(50);
            entity.Property(e => e.MailingAddress).HasMaxLength(100);
            entity.Property(e => e.MailingCity).HasMaxLength(50);
            entity.Property(e => e.MailingState).HasMaxLength(50);
            entity.Property(e => e.MailingZipCode).HasMaxLength(50);
            entity.Property(e => e.MailingPhone1).HasMaxLength(50);
            entity.Property(e => e.MailingPhone2).HasMaxLength(50);
            entity.Property(e => e.MailingFax).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.WebUrl).HasMaxLength(200);
            entity.Property(e => e.CheckTo).HasMaxLength(100);
            entity.Property(e => e.PercentToHost).HasPrecision(5, 2);
            entity.Property(e => e.FuturePercent).HasPrecision(5, 2);
            entity.Property(e => e.GrossRatePercent).HasPrecision(5, 2);
            entity.Property(e => e.FederalTaxId).HasMaxLength(50);
            entity.Property(e => e.TaxPlanCode).HasMaxLength(10);
            entity.Property(e => e.DepositRequired).HasMaxLength(200);
            entity.Property(e => e.Exceptions).HasMaxLength(500);
            entity.Property(e => e.ExceptionsDescription).HasMaxLength(500);
        });

        // Accommodation configuration (bbtbl)
        modelBuilder.Entity<Accommodation>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.UnitName).HasMaxLength(50);
            entity.Property(e => e.UnitNameDescription).HasMaxLength(200);
            entity.Property(e => e.DailyGrossRate).HasPrecision(10, 2);
            entity.Property(e => e.DailyNetRate).HasPrecision(10, 2);
            entity.Property(e => e.TotalGrossWithTax).HasPrecision(10, 2);
            entity.Property(e => e.TotalNetWithTax).HasPrecision(10, 2);
            entity.Property(e => e.TotalTax).HasPrecision(10, 2);
            entity.Property(e => e.Tax1).HasPrecision(10, 2);
            entity.Property(e => e.Tax2).HasPrecision(10, 2);
            entity.Property(e => e.Tax3).HasPrecision(10, 2);
            entity.Property(e => e.ServiceFee).HasPrecision(10, 2);
            entity.Property(e => e.Commission).HasPrecision(10, 2);
            entity.Property(e => e.CommissionPaid).HasPrecision(10, 2);
            entity.Property(e => e.CommissionReceived).HasPrecision(10, 2);
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.OverridePercentToHost).HasPrecision(5, 2);
            entity.Property(e => e.OverrideTaxPlanCode).HasMaxLength(10);
            entity.Property(e => e.Comments).HasMaxLength(2000);
            entity.Property(e => e.NightNotes).HasMaxLength(2000);
            entity.Property(e => e.EntryUser).HasMaxLength(50);
            entity.Property(e => e.UpdateUser).HasMaxLength(50);

            entity.HasOne(e => e.Guest)
                .WithMany(g => g.Accommodations)
                .HasForeignKey(e => e.GuestId)
                .IsRequired();  // Every accommodation must have a guest

            entity.HasOne(e => e.Property)
                .WithMany(p => p.Accommodations)
                .HasForeignKey(e => e.PropertyAccountNumber);
        });

        // Payment configuration (paymentreceived)
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Amount).HasPrecision(10, 2);
            entity.Property(e => e.CheckNumber).HasMaxLength(50);
            entity.Property(e => e.ReceivedFrom).HasMaxLength(100);
            entity.Property(e => e.AppliedTo).HasMaxLength(100);
            entity.Property(e => e.DepositDue).HasPrecision(10, 2);
            entity.Property(e => e.PrepaymentDue).HasPrecision(10, 2);
            entity.Property(e => e.CancellationFee).HasPrecision(10, 2);
            entity.Property(e => e.RefundOwed).HasPrecision(10, 2);
            entity.Property(e => e.OtherCredit).HasPrecision(10, 2);
            entity.Property(e => e.DefaultCommission).HasPrecision(10, 2);

            entity.HasOne(e => e.Guest)
                .WithMany(g => g.Payments)
                .HasForeignKey(e => e.GuestId)
                .IsRequired();
        });

        // Check configuration (checktbl)
        modelBuilder.Entity<Check>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CheckNumber).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Amount).HasPrecision(10, 2);
            entity.Property(e => e.PayableTo).HasMaxLength(100);
            entity.Property(e => e.Memo).HasMaxLength(200);
            entity.Property(e => e.Comments).HasMaxLength(500);

            entity.HasOne(e => e.Accommodation)
                .WithMany()
                .HasForeignKey(e => e.AccommodationId);
        });

        // TaxRate configuration
        modelBuilder.Entity<TaxRate>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.TaxOne).HasPrecision(10, 4);
            entity.Property(e => e.TaxTwo).HasPrecision(10, 4);
            entity.Property(e => e.TaxThree).HasPrecision(10, 4);
            entity.Property(e => e.FutureTaxOne).HasPrecision(10, 4);
            entity.Property(e => e.FutureTaxTwo).HasPrecision(10, 4);
            entity.Property(e => e.FutureTaxThree).HasPrecision(10, 4);
            entity.Property(e => e.TaxOneDescription).HasMaxLength(50);
            entity.Property(e => e.TaxTwoDescription).HasMaxLength(50);
            entity.Property(e => e.TaxThreeDescription).HasMaxLength(50);
        });

        // TaxPlan configuration
        modelBuilder.Entity<TaxPlan>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PlanCode).HasMaxLength(10).IsRequired();
            entity.Property(e => e.PlanTitle).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.HasIndex(e => e.PlanCode).IsUnique();

            // Tax 1 fields
            entity.Property(e => e.Tax1Rate).HasPrecision(10, 4);
            entity.Property(e => e.Tax1Description).HasMaxLength(50);
            entity.Property(e => e.FutureTax1Rate).HasPrecision(10, 4);

            // Tax 2 fields
            entity.Property(e => e.Tax2Rate).HasPrecision(10, 4);
            entity.Property(e => e.Tax2Description).HasMaxLength(50);
            entity.Property(e => e.FutureTax2Rate).HasPrecision(10, 4);

            // Tax 3 fields
            entity.Property(e => e.Tax3Rate).HasPrecision(10, 4);
            entity.Property(e => e.Tax3Description).HasMaxLength(50);
            entity.Property(e => e.FutureTax3Rate).HasPrecision(10, 4);
        });

        // RoomType configuration (hostaccount_roomtype_link)
        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.DefaultRate).HasPrecision(10, 2);

            entity.HasOne(e => e.Property)
                .WithMany(p => p.RoomTypes)
                .HasForeignKey(e => e.PropertyAccountNumber);
        });

        // RoomBlackout configuration
        modelBuilder.Entity<RoomBlackout>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Reason).HasMaxLength(200).IsRequired();
            entity.Property(e => e.EntryUser).HasMaxLength(50);

            entity.HasOne(e => e.RoomType)
                .WithMany(r => r.Blackouts)
                .HasForeignKey(e => e.RoomTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Index for efficient date range queries
            entity.HasIndex(e => new { e.RoomTypeId, e.StartDate, e.EndDate });
        });

        // CompanyInfo configuration (usercompanyinfo)
        modelBuilder.Entity<CompanyInfo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.WebUrl).HasMaxLength(200);
        });

        // CommonText configuration (commontext)
        modelBuilder.Entity<CommonText>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).HasMaxLength(60).IsRequired();
            entity.Property(e => e.Text).IsRequired();
            entity.HasIndex(e => e.Title).IsUnique();
        });

        // CheckNumberConfig configuration (checknum)
        modelBuilder.Entity<CheckNumberConfig>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // Fact configuration (facttbl)
        modelBuilder.Entity<Fact>(entity =>
        {
            entity.HasKey(e => e.FactId);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(200).IsRequired();
        });

        // PropertyFact configuration (propfacttbl)
        modelBuilder.Entity<PropertyFact>(entity =>
        {
            entity.HasKey(e => e.PropertyFactId);

            entity.HasOne(e => e.Property)
                .WithMany()
                .HasForeignKey(e => e.PropertyId);

            entity.HasOne(e => e.Fact)
                .WithMany(f => f.PropertyFacts)
                .HasForeignKey(e => e.FactId);

            entity.HasIndex(e => new { e.PropertyId, e.FactId }).IsUnique();
        });
    }
}
