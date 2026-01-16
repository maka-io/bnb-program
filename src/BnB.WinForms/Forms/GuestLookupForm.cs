using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.UI;

namespace BnB.WinForms.Forms;

/// <summary>
/// Guest lookup dialog - allows searching for and selecting a guest.
/// </summary>
public partial class GuestLookupForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();

    /// <summary>
    /// The selected guest, if any.
    /// </summary>
    public Guest? SelectedGuest { get; private set; }

    public GuestLookupForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void GuestLookupForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        ConfigureGrid();
        LoadGuests();
        txtSearchName.Focus();
    }

    private void ConfigureGrid()
    {
        dgvGuests.AutoGenerateColumns = false;
        dgvGuests.Columns.Clear();

        dgvGuests.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ConfirmationNumber",
            HeaderText = "Conf #",
            Width = 70
        });

        dgvGuests.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "FirstName",
            HeaderText = "First Name",
            Width = 120
        });

        dgvGuests.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "LastName",
            HeaderText = "Last Name",
            Width = 120
        });

        dgvGuests.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "City",
            HeaderText = "City",
            Width = 100
        });

        dgvGuests.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "State",
            HeaderText = "State",
            Width = 60
        });

        dgvGuests.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "HomePhone",
            HeaderText = "Phone",
            Width = 110
        });

        dgvGuests.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Email",
            HeaderText = "Email",
            Width = 180
        });
    }

    private void LoadGuests()
    {
        var searchText = txtSearchName.Text.Trim();
        long? confNum = null;
        if (long.TryParse(txtSearchConfNum.Text.Trim(), out var parsedConfNum))
        {
            confNum = parsedConfNum;
        }

        var query = _dbContext.Guests.AsQueryable();

        if (confNum.HasValue)
        {
            query = query.Where(g => g.ConfirmationNumber == confNum.Value);
        }
        else if (!string.IsNullOrEmpty(searchText))
        {
            query = query.Where(g =>
                g.FirstName.Contains(searchText) ||
                g.LastName.Contains(searchText));
        }

        var guests = query
            .OrderByDescending(g => g.ConfirmationNumber)
            .Take(100)
            .ToList();

        _bindingSource.DataSource = guests;
        dgvGuests.DataSource = _bindingSource;

        lblResultCount.Text = $"Showing {guests.Count} guest(s)";
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        LoadGuests();
    }

    private void btnSelect_Click(object sender, EventArgs e)
    {
        SelectGuest();
    }

    private void SelectGuest()
    {
        if (_bindingSource.Current is Guest guest)
        {
            SelectedGuest = guest;
            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show("Please select a guest first.", "No Selection",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        SelectedGuest = null;
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void dgvGuests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            SelectGuest();
        }
    }

    private void txtSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            LoadGuests();
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }

    private void GuestLookupForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            btnCancel_Click(sender, e);
        }
    }
}
