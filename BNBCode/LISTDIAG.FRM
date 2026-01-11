VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmListDialog 
   Caption         =   "Listing Report Sort Options Dialog"
   ClientHeight    =   4830
   ClientLeft      =   1575
   ClientTop       =   2055
   ClientWidth     =   8520
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4830
   ScaleWidth      =   8520
   Begin VB.OptionButton optSortOrderChanged 
      Caption         =   "SortOrderChanged"
      Height          =   255
      Left            =   720
      TabIndex        =   16
      Top             =   5190
      Width           =   1695
   End
   Begin VB.Frame fraDateFormat 
      Caption         =   "Date Format"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1605
      Left            =   120
      TabIndex        =   15
      Top             =   3180
      Width           =   4095
      Begin VB.ComboBox txtComboDateFormat 
         Height          =   315
         ItemData        =   "LISTDIAG.frx":0000
         Left            =   360
         List            =   "LISTDIAG.frx":0002
         TabIndex        =   8
         Text            =   "m/d/yyyy"
         Top             =   360
         Width           =   3255
      End
      Begin VB.Label Label1 
         Caption         =   "Sample Format:"
         Height          =   315
         Left            =   360
         TabIndex        =   18
         Top             =   900
         Width           =   1335
      End
      Begin VB.Label lblSampleDate 
         Caption         =   "1/31/1998"
         Height          =   465
         Left            =   1800
         TabIndex        =   17
         Top             =   900
         Width           =   1815
      End
   End
   Begin VB.TextBox txtCallingFormCaption 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   2460
      TabIndex        =   14
      Text            =   "txtCallingFormCaption"
      Top             =   4950
      Width           =   2295
   End
   Begin VB.OptionButton optCancelled 
      Caption         =   "Cancelled"
      Height          =   255
      Left            =   720
      TabIndex        =   13
      Top             =   4920
      Width           =   1335
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "&OK"
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
      Height          =   615
      Left            =   7200
      TabIndex        =   11
      Top             =   4200
      Width           =   1215
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
      Height          =   615
      Left            =   5820
      TabIndex        =   10
      Top             =   4200
      Width           =   1215
   End
   Begin VB.CommandButton cmdFonts 
      Caption         =   "&Fonts"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   4440
      TabIndex        =   9
      Top             =   4200
      Width           =   1215
   End
   Begin VB.Frame fraColumnOrder 
      Caption         =   "Column Order"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2955
      Left            =   4320
      TabIndex        =   12
      Top             =   120
      Width           =   4095
      Begin VB.CommandButton cmdColMoveDown 
         Caption         =   "Move Down"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   2760
         TabIndex        =   7
         Top             =   1080
         Width           =   1215
      End
      Begin VB.CommandButton cmdColMoveUp 
         Caption         =   "Move Up"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   2760
         TabIndex        =   6
         Top             =   540
         Width           =   1215
      End
      Begin VB.ListBox lstColumnOrder 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   2205
         ItemData        =   "LISTDIAG.frx":0004
         Left            =   240
         List            =   "LISTDIAG.frx":0006
         TabIndex        =   5
         Top             =   240
         Width           =   2415
      End
   End
   Begin VB.Frame fraSortOrder 
      Caption         =   "Row Sort Order"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2955
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   4095
      Begin VB.CommandButton cmdSortMoveDown 
         Caption         =   "Move Down"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   2760
         TabIndex        =   3
         Top             =   1080
         Width           =   1215
      End
      Begin VB.CommandButton cmdSortMoveUp 
         Caption         =   "Move Up"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   2760
         TabIndex        =   2
         Top             =   540
         Width           =   1215
      End
      Begin VB.ListBox lstSortOrder 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   2205
         ItemData        =   "LISTDIAG.frx":0008
         Left            =   240
         List            =   "LISTDIAG.frx":000A
         TabIndex        =   1
         Top             =   240
         Width           =   2415
      End
      Begin Threed.SSCheck chkDescending 
         Height          =   255
         Left            =   240
         TabIndex        =   4
         Top             =   2550
         Width           =   2055
         _Version        =   65536
         _ExtentX        =   3625
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Sort in descending order"
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
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   120
      Top             =   4890
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
End
Attribute VB_Name = "frmListDialog"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LastErr As Long     'The last error number returned by VB.
Dim CallingForm As Form
Dim CallingGrid As Control
Dim SampleDate As Variant
Dim FC As Integer       'Integer expression of lblFixedColsValue.Caption.
Dim xx As Integer       'Counter
Dim TimesActivated As Integer
Dim i As Integer
Dim OrigDescOrderChkBox As Integer
Dim SAW As Long

