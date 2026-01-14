using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Arrival/Departure report form - migrated from ArrDep.frm
/// Shows arrivals and departures for a date range.
/// </summary>
public partial class ArrivalDepartureForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _arrivalsBinding = new();
    private BindingSource _departuresBinding = new();

    public ArrivalDepartureForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void ArrivalDepartureForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        // Default to today
        dtpDate.Value = DateTime.Today;
        LoadData();
    }

    private void dtpDate_ValueChanged(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        var selectedDate = dtpDate.Value.Date;
        var today = DateTime.Today;

        // Load arrivals - from selected date onwards, sorted by days until arrival
        var arrivalsData = _dbContext.Accommodations
            .Include(a => a.Property)
            .Include(a => a.Guest)
            .Where(a => a.ArrivalDate >= selectedDate && !a.Suppress)
            .ToList();

        var arrivals = arrivalsData
            .Select(a => new
            {
                a.ConfirmationNumber,
                GuestName = a.FirstName + " " + a.LastName,
                PropertyName = a.Property?.Location ?? "",
                a.ArrivalDate,
                DaysUntilArrival = (a.ArrivalDate - today).Days,
                a.NumberOfNights,
                a.NumberInParty,
                a.DepartureDate,
                SpecialRequests = a.Comments ?? ""
            })
            .OrderBy(a => a.DaysUntilArrival)
            .ThenBy(a => a.PropertyName)
            .ToList();

        _arrivalsBinding.DataSource = arrivals;
        dgvArrivals.DataSource = _arrivalsBinding;
        ConfigureGrid(dgvArrivals, true);

        // Load departures - from selected date onwards, only if already checked in (arrived)
        var departuresData = _dbContext.Accommodations
            .Include(a => a.Property)
            .Include(a => a.Guest)
            .Where(a => a.DepartureDate >= selectedDate && a.ArrivalDate <= today && !a.Suppress)
            .ToList();

        var departures = departuresData
            .Select(a => new
            {
                a.ConfirmationNumber,
                GuestName = a.FirstName + " " + a.LastName,
                PropertyName = a.Property?.Location ?? "",
                a.DepartureDate,
                DaysUntilCheckout = (a.DepartureDate - today).Days,
                a.ArrivalDate,
                a.NumberOfNights,
                BalanceDue = (decimal?)0
            })
            .OrderBy(a => a.DaysUntilCheckout)
            .ThenBy(a => a.PropertyName)
            .ToList();

        _departuresBinding.DataSource = departures;
        dgvDepartures.DataSource = _departuresBinding;
        ConfigureGrid(dgvDepartures, false);

        UpdateSummary(arrivals.Count, departures.Count);
    }

    private void ConfigureGrid(DataGridView dgv, bool isArrival)
    {
        if (dgv.Columns.Count == 0) return;

        if (dgv.Columns.Contains("ConfirmationNumber"))
        {
            dgv.Columns["ConfirmationNumber"].HeaderText = "Conf #";
            dgv.Columns["ConfirmationNumber"].Width = 70;
            dgv.Columns["ConfirmationNumber"].DisplayIndex = 0;
        }

        if (dgv.Columns.Contains("GuestName"))
        {
            dgv.Columns["GuestName"].HeaderText = "Guest";
            dgv.Columns["GuestName"].Width = 140;
            dgv.Columns["GuestName"].DisplayIndex = 1;
        }

        if (dgv.Columns.Contains("PropertyName"))
        {
            dgv.Columns["PropertyName"].HeaderText = "Property";
            dgv.Columns["PropertyName"].Width = 130;
            dgv.Columns["PropertyName"].DisplayIndex = 2;
        }

        if (dgv.Columns.Contains("NumberOfNights"))
        {
            dgv.Columns["NumberOfNights"].HeaderText = "Nights";
            dgv.Columns["NumberOfNights"].Width = 55;
            dgv.Columns["NumberOfNights"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        if (isArrival)
        {
            if (dgv.Columns.Contains("ArrivalDate"))
            {
                dgv.Columns["ArrivalDate"].HeaderText = "Arrival";
                dgv.Columns["ArrivalDate"].Width = 85;
                dgv.Columns["ArrivalDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                dgv.Columns["ArrivalDate"].DisplayIndex = 3;
            }

            if (dgv.Columns.Contains("DaysUntilArrival"))
            {
                dgv.Columns["DaysUntilArrival"].HeaderText = "Days Until";
                dgv.Columns["DaysUntilArrival"].Width = 70;
                dgv.Columns["DaysUntilArrival"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["DaysUntilArrival"].DisplayIndex = 4;
            }

            if (dgv.Columns.Contains("NumberInParty"))
            {
                dgv.Columns["NumberInParty"].HeaderText = "Guests";
                dgv.Columns["NumberInParty"].Width = 55;
                dgv.Columns["NumberInParty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgv.Columns.Contains("DepartureDate"))
            {
                dgv.Columns["DepartureDate"].HeaderText = "Departs";
                dgv.Columns["DepartureDate"].Width = 85;
                dgv.Columns["DepartureDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            }

            if (dgv.Columns.Contains("SpecialRequests"))
            {
                dgv.Columns["SpecialRequests"].HeaderText = "Notes";
                dgv.Columns["SpecialRequests"].Width = 100;
            }
        }
        else
        {
            if (dgv.Columns.Contains("DepartureDate"))
            {
                dgv.Columns["DepartureDate"].HeaderText = "Checkout";
                dgv.Columns["DepartureDate"].Width = 85;
                dgv.Columns["DepartureDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                dgv.Columns["DepartureDate"].DisplayIndex = 3;
            }

            if (dgv.Columns.Contains("DaysUntilCheckout"))
            {
                dgv.Columns["DaysUntilCheckout"].HeaderText = "Days Until";
                dgv.Columns["DaysUntilCheckout"].Width = 70;
                dgv.Columns["DaysUntilCheckout"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["DaysUntilCheckout"].DisplayIndex = 4;
            }

            if (dgv.Columns.Contains("ArrivalDate"))
            {
                dgv.Columns["ArrivalDate"].HeaderText = "Arrived";
                dgv.Columns["ArrivalDate"].Width = 85;
                dgv.Columns["ArrivalDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
            }

            if (dgv.Columns.Contains("BalanceDue"))
            {
                dgv.Columns["BalanceDue"].HeaderText = "Balance";
                dgv.Columns["BalanceDue"].Width = 80;
                dgv.Columns["BalanceDue"].DefaultCellStyle.Format = "C2";
                dgv.Columns["BalanceDue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
    }

    private void UpdateSummary(int arrivals, int departures)
    {
        lblSummary.Text = $"Arrivals: {arrivals} | Departures: {departures}";
    }

    private void btnPrevDay_Click(object sender, EventArgs e)
    {
        dtpDate.Value = dtpDate.Value.AddDays(-1);
    }

    private void btnNextDay_Click(object sender, EventArgs e)
    {
        dtpDate.Value = dtpDate.Value.AddDays(1);
    }

    private void btnToday_Click(object sender, EventArgs e)
    {
        dtpDate.Value = DateTime.Today;
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
        var selectedDate = dtpDate.Value.Date;

        var arrivals = _dbContext.Accommodations
            .Include(a => a.Property)
            .Include(a => a.Guest)
            .Where(a => a.ArrivalDate == selectedDate && !a.Suppress)
            .OrderBy(a => a.Property.Location)
            .ToList();

        var departures = _dbContext.Accommodations
            .Include(a => a.Property)
            .Include(a => a.Guest)
            .Where(a => a.DepartureDate == selectedDate && !a.Suppress)
            .OrderBy(a => a.Property.Location)
            .ToList();

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new ArrivalDepartureReport(selectedDate, arrivals, departures, companyInfo);
        using var viewer = new ReportViewerForm(report, autoPrint);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
