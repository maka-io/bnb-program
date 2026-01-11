VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmGuestTravel 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Guest Travel Agency"
   ClientHeight    =   5205
   ClientLeft      =   495
   ClientTop       =   795
   ClientWidth     =   5805
   HelpContextID   =   105
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   5205
   ScaleWidth      =   5805
   Tag             =   "tagentbl"
   Begin VB.TextBox txtAccountNum 
      Appearance      =   0  'Flat
      DataField       =   "accountnum"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   5
      TabStop         =   0   'False
      Tag             =   "Number"
      Top             =   1560
      Width           =   1275
   End
   Begin VB.TextBox txtComment 
      Appearance      =   0  'Flat
      DataField       =   "comment"
      DataSource      =   "datBrowse"
      Height          =   825
      Left            =   1260
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   7
      Tag             =   "Text"
      Top             =   2280
      Width           =   3048
   End
   Begin VB.CommandButton cmdGoTo 
      Caption         =   "&Go to..."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   525
      Left            =   4440
      TabIndex        =   18
      Top             =   4650
      Width           =   1335
   End
   Begin VB.Frame fraCommDue 
      Caption         =   "Commission Due to Agency"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1545
      Left            =   72
      TabIndex        =   24
      Top             =   3210
      Width           =   4248
      Begin Threed.SSCheck chkDefCom 
         DataField       =   "DefCom"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   90
         TabIndex        =   9
         Top             =   1140
         Width           =   3855
         _Version        =   65536
         _ExtentX        =   6800
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Commission has been deferred in Payment History"
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
      Begin VB.TextBox txtCommDue 
         Appearance      =   0  'Flat
         DataField       =   "commdue"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1170
         MaxLength       =   30
         TabIndex        =   8
         Tag             =   "Currency"
         Top             =   690
         Width           =   1215
      End
      Begin VB.Label lblComAmtValue 
         Caption         =   "xxxxxxxxxx"
         Height          =   255
         Left            =   2760
         TabIndex        =   29
         Top             =   360
         Width           =   1185
      End
      Begin VB.Label lblComAmt 
         Caption         =   "Suggested Commission Amount:"
         Height          =   225
         Left            =   90
         TabIndex        =   28
         Top             =   360
         Width           =   2595
      End
      Begin VB.Label lblAmtDue 
         Caption         =   "Amount Due:"
         Height          =   255
         Left            =   120
         TabIndex        =   25
         Top             =   750
         Width           =   1035
      End
   End
   Begin VB.TextBox txtAgentName 
      Appearance      =   0  'Flat
      DataField       =   "agentname"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   6
      Tag             =   "Text"
      Top             =   1920
      Width           =   3048
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
      Height          =   525
      Left            =   4440
      TabIndex        =   17
      Top             =   4080
      Width           =   1335
   End
   Begin VB.CommandButton cmdDisplayRows 
      Caption         =   "Display &Rows"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   525
      Left            =   4440
      TabIndex        =   15
      Top             =   2940
      Width           =   1335
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
      Height          =   525
      Left            =   4440
      TabIndex        =   14
      Top             =   2370
      Width           =   1335
   End
   Begin VB.CommandButton cmdFind 
      Caption         =   "&Find"
      Default         =   -1  'True
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   525
      Left            =   4440
      TabIndex        =   13
      Top             =   1800
      Width           =   1335
   End
   Begin VB.CommandButton cmdDelete 
      Caption         =   "&Delete"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   525
      Left            =   4440
      TabIndex        =   12
      Top             =   1260
      Width           =   1335
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
      Height          =   525
      Left            =   4440
      TabIndex        =   10
      Top             =   120
      Width           =   1335
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
      Height          =   525
      Left            =   4440
      TabIndex        =   16
      Top             =   3510
      Width           =   1335
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
      Height          =   525
      Left            =   4440
      TabIndex        =   11
      Top             =   690
      Width           =   1335
   End
   Begin VB.Data datAgencyList 
      Appearance      =   0  'Flat
      Caption         =   "datAgencyList"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   1980
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   5250
      Visible         =   0   'False
      Width           =   2115
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
      Top             =   5250
      Visible         =   0   'False
      Width           =   1875
   End
   Begin VB.TextBox txtLastName 
      Appearance      =   0  'Flat
      DataField       =   "l_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      MaxLength       =   50
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   840
      Width           =   3048
   End
   Begin VB.TextBox txtFirstName 
      Appearance      =   0  'Flat
      DataField       =   "f_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      MaxLength       =   50
      TabIndex        =   2
      Tag             =   "Text"
      Top             =   480
      Width           =   3048
   End
   Begin VB.TextBox txtConfNum 
      Appearance      =   0  'Flat
      DataField       =   "conf"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      MaxLength       =   9
      TabIndex        =   1
      Tag             =   "Number"
      Top             =   120
      Width           =   1035
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "travel.frx":0000
      Height          =   336
      Left            =   60
      TabIndex        =   0
      Tag             =   "tagentbl"
      Top             =   4836
      Width           =   4248
      _Version        =   131075
      _ExtentX        =   7488
      _ExtentY        =   582
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
   Begin SSDataWidgets_B.SSDBCombo datdwComboAgency 
      Bindings        =   "travel.frx":0014
      DataField       =   "agencyname"
      DataSource      =   "datBrowse"
      Height          =   288
      Left            =   1260
      TabIndex        =   4
      Tag             =   "Text"
      Top             =   1200
      Width           =   3084
      ScrollBars      =   3
      ListAutoValidate=   0   'False
      ListAutoPosition=   0   'False
      ListWidthAutoSize=   0   'False
      MaxDropDownItems=   20
      BevelType       =   0
      MultiLine       =   -1  'True
      _Version        =   131078
      BeginProperty HeadFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Columns(0).Width=   3200
      _ExtentX        =   5440
      _ExtentY        =   508
      _StockProps     =   93
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
   End
   Begin VB.Label lblAcctNum 
      Caption         =   "Account Num:"
      Height          =   255
      Left            =   60
      TabIndex        =   27
      Tag             =   "Number"
      Top             =   1620
      Width           =   1095
   End
   Begin VB.Label lblComment 
      Caption         =   "Comments:"
      Height          =   255
      Left            =   60
      TabIndex        =   26
      Top             =   2340
      Width           =   1095
   End
   Begin VB.Label lblLastName 
      Caption         =   "Last Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   23
      Top             =   900
      Width           =   1095
   End
   Begin VB.Label lblFirstName 
      Caption         =   "First Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   22
      Top             =   540
      Width           =   1095
   End
   Begin VB.Label lblConfNum 
      Caption         =   "Conf Number:"
      Height          =   255
      Left            =   60
      TabIndex        =   21
      Top             =   180
      Width           =   1095
   End
   Begin VB.Label lblAgentName 
      Caption         =   "Agent:"
      Height          =   255
      Left            =   60
      TabIndex        =   20
      Top             =   1980
      Width           =   1095
   End
   Begin VB.Label lblAgencyName 
      Caption         =   "Agency Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   19
      Top             =   1260
      Width           =   1095
   End