Private Sub cmdCancel_Click()
    
    On Error GoTo cmdCancel_Click_Error
    
    optCancelled = True
    cmdOK.SetFocus
    frmListDialog.Hide
    DoEvents

cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume
   
End Sub


Private Sub cmdColMoveDown_Click()
    'This routine will move the selected list item up one position in the list box.
    ChangeColumnListPosition 1
    'It is recommended to resize the columns after recordering the columns

End Sub

Private Sub cmdColMoveUp_Click()
    'This routine will move the selected list item up one position in the list box.
    ChangeColumnListPosition -1
    'It is recommended to resize the columns after reordering the columns

End Sub

Private Sub cmdFonts_Click()

    On Error GoTo cmdFont_Err

    'Set Common Dialog Font Properites
    CMDialog1.Flags = CF_SCREENFONTS
    CMDialog1.FontName = CallingGrid.Font.Name
    CMDialog1.FontSize = CallingGrid.Font.Size
    CMDialog1.FontBold = CallingGrid.Font.Bold
    CMDialog1.FontItalic = CallingGrid.Font.Italic
    CMDialog1.CancelError = True
    CMDialog1.Max = 72  'Pertains to font size now.
    
    'Activate Font Dialog Box
    CMDialog1.ShowFont  'CMDialog1.Action = 4

cmdFont_Resume:
   cmdOK.SetFocus
   Exit Sub

cmdFont_Err:
   'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
   If Err = cdlCancel Then
      'This will keep background screens from other applications
      'gaining focus mysteriously upon closure of common dialog.
      SAW = SetActiveWindow(mdiBNB.hwnd)
   Else
      MsgBox Err.Description
   End If
   Resume cmdFont_Resume

End Sub



Private Sub cmdOK_Click()
      
   If OrigDescOrderChkBox <> chkDescending.Value Then optSortOrderChanged.Value = CHECKED
   optCancelled = False
   frmListDialog.Hide
   DoEvents

End Sub

Private Sub cmdSortMoveDown_Click()
    'This routine will move the selected list item up one position in the list box.
    ChangeSortListPosition 1
    'It is recommended to resize the columns after recordering the columns

End Sub

Private Sub cmdSortMoveUp_Click()
    'This routine will move the selected list item up one position in the list box.
    ChangeSortListPosition -1
    'It is recommended to resize the columns after reordering the columns

End Sub

Private Sub txtComboDateFormat_Change()

    On Error GoTo txtComboDateFormat_Change_Error
    'Change the displayed sample date as the date format changes.
    lblSampleDate.Caption = Format$(SampleDate, txtComboDateFormat.Text)

    'Do not let the user OK this form with an invalid date format string.
    If lblSampleDate.Caption = "Invalid Format String" Then
        cmdOK.Enabled = False
    Else
        cmdOK.Enabled = True
        'If a column format was changed, then it is recommended that the grid columns be automatically resized.
        'chk3dSizeColumns.Value = True
    End If

Exit Sub

txtComboDateFormat_Change_Error:
    lblSampleDate.Caption = "Invalid Format String"
    Resume Next

End Sub

Private Sub txtComboDateFormat_Click()
   Call txtComboDateFormat_Change
End Sub


