namespace BnB.WinForms.Forms;

partial class ManualConfirmationForm
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
        lblEnterConfNum = new Label();
        txtConfirmationNumber = new TextBox();
        btnAdd = new Button();
        lstConfirmationNumbers = new ListBox();
        btnRemove = new Button();
        btnClear = new Button();
        lblCount = new Label();
        btnOK = new Button();
        btnCancel = new Button();
        SuspendLayout();
        //
        // lblEnterConfNum
        //
        lblEnterConfNum.AutoSize = true;
        lblEnterConfNum.Location = new Point(12, 15);
        lblEnterConfNum.Name = "lblEnterConfNum";
        lblEnterConfNum.Size = new Size(158, 15);
        lblEnterConfNum.TabIndex = 0;
        lblEnterConfNum.Text = "Enter Confirmation Number:";
        //
        // txtConfirmationNumber
        //
        txtConfirmationNumber.Location = new Point(12, 33);
        txtConfirmationNumber.MaxLength = 20;
        txtConfirmationNumber.Name = "txtConfirmationNumber";
        txtConfirmationNumber.Size = new Size(200, 23);
        txtConfirmationNumber.TabIndex = 1;
        txtConfirmationNumber.KeyPress += txtConfirmationNumber_KeyPress;
        //
        // btnAdd
        //
        btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnAdd.Location = new Point(218, 31);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(75, 27);
        btnAdd.TabIndex = 2;
        btnAdd.Text = "&Add";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        //
        // lstConfirmationNumbers
        //
        lstConfirmationNumbers.FormattingEnabled = true;
        lstConfirmationNumbers.ItemHeight = 15;
        lstConfirmationNumbers.Location = new Point(12, 70);
        lstConfirmationNumbers.Name = "lstConfirmationNumbers";
        lstConfirmationNumbers.Size = new Size(200, 154);
        lstConfirmationNumbers.TabIndex = 3;
        lstConfirmationNumbers.SelectedIndexChanged += lstConfirmationNumbers_SelectedIndexChanged;
        //
        // btnRemove
        //
        btnRemove.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRemove.Location = new Point(218, 70);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new Size(75, 27);
        btnRemove.TabIndex = 4;
        btnRemove.Text = "&Remove";
        btnRemove.UseVisualStyleBackColor = true;
        btnRemove.Click += btnRemove_Click;
        //
        // btnClear
        //
        btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnClear.Location = new Point(218, 103);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(75, 27);
        btnClear.TabIndex = 5;
        btnClear.Text = "C&lear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        //
        // lblCount
        //
        lblCount.AutoSize = true;
        lblCount.Location = new Point(12, 230);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(100, 15);
        lblCount.TabIndex = 6;
        lblCount.Text = "0 confirmation(s)";
        //
        // btnOK
        //
        btnOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnOK.Location = new Point(137, 258);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(75, 27);
        btnOK.TabIndex = 7;
        btnOK.Text = "&OK";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        //
        // btnCancel
        //
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.Location = new Point(218, 258);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 27);
        btnCancel.TabIndex = 8;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // ManualConfirmationForm
        //
        AcceptButton = btnOK;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(306, 297);
        Controls.Add(btnCancel);
        Controls.Add(btnOK);
        Controls.Add(lblCount);
        Controls.Add(btnClear);
        Controls.Add(btnRemove);
        Controls.Add(lstConfirmationNumbers);
        Controls.Add(btnAdd);
        Controls.Add(txtConfirmationNumber);
        Controls.Add(lblEnterConfNum);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ManualConfirmationForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Manual Confirmation Entry";
        Load += ManualConfirmationForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblEnterConfNum;
    private TextBox txtConfirmationNumber;
    private Button btnAdd;
    private ListBox lstConfirmationNumbers;
    private Button btnRemove;
    private Button btnClear;
    private Label lblCount;
    private Button btnOK;
    private Button btnCancel;
}
