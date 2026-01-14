using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Arrivals Report - lists guests arriving within a date range
/// Migrated from Arrival1.rpt
/// </summary>
public class ArrivalsReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly IEnumerable<Accommodation> _arrivals;

    public override string Title => $"Arrivals Report ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

    public ArrivalsReport(DateTime startDate, DateTime endDate, IEnumerable<Accommodation> arrivals, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _arrivals = arrivals.OrderBy(a => a.ArrivalDate).ThenBy(a => a.Location).ToList();
    }

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
        var arrivalList = _arrivals.ToList();

        container.Column(column =>
        {
            column.Item().PaddingBottom(10).Text($"Total Arrivals: {arrivalList.Count}")
                .FontSize(11)
                .SemiBold();

            if (!arrivalList.Any())
            {
                column.Item().Text("No arrivals found for the selected date range.")
                    .FontSize(11)
                    .Italic();
                return;
            }

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(80);  // Confirmation #
                    columns.RelativeColumn(1.5f); // Guest Name
                    columns.RelativeColumn(1.5f); // Property
                    columns.ConstantColumn(80);  // Arrival Date
                    columns.ConstantColumn(80);  // Departure Date
                    columns.ConstantColumn(50);  // Nights
                    columns.ConstantColumn(50);  // Guests
                    columns.RelativeColumn(1);   // Phone
                    columns.ConstantColumn(70);  // Total
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Conf #").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().Text("Arrival").TableHeaderText();
                    header.Cell().TableHeader().Text("Departure").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Guests").TableHeaderText();
                    header.Cell().TableHeader().Text("Phone").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                bool alternate = false;
                DateTime? currentDate = null;

                foreach (var arrival in arrivalList)
                {
                    // Add date separator when date changes
                    if (currentDate != arrival.ArrivalDate.Date)
                    {
                        if (currentDate.HasValue)
                        {
                            table.Cell().ColumnSpan(9).PaddingVertical(5);
                        }
                        currentDate = arrival.ArrivalDate.Date;
                        alternate = false;
                    }

                    var guestName = $"{SafeString(arrival.FirstName)} {SafeString(arrival.LastName)}";

                    table.Cell().TableCell(alternate).Text(arrival.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(guestName).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(arrival.Location)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(arrival.ArrivalDate)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(arrival.DepartureDate)).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(arrival.NumberOfNights.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(arrival.NumberInParty?.ToString() ?? "").TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(arrival.Guest?.HomePhone ?? arrival.Guest?.BusinessPhone)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(arrival.TotalGrossWithTax)).TableCellText();

                    alternate = !alternate;
                }

                // Summary row
                var totalAmount = arrivalList.Sum(a => a.TotalGrossWithTax);
                table.Cell().ColumnSpan(8).TotalsRow().AlignRight().Text("Grand Total:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalAmount)).Bold();
            });

            // Summary by property
            column.Item().PaddingTop(20).Element(ComposeSummaryByProperty);
        });
    }

    private void ComposeSummaryByProperty(IContainer container)
    {
        var arrivalList = _arrivals.ToList();
        if (!arrivalList.Any()) return;

        var byProperty = arrivalList
            .GroupBy(a => a.Location ?? "Unknown")
            .OrderBy(g => g.Key)
            .ToList();

        container.Column(column =>
        {
            column.Item().Text("Summary by Property").FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().PaddingTop(5);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2);
                    columns.ConstantColumn(80);
                    columns.ConstantColumn(80);
                    columns.ConstantColumn(100);
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Arrivals").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Guests").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total Revenue").TableHeaderText();
                });

                bool alternate = false;
                foreach (var group in byProperty)
                {
                    table.Cell().TableCell(alternate).Text(group.Key).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(group.Count().ToString()).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(group.Sum(a => a.NumberInParty ?? 1).ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(group.Sum(a => a.TotalGrossWithTax))).TableCellText();
                    alternate = !alternate;
                }
            });
        });
    }
}
