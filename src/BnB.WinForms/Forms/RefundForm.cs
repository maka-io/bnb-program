using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Refund tracking form - migrated from RefundCC.frm
/// Tracks refunds owed to guests.
/// </summary>
public partial class RefundForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();

    public RefundForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void RefundForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        LoadRefunds();
    }

    private void LoadRefunds()
    {
        var payments = _dbContext.Payments
            .Include(p => p.Guest)
            .Where(p => p.RefundOwed.HasValue && p.RefundOwed > 0)
            .OrderByDescending(p => p.PaymentDate)
            .ToList();

        _bindingSource.DataSource = payments;
        dgvRefunds.DataSource = _bindingSource;
        ConfigureGrid();
        UpdateSummary(payments);
    }

    private void ConfigureGrid()
    {
        if (dgvRefunds.Columns.Count == 0) return;

        foreach (DataGridViewColumn col in dgvRefunds.Columns)
        {
            col.Visible = false;
        }

        ShowColumn("ConfirmationNumber", "Conf #", 80);
        ShowColumn("FirstName", "First Name", 100);
        ShowColumn("LastName", "Last Name", 100);
        ShowColumn("RefundOwed", "Refund Owed", 100, "C2");
        ShowColumn("PaymentDate", "Date", 90, "MM/dd/yyyy");
        ShowColumn("Comments", "Comments", 200);
    }

    private void ShowColumn(string name, string header, int width, string? format = null)
    {
        if (!dgvRefunds.Columns.Contains(name)) return;

        var col = dgvRefunds.Columns[name];
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

    private void UpdateSummary(List<Payment> payments)
    {
        var count = payments.Count;
        var totalRefunds = payments.Sum(p => p.RefundOwed ?? 0);

        lblSummary.Text = $"Pending Refunds: {count} | Total: {totalRefunds:C2}";
    }

    private void btnMarkRefunded_Click(object sender, EventArgs e)
    {
        if (dgvRefunds.CurrentRow?.DataBoundItem is not Payment payment) return;

        var result = MessageBox.Show(
            $"Mark refund of {payment.RefundOwed:C2} to {payment.FirstName} {payment.LastName} as completed?",
            "Mark Refunded",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                payment.RefundOwed = 0;
                _dbContext.SaveChanges();
                LoadRefunds();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating record: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        var payments = _dbContext.Payments
            .Include(p => p.Guest)
            .Where(p => p.RefundOwed.HasValue && p.RefundOwed > 0)
            .OrderByDescending(p => p.PaymentDate)
            .ToList();

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new RefundListReport(payments, companyInfo);
        using var viewer = new ReportViewerForm(report, autoPrint);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
