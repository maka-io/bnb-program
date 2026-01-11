VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmExportDialog 
   Caption         =   "Export File Dialog Box"
   ClientHeight    =   3435
   ClientLeft      =   1605
   ClientTop       =   1950
   ClientWidth     =   6390
   LinkTopic       =   "Form1"
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   3435
   ScaleWidth      =   6390
   Begin VB.OptionButton optCancelled 
      Caption         =   "optCancelled"
      Height          =   285
      Left            =   3960
      TabIndex        =   19
      Top             =   3480
      Width           =   1515
   End
   Begin VB.TextBox txtCallingFormCaption 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   2340
      TabIndex        =   18
      Tag             =   "Text"
      Text            =   "txtCallingFormCaption"
      Top             =   3480
      Width           =   1635
   End
   Begin VB.Frame Frame2 
      Caption         =   "Range"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1665
      Left            =   3180
      TabIndex        =   16
      Top             =   1710
      Width           =   3135
      Begin VB.TextBox txtLastCol 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2280
         MaxLength       =   4
         TabIndex        =   12
         Tag             =   "Number"
         Top             =   780
         Width           =   735
      End
      Begin VB.TextBox txtFirstCol 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   840
         MaxLength       =   4
         TabIndex        =   11
         Tag             =   "Number"
         Top             =   780
         Width           =   735
      End
      Begin VB.TextBox txtLastRow 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2280
         MaxLength       =   4
         TabIndex        =   10
         Tag             =   "Number"
         Top             =   360
         Width           =   735
      End
      Begin VB.TextBox txtFirstRow 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   840
         MaxLength       =   4
         TabIndex        =   9
         Tag             =   "Number"
         Top             =   360
         Width           =   735
      End
      Begin VB.Label lblThru 
         Caption         =   "through"
         Height          =   225
         Index           =   1
         Left            =   1620
         TabIndex        =   24
         Top             =   840
         Width           =   675
      End
      Begin VB.Label lblThru 
         Caption         =   "through"
         Height          =   225
         Index           =   0
         Left            =   1620
         TabIndex        =   23
         Top             =   420
         Width           =   615
      End
      Begin VB.Label lblColumns 
         Caption         =   "Columns:"
         Height          =   255
         Left            =   120
         TabIndex        =   22
         Top             =   840
         Width           =   675
      End
      Begin VB.Label lblRows 
         Caption         =   "Rows:"
         Height          =   285
         Left            =   120
         TabIndex        =   21
         Top             =   420
         Width           =   675
      End
      Begin VB.Label Label1 
         Caption         =   "Note: Row and Column ranges will not be saved on Exit regardless of Save Setting."
         Height          =   435
         Left            =   120
         TabIndex        =   20
         Top             =   1170
         Width           =   2955
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Options"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1665
      Left            =   60
      TabIndex        =   15
      Top             =   1710
      Width           =   3135
      Begin Threed.SSCheck chkAppend 
         Height          =   225
         Left            =   180
         TabIndex        =   5
         Top             =   1140
         Width           =   2115
         _Version        =   65536
         _ExtentX        =   3731
         _ExtentY        =   397
         _StockProps     =   78
         Caption         =   "Append to File (if exists)"
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
      Begin Threed.SSCheck chkHeaders 
         Height          =   225
         Left            =   180
         TabIndex        =   4
         Top             =   720
         Width           =   2115
         _Version        =   65536
         _ExtentX        =   3731
         _ExtentY        =   397
         _StockProps     =   78
         Caption         =   "Include Column Headers"
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
      Begin Threed.SSCheck chkCaption 
         Height          =   225
         Left            =   180
         TabIndex        =   3
         Top             =   300
         Width           =   2115
         _Version        =   65536
         _ExtentX        =   3731
         _ExtentY        =   397
         _StockProps     =   78
         Caption         =   "Include Caption"
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
      Left            =   5280
      TabIndex        =   7
      Top             =   660
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
      Left            =   5280
      TabIndex        =   8
      Top             =   1140
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
      Left            =   5280
      TabIndex        =   6
      Top             =   180
      Width           =   1035
   End
   Begin VB.ComboBox txtComboFormat 
      Appearance      =   0  'Flat
      Height          =   315
      Left            =   960
      TabIndex        =   1
      Tag             =   "Text"
      Top             =   660
      Width           =   2775
   End
   Begin VB.TextBox txtFileName 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   960
      TabIndex        =   0
      Tag             =   "Text"
      Top             =   180
      Width           =   3855
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   180
      Top             =   3480
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   195
      Left            =   120
      TabIndex        =   2
      Top             =   1320
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
   Begin VB.Label Label3 
      Caption         =   "lblCallingFormCaption"
      Height          =   255
      Left            =   720
      TabIndex        =   17
      Top             =   3510
      Width           =   1575
   End
   Begin VB.Label lblFormat 
      Caption         =   "Format:"
      Height          =   255
      Left            =   120
      TabIndex        =   14
      Top             =   750
      Width           =   855
   End
   Begin VB.Label lblFileName 
      Caption         =   "File Name:"
      Height          =   255
      Left            =   120
      TabIndex        =   13
      Top             =   240
      Width           =   855
   End
End
Attribute VB_Name = "frmExportDialog"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim SAW As Long
Private Sub cmdCancel_Click()

    On Error GoTo cmdCancel_Click_Error
    
    optCancelled = True
    cmdOK.SetFocus
    frmExportDialog.Hide
    
cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume
   
End Sub


