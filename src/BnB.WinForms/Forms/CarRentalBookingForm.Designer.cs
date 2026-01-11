namespace BnB.WinForms.Forms;

partial class CarRentalBookingForm
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

        // Labels
        this.lblConfirmationNumber = new Label();
        this.lblGuestName = new Label();
        this.lblAgency = new Label();
        this.lblPickupDate = new Label();
        this.lblReturnDate = new Label();
        this.lblCarType = new Label();
        this.lblDailyRate = new Label();
        this.lblTotalAmount = new Label();
        this.lblCommissionAmount = new Label();
        this.lblCommissionPaid = new Label();
        this.lblCommissionPaidDate = new Label();
        this.lblCheckNumber = new Label();
        this.lblComments = new Label();
        this.lblRecordCount = new Label();

        // TextBoxes and Controls
        this.txtConfirmationNumber = new TextBox();
        this.txtGuestName = new TextBox();
        this.cboAgency = new ComboBox();
        this.dtpPickupDate = new DateTimePicker();
        this.dtpReturnDate = new DateTimePicker();
        this.txtCarType = new TextBox();
        this.txtDailyRate = new TextBox();
        this.txtTotalAmount = new TextBox();
        this.txtCommissionAmount = new TextBox();
        this.txtCommissionPaid = new TextBox();
        this.chkCommissionPaid = new CheckBox();
        this.dtpCommissionPaidDate = new DateTimePicker();
        this.txtCheckNumber = new TextBox();
        this.txtComments = new TextBox();

        // Buttons
        this.btnInsert = new Button();
        this.btnUpdate = new Button();
        this.btnDelete = new Button();
        this.btnCommit = new Button();
        this.btnCancel = new Button();
        this.btnFind = new Button();
        this.btnRefresh = new Button();

        // DataGridView
        this.dgvRentals = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
        this.SuspendLayout();

        // === Split Container ===
        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Orientation = Orientation.Horizontal;
        this.splitContainer.Panel1.Controls.Add(this.panelButtons);
        this.splitContainer.Panel1.Controls.Add(this.panelForm);
        this.splitContainer.Panel2.Controls.Add(this.dgvRentals);
        this.splitContainer.Size = new Size(700, 580);
        this.splitContainer.SplitterDistance = 370;

        // === Panel Form ===
        this.panelForm.Dock = DockStyle.Fill;
        this.panelForm.Padding = new Padding(15);

        int labelX = 20;
        int fieldX = 150;
        int y = 15;
        int rowHeight = 28;

        // Confirmation Number
        AddLabelAndField(lblConfirmationNumber, "Confirmation #:", txtConfirmationNumber, labelX, y, fieldX, 100);
        txtConfirmationNumber.ReadOnly = true;
        y += rowHeight;

        // Guest Name
        AddLabelAndField(lblGuestName, "Guest Name:", txtGuestName, labelX, y, fieldX, 250);
        txtGuestName.ReadOnly = true;
        y += rowHeight;

        // Car Agency
        this.lblAgency.Text = "Car Agency:";
        this.lblAgency.Location = new Point(labelX, y + 3);
        this.lblAgency.AutoSize = true;
        this.panelForm.Controls.Add(this.lblAgency);

        this.cboAgency.Location = new Point(fieldX, y);
        this.cboAgency.Size = new Size(280, 23);
        this.cboAgency.DropDownStyle = ComboBoxStyle.DropDownList;
        this.panelForm.Controls.Add(this.cboAgency);
        y += rowHeight;

        // Pickup Date
        this.lblPickupDate.Text = "Pickup Date:";
        this.lblPickupDate.Location = new Point(labelX, y + 3);
        this.lblPickupDate.AutoSize = true;
        this.panelForm.Controls.Add(this.lblPickupDate);

        this.dtpPickupDate.Location = new Point(fieldX, y);
        this.dtpPickupDate.Size = new Size(130, 23);
        this.dtpPickupDate.Format = DateTimePickerFormat.Short;
        this.panelForm.Controls.Add(this.dtpPickupDate);

        this.lblReturnDate.Text = "Return:";
        this.lblReturnDate.Location = new Point(300, y + 3);
        this.lblReturnDate.AutoSize = true;
        this.panelForm.Controls.Add(this.lblReturnDate);

        this.dtpReturnDate.Location = new Point(360, y);
        this.dtpReturnDate.Size = new Size(130, 23);
        this.dtpReturnDate.Format = DateTimePickerFormat.Short;
        this.panelForm.Controls.Add(this.dtpReturnDate);
        y += rowHeight;

        // Car Type
        AddLabelAndField(lblCarType, "Car Type:", txtCarType, labelX, y, fieldX, 150);
        y += rowHeight;

        // Daily Rate and Total Amount
        AddLabelAndField(lblDailyRate, "Daily Rate:", txtDailyRate, labelX, y, fieldX, 80);

        this.lblTotalAmount.Text = "Total:";
        this.lblTotalAmount.Location = new Point(260, y + 3);
        this.lblTotalAmount.AutoSize = true;
        this.panelForm.Controls.Add(this.lblTotalAmount);

        this.txtTotalAmount.Location = new Point(310, y);
        this.txtTotalAmount.Size = new Size(100, 23);
        this.panelForm.Controls.Add(this.txtTotalAmount);
        y += rowHeight;

        // Commission Amount
        AddLabelAndField(lblCommissionAmount, "Commission Amt:", txtCommissionAmount, labelX, y, fieldX, 100);
        y += rowHeight;

        // Commission Paid
        this.chkCommissionPaid.Text = "Commission Paid:";
        this.chkCommissionPaid.Location = new Point(labelX, y + 3);
        this.chkCommissionPaid.AutoSize = true;
        this.chkCommissionPaid.CheckedChanged += chkCommissionPaid_CheckedChanged;
        this.panelForm.Controls.Add(this.chkCommissionPaid);

        this.txtCommissionPaid.Location = new Point(fieldX, y);
        this.txtCommissionPaid.Size = new Size(100, 23);
        this.panelForm.Controls.Add(this.txtCommissionPaid);
        y += rowHeight;

        // Commission Paid Date
        this.lblCommissionPaidDate.Text = "Date Paid:";
        this.lblCommissionPaidDate.Location = new Point(labelX, y + 3);
        this.lblCommissionPaidDate.AutoSize = true;
        this.panelForm.Controls.Add(this.lblCommissionPaidDate);

        this.dtpCommissionPaidDate.Location = new Point(fieldX, y);
        this.dtpCommissionPaidDate.Size = new Size(130, 23);
        this.dtpCommissionPaidDate.Format = DateTimePickerFormat.Short;
        this.panelForm.Controls.Add(this.dtpCommissionPaidDate);
        y += rowHeight;

        // Check Number
        AddLabelAndField(lblCheckNumber, "Check Number:", txtCheckNumber, labelX, y, fieldX, 100);
        y += rowHeight + 5;

        // Comments
        this.lblComments.Text = "Comments:";
        this.lblComments.Location = new Point(labelX, y);
        this.lblComments.AutoSize = true;
        this.panelForm.Controls.Add(this.lblComments);

        this.txtComments.Location = new Point(fieldX, y);
        this.txtComments.Size = new Size(280, 45);
        this.txtComments.Multiline = true;
        this.txtComments.ScrollBars = ScrollBars.Vertical;
        this.panelForm.Controls.Add(this.txtComments);

        // Record Count
        this.lblRecordCount.Text = "Record 0 of 0";
        this.lblRecordCount.Location = new Point(labelX, y + 55);
        this.lblRecordCount.AutoSize = true;
        this.panelForm.Controls.Add(this.lblRecordCount);

        // === Panel Buttons ===
        this.panelButtons.Dock = DockStyle.Right;
        this.panelButtons.Width = 110;
        this.panelButtons.Padding = new Padding(5);

        int btnY = 15;
        int btnSpacing = 35;

        AddButton(panelButtons, btnInsert, "&Insert", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnUpdate, "&Update", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnDelete, "&Delete", btnY);
        btnY += btnSpacing + 5;
        AddButton(panelButtons, btnCommit, "Co&mmit", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnCancel, "&Cancel", btnY);
        btnY += btnSpacing + 5;
        AddButton(panelButtons, btnFind, "&Find", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnRefresh, "&Refresh", btnY);

        btnInsert.Click += btnInsert_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnCommit.Click += btnCommit_Click;
        btnCancel.Click += btnCancel_Click;
        btnFind.Click += btnFind_Click;
        btnRefresh.Click += btnRefresh_Click;

        // === DataGridView ===
        this.dgvRentals.Dock = DockStyle.Fill;
        this.dgvRentals.AllowUserToAddRows = false;
        this.dgvRentals.AllowUserToDeleteRows = false;
        this.dgvRentals.ReadOnly = true;
        this.dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvRentals.MultiSelect = false;
        this.dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvRentals.SelectionChanged += dgvRentals_SelectionChanged;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(700, 580);
        this.Controls.Add(this.splitContainer);
        this.Name = "CarRentalBookingForm";
        this.Text = "Guest Car Reservations";
        this.Load += CarRentalBookingForm_Load;
        this.FormClosing += CarRentalBookingForm_FormClosing;

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        this.splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
        this.ResumeLayout(false);
    }

    private void AddLabelAndField(Label label, string labelText, TextBox textBox,
        int labelX, int y, int fieldX, int fieldWidth)
    {
        label.Text = labelText;
        label.Location = new Point(labelX, y + 3);
        label.AutoSize = true;
        this.panelForm.Controls.Add(label);

        textBox.Location = new Point(fieldX, y);
        textBox.Size = new Size(fieldWidth, 23);
        this.panelForm.Controls.Add(textBox);
    }

    private void AddButton(Panel panel, Button button, string text, int y)
    {
        button.Text = text;
        button.Location = new Point(5, y);
        button.Size = new Size(95, 28);
        button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        panel.Controls.Add(button);
    }

    #endregion

    private SplitContainer splitContainer;
    private Panel panelForm;
    private Panel panelButtons;

    private Label lblConfirmationNumber;
    private Label lblGuestName;
    private Label lblAgency;
    private Label lblPickupDate;
    private Label lblReturnDate;
    private Label lblCarType;
    private Label lblDailyRate;
    private Label lblTotalAmount;
    private Label lblCommissionAmount;
    private Label lblCommissionPaid;
    private Label lblCommissionPaidDate;
    private Label lblCheckNumber;
    private Label lblComments;
    private Label lblRecordCount;

    private TextBox txtConfirmationNumber;
    private TextBox txtGuestName;
    private ComboBox cboAgency;
    private DateTimePicker dtpPickupDate;
    private DateTimePicker dtpReturnDate;
    private TextBox txtCarType;
    private TextBox txtDailyRate;
    private TextBox txtTotalAmount;
    private TextBox txtCommissionAmount;
    private TextBox txtCommissionPaid;
    private CheckBox chkCommissionPaid;
    private DateTimePicker dtpCommissionPaidDate;
    private TextBox txtCheckNumber;
    private TextBox txtComments;

    private Button btnInsert;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnCommit;
    private Button btnCancel;
    private Button btnFind;
    private Button btnRefresh;

    private DataGridView dgvRentals;
}
