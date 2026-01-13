using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Commission Report - shows commissions due to hosts
/// Migrated from Commish1.rpt
/// </summary>
public class CommissionReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly IEnumerable<Accommodation> _accommodations;
    private readonly bool _unpaidOnly;

    public override string Title => _unpaidOnly
        ? $"Unpaid Commissions ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})"
        : $"Commission Report ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

    public CommissionReport(DateTime startDate, DateTime endDate, IEnumerable<Accommodation> accommodations, bool unpaidOnly = false)
    {
        _startDate = startDate;
        _endDate = endDate;
        _accommodations = accommodations
            .Where(a => a.Commission > 0 && a.Commission > 0)
            .OrderBy(a => a.Property?.FullName ?? a.Location)
            .ThenBy(a => a.DepartureDate)
            .ToList();
        _unpaidOnly = unpaidOnly;
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
            var totalCommissionDue = accommodationList.Sum(a => a.Commission);
            var totalCommissionPaid = accommodationList.Sum(a => a.CommissionPaid ?? 0);
            var totalOutstanding = totalCommissionDue - totalCommissionPaid;

            column.Item().PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Text($"Total Records: {accommodationList.Count}").FontSize(11).SemiBold();
                row.RelativeItem().AlignCenter().Text($"Commission Due: {FormatCurrency(totalCommissionDue)}").FontSize(11).SemiBold();
                row.RelativeItem().AlignRight().Text($"Outstanding: {FormatCurrency(totalOutstanding)}").FontSize(11).SemiBold().FontColor("#cc0000");
            });

            if (!accommodationList.Any())
            {
                column.Item().Text("No commission records found for the selected criteria.")
                    .FontSize(11)
                    .Italic();
                return;
            }

            // Group by Host/Property
            var byHost = accommodationList
                .GroupBy(a => a.Property?.FullName ?? a.Location ?? "Unknown")
                .OrderBy(g => g.Key)
                .ToList();

            foreach (var hostGroup in byHost)
            {
                column.Item().Element(c => ComposeHostSection(c, hostGroup.Key, hostGroup.ToList()));
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
                    columns.ConstantColumn(70);  // Arrival
                    columns.ConstantColumn(70);  // Departure
                    columns.ConstantColumn(50);  // Nights
                    columns.ConstantColumn(70);  // Gross
                    columns.ConstantColumn(60);  // %
                    columns.ConstantColumn(70);  // Commission Due
                    columns.ConstantColumn(70);  // Paid
                    columns.ConstantColumn(70);  // Outstanding
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Conf #").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest").TableHeaderText();
                    header.Cell().TableHeader().Text("Arrival").TableHeaderText();
                    header.Cell().TableHeader().Text("Departure").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Gross").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("%").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Due").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Paid").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Balance").TableHeaderText();
                });

                bool alternate = false;
                foreach (var accom in accommodations)
                {
                    var outstanding = (accom.Commission) - (accom.CommissionPaid ?? 0);
                    var percent = accom.OverridePercentToHost ?? 0;

                    table.Cell().TableCell(alternate).Text(accom.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text($"{SafeString(accom.FirstName)} {SafeString(accom.LastName)}").TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(accom.ArrivalDate)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(accom.DepartureDate)).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(accom.NumberOfNights.ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.TotalGrossWithTax)).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text($"{percent:F1}%").TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.Commission)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.CommissionPaid)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(outstanding))
                        .FontColor(outstanding > 0 ? "#cc0000" : "#333333")
                        .TableCellText();

                    alternate = !alternate;
                }

                // Host subtotal
                var hostCommissionDue = accommodations.Sum(a => a.Commission);
                var hostCommissionPaid = accommodations.Sum(a => a.CommissionPaid ?? 0);
                var hostOutstanding = hostCommissionDue - hostCommissionPaid;

                table.Cell().ColumnSpan(7).TotalsRow().AlignRight().Text($"Subtotal ({accommodations.Count}):").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(hostCommissionDue)).Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(hostCommissionPaid));
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(hostOutstanding)).Bold().FontColor(hostOutstanding > 0 ? "#cc0000" : "#333333");
            });

            column.Item().PaddingBottom(10);
        });
    }

    private void ComposeGrandTotals(IContainer container, List<Accommodation> accommodations)
    {
        var totalCommissionDue = accommodations.Sum(a => a.Commission);
        var totalCommissionPaid = accommodations.Sum(a => a.CommissionPaid ?? 0);
        var totalOutstanding = totalCommissionDue - totalCommissionPaid;
        var totalGross = accommodations.Sum(a => a.TotalGrossWithTax);
        var totalNights = accommodations.Sum(a => a.NumberOfNights);

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
                    col.Item().Text($"Total Gross Revenue: {FormatCurrency(totalGross)}");
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text($"Total Commission Due: {FormatCurrency(totalCommissionDue)}").Bold();
                    col.Item().Text($"Total Commission Paid: {FormatCurrency(totalCommissionPaid)}");
                    col.Item().Text($"Outstanding Balance: {FormatCurrency(totalOutstanding)}")
                        .Bold()
                        .FontColor(totalOutstanding > 0 ? "#cc0000" : "#333333");
                });
            });
        });
    }
}
