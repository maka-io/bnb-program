namespace BnB.WinForms.Forms;

partial class CompanyInfoForm
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

        // Labels
        this.lblCompanyName = new Label();
        this.lblAddress = new Label();
        this.lblCity = new Label();
        this.lblState = new Label();
        this.lblZipCode = new Label();
        this.lblPhone = new Label();
        this.lblFax = new Label();
        this.lblEmail = new Label();
        this.lblWebUrl = new Label();
        this.lblLogo = new Label();

        // TextBoxes
        this.txtCompanyName = new TextBox();
        this.txtAddress = new TextBox();
        this.txtCity = new TextBox();
        this.txtState = new TextBox();
        this.txtZipCode = new TextBox();
        this.txtPhone = new TextBox();
        this.txtFax = new TextBox();
        this.txtEmail = new TextBox();
        this.txtWebUrl = new TextBox();

        // Logo controls
        this.picLogo = new PictureBox();
        this.btnSelectLogo = new Button();
        this.btnRemoveLogo = new Button();
        this.grpLogo = new GroupBox();

        // Buttons
        this.btnEdit = new Button();
        this.btnSave = new Button();
        this.btnCancel = new Button();
        this.btnClose = new Button();

        ((System.ComponentModel.ISupportInitialize)this.picLogo).BeginInit();
        this.grpLogo.SuspendLayout();
        this.SuspendLayout();

        int labelX = 25;
        int fieldX = 130;
        int y = 25;
        int rowHeight = 32;

        // Company Name
        AddLabelAndField(lblCompanyName, "Company Name:", txtCompanyName, labelX, y, fieldX, 300);
        y += rowHeight;

        // Address
        AddLabelAndField(lblAddress, "Address:", txtAddress, labelX, y, fieldX, 300);
        y += rowHeight;

        // City
        AddLabelAndField(lblCity, "City:", txtCity, labelX, y, fieldX, 180);
        y += rowHeight;

        // State and Zip
        AddLabelAndField(lblState, "State:", txtState, labelX, y, fieldX, 80);
        lblZipCode.Text = "Zip:";
        lblZipCode.Location = new Point(260, y + 3);
        lblZipCode.AutoSize = true;
        this.Controls.Add(lblZipCode);
        txtZipCode.Location = new Point(300, y);
        txtZipCode.Size = new Size(100, 23);
        this.Controls.Add(txtZipCode);
        y += rowHeight;

        // Phone
        AddLabelAndField(lblPhone, "Phone:", txtPhone, labelX, y, fieldX, 150);
        y += rowHeight;

        // Fax
        AddLabelAndField(lblFax, "Fax:", txtFax, labelX, y, fieldX, 150);
        y += rowHeight;

        // Email
        AddLabelAndField(lblEmail, "Email:", txtEmail, labelX, y, fieldX, 250);
        y += rowHeight;

        // Web URL
        AddLabelAndField(lblWebUrl, "Website:", txtWebUrl, labelX, y, fieldX, 300);
        y += rowHeight + 10;

        // === Logo Group Box ===
        grpLogo.Text = "Company Logo";
        grpLogo.Location = new Point(460, 25);
        grpLogo.Size = new Size(200, 230);

        // Picture Box for Logo
        picLogo.Location = new Point(15, 25);
        picLogo.Size = new Size(170, 140);
        picLogo.SizeMode = PictureBoxSizeMode.Zoom;
        picLogo.BorderStyle = BorderStyle.FixedSingle;
        picLogo.BackColor = Color.White;
        grpLogo.Controls.Add(picLogo);

        // Select Logo Button
        btnSelectLogo.Text = "Select Logo...";
        btnSelectLogo.Location = new Point(15, 175);
        btnSelectLogo.Size = new Size(80, 28);
        btnSelectLogo.Click += btnSelectLogo_Click;
        grpLogo.Controls.Add(btnSelectLogo);

        // Remove Logo Button
        btnRemoveLogo.Text = "Remove";
        btnRemoveLogo.Location = new Point(105, 175);
        btnRemoveLogo.Size = new Size(80, 28);
        btnRemoveLogo.Click += btnRemoveLogo_Click;
        grpLogo.Controls.Add(btnRemoveLogo);

        this.Controls.Add(grpLogo);

        // === Buttons ===
        int btnWidth = 90;
        int btnHeight = 34;
        int btnSpacing = 100;
        int btnStartX = 60;
        int btnY = y + 10;

        this.btnEdit.Text = "&Edit";
        this.btnEdit.Location = new Point(btnStartX, btnY);
        this.btnEdit.Size = new Size(btnWidth, btnHeight);
        this.btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnEdit.Click += btnEdit_Click;

        this.btnSave.Text = "&Save";
        this.btnSave.Location = new Point(btnStartX + btnSpacing, btnY);
        this.btnSave.Size = new Size(btnWidth, btnHeight);
        this.btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnSave.Click += btnSave_Click;

        this.btnCancel.Text = "&Cancel";
        this.btnCancel.Location = new Point(btnStartX + btnSpacing * 2, btnY);
        this.btnCancel.Size = new Size(btnWidth, btnHeight);
        this.btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnCancel.Click += btnCancel_Click;

        this.btnClose.Text = "C&lose";
        this.btnClose.Location = new Point(btnStartX + btnSpacing * 3, btnY);
        this.btnClose.Size = new Size(btnWidth, btnHeight);
        this.btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        this.btnClose.Click += btnClose_Click;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(680, btnY + 60);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnClose);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "CompanyInfoForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Company Information";
        this.Load += CompanyInfoForm_Load;
        this.FormClosing += CompanyInfoForm_FormClosing;

        ((System.ComponentModel.ISupportInitialize)this.picLogo).EndInit();
        this.grpLogo.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void AddLabelAndField(Label label, string labelText, TextBox textBox,
        int labelX, int y, int fieldX, int fieldWidth)
    {
        label.Text = labelText;
        label.Location = new Point(labelX, y + 3);
        label.AutoSize = true;
        this.Controls.Add(label);

        textBox.Location = new Point(fieldX, y);
        textBox.Size = new Size(fieldWidth, 23);
        this.Controls.Add(textBox);
    }

    #endregion

    private Label lblCompanyName;
    private Label lblAddress;
    private Label lblCity;
    private Label lblState;
    private Label lblZipCode;
    private Label lblPhone;
    private Label lblFax;
    private Label lblEmail;
    private Label lblWebUrl;
    private Label lblLogo;

    private TextBox txtCompanyName;
    private TextBox txtAddress;
    private TextBox txtCity;
    private TextBox txtState;
    private TextBox txtZipCode;
    private TextBox txtPhone;
    private TextBox txtFax;
    private TextBox txtEmail;
    private TextBox txtWebUrl;

    private GroupBox grpLogo;
    private PictureBox picLogo;
    private Button btnSelectLogo;
    private Button btnRemoveLogo;

    private Button btnEdit;
    private Button btnSave;
    private Button btnCancel;
    private Button btnClose;
}
