namespace BnB.WinForms.Forms;

partial class RoomBlackoutForm
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
        lblRoom = new Label();
        lblStartDate = new Label();
        dtpStartDate = new DateTimePicker();
        lblEndDate = new Label();
        dtpEndDate = new DateTimePicker();
        lblReasonLabel = new Label();
        cboReason = new ComboBox();
        lblOtherReason = new Label();
        txtOtherReason = new TextBox();
        btnOK = new Button();
        btnCancel = new Button();
        SuspendLayout();
        //
        // lblRoom
        //
        lblRoom.AutoSize = true;
        lblRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblRoom.Location = new Point(12, 15);
        lblRoom.Name = "lblRoom";
        lblRoom.Size = new Size(54, 19);
        lblRoom.TabIndex = 0;
        lblRoom.Text = "Room:";
        //
        // lblStartDate
        //
        lblStartDate.AutoSize = true;
        lblStartDate.Font = new Font("Segoe UI", 9F);
        lblStartDate.Location = new Point(12, 50);
        lblStartDate.Name = "lblStartDate";
        lblStartDate.Size = new Size(62, 15);
        lblStartDate.TabIndex = 1;
        lblStartDate.Text = "Start Date:";
        //
        // dtpStartDate
        //
        dtpStartDate.Font = new Font("Segoe UI", 9F);
        dtpStartDate.Format = DateTimePickerFormat.Short;
        dtpStartDate.Location = new Point(100, 47);
        dtpStartDate.Name = "dtpStartDate";
        dtpStartDate.Size = new Size(120, 23);
        dtpStartDate.TabIndex = 2;
        //
        // lblEndDate
        //
        lblEndDate.AutoSize = true;
        lblEndDate.Font = new Font("Segoe UI", 9F);
        lblEndDate.Location = new Point(12, 85);
        lblEndDate.Name = "lblEndDate";
        lblEndDate.Size = new Size(56, 15);
        lblEndDate.TabIndex = 3;
        lblEndDate.Text = "End Date:";
        //
        // dtpEndDate
        //
        dtpEndDate.Font = new Font("Segoe UI", 9F);
        dtpEndDate.Format = DateTimePickerFormat.Short;
        dtpEndDate.Location = new Point(100, 82);
        dtpEndDate.Name = "dtpEndDate";
        dtpEndDate.Size = new Size(120, 23);
        dtpEndDate.TabIndex = 4;
        //
        // lblReasonLabel
        //
        lblReasonLabel.AutoSize = true;
        lblReasonLabel.Font = new Font("Segoe UI", 9F);
        lblReasonLabel.Location = new Point(12, 120);
        lblReasonLabel.Name = "lblReasonLabel";
        lblReasonLabel.Size = new Size(47, 15);
        lblReasonLabel.TabIndex = 5;
        lblReasonLabel.Text = "Reason:";
        //
        // cboReason
        //
        cboReason.DropDownStyle = ComboBoxStyle.DropDownList;
        cboReason.Font = new Font("Segoe UI", 9F);
        cboReason.FormattingEnabled = true;
        cboReason.Location = new Point(100, 117);
        cboReason.Name = "cboReason";
        cboReason.Size = new Size(180, 23);
        cboReason.TabIndex = 6;
        cboReason.SelectedIndexChanged += cboReason_SelectedIndexChanged;
        //
        // lblOtherReason
        //
        lblOtherReason.AutoSize = true;
        lblOtherReason.Font = new Font("Segoe UI", 9F);
        lblOtherReason.Location = new Point(12, 155);
        lblOtherReason.Name = "lblOtherReason";
        lblOtherReason.Size = new Size(51, 15);
        lblOtherReason.TabIndex = 7;
        lblOtherReason.Text = "Specify:";
        lblOtherReason.Visible = false;
        //
        // txtOtherReason
        //
        txtOtherReason.Font = new Font("Segoe UI", 9F);
        txtOtherReason.Location = new Point(100, 152);
        txtOtherReason.MaxLength = 200;
        txtOtherReason.Name = "txtOtherReason";
        txtOtherReason.Size = new Size(180, 23);
        txtOtherReason.TabIndex = 8;
        txtOtherReason.Visible = false;
        //
        // btnOK
        //
        btnOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnOK.Location = new Point(100, 195);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(85, 30);
        btnOK.TabIndex = 9;
        btnOK.Text = "OK";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        //
        // btnCancel
        //
        btnCancel.Font = new Font("Segoe UI", 9F);
        btnCancel.Location = new Point(195, 195);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(85, 30);
        btnCancel.TabIndex = 10;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // RoomBlackoutForm
        //
        AcceptButton = btnOK;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(294, 241);
        Controls.Add(btnCancel);
        Controls.Add(btnOK);
        Controls.Add(txtOtherReason);
        Controls.Add(lblOtherReason);
        Controls.Add(cboReason);
        Controls.Add(lblReasonLabel);
        Controls.Add(dtpEndDate);
        Controls.Add(lblEndDate);
        Controls.Add(dtpStartDate);
        Controls.Add(lblStartDate);
        Controls.Add(lblRoom);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "RoomBlackoutForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Block Room";
        Load += RoomBlackoutForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblRoom;
    private Label lblStartDate;
    private DateTimePicker dtpStartDate;
    private Label lblEndDate;
    private DateTimePicker dtpEndDate;
    private Label lblReasonLabel;
    private ComboBox cboReason;
    private Label lblOtherReason;
    private TextBox txtOtherReason;
    private Button btnOK;
    private Button btnCancel;
}
