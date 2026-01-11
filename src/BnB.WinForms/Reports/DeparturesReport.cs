using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Departures Report - lists guests departing within a date range
/// Migrated from Depart1.rpt
/// </summary>
public class DeparturesReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly IEnumerable<Accommodation> _departures;

    public override string Title => $"Departures Report ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

    public DeparturesReport(DateTime startDate, DateTime endDate, IEnumerable<Accommodation> departures)
    {
        _startDate = startDate;
        _endDate = endDate;
        _departures = departures.OrderBy(a => a.DepartureDate).ThenBy(a => a.Location).ToList();
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
        var departureList = _departures.ToList();

        container.Column(column =>
        {
            column.Item().PaddingBottom(10).Text($"Total Departures: {departureList.Count}")
                .FontSize(11)
                .SemiBold();

            if (!departureList.Any())
            {
                column.Item().Text("No departures found for the selected date range.")
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
                    columns.RelativeColumn(1);   // Balance Due
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
                    header.Cell().TableHeader().AlignRight().Text("Balance Due").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                bool alternate = false;
                DateTime? currentDate = null;

                foreach (var departure in departureList)
                {
                    if (currentDate != departure.DepartureDate.Date)
                    {
                        if (currentDate.HasValue)
                        {
                            table.Cell().ColumnSpan(8).PaddingVertical(5);
                        }
                        currentDate = departure.DepartureDate.Date;
                        alternate = false;
                    }

                    var guestName = $"{SafeString(departure.FirstName)} {SafeString(departure.LastName)}";
                    // Balance due would be calculated from payments - simplified for now
                    var balanceDue = departure.TotalGrossWithTax; // This would be reduced by payments

                    table.Cell().TableCell(alternate).Text(departure.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(guestName).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(departure.Location)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(departure.ArrivalDate)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(departure.DepartureDate)).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(departure.Nights.ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(balanceDue)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(departure.TotalGrossWithTax)).TableCellText();

                    alternate = !alternate;
                }

                // Summary row
                var totalAmount = departureList.Sum(a => a.TotalGrossWithTax);
                table.Cell().ColumnSpan(7).TotalsRow().AlignRight().Text("Grand Total:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalAmount)).Bold();
            });

            // Summary by property
            column.Item().PaddingTop(20).Element(ComposeSummaryByProperty);
        });
    }

    private void ComposeSummaryByProperty(IContainer container)
    {
        var departureList = _departures.ToList();
        if (!departureList.Any()) return;

        var byProperty = departureList
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
                    header.Cell().TableHeader().AlignCenter().Text("Departures").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total Revenue").TableHeaderText();
                });

                bool alternate = false;
                foreach (var group in byProperty)
                {
                    table.Cell().TableCell(alternate).Text(group.Key).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(group.Count().ToString()).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(group.Sum(a => a.Nights).ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(group.Sum(a => a.TotalGrossWithTax))).TableCellText();
                    alternate = !alternate;
                }
            });
        });
    }
}
