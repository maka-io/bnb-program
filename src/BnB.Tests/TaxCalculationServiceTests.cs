using BnB.Core.Services;
using Xunit;

namespace BnB.Tests;

public class TaxCalculationServiceTests
{
    private readonly TaxCalculationService _service;

    public TaxCalculationServiceTests()
    {
        _service = new TaxCalculationService();
    }

    #region DecodeTaxPlan Tests

    [Theory]
    [InlineData("258", TaxApplication.DoesNotApply, TaxApplication.DoesNotApply, TaxApplication.DoesNotApply)]
    [InlineData("036", TaxApplication.ApplyToNet, TaxApplication.ApplyToNet, TaxApplication.ApplyToNet)]
    [InlineData("147", TaxApplication.ApplyToGross, TaxApplication.ApplyToGross, TaxApplication.ApplyToGross)]
    [InlineData("058", TaxApplication.ApplyToNet, TaxApplication.DoesNotApply, TaxApplication.DoesNotApply)]
    [InlineData("148", TaxApplication.ApplyToGross, TaxApplication.ApplyToGross, TaxApplication.DoesNotApply)]
    public void DecodeTaxPlan_ReturnsCorrectSettings(string planCode,
        TaxApplication expectedTax1, TaxApplication expectedTax2, TaxApplication expectedTax3)
    {
        var result = _service.DecodeTaxPlan(planCode);

        Assert.Equal(expectedTax1, result.Tax1Application);
        Assert.Equal(expectedTax2, result.Tax2Application);
        Assert.Equal(expectedTax3, result.Tax3Application);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("12")]
    [InlineData("1234")]
    public void DecodeTaxPlan_InvalidCode_ReturnsAllDoesNotApply(string? planCode)
    {
        var result = _service.DecodeTaxPlan(planCode!);

        Assert.Equal(TaxApplication.DoesNotApply, result.Tax1Application);
        Assert.Equal(TaxApplication.DoesNotApply, result.Tax2Application);
        Assert.Equal(TaxApplication.DoesNotApply, result.Tax3Application);
    }

    #endregion

    #region EncodeTaxPlan Tests

    [Fact]
    public void EncodeTaxPlan_AllDoesNotApply_Returns258()
    {
        var settings = new TaxPlanSettings
        {
            Tax1Application = TaxApplication.DoesNotApply,
            Tax2Application = TaxApplication.DoesNotApply,
            Tax3Application = TaxApplication.DoesNotApply
        };

        var result = TaxCalculationService.EncodeTaxPlan(settings);

        Assert.Equal("258", result);
    }

    [Fact]
    public void EncodeTaxPlan_AllApplyToNet_Returns036()
    {
        var settings = new TaxPlanSettings
        {
            Tax1Application = TaxApplication.ApplyToNet,
            Tax2Application = TaxApplication.ApplyToNet,
            Tax3Application = TaxApplication.ApplyToNet
        };

        var result = TaxCalculationService.EncodeTaxPlan(settings);

        Assert.Equal("036", result);
    }

    [Fact]
    public void EncodeTaxPlan_AllApplyToGross_Returns147()
    {
        var settings = new TaxPlanSettings
        {
            Tax1Application = TaxApplication.ApplyToGross,
            Tax2Application = TaxApplication.ApplyToGross,
            Tax3Application = TaxApplication.ApplyToGross
        };

        var result = TaxCalculationService.EncodeTaxPlan(settings);

        Assert.Equal("147", result);
    }

    #endregion

    #region GetEffectiveTaxRate Tests

    [Fact]
    public void GetEffectiveTaxRate_NoFutureRate_ReturnsCurrentRate()
    {
        var taxRate = new TaxRateInfo
        {
            TaxOne = 4.166m,
            FutureTaxOne = null,
            FutureTaxOneEffectiveDate = null
        };

        var result = _service.GetEffectiveTaxRate(taxRate, 1, DateTime.Today);

        Assert.Equal(4.166m, result);
    }

