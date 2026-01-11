VERSION 5.00
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmTaxPlan 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Tax Plans"
   ClientHeight    =   4380
   ClientLeft      =   1656
   ClientTop       =   2112
   ClientWidth     =   6636
   HelpContextID   =   112
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4380
   ScaleWidth      =   6636
   Tag             =   "taxplan"
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
      Left            =   5280
      TabIndex        =   13
      Top             =   1560
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
      Height          =   615
      Left            =   5280
      TabIndex        =   12
      Top             =   840
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
      Height          =   615
      Left            =   5280
      TabIndex        =   14
      Top             =   2280
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
      Height          =   615
      Left            =   5280
      TabIndex        =   15
      Top             =   3000
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
      Height          =   300
      Left            =   0
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   4005
      Visible         =   0   'False
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
      Height          =   615
      Left            =   5280
      TabIndex        =   11
      Top             =   120
      Width           =   1335
   End
   Begin VB.TextBox txtTaxPlanTitle 
      Appearance      =   0  'Flat
      DataField       =   "plan_title"
      DataSource      =   "datBrowse"
      Height          =   375
      Left            =   1440
      MaxLength       =   50
      TabIndex        =   1
      Tag             =   "Text"
      Top             =   120
      Width           =   3615
   End
   Begin VB.CommandButton cmdExit 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
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
      Left            =   5280
      TabIndex        =   16
      Top             =   3720
      Width           =   1335
   End
   Begin VB.Frame fraOther 
      Height          =   615
      Left            =   1440
      TabIndex        =   19
      Top             =   2760
      Width           =   3615
      Begin VB.OptionButton optTaxPlan 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   8
         Left            =   2880
         TabIndex        =   10
         Top             =   240
         Width           =   615
      End
      Begin VB.OptionButton optTaxPlan 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   7
         Left            =   1680
         TabIndex        =   9
         Top             =   240
         Width           =   615
      End
      Begin VB.OptionButton optTaxPlan 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   6
         Left            =   480
         TabIndex        =   8
         Top             =   240
         Width           =   615
      End
   End
   Begin VB.Frame fraHotel 
      Height          =   615
      Left            =   1440
      TabIndex        =   18
      Top             =   2160
      Width           =   3615
      Begin VB.OptionButton optTaxPlan 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   5
         Left            =   2880
         TabIndex        =   7
         Top             =   240
         Width           =   615
      End
      Begin VB.OptionButton optTaxPlan 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   4
         Left            =   1680
         TabIndex        =   6
         Top             =   240
         Width           =   615
      End
      Begin VB.OptionButton optTaxPlan 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   3
         Left            =   480
         TabIndex        =   5
         Top             =   240
         Width           =   615
      End
   End
   Begin VB.Frame fraState 
      Height          =   615
      Left            =   1440
      TabIndex        =   17
      Top             =   1560
      Width           =   3615
      Begin VB.OptionButton optTaxPlan 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   2
         Left            =   2880
         TabIndex        =   4
         Top             =   240
         Width           =   615
      End
      Begin VB.OptionButton optTaxPlan 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   1
         Left            =   1680
         TabIndex        =   3
         Top             =   240
         Width           =   735
      End
      Begin VB.OptionButton optTaxPlan 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   0
         Left            =   480
         TabIndex        =   2
         Top             =   240
         Width           =   735
      End
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "TAXPLAN.frx":0000
      Height          =   330
      Left            =   1440
      TabIndex        =   0
      Top             =   3960
      Width           =   3615
      _Version        =   131075
      _ExtentX        =   6371
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
   Begin VB.Label lblLabelPlanCode 
      Caption         =   "Tax Plan Code:"
      Height          =   240
      Left            =   120
      TabIndex        =   29
      Top             =   630
      Width           =   1215
   End
   Begin VB.Label lblRowID 
      Caption         =   "lblRowID"
      DataField       =   "ID"
      DataSource      =   "datBrowse"
      Height          =   255
      Left            =   0
      TabIndex        =   28
      Top             =   3645
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.Label lblPlanCode 
      AutoSize        =   -1  'True
      Caption         =   "lblPlanCode"
      DataField       =   "plancode"
      DataSource      =   "datBrowse"
      Height          =   195
      Left            =   1440
      TabIndex        =   27
      Tag             =   "Text"
      Top             =   630
      Width           =   840
   End
   Begin VB.Label lblTaxPlanTitle 
      Caption         =   "Tax Plan Title:"
      Height          =   255
      Left            =   120
      TabIndex        =   26
      Top             =   200
      Width           =   1095
   End
   Begin VB.Label lblNoTax 
      Alignment       =   2  'Center
      Caption         =   "Does Not Apply"
      Height          =   615
      Left            =   4200
      TabIndex        =   25
      Top             =   960
      Width           =   525
   End
   Begin VB.Label lblTaxOnGross 
      Alignment       =   2  'Center
      Caption         =   "Tax on Gross Amount"
      Height          =   615
      Left            =   2920
      TabIndex        =   24
      Top             =   960
      Width           =   615
   End
   Begin VB.Label lblTaxOnNet 
      Alignment       =   2  'Center
      Caption         =   "Tax on Net Amount"
      Height          =   615
      Left            =   1680
      TabIndex        =   23
      Top             =   960
      Width           =   615
   End
   Begin VB.Label lblTaxThree 
      Caption         =   "lblTaxThree"
      Height          =   375
      Left            =   120
      TabIndex        =   22
      Top             =   2880
      Width           =   1215
   End
   Begin VB.Label lblTaxTwo 
      Caption         =   "lblTaxTwo"
      Height          =   375
      Left            =   120
      TabIndex        =   21
      Top             =   2280
      Width           =   1215
   End
   Begin VB.Label lblTaxOne 
      Caption         =   "lblTaxOne"
      Height          =   375
      Left            =   120
      TabIndex        =   20
      Top             =   1680
      Width           =   1215
   End
