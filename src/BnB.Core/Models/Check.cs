namespace BnB.Core.Models;

/// <summary>
/// Check record - maps to checktbl table in legacy database
/// Tracks checks written to hosts for accommodations
/// </summary>
public class Check
{
    public int CheckId { get; set; }
    public int? AccommodationId { get; set; }  // Accom_RowId
    public int? PropertyId { get; set; }
    public string CheckNumber { get; set; } = string.Empty;  // checknum

    public decimal Amount { get; set; }
    public DateTime? CheckDate { get; set; }
    public string? PayTo { get; set; }  // PayableTo
    public string? Memo { get; set; }

    /// <summary>Whether this check has been voided</summary>
    public bool IsVoid { get; set; }  // void_chk

    /// <summary>Whether this check has been printed</summary>
    public bool IsPrinted { get; set; }

    /// <summary>Date the check was printed</summary>
    public DateTime? PrintedDate { get; set; }

    public string? Comments { get; set; }

    // Navigation properties
    public virtual Accommodation? Accommodation { get; set; }
    public virtual Property? Property { get; set; }
}
