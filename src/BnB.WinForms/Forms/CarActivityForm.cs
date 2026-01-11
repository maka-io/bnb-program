using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Car Activity Report form - migrated from CarActiv.frm
/// Shows car rental activity within a date range.
/// </summary>
public partial class CarActivityForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();

    public CarActivityForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void CarActivityForm_Load(object sender, EventArgs e)
    {
        // Default to current month
        dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        dtpEndDate.Value = dtpStartDate.Value.AddMonths(1).AddDays(-1);
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadCarActivity();
    }

    private void LoadCarActivity()
    {
        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;

        var rentals = _dbContext.CarRentals
            .Include(r => r.Guest)
            .Include(r => r.CarAgency)
            .Where(r => r.PickupDate >= startDate && r.PickupDate <= endDate)
            .OrderBy(r => r.PickupDate)
            .ToList();

        _bindingSource.DataSource = rentals;
        dgvCarActivity.DataSource = _bindingSource;
        ConfigureGrid();
        UpdateSummary(rentals);
    }

    private void ConfigureGrid()
    {
        if (dgvCarActivity.Columns.Count == 0) return;

        foreach (DataGridViewColumn col in dgvCarActivity.Columns)
        {
            col.Visible = false;
        }

        ShowColumn("ConfirmationNumber", "Conf #", 80);
        ShowColumn("CarType", "Car Type", 100);
        ShowColumn("PickupDate", "Pickup", 90, "MM/dd/yyyy");
        ShowColumn("ReturnDate", "Return", 90, "MM/dd/yyyy");
        ShowColumn("DailyRate", "Daily Rate", 80, "C2");
        ShowColumn("TotalAmount", "Total", 90, "C2");
    }

    private void ShowColumn(string name, string header, int width, string? format = null)
    {
        if (!dgvCarActivity.Columns.Contains(name)) return;

        var col = dgvCarActivity.Columns[name];
        col.Visible = true;
        col.HeaderText = header;
        col.Width = width;

        if (format != null)
        {
            col.DefaultCellStyle.Format = format;
            if (format == "C2")
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
    }

    private void UpdateSummary(List<CarRental> rentals)
    {
        var count = rentals.Count;
        var totalAmount = rentals.Sum(r => r.TotalAmount ?? 0);

        lblSummary.Text = $"Rentals: {count} | Total: {totalAmount:C2}";
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;

        var rentals = _dbContext.CarRentals
            .Include(r => r.Guest)
            .Include(r => r.CarAgency)
            .Where(r => r.PickupDate >= startDate && r.PickupDate <= endDate)
            .OrderBy(r => r.PickupDate)
            .ToList();

        var report = new CarActivityListReport(startDate, endDate, rentals);
        using var viewer = new ReportViewerForm(report);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
