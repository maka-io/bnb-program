using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Forms;

/// <summary>
/// Common Text form - migrated from COMMTEXT.FRM
/// Manages reusable text snippets for forms and reports.
/// </summary>
public partial class CommonTextForm : Form
{
    private readonly BnBDbContext _dbContext;
    private List<CommonText> _commonTexts = new();
    private CommonText? _currentText;
    private bool _isEditing;
    private int _currentIndex;

    public CommonTextForm(BnBDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent();
    }

    private void CommonTextForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        LoadCommonTexts();
        SetEditMode(false);
    }

    private void LoadCommonTexts()
    {
        try
        {
            _commonTexts = _dbContext.CommonTexts.OrderBy(c => c.Title).ToList();
            _currentIndex = 0;

            if (_commonTexts.Count > 0)
            {
                _currentText = _commonTexts[0];
                DisplayCurrentText();
                UpdateNavigationLabel();
            }
            else
            {
                ClearFields();
                UpdateNavigationLabel();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading common texts: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DisplayCurrentText()
    {
        if (_currentText == null)
        {
            ClearFields();
            return;
        }

        txtTitle.Text = _currentText.Title;
        txtText.Text = _currentText.Text;
    }

    private void ClearFields()
    {
        txtTitle.Text = "";
        txtText.Text = "";
    }

    private void UpdateNavigationLabel()
    {
        if (_commonTexts.Count == 0)
        {
            lblNavigation.Text = "No records";
        }
        else
        {
            lblNavigation.Text = $"Row {_currentIndex + 1} of {_commonTexts.Count}";
        }
    }

    private void SetEditMode(bool editing)
    {
        _isEditing = editing;

        txtTitle.ReadOnly = !editing;
        txtText.ReadOnly = !editing;

        btnInsert.Enabled = !editing;
        btnUpdate.Enabled = !editing && _commonTexts.Count > 0;
        btnDelete.Enabled = !editing && _commonTexts.Count > 0;
        btnFind.Enabled = !editing;
        btnRefresh.Enabled = !editing;
        btnCommit.Enabled = editing;
        btnCancel.Enabled = editing;
        btnExit.Enabled = !editing;

        // Navigation buttons
        btnFirst.Enabled = !editing && _commonTexts.Count > 0;
        btnPrevious.Enabled = !editing && _currentIndex > 0;
        btnNext.Enabled = !editing && _currentIndex < _commonTexts.Count - 1;
        btnLast.Enabled = !editing && _commonTexts.Count > 0;
    }

    private void btnInsert_Click(object sender, EventArgs e)
    {
        _currentText = new CommonText();
        ClearFields();
        SetEditMode(true);
        txtTitle.Focus();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_currentText == null) return;
        SetEditMode(true);
        txtTitle.Focus();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_currentText == null) return;

        var result = MessageBox.Show(
            "Delete the current row?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        if (result == DialogResult.Yes)
        {
            try
            {
                _dbContext.CommonTexts.Remove(_currentText);
                _dbContext.SaveChanges();
                LoadCommonTexts();
                SetEditMode(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        var searchText = Microsoft.VisualBasic.Interaction.InputBox(
            "Enter title to search for:",
            "Find Common Text",
            "");

        if (string.IsNullOrWhiteSpace(searchText)) return;

        try
        {
            _commonTexts = _dbContext.CommonTexts
                .Where(c => c.Title.Contains(searchText))
                .OrderBy(c => c.Title)
                .ToList();

            _currentIndex = 0;
            if (_commonTexts.Count > 0)
            {
                _currentText = _commonTexts[0];
                DisplayCurrentText();
            }
            else
            {
                ClearFields();
                MessageBox.Show("No matching records found.", "Search Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateNavigationLabel();
            SetEditMode(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error searching: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadCommonTexts();
        SetEditMode(false);
    }

    private void btnCommit_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            if (_currentText == null) return;

            _currentText.Title = txtTitle.Text.Trim();
            _currentText.Text = txtText.Text.Trim();

            if (_currentText.Id == 0)
            {
                _currentText.CreatedDate = DateTime.Now;
                _dbContext.CommonTexts.Add(_currentText);
            }
            else
            {
                _currentText.ModifiedDate = DateTime.Now;
            }

            _dbContext.SaveChanges();
            MessageBox.Show("Saved successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadCommonTexts();
            SetEditMode(false);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("UNIQUE") == true)
        {
            MessageBox.Show("A common text with this title already exists.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTitle.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        LoadCommonTexts();
        SetEditMode(false);
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            MessageBox.Show("Title cannot be blank.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTitle.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtText.Text))
        {
            MessageBox.Show("Text cannot be blank.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtText.Focus();
            return false;
        }

        return true;
    }

    private void btnFirst_Click(object sender, EventArgs e)
    {
        if (_commonTexts.Count == 0) return;
        _currentIndex = 0;
        _currentText = _commonTexts[_currentIndex];
        DisplayCurrentText();
        UpdateNavigationLabel();
        SetEditMode(false);
    }

    private void btnPrevious_Click(object sender, EventArgs e)
    {
        if (_currentIndex > 0)
        {
            _currentIndex--;
            _currentText = _commonTexts[_currentIndex];
            DisplayCurrentText();
            UpdateNavigationLabel();
            SetEditMode(false);
        }
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        if (_currentIndex < _commonTexts.Count - 1)
        {
            _currentIndex++;
            _currentText = _commonTexts[_currentIndex];
            DisplayCurrentText();
            UpdateNavigationLabel();
            SetEditMode(false);
        }
    }

    private void btnLast_Click(object sender, EventArgs e)
    {
        if (_commonTexts.Count == 0) return;
        _currentIndex = _commonTexts.Count - 1;
        _currentText = _commonTexts[_currentIndex];
        DisplayCurrentText();
        UpdateNavigationLabel();
        SetEditMode(false);
    }

    private void CommonTextForm_FormClosing(object sender, FormClosingEventArgs e)
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
