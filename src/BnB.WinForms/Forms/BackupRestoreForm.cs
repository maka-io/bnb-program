namespace BnB.WinForms.Forms;

/// <summary>
/// Database Backup/Restore dialog - migrated from BACKDLG.FRM
/// Provides database backup and restore functionality.
/// </summary>
public partial class BackupRestoreForm : Form
{
    private bool _isRestoreMode;

    public string SelectedFilePath => txtFileName.Text;
    public bool Cancelled { get; private set; } = true;

    public BackupRestoreForm(bool restoreMode = false)
    {
        _isRestoreMode = restoreMode;
        InitializeComponent();
    }

    private void BackupRestoreForm_Load(object sender, EventArgs e)
    {
        if (_isRestoreMode)
        {
            Text = "Database Restore Dialog Box";
            lblBackupTo.Text = "Restore from:";
        }
        else
        {
            Text = "Database Backup Dialog Box";
            lblBackupTo.Text = "Backup to:";
        }

        // Set default path
        var defaultPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "BnB",
            _isRestoreMode ? "bnb_backup.db" : $"bnb_backup_{DateTime.Now:yyyyMMdd}.db");

        txtFileName.Text = defaultPath;
    }

    private void btnFile_Click(object sender, EventArgs e)
    {
        if (_isRestoreMode)
        {
            using var openDialog = new OpenFileDialog
            {
                Title = "Select Backup File to Restore",
                Filter = "SQLite Database (*.db)|*.db|All Files (*.*)|*.*",
                DefaultExt = "db",
                CheckFileExists = true
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openDialog.FileName;
            }
        }
        else
        {
            using var saveDialog = new SaveFileDialog
            {
                Title = "Select Backup Location",
                Filter = "SQLite Database (*.db)|*.db|All Files (*.*)|*.*",
                DefaultExt = "db",
                OverwritePrompt = true
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = saveDialog.FileName;
            }
        }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtFileName.Text))
        {
            MessageBox.Show("Please select a file.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!txtFileName.Text.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("File must have a .db extension.", "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_isRestoreMode)
        {
            if (!File.Exists(txtFileName.Text))
            {
                MessageBox.Show($"Backup file {txtFileName.Text} does not exist. Click File... to correct.",
                    "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "CAUTION! All existing data will be removed and replaced with the contents of " +
                "the selected backup file. Any data entered/modified since the last backup " +
                "will be lost. Continue?",
                "Confirm Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
                return;
        }
        else
        {
            // Ensure directory exists for backup
            var directory = Path.GetDirectoryName(txtFileName.Text);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

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
}
