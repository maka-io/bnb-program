using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Fact list management form - migrated from FactList.frm
/// Manages the list of facts/features for properties.
/// </summary>
public partial class FactListForm : Form
{
    private readonly BnBDbContext _dbContext;
    private BindingSource _bindingSource = new();
    private List<Fact> _facts = new();

    public FactListForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void FactListForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        LoadCategories();
        LoadFacts();
    }

    private void LoadCategories()
    {
        cboCategory.Items.Clear();
        cboCategory.Items.Add("(All Categories)");

        var categories = _dbContext.Facts
            .Select(f => f.Category)
            .Distinct()
            .Where(c => !string.IsNullOrEmpty(c))
            .OrderBy(c => c)
            .ToList();

        foreach (var category in categories)
        {
            cboCategory.Items.Add(category);
        }
        cboCategory.SelectedIndex = 0;
    }

    private void LoadFacts()
    {
        IQueryable<Fact> query = _dbContext.Facts;

        // Filter by category
        if (cboCategory.SelectedIndex > 0)
        {
            var category = cboCategory.SelectedItem.ToString();
            query = query.Where(f => f.Category == category);
        }

        // Filter by search text
        if (!string.IsNullOrWhiteSpace(txtSearch.Text))
        {
            var search = txtSearch.Text.Trim().ToLower();
            query = query.Where(f => f.Description.ToLower().Contains(search));
        }

        _facts = query.OrderBy(f => f.Category).ThenBy(f => f.Description).ToList();

        _bindingSource.DataSource = _facts.Select(f => new
        {
            f.FactId,
            f.Category,
            f.Description,
            f.IsActive,
            PropertyCount = _dbContext.PropertyFacts.Count(pf => pf.FactId == f.FactId)
        }).ToList();

        dgvFacts.DataSource = _bindingSource;
        ConfigureGrid();
        UpdateSummary();
    }

    private void ConfigureGrid()
    {
        if (dgvFacts.Columns.Count == 0) return;

        if (dgvFacts.Columns.Contains("FactId"))
            dgvFacts.Columns["FactId"].Visible = false;

        if (dgvFacts.Columns.Contains("Category"))
        {
            dgvFacts.Columns["Category"].HeaderText = "Category";
            dgvFacts.Columns["Category"].Width = 120;
        }

        if (dgvFacts.Columns.Contains("Description"))
        {
            dgvFacts.Columns["Description"].HeaderText = "Description";
            dgvFacts.Columns["Description"].Width = 250;
        }

        if (dgvFacts.Columns.Contains("IsActive"))
        {
            dgvFacts.Columns["IsActive"].HeaderText = "Active";
            dgvFacts.Columns["IsActive"].Width = 60;
        }

        if (dgvFacts.Columns.Contains("PropertyCount"))
        {
            dgvFacts.Columns["PropertyCount"].HeaderText = "Properties";
            dgvFacts.Columns["PropertyCount"].Width = 80;
            dgvFacts.Columns["PropertyCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }

    private void UpdateSummary()
    {
        lblSummary.Text = $"Facts: {_bindingSource.Count}";
    }

    private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadFacts();
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        LoadFacts();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using var dialog = new FactEditDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            var fact = new Fact
            {
                Category = dialog.Category,
                Description = dialog.FactDescription,
                IsActive = true
            };

            _dbContext.Facts.Add(fact);
            _dbContext.SaveChanges();
            LoadCategories();
            LoadFacts();
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvFacts.CurrentRow == null) return;

        var factId = (int)dgvFacts.CurrentRow.Cells["FactId"].Value;
        var fact = _dbContext.Facts.Find(factId);
        if (fact == null) return;

        using var dialog = new FactEditDialog(fact.Category, fact.Description);
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            fact.Category = dialog.Category;
            fact.Description = dialog.FactDescription;
            _dbContext.SaveChanges();
            LoadCategories();
            LoadFacts();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvFacts.CurrentRow == null) return;

        var factId = (int)dgvFacts.CurrentRow.Cells["FactId"].Value;
        var propertyCount = (int)dgvFacts.CurrentRow.Cells["PropertyCount"].Value;

        if (propertyCount > 0)
        {
            MessageBox.Show($"This fact is used by {propertyCount} property(ies) and cannot be deleted.",
                "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show("Delete this fact?", "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            var fact = _dbContext.Facts.Find(factId);
            if (fact != null)
            {
                _dbContext.Facts.Remove(fact);
                _dbContext.SaveChanges();
                LoadCategories();
                LoadFacts();
            }
        }
    }

    private void btnToggleActive_Click(object sender, EventArgs e)
    {
        if (dgvFacts.CurrentRow == null) return;

        var factId = (int)dgvFacts.CurrentRow.Cells["FactId"].Value;
        var fact = _dbContext.Facts.Find(factId);
        if (fact != null)
        {
            fact.IsActive = !fact.IsActive;
            _dbContext.SaveChanges();
            LoadFacts();
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}

/// <summary>
/// Simple dialog for adding/editing facts
/// </summary>
public class FactEditDialog : Form
{
    private TextBox txtCategory;
    private TextBox txtDescription;
    private Button btnOK;
    private Button btnCancel;

    public string Category => txtCategory.Text.Trim();
    public string FactDescription => txtDescription.Text.Trim();

    public FactEditDialog(string category = "", string description = "")
    {
        Text = string.IsNullOrEmpty(category) ? "Add Fact" : "Edit Fact";
        Size = new Size(400, 180);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;

        var lblCategory = new Label { Text = "Category:", Location = new Point(12, 15), AutoSize = true };
        txtCategory = new TextBox { Location = new Point(100, 12), Size = new Size(270, 23), Text = category };

        var lblDescription = new Label { Text = "Description:", Location = new Point(12, 45), AutoSize = true };
        txtDescription = new TextBox { Location = new Point(100, 42), Size = new Size(270, 23), Text = description };

        btnOK = new Button { Text = "OK", Location = new Point(214, 100), Size = new Size(75, 28), DialogResult = DialogResult.OK };
        btnCancel = new Button { Text = "Cancel", Location = new Point(295, 100), Size = new Size(75, 28), DialogResult = DialogResult.Cancel };

        btnOK.Click += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(Category) || string.IsNullOrWhiteSpace(FactDescription))
            {
                MessageBox.Show("Category and Description are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        };

        Controls.AddRange(new Control[] { lblCategory, txtCategory, lblDescription, txtDescription, btnOK, btnCancel });
        AcceptButton = btnOK;
        CancelButton = btnCancel;
    }
}
