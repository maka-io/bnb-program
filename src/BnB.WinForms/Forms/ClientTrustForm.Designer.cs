namespace BnB.WinForms.Forms;

partial class ClientTrustForm
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
        grpDateRange = new GroupBox();
        lblStartDate = new Label();
        dtpStartDate = new DateTimePicker();
        lblEndDate = new Label();
        dtpEndDate = new DateTimePicker();
        btnCalculate = new Button();
        grpResults = new GroupBox();
        lblPaymentsReceived = new Label();
        txtPaymentsReceived = new TextBox();
        lblChecksWritten = new Label();
        txtChecksWritten = new TextBox();
        lblNetChange = new Label();
        txtNetChange = new TextBox();
        lblDepositsDue = new Label();
        txtDepositsDue = new TextBox();
        lblPrepaymentsDue = new Label();
        txtPrepaymentsDue = new TextBox();
        lblTotalDue = new Label();
        txtTotalDue = new TextBox();
        pnlButtons = new Panel();
        btnPreview = new Button();
        btnPrint = new Button();
        btnClose = new Button();
        grpDateRange.SuspendLayout();
        grpResults.SuspendLayout();
        pnlButtons.SuspendLayout();
        SuspendLayout();
        //
        // grpDateRange
        //
        grpDateRange.Controls.Add(lblStartDate);
        grpDateRange.Controls.Add(dtpStartDate);
        grpDateRange.Controls.Add(lblEndDate);
        grpDateRange.Controls.Add(dtpEndDate);
        grpDateRange.Controls.Add(btnCalculate);
        grpDateRange.Location = new Point(12, 12);
        grpDateRange.Size = new Size(400, 70);
        grpDateRange.TabStop = false;
        grpDateRange.Text = "Date Range";
        //
        // lblStartDate
        //
        lblStartDate.AutoSize = true;
        lblStartDate.Location = new Point(15, 30);
        lblStartDate.Text = "From:";
        //
        // dtpStartDate
        //
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(55, 27);
        dtpStartDate.Size = new Size(100, 23);
        //
        // lblEndDate
        //
        lblEndDate.AutoSize = true;
        lblEndDate.Location = new Point(170, 30);
        lblEndDate.Text = "To:";
        //
        // dtpEndDate
        //
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(195, 27);
        dtpEndDate.Size = new Size(100, 23);
        //
        // btnCalculate
        //
        btnCalculate.Location = new Point(310, 25);
        btnCalculate.Size = new Size(80, 27);
        btnCalculate.Text = "&Calculate";
        btnCalculate.Click += btnCalculate_Click;
        //
        // grpResults
        //
        grpResults.Controls.Add(lblPaymentsReceived);
        grpResults.Controls.Add(txtPaymentsReceived);
        grpResults.Controls.Add(lblChecksWritten);
        grpResults.Controls.Add(txtChecksWritten);
        grpResults.Controls.Add(lblNetChange);
        grpResults.Controls.Add(txtNetChange);
        grpResults.Controls.Add(lblDepositsDue);
        grpResults.Controls.Add(txtDepositsDue);
        grpResults.Controls.Add(lblPrepaymentsDue);
        grpResults.Controls.Add(txtPrepaymentsDue);
        grpResults.Controls.Add(lblTotalDue);
        grpResults.Controls.Add(txtTotalDue);
        grpResults.Location = new Point(12, 90);
        grpResults.Size = new Size(400, 220);
        grpResults.TabStop = false;
        grpResults.Text = "Trust Account Summary";
        //
        // lblPaymentsReceived
        //
        lblPaymentsReceived.AutoSize = true;
        lblPaymentsReceived.Location = new Point(15, 30);
        lblPaymentsReceived.Text = "Payments Received:";
        //
        // txtPaymentsReceived
        //
        txtPaymentsReceived.Location = new Point(150, 27);
        txtPaymentsReceived.ReadOnly = true;
        txtPaymentsReceived.Size = new Size(120, 23);
        txtPaymentsReceived.TextAlign = HorizontalAlignment.Right;
        //
        // lblChecksWritten
        //
        lblChecksWritten.AutoSize = true;
        lblChecksWritten.Location = new Point(15, 60);
        lblChecksWritten.Text = "Checks Written:";
        //
        // txtChecksWritten
        //
        txtChecksWritten.Location = new Point(150, 57);
        txtChecksWritten.ReadOnly = true;
        txtChecksWritten.Size = new Size(120, 23);
        txtChecksWritten.TextAlign = HorizontalAlignment.Right;
        //
        // lblNetChange
        //
        lblNetChange.AutoSize = true;
        lblNetChange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblNetChange.Location = new Point(15, 95);
        lblNetChange.Text = "Net Change:";
        //
        // txtNetChange
        //
        txtNetChange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        txtNetChange.Location = new Point(150, 92);
        txtNetChange.ReadOnly = true;
        txtNetChange.Size = new Size(120, 23);
        txtNetChange.TextAlign = HorizontalAlignment.Right;
        //
        // lblDepositsDue
        //
        lblDepositsDue.AutoSize = true;
        lblDepositsDue.Location = new Point(15, 135);
        lblDepositsDue.Text = "Deposits Due:";
        //
        // txtDepositsDue
        //
        txtDepositsDue.Location = new Point(150, 132);
        txtDepositsDue.ReadOnly = true;
        txtDepositsDue.Size = new Size(120, 23);
        txtDepositsDue.TextAlign = HorizontalAlignment.Right;
        //
        // lblPrepaymentsDue
        //
        lblPrepaymentsDue.AutoSize = true;
        lblPrepaymentsDue.Location = new Point(15, 165);
        lblPrepaymentsDue.Text = "Prepayments Due:";
        //
        // txtPrepaymentsDue
        //
        txtPrepaymentsDue.Location = new Point(150, 162);
        txtPrepaymentsDue.ReadOnly = true;
        txtPrepaymentsDue.Size = new Size(120, 23);
        txtPrepaymentsDue.TextAlign = HorizontalAlignment.Right;
        //
        // lblTotalDue
        //
        lblTotalDue.AutoSize = true;
        lblTotalDue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTotalDue.Location = new Point(15, 195);
        lblTotalDue.Text = "Total Due:";
        //
        // txtTotalDue
        //
        txtTotalDue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        txtTotalDue.Location = new Point(150, 192);
        txtTotalDue.ReadOnly = true;
        txtTotalDue.Size = new Size(120, 23);
        txtTotalDue.TextAlign = HorizontalAlignment.Right;
        //
        // pnlButtons
        //
        pnlButtons.Controls.Add(btnPreview);
        pnlButtons.Controls.Add(btnPrint);
        pnlButtons.Controls.Add(btnClose);
        pnlButtons.Dock = DockStyle.Bottom;
        pnlButtons.Location = new Point(0, 320);
        pnlButtons.Size = new Size(424, 40);
        //
        // btnPreview
        //
        btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPreview.Location = new Point(178, 7);
        btnPreview.Size = new Size(75, 28);
        btnPreview.Text = "Pre&view";
        btnPreview.Click += btnPreview_Click;
        //
        // btnPrint
        //
        btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPrint.Location = new Point(259, 7);
        btnPrint.Size = new Size(75, 28);
        btnPrint.Text = "&Print";
        btnPrint.Click += btnPrint_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(340, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // ClientTrustForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(424, 360);
        Controls.Add(grpDateRange);
        Controls.Add(grpResults);
        Controls.Add(pnlButtons);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ClientTrustForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Client Trust Reconciliation";
        Load += ClientTrustForm_Load;
        grpDateRange.ResumeLayout(false);
        grpDateRange.PerformLayout();
        grpResults.ResumeLayout(false);
        grpResults.PerformLayout();
        pnlButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpDateRange;
    private Label lblStartDate;
    private DateTimePicker dtpStartDate;
    private Label lblEndDate;
    private DateTimePicker dtpEndDate;
    private Button btnCalculate;
    private GroupBox grpResults;
    private Label lblPaymentsReceived;
    private TextBox txtPaymentsReceived;
    private Label lblChecksWritten;
    private TextBox txtChecksWritten;
    private Label lblNetChange;
    private TextBox txtNetChange;
    private Label lblDepositsDue;
    private TextBox txtDepositsDue;
    private Label lblPrepaymentsDue;
    private TextBox txtPrepaymentsDue;
    private Label lblTotalDue;
    private TextBox txtTotalDue;
    private Panel pnlButtons;
    private Button btnPreview;
    private Button btnPrint;
    private Button btnClose;
}
