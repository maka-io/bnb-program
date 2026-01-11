namespace BnB.WinForms.Forms;

partial class CommonTextForm
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
        lblTitle = new Label();
        txtTitle = new TextBox();
        lblText = new Label();
        txtText = new TextBox();
        btnInsert = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        btnFind = new Button();
        btnRefresh = new Button();
        btnCommit = new Button();
        btnCancel = new Button();
        btnExit = new Button();
        panelNavigation = new Panel();
        btnFirst = new Button();
        btnPrevious = new Button();
        lblNavigation = new Label();
        btnNext = new Button();
        btnLast = new Button();
        panelNavigation.SuspendLayout();
        SuspendLayout();
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(12, 15);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(33, 15);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Title:";
        //
        // txtTitle
        //
        txtTitle.Location = new Point(51, 12);
        txtTitle.MaxLength = 60;
        txtTitle.Name = "txtTitle";
        txtTitle.Size = new Size(300, 23);
        txtTitle.TabIndex = 1;
        //
        // lblText
        //
        lblText.AutoSize = true;
        lblText.Location = new Point(12, 44);
        lblText.Name = "lblText";
        lblText.Size = new Size(31, 15);
        lblText.TabIndex = 2;
        lblText.Text = "Text:";
        //
        // txtText
        //
        txtText.Location = new Point(51, 41);
        txtText.Multiline = true;
        txtText.Name = "txtText";
        txtText.ScrollBars = ScrollBars.Vertical;
        txtText.Size = new Size(300, 200);
        txtText.TabIndex = 3;
        //
        // btnInsert
        //
        btnInsert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnInsert.Location = new Point(370, 12);
        btnInsert.Name = "btnInsert";
        btnInsert.Size = new Size(90, 30);
        btnInsert.TabIndex = 4;
        btnInsert.Text = "&Insert";
        btnInsert.UseVisualStyleBackColor = true;
        btnInsert.Click += btnInsert_Click;
        //
        // btnUpdate
        //
        btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnUpdate.Location = new Point(370, 48);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(90, 30);
        btnUpdate.TabIndex = 5;
        btnUpdate.Text = "&Update";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        //
        // btnDelete
        //
        btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDelete.Location = new Point(370, 84);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(90, 30);
        btnDelete.TabIndex = 6;
        btnDelete.Text = "&Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        //
        // btnFind
        //
        btnFind.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnFind.Location = new Point(370, 120);
        btnFind.Name = "btnFind";
        btnFind.Size = new Size(90, 30);
        btnFind.TabIndex = 7;
        btnFind.Text = "&Find";
        btnFind.UseVisualStyleBackColor = true;
        btnFind.Click += btnFind_Click;
        //
        // btnRefresh
        //
        btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRefresh.Location = new Point(370, 156);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(90, 30);
        btnRefresh.TabIndex = 8;
        btnRefresh.Text = "R&efresh";
        btnRefresh.UseVisualStyleBackColor = true;
        btnRefresh.Click += btnRefresh_Click;
        //
        // btnCommit
        //
        btnCommit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCommit.Location = new Point(370, 192);
        btnCommit.Name = "btnCommit";
        btnCommit.Size = new Size(90, 30);
        btnCommit.TabIndex = 9;
        btnCommit.Text = "Co&mmit";
        btnCommit.UseVisualStyleBackColor = true;
        btnCommit.Click += btnCommit_Click;
        //
        // btnCancel
        //
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.Location = new Point(370, 228);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 30);
        btnCancel.TabIndex = 10;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // btnExit
        //
        btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnExit.Location = new Point(370, 264);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(90, 30);
        btnExit.TabIndex = 11;
        btnExit.Text = "E&xit";
        btnExit.UseVisualStyleBackColor = true;
        btnExit.Click += btnExit_Click;
        //
        // panelNavigation
        //
        panelNavigation.Controls.Add(btnFirst);
        panelNavigation.Controls.Add(btnPrevious);
        panelNavigation.Controls.Add(lblNavigation);
        panelNavigation.Controls.Add(btnNext);
        panelNavigation.Controls.Add(btnLast);
        panelNavigation.Location = new Point(51, 247);
        panelNavigation.Name = "panelNavigation";
        panelNavigation.Size = new Size(300, 30);
        panelNavigation.TabIndex = 12;
        //
        // btnFirst
        //
        btnFirst.Location = new Point(0, 0);
        btnFirst.Name = "btnFirst";
        btnFirst.Size = new Size(40, 30);
        btnFirst.TabIndex = 0;
        btnFirst.Text = "|<";
        btnFirst.UseVisualStyleBackColor = true;
        btnFirst.Click += btnFirst_Click;
        //
        // btnPrevious
        //
        btnPrevious.Location = new Point(46, 0);
        btnPrevious.Name = "btnPrevious";
        btnPrevious.Size = new Size(40, 30);
        btnPrevious.TabIndex = 1;
        btnPrevious.Text = "<";
        btnPrevious.UseVisualStyleBackColor = true;
        btnPrevious.Click += btnPrevious_Click;
        //
        // lblNavigation
        //
        lblNavigation.Location = new Point(92, 7);
        lblNavigation.Name = "lblNavigation";
        lblNavigation.Size = new Size(116, 15);
        lblNavigation.TabIndex = 2;
        lblNavigation.Text = "Row 1 of 1";
        lblNavigation.TextAlign = ContentAlignment.MiddleCenter;
        //
        // btnNext
        //
        btnNext.Location = new Point(214, 0);
        btnNext.Name = "btnNext";
        btnNext.Size = new Size(40, 30);
        btnNext.TabIndex = 3;
        btnNext.Text = ">";
        btnNext.UseVisualStyleBackColor = true;
        btnNext.Click += btnNext_Click;
        //
        // btnLast
        //
        btnLast.Location = new Point(260, 0);
        btnLast.Name = "btnLast";
        btnLast.Size = new Size(40, 30);
        btnLast.TabIndex = 4;
        btnLast.Text = ">|";
        btnLast.UseVisualStyleBackColor = true;
        btnLast.Click += btnLast_Click;
        //
        // CommonTextForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(474, 291);
        Controls.Add(panelNavigation);
        Controls.Add(btnExit);
        Controls.Add(btnCancel);
        Controls.Add(btnCommit);
        Controls.Add(btnRefresh);
        Controls.Add(btnFind);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(btnInsert);
        Controls.Add(txtText);
        Controls.Add(lblText);
        Controls.Add(txtTitle);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CommonTextForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Common Text";
        FormClosing += CommonTextForm_FormClosing;
        Load += CommonTextForm_Load;
        panelNavigation.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private TextBox txtTitle;
    private Label lblText;
    private TextBox txtText;
    private Button btnInsert;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnFind;
    private Button btnRefresh;
    private Button btnCommit;
    private Button btnCancel;
    private Button btnExit;
    private Panel panelNavigation;
    private Button btnFirst;
    private Button btnPrevious;
    private Label lblNavigation;
    private Button btnNext;
    private Button btnLast;
}
