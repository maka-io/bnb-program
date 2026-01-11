namespace BnB.WinForms.Forms;

partial class OverpaymentForm
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
        dgvOverpayments = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnPrint = new Button();
        btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvOverpayments).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // dgvOverpayments
        //
        dgvOverpayments.AllowUserToAddRows = false;
        dgvOverpayments.AllowUserToDeleteRows = false;
        dgvOverpayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvOverpayments.Dock = DockStyle.Fill;
        dgvOverpayments.Location = new Point(0, 0);
        dgvOverpayments.MultiSelect = false;
        dgvOverpayments.ReadOnly = true;
        dgvOverpayments.RowHeadersWidth = 25;
        dgvOverpayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvOverpayments.Size = new Size(700, 360);
        dgvOverpayments.TabIndex = 0;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
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
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(536, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 1;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(617, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 2;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // OverpaymentForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 400);
        Controls.Add(dgvOverpayments);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(500, 350);
        Name = "OverpaymentForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Overpayments to Host Properties";
        Load += OverpaymentForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvOverpayments).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvOverpayments;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnPrint;
    private Button btnClose;
}
