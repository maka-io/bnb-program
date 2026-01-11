namespace BnB.WinForms.Forms;

partial class TaxPlanForm
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

        // Main layout
        this.splitContainer = new SplitContainer();
        this.panelForm = new Panel();
        this.panelButtons = new Panel();

        // Labels and TextBoxes
        this.lblPlanCode = new Label();
        this.lblPlanTitle = new Label();
        this.lblDescription = new Label();
        this.lblRecordCount = new Label();

        this.txtPlanCode = new TextBox();
        this.txtPlanTitle = new TextBox();
        this.txtDescription = new TextBox();

        // Buttons
        this.btnInsert = new Button();
        this.btnUpdate = new Button();
        this.btnDelete = new Button();
        this.btnCommit = new Button();
        this.btnCancel = new Button();
        this.btnClose = new Button();

        // DataGridView
        this.dgvPlans = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).BeginInit();
        this.SuspendLayout();

        // === Split Container ===
        this.splitContainer.Dock = DockStyle.Fill;
        this.splitContainer.Orientation = Orientation.Horizontal;
        this.splitContainer.Panel1.Controls.Add(this.panelButtons);
        this.splitContainer.Panel1.Controls.Add(this.panelForm);
        this.splitContainer.Panel2.Controls.Add(this.dgvPlans);
        this.splitContainer.Size = new Size(550, 400);
        this.splitContainer.SplitterDistance = 200;

        // === Panel Form ===
        this.panelForm.Dock = DockStyle.Fill;
        this.panelForm.Padding = new Padding(15);

        int labelX = 20;
        int fieldX = 110;
        int y = 20;
        int rowHeight = 30;

        // Plan Code
        this.lblPlanCode.Text = "Plan Code:";
        this.lblPlanCode.Location = new Point(labelX, y + 3);
        this.lblPlanCode.AutoSize = true;
        this.panelForm.Controls.Add(this.lblPlanCode);

        this.txtPlanCode.Location = new Point(fieldX, y);
        this.txtPlanCode.Size = new Size(80, 23);
        this.txtPlanCode.CharacterCasing = CharacterCasing.Upper;
        this.panelForm.Controls.Add(this.txtPlanCode);

        y += rowHeight;

        // Plan Title
        this.lblPlanTitle.Text = "Plan Title:";
        this.lblPlanTitle.Location = new Point(labelX, y + 3);
        this.lblPlanTitle.AutoSize = true;
        this.panelForm.Controls.Add(this.lblPlanTitle);

        this.txtPlanTitle.Location = new Point(fieldX, y);
        this.txtPlanTitle.Size = new Size(250, 23);
        this.panelForm.Controls.Add(this.txtPlanTitle);

        y += rowHeight + 5;

        // Description
        this.lblDescription.Text = "Description:";
        this.lblDescription.Location = new Point(labelX, y);
        this.lblDescription.AutoSize = true;
        this.panelForm.Controls.Add(this.lblDescription);

        this.txtDescription.Location = new Point(fieldX, y);
        this.txtDescription.Size = new Size(300, 70);
        this.txtDescription.Multiline = true;
        this.txtDescription.ScrollBars = ScrollBars.Vertical;
        this.panelForm.Controls.Add(this.txtDescription);

        // Record Count
        this.lblRecordCount.Text = "Record 0 of 0";
        this.lblRecordCount.Location = new Point(labelX, y + 80);
        this.lblRecordCount.AutoSize = true;
        this.panelForm.Controls.Add(this.lblRecordCount);

        // === Panel Buttons ===
        this.panelButtons.Dock = DockStyle.Right;
        this.panelButtons.Width = 110;
        this.panelButtons.Padding = new Padding(5);

        int btnY = 15;
        int btnSpacing = 35;

        AddButton(panelButtons, btnInsert, "&Insert", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnUpdate, "&Update", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnDelete, "&Delete", btnY);
        btnY += btnSpacing + 5;
        AddButton(panelButtons, btnCommit, "Co&mmit", btnY);
        btnY += btnSpacing;
        AddButton(panelButtons, btnCancel, "&Cancel", btnY);
        btnY += btnSpacing + 5;
        AddButton(panelButtons, btnClose, "C&lose", btnY);

        btnInsert.Click += btnInsert_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnCommit.Click += btnCommit_Click;
        btnCancel.Click += btnCancel_Click;
        btnClose.Click += btnClose_Click;

        // === DataGridView ===
        this.dgvPlans.Dock = DockStyle.Fill;
        this.dgvPlans.AllowUserToAddRows = false;
        this.dgvPlans.AllowUserToDeleteRows = false;
        this.dgvPlans.ReadOnly = true;
        this.dgvPlans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvPlans.MultiSelect = false;
        this.dgvPlans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvPlans.SelectionChanged += dgvPlans_SelectionChanged;

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(550, 400);
        this.Controls.Add(this.splitContainer);
        this.Name = "TaxPlanForm";
        this.Text = "Set Tax Plans";
        this.Load += TaxPlanForm_Load;
        this.FormClosing += TaxPlanForm_FormClosing;

        ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        this.splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).EndInit();
        this.ResumeLayout(false);
    }

    private void AddButton(Panel panel, Button button, string text, int y)
    {
        button.Text = text;
        button.Location = new Point(5, y);
        button.Size = new Size(95, 28);
        button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        panel.Controls.Add(button);
    }

    #endregion

    private SplitContainer splitContainer;
    private Panel panelForm;
    private Panel panelButtons;

    private Label lblPlanCode;
    private Label lblPlanTitle;
    private Label lblDescription;
    private Label lblRecordCount;

    private TextBox txtPlanCode;
    private TextBox txtPlanTitle;
    private TextBox txtDescription;

    private Button btnInsert;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnCommit;
    private Button btnCancel;
    private Button btnClose;

    private DataGridView dgvPlans;
}
