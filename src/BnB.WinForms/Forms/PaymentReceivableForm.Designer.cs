namespace BnB.WinForms.Forms;

partial class PaymentReceivableForm
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
        dgvReceivables = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnRefresh = new Button();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvReceivables).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // dgvReceivables
        //
        dgvReceivables.AllowUserToAddRows = false;
        dgvReceivables.AllowUserToDeleteRows = false;
        dgvReceivables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvReceivables.Dock = DockStyle.Fill;
        dgvReceivables.Location = new Point(0, 0);
        dgvReceivables.MultiSelect = false;
        dgvReceivables.ReadOnly = true;
        dgvReceivables.RowHeadersWidth = 25;
        dgvReceivables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvReceivables.Size = new Size(850, 410);
        dgvReceivables.TabIndex = 0;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnRefresh);
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 410);
        pnlBottom.Size = new Size(850, 40);
        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(13, 13);
        lblSummary.Text = "Loading...";
        //
        // btnRefresh
        //
        btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRefresh.Location = new Point(524, 7);
        btnRefresh.Size = new Size(75, 28);
        btnRefresh.TabIndex = 1;
        btnRefresh.Text = "&Refresh";
        btnRefresh.Click += btnRefresh_Click;
        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(605, 7);
        btnPreview.Size = new Size(75, 28);
        btnPreview.TabIndex = 2;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(686, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 3;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(767, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 4;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // PaymentReceivableForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(850, 450);
        Controls.Add(dgvReceivables);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(700, 400);
        Name = "PaymentReceivableForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Payments Receivable";
        Load += PaymentReceivableForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvReceivables).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvReceivables;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnRefresh;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
