VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{00025600-0000-0000-C000-000000000046}#5.1#0"; "CRYSTL32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmCheckLedger 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Check Ledger Summary Report Dialog Box"
   ClientHeight    =   2370
   ClientLeft      =   1605
   ClientTop       =   2175
   ClientWidth     =   6795
   HelpContextID   =   115
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2370
   ScaleWidth      =   6795
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   195
      Left            =   2850
      TabIndex        =   8
      Top             =   1620
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
   Begin Threed.SSCheck chkDisplayOnly 
      Height          =   195
      Left            =   2850
      TabIndex        =   7
      Top             =   1290
      Width           =   2295
      _Version        =   65536
      _ExtentX        =   4048
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
      Left            =   2850
      TabIndex        =   9
      Top             =   1980
      Width           =   1275
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
      Height          =   345
      Left            =   4170
      TabIndex        =   10
      Top             =   1980
      Width           =   1275
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
      Left            =   5490
      TabIndex        =   11
      Top             =   1980
      Width           =   1275
   End
   Begin Crystal.CrystalReport CheckLedger1 
      Left            =   840
      Top             =   2520
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   348160
      WindowMaxButton =   0   'False
      WindowState     =   2
      PrintFileLinesPerPage=   60
      WindowShowExportBtn=   0   'False
      WindowShowCloseBtn=   -1  'True
      WindowShowSearchBtn=   -1  'True
      WindowShowPrintSetupBtn=   -1  'True
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   240
      Top             =   2520
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Frame fraDateRange 
      Caption         =   "Check Print Date Range"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1035
      Left            =   2850
      TabIndex        =   12
      Top             =   90
      Width           =   3915
      Begin VB.TextBox txtEndDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2700
         TabIndex        =   6
         Tag             =   "Date"
         Top             =   450
         Width           =   975
      End
      Begin VB.TextBox txtStartDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   960
         TabIndex        =   5
         Tag             =   "Date"
         Top             =   450
         Width           =   975
      End
      Begin VB.Label lblEndDate 
         Caption         =   "through"
         Height          =   225
         Left            =   2040
         TabIndex        =   14
         Top             =   510
         Width           =   615
      End
      Begin VB.Label lblStartDate 
         Caption         =   "Start Date:"
         Height          =   225
         Left            =   120
         TabIndex        =   13
         Top             =   510
         Width           =   975
      End
   End
   Begin VB.Frame fraCategory 
      Caption         =   "Check Category"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2235
      Left            =   60
      TabIndex        =   0
      Top             =   90
      Width           =   2715
      Begin VB.OptionButton optAll 
         Caption         =   "All"
         Height          =   195
         Left            =   180
         TabIndex        =   4
         Top             =   1560
         Width           =   2355
      End
      Begin VB.OptionButton optMisc 
         Caption         =   "Miscellaneous"
         Height          =   195
         Left            =   180
         TabIndex        =   3
         Top             =   1140
         Width           =   2355
      End
      Begin VB.OptionButton optTravel 
         Caption         =   "Travel"
         Height          =   195
         Left            =   180
         TabIndex        =   2
         Top             =   720
         Width           =   2415
      End
      Begin VB.OptionButton optHost 
         Caption         =   "Host"
         Height          =   195
         Left            =   180
         TabIndex        =   1
         Top             =   330
         Width           =   2415
      End
   End
End
Attribute VB_Name = "frmCheckLedger"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim SAW As Long
Private Sub cmdExit_Click()
   Unload Me
End Sub

Private Sub cmdPrint_Click()
    
  'This Sub will drive the Crystal report CheckLedger1.rpt based upon
  'user settings on the frmCheckLedger dialog box form.
  'Primary table for report CHECKTBL.
  On Error GoTo cmdPrint_Click_Error

  Screen.MousePointer = HOURGLASS
  'Validate date and number formats here
  If Not VerifyUpdate() Then
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  End If
  
  Dim vNowTemp As Date
  Dim vNumMonths As Integer
  Dim vSYear, vSMonth, vSDay As String
  Dim vEYear, vEMonth, vEDay As String
  Dim vStartDate, vEndDate, vCategory As String
  
  If Trim(txtStartDate.Text) = "" Then
     MsgBox "Starting Date cannot be blank.", MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  End If
  'Get category option
  If optHost.Value = CHECKED Then
     vCategory = "Host"
  ElseIf optTravel.Value = CHECKED Then
     vCategory = "Travel"
  ElseIf optMisc.Value = CHECKED Then
     vCategory = "Miscellaneous"
  ElseIf optAll.Value = CHECKED Then
     vCategory = ""
  Else
     MsgBox "Category has not been selected.", MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  End If
  'MsgBox vCategory
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
  'Set start year values
  vSYear = DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy"))
  vSMonth = DatePart("m", Format(vStartDate, "mm/dd/yyyy"))
  vSDay = DatePart("d", Format(vStartDate, "mm/dd/yyyy"))
  If vEndDate <> "" Then
     vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
     vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
     vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
     If vCategory <> "" Then
        'NOTE: In next line, specifying date range first and CheckCategory last
        '      produces MUCH faster query return than the other way around!!
        CheckLedger1.SelectionFormula = "{checktbl.chk_date} >= Date(" & _
                  vSYear & "," & vSMonth & "," & vSDay & ")" & _
                  " And {checktbl.chk_date} <= Date(" & _
                  vEYear & "," & vEMonth & "," & vEDay & ") " & _
                  "And {checktbl.CheckCategory} = '" & vCategory & "'"
     Else
        CheckLedger1.SelectionFormula = "{checktbl.chk_date} >= Date(" & _
                  vSYear & "," & vSMonth & "," & vSDay & ")" & _
                  " And {checktbl.chk_date} <= Date(" & _
                  vEYear & "," & vEMonth & "," & vEDay & ")"
     End If
