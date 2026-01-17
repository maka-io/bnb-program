using System.ComponentModel.DataAnnotations.Schema;

namespace BnB.Core.Models;

/// <summary>
/// Property/Host information - maps to proptbl in legacy database
/// </summary>
public class Property
{
    public int AccountNumber { get; set; }  // accountnum (primary key)
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
    public string? DepositRequired { get; set; }  // depositreq (legacy text field)
    public string? Exceptions { get; set; }  // exceptions
    public string? ExceptionsDescription { get; set; }  // exceptions_desc

    // Payment Policy - Default Settings
    /// <summary>Deposit percentage (e.g., 50 for 50%)</summary>
    public decimal? DefaultDepositPercent { get; set; }

    /// <summary>Days after booking when deposit is due (e.g., 14 for 2 weeks)</summary>
    public int? DefaultDepositDueDays { get; set; }

    /// <summary>Days before arrival when full prepayment is due (e.g., 45)</summary>
    public int? DefaultPrepaymentDueDays { get; set; }

    /// <summary>Days before arrival required for cancellation notice (e.g., 30)</summary>
    public int? DefaultCancellationNoticeDays { get; set; }

    /// <summary>Percentage of deposit forfeited if cancellation is late (e.g., 100 = forfeit entire deposit)</summary>
    public decimal? DefaultCancellationFeePercent { get; set; }

    /// <summary>Flat processing fee deducted from refund for any cancellation (e.g., $25)</summary>
    public decimal? CancellationProcessingFee { get; set; }

    // Payment Policy - Peak Period Override Settings (e.g., Christmas/Holiday period)
    /// <summary>Whether this property has peak period payment overrides</summary>
    public bool HasPeakPeriodPolicy { get; set; }

    /// <summary>Peak period prepayment due days override (e.g., 60)</summary>
    public int? PeakPeriodPrepaymentDueDays { get; set; }

    /// <summary>Peak period cancellation notice days override (e.g., 60)</summary>
    public int? PeakPeriodCancellationNoticeDays { get; set; }

    /// <summary>Peak period cancellation fee percent override</summary>
    public decimal? PeakPeriodCancellationFeePercent { get; set; }

    /// <summary>Start month of peak period (1-12)</summary>
    public int? PeakPeriodStartMonth { get; set; }

    /// <summary>Start day of peak period (1-31)</summary>
    public int? PeakPeriodStartDay { get; set; }

    /// <summary>End month of peak period (1-12)</summary>
    public int? PeakPeriodEndMonth { get; set; }

    /// <summary>End day of peak period (1-31)</summary>
    public int? PeakPeriodEndDay { get; set; }

    // Status flags
    [NotMapped]
    public bool IsActive { get; set; } = true;  // Not in database
    public bool IsObsolete { get; set; }  // PropObsolete
    public bool SuppressFlag { get; set; }  // suppressflag

    public string? Comments { get; set; }  // comments

    // Navigation properties
    public virtual ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
    public virtual ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();

    /// <summary>
    /// Checks if a given arrival date falls within the peak period.
    /// Handles date ranges that span year boundaries (e.g., Dec 15 - Jan 5).
    /// </summary>
    public bool IsInPeakPeriod(DateTime arrivalDate)
    {
        if (!HasPeakPeriodPolicy ||
            !PeakPeriodStartMonth.HasValue || !PeakPeriodStartDay.HasValue ||
            !PeakPeriodEndMonth.HasValue || !PeakPeriodEndDay.HasValue)
        {
            return false;
        }

        var month = arrivalDate.Month;
        var day = arrivalDate.Day;
        var startMonth = PeakPeriodStartMonth.Value;
        var startDay = PeakPeriodStartDay.Value;
        var endMonth = PeakPeriodEndMonth.Value;
        var endDay = PeakPeriodEndDay.Value;

        // Create comparable date values (month * 100 + day)
        var dateValue = month * 100 + day;
        var startValue = startMonth * 100 + startDay;
        var endValue = endMonth * 100 + endDay;

        if (startValue <= endValue)
        {
            // Normal range (e.g., Jun 1 - Aug 31)
            return dateValue >= startValue && dateValue <= endValue;
        }
        else
        {
            // Range spans year boundary (e.g., Dec 15 - Jan 5)
            return dateValue >= startValue || dateValue <= endValue;
        }
    }

    /// <summary>
    /// Gets the prepayment due days for a given arrival date (uses peak period override if applicable).
    /// </summary>
    public int? GetPrepaymentDueDays(DateTime arrivalDate)
    {
        if (IsInPeakPeriod(arrivalDate) && PeakPeriodPrepaymentDueDays.HasValue)
        {
            return PeakPeriodPrepaymentDueDays;
        }
        return DefaultPrepaymentDueDays;
    }

    /// <summary>
    /// Gets the cancellation notice days for a given arrival date (uses peak period override if applicable).
    /// </summary>
    public int? GetCancellationNoticeDays(DateTime arrivalDate)
    {
        if (IsInPeakPeriod(arrivalDate) && PeakPeriodCancellationNoticeDays.HasValue)
        {
            return PeakPeriodCancellationNoticeDays;
        }
        return DefaultCancellationNoticeDays;
    }

    /// <summary>
    /// Gets the cancellation fee percent for a given arrival date (uses peak period override if applicable).
    /// </summary>
    public decimal? GetCancellationFeePercent(DateTime arrivalDate)
    {
        if (IsInPeakPeriod(arrivalDate) && PeakPeriodCancellationFeePercent.HasValue)
        {
            return PeakPeriodCancellationFeePercent;
        }
        return DefaultCancellationFeePercent;
    }
}
