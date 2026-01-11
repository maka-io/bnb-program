namespace BnB.Core.Models;

/// <summary>
/// Property/Host information - maps to proptbl in legacy database
/// </summary>
public class Property
{
    public int AccountNumber { get; set; }  // accountnum
    public string Location { get; set; } = string.Empty;  // location (property name)
    public string? FullName { get; set; }  // fullname
    public string? DBA { get; set; }  // dba (doing business as)

    // Property address
    public string? PropertyAddress { get; set; }  // propaddress
    public string? PropertyCity { get; set; }  // propcity
    public string? PropertyState { get; set; }  // propstate
    public string? PropertyZipCode { get; set; }  // propzipcode
    public string? PropertyPhone { get; set; }  // propphone
    public string? PropertyFax { get; set; }  // propfax

    // Mailing address
    public string? MailingAddress { get; set; }  // mailaddress
    public string? MailingCity { get; set; }  // mailcity
    public string? MailingState { get; set; }  // mailstate
    public string? MailingZipCode { get; set; }  // mailzipcode
    public string? MailingPhone1 { get; set; }  // mailphone1
    public string? MailingPhone2 { get; set; }  // mailphone2
    public string? MailingFax { get; set; }  // mailfax

    // Contact info
    public string? Email { get; set; }  // Email
    public string? WebUrl { get; set; }  // WebURL

    // Financial info
    public string? CheckTo { get; set; }  // check_to
    public decimal PercentToHost { get; set; }  // perdirect
    public decimal? FuturePercent { get; set; }  // futurepercent
    public DateTime? FuturePercentDate { get; set; }  // futuredate
    public decimal? GrossRatePercent { get; set; }  // GrosRatePercent
    public string? FederalTaxId { get; set; }  // federaltaxid

    // Tax and booking settings
    public string? TaxPlanCode { get; set; }  // tax_plan_code
    public string? DepositRequired { get; set; }  // depositreq
    public string? Exceptions { get; set; }  // exceptions
    public string? ExceptionsDescription { get; set; }  // exceptions_desc

    // Status flags
    public bool IsObsolete { get; set; }  // PropObsolete
    public bool SuppressFlag { get; set; }  // suppressflag

    public string? Comments { get; set; }  // comments

    // Navigation properties
    public virtual ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
    public virtual ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();
}
