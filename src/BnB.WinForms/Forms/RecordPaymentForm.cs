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
        this.Size = new Size(400, 380);
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

        // Summary panel
        var pnlSummary = new Panel
        {
            Location = new Point(12, 60),
            Size = new Size(360, 50),
            BorderStyle = BorderStyle.FixedSingle
        };

        var lblDepositDue = new Label
        {
            Text = $"Deposit Due: {_depositDue:C2}",
            Location = new Point(5, 5),
            AutoSize = true
        };

        var lblPrepaymentDue = new Label
        {
            Text = $"Prepayment Due: {_prepaymentDue:C2}",
            Location = new Point(5, 25),
            AutoSize = true
        };

        var lblPreviouslyPaid = new Label
        {
            Text = $"Previously Paid: {_totalPreviouslyPaid:C2}",
            Location = new Point(180, 5),
            AutoSize = true
        };

        var totalDue = (_depositDue ?? 0) + (_prepaymentDue ?? 0);
        var balance = totalDue - (_totalPreviouslyPaid ?? 0);
        var lblBalance = new Label
        {
            Text = $"Balance: {balance:C2}",
            Location = new Point(180, 25),
            AutoSize = true,
            ForeColor = balance > 0 ? Color.Red : Color.Green
        };

        pnlSummary.Controls.AddRange(new Control[] { lblDepositDue, lblPrepaymentDue, lblPreviouslyPaid, lblBalance });

        // Amount
        var lblAmount = new Label
        {
            Text = "Amount:",
            Location = new Point(12, 125),
            Size = new Size(100, 23)
        };

        txtAmount = new TextBox
        {
            Location = new Point(120, 122),
            Size = new Size(120, 23)
        };

        // Payment Date
        var lblPaymentDate = new Label
        {
            Text = "Payment Date:",
            Location = new Point(12, 155),
            Size = new Size(100, 23)
        };

        dtpPaymentDate = new DateTimePicker
        {
            Location = new Point(120, 152),
            Size = new Size(120, 23),
            Format = DateTimePickerFormat.Short
        };

        // Check Number
        var lblCheckNumber = new Label
        {
            Text = "Check #:",
            Location = new Point(12, 185),
            Size = new Size(100, 23)
        };

        txtCheckNumber = new TextBox
        {
            Location = new Point(120, 182),
            Size = new Size(120, 23)
        };

        // Received From
        var lblReceivedFrom = new Label
        {
            Text = "Received From:",
            Location = new Point(12, 215),
            Size = new Size(100, 23)
        };

        txtReceivedFrom = new TextBox
        {
            Location = new Point(120, 212),
            Size = new Size(200, 23)
        };

        // Applied To
        var lblAppliedTo = new Label
        {
            Text = "Applied To:",
            Location = new Point(12, 245),
            Size = new Size(100, 23)
        };

        cboAppliedTo = new ComboBox
        {
            Location = new Point(120, 242),
            Size = new Size(150, 23),
            DropDownStyle = ComboBoxStyle.DropDownList
        };

        // Comments
        var lblComments = new Label
        {
            Text = "Comments:",
            Location = new Point(12, 275),
            Size = new Size(100, 23)
        };

        txtComments = new TextBox
        {
            Location = new Point(120, 272),
            Size = new Size(252, 23)
        };

        // Buttons
        btnOK = new Button
        {
            Text = "Record Payment",
            Location = new Point(120, 305),
            Size = new Size(120, 28),
            DialogResult = DialogResult.None
        };
        btnOK.Click += BtnOK_Click;

        btnCancel = new Button
        {
            Text = "Cancel",
            Location = new Point(250, 305),
            Size = new Size(80, 28),
            DialogResult = DialogResult.Cancel
        };

        this.Controls.AddRange(new Control[]
        {
            lblTitle, lblGuestName, pnlSummary,
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
