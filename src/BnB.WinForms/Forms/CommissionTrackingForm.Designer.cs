namespace BnB.WinForms.Forms;

partial class CommissionTrackingForm
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
        pnlTop = new Panel();
        lblProperty = new Label();
        cboProperty = new ComboBox();
        chkShowUnpaidOnly = new CheckBox();
        dgvCommissions = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnMarkPaid = new Button();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCommissions).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // pnlTop
        //
        pnlTop.Controls.Add(lblProperty);
        pnlTop.Controls.Add(cboProperty);
        pnlTop.Controls.Add(chkShowUnpaidOnly);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Size = new Size(800, 45);
        //
        // lblProperty
        //
        lblProperty.AutoSize = true;
        lblProperty.Location = new Point(12, 15);
        lblProperty.Text = "Property:";
        //
        // cboProperty
        //
        cboProperty.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProperty.Location = new Point(75, 12);
        cboProperty.Size = new Size(200, 23);
        cboProperty.SelectedIndexChanged += cboProperty_SelectedIndexChanged;
        //
        // chkShowUnpaidOnly
        //
        chkShowUnpaidOnly.AutoSize = true;
        chkShowUnpaidOnly.Checked = true;
        chkShowUnpaidOnly.CheckState = CheckState.Checked;
        chkShowUnpaidOnly.Location = new Point(300, 14);
        chkShowUnpaidOnly.Text = "Show unpaid only";
        chkShowUnpaidOnly.CheckedChanged += chkShowUnpaidOnly_CheckedChanged;
        //
        // dgvCommissions
        //
        dgvCommissions.AllowUserToAddRows = false;
        dgvCommissions.AllowUserToDeleteRows = false;
        dgvCommissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCommissions.Dock = DockStyle.Fill;
        dgvCommissions.Location = new Point(0, 45);
        dgvCommissions.MultiSelect = false;
        dgvCommissions.ReadOnly = true;
        dgvCommissions.RowHeadersWidth = 25;
        dgvCommissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCommissions.Size = new Size(800, 365);
        dgvCommissions.TabIndex = 0;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnMarkPaid);
        pnlBottom.Controls.Add(btnPreview);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 410);
        pnlBottom.Size = new Size(800, 40);
        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(13, 13);
        lblSummary.Text = "Loading...";
        //
        // btnMarkPaid
        //
        btnMarkPaid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnMarkPaid.Location = new Point(438, 7);
        btnMarkPaid.Size = new Size(100, 28);
        btnMarkPaid.TabIndex = 1;
        btnMarkPaid.Text = "&Mark Paid";
        btnMarkPaid.Click += btnMarkPaid_Click;
        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(544, 7);
        btnPreview.Size = new Size(75, 28);
        btnPreview.TabIndex = 2;
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(625, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.TabIndex = 3;
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(706, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 4;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // CommissionTrackingForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(dgvCommissions);
        Controls.Add(pnlTop);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(650, 400);
        Name = "CommissionTrackingForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Commission Tracking";
        Load += CommissionTrackingForm_Load;
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCommissions).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTop;
    private Label lblProperty;
    private ComboBox cboProperty;
    private CheckBox chkShowUnpaidOnly;
    private DataGridView dgvCommissions;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnMarkPaid;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
