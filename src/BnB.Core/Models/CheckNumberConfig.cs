namespace BnB.Core.Models;

/// <summary>
/// Configuration for check numbering sequences.
/// Migrated from CheckNum table (CHECKNUM.FRM).
/// Manages check number sequences for Host, Travel, and Miscellaneous categories.
/// </summary>
public class CheckNumberConfig
{
    public int Id { get; set; }

    /// <summary>
    /// Next check number to be printed for Host payments.
    /// </summary>
    public int HostCheckNum { get; set; }

    /// <summary>
    /// Next check number to be printed for Travel agency payments.
    /// </summary>
    public int TravelCheckNum { get; set; }

    /// <summary>
    /// Next check number to be printed for Miscellaneous payments.
    /// </summary>
    public int MiscCheckNum { get; set; }

    /// <summary>
    /// Shared accounts configuration:
    /// 0 = None (all on separate sequences)
    /// 1 = Travel and Miscellaneous share sequence
    /// 2 = Host and Miscellaneous share sequence
    /// 3 = Host and Travel share sequence
    /// 4 = All share the same sequence
    /// </summary>
    public int SharedAccounts { get; set; }
}
