using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Services;
using BnB.WinForms.UI;

namespace BnB.WinForms.Forms;

/// <summary>
/// Tax Plan form - manages tax plans with rates and application settings.
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
        SetupFutureCheckboxHandlers();
    }

    private void SetupFutureCheckboxHandlers()
    {
        chkTax1Future.CheckedChanged += (s, e) => UpdateFutureFieldsEnabled();
        chkTax2Future.CheckedChanged += (s, e) => UpdateFutureFieldsEnabled();
        chkTax3Future.CheckedChanged += (s, e) => UpdateFutureFieldsEnabled();
    }

    private void UpdateFutureFieldsEnabled()
    {
        bool editing = _currentMode == FormMode.Insert || _currentMode == FormMode.Update;

        txtTax1FutureRate.Enabled = editing && chkTax1Future.Checked;
        dtpTax1FutureDate.Enabled = editing && chkTax1Future.Checked;

        txtTax2FutureRate.Enabled = editing && chkTax2Future.Checked;
        dtpTax2FutureDate.Enabled = editing && chkTax2Future.Checked;

        txtTax3FutureRate.Enabled = editing && chkTax3Future.Checked;
        dtpTax3FutureDate.Enabled = editing && chkTax3Future.Checked;
    }

    private void TaxPlanForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        LoadPlans();
        SetMode(FormMode.Browse);
    }

    private void LoadPlans()
    {
        try
        {
            var plans = _dbContext.TaxPlans
                .OrderBy(p => p.PlanTitle)
                .ToList();

            _bindingSource.DataSource = plans;
            dgvPlans.DataSource = _bindingSource;
            ConfigureGrid();

            if (plans.Count == 0)
            {
                SetMode(FormMode.NoRows);
                ClearForm();
            }
            else
            {
                SetMode(FormMode.Browse);
                DisplayCurrentPlan();
            }

            UpdateRecordCount();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading tax plans: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ConfigureGrid()
    {
        dgvPlans.AutoGenerateColumns = false;
        dgvPlans.Columns.Clear();

        dgvPlans.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "PlanTitle",
            HeaderText = "Plan Title",
            Width = 150
        });

        dgvPlans.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "PlanCode",
            HeaderText = "Code",
            Width = 60
        });

        dgvPlans.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Tax1Rate",
            HeaderText = "Tax 1 %",
            Width = 70,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "N4" }
        });

        dgvPlans.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Tax2Rate",
            HeaderText = "Tax 2 %",
            Width = 70,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "N4" }
        });

        dgvPlans.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Tax3Rate",
            HeaderText = "Tax 3 %",
            Width = 70,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "N4" }
        });
    }

    private void DisplayCurrentPlan()
    {
        if (_bindingSource.Current is not TaxPlan plan)
        {
            ClearForm();
            return;
        }

        txtPlanTitle.Text = plan.PlanTitle ?? "";
        txtDescription.Text = plan.Description ?? "";
        txtPlanCode.Text = plan.PlanCode;

        // Tax 1
        txtTax1Rate.Text = plan.Tax1Rate.ToString("F4");
        txtTax1Desc.Text = plan.Tax1Description ?? "";
        cboTax1Apply.SelectedIndex = plan.Tax1Application;
        chkTax1Future.Checked = plan.FutureTax1Rate.HasValue;
        txtTax1FutureRate.Text = plan.FutureTax1Rate?.ToString("F4") ?? "";
        dtpTax1FutureDate.Value = plan.FutureTax1EffectiveDate ?? DateTime.Today;

        // Tax 2
        txtTax2Rate.Text = plan.Tax2Rate.ToString("F4");
        txtTax2Desc.Text = plan.Tax2Description ?? "";
        cboTax2Apply.SelectedIndex = plan.Tax2Application;
        chkTax2Future.Checked = plan.FutureTax2Rate.HasValue;
        txtTax2FutureRate.Text = plan.FutureTax2Rate?.ToString("F4") ?? "";
        dtpTax2FutureDate.Value = plan.FutureTax2EffectiveDate ?? DateTime.Today;

        // Tax 3
        txtTax3Rate.Text = plan.Tax3Rate.ToString("F4");
        txtTax3Desc.Text = plan.Tax3Description ?? "";
        cboTax3Apply.SelectedIndex = plan.Tax3Application;
        chkTax3Future.Checked = plan.FutureTax3Rate.HasValue;
        txtTax3FutureRate.Text = plan.FutureTax3Rate?.ToString("F4") ?? "";
        dtpTax3FutureDate.Value = plan.FutureTax3EffectiveDate ?? DateTime.Today;

        UpdateFutureFieldsEnabled();
    }

    private void ClearForm()
    {
        txtPlanTitle.Text = "";
        txtDescription.Text = "";
        txtPlanCode.Text = "";

        txtTax1Rate.Text = "0.0000";
        txtTax1Desc.Text = "";
        cboTax1Apply.SelectedIndex = 2;
        chkTax1Future.Checked = false;
        txtTax1FutureRate.Text = "";
        dtpTax1FutureDate.Value = DateTime.Today;

        txtTax2Rate.Text = "0.0000";
        txtTax2Desc.Text = "";
        cboTax2Apply.SelectedIndex = 2;
        chkTax2Future.Checked = false;
        txtTax2FutureRate.Text = "";
        dtpTax2FutureDate.Value = DateTime.Today;

        txtTax3Rate.Text = "0.0000";
        txtTax3Desc.Text = "";
        cboTax3Apply.SelectedIndex = 2;
        chkTax3Future.Checked = false;
        txtTax3FutureRate.Text = "";
        dtpTax3FutureDate.Value = DateTime.Today;
    }

    private void ApplyFormToPlan(TaxPlan plan)
    {
        plan.PlanTitle = txtPlanTitle.Text.Trim();
        plan.Description = txtDescription.Text.Trim();

        // Tax 1
        if (decimal.TryParse(txtTax1Rate.Text, out var tax1Rate))
            plan.Tax1Rate = tax1Rate;
        plan.Tax1Description = txtTax1Desc.Text.Trim();
        plan.Tax1Application = cboTax1Apply.SelectedIndex;

        if (chkTax1Future.Checked && decimal.TryParse(txtTax1FutureRate.Text, out var futureTax1))
        {
            plan.FutureTax1Rate = futureTax1;
            plan.FutureTax1EffectiveDate = dtpTax1FutureDate.Value;
        }
        else
        {
            plan.FutureTax1Rate = null;
            plan.FutureTax1EffectiveDate = null;
        }

        // Tax 2
        if (decimal.TryParse(txtTax2Rate.Text, out var tax2Rate))
            plan.Tax2Rate = tax2Rate;
        plan.Tax2Description = txtTax2Desc.Text.Trim();
        plan.Tax2Application = cboTax2Apply.SelectedIndex;

        if (chkTax2Future.Checked && decimal.TryParse(txtTax2FutureRate.Text, out var futureTax2))
        {
            plan.FutureTax2Rate = futureTax2;
            plan.FutureTax2EffectiveDate = dtpTax2FutureDate.Value;
        }
        else
        {
            plan.FutureTax2Rate = null;
            plan.FutureTax2EffectiveDate = null;
        }

        // Tax 3
        if (decimal.TryParse(txtTax3Rate.Text, out var tax3Rate))
            plan.Tax3Rate = tax3Rate;
        plan.Tax3Description = txtTax3Desc.Text.Trim();
        plan.Tax3Application = cboTax3Apply.SelectedIndex;

        if (chkTax3Future.Checked && decimal.TryParse(txtTax3FutureRate.Text, out var futureTax3))
        {
            plan.FutureTax3Rate = futureTax3;
            plan.FutureTax3EffectiveDate = dtpTax3FutureDate.Value;
        }
        else
        {
            plan.FutureTax3Rate = null;
            plan.FutureTax3EffectiveDate = null;
        }

        // Generate plan code from application settings
        plan.PlanCode = plan.GeneratePlanCode();
    }

    private void SetMode(FormMode mode)
    {
        _currentMode = mode;
        _stateManager.SetMode(this, mode);
        UpdateButtonStates();
        UpdateFutureFieldsEnabled();
    }

    private void UpdateButtonStates()
    {
        bool editing = _currentMode == FormMode.Insert || _currentMode == FormMode.Update;

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
                SetFieldsReadOnly(true);
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
                SetFieldsReadOnly(false);
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
                SetFieldsReadOnly(true);
                break;
        }
    }

    private void SetFieldsReadOnly(bool readOnly)
    {
        txtPlanTitle.ReadOnly = readOnly;
        txtDescription.ReadOnly = readOnly;

        txtTax1Rate.ReadOnly = readOnly;
        txtTax1Desc.ReadOnly = readOnly;
        cboTax1Apply.Enabled = !readOnly;
        chkTax1Future.Enabled = !readOnly;
        txtTax1FutureRate.ReadOnly = readOnly;

        txtTax2Rate.ReadOnly = readOnly;
        txtTax2Desc.ReadOnly = readOnly;
        cboTax2Apply.Enabled = !readOnly;
        chkTax2Future.Enabled = !readOnly;
        txtTax2FutureRate.ReadOnly = readOnly;

        txtTax3Rate.ReadOnly = readOnly;
        txtTax3Desc.ReadOnly = readOnly;
        cboTax3Apply.Enabled = !readOnly;
        chkTax3Future.Enabled = !readOnly;
        txtTax3FutureRate.ReadOnly = readOnly;
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
            PlanTitle = "New Tax Plan",
            Tax1Application = 2,
            Tax2Application = 2,
            Tax3Application = 2
        };

        ClearForm();
        txtPlanTitle.Text = "New Tax Plan";
        txtPlanTitle.Focus();
        txtPlanTitle.SelectAll();
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
                $"Are you sure you want to delete tax plan '{plan.PlanTitle}'?",
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
                    if (_currentPlan != null)
                    {
                        ApplyFormToPlan(_currentPlan);
                        _dbContext.TaxPlans.Add(_currentPlan);
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Tax plan added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case FormMode.Update:
                    if (_currentPlan != null)
                    {
                        ApplyFormToPlan(_currentPlan);
                    }
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
        if (string.IsNullOrWhiteSpace(txtPlanTitle.Text))
        {
            MessageBox.Show("Plan title is required.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPlanTitle.Focus();
            return false;
        }

        // Validate tax rates
        if (!decimal.TryParse(txtTax1Rate.Text, out _))
        {
            MessageBox.Show("Please enter a valid Tax 1 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax1Rate.Focus();
            return false;
        }

        if (!decimal.TryParse(txtTax2Rate.Text, out _))
        {
            MessageBox.Show("Please enter a valid Tax 2 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax2Rate.Focus();
            return false;
        }

        if (!decimal.TryParse(txtTax3Rate.Text, out _))
        {
            MessageBox.Show("Please enter a valid Tax 3 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax3Rate.Focus();
            return false;
        }

        // Validate future rates if enabled
        if (chkTax1Future.Checked && !decimal.TryParse(txtTax1FutureRate.Text, out _))
        {
            MessageBox.Show("Please enter a valid future Tax 1 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax1FutureRate.Focus();
            return false;
        }

        if (chkTax2Future.Checked && !decimal.TryParse(txtTax2FutureRate.Text, out _))
        {
            MessageBox.Show("Please enter a valid future Tax 2 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax2FutureRate.Focus();
            return false;
        }

        if (chkTax3Future.Checked && !decimal.TryParse(txtTax3FutureRate.Text, out _))
        {
            MessageBox.Show("Please enter a valid future Tax 3 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax3FutureRate.Focus();
            return false;
        }

        return true;
    }

    private void dgvPlans_SelectionChanged(object sender, EventArgs e)
    {
        if (_currentMode == FormMode.Browse)
        {
            DisplayCurrentPlan();
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
