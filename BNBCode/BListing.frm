VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmBoundListing 
   ClientHeight    =   4170
   ClientLeft      =   1635
   ClientTop       =   2280
   ClientWidth     =   6555
   HelpContextID   =   132
   LinkTopic       =   "Form1"
   MDIChild        =   -1  'True
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4170
   ScaleWidth      =   6555
   Begin VB.ListBox lstColumnOrderSave 
      Height          =   450
      ItemData        =   "BLISTING.frx":0000
      Left            =   0
      List            =   "BLISTING.frx":0002
      TabIndex        =   10
      TabStop         =   0   'False
      Top             =   1560
      Visible         =   0   'False
      Width           =   1095
   End
   Begin VB.ListBox lstSortOrderSave 
      Height          =   450
      ItemData        =   "BLISTING.frx":0004
      Left            =   0
      List            =   "BLISTING.frx":0006
      TabIndex        =   9
      TabStop         =   0   'False
      Top             =   780
      Visible         =   0   'False
      Width           =   1095
   End
   Begin VB.TextBox txtDateFormat 
      Appearance      =   0  'Flat
      Height          =   315
      Left            =   5160
      TabIndex        =   8
      TabStop         =   0   'False
      Tag             =   "Text"
      Text            =   "m/d/yyyy"
      Top             =   180
      Visible         =   0   'False
      Width           =   1215
   End
   Begin Threed.SSPanel pnlMessage 
      Height          =   495
      Left            =   3480
      TabIndex        =   5
      Top             =   0
      Width           =   1215
      _Version        =   65536
      _ExtentX        =   2143
      _ExtentY        =   873
      _StockProps     =   15
      Caption         =   "pnlMessage"
      BackColor       =   12632256
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      RoundedCorners  =   0   'False
      FloodShowPct    =   0   'False
   End
   Begin VB.CommandButton cmdOptions 
      Caption         =   "&Sort..."
      Height          =   375
      Left            =   3480
      TabIndex        =   3
      Top             =   3120
      Width           =   900
   End
   Begin VB.CommandButton cmdSave 
      Caption         =   "&Export..."
      Height          =   375
      Left            =   2400
      TabIndex        =   2
      Top             =   3120
      Width           =   900
   End
   Begin VB.CommandButton cmd3dPrint 
      Caption         =   "&Print..."
      Height          =   375
      Left            =   1320
      TabIndex        =   1
      Top             =   3120
      Width           =   900
   End
   Begin VB.CommandButton cmdClose 
      Caption         =   "&Close"
      Height          =   375
      Left            =   4560
      TabIndex        =   4
      Top             =   3120
      Width           =   900
   End
   Begin VB.TextBox txtStatement 
      Height          =   375
      Left            =   120
      TabIndex        =   0
      TabStop         =   0   'False
      Text            =   "txtStatement"
      Top             =   120
      Visible         =   0   'False
      Width           =   1335
   End
   Begin VB.Data datListing 
      Caption         =   "datListing"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   300
      Left            =   120
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   2760
      Visible         =   0   'False
      Width           =   2175
   End
   Begin SSDataWidgets_A.SSDBData datdwListing 
      Bindings        =   "BLISTING.frx":0008
      Height          =   435
      Left            =   840
      TabIndex        =   7
      Top             =   3600
      Width           =   4980
      _Version        =   131075
      _ExtentX        =   8784
      _ExtentY        =   767
      _StockProps     =   79
      BackColor       =   16777215
      ShowAddButton   =   0   'False
      ShowCancelButton=   0   'False
      ShowDelButton   =   0   'False
      ShowUpdateButton=   0   'False
      BevelOuter      =   0
      PageValue       =   5
      ShowBookmarkButtons=   0
      ShowFindButtons =   0
   End
   Begin SSDataWidgets_B.SSDBGrid grddwListing 
      Height          =   1935
      Left            =   1200
      TabIndex        =   6
      Top             =   720
      Width           =   4335
      _Version        =   131078
      DataMode        =   2
      Col.Count       =   0
      AllowUpdate     =   0   'False
      AllowColumnSwapping=   2
      AllowGroupShrinking=   0   'False
      AllowColumnShrinking=   0   'False
      SelectTypeCol   =   3
      SelectTypeRow   =   3
      ForeColorEven   =   0
      RowHeight       =   423
      Columns(0).Width=   3200
      _ExtentX        =   7646
      _ExtentY        =   3413
      _StockProps     =   79
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   2520
      Top             =   0
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
End
Attribute VB_Name = "frmBoundListing"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim NL As String                'New Line of text.
Dim RefreshFlag As Integer      'Indicates whether of not data control needs to be refreshed.
Dim msg As String   'MsgBox message string
'Record global SQL Statement at module level (before it changes).
Dim mSQL As String
'Module level variables for Report Identification
'which correspond to Global variables.
Dim mReportNumber As Integer
Dim mCaption As String   'Title of the Report/SQL Statement

'Print declarations
Dim ColPosition() As Single
'These are based on what user entered in Print Dialog box
Dim PrintColStart, PrintColEnd, PrintRowStart, PrintRowEnd As Integer
'These are based on what user actually selected. Values are zero-based.
Dim PrintSelColStart, PrintSelColEnd, PrintSelRowStart, PrintSelRowEnd As Integer

'Form's original position prior to resize event.
Dim OrigLeft, OrigTop, OrigWidth, OrigHeight As Long

'Record column widths in an array.  First set as displayed.  Second set as maximum for setting print column widths.
Dim ColWidths() As Long
Const ScreenCol = 0
Const PrintCol = 1
'Needed to hold maximum text for each column if changing screen font but not yet printing.
Dim MaxText() As String

'Form level flag as to whether or not print column widths need to be determined.
Dim NeedToRecordPrintColumnWidths As Integer
Dim CallingGrid As Control
Dim CallingForm As Form
Dim CurrRec As Integer
'Variables needed for Print Bug workaround
Dim v_FontName As String
Dim v_FontSize As Single
Dim v_FontBold As Integer
Dim v_FontItalic As Integer
Dim v_FontUnderline As Integer



Private Sub cmd3dPrint_Click()
    
    On Error GoTo cmd3dPrint_Click_Error

    Dim X As Integer
    Screen.MousePointer = HOURGLASS
    DisableCommandButtons Me
    'Set dialog box properties
    frmPrintDialog.txtCallingFormCaption.Text = Me.Caption
    frmPrintDialog.txtHeaderLines = 5   'Reference to 5 header lines in Print_DataGrid_Header
    'Set max and min print ranges.
    frmPrintDialog.txtFirstRow.Tag = "1"
    frmPrintDialog.txtLastRow.Tag = Str(grddwListing.Rows)
    frmPrintDialog.txtFirstCol.Tag = "1"
    frmPrintDialog.txtLastCol.Tag = Str(grddwListing.Cols)
    'Disable graphing options.
    frmPrintDialog.chk3dColor.Enabled = False
    frmPrintDialog.chk3dChartBorder.Enabled = False
    'Run thru the Forms collection and identify the calling form.
    For i = 0 To Forms.Count - 1
        If Forms(i).Caption = frmPrintDialog.txtCallingFormCaption.Text Then
            Set CallingForm = Forms(i)
            Exit For
        End If
    Next
    'Setup public variables for selected row and column ranges.
    GetSelectedRowsAndCols grddwListing
    
    frmPrintDialog.txtFirstRow.Text = Str(PrintSelRowStart + 1)
    frmPrintDialog.txtLastRow.Text = Str(PrintSelRowEnd + 1)
    frmPrintDialog.txtFirstCol.Text = Str(PrintSelColStart + 1)
    frmPrintDialog.txtLastCol.Text = Str(PrintSelColEnd + 1)

    'Transfer control to dialog box
    frmPrintDialog.Show 1   'Modal
    DoEvents
    CallingForm.SetFocus
    'Resume after control returns from dialog box
    'If the print dialog was unloaded or cancelled, then don't print and return form to normal.
    If Not FormLoaded(frmPrintDialog) Then GoTo cmd3dPrint_Click_Resume
    If frmPrintDialog.optCancelled.Value Then GoTo cmd3dPrint_Click_Resume
    'Indicate delay to user.
    Screen.MousePointer = HOURGLASS
    'Record current position in recordset so that we can return there when done.
    Dim OrigRow As Variant
    'Display message panel indicating activity.
    StatusMessage Me, "Print preparation, please wait ...", True
    grddwListing.Visible = False
    If NeedToRecordPrintColumnWidths Then
        ResizeGridCols grddwListing
        grddwListing.Redraw = True
       ' Call SizeGridCells(Me, grddwListing, SGC_ALL) 'DO NOT USE. Takes too long.
        Call RecordPrintColumnWidths(grddwListing)
        NeedToRecordPrintColumnWidths = False
    End If
    SetToPrintColumnWidths grddwListing

    'Start Printing
    StatusMessage Me, "Printing ...", True

    Print_DataGrid_Listing grddwListing

