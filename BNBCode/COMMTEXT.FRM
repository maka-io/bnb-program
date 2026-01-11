VERSION 5.00
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmCommonText 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Common Text"
   ClientHeight    =   4845
   ClientLeft      =   1635
   ClientTop       =   1725
   ClientWidth     =   5820
   HelpContextID   =   102
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4845
   ScaleWidth      =   5820
   Tag             =   "commontext"
   Begin VB.TextBox txtText 
      Appearance      =   0  'Flat
      DataField       =   "common_text"
      DataSource      =   "datBrowse"
      Height          =   3435
      Left            =   600
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   2
      Tag             =   "Text"
      Top             =   960
      Width           =   3615
   End
   Begin VB.CommandButton cmdRefresh 
      Caption         =   "R&efresh"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   4440
      TabIndex        =   7
      Top             =   2520
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
      Height          =   495
      Left            =   4440
      TabIndex        =   6
      TabStop         =   0   'False
      Top             =   1920
      Width           =   1335
   End
   Begin VB.TextBox txtTitle 
      Appearance      =   0  'Flat
      DataField       =   "common_title"
      DataSource      =   "datBrowse"
      Height          =   375
      Left            =   600
      MaxLength       =   60
      TabIndex        =   1
      Tag             =   "Text"
      Top             =   120
      Width           =   3615
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
      Left            =   1320
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   600
      Visible         =   0   'False
      Width           =   2055
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
      Height          =   495
      Left            =   4440
      TabIndex        =   10
      Top             =   4320
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
      Height          =   495
      Left            =   4440
      TabIndex        =   9
      Top             =   3720
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
      Height          =   495
      Left            =   4440
      TabIndex        =   8
      Top             =   3120
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
      Height          =   495
      Left            =   4440
      TabIndex        =   5
      Top             =   1320
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
      Height          =   495
      Left            =   4440
      TabIndex        =   4
      Top             =   720
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
      Height          =   495
      Left            =   4440
      TabIndex        =   3
      Top             =   120
      Width           =   1335
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "COMMTEXT.frx":0000
      Height          =   330
      Left            =   600
      TabIndex        =   0
      Top             =   4480
      Width           =   3615
      _Version        =   131075
      _ExtentX        =   6376
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
   Begin VB.Label lblText 
      Caption         =   "Text:"
      Height          =   255
      Left            =   120
      TabIndex        =   12
      Top             =   960
      Width           =   495
   End
   Begin VB.Label lblTitle 
      Caption         =   "Title:"
      Height          =   255
      Left            =   120
      TabIndex        =   11
      Top             =   120
      Width           =   495
   End
End
Attribute VB_Name = "frmCommonText"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim CurrRec As Long
Dim InClicked As String
Dim TimesActivated As Integer
Dim SetFocusTo As String
Dim OrigTitle As String
'Dim OrigBookmark As Variant

Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error
   
   Select Case GetFormMode(Me)
     Case "Insert"
        If datBrowse.Recordset.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
     Case "Update"
        If datBrowse.Recordset.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
     Case "Find"
        cmdFind.Caption = "&Find"
     Case Else
        '
   End Select
   datBrowse.UpdateControls
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
     SetFormToNoRowsMode Me
     cmdInsert.SetFocus
   Else
     SetFormToBrowseMode Me
     CurrRec = GetCurrentRowNumber(datBrowse)
     datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
     txtTitle.SetFocus
   End If
   'datBrowse.Refresh
   
cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume
   
End Sub

Private Sub cmdCommit_Click()

    On Error GoTo cmdCommit_Click_Error

    Screen.MousePointer = HOURGLASS

    Select Case GetFormMode(Me)
      Case "Insert"
        '***Check for valid row entry here (i_trig)***
        '**********************************
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
        datBrowse.Recordset.Update
        datBrowse.Recordset.Bookmark = datBrowse.Recordset.LastModified
      Case "Update"
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
        datBrowse.Recordset.Update
        datBrowse.UpdateControls
      Case "Delete"
        gMsg = "Delete the current row?"
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


Private Sub cmdExit_Click()
   Unload Me
End Sub


Private Sub cmdFind_Click()

   On Error GoTo cmdFind_Click_Error
   
   Screen.MousePointer = HOURGLASS
   Dim Criteria As String
   If cmdFind.Caption = "&Find" Then
      'If Not datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then OrigBookmark = datBrowse.Recordset.Bookmark
      SetFormToFindMode Me
      cmdFind.Caption = "&Run Query"
   Else
      cmdFind.Caption = "&Find"
      Criteria = BuildFindCriteria(Me, "common_title")
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
   txtTitle.SetFocus

