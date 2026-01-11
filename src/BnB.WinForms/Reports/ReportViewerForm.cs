using System.Diagnostics;

namespace BnB.WinForms.Reports;

/// <summary>
/// Report Viewer Form - displays PDF reports with print/save functionality
/// </summary>
public partial class ReportViewerForm : Form
{
    private readonly IReport _report;
    private string? _tempPdfPath;
    private readonly WebBrowser _webBrowser;

    public ReportViewerForm(IReport report)
    {
        _report = report;
        InitializeComponent();

        // Create and configure WebBrowser control for PDF display
        _webBrowser = new WebBrowser
        {
            Dock = DockStyle.Fill,
            AllowNavigation = true,
            AllowWebBrowserDrop = false,
            ScriptErrorsSuppressed = true
        };
        pnlContent.Controls.Add(_webBrowser);
    }

    private void ReportViewerForm_Load(object sender, EventArgs e)
    {
        Text = $"Report: {_report.Title}";
        lblTitle.Text = _report.Title;
        GenerateAndDisplayReport();
    }

    private void GenerateAndDisplayReport()
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            lblStatus.Text = "Generating report...";

            // Generate temp PDF file
            _tempPdfPath = Path.Combine(Path.GetTempPath(), $"BnB_Report_{Guid.NewGuid():N}.pdf");
            _report.SaveToFile(_tempPdfPath);

            // Display in WebBrowser
            _webBrowser.Navigate(_tempPdfPath);
            lblStatus.Text = "Report generated successfully";
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error: {ex.Message}";
            MessageBox.Show($"Error generating report:\n{ex.Message}", "Report Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(_tempPdfPath) || !File.Exists(_tempPdfPath))
            {
                MessageBox.Show("Please generate the report first.", "Print Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Use system default PDF viewer to print
            var startInfo = new ProcessStartInfo
            {
                FileName = _tempPdfPath,
                Verb = "print",
                UseShellExecute = true
            };
            Process.Start(startInfo);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error printing report:\n{ex.Message}", "Print Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*",
                DefaultExt = "pdf",
                FileName = $"{_report.Title.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(_tempPdfPath) && File.Exists(_tempPdfPath))
                {
                    File.Copy(_tempPdfPath, saveDialog.FileName, overwrite: true);
                    MessageBox.Show($"Report saved to:\n{saveDialog.FileName}", "Save Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _report.SaveToFile(saveDialog.FileName);
                    MessageBox.Show($"Report saved to:\n{saveDialog.FileName}", "Save Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving report:\n{ex.Message}", "Save Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnOpenExternal_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(_tempPdfPath) || !File.Exists(_tempPdfPath))
            {
                MessageBox.Show("Please generate the report first.", "Open Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = _tempPdfPath,
                UseShellExecute = true
            };
            Process.Start(startInfo);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening report:\n{ex.Message}", "Open Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        GenerateAndDisplayReport();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void ReportViewerForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Clean up temp file
        try
        {
            if (!string.IsNullOrEmpty(_tempPdfPath) && File.Exists(_tempPdfPath))
            {
                _webBrowser.Navigate("about:blank");
                Application.DoEvents();
                File.Delete(_tempPdfPath);
            }
        }
        catch
        {
            // Ignore cleanup errors
        }
    }
}
