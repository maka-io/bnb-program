using BnB.Core.Models;
using BnB.Core.Services;
using BnB.WinForms.Services;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace BnB.WinForms.Reports;

/// <summary>
/// Trend Report - shows booking and revenue trends over time.
/// </summary>
public class TrendReport : BaseReport
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;
    private readonly List<TrendDataItem> _trendData;
    private readonly byte[]? _revenueChartImage;
    private readonly byte[]? _bookingsChartImage;
    private readonly byte[]? _avgRevenueChartImage;

    public TrendReport(DateTime startDate, DateTime endDate, List<TrendDataItem> trendData, CompanyInfo? companyInfo = null)
    {
        CompanyInfo = companyInfo;
        _startDate = startDate;
        _endDate = endDate;
        _trendData = trendData;

        // Generate chart images
        if (_trendData.Count > 0)
        {
            _revenueChartImage = GenerateRevenueChart();
            _bookingsChartImage = GenerateBookingsChart();

            // Only show monthly average bar chart if range is 2+ years
            var rangeInYears = (_endDate - _startDate).TotalDays / 365.25;
            if (rangeInYears >= 2)
            {
                _avgRevenueChartImage = GenerateAvgRevenueChart();
            }
        }
    }

    private byte[] GenerateRevenueChart()
    {
        var chartService = new ChartService();
        var dataPoints = _trendData.Select(t => new ChartDataPoint
        {
            Label = t.MonthLabel,
            Value = (double)t.TotalRevenue
        });

        var chartData = chartService.CreateLineChart("Revenue Trend", dataPoints);
        chartData.YAxisTitle = "Revenue ($)";
        chartData.XAxisTitle = "Month";

        return chartService.ExportToImage(chartData, 700, 300);
    }

    private byte[] GenerateBookingsChart()
    {
        var chartService = new ChartService();
        var dataPoints = _trendData.Select(t => new ChartDataPoint
        {
            Label = t.MonthLabel,
            Value = t.BookingCount
        });

        var chartData = chartService.CreateLineChart("Bookings Trend", dataPoints);
        chartData.YAxisTitle = "Number of Bookings";
        chartData.XAxisTitle = "Month";

        return chartService.ExportToImage(chartData, 700, 300);
    }

    private byte[] GenerateAvgRevenueChart()
    {
        var chartService = new ChartService();

        // Group by month number (1-12) and calculate statistics for box plot
        // Uses total monthly revenue (not per booking)
        var monthlyGroups = _trendData
            .GroupBy(t => t.Month)
            .OrderBy(g => g.Key)
            .ToList();

        var boxPlotData = new BoxPlotData
        {
            Title = "Monthly Revenue Distribution by Month",
            XAxisTitle = "Month",
            YAxisTitle = "Total Revenue ($)"
        };

        foreach (var group in monthlyGroups)
        {
            var values = group
                .Select(t => (double)t.TotalRevenue)
                .OrderBy(v => v)
                .ToList();

            if (values.Count == 0)
                continue;

            var dataPoint = new BoxPlotDataPoint
            {
                Label = new DateTime(2000, group.Key, 1).ToString("MMM"),
                Min = values.First(),
                Max = values.Last(),
                Median = GetPercentile(values, 50),
                Q1 = GetPercentile(values, 25),
                Q3 = GetPercentile(values, 75)
            };

            boxPlotData.DataPoints.Add(dataPoint);
        }

        return chartService.ExportBoxPlotToImage(boxPlotData, 700, 300);
    }

    private static double GetPercentile(List<double> sortedValues, double percentile)
    {
        if (sortedValues.Count == 0)
            return 0;
        if (sortedValues.Count == 1)
            return sortedValues[0];

        var index = (percentile / 100.0) * (sortedValues.Count - 1);
        var lower = (int)Math.Floor(index);
        var upper = (int)Math.Ceiling(index);

        if (lower == upper)
            return sortedValues[lower];

        var fraction = index - lower;
        return sortedValues[lower] + (sortedValues[upper] - sortedValues[lower]) * fraction;
    }

    public override string Title => $"Booking Trends Report ({_startDate:MMM yyyy} - {_endDate:MMM yyyy})";

    public override void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.Letter);
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
            if (_trendData.Count == 0)
            {
                column.Item().Text("No trend data available for the selected date range.")
                    .FontSize(11).Italic();
                return;
            }

            // Revenue Trend Chart
            if (_revenueChartImage != null)
            {
                column.Item().Text("Revenue Trend").FontSize(12).Bold();
                column.Item().PaddingTop(5).PaddingBottom(10).AlignCenter()
                    .Image(_revenueChartImage).FitWidth();
            }

            // Bookings Trend Chart
            if (_bookingsChartImage != null)
            {
                column.Item().Text("Bookings Trend").FontSize(12).Bold();
                column.Item().PaddingTop(5).PaddingBottom(10).AlignCenter()
                    .Image(_bookingsChartImage).FitWidth();
            }

            // Revenue Box Plot (shows min, Q1, median, Q3, max by month)
            if (_avgRevenueChartImage != null)
            {
                column.Item().Text("Monthly Revenue Distribution (Min/Max Range)").FontSize(12).Bold();
                column.Item().PaddingTop(5).PaddingBottom(15).AlignCenter()
                    .Image(_avgRevenueChartImage).FitWidth();
            }

            // Overall Summary
            var totalBookings = _trendData.Sum(t => t.BookingCount);
            var totalRevenue = _trendData.Sum(t => t.TotalRevenue);
            var totalNights = _trendData.Sum(t => t.TotalNights);
            var avgRate = totalNights > 0 ? totalRevenue / totalNights : 0;

            column.Item().Border(1).BorderColor(ReportStyles.BorderColor).Padding(10).Column(summary =>
            {
                summary.Item().Text("Period Summary").FontSize(12).Bold().FontColor(ReportStyles.PrimaryColor);
                summary.Item().PaddingTop(10).Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"Total Bookings: {totalBookings:N0}");
                        col.Item().Text($"Total Nights: {totalNights:N0}");
                    });
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text($"Total Revenue: {totalRevenue:C2}");
                        col.Item().Text($"Average Nightly Rate: {avgRate:C2}");
                    });
                });
            });

            column.Item().PaddingTop(20);

            // Monthly Detail Table
            column.Item().Text("Monthly Breakdown").FontSize(12).Bold();
            column.Item().PaddingTop(10).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(1);   // Month
                    columns.ConstantColumn(80);  // Bookings
                    columns.ConstantColumn(80);  // Nights
                    columns.ConstantColumn(100); // Revenue
                    columns.ConstantColumn(90);  // Avg Rate
                });

                table.Header(header =>
                {
                    header.Cell().TableHeader().Text("Month").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Bookings").TableHeaderText();
                    header.Cell().TableHeader().AlignCenter().Text("Nights").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Revenue").TableHeaderText();
                    header.Cell().TableHeader().AlignRight().Text("Avg Rate").TableHeaderText();
                });

                bool alternate = false;

                foreach (var item in _trendData)
                {
                    var monthAvgRate = item.TotalNights > 0 ? item.TotalRevenue / item.TotalNights : 0;

                    table.Cell().TableCell(alternate).Text(item.MonthLabel).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(item.BookingCount.ToString("N0")).TableCellText();
                    table.Cell().TableCell(alternate).AlignCenter().Text(item.TotalNights.ToString("N0")).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(item.TotalRevenue)).TableCellText();
                    table.Cell().CurrencyCell(alternate).Text(FormatCurrency(monthAvgRate)).TableCellText();

                    alternate = !alternate;
                }

                // Total row
                table.Cell().TotalsRow().Text("Totals").Bold();
                table.Cell().TotalsRow().AlignCenter().Text(totalBookings.ToString("N0")).Bold();
                table.Cell().TotalsRow().AlignCenter().Text(totalNights.ToString("N0")).Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(totalRevenue)).Bold();
                table.Cell().TotalsRow().AlignRight().Text(FormatCurrency(avgRate)).Bold();
            });

            column.Item().PaddingTop(20);

            // Comparison indicators
            if (_trendData.Count >= 2)
            {
                column.Item().Text("Month-over-Month Changes").FontSize(12).Bold();
                column.Item().PaddingTop(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(1);
                        columns.ConstantColumn(100);
                        columns.ConstantColumn(100);
                    });

                    table.Header(header =>
                    {
                        header.Cell().TableHeader().Text("Month").TableHeaderText();
                        header.Cell().TableHeader().AlignCenter().Text("Booking Change").TableHeaderText();
                        header.Cell().TableHeader().AlignCenter().Text("Revenue Change").TableHeaderText();
                    });

                    bool alternate = false;
                    for (int i = 1; i < _trendData.Count; i++)
                    {
                        var current = _trendData[i];
                        var previous = _trendData[i - 1];

                        var bookingChange = previous.BookingCount > 0
                            ? ((decimal)(current.BookingCount - previous.BookingCount) / previous.BookingCount * 100)
                            : 0;
                        var revenueChange = previous.TotalRevenue > 0
                            ? ((current.TotalRevenue - previous.TotalRevenue) / previous.TotalRevenue * 100)
                            : 0;

                        table.Cell().TableCell(alternate).Text(current.MonthLabel).TableCellText();

                        var bookingText = table.Cell().TableCell(alternate).AlignCenter()
                            .Text($"{(bookingChange >= 0 ? "+" : "")}{bookingChange:F1}%").TableCellText();
                        if (bookingChange > 0) bookingText.FontColor("#008800");
                        else if (bookingChange < 0) bookingText.FontColor("#cc0000");

                        var revenueText = table.Cell().TableCell(alternate).AlignCenter()
                            .Text($"{(revenueChange >= 0 ? "+" : "")}{revenueChange:F1}%").TableCellText();
                        if (revenueChange > 0) revenueText.FontColor("#008800");
                        else if (revenueChange < 0) revenueText.FontColor("#cc0000");

                        alternate = !alternate;
                    }
                });
            }
        });
    }
}

/// <summary>
/// Data transfer object for trend data.
/// </summary>
public class TrendDataItem
{
    public int Year { get; set; }
    public int Month { get; set; }
    public string MonthLabel => new DateTime(Year, Month, 1).ToString("MMM yyyy");
    public int BookingCount { get; set; }
    public decimal TotalRevenue { get; set; }
    public int TotalNights { get; set; }
}
