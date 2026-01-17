using BnB.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Availability Report - shows room availability calendar for properties.
/// </summary>
public class AvailabilityReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<Property> _properties;
    private readonly List<RoomType> _roomTypes;
    private readonly List<Accommodation> _accommodations;

    public AvailabilityReport(DateTime startDate, DateTime endDate, List<Property> properties, List<RoomType> roomTypes, List<Accommodation> accommodations, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _properties = properties;
        _roomTypes = roomTypes;
        _accommodations = accommodations;
    }

    public override string Title => $"Availability Calendar ({_startDate:MM/dd/yyyy} - {_endDate:MM/dd/yyyy})";

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
            if (_roomTypes.Count == 0)
            {
                column.Item().Text("No rooms found.")
                    .FontSize(11).Italic();
                return;
            }

            // Determine how many days to show per row (max ~14 days for landscape letter)
            var totalDays = (_endDate - _startDate).Days + 1;
            var daysPerPage = Math.Min(14, totalDays);
            var currentStartDay = 0;

            while (currentStartDay < totalDays)
            {
                var daysInThisSection = Math.Min(daysPerPage, totalDays - currentStartDay);
                ComposeCalendarSection(column, currentStartDay, daysInThisSection);
                currentStartDay += daysInThisSection;

                if (currentStartDay < totalDays)
                {
                    column.Item().PageBreak();
                }
            }

            // Legend
            column.Item().PaddingTop(20).Row(row =>
            {
                row.AutoItem().Width(20).Height(12).Background("#90EE90").Border(1).BorderColor("#888888");
                row.AutoItem().PaddingLeft(5).Text("Available").FontSize(8);
                row.AutoItem().PaddingLeft(15).Width(20).Height(12).Background("#F08080").Border(1).BorderColor("#888888");
                row.AutoItem().PaddingLeft(5).Text("Booked").FontSize(8);
                row.AutoItem().PaddingLeft(15).Width(20).Height(12).Background("#D3D3D3").Border(1).BorderColor("#888888");
                row.AutoItem().PaddingLeft(5).Text("Weekend").FontSize(8);
            });
        });
    }

    private void ComposeCalendarSection(ColumnDescriptor column, int startDayOffset, int daysToShow)
    {
        var sectionStart = _startDate.AddDays(startDayOffset);

        column.Item().Table(table =>
        {
            // Define columns: Property name + Room type + day columns
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(100); // Property column
                columns.ConstantColumn(80);  // Room type column
                for (int i = 0; i < daysToShow; i++)
                {
                    columns.RelativeColumn(1);
                }
            });

            // Header row with dates
            table.Header(header =>
            {
                header.Cell().TableHeader().Text("Property").TableHeaderText();
                header.Cell().TableHeader().Text("Room").TableHeaderText();
                for (int i = 0; i < daysToShow; i++)
                {
                    var date = sectionStart.AddDays(i);
                    var isWeekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
                    var cell = header.Cell().TableHeader();
                    if (isWeekend)
                        cell = cell.Background("#b0b0b0");
                    cell.AlignCenter().Text(date.ToString("M/d\nddd")).FontSize(7).FontColor("#ffffff");
                }
            });

            // Room type rows
            bool alternate = false;
            string? lastPropertyLocation = null;

            foreach (var roomType in _roomTypes.OrderBy(r => r.PropertyAccountNumber).ThenBy(r => r.Name))
            {
                var property = _properties.FirstOrDefault(p => p.AccountNumber == roomType.PropertyAccountNumber);
                if (property == null) continue;

                var roomAccoms = _accommodations
                    .Where(a => a.PropertyAccountNumber == roomType.PropertyAccountNumber
                             && a.UnitName == roomType.Name)
                    .ToList();

                // Only show property name on first row for that property
                if (lastPropertyLocation != property.Location)
                {
                    table.Cell().TableCell(alternate).Text(SafeString(property.Location)).FontSize(8);
                    lastPropertyLocation = property.Location;
                }
                else
                {
                    table.Cell().TableCell(alternate).Text("");
                }

                table.Cell().TableCell(alternate).Text(SafeString(roomType.Description ?? roomType.Name)).FontSize(8);

                for (int i = 0; i < daysToShow; i++)
                {
                    var date = sectionStart.AddDays(i);
                    var isWeekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;

                    // Check if room is booked on this date
                    var booking = roomAccoms
                        .FirstOrDefault(a => a.ArrivalDate <= date && a.DepartureDate > date);

                    var cell = table.Cell();
                    if (booking != null)
                    {
                        var initials = $"{booking.FirstName?.FirstOrDefault()}{booking.LastName?.FirstOrDefault()}";
                        cell.Background("#F08080").AlignCenter().AlignMiddle()
                            .Text(!string.IsNullOrEmpty(initials) ? initials : "X").FontSize(7).Bold();
                    }
                    else if (isWeekend)
                    {
                        cell.Background("#D3D3D3");
                    }
                    else
                    {
                        cell.Background("#90EE90");
                    }
                }

                alternate = !alternate;
            }
        });

        // Date range label
        var sectionEnd = sectionStart.AddDays(daysToShow - 1);
        column.Item().PaddingTop(5).Text($"{sectionStart:MMMM d, yyyy} - {sectionEnd:MMMM d, yyyy}").FontSize(9).Italic();
    }
}