cmd3dPrint_Click_Resume:
    'Cleanup...
    'Re-display datagrid and remove message panel.
    DoEvents
    CallingForm.SetFocus
    SetToScreenColumnWidths grddwListing
    grddwListing.Visible = True
    StatusMessage Me, "", False
    'Unload dialog box from memory
    Unload frmPrintDialog
    'Re-enable command buttons and restore mousepointer to default
    EnableCommandButtons Me
    'Restore default mousepointer
    Screen.MousePointer = DEFAULT

Exit Sub

cmd3dPrint_Click_Error:
    'User pressed common dialog cancel button is Err 32755
    If Err <> 32755 Then
       X% = IsError("cmd3dPrint_Click")   'If not intentional, display message.
    Else
       MsgBox Err.Description
    End If
    Resume cmd3dPrint_Click_Resume

End Sub


Private Sub cmdClose_Click()
   Unload Me
End Sub




Private Sub cmdOptions_Click()
    On Error GoTo cmd3dOptions_Err
  
    Screen.MousePointer = HOURGLASS
    'Dimension variables.
    Dim i, xx, j As Integer
 
    DisableCommandButtons Me

    'Set dialog box properties (setting form's properties will cause it to be loaded.)
    frmListDialog.txtCallingFormCaption.Text = Me.Caption
    frmListDialog.txtComboDateFormat.Text = txtDateFormat.Text
    frmListDialog.txtComboDateFormat.Tag = txtDateFormat.Tag

    'Run thru the Forms collection and identify the calling form.
    For i = 0 To Forms.Count - 1
        If Forms(i).Caption = frmListDialog.txtCallingFormCaption.Text Then
            Set CallingForm = Forms(i)
            Exit For
        End If
    Next
    If frmListDialog.txtCallingFormCaption.Text Like "*Listing*" Then
        'Run thru the Control collection and identify the calling form's grid.
        For i = 0 To CallingForm.Controls.Count - 1
            If TypeOf CallingForm.Controls(i) Is SSDBGrid Then
                Set CallingGrid = CallingForm.Controls(i)
                Exit For
            End If
        Next
    Else
        'Do nothing
    End If
        
    'Transfer control to dialog box
    frmListDialog.Show 1   'Modal
    DoEvents
    DoEvents
    CallingForm.SetFocus
    'Resume after control returns from dialog box
    'If the options dialog was cancelled, then don't change listing form/grid properties.
    If frmListDialog.optCancelled Then GoTo cmd3dOptions_resume
    Screen.MousePointer = HOURGLASS
    'Update TagVariant property in case Col order changed
    SetTagVariantProp
    'Reset ORDER BY clause if sort order has changed.
    'Remove and replace ORDER BY clause if exists, otherwise add a new one.
    If frmListDialog.optSortOrderChanged.Value = CHECKED Then
        Dim TempStr As String
        If InStr(1, txtStatement.Text, "order by", 1) > 0 Then
           TempStr = Trim(Left(txtStatement.Text, InStr(1, txtStatement.Text, "order by", 1) - 1))
        Else
           TempStr = Trim(txtStatement.Text)
        End If
        'Build ORDER BY clause. Only use first 8 fields in ORDER BY (more would not be necessary)
        TempStr = TempStr & " order by "
        For i = 0 To 7
          If i = 0 And frmListDialog.chkDescending.Value = CHECKED Then
             If frmListDialog.lstSortOrder.List(i) <> "" Then
                '*** Error if attempt to sort on Memo fields, so exclude.
                If Not frmListDialog.lstSortOrder.List(i) Like "comment*" _
                   And Not frmListDialog.lstSortOrder.List(i) Like "cmmnt*" _
                   And frmListDialog.lstSortOrder.List(i) <> "closeure" Then
                   TempStr = TempStr & frmListDialog.lstSortOrder.List(i) & " desc,"
                End If
             End If
          Else
             If frmListDialog.lstSortOrder.List(i) <> "" Then
                 If Not frmListDialog.lstSortOrder.List(i) Like "comment*" _
                   And Not frmListDialog.lstSortOrder.List(i) Like "cmmnt*" _
                   And frmListDialog.lstSortOrder.List(i) <> "closeure" Then
                   TempStr = TempStr & frmListDialog.lstSortOrder.List(i) & ","
                End If
             End If
          End If
        Next i
        TempStr = Left(TempStr, Len(TempStr) - 1)
        If TempStr = " order by " Then TempStr = ""
        txtStatement.Text = TempStr
        Call Form_Activate
    End If
    'Set Grid font properties.
    grddwListing.Font.Bold = frmListDialog.CMDialog1.FontBold
    grddwListing.Font.Italic = frmListDialog.CMDialog1.FontItalic
    'grddwListing.Font.Strikethru = frmListDialog.CMDialog1.FontStrikethru
    grddwListing.Font.Underline = frmListDialog.CMDialog1.FontUnderline
    grddwListing.Font.Name = frmListDialog.CMDialog1.FontName
    grddwListing.Font.Size = frmListDialog.CMDialog1.FontSize
    'Set Column Formats.
    txtDateFormat.Text = frmListDialog.txtComboDateFormat.Text
    For i = 0 To datListing.Recordset.Fields.Count - 1
      If datListing.Recordset.Fields(i).Type = dbDate Then
        For j = 0 To datListing.Recordset.Fields.Count - 1
           If datListing.Recordset.Fields(i).Name = grddwListing.Columns(i).Caption Then
             grddwListing.Columns(i).NumberFormat = txtDateFormat.Text
             Exit For
           End If
        Next j
      ElseIf datListing.Recordset.Fields(i).Type = dbCurrency Then
        For j = 0 To datListing.Recordset.Fields.Count - 1
           If datListing.Recordset.Fields(i).Name = grddwListing.Columns(i).Caption Then
             grddwListing.Columns(i).Alignment = 1 'Right Justify
             grddwListing.Columns(i).NumberFormat = CURRENCYFORMAT
             Exit For
           End If
        Next j
     End If
    Next i
    grddwListing.Refresh
    ReorderGridColumns
    ResizeGridCols grddwListing
    
    GoTo cmd3dOptions_resume
    
Exit Sub

cmd3dOptions_Err:
    'User pressed cancel button is Err 32755
    If Err <> 32755 Then    'If not intentional, display message.
        msg = "Error #" & Err & ":  " & Error$
        MsgBox msg, MB_ICONEXLAMATION, Me.Caption & " Print"
    End If
    Resume cmd3dOptions_resume

cmd3dOptions_resume:
    grddwListing.Visible = True
    EnableCommandButtons Me
    Screen.MousePointer = DEFAULT

End Sub


Private Sub cmdSave_Click()


    On Error GoTo cmd3dSave_Click_Error

    'Declare & set variables
    Dim MyDS As Recordset
    Set MyDS = datListing.Recordset
    Dim OrigRow As Variant      'used to record bookmark of row to return to when done.
    Dim Response As Integer     'Message box response.
    'Record current position in recordset so that we can return there when done.
    OrigRow = MyDS.Bookmark
    'Call the export dialog box and exit on error or user cancellation.
    If Not ExportDialog(Me, MyDS) Then GoTo cmd3dSave_Click_Resume
    'Resume control from dialog box ...
    'See if frmExportDialog has been unloaded, if not then continue. If unloaded,
    'don't Goto Resume routine because it is referenced there; just Exit Sub.
    Dim vLoaded As Integer
    vLoaded = False
    If FormLoaded(frmExportDialog) Then 'If Export Dialog is loaded...
      For i = 0 To Forms.Count - 1
        'If Export Dialog is loaded for particular instance of Listing form...
        If Forms(i).Caption = frmExportDialog.txtCallingFormCaption.Text Then
           'MsgBox Forms(i).Caption
           vLoaded = True
           Exit For
        End If
      Next
    End If
    If Not vLoaded Then Exit Sub
    Screen.MousePointer = HOURGLASS
    'Display message panel indicating activity.
    StatusMessage Me, "Saving data to file ...", True
    grddwListing.Visible = False
    'Call export data and exit on error.
    If Not ExportData(Me, MyDS) Then GoTo cmd3dSave_Click_Resume

