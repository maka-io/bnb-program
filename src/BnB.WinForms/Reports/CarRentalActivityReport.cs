using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Car Rental Activity Report - shows car rental bookings within a date range.
/// </summary>
public class CarRentalActivityReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<CarRental> _rentals;

    public CarRentalActivityReport(DateTime startDate, DateTime endDate, List<CarRental> rentals)
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
                column.Item().Text("No car rentals found for the selected date range.")
                    .FontSize(11).Italic();
                return;
            }

            // Summary by agency
            column.Item().PaddingBottom(10).Column(summaryCol =>
            {
                summaryCol.Item().Text("Summary by Agency:").Bold().FontSize(11);
                var byAgency = _rentals.GroupBy(r => r.CarAgency?.Name ?? "Unknown")
                    .Select(g => new { Agency = g.Key, Count = g.Count(), Total = g.Sum(r => r.TotalAmount ?? 0) })
                    .OrderByDescending(a => a.Count);

                foreach (var agency in byAgency)
                {
                    summaryCol.Item().Text($"  {agency.Agency}: {agency.Count} rentals, {FormatCurrency(agency.Total)}").FontSize(10);
                }
            });

            column.Item().PaddingVertical(10).LineHorizontal(1);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(60);  // Conf #
                    columns.RelativeColumn(1.2f); // Guest Name
                    columns.RelativeColumn(1);   // Agency
                    columns.ConstantColumn(70);  // Pickup
                    columns.ConstantColumn(70);  // Return
                    columns.RelativeColumn(0.8f); // Car Type
                    columns.ConstantColumn(70);  // Daily Rate
                    columns.ConstantColumn(70);  // Total
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest").TableHeaderText();
                    header.Cell().TableHeader().Text("Agency").TableHeaderText();
                    header.Cell().TableHeader().Text("Pickup").TableHeaderText();
                    header.Cell().TableHeader().Text("Return").TableHeaderText();
                    header.Cell().TableHeader().Text("Car Type").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Daily").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                bool alternate = false;
                decimal totalAmount = 0;

                foreach (var rental in _rentals)
                {
                    var guestName = rental.Guest != null
                        ? $"{SafeString(rental.Guest.LastName)}, {SafeString(rental.Guest.FirstName)}"
                        : "N/A";

                    table.Cell().TableCell(alternate).Text(rental.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(guestName).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(rental.CarAgency?.Name)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(rental.PickupDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(rental.ReturnDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(rental.CarType)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(rental.DailyRate)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(rental.TotalAmount)).TableCellText();

                    totalAmount += rental.TotalAmount ?? 0;
                    alternate = !alternate;
                }

                // Total row
                table.Cell().ColumnSpan(7).TotalsRow().AlignRight().Text("Total:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalAmount)).Bold();
            });

            column.Item().PaddingTop(10).Text($"Total Rentals: {_rentals.Count}")
                .FontSize(10).SemiBold();
        });
    }
}
