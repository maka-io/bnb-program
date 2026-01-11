VERSION 5.00
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmPropertyFacts 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Property Facts"
   ClientHeight    =   4080
   ClientLeft      =   3072
   ClientTop       =   2892
   ClientWidth     =   5616
   HelpContextID   =   142
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4080
   ScaleWidth      =   5616
   Tag             =   "PropertyFacts"
   Begin VB.TextBox txtZipcode 
      Appearance      =   0  'Flat
      DataField       =   "Zipcode"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   5
      Tag             =   "Text"
      Top             =   1560
      Width           =   2835
   End
   Begin VB.TextBox txtState 
      Appearance      =   0  'Flat
      DataField       =   "State"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   4
      Tag             =   "Text"
      Top             =   1200
      Width           =   2835
   End
   Begin VB.TextBox txtCity 
      Appearance      =   0  'Flat
      DataField       =   "City"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   840
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
      Height          =   390
      Left            =   4230
      TabIndex        =   12
      Top             =   1860
      Width           =   1335
   End
   Begin VB.TextBox txtProperty 
      Appearance      =   0  'Flat
      DataField       =   "Property"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   1
      Tag             =   "Text"
      Top             =   105
      Width           =   2856
   End
   Begin VB.TextBox txtAccountNum 
      Appearance      =   0  'Flat
      DataField       =   "accountnum"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   2
      TabStop         =   0   'False
      Tag             =   "Number"
      Top             =   480
      Width           =   1275
   End
   Begin VB.TextBox txtComment 
      Appearance      =   0  'Flat
      DataField       =   "TopicDescription"
      DataSource      =   "datBrowse"
      Height          =   1050
      Left            =   60
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   7
      Tag             =   "Text"
      Top             =   2580
      Width           =   4035
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
      Height          =   390
      Left            =   4230
      TabIndex        =   17
      Top             =   3660
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
      Height          =   390
      Left            =   4230
      TabIndex        =   14
      Top             =   2760
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
      Height          =   390
      Left            =   4230
      TabIndex        =   13
      Top             =   2310
      Width           =   1335
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
      Height          =   390
      Left            =   4230
      TabIndex        =   11
      Top             =   1410
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
      Height          =   390
      Left            =   4230
      TabIndex        =   10
      Top             =   990
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
      Height          =   390
      Left            =   4230
      TabIndex        =   8
      Top             =   108
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
      Height          =   390
      Left            =   4230
      TabIndex        =   15
      Top             =   3210
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
      Height          =   390
      Left            =   4230
      TabIndex        =   9
      Top             =   540
      Width           =   1335
   End
   Begin VB.Data datFactList 
      Appearance      =   0  'Flat
      Caption         =   "datFactList"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   1944
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   4230
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
      Left            =   24
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   4230
      Visible         =   0   'False
      Width           =   1875
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "PropFact.frx":0000
      Height          =   330
      Left            =   45
      TabIndex        =   0
      Tag             =   "tagentbl"
      Top             =   3705
      Width           =   4065
      _Version        =   131075
      _ExtentX        =   7176
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
   Begin SSDataWidgets_B.SSDBCombo datdwComboAgency 
      Bindings        =   "PropFact.frx":0014
      DataField       =   "TopicName"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   6
      Tag             =   "Text"
      Top             =   1920
      Width           =   2835
      ScrollBars      =   3
      ListAutoValidate=   0   'False
      MaxDropDownItems=   20
      BevelType       =   0
      MultiLine       =   -1  'True
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
      Columns(0).Width=   3200
      _ExtentX        =   5001
      _ExtentY        =   503
      _StockProps     =   93
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
   End
   Begin VB.Label lblZipCode 
      Caption         =   "Zipcode:"
      Height          =   255
      Left            =   90
      TabIndex        =   23
      Top             =   1560
      Width           =   1125
   End
   Begin VB.Label lblState 
      Caption         =   "State:"
      Height          =   255
      Left            =   90
      TabIndex        =   22
      Top             =   1200
      Width           =   1125
   End
   Begin VB.Label lblCity 
      Caption         =   "City:"
      Height          =   255
      Left            =   90
      TabIndex        =   21
      Top             =   840
      Width           =   1125
   End
   Begin VB.Label lblProperty 
      Caption         =   "Property:"
      Height          =   255
      Left            =   90
      TabIndex        =   20
      Top             =   120
      Width           =   1095
   End
   Begin VB.Label lblAcctNum 
      Caption         =   "Account Num:"
      Height          =   255
      Left            =   90
      TabIndex        =   19
      Tag             =   "Number"
      Top             =   480
      Width           =   1125
   End
   Begin VB.Label lblComment 
      Caption         =   "Description:"
      Height          =   255
      Left            =   90
      TabIndex        =   18
      Top             =   2340
      Width           =   1050
   End
   Begin VB.Label lblAgencyName 
      Caption         =   "Topic Name:"
      Height          =   255
      Left            =   75
      TabIndex        =   16
      Top             =   1950
      Width           =   1140
   End