End
Attribute VB_Name = "frmGuestTravel"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim i As Integer
Dim TimesActivated As Integer
Dim CurrRec1 As Long
Dim CurrRec2 As Long
Dim SaveRec1 As Long
Dim SaveRec2 As Long
Dim NullDateArray()
Dim FailedLostFocus As Integer
Dim SetFocusTo As String


Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error
   
   Select Case GetFormMode(Me)
     Case "Insert"
        If datBrowse.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
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
   If Not OtherGuestFormsInBrowseMode And GetFormMode(Me) = "No Rows" Then gConfNum = 0
   GetCommissionableAmt
   
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
        'Check for specifics of frmGuestTravel
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
        'Was problem with dropping down more than once, then committing
        datBrowse.Recordset("agencyname") = datdwComboAgency.Text
        'If new record is being added
        If datBrowse.EditMode = dbEditAdd Then
           'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
           'unbind control's DataField property and commit Null.
           RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
           datBrowse.Recordset.Update
           datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
           If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
           'Do if there was at least one Date or Number set to null
           If RetVal Then BindNullDateControl Me, NullDateArray
           'Make the current record current again
           If Not datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then datBrowse.Recordset.MoveLast
        End If
        SetToCurrencyFormat Me
      Case "Update"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmGuestTravel
        If Not UpdateTrigger() Then
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
           'Do if there was at least one Date or Number was set to null
           If RetVal Then BindNullDateControl Me, NullDateArray
           'Make the current record current again.
           datBrowse.UpdateControls
        End If
        SetToCurrencyFormat Me
      Case "Delete"
           gMsg = "Delete this guest's Travel Agency information?"
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
    DoEvents
    If datBrowse.Recordset.RecordCount = 0 Then
      SetFormToNoRowsMode Me
    Else
      SetFormToBrowseMode Me
      CurrRec1 = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount
    End If
    GetCommissionableAmt
   
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
    gCaption = "Guest Travel Agency Listing"
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
   
   Dim Criteria, DueStr As String
   If cmdFind.Caption = "&Find" Then
      SetFormToFindMode Me
      cmdFind.DEFAULT = True
      lblComAmtValue.Caption = ""
      txtConfNum.SetFocus
      cmdFind.Caption = "&Run Query"
   Else
      Screen.MousePointer = HOURGLASS
      cmdFind.Caption = "&Find"
      Criteria = BuildFindCriteria(Me, "conf")
      If Criteria <> "" Then
         datBrowse.UpdateControls
         datBrowse.RecordSource = Criteria
         Screen.MousePointer = HOURGLASS
         If Not GetDCRows(datBrowse) Then Exit Sub
         Screen.MousePointer = DEFAULT
         If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
            SetFormToNoRowsMode Me
         Else
            SetFormToBrowseMode Me
            'Setup Payment Due control
            CurrRec1 = GetCurrentRowNumber(datBrowse)
            datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount
         End If
      Else
         SetFormToNoRowsMode Me
      End If
      txtConfNum.SetFocus
      'MsgBox Criteria
      datBrowse.RecordSource = Criteria
      If Not GetDCRows(datBrowse) Then Exit Sub
      DoEvents
      If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
         SetFormToNoRowsMode Me
      Else
         SetFormToBrowseMode Me
         'Setup Payment Due control
         CurrRec1 = GetCurrentRowNumber(datBrowse)
         datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount
      End If
   End If