cmd3dSave_Click_Resume:
    'CLEAN UP ...
    'Set focus back to instance of frmBoundListing.
    'Run thru the Forms collection and identify the calling form.
    For i = 0 To Forms.Count - 1
      If FormLoaded(frmExportDialog) Then
        If Forms(i).Caption = frmExportDialog.txtCallingFormCaption.Text Then
            Set CallingForm = Forms(i)
            Exit For
        End If
      End If
    Next
    DoEvents
    DoEvents
    CallingForm.SetFocus
    'Reposition to original row in datagrid
    MyDS.Bookmark = OrigRow
    'Re-display datagrid and remove message panel.
    grddwListing.Visible = True
    StatusMessage Me, "", False
    'Unload dialog box from memory
    Unload frmExportDialog
    'Restore default mousepointer
    Screen.MousePointer = DEFAULT
Exit Sub

cmd3dSave_Click_Error:
    Resume cmd3dSave_Click_Resume

End Sub

Private Sub datdwListing_Click(ByVal nPosition As Integer)
    'On Error GoTo datdwListing_Click_Error
    Me.SetFocus
    'Dim EntryConfNum As String
   ' gRowChangeFormName = Me.Name
    
    'case1: first row button
    If nPosition = 3 Then
        CurrRec = 0
    'case2: previous page button
    ElseIf nPosition = 5 Then
        If CurrRec > datdwListing.PageValue Then
            CurrRec = CurrRec - datdwListing.PageValue
        Else
            CurrRec = 0
        End If
    'case3: previous row button
    ElseIf nPosition = 7 Then
        If CurrRec > 0 Then
            CurrRec = CurrRec - 1
        Else
            CurrRec = 0
        End If
    'case4: save bookmark button
    ElseIf nPosition = 16 Then
        SaveRec = CurrRec
    'case5: goto saved bookmark
    ElseIf nPosition = 18 Then
        If SaveRec > 0 Then CurrRec = SaveRec
    'case6: next row button
    ElseIf nPosition = 8 Then
        If CurrRec < Me.datListing.Recordset.RecordCount - 1 Then
            CurrRec = CurrRec + 1
        Else
            CurrRec = Me.datListing.Recordset.RecordCount - 1
        End If
    'case7: next page button
    ElseIf nPosition = 6 Then
        If CurrRec < (Me.datListing.Recordset.RecordCount - 1) - datdwListing.PageValue Then
            CurrRec = CurrRec + datdwListing.PageValue
        Else
            CurrRec = Me.datListing.Recordset.RecordCount - 1
        End If
    'case8: last row button
    ElseIf nPosition = 4 Then
        CurrRec = Me.datListing.Recordset.RecordCount - 1
    End If
    grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrRec)
    datdwListing.Caption = "Row " & CurrRec & " of " & datListing.Recordset.RecordCount
 
Exit Sub

'datdwListing_Click_Error:
'    If IsError("datdwListing_Click") Then
'        Resume datdwListing_Click_Resume
'    Else
'        Resume Next
'    End If
'Exit Sub

datdwListing_Click_Resume:
    Screen.MousePointer = DEFAULT
End Sub
Private Sub Form_Activate()
'  datListing.RecordSource = frmGeneralGuest.datListing.RecordSource
'  datListing.Refresh
    'Set the data control the first time the form is activated.
    'Note: the first time the form is activated is like form load
    'except that the form load procedure may be followed by
    'additional code contained in a calling procedure.  This
    'has caused problems with error handling, and as such the
    'RecordSource.Refresh has been moved here.
 '   Static TimesActivated As Integer
 '   TimesActivated = TimesActivated + 1
 '   If TimesActivated = 1 Then

     On Error GoTo Form_Activate_Error
     'If this form is in the background (does not have focus) and the
     'Minimize button is clicked on this form that does not yet have the focus,
     'an endless loop of Minimizing and Activating will occur. The following
     'line prevents this interesting problem.
     If Me.WindowState = MINIMIZED Then Exit Sub
     
     Screen.MousePointer = HOURGLASS
     If datListing.RecordSource <> txtStatement.Text Then
        grddwListing.Visible = False
        datdwListing.Enabled = False
        'Clear grid for possible call from Options. Doesn't hurt otherwise.
        grddwListing.Reset
        'Display status message
        StatusMessage Me, "Querying the database ...", True
        'Set data control's record source equal to SQL statement.
        datListing.RecordSource = txtStatement.Text
        'Refresh datacontrol and query the database.
        If Not GetDCRows(datListing) Then GoTo Form_Activate_Resume
        For i = 0 To 5
          DoEvents
        Next i
        If datListing.Recordset.RecordCount = 0 Then
           StatusMessage Me, "No rows exist.", True
           cmdClose.Enabled = True
           GoTo Form_Activate_Resume
        End If
        'Load data into grid
        StatusMessage Me, "Loading data grid...", True
        LoadGridRows
        Call grddwListing_InitColumnProps
        'Display status message
        StatusMessage Me, "Sizing Grid Cells ...", True
        'Size the grid cells to fit displayed text & headers.
        
        'Call SizeGridCells(Me, grddwListing, SGC_VISIBLE)
        ResizeGridCols grddwListing
        grddwListing.Redraw = True
        
        'Put recordsource in sync with datagrid. Grid has already moved to first record in LoadGridRows.
        datListing.Recordset.MoveFirst
        For N = 1 To 5
            DoEvents
        Next N
        'Set column format (date and currency)
        FormatColumns
        'Initialize the Column Sort Order Save listbox. This listbox
        'is also reset by frmListDialog upon reorder of columns.
        If lstColumnOrderSave.List(0) = "" Then
          For i = 0 To grddwListing.Cols - 1
            lstColumnOrderSave.AddItem grddwListing.Columns(i).Caption
          Next i
        End If
        'Initialize the Row Sort Order Save listbox. Also reset
        'by frmListDialog upon reorder of rows.
        If lstSortOrderSave.List(0) = "" Then
           For i = 0 To grddwListing.Cols - 1
             lstSortOrderSave.AddItem grddwListing.Columns(i).Caption
           Next i
        End If
        'Initialize the grid's TagVariant property which holds the DISPLAYED column order
        'for each column.
        SetTagVariantProp
        'Re-Enable command buttons disabled at start of form load.
        EnableCommandButtons Me
        StatusMessage Me, "", False
        'If there are no rows in the data grid, disable the print, save, options buttons.
        If grddwListing.Rows = 0 Then
            cmd3dPrint.Enabled = False
            cmdSave.Enabled = False
            cmdOptions.Enabled = False
        End If
        'Record form's current position. (for use during resize event)
        OrigLeft = Me.Left
        OrigTop = Me.Top
        OrigWidth = Me.Width
        OrigHeight = Me.Height
        datdwListing.Enabled = True
     End If

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

Form_Activate_Error:
   'MsgBox "Activate error:" & Err.Description
   Screen.MousePointer = DEFAULT
   Unload Me

End Sub

Private Sub Form_Load()
    
    'On Error GoTo Form_Load_Error
    Screen.MousePointer = HOURGLASS
    'Set minimum ColWidths() array dimensions.  Will be redimensioned again later with actual number of columns.
    ReDim ColWidths(1, 0)
    DisableCommandButtons Me    'Re-Enabled after initial Active
    'Intialize form level variables.
    NL = Chr$(13) & Chr$(10)   'New Line of text.  Form level variable.
    NeedToRecordPrintColumnWidths = True
    'Record global variable setting at the time this report was initiated.
'    mSQL = gSQL
'    mCaption = gCaption
    'Record the most recently executed SQL statement into the LastSQL log.
    Call IncrementReportNo(True)   'Note: this will increment gReportNumber & append the new report number to gCaption.
    'Record the datetime of query (consistent with LastSQL(0)) in grid's caption.
'    grddwListing.Caption = gLastSQL(0).When
    'Record this report's sequential number.
'    mReportNumber = gReportNumber
    'Set this report's caption and SQL statement.
    Me.Caption = gCaption
    Me.txtStatement.Text = gSQL
    'Display current database in label.
 '   lblDatabase.Caption = gDatabaseName
    'Link data controls to the database
    datListing.DatabaseName = gDatabaseName
    'Provide database connect string for non-Access databases
  '  datListing.Connect = gConnect
  '  'Set the read only state of this database connection.
  '  datListing.ReadOnly = gReadOnly
  '  'Set characteristics of data control's database connection.
  '  If IsTransformStatement(gSQL) Then
  '      'Don't use SQLPassThrough because Sybase is not going to understand this query.
  '      datListing.Options = 0
  '  Else
  '      datListing.Options = gOptions
  '  End If
    'Initialize the data control's record source.
    datListing.RecordSource = ""
    
    Screen.MousePointer = DEFAULT
