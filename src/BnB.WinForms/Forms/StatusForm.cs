using BnB.Core.Models;
using BnB.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Status display form - migrated from Status.frm
/// Shows current system status and statistics.
/// </summary>
public partial class StatusForm : Form
{
    private readonly BnBDbContext _dbContext;

    public StatusForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void StatusForm_Load(object sender, EventArgs e)
    {
        LoadStatus();
    }

    private void LoadStatus()
    {
        try
        {
            var today = DateTime.Today;
            var thisMonth = new DateTime(today.Year, today.Month, 1);
            var nextMonth = thisMonth.AddMonths(1);

            // Today's activity
            var todayArrivals = _dbContext.Accommodations
                .Count(a => a.ArrivalDate == today && a.Status != "Cancelled");
            var todayDepartures = _dbContext.Accommodations
                .Count(a => a.DepartureDate == today && a.Status != "Cancelled");

            txtTodayArrivals.Text = todayArrivals.ToString();
            txtTodayDepartures.Text = todayDepartures.ToString();

            // Currently in-house
            var inHouse = _dbContext.Accommodations
                .Count(a => a.ArrivalDate <= today && a.DepartureDate > today && a.Status != "Cancelled");
            txtInHouse.Text = inHouse.ToString();

            // This month's bookings
            var thisMonthBookings = _dbContext.Accommodations
                .Where(a => a.BookedDate >= thisMonth && a.BookedDate < nextMonth)
                .Count();
            txtThisMonthBookings.Text = thisMonthBookings.ToString();

            // This month's revenue
            var thisMonthRevenue = _dbContext.Accommodations
                .Where(a => a.ArrivalDate >= thisMonth && a.ArrivalDate < nextMonth)
                .Sum(a => a.TotalCharges ?? 0);
            txtThisMonthRevenue.Text = thisMonthRevenue.ToString("C2");

            // Outstanding balances
            var outstandingBalance = _dbContext.Accommodations
                .Where(a => a.BalanceDue > 0)
                .Sum(a => a.BalanceDue ?? 0);
            txtOutstandingBalance.Text = outstandingBalance.ToString("C2");

            // Commissions due
            var commissionsDue = _dbContext.Accommodations
                .Where(a => a.Commission > (a.CommissionPaid ?? 0))
                .Sum(a => a.Commission - (a.CommissionPaid ?? 0));
            txtCommissionsDue.Text = commissionsDue.ToString("C2");

            // Refunds owed
            var refundsOwed = _dbContext.Accommodations
                .Where(a => a.RefundOwed > 0)
                .Sum(a => a.RefundOwed ?? 0);
            txtRefundsOwed.Text = refundsOwed.ToString("C2");

            // Database counts
            var guestCount = _dbContext.Guests.Count();
            var propertyCount = _dbContext.Properties.Count();
            var accommodationCount = _dbContext.Accommodations.Count();

            txtGuestCount.Text = guestCount.ToString("N0");
            txtPropertyCount.Text = propertyCount.ToString("N0");
            txtAccommodationCount.Text = accommodationCount.ToString("N0");

            // Upcoming (next 7 days)
            var next7Days = today.AddDays(7);
            var upcomingArrivals = _dbContext.Accommodations
                .Count(a => a.ArrivalDate > today && a.ArrivalDate <= next7Days && a.Status != "Cancelled");
            txtUpcomingArrivals.Text = upcomingArrivals.ToString();

            lblLastUpdated.Text = $"Last updated: {DateTime.Now:g}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading status: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadStatus();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
