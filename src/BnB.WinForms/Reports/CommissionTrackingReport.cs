using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Commission Tracking Report - shows commission status by property.
/// </summary>
public class CommissionTrackingReport : BaseReport
{
    private readonly List<CommissionTrackingItem> _commissions;
    private readonly string _propertyFilter;
    private readonly bool _unpaidOnly;

    public CommissionTrackingReport(List<CommissionTrackingItem> commissions, string propertyFilter, bool unpaidOnly)
    {
        _commissions = commissions;
        _propertyFilter = propertyFilter;
        _unpaidOnly = unpaidOnly;
    }

    public override string Title => "Commission Tracking Report";

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
            // Filters applied
            var filterText = $"Property: {_propertyFilter}";
            if (_unpaidOnly)
                filterText += " | Unpaid Only";
            column.Item().PaddingBottom(5).Text(filterText).FontSize(9).Italic();

            if (_commissions.Count == 0)
            {
                column.Item().PaddingTop(10).Text("No commission records found.")
                    .FontSize(11).Italic();
                return;
            }

            var totalCommission = _commissions.Sum(c => c.Commission);
            var totalPaid = _commissions.Sum(c => c.CommissionPaid);
            var totalDue = _commissions.Sum(c => c.CommissionDue);

            column.Item().PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Text($"Total Records: {_commissions.Count}").FontSize(11).SemiBold();
                row.RelativeItem().AlignRight().Text($"Total Due: {totalDue:C2}").FontSize(11).SemiBold().FontColor("#cc0000");
            });

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(60);  // Conf #
                    columns.RelativeColumn(1.2f); // Guest Name
                    columns.RelativeColumn(1.2f); // Property
                    columns.ConstantColumn(70);  // Departure
                    columns.ConstantColumn(80);  // Commission
                    columns.ConstantColumn(80);  // Paid
                    columns.ConstantColumn(80);  // Due
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().Text("Departure").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Commission").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Paid").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Due").TableHeaderText();
                });

                bool alternate = false;

                foreach (var item in _commissions.OrderBy(c => c.PropertyName).ThenBy(c => c.DepartureDate))
                {
                    table.Cell().TableCell(alternate).Text(item.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(item.GuestName).TableCellText();
                    table.Cell().TableCell(alternate).Text(item.PropertyName).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(item.DepartureDate, "MM/dd/yy")).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(item.Commission)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(item.CommissionPaid)).TableCellText();

                    var dueText = table.Cell().CurrencyCell(alternate).Text(FormatCurrency(item.CommissionDue)).TableCellText();
                    if (item.CommissionDue > 0)
                        dueText.FontColor("#cc0000");

                    alternate = !alternate;
                }

                // Total row
                table.Cell().ColumnSpan(4).TotalsRow().AlignRight().Text("Totals:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalCommission)).Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalPaid)).Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalDue)).Bold().FontColor("#cc0000");
            });

            // Summary by property
            column.Item().PaddingTop(20).Text("Summary by Property").FontSize(12).Bold();
            column.Item().PaddingTop(5).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(1.5f);
                    columns.ConstantColumn(70);
                    columns.ConstantColumn(90);
                    columns.ConstantColumn(90);
                    columns.ConstantColumn(90);
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Count").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Commission").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Paid").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Due").TableHeaderText();
                });

                bool alternate = false;
                var byProperty = _commissions.GroupBy(c => c.PropertyName)
                    .OrderByDescending(g => g.Sum(c => c.CommissionDue));

                foreach (var propertyGroup in byProperty)
                {
                    var propDue = propertyGroup.Sum(c => c.CommissionDue);
                    table.Cell().TableCell(alternate).Text(propertyGroup.Key).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(propertyGroup.Count().ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(propertyGroup.Sum(c => c.Commission))).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(propertyGroup.Sum(c => c.CommissionPaid))).TableCellText();
                    var dueText = table.Cell().CurrencyCell(alternate).Text(FormatCurrency(propDue)).TableCellText();
                    if (propDue > 0)
                        dueText.FontColor("#cc0000");
                    alternate = !alternate;
                }
            });
        });
    }
}

/// <summary>
/// Data transfer object for commission tracking.
/// </summary>
public class CommissionTrackingItem
{
    public long ConfirmationNumber { get; set; }
    public string GuestName { get; set; } = "";
    public string PropertyName { get; set; } = "";
    public DateTime DepartureDate { get; set; }
    public decimal Commission { get; set; }
    public decimal CommissionPaid { get; set; }
    public decimal CommissionDue { get; set; }
}
