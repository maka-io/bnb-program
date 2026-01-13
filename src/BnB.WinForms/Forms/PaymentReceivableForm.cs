using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Payments receivable form - migrated from PayRecv.frm
/// Shows payments that are due/receivable.
/// </summary>
public partial class PaymentReceivableForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();

    public PaymentReceivableForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void PaymentReceivableForm_Load(object sender, EventArgs e)
    {
        LoadPaymentsReceivable();
    }

    private void LoadPaymentsReceivable()
    {
        // Note: BalanceDue and TotalCharges are computed properties not in DB
        // We compute balance by comparing TotalGrossWithTax against payments
        var today = DateTime.Today;

        // Get all accommodations first (SQLite can't do Sum on decimal in subquery)
        var accommodations = _dbContext.Accommodations
            .Include(a => a.Property)
            .Include(a => a.Guest)
            .Where(a => a.ArrivalDate >= today.AddMonths(-6)) // Reasonable date range
            .OrderBy(a => a.ArrivalDate)
            .ToList();

        // Get all payments and group by confirmation number (client-side)
        var paymentsByConf = _dbContext.Payments
            .ToList()
            .GroupBy(p => p.ConfirmationNumber)
            .ToDictionary(g => g.Key, g => g.Sum(p => p.Amount));

        // Build the result with computed values (all on client side)
        var receivables = accommodations
            .Select(a => new
            {
                a.Id,
                a.ConfirmationNumber,
                a.FirstName,
                a.LastName,
                a.ArrivalDate,
                a.DepartureDate,
                PropertyName = a.Property?.Location ?? "N/A",
                TotalCharges = a.TotalGrossWithTax ?? 0m,
                TotalPaid = paymentsByConf.TryGetValue(a.ConfirmationNumber, out var paid) ? paid : 0m,
                BalanceDue = (a.TotalGrossWithTax ?? 0m) - (paymentsByConf.TryGetValue(a.ConfirmationNumber, out var p) ? p : 0m),
                DaysUntilArrival = (a.ArrivalDate - today).Days
            })
            .Where(a => a.BalanceDue > 0)
            .ToList();

        _bindingSource.DataSource = receivables;
        dgvReceivables.DataSource = _bindingSource;
        ConfigureGrid();
        UpdateSummary();
    }

    private void ConfigureGrid()
    {
        if (dgvReceivables.Columns.Count == 0) return;

        if (dgvReceivables.Columns.Contains("Id"))
            dgvReceivables.Columns["Id"].Visible = false;

        if (dgvReceivables.Columns.Contains("ConfirmationNumber"))
        {
            dgvReceivables.Columns["ConfirmationNumber"].HeaderText = "Conf #";
            dgvReceivables.Columns["ConfirmationNumber"].Width = 80;
        }

        if (dgvReceivables.Columns.Contains("FirstName"))
        {
            dgvReceivables.Columns["FirstName"].HeaderText = "First";
            dgvReceivables.Columns["FirstName"].Width = 90;
        }

        if (dgvReceivables.Columns.Contains("LastName"))
        {
            dgvReceivables.Columns["LastName"].HeaderText = "Last";
            dgvReceivables.Columns["LastName"].Width = 90;
        }

        if (dgvReceivables.Columns.Contains("ArrivalDate"))
        {
            dgvReceivables.Columns["ArrivalDate"].HeaderText = "Arrival";
            dgvReceivables.Columns["ArrivalDate"].Width = 90;
            dgvReceivables.Columns["ArrivalDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        if (dgvReceivables.Columns.Contains("DepartureDate"))
        {
            dgvReceivables.Columns["DepartureDate"].HeaderText = "Departure";
            dgvReceivables.Columns["DepartureDate"].Width = 90;
            dgvReceivables.Columns["DepartureDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        if (dgvReceivables.Columns.Contains("PropertyName"))
        {
            dgvReceivables.Columns["PropertyName"].HeaderText = "Property";
            dgvReceivables.Columns["PropertyName"].Width = 120;
        }

        if (dgvReceivables.Columns.Contains("TotalCharges"))
        {
            dgvReceivables.Columns["TotalCharges"].HeaderText = "Total";
            dgvReceivables.Columns["TotalCharges"].Width = 90;
            dgvReceivables.Columns["TotalCharges"].DefaultCellStyle.Format = "C2";
            dgvReceivables.Columns["TotalCharges"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (dgvReceivables.Columns.Contains("TotalPaid"))
        {
            dgvReceivables.Columns["TotalPaid"].HeaderText = "Paid";
            dgvReceivables.Columns["TotalPaid"].Width = 90;
            dgvReceivables.Columns["TotalPaid"].DefaultCellStyle.Format = "C2";
            dgvReceivables.Columns["TotalPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (dgvReceivables.Columns.Contains("BalanceDue"))
        {
            dgvReceivables.Columns["BalanceDue"].HeaderText = "Balance";
            dgvReceivables.Columns["BalanceDue"].Width = 90;
            dgvReceivables.Columns["BalanceDue"].DefaultCellStyle.Format = "C2";
            dgvReceivables.Columns["BalanceDue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvReceivables.Columns["BalanceDue"].DefaultCellStyle.ForeColor = Color.Red;
        }

        if (dgvReceivables.Columns.Contains("DaysUntilArrival"))
        {
            dgvReceivables.Columns["DaysUntilArrival"].HeaderText = "Days Until";
            dgvReceivables.Columns["DaysUntilArrival"].Width = 70;
            dgvReceivables.Columns["DaysUntilArrival"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // Color code based on urgency
        foreach (DataGridViewRow row in dgvReceivables.Rows)
        {
            if (row.Cells["DaysUntilArrival"].Value is int days)
            {
                if (days < 0) // Past arrival
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (days <= 7) // Within a week
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }
    }

    private void UpdateSummary()
    {
        var count = _bindingSource.Count;
        decimal totalReceivable = 0;
        foreach (var item in _bindingSource.List)
        {
            var balProp = item.GetType().GetProperty("BalanceDue");
            if (balProp?.GetValue(item) is decimal balance)
                totalReceivable += balance;
        }

        lblSummary.Text = $"Receivables: {count} | Total Due: {totalReceivable:C2}";
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadPaymentsReceivable();
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        // Note: BalanceDue is computed, so we fetch all recent accommodations
        // and the report will handle filtering/display
        var today = DateTime.Today;
        var receivables = _dbContext.Accommodations
            .Include(a => a.Property)
            .Include(a => a.Guest)
            .Where(a => a.ArrivalDate >= today.AddMonths(-6))
            .OrderBy(a => a.ArrivalDate)
            .ToList();

        var report = new PaymentReceivableReport(receivables);
        using var viewer = new ReportViewerForm(report);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
