namespace BnB.WinForms.Forms;

partial class CheckPrintForm
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
        dgvChecks = new DataGridView();
        pnlTop = new Panel();
        lblTitle = new Label();
        btnSelectAll = new Button();
        btnSelectNone = new Button();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvChecks).BeginInit();
        pnlTop.SuspendLayout();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // pnlTop
        //
        pnlTop.Controls.Add(lblTitle);
        pnlTop.Controls.Add(btnSelectAll);
        pnlTop.Controls.Add(btnSelectNone);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Size = new Size(750, 45);
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTitle.Location = new Point(12, 12);
        lblTitle.Text = "Checks Ready to Print";
        //
        // btnSelectAll
        //
        btnSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSelectAll.Location = new Point(560, 10);
        btnSelectAll.Size = new Size(85, 28);
        btnSelectAll.Text = "Select &All";
        btnSelectAll.Click += btnSelectAll_Click;
        //
        // btnSelectNone
        //
        btnSelectNone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSelectNone.Location = new Point(651, 10);
        btnSelectNone.Size = new Size(85, 28);
        btnSelectNone.Text = "Select &None";
        btnSelectNone.Click += btnSelectNone_Click;
        //
        // dgvChecks
        //
        dgvChecks.AllowUserToAddRows = false;
        dgvChecks.AllowUserToDeleteRows = false;
        dgvChecks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvChecks.Dock = DockStyle.Fill;
        dgvChecks.Location = new Point(0, 45);
        dgvChecks.MultiSelect = false;
        dgvChecks.RowHeadersWidth = 25;
        dgvChecks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvChecks.Size = new Size(750, 355);
        dgvChecks.TabIndex = 0;
        dgvChecks.CellValueChanged += dgvChecks_CellValueChanged;
        dgvChecks.CellContentClick += dgvChecks_CellContentClick;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 400);
        pnlBottom.Size = new Size(750, 50);
        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(13, 18);
        lblSummary.Text = "Loading...";
        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(506, 11);
        btnPreview.Size = new Size(75, 28);
        btnPreview.TabIndex = 1;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(587, 11);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 2;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(668, 11);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 3;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // CheckPrintForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(750, 450);
        Controls.Add(dgvChecks);
        Controls.Add(pnlTop);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(600, 400);
        Name = "CheckPrintForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Print Checks";
        Load += CheckPrintForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvChecks).EndInit();
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTop;
    private Label lblTitle;
    private Button btnSelectAll;
    private Button btnSelectNone;
    private DataGridView dgvChecks;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
