using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Services;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Guest General Information form - migrated from GENGUEST.FRM
/// </summary>
public partial class GuestForm : Form
{
    private readonly BnBDbContext _dbContext;
    private readonly FormStateManager _stateManager;
    private readonly BindingSource _bindingSource;

    private FormMode _currentMode = FormMode.Browse;
    private Guest? _currentGuest;
    private int? _initialGuestId;

    public GuestForm(BnBDbContext dbContext, int? guestId = null)
    {
        _dbContext = dbContext;
        _stateManager = new FormStateManager();
        _bindingSource = new BindingSource();
        _initialGuestId = guestId;

        InitializeComponent();
    }

    private void GuestForm_Load(object sender, EventArgs e)
    {
        // Apply modern UI theme
        this.ApplyTheme();

        LoadGuests();
        SetupDataBindings();
        SetMode(FormMode.Browse);

        // Navigate to specific guest if ID was provided
        if (_initialGuestId.HasValue)
        {
            NavigateToGuest(_initialGuestId.Value);
        }
    }

    private void NavigateToGuest(int guestId)
    {
        for (int i = 0; i < _bindingSource.Count; i++)
        {
            if (_bindingSource[i] is Guest guest && guest.Id == guestId)
            {
                _bindingSource.Position = i;
                break;
            }
        }
    }

