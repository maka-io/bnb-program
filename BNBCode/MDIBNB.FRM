VERSION 5.00
Object = "{00025600-0000-0000-C000-000000000046}#5.1#0"; "CRYSTL32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.MDIForm mdiBNB 
   BackColor       =   &H8000000C&
   Caption         =   "BnB"
   ClientHeight    =   7548
   ClientLeft      =   180
   ClientTop       =   1320
   ClientWidth     =   11052
   Icon            =   "MDIBNB.frx":0000
   ScrollBars      =   0   'False
   WindowState     =   2  'Maximized
   Begin Crystal.CrystalReport Report1 
      Left            =   1860
      Top             =   6600
      _ExtentX        =   593
      _ExtentY        =   593
      _Version        =   348160
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
      Left            =   1320
      Top             =   6600
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      HelpContext     =   100
   End
   Begin VB.Menu mnuFile 
      Caption         =   "&File"
      Begin VB.Menu mnuBackup 
         Caption         =   "&Backup Database"
      End
      Begin VB.Menu mnuCommonText 
         Caption         =   "Common &Text"
      End
      Begin VB.Menu mnuPrinterSetup 
         Caption         =   "&Printer Setup..."
      End
      Begin VB.Menu mnuExit 
         Caption         =   "E&xit"
         Shortcut        =   ^X
      End
   End
   Begin VB.Menu mnuGuestData 
      Caption         =   "&Guests"
      Begin VB.Menu mnuGeneralInfo 
         Caption         =   "&General Information"
      End
      Begin VB.Menu mnuAccommodations 
         Caption         =   "&Accommodations"
      End
      Begin VB.Menu mnuTravelAgent 
         Caption         =   "&Travel Agency"
      End
      Begin VB.Menu mnuAutomobile 
         Caption         =   "&Car Reservations"
      End
      Begin VB.Menu mnuPaymentHistory 
         Caption         =   "&Payments"
      End
      Begin VB.Menu mnuLine1 
         Caption         =   "----------------------------------"
         Enabled         =   0   'False
         Visible         =   0   'False
      End
      Begin VB.Menu mnuPayToHost 
         Caption         =   "&Host/Travel/Refund Payments"
         Visible         =   0   'False
      End
      Begin VB.Menu mnuAuditTrail 
         Caption         =   "Accommodation A&udit Trail"
         Visible         =   0   'False
      End
   End
   Begin VB.Menu mnuAccounts 
      Caption         =   "&Accounts"
      Begin VB.Menu mnuHostAccountData 
         Caption         =   "&Host Properties"
      End
      Begin VB.Menu mnuTravelAgencyAccountData 
         Caption         =   "&Travel Agencies"
      End
      Begin VB.Menu mnuCarRentalAgencyData 
         Caption         =   "&Car Rental Agencies"
      End
   End
   Begin VB.Menu mnuAvailability 
      Caption         =   "A&vailability"
   End
   Begin VB.Menu mnuReports 
      Caption         =   "&Reports"
      Begin VB.Menu mnuConfirmations 
         Caption         =   "C&onfirmation/Fee Summary Report"
      End
      Begin VB.Menu mnuArriveDepart 
         Caption         =   "&Arrivals/Departures"
      End
      Begin VB.Menu mnuDaily 
         Caption         =   "&Daily Reports"
         Begin VB.Menu mnuDailyBooking 
            Caption         =   "Daily &Booking Report"
         End
         Begin VB.Menu mnuArrivals 
            Caption         =   "&Arrivals"
         End
         Begin VB.Menu mnuDepartures 
            Caption         =   "&Departures"
         End
         Begin VB.Menu mnuHostNotification 
            Caption         =   "&Host Notification Report"
         End
         Begin VB.Menu mnuPaymentsDue 
            Caption         =   "&Payments Receivable"
            Visible         =   0   'False
         End
      End
      Begin VB.Menu mnuCheckLedger 
         Caption         =   "&Check Ledger Summary Report"
      End
      Begin VB.Menu mnuNetSummary 
         Caption         =   "&Net Summary Report"
      End
      Begin VB.Menu mnuServiceFeeSummary 
         Caption         =   "&Service Fee Summary Report"
      End
      Begin VB.Menu mnuCommission 
         Caption         =   "Co&mmission Report"
      End
      Begin VB.Menu mnuPaymentsRec 
         Caption         =   "&Payments Received"
         Begin VB.Menu mnuPayRecSummary 
            Caption         =   "Payments &Received Report"
         End
         Begin VB.Menu mnuClientTrust 
            Caption         =   "&Client Trust Reconciliation"
         End
      End
      Begin VB.Menu mnuPayReceivable 
         Caption         =   "Pa&yments Receivable"
      End
      Begin VB.Menu mnuRefunds 
         Caption         =   "&Refunds"
      End
      Begin VB.Menu mnuOverPay 
         Caption         =   "O&verpayments To Host Properties"
      End
      Begin VB.Menu mnuTax1099 
         Caption         =   "&Host 1099 Tax Forms"
      End
      Begin VB.Menu mnuHostAcctListing 
         Caption         =   "Host Account &Information"
      End
      Begin VB.Menu mnuCarRentalActivity 
         Caption         =   "Car R&ental Activity"
      End
      Begin VB.Menu mnuTrends 
         Caption         =   "&Trends"
      End
   End
   Begin VB.Menu mnuAccounting 
      Caption         =   "A&ccounting"
      Begin VB.Menu mnuChecking 
         Caption         =   "&Checks"
         Begin VB.Menu mnuPrintChecks 
            Caption         =   "&Print Checks"
         End
         Begin VB.Menu mnuCheckEdit 
            Caption         =   "&View/Edit Printed Checks"
         End
         Begin VB.Menu mnuSetCheckNum 
            Caption         =   "Set Check &Numbers"
         End
      End
      Begin VB.Menu mnuPaymentReceived 
         Caption         =   "&View/Edit Payments Received"
      End
   End
   Begin VB.Menu mnuTaxes 
      Caption         =   "&Taxes"
      Begin VB.Menu mnuSetTaxRates 
         Caption         =   "Set Tax &Rates"
      End
      Begin VB.Menu mnuSetTaxPlans 
         Caption         =   "Set Tax &Plans"
      End
   End
   Begin VB.Menu mnuView 
      Caption         =   "&View"
      Begin VB.Menu mnuCascadeForms 
         Caption         =   "&Cascade Forms"
      End
   End
   Begin VB.Menu mnuAdmin 
      Caption         =   "A&dmin"
      Begin VB.Menu mnuMasterFactsList 
         Caption         =   "&Property Facts Master List"
      End
      Begin VB.Menu mnuCompanyInfo 
         Caption         =   "Company &Information"
      End
      Begin VB.Menu mnuRestore 
         Caption         =   "&Restore Database"
      End
   End
   Begin VB.Menu mnuHelp 
      Caption         =   "&Help"
      Begin VB.Menu mnuHelpTopics 
         Caption         =   "Help Topics"
      End
      Begin VB.Menu mnuVersion 
         Caption         =   "&About"
      End
   End
End
Attribute VB_Name = "mdiBNB"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim SAW As Long
Dim SSTemp As Recordset



 Private Sub MDIForm_Load()

  On Error GoTo Load_Error
  Screen.MousePointer = HOURGLASS
  
  Dim vPosition As Integer

  DEMO = False
  gVersion = "2.0"
    
  Dim Response As Variant
  Response = App.PrevInstance
  'MsgBox Str(Response) & ", " & App.EXEName
  If App.PrevInstance Then
     gMsg = "A previous instance of this program is already running " & _
            "and might be minimized in the task bar."
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     End
  End If
    
  '*** In Setup, if Setup As Server is chosen,path will be written to .ini file
  '(in format ServerPath=<drive>:\bnb1\) in users windows dir. If not chosen as server,
  'user will browse network for the machine chosen as server and set path as format
  ' \\SERVERNAME\SHAREDRIVE\BNB1\
  
  'Get Path and database name fron BNB1.INI created by Setup prog.
  'The following will be set by call to GetIniSettings:
  '  1. gDatabaseName - Global Path + Database Name (eg, (\\BESTBNB1\BNB\) + (BNB1.MDB) )
  GetIniSettings
  
  'Get DB path
  vPosition = InStr(1, gDatabaseName, "BNB1.MDB", 1) - 1
  gDBDirectory = Left(gDatabaseName, vPosition)
  'MsgBox gDBDirectory
  'Open database
  Set gBNB = Workspaces(0).OpenDatabase(gDatabaseName, False, False, "")
  
  Temp1$ = Space(145)                ' Size Buffer
  X& = GetComputerName(Temp1$, 145)  ' Make API Call
  'Set global computer name variable
  gComputerName = CStr(Trim$(Temp1$))
  'Remove hidden Null at end of string (or you cannot concatenate to it)
  gComputerName = Left(gComputerName, Len(gComputerName) - 1)
  If gComputerName = "" Then
     MsgBox "Computer's Identification (Name) has not been set. Set Identification in Network section of Control Panel.", MB_ICONSTOP, Me.Caption
     End
  End If
  gTableName = gComputerName & "_10" 'Set initial temp table name. Users can create 88 temp tables per session.
  'Clean out any temporary tables created from last session.
  '(Of the form: BESTBNB4_xx)
  gSQL = "select name from MSysObjects where name like " & Chr$(34) & gComputerName & "_*" & Chr$(34)
  Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount > 0 Then
    For i = 0 To SSTemp.RecordCount - 1
      'MsgBox SSTemp("name")
      gBNB.Execute "DROP TABLE " & SSTemp("name") & ";"
      SSTemp.MoveNext
    Next i
  End If
  'Set global conf number
  gConfNum = 0
  'Set the help file location to local machine setup folder.
  App.HelpFile = gSetupDirectory & "bnbhelp.hlp"
  'Set caption if DEMO
  If DEMO Then Me.Caption = Me.Caption & " - DEMO Version"
  'Clear out insert control tables
  gBNB.Execute "delete * from GuestInsertControl where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  gBNB.Execute "delete * from HostInsertControl where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  gBNB.Execute "delete * from AgencyInsertControl where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  gBNB.Execute "delete * from RoomTypeInsertControl where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  gBNB.Execute "delete * from CarAgencyInsertControl where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  
MDIForm_Load_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
 
Load_Error:
  If Err = 3045 Then
     MsgBox "Users locked out until pending backup operation is complete.", MB_ICONSTOP, Me.Caption
  Else
     MsgBox Str(Err) & ", " & Err.Description
  End If
  End
  'Resume MDIForm_Load_Resume
  
End Sub


Private Sub MDIForm_QueryUnload(Cancel As Integer, UnloadMode As Integer)
 
 On Error GoTo MDIForm_Error
 Dim TempStr As String
 For i = 0 To Forms.Count - 1
     TempStr = GetFormMode(Forms(i))
     Select Case TempStr
       Case "Insert"
         MsgBox "Cancel pending Insert operation before exiting.", MB_ICONSTOP, Me.Caption
         Cancel = 1
         Exit For
       Case "Update"
         MsgBox "Cancel pending Update operation before exiting.", MB_ICONSTOP, Me.Caption
         Cancel = 1
         Exit For
       Case Else
     End Select
 Next i
 If Cancel = 1 Then
    If Forms(i).WindowState = MINIMIZED Then
       Dim X&
       Forms(i).SetFocus
       X& = ShowWindow(Forms(i).hwnd, SW_SHOWNORMAL)
    Else
       Forms(i).Show
       Forms(i).SetFocus
    End If
 End If

MDIForm_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
MDIForm_Error:
   Resume MDIForm_Resume

End Sub


Private Sub MDIForm_Unload(Cancel As Integer)
  
  On Error GoTo MDI_Form_Error
  
  'Unload any hidden dialog boxes
  If FormLoaded(frmTaxPlan) Then Unload frmTaxPlan
  If FormLoaded(frmTrendsDialog) Then Unload frmTrendsDialog
  If FormLoaded(frmListDialog) Then Unload frmListDialog
  If FormLoaded(frmConfDlg) Then Unload frmConfDlg
  If FormLoaded(frmDBBackup) Then Unload frmDBBackup
  If FormLoaded(frmLabelDialog) Then Unload frmLabelDialog
  If FormLoaded(frmRefund) Then Unload frmRefund
  If FormLoaded(frmClientTrust) Then Unload frmClientTrust
  'Drop any temporary tables created during this session.
  'Tables are of the form: MYCOMPUTERNAME_23
  gSQL = "select name from MSysObjects where name like " & Chr$(34) & gComputerName & "_*" & Chr$(34)
  Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
  If SSTemp.RecordCount > 0 Then
    GetSSRows SSTemp
    'Delete tables
    For i = 0 To SSTemp.RecordCount - 1
      'MsgBox SSTemp("name")
      gBNB.Execute "DROP TABLE " & SSTemp("name") & ";"
      SSTemp.MoveNext
    Next i
  End If
  'Clear out LabelSupport table
  gBNB.Execute "delete from LabelSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  'Clear out insert control tables
  gBNB.Execute "delete * from GuestInsertControl where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  gBNB.Execute "delete * from HostInsertControl where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  gBNB.Execute "delete * from AgencyInsertControl where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  gBNB.Execute "delete * from RoomTypeInsertControl where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  gBNB.Execute "delete * from CarAgencyInsertControl where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  'Close Database
  gBNB.Close
  'Close any previously activated help session.
  CloseHelpApp
  
MDI_Form_Resume:
  Exit Sub
  
MDI_Form_Error:
   Resume MDI_Form_Resume
   
End Sub



Private Sub mnuAccommodations_Click()

   Screen.MousePointer = HOURGLASS
   If frmAccommodations.WindowState = MINIMIZED Then
      Dim X&
      frmAccommodations.SetFocus
      X& = ShowWindow(frmAccommodations.hwnd, SW_SHOWNORMAL)
   Else
      frmAccommodations.Show
      frmAccommodations.SetFocus
   End If
   Screen.MousePointer = DEFAULT
   
End Sub

