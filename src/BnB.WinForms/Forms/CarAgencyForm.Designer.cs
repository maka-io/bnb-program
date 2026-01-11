namespace BnB.WinForms.Forms;

partial class CarAgencyForm
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

        // Labels and TextBoxes
        this.lblName = new Label();
        this.lblContactName = new Label();
        this.lblAddress = new Label();
        this.lblCity = new Label();
        this.lblState = new Label();
        this.lblZipCode = new Label();
        this.lblPhone = new Label();
        this.lblFax = new Label();
        this.lblEmail = new Label();
        this.lblCommissionPercent = new Label();
        this.lblComments = new Label();
        this.lblRecordCount = new Label();

        this.txtName = new TextBox();
        this.txtContactName = new TextBox();
        this.txtAddress = new TextBox();
        this.txtCity = new TextBox();
        this.txtState = new TextBox();
        this.txtZipCode = new TextBox();
        this.txtPhone = new TextBox();
        this.txtFax = new TextBox();
        this.txtEmail = new TextBox();
        this.txtCommissionPercent = new TextBox();
        this.txtComments = new TextBox();

        // Buttons
        this.btnInsert = new Button();
        this.btnUpdate = new Button();
        this.btnDelete = new Button();
        this.btnCommit = new Button();
        this.btnCancel = new Button();
        this.btnFind = new Button();
        this.btnRefresh = new Button();

        // DataGridView
        this.dgvAgencies = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvAgencies)).BeginInit();
        this.SuspendLayout();

        // === Split Container ===
        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Orientation = Orientation.Horizontal;
        this.splitContainer.Panel1.Controls.Add(this.panelButtons);
        this.splitContainer.Panel1.Controls.Add(this.panelForm);
        this.splitContainer.Panel2.Controls.Add(this.dgvAgencies);
        this.splitContainer.Size = new Size(700, 560);
        this.splitContainer.SplitterDistance = 350;

        // === Panel Form ===
        this.panelForm.Dock = DockStyle.Fill;
        this.panelForm.Padding = new Padding(15);

        int labelX = 20;
        int fieldX = 130;
        int y = 20;
        int rowHeight = 30;

        // Agency Name
        AddLabelAndField(panelForm, lblName, "Agency Name:", txtName, labelX, y, fieldX, 250);

        y += rowHeight;
        AddLabelAndField(panelForm, lblContactName, "Contact:", txtContactName, labelX, y, fieldX, 200);

        y += rowHeight;
        AddLabelAndField(panelForm, lblAddress, "Address:", txtAddress, labelX, y, fieldX, 250);

        y += rowHeight;
        AddLabelAndField(panelForm, lblCity, "City:", txtCity, labelX, y, fieldX, 150);

        y += rowHeight;
        AddLabelAndField(panelForm, lblState, "State:", txtState, labelX, y, fieldX, 80);
        AddLabelAndField(panelForm, lblZipCode, "Zip:", txtZipCode, 270, y, 300, 100);

        y += rowHeight;
        AddLabelAndField(panelForm, lblPhone, "Phone:", txtPhone, labelX, y, fieldX, 150);

        y += rowHeight;
        AddLabelAndField(panelForm, lblFax, "Fax:", txtFax, labelX, y, fieldX, 150);

        y += rowHeight;
        AddLabelAndField(panelForm, lblEmail, "Email:", txtEmail, labelX, y, fieldX, 250);

        y += rowHeight;
        AddLabelAndField(panelForm, lblCommissionPercent, "Commission %:", txtCommissionPercent, labelX, y, fieldX, 60);

        y += rowHeight + 5;
        lblComments.Text = "Comments:";
        lblComments.Location = new Point(labelX, y);
        lblComments.AutoSize = true;
        panelForm.Controls.Add(lblComments);

        txtComments.Location = new Point(fieldX, y);
        txtComments.Size = new Size(250, 70);
        txtComments.Multiline = true;
        txtComments.ScrollBars = ScrollBars.Vertical;
        panelForm.Controls.Add(txtComments);

        // Record Count
        lblRecordCount.Text = "Record 0 of 0";
        lblRecordCount.Location = new Point(labelX, y + 80);
        lblRecordCount.AutoSize = true;
        panelForm.Controls.Add(lblRecordCount);

        // === Panel Buttons ===
        this.panelButtons.Dock = DockStyle.Right;
        this.panelButtons.Width = 120;
        this.panelButtons.Padding = new Padding(5);

        int btnY = 15;
        int btnSpacing = 42;

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
        AddButton(panelButtons, btnFind, "&Find", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnRefresh, "&Refresh", btnY);

        btnInsert.Click += btnInsert_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnCommit.Click += btnCommit_Click;
        btnCancel.Click += btnCancel_Click;
        btnFind.Click += btnFind_Click;
        btnRefresh.Click += btnRefresh_Click;

        // === DataGridView ===
        this.dgvAgencies.Dock = DockStyle.Fill;
        this.dgvAgencies.AllowUserToAddRows = false;
        this.dgvAgencies.AllowUserToDeleteRows = false;
        this.dgvAgencies.ReadOnly = true;
        this.dgvAgencies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvAgencies.MultiSelect = false;
        this.dgvAgencies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvAgencies.SelectionChanged += dgvAgencies_SelectionChanged;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(700, 560);
        this.Controls.Add(this.splitContainer);
        this.Name = "CarAgencyForm";
        this.Text = "Car Rental Agency Accounts";
        this.Load += CarAgencyForm_Load;
        this.FormClosing += CarAgencyForm_FormClosing;

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        this.splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvAgencies)).EndInit();
        this.ResumeLayout(false);
    }

    private void AddLabelAndField(Control container, Label label, string labelText, TextBox textBox,
        int labelX, int y, int fieldX, int fieldWidth)
    {
        label.Text = labelText;
        label.Location = new Point(labelX, y + 3);
        label.AutoSize = true;
        container.Controls.Add(label);

        textBox.Location = new Point(fieldX, y);
        textBox.Size = new Size(fieldWidth, 23);
        container.Controls.Add(textBox);
    }

    private void AddButton(Panel panel, Button button, string text, int y)
    {
        button.Text = text;
        button.Location = new Point(10, y);
        button.Size = new Size(100, 34);
        button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        panel.Controls.Add(button);
    }

    #endregion

    private SplitContainer splitContainer;
    private Panel panelForm;
    private Panel panelButtons;

    private Label lblName;
    private Label lblContactName;
    private Label lblAddress;
    private Label lblCity;
    private Label lblState;
    private Label lblZipCode;
    private Label lblPhone;
    private Label lblFax;
    private Label lblEmail;
    private Label lblCommissionPercent;
    private Label lblComments;
    private Label lblRecordCount;

    private TextBox txtName;
    private TextBox txtContactName;
    private TextBox txtAddress;
    private TextBox txtCity;
    private TextBox txtState;
    private TextBox txtZipCode;
    private TextBox txtPhone;
    private TextBox txtFax;
    private TextBox txtEmail;
    private TextBox txtCommissionPercent;
    private TextBox txtComments;

    private Button btnInsert;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnCommit;
    private Button btnCancel;
    private Button btnFind;
    private Button btnRefresh;

    private DataGridView dgvAgencies;
}
