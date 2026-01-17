using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BnB.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyPaymentPolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Payment Policy - Default Settings
            migrationBuilder.AddColumn<decimal>(
                name: "DefaultDepositPercent",
                table: "Properties",
                type: "TEXT",
                precision: 5,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultDepositDueDays",
                table: "Properties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultPrepaymentDueDays",
                table: "Properties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultCancellationNoticeDays",
                table: "Properties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DefaultCancellationFeePercent",
                table: "Properties",
                type: "TEXT",
                precision: 5,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CancellationProcessingFee",
                table: "Properties",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            // Payment Policy - Peak Period Override Settings
            migrationBuilder.AddColumn<bool>(
                name: "HasPeakPeriodPolicy",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PeakPeriodPrepaymentDueDays",
                table: "Properties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeakPeriodCancellationNoticeDays",
                table: "Properties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PeakPeriodCancellationFeePercent",
                table: "Properties",
                type: "TEXT",
                precision: 5,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeakPeriodStartMonth",
                table: "Properties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeakPeriodStartDay",
                table: "Properties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeakPeriodEndMonth",
                table: "Properties",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeakPeriodEndDay",
                table: "Properties",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DefaultDepositPercent", table: "Properties");
            migrationBuilder.DropColumn(name: "DefaultDepositDueDays", table: "Properties");
            migrationBuilder.DropColumn(name: "DefaultPrepaymentDueDays", table: "Properties");
            migrationBuilder.DropColumn(name: "DefaultCancellationNoticeDays", table: "Properties");
            migrationBuilder.DropColumn(name: "DefaultCancellationFeePercent", table: "Properties");
            migrationBuilder.DropColumn(name: "CancellationProcessingFee", table: "Properties");
            migrationBuilder.DropColumn(name: "HasPeakPeriodPolicy", table: "Properties");
            migrationBuilder.DropColumn(name: "PeakPeriodPrepaymentDueDays", table: "Properties");
            migrationBuilder.DropColumn(name: "PeakPeriodCancellationNoticeDays", table: "Properties");
            migrationBuilder.DropColumn(name: "PeakPeriodCancellationFeePercent", table: "Properties");
            migrationBuilder.DropColumn(name: "PeakPeriodStartMonth", table: "Properties");
            migrationBuilder.DropColumn(name: "PeakPeriodStartDay", table: "Properties");
            migrationBuilder.DropColumn(name: "PeakPeriodEndMonth", table: "Properties");
            migrationBuilder.DropColumn(name: "PeakPeriodEndDay", table: "Properties");
        }
    }
}