End
Attribute VB_Name = "frmTaxPlan"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim CurrRec As Integer
Dim TimesActivated As Integer
Dim TaxOneDesc As String
Dim TaxTwoDesc As String
Dim TaxThreeDesc As String
Dim OrigPlanCode As String
Dim SetFocusTo As String
Private Sub cmdClose_Click()
   Unload Me
End Sub


Private Sub lblOtherTaxDesc_Click()

End Sub


Private Sub cmdCancel_Click()
   'If cmdFind.Caption = "&Run Query" Then cmdFind.Caption = "&Find"
   
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
     DecodeTaxPlan (lblPlanCode.Caption)
     CurrRec = GetCurrentRowNumber(datBrowse)
     datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
     txtTaxPlanTitle.SetFocus
   End If

cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume

End Sub

Private Sub cmdCommit_Click()
    
    Dim SSTemp As Recordset
    
    On Error GoTo cmdCommit_Click_Error
    
    Screen.MousePointer = HOURGLASS
    
    lblPlanCode.Caption = EncodeTaxPlan()
    
    Select Case GetFormMode(Me)
      Case "Insert"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'See if tax plan already exists.
        Set SSTemp = gBNB.OpenRecordset("select * from taxplan where plancode = '" & lblPlanCode.Caption & "'", dbOpenSnapshot)
        GetSSRows SSTemp
        If Not SSTemp.EOF And Not SSTemp.BOF Then
           MsgBox "This tax plan already exists with the title of: " & SSTemp("plan_title"), MB_ICONSTOP, Me.Caption
           SSTemp.Close
           GoTo cmdCommit_Click_Resume
        End If
        SSTemp.Close
        'Check for specifics of frmTaxPlan
        If Not InsertTrigger() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        datBrowse.Recordset.Update
        If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
        If Not datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then datBrowse.Recordset.MoveLast
      Case "Update"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'See if tax plan already exists.
        Set SSTemp = gBNB.OpenRecordset("select * from taxplan where plancode = '" & lblPlanCode.Caption & "' and ID <> " & lblRowID, dbOpenSnapshot)
        GetSSRows SSTemp
        If Not SSTemp.EOF And Not SSTemp.BOF Then
           MsgBox "This tax plan already exists with the title of: " & SSTemp("plan_title"), MB_ICONSTOP, Me.Caption
           SSTemp.Close
           GoTo cmdCommit_Click_Resume
        End If
        SSTemp.Close
        'Don't update plancode if plancode is used in bbtbl (Only Title can be updated in that case).
        Set SSTemp = gBNB.OpenRecordset("select taxplan.plan_title from taxplan,bbtbl where bbtbl.tax_plan_code = '" & OrigPlanCode & "' and bbtbl.tax_plan_code = taxplan.plancode", dbOpenSnapshot)
        GetSSRows SSTemp
        If SSTemp.RecordCount > 0 And lblPlanCode.Caption <> OrigPlanCode Then
           gMsg = "This tax plan (" & SSTemp(0) & ") is currently used in Guest Accommodations and cannot be updated. Only the Title may be updated."
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           SSTemp.Close
           GoTo cmdCommit_Click_Resume
        End If
        SSTemp.Close
        'Check for specifics of frmTaxPlan
        If Not InsertTrigger() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        datBrowse.Recordset.Update
        datBrowse.UpdateControls
      Case "Delete"
       'Don't delete if plancode is used in proptbl.
        Set SSTemp = gBNB.OpenRecordset("select taxplan.plan_title from proptbl,taxplan where proptbl.tax_plan_code = taxplan.plancode and proptbl.tax_plan_code = '" & lblPlanCode.Caption & "'", dbOpenSnapshot)
        GetSSRows SSTemp
        If SSTemp.RecordCount > 0 Then
           gMsg = "This tax plan (" & SSTemp(0) & ") is currently used in Host Accounts and cannot be deleted."
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           SSTemp.Close
           GoTo cmdCommit_Click_Resume
        End If
        SSTemp.Close
        'Don't delete if plancode is used in bbtbl.
        Set SSTemp = gBNB.OpenRecordset("select taxplan.plan_title from bbtbl,taxplan where bbtbl.tax_plan_code = taxplan.plancode and bbtbl.tax_plan_code = '" & lblPlanCode.Caption & "'", dbOpenSnapshot)
        GetSSRows SSTemp
        If SSTemp.RecordCount > 0 Then
           gMsg = "This tax plan (" & SSTemp(0) & ") is currently used in Guest Accommodations and cannot be deleted."
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           SSTemp.Close
           GoTo cmdCommit_Click_Resume
        End If
        SSTemp.Close
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
      optTaxPlan(2).Value = True
      optTaxPlan(5).Value = True
      optTaxPlan(8).Value = True
    Else
      SetFormToBrowseMode Me
      DecodeTaxPlan (lblPlanCode.Caption)
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
    gCaption = "Tax Plan Listing"
    gSQL = datBrowse.RecordSource
    'frmBoundListing.Show
    Dim frmNewBoundListing As New frmBoundListing  ' Declare form variable
    frmNewBoundListing.Show     ' Load and display new instance

