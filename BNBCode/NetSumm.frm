VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{00025600-0000-0000-C000-000000000046}#5.1#0"; "CRYSTL32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmNetSummaryDlg 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Net Summary Report Dialog Box"
   ClientHeight    =   4665
   ClientLeft      =   1635
   ClientTop       =   2145
   ClientWidth     =   8985
   HelpContextID   =   116
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4665
   ScaleWidth      =   8985
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
      Height          =   375
      Left            =   5760
      TabIndex        =   10
      Top             =   3840
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
      Height          =   375
      Left            =   7380
      TabIndex        =   11
      Top             =   3840
      Width           =   1515
   End
   Begin VB.Frame fraDateRange 
      Caption         =   "Date Range Options"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1605
      Left            =   5760
      TabIndex        =   17
      Top             =   1440
      Width           =   3135
      Begin VB.TextBox txtEndDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1860
         TabIndex        =   5
         Tag             =   "Date"
         Top             =   570
         Width           =   795
      End
      Begin VB.TextBox txtStartDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   300
         TabIndex        =   4
         Tag             =   "Date"
         Top             =   570
         Width           =   885
      End
      Begin VB.TextBox txtNumMonths 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   810
         TabIndex        =   7
         Tag             =   "Number"
         Top             =   990
         Width           =   375
      End
      Begin VB.OptionButton optXMonthsBack 
         Caption         =   "Back"
         Height          =   255
         Left            =   120
         TabIndex        =   6
         Top             =   1050
         Width           =   705
      End
      Begin VB.OptionButton optDateRange 
         Caption         =   "Specify date range"
         Height          =   285
         Left            =   120
         TabIndex        =   3
         Top             =   270
         Width           =   1845
      End
      Begin VB.Label Label4 
         Caption         =   "through"
         Height          =   255
         Left            =   1260
         TabIndex        =   20
         Top             =   600
         Width           =   615
      End
      Begin VB.Label Label3 
         Caption         =   "through all future dates"
         Height          =   225
         Left            =   390
         TabIndex        =   19
         Top             =   1320
         Width           =   1875
      End
      Begin VB.Label Label2 
         Caption         =   "months and"
         Height          =   255
         Left            =   1230
         TabIndex        =   18
         Top             =   1050
         Width           =   1395
      End
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
      Height          =   345
      Left            =   7380
      TabIndex        =   13
      Top             =   4290
      Width           =   1515
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
      Height          =   345
      Left            =   5760
      TabIndex        =   12
      Top             =   4290
      Width           =   1575
   End
   Begin VB.Frame fraPrintBy 
      Caption         =   "Print By"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1215
      Left            =   5760
      TabIndex        =   15
      Top             =   120
      Width           =   3135
      Begin VB.OptionButton optDatePayRec 
         Caption         =   "Date Payment Received"
         Height          =   255
         Left            =   120
         TabIndex        =   21
         Top             =   900
         Width           =   2505
      End
      Begin VB.OptionButton optCheckDate 
         Caption         =   "Check Print Date"
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   600
         Width           =   2235
      End
      Begin VB.OptionButton optArrivalDate 
         Caption         =   "Arrival Date"
         Height          =   255
         Left            =   120
         TabIndex        =   1
         Top             =   300
         Width           =   1515
      End
      Begin VB.Label Label1 
         Caption         =   "Label1"
         Height          =   75
         Left            =   120
         TabIndex        =   16
         Top             =   480
         Width           =   15
      End
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
      Left            =   120
      MousePointer    =   1  'Arrow
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   4800
      Visible         =   0   'False
      Width           =   1935
   End
   Begin Threed.SSPanel pnlMessage 
      Height          =   495
      Left            =   2040
      TabIndex        =   14
      Top             =   4830
      Width           =   1275
      _Version        =   65536
      _ExtentX        =   2249
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
   Begin Threed.SSCheck chkDisplayOnly 
      Height          =   195
      Left            =   5760
      TabIndex        =   8
      Top             =   3180
      Width           =   2355
      _Version        =   65536
      _ExtentX        =   4154
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "Display report to screen only"
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
   Begin Crystal.CrystalReport NetSumReport 
      Left            =   3840
      Top             =   4890
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   348160
      WindowControlBox=   -1  'True
      WindowMaxButton =   0   'False
      WindowMinButton =   -1  'True
      WindowState     =   2
      PrintFileLinesPerPage=   60
      WindowShowExportBtn=   0   'False
      WindowShowCloseBtn=   -1  'True
      WindowShowSearchBtn=   -1  'True
      WindowShowPrintSetupBtn=   -1  'True
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   3300
      Top             =   4860
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   195
      Left            =   5760
      TabIndex        =   9
      Top             =   3480
      Width           =   2355
      _Version        =   65536
      _ExtentX        =   4154
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "&Save settings on Exit"
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
   Begin SSDataWidgets_B.SSDBGrid grddwListing 
      Height          =   4515
      Left            =   60
      TabIndex        =   0
      Top             =   120
      Width           =   5595
      _Version        =   131078
      DataMode        =   2
      Col.Count       =   0
      AllowUpdate     =   0   'False
      MultiLine       =   0   'False
      AllowRowSizing  =   0   'False
      AllowGroupSizing=   0   'False
      AllowGroupMoving=   0   'False
      AllowColumnMoving=   0
      AllowGroupSwapping=   0   'False
      AllowColumnSwapping=   0
      AllowGroupShrinking=   0   'False
      AllowColumnShrinking=   0   'False
      AllowDragDrop   =   0   'False
      SelectTypeCol   =   0
      ForeColorEven   =   0
      RowHeight       =   423
      Columns(0).Width=   3200
      _ExtentX        =   9869
      _ExtentY        =   7964
      _StockProps     =   79
      Caption         =   "Select Properties"
   End
