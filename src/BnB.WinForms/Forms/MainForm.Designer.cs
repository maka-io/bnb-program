namespace BnB.WinForms.Forms;

partial class MainForm
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
        this.components = new System.ComponentModel.Container();
        this.menuStrip = new MenuStrip();

        // File Menu
        this.mnuFile = new ToolStripMenuItem();
        this.mnuBackup = new ToolStripMenuItem();
        this.mnuCommonText = new ToolStripMenuItem();
        this.mnuPrinterSetup = new ToolStripMenuItem();
        this.mnuFileSeparator = new ToolStripSeparator();
        this.mnuExit = new ToolStripMenuItem();

        // Guests Menu
        this.mnuGuests = new ToolStripMenuItem();
        this.mnuGeneralInfo = new ToolStripMenuItem();
        this.mnuAccommodations = new ToolStripMenuItem();
        this.mnuTravelAgent = new ToolStripMenuItem();
        this.mnuCarReservations = new ToolStripMenuItem();
        this.mnuPayments = new ToolStripMenuItem();

        // Accounts Menu
        this.mnuAccounts = new ToolStripMenuItem();
        this.mnuHostProperties = new ToolStripMenuItem();
        this.mnuTravelAgencies = new ToolStripMenuItem();
        this.mnuCarRentalAgencies = new ToolStripMenuItem();

        // Availability Menu
        this.mnuAvailability = new ToolStripMenuItem();

        // Reports Menu
        this.mnuReports = new ToolStripMenuItem();
        this.mnuConfirmations = new ToolStripMenuItem();
        this.mnuArrivalsDeparts = new ToolStripMenuItem();
        this.mnuDailyReports = new ToolStripMenuItem();
        this.mnuDailyBooking = new ToolStripMenuItem();
        this.mnuArrivals = new ToolStripMenuItem();
        this.mnuDepartures = new ToolStripMenuItem();
        this.mnuHostNotification = new ToolStripMenuItem();
        this.mnuCheckLedger = new ToolStripMenuItem();
        this.mnuNetSummary = new ToolStripMenuItem();
        this.mnuServiceFeeSummary = new ToolStripMenuItem();
        this.mnuCommission = new ToolStripMenuItem();
        this.mnuPaymentsReceived = new ToolStripMenuItem();
        this.mnuPayRecSummary = new ToolStripMenuItem();
        this.mnuClientTrust = new ToolStripMenuItem();
        this.mnuPayReceivable = new ToolStripMenuItem();
        this.mnuRefunds = new ToolStripMenuItem();
        this.mnuOverpayments = new ToolStripMenuItem();
        this.mnuHost1099 = new ToolStripMenuItem();
        this.mnuHostAcctInfo = new ToolStripMenuItem();
        this.mnuCarRentalActivity = new ToolStripMenuItem();
        this.mnuTrends = new ToolStripMenuItem();

        // Accounting Menu
        this.mnuAccounting = new ToolStripMenuItem();
        this.mnuChecks = new ToolStripMenuItem();
        this.mnuPrintChecks = new ToolStripMenuItem();
        this.mnuViewEditChecks = new ToolStripMenuItem();
        this.mnuSetCheckNumbers = new ToolStripMenuItem();
        this.mnuViewEditPayments = new ToolStripMenuItem();

        // Taxes Menu
        this.mnuTaxes = new ToolStripMenuItem();
        this.mnuSetTaxRates = new ToolStripMenuItem();
        this.mnuSetTaxPlans = new ToolStripMenuItem();

        // View Menu
        this.mnuView = new ToolStripMenuItem();
        this.mnuCascade = new ToolStripMenuItem();
        this.mnuTileHorizontal = new ToolStripMenuItem();
        this.mnuTileVertical = new ToolStripMenuItem();

        // Admin Menu
        this.mnuAdmin = new ToolStripMenuItem();
        this.mnuPropertyFacts = new ToolStripMenuItem();
        this.mnuCompanyInfo = new ToolStripMenuItem();
        this.mnuRestoreDatabase = new ToolStripMenuItem();

        // Help Menu
        this.mnuHelp = new ToolStripMenuItem();
        this.mnuHelpTopics = new ToolStripMenuItem();
        this.mnuAbout = new ToolStripMenuItem();

        // Status Bar
        this.statusStrip = new StatusStrip();
        this.statusLabel = new ToolStripStatusLabel();

        this.SuspendLayout();

        // === Menu Strip ===
        this.menuStrip.Items.AddRange(new ToolStripItem[] {
            this.mnuFile, this.mnuGuests, this.mnuAccounts, this.mnuAvailability,
            this.mnuReports, this.mnuAccounting, this.mnuTaxes, this.mnuView,
            this.mnuAdmin, this.mnuHelp
        });
        this.menuStrip.Location = new Point(0, 0);
        this.menuStrip.Name = "menuStrip";
        this.menuStrip.Size = new Size(800, 24);

        // === File Menu ===
        this.mnuFile.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuBackup, this.mnuCommonText, this.mnuPrinterSetup,
            this.mnuFileSeparator, this.mnuExit
        });
        this.mnuFile.Text = "&File";

        this.mnuBackup.Text = "&Backup Database";
        this.mnuBackup.Click += mnuBackup_Click;

        this.mnuCommonText.Text = "Common &Text";
        this.mnuCommonText.Click += mnuCommonText_Click;

        this.mnuPrinterSetup.Text = "&Printer Setup...";
        this.mnuPrinterSetup.Click += mnuPrinterSetup_Click;

        this.mnuExit.Text = "E&xit";
        this.mnuExit.ShortcutKeys = Keys.Control | Keys.X;
        this.mnuExit.Click += mnuExit_Click;

        // === Guests Menu ===
        this.mnuGuests.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuGeneralInfo, this.mnuAccommodations, this.mnuTravelAgent,
            this.mnuCarReservations, this.mnuPayments
        });
        this.mnuGuests.Text = "&Guests";

        this.mnuGeneralInfo.Text = "&General Information";
        this.mnuGeneralInfo.Click += mnuGeneralInfo_Click;

        this.mnuAccommodations.Text = "&Accommodations";
        this.mnuAccommodations.Click += mnuAccommodations_Click;

        this.mnuTravelAgent.Text = "&Travel Agency";
        this.mnuTravelAgent.Click += mnuTravelAgent_Click;

        this.mnuCarReservations.Text = "&Car Reservations";
        this.mnuCarReservations.Click += mnuCarReservations_Click;

        this.mnuPayments.Text = "&Payments";
        this.mnuPayments.Click += mnuPayments_Click;

        // === Accounts Menu ===
        this.mnuAccounts.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuHostProperties, this.mnuTravelAgencies, this.mnuCarRentalAgencies
        });
        this.mnuAccounts.Text = "&Accounts";

        this.mnuHostProperties.Text = "&Host Properties";
        this.mnuHostProperties.Click += mnuHostProperties_Click;

        this.mnuTravelAgencies.Text = "&Travel Agencies";
        this.mnuTravelAgencies.Click += mnuTravelAgencies_Click;

        this.mnuCarRentalAgencies.Text = "&Car Rental Agencies";
        this.mnuCarRentalAgencies.Click += mnuCarRentalAgencies_Click;

        // === Availability Menu ===
        this.mnuAvailability.Text = "A&vailability";

        // === Reports Menu ===
        this.mnuReports.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuConfirmations, this.mnuArrivalsDeparts, this.mnuDailyReports,
            this.mnuCheckLedger, this.mnuNetSummary, this.mnuServiceFeeSummary,
            this.mnuCommission, this.mnuPaymentsReceived, this.mnuPayReceivable,
            this.mnuRefunds, this.mnuOverpayments, this.mnuHost1099,
            this.mnuHostAcctInfo, this.mnuCarRentalActivity, this.mnuTrends
        });
        this.mnuReports.Text = "&Reports";

        this.mnuConfirmations.Text = "C&onfirmation/Fee Summary Report";
        this.mnuArrivalsDeparts.Text = "&Arrivals/Departures";

        this.mnuDailyReports.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuDailyBooking, this.mnuArrivals, this.mnuDepartures, this.mnuHostNotification
        });
        this.mnuDailyReports.Text = "&Daily Reports";

        this.mnuDailyBooking.Text = "Daily &Booking Report";
        this.mnuArrivals.Text = "&Arrivals";
        this.mnuDepartures.Text = "&Departures";
        this.mnuHostNotification.Text = "&Host Notification Report";

        this.mnuCheckLedger.Text = "&Check Ledger Summary Report";
        this.mnuNetSummary.Text = "&Net Summary Report";
        this.mnuServiceFeeSummary.Text = "&Service Fee Summary Report";
        this.mnuCommission.Text = "Co&mmission Report";

        this.mnuPaymentsReceived.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuPayRecSummary, this.mnuClientTrust
        });
        this.mnuPaymentsReceived.Text = "&Payments Received";
        this.mnuPayRecSummary.Text = "Payments &Received Report";
        this.mnuClientTrust.Text = "&Client Trust Reconciliation";

        this.mnuPayReceivable.Text = "Pa&yments Receivable";
        this.mnuRefunds.Text = "&Refunds";
        this.mnuOverpayments.Text = "O&verpayments To Host Properties";
        this.mnuHost1099.Text = "&Host 1099 Tax Forms";
        this.mnuHostAcctInfo.Text = "Host Account &Information";
        this.mnuCarRentalActivity.Text = "Car R&ental Activity";
        this.mnuTrends.Text = "&Trends";

        // === Accounting Menu ===
        this.mnuAccounting.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuChecks, this.mnuViewEditPayments
        });
        this.mnuAccounting.Text = "A&ccounting";

        this.mnuChecks.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuPrintChecks, this.mnuViewEditChecks, this.mnuSetCheckNumbers
        });
        this.mnuChecks.Text = "&Checks";
        this.mnuPrintChecks.Text = "&Print Checks";
        this.mnuViewEditChecks.Text = "&View/Edit Printed Checks";
        this.mnuSetCheckNumbers.Text = "Set Check &Numbers";

        this.mnuViewEditPayments.Text = "&View/Edit Payments Received";

        // === Taxes Menu ===
        this.mnuTaxes.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuSetTaxRates, this.mnuSetTaxPlans
        });
        this.mnuTaxes.Text = "&Taxes";
        this.mnuSetTaxRates.Text = "Set Tax &Rates";
        this.mnuSetTaxRates.Click += mnuSetTaxRates_Click;
        this.mnuSetTaxPlans.Text = "Set Tax &Plans";
        this.mnuSetTaxPlans.Click += mnuSetTaxPlans_Click;

        // === View Menu ===
        this.mnuView.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuCascade, this.mnuTileHorizontal, this.mnuTileVertical
        });
        this.mnuView.Text = "&View";

        this.mnuCascade.Text = "&Cascade Forms";
        this.mnuCascade.Click += mnuCascade_Click;

        this.mnuTileHorizontal.Text = "Tile &Horizontal";
        this.mnuTileHorizontal.Click += mnuTileHorizontal_Click;

        this.mnuTileVertical.Text = "Tile &Vertical";
        this.mnuTileVertical.Click += mnuTileVertical_Click;

        // === Admin Menu ===
        this.mnuAdmin.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuPropertyFacts, this.mnuCompanyInfo, this.mnuRestoreDatabase
        });
        this.mnuAdmin.Text = "A&dmin";
        this.mnuPropertyFacts.Text = "&Property Facts Master List";
        this.mnuCompanyInfo.Text = "Company &Information";
        this.mnuCompanyInfo.Click += mnuCompanyInfo_Click;
        this.mnuRestoreDatabase.Text = "&Restore Database";

        // === Help Menu ===
        this.mnuHelp.DropDownItems.AddRange(new ToolStripItem[] {
            this.mnuHelpTopics, this.mnuAbout
        });
        this.mnuHelp.Text = "&Help";
        this.mnuHelpTopics.Text = "Help &Topics";
        this.mnuAbout.Text = "&About";
        this.mnuAbout.Click += mnuAbout_Click;

        // === Status Strip ===
        this.statusStrip.Items.AddRange(new ToolStripItem[] { this.statusLabel });
        this.statusStrip.Location = new Point(0, 428);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new Size(800, 22);

        this.statusLabel.Text = "Ready";

        // === MainForm ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1024, 768);
        this.Controls.Add(this.menuStrip);
        this.Controls.Add(this.statusStrip);
        this.IsMdiContainer = true;
        this.MainMenuStrip = this.menuStrip;
        this.Name = "MainForm";
        this.Text = "BnB";
        this.Load += MainForm_Load;
        this.FormClosing += MainForm_FormClosing;

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel statusLabel;

    // File Menu
    private ToolStripMenuItem mnuFile;
    private ToolStripMenuItem mnuBackup;
    private ToolStripMenuItem mnuCommonText;
    private ToolStripMenuItem mnuPrinterSetup;
    private ToolStripSeparator mnuFileSeparator;
    private ToolStripMenuItem mnuExit;

    // Guests Menu
    private ToolStripMenuItem mnuGuests;
    private ToolStripMenuItem mnuGeneralInfo;
    private ToolStripMenuItem mnuAccommodations;
    private ToolStripMenuItem mnuTravelAgent;
    private ToolStripMenuItem mnuCarReservations;
    private ToolStripMenuItem mnuPayments;

    // Accounts Menu
    private ToolStripMenuItem mnuAccounts;
    private ToolStripMenuItem mnuHostProperties;
    private ToolStripMenuItem mnuTravelAgencies;
    private ToolStripMenuItem mnuCarRentalAgencies;

    // Availability Menu
    private ToolStripMenuItem mnuAvailability;

    // Reports Menu
    private ToolStripMenuItem mnuReports;
    private ToolStripMenuItem mnuConfirmations;
    private ToolStripMenuItem mnuArrivalsDeparts;
    private ToolStripMenuItem mnuDailyReports;
    private ToolStripMenuItem mnuDailyBooking;
    private ToolStripMenuItem mnuArrivals;
    private ToolStripMenuItem mnuDepartures;
    private ToolStripMenuItem mnuHostNotification;
    private ToolStripMenuItem mnuCheckLedger;
    private ToolStripMenuItem mnuNetSummary;
    private ToolStripMenuItem mnuServiceFeeSummary;
    private ToolStripMenuItem mnuCommission;
    private ToolStripMenuItem mnuPaymentsReceived;
    private ToolStripMenuItem mnuPayRecSummary;
    private ToolStripMenuItem mnuClientTrust;
    private ToolStripMenuItem mnuPayReceivable;
    private ToolStripMenuItem mnuRefunds;
    private ToolStripMenuItem mnuOverpayments;
    private ToolStripMenuItem mnuHost1099;
    private ToolStripMenuItem mnuHostAcctInfo;
    private ToolStripMenuItem mnuCarRentalActivity;
    private ToolStripMenuItem mnuTrends;

    // Accounting Menu
    private ToolStripMenuItem mnuAccounting;
    private ToolStripMenuItem mnuChecks;
    private ToolStripMenuItem mnuPrintChecks;
    private ToolStripMenuItem mnuViewEditChecks;
    private ToolStripMenuItem mnuSetCheckNumbers;
    private ToolStripMenuItem mnuViewEditPayments;

    // Taxes Menu
    private ToolStripMenuItem mnuTaxes;
    private ToolStripMenuItem mnuSetTaxRates;
    private ToolStripMenuItem mnuSetTaxPlans;

    // View Menu
    private ToolStripMenuItem mnuView;
    private ToolStripMenuItem mnuCascade;
    private ToolStripMenuItem mnuTileHorizontal;
    private ToolStripMenuItem mnuTileVertical;

    // Admin Menu
    private ToolStripMenuItem mnuAdmin;
    private ToolStripMenuItem mnuPropertyFacts;
    private ToolStripMenuItem mnuCompanyInfo;
    private ToolStripMenuItem mnuRestoreDatabase;

    // Help Menu
    private ToolStripMenuItem mnuHelp;
    private ToolStripMenuItem mnuHelpTopics;
    private ToolStripMenuItem mnuAbout;
}
