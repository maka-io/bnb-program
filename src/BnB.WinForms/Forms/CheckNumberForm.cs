using BnB.Core.Models;
using BnB.Data.Context;

namespace BnB.WinForms.Forms;

/// <summary>
/// Check Category Information form - migrated from CHECKNUM.FRM
/// Manages check number sequences for different payment categories.
/// </summary>
public partial class CheckNumberForm : Form
{
    private readonly BnBDbContext _dbContext;
    private CheckNumberConfig? _config;
    private bool _isEditing;

    public CheckNumberForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void CheckNumberForm_Load(object sender, EventArgs e)
    {
        LoadConfig();
        SetEditMode(false);
    }

    private void LoadConfig()
    {
        try
        {
            _config = _dbContext.CheckNumberConfigs.FirstOrDefault();

            if (_config == null)
            {
                // Create default config if none exists
                _config = new CheckNumberConfig
                {
                    HostCheckNum = 1,
                    TravelCheckNum = 1,
                    MiscCheckNum = 1,
                    SharedAccounts = 0
                };
                _dbContext.CheckNumberConfigs.Add(_config);
                _dbContext.SaveChanges();
            }

            DisplayConfig();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading check configuration: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DisplayConfig()
    {
        if (_config == null) return;

        txtHostCheckNum.Text = _config.HostCheckNum.ToString();
        txtTravelCheckNum.Text = _config.TravelCheckNum.ToString();
        txtMiscCheckNum.Text = _config.MiscCheckNum.ToString();

        // Set the appropriate radio button
        switch (_config.SharedAccounts)
        {
            case 0:
                radNone.Checked = true;
                break;
            case 1:
                radTravelMisc.Checked = true;
                break;
            case 2:
                radHostMisc.Checked = true;
                break;
            case 3:
                radHostTravel.Checked = true;
                break;
            case 4:
                radAll.Checked = true;
                break;
            default:
                radNone.Checked = true;
                break;
        }
    }

    private void SetEditMode(bool editing)
    {
        _isEditing = editing;

        txtHostCheckNum.ReadOnly = !editing;
        txtTravelCheckNum.ReadOnly = !editing;
        txtMiscCheckNum.ReadOnly = !editing;

        radNone.Enabled = editing;
        radTravelMisc.Enabled = editing;
        radHostMisc.Enabled = editing;
        radHostTravel.Enabled = editing;
        radAll.Enabled = editing;

        btnInsert.Enabled = !editing && _config == null;
        btnUpdate.Enabled = !editing && _config != null;
        btnCommit.Enabled = editing;
        btnCancel.Enabled = editing;
        btnExit.Enabled = !editing;
    }

    private void btnInsert_Click(object sender, EventArgs e)
    {
        _config = new CheckNumberConfig();
        txtHostCheckNum.Text = "";
        txtTravelCheckNum.Text = "";
        txtMiscCheckNum.Text = "";
        radNone.Checked = true;
        SetEditMode(true);
        txtHostCheckNum.Focus();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        SetEditMode(true);
        txtHostCheckNum.Focus();
    }

    private void btnCommit_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            if (_config == null) return;

            _config.HostCheckNum = int.Parse(txtHostCheckNum.Text.Trim());
            _config.TravelCheckNum = int.Parse(txtTravelCheckNum.Text.Trim());
            _config.MiscCheckNum = int.Parse(txtMiscCheckNum.Text.Trim());

            // Get shared accounts value
            if (radNone.Checked)
                _config.SharedAccounts = 0;
            else if (radTravelMisc.Checked)
                _config.SharedAccounts = 1;
            else if (radHostMisc.Checked)
                _config.SharedAccounts = 2;
            else if (radHostTravel.Checked)
                _config.SharedAccounts = 3;
            else if (radAll.Checked)
                _config.SharedAccounts = 4;

            if (_config.Id == 0)
            {
                _dbContext.CheckNumberConfigs.Add(_config);
            }

            _dbContext.SaveChanges();
            MessageBox.Show("Check configuration saved successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            SetEditMode(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        LoadConfig();
        SetEditMode(false);
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private bool ValidateInput()
    {
        // Validate Host check number
        if (string.IsNullOrWhiteSpace(txtHostCheckNum.Text) || !int.TryParse(txtHostCheckNum.Text, out _))
        {
            MessageBox.Show("Please enter a valid Host check number.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHostCheckNum.Focus();
            return false;
        }

        // Validate Travel check number
        if (string.IsNullOrWhiteSpace(txtTravelCheckNum.Text) || !int.TryParse(txtTravelCheckNum.Text, out _))
        {
            MessageBox.Show("Please enter a valid Travel check number.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTravelCheckNum.Focus();
            return false;
        }

        // Validate Misc check number
        if (string.IsNullOrWhiteSpace(txtMiscCheckNum.Text) || !int.TryParse(txtMiscCheckNum.Text, out _))
        {
            MessageBox.Show("Please enter a valid Miscellaneous check number.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMiscCheckNum.Focus();
            return false;
        }

        // Validate shared account rules
        if (!radNone.Checked && !radTravelMisc.Checked && !radHostMisc.Checked &&
            !radHostTravel.Checked && !radAll.Checked)
        {
            MessageBox.Show("A Shared Account option must be chosen.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validate matching numbers for shared options
        int host = int.Parse(txtHostCheckNum.Text.Trim());
        int travel = int.Parse(txtTravelCheckNum.Text.Trim());
        int misc = int.Parse(txtMiscCheckNum.Text.Trim());

        if (radTravelMisc.Checked && travel != misc)
        {
            MessageBox.Show("Check numbers for Travel and Miscellaneous must be the same for the selected sharing option.",
                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (radHostMisc.Checked && host != misc)
        {
            MessageBox.Show("Check numbers for Host and Miscellaneous must be the same for the selected sharing option.",
                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (radHostTravel.Checked && host != travel)
        {
            MessageBox.Show("Check numbers for Host and Travel must be the same for the selected sharing option.",
                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (radAll.Checked && (host != travel || host != misc || travel != misc))
        {
            MessageBox.Show("All check numbers must be the same for the selected sharing option.",
                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void CheckNumberForm_FormClosing(object sender, FormClosingEventArgs e)
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
                    btnCommit_Click(sender, e);
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
