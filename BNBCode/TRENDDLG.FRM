VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Begin VB.Form frmTrendsDialog 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Trends Dialog Box"
   ClientHeight    =   2400
   ClientLeft      =   1980
   ClientTop       =   3045
   ClientWidth     =   7005
   HelpContextID   =   121
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   2400
   ScaleWidth      =   7005
   Begin VB.Data datPropertyName 
      Appearance      =   0  'Flat
      Caption         =   "datPropertyName"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   120
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   2520
      Visible         =   0   'False
      Width           =   3075
   End
   Begin VB.TextBox txtEndDate 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   5580
      TabIndex        =   9
      Top             =   480
      Width           =   1395
   End
   Begin VB.TextBox txtStartDate 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   5580
      TabIndex        =   8
      Top             =   150
      Width           =   1395
   End
   Begin VB.OptionButton optCancelled 
      Caption         =   "optCancelled"
      Height          =   195
      Left            =   3360
      TabIndex        =   21
      Top             =   2520
      Visible         =   0   'False
      Width           =   1995
   End
   Begin VB.HScrollBar hsbThreshold 
      Height          =   255
      LargeChange     =   5
      Left            =   5940
      Max             =   200
      Min             =   1
      TabIndex        =   13
      Top             =   1320
      Value           =   10
      Width           =   1035
   End
   Begin VB.HScrollBar hsbFrequency 
      Height          =   255
      LargeChange     =   5
      Left            =   5940
      Max             =   5000
      Min             =   1
      TabIndex        =   11
      Top             =   960
      Value           =   1
      Width           =   1035
   End
   Begin VB.TextBox txtThreshold 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   5340
      TabIndex        =   12
      Tag             =   "Text"
      Text            =   "10"
      Top             =   1320
      Width           =   435
   End
   Begin VB.TextBox txtFrequency 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   5340
      TabIndex        =   10
      Tag             =   "Text"
      Text            =   "1"
      Top             =   960
      Width           =   435
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "&OK"
      Default         =   -1  'True
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
      TabIndex        =   16
      Top             =   1980
      Width           =   1215
   End
   Begin VB.CommandButton cmdCancel 
      Caption         =   "&Cancel"
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
      Left            =   4440
      TabIndex        =   15
      Top             =   1980
      Width           =   1215
   End
   Begin VB.Frame fraBy 
      Caption         =   "By"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2295
      Left            =   1860
      TabIndex        =   18
      Top             =   60
      Width           =   2475
      Begin SSDataWidgets_B.SSDBCombo datdwComboPropertyName 
         Bindings        =   "TRENDDLG.frx":0000
         Height          =   315
         Left            =   120
         TabIndex        =   7
         Tag             =   "Text"
         Top             =   1770
         Width           =   2295
         DataFieldList   =   "location"
         _Version        =   131078
         BeginProperty HeadFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Columns(0).Width=   3200
         _ExtentX        =   4048
         _ExtentY        =   556
         _StockProps     =   93
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         DataFieldToDisplay=   "location"
      End
      Begin VB.OptionButton optYear 
         Caption         =   "Year"
         Height          =   255
         Left            =   120
         TabIndex        =   6
         Tag             =   "year"
         Top             =   1200
         Width           =   1395
      End
      Begin VB.OptionButton optMonth 
         Caption         =   "Month"
         Height          =   255
         Left            =   120
         TabIndex        =   5
         Tag             =   "month"
         Top             =   780
         Width           =   1395
      End
      Begin VB.OptionButton optProperty 
         Caption         =   "Property Name"
         Height          =   255
         Left            =   120
         TabIndex        =   4
         Tag             =   "location"
         Top             =   360
         Value           =   -1  'True
         Width           =   1455
      End
      Begin VB.Label lblPropertyName 
         Caption         =   "Property:"
         Height          =   195
         Left            =   120
         TabIndex        =   24
         Top             =   1590
         Width           =   1035
      End
   End
   Begin VB.Frame fraShow 
      Caption         =   "Show"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2295
      Left            =   0
      TabIndex        =   17
      Top             =   60
      Width           =   1815
      Begin VB.OptionButton optBookings 
         Caption         =   "Bookings"
         Height          =   285
         Left            =   120
         TabIndex        =   3
         Tag             =   "guesttbl.datebkd"
         Top             =   1800
         Width           =   1455
      End
      Begin VB.OptionButton optReservationFee 
         Caption         =   "Reservation Fee"
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Tag             =   "guesttbl.resfee"
         Top             =   1320
         Width           =   1575
      End
      Begin VB.OptionButton optServiceFee 
         Caption         =   "Service Fee"
         Height          =   255
         Left            =   120
         TabIndex        =   1
         Tag             =   "bbtbl.svcharge"
         Top             =   840
         Width           =   1575
      End
      Begin VB.OptionButton optRoomNights 
         Caption         =   "Room Nights"
         Height          =   255
         Left            =   120
         TabIndex        =   0
         Tag             =   "bbtbl.numnites"
         Top             =   360
         Value           =   -1  'True
         Width           =   1575
      End
   End
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   195
      Left            =   4440
      TabIndex        =   14
      Top             =   1680
      Width           =   1875
      _Version        =   65536
      _ExtentX        =   3307
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
   Begin VB.Label lblEndDate 
      Caption         =   "Ending Date:"
      Height          =   195
      Left            =   4440
      TabIndex        =   23
      Top             =   540
      Width           =   1035
   End
   Begin VB.Label lblStartDate 
      Caption         =   "Starting Date:"
      Height          =   195
      Left            =   4440
      TabIndex        =   22
      Top             =   180
      Width           =   1035
   End
   Begin VB.Label lblThreshold 
      Caption         =   "Threshold:"
      Height          =   255
      Left            =   4440
      TabIndex        =   20
      Top             =   1320
      Width           =   855
   End
   Begin VB.Label lblFrequency 
      Caption         =   "Frequency:"
      Height          =   255
      Left            =   4440
      TabIndex        =   19
      Top             =   960
      Width           =   855
   End
