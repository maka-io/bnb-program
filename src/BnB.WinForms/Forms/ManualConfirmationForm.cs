using BnB.Data.Context;

namespace BnB.WinForms.Forms;

/// <summary>
/// Manual Confirmation Number Entry form - migrated from MANUCHK.FRM
/// Allows manually adding or removing confirmation numbers for processing.
/// </summary>
public partial class ManualConfirmationForm : Form
{
    private readonly BnBDbContext _dbContext;

    public List<string> ConfirmationNumbers { get; } = new();
    public bool Cancelled { get; private set; } = true;

    public ManualConfirmationForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void ManualConfirmationForm_Load(object sender, EventArgs e)
    {
        UpdateButtons();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var confNum = txtConfirmationNumber.Text.Trim();

        if (string.IsNullOrWhiteSpace(confNum))
        {
            MessageBox.Show("Please enter a confirmation number.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmationNumber.Focus();
            return;
        }

        // Check if already in list
        if (lstConfirmationNumbers.Items.Contains(confNum))
        {
            MessageBox.Show("This confirmation number is already in the list.", "Duplicate Entry",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtConfirmationNumber.SelectAll();
            txtConfirmationNumber.Focus();
            return;
        }

        // Verify the confirmation number exists in the database
        var exists = long.TryParse(confNum, out var confNumLong) &&
                     _dbContext.Guests.Any(g => g.ConfirmationNumber == confNumLong);
        if (!exists)
        {
            var result = MessageBox.Show(
                $"Confirmation number '{confNum}' was not found in the database. Add anyway?",
                "Confirmation Not Found",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                txtConfirmationNumber.SelectAll();
                txtConfirmationNumber.Focus();
                return;
            }
        }

        lstConfirmationNumbers.Items.Add(confNum);
        txtConfirmationNumber.Clear();
        txtConfirmationNumber.Focus();
        UpdateButtons();
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (lstConfirmationNumbers.SelectedIndex < 0) return;

        lstConfirmationNumbers.Items.RemoveAt(lstConfirmationNumbers.SelectedIndex);
        UpdateButtons();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        if (lstConfirmationNumbers.Items.Count == 0) return;

        var result = MessageBox.Show(
            "Clear all confirmation numbers from the list?",
            "Confirm Clear",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            lstConfirmationNumbers.Items.Clear();
            UpdateButtons();
        }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (lstConfirmationNumbers.Items.Count == 0)
        {
            MessageBox.Show("Please add at least one confirmation number.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmationNumber.Focus();
            return;
        }

        // Collect all confirmation numbers
        ConfirmationNumbers.Clear();
        foreach (var item in lstConfirmationNumbers.Items)
        {
            ConfirmationNumbers.Add(item.ToString() ?? "");
        }

        Cancelled = false;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Cancelled = true;
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void lstConfirmationNumbers_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateButtons();
    }

    private void txtConfirmationNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Add on Enter key
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
            btnAdd_Click(sender, e);
        }
    }

    private void UpdateButtons()
    {
        btnRemove.Enabled = lstConfirmationNumbers.SelectedIndex >= 0;
        btnClear.Enabled = lstConfirmationNumbers.Items.Count > 0;
        lblCount.Text = $"{lstConfirmationNumbers.Items.Count} confirmation(s)";
    }
}
