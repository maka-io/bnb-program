VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{00025600-0000-0000-C000-000000000046}#5.1#0"; "CRYSTL32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmConfDlg 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Confirmation & Fee Summary Report Dialog Box"
   ClientHeight    =   5565
   ClientLeft      =   1305
   ClientTop       =   2025
   ClientWidth     =   8760
   HelpContextID   =   113
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   5565
   ScaleWidth      =   8760
   Begin Threed.SSCheck chkManualConf 
      Height          =   195
      Left            =   5820
      TabIndex        =   7
      Top             =   3360
      Width           =   2835
      _Version        =   65536
      _ExtentX        =   5001
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "&Enter Conf number manually"
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
   Begin VB.CommandButton cmdFeeSum 
      Caption         =   "Print &Fee Rpt"
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
      Left            =   7320
      TabIndex        =   12
      Top             =   4620
      Width           =   1395
   End
   Begin VB.CommandButton cmdPrintSetup 
      Caption         =   "Print &Setup..."
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
      Left            =   5820
      TabIndex        =   11
      Top             =   4620
      Width           =   1395
   End
   Begin Threed.SSCheck chkPreFormat 
      Height          =   195
      Left            =   5820
      TabIndex        =   8
      Top             =   3660
      Width           =   2835
      _Version        =   65536
      _ExtentX        =   5001
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "&Print Conf on pre-formatted form"
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
   Begin Threed.SSCheck chkSortName 
      Height          =   195
      Left            =   5820
      TabIndex        =   6
      Top             =   3060
      Width           =   2355
      _Version        =   65536
      _ExtentX        =   4154
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "Show sorted by &Last Name"
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
   Begin VB.Frame fraConfirmType 
      Caption         =   "Confirmation Type"
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
      Left            =   5820
      TabIndex        =   20
      Top             =   1380
      Width           =   2895
      Begin VB.OptionButton optTypePackage 
         Caption         =   "P&ackage (grand total only)"
         Height          =   195
         Left            =   120
         TabIndex        =   4
         Top             =   660
         Width           =   2655
      End
      Begin VB.OptionButton optTypeNormal 
         Caption         =   "&Normal (full cost breakdown)"
         Height          =   255
         Left            =   120
         TabIndex        =   3
         Top             =   300
         Width           =   2655
      End
   End
   Begin VB.CommandButton cmdPrint 
      Caption         =   "Print &Conf Rpt"
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
      Left            =   7320
      TabIndex        =   14
      Top             =   5160
      Width           =   1395
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
      Height          =   375
      Left            =   5820
      TabIndex        =   13
      Top             =   5160
      Width           =   1395
   End
   Begin VB.TextBox txtShowTop 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   6600
      TabIndex        =   5
      Tag             =   "Number"
      Text            =   "50"
      Top             =   2700
      Width           =   555
   End
   Begin VB.Frame fraConfirmTo 
      Caption         =   "Address Confirmation To"
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
      Left            =   5820
      TabIndex        =   16
      Top             =   60
      Width           =   2895
      Begin VB.OptionButton optTravelAgent 
         Caption         =   "&Travel Agent/Wholesaler"
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   660
         Width           =   2235
      End
      Begin VB.OptionButton optGuest 
         Caption         =   "&Guest"
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
         TabIndex        =   17
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
      Left            =   60
      MousePointer    =   1  'Arrow
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   5700
      Visible         =   0   'False
      Width           =   1935
   End
   Begin Threed.SSPanel pnlMessage 
      Height          =   495
      Left            =   2040
      TabIndex        =   15
      Top             =   5700
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
      Left            =   5820
      TabIndex        =   9
      Top             =   3960
      Width           =   2355
      _Version        =   65536
      _ExtentX        =   4154
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "&Display report to screen only"
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
   Begin Crystal.CrystalReport ConfReport 
      Left            =   4020
      Top             =   5610
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
      WindowShowPrintSetupBtn=   -1  'True
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   3420
      Top             =   5610
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   195
      Left            =   5820
      TabIndex        =   10
      Top             =   4260
      Width           =   2355
      _Version        =   65536
      _ExtentX        =   4154
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "Sa&ve settings on Exit"
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
      Height          =   5415
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
      AllowColumnSizing=   0   'False
      AllowGroupMoving=   0   'False
      AllowColumnMoving=   0
      AllowGroupSwapping=   0   'False
      AllowColumnSwapping=   0
      AllowGroupShrinking=   0   'False
      AllowColumnShrinking=   0   'False
      AllowDragDrop   =   0   'False
      SelectTypeCol   =   0
      SelectTypeRow   =   1
      MaxSelectedRows =   1
      ForeColorEven   =   0
      RowHeight       =   423
      Columns(0).Width=   3200
      _ExtentX        =   9869
      _ExtentY        =   9551
      _StockProps     =   79
      Caption         =   "Select Confirmation to Print"
   End
   Begin VB.Label lblConfirmations 
      Caption         =   "Confirmations"
      Height          =   195
      Left            =   7200
      TabIndex        =   19
      Top             =   2760
      Width           =   1035
   End
   Begin VB.Label lblShowTop 
      Caption         =   "Show Top"
      Height          =   195
      Left            =   5820
      TabIndex        =   18
      Top             =   2760
      Width           =   795
   End
