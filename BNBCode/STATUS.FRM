VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Begin VB.Form frmStatus 
   BorderStyle     =   1  'Fixed Single
   ClientHeight    =   1455
   ClientLeft      =   2865
   ClientTop       =   3960
   ClientWidth     =   5610
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   1455
   ScaleWidth      =   5610
   Begin Threed.SSPanel pnlMessage 
      Height          =   1485
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   5655
      _Version        =   65536
      _ExtentX        =   9975
      _ExtentY        =   2619
      _StockProps     =   15
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
End
Attribute VB_Name = "frmStatus"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()

    StatusMessage Me, gMsg, True
    
End Sub
Private Sub Form_Resize()
Me.Height = pnlMessage.Height
Me.Width = pnlMessage.Width
End Sub


