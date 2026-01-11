namespace BnB.WinForms.Forms;

partial class PropertySearchForm
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

        this.lblAccountNumber = new Label();
        this.lblPropertyName = new Label();
        this.lblOwnerName = new Label();

        this.txtAccountNumber = new TextBox();
        this.txtPropertyName = new TextBox();
        this.txtOwnerName = new TextBox();

        this.chkIncludeObsolete = new CheckBox();

        this.btnSearch = new Button();
        this.btnCancel = new Button();

        this.SuspendLayout();

        int y = 20;
        int labelX = 20;
        int fieldX = 130;

        // Account Number
        this.lblAccountNumber.Text = "Account #:";
        this.lblAccountNumber.Location = new Point(labelX, y + 3);
        this.lblAccountNumber.AutoSize = true;

        this.txtAccountNumber.Location = new Point(fieldX, y);
        this.txtAccountNumber.Size = new Size(100, 23);

        y += 32;

        // Property Name
        this.lblPropertyName.Text = "Property Name:";
        this.lblPropertyName.Location = new Point(labelX, y + 3);
        this.lblPropertyName.AutoSize = true;

        this.txtPropertyName.Location = new Point(fieldX, y);
        this.txtPropertyName.Size = new Size(200, 23);

        y += 32;

        // Owner Name
        this.lblOwnerName.Text = "Owner/Mgr:";
        this.lblOwnerName.Location = new Point(labelX, y + 3);
        this.lblOwnerName.AutoSize = true;

        this.txtOwnerName.Location = new Point(fieldX, y);
        this.txtOwnerName.Size = new Size(200, 23);

        y += 35;

        // Include Obsolete
        this.chkIncludeObsolete.Text = "Include obsolete properties";
        this.chkIncludeObsolete.Location = new Point(fieldX, y);
        this.chkIncludeObsolete.AutoSize = true;

        y += 40;

        // Buttons
        this.btnSearch.Text = "&Search";
        this.btnSearch.Location = new Point(130, y);
        this.btnSearch.Size = new Size(90, 30);
        this.btnSearch.Click += btnSearch_Click;

        this.btnCancel.Text = "&Cancel";
        this.btnCancel.Location = new Point(230, y);
        this.btnCancel.Size = new Size(90, 30);
        this.btnCancel.Click += btnCancel_Click;

        // Form
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(360, y + 50);
        this.Controls.Add(this.lblAccountNumber);
        this.Controls.Add(this.txtAccountNumber);
        this.Controls.Add(this.lblPropertyName);
        this.Controls.Add(this.txtPropertyName);
        this.Controls.Add(this.lblOwnerName);
        this.Controls.Add(this.txtOwnerName);
        this.Controls.Add(this.chkIncludeObsolete);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "PropertySearchForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Find Properties";

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Label lblAccountNumber;
    private Label lblPropertyName;
    private Label lblOwnerName;

    private TextBox txtAccountNumber;
    private TextBox txtPropertyName;
    private TextBox txtOwnerName;

    private CheckBox chkIncludeObsolete;

    private Button btnSearch;
    private Button btnCancel;
}
