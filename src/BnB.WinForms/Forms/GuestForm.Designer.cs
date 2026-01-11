namespace BnB.WinForms.Forms;

partial class GuestForm
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

        // Main layout panels
        this.splitContainer = new SplitContainer();
        this.panelForm = new Panel();
        this.panelButtons = new Panel();
        this.panelNavigation = new Panel();

        // Labels
        this.lblConfirmationNumber = new Label();
        this.lblFirstName = new Label();
        this.lblLastName = new Label();
        this.lblAddress = new Label();
        this.lblCity = new Label();
        this.lblState = new Label();
        this.lblZipCode = new Label();
        this.lblCountry = new Label();
        this.lblHomePhone = new Label();
        this.lblBusinessPhone = new Label();
        this.lblFax = new Label();
        this.lblEmail = new Label();
        this.lblReferral = new Label();
        this.lblBookedBy = new Label();
        this.lblTravelingWith = new Label();
        this.lblComments = new Label();
        this.lblRecordCount = new Label();

        // TextBoxes
        this.txtConfirmationNumber = new TextBox();
        this.txtFirstName = new TextBox();
        this.txtLastName = new TextBox();
        this.txtAddress = new TextBox();
        this.txtCity = new TextBox();
        this.txtState = new TextBox();
        this.txtZipCode = new TextBox();
        this.txtCountry = new TextBox();
        this.txtHomePhone = new TextBox();
        this.txtBusinessPhone = new TextBox();
        this.txtFax = new TextBox();
        this.txtEmail = new TextBox();
        this.txtReferral = new TextBox();
        this.txtBookedBy = new TextBox();
        this.txtTravelingWith = new TextBox();
        this.txtComments = new TextBox();

        // CheckBox
        this.chkLabelFlag = new CheckBox();

        // Buttons
        this.btnInsert = new Button();
        this.btnUpdate = new Button();
        this.btnDelete = new Button();
        this.btnCommit = new Button();
        this.btnCancel = new Button();
        this.btnFind = new Button();
        this.btnRefresh = new Button();

        // DataGridView for navigation
        this.dgvGuests = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).BeginInit();
        this.SuspendLayout();

        // === Split Container ===
        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Location = new Point(0, 0);
        this.splitContainer.Name = "splitContainer";
        this.splitContainer.Orientation = Orientation.Horizontal;

        // Panel 1: Form fields
        this.splitContainer.Panel1.Controls.Add(this.panelButtons);
        this.splitContainer.Panel1.Controls.Add(this.panelForm);

        // Panel 2: Navigation grid
        this.splitContainer.Panel2.Controls.Add(this.dgvGuests);
        this.splitContainer.Panel2.Controls.Add(this.panelNavigation);

        this.splitContainer.Size = new Size(900, 650);
        this.splitContainer.SplitterDistance = 420;

        // === Panel Form ===
        this.panelForm.Dock = DockStyle.Fill;
        this.panelForm.Padding = new Padding(10);

        int labelX = 20;
        int fieldX = 150;
        int col2LabelX = 450;
        int col2FieldX = 560;
        int rowHeight = 30;
        int y = 15;

        // Row 1: Confirmation Number
        AddLabelAndField(panelForm, lblConfirmationNumber, "Conf #:", txtConfirmationNumber,
            labelX, y, fieldX, 100);
        txtConfirmationNumber.ReadOnly = true;

        // Row 2: Name
        y += rowHeight;
        AddLabelAndField(panelForm, lblFirstName, "First Name:", txtFirstName,
            labelX, y, fieldX, 150);
        AddLabelAndField(panelForm, lblLastName, "Last Name:", txtLastName,
            col2LabelX, y, col2FieldX, 200);

        // Row 3: Address
        y += rowHeight;
        AddLabelAndField(panelForm, lblAddress, "Address:", txtAddress,
            labelX, y, fieldX, 350);

        // Row 4: City, State, Zip
        y += rowHeight;
        AddLabelAndField(panelForm, lblCity, "City:", txtCity,
            labelX, y, fieldX, 150);
        AddLabelAndField(panelForm, lblState, "State:", txtState,
            340, y, 390, 50);
        AddLabelAndField(panelForm, lblZipCode, "Zip:", txtZipCode,
            460, y, 490, 100);

        // Row 5: Country
        y += rowHeight;
        AddLabelAndField(panelForm, lblCountry, "Country:", txtCountry,
            labelX, y, fieldX, 150);

        // Row 6: Phones
        y += rowHeight;
        AddLabelAndField(panelForm, lblHomePhone, "Home Phone:", txtHomePhone,
            labelX, y, fieldX, 150);
        AddLabelAndField(panelForm, lblBusinessPhone, "Bus Phone:", txtBusinessPhone,
            col2LabelX, y, col2FieldX, 150);

        // Row 7: Fax and Email
        y += rowHeight;
        AddLabelAndField(panelForm, lblFax, "Fax:", txtFax,
            labelX, y, fieldX, 150);
        AddLabelAndField(panelForm, lblEmail, "Email:", txtEmail,
            col2LabelX, y, col2FieldX, 200);

        // Row 8: Referral and Booked By
        y += rowHeight;
        AddLabelAndField(panelForm, lblReferral, "Referral:", txtReferral,
            labelX, y, fieldX, 150);
        AddLabelAndField(panelForm, lblBookedBy, "Booked By:", txtBookedBy,
            col2LabelX, y, col2FieldX, 150);

        // Row 9: Traveling With
        y += rowHeight;
        AddLabelAndField(panelForm, lblTravelingWith, "Traveling With:", txtTravelingWith,
            labelX, y, fieldX, 350);

        // Row 10: Comments (multiline)
        y += rowHeight;
        lblComments.Text = "Comments:";
        lblComments.Location = new Point(labelX, y);
        lblComments.AutoSize = true;
        panelForm.Controls.Add(lblComments);

        txtComments.Location = new Point(fieldX, y);
        txtComments.Size = new Size(350, 60);
        txtComments.Multiline = true;
        txtComments.ScrollBars = ScrollBars.Vertical;
        panelForm.Controls.Add(txtComments);

        // Row 11: Suppress from mailing labels
        y += 70;
        chkLabelFlag.Text = "Suppress from mailing labels";
        chkLabelFlag.Location = new Point(fieldX, y);
        chkLabelFlag.AutoSize = true;
        panelForm.Controls.Add(chkLabelFlag);

        // === Panel Buttons ===
        this.panelButtons.Dock = DockStyle.Right;
        this.panelButtons.Width = 120;
        this.panelButtons.Padding = new Padding(5);

        int btnY = 15;
        int btnSpacing = 45;

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

        // === Panel Navigation ===
        this.panelNavigation.Dock = DockStyle.Top;
        this.panelNavigation.Height = 30;
        this.panelNavigation.Padding = new Padding(10, 5, 10, 5);

        this.lblRecordCount.Text = "Record 0 of 0";
        this.lblRecordCount.Dock = DockStyle.Left;
        this.lblRecordCount.AutoSize = true;
        this.panelNavigation.Controls.Add(lblRecordCount);

        // === DataGridView ===
        this.dgvGuests.Dock = DockStyle.Fill;
        this.dgvGuests.AllowUserToAddRows = false;
        this.dgvGuests.AllowUserToDeleteRows = false;
        this.dgvGuests.ReadOnly = true;
        this.dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvGuests.MultiSelect = false;
        this.dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvGuests.SelectionChanged += dgvGuests_SelectionChanged;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(900, 650);
        this.Controls.Add(this.splitContainer);
        this.Name = "GuestForm";
        this.Text = "Guest General Information";
        this.Load += GuestForm_Load;
        this.FormClosing += GuestForm_FormClosing;

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        this.splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).EndInit();
        this.ResumeLayout(false);
    }

    private void AddLabelAndField(Panel panel, Label label, string labelText, TextBox textBox,
        int labelX, int y, int fieldX, int fieldWidth)
    {
        label.Text = labelText;
        label.Location = new Point(labelX, y + 3);
        label.AutoSize = true;
        panel.Controls.Add(label);

        textBox.Location = new Point(fieldX, y);
        textBox.Size = new Size(fieldWidth, 23);
        panel.Controls.Add(textBox);
    }

    private void AddButton(Panel panel, Button button, string text, int y)
    {
        button.Text = text;
        button.Location = new Point(10, y);
        button.Size = new Size(100, 35);
        button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        panel.Controls.Add(button);
    }

    #endregion

    private SplitContainer splitContainer;
    private Panel panelForm;
    private Panel panelButtons;
    private Panel panelNavigation;

    private Label lblConfirmationNumber;
    private Label lblFirstName;
    private Label lblLastName;
    private Label lblAddress;
    private Label lblCity;
    private Label lblState;
    private Label lblZipCode;
    private Label lblCountry;
    private Label lblHomePhone;
    private Label lblBusinessPhone;
    private Label lblFax;
    private Label lblEmail;
    private Label lblReferral;
    private Label lblBookedBy;
    private Label lblTravelingWith;
    private Label lblComments;
    private Label lblRecordCount;

    private TextBox txtConfirmationNumber;
    private TextBox txtFirstName;
    private TextBox txtLastName;
    private TextBox txtAddress;
    private TextBox txtCity;
    private TextBox txtState;
    private TextBox txtZipCode;
    private TextBox txtCountry;
    private TextBox txtHomePhone;
    private TextBox txtBusinessPhone;
    private TextBox txtFax;
    private TextBox txtEmail;
    private TextBox txtReferral;
    private TextBox txtBookedBy;
    private TextBox txtTravelingWith;
    private TextBox txtComments;

    private CheckBox chkLabelFlag;

    private Button btnInsert;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnCommit;
    private Button btnCancel;
    private Button btnFind;
    private Button btnRefresh;

    private DataGridView dgvGuests;
}
