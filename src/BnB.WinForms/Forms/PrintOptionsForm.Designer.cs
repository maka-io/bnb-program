namespace BnB.WinForms.Forms;

partial class PrintOptionsForm
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
        lblPages = new Label();
        lblPagesData = new Label();
        lblPageCountWarning = new Label();
        lblFont = new Label();
        lblFontData = new Label();
        grpOptions = new GroupBox();
        chkAutoScale = new CheckBox();
        chkCellOutlines = new CheckBox();
        chkColor = new CheckBox();
        chkChartBorder = new CheckBox();
        chkSaveSettings = new CheckBox();
        grpRange = new GroupBox();
        lblRows = new Label();
        txtFirstRow = new TextBox();
        lblRowsThrough = new Label();
        txtLastRow = new TextBox();
        lblColumns = new Label();
        txtFirstCol = new TextBox();
        lblColsThrough = new Label();
        txtLastCol = new TextBox();
        lblRangeNote = new Label();
        btnPrinter = new Button();
        btnFonts = new Button();
        btnOK = new Button();
        btnCancel = new Button();
        grpOptions.SuspendLayout();
        grpRange.SuspendLayout();
        SuspendLayout();
        //
        // lblPages
        //
        lblPages.AutoSize = true;
        lblPages.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPages.Location = new Point(12, 15);
        lblPages.Name = "lblPages";
        lblPages.Size = new Size(44, 15);
        lblPages.TabIndex = 0;
        lblPages.Text = "Pages:";
        //
        // lblPagesData
        //
        lblPagesData.AutoSize = true;
        lblPagesData.Location = new Point(62, 15);
        lblPagesData.Name = "lblPagesData";
        lblPagesData.Size = new Size(13, 15);
        lblPagesData.TabIndex = 1;
        lblPagesData.Text = "1";
        //
        // lblPageCountWarning
        //
        lblPageCountWarning.AutoSize = true;
        lblPageCountWarning.ForeColor = SystemColors.GrayText;
        lblPageCountWarning.Location = new Point(110, 15);
        lblPageCountWarning.Name = "lblPageCountWarning";
        lblPageCountWarning.Size = new Size(181, 15);
        lblPageCountWarning.TabIndex = 2;
        lblPageCountWarning.Text = "(estimate subject to auto-scaling)";
        //
        // lblFont
        //
        lblFont.AutoSize = true;
        lblFont.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblFont.Location = new Point(12, 40);
        lblFont.Name = "lblFont";
        lblFont.Size = new Size(35, 15);
        lblFont.TabIndex = 3;
        lblFont.Text = "Font:";
        //
        // lblFontData
        //
        lblFontData.AutoSize = true;
        lblFontData.Location = new Point(62, 40);
        lblFontData.Name = "lblFontData";
        lblFontData.Size = new Size(98, 15);
        lblFontData.TabIndex = 4;
        lblFontData.Text = "Courier - 12 pt.";
        //
        // grpOptions
        //
        grpOptions.Controls.Add(chkAutoScale);
        grpOptions.Controls.Add(chkCellOutlines);
        grpOptions.Controls.Add(chkColor);
        grpOptions.Controls.Add(chkChartBorder);
        grpOptions.Controls.Add(chkSaveSettings);
        grpOptions.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpOptions.Location = new Point(12, 70);
        grpOptions.Name = "grpOptions";
        grpOptions.Size = new Size(210, 145);
        grpOptions.TabIndex = 5;
        grpOptions.TabStop = false;
        grpOptions.Text = "Options";
        //
        // chkAutoScale
        //
        chkAutoScale.AutoSize = true;
        chkAutoScale.Font = new Font("Segoe UI", 9F);
        chkAutoScale.Location = new Point(15, 25);
        chkAutoScale.Name = "chkAutoScale";
        chkAutoScale.Size = new Size(82, 19);
        chkAutoScale.TabIndex = 0;
        chkAutoScale.Text = "Auto Scale";
        chkAutoScale.UseVisualStyleBackColor = true;
        chkAutoScale.CheckedChanged += chkAutoScale_CheckedChanged;
        //
        // chkCellOutlines
        //
        chkCellOutlines.AutoSize = true;
        chkCellOutlines.Font = new Font("Segoe UI", 9F);
        chkCellOutlines.Location = new Point(15, 50);
        chkCellOutlines.Name = "chkCellOutlines";
        chkCellOutlines.Size = new Size(93, 19);
        chkCellOutlines.TabIndex = 1;
        chkCellOutlines.Text = "Cell Outlines";
        chkCellOutlines.UseVisualStyleBackColor = true;
        //
        // chkColor
        //
        chkColor.AutoSize = true;
        chkColor.Font = new Font("Segoe UI", 9F);
        chkColor.Location = new Point(120, 25);
        chkColor.Name = "chkColor";
        chkColor.Size = new Size(54, 19);
        chkColor.TabIndex = 2;
        chkColor.Text = "Color";
        chkColor.UseVisualStyleBackColor = true;
        //
        // chkChartBorder
        //
        chkChartBorder.AutoSize = true;
        chkChartBorder.Font = new Font("Segoe UI", 9F);
        chkChartBorder.Location = new Point(120, 50);
        chkChartBorder.Name = "chkChartBorder";
        chkChartBorder.Size = new Size(93, 19);
        chkChartBorder.TabIndex = 3;
        chkChartBorder.Text = "Chart Border";
        chkChartBorder.UseVisualStyleBackColor = true;
        //
        // chkSaveSettings
        //
        chkSaveSettings.AutoSize = true;
        chkSaveSettings.Font = new Font("Segoe UI", 9F);
        chkSaveSettings.Location = new Point(15, 85);
        chkSaveSettings.Name = "chkSaveSettings";
        chkSaveSettings.Size = new Size(134, 19);
        chkSaveSettings.TabIndex = 4;
        chkSaveSettings.Text = "&Save settings on Exit";
        chkSaveSettings.UseVisualStyleBackColor = true;
        //
        // grpRange
        //
        grpRange.Controls.Add(lblRows);
        grpRange.Controls.Add(txtFirstRow);
        grpRange.Controls.Add(lblRowsThrough);
        grpRange.Controls.Add(txtLastRow);
        grpRange.Controls.Add(lblColumns);
        grpRange.Controls.Add(txtFirstCol);
        grpRange.Controls.Add(lblColsThrough);
        grpRange.Controls.Add(txtLastCol);
        grpRange.Controls.Add(lblRangeNote);
        grpRange.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpRange.Location = new Point(228, 70);
        grpRange.Name = "grpRange";
        grpRange.Size = new Size(245, 145);
        grpRange.TabIndex = 6;
        grpRange.TabStop = false;
        grpRange.Text = "Range";
        //
        // lblRows
        //
        lblRows.AutoSize = true;
        lblRows.Font = new Font("Segoe UI", 9F);
        lblRows.Location = new Point(10, 27);
        lblRows.Name = "lblRows";
        lblRows.Size = new Size(38, 15);
        lblRows.TabIndex = 0;
        lblRows.Text = "Rows:";
        //
        // txtFirstRow
        //
        txtFirstRow.Font = new Font("Segoe UI", 9F);
        txtFirstRow.Location = new Point(70, 24);
        txtFirstRow.MaxLength = 5;
        txtFirstRow.Name = "txtFirstRow";
        txtFirstRow.Size = new Size(50, 23);
        txtFirstRow.TabIndex = 1;
        //
        // lblRowsThrough
        //
        lblRowsThrough.AutoSize = true;
        lblRowsThrough.Font = new Font("Segoe UI", 9F);
        lblRowsThrough.Location = new Point(126, 27);
        lblRowsThrough.Name = "lblRowsThrough";
        lblRowsThrough.Size = new Size(50, 15);
        lblRowsThrough.TabIndex = 2;
        lblRowsThrough.Text = "through";
        //
        // txtLastRow
        //
        txtLastRow.Font = new Font("Segoe UI", 9F);
        txtLastRow.Location = new Point(182, 24);
        txtLastRow.MaxLength = 5;
        txtLastRow.Name = "txtLastRow";
        txtLastRow.Size = new Size(50, 23);
        txtLastRow.TabIndex = 3;
        //
        // lblColumns
        //
        lblColumns.AutoSize = true;
        lblColumns.Font = new Font("Segoe UI", 9F);
        lblColumns.Location = new Point(10, 57);
        lblColumns.Name = "lblColumns";
        lblColumns.Size = new Size(56, 15);
        lblColumns.TabIndex = 4;
        lblColumns.Text = "Columns:";
        //
        // txtFirstCol
        //
        txtFirstCol.Font = new Font("Segoe UI", 9F);
        txtFirstCol.Location = new Point(70, 54);
        txtFirstCol.MaxLength = 4;
        txtFirstCol.Name = "txtFirstCol";
        txtFirstCol.Size = new Size(50, 23);
        txtFirstCol.TabIndex = 5;
        //
        // lblColsThrough
        //
        lblColsThrough.AutoSize = true;
        lblColsThrough.Font = new Font("Segoe UI", 9F);
        lblColsThrough.Location = new Point(126, 57);
        lblColsThrough.Name = "lblColsThrough";
        lblColsThrough.Size = new Size(50, 15);
        lblColsThrough.TabIndex = 6;
        lblColsThrough.Text = "through";
        //
        // txtLastCol
        //
        txtLastCol.Font = new Font("Segoe UI", 9F);
        txtLastCol.Location = new Point(182, 54);
        txtLastCol.MaxLength = 4;
        txtLastCol.Name = "txtLastCol";
        txtLastCol.Size = new Size(50, 23);
        txtLastCol.TabIndex = 7;
        //
        // lblRangeNote
        //
        lblRangeNote.Font = new Font("Segoe UI", 8F);
        lblRangeNote.ForeColor = SystemColors.GrayText;
        lblRangeNote.Location = new Point(10, 90);
        lblRangeNote.Name = "lblRangeNote";
        lblRangeNote.Size = new Size(230, 45);
        lblRangeNote.TabIndex = 8;
        lblRangeNote.Text = "Note: Row and Column ranges will not be saved on Exit regardless of Save Setting.";
        //
        // btnPrinter
        //
        btnPrinter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnPrinter.Location = new Point(490, 12);
        btnPrinter.Name = "btnPrinter";
        btnPrinter.Size = new Size(90, 28);
        btnPrinter.TabIndex = 7;
        btnPrinter.Text = "&Printer...";
        btnPrinter.UseVisualStyleBackColor = true;
        btnPrinter.Click += btnPrinter_Click;
        //
        // btnFonts
        //
        btnFonts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnFonts.Location = new Point(490, 46);
        btnFonts.Name = "btnFonts";
        btnFonts.Size = new Size(90, 28);
        btnFonts.TabIndex = 8;
        btnFonts.Text = "&Fonts...";
        btnFonts.UseVisualStyleBackColor = true;
        btnFonts.Click += btnFonts_Click;
        //
        // btnOK
        //
        btnOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnOK.Location = new Point(490, 80);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(90, 28);
        btnOK.TabIndex = 9;
        btnOK.Text = "&OK";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        //
        // btnCancel
        //
        btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnCancel.Location = new Point(490, 114);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 28);
        btnCancel.TabIndex = 10;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // PrintOptionsForm
        //
        AcceptButton = btnOK;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(593, 227);
        Controls.Add(btnCancel);
        Controls.Add(btnOK);
        Controls.Add(btnFonts);
        Controls.Add(btnPrinter);
        Controls.Add(grpRange);
        Controls.Add(grpOptions);
        Controls.Add(lblFontData);
        Controls.Add(lblFont);
        Controls.Add(lblPageCountWarning);
        Controls.Add(lblPagesData);
        Controls.Add(lblPages);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PrintOptionsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Print Dialog";
        Load += PrintOptionsForm_Load;
        grpOptions.ResumeLayout(false);
        grpOptions.PerformLayout();
        grpRange.ResumeLayout(false);
        grpRange.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblPages;
    private Label lblPagesData;
    private Label lblPageCountWarning;
    private Label lblFont;
    private Label lblFontData;
    private GroupBox grpOptions;
    private CheckBox chkAutoScale;
    private CheckBox chkCellOutlines;
    private CheckBox chkColor;
    private CheckBox chkChartBorder;
    private CheckBox chkSaveSettings;
    private GroupBox grpRange;
    private Label lblRows;
    private TextBox txtFirstRow;
    private Label lblRowsThrough;
    private TextBox txtLastRow;
    private Label lblColumns;
    private TextBox txtFirstCol;
    private Label lblColsThrough;
    private TextBox txtLastCol;
    private Label lblRangeNote;
    private Button btnPrinter;
    private Button btnFonts;
    private Button btnOK;
    private Button btnCancel;
}