End
Attribute VB_Name = "frmConfDlg"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
Dim SAW As Long

Private Sub chkManualConf_Click(Value As Integer)

   If chkManualConf.Value = CHECKED Then
      grddwListing.Enabled = False
   Else
      grddwListing.Enabled = True
   End If
   
End Sub

Private Sub cmdExit_Click()
   Unload Me
End Sub

Private Sub cmdFeeSum_Click()

    Dim vConf As Long
    Dim TempSS As Recordset

    'Get the conf user selected from list, or supply an Input Box to manually enter conf.
    If chkManualConf.Value = CHECKED Then
       Dim ConfTemp As Variant
       ConfTemp = InputBox("Enter confirmation number:", "Fee Summary Report", , , , App.HelpFile, 113)
       If Trim(ConfTemp) <> "" Then
          If Not IsNumeric(ConfTemp) Then
             MsgBox "Confirmation entered must be numeric.", MB_ICONSTOP, Me.Caption
             GoTo cmdFeeSum_Resume
          End If
       Else
          GoTo cmdFeeSum_Resume
       End If
       vConf = CLng(ConfTemp)
       gSQL = "SELECT conf FROM guesttbl WHERE conf = " & vConf
       Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
       GetSSRows TempSS
       If TempSS.RecordCount = 0 Then
          MsgBox "Confirmation number does not exist.", MB_ICONSTOP, Me.Caption
          TempSS.Close
          GoTo cmdFeeSum_Resume
       End If
       TempSS.Close
    Else
       'Get the conf user selected from list.
       '(Only one can be selected at a time - for now)
       If grddwListing.SelBookmarks.Count = 0 Then
          MsgBox "No confirmations have been selected.", MB_ICONSTOP, Me.Caption
          GoTo cmdFeeSum_Resume
       Else
          vConf = grddwListing.Columns("Conf Num").CellValue(grddwListing.SelBookmarks(0))
       End If
    End If
    'Dont allow users to click anything
    'Me.Enabled = False
    Screen.MousePointer = HOURGLASS
    'Setup report
    ConfReport.ReportFileName = gDBDirectory & "FeeSum.rpt"
    'ConfReport.WindowMinButton = False
    ConfReport.SelectionFormula = "{BBTBL.conf} = " & vConf & _
                                  " And ({BBTBL.suppress} <> -1 " & _
                                  " or ({BBTBL.suppress}=-1 and {bbtbl.forfeit}=-1)) "
    ConfReport.SortFields(0) = "+{bbtbl.arrdate}"
    ConfReport.DataFiles(0) = gDatabaseName
    If chkDisplayOnly.Value = CHECKED Then
       ConfReport.Destination = 0
    Else
       ConfReport.Destination = 1
    End If
    'Print report
    ConfReport.Action = 1
    
cmdFeeSum_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdFeeSum_Error:
      Resume cmdFeeSum_Resume
   
End Sub



