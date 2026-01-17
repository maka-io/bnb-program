namespace BnB.Core.Models;

/// <summary>
/// Represents a blackout period for a specific room type.
/// Prevents bookings during maintenance, owner use, or other unavailability.
/// </summary>
public class RoomBlackout
{
    public int Id { get; set; }

    /// <summary>
    /// Foreign key to the RoomType being blocked.
    /// </summary>
    public int RoomTypeId { get; set; }

    /// <summary>
    /// Start date of the blackout period (inclusive).
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// End date of the blackout period (inclusive).
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Reason for the blackout (e.g., "Maintenance", "Owner Use", "Renovation").
    /// </summary>
    public string Reason { get; set; } = string.Empty;

    /// <summary>
    /// Date when this blackout was created.
    /// </summary>
    public DateTime? EntryDate { get; set; }

    /// <summary>
    /// User who created this blackout.
    /// </summary>
    public string? EntryUser { get; set; }

    /// <summary>
    /// Navigation property to the associated RoomType.
    /// </summary>
    public virtual RoomType RoomType { get; set; } = null!;

    /// <summary>
    /// Checks if a specific date falls within this blackout period.
    /// </summary>
    public bool ContainsDate(DateTime date) => date >= StartDate && date <= EndDate;
}
