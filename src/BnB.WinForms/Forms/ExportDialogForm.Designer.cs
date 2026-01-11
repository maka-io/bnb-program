namespace BnB.WinForms.Forms;

partial class ExportDialogForm
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
        lblFileName = new Label();
        txtFileName = new TextBox();
        btnFile = new Button();
        lblFormat = new Label();
        cboFormat = new ComboBox();
        grpOptions = new GroupBox();
        chkCaption = new CheckBox();
        chkHeaders = new CheckBox();
        chkAppend = new CheckBox();
        grpRange = new GroupBox();
        lblRows = new Label();
        txtFirstRow = new TextBox();
        lblRowsThrough = new Label();
        txtLastRow = new TextBox();
        lblColumns = new Label();
        txtFirstCol = new TextBox();
        lblColsThrough = new Label();
        txtLastCol = new TextBox();
        lblRangeNote = new Label();
        chkSaveSettings = new CheckBox();
        btnOK = new Button();
        btnCancel = new Button();
        grpOptions.SuspendLayout();
        grpRange.SuspendLayout();
        SuspendLayout();
        //
        // lblFileName
        //
        lblFileName.AutoSize = true;
        lblFileName.Location = new Point(12, 15);
        lblFileName.Name = "lblFileName";
        lblFileName.Size = new Size(61, 15);
        lblFileName.TabIndex = 0;
        lblFileName.Text = "File Name:";
        //
        // txtFileName
        //
        txtFileName.Location = new Point(79, 12);
        txtFileName.Name = "txtFileName";
        txtFileName.Size = new Size(300, 23);
        txtFileName.TabIndex = 1;
        //
        // btnFile
        //
        btnFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnFile.Location = new Point(385, 10);
        btnFile.Name = "btnFile";
        btnFile.Size = new Size(75, 27);
        btnFile.TabIndex = 2;
        btnFile.Text = "&File...";
        btnFile.UseVisualStyleBackColor = true;
        btnFile.Click += btnFile_Click;
        //
        // lblFormat
        //
        lblFormat.AutoSize = true;
        lblFormat.Location = new Point(12, 47);
        lblFormat.Name = "lblFormat";
        lblFormat.Size = new Size(48, 15);
        lblFormat.TabIndex = 3;
        lblFormat.Text = "Format:";
        //
        // cboFormat
        //
        cboFormat.DropDownStyle = ComboBoxStyle.DropDownList;
        cboFormat.FormattingEnabled = true;
        cboFormat.Location = new Point(79, 44);
        cboFormat.Name = "cboFormat";
        cboFormat.Size = new Size(200, 23);
        cboFormat.TabIndex = 4;
        //
        // grpOptions
        //
        grpOptions.Controls.Add(chkCaption);
        grpOptions.Controls.Add(chkHeaders);
        grpOptions.Controls.Add(chkAppend);
        grpOptions.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpOptions.Location = new Point(12, 80);
        grpOptions.Name = "grpOptions";
        grpOptions.Size = new Size(220, 110);
        grpOptions.TabIndex = 5;
        grpOptions.TabStop = false;
        grpOptions.Text = "Options";
        //
        // chkCaption
        //
        chkCaption.AutoSize = true;
        chkCaption.Font = new Font("Segoe UI", 9F);
        chkCaption.Location = new Point(15, 25);
        chkCaption.Name = "chkCaption";
        chkCaption.Size = new Size(110, 19);
        chkCaption.TabIndex = 0;
        chkCaption.Text = "Include Caption";
        chkCaption.UseVisualStyleBackColor = true;
        //
        // chkHeaders
        //
        chkHeaders.AutoSize = true;
        chkHeaders.Font = new Font("Segoe UI", 9F);
        chkHeaders.Location = new Point(15, 50);
        chkHeaders.Name = "chkHeaders";
        chkHeaders.Size = new Size(164, 19);
        chkHeaders.TabIndex = 1;
        chkHeaders.Text = "Include Column Headers";
        chkHeaders.UseVisualStyleBackColor = true;
        //
        // chkAppend
        //
        chkAppend.AutoSize = true;
        chkAppend.Font = new Font("Segoe UI", 9F);
        chkAppend.Location = new Point(15, 75);
        chkAppend.Name = "chkAppend";
        chkAppend.Size = new Size(155, 19);
        chkAppend.TabIndex = 2;
        chkAppend.Text = "Append to File (if exists)";
        chkAppend.UseVisualStyleBackColor = true;
        //
        // grpRange
        //
        grpRange.Controls.Add(lblRows);
        grpRange.Controls.Add(txtFirstRow);
        grpRange.Controls.Add(lblRowsThrough);
        grpRange.Controls.Add(txtLastRow);
        grpRange.Controls.Add(lblColumns);
        grpRange.Controls.Add(txtFirstCol);
        grpRange.Controls.Add(lblColsThrough);
        grpRange.Controls.Add(txtLastCol);
        grpRange.Controls.Add(lblRangeNote);
        grpRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpRange.Location = new Point(238, 80);
        grpRange.Name = "grpRange";
        grpRange.Size = new Size(220, 110);
        grpRange.TabIndex = 6;
        grpRange.TabStop = false;
        grpRange.Text = "Range";
        //
        // lblRows
        //
        lblRows.AutoSize = true;
        lblRows.Font = new Font("Segoe UI", 9F);
        lblRows.Location = new Point(10, 27);
        lblRows.Name = "lblRows";
        lblRows.Size = new Size(38, 15);
        lblRows.TabIndex = 0;
        lblRows.Text = "Rows:";
        //
        // txtFirstRow
        //
        txtFirstRow.Font = new Font("Segoe UI", 9F);
        txtFirstRow.Location = new Point(60, 24);
        txtFirstRow.MaxLength = 5;
        txtFirstRow.Name = "txtFirstRow";
        txtFirstRow.Size = new Size(50, 23);
        txtFirstRow.TabIndex = 1;
        //
        // lblRowsThrough
        //
        lblRowsThrough.AutoSize = true;
        lblRowsThrough.Font = new Font("Segoe UI", 9F);
        lblRowsThrough.Location = new Point(116, 27);
        lblRowsThrough.Name = "lblRowsThrough";
        lblRowsThrough.Size = new Size(50, 15);
        lblRowsThrough.TabIndex = 2;
        lblRowsThrough.Text = "through";
        //
        // txtLastRow
        //
        txtLastRow.Font = new Font("Segoe UI", 9F);
        txtLastRow.Location = new Point(166, 24);
        txtLastRow.MaxLength = 5;
        txtLastRow.Name = "txtLastRow";
        txtLastRow.Size = new Size(50, 23);
        txtLastRow.TabIndex = 3;
        //
        // lblColumns
        //
        lblColumns.AutoSize = true;
        lblColumns.Font = new Font("Segoe UI", 9F);
        lblColumns.Location = new Point(10, 55);
        lblColumns.Name = "lblColumns";
        lblColumns.Size = new Size(56, 15);
        lblColumns.TabIndex = 4;
        lblColumns.Text = "Columns:";
        //
        // txtFirstCol
        //
        txtFirstCol.Font = new Font("Segoe UI", 9F);
        txtFirstCol.Location = new Point(60, 52);
        txtFirstCol.MaxLength = 4;
        txtFirstCol.Name = "txtFirstCol";
        txtFirstCol.Size = new Size(50, 23);
        txtFirstCol.TabIndex = 5;
        //
        // lblColsThrough
        //
        lblColsThrough.AutoSize = true;
        lblColsThrough.Font = new Font("Segoe UI", 9F);
        lblColsThrough.Location = new Point(116, 55);
        lblColsThrough.Name = "lblColsThrough";
        lblColsThrough.Size = new Size(50, 15);
        lblColsThrough.TabIndex = 6;
        lblColsThrough.Text = "through";
        //
        // txtLastCol
        //
        txtLastCol.Font = new Font("Segoe UI", 9F);
        txtLastCol.Location = new Point(166, 52);
        txtLastCol.MaxLength = 4;
        txtLastCol.Name = "txtLastCol";
        txtLastCol.Size = new Size(50, 23);
        txtLastCol.TabIndex = 7;
        //
        // lblRangeNote
        //
        lblRangeNote.Font = new Font("Segoe UI", 8F);
        lblRangeNote.ForeColor = SystemColors.GrayText;
        lblRangeNote.Location = new Point(10, 80);
        lblRangeNote.Name = "lblRangeNote";
        lblRangeNote.Size = new Size(205, 28);
        lblRangeNote.TabIndex = 8;
        lblRangeNote.Text = "Note: Row and Column ranges will not be saved on Exit.";
        //
        // chkSaveSettings
        //
        chkSaveSettings.AutoSize = true;
        chkSaveSettings.Location = new Point(12, 200);
        chkSaveSettings.Name = "chkSaveSettings";
        chkSaveSettings.Size = new Size(127, 19);
        chkSaveSettings.TabIndex = 7;
        chkSaveSettings.Text = "&Save Settings on Exit";
        chkSaveSettings.UseVisualStyleBackColor = true;
        //
        // btnOK
        //
        btnOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnOK.Location = new Point(385, 43);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(75, 27);
        btnOK.TabIndex = 8;
        btnOK.Text = "&OK";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        //
        // btnCancel
        //
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.Location = new Point(385, 76);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 27);
        btnCancel.TabIndex = 9;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // ExportDialogForm
        //
        AcceptButton = btnOK;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(472, 230);
        Controls.Add(btnCancel);
        Controls.Add(btnOK);
        Controls.Add(chkSaveSettings);
        Controls.Add(grpRange);
        Controls.Add(grpOptions);
        Controls.Add(cboFormat);
        Controls.Add(lblFormat);
        Controls.Add(btnFile);
        Controls.Add(txtFileName);
        Controls.Add(lblFileName);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ExportDialogForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Export File Dialog Box";
        Load += ExportDialogForm_Load;
        grpOptions.ResumeLayout(false);
        grpOptions.PerformLayout();
        grpRange.ResumeLayout(false);
        grpRange.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblFileName;
    private TextBox txtFileName;
    private Button btnFile;
    private Label lblFormat;
    private ComboBox cboFormat;
    private GroupBox grpOptions;
    private CheckBox chkCaption;
    private CheckBox chkHeaders;
    private CheckBox chkAppend;
    private GroupBox grpRange;
    private Label lblRows;
    private TextBox txtFirstRow;
    private Label lblRowsThrough;
    private TextBox txtLastRow;
    private Label lblColumns;
    private TextBox txtFirstCol;
    private Label lblColsThrough;
    private TextBox txtLastCol;
    private Label lblRangeNote;
    private CheckBox chkSaveSettings;
    private Button btnOK;
    private Button btnCancel;
}
