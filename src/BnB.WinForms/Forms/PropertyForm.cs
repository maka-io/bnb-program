using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Services;
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
        SetupDataBindings();
    }

    private void PropertyForm_Load(object sender, EventArgs e)
    {
        LoadTaxPlans();
        LoadProperties();
        SetMode(FormMode.Browse);
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

        // Navigation grid
        dgvProperties.DataSource = _bindingSource;
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

            if (criteria.AccountNumber.HasValue)
                query = query.Where(p => p.AccountNumber == criteria.AccountNumber);

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
            // TODO: Open Room Types form for this property
            MessageBox.Show($"Room Types for Property #{property.AccountNumber}: {property.Location}",
                "Room Types", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnCopyAddress_Click(object sender, EventArgs e)
    {
        // Copy property address to mailing address
        if (_bindingSource.Current is Property property)
        {
            property.MailingAddress = property.PropertyAddress;
            property.MailingCity = property.PropertyCity;
            property.MailingState = property.PropertyState;
            property.MailingZipCode = property.PropertyZipCode;
            property.MailingPhone1 = property.PropertyPhone;
            property.MailingFax = property.PropertyFax;

            _bindingSource.ResetCurrentItem();
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
    public int? AccountNumber { get; set; }
    public string? PropertyName { get; set; }
    public string? OwnerName { get; set; }
    public bool IncludeObsolete { get; set; }
}
