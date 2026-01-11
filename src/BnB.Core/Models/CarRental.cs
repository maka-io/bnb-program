namespace BnB.Core.Models;

/// <summary>
/// Car rental agency master record - maps to carmaster table in legacy database
/// </summary>
public class CarAgency
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
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
    public virtual ICollection<CarRental> Rentals { get; set; } = new List<CarRental>();
}

/// <summary>
/// Car rental booking record - maps to cartbl table in legacy database
/// Links a guest reservation to a car rental
/// </summary>
public class CarRental
{
    public int Id { get; set; }
    public long ConfirmationNumber { get; set; }  // conf
    public int? CarAgencyId { get; set; }

    // Rental info
    public DateTime? PickupDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? CarType { get; set; }
    public decimal? DailyRate { get; set; }
    public decimal? TotalAmount { get; set; }

    // Commission info
    public decimal? CommissionAmount { get; set; }
    public decimal? CommissionPaid { get; set; }
    public DateTime? CommissionPaidDate { get; set; }
    public string? CheckNumber { get; set; }

    public string? Comments { get; set; }

    // Navigation properties
    public virtual Guest Guest { get; set; } = null!;
    public virtual CarAgency? CarAgency { get; set; }
}
