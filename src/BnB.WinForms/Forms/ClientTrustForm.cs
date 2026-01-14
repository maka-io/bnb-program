using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Client Trust Reconciliation form - migrated from ClntTrst.frm
/// Shows client trust account reconciliation.
/// </summary>
public partial class ClientTrustForm : Form
{
    private readonly BnBDbContext _dbContext;

    public ClientTrustForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void ClientTrustForm_Load(object sender, EventArgs e)
    {
        // Default to current month
        dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        dtpEndDate.Value = dtpStartDate.Value.AddMonths(1).AddDays(-1);
    }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
        CalculateTrustBalance();
    }

    private void CalculateTrustBalance()
    {
        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;

        // Get payments received in the period
        var paymentsReceived = _dbContext.Payments
            .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
            .Sum(p => p.Amount);

        // Get checks written in the period
        var checksWritten = _dbContext.Checks
            .Where(c => c.CheckDate >= startDate && c.CheckDate <= endDate && !c.IsVoid)
            .Sum(c => c.Amount);

        // Get deposits due
        var depositsDue = _dbContext.Payments
            .Where(p => p.DepositDueDate >= startDate && p.DepositDueDate <= endDate)
            .Sum(p => p.DepositDue ?? 0);

        // Get prepayments due
        var prepaymentsDue = _dbContext.Payments
            .Where(p => p.PrepaymentDueDate >= startDate && p.PrepaymentDueDate <= endDate)
            .Sum(p => p.PrepaymentDue ?? 0);

        // Display results
        txtPaymentsReceived.Text = paymentsReceived.ToString("C2");
        txtChecksWritten.Text = checksWritten.ToString("C2");
        txtDepositsDue.Text = depositsDue.ToString("C2");
        txtPrepaymentsDue.Text = prepaymentsDue.ToString("C2");

        var netChange = paymentsReceived - checksWritten;
        txtNetChange.Text = netChange.ToString("C2");
        txtNetChange.ForeColor = netChange >= 0 ? Color.Green : Color.Red;

        var totalDue = depositsDue + prepaymentsDue;
        txtTotalDue.Text = totalDue.ToString("C2");
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

        // Calculate the same values as CalculateTrustBalance
        var paymentsReceived = _dbContext.Payments
            .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
            .Sum(p => p.Amount);

        var checksWritten = _dbContext.Checks
            .Where(c => c.CheckDate >= startDate && c.CheckDate <= endDate && !c.IsVoid)
            .Sum(c => c.Amount);

        var depositsDue = _dbContext.Payments
            .Where(p => p.DepositDueDate >= startDate && p.DepositDueDate <= endDate)
            .Sum(p => p.DepositDue ?? 0);

        var prepaymentsDue = _dbContext.Payments
            .Where(p => p.PrepaymentDueDate >= startDate && p.PrepaymentDueDate <= endDate)
            .Sum(p => p.PrepaymentDue ?? 0);

        var summary = new ClientTrustSummary
        {
            PaymentsReceived = paymentsReceived,
            ChecksWritten = checksWritten,
            DepositsDue = depositsDue,
            PrepaymentsDue = prepaymentsDue
        };

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new ClientTrustSummaryReport(startDate, endDate, summary, companyInfo);
        using var viewer = new ReportViewerForm(report, autoPrint);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
