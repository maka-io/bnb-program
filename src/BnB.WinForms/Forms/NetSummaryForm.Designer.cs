namespace BnB.WinForms.Forms;

partial class NetSummaryForm
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
        pnlTop = new Panel();
        lblStartDate = new Label();
        dtpStartDate = new DateTimePicker();
        lblEndDate = new Label();
        dtpEndDate = new DateTimePicker();
        btnRefresh = new Button();
        dgvSummary = new DataGridView();
        grpTotals = new GroupBox();
        lblTotalBookings = new Label();
        txtTotalBookings = new TextBox();
        lblTotalNights = new Label();
        txtTotalNights = new TextBox();
        lblTotalGross = new Label();
        txtTotalGross = new TextBox();
        lblTotalCommission = new Label();
        txtTotalCommission = new TextBox();
        lblTotalNet = new Label();
        txtTotalNet = new TextBox();
        pnlBottom = new Panel();
        btnExport = new Button();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvSummary).BeginInit();
        grpTotals.SuspendLayout();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // pnlTop
        //
        pnlTop.Controls.Add(lblStartDate);
        pnlTop.Controls.Add(dtpStartDate);
        pnlTop.Controls.Add(lblEndDate);
        pnlTop.Controls.Add(dtpEndDate);
        pnlTop.Controls.Add(btnRefresh);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Size = new Size(750, 45);
        //
        // lblStartDate
        //
        lblStartDate.AutoSize = true;
        lblStartDate.Location = new Point(12, 15);
        lblStartDate.Text = "From:";
        //
        // dtpStartDate
        //
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(55, 12);
        dtpStartDate.Size = new Size(100, 23);
        //
        // lblEndDate
        //
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(170, 15);
        lblEndDate.Text = "To:";
        //
        // dtpEndDate
        //
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(195, 12);
        dtpEndDate.Size = new Size(100, 23);
        //
        // btnRefresh
        //
        btnRefresh.Location = new Point(310, 10);
        btnRefresh.Size = new Size(80, 27);
        btnRefresh.Text = "&Refresh";
        btnRefresh.Click += btnRefresh_Click;
        //
        // dgvSummary
        //
        dgvSummary.AllowUserToAddRows = false;
        dgvSummary.AllowUserToDeleteRows = false;
        dgvSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvSummary.Dock = DockStyle.Fill;
        dgvSummary.Location = new Point(0, 45);
        dgvSummary.MultiSelect = false;
        dgvSummary.ReadOnly = true;
        dgvSummary.RowHeadersWidth = 25;
        dgvSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvSummary.Size = new Size(750, 305);
        dgvSummary.TabIndex = 0;
        //
        // grpTotals
        //
        grpTotals.Controls.Add(lblTotalBookings);
        grpTotals.Controls.Add(txtTotalBookings);
        grpTotals.Controls.Add(lblTotalNights);
        grpTotals.Controls.Add(txtTotalNights);
        grpTotals.Controls.Add(lblTotalGross);
        grpTotals.Controls.Add(txtTotalGross);
        grpTotals.Controls.Add(lblTotalCommission);
        grpTotals.Controls.Add(txtTotalCommission);
        grpTotals.Controls.Add(lblTotalNet);
        grpTotals.Controls.Add(txtTotalNet);
        grpTotals.Dock = DockStyle.Bottom;
        grpTotals.Location = new Point(0, 350);
        grpTotals.Size = new Size(750, 60);
        grpTotals.TabStop = false;
        grpTotals.Text = "Totals";
        //
        // lblTotalBookings
        //
        lblTotalBookings.AutoSize = true;
        lblTotalBookings.Location = new Point(12, 27);
        lblTotalBookings.Text = "Bookings:";
        //
        // txtTotalBookings
        //
        txtTotalBookings.Location = new Point(75, 24);
        txtTotalBookings.ReadOnly = true;
        txtTotalBookings.Size = new Size(60, 23);
        txtTotalBookings.TextAlign = HorizontalAlignment.Right;
        //
        // lblTotalNights
        //
        lblTotalNights.AutoSize = true;
        lblTotalNights.Location = new Point(150, 27);
        lblTotalNights.Text = "Nights:";
        //
        // txtTotalNights
        //
        txtTotalNights.Location = new Point(200, 24);
        txtTotalNights.ReadOnly = true;
        txtTotalNights.Size = new Size(60, 23);
        txtTotalNights.TextAlign = HorizontalAlignment.Right;
        //
        // lblTotalGross
        //
        lblTotalGross.AutoSize = true;
        lblTotalGross.Location = new Point(280, 27);
        lblTotalGross.Text = "Gross:";
        //
        // txtTotalGross
        //
        txtTotalGross.Location = new Point(325, 24);
        txtTotalGross.ReadOnly = true;
        txtTotalGross.Size = new Size(90, 23);
        txtTotalGross.TextAlign = HorizontalAlignment.Right;
        //
        // lblTotalCommission
        //
        lblTotalCommission.AutoSize = true;
        lblTotalCommission.Location = new Point(430, 27);
        lblTotalCommission.Text = "Comm:";
        //
        // txtTotalCommission
        //
        txtTotalCommission.Location = new Point(475, 24);
        txtTotalCommission.ReadOnly = true;
        txtTotalCommission.Size = new Size(90, 23);
        txtTotalCommission.TextAlign = HorizontalAlignment.Right;
        //
        // lblTotalNet
        //
        lblTotalNet.AutoSize = true;
        lblTotalNet.Location = new Point(580, 27);
        lblTotalNet.Text = "Net:";
        //
        // txtTotalNet
        //
        txtTotalNet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        txtTotalNet.Location = new Point(610, 24);
        txtTotalNet.ReadOnly = true;
        txtTotalNet.Size = new Size(100, 23);
        txtTotalNet.TextAlign = HorizontalAlignment.Right;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(btnExport);
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 410);
        pnlBottom.Size = new Size(750, 40);
        //
        // btnExport
        //
        btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnExport.Location = new Point(428, 7);
        btnExport.Size = new Size(75, 28);
        btnExport.TabIndex = 1;
        btnExport.Text = "&Export";
        btnExport.Click += btnExport_Click;
        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(509, 7);
        btnPreview.Size = new Size(75, 28);
        btnPreview.TabIndex = 2;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(590, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 3;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(671, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 4;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // NetSummaryForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(750, 450);
        Controls.Add(dgvSummary);
        Controls.Add(pnlTop);
        Controls.Add(grpTotals);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(650, 400);
        Name = "NetSummaryForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Net Summary by Property";
        Load += NetSummaryForm_Load;
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvSummary).EndInit();
        grpTotals.ResumeLayout(false);
        grpTotals.PerformLayout();
        pnlBottom.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTop;
    private Label lblStartDate;
    private DateTimePicker dtpStartDate;
    private Label lblEndDate;
    private DateTimePicker dtpEndDate;
    private Button btnRefresh;
    private DataGridView dgvSummary;
    private GroupBox grpTotals;
    private Label lblTotalBookings;
    private TextBox txtTotalBookings;
    private Label lblTotalNights;
    private TextBox txtTotalNights;
    private Label lblTotalGross;
    private TextBox txtTotalGross;
    private Label lblTotalCommission;
    private TextBox txtTotalCommission;
    private Label lblTotalNet;
    private TextBox txtTotalNet;
    private Panel pnlBottom;
    private Button btnExport;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
