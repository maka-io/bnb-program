namespace BnB.WinForms.Forms;

/// <summary>
/// Payment search dialog - allows searching by various criteria.
/// </summary>
public partial class PaymentSearchForm : Form
{
    public PaymentSearchCriteria? SearchCriteria { get; private set; }

    public PaymentSearchForm()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        SearchCriteria = new PaymentSearchCriteria
        {
            ConfirmationNumber = long.TryParse(txtConfirmationNumber.Text, out var confNum) ? confNum : null,
            GuestName = string.IsNullOrWhiteSpace(txtGuestName.Text) ? null : txtGuestName.Text.Trim(),
            DateFrom = chkDateFrom.Checked ? dtpDateFrom.Value.Date : null,
            DateTo = chkDateTo.Checked ? dtpDateTo.Value.Date : null,
            MinAmount = decimal.TryParse(txtMinAmount.Text, out var minAmt) ? minAmt : null
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

    private void chkDateFrom_CheckedChanged(object sender, EventArgs e)
    {
        dtpDateFrom.Enabled = chkDateFrom.Checked;
    }

    private void chkDateTo_CheckedChanged(object sender, EventArgs e)
    {
        dtpDateTo.Enabled = chkDateTo.Checked;
    }
}