cmdFind_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

cmdFind_Click_Error:
    MsgBox Err.Description
    Resume cmdFind_Click_Resume
 
BuildFindCriteria_Invalid_Characters:
  MsgBox gMsg, MB_ICONSTOP, Me.Caption
  GoTo cmdFind_Click_Resume

End Sub

Private Sub cmdGoTo_Click()

  If txtConfNum.Text <> "" Then gConfNum = CLng(txtConfNum.Text)
  mdiBNB.mnuLine1.Visible = True
  mdiBNB.mnuPayToHost.Visible = True
  mdiBNB.mnuAuditTrail.Visible = True
  PopupMenu mdiBNB.mnuGuestData
  mdiBNB.mnuLine1.Visible = False
  mdiBNB.mnuPayToHost.Visible = False
  mdiBNB.mnuAuditTrail.Visible = False
  
End Sub

Private Sub cmdInsert_Click()

    On Error GoTo cmdInsert_Click_Error
    
    
    If Trim(datBrowse.RecordSource) = "" Then
       datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
       If Not GetDCRows(datBrowse) Then Exit Sub
    End If
        
    SetFormToInsertMode Me
    txtFirstName.Locked = True
    txtLastName.Locked = True
    txtFirstName.ForeColor = BLACK
    txtLastName.ForeColor = BLACK
    chkDefCom.Enabled = False