End
Attribute VB_Name = "frmPropertyFacts"
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
     'txtConfNum.SetFocus
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
    Dim vHoldAcctNum As Long
    Screen.MousePointer = HOURGLASS

    Select Case GetFormMode(Me)
      Case "Insert"
        vHoldAcctNum = txtAccountNum.Text
        'Check for valid dates and number formats
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmGuestTravel
        If Not InsertTrigger() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'If number formats are OK, then set currency formats
        SetToCurrencyFormat Me
        'Was problem with dropping down more than once, then committing
        datBrowse.Recordset("TopicName") = datdwComboAgency.Text
        'If new record is being added
        If datBrowse.EditMode = dbEditAdd Then
           'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
           'unbind control's DataField property and commit Null.
           RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
           datBrowse.Recordset.Update
           datBrowse.RecordSource = "select * from " & Me.Tag & " where AccountNum = " & vHoldAcctNum & " Order By TopicName"
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
           gMsg = "Delete this property fact?"
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
    gCaption = "Property Fact Listing"
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
      'txtConfNum.SetFocus
      cmdFind.Caption = "&Run Query"
   Else
      Screen.MousePointer = HOURGLASS
      cmdFind.Caption = "&Find"
      Criteria = BuildFindCriteria(Me, "TopicName")
      If Criteria <> "" Then
         datBrowse.UpdateControls
         datBrowse.RecordSource = Criteria
         Screen.MousePointer = HOURGLASS
         If Not GetDCRows(datBrowse) Then GoTo cmdFind_Click_Resume
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
      'txtConfNum.SetFocus
      'MsgBox Criteria
      datBrowse.RecordSource = Criteria
      If Not GetDCRows(datBrowse) Then GoTo cmdFind_Click_Resume
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


Private Sub cmdInsert_Click()

    On Error GoTo cmdInsert_Click_Error
    
'    If Trim(datBrowse.RecordSource) = "" Then
'       datBrowse.RecordSource = "select * from " & Me.Tag & " where AccountNum = " & frmProperty.txtAccountNum.Text & " Order By TopicName"
'       If Not GetDCRows(datBrowse) Then GoTo cmdInsert_Click_Resume
'    End If
    Dim SSTemp As Recordset
    Screen.MousePointer = HOURGLASS
    Set SSTemp = gBNB.OpenRecordset("SELECT * FROM MasterPropertyFacts", dbOpenSnapshot)
    GetSSRows SSTemp
    If Not SSTemp.RecordCount > 0 Then
       gMsg = "Property fact topics must be entered before proceeding. " & _
              "Enter fact topics through the 'Admin' > 'Property Facts Master List' " & _
              "menu selections."
       MsgBox gMsg, MB_ICONSTOP, Me.Caption
       GoTo cmdInsert_Click_Resume
       SSTemp.Close
    End If
    SSTemp.Close
    
    SetFormToInsertMode Me
    txtProperty.ForeColor = BLACK
    txtProperty.Locked = True
    txtCity.ForeColor = BLACK
    txtCity.Locked = True
    txtState.ForeColor = BLACK
    txtState.Locked = True
    txtZipcode.ForeColor = BLACK
    txtZipcode.Locked = True

    datBrowse.Recordset.AddNew
    SetZeroLengthString Me
    
    datdwComboAgency.SetFocus
    txtAccountNum.Text = frmProperty.txtAccountNum.Text
    GetPropertyName
     
cmdInsert_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdInsert_Click_Error:
   MsgBox Err.Description
   Resume cmdInsert_Click_Resume
   
End Sub

