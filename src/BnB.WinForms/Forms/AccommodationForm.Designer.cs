namespace BnB.WinForms.Forms;

partial class AccommodationForm
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
        this.grpGuest = new GroupBox();
        this.grpDates = new GroupBox();
        this.grpCalculatedAmounts = new GroupBox();
        this.grpCommission = new GroupBox();
        this.grpOptions = new GroupBox();
        this.grpComments = new GroupBox();

        // Labels
        this.lblConfirmationNumber = new Label();
        this.lblProperty = new Label();
        this.lblGuestName = new Label();
        this.lblArrivalDate = new Label();
        this.lblDepartureDate = new Label();
        this.lblNights = new Label();
        this.lblNumberOfGuests = new Label();
        this.lblUnitName = new Label();
        this.lblUnitNameDescription = new Label();
        this.lblDailyGrossRate = new Label();
        this.lblDailyNetRate = new Label();
        this.lblTotalGrossWithTax = new Label();
        this.lblTotalNetWithTax = new Label();
        this.lblTotalTax = new Label();
        this.lblTax1 = new Label();
        this.lblTax2 = new Label();
        this.lblTax3 = new Label();
        this.lblServiceFee = new Label();
        this.lblCommissionDue = new Label();
        this.lblCommissionPaid = new Label();
        this.lblCommissionReceived = new Label();
        this.lblOverridePercent = new Label();
        this.lblOverrideTaxPlan = new Label();
        this.lblRecordCount = new Label();

        // TextBoxes
        this.txtConfirmationNumber = new TextBox();
        this.txtGuestName = new TextBox();
        this.txtLocation = new TextBox();
        this.txtNights = new TextBox();
        this.txtNumberOfGuests = new TextBox();
        this.txtUnitName = new TextBox();
        this.txtUnitNameDescription = new TextBox();
        this.txtDailyGrossRate = new TextBox();
        this.txtDailyNetRate = new TextBox();
        this.txtTotalGrossWithTax = new TextBox();
        this.txtTotalNetWithTax = new TextBox();
        this.txtTotalTax = new TextBox();
        this.txtTax1 = new TextBox();
        this.txtTax2 = new TextBox();
        this.txtTax3 = new TextBox();
        this.txtServiceFee = new TextBox();
        this.txtCommissionDue = new TextBox();
        this.txtCommissionPaid = new TextBox();
        this.txtCommissionReceived = new TextBox();
        this.txtOverridePercent = new TextBox();
        this.txtOverrideTaxPlan = new TextBox();
        this.txtComments = new TextBox();
        this.txtNightNotes = new TextBox();

        // ComboBox
        this.cboProperty = new ComboBox();

        // DateTimePickers
        this.dtpArrivalDate = new DateTimePicker();
        this.dtpDepartureDate = new DateTimePicker();

        // CheckBoxes
        this.chkUseManualAmounts = new CheckBox();
        this.chkSuppress = new CheckBox();
        this.chkForfeit = new CheckBox();
        this.chkNotified = new CheckBox();

        // Buttons
        this.btnInsert = new Button();
        this.btnUpdate = new Button();
        this.btnDelete = new Button();
        this.btnCommit = new Button();
        this.btnCancel = new Button();
        this.btnFind = new Button();
        this.btnRefresh = new Button();
        this.btnGoToGuest = new Button();
        this.btnCalculate = new Button();

        // DataGridView
        this.dgvAccommodations = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvAccommodations)).BeginInit();
        this.SuspendLayout();

        // === Split Container ===
        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Orientation = Orientation.Horizontal;
        this.splitContainer.Panel1.Controls.Add(this.panelButtons);
        this.splitContainer.Panel1.Controls.Add(this.panelForm);
        this.splitContainer.Panel2.Controls.Add(this.dgvAccommodations);
        this.splitContainer.Size = new Size(1000, 700);
        this.splitContainer.SplitterDistance = 480;

        // === Panel Form ===
        this.panelForm.Dock = DockStyle.Fill;
        this.panelForm.Padding = new Padding(10);
        this.panelForm.AutoScroll = true;

        // === Guest Group Box ===
        this.grpGuest.Text = "Guest / Property";
        this.grpGuest.Location = new Point(10, 10);
        this.grpGuest.Size = new Size(420, 110);
        this.panelForm.Controls.Add(this.grpGuest);

        int y = 20;
        AddLabelAndField(grpGuest, lblConfirmationNumber, "Conf #:", txtConfirmationNumber, 15, y, 100, 100);
        txtConfirmationNumber.ReadOnly = true;

        y += 28;
        lblProperty.Text = "Property:";
        lblProperty.Location = new Point(15, y + 3);
        lblProperty.AutoSize = true;
        grpGuest.Controls.Add(lblProperty);
        cboProperty.Location = new Point(100, y);
        cboProperty.Size = new Size(300, 23);
        cboProperty.DropDownStyle = ComboBoxStyle.DropDownList;
        grpGuest.Controls.Add(cboProperty);

        y += 28;
        AddLabelAndField(grpGuest, lblGuestName, "Guest:", txtGuestName, 15, y, 100, 150);
        txtGuestName.ReadOnly = true;

        // === Dates Group Box ===
        this.grpDates.Text = "Dates";
        this.grpDates.Location = new Point(10, 125);
        this.grpDates.Size = new Size(420, 140);
        this.panelForm.Controls.Add(this.grpDates);

        y = 22;
        lblArrivalDate.Text = "Arrival:";
        lblArrivalDate.Location = new Point(15, y + 3);
        lblArrivalDate.AutoSize = true;
        grpDates.Controls.Add(lblArrivalDate);
        dtpArrivalDate.Location = new Point(100, y);
        dtpArrivalDate.Size = new Size(130, 23);
        dtpArrivalDate.Format = DateTimePickerFormat.Short;
        dtpArrivalDate.ValueChanged += dtpArrivalDate_ValueChanged;
        grpDates.Controls.Add(dtpArrivalDate);

        y += 28;
        lblDepartureDate.Text = "Departure:";
        lblDepartureDate.Location = new Point(15, y + 3);
        lblDepartureDate.AutoSize = true;
        grpDates.Controls.Add(lblDepartureDate);
        dtpDepartureDate.Location = new Point(100, y);
        dtpDepartureDate.Size = new Size(130, 23);
        dtpDepartureDate.Format = DateTimePickerFormat.Short;
        dtpDepartureDate.ValueChanged += dtpDepartureDate_ValueChanged;
        grpDates.Controls.Add(dtpDepartureDate);

        y += 28;
        AddLabelAndField(grpDates, lblNights, "# Nights:", txtNights, 15, y, 100, 60);
        AddLabelAndField(grpDates, lblNumberOfGuests, "# In Party:", txtNumberOfGuests, 200, y, 280, 60);

        y += 28;
        AddLabelAndField(grpDates, lblUnitName, "Unit:", txtUnitName, 15, y, 100, 60);
        AddLabelAndField(grpDates, lblUnitNameDescription, "Desc:", txtUnitNameDescription, 200, y, 280, 120);

        // === Calculated Amounts Group Box ===
        this.grpCalculatedAmounts.Text = "Calculated Amounts";
        this.grpCalculatedAmounts.Location = new Point(440, 10);
        this.grpCalculatedAmounts.Size = new Size(200, 255);
        this.panelForm.Controls.Add(this.grpCalculatedAmounts);

        y = 22;
        AddLabelAndField(grpCalculatedAmounts, lblDailyGrossRate, "Gross Rate:", txtDailyGrossRate, 10, y, 90, 90);
        y += 26;
        AddLabelAndField(grpCalculatedAmounts, lblDailyNetRate, "Net Rate:", txtDailyNetRate, 10, y, 90, 90);
        y += 26;
        AddLabelAndField(grpCalculatedAmounts, lblTotalGrossWithTax, "Gross+Tax:", txtTotalGrossWithTax, 10, y, 90, 90);
        y += 26;
        AddLabelAndField(grpCalculatedAmounts, lblTotalNetWithTax, "Net+Tax:", txtTotalNetWithTax, 10, y, 90, 90);
        y += 26;
        AddLabelAndField(grpCalculatedAmounts, lblTotalTax, "Total Tax:", txtTotalTax, 10, y, 90, 90);
        y += 26;
        AddLabelAndField(grpCalculatedAmounts, lblTax1, "Tax 1:", txtTax1, 10, y, 90, 90);
        y += 26;
        AddLabelAndField(grpCalculatedAmounts, lblTax2, "Tax 2:", txtTax2, 10, y, 90, 90);
        y += 26;
        AddLabelAndField(grpCalculatedAmounts, lblTax3, "Tax 3:", txtTax3, 10, y, 90, 90);
        y += 26;
        AddLabelAndField(grpCalculatedAmounts, lblServiceFee, "Service Fee:", txtServiceFee, 10, y, 90, 90);

        // === Commission Group Box ===
        this.grpCommission.Text = "Commission Due from Host";
        this.grpCommission.Location = new Point(650, 10);
        this.grpCommission.Size = new Size(200, 115);
        this.panelForm.Controls.Add(this.grpCommission);

        y = 22;
        AddLabelAndField(grpCommission, lblCommissionDue, "Due:", txtCommissionDue, 10, y, 80, 100);
        y += 28;
        AddLabelAndField(grpCommission, lblCommissionPaid, "Paid:", txtCommissionPaid, 10, y, 80, 100);
        y += 28;
        AddLabelAndField(grpCommission, lblCommissionReceived, "Received:", txtCommissionReceived, 10, y, 80, 100);

        // === Options Group Box ===
        this.grpOptions.Text = "Options";
        this.grpOptions.Location = new Point(440, 270);
        this.grpOptions.Size = new Size(410, 130);
        this.panelForm.Controls.Add(this.grpOptions);

        y = 20;
        chkUseManualAmounts.Text = "Use manually entered amounts";
        chkUseManualAmounts.Location = new Point(15, y);
        chkUseManualAmounts.AutoSize = true;
        grpOptions.Controls.Add(chkUseManualAmounts);

        y += 22;
        chkSuppress.Text = "Cancel this accommodation";
        chkSuppress.Location = new Point(15, y);
        chkSuppress.AutoSize = true;
        grpOptions.Controls.Add(chkSuppress);

        y += 22;
        chkForfeit.Text = "Cancelled with forfeiture";
        chkForfeit.Location = new Point(15, y);
        chkForfeit.AutoSize = true;
        grpOptions.Controls.Add(chkForfeit);

        y += 22;
        chkNotified.Text = "Host notification printed";
        chkNotified.Location = new Point(15, y);
        chkNotified.AutoSize = true;
        grpOptions.Controls.Add(chkNotified);

        AddLabelAndField(grpOptions, lblOverrideTaxPlan, "Tax Plan:", txtOverrideTaxPlan, 220, 20, 300, 80);
        AddLabelAndField(grpOptions, lblOverridePercent, "% to Host:", txtOverridePercent, 220, 48, 300, 60);

        // === Comments Group Box ===
        this.grpComments.Text = "Comments";
        this.grpComments.Location = new Point(10, 270);
        this.grpComments.Size = new Size(420, 130);
        this.panelForm.Controls.Add(this.grpComments);

        txtComments.Location = new Point(10, 20);
        txtComments.Size = new Size(190, 100);
        txtComments.Multiline = true;
        txtComments.ScrollBars = ScrollBars.Vertical;
        grpComments.Controls.Add(txtComments);

        lblNightNotes = new Label();
        lblNightNotes.Text = "Night Notes:";
        lblNightNotes.Location = new Point(210, 20);
        lblNightNotes.AutoSize = true;
        grpComments.Controls.Add(lblNightNotes);

        txtNightNotes.Location = new Point(210, 38);
        txtNightNotes.Size = new Size(200, 82);
        txtNightNotes.Multiline = true;
        txtNightNotes.ScrollBars = ScrollBars.Vertical;
        grpComments.Controls.Add(txtNightNotes);

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
        btnY += btnSpacing + 10;
        AddButton(panelButtons, btnCalculate, "Ca&lc", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnGoToGuest, "&Go to...", btnY);

        btnInsert.Click += btnInsert_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnCommit.Click += btnCommit_Click;
        btnCancel.Click += btnCancel_Click;
        btnFind.Click += btnFind_Click;
        btnRefresh.Click += btnRefresh_Click;
        btnCalculate.Click += btnCalculate_Click;
        btnGoToGuest.Click += btnGoToGuest_Click;

        // === Record Count ===
        this.lblRecordCount.Text = "Record 0 of 0";
        this.lblRecordCount.Location = new Point(10, 410);
        this.lblRecordCount.AutoSize = true;
        this.panelForm.Controls.Add(lblRecordCount);

        // === DataGridView ===
        this.dgvAccommodations.Dock = DockStyle.Fill;
        this.dgvAccommodations.AllowUserToAddRows = false;
        this.dgvAccommodations.AllowUserToDeleteRows = false;
        this.dgvAccommodations.ReadOnly = true;
        this.dgvAccommodations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvAccommodations.MultiSelect = false;
        this.dgvAccommodations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvAccommodations.SelectionChanged += dgvAccommodations_SelectionChanged;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1000, 700);
        this.Controls.Add(this.splitContainer);
        this.Name = "AccommodationForm";
        this.Text = "Guest Accommodations";
        this.Load += AccommodationForm_Load;
        this.FormClosing += AccommodationForm_FormClosing;

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        this.splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvAccommodations)).EndInit();
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

    private GroupBox grpGuest;
    private GroupBox grpDates;
    private GroupBox grpCalculatedAmounts;
    private GroupBox grpCommission;
    private GroupBox grpOptions;
    private GroupBox grpComments;

    private Label lblConfirmationNumber;
    private Label lblProperty;
    private Label lblGuestName;
    private Label lblArrivalDate;
    private Label lblDepartureDate;
    private Label lblNights;
    private Label lblNumberOfGuests;
    private Label lblUnitName;
    private Label lblUnitNameDescription;
    private Label lblDailyGrossRate;
    private Label lblDailyNetRate;
    private Label lblTotalGrossWithTax;
    private Label lblTotalNetWithTax;
    private Label lblTotalTax;
    private Label lblTax1;
    private Label lblTax2;
    private Label lblTax3;
    private Label lblServiceFee;
    private Label lblCommissionDue;
    private Label lblCommissionPaid;
    private Label lblCommissionReceived;
    private Label lblOverridePercent;
    private Label lblOverrideTaxPlan;
    private Label lblNightNotes;
    private Label lblRecordCount;

    private TextBox txtConfirmationNumber;
    private TextBox txtGuestName;
    private TextBox txtLocation;
    private TextBox txtNights;
    private TextBox txtNumberOfGuests;
    private TextBox txtUnitName;
    private TextBox txtUnitNameDescription;
    private TextBox txtDailyGrossRate;
    private TextBox txtDailyNetRate;
    private TextBox txtTotalGrossWithTax;
    private TextBox txtTotalNetWithTax;
    private TextBox txtTotalTax;
    private TextBox txtTax1;
    private TextBox txtTax2;
    private TextBox txtTax3;
    private TextBox txtServiceFee;
    private TextBox txtCommissionDue;
    private TextBox txtCommissionPaid;
    private TextBox txtCommissionReceived;
    private TextBox txtOverridePercent;
    private TextBox txtOverrideTaxPlan;
    private TextBox txtComments;
    private TextBox txtNightNotes;

    private ComboBox cboProperty;

    private DateTimePicker dtpArrivalDate;
    private DateTimePicker dtpDepartureDate;

    private CheckBox chkUseManualAmounts;
    private CheckBox chkSuppress;
    private CheckBox chkForfeit;
    private CheckBox chkNotified;

    private Button btnInsert;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnCommit;
    private Button btnCancel;
    private Button btnFind;
    private Button btnRefresh;
    private Button btnGoToGuest;
    private Button btnCalculate;

    private DataGridView dgvAccommodations;
}
