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
    protected const float HeaderFontSize = 16;
    protected const float SubHeaderFontSize = 12;
    protected const float BodyFontSize = 10;
    protected const float SmallFontSize = 8;

    public abstract string Title { get; }

    protected string CompanyName { get; set; } = "Hawaii's Best Bed & Breakfasts";
    protected DateTime ReportDate { get; set; } = DateTime.Now;

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
    /// Compose standard report header with company name and report title
    /// </summary>
    protected void ComposeHeader(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text(CompanyName)
                    .FontSize(HeaderFontSize)
                    .Bold();

                column.Item().Text(Title)
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
