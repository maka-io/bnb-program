namespace BnB.Core.Services;

/// <summary>
/// Defines the contract for converting currency amounts to words.
/// Used for printing checks where the amount must be written in words.
/// </summary>
public interface ICurrencyToWordsService
{
    /// <summary>
    /// Converts a decimal currency amount to its word representation.
    /// </summary>
    /// <param name="amount">The currency amount to convert.</param>
    /// <returns>The amount in words (e.g., "One Hundred Twenty-Three and 45/100").</returns>
    string ConvertToWords(decimal amount);

    /// <summary>
    /// Converts a decimal currency amount to its word representation with a specified currency name.
    /// </summary>
    /// <param name="amount">The currency amount to convert.</param>
    /// <param name="currencyName">The currency name (e.g., "Dollars").</param>
    /// <returns>The amount in words with currency (e.g., "One Hundred Twenty-Three Dollars and 45/100").</returns>
    string ConvertToWords(decimal amount, string currencyName);
}
