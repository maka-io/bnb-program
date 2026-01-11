namespace BnB.WinForms.Forms;

public partial class TravelAgencySearchForm : Form
{
    public TravelAgencySearchCriteria? SearchCriteria { get; private set; }

    public TravelAgencySearchForm()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        SearchCriteria = new TravelAgencySearchCriteria
        {
            AccountNumber = int.TryParse(txtAccountNumber.Text, out var accNum) ? accNum : null,
            Name = string.IsNullOrWhiteSpace(txtName.Text) ? null : txtName.Text.Trim(),
            City = string.IsNullOrWhiteSpace(txtCity.Text) ? null : txtCity.Text.Trim()
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
