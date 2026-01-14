using BnB.Core.Services;
using Xunit;

namespace BnB.Tests;

public class ValidationServiceTests
{
    private readonly ValidationService _service;

    public ValidationServiceTests()
    {
        _service = new ValidationService();
    }

    #region ValidateRequired Tests

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ValidateRequired_EmptyValue_ReturnsError(string? value)
    {
        var result = _service.ValidateRequired(value, "Test Field");

        Assert.False(result.IsValid);
        Assert.Contains("required", result.ErrorMessage);
    }

    [Fact]
    public void ValidateRequired_WithValue_ReturnsSuccess()
    {
        var result = _service.ValidateRequired("some value", "Test Field");

        Assert.True(result.IsValid);
    }

    #endregion

    #region ValidateDate Tests

    [Theory]
    [InlineData("1/15/2024")]
    [InlineData("01/15/2024")]
    [InlineData("1/15/24")]
    [InlineData("01/15/24")]
    [InlineData("2024-01-15")]
    public void ValidateDate_ValidFormats_ReturnsSuccess(string value)
    {
        var result = _service.ValidateDate(value, "Date");

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("13/45/2024")]
    [InlineData("abc/def/ghi")]
    public void ValidateDate_InvalidFormats_ReturnsError(string value)
    {
        var result = _service.ValidateDate(value, "Date");

        Assert.False(result.IsValid);
        Assert.Contains("Invalid date format", result.ErrorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ValidateDate_Empty_ReturnsSuccess(string? value)
    {
        var result = _service.ValidateDate(value, "Date");

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateRequiredDate_Empty_ReturnsError()
    {
        var result = _service.ValidateRequiredDate("", "Date");

        Assert.False(result.IsValid);
        Assert.Contains("required", result.ErrorMessage);
    }

    #endregion

    #region ValidateNumber Tests

    [Theory]
    [InlineData("123")]
    [InlineData("0")]
    [InlineData("999999")]
    public void ValidateNumber_ValidIntegers_ReturnsSuccess(string value)
    {
        var result = _service.ValidateNumber(value, "Number");

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("123.45")]
    [InlineData("0.00")]
    [InlineData("999.99")]
    public void ValidateNumber_ValidDecimals_ReturnsSuccess(string value)
    {
        var result = _service.ValidateNumber(value, "Number", allowDecimal: true);

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("-5")]
    [InlineData("-100.50")]
    public void ValidateNumber_NegativeWhenNotAllowed_ReturnsError(string value)
    {
        var result = _service.ValidateNumber(value, "Number", allowNegative: false);

        Assert.False(result.IsValid);
        Assert.Contains("cannot be negative", result.ErrorMessage);
    }

    [Theory]
    [InlineData("-5")]
    [InlineData("-100.50")]
    public void ValidateNumber_NegativeWhenAllowed_ReturnsSuccess(string value)
    {
        var result = _service.ValidateNumber(value, "Number", allowNegative: true);

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("12.34.56")]
    [InlineData("$100")]
    public void ValidateNumber_InvalidFormat_ReturnsError(string value)
    {
        var result = _service.ValidateNumber(value, "Number");

        Assert.False(result.IsValid);
        Assert.Contains("Invalid character", result.ErrorMessage);
    }

    #endregion

    #region ValidateCurrency Tests

    [Theory]
    [InlineData("100")]
    [InlineData("100.00")]
    [InlineData("$100.00")]
    [InlineData("1,234.56")]
    [InlineData("$1,234.56")]
    public void ValidateCurrency_ValidFormats_ReturnsSuccess(string value)
    {
        var result = _service.ValidateCurrency(value, "Amount");

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("-50.00")]
    [InlineData("-$100")]
    public void ValidateCurrency_NegativeWhenNotAllowed_ReturnsError(string value)
    {
        var result = _service.ValidateCurrency(value, "Amount", allowNegative: false);

        Assert.False(result.IsValid);
        Assert.Contains("cannot be negative", result.ErrorMessage);
    }

    #endregion

    #region ValidateEmail Tests

    [Theory]
    [InlineData("test@example.com")]
    [InlineData("user.name@domain.org")]
    [InlineData("user+tag@subdomain.domain.com")]
    public void ValidateEmail_ValidEmails_ReturnsSuccess(string value)
    {
        var result = _service.ValidateEmail(value, "Email");

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("@domain.com")]
    [InlineData("user@")]
    [InlineData("user@domain")]
    public void ValidateEmail_InvalidEmails_ReturnsError(string value)
    {
        var result = _service.ValidateEmail(value, "Email");

        Assert.False(result.IsValid);
        Assert.Contains("Invalid email", result.ErrorMessage);
    }

    [Fact]
    public void ValidateEmail_Empty_ReturnsSuccess()
    {
        var result = _service.ValidateEmail("", "Email");

        Assert.True(result.IsValid);
    }

    #endregion

    #region ValidatePhone Tests

    [Theory]
    [InlineData("1234567")]
    [InlineData("123-456-7890")]
    [InlineData("(123) 456-7890")]
    [InlineData("1-800-555-1234")]
    [InlineData("+1 (123) 456-7890")]
    public void ValidatePhone_ValidPhones_ReturnsSuccess(string value)
    {
        var result = _service.ValidatePhone(value, "Phone");

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("12345")]
    public void ValidatePhone_TooShort_ReturnsError(string value)
    {
        var result = _service.ValidatePhone(value, "Phone");

        Assert.False(result.IsValid);
        Assert.Contains("Invalid phone", result.ErrorMessage);
    }

    #endregion

    #region ValidateZipCode Tests

    [Theory]
    [InlineData("12345")]
    [InlineData("12345-6789")]
    public void ValidateZipCode_ValidFormats_ReturnsSuccess(string value)
    {
        var result = _service.ValidateZipCode(value, "ZIP");

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("1234")]
    [InlineData("123456")]
    [InlineData("12345-")]
    [InlineData("abcde")]
    public void ValidateZipCode_InvalidFormats_ReturnsError(string value)
    {
        var result = _service.ValidateZipCode(value, "ZIP");

        Assert.False(result.IsValid);
        Assert.Contains("Invalid ZIP code", result.ErrorMessage);
    }

    #endregion

    #region ValidateMaxLength Tests

    [Fact]
    public void ValidateMaxLength_WithinLimit_ReturnsSuccess()
    {
        var result = _service.ValidateMaxLength("short", "Field", 10);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateMaxLength_ExceedsLimit_ReturnsError()
    {
        var result = _service.ValidateMaxLength("this is a very long string", "Field", 10);

        Assert.False(result.IsValid);
        Assert.Contains("cannot exceed", result.ErrorMessage);
    }

    #endregion

    #region ValidateDateRange Tests

    [Fact]
    public void ValidateDateRange_ValidRange_ReturnsSuccess()
    {
        var start = new DateTime(2024, 1, 1);
        var end = new DateTime(2024, 1, 15);

        var result = _service.ValidateDateRange(start, end, "Start Date", "End Date");

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateDateRange_SameDate_ReturnsSuccess()
    {
        var date = new DateTime(2024, 1, 1);

        var result = _service.ValidateDateRange(date, date, "Start Date", "End Date");

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ValidateDateRange_InvalidRange_ReturnsError()
    {
        var start = new DateTime(2024, 1, 15);
        var end = new DateTime(2024, 1, 1);

        var result = _service.ValidateDateRange(start, end, "Start Date", "End Date");

        Assert.False(result.IsValid);
        Assert.Contains("must be on or after", result.ErrorMessage);
    }

    #endregion

    #region ValidatePercentage Tests

    [Theory]
    [InlineData("0")]
    [InlineData("50")]
    [InlineData("100")]
    [InlineData("75.5")]
    [InlineData("70%")]
    public void ValidatePercentage_ValidValues_ReturnsSuccess(string value)
    {
        var result = _service.ValidatePercentage(value, "Percentage");

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("-1")]
    [InlineData("101")]
    [InlineData("150")]
    public void ValidatePercentage_OutOfRange_ReturnsError(string value)
    {
        var result = _service.ValidatePercentage(value, "Percentage");

        Assert.False(result.IsValid);
        Assert.Contains("between 0 and 100", result.ErrorMessage);
    }

    #endregion

    #region ValidateAll Tests

    [Fact]
    public void ValidateAll_AllValid_ReturnsSuccess()
    {
        var result = _service.ValidateAll(
            _service.ValidateRequired("value", "Field1"),
            _service.ValidateDate("1/15/2024", "Field2"),
            _service.ValidateNumber("123", "Field3")
        );

        Assert.True(result.IsValid);
        Assert.Empty(result.AllErrors);
    }

    [Fact]
    public void ValidateAll_SomeInvalid_ReturnsAllErrors()
    {
        var result = _service.ValidateAll(
            _service.ValidateRequired("", "Field1"),
            _service.ValidateDate("invalid", "Field2"),
            _service.ValidateNumber("abc", "Field3")
        );

        Assert.False(result.IsValid);
        Assert.Equal(3, result.AllErrors.Count);
    }

    #endregion

    #region Static Helper Tests

    [Fact]
    public void TryParseDate_ValidDate_ReturnsTrue()
    {
        var success = ValidationService.TryParseDate("1/15/2024", out var result);

        Assert.True(success);
        Assert.Equal(new DateTime(2024, 1, 15), result);
    }

    [Fact]
    public void TryParseCurrency_ValidAmount_ReturnsTrue()
    {
        var success = ValidationService.TryParseCurrency("$1,234.56", out var result);

        Assert.True(success);
        Assert.Equal(1234.56m, result);
    }

    #endregion
}
