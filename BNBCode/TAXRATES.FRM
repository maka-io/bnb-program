VERSION 5.00
Begin VB.Form frmTaxRates 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Tax Rates"
   ClientHeight    =   4416
   ClientLeft      =   1536
   ClientTop       =   1992
   ClientWidth     =   8940
   HelpContextID   =   111
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4416
   ScaleWidth      =   8940
   Tag             =   "taxrates"
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
      Height          =   735
      Left            =   7560
      TabIndex        =   42
      Top             =   3600
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
      Height          =   735
      Left            =   7560
      TabIndex        =   15
      Top             =   2750
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
      Height          =   735
      Left            =   7560
      TabIndex        =   14
      Top             =   1860
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
      Height          =   735
      Left            =   7560
      TabIndex        =   13
      Top             =   970
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
      Height          =   735
      Left            =   7560
      TabIndex        =   12
      Top             =   120
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
      Left            =   240
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   4200
      Visible         =   0   'False
      Width           =   1695
   End
   Begin VB.Frame fraFutureTaxRates 
      Caption         =   "Future Tax Rates"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   4335
      Left            =   4200
      TabIndex        =   17
      Top             =   0
      Width           =   3255
      Begin VB.TextBox txtEffectiveDate3 
         Appearance      =   0  'Flat
         DataField       =   "future_tax_three_eff_date"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   2040
         TabIndex        =   11
         Tag             =   "Date"
         Top             =   3840
         Width           =   1095
      End
      Begin VB.TextBox txtFutureRate3 
         Appearance      =   0  'Flat
         DataField       =   "future_tax_three"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   2040
         TabIndex        =   10
         Tag             =   "Number"
         Top             =   3480
         Width           =   735
      End
      Begin VB.TextBox txtEffectiveDate2 
         Appearance      =   0  'Flat
         DataField       =   "future_tax_two_eff_date"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   2040
         TabIndex        =   9
         Tag             =   "Date"
         Top             =   2520
         Width           =   1095
      End
      Begin VB.TextBox txtFutureRate2 
         Appearance      =   0  'Flat
         DataField       =   "future_tax_two"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   2040
         TabIndex        =   8
         Tag             =   "Number"
         Top             =   2160
         Width           =   735
      End
      Begin VB.TextBox txtEffectiveDate1 
         Appearance      =   0  'Flat
         DataField       =   "future_tax_one_eff_date"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   2040
         TabIndex        =   7
         Tag             =   "Date"
         Top             =   1200
         Width           =   1095
      End
      Begin VB.TextBox txtFutureRate1 
         Appearance      =   0  'Flat
         DataField       =   "future_tax_one"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   2040
         TabIndex        =   6
         Tag             =   "Number"
         Top             =   840
         Width           =   735
      End
      Begin VB.Label lblfra2Label12 
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
         Height          =   255
         Left            =   2760
         TabIndex        =   41
         Top             =   3520
         Width           =   255
      End
      Begin VB.Label lblfra2Label11 
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
         Height          =   255
         Left            =   2760
         TabIndex        =   40
         Top             =   2200
         Width           =   255
      End
      Begin VB.Label lblfra2Label10 
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
         Height          =   255
         Left            =   2760
         TabIndex        =   39
         Top             =   880
         Width           =   255
      End
      Begin VB.Line Line36 
         X1              =   1800
         X2              =   2040
         Y1              =   3960
         Y2              =   3960
      End
      Begin VB.Line Line35 
         X1              =   1440
         X2              =   2040
         Y1              =   3600
         Y2              =   3600
      End
      Begin VB.Line Line34 
         X1              =   1800
         X2              =   2040
         Y1              =   2640
         Y2              =   2640
      End
      Begin VB.Line Line33 
         X1              =   1440
         X2              =   2040
         Y1              =   2280
         Y2              =   2280
      End
      Begin VB.Line Line32 
         X1              =   1800
         X2              =   2040
         Y1              =   1320
         Y2              =   1320
      End
      Begin VB.Line Line31 
         X1              =   1440
         X2              =   2040
         Y1              =   960
         Y2              =   960
      End
      Begin VB.Label lblfra2Label6 
         Caption         =   "Effective Date"
         Height          =   255
         Left            =   720
         TabIndex        =   38
         Top             =   3840
         Width           =   1335
      End
      Begin VB.Label lblfra2Label5 
         Caption         =   "Effective Date"
         Height          =   255
         Left            =   720
         TabIndex        =   37
         Top             =   2520
         Width           =   1335
      End
      Begin VB.Label lblfra2Label4 
         Caption         =   "Effective Date"
         Height          =   255
         Left            =   720
         TabIndex        =   36
         Top             =   1200
         Width           =   1455
      End
      Begin VB.Label lblfra2Label7 
         Caption         =   "New Rate"
         Height          =   255
         Left            =   720
         TabIndex        =   35
         Top             =   3480
         Width           =   855
      End
      Begin VB.Label lblfra2Label8 
         Caption         =   "New Rate"
         Height          =   255
         Left            =   720
         TabIndex        =   34
         Top             =   2160
         Width           =   855
      End
      Begin VB.Label lblfra2Label9 
         Caption         =   "New Rate"
         Height          =   255
         Left            =   720
         TabIndex        =   33
         Top             =   840
         Width           =   855
      End
      Begin VB.Line Line30 
         X1              =   720
         X2              =   480
         Y1              =   3960
         Y2              =   3960
      End
      Begin VB.Line Line29 
         X1              =   480
         X2              =   480
         Y1              =   3960
         Y2              =   3600
      End
      Begin VB.Line Line28 
         X1              =   720
         X2              =   480
         Y1              =   3600
         Y2              =   3600
      End
      Begin VB.Line Line27 
         X1              =   480
         X2              =   480
         Y1              =   3600
         Y2              =   3360
      End
      Begin VB.Line Line26 
         X1              =   720
         X2              =   480
         Y1              =   2640
         Y2              =   2640
      End
      Begin VB.Line Line25 
         X1              =   480
         X2              =   480
         Y1              =   2640
         Y2              =   2280
      End
      Begin VB.Line Line24 
         X1              =   720
         X2              =   480
         Y1              =   2280
         Y2              =   2280
      End
      Begin VB.Line Line23 
         X1              =   480
         X2              =   480
         Y1              =   2040
         Y2              =   2280
      End
      Begin VB.Line Line22 
         X1              =   720
         X2              =   480
         Y1              =   1320
         Y2              =   1320
      End
      Begin VB.Line Line21 
         X1              =   480
         X2              =   480
         Y1              =   1320
         Y2              =   960
      End
      Begin VB.Line Line20 
         X1              =   720
         X2              =   480
         Y1              =   960
         Y2              =   960
      End
      Begin VB.Line Line19 
         X1              =   480
         X2              =   480
         Y1              =   720
         Y2              =   960
      End
      Begin VB.Label lblfra2Label3 
         Caption         =   "Tax #3"
         Height          =   255
         Left            =   240
         TabIndex        =   32
         Top             =   3120
         Width           =   615
      End
      Begin VB.Label lblfra2Label2 
         Caption         =   "Tax #2"
         Height          =   255
         Left            =   240
         TabIndex        =   31
         Top             =   1800
         Width           =   735
      End
      Begin VB.Label lblfra2Label1 
         Caption         =   "Tax #1"
         Height          =   255
         Left            =   240
         TabIndex        =   30
         Top             =   480
         Width           =   615
      End
   End
   Begin VB.Frame fraCurrentTaxRates 
      Caption         =   "Current Tax Rates"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   4335
      Left            =   120
      TabIndex        =   16
      Top             =   0
      Width           =   3975
      Begin VB.TextBox txtDescThree 
         Appearance      =   0  'Flat
         DataField       =   "tax_three_desc"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1680
         MaxLength       =   25
         TabIndex        =   5
         Tag             =   "Text"
         Top             =   3840
         Width           =   2175
      End
      Begin VB.TextBox txtRateThree 
         Appearance      =   0  'Flat
         DataField       =   "tax_three"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1680
         TabIndex        =   4
         Tag             =   "Number"
         Top             =   3480
         Width           =   735
      End
      Begin VB.TextBox txtDescTwo 
         Appearance      =   0  'Flat
         DataField       =   "tax_two_desc"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1680
         MaxLength       =   25
         TabIndex        =   3
         Tag             =   "Text"
         Top             =   2520
         Width           =   2175
      End
      Begin VB.TextBox txtRateTwo 
         Appearance      =   0  'Flat
         DataField       =   "tax_two"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1680
         TabIndex        =   2
         Tag             =   "Number"
         Top             =   2160
         Width           =   735
      End
      Begin VB.TextBox txtDescOne 
         Appearance      =   0  'Flat
         DataField       =   "tax_one_desc"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1680
         MaxLength       =   25
         TabIndex        =   1
         Tag             =   "Text"
         Top             =   1200
         Width           =   2175
      End
      Begin VB.TextBox txtRateOne 
         Appearance      =   0  'Flat
         DataField       =   "tax_one"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1680
         TabIndex        =   0
         Tag             =   "Number"
         Top             =   840
         Width           =   735
      End
      Begin VB.Label lblfra1Label9 
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
         Height          =   255
         Left            =   2400
         TabIndex        =   29
         Top             =   3520
         Width           =   255
      End
      Begin VB.Label lblfra1Label8 
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
         Height          =   255
         Left            =   2400
         TabIndex        =   28
         Top             =   2200
         Width           =   255
      End
      Begin VB.Label lblfra1Label7 
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
         Height          =   255
         Left            =   2400
         TabIndex        =   27
         Top             =   880
         Width           =   255
      End
      Begin VB.Line Line18 
         X1              =   1440
         X2              =   1680
         Y1              =   3960
         Y2              =   3960
      End
      Begin VB.Line Line17 
         X1              =   960
         X2              =   1680
         Y1              =   3600
         Y2              =   3600
      End
      Begin VB.Line Line16 
         X1              =   1440
         X2              =   1680
         Y1              =   2640
         Y2              =   2640
      End
      Begin VB.Line Line15 
         X1              =   960
         X2              =   1680
         Y1              =   2280
         Y2              =   2280
      End
      Begin VB.Label lblfra1Label6 
         Caption         =   "Description"
         Height          =   255
         Left            =   600
         TabIndex        =   26
         Top             =   3840
         Width           =   855
      End
      Begin VB.Label lblfra1Label5 
         Caption         =   "Rate"
         Height          =   255
         Left            =   600
         TabIndex        =   25
         Top             =   3480
         Width           =   615
      End
      Begin VB.Line Line14 
         X1              =   600
         X2              =   360
         Y1              =   3960
         Y2              =   3960
      End
      Begin VB.Line Line13 
         X1              =   360
         X2              =   360
         Y1              =   3960
         Y2              =   3600
      End
      Begin VB.Line Line12 
         X1              =   600
         X2              =   360
         Y1              =   3600
         Y2              =   3600
      End
      Begin VB.Line Line11 
         X1              =   360
         X2              =   360
         Y1              =   3360
         Y2              =   3600
      End
      Begin VB.Label lblfra1Label4 
         Caption         =   "Description"
         Height          =   255
         Left            =   600
         TabIndex        =   24
         Top             =   2520
         Width           =   855
      End
      Begin VB.Label lblfra1Label3 
         Caption         =   "Rate"
         Height          =   255
         Left            =   600
         TabIndex        =   23
         Top             =   2160
         Width           =   615
      End
      Begin VB.Line Line10 
         X1              =   600
         X2              =   360
         Y1              =   2640
         Y2              =   2640
      End
      Begin VB.Line Line9 
         X1              =   360
         X2              =   360
         Y1              =   2640
         Y2              =   2280
      End
      Begin VB.Line Line8 
         X1              =   600
         X2              =   360
         Y1              =   2280
         Y2              =   2280
      End
      Begin VB.Line Line7 
         X1              =   360
         X2              =   360
         Y1              =   2040
         Y2              =   2280
      End
      Begin VB.Line Line6 
         X1              =   960
         X2              =   1680
         Y1              =   960
         Y2              =   960
      End
      Begin VB.Line Line5 
         X1              =   1440
         X2              =   1680
         Y1              =   1320
         Y2              =   1320
      End
      Begin VB.Label lblfra1Label2 
         Caption         =   "Description"
         Height          =   255
         Left            =   600
         TabIndex        =   22
         Top             =   1200
         Width           =   855
      End
      Begin VB.Label lblfra1Label1 
         Caption         =   "Rate"
         Height          =   255
         Left            =   600
         TabIndex        =   21
         Top             =   840
         Width           =   495
      End
      Begin VB.Line Line3 
         X1              =   360
         X2              =   360
         Y1              =   1320
         Y2              =   960
      End
      Begin VB.Line Line4 
         X1              =   600
         X2              =   360
         Y1              =   1320
         Y2              =   1320
      End
      Begin VB.Line Line2 
         X1              =   600
         X2              =   360
         Y1              =   960
         Y2              =   960
      End
      Begin VB.Line Line1 
         X1              =   360
         X2              =   360
         Y1              =   720
         Y2              =   960
      End
      Begin VB.Label lblfra1TaxRateThree 
         Caption         =   "Tax #3"
         Height          =   255
         Left            =   120
         TabIndex        =   20
         Top             =   3120
         Width           =   615
      End
      Begin VB.Label lblfra1TaxRateTwo 
         Caption         =   "Tax #2"
         Height          =   255
         Left            =   120
         TabIndex        =   19
         Top             =   1800
         Width           =   615
      End
      Begin VB.Label lblfra1TaxRateOne 
         Caption         =   "Tax #1"
         Height          =   255
         Left            =   120
         TabIndex        =   18
         Top             =   480
         Width           =   615
      End
   End
