using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Services;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Travel Agent Booking form - migrated from TAGENT.FRM
/// Manages travel agent bookings linked to guest reservations.
/// </summary>
public partial class TravelAgentBookingForm : Form
{
    private readonly BnBDbContext _dbContext;
    private readonly FormStateManager _stateManager;
    private readonly BindingSource _bindingSource;

    private FormMode _currentMode = FormMode.Browse;
    private TravelAgentBooking? _currentBooking;

    public TravelAgentBookingForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        _stateManager = new FormStateManager();
        _bindingSource = new BindingSource();

        InitializeComponent();
        LoadAgencies();
    }

    private void TravelAgentBookingForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        LoadBookings();
        SetupDataBindings();
        SetMode(FormMode.Browse);
    }

    private void SetupDataBindings()
    {
        txtConfirmationNumber.DataBindings.Add("Text", _bindingSource, nameof(TravelAgentBooking.ConfirmationNumber), true);
        txtCommissionAmount.DataBindings.Add("Text", _bindingSource, nameof(TravelAgentBooking.CommissionAmount), true, DataSourceUpdateMode.OnPropertyChanged, "");
        txtCommissionPaid.DataBindings.Add("Text", _bindingSource, nameof(TravelAgentBooking.CommissionPaid), true, DataSourceUpdateMode.OnPropertyChanged, "");
        txtCheckNumber.DataBindings.Add("Text", _bindingSource, nameof(TravelAgentBooking.CheckNumber), true);
        txtComments.DataBindings.Add("Text", _bindingSource, nameof(TravelAgentBooking.Comments), true);

        dgvBookings.DataSource = _bindingSource;
    }

    private void LoadAgencies()
    {
        try
        {
            var agencies = _dbContext.TravelAgencies
                .OrderBy(a => a.Name)
                .Select(a => new { a.Id, a.Name, a.AccountNumber })
                .ToList();

            cboAgency.DataSource = agencies;
            cboAgency.DisplayMember = "Name";
            cboAgency.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading agencies: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadBookings()
    {
        try
        {
            var bookings = _dbContext.Set<TravelAgentBooking>()
                .Include(b => b.Guest)
                .Include(b => b.TravelAgency)
                .OrderByDescending(b => b.Id)
                .ToList();

            _bindingSource.DataSource = bookings;

            if (bookings.Count == 0)
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
            MessageBox.Show($"Error loading bookings: {ex.Message}", "Error",
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
                dgvBookings.Enabled = true;
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
                dgvBookings.Enabled = false;
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
                dgvBookings.Enabled = false;
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
                dgvBookings.Enabled = true;
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
        if (_bindingSource.Current is TravelAgentBooking booking && booking.Guest != null)
        {
            txtGuestName.Text = $"{booking.Guest.FirstName} {booking.Guest.LastName}";

            if (booking.TravelAgency != null)
            {
                cboAgency.SelectedValue = booking.TravelAgencyId;
            }

            if (booking.CommissionPaidDate.HasValue)
            {
                dtpCommissionPaidDate.Value = booking.CommissionPaidDate.Value;
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

            if (criteria.ConfirmationNumber.HasValue)
                query = query.Where(g => g.ConfirmationNumber == criteria.ConfirmationNumber);
            else if (!string.IsNullOrEmpty(criteria.LastName))
                query = query.Where(g => g.LastName != null && g.LastName.Contains(criteria.LastName));

            var guest = query.FirstOrDefault();
            if (guest == null)
            {
                MessageBox.Show("No guest found matching the criteria.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check if booking already exists for this guest
            var existingBooking = _dbContext.Set<TravelAgentBooking>()
                .FirstOrDefault(b => b.ConfirmationNumber == guest.ConfirmationNumber);

            if (existingBooking != null)
            {
                MessageBox.Show("A travel agent booking already exists for this guest.", "Already Exists",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SetMode(FormMode.Insert);

            _currentBooking = new TravelAgentBooking
            {
                ConfirmationNumber = guest.ConfirmationNumber,
                Guest = guest
            };

            _bindingSource.Add(_currentBooking);
            _bindingSource.Position = _bindingSource.Count - 1;

            txtGuestName.Text = $"{guest.FirstName} {guest.LastName}";
            cboAgency.Focus();
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is TravelAgentBooking booking)
        {
            _currentBooking = booking;
            SetMode(FormMode.Update);
            cboAgency.Focus();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is TravelAgentBooking booking)
        {
            _currentBooking = booking;
            SetMode(FormMode.Delete);

            var guestName = booking.Guest != null ? $"{booking.Guest.FirstName} {booking.Guest.LastName}" : "Unknown";
            var result = MessageBox.Show(
                $"Are you sure you want to delete the travel agent booking for '{guestName}'?",
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
                    if (_currentBooking != null)
                    {
                        _currentBooking.TravelAgencyId = (int?)cboAgency.SelectedValue;

                        if (decimal.TryParse(txtCommissionAmount.Text, out var commAmt))
                            _currentBooking.CommissionAmount = commAmt;

                        if (chkCommissionPaid.Checked)
                        {
                            if (decimal.TryParse(txtCommissionPaid.Text, out var commPaid))
                                _currentBooking.CommissionPaid = commPaid;
                            _currentBooking.CommissionPaidDate = dtpCommissionPaidDate.Value;
                        }

                        _currentBooking.CheckNumber = txtCheckNumber.Text.Trim();
                        _currentBooking.Comments = txtComments.Text.Trim();

                        _dbContext.Set<TravelAgentBooking>().Add(_currentBooking);
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Travel agent booking added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case FormMode.Update:
                    _bindingSource.EndEdit();
                    if (_currentBooking != null)
                    {
                        _currentBooking.TravelAgencyId = (int?)cboAgency.SelectedValue;

                        if (decimal.TryParse(txtCommissionAmount.Text, out var commAmtUpd))
                            _currentBooking.CommissionAmount = commAmtUpd;

                        if (chkCommissionPaid.Checked)
                        {
                            if (decimal.TryParse(txtCommissionPaid.Text, out var commPaidUpd))
                                _currentBooking.CommissionPaid = commPaidUpd;
                            _currentBooking.CommissionPaidDate = dtpCommissionPaidDate.Value;
                        }
                        else
                        {
                            _currentBooking.CommissionPaid = null;
                            _currentBooking.CommissionPaidDate = null;
                        }

                        _currentBooking.CheckNumber = txtCheckNumber.Text.Trim();
                        _currentBooking.Comments = txtComments.Text.Trim();
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Travel agent booking updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            LoadBookings();
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
            if (_currentBooking != null)
            {
                _dbContext.Set<TravelAgentBooking>().Remove(_currentBooking);
                _dbContext.SaveChanges();
                MessageBox.Show("Travel agent booking deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadBookings();
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

        if (_currentMode == FormMode.Insert && _currentBooking != null)
        {
            _bindingSource.Remove(_currentBooking);
        }

        _currentBooking = null;
        LoadBookings();
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        using var guestSearch = new GuestSearchForm();
        if (guestSearch.ShowDialog(this) == DialogResult.OK && guestSearch.SearchCriteria != null)
        {
            var criteria = guestSearch.SearchCriteria;
            var query = _dbContext.Set<TravelAgentBooking>()
                .Include(b => b.Guest)
                .Include(b => b.TravelAgency)
                .AsQueryable();

            if (criteria.ConfirmationNumber.HasValue)
                query = query.Where(b => b.ConfirmationNumber == criteria.ConfirmationNumber);

            if (!string.IsNullOrEmpty(criteria.LastName))
                query = query.Where(b => b.Guest.LastName != null && b.Guest.LastName.Contains(criteria.LastName));

            var results = query.OrderByDescending(b => b.Id).ToList();
            _bindingSource.DataSource = results;

            if (results.Count == 0)
            {
                MessageBox.Show("No travel agent bookings found.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBookings();
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
        LoadBookings();
    }

    #endregion

    private bool ValidateInput()
    {
        if (cboAgency.SelectedValue == null)
        {
            MessageBox.Show("Please select a travel agency.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboAgency.Focus();
            return false;
        }

        return true;
    }

    private void dgvBookings_SelectionChanged(object sender, EventArgs e)
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

    private void TravelAgentBookingForm_FormClosing(object sender, FormClosingEventArgs e)
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
