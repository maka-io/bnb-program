namespace BnB.WinForms.Forms;

partial class BookingListForm
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
        pnlFilter = new Panel();
        lblProperty = new Label();
        cboProperty = new ComboBox();
        lblDateField = new Label();
        cboDateField = new ComboBox();
        lblStartDate = new Label();
        dtpStartDate = new DateTimePicker();
        lblEndDate = new Label();
        dtpEndDate = new DateTimePicker();
        lblStatus = new Label();
        cboStatus = new ComboBox();
        lblSearch = new Label();
        txtSearch = new TextBox();
        btnSearch = new Button();
        dgvBookings = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnExport = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        pnlFilter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // pnlFilter
        //
        pnlFilter.Controls.Add(lblProperty);
        pnlFilter.Controls.Add(cboProperty);
        pnlFilter.Controls.Add(lblDateField);
        pnlFilter.Controls.Add(cboDateField);
        pnlFilter.Controls.Add(lblStartDate);
        pnlFilter.Controls.Add(dtpStartDate);
        pnlFilter.Controls.Add(lblEndDate);
        pnlFilter.Controls.Add(dtpEndDate);
        pnlFilter.Controls.Add(lblStatus);
        pnlFilter.Controls.Add(cboStatus);
        pnlFilter.Controls.Add(lblSearch);
        pnlFilter.Controls.Add(txtSearch);
        pnlFilter.Controls.Add(btnSearch);
        pnlFilter.Dock = DockStyle.Top;
        pnlFilter.Location = new Point(0, 0);
        pnlFilter.Name = "pnlFilter";
        pnlFilter.Padding = new Padding(10);
        pnlFilter.Size = new Size(950, 75);
        //
        // lblProperty
        //
        lblProperty.AutoSize = true;
        lblProperty.Location = new Point(13, 18);
        lblProperty.Name = "lblProperty";
        lblProperty.Size = new Size(55, 15);
        lblProperty.Text = "Property:";
        //
        // cboProperty
        //
        cboProperty.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProperty.Location = new Point(75, 15);
        cboProperty.Name = "cboProperty";
        cboProperty.Size = new Size(180, 23);
        cboProperty.TabIndex = 0;
        //
        // lblDateField
        //
        lblDateField.AutoSize = true;
        lblDateField.Location = new Point(270, 18);
        lblDateField.Name = "lblDateField";
        lblDateField.Size = new Size(64, 15);
        lblDateField.Text = "Date Field:";
        //
        // cboDateField
        //
        cboDateField.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDateField.Location = new Point(340, 15);
        cboDateField.Name = "cboDateField";
        cboDateField.Size = new Size(110, 23);
        cboDateField.TabIndex = 1;
        //
        // lblStartDate
        //
        lblStartDate.AutoSize = true;
        lblStartDate.Location = new Point(13, 48);
        lblStartDate.Name = "lblStartDate";
        lblStartDate.Size = new Size(35, 15);
        lblStartDate.Text = "From:";
        //
        // dtpStartDate
        //
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(55, 45);
        dtpStartDate.Name = "dtpStartDate";
        dtpStartDate.Size = new Size(100, 23);
        dtpStartDate.TabIndex = 2;
        //
        // lblEndDate
        //
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(165, 48);
        lblEndDate.Name = "lblEndDate";
        lblEndDate.Size = new Size(22, 15);
        lblEndDate.Text = "To:";
        //
        // dtpEndDate
        //
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(195, 45);
        dtpEndDate.Name = "dtpEndDate";
        dtpEndDate.Size = new Size(100, 23);
        dtpEndDate.TabIndex = 3;
        //
        // lblStatus
        //
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(310, 48);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(42, 15);
        lblStatus.Text = "Status:";
        //
        // cboStatus
        //
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboStatus.Location = new Point(360, 45);
        cboStatus.Name = "cboStatus";
        cboStatus.Size = new Size(90, 23);
        cboStatus.TabIndex = 4;
        //
        // lblSearch
        //
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(470, 18);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(45, 15);
        lblSearch.Text = "Search:";
        //
        // txtSearch
        //
        txtSearch.Location = new Point(520, 15);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(150, 23);
        txtSearch.TabIndex = 5;
        //
        // btnSearch
        //
        btnSearch.Location = new Point(520, 43);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(80, 27);
        btnSearch.TabIndex = 6;
        btnSearch.Text = "&Search";
        btnSearch.Click += btnSearch_Click;
        //
        // dgvBookings
        //
        dgvBookings.AllowUserToAddRows = false;
        dgvBookings.AllowUserToDeleteRows = false;
        dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvBookings.Dock = DockStyle.Fill;
        dgvBookings.Location = new Point(0, 75);
        dgvBookings.MultiSelect = false;
        dgvBookings.Name = "dgvBookings";
        dgvBookings.ReadOnly = true;
        dgvBookings.RowHeadersWidth = 25;
        dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBookings.Size = new Size(950, 425);
        dgvBookings.TabIndex = 7;
        dgvBookings.CellDoubleClick += dgvBookings_CellDoubleClick;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnExport);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 500);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new Size(950, 50);
        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(13, 18);
        lblSummary.Name = "lblSummary";
        lblSummary.Size = new Size(208, 15);
        lblSummary.Text = "Use Search to load booking listings";
        //
        // btnExport
        //
        btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnExport.Location = new Point(700, 12);
        btnExport.Name = "btnExport";
        btnExport.Size = new Size(75, 28);
        btnExport.TabIndex = 8;
        btnExport.Text = "&Export";
        btnExport.Click += btnExport_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(782, 12);
        btnPrint.Name = "btnPrint";
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 9;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(864, 12);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 10;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // BookingListForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(950, 550);
        Controls.Add(dgvBookings);
        Controls.Add(pnlFilter);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(800, 500);
        Name = "BookingListForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Booking Listings";
        Load += BookingListForm_Load;
        pnlFilter.ResumeLayout(false);
        pnlFilter.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlFilter;
    private Label lblProperty;
    private ComboBox cboProperty;
    private Label lblDateField;
    private ComboBox cboDateField;
    private Label lblStartDate;
    private DateTimePicker dtpStartDate;
    private Label lblEndDate;
    private DateTimePicker dtpEndDate;
    private Label lblStatus;
    private ComboBox cboStatus;
    private Label lblSearch;
    private TextBox txtSearch;
    private Button btnSearch;
    private DataGridView dgvBookings;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnExport;
    private Button btnPrint;
    private Button btnClose;
}
