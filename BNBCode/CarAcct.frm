VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmCarAccount 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Car Rental Agency Accounts"
   ClientHeight    =   5904
   ClientLeft      =   1656
   ClientTop       =   1860
   ClientWidth     =   5640
   HelpContextID   =   110
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   5904
   ScaleWidth      =   5640
   Tag             =   "carmaster"
   Begin VB.Frame Frame1 
      Caption         =   "Commission Due From Rental Agency"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   840
      Left            =   72
      TabIndex        =   0
      Top             =   4104
      Width           =   3936
      Begin VB.TextBox txtCommPercent 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         DataField       =   "CommPercent"
         DataSource      =   "datBrowse"
         Height          =   288
         Left            =   1188
         TabIndex        =   11
         Tag             =   "Number"
         Top             =   324
         Width           =   735
      End
      Begin VB.Label lblLabel2 
         Caption         =   "%"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Left            =   1920
         TabIndex        =   34
         Top             =   360
         Width           =   225
      End
      Begin VB.Label lblLabel1 
         Caption         =   "Percentage:"
         Height          =   264
         Left            =   144
         TabIndex        =   33
         Top             =   360
         Width           =   1020
      End
   End
   Begin VB.TextBox txtFindSQL 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   3168
      TabIndex        =   32
      Tag             =   "Text"
      Top             =   5076
      Visible         =   0   'False
      Width           =   870
   End
   Begin VB.CommandButton cmdLabels 
      Caption         =   "Print &Labels"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   540
      Left            =   4284
      TabIndex        =   20
      Top             =   4176
      Width           =   1335
   End
   Begin VB.TextBox txtComments 
      Appearance      =   0  'Flat
      DataField       =   "comments"
      DataSource      =   "datBrowse"
      Height          =   732
      Left            =   60
      ScrollBars      =   2  'Vertical
      TabIndex        =   10
      Tag             =   "Text"
      Top             =   3240
      Width           =   3975
   End
   Begin VB.TextBox txtFax 
      Appearance      =   0  'Flat
      DataField       =   "fax"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      MaxLength       =   50
      TabIndex        =   9
      Tag             =   "Text"
      Top             =   2640
      Width           =   2835
   End
   Begin VB.TextBox txtPhone 
      Appearance      =   0  'Flat
      DataField       =   "phone"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      MaxLength       =   50
      TabIndex        =   8
      Tag             =   "Text"
      Top             =   2280
      Width           =   2835
   End
   Begin VB.CommandButton cmdRefresh 
      Caption         =   "R&efresh"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   540
      Left            =   4284
      TabIndex        =   17
      Top             =   2448
      Width           =   1335
   End
   Begin VB.TextBox txtZipcode 
      Appearance      =   0  'Flat
      DataField       =   "zipcode"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      MaxLength       =   30
      TabIndex        =   7
      Tag             =   "Text"
      Top             =   1920
      Width           =   2835
   End
   Begin VB.TextBox txtState 
      Appearance      =   0  'Flat
      DataField       =   "state"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      MaxLength       =   30
      TabIndex        =   6
      Tag             =   "Text"
      Top             =   1560
      Width           =   2835
   End
   Begin VB.TextBox txtCity 
      Appearance      =   0  'Flat
      DataField       =   "city"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      MaxLength       =   30
      TabIndex        =   5
      Tag             =   "Text"
      Top             =   1200
      Width           =   2835
   End
   Begin VB.TextBox txtAddress 
      Appearance      =   0  'Flat
      DataField       =   "address"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      MaxLength       =   50
      TabIndex        =   4
      Tag             =   "Text"
      Top             =   840
      Width           =   2835
   End
   Begin VB.TextBox txtAgencyName 
      Appearance      =   0  'Flat
      DataField       =   "agencyname"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      MaxLength       =   50
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   480
      Width           =   2835
   End
   Begin VB.TextBox txtAccountNum 
      Appearance      =   0  'Flat
      DataField       =   "accountnum"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1200
      TabIndex        =   2
      Tag             =   "Number"
      Top             =   120
      Width           =   1575
   End
   Begin VB.Data datDropListing 
      Appearance      =   0  'Flat
      Caption         =   "datDropListing"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   2184
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   6048
      Visible         =   0   'False
      Width           =   1875
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
      Left            =   264
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   6048
      Visible         =   0   'False
      Width           =   1875
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
      Height          =   540
      Left            =   4284
      TabIndex        =   22
      Top             =   5328
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
      Height          =   540
      Left            =   4284
      TabIndex        =   21
      Top             =   4752
      Width           =   1335
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
      Height          =   540
      Left            =   4284
      TabIndex        =   19
      Top             =   3600
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
      Height          =   540
      Left            =   4284
      TabIndex        =   18
      Top             =   3024
      Width           =   1335
   End
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
      Height          =   540
      Left            =   4284
      TabIndex        =   16
      Top             =   1872
      Width           =   1332
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
      Height          =   540
      Left            =   4284
      TabIndex        =   15
      Top             =   1296
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
      Height          =   540
      Left            =   4284
      TabIndex        =   14
      Top             =   720
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
      Height          =   540
      Left            =   4284
      TabIndex        =   13
      Top             =   144
      Width           =   1335
   End
   Begin Threed.SSCheck chkSuppress 
      DataField       =   "suppress"
      DataSource      =   "datBrowse"
      Height          =   228
      Left            =   72
      TabIndex        =   12
      Top             =   5088
      Width           =   2772
      _Version        =   65536
      _ExtentX        =   4895
      _ExtentY        =   397
      _StockProps     =   78
      Caption         =   "Suppress from mailing labels"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   7.7
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "CarAcct.frx":0000
      Height          =   336
      Left            =   72
      TabIndex        =   1
      Top             =   5544
      Width           =   4020
      _Version        =   131075
      _ExtentX        =   7091
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
   Begin VB.Label lblComment 
      Caption         =   "Blind Comment:"
      Height          =   192
      Left            =   60
      TabIndex        =   31
      Top             =   3048
      Width           =   1332
   End
   Begin VB.Label lblFax 
      Caption         =   "Fax:"
      Height          =   255
      Left            =   60
      TabIndex        =   30
      Top             =   2670
      Width           =   1095
   End
   Begin VB.Label lblPhone 
      Caption         =   "Phone:"
      Height          =   255
      Left            =   60
      TabIndex        =   29
      Top             =   2310
      Width           =   1095
   End
   Begin VB.Label lblZipCode 
      Caption         =   "Zipcode:"
      Height          =   255
      Left            =   60
      TabIndex        =   28
      Top             =   1950
      Width           =   1095
   End
   Begin VB.Label lblState 
      Caption         =   "State:"
      Height          =   255
      Left            =   60
      TabIndex        =   27
      Top             =   1590
      Width           =   1095
   End
   Begin VB.Label lblCity 
      Caption         =   "City:"
      Height          =   255
      Left            =   60
      TabIndex        =   26
      Top             =   1230
      Width           =   1095
   End
   Begin VB.Label lblAddress 
      Caption         =   "Address:"
      Height          =   255
      Left            =   60
      TabIndex        =   25
      Top             =   870
      Width           =   1095
   End
   Begin VB.Label lblAgencyName 
      Caption         =   "Agency Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   24
      Top             =   510
      Width           =   1095
   End
   Begin VB.Label lblAccountNum 
      Caption         =   "Account Num:"
      Height          =   255
      Left            =   60
      TabIndex        =   23
      Top             =   150
      Width           =   1095
   End
