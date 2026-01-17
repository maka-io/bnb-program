using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Availability Calendar form - Year view with monthly grids.
/// Shows room availability for properties across an entire year.
/// </summary>
public partial class AvailabilityForm : Form
{
    private readonly BnBDbContext _dbContext;
    private int _selectedYear;
    private List<Property> _properties = new();
    private List<RoomType> _roomTypes = new();
    private List<Accommodation> _accommodations = new();
    private List<RoomBlackout> _blackouts = new();
    private readonly Dictionary<int, DataGridView> _monthGrids = new();

    // Context menu for right-click actions
    private ContextMenuStrip _cellContextMenu = null!;
    private ToolStripMenuItem _menuNewBooking = null!;
    private ToolStripMenuItem _menuBlockRoom = null!;
    private ToolStripMenuItem _menuRemoveBlackout = null!;
    private ToolStripMenuItem _menuViewBooking = null!;
    private DataGridView? _contextMenuGrid;
    private int _contextMenuRow;
    private int _contextMenuCol;

    public AvailabilityForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void AvailabilityForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        // Re-apply legend colors after theme (theme may override them)
        pnlLegendAvailable.BackColor = Color.LightGreen;
        pnlLegendBooked.BackColor = Color.LightCoral;
        pnlLegendWeekend.BackColor = Color.FromArgb(220, 220, 220);
        pnlLegendBlocked.BackColor = Color.FromArgb(255, 200, 100);

        CreateContextMenu();
        LoadProperties();
        LoadYears();

