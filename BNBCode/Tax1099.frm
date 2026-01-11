VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmTax1099 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Host 1099 Tax Form Dialog Box"
   ClientHeight    =   5460
   ClientLeft      =   2715
   ClientTop       =   2175
   ClientWidth     =   5955
   HelpContextID   =   120
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5460
   ScaleWidth      =   5955
   Visible         =   0   'False
   Begin VB.CommandButton cmdClear 
      Caption         =   "Clear &Selections"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   2700
      TabIndex        =   3
      Top             =   4410
      Width           =   1575
   End
   Begin VB.CommandButton cmdPrint 
      Caption         =   "&Print"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   4320
      TabIndex        =   6
      Top             =   4980
      Width           =   1575
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "E&xit"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   4320
      TabIndex        =   4
      Top             =   4410
      Width           =   1575
   End
   Begin VB.CommandButton cmdPrinterSetup 
      Caption         =   "P&rinter Setup"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   2700
      TabIndex        =   5
      Top             =   4980
      Width           =   1575
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   4440
      Top             =   5670
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin Threed.SSPanel pnlMessage 
      Height          =   495
      Left            =   2940
      TabIndex        =   8
      Top             =   5640
      Width           =   1335
      _Version        =   65536
      _ExtentX        =   2355
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
   End
   Begin VB.Data datListing 
      Appearance      =   0  'Flat
      Caption         =   "datListing"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   600
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   5640
      Visible         =   0   'False
      Width           =   2235
   End
   Begin VB.Frame fraDate 
      Caption         =   "Tax Year Date Range"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1095
      Left            =   120
      TabIndex        =   7
      Top             =   4320
      Width           =   2475
      Begin VB.TextBox txtEndDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1050
         TabIndex        =   2
         Tag             =   "Date"
         Top             =   660
         Width           =   1245
      End
      Begin VB.TextBox txtStartDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1050
         TabIndex        =   1
         Tag             =   "Date"
         Top             =   270
         Width           =   1245
      End
      Begin VB.Label lblEndDate 
         Caption         =   "End Date:"
         Height          =   225
         Left            =   120
         TabIndex        =   10
         Top             =   750
         Width           =   1005
      End
      Begin VB.Label lblStartDate 
         Caption         =   "Start Date:"
         Height          =   255
         Left            =   120
         TabIndex        =   9
         Top             =   360
         Width           =   915
      End
   End
   Begin SSDataWidgets_B.SSDBGrid grddwListing 
      Height          =   4125
      Left            =   120
      TabIndex        =   0
      Top             =   90
      Width           =   5775
      ScrollBars      =   2
      _Version        =   131078
      DataMode        =   2
      Col.Count       =   0
      AllowDelete     =   -1  'True
      AllowUpdate     =   0   'False
      AllowRowSizing  =   0   'False
      AllowGroupSizing=   0   'False
      AllowGroupMoving=   0   'False
      AllowGroupSwapping=   0   'False
      AllowGroupShrinking=   0   'False
      AllowDragDrop   =   0   'False
      SelectTypeCol   =   0
      MaxSelectedRows =   200
      RowHeight       =   423
      Columns(0).Width=   3200
      _ExtentX        =   10186
      _ExtentY        =   7276
      _StockProps     =   79
      Caption         =   "Select Properties"
   End
End
Attribute VB_Name = "frmTax1099"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
Dim OriginalRowPosition As Long
Dim SAW As Long

Private Sub cmdClear_Click()
   grddwListing.SelBookmarks.RemoveAll
End Sub

Private Sub cmdExit_Click()
   Unload Me
End Sub

