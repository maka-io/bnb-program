using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Data transfer object for check ledger report entries
/// </summary>
public class CheckRecord
{
    public int CheckNumber { get; set; }
    public DateTime? CheckDate { get; set; }
    public string? PayTo { get; set; }
    public long ConfirmationNumber { get; set; }
    public string? GuestLastName { get; set; }
    public string? Location { get; set; }
    public string? Category { get; set; }
    public decimal Amount { get; set; }
    public bool IsVoid { get; set; }
}

/// <summary>
/// Check Ledger Report - lists checks written within a date range
/// Migrated from ChkLedgr.rpt
/// </summary>
public class CheckLedgerReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly IEnumerable<CheckRecord> _checks;
    private readonly string _category;

    public override string Title => $"Check Ledger ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

    public CheckLedgerReport(DateTime startDate, DateTime endDate, IEnumerable<CheckRecord> checks, string category = "All", CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _checks = checks.OrderBy(c => c.CheckDate).ThenBy(c => c.CheckNumber).ToList();
        _category = category;
    }

    public override void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.Letter.Landscape());
            page.Margin(DefaultMargin);
            page.DefaultTextStyle(x => x.FontSize(BodyFontSize).FontFamily("Arial"));

            page.Header().Element(ComposeReportHeader);
            page.Content().Element(ComposeContent);
            page.Footer().Element(ComposeFooter);
        });
    }

    private void ComposeReportHeader(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Row(row =>
            {
                // Logo on the left (if available)
                if (CompanyInfo?.Logo != null && CompanyInfo.Logo.Length > 0)
                {
                    row.ConstantItem(80).Height(60).Image(CompanyInfo.Logo, ImageScaling.FitArea);
                    row.ConstantItem(15); // Spacing
                }

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(CompanyName)
                        .FontSize(HeaderFontSize)
                        .Bold()
                        .FontColor(ReportStyles.PrimaryColor);

                    // Address line (if available)
                    if (CompanyInfo != null && !string.IsNullOrWhiteSpace(CompanyInfo.Address))
                    {
                        var addressLine = CompanyInfo.Address;
                        if (!string.IsNullOrWhiteSpace(CompanyInfo.City))
                            addressLine += $", {CompanyInfo.City}";
                        if (!string.IsNullOrWhiteSpace(CompanyInfo.State))
                            addressLine += $", {CompanyInfo.State}";
                        if (!string.IsNullOrWhiteSpace(CompanyInfo.ZipCode))
                            addressLine += $" {CompanyInfo.ZipCode}";
                        col.Item().Text(addressLine).FontSize(SmallFontSize);
                    }

                    // Contact info
                    if (CompanyInfo != null)
                    {
                        var contactParts = new List<string>();
                        if (!string.IsNullOrWhiteSpace(CompanyInfo.Phone))
                            contactParts.Add($"Phone: {CompanyInfo.Phone}");
                        if (!string.IsNullOrWhiteSpace(CompanyInfo.Email))
                            contactParts.Add(CompanyInfo.Email);
                        if (contactParts.Count > 0)
                            col.Item().Text(string.Join(" | ", contactParts)).FontSize(SmallFontSize);
                    }

                    col.Item().PaddingTop(5).Text(Title)
                        .FontSize(SubHeaderFontSize)
                        .SemiBold();

                    if (_category != "All")
                    {
                        col.Item().Text($"Category: {_category}")
                            .FontSize(10);
                    }
                });

                row.ConstantItem(150).AlignRight().Column(col =>
                {
                    col.Item().Text($"Generated: {ReportDate:MM/dd/yyyy}")
                        .FontSize(SmallFontSize);
                });
            });

            column.Item().PaddingVertical(5).LineHorizontal(1).LineColor(ReportStyles.BorderColor);
        });
    }

    private void ComposeContent(IContainer container)
    {
        var checkList = _checks.ToList();

        container.Column(column =>
        {
            column.Item().PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Text($"Total Checks: {checkList.Count}").FontSize(11).SemiBold();
                row.RelativeItem().AlignRight().Text($"Total Amount: {FormatCurrency(checkList.Sum(c => c.Amount))}").FontSize(11).SemiBold();
            });

            if (!checkList.Any())
            {
                column.Item().Text("No checks found for the selected date range.")
                    .FontSize(11)
                    .Italic();
                return;
            }

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(70);  // Check #
                    columns.ConstantColumn(80);  // Date
                    columns.RelativeColumn(1.5f); // Payee
                    columns.ConstantColumn(80);  // Conf #
                    columns.RelativeColumn(1);   // Guest
                    columns.RelativeColumn(1);   // Property
                    columns.ConstantColumn(80);  // Category
                    columns.ConstantColumn(80);  // Amount
                    columns.ConstantColumn(50);  // Void
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Check #").TableHeaderText();
                    header.Cell().TableHeader().Text("Date").TableHeaderText();
                    header.Cell().TableHeader().Text("Payee").TableHeaderText();
                    header.Cell().TableHeader().Text("Conf #").TableHeaderText();
                    header.Cell().TableHeader().Text("Guest").TableHeaderText();
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().Text("Category").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Amount").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Void").TableHeaderText();
                });

                bool alternate = false;
                foreach (var check in checkList)
                {
                    table.Cell().TableCell(alternate).Text(check.CheckNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(check.CheckDate)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(check.PayTo)).TableCellText();
                    table.Cell().TableCell(alternate).Text(check.ConfirmationNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(check.GuestLastName)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(check.Location)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(check.Category)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(check.Amount)).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(check.IsVoid ? "X" : "").TableCellText();

                    alternate = !alternate;
                }

                // Total row
                var validChecks = checkList.Where(c => !c.IsVoid).ToList();
                var totalAmount = validChecks.Sum(c => c.Amount);
                table.Cell().ColumnSpan(7).TotalsRow().AlignRight().Text($"Total ({validChecks.Count} checks):").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalAmount)).Bold();
                table.Cell().TotalsRow();
            });

            // Summary by Category
            column.Item().PaddingTop(20).Element(ComposeSummaryByCategory);
        });
    }

    private void ComposeSummaryByCategory(IContainer container)
    {
        var checkList = _checks.Where(c => !c.IsVoid).ToList();
        if (!checkList.Any()) return;

        var byCategory = checkList
            .GroupBy(c => c.Category ?? "Uncategorized")
            .OrderBy(g => g.Key)
            .ToList();

        container.Column(column =>
        {
            column.Item().Text("Summary by Category").FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().PaddingTop(5);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2);
                    columns.ConstantColumn(80);
                    columns.ConstantColumn(100);
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Category").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Count").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total Amount").TableHeaderText();
                });

                bool alternate = false;
                foreach (var group in byCategory)
                {
                    table.Cell().TableCell(alternate).Text(group.Key).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(group.Count().ToString()).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(group.Sum(c => c.Amount))).TableCellText();
                    alternate = !alternate;
                }
            });
        });
    }
}
