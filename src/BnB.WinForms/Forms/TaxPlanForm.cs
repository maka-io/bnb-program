using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Services;

namespace BnB.WinForms.Forms;

/// <summary>
/// Tax Plan form - migrated from TAXPLAN.FRM
/// Manages tax plan codes and descriptions.
/// </summary>
public partial class TaxPlanForm : Form
{
    private readonly BnBDbContext _dbContext;
    private readonly FormStateManager _stateManager;
    private readonly BindingSource _bindingSource;

    private FormMode _currentMode = FormMode.Browse;
    private TaxPlan? _currentPlan;

    public TaxPlanForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        _stateManager = new FormStateManager();
        _bindingSource = new BindingSource();

        InitializeComponent();
        SetupDataBindings();
    }

    private void TaxPlanForm_Load(object sender, EventArgs e)
    {
        LoadPlans();
        SetMode(FormMode.Browse);
    }

    private void SetupDataBindings()
    {
        txtPlanCode.DataBindings.Add("Text", _bindingSource, nameof(TaxPlan.PlanCode), true);
        txtPlanTitle.DataBindings.Add("Text", _bindingSource, nameof(TaxPlan.PlanTitle), true);
        txtDescription.DataBindings.Add("Text", _bindingSource, nameof(TaxPlan.Description), true);

        dgvPlans.DataSource = _bindingSource;
    }

    private void LoadPlans()
    {
        try
        {
            var plans = _dbContext.TaxPlans
                .OrderBy(p => p.PlanCode)
                .ToList();

            _bindingSource.DataSource = plans;

            if (plans.Count == 0)
            {
                SetMode(FormMode.NoRows);
            }
            else
            {
                SetMode(FormMode.Browse);
            }

            UpdateRecordCount();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading tax plans: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SetMode(FormMode mode)
    {
        _currentMode = mode;
        _stateManager.SetMode(this, mode);
        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        switch (_currentMode)
        {
            case FormMode.Browse:
                btnInsert.Enabled = true;
                btnUpdate.Enabled = _bindingSource.Count > 0;
                btnDelete.Enabled = _bindingSource.Count > 0;
                btnCommit.Enabled = false;
                btnCancel.Enabled = false;
                btnClose.Enabled = true;
                dgvPlans.Enabled = true;
                txtPlanCode.ReadOnly = true;
                break;

            case FormMode.Insert:
            case FormMode.Update:
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCommit.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = false;
                dgvPlans.Enabled = false;
                txtPlanCode.ReadOnly = _currentMode == FormMode.Update;
                break;

            case FormMode.Delete:
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCommit.Enabled = true;
                btnCancel.Enabled = true;
                btnClose.Enabled = false;
                dgvPlans.Enabled = false;
                break;

            case FormMode.NoRows:
                btnInsert.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCommit.Enabled = false;
                btnCancel.Enabled = false;
                btnClose.Enabled = true;
                dgvPlans.Enabled = true;
                break;
        }
    }

    private void UpdateRecordCount()
    {
        lblRecordCount.Text = $"Record {_bindingSource.Position + 1} of {_bindingSource.Count}";
    }

    #region Button Event Handlers

    private void btnInsert_Click(object sender, EventArgs e)
    {
        SetMode(FormMode.Insert);

        _currentPlan = new TaxPlan
        {
            PlanCode = ""
        };

        _bindingSource.Add(_currentPlan);
        _bindingSource.Position = _bindingSource.Count - 1;

        txtPlanCode.Focus();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is TaxPlan plan)
        {
            _currentPlan = plan;
            SetMode(FormMode.Update);
            txtPlanTitle.Focus();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is TaxPlan plan)
        {
            // Check if plan is in use by properties
            var isUsed = _dbContext.Properties
                .Any(p => p.TaxPlanCode == plan.PlanCode);

            if (isUsed)
            {
                MessageBox.Show(
                    "Cannot delete this tax plan because it is assigned to one or more properties.",
                    "Cannot Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _currentPlan = plan;
            SetMode(FormMode.Delete);

            var result = MessageBox.Show(
                $"Are you sure you want to delete tax plan '{plan.PlanCode}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                CommitDelete();
            }
            else
            {
                SetMode(FormMode.Browse);
            }
        }
    }

    private void btnCommit_Click(object sender, EventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            switch (_currentMode)
            {
                case FormMode.Insert:
                    _bindingSource.EndEdit();
                    if (_currentPlan != null)
                    {
                        _dbContext.TaxPlans.Add(_currentPlan);
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Tax plan added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case FormMode.Update:
                    _bindingSource.EndEdit();
                    _dbContext.SaveChanges();
                    MessageBox.Show("Tax plan updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            LoadPlans();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CommitDelete()
    {
        try
        {
            if (_currentPlan != null)
            {
                _dbContext.TaxPlans.Remove(_currentPlan);
                _dbContext.SaveChanges();
                MessageBox.Show("Tax plan deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadPlans();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            SetMode(FormMode.Browse);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        _bindingSource.CancelEdit();

        if (_currentMode == FormMode.Insert && _currentPlan != null)
        {
            _bindingSource.Remove(_currentPlan);
        }

        _currentPlan = null;
        LoadPlans();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    #endregion

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtPlanCode.Text))
        {
            MessageBox.Show("Plan code is required.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPlanCode.Focus();
            return false;
        }

        // Check for duplicate plan code on insert
        if (_currentMode == FormMode.Insert)
        {
            var planCode = txtPlanCode.Text.Trim();
            if (_dbContext.TaxPlans.Any(p => p.PlanCode == planCode))
            {
                MessageBox.Show("A tax plan with this code already exists.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlanCode.Focus();
                return false;
            }
        }

        return true;
    }

    private void dgvPlans_SelectionChanged(object sender, EventArgs e)
    {
        if (_currentMode == FormMode.Browse)
        {
            UpdateRecordCount();
        }
    }

    private void TaxPlanForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (_currentMode == FormMode.Insert || _currentMode == FormMode.Update)
        {
            var result = MessageBox.Show(
                "You have unsaved changes. Do you want to save before closing?",
                "Unsaved Changes",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    btnCommit_Click(sender, e);
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
