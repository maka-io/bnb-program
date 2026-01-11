using BnB.Core.Models;
using BnB.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

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
        LoadUnprintedChecks();
    }

    private void LoadUnprintedChecks()
    {
        _checksToPrint = _dbContext.Checks
            .Include(c => c.Property)
            .Where(c => !c.IsPrinted && !c.IsVoid)
            .OrderBy(c => c.CheckDate)
            .ToList();

        _bindingSource.DataSource = _checksToPrint.Select(c => new
        {
            c.CheckId,
            Selected = true,
            c.CheckNumber,
            c.CheckDate,
            c.PayTo,
            PropertyName = c.Property?.Location ?? "N/A",
            c.Amount,
            c.Memo
        }).ToList();

        dgvChecks.DataSource = _bindingSource;
        ConfigureGrid();
        UpdateSummary();
    }

    private void ConfigureGrid()
    {
        if (dgvChecks.Columns.Count == 0) return;

        if (dgvChecks.Columns.Contains("CheckId"))
            dgvChecks.Columns["CheckId"].Visible = false;

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

        if (dgvChecks.Columns.Contains("PayTo"))
        {
            dgvChecks.Columns["PayTo"].HeaderText = "Pay To";
            dgvChecks.Columns["PayTo"].Width = 150;
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

        foreach (DataGridViewRow row in dgvChecks.Rows)
        {
            if (row.Cells["Selected"].Value is true)
            {
                selectedCount++;
                if (row.Cells["Amount"].Value is decimal amount)
                    selectedTotal += amount;
            }
        }

        lblSummary.Text = $"Selected: {selectedCount} checks | Total: {selectedTotal:C2}";
    }

    private void dgvChecks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex >= 0 && dgvChecks.Columns[e.ColumnIndex].Name == "Selected")
        {
            UpdateSummary();
        }
    }

    private void dgvChecks_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvChecks.Columns[e.ColumnIndex].Name == "Selected")
        {
            dgvChecks.EndEdit();
            UpdateSummary();
        }
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dgvChecks.Rows)
        {
            row.Cells["Selected"].Value = true;
        }
        UpdateSummary();
    }

    private void btnSelectNone_Click(object sender, EventArgs e)
    {
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

        MessageBox.Show($"Preview of {selectedCheckIds.Count} check(s) will be shown here.", "Preview",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        foreach (DataGridViewRow row in dgvChecks.Rows)
        {
            if (row.Cells["Selected"].Value is true && row.Cells["CheckId"].Value is int checkId)
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
            // Mark checks as printed
            var checks = _dbContext.Checks.Where(c => checkIds.Contains(c.CheckId)).ToList();
            foreach (var check in checks)
            {
                check.IsPrinted = true;
                check.PrintedDate = DateTime.Now;
            }
            _dbContext.SaveChanges();

            MessageBox.Show($"{checkIds.Count} check(s) have been marked as printed.\n\nActual printing functionality coming soon.",
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
