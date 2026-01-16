using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Data transfer object for payment receivable records
/// </summary>
public class PaymentReceivableData
{
    public long ConfirmationNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public string? PropertyName { get; set; }
    public decimal TotalCharges { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal BalanceDue { get; set; }
    public int DaysUntilArrival { get; set; }
}

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
        this.ApplyTheme();

        // Default date range to current year
        var currentYear = DateTime.Today.Year;
        dtpDateFrom.Value = new DateTime(currentYear, 1, 1);
        dtpDateTo.Value = new DateTime(currentYear, 12, 31);

        LoadPaymentsReceivable();
    }

    private void dtpDateRange_ValueChanged(object sender, EventArgs e)
    {
        LoadPaymentsReceivable();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        var currentYear = DateTime.Today.Year;
        dtpDateFrom.Value = new DateTime(currentYear, 1, 1);
        dtpDateTo.Value = new DateTime(currentYear, 12, 31);
        chkIncludePastArrivals.Checked = false;
    }

    private void LoadPaymentsReceivable()
    {
        // Note: BalanceDue and TotalCharges are computed properties not in DB
        // We compute balance by comparing TotalGrossWithTax against payments
        var today = DateTime.Today;
        var includePastArrivals = chkIncludePastArrivals.Checked;
        var dateFrom = dtpDateFrom.Value.Date;
        var dateTo = dtpDateTo.Value.Date;

        // Get accommodations - filter by date range and arrival date
        var accommodationsQuery = _dbContext.Accommodations
            .Include(a => a.Property)
            .Include(a => a.Guest)
            .Where(a => a.ArrivalDate >= dateFrom && a.ArrivalDate <= dateTo)
            .AsQueryable();

        if (!includePastArrivals)
        {
            accommodationsQuery = accommodationsQuery.Where(a => a.ArrivalDate >= today);
        }

        var accommodations = accommodationsQuery.ToList();

        // Get all payments and group by confirmation number (client-side)
        var paymentsByConf = _dbContext.Payments
            .ToList()
            .GroupBy(p => p.ConfirmationNumber)
            .ToDictionary(g => g.Key, g => g.Sum(p => p.Amount));

        // Build the result with computed values (all on client side)
        var allReceivables = accommodations
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

        // Sort: upcoming arrivals first (soonest first), then past arrivals (most recent first)
        var upcoming = allReceivables.Where(a => a.DaysUntilArrival >= 0).OrderBy(a => a.ArrivalDate);
        var past = allReceivables.Where(a => a.DaysUntilArrival < 0).OrderByDescending(a => a.ArrivalDate);
        var receivables = upcoming.Concat(past).ToList();

        _bindingSource.DataSource = receivables;
        dgvReceivables.DataSource = _bindingSource;
        ConfigureGrid();
        UpdateSummary();
    }

    private void ConfigureGrid()
    {
        if (dgvReceivables.Columns.Count == 0) return;

        // Disable automatic sorting on all columns to preserve our custom sort order
        foreach (DataGridViewColumn column in dgvReceivables.Columns)
        {
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

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

    private void chkIncludePastArrivals_CheckedChanged(object sender, EventArgs e)
    {
        LoadPaymentsReceivable();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadPaymentsReceivable();
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
        // Use the same data that's displayed in the form grid
        var receivableData = new List<PaymentReceivableData>();
        foreach (var item in _bindingSource.List)
        {
            var type = item.GetType();
            receivableData.Add(new PaymentReceivableData
            {
                ConfirmationNumber = (long)(type.GetProperty("ConfirmationNumber")?.GetValue(item) ?? 0),
                FirstName = type.GetProperty("FirstName")?.GetValue(item)?.ToString(),
                LastName = type.GetProperty("LastName")?.GetValue(item)?.ToString(),
                ArrivalDate = (DateTime)(type.GetProperty("ArrivalDate")?.GetValue(item) ?? DateTime.MinValue),
                DepartureDate = (DateTime)(type.GetProperty("DepartureDate")?.GetValue(item) ?? DateTime.MinValue),
                PropertyName = type.GetProperty("PropertyName")?.GetValue(item)?.ToString(),
                TotalCharges = (decimal)(type.GetProperty("TotalCharges")?.GetValue(item) ?? 0m),
                TotalPaid = (decimal)(type.GetProperty("TotalPaid")?.GetValue(item) ?? 0m),
                BalanceDue = (decimal)(type.GetProperty("BalanceDue")?.GetValue(item) ?? 0m),
                DaysUntilArrival = (int)(type.GetProperty("DaysUntilArrival")?.GetValue(item) ?? 0)
            });
        }

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new PaymentReceivableReport(receivableData, companyInfo);
        using var viewer = new ReportViewerForm(report, autoPrint);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvReceivables_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hitTest = dgvReceivables.HitTest(e.X, e.Y);
            if (hitTest.RowIndex >= 0 && hitTest.RowIndex < dgvReceivables.Rows.Count)
            {
                // Select the row under the cursor
                dgvReceivables.ClearSelection();
                dgvReceivables.Rows[hitTest.RowIndex].Selected = true;

                // Find the first visible cell to set as current
                foreach (DataGridViewCell cell in dgvReceivables.Rows[hitTest.RowIndex].Cells)
                {
                    if (cell.Visible)
                    {
                        dgvReceivables.CurrentCell = cell;
                        break;
                    }
                }

                // Show context menu at cursor position
                contextMenuStrip.Show(dgvReceivables, e.Location);
            }
            // If not on a valid row, don't show the context menu
        }
    }

    private long? GetSelectedConfirmationNumber()
    {
        if (dgvReceivables.SelectedRows.Count == 0) return null;

        var selectedRow = dgvReceivables.SelectedRows[0];
        if (selectedRow.DataBoundItem == null) return null;

        var type = selectedRow.DataBoundItem.GetType();
        var confProp = type.GetProperty("ConfirmationNumber");
        if (confProp?.GetValue(selectedRow.DataBoundItem) is long confNum)
        {
            return confNum;
        }
        return null;
    }

    private void mnuGoToGuestInfo_Click(object sender, EventArgs e)
    {
        var confNum = GetSelectedConfirmationNumber();
        if (confNum == null)
        {
            MessageBox.Show("Please select a record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var guest = _dbContext.Guests.FirstOrDefault(g => g.ConfirmationNumber == confNum);
        if (guest == null)
        {
            MessageBox.Show($"Guest with Conf# {confNum} not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var form = new GuestForm(_dbContext, confNum);
        form.MdiParent = this.MdiParent;
        form.Show();
    }

    private void mnuGoToAccommodations_Click(object sender, EventArgs e)
    {
        var confNum = GetSelectedConfirmationNumber();
        if (confNum == null)
        {
            MessageBox.Show("Please select a record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var form = new AccommodationForm(_dbContext, confNum);
        form.MdiParent = this.MdiParent;
        form.Show();
    }

    private void mnuGoToPayments_Click(object sender, EventArgs e)
    {
        var confNum = GetSelectedConfirmationNumber();
        if (confNum == null)
        {
            MessageBox.Show("Please select a record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var form = new PaymentForm(_dbContext, confNum);
        form.MdiParent = this.MdiParent;
        form.Show();
    }
}
