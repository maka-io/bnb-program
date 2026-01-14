namespace BnB.WinForms.Forms;

partial class ArrivalDepartureForm
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
        pnlTop = new Panel();
        btnPrevDay = new Button();
        lblDate = new Label();
        dtpDate = new DateTimePicker();
        btnNextDay = new Button();
        btnToday = new Button();
        splitContainer = new SplitContainer();
        lblArrivals = new Label();
        dgvArrivals = new DataGridView();
        lblDepartures = new Label();
        dgvDepartures = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();

        pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvArrivals).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvDepartures).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();

        //
        // pnlTop - Navigation controls
        //
        pnlTop.Controls.Add(btnPrevDay);
        pnlTop.Controls.Add(lblDate);
        pnlTop.Controls.Add(dtpDate);
        pnlTop.Controls.Add(btnNextDay);
        pnlTop.Controls.Add(btnToday);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Size = new Size(900, 50);
        pnlTop.Padding = new Padding(10);

        //
        // btnPrevDay
        //
        btnPrevDay.Location = new Point(15, 12);
        btnPrevDay.Size = new Size(60, 28);
        btnPrevDay.Text = "< Back";
        btnPrevDay.Click += btnPrevDay_Click;

        //
        // lblDate
        //
        lblDate.AutoSize = true;
        lblDate.Location = new Point(90, 18);
        lblDate.Text = "Date:";

        //
        // dtpDate
        //
        dtpDate.Format = DateTimePickerFormat.Short;
        dtpDate.Location = new Point(135, 14);
        dtpDate.Size = new Size(120, 23);
        dtpDate.ValueChanged += dtpDate_ValueChanged;

        //
        // btnNextDay
        //
        btnNextDay.Location = new Point(270, 12);
        btnNextDay.Size = new Size(60, 28);
        btnNextDay.Text = "Next >";
        btnNextDay.Click += btnNextDay_Click;

        //
        // btnToday
        //
        btnToday.Location = new Point(350, 12);
        btnToday.Size = new Size(75, 28);
        btnToday.Text = "Today";
        btnToday.Click += btnToday_Click;

        //
        // pnlBottom - Summary and action buttons
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 510);
        pnlBottom.Size = new Size(900, 45);

        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(15, 15);
        lblSummary.Text = "Loading...";

        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(632, 10);
        btnPreview.Size = new Size(80, 28);
        btnPreview.TabIndex = 1;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;

        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(720, 10);
        btnPrint.Size = new Size(80, 28);
        btnPrint.TabIndex = 2;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;

        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(808, 10);
        btnClose.Size = new Size(80, 28);
        btnClose.TabIndex = 3;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;

        //
        // splitContainer - Main content area
        //
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Location = new Point(0, 50);
        splitContainer.Orientation = Orientation.Horizontal;
        splitContainer.Size = new Size(900, 460);
        splitContainer.SplitterDistance = 225;
        splitContainer.SplitterWidth = 8;
        splitContainer.Panel1MinSize = 100;
        splitContainer.Panel2MinSize = 100;

        //
        // splitContainer.Panel1 - Arrivals
        //
        splitContainer.Panel1.Controls.Add(dgvArrivals);
        splitContainer.Panel1.Controls.Add(lblArrivals);
        splitContainer.Panel1.Padding = new Padding(10, 5, 10, 5);

        //
        // lblArrivals
        //
        lblArrivals.Dock = DockStyle.Top;
        lblArrivals.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblArrivals.Location = new Point(10, 5);
        lblArrivals.Size = new Size(880, 25);
        lblArrivals.Text = "Arrivals";

        //
        // dgvArrivals
        //
        dgvArrivals.AllowUserToAddRows = false;
        dgvArrivals.AllowUserToDeleteRows = false;
        dgvArrivals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvArrivals.BackgroundColor = SystemColors.Window;
        dgvArrivals.BorderStyle = BorderStyle.Fixed3D;
        dgvArrivals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvArrivals.Dock = DockStyle.Fill;
        dgvArrivals.Location = new Point(10, 30);
        dgvArrivals.MultiSelect = false;
        dgvArrivals.ReadOnly = true;
        dgvArrivals.RowHeadersVisible = false;
        dgvArrivals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvArrivals.Size = new Size(880, 190);
        dgvArrivals.TabIndex = 0;

        //
        // splitContainer.Panel2 - Departures
        //
        splitContainer.Panel2.Controls.Add(dgvDepartures);
        splitContainer.Panel2.Controls.Add(lblDepartures);
        splitContainer.Panel2.Padding = new Padding(10, 5, 10, 5);

        //
        // lblDepartures
        //
        lblDepartures.Dock = DockStyle.Top;
        lblDepartures.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblDepartures.Location = new Point(10, 5);
        lblDepartures.Size = new Size(880, 25);
        lblDepartures.Text = "Departures";

        //
        // dgvDepartures
        //
        dgvDepartures.AllowUserToAddRows = false;
        dgvDepartures.AllowUserToDeleteRows = false;
        dgvDepartures.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDepartures.BackgroundColor = SystemColors.Window;
        dgvDepartures.BorderStyle = BorderStyle.Fixed3D;
        dgvDepartures.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDepartures.Dock = DockStyle.Fill;
        dgvDepartures.Location = new Point(10, 30);
        dgvDepartures.MultiSelect = false;
        dgvDepartures.ReadOnly = true;
        dgvDepartures.RowHeadersVisible = false;
        dgvDepartures.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDepartures.Size = new Size(880, 195);
        dgvDepartures.TabIndex = 0;

        //
        // ArrivalDepartureForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 555);
        Controls.Add(splitContainer);
        Controls.Add(pnlBottom);
        Controls.Add(pnlTop);
        MinimumSize = new Size(700, 450);
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
        ((System.ComponentModel.ISupportInitialize)dgvArrivals).EndInit();
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
    private Label lblArrivals;
    private DataGridView dgvArrivals;
    private Label lblDepartures;
    private DataGridView dgvDepartures;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
