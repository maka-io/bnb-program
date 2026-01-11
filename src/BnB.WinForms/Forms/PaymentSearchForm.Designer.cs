namespace BnB.WinForms.Forms;

partial class PaymentSearchForm
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
        this.lblMinAmount = new Label();

        this.txtConfirmationNumber = new TextBox();
        this.txtGuestName = new TextBox();
        this.txtMinAmount = new TextBox();

        this.chkDateFrom = new CheckBox();
        this.chkDateTo = new CheckBox();
        this.dtpDateFrom = new DateTimePicker();
        this.dtpDateTo = new DateTimePicker();

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

        // Date From
        this.chkDateFrom.Text = "Date From:";
        this.chkDateFrom.Location = new Point(labelX, y + 2);
        this.chkDateFrom.AutoSize = true;
        this.chkDateFrom.CheckedChanged += chkDateFrom_CheckedChanged;

        this.dtpDateFrom.Location = new Point(fieldX, y);
        this.dtpDateFrom.Size = new Size(130, 23);
        this.dtpDateFrom.Format = DateTimePickerFormat.Short;
        this.dtpDateFrom.Enabled = false;

        y += 32;

        // Date To
        this.chkDateTo.Text = "Date To:";
        this.chkDateTo.Location = new Point(labelX, y + 2);
        this.chkDateTo.AutoSize = true;
        this.chkDateTo.CheckedChanged += chkDateTo_CheckedChanged;

        this.dtpDateTo.Location = new Point(fieldX, y);
        this.dtpDateTo.Size = new Size(130, 23);
        this.dtpDateTo.Format = DateTimePickerFormat.Short;
        this.dtpDateTo.Enabled = false;

        y += 32;

        // Min Amount
        this.lblMinAmount.Text = "Min Amount:";
        this.lblMinAmount.Location = new Point(labelX, y + 3);
        this.lblMinAmount.AutoSize = true;

        this.txtMinAmount.Location = new Point(fieldX, y);
        this.txtMinAmount.Size = new Size(100, 23);

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
        this.Controls.Add(this.chkDateFrom);
        this.Controls.Add(this.dtpDateFrom);
        this.Controls.Add(this.chkDateTo);
        this.Controls.Add(this.dtpDateTo);
        this.Controls.Add(this.lblMinAmount);
        this.Controls.Add(this.txtMinAmount);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.btnCancel);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "PaymentSearchForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Find Payments";

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Label lblConfirmationNumber;
    private Label lblGuestName;
    private Label lblMinAmount;

    private TextBox txtConfirmationNumber;
    private TextBox txtGuestName;
    private TextBox txtMinAmount;

    private CheckBox chkDateFrom;
    private CheckBox chkDateTo;
    private DateTimePicker dtpDateFrom;
    private DateTimePicker dtpDateTo;

    private Button btnSearch;
    private Button btnCancel;
}
