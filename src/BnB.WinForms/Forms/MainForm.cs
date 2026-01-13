using BnB.Core.Models;
using BnB.Data.Context;
using BnB.WinForms.Reports;
using BnB.WinForms.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BnB.WinForms.Forms;

/// <summary>
/// Main MDI container form - migrated from MDIBNB.FRM
/// </summary>
public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;

    public MainForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // Apply modern UI theme
        ApplyModernTheme();

        // Set window state
        WindowState = FormWindowState.Maximized;

        // Update title with version
        Text = $"BnB - Hawaii's Best Bed & Breakfasts v{Application.ProductVersion}";
    }

    private void ApplyModernTheme()
    {
        // Apply theme to main form background
        BackColor = UITheme.BackgroundMain;

        // Style the menu strip
        menuStrip.ApplyMenuStripStyle();

        // Style the status strip
        statusStrip.ApplyStatusStripStyle();

        // Set MDI client background color
        foreach (Control control in Controls)
        {
            if (control is MdiClient mdiClient)
            {
                mdiClient.BackColor = UITheme.BackgroundMain;
            }
        }
    }

    #region File Menu Handlers

    private void mnuBackup_Click(object sender, EventArgs e)
    {
        using var dialog = new BackupRestoreForm(restoreMode: false);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                var dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "BnB", "bnb.db");

                File.Copy(dbPath, dialog.SelectedFilePath, overwrite: true);
                MessageBox.Show("Database backup completed successfully.", "Backup Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating backup: {ex.Message}", "Backup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void mnuCommonText_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CommonTextForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CommonTextForm(dbContext);
        });
    }

    private void mnuPrinterSetup_Click(object sender, EventArgs e)
    {
        using var dialog = new PrintDialog();
        dialog.ShowDialog(this);
    }

    private void mnuExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    #endregion

    #region Guests Menu Handlers

    private void mnuGeneralInfo_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<GuestForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new GuestForm(dbContext);
        });
    }

    private void mnuAccommodations_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<AccommodationForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new AccommodationForm(dbContext);
        });
    }

    private void mnuTravelAgent_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<TravelAgentBookingForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new TravelAgentBookingForm(dbContext);
        });
    }

    private void mnuCarReservations_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CarRentalBookingForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CarRentalBookingForm(dbContext);
        });
    }

    private void mnuPayments_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<PaymentForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new PaymentForm(dbContext);
        });
    }

    #endregion

    #region Accounts Menu Handlers

    private void mnuHostProperties_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<PropertyForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new PropertyForm(dbContext);
        });
    }

    private void mnuTravelAgencies_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<TravelAgencyForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new TravelAgencyForm(dbContext);
        });
    }

    private void mnuCarRentalAgencies_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CarAgencyForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CarAgencyForm(dbContext);
        });
    }

    #endregion

    #region Taxes Menu Handlers

    private void mnuSetTaxRates_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<TaxRateForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new TaxRateForm(dbContext);
        });
    }

    private void mnuSetTaxPlans_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<TaxPlanForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new TaxPlanForm(dbContext);
        });
    }

    #endregion

    #region View Menu Handlers

    private void mnuCascade_Click(object sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.Cascade);
    }

    private void mnuTileHorizontal_Click(object sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void mnuTileVertical_Click(object sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.TileVertical);
    }

    #endregion

    #region Availability Menu Handlers

    private void mnuRoomAvailability_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<AvailabilityForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new AvailabilityForm(dbContext);
        });
    }

    private void mnuCarAvailability_Click(object sender, EventArgs e)
    {
        // Car availability is a separate concept - for now show a message
        MessageBox.Show("Car Availability feature coming soon.", "Car Availability",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    #endregion

    #region Admin Menu Handlers

    private void mnuPropertyFacts_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<FactListForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new FactListForm(dbContext);
        });
    }

    private void mnuCompanyInfo_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CompanyInfoForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CompanyInfoForm(dbContext);
        });
    }

    private void mnuDatabaseSettings_Click(object sender, EventArgs e)
    {
        using var form = new DatabaseSettingsForm(_serviceProvider);
        form.ShowDialog(this);
    }

    private void mnuRestoreDatabase_Click(object sender, EventArgs e)
    {
        using var dialog = new BackupRestoreForm(restoreMode: true);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                var dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "BnB", "bnb.db");

                File.Copy(dialog.SelectedFilePath, dbPath, overwrite: true);
                MessageBox.Show("Database restored successfully. Please restart the application.", "Restore Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error restoring database: {ex.Message}", "Restore Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void mnuImportLegacyData_Click(object sender, EventArgs e)
    {
        using var openDialog = new OpenFileDialog
        {
            Title = "Select Legacy Access Database",
            Filter = "Access Database (*.mdb)|*.mdb|All Files (*.*)|*.*",
            DefaultExt = "mdb"
        };

        if (openDialog.ShowDialog(this) != DialogResult.OK)
            return;

        var result = MessageBox.Show(
            "This will:\n" +
            "1. Export data from the Access database using Java\n" +
            "2. Import the data into the application\n\n" +
            "This will replace all existing data in the database.\n\n" +
            "Note: Java must be installed on this computer.\n\n" +
            "Are you sure you want to continue?",
            "Confirm Import",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
            return;

        await ImportLegacyDataAsync(openDialog.FileName);
    }

    private async Task ImportLegacyDataAsync(string mdbFilePath)
    {
        using var progressForm = new Form
        {
            Text = "Importing Legacy Data",
            Size = new Size(550, 400),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false,
            ControlBox = false
        };

        var progressLabel = new Label
        {
            Text = "Starting import...",
            Location = new Point(20, 20),
            AutoSize = true
        };

        var progressBar = new ProgressBar
        {
            Location = new Point(20, 50),
            Size = new Size(490, 25),
            Style = ProgressBarStyle.Marquee
        };

        var logTextBox = new TextBox
        {
            Location = new Point(20, 90),
            Size = new Size(490, 220),
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            ReadOnly = true,
            Font = new Font("Consolas", 9)
        };

        var closeButton = new Button
        {
            Text = "Close",
            Location = new Point(435, 320),
            Width = 75,
            Enabled = false
        };
        closeButton.Click += (s, e) => progressForm.Close();

        progressForm.Controls.AddRange(new Control[] { progressLabel, progressBar, logTextBox, closeButton });

        void Log(string message)
        {
            if (progressForm.InvokeRequired)
            {
                progressForm.Invoke(() => Log(message));
                return;
            }
            progressLabel.Text = message;
            logTextBox.AppendText(message + Environment.NewLine);
            Application.DoEvents();
        }

        progressForm.Show(this);
        Application.DoEvents();

        try
        {
            // Step 1: Find the tools folder
            Log("Locating export tools...");
            var toolsFolder = FindToolsFolder();
            if (toolsFolder == null)
            {
                Log("ERROR: Could not find tools folder with ExportMdb.java");
                MessageBox.Show("Could not find the tools folder containing ExportMdb.java.\n\n" +
                    "Please ensure the 'tools' folder is in the application directory.",
                    "Tools Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Log($"Found tools at: {toolsFolder}");

            // Step 2: Check if Java is available
            Log("Checking for Java...");
            if (!await IsJavaAvailableAsync())
            {
                Log("ERROR: Java not found");
                MessageBox.Show("Java is not installed or not in the system PATH.\n\n" +
                    "Please install Java from https://adoptium.net/ and try again.",
                    "Java Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Log("Java found");

            // Step 3: Ensure JAR files are downloaded
            Log("Checking for required libraries...");
            var libFolder = Path.Combine(toolsFolder, "lib");
            if (!Directory.Exists(libFolder) || !File.Exists(Path.Combine(libFolder, "jackcess-4.0.5.jar")))
            {
                Log("Downloading required libraries (this may take a moment)...");
                await DownloadJackcessLibrariesAsync(toolsFolder);
            }
            Log("Libraries ready");

            // Step 4: Compile Java if needed
            var classFile = Path.Combine(toolsFolder, "ExportMdb.class");
            if (!File.Exists(classFile))
            {
                Log("Compiling export tool...");
                var compileResult = await RunProcessAsync("javac", $"-cp \"lib{Path.DirectorySeparatorChar}*\" ExportMdb.java", toolsFolder);
                if (compileResult.ExitCode != 0)
                {
                    Log($"ERROR: Compilation failed: {compileResult.Error}");
                    MessageBox.Show($"Failed to compile export tool:\n\n{compileResult.Error}",
                        "Compilation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Log("Export tool ready");

            // Step 5: Run the export
            Log($"Exporting data from: {Path.GetFileName(mdbFilePath)}");
            Log("This may take a few minutes for large databases...");

            var exportedDataFolder = Path.Combine(toolsFolder, "exported_data");

            // Clean up old export data
            if (Directory.Exists(exportedDataFolder))
            {
                Directory.Delete(exportedDataFolder, true);
            }

            var cpSeparator = Path.DirectorySeparatorChar == '\\' ? ";" : ":";
            var exportResult = await RunProcessAsync("java",
                $"-cp \".{cpSeparator}lib{Path.DirectorySeparatorChar}*\" ExportMdb \"{mdbFilePath}\"",
                toolsFolder,
                output => Log(output));

            if (exportResult.ExitCode != 0)
            {
                Log($"ERROR: Export failed: {exportResult.Error}");
                MessageBox.Show($"Failed to export data:\n\n{exportResult.Error}",
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 6: Verify export
            if (!Directory.Exists(exportedDataFolder))
            {
                Log("ERROR: Export folder not created");
                MessageBox.Show("Export completed but no data folder was created.",
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var jsonFiles = Directory.GetFiles(exportedDataFolder, "*.json");
            Log($"Export complete: {jsonFiles.Length} tables exported");

            // Step 7: Import JSON data
            Log("");
            Log("=== Starting database import ===");

            var progress = new Progress<string>(Log);
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var importService = new Services.JsonImportService(exportedDataFolder, dbContext, progress);

            var importResult = await importService.ImportAllAsync();

            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 100;

            if (importResult.Success)
            {
                Log("");
                Log("=== Import Summary ===");
                Log($"Tax Rates: {importResult.TaxRates}");
                Log($"Tax Plans: {importResult.TaxPlans}");
                Log($"Travel Agencies: {importResult.TravelAgencies}");
                Log($"Car Agencies: {importResult.CarAgencies}");
                Log($"Properties: {importResult.Properties}");
                Log($"Room Types: {importResult.RoomTypes}");
                Log($"Guests: {importResult.Guests}");
                Log($"Accommodations: {importResult.Accommodations}");
                Log($"Payments: {importResult.Payments}");
                Log($"Checks: {importResult.Checks}");
                Log($"Travel Agent Bookings: {importResult.TravelAgentBookings}");
                Log($"Car Rentals: {importResult.CarRentals}");
                Log("");
                Log($"Total: {importResult.TotalRecords} records imported");

                MessageBox.Show($"Import completed successfully!\n\n{importResult.TotalRecords} records imported.",
                    "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Log($"ERROR: Import failed: {importResult.ErrorMessage}");
                MessageBox.Show($"Import failed: {importResult.ErrorMessage}",
                    "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            progressBar.Style = ProgressBarStyle.Continuous;
            Log($"ERROR: {ex.Message}");
            MessageBox.Show($"Import failed: {ex.Message}", "Import Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            closeButton.Enabled = true;
        }

        // Wait for user to close the form
        while (progressForm.Visible)
        {
            Application.DoEvents();
            await Task.Delay(100);
        }
    }

    private string? FindToolsFolder()
    {
        // Try various locations relative to the application
        var possiblePaths = new[]
        {
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "tools"),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "tools"),
            Path.Combine(Environment.CurrentDirectory, "tools"),
            @"C:\Users\mjc\Desktop\BnB\BnBCode\tools" // Fallback for development
        };

        foreach (var path in possiblePaths)
        {
            var fullPath = Path.GetFullPath(path);
            if (Directory.Exists(fullPath) && File.Exists(Path.Combine(fullPath, "ExportMdb.java")))
            {
                return fullPath;
            }
        }

        return null;
    }

    private async Task<bool> IsJavaAvailableAsync()
    {
        try
        {
            var result = await RunProcessAsync("java", "-version", Environment.CurrentDirectory);
            return result.ExitCode == 0;
        }
        catch
        {
            return false;
        }
    }

    private async Task DownloadJackcessLibrariesAsync(string toolsFolder)
    {
        var libFolder = Path.Combine(toolsFolder, "lib");
        Directory.CreateDirectory(libFolder);

        var libraries = new Dictionary<string, string>
        {
            ["jackcess-4.0.5.jar"] = "https://repo1.maven.org/maven2/com/healthmarketscience/jackcess/jackcess/4.0.5/jackcess-4.0.5.jar",
            ["commons-lang3-3.12.0.jar"] = "https://repo1.maven.org/maven2/org/apache/commons/commons-lang3/3.12.0/commons-lang3-3.12.0.jar",
            ["commons-logging-1.2.jar"] = "https://repo1.maven.org/maven2/commons-logging/commons-logging/1.2/commons-logging-1.2.jar",
            ["slf4j-api-1.7.36.jar"] = "https://repo1.maven.org/maven2/org/slf4j/slf4j-api/1.7.36/slf4j-api-1.7.36.jar",
            ["slf4j-simple-1.7.36.jar"] = "https://repo1.maven.org/maven2/org/slf4j/slf4j-simple/1.7.36/slf4j-simple-1.7.36.jar"
        };

        using var httpClient = new HttpClient();
        foreach (var (fileName, url) in libraries)
        {
            var filePath = Path.Combine(libFolder, fileName);
            if (!File.Exists(filePath))
            {
                var bytes = await httpClient.GetByteArrayAsync(url);
                await File.WriteAllBytesAsync(filePath, bytes);
            }
        }
    }

    private record ProcessResult(int ExitCode, string Output, string Error);

    private async Task<ProcessResult> RunProcessAsync(string fileName, string arguments, string workingDirectory, Action<string>? outputHandler = null)
    {
        using var process = new System.Diagnostics.Process
        {
            StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            }
        };

        var output = new System.Text.StringBuilder();
        var error = new System.Text.StringBuilder();

        process.OutputDataReceived += (s, e) =>
        {
            if (e.Data != null)
            {
                output.AppendLine(e.Data);
                outputHandler?.Invoke(e.Data);
            }
        };

        process.ErrorDataReceived += (s, e) =>
        {
            if (e.Data != null)
            {
                error.AppendLine(e.Data);
            }
        };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        await process.WaitForExitAsync();

        return new ProcessResult(process.ExitCode, output.ToString(), error.ToString());
    }

    private async void mnuImportFromJson_Click(object sender, EventArgs e)
    {
        using var folderDialog = new FolderBrowserDialog
        {
            Description = "Select the folder containing exported JSON files",
            ShowNewFolderButton = false,
            UseDescriptionForTitle = true
        };

        if (folderDialog.ShowDialog(this) == DialogResult.OK)
        {
            // Check if the folder contains expected JSON files
            var jsonFiles = Directory.GetFiles(folderDialog.SelectedPath, "*.json");
            if (jsonFiles.Length == 0)
            {
                MessageBox.Show("The selected folder does not contain any JSON files.\n\n" +
                    "Please select the folder containing the exported JSON files (e.g., 'exported_data').",
                    "No JSON Files Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Found {jsonFiles.Length} JSON files in the selected folder.\n\n" +
                "This will replace all existing data in the database with data from the JSON files.\n\n" +
                "Are you sure you want to continue?",
                "Confirm Import",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                await ImportFromJsonAsync(folderDialog.SelectedPath);
            }
        }
    }

    private async Task ImportFromJsonAsync(string jsonFolderPath)
    {
        using var progressForm = new Form
        {
            Text = "Importing Data from JSON",
            Size = new Size(500, 350),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false,
            ControlBox = false
        };

        var progressLabel = new Label
        {
            Text = "Starting import...",
            Location = new Point(20, 20),
            AutoSize = true
        };

        var progressBar = new ProgressBar
        {
            Location = new Point(20, 50),
            Size = new Size(440, 25),
            Style = ProgressBarStyle.Marquee
        };

        var logTextBox = new TextBox
        {
            Location = new Point(20, 90),
            Size = new Size(440, 180),
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            ReadOnly = true
        };

        var closeButton = new Button
        {
            Text = "Close",
            Location = new Point(385, 280),
            Width = 75,
            Enabled = false
        };
        closeButton.Click += (s, e) => progressForm.Close();

        progressForm.Controls.AddRange(new Control[] { progressLabel, progressBar, logTextBox, closeButton });

        var progress = new Progress<string>(message =>
        {
            progressLabel.Text = message;
            logTextBox.AppendText(message + Environment.NewLine);
        });

        progressForm.Show(this);
        Application.DoEvents();

        try
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var importService = new Services.JsonImportService(jsonFolderPath, dbContext, progress);

            var importResult = await importService.ImportAllAsync();

            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 100;

            if (importResult.Success)
            {
                progressLabel.Text = "Import completed successfully!";
                logTextBox.AppendText(Environment.NewLine);
                logTextBox.AppendText("=== Import Summary ===" + Environment.NewLine);
                logTextBox.AppendText($"Tax Rates: {importResult.TaxRates}" + Environment.NewLine);
                logTextBox.AppendText($"Tax Plans: {importResult.TaxPlans}" + Environment.NewLine);
                logTextBox.AppendText($"Travel Agencies: {importResult.TravelAgencies}" + Environment.NewLine);
                logTextBox.AppendText($"Car Agencies: {importResult.CarAgencies}" + Environment.NewLine);
                logTextBox.AppendText($"Properties: {importResult.Properties}" + Environment.NewLine);
                logTextBox.AppendText($"Room Types: {importResult.RoomTypes}" + Environment.NewLine);
                logTextBox.AppendText($"Guests: {importResult.Guests}" + Environment.NewLine);
                logTextBox.AppendText($"Accommodations: {importResult.Accommodations}" + Environment.NewLine);
                logTextBox.AppendText($"Payments: {importResult.Payments}" + Environment.NewLine);
                logTextBox.AppendText($"Checks: {importResult.Checks}" + Environment.NewLine);
                logTextBox.AppendText($"Travel Agent Bookings: {importResult.TravelAgentBookings}" + Environment.NewLine);
                logTextBox.AppendText($"Car Rentals: {importResult.CarRentals}" + Environment.NewLine);

                MessageBox.Show("Import completed successfully!", "Import Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                progressLabel.Text = "Import failed!";
                logTextBox.AppendText(Environment.NewLine);
                logTextBox.AppendText($"Error: {importResult.ErrorMessage}" + Environment.NewLine);

                MessageBox.Show($"Import failed: {importResult.ErrorMessage}", "Import Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            progressBar.Style = ProgressBarStyle.Continuous;
            progressLabel.Text = "Import failed!";
            logTextBox.AppendText(Environment.NewLine);
            logTextBox.AppendText($"Error: {ex.Message}" + Environment.NewLine);

            MessageBox.Show($"Import failed: {ex.Message}", "Import Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            closeButton.Enabled = true;
        }

        // Wait for user to close the form
        while (progressForm.Visible)
        {
            Application.DoEvents();
            await Task.Delay(100);
        }
    }

    #endregion

    #region Reports Menu Handlers

    private void mnuConfirmations_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<BookingListForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new BookingListForm(dbContext);
        });
    }

    private void mnuArrivals_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Arrivals Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var arrivals = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.ArrivalDate >= startDate && a.ArrivalDate <= endDate)
                .OrderBy(a => a.ArrivalDate)
                .ToList();

            var report = new ArrivalsReport(startDate, endDate, arrivals);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuDepartures_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Departures Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var departures = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .OrderBy(a => a.DepartureDate)
                .ToList();

            var report = new DeparturesReport(startDate, endDate, departures);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuCheckLedger_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Check Ledger Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var checks = dbContext.Checks
                .Include(c => c.Accommodation)
                .ThenInclude(a => a.Guest)
                .Where(c => c.CheckDate >= startDate && c.CheckDate <= endDate)
                .AsEnumerable()
                .Select(c => new CheckRecord
                {
                    CheckNumber = int.TryParse(c.CheckNumber, out var num) ? num : 0,
                    CheckDate = c.CheckDate,
                    PayTo = c.PayableTo,
                    ConfirmationNumber = c.Accommodation.ConfirmationNumber,
                    GuestLastName = c.Accommodation.LastName,
                    Location = c.Accommodation.Location,
                    Category = "Host Payment", // Default category
                    Amount = c.Amount,
                    IsVoid = c.IsVoid
                })
                .OrderBy(c => c.CheckDate)
                .ThenBy(c => c.CheckNumber)
                .ToList();

            var report = new CheckLedgerReport(startDate, endDate, checks);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuNetSummary_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Net Summary Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var accommodations = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .OrderBy(a => a.Property.FullName)
                .ThenBy(a => a.DepartureDate)
                .ToList();

            var report = new NetSummaryReport(startDate, endDate, accommodations);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuCommission_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Commission Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var accommodations = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .Where(a => a.Commission > 0 && a.Commission > 0)
                .OrderBy(a => a.Property.FullName)
                .ThenBy(a => a.DepartureDate)
                .ToList();

            var report = new CommissionReport(startDate, endDate, accommodations);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuHost1099_Click(object sender, EventArgs e)
    {
        // Show year selection dialog
        var currentYear = DateTime.Now.Year;
        var taxYear = ShowYearSelectionDialog(currentYear - 1);
        if (!taxYear.HasValue)
            return;

        var startDate = new DateTime(taxYear.Value, 1, 1);
        var endDate = new DateTime(taxYear.Value, 12, 31);

        var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();

        // Get host 1099 data by aggregating checks written to each host
        var hostData = dbContext.Checks
            .Include(c => c.Accommodation)
            .ThenInclude(a => a.Property)
            .Where(c => c.CheckDate >= startDate && c.CheckDate <= endDate && !c.IsVoid)
            .AsEnumerable()
            .GroupBy(c => c.Accommodation.Property)
            .Select(g => new Host1099Data
            {
                AccountNumber = g.Key.AccountNumber,
                HostName = g.Key.FullName,
                Address = g.Key.MailingAddress,
                City = g.Key.MailingCity,
                State = g.Key.MailingState,
                ZipCode = g.Key.MailingZipCode,
                FederalTaxId = g.Key.FederalTaxId,
                TotalPaid = g.Sum(c => c.Amount),
                ReservationCount = g.Count()
            })
            .OrderBy(h => h.HostName)
            .ToList();

        var report = new Host1099Report(taxYear.Value, hostData);
        using var viewer = new ReportViewerForm(report);
        viewer.ShowDialog(this);
    }

    /// <summary>
    /// Shows a dialog to select a year for tax reporting
    /// </summary>
    private int? ShowYearSelectionDialog(int defaultYear)
    {
        using var dialog = new Form
        {
            Text = "Select Tax Year",
            Size = new Size(280, 150),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var lblYear = new Label { Text = "Tax Year:", Location = new Point(20, 25), AutoSize = true };
        var numYear = new NumericUpDown
        {
            Location = new Point(100, 22),
            Width = 100,
            Minimum = 1990,
            Maximum = DateTime.Now.Year,
            Value = defaultYear
        };

        var btnOK = new Button
        {
            Text = "OK",
            Location = new Point(60, 70),
            Width = 75,
            DialogResult = DialogResult.OK
        };

        var btnCancel = new Button
        {
            Text = "Cancel",
            Location = new Point(145, 70),
            Width = 75,
            DialogResult = DialogResult.Cancel
        };

        dialog.Controls.AddRange(new Control[] { lblYear, numYear, btnOK, btnCancel });
        dialog.AcceptButton = btnOK;
        dialog.CancelButton = btnCancel;

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            return (int)numYear.Value;
        }
        return null;
    }

    private void mnuTrends_Click(object sender, EventArgs e)
    {
        var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
        using var dialog = new TrendsDialogForm(dbContext);
        dialog.ShowDialog(this);
    }

    private void mnuMailingLabels_Click(object sender, EventArgs e)
    {
        var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
        using var form = new MailingLabelsForm(dbContext);
        form.ShowDialog(this);
    }

    private void mnuAccountList_Click(object sender, EventArgs e)
    {
        try
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var properties = dbContext.Properties
                .OrderBy(p => p.Location)
                .ToList();

            if (!properties.Any())
            {
                MessageBox.Show("No host properties found in the database.", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var report = new Reports.AccountListReport(properties);
            using var viewer = new Reports.ReportViewerForm(report);
            viewer.ShowDialog(this);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error generating Account List report: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void mnuArrivalsDeparts_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<ArrivalDepartureForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new ArrivalDepartureForm(dbContext);
        });
    }

    private void mnuDailyBooking_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Daily Booking Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var bookings = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.Guest.DateBooked >= startDate && a.Guest.DateBooked <= endDate)
                .OrderBy(a => a.Guest.DateBooked)
                .ToList();

            var report = new DailyBookingReport(startDate, endDate, bookings);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuHostNotification_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Host Notification Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var arrivals = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.ArrivalDate >= startDate && a.ArrivalDate <= endDate)
                .OrderBy(a => a.Property.Location)
                .ThenBy(a => a.ArrivalDate)
                .ToList();

            var report = new HostNotificationReport(startDate, endDate, arrivals);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuServiceFeeSummary_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Service Fee Summary Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var accommodations = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .OrderBy(a => a.DepartureDate)
                .ToList();

            var report = new ServiceFeeSummaryReport(startDate, endDate, accommodations);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuPayRecSummary_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<PaymentReceivedForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new PaymentReceivedForm(dbContext);
        });
    }

    private void mnuClientTrust_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Client Trust Reconciliation", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var payments = dbContext.Payments
                .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
                .OrderBy(p => p.PaymentDate)
                .ToList();

            var report = new ClientTrustReport(startDate, endDate, payments);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuPayReceivable_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<PaymentReceivableForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new PaymentReceivableForm(dbContext);
        });
    }

    private void mnuRefunds_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Refunds Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            // Note: RefundOwed is a computed property. For now, get all accommodations in date range.
            // A proper implementation would compute refunds based on payments vs charges.
            var refunds = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .OrderBy(a => a.DepartureDate)
                .ToList();

            var report = new RefundsReport(startDate, endDate, refunds);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuOverpayments_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Overpayments Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            // Note: TotalPaid and TotalCharges are computed properties. For now, get all accommodations in date range.
            // A proper implementation would compute overpayments based on payments vs charges.
            var overpayments = dbContext.Accommodations
                .Include(a => a.Guest)
                .Include(a => a.Property)
                .Where(a => a.DepartureDate >= startDate && a.DepartureDate <= endDate)
                .OrderBy(a => a.Property.Location)
                .ThenBy(a => a.DepartureDate)
                .ToList();

            var report = new OverpaymentsReport(startDate, endDate, overpayments);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    private void mnuHostAcctInfo_Click(object sender, EventArgs e)
    {
        var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
        var properties = dbContext.Properties
            .OrderBy(p => p.Location)
            .ToList();

        var report = new HostAccountInfoReport(properties);
        using var viewer = new ReportViewerForm(report);
        viewer.ShowDialog(this);
    }

    private void mnuCarRentalActivity_Click(object sender, EventArgs e)
    {
        ShowDateRangeReport("Car Rental Activity Report", (startDate, endDate) =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            var rentals = dbContext.Set<CarRental>()
                .Include(r => r.Guest)
                .Include(r => r.CarAgency)
                .Where(r => r.PickupDate >= startDate && r.PickupDate <= endDate)
                .OrderBy(r => r.PickupDate)
                .ToList();

            var report = new CarRentalActivityReport(startDate, endDate, rentals);
            using var viewer = new ReportViewerForm(report);
            viewer.ShowDialog(this);
        });
    }

    /// <summary>
    /// Shows a simple date range selection dialog and executes the report callback
    /// </summary>
    private void ShowDateRangeReport(string reportTitle, Action<DateTime, DateTime> generateReport)
    {
        using var dialog = new Form
        {
            Text = $"Select Date Range - {reportTitle}",
            Size = new Size(350, 200),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var lblStart = new Label { Text = "Start Date:", Location = new Point(20, 25), AutoSize = true };
        var dtpStart = new DateTimePicker
        {
            Location = new Point(120, 22),
            Width = 180,
            Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        };

        var lblEnd = new Label { Text = "End Date:", Location = new Point(20, 60), AutoSize = true };
        var dtpEnd = new DateTimePicker
        {
            Location = new Point(120, 57),
            Width = 180,
            Value = DateTime.Now
        };

        var btnOK = new Button
        {
            Text = "Generate Report",
            Location = new Point(80, 110),
            Width = 100,
            DialogResult = DialogResult.OK
        };

        var btnCancel = new Button
        {
            Text = "Cancel",
            Location = new Point(190, 110),
            Width = 80,
            DialogResult = DialogResult.Cancel
        };

        dialog.Controls.AddRange(new Control[] { lblStart, dtpStart, lblEnd, dtpEnd, btnOK, btnCancel });
        dialog.AcceptButton = btnOK;
        dialog.CancelButton = btnCancel;

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                generateReport(dtpStart.Value.Date, dtpEnd.Value.Date);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }

    #endregion

    #region Accounting Menu Handlers

    private void mnuPrintChecks_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CheckPrintForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CheckPrintForm(dbContext);
        });
    }

    private void mnuViewEditChecks_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CheckLedgerReportForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CheckLedgerReportForm(dbContext);
        });
    }

    private void mnuSetCheckNumbers_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<CheckNumberForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new CheckNumberForm(dbContext);
        });
    }

    private void mnuViewEditPayments_Click(object sender, EventArgs e)
    {
        OpenOrActivateForm<PaymentReceivedForm>(() =>
        {
            var dbContext = _serviceProvider.GetRequiredService<BnBDbContext>();
            return new PaymentReceivedForm(dbContext);
        });
    }

    #endregion

    #region Help Menu Handlers

    private void mnuHelpTopics_Click(object sender, EventArgs e)
    {
        // Display help information
        var helpText = @"BnB - Bed & Breakfast Reservation System Help

Getting Started:
- Use the Guests menu to manage guest information, accommodations, and payments
- Use the Accounts menu to manage host properties and agency accounts
- Use the Reports menu to generate various business reports

Key Features:
- Guest Management: Track guest information and reservations
- Property Management: Manage host properties and room types
- Payment Processing: Record and track payments
- Reporting: Generate comprehensive business reports
- Tax Management: Configure tax rates and plans

Navigation:
- Use Ctrl+X to exit the application
- Press F1 for help

For additional support, please contact your system administrator.";

        MessageBox.Show(helpText, "Help Topics",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void mnuAbout_Click(object sender, EventArgs e)
    {
        MessageBox.Show(
            $"BnB - Bed & Breakfast Reservation System\n\n" +
            $"Version: {Application.ProductVersion}\n" +
            $"Hawaii's Best Bed & Breakfasts\n\n" +
            $"Modernized from VB5 to .NET 8",
            "About BnB",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    #endregion

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Check if any child forms have unsaved changes
        foreach (Form child in MdiChildren)
        {
            // TODO: Check for unsaved changes
        }
    }

    /// <summary>
    /// Opens a new MDI child form or activates an existing one of the same type.
    /// </summary>
    private void OpenOrActivateForm<T>(Func<T> formFactory) where T : Form
    {
        // Check if form of this type is already open
        foreach (Form child in MdiChildren)
        {
            if (child is T existingForm)
            {
                existingForm.Activate();
                return;
            }
        }

        // Create and show new form
        var form = formFactory();
        form.MdiParent = this;
        form.Show();
    }
}
