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
        lblRoomType = new Label();
        cboRoomType = new ComboBox();
        lblStartDate = new Label();
        dtpStartDate = new DateTimePicker();
        lblEndDate = new Label();
        dtpEndDate = new DateTimePicker();
        btnRefresh = new Button();
        dgvCalendar = new DataGridView();
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
        pnlFilter.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCalendar).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // pnlFilter
        //
        pnlFilter.Controls.Add(lblProperty);
        pnlFilter.Controls.Add(cboProperty);
        pnlFilter.Controls.Add(lblRoomType);
        pnlFilter.Controls.Add(cboRoomType);
        pnlFilter.Controls.Add(lblStartDate);
        pnlFilter.Controls.Add(dtpStartDate);
        pnlFilter.Controls.Add(lblEndDate);
        pnlFilter.Controls.Add(dtpEndDate);
        pnlFilter.Controls.Add(btnRefresh);
        pnlFilter.Dock = DockStyle.Top;
        pnlFilter.Location = new Point(0, 0);
        pnlFilter.Name = "pnlFilter";
        pnlFilter.Padding = new Padding(10);
        pnlFilter.Size = new Size(900, 70);
        //
        // lblProperty
        //
        lblProperty.AutoSize = true;
        lblProperty.Location = new Point(13, 18);
        lblProperty.Name = "lblProperty";
        lblProperty.Size = new Size(55, 15);
        lblProperty.Text = "Property:";
        //
        // cboProperty
        //
        cboProperty.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProperty.Location = new Point(75, 15);
        cboProperty.Name = "cboProperty";
        cboProperty.Size = new Size(200, 23);
        cboProperty.TabIndex = 0;
        cboProperty.SelectedIndexChanged += cboProperty_SelectedIndexChanged;
        //
        // lblRoomType
        //
        lblRoomType.AutoSize = true;
        lblRoomType.Location = new Point(290, 18);
        lblRoomType.Name = "lblRoomType";
        lblRoomType.Size = new Size(70, 15);
        lblRoomType.Text = "Room Type:";
        //
        // cboRoomType
        //
        cboRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRoomType.Location = new Point(365, 15);
        cboRoomType.Name = "cboRoomType";
        cboRoomType.Size = new Size(120, 23);
        cboRoomType.TabIndex = 1;
        //
        // lblStartDate
        //
        lblStartDate.AutoSize = true;
        lblStartDate.Location = new Point(13, 45);
        lblStartDate.Name = "lblStartDate";
        lblStartDate.Size = new Size(35, 15);
        lblStartDate.Text = "From:";
        //
        // dtpStartDate
        //
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(55, 42);
        dtpStartDate.Name = "dtpStartDate";
        dtpStartDate.Size = new Size(100, 23);
        dtpStartDate.TabIndex = 2;
        dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
        //
        // lblEndDate
        //
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(165, 45);
        lblEndDate.Name = "lblEndDate";
        lblEndDate.Size = new Size(22, 15);
        lblEndDate.Text = "To:";
        //
        // dtpEndDate
        //
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(195, 42);
        dtpEndDate.Name = "dtpEndDate";
        dtpEndDate.Size = new Size(100, 23);
        dtpEndDate.TabIndex = 3;
        //
        // btnRefresh
        //
        btnRefresh.Location = new Point(320, 40);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(80, 27);
        btnRefresh.TabIndex = 4;
        btnRefresh.Text = "&Refresh";
        btnRefresh.Click += btnRefresh_Click;
        //
        // dgvCalendar
        //
        dgvCalendar.AllowUserToAddRows = false;
        dgvCalendar.AllowUserToDeleteRows = false;
        dgvCalendar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCalendar.Dock = DockStyle.Fill;
        dgvCalendar.Location = new Point(0, 70);
        dgvCalendar.Name = "dgvCalendar";
        dgvCalendar.ReadOnly = true;
        dgvCalendar.RowHeadersWidth = 25;
        dgvCalendar.Size = new Size(900, 380);
        dgvCalendar.TabIndex = 5;
        dgvCalendar.CellDoubleClick += dgvCalendar_CellDoubleClick;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblStatus);
        pnlBottom.Controls.Add(lblLegend);
        pnlBottom.Controls.Add(pnlLegendAvailable);
        pnlBottom.Controls.Add(lblAvailable);
        pnlBottom.Controls.Add(pnlLegendBooked);
        pnlBottom.Controls.Add(lblBooked);
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 450);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new Size(900, 50);
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
        lblLegend.Location = new Point(450, 18);
        lblLegend.Name = "lblLegend";
        lblLegend.Size = new Size(50, 15);
        lblLegend.Text = "Legend:";
        //
        // pnlLegendAvailable
        //
        pnlLegendAvailable.BackColor = Color.LightGreen;
        pnlLegendAvailable.BorderStyle = BorderStyle.FixedSingle;
        pnlLegendAvailable.Location = new Point(510, 15);
        pnlLegendAvailable.Name = "pnlLegendAvailable";
        pnlLegendAvailable.Size = new Size(20, 20);
        //
        // lblAvailable
        //
        lblAvailable.AutoSize = true;
        lblAvailable.Location = new Point(535, 18);
        lblAvailable.Name = "lblAvailable";
        lblAvailable.Size = new Size(55, 15);
        lblAvailable.Text = "Available";
        //
        // pnlLegendBooked
        //
        pnlLegendBooked.BackColor = Color.LightCoral;
        pnlLegendBooked.BorderStyle = BorderStyle.FixedSingle;
        pnlLegendBooked.Location = new Point(610, 15);
        pnlLegendBooked.Name = "pnlLegendBooked";
        pnlLegendBooked.Size = new Size(20, 20);
        //
        // lblBooked
        //
        lblBooked.AutoSize = true;
        lblBooked.Location = new Point(635, 18);
        lblBooked.Name = "lblBooked";
        lblBooked.Size = new Size(48, 15);
        lblBooked.Text = "Booked";
        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(648, 12);
        btnPreview.Name = "btnPreview";
        btnPreview.Size = new Size(75, 28);
        btnPreview.TabIndex = 6;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(730, 12);
        btnPrint.Name = "btnPrint";
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 7;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(812, 12);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 8;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // AvailabilityForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 500);
        Controls.Add(dgvCalendar);
        Controls.Add(pnlFilter);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(800, 400);
        Name = "AvailabilityForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Availability Calendar";
        Load += AvailabilityForm_Load;
        pnlFilter.ResumeLayout(false);
        pnlFilter.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCalendar).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlFilter;
    private Label lblProperty;
    private ComboBox cboProperty;
    private Label lblRoomType;
    private ComboBox cboRoomType;
    private Label lblStartDate;
    private DateTimePicker dtpStartDate;
    private Label lblEndDate;
    private DateTimePicker dtpEndDate;
    private Button btnRefresh;
    private DataGridView dgvCalendar;
    private Panel pnlBottom;
    private Label lblStatus;
    private Label lblLegend;
    private Panel pnlLegendAvailable;
    private Label lblAvailable;
    private Panel pnlLegendBooked;
    private Label lblBooked;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