Private Sub cmdRefresh_Click()

   Screen.MousePointer = HOURGLASS
   datBrowse.RecordSource = "select * from " & Me.Tag & " Where accountnum = " & frmProperty.txtAccountNum.Text & " order by TopicName"
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
   txtProperty.ForeColor = BLACK
   txtProperty.Locked = True
   txtCity.ForeColor = BLACK
   txtCity.Locked = True
   txtState.ForeColor = BLACK
   txtState.Locked = True
   txtZipcode.ForeColor = BLACK
   txtZipcode.Locked = True

'   txtAgencyName.Enabled = False
   datBrowse.Recordset.Edit
   datdwComboAgency.SetFocus
   GetPropertyName
   
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
   
   GetPropertyName
    
datBrowse_Reposition_Resume:
  Screen.MousePointer = DEFAULT
  Exit Sub
  
datBrowse_Reposition_Error:
  Resume datBrowse_Reposition_Resume
  
End Sub

Private Sub datdwComboAgency_Change()
   
'   If UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then
'      If Trim(datdwComboAgency.Text) = "" Then txtAccountNum.Text = ""
'   End If
   
End Sub

Private Sub datdwComboAgency_Click()

  On Error GoTo datdwComboAgency_Click_Error
  
'  Dim SSTemp As Recordset
'  txtAccountNum.Text = datdwComboAgency.Columns("accountnum").CellValue(datdwComboAgency.SelBookmarks(0))

datdwComboAgency_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

datdwComboAgency_Click_Error:
    MsgBox Err.Description
    Resume datdwComboAgency_Click_Resume
     
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
        'datdwComboAgency.ListWidth = datdwComboAgency.Width
        datdwComboAgency.Columns(0).Width = datdwComboAgency.Width
        datdwComboAgency.DataFieldList = "TopicName"
   End Select
