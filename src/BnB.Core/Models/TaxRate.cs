namespace BnB.Core.Models;

/// <summary>
/// Tax rates configuration - maps to taxrates table
/// </summary>
public class TaxRate
{
    public int Id { get; set; }

    public decimal TaxOne { get; set; }
    public string? TaxOneDescription { get; set; }
    public decimal? FutureTaxOne { get; set; }
    public DateTime? FutureTaxOneEffectiveDate { get; set; }

    public decimal TaxTwo { get; set; }
    public string? TaxTwoDescription { get; set; }
    public decimal? FutureTaxTwo { get; set; }
    public DateTime? FutureTaxTwoEffectiveDate { get; set; }

    public decimal TaxThree { get; set; }
    public string? TaxThreeDescription { get; set; }
    public decimal? FutureTaxThree { get; set; }
    public DateTime? FutureTaxThreeEffectiveDate { get; set; }
}