'    txtAgencyName.Enabled = False
    datBrowse.Recordset.AddNew
    SetZeroLengthString Me
    
    'Get first and last name if gConfNum is set.
    If gConfNum <> 0 Then
       Dim SSTemp As Recordset
       txtConfNum.Locked = True
       txtConfNum.ForeColor = BLACK
       Set SSTemp = gBNB.OpenRecordset("select f_name,l_name from guesttbl where conf = " & gConfNum, dbOpenSnapshot)
       GetSSRows SSTemp
       If SSTemp.RecordCount > 0 Then
          txtConfNum.Text = gConfNum
          If Not IsNull(SSTemp("f_name")) Then txtFirstName.Text = SSTemp("f_name")
          If Not IsNull(SSTemp("l_name")) Then txtLastName.Text = SSTemp("l_name")
          datdwComboAgency.SetFocus
       End If
       SSTemp.Close
    Else
       txtConfNum.Locked = False
       txtConfNum.ForeColor = BLUE
       txtConfNum.SetFocus
    End If
    GetCommissionableAmt
    If GetFormMode(Me) = "Insert" Then
       txtCommDue.Text = lblComAmtValue.Caption
    End If
    
cmdInsert_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdInsert_Click_Error:
   MsgBox Err.Description
   Resume cmdInsert_Click_Resume
   
End Sub

Private Sub cmdUpdate_Click()

   On Error GoTo cmdUpdate_Click_Error
   
   SetFormToUpdateMode Me
'   txtAgencyName.Enabled = False
   datBrowse.Recordset.Edit
   txtCommDue.SetFocus
   chkDefCom.Enabled = False
   
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

    On Error GoTo datBrowse_Reposition_Error
    
    'Get payment received info for current conf.
    If GetFormMode(Me) = "Browse" And Trim(txtConfNum.Text) <> "" Then
      GetCommissionableAmt
    End If

datBrowse_Reposition_Resume:
  Screen.MousePointer = DEFAULT
  Exit Sub
  
datBrowse_Reposition_Error:
  Resume datBrowse_Reposition_Resume
   'SetToCurrencyFormat Me
End Sub

Private Sub datdwComboAgency_Change()
   
'   If UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then
'      If Trim(datdwComboAgency.Text) = "" Then txtAccountNum.Text = ""
'   End If
   
End Sub

Private Sub datdwComboAgency_Click()

  On Error GoTo datdwComboAgency_Click_Error
  
  Dim SSTemp As Recordset
  txtAccountNum.Text = datdwComboAgency.Columns("accountnum").CellValue(datdwComboAgency.SelBookmarks(0))

datdwComboAgency_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

datdwComboAgency_Click_Error:
    MsgBox Err.Description
    Resume datdwComboAgency_Click_Resume
     
End Sub

Private Sub datdwComboAgency_CloseUp()

   On Error GoTo Closeup_Error
   'Set account number.
   txtAccountNum.Text = datdwComboAgency.Columns("accountnum").CellValue(datdwComboAgency.SelBookmarks(0))
   'Fix for unknown bug. Symptoms:
   '1. Click Insert button.
   '2. TYPE a agency name EXACTLY (including case) as it exists in the database.
   '3. Hit dropdown for agency name and select same agency previously typed in.
   '4. Continue with entry of other fields
   '5. On Commit, agency name field is blanked and Null agency name is saved to Database.
   datdwComboAgency.Text = ""
   datdwComboAgency.Refresh
   If Not datAgencyList.Recordset.BOF And Not datAgencyList.Recordset.EOF Then
      datdwComboAgency.Text = datdwComboAgency.Columns("agencyname").Text
   End If
   datdwComboAgency.Refresh
   cmdFind.DEFAULT = True
   
