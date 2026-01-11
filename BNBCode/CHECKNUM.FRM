VERSION 5.00
Begin VB.Form frmCheckNumbers 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Check Category Information"
   ClientHeight    =   2835
   ClientLeft      =   855
   ClientTop       =   1965
   ClientWidth     =   8460
   HelpContextID   =   104
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2835
   ScaleWidth      =   8460
   Tag             =   "CheckNum"
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
      Height          =   435
      Left            =   7380
      TabIndex        =   9
      Top             =   210
      Width           =   1035
   End
   Begin VB.Data datBrowse 
      Appearance      =   0  'Flat
      Caption         =   "datBrowse"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   300
      Left            =   120
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   2880
      Visible         =   0   'False
      Width           =   2475
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
      Height          =   435
      Left            =   7380
      TabIndex        =   13
      Top             =   2370
      Width           =   1035
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
      Height          =   435
      Left            =   7380
      TabIndex        =   12
      Top             =   1830
      Width           =   1035
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
      Height          =   435
      Left            =   7380
      TabIndex        =   11
      Top             =   1290
      Width           =   1035
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
      Height          =   435
      Left            =   7380
      TabIndex        =   10
      Top             =   750
      Width           =   1035
   End
   Begin VB.Frame fraSharedCheck 
      Caption         =   "Shared Checks"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2685
      Left            =   3540
      TabIndex        =   19
      Top             =   120
      Width           =   3735
      Begin VB.OptionButton optAll 
         Caption         =   "All (All categories share same sequence)"
         Height          =   195
         Left            =   180
         TabIndex        =   8
         Top             =   2100
         Width           =   3435
      End
      Begin VB.OptionButton optHostTravel 
         Caption         =   "Host and Travel"
         Height          =   195
         Left            =   180
         TabIndex        =   7
         Top             =   1680
         Width           =   2895
      End
      Begin VB.OptionButton optHostMisc 
         Caption         =   "Host and Miscellaneous"
         Height          =   195
         Left            =   180
         TabIndex        =   6
         Top             =   1260
         Width           =   2895
      End
      Begin VB.OptionButton optTravelMisc 
         Caption         =   "Travel and Miscellaneous"
         Height          =   195
         Left            =   180
         TabIndex        =   5
         Top             =   840
         Width           =   2835
      End
      Begin VB.OptionButton optNone 
         Caption         =   "None (All on separate check sequences) "
         Height          =   195
         Left            =   180
         TabIndex        =   4
         Top             =   420
         Width           =   3435
      End
   End
   Begin VB.Frame fraNextCheck 
      Caption         =   "Next Check Number to be Printed"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2685
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   3375
      Begin VB.TextBox txtNextMisc 
         Appearance      =   0  'Flat
         DataField       =   "MiscCheckNum"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1500
         TabIndex        =   3
         Tag             =   "Number"
         Top             =   1620
         Width           =   1215
      End
      Begin VB.TextBox txtNextTravel 
         Appearance      =   0  'Flat
         DataField       =   "TravelCheckNum"
         DataSource      =   "datBrowse"
         Height          =   315
         Left            =   1500
         TabIndex        =   2
         Tag             =   "Number"
         Top             =   1140
         Width           =   1215
      End
      Begin VB.TextBox txtNextHost 
         Appearance      =   0  'Flat
         DataField       =   "HostCheckNum"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1500
         TabIndex        =   1
         Tag             =   "Number"
         Top             =   660
         Width           =   1215
      End
      Begin VB.Label lblCatMisc 
         Caption         =   "Miscellaneous"
         Height          =   195
         Left            =   120
         TabIndex        =   18
         Top             =   1680
         Width           =   1035
      End
      Begin VB.Label lblCatTravel 
         Caption         =   "Travel"
         Height          =   255
         Left            =   120
         TabIndex        =   17
         Top             =   1200
         Width           =   1035
      End
      Begin VB.Label lblCatHost 
         Caption         =   "Host"
         Height          =   255
         Left            =   120
         TabIndex        =   16
         Top             =   720
         Width           =   1035
      End
      Begin VB.Label lblNextCheck 
         Caption         =   "Check Number"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   -1  'True
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   1500
         TabIndex        =   15
         Top             =   360
         Width           =   1455
      End
      Begin VB.Label lblCategory 
         Caption         =   "Category"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   -1  'True
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   120
         TabIndex        =   14
         Top             =   360
         Width           =   1095
      End
   End
   Begin VB.Label lblShareCode 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      Caption         =   "lblShareCode"
      DataField       =   "SharedAccounts"
      DataSource      =   "datBrowse"
      ForeColor       =   &H80000008&
      Height          =   255
      Left            =   2760
      TabIndex        =   20
      Top             =   2880
      Visible         =   0   'False
      Width           =   1455
   End
