using System.ComponentModel.DataAnnotations.Schema;

namespace BnB.Core.Models;

/// <summary>
/// Room type for a property
/// </summary>
public class RoomType
{
    public int Id { get; set; }
    public int PropertyAccountNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal? DefaultRate { get; set; }

    [NotMapped]
    public bool IsActive { get; set; } = true;  // Not in database

    // Navigation property
    public virtual Property Property { get; set; } = null!;
}
