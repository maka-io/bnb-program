VERSION 5.00
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmPaymentReceived 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Payments Received"
   ClientHeight    =   4332
   ClientLeft      =   48
   ClientTop       =   336
   ClientWidth     =   5712
   HelpContextID   =   133
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   ScaleHeight     =   4332
   ScaleWidth      =   5712
   Tag             =   "PaymentReceived"
   Begin VB.Data datPaymentAppliedTo 
      Appearance      =   0  'Flat
      Caption         =   "datPaymentAppliedTo"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   252
      Left            =   2520
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   4440
      Visible         =   0   'False
      Width           =   1872
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
      Height          =   555
      Left            =   4200
      TabIndex        =   14
      Top             =   3720
      Width           =   1455
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "PayRec.frx":0000
      Height          =   396
      Left            =   120
      TabIndex        =   0
      Top             =   3888
      Width           =   3948
      _Version        =   131075
      _ExtentX        =   6964
      _ExtentY        =   699
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
   Begin VB.Data datBrowse 
      Appearance      =   0  'Flat
      Caption         =   "datBrowse"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   264
      Left            =   120
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   4440
      Visible         =   0   'False
      Width           =   2295
   End
   Begin VB.TextBox txtComments 
      Appearance      =   0  'Flat
      DataField       =   "comments"
      DataSource      =   "datBrowse"
      Height          =   915
      Left            =   120
      MaxLength       =   255
      ScrollBars      =   2  'Vertical
      TabIndex        =   7
      Tag             =   "Text"
      Top             =   2850
      Width           =   3915
   End
   Begin VB.TextBox txtPrintTo 
      Appearance      =   0  'Flat
      DataField       =   "ReceivedFrom"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      TabIndex        =   4
      Tag             =   "Text"
      Top             =   1290
      Width           =   2595
   End
   Begin VB.TextBox txtCheckDate 
      Appearance      =   0  'Flat
      DataField       =   "DateReceived"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      TabIndex        =   3
      Tag             =   "Date"
      Top             =   900
      Width           =   2595
   End
   Begin VB.TextBox txtCheckNum 
      Appearance      =   0  'Flat
      DataField       =   "checknumber"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      TabIndex        =   5
      Tag             =   "Text"
      Top             =   1680
      Width           =   2595
   End
   Begin VB.TextBox txtCheckAmt 
      Appearance      =   0  'Flat
      DataField       =   "AmountReceived"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      TabIndex        =   2
      Tag             =   "Currency"
      Top             =   510
      Width           =   2595
   End
   Begin VB.TextBox txtConfNum 
      Appearance      =   0  'Flat
      DataField       =   "conf"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      TabIndex        =   1
      Tag             =   "Number"
      Top             =   120
      Width           =   2595
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
      Height          =   555
      Left            =   4200
      TabIndex        =   13
      Top             =   3120
      Width           =   1455
   End
   Begin VB.CommandButton cmdDisplayRows 
      Caption         =   "Display &Rows"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   555
      Left            =   4200
      TabIndex        =   12
      Top             =   2520
      Width           =   1455
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
      Height          =   555
      Left            =   4200
      TabIndex        =   11
      Top             =   1920
      Width           =   1455
   End
   Begin VB.CommandButton cmdFind 
      Caption         =   "&Find"
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
      Height          =   555
      Left            =   4200
      TabIndex        =   10
      Top             =   1320
      Width           =   1455
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
      Height          =   555
      Left            =   4200
      TabIndex        =   9
      Top             =   720
      Width           =   1455
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
      Height          =   555
      Left            =   4200
      TabIndex        =   8
      Top             =   120
      Width           =   1455
   End
   Begin SSDataWidgets_B.SSDBCombo datdwComboPaymentAppliedTo 
      Bindings        =   "PayRec.frx":0014
      DataField       =   "AppliedTo"
      DataSource      =   "datBrowse"
      Height          =   312
      Left            =   1440
      TabIndex        =   6
      Tag             =   "Text"
      Top             =   2052
      Width           =   2592
      ListAutoValidate=   0   'False
      ListWidthAutoSize=   0   'False
      _Version        =   131078
      BeginProperty HeadFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColorEven   =   0
      Columns(0).Width=   3200
      _ExtentX        =   4572
      _ExtentY        =   550
      _StockProps     =   93
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
   End
   Begin VB.Label lblComments 
      Caption         =   "Comments:"
      Height          =   195
      Left            =   120
      TabIndex        =   21
      Top             =   2640
      Width           =   975
   End
   Begin VB.Label lblAcctNum 
      Caption         =   "Applied To:"
      Height          =   195
      Left            =   120
      TabIndex        =   20
      Top             =   2160
      Width           =   1215
   End
   Begin VB.Label lblPrintTo 
      Caption         =   "Received From:"
      Height          =   195
      Left            =   120
      TabIndex        =   19
      Top             =   1380
      Width           =   1275
   End
   Begin VB.Label lblCheckDate 
      Caption         =   "Date Received:"
      Height          =   195
      Left            =   120
      TabIndex        =   18
      Top             =   990
      Width           =   1215
   End
   Begin VB.Label lblCheckNum 
      Caption         =   "Check Number:"
      Height          =   195
      Left            =   120
      TabIndex        =   17
      Top             =   1770
      Width           =   1275
   End
   Begin VB.Label lblCheckAmt 
      Caption         =   "Amt Received:"
      Height          =   195
      Left            =   120
      TabIndex        =   16
      Top             =   570
      Width           =   1215
   End
   Begin VB.Label lblConf 
      Caption         =   "Conf Number:"
      Height          =   195
      Left            =   120
      TabIndex        =   15
      Top             =   180
      Width           =   975
   End
