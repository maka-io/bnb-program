VERSION 5.00
Begin VB.Form frmCompanyInfo 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Company Information"
   ClientHeight    =   4530
   ClientLeft      =   930
   ClientTop       =   1260
   ClientWidth     =   5685
   HelpContextID   =   103
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   ScaleHeight     =   4530
   ScaleWidth      =   5685
   Tag             =   "UserCompanyInfo"
   Begin VB.Frame fraFedTaxId 
      Caption         =   "Federal Tax ID Number"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   120
      TabIndex        =   24
      Top             =   3750
      Width           =   4035
      Begin VB.TextBox txtFedTaxId 
         Appearance      =   0  'Flat
         DataField       =   "FedTaxId"
         DataSource      =   "datBrowse"
         Height          =   315
         Left            =   120
         TabIndex        =   9
         Tag             =   "Text"
         Top             =   270
         Width           =   3795
      End
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
      Height          =   765
      Left            =   4260
      TabIndex        =   23
      Top             =   3720
      Width           =   1395
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
      Height          =   735
      Left            =   4260
      TabIndex        =   13
      Top             =   2820
      Width           =   1395
   End
   Begin VB.CommandButton cmdCommit 
      Caption         =   "Co&mmit"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   4260
      TabIndex        =   12
      Top             =   1920
      Width           =   1395
   End
   Begin VB.CommandButton cmdUpdate 
      Caption         =   "&Update"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   4260
      TabIndex        =   11
      Top             =   1020
      Width           =   1395
   End
   Begin VB.CommandButton cmdInsert 
      Caption         =   "&Insert"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   4260
      TabIndex        =   10
      Top             =   120
      Width           =   1395
   End
   Begin VB.Data datBrowse 
      Appearance      =   0  'Flat
      Caption         =   "datBrowse"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   360
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   4620
      Visible         =   0   'False
      Width           =   2475
   End
   Begin VB.TextBox txtEmail 
      Appearance      =   0  'Flat
      DataField       =   "Email"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1020
      TabIndex        =   8
      Tag             =   "Text"
      Top             =   3240
      Width           =   3135
   End
   Begin VB.TextBox txtFax 
      Appearance      =   0  'Flat
      DataField       =   "Fax"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1020
      TabIndex        =   7
      Tag             =   "Text"
      Top             =   2850
      Width           =   3135
   End
   Begin VB.TextBox txtPhone2 
      Appearance      =   0  'Flat
      DataField       =   "Phone2"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1020
      TabIndex        =   6
      Tag             =   "Text"
      Top             =   2460
      Width           =   3135
   End
   Begin VB.TextBox txtPhone1 
      Appearance      =   0  'Flat
      DataField       =   "Phone1"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1020
      TabIndex        =   5
      Tag             =   "Text"
      Top             =   2070
      Width           =   3135
   End
   Begin VB.TextBox txtZipcode 
      Appearance      =   0  'Flat
      DataField       =   "Zipcode"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1020
      TabIndex        =   4
      Tag             =   "Text"
      Top             =   1680
      Width           =   3135
   End
   Begin VB.TextBox txtState 
      Appearance      =   0  'Flat
      DataField       =   "State"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1020
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   1290
      Width           =   3135
   End
   Begin VB.TextBox txtCity 
      Appearance      =   0  'Flat
      DataField       =   "City"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1020
      TabIndex        =   2
      Tag             =   "Text"
      Top             =   900
      Width           =   3135
   End
   Begin VB.TextBox txtAddress 
      Appearance      =   0  'Flat
      DataField       =   "Address"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1020
      TabIndex        =   1
      Tag             =   "Text"
      Top             =   510
      Width           =   3135
   End
   Begin VB.TextBox txtCompanyName 
      Appearance      =   0  'Flat
      DataField       =   "CompanyName"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1020
      TabIndex        =   0
      Tag             =   "Text"
      Top             =   120
      Width           =   3135
   End
   Begin VB.Label lblEmail 
      Caption         =   "E-Mail:"
      Height          =   195
      Left            =   120
      TabIndex        =   22
      Top             =   3300
      Width           =   735
   End
   Begin VB.Label lblFax 
      Caption         =   "Fax:"
      Height          =   195
      Left            =   120
      TabIndex        =   21
      Top             =   2910
      Width           =   735
   End
   Begin VB.Label lblPhone2 
      Caption         =   "Phone2:"
      Height          =   195
      Left            =   120
      TabIndex        =   20
      Top             =   2520
      Width           =   915
   End
   Begin VB.Label lblPhone1 
      Caption         =   "Phone1:"
      Height          =   195
      Left            =   120
      TabIndex        =   19
      Top             =   2130
      Width           =   735
   End
   Begin VB.Label lblZipcode 
      Caption         =   "Zipcode:"
      Height          =   195
      Left            =   120
      TabIndex        =   18
      Top             =   1740
      Width           =   735
   End
   Begin VB.Label lblState 
      Caption         =   "State:"
      Height          =   195
      Left            =   120
      TabIndex        =   17
      Top             =   1350
      Width           =   735
   End
   Begin VB.Label lblCity 
      Caption         =   "City:"
      Height          =   195
      Left            =   120
      TabIndex        =   16
      Top             =   960
      Width           =   735
   End
   Begin VB.Label lblAddress 
      Caption         =   "Address:"
      Height          =   195
      Left            =   120
      TabIndex        =   15
      Top             =   570
      Width           =   735
   End
   Begin VB.Label lblCompanyName 
      Caption         =   "Name:"
      Height          =   195
      Left            =   120
      TabIndex        =   14
      Top             =   180
      Width           =   735
   End
