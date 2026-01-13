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
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    ConfirmationNumber = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.ConfirmationNumber);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Fax = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PercentToHost = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: false),
                    FuturePercent = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: true),
                    FuturePercentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TaxPlanCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
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
                    TaxOne = table.Column<decimal>(type: "TEXT", precision: 5, scale: 4, nullable: false),
                    TaxOneDescription = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FutureTaxOne = table.Column<decimal>(type: "TEXT", precision: 5, scale: 4, nullable: true),
                    FutureTaxOneEffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TaxTwo = table.Column<decimal>(type: "TEXT", precision: 5, scale: 4, nullable: false),
                    TaxTwoDescription = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FutureTaxTwo = table.Column<decimal>(type: "TEXT", precision: 5, scale: 4, nullable: true),
                    FutureTaxTwoEffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TaxThree = table.Column<decimal>(type: "TEXT", precision: 5, scale: 4, nullable: false),
                    TaxThreeDescription = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    FutureTaxThree = table.Column<decimal>(type: "TEXT", precision: 5, scale: 4, nullable: true),
                    FutureTaxThreeEffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfirmationNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ReceivedFrom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    AppliedTo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Guests_ConfirmationNumber",
                        column: x => x.ConfirmationNumber,
                        principalTable: "Guests",
                        principalColumn: "ConfirmationNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfirmationNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    PropertyAccountNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumberOfNights = table.Column<int>(type: "INTEGER", nullable: false),
                    DailyGrossRate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    DailyNetRate = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    TotalGrossWithTax = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    TotalNetWithTax = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    TotalTax = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    Tax1 = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    Tax2 = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    Tax3 = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    ServiceFee = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    PaymentType = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    OverridePercentToHost = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: true),
                    OverrideTaxPlanCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    UseManualAmounts = table.Column<bool>(type: "INTEGER", nullable: false),
                    RoomType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodations_Guests_ConfirmationNumber",
                        column: x => x.ConfirmationNumber,
                        principalTable: "Guests",
                        principalColumn: "ConfirmationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accommodations_Properties_PropertyAccountNumber",
                        column: x => x.PropertyAccountNumber,
                        principalTable: "Properties",
                        principalColumn: "AccountNumber",
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

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_ConfirmationNumber",
                table: "Accommodations",
                column: "ConfirmationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_PropertyAccountNumber",
                table: "Accommodations",
                column: "PropertyAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ConfirmationNumber",
                table: "Payments",
                column: "ConfirmationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_PropertyAccountNumber",
                table: "RoomTypes",
                column: "PropertyAccountNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
