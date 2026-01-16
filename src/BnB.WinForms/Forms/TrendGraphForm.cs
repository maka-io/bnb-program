using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Trend graph form - migrated from TrndGrph.frm
/// Shows booking and revenue trends over time.
/// </summary>
public partial class TrendGraphForm : Form
{
    private readonly BnBDbContext _dbContext;
    private List<MonthlyTrendData> _trendData = new();

    public TrendGraphForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void TrendGraphForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        // Default to past 12 months
        dtpStartDate.Value = DateTime.Now.AddMonths(-11);
        dtpEndDate.Value = DateTime.Now;

        cboMetric.Items.AddRange(new object[]
        {
            "Bookings",
            "Revenue",
            "Nights Booked",
            "Average Rate"
        });
        cboMetric.SelectedIndex = 0;

        LoadTrendData();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadTrendData();
    }

    private void cboMetric_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrawChart();
    }

    private void LoadTrendData()
    {
        var startDate = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, 1);
        var endDate = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, 1).AddMonths(1).AddDays(-1);

        // Note: TotalCharges is computed, using TotalGrossWithTax instead
        _trendData = _dbContext.Accommodations
            .Where(a => a.ArrivalDate >= startDate && a.ArrivalDate <= endDate)
            .GroupBy(a => new { a.ArrivalDate.Year, a.ArrivalDate.Month })
            .Select(g => new MonthlyTrendData
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                BookingCount = g.Count(),
                TotalRevenue = g.Sum(a => a.TotalGrossWithTax ?? 0),
                TotalNights = g.Sum(a => a.NumberOfNights)
            })
            .OrderBy(t => t.Year)
            .ThenBy(t => t.Month)
            .ToList();

        // Fill in missing months with zeros
        var filledData = new List<MonthlyTrendData>();
        var currentDate = startDate;
        while (currentDate <= endDate)
        {
            var existing = _trendData.FirstOrDefault(t => t.Year == currentDate.Year && t.Month == currentDate.Month);
            if (existing != null)
            {
                filledData.Add(existing);
            }
            else
            {
                filledData.Add(new MonthlyTrendData
                {
                    Year = currentDate.Year,
                    Month = currentDate.Month,
                    BookingCount = 0,
                    TotalRevenue = 0,
                    TotalNights = 0
                });
            }
            currentDate = currentDate.AddMonths(1);
        }
        _trendData = filledData;

        DrawChart();
        UpdateDataGrid();
    }

    private void DrawChart()
    {
        if (_trendData.Count == 0) return;

        pnlChart.Invalidate();
    }

    private void pnlChart_Paint(object sender, PaintEventArgs e)
    {
        if (_trendData.Count == 0) return;

        var g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        var chartRect = new Rectangle(50, 30, pnlChart.Width - 70, pnlChart.Height - 80);

        // Draw axes
        using var axisPen = new Pen(Color.Black, 1);
        g.DrawLine(axisPen, chartRect.Left, chartRect.Top, chartRect.Left, chartRect.Bottom);
        g.DrawLine(axisPen, chartRect.Left, chartRect.Bottom, chartRect.Right, chartRect.Bottom);

        // Get values based on selected metric
        var values = GetMetricValues();
        if (values.Length == 0) return;

        var maxValue = values.Max();
        if (maxValue == 0) maxValue = 1;

        // Draw grid lines
        using var gridPen = new Pen(Color.LightGray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        for (int i = 1; i <= 5; i++)
        {
            var y = chartRect.Bottom - (chartRect.Height * i / 5);
            g.DrawLine(gridPen, chartRect.Left, y, chartRect.Right, y);

            var labelValue = maxValue * i / 5;
            var labelText = cboMetric.SelectedIndex == 1 || cboMetric.SelectedIndex == 3
                ? labelValue.ToString("C0")
                : labelValue.ToString("N0");
            g.DrawString(labelText, Font, Brushes.Black, 5, y - 7);
        }

        // Draw bars
        var barWidth = (chartRect.Width - 20) / values.Length;
        using var barBrush = new SolidBrush(Color.SteelBlue);

        for (int i = 0; i < values.Length; i++)
        {
            var barHeight = (int)(chartRect.Height * values[i] / maxValue);
            var x = chartRect.Left + 10 + i * barWidth;
            var y = chartRect.Bottom - barHeight;

            g.FillRectangle(barBrush, x, y, barWidth - 4, barHeight);

            // Draw month label
            var label = new DateTime(_trendData[i].Year, _trendData[i].Month, 1).ToString("MMM yy");
            var labelSize = g.MeasureString(label, Font);
            g.DrawString(label, Font, Brushes.Black, x + (barWidth - labelSize.Width) / 2, chartRect.Bottom + 5);
        }

        // Draw title
        var title = cboMetric.SelectedItem?.ToString() ?? "Trend";
        using var titleFont = new Font("Segoe UI", 12, FontStyle.Bold);
        var titleSize = g.MeasureString(title, titleFont);
        g.DrawString(title, titleFont, Brushes.Black, (pnlChart.Width - titleSize.Width) / 2, 5);
    }

    private decimal[] GetMetricValues()
    {
        return cboMetric.SelectedIndex switch
        {
            0 => _trendData.Select(t => (decimal)t.BookingCount).ToArray(),
            1 => _trendData.Select(t => t.TotalRevenue).ToArray(),
            2 => _trendData.Select(t => (decimal)t.TotalNights).ToArray(),
            3 => _trendData.Select(t => t.TotalNights > 0 ? t.TotalRevenue / t.TotalNights : 0).ToArray(),
            _ => Array.Empty<decimal>()
        };
    }

    private void UpdateDataGrid()
    {
        dgvData.DataSource = _trendData.Select(t => new
        {
            Month = new DateTime(t.Year, t.Month, 1).ToString("MMM yyyy"),
            Bookings = t.BookingCount,
            Revenue = t.TotalRevenue,
            Nights = t.TotalNights,
            AvgRate = t.TotalNights > 0 ? t.TotalRevenue / t.TotalNights : 0
        }).ToList();

        if (dgvData.Columns.Contains("Revenue"))
        {
            dgvData.Columns["Revenue"].DefaultCellStyle.Format = "C2";
            dgvData.Columns["Revenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        if (dgvData.Columns.Contains("AvgRate"))
        {
            dgvData.Columns["AvgRate"].HeaderText = "Avg Rate";
            dgvData.Columns["AvgRate"].DefaultCellStyle.Format = "C2";
            dgvData.Columns["AvgRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }

    private void btnPreview_Click(object sender, EventArgs e)
    {
        ShowReport(autoPrint: false);
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        ShowReport(autoPrint: true);
    }

    private void ShowReport(bool autoPrint)
    {
        var startDate = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, 1);
        var endDate = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, 1).AddMonths(1).AddDays(-1);

        var trendItems = _trendData.Select(t => new TrendDataItem
        {
            Year = t.Year,
            Month = t.Month,
            BookingCount = t.BookingCount,
            TotalRevenue = t.TotalRevenue,
            TotalNights = t.TotalNights
        }).ToList();

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new TrendReport(startDate, endDate, trendItems, companyInfo);
        using var viewer = new ReportViewerForm(report, autoPrint);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}

internal class MonthlyTrendData
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int BookingCount { get; set; }
    public decimal TotalRevenue { get; set; }
    public int TotalNights { get; set; }
}