End
Attribute VB_Name = "frmCheckNumbers"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
Dim vOptControl As Control
Dim SetFocusTo As String


Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error
   
   Select Case GetFormMode(Me)
     Case "Insert"
        If datBrowse.Recordset.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
     Case "Update"
        If datBrowse.Recordset.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
        vOptControl.Value = True
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
     txtNextHost.SetFocus
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
    'Get code (from option buttons) for Account Sharing
    If optNone.Value = CHECKED Then
       lblShareCode.Caption = "0"
    ElseIf optTravelMisc.Value = CHECKED Then
       lblShareCode.Caption = "1"
    ElseIf optHostMisc.Value = CHECKED Then
       lblShareCode.Caption = "2"
    ElseIf optHostTravel.Value = CHECKED Then
       lblShareCode.Caption = "3"
    ElseIf optAll.Value = CHECKED Then
       lblShareCode.Caption = "4"
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
        'Check if any Date, Currency or Number fields were set to blank (0 length string);
        'if so, unbind control's DataField property and commit Null.
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        'Make the current record current again
        datBrowse.UpdateControls
        'If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
      Case "Delete"
        gMsg = "Delete the current row?"
        If MsgBox(gMsg, MB_ICONQUESTION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDYES Then
            datBrowse.Recordset.Delete
            'datBrowse.Refresh
            'Position to the next remaining row in the recordset.
            If datBrowse.Recordset.RecordCount > 1 Then
                datBrowse.Recordset.MoveNext
                'If there is no next row to position to, move to the last remaining row (if any).
                If datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then datBrowse.Recordset.MoveLast
            ElseIf datBrowse.Recordset.RecordCount = 1 Then
                datBrowse.Recordset.MoveLast
            Else
               'All rows have been removed. If AddNew is invoked (Insert is clicked)
               'at this point, error will occur if data control is not Refreshed.
               datBrowse.Refresh
               'no movement
            End If
        End If
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
    Resume cmdCommit_Click_Resume

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
   
   Dim i As Integer
   For i = 0 To Me.Controls.Count - 1
     If Me.Controls(i).Name Like "opt*" Then
        If Me.Controls(i).Value Then
           Set vOptControl = Me.Controls(i)
           Exit For
        End If
     End If
   Next i
   
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
      'Get and set the value for the Sharing option
      If datBrowse.Recordset("SharedAccounts") = 0 Then
         optNone.Value = CHECKED
      ElseIf datBrowse.Recordset("SharedAccounts") = 1 Then
         optTravelMisc.Value = CHECKED
      ElseIf datBrowse.Recordset("SharedAccounts") = 2 Then
         optHostMisc.Value = CHECKED
      ElseIf datBrowse.Recordset("SharedAccounts") = 3 Then
         optHostTravel.Value = CHECKED
      ElseIf datBrowse.Recordset("SharedAccounts") = 4 Then
         optAll.Value = CHECKED
      End If
   End If
End If

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

Form_Activate_Error:
   Resume Form_Activate_Resume

End Sub

Private Sub Form_Load()

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
    
    If optNone.Value = UNCHECKED And optTravelMisc.Value = UNCHECKED _
       And optHostMisc.Value = UNCHECKED And optHostTravel.Value = UNCHECKED _
       And optAll.Value = UNCHECKED Then
       gMsg = "A Shared Account option must be chosen."
       GoTo InsertTrigger_Resume
    End If
    'If a Sharing option other than 'None' is chosen, make sure
    'the corresponding check numbers for that option are the same.
    If optTravelMisc.Value = CHECKED Then
       If Trim(txtNextTravel.Text) = "" Or Trim(txtNextMisc.Text) = "" Then
          gMsg = "Check numbers for Travel and Miscellaneous categories cannot be blank for selected Sharing option."
          GoTo InsertTrigger_Resume
       ElseIf txtNextTravel.Text <> txtNextMisc.Text Then
          gMsg = "Check numbers for Travel and Miscellaneous categories must be the same for selected Sharing option."
          GoTo InsertTrigger_Resume
       End If
    ElseIf optHostMisc.Value = CHECKED Then
       If Trim(txtNextHost.Text) = "" Or Trim(txtNextMisc.Text) = "" Then
          gMsg = "Check numbers for Host and Miscellaneous categories cannot be blank for selected Sharing option."
          GoTo InsertTrigger_Resume
       ElseIf txtNextHost.Text <> txtNextMisc.Text Then
          gMsg = "Check numbers for Host and Miscellaneous categories must be the same for selected Sharing option."
          GoTo InsertTrigger_Resume
       End If
    ElseIf optHostTravel.Value = CHECKED Then
       If Trim(txtNextHost.Text) = "" Or Trim(txtNextTravel.Text) = "" Then
          gMsg = "Check numbers for Host and Travel categories cannot be blank for selected Sharing option."
          GoTo InsertTrigger_Resume
       ElseIf txtNextHost.Text <> txtNextTravel.Text Then
          gMsg = "Check numbers for Host and Travel categories must be the same for selected Sharing option."
          GoTo InsertTrigger_Resume
       End If
    ElseIf optAll.Value = CHECKED Then
       If Trim(txtNextHost.Text) = "" Or Trim(txtNextTravel.Text) = "" Or Trim(txtNextMisc.Text) = "" Then
          gMsg = "Check numbers for Host, Travel, and Miscellaneous categories cannot be blank for selected Sharing option."
          GoTo InsertTrigger_Resume
       ElseIf (txtNextHost.Text <> txtNextTravel.Text) Or _
          (txtNextHost.Text <> txtNextMisc.Text) Or _
          (txtNextTravel.Text <> txtNextMisc.Text) Then
          gMsg = "Check numbers for Host, Travel, and Miscellaneous categories must be the same for selected Sharing option."
          GoTo InsertTrigger_Resume
       End If
    End If
    
    InsertTrigger = True
  
InsertTrigger_Resume:
   Exit Function
   
InsertTrigger_Error:
   Resume InsertTrigger_Resume

End Function

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
