using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Client Trust Summary Report - shows trust account reconciliation.
/// </summary>
public class ClientTrustSummaryReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly ClientTrustSummary _summary;

    public ClientTrustSummaryReport(DateTime startDate, DateTime endDate, ClientTrustSummary summary, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _summary = summary;
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
            column.Item().PaddingTop(20);

            // Cash Flow Section
            column.Item().Border(1).BorderColor(ReportStyles.BorderColor).Column(section =>
            {
                section.Item().Background(ReportStyles.PrimaryColor).Padding(10)
                    .Text("Cash Flow Summary").FontSize(14).Bold().FontColor("#ffffff");

                section.Item().Padding(15).Column(content =>
                {
                    content.Item().Row(row =>
                    {
                        row.RelativeItem().Text("Payments Received:").FontSize(12);
                        row.ConstantItem(120).AlignRight().Text(_summary.PaymentsReceived.ToString("C2")).FontSize(12).FontColor("#008800");
                    });

                    content.Item().PaddingTop(10).Row(row =>
                    {
                        row.RelativeItem().Text("Checks Written:").FontSize(12);
                        row.ConstantItem(120).AlignRight().Text($"({_summary.ChecksWritten:C2})").FontSize(12).FontColor("#cc0000");
                    });

                    content.Item().PaddingTop(10).LineHorizontal(1).LineColor(ReportStyles.BorderColor);

                    content.Item().PaddingTop(10).Row(row =>
                    {
                        row.RelativeItem().Text("Net Change:").FontSize(12).Bold();
                        var netChange = _summary.PaymentsReceived - _summary.ChecksWritten;
                        row.ConstantItem(120).AlignRight().Text(netChange.ToString("C2")).FontSize(12).Bold()
                            .FontColor(netChange >= 0 ? "#008800" : "#cc0000");
                    });
                });
            });

            column.Item().PaddingTop(20);

            // Amounts Due Section
            column.Item().Border(1).BorderColor(ReportStyles.BorderColor).Column(section =>
            {
                section.Item().Background(ReportStyles.SecondaryColor).Padding(10)
                    .Text("Amounts Due").FontSize(14).Bold().FontColor("#ffffff");

                section.Item().Padding(15).Column(content =>
                {
                    content.Item().Row(row =>
                    {
                        row.RelativeItem().Text("Deposits Due:").FontSize(12);
                        row.ConstantItem(120).AlignRight().Text(_summary.DepositsDue.ToString("C2")).FontSize(12);
                    });

                    content.Item().PaddingTop(10).Row(row =>
                    {
                        row.RelativeItem().Text("Prepayments Due:").FontSize(12);
                        row.ConstantItem(120).AlignRight().Text(_summary.PrepaymentsDue.ToString("C2")).FontSize(12);
                    });

                    content.Item().PaddingTop(10).LineHorizontal(1).LineColor(ReportStyles.BorderColor);

                    content.Item().PaddingTop(10).Row(row =>
                    {
                        row.RelativeItem().Text("Total Due:").FontSize(12).Bold();
                        row.ConstantItem(120).AlignRight().Text(_summary.TotalDue.ToString("C2")).FontSize(12).Bold();
                    });
                });
            });

            column.Item().PaddingTop(20);

            // Trust Balance Summary
            column.Item().Border(2).BorderColor(ReportStyles.PrimaryColor).Background(ReportStyles.LightGray).Padding(15).Column(summary =>
            {
                summary.Item().Text("Trust Account Summary").FontSize(14).Bold().FontColor(ReportStyles.PrimaryColor);
                summary.Item().PaddingTop(10);

                summary.Item().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("Period Net Change:").FontSize(11);
                        col.Item().PaddingTop(5).Text("Total Amounts Due:").FontSize(11);
                    });
                    row.ConstantItem(120).Column(col =>
                    {
                        var netChange = _summary.PaymentsReceived - _summary.ChecksWritten;
                        col.Item().AlignRight().Text(netChange.ToString("C2")).FontSize(11)
                            .FontColor(netChange >= 0 ? "#008800" : "#cc0000");
                        col.Item().PaddingTop(5).AlignRight().Text(_summary.TotalDue.ToString("C2")).FontSize(11);
                    });
                });
            });
        });
    }
}

/// <summary>
/// Data transfer object for client trust summary.
/// </summary>
public class ClientTrustSummary
{
    public decimal PaymentsReceived { get; set; }
    public decimal ChecksWritten { get; set; }
    public decimal DepositsDue { get; set; }
    public decimal PrepaymentsDue { get; set; }
    public decimal TotalDue => DepositsDue + PrepaymentsDue;
}
