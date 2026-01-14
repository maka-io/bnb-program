using BnB.Core.Services;
using ScottPlot;

namespace BnB.WinForms.Services;

/// <summary>
/// Service for creating charts using ScottPlot.
/// Replaces Graphs32.OCX functionality from the legacy VB5 application.
/// </summary>
public class ChartService : IChartService
{
    /// <inheritdoc />
    public ChartData CreateBarChart(string title, IEnumerable<ChartDataPoint> dataPoints)
    {
        return new ChartData
        {
            Title = title,
            ChartType = ChartType.Bar,
            DataPoints = dataPoints.ToList(),
            ShowDataLabels = true
        };
    }

    /// <inheritdoc />
    public ChartData CreateLineChart(string title, IEnumerable<ChartDataPoint> dataPoints)
    {
        return new ChartData
        {
            Title = title,
            ChartType = ChartType.Line,
            DataPoints = dataPoints.ToList(),
            ShowDataLabels = false
        };
    }

    /// <inheritdoc />
    public ChartData CreatePieChart(string title, IEnumerable<ChartDataPoint> dataPoints)
    {
        return new ChartData
        {
            Title = title,
            ChartType = ChartType.Pie,
            DataPoints = dataPoints.ToList(),
            ShowDataLabels = true,
            ShowLegend = true
        };
    }

    /// <inheritdoc />
    public ChartData CreateMonthlyTrendChart(string title, IEnumerable<MonthlyDataPoint> dataPoints)
    {
        var points = dataPoints.Select(p => new ChartDataPoint
        {
            Label = p.Label,
            Value = p.Value
        });

        return CreateBarChart(title, points);
    }

    /// <inheritdoc />
    public byte[] ExportToImage(ChartData chartData, int width, int height)
    {
        var plot = CreatePlot(chartData, width, height);
        return plot.GetImageBytes(width, height, ImageFormat.Png);
    }

    /// <summary>
    /// Creates a ScottPlot Plot object from ChartData.
    /// </summary>
    public static Plot CreatePlot(ChartData chartData, int width = 800, int height = 600)
    {
        var plot = new Plot();

        // Set title
        plot.Title(chartData.Title);

        if (chartData.DataPoints.Count == 0)
        {
            return plot;
        }

        switch (chartData.ChartType)
        {
            case ChartType.Bar:
                AddBarPlot(plot, chartData);
                break;
            case ChartType.Line:
                AddLinePlot(plot, chartData);
                break;
            case ChartType.Pie:
                AddPiePlot(plot, chartData);
                break;
            case ChartType.Area:
                AddAreaPlot(plot, chartData);
                break;
            case ChartType.Scatter:
                AddScatterPlot(plot, chartData);
                break;
        }

        // Set axis titles if provided
        if (!string.IsNullOrEmpty(chartData.XAxisTitle))
        {
            plot.XLabel(chartData.XAxisTitle);
        }
        if (!string.IsNullOrEmpty(chartData.YAxisTitle))
        {
            plot.YLabel(chartData.YAxisTitle);
        }

        return plot;
    }

    private static void AddBarPlot(Plot plot, ChartData chartData)
    {
        var positions = Enumerable.Range(0, chartData.DataPoints.Count).Select(i => (double)i).ToArray();
        var values = chartData.DataPoints.Select(p => p.Value).ToArray();

        var bars = plot.Add.Bars(positions, values);
        bars.Color = Colors.SteelBlue;

        // Set custom tick labels
        var ticks = chartData.DataPoints.Select((p, i) => new Tick(i, p.Label)).ToArray();
        plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
        plot.Axes.Bottom.TickLabelStyle.Rotation = chartData.DataPoints.Count > 6 ? 45 : 0;

        // Add data labels if enabled
        if (chartData.ShowDataLabels)
        {
            for (int i = 0; i < chartData.DataPoints.Count; i++)
            {
                var txt = plot.Add.Text(chartData.DataPoints[i].Value.ToString("N0"), i, values[i]);
                txt.LabelAlignment = Alignment.LowerCenter;
                txt.LabelOffsetY = -5;
                txt.LabelFontSize = 10;
            }
        }
    }