        // Auto-load availability on form open
        LoadAvailability();
    }

    private void CreateContextMenu()
    {
        _cellContextMenu = new ContextMenuStrip();

        _menuNewBooking = new ToolStripMenuItem("New Booking...");
        _menuNewBooking.Click += MenuNewBooking_Click;

        _menuBlockRoom = new ToolStripMenuItem("Block Room...");
        _menuBlockRoom.Click += MenuBlockRoom_Click;

        _menuRemoveBlackout = new ToolStripMenuItem("Remove Blackout");
        _menuRemoveBlackout.Click += MenuRemoveBlackout_Click;

        _menuViewBooking = new ToolStripMenuItem("View/Edit Booking...");
        _menuViewBooking.Click += MenuViewBooking_Click;

        _cellContextMenu.Items.AddRange(new ToolStripItem[] {
            _menuNewBooking,
            _menuBlockRoom,
            new ToolStripSeparator(),
            _menuRemoveBlackout,
            new ToolStripSeparator(),
            _menuViewBooking
        });
    }

    private void LoadProperties()
    {
        var properties = _dbContext.Properties
            .Where(p => !p.IsObsolete)
            .OrderBy(p => p.Location)
            .Select(p => new { p.AccountNumber, Display = p.Location })
            .ToList();

        properties.Insert(0, new { AccountNumber = 0, Display = "(All Properties)" });

        cboProperty.DataSource = properties;
        cboProperty.DisplayMember = "Display";
        cboProperty.ValueMember = "AccountNumber";
    }

    private void LoadYears()
    {
        var currentYear = DateTime.Now.Year;
        var years = new List<int>();
        for (int y = currentYear - 2; y <= currentYear + 2; y++)
        {
            years.Add(y);
        }

        cboYear.DataSource = years;
        cboYear.SelectedItem = currentYear;
        _selectedYear = currentYear;
    }

    private void cboProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Don't auto-refresh on property change to avoid slow updates
    }

    private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboYear.SelectedItem is int year)
        {
            _selectedYear = year;
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadAvailability();
    }

    private void LoadAvailability()
    {
        Cursor = Cursors.WaitCursor;
        try
        {
            var selectedProperty = cboProperty.SelectedValue as int? ?? 0;

            // Get properties to display
            var propertiesQuery = _dbContext.Properties
                .Where(p => !p.IsObsolete);

            if (selectedProperty > 0)
            {
                propertiesQuery = propertiesQuery.Where(p => p.AccountNumber == selectedProperty);
            }

            _properties = propertiesQuery.OrderBy(p => p.Location).ToList();

            // Get room types for these properties
            var propertyIds = _properties.Select(p => p.AccountNumber).ToList();
            _roomTypes = _dbContext.RoomTypes
                .Where(r => propertyIds.Contains(r.PropertyAccountNumber))
                .OrderBy(r => r.PropertyAccountNumber)
                .ThenBy(r => r.Name)
                .ToList();

            // Get accommodations for the entire year
            var yearStart = new DateTime(_selectedYear, 1, 1);
            var yearEnd = new DateTime(_selectedYear, 12, 31);

            var accommodationsQuery = _dbContext.Accommodations
                .Where(a => a.ArrivalDate <= yearEnd && a.DepartureDate >= yearStart);

            if (selectedProperty > 0)
            {
                accommodationsQuery = accommodationsQuery.Where(a => a.PropertyAccountNumber == selectedProperty);
            }

            _accommodations = accommodationsQuery.ToList();

            // Get blackouts for the selected room types in the year
            var roomTypeIds = _roomTypes.Select(r => r.Id).ToList();
            _blackouts = _dbContext.RoomBlackouts
                .Where(b => roomTypeIds.Contains(b.RoomTypeId)
                         && b.StartDate <= yearEnd
                         && b.EndDate >= yearStart)
                .ToList();

            // Build the monthly grids
            BuildYearView();

            if (_roomTypes.Count == 0)
            {
                lblStatus.Text = $"No rooms found. Properties have {_dbContext.RoomTypes.Count()} total room types defined.";
            }
            else
            {
                lblStatus.Text = $"Showing {_roomTypes.Count} rooms across {_properties.Count} properties for {_selectedYear}";
            }
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void BuildYearView()
    {
        pnlCalendars.SuspendLayout();
        pnlCalendars.Controls.Clear();
        _monthGrids.Clear();

        if (_roomTypes.Count == 0)
        {
            var lblNoRooms = new Label
            {
                Text = "No rooms found for the selected property.",
                AutoSize = true,
                Font = new Font(Font.FontFamily, 12),
                Margin = new Padding(20)
            };
            pnlCalendars.Controls.Add(lblNoRooms);
            pnlCalendars.ResumeLayout();
            return;
        }

        // Create 12 grids, one for each month (FlowLayoutPanel handles positioning)
        for (int month = 1; month <= 12; month++)
        {
            var monthStart = new DateTime(_selectedYear, month, 1);
            var daysInMonth = DateTime.DaysInMonth(_selectedYear, month);

            // Month header label
            var lblMonth = new Label
            {
                Text = monthStart.ToString("MMMM yyyy"),
                Font = new Font(Font.FontFamily, 11, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(10, 15, 10, 5)
            };
            pnlCalendars.Controls.Add(lblMonth);

            // Create DataGridView for this month
            var gridWidth = 150 + (daysInMonth * 25) + 3;
            var gridHeight = 25 + (_roomTypes.Count * 22) + 3;

            // Extra bottom margin for December to ensure it's fully visible
            var bottomMargin = (month == 12) ? 120 : 10;

            var dgv = new DataGridView
            {
                Size = new Size(gridWidth, gridHeight),
                Margin = new Padding(10, 0, 10, bottomMargin),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 25,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                RowTemplate = { Height = 22 },
                ScrollBars = ScrollBars.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None,
                BorderStyle = BorderStyle.FixedSingle,
                CellBorderStyle = DataGridViewCellBorderStyle.Single,
                GridColor = Color.LightGray,
                Tag = month,
                SelectionMode = DataGridViewSelectionMode.CellSelect,
                MultiSelect = false
            };

            dgv.CellDoubleClick += MonthGrid_CellDoubleClick;
            dgv.CellMouseClick += MonthGrid_CellMouseClick;

            // Configure columns: Room name + days
            dgv.Columns.Add("Room", "Room");
            dgv.Columns["Room"].Width = 150;
            dgv.Columns["Room"].Frozen = true;

            for (int day = 1; day <= daysInMonth; day++)
            {
                var date = new DateTime(_selectedYear, month, day);
                var colName = $"Day{day}";
                dgv.Columns.Add(colName, day.ToString());
                dgv.Columns[colName].Width = 25;
                dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    dgv.Columns[colName].DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
                }
            }

            // Add rows for each room type
            foreach (var roomType in _roomTypes)
            {
                var property = _properties.FirstOrDefault(p => p.AccountNumber == roomType.PropertyAccountNumber);
                if (property == null) continue;

                var rowIndex = dgv.Rows.Add();
                var row = dgv.Rows[rowIndex];

                var roomDisplay = $"{roomType.Description ?? roomType.Name}";
                row.Cells[0].Value = roomDisplay;
                row.Cells[0].ToolTipText = $"{property.Location}\n{roomType.Description ?? roomType.Name}";

                row.Tag = new RoomTypeInfo
                {
                    RoomTypeId = roomType.Id,
                    PropertyAccountNumber = roomType.PropertyAccountNumber,
                    PropertyLocation = property.Location,
                    RoomTypeName = roomType.Name,
                    RoomTypeDescription = roomType.Description ?? roomType.Name
                };

                var monthEnd = monthStart.AddMonths(1).AddDays(-1);
                var roomAccoms = _accommodations
                    .Where(a => a.PropertyAccountNumber == roomType.PropertyAccountNumber
                             && a.UnitName == roomType.Name
                             && a.ArrivalDate <= monthEnd
                             && a.DepartureDate >= monthStart)
                    .ToList();

                var roomBlackouts = _blackouts
                    .Where(b => b.RoomTypeId == roomType.Id
                             && b.StartDate <= monthEnd
                             && b.EndDate >= monthStart)
                    .ToList();

                for (int day = 1; day <= daysInMonth; day++)
                {
                    var date = new DateTime(_selectedYear, month, day);
                    var booking = roomAccoms
                        .FirstOrDefault(a => a.ArrivalDate <= date && a.DepartureDate > date);

                    if (booking != null)
                    {
                        row.Cells[day].Style.BackColor = Color.LightCoral;
                        row.Cells[day].ToolTipText = $"{booking.FirstName} {booking.LastName}\nConf# {booking.ConfirmationNumber}\n{booking.ArrivalDate:MM/dd} - {booking.DepartureDate:MM/dd}";
                    }
                    else
                    {
                        // Check for blackout
                        var blackout = roomBlackouts
                            .FirstOrDefault(b => b.StartDate <= date && b.EndDate >= date);

                        if (blackout != null)
                        {
                            row.Cells[day].Style.BackColor = Color.FromArgb(255, 200, 100);
                            row.Cells[day].ToolTipText = $"BLOCKED: {blackout.Reason}\n{blackout.StartDate:MM/dd} - {blackout.EndDate:MM/dd}";
                        }
                        else
                        {
                            var isWeekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
                            if (!isWeekend)
                            {
                                row.Cells[day].Style.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }

            _monthGrids[month] = dgv;
            pnlCalendars.Controls.Add(dgv);
        }

        pnlCalendars.ResumeLayout(true);
    }

    private void MonthGrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (sender is not DataGridView dgv) return;
        if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

        var row = dgv.Rows[e.RowIndex];
        var roomInfo = row.Tag as RoomTypeInfo;
        if (roomInfo == null) return;

        var month = (int)(dgv.Tag ?? 1);
        var day = e.ColumnIndex;
        var clickedDate = new DateTime(_selectedYear, month, day);

        // Check for booking
        var booking = _accommodations
            .FirstOrDefault(a => a.PropertyAccountNumber == roomInfo.PropertyAccountNumber &&
                       a.UnitName == roomInfo.RoomTypeName &&
                       a.ArrivalDate <= clickedDate &&
                       a.DepartureDate > clickedDate);

        if (booking != null)
        {
            MessageBox.Show(
                $"Booking Information\n\n" +
                $"Room: {roomInfo.RoomTypeDescription}\n" +
                $"Property: {roomInfo.PropertyLocation}\n" +
                $"Date: {clickedDate:dddd, MMMM d, yyyy}\n\n" +
                $"Guest: {booking.FirstName} {booking.LastName}\n" +
                $"Confirmation #: {booking.ConfirmationNumber}\n" +
                $"Arrival: {booking.ArrivalDate:MM/dd/yyyy}\n" +
                $"Departure: {booking.DepartureDate:MM/dd/yyyy}",
                "Booking Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        // Check for blackout
        var blackout = _blackouts
            .FirstOrDefault(b => b.RoomTypeId == roomInfo.RoomTypeId &&
                       b.StartDate <= clickedDate &&
                       b.EndDate >= clickedDate);

        if (blackout != null)
        {
            MessageBox.Show(
                $"Blackout Information\n\n" +
                $"Room: {roomInfo.RoomTypeDescription}\n" +
                $"Property: {roomInfo.PropertyLocation}\n" +
                $"Date: {clickedDate:dddd, MMMM d, yyyy}\n\n" +
                $"Reason: {blackout.Reason}\n" +
                $"Start: {blackout.StartDate:MM/dd/yyyy}\n" +
                $"End: {blackout.EndDate:MM/dd/yyyy}",
                "Blackout Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        // Available
        MessageBox.Show(
            $"Room Available\n\n" +
            $"Room: {roomInfo.RoomTypeDescription}\n" +
            $"Property: {roomInfo.PropertyLocation}\n" +
            $"Date: {clickedDate:dddd, MMMM d, yyyy}\n\n" +
            $"This room is available for booking.\n" +
            $"Right-click for options.",
            "Availability",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void MonthGrid_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        if (sender is not DataGridView dgv) return;
        if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

        var row = dgv.Rows[e.RowIndex];
        var roomInfo = row.Tag as RoomTypeInfo;
        if (roomInfo == null) return;

        var month = (int)(dgv.Tag ?? 1);
        var day = e.ColumnIndex;
        var clickedDate = new DateTime(_selectedYear, month, day);

        // Store context for menu handlers
        _contextMenuGrid = dgv;
        _contextMenuRow = e.RowIndex;
        _contextMenuCol = e.ColumnIndex;

        // Check cell state to determine which menu items to show
        var hasBooking = _accommodations.Any(a =>
            a.PropertyAccountNumber == roomInfo.PropertyAccountNumber &&
            a.UnitName == roomInfo.RoomTypeName &&
            a.ArrivalDate <= clickedDate &&
            a.DepartureDate > clickedDate);

        var blackout = _blackouts.FirstOrDefault(b =>
            b.RoomTypeId == roomInfo.RoomTypeId &&
            b.StartDate <= clickedDate &&
            b.EndDate >= clickedDate);

        var hasBlackout = blackout != null;

        // Configure menu visibility based on cell state
        _menuNewBooking.Visible = !hasBooking && !hasBlackout;
        _menuBlockRoom.Visible = !hasBooking && !hasBlackout;
        _menuRemoveBlackout.Visible = hasBlackout;
        _menuViewBooking.Visible = hasBooking;

        // Update separator visibility
        _cellContextMenu.Items[2].Visible = (!hasBooking && !hasBlackout) || hasBlackout;
        _cellContextMenu.Items[4].Visible = hasBlackout && hasBooking;

        // Show menu at cursor position
        var cellRect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
        _cellContextMenu.Show(dgv, new Point(cellRect.Left + e.X, cellRect.Top + e.Y));
    }

    private void MenuNewBooking_Click(object? sender, EventArgs e)
    {
        if (_contextMenuGrid == null) return;

        var row = _contextMenuGrid.Rows[_contextMenuRow];
        var roomInfo = row.Tag as RoomTypeInfo;
        if (roomInfo == null) return;

        var month = (int)(_contextMenuGrid.Tag ?? 1);
        var day = _contextMenuCol;
        var clickedDate = new DateTime(_selectedYear, month, day);

        using var form = new AccommodationForm(_dbContext, roomInfo.PropertyAccountNumber, roomInfo.RoomTypeName, clickedDate);
        form.ShowDialog(this);
        LoadAvailability();
    }

    private void MenuBlockRoom_Click(object? sender, EventArgs e)
    {
        if (_contextMenuGrid == null) return;

        var row = _contextMenuGrid.Rows[_contextMenuRow];
        var roomInfo = row.Tag as RoomTypeInfo;
        if (roomInfo == null) return;

        var month = (int)(_contextMenuGrid.Tag ?? 1);
        var day = _contextMenuCol;
        var clickedDate = new DateTime(_selectedYear, month, day);

        using var form = new RoomBlackoutForm(_dbContext, roomInfo.RoomTypeId, roomInfo.RoomTypeDescription, clickedDate);
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            LoadAvailability();
        }
    }

    private void MenuRemoveBlackout_Click(object? sender, EventArgs e)
    {
        if (_contextMenuGrid == null) return;

        var row = _contextMenuGrid.Rows[_contextMenuRow];
        var roomInfo = row.Tag as RoomTypeInfo;
        if (roomInfo == null) return;

        var month = (int)(_contextMenuGrid.Tag ?? 1);
        var day = _contextMenuCol;
        var clickedDate = new DateTime(_selectedYear, month, day);

        var blackout = _blackouts.FirstOrDefault(b =>
            b.RoomTypeId == roomInfo.RoomTypeId &&
            b.StartDate <= clickedDate &&
            b.EndDate >= clickedDate);

        if (blackout != null)
        {
            var result = MessageBox.Show(
                $"Remove blackout for {roomInfo.RoomTypeDescription}?\n\n" +
                $"Dates: {blackout.StartDate:MM/dd/yyyy} - {blackout.EndDate:MM/dd/yyyy}\n" +
                $"Reason: {blackout.Reason}",
                "Confirm Remove Blackout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _dbContext.RoomBlackouts.Remove(blackout);
                _dbContext.SaveChanges();
                LoadAvailability();
            }
        }
    }

    private void MenuViewBooking_Click(object? sender, EventArgs e)
    {
        if (_contextMenuGrid == null) return;

        var row = _contextMenuGrid.Rows[_contextMenuRow];
        var roomInfo = row.Tag as RoomTypeInfo;
        if (roomInfo == null) return;

        var month = (int)(_contextMenuGrid.Tag ?? 1);
        var day = _contextMenuCol;
        var clickedDate = new DateTime(_selectedYear, month, day);

        var booking = _dbContext.Accommodations
            .FirstOrDefault(a => a.PropertyAccountNumber == roomInfo.PropertyAccountNumber &&
                       a.UnitName == roomInfo.RoomTypeName &&
                       a.ArrivalDate <= clickedDate &&
                       a.DepartureDate > clickedDate);

        if (booking != null)
        {
            using var form = new AccommodationForm(_dbContext, booking.ConfirmationNumber);
            form.ShowDialog(this);
            LoadAvailability();
        }
    }

    private void btnPreview_Click(object sender, EventArgs e)
    {
        ShowReport(autoPrint: false);
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        ShowReport(autoPrint: true);
    }

    private void ShowReport(bool autoPrint)
    {
        var yearStart = new DateTime(_selectedYear, 1, 1);
        var yearEnd = new DateTime(_selectedYear, 12, 31);

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new AvailabilityReport(yearStart, yearEnd, _properties, _roomTypes, _accommodations, companyInfo);
        using var viewer = new ReportViewerForm(report, autoPrint);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Helper class to store room type information for grid rows.
    /// </summary>
    private class RoomTypeInfo
    {
        public int RoomTypeId { get; set; }
        public int PropertyAccountNumber { get; set; }
        public string PropertyLocation { get; set; } = string.Empty;
        public string RoomTypeName { get; set; } = string.Empty;
        public string RoomTypeDescription { get; set; } = string.Empty;
    }
}
