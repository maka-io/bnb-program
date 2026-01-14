using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Mailing Labels Form - allows printing address labels for guests or hosts
/// Migrated from Label1.frm and Label2.frm functionality
/// </summary>
public partial class MailingLabelsForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();
    private List<LabelData> _selectedLabels = new();

    public MailingLabelsForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        pnlTop = new Panel();
        lblTitle = new Label();
        grpLabelType = new GroupBox();
        rbGuests = new RadioButton();
        rbHosts = new RadioButton();
        grpFilter = new GroupBox();
        lblDateRange = new Label();
        dtpStartDate = new DateTimePicker();
        lblTo = new Label();
        dtpEndDate = new DateTimePicker();
        chkAllRecords = new CheckBox();
        btnLoad = new Button();
        dgvLabels = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnSelectAll = new Button();
        btnSelectNone = new Button();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvLabels).BeginInit();
        pnlTop.SuspendLayout();
        grpLabelType.SuspendLayout();
        grpFilter.SuspendLayout();
        pnlBottom.SuspendLayout();
        SuspendLayout();

        // pnlTop
        pnlTop.Controls.Add(lblTitle);
        pnlTop.Controls.Add(grpLabelType);
        pnlTop.Controls.Add(grpFilter);
        pnlTop.Controls.Add(btnLoad);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Size = new Size(800, 100);

        // lblTitle
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTitle.Location = new Point(12, 8);
        lblTitle.Text = "Mailing Labels";

        // grpLabelType
        grpLabelType.Controls.Add(rbGuests);
        grpLabelType.Controls.Add(rbHosts);
        grpLabelType.Location = new Point(12, 35);
        grpLabelType.Size = new Size(180, 55);
        grpLabelType.Text = "Label Type";

        // rbGuests
        rbGuests.AutoSize = true;
        rbGuests.Checked = true;
        rbGuests.Location = new Point(10, 22);
        rbGuests.Text = "Guests";
        rbGuests.CheckedChanged += rbLabelType_CheckedChanged;

        // rbHosts
        rbHosts.AutoSize = true;
        rbHosts.Location = new Point(90, 22);
        rbHosts.Text = "Hosts";
        rbHosts.CheckedChanged += rbLabelType_CheckedChanged;

        // grpFilter
        grpFilter.Controls.Add(lblDateRange);
        grpFilter.Controls.Add(dtpStartDate);
        grpFilter.Controls.Add(lblTo);
        grpFilter.Controls.Add(dtpEndDate);
        grpFilter.Controls.Add(chkAllRecords);
        grpFilter.Location = new Point(200, 35);
        grpFilter.Size = new Size(450, 55);
        grpFilter.Text = "Filter (Arrivals)";

        // lblDateRange
        lblDateRange.AutoSize = true;
        lblDateRange.Location = new Point(10, 24);
        lblDateRange.Text = "From:";

        // dtpStartDate
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(50, 20);
        dtpStartDate.Size = new Size(100, 23);
        dtpStartDate.Value = DateTime.Today;

        // lblTo
        lblTo.AutoSize = true;
        lblTo.Location = new Point(160, 24);
        lblTo.Text = "To:";

        // dtpEndDate
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(185, 20);
        dtpEndDate.Size = new Size(100, 23);
        dtpEndDate.Value = DateTime.Today.AddMonths(1);

        // chkAllRecords
        chkAllRecords.AutoSize = true;
        chkAllRecords.Location = new Point(300, 23);
        chkAllRecords.Text = "All Records";
        chkAllRecords.CheckedChanged += chkAllRecords_CheckedChanged;

        // btnLoad
        btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLoad.Location = new Point(700, 50);
        btnLoad.Size = new Size(85, 30);
        btnLoad.Text = "&Load";
        btnLoad.Click += btnLoad_Click;

        // dgvLabels
        dgvLabels.AllowUserToAddRows = false;
        dgvLabels.AllowUserToDeleteRows = false;
        dgvLabels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvLabels.Dock = DockStyle.Fill;
        dgvLabels.Location = new Point(0, 100);
        dgvLabels.MultiSelect = true;
        dgvLabels.RowHeadersWidth = 25;
        dgvLabels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvLabels.Size = new Size(800, 310);
        dgvLabels.TabIndex = 0;

        // pnlBottom
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnSelectAll);
        pnlBottom.Controls.Add(btnSelectNone);
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 410);
        pnlBottom.Size = new Size(800, 50);

        // lblSummary
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(13, 18);
        lblSummary.Text = "Click Load to retrieve addresses";

        // btnSelectAll
        btnSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSelectAll.Location = new Point(425, 11);
        btnSelectAll.Size = new Size(75, 28);
        btnSelectAll.Text = "Select &All";
        btnSelectAll.Click += btnSelectAll_Click;

        // btnSelectNone
        btnSelectNone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSelectNone.Location = new Point(506, 11);
        btnSelectNone.Size = new Size(85, 28);
        btnSelectNone.Text = "Select &None";
        btnSelectNone.Click += btnSelectNone_Click;

        // btnPreview
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(597, 11);
        btnPreview.Size = new Size(75, 28);
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;

        // btnPrint
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(678, 11);
        btnPrint.Size = new Size(50, 28);
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;

        // btnClose
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(734, 11);
        btnClose.Size = new Size(55, 28);
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;

        // MailingLabelsForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 460);
        Controls.Add(dgvLabels);
        Controls.Add(pnlTop);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(600, 400);
        Name = "MailingLabelsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Mailing Labels";
        Load += MailingLabelsForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvLabels).EndInit();
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        grpLabelType.ResumeLayout(false);
        grpLabelType.PerformLayout();
        grpFilter.ResumeLayout(false);
        grpFilter.PerformLayout();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    private Panel pnlTop;
    private Label lblTitle;
    private GroupBox grpLabelType;
    private RadioButton rbGuests;
    private RadioButton rbHosts;
    private GroupBox grpFilter;
    private Label lblDateRange;
    private DateTimePicker dtpStartDate;
    private Label lblTo;
    private DateTimePicker dtpEndDate;
    private CheckBox chkAllRecords;
    private Button btnLoad;
    private DataGridView dgvLabels;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnSelectAll;
    private Button btnSelectNone;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;

    private void MailingLabelsForm_Load(object sender, EventArgs e)
    {
        UpdateFilterVisibility();
    }

    private void rbLabelType_CheckedChanged(object sender, EventArgs e)
    {
        UpdateFilterVisibility();
    }

    private void chkAllRecords_CheckedChanged(object sender, EventArgs e)
    {
        dtpStartDate.Enabled = !chkAllRecords.Checked;
        dtpEndDate.Enabled = !chkAllRecords.Checked;
    }

    private void UpdateFilterVisibility()
    {
        grpFilter.Visible = rbGuests.Checked;
        grpFilter.Text = "Filter (Arrivals)";
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        try
        {
            Cursor = Cursors.WaitCursor;

            if (rbGuests.Checked)
            {
                LoadGuestLabels();
            }
            else
            {
                LoadHostLabels();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void LoadGuestLabels()
    {
        IQueryable<Guest> query;

        if (chkAllRecords.Checked)
        {
            query = _dbContext.Guests;
        }
        else
        {
            // Filter by arrival date range via accommodations
            var startDate = dtpStartDate.Value.Date;
            var endDate = dtpEndDate.Value.Date;

            var confirmationNumbers = _dbContext.Accommodations
                .Where(a => a.ArrivalDate >= startDate && a.ArrivalDate <= endDate)
                .Select(a => a.ConfirmationNumber)
                .Distinct()
                .ToList();

            query = _dbContext.Guests.Where(g => confirmationNumbers.Contains(g.ConfirmationNumber));
        }

        var guests = query
            .OrderBy(g => g.LastName)
            .ThenBy(g => g.FirstName)
            .ToList();

        _selectedLabels = guests.Select(g => new LabelData
        {
            Name = $"{g.FirstName} {g.LastName}".Trim(),
            Address = g.Address ?? g.BusinessAddress,
            City = g.City,
            State = g.State,
            ZipCode = g.ZipCode
        }).Where(l => !string.IsNullOrEmpty(l.Name)).ToList();

        DisplayLabels();
    }

    private void LoadHostLabels()
    {
        var properties = _dbContext.Properties
            .OrderBy(p => p.Location)
            .ToList();

        _selectedLabels = properties.Select(p =>
        {
            // Prefer mailing address, fall back to property address
            if (!string.IsNullOrEmpty(p.MailingAddress))
            {
                return new LabelData
                {
                    Name = p.Location,
                    Address = p.MailingAddress,
                    City = p.MailingCity,
                    State = p.MailingState,
                    ZipCode = p.MailingZipCode
                };
            }
            return new LabelData
            {
                Name = p.Location,
                Address = p.PropertyAddress,
                City = p.PropertyCity,
                State = p.PropertyState,
                ZipCode = p.PropertyZipCode
            };
        }).Where(l => !string.IsNullOrEmpty(l.Name)).ToList();

        DisplayLabels();
    }

    private void DisplayLabels()
    {
        var displayData = _selectedLabels.Select((l, index) => new
        {
            Index = index,
            Selected = true,
            l.Name,
            l.Address,
            l.City,
            l.State,
            l.ZipCode
        }).ToList();

        _bindingSource.DataSource = displayData;
        dgvLabels.DataSource = _bindingSource;

        ConfigureGrid();
        UpdateSummary();
    }

    private void ConfigureGrid()
    {
        if (dgvLabels.Columns.Count == 0) return;

        if (dgvLabels.Columns.Contains("Index"))
            dgvLabels.Columns["Index"].Visible = false;

        if (dgvLabels.Columns.Contains("Selected"))
        {
            dgvLabels.Columns["Selected"].HeaderText = "Print";
            dgvLabels.Columns["Selected"].Width = 50;
        }

        if (dgvLabels.Columns.Contains("Name"))
        {
            dgvLabels.Columns["Name"].Width = 150;
        }

        if (dgvLabels.Columns.Contains("Address"))
        {
            dgvLabels.Columns["Address"].Width = 200;
        }

        if (dgvLabels.Columns.Contains("City"))
        {
            dgvLabels.Columns["City"].Width = 120;
        }

        if (dgvLabels.Columns.Contains("State"))
        {
            dgvLabels.Columns["State"].Width = 50;
        }

        if (dgvLabels.Columns.Contains("ZipCode"))
        {
            dgvLabels.Columns["ZipCode"].HeaderText = "ZIP";
            dgvLabels.Columns["ZipCode"].Width = 80;
        }
    }

    private void UpdateSummary()
    {
        var total = _selectedLabels.Count;
        var selected = dgvLabels.SelectedRows.Count;
        lblSummary.Text = $"Loaded: {total} addresses | Selected: {selected}";
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
        dgvLabels.SelectAll();
        UpdateSummary();
    }

    private void btnSelectNone_Click(object sender, EventArgs e)
    {
        dgvLabels.ClearSelection();
        UpdateSummary();
    }

    private List<LabelData> GetSelectedLabels()
    {
        var selectedIndices = new HashSet<int>();
        foreach (DataGridViewRow row in dgvLabels.SelectedRows)
        {
            if (row.Cells["Index"].Value is int index)
            {
                selectedIndices.Add(index);
            }
        }

        return _selectedLabels.Where((l, i) => selectedIndices.Contains(i)).ToList();
    }

    private void btnPreview_Click(object sender, EventArgs e)
    {
        var labels = GetSelectedLabels();
        if (labels.Count == 0)
        {
            MessageBox.Show("Please select at least one address to preview.", "No Selection",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
            var report = new MailingLabelsReport(labels, LabelFormat.Avery5160, companyInfo);
            var viewer = new ReportViewerForm(report);
            viewer.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error generating preview: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        var labels = GetSelectedLabels();
        if (labels.Count == 0)
        {
            MessageBox.Show("Please select at least one address to print.", "No Selection",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show(
            $"Print {labels.Count} label(s)?\n\nMake sure label stock (Avery 5160 or compatible) is loaded.",
            "Confirm Print",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                var companyInfo = _dbContext.CompanyInfo.FirstOrDefault();
                var report = new MailingLabelsReport(labels, LabelFormat.Avery5160, companyInfo);
                var pdfBytes = report.GeneratePdf();

                var tempFile = Path.Combine(Path.GetTempPath(), $"Labels_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
                File.WriteAllBytes(tempFile, pdfBytes);

                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true,
                    Verb = "print"
                };

                try
                {
                    System.Diagnostics.Process.Start(psi);
                }
                catch
                {
                    psi.Verb = "open";
                    System.Diagnostics.Process.Start(psi);
                }

                MessageBox.Show($"{labels.Count} label(s) sent to printer.",
                    "Labels Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing labels: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
