using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Account List Report - lists all host properties with contact information
/// Migrated from AcctList.rpt
/// </summary>
public class AccountListReport : BaseReport
{
    private readonly IEnumerable<Property> _properties;
    private readonly bool _includeInactive;
    private readonly string? _filterArea;

    public override string Title => "Host Account List";

    public AccountListReport(
        IEnumerable<Property> properties,
        bool includeInactive = false,
        string? filterArea = null,
        CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _properties = properties.ToList();
        _includeInactive = includeInactive;
        _filterArea = filterArea;
    }

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
        var propertyList = _properties
            .OrderBy(p => p.Location)
            .ToList();

        container.Column(column =>
        {
            // Summary info
            column.Item().PaddingBottom(10).Row(row =>
            {
                row.RelativeItem().Text($"Total Properties: {propertyList.Count}")
                    .FontSize(11).SemiBold();

                if (!string.IsNullOrEmpty(_filterArea))
                {
                    row.RelativeItem().AlignRight().Text($"Area: {_filterArea}")
                        .FontSize(10);
                }
            });

            if (!propertyList.Any())
            {
                column.Item().Text("No properties found.")
                    .FontSize(11).Italic();
                return;
            }

            // Main property table
            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(50);   // Account #
                    columns.RelativeColumn(1.5f);  // Location/Name
                    columns.RelativeColumn(1.5f);  // Mailing Address
                    columns.RelativeColumn(1);    // City/State/Zip
                    columns.ConstantColumn(100);  // Phone
                    columns.ConstantColumn(80);   // Fax
                    columns.RelativeColumn(1.2f);  // Email
                    columns.ConstantColumn(50);   // % to Host
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Acct #").TableHeaderText();
                    header.Cell().TableHeader().Text("Property Name").TableHeaderText();
                    header.Cell().TableHeader().Text("Mailing Address").TableHeaderText();
                    header.Cell().TableHeader().Text("City/State/Zip").TableHeaderText();
                    header.Cell().TableHeader().Text("Phone").TableHeaderText();
                    header.Cell().TableHeader().Text("Fax").TableHeaderText();
                    header.Cell().TableHeader().Text("Email").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("% Host").TableHeaderText();
                });

                bool alternate = false;
                foreach (var prop in propertyList)
                {
                    var cityStateZip = FormatCityStateZip(
                        prop.MailingCity ?? prop.PropertyCity,
                        prop.MailingState ?? prop.PropertyState,
                        prop.MailingZipCode ?? prop.PropertyZipCode);

                    var address = prop.MailingAddress ?? prop.PropertyAddress ?? "";

                    table.Cell().TableCell(alternate).Text(prop.AccountNumber.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(prop.Location)).TableCellText();
                    table.Cell().TableCell(alternate).Text(address).TableCellText();
                    table.Cell().TableCell(alternate).Text(cityStateZip).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(prop.MailingPhone1 ?? prop.PropertyPhone)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(prop.MailingFax ?? prop.PropertyFax)).TableCellText();
                    table.Cell().TableCell(alternate).Text(SafeString(prop.Email)).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter()
                        .Text(prop.PercentToHost.ToString("F1")).TableCellText();

                    alternate = !alternate;
                }
            });

            // Summary by area if applicable
            column.Item().PaddingTop(20).Element(ComposeSummaryByArea);
        });
    }

    private void ComposeSummaryByArea(IContainer container)
    {
        var propertyList = _properties.ToList();
        if (!propertyList.Any()) return;

        // Group by area (using property state or a custom area field if available)
        var byArea = propertyList
            .GroupBy(p => p.PropertyState ?? "Unknown")
            .OrderBy(g => g.Key)
            .ToList();

        if (byArea.Count <= 1) return; // No need for summary if only one area

        container.Column(column =>
        {
            column.Item().Text("Summary by Area").FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().PaddingTop(5);

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2);
                    columns.ConstantColumn(100);
                    columns.ConstantColumn(120);
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Area/State").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("# Properties").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Avg % to Host").TableHeaderText();
                });

                bool alternate = false;
                foreach (var group in byArea)
                {
                    var avgPercent = group
                        .Select(p => p.PercentToHost)
                        .DefaultIfEmpty(0)
                        .Average();

                    table.Cell().TableCell(alternate).Text(group.Key).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(group.Count().ToString()).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text($"{avgPercent:F1}%").TableCellText();
                    alternate = !alternate;
                }

                // Totals row
                var totalAvg = propertyList
                    .Select(p => p.PercentToHost)
                    .DefaultIfEmpty(0)
                    .Average();

                table.Cell().TotalsRow().Text("TOTAL").Bold();
                table.Cell().TotalsRow().AlignCenter().Text(propertyList.Count.ToString()).Bold();
                table.Cell().TotalsRow().AlignCenter().Text($"{totalAvg:F1}%").Bold();
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
}
