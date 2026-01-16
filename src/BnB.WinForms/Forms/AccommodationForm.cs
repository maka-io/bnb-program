using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Core.Services;
using BnB.Data.Context;
using BnB.WinForms.Services;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
    private ContextMenuStrip _goToMenu;
    private bool _isLoadingRoomTypes = false;
    private bool _isLoadingData = false;

    public AccommodationForm(BnBDbContext dbContext, long? confirmationNumber = null)
    {
        _dbContext = dbContext;
        _stateManager = new FormStateManager();
        _bindingSource = new BindingSource();
        _propertyBindingSource = new BindingSource();
        _filterConfirmationNumber = confirmationNumber;

        InitializeComponent();
        InitializeGoToMenu();
        SetupRoomTypeComboBox();
        SetupCalculationEvents();
    }

    private void SetupCalculationEvents()
    {
        // When gross rate changes, recalculate
        txtDailyGrossRate.Leave += (s, e) =>
        {
            if (_currentMode == FormMode.Insert || _currentMode == FormMode.Update)
            {
                // Parse the value and update the accommodation
                if (_currentAccommodation != null && decimal.TryParse(txtDailyGrossRate.Text, System.Globalization.NumberStyles.Currency, null, out var rate))
                {
                    _currentAccommodation.DailyGrossRate = rate;
                    CalculateAmounts();
                }
            }
        };

        // When number of nights changes, recalculate
        txtNights.Leave += (s, e) =>
        {
            if (_currentMode == FormMode.Insert || _currentMode == FormMode.Update)
            {
                if (_currentAccommodation != null && int.TryParse(txtNights.Text, out var nights))
                {
                    _currentAccommodation.NumberOfNights = nights;
                    CalculateAmounts();
                }
            }
        };
    }

    private void InitializeGoToMenu()
    {
        _goToMenu = new ContextMenuStrip();
        var mnuGuestInfo = new ToolStripMenuItem("Guest General Information");
        mnuGuestInfo.Click += (s, e) => GoToGuestInfo();
        var mnuPayments = new ToolStripMenuItem("Guest Payments");
        mnuPayments.Click += (s, e) => GoToPayments();
        _goToMenu.Items.AddRange(new ToolStripItem[] { mnuGuestInfo, mnuPayments });
    }

    private void SetupRoomTypeComboBox()
    {
        // Initialize with empty list
        cboRoomType.DisplayMember = "Description";
        cboRoomType.ValueMember = "Name";
        cboRoomType.DataSource = new List<RoomTypeItem>();
        cboRoomType.SelectedIndexChanged += cboRoomType_SelectedIndexChanged;

        // When property changes, reload room types
        cboProperty.SelectedIndexChanged += cboProperty_SelectedIndexChanged;

        // When current accommodation changes, sync room type selection
        _bindingSource.PositionChanged += (s, e) => SyncRoomTypeSelection();
    }

    private void cboProperty_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_currentMode == FormMode.Insert || _currentMode == FormMode.Update)
        {
            LoadRoomTypesForProperty();

            // Update current accommodation with the selected property
            if (_currentAccommodation != null && cboProperty.SelectedValue is int accountNum)
            {
                _currentAccommodation.PropertyAccountNumber = accountNum;
                var property = _dbContext.Properties.Find(accountNum);
                if (property != null)
                {
                    _currentAccommodation.Location = property.Location;
                }

                // Recalculate with the new property's tax plan
                CalculateAmounts();
            }
        }
    }

    private void LoadRoomTypesForProperty()
    {
        _isLoadingRoomTypes = true;
        try
        {
            int? accountNum = null;
            if (cboProperty.SelectedValue is int num)
                accountNum = num;

            if (accountNum == null)
            {
                cboRoomType.DataSource = new List<RoomTypeItem>();
                return;
            }

            var roomTypes = _dbContext.RoomTypes
                .Where(r => r.PropertyAccountNumber == accountNum.Value)
                .OrderBy(r => r.Name)
                .Select(r => new RoomTypeItem
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description ?? r.Name,
                    DefaultRate = r.DefaultRate
                })
                .ToList();

            // Add empty option at the beginning
            roomTypes.Insert(0, new RoomTypeItem { Id = 0, Name = "", Description = "(None)", DefaultRate = null });

            cboRoomType.DataSource = roomTypes;
        }
        finally
        {
            _isLoadingRoomTypes = false;
        }
    }

    private void cboRoomType_SelectedIndexChanged(object? sender, EventArgs e)
    {
        // When room type changes, apply the default rate and recalculate
        if (_isLoadingRoomTypes) return;
        if (_currentMode != FormMode.Insert && _currentMode != FormMode.Update) return;

        if (cboRoomType.SelectedItem is RoomTypeItem selectedRoom && _currentAccommodation != null)
        {
            // Always set room type info
            _currentAccommodation.UnitName = selectedRoom.Name;
            _currentAccommodation.UnitNameDescription = selectedRoom.Description;

            // Apply default rate if room type has one
            if (selectedRoom.DefaultRate.HasValue)
            {
                _currentAccommodation.DailyGrossRate = selectedRoom.DefaultRate.Value;
            }

            // Refresh bindings and recalculate
            _bindingSource.ResetCurrentItem();
            CalculateAmounts();
        }
    }

    private void SyncRoomTypeSelection()
    {
        if (_bindingSource.Current is not Accommodation accommodation) return;

        // Load room types for this accommodation's property
        var property = _dbContext.Properties.FirstOrDefault(p => p.AccountNumber == accommodation.PropertyAccountNumber);
        if (property != null)
        {
            // Set property selection without triggering reload
            _isLoadingRoomTypes = true;
            cboProperty.SelectedValue = accommodation.PropertyAccountNumber;
            _isLoadingRoomTypes = false;

            // Load room types
            LoadRoomTypesForProperty();

            // Select the matching room type
            if (!string.IsNullOrEmpty(accommodation.UnitName))
            {
                cboRoomType.SelectedValue = accommodation.UnitName;
            }
            else
            {
                cboRoomType.SelectedIndex = 0;
            }
        }
    }

    /// <summary>
    /// Helper class for room type ComboBox binding
    /// </summary>
    private class RoomTypeItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal? DefaultRate { get; set; }
    }

    private void AccommodationForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        LoadProperties();
        LoadAccommodations();
        SetupDataBindings();
        SetMode(FormMode.Browse);
    }

    private void SetupDataBindings()
    {
        // Main data bindings
        txtConfirmationNumber.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.ConfirmationNumber), true);
        txtGuestName.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.LastName), true);
        txtFirstName.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.FirstName), true);
        txtLocation.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.Location), true);

        // Date bindings
        dtpArrivalDate.DataBindings.Add("Value", _bindingSource, nameof(Accommodation.ArrivalDate), true);
        dtpDepartureDate.DataBindings.Add("Value", _bindingSource, nameof(Accommodation.DepartureDate), true);
        txtNights.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.NumberOfNights), true);
        txtNumberOfGuests.DataBindings.Add("Text", _bindingSource, nameof(Accommodation.NumberInParty), true);

        // Room info - UnitNameDescription is read-only (auto-populated from room type selection)
        // Note: cboRoomType is populated based on selected property and current accommodation

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
        ConfigureGrid();
    }

    private void ConfigureGrid()
    {
        dgvAccommodations.AutoGenerateColumns = false;
        dgvAccommodations.Columns.Clear();

        // Add only the columns we want to display
        dgvAccommodations.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ConfirmationNumber",
            HeaderText = "Conf #",
            Width = 70
        });

        dgvAccommodations.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "FirstName",
            HeaderText = "First Name",
            Width = 90
        });

        dgvAccommodations.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "LastName",
            HeaderText = "Last Name",
            Width = 100
        });

        dgvAccommodations.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Location",
            HeaderText = "Property",
            Width = 130
        });

        dgvAccommodations.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ArrivalDate",
            HeaderText = "Arrival",
            Width = 85,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "MM/dd/yyyy" }
        });

        dgvAccommodations.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "DepartureDate",
            HeaderText = "Departure",
            Width = 85,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "MM/dd/yyyy" }
        });

        dgvAccommodations.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "NumberOfNights",
            HeaderText = "Nights",
            Width = 55,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
        });

        dgvAccommodations.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "TotalGrossWithTax",
            HeaderText = "Total",
            Width = 80,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });
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
        _isLoadingData = true;
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
        finally
        {
            _isLoadingData = false;
        }
    }

    private void SetMode(FormMode mode)
    {
        _currentMode = mode;
        _stateManager.SetMode(this, mode);
        UpdateButtonStates();

        // Explicitly set date picker enabled state (FormStateManager may not reach them)
        bool editable = (mode == FormMode.Insert || mode == FormMode.Update);
        dtpArrivalDate.Enabled = editable;
        dtpDepartureDate.Enabled = editable;
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
                lblLookupGuest.Enabled = false;
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
                lblLookupGuest.Enabled = true;
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
                lblLookupGuest.Enabled = false;
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
                lblLookupGuest.Enabled = false;
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

        // Get next confirmation number
        long nextConfNum = 1;
        var maxConf = _dbContext.Accommodations.Max(a => (long?)a.ConfirmationNumber);
        if (maxConf.HasValue)
        {
            nextConfNum = maxConf.Value + 1;
        }
        else
        {
            // Also check guests table in case no accommodations exist yet
            var maxGuestConf = _dbContext.Guests.Max(g => (long?)g.ConfirmationNumber);
            if (maxGuestConf.HasValue)
            {
                nextConfNum = maxGuestConf.Value + 1;
            }
        }

        _currentAccommodation = new Accommodation
        {
            ConfirmationNumber = nextConfNum,
            ArrivalDate = DateTime.Today,
            DepartureDate = DateTime.Today.AddDays(1),
            NumberOfNights = 1,
            PaymentType = "Prepay",
            EntryDate = DateTime.Now,
            EntryUser = Environment.UserName
        };

        _bindingSource.Add(_currentAccommodation);
        _bindingSource.Position = _bindingSource.Count - 1;

        // Default to first property and load its room types
        if (cboProperty.Items.Count > 0)
        {
            cboProperty.SelectedIndex = 0;
            LoadRoomTypesForProperty();
        }

        // Enable guest lookup button and set focus
        lblLookupGuest.Enabled = true;
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

                        // Set room type info
                        if (cboRoomType.SelectedItem is RoomTypeItem selectedRoom && !string.IsNullOrEmpty(selectedRoom.Name))
                        {
                            _currentAccommodation.UnitName = selectedRoom.Name;
                            _currentAccommodation.UnitNameDescription = selectedRoom.Description;
                        }

                        _dbContext.Accommodations.Add(_currentAccommodation);
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Accommodation added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case FormMode.Update:
                    _bindingSource.EndEdit();
                    if (_currentAccommodation != null)
                    {
                        // Update room type info
                        if (cboRoomType.SelectedItem is RoomTypeItem selectedRoom && !string.IsNullOrEmpty(selectedRoom.Name))
                        {
                            _currentAccommodation.UnitName = selectedRoom.Name;
                            _currentAccommodation.UnitNameDescription = selectedRoom.Description;
                        }
                        else
                        {
                            _currentAccommodation.UnitName = null;
                            _currentAccommodation.UnitNameDescription = null;
                        }
                    }
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
        if (_bindingSource.Current is Accommodation && btnGoToGuest != null)
        {
            _goToMenu.Show(btnGoToGuest, new Point(0, btnGoToGuest.Height));
        }
    }

    private void GoToGuestInfo()
    {
        if (_bindingSource.Current is Accommodation accommodation)
        {
            var form = new GuestForm(_dbContext, accommodation.ConfirmationNumber);
            form.MdiParent = this.MdiParent;
            form.Show();
        }
    }

    private void GoToPayments()
    {
        if (_bindingSource.Current is Accommodation accommodation)
        {
            var form = new PaymentForm(_dbContext, accommodation.ConfirmationNumber);
            form.MdiParent = this.MdiParent;
            form.Show();
        }
    }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
        // Sync binding source with current control values before calculating
        _bindingSource.EndEdit();

        // If gross rate was manually entered, parse and update the accommodation
        if (_currentAccommodation != null && decimal.TryParse(txtDailyGrossRate.Text, System.Globalization.NumberStyles.Currency, null, out var rate))
        {
            _currentAccommodation.DailyGrossRate = rate;
        }

        CalculateAmounts();
    }

    private void lblLookupGuest_Click(object sender, EventArgs e)
    {
        if (_currentMode != FormMode.Insert && _currentMode != FormMode.Update)
            return;

        using var lookupForm = new GuestLookupForm(_dbContext);
        if (lookupForm.ShowDialog(this) == DialogResult.OK && lookupForm.SelectedGuest != null)
        {
            var guest = lookupForm.SelectedGuest;

            if (_currentAccommodation != null)
            {
                // Update the accommodation with the selected guest info
                // Note: Don't change ConfirmationNumber - it's auto-incremented for the accommodation
                _currentAccommodation.FirstName = guest.FirstName;
                _currentAccommodation.LastName = guest.LastName;

                // Refresh the bindings to show the updated values
                _bindingSource.ResetCurrentItem();
            }
        }
    }

    #endregion

    private void CalculateAmounts()
    {
        if (_bindingSource.Current is not Accommodation accommodation)
            return;

        // Calculate number of nights from dates
        if (accommodation.DepartureDate > accommodation.ArrivalDate)
        {
            accommodation.NumberOfNights = (int)(accommodation.DepartureDate - accommodation.ArrivalDate).TotalDays;
        }

        // Get property for tax plan and percent to host
        var property = _dbContext.Properties.FirstOrDefault(p => p.AccountNumber == accommodation.PropertyAccountNumber);
        if (property == null)
        {
            // Simple calculation without taxes if no property
            accommodation.TotalGrossWithTax = accommodation.DailyGrossRate * accommodation.NumberOfNights;
            accommodation.TotalNetWithTax = accommodation.DailyNetRate * accommodation.NumberOfNights;
            _bindingSource.ResetCurrentItem();
            return;
        }

        // Use override values if specified, otherwise use property defaults
        var taxPlanCode = !string.IsNullOrEmpty(accommodation.OverrideTaxPlanCode)
            ? accommodation.OverrideTaxPlanCode
            : property.TaxPlanCode ?? "258";  // Default to all taxes N/A
        var percentToHost = accommodation.OverridePercentToHost ?? property.PercentToHost;

        // Get tax plan by code to get the rates
        var taxPlan = _dbContext.TaxPlans.FirstOrDefault(tp => tp.PlanCode == taxPlanCode);

        // If exact tax plan not found, try to use any existing tax plan's rates with the requested code
        if (taxPlan == null)
        {
            var anyTaxPlan = _dbContext.TaxPlans.FirstOrDefault();
            if (anyTaxPlan != null)
            {
                // Create a temporary tax plan with the rates from existing plan but the requested code
                taxPlan = new TaxPlan
                {
                    PlanCode = taxPlanCode,
                    Tax1Rate = anyTaxPlan.Tax1Rate,
                    Tax1Description = anyTaxPlan.Tax1Description,
                    FutureTax1Rate = anyTaxPlan.FutureTax1Rate,
                    FutureTax1EffectiveDate = anyTaxPlan.FutureTax1EffectiveDate,
                    Tax2Rate = anyTaxPlan.Tax2Rate,
                    Tax2Description = anyTaxPlan.Tax2Description,
                    FutureTax2Rate = anyTaxPlan.FutureTax2Rate,
                    FutureTax2EffectiveDate = anyTaxPlan.FutureTax2EffectiveDate,
                    Tax3Rate = anyTaxPlan.Tax3Rate,
                    Tax3Description = anyTaxPlan.Tax3Description,
                    FutureTax3Rate = anyTaxPlan.FutureTax3Rate,
                    FutureTax3EffectiveDate = anyTaxPlan.FutureTax3EffectiveDate
                };
                // Parse the code to set application settings
                taxPlan.ParsePlanCode(taxPlanCode);
            }
        }

        if (taxPlan == null || accommodation.DailyGrossRate == null || accommodation.DailyGrossRate == 0)
        {
            // Simple calculation without taxes if no tax plan configured
            accommodation.TotalGrossWithTax = accommodation.DailyGrossRate * accommodation.NumberOfNights;
            var pctHost = percentToHost / 100m;
            accommodation.DailyNetRate = accommodation.DailyGrossRate * pctHost;
            accommodation.TotalNetWithTax = accommodation.DailyNetRate * accommodation.NumberOfNights;
            accommodation.Tax1 = 0;
            accommodation.Tax2 = 0;
            accommodation.Tax3 = 0;
            accommodation.TotalTax = 0;
            accommodation.ServiceFee = (accommodation.TotalGrossWithTax ?? 0) - (accommodation.TotalNetWithTax ?? 0);
            _bindingSource.ResetCurrentItem();
            return;
        }

        // Get the tax calculation service
        var taxService = Program.ServiceProvider.GetRequiredService<ITaxCalculationService>();

        // Get tax rate info from the TaxPlan
        var taxRateInfo = taxPlan.ToTaxRateInfo();

        // Build calculation input
        var input = new TaxCalculationInput
        {
            DailyGrossRate = accommodation.DailyGrossRate.Value,
            NumberOfNights = accommodation.NumberOfNights,
            PercentToHost = percentToHost,
            TaxPlanCode = taxPlanCode,
            ArrivalDate = accommodation.ArrivalDate,
            PaymentType = accommodation.PaymentType == "Direct" ? PaymentType.Direct
                : accommodation.PaymentType == "Comp" ? PaymentType.Comp
                : PaymentType.Prepay,
            TaxRates = taxRateInfo
        };

        // Calculate
        var result = taxService.CalculateAmounts(input);

        if (result.Success)
        {
            // Apply calculated values
            accommodation.DailyNetRate = result.DailyNetRate;
            accommodation.Tax1 = result.Tax1Amount;
            accommodation.Tax2 = result.Tax2Amount;
            accommodation.Tax3 = result.Tax3Amount;
            accommodation.TotalTax = result.TotalTax;
            accommodation.TotalGrossWithTax = result.GrossWithTax;
            accommodation.TotalNetWithTax = result.NetWithTax;
            accommodation.ServiceFee = result.ServiceFee;
        }

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
        if (_isLoadingData) return;
        if (_currentMode != FormMode.Insert && _currentMode != FormMode.Update) return;

        // Update the accommodation with the new date
        if (_currentAccommodation != null)
        {
            _currentAccommodation.ArrivalDate = dtpArrivalDate.Value;
        }

        CalculateAmounts();
    }

    private void dtpDepartureDate_ValueChanged(object sender, EventArgs e)
    {
        if (_isLoadingData) return;
        if (_currentMode != FormMode.Insert && _currentMode != FormMode.Update) return;

        // Update the accommodation with the new date
        if (_currentAccommodation != null)
        {
            _currentAccommodation.DepartureDate = dtpDepartureDate.Value;
        }

        CalculateAmounts();
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
