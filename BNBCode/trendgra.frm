VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{827E9F53-96A4-11CF-823E-000021570103}#1.0#0"; "GRAPHS32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmTrendsGraph 
   Caption         =   "Trends Report"
   ClientHeight    =   4935
   ClientLeft      =   1635
   ClientTop       =   1995
   ClientWidth     =   8025
   HelpContextID   =   121
   LinkTopic       =   "Form1"
   MDIChild        =   -1  'True
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4935
   ScaleWidth      =   8025
   Begin VB.CommandButton cmdOptions 
      Caption         =   "&Options"
      Height          =   375
      Left            =   5040
      TabIndex        =   4
      Top             =   4260
      Width           =   915
   End
   Begin VB.CommandButton cmdSave 
      Caption         =   "Sa&ve"
      Height          =   375
      Left            =   3960
      TabIndex        =   3
      Top             =   4260
      Width           =   900
   End
   Begin VB.CommandButton cmdPrint 
      Caption         =   "&Print"
      Height          =   375
      Left            =   1200
      TabIndex        =   2
      Top             =   4260
      Width           =   900
   End
   Begin VB.CommandButton cmdClose 
      Caption         =   "&Close"
      Height          =   375
      Left            =   120
      TabIndex        =   1
      Top             =   4260
      Width           =   900
   End
   Begin VB.ListBox lstSorter 
      Height          =   450
      ItemData        =   "TRENDGRA.frx":0000
      Left            =   6000
      List            =   "TRENDGRA.frx":0007
      TabIndex        =   6
      TabStop         =   0   'False
      Top             =   2040
      Visible         =   0   'False
      Width           =   1335
   End
   Begin VB.TextBox txtSQLStatement 
      Height          =   495
      Left            =   6000
      TabIndex        =   5
      TabStop         =   0   'False
      Tag             =   "Text"
      Text            =   "txtSQLStatement"
      Top             =   1440
      Visible         =   0   'False
      Width           =   1335
   End
   Begin VB.Data datTrends 
      Caption         =   "datTrends"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   300
      Left            =   6000
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   1020
      Visible         =   0   'False
      Width           =   1875
   End
   Begin Threed.SSPanel pnlMessage 
      Height          =   615
      Left            =   6000
      TabIndex        =   0
      Top             =   240
      Visible         =   0   'False
      Width           =   1515
      _Version        =   65536
      _ExtentX        =   2672
      _ExtentY        =   1085
      _StockProps     =   15
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
   End
   Begin Threed.SSPanel pnl3dCaption 
      Height          =   375
      Left            =   2280
      TabIndex        =   7
      Top             =   4260
      Width           =   1455
      _Version        =   65536
      _ExtentX        =   2566
      _ExtentY        =   661
      _StockProps     =   15
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
   End
   Begin GraphsLib.Graph graBarChart 
      Height          =   3495
      Left            =   480
      TabIndex        =   8
      TabStop         =   0   'False
      Top             =   240
      Width           =   4995
      _Version        =   327680
      _ExtentX        =   8811
      _ExtentY        =   6165
      _StockProps     =   96
      BorderStyle     =   1
      Background      =   "15~-1~-1~-1~-1~-1~-1"
      DataLabels      =   1
      GraphType       =   3
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   6000
      Top             =   2700
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
End
Attribute VB_Name = "frmTrendsGraph"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated, myFrequency, myThreshold As Integer
Dim ShownRows, TotalRows As Long
Dim myBy, myShow, myTable, DateRange As String
'Temp table names and Query string used for Res Fee calculations
Dim TableName1, TableName2, TempEXEC As String
Dim PopArray() As Variant
Dim NeedToUnload As Integer
Dim SAW As Long
Private Sub cmdClose_Click()
   Unload Me
End Sub

Private Sub cmdOptions_Click()
    
    'Display the toolbar.
    If graBarChart.Toolbar = 2 Then
        graBarChart.Toolbar = 0
    Else
        graBarChart.Toolbar = 3
    End If
    'Draw the chart.
    graBarChart.DrawMode = 2    'Draw

End Sub

Private Sub cmdPrint_Click()

    On Error GoTo cmdPrint_Click_Error
    Dim Response As Integer
