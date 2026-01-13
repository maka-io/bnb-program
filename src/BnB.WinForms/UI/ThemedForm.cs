namespace BnB.WinForms.UI;

/// <summary>
/// Base form class that automatically applies the modern UI theme.
/// Inherit from this class to get consistent styling across forms.
/// </summary>
public class ThemedForm : Form
{
    public ThemedForm()
    {
        // Set form defaults
        Font = UITheme.DefaultFont;
        BackColor = UITheme.BackgroundMain;
        ForeColor = UITheme.TextPrimary;
        StartPosition = FormStartPosition.CenterParent;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        // Apply theme to all controls
        this.ApplyTheme();
    }

    /// <summary>
    /// Create a styled header panel with title
    /// </summary>
    protected Panel CreateHeaderPanel(string title)
    {
        var panel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 50,
            BackColor = UITheme.Primary,
            Padding = new Padding(15, 0, 15, 0)
        };

        var label = new Label
        {
            Text = title,
            Font = UITheme.TitleFont,
            ForeColor = UITheme.TextOnPrimary,
            AutoSize = false,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft
        };

        panel.Controls.Add(label);
        return panel;
    }

    /// <summary>
    /// Create a styled button bar panel
    /// </summary>
    protected Panel CreateButtonPanel(params Button[] buttons)
    {
        var panel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 55,
            BackColor = UITheme.BackgroundPanel,
            Padding = new Padding(10)
        };

        var flowPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            AutoSize = true,
            FlowDirection = FlowDirection.RightToLeft,
            WrapContents = false
        };

        foreach (var button in buttons.Reverse())
        {
            button.Margin = new Padding(5, 0, 5, 0);
            button.Width = UITheme.ButtonWidth;
            button.Height = UITheme.ButtonHeight;
            flowPanel.Controls.Add(button);
        }

        panel.Controls.Add(flowPanel);
        return panel;
    }

    /// <summary>
    /// Create a styled group box
    /// </summary>
    protected GroupBox CreateGroupBox(string title)
    {
        return new GroupBox
        {
            Text = title,
            Font = UITheme.BoldFont,
            ForeColor = UITheme.Primary,
            BackColor = UITheme.BackgroundPanel,
            Padding = new Padding(10)
        };
    }

    /// <summary>
    /// Create a styled label
    /// </summary>
    protected Label CreateLabel(string text, bool isHeader = false)
    {
        return new Label
        {
            Text = text,
            Font = isHeader ? UITheme.HeaderFont : UITheme.DefaultFont,
            ForeColor = isHeader ? UITheme.Primary : UITheme.TextPrimary,
            AutoSize = true
        };
    }

    /// <summary>
    /// Create a styled text box
    /// </summary>
    protected TextBox CreateTextBox(int width = 200, bool readOnly = false)
    {
        return new TextBox
        {
            Width = width,
            Font = UITheme.DefaultFont,
            BorderStyle = BorderStyle.FixedSingle,
            ReadOnly = readOnly,
            BackColor = readOnly ? UITheme.BackgroundAlternate : UITheme.BackgroundPanel
        };
    }

    /// <summary>
    /// Create a styled combo box
    /// </summary>
    protected ComboBox CreateComboBox(int width = 200)
    {
        return new ComboBox
        {
            Width = width,
            Font = UITheme.DefaultFont,
            FlatStyle = FlatStyle.Flat,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
    }

    /// <summary>
    /// Create a styled DataGridView
    /// </summary>
    protected DataGridView CreateDataGridView()
    {
        var grid = new DataGridView();
        grid.ApplyGridStyle();
        return grid;
    }

    /// <summary>
    /// Create a primary action button
    /// </summary>
    protected Button CreatePrimaryButton(string text, EventHandler? onClick = null)
    {
        var button = new Button { Text = text };
        button.ApplyPrimaryStyle();
        if (onClick != null)
            button.Click += onClick;
        return button;
    }

    /// <summary>
    /// Create a secondary action button
    /// </summary>
    protected Button CreateSecondaryButton(string text, EventHandler? onClick = null)
    {
        var button = new Button { Text = text };
        button.ApplySecondaryStyle();
        if (onClick != null)
            button.Click += onClick;
        return button;
    }

    /// <summary>
    /// Create a success action button
    /// </summary>
    protected Button CreateSuccessButton(string text, EventHandler? onClick = null)
    {
        var button = new Button { Text = text };
        button.ApplySuccessStyle();
        if (onClick != null)
            button.Click += onClick;
        return button;
    }

    /// <summary>
    /// Create a danger action button
    /// </summary>
    protected Button CreateDangerButton(string text, EventHandler? onClick = null)
    {
        var button = new Button { Text = text };
        button.ApplyDangerStyle();
        if (onClick != null)
            button.Click += onClick;
        return button;
    }
}
