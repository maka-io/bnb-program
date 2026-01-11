namespace BnB.WinForms.Forms;

partial class StatusForm
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
        grpToday = new GroupBox();
        lblTodayArrivals = new Label();
        txtTodayArrivals = new TextBox();
        lblTodayDepartures = new Label();
        txtTodayDepartures = new TextBox();
        lblInHouse = new Label();
        txtInHouse = new TextBox();
        grpThisMonth = new GroupBox();
        lblThisMonthBookings = new Label();
        txtThisMonthBookings = new TextBox();
        lblThisMonthRevenue = new Label();
        txtThisMonthRevenue = new TextBox();
        grpFinancials = new GroupBox();
        lblOutstandingBalance = new Label();
        txtOutstandingBalance = new TextBox();
        lblCommissionsDue = new Label();
        txtCommissionsDue = new TextBox();
        lblRefundsOwed = new Label();
        txtRefundsOwed = new TextBox();
        grpDatabase = new GroupBox();
        lblGuestCount = new Label();
        txtGuestCount = new TextBox();
        lblPropertyCount = new Label();
        txtPropertyCount = new TextBox();
        lblAccommodationCount = new Label();
        txtAccommodationCount = new TextBox();
        grpUpcoming = new GroupBox();
        lblUpcomingArrivals = new Label();
        txtUpcomingArrivals = new TextBox();
        pnlBottom = new Panel();
        lblLastUpdated = new Label();
        btnRefresh = new Button();
        btnClose = new Button();
        grpToday.SuspendLayout();
        grpThisMonth.SuspendLayout();
        grpFinancials.SuspendLayout();
        grpDatabase.SuspendLayout();
        grpUpcoming.SuspendLayout();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // grpToday
        //
        grpToday.Controls.Add(lblTodayArrivals);
        grpToday.Controls.Add(txtTodayArrivals);
        grpToday.Controls.Add(lblTodayDepartures);
        grpToday.Controls.Add(txtTodayDepartures);
        grpToday.Controls.Add(lblInHouse);
        grpToday.Controls.Add(txtInHouse);
        grpToday.Location = new Point(12, 12);
        grpToday.Size = new Size(220, 130);
        grpToday.TabStop = false;
        grpToday.Text = "Today";
        //
        // lblTodayArrivals
        //
        lblTodayArrivals.AutoSize = true;
        lblTodayArrivals.Location = new Point(15, 30);
        lblTodayArrivals.Text = "Arrivals:";
        //
        // txtTodayArrivals
        //
        txtTodayArrivals.Location = new Point(120, 27);
        txtTodayArrivals.ReadOnly = true;
        txtTodayArrivals.Size = new Size(80, 23);
        txtTodayArrivals.TextAlign = HorizontalAlignment.Right;
        //
        // lblTodayDepartures
        //
        lblTodayDepartures.AutoSize = true;
        lblTodayDepartures.Location = new Point(15, 60);
        lblTodayDepartures.Text = "Departures:";
        //
        // txtTodayDepartures
        //
        txtTodayDepartures.Location = new Point(120, 57);
        txtTodayDepartures.ReadOnly = true;
        txtTodayDepartures.Size = new Size(80, 23);
        txtTodayDepartures.TextAlign = HorizontalAlignment.Right;
        //
        // lblInHouse
        //
        lblInHouse.AutoSize = true;
        lblInHouse.Location = new Point(15, 90);
        lblInHouse.Text = "In-House:";
        //
        // txtInHouse
        //
        txtInHouse.Location = new Point(120, 87);
        txtInHouse.ReadOnly = true;
        txtInHouse.Size = new Size(80, 23);
        txtInHouse.TextAlign = HorizontalAlignment.Right;
        //
        // grpThisMonth
        //
        grpThisMonth.Controls.Add(lblThisMonthBookings);
        grpThisMonth.Controls.Add(txtThisMonthBookings);
        grpThisMonth.Controls.Add(lblThisMonthRevenue);
        grpThisMonth.Controls.Add(txtThisMonthRevenue);
        grpThisMonth.Location = new Point(248, 12);
        grpThisMonth.Size = new Size(220, 95);
        grpThisMonth.TabStop = false;
        grpThisMonth.Text = "This Month";
        //
        // lblThisMonthBookings
        //
        lblThisMonthBookings.AutoSize = true;
        lblThisMonthBookings.Location = new Point(15, 30);
        lblThisMonthBookings.Text = "New Bookings:";
        //
        // txtThisMonthBookings
        //
        txtThisMonthBookings.Location = new Point(120, 27);
        txtThisMonthBookings.ReadOnly = true;
        txtThisMonthBookings.Size = new Size(80, 23);
        txtThisMonthBookings.TextAlign = HorizontalAlignment.Right;
        //
        // lblThisMonthRevenue
        //
        lblThisMonthRevenue.AutoSize = true;
        lblThisMonthRevenue.Location = new Point(15, 60);
        lblThisMonthRevenue.Text = "Revenue:";
        //
        // txtThisMonthRevenue
        //
        txtThisMonthRevenue.Location = new Point(120, 57);
        txtThisMonthRevenue.ReadOnly = true;
        txtThisMonthRevenue.Size = new Size(80, 23);
        txtThisMonthRevenue.TextAlign = HorizontalAlignment.Right;
        //
        // grpFinancials
        //
        grpFinancials.Controls.Add(lblOutstandingBalance);
        grpFinancials.Controls.Add(txtOutstandingBalance);
        grpFinancials.Controls.Add(lblCommissionsDue);
        grpFinancials.Controls.Add(txtCommissionsDue);
        grpFinancials.Controls.Add(lblRefundsOwed);
        grpFinancials.Controls.Add(txtRefundsOwed);
        grpFinancials.Location = new Point(12, 150);
        grpFinancials.Size = new Size(220, 130);
        grpFinancials.TabStop = false;
        grpFinancials.Text = "Financials";
        //
        // lblOutstandingBalance
        //
        lblOutstandingBalance.AutoSize = true;
        lblOutstandingBalance.Location = new Point(15, 30);
        lblOutstandingBalance.Text = "Balance Due:";
        //
        // txtOutstandingBalance
        //
        txtOutstandingBalance.Location = new Point(120, 27);
        txtOutstandingBalance.ReadOnly = true;
        txtOutstandingBalance.Size = new Size(80, 23);
        txtOutstandingBalance.TextAlign = HorizontalAlignment.Right;
        //
        // lblCommissionsDue
        //
        lblCommissionsDue.AutoSize = true;
        lblCommissionsDue.Location = new Point(15, 60);
        lblCommissionsDue.Text = "Commissions:";
        //
        // txtCommissionsDue
        //
        txtCommissionsDue.Location = new Point(120, 57);
        txtCommissionsDue.ReadOnly = true;
        txtCommissionsDue.Size = new Size(80, 23);
        txtCommissionsDue.TextAlign = HorizontalAlignment.Right;
        //
        // lblRefundsOwed
        //
        lblRefundsOwed.AutoSize = true;
        lblRefundsOwed.Location = new Point(15, 90);
        lblRefundsOwed.Text = "Refunds Owed:";
        //
        // txtRefundsOwed
        //
        txtRefundsOwed.Location = new Point(120, 87);
        txtRefundsOwed.ReadOnly = true;
        txtRefundsOwed.Size = new Size(80, 23);
        txtRefundsOwed.TextAlign = HorizontalAlignment.Right;
        //
        // grpDatabase
        //
        grpDatabase.Controls.Add(lblGuestCount);
        grpDatabase.Controls.Add(txtGuestCount);
        grpDatabase.Controls.Add(lblPropertyCount);
        grpDatabase.Controls.Add(txtPropertyCount);
        grpDatabase.Controls.Add(lblAccommodationCount);
        grpDatabase.Controls.Add(txtAccommodationCount);
        grpDatabase.Location = new Point(248, 115);
        grpDatabase.Size = new Size(220, 130);
        grpDatabase.TabStop = false;
        grpDatabase.Text = "Database";
        //
        // lblGuestCount
        //
        lblGuestCount.AutoSize = true;
        lblGuestCount.Location = new Point(15, 30);
        lblGuestCount.Text = "Guests:";
        //
        // txtGuestCount
        //
        txtGuestCount.Location = new Point(120, 27);
        txtGuestCount.ReadOnly = true;
        txtGuestCount.Size = new Size(80, 23);
        txtGuestCount.TextAlign = HorizontalAlignment.Right;
        //
        // lblPropertyCount
        //
        lblPropertyCount.AutoSize = true;
        lblPropertyCount.Location = new Point(15, 60);
        lblPropertyCount.Text = "Properties:";
        //
        // txtPropertyCount
        //
        txtPropertyCount.Location = new Point(120, 57);
        txtPropertyCount.ReadOnly = true;
        txtPropertyCount.Size = new Size(80, 23);
        txtPropertyCount.TextAlign = HorizontalAlignment.Right;
        //
        // lblAccommodationCount
        //
        lblAccommodationCount.AutoSize = true;
        lblAccommodationCount.Location = new Point(15, 90);
        lblAccommodationCount.Text = "Reservations:";
        //
        // txtAccommodationCount
        //
        txtAccommodationCount.Location = new Point(120, 87);
        txtAccommodationCount.ReadOnly = true;
        txtAccommodationCount.Size = new Size(80, 23);
        txtAccommodationCount.TextAlign = HorizontalAlignment.Right;
        //
        // grpUpcoming
        //
        grpUpcoming.Controls.Add(lblUpcomingArrivals);
        grpUpcoming.Controls.Add(txtUpcomingArrivals);
        grpUpcoming.Location = new Point(248, 253);
        grpUpcoming.Size = new Size(220, 60);
        grpUpcoming.TabStop = false;
        grpUpcoming.Text = "Next 7 Days";
        //
        // lblUpcomingArrivals
        //
        lblUpcomingArrivals.AutoSize = true;
        lblUpcomingArrivals.Location = new Point(15, 27);
        lblUpcomingArrivals.Text = "Arrivals:";
        //
        // txtUpcomingArrivals
        //
        txtUpcomingArrivals.Location = new Point(120, 24);
        txtUpcomingArrivals.ReadOnly = true;
        txtUpcomingArrivals.Size = new Size(80, 23);
        txtUpcomingArrivals.TextAlign = HorizontalAlignment.Right;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblLastUpdated);
        pnlBottom.Controls.Add(btnRefresh);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 330);
        pnlBottom.Size = new Size(484, 40);
        //
        // lblLastUpdated
        //
        lblLastUpdated.AutoSize = true;
        lblLastUpdated.Location = new Point(13, 13);
        lblLastUpdated.Text = "Last updated: --";
        //
        // btnRefresh
        //
        btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRefresh.Location = new Point(320, 7);
        btnRefresh.Size = new Size(75, 28);
        btnRefresh.TabIndex = 1;
        btnRefresh.Text = "&Refresh";
        btnRefresh.Click += btnRefresh_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(401, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 2;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // StatusForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(484, 370);
        Controls.Add(grpToday);
        Controls.Add(grpThisMonth);
        Controls.Add(grpFinancials);
        Controls.Add(grpDatabase);
        Controls.Add(grpUpcoming);
        Controls.Add(pnlBottom);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "StatusForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "System Status";
        Load += StatusForm_Load;
        grpToday.ResumeLayout(false);
        grpToday.PerformLayout();
        grpThisMonth.ResumeLayout(false);
        grpThisMonth.PerformLayout();
        grpFinancials.ResumeLayout(false);
        grpFinancials.PerformLayout();
        grpDatabase.ResumeLayout(false);
        grpDatabase.PerformLayout();
        grpUpcoming.ResumeLayout(false);
        grpUpcoming.PerformLayout();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpToday;
    private Label lblTodayArrivals;
    private TextBox txtTodayArrivals;
    private Label lblTodayDepartures;
    private TextBox txtTodayDepartures;
    private Label lblInHouse;
    private TextBox txtInHouse;
    private GroupBox grpThisMonth;
    private Label lblThisMonthBookings;
    private TextBox txtThisMonthBookings;
    private Label lblThisMonthRevenue;
    private TextBox txtThisMonthRevenue;
    private GroupBox grpFinancials;
    private Label lblOutstandingBalance;
    private TextBox txtOutstandingBalance;
    private Label lblCommissionsDue;
    private TextBox txtCommissionsDue;
    private Label lblRefundsOwed;
    private TextBox txtRefundsOwed;
    private GroupBox grpDatabase;
    private Label lblGuestCount;
    private TextBox txtGuestCount;
    private Label lblPropertyCount;
    private TextBox txtPropertyCount;
    private Label lblAccommodationCount;
    private TextBox txtAccommodationCount;
    private GroupBox grpUpcoming;
    private Label lblUpcomingArrivals;
    private TextBox txtUpcomingArrivals;
    private Panel pnlBottom;
    private Label lblLastUpdated;
    private Button btnRefresh;
    private Button btnClose;
}
