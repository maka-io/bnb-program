using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Services;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Host Property form - migrated from PROPERTY.FRM
/// Manages property/host account information.
/// </summary>
public partial class PropertyForm : Form
{
    private readonly BnBDbContext _dbContext;
    private readonly FormStateManager _stateManager;
    private readonly BindingSource _bindingSource;

    private FormMode _currentMode = FormMode.Browse;
    private Property? _currentProperty;

    public PropertyForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        _stateManager = new FormStateManager();
        _bindingSource = new BindingSource();

        InitializeComponent();
    }

    private void PropertyForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        LoadTaxPlans();
        LoadMonthComboBoxes();
        LoadProperties();
        SetupDataBindings();
        SetMode(FormMode.Browse);
        UpdatePeakPeriodControlsEnabled();
    }

    private void LoadMonthComboBoxes()
    {
        var months = new[]
        {
            new { Value = (int?)null, Display = "" },
            new { Value = (int?)1, Display = "January" },
            new { Value = (int?)2, Display = "February" },
            new { Value = (int?)3, Display = "March" },
            new { Value = (int?)4, Display = "April" },
            new { Value = (int?)5, Display = "May" },
            new { Value = (int?)6, Display = "June" },
            new { Value = (int?)7, Display = "July" },
            new { Value = (int?)8, Display = "August" },
            new { Value = (int?)9, Display = "September" },
            new { Value = (int?)10, Display = "October" },
            new { Value = (int?)11, Display = "November" },
            new { Value = (int?)12, Display = "December" }
        };

        cboPeakPeriodStartMonth.DataSource = months.ToList();
        cboPeakPeriodStartMonth.DisplayMember = "Display";
        cboPeakPeriodStartMonth.ValueMember = "Value";

        cboPeakPeriodEndMonth.DataSource = months.ToList();
        cboPeakPeriodEndMonth.DisplayMember = "Display";
        cboPeakPeriodEndMonth.ValueMember = "Value";
    }

    private void ChkHasPeakPeriodPolicy_CheckedChanged(object? sender, EventArgs e)
    {
        UpdatePeakPeriodControlsEnabled();
    }

    private void UpdatePeakPeriodControlsEnabled()
    {
        var enabled = chkHasPeakPeriodPolicy.Checked;
        txtPeakPeriodPrepaymentDueDays.Enabled = enabled;
        txtPeakPeriodCancellationNoticeDays.Enabled = enabled;
        txtPeakPeriodCancellationFeePercent.Enabled = enabled;
        cboPeakPeriodStartMonth.Enabled = enabled;
        txtPeakPeriodStartDay.Enabled = enabled;
        cboPeakPeriodEndMonth.Enabled = enabled;
        txtPeakPeriodEndDay.Enabled = enabled;
    }

    private void SetupDataBindings()
    {
        // General Information
        txtAccountNumber.DataBindings.Add("Text", _bindingSource, nameof(Property.AccountNumber), true);
        txtLocation.DataBindings.Add("Text", _bindingSource, nameof(Property.Location), true);
        txtFullName.DataBindings.Add("Text", _bindingSource, nameof(Property.FullName), true);
        txtCheckTo.DataBindings.Add("Text", _bindingSource, nameof(Property.CheckTo), true);
        txtPercentToHost.DataBindings.Add("Text", _bindingSource, nameof(Property.PercentToHost), true);
        txtGrossRatePercent.DataBindings.Add("Text", _bindingSource, nameof(Property.GrossRatePercent), true);

        // Property Address
        txtPropertyAddress.DataBindings.Add("Text", _bindingSource, nameof(Property.PropertyAddress), true);
        txtPropertyCity.DataBindings.Add("Text", _bindingSource, nameof(Property.PropertyCity), true);
        txtPropertyState.DataBindings.Add("Text", _bindingSource, nameof(Property.PropertyState), true);
        txtPropertyZipCode.DataBindings.Add("Text", _bindingSource, nameof(Property.PropertyZipCode), true);
        txtPropertyPhone.DataBindings.Add("Text", _bindingSource, nameof(Property.PropertyPhone), true);
        txtPropertyFax.DataBindings.Add("Text", _bindingSource, nameof(Property.PropertyFax), true);

        // Mailing Address
        txtMailingAddress.DataBindings.Add("Text", _bindingSource, nameof(Property.MailingAddress), true);
        txtMailingCity.DataBindings.Add("Text", _bindingSource, nameof(Property.MailingCity), true);
        txtMailingState.DataBindings.Add("Text", _bindingSource, nameof(Property.MailingState), true);
        txtMailingZipCode.DataBindings.Add("Text", _bindingSource, nameof(Property.MailingZipCode), true);
        txtMailingPhone1.DataBindings.Add("Text", _bindingSource, nameof(Property.MailingPhone1), true);
        txtMailingPhone2.DataBindings.Add("Text", _bindingSource, nameof(Property.MailingPhone2), true);
        txtMailingFax.DataBindings.Add("Text", _bindingSource, nameof(Property.MailingFax), true);

        // Contact Info
        txtEmail.DataBindings.Add("Text", _bindingSource, nameof(Property.Email), true);
        txtWebUrl.DataBindings.Add("Text", _bindingSource, nameof(Property.WebUrl), true);

        // Tax Information
        txtFederalTaxId.DataBindings.Add("Text", _bindingSource, nameof(Property.FederalTaxId), true);
        txtDBA.DataBindings.Add("Text", _bindingSource, nameof(Property.DBA), true);
        txtTaxPlanCode.DataBindings.Add("Text", _bindingSource, nameof(Property.TaxPlanCode), true);

        // Future Percentage
        txtFuturePercent.DataBindings.Add("Text", _bindingSource, nameof(Property.FuturePercent), true);
        dtpFuturePercentDate.DataBindings.Add("Value", _bindingSource, nameof(Property.FuturePercentDate), true);

        // Options
        chkSuppressFlag.DataBindings.Add("Checked", _bindingSource, nameof(Property.SuppressFlag), true);
        chkIsObsolete.DataBindings.Add("Checked", _bindingSource, nameof(Property.IsObsolete), true);
        txtDepositRequired.DataBindings.Add("Text", _bindingSource, nameof(Property.DepositRequired), true);
        chkExceptions.DataBindings.Add("Checked", _bindingSource, nameof(Property.Exceptions), true,
            DataSourceUpdateMode.OnPropertyChanged, false, "Y");
        txtExceptionsDescription.DataBindings.Add("Text", _bindingSource, nameof(Property.ExceptionsDescription), true);

        // Comments
        txtComments.DataBindings.Add("Text", _bindingSource, nameof(Property.Comments), true);

        // Payment Policy - Default Settings
        txtDefaultDepositPercent.DataBindings.Add("Text", _bindingSource, nameof(Property.DefaultDepositPercent), true);
        txtDefaultDepositDueDays.DataBindings.Add("Text", _bindingSource, nameof(Property.DefaultDepositDueDays), true);
        txtDefaultPrepaymentDueDays.DataBindings.Add("Text", _bindingSource, nameof(Property.DefaultPrepaymentDueDays), true);
        txtDefaultCancellationNoticeDays.DataBindings.Add("Text", _bindingSource, nameof(Property.DefaultCancellationNoticeDays), true);
        txtDefaultCancellationFeePercent.DataBindings.Add("Text", _bindingSource, nameof(Property.DefaultCancellationFeePercent), true);
        txtCancellationProcessingFee.DataBindings.Add("Text", _bindingSource, nameof(Property.CancellationProcessingFee), true);

        // Payment Policy - Peak Period Settings
        chkHasPeakPeriodPolicy.DataBindings.Add("Checked", _bindingSource, nameof(Property.HasPeakPeriodPolicy), true,
            DataSourceUpdateMode.OnPropertyChanged);
        txtPeakPeriodPrepaymentDueDays.DataBindings.Add("Text", _bindingSource, nameof(Property.PeakPeriodPrepaymentDueDays), true);
        txtPeakPeriodCancellationNoticeDays.DataBindings.Add("Text", _bindingSource, nameof(Property.PeakPeriodCancellationNoticeDays), true);
        txtPeakPeriodCancellationFeePercent.DataBindings.Add("Text", _bindingSource, nameof(Property.PeakPeriodCancellationFeePercent), true);
        cboPeakPeriodStartMonth.DataBindings.Add("SelectedValue", _bindingSource, nameof(Property.PeakPeriodStartMonth), true,
            DataSourceUpdateMode.OnPropertyChanged);
        txtPeakPeriodStartDay.DataBindings.Add("Text", _bindingSource, nameof(Property.PeakPeriodStartDay), true);
        cboPeakPeriodEndMonth.DataBindings.Add("SelectedValue", _bindingSource, nameof(Property.PeakPeriodEndMonth), true,
            DataSourceUpdateMode.OnPropertyChanged);
        txtPeakPeriodEndDay.DataBindings.Add("Text", _bindingSource, nameof(Property.PeakPeriodEndDay), true);

        // Navigation grid
        dgvProperties.DataSource = _bindingSource;

        // Configure grid columns after data binding
        ConfigureGrid();
    }

    private void ConfigureGrid()
    {
        if (dgvProperties.Columns.Count == 0) return;

        // Hide navigation properties and internal columns
        var columnsToHide = new[] { "RoomTypes", "Blackouts", "EntryDate", "EntryUser", "UpdateDate", "UpdateUser" };
        foreach (var colName in columnsToHide)
        {
            if (dgvProperties.Columns.Contains(colName))
                dgvProperties.Columns[colName].Visible = false;
        }

        // Configure visible columns with proper headers and auto-size to header
        foreach (DataGridViewColumn col in dgvProperties.Columns)
        {
            if (!col.Visible) continue;

            col.HeaderText = col.Name switch
            {
                "AccountNumber" => "Account #",
                "Location" => "Location",
                "FullName" => "Full Name",
                "CheckTo" => "Check To",
                "PercentToHost" => "% to Host",
                "GrossRatePercent" => "Gross Rate %",
                "PropertyAddress" => "Property Address",
                "PropertyCity" => "Property City",
                "PropertyState" => "State",
                "PropertyZipCode" => "Zip Code",
                "PropertyPhone" => "Phone",
                "PropertyFax" => "Fax",
                "MailingAddress" => "Mailing Address",
                "MailingCity" => "Mailing City",
                "MailingState" => "Mailing State",
                "MailingZipCode" => "Mailing Zip",
                "MailingPhone1" => "Phone 1",
                "MailingPhone2" => "Phone 2",
                "MailingFax" => "Mailing Fax",
                "Email" => "Email",
                "WebUrl" => "Website",
                "FederalTaxId" => "Federal Tax ID",
                "DBA" => "DBA",
                "TaxPlanCode" => "Tax Plan",
                "FuturePercent" => "Future %",
                "FuturePercentDate" => "Future % Date",
                "SuppressFlag" => "Suppress",
                "IsObsolete" => "Obsolete",
                "DepositRequired" => "Deposit Req'd",
                "Exceptions" => "Exceptions",
                "ExceptionsDescription" => "Exceptions Desc",
                "Comments" => "Comments",
                "DefaultDepositPercent" => "Deposit %",
                "DefaultDepositDueDays" => "Deposit Due Days",
                "DefaultPrepaymentDueDays" => "Prepay Due Days",
                "DefaultCancellationNoticeDays" => "Cancel Notice Days",
                "DefaultCancellationFeePercent" => "Cancel Fee %",
                "CancellationProcessingFee" => "Processing Fee",
                "HasPeakPeriodPolicy" => "Has Peak Policy",
                "PeakPeriodPrepaymentDueDays" => "Peak Prepay Days",
                "PeakPeriodCancellationNoticeDays" => "Peak Cancel Days",
                "PeakPeriodCancellationFeePercent" => "Peak Cancel Fee %",
                "PeakPeriodStartMonth" => "Peak Start Month",
                "PeakPeriodStartDay" => "Peak Start Day",
                "PeakPeriodEndMonth" => "Peak End Month",
                "PeakPeriodEndDay" => "Peak End Day",
                _ => col.HeaderText
            };

            // Comments fills remaining space, others size to header
            if (col.Name == "Comments")
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
        }
    }

    private void LoadTaxPlans()
    {
        try
        {
            var taxPlans = _dbContext.TaxPlans
                .OrderBy(t => t.PlanCode)
                .Select(t => new { t.PlanCode, t.PlanTitle })
                .ToList();

            cboTaxPlan.DataSource = taxPlans;
            cboTaxPlan.DisplayMember = "PlanTitle";
            cboTaxPlan.ValueMember = "PlanCode";
        }
        catch (Exception ex)
        {
            // Tax plans table may not exist yet
            System.Diagnostics.Debug.WriteLine($"Error loading tax plans: {ex.Message}");
        }
    }

    private void LoadProperties()
    {
        try
        {
            var properties = _dbContext.Properties
                .OrderBy(p => p.Location)
                .ToList();

            _bindingSource.DataSource = properties;

            if (properties.Count == 0)
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
            MessageBox.Show($"Error loading properties: {ex.Message}", "Error",
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
                btnFind.Enabled = true;
                btnCommit.Enabled = false;
                btnCancel.Enabled = false;
                btnRefresh.Enabled = true;
                btnRoomTypes.Enabled = _bindingSource.Count > 0;
                dgvProperties.Enabled = true;
                break;

            case FormMode.Insert:
            case FormMode.Update:
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnCommit.Enabled = true;
                btnCancel.Enabled = true;
                btnRefresh.Enabled = false;
                btnRoomTypes.Enabled = false;
                dgvProperties.Enabled = false;
                break;

            case FormMode.Delete:
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnCommit.Enabled = true;
                btnCancel.Enabled = true;
                btnRefresh.Enabled = false;
                btnRoomTypes.Enabled = false;
                dgvProperties.Enabled = false;
                break;

            case FormMode.NoRows:
                btnInsert.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = true;
                btnCommit.Enabled = false;
                btnCancel.Enabled = false;
                btnRefresh.Enabled = true;
                btnRoomTypes.Enabled = false;
                dgvProperties.Enabled = true;
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

        // Generate next account number
        var maxAccountNum = _dbContext.Properties.Any()
            ? _dbContext.Properties.Max(p => p.AccountNumber)
            : 0;

        _currentProperty = new Property
        {
            AccountNumber = maxAccountNum + 1,
            Location = "",
            PercentToHost = 70  // Default percentage
        };

        _bindingSource.Add(_currentProperty);
        _bindingSource.Position = _bindingSource.Count - 1;

        txtLocation.Focus();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Property property)
        {
            _currentProperty = property;
            SetMode(FormMode.Update);
            txtLocation.Focus();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Property property)
        {
            // Check if property has accommodations
            var hasAccommodations = _dbContext.Accommodations
                .Any(a => a.PropertyAccountNumber == property.AccountNumber);

            if (hasAccommodations)
            {
                MessageBox.Show(
                    "Cannot delete this property because it has associated accommodations.\n" +
                    "Mark it as 'Property no longer booked' instead.",
                    "Cannot Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _currentProperty = property;
            SetMode(FormMode.Delete);

            var result = MessageBox.Show(
                $"Are you sure you want to delete property '{property.Location}' (Account# {property.AccountNumber})?",
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
                    if (_currentProperty != null)
                    {
                        _dbContext.Properties.Add(_currentProperty);
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Property added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case FormMode.Update:
                    _bindingSource.EndEdit();
                    _dbContext.SaveChanges();
                    MessageBox.Show("Property updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            LoadProperties();
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
            if (_currentProperty != null)
            {
                _dbContext.Properties.Remove(_currentProperty);
                _dbContext.SaveChanges();
                MessageBox.Show("Property deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadProperties();
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

        if (_currentMode == FormMode.Insert && _currentProperty != null)
        {
            _bindingSource.Remove(_currentProperty);
        }

        _currentProperty = null;
        LoadProperties();
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        using var searchForm = new PropertySearchForm();
        if (searchForm.ShowDialog(this) == DialogResult.OK && searchForm.SearchCriteria != null)
        {
            var criteria = searchForm.SearchCriteria;
            var query = _dbContext.Properties.AsQueryable();

            if (criteria.PropertyId.HasValue)
                query = query.Where(p => p.AccountNumber == criteria.PropertyId);

            if (!string.IsNullOrEmpty(criteria.PropertyName))
                query = query.Where(p => p.Location.Contains(criteria.PropertyName));

            if (!string.IsNullOrEmpty(criteria.OwnerName))
                query = query.Where(p => p.FullName != null && p.FullName.Contains(criteria.OwnerName));

            if (!criteria.IncludeObsolete)
                query = query.Where(p => !p.IsObsolete);

            var results = query.OrderBy(p => p.Location).ToList();
            _bindingSource.DataSource = results;

            if (results.Count == 0)
            {
                MessageBox.Show("No properties found matching the criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProperties();
            }
            else
            {
                SetMode(FormMode.Browse);
            }
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadProperties();
    }

    private void btnRoomTypes_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Property property)
        {
            using var roomTypeForm = new RoomTypeForm(_dbContext, property.AccountNumber);
            roomTypeForm.ShowDialog(this);
        }
    }

    #endregion

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtLocation.Text))
        {
            MessageBox.Show("Property name is required.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtLocation.Focus();
            return false;
        }

        if (!decimal.TryParse(txtPercentToHost.Text, out var percent) || percent < 0 || percent > 100)
        {
            MessageBox.Show("Percent to host must be a number between 0 and 100.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPercentToHost.Focus();
            return false;
        }

        return true;
    }

    private void dgvProperties_SelectionChanged(object sender, EventArgs e)
    {
        if (_currentMode == FormMode.Browse)
        {
            UpdateRecordCount();
        }
    }

    private void PropertyForm_FormClosing(object sender, FormClosingEventArgs e)
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

/// <summary>
/// Search criteria for property lookup
/// </summary>
public class PropertySearchCriteria
{
    public int? PropertyId { get; set; }
    public string? PropertyName { get; set; }
    public string? OwnerName { get; set; }
    public bool IncludeObsolete { get; set; }
}