    [Fact]
    public void GetEffectiveTaxRate_FutureRateNotYetEffective_ReturnsCurrentRate()
    {
        var taxRate = new TaxRateInfo
        {
            TaxOne = 4.166m,
            FutureTaxOne = 5.0m,
            FutureTaxOneEffectiveDate = DateTime.Today.AddDays(30)
        };

        var result = _service.GetEffectiveTaxRate(taxRate, 1, DateTime.Today);

        Assert.Equal(4.166m, result);
    }

    [Fact]
    public void GetEffectiveTaxRate_FutureRateEffective_ReturnsFutureRate()
    {
        var taxRate = new TaxRateInfo
        {
            TaxOne = 4.166m,
            FutureTaxOne = 5.0m,
            FutureTaxOneEffectiveDate = DateTime.Today.AddDays(-1)
        };

        var result = _service.GetEffectiveTaxRate(taxRate, 1, DateTime.Today);

        Assert.Equal(5.0m, result);
    }

    [Fact]
    public void GetEffectiveTaxRate_FutureRateEffectiveOnArrivalDate_ReturnsFutureRate()
    {
        var effectiveDate = DateTime.Today;
        var taxRate = new TaxRateInfo
        {
            TaxOne = 4.166m,
            FutureTaxOne = 5.0m,
            FutureTaxOneEffectiveDate = effectiveDate
        };

        var result = _service.GetEffectiveTaxRate(taxRate, 1, effectiveDate);

        Assert.Equal(5.0m, result);
    }

    #endregion

    #region CalculateAmounts Tests

    [Fact]
    public void CalculateAmounts_DirectPayment_ReturnsAllZeros()
    {
        var input = new TaxCalculationInput
        {
            DailyGrossRate = 100m,
            NumberOfNights = 3,
            PercentToHost = 70m,
            TaxPlanCode = "147",
            PaymentType = PaymentType.Direct,
            TaxRates = new TaxRateInfo { TaxOne = 4.166m, TaxTwo = 7.25m, TaxThree = 0 }
        };

        var result = _service.CalculateAmounts(input);

        Assert.True(result.Success);
        Assert.Equal(0, result.DailyNetRate);
        Assert.Equal(0, result.Tax1Amount);
        Assert.Equal(0, result.Tax2Amount);
        Assert.Equal(0, result.Tax3Amount);
        Assert.Equal(0, result.TotalTax);
        Assert.Equal(0, result.GrossWithTax);
        Assert.Equal(0, result.NetWithTax);
        Assert.Equal(0, result.ServiceFee);
    }

    [Fact]
    public void CalculateAmounts_CompPayment_ReturnsAllZeros()
    {
        var input = new TaxCalculationInput
        {
            DailyGrossRate = 100m,
            NumberOfNights = 3,
            PercentToHost = 70m,
            TaxPlanCode = "147",
            PaymentType = PaymentType.Comp,
            TaxRates = new TaxRateInfo { TaxOne = 4.166m, TaxTwo = 7.25m, TaxThree = 0 }
        };

        var result = _service.CalculateAmounts(input);

        Assert.True(result.Success);
        Assert.Equal(0, result.DailyNetRate);
    }

    [Fact]
    public void CalculateAmounts_InvalidTaxPlanCode_ReturnsError()
    {
        var input = new TaxCalculationInput
        {
            DailyGrossRate = 100m,
            NumberOfNights = 3,
            PercentToHost = 70m,
            TaxPlanCode = "12", // Invalid - only 2 digits
            PaymentType = PaymentType.Prepay,
            TaxRates = new TaxRateInfo { TaxOne = 4.166m, TaxTwo = 7.25m, TaxThree = 0 }
        };

        var result = _service.CalculateAmounts(input);

        Assert.False(result.Success);
        Assert.Contains("Invalid tax plan code", result.ErrorMessage);
    }

    [Fact]
    public void CalculateAmounts_NullTaxRates_ReturnsError()
    {
        var input = new TaxCalculationInput
        {
            DailyGrossRate = 100m,
            NumberOfNights = 3,
            PercentToHost = 70m,
            TaxPlanCode = "147",
            PaymentType = PaymentType.Prepay,
            TaxRates = null!
        };

        var result = _service.CalculateAmounts(input);

        Assert.False(result.Success);
        Assert.Contains("Tax rates have not been set", result.ErrorMessage);
    }

