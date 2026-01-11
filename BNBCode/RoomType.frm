VERSION 5.00
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmRoomType 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Room Types"
   ClientHeight    =   3228
   ClientLeft      =   1656
   ClientTop       =   1860
   ClientWidth     =   4992
   HelpContextID   =   140
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   3228
   ScaleWidth      =   4992
   Tag             =   "HostAccount_RoomType_Link"
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
      Height          =   345
      Left            =   3600
      TabIndex        =   6
      Top             =   1680
      Width           =   1335
   End
   Begin VB.TextBox txtRoomTypeDesc 
      Appearance      =   0  'Flat
      DataField       =   "RoomType_Desc"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   120
      MaxLength       =   50
      TabIndex        =   1
      Tag             =   "Text"
      Top             =   1830
      Width           =   3315
   End
   Begin VB.TextBox txtRoomType 
      Appearance      =   0  'Flat
      DataField       =   "RoomType"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   120
      MaxLength       =   50
      TabIndex        =   11
      TabStop         =   0   'False
      Tag             =   "Number"
      Top             =   1110
      Width           =   1935
   End
   Begin VB.TextBox txtAccountNum 
      Appearance      =   0  'Flat
      DataField       =   "AccountNum"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   120
      TabIndex        =   10
      TabStop         =   0   'False
      Tag             =   "Number"
      Top             =   390
      Width           =   1935
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
      Left            =   120
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   3330
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
      Height          =   345
      Left            =   3600
      TabIndex        =   9
      Top             =   2850
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
      Height          =   345
      Left            =   3600
      TabIndex        =   8
      Top             =   2460
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
      Height          =   345
      Left            =   2760
      TabIndex        =   12
      Top             =   2460
      Visible         =   0   'False
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
      Height          =   345
      Left            =   3600
      TabIndex        =   7
      Top             =   2070
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
      Height          =   345
      Left            =   3600
      TabIndex        =   5
      Top             =   1290
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
      Height          =   345
      Left            =   3600
      TabIndex        =   4
      Top             =   900
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
      Height          =   345
      Left            =   3600
      TabIndex        =   3
      Top             =   510
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
      Height          =   345
      Left            =   3600
      TabIndex        =   2
      Top             =   120
      Width           =   1335
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "RoomType.frx":0000
      Height          =   330
      Left            =   120
      TabIndex        =   0
      Top             =   2880
      Width           =   3315
      _Version        =   131075
      _ExtentX        =   5842
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
   Begin VB.Label lblRoomTypeDesc 
      Caption         =   "Room Type Description:"
      Height          =   255
      Left            =   120
      TabIndex        =   15
      Top             =   1560
      Width           =   2235
   End
   Begin VB.Label lblRoomType 
      Caption         =   "Room Type ID:"
      Height          =   255
      Left            =   120
      TabIndex        =   14
      Top             =   840
      Width           =   1215
   End
   Begin VB.Label lblAccountNum 
      Caption         =   "Property Account Num:"
      Height          =   255
      Left            =   120
      TabIndex        =   13
      Top             =   150
      Width           =   1875
   End
End
Attribute VB_Name = "frmRoomType"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
'CurrRec holds the number of the current record displayed on the screen
Dim CurrRec As Long
Dim SaveRec As Long
Dim v_AccountNum As Long
Dim v_RoomType As Long
Dim SetFocusTo As String

Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error
   
   Select Case GetFormMode(Me)
     Case "Insert"
        If datBrowse.Recordset.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
        'MsgBox Str$(v_RoomType)
        gBNB.Execute "delete * from RoomTypeInsertControl where accountnum = " & frmProperty.txtAccountNum.Text & " and RoomType = " & v_RoomType & " and ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
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
   txtAccountNum.Text = frmProperty.txtAccountNum.Text
   
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
        TempVal = Trim$(frmProperty.txtAccountNum.Text)
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        datBrowse.RecordSource = "select * from " & Me.Tag & " where AccountNum = " & CLng(TempVal)
        If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        'If successful update, update the HostInsertControl table
        gBNB.Execute "delete * from RoomTypeInsertControl where AccountNum = " & CLng(TempVal)
        If Not datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then datBrowse.Recordset.MoveLast
        SetToCurrencyFormat Me
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
        'Cannot delete if UnitName exists in bbtbl.
        gSQL = "SELECT UnitName FROM bbtbl WHERE AccountNum = " & frmProperty.txtAccountNum.Text & " And UnitName = " & Chr$(34) & txtRoomType.Text & Chr$(34)
        Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
        GetSSRows TempSS
        If TempSS.RecordCount > 0 Then
           'MsgBox "This room type is currently linked to guest reservations and cannot be deleted.", MB_ICONSTOP, Me.Caption
           'TempSS.Close
           'GoTo cmdCommit_Click_Resume
           gMsg = "This room type is currently linked to guest accommodations. Delete it anyway?"
        Else
           gMsg = "Delete the current row?"
        End If
        TempSS.Close
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
    gCaption = "Room Type Listing"
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
      Criteria = BuildFindCriteria(Me, "RoomType")
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
   txtAccountNum.Text = frmProperty.txtAccountNum.Text
   txtAccountNum.Locked = True
   txtRoomType.SetFocus

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
'    If Trim(datBrowse.RecordSource) = "" Then
       datBrowse.RecordSource = "select * from " & Me.Tag & " where accountnum = " & frmProperty.txtAccountNum.Text '& " order by RoomType"
       If Not GetDCRows(datBrowse) Then GoTo cmdInsert_Click_Resume
