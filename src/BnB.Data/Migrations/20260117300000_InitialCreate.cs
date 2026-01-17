using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnB.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Core tables
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    BusinessAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    HomePhone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    BusinessPhone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FaxNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DateBooked = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BookedBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Referral = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ReservationFee = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    TravelingWith = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    LabelFlag = table.Column<bool>(type: "INTEGER", nullable: false),
                    Closure = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EntryUser = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdateUser = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    RevisionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Revision = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DBA = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PropertyAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PropertyCity = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PropertyState = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PropertyZipCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PropertyPhone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PropertyFax = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MailingAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    MailingCity = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MailingState = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MailingZipCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MailingPhone1 = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MailingPhone2 = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MailingFax = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    WebUrl = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    CheckTo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PercentToHost = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: false),
                    FuturePercent = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: true),
                    FuturePercentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GrossRatePercent = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: true),
                    FederalTaxId = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    TaxPlanCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    DepositRequired = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Exceptions = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    ExceptionsDescription = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsObsolete = table.Column<bool>(type: "INTEGER", nullable: false),
                    SuppressFlag = table.Column<bool>(type: "INTEGER", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "TaxRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaxOne = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: false),
                    TaxOneDescription = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FutureTaxOne = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: true),
                    FutureTaxOneEffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TaxTwo = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: false),
                    TaxTwoDescription = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FutureTaxTwo = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: true),
                    FutureTaxTwoEffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TaxThree = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: false),
                    TaxThreeDescription = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FutureTaxThree = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: true),
                    FutureTaxThreeEffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    PlanTitle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Tax1Rate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: false),
                    Tax1Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Tax1Application = table.Column<int>(type: "INTEGER", nullable: false),
                    FutureTax1Rate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: true),
                    FutureTax1EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Tax2Rate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: false),
                    Tax2Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Tax2Application = table.Column<int>(type: "INTEGER", nullable: false),
                    FutureTax2Rate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: true),
                    FutureTax2EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Tax3Rate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: false),
                    Tax3Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Tax3Application = table.Column<int>(type: "INTEGER", nullable: false),
                    FutureTax3Rate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 4, nullable: true),
                    FutureTax3EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CommissionPercent = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarAgencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CommissionPercent = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAgencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facts",
                columns: table => new
                {
                    FactId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facts", x => x.FactId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    WebUrl = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Logo = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommonTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckNumberConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastCheckNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckNumberConfigs", x => x.Id);
                });

            // Tables with foreign keys to Guests
            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfirmationNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyAccountNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumberOfNights = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberInParty = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    UnitNameDescription = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    DailyGrossRate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    DailyNetRate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    TotalGrossWithTax = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    TotalNetWithTax = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    TotalTax = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    Tax1 = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    Tax2 = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    Tax3 = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    ServiceFee = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    Commission = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    CommissionPaid = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    CommissionReceived = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    PaymentType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    OverridePercentToHost = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: true),
                    OverrideTaxPlanCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    UseManualAmounts = table.Column<bool>(type: "INTEGER", nullable: false),
                    Suppress = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notified = table.Column<bool>(type: "INTEGER", nullable: false),
                    Forfeit = table.Column<bool>(type: "INTEGER", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    NightNotes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EntryUser = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdateUser = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    RevisionDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodations_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accommodations_Properties_PropertyAccountNumber",
                        column: x => x.PropertyAccountNumber,
                        principalTable: "Properties",
                        principalColumn: "AccountNumber");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfirmationNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ReceivedFrom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    AppliedTo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DepositDue = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    DepositDueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PrepaymentDue = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    PrepaymentDueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CancellationFee = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    CancellationFeeDueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RefundOwed = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    OtherCredit = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    DefaultCommission = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgentBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfirmationNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    TravelAgencyId = table.Column<int>(type: "INTEGER", nullable: true),
                    CommissionAmount = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    CommissionPaid = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    CommissionPaidDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CheckNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgentBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelAgentBookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelAgentBookings_TravelAgencies_TravelAgencyId",
                        column: x => x.TravelAgencyId,
                        principalTable: "TravelAgencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfirmationNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    CarAgencyId = table.Column<int>(type: "INTEGER", nullable: true),
                    PickupDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CarType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    DailyRate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    CommissionAmount = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    CommissionPaid = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    CommissionPaidDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CheckNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarRentals_CarAgencies_CarAgencyId",
                        column: x => x.CarAgencyId,
                        principalTable: "CarAgencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarRentals_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyAccountNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    DefaultRate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomTypes_Properties_PropertyAccountNumber",
                        column: x => x.PropertyAccountNumber,
                        principalTable: "Properties",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomBlackouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EntryUser = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBlackouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomBlackouts_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccommodationId = table.Column<int>(type: "INTEGER", nullable: true),
                    ConfirmationNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CheckNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    CheckDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PayableTo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Memo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    IsVoid = table.Column<bool>(type: "INTEGER", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checks_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyFacts",
                columns: table => new
                {
                    PropertyFactId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    FactId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFacts", x => x.PropertyFactId);
                    table.ForeignKey(
                        name: "FK_PropertyFacts_Facts_FactId",
                        column: x => x.FactId,
                        principalTable: "Facts",
                        principalColumn: "FactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyFacts_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            // Indexes
            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_ConfirmationNumber",
                table: "Accommodations",
                column: "ConfirmationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_GuestId",
                table: "Accommodations",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_PropertyAccountNumber",
                table: "Accommodations",
                column: "PropertyAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_CarAgencyId",
                table: "CarRentals",
                column: "CarAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_GuestId",
                table: "CarRentals",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_AccommodationId",
                table: "Checks",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonTexts_Title",
                table: "CommonTexts",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GuestId",
                table: "Payments",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFacts_FactId",
                table: "PropertyFacts",
                column: "FactId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFacts_PropertyId_FactId",
                table: "PropertyFacts",
                columns: new[] { "PropertyId", "FactId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomBlackouts_RoomTypeId_StartDate_EndDate",
                table: "RoomBlackouts",
                columns: new[] { "RoomTypeId", "StartDate", "EndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_PropertyAccountNumber",
                table: "RoomTypes",
                column: "PropertyAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPlans_PlanCode",
                table: "TaxPlans",
                column: "PlanCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TravelAgentBookings_GuestId",
                table: "TravelAgentBookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelAgentBookings_TravelAgencyId",
                table: "TravelAgentBookings",
                column: "TravelAgencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Checks");
            migrationBuilder.DropTable(name: "CarRentals");
            migrationBuilder.DropTable(name: "TravelAgentBookings");
            migrationBuilder.DropTable(name: "Payments");
            migrationBuilder.DropTable(name: "RoomBlackouts");
            migrationBuilder.DropTable(name: "PropertyFacts");
            migrationBuilder.DropTable(name: "CheckNumberConfigs");
            migrationBuilder.DropTable(name: "CommonTexts");
            migrationBuilder.DropTable(name: "CompanyInfo");
            migrationBuilder.DropTable(name: "TaxPlans");
            migrationBuilder.DropTable(name: "TaxRates");
            migrationBuilder.DropTable(name: "Accommodations");
            migrationBuilder.DropTable(name: "RoomTypes");
            migrationBuilder.DropTable(name: "CarAgencies");
            migrationBuilder.DropTable(name: "TravelAgencies");
            migrationBuilder.DropTable(name: "Facts");
            migrationBuilder.DropTable(name: "Guests");
            migrationBuilder.DropTable(name: "Properties");
        }
    }
}
