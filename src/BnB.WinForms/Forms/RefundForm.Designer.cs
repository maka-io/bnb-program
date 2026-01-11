namespace BnB.WinForms.Forms;

partial class RefundForm
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
        dgvRefunds = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnMarkRefunded = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvRefunds).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // dgvRefunds
        //
        dgvRefunds.AllowUserToAddRows = false;
        dgvRefunds.AllowUserToDeleteRows = false;
        dgvRefunds.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvRefunds.Dock = DockStyle.Fill;
        dgvRefunds.Location = new Point(0, 0);
        dgvRefunds.MultiSelect = false;
        dgvRefunds.ReadOnly = true;
        dgvRefunds.RowHeadersWidth = 25;
        dgvRefunds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRefunds.Size = new Size(700, 360);
        dgvRefunds.TabIndex = 0;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnMarkRefunded);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 360);
        pnlBottom.Size = new Size(700, 40);
        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(13, 13);
        lblSummary.Text = "Loading...";
        //
        // btnMarkRefunded
        //
        btnMarkRefunded.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnMarkRefunded.Location = new Point(430, 7);
        btnMarkRefunded.Size = new Size(100, 28);
        btnMarkRefunded.TabIndex = 1;
        btnMarkRefunded.Text = "&Mark Refunded";
        btnMarkRefunded.Click += btnMarkRefunded_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(536, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 2;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(617, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 3;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // RefundForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 400);
        Controls.Add(dgvRefunds);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(500, 350);
        Name = "RefundForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Refunds Owed";
        Load += RefundForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvRefunds).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvRefunds;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnMarkRefunded;
    private Button btnPrint;
    private Button btnClose;
}