'    Me.graBarChart.FontUse = 4
'    Me.graBarChart.FontSize = 100
'    Me.graBarChart.FontStyle = 2
'    cmd3dRefresh_Click

    Screen.MousePointer = HOURGLASS
    
    'Declare variables.
    Dim X, OrigPSM As Integer
    Dim OrigWidth, OrigHeight As Long   'The graphs original Width and Height prior to Auto Scale.

    'Initialize variables.
    OrigWidth = graBarChart.Width
    OrigHeight = graBarChart.Height

    'Set dialog box properties
    frmPrintDialog.txtCallingFormCaption.Text = Me.Caption
    'Enable/Disable ranges and options as appropriate.
    frmPrintDialog.fra3dRange.Enabled = False
    frmPrintDialog.chk3dCellOutlines.Enabled = False
    frmPrintDialog.chk3dAutoScale.Enabled = True
    frmPrintDialog.chk3dColor.Enabled = True
    frmPrintDialog.chk3dChartBorder.Enabled = True
    'Transfer control to dialog box
    Screen.MousePointer = DEFAULT
    frmPrintDialog.Show 1   'Modal
    'If the print dialog was unloaded or cancelled, then don't print and return form to normal.
    If Not FormLoaded(frmPrintDialog) Then GoTo cmdPrint_Click_Resume
    If frmPrintDialog.optCancelled.Value Then GoTo cmdPrint_Click_Resume
    'Resume after control returns from dialog box ...
    Screen.MousePointer = HOURGLASS
    'Disable/Enable ranges and options to their original state.
    frmPrintDialog.chk3dColor.Enabled = False
    frmPrintDialog.chk3dChartBorder.Enabled = False
    frmPrintDialog.fra3dRange.Enabled = True
    frmPrintDialog.chk3dCellOutlines.Enabled = True
    frmPrintDialog.chk3dAutoScale.Enabled = True
    'Display status message
    StatusMessage Me, "Print preparation, please wait ...", True
    'Set the charts print style
    graBarChart.PrintStyle = 0  'Monochrome w/out border
    If frmPrintDialog.chk3dColor Then graBarChart.PrintStyle = graBarChart.PrintStyle + 1
    If frmPrintDialog.chk3dChartBorder Then graBarChart.PrintStyle = graBarChart.PrintStyle + 2
    'If auto scale then hide the grid and size it to match the printed page.
    If frmPrintDialog.chk3dAutoScale And frmPrintDialog.chk3dColor Then
        'Need to print a Bitmap.  This has been demonstrated by trial and error.
        'Clear the chart.
        graBarChart.DrawMode = 0
        'Record the printer's current scale mode before we change it to Twips.
        OrigPSM = Printer.ScaleMode
        Printer.ScaleMode = 1   'Twips
        graBarChart.Width = Printer.ScaleWidth
        graBarChart.Height = Printer.ScaleHeight
        'Reset the printer's scalemode prior to printing.
        Printer.ScaleMode = OrigPSM
        'Produce a BitMap image of the chart.
        graBarChart.DrawMode = 3
        'Send the graph to the printer. The statement may translate it to monochrome first depending on the print style.
        graBarChart.DrawMode = 5
        'Return the chart to its original size and drawmode
        graBarChart.DrawMode = 0
        graBarChart.Width = OrigWidth
        graBarChart.Height = OrigHeight
        graBarChart.DrawMode = 2
    ElseIf frmPrintDialog.chk3dAutoScale Then   'Monochrome AutoScale
        'Record the printer's current scale mode before we change it to Twips.
        OrigPSM = Printer.ScaleMode
        Printer.ScaleMode = 1   'Twips
        graBarChart.Width = Printer.ScaleWidth
        graBarChart.Height = Printer.ScaleHeight
        'Reset the printer's scalemode prior to printing.
        Printer.ScaleMode = OrigPSM
        'Send the graph to the printer. The statement may translate it to monochrome first depending on the print style.
        graBarChart.DrawMode = 5
        'Return the chart to its original size
        graBarChart.Width = OrigWidth
        graBarChart.Height = OrigHeight
    Else
        'Send the graph to the printer. The statement may translate it to monochrome first depending on the print style.
        graBarChart.DrawMode = 5
    End If
    
cmdPrint_Click_Resume:
    'Cleanup...
    'Unload dialog box from memory
    'Remove status message
    StatusMessage Me, "", False
    Unload frmPrintDialog
    'Restore default mousepointer
    Screen.MousePointer = DEFAULT

Exit Sub

cmdPrint_Click_Error:
    'User pressed common dialog cancel button is Err 32755
    If Err <> 32755 Then
       X = IsError("cmdPrint_Click")   'If not intentional, display message.
    Else
       MsgBox Err.Description
    End If
    Resume cmdPrint_Click_Resume

End Sub

Private Sub cmdSave_Click()

    On Error GoTo cmdSave_Error

    Dim LastErr As Long

    'Set Common Dialog Font Properites
    CMDialog1.CancelError = True
    CMDialog1.DefaultExt = ".bmp"
    CMDialog1.Filter = "Bitmap (*.bmp) |*.bmp|MetaFile (*.wmf)|*.wmf|All files (*.*)|*.*"
    CMDialog1.FilterIndex = 1
    'Activate Save Dialog Box
    CMDialog1.ShowSave  'Action = 2
    'If a filename was provided in dialog, then save file to that name.
    If Trim$(CMDialog1.filename) <> "" Then
        Screen.MousePointer = HOURGLASS
        graBarChart.ImageFile = CMDialog1.filename
        If LCase$(CMDialog1.filename) Like "*bmp" Then
            'Save the displayed graph to the disk as a Bitmap (.bmp).
            graBarChart.DrawMode = 3
            graBarChart.DrawMode = 6
            graBarChart.DrawMode = 2
        Else    'Defaults to Metafile
            'Save the displayed graph to the disk as a Windows Metafile (.WMF).
            graBarChart.DrawMode = 6
        End If
    End If

cmdSave_Resume:
   cmdSave.SetFocus
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdSave_Error:
    'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
    If Err = cdlCancel Then
       'This will keep background screens from other applications
       'gaining focus mysteriously upon closure of common dialog.
       SAW = SetActiveWindow(mdiBNB.hwnd)
    Else
      MsgBox Err.Description
    End If
    Resume cmdSave_Resume
    
