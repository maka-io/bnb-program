namespace BnB.WinForms.Forms;

/// <summary>
/// Property search dialog - allows searching by various criteria.
/// </summary>
public partial class PropertySearchForm : Form
{
    public PropertySearchCriteria? SearchCriteria { get; private set; }

    public PropertySearchForm()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        SearchCriteria = new PropertySearchCriteria
        {
            PropertyId = int.TryParse(txtAccountNumber.Text, out var accNum) ? accNum : null,
            PropertyName = string.IsNullOrWhiteSpace(txtPropertyName.Text) ? null : txtPropertyName.Text.Trim(),
            OwnerName = string.IsNullOrWhiteSpace(txtOwnerName.Text) ? null : txtOwnerName.Text.Trim(),
            IncludeObsolete = chkIncludeObsolete.Checked
        };

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        SearchCriteria = null;
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
