VERSION 5.00
Begin VB.Form frmRefund 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Refund Dialog Box"
   ClientHeight    =   2400
   ClientLeft      =   2712
   ClientTop       =   2556
   ClientWidth     =   3384
   HelpContextID   =   119
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2400
   ScaleWidth      =   3384
   Begin VB.CommandButton cmdExit 
      Caption         =   "E&xit"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   60
      TabIndex        =   6
      Top             =   1950
      Width           =   1455
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "&OK"
      Default         =   -1  'True
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   1860
      TabIndex        =   5
      Top             =   1950
      Width           =   1455
   End
   Begin VB.Frame fraDateRange 
      Caption         =   "Date Refunded"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1695
      Left            =   60
      TabIndex        =   0
      Top             =   120
      Width           =   3255
      Begin VB.TextBox txtEndDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2190
         TabIndex        =   3
         Tag             =   "Date"
         Top             =   450
         Width           =   915
      End
      Begin VB.TextBox txtStartDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   600
         TabIndex        =   1
         Tag             =   "Date"
         Top             =   450
         Width           =   915
      End
      Begin VB.Label lblStartDate 
         Caption         =   "Start:"
         Height          =   225
         Left            =   120
         TabIndex        =   4
         Top             =   510
         Width           =   495
      End
      Begin VB.Label lblEndDate 
         Caption         =   "through"
         Height          =   225
         Left            =   1560
         TabIndex        =   2
         Top             =   510
         Width           =   615
      End
   End
End
Attribute VB_Name = "frmRefund"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub cmdExit_Click()
   Unload Me
End Sub


Private Sub cmdOK_Click()
  
  On Error GoTo cmdOK_Click_Error
  'Validate date and number formats here
  If Not VerifyUpdate() Then
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo cmdOK_Click_Resume
  End If
  
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






Private Sub Form_Load()

   On Error GoTo Load_Error
   
Load_Resume:
   Exit Sub

Load_Error:
   Resume Load_Resume
   
End Sub