Private Sub Form_Activate()

  On Error GoTo Form_Activate_Error

  'If this form is in the background (does not have focus) and the
  'Minimize button is clicked on this form that does not yet have the focus,
  'an endless loop of Minimizing and Activating will occur. The following
  'line prevents this interesting problem.
  If Me.WindowState = MINIMIZED Then Exit Sub

  TimesActivated = TimesActivated + 1
  optSortOrderChanged.Value = UNCHECKED
  OrigDescOrderChkBox = chkDescending.Value
  optCancelled.Value = UNCHECKED
  lstColumnOrder.Clear
  lstSortOrder.Clear
  cmdColMoveUp.Enabled = False
  cmdColMoveDown.Enabled = False
  cmdSortMoveUp.Enabled = False
  cmdSortMoveDown.Enabled = False
  '**************** Load Sort ListBox
  If CallingForm.lstSortOrderSave.List(0) = "" Then
     'Load column names from data source
     For i = 0 To CallingForm.datListing.Recordset.Fields.Count - 1
        lstSortOrder.AddItem CallingForm.datListing.Recordset.Fields(i).Name
     Next i
  Else  'Load from Saved Sort Order list box
     For i = 0 To CallingForm.lstSortOrderSave.ListCount - 1
        lstSortOrder.AddItem CallingForm.lstSortOrderSave.List(i)
     Next i
  End If
  'Don't allow sort if only one (or less) row exists in grid
  If CallingForm.datListing.Recordset.RecordCount < 2 Then
     lstSortOrder.Enabled = False
     chkDescending.Enabled = False
     cmdSortMoveUp.Enabled = False
     cmdSortMoveDown.Enabled = False
  Else
     lstSortOrder.Enabled = True
     chkDescending.Enabled = True
  End If
  '**************** Load Column ListBox
  Dim j, k As Integer
  Dim TempStr As String
  DoEvents
  For j = 0 To CallingForm.datListing.Recordset.Fields.Count - 1
    'Find position of jth  element
    For i = 0 To CallingForm.datListing.Recordset.Fields.Count - 1
      If CallingGrid.Columns(i).Position = j Then
        TempStr = CallingGrid.Columns(i).Caption
        lstColumnOrder.AddItem TempStr, j
        Exit For
      End If
    Next i
  Next j

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
  
Form_Activate_Error:
   Resume Form_Activate_Resume
  
End Sub

Private Sub Form_Load()

    'Set sample date (module level variable)
    SampleDate = CDate("7/27/98 15:10:23")
    'Load a selection of possible date formats into date format combo list.
    txtComboDateFormat.AddItem "AM/PM"
    txtComboDateFormat.AddItem "c"
    txtComboDateFormat.AddItem "ddd"
    txtComboDateFormat.AddItem "dddd"
    txtComboDateFormat.AddItem "dd-mmm-yy"
    txtComboDateFormat.AddItem "dd-mmmm-yy"
    txtComboDateFormat.AddItem "h:mm:ss"
    txtComboDateFormat.AddItem "m/d/yy"
    txtComboDateFormat.AddItem "mm/dd/yy"
    txtComboDateFormat.AddItem "mm/dd/yy h:mm"
    txtComboDateFormat.AddItem "m/d/yyyy"
    txtComboDateFormat.AddItem "mm/dd/yyyy"
    txtComboDateFormat.AddItem "mm/dd/yyyy h:mm"
    txtComboDateFormat.AddItem "dd-mmm-yy h:mm"
    txtComboDateFormat.AddItem "dd-mmm-yy h:mm:ss"
    txtComboDateFormat.AddItem "ddd dd-mmmm-yy h:mm:ss am/pm"
    txtComboDateFormat.AddItem "\Qq yy"
    txtComboDateFormat.AddItem "\Www yyyy"
    txtComboDateFormat.AddItem "\Dy yyyy"
    TimesActivated = 0

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

Private Sub lstColumnOrder_Click()
    'Disable/Enable the Move Up (Down) command buttons if the selected
    'item in the list is the first (last) item in the list.
    If lstColumnOrder.ListIndex = 0 Then
        cmdColMoveUp.Enabled = False
        cmdColMoveDown.Enabled = True
    ElseIf lstColumnOrder.ListIndex = lstColumnOrder.ListCount - 1 Then
        'The last item in the list box.
        cmdColMoveUp.Enabled = True
        cmdColMoveDown.Enabled = False
    Else
        'Any other item in the list.
        cmdColMoveUp.Enabled = True
        cmdColMoveDown.Enabled = True
    End If

End Sub

Private Sub lstSortOrder_Click()
    'Disable/Enable the Move Up (Down) command buttons if the selected
    'item in the list is the first (last) item in the list.
    If lstSortOrder.ListIndex = 0 Then
        cmdSortMoveUp.Enabled = False
        cmdSortMoveDown.Enabled = True
    ElseIf lstSortOrder.ListIndex = lstSortOrder.ListCount - 1 Then
        'The last item in the list box.
        cmdSortMoveUp.Enabled = True
        cmdSortMoveDown.Enabled = False
    Else
        'Any other item in the list.
        cmdSortMoveUp.Enabled = True
        cmdSortMoveDown.Enabled = True
    End If

End Sub

