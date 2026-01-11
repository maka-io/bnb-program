namespace BnB.WinForms.Forms;

partial class PropertyFactsForm
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
        splitContainer = new SplitContainer();
        lstProperties = new ListBox();
        tabControl = new TabControl();
        tabGeneral = new TabPage();
        lblLocation = new Label();
        txtLocation = new TextBox();
        lblFullName = new Label();
        txtFullName = new TextBox();
        lblDBA = new Label();
        txtDBA = new TextBox();
        grpPropertyAddress = new GroupBox();
        lblPropAddress = new Label();
        txtPropAddress = new TextBox();
        lblPropCity = new Label();
        txtPropCity = new TextBox();
        lblPropState = new Label();
        txtPropState = new TextBox();
        lblPropZip = new Label();
        txtPropZip = new TextBox();
        lblPropPhone = new Label();
        txtPropPhone = new TextBox();
        grpMailingAddress = new GroupBox();
        lblMailAddress = new Label();
        txtMailAddress = new TextBox();
        lblMailCity = new Label();
        txtMailCity = new TextBox();
        lblMailState = new Label();
        txtMailState = new TextBox();
        lblMailZip = new Label();
        txtMailZip = new TextBox();
        lblMailPhone = new Label();
        txtMailPhone = new TextBox();
        tabContact = new TabPage();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblWebUrl = new Label();
        txtWebUrl = new TextBox();
        tabFinancial = new TabPage();
        lblCheckTo = new Label();
        txtCheckTo = new TextBox();
        lblFederalTaxId = new Label();
        txtFederalTaxId = new TextBox();
        lblPercentToHost = new Label();
        txtPercentToHost = new TextBox();
        lblTaxPlan = new Label();
        txtTaxPlan = new TextBox();
        tabComments = new TabPage();
        txtComments = new TextBox();
        pnlButtons = new Panel();
        btnRoomTypes = new Button();
        btnSave = new Button();
        btnClose = new Button();
        ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
        splitContainer.Panel1.SuspendLayout();
        splitContainer.Panel2.SuspendLayout();
        splitContainer.SuspendLayout();
        tabControl.SuspendLayout();
        tabGeneral.SuspendLayout();
        grpPropertyAddress.SuspendLayout();
        grpMailingAddress.SuspendLayout();
        tabContact.SuspendLayout();
        tabFinancial.SuspendLayout();
        tabComments.SuspendLayout();
        pnlButtons.SuspendLayout();
        SuspendLayout();
        //
        // splitContainer
        //
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Location = new Point(0, 0);
        splitContainer.Name = "splitContainer";
        splitContainer.Panel1.Controls.Add(lstProperties);
        splitContainer.Panel2.Controls.Add(tabControl);
        splitContainer.Size = new Size(750, 500);
        splitContainer.SplitterDistance = 180;
        //
        // lstProperties
        //
        lstProperties.Dock = DockStyle.Fill;
        lstProperties.FormattingEnabled = true;
        lstProperties.Location = new Point(0, 0);
        lstProperties.Name = "lstProperties";
        lstProperties.Size = new Size(180, 500);
        lstProperties.TabIndex = 0;
        lstProperties.SelectedIndexChanged += lstProperties_SelectedIndexChanged;
        //
        // tabControl
        //
        tabControl.Controls.Add(tabGeneral);
        tabControl.Controls.Add(tabContact);
        tabControl.Controls.Add(tabFinancial);
        tabControl.Controls.Add(tabComments);
        tabControl.Dock = DockStyle.Fill;
        tabControl.Location = new Point(0, 0);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(566, 500);
        //
        // tabGeneral
        //
        tabGeneral.Controls.Add(lblLocation);
        tabGeneral.Controls.Add(txtLocation);
        tabGeneral.Controls.Add(lblFullName);
        tabGeneral.Controls.Add(txtFullName);
        tabGeneral.Controls.Add(lblDBA);
        tabGeneral.Controls.Add(txtDBA);
        tabGeneral.Controls.Add(grpPropertyAddress);
        tabGeneral.Controls.Add(grpMailingAddress);
        tabGeneral.Location = new Point(4, 24);
        tabGeneral.Name = "tabGeneral";
        tabGeneral.Padding = new Padding(10);
        tabGeneral.Size = new Size(558, 472);
        tabGeneral.Text = "General";
        //
        // lblLocation
        //
        lblLocation.AutoSize = true;
        lblLocation.Location = new Point(13, 15);
        lblLocation.Size = new Size(55, 15);
        lblLocation.Text = "Location:";
        //
        // txtLocation
        //
        txtLocation.Location = new Point(90, 12);
        txtLocation.Size = new Size(200, 23);
        //
        // lblFullName
        //
        lblFullName.AutoSize = true;
        lblFullName.Location = new Point(13, 45);
        lblFullName.Size = new Size(64, 15);
        lblFullName.Text = "Full Name:";
        //
        // txtFullName
        //
        txtFullName.Location = new Point(90, 42);
        txtFullName.Size = new Size(300, 23);
        //
        // lblDBA
        //
        lblDBA.AutoSize = true;
        lblDBA.Location = new Point(13, 75);
        lblDBA.Size = new Size(33, 15);
        lblDBA.Text = "DBA:";
        //
        // txtDBA
        //
        txtDBA.Location = new Point(90, 72);
        txtDBA.Size = new Size(300, 23);
        //
        // grpPropertyAddress
        //
        grpPropertyAddress.Controls.Add(lblPropAddress);
        grpPropertyAddress.Controls.Add(txtPropAddress);
        grpPropertyAddress.Controls.Add(lblPropCity);
        grpPropertyAddress.Controls.Add(txtPropCity);
        grpPropertyAddress.Controls.Add(lblPropState);
        grpPropertyAddress.Controls.Add(txtPropState);
        grpPropertyAddress.Controls.Add(lblPropZip);
        grpPropertyAddress.Controls.Add(txtPropZip);
        grpPropertyAddress.Controls.Add(lblPropPhone);
        grpPropertyAddress.Controls.Add(txtPropPhone);
        grpPropertyAddress.Location = new Point(13, 105);
        grpPropertyAddress.Size = new Size(520, 130);
        grpPropertyAddress.TabStop = false;
        grpPropertyAddress.Text = "Property Address";
        //
        // lblPropAddress
        //
        lblPropAddress.AutoSize = true;
        lblPropAddress.Location = new Point(10, 25);
        lblPropAddress.Text = "Address:";
        //
        // txtPropAddress
        //
        txtPropAddress.Location = new Point(75, 22);
        txtPropAddress.Size = new Size(280, 23);
        //
        // lblPropCity
        //
        lblPropCity.AutoSize = true;
        lblPropCity.Location = new Point(10, 55);
        lblPropCity.Text = "City:";
        //
        // txtPropCity
        //
        txtPropCity.Location = new Point(75, 52);
        txtPropCity.Size = new Size(150, 23);
        //
        // lblPropState
        //
        lblPropState.AutoSize = true;
        lblPropState.Location = new Point(235, 55);
        lblPropState.Text = "State:";
        //
        // txtPropState
        //
        txtPropState.Location = new Point(280, 52);
        txtPropState.Size = new Size(40, 23);
        //
        // lblPropZip
        //
        lblPropZip.AutoSize = true;
        lblPropZip.Location = new Point(330, 55);
        lblPropZip.Text = "Zip:";
        //
        // txtPropZip
        //
        txtPropZip.Location = new Point(360, 52);
        txtPropZip.Size = new Size(80, 23);
        //
        // lblPropPhone
        //
        lblPropPhone.AutoSize = true;
        lblPropPhone.Location = new Point(10, 85);
        lblPropPhone.Text = "Phone:";
        //
        // txtPropPhone
        //
        txtPropPhone.Location = new Point(75, 82);
        txtPropPhone.Size = new Size(120, 23);
        //
        // grpMailingAddress
        //
        grpMailingAddress.Controls.Add(lblMailAddress);
        grpMailingAddress.Controls.Add(txtMailAddress);
        grpMailingAddress.Controls.Add(lblMailCity);
        grpMailingAddress.Controls.Add(txtMailCity);
        grpMailingAddress.Controls.Add(lblMailState);
        grpMailingAddress.Controls.Add(txtMailState);
        grpMailingAddress.Controls.Add(lblMailZip);
        grpMailingAddress.Controls.Add(txtMailZip);
        grpMailingAddress.Controls.Add(lblMailPhone);
        grpMailingAddress.Controls.Add(txtMailPhone);
        grpMailingAddress.Location = new Point(13, 245);
        grpMailingAddress.Size = new Size(520, 130);
        grpMailingAddress.TabStop = false;
        grpMailingAddress.Text = "Mailing Address";
        //
        // lblMailAddress
        //
        lblMailAddress.AutoSize = true;
        lblMailAddress.Location = new Point(10, 25);
        lblMailAddress.Text = "Address:";
        //
        // txtMailAddress
        //
        txtMailAddress.Location = new Point(75, 22);
        txtMailAddress.Size = new Size(280, 23);
        //
        // lblMailCity
        //
        lblMailCity.AutoSize = true;
        lblMailCity.Location = new Point(10, 55);
        lblMailCity.Text = "City:";
        //
        // txtMailCity
        //
        txtMailCity.Location = new Point(75, 52);
        txtMailCity.Size = new Size(150, 23);
        //
        // lblMailState
        //
        lblMailState.AutoSize = true;
        lblMailState.Location = new Point(235, 55);
        lblMailState.Text = "State:";
        //
        // txtMailState
        //
        txtMailState.Location = new Point(280, 52);
        txtMailState.Size = new Size(40, 23);
        //
        // lblMailZip
        //
        lblMailZip.AutoSize = true;
        lblMailZip.Location = new Point(330, 55);
        lblMailZip.Text = "Zip:";
        //
        // txtMailZip
        //
        txtMailZip.Location = new Point(360, 52);
        txtMailZip.Size = new Size(80, 23);
        //
        // lblMailPhone
        //
        lblMailPhone.AutoSize = true;
        lblMailPhone.Location = new Point(10, 85);
        lblMailPhone.Text = "Phone:";
        //
        // txtMailPhone
        //
        txtMailPhone.Location = new Point(75, 82);
        txtMailPhone.Size = new Size(120, 23);
        //
        // tabContact
        //
        tabContact.Controls.Add(lblEmail);
        tabContact.Controls.Add(txtEmail);
        tabContact.Controls.Add(lblWebUrl);
        tabContact.Controls.Add(txtWebUrl);
        tabContact.Location = new Point(4, 24);
        tabContact.Name = "tabContact";
        tabContact.Padding = new Padding(10);
        tabContact.Size = new Size(558, 472);
        tabContact.Text = "Contact";
        //
        // lblEmail
        //
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(13, 25);
        lblEmail.Text = "Email:";
        //
        // txtEmail
        //
        txtEmail.Location = new Point(80, 22);
        txtEmail.Size = new Size(300, 23);
        //
        // lblWebUrl
        //
        lblWebUrl.AutoSize = true;
        lblWebUrl.Location = new Point(13, 55);
        lblWebUrl.Text = "Web URL:";
        //
        // txtWebUrl
        //
        txtWebUrl.Location = new Point(80, 52);
        txtWebUrl.Size = new Size(300, 23);
        //
        // tabFinancial
        //
        tabFinancial.Controls.Add(lblCheckTo);
        tabFinancial.Controls.Add(txtCheckTo);
        tabFinancial.Controls.Add(lblFederalTaxId);
        tabFinancial.Controls.Add(txtFederalTaxId);
        tabFinancial.Controls.Add(lblPercentToHost);
        tabFinancial.Controls.Add(txtPercentToHost);
        tabFinancial.Controls.Add(lblTaxPlan);
        tabFinancial.Controls.Add(txtTaxPlan);
        tabFinancial.Location = new Point(4, 24);
        tabFinancial.Name = "tabFinancial";
        tabFinancial.Padding = new Padding(10);
        tabFinancial.Size = new Size(558, 472);
        tabFinancial.Text = "Financial";
        //
        // lblCheckTo
        //
        lblCheckTo.AutoSize = true;
        lblCheckTo.Location = new Point(13, 25);
        lblCheckTo.Text = "Check To:";
        //
        // txtCheckTo
        //
        txtCheckTo.Location = new Point(110, 22);
        txtCheckTo.Size = new Size(250, 23);
        //
        // lblFederalTaxId
        //
        lblFederalTaxId.AutoSize = true;
        lblFederalTaxId.Location = new Point(13, 55);
        lblFederalTaxId.Text = "Federal Tax ID:";
        //
        // txtFederalTaxId
        //
        txtFederalTaxId.Location = new Point(110, 52);
        txtFederalTaxId.Size = new Size(150, 23);
        //
        // lblPercentToHost
        //
        lblPercentToHost.AutoSize = true;
        lblPercentToHost.Location = new Point(13, 85);
        lblPercentToHost.Text = "Percent to Host:";
        //
        // txtPercentToHost
        //
        txtPercentToHost.Location = new Point(110, 82);
        txtPercentToHost.Size = new Size(80, 23);
        //
        // lblTaxPlan
        //
        lblTaxPlan.AutoSize = true;
        lblTaxPlan.Location = new Point(13, 115);
        lblTaxPlan.Text = "Tax Plan:";
        //
        // txtTaxPlan
        //
        txtTaxPlan.Location = new Point(110, 112);
        txtTaxPlan.Size = new Size(100, 23);
        //
        // tabComments
        //
        tabComments.Controls.Add(txtComments);
        tabComments.Location = new Point(4, 24);
        tabComments.Name = "tabComments";
        tabComments.Padding = new Padding(10);
        tabComments.Size = new Size(558, 472);
        tabComments.Text = "Comments";
        //
        // txtComments
        //
        txtComments.Dock = DockStyle.Fill;
        txtComments.Location = new Point(10, 10);
        txtComments.Multiline = true;
        txtComments.ScrollBars = ScrollBars.Vertical;
        txtComments.Size = new Size(538, 452);
        //
        // pnlButtons
        //
        pnlButtons.Controls.Add(btnRoomTypes);
        pnlButtons.Controls.Add(btnSave);
        pnlButtons.Controls.Add(btnClose);
        pnlButtons.Dock = DockStyle.Bottom;
        pnlButtons.Location = new Point(0, 500);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(750, 40);
        //
        // btnRoomTypes
        //
        btnRoomTypes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRoomTypes.Location = new Point(490, 7);
        btnRoomTypes.Name = "btnRoomTypes";
        btnRoomTypes.Size = new Size(90, 28);
        btnRoomTypes.Text = "Room &Types";
        btnRoomTypes.Click += btnRoomTypes_Click;
        //
        // btnSave
        //
        btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSave.Location = new Point(586, 7);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(75, 28);
        btnSave.Text = "&Save";
        btnSave.Click += btnSave_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(667, 7);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(75, 28);
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // PropertyFactsForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(750, 540);
        Controls.Add(splitContainer);
        Controls.Add(pnlButtons);
        MinimumSize = new Size(650, 500);
        Name = "PropertyFactsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Property Facts";
        Load += PropertyFactsForm_Load;
        splitContainer.Panel1.ResumeLayout(false);
        splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        tabControl.ResumeLayout(false);
        tabGeneral.ResumeLayout(false);
        tabGeneral.PerformLayout();
        grpPropertyAddress.ResumeLayout(false);
        grpPropertyAddress.PerformLayout();
        grpMailingAddress.ResumeLayout(false);
        grpMailingAddress.PerformLayout();
        tabContact.ResumeLayout(false);
        tabContact.PerformLayout();
        tabFinancial.ResumeLayout(false);
        tabFinancial.PerformLayout();
        tabComments.ResumeLayout(false);
        tabComments.PerformLayout();
        pnlButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer;
    private ListBox lstProperties;
    private TabControl tabControl;
    private TabPage tabGeneral;
    private TabPage tabContact;
    private TabPage tabFinancial;
    private TabPage tabComments;
    private Label lblLocation;
    private TextBox txtLocation;
    private Label lblFullName;
    private TextBox txtFullName;
    private Label lblDBA;
    private TextBox txtDBA;
    private GroupBox grpPropertyAddress;
    private Label lblPropAddress;
    private TextBox txtPropAddress;
    private Label lblPropCity;
    private TextBox txtPropCity;
    private Label lblPropState;
    private TextBox txtPropState;
    private Label lblPropZip;
    private TextBox txtPropZip;
    private Label lblPropPhone;
    private TextBox txtPropPhone;
    private GroupBox grpMailingAddress;
    private Label lblMailAddress;
    private TextBox txtMailAddress;
    private Label lblMailCity;
    private TextBox txtMailCity;
    private Label lblMailState;
    private TextBox txtMailState;
    private Label lblMailZip;
    private TextBox txtMailZip;
    private Label lblMailPhone;
    private TextBox txtMailPhone;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblWebUrl;
    private TextBox txtWebUrl;
    private Label lblCheckTo;
    private TextBox txtCheckTo;
    private Label lblFederalTaxId;
    private TextBox txtFederalTaxId;
    private Label lblPercentToHost;
    private TextBox txtPercentToHost;
    private Label lblTaxPlan;
    private TextBox txtTaxPlan;
    private TextBox txtComments;
    private Panel pnlButtons;
    private Button btnRoomTypes;
    private Button btnSave;
    private Button btnClose;
}
