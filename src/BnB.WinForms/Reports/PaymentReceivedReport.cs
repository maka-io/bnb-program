using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Payments Received Report - shows payments received within a date range.
/// </summary>
public class PaymentReceivedReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<Payment> _payments;

    public PaymentReceivedReport(DateTime startDate, DateTime endDate, List<Payment> payments)
    {
        _startDate = startDate;
        _endDate = endDate;
        _payments = payments;
    }

    public override string Title => $"Payments Received ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

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
            if (_payments.Count == 0)
            {
                column.Item().Text("No payments found for the selected date range.")
                    .FontSize(11).Italic();
                return;
            }

            column.Item().PaddingBottom(10).Text($"Total Payments: {_payments.Count}")
                .FontSize(11).SemiBold();

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(70);  // Date
                    columns.ConstantColumn(60);  // Conf #
                    columns.RelativeColumn(1.2f); // Guest Name
                    columns.RelativeColumn(1.2f); // Property
                    columns.ConstantColumn(70);  // Method
                    columns.ConstantColumn(70);  // Check #
                    columns.ConstantColumn(80);  // Amount
                    columns.RelativeColumn(1);   // Notes
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Date").TableHeaderText();
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().Text("Method").TableHeaderText();
                    header.Cell().TableHeader().Text("Check#").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Amount").TableHeaderText();
                    header.Cell().TableHeader().Text("Notes").TableHeaderText();
                });

                bool alternate = false;
                decimal totalAmount = 0;

                foreach (var payment in _payments.OrderBy(p => p.PaymentDate))
                {
                    var guestName = $"{SafeString(payment.Accommodation?.FirstName)} {SafeString(payment.Accommodation?.LastName)}";
                    var propertyName = SafeString(payment.Accommodation?.Property?.Location);

                    table.Cell().TableCell(alternate).Text(FormatDate(payment.PaymentDate, "MM/dd/yy")).TableCellText();
                    table.Cell().TableCell(alternate).Text(payment.Accommodation?.ConfirmationNumber.ToString() ?? "").TableCellText();
                    table.Cell().TableCell(alternate).Text(guestName).TableCellText();
                    table.Cell().TableCell(alternate).Text(propertyName).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(payment.PaymentMethod)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(payment.CheckNumber)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(payment.Amount)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(payment.Notes)).TableCellText();

                    totalAmount += payment.Amount;
                    alternate = !alternate;
                }

                // Total row
                table.Cell().ColumnSpan(6).TotalsRow().AlignRight().Text("Total Received:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalAmount)).Bold();
                table.Cell().TotalsRow();
            });

            // Summary by payment method
            column.Item().PaddingTop(20).Text("Summary by Payment Method").FontSize(12).Bold();
            column.Item().PaddingTop(5).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(1);
                    columns.ConstantColumn(80);
                    columns.ConstantColumn(100);
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Payment Method").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Count").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                bool alternate = false;
                var byMethod = _payments.GroupBy(p => p.PaymentMethod ?? "Unknown")
                    .OrderByDescending(g => g.Sum(p => p.Amount));

                foreach (var methodGroup in byMethod)
                {
                    table.Cell().TableCell(alternate).Text(methodGroup.Key).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(methodGroup.Count().ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(methodGroup.Sum(p => p.Amount))).TableCellText();
                    alternate = !alternate;
                }
            });
        });
    }
}