End
Attribute VB_Name = "frmCarAccount"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
'CurrRec holds the number of the current record displayed on the screen
Dim CurrRec As Long
Dim SaveRec As Long
Dim v_AccountNum As Long
Dim SetFocusTo As String

Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error
   
   Select Case GetFormMode(Me)
     Case "Insert"
        If datBrowse.Recordset.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
        'MsgBox Str$(v_AccountNum)
        gBNB.Execute "delete * from CarAgencyInsertControl where accountnum = " & v_AccountNum & " and ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
     Case "Update"
        If datBrowse.Recordset.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
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
     CurrRec = GetCurrentRowNumber(datBrowse)
     datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
     txtAccountNum.SetFocus
   End If
   
cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume

End Sub


Private Sub cmdCommit_Click()
    
    On Error GoTo cmdCommit_Click_Error
    
    Dim TempVal As Variant
    Dim TempSS As Recordset
    
    Screen.MousePointer = HOURGLASS

    Select Case GetFormMode(Me)
      Case "Insert"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmCarAccount
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
        SetToCurrencyFormat Me
        'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
        'unbind control's DataField property and commit Null.
        TempVal = Trim$(txtAccountNum.Text)
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        datBrowse.RecordSource = "select * from " & Me.Tag & " where AccountNum = " & CLng(TempVal)
        If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        'If successful update, update the HostInsertControl table
        gBNB.Execute "delete * from CarAgencyInsertControl where AccountNum = " & CLng(TempVal)
        SetToCurrencyFormat Me
        'If Not datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then datBrowse.Recordset.MoveLast
      Case "Update"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmProperty
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
        SetToCurrencyFormat Me
        'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
        'unbind control's DataField property and commit Null.
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        datBrowse.Recordset.Bookmark = datBrowse.Recordset.LastModified
        SetToCurrencyFormat Me
        'Make the current record current again
        'datBrowse.UpdateControls
      Case "Delete"
        'Cannot delete if Rental Agency AccountNum exists in Guest Car (cartbl).
        gSQL = "SELECT COUNT(AccountNum) FROM cartbl WHERE AccountNum = " & txtAccountNum.Text
        Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
        GetSSRows TempSS
        If TempSS(0) > 0 And Not IsNull(TempSS(0)) Then
           MsgBox "This car rental agency account number is currently linked to guest reservations and cannot be deleted.", MB_ICONSTOP, Me.Caption
           TempSS.Close
           GoTo cmdCommit_Click_Resume
        End If
        TempSS.Close
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
    gCaption = "Car Rental Agency Account Listing"
    gSQL = datBrowse.RecordSource
    'frmBoundListing.Show
    Dim frmNewBoundListing As New frmBoundListing  ' Declare form variable
    frmNewBoundListing.Show     ' Load and display new instance
   ' frmNewBoundListing.txtSQLStatement.Tag = "Write Enabled"
   ' 'Set the HelpContextID for the form ( The F1 Help File Jump ).
   ' frmNewBoundListing.HelpContextID = 410
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
      Criteria = BuildFindCriteria(Me, "agencyname")
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
   txtAccountNum.SetFocus

