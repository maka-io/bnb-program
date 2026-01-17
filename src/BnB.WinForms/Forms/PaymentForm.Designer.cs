namespace BnB.WinForms.Forms;

partial class PaymentForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();

        // Main layout
        this.splitContainer = new SplitContainer();
        this.panelForm = new Panel();
        this.panelButtons = new Panel();

        // Group boxes
        this.grpGuestInfo = new GroupBox();
        this.grpPaymentReceived = new GroupBox();
        this.grpPaymentsDue = new GroupBox();
        this.grpRefund = new GroupBox();
        this.grpOtherCredits = new GroupBox();

        // Guest Info controls
        this.lblConfirmationNumber = new Label();
        this.lblFirstName = new Label();
        this.lblLastName = new Label();
        this.txtConfirmationNumber = new TextBox();
        this.txtFirstName = new TextBox();
        this.txtLastName = new TextBox();

        // Payment Received controls
        this.lblAmount = new Label();
        this.lblPaymentDate = new Label();
        this.lblCheckNumber = new Label();
        this.lblReceivedFrom = new Label();
        this.lblAppliedTo = new Label();
        this.txtAmount = new TextBox();
        this.dtpPaymentDate = new DateTimePicker();
        this.txtCheckNumber = new TextBox();
        this.txtReceivedFrom = new TextBox();
        this.cboAppliedTo = new ComboBox();

        // Payments Due controls
        this.lblDepositDue = new Label();
        this.lblDepositDueDate = new Label();
        this.lblPrepaymentDue = new Label();
        this.lblPrepaymentDueDate = new Label();
        this.lblCancellationFee = new Label();
        this.lblCancellationFeeDueDate = new Label();
        this.txtDepositDue = new TextBox();
        this.dtpDepositDueDate = new DateTimePicker();
        this.txtPrepaymentDue = new TextBox();
        this.dtpPrepaymentDueDate = new DateTimePicker();
        this.txtCancellationFee = new TextBox();
        this.dtpCancellationFeeDueDate = new DateTimePicker();

        // Refund controls
        this.lblRefundOwed = new Label();
        this.txtRefundOwed = new TextBox();

        // Other Credits controls
        this.lblDefaultCommission = new Label();
        this.lblOtherCredit = new Label();
        this.txtDefaultCommission = new TextBox();
        this.txtOtherCredit = new TextBox();

        // Comments
        this.lblComments = new Label();
        this.txtComments = new TextBox();

        // Grid Totals
        this.lblTotalReceived = new Label();
        this.lblTotalDue = new Label();
        this.lblTotalBalance = new Label();

        // Selected Record Summary
        this.lblRecordReceived = new Label();
        this.lblRecordDue = new Label();
        this.lblRecordBalance = new Label();

        // Buttons
        this.btnInsert = new Button();
        this.btnUpdate = new Button();
        this.btnDelete = new Button();
        this.btnCommit = new Button();
        this.btnCancel = new Button();
        this.btnFind = new Button();
        this.btnRefresh = new Button();
        this.btnGoToGuest = new Button();
        this.btnRecordPayment = new Button();

        // Other controls
        this.lblRecordCount = new Label();
        this.dgvPayments = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
        this.SuspendLayout();

        // === Split Container ===
        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Orientation = Orientation.Horizontal;
        this.splitContainer.Panel1.Controls.Add(this.panelButtons);
        this.splitContainer.Panel1.Controls.Add(this.panelForm);
        this.splitContainer.Panel2.Controls.Add(this.dgvPayments);
        this.splitContainer.Size = new Size(950, 700);
        this.splitContainer.SplitterDistance = 420;

        // === Panel Form ===
        this.panelForm.Dock = DockStyle.Fill;
        this.panelForm.Padding = new Padding(10);
        this.panelForm.AutoScroll = true;

        // === Guest Info Group ===
        this.grpGuestInfo.Text = "Guest Information";
        this.grpGuestInfo.Location = new Point(10, 10);
        this.grpGuestInfo.Size = new Size(350, 120);
        this.panelForm.Controls.Add(this.grpGuestInfo);

        int y = 25;
        AddLabelAndField(grpGuestInfo, lblConfirmationNumber, "Conf #:", txtConfirmationNumber, 10, y, 80, 100);

        y += 30;
        AddLabelAndField(grpGuestInfo, lblFirstName, "First Name:", txtFirstName, 10, y, 80, 150);
        y += 30;
        AddLabelAndField(grpGuestInfo, lblLastName, "Last Name:", txtLastName, 10, y, 80, 150);

        // === Payment Received Group ===
        this.grpPaymentReceived.Text = "Payment Received";
        this.grpPaymentReceived.Location = new Point(10, 140);
        this.grpPaymentReceived.Size = new Size(350, 170);
        this.panelForm.Controls.Add(this.grpPaymentReceived);

        y = 22;
        AddLabelAndField(grpPaymentReceived, lblAmount, "Amount:", txtAmount, 10, y, 90, 100);
        y += 28;
        lblPaymentDate.Text = "Date:";
        lblPaymentDate.Location = new Point(10, y + 3);
        lblPaymentDate.AutoSize = true;
        grpPaymentReceived.Controls.Add(lblPaymentDate);
        dtpPaymentDate.Location = new Point(90, y);
        dtpPaymentDate.Size = new Size(130, 23);
        dtpPaymentDate.Format = DateTimePickerFormat.Short;
        grpPaymentReceived.Controls.Add(dtpPaymentDate);

        y += 28;
        AddLabelAndField(grpPaymentReceived, lblCheckNumber, "Check/CC#:", txtCheckNumber, 10, y, 90, 150);
        y += 28;
        AddLabelAndField(grpPaymentReceived, lblReceivedFrom, "From:", txtReceivedFrom, 10, y, 90, 200);
        y += 28;
        lblAppliedTo.Text = "Applied To:";
        lblAppliedTo.Location = new Point(10, y + 3);
        lblAppliedTo.AutoSize = true;
        grpPaymentReceived.Controls.Add(lblAppliedTo);
        cboAppliedTo.Location = new Point(90, y);
        cboAppliedTo.Size = new Size(150, 23);
        cboAppliedTo.DropDownStyle = ComboBoxStyle.DropDownList;
        grpPaymentReceived.Controls.Add(cboAppliedTo);

        // === Payments Due Group ===
        this.grpPaymentsDue.Text = "Payments Due from Guest";
        this.grpPaymentsDue.Location = new Point(370, 10);
        this.grpPaymentsDue.Size = new Size(360, 140);
        this.panelForm.Controls.Add(this.grpPaymentsDue);

        y = 22;
        AddLabelAndField(grpPaymentsDue, lblDepositDue, "Deposit:", txtDepositDue, 10, y, 90, 80);
        lblDepositDueDate.Text = "Due:";
        lblDepositDueDate.Location = new Point(185, y + 3);
        lblDepositDueDate.AutoSize = true;
        grpPaymentsDue.Controls.Add(lblDepositDueDate);
        dtpDepositDueDate.Location = new Point(220, y);
        dtpDepositDueDate.Size = new Size(125, 23);
        dtpDepositDueDate.Format = DateTimePickerFormat.Short;
        grpPaymentsDue.Controls.Add(dtpDepositDueDate);

        y += 28;
        AddLabelAndField(grpPaymentsDue, lblPrepaymentDue, "Prepayment:", txtPrepaymentDue, 10, y, 90, 80);
        lblPrepaymentDueDate.Text = "Due:";
        lblPrepaymentDueDate.Location = new Point(185, y + 3);
        lblPrepaymentDueDate.AutoSize = true;
        grpPaymentsDue.Controls.Add(lblPrepaymentDueDate);
        dtpPrepaymentDueDate.Location = new Point(220, y);
        dtpPrepaymentDueDate.Size = new Size(125, 23);
        dtpPrepaymentDueDate.Format = DateTimePickerFormat.Short;
        grpPaymentsDue.Controls.Add(dtpPrepaymentDueDate);

        y += 28;
        AddLabelAndField(grpPaymentsDue, lblCancellationFee, "Cancel Fee:", txtCancellationFee, 10, y, 90, 80);
        lblCancellationFeeDueDate.Text = "Due:";
        lblCancellationFeeDueDate.Location = new Point(185, y + 3);
        lblCancellationFeeDueDate.AutoSize = true;
        grpPaymentsDue.Controls.Add(lblCancellationFeeDueDate);
        dtpCancellationFeeDueDate.Location = new Point(220, y);
        dtpCancellationFeeDueDate.Size = new Size(125, 23);
        dtpCancellationFeeDueDate.Format = DateTimePickerFormat.Short;
        grpPaymentsDue.Controls.Add(dtpCancellationFeeDueDate);

        // === Refund Group ===
        this.grpRefund.Text = "Refund Due to Guest";
        this.grpRefund.Location = new Point(370, 160);
        this.grpRefund.Size = new Size(175, 60);
        this.panelForm.Controls.Add(this.grpRefund);

        y = 25;
        AddLabelAndField(grpRefund, lblRefundOwed, "Amount:", txtRefundOwed, 10, y, 70, 90);

        // === Other Credits Group ===
        this.grpOtherCredits.Text = "Other Credits";
        this.grpOtherCredits.Location = new Point(555, 160);
        this.grpOtherCredits.Size = new Size(175, 90);
        this.panelForm.Controls.Add(this.grpOtherCredits);

        y = 22;
        AddLabelAndField(grpOtherCredits, lblDefaultCommission, "Def Comm:", txtDefaultCommission, 10, y, 80, 80);
        y += 28;
        AddLabelAndField(grpOtherCredits, lblOtherCredit, "Other:", txtOtherCredit, 10, y, 80, 80);

        // === Comments ===
        lblComments.Text = "Comments:";
        lblComments.Location = new Point(10, 320);
        lblComments.AutoSize = true;
        panelForm.Controls.Add(lblComments);

        txtComments.Location = new Point(10, 338);
        txtComments.Size = new Size(350, 70);
        txtComments.Multiline = true;
        txtComments.ScrollBars = ScrollBars.Vertical;
        panelForm.Controls.Add(txtComments);

        // === Selected Record Summary ===
        this.grpRecordSummary = new GroupBox();
        this.grpRecordSummary.Text = "Summary";
        this.grpRecordSummary.Location = new Point(370, 260);
        this.grpRecordSummary.Size = new Size(360, 55);
        this.panelForm.Controls.Add(this.grpRecordSummary);

        lblRecordReceived.Text = "Received: $0.00";
        lblRecordReceived.Location = new Point(10, 22);
        lblRecordReceived.AutoSize = true;
        grpRecordSummary.Controls.Add(lblRecordReceived);

        lblRecordDue.Text = "Due: $0.00";
        lblRecordDue.Location = new Point(130, 22);
        lblRecordDue.AutoSize = true;
        grpRecordSummary.Controls.Add(lblRecordDue);

        lblRecordBalance.Text = "Balance: $0.00";
        lblRecordBalance.Location = new Point(230, 22);
        lblRecordBalance.AutoSize = true;
        lblRecordBalance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpRecordSummary.Controls.Add(lblRecordBalance);

        // === Record Count ===
        this.lblRecordCount.Text = "Record 0 of 0";
        this.lblRecordCount.Location = new Point(370, 320);
        this.lblRecordCount.AutoSize = true;
        this.panelForm.Controls.Add(lblRecordCount);

        // === Panel Buttons ===
        this.panelButtons.Dock = DockStyle.Right;
        this.panelButtons.Width = 120;
        this.panelButtons.Padding = new Padding(5);

        int btnY = 15;
        int btnSpacing = 40;

        AddButton(panelButtons, btnInsert, "&Insert", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnUpdate, "&Update", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnDelete, "&Delete", btnY);
        btnY += btnSpacing + 10;
        AddButton(panelButtons, btnCommit, "Co&mmit", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnCancel, "&Cancel", btnY);
        btnY += btnSpacing + 10;
        AddButton(panelButtons, btnFind, "&Find", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnRefresh, "&Refresh", btnY);
        btnY += btnSpacing + 15;
        AddButton(panelButtons, btnGoToGuest, "&Go to...", btnY);
        btnY += btnSpacing + 10;
        AddButton(panelButtons, btnRecordPayment, "Record &Pmt", btnY);
        btnRecordPayment.BackColor = Color.FromArgb(230, 245, 230);

        btnInsert.Click += btnInsert_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnCommit.Click += btnCommit_Click;
        btnCancel.Click += btnCancel_Click;
        btnFind.Click += btnFind_Click;
        btnRefresh.Click += btnRefresh_Click;
        btnGoToGuest.Click += btnGoToGuest_Click;
        btnRecordPayment.Click += btnRecordPayment_Click;

        // === Summary Panel (above DataGrid) ===
        this.panelSummary = new Panel();
        this.panelSummary.Dock = DockStyle.Top;
        this.panelSummary.Height = 30;
        this.panelSummary.Padding = new Padding(5, 5, 5, 5);
        this.splitContainer.Panel2.Controls.Add(this.panelSummary);

        lblTotalReceived.Text = "Total Received: $0.00";
        lblTotalReceived.Location = new Point(10, 7);
        lblTotalReceived.AutoSize = true;
        panelSummary.Controls.Add(lblTotalReceived);

        lblTotalDue.Text = "Total Due: $0.00";
        lblTotalDue.Location = new Point(180, 7);
        lblTotalDue.AutoSize = true;
        panelSummary.Controls.Add(lblTotalDue);

        lblTotalBalance.Text = "Total Balance: $0.00";
        lblTotalBalance.Location = new Point(330, 7);
        lblTotalBalance.AutoSize = true;
        lblTotalBalance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        panelSummary.Controls.Add(lblTotalBalance);

        // === DataGridView ===
        this.dgvPayments.Dock = DockStyle.Fill;
        this.dgvPayments.AllowUserToAddRows = false;
        this.dgvPayments.AllowUserToDeleteRows = false;
        this.dgvPayments.ReadOnly = true;
        this.dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvPayments.MultiSelect = false;
        this.dgvPayments.ScrollBars = ScrollBars.Both;
        this.dgvPayments.SelectionChanged += dgvPayments_SelectionChanged;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(950, 700);
        this.Controls.Add(this.splitContainer);
        this.Name = "PaymentForm";
        this.Text = "Guest Payments";
        this.Load += PaymentForm_Load;
        this.FormClosing += PaymentForm_FormClosing;

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        this.splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
        this.ResumeLayout(false);
    }

    private void AddLabelAndField(Control container, Label label, string labelText, TextBox textBox,
        int labelX, int y, int fieldX, int fieldWidth)
    {
        label.Text = labelText;
        label.Location = new Point(labelX, y + 3);
        label.AutoSize = true;
        container.Controls.Add(label);

        textBox.Location = new Point(fieldX, y);
        textBox.Size = new Size(fieldWidth, 23);
        container.Controls.Add(textBox);
    }

    private void AddButton(Panel panel, Button button, string text, int y)
    {
        button.Text = text;
        button.Location = new Point(10, y);
        button.Size = new Size(100, 32);
        button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        panel.Controls.Add(button);
    }

    #endregion

    private SplitContainer splitContainer;
    private Panel panelForm;
    private Panel panelButtons;

    private GroupBox grpGuestInfo;
    private GroupBox grpPaymentReceived;
    private GroupBox grpPaymentsDue;
    private GroupBox grpRefund;
    private GroupBox grpOtherCredits;
    private Panel panelSummary;

    // Guest Info
    private Label lblConfirmationNumber;
    private Label lblFirstName;
    private Label lblLastName;
    private TextBox txtConfirmationNumber;
    private TextBox txtFirstName;
    private TextBox txtLastName;

    // Payment Received
    private Label lblAmount;
    private Label lblPaymentDate;
    private Label lblCheckNumber;
    private Label lblReceivedFrom;
    private Label lblAppliedTo;
    private TextBox txtAmount;
    private DateTimePicker dtpPaymentDate;
    private TextBox txtCheckNumber;
    private TextBox txtReceivedFrom;
    private ComboBox cboAppliedTo;

    // Payments Due
    private Label lblDepositDue;
    private Label lblDepositDueDate;
    private Label lblPrepaymentDue;
    private Label lblPrepaymentDueDate;
    private Label lblCancellationFee;
    private Label lblCancellationFeeDueDate;
    private TextBox txtDepositDue;
    private DateTimePicker dtpDepositDueDate;
    private TextBox txtPrepaymentDue;
    private DateTimePicker dtpPrepaymentDueDate;
    private TextBox txtCancellationFee;
    private DateTimePicker dtpCancellationFeeDueDate;

    // Refund
    private Label lblRefundOwed;
    private TextBox txtRefundOwed;

    // Other Credits
    private Label lblDefaultCommission;
    private Label lblOtherCredit;
    private TextBox txtDefaultCommission;
    private TextBox txtOtherCredit;

    // Comments
    private Label lblComments;
    private TextBox txtComments;

    // Grid Totals (above datagrid)
    private Label lblTotalReceived;
    private Label lblTotalDue;
    private Label lblTotalBalance;

    // Selected Record Summary (in form area)
    private GroupBox grpRecordSummary;
    private Label lblRecordReceived;
    private Label lblRecordDue;
    private Label lblRecordBalance;

    // Buttons
    private Button btnInsert;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnCommit;
    private Button btnCancel;
    private Button btnFind;
    private Button btnRefresh;
    private Button btnGoToGuest;
    private Button btnRecordPayment;

    // Other
    private Label lblRecordCount;
    private DataGridView dgvPayments;
}
