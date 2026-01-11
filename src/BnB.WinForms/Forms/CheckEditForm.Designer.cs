namespace BnB.WinForms.Forms;

partial class CheckEditForm
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
        pnlSearch = new Panel();
        lblSearch = new Label();
        txtSearch = new TextBox();
        btnFind = new Button();
        splitContainer = new SplitContainer();
        dgvChecks = new DataGridView();
        grpDetails = new GroupBox();
        lblCheckNumber = new Label();
        txtCheckNumber = new TextBox();
        lblCheckDate = new Label();
        dtpCheckDate = new DateTimePicker();
        lblPayTo = new Label();
        txtPayTo = new TextBox();
        lblAmount = new Label();
        txtAmount = new TextBox();
        chkVoid = new CheckBox();
        lblMemo = new Label();
        txtMemo = new TextBox();
        lblComments = new Label();
        txtComments = new TextBox();
        grpAccommodation = new GroupBox();
        lblConfirmation = new Label();
        txtConfirmation = new TextBox();
        lblGuest = new Label();
        txtGuest = new TextBox();
        lblProperty = new Label();
        txtProperty = new TextBox();
        pnlButtons = new Panel();
        btnVoid = new Button();
        btnSave = new Button();
        btnClose = new Button();
        pnlSearch.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvChecks).BeginInit();
        grpDetails.SuspendLayout();
        grpAccommodation.SuspendLayout();
        pnlButtons.SuspendLayout();
        SuspendLayout();
        //
        // pnlSearch
        //
        pnlSearch.Controls.Add(lblSearch);
        pnlSearch.Controls.Add(txtSearch);
        pnlSearch.Controls.Add(btnFind);
        pnlSearch.Dock = DockStyle.Top;
        pnlSearch.Location = new Point(0, 0);
        pnlSearch.Name = "pnlSearch";
        pnlSearch.Padding = new Padding(10);
        pnlSearch.Size = new Size(700, 45);
        //
        // lblSearch
        //
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(13, 15);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(45, 15);
        lblSearch.Text = "Search:";
        //
        // txtSearch
        //
        txtSearch.Location = new Point(65, 12);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(150, 23);
        txtSearch.TabIndex = 0;
        //
        // btnFind
        //
        btnFind.Location = new Point(225, 10);
        btnFind.Name = "btnFind";
        btnFind.Size = new Size(60, 27);
        btnFind.TabIndex = 1;
        btnFind.Text = "&Find";
        btnFind.Click += btnFind_Click;
        //
        // splitContainer
        //
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Location = new Point(0, 45);
        splitContainer.Name = "splitContainer";
        //
        // splitContainer.Panel1
        //
        splitContainer.Panel1.Controls.Add(dgvChecks);
        splitContainer.Panel1MinSize = 350;
        //
        // splitContainer.Panel2
        //
        splitContainer.Panel2.Controls.Add(grpDetails);
        splitContainer.Panel2.Controls.Add(grpAccommodation);
        splitContainer.Panel2MinSize = 250;
        splitContainer.Size = new Size(700, 455);
        splitContainer.SplitterDistance = 380;
        //
        // dgvChecks
        //
        dgvChecks.AllowUserToAddRows = false;
        dgvChecks.AllowUserToDeleteRows = false;
        dgvChecks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvChecks.Dock = DockStyle.Fill;
        dgvChecks.Location = new Point(0, 0);
        dgvChecks.MultiSelect = false;
        dgvChecks.Name = "dgvChecks";
        dgvChecks.ReadOnly = true;
        dgvChecks.RowHeadersWidth = 25;
        dgvChecks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvChecks.Size = new Size(380, 455);
        dgvChecks.TabIndex = 2;
        dgvChecks.SelectionChanged += dgvChecks_SelectionChanged;
        //
        // grpDetails
        //
        grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        grpDetails.Controls.Add(lblCheckNumber);
        grpDetails.Controls.Add(txtCheckNumber);
        grpDetails.Controls.Add(lblCheckDate);
        grpDetails.Controls.Add(dtpCheckDate);
        grpDetails.Controls.Add(lblPayTo);
        grpDetails.Controls.Add(txtPayTo);
        grpDetails.Controls.Add(lblAmount);
        grpDetails.Controls.Add(txtAmount);
        grpDetails.Controls.Add(chkVoid);
        grpDetails.Controls.Add(lblMemo);
        grpDetails.Controls.Add(txtMemo);
        grpDetails.Controls.Add(lblComments);
        grpDetails.Controls.Add(txtComments);
        grpDetails.Enabled = false;
        grpDetails.Location = new Point(5, 5);
        grpDetails.Name = "grpDetails";
        grpDetails.Size = new Size(300, 290);
        grpDetails.TabIndex = 3;
        grpDetails.TabStop = false;
        grpDetails.Text = "Check Details";
        //
        // lblCheckNumber
        //
        lblCheckNumber.AutoSize = true;
        lblCheckNumber.Location = new Point(10, 25);
        lblCheckNumber.Name = "lblCheckNumber";
        lblCheckNumber.Size = new Size(56, 15);
        lblCheckNumber.Text = "Check #:";
        //
        // txtCheckNumber
        //
        txtCheckNumber.Location = new Point(85, 22);
        txtCheckNumber.Name = "txtCheckNumber";
        txtCheckNumber.ReadOnly = true;
        txtCheckNumber.Size = new Size(100, 23);
        txtCheckNumber.TabIndex = 0;
        //
        // lblCheckDate
        //
        lblCheckDate.AutoSize = true;
        lblCheckDate.Location = new Point(10, 55);
        lblCheckDate.Name = "lblCheckDate";
        lblCheckDate.Size = new Size(34, 15);
        lblCheckDate.Text = "Date:";
        //
        // dtpCheckDate
        //
        dtpCheckDate.Format = DateTimePickerFormat.Short;
        dtpCheckDate.Location = new Point(85, 52);
        dtpCheckDate.Name = "dtpCheckDate";
        dtpCheckDate.Size = new Size(100, 23);
        dtpCheckDate.TabIndex = 1;
        //
        // lblPayTo
        //
        lblPayTo.AutoSize = true;
        lblPayTo.Location = new Point(10, 85);
        lblPayTo.Name = "lblPayTo";
        lblPayTo.Size = new Size(44, 15);
        lblPayTo.Text = "Pay To:";
        //
        // txtPayTo
        //
        txtPayTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtPayTo.Location = new Point(85, 82);
        txtPayTo.Name = "txtPayTo";
        txtPayTo.Size = new Size(205, 23);
        txtPayTo.TabIndex = 2;
        //
        // lblAmount
        //
        lblAmount.AutoSize = true;
        lblAmount.Location = new Point(10, 115);
        lblAmount.Name = "lblAmount";
        lblAmount.Size = new Size(54, 15);
        lblAmount.Text = "Amount:";
        //
        // txtAmount
        //
        txtAmount.Location = new Point(85, 112);
        txtAmount.Name = "txtAmount";
        txtAmount.Size = new Size(100, 23);
        txtAmount.TabIndex = 3;
        txtAmount.TextAlign = HorizontalAlignment.Right;
        //
        // chkVoid
        //
        chkVoid.AutoSize = true;
        chkVoid.Enabled = false;
        chkVoid.Location = new Point(200, 115);
        chkVoid.Name = "chkVoid";
        chkVoid.Size = new Size(50, 19);
        chkVoid.TabIndex = 4;
        chkVoid.Text = "Void";
        //
        // lblMemo
        //
        lblMemo.AutoSize = true;
        lblMemo.Location = new Point(10, 145);
        lblMemo.Name = "lblMemo";
        lblMemo.Size = new Size(43, 15);
        lblMemo.Text = "Memo:";
        //
        // txtMemo
        //
        txtMemo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtMemo.Location = new Point(85, 142);
        txtMemo.Name = "txtMemo";
        txtMemo.Size = new Size(205, 23);
        txtMemo.TabIndex = 5;
        //
        // lblComments
        //
        lblComments.AutoSize = true;
        lblComments.Location = new Point(10, 175);
        lblComments.Name = "lblComments";
        lblComments.Size = new Size(69, 15);
        lblComments.Text = "Comments:";
        //
        // txtComments
        //
        txtComments.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtComments.Location = new Point(85, 172);
        txtComments.Multiline = true;
        txtComments.Name = "txtComments";
        txtComments.ScrollBars = ScrollBars.Vertical;
        txtComments.Size = new Size(205, 105);
        txtComments.TabIndex = 6;
        //
        // grpAccommodation
        //
        grpAccommodation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        grpAccommodation.Controls.Add(lblConfirmation);
        grpAccommodation.Controls.Add(txtConfirmation);
        grpAccommodation.Controls.Add(lblGuest);
        grpAccommodation.Controls.Add(txtGuest);
        grpAccommodation.Controls.Add(lblProperty);
        grpAccommodation.Controls.Add(txtProperty);
        grpAccommodation.Location = new Point(5, 301);
        grpAccommodation.Name = "grpAccommodation";
        grpAccommodation.Size = new Size(300, 105);
        grpAccommodation.TabIndex = 4;
        grpAccommodation.TabStop = false;
        grpAccommodation.Text = "Accommodation";
        //
        // lblConfirmation
        //
        lblConfirmation.AutoSize = true;
        lblConfirmation.Location = new Point(10, 25);
        lblConfirmation.Name = "lblConfirmation";
        lblConfirmation.Size = new Size(40, 15);
        lblConfirmation.Text = "Conf#:";
        //
        // txtConfirmation
        //
        txtConfirmation.Location = new Point(85, 22);
        txtConfirmation.Name = "txtConfirmation";
        txtConfirmation.ReadOnly = true;
        txtConfirmation.Size = new Size(100, 23);
        txtConfirmation.TabIndex = 0;
        //
        // lblGuest
        //
        lblGuest.AutoSize = true;
        lblGuest.Location = new Point(10, 55);
        lblGuest.Name = "lblGuest";
        lblGuest.Size = new Size(41, 15);
        lblGuest.Text = "Guest:";
        //
        // txtGuest
        //
        txtGuest.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtGuest.Location = new Point(85, 52);
        txtGuest.Name = "txtGuest";
        txtGuest.ReadOnly = true;
        txtGuest.Size = new Size(205, 23);
        txtGuest.TabIndex = 1;
        //
        // lblProperty
        //
        lblProperty.AutoSize = true;
        lblProperty.Location = new Point(10, 80);
        lblProperty.Name = "lblProperty";
        lblProperty.Size = new Size(55, 15);
        lblProperty.Text = "Property:";
        //
        // txtProperty
        //
        txtProperty.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtProperty.Location = new Point(85, 77);
        txtProperty.Name = "txtProperty";
        txtProperty.ReadOnly = true;
        txtProperty.Size = new Size(205, 23);
        txtProperty.TabIndex = 2;
        //
        // pnlButtons
        //
        pnlButtons.Controls.Add(btnVoid);
        pnlButtons.Controls.Add(btnSave);
        pnlButtons.Controls.Add(btnClose);
        pnlButtons.Dock = DockStyle.Bottom;
        pnlButtons.Location = new Point(0, 500);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(700, 40);
        //
        // btnVoid
        //
        btnVoid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnVoid.Enabled = false;
        btnVoid.Location = new Point(460, 7);
        btnVoid.Name = "btnVoid";
        btnVoid.Size = new Size(70, 28);
        btnVoid.TabIndex = 5;
        btnVoid.Text = "&Void";
        btnVoid.Click += btnVoid_Click;
        //
        // btnSave
        //
        btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSave.Enabled = false;
        btnSave.Location = new Point(536, 7);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(70, 28);
        btnSave.TabIndex = 6;
        btnSave.Text = "&Save";
        btnSave.Click += btnSave_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(617, 7);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(70, 28);
        btnClose.TabIndex = 7;
        btnClose.Text = "C&lose";
        btnClose.Click += btnClose_Click;
        //
        // CheckEditForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 540);
        Controls.Add(splitContainer);
        Controls.Add(pnlSearch);
        Controls.Add(pnlButtons);
        MinimumSize = new Size(600, 500);
        Name = "CheckEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Edit Printed Checks";
        Load += CheckEditForm_Load;
        pnlSearch.ResumeLayout(false);
        pnlSearch.PerformLayout();
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvChecks).EndInit();
        grpDetails.ResumeLayout(false);
        grpDetails.PerformLayout();
        grpAccommodation.ResumeLayout(false);
        grpAccommodation.PerformLayout();
        pnlButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlSearch;
    private Label lblSearch;
    private TextBox txtSearch;
    private Button btnFind;
    private SplitContainer splitContainer;
    private DataGridView dgvChecks;
    private GroupBox grpDetails;
    private Label lblCheckNumber;
    private TextBox txtCheckNumber;
    private Label lblCheckDate;
    private DateTimePicker dtpCheckDate;
    private Label lblPayTo;
    private TextBox txtPayTo;
    private Label lblAmount;
    private TextBox txtAmount;
    private CheckBox chkVoid;
    private Label lblMemo;
    private TextBox txtMemo;
    private Label lblComments;
    private TextBox txtComments;
    private GroupBox grpAccommodation;
    private Label lblConfirmation;
    private TextBox txtConfirmation;
    private Label lblGuest;
    private TextBox txtGuest;
    private Label lblProperty;
    private TextBox txtProperty;
    private Panel pnlButtons;
    private Button btnVoid;
    private Button btnSave;
    private Button btnClose;
}
