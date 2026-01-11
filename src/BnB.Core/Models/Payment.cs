namespace BnB.Core.Models;

/// <summary>
/// Payment record - maps to payment table
/// </summary>
public class Payment
{
    public int Id { get; set; }
    public long ConfirmationNumber { get; set; }

    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string? CheckNumber { get; set; }
    public string? ReceivedFrom { get; set; }
    public string? AppliedTo { get; set; }
    public string? Comments { get; set; }

    // Navigation property
    public virtual Guest Guest { get; set; } = null!;
}