End Sub

Private Sub Form_Activate()
    
    On Error GoTo Form_Activate_Error
    
    'If this form is in the background (does not have focus) and the
    'Minimize button is clicked on this form that does not yet have the focus,
    'an endless loop of Minimizing and Activating will occur. The following
    'line prevents this interesting problem.
    If Me.WindowState = MINIMIZED Then Exit Sub

    'Set the data control the first time the form is activated.
    'Note: the first time the form is activated is like form load
    'except that the form load procedure may be followed by
    'additional code contained in a calling procedure.  This
    'has caused problems with error handling, and as such the
    'RecordSource.Refresh has been moved here.
    
    'The following IF statement is necessary to avoid creating more than 88
    'temp working tables (not that this is likely). But if a user
    'never turns off machine or exits BNB application, it could happen.
    If NeedToUnload Then
      'gMsg has been set in GetNextTableName()
      MsgBox gMsg, MB_ICONSTOP, "System"
      GoTo Form_Activate_Resume
    End If
         
    'Declare variables.
    Dim i As Integer

    'Initialize variables.
    TimesActivated = TimesActivated + 1

    'Perform the rest of this subroutine only if the is the first time the form is activated!
    If TimesActivated > 1 Then GoTo Form_Activate_Resume
        
    'Indicate delay.
    Screen.MousePointer = HOURGLASS

    graBarChart.GraphTitle = ""
    Me.Caption = "Trends Report"

    'Display status message
    StatusMessage Me, "Querying the database for Trends...", True
    'Set data control's record source equal to SQL statement.
    datTrends.RecordSource = txtSQLStatement.Text
    'Query the database.
    If Not GetDCRows(datTrends) Then GoTo Form_Activate_Resume
    'If myShow = "Property" Then
    '    'Display status message
    '    StatusMessage "Querying the database ...", True
    '    'Load the population data into the PopArray 2-D array.
    '    Call GetPopulations
    'End If
    'Plot the chart
    If Not PlotChart() Then GoTo Form_Activate_Resume
    'Let other pending events catch up.
'    StatusMessage "Allowing pending events to catch up ...", True
    For i = 1 To 5
        DoEvents
    Next
    Call Form_Resize
    graBarChart.Visible = True
    'Re-Enable command buttons disabled at start of form load.
    EnableCommandButtons Me
    StatusMessage Me, "", False
    
Form_Activate_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

Form_Activate_Error:
    Resume Form_Activate_Resume
 
End Sub