    private void SetupDataBindings()
    {
        // Bind controls to the binding source
        // Note: ConfirmationNumber field removed - Guest is identified by Id
        txtConfirmationNumber.DataBindings.Add("Text", _bindingSource, nameof(Guest.Id), true);
        txtFirstName.DataBindings.Add("Text", _bindingSource, nameof(Guest.FirstName), true);
        txtLastName.DataBindings.Add("Text", _bindingSource, nameof(Guest.LastName), true);
        txtAddress.DataBindings.Add("Text", _bindingSource, nameof(Guest.Address), true);
        txtCity.DataBindings.Add("Text", _bindingSource, nameof(Guest.City), true);
        txtState.DataBindings.Add("Text", _bindingSource, nameof(Guest.State), true);
        txtZipCode.DataBindings.Add("Text", _bindingSource, nameof(Guest.ZipCode), true);
        txtCountry.DataBindings.Add("Text", _bindingSource, nameof(Guest.Country), true);
        txtHomePhone.DataBindings.Add("Text", _bindingSource, nameof(Guest.HomePhone), true);
        txtBusinessPhone.DataBindings.Add("Text", _bindingSource, nameof(Guest.BusinessPhone), true);
        txtFax.DataBindings.Add("Text", _bindingSource, nameof(Guest.FaxNumber), true);
        txtEmail.DataBindings.Add("Text", _bindingSource, nameof(Guest.Email), true);
        txtReferral.DataBindings.Add("Text", _bindingSource, nameof(Guest.Referral), true);
        txtBookedBy.DataBindings.Add("Text", _bindingSource, nameof(Guest.BookedBy), true);
        txtTravelingWith.DataBindings.Add("Text", _bindingSource, nameof(Guest.TravelingWith), true);
        txtComments.DataBindings.Add("Text", _bindingSource, nameof(Guest.Comments), true);
        chkLabelFlag.DataBindings.Add("Checked", _bindingSource, nameof(Guest.LabelFlag), true);

        // Navigation grid
        dgvGuests.DataSource = _bindingSource;

        // Hide navigation property columns and audit columns that aren't needed in grid
        if (dgvGuests.Columns.Contains("Accommodations"))
            dgvGuests.Columns["Accommodations"].Visible = false;
        if (dgvGuests.Columns.Contains("Payments"))
            dgvGuests.Columns["Payments"].Visible = false;
        if (dgvGuests.Columns.Contains("EntryDate"))
            dgvGuests.Columns["EntryDate"].Visible = false;
        if (dgvGuests.Columns.Contains("EntryUser"))
            dgvGuests.Columns["EntryUser"].Visible = false;
        if (dgvGuests.Columns.Contains("UpdateDate"))
            dgvGuests.Columns["UpdateDate"].Visible = false;
        if (dgvGuests.Columns.Contains("UpdateUser"))
            dgvGuests.Columns["UpdateUser"].Visible = false;
        if (dgvGuests.Columns.Contains("RevisionDate"))
            dgvGuests.Columns["RevisionDate"].Visible = false;
        if (dgvGuests.Columns.Contains("Revision"))
            dgvGuests.Columns["Revision"].Visible = false;
        if (dgvGuests.Columns.Contains("BusinessAddress"))
            dgvGuests.Columns["BusinessAddress"].Visible = false;
        if (dgvGuests.Columns.Contains("Closure"))
            dgvGuests.Columns["Closure"].Visible = false;
        if (dgvGuests.Columns.Contains("ReservationFee"))
            dgvGuests.Columns["ReservationFee"].Visible = false;
        if (dgvGuests.Columns.Contains("DateBooked"))
            dgvGuests.Columns["DateBooked"].Visible = false;

        // Configure LabelFlag column - position before Comments and prevent auto-expand
        if (dgvGuests.Columns.Contains("LabelFlag") && dgvGuests.Columns.Contains("Comments"))
        {
            var labelFlagCol = dgvGuests.Columns["LabelFlag"];
            var commentsCol = dgvGuests.Columns["Comments"];

            labelFlagCol.HeaderText = "Mailing Label";
            labelFlagCol.Width = 80;
            labelFlagCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Position LabelFlag just before Comments
            labelFlagCol.DisplayIndex = commentsCol.DisplayIndex;
        }
        else if (dgvGuests.Columns.Contains("LabelFlag"))
        {
            dgvGuests.Columns["LabelFlag"].HeaderText = "Mailing Label";
            dgvGuests.Columns["LabelFlag"].Width = 80;
            dgvGuests.Columns["LabelFlag"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        }
    }

    private void LoadGuests()
    {
        try
        {
            var guests = _dbContext.Guests
                .OrderByDescending(g => g.Id)
                .ToList();

            _bindingSource.DataSource = guests;

            if (guests.Count == 0)
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
            MessageBox.Show($"Error loading guests: {ex.Message}", "Error",
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
                dgvGuests.Enabled = true;
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
                dgvGuests.Enabled = false;
                break;

            case FormMode.Delete:
                btnInsert.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnCommit.Enabled = true;
                btnCancel.Enabled = true;
                btnRefresh.Enabled = false;
                dgvGuests.Enabled = false;
                break;

            case FormMode.NoRows:
                btnInsert.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = true;
                btnCommit.Enabled = false;
                btnCancel.Enabled = false;
                btnRefresh.Enabled = true;
                dgvGuests.Enabled = true;
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

        // Create new guest - Id will be auto-generated by the database
        _currentGuest = new Guest
        {
            FirstName = "",
            LastName = "",
            DateBooked = DateTime.Today,
            EntryDate = DateTime.Now,
            EntryUser = Environment.UserName
        };

        _bindingSource.Add(_currentGuest);
        _bindingSource.Position = _bindingSource.Count - 1;

        txtFirstName.Focus();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Guest guest)
        {
            _currentGuest = guest;
            guest.UpdateDate = DateTime.Now;
            guest.UpdateUser = Environment.UserName;
            SetMode(FormMode.Update);
            txtFirstName.Focus();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Guest guest)
        {
            _currentGuest = guest;
            SetMode(FormMode.Delete);

            var result = MessageBox.Show(
                $"Are you sure you want to delete guest '{guest.FirstName} {guest.LastName}' (ID# {guest.Id})?",
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
                    if (_currentGuest != null)
                    {
                        _dbContext.Guests.Add(_currentGuest);
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Guest added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case FormMode.Update:
                    _bindingSource.EndEdit();
                    _dbContext.SaveChanges();
                    MessageBox.Show("Guest updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            LoadGuests();
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
            if (_currentGuest != null)
            {
                _dbContext.Guests.Remove(_currentGuest);
                _dbContext.SaveChanges();
                MessageBox.Show("Guest deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadGuests();
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

        if (_currentMode == FormMode.Insert && _currentGuest != null)
        {
            _bindingSource.Remove(_currentGuest);
        }

        _currentGuest = null;
        LoadGuests();
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        using var searchForm = new GuestSearchForm();
        if (searchForm.ShowDialog(this) == DialogResult.OK && searchForm.SearchCriteria != null)
        {
            var criteria = searchForm.SearchCriteria;
            var query = _dbContext.Guests.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.LastName))
                query = query.Where(g => g.LastName.Contains(criteria.LastName));

            if (!string.IsNullOrEmpty(criteria.FirstName))
                query = query.Where(g => g.FirstName.Contains(criteria.FirstName));

            if (criteria.GuestId.HasValue)
                query = query.Where(g => g.Id == criteria.GuestId);

            var results = query.OrderByDescending(g => g.Id).ToList();
            _bindingSource.DataSource = results;

            if (results.Count == 0)
            {
                MessageBox.Show("No guests found matching the criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGuests();
            }
            else
            {
                SetMode(FormMode.Browse);
            }
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadGuests();
    }

    private void btnGoTo_Click(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            _goToMenu.Show(btn, new Point(0, btn.Height));
        }
    }

    private void menuAccommodations_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Guest guest)
        {
            using var form = AccommodationForm.CreateForGuest(_dbContext, guest.Id);
            form.ShowDialog(this);
        }
    }

    private void menuPayments_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Guest guest)
        {
            using var form = PaymentForm.CreateForGuest(_dbContext, guest.Id);
            form.ShowDialog(this);
        }
    }

    #endregion

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            MessageBox.Show("First name is required.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtFirstName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            MessageBox.Show("Last name is required.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtLastName.Focus();
            return false;
        }

        return true;
    }

    private void dgvGuests_SelectionChanged(object sender, EventArgs e)
    {
        if (_currentMode == FormMode.Browse)
        {
            UpdateRecordCount();
        }
    }

    private void GuestForm_FormClosing(object sender, FormClosingEventArgs e)
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
/// Search criteria for guest lookup
/// </summary>
public class GuestSearchCriteria
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? GuestId { get; set; }
}