End
Attribute VB_Name = "frmNetSummaryDlg"
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
    
  'This Sub will drive the Crystal report NetSum.rpt based upon
  'user settings on the frmNetSum dialog box form.
  'Primary table for report is BBTBL. Secondary is CHECKTBL.
  'CheckCategory (ie, Host,Travel,Misc) doesn't need to
  'be specified when querying checktbl because row id BBTBL.ID is
  'written to CHECKTBL.ACCOM_ROWID upon check print, which maintains a one-
  'to-one relationship between checktbl and bbtbl.
  
  On Error GoTo cmdPrint_Click_Error
  Screen.MousePointer = HOURGLASS
  'Validate date and number formats here
  If Not VerifyUpdate() Then
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  End If
  If grddwListing.SelBookmarks.Count = 0 Then
     MsgBox "No properties have been selected.", MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  End If
  Dim vNowTemp As Date
  Dim vNumMonths As Integer
  Dim vAccountNum As Long
  Dim vSYear, vSMonth, vSDay As String
  Dim vEYear, vEMonth, vEDay As String
  Dim vStartDate, vEndDate As String
   
  'Verify dates entered.
  If optXMonthsBack.Value = CHECKED Then
     'Keep Months Back <= 12; > 0
     If CInt(txtNumMonths.Text) > 12 Or CInt(txtNumMonths.Text) < 1 Then
        MsgBox "Number of Months Back must be between 1 and 12.", MB_ICONSTOP, Me.Caption
        GoTo cmdPrint_Click_Resume
     End If
     'Determine range from Number of months back
     NowTemp = Format(Now, "m/d/yyyy")
     vNumMonths = -(CInt(txtNumMonths.Text))
     vStartDate = Format(DateAdd("m", vNumMonths, NowTemp), "m/d/yyyy")
  Else
     If Trim(txtStartDate.Text) = "" Then
        MsgBox "Starting Date cannot be blank.", MB_ICONSTOP, Me.Caption
        GoTo cmdPrint_Click_Resume
     End If
     If Trim(txtEndDate.Text) <> "" Then
        If CDate(txtStartDate.Text) > CDate(txtEndDate.Text) Then
           MsgBox "Starting Date cannot be greater than ending date.", MB_ICONSTOP, Me.Caption
           GoTo cmdPrint_Click_Resume
        End If
        vEndDate = Format(Trim(txtEndDate.Text), "mm/dd/yyyy")
        vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
        vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
        vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
     End If
     vStartDate = Format(Trim(txtStartDate.Text), "mm/dd/yyyy")
  End If
  'Set start year values
  'Me.Enabled = False
  vSYear = DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy"))
  vSMonth = DatePart("m", Format(vStartDate, "mm/dd/yyyy"))
  vSDay = DatePart("d", Format(vStartDate, "mm/dd/yyyy"))
  'Delete from support table
  gBNB.Execute "DELETE FROM NetSummarySupport WHERE ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  'Print report for each selected property.
  OriginalRowPosition = grddwListing.AddItemRowIndex(grddwListing.Bookmark)
  For j = 0 To grddwListing.SelBookmarks.Count - 1
     Screen.MousePointer = HOURGLASS
     grddwListing.Bookmark = grddwListing.SelBookmarks(j)
     vAccountNum = CLng(grddwListing.Columns(1).Text)
     'Build select criteria for report.
     If optArrivalDate.Value = CHECKED Then   'Using Arrival Date
        If optXMonthsBack.Value = CHECKED Then
           NetSumReport.SelectionFormula = "{bbtbl.ArrDate} >= Date(" & _
                    vSYear & "," & vSMonth & "," & vSDay & ") " & _
                    "And Not IsNull({bbtbl.ArrDate}) " & _
                    "And {bbtbl.AccountNum} = " & vAccountNum
        Else
           If vEndDate <> "" Then
              vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
              vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
              vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
              NetSumReport.SelectionFormula = "{bbtbl.ArrDate} >= Date(" & _
                                  vSYear & "," & vSMonth & "," & vSDay & ")" & _
                                  " And {bbtbl.ArrDate} <= Date(" & _
                                  vEYear & "," & vEMonth & "," & vEDay & ") " & _
                                  "And Not IsNull({bbtbl.ArrDate}) " & _
                                  "And {bbtbl.AccountNum} = " & vAccountNum '& _
                                  " And {CheckTbl.CheckCategory} = 'Host' " & _
                                  "And ((IsNull({CheckTbl.SubCategory}) Or " & _
                                  "(Not IsNull({CheckTbl.SubCategory}) And " & _
                                  "{CheckTbl.SubCategory} <> 'Guest Refund'))) "
           Else
              NetSumReport.SelectionFormula = "{bbtbl.ArrDate} >= Date(" & _
                                  vSYear & "," & vSMonth & "," & vSDay & ") " & _
                                  "And Not IsNull({bbtbl.ArrDate}) " & _
                                  "And {bbtbl.AccountNum} = " & vAccountNum '& _
                                  " And {CheckTbl.CheckCategory} = 'Host' " & _
                                  "And ((IsNull({CheckTbl.SubCategory}) Or " & _
                                  "(Not IsNull({CheckTbl.SubCategory}) And " & _
                                  "{CheckTbl.SubCategory} <> 'Guest Refund'))) "
           End If
        End If
     ElseIf optDatePayRec.Value = CHECKED Then
           If vEndDate <> "" Then
              'Fill Support table with confs that have Payments Received
              'within these dates
              gBNB.Execute "INSERT INTO NetSummarySupport (conf,ComputerName) " & _
                           "SELECT DISTINCT conf," & Chr$(34) & gComputerName & Chr$(34) & _
                           " FROM paymentreceived WHERE DateReceived >= #" & _
                           vStartDate & "# AND DateReceived <= #" & _
                           vEndDate & "# " & _
                           "And Not IsNull(DateReceived)"
           Else
              gBNB.Execute "INSERT INTO NetSummarySupport (conf,ComputerName) " & _
                           "SELECT DISTINCT conf," & Chr$(34) & gComputerName & Chr$(34) & _
                           " FROM paymentreceived WHERE DateReceived >= #" & _
                           vStartDate & "# " & _
                           "And Not IsNull(DateReceived)"
           End If
           NetSumReport.SelectionFormula = "{bbtbl.AccountNum} = " & vAccountNum & " " & _
                                           "And {bbtbl.conf}={NetSummarySupport.conf} " & _
                                           "And {NetSummarySupport.ComputerName} = " & Chr$(34) & gComputerName & Chr$(34) & _
                                           " And {CheckTbl.CheckCategory} = 'Host' " & _
                                           "And ((IsNull({CheckTbl.SubCategory}) Or " & _
                                           "(Not IsNull({CheckTbl.SubCategory}) And " & _
                                           "{CheckTbl.SubCategory} <> 'Guest Refund'))) "
     Else  'Using Check Print Date
        If optXMonthsBack.Value = CHECKED Then
           NetSumReport.SelectionFormula = "{CheckTbl.Chk_Date} >= Date(" & _
                    vSYear & "," & vSMonth & "," & vSDay & ") " & _
                    "And Not IsNull({CheckTbl.Chk_Date}) " & _
                    "And {bbtbl.ID} = {checktbl.Accom_RowId} " & _
                    "And {bbtbl.AccountNum} = " & vAccountNum & _
                    " And {CheckTbl.CheckCategory} = 'Host' " & _
                    "And ((IsNull({CheckTbl.SubCategory}) Or " & _
                    "(Not IsNull({CheckTbl.SubCategory}) And " & _
                    "{CheckTbl.SubCategory} <> 'Guest Refund'))) "
        Else
           If vEndDate <> "" Then
              vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
              vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
              vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
              NetSumReport.SelectionFormula = "{CheckTbl.Chk_Date} >= Date(" & _
                                  vSYear & "," & vSMonth & "," & vSDay & ") " & _
                                  "And {CheckTbl.Chk_Date} <= Date(" & _
                                  vEYear & "," & vEMonth & "," & vEDay & ") " & _
                                  "And Not IsNull({CheckTbl.Chk_Date}) " & _
                                  "And {bbtbl.AccountNum} = " & vAccountNum & _
                                  " And {CheckTbl.CheckCategory} = 'Host' " & _
                                  "And ((IsNull({CheckTbl.SubCategory}) Or " & _
                                  "(Not IsNull({CheckTbl.SubCategory}) And " & _
                                  "{CheckTbl.SubCategory} <> 'Guest Refund'))) "
           Else
              NetSumReport.SelectionFormula = "{CheckTbl.Chk_Date} >= Date(" & _
                                  vSYear & "," & vSMonth & "," & vSDay & ") " & _
                                  "And Not IsNull({CheckTbl.Chk_Date}) " & _
                                  "And {bbtbl.AccountNum} = " & vAccountNum & _
                                  " And {CheckTbl.CheckCategory} = 'Host' " & _
                                  "And ((IsNull({CheckTbl.SubCategory}) Or " & _
                                  "(Not IsNull({CheckTbl.SubCategory}) And " & _
                                  "{CheckTbl.SubCategory} <> 'Guest Refund'))) "
           End If
        End If
     End If
    'Setup report options
    'NetSumReport.WindowMinButton = False
    'Set Sort order
    If optArrivalDate.Value = CHECKED Then
      NetSumReport.SortFields(0) = "+{bbtbl.arrdate}"
    ElseIf optDatePayRec.Value = CHECKED Then
      NetSumReport.SortFields(0) = "+{bbtbl.l_name}"
    Else
      NetSumReport.SortFields(0) = "+{checktbl.chk_date}"
    End If
    
    If Me.Caption Like "*Net Summary Report*" Then
       NetSumReport.ReportFileName = gDBDirectory & "NetSum.rpt"
    ElseIf Me.Caption Like "*Service Fee Summary Report*" Then
       NetSumReport.ReportFileName = gDBDirectory & "SvFeeSum.rpt"
    End If
    
    NetSumReport.DataFiles(0) = gDatabaseName
    If chkDisplayOnly.Value = CHECKED Then
       NetSumReport.Destination = 0
    Else
       NetSumReport.Destination = 1
    End If
    'Print report for current Account Num.
    NetSumReport.Action = 1
  Next j
  grddwListing.Bookmark = grddwListing.AddItemBookmark(OriginalRowPosition)
  'Delete from support table
  gBNB.Execute "DELETE FROM NetSummarySupport WHERE ComputerName = " & Chr$(34) & gComputerName & Chr$(34)