End
Attribute VB_Name = "frmTrendsDialog"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False



Private Sub cmdCancel_Click()
    
    On Error GoTo cmdCancel_Click_Error
    'Flag that form was exited via cancel button.
    optCancelled = True
    WriteIniSettings
    'Hide the dialog box and resume calling procedure execution.
    Me.Hide

cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume
   
End Sub


Private Sub cmdOK_Click()

    On Error GoTo cmdOK_Click_Error
    If Not VerifyEntry() Then
      MsgBox gMsg
      GoTo cmdOK_Click_Resume
    End If
    'Write the current dialog box settings to the .INI file if instructed by the user.
    'If chkSaveSettings.Value = CHECKED Then WriteIniSettings
    WriteIniSettings
    'Flag that form was not cancelled. (i.e. OK exit)
    optCancelled = False
    'Hide the dialog box and resume calling procedure execution.
    Me.Hide
    DoEvents
    
cmdOK_Click_Resume:
    Screen.MousePointer = DEFAULT
    Dim X&
    X& = SetActiveWindow(mdiBNB.hwnd)
    Exit Sub
    
cmdOK_Click_Error:
   Resume cmdOK_Click_Resume
    
End Sub

Private Sub datdwComboPropertyName_DropDown()

   datdwComboPropertyName.DefColWidth = datdwComboPropertyName.Width * 1.2
   datPropertyName.RecordSource = "select location,AccountNum from proptbl where PropObsolete<>-1 order by location"
   If Not GetDCRows(datPropertyName) Then Exit Sub

End Sub

Private Sub Form_Activate()

  On Error GoTo Activate_Error

  'If this form is in the background (does not have focus) and the
  'Minimize button is clicked on this form that does not yet have the focus,
  'an endless loop of Minimizing and Activating will occur. The following
  'line prevents this interesting problem.
  If Me.WindowState = MINIMIZED Then Exit Sub

  cmdOK.SetFocus
  GetIniSettings

Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

Activate_Error:
   Resume Activate_Resume
  
End Sub

Private Sub Form_Load()

   On Error GoTo Load_Error
   
   datPropertyName.DatabaseName = gDatabaseName
   
Load_Resume:
   Exit Sub

