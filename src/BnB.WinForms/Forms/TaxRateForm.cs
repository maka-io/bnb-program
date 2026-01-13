using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.UI;

namespace BnB.WinForms.Forms;

/// <summary>
/// Tax Rates form - migrated from TAXRATES.FRM
/// Manages tax rate configuration (typically single record).
/// </summary>
public partial class TaxRateForm : Form
{
    private readonly BnBDbContext _dbContext;
    private TaxRate? _taxRate;
    private bool _isEditing;

    public TaxRateForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void TaxRateForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        LoadTaxRates();
        SetEditMode(false);
    }

    private void LoadTaxRates()
    {
        try
        {
            _taxRate = _dbContext.TaxRates.FirstOrDefault();

            if (_taxRate == null)
            {
                // Create default tax rate record if none exists
                _taxRate = new TaxRate
                {
                    TaxOne = 0,
                    TaxTwo = 0,
                    TaxThree = 0
                };
                _dbContext.TaxRates.Add(_taxRate);
                _dbContext.SaveChanges();
            }

            DisplayTaxRates();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading tax rates: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DisplayTaxRates()
    {
        if (_taxRate == null) return;

        // Tax 1
        txtTax1Rate.Text = (_taxRate.TaxOne * 100).ToString("F4");
        txtTax1Description.Text = _taxRate.TaxOneDescription ?? "";
        txtTax1FutureRate.Text = _taxRate.FutureTaxOne.HasValue ? (_taxRate.FutureTaxOne.Value * 100).ToString("F4") : "";
        dtpTax1EffectiveDate.Value = _taxRate.FutureTaxOneEffectiveDate ?? DateTime.Today;
        chkTax1HasFuture.Checked = _taxRate.FutureTaxOne.HasValue;

        // Tax 2
        txtTax2Rate.Text = (_taxRate.TaxTwo * 100).ToString("F4");
        txtTax2Description.Text = _taxRate.TaxTwoDescription ?? "";
        txtTax2FutureRate.Text = _taxRate.FutureTaxTwo.HasValue ? (_taxRate.FutureTaxTwo.Value * 100).ToString("F4") : "";
        dtpTax2EffectiveDate.Value = _taxRate.FutureTaxTwoEffectiveDate ?? DateTime.Today;
        chkTax2HasFuture.Checked = _taxRate.FutureTaxTwo.HasValue;

        // Tax 3
        txtTax3Rate.Text = (_taxRate.TaxThree * 100).ToString("F4");
        txtTax3Description.Text = _taxRate.TaxThreeDescription ?? "";
        txtTax3FutureRate.Text = _taxRate.FutureTaxThree.HasValue ? (_taxRate.FutureTaxThree.Value * 100).ToString("F4") : "";
        dtpTax3EffectiveDate.Value = _taxRate.FutureTaxThreeEffectiveDate ?? DateTime.Today;
        chkTax3HasFuture.Checked = _taxRate.FutureTaxThree.HasValue;

        UpdateFutureFieldsEnabled();
    }

    private void SetEditMode(bool editing)
    {
        _isEditing = editing;

        // Enable/disable fields
        txtTax1Rate.ReadOnly = !editing;
        txtTax1Description.ReadOnly = !editing;
        txtTax1FutureRate.ReadOnly = !editing;
        dtpTax1EffectiveDate.Enabled = editing && chkTax1HasFuture.Checked;
        chkTax1HasFuture.Enabled = editing;

        txtTax2Rate.ReadOnly = !editing;
        txtTax2Description.ReadOnly = !editing;
        txtTax2FutureRate.ReadOnly = !editing;
        dtpTax2EffectiveDate.Enabled = editing && chkTax2HasFuture.Checked;
        chkTax2HasFuture.Enabled = editing;

        txtTax3Rate.ReadOnly = !editing;
        txtTax3Description.ReadOnly = !editing;
        txtTax3FutureRate.ReadOnly = !editing;
        dtpTax3EffectiveDate.Enabled = editing && chkTax3HasFuture.Checked;
        chkTax3HasFuture.Enabled = editing;

        // Enable/disable buttons
        btnEdit.Enabled = !editing;
        btnSave.Enabled = editing;
        btnCancel.Enabled = editing;
        btnClose.Enabled = !editing;
    }

    private void UpdateFutureFieldsEnabled()
    {
        txtTax1FutureRate.Enabled = chkTax1HasFuture.Checked;
        dtpTax1EffectiveDate.Enabled = _isEditing && chkTax1HasFuture.Checked;

        txtTax2FutureRate.Enabled = chkTax2HasFuture.Checked;
        dtpTax2EffectiveDate.Enabled = _isEditing && chkTax2HasFuture.Checked;

        txtTax3FutureRate.Enabled = chkTax3HasFuture.Checked;
        dtpTax3EffectiveDate.Enabled = _isEditing && chkTax3HasFuture.Checked;
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        SetEditMode(true);
        txtTax1Rate.Focus();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            if (_taxRate == null) return;

            // Parse and save Tax 1
            if (decimal.TryParse(txtTax1Rate.Text, out var tax1))
                _taxRate.TaxOne = tax1 / 100;
            _taxRate.TaxOneDescription = txtTax1Description.Text.Trim();

            if (chkTax1HasFuture.Checked && decimal.TryParse(txtTax1FutureRate.Text, out var futureTax1))
            {
                _taxRate.FutureTaxOne = futureTax1 / 100;
                _taxRate.FutureTaxOneEffectiveDate = dtpTax1EffectiveDate.Value;
            }
            else
            {
                _taxRate.FutureTaxOne = null;
                _taxRate.FutureTaxOneEffectiveDate = null;
            }

            // Parse and save Tax 2
            if (decimal.TryParse(txtTax2Rate.Text, out var tax2))
                _taxRate.TaxTwo = tax2 / 100;
            _taxRate.TaxTwoDescription = txtTax2Description.Text.Trim();

            if (chkTax2HasFuture.Checked && decimal.TryParse(txtTax2FutureRate.Text, out var futureTax2))
            {
                _taxRate.FutureTaxTwo = futureTax2 / 100;
                _taxRate.FutureTaxTwoEffectiveDate = dtpTax2EffectiveDate.Value;
            }
            else
            {
                _taxRate.FutureTaxTwo = null;
                _taxRate.FutureTaxTwoEffectiveDate = null;
            }

            // Parse and save Tax 3
            if (decimal.TryParse(txtTax3Rate.Text, out var tax3))
                _taxRate.TaxThree = tax3 / 100;
            _taxRate.TaxThreeDescription = txtTax3Description.Text.Trim();

            if (chkTax3HasFuture.Checked && decimal.TryParse(txtTax3FutureRate.Text, out var futureTax3))
            {
                _taxRate.FutureTaxThree = futureTax3 / 100;
                _taxRate.FutureTaxThreeEffectiveDate = dtpTax3EffectiveDate.Value;
            }
            else
            {
                _taxRate.FutureTaxThree = null;
                _taxRate.FutureTaxThreeEffectiveDate = null;
            }

            _dbContext.SaveChanges();
            MessageBox.Show("Tax rates saved successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            SetEditMode(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving tax rates: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DisplayTaxRates();
        SetEditMode(false);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private bool ValidateInput()
    {
        // Validate Tax 1 rate
        if (!decimal.TryParse(txtTax1Rate.Text, out _))
        {
            MessageBox.Show("Please enter a valid Tax 1 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax1Rate.Focus();
            return false;
        }

        // Validate Tax 2 rate
        if (!decimal.TryParse(txtTax2Rate.Text, out _))
        {
            MessageBox.Show("Please enter a valid Tax 2 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax2Rate.Focus();
            return false;
        }

        // Validate Tax 3 rate
        if (!decimal.TryParse(txtTax3Rate.Text, out _))
        {
            MessageBox.Show("Please enter a valid Tax 3 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax3Rate.Focus();
            return false;
        }

        // Validate future rates if enabled
        if (chkTax1HasFuture.Checked && !decimal.TryParse(txtTax1FutureRate.Text, out _))
        {
            MessageBox.Show("Please enter a valid future Tax 1 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax1FutureRate.Focus();
            return false;
        }

        if (chkTax2HasFuture.Checked && !decimal.TryParse(txtTax2FutureRate.Text, out _))
        {
            MessageBox.Show("Please enter a valid future Tax 2 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax2FutureRate.Focus();
            return false;
        }

        if (chkTax3HasFuture.Checked && !decimal.TryParse(txtTax3FutureRate.Text, out _))
        {
            MessageBox.Show("Please enter a valid future Tax 3 rate.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTax3FutureRate.Focus();
            return false;
        }

        return true;
    }

    private void chkTax1HasFuture_CheckedChanged(object sender, EventArgs e)
    {
        UpdateFutureFieldsEnabled();
    }

    private void chkTax2HasFuture_CheckedChanged(object sender, EventArgs e)
    {
        UpdateFutureFieldsEnabled();
    }

    private void chkTax3HasFuture_CheckedChanged(object sender, EventArgs e)
    {
        UpdateFutureFieldsEnabled();
    }

    private void TaxRateForm_FormClosing(object sender, FormClosingEventArgs e)
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
