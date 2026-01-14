using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Base class for all BnB reports providing common functionality
/// </summary>
public abstract class BaseReport : IReport, IDocument
{
    protected const float DefaultMargin = 36; // 0.5 inch
    protected const float HeaderFontSize = 14;
    protected const float SubHeaderFontSize = 11;
    protected const float BodyFontSize = 10;
    protected const float SmallFontSize = 8;

    public abstract string Title { get; }

    protected CompanyInfo? CompanyInfo { get; set; }
    protected DateTime ReportDate { get; set; } = DateTime.Now;

    // For backwards compatibility
    protected string CompanyName => CompanyInfo?.CompanyName ?? "Hawaii's Best Bed & Breakfasts";

    public IDocument CreateDocument() => this;

    public byte[] GeneratePdf()
    {
        return Document.Create(Compose).GeneratePdf();
    }

    public void SaveToFile(string filePath)
    {
        Document.Create(Compose).GeneratePdf(filePath);
    }

    public DocumentMetadata GetMetadata() => new()
    {
        Title = Title,
        Author = CompanyName,
        Creator = "BnB Reservation System",
        Producer = "QuestPDF",
        CreationDate = ReportDate
    };

    public DocumentSettings GetSettings() => DocumentSettings.Default;

    public abstract void Compose(IDocumentContainer container);

    /// <summary>
    /// Compose standard report header with company logo, info, and report title
    /// </summary>
    protected void ComposeHeader(IContainer container)
    {
        container.Row(row =>
        {
            // Logo on the left (if available)
            if (CompanyInfo?.Logo != null && CompanyInfo.Logo.Length > 0)
            {
                row.ConstantItem(80).Height(60).Image(CompanyInfo.Logo, ImageScaling.FitArea);
                row.ConstantItem(15); // Spacing
            }

            // Company info and report title
            row.RelativeItem().Column(column =>
            {
                // Company name
                column.Item().Text(CompanyName)
                    .FontSize(HeaderFontSize)
                    .Bold();

                // Address line (if available)
                if (CompanyInfo != null && !string.IsNullOrWhiteSpace(CompanyInfo.Address))
                {
                    var addressParts = new List<string>();
                    if (!string.IsNullOrWhiteSpace(CompanyInfo.Address))
                        addressParts.Add(CompanyInfo.Address);

                    var cityStateZip = FormatCityStateZip(CompanyInfo.City, CompanyInfo.State, CompanyInfo.ZipCode);
                    if (!string.IsNullOrWhiteSpace(cityStateZip))
                        addressParts.Add(cityStateZip);

                    if (addressParts.Count > 0)
                    {
                        column.Item().Text(string.Join(" | ", addressParts))
                            .FontSize(SmallFontSize);
                    }
                }

                // Contact info (if available)
                if (CompanyInfo != null)
                {
                    var contactParts = new List<string>();
                    if (!string.IsNullOrWhiteSpace(CompanyInfo.Phone))
                        contactParts.Add($"Phone: {CompanyInfo.Phone}");
                    if (!string.IsNullOrWhiteSpace(CompanyInfo.Email))
                        contactParts.Add(CompanyInfo.Email);
                    if (!string.IsNullOrWhiteSpace(CompanyInfo.WebUrl))
                        contactParts.Add(CompanyInfo.WebUrl);

                    if (contactParts.Count > 0)
                    {
                        column.Item().Text(string.Join(" | ", contactParts))
                            .FontSize(SmallFontSize);
                    }
                }

                column.Item().PaddingTop(5).Text(Title)
                    .FontSize(SubHeaderFontSize)
                    .SemiBold();

                column.Item().Text($"Generated: {ReportDate:MM/dd/yyyy hh:mm tt}")
                    .FontSize(SmallFontSize)
                    .Italic();
            });
        });
    }

    /// <summary>
    /// Compose standard page footer with page numbers
    /// </summary>
    protected void ComposeFooter(IContainer container)
    {
        container.AlignCenter().Text(text =>
        {
            text.Span("Page ");
            text.CurrentPageNumber();
            text.Span(" of ");
            text.TotalPages();
        });
    }

    /// <summary>
    /// Format city, state, zip into a single line
    /// </summary>
    private static string FormatCityStateZip(string? city, string? state, string? zip)
    {
        var parts = new List<string>();

        if (!string.IsNullOrWhiteSpace(city))
            parts.Add(city);

        if (!string.IsNullOrWhiteSpace(state))
        {
            if (parts.Count > 0)
                parts[parts.Count - 1] += ",";
            parts.Add(state);
        }

        if (!string.IsNullOrWhiteSpace(zip))
            parts.Add(zip);

        return string.Join(" ", parts);
    }

    /// <summary>
    /// Format currency value
    /// </summary>
    protected static string FormatCurrency(decimal? value)
    {
        return value.HasValue ? value.Value.ToString("C2") : "";
    }

    /// <summary>
    /// Format date value
    /// </summary>
    protected static string FormatDate(DateTime? value, string format = "MM/dd/yyyy")
    {
        return value?.ToString(format) ?? "";
    }

    /// <summary>
    /// Format nullable string
    /// </summary>
    protected static string SafeString(string? value)
    {
        return value ?? "";
    }
}
