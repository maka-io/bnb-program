namespace BnB.WinForms.Forms;

partial class AccommodationSearchForm
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

        this.lblConfirmationNumber = new Label();
        this.lblGuestName = new Label();
        this.lblPropertyName = new Label();

        this.txtConfirmationNumber = new TextBox();
        this.txtGuestName = new TextBox();
        this.txtPropertyName = new TextBox();

        this.chkArrivalDateFrom = new CheckBox();
        this.chkArrivalDateTo = new CheckBox();
        this.dtpArrivalDateFrom = new DateTimePicker();
        this.dtpArrivalDateTo = new DateTimePicker();

        this.btnSearch = new Button();
        this.btnCancel = new Button();

        this.SuspendLayout();

        int y = 20;
        int labelX = 20;
        int fieldX = 140;

        // Confirmation Number
        this.lblConfirmationNumber.Text = "Confirmation #:";
        this.lblConfirmationNumber.Location = new Point(labelX, y + 3);
        this.lblConfirmationNumber.AutoSize = true;

        this.txtConfirmationNumber.Location = new Point(fieldX, y);
        this.txtConfirmationNumber.Size = new Size(100, 23);

        y += 32;

        // Guest Name
        this.lblGuestName.Text = "Guest Name:";
        this.lblGuestName.Location = new Point(labelX, y + 3);
        this.lblGuestName.AutoSize = true;

        this.txtGuestName.Location = new Point(fieldX, y);
        this.txtGuestName.Size = new Size(180, 23);

        y += 32;

        // Property Name
        this.lblPropertyName.Text = "Property Name:";
        this.lblPropertyName.Location = new Point(labelX, y + 3);
        this.lblPropertyName.AutoSize = true;

        this.txtPropertyName.Location = new Point(fieldX, y);
        this.txtPropertyName.Size = new Size(180, 23);

        y += 32;

        // Arrival Date From
        this.chkArrivalDateFrom.Text = "Arrival From:";
        this.chkArrivalDateFrom.Location = new Point(labelX, y + 2);
        this.chkArrivalDateFrom.AutoSize = true;
        this.chkArrivalDateFrom.CheckedChanged += chkArrivalDateFrom_CheckedChanged;

        this.dtpArrivalDateFrom.Location = new Point(fieldX, y);
        this.dtpArrivalDateFrom.Size = new Size(130, 23);
        this.dtpArrivalDateFrom.Format = DateTimePickerFormat.Short;
        this.dtpArrivalDateFrom.Enabled = false;

        y += 32;

        // Arrival Date To
        this.chkArrivalDateTo.Text = "Arrival To:";
        this.chkArrivalDateTo.Location = new Point(labelX, y + 2);
        this.chkArrivalDateTo.AutoSize = true;
        this.chkArrivalDateTo.CheckedChanged += chkArrivalDateTo_CheckedChanged;

        this.dtpArrivalDateTo.Location = new Point(fieldX, y);
        this.dtpArrivalDateTo.Size = new Size(130, 23);
        this.dtpArrivalDateTo.Format = DateTimePickerFormat.Short;
        this.dtpArrivalDateTo.Enabled = false;

        y += 45;

        // Buttons
        this.btnSearch.Text = "&Search";
        this.btnSearch.Location = new Point(140, y);
        this.btnSearch.Size = new Size(90, 30);
        this.btnSearch.Click += btnSearch_Click;

        this.btnCancel.Text = "&Cancel";
        this.btnCancel.Location = new Point(240, y);
        this.btnCancel.Size = new Size(90, 30);
        this.btnCancel.Click += btnCancel_Click;

        // Form
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(360, y + 50);
        this.Controls.Add(this.lblConfirmationNumber);
        this.Controls.Add(this.txtConfirmationNumber);
        this.Controls.Add(this.lblGuestName);
        this.Controls.Add(this.txtGuestName);
        this.Controls.Add(this.lblPropertyName);
        this.Controls.Add(this.txtPropertyName);
        this.Controls.Add(this.chkArrivalDateFrom);
        this.Controls.Add(this.dtpArrivalDateFrom);
        this.Controls.Add(this.chkArrivalDateTo);
        this.Controls.Add(this.dtpArrivalDateTo);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AccommodationSearchForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Find Accommodations";

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Label lblConfirmationNumber;
    private Label lblGuestName;
    private Label lblPropertyName;

    private TextBox txtConfirmationNumber;
    private TextBox txtGuestName;
    private TextBox txtPropertyName;

    private CheckBox chkArrivalDateFrom;
    private CheckBox chkArrivalDateTo;
    private DateTimePicker dtpArrivalDateFrom;
    private DateTimePicker dtpArrivalDateTo;

    private Button btnSearch;
    private Button btnCancel;
}