End Sub

Private Sub cmdExit_Click()
  Unload Me
End Sub

Private Sub cmdInsert_Click()

   On Error GoTo cmdInsert_Click_Error
   
   SetFormToInsertMode Me
   datBrowse.Recordset.AddNew
   SetZeroLengthString Me
   
   optTaxPlan(2).Value = True
   optTaxPlan(5).Value = True
   optTaxPlan(8).Value = True
      
   If lblTaxOne.Caption = "N/A" Then
      optTaxPlan(0).Enabled = False
      optTaxPlan(1).Enabled = False
      optTaxPlan(2).Enabled = False
   End If
   If lblTaxTwo.Caption = "N/A" Then
      optTaxPlan(3).Enabled = False
      optTaxPlan(4).Enabled = False
      optTaxPlan(5).Enabled = False
   End If
   If lblTaxThree.Caption = "N/A" Then
      optTaxPlan(6).Enabled = False
      optTaxPlan(7).Enabled = False
      optTaxPlan(8).Enabled = False
   End If
   txtTaxPlanTitle.SetFocus

cmdInsert_Click_Resume:
   Exit Sub
   
cmdInsert_Click_Error:
   MsgBox Err.Description
   Resume cmdInsert_Click_Resume
   
End Sub

Private Sub cmdUpdate_Click()

   On Error GoTo cmdUpdate_Click_Error
   
   OrigPlanCode = Trim$(lblPlanCode.Caption)
   SetFormToUpdateMode Me

   If lblTaxOne.Caption = "N/A" Then
      optTaxPlan(0).Enabled = False
      optTaxPlan(1).Enabled = False
      optTaxPlan(2).Enabled = False
   End If
   If lblTaxTwo.Caption = "N/A" Then
      optTaxPlan(3).Enabled = False
      optTaxPlan(4).Enabled = False
      optTaxPlan(5).Enabled = False
   End If
   If lblTaxThree.Caption = "N/A" Then
      optTaxPlan(6).Enabled = False
      optTaxPlan(7).Enabled = False
      optTaxPlan(8).Enabled = False
   End If
   
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

Private Sub Command1_Click()
  EncodeTaxPlan
End Sub

