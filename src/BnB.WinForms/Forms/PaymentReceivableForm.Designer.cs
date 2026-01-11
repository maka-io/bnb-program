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
        btnRefresh.Location = new Point(606, 7);
        btnRefresh.Size = new Size(75, 28);
        btnRefresh.TabIndex = 1;
        btnRefresh.Text = "&Refresh";
        btnRefresh.Click += btnRefresh_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(687, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 2;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(768, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 3;
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
    private Button btnPrint;
    private Button btnClose;
}