cmdFind_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdFind_Click_Error:
   Resume cmdFind_Click_Resume
   
End Sub

Private Sub cmdInsert_Click()
 
   On Error GoTo cmdInsert_Click_Error
   
   SetFormToInsertMode Me
   If Trim(datBrowse.RecordSource) = "" Then
      datBrowse.RecordSource = "select * from " & Me.Tag
      If Not GetDCRows(datBrowse) Then Exit Sub
   End If
   datBrowse.Recordset.AddNew
   SetZeroLengthString Me
   txtTitle.SetFocus
   
cmdInsert_Click_Resume:
   Exit Sub
   
cmdInsert_Click_Error:
   MsgBox Err.Description
   Resume cmdInsert_Click_Resume
   
End Sub


Private Sub cmdRefresh_Click()

   On Error GoTo cmdRefresh_Error
   
   Screen.MousePointer = HOURGLASS
   
   datBrowse.RecordSource = "select * from " & Me.Tag
   If Not GetDCRows(datBrowse) Then Exit Sub
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
   Else
      SetFormToBrowseMode Me
      CurrRec = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
   End If

cmdRefresh_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdRefresh_Error:
   Resume cmdRefresh_Resume
    
End Sub

Private Sub cmdUpdate_Click()

   On Error GoTo cmdUpdate_Click_Error
   
   'If Not datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then OrigBookmark = datBrowse.Recordset.Bookmark
   OrigTitle = Trim(txtTitle.Text)
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
   TimesActivated = TimesActivated + 1
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
   Screen.MousePointer = DEFAULT
   Exit Sub

Form_Activate_Error:
   Resume Form_Activate_Resume
   
End Sub

Private Sub Form_Load()

    On Error GoTo Form_Load_Error
    
    Screen.MousePointer = HOURGLASS
    TimesActivated = 0
    datBrowse.DatabaseName = gDatabaseName
    datBrowse.RecordSource = "select * from " & Me.Tag
   
Form_Load_Resume:
   Exit Sub
   
Form_Load_Error:
   Resume Form_Load_Resume

End Sub

Public Function InsertTrigger() As Integer

  On Error GoTo InsertTrigger_Error
  
  Dim SSTemp As Recordset
  InsertTrigger = True
  SetFocusTo = ""
  If Trim(txtTitle.Text) = "" Then
     InsertTrigger = False
     gMsg = "Title cannot be blank."
     SetFocusTo = "txtTitle"
  Else
     'See if Title already exists.
     txtTitle.Text = Trim(txtTitle.Text)
     Set SSTemp = gBNB.OpenRecordset("select Common_Title from " & Me.Tag & " where Common_Title = '" & txtTitle.Text & "'", dbOpenSnapshot)
     GetSSRows SSTemp
     If Not SSTemp.EOF And Not SSTemp.BOF Then
        InsertTrigger = False
        gMsg = "A Common Text row already exists with the title of " & SSTemp(0)
        SetFocusTo = "txtTitle"
     End If
     SSTemp.Close
  End If
  If Trim(txtText.Text) = "" Then
     InsertTrigger = False
     gMsg = "Text cannot be blank."
     SetFocusTo = "txtText"
  End If
  
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



Public Function UpdateTrigger() As Integer

  On Error GoTo UpdateTrigger_Error
  
  Dim SSTemp As Recordset
  UpdateTrigger = True
  SetFocusTo = ""
  If Trim(txtTitle.Text) = "" Then
     UpdateTrigger = False
     gMsg = "Title cannot be blank."
     SetFocusTo = "txtTitle"
  Else
     'See if Title already exists.
     txtTitle.Text = Trim(txtTitle.Text)
     If txtTitle.Text <> OrigTitle Then
        Set SSTemp = gBNB.OpenRecordset("select Common_Title from " & Me.Tag & " where Common_Title = '" & txtTitle.Text & "'", dbOpenSnapshot)
        GetSSRows SSTemp
        If Not SSTemp.EOF And Not SSTemp.BOF Then
           UpdateTrigger = False
           gMsg = "A Common Text row already exists with the title of " & SSTemp(0)
           SetFocusTo = "txtTitle"
        End If
        SSTemp.Close
     End If
  End If
  If Trim(txtText.Text) = "" Then
     UpdateTrigger = False
     gMsg = "Text cannot be blank."
     SetFocusTo = "txtText"
  End If
  
UpdateTrigger_Resume:
   Exit Function
   
UpdateTrigger_Error:
   Resume UpdateTrigger_Resume
 
End Function
