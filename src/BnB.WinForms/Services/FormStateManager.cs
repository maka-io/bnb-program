using BnB.Core.Enums;

namespace BnB.WinForms.Services;

/// <summary>
/// Manages form state (Browse/Insert/Update/Delete/Find modes).
/// Migrated from BNBMODE.BAS in legacy VB5 application.
/// </summary>
public class FormStateManager
{
    private static readonly Color EditableColor = Color.Blue;
    private static readonly Color ReadOnlyColor = Color.Black;

    /// <summary>
    /// Sets the form mode and updates all controls accordingly.
    /// </summary>
    public void SetMode(Form form, FormMode mode)
    {
        // Update form caption with mode
        var baseCaption = GetBaseCaptionWithoutMode(form.Text);
        form.Text = $"{baseCaption}  [ {mode} ]";

        // Update controls based on mode
        switch (mode)
        {
            case FormMode.Browse:
                SetBrowseMode(form);
                break;
            case FormMode.Insert:
                SetInsertMode(form);
                break;
            case FormMode.Update:
                SetUpdateMode(form);
                break;
            case FormMode.Delete:
                SetDeleteMode(form);
                break;
            case FormMode.Find:
                SetFindMode(form);
                break;
            case FormMode.NoRows:
                SetNoRowsMode(form);
                break;
        }
    }

    /// <summary>
    /// Gets the current mode from the form's caption.
    /// </summary>
    public FormMode GetMode(Form form)
    {
        var caption = form.Text;
        var startIndex = caption.IndexOf('[');
        var endIndex = caption.IndexOf(']');

        if (startIndex >= 0 && endIndex > startIndex)
        {
            var modeText = caption.Substring(startIndex + 1, endIndex - startIndex - 1).Trim();
            if (Enum.TryParse<FormMode>(modeText, out var mode))
            {
                return mode;
            }
        }

        return FormMode.Browse; // Default
    }

    private string GetBaseCaptionWithoutMode(string caption)
    {
        var bracketIndex = caption.IndexOf('[');
        if (bracketIndex > 0)
        {
            return caption.Substring(0, bracketIndex).Trim();
        }
        return caption;
    }

    private void SetBrowseMode(Form form)
    {
        foreach (Control control in GetAllControls(form))
        {
            switch (control)
            {
                case TextBox textBox:
                    textBox.ReadOnly = true;
                    textBox.ForeColor = ReadOnlyColor;
                    break;

                case ComboBox comboBox:
                    comboBox.Enabled = false;
                    break;

                case CheckBox checkBox:
                    checkBox.Enabled = false;
                    break;

                case RadioButton radioButton:
                    radioButton.Enabled = false;
                    break;

                case Button button:
                    SetButtonStateForBrowse(button);
                    break;

                case DataGridView grid:
                    grid.ReadOnly = true;
                    break;
            }
        }
    }

    private void SetInsertMode(Form form)
    {
        foreach (Control control in GetAllControls(form))
        {
            switch (control)
            {
                case TextBox textBox:
                    // Account numbers are never editable in insert mode
                    if (textBox.Name.Contains("AccountNum", StringComparison.OrdinalIgnoreCase))
                    {
                        textBox.ReadOnly = true;
                        textBox.ForeColor = ReadOnlyColor;
                    }
                    else
                    {
                        textBox.ReadOnly = false;
                        textBox.ForeColor = EditableColor;
                        textBox.Text = string.Empty; // Clear for new entry
                    }
                    break;

                case ComboBox comboBox:
                    comboBox.Enabled = true;
                    comboBox.SelectedIndex = -1;
                    break;

                case CheckBox checkBox:
                    checkBox.Enabled = true;
                    break;

                case RadioButton radioButton:
                    radioButton.Enabled = true;
                    break;

                case Button button:
                    SetButtonStateForEdit(button);
                    break;

                case DataGridView grid:
                    grid.ReadOnly = true; // Grid not editable during insert
                    break;
            }
        }
    }

    private void SetUpdateMode(Form form)
    {
        foreach (Control control in GetAllControls(form))
        {
            switch (control)
            {
                case TextBox textBox:
                    // Account numbers and confirmation numbers are never editable
                    if (textBox.Name.Contains("AccountNum", StringComparison.OrdinalIgnoreCase) ||
                        textBox.Name.Contains("ConfNum", StringComparison.OrdinalIgnoreCase) ||
                        textBox.Name.Contains("Confirmation", StringComparison.OrdinalIgnoreCase))
                    {
                        textBox.ReadOnly = true;
                        textBox.ForeColor = ReadOnlyColor;
                    }
                    else
                    {
                        textBox.ReadOnly = false;
                        textBox.ForeColor = EditableColor;
                    }
                    break;

                case ComboBox comboBox:
                    comboBox.Enabled = true;
                    break;

                case CheckBox checkBox:
                    checkBox.Enabled = true;
                    break;

                case RadioButton radioButton:
                    radioButton.Enabled = true;
                    break;

                case Button button:
                    SetButtonStateForEdit(button);
                    break;

                case DataGridView grid:
                    grid.ReadOnly = true;
                    break;
            }
        }
    }

