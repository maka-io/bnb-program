namespace BnB.Core.Models;

/// <summary>
/// Travel agency master record - maps to tamaster table in legacy database
/// </summary>
public class TravelAgency
{
    public int Id { get; set; }
    public int AccountNumber { get; set; }  // accountnum
    public string Name { get; set; } = string.Empty;  // agencyname
    public string? ContactName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }

    /// <summary>Commission percentage for this agency</summary>
    public decimal? CommissionPercent { get; set; }

    public string? Comments { get; set; }

    // Navigation properties
    public virtual ICollection<TravelAgentBooking> Bookings { get; set; } = new List<TravelAgentBooking>();
}

/// <summary>
/// Travel agent booking record - maps to tagentbl table in legacy database
/// Links a guest reservation to a travel agency
/// </summary>
public class TravelAgentBooking
{
    public int Id { get; set; }
    public int GuestId { get; set; }  // Foreign key to Guest.Id
    public long ConfirmationNumber { get; set; }  // conf - booking/reservation number
    public int? TravelAgencyId { get; set; }

    // Commission info
    public decimal? CommissionAmount { get; set; }
    public decimal? CommissionPaid { get; set; }
    public DateTime? CommissionPaidDate { get; set; }
    public string? CheckNumber { get; set; }

    public string? Comments { get; set; }

    // Navigation properties
    public virtual Guest Guest { get; set; } = null!;
    public virtual TravelAgency? TravelAgency { get; set; }
}