Private Sub Form_Load()

    On Error GoTo Form_Load_Error
    
    Screen.MousePointer = HOURGLASS

    DisableCommandButtons Me    'Re-Enabled after initial Activate

    Dim X As Integer
    Dim TempSQL As String
    NeedToUnload = False
    TempSQL = ""
    'Intialize form level variables.
    NL = Chr$(13) & Chr$(10)   'New Line of text.  Form level variable.
    TotalRows = 0
    ShownRows = 0
    'Hide the Graph for now
    graBarChart.Visible = False
    'Initialize the graph
    graBarChart.DataReset = 9   'All data
    graBarChart.GraphTitle = Me.Caption 'Left$(gCaption, 80)    'Set the chart's graph title.
    'Set data control's database connection properties
    datTrends.DatabaseName = gDatabaseName
    'Record dialog box settings pertaining to this form.
    Record_Dialog_Box_Settings
    If Trim(frmTrendsDialog.txtStartDate.Text) <> "" And Trim(frmTrendsDialog.txtEndDate.Text) <> "" Then
       If frmTrendsDialog.optBookings.Value = UNCHECKED Then
          TempSQL = " bbtbl.arrdate >= #" & Trim(frmTrendsDialog.txtStartDate.Text) & "# And bbtbl.arrdate <= #" & Trim(frmTrendsDialog.txtEndDate.Text) & "#"
       Else
          TempSQL = " guesttbl.datebkd >= #" & Trim(frmTrendsDialog.txtStartDate.Text) & "# And guesttbl.datebkd <= #" & Trim(frmTrendsDialog.txtEndDate.Text) & "#"
       End If
       DateRange = frmTrendsDialog.txtStartDate.Text & " - " & frmTrendsDialog.txtEndDate.Text
    ElseIf Trim(frmTrendsDialog.txtStartDate.Text) <> "" Then
       If frmTrendsDialog.optBookings.Value = UNCHECKED Then
          TempSQL = " bbtbl.arrdate >= #" & Trim(frmTrendsDialog.txtStartDate.Text) & "#"
       Else
          TempSQL = " guesttbl.datebkd >= #" & Trim(frmTrendsDialog.txtStartDate.Text) & "#"
       End If
       DateRange = frmTrendsDialog.txtStartDate.Text & " - All future dates"
    ElseIf Trim(frmTrendsDialog.txtEndDate.Text) <> "" Then
       If frmTrendsDialog.optBookings.Value = UNCHECKED Then
          TempSQL = " bbtbl.arrdate <= #" & Trim(frmTrendsDialog.txtEndDate.Text) & "#"
       Else
          TempSQL = " guesttbl.datebkd <= #" & Trim(frmTrendsDialog.txtEndDate.Text) & "#"
       End If
       DateRange = "All past dates - " & frmTrendsDialog.txtEndDate.Text
    Else
       TempSQL = ""
       DateRange = "All dates"
    End If
    'Construct SQL Statments...
    If frmTrendsDialog.optRoomNights.Value Then
       If myBy = "month" Then
          gSQL = "select datepart('m',arrdate), sum(" & myShow & ") AS 'Frequency' "
          gSQL = gSQL & " From " & myTable
          gSQL = gSQL & " Where (suppress<>-1 Or (suppress=-1 And forfeit=-1)) "
          If Len(TempSQL) > 0 Then gSQL = gSQL & " And " & TempSQL
          gSQL = gSQL & " group by datepart('yyyy',arrdate),datepart('m',arrdate) "
          gSQL = gSQL & " Having sum(" & myShow & ") >= " & myFrequency
          gSQL = gSQL & " Order By datepart('yyyy',arrdate),DatePart('m', arrdate) "
       ElseIf myBy = "year" Then
          gSQL = "select datepart('yyyy',arrdate), sum(" & myShow & ") AS 'Frequency' "
          gSQL = gSQL & " From " & myTable
          gSQL = gSQL & " Where (suppress<>-1 Or (suppress=-1 And forfeit=-1)) "
          If Len(TempSQL) > 0 Then gSQL = gSQL & " And " & TempSQL
          gSQL = gSQL & " group by datepart('yyyy',arrdate) "
          gSQL = gSQL & " Having sum(" & myShow & ") >= " & myFrequency
          gSQL = gSQL & " Order By DatePart('yyyy', arrdate) "
       Else  'By location (property name)
          gSQL = "select " & myBy & ", sum(" & myShow & ") AS 'Frequency' "
          gSQL = gSQL & " From " & myTable
          gSQL = gSQL & " Where (suppress<>-1 Or (suppress=-1 And forfeit=-1)) "
          If Len(TempSQL) > 0 Then gSQL = gSQL & " And " & TempSQL
          If Trim(frmTrendsDialog.datdwComboPropertyName.Text) <> "" Then
             gSQL = gSQL & " And location = '" & frmTrendsDialog.datdwComboPropertyName.Text & "' "
          End If
          gSQL = gSQL & " group by " & myBy
          gSQL = gSQL & " Having sum(" & myShow & ") >= " & myFrequency
          gSQL = gSQL & " Order By sum(" & myShow & ") desc, " & myBy
       End If
    ElseIf frmTrendsDialog.optServiceFee.Value Then
       If myBy = "month" Then
          gSQL = "select datepart('m',arrdate), sum(" & myShow & ") AS 'Frequency' "
          gSQL = gSQL & " From " & myTable
          gSQL = gSQL & " Where (suppress<>-1 Or (suppress=-1 And forfeit=-1)) "
          If Len(TempSQL) > 0 Then gSQL = gSQL & " And " & TempSQL
          gSQL = gSQL & " group by datepart('yyyy',arrdate),datepart('m',arrdate) "
          gSQL = gSQL & " Having sum(" & myShow & ") >= " & myFrequency
          gSQL = gSQL & " Order By datepart('yyyy',arrdate),DatePart('m', arrdate) "
       ElseIf myBy = "year" Then
          gSQL = "select datepart('yyyy',arrdate), sum(" & myShow & ") AS 'Frequency' "
          gSQL = gSQL & " From " & myTable
          gSQL = gSQL & " Where (suppress<>-1 Or (suppress=-1 And forfeit=-1)) "
          If Len(TempSQL) > 0 Then gSQL = gSQL & " And " & TempSQL
          gSQL = gSQL & " group by datepart('yyyy',arrdate) "
          gSQL = gSQL & " Having sum(" & myShow & ") >= " & myFrequency
          gSQL = gSQL & " Order By DatePart('yyyy', arrdate) "
       Else
          gSQL = "select " & myBy & ", sum(" & myShow & ") AS 'Frequency' "
          gSQL = gSQL & " From " & myTable
          gSQL = gSQL & " Where (suppress<>-1 Or (suppress=-1 And forfeit=-1)) "
          If Len(TempSQL) > 0 Then gSQL = gSQL & " And " & TempSQL
          If Trim(frmTrendsDialog.datdwComboPropertyName.Text) <> "" Then
             gSQL = gSQL & " And location = '" & frmTrendsDialog.datdwComboPropertyName.Text & "' "
          End If
          gSQL = gSQL & " group by " & myBy
          gSQL = gSQL & " Having sum(" & myShow & ") >= " & myFrequency
          gSQL = gSQL & " Order By sum(" & myShow & ") desc, " & myBy
       End If
    ElseIf frmTrendsDialog.optReservationFee.Value Then
       'Create distinct temp tables.
       TempEXEC = ""
       If GetNextTableName() Then
         TableName1 = gTableName
       Else
         MsgBox gMsg
         GoTo Form_Unload
       End If
       If GetNextTableName() Then
          TableName2 = gTableName
       Else
          MsgBox gMsg
          GoTo Form_Unload
       End If
       gBNB.Execute "CREATE TABLE " & TableName1 & " (conf LONG);"
       gBNB.Execute "CREATE TABLE " & TableName2 & " (conf LONG, arrdate DATETIME);"
       'Load first temp table
       TempEXEC = "INSERT INTO " & TableName1 & " (conf) SELECT DISTINCT " & _
          "(conf) FROM bbtbl "
       If Len(TempSQL) > 0 Then TempEXEC = TempEXEC & " Where " & TempSQL
       TempEXEC = TempEXEC & ";"
       gBNB.Execute TempEXEC
       'Load second temp table
       TempEXEC = "INSERT INTO " & TableName2 & " (conf,arrdate) SELECT " & _
          "bbtbl.conf,Min(arrdate) FROM bbtbl," & TableName1 & _
          " WHERE bbtbl.conf=" & TableName1 & ".conf " & _
          " GROUP BY bbtbl.conf;"
       gBNB.Execute TempEXEC
       gBNB.Execute "DROP TABLE " & TableName1 & ";"
       If myBy = "month" Then
          gSQL = "select datepart('m',bbtbl.arrdate), sum(" & myShow & ") AS 'Frequency' "
          gSQL = gSQL & " From bbtbl," & myTable & "," & TableName2
          gSQL = gSQL & " Where " & myTable & ".conf=bbtbl.conf "
          gSQL = gSQL & " And bbtbl.conf=" & TableName2 & ".conf"
          gSQL = gSQL & " And bbtbl.arrdate=" & TableName2 & ".arrdate"
          gSQL = gSQL & " And (bbtbl.suppress<>-1 Or (bbtbl.suppress=-1 And bbtbl.forfeit=-1)) "
          If Len(TempSQL) > 0 Then gSQL = gSQL & " And " & TempSQL
          gSQL = gSQL & " group by Datepart('yyyy',bbtbl.arrdate),Datepart('m',bbtbl.arrdate) "
          gSQL = gSQL & " Having sum(" & myShow & ") >= " & myFrequency
          gSQL = gSQL & " Order By Datepart('yyyy',bbtbl.arrdate),DatePart('m', bbtbl.arrdate) "
          'MsgBox gSQL
       ElseIf myBy = "year" Then
          gSQL = "select datepart('yyyy',bbtbl.arrdate), sum(" & myShow & ") AS 'Frequency' "
          gSQL = gSQL & " From bbtbl," & myTable & "," & TableName2
          gSQL = gSQL & " Where " & myTable & ".conf=bbtbl.conf "
          gSQL = gSQL & " And bbtbl.conf=" & TableName2 & ".conf"
          gSQL = gSQL & " And bbtbl.arrdate=" & TableName2 & ".arrdate"
          gSQL = gSQL & " And (bbtbl.suppress<>-1 Or (bbtbl.suppress=-1 And bbtbl.forfeit=-1)) "
          If Len(TempSQL) > 0 Then gSQL = gSQL & " And " & TempSQL
          gSQL = gSQL & " group by datepart('yyyy',bbtbl.arrdate) "
          gSQL = gSQL & " Having sum(" & myShow & ") >= " & myFrequency
          gSQL = gSQL & " Order By DatePart('yyyy', bbtbl.arrdate) "
       End If
    ElseIf frmTrendsDialog.optBookings.Value Then
       If myBy = "month" Then
          gSQL = "select datepart('m',datebkd), count(" & myShow & ") AS 'Frequency' "
          gSQL = gSQL & " From " & myTable
          If Len(TempSQL) > 0 Then gSQL = gSQL & " Where " & TempSQL
          gSQL = gSQL & " group by Datepart('yyyy',guesttbl.datebkd),Datepart('m',guesttbl.datebkd) "
          gSQL = gSQL & " Having count(" & myShow & ") >= " & myFrequency
          gSQL = gSQL & " Order By datepart('yyyy',datebkd),DatePart('m', datebkd) "
       ElseIf myBy = "year" Then
          gSQL = "select datepart('yyyy',datebkd), count(" & myShow & ") AS 'Frequency' "
          gSQL = gSQL & " From " & myTable
          If Len(TempSQL) > 0 Then gSQL = gSQL & " Where " & TempSQL
          gSQL = gSQL & " group by Datepart('yyyy',guesttbl.datebkd) "
          gSQL = gSQL & " Having count(" & myShow & ") >= " & myFrequency
          gSQL = gSQL & " Order By DatePart('yyyy', datebkd) "
       End If
    End If
    
    'Set this report's caption and SQL statement.
    'Me.Caption = gCaption  -  done in Activate event
    Me.txtSQLStatement.Text = gSQL