Load_Error:
   Resume Load_Resume
   
End Sub


Private Sub Form_Unload(Cancel As Integer)

   On Error GoTo Form_Unload_Error
   
Form_Unload_Resume:
   Screen.MousePointer = DEFAULT
   Dim X&
   X& = SetActiveWindow(mdiBNB.hwnd)
   Exit Sub
   
Form_Unload_Error:
   Resume Form_Unload_Resume
   
End Sub

Private Sub hsbFrequency_Change()
   txtFrequency.Text = Format$(hsbFrequency.Value)
End Sub


Private Sub hsbFrequency_Scroll()
  txtFrequency.Text = Format$(hsbFrequency.Value)
End Sub


Private Sub hsbThreshold_Change()
   txtThreshold.Text = Format$(hsbThreshold.Value)
End Sub


Private Sub hsbThreshold_Scroll()
   txtThreshold.Text = Format$(hsbThreshold.Value)
End Sub



Private Sub optBookings_Click()
   
   If optProperty.Value = CHECKED Then
      optMonth.Value = CHECKED
   End If
   optProperty.Enabled = False
   datdwComboPropertyName.Enabled = False
   lblPropertyName.Enabled = False
   datdwComboPropertyName.Text = ""
               
End Sub

Private Sub optMonth_Click()
   datdwComboPropertyName.Enabled = False
   lblPropertyName.Enabled = False
   datdwComboPropertyName.Text = ""
End Sub

Private Sub optProperty_Click()
   datdwComboPropertyName.Enabled = True
   lblPropertyName.Enabled = True
End Sub

Private Sub optReservationFee_Click()
   
   If optProperty.Value = CHECKED Then
      optMonth.Value = CHECKED
   End If
   optProperty.Enabled = False
   datdwComboPropertyName.Enabled = False
   lblPropertyName.Enabled = False
   datdwComboPropertyName.Text = ""
               
End Sub

Private Sub optRoomNights_Click()
  optProperty.Enabled = True
  optMonth.Enabled = True
  optYear.Enabled = True
  If optProperty.Value Then
     datdwComboPropertyName.Enabled = True
     lblPropertyName.Enabled = True
  Else
     datdwComboPropertyName.Enabled = False
     lblPropertyName.Enabled = False
     datdwComboPropertyName.Text = ""
  End If
End Sub

Private Sub optServiceFee_Click()
  optProperty.Enabled = True
  optMonth.Enabled = True
  optYear.Enabled = True
  If optProperty.Value Then
     datdwComboPropertyName.Enabled = True
     lblPropertyName.Enabled = True
  Else
     datdwComboPropertyName.Enabled = False
     datdwComboPropertyName.Text = ""
     lblPropertyName.Enabled = False
  End If
End Sub

Private Sub optYear_Click()
   datdwComboPropertyName.Enabled = False
   lblPropertyName.Enabled = False
   datdwComboPropertyName.Text = ""
End Sub

Private Sub txtFrequency_LostFocus()
    'Make sure that only digits have been entered.
    If txtFrequency.Text Like "*[!0-9]*" Then
        Beep
        MsgBox "Only numbers between " & hsbFrequency.Min & " and " & hsbFrequency.Max & " are allowed!"
        txtFrequency.SelStart = 0
        txtFrequency.SelLength = Len(txtFrequency.Text)
        txtFrequency.SetFocus
        Exit Sub
    End If
    'Make sure the entered value is within the acceptable range of the scrollbar.
    If CInt(txtFrequency.Text) > hsbFrequency.Max Then
        txtFrequency.Text = Format$(hsbFrequency.Max)
    ElseIf CInt(txtFrequency.Text) < hsbFrequency.Min Then
        txtFrequency.Text = Format$(hsbFrequency.Min)
    End If
    'Change the thumb of the scrollbar to reflect the changed value.
    hsbFrequency.Value = CInt(txtFrequency.Text)

End Sub


