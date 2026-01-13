using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Availability Calendar form - migrated from Avail.frm
/// Shows room availability for properties within a date range.
/// </summary>
public partial class AvailabilityForm : Form
{
    private readonly BnBDbContext _dbContext;

    public AvailabilityForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void AvailabilityForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        LoadProperties();
        LoadRoomTypes();

        // Default to current month
        dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        dtpEndDate.Value = dtpStartDate.Value.AddMonths(1).AddDays(-1);

        ConfigureCalendarGrid();
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

    private void LoadRoomTypes()
    {
        cboRoomType.Items.Clear();
        cboRoomType.Items.Add("(All Room Types)");

        if (cboProperty.SelectedValue is int accountNum && accountNum > 0)
        {
            var roomTypes = _dbContext.RoomTypes
                .Where(r => r.PropertyAccountNumber == accountNum)
                .OrderBy(r => r.Name)
                .Select(r => r.Name)
                .ToList();

            foreach (var rt in roomTypes)
            {
                cboRoomType.Items.Add(rt);
            }
        }

        cboRoomType.SelectedIndex = 0;
    }

    private void ConfigureCalendarGrid()
    {
        dgvCalendar.Columns.Clear();
        dgvCalendar.Rows.Clear();

        // Add property column
        dgvCalendar.Columns.Add("Property", "Property");
        dgvCalendar.Columns["Property"].Width = 150;
        dgvCalendar.Columns["Property"].Frozen = true;

        // Add date columns
        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;
        var days = (endDate - startDate).Days + 1;

        for (int i = 0; i < days; i++)
        {
            var date = startDate.AddDays(i);
            var colName = $"Day{i}";
            dgvCalendar.Columns.Add(colName, date.ToString("MM/dd"));
            dgvCalendar.Columns[colName].Width = 45;
            dgvCalendar.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Weekend highlighting
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                dgvCalendar.Columns[colName].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadAvailability();
    }

    private void LoadAvailability()
    {
        ConfigureCalendarGrid();

        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;
        var selectedProperty = cboProperty.SelectedValue as int? ?? 0;
        var selectedRoomType = cboRoomType.SelectedItem?.ToString();

        // Get properties to display
        var propertiesQuery = _dbContext.Properties
            .Where(p => !p.IsObsolete);

        if (selectedProperty > 0)
        {
            propertiesQuery = propertiesQuery.Where(p => p.AccountNumber == selectedProperty);
        }

        var properties = propertiesQuery.OrderBy(p => p.Location).ToList();

        // Get accommodations in date range
        var accommodationsQuery = _dbContext.Accommodations
            .Where(a => a.ArrivalDate <= endDate && a.DepartureDate >= startDate);

        if (selectedProperty > 0)
        {
            accommodationsQuery = accommodationsQuery.Where(a => a.PropertyAccountNumber == selectedProperty);
        }

        var accommodations = accommodationsQuery.ToList();

        // Build the grid
        foreach (var property in properties)
        {
            var row = new DataGridViewRow();
            row.CreateCells(dgvCalendar);
            row.Cells[0].Value = property.Location;

            var propertyAccoms = accommodations
                .Where(a => a.PropertyAccountNumber == property.AccountNumber)
                .ToList();

            var days = (endDate - startDate).Days + 1;
            for (int i = 0; i < days; i++)
            {
                var date = startDate.AddDays(i);

                // Count bookings for this date
                var bookingsOnDate = propertyAccoms
                    .Count(a => a.ArrivalDate <= date && a.DepartureDate > date);

                if (bookingsOnDate > 0)
                {
                    row.Cells[i + 1].Value = bookingsOnDate.ToString();
                    row.Cells[i + 1].Style.BackColor = Color.LightCoral;
                    row.Cells[i + 1].ToolTipText = $"{bookingsOnDate} booking(s)";
                }
                else
                {
                    row.Cells[i + 1].Style.BackColor = Color.LightGreen;
                }
            }

            dgvCalendar.Rows.Add(row);
        }

        lblStatus.Text = $"Showing {properties.Count} properties, {startDate:MM/dd/yyyy} - {endDate:MM/dd/yyyy}";
    }

    private void cboProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadRoomTypes();
    }

    private void dtpStartDate_ValueChanged(object sender, EventArgs e)
    {
        if (dtpEndDate.Value < dtpStartDate.Value)
        {
            dtpEndDate.Value = dtpStartDate.Value.AddMonths(1).AddDays(-1);
        }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;
        var selectedProperty = cboProperty.SelectedValue as int? ?? 0;

        // Get properties to display
        var propertiesQuery = _dbContext.Properties
            .Where(p => !p.IsObsolete);

        if (selectedProperty > 0)
        {
            propertiesQuery = propertiesQuery.Where(p => p.AccountNumber == selectedProperty);
        }

        var properties = propertiesQuery.OrderBy(p => p.Location).ToList();

        // Get accommodations in date range
        var accommodationsQuery = _dbContext.Accommodations
            .Where(a => a.ArrivalDate <= endDate && a.DepartureDate >= startDate);

        if (selectedProperty > 0)
        {
            accommodationsQuery = accommodationsQuery.Where(a => a.PropertyAccountNumber == selectedProperty);
        }

        var accommodations = accommodationsQuery.ToList();

        var report = new AvailabilityReport(startDate, endDate, properties, accommodations);
        using var viewer = new ReportViewerForm(report);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvCalendar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

        var propertyName = dgvCalendar.Rows[e.RowIndex].Cells[0].Value?.ToString();
        var startDate = dtpStartDate.Value.Date;
        var clickedDate = startDate.AddDays(e.ColumnIndex - 1);

        // Show bookings for this property/date
        var bookings = _dbContext.Accommodations
            .Include(a => a.Guest)
            .Where(a => a.Location == propertyName &&
                       a.ArrivalDate <= clickedDate &&
                       a.DepartureDate > clickedDate)
            .ToList();

        if (bookings.Any())
        {
            var message = $"Bookings for {propertyName} on {clickedDate:MM/dd/yyyy}:\n\n";
            foreach (var booking in bookings)
            {
                message += $"- Conf# {booking.ConfirmationNumber}: {booking.FirstName} {booking.LastName}\n";
                message += $"  {booking.ArrivalDate:MM/dd} - {booking.DepartureDate:MM/dd}\n\n";
            }

            MessageBox.Show(message, "Bookings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
