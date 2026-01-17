using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Services;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Car Rental Booking form - migrated from CARRES.FRM
/// Manages car rental reservations linked to guest reservations.
/// </summary>
public partial class CarRentalBookingForm : Form
{
    private readonly BnBDbContext _dbContext;
    private readonly FormStateManager _stateManager;
    private readonly BindingSource _bindingSource;

    private FormMode _currentMode = FormMode.Browse;
    private CarRental? _currentRental;

    public CarRentalBookingForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        _stateManager = new FormStateManager();
        _bindingSource = new BindingSource();

        InitializeComponent();
        LoadAgencies();
    }

    private void CarRentalBookingForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        LoadRentals();
        SetupDataBindings();
        SetMode(FormMode.Browse);
    }

    private void SetupDataBindings()
    {
        txtConfirmationNumber.DataBindings.Add("Text", _bindingSource, nameof(CarRental.ConfirmationNumber), true);
        txtCarType.DataBindings.Add("Text", _bindingSource, nameof(CarRental.CarType), true);
        txtDailyRate.DataBindings.Add("Text", _bindingSource, nameof(CarRental.DailyRate), true, DataSourceUpdateMode.OnPropertyChanged, "");
        txtTotalAmount.DataBindings.Add("Text", _bindingSource, nameof(CarRental.TotalAmount), true, DataSourceUpdateMode.OnPropertyChanged, "");
        txtCommissionAmount.DataBindings.Add("Text", _bindingSource, nameof(CarRental.CommissionAmount), true, DataSourceUpdateMode.OnPropertyChanged, "");
        txtCommissionPaid.DataBindings.Add("Text", _bindingSource, nameof(CarRental.CommissionPaid), true, DataSourceUpdateMode.OnPropertyChanged, "");
        txtCheckNumber.DataBindings.Add("Text", _bindingSource, nameof(CarRental.CheckNumber), true);
        txtComments.DataBindings.Add("Text", _bindingSource, nameof(CarRental.Comments), true);

        dgvRentals.DataSource = _bindingSource;
    }

    private void LoadAgencies()
    {
        try
        {
            var agencies = _dbContext.CarAgencies
                .OrderBy(a => a.Name)
                .Select(a => new { a.Id, a.Name })
                .ToList();

            cboAgency.DataSource = agencies;
            cboAgency.DisplayMember = "Name";
            cboAgency.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading car agencies: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadRentals()
    {
        try
        {
            var rentals = _dbContext.CarRentals
                .Include(r => r.Guest)
                .Include(r => r.CarAgency)
                .OrderByDescending(r => r.Id)
                .ToList();

            _bindingSource.DataSource = rentals;

            if (rentals.Count == 0)
            {
                SetMode(FormMode.NoRows);
            }
            else
            {
                SetMode(FormMode.Browse);
            }

            UpdateRecordCount();
            UpdateGuestInfo();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading car rentals: {ex.Message}", "Error",
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
                dgvRentals.Enabled = true;
                cboAgency.Enabled = false;
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
                dgvRentals.Enabled = false;
                cboAgency.Enabled = true;
                break;

            case FormMode.Delete:
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnCommit.Enabled = true;
                btnCancel.Enabled = true;
                btnRefresh.Enabled = false;
                dgvRentals.Enabled = false;
                cboAgency.Enabled = false;
                break;

            case FormMode.NoRows:
                btnInsert.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = true;
                btnCommit.Enabled = false;
                btnCancel.Enabled = false;
                btnRefresh.Enabled = true;
                dgvRentals.Enabled = true;
                cboAgency.Enabled = false;
                break;
        }
    }

    private void UpdateRecordCount()
    {
        lblRecordCount.Text = $"Record {_bindingSource.Position + 1} of {_bindingSource.Count}";
    }

    private void UpdateGuestInfo()
    {
        if (_bindingSource.Current is CarRental rental && rental.Guest != null)
        {
            txtGuestName.Text = $"{rental.Guest.FirstName} {rental.Guest.LastName}";

            if (rental.CarAgency != null)
            {
                cboAgency.SelectedValue = rental.CarAgencyId;
            }

            if (rental.PickupDate.HasValue)
                dtpPickupDate.Value = rental.PickupDate.Value;
            else
                dtpPickupDate.Value = DateTime.Today;

            if (rental.ReturnDate.HasValue)
                dtpReturnDate.Value = rental.ReturnDate.Value;
            else
                dtpReturnDate.Value = DateTime.Today.AddDays(7);

            if (rental.CommissionPaidDate.HasValue)
            {
                dtpCommissionPaidDate.Value = rental.CommissionPaidDate.Value;
                chkCommissionPaid.Checked = true;
            }
            else
            {
                dtpCommissionPaidDate.Value = DateTime.Today;
                chkCommissionPaid.Checked = false;
            }
        }
        else
        {
            txtGuestName.Text = "";
            chkCommissionPaid.Checked = false;
            dtpPickupDate.Value = DateTime.Today;
            dtpReturnDate.Value = DateTime.Today.AddDays(7);
        }
    }

    #region Button Event Handlers

    private void btnInsert_Click(object sender, EventArgs e)
    {
        // Need to select a guest first
        using var guestSearch = new GuestSearchForm();
        if (guestSearch.ShowDialog(this) == DialogResult.OK && guestSearch.SearchCriteria != null)
        {
            var criteria = guestSearch.SearchCriteria;
            var query = _dbContext.Guests.AsQueryable();

            if (criteria.GuestId.HasValue)
                query = query.Where(g => g.Id == criteria.GuestId);
            else if (!string.IsNullOrEmpty(criteria.LastName))
                query = query.Where(g => g.LastName != null && g.LastName.Contains(criteria.LastName));

            var guest = query.FirstOrDefault();
            if (guest == null)
            {
                MessageBox.Show("No guest found matching the criteria.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SetMode(FormMode.Insert);

            // Get first accommodation for this guest to use its confirmation number
            var firstAccom = _dbContext.Accommodations.FirstOrDefault(a => a.GuestId == guest.Id);

            _currentRental = new CarRental
            {
                GuestId = guest.Id,
                ConfirmationNumber = firstAccom?.ConfirmationNumber ?? 0,
                Guest = guest,
                PickupDate = DateTime.Today,
                ReturnDate = DateTime.Today.AddDays(7)
            };

            _bindingSource.Add(_currentRental);
            _bindingSource.Position = _bindingSource.Count - 1;

            txtGuestName.Text = $"{guest.FirstName} {guest.LastName}";
            cboAgency.Focus();
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is CarRental rental)
        {
            _currentRental = rental;
            SetMode(FormMode.Update);
            cboAgency.Focus();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is CarRental rental)
        {
            _currentRental = rental;
            SetMode(FormMode.Delete);

            var guestName = rental.Guest != null ? $"{rental.Guest.FirstName} {rental.Guest.LastName}" : "Unknown";
            var result = MessageBox.Show(
                $"Are you sure you want to delete the car rental for '{guestName}'?",
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
                    if (_currentRental != null)
                    {
                        _currentRental.CarAgencyId = (int?)cboAgency.SelectedValue;
                        _currentRental.PickupDate = dtpPickupDate.Value;
                        _currentRental.ReturnDate = dtpReturnDate.Value;
                        _currentRental.CarType = txtCarType.Text.Trim();

                        if (decimal.TryParse(txtDailyRate.Text, out var dailyRate))
                            _currentRental.DailyRate = dailyRate;

                        if (decimal.TryParse(txtTotalAmount.Text, out var totalAmt))
                            _currentRental.TotalAmount = totalAmt;

                        if (decimal.TryParse(txtCommissionAmount.Text, out var commAmt))
                            _currentRental.CommissionAmount = commAmt;

                        if (chkCommissionPaid.Checked)
                        {
                            if (decimal.TryParse(txtCommissionPaid.Text, out var commPaid))
                                _currentRental.CommissionPaid = commPaid;
                            _currentRental.CommissionPaidDate = dtpCommissionPaidDate.Value;
                        }

                        _currentRental.CheckNumber = txtCheckNumber.Text.Trim();
                        _currentRental.Comments = txtComments.Text.Trim();

                        _dbContext.CarRentals.Add(_currentRental);
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Car rental added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case FormMode.Update:
                    _bindingSource.EndEdit();
                    if (_currentRental != null)
                    {
                        _currentRental.CarAgencyId = (int?)cboAgency.SelectedValue;
                        _currentRental.PickupDate = dtpPickupDate.Value;
                        _currentRental.ReturnDate = dtpReturnDate.Value;
                        _currentRental.CarType = txtCarType.Text.Trim();

                        if (decimal.TryParse(txtDailyRate.Text, out var dailyRateUpd))
                            _currentRental.DailyRate = dailyRateUpd;

                        if (decimal.TryParse(txtTotalAmount.Text, out var totalAmtUpd))
                            _currentRental.TotalAmount = totalAmtUpd;

                        if (decimal.TryParse(txtCommissionAmount.Text, out var commAmtUpd))
                            _currentRental.CommissionAmount = commAmtUpd;

                        if (chkCommissionPaid.Checked)
                        {
                            if (decimal.TryParse(txtCommissionPaid.Text, out var commPaidUpd))
                                _currentRental.CommissionPaid = commPaidUpd;
                            _currentRental.CommissionPaidDate = dtpCommissionPaidDate.Value;
                        }
                        else
                        {
                            _currentRental.CommissionPaid = null;
                            _currentRental.CommissionPaidDate = null;
                        }

                        _currentRental.CheckNumber = txtCheckNumber.Text.Trim();
                        _currentRental.Comments = txtComments.Text.Trim();
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Car rental updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            LoadRentals();
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
            if (_currentRental != null)
            {
                _dbContext.CarRentals.Remove(_currentRental);
                _dbContext.SaveChanges();
                MessageBox.Show("Car rental deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadRentals();
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

        if (_currentMode == FormMode.Insert && _currentRental != null)
        {
            _bindingSource.Remove(_currentRental);
        }

        _currentRental = null;
        LoadRentals();
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        using var guestSearch = new GuestSearchForm();
        if (guestSearch.ShowDialog(this) == DialogResult.OK && guestSearch.SearchCriteria != null)
        {
            var criteria = guestSearch.SearchCriteria;
            var query = _dbContext.CarRentals
                .Include(r => r.Guest)
                .Include(r => r.CarAgency)
                .AsQueryable();

            if (criteria.GuestId.HasValue)
                query = query.Where(r => r.GuestId == criteria.GuestId);

            if (!string.IsNullOrEmpty(criteria.LastName))
                query = query.Where(r => r.Guest.LastName != null && r.Guest.LastName.Contains(criteria.LastName));

            var results = query.OrderByDescending(r => r.Id).ToList();
            _bindingSource.DataSource = results;

            if (results.Count == 0)
            {
                MessageBox.Show("No car rentals found.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRentals();
            }
            else
            {
                SetMode(FormMode.Browse);
                UpdateGuestInfo();
            }
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadRentals();
    }

    #endregion

    private bool ValidateInput()
    {
        if (cboAgency.SelectedValue == null)
        {
            MessageBox.Show("Please select a car rental agency.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboAgency.Focus();
            return false;
        }

        if (dtpReturnDate.Value < dtpPickupDate.Value)
        {
            MessageBox.Show("Return date must be on or after pickup date.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpReturnDate.Focus();
            return false;
        }

        return true;
    }

    private void dgvRentals_SelectionChanged(object sender, EventArgs e)
    {
        if (_currentMode == FormMode.Browse)
        {
            UpdateRecordCount();
            UpdateGuestInfo();
        }
    }

    private void chkCommissionPaid_CheckedChanged(object sender, EventArgs e)
    {
        dtpCommissionPaidDate.Enabled = chkCommissionPaid.Checked;
        txtCommissionPaid.Enabled = chkCommissionPaid.Checked;
    }

    private void CarRentalBookingForm_FormClosing(object sender, FormClosingEventArgs e)
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
