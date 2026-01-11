namespace BnB.Core.Models;

/// <summary>
/// Room type for a property
/// </summary>
public class RoomType
{
    public int RoomTypeId { get; set; }
    public int PropertyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal? DefaultRate { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation property
    public virtual Property Property { get; set; } = null!;
}