cmdPrint_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdPrint_Click_Error:
     MsgBox Err.Description
     GoTo cmdPrint_Click_Resume

End Sub



Private Sub cmdPrinterSetup_Click()
   
   On Error GoTo cmdPrinterSetup_Click_Error
   
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
 
cmdPrinterSetup_Click_Error:
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
  Me.Caption = gCaption
  Dim TempSS As Recordset
  Set TempSS = gBNB.OpenRecordset("select MAX(accountnum) from proptbl where PropObsolete<>-1", dbOpenSnapshot)
  GetSSRows TempSS
  If IsNull(TempSS(0)) Then
     TempSS.Close
     gMsg = "No host properties have been entered."
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo Form_Activate_Resume
  End If
  TempSS.Close
  GetIniSettings
  gSQL = "select location AS [Property],accountnum AS [Account Num],propcity AS [Property Location]" & _
         " from proptbl where PropObsolete<>-1 " & _
         " order by location"
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



Public Sub WriteIniSettings()

    'Declare variables
    Dim X As Integer        'Return Value
    Dim winDir, iniFile, Temp As String
    'Get the directory in which the Windows and the .INI files reside.
    'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())
    'Detemine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"
'SAVE SETTINGS (always save this)
    'Write the Save Settings check box setting to the .INI file.
