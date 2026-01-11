namespace BnB.WinForms.Forms;

partial class PaymentReceivedForm
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
        grpDateRange = new GroupBox();
        lblStartDate = new Label();
        dtpStartDate = new DateTimePicker();
        lblEndDate = new Label();
        dtpEndDate = new DateTimePicker();
        btnRefresh = new Button();
        dgvPayments = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnExport = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        grpDateRange.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // grpDateRange
        //
        grpDateRange.Controls.Add(lblStartDate);
        grpDateRange.Controls.Add(dtpStartDate);
        grpDateRange.Controls.Add(lblEndDate);
        grpDateRange.Controls.Add(dtpEndDate);
        grpDateRange.Controls.Add(btnRefresh);
        grpDateRange.Dock = DockStyle.Top;
        grpDateRange.Location = new Point(0, 0);
        grpDateRange.Size = new Size(800, 60);
        grpDateRange.TabStop = false;
        grpDateRange.Text = "Date Range";
        //
        // lblStartDate
        //
        lblStartDate.AutoSize = true;
        lblStartDate.Location = new Point(15, 25);
        lblStartDate.Text = "From:";
        //
        // dtpStartDate
        //
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(55, 22);
        dtpStartDate.Size = new Size(100, 23);
        //
        // lblEndDate
        //
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(170, 25);
        lblEndDate.Text = "To:";
        //
        // dtpEndDate
        //
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(195, 22);
        dtpEndDate.Size = new Size(100, 23);
        //
        // btnRefresh
        //
        btnRefresh.Location = new Point(310, 20);
        btnRefresh.Size = new Size(80, 27);
        btnRefresh.Text = "&Refresh";
        btnRefresh.Click += btnRefresh_Click;
        //
        // dgvPayments
        //
        dgvPayments.AllowUserToAddRows = false;
        dgvPayments.AllowUserToDeleteRows = false;
        dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPayments.Dock = DockStyle.Fill;
        dgvPayments.Location = new Point(0, 60);
        dgvPayments.MultiSelect = false;
        dgvPayments.ReadOnly = true;
        dgvPayments.RowHeadersWidth = 25;
        dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPayments.Size = new Size(800, 350);
        dgvPayments.TabIndex = 0;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnExport);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 410);
        pnlBottom.Size = new Size(800, 40);
        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(13, 13);
        lblSummary.Text = "Loading...";
        //
        // btnExport
        //
        btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnExport.Location = new Point(555, 7);
        btnExport.Size = new Size(75, 28);
        btnExport.TabIndex = 1;
        btnExport.Text = "&Export";
        btnExport.Click += btnExport_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(636, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 2;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(717, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 3;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // PaymentReceivedForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(dgvPayments);
        Controls.Add(grpDateRange);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(600, 400);
        Name = "PaymentReceivedForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Payments Received";
        Load += PaymentReceivedForm_Load;
        grpDateRange.ResumeLayout(false);
        grpDateRange.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpDateRange;
    private Label lblStartDate;
    private DateTimePicker dtpStartDate;
    private Label lblEndDate;
    private DateTimePicker dtpEndDate;
    private Button btnRefresh;
    private DataGridView dgvPayments;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnExport;
    private Button btnPrint;
    private Button btnClose;
}
