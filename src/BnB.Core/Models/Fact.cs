namespace BnB.Core.Models;

/// <summary>
/// Represents a property fact/feature (e.g., "Ocean View", "Pool", "Hot Tub")
/// </summary>
public class Fact
{
    public int FactId { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual ICollection<PropertyFact> PropertyFacts { get; set; } = new List<PropertyFact>();
}
