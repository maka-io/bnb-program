using BnB.WinForms.UI;

namespace BnB.WinForms.Forms;

/// <summary>
/// Print Options Dialog - migrated from PRINTDLG.FRM
/// Provides print options for grid/report output.
/// </summary>
public partial class PrintOptionsForm : Form
{
    public bool AutoScaleContent => chkAutoScale.Checked;
    public bool CellOutlines => chkCellOutlines.Checked;
    public bool UseColor => chkColor.Checked;
    public bool ChartBorder => chkChartBorder.Checked;
    public int FirstRow => int.TryParse(txtFirstRow.Text, out var val) ? val : 1;
    public int LastRow => int.TryParse(txtLastRow.Text, out var val) ? val : 1;
    public int FirstColumn => int.TryParse(txtFirstCol.Text, out var val) ? val : 1;
    public int LastColumn => int.TryParse(txtLastCol.Text, out var val) ? val : 1;
    public Font SelectedFont { get; private set; } = SystemFonts.DefaultFont;
    public bool Cancelled { get; private set; } = true;

    private int _maxRows;
    private int _maxCols;
    private int _pageCount;

    public PrintOptionsForm(int maxRows = 100, int maxCols = 10)
    {
        _maxRows = maxRows;
        _maxCols = maxCols;
        InitializeComponent();
    }

    private void PrintOptionsForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();

        // Set default range
        txtFirstRow.Text = "1";
        txtLastRow.Text = _maxRows.ToString();
        txtFirstCol.Text = "1";
        txtLastCol.Text = _maxCols.ToString();

        // Set default options
        chkAutoScale.Checked = true;
        chkSaveSettings.Checked = true;

        UpdatePageCount();
        UpdateFontDisplay();
    }

    private void btnPrinter_Click(object sender, EventArgs e)
    {
        using var printDialog = new PrintDialog();
        printDialog.ShowDialog();
        UpdatePageCount();
    }

    private void btnFonts_Click(object sender, EventArgs e)
    {
        using var fontDialog = new FontDialog
        {
            Font = SelectedFont,
            ShowEffects = true,
            MaxSize = 72,
            MinSize = 6
        };

        if (fontDialog.ShowDialog() == DialogResult.OK)
        {
            SelectedFont = fontDialog.Font;
            UpdateFontDisplay();
            UpdatePageCount();
        }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        Cancelled = false;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Cancelled = true;
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private bool ValidateInput()
    {
        // Validate range values
        if (string.IsNullOrWhiteSpace(txtFirstRow.Text) ||
            string.IsNullOrWhiteSpace(txtLastRow.Text) ||
            string.IsNullOrWhiteSpace(txtFirstCol.Text) ||
            string.IsNullOrWhiteSpace(txtLastCol.Text))
        {
            MessageBox.Show("Row and Column range values cannot be blank.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return false;
        }

        if (!int.TryParse(txtFirstRow.Text, out var firstRow) ||
            !int.TryParse(txtLastRow.Text, out var lastRow) ||
            !int.TryParse(txtFirstCol.Text, out var firstCol) ||
            !int.TryParse(txtLastCol.Text, out var lastCol))
        {
            MessageBox.Show("Range values must be valid numbers.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (lastRow > _maxRows || lastRow < firstRow)
        {
            MessageBox.Show("Row range is incorrect.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (lastCol > _maxCols || lastCol < firstCol)
        {
            MessageBox.Show("Column range is incorrect.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void UpdatePageCount()
    {
        // Estimate page count based on rows and font size
        var linesPerPage = 50; // Simplified estimate
        if (int.TryParse(txtLastRow.Text, out var lastRow) && int.TryParse(txtFirstRow.Text, out var firstRow))
        {
            var totalRows = lastRow - firstRow + 1;
            _pageCount = Math.Max(1, (int)Math.Ceiling((double)totalRows / linesPerPage));
        }
        else
        {
            _pageCount = 1;
        }

        lblPagesData.Text = _pageCount.ToString();
        lblPageCountWarning.Visible = chkAutoScale.Checked;
    }

    private void UpdateFontDisplay()
    {
        lblFontData.Text = $"{SelectedFont.Name} - {SelectedFont.Size} pt.";
    }

    private void chkAutoScale_CheckedChanged(object sender, EventArgs e)
    {
        lblPageCountWarning.Visible = chkAutoScale.Checked;
    }
}
