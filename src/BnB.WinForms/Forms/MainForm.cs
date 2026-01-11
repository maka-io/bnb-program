using System.ComponentModel;
using BnB.Data.Context;
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
        MessageBox.Show("Database backup functionality will be implemented.", "Backup",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void mnuCommonText_Click(object sender, EventArgs e)
    {
        // TODO: Open Common Text form
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
        // TODO: Open Accommodations form
    }

    private void mnuTravelAgent_Click(object sender, EventArgs e)
    {
        // TODO: Open Travel Agency form
    }

    private void mnuCarReservations_Click(object sender, EventArgs e)
    {
        // TODO: Open Car Reservations form
    }

    private void mnuPayments_Click(object sender, EventArgs e)
    {
        // TODO: Open Payments form
    }

    #endregion

    #region Accounts Menu Handlers

    private void mnuHostProperties_Click(object sender, EventArgs e)
    {
        // TODO: Open Host Properties form
    }

    private void mnuTravelAgencies_Click(object sender, EventArgs e)
    {
        // TODO: Open Travel Agencies form
    }

    private void mnuCarRentalAgencies_Click(object sender, EventArgs e)
    {
        // TODO: Open Car Rental Agencies form
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

    #region Help Menu Handlers

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
