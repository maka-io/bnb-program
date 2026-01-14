using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Refund List Report - shows pending refunds from payments.
/// </summary>
public class RefundListReport : BaseReport
{
    private readonly List<Payment> _payments;

    public RefundListReport(List<Payment> payments, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _payments = payments;
    }

    public override string Title => "Pending Refunds Report";

    public override void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.Letter);
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
            if (_payments.Count == 0)
            {
                column.Item().Text("No pending refunds.")
                    .FontSize(11).Italic();
                return;
            }

            var totalRefunds = _payments.Sum(p => p.RefundOwed ?? 0);
            column.Item().PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Text($"Total Pending Refunds: {_payments.Count}").FontSize(11).SemiBold();
                row.RelativeItem().AlignRight().Text($"Total Amount: {totalRefunds:C2}").FontSize(11).SemiBold().FontColor("#cc0000");
            });

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(70);  // Date
                    columns.ConstantColumn(60);  // Conf #
                    columns.RelativeColumn(1);   // First Name
                    columns.RelativeColumn(1);   // Last Name
                    columns.ConstantColumn(90);  // Refund Owed
                    columns.RelativeColumn(1.5f); // Comments
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Date").TableHeaderText();
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("First Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Last Name").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Refund Owed").TableHeaderText();
                    header.Cell().TableHeader().Text("Comments").TableHeaderText();
                });

                bool alternate = false;
                decimal total = 0;

                foreach (var payment in _payments.OrderByDescending(p => p.PaymentDate))
                {
                    table.Cell().TableCell(alternate).Text(FormatDate(payment.PaymentDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(payment.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(payment.FirstName)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(payment.LastName)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(payment.RefundOwed)).FontColor("#cc0000").TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(payment.Comments)).TableCellText();

                    total += payment.RefundOwed ?? 0;
                    alternate = !alternate;
                }

                // Total row
                table.Cell().ColumnSpan(4).TotalsRow().AlignRight().Text("Total Refunds:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(total)).Bold().FontColor("#cc0000");
                table.Cell().TotalsRow();
            });
        });
    }
}
