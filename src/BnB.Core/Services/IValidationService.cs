using System.ComponentModel.DataAnnotations;

namespace BnB.Core.Services;

/// <summary>
/// Defines the contract for input validation operations.
/// </summary>
public interface IValidationService
{
    /// <summary>
    /// Validates the specified value as a date.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateDate(string? value, string fieldName);

    /// <summary>
    /// Validates the specified value as a required date.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateRequiredDate(string? value, string fieldName);

    /// <summary>
    /// Validates the specified value as currency.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <param name="allowNegative">Whether negative values are allowed.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateCurrency(string? value, string fieldName, bool allowNegative = false);

    /// <summary>
    /// Validates the specified value as a required currency.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <param name="allowNegative">Whether negative values are allowed.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateRequiredCurrency(string? value, string fieldName, bool allowNegative = false);

    /// <summary>
    /// Validates the specified value as a number.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <param name="allowNegative">Whether negative values are allowed.</param>
    /// <param name="allowDecimal">Whether decimal values are allowed.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateNumber(string? value, string fieldName, bool allowNegative = false, bool allowDecimal = true);

    /// <summary>
    /// Validates the specified value as a required number.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <param name="allowNegative">Whether negative values are allowed.</param>
    /// <param name="allowDecimal">Whether decimal values are allowed.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateRequiredNumber(string? value, string fieldName, bool allowNegative = false, bool allowDecimal = true);

    /// <summary>
    /// Validates that the specified value is not empty.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateRequired(string? value, string fieldName);

    /// <summary>
    /// Validates that the specified value does not exceed the maximum length.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <param name="maxLength">The maximum allowed length.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateMaxLength(string? value, string fieldName, int maxLength);

    /// <summary>
    /// Validates the specified value as an email address.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateEmail(string? value, string fieldName);

    /// <summary>
    /// Validates the specified value as a phone number.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidatePhone(string? value, string fieldName);

    /// <summary>
    /// Validates the specified value as a ZIP/postal code.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateZipCode(string? value, string fieldName);

    /// <summary>
    /// Validates that a date range is valid (start date before end date).
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="startFieldName">The name of the start date field.</param>
    /// <param name="endFieldName">The name of the end date field.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidateDateRange(DateTime? startDate, DateTime? endDate, string startFieldName, string endFieldName);

    /// <summary>
    /// Validates that a percentage is within valid range (0-100).
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="fieldName">The name of the field being validated.</param>
    /// <returns>A validation result.</returns>
    ValidationResult ValidatePercentage(string? value, string fieldName);

    /// <summary>
    /// Validates multiple fields and returns all validation errors.
    /// </summary>
    /// <param name="validations">Collection of validation results to check.</param>
    /// <returns>A combined validation result containing all errors.</returns>
    ValidationResult ValidateAll(params ValidationResult[] validations);
}

/// <summary>
/// Validation result that can contain multiple error messages.
/// </summary>
public class ValidationResult
{
    /// <summary>
    /// Gets whether the validation passed.
    /// </summary>
    public bool IsValid { get; }

    /// <summary>
    /// Gets the error message if validation failed.
    /// </summary>
    public string? ErrorMessage { get; }

    /// <summary>
    /// Gets the name of the field that failed validation.
    /// </summary>
    public string? FieldName { get; }

    /// <summary>
    /// Gets all error messages if multiple validations failed.
    /// </summary>
    public IReadOnlyList<string> AllErrors { get; }

    private ValidationResult(bool isValid, string? fieldName = null, string? errorMessage = null, IReadOnlyList<string>? allErrors = null)
    {
        IsValid = isValid;
        FieldName = fieldName;
        ErrorMessage = errorMessage;
        AllErrors = allErrors ?? (errorMessage != null ? new[] { errorMessage } : Array.Empty<string>());
    }

    /// <summary>
    /// Creates a successful validation result.
    /// </summary>
    public static ValidationResult Success() => new(true);

    /// <summary>
    /// Creates a failed validation result.
    /// </summary>
    public static ValidationResult Error(string fieldName, string errorMessage) => new(false, fieldName, errorMessage);

    /// <summary>
    /// Creates a combined validation result from multiple errors.
    /// </summary>
    public static ValidationResult Errors(IReadOnlyList<string> errors)
    {
        if (errors.Count == 0)
            return Success();

        return new ValidationResult(false, null, errors[0], errors);
    }
}
