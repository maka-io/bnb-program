namespace BnB.WinForms.Forms;

partial class RoomTypeForm
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
        lblProperty = new Label();
        cboProperty = new ComboBox();
        grpRoomTypes = new GroupBox();
        dgvRoomTypes = new DataGridView();
        grpDetails = new GroupBox();
        lblRoomType = new Label();
        txtRoomType = new TextBox();
        lblDescription = new Label();
        txtDescription = new TextBox();
        pnlButtons = new Panel();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        btnSave = new Button();
        btnCancel = new Button();
        btnClose = new Button();
        grpRoomTypes.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRoomTypes).BeginInit();
        grpDetails.SuspendLayout();
        pnlButtons.SuspendLayout();
        SuspendLayout();
        //
        // lblProperty
        //
        lblProperty.AutoSize = true;
        lblProperty.Location = new Point(12, 15);
        lblProperty.Name = "lblProperty";
        lblProperty.Size = new Size(55, 15);
        lblProperty.Text = "Property:";
        //
        // cboProperty
        //
        cboProperty.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProperty.Location = new Point(80, 12);
        cboProperty.Name = "cboProperty";
        cboProperty.Size = new Size(300, 23);
        cboProperty.TabIndex = 0;
        cboProperty.SelectedIndexChanged += cboProperty_SelectedIndexChanged;
        //
        // grpRoomTypes
        //
        grpRoomTypes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grpRoomTypes.Controls.Add(dgvRoomTypes);
        grpRoomTypes.Location = new Point(12, 45);
        grpRoomTypes.Name = "grpRoomTypes";
        grpRoomTypes.Size = new Size(410, 200);
        grpRoomTypes.TabIndex = 1;
        grpRoomTypes.TabStop = false;
        grpRoomTypes.Text = "Room Types";
        //
        // dgvRoomTypes
        //
        dgvRoomTypes.AllowUserToAddRows = false;
        dgvRoomTypes.AllowUserToDeleteRows = false;
        dgvRoomTypes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvRoomTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvRoomTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvRoomTypes.Location = new Point(10, 22);
        dgvRoomTypes.MultiSelect = false;
        dgvRoomTypes.Name = "dgvRoomTypes";
        dgvRoomTypes.ReadOnly = true;
        dgvRoomTypes.RowHeadersWidth = 25;
        dgvRoomTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRoomTypes.Size = new Size(390, 168);
        dgvRoomTypes.TabIndex = 0;
        dgvRoomTypes.SelectionChanged += dgvRoomTypes_SelectionChanged;
        //
        // grpDetails
        //
        grpDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grpDetails.Controls.Add(lblRoomType);
        grpDetails.Controls.Add(txtRoomType);
        grpDetails.Controls.Add(lblDescription);
        grpDetails.Controls.Add(txtDescription);
        grpDetails.Location = new Point(12, 251);
        grpDetails.Name = "grpDetails";
        grpDetails.Size = new Size(410, 100);
        grpDetails.TabIndex = 2;
        grpDetails.TabStop = false;
        grpDetails.Text = "Room Type Details";
        //
        // lblRoomType
        //
        lblRoomType.AutoSize = true;
        lblRoomType.Location = new Point(10, 28);
        lblRoomType.Name = "lblRoomType";
        lblRoomType.Size = new Size(70, 15);
        lblRoomType.Text = "Room Type:";
        //
        // txtRoomType
        //
        txtRoomType.Enabled = false;
        txtRoomType.Location = new Point(100, 25);
        txtRoomType.MaxLength = 50;
        txtRoomType.Name = "txtRoomType";
        txtRoomType.Size = new Size(120, 23);
        txtRoomType.TabIndex = 0;
        //
        // lblDescription
        //
        lblDescription.AutoSize = true;
        lblDescription.Location = new Point(10, 60);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(70, 15);
        lblDescription.Text = "Description:";
        //
        // txtDescription
        //
        txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtDescription.Enabled = false;
        txtDescription.Location = new Point(100, 57);
        txtDescription.MaxLength = 100;
        txtDescription.Name = "txtDescription";
        txtDescription.Size = new Size(300, 23);
        txtDescription.TabIndex = 1;
        //
        // pnlButtons
        //
        pnlButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnlButtons.Controls.Add(btnAdd);
        pnlButtons.Controls.Add(btnEdit);
        pnlButtons.Controls.Add(btnDelete);
        pnlButtons.Controls.Add(btnSave);
        pnlButtons.Controls.Add(btnCancel);
        pnlButtons.Controls.Add(btnClose);
        pnlButtons.Location = new Point(12, 357);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(410, 35);
        pnlButtons.TabIndex = 3;
        //
        // btnAdd
        //
        btnAdd.Location = new Point(0, 5);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(60, 28);
        btnAdd.TabIndex = 0;
        btnAdd.Text = "&Add";
        btnAdd.Click += btnAdd_Click;
        //
        // btnEdit
        //
        btnEdit.Location = new Point(66, 5);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(60, 28);
        btnEdit.TabIndex = 1;
        btnEdit.Text = "&Edit";
        btnEdit.Click += btnEdit_Click;
        //
        // btnDelete
        //
        btnDelete.Location = new Point(132, 5);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(60, 28);
        btnDelete.TabIndex = 2;
        btnDelete.Text = "&Delete";
        btnDelete.Click += btnDelete_Click;
        //
        // btnSave
        //
        btnSave.Enabled = false;
        btnSave.Location = new Point(210, 5);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(60, 28);
        btnSave.TabIndex = 3;
        btnSave.Text = "&Save";
        btnSave.Click += btnSave_Click;
        //
        // btnCancel
        //
        btnCancel.Enabled = false;
        btnCancel.Location = new Point(276, 5);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(60, 28);
        btnCancel.TabIndex = 4;
        btnCancel.Text = "Ca&ncel";
        btnCancel.Click += btnCancel_Click;
        //
        // btnClose
        //
        btnClose.Location = new Point(350, 5);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(60, 28);
        btnClose.TabIndex = 5;
        btnClose.Text = "C&lose";
        btnClose.Click += btnClose_Click;
        //
        // RoomTypeForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(434, 401);
        Controls.Add(lblProperty);
        Controls.Add(cboProperty);
        Controls.Add(grpRoomTypes);
        Controls.Add(grpDetails);
        Controls.Add(pnlButtons);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "RoomTypeForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Room Types";
        Load += RoomTypeForm_Load;
        grpRoomTypes.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvRoomTypes).EndInit();
        grpDetails.ResumeLayout(false);
        grpDetails.PerformLayout();
        pnlButtons.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblProperty;
    private ComboBox cboProperty;
    private GroupBox grpRoomTypes;
    private DataGridView dgvRoomTypes;
    private GroupBox grpDetails;
    private Label lblRoomType;
    private TextBox txtRoomType;
    private Label lblDescription;
    private TextBox txtDescription;
    private Panel pnlButtons;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnSave;
    private Button btnCancel;
    private Button btnClose;
}
