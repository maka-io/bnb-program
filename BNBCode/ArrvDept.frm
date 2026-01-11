VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Begin VB.Form frmArriveDepart 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Arrivals/Departures Dialog Box"
   ClientHeight    =   2715
   ClientLeft      =   2715
   ClientTop       =   2550
   ClientWidth     =   3375
   HelpContextID   =   136
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2715
   ScaleWidth      =   3375
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   255
      Left            =   60
      TabIndex        =   5
      Top             =   1860
      Width           =   2175
      _Version        =   65536
      _ExtentX        =   3836
      _ExtentY        =   450
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
      Value           =   -1  'True
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
      Height          =   405
      Left            =   60
      TabIndex        =   6
      Top             =   2280
      Width           =   1455
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
      Height          =   405
      Left            =   1860
      TabIndex        =   7
      Top             =   2280
      Width           =   1455
   End
   Begin VB.Frame fraDateRange 
      Caption         =   "Date Range"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1575
      Left            =   60
      TabIndex        =   0
      Top             =   120
      Width           =   3255
      Begin VB.OptionButton optDepartures 
         Caption         =   "Show Departures"
         Height          =   195
         Left            =   120
         TabIndex        =   4
         Top             =   1200
         Width           =   2055
      End
      Begin VB.OptionButton optArrivals 
         Caption         =   "Show Arrivals"
         Height          =   195
         Left            =   120
         TabIndex        =   3
         Top             =   840
         Width           =   2055
      End
      Begin VB.TextBox txtEndDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2190
         TabIndex        =   2
         Tag             =   "Date"
         Top             =   330
         Width           =   915
      End
      Begin VB.TextBox txtStartDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   600
         TabIndex        =   1
         Tag             =   "Date"
         Top             =   330
         Width           =   915
      End
      Begin VB.Label lblStartDate 
         Caption         =   "Start:"
         Height          =   225
         Left            =   120
         TabIndex        =   9
         Top             =   390
         Width           =   495
      End
      Begin VB.Label lblEndDate 
         Caption         =   "through"
         Height          =   225
         Left            =   1560
         TabIndex        =   8
         Top             =   390
         Width           =   615
      End
   End
End
Attribute VB_Name = "frmArriveDepart"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub cmdExit_Click()
   Unload Me
End Sub


Private Sub cmdOK_Click()
  
  On Error GoTo cmdOK_Error
  
  If Trim(txtStartDate.Text) = "" Then
     MsgBox "A Start Date must be entered.", MB_ICONSTOP, Me.Caption
     GoTo cmdOK_Resume
  End If
  'Validate date and number formats here
  If Not VerifyUpdate() Then
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo cmdOK_Resume
  End If
  If Trim(txtStartDate.Text) = "" Then
     MsgBox "Starting Date cannot be blank.", MB_ICONSTOP, Me.Caption
     GoTo cmdOK_Resume
  End If
  If Trim(txtEndDate.Text) <> "" Then
     If CDate(txtStartDate.Text) > CDate(txtEndDate.Text) Then
        MsgBox "Starting Date cannot be greater than ending date.", MB_ICONSTOP, Me.Caption
        GoTo cmdOK_Resume
     End If
  End If
  
  WriteIniSettings
  
  Me.Hide
  
cmdOK_Resume:
  Dim X&
  X& = SetActiveWindow(mdiBNB.hwnd)
  Screen.MousePointer = DEFAULT
  Exit Sub
   
cmdOK_Error:
  'MsgBox Err.Description
  Resume cmdOK_Resume
   
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
















Private Sub Form_Activate()

   GetIniSettings
   Screen.MousePointer = DEFAULT

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
    X = GetPrivateProfileString("Arrivals And Departures Report", "Arrivals", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optArrivals.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Arrivals And Departures Report", "Departures", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optDepartures.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Arrivals And Departures Report", "StartDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtStartDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Arrivals And Departures Report", "EndDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtEndDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Arrivals And Departures Report", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
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

Public Sub WriteIniSettings()

    'Declare variables
    Dim X As Integer        'Return Value
    Dim winDir, iniFile, TempStr As String
    'Get the directory in which the Windows and the .INI files reside.
    'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())
    'Detemine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"
'SAVE SETTINGS (always save this)
    'Write the Save Settings check box setting to the .INI file.
'MsgBox Str(chkSaveSettings.Value)
    If chkSaveSettings.Value = CHECKED Then
        X = WritePrivateProfileString("Arrivals And Departures Report", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Arrivals And Departures Report", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Arrivals And Departures Report", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub
    X = WritePrivateProfileString("Arrivals And Departures Report", "Arrivals", Format$(optArrivals.Value), iniFile)
    X = WritePrivateProfileString("Arrivals And Departures Report", "Departures", Format$(optDepartures.Value), iniFile)
    X = WritePrivateProfileString("Arrivals And Departures Report", "StartDate", txtStartDate.Text, iniFile)
    X = WritePrivateProfileString("Arrivals And Departures Report", "EndDate", txtEndDate.Text, iniFile)

End Sub

Private Sub Form_Unload(Cancel As Integer)

   WriteIniSettings
   
End Sub