Private Sub cmdPrint_Click()
    
  'This Sub will drive the Crystal report Tax1099.rpt based upon
  'user settings on the frmTax1099 dialog box form.
  On Error GoTo cmdPrint_Click_Error
  Screen.MousePointer = HOURGLASS
  If grddwListing.SelBookmarks.Count = 0 Then
     MsgBox "No properties have been selected.", MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  End If
  If Trim(txtStartDate.Text) = "" Then
     MsgBox "A Start Date must be entered.", MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  Else
     txtStartDate.Text = Trim(txtStartDate.Text)
  End If
  If Trim(txtEndDate.Text) = "" Then
     MsgBox "An End Date must be entered.", MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  Else
     txtEndDate.Text = Trim(txtEndDate.Text)
  End If
  'Validate date and number formats here
  If Not VerifyUpdate() Then
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  End If
  Dim vAccountNum As Long
  Dim vSYear, vSMonth, vSDay As String
  Dim vEYear, vEMonth, vEDay As String
  Dim vStartDate, vEndDate As String
  vEndDate = txtEndDate.Text 'Format(Trim(txtEndDate.Text), "mm/dd/yyyy")
  vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
  vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
  vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
  'Set start year values
  vStartDate = txtStartDate.Text 'Format(Trim(txtStartDate.Text), "mm/dd/yyyy")
  vSYear = DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy"))
  vSMonth = DatePart("m", Format(vStartDate, "mm/dd/yyyy"))
  vSDay = DatePart("d", Format(vStartDate, "mm/dd/yyyy"))
  'Warn if start and end years are different.
  If vSYear <> vEYear Then
     gMsg = "Start and End tax years are not the same. Are you sure you want to continue printing?"
     If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then
        GoTo cmdPrint_Click_Resume
     End If
  End If
  'Print report for each selected property.
  OriginalRowPosition = grddwListing.AddItemRowIndex(grddwListing.Bookmark)
  'Dont allow users to click anything
  'Me.Enabled = False
  Screen.MousePointer = HOURGLASS
  'Build select criteria for report.
  vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
  vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
  vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
  'Use Crystal OCX attached to the main form so we don't need to load another one.
  mdiBNB.Report1.ReportFileName = gDBDirectory & "Tax1099.rpt"
  'Since several reports are sharing the mdiBNB.Report1 control, the sort
  'array MUST be cleared out or values from previous report will be saved in the
  'array causing 'Unknown Field Name' error
  Dim vCount As Integer
  vCount = 0
  While Trim(mdiBNB.Report1.SortFields(vCount)) <> ""
    mdiBNB.Report1.SortFields(vCount) = ""
    vCount = vCount + 1
  Wend
  'Clear out support table
  gBNB.Execute "DELETE FROM Tax1099ReportSupport WHERE ComputerName=" & Chr$(34) & gComputerName & Chr$(34) & ";"
  For j = 0 To grddwListing.SelBookmarks.Count - 1
     grddwListing.Bookmark = grddwListing.SelBookmarks(j)
     vAccountNum = CLng(grddwListing.Columns(1).Text)
     'mdiBNB.Report1.SelectionFormula = mdiBNB.Report1.SelectionFormula & " {proptbl.AccountNum} = " & vAccountNum & " OR"
     gBNB.Execute "INSERT INTO Tax1099ReportSupport (AccountNum,ComputerName) " & _
                  " VALUES (" & vAccountNum & "," & Chr$(34) & gComputerName & Chr$(34) & ");"
  Next j
  mdiBNB.Report1.SelectionFormula = "{CheckTbl.Chk_Date} >= Date(" & _
                      vSYear & "," & vSMonth & "," & vSDay & ")" & _
                      " And {CheckTbl.Chk_Date} <= Date(" & _
                      vEYear & "," & vEMonth & "," & vEDay & ") " & _
                      "And Not IsNull({CheckTbl.Chk_Date}) " & _
                      "And {CheckTbl.void_chk} = 0 " & _
                      "And {CheckTbl.AccountNum}={Tax1099ReportSupport.AccountNum} " & _
                      "And {CheckTbl.CheckCategory} = 'Host' " & _
                      "And ((IsNull({CheckTbl.SubCategory}) Or " & _
                      "(Not IsNull({CheckTbl.SubCategory}) And " & _
                      "{CheckTbl.SubCategory} <> 'Guest Refund'))); "
  'Setup report options
  'mdiBNB.Report1.WindowMinButton = False
  'Set Sort order
  mdiBNB.Report1.SortFields(0) = "+{proptbl.check_to}"
  mdiBNB.Report1.DataFiles(0) = gDatabaseName
    'Print report for current Account Num.
  mdiBNB.Report1.Action = 1
  grddwListing.Bookmark = grddwListing.AddItemBookmark(OriginalRowPosition)
  'Clear out support table
  gBNB.Execute "DELETE FROM Tax1099ReportSupport WHERE ComputerName=" & Chr$(34) & gComputerName & Chr$(34) & ";"

cmdPrint_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdPrint_Click_Error:
   MsgBox Err.Description
   GoTo cmdPrint_Click_Resume

End Sub

Private Sub cmdPrinterSetup_Click()
   
   On Error GoTo cmdPrint_Error
   
   'Generate error if use clicks on Cancel.
   CMDialog1.CancelError = True
   'Show printer setup box instead of printer dialog box.
   CMDialog1.Flags = cdlPDPrintSetup
   'Activate Printer Dialog Box
   CMDialog1.ShowPrinter
   'Invoke changes on printer object.
   Printer.EndDoc

cmdPrinterSetup_Click_Resume:
   Exit Sub
 
cmdPrint_Error:
    'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
    If Err = cdlCancel Then
       'This will keep background screens from other applications
       'gaining focus mysteriously upon closure of common dialog.
       SAW = SetActiveWindow(mdiBNB.hwnd)
    Else
       MsgBox Err.Description
    End If
    Resume cmdPrinterSetup_Click_Resume

End Sub




