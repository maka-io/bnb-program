using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Guest Confirmation Report - generates confirmation letter for guest bookings
/// Migrated from CONF.RPT
/// </summary>
public class ConfirmationReport : BaseReport
{
    private readonly Guest _guest;
    private readonly IEnumerable<Accommodation> _accommodations;
    private readonly Payment? _payment;
    private readonly string _confirmationType;
    private readonly string _confirmationTo;
    private readonly decimal _totalDeposit;
    private readonly decimal _totalPrepayment;
    private readonly string? _depositCheckNum;
    private readonly string? _prepayCheckNum;

    public override string Title => $"Confirmation #{_guest.ConfirmationNumber}";

    public ConfirmationReport(
        Guest guest,
        IEnumerable<Accommodation> accommodations,
        Payment? payment = null,
        string confirmationType = "Standard",
        string confirmationTo = "Guest",
        decimal totalDeposit = 0,
        decimal totalPrepayment = 0,
        string? depositCheckNum = null,
        string? prepayCheckNum = null,
        CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _guest = guest;
        _accommodations = accommodations.ToList();
        _payment = payment;
        _confirmationType = confirmationType;
        _confirmationTo = confirmationTo;
        _totalDeposit = totalDeposit;
        _totalPrepayment = totalPrepayment;
        _depositCheckNum = depositCheckNum;
        _prepayCheckNum = prepayCheckNum;
    }

