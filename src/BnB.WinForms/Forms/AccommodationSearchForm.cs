namespace BnB.WinForms.Forms;

/// <summary>
/// Accommodation search dialog - allows searching by various criteria.
/// </summary>
public partial class AccommodationSearchForm : Form
{
    public AccommodationSearchCriteria? SearchCriteria { get; private set; }

    public AccommodationSearchForm()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        SearchCriteria = new AccommodationSearchCriteria
        {
            ConfirmationNumber = long.TryParse(txtConfirmationNumber.Text, out var confNum) ? confNum : null,
            GuestName = string.IsNullOrWhiteSpace(txtGuestName.Text) ? null : txtGuestName.Text.Trim(),
            Location = string.IsNullOrWhiteSpace(txtPropertyName.Text) ? null : txtPropertyName.Text.Trim(),
            ArrivalDateFrom = chkArrivalDateFrom.Checked ? dtpArrivalDateFrom.Value.Date : null,
            ArrivalDateTo = chkArrivalDateTo.Checked ? dtpArrivalDateTo.Value.Date : null
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

    private void chkArrivalDateFrom_CheckedChanged(object sender, EventArgs e)
    {
        dtpArrivalDateFrom.Enabled = chkArrivalDateFrom.Checked;
    }

    private void chkArrivalDateTo_CheckedChanged(object sender, EventArgs e)
    {
        dtpArrivalDateTo.Enabled = chkArrivalDateTo.Checked;
    }
}
