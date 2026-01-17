using System.ComponentModel.DataAnnotations.Schema;

namespace BnB.Core.Models;

/// <summary>
/// Payment record - maps to paymentreceived table in legacy database
/// </summary>
public class Payment
{
    public int Id { get; set; }
    public int GuestId { get; set; }  // Foreign key to Guest.Id
    public long ConfirmationNumber { get; set; }  // conf - the booking/reservation number

    // Denormalized guest info
    public string? FirstName { get; set; }  // f_name
    public string? LastName { get; set; }  // l_name

    // Payment details
    public decimal Amount { get; set; }  // AmountReceived
    public DateTime PaymentDate { get; set; }  // DateReceived
    [NotMapped]
    public string? PaymentMethod { get; set; }  // Not in database
    public string? CheckNumber { get; set; }  // CheckNumber
    public string? ReceivedFrom { get; set; }  // ReceivedFrom
    public string? AppliedTo { get; set; }  // AppliedTo
    [NotMapped]
    public string? Notes { get; set; }  // Not in database

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

    public string? Comments { get; set; }

    // Calculated property for outstanding balance
    // Note: CancellationFee is NOT included - it's only owed if guest actually cancels
    [NotMapped]
    public decimal Balance => (DepositDue ?? 0) + (PrepaymentDue ?? 0) - Amount;

    // Navigation properties
    public virtual Guest Guest { get; set; } = null!;
}
