namespace BnB.WinForms.Forms;

partial class CheckLedgerReportForm
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
        grpCategory = new GroupBox();
        radHost = new RadioButton();
        radTravel = new RadioButton();
        radMisc = new RadioButton();
        radAll = new RadioButton();
        grpDateRange = new GroupBox();
        lblStartDate = new Label();
        dtpStartDate = new DateTimePicker();
        chkHasEndDate = new CheckBox();
        dtpEndDate = new DateTimePicker();
        chkDisplayOnly = new CheckBox();
        chkSaveSettings = new CheckBox();
        btnExit = new Button();
        btnPrinterSetup = new Button();
        btnPrint = new Button();
        grpCategory.SuspendLayout();
        grpDateRange.SuspendLayout();
        SuspendLayout();
        //
        // grpCategory
        //
        grpCategory.Controls.Add(radHost);
        grpCategory.Controls.Add(radTravel);
        grpCategory.Controls.Add(radMisc);
        grpCategory.Controls.Add(radAll);
        grpCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpCategory.Location = new Point(12, 12);
        grpCategory.Name = "grpCategory";
        grpCategory.Size = new Size(180, 130);
        grpCategory.TabIndex = 0;
        grpCategory.TabStop = false;
        grpCategory.Text = "Check Category";
        //
        // radHost
        //
        radHost.AutoSize = true;
        radHost.Font = new Font("Segoe UI", 9F);
        radHost.Location = new Point(15, 25);
        radHost.Name = "radHost";
        radHost.Size = new Size(50, 19);
        radHost.TabIndex = 0;
        radHost.Text = "Host";
        radHost.UseVisualStyleBackColor = true;
        //
        // radTravel
        //
        radTravel.AutoSize = true;
        radTravel.Font = new Font("Segoe UI", 9F);
        radTravel.Location = new Point(15, 50);
        radTravel.Name = "radTravel";
        radTravel.Size = new Size(55, 19);
        radTravel.TabIndex = 1;
        radTravel.Text = "Travel";
        radTravel.UseVisualStyleBackColor = true;
        //
        // radMisc
        //
        radMisc.AutoSize = true;
        radMisc.Font = new Font("Segoe UI", 9F);
        radMisc.Location = new Point(15, 75);
        radMisc.Name = "radMisc";
        radMisc.Size = new Size(95, 19);
        radMisc.TabIndex = 2;
        radMisc.Text = "Miscellaneous";
        radMisc.UseVisualStyleBackColor = true;
        //
        // radAll
        //
        radAll.AutoSize = true;
        radAll.Font = new Font("Segoe UI", 9F);
        radAll.Location = new Point(15, 100);
        radAll.Name = "radAll";
        radAll.Size = new Size(39, 19);
        radAll.TabIndex = 3;
        radAll.Text = "All";
        radAll.UseVisualStyleBackColor = true;
        //
        // grpDateRange
        //
        grpDateRange.Controls.Add(lblStartDate);
        grpDateRange.Controls.Add(dtpStartDate);
        grpDateRange.Controls.Add(chkHasEndDate);
        grpDateRange.Controls.Add(dtpEndDate);
        grpDateRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpDateRange.Location = new Point(198, 12);
        grpDateRange.Name = "grpDateRange";
        grpDateRange.Size = new Size(260, 80);
        grpDateRange.TabIndex = 1;
        grpDateRange.TabStop = false;
        grpDateRange.Text = "Check Print Date Range";
        //
        // lblStartDate
        //
        lblStartDate.AutoSize = true;
        lblStartDate.Font = new Font("Segoe UI", 9F);
        lblStartDate.Location = new Point(10, 28);
        lblStartDate.Name = "lblStartDate";
        lblStartDate.Size = new Size(62, 15);
        lblStartDate.TabIndex = 0;
        lblStartDate.Text = "Start Date:";
        //
        // dtpStartDate
        //
        dtpStartDate.Font = new Font("Segoe UI", 9F);
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(78, 25);
        dtpStartDate.Name = "dtpStartDate";
        dtpStartDate.Size = new Size(100, 23);
        dtpStartDate.TabIndex = 1;
        //
        // chkHasEndDate
        //
        chkHasEndDate.AutoSize = true;
        chkHasEndDate.Font = new Font("Segoe UI", 9F);
        chkHasEndDate.Location = new Point(10, 53);
        chkHasEndDate.Name = "chkHasEndDate";
        chkHasEndDate.Size = new Size(68, 19);
        chkHasEndDate.TabIndex = 2;
        chkHasEndDate.Text = "through:";
        chkHasEndDate.UseVisualStyleBackColor = true;
        chkHasEndDate.CheckedChanged += chkHasEndDate_CheckedChanged;
        //
        // dtpEndDate
        //
        dtpEndDate.Enabled = false;
        dtpEndDate.Font = new Font("Segoe UI", 9F);
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(78, 50);
        dtpEndDate.Name = "dtpEndDate";
        dtpEndDate.Size = new Size(100, 23);
        dtpEndDate.TabIndex = 3;
        //
        // chkDisplayOnly
        //
        chkDisplayOnly.AutoSize = true;
        chkDisplayOnly.Location = new Point(198, 98);
        chkDisplayOnly.Name = "chkDisplayOnly";
        chkDisplayOnly.Size = new Size(167, 19);
        chkDisplayOnly.TabIndex = 2;
        chkDisplayOnly.Text = "Display report to screen only";
        chkDisplayOnly.UseVisualStyleBackColor = true;
        //
        // chkSaveSettings
        //
        chkSaveSettings.AutoSize = true;
        chkSaveSettings.Location = new Point(198, 123);
        chkSaveSettings.Name = "chkSaveSettings";
        chkSaveSettings.Size = new Size(127, 19);
        chkSaveSettings.TabIndex = 3;
        chkSaveSettings.Text = "&Save settings on Exit";
        chkSaveSettings.UseVisualStyleBackColor = true;
        //
        // btnExit
        //
        btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnExit.Location = new Point(198, 148);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(85, 28);
        btnExit.TabIndex = 4;
        btnExit.Text = "E&xit";
        btnExit.UseVisualStyleBackColor = true;
        btnExit.Click += btnExit_Click;
        //
        // btnPrinterSetup
        //
        btnPrinterSetup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnPrinterSetup.Location = new Point(289, 148);
        btnPrinterSetup.Name = "btnPrinterSetup";
        btnPrinterSetup.Size = new Size(85, 28);
        btnPrinterSetup.TabIndex = 5;
        btnPrinterSetup.Text = "P&rinter Setup";
        btnPrinterSetup.UseVisualStyleBackColor = true;
        btnPrinterSetup.Click += btnPrinterSetup_Click;
        //
        // btnPrint
        //
        btnPrint.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnPrint.Location = new Point(380, 148);
        btnPrint.Name = "btnPrint";
        btnPrint.Size = new Size(85, 28);
        btnPrint.TabIndex = 6;
        btnPrint.Text = "&Print";
        btnPrint.UseVisualStyleBackColor = true;
        btnPrint.Click += btnPrint_Click;
        //
        // CheckLedgerReportForm
        //
        AcceptButton = btnPrint;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(477, 188);
        Controls.Add(btnPrint);
        Controls.Add(btnPrinterSetup);
        Controls.Add(btnExit);
        Controls.Add(chkSaveSettings);
        Controls.Add(chkDisplayOnly);
        Controls.Add(grpDateRange);
        Controls.Add(grpCategory);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CheckLedgerReportForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Check Ledger Summary Report Dialog Box";
        Load += CheckLedgerReportForm_Load;
        grpCategory.ResumeLayout(false);
        grpCategory.PerformLayout();
        grpDateRange.ResumeLayout(false);
        grpDateRange.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox grpCategory;
    private RadioButton radHost;
    private RadioButton radTravel;
    private RadioButton radMisc;
    private RadioButton radAll;
    private GroupBox grpDateRange;
    private Label lblStartDate;
    private DateTimePicker dtpStartDate;
    private CheckBox chkHasEndDate;
    private DateTimePicker dtpEndDate;
    private CheckBox chkDisplayOnly;
    private CheckBox chkSaveSettings;
    private Button btnExit;
    private Button btnPrinterSetup;
    private Button btnPrint;
}
