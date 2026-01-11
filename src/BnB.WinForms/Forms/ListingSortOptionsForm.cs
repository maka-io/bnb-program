namespace BnB.WinForms.Forms;

/// <summary>
/// Listing Report Sort Options Dialog - migrated from LISTDIAG.FRM
/// Provides options for sorting and ordering columns in report listings.
/// </summary>
public partial class ListingSortOptionsForm : Form
{
    public List<string> SortOrder { get; private set; } = new();
    public List<string> ColumnOrder { get; private set; } = new();
    public bool SortDescending => chkDescending.Checked;
    public string DateFormat => cboDateFormat.Text;
    public bool SortOrderChanged { get; private set; }
    public bool Cancelled { get; private set; } = true;

    private readonly List<string> _columns;

    public ListingSortOptionsForm(List<string> columns)
    {
        _columns = columns ?? new List<string>();
        InitializeComponent();
    }

    private void ListingSortOptionsForm_Load(object sender, EventArgs e)
    {
        // Store original descending state
        _originalDescending = chkDescending.Checked;

        // Load sort order list (initially same as column order)
        lstSortOrder.Items.Clear();
        foreach (var col in _columns)
        {
            lstSortOrder.Items.Add(col);
        }

        // Load column order list
        lstColumnOrder.Items.Clear();
        foreach (var col in _columns)
        {
            lstColumnOrder.Items.Add(col);
        }

        // Load date format options
        cboDateFormat.Items.AddRange(new object[]
        {
            "m/d/yyyy",
            "mm/dd/yyyy",
            "m/d/yy",
            "mm/dd/yy",
            "dd-mmm-yy",
            "dd-mmmm-yy",
            "mm/dd/yy h:mm",
            "mm/dd/yyyy h:mm",
            "ddd",
            "dddd",
            "h:mm:ss",
            "AM/PM"
        });
        cboDateFormat.Text = "m/d/yyyy";

        UpdateSampleDate();
        UpdateSortButtons();
        UpdateColumnButtons();
    }

    private void UpdateSampleDate()
    {
        try
        {
            var sampleDate = new DateTime(1998, 7, 27, 15, 10, 23);
            lblSampleDate.Text = sampleDate.ToString(ConvertVBDateFormat(cboDateFormat.Text));
        }
        catch
        {
            lblSampleDate.Text = "Invalid Format String";
            btnOK.Enabled = false;
        }
    }

    private string ConvertVBDateFormat(string vbFormat)
    {
        // Convert VB date format to .NET format
        return vbFormat
            .Replace("mmmm", "MMMM")
            .Replace("mmm", "MMM")
            .Replace("mm", "MM")
            .Replace("dd", "dd")
            .Replace("yyyy", "yyyy")
            .Replace("yy", "yy")
            .Replace("h:", "H:")
            .Replace("AM/PM", "tt");
    }

    private void UpdateSortButtons()
    {
        var hasSelection = lstSortOrder.SelectedIndex >= 0;
        btnSortMoveUp.Enabled = hasSelection && lstSortOrder.SelectedIndex > 0;
        btnSortMoveDown.Enabled = hasSelection && lstSortOrder.SelectedIndex < lstSortOrder.Items.Count - 1;
    }

    private void UpdateColumnButtons()
    {
        var hasSelection = lstColumnOrder.SelectedIndex >= 0;
        btnColMoveUp.Enabled = hasSelection && lstColumnOrder.SelectedIndex > 0;
        btnColMoveDown.Enabled = hasSelection && lstColumnOrder.SelectedIndex < lstColumnOrder.Items.Count - 1;
    }

    private void btnSortMoveUp_Click(object sender, EventArgs e)
    {
        MoveListItem(lstSortOrder, -1);
        SortOrderChanged = true;
    }

    private void btnSortMoveDown_Click(object sender, EventArgs e)
    {
        MoveListItem(lstSortOrder, 1);
        SortOrderChanged = true;
    }

    private void btnColMoveUp_Click(object sender, EventArgs e)
    {
        MoveListItem(lstColumnOrder, -1);
    }

    private void btnColMoveDown_Click(object sender, EventArgs e)
    {
        MoveListItem(lstColumnOrder, 1);
    }

    private void MoveListItem(ListBox listBox, int delta)
    {
        if (listBox.SelectedIndex < 0) return;

        var index = listBox.SelectedIndex;
        var newIndex = index + delta;

        if (newIndex < 0 || newIndex >= listBox.Items.Count) return;

        var item = listBox.Items[index];
        listBox.Items.RemoveAt(index);
        listBox.Items.Insert(newIndex, item);
        listBox.SelectedIndex = newIndex;
    }

    private void lstSortOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateSortButtons();
    }

    private void lstColumnOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateColumnButtons();
    }

    private void cboDateFormat_TextChanged(object sender, EventArgs e)
    {
        UpdateSampleDate();
        if (lblSampleDate.Text != "Invalid Format String")
        {
            btnOK.Enabled = true;
        }
    }

    private void btnFonts_Click(object sender, EventArgs e)
    {
        using var fontDialog = new FontDialog();
        fontDialog.ShowDialog();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        // Collect sort order
        SortOrder.Clear();
        foreach (var item in lstSortOrder.Items)
        {
            SortOrder.Add(item.ToString() ?? "");
        }

        // Collect column order
        ColumnOrder.Clear();
        foreach (var item in lstColumnOrder.Items)
        {
            ColumnOrder.Add(item.ToString() ?? "");
        }

        // Check if descending changed
        if (chkDescending.Checked != _originalDescending)
        {
            SortOrderChanged = true;
        }

        Cancelled = false;
        DialogResult = DialogResult.OK;
        Close();
    }

    private bool _originalDescending;

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Cancelled = true;
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void chkDescending_CheckedChanged(object sender, EventArgs e)
    {
        SortOrderChanged = true;
    }
}
