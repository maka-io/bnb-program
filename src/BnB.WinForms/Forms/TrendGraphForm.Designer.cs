namespace BnB.WinForms.Forms;

partial class TrendGraphForm
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
        lblMetric = new Label();
        cboMetric = new ComboBox();
        btnRefresh = new Button();
        splitContainer = new SplitContainer();
        pnlChart = new Panel();
        dgvData = new DataGridView();
        pnlBottom = new Panel();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // pnlTop
        //
        pnlTop.Controls.Add(lblStartDate);
        pnlTop.Controls.Add(dtpStartDate);
        pnlTop.Controls.Add(lblEndDate);
        pnlTop.Controls.Add(dtpEndDate);
        pnlTop.Controls.Add(lblMetric);
        pnlTop.Controls.Add(cboMetric);
        pnlTop.Controls.Add(btnRefresh);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Size = new Size(850, 45);
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
        // lblMetric
        //
        lblMetric.AutoSize = true;
        lblMetric.Location = new Point(320, 15);
        lblMetric.Text = "Metric:";
        //
        // cboMetric
        //
        cboMetric.DropDownStyle = ComboBoxStyle.DropDownList;
        cboMetric.Location = new Point(365, 12);
        cboMetric.Size = new Size(120, 23);
        cboMetric.SelectedIndexChanged += cboMetric_SelectedIndexChanged;
        //
        // btnRefresh
        //
        btnRefresh.Location = new Point(500, 10);
        btnRefresh.Size = new Size(80, 27);
        btnRefresh.Text = "&Refresh";
        btnRefresh.Click += btnRefresh_Click;
        //
        // splitContainer
        //
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Location = new Point(0, 45);
        splitContainer.Orientation = Orientation.Horizontal;
        splitContainer.Size = new Size(850, 415);
        splitContainer.SplitterDistance = 280;
        //
        // splitContainer.Panel1
        //
        splitContainer.Panel1.Controls.Add(pnlChart);
        //
        // splitContainer.Panel2
        //
        splitContainer.Panel2.Controls.Add(dgvData);
        //
        // pnlChart
        //
        pnlChart.BackColor = Color.White;
        pnlChart.BorderStyle = BorderStyle.FixedSingle;
        pnlChart.Dock = DockStyle.Fill;
        pnlChart.Location = new Point(0, 0);
        pnlChart.Size = new Size(850, 280);
        pnlChart.Paint += pnlChart_Paint;
        //
        // dgvData
        //
        dgvData.AllowUserToAddRows = false;
        dgvData.AllowUserToDeleteRows = false;
        dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvData.Dock = DockStyle.Fill;
        dgvData.Location = new Point(0, 0);
        dgvData.ReadOnly = true;
        dgvData.RowHeadersWidth = 25;
        dgvData.Size = new Size(850, 131);
        dgvData.TabIndex = 0;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 460);
        pnlBottom.Size = new Size(850, 40);
        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(605, 7);
        btnPreview.Size = new Size(75, 28);
        btnPreview.TabIndex = 1;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(686, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 2;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(767, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 3;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // TrendGraphForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(850, 500);
        Controls.Add(splitContainer);
        Controls.Add(pnlTop);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(700, 450);
        Name = "TrendGraphForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Trend Analysis";
        Load += TrendGraphForm_Load;
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
        pnlBottom.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTop;
    private Label lblStartDate;
    private DateTimePicker dtpStartDate;
    private Label lblEndDate;
    private DateTimePicker dtpEndDate;
    private Label lblMetric;
    private ComboBox cboMetric;
    private Button btnRefresh;
    private SplitContainer splitContainer;
    private Panel pnlChart;
    private DataGridView dgvData;
    private Panel pnlBottom;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
