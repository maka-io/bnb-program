VERSION 5.00
Begin VB.Form frmAbout 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "BnB"
   ClientHeight    =   3000
   ClientLeft      =   3675
   ClientTop       =   2580
   ClientWidth     =   4545
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3000
   ScaleWidth      =   4545
   Begin VB.Frame fraVersion 
      Caption         =   "Version"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   945
      Left            =   60
      TabIndex        =   5
      Top             =   1290
      Width           =   4455
      Begin VB.Label lblDBVersion 
         Caption         =   "Database Version:"
         Height          =   285
         Left            =   90
         TabIndex        =   7
         Top             =   600
         Width           =   2505
      End
      Begin VB.Label lblClientVersion 
         Caption         =   "Client Version:"
         Height          =   285
         Left            =   90
         TabIndex        =   6
         Top             =   300
         Width           =   2865
      End
   End
   Begin VB.Frame fraContact 
      Caption         =   "Contact"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1005
      Left            =   60
      TabIndex        =   2
      Top             =   150
      Width           =   4455
      Begin VB.Label lblEmail 
         Caption         =   "support@bnbsoft.com"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   90
         TabIndex        =   4
         Top             =   570
         Width           =   3585
      End
      Begin VB.Label lblLabel1 
         Caption         =   "Contact BnB Systems via e-mail at:"
         Height          =   255
         Left            =   90
         TabIndex        =   3
         Top             =   300
         Width           =   3945
      End
   End
   Begin VB.PictureBox Picture1 
      AutoSize        =   -1  'True
      BorderStyle     =   0  'None
      Height          =   480
      Left            =   4020
      Picture         =   "About.frx":0000
      ScaleHeight     =   480
      ScaleWidth      =   480
      TabIndex        =   0
      Top             =   2490
      Width           =   480
   End
   Begin VB.Label lblCopyright 
      Caption         =   "Copyright:"
      Height          =   255
      Left            =   60
      TabIndex        =   1
      Top             =   2700
      Width           =   3855
   End
End
Attribute VB_Name = "frmAbout"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Click()
   Unload Me
End Sub

Private Sub Form_Load()

   On Error GoTo Form_Load_Error
   NL$ = Chr$(13) & Chr$(10)   'New Line of text.
   Dim SSTemp As Recordset
   Dim vDBVersion As String
   Set SSTemp = gBNB.OpenRecordset("select * from DBVersion", dbOpenSnapshot)
   GetSSRows SSTemp
   If SSTemp.EOF And SSTemp.BOF Then
      vDBVersion = ""
   Else
      vDBVersion = SSTemp(0)
   End If
   SSTemp.Close
   lblClientVersion.Caption = "Client Version: " & gVersion
   If DEMO Then lblClientVersion.Caption = lblClientVersion.Caption & "  *** DEMO ***"
   lblDBVersion.Caption = "Database Version: " & vDBVersion
   lblCopyright.Caption = "Copyright (C) 1999 - BnB Systems"
'   gMsg = "Client Version: " & gVersion & NL & "Database Version: " & vDBVersion
'   MsgBox gMsg, MB_ICONINFORMATION, Me.Caption

Form_Load_Resume:
    Exit Sub
    
Form_Load_Error:
    MsgBox Err.Description
    Resume Form_Load_Resume
    
End Sub


Private Sub Picture1_Click()
   Unload Me
End Sub


