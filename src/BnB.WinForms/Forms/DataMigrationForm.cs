using BnB.Data.Context;

namespace BnB.WinForms.Forms;

/// <summary>
/// Form to display progress during data migration from Access to SQLite
/// </summary>
public partial class DataMigrationForm : Form
{
    private readonly string _accessDbPath;
    private readonly BnBDbContext _context;
    private readonly Label _statusLabel;
    private readonly Label _tableLabel;
    private readonly Label _recordLabel;
    private readonly ProgressBar _progressBar;
    private readonly Button _startButton;
    private readonly Button _closeButton;
    private readonly TextBox _logTextBox;
    private bool _migrationComplete;

    public DataMigrationForm(string accessDbPath, BnBDbContext context)
    {
        _accessDbPath = accessDbPath;
        _context = context;

        Text = "Import Legacy Data";
        Size = new Size(500, 450);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        // Status label
        _statusLabel = new Label
        {
            Text = "Ready to import data from Access database.",
            Location = new Point(20, 20),
            Size = new Size(440, 20),
            Font = new Font(Font.FontFamily, 9, FontStyle.Bold)
        };
        Controls.Add(_statusLabel);

        // Source file label
        var sourceLabel = new Label
        {
            Text = $"Source: {Path.GetFileName(_accessDbPath)}",
            Location = new Point(20, 45),
            Size = new Size(440, 20)
        };
        Controls.Add(sourceLabel);

        // Table label
        _tableLabel = new Label
        {
            Text = "Table: -",
            Location = new Point(20, 70),
            Size = new Size(440, 20)
        };
        Controls.Add(_tableLabel);

        // Record label
        _recordLabel = new Label
        {
            Text = "Records: -",
            Location = new Point(20, 95),
            Size = new Size(440, 20)
        };
        Controls.Add(_recordLabel);

        // Progress bar
        _progressBar = new ProgressBar
        {
            Location = new Point(20, 125),
            Size = new Size(440, 25),
            Style = ProgressBarStyle.Marquee
        };
        Controls.Add(_progressBar);

        // Log text box
        _logTextBox = new TextBox
        {
            Location = new Point(20, 160),
            Size = new Size(440, 200),
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            Font = new Font("Consolas", 9)
        };
        Controls.Add(_logTextBox);

        // Start button
        _startButton = new Button
        {
            Text = "Start Import",
            Location = new Point(280, 370),
            Size = new Size(90, 30)
        };
        _startButton.Click += StartButton_Click;
        Controls.Add(_startButton);

        // Close button
        _closeButton = new Button
        {
            Text = "Cancel",
            Location = new Point(380, 370),
            Size = new Size(80, 30)
        };
        _closeButton.Click += CloseButton_Click;
        Controls.Add(_closeButton);

        FormClosing += DataMigrationForm_FormClosing;
    }

    private async void StartButton_Click(object? sender, EventArgs e)
    {
        _startButton.Enabled = false;
        _closeButton.Text = "Cancel";
        _statusLabel.Text = "Importing data...";
        _logTextBox.Clear();

        var progress = new Progress<Services.MigrationProgress>(p =>
        {
            _tableLabel.Text = $"Table: {p.TableName}";
            if (p.TotalRecords > 0)
            {
                _recordLabel.Text = $"Records: {p.CurrentRecord:N0} of {p.TotalRecords:N0}";
                _progressBar.Style = ProgressBarStyle.Continuous;
                _progressBar.Maximum = p.TotalRecords;
                _progressBar.Value = Math.Min(p.CurrentRecord, p.TotalRecords);
            }
            else
            {
                _recordLabel.Text = $"Records: {p.CurrentRecord:N0}";
                _progressBar.Style = ProgressBarStyle.Marquee;
            }
        });

        try
        {
            var service = new Services.DataMigrationService(_accessDbPath, _context, progress);
            var result = await Task.Run(() => service.MigrateAllAsync());

            _migrationComplete = true;

            if (result.Success)
            {
                _statusLabel.Text = "Import completed successfully!";
                _progressBar.Style = ProgressBarStyle.Continuous;
                _progressBar.Value = _progressBar.Maximum;

                Log($"Migration completed successfully!");
                Log($"");
                Log($"Records imported:");
                Log($"  Tax Rates:           {result.TaxRates,6:N0}");
                Log($"  Tax Plans:           {result.TaxPlans,6:N0}");
                Log($"  Properties:          {result.Properties,6:N0}");
                Log($"  Room Types:          {result.RoomTypes,6:N0}");
                Log($"  Guests:              {result.Guests,6:N0}");
                Log($"  Accommodations:      {result.Accommodations,6:N0}");
                Log($"  Payments:            {result.Payments,6:N0}");
                Log($"  Checks:              {result.Checks,6:N0}");
                Log($"  ──────────────────────────");
                Log($"  TOTAL:               {result.TotalRecords,6:N0}");

                MessageBox.Show(
                    $"Successfully imported {result.TotalRecords:N0} records from Access database.",
                    "Import Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                _statusLabel.Text = "Import failed!";
                Log($"ERROR: {result.ErrorMessage}");

                MessageBox.Show(
                    $"Import failed: {result.ErrorMessage}",
                    "Import Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            _statusLabel.Text = "Import failed!";
            Log($"ERROR: {ex.Message}");

            MessageBox.Show(
                $"Import failed: {ex.Message}",
                "Import Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        _startButton.Enabled = true;
        _startButton.Text = "Import Again";
        _closeButton.Text = "Close";
    }

    private void Log(string message)
    {
        _logTextBox.AppendText(message + Environment.NewLine);
    }

    private void CloseButton_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void DataMigrationForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (!_migrationComplete && !_startButton.Enabled)
        {
            var result = MessageBox.Show(
                "Migration is in progress. Are you sure you want to cancel?",
                "Cancel Migration",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
