namespace BnB.Core.Models;

/// <summary>
/// Payment record - maps to paymentreceived table in legacy database
/// </summary>
public class Payment
{
    public int PaymentId { get; set; }
    public long ConfirmationNumber { get; set; }  // conf
    public int? AccommodationId { get; set; }

    // Denormalized guest info
    public string? FirstName { get; set; }  // f_name
    public string? LastName { get; set; }  // l_name

    // Payment details
    public decimal Amount { get; set; }  // AmountReceived
    public DateTime PaymentDate { get; set; }  // DateReceived
    public string? PaymentMethod { get; set; }  // Cash, Check, Credit Card
    public string? CheckNumber { get; set; }  // CheckNumber
    public string? ReceivedFrom { get; set; }  // ReceivedFrom
    public string? AppliedTo { get; set; }  // AppliedTo
    public string? Notes { get; set; }

    // Payment due tracking
    public decimal? DepositDue { get; set; }  // depdue
    public DateTime? DepositDueDate { get; set; }  // depdate
    public decimal? PrepaymentDue { get; set; }  // predue
    public DateTime? PrepaymentDueDate { get; set; }  // predate

    // Cancellation
    public decimal? CancellationFee { get; set; }  // canclfee
    public DateTime? CancellationFeeDueDate { get; set; }  // canclfeedatedue

    // Other amounts
    public decimal? RefundOwed { get; set; }  // RefundOwed
    public decimal? OtherCredit { get; set; }  // OtherCredit
    public decimal? DefaultCommission { get; set; }  // defcom

    public string? Comments { get; set; }  // Comments + cmmnts

    // Navigation properties
    public virtual Guest Guest { get; set; } = null!;
    public virtual Accommodation? Accommodation { get; set; }
}