End Sub


Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
   
   On Error GoTo QueryUnload_Error
   
   If FormLoaded(frmListDialog) Then
      Unload frmListDialog
      Set frmListDialog = Nothing
   End If
   If FormLoaded(frmExportDialog) Then
      Unload frmExportDialog
      Set frmExportDialog = Nothing
   End If
   If FormLoaded(frmPrintDialog) Then
      Unload frmPrintDialog
      Set frmPrintDialog = Nothing
   End If
   
QueryUnload_Resume:
   Exit Sub
   
QueryUnload_Error:
   Resume QueryUnload_Resume
   
End Sub

Private Sub Form_Resize()

    On Error GoTo Resize_Error
    'Only respond to event if form is not minimized.
    If Me.WindowState = MINIMIZED Then Exit Sub

    Screen.MousePointer = HOURGLASS

    Dim CommandTop, CommandWidth, CommandHeight, StretchWidth As Long
    Dim CommandCount As Integer 'The number of command buttons

    pnlMessage.Caption = ""
    'Initialize Variables
    CommandCount = 4
    CommandHeight = 375 'Twips
    CommandWidth = 900  'Twips
    CommandTop = Me.ScaleHeight - CommandHeight
    'Determine width of horizontal data control given standard layout,
    'where standard layout aligns the data control and command buttons
    'horizontally.
    measurement = Me.ScaleWidth - (CommandCount * CommandWidth)
    'If expected width < (2500 twips + the text width of the displayed caption) then use narrow layout.
    If measurement >= (2500 + Me.TextWidth(datListing.Caption)) Then
    'Reposition Controls in standard layout.  Note: Don't change control heights!
        cmdClose.Move 0, CommandTop, CommandWidth, CommandHeight
        cmd3dPrint.Move CommandWidth, CommandTop, CommandWidth, CommandHeight
        datdwListing.Move (CommandWidth * 2), CommandTop, (ScaleWidth - (CommandCount * CommandWidth)), CommandHeight
        cmdOptions.Move (ScaleWidth - CommandWidth * 2), CommandTop, CommandWidth, CommandHeight
        cmdSave.Move (ScaleWidth - CommandWidth), CommandTop, CommandWidth, CommandHeight
        grddwListing.Move 0, 0, ScaleWidth, CommandTop
        txtStatement.Move 0, 0, ScaleWidth, CommandTop
        pnlMessage.Move 0, 0, ScaleWidth, CommandTop
    Else
    'Reposition Controls in narrow layout.
        'First check stretch width of commands
        StretchWidth = ScaleWidth / CommandCount
        If StretchWidth >= CommandWidth Then
            CommandWidth = StretchWidth
            cmdClose.Move 0, CommandTop - CommandHeight, CommandWidth, CommandHeight
            cmd3dPrint.Move CommandWidth, CommandTop - CommandHeight, CommandWidth, CommandHeight
            cmdSave.Move (CommandWidth * 2), CommandTop - CommandHeight, CommandWidth, CommandHeight
            cmdOptions.Move (CommandWidth * 3), CommandTop - CommandHeight, CommandWidth, CommandHeight
            datdwListing.Move 0, CommandTop, ScaleWidth, CommandHeight
            grddwListing.Move 0, 0, ScaleWidth, CommandTop - CommandHeight
            txtStatement.Move 0, 0, ScaleWidth, CommandTop - CommandHeight
            pnlMessage.Move 0, 0, ScaleWidth, CommandTop - CommandHeight
        Else    'Stacked narrow layout
            CommandWidth = StretchWidth * 2
            cmdClose.Move 0, CommandTop - CommandHeight * 2, CommandWidth, CommandHeight
            cmd3dPrint.Move CommandWidth, CommandTop - CommandHeight, CommandWidth, CommandHeight
            cmdSave.Move (CommandWidth), CommandTop - CommandHeight * 2, CommandWidth, CommandHeight
            cmdOptions.Move 0, CommandTop - CommandHeight, CommandWidth, CommandHeight
            grddwListing.Move 0, 0, ScaleWidth, CommandTop - CommandHeight * 2
            datdwListing.Move 0, CommandTop, ScaleWidth, CommandHeight
            txtStatement.Move 0, 0, ScaleWidth, CommandTop - CommandHeight * 2
            pnlMessage.Move 0, 0, ScaleWidth, CommandTop - CommandHeight * 2
        End If
    End If
    'Record the width and height of form for future use.
    OrigLeft = Me.Left
    OrigTop = Me.Top
    OrigWidth = Me.Width
    OrigHeight = Me.Height

Resize_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

Resize_Error:
   Resume Resize_Resume

End Sub


Private Sub grddwListing_AfterPosChanged(ByVal WhatChanged As Integer, ByVal NewIndex As Integer)

 For i = 0 To grddwListing.Cols - 1
    grddwListing.Columns(i).TagVariant = grddwListing.Columns(i).Position
 Next i
 
 lstColumnOrderSave.Clear
 
 For i = 0 To grddwListing.Cols - 1
   For j = 0 To grddwListing.Cols - 1
     If grddwListing.Columns(j).TagVariant = i Then
        lstColumnOrderSave.List(i) = grddwListing.Columns(j).Caption
        Exit For
     End If
   Next j
 Next i

End Sub

Private Sub grddwListing_Click()
  Me.SetFocus
End Sub

Private Sub grddwListing_ColMove(ByVal ColIndex As Integer, ByVal NewPos As Integer, Cancel As Integer)
   
 grddwListing.Columns(ColIndex).TagVariant = NewPos

End Sub


Private Sub grddwListing_InitColumnProps()
    
    
    'Exit immediately if there are no columns to initialize.
    If grddwListing.Cols < 1 Then Exit Sub
    
    grddwListing.Redraw = False
    
    'Dimension an array to record the screen vs print column widths
    'which at this moment are to be determined.
    ReDim ColWidths(1, grddwListing.Cols - 1)
    
End Sub

Private Sub grddwListing_LostFocus()
   RecordScreenColumnWidths grddwListing
End Sub


Private Sub grddwListing_RowColChange(ByVal LastRow As Variant, ByVal LastCol As Integer)

    'Display "row of rows" in enhanced data control caption.
    If datListing.RecordSource = "" Then
        datdwListing.Caption = "No Rows"
    Else
        datdwListing.Caption = "Row " & (grddwListing.AddItemRowIndex(grddwListing.Bookmark) + 1) & " of " & datListing.Recordset.RecordCount
    End If
  
End Sub
Public Sub RecordPrintColumnWidths(TheGrid As SSDBGrid)

    Dim c As Integer

    For c = 0 To (TheGrid.Cols - 1)
        'Find out which DISPLAY column C refers to.
        For i = 0 To TheGrid.Cols - 1
           If TheGrid.Columns(i).TagVariant = c Then
              ColWidths(PrintCol, c) = TheGrid.Columns(i).Width
              Exit For
           End If
        Next i
        'ColWidths(PrintCol, C) = TheGrid.Columns(i).Width
    Next c

End Sub

