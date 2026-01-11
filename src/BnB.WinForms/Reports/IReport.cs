using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Interface for all BnB reports
/// </summary>
public interface IReport
{
    /// <summary>
    /// Report title displayed in viewer and PDF
    /// </summary>
    string Title { get; }

    /// <summary>
    /// Generate the PDF document
    /// </summary>
    IDocument CreateDocument();

    /// <summary>
    /// Generate PDF bytes
    /// </summary>
    byte[] GeneratePdf();

    /// <summary>
    /// Save PDF to file
    /// </summary>
    void SaveToFile(string filePath);
}
