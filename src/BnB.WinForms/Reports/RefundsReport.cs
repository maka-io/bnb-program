using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Refunds Report - shows accommodations where refunds are owed.
/// </summary>
public class RefundsReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<Accommodation> _refunds;

    public RefundsReport(DateTime startDate, DateTime endDate, List<Accommodation> refunds, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _refunds = refunds;
    }

    public override string Title => $"Refunds Report ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

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
            if (_refunds.Count == 0)
            {
                column.Item().Text("No refunds found for the selected date range.")
                    .FontSize(11).Italic();
                return;
            }

            column.Item().PaddingBottom(10).Text($"Total Refund Items: {_refunds.Count}")
                .FontSize(11).SemiBold();

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(70);  // Departure
                    columns.ConstantColumn(60);  // Conf #
                    columns.RelativeColumn(1.2f); // Guest Name
                    columns.RelativeColumn(1.2f); // Property
                    columns.ConstantColumn(80);  // Total Charges
                    columns.ConstantColumn(80);  // Total Paid
                    columns.ConstantColumn(80);  // Refund Owed
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Departure").TableHeaderText();
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Charges").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Paid").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Refund").TableHeaderText();
                });

                bool alternate = false;
                decimal totalRefunds = 0;

                foreach (var refund in _refunds)
                {
                    var guestName = $"{SafeString(refund.LastName)}, {SafeString(refund.FirstName)}";

                    table.Cell().TableCell(alternate).Text(FormatDate(refund.DepartureDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(refund.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(guestName).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(refund.Property?.Location)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(refund.TotalCharges)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(refund.TotalPaid)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(refund.RefundOwed)).FontColor("#cc0000").TableCellText();

                    totalRefunds += refund.RefundOwed ?? 0;
                    alternate = !alternate;
                }

                // Total row
                table.Cell().ColumnSpan(6).TotalsRow().AlignRight().Text("Total Refunds:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalRefunds)).Bold().FontColor("#cc0000");
            });
        });
    }
}
