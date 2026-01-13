namespace BnB.WinForms.UI;

/// <summary>
/// Extension methods for applying UI theme styles to Windows Forms controls
/// </summary>
public static class UIExtensions
{
    /// <summary>
    /// Apply modern theme to a form
    /// </summary>
    public static T ApplyTheme<T>(this T form) where T : Form
    {
        form.BackColor = UITheme.BackgroundMain;
        form.Font = UITheme.DefaultFont;
        form.ForeColor = UITheme.TextPrimary;

        // Recursively style child controls
        ApplyThemeToControls(form.Controls);

        return form;
    }

    /// <summary>
    /// Apply theme styles to a collection of controls
    /// </summary>
    public static void ApplyThemeToControls(Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            ApplyThemeToControl(control);

            // Recursively apply to child controls
            if (control.HasChildren)
            {
                ApplyThemeToControls(control.Controls);
            }
        }
    }

    /// <summary>
    /// Apply theme to a specific control based on its type
    /// </summary>
    public static void ApplyThemeToControl(Control control)
    {
        switch (control)
        {
            case Button btn:
                btn.ApplyPrimaryStyle();
                break;

            case DataGridView dgv:
                dgv.ApplyGridStyle();
                break;

            case Panel panel:
                panel.ApplyPanelStyle();
                break;

            case GroupBox grp:
                grp.ApplyGroupBoxStyle();
                break;

            case TextBox txt:
                txt.ApplyTextBoxStyle();
                break;

            case ComboBox cmb:
                cmb.ApplyComboBoxStyle();
                break;

            case Label lbl:
                lbl.ApplyLabelStyle();
                break;

            case TabControl tab:
                tab.ApplyTabStyle();
                break;

            case MenuStrip menuStrip:
                menuStrip.ApplyMenuStripStyle();
                break;

            case StatusStrip statusStrip:
                statusStrip.ApplyStatusStripStyle();
                break;

            case ToolStrip toolStrip:
                toolStrip.ApplyToolStripStyle();
                break;
        }
    }

    // === Button Styles ===

    /// <summary>
    /// Apply primary button style (main action buttons)
    /// </summary>
    public static Button ApplyPrimaryStyle(this Button button)
    {
        var enabledBackColor = UITheme.Primary;
        var enabledForeColor = UITheme.TextOnPrimary;
        var hoverBackColor = UITheme.PrimaryLight;

        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Font = UITheme.DefaultFont;
        button.Height = UITheme.ButtonHeight;

        if (button.Width < UITheme.ButtonWidthSmall)
            button.Width = UITheme.ButtonWidthSmall;

        // Set initial colors based on enabled state
        UpdateButtonColors(button, enabledBackColor, enabledForeColor);

        // Add hover effect (only when enabled)
        button.MouseEnter += (s, e) =>
        {
            if (button.Enabled)
                button.BackColor = hoverBackColor;
        };
        button.MouseLeave += (s, e) =>
        {
            if (button.Enabled)
                button.BackColor = enabledBackColor;
        };

        // Handle enabled state changes
        button.EnabledChanged += (s, e) => UpdateButtonColors(button, enabledBackColor, enabledForeColor);

        return button;
    }

    /// <summary>
    /// Apply secondary button style (less prominent actions)
    /// </summary>
    public static Button ApplySecondaryStyle(this Button button)
    {
        var enabledBackColor = UITheme.BackgroundPanel;
        var enabledForeColor = UITheme.TextPrimary;
        var hoverBackColor = UITheme.BackgroundAlternate;

        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderColor = UITheme.Border;
        button.FlatAppearance.BorderSize = 1;
        button.Font = UITheme.DefaultFont;
        button.Height = UITheme.ButtonHeight;

        UpdateButtonColors(button, enabledBackColor, enabledForeColor);

        button.MouseEnter += (s, e) =>
        {
            if (button.Enabled)
                button.BackColor = hoverBackColor;
        };
        button.MouseLeave += (s, e) =>
        {
            if (button.Enabled)
                button.BackColor = enabledBackColor;
        };

        button.EnabledChanged += (s, e) => UpdateButtonColors(button, enabledBackColor, enabledForeColor);

        return button;
    }

    /// <summary>
    /// Apply success button style (save, confirm actions)
    /// </summary>
    public static Button ApplySuccessStyle(this Button button)
    {
        var enabledBackColor = UITheme.Success;
        var enabledForeColor = UITheme.TextOnDark;
        var hoverBackColor = UITheme.SecondaryLight;

        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Font = UITheme.DefaultFont;
        button.Height = UITheme.ButtonHeight;

        UpdateButtonColors(button, enabledBackColor, enabledForeColor);

        button.MouseEnter += (s, e) =>
        {
            if (button.Enabled)
                button.BackColor = hoverBackColor;
        };
        button.MouseLeave += (s, e) =>
        {
            if (button.Enabled)
                button.BackColor = enabledBackColor;
        };

        button.EnabledChanged += (s, e) => UpdateButtonColors(button, enabledBackColor, enabledForeColor);

        return button;
    }

    /// <summary>
    /// Apply danger button style (delete, cancel destructive actions)
    /// </summary>
    public static Button ApplyDangerStyle(this Button button)
    {
        var enabledBackColor = UITheme.Error;
        var enabledForeColor = UITheme.TextOnDark;
        var hoverBackColor = Color.FromArgb(192, 57, 43);

        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Font = UITheme.DefaultFont;
        button.Height = UITheme.ButtonHeight;

        UpdateButtonColors(button, enabledBackColor, enabledForeColor);

        button.MouseEnter += (s, e) =>
        {
            if (button.Enabled)
                button.BackColor = hoverBackColor;
        };
        button.MouseLeave += (s, e) =>
        {
            if (button.Enabled)
                button.BackColor = enabledBackColor;
        };

        button.EnabledChanged += (s, e) => UpdateButtonColors(button, enabledBackColor, enabledForeColor);

        return button;
    }

    /// <summary>
    /// Helper method to update button colors based on enabled state
    /// </summary>
    private static void UpdateButtonColors(Button button, Color enabledBackColor, Color enabledForeColor)
    {
        if (button.Enabled)
        {
            button.BackColor = enabledBackColor;
            button.ForeColor = enabledForeColor;
            button.Cursor = Cursors.Hand;
        }
        else
        {
            button.BackColor = UITheme.DisabledBackground;
            button.ForeColor = UITheme.DisabledText;
            button.Cursor = Cursors.Default;
        }
    }

    // === DataGridView Styles ===

    /// <summary>
    /// Apply modern styling to a DataGridView
    /// </summary>
    public static DataGridView ApplyGridStyle(this DataGridView grid)
    {
        // General settings
        grid.BorderStyle = BorderStyle.None;
        grid.BackgroundColor = UITheme.BackgroundPanel;
        grid.GridColor = UITheme.Border;
        grid.Font = UITheme.DefaultFont;

        // Cell styles
        grid.DefaultCellStyle.BackColor = UITheme.BackgroundPanel;
        grid.DefaultCellStyle.ForeColor = UITheme.TextPrimary;
        grid.DefaultCellStyle.SelectionBackColor = UITheme.PrimaryLight;
        grid.DefaultCellStyle.SelectionForeColor = UITheme.TextOnPrimary;
        grid.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);

        // Alternating rows
        grid.AlternatingRowsDefaultCellStyle.BackColor = UITheme.BackgroundAlternate;

        // Header style
        grid.ColumnHeadersDefaultCellStyle.BackColor = UITheme.Primary;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = UITheme.TextOnPrimary;
        grid.ColumnHeadersDefaultCellStyle.Font = UITheme.BoldFont;
        grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 4, 5, 4);
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersHeight = UITheme.GridHeaderHeight;

        // Row headers
        grid.RowHeadersVisible = false;

        // Row settings
        grid.RowTemplate.Height = UITheme.GridRowHeight;

        // Selection
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;

        // Scrollbars
        grid.ScrollBars = ScrollBars.Both;

        return grid;
    }

    // === Panel Styles ===

    /// <summary>
    /// Apply standard panel styling
    /// </summary>
    public static Panel ApplyPanelStyle(this Panel panel)
    {
        panel.BackColor = UITheme.BackgroundPanel;
        return panel;
    }

    /// <summary>
    /// Apply header panel styling
    /// </summary>
    public static Panel ApplyHeaderStyle(this Panel panel)
    {
        panel.BackColor = UITheme.Primary;
        panel.ForeColor = UITheme.TextOnPrimary;
        panel.Padding = UITheme.DefaultPadding;
        return panel;
    }

    // === GroupBox Styles ===

    /// <summary>
    /// Apply styling to a GroupBox
    /// </summary>
    public static GroupBox ApplyGroupBoxStyle(this GroupBox groupBox)
    {
        groupBox.Font = UITheme.BoldFont;
        groupBox.ForeColor = UITheme.Primary;
        groupBox.BackColor = UITheme.BackgroundPanel;
        return groupBox;
    }

    // === TextBox Styles ===

    /// <summary>
    /// Apply modern TextBox styling
    /// </summary>
    public static TextBox ApplyTextBoxStyle(this TextBox textBox)
    {
        textBox.BorderStyle = BorderStyle.FixedSingle;
        textBox.Font = UITheme.DefaultFont;
        textBox.BackColor = UITheme.BackgroundPanel;
        textBox.ForeColor = UITheme.TextPrimary;
        return textBox;
    }

    // === ComboBox Styles ===

    /// <summary>
    /// Apply modern ComboBox styling
    /// </summary>
    public static ComboBox ApplyComboBoxStyle(this ComboBox comboBox)
    {
        comboBox.FlatStyle = FlatStyle.Flat;
        comboBox.Font = UITheme.DefaultFont;
        comboBox.BackColor = UITheme.BackgroundPanel;
        comboBox.ForeColor = UITheme.TextPrimary;
        return comboBox;
    }

    // === Label Styles ===

    /// <summary>
    /// Apply standard label styling
    /// </summary>
    public static Label ApplyLabelStyle(this Label label)
    {
        label.Font = UITheme.DefaultFont;
        label.ForeColor = UITheme.TextPrimary;
        return label;
    }

    /// <summary>
    /// Apply header label styling
    /// </summary>
    public static Label ApplyHeaderLabelStyle(this Label label)
    {
        label.Font = UITheme.HeaderFont;
        label.ForeColor = UITheme.Primary;
        return label;
    }

    /// <summary>
    /// Apply title label styling
    /// </summary>
    public static Label ApplyTitleStyle(this Label label)
    {
        label.Font = UITheme.TitleFont;
        label.ForeColor = UITheme.Primary;
        return label;
    }

    // === TabControl Styles ===

    /// <summary>
    /// Apply modern TabControl styling
    /// </summary>
    public static TabControl ApplyTabStyle(this TabControl tabControl)
    {
        tabControl.Font = UITheme.DefaultFont;
        return tabControl;
    }

    // === ToolStrip Styles ===

    /// <summary>
    /// Apply modern ToolStrip styling
    /// </summary>
    public static ToolStrip ApplyToolStripStyle(this ToolStrip toolStrip)
    {
        toolStrip.BackColor = UITheme.BackgroundHeader;
        toolStrip.ForeColor = UITheme.TextOnDark;
        toolStrip.GripStyle = ToolStripGripStyle.Hidden;
        toolStrip.Renderer = new ModernToolStripRenderer();
        return toolStrip;
    }

    // === MenuStrip Styles ===

    /// <summary>
    /// Apply modern MenuStrip styling
    /// </summary>
    public static MenuStrip ApplyMenuStripStyle(this MenuStrip menuStrip)
    {
        menuStrip.BackColor = UITheme.BackgroundHeader;
        menuStrip.ForeColor = UITheme.TextOnDark;
        menuStrip.Renderer = new ModernToolStripRenderer();
        return menuStrip;
    }

    // === StatusStrip Styles ===

    /// <summary>
    /// Apply modern StatusStrip styling
    /// </summary>
    public static StatusStrip ApplyStatusStripStyle(this StatusStrip statusStrip)
    {
        statusStrip.BackColor = UITheme.BackgroundHeader;
        statusStrip.ForeColor = UITheme.TextOnDark;
        return statusStrip;
    }
}

