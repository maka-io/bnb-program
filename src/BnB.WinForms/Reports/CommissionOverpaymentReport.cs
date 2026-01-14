using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Commission Overpayment Report - shows commission overpayments by property.
/// </summary>
public class CommissionOverpaymentReport : BaseReport
{
    private readonly List<CommissionOverpaymentItem> _overpayments;

    public CommissionOverpaymentReport(List<CommissionOverpaymentItem> overpayments, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _overpayments = overpayments;
    }

    public override string Title => "Commission Overpayments Report";

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
            if (_overpayments.Count == 0)
            {
                column.Item().Text("No commission overpayments found.")
                    .FontSize(11).Italic();
                return;
            }

            var totalOverpayments = _overpayments.Sum(o => o.Overpayment);
            column.Item().PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Text($"Total Overpayment Items: {_overpayments.Count}").FontSize(11).SemiBold();
                row.RelativeItem().AlignRight().Text($"Total Amount: {totalOverpayments:C2}").FontSize(11).SemiBold().FontColor("#cc0000");
            });

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(60);  // Conf #
                    columns.RelativeColumn(1);   // First Name
                    columns.RelativeColumn(1);   // Last Name
                    columns.RelativeColumn(1.2f); // Property
                    columns.ConstantColumn(80);  // Commission Due
                    columns.ConstantColumn(80);  // Paid
                    columns.ConstantColumn(80);  // Overpayment
                    columns.ConstantColumn(70);  // Departure
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                    header.Cell().TableHeader().Text("First Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Last Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Commission").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Paid").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Overpayment").TableHeaderText();
                    header.Cell().TableHeader().Text("Departure").TableHeaderText();
                });

                bool alternate = false;
                decimal total = 0;

                foreach (var item in _overpayments.OrderByDescending(o => o.Overpayment))
                {
                    table.Cell().TableCell(alternate).Text(item.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(item.FirstName).TableCellText();
                    table.Cell().TableCell(alternate).Text(item.LastName).TableCellText();
                    table.Cell().TableCell(alternate).Text(item.PropertyName).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(item.Commission)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(item.CommissionPaid)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(item.Overpayment)).FontColor("#cc0000").TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(item.DepartureDate, "MM/dd/yy")).TableCellText();

                    total += item.Overpayment;
                    alternate = !alternate;
                }

                // Total row
                table.Cell().ColumnSpan(6).TotalsRow().AlignRight().Text("Total Overpayments:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(total)).Bold().FontColor("#cc0000");
                table.Cell().TotalsRow();
            });
        });
    }
}

/// <summary>
/// Data transfer object for commission overpayments.
/// </summary>
public class CommissionOverpaymentItem
{
    public long ConfirmationNumber { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PropertyName { get; set; } = "";
    public decimal Commission { get; set; }
    public decimal CommissionPaid { get; set; }
    public decimal Overpayment { get; set; }
    public DateTime DepartureDate { get; set; }
}
