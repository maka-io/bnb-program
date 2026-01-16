namespace BnB.Core.Models;

/// <summary>
/// Tax plan configuration - contains both tax rates and how they are applied.
/// Maps to taxplan table in legacy database (enhanced).
/// </summary>
public class TaxPlan
{
    public int Id { get; set; }
    public string PlanCode { get; set; } = string.Empty;  // plancode (legacy 3-digit code, auto-generated)
    public string? PlanTitle { get; set; }  // plan_title
    public string? Description { get; set; }

    // Tax 1
    public decimal Tax1Rate { get; set; }  // Tax rate as percentage (e.g., 4.166 for 4.166%)
    public string? Tax1Description { get; set; }
    public int Tax1Application { get; set; }  // 0=Net, 1=Gross, 2=N/A
    public decimal? FutureTax1Rate { get; set; }
    public DateTime? FutureTax1EffectiveDate { get; set; }

    // Tax 2
    public decimal Tax2Rate { get; set; }
    public string? Tax2Description { get; set; }
    public int Tax2Application { get; set; }  // 0=Net, 1=Gross, 2=N/A
    public decimal? FutureTax2Rate { get; set; }
    public DateTime? FutureTax2EffectiveDate { get; set; }

    // Tax 3
    public decimal Tax3Rate { get; set; }
    public string? Tax3Description { get; set; }
    public int Tax3Application { get; set; }  // 0=Net, 1=Gross, 2=N/A
    public decimal? FutureTax3Rate { get; set; }
    public DateTime? FutureTax3EffectiveDate { get; set; }

    /// <summary>
    /// Generates the legacy 3-digit plan code from application settings.
    /// </summary>
    public string GeneratePlanCode()
    {
        // Tax 1: 0=Net, 1=Gross, 2=N/A
        char tax1Digit = Tax1Application switch
        {
            0 => '0',  // Net
            1 => '1',  // Gross
            _ => '2'   // N/A
        };

        // Tax 2: 3=Net, 4=Gross, 5=N/A
        char tax2Digit = Tax2Application switch
        {
            0 => '3',  // Net
            1 => '4',  // Gross
            _ => '5'   // N/A
        };

        // Tax 3: 6=Net, 7=Gross, 8=N/A
        char tax3Digit = Tax3Application switch
        {
            0 => '6',  // Net
            1 => '7',  // Gross
            _ => '8'   // N/A
        };

        return $"{tax1Digit}{tax2Digit}{tax3Digit}";
    }

    /// <summary>
    /// Parses a legacy 3-digit plan code and sets the application settings.
    /// </summary>
    public void ParsePlanCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code) || code.Length != 3)
        {
            Tax1Application = 2;  // N/A
            Tax2Application = 2;  // N/A
            Tax3Application = 2;  // N/A
            return;
        }

        // Tax 1: 0=Net, 1=Gross, 2=N/A
        Tax1Application = code[0] switch
        {
            '0' => 0,  // Net
            '1' => 1,  // Gross
            _ => 2     // N/A
        };

        // Tax 2: 3=Net, 4=Gross, 5=N/A
        Tax2Application = code[1] switch
        {
            '3' => 0,  // Net
            '4' => 1,  // Gross
            _ => 2     // N/A
        };

        // Tax 3: 6=Net, 7=Gross, 8=N/A
        Tax3Application = code[2] switch
        {
            '6' => 0,  // Net
            '7' => 1,  // Gross
            _ => 2     // N/A
        };
    }

    /// <summary>
    /// Converts this TaxPlan to a TaxRateInfo for use with TaxCalculationService.
    /// </summary>
    public BnB.Core.Services.TaxRateInfo ToTaxRateInfo()
    {
        return new BnB.Core.Services.TaxRateInfo
        {
            TaxOne = Tax1Rate,
            FutureTaxOne = FutureTax1Rate,
            FutureTaxOneEffectiveDate = FutureTax1EffectiveDate,
            TaxTwo = Tax2Rate,
            FutureTaxTwo = FutureTax2Rate,
            FutureTaxTwoEffectiveDate = FutureTax2EffectiveDate,
            TaxThree = Tax3Rate,
            FutureTaxThree = FutureTax3Rate,
            FutureTaxThreeEffectiveDate = FutureTax3EffectiveDate
        };
    }
}
