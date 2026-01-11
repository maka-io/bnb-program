VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmDBPath 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Set Database Location"
   ClientHeight    =   2835
   ClientLeft      =   915
   ClientTop       =   1530
   ClientWidth     =   6930
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2835
   ScaleWidth      =   6930
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton cmdBrowse 
      Caption         =   "&Browse..."
      Height          =   495
      Left            =   5700
      TabIndex        =   7
      Top             =   840
      Width           =   1155
   End
   Begin VB.TextBox txtDBPath 
      Appearance      =   0  'Flat
      Height          =   315
      Left            =   1440
      TabIndex        =   5
      Top             =   2460
      Width           =   4155
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "E&xit"
      Height          =   495
      Left            =   5700
      TabIndex        =   4
      Top             =   1440
      Width           =   1155
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      Height          =   495
      Left            =   5700
      TabIndex        =   3
      Top             =   240
      Width           =   1155
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   120
      Top             =   2760
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Frame Frame1 
      Height          =   2265
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   5475
      Begin VB.OptionButton optWorkStation 
         Caption         =   "Install as Workstation (another machine on network has already been setup as a Database Server using this setup program.)"
         Height          =   615
         Left            =   140
         TabIndex        =   2
         Top             =   240
         Width           =   5175
      End
      Begin VB.OptionButton optServer 
         Caption         =   $"DBpath.frx":0000
         Height          =   1110
         Left            =   120
         TabIndex        =   1
         Top             =   1020
         Width           =   5200
      End
   End
   Begin VB.Label lblDBPath 
      Caption         =   "Database path:"
      Height          =   255
      Left            =   120
      TabIndex        =   6
      Top             =   2520
      Width           =   1215
   End
End
Attribute VB_Name = "frmDBPath"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdBrowse_Click()
    
    On Error GoTo cmdBrowse_Click_Error
    
    If optWorkStation.Value Then
     'Set Common Dialog Font Properites
     CMDialog1.CancelError = True
     CMDialog1.DefaultExt = "mdb"
     CMDialog1.Filter = "Microsoft Access (*.mdb)|*.mdb"
     CMDialog1.FilterIndex = 1
     CMDialog1.filename = "BNB1.MDB"
     CMDialog1.DialogTitle = "Database Location"
     CMDialog1.InitDir = gstrDestDir
     'Set Common Dialog flags such that:
     '  a) The read only check box is hidden, and
     '  b) That the returned file name will not be a read only file, and that its directory will not be write protected, and
     '  c) That the path must exist.
     CMDialog1.Flags = &H4& Or &H8000& Or &H800& Or &H400&
     
     CMDialog1.ShowOpen
     
     txtDBPath.Text = CMDialog1.filename
   
   End If
   
cmdBrowse_Click_Resume:
   Screen.MousePointer = Default
   Exit Sub

cmdBrowse_Click_Error:
   If Err = cdlCancel Then Resume cmdBrowse_Click_Resume
   
End Sub

Private Sub cmdExit_Click()
   ExitSetup Me, gintRET_EXIT
End Sub

Private Sub cmdOK_Click()
  
    On Error GoTo cmdOK_Click_Error
    
    If optWorkStation.Value Then
       If Trim(txtDBPath.Text) = "" Then
         MsgBox "Database path cannot be blank. Click 'Browse...' to set network path to the BnB database file (bnb1.mdb).", MB_ICONSTOP, Me.Caption
         GoTo cmdOK_Click_Resume
       Else
         IsWorkstation = True
         gDatabasePath = Trim(txtDBPath.Text)
         If Not FileExists(gDatabasePath) Then
            MsgBox "Database file does not exist at specified location.", MB_ICONSTOP, Me.Caption
            GoTo cmdOK_Click_Resume
         End If
       End If
    End If
    
    Unload Me
   
cmdOK_Click_Resume:
   Screen.MousePointer = Default
   Exit Sub

cmdOK_Click_Error:
   If Err = cdlCancel Then Resume cmdOK_Click_Resume
     

End Sub

Private Sub Form_Load()

  optWorkStation.Value = True
  
End Sub

Private Sub optServer_Click()

   txtDBPath.Text = ""
   txtDBPath.Enabled = False
   lblDBPath.Enabled = False
   
   cmdBrowse.Enabled = False 'paultest
   

End Sub

Private Sub optWorkStation_Click()
   
   txtDBPath.Enabled = True
   lblDBPath.Enabled = True
   
   cmdBrowse.Enabled = True 'paultest
      
End Sub

