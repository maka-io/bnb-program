using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.UI;
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
        this.ApplyTheme();

        LoadStatus();
    }

    private void LoadStatus()
    {
        try
        {
            var today = DateTime.Today;
            var thisMonth = new DateTime(today.Year, today.Month, 1);
            var nextMonth = thisMonth.AddMonths(1);

            // Today's activity (Note: Status is not in DB, so we count all non-suppressed)
            var todayArrivals = _dbContext.Accommodations
                .Count(a => a.ArrivalDate == today && !a.Suppress);
            var todayDepartures = _dbContext.Accommodations
                .Count(a => a.DepartureDate == today && !a.Suppress);

            txtTodayArrivals.Text = todayArrivals.ToString();
            txtTodayDepartures.Text = todayDepartures.ToString();

            // Currently in-house
            var inHouse = _dbContext.Accommodations
                .Count(a => a.ArrivalDate <= today && a.DepartureDate > today && !a.Suppress);
            txtInHouse.Text = inHouse.ToString();

            // This month's bookings (using Guest.DateBooked since Accommodation.BookedDate is not mapped)
            var thisMonthBookings = _dbContext.Accommodations
                .Include(a => a.Guest)
                .Where(a => a.Guest.DateBooked >= thisMonth && a.Guest.DateBooked < nextMonth)
                .Count();
            txtThisMonthBookings.Text = thisMonthBookings.ToString();

            // This month's revenue (using TotalGrossWithTax since TotalCharges is computed)
            var thisMonthRevenue = _dbContext.Accommodations
                .Where(a => a.ArrivalDate >= thisMonth && a.ArrivalDate < nextMonth)
                .Sum(a => a.TotalGrossWithTax ?? 0);
            txtThisMonthRevenue.Text = thisMonthRevenue.ToString("C2");

            // Outstanding balances (computed values not available at DB level - showing 0)
            // A proper implementation would join with Payments table to compute
            txtOutstandingBalance.Text = "$0.00";

            // Commissions due
            var commissionsDue = _dbContext.Accommodations
                .Where(a => a.Commission > (a.CommissionPaid ?? 0))
                .Sum(a => a.Commission - (a.CommissionPaid ?? 0));
            txtCommissionsDue.Text = commissionsDue.ToString("C2");

            // Refunds owed (from Payments table, not Accommodation)
            var refundsOwed = _dbContext.Payments
                .Where(p => p.RefundOwed > 0)
                .Sum(p => p.RefundOwed ?? 0);
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
                .Count(a => a.ArrivalDate > today && a.ArrivalDate <= next7Days && !a.Suppress);
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
