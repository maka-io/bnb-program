using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Services;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Guest Accommodations form - migrated from ACCOM.FRM
/// Manages accommodation/reservation records for guests.
/// </summary>
public partial class AccommodationForm : Form
{
    private readonly BnBDbContext _dbContext;
    private readonly FormStateManager _stateManager;
    private readonly BindingSource _bindingSource;
    private readonly BindingSource _propertyBindingSource;

    private FormMode _currentMode = FormMode.Browse;
    private Accommodation? _currentAccommodation;
    private long? _filterConfirmationNumber;

    public AccommodationForm(BnBDbContext dbContext, long? confirmationNumber = null)
    {
        _dbContext = dbContext;
        _stateManager = new FormStateManager();
        _bindingSource = new BindingSource();
        _propertyBindingSource = new BindingSource();
        _filterConfirmationNumber = confirmationNumber;

        InitializeComponent();
        SetupDataBindings();
    }

    private void AccommodationForm_Load(object sender, EventArgs e)
    {
        LoadProperties();
        LoadAccommodations();
        SetMode(FormMode.Browse);
    }

    private void SetupDataBindings()
    {
        // Main data bindings
        txtConfirmationNumber.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.ConfirmationNumber), true);
        txtGuestName.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.LastName), true);
        txtLocation.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.Location), true);

        // Date bindings
        dtpArrivalDate.DataBindings.Add("Value", _bindingSource, nameof(Accommodation.ArrivalDate), true);
        dtpDepartureDate.DataBindings.Add("Value", _bindingSource, nameof(Accommodation.DepartureDate), true);
        txtNumberOfNights.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.NumberOfNights), true);
        txtNumberInParty.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.NumberInParty), true);

        // Room info
        txtUnitName.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.UnitName), true);
        txtUnitNameDescription.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.UnitNameDescription), true);

        // Rates and amounts
        txtDailyGrossRate.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.DailyGrossRate), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtDailyNetRate.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.DailyNetRate), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtTotalGrossWithTax.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.TotalGrossWithTax), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtTotalNetWithTax.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.TotalNetWithTax), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtTotalTax.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.TotalTax), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtTax1.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.Tax1), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtTax2.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.Tax2), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtTax3.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.Tax3), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtServiceFee.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.ServiceFee), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");

        // Commission
        txtCommissionDue.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.Commission), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtCommissionPaid.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.CommissionPaid), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtCommissionReceived.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.CommissionReceived), true);

        // Options
        chkUseManualAmounts.DataBindings.Add("Checked", _bindingSource, nameof(Accommodation.UseManualAmounts), true);
        chkSuppress.DataBindings.Add("Checked", _bindingSource, nameof(Accommodation.Suppress), true);
        chkForfeit.DataBindings.Add("Checked", _bindingSource, nameof(Accommodation.Forfeit), true);
        chkNotified.DataBindings.Add("Checked", _bindingSource, nameof(Accommodation.Notified), true);
        txtOverridePercent.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.OverridePercentToHost), true);
        txtOverrideTaxPlan.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.OverrideTaxPlanCode), true);

        // Comments
        txtComments.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.Comments), true);
        txtNightNotes.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.NightNotes), true);

        // Navigation grid
        dgvAccommodations.DataSource = _bindingSource;
    }

    private void LoadProperties()
    {
        try
        {
            var properties = _dbContext.Properties
                .OrderBy(p => p.Location)
                .Select(p => new { p.AccountNumber, p.Location })
                .ToList();

            _propertyBindingSource.DataSource = properties;
            cboProperty.DataSource = _propertyBindingSource;
            cboProperty.DisplayMember = "Location";
            cboProperty.ValueMember = "AccountNumber";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading properties: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadAccommodations()
    {
        try
        {
            var query = _dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .AsQueryable();

            if (_filterConfirmationNumber.HasValue)
            {
                query = query.Where(a => a.ConfirmationNumber == _filterConfirmationNumber.Value);
            }

            var accommodations = query
                .OrderByDescending(a => a.ArrivalDate)
                .ToList();

            _bindingSource.DataSource = accommodations;

            if (accommodations.Count == 0)
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
            MessageBox.Show($"Error loading accommodations: {ex.Message}", "Error",
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
                btnGoToGuest.Enabled = _bindingSource.Count > 0;
                dgvAccommodations.Enabled = true;
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
                btnGoToGuest.Enabled = false;
                dgvAccommodations.Enabled = false;
                break;

            case FormMode.Delete:
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnCommit.Enabled = true;
                btnCancel.Enabled = true;
                btnRefresh.Enabled = false;
                btnGoToGuest.Enabled = false;
                dgvAccommodations.Enabled = false;
                break;

            case FormMode.NoRows:
                btnInsert.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = true;
                btnCommit.Enabled = false;
                btnCancel.Enabled = false;
                btnRefresh.Enabled = true;
                btnGoToGuest.Enabled = false;
                dgvAccommodations.Enabled = true;
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

        _currentAccommodation = new Accommodation
        {
            ArrivalDate = DateTime.Today,
            DepartureDate = DateTime.Today.AddDays(1),
            NumberOfNights = 1,
            PaymentType = "Prepay",
            EntryDate = DateTime.Now,
            EntryUser = Environment.UserName
        };

        _bindingSource.Add(_currentAccommodation);
        _bindingSource.Position = _bindingSource.Count - 1;

        cboProperty.Focus();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Accommodation accommodation)
        {
            _currentAccommodation = accommodation;
            accommodation.UpdateDate = DateTime.Now;
            accommodation.UpdateUser = Environment.UserName;
            SetMode(FormMode.Update);
            dtpArrivalDate.Focus();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Accommodation accommodation)
        {
            _currentAccommodation = accommodation;
            SetMode(FormMode.Delete);

            var result = MessageBox.Show(
                $"Are you sure you want to delete the accommodation for Conf# {accommodation.ConfirmationNumber} at '{accommodation.Location}'?",
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
                    if (_currentAccommodation != null)
                    {
                        // Set property info
                        if (cboProperty.SelectedValue is int accountNum)
                        {
                            _currentAccommodation.PropertyAccountNumber = accountNum;
                            var property = _dbContext.Properties.Find(accountNum);
                            if (property != null)
                            {
                                _currentAccommodation.Location = property.Location;
                            }
                        }

                        _dbContext.Accommodations.Add(_currentAccommodation);
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Accommodation added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case FormMode.Update:
                    _bindingSource.EndEdit();
                    _dbContext.SaveChanges();
                    MessageBox.Show("Accommodation updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            LoadAccommodations();
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
            if (_currentAccommodation != null)
            {
                _dbContext.Accommodations.Remove(_currentAccommodation);
                _dbContext.SaveChanges();
                MessageBox.Show("Accommodation deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadAccommodations();
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

        if (_currentMode == FormMode.Insert && _currentAccommodation != null)
        {
            _bindingSource.Remove(_currentAccommodation);
        }

        _currentAccommodation = null;
        LoadAccommodations();
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        using var searchForm = new AccommodationSearchForm();
        if (searchForm.ShowDialog(this) == DialogResult.OK && searchForm.SearchCriteria != null)
        {
            var criteria = searchForm.SearchCriteria;
            var query = _dbContext.Accommodations.AsQueryable();

            if (criteria.ConfirmationNumber.HasValue)
                query = query.Where(a => a.ConfirmationNumber == criteria.ConfirmationNumber);

            if (!string.IsNullOrEmpty(criteria.GuestName))
                query = query.Where(a => (a.LastName != null && a.LastName.Contains(criteria.GuestName)) ||
                                         (a.FirstName != null && a.FirstName.Contains(criteria.GuestName)));

            if (!string.IsNullOrEmpty(criteria.Location))
                query = query.Where(a => a.Location != null && a.Location.Contains(criteria.Location));

            if (criteria.ArrivalDateFrom.HasValue)
                query = query.Where(a => a.ArrivalDate >= criteria.ArrivalDateFrom);

            if (criteria.ArrivalDateTo.HasValue)
                query = query.Where(a => a.ArrivalDate <= criteria.ArrivalDateTo);

            var results = query.OrderByDescending(a => a.ArrivalDate).ToList();
            _bindingSource.DataSource = results;

            if (results.Count == 0)
            {
                MessageBox.Show("No accommodations found matching the criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccommodations();
            }
            else
            {
                SetMode(FormMode.Browse);
            }
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        _filterConfirmationNumber = null;
        LoadAccommodations();
    }

    private void btnGoToGuest_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Accommodation accommodation)
        {
            // Navigate to guest form (would need to be implemented via parent form)
            MessageBox.Show($"Navigate to Guest Conf# {accommodation.ConfirmationNumber}",
                "Go To Guest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
        CalculateAmounts();
    }

    #endregion

    private void CalculateAmounts()
    {
        if (_bindingSource.Current is not Accommodation accommodation)
            return;

        // Calculate number of nights
        if (accommodation.DepartureDate > accommodation.ArrivalDate)
        {
            accommodation.NumberOfNights = (int)(accommodation.DepartureDate - accommodation.ArrivalDate).TotalDays;
        }

        // Calculate totals (simplified - would need tax rates from database)
        accommodation.TotalGrossWithTax = accommodation.DailyGrossRate * accommodation.NumberOfNights;
        accommodation.TotalNetWithTax = accommodation.DailyNetRate * accommodation.NumberOfNights;

        // Refresh bindings
        _bindingSource.ResetCurrentItem();
    }

    private bool ValidateInput()
    {
        if (cboProperty.SelectedIndex < 0)
        {
            MessageBox.Show("Please select a property.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboProperty.Focus();
            return false;
        }

        if (dtpDepartureDate.Value <= dtpArrivalDate.Value)
        {
            MessageBox.Show("Departure date must be after arrival date.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpDepartureDate.Focus();
            return false;
        }

        return true;
    }

    private void dtpArrivalDate_ValueChanged(object sender, EventArgs e)
    {
        if (_currentMode == FormMode.Insert || _currentMode == FormMode.Update)
        {
            CalculateAmounts();
        }
    }

    private void dtpDepartureDate_ValueChanged(object sender, EventArgs e)
    {
        if (_currentMode == FormMode.Insert || _currentMode == FormMode.Update)
        {
            CalculateAmounts();
        }
    }

    private void dgvAccommodations_SelectionChanged(object sender, EventArgs e)
    {
        if (_currentMode == FormMode.Browse)
        {
            UpdateRecordCount();
        }
    }

    private void AccommodationForm_FormClosing(object sender, FormClosingEventArgs e)
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
/// Search criteria for accommodation lookup
/// </summary>
public class AccommodationSearchCriteria
{
    public long? ConfirmationNumber { get; set; }
    public string? GuestName { get; set; }
    public string? Location { get; set; }
    public DateTime? ArrivalDateFrom { get; set; }
    public DateTime? ArrivalDateTo { get; set; }
}
