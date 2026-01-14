namespace BnB.Core.Services;

/// <summary>
/// Defines the contract for chart generation services.
/// Replaces Graphs32.OCX functionality from the legacy VB5 application.
/// </summary>
public interface IChartService
{
    /// <summary>
    /// Creates bar chart data from a collection of values.
    /// </summary>
    ChartData CreateBarChart(string title, IEnumerable<ChartDataPoint> dataPoints);

    /// <summary>
    /// Creates line chart data from a collection of values.
    /// </summary>
    ChartData CreateLineChart(string title, IEnumerable<ChartDataPoint> dataPoints);

    /// <summary>
    /// Creates pie chart data from a collection of values.
    /// </summary>
    ChartData CreatePieChart(string title, IEnumerable<ChartDataPoint> dataPoints);

    /// <summary>
    /// Exports chart to a bitmap image.
    /// </summary>
    byte[] ExportToImage(ChartData chartData, int width, int height);

    /// <summary>
    /// Gets chart data for monthly trends.
    /// </summary>
    ChartData CreateMonthlyTrendChart(string title, IEnumerable<MonthlyDataPoint> dataPoints);
}

/// <summary>
/// Represents a single data point for a chart.
/// </summary>
public class ChartDataPoint
{
    /// <summary>
    /// The label for this data point (X-axis label).
    /// </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// The value for this data point (Y-axis value).
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// Optional color for this data point.
    /// </summary>
    public string? Color { get; set; }
}

/// <summary>
/// Represents a monthly data point for time-series charts.
/// </summary>
public class MonthlyDataPoint
{
    public int Year { get; set; }
    public int Month { get; set; }
    public double Value { get; set; }

    /// <summary>
    /// Gets a DateTime for this data point.
    /// </summary>
    public DateTime Date => new(Year, Month, 1);

    /// <summary>
    /// Gets a formatted label (e.g., "Jan 2024").
    /// </summary>
    public string Label => Date.ToString("MMM yyyy");
}

/// <summary>
/// Container for chart configuration and data.
/// </summary>
public class ChartData
{
    /// <summary>
    /// The chart title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The type of chart.
    /// </summary>
    public ChartType ChartType { get; set; }

    /// <summary>
    /// The X-axis title.
    /// </summary>
    public string? XAxisTitle { get; set; }

    /// <summary>
    /// The Y-axis title.
    /// </summary>
    public string? YAxisTitle { get; set; }

    /// <summary>
    /// The data points to display.
    /// </summary>
    public List<ChartDataPoint> DataPoints { get; set; } = new();

    /// <summary>
    /// Whether to show data labels on the chart.
    /// </summary>
    public bool ShowDataLabels { get; set; } = true;

    /// <summary>
    /// Whether to show a legend.
    /// </summary>
    public bool ShowLegend { get; set; } = false;

    /// <summary>
    /// The subtitle or description.
    /// </summary>
    public string? Subtitle { get; set; }
}

/// <summary>
/// Types of charts supported.
/// </summary>
public enum ChartType
{
    Bar,
    Line,
    Pie,
    Area,
    Scatter
}
