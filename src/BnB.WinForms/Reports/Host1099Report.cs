using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Host 1099 Report - generates tax reporting data for hosts
/// Migrated from Tax1099.rpt
/// </summary>
public class Host1099Report : BaseReport
{
    private readonly int _taxYear;
    private readonly IEnumerable<Host1099Data> _hostData;
    private readonly decimal _minimumReportingThreshold;

    public override string Title => $"Host 1099 Report - Tax Year {_taxYear}";

    public Host1099Report(int taxYear, IEnumerable<Host1099Data> hostData, decimal minimumReportingThreshold = 600, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _taxYear = taxYear;
        _hostData = hostData.OrderBy(h => h.HostName).ToList();
        _minimumReportingThreshold = minimumReportingThreshold;
    }

    public override void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.Letter);
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
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(CompanyName)
                        .FontSize(HeaderFontSize)
                        .Bold()
                        .FontColor(ReportStyles.PrimaryColor);

                    col.Item().Text(Title)
                        .FontSize(SubHeaderFontSize)
                        .SemiBold();

                    col.Item().Text($"Minimum Reporting Threshold: {FormatCurrency(_minimumReportingThreshold)}")
                        .FontSize(9)
                        .Italic();
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
        var hostList = _hostData.ToList();
        var reportableHosts = hostList.Where(h => h.TotalPaid >= _minimumReportingThreshold).ToList();
        var nonReportableHosts = hostList.Where(h => h.TotalPaid < _minimumReportingThreshold).ToList();

        container.Column(column =>
        {
            // Summary
            column.Item().PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Text($"Total Hosts: {hostList.Count}").FontSize(10);
                row.RelativeItem().Text($"Reportable (>= {FormatCurrency(_minimumReportingThreshold)}): {reportableHosts.Count}").FontSize(10).Bold();
                row.RelativeItem().Text($"Non-Reportable: {nonReportableHosts.Count}").FontSize(10);
            });

            // Reportable Hosts Section
            if (reportableHosts.Any())
            {
                column.Item().Element(c => ComposeHostTable(c, "Hosts Requiring 1099", reportableHosts, true));
            }

            // Non-Reportable Hosts Section
            if (nonReportableHosts.Any())
            {
                column.Item().PaddingTop(20).Element(c => ComposeHostTable(c, $"Hosts Below {FormatCurrency(_minimumReportingThreshold)} Threshold", nonReportableHosts, false));
            }

            // Grand totals
            column.Item().PaddingTop(20).Element(c => ComposeSummary(c, hostList, reportableHosts));
        });
    }

    private void ComposeHostTable(IContainer container, string sectionTitle, List<Host1099Data> hosts, bool isReportable)
    {
        container.Column(column =>
        {
            column.Item().SectionHeader()
                .Text(sectionTitle)
                .FontSize(11)
                .Bold()
                .FontColor("#ffffff");

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(60);  // Account #
                    columns.RelativeColumn(1.5f); // Host Name
                    columns.RelativeColumn(1);   // Address
                    columns.RelativeColumn(1);   // City, State Zip
                    columns.ConstantColumn(100); // Federal Tax ID
                    columns.ConstantColumn(80);  // Total Paid
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Acct #").TableHeaderText();
                    header.Cell().TableHeader().Text("Host Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Address").TableHeaderText();
                    header.Cell().TableHeader().Text("City, State Zip").TableHeaderText();
                    header.Cell().TableHeader().Text("Federal Tax ID").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total Paid").TableHeaderText();
                });

                bool alternate = false;
                foreach (var host in hosts)
                {
                    var cityStateZip = $"{SafeString(host.City)}, {SafeString(host.State)} {SafeString(host.ZipCode)}";

                    table.Cell().TableCell(alternate).Text(host.AccountNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(host.HostName)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(host.Address)).TableCellText();
                    table.Cell().TableCell(alternate).Text(cityStateZip).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(host.FederalTaxId)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(host.TotalPaid))
                        .FontColor(isReportable ? "#cc0000" : "#333333")
                        .TableCellText();

                    alternate = !alternate;
                }

                // Subtotal
                var subtotal = hosts.Sum(h => h.TotalPaid);
                table.Cell().ColumnSpan(5).TotalsRow().AlignRight().Text($"Subtotal ({hosts.Count} hosts):").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(subtotal)).Bold();
            });
        });
    }

    private void ComposeSummary(IContainer container, List<Host1099Data> allHosts, List<Host1099Data> reportableHosts)
    {
        var totalPaid = allHosts.Sum(h => h.TotalPaid);
        var reportablePaid = reportableHosts.Sum(h => h.TotalPaid);
        var nonReportablePaid = totalPaid - reportablePaid;

        container.Border(2).BorderColor(ReportStyles.PrimaryColor).Padding(10).Column(column =>
        {
            column.Item().Text("Summary").FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().PaddingTop(5);

            column.Item().Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    col.Item().Text($"Total Hosts: {allHosts.Count}");
                    col.Item().Text($"Hosts Requiring 1099: {reportableHosts.Count}");
                    col.Item().Text($"Hosts Below Threshold: {allHosts.Count - reportableHosts.Count}");
                });

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text($"Total Paid to All Hosts: {FormatCurrency(totalPaid)}").Bold();
                    col.Item().Text($"Reportable Amount: {FormatCurrency(reportablePaid)}").FontColor("#cc0000");
                    col.Item().Text($"Non-Reportable Amount: {FormatCurrency(nonReportablePaid)}");
                });
            });

            column.Item().PaddingTop(10).Text(text =>
            {
                text.Span("Note: ").Bold().FontSize(8);
                text.Span("IRS Form 1099-MISC must be filed for each host who received $600 or more during the tax year. " +
                         "Verify Federal Tax IDs are on file before filing.").FontSize(8);
            });
        });
    }
}

/// <summary>
/// Data structure for Host 1099 reporting
/// </summary>
public class Host1099Data
{
    public int AccountNumber { get; set; }
    public string? HostName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? FederalTaxId { get; set; }
    public decimal TotalPaid { get; set; }
    public int ReservationCount { get; set; }
}