Private Sub cmdPrint_Click()
    
    On Error GoTo cmdPrint_Error
    
    Dim vConfTo, vConfType As String
    Dim vConf, vTravelAgencyNum As Long
    Dim TempSS As Recordset
    Screen.MousePointer = HOURGLASS
    '*****Perform validity checks before printing.*****
    If IsNumeric(txtShowTop.Text) Then
       If CInt(Trim(txtShowTop.Text)) <= 0 Then
          MsgBox "Show Top Confirmations field value must be greater than zero.", MB_ICONSTOP, Me.Caption
          GoTo cmdPrint_Resume
       End If
    Else
       MsgBox "Invalid number value in Show Top Confirmations field.", MB_ICONSTOP, Me.Caption
       GoTo cmdPrint_Resume
    End If
    If chkManualConf.Value = CHECKED Then
       Dim ConfTemp As Variant
       ConfTemp = InputBox("Enter confirmation number:", "Confirmation Report", , , , App.HelpFile, 113)
       If Trim(ConfTemp) <> "" Then
          If Not IsNumeric(ConfTemp) Then
             MsgBox "Confirmation entered must be numeric.", MB_ICONSTOP, Me.Caption
             GoTo cmdPrint_Resume
          End If
       Else
          GoTo cmdPrint_Resume
       End If
       vConf = CLng(ConfTemp)
       gSQL = "SELECT conf FROM guesttbl WHERE conf = " & vConf
       Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
       GetSSRows TempSS
       If TempSS.RecordCount = 0 Then
          MsgBox "Confirmation number does not exist.", MB_ICONSTOP, Me.Caption
          TempSS.Close
          GoTo cmdPrint_Resume
       End If
       TempSS.Close
    Else
       'Get the conf user selected from list.
       '(Only one can be selected at a time - for now)
       If grddwListing.SelBookmarks.Count = 0 Then
          MsgBox "No confirmations have been selected.", MB_ICONSTOP, Me.Caption
          GoTo cmdPrint_Resume
       Else
          vConf = grddwListing.Columns("Conf Num").CellValue(grddwListing.SelBookmarks(0))
       End If
    End If
    'Don't allow print if row doesn't exist in payment history for selected conf
    gSQL = "SELECT conf FROM payment WHERE conf = " & vConf
    Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
    GetSSRows TempSS
    If TempSS.RecordCount = 0 Then
       MsgBox "A Guest Payments record must be entered for this confirmation number.", MB_ICONSTOP, Me.Caption
       TempSS.Close
       GoTo cmdPrint_Resume
    End If
    TempSS.Close
    'Get values user selected for Confirm To and Confirmation Type.
    If optGuest.Value = CHECKED Then
       vConfTo = "Guest"
    ElseIf optTravelAgent.Value = CHECKED Then
       vConfTo = "Travel Agent"
    End If
    If optTypeNormal.Value = CHECKED Then
       vConfType = "Normal"
    ElseIf optTypePackage.Value = CHECKED Then
       vConfType = "Package"
    End If

    Dim TravelAgencyExists As Integer
    TravelAgencyExists = False
    'Make sure this conf is associated with a travel agency if Confirm To Agent is selected.
    'If yes, insert TravelAgent into ConfReportSupport.ConfTo; If not, exit.
    gSQL = "SELECT conf,accountnum FROM tagentbl WHERE conf = " & vConf
    Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
    GetSSRows TempSS
    If TempSS.RecordCount > 0 Then
       TravelAgencyExists = True
       vTravelAgencyNum = TempSS("accountnum")
    End If
    TempSS.Close
    If Not TravelAgencyExists And vConfTo = "Travel Agent" Then
       gMsg = "The 'Travel Agent/Wholesaler' option in the 'Address Confirmation " & _
              "To' section is selected, but a travel agency has not been associated " & _
              "with this confirmation."
       MsgBox gMsg, MB_ICONSTOP, Me.Caption
       GoTo cmdPrint_Resume
    ElseIf TravelAgencyExists And vConfTo <> "Travel Agent" Then
       gMsg = "A travel agency is associated with this confirmation, but the " & _
              "'Guest' option in the 'Address Confirmation To' section " & _
              "is selected. Continue confirming to " & vConfTo & " instead?"
       If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then GoTo cmdPrint_Resume
    End If
    'If Package type is selected, ensure entry exists in payment.predue and Deposit Due is blank
    If optTypePackage.Value = CHECKED Then
       gSQL = "SELECT depdue,predue FROM payment WHERE conf = " & vConf
       Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
       GetSSRows TempSS
       If TempSS.BOF And TempSS.EOF Then
          gMsg = "A Guest Payments record must be entered for a Package confirmation."
          MsgBox gMsg, MB_ICONSTOP, Me.Caption
          TempSS.Close
          GoTo cmdPrint_Resume
       ElseIf IsNull(TempSS("predue")) Then
          gMsg = "Prepayment Amount Due must be entered in Guest Payments for a Package confirmation."
          MsgBox gMsg, MB_ICONSTOP, Me.Caption
          TempSS.Close
          GoTo cmdPrint_Resume
       ElseIf Not IsNull(TempSS("depdue")) Then
          gMsg = "Deposit Amount Due in Guest Payments must be blank for a Package confirmation." & _
                 " Prepayment Amount Due will be listed as the total package price."
          MsgBox gMsg, MB_ICONSTOP, Me.Caption
          TempSS.Close
          GoTo cmdPrint_Resume
       End If
    End If
    'Force to Portrait mode
    While Printer.Orientation <> 1
       GoSub SetToPortrait
    Wend
    '*****End validity checks.*****
    'Me.Enabled = False  'Dont allow users to click anything during processing
    Screen.MousePointer = HOURGLASS
    'Clear out working table for this computer name.
    gBNB.Execute "delete from ConfReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
    'Calculate Deposit(Received) totals for this conf number.
    Dim vDepRec, vPreRec As Currency
    Dim vDateDepRec, vDepositCheckNum, vDatePreRec, vPrepayCheckNum As String
