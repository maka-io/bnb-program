namespace BnB.WinForms.Forms;

/// <summary>
/// Export File Dialog - migrated from XPORTDLG.FRM
/// Provides options for exporting data to delimited text files.
/// </summary>
public partial class ExportDialogForm : Form
{
    public string ExportFileName => txtFileName.Text;
    public string ExportFormat => cboFormat.SelectedItem?.ToString() ?? "Tab Delimited";
    public bool IncludeCaption => chkCaption.Checked;
    public bool IncludeHeaders => chkHeaders.Checked;
    public bool AppendToFile => chkAppend.Checked;
    public int FirstRow => int.TryParse(txtFirstRow.Text, out var val) ? val : 1;
    public int LastRow => int.TryParse(txtLastRow.Text, out var val) ? val : 1;
    public int FirstColumn => int.TryParse(txtFirstCol.Text, out var val) ? val : 1;
    public int LastColumn => int.TryParse(txtLastCol.Text, out var val) ? val : 1;
    public bool Cancelled { get; private set; } = true;

    private int _maxRows = 1;
    private int _maxCols = 1;

    public ExportDialogForm(int maxRows = 100, int maxCols = 10)
    {
        _maxRows = maxRows;
        _maxCols = maxCols;
        InitializeComponent();
    }

    private void ExportDialogForm_Load(object sender, EventArgs e)
    {
        // Set default file name
        var defaultPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            $"export_{DateTime.Now:yyyyMMdd}.txt");
        txtFileName.Text = defaultPath;

        // Load format options
        cboFormat.Items.Add("Comma Delimited");
        cboFormat.Items.Add("Pipe Delimited");
        cboFormat.Items.Add("Space Delimited");
        cboFormat.Items.Add("Tab Delimited");
        cboFormat.SelectedIndex = 3; // Default to Tab Delimited

        // Set default range
        txtFirstRow.Text = "1";
        txtLastRow.Text = _maxRows.ToString();
        txtFirstCol.Text = "1";
        txtLastCol.Text = _maxCols.ToString();

        chkHeaders.Checked = true;
    }

    private void btnFile_Click(object sender, EventArgs e)
    {
        using var saveDialog = new SaveFileDialog
        {
            Title = "Select Export File",
            Filter = "Text File (*.txt)|*.txt|CSV File (*.csv)|*.csv|All Files (*.*)|*.*",
            DefaultExt = "txt",
            OverwritePrompt = !chkAppend.Checked
        };

        if (saveDialog.ShowDialog() == DialogResult.OK)
        {
            txtFileName.Text = saveDialog.FileName;
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
        if (string.IsNullOrWhiteSpace(txtFileName.Text))
        {
            MessageBox.Show("Please select a file name.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Validate range values
        if (!int.TryParse(txtFirstRow.Text, out var firstRow) ||
            !int.TryParse(txtLastRow.Text, out var lastRow) ||
            !int.TryParse(txtFirstCol.Text, out var firstCol) ||
            !int.TryParse(txtLastCol.Text, out var lastCol))
        {
            MessageBox.Show("Range values are not properly filled in.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (firstRow < 1 || lastRow < 1 || firstCol < 1 || lastCol < 1)
        {
            MessageBox.Show("Range values must be positive numbers.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (firstRow > lastRow || firstCol > lastCol)
        {
            MessageBox.Show("First value cannot be greater than last value.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Check if file exists when not appending
        if (File.Exists(txtFileName.Text) && !chkAppend.Checked)
        {
            var result = MessageBox.Show(
                "File already exists! Overwrite it?",
                Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
                return false;
        }

        return true;
    }
}