    public override void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.Letter);
            page.Margin(DefaultMargin);
            page.DefaultTextStyle(x => x.FontSize(BodyFontSize).FontFamily("Arial"));

            page.Header().Element(ComposeReportHeader);
            page.Content().Element(ComposeContent);
            page.Footer().Element(ComposeFooter);
        });
    }

    private void ComposeReportHeader(IContainer container)
    {
        container.Column(column =>
        {
            // Company Header with Logo
            column.Item().Row(row =>
            {
                // Logo on the left (if available)
                if (CompanyInfo?.Logo != null && CompanyInfo.Logo.Length > 0)
                {
                    row.ConstantItem(80).Height(60).Image(CompanyInfo.Logo, ImageScaling.FitArea);
                    row.ConstantItem(15); // Spacing
                }

                row.RelativeItem().Column(col =>
                {
                    col.Item().Text(CompanyName)
                        .FontSize(18)
                        .Bold()
                        .FontColor(ReportStyles.PrimaryColor);

                    // Address line (if available)
                    if (CompanyInfo != null && !string.IsNullOrWhiteSpace(CompanyInfo.Address))
                    {
                        var addressLine = CompanyInfo.Address;
                        if (!string.IsNullOrWhiteSpace(CompanyInfo.City))
                            addressLine += $", {CompanyInfo.City}";
                        if (!string.IsNullOrWhiteSpace(CompanyInfo.State))
                            addressLine += $", {CompanyInfo.State}";
                        if (!string.IsNullOrWhiteSpace(CompanyInfo.ZipCode))
                            addressLine += $" {CompanyInfo.ZipCode}";
                        col.Item().Text(addressLine).FontSize(SmallFontSize);
                    }

                    // Contact info
                    if (CompanyInfo != null)
                    {
                        var contactParts = new List<string>();
                        if (!string.IsNullOrWhiteSpace(CompanyInfo.Phone))
                            contactParts.Add($"Phone: {CompanyInfo.Phone}");
                        if (!string.IsNullOrWhiteSpace(CompanyInfo.Email))
                            contactParts.Add(CompanyInfo.Email);
                        if (contactParts.Count > 0)
                            col.Item().Text(string.Join(" | ", contactParts)).FontSize(SmallFontSize);
                    }

                    col.Item().PaddingTop(5).Text("Reservation Confirmation")
                        .FontSize(14)
                        .SemiBold();
                });

                row.ConstantItem(150).AlignRight().Column(col =>
                {
                    col.Item().Text($"Confirmation #: {_guest.ConfirmationNumber}")
                        .FontSize(12)
                        .Bold();

                    col.Item().Text($"Date: {ReportDate:MM/dd/yyyy}")
                        .FontSize(10);

                    if (_guest.Revision.HasValue && _guest.Revision != 0)
                    {
                        col.Item().Text("REVISED")
                            .FontSize(10)
                            .Bold()
                            .FontColor("#cc0000");
                    }
                });
            });

            column.Item().PaddingVertical(10).LineHorizontal(1).LineColor(ReportStyles.BorderColor);
        });
    }

    private void ComposeContent(IContainer container)
    {
        container.Column(column =>
        {
            // Guest Information
            column.Item().Element(ComposeGuestInfo);

            column.Item().Height(15);

            // Accommodation Details
            column.Item().Element(ComposeAccommodationDetails);

            column.Item().Height(15);

            // Payment Summary
            column.Item().Element(ComposePaymentSummary);

            column.Item().Height(20);

            // Terms and Conditions
            column.Item().Element(ComposeTermsAndConditions);
        });
    }

    private void ComposeGuestInfo(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Text("Guest Information").FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().PaddingTop(5);

            column.Item().Border(1).BorderColor(ReportStyles.BorderColor).Padding(10).Column(innerCol =>
            {
                innerCol.Item().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"{_guest.FirstName} {_guest.LastName}").Bold();
                        if (!string.IsNullOrEmpty(_guest.BusinessAddress))
                            col.Item().Text(_guest.BusinessAddress);
                        if (!string.IsNullOrEmpty(_guest.Address))
                            col.Item().Text(_guest.Address);
                        if (!string.IsNullOrEmpty(_guest.City) || !string.IsNullOrEmpty(_guest.State))
                            col.Item().Text($"{SafeString(_guest.City)}, {SafeString(_guest.State)} {SafeString(_guest.ZipCode)}");
                    });

                    row.RelativeItem().Column(col =>
                    {
                        if (!string.IsNullOrEmpty(_guest.HomePhone))
                            col.Item().Text($"Home: {_guest.HomePhone}");
                        if (!string.IsNullOrEmpty(_guest.BusinessPhone))
                            col.Item().Text($"Business: {_guest.BusinessPhone}");
                        if (!string.IsNullOrEmpty(_guest.Email))
                            col.Item().Text($"Email: {_guest.Email}");
                        if (!string.IsNullOrEmpty(_guest.TravelingWith))
                            col.Item().Text($"Traveling with: {_guest.TravelingWith}");
                    });
                });
            });
        });
    }

    private void ComposeAccommodationDetails(IContainer container)
    {
        var accommodationList = _accommodations.ToList();
        if (!accommodationList.Any()) return;

        container.Column(column =>
        {
            column.Item().Text("Accommodation Details").FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().PaddingTop(5);

            // Table for accommodations
            column.Item().Table(table =>
            {
                // Define columns
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(1.3f);  // Property/Location
                    columns.ConstantColumn(65);    // Arrival
                    columns.ConstantColumn(65);    // Departure
                    columns.ConstantColumn(40);    // Nights
                    columns.ConstantColumn(40);    // Guests
                    columns.ConstantColumn(60);    // Rate
                    columns.ConstantColumn(55);    // Tax
                    columns.ConstantColumn(65);    // Total
                });

                // Header row
                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Property").TableHeaderText();
                    header.Cell().TableHeader().Text("Arrival").TableHeaderText();
                    header.Cell().TableHeader().Text("Departure").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Guests").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Rate").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Tax").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Total").TableHeaderText();
                });

                // Data rows
                bool alternate = false;
                foreach (var accom in accommodationList)
                {
                    var total = accom.DailyGrossRate * accom.NumberOfNights;
                    var totalWithTax = accom.TotalGrossWithTax;

                    table.Cell().TableCell(alternate).Text(SafeString(accom.Location)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(accom.ArrivalDate)).TableCellText();
                    table.Cell().TableCell(alternate).Text(FormatDate(accom.DepartureDate)).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(accom.NumberOfNights.ToString()).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(accom.NumberInParty?.ToString() ?? "").TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.DailyGrossRate)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(accom.TotalTax)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(totalWithTax)).TableCellText();

                    alternate = !alternate;
                }

                // Totals row
                var grandTotal = accommodationList.Sum(a => a.TotalGrossWithTax);
                var totalTax = accommodationList.Sum(a => a.TotalTax);
                var subtotal = grandTotal - totalTax;

                table.Cell().ColumnSpan(5).TotalsRow().AlignRight().Text("Subtotal:").Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(subtotal));
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalTax));
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(grandTotal)).Bold();
            });

            // Add reservation fee if applicable
            if (_guest.ReservationFee.HasValue && _guest.ReservationFee > 0)
            {
                column.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem();
                    row.ConstantItem(200).AlignRight().Text($"Reservation Fee: {FormatCurrency(_guest.ReservationFee)}");
                });
            }

        });
    }

    private void ComposePaymentSummary(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Text("Payment Summary").FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().PaddingTop(5);

            column.Item().Border(1).BorderColor(ReportStyles.BorderColor).Padding(10).Column(innerCol =>
            {
                var grandTotal = _accommodations.Sum(a => a.TotalGrossWithTax);
                if (_guest.ReservationFee.HasValue)
                    grandTotal += _guest.ReservationFee.Value;

                // Credits section
                decimal totalCredits = 0;

                if (_totalDeposit > 0)
                {
                    innerCol.Item().Row(row =>
                    {
                        row.RelativeItem().Text($"Deposit Received{(!string.IsNullOrEmpty(_depositCheckNum) ? $" (Check #{_depositCheckNum})" : "")}:");
                        row.ConstantItem(100).AlignRight().Text(FormatCurrency(_totalDeposit));
                    });
                    totalCredits += _totalDeposit;
                }

                if (_totalPrepayment > 0)
                {
                    innerCol.Item().Row(row =>
                    {
                        row.RelativeItem().Text($"Prepayment Received{(!string.IsNullOrEmpty(_prepayCheckNum) ? $" (Check #{_prepayCheckNum})" : "")}:");
                        row.ConstantItem(100).AlignRight().Text(FormatCurrency(_totalPrepayment));
                    });
                    totalCredits += _totalPrepayment;
                }

                if (_payment?.DefaultCommission > 0)
                {
                    innerCol.Item().Row(row =>
                    {
                        row.RelativeItem().Text("Travel Agent Commission:");
                        row.ConstantItem(100).AlignRight().Text(FormatCurrency(_payment.DefaultCommission));
                    });
                    totalCredits += _payment.DefaultCommission ?? 0;
                }

                if (_payment?.OtherCredit > 0)
                {
                    innerCol.Item().Row(row =>
                    {
                        row.RelativeItem().Text("Other Credit:");
                        row.ConstantItem(100).AlignRight().Text(FormatCurrency(_payment.OtherCredit));
                    });
                    totalCredits += _payment.OtherCredit ?? 0;
                }

                innerCol.Item().PaddingVertical(5).LineHorizontal(1).LineColor(ReportStyles.BorderColor);

                // Total and Balance Due
                innerCol.Item().Row(row =>
                {
                    row.RelativeItem().Text("Total Charges:").Bold();
                    row.ConstantItem(100).AlignRight().Text(FormatCurrency(grandTotal)).Bold();
                });

                innerCol.Item().Row(row =>
                {
                    row.RelativeItem().Text("Total Credits:");
                    row.ConstantItem(100).AlignRight().Text(FormatCurrency(totalCredits));
                });

                var balanceDue = grandTotal - totalCredits;
                innerCol.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Text("Balance Due:").FontSize(12).Bold();
                    row.ConstantItem(100).AlignRight().Text(FormatCurrency(balanceDue)).FontSize(12).Bold();
                });
            });
        });
    }

    private void ComposeTermsAndConditions(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Text("Terms and Conditions").FontSize(10).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().PaddingTop(3);

            column.Item().Text(text =>
            {
                text.Span("Cancellation Policy: ").Bold().FontSize(8);
                text.Span("Cancellations made 30 or more days prior to arrival will receive a full refund less a $25 processing fee. " +
                         "Cancellations made within 30 days of arrival may result in forfeiture of deposit.").FontSize(8);
            });

            column.Item().PaddingTop(3).Text(text =>
            {
                text.Span("Check-in/Check-out: ").Bold().FontSize(8);
                text.Span("Check-in time is 3:00 PM. Check-out time is 11:00 AM. " +
                         "Please contact your host directly if you need to arrange different times.").FontSize(8);
            });

            column.Item().PaddingTop(10).Text($"Thank you for choosing {CompanyName}!")
                .FontSize(10)
                .Italic()
                .FontColor(ReportStyles.PrimaryColor);
        });
    }
}
