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

    public PaymentForm(BnBDbContext dbContext, long? confirmationNumber = null)
    {
        _dbContext = dbContext;
        _stateManager = new FormStateManager();
        _bindingSource = new BindingSource();
        _filterConfirmationNumber = confirmationNumber;

        InitializeComponent();
        LoadAppliedToOptions();
    }

    private void PaymentForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        ConfigureDataGridView();
        LoadPayments();
        SetupDataBindings();
        SetMode(FormMode.Browse);

        // If opened with a confirmation number filter but no payments exist,
        // automatically start insert mode with guest info pre-populated
        if (_filterConfirmationNumber.HasValue && _bindingSource.Count == 0)
        {
            StartInsertWithGuestInfo(_filterConfirmationNumber.Value);
        }
    }

    private void StartInsertWithGuestInfo(long confirmationNumber)
    {
        // Look up the guest info
        var guest = _dbContext.Guests.FirstOrDefault(g => g.ConfirmationNumber == confirmationNumber);

        SetMode(FormMode.Insert);

        _currentPayment = new Payment
        {
            ConfirmationNumber = confirmationNumber,
            PaymentDate = DateTime.Today,
            Amount = 0,
            FirstName = guest?.FirstName,
            LastName = guest?.LastName
        };

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

        txtAmount.Focus();
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

        // Payment received
        txtAmount.DataBindings.Add("Text", _bindingSource, nameof(Payment.Amount), true, DataSourceUpdateMode.OnPropertyChanged, "", "C2");
        dtpPaymentDate.DataBindings.Add("Value", _bindingSource, nameof(Payment.PaymentDate), true);
        txtCheckNumber.DataBindings.Add("Text", _bindingSource, nameof(Payment.CheckNumber), true);
        txtReceivedFrom.DataBindings.Add("Text", _bindingSource, nameof(Payment.ReceivedFrom), true);
        cboAppliedTo.DataBindings.Add("Text", _bindingSource, nameof(Payment.AppliedTo), true);

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

    private void LoadAppliedToOptions()
    {
        cboAppliedTo.Items.Clear();
        cboAppliedTo.Items.AddRange(new object[]
        {
            "Deposit",
            "Prepayment",
            "Balance Due",
            "Service Fee",
            "Cancellation Fee",
            "Other"
        });
    }

    private void LoadPayments()
    {
        try
        {
            var query = _dbContext.Payments
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
            var totalDue = payments.Sum(p => (p.DepositDue ?? 0) + (p.PrepaymentDue ?? 0) + (p.CancellationFee ?? 0));
            var totalBalance = payments.Sum(p => p.Balance);

            lblTotalReceived.Text = $"Total Received: {totalReceived:C2}";
            lblTotalDue.Text = $"Total Due: {totalDue:C2}";
            lblTotalBalance.Text = $"Total Balance: {totalBalance:C2}";
        }
        else
        {
            lblTotalReceived.Text = "Total Received: $0.00";
            lblTotalDue.Text = "Total Due: $0.00";
            lblTotalBalance.Text = "Total Balance: $0.00";
        }
    }

    private void UpdateSelectedRecordSummary()
    {
        if (_bindingSource.Current is Payment payment)
        {
            var totalDue = (payment.DepositDue ?? 0) + (payment.PrepaymentDue ?? 0) + (payment.CancellationFee ?? 0);

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
            _currentPayment = payment;
            SetMode(FormMode.Update);
            txtAmount.Focus();
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

                        // Look up guest info
                        var guest = _dbContext.Guests
                            .FirstOrDefault(g => g.ConfirmationNumber == _currentPayment.ConfirmationNumber);

                        if (guest != null)
                        {
                            _currentPayment.FirstName = guest.FirstName;
                            _currentPayment.LastName = guest.LastName;
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
                _dbContext.Payments.Remove(_currentPayment);
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
        if (_bindingSource.Current is Payment payment)
        {
            MessageBox.Show($"Navigate to Guest Conf# {payment.ConfirmationNumber}",
                "Go To Guest", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        if (!decimal.TryParse(txtAmount.Text.Replace("$", "").Replace(",", ""), out var amount) || amount < 0)
        {
            MessageBox.Show("Please enter a valid payment amount.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtAmount.Focus();
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
