namespace BnB.WinForms.Forms;

partial class TrendsDialogForm
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
        grpShow = new GroupBox();
        optRoomNights = new RadioButton();
        optServiceFee = new RadioButton();
        optResFee = new RadioButton();
        optBookings = new RadioButton();
        grpBy = new GroupBox();
        optProperty = new RadioButton();
        optMonth = new RadioButton();
        optYear = new RadioButton();
        lblProperty = new Label();
        cboProperty = new ComboBox();
        lblStartDate = new Label();
        dtpStartDate = new DateTimePicker();
        lblEndDate = new Label();
        dtpEndDate = new DateTimePicker();
        lblFrequency = new Label();
        txtFrequency = new TextBox();
        hsbFrequency = new HScrollBar();
        lblThreshold = new Label();
        txtThreshold = new TextBox();
        hsbThreshold = new HScrollBar();
        chkSaveSettings = new CheckBox();
        btnCancel = new Button();
        btnOK = new Button();
        grpShow.SuspendLayout();
        grpBy.SuspendLayout();
        SuspendLayout();
        //
        // grpShow
        //
        grpShow.Controls.Add(optRoomNights);
        grpShow.Controls.Add(optServiceFee);
        grpShow.Controls.Add(optResFee);
        grpShow.Controls.Add(optBookings);
        grpShow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpShow.Location = new Point(12, 12);
        grpShow.Name = "grpShow";
        grpShow.Size = new Size(130, 135);
        grpShow.TabIndex = 0;
        grpShow.TabStop = false;
        grpShow.Text = "Show";
        //
        // optRoomNights
        //
        optRoomNights.AutoSize = true;
        optRoomNights.Font = new Font("Segoe UI", 9F);
        optRoomNights.Location = new Point(10, 25);
        optRoomNights.Name = "optRoomNights";
        optRoomNights.Size = new Size(95, 19);
        optRoomNights.TabIndex = 0;
        optRoomNights.Text = "Room Nights";
        optRoomNights.UseVisualStyleBackColor = true;
        optRoomNights.CheckedChanged += optRoomNights_CheckedChanged;
        //
        // optServiceFee
        //
        optServiceFee.AutoSize = true;
        optServiceFee.Font = new Font("Segoe UI", 9F);
        optServiceFee.Location = new Point(10, 50);
        optServiceFee.Name = "optServiceFee";
        optServiceFee.Size = new Size(83, 19);
        optServiceFee.TabIndex = 1;
        optServiceFee.Text = "Service Fee";
        optServiceFee.UseVisualStyleBackColor = true;
        optServiceFee.CheckedChanged += optServiceFee_CheckedChanged;
        //
        // optResFee
        //
        optResFee.AutoSize = true;
        optResFee.Font = new Font("Segoe UI", 9F);
        optResFee.Location = new Point(10, 75);
        optResFee.Name = "optResFee";
        optResFee.Size = new Size(108, 19);
        optResFee.TabIndex = 2;
        optResFee.Text = "Reservation Fee";
        optResFee.UseVisualStyleBackColor = true;
        optResFee.CheckedChanged += optBookings_CheckedChanged;
        //
        // optBookings
        //
        optBookings.AutoSize = true;
        optBookings.Font = new Font("Segoe UI", 9F);
        optBookings.Location = new Point(10, 100);
        optBookings.Name = "optBookings";
        optBookings.Size = new Size(74, 19);
        optBookings.TabIndex = 3;
        optBookings.Text = "Bookings";
        optBookings.UseVisualStyleBackColor = true;
        optBookings.CheckedChanged += optBookings_CheckedChanged;
        //
        // grpBy
        //
        grpBy.Controls.Add(optProperty);
        grpBy.Controls.Add(optMonth);
        grpBy.Controls.Add(optYear);
        grpBy.Controls.Add(lblProperty);
        grpBy.Controls.Add(cboProperty);
        grpBy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpBy.Location = new Point(148, 12);
        grpBy.Name = "grpBy";
        grpBy.Size = new Size(180, 135);
        grpBy.TabIndex = 1;
        grpBy.TabStop = false;
        grpBy.Text = "By";
        //
        // optProperty
        //
        optProperty.AutoSize = true;
        optProperty.Font = new Font("Segoe UI", 9F);
        optProperty.Location = new Point(10, 25);
        optProperty.Name = "optProperty";
        optProperty.Size = new Size(105, 19);
        optProperty.TabIndex = 0;
        optProperty.Text = "Property Name";
        optProperty.UseVisualStyleBackColor = true;
        optProperty.CheckedChanged += optProperty_CheckedChanged;
        //
        // optMonth
        //
        optMonth.AutoSize = true;
        optMonth.Font = new Font("Segoe UI", 9F);
        optMonth.Location = new Point(10, 50);
        optMonth.Name = "optMonth";
        optMonth.Size = new Size(61, 19);
        optMonth.TabIndex = 1;
        optMonth.Text = "Month";
        optMonth.UseVisualStyleBackColor = true;
        //
        // optYear
        //
        optYear.AutoSize = true;
        optYear.Font = new Font("Segoe UI", 9F);
        optYear.Location = new Point(10, 75);
        optYear.Name = "optYear";
        optYear.Size = new Size(46, 19);
        optYear.TabIndex = 2;
        optYear.Text = "Year";
        optYear.UseVisualStyleBackColor = true;
        //
        // lblProperty
        //
        lblProperty.AutoSize = true;
        lblProperty.Font = new Font("Segoe UI", 9F);
        lblProperty.Location = new Point(10, 100);
        lblProperty.Name = "lblProperty";
        lblProperty.Size = new Size(55, 15);
        lblProperty.TabIndex = 3;
        lblProperty.Text = "Property:";
        //
        // cboProperty
        //
        cboProperty.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProperty.Font = new Font("Segoe UI", 9F);
        cboProperty.FormattingEnabled = true;
        cboProperty.Location = new Point(70, 97);
        cboProperty.Name = "cboProperty";
        cboProperty.Size = new Size(100, 23);
        cboProperty.TabIndex = 4;
        //
        // lblStartDate
        //
        lblStartDate.AutoSize = true;
        lblStartDate.Location = new Point(334, 15);
        lblStartDate.Name = "lblStartDate";
        lblStartDate.Size = new Size(76, 15);
        lblStartDate.TabIndex = 2;
        lblStartDate.Text = "Starting Date:";
        //
        // dtpStartDate
        //
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(416, 12);
        dtpStartDate.Name = "dtpStartDate";
        dtpStartDate.Size = new Size(110, 23);
        dtpStartDate.TabIndex = 3;
        //
        // lblEndDate
        //
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(334, 44);
        lblEndDate.Name = "lblEndDate";
        lblEndDate.Size = new Size(74, 15);
        lblEndDate.TabIndex = 4;
        lblEndDate.Text = "Ending Date:";
        //
        // dtpEndDate
        //
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(416, 41);
        dtpEndDate.Name = "dtpEndDate";
        dtpEndDate.Size = new Size(110, 23);
        dtpEndDate.TabIndex = 5;
        //
        // lblFrequency
        //
        lblFrequency.AutoSize = true;
        lblFrequency.Location = new Point(334, 73);
        lblFrequency.Name = "lblFrequency";
        lblFrequency.Size = new Size(65, 15);
        lblFrequency.TabIndex = 6;
        lblFrequency.Text = "Frequency:";
        //
        // txtFrequency
        //
        txtFrequency.Location = new Point(416, 70);
        txtFrequency.Name = "txtFrequency";
        txtFrequency.Size = new Size(40, 23);
        txtFrequency.TabIndex = 7;
        txtFrequency.Leave += txtFrequency_Leave;
        //
        // hsbFrequency
        //
        hsbFrequency.LargeChange = 5;
        hsbFrequency.Location = new Point(462, 70);
        hsbFrequency.Maximum = 5000;
        hsbFrequency.Minimum = 1;
        hsbFrequency.Name = "hsbFrequency";
        hsbFrequency.Size = new Size(80, 20);
        hsbFrequency.TabIndex = 8;
        hsbFrequency.Value = 1;
        hsbFrequency.Scroll += hsbFrequency_Scroll;
        //
        // lblThreshold
        //
        lblThreshold.AutoSize = true;
        lblThreshold.Location = new Point(334, 102);
        lblThreshold.Name = "lblThreshold";
        lblThreshold.Size = new Size(62, 15);
        lblThreshold.TabIndex = 9;
        lblThreshold.Text = "Threshold:";
        //
        // txtThreshold
        //
        txtThreshold.Location = new Point(416, 99);
        txtThreshold.Name = "txtThreshold";
        txtThreshold.Size = new Size(40, 23);
        txtThreshold.TabIndex = 10;
        txtThreshold.Leave += txtThreshold_Leave;
        //
        // hsbThreshold
        //
        hsbThreshold.LargeChange = 5;
        hsbThreshold.Location = new Point(462, 99);
        hsbThreshold.Maximum = 200;
        hsbThreshold.Minimum = 1;
        hsbThreshold.Name = "hsbThreshold";
        hsbThreshold.Size = new Size(80, 20);
        hsbThreshold.TabIndex = 11;
        hsbThreshold.Value = 10;
        hsbThreshold.Scroll += hsbThreshold_Scroll;
        //
        // chkSaveSettings
        //
        chkSaveSettings.AutoSize = true;
        chkSaveSettings.Location = new Point(334, 128);
        chkSaveSettings.Name = "chkSaveSettings";
        chkSaveSettings.Size = new Size(134, 19);
        chkSaveSettings.TabIndex = 12;
        chkSaveSettings.Text = "&Save settings on Exit";
        chkSaveSettings.UseVisualStyleBackColor = true;
        //
        // btnCancel
        //
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.Location = new Point(345, 155);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 28);
        btnCancel.TabIndex = 13;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // btnOK
        //
        btnOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnOK.Location = new Point(441, 155);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(90, 28);
        btnOK.TabIndex = 14;
        btnOK.Text = "&OK";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        //
        // TrendsDialogForm
        //
        AcceptButton = btnOK;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(555, 195);
        Controls.Add(btnOK);
        Controls.Add(btnCancel);
        Controls.Add(chkSaveSettings);
        Controls.Add(hsbThreshold);
        Controls.Add(txtThreshold);
        Controls.Add(lblThreshold);
        Controls.Add(hsbFrequency);
        Controls.Add(txtFrequency);
        Controls.Add(lblFrequency);
        Controls.Add(dtpEndDate);
        Controls.Add(lblEndDate);
        Controls.Add(dtpStartDate);
        Controls.Add(lblStartDate);
        Controls.Add(grpBy);
        Controls.Add(grpShow);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "TrendsDialogForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Trends Dialog Box";
        Load += TrendsDialogForm_Load;
        grpShow.ResumeLayout(false);
        grpShow.PerformLayout();
        grpBy.ResumeLayout(false);
        grpBy.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox grpShow;
    private RadioButton optRoomNights;
    private RadioButton optServiceFee;
    private RadioButton optResFee;
    private RadioButton optBookings;
    private GroupBox grpBy;
    private RadioButton optProperty;
    private RadioButton optMonth;
    private RadioButton optYear;
    private Label lblProperty;
    private ComboBox cboProperty;
    private Label lblStartDate;
    private DateTimePicker dtpStartDate;
    private Label lblEndDate;
    private DateTimePicker dtpEndDate;
    private Label lblFrequency;
    private TextBox txtFrequency;
    private HScrollBar hsbFrequency;
    private Label lblThreshold;
    private TextBox txtThreshold;
    private HScrollBar hsbThreshold;
    private CheckBox chkSaveSettings;
    private Button btnCancel;
    private Button btnOK;
}
