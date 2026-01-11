using BnB.Core.Models;
using BnB.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Property Facts form - migrated from PropFact.frm
/// Manages property facts and attributes.
/// </summary>
public partial class PropertyFactsForm : Form
{
    private readonly BnBDbContext _dbContext;
    private Property? _currentProperty;

    public PropertyFactsForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void PropertyFactsForm_Load(object sender, EventArgs e)
    {
        LoadProperties();
    }

    private void LoadProperties()
    {
        var properties = _dbContext.Properties
            .Where(p => !p.IsObsolete)
            .OrderBy(p => p.Location)
            .ToList();

        lstProperties.DataSource = properties;
        lstProperties.DisplayMember = "Location";
        lstProperties.ValueMember = "AccountNumber";
    }

    private void lstProperties_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstProperties.SelectedItem is Property property)
        {
            _currentProperty = property;
            DisplayPropertyDetails(property);
        }
    }

    private void DisplayPropertyDetails(Property property)
    {
        txtLocation.Text = property.Location;
        txtFullName.Text = property.FullName;
        txtDBA.Text = property.DBA;

        // Property Address
        txtPropAddress.Text = property.PropertyAddress;
        txtPropCity.Text = property.PropertyCity;
        txtPropState.Text = property.PropertyState;
        txtPropZip.Text = property.PropertyZipCode;
        txtPropPhone.Text = property.PropertyPhone;

        // Mailing Address
        txtMailAddress.Text = property.MailingAddress;
        txtMailCity.Text = property.MailingCity;
        txtMailState.Text = property.MailingState;
        txtMailZip.Text = property.MailingZipCode;
        txtMailPhone.Text = property.MailingPhone1;

        // Contact Info
        txtEmail.Text = property.Email;
        txtWebUrl.Text = property.WebUrl;

        // Financial Info
        txtCheckTo.Text = property.CheckTo;
        txtFederalTaxId.Text = property.FederalTaxId;
        txtPercentToHost.Text = property.PercentToHost.ToString("F2");
        txtTaxPlan.Text = property.TaxPlanCode;

        txtComments.Text = property.Comments;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (_currentProperty == null) return;

        try
        {
            _currentProperty.Location = txtLocation.Text.Trim();
            _currentProperty.FullName = txtFullName.Text.Trim();
            _currentProperty.DBA = txtDBA.Text.Trim();

            _currentProperty.PropertyAddress = txtPropAddress.Text.Trim();
            _currentProperty.PropertyCity = txtPropCity.Text.Trim();
            _currentProperty.PropertyState = txtPropState.Text.Trim();
            _currentProperty.PropertyZipCode = txtPropZip.Text.Trim();
            _currentProperty.PropertyPhone = txtPropPhone.Text.Trim();

            _currentProperty.MailingAddress = txtMailAddress.Text.Trim();
            _currentProperty.MailingCity = txtMailCity.Text.Trim();
            _currentProperty.MailingState = txtMailState.Text.Trim();
            _currentProperty.MailingZipCode = txtMailZip.Text.Trim();
            _currentProperty.MailingPhone1 = txtMailPhone.Text.Trim();

            _currentProperty.Email = txtEmail.Text.Trim();
            _currentProperty.WebUrl = txtWebUrl.Text.Trim();

            _currentProperty.CheckTo = txtCheckTo.Text.Trim();
            _currentProperty.FederalTaxId = txtFederalTaxId.Text.Trim();

            if (decimal.TryParse(txtPercentToHost.Text, out var percent))
            {
                _currentProperty.PercentToHost = percent;
            }

            _currentProperty.TaxPlanCode = txtTaxPlan.Text.Trim();
            _currentProperty.Comments = txtComments.Text.Trim();

            _dbContext.SaveChanges();

            MessageBox.Show("Property saved successfully.", "Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadProperties();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving property: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRoomTypes_Click(object sender, EventArgs e)
    {
        if (_currentProperty == null) return;

        using var form = new RoomTypeForm(_dbContext, _currentProperty.PropertyId);
        form.ShowDialog(this);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
