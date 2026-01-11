namespace BnB.WinForms.Forms;

partial class TravelAgencySearchForm
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
        this.lblAccountNumber = new Label();
        this.lblName = new Label();
        this.lblCity = new Label();

        this.txtAccountNumber = new TextBox();
        this.txtName = new TextBox();
        this.txtCity = new TextBox();

        this.btnSearch = new Button();
        this.btnCancel = new Button();

        this.SuspendLayout();

        int y = 20;
        int labelX = 20;
        int fieldX = 120;

        // Account Number
        this.lblAccountNumber.Text = "Account #:";
        this.lblAccountNumber.Location = new Point(labelX, y + 3);
        this.lblAccountNumber.AutoSize = true;
        this.txtAccountNumber.Location = new Point(fieldX, y);
        this.txtAccountNumber.Size = new Size(100, 23);

        y += 32;
        this.lblName.Text = "Agency Name:";
        this.lblName.Location = new Point(labelX, y + 3);
        this.lblName.AutoSize = true;
        this.txtName.Location = new Point(fieldX, y);
        this.txtName.Size = new Size(180, 23);

        y += 32;
        this.lblCity.Text = "City:";
        this.lblCity.Location = new Point(labelX, y + 3);
        this.lblCity.AutoSize = true;
        this.txtCity.Location = new Point(fieldX, y);
        this.txtCity.Size = new Size(150, 23);

        y += 45;

        this.btnSearch.Text = "&Search";
        this.btnSearch.Location = new Point(120, y);
        this.btnSearch.Size = new Size(90, 30);
        this.btnSearch.Click += btnSearch_Click;

        this.btnCancel.Text = "&Cancel";
        this.btnCancel.Location = new Point(220, y);
        this.btnCancel.Size = new Size(90, 30);
        this.btnCancel.Click += btnCancel_Click;

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(340, y + 50);
        this.Controls.Add(this.lblAccountNumber);
        this.Controls.Add(this.txtAccountNumber);
        this.Controls.Add(this.lblName);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.lblCity);
        this.Controls.Add(this.txtCity);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "TravelAgencySearchForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Find Travel Agencies";

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Label lblAccountNumber;
    private Label lblName;
    private Label lblCity;

    private TextBox txtAccountNumber;
    private TextBox txtName;
    private TextBox txtCity;

    private Button btnSearch;
    private Button btnCancel;
}
