using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Room Type management form - migrated from RoomType.frm
/// Manages room types associated with host properties.
/// </summary>
public partial class RoomTypeForm : Form
{
    private readonly BnBDbContext _dbContext;
    private int _currentPropertyAccountNum;
    private BindingSource _bindingSource = new();
    private List<RoomType> _roomTypes = new();

    public RoomTypeForm(BnBDbContext dbContext, int propertyAccountNum = 0)
    {
        _dbContext = dbContext;
        _currentPropertyAccountNum = propertyAccountNum;
        InitializeComponent();
    }

    private void RoomTypeForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        // Temporarily detach event to prevent it firing during setup
        cboProperty.SelectedIndexChanged -= cboProperty_SelectedIndexChanged;
        LoadProperties();

        if (_currentPropertyAccountNum > 0)
        {
            cboProperty.SelectedValue = _currentPropertyAccountNum;
        }

        // Reattach event handler
        cboProperty.SelectedIndexChanged += cboProperty_SelectedIndexChanged;

        LoadRoomTypes();
        UpdateButtonStates();
    }

    private void LoadProperties()
    {
        var properties = _dbContext.Properties
            .Where(p => !p.IsObsolete)
            .OrderBy(p => p.Location)
            .Select(p => new PropertyItem { AccountNumber = p.AccountNumber, Display = $"{p.Location} ({p.AccountNumber})" })
            .ToList();

        cboProperty.DataSource = properties;
        cboProperty.DisplayMember = nameof(PropertyItem.Display);
        cboProperty.ValueMember = nameof(PropertyItem.AccountNumber);
    }

    private void LoadRoomTypes()
    {
        if (cboProperty.SelectedValue == null) return;

        // Handle both int and boxed int types
        int accountNum;
        if (cboProperty.SelectedValue is int intVal)
            accountNum = intVal;
        else if (int.TryParse(cboProperty.SelectedValue.ToString(), out int parsed))
            accountNum = parsed;
        else
            return;

        _currentPropertyAccountNum = accountNum;

        // Check total room types in database for debugging
        var totalRoomTypes = _dbContext.RoomTypes.Count();
        var roomTypesForProperty = _dbContext.RoomTypes
            .Where(r => r.PropertyAccountNumber == _currentPropertyAccountNum)
            .Count();

        System.Diagnostics.Debug.WriteLine($"RoomTypeForm: Total room types in DB: {totalRoomTypes}, For property {_currentPropertyAccountNum}: {roomTypesForProperty}");

        _roomTypes = _dbContext.RoomTypes
            .Where(r => r.PropertyAccountNumber == _currentPropertyAccountNum)
            .OrderBy(r => r.Name)
            .ToList();

        _bindingSource.DataSource = _roomTypes;
        dgvRoomTypes.DataSource = _bindingSource;

        ConfigureGrid();

        // Select the first row if there are any records
        if (_roomTypes.Count > 0 && dgvRoomTypes.Rows.Count > 0)
        {
            dgvRoomTypes.ClearSelection();
            dgvRoomTypes.Rows[0].Selected = true;
            // Set current cell to first visible column
            foreach (DataGridViewColumn col in dgvRoomTypes.Columns)
            {
                if (col.Visible)
                {
                    dgvRoomTypes.CurrentCell = dgvRoomTypes.Rows[0].Cells[col.Index];
                    break;
                }
            }
        }

        UpdateButtonStates();
        PopulateDetailsFromSelection();

        // Update group box title to show count
        grpRoomTypes.Text = $"Room Types ({_roomTypes.Count})";
    }

    private void ConfigureGrid()
    {
        if (dgvRoomTypes.Columns.Count == 0) return;

        // Hide system columns
        dgvRoomTypes.Columns["Id"].Visible = false;
        dgvRoomTypes.Columns["PropertyAccountNumber"].Visible = false;
        dgvRoomTypes.Columns["Property"].Visible = false;
        if (dgvRoomTypes.Columns.Contains("Blackouts"))
            dgvRoomTypes.Columns["Blackouts"].Visible = false;

        // Configure visible columns with proper order, headers, and widths
        if (dgvRoomTypes.Columns.Contains("Name"))
        {
            dgvRoomTypes.Columns["Name"].HeaderText = "Room Name";
            dgvRoomTypes.Columns["Name"].Width = 100;
            dgvRoomTypes.Columns["Name"].DisplayIndex = 0;
        }

        if (dgvRoomTypes.Columns.Contains("DefaultRate"))
        {
            dgvRoomTypes.Columns["DefaultRate"].HeaderText = "Default Rate";
            dgvRoomTypes.Columns["DefaultRate"].Width = 85;
            dgvRoomTypes.Columns["DefaultRate"].DisplayIndex = 1;
            dgvRoomTypes.Columns["DefaultRate"].DefaultCellStyle.Format = "C2";
            dgvRoomTypes.Columns["DefaultRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        if (dgvRoomTypes.Columns.Contains("Description"))
        {
            dgvRoomTypes.Columns["Description"].HeaderText = "Description";
            dgvRoomTypes.Columns["Description"].Width = 180;
            dgvRoomTypes.Columns["Description"].DisplayIndex = 2;
        }

        if (dgvRoomTypes.Columns.Contains("IsActive"))
        {
            dgvRoomTypes.Columns["IsActive"].HeaderText = "Active";
            dgvRoomTypes.Columns["IsActive"].Width = 50;
            dgvRoomTypes.Columns["IsActive"].DisplayIndex = 3;
        }
    }

    private void cboProperty_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadRoomTypes();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (cboProperty.SelectedValue == null)
        {
            MessageBox.Show("Please select a property first.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        txtRoomType.Clear();
        txtDescription.Clear();
        txtDefaultRate.Clear();
        chkActive.Checked = true;  // Default to active for new rooms
        txtRoomType.Focus();
        SetEditMode(true);
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvRoomTypes.CurrentRow == null) return;

        var roomType = dgvRoomTypes.CurrentRow.DataBoundItem as RoomType;
        if (roomType == null) return;

        txtRoomType.Text = roomType.Name;
        txtDescription.Text = roomType.Description;
        txtDefaultRate.Text = roomType.DefaultRate?.ToString("F2") ?? "";
        chkActive.Checked = roomType.IsActive;
        SetEditMode(true);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvRoomTypes.CurrentRow == null) return;

        var roomType = dgvRoomTypes.CurrentRow.DataBoundItem as RoomType;
        if (roomType == null) return;

        var result = MessageBox.Show(
            $"Delete room type '{roomType.Name}'?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                _dbContext.RoomTypes.Remove(roomType);
                _dbContext.SaveChanges();
                LoadRoomTypes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting room type: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtRoomType.Text))
        {
            MessageBox.Show("Please enter a room type code.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtRoomType.Focus();
            return;
        }

        // Parse default rate
        decimal? defaultRate = null;
        if (!string.IsNullOrWhiteSpace(txtDefaultRate.Text))
        {
            if (!decimal.TryParse(txtDefaultRate.Text, out var rate))
            {
                MessageBox.Show("Please enter a valid default rate.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDefaultRate.Focus();
                return;
            }
            defaultRate = rate;
        }

        try
        {
            RoomType? roomType = null;

            if (dgvRoomTypes.CurrentRow?.DataBoundItem is RoomType existing &&
                existing.Name == txtRoomType.Text)
            {
                // Editing existing
                roomType = existing;
            }
            else
            {
                // Check for duplicate
                var duplicate = _roomTypes.FirstOrDefault(r =>
                    r.Name.Equals(txtRoomType.Text, StringComparison.OrdinalIgnoreCase));

                if (duplicate != null)
                {
                    MessageBox.Show("A room type with this code already exists.", "Duplicate",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // New room type
                roomType = new RoomType
                {
                    PropertyAccountNumber = _currentPropertyAccountNum,
                    Name = txtRoomType.Text.Trim()
                };
                _dbContext.RoomTypes.Add(roomType);
            }

            roomType.Description = txtDescription.Text.Trim();
            roomType.DefaultRate = defaultRate;
            roomType.IsActive = chkActive.Checked;
            _dbContext.SaveChanges();

            LoadRoomTypes();
            SetEditMode(false);
        }
        catch (Exception ex)
        {
            // Get the innermost exception for actual error details
            var innerEx = ex;
            while (innerEx.InnerException != null)
                innerEx = innerEx.InnerException;

            MessageBox.Show($"Error saving room type: {ex.Message}\n\nDetails: {innerEx.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        txtRoomType.Clear();
        txtDescription.Clear();
        txtDefaultRate.Clear();
        chkActive.Checked = false;
        SetEditMode(false);
    }

    private void btnBlackouts_Click(object sender, EventArgs e)
    {
        if (dgvRoomTypes.CurrentRow == null) return;

        var roomType = dgvRoomTypes.CurrentRow.DataBoundItem as RoomType;
        if (roomType == null) return;

        using var form = new RoomBlackoutForm(_dbContext, roomType.Id, roomType.Description ?? roomType.Name, DateTime.Today);
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            // Blackout was added, could refresh count display if needed
            LoadRoomTypes();
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvRoomTypes_SelectionChanged(object sender, EventArgs e)
    {
        UpdateButtonStates();
        PopulateDetailsFromSelection();
    }

    private void PopulateDetailsFromSelection()
    {
        if (dgvRoomTypes.CurrentRow?.DataBoundItem is RoomType roomType)
        {
            txtRoomType.Text = roomType.Name;
            txtDescription.Text = roomType.Description ?? "";
            txtDefaultRate.Text = roomType.DefaultRate?.ToString("F2") ?? "";
            chkActive.Checked = roomType.IsActive;
        }
        else
        {
            txtRoomType.Clear();
            txtDescription.Clear();
            txtDefaultRate.Clear();
            chkActive.Checked = false;
        }
    }

    private void SetEditMode(bool editing)
    {
        txtRoomType.Enabled = editing;
        txtDescription.Enabled = editing;
        txtDefaultRate.Enabled = editing;
        chkActive.Enabled = editing;
        btnSave.Enabled = editing;
        btnCancel.Enabled = editing;
        btnAdd.Enabled = !editing;
        btnEdit.Enabled = !editing && dgvRoomTypes.CurrentRow != null;
        btnDelete.Enabled = !editing && dgvRoomTypes.CurrentRow != null;
        btnBlackouts.Enabled = !editing && dgvRoomTypes.CurrentRow != null;
        cboProperty.Enabled = !editing;
    }

    private void UpdateButtonStates()
    {
        var hasSelection = dgvRoomTypes.CurrentRow != null;
        btnEdit.Enabled = hasSelection;
        btnDelete.Enabled = hasSelection;
        btnBlackouts.Enabled = hasSelection;
    }

    /// <summary>
    /// Helper class for property ComboBox binding.
    /// </summary>
    private class PropertyItem
    {
        public int AccountNumber { get; set; }
        public string Display { get; set; } = string.Empty;
    }
}