'*****DEPOSIT******
    'Get total Deposit Received.
    gSQL = "SELECT sum(AmountReceived) " & _
           "FROM paymentreceived WHERE conf = " & vConf & _
           " AND AppliedTo = 'Deposit'"
    Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
    GetSSRows TempSS
    'MsgBox gSQL
    If IsNull(TempSS(0)) Then
      vDepRec = 0
    Else
      vDepRec = (TempSS(0))
    End If
    'Now concatenate the DateReceived and CheckNumber fields for this conf into 2 separate strings.
    gSQL = "SELECT DateReceived " & _
           "FROM paymentreceived WHERE conf = " & vConf & _
           " AND AppliedTo = 'Deposit'"
    Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
    GetSSRows TempSS
    vDateDepRec = ""
    For i = 0 To TempSS.RecordCount - 1
      If IsNull(TempSS(0)) Then
        'Do nothing
      Else
        vDateDepRec = vDateDepRec & Str(TempSS(0)) & ","
      End If
      TempSS.MoveNext
    Next i
    If Len(vDateDepRec) > 0 Then vDateDepRec = Left(vDateDepRec, Len(vDateDepRec) - 1)
 '   MsgBox vDateDepRec
    TempSS.Close
    
    gSQL = "SELECT CheckNumber " & _
           "FROM paymentreceived WHERE conf = " & vConf & _
           " AND AppliedTo = 'Deposit'"
    Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
    GetSSRows TempSS
    vDepositCheckNum = ""
    For i = 0 To TempSS.RecordCount - 1
      If IsNull(TempSS(0)) Then
        'Do nothing
      Else
        vDepositCheckNum = vDepositCheckNum & TempSS(0) & ","
      End If
      TempSS.MoveNext
    Next i
    If Len(vDepositCheckNum) > 0 Then vDepositCheckNum = Left(vDepositCheckNum, Len(vDepositCheckNum) - 1)
 '   MsgBox vDateDepRec
    TempSS.Close
'*****PREPAYMENT *******
    'Calculate Prepayment(Received) totals for this conf number.
    'Get total Prepayment Received.
    gSQL = "SELECT sum(AmountReceived) " & _
           "FROM paymentreceived WHERE conf = " & vConf & _
           " AND AppliedTo = 'Prepayment'"
    Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
    GetSSRows TempSS
    'MsgBox gSQL
    If IsNull(TempSS(0)) Then
      vPreRec = 0
    Else
      vPreRec = (TempSS(0))
    End If
    'MsgBox Str(vDepRec)
    TempSS.Close
'**** Append Dates Received to each other separated by commas  ***
    gSQL = "SELECT DateReceived " & _
           "FROM paymentreceived WHERE conf = " & vConf & _
           " AND AppliedTo = 'Prepayment'"
    Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
    GetSSRows TempSS
    vDatePreRec = ""
    For i = 0 To TempSS.RecordCount - 1
      If IsNull(TempSS(0)) Then
        'Do nothing
      Else
        vDatePreRec = vDatePreRec & Str(TempSS(0)) & ","
      End If
      TempSS.MoveNext
    Next i
    If Len(vDatePreRec) > 0 Then vDatePreRec = Left(vDatePreRec, Len(vDatePreRec) - 1)
    TempSS.Close