Closeup_Resume:
   Exit Sub

Closeup_Error:
   Resume Closeup_Resume

End Sub


Private Sub datdwComboAgency_DropDown()

   On Error GoTo datdwComboAgency_DropDown_Error
   Dim bkmark As Variant
   Screen.MousePointer = HOURGLASS
   
   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        datdwComboAgency.DataFieldList = ""
        GoTo datdwComboAgency_DropDown_Resume
     Case Else
        datdwComboAgency.ListWidth = datdwComboAgency.Width * 3.5
        datdwComboAgency.DefColWidth = datdwComboAgency.Width * 0.8
        datdwComboAgency.DataFieldList = "agencyname"
   End Select
   If Trim(datdwComboAgency.Text) <> "" Then
      'Replace any apostrophes (') with asterik (*)
      SelectedAgency = Replace_All_In_With("'", datdwComboAgency.Text, "*")
      datAgencyList.RecordSource = "SELECT agencyname,accountnum,address,city,state,zipcode " & _
                                   "FROM tamaster " & _
                                   "WHERE agencyname Like '" & SelectedAgency & "*' " & _
                                   "ORDER BY agencyname"
   Else
      datAgencyList.RecordSource = "SELECT agencyname,accountnum,address,city,state,zipcode " & _
                                   "FROM tamaster WHERE agencyname IS NOT NULL ORDER BY agencyname"
   End If
   If Not GetDCRows(datAgencyList) Then GoTo datdwComboAgency_DropDown_Resume
   'Select the appropriate agency in the dropdown list.
   If Trim(txtAccountNum.Text) <> "" Then
      datdwComboAgency.ListAutoPosition = False
      datdwComboAgency.SelBookmarks.RemoveAll
      datdwComboAgency.MoveFirst
      For j = 0 To datdwComboAgency.Rows - 1
         bkmrk = datdwComboAgency.Bookmark
         If txtAccountNum.Text = datdwComboAgency.Columns("accountnum").CellValue(bkmrk) Then
            'MsgBox "Found It: J=" & Str(j) & ", " & datdwComboAgency.Columns("accountnum").CellValue(bkmrk)
            datdwComboAgency.SelBookmarks.Add (bkmark)
            Exit For
         End If
         datdwComboAgency.MoveNext
      Next j
    End If
    cmdFind.DEFAULT = False
   
datdwComboAgency_DropDown_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

datdwComboAgency_DropDown_Error:
    MsgBox Err.Description
    Resume datdwComboAgency_DropDown_Resume

End Sub

Private Sub datdwComboAgency_InitColumnProps()

   datdwComboAgency.Columns("accountnum").Width = Me.TextWidth("XXXXXXXXXX")
   datdwComboAgency.Columns("city").Width = Me.TextWidth("XXXXXXXXXXXXXXXXXX")
   datdwComboAgency.Columns("state").Width = Me.TextWidth("XXXXXXXXXXXXXX")
   datdwComboAgency.Columns("zipcode").Width = Me.TextWidth("XXXXXXXXXXXXXX")
   
End Sub
Private Sub datdwComboAgency_KeyPress(KeyAscii As Integer)
   
   'Need this because it is set to False in dropdown to locate proper row.
   'This allows users to press a key to goto a row in dropdown list.
   datdwComboAgency.ListAutoPosition = True
   
   If UCase(GetFormMode(Me)) = "FIND" Or UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then

   Else
      KeyAscii = False
   End If

End Sub


Private Sub datdwData1_Click(ByVal nPosition As Integer)
    
    On Error GoTo datdwData1_Click_Error
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

datdwData1_Click_Error:
    Resume datdwData1_Click_Resume

End Sub


Private Sub Form_Activate()

On Error GoTo Form_Activate_Error