End
Attribute VB_Name = "frmPaymentReceived"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim i, j As Integer
Dim TimesActivated As Integer
Dim CurrRec As Long
Dim SaveRec As Long
Dim NullDateArray()
Dim FailedLostFocus As Integer
Dim SetFocusTo As String
Dim OrigAppliedTo As String

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
   Else
     SetFormToBrowseMode Me
     CurrRec = GetCurrentRowNumber(datBrowse)
     datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
   End If
   txtConfNum.SetFocus

cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume

End Sub

Private Sub cmdCommit_Click()

    On Error GoTo cmdCommit_Click_Error
    
    Dim SSTemp As Recordset
    
    Screen.MousePointer = HOURGLASS

    Dim TempBook As Variant
    Dim RetVal As Integer
    Screen.MousePointer = HOURGLASS
    Select Case GetFormMode(Me)
      Case "Update"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        If Not InsertTrigger() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'If number formats are OK, then set currency formats
        SetToCurrencyFormat Me
        'Warn user if they are attempting to update a record to be applied to prepayment,
        'and there is already a payment received which has been applied to prepayment.
        'Service Fee may need to be adjusted because guest has revised reservations, and a
        'service fee has already been taken from the original prepayment.
        If datdwComboPaymentAppliedTo.Text = "Prepayment" And OrigAppliedTo <> "Prepayment" Then
           Set SSTemp = gBNB.OpenRecordset("select count(*) from paymentreceived where conf = " & txtConfNum.Text & " and AppliedTo = 'Prepayment'", dbOpenSnapshot)
           GetSSRows SSTemp
           If IsNull(SSTemp(0)) Or SSTemp(0) = 0 Then
              'No previously entered prepayments - allow entry of prepayment.
           ElseIf SSTemp(0) > 1 Then
              gMsg = "Previous payments received have already been applied to Prepayment. " & _
                     "Service fee for this confirmation may need adjustment if this payment " & _
                     "is also entered as a Prepayment. Continue with entry?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, "Payments Received") = IDNO Then
                 GoTo cmdCommit_Click_Resume
              End If
           Else
              gMsg = "A previous payment received has already been applied to Prepayment. " & _
                     "Service fee for this confirmation may need adjustment if this payment " & _
                     "is also entered as a Prepayment. Continue with entry?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, "Payments Received") = IDNO Then
                 GoTo cmdCommit_Click_Resume
              End If
           End If
        End If
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
           'datBrowse.Recordset.Bookmark = datBrowse.Recordset.LastModified
           datBrowse.UpdateControls
        End If
        SetToCurrencyFormat Me
      Case "Delete"
           gMsg = "Delete this row from Payments Received?"
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
    End Select
    
    If datBrowse.Recordset.RecordCount = 0 Then
      SetFormToNoRowsMode Me
    Else
      SetFormToBrowseMode Me
      CurrRec = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
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

