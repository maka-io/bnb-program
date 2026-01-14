using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Check Ledger Summary Report dialog - migrated from CHKLEDGR.FRM
/// Provides options for generating check ledger reports.
/// </summary>
public partial class CheckLedgerReportForm : Form
{
    private readonly BnBDbContext _dbContext;

    public DateTime? StartDate => dtpStartDate.Value;
    public DateTime? EndDate => chkHasEndDate.Checked ? dtpEndDate.Value : null;
    public string Category { get; private set; } = "";
    public bool DisplayOnly => chkDisplayOnly.Checked;
    public bool Cancelled { get; private set; } = true;

    public CheckLedgerReportForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void CheckLedgerReportForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        dtpStartDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
        dtpEndDate.Value = DateTime.Today;
        chkHasEndDate.Checked = true;
        radHost.Checked = true;
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
        if (!ValidateInput()) return;

        // Determine category
        if (radHost.Checked)
            Category = "Host";
        else if (radTravel.Checked)
            Category = "Travel";
        else if (radMisc.Checked)
            Category = "Miscellaneous";
        else if (radAll.Checked)
            Category = "All";

        var startDate = dtpStartDate.Value.Date;
        var endDate = chkHasEndDate.Checked ? dtpEndDate.Value.Date : DateTime.Today;

        // Query checks from the database
        var checksQuery = _dbContext.Checks
            .Include(c => c.Accommodation)
            .ThenInclude(a => a!.Property)
            .Include(c => c.Accommodation)
            .ThenInclude(a => a!.Guest)
            .Where(c => c.CheckDate >= startDate && c.CheckDate <= endDate);

        // Filter by category if not "All"
        if (Category != "All")
        {
            checksQuery = checksQuery.Where(c => c.Category == Category);
        }

        var checks = checksQuery.ToList();

        // Transform to CheckRecord DTOs for the report
        var checkRecords = checks.Select(c => new CheckRecord
        {
            CheckNumber = int.TryParse(c.CheckNumber, out var num) ? num : 0,
            CheckDate = c.CheckDate,
            PayTo = c.PayableTo,
            ConfirmationNumber = c.ConfirmationNumber > 0 ? c.ConfirmationNumber : c.Accommodation?.ConfirmationNumber ?? 0,
            GuestLastName = c.Accommodation?.LastName ?? c.Accommodation?.Guest?.LastName,
            Location = c.Accommodation?.Property?.Location,
            Category = c.Category,
            Amount = c.Amount,
            IsVoid = c.IsVoid
        }).ToList();

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new CheckLedgerReport(startDate, endDate, checkRecords, Category, companyInfo);
        using var viewer = new ReportViewerForm(report, autoPrint);
        viewer.ShowDialog(this);
    }

    private void btnPrinterSetup_Click(object sender, EventArgs e)
    {
        using var printDialog = new PrintDialog();
        printDialog.ShowDialog();
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Cancelled = true;
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private bool ValidateInput()
    {
        if (!radHost.Checked && !radTravel.Checked && !radMisc.Checked && !radAll.Checked)
        {
            MessageBox.Show("Category has not been selected.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (chkHasEndDate.Checked && dtpStartDate.Value > dtpEndDate.Value)
        {
            MessageBox.Show("Starting date cannot be greater than ending date.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void chkHasEndDate_CheckedChanged(object sender, EventArgs e)
    {
        dtpEndDate.Enabled = chkHasEndDate.Checked;
    }
}