/// <summary>
/// Custom renderer for modern ToolStrip appearance
/// </summary>
public class ModernToolStripRenderer : ToolStripProfessionalRenderer
{
    public ModernToolStripRenderer() : base(new ModernColorTable()) { }

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        if (e.Item.Selected || e.Item.Pressed)
        {
            using var brush = new SolidBrush(UITheme.PrimaryLight);
            e.Graphics.FillRectangle(brush, e.Item.ContentRectangle);
        }
        else
        {
            base.OnRenderMenuItemBackground(e);
        }
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        // Check if item is on the main menu bar (dark background) or in a dropdown (light background)
        bool isOnMenuBar = e.ToolStrip is MenuStrip;
        bool isSelected = e.Item.Selected || e.Item.Pressed;

        if (isOnMenuBar)
        {
            // Top-level menu items on dark background
            e.TextColor = UITheme.TextOnDark;
        }
        else if (isSelected)
        {
            // Selected items in dropdown get white text on blue background
            e.TextColor = UITheme.TextOnDark;
        }
        else
        {
            // Non-selected dropdown items get dark text on light background
            e.TextColor = UITheme.TextPrimary;
        }

        base.OnRenderItemText(e);
    }
}

/// <summary>
/// Color table for modern ToolStrip rendering
/// </summary>
public class ModernColorTable : ProfessionalColorTable
{
    public override Color MenuItemSelected => UITheme.PrimaryLight;
    public override Color MenuItemSelectedGradientBegin => UITheme.PrimaryLight;
    public override Color MenuItemSelectedGradientEnd => UITheme.PrimaryLight;
    public override Color MenuItemBorder => UITheme.Primary;
    public override Color MenuBorder => UITheme.Border;
    public override Color MenuStripGradientBegin => UITheme.BackgroundHeader;
    public override Color MenuStripGradientEnd => UITheme.BackgroundHeader;
    public override Color ToolStripGradientBegin => UITheme.BackgroundHeader;
    public override Color ToolStripGradientEnd => UITheme.BackgroundHeader;
    public override Color ToolStripGradientMiddle => UITheme.BackgroundHeader;
    public override Color ImageMarginGradientBegin => UITheme.BackgroundPanel;
    public override Color ImageMarginGradientMiddle => UITheme.BackgroundPanel;
    public override Color ImageMarginGradientEnd => UITheme.BackgroundPanel;
    public override Color ToolStripDropDownBackground => UITheme.BackgroundPanel;
    public override Color SeparatorDark => UITheme.Border;
    public override Color SeparatorLight => UITheme.BackgroundAlternate;
}
