using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BnB.WinForms.Forms;

/// <summary>
/// Main MDI container form - migrated from MDIBNB.FRM
/// </summary>
public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;

    public MainForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // Set window state
        WindowState = FormWindowState.Maximized;

        // Update title with version
        Text = $"BnB - Hawaii's Best Bed & Breakfasts v{Application.ProductVersion}";
    }

    #region File Menu Handlers

    private void mnuBackup_Click(object sender, EventArgs e)
    {
        using var dialog = new BackupRestoreForm(restoreMode: false);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                var dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "BnB", "bnb.db");

                File.Copy(dbPath, dialog.SelectedFilePath, overwrite: true);
                MessageBox.Show("Database backup completed successfully.", "Backup Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating backup: {ex.Message}", "Backup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void mnuCommonText_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CommonTextForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CommonTextForm(dbContext);
        });
    }

    private void mnuPrinterSetup_Click(object sender, EventArgs e)
    {
        using var dialog = new PrintDialog();
        dialog.ShowDialog(this);
    }

    private void mnuExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    #endregion

    #region Guests Menu Handlers

    private void mnuGeneralInfo_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<GuestForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new GuestForm(dbContext);
        });
    }

    private void mnuAccommodations_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<AccommodationForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new AccommodationForm(dbContext);
        });
    }

    private void mnuTravelAgent_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<TravelAgentBookingForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new TravelAgentBookingForm(dbContext);
        });
    }

    private void mnuCarReservations_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CarRentalBookingForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CarRentalBookingForm(dbContext);
        });
    }

    private void mnuPayments_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<PaymentForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new PaymentForm(dbContext);
        });
    }

    #endregion

    #region Accounts Menu Handlers

    private void mnuHostProperties_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<PropertyForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new PropertyForm(dbContext);
        });
    }

    private void mnuTravelAgencies_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<TravelAgencyForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new TravelAgencyForm(dbContext);
        });
    }

    private void mnuCarRentalAgencies_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CarAgencyForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CarAgencyForm(dbContext);
        });
    }

    #endregion

    #region Taxes Menu Handlers

    private void mnuSetTaxRates_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<TaxRateForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new TaxRateForm(dbContext);
        });
    }

    private void mnuSetTaxPlans_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<TaxPlanForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new TaxPlanForm(dbContext);
        });
    }

    #endregion

    #region View Menu Handlers

    private void mnuCascade_Click(object sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.Cascade);
    }

    private void mnuTileHorizontal_Click(object sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void mnuTileVertical_Click(object sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileVertical);
    }

    #endregion

    #region Availability Menu Handlers

    private void mnuRoomAvailability_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<AvailabilityForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new AvailabilityForm(dbContext);
        });
    }

    private void mnuCarAvailability_Click(object sender, EventArgs e)
    {
        // Car availability is a separate concept - for now show a message
        MessageBox.Show("Car Availability feature coming soon.", "Car Availability",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    #endregion

    #region Admin Menu Handlers

    private void mnuPropertyFacts_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<FactListForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new FactListForm(dbContext);
        });
    }

    private void mnuCompanyInfo_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CompanyInfoForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CompanyInfoForm(dbContext);
        });
    }

    private void mnuRestoreDatabase_Click(object sender, EventArgs e)
    {
        using var dialog = new BackupRestoreForm(restoreMode: true);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                var dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "BnB", "bnb.db");

                File.Copy(dialog.SelectedFilePath, dbPath, overwrite: true);
                MessageBox.Show("Database restored successfully. Please restart the application.", "Restore Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error restoring database: {ex.Message}", "Restore Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #endregion

    #region Reports Menu Handlers

    private void mnuConfirmations_Click(object sender, EventArgs e)
    {
        // Open guest search to select a confirmation to print
        MessageBox.Show("Please use the Guest form to print confirmations for specific guests.",
            "Print Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void mnuArrivals_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Arrivals Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var arrivals = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.ArrivalDate >= startDate && a.ArrivalDate <= endDate)
                .OrderBy(a => a.ArrivalDate)
                .ToList();

            var report = new ArrivalsReport(startDate, endDate, arrivals);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuDepartures_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Departures Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var departures = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .OrderBy(a => a.DepartureDate)
                .ToList();

            var report = new DeparturesReport(startDate, endDate, departures);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuCheckLedger_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Check Ledger Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var checks = dbContext.Checks
                .Include(c => c.Accommodation)
                .ThenInclude(a => a.Guest)
                .Where(c => c.CheckDate >= startDate && c.CheckDate <= endDate)
                .AsEnumerable()
                .Select(c => new CheckRecord
                {
                    CheckNumber = int.TryParse(c.CheckNumber, out var num) ? num : 0,
                    CheckDate = c.CheckDate,
                    PayTo = c.PayTo,
                    ConfirmationNumber = c.Accommodation.ConfirmationNumber,
                    GuestLastName = c.Accommodation.LastName,
                    Location = c.Accommodation.Location,
                    Category = "Host Payment", // Default category
                    Amount = c.Amount,
                    IsVoid = c.IsVoid
                })
                .OrderBy(c => c.CheckDate)
                .ThenBy(c => c.CheckNumber)
                .ToList();

            var report = new CheckLedgerReport(startDate, endDate, checks);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuNetSummary_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Net Summary Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var accommodations = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .OrderBy(a => a.Property.FullName)
                .ThenBy(a => a.DepartureDate)
                .ToList();

            var report = new NetSummaryReport(startDate, endDate, accommodations);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuCommission_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Commission Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var accommodations = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .Where(a => a.Commission > 0 && a.Commission > 0)
                .OrderBy(a => a.Property.FullName)
                .ThenBy(a => a.DepartureDate)
                .ToList();

            var report = new CommissionReport(startDate, endDate, accommodations);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuHost1099_Click(object sender, EventArgs e)
    {
        // Show year selection dialog
        var currentYear = DateTime.Now.Year;
        var taxYear = ShowYearSelectionDialog(currentYear - 1);
        if (!taxYear.HasValue)
            return;

        var startDate = new DateTime(taxYear.Value, 1, 1);
        var endDate = new DateTime(taxYear.Value, 12, 31);

        var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();

        // Get host 1099 data by aggregating checks written to each host
        var hostData = dbContext.Checks
            .Include(c => c.Accommodation)
            .ThenInclude(a => a.Property)
            .Where(c => c.CheckDate >= startDate && c.CheckDate <= endDate && !c.IsVoid)
            .AsEnumerable()
            .GroupBy(c => c.Accommodation.Property)
            .Select(g => new Host1099Data
            {
                AccountNumber = g.Key.PropertyId,
                HostName = g.Key.FullName,
                Address = g.Key.MailingAddress,
                City = g.Key.MailingCity,
                State = g.Key.MailingState,
                ZipCode = g.Key.MailingZipCode,
                FederalTaxId = g.Key.FederalTaxId,
                TotalPaid = g.Sum(c => c.Amount),
                ReservationCount = g.Count()
            })
            .OrderBy(h => h.HostName)
            .ToList();

        var report = new Host1099Report(taxYear.Value, hostData);
        using var viewer = new ReportViewerForm(report);
        viewer.ShowDialog(this);
    }

    /// <summary>
    /// Shows a dialog to select a year for tax reporting
    /// </summary>
    private int? ShowYearSelectionDialog(int defaultYear)
    {
        using var dialog = new Form
        {
            Text = "Select Tax Year",
            Size = new Size(280, 150),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var lblYear = new Label { Text = "Tax Year:", Location = new Point(20, 25), AutoSize = true };
        var numYear = new NumericUpDown
        {
            Location = new Point(100, 22),
            Width = 100,
            Minimum = 1990,
            Maximum = DateTime.Now.Year,
            Value = defaultYear
        };

        var btnOK = new Button
        {
            Text = "OK",
            Location = new Point(60, 70),
            Width = 75,
            DialogResult = DialogResult.OK
        };

        var btnCancel = new Button
        {
            Text = "Cancel",
            Location = new Point(145, 70),
            Width = 75,
            DialogResult = DialogResult.Cancel
        };

        dialog.Controls.AddRange(new Control[] { lblYear, numYear, btnOK, btnCancel });
        dialog.AcceptButton = btnOK;
        dialog.CancelButton = btnCancel;

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            return (int)numYear.Value;
        }
        return null;
    }

    private void mnuTrends_Click(object sender, EventArgs e)
    {
        var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
        using var dialog = new TrendsDialogForm(dbContext);
        dialog.ShowDialog(this);
    }

    private void mnuArrivalsDeparts_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<ArrivalDepartureForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new ArrivalDepartureForm(dbContext);
        });
    }

    private void mnuDailyBooking_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Daily Booking Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var bookings = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.BookedDate >= startDate && a.BookedDate <= endDate)
                .OrderBy(a => a.BookedDate)
                .ToList();

            var report = new DailyBookingReport(startDate, endDate, bookings);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuHostNotification_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Host Notification Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var arrivals = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.ArrivalDate >= startDate && a.ArrivalDate <= endDate)
                .OrderBy(a => a.Property.Location)
                .ThenBy(a => a.ArrivalDate)
                .ToList();

            var report = new HostNotificationReport(startDate, endDate, arrivals);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuServiceFeeSummary_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Service Fee Summary Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var accommodations = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .OrderBy(a => a.DepartureDate)
                .ToList();

            var report = new ServiceFeeSummaryReport(startDate, endDate, accommodations);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuPayRecSummary_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<PaymentReceivedForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new PaymentReceivedForm(dbContext);
        });
    }

    private void mnuClientTrust_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Client Trust Reconciliation", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var payments = dbContext.Payments
                .Include(p => p.Accommodation)
                    .ThenInclude(a => a.Guest)
                .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
                .OrderBy(p => p.PaymentDate)
                .ToList();

            var report = new ClientTrustReport(startDate, endDate, payments);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuPayReceivable_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<PaymentReceivableForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new PaymentReceivableForm(dbContext);
        });
    }

    private void mnuRefunds_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Refunds Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var refunds = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.RefundOwed > 0 && a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .OrderBy(a => a.DepartureDate)
                .ToList();

            var report = new RefundsReport(startDate, endDate, refunds);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuOverpayments_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Overpayments Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var overpayments = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.TotalPaid > a.TotalCharges && a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .OrderBy(a => a.Property.Location)
                .ThenBy(a => a.DepartureDate)
                .ToList();

            var report = new OverpaymentsReport(startDate, endDate, overpayments);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuHostAcctInfo_Click(object sender, EventArgs e)
    {
        var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
        var properties = dbContext.Properties
            .OrderBy(p => p.Location)
            .ToList();

        var report = new HostAccountInfoReport(properties);
        using var viewer = new ReportViewerForm(report);
        viewer.ShowDialog(this);
    }

    private void mnuCarRentalActivity_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Car Rental Activity Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var rentals = dbContext.Set<CarRental>()
                .Include(r => r.Guest)
                .Include(r => r.CarAgency)
                .Where(r => r.PickupDate >= startDate && r.PickupDate <= endDate)
                .OrderBy(r => r.PickupDate)
                .ToList();

            var report = new CarRentalActivityReport(startDate, endDate, rentals);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    /// <summary>
    /// Shows a simple date range selection dialog and executes the report callback
    /// </summary>
    private void ShowDateRangeReport(string reportTitle, Action<DateTime, DateTime> generateReport)
    {
        using var dialog = new Form
        {
            Text = $"Select Date Range - {reportTitle}",
            Size = new Size(350, 200),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var lblStart = new Label { Text = "Start Date:", Location = new Point(20, 25), AutoSize = true };
        var dtpStart = new DateTimePicker
        {
            Location = new Point(120, 22),
            Width = 180,
            Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        };

        var lblEnd = new Label { Text = "End Date:", Location = new Point(20, 60), AutoSize = true };
        var dtpEnd = new DateTimePicker
        {
            Location = new Point(120, 57),
            Width = 180,
            Value = DateTime.Now
        };

        var btnOK = new Button
        {
            Text = "Generate Report",
            Location = new Point(80, 110),
            Width = 100,
            DialogResult = DialogResult.OK
        };

        var btnCancel = new Button
        {
            Text = "Cancel",
            Location = new Point(190, 110),
            Width = 80,
            DialogResult = DialogResult.Cancel
        };

        dialog.Controls.AddRange(new Control[] { lblStart, dtpStart, lblEnd, dtpEnd, btnOK, btnCancel });
        dialog.AcceptButton = btnOK;
        dialog.CancelButton = btnCancel;

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                generateReport(dtpStart.Value.Date, dtpEnd.Value.Date);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }

    #endregion

    #region Accounting Menu Handlers

    private void mnuPrintChecks_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CheckPrintForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CheckPrintForm(dbContext);
        });
    }

    private void mnuViewEditChecks_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CheckLedgerReportForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CheckLedgerReportForm(dbContext);
        });
    }

    private void mnuSetCheckNumbers_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CheckNumberForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CheckNumberForm(dbContext);
        });
    }

    private void mnuViewEditPayments_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<PaymentReceivedForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new PaymentReceivedForm(dbContext);
        });
    }

    #endregion

    #region Help Menu Handlers

    private void mnuHelpTopics_Click(object sender, EventArgs e)
    {
        // Display help information
        var helpText = @"BnB - Bed & Breakfast Reservation System Help

Getting Started:
- Use the Guests menu to manage guest information, accommodations, and payments
- Use the Accounts menu to manage host properties and agency accounts
- Use the Reports menu to generate various business reports

Key Features:
- Guest Management: Track guest information and reservations
- Property Management: Manage host properties and room types
- Payment Processing: Record and track payments
- Reporting: Generate comprehensive business reports
- Tax Management: Configure tax rates and plans

Navigation:
- Use Ctrl+X to exit the application
- Press F1 for help

For additional support, please contact your system administrator.";

        MessageBox.Show(helpText, "Help Topics",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void mnuAbout_Click(object sender, EventArgs e)
    {
        MessageBox.Show(
            $"BnB - Bed & Breakfast Reservation System\n\n" +
            $"Version: {Application.ProductVersion}\n" +
            $"Hawaii's Best Bed & Breakfasts\n\n" +
            $"Modernized from VB5 to .NET 8",
            "About BnB",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    #endregion

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Check if any child forms have unsaved changes
        foreach (Form child in MdiChildren)
        {
            // TODO: Check for unsaved changes
        }
    }

    /// <summary>
    /// Opens a new MDI child form or activates an existing one of the same type.
    /// </summary>
    private void OpenOrActivateForm<T>(Func<T> formFactory) where T : Form
    {
        // Check if form of this type is already open
        foreach (Form child in MdiChildren)
        {
            if (child is T existingForm)
            {
                existingForm.Activate();
                return;
            }
        }

        // Create and show new form
        var form = formFactory();
        form.MdiParent = this;
        form.Show();
    }
}
