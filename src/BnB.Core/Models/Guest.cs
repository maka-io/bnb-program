namespace BnB.Core.Models;

/// <summary>
/// Guest information - maps to guesttbl in legacy database
/// </summary>
public class Guest
{
    public int Id { get; set; }  // Auto-increment primary key
    public string FirstName { get; set; } = string.Empty;  // f_name
    public string LastName { get; set; } = string.Empty;  // l_name

    // Address info
    public string? Address { get; set; }  // address
    public string? BusinessAddress { get; set; }  // busadd
    public string? City { get; set; }  // city
    public string? State { get; set; }  // state
    public string? ZipCode { get; set; }  // zipcode
    public string? Country { get; set; }

    // Contact info
    public string? HomePhone { get; set; }  // hmphone
    public string? BusinessPhone { get; set; }  // bsphone
    public string? FaxNumber { get; set; }  // faxnum
    public string? Email { get; set; }  // Email

    // Booking info (DateBooked moved to Accommodation.EntryDate - each booking has its own date)
    // ReservationFee moved to Accommodation - each booking has its own fee
    public string? BookedBy { get; set; }  // bookedby
    public string? Referral { get; set; }  // referral
    public string? TravelingWith { get; set; }  // travwith
    public string? Comments { get; set; }  // cmmnts

    // Status flags
    public bool LabelFlag { get; set; }  // lbl_flag
    public string? Closure { get; set; }  // closeure

    // Audit fields
    public DateTime? EntryDate { get; set; }  // EntryDate
    public string? EntryUser { get; set; }  // EntryUser
    public DateTime? UpdateDate { get; set; }  // UpdateDate
    public string? UpdateUser { get; set; }  // UpdateUser
    public DateTime? RevisionDate { get; set; }  // revdate
    public int? Revision { get; set; }  // revision

    // Navigation properties
    public virtual ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