'If this form is in the background (does not have focus) and the
'Minimize button is clicked on this form that does not yet have the focus,
'an endless loop of Minimizing and Activating will occur. The following
'line prevents this interesting problem.
If Me.WindowState = MINIMIZED Then Exit Sub
'If form is only regaining focus then exit
If UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then Exit Sub
'MsgBox "gConf=" & Str$(gConfNum) & ", gPrior=" & Str$(gPriorConfNum) & ", gRowChangeFormName=" & gRowChangeFormName
If UCase(GetFormMode(Me)) = "BROWSE" Then GetCommissionableAmt
If TimesActivated < 1 Or (gConfNum <> gPriorConfNum And gRowChangeFormName <> Me.Name) _
   Or ((Trim$(txtConfNum.Text) <> Trim$(gConfNum)) And (Trim$(txtConfNum.Text) <> "")) _
   Or gConfNum <> 0 And Trim(txtConfNum.Text) = "" Then
   Screen.MousePointer = HOURGLASS
   TimesActivated = TimesActivated + 1
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
   If Not GetDCRows(datBrowse) Then GoTo Form_Activate_Resume
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
   Else
      SetFormToBrowseMode Me
      CurrRec1 = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount
      'Get Commissionable amount
      GetCommissionableAmt
   End If
End If

Form_Activate_Resume:
  Screen.MousePointer = DEFAULT
  'Do this in the event of a name (first,last or both) change on frmGeneralGuest
  txtConfNum.SetFocus
  txtFirstName.SetFocus
  txtConfNum.SetFocus
  Exit Sub
  
Form_Activate_Error:
  MsgBox Str(Err) & ", " & Err.Description
  Resume Form_Activate_Resume
  
End Sub

Private Sub Form_Load()
   
   'Screen.MousePointer = HOURGLASS
   On Error GoTo Load_Error
   
   TimesActivated = 0
   If Not OtherGuestFormsInBrowseMode Then gConfNum = 0
   datBrowse.DatabaseName = gDatabaseName
   datAgencyList.DatabaseName = gDatabaseName
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
   CurrRec1 = 1
   SaveRec1 = 0
   lblComAmtValue.Caption = ""

Load_Resume:
   Exit Sub
   
Load_Error:
   Resume Load_Resume
   
End Sub


Private Sub Form_Unload(Cancel As Integer)
   DoEvents
End Sub











Private Sub txtConfNum_Change()
    
    If Not IsNumeric(txtConfNum.Text) Then GoTo txtConfNum_Resume
    
    Screen.MousePointer = HOURGLASS
    
    If gConfNum = 0 Then
       gPriorConfNum = 0
    Else
       gPriorConfNum = gConfNum
    End If
    If txtConfNum.Text <> "" Then
       gConfNum = CLng(txtConfNum.Text)
       gRowChangeFormName = Me.Name
    Else
       gConfNum = 0
    End If

txtConfNum_Resume:
  Screen.MousePointer = DEFAULT
    
End Sub


Private Sub txtConfNum_LostFocus()

  On Error GoTo LostFocus_Error
  
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
  GetCommissionableAmt
  If GetFormMode(Me) = "Insert" Then
     txtCommDue.Text = lblComAmtValue.Caption
  End If
  
LostFocus_Resume:
   Exit Sub

LostFocus_Error:
   Resume LostFocus_Resume
     
End Sub