'**** Append Check Numbers to each other separated by commas  ***
    gSQL = "SELECT CheckNumber " & _
           "FROM paymentreceived WHERE conf = " & vConf & _
           " AND AppliedTo = 'Prepayment'"
    Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
    GetSSRows TempSS
    vPrepayCheckNum = ""
    For i = 0 To TempSS.RecordCount - 1
      If IsNull(TempSS(0)) Then
        'Do nothing
      Else
        vPrepayCheckNum = vPrepayCheckNum & TempSS(0) & ","
      End If
      TempSS.MoveNext
    Next i
    If Len(vPrepayCheckNum) > 0 Then vPrepayCheckNum = Left(vPrepayCheckNum, Len(vPrepayCheckNum) - 1)
 '   MsgBox vDateDepRec
    TempSS.Close
    gSQL = "INSERT INTO ConfReportSupport (conf,TotalDeposit,DateDepReceived,DepositCheckNum,TotalPrepayment,DatePreReceived,PrepayCheckNum,ComputerName,ConfTo,ConfType,TravelAgencyNum) " & _
           "VALUES (" & vConf & "," & Format(vDepRec, CURRENCYFORMAT2) & ",'" & vDateDepRec & "','" & vDepositCheckNum & "'," & Format(vPreRec, CURRENCYFORMAT2) & ",'" & vDatePreRec & "','" & vPrepayCheckNum & "'," & Chr$(34) & gComputerName & Chr$(34) & ",'" & vConfTo & "','" & vConfType & "'," & vTravelAgencyNum & ")"
    'MsgBox gSQL
    gBNB.Execute gSQL
    'Select appropriate Confirmation report
    If chkPreFormat.Value = CHECKED Then
       ConfReport.ReportFileName = gDBDirectory & "conf.rpt"
    Else
       ConfReport.ReportFileName = gDBDirectory & "conf2.rpt"
    End If
    'ConfReport.WindowMinButton = False
    ConfReport.DataFiles(0) = gDatabaseName
    If chkDisplayOnly.Value = CHECKED Then
       ConfReport.Destination = 0
    Else
       ConfReport.Destination = 1
    End If
    
    If vConfTo = "Guest" Then
       ConfReport.SelectionFormula = "{guesttbl.conf} = " & vConf & _
                                    " And ({BBTBL.suppress}<>-1 " & _
                                    " or ({BBTBL.suppress}=-1 and {bbtbl.forfeit}=-1)) " & _
                                    " And {ConfReportSupport.Conf} = " & vConf & _
                                    " And {ConfReportSupport.ComputerName} = " & Chr$(34) & gComputerName & Chr$(34)
    Else
       ConfReport.SelectionFormula = "{guesttbl.conf} = " & vConf & _
                                    " And ({BBTBL.suppress}<>-1 " & _
                                    " or ({BBTBL.suppress}=-1 and {bbtbl.forfeit}=-1)) " & _
                                    " And {ConfReportSupport.Conf} = " & vConf & _
                                    " And {tagentbl.conf} = " & vConf & _
                                    " And {ConfReportSupport.ComputerName} = " & Chr$(34) & gComputerName & Chr$(34)
    End If
'MsgBox ConfReport.SelectionFormula
    'Print report
    ConfReport.Action = 1
    'Clear out working table for this computer name.
    gBNB.Execute "delete from ConfReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)

cmdPrint_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
SetToPortrait:
   gMsg = "Set Orientation to Portrait mode in the following Printer Setup screen..."
   MsgBox gMsg, MB_ICONSTOP, Me.Caption
   'Generate error if use clicks on Cancel.
   CMDialog1.CancelError = True
   'Show printer setup box instead of printer dialog box.
   CMDialog1.Flags = cdlPDPrintSetup
   'Activate Printer Dialog Box
   CMDialog1.ShowPrinter
   'Invoke changes on printer object.
   Printer.EndDoc
   Return
   
cmdPrint_Error:
    'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
    If Err = cdlCancel Then
       'This will keep background screens from other applications
       'gaining focus mysteriously upon closure of common dialog.
       SAW = SetActiveWindow(mdiBNB.hwnd)
    Else
       MsgBox Err.Description
    End If
    Resume cmdPrint_Resume
   
End Sub


Private Sub cmdPrintSetup_Click()
   
   On Error GoTo cmdPrintSetup_Click_Error
   
   'Generate error if use clicks on Cancel.
   CMDialog1.CancelError = True
   'Show printer setup box instead of printer dialog box.
   CMDialog1.Flags = cdlPDPrintSetup
   'Activate Printer Dialog Box
   CMDialog1.ShowPrinter
   'Invoke changes on printer object.
   Printer.EndDoc
 
