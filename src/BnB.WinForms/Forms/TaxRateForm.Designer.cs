namespace BnB.WinForms.Forms;

partial class TaxRateForm
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

        // Group boxes
        this.grpTax1 = new GroupBox();
        this.grpTax2 = new GroupBox();
        this.grpTax3 = new GroupBox();

        // Tax 1 controls
        this.lblTax1Rate = new Label();
        this.txtTax1Rate = new TextBox();
        this.lblTax1Description = new Label();
        this.txtTax1Description = new TextBox();
        this.chkTax1HasFuture = new CheckBox();
        this.lblTax1FutureRate = new Label();
        this.txtTax1FutureRate = new TextBox();
        this.lblTax1EffectiveDate = new Label();
        this.dtpTax1EffectiveDate = new DateTimePicker();

        // Tax 2 controls
        this.lblTax2Rate = new Label();
        this.txtTax2Rate = new TextBox();
        this.lblTax2Description = new Label();
        this.txtTax2Description = new TextBox();
        this.chkTax2HasFuture = new CheckBox();
        this.lblTax2FutureRate = new Label();
        this.txtTax2FutureRate = new TextBox();
        this.lblTax2EffectiveDate = new Label();
        this.dtpTax2EffectiveDate = new DateTimePicker();

        // Tax 3 controls
        this.lblTax3Rate = new Label();
        this.txtTax3Rate = new TextBox();
        this.lblTax3Description = new Label();
        this.txtTax3Description = new TextBox();
        this.chkTax3HasFuture = new CheckBox();
        this.lblTax3FutureRate = new Label();
        this.txtTax3FutureRate = new TextBox();
        this.lblTax3EffectiveDate = new Label();
        this.dtpTax3EffectiveDate = new DateTimePicker();

        // Buttons
        this.btnEdit = new Button();
        this.btnSave = new Button();
        this.btnCancel = new Button();
        this.btnClose = new Button();

        this.SuspendLayout();

        int grpWidth = 520;
        int grpHeight = 110;
        int grpX = 20;
        int y = 20;

        // === Tax 1 Group ===
        SetupTaxGroup(grpTax1, "Tax 1 (State Tax)", grpX, y, grpWidth, grpHeight,
            lblTax1Rate, txtTax1Rate, lblTax1Description, txtTax1Description,
            chkTax1HasFuture, lblTax1FutureRate, txtTax1FutureRate,
            lblTax1EffectiveDate, dtpTax1EffectiveDate);
        chkTax1HasFuture.CheckedChanged += chkTax1HasFuture_CheckedChanged;

        y += grpHeight + 10;

        // === Tax 2 Group ===
        SetupTaxGroup(grpTax2, "Tax 2 (Transient Tax)", grpX, y, grpWidth, grpHeight,
            lblTax2Rate, txtTax2Rate, lblTax2Description, txtTax2Description,
            chkTax2HasFuture, lblTax2FutureRate, txtTax2FutureRate,
            lblTax2EffectiveDate, dtpTax2EffectiveDate);
        chkTax2HasFuture.CheckedChanged += chkTax2HasFuture_CheckedChanged;

        y += grpHeight + 10;

        // === Tax 3 Group ===
        SetupTaxGroup(grpTax3, "Tax 3 (GET Tax)", grpX, y, grpWidth, grpHeight,
            lblTax3Rate, txtTax3Rate, lblTax3Description, txtTax3Description,
            chkTax3HasFuture, lblTax3FutureRate, txtTax3FutureRate,
            lblTax3EffectiveDate, dtpTax3EffectiveDate);
        chkTax3HasFuture.CheckedChanged += chkTax3HasFuture_CheckedChanged;

        y += grpHeight + 20;

        // === Buttons ===
        int btnWidth = 90;
        int btnHeight = 34;
        int btnSpacing = 100;
        int btnStartX = 80;

        this.btnEdit.Text = "&Edit";
        this.btnEdit.Location = new Point(btnStartX, y);
        this.btnEdit.Size = new Size(btnWidth, btnHeight);
        this.btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnEdit.Click += btnEdit_Click;

        this.btnSave.Text = "&Save";
        this.btnSave.Location = new Point(btnStartX + btnSpacing, y);
        this.btnSave.Size = new Size(btnWidth, btnHeight);
        this.btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnSave.Click += btnSave_Click;

        this.btnCancel.Text = "&Cancel";
        this.btnCancel.Location = new Point(btnStartX + btnSpacing * 2, y);
        this.btnCancel.Size = new Size(btnWidth, btnHeight);
        this.btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnCancel.Click += btnCancel_Click;

        this.btnClose.Text = "C&lose";
        this.btnClose.Location = new Point(btnStartX + btnSpacing * 3, y);
        this.btnClose.Size = new Size(btnWidth, btnHeight);
        this.btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnClose.Click += btnClose_Click;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(560, y + 60);
        this.Controls.Add(this.grpTax1);
        this.Controls.Add(this.grpTax2);
        this.Controls.Add(this.grpTax3);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnClose);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "TaxRateForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Set Tax Rates";
        this.Load += TaxRateForm_Load;
        this.FormClosing += TaxRateForm_FormClosing;

        this.ResumeLayout(false);
    }

    private void SetupTaxGroup(GroupBox grp, string title, int x, int y, int width, int height,
        Label lblRate, TextBox txtRate, Label lblDesc, TextBox txtDesc,
        CheckBox chkFuture, Label lblFutureRate, TextBox txtFutureRate,
        Label lblEffDate, DateTimePicker dtpEffDate)
    {
        grp.Text = title;
        grp.Location = new Point(x, y);
        grp.Size = new Size(width, height);

        int row1Y = 22;
        int row2Y = 52;

        // Row 1: Current Rate and Description
        lblRate.Text = "Rate (%):";
        lblRate.Location = new Point(15, row1Y + 3);
        lblRate.AutoSize = true;
        grp.Controls.Add(lblRate);

        txtRate.Location = new Point(80, row1Y);
        txtRate.Size = new Size(70, 23);
        grp.Controls.Add(txtRate);

        lblDesc.Text = "Description:";
        lblDesc.Location = new Point(170, row1Y + 3);
        lblDesc.AutoSize = true;
        grp.Controls.Add(lblDesc);

        txtDesc.Location = new Point(250, row1Y);
        txtDesc.Size = new Size(250, 23);
        grp.Controls.Add(txtDesc);

        // Row 2: Future rate checkbox and rate
        chkFuture.Text = "Future Rate:";
        chkFuture.Location = new Point(15, row2Y);
        chkFuture.AutoSize = true;
        grp.Controls.Add(chkFuture);

        lblFutureRate.Text = "Rate (%):";
        lblFutureRate.Location = new Point(130, row2Y + 3);
        lblFutureRate.AutoSize = true;
        grp.Controls.Add(lblFutureRate);

        txtFutureRate.Location = new Point(195, row2Y);
        txtFutureRate.Size = new Size(70, 23);
        grp.Controls.Add(txtFutureRate);

        lblEffDate.Text = "Effective:";
        lblEffDate.Location = new Point(280, row2Y + 3);
        lblEffDate.AutoSize = true;
        grp.Controls.Add(lblEffDate);

        dtpEffDate.Location = new Point(345, row2Y);
        dtpEffDate.Size = new Size(155, 23);
        dtpEffDate.Format = DateTimePickerFormat.Short;
        grp.Controls.Add(dtpEffDate);

        this.Controls.Add(grp);
    }

    #endregion

    private GroupBox grpTax1;
    private GroupBox grpTax2;
    private GroupBox grpTax3;

    // Tax 1
    private Label lblTax1Rate;
    private TextBox txtTax1Rate;
    private Label lblTax1Description;
    private TextBox txtTax1Description;
    private CheckBox chkTax1HasFuture;
    private Label lblTax1FutureRate;
    private TextBox txtTax1FutureRate;
    private Label lblTax1EffectiveDate;
    private DateTimePicker dtpTax1EffectiveDate;

    // Tax 2
    private Label lblTax2Rate;
    private TextBox txtTax2Rate;
    private Label lblTax2Description;
    private TextBox txtTax2Description;
    private CheckBox chkTax2HasFuture;
    private Label lblTax2FutureRate;
    private TextBox txtTax2FutureRate;
    private Label lblTax2EffectiveDate;
    private DateTimePicker dtpTax2EffectiveDate;

    // Tax 3
    private Label lblTax3Rate;
    private TextBox txtTax3Rate;
    private Label lblTax3Description;
    private TextBox txtTax3Description;
    private CheckBox chkTax3HasFuture;
    private Label lblTax3FutureRate;
    private TextBox txtTax3FutureRate;
    private Label lblTax3EffectiveDate;
    private DateTimePicker dtpTax3EffectiveDate;

    // Buttons
    private Button btnEdit;
    private Button btnSave;
    private Button btnCancel;
    private Button btnClose;
}