Public Function InsertTrigger() As Integer

  On Error GoTo InsertTrigger_Error
  
  Dim SSTemp As Recordset
  InsertTrigger = True

  SetFocusTo = ""
  txtConfNum.Text = Trim(txtConfNum.Text)
  'Check for confirmation number equal to zero
  If txtConfNum.Text = "0" Or txtConfNum.Text = "" Then
     gMsg = "Confirmation number cannot be zero or blank."
     InsertTrigger = False
     SetFocusTo = "txtConfNum"
     Exit Function
  End If
  'Conf number must exist in guesttbl
  Set SSTemp = gBNB.OpenRecordset("select conf from guesttbl where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Confirmation number must exist in General Guest Information before travel agency can be entered."
     InsertTrigger = False
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close
  'Don't allow insert if Travel Agency already exists for this conf number.
  If GetFormMode(Me) = "Insert" Then
     Set SSTemp = gBNB.OpenRecordset("select conf from tagentbl where conf = " & txtConfNum.Text, dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount > 0 Then
        gMsg = "A Travel Agency entry already exists for this confirmation."
        InsertTrigger = False
        SSTemp.Close
        Exit Function
     End If
     SSTemp.Close
  End If
  'Account number cannot be blank
  If Trim(txtAccountNum.Text) = "" Then
     gMsg = "Account Number cannot be blank. Select an agency from the dropdown list."
     InsertTrigger = False
     SetFocusTo = "datdwComboAgency"
     Exit Function
  End If
  'Agency name cannot be blank
  If Trim(datdwComboAgency.Text) = "" Then
     gMsg = "Agency name cannot be blank. Select an agency from the dropdown list."
     InsertTrigger = False
     SetFocusTo = "datdwComboAgency"
     Exit Function
  End If
  'Account number must exist in travel agency account table (tamaster) and
  'Agency Name entered must match the Agency Name associated with the Account Number
  datdwComboAgency.Text = Trim(datdwComboAgency.Text)
  Set SSTemp = gBNB.OpenRecordset("SELECT AccountNum,AgencyName FROM tamaster WHERE AccountNum = " & txtAccountNum.Text, dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Agency does not exist in Travel Agency Accounts. Select an agency from the dropdown list."
     InsertTrigger = False
     SetFocusTo = "datdwComboAgency"
     SSTemp.Close
     Exit Function
  Else
     If SSTemp(1) <> datdwComboAgency.Text Then
        gMsg = "Agency Name entered is not correct for this Account Number. Select an agency from the dropdown list."
        InsertTrigger = False
        SetFocusTo = "datdwComboAgency"
        SSTemp.Close
        Exit Function
     End If
  End If
  SSTemp.Close
  'Commission due to T/A must be filled in
  If Trim(txtCommDue.Text) = "" Then
     gMsg = "Commission due to travel agency cannot be blank. If no commission is " & _
            "due, enter 0"
     InsertTrigger = False
     SetFocusTo = "txtCommDue"
     Exit Function
  End If

InsertTrigger_Resume:
   Exit Function
   
InsertTrigger_Error:
   MsgBox Err.Description
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

Public Function NoCommPaidFieldsEntered() As Integer
     
   NoCommPaidFieldsEntered = False
   If Trim$(txtAmountPaid.Text) = "" _
      And Trim$(txtDatePaid.Text) = "" _
      And Trim$(txtCheckNum.Text) = "" Then NoCommPaidFieldsEntered = True

End Function

Public Sub CommissionPaidMode(TheMode As String)

   If TheMode = "Disabled" Then
      fraCommPaid.Enabled = False
      txtAmountPaid.Enabled = False
      txtDatePaid.Enabled = False
      txtCheckNum.Enabled = False
   Else
      fraCommPaid.Enabled = True
      txtAmountPaid.Enabled = True
      txtDatePaid.Enabled = True
      txtCheckNum.Enabled = True
   End If
   
End Sub


Public Function UpdateTrigger() As Integer

  On Error GoTo UpdateTrigger_Error
  
  Dim SSTemp As Recordset
  UpdateTrigger = True
  
  SetFocusTo = ""
  txtConfNum.Text = Trim(txtConfNum.Text)
  'Check for confirmation number equal to zero
  If txtConfNum.Text = "0" Or txtConfNum.Text = "" Then
     gMsg = "Confirmation number cannot be zero or blank."
     UpdateTrigger = False
     SetFocusTo = "txtConfNum"
     Exit Function
  End If
  'Conf number must exist in guesttbl
  Set SSTemp = gBNB.OpenRecordset("select conf from guesttbl where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Confirmation number must exist in General Guest Information before travel agency can be entered."
     UpdateTrigger = False
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close
  'Account number cannot be blank
  If Trim(txtAccountNum.Text) = "" Then
     gMsg = "Account Number cannot be blank. Select an agency from the dropdown list."
     UpdateTrigger = False
     SetFocusTo = "datdwComboAgency"
     Exit Function
  End If
  'Agency name cannot be blank
  If Trim(datdwComboAgency.Text) = "" Then
     gMsg = "Agency name cannot be blank. Select an agency from the dropdown list."
     UpdateTrigger = False
     SetFocusTo = "datdwComboAgency"
     Exit Function
  End If
  'Account number must exist in travel agency account table (tamaster) and
  'Agency Name entered must match the Agency Name associated with the Account Number
  datdwComboAgency.Text = Trim(datdwComboAgency.Text)
  Set SSTemp = gBNB.OpenRecordset("SELECT AccountNum,AgencyName FROM tamaster WHERE AccountNum = " & txtAccountNum.Text, dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Agency does not exist in Travel Agency Accounts. Select an agency from the dropdown list."
     UpdateTrigger = False
     SetFocusTo = "datdwComboAgency"
     SSTemp.Close
     Exit Function
  Else
     If SSTemp(1) <> datdwComboAgency.Text Then
        gMsg = "Agency Name entered is not correct for this Account Number. Select an agency from the dropdown list."
        UpdateTrigger = False
        SetFocusTo = "datdwComboAgency"
        SSTemp.Close
        Exit Function
     End If
  End If
  SSTemp.Close
  'Commission due to T/A must be filled in
  If Trim(txtCommDue.Text) = "" Then
     gMsg = "Commission due to travel agency cannot be blank. If no commission is " & _
            "due, enter 0"
     UpdateTrigger = False
     SetFocusTo = "txtCommDue"
     Exit Function
  End If
  
UpdateTrigger_Resume:
   Exit Function

UpdateTrigger_Error:
   Resume UpdateTrigger_Resume

End Function

Public Sub GetCommissionableAmt()

   On Error GoTo GetAmt_Error
   
   Dim SSTemp As Recordset
   Dim vTempSum As Currency
   
   If Trim(txtConfNum.Text) = "" Then
      lblComAmtValue.Caption = ""
      GoTo GetAmt_Resume
   End If
   Screen.MousePointer = HOURGLASS
   'Get Commissionable amount
   lblComAmtValue.Caption = ""
   'Update Suggested Commission field with sum of (GrosRate*NumNites)*GrosRatePercent
   'for each valid (non-cancel OR cancel w/ forfeit) accommodation row.
   gSQL = "select GrosRate,NumNites,GrosRatePercent " & _
          "From bbtbl INNER JOIN proptbl ON bbtbl.accountnum=proptbl.accountnum " & _
          "Where bbtbl.conf=" & txtConfNum.Text & _
          " And (bbtbl.suppress<>-1 Or (bbtbl.suppress=-1 And bbtbl.forfeit=-1))"
   Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
   GetSSRows SSTemp
   If SSTemp.RecordCount > 0 Then
      vTempSum = 0
      SSTemp.MoveFirst
      While Not SSTemp.EOF
         If Not IsNull(SSTemp("GrosRate")) And Not IsNull(SSTemp("NumNites")) And Not IsNull(SSTemp("GrosRatePercent")) Then
            vTempSum = vTempSum + (SSTemp("GrosRate") * SSTemp("NumNites") * (SSTemp("GrosRatePercent") / 100))
         End If
         SSTemp.MoveNext
      Wend
      'Update label with Commissionable amount.
      lblComAmtValue.Caption = Format(Str(vTempSum), CURRENCYFORMAT)
   Else
      lblComAmtValue.Caption = Format(Str(0), CURRENCYFORMAT)
   End If
   SSTemp.Close

GetAmt_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

GetAmt_Error:
   Resume GetAmt_Resume
       
End Sub
