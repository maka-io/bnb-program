using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Common styling utilities for reports
/// </summary>
public static class ReportStyles
{
    public static string DefaultFontFamily => "Arial";
    public static string HeaderFontFamily => "Arial";

    // Colors
    public static string PrimaryColor => "#1a5276";
    public static string SecondaryColor => "#5dade2";
    public static string LightGray => "#f5f5f5";
    public static string DarkGray => "#333333";
    public static string BorderColor => "#cccccc";

    /// <summary>
    /// Style for table headers
    /// </summary>
    public static IContainer TableHeader(this IContainer container)
    {
        return container
            .Background(PrimaryColor)
            .Padding(5);
    }

    /// <summary>
    /// Style for table header text
    /// </summary>
    public static TextSpanDescriptor TableHeaderText(this TextSpanDescriptor text)
    {
        return text
            .FontColor("#ffffff")
            .FontSize(10)
            .Bold();
    }

    /// <summary>
    /// Style for table cells
    /// </summary>
    public static IContainer TableCell(this IContainer container, bool alternate = false)
    {
        return container
            .Background(alternate ? LightGray : "#ffffff")
            .BorderBottom(1)
            .BorderColor(BorderColor)
            .Padding(4);
    }

    /// <summary>
    /// Style for table cell text
    /// </summary>
    public static TextSpanDescriptor TableCellText(this TextSpanDescriptor text)
    {
        return text
            .FontSize(9)
            .FontColor(DarkGray);
    }

    /// <summary>
    /// Style for section headers
    /// </summary>
    public static IContainer SectionHeader(this IContainer container)
    {
        return container
            .Background(SecondaryColor)
            .Padding(8);
    }

    /// <summary>
    /// Style for totals row
    /// </summary>
    public static IContainer TotalsRow(this IContainer container)
    {
        return container
            .Background(LightGray)
            .BorderTop(2)
            .BorderColor(PrimaryColor)
            .Padding(5);
    }

    /// <summary>
    /// Style for label text
    /// </summary>
    public static TextSpanDescriptor LabelText(this TextSpanDescriptor text)
    {
        return text
            .FontSize(9)
            .Bold()
            .FontColor(DarkGray);
    }

    /// <summary>
    /// Style for value text
    /// </summary>
    public static TextSpanDescriptor ValueText(this TextSpanDescriptor text)
    {
        return text
            .FontSize(9)
            .FontColor(DarkGray);
    }

    /// <summary>
    /// Style for currency values (right-aligned)
    /// </summary>
    public static IContainer CurrencyCell(this IContainer container, bool alternate = false)
    {
        return container.TableCell(alternate).AlignRight();
    }
}