Public Sub Print_DataGrid_Listing(TheGrid As SSDBGrid)
    'This routine prints the headers and data in the DataGrid.
    
    On Error GoTo Print_DataGrid_Error
    
    Dim c, i, r As Integer
    Dim s As String
    Dim Response%, ColsTruncated%, LeftMargin%, Result%     'Integers
    Dim OrigFontSize As Single
    LeftMargin% = 1 '2
    'Record DataGrid's current Visible state and then hide it.
    OrigGridVisible% = TheGrid.Visible
    TheGrid.Visible = False
    'Record current printer scalemode & switch to pixel.
    PrinterMode% = Printer.ScaleMode
    Printer.ScaleMode = 3   'Pixel
    'Set initial row & column print ranges to include all rows and columns.
    PrintColStart = 0
    PrintColEnd = TheGrid.Cols - 1
    PrintRowStart = 0
    PrintRowEnd = TheGrid.Rows - 1
    'PAGE LAYOUT OPERATIONS ...
    'If a page range is provided, adjust the row & column print range.
    'Position to the first row of the first page.  Note: account for 5 header lines.
    If frmPrintDialog.CMDialog1.FromPage <> 1 Then PrintRowStart = (Val(frmPrintDialog.txtPrintLinesPerPage) - 5) * (Val(frmPrintDialog.CMDialog1.FromPage) - 1)
    'Position to the last row of the last page.  Note: account for 5 header lines.
    If frmPrintDialog.CMDialog1.ToPage <> frmPrintDialog.CMDialog1.Max Then PrintRowEnd = ((Val(frmPrintDialog.txtPrintLinesPerPage) - 5) * Val(frmPrintDialog.CMDialog1.ToPage)) - 1
    'Determine what, if anything, to do about selected (highlighted) cells.
    GetSelectedRowsAndCols TheGrid
    Response% = Print_IfSelectedCells(TheGrid)
    If Response% = IDCANCEL Then GoTo Print_WrapUp
    'Determine column positions on printed page.
    Result% = Print_SetColPositions(TheGrid)
    If Not Result Then
        'Function was unable to set print columns. Notify user and exit.
        msg = "Unable to set column positions on printed page.  Try another font setting."
        MsgBox msg, MB_ICONSTOP, Me.Caption & " Print"
        GoTo Print_WrapUp
    End If
    'Determine if columns will be truncated based on current printer
    'and font selections, and if so, what the user wants to do about it.
    ColsTruncated% = Print_ColsTruncated()
    'If ColsTruncated% < 0 Then Beep
    If ColsTruncated% > 0 Then
        If frmPrintDialog.chk3dAutoScale.Value Then
            'Perform Auto Scaling of font size as requested in print dialog.
            Print_AutoScaleFontSize TheGrid
        Else
            'Do this when Auto Scaling is not invoked.
            'Construct message.
            If ColsTruncated% = 1 Then
                msg = "WARNING!  The last print column will be truncated."
            Else
                msg = "WARNING! The last " & ColsTruncated% & " print columns will be truncated!"
            End If
            msg = msg & "  CONTINUE?"
            msg = msg & NL & NL & "Suggestion:  Change your printer or font settings in order to fit more columns of data on a page."
            'Display message box
            Beep
            Response% = MsgBox(msg, MB_OKCANCEL + MB_ICONEXCLAMATION, Me.Caption & " Print")
            If Response% = IDCANCEL Then GoTo Print_WrapUp
            'If OK, then reset the ending print column.
            PrintColEnd = PrintColEnd - ColsTruncated%
        End If
    ElseIf ColsTruncated% = -1 Then: MsgBox "Error: Printer ScaleMode is not pixels!", MB_ICONSTOP, (Me.Caption & " Print")
    ElseIf ColsTruncated% = -2 Then: MsgBox "Error: Column(s) do not fit on printed page!" & NL & NL & "Suggestion: Change printer/font properties", MB_ICONSTOP, (Me.Caption & " Print")
    ElseIf ColsTruncated% = -3 Then: MsgBox "Error: Unknown, but suspect that ColPositions() are not set!", MB_ICONSTOP, (Me.Caption & " Print")
    Else
        'All columns fit!  Nothing to do.
    End If
    'START PRINTING ...
    'Print header on initial page.
    'Set total number of pages at beginning of print job.
    frmPrintDialog.lblPagesData.Caption = Str$(Print_PageCount(TheGrid))
    Print_DataGrid_Header TheGrid, LeftMargin%
    Printer.Print Tab(LeftMargin%);
    'Print rows of data in DataGrid
    'Save original bookmark
    Dim OrigAddItemBookmark As Variant
    OrigAddItemBookmark = TheGrid.Bookmark
    For r = PrintRowStart To PrintRowEnd        'For all print rows.
        TheGrid.Bookmark = TheGrid.AddItemBookmark(r)
        For c = PrintColStart To PrintColEnd    'For all print columns.
            'Find out which DISPLAY column C refers to.
            For i = 0 To TheGrid.Cols - 1
               If TheGrid.Columns(i).TagVariant = c Then Exit For
            Next
            Printer.CurrentX = ColPosition(c) 'Position to column c on printed page.
            'Print Outline around cell if requested by user in print dialog box.
            If frmPrintDialog.chk3dCellOutlines.Value Then Print_CellOutline c
            If TheGrid.Columns(i).Text = "" Then 'Do this if there is no text in cell to print.
                If c = PrintColEnd Then         'Do this if c is the last column.
                    'Goto next line
                    Printer.Print
                    If Print_StartNewPage(TheGrid) Then
                        'Save Font Info for MS Bug workaround (NewPage clears Font info)
                        SaveFontInfo
                        Printer.NewPage
                        ResetFontInfo
                        Print_DataGrid_Header TheGrid, LeftMargin%
                    End If
                    Printer.Print Tab(LeftMargin%);
                Else
                    'Do Nothing
                End If
            Else    'Print DataGrid cell text
                If c = PrintColEnd Then    'Print text & goto next line
                'MsgBox "C=" & Str(C) & ", PrintColEnd=" & Str(PrintColEnd)
                    Printer.Print Format(TheGrid.Columns(i).Text, TheGrid.Columns(i).NumberFormat);
                    If Print_StartNewPage(TheGrid) Then
                        'Save Font Info for MS Bug workaround (NewPage clears Font info)
                        SaveFontInfo
                        Printer.NewPage
                        ResetFontInfo
                        Print_DataGrid_Header TheGrid, LeftMargin%
                    End If
                    Printer.Print Tab(LeftMargin%);
                Else    'Print text
                    Printer.Print Format(TheGrid.Columns(i).Text, TheGrid.Columns(i).NumberFormat);
                End If
            End If
        Next c
    Next r
    Printer.Print
'    Printer.NewPage
    Printer.EndDoc
    'Reset to original grid row
    TheGrid.Bookmark = OrigAddItemBookmark
    
Print_WrapUp:
    'Reset Printer.ScaleMode to original setting
    Printer.ScaleMode = PrinterMode%
    'Reset the DataGrid's Visibility
    TheGrid.Visible = OrigGridVisible%

Print_DataGrid_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
Print_DataGrid_Error:
   MsgBox "Print_DataGrid_Error: " & Err.Description
   GoTo Print_DataGrid_Resume
   
End Sub

Public Sub SetToPrintColumnWidths(TheGrid As SSDBGrid)

    Dim c As Integer

    For c = 0 To (TheGrid.Cols - 1) Step 1
        'Find out which DISPLAY column C refers to.
        For i = 0 To TheGrid.Cols - 1
           If TheGrid.Columns(i).TagVariant = c Then
              TheGrid.Columns(i).Width = ColWidths(PrintCol, c)
              Exit For
           End If
        Next i
        'TheGrid.Columns(i).Width = ColWidths(PrintCol, C)
    Next c

End Sub

Public Sub SetToScreenColumnWidths(TheGrid As SSDBGrid)

    Dim c As Integer

    For c = 0 To (TheGrid.Cols - 1) Step 1
        'Find out which DISPLAY column C refers to.
        For i = 0 To TheGrid.Cols - 1
           If TheGrid.Columns(i).TagVariant = c Then
              TheGrid.Columns(i).Width = ColWidths(ScreenCol, c)
              Exit For
           End If
        Next i
        'TheGrid.Columns(i).Width = ColWidths(ScreenCol, C)
    Next c

End Sub

Public Sub Print_AutoScaleFontSize(TheGrid As SSDBGrid)
    
    On Error Resume Next
    Dim OrigFontSize, NewFontSize As Single
    Dim OrigFontName As String
    Dim ColsTruncated, Result As Integer

    ColsTruncated = 1  'Any integer value greater than 0
    OrigFontName = Printer.FontName  'Record original font name
    OrigFontSize = Printer.FontSize  'Record original font size
    NewFontSize = OrigFontSize      'Initialize variable
    Do Until ColsTruncated = 0 Or NewFontSize <= 0
        NewFontSize = NewFontSize - 0.5
        'Reset Printer object's FontSize
        Printer.FontSize = NewFontSize
        If NewFontSize < 8 And OrigFontSize >= 8 Then   'Refer to VB Language Reference
            Printer.FontName = OrigFontName
            Printer.FontSize = NewFontSize
        End If
        Result = Print_SetColPositions(TheGrid)
        'If unable to set column positions with new font size ...
        If Not Result Then
            Printer.FontSize = OrigFontSize
            Exit Do
        End If
        'If able to set column positions ...
        ColsTruncated = Print_ColsTruncated()
    Loop

    'Record resulting font size in print dialog box.
    frmPrintDialog.CMDialog1.FontSize = NewFontSize

    'Redo PageCount
    frmPrintDialog.lblPagesData.Caption = Str$(Print_PageCount(TheGrid))

End Sub

Public Sub Print_CellOutline(c As Variant)
    
    'The routine prints a outline (box) around a printed datagrid cell.

    'Input parameters:
    '   c: the grid column in which the outline is to be placed.
    
    Dim TempX, TempY, TempRowHeight As Single
    'First, record current x and y coordinates.
    TempX = Printer.CurrentX
    TempY = Printer.CurrentY
    'Determine height of a printed row.
    Printer.Print
    TempRowHeight = Printer.CurrentY
    TempRowHeight = TempRowHeight - TempY
    Printer.CurrentY = TempY
    'Print a box beginning at the top left corner of the cell extending to the lower right corner of the cell,
    'but first adjust the y-scale positions by -15% of the row height and the x-scale position by 2 pixels for
    'better appearance.
    Printer.Line Step(0, (0 - 0.15 * TempRowHeight))-(ColPosition(c + 1), (TempY + 0.85 * TempRowHeight)), , B
    'Reset the printer's x & y coordinates.
    Printer.CurrentX = TempX
    Printer.CurrentY = TempY

