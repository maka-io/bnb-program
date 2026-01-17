using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Host Notification Report - lists upcoming arrivals grouped by property.
/// Used to notify hosts of upcoming guests.
/// </summary>
public class HostNotificationReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<Accommodation> _arrivals;

    public HostNotificationReport(DateTime startDate, DateTime endDate, List<Accommodation> arrivals, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _arrivals = arrivals;
    }

    public override string Title => $"Host Notification Report ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

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
            column.Item().PaddingBottom(10).Text($"Total Arrivals: {_arrivals.Count}")
                .FontSize(11).SemiBold();

            if (_arrivals.Count == 0)
            {
                column.Item().Text("No arrivals found for the selected date range.")
                    .FontSize(11).Italic();
                return;
            }

            // Group by property
            var byProperty = _arrivals.GroupBy(a => a.Property?.Location ?? "Unknown").OrderBy(g => g.Key);

            foreach (var propertyGroup in byProperty)
            {
                column.Item().PaddingTop(15).Text(propertyGroup.Key)
                    .FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);

                var property = propertyGroup.First().Property;
                if (property != null)
                {
                    column.Item().Text($"Host: {SafeString(property.FullName)} | Phone: {SafeString(property.PropertyPhone)}")
                        .FontSize(9).Italic();
                }

                column.Item().PaddingTop(5).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(70);  // Arrival
                        columns.ConstantColumn(70);  // Departure
                        columns.ConstantColumn(60);  // Conf #
                        columns.RelativeColumn(1.2f); // Guest Name
                        columns.ConstantColumn(50);  // # Guests
                        columns.RelativeColumn(1);   // Room Type
                        columns.RelativeColumn(1.5f); // Special Requests
                    });

                    table.Header(header =>
                    {
                        header.Cell().TableHeader().Text("Arrival").TableHeaderText();
                        header.Cell().TableHeader().Text("Departure").TableHeaderText();
                        header.Cell().TableHeader().Text("Conf#").TableHeaderText();
                        header.Cell().TableHeader().Text("Guest").TableHeaderText();
                        header.Cell().TableHeader().AlignCenter().Text("Guests").TableHeaderText();
                        header.Cell().TableHeader().Text("Room Type").TableHeaderText();
                        header.Cell().TableHeader().Text("Special Requests").TableHeaderText();
                    });

                    bool alternate = false;
                    foreach (var arrival in propertyGroup.OrderBy(a => a.ArrivalDate))
                    {
                        var guestName = $"{SafeString(arrival.LastName)}, {SafeString(arrival.FirstName)}";

                        table.Cell().TableCell(alternate).Text(FormatDate(arrival.ArrivalDate, "MM/dd/yy")).TableCellText();
                        table.Cell().TableCell(alternate).Text(FormatDate(arrival.DepartureDate, "MM/dd/yy")).TableCellText();
                        table.Cell().TableCell(alternate).Text(arrival.ConfirmationNumber.ToString()).TableCellText();
                        table.Cell().TableCell(alternate).Text(guestName).TableCellText();
                        table.Cell().TableCell(alternate).AlignCenter().Text(arrival.NumberInParty.ToString()).TableCellText();
                        table.Cell().TableCell(alternate).Text(SafeString(arrival.UnitNameDescription ?? arrival.UnitName)).TableCellText();
                        table.Cell().TableCell(alternate).Text(SafeString(arrival.SpecialRequests)).TableCellText();

                        alternate = !alternate;
                    }
                });

                column.Item().PaddingTop(3).Text($"Property Total: {propertyGroup.Count()} guests")
                    .FontSize(9).Italic();
            }
        });
    }
}