Private Sub Form_Activate()

  On Error GoTo Form_Activate_Error

  'If this form is in the background (does not have focus) and the
  'Minimize button is clicked on this form that does not yet have the focus,
  'an endless loop of Minimizing and Activating will occur. The following
  'line prevents this interesting problem.
  If Me.WindowState = MINIMIZED Then Exit Sub

  TimesActivated = TimesActivated + 1
  If TimesActivated > 1 Then GoTo Form_Activate_Resume
  Screen.MousePointer = HOURGLASS
  Dim TempSS As Recordset
  Set TempSS = gBNB.OpenRecordset("select MAX(accountnum) from proptbl where PropObsolete<>-1", dbOpenSnapshot)
  GetSSRows TempSS
  If IsNull(TempSS(0)) Then
     gMsg = "Cannot print tax forms. Host properties have not been entered."
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     TempSS.Close
     GoTo Form_Activate_Resume
  End If
'  GetIniSettings
  gSQL = "select location AS [Property],accountnum AS [Account Num],propcity AS [Property Location]" & _
         " from proptbl where PropObsolete<>-1 " & _
         " order by location"
  TempSS.Close
  grddwListing.Visible = False
  datListing.Enabled = False
  'Clear grid for possible call from Options. Doesn't hurt otherwise.
  grddwListing.Reset
  'Display status message
  StatusMessage Me, "Querying the database ...", True
  'Set data control's record source equal to SQL statement.
  datListing.RecordSource = gSQL
  'Refresh datacontrol and query the database.
  If Not GetDCRows(datListing) Then GoTo Form_Activate_Resume
  For i = 0 To 5
    DoEvents
  Next i
  'Load data into grid
  StatusMessage Me, "Loading data grid...", True
  LoadGridRows
  StatusMessage Me, "", False

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
  
Form_Activate_Error:
   Resume Form_Activate_Resume
   
End Sub

Private Sub Form_Load()
  
  TimesActivated = 0
  datListing.DatabaseName = gDatabaseName
End Sub

Public Sub LoadGridRows()

    Dim j As Long
    For i = 0 To datListing.Recordset.Fields.Count - 1
       grddwListing.Columns(i).Caption = datListing.Recordset.Fields(i).Name
    Next i
    'grddwListing.Redraw = False
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
        ' ElseIf datListing.Recordset.Fields(i).Type <> dbText And datListing.Recordset.Fields(i).Type <> dbMemo Then
        '    grddwListing.Columns(i).Text = Str(datListing.Recordset.Fields(i).Value)
         Else
            grddwListing.Columns(i).Text = datListing.Recordset.Fields(i).Value
'MsgBox grddwListing.Columns(i).Text
         End If
       Next i
       datListing.Recordset.MoveNext
    Next j
    'Move the row ID column to end of list (users will never need this
    'and it would be confused with conf#). It should always be at end of list anyway
    'because that's the way it is in the table  (bnb1.mdb file)
 '   For i = 0 To datListing.Recordset.Fields.Count - 1
 '     If grddwListing.Columns(i).Caption = "ID" Then
 '       grddwListing.Columns(i).Position = datListing.Recordset.Fields.Count - 1
 '       Exit For
 '     End If
 '   Next i
    grddwListing.MoveFirst
    grddwListing.Redraw = True
    grddwListing.Visible = True
End Sub

Private Sub Form_Resize()
   pnlMessage.Move grddwListing.Left, grddwListing.Top, grddwListing.Width, grddwListing.Height
End Sub

Private Sub Form_Unload(Cancel As Integer)

   On Error GoTo Form_Unload_Error
   
  ' WriteIniSettings

Form_Unload_Resume:
   Screen.MousePointer = DEFAULT
   Dim X&
   X& = SetActiveWindow(mdiBNB.hwnd)
   Exit Sub
   
Form_Unload_Error:
   Resume Form_Unload_Resume
   
End Sub



Public Function VerifyUpdate()

   VerifyUpdate = True
   
   Dim i As Integer
   For i = 0 To Me.Controls.Count - 1
      If Me.Controls(i).Name Like "txt*" Or Me.Controls(i).Name Like "datdwCombo*" Then
        If Me.Controls(i).Tag = "Number" Or Me.Controls(i).Tag = "Currency" Then
           If Trim(Me.Controls(i).Text) <> "" Then
              If Not IsNumeric(Me.Controls(i).Text) Then
                 gMsg = "Invalid character in number field."
                 VerifyUpdate = False
                 Me.Controls(i).SetFocus
                 Exit For
              End If
           End If
        ElseIf Me.Controls(i).Tag = "Date" Then
              If Me.Controls(i).Text = "" Then
                 'do nothing
              ElseIf IsNull(Me.Controls(i).Text) Then
                 'do nothing
              ElseIf Not DateFormatOk(Me.Controls(i)) Then
                 gMsg = "Invalid date. Use mm/dd/yy format."
                 VerifyUpdate = False
                 Me.Controls(i).SetFocus
                 Exit For
              End If
        ElseIf Me.Controls(i).Tag = "Text" Then
           'Don't commit spaces.
           If Trim(Me.Controls(i).Text) = "" Then Me.Controls(i).Text = ""
        End If
      End If
   Next i
End Function

