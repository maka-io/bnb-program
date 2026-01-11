VERSION 5.00
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Begin VB.Form frmMasterFactList 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Master Property Fact List"
   ClientHeight    =   4125
   ClientLeft      =   3375
   ClientTop       =   2865
   ClientWidth     =   4125
   HelpContextID   =   143
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   ScaleHeight     =   4125
   ScaleWidth      =   4125
   Begin VB.CommandButton cmdHelp 
      Caption         =   "&Help"
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
      Left            =   780
      TabIndex        =   2
      Top             =   3720
      Width           =   975
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
      Height          =   375
      Left            =   2400
      TabIndex        =   1
      Top             =   3720
      Width           =   975
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
      Top             =   4230
      Visible         =   0   'False
      Width           =   2055
   End
   Begin SSDataWidgets_B.SSDBGrid grddwListing 
      Bindings        =   "FactList.frx":0000
      Height          =   3585
      Left            =   60
      TabIndex        =   0
      Top             =   60
      Width           =   4005
      _Version        =   131078
      Cols            =   1
      AllowAddNew     =   -1  'True
      AllowDelete     =   -1  'True
      AllowGroupSizing=   0   'False
      AllowGroupMoving=   0   'False
      AllowColumnMoving=   0
      AllowGroupSwapping=   0   'False
      AllowColumnSwapping=   0
      AllowGroupShrinking=   0   'False
      AllowColumnShrinking=   0   'False
      AllowDragDrop   =   0   'False
      SelectTypeRow   =   1
      MaxSelectedRows =   1
      RowHeight       =   423
      Columns(0).Width=   3200
      _ExtentX        =   7064
      _ExtentY        =   6324
      _StockProps     =   79
      Caption         =   "Add/Edit/Delete Property Fact Topics"
   End
End
Attribute VB_Name = "frmMasterFactList"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim vTempInput As Variant
Dim SSTemp As Recordset
Dim TimesActivated As Integer
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


Private Sub cmdExit_Click()
   Unload Me
End Sub

Private Sub cmdHelp_Click()
  SendKeys "{F1}", True
End Sub

Private Sub Form_Activate()

    On Error GoTo Form_Activate_Error
    Screen.MousePointer = HOURGLASS
    If TimesActivated < 1 Then
       TimesActivated = TimesActivated + 1
       grddwListing.Columns(0).Width = grddwListing.Width
       If Not GetDCRows(datBrowse) Then GoTo Form_Activate_Resume
       grddwListing.Columns(0).Caption = ""
       grddwListing.Refresh
       grddwListing.Visible = True
    End If
    
Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

Form_Activate_Error:
   Resume Form_Activate_Resume
    
End Sub

Private Sub Form_Load()

   datBrowse.DatabaseName = gDatabaseName
   datBrowse.RecordSource = "select * from MasterPropertyFacts"
   TimesActivated = 0
   
End Sub


Private Sub grddwListing_InitColumnProps()

   grddwListing.Columns(0).Width = grddwListing.Width
   
End Sub


