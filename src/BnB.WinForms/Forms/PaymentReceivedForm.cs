using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Payments received form - migrated from PayRcvd.frm
/// Shows payments received in a date range.
/// </summary>
public partial class PaymentReceivedForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();

    public PaymentReceivedForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void PaymentReceivedForm_Load(object sender, EventArgs e)
    {
        // Default to current month
        dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        dtpEndDate.Value = dtpStartDate.Value.AddMonths(1).AddDays(-1);
        LoadPayments();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadPayments();
    }

    private void LoadPayments()
    {
        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;

        var payments = _dbContext.Payments
            .Include(p => p.Accommodation)
                .ThenInclude(a => a.Property)
            .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
            .OrderBy(p => p.PaymentDate)
            .Select(p => new
            {
                p.PaymentId,
                p.PaymentDate,
                ConfirmationNumber = p.Accommodation.ConfirmationNumber,
                GuestName = p.Accommodation.FirstName + " " + p.Accommodation.LastName,
                PropertyName = p.Accommodation.Property.Location,
                p.PaymentMethod,
                p.CheckNumber,
                p.Amount,
                p.Notes
            })
            .ToList();

        _bindingSource.DataSource = payments;
        dgvPayments.DataSource = _bindingSource;
        ConfigureGrid();
        UpdateSummary();
    }

    private void ConfigureGrid()
    {
        if (dgvPayments.Columns.Count == 0) return;

        if (dgvPayments.Columns.Contains("PaymentId"))
            dgvPayments.Columns["PaymentId"].Visible = false;

        if (dgvPayments.Columns.Contains("PaymentDate"))
        {
            dgvPayments.Columns["PaymentDate"].HeaderText = "Date";
            dgvPayments.Columns["PaymentDate"].Width = 90;
            dgvPayments.Columns["PaymentDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        if (dgvPayments.Columns.Contains("ConfirmationNumber"))
        {
            dgvPayments.Columns["ConfirmationNumber"].HeaderText = "Conf #";
            dgvPayments.Columns["ConfirmationNumber"].Width = 80;
        }

        if (dgvPayments.Columns.Contains("GuestName"))
        {
            dgvPayments.Columns["GuestName"].HeaderText = "Guest";
            dgvPayments.Columns["GuestName"].Width = 140;
        }

        if (dgvPayments.Columns.Contains("PropertyName"))
        {
            dgvPayments.Columns["PropertyName"].HeaderText = "Property";
            dgvPayments.Columns["PropertyName"].Width = 120;
        }

        if (dgvPayments.Columns.Contains("PaymentMethod"))
        {
            dgvPayments.Columns["PaymentMethod"].HeaderText = "Method";
            dgvPayments.Columns["PaymentMethod"].Width = 80;
        }

        if (dgvPayments.Columns.Contains("CheckNumber"))
        {
            dgvPayments.Columns["CheckNumber"].HeaderText = "Check #";
            dgvPayments.Columns["CheckNumber"].Width = 80;
        }

        if (dgvPayments.Columns.Contains("Amount"))
        {
            dgvPayments.Columns["Amount"].HeaderText = "Amount";
            dgvPayments.Columns["Amount"].Width = 100;
            dgvPayments.Columns["Amount"].DefaultCellStyle.Format = "C2";
            dgvPayments.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (dgvPayments.Columns.Contains("Notes"))
        {
            dgvPayments.Columns["Notes"].HeaderText = "Notes";
            dgvPayments.Columns["Notes"].Width = 150;
        }
    }

    private void UpdateSummary()
    {
        var count = _bindingSource.Count;
        decimal total = 0;
        foreach (var item in _bindingSource.List)
        {
            var amountProp = item.GetType().GetProperty("Amount");
            if (amountProp?.GetValue(item) is decimal amount)
                total += amount;
        }

        lblSummary.Text = $"Payments: {count} | Total: {total:C2}";
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;

        var payments = _dbContext.Payments
            .Include(p => p.Accommodation)
                .ThenInclude(a => a.Property)
            .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
            .OrderBy(p => p.PaymentDate)
            .ToList();

        var report = new PaymentReceivedReport(startDate, endDate, payments);
        using var viewer = new ReportViewerForm(report);
        viewer.ShowDialog(this);
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        using var saveDialog = new SaveFileDialog
        {
            Filter = "CSV Files (*.csv)|*.csv",
            DefaultExt = "csv",
            FileName = $"PaymentsReceived_{dtpStartDate.Value:yyyyMMdd}_{dtpEndDate.Value:yyyyMMdd}.csv"
        };

        if (saveDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                using var writer = new StreamWriter(saveDialog.FileName);
                writer.WriteLine("Date,Conf#,Guest,Property,Method,Check#,Amount,Notes");

                foreach (DataGridViewRow row in dgvPayments.Rows)
                {
                    var date = row.Cells["PaymentDate"].Value;
                    var conf = row.Cells["ConfirmationNumber"].Value;
                    var guest = row.Cells["GuestName"].Value;
                    var property = row.Cells["PropertyName"].Value;
                    var method = row.Cells["PaymentMethod"].Value;
                    var checkNum = row.Cells["CheckNumber"].Value;
                    var amount = row.Cells["Amount"].Value;
                    var notes = row.Cells["Notes"].Value?.ToString()?.Replace(",", ";");

                    writer.WriteLine($"{date:MM/dd/yyyy},{conf},{guest},{property},{method},{checkNum},{amount:F2},{notes}");
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
