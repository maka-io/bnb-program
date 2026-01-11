namespace BnB.WinForms.Forms;

partial class ArrivalDepartureForm
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
        btnPrevDay = new Button();
        lblDate = new Label();
        dtpDate = new DateTimePicker();
        btnNextDay = new Button();
        btnToday = new Button();
        splitContainer = new SplitContainer();
        grpArrivals = new GroupBox();
        dgvArrivals = new DataGridView();
        grpDepartures = new GroupBox();
        dgvDepartures = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnPrint = new Button();
        btnClose = new Button();
        pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        grpArrivals.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvArrivals).BeginInit();
        grpDepartures.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDepartures).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // pnlTop
        //
        pnlTop.Controls.Add(btnPrevDay);
        pnlTop.Controls.Add(lblDate);
        pnlTop.Controls.Add(dtpDate);
        pnlTop.Controls.Add(btnNextDay);
        pnlTop.Controls.Add(btnToday);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Size = new Size(800, 45);
        //
        // btnPrevDay
        //
        btnPrevDay.Location = new Point(12, 10);
        btnPrevDay.Size = new Size(30, 27);
        btnPrevDay.Text = "<";
        btnPrevDay.Click += btnPrevDay_Click;
        //
        // lblDate
        //
        lblDate.AutoSize = true;
        lblDate.Location = new Point(55, 15);
        lblDate.Text = "Date:";
        //
        // dtpDate
        //
        dtpDate.Format = DateTimePickerFormat.Short;
        dtpDate.Location = new Point(95, 12);
        dtpDate.Size = new Size(100, 23);
        dtpDate.ValueChanged += dtpDate_ValueChanged;
        //
        // btnNextDay
        //
        btnNextDay.Location = new Point(200, 10);
        btnNextDay.Size = new Size(30, 27);
        btnNextDay.Text = ">";
        btnNextDay.Click += btnNextDay_Click;
        //
        // btnToday
        //
        btnToday.Location = new Point(245, 10);
        btnToday.Size = new Size(60, 27);
        btnToday.Text = "Today";
        btnToday.Click += btnToday_Click;
        //
        // splitContainer
        //
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Location = new Point(0, 45);
        splitContainer.Orientation = Orientation.Horizontal;
        splitContainer.Size = new Size(800, 365);
        splitContainer.SplitterDistance = 180;
        //
        // splitContainer.Panel1
        //
        splitContainer.Panel1.Controls.Add(grpArrivals);
        //
        // splitContainer.Panel2
        //
        splitContainer.Panel2.Controls.Add(grpDepartures);
        //
        // grpArrivals
        //
        grpArrivals.Controls.Add(dgvArrivals);
        grpArrivals.Dock = DockStyle.Fill;
        grpArrivals.Location = new Point(0, 0);
        grpArrivals.Size = new Size(800, 180);
        grpArrivals.TabStop = false;
        grpArrivals.Text = "Arrivals";
        //
        // dgvArrivals
        //
        dgvArrivals.AllowUserToAddRows = false;
        dgvArrivals.AllowUserToDeleteRows = false;
        dgvArrivals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvArrivals.Dock = DockStyle.Fill;
        dgvArrivals.Location = new Point(3, 19);
        dgvArrivals.MultiSelect = false;
        dgvArrivals.ReadOnly = true;
        dgvArrivals.RowHeadersWidth = 25;
        dgvArrivals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvArrivals.Size = new Size(794, 158);
        dgvArrivals.TabIndex = 0;
        //
        // grpDepartures
        //
        grpDepartures.Controls.Add(dgvDepartures);
        grpDepartures.Dock = DockStyle.Fill;
        grpDepartures.Location = new Point(0, 0);
        grpDepartures.Size = new Size(800, 181);
        grpDepartures.TabStop = false;
        grpDepartures.Text = "Departures";
        //
        // dgvDepartures
        //
        dgvDepartures.AllowUserToAddRows = false;
        dgvDepartures.AllowUserToDeleteRows = false;
        dgvDepartures.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDepartures.Dock = DockStyle.Fill;
        dgvDepartures.Location = new Point(3, 19);
        dgvDepartures.MultiSelect = false;
        dgvDepartures.ReadOnly = true;
        dgvDepartures.RowHeadersWidth = 25;
        dgvDepartures.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDepartures.Size = new Size(794, 159);
        dgvDepartures.TabIndex = 0;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
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
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(636, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 1;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(717, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 2;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // ArrivalDepartureForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(splitContainer);
        Controls.Add(pnlTop);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(600, 400);
        Name = "ArrivalDepartureForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Arrivals & Departures";
        Load += ArrivalDepartureForm_Load;
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        grpArrivals.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvArrivals).EndInit();
        grpDepartures.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvDepartures).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTop;
    private Button btnPrevDay;
    private Label lblDate;
    private DateTimePicker dtpDate;
    private Button btnNextDay;
    private Button btnToday;
    private SplitContainer splitContainer;
    private GroupBox grpArrivals;
    private DataGridView dgvArrivals;
    private GroupBox grpDepartures;
    private DataGridView dgvDepartures;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnPrint;
    private Button btnClose;
}
