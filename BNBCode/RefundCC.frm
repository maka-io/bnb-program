VERSION 5.00
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmRefundByCC 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Credit Card/Cash Refunds"
   ClientHeight    =   4056
   ClientLeft      =   3216
   ClientTop       =   2136
   ClientWidth     =   4884
   HelpContextID   =   135
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4056
   ScaleWidth      =   4884
   Tag             =   "RefundByCCTbl"
   Begin VB.CommandButton cmdFind 
      Caption         =   "&Find"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   3540
      TabIndex        =   12
      Top             =   1830
      Width           =   1335
   End
   Begin VB.ComboBox txtComboPayMethod 
      Appearance      =   0  'Flat
      DataField       =   "PaymentMethod"
      DataSource      =   "datBrowse"
      Height          =   315
      ItemData        =   "RefundCC.frx":0000
      Left            =   1320
      List            =   "RefundCC.frx":0002
      TabIndex        =   7
      Tag             =   "Text"
      Top             =   2280
      Width           =   1935
   End
   Begin VB.Data datPayMethod 
      Appearance      =   0  'Flat
      Caption         =   "datPayMethod"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   2100
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   4140
      Visible         =   0   'False
      Width           =   2415
   End
   Begin VB.TextBox txtComments 
      Appearance      =   0  'Flat
      DataField       =   "Comments"
      DataSource      =   "datBrowse"
      Height          =   705
      Left            =   60
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   8
      Tag             =   "Text"
      Top             =   2910
      Width           =   3195
   End
   Begin VB.TextBox txtDatePaid 
      Appearance      =   0  'Flat
      DataField       =   "DatePaid"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1320
      TabIndex        =   6
      Tag             =   "Date"
      Top             =   1920
      Width           =   1935
   End
   Begin VB.TextBox txtAmtPaid 
      Appearance      =   0  'Flat
      DataField       =   "AmtPaid"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1320
      TabIndex        =   5
      Tag             =   "Currency"
      Top             =   1560
      Width           =   1935
   End
   Begin VB.TextBox txtAmtDue 
      Appearance      =   0  'Flat
      DataField       =   "AmtDue"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1320
      TabIndex        =   4
      Tag             =   "Currency"
      Top             =   1200
      Width           =   1935
   End
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
      Height          =   495
      Left            =   3540
      TabIndex        =   15
      Top             =   3540
      Width           =   1335
   End
   Begin VB.CommandButton cmdCommit 
      Caption         =   "Co&mmit"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   3540
      TabIndex        =   13
      Top             =   2400
      Width           =   1335
   End
   Begin VB.CommandButton cmdDelete 
      Caption         =   "&Delete"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   3540
      TabIndex        =   11
      Top             =   1260
      Width           =   1335
   End
   Begin VB.CommandButton cmdInsert 
      Caption         =   "&Insert"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   3540
      TabIndex        =   9
      Top             =   120
      Width           =   1335
   End
   Begin VB.CommandButton cmdCancel 
      Caption         =   "&Cancel"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   3540
      TabIndex        =   14
      Top             =   2970
      Width           =   1335
   End
   Begin VB.CommandButton cmdUpdate 
      Caption         =   "&Update"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   3540
      TabIndex        =   10
      Top             =   690
      Width           =   1335
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
      Left            =   60
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   4140
      Visible         =   0   'False
      Width           =   1875
   End
   Begin VB.TextBox txtLastName 
      Appearance      =   0  'Flat
      DataField       =   "l_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1320
      MaxLength       =   50
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   840
      Width           =   1935
   End
   Begin VB.TextBox txtFirstName 
      Appearance      =   0  'Flat
      DataField       =   "f_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1320
      MaxLength       =   50
      TabIndex        =   2
      Tag             =   "Text"
      Top             =   480
      Width           =   1935
   End
   Begin VB.TextBox txtConfNum 
      Appearance      =   0  'Flat
      DataField       =   "conf"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1320
      MaxLength       =   9
      TabIndex        =   1
      Tag             =   "Number"
      Top             =   120
      Width           =   1035
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "RefundCC.frx":0004
      Height          =   330
      Left            =   60
      TabIndex        =   0
      Tag             =   "tagentbl"
      Top             =   3720
      Width           =   3195
      _Version        =   131075
      _ExtentX        =   5630
      _ExtentY        =   572
      _StockProps     =   79
      ShowAddButton   =   0   'False
      ShowCancelButton=   0   'False
      ShowDelButton   =   0   'False
      ShowUpdateButton=   0   'False
      BevelOuter      =   0
      PageValue       =   5
      ShowBookmarkButtons=   0
      ShowFindButtons =   0
   End
   Begin VB.Label lblDailyRate 
      Caption         =   "Date Paid"
      Height          =   255
      Left            =   60
      TabIndex        =   23
      Top             =   1980
      Width           =   1155
   End
   Begin VB.Label lblWeeklyRate 
      Caption         =   "Refund Method:"
      Height          =   255
      Left            =   60
      TabIndex        =   22
      Top             =   2340
      Width           =   1215
   End
   Begin VB.Label lblCarModel 
      Caption         =   "Amount Paid"
      Height          =   255
      Left            =   60
      TabIndex        =   21
      Top             =   1620
      Width           =   1215
   End
   Begin VB.Label lblComment 
      Caption         =   "Comments:"
      Height          =   255
      Left            =   60
      TabIndex        =   20
      Top             =   2700
      Width           =   1155
   End
   Begin VB.Label lblLastName 
      Caption         =   "Last Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   19
      Top             =   900
      Width           =   1095
   End
   Begin VB.Label lblFirstName 
      Caption         =   "First Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   18
      Top             =   540
      Width           =   1095
   End
   Begin VB.Label lblConfNum 
      Caption         =   "Conf Number:"
      Height          =   255
      Left            =   60
      TabIndex        =   17
      Top             =   180
      Width           =   1095
   End
   Begin VB.Label lblAgentName 
      Caption         =   "Amount Due:"
      Height          =   255
      Left            =   60
      TabIndex        =   16
      Top             =   1260
      Width           =   1095
   End