    private void SetDeleteMode(Form form)
    {
        // In delete mode, all fields are read-only but visible
        foreach (Control control in GetAllControls(form))
        {
            switch (control)
            {
                case TextBox textBox:
                    textBox.ReadOnly = true;
                    textBox.ForeColor = ReadOnlyColor;
                    break;

                case ComboBox comboBox:
                    comboBox.Enabled = false;
                    break;

                case CheckBox checkBox:
                    checkBox.Enabled = false;
                    break;

                case RadioButton radioButton:
                    radioButton.Enabled = false;
                    break;

                case Button button:
                    SetButtonStateForDelete(button);
                    break;

                case DataGridView grid:
                    grid.ReadOnly = true;
                    break;
            }
        }
    }

    private void SetFindMode(Form form)
    {
        foreach (Control control in GetAllControls(form))
        {
            switch (control)
            {
                case TextBox textBox:
                    textBox.ReadOnly = false;
                    textBox.ForeColor = ReadOnlyColor;
                    textBox.Text = string.Empty; // Clear for search criteria
                    break;

                case ComboBox comboBox:
                    comboBox.Enabled = true;
                    comboBox.SelectedIndex = -1;
                    break;

                case CheckBox checkBox:
                    checkBox.Enabled = true;
                    checkBox.Checked = false;
                    break;

                case RadioButton radioButton:
                    radioButton.Enabled = false;
                    break;

                case Button button:
                    SetButtonStateForFind(button);
                    break;

                case DataGridView grid:
                    grid.ReadOnly = true;
                    break;
            }
        }
    }

    private void SetNoRowsMode(Form form)
    {
        foreach (Control control in GetAllControls(form))
        {
            switch (control)
            {
                case TextBox textBox:
                    textBox.ReadOnly = true;
                    textBox.ForeColor = ReadOnlyColor;
                    textBox.Text = string.Empty;
                    break;

                case ComboBox comboBox:
                    comboBox.Enabled = false;
                    comboBox.SelectedIndex = -1;
                    break;

                case CheckBox checkBox:
                    checkBox.Enabled = false;
                    break;

                case RadioButton radioButton:
                    radioButton.Enabled = false;
                    break;

                case Button button:
                    SetButtonStateForNoRows(button);
                    break;

                case DataGridView grid:
                    grid.ReadOnly = true;
                    break;
            }
        }
    }

    #region Button State Helpers

    private void SetButtonStateForBrowse(Button button)
    {
        var text = button.Text.Replace("&", "");
        button.Enabled = text switch
        {
            "Update" or "Delete" or "Insert" or "Find" or "Exit" or "Refresh" => true,
            "Commit" or "Cancel" => false,
            _ => true
        };
    }

    private void SetButtonStateForEdit(Button button)
    {
        var text = button.Text.Replace("&", "");
        button.Enabled = text switch
        {
            "Commit" or "Cancel" => true,
            "Update" or "Delete" or "Insert" or "Find" or "Exit" => false,
            _ => true
        };
    }

    private void SetButtonStateForDelete(Button button)
    {
        var text = button.Text.Replace("&", "");
        button.Enabled = text switch
        {
            "Commit" or "Cancel" => true,
            _ => false
        };
    }

    private void SetButtonStateForFind(Button button)
    {
        var text = button.Text.Replace("&", "");
        button.Enabled = text switch
        {
            "Run Query" or "Cancel" => true,
            _ => false
        };
    }

    private void SetButtonStateForNoRows(Button button)
    {
        var text = button.Text.Replace("&", "");
        button.Enabled = text switch
        {
            "Insert" or "Find" or "Exit" or "Refresh" => true,
            _ => false
        };
    }

    #endregion

    /// <summary>
    /// Gets all controls including nested controls.
    /// </summary>
    private IEnumerable<Control> GetAllControls(Control container)
    {
        foreach (Control control in container.Controls)
        {
            yield return control;
            foreach (var child in GetAllControls(control))
            {
                yield return child;
            }
        }
    }
}
