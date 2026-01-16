using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnB.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTaxPlanRateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Tax 1 fields
            migrationBuilder.AddColumn<decimal>(
                name: "Tax1Rate",
                table: "TaxPlans",
                type: "TEXT",
                precision: 10,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Tax1Description",
                table: "TaxPlans",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tax1Application",
                table: "TaxPlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 2);  // Default to N/A

            migrationBuilder.AddColumn<decimal>(
                name: "FutureTax1Rate",
                table: "TaxPlans",
                type: "TEXT",
                precision: 10,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FutureTax1EffectiveDate",
                table: "TaxPlans",
                type: "TEXT",
                nullable: true);

            // Tax 2 fields
            migrationBuilder.AddColumn<decimal>(
                name: "Tax2Rate",
                table: "TaxPlans",
                type: "TEXT",
                precision: 10,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Tax2Description",
                table: "TaxPlans",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tax2Application",
                table: "TaxPlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 2);  // Default to N/A

            migrationBuilder.AddColumn<decimal>(
                name: "FutureTax2Rate",
                table: "TaxPlans",
                type: "TEXT",
                precision: 10,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FutureTax2EffectiveDate",
                table: "TaxPlans",
                type: "TEXT",
                nullable: true);

            // Tax 3 fields
            migrationBuilder.AddColumn<decimal>(
                name: "Tax3Rate",
                table: "TaxPlans",
                type: "TEXT",
                precision: 10,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Tax3Description",
                table: "TaxPlans",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tax3Application",
                table: "TaxPlans",
                type: "INTEGER",
                nullable: false,
                defaultValue: 2);  // Default to N/A

            migrationBuilder.AddColumn<decimal>(
                name: "FutureTax3Rate",
                table: "TaxPlans",
                type: "TEXT",
                precision: 10,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FutureTax3EffectiveDate",
                table: "TaxPlans",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Tax1Rate", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "Tax1Description", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "Tax1Application", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "FutureTax1Rate", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "FutureTax1EffectiveDate", table: "TaxPlans");

            migrationBuilder.DropColumn(name: "Tax2Rate", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "Tax2Description", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "Tax2Application", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "FutureTax2Rate", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "FutureTax2EffectiveDate", table: "TaxPlans");

            migrationBuilder.DropColumn(name: "Tax3Rate", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "Tax3Description", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "Tax3Application", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "FutureTax3Rate", table: "TaxPlans");
            migrationBuilder.DropColumn(name: "FutureTax3EffectiveDate", table: "TaxPlans");
        }
    }
}