End Sub

Public Function Print_ColsTruncated() As Integer
    'This function will return the number of columns
    'to be printed which cannot fit on the printed page.
    'The number of truncated columns is counted from
    'right to left.  NOTE:  The array ColPositions must
    'be filled prior to calling this function.
    'See: Print_SetColPositions

    'The function will return:
    '    # of columns that would be truncated (not fit on printed page), or
    '    0 if all columns fit, or
    '   -1 if the printer's ScaleMode is not set to pixels, or
    '   -2 if the number of truncated columns is >= # of print columns, or
    '   -3 for any other error.

    'Note:  1) Printer measurements are assumed to be pixels.
    '       2) ColPosition(n) measurements are in pixels.

    On Error GoTo Print_ColsTruncated_Err

    Dim c, Count As Integer

    'CHECK FOR ERROR CONDITION -1
    If Printer.ScaleMode <> 3 Then  'Pixel = 3
        Print_ColsTruncated = -1
        Exit Function
    End If

    'Determine number of truncated columns
    Count = 0   'Initialize Truncated Column Counter
    For c = PrintColEnd To PrintColStart Step -1
        If ColPosition(c + 1) > Printer.ScaleWidth Then Count = Count + 1
    Next

    'CHECK FOR ERROR CONDITION -2
    If Count >= (PrintColEnd - PrintColStart + 1) Then
        Print_ColsTruncated = -2
        Exit Function
    End If
    
    'Return number of columns which would be truncated.
    Print_ColsTruncated = Count
    Exit Function

Print_ColsTruncated_Err:
    Resume Print_ColsTruncated_Resume

Print_ColsTruncated_Resume:
    Print_ColsTruncated = -3

End Function

Public Sub Print_DataGrid_Header(TheGrid As SSDBGrid, LeftMargin As Integer)

    On Error GoTo Print_Data_Grid_Header_Error
    
    Dim c As Integer, TempString As String, OrigFontSize As Single
    Dim PageCurrentX
    'Initialize variables.
    OrigFontSize = Printer.FontSize

    'Print header
    Printer.FontBold = True
    
    'FIRST LINE OF HEADER
    Printer.Print    'Blank line
    'SECOND LINE ON HEADER...
    'Print datetime of query, 20% smaller than other text.
    'Redo PageCount
    Printer.FontSize = OrigFontSize / 1.2
    Printer.Print Tab(LeftMargin); ""; TheGrid.Caption;
    Printer.FontSize = OrigFontSize
    'Center caption on page, 20% larger than other text.
    Printer.FontSize = OrigFontSize * 1.2
    Printer.CurrentX = (Printer.ScaleWidth / 2.7) - (Printer.TextWidth(TheGrid.Caption) / 2)
    'Print caption.
    Printer.Print Trim$(Me.Caption);
    Printer.FontSize = OrigFontSize
    'Right justify page number, 20% smaller than other text.
    Printer.FontSize = OrigFontSize / 1.2
    TempString = "Page " & Printer.Page & " of " & Trim$(frmPrintDialog.lblPagesData.Caption)
    'Pages and Cols info is printed onto the next page when in Landscape (on some dot-matrix
    'printers) so keep it back from right edge more than in Portrait orientation.
    If Printer.Orientation = vbPRORLandscape Then
       Printer.CurrentX = Printer.ScaleWidth - (Printer.TextWidth(TempString) * 2.5)
    Else
       Printer.CurrentX = Printer.ScaleWidth - Printer.TextWidth(TempString)
    End If
    PageCurrentX = Printer.CurrentX
    Printer.Print TempString;
    'THIRD LINE OF HEADER
    'Print datetime of printing.
    Printer.Print Tab(LeftMargin); "Printed:  "; Format$(Now, "c");
    'Print "Rows x - y" or "Cols x - y" if a subset of the total rows or columns are printed.
    'Set initial row & column print ranges to include all rows and columns.
    TempString = ""
    If PrintColStart <> 0 Or PrintColEnd <> TheGrid.Cols - 1 Then TempString = "Cols " & PrintColStart + 1 & " - " & PrintColEnd + 1 'Print "Cols x - y"
    If PrintRowStart <> 0 Or PrintRowEnd <> TheGrid.Rows - 1 Then  'Print "Rows x - y"
        If TempString = "" Then
            TempString = "Rows " & PrintRowStart + 1 & " - " & PrintRowEnd + 1
        Else
            TempString = TempString & "; Rows " & PrintRowStart + 1 & " - " & PrintRowEnd + 1
        End If
    End If
    'Right justify and print row/col string same as Page number info.
    Printer.CurrentX = PageCurrentX
    Printer.Print TempString;
    Printer.FontSize = OrigFontSize
    'FOURTH LINE OF HEADER
    Printer.Print   'Blank line
    'FIFTH LINE OF HEADER, print column headings
    Printer.Print Tab(LeftMargin);
'MsgBox "PrintColStart=" & Str$(PrintColStart) & ", PrintColEnd=" & Str$(PrintColEnd)
    For c = PrintColStart To PrintColEnd
        'Find out which DISPLAY column C refers to and save it in i.
        For i = 0 To TheGrid.Cols - 1
           If TheGrid.Columns(i).TagVariant = c Then Exit For
        Next
        Printer.CurrentX = ColPosition(c)
        If TheGrid.Columns(i).Caption = "" Then
            If c = PrintColEnd Then    'Print field name & goto next line
                Printer.Print TheGrid.Columns(i);
                Printer.Print Tab(LeftMargin);
            Else    'Print field name
                Printer.Print TheGrid.Columns(i);
            End If
        Else    'Print grid column heading name
            If c = PrintColEnd Then    'Print heading & goto next line
                Printer.Print TheGrid.Columns(i).Caption;
                Printer.Print Tab(LeftMargin);
            Else    'Print column heading
                Printer.Print TheGrid.Columns(i).Caption;
            End If
        End If
    Next
    Printer.FontBold = False
    
Exit Sub

Print_Data_Grid_Header_Error:
   MsgBox "Print_Data_Grid_Header_Error: " & Err.Description
   
End Sub

Public Function Print_IfSelectedCells(TheGrid As SSDBGrid) As Integer
    'This function will determine if the user has selected
    '(highlighted) rows or columns in the DataGrid.  If so,
    'the function will prompt the user as to whether or not
    'to print only the selected rows/columns or to ignore
    'the selection.  If the user indicates that only the
    'selected rows/columns are to be printed, then this
    'function will reset the PrintColStart, PrintColEnd,
    'PrintRowStart, and PrintRowEnd form level variables.

    'The function will return the user's response to the
    'MsgBox, either: IDYES (6), IDNO (7), or IDCANCEL (2).
    'If no cells are selected the function will return a
    'value of FALSE (0).

    Dim Response%

'paultest - not showing msg here for selected rows/cols
    If CLng(frmPrintDialog.txtFirstRow.Text) > 1 Or CLng(frmPrintDialog.txtLastRow.Text) < TheGrid.Rows Or CLng(frmPrintDialog.txtFirstCol.Text) > 1 Or CLng(frmPrintDialog.txtLastCol.Text) < TheGrid.Cols Then
        'The user has specified that a limited range of data is to be printed.
        PrintRowStart = CLng(frmPrintDialog.txtFirstRow.Text) - 1
        PrintRowEnd = CLng(frmPrintDialog.txtLastRow.Text) - 1
        PrintColStart = CLng(frmPrintDialog.txtFirstCol.Text) - 1
        PrintColEnd = CLng(frmPrintDialog.txtLastCol.Text) - 1
        Print_IfSelectedCells = IDYES
    ElseIf PrintSelColStart > -1 Or PrintSelRowStart > -1 Then
        'Tailor message based on whether columns or rows are selected.
 '       If PrintSelColStart > -1 Then
 '           msg = "Do you wish to print only the selected columns?"
 '       Else
 '           msg = "Do you wish to print only the selected rows?"
 '       End If
        Response% = IDYES 'MsgBox(msg, MB_YESNOCANCEL + MB_ICONQUESTION, Me.Caption & " Print")
        If Response% = IDYES Then
            'Reset range of print rows or columns.
            If PrintSelColStart > -1 Then
                PrintColStart = PrintSelColStart
                PrintColEnd = PrintSelColEnd
            Else
                PrintRowStart = PrintSelRowStart
                PrintRowEnd = PrintSelRowEnd
            End If
        End If
        Print_IfSelectedCells = Response%
    Else
        'Do this when nothing is selected.
        Print_IfSelectedCells = False
    End If

