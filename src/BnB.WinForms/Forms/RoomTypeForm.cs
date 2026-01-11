using BnB.Core.Models;
using BnB.Data.Context;
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
        LoadProperties();

        if (_currentPropertyAccountNum > 0)
        {
            cboProperty.SelectedValue = _currentPropertyAccountNum;
        }

        LoadRoomTypes();
        UpdateButtonStates();
    }

    private void LoadProperties()
    {
        var properties = _dbContext.Properties
            .Where(p => !p.IsObsolete)
            .OrderBy(p => p.Location)
            .Select(p => new { p.PropertyId, Display = $"{p.Location} ({p.PropertyId})" })
            .ToList();

        cboProperty.DataSource = properties;
        cboProperty.DisplayMember = "Display";
        cboProperty.ValueMember = "AccountNumber";
    }

    private void LoadRoomTypes()
    {
        if (cboProperty.SelectedValue == null) return;

        _currentPropertyAccountNum = (int)cboProperty.SelectedValue;

        _roomTypes = _dbContext.RoomTypes
            .Where(r => r.PropertyId == _currentPropertyAccountNum)
            .OrderBy(r => r.Name)
            .ToList();

        _bindingSource.DataSource = _roomTypes;
        dgvRoomTypes.DataSource = _bindingSource;

        ConfigureGrid();
        UpdateButtonStates();
    }

    private void ConfigureGrid()
    {
        if (dgvRoomTypes.Columns.Count == 0) return;

        dgvRoomTypes.Columns["Id"].Visible = false;
        dgvRoomTypes.Columns["PropertyId"].Visible = false;
        dgvRoomTypes.Columns["Property"].Visible = false;

        if (dgvRoomTypes.Columns.Contains("Name"))
        {
            dgvRoomTypes.Columns["Name"].HeaderText = "Room Type";
            dgvRoomTypes.Columns["Name"].Width = 100;
        }

        if (dgvRoomTypes.Columns.Contains("Description"))
        {
            dgvRoomTypes.Columns["Description"].HeaderText = "Description";
            dgvRoomTypes.Columns["Description"].Width = 250;
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
                    PropertyId = _currentPropertyAccountNum,
                    Name = txtRoomType.Text.Trim()
                };
                _dbContext.RoomTypes.Add(roomType);
            }

            roomType.Description = txtDescription.Text.Trim();
            _dbContext.SaveChanges();

            LoadRoomTypes();
            SetEditMode(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving room type: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        txtRoomType.Clear();
        txtDescription.Clear();
        SetEditMode(false);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvRoomTypes_SelectionChanged(object sender, EventArgs e)
    {
        UpdateButtonStates();
    }

    private void SetEditMode(bool editing)
    {
        txtRoomType.Enabled = editing;
        txtDescription.Enabled = editing;
        btnSave.Enabled = editing;
        btnCancel.Enabled = editing;
        btnAdd.Enabled = !editing;
        btnEdit.Enabled = !editing && dgvRoomTypes.CurrentRow != null;
        btnDelete.Enabled = !editing && dgvRoomTypes.CurrentRow != null;
        cboProperty.Enabled = !editing;
    }

    private void UpdateButtonStates()
    {
        var hasSelection = dgvRoomTypes.CurrentRow != null;
        btnEdit.Enabled = hasSelection;
        btnDelete.Enabled = hasSelection;
    }
}