cmdFind_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

cmdFind_Click_Error:
    MsgBox Err.Description
    Resume cmdFind_Click_Resume

End Sub

Private Sub cmdInsert_Click()

    On Error GoTo cmdInsert_Click_Error
    
    Screen.MousePointer = HOURGLASS
    SetFormToInsertMode Me
    If Trim(datBrowse.RecordSource) = "" Then
       datBrowse.RecordSource = "select * from " & Me.Tag & " order by agencyname"
       If Not GetDCRows(datBrowse) Then GoTo cmdInsert_Click_Resume
    End If
    datBrowse.Recordset.AddNew
    SetZeroLengthString Me
    'Control for Multi-user inserts.
    'Use a accountnum control table containing all attempted row inserts.
    'Get next accountnum
    Dim MaxRS As Recordset  'Maximum accountnum from actual data table (proptbl)
    Dim ControlRS As Recordset  'accountnum numbers from CarAgencyInsertControl table.
    Dim MaxAccountNumPlusOne As Long
    Dim MinControlRS As Long
    txtAccountNum.Locked = True
    txtAccountNum.ForeColor = BLACK
    'Get highest accountnum from proptbl and put it in MaxRS.
    'The following line is for testing when no rows in proptbl yet.
    'Set MaxRS = gBNB.OpenRecordset("select accountnum from " & Me.Tag & " where accountnum in(select max(accountnum) from " & Me.Tag & " where accountnum = 0)", dbOpenSnapshot)
    Set MaxRS = gBNB.OpenRecordset("select accountnum from " & Me.Tag & " where accountnum in(select max(alias_1.accountnum) from " & Me.Tag & " AS alias_1)", dbOpenSnapshot)
    GetSSRows MaxRS
    'The ONLY purpose of the CarAgencyInsertControl table is to get new rows into proptbl.
    'Any accountnum numbers already in proptbl have no reason to be in the CarAgencyInsertControl table.
    'This case could happen due to a power outage (or other abnormal termination) AFTER
    'insert of accountnum into proptbl but BEFORE that accountnum's removal from
    'CarAgencyInsertControl table. As such, remove invalid rows from CarAgencyInsertControl to prevent any
    'possible buildup of old accountnum numbers in CarAgencyInsertControl. Removed accountnum will never
    'be used in the database.
    If Not MaxRS.EOF Then gBNB.Execute "delete from CarAgencyInsertControl where accountnum < " & (MaxRS(0) + 1)
    'Get all accountnum numbers currently in CarAgencyInsertControl table.
    Set ControlRS = gBNB.OpenRecordset("select accountnum,ComputerName from CarAgencyInsertControl order by accountnum ASC", dbOpenDynaset)
    'Make SURE we're at beginning.
    GetSSRows ControlRS
    If Not ControlRS.BOF And Not ControlRS.EOF Then
       MinControlRS = ControlRS("accountnum")
    Else  'No rows in CarAgencyInsertControl table.
       MinControlRS = 0
    End If
    If MaxRS.BOF And MaxRS.EOF Then  'No rows exist in proptbl yet.
       'MsgBox "Null"
       MaxAccountNumPlusOne = 1
    Else
       MaxAccountNumPlusOne = (MaxRS("accountnum") + 1)
    End If
    MaxRS.Close
    If (ControlRS.BOF And ControlRS.EOF) Then  'No rows in CarAgencyInsertControl table.
       GoSub Insert_Control
    ElseIf MaxAccountNumPlusOne < MinControlRS Then  'accountnum to be inserted is less than all rows in CarAgencyInsertControl.
       GoSub Insert_Control
    ElseIf MaxAccountNumPlusOne >= MinControlRS Then
       'Equal or greater. Move through recordset to find next available
       'accountnum to insert.
       Dim Done As Integer
       Done = False
       For i = 0 To ControlRS.RecordCount - 1
          If MaxAccountNumPlusOne < (ControlRS("accountnum") - i) Then
            v_AccountNum = (MaxAccountNumPlusOne + i)
            ControlRS.AddNew
            ControlRS("accountnum") = (MaxAccountNumPlusOne + i)
            ControlRS("ComputerName") = gComputerName
            ControlRS.Update
            'v_AccountNum = (MaxAccountNumPlusOne + i)
            Done = True
            Exit For
          End If
          ControlRS.MoveNext
       Next i
       'accountnum to be inserted into CarAgencyInsertControl table will be
       'greater than any of those already existing in the table.
       If Not Done Then
          v_AccountNum = (MaxAccountNumPlusOne + i)
          ControlRS.AddNew
          ControlRS("accountnum") = (MaxAccountNumPlusOne + i)
          ControlRS("ComputerName") = gComputerName
          ControlRS.Update
          'v_AccountNum = (MaxAccountNumPlusOne + i)
       End If
    Else
       'All cases have been accounted for.
    End If
    ControlRS.Close
    txtAccountNum.Text = Trim$(v_AccountNum)
    txtAccountNum.Locked = True
    txtAccountNum.ForeColor = BLACK
    txtAgencyName.SetFocus
    'txtDateBooked.Text = Format$(Now, "m/d/yyyy")
    