Private Sub txtCallingFormCaption_Change()
    
    'Run thru the Forms collection and identify the calling form.
    For i = 0 To Forms.Count - 1
        If Forms(i).Caption = txtCallingFormCaption.Text Then
            Set CallingForm = Forms(i)
            Exit For
        End If
    Next

    If txtCallingFormCaption.Text Like "*Listing*" Then
        'Run thru the Control collection and identify the calling form's grid.
        For i = 0 To CallingForm.Controls.Count - 1
            If TypeOf CallingForm.Controls(i) Is SSDBGrid Then
                Set CallingGrid = CallingForm.Controls(i)
                Exit For
            End If
        Next

    Else
        'Do nothing
    End If
    InitializeCommonDialogBox

End Sub



Public Sub InitializeCommonDialogBox()

    'Set Common Dialog Font Properites
    CMDialog1.DialogTitle = txtCallingFormCaption.Text & " Fonts"
    CMDialog1.Min = 1
    CMDialog1.FontBold = CallingGrid.Font.Bold
    CMDialog1.FontItalic = CallingGrid.Font.Italic
'    CMDialog1.FontStrikethru = CallingGrid.Font.Strikethru
    CMDialog1.FontUnderline = CallingGrid.Font.Underline
    CMDialog1.FontName = CallingGrid.Font.Name
    CMDialog1.FontSize = CallingGrid.Font.Size

End Sub

Public Sub ChangeColumnListPosition(Delta As Integer)

    'This routine will move the selected list item up or down Delta position(s) in the list box.
    'An upward move is a negative delta, whereas a downward move is a positive delta.
    'Note that this routine does not work for a multi-select list box.

    'If no item is current then exit.
    If lstColumnOrder.ListIndex < 0 Then Exit Sub

    'Declare variables.
    Dim Temp$, ID%, OldIndex%

    'Record ListIndex, List and ItemData for current row prior to removing it.
    OldIndex% = lstColumnOrder.ListIndex
    Temp$ = lstColumnOrder.List(lstColumnOrder.ListIndex)
    ID% = lstColumnOrder.ItemData(lstColumnOrder.ListIndex)

    'First remove the item from its current position in the list.
    lstColumnOrder.RemoveItem lstColumnOrder.ListIndex

    'Next, insert the item in its new position in the list.
    lstColumnOrder.AddItem Temp$, OldIndex% + Delta
    lstColumnOrder.ItemData(lstColumnOrder.NewIndex) = ID%
    lstColumnOrder.Selected(lstColumnOrder.NewIndex) = True
        
    CallingForm.lstColumnOrderSave.Clear
    For i = 0 To lstColumnOrder.ListCount - 1
      CallingForm.lstColumnOrderSave.AddItem lstColumnOrder.List(i)
    Next i

End Sub

Public Sub ChangeSortListPosition(Delta As Integer)

    'This routine will move the selected list item up or down Delta position(s) in the list box.
    'An upward move is a negative delta, whereas a downward move is a positive delta.
    'Note that this routine does not work for a multi-select list box.

    'If no item is current then exit.
    If lstSortOrder.ListIndex < 0 Then Exit Sub

    'Declare variables.
    Dim Temp$, ID%, OldIndex%

    'Record ListIndex, List and ItemData for current row prior to removing it.
    OldIndex% = lstSortOrder.ListIndex
    Temp$ = lstSortOrder.List(lstSortOrder.ListIndex)
    ID% = lstSortOrder.ItemData(lstSortOrder.ListIndex)

    'First remove the item from its current position in the list.
    lstSortOrder.RemoveItem lstSortOrder.ListIndex
'MsgBox "Removed ListIndex# " & OldIndex% & ", " & Temp$ & " , representing result set column " & ID% & "."

    'Next, insert the item in its new position in the list.
    lstSortOrder.AddItem Temp$, OldIndex% + Delta
    lstSortOrder.ItemData(lstSortOrder.NewIndex) = ID%
    lstSortOrder.Selected(lstSortOrder.NewIndex) = True
    
    optSortOrderChanged.Value = CHECKED
    CallingForm.lstSortOrderSave.Clear
    For i = 0 To lstSortOrder.ListCount - 1
      CallingForm.lstSortOrderSave.AddItem lstSortOrder.List(i)
    Next i
'MsgBox "Added ListIndex# " & lstSortOrder.NewIndex & ", " & lstSortOrder.List(lstSortOrder.NewIndex) & " , representing result set column " & lstSortOrder.ItemData(lstSortOrder.NewIndex) & "."

End Sub

