namespace BnB.Core.Services;

/// <summary>
/// Service for converting currency amounts to their word representation.
/// Used for check printing where amounts must be written in words.
/// </summary>
public class CurrencyToWordsService : ICurrencyToWordsService
{
    private static readonly string[] Ones =
    {
        "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
        "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
        "Seventeen", "Eighteen", "Nineteen"
    };

    private static readonly string[] Tens =
    {
        "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
    };

    private static readonly string[] Thousands =
    {
        "", "Thousand", "Million", "Billion", "Trillion"
    };

    /// <inheritdoc />
    public string ConvertToWords(decimal amount)
    {
        return ConvertToWords(amount, "Dollars");
    }

    /// <inheritdoc />
    public string ConvertToWords(decimal amount, string currencyName)
    {
        if (amount < 0)
        {
            return "Negative " + ConvertToWords(Math.Abs(amount), currencyName);
        }

        if (amount == 0)
        {
            return $"Zero {currencyName} and 00/100";
        }

        // Separate dollars and cents
        long dollars = (long)Math.Truncate(amount);
        int cents = (int)Math.Round((amount - dollars) * 100);

        // Handle case where rounding cents gives 100
        if (cents == 100)
        {
            dollars++;
            cents = 0;
        }

        string dollarsInWords = ConvertWholeNumberToWords(dollars);
        string centsString = cents.ToString("D2");

        if (string.IsNullOrEmpty(dollarsInWords))
        {
            dollarsInWords = "Zero";
        }

        // Format: "One Hundred Twenty-Three Dollars and 45/100"
        // If only one dollar, use singular "Dollar"
        string currencyWord = dollars == 1 ? currencyName.TrimEnd('s') : currencyName;

        return $"{dollarsInWords} {currencyWord} and {centsString}/100";
    }

    /// <summary>
    /// Converts a whole number to its word representation.
    /// </summary>
    /// <param name="number">The number to convert (0 to 999,999,999,999,999).</param>
    /// <returns>The number in words.</returns>
    private static string ConvertWholeNumberToWords(long number)
    {
        if (number == 0)
        {
            return "";
        }

        if (number < 0)
        {
            return "Negative " + ConvertWholeNumberToWords(Math.Abs(number));
        }

        var words = new List<string>();
        int groupIndex = 0;

        while (number > 0)
        {
            int group = (int)(number % 1000);
            number /= 1000;

            if (group > 0)
            {
                string groupWords = ConvertGroupToWords(group);
                if (groupIndex > 0)
                {
                    groupWords += " " + Thousands[groupIndex];
                }
                words.Insert(0, groupWords);
            }

            groupIndex++;
        }

        return string.Join(" ", words);
    }

    /// <summary>
    /// Converts a group of up to 3 digits to words.
    /// </summary>
    /// <param name="number">A number from 0 to 999.</param>
    /// <returns>The number in words.</returns>
    private static string ConvertGroupToWords(int number)
    {
        if (number == 0)
        {
            return "";
        }

        var parts = new List<string>();

        // Hundreds
        int hundreds = number / 100;
        if (hundreds > 0)
        {
            parts.Add(Ones[hundreds] + " Hundred");
        }

        // Tens and ones
        int remainder = number % 100;
        if (remainder > 0)
        {
            if (remainder < 20)
            {
                parts.Add(Ones[remainder]);
            }
            else
            {
                int tensDigit = remainder / 10;
                int onesDigit = remainder % 10;

                if (onesDigit > 0)
                {
                    parts.Add(Tens[tensDigit] + "-" + Ones[onesDigit]);
                }
                else
                {
                    parts.Add(Tens[tensDigit]);
                }
            }
        }

        return string.Join(" ", parts);
    }
}
