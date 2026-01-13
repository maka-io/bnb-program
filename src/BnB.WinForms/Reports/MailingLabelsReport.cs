using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Mailing Labels Report - prints address labels on standard label stock
/// Migrated from Label1.rpt and Label2.rpt
/// Supports Avery 5160 (30 labels per sheet - 3 columns x 10 rows)
/// Label size: 1" x 2-5/8" (2.625 inches)
/// </summary>
public class MailingLabelsReport : BaseReport
{
    private readonly IEnumerable<LabelData> _labels;
    private readonly LabelFormat _format;

    // Avery 5160 dimensions (in points, 72 points per inch)
    private const int ColumnsPerPage = 3;
    private const int RowsPerPage = 10;
    private const float LabelWidth = 189;   // 2.625 inches
    private const float LabelHeight = 72;   // 1 inch
    private const float HorizontalGap = 9;  // ~0.125 inch gap between columns
    private const float VerticalGap = 0;    // No vertical gap for 5160
    private const float TopMargin = 36;     // 0.5 inch top margin
    private const float LeftMargin = 13.5f; // ~0.1875 inch left margin

    public override string Title => "Mailing Labels";

    public MailingLabelsReport(IEnumerable<LabelData> labels, LabelFormat format = LabelFormat.Avery5160)
    {
        _labels = labels.ToList();
        _format = format;
    }

    /// <summary>
    /// Create labels from a list of guests
    /// </summary>
    public static MailingLabelsReport FromGuests(IEnumerable<Guest> guests)
    {
        var labels = guests.Select(g => new LabelData
        {
            Name = $"{g.FirstName} {g.LastName}".Trim(),
            Address = g.Address ?? g.BusinessAddress,
            City = g.City,
            State = g.State,
            ZipCode = g.ZipCode
        }).Where(l => !string.IsNullOrEmpty(l.Name) && HasAddress(l));

        return new MailingLabelsReport(labels);
    }

    /// <summary>
    /// Create labels from a list of properties (using mailing address)
    /// </summary>
    public static MailingLabelsReport FromProperties(IEnumerable<Property> properties, bool useMailingAddress = true)
    {
        var labels = properties.Select(p =>
        {
            if (useMailingAddress && !string.IsNullOrEmpty(p.MailingAddress))
            {
                return new LabelData
                {
                    Name = p.Location,
                    Address = p.MailingAddress,
                    City = p.MailingCity,
                    State = p.MailingState,
                    ZipCode = p.MailingZipCode
                };
            }
            return new LabelData
            {
                Name = p.Location,
                Address = p.PropertyAddress,
                City = p.PropertyCity,
                State = p.PropertyState,
                ZipCode = p.PropertyZipCode
            };
        }).Where(l => !string.IsNullOrEmpty(l.Name) && HasAddress(l));

        return new MailingLabelsReport(labels);
    }

    private static bool HasAddress(LabelData label)
    {
        return !string.IsNullOrEmpty(label.Address) ||
               !string.IsNullOrEmpty(label.City) ||
               !string.IsNullOrEmpty(label.State);
    }

    public override void Compose(IDocumentContainer container)
    {
        var labelList = _labels.ToList();
        var labelsPerPage = ColumnsPerPage * RowsPerPage;
        var totalPages = (int)Math.Ceiling((double)labelList.Count / labelsPerPage);

        for (int pageIndex = 0; pageIndex < Math.Max(1, totalPages); pageIndex++)
        {
            var pageLabels = labelList
                .Skip(pageIndex * labelsPerPage)
                .Take(labelsPerPage)
                .ToList();

            container.Page(page =>
            {
                page.Size(PageSizes.Letter);
                page.MarginTop(TopMargin);
                page.MarginLeft(LeftMargin);
                page.MarginRight(0);
                page.MarginBottom(0);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                page.Content().Element(c => ComposeLabelsGrid(c, pageLabels));
            });
        }
    }

    private void ComposeLabelsGrid(IContainer container, List<LabelData> labels)
    {
        container.Column(column =>
        {
            for (int row = 0; row < RowsPerPage; row++)
            {
                column.Item().Height(LabelHeight + VerticalGap).Row(rowContainer =>
                {
                    for (int col = 0; col < ColumnsPerPage; col++)
                    {
                        var labelIndex = row * ColumnsPerPage + col;

                        rowContainer.ConstantItem(LabelWidth).Element(cell =>
                        {
                            if (labelIndex < labels.Count)
                            {
                                ComposeLabel(cell, labels[labelIndex]);
                            }
                        });

                        if (col < ColumnsPerPage - 1)
                        {
                            rowContainer.ConstantItem(HorizontalGap);
                        }
                    }
                });
            }
        });
    }

    private void ComposeLabel(IContainer container, LabelData label)
    {
        container.PaddingVertical(5).PaddingHorizontal(8).Column(column =>
        {
            // Name
            if (!string.IsNullOrEmpty(label.Name))
            {
                column.Item().Text(label.Name).FontSize(10).Bold();
            }

            // Company (if different from name)
            if (!string.IsNullOrEmpty(label.Company) && label.Company != label.Name)
            {
                column.Item().Text(label.Company).FontSize(9);
            }

            // Address line 1
            if (!string.IsNullOrEmpty(label.Address))
            {
                column.Item().Text(label.Address).FontSize(9);
            }

            // Address line 2
            if (!string.IsNullOrEmpty(label.Address2))
            {
                column.Item().Text(label.Address2).FontSize(9);
            }

            // City, State ZIP
            var cityStateZip = FormatCityStateZip(label.City, label.State, label.ZipCode);
            if (!string.IsNullOrEmpty(cityStateZip))
            {
                column.Item().Text(cityStateZip).FontSize(9);
            }

            // Country (if specified)
            if (!string.IsNullOrEmpty(label.Country) && label.Country.ToUpper() != "USA" && label.Country.ToUpper() != "US")
            {
                column.Item().Text(label.Country.ToUpper()).FontSize(9);
            }
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

/// <summary>
/// Data structure for a single mailing label
/// </summary>
public class LabelData
{
    public string? Name { get; set; }
    public string? Company { get; set; }
    public string? Address { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
}

/// <summary>
/// Supported label formats
/// </summary>
public enum LabelFormat
{
    /// <summary>Avery 5160 - 30 labels per sheet (3x10), 1" x 2-5/8"</summary>
    Avery5160,

    /// <summary>Avery 5163 - 10 labels per sheet (2x5), 2" x 4"</summary>
    Avery5163,

    /// <summary>Avery 5164 - 6 labels per sheet (2x3), 3-1/3" x 4"</summary>
    Avery5164
}
