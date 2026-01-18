using BnB.Core.Models;
using BnB.WinForms.UI;

namespace BnB.WinForms.Forms;

/// <summary>
/// Popup form for recording a payment transaction.
/// </summary>
public partial class RecordPaymentForm : Form
{
    public decimal Amount { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public string? CheckNumber { get; private set; }
    public string? ReceivedFrom { get; private set; }
    public string? AppliedTo { get; private set; }
    public string? Comments { get; private set; }

    private readonly long _confirmationNumber;
    private readonly string _guestName;
    private readonly decimal? _depositDue;
    private readonly decimal? _prepaymentDue;
    private readonly decimal? _totalPreviouslyPaid;

    public RecordPaymentForm(long confirmationNumber, string guestName,
        decimal? depositDue = null, decimal? prepaymentDue = null, decimal? totalPreviouslyPaid = null)
    {
        _confirmationNumber = confirmationNumber;
        _guestName = guestName;
        _depositDue = depositDue;
        _prepaymentDue = prepaymentDue;
        _totalPreviouslyPaid = totalPreviouslyPaid;

        InitializeComponent();
        LoadAppliedToOptions();
        SetupInitialValues();
    }

    private void InitializeComponent()
    {
        this.Text = "Record Payment";
        this.Size = new Size(420, 480);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        var lblTitle = new Label
        {
            Text = $"Record Payment for Conf# {_confirmationNumber}",
            Font = new Font(this.Font.FontFamily, 10, FontStyle.Bold),
            Location = new Point(12, 12),
            AutoSize = true
        };

        var lblGuestName = new Label
        {
            Text = _guestName,
            Location = new Point(12, 35),
            AutoSize = true
        };

        // Balance Tally Panel - shows clear progression
        var pnlTally = new Panel
        {
            Location = new Point(12, 60),
            Size = new Size(380, 130),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.FromArgb(250, 250, 250),
            AutoScroll = true
        };

        var totalDue = (_depositDue ?? 0) + (_prepaymentDue ?? 0);
        var previouslyPaid = _totalPreviouslyPaid ?? 0;
        var balance = totalDue - previouslyPaid;

        // Use a monospace-friendly format for alignment
        int labelCol = 10;
        int amountCol = 260;
        int y = 8;

        // Amounts Due section
        var lblDueHeader = new Label
        {
            Text = "Amounts Due:",
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            Location = new Point(labelCol, y),
            AutoSize = true
        };
        y += 20;

        var lblDepositLabel = new Label
        {
            Text = "Deposit:",
            Location = new Point(labelCol + 15, y),
            AutoSize = true
        };
        var lblDepositValue = new Label
        {
            Text = $"{_depositDue ?? 0:C2}",
            Location = new Point(amountCol, y),
            AutoSize = true,
            TextAlign = ContentAlignment.MiddleRight
        };
        y += 18;

        var lblPrepayLabel = new Label
        {
            Text = "Prepayment:",
            Location = new Point(labelCol + 15, y),
            AutoSize = true
        };
        var lblPrepayValue = new Label
        {
            Text = $"{_prepaymentDue ?? 0:C2}",
            Location = new Point(amountCol, y),
            AutoSize = true
        };
        y += 18;

        // Separator and Total Due
        var lblTotalDueLabel = new Label
        {
            Text = "Total Due:",
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            Location = new Point(labelCol + 15, y),
            AutoSize = true
        };
        var lblTotalDueValue = new Label
        {
            Text = $"{totalDue:C2}",
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            Location = new Point(amountCol, y),
            AutoSize = true
        };
        y += 22;

        // Less Payments section
        var lblPaidLabel = new Label
        {
            Text = "Less Payments Received:",
            Location = new Point(labelCol + 15, y),
            AutoSize = true
        };
        var lblPaidValue = new Label
        {
            Text = previouslyPaid > 0 ? $"({previouslyPaid:C2})" : "$0.00",
            Location = new Point(amountCol, y),
            AutoSize = true,
            ForeColor = previouslyPaid > 0 ? Color.Green : Color.Black
        };
        y += 22;

        // Balance Due - highlighted
        var lblBalanceLabel = new Label
        {
            Text = "Balance Due:",
            Font = new Font("Segoe UI", 9, FontStyle.Bold),
            Location = new Point(labelCol, y),
            AutoSize = true
        };
        var lblBalanceValue = new Label
        {
            Text = $"{balance:C2}",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            Location = new Point(amountCol, y),
            AutoSize = true,
            ForeColor = balance > 0 ? Color.FromArgb(180, 0, 0) : Color.FromArgb(0, 128, 0)
        };

        pnlTally.Controls.AddRange(new Control[] {
            lblDueHeader,
            lblDepositLabel, lblDepositValue,
            lblPrepayLabel, lblPrepayValue,
            lblTotalDueLabel, lblTotalDueValue,
            lblPaidLabel, lblPaidValue,
            lblBalanceLabel, lblBalanceValue
        });

        // Amount input - positioned below tally
        int inputY = 200;

        var lblAmount = new Label
        {
            Text = "Amount:",
            Location = new Point(12, inputY),
            Size = new Size(100, 23)
        };

        txtAmount = new TextBox
        {
            Location = new Point(120, inputY - 3),
            Size = new Size(120, 23)
        };

        // Payment Date
        inputY += 30;
        var lblPaymentDate = new Label
        {
            Text = "Payment Date:",
            Location = new Point(12, inputY),
            Size = new Size(100, 23)
        };

        dtpPaymentDate = new DateTimePicker
        {
            Location = new Point(120, inputY - 3),
            Size = new Size(120, 23),
            Format = DateTimePickerFormat.Short
        };

        // Check Number
        inputY += 30;
        var lblCheckNumber = new Label
        {
            Text = "Check #:",
            Location = new Point(12, inputY),
            Size = new Size(100, 23)
        };

        txtCheckNumber = new TextBox
        {
            Location = new Point(120, inputY - 3),
            Size = new Size(120, 23)
        };

        // Received From
        inputY += 30;
        var lblReceivedFrom = new Label
        {
            Text = "Received From:",
            Location = new Point(12, inputY),
            Size = new Size(100, 23)
        };

        txtReceivedFrom = new TextBox
        {
            Location = new Point(120, inputY - 3),
            Size = new Size(200, 23)
        };

        // Applied To
        inputY += 30;
        var lblAppliedTo = new Label
        {
            Text = "Applied To:",
            Location = new Point(12, inputY),
            Size = new Size(100, 23)
        };

        cboAppliedTo = new ComboBox
        {
            Location = new Point(120, inputY - 3),
            Size = new Size(150, 23),
            DropDownStyle = ComboBoxStyle.DropDownList
        };

        // Comments
        inputY += 30;
        var lblComments = new Label
        {
            Text = "Comments:",
            Location = new Point(12, inputY),
            Size = new Size(100, 23)
        };

        txtComments = new TextBox
        {
            Location = new Point(120, inputY - 3),
            Size = new Size(270, 23)
        };

        // Buttons
        inputY += 40;
        btnOK = new Button
        {
            Text = "Record Payment",
            Location = new Point(120, inputY),
            Size = new Size(120, 28),
            DialogResult = DialogResult.None
        };
        btnOK.Click += BtnOK_Click;

        btnCancel = new Button
        {
            Text = "Cancel",
            Location = new Point(250, inputY),
            Size = new Size(80, 28),
            DialogResult = DialogResult.Cancel
        };

        this.Controls.AddRange(new Control[]
        {
            lblTitle, lblGuestName, pnlTally,
            lblAmount, txtAmount,
            lblPaymentDate, dtpPaymentDate,
            lblCheckNumber, txtCheckNumber,
            lblReceivedFrom, txtReceivedFrom,
            lblAppliedTo, cboAppliedTo,
            lblComments, txtComments,
            btnOK, btnCancel
        });

        this.AcceptButton = btnOK;
        this.CancelButton = btnCancel;
    }

    private TextBox txtAmount = null!;
    private DateTimePicker dtpPaymentDate = null!;
    private TextBox txtCheckNumber = null!;
    private TextBox txtReceivedFrom = null!;
    private ComboBox cboAppliedTo = null!;
    private TextBox txtComments = null!;
    private Button btnOK = null!;
    private Button btnCancel = null!;

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

    private void SetupInitialValues()
    {
        dtpPaymentDate.Value = DateTime.Today;
        txtAmount.Text = "";
        cboAppliedTo.SelectedIndex = 0; // Default to "Deposit"

        // Auto-suggest amount based on what's due
        var totalDue = (_depositDue ?? 0) + (_prepaymentDue ?? 0);
        var balance = totalDue - (_totalPreviouslyPaid ?? 0);

        if (_totalPreviouslyPaid == 0 || _totalPreviouslyPaid == null)
        {
            // No payments yet - suggest deposit
            if (_depositDue.HasValue && _depositDue > 0)
            {
                txtAmount.Text = _depositDue.Value.ToString("F2");
                cboAppliedTo.SelectedItem = "Deposit";
            }
        }
        else if (_totalPreviouslyPaid >= _depositDue && balance > 0)
        {
            // Deposit paid, suggest remaining balance (prepayment)
            txtAmount.Text = balance.ToString("F2");
            cboAppliedTo.SelectedItem = "Prepayment";
        }

        txtAmount.Focus();
        txtAmount.SelectAll();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        this.ApplyTheme();
    }

    private void BtnOK_Click(object? sender, EventArgs e)
    {
        // Validate amount
        if (!decimal.TryParse(txtAmount.Text.Replace("$", "").Replace(",", ""), out var amount) || amount <= 0)
        {
            MessageBox.Show("Please enter a valid payment amount greater than zero.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtAmount.Focus();
            return;
        }

        // Check if balance is already zero or negative (fully paid)
        var totalDue = (_depositDue ?? 0) + (_prepaymentDue ?? 0);
        var balance = totalDue - (_totalPreviouslyPaid ?? 0);

        if (balance <= 0)
        {
            var result = MessageBox.Show(
                "This reservation has no balance due. The account is already fully paid.\n\n" +
                "Are you sure you want to record an additional payment?",
                "No Balance Due",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }
        }

        Amount = amount;
        PaymentDate = dtpPaymentDate.Value.Date;
        CheckNumber = string.IsNullOrWhiteSpace(txtCheckNumber.Text) ? null : txtCheckNumber.Text.Trim();
        ReceivedFrom = string.IsNullOrWhiteSpace(txtReceivedFrom.Text) ? null : txtReceivedFrom.Text.Trim();
        AppliedTo = cboAppliedTo.SelectedItem?.ToString();
        Comments = string.IsNullOrWhiteSpace(txtComments.Text) ? null : txtComments.Text.Trim();

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
