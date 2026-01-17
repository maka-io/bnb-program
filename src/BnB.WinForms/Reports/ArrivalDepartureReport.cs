using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Arrival/Departure Daily Report - shows arrivals and departures for a specific date.
/// </summary>
public class ArrivalDepartureReport : BaseReport
{
    private readonly DateTime _date;
    private readonly List<Accommodation> _arrivals;
    private readonly List<Accommodation> _departures;

    public ArrivalDepartureReport(DateTime date, List<Accommodation> arrivals, List<Accommodation> departures, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _date = date;
        _arrivals = arrivals;
        _departures = departures;
    }

    public override string Title => $"Arrivals/Departures for {_date:MM/dd/yyyy}";

    public override void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.Letter.Landscape());
            page.Margin(DefaultMargin);
            page.DefaultTextStyle(x => x.FontSize(BodyFontSize).FontFamily("Arial"));

            page.Header().Element(ComposeHeader);
            page.Content().Element(ComposeContent);
            page.Footer().Element(ComposeFooter);
        });
    }

    private void ComposeContent(IContainer container)
    {
        container.Column(column =>
        {
            // Arrivals Section
            column.Item().Text("ARRIVALS")
                .FontSize(14).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().Text($"Total: {_arrivals.Count}").FontSize(10).SemiBold();

            if (_arrivals.Count == 0)
            {
                column.Item().PaddingVertical(10).Text("No arrivals scheduled for this date.")
                    .FontSize(10).Italic();
            }
            else
            {
                column.Item().PaddingTop(5).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(60);  // Conf #
                        columns.RelativeColumn(1.2f); // Guest
                        columns.RelativeColumn(1.2f); // Property
                        columns.ConstantColumn(50);  // Nights
                        columns.ConstantColumn(50);  // Guests
                        columns.ConstantColumn(70);  // Departs
                        columns.RelativeColumn(1.5f); // Notes
                    });

                    table.Header(header =>
                    {
                        header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                        header.Cell().TableHeader().Text("Guest").TableHeaderText();
                        header.Cell().TableHeader().Text("Property").TableHeaderText();
                        header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                        header.Cell().TableHeader().AlignCenter().Text("Guests").TableHeaderText();
                        header.Cell().TableHeader().Text("Departs").TableHeaderText();
                        header.Cell().TableHeader().Text("Notes").TableHeaderText();
                    });

                    bool alternate = false;
                    foreach (var arr in _arrivals)
                    {
                        table.Cell().TableCell(alternate).Text(arr.ConfirmationNumber.ToString()).TableCellText();
                        table.Cell().TableCell(alternate).Text($"{SafeString(arr.FirstName)} {SafeString(arr.LastName)}").TableCellText();
                        table.Cell().TableCell(alternate).Text(SafeString(arr.Property?.Location)).TableCellText();
                        table.Cell().TableCell(alternate).AlignCenter().Text(arr.NumberOfNights.ToString()).TableCellText();
                        table.Cell().TableCell(alternate).AlignCenter().Text(arr.NumberInParty.ToString()).TableCellText();
                        table.Cell().TableCell(alternate).Text(FormatDate(arr.DepartureDate, "MM/dd/yy")).TableCellText();
                        table.Cell().TableCell(alternate).Text(SafeString(arr.SpecialRequests)).TableCellText();
                        alternate = !alternate;
                    }
                });
            }

            // Spacing between sections
            column.Item().PaddingTop(25);

            // Departures Section
            column.Item().Text("DEPARTURES")
                .FontSize(14).Bold().FontColor(ReportStyles.PrimaryColor);
            column.Item().Text($"Total: {_departures.Count}").FontSize(10).SemiBold();

            if (_departures.Count == 0)
            {
                column.Item().PaddingVertical(10).Text("No departures scheduled for this date.")
                    .FontSize(10).Italic();
            }
            else
            {
                column.Item().PaddingTop(5).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(60);  // Conf #
                        columns.RelativeColumn(1.2f); // Guest
                        columns.RelativeColumn(1.2f); // Property
                        columns.ConstantColumn(70);  // Arrived
                        columns.ConstantColumn(50);  // Nights
                        columns.ConstantColumn(80);  // Balance
                    });

                    table.Header(header =>
                    {
                        header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                        header.Cell().TableHeader().Text("Guest").TableHeaderText();
                        header.Cell().TableHeader().Text("Property").TableHeaderText();
                        header.Cell().TableHeader().Text("Arrived").TableHeaderText();
                        header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                        header.Cell().TableHeader().AlignRight().Text("Balance").TableHeaderText();
                    });

                    bool alternate = false;
                    decimal totalBalance = 0;
                    foreach (var dep in _departures)
                    {
                        var balance = dep.BalanceDue ?? 0;
                        table.Cell().TableCell(alternate).Text(dep.ConfirmationNumber.ToString()).TableCellText();
                        table.Cell().TableCell(alternate).Text($"{SafeString(dep.FirstName)} {SafeString(dep.LastName)}").TableCellText();
                        table.Cell().TableCell(alternate).Text(SafeString(dep.Property?.Location)).TableCellText();
                        table.Cell().TableCell(alternate).Text(FormatDate(dep.ArrivalDate, "MM/dd/yy")).TableCellText();
                        table.Cell().TableCell(alternate).AlignCenter().Text(dep.NumberOfNights.ToString()).TableCellText();
                        table.Cell().CurrencyCell(alternate).Text(FormatCurrency(balance)).TableCellText();
                        totalBalance += balance;
                        alternate = !alternate;
                    }

                    // Total row
                    table.Cell().ColumnSpan(5).TotalsRow().AlignRight().Text("Total Balance Due:").Bold();
                    table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalBalance)).Bold();
                });
            }
        });
    }
}