    [Fact]
    public void CalculateAmounts_PrepayWithGrossTaxes_CalculatesCorrectly()
    {
        // Example: $150/night for 3 nights, 70% to host, all taxes on gross
        var input = new TaxCalculationInput
        {
            DailyGrossRate = 150m,
            NumberOfNights = 3,
            PercentToHost = 70m,
            TaxPlanCode = "147", // All taxes apply to gross
            PaymentType = PaymentType.Prepay,
            ArrivalDate = DateTime.Today,
            TaxRates = new TaxRateInfo
            {
                TaxOne = 4.0m,    // 4%
                TaxTwo = 7.0m,    // 7%
                TaxThree = 0m     // N/A (but code says 7=gross)
            }
        };

        var result = _service.CalculateAmounts(input);

        Assert.True(result.Success);

        // Daily Net Rate = 150 * 0.70 = 105
        Assert.Equal(105m, result.DailyNetRate);

        // Gross × Nights = 150 * 3 = 450
        // Tax1 (gross): 450 * 0.04 = 18
        Assert.Equal(18m, result.Tax1Amount);

        // Tax2 (gross): 450 * 0.07 = 31.50
        Assert.Equal(31.5m, result.Tax2Amount);

        // Tax3 (not applied since rate is 0): 0
        Assert.Equal(0m, result.Tax3Amount);

        // Total Tax = 450 * (0.04 + 0.07 + 0) = 450 * 0.11 = 49.50
        Assert.Equal(49.5m, result.TotalTax);

        // Gross with Tax = 450 + 49.50 = 499.50
        Assert.Equal(499.5m, result.GrossWithTax);
    }

    [Fact]
    public void CalculateAmounts_PrepayWithNetTaxes_CalculatesCorrectly()
    {
        // Example: $100/night for 2 nights, 65% to host, all taxes on net
        var input = new TaxCalculationInput
        {
            DailyGrossRate = 100m,
            NumberOfNights = 2,
            PercentToHost = 65m,
            TaxPlanCode = "036", // All taxes apply to net
            PaymentType = PaymentType.Prepay,
            ArrivalDate = DateTime.Today,
            TaxRates = new TaxRateInfo
            {
                TaxOne = 5.0m,    // 5%
                TaxTwo = 5.0m,    // 5%
                TaxThree = 5.0m   // 5%
            }
        };

        var result = _service.CalculateAmounts(input);

        Assert.True(result.Success);

        // Daily Net Rate = 100 * 0.65 = 65
        Assert.Equal(65m, result.DailyNetRate);

        // Net × Nights = 65 * 2 = 130
        // Tax1 (net): 130 * 0.05 = 6.50
        Assert.Equal(6.5m, result.Tax1Amount);

        // Tax2 (net): 130 * 0.05 = 6.50
        Assert.Equal(6.5m, result.Tax2Amount);

        // Tax3 (net): 130 * 0.05 = 6.50
        Assert.Equal(6.5m, result.Tax3Amount);
    }

    [Fact]
    public void CalculateAmounts_AllTaxesDoNotApply_NoTaxCalculated()
    {
        var input = new TaxCalculationInput
        {
            DailyGrossRate = 100m,
            NumberOfNights = 2,
            PercentToHost = 70m,
            TaxPlanCode = "258", // No taxes apply
            PaymentType = PaymentType.Prepay,
            ArrivalDate = DateTime.Today,
            TaxRates = new TaxRateInfo
            {
                TaxOne = 5.0m,
                TaxTwo = 5.0m,
                TaxThree = 5.0m
            }
        };

        var result = _service.CalculateAmounts(input);

        Assert.True(result.Success);
        Assert.Equal(0m, result.Tax1Amount);
        Assert.Equal(0m, result.Tax2Amount);
        Assert.Equal(0m, result.Tax3Amount);
        Assert.Equal(0m, result.TotalTax);
    }

    #endregion
}