'   If Trim(datdwComboAgency.Text) <> "" Then
'      'Replace any apostrophes (') with asterik (*)
'      SelectedAgency = Replace_All_In_With("'", datdwComboAgency.Text, "*")
'      datFactList.RecordSource = "SELECT agencyname,accountnum,address,city,state,zipcode " & _
'                                   "FROM tamaster " & _
'                                   "WHERE agencyname Like '" & SelectedAgency & "*' " & _
'                                   "ORDER BY agencyname"
'   Else
      datFactList.RecordSource = "SELECT * from MasterPropertyFacts ORDER BY TopicName"
'   End If
   If Not GetDCRows(datFactList) Then Exit Sub
'   'Select the appropriate agency in the dropdown list.
'   If Trim(txtAccountNum.Text) <> "" Then
'      datdwComboAgency.ListAutoPosition = False
'      datdwComboAgency.SelBookmarks.RemoveAll
 '     datdwComboAgency.MoveFirst
 '     For j = 0 To datdwComboAgency.Rows - 1
 '        bkmrk = datdwComboAgency.Bookmark
 '        If txtAccountNum.Text = datdwComboAgency.Columns("accountnum").CellValue(bkmrk) Then
 '           'MsgBox "Found It: J=" & Str(j) & ", " & datdwComboAgency.Columns("accountnum").CellValue(bkmrk)
 '           datdwComboAgency.SelBookmarks.Add (bkmark)
 '           Exit For
 '        End If
 '        datdwComboAgency.MoveNext
 '     Next j
 '   End If
  '
datdwComboAgency_DropDown_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

datdwComboAgency_DropDown_Error:
    MsgBox Err.Description
    Resume datdwComboAgency_DropDown_Resume

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
If TimesActivated < 1 Or txtAccountNum.Text <> frmProperty.txtAccountNum.Text Then
   Screen.MousePointer = HOURGLASS
   TimesActivated = TimesActivated + 1
   datBrowse.RecordSource = "select * from " & Me.Tag & " where AccountNum = " & frmProperty.txtAccountNum.Text & " Order By TopicName"
   If Not GetDCRows(datBrowse) Then GoTo Form_Activate_Resume
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
   Else
      SetFormToBrowseMode Me
      CurrRec1 = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount
   End If
   txtProperty.SetFocus
   GetPropertyName

End If

Form_Activate_Resume:
  Screen.MousePointer = DEFAULT
  'Do this in the event of a name (first,last or both) change on frmGeneralGuest
 ' txtConfNum.SetFocus
 ' txtFirstName.SetFocus
  'txtConfNum.SetFocus
  Exit Sub
  
Form_Activate_Error:
  MsgBox Str(Err) & ", " & Err.Description
  Resume Form_Activate_Resume
  
End Sub

Private Sub Form_Load()
   
   'Screen.MousePointer = HOURGLASS
   On Error GoTo Load_Error
   
   TimesActivated = 0
   datBrowse.DatabaseName = gDatabaseName
   datFactList.DatabaseName = gDatabaseName
   datBrowse.RecordSource = "select * from " & Me.Tag & " Where AccountNum = " & frmProperty.txtAccountNum.Text & " Order By TopicName"
   CurrRec1 = 1
   SaveRec1 = 0

Load_Resume:
   Exit Sub

Load_Error:
   Resume Load_Resume
   
End Sub


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

















Public Function InsertTrigger() As Integer

  On Error GoTo InsertTrigger_Error
  
  Dim SSTemp As Recordset
  InsertTrigger = True

  SetFocusTo = ""

'  'Account number cannot be blank
'  If Trim(txtAccountNum.Text) = "" Then
'     gMsg = "Account Number cannot be blank. Select an agency from the dropdown list."
'     InsertTrigger = False
'     SetFocusTo = "datdwComboAgency"
'     Exit Function
'  End If
'  'Agency name cannot be blank
'  If Trim(datdwComboAgency.Text) = "" Then
'     gMsg = "Agency name cannot be blank. Select an agency from the dropdown list."
'     InsertTrigger = False
'     SetFocusTo = "datdwComboAgency"
'     Exit Function
'  End If
  'Topic Name must exist in MasterPropertyFacts table
  datdwComboAgency.Text = Trim(datdwComboAgency.Text)
  Set SSTemp = gBNB.OpenRecordset("SELECT TopicName FROM MasterPropertyFacts WHERE TopicName = " & Chr$(34) & datdwComboAgency.Text & Chr$(34), dbOpenSnapshot)
  GetSSRows SSTemp
  If Not SSTemp.RecordCount > 0 Then
     gMsg = "Topic Name is incorrect. Select a Topic Name from the dropdown list."
     InsertTrigger = False
     SetFocusTo = "datdwComboAgency"
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close


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




Public Function UpdateTrigger() As Integer

  On Error GoTo UpdateTrigger_Error
  
  Dim SSTemp As Recordset
  UpdateTrigger = True
  
  SetFocusTo = ""

  'Topic Name must exist in MasterPropertyFacts table
  datdwComboAgency.Text = Trim(datdwComboAgency.Text)
  Set SSTemp = gBNB.OpenRecordset("SELECT TopicName FROM MasterPropertyFacts WHERE TopicName = " & Chr$(34) & datdwComboAgency.Text & Chr$(34), dbOpenSnapshot)
  GetSSRows SSTemp
  If Not SSTemp.RecordCount > 0 Then
     gMsg = "Topic Name is incorrect. Select a Topic Name from the dropdown list."
     UpdateTrigger = False
     SetFocusTo = "datdwComboAgency"
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close
  
UpdateTrigger_Resume:
   Exit Function

UpdateTrigger_Error:
   Resume UpdateTrigger_Resume

End Function


Public Sub GetPropertyName()

    On Error GoTo GetPropertyName_Error
    
    Dim SSTemp As Recordset
    
   ' If UCase(GetFormMode(Me)) = "BROWSE" And Trim(txtAccountNum.Text) <> "" Then
       Screen.MousePointer = HOURGLASS
       Set SSTemp = gBNB.OpenRecordset("SELECT location,propcity,propstate,propzipcode FROM proptbl WHERE AccountNum = " & Trim(txtAccountNum.Text), dbOpenSnapshot)
       GetSSRows SSTemp
       If SSTemp.RecordCount > 0 Then
          txtProperty.Text = SSTemp(0)
          txtCity.Text = SSTemp(1)
          txtState.Text = SSTemp(2)
          txtZipcode.Text = SSTemp(3)
       Else
          txtProperty.Text = ""
          txtCity.Text = ""
          txtState.Text = ""
          txtZipcode.Text = ""
       End If
       SSTemp.Close
   ' End If
    
GetPropertyName_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
GetPropertyName_Error:
   Resume GetPropertyName_Resume
    
End Sub