End
Attribute VB_Name = "frmTaxRates"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
Dim SetFocusTo As String
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
     cmdInsert.Enabled = True
     cmdInsert.SetFocus
   Else
     SetFormToBrowseMode Me
     cmdInsert.Enabled = False
     'CurrRec = GetCurrentRowNumber(datBrowse)
     'datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
     txtRateOne.SetFocus
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

    If Not VerifyUpdate() Then
       MsgBox gMsg, MB_ICONSTOP, Me.Caption
       GoTo cmdCommit_Click_Resume
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
        'Make the current record current again
        datBrowse.UpdateControls
      Case "Update"
        'Check if any Date, Currency or Number fields were set to blank (0
        'length string); if so, unbind control's DataField property and commit Null.
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        'Make the current record current again
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


Private Sub cmdDelete_Click()
   gMsg = "Tax rate settings can be updated but not deleted"
   MsgBox gMsg, MB_ICONSTOP, Me.Caption
   Exit Sub
   SetFormToDeleteMode Me
   cmdInsert.Enabled = False
End Sub

Private Sub cmdExit_Click()

   Unload Me
   
End Sub

Private Sub cmdInsert_Click()
 
   On Error GoTo cmdInsert_Click_Error
   
   SetFormToInsertMode Me
   datBrowse.Recordset.AddNew
   SetZeroLengthString Me
   txtRateOne.SetFocus

