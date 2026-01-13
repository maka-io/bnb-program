using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Net Summary Report - shows net amounts due to hosts after commissions
/// Migrated from NetSum.rpt
/// </summary>
public class NetSummaryReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly IEnumerable<Accommodation> _accommodations;

    public override string Title => $"Net Summary Report ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

    public NetSummaryReport(DateTime startDate, DateTime endDate, IEnumerable<Accommodation> accommodations)
    {
        _startDate = startDate;
        _endDate = endDate;
        _accommodations = accommodations
            .OrderBy(a => a.Property?.FullName ?? a.Location)
            .ThenBy(a => a.DepartureDate)
            .ToList();
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
        var accommodationList = _accommodations.ToList();

        container.Column(column =>
        {
            if (!accommodationList.Any())
            {
                column.Item().Text("No records found for the selected date range.")
                    .FontSize(11)
                    .Italic();
                return;
            }

            // Group by Host/Property
            var byHost = accommodationList
                .GroupBy(a => new
                {
                    Name = a.Property?.FullName ?? a.Location ?? "Unknown",
                    AccountNum = a.PropertyAccountNumber
                })
                .OrderBy(g => g.Key.Name)
                .ToList();

            foreach (var hostGroup in byHost)
            {
                column.Item().Element(c => ComposeHostSection(c, hostGroup.Key.Name, hostGroup.ToList()));
            }

            // Grand totals
            column.Item().PaddingTop(15).Element(c => ComposeGrandTotals(c, accommodationList));
        });
    }

    private void ComposeHostSection(IContainer container, string hostName, List<Accommodation> accommodations)
    {
        container.Column(column =>
        {
            column.Item().SectionHeader().Text(hostName).FontSize(11).Bold().FontColor("#ffffff");

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(70);  // Conf #
                    columns.RelativeColumn(1);   // Guest
                    columns.ConstantColumn(70);  // Departure
                    columns.ConstantColumn(50);  // Nights
                    columns.ConstantColumn(70);  // Gross Rate
                    columns.ConstantColumn(70);  // Net Rate
                    columns.ConstantColumn(60);  // Tax
                    columns.ConstantColumn(70);  // Gross Total
                    columns.ConstantColumn(70);  // Net w/Tax
                    columns.ConstantColumn(70);  // Commission
                    columns.ConstantColumn(80);  // Due to Host
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Conf #").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest").TableHeaderText();
                    header.Cell().TableHeader().Text("Depart").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Gross/Nt").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Net/Nt").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Tax").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Gross Tot").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Net w/Tax").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Comm").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Due Host").TableHeaderText();
                });

                bool alternate = false;
                foreach (var accom in accommodations)
                {
                    var dueToHost = accom.TotalNetWithTax - (accom.Commission);

                    table.Cell().TableCell(alternate).Text(accom.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text($"{SafeString(accom.FirstName)} {SafeString(accom.LastName)}").TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(accom.DepartureDate)).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(accom.NumberOfNights.ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.DailyGrossRate)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.DailyNetRate)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.TotalTax)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.TotalGrossWithTax)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.TotalNetWithTax)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.Commission)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(dueToHost)).TableCellText().Bold();

                    alternate = !alternate;
                }

                // Host subtotal
                var hostGross = accommodations.Sum(a => a.TotalGrossWithTax);
                var hostNet = accommodations.Sum(a => a.TotalNetWithTax);
                var hostTax = accommodations.Sum(a => a.TotalTax);
                var hostCommission = accommodations.Sum(a => a.Commission);
                var hostDueToHost = hostNet - hostCommission;

                table.Cell().ColumnSpan(6).TotalsRow().AlignRight().Text($"Subtotal ({accommodations.Count}):").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(hostTax));
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(hostGross));
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(hostNet));
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(hostCommission));
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(hostDueToHost)).Bold();
            });

            column.Item().PaddingBottom(10);
        });
    }

    private void ComposeGrandTotals(IContainer container, List<Accommodation> accommodations)
    {
        var totalGross = accommodations.Sum(a => a.TotalGrossWithTax);
        var totalNet = accommodations.Sum(a => a.TotalNetWithTax);
        var totalTax = accommodations.Sum(a => a.TotalTax);
        var totalCommission = accommodations.Sum(a => a.Commission);
        var totalDueToHost = totalNet - totalCommission;
        var totalNights = accommodations.Sum(a => a.NumberOfNights);
        var avgNightlyRate = totalNights > 0 ? totalGross / totalNights : 0;

        container.Border(2).BorderColor(ReportStyles.PrimaryColor).Padding(10).Column(column =>
        {
            column.Item().Text("Grand Totals").FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().PaddingTop(5);

            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text($"Total Reservations: {accommodations.Count}");
                    col.Item().Text($"Total Night Stays: {totalNights}");
                    col.Item().Text($"Average Nightly Rate: {FormatCurrency(avgNightlyRate)}");
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text($"Total Gross Revenue: {FormatCurrency(totalGross)}");
                    col.Item().Text($"Total Taxes Collected: {FormatCurrency(totalTax)}");
                    col.Item().Text($"Total Net Revenue: {FormatCurrency(totalNet)}");
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text($"Total Commission: {FormatCurrency(totalCommission)}");
                    col.Item().Text($"Total Due to Hosts: {FormatCurrency(totalDueToHost)}").Bold();
                });
            });
        });
    }
}