Private Sub mnuArrivals_Click()

   On Error GoTo mnuArrivals_Click_Error
   
   Dim X As String
   Dim vDays As Integer
   Dim vSYear, vSMonth, vSDay As String
   Dim vEYear, vEMonth, vEDay As String
   Dim vStartDate, vEndDate As String
   NL$ = Chr$(13) & Chr$(10)   'New Line of text.
   
   'Get Saved settings.
   Dim Z As Integer        'Return Value
   Dim Rs As String * 200  'Return String
   Dim winDir, Temp, iniFile As String
   'Initialize variables
   Rs = Space$(Len(Rs))
   'Get the directory in which the Windows and the .INI files reside.
   'Note that GetPrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
   winDir = UCase$(GetWindowsDir())
   'Determine the target .ini file
   iniFile = winDir & UCase$(App.EXEName) & ".INI"
   Z = GetPrivateProfileString("Daily Reports", "Arrivals", 2, Rs, Len(Rs), iniFile)
   If Z > 0 Then vDays = Left$(Rs, Z)     ' Trim Buffer 'a string was returned.
   
   gMsg = "Example format: " & NL$ & NL$ & "2  (shows arrivals for today and the next 2 days)" & _
          NL$ & "0  (shows arrivals for today)" & _
          NL$ & "-2 (shows arrivals for today and the previous 2 days)"
   X = InputBox(gMsg, "Daily Arrivals Report", vDays, , , App.HelpFile, 123)
   If X = "" Then Exit Sub
   If Not IsNumeric(X) Then
      MsgBox "Number of days must be numeric.", MB_ICONSTOP, Me.Caption
      GoTo mnuArrivals_Click_Resume
   End If
   'Write INI settings:
   'Get the directory in which the Windows and the .INI files reside.
   'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
   winDir = UCase$(GetWindowsDir())
   'Detemine the target .ini file
   iniFile = winDir & UCase$(App.EXEName) & ".INI"
   Z = WritePrivateProfileString("Daily Reports", "Arrivals", X, iniFile)
    
   Screen.MousePointer = HOURGLASS
   If X < 0 Then
      vStartDate = DateAdd("d", X, Format(Now, "m/d/yyyy"))
      vEndDate = Format(Now, "m/d/yyyy")
   ElseIf X = 0 Then
      vStartDate = Format(Now, "m/d/yyyy")
      vEndDate = Format(Now, "m/d/yyyy")
   Else
      vStartDate = Format(Now, "m/d/yyyy")
      vEndDate = DateAdd("d", X, Format(Now, "m/d/yyyy"))
   End If
   'Set start date
   vSYear = DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy"))
   vSMonth = DatePart("m", Format(vStartDate, "mm/dd/yyyy"))
   vSDay = DatePart("d", Format(vStartDate, "mm/dd/yyyy"))
   'Set end date
   vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
   vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
   vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
   
   Report1.ReportFileName = gDBDirectory & "Arrival1.rpt"
   Report1.SelectionFormula = "{bbtbl.ArrDate} >= Date(" & _
                                  vSYear & "," & vSMonth & "," & vSDay & ")" & _
                                  " And {bbtbl.ArrDate} <= Date(" & _
                                  vEYear & "," & vEMonth & "," & vEDay & ")"
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(Report1.SortFields(vCount)) <> ""
     Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   Report1.SortFields(0) = "+{bbtbl.arrdate}"
   Report1.Destination = 0
   Report1.Action = 1
   
mnuArrivals_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

mnuArrivals_Click_Error:
   GoTo mnuArrivals_Click_Resume
   
End Sub

Private Sub mnuArriveDepart_Click()

   On Error GoTo mnuArriveDepart_Click_Error
   frmArriveDepart.Show 1
   If Not FormLoaded(frmArriveDepart) Then GoTo mnuArriveDepart_Click_Resume
   Dim X As String
   Dim vSYear, vSMonth, vSDay As String
   Dim vEYear, vEMonth, vEDay As String
   Dim vStartDate, vEndDate As String
   NL$ = Chr$(13) & Chr$(10)   'New Line of text.

  If Trim(frmArriveDepart.txtEndDate.Text) <> "" Then
     vEndDate = Format(Trim(frmArriveDepart.txtEndDate.Text), "mm/dd/yyyy")
     vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
     vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
     vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
  End If
  Screen.MousePointer = HOURGLASS
  vStartDate = Format(Trim(frmArriveDepart.txtStartDate.Text), "mm/dd/yyyy")
  'Set start year values
  vSYear = DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy"))
  vSMonth = DatePart("m", Format(vStartDate, "mm/dd/yyyy"))
  vSDay = DatePart("d", Format(vStartDate, "mm/dd/yyyy"))

   Screen.MousePointer = HOURGLASS
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(Report1.SortFields(vCount)) <> ""
     Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   If frmArriveDepart.optArrivals.Value = CHECKED Then
      Report1.ReportFileName = gDBDirectory & "Arrival1.rpt"
      Report1.SortFields(0) = "+{bbtbl.arrdate}"
      Report1.SortFields(1) = "+{bbtbl.l_name}"
   Else
      Report1.ReportFileName = gDBDirectory & "Depart1.rpt"
      Report1.SortFields(0) = "+{bbtbl.depdate}"
      Report1.SortFields(1) = "+{bbtbl.l_name}"
   End If
   If vEndDate <> "" Then
      If frmArriveDepart.optArrivals.Value = CHECKED Then
         Report1.SelectionFormula = "{bbtbl.ArrDate} >= Date(" & _
                                  vSYear & "," & vSMonth & "," & vSDay & ")" & _
                                  " And {bbtbl.ArrDate} <= Date(" & _
                                  vEYear & "," & vEMonth & "," & vEDay & ")"
      Else
         Report1.SelectionFormula = "{bbtbl.DepDate} >= Date(" & _
                                  vSYear & "," & vSMonth & "," & vSDay & ")" & _
                                  " And {bbtbl.DepDate} <= Date(" & _
                                  vEYear & "," & vEMonth & "," & vEDay & ")"
      End If
   Else
      If frmArriveDepart.optArrivals.Value = CHECKED Then
         Report1.SelectionFormula = "{bbtbl.ArrDate} >= Date(" & _
                                  vSYear & "," & vSMonth & "," & vSDay & ")"
      Else
         Report1.SelectionFormula = "{bbtbl.DepDate} >= Date(" & _
                                  vSYear & "," & vSMonth & "," & vSDay & ")"
      End If
   End If
   Report1.Destination = 0
   Report1.Action = 1
   
mnuArriveDepart_Click_Resume:
   If FormLoaded(frmArriveDepart) Then Unload frmArriveDepart
   Screen.MousePointer = DEFAULT
   Exit Sub

mnuArriveDepart_Click_Error:
   MsgBox Err.Description
   GoTo mnuArriveDepart_Click_Resume
End Sub


Private Sub mnuAuditTrail_Click()
  
    Screen.MousePointer = HOURGLASS
    gCaption = "Accommodation Audit Trail Listing"
    gSQL = "select Conf,Action,ActionDate," & _
           "Location,UnitName," & _
           "NumPty,ArrDate,DepDate, " & _
           "PymtType,GrosRate,Suppress,ComputerName " & _
           "from AccomAudit where conf = " & gConfNum & _
           " order by Accom_RowID,ActionDate "
    Dim frmNewBoundListing As New frmBoundListing  ' Declare form variable
    frmNewBoundListing.Show     ' Load and display new instance
 
End Sub

Private Sub mnuAutomobile_Click()

   Screen.MousePointer = HOURGLASS
   If frmGuestCar.WindowState = MINIMIZED Then
      Dim X&
      frmGuestCar.SetFocus
      X& = ShowWindow(frmGuestCar.hwnd, SW_SHOWNORMAL)
   Else
      frmGuestCar.Show
      frmGuestCar.SetFocus
   End If
   Screen.MousePointer = DEFAULT
   
End Sub

Private Sub mnuAvailability_Click()

   Screen.MousePointer = HOURGLASS
   If frmAvailability.WindowState = MINIMIZED Then
      Dim X&
      frmAvailability.SetFocus
      X& = ShowWindow(frmAvailability.hwnd, SW_SHOWNORMAL)
   Else
      frmAvailability.Show
      frmAvailability.SetFocus
   End If
   Screen.MousePointer = DEFAULT
       
End Sub

Private Sub mnuBackup_Click()
   
    On Error GoTo mnuBackup_Click_Error2

   'Cancel all pending Updates/Inserts before backup
    Dim TempStr, DBPathOnly As String
    DBPathOnly = Left(gDatabaseName, InStr(1, gDatabaseName, "BNB1.MDB", 1) - 1)
    
    For i = 0 To Forms.Count - 1
      If Forms(i).Name <> "mdiBNB" And Forms(i).Name <> "frmDBBackup" Then
        TempStr = GetFormMode(Forms(i))
        Select Case TempStr
          Case "Insert"
            MsgBox "Please cancel pending Insert operations and close all forms before backing up.", MB_ICONSTOP, Me.Caption
            GoTo mnuBackup_Click_Resume
          Case "Update"
            MsgBox "Please cancel pending Update operations and close all forms before backing up.", MB_ICONSTOP, Me.Caption
            GoTo mnuBackup_Click_Resume
          Case Else
            'MsgBox "Please close all forms before backing up.", MB_ICONSTOP, Me.Caption
            'GoTo mnuBackup_Click_Resume
        End Select
      End If
    Next i
    Screen.MousePointer = HOURGLASS
    frmDBBackup.CMDialog1.DialogTitle = "Backup Database"
    frmDBBackup.Caption = "Database Backup Dialog Box"
    frmDBBackup.lblFileName.Caption = "Backup to:"
    frmDBBackup.Show 1
    
    If Not FormLoaded(frmDBBackup) Then GoTo mnuBackup_Click_Resume

    If frmDBBackup.optCancelled = True Then GoTo mnuBackup_Click_Resume
    gMsg = "Backing up database. Please wait..."
    frmStatus.Show
    Screen.MousePointer = HOURGLASS
    'Allow status form to paint fully
    For i = 1 To 3
      DoEvents
    Next i
    'Refresh screeen. After initial message of other attached users, and
    'subsequent closing of those applications, code still thinks users are attached
    'and backup cannot continue. The SendKeys fixes this.
    SendKeys "%{F5}", True
    'Close the Database
    gBNB.Close
    'Need to reconnect DB if error occurs
    On Error GoTo mnuBackup_Click_Error
    'Compact the database to temporary file BNB1BACK.MDB on hard disk
    CompactDatabase gDatabaseName, gDBDirectory & "BNB1BACK.MDB"
    'No need to reconnect DB if error occurs
    On Error GoTo mnuBackup_Click_Error2
    'Reconnect database
    Set gBNB = Workspaces(0).OpenDatabase(gDatabaseName, False, False, "")
    'Copy temporary file to desired location
    FileCopy gDBDirectory & "BNB1BACK.MDB", frmDBBackup.CMDialog1.filename
    'Get rid of temporary file on hard disk
    If FileExists(gDBDirectory & "BNB1BACK.MDB") Then Kill gDBDirectory & "BNB1BACK.MDB"
    
mnuBackup_Click_Resume:
    If FileExists(gDBDirectory & "BNB1BACK.MDB") Then Kill gDBDirectory & "BNB1BACK.MDB"
    If FormLoaded(frmStatus) Then Unload frmStatus
    If FormLoaded(frmDBBackup) Then Unload frmDBBackup
    Screen.MousePointer = DEFAULT
    Exit Sub
    
mnuBackup_Click_Error:
    'Reconnect database
    Set gBNB = Workspaces(0).OpenDatabase(gDatabaseName, False, False, "")
    'User pressed cancel button is Err 32755
    If Err = 32755 Then
        'Do nothing
    ElseIf Err = 3196 Or Err = 3356 Then
        '3196 = Database already in use. (Can't perform compact)
        '3356 = Attempt to open database that is exclusively opened by ...
        MsgBox "All other users must exit program before backup can take place.", MB_ICONSTOP, Me.Caption
    ElseIf Err = 75 Or Err = 70 Then
        MsgBox "Cannot backup to the same directory or filename as active database file (BNB1.MDB).", MB_ICONSTOP, Me.Caption
    Else
        MsgBox Str(Err) & ", " & Err.Description
    End If
    Resume mnuBackup_Click_Resume

mnuBackup_Click_Error2:
    'User pressed cancel button is Err 32755
    If Err = 32755 Then
        'Do nothing
    ElseIf Err = 3196 Or Err = 3356 Then
        '3196 = Database already in use. (Can't perform compact)
        '3356 = Attempt to open database that is exclusively opened by ...
        MsgBox "All other users must exit program before backup can take place.", MB_ICONSTOP, Me.Caption
    ElseIf Err = 75 Or Err = 70 Then
        MsgBox "Cannot backup to the same directory or filename as active database file (" & gDatabaseName & ").", MB_ICONSTOP, Me.Caption
    Else
        MsgBox Str(Err) & ", " & Err.Description
    End If
    Resume mnuBackup_Click_Resume
      
End Sub