'    End If
    datBrowse.Recordset.AddNew
    SetZeroLengthString Me
    'Control for Multi-user inserts.
    'Use a accountnum control table containing all attempted row inserts.
    'Get next accountnum
    Dim MaxRS As Recordset  'Maximum accountnum from actual data table (proptbl)
    Dim ControlRS As Recordset  'accountnum numbers from CarAgencyInsertControl table.
    Dim MaxRoomTypePlusOne As Long
    Dim MinControlRS As Long
    txtRoomType.Locked = True
    txtAccountNum.Locked = True
    txtRoomType.ForeColor = BLACK
    'Get highest accountnum from proptbl and put it in MaxRS.
    'The following line is for testing when no rows in proptbl yet.
    'Set MaxRS = gBNB.OpenRecordset("select accountnum from " & Me.Tag & " where accountnum in(select max(accountnum) from " & Me.Tag & " where accountnum = 0)", dbOpenSnapshot)
    Set MaxRS = gBNB.OpenRecordset("select RoomType from " & Me.Tag & " where accountnum = " & frmProperty.txtAccountNum.Text & " And RoomType in(select max(alias_1.RoomType) from " & Me.Tag & " AS alias_1 where accountnum = " & frmProperty.txtAccountNum.Text & ")", dbOpenSnapshot)
    GetSSRows MaxRS
    'The ONLY purpose of the CarAgencyInsertControl table is to get new rows into proptbl.
    'Any accountnum numbers already in proptbl have no reason to be in the CarAgencyInsertControl table.
    'This case could happen due to a power outage (or other abnormal termination) AFTER
    'insert of accountnum into proptbl but BEFORE that accountnum's removal from
    'CarAgencyInsertControl table. As such, remove invalid rows from CarAgencyInsertControl to prevent any
    'possible buildup of old accountnum numbers in CarAgencyInsertControl. Removed accountnum will never
    'be used in the database.
    If Not MaxRS.EOF Then gBNB.Execute "delete from RoomTypeInsertControl where RoomType < " & (MaxRS(0) + 1) & " and accountnum = " & frmProperty.txtAccountNum.Text
    'Get all accountnum numbers currently in CarAgencyInsertControl table.
    Set ControlRS = gBNB.OpenRecordset("select * from RoomTypeInsertControl where accountnum = " & frmProperty.txtAccountNum.Text & " order by RoomType ASC", dbOpenDynaset)
    'Make SURE we're at beginning.
    GetSSRows ControlRS
    If Not ControlRS.BOF And Not ControlRS.EOF Then
       MinControlRS = ControlRS("RoomType")
    Else  'No rows in CarAgencyInsertControl table.
       MinControlRS = 0
    End If
    If MaxRS.BOF And MaxRS.EOF Then  'No rows exist in proptbl yet.
       'MsgBox "Null"
       MaxRoomTypePlusOne = 1
    Else
       MaxRoomTypePlusOne = (MaxRS("RoomType") + 1)
    End If
    MaxRS.Close
    If (ControlRS.BOF And ControlRS.EOF) Then  'No rows in CarAgencyInsertControl table.
       GoSub Insert_Control
    ElseIf MaxRoomTypePlusOne < MinControlRS Then  'accountnum to be inserted is less than all rows in CarAgencyInsertControl.
       GoSub Insert_Control
    ElseIf MaxRoomTypePlusOne >= MinControlRS Then
       'Equal or greater. Move through recordset to find next available
       'accountnum to insert.
       Dim Done As Integer
       Done = False
       For i = 0 To ControlRS.RecordCount - 1
          If MaxRoomTypePlusOne < (ControlRS("RoomType") - i) Then
            v_RoomType = (MaxRoomTypePlusOne + i)
            ControlRS.AddNew
            ControlRS("accountnum") = frmProperty.txtAccountNum.Text
            ControlRS("RoomType") = (MaxRoomTypePlusOne + i)
            ControlRS("ComputerName") = gComputerName
            ControlRS.Update
            'v_RoomType = (MaxRoomTypePlusOne + i)
            Done = True
            Exit For
          End If
          ControlRS.MoveNext
       Next i
       'accountnum to be inserted into CarAgencyInsertControl table will be
       'greater than any of those already existing in the table.
       If Not Done Then
          v_RoomType = (MaxRoomTypePlusOne + i)
          ControlRS.AddNew
          ControlRS("accountnum") = frmProperty.txtAccountNum.Text
          ControlRS("RoomType") = (MaxRoomTypePlusOne + i)
          ControlRS("ComputerName") = gComputerName
          ControlRS.Update
          'v_RoomType = (MaxRoomTypePlusOne + i)
       End If
    Else
       'All cases have been accounted for.
    End If
    ControlRS.Close
    txtAccountNum.Text = frmProperty.txtAccountNum.Text
    txtRoomType.Text = Trim$(v_RoomType)
    txtRoomType.Locked = True
    txtRoomType.ForeColor = BLACK
    txtRoomTypeDesc.SetFocus
    'txtDateBooked.Text = Format$(Now, "m/d/yyyy")
    
