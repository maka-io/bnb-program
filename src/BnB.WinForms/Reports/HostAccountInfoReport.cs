using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Host Account Information Report - lists all host properties with their details.
/// </summary>
public class HostAccountInfoReport : BaseReport
{
    private readonly List<Property> _properties;

    public HostAccountInfoReport(List<Property> properties, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _properties = properties;
    }

    public override string Title => "Host Account Information";

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
            if (_properties.Count == 0)
            {
                column.Item().Text("No properties found.")
                    .FontSize(11).Italic();
                return;
            }

            column.Item().PaddingBottom(10).Text($"Total Properties: {_properties.Count}")
                .FontSize(11).SemiBold();

            foreach (var property in _properties)
            {
                column.Item().PaddingTop(10)
                    .Border(1)
                    .BorderColor(ReportStyles.BorderColor)
                    .Padding(10)
                    .Column(propCol =>
                    {
                        // Header with property name and account number
                        propCol.Item().Row(row =>
                        {
                            row.RelativeItem().Text(SafeString(property.Location))
                                .FontSize(14).Bold().FontColor(ReportStyles.PrimaryColor);
                            row.ConstantItem(100).AlignRight().Text($"Acct# {property.AccountNumber}")
                                .FontSize(10);
                        });

                        propCol.Item().PaddingVertical(5).LineHorizontal(1).LineColor(ReportStyles.BorderColor);

                        // Two-column layout for property details
                        propCol.Item().Row(row =>
                        {
                            // Left column - Property Address
                            row.RelativeItem().Column(leftCol =>
                            {
                                leftCol.Item().Text("Property Address:").Bold().FontSize(9);
                                leftCol.Item().Text(SafeString(property.PropertyAddress)).FontSize(9);
                                leftCol.Item().Text($"{SafeString(property.PropertyCity)}, {SafeString(property.PropertyState)} {SafeString(property.PropertyZipCode)}").FontSize(9);
                                leftCol.Item().Text($"Phone: {SafeString(property.PropertyPhone)}").FontSize(9);
                                leftCol.Item().Text($"Fax: {SafeString(property.PropertyFax)}").FontSize(9);
                            });

                            // Right column - Mailing Address
                            row.RelativeItem().Column(rightCol =>
                            {
                                rightCol.Item().Text("Mailing Address:").Bold().FontSize(9);
                                rightCol.Item().Text(SafeString(property.MailingAddress)).FontSize(9);
                                rightCol.Item().Text($"{SafeString(property.MailingCity)}, {SafeString(property.MailingState)} {SafeString(property.MailingZipCode)}").FontSize(9);
                                rightCol.Item().Text($"Phone: {SafeString(property.MailingPhone1)}").FontSize(9);
                                rightCol.Item().Text($"Fax: {SafeString(property.MailingFax)}").FontSize(9);
                            });
                        });

                        propCol.Item().PaddingTop(5).Row(row =>
                        {
                            row.RelativeItem().Column(leftCol =>
                            {
                                leftCol.Item().Text("Contact Information:").Bold().FontSize(9);
                                leftCol.Item().Text($"Owner/Host: {SafeString(property.FullName)}").FontSize(9);
                                leftCol.Item().Text($"Check To: {SafeString(property.CheckTo)}").FontSize(9);
                                leftCol.Item().Text($"Email: {SafeString(property.Email)}").FontSize(9);
                                leftCol.Item().Text($"Website: {SafeString(property.WebUrl)}").FontSize(9);
                            });

                            row.RelativeItem().Column(rightCol =>
                            {
                                rightCol.Item().Text("Financial Information:").Bold().FontSize(9);
                                rightCol.Item().Text($"% to Host: {property.PercentToHost}%").FontSize(9);
                                rightCol.Item().Text($"Gross Rate %: {property.GrossRatePercent}%").FontSize(9);
                                rightCol.Item().Text($"Tax Plan: {SafeString(property.TaxPlanCode)}").FontSize(9);
                                rightCol.Item().Text($"Federal Tax ID: {SafeString(property.FederalTaxId)}").FontSize(9);
                                if (!string.IsNullOrEmpty(property.DBA))
                                    rightCol.Item().Text($"DBA: {property.DBA}").FontSize(9);
                            });
                        });

                        // Status flags
                        propCol.Item().PaddingTop(5).Row(row =>
                        {
                            if (property.IsObsolete)
                                row.AutoItem().Padding(2).Background("#ffcccc").Text(" OBSOLETE ").FontSize(8);
                            if (property.SuppressFlag)
                                row.AutoItem().Padding(2).Background("#ffffcc").Text(" SUPPRESSED ").FontSize(8);
                            if (!string.IsNullOrEmpty(property.Exceptions))
                                row.AutoItem().Padding(2).Background("#ffeecc").Text(" EXCEPTIONS ").FontSize(8);
                        });

                        // Comments if any
                        if (!string.IsNullOrEmpty(property.Comments))
                        {
                            propCol.Item().PaddingTop(5).Text("Comments:").Bold().FontSize(9);
                            propCol.Item().Text(property.Comments).FontSize(8).Italic();
                        }
                    });
            }
        });
    }
}