Private Sub cmdDisplayRows_Click()

    'Warn if more than 500 records
    If datBrowse.Recordset.RecordCount > 300 Then
      gMsg = "You are about to display " & _
             datBrowse.Recordset.RecordCount & _
             " rows to the screen. Continue?"
      If MsgBox(gMsg, MB_ICONQUESTION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then Exit Sub
    End If
    Screen.MousePointer = HOURGLASS
    gCaption = "Payments Received Listing"
    gSQL = datBrowse.RecordSource
    'frmBoundListing.Show
    Dim frmNewBoundListing As New frmBoundListing  ' Declare form variable
    frmNewBoundListing.Show     ' Load and display new instance
    
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
      cmdFind.DEFAULT = True
      cmdFind.Caption = "&Run Query"
   Else
      cmdFind.Caption = "&Find"
      Criteria = BuildFindCriteria(Me, "conf")
      If Criteria <> "" Then
         datBrowse.RecordSource = Criteria
         If Not GetDCRows(datBrowse) Then Exit Sub
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
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdFind_Click_Error:
    If IsError("cmdFind_Click") Then
        Resume cmdFind_Click_Resume
    Else
        Resume cmdFind_Click_Resume
        'Resume Next
    End If

cmdFind_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub
End Sub

Private Sub cmdUpdate_Click()

   On Error GoTo cmdUpdate_Click_Error
   
   OrigAppliedTo = Trim(datdwComboPaymentAppliedTo.Text)
   SetFormToUpdateMode Me
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

Private Sub datdwComboPaymentAppliedTo_Change()
  
  If Trim(datdwComboPaymentAppliedTo.Text) = "" Then Exit Sub
  Dim SSTemp As Recordset

  Set SSTemp = gBNB.OpenRecordset("select AppliedTo from PaymentAppliedTo Where AppliedTo Like '" & datdwComboPaymentAppliedTo.Text & "*'", dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount > 0 Then datdwComboPaymentAppliedTo.Text = SSTemp(0)
  SSTemp.Close
  
End Sub

Private Sub datdwComboPaymentAppliedTo_CloseUp()

   cmdFind.DEFAULT = True

End Sub


Private Sub datdwComboPaymentAppliedTo_DropDown()

   On Error GoTo DropDown_Error
   
   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        datdwComboPaymentAppliedTo.DataFieldList = ""
        Exit Sub
     Case Else
        datdwComboPaymentAppliedTo.DefColWidth = datdwComboPaymentAppliedTo.Width * 1.5
        datdwComboPaymentAppliedTo.DataFieldList = "appliedto"
   End Select
   
   'datDropListing.DatabaseName = gDatabaseName
   datPaymentAppliedTo.RecordSource = "select * from paymentappliedto Where Trim(AppliedTo) <> ''"
   If Not GetDCRows(datPaymentAppliedTo) Then Exit Sub
   cmdFind.DEFAULT = False

DropDown_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

DropDown_Error:
   Resume DropDown_Resume
   
End Sub


Private Sub datdwComboPaymentAppliedTo_KeyPress(KeyAscii As Integer)
   
   If UCase(GetFormMode(Me)) = "FIND" Or UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then

   Else
      KeyAscii = False
   End If

End Sub

Private Sub datdwData1_Click(ByVal nPosition As Integer)
    
    'On Error GoTo datdwData1_Click_Error
    Screen.MousePointer = HOURGLASS
    Me.SetFocus
   ' Dim EntryConfNum As String
   ' EntryConfNum = Trim$(txtConfNum.Text)
    'case1: first row button
    If nPosition = 3 Then
        CurrRec = 1
    'case2: previous page button
    ElseIf nPosition = 5 Then
        If CurrRec > datdwData1.PageValue Then
            CurrRec = CurrRec - datdwData1.PageValue
        Else
            CurrRec = 1
        End If
    'case3: previous row button
    ElseIf nPosition = 7 Then
        If CurrRec > 1 Then
            CurrRec = CurrRec - 1
        Else
            CurrRec = 1
        End If
    'case4: save bookmark button
    ElseIf nPosition = 16 Then
        SaveRec1 = CurrRec
    'case5: goto saved bookmark
    ElseIf nPosition = 18 Then
        If SaveRec1 > 0 Then CurrRec = SaveRec1
    'case6: next row button
    ElseIf nPosition = 8 Then
        If CurrRec < Me.datBrowse.Recordset.RecordCount Then
            CurrRec = CurrRec + 1
        Else
            CurrRec = Me.datBrowse.Recordset.RecordCount
        End If
    'case7: next page button
    ElseIf nPosition = 6 Then
        If CurrRec < Me.datBrowse.Recordset.RecordCount - datdwData1.PageValue Then
            CurrRec = CurrRec + datdwData1.PageValue
        Else
            CurrRec = Me.datBrowse.Recordset.RecordCount
        End If
    'case8: last row button
    ElseIf nPosition = 4 Then
        CurrRec = Me.datBrowse.Recordset.RecordCount
    End If
    datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount

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
If Me.WindowState = MINIMIZED Then Exit Sub

If TimesActivated < 1 Then
   Screen.MousePointer = HOURGLASS
   TimesActivated = TimesActivated + 1
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = 0"
   If Not GetDCRows(datBrowse) Then GoTo Form_Activate_Resume
   If Not GetDCRows(datPaymentAppliedTo) Then GoTo Form_Activate_Resume
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
   Else
      SetFormToBrowseMode Me
      CurrRec = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
   End If
End If

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   txtConfNum.SetFocus
   Exit Sub

Form_Activate_Error:
   Resume Form_Activate_Resume

End Sub

Private Sub Form_Load()
   
   On Error GoTo Load_Error
   
   TimesActivated = 0
   datPaymentAppliedTo.DatabaseName = gDatabaseName
   datPaymentAppliedTo.RecordSource = "select * from paymentappliedto"
   If Not GetDCRows(datPaymentAppliedTo) Then Exit Sub
   datBrowse.DatabaseName = gDatabaseName
   'datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = 0"
   CurrRec = 1
   SaveRec = 0

Load_Resume:
   Exit Sub

Load_Error:
   Resume Load_Resume
   
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
  
  InsertTrigger = True
  
  Dim SSTemp As Recordset
  Dim i, j As Integer
  
  'If Amount Received is filled in then Date Received and Applied To
  'must also be filled in, and vice versa (all 3 ways).
  '#1
  txtCheckAmt.Text = Trim(txtCheckAmt.Text)
  txtCheckDate.Text = Trim(txtCheckDate.Text)
  txtComments.Text = Trim(txtComments.Text)
  txtCheckNum.Text = Trim(txtCheckNum.Text)
  txtPrintTo.Text = Trim(txtPrintTo.Text)
  datdwComboPaymentAppliedTo.Text = Trim(datdwComboPaymentAppliedTo.Text)
  If txtCheckAmt.Text <> "" Then
     If txtCheckDate.Text = "" Then
        gMsg = "Date Received must be filled in."
        txtCheckDate.SetFocus
        InsertTrigger = False
     ElseIf datdwComboPaymentAppliedTo.Text = "" Then
        gMsg = "Payment Applied To must be filled in."
        datdwComboPaymentAppliedTo.SetFocus
        InsertTrigger = False
     ElseIf txtCheckNum.Text = "" Then
        gMsg = "Check Number must be filled in."
        txtCheckNum.SetFocus
        InsertTrigger = False
     End If
  ElseIf txtCheckDate.Text <> "" Then
     If txtCheckAmt.Text = "" Then
        gMsg = "Payment Amount must be filled in."
        txtCheckAmt.SetFocus
        InsertTrigger = False
     ElseIf datdwComboPaymentAppliedTo.Text = "" Then
        gMsg = "Payment Applied To must be filled in."
        datdwComboPaymentAppliedTo.SetFocus
        InsertTrigger = False
     End If
  ElseIf datdwComboPaymentAppliedTo.Text <> "" Then
     If txtCheckAmt.Text = "" Then
        gMsg = "Payment Amount must be filled in."
        txtCheckAmt.SetFocus
        InsertTrigger = False
     ElseIf txtCheckDate.Text = "" Then
        gMsg = "Date Received must be filled in."
        txtCheckDate.SetFocus
        InsertTrigger = False
     End If
  End If
  If Trim(txtCheckAmt.Text) = "" And _
     (txtComments.Text <> "" Or _
      txtCheckNum.Text <> "" Or _
      txtPrintTo.Text <> "" Or _
      txtCheckNum.Text <> "") Then
      gMsg = "Payment Amount must be filled in."
      txtCheckAmt.SetFocus
      InsertTrigger = False
  End If
  'Validate 'Applied To' value
  If datdwComboPaymentAppliedTo.Text <> "" Then
     Set SSTemp = gBNB.OpenRecordset("select AppliedTo from paymentappliedto", dbOpenSnapshot)
     GetSSRows SSTemp
     j = 0
     For i = 0 To SSTemp.RecordCount - 1
       'MsgBox SSTemp("AppliedTo")
       If UCase(SSTemp("AppliedTo")) = UCase(datdwComboPaymentAppliedTo.Text) Then
          j = 1
          Exit For
       End If
       SSTemp.MoveNext
     Next i
     If j = 0 Then
        gMsg = "Invalid 'Applied To' value. Please select from the dropdown list."
        datdwComboPaymentAppliedTo.SetFocus
        InsertTrigger = False
        SSTemp.Close
        GoTo InsertTrigger_Resume
     End If
     SSTemp.Close
  End If
  
InsertTrigger_Resume:
   Exit Function

InsertTrigger_Error:
   Resume InsertTrigger_Resume
  
End Function

