using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnB.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomTypeRoomCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomCount",
                table: "RoomTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomCount",
                table: "RoomTypes");
        }
    }
}