Private Sub cmdFile_Click()

    On Error GoTo cmdFile_Click_Error
    
    'Set Common Dialog Font Properites
    CMDialog1.CancelError = True
    CMDialog1.DefaultExt = "txt"
    CMDialog1.Filter = "Delimited Text File (*.txt) |*.txt"
    CMDialog1.FilterIndex = 1
    'Set Common Dialog flags such that:
    '  a) The read only check box is hidden, and
    '  b) That the returned file name will not be a read only file, and that its directory will not be write protected, and
    '  c) That the path must exist.
    CMDialog1.Flags = &H4& Or &H8000& Or &H800&
    
'    If chkAppend.Value Then
'      'Append
'      CMDialog1.Action = 1
'    Else
'      'Overwrite
'     CMDialog1.Action = 2
'    End If
    CMDialog1.ShowSave
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
    If txtLastCol.Text = "" Or txtFirstCol.Text = "" Or txtLastRow.Text = "" Or txtFirstRow.Text = "" Then
      Response = MsgBox("Range values are not properly filled in.", MB_ICONEXCLAMATION + MB_OK, Me.Caption)
      Exit Sub
    End If
    'Check for previous instance of file, provided that user does not want to append
    'data to it, such that user will not accidently overwrite existing data.
    If FileExists(CMDialog1.filename) = 1 Then  'Error condition
        Exit Sub
    ElseIf FileExists(CMDialog1.filename) And Not chkAppend.Value Then
        Response = MsgBox("File already exists!  Overwrite it?", MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption)
        If Response = IDNO Then
            'Return to dialog & allow user to rename file or cancel.
            Exit Sub
        Else
            Kill CMDialog1.filename
        End If
    End If
    WriteIniSettings
    optCancelled = False
    Me.Hide

cmdOK_Click_Resume:

Exit Sub

cmdOK_Click_Error:
    Response = IsError("cmdOK_Click")
    Resume cmdOK_Click_Resume

End Sub

Private Sub Form_Activate()

  'If this form is in the background (does not have focus) and the
  'Minimize button is clicked on this form that does not yet have the focus,
  'an endless loop of Minimizing and Activating will occur. The following
  'line prevents this interesting problem.
  If Me.WindowState = MINIMIZED Then Exit Sub

  GetIniSettings

End Sub

Private Sub Form_Load()
    
    'Create a default file name
    txtFileName.Text = CurDir$ & "\" & LCase$(Trim$(Left$(gComputerName, 8))) & ".txt"
    'Load the ComboBox with output file format types.
    txtComboFormat.AddItem "Comma Delimited"
    'txtComboFormat.AddItem "Microsoft Access"
    txtComboFormat.AddItem "Pipe Delimited"
    txtComboFormat.AddItem "Space Delimited"
    txtComboFormat.AddItem "Tab Delimited"
    'Select "Tab Delimited" as the default option.
    txtComboFormat.ListIndex = 3
    
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
    X = GetPrivateProfileString("Export", "FileName", "", Rs, Len(Rs), winDir & UCase$(App.EXEName) & ".INI")
    If X > 0 Then txtFileName.Text = Left$(Rs, X)     ' Trim Buffer 'a string was returned.
    'Get & Set the Row End.
    X = GetPrivateProfileString("Export", "Format", "Tab Delimited", Rs, Len(Rs), winDir & UCase$(App.EXEName) & ".INI")
    If X > 0 Then  'a string was returned.
        For i = 0 To txtComboFormat.ListCount - 1
            If txtComboFormat.List(i) = Left$(Rs, X) Then
                txtComboFormat.ListIndex = i
                Exit For
            End If
        Next i
    End If

'OPTIONS ...
    'Get & Set the Include Caption option.
    X = GetPrivateProfileString("Export", "Caption", "False", Rs, Len(Rs), winDir & UCase$(App.EXEName) & ".INI")
    If X > 0 Then chkCaption.Value = Left$(Rs, X)     ' Trim Buffer 'a string was returned.
    'Get & Set the Include Headers option.
    X = GetPrivateProfileString("Export", "Headers", "True", Rs, Len(Rs), winDir & UCase$(App.EXEName) & ".INI")
    If X > 0 Then chkHeaders.Value = Left$(Rs, X)     ' Trim Buffer 'a string was returned.
    'Get & Set the Append option.
    X = GetPrivateProfileString("Export", "Append", "False", Rs, Len(Rs), winDir & UCase$(App.EXEName) & ".INI")
    If X > 0 Then chkAppend.Value = Left$(Rs, X)     ' Trim Buffer 'a string was returned.
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Export", "SaveSettings", "CHECKED", Rs, Len(Rs), winDir & UCase$(App.EXEName) & ".INI")
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
        X = WritePrivateProfileString("Export", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Export", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Export", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub

'GENERAL ...
    'Write the File Name setting to the .INI file.
    X = WritePrivateProfileString("Export", "FileName", Format$(txtFileName.Text), iniFile)
    'Write the Format setting to the .INI file.
    X = WritePrivateProfileString("Export", "Format", Format$(txtComboFormat.Text), iniFile)

'OPTIONS ...
    'Write the Include Caption setting to the .INI file.
    X = WritePrivateProfileString("Export", "Caption", Format$(chkCaption.Value), iniFile)
    'Write the Include Headers setting to the .INI file.
    X = WritePrivateProfileString("Export", "Headers", Format$(chkHeaders.Value), iniFile)
    'Write the Append setting to the .INI file.
    X = WritePrivateProfileString("Export", "Append", Format$(chkAppend.Value), iniFile)

End Sub

Private Sub txtFileName_Change()

    'Convert any double backslashes with single.
    'For unknown reason, doubles get into string intermittently.
    Temp = Replace_All_In_With("\\", txtFileName.Text, "\")
    CMDialog1.filename = txtFileName.Text

End Sub
