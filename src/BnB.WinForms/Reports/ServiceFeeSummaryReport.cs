using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Service Fee Summary Report - summarizes service fees collected.
/// </summary>
public class ServiceFeeSummaryReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<Accommodation> _accommodations;

    public ServiceFeeSummaryReport(DateTime startDate, DateTime endDate, List<Accommodation> accommodations, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _accommodations = accommodations;
    }

    public override string Title => $"Service Fee Summary ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

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
            column.Item().PaddingBottom(10).Text($"Total Reservations: {_accommodations.Count}")
                .FontSize(11).SemiBold();

            if (_accommodations.Count == 0)
            {
                column.Item().Text("No accommodations found for the selected date range.")
                    .FontSize(11).Italic();
                return;
            }

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(70);  // Departure
                    columns.ConstantColumn(60);  // Conf #
                    columns.RelativeColumn(1.2f); // Guest Name
                    columns.RelativeColumn(1.2f); // Property
                    columns.ConstantColumn(80);  // Room Rate
                    columns.ConstantColumn(80);  // Service Fee
                    columns.ConstantColumn(80);  // Total
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Departure").TableHeaderText();
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Room Rate").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Service Fee").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                bool alternate = false;
                decimal totalRoomRate = 0;
                decimal totalServiceFee = 0;
                decimal totalAmount = 0;

                foreach (var accom in _accommodations)
                {
                    var guestName = $"{SafeString(accom.LastName)}, {SafeString(accom.FirstName)}";
                    var roomRate = (accom.DailyGrossRate ?? 0) * accom.NumberOfNights;
                    var serviceFee = accom.ServiceFee ?? 0;
                    var total = accom.TotalCharges ?? 0;

                    table.Cell().TableCell(alternate).Text(FormatDate(accom.DepartureDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(accom.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(guestName).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(accom.Property?.Location)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(roomRate)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(serviceFee)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(total)).TableCellText();

                    totalRoomRate += roomRate;
                    totalServiceFee += serviceFee;
                    totalAmount += total;
                    alternate = !alternate;
                }

                // Totals row
                table.Cell().ColumnSpan(4).TotalsRow().AlignRight().Text("Totals:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalRoomRate)).Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalServiceFee)).Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalAmount)).Bold();
            });
        });
    }
}
