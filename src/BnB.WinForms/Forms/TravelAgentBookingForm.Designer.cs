namespace BnB.WinForms.Forms;

partial class TravelAgentBookingForm
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
        this.dgvBookings = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
        this.SuspendLayout();

        // === Split Container ===
        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Orientation = Orientation.Horizontal;
        this.splitContainer.Panel1.Controls.Add(this.panelButtons);
        this.splitContainer.Panel1.Controls.Add(this.panelForm);
        this.splitContainer.Panel2.Controls.Add(this.dgvBookings);
        this.splitContainer.Size = new Size(650, 500);
        this.splitContainer.SplitterDistance = 280;

        // === Panel Form ===
        this.panelForm.Dock = DockStyle.Fill;
        this.panelForm.Padding = new Padding(15);

        int labelX = 20;
        int fieldX = 150;
        int y = 20;
        int rowHeight = 30;

        // Confirmation Number
        this.lblConfirmationNumber.Text = "Confirmation #:";
        this.lblConfirmationNumber.Location = new Point(labelX, y + 3);
        this.lblConfirmationNumber.AutoSize = true;
        this.panelForm.Controls.Add(this.lblConfirmationNumber);

        this.txtConfirmationNumber.Location = new Point(fieldX, y);
        this.txtConfirmationNumber.Size = new Size(100, 23);
        this.txtConfirmationNumber.ReadOnly = true;
        this.panelForm.Controls.Add(this.txtConfirmationNumber);

        y += rowHeight;

        // Guest Name
        this.lblGuestName.Text = "Guest Name:";
        this.lblGuestName.Location = new Point(labelX, y + 3);
        this.lblGuestName.AutoSize = true;
        this.panelForm.Controls.Add(this.lblGuestName);

        this.txtGuestName.Location = new Point(fieldX, y);
        this.txtGuestName.Size = new Size(250, 23);
        this.txtGuestName.ReadOnly = true;
        this.panelForm.Controls.Add(this.txtGuestName);

        y += rowHeight;

        // Travel Agency
        this.lblAgency.Text = "Travel Agency:";
        this.lblAgency.Location = new Point(labelX, y + 3);
        this.lblAgency.AutoSize = true;
        this.panelForm.Controls.Add(this.lblAgency);

        this.cboAgency.Location = new Point(fieldX, y);
        this.cboAgency.Size = new Size(280, 23);
        this.cboAgency.DropDownStyle = ComboBoxStyle.DropDownList;
        this.panelForm.Controls.Add(this.cboAgency);

        y += rowHeight;

        // Commission Amount
        this.lblCommissionAmount.Text = "Commission Amount:";
        this.lblCommissionAmount.Location = new Point(labelX, y + 3);
        this.lblCommissionAmount.AutoSize = true;
        this.panelForm.Controls.Add(this.lblCommissionAmount);

        this.txtCommissionAmount.Location = new Point(fieldX, y);
        this.txtCommissionAmount.Size = new Size(100, 23);
        this.panelForm.Controls.Add(this.txtCommissionAmount);

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
        this.dtpCommissionPaidDate.Size = new Size(150, 23);
        this.dtpCommissionPaidDate.Format = DateTimePickerFormat.Short;
        this.panelForm.Controls.Add(this.dtpCommissionPaidDate);

        y += rowHeight;

        // Check Number
        this.lblCheckNumber.Text = "Check Number:";
        this.lblCheckNumber.Location = new Point(labelX, y + 3);
        this.lblCheckNumber.AutoSize = true;
        this.panelForm.Controls.Add(this.lblCheckNumber);

        this.txtCheckNumber.Location = new Point(fieldX, y);
        this.txtCheckNumber.Size = new Size(100, 23);
        this.panelForm.Controls.Add(this.txtCheckNumber);

        y += rowHeight + 5;

        // Comments
        this.lblComments.Text = "Comments:";
        this.lblComments.Location = new Point(labelX, y);
        this.lblComments.AutoSize = true;
        this.panelForm.Controls.Add(this.lblComments);

        this.txtComments.Location = new Point(fieldX, y);
        this.txtComments.Size = new Size(280, 50);
        this.txtComments.Multiline = true;
        this.txtComments.ScrollBars = ScrollBars.Vertical;
        this.panelForm.Controls.Add(this.txtComments);

        // Record Count
        this.lblRecordCount.Text = "Record 0 of 0";
        this.lblRecordCount.Location = new Point(labelX, y + 60);
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
        this.dgvBookings.Dock = DockStyle.Fill;
        this.dgvBookings.AllowUserToAddRows = false;
        this.dgvBookings.AllowUserToDeleteRows = false;
        this.dgvBookings.ReadOnly = true;
        this.dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvBookings.MultiSelect = false;
        this.dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvBookings.SelectionChanged += dgvBookings_SelectionChanged;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(650, 500);
        this.Controls.Add(this.splitContainer);
        this.Name = "TravelAgentBookingForm";
        this.Text = "Guest Travel Agency";
        this.Load += TravelAgentBookingForm_Load;
        this.FormClosing += TravelAgentBookingForm_FormClosing;

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        this.splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
        this.ResumeLayout(false);
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
    private Label lblCommissionAmount;
    private Label lblCommissionPaid;
    private Label lblCommissionPaidDate;
    private Label lblCheckNumber;
    private Label lblComments;
    private Label lblRecordCount;

    private TextBox txtConfirmationNumber;
    private TextBox txtGuestName;
    private ComboBox cboAgency;
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

    private DataGridView dgvBookings;
}
