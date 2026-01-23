using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnB.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCarRentalAndTravelAgencyFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Use raw SQL to safely drop tables only if they exist
            // SQLite doesn't support IF EXISTS in DROP TABLE via EF Core's DropTable,
            // so we use raw SQL instead

            // Drop child tables first (they have FKs to parent tables)
            migrationBuilder.Sql("DROP TABLE IF EXISTS TravelAgentBookings");
            migrationBuilder.Sql("DROP TABLE IF EXISTS CarRentals");

            // Drop parent tables
            migrationBuilder.Sql("DROP TABLE IF EXISTS TravelAgencies");
            migrationBuilder.Sql("DROP TABLE IF EXISTS CarAgencies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Recreate TravelAgencies table
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

            // Recreate CarAgencies table
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

            // Recreate TravelAgentBookings table
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

            // Recreate CarRentals table
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

            // Recreate indexes
            migrationBuilder.CreateIndex(
                name: "IX_TravelAgentBookings_GuestId",
                table: "TravelAgentBookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelAgentBookings_TravelAgencyId",
                table: "TravelAgentBookings",
                column: "TravelAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_CarAgencyId",
                table: "CarRentals",
                column: "CarAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_GuestId",
                table: "CarRentals",
                column: "GuestId");
        }
    }
}
