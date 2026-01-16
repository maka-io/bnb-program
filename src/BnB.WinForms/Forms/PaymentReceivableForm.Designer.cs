namespace BnB.WinForms.Forms;

partial class PaymentReceivableForm
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
        dgvReceivables = new DataGridView();
        contextMenuStrip = new ContextMenuStrip();
        mnuGoTo = new ToolStripMenuItem();
        mnuGoToGuestInfo = new ToolStripMenuItem();
        mnuGoToAccommodations = new ToolStripMenuItem();
        mnuGoToPayments = new ToolStripMenuItem();
        pnlTop = new Panel();
        chkIncludePastArrivals = new CheckBox();
        lblDateFrom = new Label();
        dtpDateFrom = new DateTimePicker();
        lblDateTo = new Label();
        dtpDateTo = new DateTimePicker();
        btnReset = new Button();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnRefresh = new Button();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvReceivables).BeginInit();
        contextMenuStrip.SuspendLayout();
        pnlTop.SuspendLayout();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // contextMenuStrip
        //
        contextMenuStrip.Items.AddRange(new ToolStripItem[] { mnuGoTo });
        //
        // mnuGoTo
        //
        mnuGoTo.Text = "Go To";
        mnuGoTo.DropDownItems.AddRange(new ToolStripItem[] { mnuGoToGuestInfo, mnuGoToAccommodations, mnuGoToPayments });
        //
        // mnuGoToGuestInfo
        //
        mnuGoToGuestInfo.Text = "Guest General Information";
        mnuGoToGuestInfo.Click += mnuGoToGuestInfo_Click;
        //
        // mnuGoToAccommodations
        //
        mnuGoToAccommodations.Text = "Guest Accommodations";
        mnuGoToAccommodations.Click += mnuGoToAccommodations_Click;
        //
        // mnuGoToPayments
        //
        mnuGoToPayments.Text = "Guest Payments";
        mnuGoToPayments.Click += mnuGoToPayments_Click;
        //
        // pnlTop
        //
        pnlTop.Controls.Add(chkIncludePastArrivals);
        pnlTop.Controls.Add(lblDateFrom);
        pnlTop.Controls.Add(dtpDateFrom);
        pnlTop.Controls.Add(lblDateTo);
        pnlTop.Controls.Add(dtpDateTo);
        pnlTop.Controls.Add(btnReset);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Size = new Size(850, 35);
        //
        // chkIncludePastArrivals
        //
        chkIncludePastArrivals.AutoSize = true;
        chkIncludePastArrivals.Location = new Point(13, 8);
        chkIncludePastArrivals.Text = "Include guests who have already arrived";
        chkIncludePastArrivals.CheckedChanged += chkIncludePastArrivals_CheckedChanged;
        //
        // lblDateFrom
        //
        lblDateFrom.AutoSize = true;
        lblDateFrom.Location = new Point(320, 10);
        lblDateFrom.Text = "From:";
        //
        // dtpDateFrom
        //
        dtpDateFrom.Format = DateTimePickerFormat.Short;
        dtpDateFrom.Location = new Point(360, 6);
        dtpDateFrom.Size = new Size(100, 23);
        dtpDateFrom.ValueChanged += dtpDateRange_ValueChanged;
        //
        // lblDateTo
        //
        lblDateTo.AutoSize = true;
        lblDateTo.Location = new Point(470, 10);
        lblDateTo.Text = "To:";
        //
        // dtpDateTo
        //
        dtpDateTo.Format = DateTimePickerFormat.Short;
        dtpDateTo.Location = new Point(495, 6);
        dtpDateTo.Size = new Size(100, 23);
        dtpDateTo.ValueChanged += dtpDateRange_ValueChanged;
        //
        // btnReset
        //
        btnReset.Location = new Point(605, 5);
        btnReset.Size = new Size(60, 25);
        btnReset.Text = "Reset";
        btnReset.Click += btnReset_Click;
        //
        // dgvReceivables
        //
        dgvReceivables.AllowUserToAddRows = false;
        dgvReceivables.AllowUserToDeleteRows = false;
        dgvReceivables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvReceivables.Dock = DockStyle.Fill;
        dgvReceivables.Location = new Point(0, 35);
        dgvReceivables.MultiSelect = false;
        dgvReceivables.ReadOnly = true;
        dgvReceivables.RowHeadersWidth = 25;
        dgvReceivables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvReceivables.Size = new Size(850, 375);
        dgvReceivables.TabIndex = 0;
        dgvReceivables.MouseDown += dgvReceivables_MouseDown;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnRefresh);
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 410);
        pnlBottom.Size = new Size(850, 40);
        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(13, 13);
        lblSummary.Text = "Loading...";
        //
        // btnRefresh
        //
        btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRefresh.Location = new Point(524, 7);
        btnRefresh.Size = new Size(75, 28);
        btnRefresh.TabIndex = 1;
        btnRefresh.Text = "&Refresh";
        btnRefresh.Click += btnRefresh_Click;
        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(605, 7);
        btnPreview.Size = new Size(75, 28);
        btnPreview.TabIndex = 2;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(686, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 3;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(767, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 4;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // PaymentReceivableForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(850, 450);
        Controls.Add(dgvReceivables);
        Controls.Add(pnlTop);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(700, 400);
        Name = "PaymentReceivableForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Payments Receivable";
        Load += PaymentReceivableForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvReceivables).EndInit();
        contextMenuStrip.ResumeLayout(false);
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvReceivables;
    private ContextMenuStrip contextMenuStrip;
    private ToolStripMenuItem mnuGoTo;
    private ToolStripMenuItem mnuGoToGuestInfo;
    private ToolStripMenuItem mnuGoToAccommodations;
    private ToolStripMenuItem mnuGoToPayments;
    private Panel pnlTop;
    private CheckBox chkIncludePastArrivals;
    private Label lblDateFrom;
    private DateTimePicker dtpDateFrom;
    private Label lblDateTo;
    private DateTimePicker dtpDateTo;
    private Button btnReset;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnRefresh;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
