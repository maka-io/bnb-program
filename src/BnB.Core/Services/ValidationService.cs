using System.Globalization;
using System.Text.RegularExpressions;

namespace BnB.Core.Services;

/// <summary>
/// Service for validating form inputs.
/// Migrated from VerifyUpdate and similar validation logic in legacy VB5 application.
/// </summary>
public partial class ValidationService : IValidationService
{
    // Common date formats accepted by the application
    private static readonly string[] DateFormats =
    {
        "M/d/yyyy", "MM/dd/yyyy", "M/d/yy", "MM/dd/yy",
        "yyyy-MM-dd", "M-d-yyyy", "MM-dd-yyyy"
    };

    /// <inheritdoc />
    public ValidationResult ValidateDate(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ValidationResult.Success();
        }

        if (!TryParseDate(value, out _))
        {
            return ValidationResult.Error(fieldName, $"{fieldName}: Invalid date format. Use MM/DD/YY or MM/DD/YYYY format.");
        }

        return ValidationResult.Success();
    }

    /// <inheritdoc />
    public ValidationResult ValidateRequiredDate(string? value, string fieldName)
    {
        var requiredResult = ValidateRequired(value, fieldName);
        if (!requiredResult.IsValid)
        {
            return requiredResult;
        }

        return ValidateDate(value, fieldName);
    }

    /// <inheritdoc />
    public ValidationResult ValidateCurrency(string? value, string fieldName, bool allowNegative = false)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ValidationResult.Success();
        }

        // Remove currency symbols and thousands separators
        var cleanValue = value.Replace("$", "").Replace(",", "").Trim();

        if (!decimal.TryParse(cleanValue, NumberStyles.Currency, CultureInfo.CurrentCulture, out var amount))
        {
            return ValidationResult.Error(fieldName, $"{fieldName}: Invalid currency value.");
        }

        if (!allowNegative && amount < 0)
        {
            return ValidationResult.Error(fieldName, $"{fieldName}: Value cannot be negative.");
        }

        return ValidationResult.Success();
    }

    /// <inheritdoc />
    public ValidationResult ValidateRequiredCurrency(string? value, string fieldName, bool allowNegative = false)
    {
        var requiredResult = ValidateRequired(value, fieldName);
        if (!requiredResult.IsValid)
        {
            return requiredResult;
        }

        return ValidateCurrency(value, fieldName, allowNegative);
    }

    /// <inheritdoc />
    public ValidationResult ValidateNumber(string? value, string fieldName, bool allowNegative = false, bool allowDecimal = true)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ValidationResult.Success();
        }

        var trimmedValue = value.Trim();

        if (allowDecimal)
        {
            if (!decimal.TryParse(trimmedValue, out var decimalResult))
            {
                return ValidationResult.Error(fieldName, $"{fieldName}: Invalid character in number field.");
            }

            if (!allowNegative && decimalResult < 0)
            {
                return ValidationResult.Error(fieldName, $"{fieldName}: Value cannot be negative.");
            }
        }
        else
        {
            if (!long.TryParse(trimmedValue, out var longResult))
            {
                return ValidationResult.Error(fieldName, $"{fieldName}: Value must be a whole number.");
            }

            if (!allowNegative && longResult < 0)
            {
                return ValidationResult.Error(fieldName, $"{fieldName}: Value cannot be negative.");
            }
        }

        return ValidationResult.Success();
    }

    /// <inheritdoc />
    public ValidationResult ValidateRequiredNumber(string? value, string fieldName, bool allowNegative = false, bool allowDecimal = true)
    {
        var requiredResult = ValidateRequired(value, fieldName);
        if (!requiredResult.IsValid)
        {
            return requiredResult;
        }

        return ValidateNumber(value, fieldName, allowNegative, allowDecimal);
    }

    /// <inheritdoc />
    public ValidationResult ValidateRequired(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ValidationResult.Error(fieldName, $"{fieldName} is required.");
        }

        return ValidationResult.Success();
    }

    /// <inheritdoc />
    public ValidationResult ValidateMaxLength(string? value, string fieldName, int maxLength)
    {
        if (string.IsNullOrEmpty(value))
        {
            return ValidationResult.Success();
        }

        if (value.Length > maxLength)
        {
            return ValidationResult.Error(fieldName, $"{fieldName} cannot exceed {maxLength} characters.");
        }

        return ValidationResult.Success();
    }

    /// <inheritdoc />
    public ValidationResult ValidateEmail(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ValidationResult.Success();
        }

        if (!EmailRegex().IsMatch(value))
        {
            return ValidationResult.Error(fieldName, $"{fieldName}: Invalid email address format.");
        }

        return ValidationResult.Success();
    }

    /// <inheritdoc />
    public ValidationResult ValidatePhone(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ValidationResult.Success();
        }

        // Remove common phone formatting characters
        var digitsOnly = PhoneDigitsRegex().Replace(value, "");

        // Accept 7, 10, or 11 digit phone numbers (with or without country code)
        if (digitsOnly.Length < 7 || digitsOnly.Length > 15)
        {
            return ValidationResult.Error(fieldName, $"{fieldName}: Invalid phone number.");
        }

        return ValidationResult.Success();
    }

    /// <inheritdoc />
    public ValidationResult ValidateZipCode(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ValidationResult.Success();
        }

        // US ZIP codes: 5 digits or 5+4 format
        if (!ZipCodeRegex().IsMatch(value))
        {
            return ValidationResult.Error(fieldName, $"{fieldName}: Invalid ZIP code format. Use 12345 or 12345-6789 format.");
        }

        return ValidationResult.Success();
    }

    /// <inheritdoc />
    public ValidationResult ValidateDateRange(DateTime? startDate, DateTime? endDate, string startFieldName, string endFieldName)
    {
        if (!startDate.HasValue || !endDate.HasValue)
        {
            return ValidationResult.Success();
        }

        if (endDate.Value < startDate.Value)
        {
            return ValidationResult.Error(endFieldName, $"{endFieldName} must be on or after {startFieldName}.");
        }

        return ValidationResult.Success();
    }

    /// <inheritdoc />
    public ValidationResult ValidatePercentage(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return ValidationResult.Success();
        }

        // Remove percentage sign if present
        var cleanValue = value.Replace("%", "").Trim();

        if (!decimal.TryParse(cleanValue, out var percentage))
        {
            return ValidationResult.Error(fieldName, $"{fieldName}: Invalid percentage value.");
        }

        if (percentage < 0 || percentage > 100)
        {
            return ValidationResult.Error(fieldName, $"{fieldName} must be between 0 and 100.");
        }

        return ValidationResult.Success();
    }

    /// <inheritdoc />
    public ValidationResult ValidateAll(params ValidationResult[] validations)
    {
        var errors = new List<string>();

        foreach (var validation in validations)
        {
            if (!validation.IsValid && validation.ErrorMessage != null)
            {
                errors.Add(validation.ErrorMessage);
            }
        }

        return ValidationResult.Errors(errors);
    }

    /// <summary>
    /// Tries to parse a date string using common formats.
    /// </summary>
    public static bool TryParseDate(string? value, out DateTime result)
    {
        result = default;

        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        return DateTime.TryParseExact(value.Trim(), DateFormats, CultureInfo.InvariantCulture,
            DateTimeStyles.None, out result) ||
            DateTime.TryParse(value.Trim(), out result);
    }

    /// <summary>
    /// Parses a currency string to decimal.
    /// </summary>
    public static bool TryParseCurrency(string? value, out decimal result)
    {
        result = 0;

        if (string.IsNullOrWhiteSpace(value))
        {
            return true; // Empty is valid, returns 0
        }

        var cleanValue = value.Replace("$", "").Replace(",", "").Trim();
        return decimal.TryParse(cleanValue, NumberStyles.Currency, CultureInfo.CurrentCulture, out result);
    }

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase)]
    private static partial Regex EmailRegex();

    [GeneratedRegex(@"[^\d]")]
    private static partial Regex PhoneDigitsRegex();

    [GeneratedRegex(@"^\d{5}(-\d{4})?$")]
    private static partial Regex ZipCodeRegex();
}
