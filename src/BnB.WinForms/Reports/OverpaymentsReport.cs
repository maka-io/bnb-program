using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Overpayments Report - shows accommodations where guest paid more than total charges.
/// </summary>
public class OverpaymentsReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<Accommodation> _overpayments;

    public OverpaymentsReport(DateTime startDate, DateTime endDate, List<Accommodation> overpayments, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _overpayments = overpayments;
    }

    public override string Title => $"Overpayments To Host Properties ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

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
                column.Item().Text("No overpayments found for the selected date range.")
                    .FontSize(11).Italic();
                return;
            }

            // Group by property
            var byProperty = _overpayments.GroupBy(a => a.Property?.Location ?? "Unknown").OrderBy(g => g.Key);
            decimal grandTotal = 0;

            foreach (var propertyGroup in byProperty)
            {
                column.Item().PaddingTop(15).Text(propertyGroup.Key)
                    .FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);

                column.Item().PaddingTop(5).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(70);  // Departure
                        columns.ConstantColumn(60);  // Conf #
                        columns.RelativeColumn(1.5f); // Guest Name
                        columns.ConstantColumn(80);  // Total Charges
                        columns.ConstantColumn(80);  // Total Paid
                        columns.ConstantColumn(80);  // Overpayment
                    });

                    table.Header(header =>
                    {
                        header.Cell().TableHeader().Text("Departure").TableHeaderText();
                        header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                        header.Cell().TableHeader().Text("Guest Name").TableHeaderText();
                        header.Cell().TableHeader().AlignRight().Text("Charges").TableHeaderText();
                        header.Cell().TableHeader().AlignRight().Text("Paid").TableHeaderText();
                        header.Cell().TableHeader().AlignRight().Text("Overpayment").TableHeaderText();
                    });

                    bool alternate = false;
                    decimal propertyTotal = 0;

                    foreach (var op in propertyGroup.OrderBy(a => a.DepartureDate))
                    {
                        var guestName = $"{SafeString(op.LastName)}, {SafeString(op.FirstName)}";
                        var overpayment = (op.TotalPaid ?? 0) - (op.TotalCharges ?? 0);

                        table.Cell().TableCell(alternate).Text(FormatDate(op.DepartureDate, "MM/dd/yy")).TableCellText();
                        table.Cell().TableCell(alternate).Text(op.ConfirmationNumber.ToString()).TableCellText();
                        table.Cell().TableCell(alternate).Text(guestName).TableCellText();
                        table.Cell().CurrencyCell(alternate).Text(FormatCurrency(op.TotalCharges)).TableCellText();
                        table.Cell().CurrencyCell(alternate).Text(FormatCurrency(op.TotalPaid)).TableCellText();
                        table.Cell().CurrencyCell(alternate).Text(FormatCurrency(overpayment)).FontColor("#008800").TableCellText();

                        propertyTotal += overpayment;
                        alternate = !alternate;
                    }

                    // Property subtotal
                    table.Cell().ColumnSpan(5).TotalsRow().AlignRight().Text("Property Total:").Bold();
                    table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(propertyTotal)).Bold().FontColor("#008800");

                    grandTotal += propertyTotal;
                });
            }

            // Grand total
            column.Item().PaddingTop(15).LineHorizontal(2).LineColor(ReportStyles.PrimaryColor);
            column.Item().PaddingTop(10).Row(row =>
            {
                row.RelativeItem().Text("Grand Total Overpayments:").Bold().FontSize(12);
                row.ConstantItem(100).AlignRight().Text(FormatCurrency(grandTotal)).Bold().FontSize(12).FontColor("#008800");
            });

            column.Item().PaddingTop(5).Text($"Total Overpayment Items: {_overpayments.Count}")
                .FontSize(10);
        });
    }
}
