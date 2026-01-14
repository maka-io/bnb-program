using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Booking List form - migrated from BListing.frm
/// Displays a list of bookings with filtering and export options.
/// </summary>
public partial class BookingListForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();
    private List<Accommodation> _accommodations = new();

    public BookingListForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void BookingListForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        LoadProperties();

        // Default date range - 15 days before and after today
        dtpStartDate.Value = DateTime.Today.AddDays(-15);
        dtpEndDate.Value = DateTime.Today.AddDays(15);

        cboDateField.Items.AddRange(new object[] { "Arrival Date", "Departure Date", "Booked Date" });
        cboDateField.SelectedIndex = 0;

        cboStatus.Items.AddRange(new object[] { "(All)", "Active", "Cancelled", "Forfeit" });
        cboStatus.SelectedIndex = 0;

        // Wire up resize event
        this.Resize += BookingListForm_Resize;
        ResizeControls();

        // Auto search on load
        LoadBookings();
    }

    private void BookingListForm_Resize(object? sender, EventArgs e)
    {
        ResizeControls();
    }

    private void ResizeControls()
    {
        // Manually size and position the controls
        int filterHeight = 75;
        int bottomHeight = 50;
        int gridTop = filterHeight;
        int gridHeight = this.ClientSize.Height - filterHeight - bottomHeight;

        pnlFilter.Location = new Point(0, 0);
        pnlFilter.Size = new Size(this.ClientSize.Width, filterHeight);

        dgvBookings.Location = new Point(0, gridTop);
        dgvBookings.Size = new Size(this.ClientSize.Width, gridHeight);

        pnlBottom.Location = new Point(0, this.ClientSize.Height - bottomHeight);
        pnlBottom.Size = new Size(this.ClientSize.Width, bottomHeight);
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

    private void btnSearch_Click(object sender, EventArgs e)
    {
        LoadBookings();
    }

    private void LoadBookings()
    {
        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;
        var selectedProperty = cboProperty.SelectedValue as int? ?? 0;
        var dateField = cboDateField.SelectedIndex;

        IQueryable<Accommodation> query = _dbContext.Accommodations
            .Include(a => a.Guest)
            .Include(a => a.Property);

        // Apply date filter based on selected field
        query = dateField switch
        {
            0 => query.Where(a => a.ArrivalDate >= startDate && a.ArrivalDate <= endDate),
            1 => query.Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate),
            2 => query.Where(a => a.Guest.DateBooked >= startDate && a.Guest.DateBooked <= endDate),
            _ => query
        };

        // Apply property filter
        if (selectedProperty > 0)
        {
            query = query.Where(a => a.PropertyAccountNumber == selectedProperty);
        }

        // Apply status filter
        var status = cboStatus.SelectedItem?.ToString();
        if (status != "(All)")
        {
            query = status switch
            {
                "Active" => query.Where(a => !a.Suppress && !a.Forfeit),
                "Cancelled" => query.Where(a => a.Suppress),
                "Forfeit" => query.Where(a => a.Forfeit),
                _ => query
            };
        }

        // Apply search text filter
        var searchText = txtSearch.Text.Trim();
        if (!string.IsNullOrEmpty(searchText))
        {
            query = query.Where(a =>
                a.ConfirmationNumber.ToString().Contains(searchText) ||
                (a.FirstName != null && a.FirstName.Contains(searchText)) ||
                (a.LastName != null && a.LastName.Contains(searchText)) ||
                (a.Location != null && a.Location.Contains(searchText)));
        }

        _accommodations = query
            .OrderBy(a => a.ArrivalDate)
            .ToList();

        _bindingSource.DataSource = _accommodations;
        dgvBookings.DataSource = _bindingSource;
        ConfigureGrid();

        UpdateSummary();
    }

    private void ConfigureGrid()
    {
        if (dgvBookings.Columns.Count == 0) return;

        // Hide internal columns
        foreach (DataGridViewColumn col in dgvBookings.Columns)
        {
            col.Visible = false;
        }

        // Show and configure visible columns
        ShowColumn("ConfirmationNumber", "Conf #", 75);
        ShowColumn("FirstName", "First Name", 100, fill: true);
        ShowColumn("LastName", "Last Name", 100, fill: true);
        ShowColumn("Location", "Property", 150, fill: true);
        ShowColumn("BookedDate", "Booked", 90, "MM/dd/yyyy");
        ShowColumn("ArrivalDate", "Arrival", 90, "MM/dd/yyyy");
        ShowColumn("DepartureDate", "Departure", 90, "MM/dd/yyyy");
        ShowColumn("NumberOfNights", "Nights", 55);
        ShowColumn("NumberInParty", "Guests", 55);
        ShowColumn("TotalGrossWithTax", "Total", 90, "C2");
    }

    private void ShowColumn(string name, string header, int width, string? format = null, bool fill = false)
    {
        if (!dgvBookings.Columns.Contains(name)) return;

        var col = dgvBookings.Columns[name];
        col.Visible = true;
        col.HeaderText = header;
        col.MinimumWidth = width;

        if (fill)
        {
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        else
        {
            col.Width = width;
        }

        if (format != null)
        {
            col.DefaultCellStyle.Format = format;
            if (format == "C2")
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
    }

    private void UpdateSummary()
    {
        var count = _accommodations.Count;
        var totalNights = _accommodations.Sum(a => a.NumberOfNights);
        var totalAmount = _accommodations.Sum(a => a.TotalGrossWithTax);
        var totalGuests = _accommodations.Sum(a => a.NumberInParty ?? 1);

        lblSummary.Text = $"Bookings: {count} | Total Nights: {totalNights} | Total Guests: {totalGuests} | Total: {totalAmount:C2}";
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        if (_accommodations.Count == 0)
        {
            MessageBox.Show("No data to export.", "Export",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var saveDialog = new SaveFileDialog
        {
            Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
            DefaultExt = "csv",
            FileName = $"BookingList_{DateTime.Now:yyyyMMdd}.csv"
        };

        if (saveDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                using var writer = new StreamWriter(saveDialog.FileName);
                // Header
                writer.WriteLine("Conf#,First Name,Last Name,Property,Arrival,Departure,Nights,Guests,Total");

                // Data
                foreach (var accom in _accommodations)
                {
                    writer.WriteLine($"{accom.ConfirmationNumber}," +
                        $"\"{accom.FirstName}\"," +
                        $"\"{accom.LastName}\"," +
                        $"\"{accom.Location}\"," +
                        $"{accom.ArrivalDate:MM/dd/yyyy}," +
                        $"{accom.DepartureDate:MM/dd/yyyy}," +
                        $"{accom.NumberOfNights}," +
                        $"{accom.NumberInParty ?? 1}," +
                        $"{accom.TotalGrossWithTax:F2}");
                }

                MessageBox.Show($"Exported {_accommodations.Count} records to:\n{saveDialog.FileName}",
                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        if (_accommodations.Count == 0)
        {
            MessageBox.Show("No data to print. Please run a search first.", "Print",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var startDate = dtpStartDate.Value.Date;
        var endDate = dtpEndDate.Value.Date;
        var dateField = cboDateField.SelectedItem?.ToString() ?? "Arrival Date";

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new BookingListReport(startDate, endDate, dateField, _accommodations, companyInfo);
        using var viewer = new ReportViewerForm(report, autoPrint);
        viewer.ShowDialog(this);
    }

    private void btnPrintConfirmation_Click(object sender, EventArgs e)
    {
        if (dgvBookings.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a booking first.", "Print Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (dgvBookings.SelectedRows[0].DataBoundItem is not Accommodation accom)
            return;

        // Load the full guest and accommodations data
        var guest = _dbContext.Guests
            .FirstOrDefault(g => g.ConfirmationNumber == accom.ConfirmationNumber);

        if (guest == null)
        {
            MessageBox.Show("Guest record not found.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var accommodations = _dbContext.Accommodations
            .Include(a => a.Property)
            .Where(a => a.ConfirmationNumber == accom.ConfirmationNumber)
            .ToList();

        var payment = _dbContext.Payments
            .FirstOrDefault(p => p.ConfirmationNumber == accom.ConfirmationNumber);

        // Calculate deposit and prepayment totals
        decimal totalDeposit = payment?.DepositDue ?? 0;
        decimal totalPrepayment = payment?.PrepaymentDue ?? 0;

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new ConfirmationReport(
            guest,
            accommodations,
            payment,
            "Standard",
            "Guest",
            totalDeposit,
            totalPrepayment,
            null,
            null,
            companyInfo);

        using var viewer = new ReportViewerForm(report, autoPrint: true);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvBookings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        if (dgvBookings.Rows[e.RowIndex].DataBoundItem is Accommodation accom)
        {
            // Could open accommodation form here
            MessageBox.Show(
                $"Confirmation #: {accom.ConfirmationNumber}\n" +
                $"Guest: {accom.FirstName} {accom.LastName}\n" +
                $"Property: {accom.Location}\n" +
                $"Dates: {accom.ArrivalDate:MM/dd/yyyy} - {accom.DepartureDate:MM/dd/yyyy}\n" +
                $"Nights: {accom.NumberOfNights}\n" +
                $"Total: {accom.TotalGrossWithTax:C2}",
                "Booking Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
