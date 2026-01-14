using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Booking List Report - shows filtered list of bookings.
/// </summary>
public class BookingListReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly string _dateField;
    private readonly List<Accommodation> _bookings;

    public BookingListReport(DateTime startDate, DateTime endDate, string dateField, List<Accommodation> bookings, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _dateField = dateField;
        _bookings = bookings;
    }

    public override string Title => $"Booking List ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

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
            column.Item().PaddingBottom(5).Text($"Filtered by: {_dateField}").FontSize(10);

            if (_bookings.Count == 0)
            {
                column.Item().PaddingTop(10).Text("No bookings found for the selected criteria.")
                    .FontSize(11).Italic();
                return;
            }

            column.Item().PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Text($"Total Bookings: {_bookings.Count}").FontSize(11).SemiBold();
                row.RelativeItem().AlignRight().Text($"Total Nights: {_bookings.Sum(b => b.NumberOfNights)} | Total Guests: {_bookings.Sum(b => b.NumberInParty ?? 1)}").FontSize(10);
            });

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(45);  // Conf #
                    columns.ConstantColumn(85);  // First Name
                    columns.ConstantColumn(85);  // Last Name
                    columns.RelativeColumn(1);   // Property (takes remaining space)
                    columns.ConstantColumn(65);  // Arrival
                    columns.ConstantColumn(65);  // Departure
                    columns.ConstantColumn(40);  // Nights
                    columns.ConstantColumn(40);  // Guests
                    columns.ConstantColumn(70);  // Total
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("First Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Last Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().Text("Arrival").TableHeaderText();
                    header.Cell().TableHeader().Text("Departure").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Guests").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                bool alternate = false;
                decimal grandTotal = 0;

                foreach (var booking in _bookings)
                {
                    table.Cell().TableCell(alternate).Text(booking.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(booking.FirstName)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(booking.LastName)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(booking.Location)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(booking.ArrivalDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(booking.DepartureDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(booking.NumberOfNights.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text((booking.NumberInParty ?? 1).ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(booking.TotalGrossWithTax)).TableCellText();

                    grandTotal += booking.TotalGrossWithTax ?? 0;
                    alternate = !alternate;
                }

                // Total row
                table.Cell().ColumnSpan(8).TotalsRow().AlignRight().Text("Grand Total:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(grandTotal)).Bold();
            });

            // Summary by property
            column.Item().PaddingTop(20).Text("Summary by Property").FontSize(12).Bold();
            column.Item().PaddingTop(5).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(1.5f);
                    columns.ConstantColumn(70);
                    columns.ConstantColumn(70);
                    columns.ConstantColumn(70);
                    columns.ConstantColumn(100);
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Bookings").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Guests").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                bool alternate = false;
                var byProperty = _bookings.GroupBy(b => b.Location ?? "Unknown")
                    .OrderByDescending(g => g.Sum(b => b.TotalGrossWithTax));

                foreach (var propertyGroup in byProperty)
                {
                    table.Cell().TableCell(alternate).Text(propertyGroup.Key).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(propertyGroup.Count().ToString()).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(propertyGroup.Sum(b => b.NumberOfNights).ToString()).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(propertyGroup.Sum(b => b.NumberInParty ?? 1).ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(propertyGroup.Sum(b => b.TotalGrossWithTax))).TableCellText();
                    alternate = !alternate;
                }
            });
        });
    }
}
