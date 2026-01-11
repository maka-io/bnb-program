namespace BnB.WinForms.Forms;

partial class FactListForm
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
        pnlTop = new Panel();
        lblCategory = new Label();
        cboCategory = new ComboBox();
        lblSearch = new Label();
        txtSearch = new TextBox();
        dgvFacts = new DataGridView();
        pnlBottom = new Panel();
        lblSummary = new Label();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        btnToggleActive = new Button();
        btnClose = new Button();
        pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvFacts).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        //
        // pnlTop
        //
        pnlTop.Controls.Add(lblCategory);
        pnlTop.Controls.Add(cboCategory);
        pnlTop.Controls.Add(lblSearch);
        pnlTop.Controls.Add(txtSearch);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Size = new Size(600, 45);
        //
        // lblCategory
        //
        lblCategory.AutoSize = true;
        lblCategory.Location = new Point(12, 15);
        lblCategory.Text = "Category:";
        //
        // cboCategory
        //
        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCategory.Location = new Point(75, 12);
        cboCategory.Size = new Size(150, 23);
        cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
        //
        // lblSearch
        //
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(245, 15);
        lblSearch.Text = "Search:";
        //
        // txtSearch
        //
        txtSearch.Location = new Point(295, 12);
        txtSearch.Size = new Size(200, 23);
        txtSearch.TextChanged += txtSearch_TextChanged;
        //
        // dgvFacts
        //
        dgvFacts.AllowUserToAddRows = false;
        dgvFacts.AllowUserToDeleteRows = false;
        dgvFacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvFacts.Dock = DockStyle.Fill;
        dgvFacts.Location = new Point(0, 45);
        dgvFacts.MultiSelect = false;
        dgvFacts.ReadOnly = true;
        dgvFacts.RowHeadersWidth = 25;
        dgvFacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvFacts.Size = new Size(600, 315);
        dgvFacts.TabIndex = 0;
        //
        // pnlBottom
        //
        pnlBottom.Controls.Add(lblSummary);
        pnlBottom.Controls.Add(btnAdd);
        pnlBottom.Controls.Add(btnEdit);
        pnlBottom.Controls.Add(btnDelete);
        pnlBottom.Controls.Add(btnToggleActive);
        pnlBottom.Controls.Add(btnClose);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 360);
        pnlBottom.Size = new Size(600, 40);
        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(13, 13);
        lblSummary.Text = "Loading...";
        //
        // btnAdd
        //
        btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAdd.Location = new Point(195, 7);
        btnAdd.Size = new Size(75, 28);
        btnAdd.TabIndex = 1;
        btnAdd.Text = "&Add";
        btnAdd.Click += btnAdd_Click;
        //
        // btnEdit
        //
        btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnEdit.Location = new Point(276, 7);
        btnEdit.Size = new Size(75, 28);
        btnEdit.TabIndex = 2;
        btnEdit.Text = "&Edit";
        btnEdit.Click += btnEdit_Click;
        //
        // btnDelete
        //
        btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDelete.Location = new Point(357, 7);
        btnDelete.Size = new Size(75, 28);
        btnDelete.TabIndex = 3;
        btnDelete.Text = "&Delete";
        btnDelete.Click += btnDelete_Click;
        //
        // btnToggleActive
        //
        btnToggleActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnToggleActive.Location = new Point(438, 7);
        btnToggleActive.Size = new Size(75, 28);
        btnToggleActive.TabIndex = 4;
        btnToggleActive.Text = "&Toggle";
        btnToggleActive.Click += btnToggleActive_Click;
        //
        // btnClose
        //
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new Point(519, 7);
        btnClose.Size = new Size(75, 28);
        btnClose.TabIndex = 5;
        btnClose.Text = "&Close";
        btnClose.Click += btnClose_Click;
        //
        // FactListForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(600, 400);
        Controls.Add(dgvFacts);
        Controls.Add(pnlTop);
        Controls.Add(pnlBottom);
        MinimumSize = new Size(500, 350);
        Name = "FactListForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Fact List Management";
        Load += FactListForm_Load;
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvFacts).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTop;
    private Label lblCategory;
    private ComboBox cboCategory;
    private Label lblSearch;
    private TextBox txtSearch;
    private DataGridView dgvFacts;
    private Panel pnlBottom;
    private Label lblSummary;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnToggleActive;
    private Button btnClose;
}
