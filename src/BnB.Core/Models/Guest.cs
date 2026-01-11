namespace BnB.Core.Models;

/// <summary>
/// Guest information - maps to guest table in legacy database
/// </summary>
public class Guest
{
    public long ConfirmationNumber { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Comments { get; set; }

    // Navigation properties
    public virtual ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
