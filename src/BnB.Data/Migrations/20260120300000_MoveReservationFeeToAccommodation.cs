using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnB.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoveReservationFeeToAccommodation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add ReservationFee column to Accommodations
            migrationBuilder.AddColumn<decimal>(
                name: "ReservationFee",
                table: "Accommodations",
                type: "TEXT",
                nullable: true);

            // Migrate existing data: copy Guest.ReservationFee to their Accommodations
            migrationBuilder.Sql(@"
                UPDATE Accommodations
                SET ReservationFee = (
                    SELECT ReservationFee
                    FROM Guests
                    WHERE Guests.Id = Accommodations.GuestId
                )
                WHERE EXISTS (
                    SELECT 1 FROM Guests
                    WHERE Guests.Id = Accommodations.GuestId
                    AND Guests.ReservationFee IS NOT NULL
                )
            ");

            // Remove ReservationFee column from Guests
            migrationBuilder.DropColumn(name: "ReservationFee", table: "Guests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Add ReservationFee column back to Guests
            migrationBuilder.AddColumn<decimal>(
                name: "ReservationFee",
                table: "Guests",
                type: "TEXT",
                nullable: true);

            // Note: Data migration back is not straightforward since multiple accommodations
            // may now have different fees. We'll take the first accommodation's fee.
            migrationBuilder.Sql(@"
                UPDATE Guests
                SET ReservationFee = (
                    SELECT ReservationFee
                    FROM Accommodations
                    WHERE Accommodations.GuestId = Guests.Id
                    AND Accommodations.ReservationFee IS NOT NULL
                    LIMIT 1
                )
            ");

            // Remove ReservationFee column from Accommodations
            migrationBuilder.DropColumn(name: "ReservationFee", table: "Accommodations");
        }
    }
}
