namespace BnB.Core.Models;

/// <summary>
/// Property/Host information - maps to proptbl in legacy database
/// </summary>
public class Property
{
    public int AccountNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ContactName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }

    /// <summary>Percentage paid to host (perdirect in legacy)</summary>
    public decimal PercentToHost { get; set; }

    /// <summary>Future percentage (if rate change scheduled)</summary>
    public decimal? FuturePercent { get; set; }

    /// <summary>Effective date for future percentage</summary>
    public DateTime? FuturePercentDate { get; set; }

    /// <summary>Tax plan code for this property</summary>
    public string? TaxPlanCode { get; set; }

    public string? Comments { get; set; }

    // Navigation properties
    public virtual ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
    public virtual ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();
}
