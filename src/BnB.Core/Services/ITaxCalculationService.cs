namespace BnB.Core.Services;

/// <summary>
/// Defines the contract for tax calculation operations.
/// </summary>
public interface ITaxCalculationService
{
    /// <summary>
    /// Calculates all tax-related amounts for an accommodation booking.
    /// </summary>
    /// <param name="input">The input parameters for the calculation.</param>
    /// <returns>The calculated tax amounts and totals.</returns>
    TaxCalculationResult CalculateAmounts(TaxCalculationInput input);

    /// <summary>
    /// Gets the effective tax rate for a specific tax type based on the booking date.
    /// </summary>
    /// <param name="taxRate">The tax rate configuration.</param>
    /// <param name="taxNumber">The tax number (1, 2, or 3).</param>
    /// <param name="arrivalDate">The arrival date for the booking.</param>
    /// <returns>The effective tax rate as a decimal percentage.</returns>
    decimal GetEffectiveTaxRate(TaxRateInfo taxRate, int taxNumber, DateTime arrivalDate);

    /// <summary>
    /// Decodes a tax plan code into its individual tax application settings.
    /// </summary>
    /// <param name="planCode">The 3-digit tax plan code (e.g., "015" or "258").</param>
    /// <returns>The decoded tax plan settings.</returns>
    TaxPlanSettings DecodeTaxPlan(string planCode);
}

/// <summary>
/// Input parameters for tax calculation.
/// </summary>
public class TaxCalculationInput
{
    /// <summary>
    /// Daily gross rate charged to the guest.
    /// </summary>
    public decimal DailyGrossRate { get; set; }

    /// <summary>
    /// Number of nights for the booking.
    /// </summary>
    public int NumberOfNights { get; set; }

    /// <summary>
    /// Percentage paid to the host (0-100).
    /// </summary>
    public decimal PercentToHost { get; set; }

    /// <summary>
    /// The tax plan code (3-digit string like "015" or "258").
    /// </summary>
    public string TaxPlanCode { get; set; } = string.Empty;

    /// <summary>
    /// The arrival date (used to determine which tax rates apply).
    /// </summary>
    public DateTime ArrivalDate { get; set; }

    /// <summary>
    /// The payment type (Prepay, Direct, or Comp).
    /// </summary>
    public PaymentType PaymentType { get; set; }

    /// <summary>
    /// Current tax rates configuration.
    /// </summary>
    public TaxRateInfo TaxRates { get; set; } = new();
}

/// <summary>
/// Tax rate information including current and future rates.
/// </summary>
public class TaxRateInfo
{
    public decimal TaxOne { get; set; }
    public decimal? FutureTaxOne { get; set; }
    public DateTime? FutureTaxOneEffectiveDate { get; set; }

    public decimal TaxTwo { get; set; }
    public decimal? FutureTaxTwo { get; set; }
    public DateTime? FutureTaxTwoEffectiveDate { get; set; }

    public decimal TaxThree { get; set; }
    public decimal? FutureTaxThree { get; set; }
    public DateTime? FutureTaxThreeEffectiveDate { get; set; }
}

/// <summary>
/// Result of tax calculation.
/// </summary>
public class TaxCalculationResult
{
    /// <summary>
    /// Whether the calculation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Error message if calculation failed.
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Daily net rate (gross rate × percent to host).
    /// </summary>
    public decimal DailyNetRate { get; set; }

    /// <summary>
    /// Tax amount for Tax 1.
    /// </summary>
    public decimal Tax1Amount { get; set; }

    /// <summary>
    /// Tax amount for Tax 2.
    /// </summary>
    public decimal Tax2Amount { get; set; }

    /// <summary>
    /// Tax amount for Tax 3.
    /// </summary>
    public decimal Tax3Amount { get; set; }

    /// <summary>
    /// Total tax amount (on gross).
    /// </summary>
    public decimal TotalTax { get; set; }

    /// <summary>
    /// Gross amount with tax (total guest pays).
    /// </summary>
    public decimal GrossWithTax { get; set; }

    /// <summary>
    /// Net amount with tax (amount to host including their portion of tax).
    /// </summary>
    public decimal NetWithTax { get; set; }

    /// <summary>
    /// Service fee (difference between gross and net with tax).
    /// </summary>
    public decimal ServiceFee { get; set; }
}

/// <summary>
/// Decoded tax plan settings indicating how each tax applies.
/// </summary>
public class TaxPlanSettings
{
    /// <summary>
    /// How Tax 1 is applied.
    /// </summary>
    public TaxApplication Tax1Application { get; set; }

    /// <summary>
    /// How Tax 2 is applied.
    /// </summary>
    public TaxApplication Tax2Application { get; set; }

    /// <summary>
    /// How Tax 3 is applied.
    /// </summary>
    public TaxApplication Tax3Application { get; set; }
}

/// <summary>
/// How a tax rate is applied in calculations.
/// </summary>
public enum TaxApplication
{
    /// <summary>
    /// Tax is applied to the net amount (host's portion).
    /// </summary>
    ApplyToNet,

    /// <summary>
    /// Tax is applied to the gross amount (total guest pays).
    /// </summary>
    ApplyToGross,

    /// <summary>
    /// Tax does not apply.
    /// </summary>
    DoesNotApply
}

/// <summary>
/// Payment type for accommodation bookings.
/// </summary>
public enum PaymentType
{
    /// <summary>
    /// Guest prepays through the agency.
    /// </summary>
    Prepay,

    /// <summary>
    /// Guest pays host directly.
    /// </summary>
    Direct,

    /// <summary>
    /// Complimentary stay (no charge).
    /// </summary>
    Comp
}
