namespace BnB.WinForms.Forms;

partial class AvailabilityForm
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
        lblYear = new Label();
        cboYear = new ComboBox();
        btnRefresh = new Button();
        pnlCalendars = new FlowLayoutPanel();
        pnlBottom = new Panel();
        lblStatus = new Label();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        lblLegend = new Label();
        pnlLegendAvailable = new Panel();
        lblAvailable = new Label();
        pnlLegendBooked = new Panel();
        lblBooked = new Label();
        pnlLegendWeekend = new Panel();
        lblWeekend = new Label();
        pnlFilter.SuspendLayout();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // pnlFilter
        //
        pnlFilter.Controls.Add(lblProperty);
        pnlFilter.Controls.Add(cboProperty);
        pnlFilter.Controls.Add(lblYear);
        pnlFilter.Controls.Add(cboYear);
        pnlFilter.Controls.Add(btnRefresh);
        pnlFilter.Dock = DockStyle.Top;
        pnlFilter.Location = new Point(0, 0);
        pnlFilter.Name = "pnlFilter";
        pnlFilter.Padding = new Padding(10);
        pnlFilter.Size = new Size(1200, 45);
        //
        // lblProperty
        //
        lblProperty.AutoSize = true;
        lblProperty.Location = new Point(13, 15);
        lblProperty.Name = "lblProperty";
        lblProperty.Size = new Size(55, 15);
        lblProperty.Text = "Property:";
        //
        // cboProperty
        //
        cboProperty.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProperty.Location = new Point(75, 12);
        cboProperty.Name = "cboProperty";
        cboProperty.Size = new Size(250, 23);
        cboProperty.TabIndex = 0;
        cboProperty.SelectedIndexChanged += cboProperty_SelectedIndexChanged;
        //
        // lblYear
        //
        lblYear.AutoSize = true;
        lblYear.Location = new Point(345, 15);
        lblYear.Name = "lblYear";
        lblYear.Size = new Size(32, 15);
        lblYear.Text = "Year:";
        //
        // cboYear
        //
        cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
        cboYear.Location = new Point(385, 12);
        cboYear.Name = "cboYear";
        cboYear.Size = new Size(80, 23);
        cboYear.TabIndex = 1;
        cboYear.SelectedIndexChanged += cboYear_SelectedIndexChanged;
        //
        // btnRefresh
        //
        btnRefresh.Location = new Point(480, 10);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(80, 27);
        btnRefresh.TabIndex = 2;
        btnRefresh.Text = "&Refresh";
        btnRefresh.Click += btnRefresh_Click;
        //
        // pnlCalendars
        //
        pnlCalendars.AutoScroll = true;
        pnlCalendars.Dock = DockStyle.Fill;
        pnlCalendars.FlowDirection = FlowDirection.TopDown;
        pnlCalendars.WrapContents = false;
        pnlCalendars.Padding = new Padding(10, 30, 10, 100);
        pnlCalendars.Location = new Point(0, 45);
        pnlCalendars.Name = "pnlCalendars";
        pnlCalendars.Size = new Size(1200, 555);
        pnlCalendars.TabIndex = 3;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblStatus);
        pnlBottom.Controls.Add(lblLegend);
        pnlBottom.Controls.Add(pnlLegendAvailable);
        pnlBottom.Controls.Add(lblAvailable);
        pnlBottom.Controls.Add(pnlLegendBooked);
        pnlBottom.Controls.Add(lblBooked);
        pnlBottom.Controls.Add(pnlLegendWeekend);
        pnlBottom.Controls.Add(lblWeekend);
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 650);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new Size(1200, 50);
        //
        // lblStatus
        //
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(13, 18);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(213, 15);
        lblStatus.Text = "Select options and click Refresh to view";
        //
        // lblLegend
        //
        lblLegend.AutoSize = true;
        lblLegend.Location = new Point(350, 18);
        lblLegend.Name = "lblLegend";
        lblLegend.Size = new Size(50, 15);
        lblLegend.Text = "Legend:";
        //
        // pnlLegendAvailable
        //
        pnlLegendAvailable.BackColor = Color.LightGreen;
        pnlLegendAvailable.BorderStyle = BorderStyle.FixedSingle;
        pnlLegendAvailable.Location = new Point(410, 15);
        pnlLegendAvailable.Name = "pnlLegendAvailable";
        pnlLegendAvailable.Size = new Size(20, 20);
        //
        // lblAvailable
        //
        lblAvailable.AutoSize = true;
        lblAvailable.Location = new Point(435, 18);
        lblAvailable.Name = "lblAvailable";
        lblAvailable.Size = new Size(55, 15);
        lblAvailable.Text = "Available";
        //
        // pnlLegendBooked
        //
        pnlLegendBooked.BackColor = Color.LightCoral;
        pnlLegendBooked.BorderStyle = BorderStyle.FixedSingle;
        pnlLegendBooked.Location = new Point(505, 15);
        pnlLegendBooked.Name = "pnlLegendBooked";
        pnlLegendBooked.Size = new Size(20, 20);
        //
        // lblBooked
        //
        lblBooked.AutoSize = true;
        lblBooked.Location = new Point(530, 18);
        lblBooked.Name = "lblBooked";
        lblBooked.Size = new Size(48, 15);
        lblBooked.Text = "Booked";
        //
        // pnlLegendWeekend
        //
        pnlLegendWeekend.BackColor = Color.FromArgb(220, 220, 220);
        pnlLegendWeekend.BorderStyle = BorderStyle.FixedSingle;
        pnlLegendWeekend.Location = new Point(595, 15);
        pnlLegendWeekend.Name = "pnlLegendWeekend";
        pnlLegendWeekend.Size = new Size(20, 20);
        //
        // lblWeekend
        //
        lblWeekend.AutoSize = true;
        lblWeekend.Location = new Point(620, 18);
        lblWeekend.Name = "lblWeekend";
        lblWeekend.Size = new Size(55, 15);
        lblWeekend.Text = "Weekend";
        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(970, 12);
        btnPreview.Name = "btnPreview";
        btnPreview.Size = new Size(75, 28);
        btnPreview.TabIndex = 6;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(1050, 12);
        btnPrint.Name = "btnPrint";
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 7;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(1130, 12);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(60, 28);
        btnClose.TabIndex = 8;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // AvailabilityForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1200, 700);
        Controls.Add(pnlFilter);
        Controls.Add(pnlBottom);
        Controls.Add(pnlCalendars);
        MinimumSize = new Size(1000, 600);
        Name = "AvailabilityForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Availability Calendar - Year View";
        WindowState = FormWindowState.Maximized;
        Load += AvailabilityForm_Load;
        pnlFilter.ResumeLayout(false);
        pnlFilter.PerformLayout();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlFilter;
    private Label lblProperty;
    private ComboBox cboProperty;
    private Label lblYear;
    private ComboBox cboYear;
    private Button btnRefresh;
    private FlowLayoutPanel pnlCalendars;
    private Panel pnlBottom;
    private Label lblStatus;
    private Label lblLegend;
    private Panel pnlLegendAvailable;
    private Label lblAvailable;
    private Panel pnlLegendBooked;
    private Label lblBooked;
    private Panel pnlLegendWeekend;
    private Label lblWeekend;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
