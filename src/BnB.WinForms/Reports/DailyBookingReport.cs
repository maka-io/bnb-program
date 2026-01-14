using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Daily Booking Report - shows bookings made within a date range.
/// </summary>
public class DailyBookingReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<Accommodation> _bookings;

    public DailyBookingReport(DateTime startDate, DateTime endDate, List<Accommodation> bookings, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _bookings = bookings;
    }

    public override string Title => $"Daily Booking Report ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

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
            column.Item().PaddingBottom(10).Text($"Total Bookings: {_bookings.Count}")
                .FontSize(11).SemiBold();

            if (_bookings.Count == 0)
            {
                column.Item().Text("No bookings found for the selected date range.")
                    .FontSize(11).Italic();
                return;
            }

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(80);  // Booked Date
                    columns.ConstantColumn(70);  // Conf #
                    columns.RelativeColumn(1.5f); // Guest Name
                    columns.RelativeColumn(1.5f); // Property
                    columns.ConstantColumn(80);  // Arrival
                    columns.ConstantColumn(80);  // Departure
                    columns.ConstantColumn(50);  // Nights
                    columns.ConstantColumn(80);  // Total
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Booked").TableHeaderText();
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().Text("Arrival").TableHeaderText();
                    header.Cell().TableHeader().Text("Departure").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                bool alternate = false;
                decimal totalAmount = 0;

                foreach (var booking in _bookings)
                {
                    var guestName = $"{SafeString(booking.FirstName)} {SafeString(booking.LastName)}";

                    table.Cell().TableCell(alternate).Text(FormatDate(booking.BookedDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(booking.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(guestName).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(booking.Property?.Location)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(booking.ArrivalDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(booking.DepartureDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(booking.NumberOfNights.ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(booking.TotalCharges)).TableCellText();

                    totalAmount += booking.TotalCharges ?? 0;
                    alternate = !alternate;
                }

                // Total row
                table.Cell().ColumnSpan(7).TotalsRow().AlignRight().Text("Grand Total:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalAmount)).Bold();
            });
        });
    }
}
