using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Car Activity List Report - shows car rental activity within a date range.
/// </summary>
public class CarActivityListReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<CarRental> _rentals;

    public CarActivityListReport(DateTime startDate, DateTime endDate, List<CarRental> rentals)
    {
        _startDate = startDate;
        _endDate = endDate;
        _rentals = rentals;
    }

    public override string Title => $"Car Rental Activity ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

    public override void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.Letter.Landscape());
            page.Margin(DefaultMargin);
            page.DefaultTextStyle(x => x.FontSize(BodyFontSize).FontFamily("Arial"));

            page.Header().Element(ComposeHeader);
            page.Content().Element(ComposeContent);
            page.Footer().Element(ComposeFooter);
        });
    }

    private void ComposeContent(IContainer container)
    {
        container.Column(column =>
        {
            if (_rentals.Count == 0)
            {
                column.Item().Text("No car rental activity found for the selected date range.")
                    .FontSize(11).Italic();
                return;
            }

            var totalAmount = _rentals.Sum(r => r.TotalAmount ?? 0);
            column.Item().PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Text($"Total Rentals: {_rentals.Count}").FontSize(11).SemiBold();
                row.RelativeItem().AlignRight().Text($"Total Amount: {totalAmount:C2}").FontSize(11).SemiBold();
            });

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(80);  // Conf #
                    columns.RelativeColumn(1.2f); // Agency
                    columns.RelativeColumn(1);   // Car Type
                    columns.ConstantColumn(80);  // Pickup Date
                    columns.ConstantColumn(80);  // Return Date
                    columns.ConstantColumn(80);  // Daily Rate
                    columns.ConstantColumn(90);  // Total
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("Agency").TableHeaderText();
                    header.Cell().TableHeader().Text("Car Type").TableHeaderText();
                    header.Cell().TableHeader().Text("Pickup").TableHeaderText();
                    header.Cell().TableHeader().Text("Return").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Daily Rate").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                bool alternate = false;
                decimal total = 0;

                foreach (var rental in _rentals.OrderBy(r => r.PickupDate))
                {
                    table.Cell().TableCell(alternate).Text(rental.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(rental.CarAgency?.Name)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(rental.CarType)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(rental.PickupDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(rental.ReturnDate, "MM/dd/yy")).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(rental.DailyRate)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(rental.TotalAmount)).TableCellText();

                    total += rental.TotalAmount ?? 0;
                    alternate = !alternate;
                }

                // Total row
                table.Cell().ColumnSpan(6).TotalsRow().AlignRight().Text("Grand Total:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(total)).Bold();
            });

            // Summary by agency
            column.Item().PaddingTop(20).Text("Summary by Agency").FontSize(12).Bold();
            column.Item().PaddingTop(5).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(1.5f);
                    columns.ConstantColumn(80);
                    columns.ConstantColumn(100);
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Agency").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Rentals").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                bool alternate = false;
                var byAgency = _rentals.GroupBy(r => r.CarAgency?.Name ?? "Unknown")
                    .OrderByDescending(g => g.Sum(r => r.TotalAmount ?? 0));

                foreach (var agencyGroup in byAgency)
                {
                    table.Cell().TableCell(alternate).Text(agencyGroup.Key).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(agencyGroup.Count().ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(agencyGroup.Sum(r => r.TotalAmount ?? 0))).TableCellText();
                    alternate = !alternate;
                }
            });
        });
    }
}
