using System.ComponentModel.DataAnnotations.Schema;

namespace BnB.Core.Models;

/// <summary>
/// Check record - maps to checktbl table in legacy database
/// Tracks checks written to hosts for accommodations
/// </summary>
public class Check
{
    public int Id { get; set; }
    public int AccommodationId { get; set; }  // Accom_RowId
    public long ConfirmationNumber { get; set; }  // Conf_Num
    public string CheckNumber { get; set; } = string.Empty;  // checknum

    public decimal Amount { get; set; }
    public DateTime? CheckDate { get; set; }
    public string? PayableTo { get; set; }  // PayableTo
    public string? Memo { get; set; }

    /// <summary>Check category: Host, Travel, Miscellaneous</summary>
    public string? Category { get; set; }

    /// <summary>Whether this check has been voided</summary>
    public bool IsVoid { get; set; }  // void_chk

    /// <summary>Whether this check has been printed</summary>
    [NotMapped]
    public bool IsPrinted { get; set; }  // Not in database

    /// <summary>Date the check was printed</summary>
    [NotMapped]
    public DateTime? PrintedDate { get; set; }  // Not in database

    public string? Comments { get; set; }

    // Navigation properties
    public virtual Accommodation Accommodation { get; set; } = null!;
}
