using BnB.Core.Services;
using Xunit;

namespace BnB.Tests;

public class CurrencyToWordsServiceTests
{
    private readonly CurrencyToWordsService _service;

    public CurrencyToWordsServiceTests()
    {
        _service = new CurrencyToWordsService();
    }

    #region Basic Number Conversion Tests

    [Fact]
    public void ConvertToWords_Zero_ReturnsZeroDollars()
    {
        var result = _service.ConvertToWords(0m);

        Assert.Equal("Zero Dollars and 00/100", result);
    }

    [Fact]
    public void ConvertToWords_OneDollar_ReturnsSingularDollar()
    {
        var result = _service.ConvertToWords(1m);

        Assert.Equal("One Dollar and 00/100", result);
    }

    [Fact]
    public void ConvertToWords_TwoDollars_ReturnsPluralDollars()
    {
        var result = _service.ConvertToWords(2m);

        Assert.Equal("Two Dollars and 00/100", result);
    }

    [Theory]
    [InlineData(5, "Five Dollars and 00/100")]
    [InlineData(10, "Ten Dollars and 00/100")]
    [InlineData(11, "Eleven Dollars and 00/100")]
    [InlineData(15, "Fifteen Dollars and 00/100")]
    [InlineData(19, "Nineteen Dollars and 00/100")]
    public void ConvertToWords_SingleAndTeens_ConvertsCorrectly(decimal amount, string expected)
    {
        var result = _service.ConvertToWords(amount);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(20, "Twenty Dollars and 00/100")]
    [InlineData(25, "Twenty-Five Dollars and 00/100")]
    [InlineData(30, "Thirty Dollars and 00/100")]
    [InlineData(42, "Forty-Two Dollars and 00/100")]
    [InlineData(99, "Ninety-Nine Dollars and 00/100")]
    public void ConvertToWords_TwentyToNinetyNine_ConvertsCorrectly(decimal amount, string expected)
    {
        var result = _service.ConvertToWords(amount);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(100, "One Hundred Dollars and 00/100")]
    [InlineData(101, "One Hundred One Dollars and 00/100")]
    [InlineData(123, "One Hundred Twenty-Three Dollars and 00/100")]
    [InlineData(500, "Five Hundred Dollars and 00/100")]
    [InlineData(999, "Nine Hundred Ninety-Nine Dollars and 00/100")]
    public void ConvertToWords_Hundreds_ConvertsCorrectly(decimal amount, string expected)
    {
        var result = _service.ConvertToWords(amount);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1000, "One Thousand Dollars and 00/100")]
    [InlineData(1001, "One Thousand One Dollars and 00/100")]
    [InlineData(1234, "One Thousand Two Hundred Thirty-Four Dollars and 00/100")]
    [InlineData(10000, "Ten Thousand Dollars and 00/100")]
    [InlineData(12345, "Twelve Thousand Three Hundred Forty-Five Dollars and 00/100")]
    public void ConvertToWords_Thousands_ConvertsCorrectly(decimal amount, string expected)
    {
        var result = _service.ConvertToWords(amount);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1000000, "One Million Dollars and 00/100")]
    [InlineData(1234567, "One Million Two Hundred Thirty-Four Thousand Five Hundred Sixty-Seven Dollars and 00/100")]
    public void ConvertToWords_Millions_ConvertsCorrectly(decimal amount, string expected)
    {
        var result = _service.ConvertToWords(amount);

        Assert.Equal(expected, result);
    }

    #endregion

    #region Cents Tests

    [Theory]
    [InlineData(0.01, "Zero Dollars and 01/100")]
    [InlineData(0.10, "Zero Dollars and 10/100")]
    [InlineData(0.50, "Zero Dollars and 50/100")]
    [InlineData(0.99, "Zero Dollars and 99/100")]
    public void ConvertToWords_CentsOnly_ConvertsCorrectly(decimal amount, string expected)
    {
        var result = _service.ConvertToWords(amount);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1.01, "One Dollar and 01/100")]
    [InlineData(5.25, "Five Dollars and 25/100")]
    [InlineData(123.45, "One Hundred Twenty-Three Dollars and 45/100")]
    [InlineData(1234.56, "One Thousand Two Hundred Thirty-Four Dollars and 56/100")]
    public void ConvertToWords_DollarsAndCents_ConvertsCorrectly(decimal amount, string expected)
    {
        var result = _service.ConvertToWords(amount);

        Assert.Equal(expected, result);
    }

    #endregion

    #region Negative Numbers Tests

    [Theory]
    [InlineData(-1, "Negative One Dollar and 00/100")]
    [InlineData(-100, "Negative One Hundred Dollars and 00/100")]
    [InlineData(-123.45, "Negative One Hundred Twenty-Three Dollars and 45/100")]
    public void ConvertToWords_NegativeAmounts_IncludesNegative(decimal amount, string expected)
    {
        var result = _service.ConvertToWords(amount);

        Assert.Equal(expected, result);
    }

    #endregion

    #region Custom Currency Name Tests

    [Fact]
    public void ConvertToWords_CustomCurrency_UsesCurrencyName()
    {
        var result = _service.ConvertToWords(100m, "Pesos");

        Assert.Equal("One Hundred Pesos and 00/100", result);
    }

    [Fact]
    public void ConvertToWords_SingleUnitCustomCurrency_UsesSingular()
    {
        var result = _service.ConvertToWords(1m, "Euros");

        Assert.Equal("One Euro and 00/100", result);
    }

    #endregion

    #region Rounding Tests

    [Fact]
    public void ConvertToWords_MoreThanTwoDecimalPlaces_RoundsCorrectly()
    {
        // 123.456 should round to 123.46
        var result = _service.ConvertToWords(123.456m);

        Assert.Equal("One Hundred Twenty-Three Dollars and 46/100", result);
    }

    [Fact]
    public void ConvertToWords_RoundsUpTo100Cents_IncrementsDollar()
    {
        // 1.999 should round to 2.00
        var result = _service.ConvertToWords(1.999m);

        Assert.Equal("Two Dollars and 00/100", result);
    }

    #endregion

    #region Real-World Check Amount Tests

    [Theory]
    [InlineData(499.50, "Four Hundred Ninety-Nine Dollars and 50/100")]
    [InlineData(1575.00, "One Thousand Five Hundred Seventy-Five Dollars and 00/100")]
    [InlineData(2350.75, "Two Thousand Three Hundred Fifty Dollars and 75/100")]
    [InlineData(15000.00, "Fifteen Thousand Dollars and 00/100")]
    public void ConvertToWords_TypicalCheckAmounts_ConvertsCorrectly(decimal amount, string expected)
    {
        var result = _service.ConvertToWords(amount);

        Assert.Equal(expected, result);
    }

    #endregion
}