cmdInsert_Click_Resume:
   Exit Sub
   
cmdInsert_Click_Error:
   MsgBox Err.Description
   Resume cmdInsert_Click_Resume
   
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
   End If
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
    'datBrowse.Refresh

Load_Resume:
   Exit Sub

Load_Error:
   Resume Load_Resume

End Sub


Private Sub Form_Resize()
    If Me.WindowState = MINIMIZED Then Exit Sub
    'MsgBox Str$(ScaleWidth)
    Me.Width = cmdCancel.Width * 6.8
    Me.Height = cmdCancel.Height * 6.5
End Sub



Public Function VerifyUpdate() As Integer
   
   VerifyUpdate = True
   
   Dim i As Integer
   For i = 0 To Me.Controls.Count - 1
      If Me.Controls(i).Name Like "txt*" Or Me.Controls(i).Name Like "datdwCombo*" Then
        If Me.Controls(i).Tag = "Number" Or Me.Controls(i).Tag = "Currency" Then
           If Trim(Me.Controls(i).Text) <> "" Then
              If Not IsNumeric(Me.Controls(i).Text) Then
                 gMsg = "Invalid character in Rate number field."
                 VerifyUpdate = False
                 Me.Controls(i).SetFocus
                 Exit For
              ElseIf Not (Me.Controls(i).Text >= 0 And Me.Controls(i).Text <= 100) Then
                 gMsg = "Tax rate percentage must be between 0 and 100"
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
   'Leave blank if user commits Zero in rate field
   If txtRateOne.Text = "" Or txtRateOne.Text = "0" Then
      txtRateOne.Text = "0"
      txtDescOne.Text = "N/A"
   End If
   If txtRateTwo.Text = "" Or txtRateTwo.Text = "0" Then
      txtRateTwo.Text = "0"
      txtDescTwo.Text = "N/A"
   End If
   If txtRateThree.Text = "" Or txtRateThree.Text = "0" Then
      txtRateThree.Text = "0"
      txtDescThree.Text = "N/A"
   End If
   
   If txtFutureRate1.Text = "0" And txtEffectiveDate1.Text = "" Then txtFutureRate1.Text = ""
   If txtFutureRate2.Text = "0" And txtEffectiveDate2.Text = "" Then txtFutureRate2.Text = ""
   If txtFutureRate3.Text = "0" And txtEffectiveDate3.Text = "" Then txtFutureRate3.Text = ""
   
   If Trim(txtFutureRate1.Text) = "" Then txtEffectiveDate1.Text = ""
   If Trim(txtFutureRate2.Text) = "" Then txtEffectiveDate2.Text = ""
   If Trim(txtFutureRate3.Text) = "" Then txtEffectiveDate3.Text = ""
   
   If Trim(txtEffectiveDate1.Text) = "" Then txtFutureRate1.Text = ""
   If Trim(txtEffectiveDate2.Text) = "" Then txtFutureRate2.Text = ""
   If Trim(txtEffectiveDate3.Text) = "" Then txtFutureRate3.Text = ""
   
   If (txtRateOne.Text <> "" And txtRateOne.Text <> "0") And (txtDescOne.Text = "" Or txtDescOne.Text = "N/A") Then
      gMsg = "Description must be set for all applied tax rates (eg, State Sales Tax)"
      txtDescOne.SetFocus
      VerifyUpdate = False
   ElseIf (txtRateTwo.Text <> "" And txtRateTwo.Text <> "0") And (txtDescTwo.Text = "" Or txtDescTwo.Text = "N/A") Then
      gMsg = "Description must be set for all applied tax rates (eg, State Sales Tax)"
      txtDescTwo.SetFocus
      VerifyUpdate = False
   ElseIf (txtRateThree.Text <> "" And txtRateThree.Text <> "0") And (txtDescThree.Text = "" Or txtDescThree.Text = "N/A") Then
      gMsg = "Description must be set for all applied tax rates (eg, State Sales Tax)"
      txtDescThree.SetFocus
      VerifyUpdate = False
   End If
  
End Function


Public Function UpdateTrigger() As Integer

End Function

