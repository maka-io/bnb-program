using BnB.Core.Models;
using BnB.WinForms.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Payment Receivable Report - shows outstanding payments due.
/// </summary>
public class PaymentReceivableReport : BaseReport
{
    private readonly List<PaymentReceivableData> _receivables;

    public PaymentReceivableReport(List<PaymentReceivableData> receivables, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _receivables = receivables;
    }

    public override string Title => "Payments Receivable Report";

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
            if (_receivables.Count == 0)
            {
                column.Item().Text("No outstanding receivables.")
                    .FontSize(11).Italic();
                return;
            }

            var pastDue = _receivables.Where(a => a.DaysUntilArrival < 0).ToList();
            var upcoming = _receivables.Where(a => a.DaysUntilArrival >= 0).ToList();

            column.Item().PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Text($"Total Receivables: {_receivables.Count}").FontSize(11).SemiBold();
                row.RelativeItem().AlignRight().Text($"Past Due: {pastDue.Count} | Upcoming: {upcoming.Count}")
                    .FontSize(10);
            });

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(55);  // Conf #
                    columns.RelativeColumn(1.2f); // Guest
                    columns.RelativeColumn(1);   // Property
                    columns.ConstantColumn(65);  // Arrival
                    columns.ConstantColumn(65);  // Departure
                    columns.ConstantColumn(65);  // Total
                    columns.ConstantColumn(65);  // Paid
                    columns.ConstantColumn(65);  // Balance
                    columns.ConstantColumn(50);  // Days Until
                    columns.ConstantColumn(45);  // Pmt Rec
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest").TableHeaderText();
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().Text("Arrival").TableHeaderText();
                    header.Cell().TableHeader().Text("Departure").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Paid").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Balance").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Days").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Pmt").TableHeaderText();
                });

                bool alternate = false;
                decimal totalCharges = 0;
                decimal totalPaid = 0;
                decimal totalBalance = 0;

                foreach (var rec in _receivables.OrderBy(a => a.ArrivalDate))
                {
                    var isPastDue = rec.DaysUntilArrival < 0;

                    var textContainer = table.Cell().TableCell(alternate);
                    if (isPastDue)
                        textContainer = textContainer.Background("#ffeeee");
                    textContainer.Text(rec.ConfirmationNumber.ToString()).TableCellText();

                    textContainer = table.Cell().TableCell(alternate);
                    if (isPastDue)
                        textContainer = textContainer.Background("#ffeeee");
                    textContainer.Text($"{SafeString(rec.FirstName)} {SafeString(rec.LastName)}").TableCellText();

                    textContainer = table.Cell().TableCell(alternate);
                    if (isPastDue)
                        textContainer = textContainer.Background("#ffeeee");
                    textContainer.Text(SafeString(rec.PropertyName)).TableCellText();

                    textContainer = table.Cell().TableCell(alternate);
                    if (isPastDue)
                        textContainer = textContainer.Background("#ffeeee");
                    textContainer.Text(FormatDate(rec.ArrivalDate, "MM/dd/yy")).TableCellText();

                    textContainer = table.Cell().TableCell(alternate);
                    if (isPastDue)
                        textContainer = textContainer.Background("#ffeeee");
                    textContainer.Text(FormatDate(rec.DepartureDate, "MM/dd/yy")).TableCellText();

                    textContainer = table.Cell().CurrencyCell(alternate);
                    if (isPastDue)
                        textContainer = textContainer.Background("#ffeeee");
                    textContainer.Text(FormatCurrency(rec.TotalCharges)).TableCellText();

                    textContainer = table.Cell().CurrencyCell(alternate);
                    if (isPastDue)
                        textContainer = textContainer.Background("#ffeeee");
                    textContainer.Text(FormatCurrency(rec.TotalPaid)).TableCellText();

                    textContainer = table.Cell().CurrencyCell(alternate);
                    if (isPastDue)
                        textContainer = textContainer.Background("#ffeeee");
                    textContainer.Text(FormatCurrency(rec.BalanceDue)).FontColor("#cc0000").TableCellText();

                    textContainer = table.Cell().TableCell(alternate);
                    if (isPastDue)
                        textContainer = textContainer.Background("#ffeeee");
                    textContainer.AlignCenter().Text(rec.DaysUntilArrival.ToString()).TableCellText();

                    // Payment record indicator - show "No" with warning color if no payment record
                    textContainer = table.Cell().TableCell(alternate);
                    if (isPastDue)
                        textContainer = textContainer.Background("#ffeeee");
                    if (!rec.HasPaymentRecord)
                        textContainer.AlignCenter().Text("No").FontColor("#cc0000").Bold().TableCellText();
                    else
                        textContainer.AlignCenter().Text("Yes").TableCellText();

                    totalCharges += rec.TotalCharges;
                    totalPaid += rec.TotalPaid;
                    totalBalance += rec.BalanceDue;
                    alternate = !alternate;
                }

                // Totals rows
                table.Cell().ColumnSpan(5).TotalsRow().AlignRight().Text("Totals:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalCharges)).Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalPaid)).Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalBalance)).Bold().FontColor("#cc0000");
                table.Cell().TotalsRow(); // Days
                table.Cell().TotalsRow(); // Pmt Rec
            });

            // Legend
            column.Item().PaddingTop(15).Row(row =>
            {
                row.AutoItem().Width(15).Height(15).Background("#ffeeee");
                row.AutoItem().PaddingLeft(5).Text(" = Past arrival date").FontSize(8);
                row.AutoItem().PaddingLeft(15).Text("Pmt = Payment record exists with amounts set").FontSize(8);
            });
        });
    }
}