'MsgBox Str(chkSaveSettings.Value)
    If chkSaveSettings.Value = CHECKED Then
        X = WritePrivateProfileString("Net Summary Report", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Net Summary Report", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Net Summary Report", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub
   ' X = WritePrivateProfileString("Net Summary Report", "ShowTop", Format$(txtShowTop.Text), iniFile)
    X = WritePrivateProfileString("Net Summary Report", "ArrivalDate", Format$(optArrivalDate.Value), iniFile)
    X = WritePrivateProfileString("Net Summary Report", "CheckDate", Format$(optCheckDate.Value), iniFile)
    X = WritePrivateProfileString("Net Summary Report", "PaymentReceivedDate", Format$(optDatePayRec.Value), iniFile)
    X = WritePrivateProfileString("Net Summary Report", "DisplayOnly", Format$(chkDisplayOnly.Value), iniFile)
    X = WritePrivateProfileString("Net Summary Report", "DateRange", Format$(optDateRange.Value), iniFile)
    X = WritePrivateProfileString("Net Summary Report", "MonthsBack", Format$(optXMonthsBack.Value), iniFile)
    X = WritePrivateProfileString("Net Summary Report", "NumMonths", txtNumMonths.Text, iniFile)
    X = WritePrivateProfileString("Net Summary Report", "StartDate", txtStartDate.Text, iniFile)
    X = WritePrivateProfileString("Net Summary Report", "EndDate", txtEndDate.Text, iniFile)
   ' x = WritePrivateProfileString("Confirmation Report", "ConfirmToOther", Format$(optOther.Value), iniFile)

End Sub

Public Sub GetIniSettings()

    'Declare variables
    Dim X As Integer        'Return Value
    Dim Rs As String * 200  'Return String
    Dim winDir, Temp, iniFile As String

    'Initialize variables
    Rs = Space$(Len(Rs))

    'Get the directory in which the Windows and the .INI files reside.
    'Note that GetPrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())
    'Detemine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"

   ' X = GetPrivateProfileString("Net Summary Report", "ShowTop", "100", Rs, Len(Rs), iniFile)
   ' If X > 0 Then txtShowTop.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Net Summary Report", "ArrivalDate", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optArrivalDate.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Net Summary Report", "CheckDate", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optCheckDate.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Net Summary Report", "PaymentReceivedDate", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optDatePayRec.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Net Summary Report", "StartDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtStartDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Net Summary Report", "EndDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtEndDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Net Summary Report", "NumMonths", "2", Rs, Len(Rs), iniFile)
    If X > 0 Then txtNumMonths.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Net Summary Report", "DateRange", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optDateRange.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Net Summary Report", "MonthsBack", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optXMonthsBack.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Net Summary Report", "DisplayOnly", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then chkDisplayOnly.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
      
   ' x = GetPrivateProfileString("Confirmation Report", "ConfirmToOther", "False", Rs, Len(Rs), iniFile)
   ' If x > 0 Then optOther.Value = Left$(Rs, x)     ' Trim Buffer. a string was returned.
'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Net Summary Report", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
    If X > 0 Then  'a string was returned.
        Temp = Left$(Rs, X)     ' Trim Buffer
        If Temp = "CHECKED" Then
            chkSaveSettings.Value = CHECKED
        ElseIf Temp = "UNCHECKED" Then
            chkSaveSettings.Value = UNCHECKED
        ElseIf Temp = "GRAYED" Then
            chkSaveSettings.Value = GRAYED
        Else
            'Leave as set in design time.
        End If
    End If
End Sub

Private Sub Form_Unload(Cancel As Integer)

   On Error GoTo Form_Unload_Error
   
   WriteIniSettings
   
Form_Unload_Resume:
   Screen.MousePointer = DEFAULT
   Dim X&
   X& = SetActiveWindow(mdiBNB.hwnd)
   Exit Sub
   
Form_Unload_Error:
   Resume Form_Unload_Resume
   
End Sub


Private Sub optDateRange_Click()
  
  txtStartDate.Enabled = True
  txtEndDate.Enabled = True
  txtNumMonths.Enabled = False
  Label4.Enabled = True
  
End Sub


Private Sub optXMonthsBack_Click()

  Label4.Enabled = False
  txtStartDate.Enabled = False
  txtEndDate.Enabled = False
  txtNumMonths.Enabled = True
  
End Sub



Public Function VerifyUpdate() As Integer

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

