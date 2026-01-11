using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnB.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCommonTextAndCheckNumberConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountNumber",
                table: "TravelAgencies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CheckNumberConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HostCheckNum = table.Column<int>(type: "INTEGER", nullable: false),
                    TravelCheckNum = table.Column<int>(type: "INTEGER", nullable: false),
                    MiscCheckNum = table.Column<int>(type: "INTEGER", nullable: false),
                    SharedAccounts = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckNumberConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommonTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonTexts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommonTexts_Title",
                table: "CommonTexts",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckNumberConfigs");

            migrationBuilder.DropTable(
                name: "CommonTexts");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "TravelAgencies");
        }
    }
}
