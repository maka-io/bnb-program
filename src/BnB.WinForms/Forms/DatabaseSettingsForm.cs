using System.Text.Json;
using BnB.Data.Context;
using BnB.WinForms.Services;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BnB.WinForms.Forms;

/// <summary>
/// Database settings form - allows users to configure SQLite or PostgreSQL
/// and migrate data between databases.
/// </summary>
public partial class DatabaseSettingsForm : Form
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseSettingsForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void DatabaseSettingsForm_Load(object sender, EventArgs e)
    {
        this.ApplyTheme();
        LoadCurrentSettings();
        UpdateUIState();
    }

    private void LoadCurrentSettings()
    {
        var provider = Program.Configuration["Database:Provider"] ?? "SQLite";

        if (provider.Equals("PostgreSQL", StringComparison.OrdinalIgnoreCase))
        {
            rbPostgreSQL.Checked = true;
        }
        else
        {
            rbSQLite.Checked = true;
        }

        // Load SQLite settings
        var sqlitePath = Program.GetSQLiteDatabasePath();
        txtSQLitePath.Text = sqlitePath;

        // Load PostgreSQL settings
        txtHost.Text = Program.Configuration["Database:PostgreSQL:Host"] ?? "localhost";
        txtPort.Text = Program.Configuration["Database:PostgreSQL:Port"] ?? "5432";
        txtDatabase.Text = Program.Configuration["Database:PostgreSQL:Database"] ?? "bnb";
        txtUsername.Text = Program.Configuration["Database:PostgreSQL:Username"] ?? "postgres";
        txtPassword.Text = Program.Configuration["Database:PostgreSQL:Password"] ?? "";
    }

    private void UpdateUIState()
    {
        bool isPostgreSQL = rbPostgreSQL.Checked;

        // PostgreSQL fields
        txtHost.Enabled = isPostgreSQL;
        txtPort.Enabled = isPostgreSQL;
        txtDatabase.Enabled = isPostgreSQL;
        txtUsername.Enabled = isPostgreSQL;
        txtPassword.Enabled = isPostgreSQL;
        btnTestConnection.Enabled = isPostgreSQL;
        btnCreateDatabase.Enabled = isPostgreSQL;

        // Migration is only available when PostgreSQL is selected and SQLite has data
        btnMigrateData.Enabled = isPostgreSQL && File.Exists(Program.GetSQLiteDatabasePath());
    }

    private void rbProvider_CheckedChanged(object sender, EventArgs e)
    {
        UpdateUIState();
    }

    private void btnTestConnection_Click(object sender, EventArgs e)
    {
        var connectionString = $"Host={txtHost.Text};Port={txtPort.Text};Database={txtDatabase.Text};Username={txtUsername.Text};Password={txtPassword.Text}";

        try
        {
            Cursor = Cursors.WaitCursor;
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            MessageBox.Show("Connection successful!", "Test Connection",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Connection failed:\n\n{ex.Message}", "Test Connection",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void btnCreateDatabase_Click(object sender, EventArgs e)
    {
        var databaseName = txtDatabase.Text.Trim();
        if (string.IsNullOrEmpty(databaseName))
        {
            MessageBox.Show("Please enter a database name.", "Create Database",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Connect to the default 'postgres' database to create the new database
        var adminConnectionString = $"Host={txtHost.Text};Port={txtPort.Text};Database=postgres;Username={txtUsername.Text};Password={txtPassword.Text}";

        try
        {
            Cursor = Cursors.WaitCursor;

            using var connection = new NpgsqlConnection(adminConnectionString);
            connection.Open();

            // Check if database already exists
            using (var checkCmd = new NpgsqlCommand(
                "SELECT 1 FROM pg_database WHERE datname = @dbname", connection))
            {
                checkCmd.Parameters.AddWithValue("dbname", databaseName);
                var exists = checkCmd.ExecuteScalar();

                if (exists != null)
                {
                    MessageBox.Show($"Database '{databaseName}' already exists.", "Create Database",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Create the database
            // Note: Database names cannot be parameterized, but we validate the name
            if (!IsValidDatabaseName(databaseName))
            {
                MessageBox.Show("Invalid database name. Use only letters, numbers, and underscores.",
                    "Create Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var createCmd = new NpgsqlCommand($"CREATE DATABASE \"{databaseName}\"", connection))
            {
                createCmd.ExecuteNonQuery();
            }

            MessageBox.Show($"Database '{databaseName}' created successfully!\n\n" +
                "You can now click 'Test Connection' to verify, then 'Migrate Data' to copy your data.",
                "Create Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to create database:\n\n{ex.Message}", "Create Database",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private static bool IsValidDatabaseName(string name)
    {
        // Allow only alphanumeric characters and underscores
        return !string.IsNullOrEmpty(name) &&
               name.All(c => char.IsLetterOrDigit(c) || c == '_') &&
               !char.IsDigit(name[0]);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            var settings = new
            {
                Database = new
                {
                    Provider = rbPostgreSQL.Checked ? "PostgreSQL" : "SQLite",
                    SQLite = new
                    {
                        DatabasePath = ""
                    },
                    PostgreSQL = new
                    {
                        Host = txtHost.Text,
                        Port = int.TryParse(txtPort.Text, out var port) ? port : 5432,
                        Database = txtDatabase.Text,
                        Username = txtUsername.Text,
                        Password = txtPassword.Text
                    }
                }
            };

            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(Program.GetSettingsFilePath(), json);

            MessageBox.Show(
                "Settings saved successfully.\n\nPlease restart the application for changes to take effect.",
                "Settings Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving settings:\n\n{ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnMigrateData_Click(object sender, EventArgs e)
    {
        if (!rbPostgreSQL.Checked)
        {
            MessageBox.Show("Please select PostgreSQL as the target database first.", "Migration",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Test PostgreSQL connection first
        var pgConnectionString = $"Host={txtHost.Text};Port={txtPort.Text};Database={txtDatabase.Text};Username={txtUsername.Text};Password={txtPassword.Text}";
        try
        {
            using var connection = new NpgsqlConnection(pgConnectionString);
            connection.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Cannot connect to PostgreSQL:\n\n{ex.Message}", "Migration Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var result = MessageBox.Show(
            "This will copy all data from SQLite to PostgreSQL.\n\n" +
            "WARNING: Any existing data in the PostgreSQL database will be deleted!\n" +
            "The database will be recreated with the correct schema and all data from SQLite will be copied.\n\n" +
            "Continue?",
            "Migrate Data",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
            return;

        try
        {
            Cursor = Cursors.WaitCursor;
            btnMigrateData.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            var sqlitePath = Program.GetSQLiteDatabasePath();
            var migrationService = new SqliteToPostgresMigrationService();

            var progress = new Progress<string>(message =>
            {
                lblStatus.Text = message;
                Application.DoEvents();
            });

            await Task.Run(() => migrationService.MigrateData(sqlitePath, pgConnectionString, progress));

            MessageBox.Show(
                "Data migration completed successfully!\n\n" +
                "Click Save to switch to PostgreSQL, then restart the application.",
                "Migration Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            var errorMessage = GetFullExceptionMessage(ex);
            ShowCopyableError("Migration Error", $"Migration failed:\n\n{errorMessage}");
        }
        finally
        {
            Cursor = Cursors.Default;
            btnMigrateData.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            lblStatus.Text = "";
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private static string GetFullExceptionMessage(Exception ex)
    {
        var messages = new List<string>();
        var current = ex;
        while (current != null)
        {
            messages.Add(current.Message);
            current = current.InnerException;
        }
        return string.Join("\n\n→ ", messages);
    }

    private static void ShowCopyableError(string title, string message)
    {
        var form = new Form
        {
            Text = title,
            Width = 600,
            Height = 400,
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.Sizable,
            MinimizeBox = false,
            MaximizeBox = true
        };

        var textBox = new TextBox
        {
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Both,
            Dock = DockStyle.Fill,
            Text = message,
            Font = new Font("Consolas", 9),
            SelectionStart = 0,
            SelectionLength = 0
        };

        var buttonPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 45
        };

        var btnCopy = new Button
        {
            Text = "Copy to Clipboard",
            Width = 120,
            Height = 30,
            Location = new Point(10, 8)
        };
        btnCopy.Click += (s, e) =>
        {
            Clipboard.SetText(message);
            MessageBox.Show("Error details copied to clipboard.", "Copied",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        };

        var btnClose = new Button
        {
            Text = "Close",
            Width = 80,
            Height = 30,
            Location = new Point(140, 8)
        };
        btnClose.Click += (s, e) => form.Close();

        buttonPanel.Controls.Add(btnCopy);
        buttonPanel.Controls.Add(btnClose);
        form.Controls.Add(textBox);
        form.Controls.Add(buttonPanel);
        form.AcceptButton = btnClose;

        form.ShowDialog();
    }

    #region Designer Code

    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        grpProvider = new GroupBox();
        rbPostgreSQL = new RadioButton();
        rbSQLite = new RadioButton();
        grpSQLite = new GroupBox();
        txtSQLitePath = new TextBox();
        lblSQLitePath = new Label();
        grpPostgreSQL = new GroupBox();
        txtPassword = new TextBox();
        lblPassword = new Label();
        txtUsername = new TextBox();
        lblUsername = new Label();
        txtDatabase = new TextBox();
        lblDatabase = new Label();
        txtPort = new TextBox();
        lblPort = new Label();
        txtHost = new TextBox();
        lblHost = new Label();
        btnTestConnection = new Button();
        btnCreateDatabase = new Button();
        btnMigrateData = new Button();
        btnSave = new Button();
        btnCancel = new Button();
        lblStatus = new Label();
        grpProvider.SuspendLayout();
        grpSQLite.SuspendLayout();
        grpPostgreSQL.SuspendLayout();
        SuspendLayout();
        //
        // grpProvider
        //
        grpProvider.Controls.Add(rbPostgreSQL);
        grpProvider.Controls.Add(rbSQLite);
        grpProvider.Location = new Point(12, 12);
        grpProvider.Name = "grpProvider";
        grpProvider.Size = new Size(460, 60);
        grpProvider.TabIndex = 0;
        grpProvider.TabStop = false;
        grpProvider.Text = "Database Provider";
        //
        // rbPostgreSQL
        //
        rbPostgreSQL.AutoSize = true;
        rbPostgreSQL.Location = new Point(150, 26);
        rbPostgreSQL.Name = "rbPostgreSQL";
        rbPostgreSQL.Size = new Size(82, 19);
        rbPostgreSQL.TabIndex = 1;
        rbPostgreSQL.Text = "PostgreSQL";
        rbPostgreSQL.CheckedChanged += rbProvider_CheckedChanged;
        //
        // rbSQLite
        //
        rbSQLite.AutoSize = true;
        rbSQLite.Checked = true;
        rbSQLite.Location = new Point(20, 26);
        rbSQLite.Name = "rbSQLite";
        rbSQLite.Size = new Size(102, 19);
        rbSQLite.TabIndex = 0;
        rbSQLite.TabStop = true;
        rbSQLite.Text = "SQLite (Default)";
        rbSQLite.CheckedChanged += rbProvider_CheckedChanged;
        //
        // grpSQLite
        //
        grpSQLite.Controls.Add(txtSQLitePath);
        grpSQLite.Controls.Add(lblSQLitePath);
        grpSQLite.Location = new Point(12, 78);
        grpSQLite.Name = "grpSQLite";
        grpSQLite.Size = new Size(460, 60);
        grpSQLite.TabIndex = 1;
        grpSQLite.TabStop = false;
        grpSQLite.Text = "SQLite Settings";
        //
        // txtSQLitePath
        //
        txtSQLitePath.Location = new Point(100, 24);
        txtSQLitePath.Name = "txtSQLitePath";
        txtSQLitePath.ReadOnly = true;
        txtSQLitePath.Size = new Size(340, 23);
        txtSQLitePath.TabIndex = 1;
        //
        // lblSQLitePath
        //
        lblSQLitePath.AutoSize = true;
        lblSQLitePath.Location = new Point(20, 27);
        lblSQLitePath.Name = "lblSQLitePath";
        lblSQLitePath.Size = new Size(74, 15);
        lblSQLitePath.TabIndex = 0;
        lblSQLitePath.Text = "Database File:";
        //
        // grpPostgreSQL
        //
        grpPostgreSQL.Controls.Add(btnCreateDatabase);
        grpPostgreSQL.Controls.Add(btnTestConnection);
        grpPostgreSQL.Controls.Add(txtPassword);
        grpPostgreSQL.Controls.Add(lblPassword);
        grpPostgreSQL.Controls.Add(txtUsername);
        grpPostgreSQL.Controls.Add(lblUsername);
        grpPostgreSQL.Controls.Add(txtDatabase);
        grpPostgreSQL.Controls.Add(lblDatabase);
        grpPostgreSQL.Controls.Add(txtPort);
        grpPostgreSQL.Controls.Add(lblPort);
        grpPostgreSQL.Controls.Add(txtHost);
        grpPostgreSQL.Controls.Add(lblHost);
        grpPostgreSQL.Location = new Point(12, 144);
        grpPostgreSQL.Name = "grpPostgreSQL";
        grpPostgreSQL.Size = new Size(460, 190);
        grpPostgreSQL.TabIndex = 2;
        grpPostgreSQL.TabStop = false;
        grpPostgreSQL.Text = "PostgreSQL Settings";
        //
        // txtPassword
        //
        txtPassword.Location = new Point(100, 118);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new Size(200, 23);
        txtPassword.TabIndex = 9;
        //
        // lblPassword
        //
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(20, 121);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(57, 15);
        lblPassword.TabIndex = 8;
        lblPassword.Text = "Password:";
        //
        // txtUsername
        //
        txtUsername.Location = new Point(100, 88);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(200, 23);
        txtUsername.TabIndex = 7;
        txtUsername.Text = "postgres";
        //
        // lblUsername
        //
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(20, 91);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(60, 15);
        lblUsername.TabIndex = 6;
        lblUsername.Text = "Username:";
        //
        // txtDatabase
        //
        txtDatabase.Location = new Point(100, 58);
        txtDatabase.Name = "txtDatabase";
        txtDatabase.Size = new Size(200, 23);
        txtDatabase.TabIndex = 5;
        txtDatabase.Text = "bnb";
        //
        // lblDatabase
        //
        lblDatabase.AutoSize = true;
        lblDatabase.Location = new Point(20, 61);
        lblDatabase.Name = "lblDatabase";
        lblDatabase.Size = new Size(56, 15);
        lblDatabase.TabIndex = 4;
        lblDatabase.Text = "Database:";
        //
        // txtPort
        //
        txtPort.Location = new Point(380, 28);
        txtPort.Name = "txtPort";
        txtPort.Size = new Size(60, 23);
        txtPort.TabIndex = 3;
        txtPort.Text = "5432";
        //
        // lblPort
        //
        lblPort.AutoSize = true;
        lblPort.Location = new Point(340, 31);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(32, 15);
        lblPort.TabIndex = 2;
        lblPort.Text = "Port:";
        //
        // txtHost
        //
        txtHost.Location = new Point(100, 28);
        txtHost.Name = "txtHost";
        txtHost.Size = new Size(200, 23);
        txtHost.TabIndex = 1;
        txtHost.Text = "localhost";
        //
        // lblHost
        //
        lblHost.AutoSize = true;
        lblHost.Location = new Point(20, 31);
        lblHost.Name = "lblHost";
        lblHost.Size = new Size(35, 15);
        lblHost.TabIndex = 0;
        lblHost.Text = "Host:";
        //
        // btnTestConnection
        //
        btnTestConnection.Location = new Point(20, 152);
        btnTestConnection.Name = "btnTestConnection";
        btnTestConnection.Size = new Size(120, 28);
        btnTestConnection.TabIndex = 10;
        btnTestConnection.Text = "Test Connection";
        btnTestConnection.Click += btnTestConnection_Click;
        //
        // btnCreateDatabase
        //
        btnCreateDatabase.Location = new Point(150, 152);
        btnCreateDatabase.Name = "btnCreateDatabase";
        btnCreateDatabase.Size = new Size(120, 28);
        btnCreateDatabase.TabIndex = 11;
        btnCreateDatabase.Text = "Create Database";
        btnCreateDatabase.Click += btnCreateDatabase_Click;
        //
        // btnMigrateData
        //
        btnMigrateData.Location = new Point(12, 350);
        btnMigrateData.Name = "btnMigrateData";
        btnMigrateData.Size = new Size(180, 32);
        btnMigrateData.TabIndex = 3;
        btnMigrateData.Text = "Migrate Data to PostgreSQL";
        btnMigrateData.Click += btnMigrateData_Click;
        //
        // btnSave
        //
        btnSave.Location = new Point(292, 350);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(90, 32);
        btnSave.TabIndex = 4;
        btnSave.Text = "Save";
        btnSave.Click += btnSave_Click;
        //
        // btnCancel
        //
        btnCancel.Location = new Point(388, 350);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(84, 32);
        btnCancel.TabIndex = 5;
        btnCancel.Text = "Cancel";
        btnCancel.Click += btnCancel_Click;
        //
        // lblStatus
        //
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(12, 390);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(0, 15);
        lblStatus.TabIndex = 6;
        //
        // DatabaseSettingsForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(484, 411);
        Controls.Add(lblStatus);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(btnMigrateData);
        Controls.Add(grpPostgreSQL);
        Controls.Add(grpSQLite);
        Controls.Add(grpProvider);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "DatabaseSettingsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Database Settings";
        Load += DatabaseSettingsForm_Load;
        grpProvider.ResumeLayout(false);
        grpProvider.PerformLayout();
        grpSQLite.ResumeLayout(false);
        grpSQLite.PerformLayout();
        grpPostgreSQL.ResumeLayout(false);
        grpPostgreSQL.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private GroupBox grpProvider = null!;
    private RadioButton rbPostgreSQL = null!;
    private RadioButton rbSQLite = null!;
    private GroupBox grpSQLite = null!;
    private TextBox txtSQLitePath = null!;
    private Label lblSQLitePath = null!;
    private GroupBox grpPostgreSQL = null!;
    private TextBox txtPassword = null!;
    private Label lblPassword = null!;
    private TextBox txtUsername = null!;
    private Label lblUsername = null!;
    private TextBox txtDatabase = null!;
    private Label lblDatabase = null!;
    private TextBox txtPort = null!;
    private Label lblPort = null!;
    private TextBox txtHost = null!;
    private Label lblHost = null!;
    private Button btnTestConnection = null!;
    private Button btnCreateDatabase = null!;
    private Button btnMigrateData = null!;
    private Button btnSave = null!;
    private Button btnCancel = null!;
    private Label lblStatus = null!;

    #endregion
}
