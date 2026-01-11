namespace BnB.WinForms.Forms;

partial class BackupRestoreForm
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
        lblBackupTo = new Label();
        txtFileName = new TextBox();
        btnFile = new Button();
        chkSaveSettings = new CheckBox();
        btnOK = new Button();
        btnCancel = new Button();
        SuspendLayout();
        //
        // lblBackupTo
        //
        lblBackupTo.AutoSize = true;
        lblBackupTo.Location = new Point(12, 15);
        lblBackupTo.Name = "lblBackupTo";
        lblBackupTo.Size = new Size(64, 15);
        lblBackupTo.TabIndex = 0;
        lblBackupTo.Text = "Backup to:";
        //
        // txtFileName
        //
        txtFileName.Location = new Point(82, 12);
        txtFileName.Name = "txtFileName";
        txtFileName.ReadOnly = true;
        txtFileName.Size = new Size(300, 23);
        txtFileName.TabIndex = 1;
        //
        // btnFile
        //
        btnFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnFile.Location = new Point(388, 10);
        btnFile.Name = "btnFile";
        btnFile.Size = new Size(75, 27);
        btnFile.TabIndex = 2;
        btnFile.Text = "&File...";
        btnFile.UseVisualStyleBackColor = true;
        btnFile.Click += btnFile_Click;
        //
        // chkSaveSettings
        //
        chkSaveSettings.AutoSize = true;
        chkSaveSettings.Location = new Point(12, 50);
        chkSaveSettings.Name = "chkSaveSettings";
        chkSaveSettings.Size = new Size(127, 19);
        chkSaveSettings.TabIndex = 3;
        chkSaveSettings.Text = "&Save Settings on Exit";
        chkSaveSettings.UseVisualStyleBackColor = true;
        //
        // btnOK
        //
        btnOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnOK.Location = new Point(307, 46);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(75, 27);
        btnOK.TabIndex = 4;
        btnOK.Text = "&OK";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        //
        // btnCancel
        //
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.Location = new Point(388, 46);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 27);
        btnCancel.TabIndex = 5;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // BackupRestoreForm
        //
        AcceptButton = btnOK;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(475, 85);
        Controls.Add(btnCancel);
        Controls.Add(btnOK);
        Controls.Add(chkSaveSettings);
        Controls.Add(btnFile);
        Controls.Add(txtFileName);
        Controls.Add(lblBackupTo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "BackupRestoreForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Database Backup Dialog Box";
        Load += BackupRestoreForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblBackupTo;
    private TextBox txtFileName;
    private Button btnFile;
    private CheckBox chkSaveSettings;
    private Button btnOK;
    private Button btnCancel;
}
