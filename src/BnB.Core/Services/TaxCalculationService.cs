namespace BnB.Core.Services;

/// <summary>
/// Service for calculating tax amounts for accommodation bookings.
/// Migrated from CalculateAmounts function in BNB1.BAS.
/// </summary>
public class TaxCalculationService : ITaxCalculationService
{
    /// <inheritdoc />
    public TaxCalculationResult CalculateAmounts(TaxCalculationInput input)
    {
        var result = new TaxCalculationResult { Success = false };

        // Validate input
        if (string.IsNullOrWhiteSpace(input.TaxPlanCode) || input.TaxPlanCode.Length != 3)
        {
            result.ErrorMessage = "Invalid tax plan code. Tax plan code must be a 3-digit string.";
            return result;
        }

        if (input.TaxRates == null)
        {
            result.ErrorMessage = "Tax rates have not been set. Set tax rates through the Tax Rates configuration.";
            return result;
        }

        // For Direct and Comp payments, all calculated amounts are zero
        if (input.PaymentType == PaymentType.Direct || input.PaymentType == PaymentType.Comp)
        {
            result.Success = true;
            result.DailyNetRate = 0;
            result.Tax1Amount = 0;
            result.Tax2Amount = 0;
            result.Tax3Amount = 0;
            result.TotalTax = 0;
            result.GrossWithTax = 0;
            result.NetWithTax = 0;
            result.ServiceFee = 0;
            return result;
        }

        // Get effective tax rates based on arrival date
        decimal tax1Rate = GetEffectiveTaxRate(input.TaxRates, 1, input.ArrivalDate) / 100m;
        decimal tax2Rate = GetEffectiveTaxRate(input.TaxRates, 2, input.ArrivalDate) / 100m;
        decimal tax3Rate = GetEffectiveTaxRate(input.TaxRates, 3, input.ArrivalDate) / 100m;

        // Calculate base amounts
        decimal percentToHost = input.PercentToHost / 100m;
        decimal grossTimesNights = input.DailyGrossRate * input.NumberOfNights;
        decimal grossTimesPercent = input.DailyGrossRate * percentToHost;
        decimal netTimesNights = grossTimesPercent * input.NumberOfNights;

        // Decode tax plan to determine how each tax applies
        var taxPlan = DecodeTaxPlan(input.TaxPlanCode);

        // Calculate Tax 1
        decimal tax1Amount = CalculateTaxAmount(taxPlan.Tax1Application, tax1Rate, grossTimesNights, netTimesNights);
        if (taxPlan.Tax1Application == TaxApplication.DoesNotApply)
            tax1Rate = 0;

        // Calculate Tax 2
        decimal tax2Amount = CalculateTaxAmount(taxPlan.Tax2Application, tax2Rate, grossTimesNights, netTimesNights);
        if (taxPlan.Tax2Application == TaxApplication.DoesNotApply)
            tax2Rate = 0;

        // Calculate Tax 3
        decimal tax3Amount = CalculateTaxAmount(taxPlan.Tax3Application, tax3Rate, grossTimesNights, netTimesNights);
        if (taxPlan.Tax3Application == TaxApplication.DoesNotApply)
            tax3Rate = 0;

        // Calculate totals
        decimal combinedTaxRate = tax1Rate + tax2Rate + tax3Rate;
        decimal totalTax = grossTimesNights * combinedTaxRate;
        decimal grossWithTax = grossTimesNights + totalTax;
        decimal netWithTax = netTimesNights + tax1Amount + tax2Amount + tax3Amount;
        decimal serviceFee = grossWithTax - netWithTax;

        // Round all amounts to 2 decimal places
        result.Success = true;
        result.DailyNetRate = Math.Round(grossTimesPercent, 2);
        result.Tax1Amount = Math.Round(tax1Amount, 2);
        result.Tax2Amount = Math.Round(tax2Amount, 2);
        result.Tax3Amount = Math.Round(tax3Amount, 2);
        result.TotalTax = Math.Round(totalTax, 2);
        result.GrossWithTax = Math.Round(grossWithTax, 2);
        result.NetWithTax = Math.Round(netWithTax, 2);
        result.ServiceFee = Math.Round(serviceFee, 2);

        return result;
    }

