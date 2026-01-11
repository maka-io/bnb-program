namespace BnB.Core.Models;

/// <summary>
/// Accommodation/Reservation record - maps to accommodations table
/// </summary>
public class Accommodation
{
    public int Id { get; set; }
    public long ConfirmationNumber { get; set; }
    public int PropertyAccountNumber { get; set; }

    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public int NumberOfNights { get; set; }

    /// <summary>Daily gross rate</summary>
    public decimal DailyGrossRate { get; set; }

    /// <summary>Daily net rate (paid to host)</summary>
    public decimal DailyNetRate { get; set; }

    /// <summary>Total gross with tax</summary>
    public decimal TotalGrossWithTax { get; set; }

    /// <summary>Total net with tax</summary>
    public decimal TotalNetWithTax { get; set; }

    /// <summary>Total tax amount</summary>
    public decimal TotalTax { get; set; }

    /// <summary>Tax 1 amount</summary>
    public decimal Tax1 { get; set; }

    /// <summary>Tax 2 amount</summary>
    public decimal Tax2 { get; set; }

    /// <summary>Tax 3 amount</summary>
    public decimal Tax3 { get; set; }

    /// <summary>Service fee (BnB's commission)</summary>
    public decimal ServiceFee { get; set; }

    /// <summary>Payment type: Prepay, Direct, Comp</summary>
    public string PaymentType { get; set; } = "Prepay";

    /// <summary>Override percentage to host (null = use property default)</summary>
    public decimal? OverridePercentToHost { get; set; }

    /// <summary>Override tax plan code (null = use property default)</summary>
    public string? OverrideTaxPlanCode { get; set; }

    /// <summary>Manual calculation override flag</summary>
    public bool UseManualAmounts { get; set; }

    public string? RoomType { get; set; }
    public string? Comments { get; set; }

    // Navigation properties
    public virtual Guest Guest { get; set; } = null!;
    public virtual Property Property { get; set; } = null!;
}
