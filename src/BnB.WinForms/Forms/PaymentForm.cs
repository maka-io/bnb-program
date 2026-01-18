using BnB.Core.Enums;
using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Services;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Guest Payments form - migrated from PAYMENT.FRM
/// Manages payment records for guests.
/// </summary>
public partial class PaymentForm : Form
{
    private readonly BnBDbContext _dbContext;
    private readonly FormStateManager _stateManager;
    private readonly BindingSource _bindingSource;

    private FormMode _currentMode = FormMode.Browse;
    private Payment? _currentPayment;
    private long? _filterConfirmationNumber;
    private ContextMenuStrip _goToMenu;

    public PaymentForm(BnBDbContext dbContext, long? confirmationNumber = null)
    {
        _dbContext = dbContext;
        _stateManager = new FormStateManager();
        _bindingSource = new BindingSource();
        _filterConfirmationNumber = confirmationNumber;

        InitializeComponent();
        InitializeGoToMenu();
    }

    private void InitializeGoToMenu()
    {
        _goToMenu = new ContextMenuStrip();
        var mnuGuestInfo = new ToolStripMenuItem("Guest General Information");
        mnuGuestInfo.Click += (s, e) => GoToGuestInfo();
        var mnuAccommodations = new ToolStripMenuItem("Guest Accommodations");
        mnuAccommodations.Click += (s, e) => GoToAccommodations();
        _goToMenu.Items.AddRange(new ToolStripItem[] { mnuGuestInfo, mnuAccommodations });
    }

    private void PaymentForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        ConfigureDataGridView();
        LoadPayments();
        SetupDataBindings();
        SetMode(FormMode.Browse);

