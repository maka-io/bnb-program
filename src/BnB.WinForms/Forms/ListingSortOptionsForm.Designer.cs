namespace BnB.WinForms.Forms;

partial class ListingSortOptionsForm
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
        grpSortOrder = new GroupBox();
        lstSortOrder = new ListBox();
        btnSortMoveUp = new Button();
        btnSortMoveDown = new Button();
        chkDescending = new CheckBox();
        grpColumnOrder = new GroupBox();
        lstColumnOrder = new ListBox();
        btnColMoveUp = new Button();
        btnColMoveDown = new Button();
        grpDateFormat = new GroupBox();
        cboDateFormat = new ComboBox();
        lblSampleLabel = new Label();
        lblSampleDate = new Label();
        btnFonts = new Button();
        btnCancel = new Button();
        btnOK = new Button();
        grpSortOrder.SuspendLayout();
        grpColumnOrder.SuspendLayout();
        grpDateFormat.SuspendLayout();
        SuspendLayout();
        //
        // grpSortOrder
        //
        grpSortOrder.Controls.Add(lstSortOrder);
        grpSortOrder.Controls.Add(btnSortMoveUp);
        grpSortOrder.Controls.Add(btnSortMoveDown);
        grpSortOrder.Controls.Add(chkDescending);
        grpSortOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpSortOrder.Location = new Point(12, 12);
        grpSortOrder.Name = "grpSortOrder";
        grpSortOrder.Size = new Size(270, 200);
        grpSortOrder.TabIndex = 0;
        grpSortOrder.TabStop = false;
        grpSortOrder.Text = "Row Sort Order";
        //
        // lstSortOrder
        //
        lstSortOrder.Font = new Font("Segoe UI", 9F);
        lstSortOrder.FormattingEnabled = true;
        lstSortOrder.ItemHeight = 15;
        lstSortOrder.Location = new Point(10, 25);
        lstSortOrder.Name = "lstSortOrder";
        lstSortOrder.Size = new Size(160, 139);
        lstSortOrder.TabIndex = 0;
        lstSortOrder.SelectedIndexChanged += lstSortOrder_SelectedIndexChanged;
        //
        // btnSortMoveUp
        //
        btnSortMoveUp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSortMoveUp.Location = new Point(180, 25);
        btnSortMoveUp.Name = "btnSortMoveUp";
        btnSortMoveUp.Size = new Size(80, 28);
        btnSortMoveUp.TabIndex = 1;
        btnSortMoveUp.Text = "Move Up";
        btnSortMoveUp.UseVisualStyleBackColor = true;
        btnSortMoveUp.Click += btnSortMoveUp_Click;
        //
        // btnSortMoveDown
        //
        btnSortMoveDown.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSortMoveDown.Location = new Point(180, 59);
        btnSortMoveDown.Name = "btnSortMoveDown";
        btnSortMoveDown.Size = new Size(80, 28);
        btnSortMoveDown.TabIndex = 2;
        btnSortMoveDown.Text = "Move Down";
        btnSortMoveDown.UseVisualStyleBackColor = true;
        btnSortMoveDown.Click += btnSortMoveDown_Click;
        //
        // chkDescending
        //
        chkDescending.AutoSize = true;
        chkDescending.Font = new Font("Segoe UI", 9F);
        chkDescending.Location = new Point(10, 172);
        chkDescending.Name = "chkDescending";
        chkDescending.Size = new Size(148, 19);
        chkDescending.TabIndex = 3;
        chkDescending.Text = "Sort in descending order";
        chkDescending.UseVisualStyleBackColor = true;
        chkDescending.CheckedChanged += chkDescending_CheckedChanged;
        //
        // grpColumnOrder
        //
        grpColumnOrder.Controls.Add(lstColumnOrder);
        grpColumnOrder.Controls.Add(btnColMoveUp);
        grpColumnOrder.Controls.Add(btnColMoveDown);
        grpColumnOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpColumnOrder.Location = new Point(288, 12);
        grpColumnOrder.Name = "grpColumnOrder";
        grpColumnOrder.Size = new Size(270, 200);
        grpColumnOrder.TabIndex = 1;
        grpColumnOrder.TabStop = false;
        grpColumnOrder.Text = "Column Order";
        //
        // lstColumnOrder
        //
        lstColumnOrder.Font = new Font("Segoe UI", 9F);
        lstColumnOrder.FormattingEnabled = true;
        lstColumnOrder.ItemHeight = 15;
        lstColumnOrder.Location = new Point(10, 25);
        lstColumnOrder.Name = "lstColumnOrder";
        lstColumnOrder.Size = new Size(160, 139);
        lstColumnOrder.TabIndex = 0;
        lstColumnOrder.SelectedIndexChanged += lstColumnOrder_SelectedIndexChanged;
        //
        // btnColMoveUp
        //
        btnColMoveUp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnColMoveUp.Location = new Point(180, 25);
        btnColMoveUp.Name = "btnColMoveUp";
        btnColMoveUp.Size = new Size(80, 28);
        btnColMoveUp.TabIndex = 1;
        btnColMoveUp.Text = "Move Up";
        btnColMoveUp.UseVisualStyleBackColor = true;
        btnColMoveUp.Click += btnColMoveUp_Click;
        //
        // btnColMoveDown
        //
        btnColMoveDown.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnColMoveDown.Location = new Point(180, 59);
        btnColMoveDown.Name = "btnColMoveDown";
        btnColMoveDown.Size = new Size(80, 28);
        btnColMoveDown.TabIndex = 2;
        btnColMoveDown.Text = "Move Down";
        btnColMoveDown.UseVisualStyleBackColor = true;
        btnColMoveDown.Click += btnColMoveDown_Click;
        //
        // grpDateFormat
        //
        grpDateFormat.Controls.Add(cboDateFormat);
        grpDateFormat.Controls.Add(lblSampleLabel);
        grpDateFormat.Controls.Add(lblSampleDate);
        grpDateFormat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpDateFormat.Location = new Point(12, 218);
        grpDateFormat.Name = "grpDateFormat";
        grpDateFormat.Size = new Size(270, 100);
        grpDateFormat.TabIndex = 2;
        grpDateFormat.TabStop = false;
        grpDateFormat.Text = "Date Format";
        //
        // cboDateFormat
        //
        cboDateFormat.Font = new Font("Segoe UI", 9F);
        cboDateFormat.FormattingEnabled = true;
        cboDateFormat.Location = new Point(10, 25);
        cboDateFormat.Name = "cboDateFormat";
        cboDateFormat.Size = new Size(250, 23);
        cboDateFormat.TabIndex = 0;
        cboDateFormat.TextChanged += cboDateFormat_TextChanged;
        //
        // lblSampleLabel
        //
        lblSampleLabel.AutoSize = true;
        lblSampleLabel.Font = new Font("Segoe UI", 9F);
        lblSampleLabel.Location = new Point(10, 58);
        lblSampleLabel.Name = "lblSampleLabel";
        lblSampleLabel.Size = new Size(89, 15);
        lblSampleLabel.TabIndex = 1;
        lblSampleLabel.Text = "Sample Format:";
        //
        // lblSampleDate
        //
        lblSampleDate.AutoSize = true;
        lblSampleDate.Font = new Font("Segoe UI", 9F);
        lblSampleDate.Location = new Point(105, 58);
        lblSampleDate.Name = "lblSampleDate";
        lblSampleDate.Size = new Size(63, 15);
        lblSampleDate.TabIndex = 2;
        lblSampleDate.Text = "1/31/1998";
        //
        // btnFonts
        //
        btnFonts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnFonts.Location = new Point(298, 288);
        btnFonts.Name = "btnFonts";
        btnFonts.Size = new Size(85, 28);
        btnFonts.TabIndex = 3;
        btnFonts.Text = "&Fonts";
        btnFonts.UseVisualStyleBackColor = true;
        btnFonts.Click += btnFonts_Click;
        //
        // btnCancel
        //
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.Location = new Point(389, 288);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(85, 28);
        btnCancel.TabIndex = 4;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // btnOK
        //
        btnOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnOK.Location = new Point(480, 288);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(85, 28);
        btnOK.TabIndex = 5;
        btnOK.Text = "&OK";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        //
        // ListingSortOptionsForm
        //
        AcceptButton = btnOK;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(577, 330);
        Controls.Add(btnOK);
        Controls.Add(btnCancel);
        Controls.Add(btnFonts);
        Controls.Add(grpDateFormat);
        Controls.Add(grpColumnOrder);
        Controls.Add(grpSortOrder);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ListingSortOptionsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Listing Report Sort Options Dialog";
        Load += ListingSortOptionsForm_Load;
        grpSortOrder.ResumeLayout(false);
        grpSortOrder.PerformLayout();
        grpColumnOrder.ResumeLayout(false);
        grpDateFormat.ResumeLayout(false);
        grpDateFormat.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpSortOrder;
    private ListBox lstSortOrder;
    private Button btnSortMoveUp;
    private Button btnSortMoveDown;
    private CheckBox chkDescending;
    private GroupBox grpColumnOrder;
    private ListBox lstColumnOrder;
    private Button btnColMoveUp;
    private Button btnColMoveDown;
    private GroupBox grpDateFormat;
    private ComboBox cboDateFormat;
    private Label lblSampleLabel;
    private Label lblSampleDate;
    private Button btnFonts;
    private Button btnCancel;
    private Button btnOK;
}
