using System.Diagnostics;
using Microsoft.Web.WebView2.WinForms;

namespace BnB.WinForms.Reports;

/// <summary>
/// Report Viewer Form - displays PDF reports embedded using WebView2
/// </summary>
public partial class ReportViewerForm : Form
{
    private readonly IReport _report;
    private readonly bool _autoPrint;
    private string? _tempPdfPath;
    private readonly WebView2 _webView;
    private bool _webViewInitialized;

    public ReportViewerForm(IReport report, bool autoPrint = false)
    {
        _report = report;
        _autoPrint = autoPrint;
        InitializeComponent();

        // Create and configure WebView2 control for PDF display
        _webView = new WebView2
        {
            Dock = DockStyle.Fill
        };
        pnlContent.Controls.Add(_webView);
    }

    private async void ReportViewerForm_Load(object sender, EventArgs e)
    {
        Text = $"Report: {_report.Title}";
        lblTitle.Text = _report.Title;

        // Initialize WebView2 and then generate report
        await InitializeWebViewAsync();
    }

    private async Task InitializeWebViewAsync()
    {
        try
        {
            lblStatus.Text = "Initializing viewer...";
            Cursor = Cursors.WaitCursor;

            // Initialize WebView2 - this downloads the runtime if needed
            await _webView.EnsureCoreWebView2Async();
            _webViewInitialized = true;

            // Hook up navigation completed for auto-print
            if (_autoPrint)
            {
                _webView.CoreWebView2.NavigationCompleted += OnNavigationCompleted_AutoPrint;
            }

            // Now generate and display the report
            GenerateAndDisplayReport();
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error initializing viewer: {ex.Message}";
            MessageBox.Show(
                $"Could not initialize PDF viewer.\n\n{ex.Message}\n\nPlease ensure Microsoft Edge WebView2 Runtime is installed.",
                "Viewer Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void OnNavigationCompleted_AutoPrint(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
    {
        // Unhook so we only auto-print once
        _webView.CoreWebView2.NavigationCompleted -= OnNavigationCompleted_AutoPrint;

        if (e.IsSuccess)
        {
            // Small delay to ensure PDF is fully rendered before printing
            Task.Delay(500).ContinueWith(_ =>
            {
                if (IsHandleCreated && !IsDisposed)
                {
                    BeginInvoke(() =>
                    {
                        _webView.CoreWebView2.ShowPrintUI(Microsoft.Web.WebView2.Core.CoreWebView2PrintDialogKind.System);
                    });
                }
            });
        }
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

            if (_webViewInitialized)
            {
                // Display in WebView2 - it renders PDFs natively
                _webView.CoreWebView2.Navigate(_tempPdfPath);
                lblStatus.Text = "Report ready";
            }
            else
            {
                lblStatus.Text = "Viewer not ready - use Open button to view PDF";
            }
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

            if (_webViewInitialized)
            {
                // Use system print dialog (not Edge's print preview drawer)
                _webView.CoreWebView2.ShowPrintUI(Microsoft.Web.WebView2.Core.CoreWebView2PrintDialogKind.System);
            }
            else
            {
                // Fallback to system print
                var startInfo = new ProcessStartInfo
                {
                    FileName = _tempPdfPath,
                    Verb = "print",
                    UseShellExecute = true
                };
                Process.Start(startInfo);
            }
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
                FileName = $"{SanitizeFileName(_report.Title)}_{DateTime.Now:yyyyMMdd}.pdf"
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

    private static string SanitizeFileName(string fileName)
    {
        var invalidChars = Path.GetInvalidFileNameChars();
        var sanitized = fileName;
        foreach (var c in invalidChars)
        {
            sanitized = sanitized.Replace(c, '_');
        }
        return sanitized.Replace(" ", "_");
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
        // Clean up WebView2 and temp file
        try
        {
            if (_webViewInitialized)
            {
                _webView.CoreWebView2.Navigate("about:blank");
            }

            // Small delay to allow navigation to complete before deleting
            Application.DoEvents();

            if (!string.IsNullOrEmpty(_tempPdfPath) && File.Exists(_tempPdfPath))
            {
                try
                {
                    File.Delete(_tempPdfPath);
                }
                catch
                {
                    // File may be locked; schedule for cleanup on next startup
                }
            }
        }
        catch
        {
            // Ignore cleanup errors
        }
    }
}
