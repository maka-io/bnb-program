namespace BnB.WinForms.Forms;

partial class CheckNumberForm
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
        grpNextCheck = new GroupBox();
        lblHost = new Label();
        txtHostCheckNum = new TextBox();
        lblTravel = new Label();
        txtTravelCheckNum = new TextBox();
        lblMisc = new Label();
        txtMiscCheckNum = new TextBox();
        grpSharedCheck = new GroupBox();
        radNone = new RadioButton();
        radTravelMisc = new RadioButton();
        radHostMisc = new RadioButton();
        radHostTravel = new RadioButton();
        radAll = new RadioButton();
        btnInsert = new Button();
        btnUpdate = new Button();
        btnCommit = new Button();
        btnCancel = new Button();
        btnExit = new Button();
        grpNextCheck.SuspendLayout();
        grpSharedCheck.SuspendLayout();
        SuspendLayout();
        //
        // grpNextCheck
        //
        grpNextCheck.Controls.Add(lblHost);
        grpNextCheck.Controls.Add(txtHostCheckNum);
        grpNextCheck.Controls.Add(lblTravel);
        grpNextCheck.Controls.Add(txtTravelCheckNum);
        grpNextCheck.Controls.Add(lblMisc);
        grpNextCheck.Controls.Add(txtMiscCheckNum);
        grpNextCheck.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpNextCheck.Location = new Point(12, 12);
        grpNextCheck.Name = "grpNextCheck";
        grpNextCheck.Size = new Size(220, 150);
        grpNextCheck.TabIndex = 0;
        grpNextCheck.TabStop = false;
        grpNextCheck.Text = "Next Check Number to be Printed";
        //
        // lblHost
        //
        lblHost.AutoSize = true;
        lblHost.Font = new Font("Segoe UI", 9F);
        lblHost.Location = new Point(15, 35);
        lblHost.Name = "lblHost";
        lblHost.Size = new Size(34, 15);
        lblHost.TabIndex = 0;
        lblHost.Text = "Host:";
        //
        // txtHostCheckNum
        //
        txtHostCheckNum.Font = new Font("Segoe UI", 9F);
        txtHostCheckNum.Location = new Point(115, 32);
        txtHostCheckNum.Name = "txtHostCheckNum";
        txtHostCheckNum.Size = new Size(90, 23);
        txtHostCheckNum.TabIndex = 1;
        //
        // lblTravel
        //
        lblTravel.AutoSize = true;
        lblTravel.Font = new Font("Segoe UI", 9F);
        lblTravel.Location = new Point(15, 70);
        lblTravel.Name = "lblTravel";
        lblTravel.Size = new Size(41, 15);
        lblTravel.TabIndex = 2;
        lblTravel.Text = "Travel:";
        //
        // txtTravelCheckNum
        //
        txtTravelCheckNum.Font = new Font("Segoe UI", 9F);
        txtTravelCheckNum.Location = new Point(115, 67);
        txtTravelCheckNum.Name = "txtTravelCheckNum";
        txtTravelCheckNum.Size = new Size(90, 23);
        txtTravelCheckNum.TabIndex = 3;
        //
        // lblMisc
        //
        lblMisc.AutoSize = true;
        lblMisc.Font = new Font("Segoe UI", 9F);
        lblMisc.Location = new Point(15, 105);
        lblMisc.Name = "lblMisc";
        lblMisc.Size = new Size(81, 15);
        lblMisc.TabIndex = 4;
        lblMisc.Text = "Miscellaneous:";
        //
        // txtMiscCheckNum
        //
        txtMiscCheckNum.Font = new Font("Segoe UI", 9F);
        txtMiscCheckNum.Location = new Point(115, 102);
        txtMiscCheckNum.Name = "txtMiscCheckNum";
        txtMiscCheckNum.Size = new Size(90, 23);
        txtMiscCheckNum.TabIndex = 5;
        //
        // grpSharedCheck
        //
        grpSharedCheck.Controls.Add(radNone);
        grpSharedCheck.Controls.Add(radTravelMisc);
        grpSharedCheck.Controls.Add(radHostMisc);
        grpSharedCheck.Controls.Add(radHostTravel);
        grpSharedCheck.Controls.Add(radAll);
        grpSharedCheck.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpSharedCheck.Location = new Point(248, 12);
        grpSharedCheck.Name = "grpSharedCheck";
        grpSharedCheck.Size = new Size(250, 150);
        grpSharedCheck.TabIndex = 1;
        grpSharedCheck.TabStop = false;
        grpSharedCheck.Text = "Shared Checks";
        //
        // radNone
        //
        radNone.AutoSize = true;
        radNone.Font = new Font("Segoe UI", 9F);
        radNone.Location = new Point(15, 25);
        radNone.Name = "radNone";
        radNone.Size = new Size(224, 19);
        radNone.TabIndex = 0;
        radNone.Text = "None (All on separate check sequences)";
        radNone.UseVisualStyleBackColor = true;
        //
        // radTravelMisc
        //
        radTravelMisc.AutoSize = true;
        radTravelMisc.Font = new Font("Segoe UI", 9F);
        radTravelMisc.Location = new Point(15, 50);
        radTravelMisc.Name = "radTravelMisc";
        radTravelMisc.Size = new Size(143, 19);
        radTravelMisc.TabIndex = 1;
        radTravelMisc.Text = "Travel and Miscellaneous";
        radTravelMisc.UseVisualStyleBackColor = true;
        //
        // radHostMisc
        //
        radHostMisc.AutoSize = true;
        radHostMisc.Font = new Font("Segoe UI", 9F);
        radHostMisc.Location = new Point(15, 75);
        radHostMisc.Name = "radHostMisc";
        radHostMisc.Size = new Size(139, 19);
        radHostMisc.TabIndex = 2;
        radHostMisc.Text = "Host and Miscellaneous";
        radHostMisc.UseVisualStyleBackColor = true;
        //
        // radHostTravel
        //
        radHostTravel.AutoSize = true;
        radHostTravel.Font = new Font("Segoe UI", 9F);
        radHostTravel.Location = new Point(15, 100);
        radHostTravel.Name = "radHostTravel";
        radHostTravel.Size = new Size(104, 19);
        radHostTravel.TabIndex = 3;
        radHostTravel.Text = "Host and Travel";
        radHostTravel.UseVisualStyleBackColor = true;
        //
        // radAll
        //
        radAll.AutoSize = true;
        radAll.Font = new Font("Segoe UI", 9F);
        radAll.Location = new Point(15, 125);
        radAll.Name = "radAll";
        radAll.Size = new Size(207, 19);
        radAll.TabIndex = 4;
        radAll.Text = "All (All categories share same sequence)";
        radAll.UseVisualStyleBackColor = true;
        //
        // btnInsert
        //
        btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnInsert.Location = new Point(510, 12);
        btnInsert.Name = "btnInsert";
        btnInsert.Size = new Size(90, 30);
        btnInsert.TabIndex = 2;
        btnInsert.Text = "&Insert";
        btnInsert.UseVisualStyleBackColor = true;
        btnInsert.Click += btnInsert_Click;
        //
        // btnUpdate
        //
        btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnUpdate.Location = new Point(510, 48);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(90, 30);
        btnUpdate.TabIndex = 3;
        btnUpdate.Text = "&Update";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        //
        // btnCommit
        //
        btnCommit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCommit.Location = new Point(510, 84);
        btnCommit.Name = "btnCommit";
        btnCommit.Size = new Size(90, 30);
        btnCommit.TabIndex = 4;
        btnCommit.Text = "Co&mmit";
        btnCommit.UseVisualStyleBackColor = true;
        btnCommit.Click += btnCommit_Click;
        //
        // btnCancel
        //
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.Location = new Point(510, 120);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 30);
        btnCancel.TabIndex = 5;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // btnExit
        //
        btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnExit.Location = new Point(510, 156);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(90, 30);
        btnExit.TabIndex = 6;
        btnExit.Text = "E&xit";
        btnExit.UseVisualStyleBackColor = true;
        btnExit.Click += btnExit_Click;
        //
        // CheckNumberForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(614, 176);
        Controls.Add(btnExit);
        Controls.Add(btnCancel);
        Controls.Add(btnCommit);
        Controls.Add(btnUpdate);
        Controls.Add(btnInsert);
        Controls.Add(grpSharedCheck);
        Controls.Add(grpNextCheck);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CheckNumberForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Check Category Information";
        FormClosing += CheckNumberForm_FormClosing;
        Load += CheckNumberForm_Load;
        grpNextCheck.ResumeLayout(false);
        grpNextCheck.PerformLayout();
        grpSharedCheck.ResumeLayout(false);
        grpSharedCheck.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpNextCheck;
    private Label lblHost;
    private TextBox txtHostCheckNum;
    private Label lblTravel;
    private TextBox txtTravelCheckNum;
    private Label lblMisc;
    private TextBox txtMiscCheckNum;
    private GroupBox grpSharedCheck;
    private RadioButton radNone;
    private RadioButton radTravelMisc;
    private RadioButton radHostMisc;
    private RadioButton radHostTravel;
    private RadioButton radAll;
    private Button btnInsert;
    private Button btnUpdate;
    private Button btnCommit;
    private Button btnCancel;
    private Button btnExit;
}