cmdInsert_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub
    
Insert_Control:
      v_RoomType = MaxRoomTypePlusOne
      ControlRS.AddNew
      ControlRS("accountnum") = frmProperty.txtAccountNum.Text
      ControlRS("RoomType") = MaxRoomTypePlusOne
      ControlRS("ComputerName") = gComputerName
      'v_RoomType = MaxRoomTypePlusOne
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


Private Sub cmdRefresh_Click()

   Screen.MousePointer = HOURGLASS
   datBrowse.RecordSource = "select * from " & Me.Tag & " Where accountnum = " & frmProperty.txtAccountNum.Text & " order by RoomType"
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
   txtAccountNum.Text = frmProperty.txtAccountNum.Text
   txtAccountNum.Locked = True
   txtRoomType.Locked = True
   txtRoomType.ForeColor = BLACK
   txtRoomTypeDesc.SetFocus
   
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

'txtAccountNum.Text = frmProperty.txtAccountNum.Text
'datBrowse.RecordSource = "select * from " & Me.Tag & " Where accountnum = " & frmProperty.txtAccountNum.Text
If TimesActivated < 1 Or txtAccountNum.Text <> frmProperty.txtAccountNum.Text Then
   Screen.MousePointer = HOURGLASS
   TimesActivated = TimesActivated + 1
   gDropSource = ""
   datBrowse.RecordSource = "select * from " & Me.Tag & " Where accountnum = " & frmProperty.txtAccountNum.Text
   If Not GetDCRows(datBrowse) Then GoTo Form_Activate_Resume
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
   Else
      SetFormToBrowseMode Me
      CurrRec = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
   End If
End If
txtAccountNum.Text = frmProperty.txtAccountNum.Text

Form_Activate_Resume:
   txtRoomType.SetFocus
   Screen.MousePointer = DEFAULT
   Exit Sub
  
Form_Activate_Error:
   Resume Form_Activate_Resume
  
End Sub

Private Sub Form_Load()
   
   On Error GoTo Load_Error
   
   TimesActivated = 0
   
   datBrowse.DatabaseName = gDatabaseName
   
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
  
  Dim SSTemp As Recordset
  
  InsertTrigger = True
  SetFocusTo = ""
  
  'Account num cannot be blank
  If txtAccountNum.Text = "0" Or txtAccountNum.Text = "" Then
     gMsg = "Account number cannot be zero or blank."
     SetFocusTo = "txtAccountNum"
     InsertTrigger = False
     Exit Function
  End If
  'Room Type cannot be zero or blank
  If Trim(txtRoomType.Text) = "0" Or Trim(txtRoomType.Text) = "" Then
     gMsg = "Room Type ID cannot be zero or blank."
     SetFocusTo = "txtRoomType"
     InsertTrigger = False
     Exit Function
  End If
  'Room Type Description cannot be blank
  If Trim(txtRoomTypeDesc.Text) = "" Then
     gMsg = "Room Type Description cannot be blank."
     SetFocusTo = "txtRoomTypeDesc"
     InsertTrigger = False
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
  
  'Room Type Description cannot be blank
  If Trim(txtRoomTypeDesc.Text) = "" Then
     gMsg = "Room Type Description cannot be blank."
     SetFocusTo = "txtRoomTypeDesc"
     UpdateTrigger = False
     Exit Function
  End If
   
UpdateTrigger_Resume:
   Exit Function

UpdateTrigger_Error:
   Resume UpdateTrigger_Resume
    
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

