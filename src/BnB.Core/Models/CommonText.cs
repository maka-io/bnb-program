namespace BnB.Core.Models;

/// <summary>
/// Common text snippets that can be inserted into various forms and reports.
/// Migrated from commontext table (COMMTEXT.FRM).
/// </summary>
public class CommonText
{
    public int Id { get; set; }

    /// <summary>
    /// Title/name of the common text snippet for selection.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The actual text content to be inserted.
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Date the text was created.
    /// </summary>
    public DateTime? CreatedDate { get; set; }

    /// <summary>
    /// Date the text was last modified.
    /// </summary>
    public DateTime? ModifiedDate { get; set; }
}
