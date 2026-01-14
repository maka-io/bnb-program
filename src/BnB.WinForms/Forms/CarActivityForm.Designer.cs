namespace BnB.WinForms.Forms;

partial class CarActivityForm
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
        lblStartDate = new Label();
        dtpStartDate = new DateTimePicker();
        lblEndDate = new Label();
        dtpEndDate = new DateTimePicker();
        btnRefresh = new Button();
        dgvCarActivity = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        pnlFilter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCarActivity).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // pnlFilter
        //
        pnlFilter.Controls.Add(lblStartDate);
        pnlFilter.Controls.Add(dtpStartDate);
        pnlFilter.Controls.Add(lblEndDate);
        pnlFilter.Controls.Add(dtpEndDate);
        pnlFilter.Controls.Add(btnRefresh);
        pnlFilter.Dock = DockStyle.Top;
        pnlFilter.Location = new Point(0, 0);
        pnlFilter.Name = "pnlFilter";
        pnlFilter.Padding = new Padding(10);
        pnlFilter.Size = new Size(800, 50);
        //
        // lblStartDate
        //
        lblStartDate.AutoSize = true;
        lblStartDate.Location = new Point(13, 18);
        lblStartDate.Text = "From:";
        //
        // dtpStartDate
        //
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(55, 15);
        dtpStartDate.Size = new Size(100, 23);
        dtpStartDate.TabIndex = 0;
        //
        // lblEndDate
        //
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(170, 18);
        lblEndDate.Text = "To:";
        //
        // dtpEndDate
        //
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(195, 15);
        dtpEndDate.Size = new Size(100, 23);
        dtpEndDate.TabIndex = 1;
        //
        // btnRefresh
        //
        btnRefresh.Location = new Point(320, 13);
        btnRefresh.Size = new Size(80, 27);
        btnRefresh.TabIndex = 2;
        btnRefresh.Text = "&Refresh";
        btnRefresh.Click += btnRefresh_Click;
        //
        // dgvCarActivity
        //
        dgvCarActivity.AllowUserToAddRows = false;
        dgvCarActivity.AllowUserToDeleteRows = false;
        dgvCarActivity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCarActivity.Dock = DockStyle.Fill;
        dgvCarActivity.Location = new Point(0, 50);
        dgvCarActivity.MultiSelect = false;
        dgvCarActivity.ReadOnly = true;
        dgvCarActivity.RowHeadersWidth = 25;
        dgvCarActivity.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCarActivity.Size = new Size(800, 360);
        dgvCarActivity.TabIndex = 3;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnPreview);
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
        lblSummary.Text = "Click Refresh to load data";
        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(548, 7);
        btnPreview.Size = new Size(75, 28);
        btnPreview.TabIndex = 4;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(629, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 5;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(710, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 6;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // CarActivityForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(dgvCarActivity);
        Controls.Add(pnlFilter);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(600, 400);
        Name = "CarActivityForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Car Rental Activity";
        Load += CarActivityForm_Load;
        pnlFilter.ResumeLayout(false);
        pnlFilter.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCarActivity).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlFilter;
    private Label lblStartDate;
    private DateTimePicker dtpStartDate;
    private Label lblEndDate;
    private DateTimePicker dtpEndDate;
    private Button btnRefresh;
    private DataGridView dgvCarActivity;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
