namespace BnB.WinForms.Forms;

partial class BookingListForm
{
    private System.ComponentModel.IContainer? components = null;

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
        btnReset = new Button();
        pnlGrid = new Panel();
        dgvBookings = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnPrintConfirmation = new Button();
        btnExport = new Button();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();

        pnlFilter.SuspendLayout();
        pnlGrid.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();

        //
        // pnlFilter - Docked to top
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
        pnlFilter.Controls.Add(btnReset);
        pnlFilter.Dock = DockStyle.Top;
        pnlFilter.Location = new Point(0, 0);
        pnlFilter.Padding = new Padding(10);
        pnlFilter.Size = new Size(950, 80);

        //
        // lblProperty
        //
        lblProperty.AutoSize = true;
        lblProperty.Location = new Point(13, 18);
        lblProperty.Text = "Property:";

        //
        // cboProperty
        //
        cboProperty.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProperty.Location = new Point(75, 15);
        cboProperty.Size = new Size(180, 23);
        cboProperty.TabIndex = 0;

        //
        // lblDateField
        //
        lblDateField.AutoSize = true;
        lblDateField.Location = new Point(270, 18);
        lblDateField.Text = "Date Field:";

        //
        // cboDateField
        //
        cboDateField.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDateField.Location = new Point(340, 15);
        cboDateField.Size = new Size(110, 23);
        cboDateField.TabIndex = 1;

        //
        // lblStartDate
        //
        lblStartDate.AutoSize = true;
        lblStartDate.Location = new Point(13, 50);
        lblStartDate.Text = "From:";

        //
        // dtpStartDate
        //
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(55, 47);
        dtpStartDate.Size = new Size(100, 23);
        dtpStartDate.TabIndex = 2;

        //
        // lblEndDate
        //
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(165, 50);
        lblEndDate.Text = "To:";

        //
        // dtpEndDate
        //
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(195, 47);
        dtpEndDate.Size = new Size(100, 23);
        dtpEndDate.TabIndex = 3;

        //
        // lblStatus
        //
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(310, 50);
        lblStatus.Text = "Status:";

        //
        // cboStatus
        //
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboStatus.Location = new Point(360, 47);
        cboStatus.Size = new Size(90, 23);
        cboStatus.TabIndex = 4;

        //
        // lblSearch
        //
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(470, 18);
        lblSearch.Text = "Search:";

        //
        // txtSearch
        //
        txtSearch.Location = new Point(520, 15);
        txtSearch.Size = new Size(150, 23);
        txtSearch.TabIndex = 5;

        //
        // btnSearch
        //
        btnSearch.Location = new Point(520, 45);
        btnSearch.Size = new Size(80, 27);
        btnSearch.TabIndex = 6;
        btnSearch.Text = "&Search";
        btnSearch.Click += btnSearch_Click;

        //
        // btnReset
        //
        btnReset.Location = new Point(605, 45);
        btnReset.Size = new Size(65, 27);
        btnReset.TabIndex = 7;
        btnReset.Text = "&Reset";
        btnReset.Click += btnReset_Click;

        //
        // pnlBottom - Docked to bottom
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnPrintConfirmation);
        pnlBottom.Controls.Add(btnExport);
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 500);
        pnlBottom.Size = new Size(950, 50);

        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(13, 18);
        lblSummary.Text = "Use Search to load booking listings";

        //
        // btnPrintConfirmation
        //
        btnPrintConfirmation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrintConfirmation.Location = new Point(483, 12);
        btnPrintConfirmation.Size = new Size(125, 28);
        btnPrintConfirmation.TabIndex = 8;
        btnPrintConfirmation.Text = "Print &Confirmation";
        btnPrintConfirmation.Click += btnPrintConfirmation_Click;

        //
        // btnExport
        //
        btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnExport.Location = new Point(618, 12);
        btnExport.Size = new Size(75, 28);
        btnExport.TabIndex = 9;
        btnExport.Text = "&Export";
        btnExport.Click += btnExport_Click;

        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(699, 12);
        btnPreview.Size = new Size(75, 28);
        btnPreview.TabIndex = 10;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;

        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(780, 12);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 11;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;

        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(861, 12);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 12;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;

        //
        // pnlGrid - Container for datagrid with top padding
        //
        pnlGrid.Controls.Add(dgvBookings);
        pnlGrid.Dock = DockStyle.Fill;
        pnlGrid.Padding = new Padding(0, 10, 0, 0);

        //
        // dgvBookings - Docked to fill the container panel
        //
        dgvBookings.AllowUserToAddRows = false;
        dgvBookings.AllowUserToDeleteRows = false;
        dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvBookings.BackgroundColor = SystemColors.Window;
        dgvBookings.BorderStyle = BorderStyle.Fixed3D;
        dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvBookings.Dock = DockStyle.Fill;
        dgvBookings.MultiSelect = false;
        dgvBookings.ReadOnly = true;
        dgvBookings.RowHeadersVisible = false;
        dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvBookings.TabIndex = 7;
        dgvBookings.CellDoubleClick += dgvBookings_CellDoubleClick;

        //
        // BookingListForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(950, 550);
        Controls.Add(pnlGrid);
        Controls.Add(pnlBottom);
        Controls.Add(pnlFilter);
        MinimumSize = new Size(800, 500);
        Name = "BookingListForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Booking Listings";
        Load += BookingListForm_Load;

        pnlFilter.ResumeLayout(false);
        pnlFilter.PerformLayout();
        pnlGrid.ResumeLayout(false);
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
    private Button btnReset;
    private Panel pnlGrid;
    private DataGridView dgvBookings;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnPrintConfirmation;
    private Button btnExport;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