    /// <inheritdoc />
    public decimal GetEffectiveTaxRate(TaxRateInfo taxRate, int taxNumber, DateTime arrivalDate)
    {
        return taxNumber switch
        {
            1 => GetEffectiveRate(taxRate.TaxOne, taxRate.FutureTaxOne, taxRate.FutureTaxOneEffectiveDate, arrivalDate),
            2 => GetEffectiveRate(taxRate.TaxTwo, taxRate.FutureTaxTwo, taxRate.FutureTaxTwoEffectiveDate, arrivalDate),
            3 => GetEffectiveRate(taxRate.TaxThree, taxRate.FutureTaxThree, taxRate.FutureTaxThreeEffectiveDate, arrivalDate),
            _ => 0
        };
    }

    /// <inheritdoc />
    public TaxPlanSettings DecodeTaxPlan(string planCode)
    {
        var settings = new TaxPlanSettings();

        if (string.IsNullOrWhiteSpace(planCode) || planCode.Length != 3)
        {
            // Default to all taxes not applied if invalid code
            settings.Tax1Application = TaxApplication.DoesNotApply;
            settings.Tax2Application = TaxApplication.DoesNotApply;
            settings.Tax3Application = TaxApplication.DoesNotApply;
            return settings;
        }

        // Tax 1: digit can be 0 (Net), 1 (Gross), or 2 (N/A)
        settings.Tax1Application = planCode[0] switch
        {
            '0' => TaxApplication.ApplyToNet,
            '1' => TaxApplication.ApplyToGross,
            '2' => TaxApplication.DoesNotApply,
            _ => TaxApplication.DoesNotApply
        };

        // Tax 2: digit can be 3 (Net), 4 (Gross), or 5 (N/A)
        settings.Tax2Application = planCode[1] switch
        {
            '3' => TaxApplication.ApplyToNet,
            '4' => TaxApplication.ApplyToGross,
            '5' => TaxApplication.DoesNotApply,
            _ => TaxApplication.DoesNotApply
        };

        // Tax 3: digit can be 6 (Net), 7 (Gross), or 8 (N/A)
        settings.Tax3Application = planCode[2] switch
        {
            '6' => TaxApplication.ApplyToNet,
            '7' => TaxApplication.ApplyToGross,
            '8' => TaxApplication.DoesNotApply,
            _ => TaxApplication.DoesNotApply
        };

        return settings;
    }

    /// <summary>
    /// Encodes tax plan settings into a 3-digit plan code.
    /// </summary>
    /// <param name="settings">The tax plan settings to encode.</param>
    /// <returns>The encoded 3-digit tax plan code.</returns>
    public static string EncodeTaxPlan(TaxPlanSettings settings)
    {
        char tax1Digit = settings.Tax1Application switch
        {
            TaxApplication.ApplyToNet => '0',
            TaxApplication.ApplyToGross => '1',
            TaxApplication.DoesNotApply => '2',
            _ => '2'
        };

        char tax2Digit = settings.Tax2Application switch
        {
            TaxApplication.ApplyToNet => '3',
            TaxApplication.ApplyToGross => '4',
            TaxApplication.DoesNotApply => '5',
            _ => '5'
        };

        char tax3Digit = settings.Tax3Application switch
        {
            TaxApplication.ApplyToNet => '6',
            TaxApplication.ApplyToGross => '7',
            TaxApplication.DoesNotApply => '8',
            _ => '8'
        };

        return $"{tax1Digit}{tax2Digit}{tax3Digit}";
    }

    private static decimal GetEffectiveRate(decimal currentRate, decimal? futureRate, DateTime? futureEffectiveDate, DateTime arrivalDate)
    {
        // If there's a future rate set and it differs from current rate
        if (futureRate.HasValue && futureEffectiveDate.HasValue && futureRate.Value != currentRate)
        {
            // Use future rate if arrival date is on or after the effective date
            if (arrivalDate.Date >= futureEffectiveDate.Value.Date)
            {
                return futureRate.Value;
            }
        }

        return currentRate;
    }

    private static decimal CalculateTaxAmount(TaxApplication application, decimal taxRate, decimal grossAmount, decimal netAmount)
    {
        return application switch
        {
            TaxApplication.ApplyToNet => netAmount * taxRate,
            TaxApplication.ApplyToGross => grossAmount * taxRate,
            TaxApplication.DoesNotApply => 0,
            _ => 0
        };
    }
}
