using BnB.Data.Context;

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
        dtpStartDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
        dtpEndDate.Value = DateTime.Today;
        radHost.Checked = true;
        chkDisplayOnly.Checked = true;
    }

    private void btnPrint_Click(object sender, EventArgs e)
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
            Category = ""; // All categories

        Cancelled = false;
        DialogResult = DialogResult.OK;

        // For now, show a message that reporting will be implemented
        MessageBox.Show(
            $"Check Ledger Report\n\n" +
            $"Category: {(string.IsNullOrEmpty(Category) ? "All" : Category)}\n" +
            $"Start Date: {dtpStartDate.Value:d}\n" +
            $"End Date: {(chkHasEndDate.Checked ? dtpEndDate.Value.ToString("d") : "Open")}\n" +
            $"Display Only: {chkDisplayOnly.Checked}",
            "Report Preview",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
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