Form_Load_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
Form_Unload:
   NeedToUnload = True
   Screen.MousePointer = DEFAULT
   Exit Sub
   
Form_Load_Error:
    X = IsError("Form_Load")
    MsgBox Err.Description
    Resume Form_Load_Resume
    'MsgBox "The error will be ignored and execution will continue."
    'Resume Next

End Sub


Private Sub Form_Resize()
    On Error GoTo Form_Resize_Error

    Dim measurement As Single

    'Only respond to event if form is not minimized.
    If Me.WindowState = MINIMIZED Then Exit Sub

    Screen.MousePointer = HOURGLASS
    
    Dim CommandTop, CommandWidth, CommandHeight, StretchWidth As Long
    Static OrigLeft, OrigTop, OrigWidth, OrigHeight As Long
    Dim CommandCount As Integer 'The number of command buttons

    'Initialize Variables
    CommandCount = 4
    CommandHeight = 375 'Twips
    CommandWidth = 900  'Twips
    CommandTop = Me.ScaleHeight - CommandHeight

    'Determine width of horizontal data control given standard layout,
    'where standard layout aligns the data control and command buttons
    'horizontally.
    measurement = Me.ScaleWidth - (CommandCount * CommandWidth)
    'If expected width < 2500 twips then use narrow layout.
    If measurement >= 2500 Then
    'Reposition Controls in STANDARD layout.  Note: Don't change control heights!
        cmdClose.Move 0, CommandTop, CommandWidth, CommandHeight
        cmdPrint.Move CommandWidth, CommandTop, CommandWidth, CommandHeight
        pnl3dCaption.Move (CommandWidth * 2), CommandTop, (ScaleWidth - (CommandCount * CommandWidth)), CommandHeight
        cmdSave.Move (pnl3dCaption.Width + CommandWidth * 2), CommandTop, CommandWidth, CommandHeight
        cmdOptions.Move (ScaleWidth - CommandWidth), CommandTop, CommandWidth, CommandHeight
        'cmdSQL.Move (ScaleWidth - CommandWidth * 2), CommandTop, CommandWidth, CommandHeight
        'cmdRefresh.Move (ScaleWidth - CommandWidth), CommandTop, CommandWidth, CommandHeight
        graBarChart.Move 0, 0, ScaleWidth, CommandTop
        txtSQLStatement.Move 0, 0, ScaleWidth, CommandTop
        pnlMessage.Move 0, 0, ScaleWidth, CommandTop
    Else
    'Reposition Controls in NARROW layout.
        'First check stretch width of commands
        StretchWidth = ScaleWidth / CommandCount
        If StretchWidth >= CommandWidth Then
            CommandWidth = StretchWidth
            cmdClose.Move 0, CommandTop - CommandHeight, CommandWidth, CommandHeight
            cmdPrint.Move CommandWidth, CommandTop - CommandHeight, CommandWidth, CommandHeight
            cmdSave.Move (CommandWidth * 2), CommandTop - CommandHeight, CommandWidth, CommandHeight
            cmdOptions.Move (CommandWidth * 3), CommandTop - CommandHeight, CommandWidth, CommandHeight
            'cmdSQL.Move (CommandWidth * 4), CommandTop - CommandHeight, CommandWidth, CommandHeight
            'cmdRefresh.Move (CommandWidth * 5), CommandTop - CommandHeight, CommandWidth, CommandHeight
            pnl3dCaption.Move 0, CommandTop, ScaleWidth, CommandHeight
            graBarChart.Move 0, 0, ScaleWidth, CommandTop - CommandHeight
            txtSQLStatement.Move 0, 0, ScaleWidth, CommandTop - CommandHeight
            pnlMessage.Move 0, 0, ScaleWidth, CommandTop - CommandHeight
        Else    'STACKED NARROW layout
            CommandWidth = StretchWidth * 2
            cmdClose.Move 0, CommandTop - CommandHeight * 2, CommandWidth, CommandHeight
            cmdPrint.Move CommandWidth, CommandTop - CommandHeight * 2, CommandWidth, CommandHeight
            cmdSave.Move CommandWidth, CommandTop - CommandHeight, CommandWidth, CommandHeight
            cmdOptions.Move 0, CommandTop - CommandHeight, CommandWidth, CommandHeight
            'cmdSQL.Move CommandWidth, CommandTop - CommandHeight, CommandWidth, CommandHeight
            'cmdRefresh.Move (CommandWidth * 2), CommandTop - CommandHeight, CommandWidth, CommandHeight
            pnl3dCaption.Move 0, CommandTop, ScaleWidth, CommandHeight
            graBarChart.Move 0, 0, ScaleWidth, CommandTop - CommandHeight * 2
            txtSQLStatement.Move 0, 0, ScaleWidth, CommandTop - CommandHeight * 2
            pnlMessage.Move 0, 0, ScaleWidth, CommandTop - CommandHeight * 2
        End If
    End If
    'Record the width and height of form for future use.
    OrigLeft = Me.Left
    OrigTop = Me.Top
    OrigWidth = Me.Width
    OrigHeight = Me.Height
    
    Screen.MousePointer = DEFAULT

