using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Net summary form - migrated from NetSum.frm
/// Shows net income summary by property.
/// </summary>
public partial class NetSummaryForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();

    public NetSummaryForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void NetSummaryForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        // Default to current year
        dtpStartDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
        dtpEndDate.Value = DateTime.Now;
        LoadSummary();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadSummary();
    }

    private void LoadSummary()
    {
        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;

        // Note: Status is not in DB (using Suppress instead), TotalCharges is computed (using TotalGrossWithTax)
        var summary = _dbContext.Accommodations
            .Include(a => a.Property)
            .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate
                     && !a.Suppress)
            .GroupBy(a => new { a.PropertyAccountNumber, PropertyName = a.Property.Location })
            .Select(g => new
            {
                g.Key.PropertyAccountNumber,
                g.Key.PropertyName,
                Bookings = g.Count(),
                NumberOfNights = g.Sum(a => a.NumberOfNights),
                GrossRevenue = g.Sum(a => a.TotalGrossWithTax ?? 0),
                Commission = g.Sum(a => a.Commission),
                NetRevenue = g.Sum(a => (a.TotalGrossWithTax ?? 0) - a.Commission)
            })
            .OrderByDescending(s => s.NetRevenue)
            .ToList();

        _bindingSource.DataSource = summary;
        dgvSummary.DataSource = _bindingSource;
        ConfigureGrid();
        UpdateTotals();
    }

    private void ConfigureGrid()
    {
        if (dgvSummary.Columns.Count == 0) return;

        if (dgvSummary.Columns.Contains("PropertyAccountNumber"))
            dgvSummary.Columns["PropertyAccountNumber"].Visible = false;

        if (dgvSummary.Columns.Contains("PropertyName"))
        {
            dgvSummary.Columns["PropertyName"].HeaderText = "Property";
            dgvSummary.Columns["PropertyName"].Width = 160;
        }

        if (dgvSummary.Columns.Contains("Bookings"))
        {
            dgvSummary.Columns["Bookings"].HeaderText = "Bookings";
            dgvSummary.Columns["Bookings"].Width = 70;
            dgvSummary.Columns["Bookings"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        if (dgvSummary.Columns.Contains("NumberOfNights"))
        {
            dgvSummary.Columns["NumberOfNights"].HeaderText = "Nights";
            dgvSummary.Columns["NumberOfNights"].Width = 60;
            dgvSummary.Columns["NumberOfNights"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        if (dgvSummary.Columns.Contains("GrossRevenue"))
        {
            dgvSummary.Columns["GrossRevenue"].HeaderText = "Gross Revenue";
            dgvSummary.Columns["GrossRevenue"].Width = 110;
            dgvSummary.Columns["GrossRevenue"].DefaultCellStyle.Format = "C2";
            dgvSummary.Columns["GrossRevenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (dgvSummary.Columns.Contains("Commission"))
        {
            dgvSummary.Columns["Commission"].HeaderText = "Commission";
            dgvSummary.Columns["Commission"].Width = 100;
            dgvSummary.Columns["Commission"].DefaultCellStyle.Format = "C2";
            dgvSummary.Columns["Commission"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (dgvSummary.Columns.Contains("NetRevenue"))
        {
            dgvSummary.Columns["NetRevenue"].HeaderText = "Net Revenue";
            dgvSummary.Columns["NetRevenue"].Width = 110;
            dgvSummary.Columns["NetRevenue"].DefaultCellStyle.Format = "C2";
            dgvSummary.Columns["NetRevenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSummary.Columns["NetRevenue"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }
    }

    private void UpdateTotals()
    {
        int totalBookings = 0;
        int totalNights = 0;
        decimal totalGross = 0;
        decimal totalCommission = 0;
        decimal totalNet = 0;

        foreach (var item in _bindingSource.List)
        {
            var type = item.GetType();
            if (type.GetProperty("Bookings")?.GetValue(item) is int bookings)
                totalBookings += bookings;
            if (type.GetProperty("NumberOfNights")?.GetValue(item) is int nights)
                totalNights += nights;
            if (type.GetProperty("GrossRevenue")?.GetValue(item) is decimal gross)
                totalGross += gross;
            if (type.GetProperty("Commission")?.GetValue(item) is decimal comm)
                totalCommission += comm;
            if (type.GetProperty("NetRevenue")?.GetValue(item) is decimal net)
                totalNet += net;
        }

        txtTotalBookings.Text = totalBookings.ToString();
        txtTotalNights.Text = totalNights.ToString();
        txtTotalGross.Text = totalGross.ToString("C2");
        txtTotalCommission.Text = totalCommission.ToString("C2");
        txtTotalNet.Text = totalNet.ToString("C2");
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
        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;

        var accommodations = _dbContext.Accommodations
            .Include(a => a.Property)
            .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate
                     && !a.Suppress)
            .OrderBy(a => a.Property.Location)
            .ThenBy(a => a.DepartureDate)
            .ToList();

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new NetSummaryReport(startDate, endDate, accommodations, companyInfo);
        using var viewer = new ReportViewerForm(report, autoPrint);
        viewer.ShowDialog(this);
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        using var saveDialog = new SaveFileDialog
        {
            Filter = "CSV Files (*.csv)|*.csv",
            DefaultExt = "csv",
            FileName = $"NetSummary_{dtpStartDate.Value:yyyyMMdd}_{dtpEndDate.Value:yyyyMMdd}.csv"
        };

        if (saveDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                using var writer = new StreamWriter(saveDialog.FileName);
                writer.WriteLine("Property,Bookings,Nights,Gross Revenue,Commission,Net Revenue");

                foreach (DataGridViewRow row in dgvSummary.Rows)
                {
                    var property = row.Cells["PropertyName"].Value;
                    var bookings = row.Cells["Bookings"].Value;
                    var nights = row.Cells["NumberOfNights"].Value;
                    var gross = row.Cells["GrossRevenue"].Value;
                    var commission = row.Cells["Commission"].Value;
                    var net = row.Cells["NetRevenue"].Value;

                    writer.WriteLine($"{property},{bookings},{nights},{gross:F2},{commission:F2},{net:F2}");
                }

                MessageBox.Show($"Exported to {saveDialog.FileName}", "Export Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
