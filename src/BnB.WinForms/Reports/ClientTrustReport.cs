using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Client Trust Reconciliation Report - shows payments received and their allocation.
/// </summary>
public class ClientTrustReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<Payment> _payments;

    public ClientTrustReport(DateTime startDate, DateTime endDate, List<Payment> payments)
    {
        _startDate = startDate;
        _endDate = endDate;
        _payments = payments;
    }

    public override string Title => $"Client Trust Reconciliation ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

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
                column.Item().Text("No payments found for the selected date range.")
                    .FontSize(11).Italic();
                return;
            }

            // Summary section
            column.Item().PaddingBottom(10).Column(summaryCol =>
            {
                var totalReceived = _payments.Sum(p => p.Amount);
                var byMethod = _payments.GroupBy(p => p.PaymentMethod ?? "Unknown")
                    .Select(g => new { Method = g.Key, Total = g.Sum(p => p.Amount) })
                    .OrderByDescending(m => m.Total);

                summaryCol.Item().Text("Payment Summary by Method:").Bold().FontSize(11);
                foreach (var method in byMethod)
                {
                    summaryCol.Item().Text($"  {method.Method}: {FormatCurrency(method.Total)}").FontSize(10);
                }
                summaryCol.Item().PaddingTop(5).Text($"Total Received: {FormatCurrency(totalReceived)}")
                    .Bold().FontSize(11).FontColor(ReportStyles.PrimaryColor);
            });

            column.Item().PaddingVertical(10).LineHorizontal(1);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(70);  // Date
                    columns.ConstantColumn(60);  // Conf #
                    columns.RelativeColumn(1.2f); // Guest Name
                    columns.ConstantColumn(80);  // Method
                    columns.RelativeColumn(1);   // Reference
                    columns.ConstantColumn(80);  // Amount
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Date").TableHeaderText();
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Method").TableHeaderText();
                    header.Cell().TableHeader().Text("Reference").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Amount").TableHeaderText();
                });

                bool alternate = false;
                decimal totalAmount = 0;

                foreach (var payment in _payments)
                {
                    var guest = payment.Accommodation?.Guest;
                    var guestName = guest != null ? $"{SafeString(guest.LastName)}, {SafeString(guest.FirstName)}" : "N/A";
                    var confNum = payment.Accommodation?.ConfirmationNumber ?? 0;

                    table.Cell().TableCell(alternate).Text(FormatDate(payment.PaymentDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(confNum.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(guestName).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(payment.PaymentMethod)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(payment.CheckNumber)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(payment.Amount)).TableCellText();

                    totalAmount += payment.Amount;
                    alternate = !alternate;
                }

                // Total row
                table.Cell().ColumnSpan(5).TotalsRow().AlignRight().Text("Total:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalAmount)).Bold();
            });

            column.Item().PaddingTop(10).Text($"Total Transactions: {_payments.Count}")
                .FontSize(10).SemiBold();
        });
    }
}