        // If opened with a confirmation number filter but no payments exist,
        // ask user if they want to create a payment record
        if (_filterConfirmationNumber.HasValue && _bindingSource.Count == 0)
        {
            var result = MessageBox.Show(
                $"No payment records found for Confirmation #{_filterConfirmationNumber.Value}.\n\nWould you like to create a payment record?",
                "No Payment Records",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                StartInsertWithGuestInfo(_filterConfirmationNumber.Value);
            }
        }
    }

    private void StartInsertWithGuestInfo(long confirmationNumber)
    {
        // Look up the accommodation and its property to get payment policy
        var accommodation = _dbContext.Accommodations
            .Include(a => a.Guest)
            .Include(a => a.Property)
            .FirstOrDefault(a => a.ConfirmationNumber == confirmationNumber);
        var guest = accommodation?.Guest;
        var property = accommodation?.Property;

        SetMode(FormMode.Insert);

        _currentPayment = new Payment
        {
            GuestId = guest?.Id ?? 0,
            ConfirmationNumber = confirmationNumber,
            PaymentDate = DateTime.Today,
            Amount = 0,
            FirstName = guest?.FirstName,
            LastName = guest?.LastName
        };

        // Auto-populate payment policy fields from Property if available
        if (property != null && accommodation != null)
        {
            ApplyPropertyPaymentPolicy(_currentPayment, property, accommodation);
        }

        _bindingSource.Add(_currentPayment);
        _bindingSource.Position = _bindingSource.Count - 1;

        // Set up the form fields
        txtConfirmationNumber.DataBindings.Clear();
        txtConfirmationNumber.Text = confirmationNumber.ToString();
        txtConfirmationNumber.ReadOnly = true; // Keep it read-only since we know the guest
        txtFirstName.Text = guest?.FirstName ?? "";
        txtFirstName.ReadOnly = true;
        txtLastName.Text = guest?.LastName ?? "";
        txtLastName.ReadOnly = true;

        txtDepositDue.Focus();
    }

    /// <summary>
    /// Applies the property's payment policy to auto-populate payment due amounts and dates.
    /// </summary>
    private void ApplyPropertyPaymentPolicy(Payment payment, Property property, Accommodation accommodation)
    {
        var arrivalDate = accommodation.ArrivalDate;
        var bookedDate = accommodation.Guest?.DateBooked ?? DateTime.Today;

        // Calculate total for all accommodations with the same confirmation number
        // Note: SQLite doesn't support Sum on decimal, so we load to memory first
        var totalGross = _dbContext.Accommodations
            .Where(a => a.ConfirmationNumber == accommodation.ConfirmationNumber)
            .Select(a => a.TotalGrossWithTax)
            .ToList()
            .Sum() ?? 0m;

        // Calculate deposit amount if deposit percent is set
        if (property.DefaultDepositPercent.HasValue && property.DefaultDepositPercent > 0)
        {
            var depositAmount = totalGross * (property.DefaultDepositPercent.Value / 100m);
            payment.DepositDue = Math.Round(depositAmount, 2);

            // Calculate deposit due date
            if (property.DefaultDepositDueDays.HasValue)
            {
                payment.DepositDueDate = bookedDate.AddDays(property.DefaultDepositDueDays.Value);
            }
        }

        // Calculate prepayment amount (remainder after deposit)
        if (property.DefaultDepositPercent.HasValue && property.DefaultDepositPercent < 100)
        {
            var prepaymentAmount = totalGross - (payment.DepositDue ?? 0);
            payment.PrepaymentDue = Math.Round(prepaymentAmount, 2);
        }
        else if (!property.DefaultDepositPercent.HasValue)
        {
            // No deposit percent set, full amount as prepayment
            payment.PrepaymentDue = totalGross;
        }

        // Calculate prepayment due date (uses peak period override if applicable)
        var prepaymentDueDays = property.GetPrepaymentDueDays(arrivalDate);
        if (prepaymentDueDays.HasValue && prepaymentDueDays > 0)
        {
            payment.PrepaymentDueDate = arrivalDate.AddDays(-prepaymentDueDays.Value);
        }

        // Calculate cancellation fee due date (for reference - fee is usually if they cancel after this date)
        var cancellationNoticeDays = property.GetCancellationNoticeDays(arrivalDate);
        if (cancellationNoticeDays.HasValue && cancellationNoticeDays > 0)
        {
            payment.CancellationFeeDueDate = arrivalDate.AddDays(-cancellationNoticeDays.Value);
        }

        // Calculate cancellation fee (based on deposit forfeiture percentage)
        // This shows what the guest would owe if they cancel late
        var cancellationFeePercent = property.GetCancellationFeePercent(arrivalDate);
        if (cancellationFeePercent.HasValue && payment.DepositDue.HasValue)
        {
            var baseFee = payment.DepositDue.Value * (cancellationFeePercent.Value / 100m);
            // Add processing fee if applicable
            var processingFee = property.CancellationProcessingFee ?? 0m;
            payment.CancellationFee = Math.Round(baseFee + processingFee, 2);
        }
        else if (property.CancellationProcessingFee.HasValue)
        {
            // Only processing fee, no percentage-based fee
            payment.CancellationFee = property.CancellationProcessingFee.Value;
        }
    }

    private void ConfigureDataGridView()
    {
        dgvPayments.AutoGenerateColumns = false;
        dgvPayments.Columns.Clear();

        // Enable horizontal scrolling
        dgvPayments.ScrollBars = ScrollBars.Both;
        dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.ConfirmationNumber),
            HeaderText = "Conf #",
            Width = 70
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.FirstName),
            HeaderText = "First Name",
            Width = 90
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.LastName),
            HeaderText = "Last Name",
            Width = 90
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.Amount),
            HeaderText = "Amt Received",
            Width = 100,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.Balance),
            HeaderText = "Balance",
            Width = 80,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.PaymentDate),
            HeaderText = "Date",
            Width = 85,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "MM/dd/yyyy" }
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.CheckNumber),
            HeaderText = "Check #",
            Width = 80
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.AppliedTo),
            HeaderText = "Applied To",
            Width = 85
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.ReceivedFrom),
            HeaderText = "Received From",
            Width = 115
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.DepositDue),
            HeaderText = "Deposit Due",
            Width = 95,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.DepositDueDate),
            HeaderText = "Dep Date",
            Width = 85,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "MM/dd/yyyy" }
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.PrepaymentDue),
            HeaderText = "Prepay Due",
            Width = 85,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.PrepaymentDueDate),
            HeaderText = "Prepay Date",
            Width = 95,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "MM/dd/yyyy" }
        });
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.CancellationFee),
            HeaderText = "Cancel Fee",
            Width = 80,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        // Add a Comments column that fills remaining space
        dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(Payment.Comments),
            HeaderText = "Comments",
            MinimumWidth = 100,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        });
    }

    private void SetupDataBindings()
    {
        // Guest info
        txtConfirmationNumber.DataBindings.Add("Text", _bindingSource, nameof(Payment.ConfirmationNumber), true);
        txtFirstName.DataBindings.Add("Text", _bindingSource, nameof(Payment.FirstName), true);
        txtLastName.DataBindings.Add("Text", _bindingSource, nameof(Payment.LastName), true);

        // Payments due
        txtDepositDue.DataBindings.Add("Text", _bindingSource, nameof(Payment.DepositDue), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        dtpDepositDueDate.DataBindings.Add("Value", _bindingSource, nameof(Payment.DepositDueDate), true);
        txtPrepaymentDue.DataBindings.Add("Text", _bindingSource, nameof(Payment.PrepaymentDue), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        dtpPrepaymentDueDate.DataBindings.Add("Value", _bindingSource, nameof(Payment.PrepaymentDueDate), true);

        // Cancellation
        txtCancellationFee.DataBindings.Add("Text", _bindingSource, nameof(Payment.CancellationFee), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        dtpCancellationFeeDueDate.DataBindings.Add("Value", _bindingSource, nameof(Payment.CancellationFeeDueDate), true);

        // Other
        txtRefundOwed.DataBindings.Add("Text", _bindingSource, nameof(Payment.RefundOwed), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtOtherCredit.DataBindings.Add("Text", _bindingSource, nameof(Payment.OtherCredit), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        txtDefaultCommission.DataBindings.Add("Text", _bindingSource, nameof(Payment.DefaultCommission), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");

        // Comments
        txtComments.DataBindings.Add("Text", _bindingSource, nameof(Payment.Comments), true);

        // Navigation grid
        dgvPayments.DataSource = _bindingSource;
    }

    private void LoadPayments()
    {
        try
        {
            // Use AsNoTracking to prevent accidental modifications from being persisted
            // This is important because WinForms data binding can cause unexpected writes
            // to tracked entities when controls sync their values
            var query = _dbContext.Payments
                .AsNoTracking()
                .Include(p => p.Guest)
                .AsQueryable();

            if (_filterConfirmationNumber.HasValue)
            {
                query = query.Where(p => p.ConfirmationNumber == _filterConfirmationNumber.Value);
            }

            var payments = query
                .OrderByDescending(p => p.PaymentDate)
                .ToList();

            // Populate FirstName/LastName from Guest if not already set
            foreach (var payment in payments)
            {
                if (string.IsNullOrEmpty(payment.FirstName) && payment.Guest != null)
                {
                    payment.FirstName = payment.Guest.FirstName;
                }
                if (string.IsNullOrEmpty(payment.LastName) && payment.Guest != null)
                {
                    payment.LastName = payment.Guest.LastName;
                }
            }

            _bindingSource.DataSource = payments;

            if (payments.Count == 0)
            {
                SetMode(FormMode.NoRows);
            }
            else
            {
                SetMode(FormMode.Browse);
            }

            UpdateRecordCount();
            UpdateGridTotals();
            UpdateSelectedRecordSummary();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading payments: {ex.Message}", "Error",
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
                btnRecordPayment.Enabled = _bindingSource.Count > 0;
                dgvPayments.Enabled = true;
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
                btnRecordPayment.Enabled = false;
                dgvPayments.Enabled = false;
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
                btnRecordPayment.Enabled = false;
                dgvPayments.Enabled = false;
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
                btnRecordPayment.Enabled = false;
                dgvPayments.Enabled = true;
                break;
        }
    }

    private void UpdateRecordCount()
    {
        lblRecordCount.Text = $"Record {_bindingSource.Position + 1} of {_bindingSource.Count}";
    }

    private void UpdateGridTotals()
    {
        if (_bindingSource.DataSource is List<Payment> payments && payments.Count > 0)
        {
            var totalReceived = payments.Sum(p => p.Amount);
            var totalDue = payments.Sum(p => (p.DepositDue ?? 0) + (p.PrepaymentDue ?? 0));
            var totalBalance = payments.Sum(p => p.Balance);
            var paymentCount = payments.Count;

            lblTotalReceived.Text = $"Total Received: {totalReceived:C2}";
            lblTotalDue.Text = $"Total Due: {totalDue:C2}";
            lblTotalBalance.Text = $"Total Balance: {totalBalance:C2}";

            // Update the Payments Received summary
            lblPaymentsReceivedSummary.Text = $"Total Received: {totalReceived:C2} from {paymentCount} payment record(s)";
        }
        else
        {
            lblTotalReceived.Text = "Total Received: $0.00";
            lblTotalDue.Text = "Total Due: $0.00";
            lblTotalBalance.Text = "Total Balance: $0.00";
            lblPaymentsReceivedSummary.Text = "Total Received: $0.00 from 0 payment(s)";
        }
    }

    private void UpdateSelectedRecordSummary()
    {
        if (_bindingSource.Current is Payment payment)
        {
            var totalDue = (payment.DepositDue ?? 0) + (payment.PrepaymentDue ?? 0);

            lblRecordReceived.Text = $"Received: {payment.Amount:C2}";
            lblRecordDue.Text = $"Due: {totalDue:C2}";
            lblRecordBalance.Text = $"Balance: {payment.Balance:C2}";
        }
        else
        {
            lblRecordReceived.Text = "Received: $0.00";
            lblRecordDue.Text = "Due: $0.00";
            lblRecordBalance.Text = "Balance: $0.00";
        }
    }

    #region Button Event Handlers

    private void btnInsert_Click(object sender, EventArgs e)
    {
        // Finalize any pending edits on the current record before switching
        // Note: Since we use AsNoTracking, these edits won't be persisted accidentally
        _bindingSource.EndEdit();

        SetMode(FormMode.Insert);

        _currentPayment = new Payment
        {
            PaymentDate = DateTime.Today,
            Amount = 0
        };

        _bindingSource.Add(_currentPayment);
        _bindingSource.Position = _bindingSource.Count - 1;

        // Clear the confirmation number so user can enter a new one
        txtConfirmationNumber.DataBindings.Clear();
        txtConfirmationNumber.Clear();
        txtConfirmationNumber.ReadOnly = false;
        txtFirstName.Clear();
        txtFirstName.ReadOnly = true; // First/Last name populated by Lookup
        txtLastName.Clear();
        txtLastName.ReadOnly = true;
        txtConfirmationNumber.Focus();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Payment payment)
        {
            // Check if this entity is already being tracked
            var trackedEntity = _dbContext.ChangeTracker.Entries<Payment>()
                .FirstOrDefault(e => e.Entity.Id == payment.Id);

            if (trackedEntity != null)
            {
                // Use the tracked instance and copy values from the displayed one
                _currentPayment = trackedEntity.Entity;
                // Update position to point to the tracked entity in the binding source
                var index = ((List<Payment>)_bindingSource.DataSource!).FindIndex(p => p.Id == payment.Id);
                if (index >= 0)
                {
                    ((List<Payment>)_bindingSource.DataSource!)[index] = _currentPayment;
                    _bindingSource.ResetItem(index);
                }
            }
            else
            {
                _currentPayment = payment;
                // Attach the untracked entity so changes can be saved
                _dbContext.Payments.Attach(_currentPayment);
            }

            SetMode(FormMode.Update);
            txtDepositDue.Focus();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Payment payment)
        {
            _currentPayment = payment;
            SetMode(FormMode.Delete);

            var result = MessageBox.Show(
                $"Are you sure you want to delete this payment of {payment.Amount:C2} for Conf# {payment.ConfirmationNumber}?",
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
                    if (_currentPayment != null)
                    {
                        // Set the confirmation number from the textbox (binding was cleared)
                        if (long.TryParse(txtConfirmationNumber.Text, out var confNum))
                        {
                            _currentPayment.ConfirmationNumber = confNum;
                        }

                        // Look up guest info via accommodation
                        var accommodation = _dbContext.Accommodations
                            .Include(a => a.Guest)
                            .FirstOrDefault(a => a.ConfirmationNumber == _currentPayment.ConfirmationNumber);

                        if (accommodation?.Guest != null)
                        {
                            _currentPayment.GuestId = accommodation.Guest.Id;
                            _currentPayment.FirstName = accommodation.Guest.FirstName;
                            _currentPayment.LastName = accommodation.Guest.LastName;
                        }
                        else
                        {
                            // Use the manually entered names if guest not found
                            _currentPayment.FirstName = txtFirstName.Text;
                            _currentPayment.LastName = txtLastName.Text;
                        }

                        _dbContext.Payments.Add(_currentPayment);
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Payment added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case FormMode.Update:
                    _bindingSource.EndEdit();
                    // Mark entity as modified since we attached it in Unchanged state
                    if (_currentPayment != null)
                    {
                        _dbContext.Entry(_currentPayment).State = EntityState.Modified;
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Payment updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            // Restore bindings and reload
            RestoreConfirmationNumberBinding();
            LoadPayments();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void RestoreConfirmationNumberBinding()
    {
        if (txtConfirmationNumber.DataBindings.Count == 0)
        {
            txtConfirmationNumber.DataBindings.Add("Text", _bindingSource, nameof(Payment.ConfirmationNumber), true);
        }
    }

    private void CommitDelete()
    {
        try
        {
            if (_currentPayment != null)
            {
                // Check if this entity is already being tracked
                var trackedEntity = _dbContext.ChangeTracker.Entries<Payment>()
                    .FirstOrDefault(e => e.Entity.Id == _currentPayment.Id);

                Payment entityToDelete;
                if (trackedEntity != null)
                {
                    entityToDelete = trackedEntity.Entity;
                }
                else
                {
                    entityToDelete = _currentPayment;
                    _dbContext.Payments.Attach(entityToDelete);
                }

                _dbContext.Payments.Remove(entityToDelete);
                _dbContext.SaveChanges();
                MessageBox.Show("Payment deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadPayments();
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

        if (_currentMode == FormMode.Insert && _currentPayment != null)
        {
            _bindingSource.Remove(_currentPayment);
        }

        _currentPayment = null;
        RestoreConfirmationNumberBinding();
        LoadPayments();
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        using var searchForm = new PaymentSearchForm();
        if (searchForm.ShowDialog(this) == DialogResult.OK && searchForm.SearchCriteria != null)
        {
            var criteria = searchForm.SearchCriteria;
            var query = _dbContext.Payments
                .Include(p => p.Guest)
                .AsQueryable();

            if (criteria.ConfirmationNumber.HasValue)
                query = query.Where(p => p.ConfirmationNumber == criteria.ConfirmationNumber);

            if (!string.IsNullOrEmpty(criteria.GuestName))
            {
                var searchTerm = criteria.GuestName.ToLower();
                query = query.Where(p =>
                    (p.LastName != null && p.LastName.ToLower().Contains(searchTerm)) ||
                    (p.FirstName != null && p.FirstName.ToLower().Contains(searchTerm)) ||
                    (p.Guest != null && p.Guest.LastName != null && p.Guest.LastName.ToLower().Contains(searchTerm)) ||
                    (p.Guest != null && p.Guest.FirstName != null && p.Guest.FirstName.ToLower().Contains(searchTerm)));
            }

            if (criteria.DateFrom.HasValue)
                query = query.Where(p => p.PaymentDate >= criteria.DateFrom);

            if (criteria.DateTo.HasValue)
                query = query.Where(p => p.PaymentDate <= criteria.DateTo);

            if (criteria.MinAmount.HasValue)
                query = query.Where(p => p.Amount >= criteria.MinAmount);

            var results = query.OrderByDescending(p => p.PaymentDate).ToList();

            // Populate FirstName/LastName from Guest if not set
            foreach (var payment in results)
            {
                if (string.IsNullOrEmpty(payment.FirstName) && payment.Guest != null)
                    payment.FirstName = payment.Guest.FirstName;
                if (string.IsNullOrEmpty(payment.LastName) && payment.Guest != null)
                    payment.LastName = payment.Guest.LastName;
            }

            _bindingSource.DataSource = results;

            if (results.Count == 0)
            {
                MessageBox.Show("No payments found matching the criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPayments();
            }
            else
            {
                SetMode(FormMode.Browse);
                UpdateGridTotals();
                UpdateSelectedRecordSummary();
            }
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        _filterConfirmationNumber = null;
        LoadPayments();
    }

    private void btnGoToGuest_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is Payment && btnGoToGuest != null)
        {
            _goToMenu.Show(btnGoToGuest, new Point(0, btnGoToGuest.Height));
        }
    }

    private void GoToGuestInfo()
    {
        if (_bindingSource.Current is Payment payment)
        {
            var form = new GuestForm(_dbContext, payment.GuestId);
            form.MdiParent = this.MdiParent;
            form.Show();
        }
    }

    private void GoToAccommodations()
    {
        if (_bindingSource.Current is Payment payment)
        {
            var form = new AccommodationForm(_dbContext, payment.ConfirmationNumber);
            form.MdiParent = this.MdiParent;
            form.Show();
        }
    }

    private void btnRecordPayment_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is not Payment currentPayment)
            return;

        var confirmationNumber = currentPayment.ConfirmationNumber;
        var guestName = $"{currentPayment.FirstName} {currentPayment.LastName}".Trim();

        // Get the dues from the current record (these represent what's owed for this confirmation)
        var depositDue = currentPayment.DepositDue;
        var prepaymentDue = currentPayment.PrepaymentDue;

        // Calculate total previously paid for this confirmation
        var payments = _bindingSource.DataSource as List<Payment>;
        var totalPreviouslyPaid = payments?
            .Where(p => p.ConfirmationNumber == confirmationNumber)
            .Sum(p => p.Amount) ?? 0m;

        using var recordForm = new RecordPaymentForm(
            confirmationNumber,
            guestName,
            depositDue,
            prepaymentDue,
            totalPreviouslyPaid);

        if (recordForm.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                // Look up guest info for the new payment record
                var accommodation = _dbContext.Accommodations
                    .Include(a => a.Guest)
                    .FirstOrDefault(a => a.ConfirmationNumber == confirmationNumber);

                var newPayment = new Payment
                {
                    ConfirmationNumber = confirmationNumber,
                    GuestId = accommodation?.Guest?.Id ?? currentPayment.GuestId,
                    FirstName = currentPayment.FirstName,
                    LastName = currentPayment.LastName,
                    Amount = recordForm.Amount,
                    PaymentDate = recordForm.PaymentDate,
                    CheckNumber = recordForm.CheckNumber,
                    ReceivedFrom = recordForm.ReceivedFrom,
                    AppliedTo = recordForm.AppliedTo,
                    Comments = recordForm.Comments,
                    // Copy the dues from the current record
                    DepositDue = currentPayment.DepositDue,
                    DepositDueDate = currentPayment.DepositDueDate,
                    PrepaymentDue = currentPayment.PrepaymentDue,
                    PrepaymentDueDate = currentPayment.PrepaymentDueDate,
                    CancellationFee = currentPayment.CancellationFee,
                    CancellationFeeDueDate = currentPayment.CancellationFeeDueDate
                };

                _dbContext.Payments.Add(newPayment);
                _dbContext.SaveChanges();

                MessageBox.Show($"Payment of {recordForm.Amount:C2} recorded successfully.", "Payment Recorded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadPayments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording payment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #endregion

    private bool ValidateInput()
    {
        if (!long.TryParse(txtConfirmationNumber.Text, out _))
        {
            MessageBox.Show("Please enter a valid confirmation number.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmationNumber.Focus();
            return false;
        }

        return true;
    }

    private void dgvPayments_SelectionChanged(object sender, EventArgs e)
    {
        if (_currentMode == FormMode.Browse)
        {
            UpdateRecordCount();
            UpdateSelectedRecordSummary();
        }
    }

    private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
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
/// Search criteria for payment lookup
/// </summary>
public class PaymentSearchCriteria
{
    public long? ConfirmationNumber { get; set; }
    public string? GuestName { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public decimal? MinAmount { get; set; }
}