cmdInsert_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub
    
Insert_Control:
      v_AccountNum = MaxAccountNumPlusOne
      ControlRS.AddNew
      ControlRS("AccountNum") = MaxAccountNumPlusOne
      ControlRS("ComputerName") = gComputerName
      'v_AccountNum = MaxAccountNumPlusOne
      ControlRS.Update
      Return
      
cmdInsert_Click_Error:
   If Err.Number = 3022 Then
      gMsg = "Another user is attempting to enter a row simultaneously. Retry by clicking the Cancel button, then the Insert button."
      MsgBox gMsg, MB_ICONSTOP, Me.Caption
   Else
      MsgBox Err.Description
   End If
   Resume cmdInsert_Click_Resume
   
End Sub

Private Sub cmdLabels_Click()
   
   On Error GoTo cmdLabels_Click_Error
   txtFindSQL.Text = datBrowse.RecordSource
   gSQL = "select " & Chr$(34) & gComputerName & Chr$(34) & ",'','',agencyname,address,city,state,zipcode "
   'Remove SELECT * from query and just get rows of interest
   txtFindSQL.Text = Replace_All_In_With("select * ", txtFindSQL.Text, gSQL)
   'Remove Order By clause
   If InStr(1, txtFindSQL.Text, "Order By", 1) > 0 Then
      txtFindSQL.Text = Left(txtFindSQL.Text, InStr(1, txtFindSQL.Text, "Order By", 1) - 1)
   End If
   'Append more criteria to prevent non-mailable and Suppressed labels from being printed
   If InStr(1, txtFindSQL.Text, "where", 1) > 0 Then
      txtFindSQL.Text = txtFindSQL.Text & " And address <> '' And suppress <> -1 And suppress <> 1 "
   Else
      txtFindSQL.Text = txtFindSQL.Text & " Where address <> '' And suppress <> -1 And suppress <> 1 "
   End If
   
   LabelCallingForm = "frmCarAccount"
   frmLabelDialog.Show 1
   DoEvents
   If Not FormLoaded(frmLabelDialog) Then Exit Sub
   Screen.MousePointer = HOURGLASS
   Dim i As Integer
   'Clear out temp table
   gBNB.Execute "delete from LabelSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   If frmLabelDialog.chkMultiLabel.Value = CHECKED Then
      If chkSuppress.Value = CHECKED Then
         gMsg = "The 'Suppress from mailing labels' box is checked. Do you want to print labels anyway?"
         If MsgBox(gMsg, MB_ICONQUESTION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then GoTo cmdLabels_Click_Resume
      End If
      For i = 1 To CInt(frmLabelDialog.txtNumLabels.Text)
         gSQL = "insert into LabelSupport (ComputerName,f_name,l_name,Company,Address," & _
                "City,State,Zipcode) " & _
                "SELECT " & Chr$(34) & gComputerName & Chr$(34) & ",'" & _
                "','" & _
                "','" & _
                datBrowse.Recordset("agencyname") & "','" & _
                datBrowse.Recordset("address") & "','" & _
                datBrowse.Recordset("city") & "','" & _
                datBrowse.Recordset("state") & "','" & _
                datBrowse.Recordset("zipcode") & "'"
                'MsgBox gSQL
         gBNB.Execute gSQL
      Next i
   'pc
   Else
      gBNB.Execute "insert into LabelSupport (ComputerName,f_name,l_name,Company,Address,City,State,Zipcode) " & txtFindSQL.Text
   End If
   'Use Crystal OCX attached to the main form so we don't need to load another one.
   If frmLabelDialog.txtComboFormat.Text Like "*Laser*" Then
      'Laser printer 3-column labels
      mdiBNB.Report1.ReportFileName = gDBDirectory & "Label1.rpt"
   Else
      'Dot-matrix Single column labels
      mdiBNB.Report1.ReportFileName = gDBDirectory & "Label2.rpt"
   End If
   mdiBNB.Report1.SelectionFormula = "{LabelSupport.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(mdiBNB.Report1.SortFields(vCount)) <> ""
     mdiBNB.Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   For i = 0 To frmLabelDialog.lstSortOrder.ListCount - 1
      Select Case frmLabelDialog.lstSortOrder.List(i)
        Case "Rental Agency Name"
           mdiBNB.Report1.SortFields(i) = "+{LabelSupport.Company}"
        Case "Address"
           mdiBNB.Report1.SortFields(i) = "+{LabelSupport.Address}"
        Case "City"
           mdiBNB.Report1.SortFields(i) = "+{LabelSupport.City}"
        Case "State"
           mdiBNB.Report1.SortFields(i) = "+{LabelSupport.State}"
        Case "Zipcode"
           mdiBNB.Report1.SortFields(i) = "+{LabelSupport.Zipcode}"
        Case Else
           '
      End Select
   Next i
   If FormLoaded(frmLabelDialog) Then Unload frmLabelDialog
   mdiBNB.Report1.Destination = 0
   mdiBNB.Report1.Action = 1
   'Clear out support table
   gBNB.Execute "delete from LabelSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   
cmdLabels_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdLabels_Click_Error:
   Resume cmdLabels_Click_Resume
   
End Sub

Private Sub cmdRefresh_Click()

   Screen.MousePointer = HOURGLASS
   datBrowse.RecordSource = "select * from " & Me.Tag & " order by agencyname"
   If Not GetDCRows(datBrowse) Then Exit Sub
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
   Else
      SetFormToBrowseMode Me
      CurrRec = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
   End If
   Screen.MousePointer = DEFAULT

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
    Resume cmdUpdate_Click_Resume
    
End Sub

Private Sub datdwData1_Click(ByVal nPosition As Integer)
    
    On Error GoTo datdwData1_Click_Error

    Screen.MousePointer = HOURGLASS
    Me.SetFocus
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
        SaveRec = CurrRec
    'case5: goto saved bookmark
    ElseIf nPosition = 18 Then
        If SaveRec > 0 Then CurrRec = SaveRec
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

If TimesActivated < 1 Then
   Screen.MousePointer = HOURGLASS
   TimesActivated = TimesActivated + 1
   gDropSource = ""
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
   txtAccountNum.SetFocus
   Screen.MousePointer = DEFAULT
   Exit Sub
  
Form_Activate_Error:
   Resume Form_Activate_Resume
  
End Sub

Private Sub Form_Load()
   
   TimesActivated = 0
   
   datBrowse.DatabaseName = gDatabaseName
   datBrowse.RecordSource = "select * from " & Me.Tag & " order by agencyname"
   
   datDropListing.DatabaseName = gDatabaseName
   datDropListing.RecordSource = ""
   
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

Public Function InsertTrigger() As Integer

  On Error GoTo InsertTrigger_Error
  
  Dim SSTemp As Recordset
  
  InsertTrigger = True
  SetFocusTo = ""
  txtAgencyName.Text = Trim(txtAgencyName.Text)
  'Account num cannot be blank
  If txtAccountNum.Text = "0" Or txtAccountNum.Text = "" Then
     gMsg = "Account number cannot be zero or blank."
     SetFocusTo = "txtAccountNum"
     InsertTrigger = False
     Exit Function
  End If
  If Trim(txtAgencyName.Text) = "" Then
     gMsg = "Agency Name must be entered."
     InsertTrigger = False
     SetFocusTo = "txtAgencyName"
     Exit Function
  End If
  'Percentage to Host must be filled in
  If txtCommPercent.Text = "" Then
     gMsg = "The percentage (of the total commissionable amount) payable by the " & _
            "rental agency must be filled in."
     InsertTrigger = False
     SetFocusTo = "txtCommPercent"
     Exit Function
  ElseIf Not IsNumeric(txtCommPercent.Text) Then
     gMsg = "The percentage must be numeric between 0 and 100."
     InsertTrigger = False
     SetFocusTo = "txtCommPercent"
     Exit Function
  ElseIf Not (CDbl(txtCommPercent.Text) >= 0 And CDbl(txtCommPercent.Text) <= 100) Then
     gMsg = "The percentage must be numeric between 0 and 100."
     InsertTrigger = False
     SetFocusTo = "txtCommPercent"
     Exit Function
  End If

InsertTrigger_Resume:
   Exit Function
   
InsertTrigger_Error:
   Resume InsertTrigger_Resume
    
End Function

Public Function UpdateTrigger() As Integer

  On Error GoTo UpdateTrigger_Error
  
  UpdateTrigger = True
  SetFocusTo = ""
  txtAgencyName.Text = Trim(txtAgencyName.Text)
  txtCommPercent.Text = Trim(txtCommPercent.Text)
  'Percentage to Host must be filled in
  If txtCommPercent.Text = "" Then
     gMsg = "The percentage (of the total commissionable amount) payable by the " & _
            "rental agency must be filled in."
     UpdateTrigger = False
     SetFocusTo = "txtCommPercent"
     Exit Function
  ElseIf Not IsNumeric(txtCommPercent.Text) Then
     gMsg = "The percentage must be numeric between 0 and 100."
     UpdateTrigger = False
     SetFocusTo = "txtCommPercent"
     Exit Function
  ElseIf Not (CDbl(txtCommPercent.Text) >= 0 And CDbl(txtCommPercent.Text) <= 100) Then
     gMsg = "The percentage must be numeric between 0 and 100."
     UpdateTrigger = False
     SetFocusTo = "txtCommPercent"
     Exit Function
  End If
   
UpdateTrigger_Resume:
   Exit Function

UpdateTrigger_Error:
   Resume UpdateTrigger_Resume
    
End Function

Private Sub Form_Unload(Cancel As Integer)
   Screen.MousePointer = HOURGLASS
   'Clear out temp table
 '  gBNB.Execute "delete from LabelSupport where ComputerName = '" & gComputerName & "'"
   Screen.MousePointer = DEFAULT
End Sub



