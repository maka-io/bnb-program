namespace BnB.WinForms.Forms;

/// <summary>
/// Guest search dialog - allows searching by name or confirmation number.
/// </summary>
public partial class GuestSearchForm : Form
{
    public GuestSearchCriteria? SearchCriteria { get; private set; }

    public GuestSearchForm()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        SearchCriteria = new GuestSearchCriteria
        {
            FirstName = string.IsNullOrWhiteSpace(txtFirstName.Text) ? null : txtFirstName.Text.Trim(),
            LastName = string.IsNullOrWhiteSpace(txtLastName.Text) ? null : txtLastName.Text.Trim(),
            ConfirmationNumber = long.TryParse(txtConfirmationNumber.Text, out var confNum) ? confNum : null
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

    private void GuestSearchForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            btnCancel_Click(sender, e);
        }
        else if (e.KeyCode == Keys.Enter)
        {
            btnSearch_Click(sender, e);
        }
    }
}
