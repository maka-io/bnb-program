VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Begin VB.Form frmCarRentalActivity 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Car Rental Activity Dialog Box"
   ClientHeight    =   3690
   ClientLeft      =   2715
   ClientTop       =   2550
   ClientWidth     =   3375
   HelpContextID   =   138
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3690
   ScaleWidth      =   3375
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   255
      Left            =   60
      TabIndex        =   11
      Top             =   2880
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
   Begin VB.Data datAgencyName 
      Appearance      =   0  'Flat
      Caption         =   "datAgencyName"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   60
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   3720
      Visible         =   0   'False
      Width           =   2835
   End
   Begin SSDataWidgets_B.SSDBCombo datdwComboAgency 
      Bindings        =   "CarActiv.frx":0000
      DataField       =   "AgencyName"
      Height          =   315
      Left            =   60
      TabIndex        =   1
      Tag             =   "Text"
      Top             =   360
      Width           =   3135
      ListWidthAutoSize=   0   'False
      MaxDropDownItems=   10
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
      _ExtentX        =   5530
      _ExtentY        =   556
      _StockProps     =   93
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
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
      Top             =   3240
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
      Top             =   3240
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
      Top             =   1200
      Width           =   3255
      Begin VB.OptionButton optDropOff 
         Caption         =   "Drop-off date"
         Height          =   195
         Left            =   120
         TabIndex        =   5
         Top             =   1200
         Width           =   2055
      End
      Begin VB.OptionButton optPickUp 
         Caption         =   "Pick-up date"
         Height          =   195
         Left            =   120
         TabIndex        =   4
         Top             =   840
         Width           =   2055
      End
      Begin VB.TextBox txtEndDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2190
         TabIndex        =   3
         Tag             =   "Date"
         Top             =   330
         Width           =   915
      End
      Begin VB.TextBox txtStartDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   600
         TabIndex        =   2
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
   Begin VB.Label lblLabelAcctNum 
      Caption         =   "Account Number:"
      Enabled         =   0   'False
      Height          =   255
      Left            =   120
      TabIndex        =   13
      Top             =   780
      Width           =   1395
   End
   Begin VB.Label lblAcctNum 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BorderStyle     =   1  'Fixed Single
      Enabled         =   0   'False
      ForeColor       =   &H80000008&
      Height          =   255
      Left            =   1560
      TabIndex        =   12
      Top             =   750
      Width           =   795
   End
   Begin VB.Label lblAgency 
      Caption         =   "Rental Agency Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   10
      Top             =   120
      Width           =   1995
   End
End
Attribute VB_Name = "frmCarRentalActivity"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub cmdExit_Click()
   Unload Me
End Sub


Private Sub cmdOK_Click()
  
  On Error GoTo cmdOK_Click_Error
  If Trim(txtStartDate.Text) = "" Then
     MsgBox "A Start Date must be entered.", MB_ICONSTOP, Me.Caption
     GoTo cmdOK_Click_Resume
  End If
  'Validate date and number formats here
  If Not VerifyUpdate() Then
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo cmdOK_Click_Resume
  End If
  
  WriteIniSettings
  
  Me.Hide
  
cmdOK_Click_Resume:
  Dim X&
  X& = SetActiveWindow(mdiBNB.hwnd)
  Screen.MousePointer = DEFAULT
  Exit Sub

cmdOK_Click_Error:
  Resume cmdOK_Click_Resume
  
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






Private Sub datdwComboAgency_Change()

  'Selecting from dropdown doesn't fire Change event.
  'We can use this fact to know when user types into box
  lblAcctNum.Caption = ""
   
End Sub

Private Sub datdwComboAgency_CloseUp()

   'MsgBox "closeup"
   If Trim(datdwComboAgency.Text) <> "" Then
      lblAcctNum.Caption = datdwComboAgency.Columns("AccountNum").CellValue(datdwComboAgency.SelBookmarks(0))
   End If
   
End Sub

Private Sub datdwComboAgency_DropDown()

   datdwComboAgency.DefColWidth = datdwComboAgency.Width * 0.5
   datdwComboAgency.DataFieldList = "AgencyName"
   datdwComboAgency.ListWidth = datdwComboAgency.Width * 2
   datAgencyName.RecordSource = "select AgencyName,AccountNum,Address,City,State from CarMaster order by AgencyName"
   If Not GetDCRows(datAgencyName) Then Exit Sub

End Sub

Private Sub datdwComboAgency_KeyUp(KeyCode As Integer, Shift As Integer)
  ' If Trim(datdwComboAgency.Text) <> "" Then
  '    lblAcctNum.Caption = datdwComboAgency.Columns("AccountNum").CellValue(datdwComboAgency.SelBookmarks(0))
  ' End If
End Sub


Private Sub Form_Activate()

   GetIniSettings
   Screen.MousePointer = DEFAULT

End Sub

Private Sub Form_Load()

   datdwComboAgency.DefColWidth = datdwComboAgency.Width * 0.5
   datdwComboAgency.DataFieldList = "AgencyName"
   datdwComboAgency.ListWidth = datdwComboAgency.Width * 2
   datAgencyName.DatabaseName = gDatabaseName
   datAgencyName.RecordSource = "select AgencyName,AccountNum,Address,City,State from CarMaster order by AgencyName"
   If Not GetDCRows(datAgencyName) Then Exit Sub
   
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
    X = GetPrivateProfileString("Car Rental Activity Report", "AgencyName", "", Rs, Len(Rs), iniFile)
    If X > 0 Then datdwComboAgency.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Car Rental Activity Report", "AccountNum", "", Rs, Len(Rs), iniFile)
    If X > 0 Then lblAcctNum.Caption = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Car Rental Activity Report", "PickupDate", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optPickUp.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Car Rental Activity Report", "DropoffDate", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optDropOff.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Car Rental Activity Report", "StartDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtStartDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Car Rental Activity Report", "EndDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtEndDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
   ' x = GetPrivateProfileString("Confirmation Report", "ConfirmToOther", "False", Rs, Len(Rs), iniFile)
   ' If x > 0 Then optOther.Value = Left$(Rs, x)     ' Trim Buffer. a string was returned.
'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Car Rental Activity Report", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
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
        X = WritePrivateProfileString("Car Rental Activity Report", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Car Rental Activity Report", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Car Rental Activity Report", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub
    X = WritePrivateProfileString("Car Rental Activity Report", "AgencyName", Format$(datdwComboAgency.Text), iniFile)
    X = WritePrivateProfileString("Car Rental Activity Report", "AccountNum", Format$(lblAcctNum.Caption), iniFile)
    X = WritePrivateProfileString("Car Rental Activity Report", "PickupDate", Format$(optPickUp.Value), iniFile)
    X = WritePrivateProfileString("Car Rental Activity Report", "DropoffDate", Format$(optDropOff.Value), iniFile)
    X = WritePrivateProfileString("Car Rental Activity Report", "StartDate", txtStartDate.Text, iniFile)
    X = WritePrivateProfileString("Car Rental Activity Report", "EndDate", txtEndDate.Text, iniFile)
  
End Sub

Private Sub Form_Unload(Cancel As Integer)

   WriteIniSettings
   
End Sub


