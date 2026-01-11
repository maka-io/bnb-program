VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmDBBackup 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Database Backup Dialog Box"
   ClientHeight    =   1740
   ClientLeft      =   1905
   ClientTop       =   2670
   ClientWidth     =   5745
   HelpContextID   =   131
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   1740
   ScaleWidth      =   5745
   Begin VB.OptionButton optCancelled 
      Caption         =   "optCancelled"
      Height          =   285
      Left            =   720
      TabIndex        =   8
      Top             =   1860
      Visible         =   0   'False
      Width           =   1515
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
      Height          =   405
      Left            =   4680
      TabIndex        =   4
      Top             =   750
      Width           =   1035
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "&OK"
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
      Left            =   4680
      TabIndex        =   5
      Top             =   1260
      Width           =   1035
   End
   Begin VB.CommandButton cmdFile 
      Caption         =   "&File..."
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
      Left            =   4680
      TabIndex        =   3
      Top             =   240
      Width           =   1035
   End
   Begin VB.ComboBox txtComboFormat 
      Appearance      =   0  'Flat
      Enabled         =   0   'False
      Height          =   315
      Left            =   1200
      TabIndex        =   1
      Tag             =   "Text"
      Top             =   750
      Width           =   2775
   End
   Begin VB.TextBox txtFileName 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   1200
      Locked          =   -1  'True
      TabIndex        =   0
      Tag             =   "Text"
      Top             =   240
      Width           =   3375
   End
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   195
      Left            =   120
      TabIndex        =   2
      Top             =   1470
      Width           =   2175
      _Version        =   65536
      _ExtentX        =   3836
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "&Save Settings on Exit"
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
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   180
      Top             =   1830
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Label lblFormat 
      Caption         =   "Format:"
      Height          =   255
      Left            =   120
      TabIndex        =   7
      Top             =   840
      Width           =   855
   End
   Begin VB.Label lblFileName 
      Caption         =   "Backup to:"
      Height          =   255
      Left            =   120
      TabIndex        =   6
      Top             =   300
      Width           =   975
   End
End
Attribute VB_Name = "frmDBBackup"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim SAW As Long
Private Sub cmdCancel_Click()
    
    On Error GoTo cmdCancel_Click_Error
    
    optCancelled = True
    cmdOK.SetFocus
    frmDBBackup.Hide
    
cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume
   
End Sub

Private Sub cmdFile_Click()

    On Error GoTo cmdFile_Click_Error

    Dim X As Integer
    
    'Set Common Dialog Font Properites
    CMDialog1.CancelError = True
    CMDialog1.DefaultExt = "mdb"
    CMDialog1.Filter = "Microsoft Access (*.mdb)|*.mdb"
    CMDialog1.FilterIndex = 1
    'Set Common Dialog flags such that:
    '  a) The read only check box is hidden, and
    '  b) That the returned file name will not be a read only file, and that its directory will not be write protected, and
    '  c) That the path must exist.
    CMDialog1.Flags = &H4& Or &H8000& Or &H800& Or &H400&
    If Me.Caption Like "*Restore*" Then
       CMDialog1.ShowOpen
    Else
       CMDialog1.ShowSave
    End If
    'Display file name on dialog box.
    txtFileName.Text = CMDialog1.filename
    
cmdFile_Click_Resume:
    cmdOK.SetFocus
    Screen.MousePointer = DEFAULT
    Exit Sub
    
cmdFile_Click_Error:
    'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
    If Err = cdlCancel Then
       'This will keep background screens from other applications
       'gaining focus mysteriously upon closure of common dialog.
       SAW = SetActiveWindow(mdiBNB.hwnd)
    Else
       MsgBox Err.Description
    End If
    Resume cmdFile_Click_Resume

End Sub

Private Sub cmdOK_Click()

    Dim Response As Integer
    On Error GoTo cmdOK_Click_Error
    If Me.Caption Like "Database Backup*" Then
       'Make sure we have a .mdb file
       If Me.CMDialog1.filename Like "*.*.*" Then
          MsgBox "Too many periods in filename. Click File... to correct.", MB_ICONINFORMATION
          GoTo cmdOK_Click_Resume
       ElseIf Not UCase(Me.CMDialog1.filename) Like "*.MDB" Then
          MsgBox "Backup file is not an Access (*.mdb) file. Click File... to correct.", MB_ICONINFORMATION
          GoTo cmdOK_Click_Resume
       End If
       WriteIniSettings
       optCancelled = False
       Me.Hide
    ElseIf Me.Caption Like "Database Restore*" Then
       '*****Warn user here to logout,etc****
       gMsg = "CAUTION! All existing data will be removed and replaced with the contents of " & _
              "the selected backup file. Any data entered/modified since the last backup " & _
              "will be lost. Continue?"
       If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then
          GoTo cmdOK_Click_Resume
       End If
       If FileExists(Me.CMDialog1.filename) Then
         If Not UCase(Me.CMDialog1.filename) Like "*.MDB" Then
            MsgBox "File to restore is not an Access (*.mdb) file. Click File... to correct.", MB_ICONINFORMATION
            GoTo cmdOK_Click_Resume
         End If
       Else
         MsgBox "Backup file " & Me.CMDialog1.filename & " does not exist. Click File... to correct.", MB_ICONINFORMATION
         GoTo cmdOK_Click_Resume
       End If
       WriteIniSettings
       optCancelled = False
       Me.Hide
    End If
    
cmdOK_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdOK_Click_Error:
    Resume cmdOK_Click_Resume

End Sub


Private Sub Form_Activate()

   'If this form is in the background (does not have focus) and the
   'Minimize button is clicked on this form that does not yet have the focus,
   'an endless loop of Minimizing and Activating will occur. The following
   'line prevents this interesting problem.
   If Me.WindowState = MINIMIZED Then Exit Sub

   If Me.Caption Like "*Restore*" Then lblFileName.Caption = "Restore from:"
   GetIniSettings
   Screen.MousePointer = DEFAULT
End Sub

Private Sub Form_Load()
    'Create a default file name
    txtFileName.Text = CurDir$ & "\" & "BNB1BACK.MDB"
    txtComboFormat.AddItem "Microsoft Access (*.mdb)"
    txtComboFormat.ListIndex = 0
    
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

Private Sub txtFileName_Change()

    'Convert any double backslashes with single.
    'For unknown reason, doubles get into string intermittently.
    Temp = Replace_All_In_With("\\", txtFileName.Text, "\")
    CMDialog1.filename = txtFileName.Text
    
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
    X = GetPrivateProfileString("Backup", "FileName", "BNB1BACK.MDB", Rs, Len(Rs), winDir & UCase$(App.EXEName) & ".INI")
    If X > 0 Then txtFileName.Text = Left$(Rs, X)     ' Trim Buffer 'a string was returned.
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Backup", "SaveSettings", "CHECKED", Rs, Len(Rs), winDir & UCase$(App.EXEName) & ".INI")
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
    Dim winDir, iniFile, Temp As String

    'Get the directory in which the Windows and the .INI files reside.
    'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())
    'Detemine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"
    
'SAVE SETTINGS (always save this)
    'Write the Save Settings check box setting to the .INI file.
    If chkSaveSettings.Value = CHECKED Then
        X = WritePrivateProfileString("Backup", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Backup", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Backup", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub

'GENERAL ...
    'Write the File Name setting to the .INI file.
    X = WritePrivateProfileString("Backup", "FileName", Format$(txtFileName.Text), iniFile)

End Sub
