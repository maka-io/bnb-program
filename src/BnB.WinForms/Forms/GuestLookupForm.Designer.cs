namespace BnB.WinForms.Forms;

partial class GuestLookupForm
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

        // Search controls
        this.lblSearchName = new Label();
        this.txtSearchName = new TextBox();
        this.btnSearch = new Button();

        // Results
        this.dgvGuests = new DataGridView();
        this.lblResultCount = new Label();

        // Buttons
        this.btnSelect = new Button();
        this.btnCancel = new Button();

        ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).BeginInit();
        this.SuspendLayout();

        // === Search Controls (top) ===
        this.lblSearchName.Text = "Name:";
        this.lblSearchName.Location = new Point(12, 15);
        this.lblSearchName.AutoSize = true;
        this.Controls.Add(this.lblSearchName);

        this.txtSearchName.Location = new Point(60, 12);
        this.txtSearchName.Size = new Size(250, 23);
        this.txtSearchName.KeyDown += txtSearch_KeyDown;
        this.Controls.Add(this.txtSearchName);

        this.btnSearch.Text = "Search";
        this.btnSearch.Location = new Point(320, 11);
        this.btnSearch.Size = new Size(75, 25);
        this.btnSearch.Click += btnSearch_Click;
        this.Controls.Add(this.btnSearch);

        // === DataGridView (middle) ===
        this.dgvGuests.Location = new Point(12, 45);
        this.dgvGuests.Size = new Size(660, 310);
        this.dgvGuests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.dgvGuests.AllowUserToAddRows = false;
        this.dgvGuests.AllowUserToDeleteRows = false;
        this.dgvGuests.ReadOnly = true;
        this.dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvGuests.MultiSelect = false;
        this.dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvGuests.CellDoubleClick += dgvGuests_CellDoubleClick;
        this.Controls.Add(this.dgvGuests);

        // === Bottom controls ===
        this.lblResultCount.Text = "Showing 0 guest(s)";
        this.lblResultCount.Location = new Point(12, 365);
        this.lblResultCount.AutoSize = true;
        this.lblResultCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        this.Controls.Add(this.lblResultCount);

        this.btnSelect.Text = "Select";
        this.btnSelect.Location = new Point(500, 360);
        this.btnSelect.Size = new Size(80, 28);
        this.btnSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.btnSelect.Click += btnSelect_Click;
        this.Controls.Add(this.btnSelect);

        this.btnCancel.Text = "Cancel";
        this.btnCancel.Location = new Point(590, 360);
        this.btnCancel.Size = new Size(80, 28);
        this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.btnCancel.Click += btnCancel_Click;
        this.Controls.Add(this.btnCancel);

        // === Form ===
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(684, 400);
        this.MinimumSize = new Size(500, 300);
        this.Name = "GuestLookupForm";
        this.Text = "Guest Lookup";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Load += GuestLookupForm_Load;
        this.KeyDown += GuestLookupForm_KeyDown;
        this.KeyPreview = true;

        ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Label lblSearchName;
    private TextBox txtSearchName;
    private Button btnSearch;

    private DataGridView dgvGuests;
    private Label lblResultCount;

    private Button btnSelect;
    private Button btnCancel;
}
