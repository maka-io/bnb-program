using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Overpayment tracking form - migrated from OverPay.frm
/// Tracks overpayments to host properties.
/// </summary>
public partial class OverpaymentForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();

    public OverpaymentForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void OverpaymentForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        LoadOverpayments();
    }

    private void LoadOverpayments()
    {
        // Find accommodations where commission paid exceeds commission due
        var overpayments = _dbContext.Accommodations
            .Include(a => a.Property)
            .Include(a => a.Guest)
            .Where(a => a.CommissionPaid > a.Commission)
            .Select(a => new
            {
                a.ConfirmationNumber,
                a.FirstName,
                a.LastName,
                PropertyName = a.Property.Location,
                a.Commission,
                a.CommissionPaid,
                Overpayment = a.CommissionPaid - a.Commission,
                a.DepartureDate
            })
            .OrderByDescending(a => a.Overpayment)
            .ToList();

        _bindingSource.DataSource = overpayments;
        dgvOverpayments.DataSource = _bindingSource;
        ConfigureGrid();

        var totalOverpayments = overpayments.Sum(o => o.Overpayment ?? 0);
        lblSummary.Text = $"Total Overpayments: {overpayments.Count} | Amount: {totalOverpayments:C2}";
    }

    private void ConfigureGrid()
    {
        if (dgvOverpayments.Columns.Count == 0) return;

        if (dgvOverpayments.Columns.Contains("ConfirmationNumber"))
        {
            dgvOverpayments.Columns["ConfirmationNumber"].HeaderText = "Conf #";
            dgvOverpayments.Columns["ConfirmationNumber"].Width = 80;
        }

        if (dgvOverpayments.Columns.Contains("PropertyName"))
        {
            dgvOverpayments.Columns["PropertyName"].HeaderText = "Property";
            dgvOverpayments.Columns["PropertyName"].Width = 150;
        }

        if (dgvOverpayments.Columns.Contains("Commission"))
        {
            dgvOverpayments.Columns["Commission"].HeaderText = "Commission Due";
            dgvOverpayments.Columns["Commission"].Width = 100;
            dgvOverpayments.Columns["Commission"].DefaultCellStyle.Format = "C2";
        }

        if (dgvOverpayments.Columns.Contains("CommissionPaid"))
        {
            dgvOverpayments.Columns["CommissionPaid"].HeaderText = "Paid";
            dgvOverpayments.Columns["CommissionPaid"].Width = 90;
            dgvOverpayments.Columns["CommissionPaid"].DefaultCellStyle.Format = "C2";
        }

        if (dgvOverpayments.Columns.Contains("Overpayment"))
        {
            dgvOverpayments.Columns["Overpayment"].HeaderText = "Overpayment";
            dgvOverpayments.Columns["Overpayment"].Width = 100;
            dgvOverpayments.Columns["Overpayment"].DefaultCellStyle.Format = "C2";
            dgvOverpayments.Columns["Overpayment"].DefaultCellStyle.ForeColor = Color.Red;
        }

        if (dgvOverpayments.Columns.Contains("DepartureDate"))
        {
            dgvOverpayments.Columns["DepartureDate"].HeaderText = "Departure";
            dgvOverpayments.Columns["DepartureDate"].Width = 90;
            dgvOverpayments.Columns["DepartureDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
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
        var overpayments = _dbContext.Accommodations
            .Include(a => a.Property)
            .Where(a => a.CommissionPaid > a.Commission)
            .Select(a => new CommissionOverpaymentItem
            {
                ConfirmationNumber = a.ConfirmationNumber,
                FirstName = a.FirstName ?? "",
                LastName = a.LastName ?? "",
                PropertyName = a.Property.Location ?? "",
                Commission = a.Commission,
                CommissionPaid = a.CommissionPaid ?? 0,
                Overpayment = (a.CommissionPaid ?? 0) - a.Commission,
                DepartureDate = a.DepartureDate
            })
            .OrderByDescending(a => a.Overpayment)
            .ToList();

        var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
        var report = new CommissionOverpaymentReport(overpayments, companyInfo);
        using var viewer = new ReportViewerForm(report, autoPrint);
        viewer.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
