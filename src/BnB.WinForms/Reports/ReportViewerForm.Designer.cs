namespace BnB.WinForms.Reports;

partial class ReportViewerForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        pnlToolbar = new Panel();
        lblTitle = new Label();
        btnPrint = new Button();
        btnSave = new Button();
        btnOpenExternal = new Button();
        btnRefresh = new Button();
        btnClose = new Button();
        pnlContent = new Panel();
        pnlStatus = new Panel();
        lblStatus = new Label();
        pnlToolbar.SuspendLayout();
        pnlStatus.SuspendLayout();
        SuspendLayout();
        //
        // pnlToolbar
        //
        pnlToolbar.BackColor = SystemColors.ControlLight;
        pnlToolbar.Controls.Add(btnClose);
        pnlToolbar.Controls.Add(btnRefresh);
        pnlToolbar.Controls.Add(btnOpenExternal);
        pnlToolbar.Controls.Add(btnSave);
        pnlToolbar.Controls.Add(btnPrint);
        pnlToolbar.Controls.Add(lblTitle);
        pnlToolbar.Dock = DockStyle.Top;
        pnlToolbar.Location = new Point(0, 0);
        pnlToolbar.Name = "pnlToolbar";
        pnlToolbar.Padding = new Padding(8);
        pnlToolbar.Size = new Size(984, 50);
        pnlToolbar.TabIndex = 0;
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTitle.Location = new Point(12, 14);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(106, 21);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Report Title";
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(556, 11);
        btnPrint.Name = "btnPrint";
        btnPrint.Size = new Size(80, 28);
        btnPrint.TabIndex = 1;
        btnPrint.Text = "&Print";
        btnPrint.UseVisualStyleBackColor = true;
        btnPrint.Click += btnPrint_Click;
        //
        // btnSave
        //
        btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSave.Location = new Point(642, 11);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(80, 28);
        btnSave.TabIndex = 2;
        btnSave.Text = "&Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        //
        // btnOpenExternal
        //
        btnOpenExternal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnOpenExternal.Location = new Point(728, 11);
        btnOpenExternal.Name = "btnOpenExternal";
        btnOpenExternal.Size = new Size(80, 28);
        btnOpenExternal.TabIndex = 3;
        btnOpenExternal.Text = "&Open";
        btnOpenExternal.UseVisualStyleBackColor = true;
        btnOpenExternal.Click += btnOpenExternal_Click;
        //
        // btnRefresh
        //
        btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRefresh.Location = new Point(814, 11);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(80, 28);
        btnRefresh.TabIndex = 4;
        btnRefresh.Text = "&Refresh";
        btnRefresh.UseVisualStyleBackColor = true;
        btnRefresh.Click += btnRefresh_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(900, 11);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(72, 28);
        btnClose.TabIndex = 5;
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;
        //
        // pnlContent
        //
        pnlContent.BorderStyle = BorderStyle.FixedSingle;
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(0, 50);
        pnlContent.Name = "pnlContent";
        pnlContent.Size = new Size(984, 611);
        pnlContent.TabIndex = 1;
        //
        // pnlStatus
        //
        pnlStatus.Controls.Add(lblStatus);
        pnlStatus.Dock = DockStyle.Bottom;
        pnlStatus.Location = new Point(0, 636);
        pnlStatus.Name = "pnlStatus";
        pnlStatus.Padding = new Padding(8, 4, 8, 4);
        pnlStatus.Size = new Size(984, 25);
        pnlStatus.TabIndex = 2;
        //
        // lblStatus
        //
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(8, 4);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(42, 15);
        lblStatus.TabIndex = 0;
        lblStatus.Text = "Ready";
        //
        // ReportViewerForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 661);
        Controls.Add(pnlStatus);
        Controls.Add(pnlContent);
        Controls.Add(pnlToolbar);
        MinimumSize = new Size(800, 600);
        Name = "ReportViewerForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Report Viewer";
        WindowState = FormWindowState.Maximized;
        FormClosing += ReportViewerForm_FormClosing;
        Load += ReportViewerForm_Load;
        pnlToolbar.ResumeLayout(false);
        pnlToolbar.PerformLayout();
        pnlStatus.ResumeLayout(false);
        pnlStatus.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlToolbar;
    private Label lblTitle;
    private Button btnPrint;
    private Button btnSave;
    private Button btnOpenExternal;
    private Button btnRefresh;
    private Button btnClose;
    private Panel pnlContent;
    private Panel pnlStatus;
    private Label lblStatus;
}