End
Attribute VB_Name = "frmCompanyInfo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
Dim SetFocusTo As String



Private Sub cmdCancel_Click()
   
   On Error GoTo cmdCancel_Click_Error
   
   Select Case GetFormMode(Me)
     Case "Insert"
        If datBrowse.Recordset.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
     Case "Update"
        If datBrowse.Recordset.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
     Case Else
        '
   End Select
   datBrowse.UpdateControls
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
     SetFormToNoRowsMode Me
     cmdInsert.Enabled = True
     cmdInsert.SetFocus
   Else
     SetFormToBrowseMode Me
     cmdInsert.Enabled = False
     txtCompanyName.SetFocus
   End If
   
cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume

End Sub

Private Sub cmdCommit_Click()

    On Error GoTo cmdCommit_Click_Error

    Screen.MousePointer = HOURGLASS

    If Not VerifyUpdate() Then
       MsgBox gMsg, MB_ICONSTOP, Me.Caption
       GoTo cmdCommit_Click_Resume
    End If
    If Not InsertTrigger() Then
       MsgBox gMsg, MB_ICONSTOP, Me.Caption
       GoTo cmdCommit_Click_Resume
    End If
    
    Select Case GetFormMode(Me)
      Case "Insert"
        '***Check for valid row entry here (i_trig)***
        '**********************************
        'Check if any Date, Currency or Number fields were set to blank (0 length string);
        'if so, unbind control's DataField property and commit Null.
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
      Case "Update"
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        'Make the current record current again
        datBrowse.UpdateControls
        If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
      Case Else
         '
    End Select
    
    If datBrowse.Recordset.RecordCount = 0 Then
      SetFormToNoRowsMode Me
      cmdInsert.Enabled = True
    Else
      SetFormToBrowseMode Me
      cmdInsert.Enabled = False
      'CurrRec = GetCurrentRowNumber(datBrowse)
      'datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
    End If
   
cmdCommit_Click_Resume:
    'Return mousepointer to its original state.
    Screen.MousePointer = DEFAULT
    Exit Sub

cmdCommit_Click_Error:
    MsgBox Err.Description
    GoTo cmdCommit_Click_Resume

End Sub

Private Sub cmdExit_Click()
   Unload Me
End Sub

Private Sub cmdInsert_Click()

   On Error GoTo cmdInsert_Click_Error
 
   SetFormToInsertMode Me
   datBrowse.Recordset.AddNew
   SetZeroLengthString Me
   
cmdInsert_Click_Resume:
   Exit Sub
   
cmdInsert_Click_Error:
   MsgBox Err.Description
   Resume cmdInsert_Click_Resume
   
End Sub

Private Sub cmdUpdate_Click()

   On Error GoTo cmdUpdate_Click_Error
   
   SetFormToUpdateMode Me
   datBrowse.Recordset.Edit

cmdUpdate_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdUpdate_Click_Error:
    If datBrowse.Recordset.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
    MsgBox Err.Description
    SetFormToBrowseMode Me
    cmdInsert.Enabled = False
    Resume cmdUpdate_Click_Resume
End Sub


Private Sub Form_Activate()
   
On Error GoTo Form_Activate_Error
   
'If this form is in the background (does not have focus) and the
'Minimize button is clicked on this form that does not yet have the focus,
'an endless loop of Minimizing and Activating will occur. The following
'line prevents this interesting problem.
If Me.WindowState = MINIMIZED Then Exit Sub

If TimesActivated < 1 Then
   TimesActivated = TimesActivated + 1
   If Not GetDCRows(datBrowse) Then GoTo Form_Activate_Resume
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
      cmdInsert.Enabled = True
   Else
      SetFormToBrowseMode Me
      cmdInsert.Enabled = False
   End If
End If

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
Form_Activate_Error:
   Resume Form_Activate_Resume
   
End Sub

Private Sub Form_Load()
    Screen.MousePointer = HOURGLASS
    TimesActivated = 0
    datBrowse.DatabaseName = gDatabaseName
    datBrowse.RecordSource = "select * from " & Me.Tag
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

Public Function InsertTrigger() As Integer

    On Error GoTo InsertTrigger_Error
    
    InsertTrigger = False
    'Put any checks here. None for now...
    InsertTrigger = True
   
InsertTrigger_Resume:
   Exit Function
   
InsertTrigger_Error:
   Resume InsertTrigger_Resume

End Function
