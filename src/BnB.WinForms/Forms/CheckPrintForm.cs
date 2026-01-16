using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Display model for checks in the grid - allows Selected to be editable
/// </summary>
public class CheckDisplayItem
{
    public int Id { get; set; }
    public bool Selected { get; set; }
    public string CheckNumber { get; set; } = string.Empty;
    public DateTime? CheckDate { get; set; }
    public string? PayableTo { get; set; }
    public string PropertyName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string? Memo { get; set; }
}

/// <summary>
/// Check printing form - migrated from ChkPrint.frm
/// Prints checks to vendors and hosts.
/// </summary>
public partial class CheckPrintForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();
    private List<Check> _checksToPrint = new();

    public CheckPrintForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void CheckPrintForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        try
        {
            LoadUnprintedChecks();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading checks: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadUnprintedChecks()
    {
        // Note: IsPrinted is [NotMapped], so we load all non-void checks
        // and filter in memory. In production, consider adding IsPrinted to the DB schema.
        _checksToPrint = _dbContext.Checks
            .Include(c => c.Accommodation)
                .ThenInclude(a => a!.Property)
            .Where(c => !c.IsVoid)
            .OrderBy(c => c.CheckDate)
            .ToList()
            .Where(c => !c.IsPrinted) // Filter in memory since IsPrinted is [NotMapped]
            .ToList();

        var displayData = _checksToPrint.Select(c => new CheckDisplayItem
        {
            Id = c.Id,
            Selected = true,
            CheckNumber = c.CheckNumber,
            CheckDate = c.CheckDate,
            PayableTo = c.PayableTo,
            PropertyName = c.Accommodation?.Property?.Location ?? "N/A",
            Amount = c.Amount,
            Memo = c.Memo
        }).ToList();

        _bindingSource.DataSource = displayData;
        dgvChecks.DataSource = _bindingSource;
        ConfigureGrid();
        UpdateSummary();
    }

    private void ConfigureGrid()
    {
        if (dgvChecks.Columns.Count == 0) return;

        if (dgvChecks.Columns.Contains("Id"))
            dgvChecks.Columns["Id"].Visible = false;

        if (dgvChecks.Columns.Contains("Selected"))
        {
            dgvChecks.Columns["Selected"].HeaderText = "Print";
            dgvChecks.Columns["Selected"].Width = 50;
            dgvChecks.Columns["Selected"].ReadOnly = false;
        }

        if (dgvChecks.Columns.Contains("CheckNumber"))
        {
            dgvChecks.Columns["CheckNumber"].HeaderText = "Check #";
            dgvChecks.Columns["CheckNumber"].Width = 80;
        }

        if (dgvChecks.Columns.Contains("CheckDate"))
        {
            dgvChecks.Columns["CheckDate"].HeaderText = "Date";
            dgvChecks.Columns["CheckDate"].Width = 90;
            dgvChecks.Columns["CheckDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        if (dgvChecks.Columns.Contains("PayableTo"))
        {
            dgvChecks.Columns["PayableTo"].HeaderText = "Pay To";
            dgvChecks.Columns["PayableTo"].Width = 150;
        }

        if (dgvChecks.Columns.Contains("PropertyName"))
        {
            dgvChecks.Columns["PropertyName"].HeaderText = "Property";
            dgvChecks.Columns["PropertyName"].Width = 120;
        }

        if (dgvChecks.Columns.Contains("Amount"))
        {
            dgvChecks.Columns["Amount"].HeaderText = "Amount";
            dgvChecks.Columns["Amount"].Width = 100;
            dgvChecks.Columns["Amount"].DefaultCellStyle.Format = "C2";
            dgvChecks.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (dgvChecks.Columns.Contains("Memo"))
        {
            dgvChecks.Columns["Memo"].HeaderText = "Memo";
            dgvChecks.Columns["Memo"].Width = 150;
        }
    }

    private void UpdateSummary()
    {
        var selectedCount = 0;
        decimal selectedTotal = 0;

        if (dgvChecks.Columns.Contains("Selected") && dgvChecks.Columns.Contains("Amount"))
        {
            foreach (DataGridViewRow row in dgvChecks.Rows)
            {
                if (row.Cells["Selected"].Value is true)
                {
                    selectedCount++;
                    if (row.Cells["Amount"].Value is decimal amount)
                        selectedTotal += amount;
                }
            }
        }

        lblSummary.Text = $"Selected: {selectedCount} checks | Total: {selectedTotal:C2}";
    }

    private void dgvChecks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex >= 0 && e.ColumnIndex < dgvChecks.Columns.Count &&
            dgvChecks.Columns[e.ColumnIndex].Name == "Selected")
        {
            UpdateSummary();
        }
    }

    private void dgvChecks_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < dgvChecks.Columns.Count &&
            dgvChecks.Columns[e.ColumnIndex].Name == "Selected")
        {
            dgvChecks.EndEdit();
            UpdateSummary();
        }
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
        if (!dgvChecks.Columns.Contains("Selected")) return;
        foreach (DataGridViewRow row in dgvChecks.Rows)
        {
            row.Cells["Selected"].Value = true;
        }
        UpdateSummary();
    }

    private void btnSelectNone_Click(object sender, EventArgs e)
    {
        if (!dgvChecks.Columns.Contains("Selected")) return;
        foreach (DataGridViewRow row in dgvChecks.Rows)
        {
            row.Cells["Selected"].Value = false;
        }
        UpdateSummary();
    }

    private void btnPreview_Click(object sender, EventArgs e)
    {
        var selectedCheckIds = GetSelectedCheckIds();
        if (selectedCheckIds.Count == 0)
        {
            MessageBox.Show("Please select at least one check to preview.", "No Selection",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var checks = _dbContext.Checks
                .Include(c => c.Accommodation)
                    .ThenInclude(a => a.Property)
                .Where(c => selectedCheckIds.Contains(c.Id))
                .OrderBy(c => c.CheckNumber)
                .ToList();

            var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();

            var report = new CheckPrintReport(checks, companyInfo);
            var viewer = new ReportViewerForm(report);
            viewer.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error generating preview: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        var selectedCheckIds = GetSelectedCheckIds();
        if (selectedCheckIds.Count == 0)
        {
            MessageBox.Show("Please select at least one check to print.", "No Selection",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show(
            $"Print {selectedCheckIds.Count} check(s)?\n\nMake sure check stock is loaded in the printer.",
            "Confirm Print",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            PrintChecks(selectedCheckIds);
        }
    }

    private List<int> GetSelectedCheckIds()
    {
        var ids = new List<int>();
        if (!dgvChecks.Columns.Contains("Selected") || !dgvChecks.Columns.Contains("Id"))
            return ids;

        foreach (DataGridViewRow row in dgvChecks.Rows)
        {
            if (row.Cells["Selected"].Value is true && row.Cells["Id"].Value is int checkId)
            {
                ids.Add(checkId);
            }
        }
        return ids;
    }

    private void PrintChecks(List<int> checkIds)
    {
        try
        {
            var checks = _dbContext.Checks
                .Include(c => c.Accommodation)
                    .ThenInclude(a => a.Property)
                .Where(c => checkIds.Contains(c.Id))
                .OrderBy(c => c.CheckNumber)
                .ToList();

            var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();

            var report = new CheckPrintReport(checks, companyInfo);
            var pdfBytes = report.GeneratePdf();

            // Save to temp file and open with default PDF viewer/printer
            var tempFile = Path.Combine(Path.GetTempPath(), $"Checks_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
            File.WriteAllBytes(tempFile, pdfBytes);

            // Open PDF for printing
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = tempFile,
                UseShellExecute = true,
                Verb = "print"
            };

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch
            {
                // If print verb fails, just open the file
                psi.Verb = "open";
                System.Diagnostics.Process.Start(psi);
            }

            // Mark checks as printed (in memory only since IsPrinted/PrintedDate are [NotMapped])
            foreach (var check in checks)
            {
                check.IsPrinted = true;
                check.PrintedDate = DateTime.Now;
            }

            MessageBox.Show($"{checkIds.Count} check(s) have been sent to the printer.\n\n" +
                "The PDF has been opened for printing. Please ensure your check stock is loaded.",
                "Checks Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadUnprintedChecks();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error printing checks: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