Private Sub Command2_Click()
   DecodeTaxPlan ("258")
End Sub

Private Sub datdwData1_Click(ByVal nPosition As Integer)
    'On Error GoTo datdwData1_Click_Error

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

'Get Tax Descriptions from TaxRate table.
Dim SSTaxDesc As Recordset
Set SSTaxDesc = gBNB.OpenRecordset("select tax_one_desc, tax_two_desc, tax_three_desc from taxrates", dbOpenSnapshot)
GetSSRows SSTaxDesc
If TimesActivated < 1 Then
   TimesActivated = TimesActivated + 1
   If Not GetDCRows(datBrowse) Then GoTo Form_Activate_Resume
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
      optTaxPlan(2).Value = True
      optTaxPlan(5).Value = True
      optTaxPlan(8).Value = True
   Else
      SetFormToBrowseMode Me
      CurrRec = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
      DecodeTaxPlan datBrowse.Recordset("plancode")
   End If
   If Not IsNull(SSTaxDesc("tax_one_desc")) Then
      TaxOneDesc = SSTaxDesc("tax_one_desc")
   Else
      TaxOneDesc = "N/A"
   End If
   If Not IsNull(SSTaxDesc("tax_two_desc")) Then
      TaxTwoDesc = SSTaxDesc("tax_two_desc")
   Else
      TaxTwoDesc = "N/A"
   End If
   If Not IsNull(SSTaxDesc("tax_three_desc")) Then
      TaxThreeDesc = SSTaxDesc("tax_three_desc")
   Else
      TaxThreeDesc = "N/A"
   End If
   lblTaxOne.Caption = TaxOneDesc
   lblTaxTwo.Caption = TaxTwoDesc
   lblTaxThree.Caption = TaxThreeDesc
   SSTaxDesc.Close
End If

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
Form_Activate_Error:
   Resume Form_Activate_Resume

End Sub

Private Sub Form_Load()

    On Error GoTo Load_Error
    
    TimesActivated = 0
    datBrowse.DatabaseName = gDatabaseName
    datBrowse.RecordSource = "select * from " & Me.Tag
    
Load_Resume:
   Exit Sub

Load_Error:
   Resume Load_Resume

End Sub





Public Sub DecodeTaxPlan(TheCode As String)

   Dim TempValue As String
   Dim i As Integer
   For i = 0 To 2
     TempValue = Mid$(Val(TheCode), i + 1, 1)   'Use Val!!!
     If CInt(Val(TempValue)) <= 2 Then
        optTaxPlan(CInt(Val(TempValue))).Value = True
     ElseIf CInt(Val(TempValue)) <= 5 Then
        optTaxPlan(CInt(Val(TempValue))).Value = True
     ElseIf CInt(Val(TempValue)) <= 8 Then
        optTaxPlan(CInt(Val(TempValue))).Value = True
     End If
   Next i
   
End Sub

Public Function EncodeTaxPlan() As String
  
   Dim TempPlan As String
   Dim i As Integer
   TempPlan = ""
   For i = 0 To 8
      If i <= 2 Then
         If optTaxPlan(i).Value = True Then TempPlan = Trim$(TempPlan) & Trim$(Str$(i))
      ElseIf i <= 5 Then
         If optTaxPlan(i).Value = True Then TempPlan = Trim$(TempPlan) & Trim$(Str$(i))
      ElseIf i <= 8 Then
         If optTaxPlan(i).Value = True Then TempPlan = Trim$(TempPlan) & Trim$(Str$(i))
      End If
   Next i
   
   EncodeTaxPlan = Trim$(TempPlan)
         
End Function

Private Sub Form_Resize()
    If Me.WindowState = MINIMIZED Then Exit Sub
    'MsgBox Str$(ScaleWidth)
    Me.Width = cmdCancel.Width * 5.1
    Me.Height = cmdCancel.Height * 7.8
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

Private Sub lblPlanCode_Change()
   DecodeTaxPlan (lblPlanCode.Caption)
End Sub

Private Sub lblStateTax_Click()

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
   
   'Plan Title cannot be blank
   If Trim(txtTaxPlanTitle.Text) = "" Then
       gMsg = "Tax Plan Title must be filled in."
       InsertTrigger = False
       GoTo InsertTrigger_Resume
   End If
   
InsertTrigger_Resume:
   Exit Function
   
InsertTrigger_Error:
   Resume InsertTrigger_Resume
   
End Function
