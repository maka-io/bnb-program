using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Check Printing Report - formats checks for standard laser check stock
/// Migrated from HstLngCk.rpt and HstShtCk.rpt
/// Supports standard 3-per-page laser check stock (8.5" x 11" with 3.5" checks)
/// </summary>
public class CheckPrintReport : BaseReport
{
    private readonly IEnumerable<Check> _checks;
    private readonly CompanyInfo? _companyInfo;
    private readonly string _bankName;
    private readonly string _bankAddress;
    private readonly string _routingNumber;
    private readonly string _accountNumber;

    // Standard laser check dimensions (3 checks per page)
    private const float CheckHeight = 252; // 3.5 inches at 72 dpi
    private const float StubHeight = 72;   // 1 inch stub area

    public override string Title => "Check Print";

    public CheckPrintReport(
        IEnumerable<Check> checks,
        CompanyInfo? companyInfo = null,
        string bankName = "First Hawaiian Bank",
        string bankAddress = "Honolulu, HI",
        string routingNumber = "XXXXXXXXX",
        string accountNumber = "XXXXXXXXXX")
    {
        _checks = checks.ToList();
        _companyInfo = companyInfo;
        _bankName = bankName;
        _bankAddress = bankAddress;
        _routingNumber = routingNumber;
        _accountNumber = accountNumber;
    }

    public override void Compose(IDocumentContainer container)
    {
        var checkList = _checks.ToList();

        container.Page(page =>
        {
            page.Size(PageSizes.Letter);
            page.MarginHorizontal(36); // 0.5 inch margins
            page.MarginVertical(0);    // No vertical margins - checks need precise placement
            page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

            page.Content().Column(column =>
            {
                foreach (var check in checkList)
                {
                    column.Item().Height(CheckHeight).Element(c => ComposeCheck(c, check));
                }
            });
        });
    }

    private void ComposeCheck(IContainer container, Check check)
    {
        container.Border(0.5f).BorderColor("#cccccc").Column(column =>
        {
            // Main check area (top portion)
            column.Item().Height(CheckHeight - StubHeight).Padding(15).Column(checkArea =>
            {
                // Top row: Company info and check number
                checkArea.Item().Row(row =>
                {
                    // Company info (left side)
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text(_companyInfo?.CompanyName ?? "Hawaii's Best Bed & Breakfasts")
                            .FontSize(11).Bold();

                        if (!string.IsNullOrEmpty(_companyInfo?.Address))
                            col.Item().Text(_companyInfo.Address).FontSize(9);

                        var cityStateZip = FormatCityStateZip(_companyInfo?.City, _companyInfo?.State, _companyInfo?.ZipCode);
                        if (!string.IsNullOrEmpty(cityStateZip))
                            col.Item().Text(cityStateZip).FontSize(9);
                    });

                    // Check number (right side)
                    row.ConstantItem(120).AlignRight().Column(col =>
                    {
                        col.Item().Text($"Check No. {check.CheckNumber}")
                            .FontSize(11).Bold();
                        col.Item().Text(FormatDate(check.CheckDate))
                            .FontSize(10);
                    });
                });

                checkArea.Item().Height(15);

                // Bank info
                checkArea.Item().Text(_bankName).FontSize(9);
                checkArea.Item().Text(_bankAddress).FontSize(8);

                checkArea.Item().Height(20);

                // Pay to the order of line
                checkArea.Item().Row(row =>
                {
                    row.ConstantItem(100).Text("PAY TO THE").FontSize(9);
                    row.RelativeItem().BorderBottom(1).BorderColor("#000000").Padding(2)
                        .Text(check.PayableTo ?? "").FontSize(11).Bold();
                });

                checkArea.Item().Row(row =>
                {
                    row.ConstantItem(100).Text("ORDER OF").FontSize(9);
                    row.RelativeItem();
                });

                checkArea.Item().Height(10);

                // Amount line
                checkArea.Item().Row(row =>
                {
                    row.RelativeItem().BorderBottom(1).BorderColor("#000000").Padding(2)
                        .Text(ConvertAmountToWords(check.Amount)).FontSize(10);

                    row.ConstantItem(120).Border(1).BorderColor("#000000").Padding(5)
                        .AlignCenter().Text($"${check.Amount:N2}").FontSize(12).Bold();
                });

                checkArea.Item().Height(15);

                // Memo line
                checkArea.Item().Row(row =>
                {
                    row.ConstantItem(50).Text("MEMO:").FontSize(9);
                    row.RelativeItem().BorderBottom(1).BorderColor("#000000").Padding(2)
                        .Text(check.Memo ?? "").FontSize(9);

                    // Signature line
                    row.ConstantItem(150).Column(sigCol =>
                    {
                        sigCol.Item().BorderBottom(1).BorderColor("#000000").Height(20);
                        sigCol.Item().AlignCenter().Text("Authorized Signature").FontSize(7);
                    });
                });

                checkArea.Item().Height(10);

                // MICR line (simulated - actual MICR requires special font)
                checkArea.Item().AlignCenter().Text($"⑆{_routingNumber}⑆ {_accountNumber}⑈ {check.CheckNumber}")
                    .FontSize(10).FontFamily("Courier New");
            });

            // Stub area (bottom portion)
            column.Item().Height(StubHeight).Background("#f9f9f9").BorderTop(1)
                .BorderColor("#cccccc").Padding(8).Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text($"Check #{check.CheckNumber}").FontSize(8).Bold();
                    col.Item().Text($"Date: {FormatDate(check.CheckDate)}").FontSize(7);
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text($"Pay To: {check.PayableTo}").FontSize(8);
                    col.Item().Text($"Amount: {check.Amount:C2}").FontSize(8).Bold();
                });

                row.RelativeItem().Column(col =>
                {
                    if (!string.IsNullOrEmpty(check.Memo))
                        col.Item().Text($"Memo: {check.Memo}").FontSize(7);
                    if (check.Accommodation != null)
                        col.Item().Text($"Property: {check.Accommodation.Property?.Location ?? "N/A"}").FontSize(7);
                });
            });
        });
    }

    private static string FormatCityStateZip(string? city, string? state, string? zip)
    {
        var parts = new List<string>();
        if (!string.IsNullOrEmpty(city)) parts.Add(city);
        if (!string.IsNullOrEmpty(state)) parts.Add(state);

        var result = string.Join(", ", parts);
        if (!string.IsNullOrEmpty(zip))
            result += " " + zip;

        return result.Trim();
    }

    private static string ConvertAmountToWords(decimal amount)
    {
        var dollars = (long)Math.Floor(amount);
        var cents = (int)((amount - dollars) * 100);

        var words = NumberToWords(dollars);
        return $"{words} and {cents:D2}/100 DOLLARS";
    }

    private static string NumberToWords(long number)
    {
        if (number == 0) return "Zero";

        var ones = new[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        var tens = new[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        var words = "";

        if (number >= 1000000)
        {
            words += NumberToWords(number / 1000000) + " Million ";
            number %= 1000000;
        }

        if (number >= 1000)
        {
            words += NumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if (number >= 100)
        {
            words += ones[number / 100] + " Hundred ";
            number %= 100;
        }

        if (number >= 20)
        {
            words += tens[number / 10] + " ";
            number %= 10;
        }

        if (number > 0)
        {
            words += ones[number] + " ";
        }

        return words.Trim();
    }
}
