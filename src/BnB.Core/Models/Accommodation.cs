using System.ComponentModel.DataAnnotations.Schema;

namespace BnB.Core.Models;

/// <summary>
/// Accommodation/Reservation record - maps to bbtbl in legacy database
/// </summary>
public class Accommodation
{
    public int Id { get; set; }
    public long ConfirmationNumber { get; set; }  // conf - the reservation/booking number
    public int GuestId { get; set; }  // Foreign key to Guest.Id (required - every accommodation must have a guest)
    public int PropertyAccountNumber { get; set; }  // accountnum

    // Denormalized guest/property info (from legacy)
    public string? FirstName { get; set; }  // f_name
    public string? LastName { get; set; }  // l_name
    public string? Location { get; set; }  // location (property name)

    // Dates and duration
    public DateTime ArrivalDate { get; set; }  // arrdate
    public DateTime DepartureDate { get; set; }  // depdate
    public int NumberOfNights { get; set; }  // NumNites
    public int NumberInParty { get; set; }  // numpty

    [NotMapped]
    public DateTime? BookedDate => Guest?.DateBooked;  // From Guest record

    // Room info
    public string? UnitName { get; set; }  // UnitName (room type code)
    public string? UnitNameDescription { get; set; }  // UnitNameDesc

    // Rates and amounts
    public decimal? DailyGrossRate { get; set; }  // grosrate
    public decimal? DailyNetRate { get; set; }  // netrate
    public decimal? TotalGrossWithTax { get; set; }  // gwtax
    public decimal? TotalNetWithTax { get; set; }  // nwtax
    public decimal? TotalTax { get; set; }  // tax
    public decimal? Tax1 { get; set; }  // tax1
    public decimal? Tax2 { get; set; }  // tax2
    public decimal? Tax3 { get; set; }  // tax3
    public decimal? ServiceFee { get; set; }  // svcharge

    // Billing totals (not mapped - computed values)
    [NotMapped]
    public decimal? TotalCharges { get; set; }
    [NotMapped]
    public decimal? TotalPaid { get; set; }
    [NotMapped]
    public decimal? BalanceDue { get; set; }
    [NotMapped]
    public decimal? RefundOwed { get; set; }

    // Commission tracking
    public decimal Commission { get; set; }  // commish (commission due from host)
    public decimal? CommissionPaid { get; set; }  // comm_paid
    public decimal? CommissionReceived { get; set; }  // com_rcvd

    // Payment and billing
    public string PaymentType { get; set; } = "Prepay";  // pymttype
    public decimal? OverridePercentToHost { get; set; }  // percnt
    public string? OverrideTaxPlanCode { get; set; }  // tax_plan_code
    public bool UseManualAmounts { get; set; }  // FillinCalcAmounts

    // Status
    [NotMapped]
    public string? Status { get; set; }  // Not in database
    public bool Suppress { get; set; }  // suppress
    public bool Notified { get; set; }  // Notified
    public bool Forfeit { get; set; }  // Forfeit

    // Notes
    public string? Comments { get; set; }  // cmmnts
    public string? NightNotes { get; set; }  // nnotes
    [NotMapped]
    public string? SpecialRequests { get; set; }  // Not in database

    // Audit fields
    public DateTime? EntryDate { get; set; }
    public string? EntryUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdateUser { get; set; }
    public DateTime? RevisionDate { get; set; }  // rev_date

    // Navigation properties
    public virtual Guest Guest { get; set; } = null!;
    public virtual Property Property { get; set; } = null!;
}
