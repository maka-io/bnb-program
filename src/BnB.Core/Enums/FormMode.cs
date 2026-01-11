namespace BnB.Core.Enums;

/// <summary>
/// Form operation modes - migrated from BNBMODE.BAS
/// Controls the state of forms for data entry operations.
/// </summary>
public enum FormMode
{
    /// <summary>Read-only viewing of records</summary>
    Browse,

    /// <summary>Adding a new record</summary>
    Insert,

    /// <summary>Editing an existing record</summary>
    Update,

    /// <summary>Deleting a record</summary>
    Delete,

    /// <summary>Search/query mode</summary>
    Find,

    /// <summary>No records exist in the dataset</summary>
    NoRows
}
