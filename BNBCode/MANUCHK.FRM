VERSION 5.00
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Begin VB.Form frmManualConfDlg 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Add/Remove Confirmations"
   ClientHeight    =   3570
   ClientLeft      =   3375
   ClientTop       =   2865
   ClientWidth     =   5370
   HelpContextID   =   134
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3570
   ScaleWidth      =   5370
   Begin SSDataWidgets_B.SSDBGrid grddwListing 
      Height          =   3465
      Left            =   60
      TabIndex        =   5
      Top             =   60
      Width           =   4065
      ScrollBars      =   2
      _Version        =   131078
      DataMode        =   2
      BeginProperty HeadFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Col.Count       =   0
      AllowUpdate     =   0   'False
      AllowColumnMoving=   0
      AllowColumnShrinking=   0   'False
      SelectTypeRow   =   1
      RowHeight       =   423
      Columns(0).Width=   3200
      _ExtentX        =   7170
      _ExtentY        =   6112
      _StockProps     =   79
      Caption         =   "Confirmations"
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
   Begin VB.CommandButton cmdContinue 
      Caption         =   "C&ontinue..."
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
      Left            =   4260
      TabIndex        =   4
      Top             =   2910
      Width           =   1095
   End
   Begin VB.CommandButton cmdBack 
      Caption         =   "< Go &Back"
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
      Left            =   4260
      TabIndex        =   3
      Top             =   2190
      Width           =   1095
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
      Left            =   4260
      TabIndex        =   2
      Top             =   1470
      Width           =   1095
   End
   Begin VB.CommandButton cmdRemove 
      Caption         =   "&Remove"
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
      Left            =   4260
      TabIndex        =   1
      Top             =   750
      Width           =   1095
   End
   Begin VB.CommandButton cmdAdd 
      Caption         =   "&Add"
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
      Height          =   585
      Left            =   4260
      TabIndex        =   0
      Top             =   60
      Width           =   1095
   End
End
Attribute VB_Name = "frmManualConfDlg"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim vTempInput As Variant
Dim SSTemp As Recordset
Private Sub cmdAdd_Click()

   vTempInput = InputBox("Enter confirmation number to add.", Me.Caption, , , , App.HelpFile, 134)
   If vTempInput <> "" Then
      If Not IsNumeric(vTempInput) Then
         MsgBox "Confirmation entered must be numeric.", MB_ICONSTOP, Me.Caption
         vTempInput = ""
      Else
         'Add to list
         grddwListing.Bookmark = grddwListing.AddItemBookmark(grddwListing.Rows - 1)
         grddwListing.AddItem vTempInput
         grddwListing.Bookmark = grddwListing.AddItemBookmark(grddwListing.Rows - 1)
         gSQL = "select l_name from guesttbl where conf = " & vTempInput
         Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
         GetSSRows SSTemp
         If SSTemp.RecordCount > 0 Then grddwListing.Columns(1).Text = SSTemp(0)
         SSTemp.Close
      End If
   End If
   grddwListing.Refresh
   
End Sub


Private Sub cmdBack_Click()
   gMsg = "Return to Confirmation Selection screen and clear all current confirmation selections?"
   If MsgBox(gMsg, MB_ICONQUESTION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then Exit Sub
   ManConfDlgBack = True
   Unload Me
End Sub

Private Sub cmdCancel_Click()
   ManConfDlgCancel = True
   Unload Me
End Sub


Private Sub cmdContinue_Click()

   On Error GoTo cmdContinue_Click_Error
   
   Screen.MousePointer = HOURGLASS
   
   If grddwListing.Rows = 0 Then
      gMsg = "At least one confirmation number must be in the list"
      MsgBox gMsg, MB_ICONSTOP, Me.Caption
      GoTo cmdContinue_Click_Resume
   End If
   frmCheckDlg.cmdContinue.Caption = "&Continue..."
  ' MsgBox Str(grddwListing.Rows - 1)
   'ReDim ConfArray(grddwListing.Rows)
   Erase ConfArray
   'ReDim ConfArray(grddwListing.Rows)
   Erase ConfArray
   For i = 0 To grddwListing.Rows - 1
      grddwListing.Bookmark = grddwListing.AddItemBookmark(i)
      ConfArray(i) = grddwListing.Columns(0).Text
      'MsgBox ConfArray(i)
   Next i
   ManConfDlgContinue = True
   Unload Me

cmdContinue_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdContinue_Click_Error:
   Resume cmdContinue_Click_Resume
   
End Sub


Private Sub cmdRemove_Click()

   If grddwListing.SelBookmarks.Count > 0 Then
      grddwListing.RemoveItem grddwListing.AddItemRowIndex(grddwListing.Bookmark)
   Else
      gMsg = "Select the confirmation number to remove from the list"
      MsgBox gMsg, MB_ICONSTOP, Me.Caption
   End If
   grddwListing.Refresh
   
End Sub


Private Sub Form_Activate()

    On Error GoTo Form_Activate_Error
    
    Dim j As Long
    Screen.MousePointer = HOURGLASS
    DoEvents
    ManConfDlgContinue = False
    ManConfDlgBack = False
    ManConfDlgCancel = False
    
    grddwListing.Columns(0).Caption = "Confirmation"
    grddwListing.Columns(1).Caption = "Name"
    grddwListing.Refresh
    '*** Note! If redraw is set to false and there are lots of rows to populate,
    '*** some cells will be left blank! So, don't set it to false.
    'grddwListing.Redraw = False
    grddwListing.Visible = False
    'Initialize grid
    grddwListing.AddItem ""
    'Load Data
    For j = 0 To UBound(ConfArray) - 1
       grddwListing.Bookmark = grddwListing.AddItemBookmark(j)
       'For i = 0 To 1
       If IsNull(ConfArray(j)) Or ConfArray(j) = 0 Then
          Exit For
          'Do nothing
       Else
          grddwListing.Columns(0).Text = ConfArray(j)
          gSQL = "select l_name from guesttbl where conf = " & ConfArray(j)
          Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
          GetSSRows SSTemp
          If SSTemp.RecordCount > 0 Then grddwListing.Columns(1).Text = SSTemp(0)
          SSTemp.Close
       End If
    Next j
    'Remove any blank row (specifically, last AddItem row) from grid
    For j = 0 To grddwListing.Rows - 1
       grddwListing.Bookmark = grddwListing.AddItemBookmark(j)
       If grddwListing.Columns(0).Text = "0" Or grddwListing.Columns(0).Text = "" Then
         grddwListing.RemoveItem grddwListing.AddItemRowIndex(grddwListing.Bookmark)
         Exit For
       End If
    Next j
    'Move to top
    grddwListing.Bookmark = grddwListing.AddItemBookmark(0)
    grddwListing.Refresh
    grddwListing.Visible = True
    
Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

Form_Activate_Error:
   Resume Form_Activate_Resume
    
End Sub

