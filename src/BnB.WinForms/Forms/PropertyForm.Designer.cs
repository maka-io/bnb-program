namespace BnB.WinForms.Forms;

partial class PropertyForm
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
        this.grpGeneralInfo = new GroupBox();
        this.grpPropertyAddress = new GroupBox();
        this.grpMailingAddress = new GroupBox();
        this.grpTaxInfo = new GroupBox();
        this.grpFuturePercent = new GroupBox();
        this.grpOptions = new GroupBox();
        this.grpPaymentPolicy = new GroupBox();
        this.grpPeakPeriod = new GroupBox();

        // General Info controls
        this.lblAccountNumber = new Label();
        this.lblLocation = new Label();
        this.lblFullName = new Label();
        this.lblCheckTo = new Label();
        this.lblPercentToHost = new Label();
        this.lblGrossRatePercent = new Label();
        this.txtAccountNumber = new TextBox();
        this.txtLocation = new TextBox();
        this.txtFullName = new TextBox();
        this.txtCheckTo = new TextBox();
        this.txtPercentToHost = new TextBox();
        this.txtGrossRatePercent = new TextBox();

        // Property Address controls
        this.lblPropertyAddress = new Label();
        this.lblPropertyCity = new Label();
        this.lblPropertyState = new Label();
        this.lblPropertyZipCode = new Label();
        this.lblPropertyPhone = new Label();
        this.lblPropertyFax = new Label();
        this.txtPropertyAddress = new TextBox();
        this.txtPropertyCity = new TextBox();
        this.txtPropertyState = new TextBox();
        this.txtPropertyZipCode = new TextBox();
        this.txtPropertyPhone = new TextBox();
        this.txtPropertyFax = new TextBox();

        // Mailing Address controls
        this.lblMailingAddress = new Label();
        this.lblMailingCity = new Label();
        this.lblMailingState = new Label();
        this.lblMailingZipCode = new Label();
        this.lblMailingPhone1 = new Label();
        this.lblMailingPhone2 = new Label();
        this.lblMailingFax = new Label();
        this.lblEmail = new Label();
        this.lblWebUrl = new Label();
        this.lblComments = new Label();
        this.txtMailingAddress = new TextBox();
        this.txtMailingCity = new TextBox();
        this.txtMailingState = new TextBox();
        this.txtMailingZipCode = new TextBox();
        this.txtMailingPhone1 = new TextBox();
        this.txtMailingPhone2 = new TextBox();
        this.txtMailingFax = new TextBox();
        this.txtEmail = new TextBox();
        this.txtWebUrl = new TextBox();
        this.txtComments = new TextBox();

        // Tax Info controls
        this.lblFederalTaxId = new Label();
        this.lblDBA = new Label();
        this.lblTaxPlanCode = new Label();
        this.txtFederalTaxId = new TextBox();
        this.txtDBA = new TextBox();
        this.txtTaxPlanCode = new TextBox();
        this.cboTaxPlan = new ComboBox();

        // Future Percent controls
        this.lblFuturePercent = new Label();
        this.lblFuturePercentDate = new Label();
        this.txtFuturePercent = new TextBox();
        this.dtpFuturePercentDate = new DateTimePicker();

        // Options controls
        this.chkSuppressFlag = new CheckBox();
        this.chkIsObsolete = new CheckBox();
        this.lblDepositRequired = new Label();
        this.txtDepositRequired = new TextBox();
        this.chkExceptions = new CheckBox();
        this.txtExceptionsDescription = new TextBox();

        // Payment Policy controls
        this.lblDefaultDepositPercent = new Label();
        this.txtDefaultDepositPercent = new TextBox();
        this.lblDefaultDepositDueDays = new Label();
        this.txtDefaultDepositDueDays = new TextBox();
        this.lblDefaultPrepaymentDueDays = new Label();
        this.txtDefaultPrepaymentDueDays = new TextBox();
        this.lblDefaultCancellationNoticeDays = new Label();
        this.txtDefaultCancellationNoticeDays = new TextBox();
        this.lblDefaultCancellationFeePercent = new Label();
        this.txtDefaultCancellationFeePercent = new TextBox();
        this.lblCancellationProcessingFee = new Label();
        this.txtCancellationProcessingFee = new TextBox();

        // Peak Period controls
        this.chkHasPeakPeriodPolicy = new CheckBox();
        this.lblPeakPeriodPrepaymentDueDays = new Label();
        this.txtPeakPeriodPrepaymentDueDays = new TextBox();
        this.lblPeakPeriodCancellationNoticeDays = new Label();
        this.txtPeakPeriodCancellationNoticeDays = new TextBox();
        this.lblPeakPeriodCancellationFeePercent = new Label();
        this.txtPeakPeriodCancellationFeePercent = new TextBox();
        this.lblPeakPeriodStart = new Label();
        this.cboPeakPeriodStartMonth = new ComboBox();
        this.txtPeakPeriodStartDay = new TextBox();
        this.lblPeakPeriodEnd = new Label();
        this.cboPeakPeriodEndMonth = new ComboBox();
        this.txtPeakPeriodEndDay = new TextBox();

        // Buttons
        this.btnInsert = new Button();
        this.btnUpdate = new Button();
        this.btnDelete = new Button();
        this.btnCommit = new Button();
        this.btnCancel = new Button();
        this.btnFind = new Button();
        this.btnRefresh = new Button();
        this.btnRoomTypes = new Button();

        // Other controls
        this.lblRecordCount = new Label();
        this.dgvProperties = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
        this.SuspendLayout();

        // === Split Container ===
        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Orientation = Orientation.Horizontal;
        this.splitContainer.Panel1.Controls.Add(this.panelButtons);
        this.splitContainer.Panel1.Controls.Add(this.panelForm);
        this.splitContainer.Panel2.Controls.Add(this.dgvProperties);
        this.splitContainer.Size = new Size(1050, 750);
        this.splitContainer.SplitterDistance = 520;

        // === Panel Form ===
        this.panelForm.Dock = DockStyle.Fill;
        this.panelForm.Padding = new Padding(10);
        this.panelForm.AutoScroll = true;

        // === General Info Group ===
        this.grpGeneralInfo.Text = "General Information";
        this.grpGeneralInfo.Location = new Point(10, 10);
        this.grpGeneralInfo.Size = new Size(300, 200);
        this.panelForm.Controls.Add(this.grpGeneralInfo);

        int y = 22;
        AddLabelAndField(grpGeneralInfo, lblAccountNumber, "Account #:", txtAccountNumber, 10, y, 100, 80);
        txtAccountNumber.ReadOnly = true;
        y += 26;
        AddLabelAndField(grpGeneralInfo, lblLocation, "Property:", txtLocation, 10, y, 100, 180);
        y += 26;
        AddLabelAndField(grpGeneralInfo, lblFullName, "Owner/Mgr:", txtFullName, 10, y, 100, 180);
        y += 26;
        AddLabelAndField(grpGeneralInfo, lblCheckTo, "Check To:", txtCheckTo, 10, y, 100, 180);
        y += 26;
        AddLabelAndField(grpGeneralInfo, lblPercentToHost, "% to Host:", txtPercentToHost, 10, y, 100, 60);
        y += 26;
        AddLabelAndField(grpGeneralInfo, lblGrossRatePercent, "% Gross Rate:", txtGrossRatePercent, 10, y, 100, 60);

        // === Property Address Group ===
        this.grpPropertyAddress.Text = "Property Address";
        this.grpPropertyAddress.Location = new Point(320, 10);
        this.grpPropertyAddress.Size = new Size(280, 200);
        this.panelForm.Controls.Add(this.grpPropertyAddress);

        y = 22;
        AddLabelAndField(grpPropertyAddress, lblPropertyAddress, "Address:", txtPropertyAddress, 10, y, 70, 190);
        y += 26;
        AddLabelAndField(grpPropertyAddress, lblPropertyCity, "City:", txtPropertyCity, 10, y, 70, 190);
        y += 26;
        AddLabelAndField(grpPropertyAddress, lblPropertyState, "State:", txtPropertyState, 10, y, 70, 80);
        AddLabelAndField(grpPropertyAddress, lblPropertyZipCode, "Zip:", txtPropertyZipCode, 155, y, 185, 75);
        y += 26;
        AddLabelAndField(grpPropertyAddress, lblPropertyPhone, "Phone:", txtPropertyPhone, 10, y, 70, 120);
        y += 26;
        AddLabelAndField(grpPropertyAddress, lblPropertyFax, "Fax:", txtPropertyFax, 10, y, 70, 120);

        // === Mailing Address Group ===
        this.grpMailingAddress.Text = "Mailing Address / Contact";
        this.grpMailingAddress.Location = new Point(10, 220);
        this.grpMailingAddress.Size = new Size(300, 290);
        this.panelForm.Controls.Add(this.grpMailingAddress);

        y = 22;
        AddLabelAndField(grpMailingAddress, lblMailingAddress, "Address:", txtMailingAddress, 10, y, 70, 210);
        y += 26;
        AddLabelAndField(grpMailingAddress, lblMailingCity, "City:", txtMailingCity, 10, y, 70, 210);
        y += 26;
        AddLabelAndField(grpMailingAddress, lblMailingState, "State:", txtMailingState, 10, y, 70, 80);
        AddLabelAndField(grpMailingAddress, lblMailingZipCode, "Zip:", txtMailingZipCode, 165, y, 195, 85);
        y += 26;
        AddLabelAndField(grpMailingAddress, lblMailingPhone1, "Phone 1:", txtMailingPhone1, 10, y, 70, 120);
        y += 26;
        AddLabelAndField(grpMailingAddress, lblMailingPhone2, "Phone 2:", txtMailingPhone2, 10, y, 70, 120);
        y += 26;
        AddLabelAndField(grpMailingAddress, lblMailingFax, "Fax:", txtMailingFax, 10, y, 70, 120);
        y += 26;
        AddLabelAndField(grpMailingAddress, lblEmail, "Email:", txtEmail, 10, y, 70, 210);
        y += 26;
        AddLabelAndField(grpMailingAddress, lblWebUrl, "Web URL:", txtWebUrl, 10, y, 70, 210);

        // === Tax Info Group ===
        this.grpTaxInfo.Text = "Tax Information";
        this.grpTaxInfo.Location = new Point(320, 220);
        this.grpTaxInfo.Size = new Size(280, 120);
        this.panelForm.Controls.Add(this.grpTaxInfo);

        y = 22;
        AddLabelAndField(grpTaxInfo, lblFederalTaxId, "Fed Tax ID:", txtFederalTaxId, 10, y, 80, 180);
        y += 26;
        AddLabelAndField(grpTaxInfo, lblDBA, "DBA:", txtDBA, 10, y, 80, 180);
        y += 26;
        lblTaxPlanCode.Text = "Tax Plan:";
        lblTaxPlanCode.Location = new Point(10, y + 3);
        lblTaxPlanCode.AutoSize = true;
        grpTaxInfo.Controls.Add(lblTaxPlanCode);
        cboTaxPlan.Location = new Point(80, y);
        cboTaxPlan.Size = new Size(180, 23);
        cboTaxPlan.DropDownStyle = ComboBoxStyle.DropDownList;
        grpTaxInfo.Controls.Add(cboTaxPlan);
        txtTaxPlanCode.Visible = false; // Hidden, used for binding

        // === Future Percent Group ===
        this.grpFuturePercent.Text = "Future Percentage to Host";
        this.grpFuturePercent.Location = new Point(320, 350);
        this.grpFuturePercent.Size = new Size(280, 85);
        this.panelForm.Controls.Add(this.grpFuturePercent);

        y = 22;
        AddLabelAndField(grpFuturePercent, lblFuturePercent, "Percent:", txtFuturePercent, 10, y, 80, 60);
        y += 28;
        lblFuturePercentDate.Text = "Eff. Date:";
        lblFuturePercentDate.Location = new Point(10, y + 3);
        lblFuturePercentDate.AutoSize = true;
        grpFuturePercent.Controls.Add(lblFuturePercentDate);
        dtpFuturePercentDate.Location = new Point(80, y);
        dtpFuturePercentDate.Size = new Size(130, 23);
        dtpFuturePercentDate.Format = DateTimePickerFormat.Short;
        dtpFuturePercentDate.ShowCheckBox = true;
        grpFuturePercent.Controls.Add(dtpFuturePercentDate);

        // === Options Group ===
        this.grpOptions.Text = "Options";
        this.grpOptions.Location = new Point(610, 10);
        this.grpOptions.Size = new Size(300, 200);
        this.panelForm.Controls.Add(this.grpOptions);

        y = 22;
        chkSuppressFlag.Text = "Suppress mailing labels";
        chkSuppressFlag.Location = new Point(10, y);
        chkSuppressFlag.AutoSize = true;
        grpOptions.Controls.Add(chkSuppressFlag);

        y += 24;
        chkIsObsolete.Text = "Property no longer booked";
        chkIsObsolete.Location = new Point(10, y);
        chkIsObsolete.AutoSize = true;
        grpOptions.Controls.Add(chkIsObsolete);

        y += 28;
        AddLabelAndField(grpOptions, lblDepositRequired, "Deposit:", txtDepositRequired, 10, y, 60, 80);

        y += 28;
        chkExceptions.Text = "Display exceptions warning";
        chkExceptions.Location = new Point(10, y);
        chkExceptions.AutoSize = true;
        grpOptions.Controls.Add(chkExceptions);

        y += 26;
        txtExceptionsDescription.Location = new Point(10, y);
        txtExceptionsDescription.Size = new Size(280, 60);
        txtExceptionsDescription.Multiline = true;
        txtExceptionsDescription.ScrollBars = ScrollBars.Vertical;
        grpOptions.Controls.Add(txtExceptionsDescription);

        // === Comments ===
        lblComments.Text = "Comments:";
        lblComments.Location = new Point(610, 220);
        lblComments.AutoSize = true;
        panelForm.Controls.Add(lblComments);

        txtComments.Location = new Point(610, 238);
        txtComments.Size = new Size(300, 100);
        txtComments.Multiline = true;
        txtComments.ScrollBars = ScrollBars.Vertical;
        panelForm.Controls.Add(txtComments);

        // === Record Count ===
        this.lblRecordCount.Text = "Record 0 of 0";
        this.lblRecordCount.Location = new Point(610, 345);
        this.lblRecordCount.AutoSize = true;
        this.panelForm.Controls.Add(lblRecordCount);

        // === Payment Policy Group ===
        this.grpPaymentPolicy.Text = "Default Payment Policy";
        this.grpPaymentPolicy.Location = new Point(920, 10);
        this.grpPaymentPolicy.Size = new Size(260, 200);
        this.panelForm.Controls.Add(this.grpPaymentPolicy);

        y = 22;
        AddLabelAndField(grpPaymentPolicy, lblDefaultDepositPercent, "Deposit %:", txtDefaultDepositPercent, 10, y, 115, 50);
        y += 26;
        AddLabelAndField(grpPaymentPolicy, lblDefaultDepositDueDays, "Dep Due (days):", txtDefaultDepositDueDays, 10, y, 115, 50);
        y += 26;
        AddLabelAndField(grpPaymentPolicy, lblDefaultPrepaymentDueDays, "Prepay (days):", txtDefaultPrepaymentDueDays, 10, y, 115, 50);
        y += 26;
        AddLabelAndField(grpPaymentPolicy, lblDefaultCancellationNoticeDays, "Cancel (days):", txtDefaultCancellationNoticeDays, 10, y, 115, 50);
        y += 26;
        AddLabelAndField(grpPaymentPolicy, lblDefaultCancellationFeePercent, "Forfeit %:", txtDefaultCancellationFeePercent, 10, y, 115, 50);
        y += 26;
        AddLabelAndField(grpPaymentPolicy, lblCancellationProcessingFee, "Process Fee $:", txtCancellationProcessingFee, 10, y, 115, 60);

        // === Peak Period Group ===
        this.grpPeakPeriod.Text = "Peak Period Override (e.g., Christmas)";
        this.grpPeakPeriod.Location = new Point(920, 220);
        this.grpPeakPeriod.Size = new Size(260, 200);
        this.panelForm.Controls.Add(this.grpPeakPeriod);

        y = 20;
        chkHasPeakPeriodPolicy.Text = "Enable peak period policy";
        chkHasPeakPeriodPolicy.Location = new Point(10, y);
        chkHasPeakPeriodPolicy.AutoSize = true;
        chkHasPeakPeriodPolicy.CheckedChanged += ChkHasPeakPeriodPolicy_CheckedChanged;
        grpPeakPeriod.Controls.Add(chkHasPeakPeriodPolicy);

        y += 24;
        AddLabelAndField(grpPeakPeriod, lblPeakPeriodPrepaymentDueDays, "Prepay (days):", txtPeakPeriodPrepaymentDueDays, 10, y, 110, 50);
        y += 26;
        AddLabelAndField(grpPeakPeriod, lblPeakPeriodCancellationNoticeDays, "Cancel (days):", txtPeakPeriodCancellationNoticeDays, 10, y, 110, 50);
        y += 26;
        AddLabelAndField(grpPeakPeriod, lblPeakPeriodCancellationFeePercent, "Forfeit %:", txtPeakPeriodCancellationFeePercent, 10, y, 110, 50);

        y += 28;
        lblPeakPeriodStart.Text = "Start:";
        lblPeakPeriodStart.Location = new Point(10, y + 3);
        lblPeakPeriodStart.AutoSize = true;
        grpPeakPeriod.Controls.Add(lblPeakPeriodStart);
        cboPeakPeriodStartMonth.Location = new Point(50, y);
        cboPeakPeriodStartMonth.Size = new Size(90, 23);
        cboPeakPeriodStartMonth.DropDownStyle = ComboBoxStyle.DropDownList;
        grpPeakPeriod.Controls.Add(cboPeakPeriodStartMonth);
        txtPeakPeriodStartDay.Location = new Point(145, y);
        txtPeakPeriodStartDay.Size = new Size(35, 23);
        grpPeakPeriod.Controls.Add(txtPeakPeriodStartDay);

        y += 26;
        lblPeakPeriodEnd.Text = "End:";
        lblPeakPeriodEnd.Location = new Point(10, y + 3);
        lblPeakPeriodEnd.AutoSize = true;
        grpPeakPeriod.Controls.Add(lblPeakPeriodEnd);
        cboPeakPeriodEndMonth.Location = new Point(50, y);
        cboPeakPeriodEndMonth.Size = new Size(90, 23);
        cboPeakPeriodEndMonth.DropDownStyle = ComboBoxStyle.DropDownList;
        grpPeakPeriod.Controls.Add(cboPeakPeriodEndMonth);
        txtPeakPeriodEndDay.Location = new Point(145, y);
        txtPeakPeriodEndDay.Size = new Size(35, 23);
        grpPeakPeriod.Controls.Add(txtPeakPeriodEndDay);

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
        AddButton(panelButtons, btnRoomTypes, "R&oom Types", btnY);

        btnInsert.Click += btnInsert_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnCommit.Click += btnCommit_Click;
        btnCancel.Click += btnCancel_Click;
        btnFind.Click += btnFind_Click;
        btnRefresh.Click += btnRefresh_Click;
        btnRoomTypes.Click += btnRoomTypes_Click;

        // === DataGridView ===
        this.dgvProperties.Dock = DockStyle.Fill;
        this.dgvProperties.AllowUserToAddRows = false;
        this.dgvProperties.AllowUserToDeleteRows = false;
        this.dgvProperties.ReadOnly = true;
        this.dgvProperties.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvProperties.MultiSelect = false;
        this.dgvProperties.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProperties.SelectionChanged += dgvProperties_SelectionChanged;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1400, 750);
        this.Controls.Add(this.splitContainer);
        this.Name = "PropertyForm";
        this.Text = "Host Properties";
        this.Load += PropertyForm_Load;
        this.FormClosing += PropertyForm_FormClosing;

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        this.splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
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

    private GroupBox grpGeneralInfo;
    private GroupBox grpPropertyAddress;
    private GroupBox grpMailingAddress;
    private GroupBox grpTaxInfo;
    private GroupBox grpFuturePercent;
    private GroupBox grpOptions;

    // General Info
    private Label lblAccountNumber;
    private Label lblLocation;
    private Label lblFullName;
    private Label lblCheckTo;
    private Label lblPercentToHost;
    private Label lblGrossRatePercent;
    private TextBox txtAccountNumber;
    private TextBox txtLocation;
    private TextBox txtFullName;
    private TextBox txtCheckTo;
    private TextBox txtPercentToHost;
    private TextBox txtGrossRatePercent;

    // Property Address
    private Label lblPropertyAddress;
    private Label lblPropertyCity;
    private Label lblPropertyState;
    private Label lblPropertyZipCode;
    private Label lblPropertyPhone;
    private Label lblPropertyFax;
    private TextBox txtPropertyAddress;
    private TextBox txtPropertyCity;
    private TextBox txtPropertyState;
    private TextBox txtPropertyZipCode;
    private TextBox txtPropertyPhone;
    private TextBox txtPropertyFax;

    // Mailing Address
    private Label lblMailingAddress;
    private Label lblMailingCity;
    private Label lblMailingState;
    private Label lblMailingZipCode;
    private Label lblMailingPhone1;
    private Label lblMailingPhone2;
    private Label lblMailingFax;
    private Label lblEmail;
    private Label lblWebUrl;
    private Label lblComments;
    private TextBox txtMailingAddress;
    private TextBox txtMailingCity;
    private TextBox txtMailingState;
    private TextBox txtMailingZipCode;
    private TextBox txtMailingPhone1;
    private TextBox txtMailingPhone2;
    private TextBox txtMailingFax;
    private TextBox txtEmail;
    private TextBox txtWebUrl;
    private TextBox txtComments;

    // Tax Info
    private Label lblFederalTaxId;
    private Label lblDBA;
    private Label lblTaxPlanCode;
    private TextBox txtFederalTaxId;
    private TextBox txtDBA;
    private TextBox txtTaxPlanCode;
    private ComboBox cboTaxPlan;

    // Future Percent
    private Label lblFuturePercent;
    private Label lblFuturePercentDate;
    private TextBox txtFuturePercent;
    private DateTimePicker dtpFuturePercentDate;

    // Options
    private CheckBox chkSuppressFlag;
    private CheckBox chkIsObsolete;
    private Label lblDepositRequired;
    private TextBox txtDepositRequired;
    private CheckBox chkExceptions;
    private TextBox txtExceptionsDescription;

    // Payment Policy
    private GroupBox grpPaymentPolicy;
    private Label lblDefaultDepositPercent;
    private TextBox txtDefaultDepositPercent;
    private Label lblDefaultDepositDueDays;
    private TextBox txtDefaultDepositDueDays;
    private Label lblDefaultPrepaymentDueDays;
    private TextBox txtDefaultPrepaymentDueDays;
    private Label lblDefaultCancellationNoticeDays;
    private TextBox txtDefaultCancellationNoticeDays;
    private Label lblDefaultCancellationFeePercent;
    private TextBox txtDefaultCancellationFeePercent;
    private Label lblCancellationProcessingFee;
    private TextBox txtCancellationProcessingFee;

    // Peak Period
    private GroupBox grpPeakPeriod;
    private CheckBox chkHasPeakPeriodPolicy;
    private Label lblPeakPeriodPrepaymentDueDays;
    private TextBox txtPeakPeriodPrepaymentDueDays;
    private Label lblPeakPeriodCancellationNoticeDays;
    private TextBox txtPeakPeriodCancellationNoticeDays;
    private Label lblPeakPeriodCancellationFeePercent;
    private TextBox txtPeakPeriodCancellationFeePercent;
    private Label lblPeakPeriodStart;
    private ComboBox cboPeakPeriodStartMonth;
    private TextBox txtPeakPeriodStartDay;
    private Label lblPeakPeriodEnd;
    private ComboBox cboPeakPeriodEndMonth;
    private TextBox txtPeakPeriodEndDay;

    // Buttons
    private Button btnInsert;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnCommit;
    private Button btnCancel;
    private Button btnFind;
    private Button btnRefresh;
    private Button btnRoomTypes;

    // Other
    private Label lblRecordCount;
    private DataGridView dgvProperties;
}
