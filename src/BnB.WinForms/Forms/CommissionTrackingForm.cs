using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Commission tracking form - migrated from CommTrck.frm
/// Tracks commissions owed and paid to properties.
/// </summary>
public partial class CommissionTrackingForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();

    public CommissionTrackingForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void CommissionTrackingForm_Load(object sender, EventArgs e)
    {
        LoadProperties();
        LoadCommissions();
    }

    private void LoadProperties()
    {
        cboProperty.Items.Clear();
        cboProperty.Items.Add("(All Properties)");

        var properties = _dbContext.Properties
            .Where(p => p.IsActive)
            .OrderBy(p => p.Location)
            .ToList();

        foreach (var property in properties)
        {
            cboProperty.Items.Add(property);
        }
        cboProperty.DisplayMember = "Location";
        cboProperty.SelectedIndex = 0;
    }

    private void LoadCommissions()
    {
        IQueryable<Accommodation> query = _dbContext.Accommodations
            .Include(a => a.Property)
            .Include(a => a.Guest)
            .Where(a => a.Commission > 0);

        // Filter by property
        if (cboProperty.SelectedIndex > 0 && cboProperty.SelectedItem is Property selectedProperty)
        {
            query = query.Where(a => a.PropertyId == selectedProperty.PropertyId);
        }

        // Filter by status
        if (chkShowUnpaidOnly.Checked)
        {
            query = query.Where(a => (a.CommissionPaid ?? 0) < a.Commission);
        }

        var commissions = query
            .OrderBy(a => a.Property.Location)
            .ThenBy(a => a.DepartureDate)
            .Select(a => new
            {
                a.AccommodationId,
                a.ConfirmationNumber,
                GuestName = a.FirstName + " " + a.LastName,
                PropertyName = a.Property.Location,
                a.DepartureDate,
                a.Commission,
                CommissionPaid = a.CommissionPaid ?? 0,
                CommissionDue = a.Commission - (a.CommissionPaid ?? 0)
            })
            .ToList();

        _bindingSource.DataSource = commissions;
        dgvCommissions.DataSource = _bindingSource;
        ConfigureGrid();
        UpdateSummary();
    }

    private void ConfigureGrid()
    {
        if (dgvCommissions.Columns.Count == 0) return;

        if (dgvCommissions.Columns.Contains("AccommodationId"))
            dgvCommissions.Columns["AccommodationId"].Visible = false;

        if (dgvCommissions.Columns.Contains("ConfirmationNumber"))
        {
            dgvCommissions.Columns["ConfirmationNumber"].HeaderText = "Conf #";
            dgvCommissions.Columns["ConfirmationNumber"].Width = 70;
        }

        if (dgvCommissions.Columns.Contains("GuestName"))
        {
            dgvCommissions.Columns["GuestName"].HeaderText = "Guest";
            dgvCommissions.Columns["GuestName"].Width = 130;
        }

        if (dgvCommissions.Columns.Contains("PropertyName"))
        {
            dgvCommissions.Columns["PropertyName"].HeaderText = "Property";
            dgvCommissions.Columns["PropertyName"].Width = 130;
        }

        if (dgvCommissions.Columns.Contains("DepartureDate"))
        {
            dgvCommissions.Columns["DepartureDate"].HeaderText = "Departure";
            dgvCommissions.Columns["DepartureDate"].Width = 90;
            dgvCommissions.Columns["DepartureDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        if (dgvCommissions.Columns.Contains("Commission"))
        {
            dgvCommissions.Columns["Commission"].HeaderText = "Commission";
            dgvCommissions.Columns["Commission"].Width = 90;
            dgvCommissions.Columns["Commission"].DefaultCellStyle.Format = "C2";
            dgvCommissions.Columns["Commission"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (dgvCommissions.Columns.Contains("CommissionPaid"))
        {
            dgvCommissions.Columns["CommissionPaid"].HeaderText = "Paid";
            dgvCommissions.Columns["CommissionPaid"].Width = 90;
            dgvCommissions.Columns["CommissionPaid"].DefaultCellStyle.Format = "C2";
            dgvCommissions.Columns["CommissionPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (dgvCommissions.Columns.Contains("CommissionDue"))
        {
            dgvCommissions.Columns["CommissionDue"].HeaderText = "Due";
            dgvCommissions.Columns["CommissionDue"].Width = 90;
            dgvCommissions.Columns["CommissionDue"].DefaultCellStyle.Format = "C2";
            dgvCommissions.Columns["CommissionDue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Color code due amounts
            foreach (DataGridViewRow row in dgvCommissions.Rows)
            {
                if (row.Cells["CommissionDue"].Value is decimal due && due > 0)
                {
                    row.Cells["CommissionDue"].Style.ForeColor = Color.Red;
                }
            }
        }
    }

    private void UpdateSummary()
    {
        decimal totalCommission = 0;
        decimal totalPaid = 0;
        decimal totalDue = 0;

        foreach (var item in _bindingSource.List)
        {
            var type = item.GetType();
            if (type.GetProperty("Commission")?.GetValue(item) is decimal comm)
                totalCommission += comm;
            if (type.GetProperty("CommissionPaid")?.GetValue(item) is decimal paid)
                totalPaid += paid;
            if (type.GetProperty("CommissionDue")?.GetValue(item) is decimal due)
                totalDue += due;
        }

        lblSummary.Text = $"Total: {totalCommission:C2} | Paid: {totalPaid:C2} | Due: {totalDue:C2}";
    }

    private void cboProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCommissions();
    }

    private void chkShowUnpaidOnly_CheckedChanged(object sender, EventArgs e)
    {
        LoadCommissions();
    }

    private void btnMarkPaid_Click(object sender, EventArgs e)
    {
        if (dgvCommissions.CurrentRow == null) return;

        var accommodationId = (int)dgvCommissions.CurrentRow.Cells["AccommodationId"].Value;
        var commission = (decimal)dgvCommissions.CurrentRow.Cells["Commission"].Value;
        var paid = (decimal)dgvCommissions.CurrentRow.Cells["CommissionPaid"].Value;
        var due = commission - paid;

        if (due <= 0)
        {
            MessageBox.Show("Commission is already fully paid.", "Already Paid",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = MessageBox.Show(
            $"Mark commission of {due:C2} as paid?",
            "Confirm Payment",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            var accommodation = _dbContext.Accommodations.Find(accommodationId);
            if (accommodation != null)
            {
                accommodation.CommissionPaid = commission;
                _dbContext.SaveChanges();
                LoadCommissions();
            }
        }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        IQueryable<Accommodation> query = _dbContext.Accommodations
            .Include(a => a.Property)
            .Where(a => a.Commission > 0);

        // Apply property filter
        if (cboProperty.SelectedIndex > 0 && cboProperty.SelectedItem is Property selectedProperty)
        {
            query = query.Where(a => a.PropertyId == selectedProperty.PropertyId);
        }

        // Apply status filter
        if (chkShowUnpaidOnly.Checked)
        {
            query = query.Where(a => (a.CommissionPaid ?? 0) < a.Commission);
        }

        var commissions = query
            .OrderBy(a => a.Property.Location)
            .ThenBy(a => a.DepartureDate)
            .Select(a => new CommissionTrackingItem
            {
                ConfirmationNumber = a.ConfirmationNumber,
                GuestName = (a.FirstName ?? "") + " " + (a.LastName ?? ""),
                PropertyName = a.Property.Location ?? "",
                DepartureDate = a.DepartureDate,
                Commission = a.Commission,
                CommissionPaid = a.CommissionPaid ?? 0,
                CommissionDue = a.Commission - (a.CommissionPaid ?? 0)
            })
            .ToList();

        var propertyFilter = cboProperty.SelectedItem is Property prop ? prop.Location : "(All Properties)";
        var report = new CommissionTrackingReport(commissions, propertyFilter ?? "(All Properties)", chkShowUnpaidOnly.Checked);
        using var viewer = new ReportViewerForm(report);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
