namespace BnB.WinForms.Forms;

partial class GuestSearchForm
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

        this.lblFirstName = new Label();
        this.lblLastName = new Label();
        this.lblConfirmationNumber = new Label();

        this.txtFirstName = new TextBox();
        this.txtLastName = new TextBox();
        this.txtConfirmationNumber = new TextBox();

        this.btnSearch = new Button();
        this.btnCancel = new Button();

        this.SuspendLayout();

        // lblFirstName
        this.lblFirstName.AutoSize = true;
        this.lblFirstName.Location = new Point(20, 25);
        this.lblFirstName.Text = "First Name:";

        // txtFirstName
        this.txtFirstName.Location = new Point(140, 22);
        this.txtFirstName.Size = new Size(200, 23);

        // lblLastName
        this.lblLastName.AutoSize = true;
        this.lblLastName.Location = new Point(20, 60);
        this.lblLastName.Text = "Last Name:";

        // txtLastName
        this.txtLastName.Location = new Point(140, 57);
        this.txtLastName.Size = new Size(200, 23);

        // lblConfirmationNumber
        this.lblConfirmationNumber.AutoSize = true;
        this.lblConfirmationNumber.Location = new Point(20, 95);
        this.lblConfirmationNumber.Text = "Confirmation #:";

        // txtConfirmationNumber
        this.txtConfirmationNumber.Location = new Point(140, 92);
        this.txtConfirmationNumber.Size = new Size(100, 23);

        // btnSearch
        this.btnSearch.Location = new Point(140, 135);
        this.btnSearch.Size = new Size(90, 30);
        this.btnSearch.Text = "&Search";
        this.btnSearch.Click += btnSearch_Click;

        // btnCancel
        this.btnCancel.Location = new Point(250, 135);
        this.btnCancel.Size = new Size(90, 30);
        this.btnCancel.Text = "&Cancel";
        this.btnCancel.Click += btnCancel_Click;

        // GuestSearchForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(370, 185);
        this.Controls.Add(this.lblFirstName);
        this.Controls.Add(this.txtFirstName);
        this.Controls.Add(this.lblLastName);
        this.Controls.Add(this.txtLastName);
        this.Controls.Add(this.lblConfirmationNumber);
        this.Controls.Add(this.txtConfirmationNumber);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "GuestSearchForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Find Guest";
        this.KeyDown += GuestSearchForm_KeyDown;
        this.KeyPreview = true;

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Label lblFirstName;
    private Label lblLastName;
    private Label lblConfirmationNumber;

    private TextBox txtFirstName;
    private TextBox txtLastName;
    private TextBox txtConfirmationNumber;

    private Button btnSearch;
    private Button btnCancel;
}