'MsgBox CheckLedger1.SelectionFormula
  Else
     If vCategory <> "" Then
        CheckLedger1.SelectionFormula = "{checktbl.chk_date} >= Date(" & _
                  vSYear & "," & vSMonth & "," & vSDay & ") " & _
                  "And {checktbl.CheckCategory} = '" & vCategory & "'"
     Else
        CheckLedger1.SelectionFormula = "{checktbl.chk_date} >= Date(" & _
                  vSYear & "," & vSMonth & "," & vSDay & ")"
     End If
'MsgBox CheckLedger1.SelectionFormula
  End If
     
  'Setup report options
  'CheckLedger1.WindowMinButton = False
  'Set Sort order
  CheckLedger1.SortFields(0) = "+{checktbl.chk_date}"
  CheckLedger1.SortFields(1) = "+{checktbl.checknum}"
  'Fix directories when setup is done.
  CheckLedger1.ReportFileName = gDBDirectory & "ChkLedgr.rpt"
  CheckLedger1.DataFiles(0) = gDatabaseName
  If chkDisplayOnly.Value = CHECKED Then
     CheckLedger1.Destination = 0
  Else
     CheckLedger1.Destination = 1
  End If
  'Print report for current Account Num.
  CheckLedger1.Action = 1
 
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

Private Sub Form_Activate()
   
'If this form is in the background (does not have focus) and the
'Minimize button is clicked on this form that does not yet have the focus,
'an endless loop of Minimizing and Activating will occur. The following
'line prevents this interesting problem.
If Me.WindowState = MINIMIZED Then Exit Sub

GetIniSettings
   
End Sub

Private Sub Form_Load()
   Screen.MousePointer = DEFAULT
End Sub



Public Sub WriteIniSettings()

    'Declare variables
    Dim X As Integer        'Return Value
    Dim winDir, iniFile, Temp As String
    'Get the directory in which the Windows and the .INI files reside.
    'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())
    'Determine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"
'SAVE SETTINGS (always save this)
    'Write the Save Settings check box setting to the .INI file.
'MsgBox Str(chkSaveSettings.Value)
    If chkSaveSettings.Value = CHECKED Then
        X = WritePrivateProfileString("Check Ledger Report", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Check Ledger Report", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Check Ledger Report", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub
   ' X = WritePrivateProfileString("Net Summary Report", "ShowTop", Format$(txtShowTop.Text), iniFile)
    X = WritePrivateProfileString("Check Ledger Report", "Host", Format$(optHost.Value), iniFile)
    X = WritePrivateProfileString("Check Ledger Report", "Travel", Format$(optTravel.Value), iniFile)
    X = WritePrivateProfileString("Check Ledger Report", "Misc", Format$(optMisc.Value), iniFile)
    X = WritePrivateProfileString("Check Ledger Report", "All", Format$(optAll.Value), iniFile)
    X = WritePrivateProfileString("Check Ledger Report", "DisplayOnly", Format$(chkDisplayOnly.Value), iniFile)
    X = WritePrivateProfileString("Check Ledger Report", "StartDate", txtStartDate.Text, iniFile)
    X = WritePrivateProfileString("Check Ledger Report", "EndDate", txtEndDate.Text, iniFile)
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
    'Determine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"

   ' X = GetPrivateProfileString("Check Ledger Report", "ShowTop", "100", Rs, Len(Rs), iniFile)
   ' If X > 0 Then txtShowTop.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Ledger Report", "Host", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optHost.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Ledger Report", "Travel", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optTravel.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Ledger Report", "Misc", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optMisc.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Ledger Report", "All", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optAll.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    
    X = GetPrivateProfileString("Check Ledger Report", "StartDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtStartDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Ledger Report", "EndDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtEndDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Ledger Report", "DisplayOnly", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then chkDisplayOnly.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
      
   ' x = GetPrivateProfileString("Confirmation Report", "ConfirmToOther", "False", Rs, Len(Rs), iniFile)
   ' If x > 0 Then optOther.Value = Left$(Rs, x)     ' Trim Buffer. a string was returned.
'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Check Ledger Report", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
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