cmdPrintSetup_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdPrintSetup_Click_Error:
   'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
   If Err = cdlCancel Then
      'This will keep background screens from other applications
      'gaining focus mysteriously upon closure of common dialog.
      SAW = SetActiveWindow(mdiBNB.hwnd)
   Else
      MsgBox Err.Description
   End If
   Resume cmdPrintSetup_Click_Resume
   
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
  GetIniSettings
  Dim TempSS As Recordset
  Set TempSS = gBNB.OpenRecordset("select MAX(conf) from guesttbl", dbOpenSnapshot)
  GetSSRows TempSS
  If IsNull(TempSS(0)) Then
     gMsg = "Cannot print confirmations. None have been entered."
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     Unload Me
     GoTo Form_Activate_Resume
  End If
  Dim TempVal As Long
  If TempSS(0) <= CInt(Trim(txtShowTop.Text)) Then
     TempVal = 0
  Else
     TempVal = TempSS(0) - CInt(Trim(txtShowTop.Text) - 1)
  End If
  If chkSortName.Value = CHECKED Then
     gSQL = "select conf AS [Conf Num],l_name AS [Last Name],f_name AS [First Name] from guesttbl " & _
            "where conf <= " & Str(TempSS(0)) & " And conf >= " & TempVal & _
            " order by l_name"
  Else
     gSQL = "select conf AS [Conf Num],l_name AS [Last Name],f_name AS [First Name] from guesttbl " & _
            "where conf <= " & Str(TempSS(0)) & " And conf >= " & TempVal & _
            " order by conf desc"
  End If
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
  If datListing.Recordset.RecordCount > 0 Then
    StatusMessage Me, "Loading data grid...", True
    LoadGridRows
    StatusMessage Me, "", False
  Else
    StatusMessage Me, "No confirmations found.", True
  End If

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
    If CLng(txtShowTop) > 2000 Then txtShowTop.Text = 2000
'SAVE SETTINGS (always save this)
    'Write the Save Settings check box setting to the .INI file.
'MsgBox Str(chkSaveSettings.Value)
    If chkSaveSettings.Value = CHECKED Then
        X = WritePrivateProfileString("Confirmation Report", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Confirmation Report", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Confirmation Report", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub
    X = WritePrivateProfileString("Confirmation Report", "ShowTop", Format$(txtShowTop.Text), iniFile)
    X = WritePrivateProfileString("Confirmation Report", "ConfirmToGuest", Format$(optGuest.Value), iniFile)
    X = WritePrivateProfileString("Confirmation Report", "ConfirmToAgent", Format$(optTravelAgent.Value), iniFile)
    X = WritePrivateProfileString("Confirmation Report", "ConfTypeNormal", Format$(optTypeNormal.Value), iniFile)
    X = WritePrivateProfileString("Confirmation Report", "ConfTypePackage", Format$(optTypePackage.Value), iniFile)
    X = WritePrivateProfileString("Confirmation Report", "DisplayOnly", Format$(chkDisplayOnly.Value), iniFile)
    X = WritePrivateProfileString("Confirmation Report", "SortLastName", Format$(chkSortName.Value), iniFile)
    X = WritePrivateProfileString("Confirmation Report", "PreFormatted", Format$(chkPreFormat.Value), iniFile)
    X = WritePrivateProfileString("Confirmation Report", "ManualConfSel", Format$(chkManualConf.Value), iniFile)

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

    X = GetPrivateProfileString("Confirmation Report", "ShowTop", "100", Rs, Len(Rs), iniFile)
    If X > 0 Then txtShowTop.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Confirmation Report", "ConfirmToGuest", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optGuest.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Confirmation Report", "ConfirmToAgent", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optTravelAgent.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Confirmation Report", "ConfTypeNormal", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optTypeNormal.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Confirmation Report", "ConfTypePackage", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optTypePackage.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Confirmation Report", "DisplayOnly", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then chkDisplayOnly.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Confirmation Report", "SortLastName", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then chkSortName.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Confirmation Report", "PreFormatted", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then chkPreFormat.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Confirmation Report", "ManualConfSel", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then chkManualConf.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Confirmation Report", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
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
   
   Screen.MousePointer = HOURGLASS
   'Clear out working table for this computer name (also done b/4 print of confirmation).
   gBNB.Execute "delete from ConfReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   If Trim(txtShowTop.Text) = "" Then txtShowTop.Text = "50"
   WriteIniSettings

Form_Unload_Resume:
   Screen.MousePointer = DEFAULT
   Dim X&
   X& = SetActiveWindow(mdiBNB.hwnd)
   Exit Sub
   
Form_Unload_Error:
   Resume Form_Unload_Resume
   
End Sub