Private Sub txtThreshold_LostFocus()
    'Make sure that only digits have been entered.
    If txtThreshold.Text Like "*[!0-9]*" Then
        Beep
        MsgBox "Only numbers between " & hsbThreshold.Min & " and " & hsbThreshold.Max & " are allowed!"
        txtThreshold.SelStart = 0
        txtThreshold.SelLength = Len(txtThreshold.Text)
        txtThreshold.SetFocus
        Exit Sub
    End If
    'Make sure the entered value is within the acceptable range of the scrollbar.
    If CInt(txtThreshold.Text) > hsbThreshold.Max Then
        txtThreshold.Text = Format$(hsbThreshold.Max)
    ElseIf CInt(txtThreshold.Text) < hsbThreshold.Min Then
        txtThreshold.Text = Format$(hsbThreshold.Min)
    End If
    'Change the thumb of the scrollbar to reflect the changed value.
    hsbThreshold.Value = CInt(txtThreshold.Text)

End Sub



Public Function VerifyEntry() As Integer

  VerifyEntry = True

  'Check if all are dates
  If Trim(txtStartDate.Text) <> "" Then
     If Not DateFormatOk(txtStartDate) Then GoTo InvalidDate
  End If
  If Trim(txtEndDate.Text) <> "" Then
     If Not DateFormatOk(txtEndDate) Then GoTo InvalidDate
  End If
  
  If Trim(txtStartDate.Text) <> "" And Trim(txtEndDate.Text) <> "" Then
       'Starting date can't be > Ending date
       If "#" & txtStartDate.Text & "#" > "#" & txtEndDate.Text & "#" Then
          gMsg = "Starting date cannot be greater than ending date."
          VerifyEntry = False
          Exit Function
       End If
  End If
    
  Exit Function
  
InvalidDate:
   gMsg = "Invalid date. Use mm/dd/yy format."
   VerifyEntry = False

End Function

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
    If chkSaveSettings.Value = CHECKED Then
        X = WritePrivateProfileString("Trends Setup", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Trends Setup", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Trends Setup", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub
    X = WritePrivateProfileString("Trends Setup", "StartDate", Format$(txtStartDate.Text, "m/d/yyyy"), iniFile)
    X = WritePrivateProfileString("Trends Setup", "EndDate", Format$(txtEndDate.Text, "m/d/yyyy"), iniFile)
    X = WritePrivateProfileString("Trends Setup", "Frequency", Format$(txtFrequency.Text), iniFile)
    X = WritePrivateProfileString("Trends Setup", "Threshold", Format$(txtThreshold.Text), iniFile)
    X = WritePrivateProfileString("Trends Setup", "RoomNights", Format$(optRoomNights.Value), iniFile)
    X = WritePrivateProfileString("Trends Setup", "ServiceFee", Format$(optServiceFee.Value), iniFile)
    X = WritePrivateProfileString("Trends Setup", "ResFee", Format$(optReservationFee.Value), iniFile)
    X = WritePrivateProfileString("Trends Setup", "Bookings", Format$(optBookings.Value), iniFile)
    X = WritePrivateProfileString("Trends Setup", "Property", Format$(optProperty.Value), iniFile)
    X = WritePrivateProfileString("Trends Setup", "Month", Format$(optMonth.Value), iniFile)
    X = WritePrivateProfileString("Trends Setup", "Year", Format$(optYear.Value), iniFile)

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

    X = GetPrivateProfileString("Trends Setup", "StartDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtStartDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Trends Setup", "EndDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtEndDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Trends Setup", "Frequency", "1", Rs, Len(Rs), iniFile)
    If X > 0 Then
       txtFrequency.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
       hsbFrequency.Value = CInt(Left$(Rs, X))
    End If
    X = GetPrivateProfileString("Trends Setup", "Threshold", "10", Rs, Len(Rs), iniFile)
    If X > 0 Then
       txtThreshold.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
       hsbThreshold.Value = CInt(Left$(Rs, X))
    End If
    X = GetPrivateProfileString("Trends Setup", "RoomNights", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optRoomNights.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Trends Setup", "ServiceFee", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optServiceFee.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Trends Setup", "ResFee", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optReservationFee.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Trends Setup", "Bookings", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optBookings.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Trends Setup", "Property", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optProperty.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Trends Setup", "Month", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optMonth.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Trends Setup", "Year", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optYear.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.

'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Trends Setup", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
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
