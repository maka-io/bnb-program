namespace BnB.WinForms.UI;

/// <summary>
/// Centralized UI theme for consistent styling across all forms.
/// Provides modern colors, fonts, and styling for a professional appearance.
/// </summary>
public static class UITheme
{
    // === Primary Colors ===
    /// <summary>Primary brand color - used for headers, accents, selected items</summary>
    public static Color Primary { get; } = Color.FromArgb(26, 82, 118);  // Deep blue #1a5276

    /// <summary>Primary color - lighter variant for hover states</summary>
    public static Color PrimaryLight { get; } = Color.FromArgb(52, 152, 219);  // #3498db

    /// <summary>Primary color - darker variant for pressed states</summary>
    public static Color PrimaryDark { get; } = Color.FromArgb(21, 67, 96);  // #154360

    // === Secondary Colors ===
    /// <summary>Secondary accent color</summary>
    public static Color Secondary { get; } = Color.FromArgb(39, 174, 96);  // Green #27ae60

    /// <summary>Secondary light variant</summary>
    public static Color SecondaryLight { get; } = Color.FromArgb(46, 204, 113);  // #2ecc71

    // === Background Colors ===
    /// <summary>Main form background</summary>
    public static Color BackgroundMain { get; } = Color.FromArgb(248, 249, 250);  // Light gray #f8f9fa

    /// <summary>Panel/card background</summary>
    public static Color BackgroundPanel { get; } = Color.White;

    /// <summary>Header/toolbar background</summary>
    public static Color BackgroundHeader { get; } = Color.FromArgb(52, 73, 94);  // Dark slate #34495e

    /// <summary>Alternate row background for grids</summary>
    public static Color BackgroundAlternate { get; } = Color.FromArgb(245, 247, 250);  // #f5f7fa

    // === Text Colors ===
    /// <summary>Primary text color</summary>
    public static Color TextPrimary { get; } = Color.FromArgb(44, 62, 80);  // Dark #2c3e50

    /// <summary>Secondary/muted text color</summary>
    public static Color TextSecondary { get; } = Color.FromArgb(127, 140, 141);  // Gray #7f8c8d

    /// <summary>Text on dark backgrounds</summary>
    public static Color TextOnDark { get; } = Color.White;

    /// <summary>Text on primary color backgrounds</summary>
    public static Color TextOnPrimary { get; } = Color.White;

    // === Status Colors ===
    /// <summary>Success/positive status</summary>
    public static Color Success { get; } = Color.FromArgb(39, 174, 96);  // Green #27ae60

    /// <summary>Warning status</summary>
    public static Color Warning { get; } = Color.FromArgb(243, 156, 18);  // Orange #f39c12

    /// <summary>Error/danger status</summary>
    public static Color Error { get; } = Color.FromArgb(231, 76, 60);  // Red #e74c3c

    /// <summary>Info status</summary>
    public static Color Info { get; } = Color.FromArgb(52, 152, 219);  // Blue #3498db

    // === Border Colors ===
    /// <summary>Default border color</summary>
    public static Color Border { get; } = Color.FromArgb(220, 221, 225);  // Light gray #dcdde1

    /// <summary>Focused/active border color</summary>
    public static Color BorderFocused { get; } = Color.FromArgb(52, 152, 219);  // Blue #3498db

    // === Disabled Colors ===
    /// <summary>Disabled control background</summary>
    public static Color DisabledBackground { get; } = Color.FromArgb(200, 200, 200);  // Gray

    /// <summary>Disabled control text</summary>
    public static Color DisabledText { get; } = Color.FromArgb(140, 140, 140);  // Dark gray

    // === Fonts ===
    /// <summary>Default font family</summary>
    public static string FontFamily { get; } = "Segoe UI";

    /// <summary>Default font size</summary>
    public static float FontSizeDefault { get; } = 9f;

    /// <summary>Small font size</summary>
    public static float FontSizeSmall { get; } = 8f;

    /// <summary>Large font size for headers</summary>
    public static float FontSizeLarge { get; } = 11f;

    /// <summary>Title font size</summary>
    public static float FontSizeTitle { get; } = 14f;

    // === Pre-built Fonts ===
    public static Font DefaultFont { get; } = new Font(FontFamily, FontSizeDefault);
    public static Font SmallFont { get; } = new Font(FontFamily, FontSizeSmall);
    public static Font LargeFont { get; } = new Font(FontFamily, FontSizeLarge);
    public static Font TitleFont { get; } = new Font(FontFamily, FontSizeTitle, FontStyle.Bold);
    public static Font HeaderFont { get; } = new Font(FontFamily, FontSizeLarge, FontStyle.Bold);
    public static Font BoldFont { get; } = new Font(FontFamily, FontSizeDefault, FontStyle.Bold);

    // === Spacing ===
    /// <summary>Default padding for panels</summary>
    public static Padding DefaultPadding { get; } = new Padding(10);

    /// <summary>Compact padding</summary>
    public static Padding CompactPadding { get; } = new Padding(5);

    /// <summary>Default margin between controls</summary>
    public static Padding DefaultMargin { get; } = new Padding(3);

    // === Button Dimensions ===
    /// <summary>Standard button height</summary>
    public static int ButtonHeight { get; } = 32;

    /// <summary>Standard button width</summary>
    public static int ButtonWidth { get; } = 90;

    /// <summary>Small button width</summary>
    public static int ButtonWidthSmall { get; } = 70;

    // === DataGridView Settings ===
    /// <summary>Default row height for grids</summary>
    public static int GridRowHeight { get; } = 24;

    /// <summary>Default header height for grids</summary>
    public static int GridHeaderHeight { get; } = 30;
}