Exit Sub

Form_Resize_Error:
    If IsError("Form_Resize") Then
        Resume Form_Resize_Resume
    Else
        Resume Next
    End If

Form_Resize_Resume:
    Me.Move OrigLeft, OrigTop, OrigWidth, OrigHeight
    Screen.MousePointer = DEFAULT

End Sub



Public Sub Record_Dialog_Box_Settings()

    If frmTrendsDialog.optProperty.Value Then
        myBy = frmTrendsDialog.optProperty.Tag  'The tag property contains the corresponding database table.column reference.
        'Set Graph Title based on dialog box selection.
            'graBarChart.GraphTitle = "High Hitters by " & frmTrendsDialog.opt3dPartName.Caption
    ElseIf frmTrendsDialog.optMonth.Value Then
        myBy = frmTrendsDialog.optMonth.Tag
   '         'graBarChart.GraphTitle = "High Hitters by " & frmTrendsDialog.opt3dRTCS.Caption
    ElseIf frmTrendsDialog.optYear.Value Then
        myBy = frmTrendsDialog.optYear.Tag
   '         'graBarChart.GraphTitle = "High Hitters by " & frmTrendsDialog.opt3dSystem.Caption
   ' ElseIf frmTrendsDialog.opt3dPartNo.Value Then
   '     myBy = frmTrendsDialog.opt3dPartNo.Tag
   '         'graBarChart.GraphTitle = "High Hitters by " & frmTrendsDialog.opt3dPartNo.Caption
    End If

    If frmTrendsDialog.optRoomNights.Value Then
        myTable = Left(frmTrendsDialog.optRoomNights.Tag, InStr(1, frmTrendsDialog.optRoomNights.Tag, ".") - 1)
        myShow = frmTrendsDialog.optRoomNights.Tag
    ElseIf frmTrendsDialog.optServiceFee.Value Then
        myTable = Left(frmTrendsDialog.optServiceFee.Tag, InStr(1, frmTrendsDialog.optServiceFee.Tag, ".") - 1)
        myShow = frmTrendsDialog.optServiceFee.Tag
    ElseIf frmTrendsDialog.optReservationFee.Value Then
        myTable = Left(frmTrendsDialog.optReservationFee.Tag, InStr(1, frmTrendsDialog.optReservationFee.Tag, ".") - 1)
        myShow = frmTrendsDialog.optReservationFee.Tag
    ElseIf frmTrendsDialog.optBookings.Value Then
        myTable = Left(frmTrendsDialog.optBookings.Tag, InStr(1, frmTrendsDialog.optBookings.Tag, ".") - 1)
        myShow = frmTrendsDialog.optBookings.Tag
    End If

 '   myTable = frmTrendsDialog.chk3dTable.Value
 '   myTraceableOnly = frmTrendsDialog.chk3dTraceableOnly.Value

 '   If frmTrendsDialog.opt3dTopDown.Value Then
 '       myApproach = frmTrendsDialog.opt3dTopDown.Caption
 '   ElseIf frmTrendsDialog.opt3dBottomUp.Value Then
 '       myApproach = frmTrendsDialog.opt3dBottomUp.Caption
 '   ElseIf frmTrendsDialog.opt3dAll.Value Then
 '       myApproach = frmTrendsDialog.opt3dAll.Caption
 '   End If'

    myFrequency = CInt(frmTrendsDialog.txtFrequency.Text)
    myThreshold = CInt(frmTrendsDialog.txtThreshold.Text)

