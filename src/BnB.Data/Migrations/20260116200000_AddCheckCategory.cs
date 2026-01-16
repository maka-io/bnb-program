using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnB.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Checks",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ConfirmationNumber",
                table: "Checks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "ConfirmationNumber",
                table: "Checks");
        }
    }
}
