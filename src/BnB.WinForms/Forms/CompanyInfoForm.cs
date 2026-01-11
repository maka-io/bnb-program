using BnB.Core.Models;
using BnB.Data.Context;

namespace BnB.WinForms.Forms;

/// <summary>
/// Company Information form - migrated from COMPINFO.FRM
/// Manages the company's own information for reports and letterhead.
/// </summary>
public partial class CompanyInfoForm : Form
{
    private readonly BnBDbContext _dbContext;
    private CompanyInfo? _companyInfo;
    private bool _isEditing;

    public CompanyInfoForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void CompanyInfoForm_Load(object sender, EventArgs e)
    {
        LoadCompanyInfo();
        SetEditMode(false);
    }

    private void LoadCompanyInfo()
    {
        try
        {
            _companyInfo = _dbContext.CompanyInfo.FirstOrDefault();

            if (_companyInfo == null)
            {
                // Create default company info record if none exists
                _companyInfo = new CompanyInfo
                {
                    CompanyName = "Hawaii's Best Bed & Breakfasts"
                };
                _dbContext.CompanyInfo.Add(_companyInfo);
                _dbContext.SaveChanges();
            }

            DisplayCompanyInfo();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading company information: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DisplayCompanyInfo()
    {
        if (_companyInfo == null) return;

        txtCompanyName.Text = _companyInfo.CompanyName ?? "";
        txtAddress.Text = _companyInfo.Address ?? "";
        txtCity.Text = _companyInfo.City ?? "";
        txtState.Text = _companyInfo.State ?? "";
        txtZipCode.Text = _companyInfo.ZipCode ?? "";
        txtPhone.Text = _companyInfo.Phone ?? "";
        txtFax.Text = _companyInfo.Fax ?? "";
        txtEmail.Text = _companyInfo.Email ?? "";
        txtWebUrl.Text = _companyInfo.WebUrl ?? "";
    }

    private void SetEditMode(bool editing)
    {
        _isEditing = editing;

        // Enable/disable fields
        txtCompanyName.ReadOnly = !editing;
        txtAddress.ReadOnly = !editing;
        txtCity.ReadOnly = !editing;
        txtState.ReadOnly = !editing;
        txtZipCode.ReadOnly = !editing;
        txtPhone.ReadOnly = !editing;
        txtFax.ReadOnly = !editing;
        txtEmail.ReadOnly = !editing;
        txtWebUrl.ReadOnly = !editing;

        // Enable/disable buttons
        btnEdit.Enabled = !editing;
        btnSave.Enabled = editing;
        btnCancel.Enabled = editing;
        btnClose.Enabled = !editing;
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        SetEditMode(true);
        txtCompanyName.Focus();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            if (_companyInfo == null) return;

            _companyInfo.CompanyName = txtCompanyName.Text.Trim();
            _companyInfo.Address = txtAddress.Text.Trim();
            _companyInfo.City = txtCity.Text.Trim();
            _companyInfo.State = txtState.Text.Trim();
            _companyInfo.ZipCode = txtZipCode.Text.Trim();
            _companyInfo.Phone = txtPhone.Text.Trim();
            _companyInfo.Fax = txtFax.Text.Trim();
            _companyInfo.Email = txtEmail.Text.Trim();
            _companyInfo.WebUrl = txtWebUrl.Text.Trim();

            _dbContext.SaveChanges();
            MessageBox.Show("Company information saved successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            SetEditMode(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving company information: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DisplayCompanyInfo();
        SetEditMode(false);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
        {
            MessageBox.Show("Company name is required.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCompanyName.Focus();
            return false;
        }

        return true;
    }

    private void CompanyInfoForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (_isEditing)
        {
            var result = MessageBox.Show(
                "You have unsaved changes. Do you want to save before closing?",
                "Unsaved Changes",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    btnSave_Click(sender, e);
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
