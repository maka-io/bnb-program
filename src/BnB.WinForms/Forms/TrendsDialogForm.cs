using BnB.Data.Context;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Trends Analysis Dialog - migrated from TRENDDLG.FRM
/// Provides options for generating trend analysis reports.
/// </summary>
public partial class TrendsDialogForm : Form
{
    private readonly BnBDbContext _dbContext;

    public DateTime StartDate => dtpStartDate.Value.Date;
    public DateTime EndDate => dtpEndDate.Value.Date;
    public string ShowMetric { get; private set; } = "RoomNights";
    public string GroupBy { get; private set; } = "Property";
    public string? PropertyName => optProperty.Checked && cboProperty.SelectedItem != null ? cboProperty.SelectedItem.ToString() : null;
    public int Frequency => int.TryParse(txtFrequency.Text, out var val) ? val : 1;
    public int Threshold => int.TryParse(txtThreshold.Text, out var val) ? val : 10;
    public bool Cancelled { get; private set; } = true;

    public TrendsDialogForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void TrendsDialogForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        // Set defaults
        optRoomNights.Checked = true;
        optProperty.Checked = true;
        txtFrequency.Text = "1";
        txtThreshold.Text = "10";
        hsbFrequency.Value = 1;
        hsbThreshold.Value = 10;

        // Set default date range: 3 months ago to today
        dtpEndDate.Value = DateTime.Today;
        dtpStartDate.Value = DateTime.Today.AddMonths(-3);

        LoadProperties();
    }

    private void LoadProperties()
    {
        try
        {
            var properties = _dbContext.Properties
                .Where(p => !p.IsObsolete)
                .OrderBy(p => p.Location)
                .Select(p => p.Location)
                .ToList();

            cboProperty.Items.Clear();
            foreach (var prop in properties)
            {
                cboProperty.Items.Add(prop);
            }

            if (cboProperty.Items.Count > 0)
                cboProperty.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading properties: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        // Determine what to show
        if (optRoomNights.Checked)
            ShowMetric = "RoomNights";
        else if (optServiceFee.Checked)
            ShowMetric = "ServiceFee";
        else if (optResFee.Checked)
            ShowMetric = "ReservationFee";
        else if (optBookings.Checked)
            ShowMetric = "Bookings";

        // Determine grouping
        if (optProperty.Checked)
            GroupBy = "Property";
        else if (optMonth.Checked)
            GroupBy = "Month";
        else if (optYear.Checked)
            GroupBy = "Year";

        Cancelled = false;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Cancelled = true;
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private bool ValidateInput()
    {
        // Validate date range
        if (dtpStartDate.Value > dtpEndDate.Value)
        {
            MessageBox.Show("Starting date cannot be greater than ending date.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpStartDate.Focus();
            return false;
        }

        return true;
    }

    private void hsbFrequency_Scroll(object sender, ScrollEventArgs e)
    {
        txtFrequency.Text = hsbFrequency.Value.ToString();
    }

    private void hsbThreshold_Scroll(object sender, ScrollEventArgs e)
    {
        txtThreshold.Text = hsbThreshold.Value.ToString();
    }

    private void txtFrequency_Leave(object sender, EventArgs e)
    {
        if (int.TryParse(txtFrequency.Text, out var val))
        {
            if (val < hsbFrequency.Minimum) val = hsbFrequency.Minimum;
            if (val > hsbFrequency.Maximum) val = hsbFrequency.Maximum;
            hsbFrequency.Value = val;
            txtFrequency.Text = val.ToString();
        }
        else
        {
            txtFrequency.Text = hsbFrequency.Value.ToString();
        }
    }

    private void txtThreshold_Leave(object sender, EventArgs e)
    {
        if (int.TryParse(txtThreshold.Text, out var val))
        {
            if (val < hsbThreshold.Minimum) val = hsbThreshold.Minimum;
            if (val > hsbThreshold.Maximum) val = hsbThreshold.Maximum;
            hsbThreshold.Value = val;
            txtThreshold.Text = val.ToString();
        }
        else
        {
            txtThreshold.Text = hsbThreshold.Value.ToString();
        }
    }

    private void optBookings_CheckedChanged(object sender, EventArgs e)
    {
        if (optBookings.Checked || optResFee.Checked)
        {
            // These don't support Property grouping
            if (optProperty.Checked)
            {
                optMonth.Checked = true;
            }
            optProperty.Enabled = false;
            cboProperty.Enabled = false;
        }
    }

    private void optRoomNights_CheckedChanged(object sender, EventArgs e)
    {
        optProperty.Enabled = true;
        cboProperty.Enabled = optProperty.Checked;
    }

    private void optServiceFee_CheckedChanged(object sender, EventArgs e)
    {
        optProperty.Enabled = true;
        cboProperty.Enabled = optProperty.Checked;
    }

    private void optProperty_CheckedChanged(object sender, EventArgs e)
    {
        cboProperty.Enabled = optProperty.Checked;
    }
}