Private Sub mnuCarRentalActivity_Click()
    
  'This Sub will drive the Crystal report CarActiv.rpt
  On Error GoTo mnuCarRentalActivity_Click_Error
  Screen.MousePointer = HOURGLASS
  Set SSTemp = gBNB.OpenRecordset("SELECT COUNT(*) from cartbl", dbOpenSnapshot)
  GetSSRows SSTemp
  'Get out if no rows
  If SSTemp(0) <= 0 Then
     SSTemp.Close
     gMsg = "No car reservations have been entered into database."
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo mnuCarRentalActivity_Click_Resume
  End If
  SSTemp.Close
  frmCarRentalActivity.Show 1
  If Not FormLoaded(frmCarRentalActivity) Then GoTo mnuCarRentalActivity_Click_Resume
  Screen.MousePointer = HOURGLASS
  Dim vNowTemp As Date
  Dim vNumMonths As Integer
  Dim vSYear, vSMonth, vSDay As String
  Dim vEYear, vEMonth, vEDay As String
  Dim vStartDate, vEndDate, vCategory As String
  Dim vAccountNum As Long
  Dim vSelectConfs, vSelectConfsForRpt As String
  
  If Trim(frmCarRentalActivity.txtStartDate.Text) = "" Then
     MsgBox "Starting Date cannot be blank.", MB_ICONSTOP, Me.Caption
     GoTo mnuCarRentalActivity_Click_Resume
  End If

  If Trim(frmCarRentalActivity.txtEndDate.Text) <> "" Then
     If CDate(frmCarRentalActivity.txtStartDate.Text) > CDate(frmCarRentalActivity.txtEndDate.Text) Then
        MsgBox "Starting Date cannot be greater than ending date.", MB_ICONSTOP, Me.Caption
        GoTo mnuCarRentalActivity_Click_Resume
     End If
     vEndDate = Format(Trim(frmCarRentalActivity.txtEndDate.Text), "mm/dd/yyyy")
     vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
     vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
     vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
  End If
  Screen.MousePointer = HOURGLASS
  vStartDate = Format(Trim(frmCarRentalActivity.txtStartDate.Text), "mm/dd/yyyy")
  'Set start year values
  vSYear = DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy"))
  vSMonth = DatePart("m", Format(vStartDate, "mm/dd/yyyy"))
  vSDay = DatePart("d", Format(vStartDate, "mm/dd/yyyy"))
  'Clear out support table
  gBNB.Execute "delete from TACommReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34) & ";"
  If vEndDate <> "" Then
     If frmCarRentalActivity.optPickUp.Value = CHECKED Then
        vSelectConfs = "where [cartbl].[pudate] >= #" & vStartDate & "# " & _
                       "and [cartbl].[pudate] <= #" & vEndDate & "#"
        vSelectConfsForRpt = " And {cartbl.PUDate} >= Date(" & _
                              DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                              DatePart("m", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                              DatePart("d", Format(vStartDate, "mm/dd/yyyy")) & ") " & _
                              "And {cartbl.PUDate} <= Date(" & _
                              DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy")) & "," & _
                              DatePart("m", Format(vEndDate, "mm/dd/yyyy")) & "," & _
                              DatePart("d", Format(vEndDate, "mm/dd/yyyy")) & ")"
     ElseIf frmCarRentalActivity.optDropOff.Value = CHECKED Then
        vSelectConfs = "where [cartbl].[dropdate] >= #" & vStartDate & "# " & _
                       "and [cartbl].[dropdate] <= #" & vEndDate & "#"
        vSelectConfsForRpt = " And {cartbl.DropDate} >= Date(" & _
                              DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                              DatePart("m", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                              DatePart("d", Format(vStartDate, "mm/dd/yyyy")) & ") " & _
                              "And {cartbl.DropDate} <= Date(" & _
                              DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy")) & "," & _
                              DatePart("m", Format(vEndDate, "mm/dd/yyyy")) & "," & _
                              DatePart("d", Format(vEndDate, "mm/dd/yyyy")) & ")"
     End If
  Else 'Ending date is blank
     If frmCarRentalActivity.optPickUp.Value = CHECKED Then
        vSelectConfs = "where [cartbl].[pudate] >= #" & vStartDate & "#"
        vSelectConfsForRpt = " And {cartbl.PUDate} >= Date(" & _
                              DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                              DatePart("m", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                              DatePart("d", Format(vStartDate, "mm/dd/yyyy")) & ") "
     ElseIf frmCarRentalActivity.optDropOff.Value = CHECKED Then
        vSelectConfs = "where [cartbl].[dropdate] >= #" & vStartDate & "#"
        vSelectConfsForRpt = " And {cartbl.DropDate} >= Date(" & _
                              DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                              DatePart("m", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                              DatePart("d", Format(vStartDate, "mm/dd/yyyy")) & ")"
     End If
  End If
  gSQL = "insert into TACommReportSupport(conf, SumTACommish,MinArrDate,MaxDepDate,ComputerName) " & _
         "select [cartbl].[conf],Null,min(cartbl.pudate),max(cartbl.dropdate)," & Chr$(34) & gComputerName & Chr$(34) & _
         " from cartbl " & _
         vSelectConfs & _
         " group by [cartbl].[conf];"
         '!!!Aggregates must be in group
  gBNB.Execute gSQL
  'User typed in agency name.
  frmCarRentalActivity.datdwComboAgency.Text = Trim(frmCarRentalActivity.datdwComboAgency.Text)
  If Trim(frmCarRentalActivity.lblAcctNum.Caption) = "" And frmCarRentalActivity.datdwComboAgency.Text <> "" Then
     'Remove ' from query.
     frmCarRentalActivity.datdwComboAgency.Text = Replace_All_In_With("'", Trim(frmCarRentalActivity.datdwComboAgency.Text), "*")
     Report1.SelectionFormula = "{TACommReportSupport.conf}={cartbl.conf} " & _
                                " And {TACommReportSupport.ComputerName} = '" & _
                                gComputerName & "' " & vSelectConfsForRpt & _
                                " And UpperCase({CarMaster.AgencyName}) like '" & _
                                UCase(frmCarRentalActivity.datdwComboAgency.Text) & "*'"
  'User selected agency from the list
  ElseIf frmCarRentalActivity.lblAcctNum.Caption <> "" And Trim(frmCarRentalActivity.datdwComboAgency.Text) <> "" Then
     Report1.SelectionFormula = "{TACommReportSupport.conf}={cartbl.conf} " & _
                                " And {TACommReportSupport.ComputerName} = '" & _
                                gComputerName & "' " & vSelectConfsForRpt & _
                                " And {cartbl.AccountNum} = " & _
                                frmCarRentalActivity.lblAcctNum.Caption
  'User did not select or type in an agency
  Else
     Report1.SelectionFormula = "{TACommReportSupport.conf}={cartbl.conf} " & _
                                " And {TACommReportSupport.ComputerName} = '" & _
                                gComputerName & "' " & vSelectConfsForRpt
  End If
  'Set Sort order
  'Since several reports are sharing the mdiBNB.Report1 control, the sort
  'array MUST be cleared out or values from previous report will be saved in the
  'array causing 'Unknown Field Name' error
  Dim vCount As Integer
  vCount = 0
  While Trim(Report1.SortFields(vCount)) <> ""
    Report1.SortFields(vCount) = ""
    vCount = vCount + 1
  Wend
  If frmCarRentalActivity.optPickUp.Value = CHECKED Then
      'Report1.SortFields(0) = "+{cartbl.AgencyName}"
      Report1.SortFields(0) = "+{cartbl.PUDate}"
  ElseIf frmCarRentalActivity.optDropOff.Value = CHECKED Then
      'Report1.SortFields(0) = "+{cartbl.AgencyName}"
      Report1.SortFields(0) = "+{cartbl.DropDate}"
  End If
  Report1.ReportFileName = gDBDirectory & "CarActiv.rpt"
  Report1.DataFiles(0) = gDatabaseName
  Report1.Destination = 0
  'Print report for current Account Num.
  Report1.Action = 1
  'Clear out support table
  gBNB.Execute "delete from TACommReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34) & ";"
  
mnuCarRentalActivity_Click_Resume:
   If FormLoaded(frmCarRentalActivity) Then Unload frmCarRentalActivity
   Screen.MousePointer = DEFAULT
   Exit Sub

mnuCarRentalActivity_Click_Error:
   MsgBox Err.Description
   GoTo mnuCarRentalActivity_Click_Resume
   
End Sub

Private Sub mnuCarRentalAgencyData_Click()

   Screen.MousePointer = HOURGLASS
   If frmCarAccount.WindowState = MINIMIZED Then
      Dim X&
      frmCarAccount.SetFocus
      X& = ShowWindow(frmCarAccount.hwnd, SW_SHOWNORMAL)
   Else
      frmCarAccount.Show
      frmCarAccount.SetFocus
   End If
   Screen.MousePointer = DEFAULT
   
End Sub


Private Sub mnuCascadeForms_Click()
   mdiBNB.Arrange vbCascade
End Sub




Private Sub mnuCheckEdit_Click()

   Screen.MousePointer = HOURGLASS
   If frmCheckEdit.WindowState = MINIMIZED Then
      Dim X&
      frmCheckEdit.SetFocus
      X& = ShowWindow(frmCheckEdit.hwnd, SW_SHOWNORMAL)
   Else
      frmCheckEdit.Show
      frmCheckEdit.SetFocus
   End If
   Screen.MousePointer = DEFAULT
   
End Sub

Private Sub mnuCheckLedger_Click()
   Screen.MousePointer = HOURGLASS
   'gSummReportName = "CheckLedger"
   frmCheckLedger.Show 1
   Screen.MousePointer = DEFAULT
End Sub

Private Sub mnuClientTrust_Click()
  
  On Error GoTo mnuClientTrust_Click_Error
  
  frmClientTrust.Show 1
  If Not FormLoaded(frmClientTrust) Then GoTo mnuClientTrust_Click_Resume
  Screen.MousePointer = HOURGLASS
  Dim vTempStr As String
  Dim i As Integer
  vCount = 0
  Screen.MousePointer = HOURGLASS
     
  If Trim(frmClientTrust.txtStartDate.Text) <> "" And Trim(frmClientTrust.txtEndDate.Text) = "" Then
     vTempStr = "paymentreceived.DateReceived >= #" & frmClientTrust.txtStartDate.Text & "# "
  ElseIf Trim(frmClientTrust.txtStartDate.Text) <> "" And Trim(frmClientTrust.txtEndDate.Text) <> "" Then
     vTempStr = "paymentreceived.DateReceived >= #" & frmClientTrust.txtStartDate.Text & "# " & _
                "AND paymentreceived.DateReceived <= #" & frmClientTrust.txtEndDate.Text & "# "
  End If
  'Clear out support table
  gBNB.Execute "DELETE FROM ClientTrustSupport WHERE computername=" & Chr$(34) & gComputerName & Chr$(34) & ";"
  'Insert payments applied to Deposit.
  gBNB.Execute "INSERT INTO ClientTrustSupport (conf,DateReceived,deposits,checknum,checkamt," & _
         "cash,client,ApplyToDeposit,ApplyToPrepmt,svcfee,refund,net,hostref," & _
         "miscell,AdjustSvcFee,Description,PayRecID,ComputerName) " & _
         "SELECT conf,datereceived,Null,checknumber,amountreceived,Null,ReceivedFrom," & _
         "amountreceived,Null,Null,Null,Null,Null,Null,Null,'',ID," & _
          Chr$(34) & gComputerName & Chr$(34) & _
         " FROM paymentreceived WHERE " & vTempStr & _
         " AND paymentreceived.appliedto = 'Deposit' "
  'Insert payments applied to Prepayment
  gBNB.Execute "INSERT INTO ClientTrustSupport (conf,DateReceived,deposits,checknum,checkamt," & _
         "cash,client,ApplyToDeposit,ApplyToPrepmt,svcfee,refund,net,hostref," & _
         "miscell,AdjustSvcFee,Description,PayRecID,ComputerName) " & _
         "SELECT conf,datereceived,Null,checknumber,amountreceived,Null,ReceivedFrom," & _
         "Null,amountreceived,Null,Null,Null,Null,Null,Null,'',ID," & _
         Chr$(34) & gComputerName & Chr$(34) & _
         " FROM paymentreceived WHERE " & vTempStr & _
         " AND paymentreceived.appliedto = 'Prepayment'"
  'Set service fee as:
  '(Total service fee of non-cancelled accommodations PLUS reservation fee)
  'for each conf number.
  'Service fee is ONLY applied to Prepayment, not Deposit. For most confirmations,
  'there is only one Prepayment received; but there can be multiples. Need to
  'get confirmations that have multiple prepayments received, find the max(prepayment)
  'amount and update the service fee column for that row. If one (or more) max(prepayments)
  'is the same as another, only update the row for one of them. Those conf's with
  'only one prepayment can have service fee updated directly.
  Dim TableName1 As String
  If GetNextTableName() Then
    TableName1 = gTableName
  Else
    MsgBox gMsg
    GoTo mnuClientTrust_Click_Resume
  End If
  'Table to hold confirmation numbers of guests with multiple prepayments
  gBNB.Execute "CREATE TABLE " & TableName1 & " (conf LONG,Prepayment CURRENCY,PayRecID LONG);"
  'For multiple prepayments received, get conf and Max prepayment into temp table
  gBNB.Execute "INSERT INTO " & TableName1 & " (conf,Prepayment,PayRecID) " & _
               "SELECT conf,MAX(ApplyToPrepmt),Null " & _
               "FROM ClientTrustSupport AS cts " & _
               "WHERE cts.ApplyToPrepmt IS NOT NULL " & _
               "And cts.ComputerName=" & Chr$(34) & gComputerName & Chr$(34) & _
               " GROUP BY cts.conf " & _
               "HAVING COUNT(cts.ApplyToPrepmt) > 1"
  'Identify paymentreceived row and stuff ROWID into temp table row
  gBNB.Execute "UPDATE " & TableName1 & " INNER JOIN ClientTrustSupport " & _
               "ON " & TableName1 & ".conf=ClientTrustSupport.Conf AND " & _
               TableName1 & ".Prepayment=ClientTrustSupport.ApplyToPrepmt " & _
               "SET " & TableName1 & ".PayRecID=ClientTrustSupport.PayRecID " & _
               " Where ClientTrustSupport.ComputerName=" & Chr$(34) & gComputerName & Chr$(34)
  'Update all abnormal (more than one prepayment row exists) ClientTrustSupport service fee columns
  Dim vSumSvcFee, vResFee As Currency
  Dim vPayRecID, vConf As Long
  Dim SSTemp2 As Recordset
  'Dim NeedToClose
  'NeedToClose = False
  Set SSTemp = gBNB.OpenRecordset("SELECT conf,PayRecID FROM " & TableName1, dbOpenSnapshot)
  GetSSRows SSTemp
  For i = 0 To SSTemp.RecordCount - 1
     gSQL = "SELECT SUM(bbtbl.svcharge),MAX(guesttbl.resfee) FROM bbtbl,guesttbl " & _
            "Where bbtbl.conf=guesttbl.conf " & _
            "And bbtbl.conf=" & SSTemp(0) & " " & _
            "And (bbtbl.suppress=0 Or (bbtbl.suppress=-1 And bbtbl.forfeit=-1)) "
     Set SSTemp2 = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
     'NeedToClose = True
     GetSSRows SSTemp2
     If IsNull(SSTemp2(0)) Then
        vSumSvcFee = 0
     Else
        vSumSvcFee = SSTemp2(0)
     End If
     If IsNull(SSTemp2(1)) Then
        vResFee = 0
     Else
        vResFee = SSTemp2(1)
     End If
     SSTemp2.Close
     gSQL = "UPDATE ClientTrustSupport " & _
            "SET svcfee=((" & vSumSvcFee & ")+(" & vResFee & ")) " & _
            "WHERE PayRecID=" & SSTemp(1) & _
            " And ComputerName=" & Chr$(34) & gComputerName & Chr$(34)
     gBNB.Execute gSQL
     SSTemp.MoveNext
  Next i
  'If NeedToClose Then SSTemp2.Close
  SSTemp.Close
  'Update all normal (only one prepayment row exists) ClientTrustSupport service fee columns
  'NeedToClose = False
  gSQL = "SELECT conf,PayRecID FROM ClientTrustSupport AS cts " & _
         "WHERE cts.ApplyToPrepmt IS NOT NULL " & _
         "AND cts.conf NOT IN (SELECT conf FROM " & TableName1 & ") " & _
         "AND cts.ComputerName=" & Chr$(34) & gComputerName & Chr$(34)
  Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
  GetSSRows SSTemp
  For i = 0 To SSTemp.RecordCount - 1
     'NeedToClose = True
     gSQL = "SELECT SUM(bbtbl.svcharge),MAX(guesttbl.resfee) FROM bbtbl,guesttbl " & _
            "Where bbtbl.conf=guesttbl.conf " & _
            "And bbtbl.conf=" & SSTemp(0) & " " & _
            "And (bbtbl.suppress=0 Or (bbtbl.suppress=-1 And bbtbl.forfeit=-1)) "
     Set SSTemp2 = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
     GetSSRows SSTemp2
     If IsNull(SSTemp2(0)) Then
        vSumSvcFee = 0
     Else
        vSumSvcFee = SSTemp2(0)
     End If
     If IsNull(SSTemp2(1)) Then
        vResFee = 0
     Else
        vResFee = SSTemp2(1)
     End If
     SSTemp2.Close
     gSQL = "UPDATE ClientTrustSupport " & _
            "SET svcfee=((" & vSumSvcFee & ")+(" & vResFee & ")) " & _
            "WHERE ClientTrustSupport.PayRecID=" & SSTemp(1) & _
            " And ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
     gBNB.Execute gSQL
     SSTemp.MoveNext
  Next i
  'If NeedToClose Then SSTemp2.Close
  SSTemp.Close
  'Update Net column
  gSQL = "UPDATE ClientTrustSupport SET net = (ApplyToPrepmt-svcfee) " & _
         "WHERE Not IsNull(ApplyToPrepmt) And Not IsNull(svcfee) " & _
         " And ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  gBNB.Execute gSQL
  'Set caption for Listing report
  gCaption = "Client Trust Reconciliation Listing"
  'Get Data
  gSQL = "SELECT DateReceived,deposits,checknum,checkamt," & _
         "cash,client,ApplyToDeposit,ApplyToPrepmt,svcfee,net,refund,hostref," & _
         "miscell,AdjustSvcFee,Description,Conf " & _
         "FROM ClientTrustSupport WHERE computername=" & Chr$(34) & gComputerName & Chr$(34) & _
         " ORDER BY DateReceived,Client"
  'frmBoundListing.Show
  Dim frmNewBoundListing As New frmBoundListing  ' Declare form variable
  frmNewBoundListing.Show     ' Load and display new instance
  'Unload Client Trust dialog
  If FormLoaded(frmClientTrust) Then Unload frmClientTrust
  
mnuClientTrust_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

mnuClientTrust_Click_Error:
   MsgBox Err.Description
   GoTo mnuClientTrust_Click_Resume
   
End Sub

Private Sub mnuCommission_Click()
   Screen.MousePointer = HOURGLASS
   frmCommissionDlg.Show 1
End Sub

Private Sub mnuCommonText_Click()
    Screen.MousePointer = HOURGLASS
    frmCommonText.Show 1
End Sub

Private Sub mnuCompanyInfo_Click()
   
   Screen.MousePointer = HOURGLASS
   If frmCompanyInfo.WindowState = MINIMIZED Then
      Dim X&
      frmCompanyInfo.SetFocus
      X& = ShowWindow(frmCompanyInfo.hwnd, SW_SHOWNORMAL)
   Else
      frmCompanyInfo.Show
      frmCompanyInfo.SetFocus
   End If
   Screen.MousePointer = DEFAULT
   
End Sub

Private Sub mnuConfirmations_Click()
  Screen.MousePointer = HOURGLASS
  frmConfDlg.Show 1
  Screen.MousePointer = DEFAULT
End Sub

Private Sub mnuDailyBooking_Click()

   On Error GoTo mnuDailyBooking_Click_Error
   
   Dim vDate As Variant
   
   vDate = InputBox("Show booking activity for this date:", "Daily Booking Report", Format(Now, "m/d/yyyy"), , , App.HelpFile, 122)
   If vDate = "" Then GoTo mnuDailyBooking_Click_Resume
   If Not IsDate(vDate) Then GoTo mnuDailyBooking_Click_Resume
   Screen.MousePointer = HOURGLASS
   'Clear out support table
   gBNB.Execute "delete from DailyReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   'Load table with non-cancelled NEW reservation data.
   TempEXEC = "INSERT INTO DailyReportSupport (AccomRowID,ReportDate,EntryType,ComputerName) " & _
              "SELECT ID,#" & vDate & "#,'New'," & Chr$(34) & gComputerName & Chr$(34) & _
              " FROM bbtbl WHERE EntryDate = rev_date " & _
              "AND EntryDate = #" & vDate & "# " & _
              "AND suppress = 0;"
   gBNB.Execute TempEXEC
   'Load table with cancelled NEW reservation data.
   TempEXEC = "INSERT INTO DailyReportSupport (AccomRowID,ReportDate,EntryType,ComputerName) " & _
              "SELECT ID,#" & vDate & "#,'Cancellation'," & Chr$(34) & gComputerName & Chr$(34) & _
              " FROM bbtbl WHERE EntryDate = rev_date " & _
              "AND EntryDate = #" & vDate & "# " & _
              "AND suppress <> 0;"
   gBNB.Execute TempEXEC
   'Load temp table with non-cancelled REVISED reservation data.
   TempEXEC = "INSERT INTO DailyReportSupport (AccomRowID,ReportDate,EntryType,ComputerName) " & _
              "SELECT ID,#" & vDate & "#,'Revision'," & Chr$(34) & gComputerName & Chr$(34) & _
              " FROM bbtbl WHERE EntryDate < rev_date " & _
              "AND rev_date = #" & vDate & "# " & _
              "AND suppress = 0;"
   gBNB.Execute TempEXEC
   'Load temp table with cancelled REVISED reservation data.
   TempEXEC = "INSERT INTO DailyReportSupport (AccomRowID,ReportDate,EntryType,ComputerName) " & _
              "SELECT ID,#" & vDate & "#,'Cancellation'," & Chr$(34) & gComputerName & Chr$(34) & _
              " FROM bbtbl WHERE EntryDate < rev_date " & _
              "AND rev_date = #" & vDate & "# " & _
              "AND suppress <> 0;"
   gBNB.Execute TempEXEC
   'Need to see if any rows were returned from above. If not, need to insert one dummy row
   'into support table to get report to print with the Report Date non-blank.
   Set SSTemp = gBNB.OpenRecordset("select count(*) from DailyReportSupport where ComputerName=" & Chr$(34) & gComputerName & Chr$(34), dbOpenSnapshot)
   GetSSRows SSTemp
   If SSTemp(0) = 0 Then
      TempEXEC = "INSERT INTO DailyReportSupport (AccomRowID,ReportDate,EntryType,ComputerName) " & _
              "SELECT Null,#" & vDate & "#,''," & Chr$(34) & gComputerName & Chr$(34) & ";"
      gBNB.Execute TempEXEC
   End If
   SSTemp.Close
   Report1.ReportFileName = gDBDirectory & "Daily1.rpt"
   Report1.SelectionFormula = "{DailyReportSupport.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(Report1.SortFields(vCount)) <> ""
     Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   Report1.SortFields(0) = "+{DailyReportSupport.EntryType}"
   Report1.SortFields(1) = "+{bbtbl.arrdate}"
   Report1.Destination = 0
   Report1.Action = 1
   'Clear out support table
   gBNB.Execute "delete from DailyReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   
mnuDailyBooking_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub
    
mnuDailyBooking_Click_Error:
    GoTo mnuDailyBooking_Click_Resume

End Sub

Private Sub mnuDepartures_Click()

   On Error GoTo mnuDepartures_Click_Error

   Dim X As String
   Dim vDays As Integer
   Dim vSYear, vSMonth, vSDay As String
   Dim vEYear, vEMonth, vEDay As String
   Dim vStartDate, vEndDate As String
   NL$ = Chr$(13) & Chr$(10)   'New Line of text.
   
   'Get Saved settings.
   Dim Z As Integer        'Return Value
   Dim Rs As String * 200  'Return String
   Dim winDir, Temp, iniFile As String
   'Initialize variables
   Rs = Space$(Len(Rs))
   'Get the directory in which the Windows and the .INI files reside.
   'Note that GetPrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
   winDir = UCase$(GetWindowsDir())
   'Determine the target .ini file
   iniFile = winDir & UCase$(App.EXEName) & ".INI"
   Z = GetPrivateProfileString("Daily Reports", "Departures", 2, Rs, Len(Rs), iniFile)
   If Z > 0 Then vDays = Left$(Rs, Z)     ' Trim Buffer 'a string was returned.
   
   gMsg = "Example format: " & NL$ & NL$ & "2  (shows departures for today and the next 2 days)" & _
          NL$ & "0  (shows departures for today)" & _
          NL$ & "-2 (shows departures for today and the previous 2 days)"
   X = InputBox(gMsg, "Daily Departures Report", vDays, , , App.HelpFile, 124)
   If X = "" Then Exit Sub
   If Not IsNumeric(X) Then
      MsgBox "Number of days must be numeric.", MB_ICONSTOP, Me.Caption
      GoTo mnuDepartures_Click_Resume
   End If
   'Write INI settings:
   'Get the directory in which the Windows and the .INI files reside.
   'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
   winDir = UCase$(GetWindowsDir())
   'Detemine the target .ini file
   iniFile = winDir & UCase$(App.EXEName) & ".INI"
   Z = WritePrivateProfileString("Daily Reports", "Departures", X, iniFile)
    
   Screen.MousePointer = HOURGLASS
   If X < 0 Then
      vStartDate = DateAdd("d", X, Format(Now, "m/d/yyyy"))
      vEndDate = Format(Now, "m/d/yyyy")
   ElseIf X = 0 Then
      vStartDate = Format(Now, "m/d/yyyy")
      vEndDate = Format(Now, "m/d/yyyy")
   Else
      vStartDate = Format(Now, "m/d/yyyy")
      vEndDate = DateAdd("d", X, Format(Now, "m/d/yyyy"))
   End If
   'Set start date
   vSYear = DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy"))
   vSMonth = DatePart("m", Format(vStartDate, "mm/dd/yyyy"))
   vSDay = DatePart("d", Format(vStartDate, "mm/dd/yyyy"))
   'Set end date
   vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
   vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
   vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
   
   Report1.ReportFileName = gDBDirectory & "Depart1.rpt"
   Report1.SelectionFormula = "{bbtbl.DepDate} >= Date(" & _
                                  vSYear & "," & vSMonth & "," & vSDay & ")" & _
                                  " And {bbtbl.DepDate} <= Date(" & _
                                  vEYear & "," & vEMonth & "," & vEDay & ")"
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(Report1.SortFields(vCount)) <> ""
     Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   Report1.SortFields(0) = "+{bbtbl.depdate}"
   Report1.Destination = 0
   Report1.Action = 1
   
mnuDepartures_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
mnuDepartures_Click_Error:
   GoTo mnuDepartures_Click_Resume
   
End Sub

Private Sub mnuExit_Click()
  Unload Me
End Sub








Private Sub mnuGeneralInfo_Click()

   Screen.MousePointer = HOURGLASS
   If frmGeneralGuest.WindowState = MINIMIZED Then
      Dim X&
      frmGeneralGuest.SetFocus
      X& = ShowWindow(frmGeneralGuest.hwnd, SW_SHOWNORMAL)
   Else
      frmGeneralGuest.Show
      frmGeneralGuest.SetFocus
   End If
   Screen.MousePointer = DEFAULT
   
End Sub


Private Sub mnuHelpTopics_Click()

On Error GoTo mnuHelpTopics_Error
'Screen.MousePointer = HOURGLASS
'Start help if it exists. If is is not running,
'error will be generated and help will be started in error handler.
AppActivate "BNB Help", True
 
mnuHelpTopics_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

mnuHelpTopics_Error:
   RetVal = Shell("winhlp32.exe " & gSetupDirectory & "bnbhelp.hlp", 1)
   If RetVal = 0 Then MsgBox "WINHLP32.EXE or BNBHELP.HLP cannot be found on your system.", MB_ICONSTOP, Me.Caption
   Resume mnuHelpTopics_Resume

End Sub


Private Sub mnuHostAccountData_Click()

   Screen.MousePointer = HOURGLASS
   If frmProperty.WindowState = MINIMIZED Then
      Dim X&
      frmProperty.SetFocus
      X& = ShowWindow(frmProperty.hwnd, SW_SHOWNORMAL)
   Else
      frmProperty.Show
      frmProperty.SetFocus
   End If
   Screen.MousePointer = DEFAULT
   
End Sub

Private Sub mnuHostAcctListing_Click()

   On Error GoTo mnuHostAcctListing_Error
   Screen.MousePointer = HOURGLASS
   
   Report1.ReportFileName = gDBDirectory & "AcctList.rpt"
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(Report1.SortFields(vCount)) <> ""
     Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   Report1.SelectionFormula = "{proptbl.PropObsolete}<>-1"
   Report1.Destination = 0
   Report1.Action = 1
   
mnuHostAcctListing_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

mnuHostAcctListing_Error:
MsgBox Err.Description
   Resume mnuHostAcctListing_Resume
   
End Sub

Private Sub mnuHostNotification_Click()

   On Error GoTo mnuHostNotification_Click_Error

   Dim vDate As Variant
   
   vDate = InputBox("Show Host Notifications for this date:", "Daily Host Notification Report", Format(Now, "m/d/yyyy"), , , App.HelpFile, 125)
   If vDate = "" Then GoTo mnuHostNotification_Click_Resume
   If Not IsDate(vDate) Then GoTo mnuHostNotification_Click_Resume
   Screen.MousePointer = HOURGLASS
   Dim TableName1, TempEXEC As String
   'Clear out support table
   gBNB.Execute "delete from DailyReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   'Load table with non-cancelled NEW reservation data.
   TempEXEC = "INSERT INTO DailyReportSupport (AccomRowID,ReportDate,EntryType,ComputerName) " & _
              "SELECT ID,#" & vDate & "#,'New'," & Chr$(34) & gComputerName & Chr$(34) & " " & _
              "FROM bbtbl WHERE EntryDate = rev_date " & _
              "AND EntryDate = #" & vDate & "# " & _
              "AND suppress<>-1;"
   gBNB.Execute TempEXEC
   'Load table with cancelled NEW reservation data.
   TempEXEC = "INSERT INTO DailyReportSupport (AccomRowID,ReportDate,EntryType,ComputerName) " & _
              "SELECT ID,#" & vDate & "#,'Cancellation'," & Chr$(34) & gComputerName & Chr$(34) & _
              " FROM bbtbl WHERE EntryDate = rev_date " & _
              " AND EntryDate = #" & vDate & "# " & _
              " AND suppress=-1;"
   gBNB.Execute TempEXEC
   'Load temp table with non-cancelled REVISED reservation data.
   TempEXEC = "INSERT INTO DailyReportSupport (AccomRowID,ReportDate,EntryType,ComputerName) " & _
              "SELECT ID,#" & vDate & "#,'Revision'," & Chr$(34) & gComputerName & Chr$(34) & _
              " FROM bbtbl WHERE EntryDate < rev_date " & _
              " AND rev_date = #" & vDate & "# " & _
              " AND suppress<>-1;"
   gBNB.Execute TempEXEC
   'Load temp table with cancelled REVISED reservation data.
   TempEXEC = "INSERT INTO DailyReportSupport (AccomRowID,ReportDate,EntryType,ComputerName) " & _
              "SELECT ID,#" & vDate & "#,'Cancellation'," & Chr$(34) & gComputerName & Chr$(34) & _
              " FROM bbtbl WHERE EntryDate < rev_date " & _
              " AND rev_date = #" & vDate & "# " & _
              " AND suppress=-1;"
   gBNB.Execute TempEXEC
   'Need to see if any rows were returned from above. If not, need to insert one dummy row
   'into support table to get report to print with the Report Date non-blank.
   Set SSTemp = gBNB.OpenRecordset("select count(*) from DailyReportSupport where ComputerName=" & Chr$(34) & gComputerName & Chr$(34), dbOpenSnapshot)
   GetSSRows SSTemp
   If SSTemp(0) = 0 Then
      TempEXEC = "INSERT INTO DailyReportSupport (AccomRowID,ReportDate,EntryType,ComputerName) " & _
              "SELECT Null,#" & vDate & "#,''," & Chr$(34) & gComputerName & Chr$(34) & ";"
      gBNB.Execute TempEXEC
   End If
   SSTemp.Close
   Report1.ReportFileName = gDBDirectory & "Notify1.rpt"
   Report1.SelectionFormula = "{DailyReportSupport.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(Report1.SortFields(vCount)) <> ""
     Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   Report1.SortFields(0) = "+{DailyReportSupport.EntryType}"
   Report1.SortFields(1) = "+{bbtbl.arrdate}"
   Report1.Destination = 0
   Report1.Action = 1
   'Update (notification printed) flag.
   'First, get number of rows for update loop.
   Set SSTemp = gBNB.OpenRecordset("select COUNT(*) from DailyReportSupport " & _
                                   " where ComputerName=" & Chr$(34) & gComputerName & Chr$(34) & _
                                   " And AccomRowID<>NULL", dbOpenSnapshot)
   GetSSRows SSTemp
   vCount = SSTemp(0)
   SSTemp.Close
   Set SSTemp = gBNB.OpenRecordset("select AccomRowID from DailyReportSupport " & _
                                   " where ComputerName=" & Chr$(34) & gComputerName & Chr$(34) & _
                                   " And AccomRowID<>NULL", dbOpenSnapshot)
   GetSSRows SSTemp
   For i = 0 To vCount - 1
      TempEXEC = "UPDATE bbtbl SET Notified=-1 WHERE ID=" & SSTemp(0) & ";"
      gBNB.Execute TempEXEC
      SSTemp.MoveNext
   Next i
   SSTemp.Close
   'Clear out support table
   gBNB.Execute "delete from DailyReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   
mnuHostNotification_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub
    
mnuHostNotification_Click_Error:
    GoTo mnuHostNotification_Click_Resume
    
End Sub

Private Sub mnuMasterFactsList_Click()
   
   Screen.MousePointer = HOURGLASS
   If frmMasterFactList.WindowState = MINIMIZED Then
      Dim X&
      frmMasterFactList.SetFocus
      X& = ShowWindow(frmMasterFactList.hwnd, SW_SHOWNORMAL)
   Else
      frmMasterFactList.Show
      frmMasterFactList.SetFocus
   End If
   Screen.MousePointer = DEFAULT
   
End Sub

Private Sub mnuNetSummary_Click()
   Screen.MousePointer = HOURGLASS
   gCaption = "Net Summary Report Dialog Box"
   frmNetSummaryDlg.Show 1
   Screen.MousePointer = DEFAULT
End Sub

Private Sub mnuOverPay_Click()
  
  On Error GoTo mnuOverPay_Click_Error
  
  frmOverPay.Show 1
  If Not FormLoaded(frmOverPay) Then GoTo mnuOverPay_Click_Resume
  Screen.MousePointer = HOURGLASS
  Dim vCount As Integer
  Dim vTempStr, vTempStr2, TableName1 As String
  Dim vSYear, vSMonth, vSDay As String
  Dim vEYear, vEMonth, vEDay As String
  Dim vStartDate, vEndDate As String
  vCount = 0
  If Trim(frmOverPay.txtStartDate.Text) = "" Then
     MsgBox "Starting Date cannot be blank.", MB_ICONSTOP, Me.Caption
     GoTo mnuOverPay_Click_Resume
  End If
  If Trim(frmOverPay.txtEndDate.Text) <> "" Then
     If CDate(frmOverPay.txtStartDate.Text) > CDate(frmOverPay.txtEndDate.Text) Then
        MsgBox "Starting Date cannot be greater than ending date.", MB_ICONSTOP, Me.Caption
        GoTo mnuOverPay_Click_Resume
     End If
     vEndDate = Format(Trim(frmOverPay.txtEndDate.Text), "mm/dd/yyyy")
     vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
     vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
     vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
  End If
  vStartDate = Format(Trim(frmOverPay.txtStartDate.Text), "mm/dd/yyyy")
  vSYear = DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy"))
  vSMonth = DatePart("m", Format(vStartDate, "mm/dd/yyyy"))
  vSDay = DatePart("d", Format(vStartDate, "mm/dd/yyyy"))
  Screen.MousePointer = HOURGLASS
  If vEndDate <> "" Then
     vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
     vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
     vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
     gSQL = "{bbtbl.ArrDate} >= Date(" & _
     vSYear & "," & vSMonth & "," & vSDay & ")" & _
     " And {bbtbl.ArrDate} <= Date(" & _
     vEYear & "," & vEMonth & "," & vEDay & ") " & _
     "And Not IsNull({bbtbl.ArrDate}) " & _
     "And {bbtbl.ID} = {CheckTbl.Accom_RowId} " & _
     "And {CheckTbl.void_chk} = 0 " & _
     "And {CheckTbl.CheckCategory} = 'Host' " & _
     "And ({bbtbl.nwtax} < {CheckTbl.TrueAmt} " & _
     " Or (({bbtbl.suppress}=-1 And {bbtbl.forfeit}<>-1) And {CheckTbl.TrueAmt}>0)) "
  Else
     gSQL = "{bbtbl.ArrDate} >= Date(" & _
     vSYear & "," & vSMonth & "," & vSDay & ") " & _
     "And Not IsNull({bbtbl.ArrDate}) " & _
     "And {bbtbl.ID} = {CheckTbl.Accom_RowId} " & _
     "And {CheckTbl.void_chk} = 0 " & _
     "And {CheckTbl.CheckCategory} = 'Host' " & _
     "And ({bbtbl.nwtax} < {CheckTbl.TrueAmt} " & _
     " Or (({bbtbl.suppress}=-1 And {bbtbl.forfeit}<>-1) And {CheckTbl.TrueAmt}>0)) "
  End If
  mdiBNB.Report1.DataFiles(0) = gDatabaseName
  'Since several reports are sharing the mdiBNB.Report1 control, the sort
  'array MUST be cleared out or values from previous report will be saved in the
  'array causing 'Unknown Field Name' error
  While Trim(mdiBNB.Report1.SortFields(vCount)) <> ""
     mdiBNB.Report1.SortFields(vCount) = ""
     vCount = vCount + 1
  Wend
  'Set report to print
  mdiBNB.Report1.ReportFileName = gDBDirectory & "OverPay.rpt"
  mdiBNB.Report1.SelectionFormula = gSQL
  'Set report sort order
  mdiBNB.Report1.SortFields(0) = "+{bbtbl.arrdate} "
'  mdiBNB.Report1.SortFields(1) = "+{RefundReportSupport.DateBkd} "
  mdiBNB.Report1.Destination = 0
  mdiBNB.Report1.Action = 1
  'Unload refund dialog
  If FormLoaded(frmOverPay) Then Unload frmOverPay
  
mnuOverPay_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

mnuOverPay_Click_Error:
   'MsgBox Err.Description
   GoTo mnuOverPay_Click_Resume
   
End Sub

Private Sub mnuPaymentHistory_Click()

   Screen.MousePointer = HOURGLASS
   If frmPayment.WindowState = MINIMIZED Then
      Dim X&
      frmPayment.SetFocus
      X& = ShowWindow(frmPayment.hwnd, SW_SHOWNORMAL)
   Else
      frmPayment.Show
      frmPayment.SetFocus
   End If
   Screen.MousePointer = DEFAULT

End Sub

Private Sub mnuPaymentReceived_Click()

   Screen.MousePointer = HOURGLASS
   If frmPaymentReceived.WindowState = MINIMIZED Then
      Dim X&
      frmPaymentReceived.SetFocus
      X& = ShowWindow(frmPaymentReceived.hwnd, SW_SHOWNORMAL)
   Else
      frmPaymentReceived.Show
      frmPaymentReceived.SetFocus
   End If
   Screen.MousePointer = DEFAULT
   
End Sub

Private Sub mnuPaymentsDue_Click()

  On Error GoTo mnuPaymentsDue_Click_Error
  
  Dim SSTemp2 As Recordset
  Dim i As Integer
  Dim vDays As Integer
  Dim X As String
  Dim vSYear, vSMonth, vSDay As String
  Dim vEYear, vEMonth, vEDay As String
  Dim vStartDate, vEndDate As String
  NL$ = Chr$(13) & Chr$(10)   'New Line of text.
  
  'Get Saved settings.
  Dim Z As Integer        'Return Value
  Dim Rs As String * 200  'Return String
  Dim winDir, Temp, iniFile As String
  'Initialize variables
  Rs = Space$(Len(Rs))
  'Get the directory in which the Windows and the .INI files reside.
  'Note that GetPrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
  winDir = UCase$(GetWindowsDir())
  'Determine the target .ini file
  iniFile = winDir & UCase$(App.EXEName) & ".INI"
  Z = GetPrivateProfileString("Daily Reports", "Receivables", 2, Rs, Len(Rs), iniFile)
  If Z > 0 Then vDays = Left$(Rs, Z)     ' Trim Buffer 'a string was returned.

  gMsg = "Example format: " & NL$ & NL$ & "2  (shows payments due today and the next 2 days)" & _
         NL$ & "0  (shows payments due today)" & _
         NL$ & "-2 (shows payments due today and the previous 2 days)"
  X = InputBox(gMsg, "Daily Payments Receivable", vDays, , , App.HelpFile, 126)
  If X = "" Then Exit Sub
  If Not IsNumeric(X) Then
     MsgBox "Number of days must be numeric.", MB_ICONSTOP, Me.Caption
     GoTo mnuPaymentsDue_Click_Resume
  End If
  'Write INI settings:
  'Get the directory in which the Windows and the .INI files reside.
  'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
  winDir = UCase$(GetWindowsDir())
  'Detemine the target .ini file
  iniFile = winDir & UCase$(App.EXEName) & ".INI"
  Z = WritePrivateProfileString("Daily Reports", "Receivables", X, iniFile)
  Screen.MousePointer = HOURGLASS
  If X < 0 Then
     vStartDate = DateAdd("d", X, Format(Now, "m/d/yyyy"))
     vEndDate = Format(Now, "m/d/yyyy")
  ElseIf X = 0 Then
     vStartDate = Format(Now, "m/d/yyyy")
     vEndDate = Format(Now, "m/d/yyyy")
  Else
     vStartDate = Format(Now, "m/d/yyyy")
     vEndDate = DateAdd("d", X, Format(Now, "m/d/yyyy"))
  End If
  Screen.MousePointer = HOURGLASS
  'Clear out support table
  gBNB.Execute "delete from PaymentDueSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  'Load table with DUE amounts (Prepayment, Deposit, & Cancellation Fee)
  TempEXEC = "INSERT INTO PaymentDueSupport (ComputerName,Conf,l_name,AppliedTo,AmountDue,DateDue,AmountReceived,StartDate,EndDate) " & _
             "SELECT " & Chr$(34) & gComputerName & Chr$(34) & ",payment.conf,l_name,'Deposit',DepDue,DepDate,Null,#" & vStartDate & "#,#" & vEndDate & "# " & _
             "FROM payment " & _
             "WHERE payment.depdate >= #" & vStartDate & "# " & _
             "AND payment.depdate <= #" & vEndDate & "#;"
  gBNB.Execute TempEXEC
  TempEXEC = "INSERT INTO PaymentDueSupport (ComputerName,Conf,l_name,AppliedTo,AmountDue,DateDue,AmountReceived,StartDate,EndDate) " & _
             "SELECT " & Chr$(34) & gComputerName & Chr$(34) & ",payment.conf,l_name,'Prepayment',PreDue,PreDate,Null,#" & vStartDate & "#,#" & vEndDate & "# " & _
             "FROM payment " & _
             "WHERE payment.predate >= #" & vStartDate & "# " & _
             "AND payment.predate <= #" & vEndDate & "#;"
  gBNB.Execute TempEXEC
  TempEXEC = "INSERT INTO PaymentDueSupport (ComputerName,Conf,l_name,AppliedTo,AmountDue,DateDue,AmountReceived,StartDate,EndDate) " & _
             "SELECT " & Chr$(34) & gComputerName & Chr$(34) & ",payment.conf,l_name,'Cancellation Fee',Canclfee,Canclfeedatedue,Null,#" & vStartDate & "#,#" & vEndDate & "# " & _
             "FROM payment " & _
             "WHERE payment.CanclfeeDateDue >= #" & vStartDate & "# " & _
             "AND payment.CanclfeeDateDue <= #" & vEndDate & "#;"
  gBNB.Execute TempEXEC
  'Get a 2-column recordset of table we just loaded
  TempEXEC = "select Conf,AppliedTo from PaymentDueSupport where ComputerName=" & Chr$(34) & gComputerName & Chr$(34) & " order by Conf, AppliedTo"
  Set SSTemp = gBNB.OpenRecordset(TempEXEC, dbOpenSnapshot)
  GetSSRows SSTemp
  'Get out if no rows
  If SSTemp.EOF And SSTemp.BOF Then
     gMsg = "No payments are due for this date."
     MsgBox gMsg, MB_ICONINFORMATION, Me.Caption
     GoTo mnuPaymentsDue_Click_Resume
  End If
  'Update table we just loaded with the total amounts received for
  'each of the 3 categories (Prepayment, Deposit, & Cancellation Fee)
  For i = 0 To SSTemp.RecordCount - 1
     Set SSTemp2 = gBNB.OpenRecordset("select SUM(AmountReceived) from PaymentReceived where Conf=" & SSTemp(0) & " And AppliedTo='" & SSTemp(1) & "'", dbOpenSnapshot)
     GetSSRows SSTemp2
     If Not IsNull(SSTemp2(0)) Then
        TempEXEC = "UPDATE PaymentDueSupport " & _
                   "SET AmountReceived=" & SSTemp2(0) & _
                   " WHERE Conf=" & SSTemp(0) & _
                   " And AppliedTo='" & SSTemp(1) & "' " & _
                   "And ComputerName=" & Chr$(34) & gComputerName & Chr$(34) & ";"
        gBNB.Execute TempEXEC
     End If
     SSTemp.MoveNext
   Next i
   SSTemp.Close
   SSTemp2.Close
   'Print Report
   Report1.ReportFileName = gDBDirectory & "PayDue1.rpt"
   Report1.SelectionFormula = "{PaymentDueSupport.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(Report1.SortFields(vCount)) <> ""
     Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   Report1.SortFields(0) = "+{PaymentDueSupport.DateDue}"
   Report1.SortFields(1) = "+{PaymentDueSupport.l_name}"
   Report1.Destination = 0
   Report1.Action = 1
   'Clear out support table
   gBNB.Execute "delete from PaymentDueSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   
mnuPaymentsDue_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub
    
mnuPaymentsDue_Click_Error:
    MsgBox Err.Description
    GoTo mnuPaymentsDue_Click_Resume
End Sub

Private Sub mnuPayReceivable_Click()
   frmPayReceivable.Show 1
End Sub

Private Sub mnuPayRecSummary_Click()
   Screen.MousePointer = HOURGLASS
   frmPayRecDlg.Show 1
End Sub


Private Sub mnuPayToHost_Click()
  
    Screen.MousePointer = HOURGLASS
    gCaption = "Payments to Host/Travel Agency Listing"
    gSQL = "select Conf,CheckNum,TrueAmt," & _
           "Chk_Date,Print_To," & _
           "AccountNum,CheckCategory,Comments " & _
           "from CheckTbl where conf = " & gConfNum & _
           " And void_chk <> -1"
    Dim frmNewBoundListing As New frmBoundListing  ' Declare form variable
    frmNewBoundListing.Show     ' Load and display new instance
    
End Sub

Private Sub mnuPrintChecks_Click()
  
  'Validate syncronization of check numbers based upon value
  'of CheckNum.SharedAccounts.
  If Not ValidateCheckNum() Then
    MsgBox gMsg, MB_ICONSTOP, Me.Caption
    Exit Sub
  End If
  Screen.MousePointer = HOURGLASS
  frmCheckDlg.Show 1
  Screen.MousePointer = DEFAULT
  
End Sub

Private Sub mnuPrinterSetup_Click()
   
   On Error GoTo mnuPrinterSetup_Click_Error
   
   'Generate error if use clicks on Cancel.
   CMDialog1.CancelError = True
   'Show printer setup box instead of printer dialog box.
   CMDialog1.Flags = cdlPDPrintSetup
   'Activate Printer Dialog Box
   CMDialog1.ShowPrinter
   'Invoke changes on printer object.
   Printer.EndDoc
   
mnuPrinterSetup_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
 
mnuPrinterSetup_Click_Error:
    'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
    If Err = cdlCancel Then
       'This will keep background screens from other applications
       'gaining focus mysteriously upon closure of common dialog.
       SAW = SetActiveWindow(mdiBNB.hwnd)
    Else
       MsgBox Err.Description
    End If
    Resume mnuPrinterSetup_Click_Resume
    
End Sub

Private Sub mnuRefunds_Click()
  
  On Error GoTo mnuRefunds_Click_Error
  
  frmRefund.Show 1
  If Not FormLoaded(frmRefund) Then GoTo mnuRefunds_Click_Resume
  Screen.MousePointer = HOURGLASS
  Dim vCount As Integer
  Dim vTempStr, vTempStr2, TableName1 As String
  vCount = 0
  Screen.MousePointer = HOURGLASS
  mdiBNB.Report1.DataFiles(0) = gDatabaseName
  gBNB.Execute "DELETE FROM RefundReportSupport WHERE computername=" & Chr$(34) & gComputerName & Chr$(34) & ";"
  If Trim(frmRefund.txtStartDate.Text) <> "" And Trim(frmRefund.txtEndDate.Text) = "" Then
     vTempStr = "AND checktbl.chk_date >= #" & frmRefund.txtStartDate.Text & "# "
     vTempStr2 = "AND ((RefundByCCTbl.DatePaid >= #" & frmRefund.txtStartDate.Text & "#) OR ISNULL(RefundByCCTbl.DatePaid)) "
  ElseIf Trim(frmRefund.txtStartDate.Text) <> "" And Trim(frmRefund.txtEndDate.Text) <> "" Then
     vTempStr = "AND checktbl.chk_date >= #" & frmRefund.txtStartDate.Text & "# " & _
                "AND checktbl.chk_date <= #" & frmRefund.txtEndDate.Text & "# "
     vTempStr2 = "AND ((RefundByCCTbl.DatePaid >= #" & frmRefund.txtStartDate.Text & "# " & _
                 "AND RefundByCCTbl.DatePaid <= #" & frmRefund.txtEndDate.Text & "#) OR ISNULL(RefundByCCTbl.DatePaid)) "
  ElseIf Trim(frmRefund.txtStartDate.Text) = "" And Trim(frmRefund.txtEndDate.Text) <> "" Then
     vTempStr = "AND checktbl.chk_date <= #" & frmRefund.txtEndDate.Text & "#"
     vTempStr2 = "AND ((RefundByCCTbl.DatePaid <= #" & frmRefund.txtEndDate.Text & "#) OR ISNULL(RefundByCCTbl.DatePaid)) "
  ElseIf Trim(frmRefund.txtStartDate.Text) = "" And Trim(frmRefund.txtEndDate.Text) = "" Then
     vTempStr = ""
     vTempStr2 = ""
  End If
  'Find Amounts Refunded:
  '1. Refunds that need to have a check printed for them, but have not.
  gBNB.Execute "INSERT INTO RefundReportSupport " & _
               "(conf,l_name,DateBkd,RefOwed,AmtRefunded,RefundDate, " & _
               "PayMethod,Void,Comments,computername) " & _
               "SELECT payment.Conf,payment.l_name," & _
               "guesttbl.DateBkd,payment.refundowed,0," & _
               "NULL,'',0,''," & Chr$(34) & gComputerName & Chr$(34) & _
               " FROM payment,guesttbl " & _
               "WHERE payment.refundowed IS NOT NULL " & _
               "AND payment.conf=guesttbl.conf "
   gBNB.Execute "DELETE FROM RefundReportSupport " & _
               "WHERE RefundReportSupport.conf " & _
               "IN (SELECT conf FROM checktbl " & _
                    "WHERE SubCategory = 'Guest Refund' " & _
                    "AND CheckCategory = 'Host' " & _
                    "AND void_chk = 0)"
  '2. Refunds that have had check(s) printed on them.
  gBNB.Execute "INSERT INTO RefundReportSupport " & _
               "(conf,l_name,DateBkd,RefOwed,AmtRefunded,RefundDate, " & _
               "PayMethod,Void,Comments,computername) " & _
               "SELECT DISTINCT payment.conf,payment.l_name,guesttbl.DateBkd, " & _
               "payment.RefundOwed,checktbl.trueamt, " & _
               "checktbl.Chk_Date,'Chk ' & checktbl.checknum,checktbl.Void_Chk, " & _
               "''," & Chr$(34) & gComputerName & Chr$(34) & _
               " FROM payment,checktbl,guesttbl " & _
               "WHERE NOT ISNULL(payment.refundowed) " & _
               "AND payment.conf=checktbl.conf " & _
               "AND guesttbl.conf=payment.conf " & _
               "AND checktbl.SubCategory = 'Guest Refund' " & vTempStr & _
               " AND checktbl.void_chk = 0"
  '3. Any Credit Card/Cash/Other refunds due that have or have not been paid.
  gBNB.Execute "INSERT INTO RefundReportSupport " & _
               "(conf,l_name,DateBkd,RefOwed,AmtRefunded,RefundDate, " & _
               "PayMethod,Void,Comments,computername) " & _
               "SELECT RefundByCCTbl.Conf,RefundByCCTbl.l_name," & _
               "guesttbl.DateBkd,RefundByCCTbl.AmtDue,RefundByCCTbl.AmtPaid, " & _
               "RefundByCCTbl.DatePaid,RefundByCCTbl.PaymentMethod,0, " & _
               "RefundByCCTbl.Comments," & Chr$(34) & gComputerName & Chr$(34) & _
               " FROM RefundByCCTbl,guesttbl " & _
               "WHERE NOT ISNULL(RefundByCCTbl.AmtDue) " & _
               "AND RefundByCCTbl.Conf=guesttbl.conf " & vTempStr2
  'Since several reports are sharing the mdiBNB.Report1 control, the sort
  'array MUST be cleared out or values from previous report will be saved in the
  'array causing 'Unknown Field Name' error
  While Trim(mdiBNB.Report1.SortFields(vCount)) <> ""
     mdiBNB.Report1.SortFields(vCount) = ""
     vCount = vCount + 1
  Wend
  'Set report to print
  mdiBNB.Report1.ReportFileName = gDBDirectory & "Refund1.rpt"
  mdiBNB.Report1.SelectionFormula = "{RefundReportSupport.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
  'Set report sort order
  mdiBNB.Report1.SortFields(0) = "+{RefundReportSupport.RefundDate} "
  mdiBNB.Report1.SortFields(1) = "+{RefundReportSupport.DateBkd} "
  mdiBNB.Report1.Destination = 0
  mdiBNB.Report1.Action = 1
  'Clear out support table
  gBNB.Execute "DELETE FROM RefundReportSupport WHERE computername=" & Chr$(34) & gComputerName & Chr$(34) & ";"
  'Unload refund dialog
  If FormLoaded(frmRefund) Then Unload frmRefund
  
mnuRefunds_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

mnuRefunds_Click_Error:
   'MsgBox Err.Description
   GoTo mnuRefunds_Click_Resume
   
End Sub

Private Sub mnuRestore_Click()
   
    On Error GoTo mnuRestore_Click_Error
   'Cancel all pending Updates/Inserts before restore
    Dim TempStr As String
    
    For i = 0 To Forms.Count - 1
      If Forms(i).Name <> "mdiBNB" And Forms(i).Name <> "frmDBBackup" Then
        TempStr = GetFormMode(Forms(i))
        Select Case TempStr
          Case "Insert"
            MsgBox "Please cancel pending Insert operations and close all forms before restoring.", MB_ICONSTOP, Me.Caption
            GoTo mnuRestore_Click_Resume
          Case "Update"
            MsgBox "Please cancel pending Update operations and close all forms before restoring.", MB_ICONSTOP, Me.Caption
            GoTo mnuRestore_Click_Resume
          Case Else
            MsgBox "Please close all forms before restoring database.", MB_ICONSTOP, Me.Caption
            GoTo mnuRestore_Click_Resume
        End Select
      End If
    Next i
    Screen.MousePointer = HOURGLASS
    frmDBBackup.CMDialog1.DialogTitle = "Restore Database"
    frmDBBackup.Caption = "Database Restore Dialog Box"
    frmDBBackup.lblFileName.Caption = "Restore from:"
    frmDBBackup.Show 1
    
    If Not FormLoaded(frmDBBackup) Then GoTo mnuRestore_Click_Resume
    
    If frmDBBackup.optCancelled = True Then GoTo mnuRestore_Click_Resume
    Screen.MousePointer = HOURGLASS
    gMsg = "Restoring database from backup file. Please wait..."
    frmStatus.Show
    Screen.MousePointer = HOURGLASS
    'Allow status form to paint fully
    For i = 1 To 3
      DoEvents
    Next i
    'Close the database
    gBNB.Close
    'Overwrite current DB (gDatabaseName) with backup copy (CMDialog1.FileName)
    FileCopy frmDBBackup.CMDialog1.filename, gDatabaseName
    'Wait a while for file to copy
    For i = 1 To 10000
      DoEvents
    Next i

mnuRestore_Click_Resume:
    'Reconnect database
    Set gBNB = Workspaces(0).OpenDatabase(gDatabaseName, False, False, "")
    If FormLoaded(frmStatus) Then Unload frmStatus
    If FormLoaded(frmDBBackup) Then Unload frmDBBackup
    Screen.MousePointer = DEFAULT
    Exit Sub

mnuRestore_Click_Error:
    'MsgBox Str(Err) & ", " & Err.Description
    'User pressed cancel button is Err 32755
    If Err = 32755 Then
        'Do nothing
    ElseIf Err = 70 Then   '70 = Permission Denied. (Can't perform overwrite. File is open.)
        MsgBox "All other users must exit program before database restoration can take place.", MB_ICONSTOP, Me.Caption
    Else
        MsgBox Err.Description
    End If
    Resume mnuRestore_Click_Resume
  
End Sub

Private Sub mnuServiceFeeSummary_Click()
   Screen.MousePointer = HOURGLASS
   gCaption = "Service Fee Summary Report Dialog Box"
   frmNetSummaryDlg.Show 1
   Screen.MousePointer = DEFAULT
End Sub

Private Sub mnuSetCheckNum_Click()
   Screen.MousePointer = HOURGLASS
   frmCheckNumbers.Show 1
   Screen.MousePointer = DEFAULT
End Sub

Private Sub mnuSetTaxPlans_Click()
  
  Screen.MousePointer = HOURGLASS
  'Ensure a row exists in TaxRate table.
  Dim SSTaxRates As Recordset
  Set SSTaxRates = gBNB.OpenRecordset("select tax_one, tax_two, tax_three from taxrates", dbOpenSnapshot)
  GetSSRows SSTaxRates
  If SSTaxRates.EOF And SSTaxRates.BOF Then
       MsgBox "Tax rates must be set before tax plans can be entered.", MB_ICONSTOP, Me.Caption
  ElseIf SSTaxRates("tax_one") = 0 And SSTaxRates("tax_two") = 0 And SSTaxRates("tax_three") = 0 Then
       MsgBox "At least one tax rate must be non-zero before tax plans can be entered.", MB_ICONSTOP, Me.Caption
  Else
       frmTaxPlan.Show 1
  End If
  SSTaxRates.Close
  Screen.MousePointer = DEFAULT
End Sub

Private Sub mnuSetTaxRates_Click()

   Screen.MousePointer = HOURGLASS
   If frmTaxRates.WindowState = MINIMIZED Then
      Dim X&
      frmTaxRates.SetFocus
      X& = ShowWindow(frmTaxRates.hwnd, SW_SHOWNORMAL)
   Else
      frmTaxRates.Show
      frmTaxRates.SetFocus
   End If
   Screen.MousePointer = DEFAULT
 
End Sub




Private Sub mnuTax1099_Click()
   
   On Error GoTo mnuTax1099_Click_Error
   
   'Don't allow print if row doesn't exist in payment history for selected conf
   Dim TempSS As Recordset
   gSQL = "SELECT FedTaxId FROM UserCompanyInfo"
   Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
   GetSSRows TempSS
   If Trim(TempSS("FedTaxId")) = "" Then
      MsgBox "Federal Tax ID Number must be entered through the " & _
             "'Admin' > 'Company Information' menu selections.", MB_ICONSTOP, Me.Caption
      TempSS.Close
      GoTo mnuTax1099_Click_Resume
   End If
   TempSS.Close
   Screen.MousePointer = HOURGLASS
   'gSummReportName = "NetSummary"
   frmTax1099.Show 1

mnuTax1099_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

mnuTax1099_Click_Error:
   GoTo mnuTax1099_Click_Resume
   
End Sub

Private Sub mnuTravelAgencyAccountData_Click()

   Screen.MousePointer = HOURGLASS
   If frmTravelAccount.WindowState = MINIMIZED Then
      Dim X&
      frmTravelAccount.SetFocus
      X& = ShowWindow(frmTravelAccount.hwnd, SW_SHOWNORMAL)
   Else
      frmTravelAccount.Show
      frmTravelAccount.SetFocus
   End If
   Screen.MousePointer = DEFAULT
   
End Sub
Private Sub mnuTravelAgent_Click()

   Screen.MousePointer = HOURGLASS
   If frmGuestTravel.WindowState = MINIMIZED Then
      Dim X&
      frmGuestTravel.SetFocus
      X& = ShowWindow(frmGuestTravel.hwnd, SW_SHOWNORMAL)
   Else
      frmGuestTravel.Show
      frmGuestTravel.SetFocus
   End If
   Screen.MousePointer = DEFAULT

End Sub



Private Sub mnuTrends_Click()

   On Error GoTo mnuTrends_Click_Error
   
   Screen.MousePointer = HOURGLASS
   frmTrendsDialog.Show 1
   If FormLoaded(frmTrendsDialog) Then
      If Not frmTrendsDialog.optCancelled.Value Then TrendsReport
      'Don't need the Trends Dialog anymore, so unload it from memory.
      Unload frmTrendsDialog
   End If

mnuTrends_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

mnuTrends_Click_Error:
  GoTo mnuTrends_Click_Resume

End Sub



Public Sub GetIniSettings()
    'Declare variables
    Dim X As Integer        'Return Value
    Dim Rs As String * 200  'Return String
    Dim winDir, Temp As String

    'Initialize variables
    Rs = Space$(Len(Rs))

    'Get the directory in which the Windows and the .INI files reside.
    'Note that GetPrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())

'GENERAL ...
    'Get & Set the File Name
    X = GetPrivateProfileString("Connect", "DatabaseName", "BNB1.MDB", Rs, Len(Rs), winDir & UCase$(App.EXEName) & ".INI")
    If X > 0 Then gDatabaseName = Left$(Rs, X)     ' Trim Buffer 'a string was returned.
    X = GetPrivateProfileString("Connect", "SetupDirectory", "", Rs, Len(Rs), winDir & UCase$(App.EXEName) & ".INI")
    If X > 0 Then gSetupDirectory = Left$(Rs, X)     ' Trim Buffer 'a string was returned.

End Sub

Public Function ValidateCheckNum() As Integer
   
   Screen.MousePointer = HOURGLASS
   ValidateCheckNum = False
   Dim TempSS As Recordset
   Set TempSS = gBNB.OpenRecordset("select * from CheckNum", dbOpenSnapshot)
   GetSSRows TempSS
   If TempSS.RecordCount = 0 Then
      gMsg = "Checking account information must be entered prior to printing checks. " & _
             "Set Check Numbers and Account Sharing information through the 'Accounting', 'Checks' menu."
      GoTo ValidateCheckNum_Resume
   End If
   
   If TempSS("SharedAccounts") = 0 Then
      'No sync between check numbers required.
   ElseIf TempSS("SharedAccounts") = 1 Then
      'Travel and Miscellaneous check numbers must match.
      If TempSS("TravelCheckNum") <> TempSS("MiscCheckNum") Then
         gMsg = "Check numbers for Travel and Miscellaneous categories do not match. " & _
                "Options set for these categories indicate that they share the same account. " & _
                "Check numbers can be reset through the 'Accounting','Checks' menu selection."
         GoTo ValidateCheckNum_Resume
      End If
   ElseIf TempSS("SharedAccounts") = 2 Then
      'Host and Miscellaneous check numbers must match.
      If TempSS("HostCheckNum") <> TempSS("MiscCheckNum") Then
         gMsg = "Check numbers for Host and Miscellaneous categories do not match. " & _
                "Options set for these categories indicate that they share the same account. " & _
                "Check numbers can be reset through the 'Accounting','Checks' menu selection."
         GoTo ValidateCheckNum_Resume
      End If
   ElseIf TempSS("SharedAccounts") = 3 Then
      'Host and Travel check numbers must match.
      If TempSS("HostCheckNum") <> TempSS("TravelCheckNum") Then
         gMsg = "Check numbers for Host and Travel categories do not match. " & _
                "Options set for these categories indicate that they share the same account. " & _
                "Check numbers can be reset through the 'Accounting','Checks' menu selection."
         GoTo ValidateCheckNum_Resume
      End If
   ElseIf TempSS("SharedAccounts") = 4 Then
      'All check numbers must match.
      If TempSS("TravelCheckNum") <> TempSS("MiscCheckNum") Or _
         TempSS("HostCheckNum") <> TempSS("MiscCheckNum") Or _
         TempSS("HostCheckNum") <> TempSS("TravelCheckNum") Then
         gMsg = "Check numbers for Host, Travel, and Miscellaneous categories do not match. " & _
                "Options set for these categories indicate that they share the same account. " & _
                "Check numbers can be reset through the 'Accounting','Checks' menu selection."
         GoTo ValidateCheckNum_Resume
      End If
   End If
   ValidateCheckNum = True
   
ValidateCheckNum_Resume:
  Screen.MousePointer = DEFAULT
   
End Function

Public Sub ConvertRbaseToAccess()

On Error GoTo ConvertRbaseToAccess_Error

gMsg = "Upgrading HBBB system. Please wait..."
frmStatus.Show
Screen.MousePointer = HOURGLASS
'Allow status form to paint fully
For i = 1 To 3
DoEvents
Next i

'***** BEGINNING OF CONVERSION PROCESS ***********
'TO BE RUN IMMEDIATELY AFTER TEMPORARY TABLES (R_xxxx) TABLES ARE LOADED WITH
'EXISTING RBASE DATA.
'*************************************************
'1. FIX UP R_xxxx TABLES SO DATA TYPES WILL MATCH WHEN LOADED INTO MASTER TABLES.
'Fix Y/N fields:
gBNB.Execute "update R_TAGENT set ta_lbl = '-1' where ta_lbl='Y' or ta_lbl='y'"
gBNB.Execute "update R_TAGENT set ta_lbl = '0' where ta_lbl<>'-1' or isnull(ta_lbl)"
gBNB.Execute "update R_TAMASTR set ta_lbl = '-1' where ta_lbl='Y' or ta_lbl='y'"
gBNB.Execute "update R_TAMASTR set ta_lbl = '0' where ta_lbl<>'-1' or isnull(ta_lbl)"
gBNB.Execute "update R_PROPTBL set depreq = '-1' where depreq='Y' or depreq='y'"
gBNB.Execute "update R_PROPTBL set depreq = '0' where depreq<>'-1' or isnull(depreq)"
gBNB.Execute "update R_PROPTBL set supp_flg = '-1' where supp_flg='Y' or supp_flg='y'"
gBNB.Execute "update R_PROPTBL set supp_flg = '0' where supp_flg<>'-1' or isnull(supp_flg)"
gBNB.Execute "update R_GUEST set cancell = '-1' where cancell='Y' or cancell='y'"
gBNB.Execute "update R_GUEST set cancell = '0' where cancell<>'-1' or isnull(cancell)"
gBNB.Execute "update R_GUEST set lbl_flag = '-1' where lbl_flag='Y' or lbl_flag='y'"
gBNB.Execute "update R_GUEST set lbl_flag = '0' where lbl_flag<>'-1' or isnull(lbl_flag)"
gBNB.Execute "update R_BBTBL set xld = '-1' where xld='Y' or xld='y'"
gBNB.Execute "update R_BBTBL set xld = '0' where xld<>'-1' or isnull(xld)"
gBNB.Execute "update R_CHKTBL set void_chk = '-1' where void_chk='Y' or void_chk='y'"
gBNB.Execute "update R_CHKTBL set void_chk = '0' where void_chk<>'-1' or isnull(void_chk)"
'Fix Percent fields (Multiply by 100).
gBNB.Execute "update R_PROPTBL set perdirct = (perdirct*100) where not isnull(perdirct)"
gBNB.Execute "update R_PROPTBL set fut_pcnt = (fut_pcnt*100) where not isnull(fut_pcnt)"
gBNB.Execute "update R_BBTBL set percnt = (percnt*100) where not isnull(percnt)"
'****************************************
'2. LOAD MASTER TABLES FROM R_xxxx TABLES
gBNB.Execute "INSERT INTO guesttbl (conf,f_name,l_name,address,busadd,city,state," & _
             "zipcode,hmphone,bsphone,faxnum,travwith,bookedby,datebkd,resfee," & _
             "cmmnts,closeure,referral,revision,revdate,lbl_flag) " & _
             "SELECT conf,f_name,l_name,address,busadd,city,state," & _
             "zipcode,hmphone,bsphone,fax,travwith,bookedby,datebkd,resfee," & _
             "cmmnts,closeure,referral,0,revdate,lbl_flag " & _
             "FROM r_guest;"
gBNB.Execute "UPDATE guesttbl SET revision=-1 WHERE not IsNull(revdate);"
gBNB.Execute "INSERT INTO bbtbl (conf,f_name,l_name,location,accountnum,arrdate," & _
              "depdate,numpty,numnites,grosrate,netrate,tax1,tax2,tax3,gwtax," & _
              "nwtax,svcharge,cmmnts,pre1,predate1,nnotes,percnt,commish," & _
              "fillincalcamounts,rev_date,tax,com_rcvd,chknum," & _
              "comm_paid,pymttype,tax_plan_code,suppress,unitname) " & _
              "SELECT conf,f_name,l_name,location,acctnum,arrdate,depdate," & _
              "numpty,numnites,grosrate,netrate,net417,net5,Null,gwtax,nwtax," & _
              "svcharge,cmmnts,pre1,predate1,nnotes,Null,commish,0,rev_date," & _
              "tax,com_rcvd,chknum,comm_paid,pymttype,'',xld,''" & _
              "FROM r_bbtbl;"
gBNB.Execute "INSERT INTO checktbl (conf,location,arrdate,nwtax,trueamt,l_name," & _
             "depdate,checknum,comments,void_chk,chk_date,print_to,accountnum," & _
             "checkcategory,subcategory,Accom_RowId) " & _
             "SELECT conf,location,arrdate,nwtax,trueamt,l_name,depdate,checknum," & _
             "cnotes,void_chk,chk_date,print_to,acctnum,'Host','',Null " & _
             "FROM r_chktbl;"

'The next 2 <similar> queries will populate the Accom_RowId column in CheckTbl with
'the row id from BBTBL. Old RBase method numbered BBTL.bb_num just before
'check was printed. Worked OK for that but couldn't get one-to-one
'relationship back from BBTBL to CHECKTBL. So here we'll fill it in
'for the old data (as close as possible) and new check printing
'will fill in Accom_RowId automatically. This will be run after
'BBTBL and CHECKTBL are loaded from Rbase and all columns are
'filled in (ie, CHECKTBL.CheckCategory, etc.)
'*****************
Dim j As Integer
On Error Resume Next
Dim SSChktbl As Recordset
gSQL = "select * from bbtbl order by conf"
Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
GetSSRows SSTemp
For i = 0 To SSTemp.RecordCount - 1
        gSQL = "select * from checktbl where conf = " & SSTemp("conf") & _
         " And arrdate = #" & SSTemp("arrdate") & "#" & " And trueamt=" & SSTemp("pre1") & _
         " And chk_date = #" & SSTemp("predate1") & "#" & _
         " And checknum = " & SSTemp("chknum") & _
         " And isnull(Accom_RowId)" & _
" And accountnum = " & SSTemp("accountnum")
'!!!!! RUN FIRST WITH ABOVE LINE IN gSQL, Then again without it !!!
         Set SSChktbl = gBNB.OpenRecordset(gSQL, dbOpenDynaset)
         SSChktbl.MoveFirst
         If SSChktbl.RecordCount > 1 Then
            'MsgBox Str(SSTemp("conf")) & " - " & Str(SSChktbl.RecordCount) & " records"
            gSQL = "select ID from bbtbl where conf = " & SSChktbl("conf") & _
            " And arrdate = #" & SSChktbl("arrdate") & "#" & " And pre1=" & SSChktbl("trueamt") & _
            " And predate1 = #" & SSChktbl("chk_date") & "#" & _
            " And chknum = " & SSChktbl("checknum") & _
" And accountnum = " & SSChktbl("accountnum")
'!!!!! RUN FIRST WITH ABOVE LINE IN gSQL, Then again without it !!!
            Set SSBB = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
            SSBB.MoveLast
            SSBB.MoveFirst
            For j = 0 To SSChktbl.RecordCount - 1
              SSChktbl.Edit
              SSChktbl("accom_rowid") = SSBB("ID")
              SSChktbl.Update
              SSChktbl.MoveNext
              SSBB.MoveNext
            Next j
            SSBB.Close
         Else
           'keep going
           SSChktbl.Edit
           SSChktbl("accom_rowid") = SSTemp("ID")
           SSChktbl.Update
         End If
         SSChktbl.Close
         SSTemp.MoveNext
Next i
SSTemp.Close
SSChktbl.Close
'RUN AGAIN WITHOUT THE LINE IN gSQL
gSQL = "select * from bbtbl order by conf"
Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
GetSSRows SSTemp
For i = 0 To SSTemp.RecordCount - 1
        gSQL = "select * from checktbl where conf = " & SSTemp("conf") & _
         " And arrdate = #" & SSTemp("arrdate") & "#" & " And trueamt=" & SSTemp("pre1") & _
         " And chk_date = #" & SSTemp("predate1") & "#" & _
         " And checknum = " & SSTemp("chknum") & _
         " And isnull(Accom_RowId)" '& _
'" And accountnum = " & SSTemp("accountnum")
'!!!!! RUN FIRST WITH ABOVE LINE IN gSQL, Then again without it !!!
         Set SSChktbl = gBNB.OpenRecordset(gSQL, dbOpenDynaset)
         SSChktbl.MoveFirst
         If SSChktbl.RecordCount > 1 Then
            'MsgBox Str(SSTemp("conf")) & " - " & Str(SSChktbl.RecordCount) & " records"
            gSQL = "select ID from bbtbl where conf = " & SSChktbl("conf") & _
            " And arrdate = #" & SSChktbl("arrdate") & "#" & " And pre1=" & SSChktbl("trueamt") & _
            " And predate1 = #" & SSChktbl("chk_date") & "#" & _
            " And chknum = " & SSChktbl("checknum") '& _
'" And accountnum = " & SSChktbl("accountnum")
'!!!!! RUN FIRST WITH ABOVE LINE IN gSQL, Then again without it !!!
            Set SSBB = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
            SSBB.MoveLast
            SSBB.MoveFirst
            For j = 0 To SSChktbl.RecordCount - 1
              SSChktbl.Edit
              SSChktbl("accom_rowid") = SSBB("ID")
              SSChktbl.Update
              SSChktbl.MoveNext
              SSBB.MoveNext
            Next j
            SSBB.Close
         Else
           'keep going
           SSChktbl.Edit
           SSChktbl("accom_rowid") = SSTemp("ID")
           SSChktbl.Update
         End If
         SSChktbl.Close
         SSTemp.MoveNext
Next i
SSTemp.Close
SSChktbl.Close
On Error GoTo ConvertRbaseToAccess_Error
'***************************
'CONTINUE LOADING OTHER TABLES
gBNB.Execute "INSERT INTO proptbl (accountnum,location,fullname,mailaddress," & _
             "propcity,mailstate,mailzipcode,mailphone1,mailphone2,propphone," & _
             "mailfax,perdirect,comments,propaddress,mailcity,propstate," & _
             "propzipcode,check_to,tax_plan_code,futurepercent," & _
             "futuredate,federaltaxid,depositreq,suppressflag,propfax,dba) " & _
             "SELECT acct,prop,fullname,address,propcity,state,zipcode," & _
             "hphone,bphone,cotphone,fax,perdirct,cmmnts,'',mailcity," & _
             "'','',check_to,proptype,fut_pcnt,fut_date,taxid,depreq," & _
             "supp_flg,'',dba " & _
             "FROM r_proptbl;"
gBNB.Execute "UPDATE proptbl SET tax_plan_code='038' WHERE tax_plan_code='B&B';"
gBNB.Execute "UPDATE proptbl SET tax_plan_code='148' WHERE tax_plan_code='HOTEL';"
gBNB.Execute "UPDATE proptbl SET tax_plan_code='258' WHERE tax_plan_code<>'038' " & _
             " And tax_plan_code<>'148';"
gBNB.Execute "INSERT INTO cartbl (conf,f_name,l_name,agentname,agencyname," & _
             "phone,model,pudate,dropdate,pulocation,droplocation,days," & _
             "dailyrate,weeklyrate,dropcharge,carconfnumber,total,commishdue," & _
             "amountreceived,datereceived,comments,accountnum) " & _
             "SELECT conf,f_name,l_name,agent,caragncy," & _
             "phone,model,pudate,dropdate,puloc,droploc,Null," & _
             "dayrate,weekrate,dropchg,carconf,total,commish," & _
             "compaid,comdate,car_cmnt,Null " & _
             "FROM r_cartbl;"
'*************************
gSQL = "select distinct AgencyName from cartbl where AgencyName <> ''"
Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
Dim TempStr As String
SSTemp.MoveFirst
For i = 1 To SSTemp.RecordCount - 1
  TempStr = "'" & SSTemp(0) & "'"
  gBNB.Execute "insert into carmaster (AccountNum,AgencyName,Address,City,State," & _
               "Zipcode,Phone,Fax,Suppress,Comments) " & _
               "values (" & i & "," & TempStr & ",'','','','','','',0,'')"
  SSTemp.MoveNext
Next i
gBNB.Execute "UPDATE cartbl INNER JOIN carmaster ON cartbl.agencyname = " & _
             "carmaster.agencyname SET cartbl.accountnum = [carmaster].[accountnum];"
gBNB.Execute "UPDATE cartbl SET days=DateDiff('d', pudate, dropdate);"

'*************************
gBNB.Execute "update checktbl set comments = '' where comments is null"
'*************************
gBNB.Execute "update bbtbl set suppress = -1 " & _
             "where nnotes like '*Xcld*' " & _
             "or nnotes like '*Cancel*' " & _
             "or nnotes like '*XL*' "
gBNB.Execute "update bbtbl set percnt = null"
gBNB.Execute "update bbtbl set tax_plan_code = ''"
gBNB.Execute "update bbtbl set pymttype = 'Prepay' where pymttype = 'Normal' or pymttype = 'normal'"
'*************************
gBNB.Execute "INSERT INTO payment (conf,f_name,l_name,depdue,depdate, " & _
             "predue,predate,defcom,cmmnts,canclfee,canclfeedatedue,refundowed," & _
             "refdate) " & _
             "SELECT conf,f_name,l_name,depdue,depdate, " & _
             "predue,predate,defcom,cmmnts,canclfee,Null,refund," & _
             "refdate " & _
             "FROM r_paytbl"
gBNB.Execute "UPDATE payment INNER JOIN GUESTTBL ON payment.conf = " & _
             "GUESTTBL.conf SET payment.f_name = [guesttbl].[f_name], payment.l_name = [guesttbl].[l_name];"
gBNB.Execute "INSERT INTO paymentreceived (conf,amountreceived,datereceived," & _
             "receivedfrom,checknumber,appliedto,comments) " & _
             "SELECT conf,deprecvd,drecdate,l_name,depcheck,'Deposit','' " & _
             "FROM r_paytbl;"
gBNB.Execute "INSERT INTO paymentreceived (conf,amountreceived,datereceived," & _
             "receivedfrom,checknumber,appliedto,comments) " & _
             "SELECT conf,prerecvd,precdate,l_name,precheck,'Prepayment','' " & _
             "FROM r_paytbl;"
gBNB.Execute "DELETE FROM paymentreceived WHERE ISNULL(amountreceived);"
gBNB.Execute "UPDATE PaymentReceived INNER JOIN GUESTTBL ON PaymentReceived.conf = GUESTTBL.conf SET PaymentReceived.ReceivedFrom = [guesttbl].[l_name];"
gBNB.Execute "INSERT INTO tamaster (accountnum,agencyname,address,city,state," & _
             "zipcode,phone,fax,suppress,comments) " & _
             "SELECT agencynum,agency,address,city,state,zipcode,phone,fax,ta_lbl,'' " & _
             "FROM r_tamastr;"
gBNB.Execute "INSERT INTO tagentbl (conf,f_name,l_name,agentname,commdue," & _
             "commpaid,commdate,checknum,comment,ta_lbl,accountnum,agencyname) " & _
             "SELECT conf,f_name,l_name,agfirst & ' ' & aglast,commdue," & _
             "commpaid,commdate,chk,ta_cmnts,ta_lbl,agency,'' " & _
             "FROM r_tagent;"
gBNB.Execute "UPDATE tagentbl INNER JOIN tamaster ON tagentbl.accountnum = tamaster.accountnum SET tagentbl.agencyname = [tamaster].[agencyname];"
gBNB.Execute "INSERT INTO checktbl(conf,location,arrdate,nwtax,trueamt,l_name," & _
             "depdate,checknum,chk_date,comments,void_chk,print_to,accountnum,checkcategory," & _
             "subcategory,accom_rowid) " & _
             "SELECT conf,'',Null,Null,commpaid,l_name,Null,chk,commdate,'',0,'',agency," & _
             "'Travel','',Null " & _
             "FROM r_tagent " & _
             "WHERE NOT ISNULL(commpaid) And chk <> '';"
gBNB.Execute "UPDATE bbtbl INNER JOIN guesttbl ON bbtbl.conf=guesttbl.conf " & _
             "SET bbtbl.entrydate=guesttbl.datebkd,bbtbl.updatedate=bbtbl.rev_date;"
gBNB.Execute "UPDATE guesttbl SET entrydate=datebkd;"
gBNB.Execute "UPDATE CHECKTBL INNER JOIN PROPTBL " & _
             "ON CHECKTBL.accountnum = PROPTBL.accountnum " & _
             "SET CHECKTBL.print_to = [proptbl].[check_to] " & _
             "WHERE (CHECKTBL.print_to = '' Or CHECKTBL.print_to IS NULL) " & _
             "AND CHECKTBL.CheckCategory='Host';"
gBNB.Execute "UPDATE CHECKTBL INNER JOIN tamaster " & _
             "ON CHECKTBL.accountnum = tamaster.accountnum " & _
             "SET CHECKTBL.print_to = [tamaster].[AgencyName] " & _
             "WHERE (CHECKTBL.print_to = '' Or CHECKTBL.print_to IS NULL) " & _
             "AND CHECKTBL.CheckCategory='Travel';"
gBNB.Execute "INSERT INTO checktbl (conf,location,arrdate,nwtax,trueamt," & _
             "l_name,depdate,checknum,comments,void_chk,chk_date,print_to," & _
             "accountnum,checkcategory,SubCategory,Accom_RowId) " & _
             "SELECT conf,'',Null,Null,refundowed,l_name,Null,'','Guest Refund',0," & _
             "refdate,'',Null,'Host','Guest Refund',Null " & _
             "FROM payment " & _
             "WHERE refundowed IS NOT NULL And refdate IS NOT NULL;"
gBNB.Execute "UPDATE proptbl SET fullname = '' WHERE IsNull(fullname)"
gBNB.Execute "UPDATE proptbl SET mailaddress = '' WHERE IsNull(mailaddress)"
gBNB.Execute "UPDATE proptbl SET mailcity = '' WHERE IsNull(mailcity)"
gBNB.Execute "UPDATE proptbl SET mailstate = '' WHERE IsNull(mailstate)"
gBNB.Execute "UPDATE proptbl SET mailzipcode = '' WHERE IsNull(mailzipcode)"
gBNB.Execute "UPDATE proptbl SET mailphone1 = '' WHERE IsNull(mailphone1)"
gBNB.Execute "UPDATE proptbl SET mailphone2 = '' WHERE IsNull(mailphone2)"
gBNB.Execute "UPDATE proptbl SET mailfax = '' WHERE IsNull(mailfax)"
gBNB.Execute "UPDATE proptbl SET propaddress = '' WHERE IsNull(propaddress)"
gBNB.Execute "UPDATE proptbl SET propcity = '' WHERE IsNull(propcity)"
gBNB.Execute "UPDATE proptbl SET propstate = '' WHERE IsNull(propstate)"
gBNB.Execute "UPDATE proptbl SET propzipcode = '' WHERE IsNull(propzipcode)"
gBNB.Execute "UPDATE proptbl SET propphone = '' WHERE IsNull(propphone)"
gBNB.Execute "UPDATE proptbl SET propfax = '' WHERE IsNull(propfax)"
'TO DO (Manually) AFTER THIS PROCESS IS COMPLETE:
'1. Need to get all voided Travel check numbers and set the
'   Void checkbox for those check numbers.
'**** TESTED OK - END CONVERSION PROCESS *************

ConvertRbaseToAccess_Resume:
   Screen.MousePointer = DEFAULT
   If FormLoaded(frmStatus) Then Unload frmStatus
   Exit Sub

ConvertRbaseToAccess_Error:
  MsgBox Err.Description
  Resume ConvertRbaseToAccess_Resume

End Sub


Private Sub mnuVersion_Click()

   frmAbout.Show 1
    
End Sub