End Function
Public Function Print_LinesPerPage() As Integer

    'This function determines how many rows can be printed on a page (within margins).
    'The number of available print lines on a page is a function of the Printer.ScaleHeight,
    'the Printer.FontName, the Printer.FontSize, and the spacing between printed lines.
    'Return value is the maximum rows per printed page.  Should an error occur,
    'the function returns the negative of the VB error number.

    On Error GoTo Print_LinesPerPage_Err

    Dim TempHeight, NewHeight As Single

    'Get largest Printer.TextHeight of sample group and use as row height.
    TempHeight = Printer.TextHeight("test_ing123")
    NewHeight = Printer.TextHeight("BNB_BNBBNB_BN")
    If NewHeight > TempHeight Then TempHeight = NewHeight
    NewHeight = Printer.TextHeight("000000000001111")
    If NewHeight > TempHeight Then TempHeight = NewHeight

    'Note that line spacing between printed rows is accounted for in Printer.TextHeight()
    Print_LinesPerPage = (Printer.ScaleHeight / TempHeight)
 
Exit Function

Print_LinesPerPage_Err:
    LastErr = Err
    Resume Print_LinesPerPage_Resume

Print_LinesPerPage_Resume:
    Print_LinesPerPage = -LastErr

End Function

Public Function Print_PageCount(TheGrid As SSDBGrid) As Integer
   
    On Error GoTo Print_PageCount_Error
    Dim LinesPerPage As Integer
    Dim TempVal
    LinesPerPage = Print_LinesPerPage()
    
    If LinesPerPage > 0 Then
       TempVal = (CInt(frmPrintDialog.txtLastRow.Text) / (LinesPerPage - Val(frmPrintDialog.txtHeaderLines.Text)))
       If TempVal < 1 Then
          TempVal = 1
       ElseIf (TempVal - CInt(TempVal)) > 0 Then
          TempVal = CInt(TempVal) + 1
       Else
          TempVal = CInt(TempVal)
       End If
       Print_PageCount = TempVal
    Else
       Print_PageCount = 0
    End If
    Exit Function

Print_PageCount_Error:
    X% = IsError("Print_PageCount")
    Resume Next

End Function

Public Function Print_ScalingFactorX(TheGrid As SSDBGrid) As Single
    'Need to work on this function.

    Dim OrigFontName As String
    Dim OrigFontSize, TempFactor, NewFactor As Single
    'Record Form's Current FontName & FontSize
        OrigFontName = Me.FontName
        OrigFontSize = Me.FontSize
    'Set the Form's FontName & FontSize to that of the DataGrid.
    'This is necessary because TextWidth, used below, is the Form's Method
    'and its smart to make sure we are not comparing apples and oranges.
        Me.FontName = TheGrid.Font
        Me.FontSize = TheGrid.Font.Size
    'Determine Screen:Printer Scaling Factor for the X-Axis
    TempFactor = (Printer.TextWidth("test_result") * Printer.TwipsPerPixelX) / Me.TextWidth("test_result")
    NewFactor = (Printer.TextWidth("UUT_SERIAL_NO") * Printer.TwipsPerPixelX) / Me.TextWidth("UUT_SERIAL_NO")
    If NewFactor > TempFactor Then TempFactor = NewFactor
    NewFactor = (Printer.TextWidth("000000000001385") * Printer.TwipsPerPixelX) / Me.TextWidth("000000000001385")
    If NewFactor > TempFactor Then TempFactor = NewFactor
    'Leave a message box here until you get it right.
    'MsgBox "ScalingFactorX = " & TempFactor

    Print_ScalingFactorX = TempFactor
    'Reset the Forms Font properties to original values.
    Me.Font = OrigFontName
    Me.FontSize = OrigFontSize
    
End Function

Public Function Print_ScalingFactorY(TheGrid As SSDBGrid) As Single
    'Need to work on this function.

    Dim OrigFontName As String
    Dim OrigFontSize, TempFactor, NewFactor As Single

    'Record Form's Current FontName & FontSize
        OrigFontName = Me.Font
        OrigFontSize = Me.Font.Size
    'Set the Form's FontName & FontSize to that of the DataGrid.
    'This is necessary because TextHeight, used below, is the Form's Method
    'and its smart to make sure we are not comparing apples and oranges.
        Me.Font = TheGrid.Font
        Me.Font.Size = TheGrid.Font.Size

    'Determine Screen:Printer Scaling Factor for the X-Axis
    TempFactor = (Printer.TextHeight("test_result") * Printer.TwipsPerPixelX) / Me.TextHeight("test_result")
    NewFactor = (Printer.TextHeight("UUT_SERIAL_NO") * Printer.TwipsPerPixelX) / Me.TextHeight("UUT_SERIAL_NO")
    If NewFactor > TempFactor Then TempFactor = NewFactor
    NewFactor = (Printer.TextHeight("000000000001385") * Printer.TwipsPerPixelX) / Me.TextHeight("000000000001385")
    If NewFactor > TempFactor Then TempFactor = NewFactor

    'Leave a message box here until you get it right.
    'MsgBox "ScalingFactorX = " & TempFactor

    Print_ScalingFactorY = TempFactor

    'Reset the Forms Font properties to original values.
    Me.Font = OrigFontName
    Me.Font.Size = OrigFontSize

End Function


Public Function Print_SetColPositions(TheGrid As SSDBGrid) As Integer

    'This routine redimensions the form level variable ColPosition()
    'to the number of printed grid columns + 1 and fills it with the
    'X-coordinate position of each column.  The X-coordinate position
    'being the upper left corner (equivalent to VB's Top property) of
    'the column.  The array's last value records to end of the last
    'column (the theoretical start of the Last + 1 column).

    'This function will return the following values:
        '*  True if the function successfully sets column positions.
        '*  False if the function's operation is unsuccessful.

    On Error GoTo Print_SetColPositions_Err
    Dim i, j As Integer
    Dim ScalingFactorX As Single
    ReDim ColPosition(PrintColEnd + 1)
    'Simplified Version:  Use the DataGrid's ColWidth property to determine
    ' printer column widths.  This, of course, is subject to error if the
    ' grid columns truncate the data.  This can result from either: 1) the
    ' user resizing the grid columns; or 2) the fact that SizeGridCells
    ' sizes grid cells based on only the visible rows.
    
    'Determine Screen:Printer Scaling Factor
    ScalingFactorX = Print_ScalingFactorX(TheGrid)

    'Note:  ColPositions are in pixels.
    'Note:  Assumes Printer.ScaleMode = 3 (pixels)
    'Set left most column positions, where columns to the left of the
    'starting print column are set to the page's left edge.
    For i = 0 To PrintColStart
        ColPosition(PrintColStart) = Printer.ScaleLeft
    Next i
    'Set column positions.
    For i = (PrintColStart + 1) To (PrintColEnd + 1) Step 1
        'Find out which DISPLAY column i refers to.
        For j = 0 To TheGrid.Cols - 1
           If TheGrid.Columns(j).TagVariant = i - 1 Then
             ColPosition(i) = ColPosition(i - 1) + ScalingFactorX * (TheGrid.Columns(j).Width / Printer.TwipsPerPixelX)
             Exit For
           End If
        Next
        'ColPosition(i) = ColPosition(j - 1) + ScalingFactorX * (TheGrid.Columns(j - 1).Width / Printer.TwipsPerPixelX)
        'Leave message boxes until you get it right.
        'MsgBox "ColPosition(" & i & ") = " & ColPosition(i) & " pixels"
    Next i

    Print_SetColPositions = True
    
Exit Function

Print_SetColPositions_Err:
    MsgBox "Error in Print_SetColPositions " & Err.Description
    Resume Print_SetColPositions_Resume

Print_SetColPositions_Resume:
    Print_SetColPositions = False

End Function

Function Print_StartNewPage(TheGrid As SSDBGrid) As Integer
  
    'This function determines whether or not the next row to be printed
    'will fit on the page (within margins).  If so the function returns
    'True (-1), if not the function returns False (0).  Should an error occur,
    'the function returns the error number.

    On Error GoTo Print_StartNewPage_Err
    
    'If currently on the last row to be printed.
    If TheGrid.AddItemRowIndex(TheGrid.Bookmark) = PrintRowEnd Then
        Print_StartNewPage = False
        Exit Function
    End If
     
    Dim LastErr As Long
    'Find first non-blank cell.
    For i = 0 To TheGrid.Cols - 1
       If TheGrid.Columns(i).Text <> "" Then Exit For
    Next i
    If (Printer.CurrentY + Printer.TextHeight(TheGrid.Columns(i).Text)) > (Printer.ScaleHeight - (Val(frmPrintDialog.txtHeaderLines.Text) * Printer.TextHeight(TheGrid.Columns(i).Text))) Then
        Print_StartNewPage = True
    Else
        Print_StartNewPage = False
    End If

