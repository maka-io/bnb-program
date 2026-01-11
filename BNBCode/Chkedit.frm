VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmCheckEdit 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Printed Checks"
   ClientHeight    =   5100
   ClientLeft      =   48
   ClientTop       =   336
   ClientWidth     =   5760
   HelpContextID   =   130
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   ScaleHeight     =   5100
   ScaleWidth      =   5760
   Tag             =   "checktbl"
   Begin Threed.SSCheck chkVoid 
      DataField       =   "void_chk"
      DataSource      =   "datBrowse"
      Height          =   255
      Left            =   1200
      TabIndex        =   9
      Top             =   3030
      Width           =   435
      _Version        =   65536
      _ExtentX        =   767
      _ExtentY        =   450
      _StockProps     =   78
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
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
      Height          =   615
      Left            =   4260
      TabIndex        =   17
      Top             =   4440
      Width           =   1455
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "Chkedit.frx":0000
      Height          =   390
      Left            =   120
      TabIndex        =   0
      Top             =   4680
      Width           =   3960
      _Version        =   131075
      _ExtentX        =   6985
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
      Height          =   360
      Left            =   240
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   5220
      Visible         =   0   'False
      Width           =   2295
   End
   Begin VB.TextBox txtComments 
      Appearance      =   0  'Flat
      DataField       =   "comments"
      DataSource      =   "datBrowse"
      Height          =   1005
      Left            =   120
      MaxLength       =   255
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   10
      Tag             =   "Text"
      Top             =   3570
      Width           =   3915
   End
   Begin VB.TextBox txtAccountNum 
      Appearance      =   0  'Flat
      DataField       =   "accountnum"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      TabIndex        =   8
      Tag             =   "Number"
      Top             =   2640
      Width           =   2835
   End
   Begin VB.TextBox txtPrintTo 
      Appearance      =   0  'Flat
      DataField       =   "print_to"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      TabIndex        =   7
      Tag             =   "Text"
      Top             =   2280
      Width           =   2835
   End
   Begin VB.TextBox txtCheckDate 
      Appearance      =   0  'Flat
      DataField       =   "chk_date"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      TabIndex        =   6
      Tag             =   "Date"
      Top             =   1920
      Width           =   2835
   End
   Begin VB.TextBox txtCheckNum 
      Appearance      =   0  'Flat
      DataField       =   "checknum"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      TabIndex        =   5
      Tag             =   "Number"
      Top             =   1560
      Width           =   2835
   End
   Begin VB.TextBox txtCheckAmt 
      Appearance      =   0  'Flat
      DataField       =   "trueamt"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      TabIndex        =   4
      Tag             =   "Currency"
      Top             =   1200
      Width           =   2835
   End
   Begin VB.TextBox txtCategory 
      Appearance      =   0  'Flat
      DataField       =   "CheckCategory"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   840
      Width           =   2835
   End
   Begin VB.TextBox txtLastName 
      Appearance      =   0  'Flat
      DataField       =   "l_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      TabIndex        =   2
      Tag             =   "Text"
      Top             =   480
      Width           =   2835
   End
   Begin VB.TextBox txtConfNum 
      Appearance      =   0  'Flat
      DataField       =   "conf"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      TabIndex        =   1
      Tag             =   "Number"
      Top             =   120
      Width           =   2835
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
      Height          =   615
      Left            =   4260
      TabIndex        =   16
      Top             =   3720
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
      Height          =   615
      Left            =   4260
      TabIndex        =   15
      Top             =   3000
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
      Height          =   615
      Left            =   4260
      TabIndex        =   14
      Top             =   2280
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
      Height          =   615
      Left            =   4260
      TabIndex        =   13
      Top             =   1560
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
      Height          =   615
      Left            =   4260
      TabIndex        =   12
      Top             =   840
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
      Height          =   615
      Left            =   4260
      TabIndex        =   11
      Top             =   120
      Width           =   1455
   End
   Begin VB.Label lblVoid 
      Caption         =   "Void Check:"
      Height          =   195
      Left            =   120
      TabIndex        =   27
      Top             =   3060
      Width           =   1035
   End
   Begin VB.Label lblComments 
      Caption         =   "Memo:"
      Height          =   195
      Left            =   120
      TabIndex        =   26
      Top             =   3390
      Width           =   975
   End
   Begin VB.Label lblAcctNum 
      Caption         =   "Account Num:"
      Height          =   195
      Left            =   120
      TabIndex        =   25
      Top             =   2700
      Width           =   1095
   End
   Begin VB.Label lblPrintTo 
      Caption         =   "Payee:"
      Height          =   195
      Left            =   120
      TabIndex        =   24
      Top             =   2340
      Width           =   975
   End
   Begin VB.Label lblCheckDate 
      Caption         =   "Print Date:"
      Height          =   195
      Left            =   120
      TabIndex        =   23
      Top             =   1980
      Width           =   1095
   End
   Begin VB.Label lblCheckNum 
      Caption         =   "Check Num:"
      Height          =   195
      Left            =   120
      TabIndex        =   22
      Top             =   1620
      Width           =   975
   End
   Begin VB.Label lblCheckAmt 
      Caption         =   "Amount:"
      Height          =   195
      Left            =   120
      TabIndex        =   21
      Top             =   1260
      Width           =   975
   End
   Begin VB.Label lblCategory 
      Caption         =   "Category:"
      Height          =   195
      Left            =   120
      TabIndex        =   20
      Top             =   900
      Width           =   975
   End
   Begin VB.Label lblLastName 
      Caption         =   "Last Name:"
      Height          =   195
      Left            =   120
      TabIndex        =   19
      Top             =   540
      Width           =   975
   End
   Begin VB.Label lblConf 
      Caption         =   "Conf Number:"
      Height          =   195
      Left            =   120
      TabIndex        =   18
      Top             =   180
      Width           =   975
   End
End
Attribute VB_Name = "frmCheckEdit"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim i As Integer
Dim TimesActivated As Integer
Dim CurrRec As Long
Dim SaveRec As Long
Dim NullDateArray()
Dim FailedLostFocus As Integer
Dim SetFocusTo As String
Dim OrigVoidCheck As Integer


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
           'datBrowse.Recordset.Bookmark = datBrowse.Recordset.LastModified
           datBrowse.UpdateControls
           'If check was voided, update all records that check number was tied to.
           If OrigVoidCheck <> chkVoid.Value And Not IsNull(datBrowse.Recordset("checknum").Value) Then
              gBNB.Execute "update checktbl set void_chk = " & datBrowse.Recordset("void_chk").Value & _
                           " where checknum = " & datBrowse.Recordset("checknum").Value & _
                           " And chk_date = #" & datBrowse.Recordset("chk_date").Value & "#"
           End If
        End If
        SetToCurrencyFormat Me
      Case "Delete"
           gMsg = "Delete this row from Check Ledger?"
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
    gCaption = "Check Listing"
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
         'MsgBox Criteria
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
   
   SetFormToUpdateMode Me
   datBrowse.Recordset.Edit
   OrigVoidCheck = chkVoid.Value
   
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
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
   Else
      SetFormToBrowseMode Me
      CurrRec = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
   End If
End If

Form_Activate_Resume:
   txtConfNum.SetFocus
   Screen.MousePointer = DEFAULT
   Exit Sub
  
Form_Activate_Error:
   Resume Form_Activate_Resume

End Sub

Private Sub Form_Load()
   
   TimesActivated = 0
   datBrowse.DatabaseName = gDatabaseName
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = 0"
   CurrRec = 1
   SaveRec = 0
   
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