End Sub

Public Function PlotChart() As Integer
    
    On Error GoTo PlotChart_Error

    'Initialize Return value
    PlotChart = False

    'Declare variables.
    Dim SinglePoint, i As Integer
    Dim BottomTitle As String

    'Initialize variables.
    SinglePoint = False
    ShownRows = 0
    TotalRows = 0

    'Reset chart properties
    graBarChart.DataReset = 1   'Clear GraphData
    graBarChart.DataReset = 10  'Clear Font array
    graBarChart.DataReset = 4   'Clear LabelText
    graBarChart.DataReset = 18  'Clear DataLabelText
    graBarChart.DataLabels = 1  'Monochrome data labels above each bar
    If Trim(frmTrendsDialog.datdwComboPropertyName.Text) = "" Then
       graBarChart.LabelStyle = 1  'Vertical X-Axis Labels
    Else
       graBarChart.LabelStyle = 0  'Horizontal X-Axis Labels
    End If
    graBarChart.LeftTitleStyle = 1 'Vertical Up
    graBarChart.AutoInc = 0     'off
    
    graBarChart.FontUse = 1     'Other Titles
    graBarChart.FontStyle = 2   'Bold
    graBarChart.FontSize = 100

    graBarChart.FontUse = 2     'Labels (Axis & Data)
    graBarChart.FontStyle = 2   'Bold
    graBarChart.FontSize = 75

    graBarChart.FontUse = 0     'Graph Title
    'graBarChart.FontSize = 100
    'Load chart data and labels
    If Not datTrends.Recordset.BOF And Not datTrends.Recordset.EOF Then
        'Load chart values...
        BottomTitle = "By " & myBy & "; " & DateRange & "; Freq: " & myFrequency & ", Thresh: " & myThreshold
        graBarChart.BottomTitle = Left$(BottomTitle, 80)
        'Set the number of points to plot.
        If datTrends.Recordset.RecordCount = 1 Then
            graBarChart.NumPoints = 1
            SinglePoint = True
        Else
            graBarChart.NumPoints = datTrends.Recordset.RecordCount
        End If
        'Load data and labels into chart...
        'Limit number of points to Threshold set by user in dialog box.
        If graBarChart.NumPoints > myThreshold Then graBarChart.NumPoints = myThreshold
        If myShow = "Population" Then
            For i = LBound(PopArray, 2) To UBound(PopArray, 2)
                'Count the total number of Rows.
                TotalRows = TotalRows + CLng(PopArray(1, i))
                'Do not load data beyond threshold.
                If i + 1 <= myThreshold Then
                    graBarChart.ThisPoint = i + 1
 '                   graBarChart.LabelText = PopArray(0, I)
 '                   graBarChart.GraphData = PopArray(1, I)
 '                   ShownRows = ShownRows + CLng(PopArray(1, I))
                    If SinglePoint Then Exit For
                End If
            Next i
        Else
            For i = 1 To datTrends.Recordset.RecordCount
                'Count the total number of values returned.
                TotalRows = TotalRows + CLng(datTrends.Recordset(1))
                'Do not load data beyond threshold.
                If i <= myThreshold Then
                    graBarChart.ThisPoint = i
                    If myBy = "month" Then
                       graBarChart.LabelText = ConvertToMonth(datTrends.Recordset(0))
                    Else
                       graBarChart.LabelText = datTrends.Recordset(0)
                    End If
                    graBarChart.GraphData = datTrends.Recordset(1)
                    graBarChart.DataLabelText = datTrends.Recordset(1)
                    ShownRows = ShownRows + CLng(datTrends.Recordset(1))
                    If SinglePoint Then Exit For
                End If
                datTrends.Recordset.MoveNext
            Next i
        End If  '... myShow = Population.
        'Draw the chart.
        graBarChart.DrawMode = 2    'Draw
        'Record the shown & total number of values in grid's caption.
        pnl3dCaption.Caption = ShownRows & " of " & TotalRows & " rows shown"
    Else    'No rows returned.
        graBarChart.GraphCaption = "No rows meet query criteria.  Nothing to Graph."
        graBarChart.DrawMode = 1    'Clear
    End If  '... rows returned.
    'Set the Return value
    PlotChart = True

