namespace BnB.WinForms.Forms;

public partial class CarAgencySearchForm : Form
{
    public CarAgencySearchCriteria? SearchCriteria { get; private set; }

    public CarAgencySearchForm()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        SearchCriteria = new CarAgencySearchCriteria
        {
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
