using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Services;

namespace BnB.WinForms.Forms;

/// <summary>
/// Car Rental Agency Accounts form - migrated from CARACCT.FRM
/// Manages car rental agency master records.
/// </summary>
public partial class CarAgencyForm : Form
{
    private readonly BnBDbContext _dbContext;
    private readonly FormStateManager _stateManager;
    private readonly BindingSource _bindingSource;

    private FormMode _currentMode = FormMode.Browse;
    private CarAgency? _currentAgency;

    public CarAgencyForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        _stateManager = new FormStateManager();
        _bindingSource = new BindingSource();

        InitializeComponent();
        SetupDataBindings();
    }

    private void CarAgencyForm_Load(object sender, EventArgs e)
    {
        LoadAgencies();
        SetMode(FormMode.Browse);
    }

    private void SetupDataBindings()
    {
        txtName.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.Name), true);
        txtContactName.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.ContactName), true);
        txtAddress.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.Address), true);
        txtCity.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.City), true);
        txtState.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.State), true);
        txtZipCode.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.ZipCode), true);
        txtPhone.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.Phone), true);
        txtFax.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.Fax), true);
        txtEmail.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.Email), true);
        txtCommissionPercent.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.CommissionPercent), true);
        txtComments.DataBindings.Add("Text", _bindingSource, nameof(CarAgency.Comments), true);

        dgvAgencies.DataSource = _bindingSource;
    }

    private void LoadAgencies()
    {
        try
        {
            var agencies = _dbContext.CarAgencies
                .OrderBy(a => a.Name)
                .ToList();

            _bindingSource.DataSource = agencies;

            if (agencies.Count == 0)
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
            MessageBox.Show($"Error loading car agencies: {ex.Message}", "Error",
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
                dgvAgencies.Enabled = true;
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
                dgvAgencies.Enabled = false;
                break;

            case FormMode.Delete:
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnCommit.Enabled = true;
                btnCancel.Enabled = true;
                btnRefresh.Enabled = false;
                dgvAgencies.Enabled = false;
                break;

            case FormMode.NoRows:
                btnInsert.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = true;
                btnCommit.Enabled = false;
                btnCancel.Enabled = false;
                btnRefresh.Enabled = true;
                dgvAgencies.Enabled = true;
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

        _currentAgency = new CarAgency
        {
            Name = ""
        };

        _bindingSource.Add(_currentAgency);
        _bindingSource.Position = _bindingSource.Count - 1;

        txtName.Focus();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is CarAgency agency)
        {
            _currentAgency = agency;
            SetMode(FormMode.Update);
            txtName.Focus();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is CarAgency agency)
        {
            // Check for rentals
            var hasRentals = _dbContext.CarRentals
                .Any(r => r.CarAgencyId == agency.Id);

            if (hasRentals)
            {
                MessageBox.Show(
                    "Cannot delete this agency because it has associated car rentals.",
                    "Cannot Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _currentAgency = agency;
            SetMode(FormMode.Delete);

            var result = MessageBox.Show(
                $"Are you sure you want to delete car agency '{agency.Name}'?",
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
                    if (_currentAgency != null)
                    {
                        _dbContext.CarAgencies.Add(_currentAgency);
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Car agency added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case FormMode.Update:
                    _bindingSource.EndEdit();
                    _dbContext.SaveChanges();
                    MessageBox.Show("Car agency updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            LoadAgencies();
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
            if (_currentAgency != null)
            {
                _dbContext.CarAgencies.Remove(_currentAgency);
                _dbContext.SaveChanges();
                MessageBox.Show("Car agency deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadAgencies();
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

        if (_currentMode == FormMode.Insert && _currentAgency != null)
        {
            _bindingSource.Remove(_currentAgency);
        }

        _currentAgency = null;
        LoadAgencies();
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        using var searchForm = new CarAgencySearchForm();
        if (searchForm.ShowDialog(this) == DialogResult.OK && searchForm.SearchCriteria != null)
        {
            var criteria = searchForm.SearchCriteria;
            var query = _dbContext.CarAgencies.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Name))
                query = query.Where(a => a.Name.Contains(criteria.Name));

            if (!string.IsNullOrEmpty(criteria.City))
                query = query.Where(a => a.City != null && a.City.Contains(criteria.City));

            var results = query.OrderBy(a => a.Name).ToList();
            _bindingSource.DataSource = results;

            if (results.Count == 0)
            {
                MessageBox.Show("No car agencies found matching the criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAgencies();
            }
            else
            {
                SetMode(FormMode.Browse);
            }
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadAgencies();
    }

    #endregion

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Agency name is required.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return false;
        }

        return true;
    }

    private void dgvAgencies_SelectionChanged(object sender, EventArgs e)
    {
        if (_currentMode == FormMode.Browse)
        {
            UpdateRecordCount();
        }
    }

    private void CarAgencyForm_FormClosing(object sender, FormClosingEventArgs e)
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
/// Search criteria for car agency lookup
/// </summary>
public class CarAgencySearchCriteria
{
    public string? Name { get; set; }
    public string? City { get; set; }
}