    private static void AddLinePlot(Plot plot, ChartData chartData)
    {
        var positions = Enumerable.Range(0, chartData.DataPoints.Count).Select(i => (double)i).ToArray();
        var values = chartData.DataPoints.Select(p => p.Value).ToArray();

        var line = plot.Add.Scatter(positions, values);
        line.Color = Colors.SteelBlue;
        line.LineWidth = 2;
        line.MarkerSize = 8;

        // Set custom tick labels
        var ticks = chartData.DataPoints.Select((p, i) => new Tick(i, p.Label)).ToArray();
        plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
        plot.Axes.Bottom.TickLabelStyle.Rotation = chartData.DataPoints.Count > 6 ? 45 : 0;
    }

    private static void AddPiePlot(Plot plot, ChartData chartData)
    {
        var values = chartData.DataPoints.Select(p => p.Value).ToArray();
        var labels = chartData.DataPoints.Select(p => p.Label).ToArray();

        var slices = new List<PieSlice>();
        var colors = GetDefaultColors();

        for (int i = 0; i < chartData.DataPoints.Count; i++)
        {
            slices.Add(new PieSlice
            {
                Value = values[i],
                Label = labels[i],
                FillColor = colors[i % colors.Length]
            });
        }

        var pie = plot.Add.Pie(slices);
        // In ScottPlot 5, slice labels are shown by default based on the Label property
    }

    private static void AddAreaPlot(Plot plot, ChartData chartData)
    {
        var positions = Enumerable.Range(0, chartData.DataPoints.Count).Select(i => (double)i).ToArray();
        var values = chartData.DataPoints.Select(p => p.Value).ToArray();

        var scatter = plot.Add.Scatter(positions, values);
        scatter.Color = Colors.SteelBlue;
        scatter.LineWidth = 2;
        scatter.FillY = true;
        scatter.FillYColor = Colors.SteelBlue.WithAlpha(0.3);

        // Set custom tick labels
        var ticks = chartData.DataPoints.Select((p, i) => new Tick(i, p.Label)).ToArray();
        plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
    }

    private static void AddScatterPlot(Plot plot, ChartData chartData)
    {
        var positions = Enumerable.Range(0, chartData.DataPoints.Count).Select(i => (double)i).ToArray();
        var values = chartData.DataPoints.Select(p => p.Value).ToArray();

        var scatter = plot.Add.Scatter(positions, values);
        scatter.Color = Colors.SteelBlue;
        scatter.LineWidth = 0;
        scatter.MarkerSize = 10;
    }

    private static ScottPlot.Color[] GetDefaultColors()
    {
        return new[]
        {
            Colors.SteelBlue,
            Colors.Coral,
            Colors.MediumSeaGreen,
            Colors.Gold,
            Colors.MediumPurple,
            Colors.DarkOrange,
            Colors.CadetBlue,
            Colors.Crimson,
            Colors.DarkCyan,
            Colors.Olive
        };
    }

    /// <summary>
    /// Configures a ScottPlot FormsPlot control with the given chart data.
    /// </summary>
    public static void ConfigureFormsPlot(ScottPlot.WinForms.FormsPlot formsPlot, ChartData chartData)
    {
        formsPlot.Reset();
        var plot = formsPlot.Plot;

        // Set title
        plot.Title(chartData.Title);

        if (chartData.DataPoints.Count == 0)
        {
            formsPlot.Refresh();
            return;
        }

        switch (chartData.ChartType)
        {
            case ChartType.Bar:
                AddBarPlot(plot, chartData);
                break;
            case ChartType.Line:
                AddLinePlot(plot, chartData);
                break;
            case ChartType.Pie:
                AddPiePlot(plot, chartData);
                break;
            case ChartType.Area:
                AddAreaPlot(plot, chartData);
                break;
            case ChartType.Scatter:
                AddScatterPlot(plot, chartData);
                break;
        }

        // Set axis titles if provided
        if (!string.IsNullOrEmpty(chartData.XAxisTitle))
        {
            plot.XLabel(chartData.XAxisTitle);
        }
        if (!string.IsNullOrEmpty(chartData.YAxisTitle))
        {
            plot.YLabel(chartData.YAxisTitle);
        }

        formsPlot.Refresh();
    }
}
