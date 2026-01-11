using BnB.Core.Models;
using BnB.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Check Edit form - migrated from Chkedit.frm
/// View and edit printed checks.
/// </summary>
public partial class CheckEditForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();
    private List<Check> _checks = new();
    private Check? _currentCheck;

    public CheckEditForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void CheckEditForm_Load(object sender, EventArgs e)
    {
        LoadChecks();
        UpdateButtonStates();
    }

    private void LoadChecks()
    {
        _checks = _dbContext.Checks
            .Include(c => c.Accommodation)
            .OrderByDescending(c => c.CheckDate)
            .ThenByDescending(c => c.CheckNumber)
            .ToList();

        _bindingSource.DataSource = _checks;
        dgvChecks.DataSource = _bindingSource;
        ConfigureGrid();
    }

    private void ConfigureGrid()
    {
        if (dgvChecks.Columns.Count == 0) return;

        dgvChecks.Columns["Id"].Visible = false;
        dgvChecks.Columns["AccommodationId"].Visible = false;
        dgvChecks.Columns["Accommodation"].Visible = false;

        if (dgvChecks.Columns.Contains("CheckNumber"))
        {
            dgvChecks.Columns["CheckNumber"].HeaderText = "Check #";
            dgvChecks.Columns["CheckNumber"].Width = 80;
            dgvChecks.Columns["CheckNumber"].DisplayIndex = 0;
        }

        if (dgvChecks.Columns.Contains("CheckDate"))
        {
            dgvChecks.Columns["CheckDate"].HeaderText = "Date";
            dgvChecks.Columns["CheckDate"].Width = 90;
            dgvChecks.Columns["CheckDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvChecks.Columns["CheckDate"].DisplayIndex = 1;
        }

        if (dgvChecks.Columns.Contains("PayableTo"))
        {
            dgvChecks.Columns["PayableTo"].HeaderText = "Pay To";
            dgvChecks.Columns["PayableTo"].Width = 150;
            dgvChecks.Columns["PayableTo"].DisplayIndex = 2;
        }

        if (dgvChecks.Columns.Contains("Amount"))
        {
            dgvChecks.Columns["Amount"].HeaderText = "Amount";
            dgvChecks.Columns["Amount"].Width = 90;
            dgvChecks.Columns["Amount"].DefaultCellStyle.Format = "C2";
            dgvChecks.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChecks.Columns["Amount"].DisplayIndex = 3;
        }

        if (dgvChecks.Columns.Contains("IsVoid"))
        {
            dgvChecks.Columns["IsVoid"].HeaderText = "Void";
            dgvChecks.Columns["IsVoid"].Width = 50;
            dgvChecks.Columns["IsVoid"].DisplayIndex = 4;
        }

        if (dgvChecks.Columns.Contains("Memo"))
        {
            dgvChecks.Columns["Memo"].HeaderText = "Memo";
            dgvChecks.Columns["Memo"].Width = 150;
        }

        if (dgvChecks.Columns.Contains("Comments"))
        {
            dgvChecks.Columns["Comments"].Visible = false;
        }
    }

    private void dgvChecks_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvChecks.CurrentRow?.DataBoundItem is Check check)
        {
            _currentCheck = check;
            DisplayCheck(check);
        }
        UpdateButtonStates();
    }

    private void DisplayCheck(Check check)
    {
        txtCheckNumber.Text = check.CheckNumber;
        dtpCheckDate.Value = check.CheckDate ?? DateTime.Now;
        txtPayTo.Text = check.PayTo;
        txtAmount.Text = check.Amount.ToString("F2");
        txtMemo.Text = check.Memo;
        txtComments.Text = check.Comments;
        chkVoid.Checked = check.IsVoid;

        // Get accommodation info
        if (check.Accommodation != null)
        {
            txtConfirmation.Text = check.Accommodation.ConfirmationNumber.ToString();
            txtGuest.Text = $"{check.Accommodation.FirstName} {check.Accommodation.LastName}";
            txtProperty.Text = check.Accommodation.Location;
        }
        else
        {
            txtConfirmation.Text = "";
            txtGuest.Text = "";
            txtProperty.Text = "";
        }
    }

    private void ClearFields()
    {
        txtCheckNumber.Clear();
        dtpCheckDate.Value = DateTime.Now;
        txtPayTo.Clear();
        txtAmount.Clear();
        txtMemo.Clear();
        txtComments.Clear();
        chkVoid.Checked = false;
        txtConfirmation.Clear();
        txtGuest.Clear();
        txtProperty.Clear();
    }

    private void btnVoid_Click(object sender, EventArgs e)
    {
        if (_currentCheck == null) return;

        var action = _currentCheck.IsVoid ? "un-void" : "void";
        var result = MessageBox.Show(
            $"Are you sure you want to {action} check #{_currentCheck.CheckNumber}?",
            "Confirm",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                _currentCheck.IsVoid = !_currentCheck.IsVoid;
                _dbContext.SaveChanges();
                chkVoid.Checked = _currentCheck.IsVoid;
                _bindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating check: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (_currentCheck == null) return;

        try
        {
            _currentCheck.CheckDate = dtpCheckDate.Value;
            _currentCheck.PayTo = txtPayTo.Text.Trim();
            _currentCheck.Memo = txtMemo.Text.Trim();
            _currentCheck.Comments = txtComments.Text.Trim();

            if (decimal.TryParse(txtAmount.Text, out var amount))
            {
                _currentCheck.Amount = amount;
            }

            _dbContext.SaveChanges();
            _bindingSource.ResetBindings(false);

            MessageBox.Show("Check updated successfully.", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving check: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        var searchText = txtSearch.Text.Trim();
        if (string.IsNullOrEmpty(searchText)) return;

        var found = _checks.FirstOrDefault(c =>
            c.CheckNumber.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
            (c.PayTo?.Contains(searchText, StringComparison.OrdinalIgnoreCase) ?? false));

        if (found != null)
        {
            var index = _bindingSource.IndexOf(found);
            if (index >= 0)
            {
                dgvChecks.ClearSelection();
                dgvChecks.Rows[index].Selected = true;
                dgvChecks.FirstDisplayedScrollingRowIndex = index;
            }
        }
        else
        {
            MessageBox.Show("Check not found.", "Search",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void UpdateButtonStates()
    {
        var hasSelection = dgvChecks.CurrentRow != null;
        btnVoid.Enabled = hasSelection;
        btnSave.Enabled = hasSelection;
        grpDetails.Enabled = hasSelection;
    }
}
