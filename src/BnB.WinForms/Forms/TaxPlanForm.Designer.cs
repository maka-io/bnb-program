namespace BnB.WinForms.Forms;

partial class TaxPlanForm
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
        this.components = new System.ComponentModel.Container();

        // Main layout
        this.splitContainer = new SplitContainer();
        this.panelForm = new Panel();
        this.panelButtons = new Panel();

        // Basic info
        this.grpBasicInfo = new GroupBox();
        this.lblPlanTitle = new Label();
        this.txtPlanTitle = new TextBox();
        this.lblDescription = new Label();
        this.txtDescription = new TextBox();
        this.lblPlanCode = new Label();
        this.txtPlanCode = new TextBox();

        // Tax 1 group
        this.grpTax1 = new GroupBox();
        this.lblTax1Rate = new Label();
        this.txtTax1Rate = new TextBox();
        this.lblTax1Desc = new Label();
        this.txtTax1Desc = new TextBox();
        this.lblTax1Apply = new Label();
        this.cboTax1Apply = new ComboBox();
        this.chkTax1Future = new CheckBox();
        this.txtTax1FutureRate = new TextBox();
        this.dtpTax1FutureDate = new DateTimePicker();

        // Tax 2 group
        this.grpTax2 = new GroupBox();
        this.lblTax2Rate = new Label();
        this.txtTax2Rate = new TextBox();
        this.lblTax2Desc = new Label();
        this.txtTax2Desc = new TextBox();
        this.lblTax2Apply = new Label();
        this.cboTax2Apply = new ComboBox();
        this.chkTax2Future = new CheckBox();
        this.txtTax2FutureRate = new TextBox();
        this.dtpTax2FutureDate = new DateTimePicker();

        // Tax 3 group
        this.grpTax3 = new GroupBox();
        this.lblTax3Rate = new Label();
        this.txtTax3Rate = new TextBox();
        this.lblTax3Desc = new Label();
        this.txtTax3Desc = new TextBox();
        this.lblTax3Apply = new Label();
        this.cboTax3Apply = new ComboBox();
        this.chkTax3Future = new CheckBox();
        this.txtTax3FutureRate = new TextBox();
        this.dtpTax3FutureDate = new DateTimePicker();

        // Record count
        this.lblRecordCount = new Label();

        // Buttons
        this.btnInsert = new Button();
        this.btnUpdate = new Button();
        this.btnDelete = new Button();
        this.btnCommit = new Button();
        this.btnCancel = new Button();
        this.btnClose = new Button();

        // DataGridView
        this.dgvPlans = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).BeginInit();
        this.SuspendLayout();

        // === Split Container ===
        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Orientation = Orientation.Horizontal;
        this.splitContainer.Panel1.Controls.Add(this.panelButtons);
        this.splitContainer.Panel1.Controls.Add(this.panelForm);
        this.splitContainer.Panel2.Controls.Add(this.dgvPlans);
        this.splitContainer.SplitterDistance = 380;

        // === Panel Form ===
        this.panelForm.Dock = DockStyle.Fill;
        this.panelForm.Padding = new Padding(10);
        this.panelForm.AutoScroll = true;

        // === Basic Info Group ===
        this.grpBasicInfo.Text = "Plan Information";
        this.grpBasicInfo.Location = new Point(10, 5);
        this.grpBasicInfo.Size = new Size(500, 85);
        this.panelForm.Controls.Add(this.grpBasicInfo);

        int y = 20;
        this.lblPlanTitle.Text = "Plan Title:";
        this.lblPlanTitle.Location = new Point(15, y + 3);
        this.lblPlanTitle.AutoSize = true;
        this.grpBasicInfo.Controls.Add(this.lblPlanTitle);

        this.txtPlanTitle.Location = new Point(85, y);
        this.txtPlanTitle.Size = new Size(200, 23);
        this.grpBasicInfo.Controls.Add(this.txtPlanTitle);

        this.lblPlanCode.Text = "Code:";
        this.lblPlanCode.Location = new Point(300, y + 3);
        this.lblPlanCode.AutoSize = true;
        this.grpBasicInfo.Controls.Add(this.lblPlanCode);

        this.txtPlanCode.Location = new Point(345, y);
        this.txtPlanCode.Size = new Size(60, 23);
        this.txtPlanCode.ReadOnly = true;
        this.txtPlanCode.BackColor = SystemColors.Control;
        this.grpBasicInfo.Controls.Add(this.txtPlanCode);

        y += 28;
        this.lblDescription.Text = "Description:";
        this.lblDescription.Location = new Point(15, y + 3);
        this.lblDescription.AutoSize = true;
        this.grpBasicInfo.Controls.Add(this.lblDescription);

        this.txtDescription.Location = new Point(85, y);
        this.txtDescription.Size = new Size(320, 23);
        this.grpBasicInfo.Controls.Add(this.txtDescription);

        // === Tax 1 Group ===
        SetupTaxGroup(grpTax1, "Tax 1", 10, 95,
            lblTax1Rate, txtTax1Rate, lblTax1Desc, txtTax1Desc,
            lblTax1Apply, cboTax1Apply, chkTax1Future, txtTax1FutureRate, dtpTax1FutureDate);

        // === Tax 2 Group ===
        SetupTaxGroup(grpTax2, "Tax 2", 10, 185,
            lblTax2Rate, txtTax2Rate, lblTax2Desc, txtTax2Desc,
            lblTax2Apply, cboTax2Apply, chkTax2Future, txtTax2FutureRate, dtpTax2FutureDate);

        // === Tax 3 Group ===
        SetupTaxGroup(grpTax3, "Tax 3", 10, 275,
            lblTax3Rate, txtTax3Rate, lblTax3Desc, txtTax3Desc,
            lblTax3Apply, cboTax3Apply, chkTax3Future, txtTax3FutureRate, dtpTax3FutureDate);

        // Record Count
        this.lblRecordCount.Text = "Record 0 of 0";
        this.lblRecordCount.Location = new Point(15, 360);
        this.lblRecordCount.AutoSize = true;
        this.panelForm.Controls.Add(this.lblRecordCount);

        // === Panel Buttons ===
        this.panelButtons.Dock = DockStyle.Right;
        this.panelButtons.Width = 110;
        this.panelButtons.Padding = new Padding(5);

        int btnY = 15;
        int btnSpacing = 38;

        AddButton(panelButtons, btnInsert, "&Insert", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnUpdate, "&Update", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnDelete, "&Delete", btnY);
        btnY += btnSpacing + 10;
        AddButton(panelButtons, btnCommit, "Co&mmit", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnCancel, "&Cancel", btnY);
        btnY += btnSpacing + 10;
        AddButton(panelButtons, btnClose, "C&lose", btnY);

        btnInsert.Click += btnInsert_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnCommit.Click += btnCommit_Click;
        btnCancel.Click += btnCancel_Click;
        btnClose.Click += btnClose_Click;

        // === DataGridView ===
        this.dgvPlans.Dock = DockStyle.Fill;
        this.dgvPlans.AllowUserToAddRows = false;
        this.dgvPlans.AllowUserToDeleteRows = false;
        this.dgvPlans.ReadOnly = true;
        this.dgvPlans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvPlans.MultiSelect = false;
        this.dgvPlans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvPlans.SelectionChanged += dgvPlans_SelectionChanged;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(650, 600);
        this.MinimumSize = new Size(650, 550);
        this.Controls.Add(this.splitContainer);
        this.Name = "TaxPlanForm";
        this.Text = "Tax Plans";
        this.Load += TaxPlanForm_Load;
        this.FormClosing += TaxPlanForm_FormClosing;

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        this.splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).EndInit();
        this.ResumeLayout(false);
    }

    private void SetupTaxGroup(GroupBox grp, string title, int x, int y,
        Label lblRate, TextBox txtRate, Label lblDesc, TextBox txtDesc,
        Label lblApply, ComboBox cboApply, CheckBox chkFuture, TextBox txtFutureRate, DateTimePicker dtpFutureDate)
    {
        grp.Text = title;
        grp.Location = new Point(x, y);
        grp.Size = new Size(500, 85);
        this.panelForm.Controls.Add(grp);

        int row1Y = 20;
        int row2Y = 50;

        // Row 1: Rate, Description, Apply To
        lblRate.Text = "Rate %:";
        lblRate.Location = new Point(10, row1Y + 3);
        lblRate.AutoSize = true;
        grp.Controls.Add(lblRate);

        txtRate.Location = new Point(60, row1Y);
        txtRate.Size = new Size(70, 23);
        grp.Controls.Add(txtRate);

        lblDesc.Text = "Description:";
        lblDesc.Location = new Point(140, row1Y + 3);
        lblDesc.AutoSize = true;
        grp.Controls.Add(lblDesc);

        txtDesc.Location = new Point(215, row1Y);
        txtDesc.Size = new Size(120, 23);
        grp.Controls.Add(txtDesc);

        lblApply.Text = "Apply To:";
        lblApply.Location = new Point(345, row1Y + 3);
        lblApply.AutoSize = true;
        grp.Controls.Add(lblApply);

        cboApply.Location = new Point(405, row1Y);
        cboApply.Size = new Size(80, 23);
        cboApply.DropDownStyle = ComboBoxStyle.DropDownList;
        cboApply.Items.AddRange(new object[] { "Net", "Gross", "N/A" });
        cboApply.SelectedIndex = 2;
        grp.Controls.Add(cboApply);

        // Row 2: Future rate checkbox, rate, effective date
        chkFuture.Text = "Future Rate:";
        chkFuture.Location = new Point(10, row2Y + 2);
        chkFuture.AutoSize = true;
        grp.Controls.Add(chkFuture);

        txtFutureRate.Location = new Point(110, row2Y);
        txtFutureRate.Size = new Size(70, 23);
        txtFutureRate.Enabled = false;
        grp.Controls.Add(txtFutureRate);

        var lblEffective = new Label();
        lblEffective.Text = "Effective:";
        lblEffective.Location = new Point(190, row2Y + 3);
        lblEffective.AutoSize = true;
        grp.Controls.Add(lblEffective);

        dtpFutureDate.Location = new Point(250, row2Y);
        dtpFutureDate.Size = new Size(120, 23);
        dtpFutureDate.Format = DateTimePickerFormat.Short;
        dtpFutureDate.Enabled = false;
        grp.Controls.Add(dtpFutureDate);
    }

    private void AddButton(Panel panel, Button button, string text, int y)
    {
        button.Text = text;
        button.Location = new Point(5, y);
        button.Size = new Size(95, 30);
        button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        panel.Controls.Add(button);
    }

    #endregion

    private SplitContainer splitContainer;
    private Panel panelForm;
    private Panel panelButtons;

    private GroupBox grpBasicInfo;
    private Label lblPlanTitle;
    private TextBox txtPlanTitle;
    private Label lblDescription;
    private TextBox txtDescription;
    private Label lblPlanCode;
    private TextBox txtPlanCode;

    private GroupBox grpTax1;
    private Label lblTax1Rate;
    private TextBox txtTax1Rate;
    private Label lblTax1Desc;
    private TextBox txtTax1Desc;
    private Label lblTax1Apply;
    private ComboBox cboTax1Apply;
    private CheckBox chkTax1Future;
    private TextBox txtTax1FutureRate;
    private DateTimePicker dtpTax1FutureDate;

    private GroupBox grpTax2;
    private Label lblTax2Rate;
    private TextBox txtTax2Rate;
    private Label lblTax2Desc;
    private TextBox txtTax2Desc;
    private Label lblTax2Apply;
    private ComboBox cboTax2Apply;
    private CheckBox chkTax2Future;
    private TextBox txtTax2FutureRate;
    private DateTimePicker dtpTax2FutureDate;

    private GroupBox grpTax3;
    private Label lblTax3Rate;
    private TextBox txtTax3Rate;
    private Label lblTax3Desc;
    private TextBox txtTax3Desc;
    private Label lblTax3Apply;
    private ComboBox cboTax3Apply;
    private CheckBox chkTax3Future;
    private TextBox txtTax3FutureRate;
    private DateTimePicker dtpTax3FutureDate;

    private Label lblRecordCount;

    private Button btnInsert;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnCommit;
    private Button btnCancel;
    private Button btnClose;

    private DataGridView dgvPlans;
}