Exit Function

Print_StartNewPage_Err:
    LastErr = Err
    MsgBox "Print_StartNewPage Error: " & Err.Description
    Resume Print_StartNewPage_Resume

Print_StartNewPage_Resume:
    Print_StartNewPage = LastErr

End Function

Sub RecordScreenColumnWidths(TheGrid As SSDBGrid)

    Dim c As Integer

    For c = 0 To (TheGrid.Cols - 1)
        'Find out which DISPLAY column C refers to.
        For i = 0 To TheGrid.Cols - 1
           If TheGrid.Columns(i).TagVariant = c Then
             ColWidths(ScreenCol, c) = TheGrid.Columns(i).Width
             Exit For
           End If
        Next i
        'ColWidths(ScreenCol, C) = TheGrid.Columns(i).Width
    Next c

End Sub


Public Sub GetSelectedRowsAndCols(TheGrid As SSDBGrid)

     'Find range of selected rows using SelBookmarks collection.
     Dim j As Integer
     If TheGrid.SelBookmarks.Count > 0 Then
       TheGrid.Visible = False
       'Find selected ROWS
       j = TheGrid.SelBookmarks.Count
       TheGrid.Bookmark = TheGrid.SelBookmarks(0)
       PrintSelRowStart = TheGrid.AddItemRowIndex(TheGrid.Bookmark)
       'MsgBox frmPrintDialog.txtFirstRow.Text
       TheGrid.Bookmark = TheGrid.SelBookmarks(j - 1)
       PrintSelRowEnd = TheGrid.AddItemRowIndex(TheGrid.Bookmark)
       'MsgBox frmPrintDialog.txtLastRow.Text
       TheGrid.Visible = True
     Else
       PrintSelRowStart = 0
       PrintSelRowEnd = TheGrid.Rows - 1
     End If
     'Find selected COLS
     Dim FirstCol, LastCol As Integer
     FirstCol = -1
     LastCol = -1
     For i = 0 To TheGrid.Cols - 1
        For j = 0 To TheGrid.Cols - 1
          If TheGrid.Columns(j).TagVariant = i Then
             If TheGrid.Columns(j).Selected Then
                If FirstCol = -1 Then FirstCol = i
                LastCol = i
             End If
          End If
        Next j
     Next i
     If FirstCol > -1 Then
        PrintSelColStart = FirstCol
        PrintSelColEnd = LastCol
     Else
        PrintSelColStart = 0
        PrintSelColEnd = TheGrid.Cols - 1
     End If
     
End Sub

Public Sub LoadGridRows()

    Dim j As Long
    
    ReDim MaxText(datListing.Recordset.Fields.Count - 1)

    For i = 0 To datListing.Recordset.Fields.Count - 1
       grddwListing.Columns(i).Caption = datListing.Recordset.Fields(i).Name
       'Initialize col width
       grddwListing.Columns(i).Width = 1.5 * Me.TextWidth(grddwListing.Columns(i).Caption)
    Next i
   ' grddwListing.Redraw = False
    grddwListing.Visible = False
    'Initialize grid
    For i = 0 To datListing.Recordset.RecordCount - 1
       grddwListing.AddItem ""
    Next i
    'Load Data
    datListing.Recordset.MoveFirst
    For j = 0 To datListing.Recordset.RecordCount - 1
       grddwListing.Bookmark = grddwListing.AddItemBookmark(j)
       For i = 0 To datListing.Recordset.Fields.Count - 1
         If IsNull(datListing.Recordset.Fields(i).Value) Then
           'Do nothing
         Else
            grddwListing.Columns(i).Text = datListing.Recordset.Fields(i).Value
            'Save max length text string for each column.
            If Len(MaxText(i)) < Len(grddwListing.Columns(i).Text) Then
               MaxText(i) = grddwListing.Columns(i).Text
            End If
            'This is done in ResizeGridCols after call to this Subroutine.
            ''Resize col width if too small to fit data
            'If Me.TextWidth(grddwListing.Columns(i).Text) > grddwListing.Columns(i).Width Then
            '   grddwListing.Columns(i).Width = 1.2 * Me.TextWidth(grddwListing.Columns(i).Text)
            'End If
         End If
       Next i
       datListing.Recordset.MoveNext
    Next j
    'Move the row ID column to end of list (users will never need this
    'and it would be confused with conf#). It should always be at end of list anyway
    'because that's the way it is in the table  (bnb1.mdb file)
    For i = 0 To datListing.Recordset.Fields.Count - 1
      If grddwListing.Columns(i).Caption = "ID" Then
        grddwListing.Columns(i).Position = datListing.Recordset.Fields.Count - 1
        Exit For
      End If
    Next i
    grddwListing.MoveFirst
    grddwListing.Redraw = True
    grddwListing.Visible = True

End Sub

Public Sub ReorderGridColumns()

    Dim xx, j As Integer
    Screen.MousePointer = HOURGLASS

    For i = 0 To frmListDialog.lstColumnOrder.ListCount - 1
      For j = 0 To frmListDialog.lstColumnOrder.ListCount - 1
        'MsgBox Str(CallingGrid.Columns(xx).Position)
        If frmListDialog.lstColumnOrder.List(i) = CallingGrid.Columns(j).Caption Then
           CallingGrid.Columns(j).Position = i  '+ 1
           Exit For
        End If
      Next j
    Next i

Screen.MousePointer = DEFAULT

End Sub

Public Sub SetTagVariantProp()
  
  Dim j As Integer
  For i = 0 To grddwListing.Cols - 1
    For j = 0 To grddwListing.Cols - 1
      If lstColumnOrderSave.List(i) = grddwListing.Columns(j).Caption Then
         grddwListing.Columns(j).TagVariant = i
         Exit For
      End If
    Next j
  Next i
  
End Sub

Public Sub ResetFontInfo()

  'Workaround for MS Bug Q153125 - Printer Object Font Info is Lost After Printing.
  'MS says font info is lost after a Printer.Print or Printer.NewPage statement, but I have only seen
  'it occur in dot-matrix printer after Printer.Newpage. Laser (HP 4 si) works fine without workaround.
  
  'Printer.Print ""
  Printer.Font = ""
  Printer.Font = v_FontName
  Printer.FontSize = v_FontSize
  Printer.FontBold = v_FontBold
  Printer.FontItalic = v_FontItalic
  Printer.FontUnderline = v_FontUnderline
  
End Sub

Public Sub SaveFontInfo()

  'Workaround for MS Bug Q153125 - Printer Object Font Info is Lost After Printing.
  'MS says font info is lost after a Printer.Print or Printer.NewPage statement, but I have only seen
  'it occur in dot-matrix printer after Printer.Newpage. Laser (HP 4 si) works fine without workaround.
  
  v_FontName = Printer.Font
  v_FontSize = Printer.FontSize
  v_FontBold = Printer.FontBold
  v_FontItalic = Printer.FontItalic
  v_FontUnderline = Printer.FontUnderline
  
End Sub





Public Sub FormatColumns()
    'Set Column Formats.
    For i = 0 To datListing.Recordset.Fields.Count - 1
      If datListing.Recordset.Fields(i).Type = dbDate Then
        For j = 0 To datListing.Recordset.Fields.Count - 1
           If datListing.Recordset.Fields(i).Name = grddwListing.Columns(i).Caption Then
             grddwListing.Columns(i).NumberFormat = txtDateFormat.Text
             Exit For
           End If
        Next j
      ElseIf datListing.Recordset.Fields(i).Type = dbCurrency Then
        For j = 0 To datListing.Recordset.Fields.Count - 1
           If datListing.Recordset.Fields(i).Name = grddwListing.Columns(i).Caption Then
             grddwListing.Columns(i).Alignment = 1 'Right Justify
             grddwListing.Columns(i).NumberFormat = CURRENCYFORMAT
             Exit For
           End If
        Next j
     End If
    Next i
End Sub


Public Sub ResizeGridCols(TheGrid As SSDBGrid)
    For c = 0 To (TheGrid.Cols - 1)
       Font.Size = TheGrid.Font.Size
       If Me.TextWidth(MaxText(c)) > Me.TextWidth(TheGrid.Columns(c).Caption) Then
          TheGrid.Columns(c).Width = 1.5 * Me.TextWidth(MaxText(c))
       Else
          TheGrid.Columns(c).Width = 1.5 * Me.TextWidth(TheGrid.Columns(c).Caption)
       End If
    Next c
End Sub