End
Attribute VB_Name = "frmRefundByCC"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim i As Integer
Dim TimesActivated As Integer
Dim CurrRec1 As Long
Dim SaveRec1 As Long
Dim NullDateArray()
Dim FailedLostFocus As Integer
Dim SetFocusTo As String


Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error
   
   Select Case GetFormMode(Me)
     Case "Insert"
        If datBrowse.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
        'MsgBox Str$(gConfNum)
     Case "Update"
        If datBrowse.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
     Case "Find"
        cmdFind.Caption = "&Find"
     Case Else
        'do nothing
   End Select
   datBrowse.UpdateControls
   If datBrowse.Recordset.RecordCount = 0 Then
     SetFormToNoRowsMode Me
     cmdInsert.SetFocus
   Else
     SetFormToBrowseMode Me
     CurrRec1 = GetCurrentRowNumber(datBrowse)
     datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount
     txtConfNum.SetFocus
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
    
    Dim TempBook As Variant
    Dim RetVal As Integer
    Screen.MousePointer = HOURGLASS
    Select Case GetFormMode(Me)
      Case "Insert"
        'Check for valid dates and number formats
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmRefundByCC
        If Not InsertTrigger() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           'Find the control to return focus to.
           If Trim(SetFocusTo) <> "" Then
             For i = 0 To Me.Controls.Count - 1
               If Me.Controls(i).Name = SetFocusTo Then
                  Me.Controls(i).SetFocus
                  Exit For
               End If
              Next i
           End If
           GoTo cmdCommit_Click_Resume
        End If
        'If number formats are OK, then set currency formats
        SetToCurrencyFormat Me
        'If new record is being added
        If datBrowse.EditMode = dbEditAdd Then
           'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
           'unbind control's DataField property and commit Null.
           RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
           datBrowse.Recordset.Update
           datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & frmPayment.txtConfNum.Text
           If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
           'Do if there was at least one Date or Number set to null
           If RetVal Then BindNullDateControl Me, NullDateArray
           If Not datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then datBrowse.Recordset.MoveLast
        End If
        SetToCurrencyFormat Me
      Case "Update"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmRefundByCC
        If Not InsertTrigger() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           'Find the control to return focus to.
           If Trim(SetFocusTo) <> "" Then
             For i = 0 To Me.Controls.Count - 1
               If Me.Controls(i).Name = SetFocusTo Then
                  Me.Controls(i).SetFocus
                  Exit For
               End If
              Next i
           End If
           GoTo cmdCommit_Click_Resume
        End If
        'If number formats are OK, then set currency formats
        SetToCurrencyFormat Me
        If datBrowse.EditMode = dbEditInProgress Then
           'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
           'unbind control's DataField property and commit Null.
           RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
           datBrowse.Recordset.Update
           'getting No Current Record here. Put next (1) line in to correct.
           datBrowse.Recordset.Bookmark = datBrowse.Recordset.LastModified
           'Do if there was at least one Date or Number was set to null
           If RetVal Then BindNullDateControl Me, NullDateArray
           'Make the current record current again.
           datBrowse.UpdateControls
        End If
        SetToCurrencyFormat Me
      Case "Delete"
           gMsg = "Delete this guest's refund information?"
           If MsgBox(gMsg, MB_ICONQUESTION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDYES Then
               datBrowse.Recordset.Delete
               'datBrowse.Refresh
               'Position to the next remaining row in the recordset.
               If datBrowse.Recordset.RecordCount > 1 Then
                   datBrowse.Recordset.MoveNext
                   'If there is no next row to position to, move to the last remaining row (if any).
                   If datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then
                      datBrowse.Recordset.MoveLast
                   ElseIf Not datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
                      datBrowse.Recordset.MoveFirst
                   End If
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
         'do nothing
    End Select
    
    If datBrowse.Recordset.RecordCount = 0 Then
      SetFormToNoRowsMode Me
    Else
      SetFormToBrowseMode Me
      CurrRec1 = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount
    End If
   
cmdCommit_Click_Resume:
    'Return mousepointer to its original state.
    Screen.MousePointer = DEFAULT
    Exit Sub

cmdCommit_Click_Error:
    MsgBox Err.Description
    Resume cmdCommit_Click_Resume
 
End Sub

Private Sub cmdDelete_Click()
  SetFormToDeleteMode Me
End Sub

Private Sub cmdExit_Click()
   Unload Me
End Sub





Private Sub cmdFind_Click()
   
   On Error GoTo cmdFind_Click_Error
   Screen.MousePointer = HOURGLASS
   Dim Criteria As String
   If cmdFind.Caption = "&Find" Then
      SetFormToFindMode Me
      cmdFind.Caption = "&Run Query"
      cmdFind.DEFAULT = True
   Else
      cmdFind.Caption = "&Find"
      Criteria = BuildFindCriteria(Me, "Conf")
      If Criteria <> "" Then
         datBrowse.UpdateControls
         datBrowse.RecordSource = Criteria
         If Not GetDCRows(datBrowse) Then GoTo cmdFind_Click_Resume
         If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
            SetFormToNoRowsMode Me
         Else
            SetFormToBrowseMode Me
            CurrRec = GetCurrentRowNumber(datBrowse)
            datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
         End If
      Else
         SetFormToNoRowsMode Me
      End If
   End If
   txtConfNum.SetFocus

cmdFind_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
    
cmdFind_Click_Error:
   'MsgBox Err.Description
   Resume cmdFind_Click_Resume
End Sub

Private Sub cmdInsert_Click()

    On Error GoTo cmdInsert_Click_Error
    
    If Trim(datBrowse.RecordSource) = "" Then
       datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & frmPayment.txtConfNum.Text
       If Not GetDCRows(datBrowse) Then Exit Sub
    End If
        
    SetFormToInsertMode Me
    datBrowse.Recordset.AddNew
    SetZeroLengthString Me
    
    'Get first and last name if gConfNum is set.
    If frmPayment.txtConfNum.Text <> "" Then
       Dim SSTemp As Recordset
       Set SSTemp = gBNB.OpenRecordset("select f_name,l_name from guesttbl where conf = " & frmPayment.txtConfNum.Text, dbOpenSnapshot)
       GetSSRows SSTemp
       If SSTemp.RecordCount > 0 Then
          txtConfNum.Text = frmPayment.txtConfNum.Text
          If Not IsNull(SSTemp("f_name")) Then txtFirstName.Text = SSTemp("f_name")
          If Not IsNull(SSTemp("l_name")) Then txtLastName.Text = SSTemp("l_name")
          txtAmtDue.SetFocus
       End If
       SSTemp.Close
    Else
       txtConfNum.SetFocus
    End If
    txtConfNum.ForeColor = BLACK
    txtFirstName.ForeColor = BLACK
    txtLastName.ForeColor = BLACK
    txtConfNum.Locked = True
    txtFirstName.Locked = True
    txtLastName.Locked = True
    
    'Default the date paid to today
    txtDatePaid.Text = Format(Now, "m/d/yyyy")
    
cmdInsert_Click_Resume:
   Exit Sub
   
cmdInsert_Click_Error:
   MsgBox Err.Description
   Resume cmdInsert_Click_Resume
   
End Sub

Private Sub cmdUpdate_Click()

   On Error GoTo cmdUpdate_Click_Error
   
   SetFormToUpdateMode Me
   txtAmtDue.SetFocus
   datBrowse.Recordset.Edit
   
cmdUpdate_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdUpdate_Click_Error:
    If datBrowse.Recordset.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
    MsgBox Err.Description
    SetFormToBrowseMode Me
    Resume cmdUpdate_Click_Resume

End Sub




Private Sub datBrowse_Reposition()
   'SetToCurrencyFormat Me
End Sub

Private Sub txtComboPayMethod_DropDown()

   On Error GoTo txtComboPayMethod_Error
   
   Dim vHoldText As String
   vHoldText = Trim(txtComboPayMethod.Text)

   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        txtComboPayMethod.Clear
        GoTo txtComboPayMethod_Resume
     Case Else
        txtComboPayMethod.Clear
        txtComboPayMethod.AddItem "Credit Card"
        txtComboPayMethod.AddItem "Cash"
        txtComboPayMethod.AddItem "Other"
   End Select
   
txtComboPayMethod_Resume:
   If Trim(txtComboPayMethod.Text) = "" Then txtComboPayMethod.Text = vHoldText
   Exit Sub

txtComboPayMethod_Error:
   Resume txtComboPayMethod_Resume
   
End Sub









Private Sub datdwData1_Click(ByVal nPosition As Integer)
    
    'On Error GoTo datdwData1_Click_Error
    Screen.MousePointer = HOURGLASS
    Me.SetFocus
   ' Dim EntryConfNum As String
   ' EntryConfNum = Trim$(txtConfNum.Text)
    'case1: first row button
    If nPosition = 3 Then
        CurrRec1 = 1
    'case2: previous page button
    ElseIf nPosition = 5 Then
        If CurrRec1 > datdwData1.PageValue Then
            CurrRec1 = CurrRec1 - datdwData1.PageValue
        Else
            CurrRec1 = 1
        End If
    'case3: previous row button
    ElseIf nPosition = 7 Then
        If CurrRec1 > 1 Then
            CurrRec1 = CurrRec1 - 1
        Else
            CurrRec1 = 1
        End If
    'case4: save bookmark button
    ElseIf nPosition = 16 Then
        SaveRec1 = CurrRec1
    'case5: goto saved bookmark
    ElseIf nPosition = 18 Then
        If SaveRec1 > 0 Then CurrRec1 = SaveRec1
    'case6: next row button
    ElseIf nPosition = 8 Then
        If CurrRec1 < Me.datBrowse.Recordset.RecordCount Then
            CurrRec1 = CurrRec1 + 1
        Else
            CurrRec1 = Me.datBrowse.Recordset.RecordCount
        End If
    'case7: next page button
    ElseIf nPosition = 6 Then
        If CurrRec1 < Me.datBrowse.Recordset.RecordCount - datdwData1.PageValue Then
            CurrRec1 = CurrRec1 + datdwData1.PageValue
        Else
            CurrRec1 = Me.datBrowse.Recordset.RecordCount
        End If
    'case8: last row button
    ElseIf nPosition = 4 Then
        CurrRec1 = Me.datBrowse.Recordset.RecordCount
    End If
    datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount

datdwData1_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

'datdwData1_Click_Error:
'    If IsError("datdwData1_Click") Then
'        Resume datdwData1_Click_Resume
'    Else
'        Resume Next
'    End If
'Exit Sub

End Sub



Private Sub Form_Activate()

On Error GoTo Form_Activate_Error

'If this form is in the background (does not have focus) and the
'Minimize button is clicked on this form that does not yet have the focus,
'an endless loop of Minimizing and Activating will occur. The following
'line prevents this interesting problem.

'If Me.WindowState = MINIMIZED Then Exit Sub
'If form is only regaining focus then exit
'If UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then Exit Sub
'For i = 1 To 5
'   DoEvents
'Next i
datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & frmPayment.txtConfNum.Text
If Not GetDCRows(datBrowse) Then GoTo Form_Activate_Resume
If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
   SetFormToNoRowsMode Me
Else
   SetFormToBrowseMode Me
   CurrRec1 = GetCurrentRowNumber(datBrowse)
   datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount
End If

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
  
Form_Activate_Error:
   Resume Form_Activate_Resume
   
End Sub

Private Sub Form_Load()
   
   On Error GoTo Load_Error
   
   datBrowse.DatabaseName = gDatabaseName
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & frmPayment.txtConfNum.Text
   datPayMethod.DatabaseName = gDatabaseName
   CurrRec1 = 1
   SaveRec1 = 0

Load_Resume:
   Exit Sub

Load_Error:
   Resume Load_Resume
   
End Sub


Private Sub txtComboPayMethod_KeyPress(KeyAscii As Integer)
   
   If UCase(GetFormMode(Me)) = "FIND" Or UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then

   Else
      KeyAscii = False
   End If

End Sub

Private Sub txtConfNum_Change()
    
 '   If Not IsNumeric(txtConfNum.Text) Then GoTo txtConfNum_Resume
 '
 '   Screen.MousePointer = HOURGLASS
 '
 '   If gConfNum = 0 Then
 '      gPriorConfNum = 0
 '   Else
 '      gPriorConfNum = gConfNum
 '   End If
 '   If txtConfNum.Text <> "" Then
 '      gConfNum = CLng(txtConfNum.Text)
 '      gRowChangeFormName = Me.Name
 '   Else
 '      gConfNum = 0
 '   End If
 '
'txtConfNum_Resume:
'  Screen.MousePointer = DEFAULT
    
End Sub


Private Sub txtConfNum_LostFocus()

  Dim SSTemp As Recordset
  If Not IsNumeric(txtConfNum.Text) Or txtConfNum.Text = "" Or GetFormMode(Me) <> "Insert" Then Exit Sub
  Set SSTemp = gBNB.OpenRecordset("select f_name,l_name from guesttbl where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount > 0 Then
    If Not IsNull(SSTemp("f_name")) Then txtFirstName.Text = SSTemp("f_name")
    If Not IsNull(SSTemp("l_name")) Then txtLastName.Text = SSTemp("l_name")
     'datdwComboAgency.SetFocus
  End If
  SSTemp.Close
  
End Sub



Public Function InsertTrigger() As Integer

  On Error GoTo InsertTrigger_Error
  
  Dim SSTemp As Recordset
  InsertTrigger = True
  
  SetFocusTo = ""
  'Check for confirmation number equal to zero
  If txtConfNum.Text = "0" Or txtConfNum.Text = "" Then
     gMsg = "Confirmation number cannot be zero or blank."
     InsertTrigger = False
     SetFocusTo = "txtConfNum"
     GoTo InsertTrigger_Resume
  End If
  'Conf number must exist in guesttbl
  Set SSTemp = gBNB.OpenRecordset("select conf from guesttbl where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Confirmation number must exist in General Guest Information before car rental information can be entered."
     InsertTrigger = False
     SSTemp.Close
     GoTo InsertTrigger_Resume
  End If
  SSTemp.Close
  'Refund due must be filled in
  If Trim(txtAmtDue.Text) = "" Then
     gMsg = "Amount Due cannot be blank."
     InsertTrigger = False
     SetFocusTo = "txtAmtDue"
     GoTo InsertTrigger_Resume
  ElseIf CCur(txtAmtDue.Text) = 0 Then
     gMsg = "Amount Due cannot be zero."
     InsertTrigger = False
     SetFocusTo = "txtAmtDue"
     GoTo InsertTrigger_Resume
  End If
  'Fillin Amount Paid if blank
  If Trim(txtAmtPaid.Text) = "" Then txtAmtPaid.Text = "0"
  'If refund paid IS NOT zero, Date Paid and Payment Method must be entered.
  If CCur(txtAmtPaid.Text) <> 0 Then
     If Trim(txtDatePaid.Text) = "" Then
        gMsg = "Date Paid cannot be blank if Amount Paid is filled in."
        InsertTrigger = False
        SetFocusTo = "txtDatePaid"
        GoTo InsertTrigger_Resume
     End If
     If Trim(txtComboPayMethod.Text) = "" Then
        gMsg = "Refund Method cannot be blank if Amount Paid is filled in."
        InsertTrigger = False
        SetFocusTo = "txtComboPayMethod"
        GoTo InsertTrigger_Resume
     End If
  End If
  'If refund paid IS zero, Date Paid and Payment Method must be blank.
  If CCur(txtAmtPaid.Text) = 0 Then
     If Trim(txtDatePaid.Text) <> "" Then
        gMsg = "Date Paid must be blank if Amount Paid is zero."
        InsertTrigger = False
        SetFocusTo = "txtDatePaid"
        GoTo InsertTrigger_Resume
     End If
     If Trim(txtComboPayMethod.Text) <> "" Then
        gMsg = "Refund Method must be blank if Amount Paid is zero."
        InsertTrigger = False
        SetFocusTo = "txtComboPayMethod"
        GoTo InsertTrigger_Resume
     End If
  End If
     
InsertTrigger_Resume:
   Exit Function
   
InsertTrigger_Error:
   Resume InsertTrigger_Resume

End Function

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









