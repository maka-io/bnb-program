namespace BnB.Core.Models;

/// <summary>
/// Junction table for Property-Fact many-to-many relationship
/// </summary>
public class PropertyFact
{
    public int PropertyFactId { get; set; }
    public int PropertyId { get; set; }
    public int FactId { get; set; }

    // Navigation properties
    public virtual Property Property { get; set; } = null!;
    public virtual Fact Fact { get; set; } = null!;
}
