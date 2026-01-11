using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnB.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpandedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Properties",
                newName: "PropertyZipCode");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Properties",
                newName: "PropertyState");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Properties",
                newName: "PropertyPhone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Properties",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Fax",
                table: "Properties",
                newName: "PropertyFax");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "Properties",
                newName: "PropertyAddress");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Properties",
                newName: "PropertyCity");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Properties",
                newName: "MailingAddress");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Guests",
                newName: "HomePhone");

            migrationBuilder.RenameColumn(
                name: "RoomType",
                table: "Accommodations",
                newName: "UpdateUser");

            migrationBuilder.AddColumn<string>(
                name: "CheckTo",
                table: "Properties",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DBA",
                table: "Properties",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepositRequired",
                table: "Properties",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exceptions",
                table: "Properties",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExceptionsDescription",
                table: "Properties",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FederalTaxId",
                table: "Properties",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Properties",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossRatePercent",
                table: "Properties",
                type: "TEXT",
                precision: 5,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsObsolete",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MailingCity",
                table: "Properties",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingFax",
                table: "Properties",
                type: "TEXT",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingPhone1",
                table: "Properties",
                type: "TEXT",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingPhone2",
                table: "Properties",
                type: "TEXT",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingState",
                table: "Properties",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingZipCode",
                table: "Properties",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SuppressFlag",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WebUrl",
                table: "Properties",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CancellationFee",
                table: "Payments",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CancellationFeeDueDate",
                table: "Payments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DefaultCommission",
                table: "Payments",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DepositDue",
                table: "Payments",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepositDueDate",
                table: "Payments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Payments",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Payments",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OtherCredit",
                table: "Payments",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrepaymentDue",
                table: "Payments",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PrepaymentDueDate",
                table: "Payments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RefundOwed",
                table: "Payments",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookedBy",
                table: "Guests",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessAddress",
                table: "Guests",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone",
                table: "Guests",
                type: "TEXT",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Closure",
                table: "Guests",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBooked",
                table: "Guests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Guests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryUser",
                table: "Guests",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaxNumber",
                table: "Guests",
                type: "TEXT",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LabelFlag",
                table: "Guests",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Referral",
                table: "Guests",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReservationFee",
                table: "Guests",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Revision",
                table: "Guests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RevisionDate",
                table: "Guests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TravelingWith",
                table: "Guests",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Guests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "Guests",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Commission",
                table: "Accommodations",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CommissionPaid",
                table: "Accommodations",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CommissionReceived",
                table: "Accommodations",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "Accommodations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryUser",
                table: "Accommodations",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Accommodations",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Forfeit",
                table: "Accommodations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Accommodations",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Accommodations",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NightNotes",
                table: "Accommodations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Notified",
                table: "Accommodations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberInParty",
                table: "Accommodations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RevisionDate",
                table: "Accommodations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Suppress",
                table: "Accommodations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UnitName",
                table: "Accommodations",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitNameDescription",
                table: "Accommodations",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Accommodations",
                type: "TEXT",
                nullable: true);

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
                    State = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Fax = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CommissionPercent = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAgencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccommodationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    CheckDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PayableTo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Memo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    IsVoid = table.Column<bool>(type: "INTEGER", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checks_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    State = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Fax = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    WebUrl = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    PlanTitle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Fax = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CommissionPercent = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                        name: "FK_CarRentals_Guests_ConfirmationNumber",
                        column: x => x.ConfirmationNumber,
                        principalTable: "Guests",
                        principalColumn: "ConfirmationNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgentBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                        name: "FK_TravelAgentBookings_Guests_ConfirmationNumber",
                        column: x => x.ConfirmationNumber,
                        principalTable: "Guests",
                        principalColumn: "ConfirmationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelAgentBookings_TravelAgencies_TravelAgencyId",
                        column: x => x.TravelAgencyId,
                        principalTable: "TravelAgencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_CarAgencyId",
                table: "CarRentals",
                column: "CarAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_ConfirmationNumber",
                table: "CarRentals",
                column: "ConfirmationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_AccommodationId",
                table: "Checks",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPlans_PlanCode",
                table: "TaxPlans",
                column: "PlanCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TravelAgentBookings_ConfirmationNumber",
                table: "TravelAgentBookings",
                column: "ConfirmationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TravelAgentBookings_TravelAgencyId",
                table: "TravelAgentBookings",
                column: "TravelAgencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentals");

            migrationBuilder.DropTable(
                name: "Checks");

            migrationBuilder.DropTable(
                name: "CompanyInfo");

            migrationBuilder.DropTable(
                name: "TaxPlans");

            migrationBuilder.DropTable(
                name: "TravelAgentBookings");

            migrationBuilder.DropTable(
                name: "CarAgencies");

            migrationBuilder.DropTable(
                name: "TravelAgencies");

            migrationBuilder.DropColumn(
                name: "CheckTo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "DBA",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "DepositRequired",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Exceptions",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ExceptionsDescription",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FederalTaxId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "GrossRatePercent",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsObsolete",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MailingCity",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MailingFax",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MailingPhone1",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MailingPhone2",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MailingState",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MailingZipCode",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SuppressFlag",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "WebUrl",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CancellationFee",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CancellationFeeDueDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DefaultCommission",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DepositDue",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DepositDueDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OtherCredit",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PrepaymentDue",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PrepaymentDueDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "RefundOwed",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BookedBy",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "BusinessAddress",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "BusinessPhone",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Closure",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "DateBooked",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "EntryUser",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "FaxNumber",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "LabelFlag",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Referral",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "ReservationFee",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Revision",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "RevisionDate",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "TravelingWith",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Commission",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "CommissionPaid",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "CommissionReceived",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "EntryUser",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Forfeit",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "NightNotes",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Notified",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "NumberInParty",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "RevisionDate",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Suppress",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "UnitNameDescription",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Accommodations");

            migrationBuilder.RenameColumn(
                name: "PropertyZipCode",
                table: "Properties",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "PropertyState",
                table: "Properties",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "PropertyPhone",
                table: "Properties",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "PropertyFax",
                table: "Properties",
                newName: "Fax");

            migrationBuilder.RenameColumn(
                name: "PropertyCity",
                table: "Properties",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "PropertyAddress",
                table: "Properties",
                newName: "ContactName");

            migrationBuilder.RenameColumn(
                name: "MailingAddress",
                table: "Properties",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Properties",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "HomePhone",
                table: "Guests",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "UpdateUser",
                table: "Accommodations",
                newName: "RoomType");
        }
    }
}