PlotChart_Resume:

Exit Function

PlotChart_Error:
    'MsgBox "Plot Chart:" & Err.Description
    If IsError("PlotChart") Then
        Resume PlotChart_Resume
    Else
        Resume Next
    End If


End Function

Public Sub GetPopulations()

    On Error GoTo GetPopulations_Error
    
    If datTrends.Recordset.BOF And datTrends.Recordset.EOF Then Exit Sub
    
    'Declare variables.
    Dim SS As Recordset
    Dim PopSQL As String
    Dim i, OrigMP As Integer
    ReDim PopArray(0 To 2, 0 To datTrends.Recordset.RecordCount - 1)

    'Record current state of the mousepointer
    OrigMP = Screen.MousePointer
    'Indicate delay
    Screen.MousePointer = HOURGLASS

    For i = 0 To datTrends.Recordset.RecordCount - 1
        If i = 0 Then
            datTrends.Recordset.MoveFirst
        Else
            datTrends.Recordset.MoveNext
        End If
        PopArray(0, i) = datTrends.Recordset(0)
        PopArray(1, i) = datTrends.Recordset(1)
    '    If myBy Like "*part_no" Then
    '        PopSQL = "SELECT COUNT(*) FROM cmp..serial_current WHERE part_no = '" & datTrends.Recordset(0) & "'"
    '    ElseIf myBy Like "*part_name" Then
    '        PopSQL = "SELECT COUNT(*) FROM cmp..serial_current sc, partno_partname_link ppl WHERE sc.part_no = ppl.part_no And ppl.part_name = '" & datTrends.Recordset(0) & "'"
    '    Else
    '        'we don't belong in this subroutine.
    '        Exit Sub
    '    End If
'MsgBox PopSQL
        Set SS = gBNB.OpenRecordset(PopSQL, dbOpenSnapshot)
        PopArray(2, i) = SS(0)
'MsgBox "PopArray(0," & i & ") = " & PopArray(0, i) & " & PopArray(2," & i & ") = " & PopArray(2, i)
    Next i

    'Sort the data contained in PopArray by the Population Size
 '   Call SortByPopulation

GetPopulations_Resume:
    datTrends.Recordset.MoveFirst
    SS.Close
    Screen.MousePointer = OrigMP
Exit Sub

GetPopulations_Error:
    If IsError("GetPopulations") Then
        Resume GetPopulations_Resume
    Else
        Resume Next
    End If


End Sub

Public Function ConvertToMonth(TheNumber As Integer) As String

   If IsNull(TheNumber) Then Exit Function
   
   If TheNumber = 1 Then
      ConvertToMonth = "Jan"
   ElseIf TheNumber = 2 Then
      ConvertToMonth = "Feb"
   ElseIf TheNumber = 3 Then
      ConvertToMonth = "Mar"
   ElseIf TheNumber = 4 Then
      ConvertToMonth = "Apr"
   ElseIf TheNumber = 5 Then
      ConvertToMonth = "May"
   ElseIf TheNumber = 6 Then
      ConvertToMonth = "Jun"
   ElseIf TheNumber = 7 Then
      ConvertToMonth = "Jul"
   ElseIf TheNumber = 8 Then
      ConvertToMonth = "Aug"
   ElseIf TheNumber = 9 Then
      ConvertToMonth = "Sep"
   ElseIf TheNumber = 10 Then
      ConvertToMonth = "Oct"
   ElseIf TheNumber = 11 Then
      ConvertToMonth = "Nov"
   ElseIf TheNumber = 12 Then
      ConvertToMonth = "Dec"
   End If

End Function

