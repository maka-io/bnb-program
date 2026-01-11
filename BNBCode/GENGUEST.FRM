VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmGeneralGuest 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Guest General Information"
   ClientHeight    =   6000
   ClientLeft      =   1545
   ClientTop       =   1965
   ClientWidth     =   8925
   HelpContextID   =   100
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   6000
   ScaleWidth      =   8925
   Tag             =   "guesttbl"
   Begin VB.TextBox txtEmail 
      Appearance      =   0  'Flat
      DataField       =   "Email"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   5160
      MaxLength       =   120
      TabIndex        =   14
      Tag             =   "Text"
      Top             =   1170
      Width           =   2175
   End
   Begin VB.TextBox txtFindSQL 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   6960
      TabIndex        =   23
      TabStop         =   0   'False
      Tag             =   "Text"
      Top             =   3840
      Visible         =   0   'False
      Width           =   375
   End
   Begin VB.CommandButton cmdLabels 
      Caption         =   "Print &Labels"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   465
      Left            =   7560
      TabIndex        =   31
      Top             =   3870
      Width           =   1335
   End
   Begin Threed.SSCheck chkSuppress 
      DataField       =   "lbl_flag"
      DataSource      =   "datBrowse"
      Height          =   225
      Left            =   3840
      TabIndex        =   21
      Top             =   3810
      Width           =   2475
      _Version        =   65536
      _ExtentX        =   4366
      _ExtentY        =   397
      _StockProps     =   78
      Caption         =   "Suppress from mailing labels"
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
   Begin VB.TextBox txtRevDate 
      Appearance      =   0  'Flat
      DataField       =   "revdate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   5655
      TabIndex        =   20
      Tag             =   "Date"
      Top             =   3300
      Width           =   1695
   End
   Begin Threed.SSCheck chkRevision 
      DataField       =   "revision"
      DataSource      =   "datBrowse"
      Height          =   255
      Left            =   4695
      TabIndex        =   19
      Top             =   3330
      Width           =   315
      _Version        =   65536
      _ExtentX        =   556
      _ExtentY        =   450
      _StockProps     =   78
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
   Begin VB.TextBox txtUpdateDate 
      Appearance      =   0  'Flat
      DataField       =   "UpdateDate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   3660
      TabIndex        =   56
      TabStop         =   0   'False
      Tag             =   "Date"
      Top             =   6120
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.TextBox txtUpdateUser 
      Appearance      =   0  'Flat
      DataField       =   "UpdateUser"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   3360
      TabIndex        =   55
      TabStop         =   0   'False
      Tag             =   "Text"
      Top             =   6120
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.TextBox txtEntryDate 
      Appearance      =   0  'Flat
      DataField       =   "EntryDate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   3060
      TabIndex        =   54
      TabStop         =   0   'False
      Tag             =   "Date"
      Top             =   6120
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.TextBox txtEntryUser 
      Appearance      =   0  'Flat
      DataField       =   "EntryUser"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   2760
      TabIndex        =   53
      TabStop         =   0   'False
      Tag             =   "Text"
      Top             =   6120
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.TextBox txtDateBooked 
      Appearance      =   0  'Flat
      DataField       =   "datebkd"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   5175
      TabIndex        =   18
      Tag             =   "Date"
      Top             =   2940
      Width           =   2175
   End
   Begin VB.CommandButton cmdGoTo 
      Caption         =   "&Go to..."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   510
      Left            =   7560
      TabIndex        =   34
      Top             =   5460
      Width           =   1335
   End
   Begin VB.CommandButton cmdDisplayRows 
      Caption         =   "Display &Rows"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   510
      Left            =   7560
      TabIndex        =   29
      Top             =   2790
      Width           =   1335
   End
   Begin VB.TextBox txtReferredBy 
      Appearance      =   0  'Flat
      DataField       =   "referral"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   100
      TabIndex        =   9
      Tag             =   "Text"
      Top             =   2970
      Width           =   2235
   End
   Begin VB.TextBox txtResFee 
      Appearance      =   0  'Flat
      DataField       =   "resfee"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   5175
      TabIndex        =   16
      Tag             =   "Currency"
      Top             =   2220
      Width           =   1215
   End
   Begin VB.TextBox txtBookedBy 
      Appearance      =   0  'Flat
      DataField       =   "bookedby"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   5175
      MaxLength       =   25
      TabIndex        =   17
      Tag             =   "Text"
      Top             =   2580
      Width           =   2175
   End
   Begin VB.TextBox txtTravWith 
      Appearance      =   0  'Flat
      DataField       =   "travwith"
      DataSource      =   "datBrowse"
      Height          =   615
      Left            =   5175
      MaxLength       =   250
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   15
      Tag             =   "Text"
      Top             =   1530
      Width           =   2175
   End
   Begin VB.TextBox txtBlindComment 
      Appearance      =   0  'Flat
      DataField       =   "cmmnts"
      DataSource      =   "datBrowse"
      Height          =   660
      Left            =   1440
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   10
      Tag             =   "Text"
      Top             =   3330
      Width           =   2235
   End
   Begin VB.CommandButton cmdCommonText 
      Caption         =   "Common &Text"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   510
      Left            =   7560
      TabIndex        =   30
      TabStop         =   0   'False
      Top             =   3330
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
      Height          =   510
      Left            =   7560
      TabIndex        =   28
      TabStop         =   0   'False
      Top             =   2250
      Width           =   1335
   End
   Begin VB.TextBox txtFaxNumber 
      Appearance      =   0  'Flat
      DataField       =   "faxnum"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   5160
      MaxLength       =   25
      TabIndex        =   13
      Tag             =   "Text"
      Top             =   810
      Width           =   2175
   End
   Begin VB.TextBox txtBusPhone 
      Appearance      =   0  'Flat
      DataField       =   "bsphone"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   5160
      MaxLength       =   25
      TabIndex        =   12
      Tag             =   "Text"
      Top             =   450
      Width           =   2175
   End
   Begin VB.TextBox txtHomePhone 
      Appearance      =   0  'Flat
      DataField       =   "hmphone"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   5160
      MaxLength       =   25
      TabIndex        =   11
      Tag             =   "Text"
      Top             =   90
      Width           =   2175
   End
   Begin VB.TextBox txtZipcode 
      Appearance      =   0  'Flat
      DataField       =   "zipcode"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   25
      TabIndex        =   8
      Tag             =   "Text"
      Top             =   2610
      Width           =   2235
   End
   Begin VB.TextBox txtState 
      Appearance      =   0  'Flat
      DataField       =   "state"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   25
      TabIndex        =   7
      Tag             =   "Text"
      Top             =   2250
      Width           =   2235
   End
   Begin VB.TextBox txtCity 
      Appearance      =   0  'Flat
      DataField       =   "city"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   25
      TabIndex        =   6
      Tag             =   "Text"
      Top             =   1890
      Width           =   2235
   End
   Begin VB.TextBox txtAddress 
      Appearance      =   0  'Flat
      DataField       =   "address"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   30
      TabIndex        =   5
      Tag             =   "Text"
      Top             =   1530
      Width           =   2235
   End
   Begin VB.TextBox txtCompany 
      Appearance      =   0  'Flat
      DataField       =   "busadd"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   30
      TabIndex        =   4
      Tag             =   "Text"
      Top             =   1170
      Width           =   2235
   End
   Begin VB.TextBox txtLastName 
      Appearance      =   0  'Flat
      DataField       =   "l_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   25
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   810
      Width           =   2235
   End
   Begin VB.TextBox txtFirstName 
      Appearance      =   0  'Flat
      DataField       =   "f_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   25
      TabIndex        =   2
      Tag             =   "Text"
      Top             =   450
      Width           =   2235
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
      Height          =   510
      Left            =   7560
      TabIndex        =   33
      TabStop         =   0   'False
      Top             =   4920
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
      Height          =   510
      Left            =   7560
      TabIndex        =   32
      TabStop         =   0   'False
      Top             =   4380
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
      Height          =   510
      Left            =   7560
      TabIndex        =   27
      TabStop         =   0   'False
      Top             =   1710
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
      Height          =   510
      Left            =   7560
      TabIndex        =   26
      TabStop         =   0   'False
      Top             =   1170
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
      Height          =   510
      Left            =   7560
      TabIndex        =   25
      TabStop         =   0   'False
      Top             =   630
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
      Height          =   510
      Left            =   7560
      TabIndex        =   24
      TabStop         =   0   'False
      Top             =   90
      Width           =   1335
   End
   Begin VB.TextBox txtConfNum 
      Appearance      =   0  'Flat
      DataField       =   "conf"
      DataSource      =   "datBrowse"
      ForeColor       =   &H00000000&
      Height          =   285
      Left            =   1440
      MaxLength       =   9
      TabIndex        =   1
      Tag             =   "Number"
      Top             =   90
      Width           =   1215
   End
   Begin VB.TextBox txtClosing 
      Appearance      =   0  'Flat
      DataField       =   "closeure"
      DataSource      =   "datBrowse"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1365
      Left            =   120
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   22
      Tag             =   "Text"
      Top             =   4200
      Width           =   7215
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
      Left            =   600
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   6090
      Visible         =   0   'False
      Width           =   2055
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "GENGUEST.frx":0000
      Height          =   330
      Left            =   120
      TabIndex        =   0
      Top             =   5640
      Width           =   7215
      _Version        =   131075
      _ExtentX        =   12726
      _ExtentY        =   582
      _StockProps     =   79
      BackColor       =   16777215
      ShowAddButton   =   0   'False
      ShowCancelButton=   0   'False
      ShowDelButton   =   0   'False
      ShowUpdateButton=   0   'False
      BevelOuter      =   0
      PageValue       =   5
      ShowBookmarkButtons=   0
      ShowFindButtons =   0
   End
   Begin VB.Label lblEmail 
      Caption         =   "E-mail Address:"
      Height          =   255
      Left            =   3840
      TabIndex        =   59
      Top             =   1200
      Width           =   1215
   End
   Begin VB.Label lblRevDate 
      Caption         =   "Date:"
      Height          =   255
      Left            =   5055
      TabIndex        =   58
      Top             =   3330
      Width           =   555
   End
   Begin VB.Label lblRevision 
      Caption         =   "Revision:"
      Height          =   255
      Left            =   3855
      TabIndex        =   57
      Top             =   3330
      Width           =   735
   End
   Begin VB.Label lblReferredBy 
      Caption         =   "Referred By:"
      Height          =   255
      Left            =   120
      TabIndex        =   52
      Top             =   3000
      Width           =   1275
   End
   Begin VB.Label lblResFee 
      Caption         =   "Reservation Fee:"
      Height          =   255
      Left            =   3855
      TabIndex        =   51
      Top             =   2250
      Width           =   1275
   End
   Begin VB.Label lblDateBooked 
      Caption         =   "Date Booked:"
      Height          =   255
      Left            =   3855
      TabIndex        =   50
      Top             =   2970
      Width           =   1215
   End
   Begin VB.Label lblBookedBy 
      Caption         =   "Booked By:"
      Height          =   255
      Left            =   3855
      TabIndex        =   49
      Top             =   2610
      Width           =   1215
   End
   Begin VB.Label lblTravWith 
      Caption         =   "Travelling With:"
      Height          =   255
      Left            =   3840
      TabIndex        =   48
      Top             =   1560
      Width           =   1215
   End
   Begin VB.Label lblClosure 
      Caption         =   "Confirmation Closure:"
      Height          =   255
      Left            =   120
      TabIndex        =   47
      Top             =   3990
      Width           =   1755
   End
   Begin VB.Label lblBlindComment 
      Caption         =   "Blind Comment:"
      Height          =   255
      Left            =   120
      TabIndex        =   46
      Top             =   3360
      Width           =   1275
   End
   Begin VB.Label lblFaxNumber 
      Caption         =   "Fax Number:"
      Height          =   255
      Left            =   3840
      TabIndex        =   45
      Top             =   840
      Width           =   1215
   End
   Begin VB.Label lblBusPhone 
      Caption         =   "Bus Phone:"
      Height          =   255
      Left            =   3840
      TabIndex        =   44
      Top             =   480
      Width           =   1215
   End
   Begin VB.Label lblHomePhone 
      Caption         =   "Home Phone:"
      Height          =   255
      Left            =   3840
      TabIndex        =   43
      Top             =   120
      Width           =   1215
   End
   Begin VB.Label lblZipcode 
      Caption         =   "Zipcode:"
      Height          =   255
      Left            =   120
      TabIndex        =   42
      Top             =   2640
      Width           =   855
   End
   Begin VB.Label lblState 
      Caption         =   "State:"
      Height          =   255
      Left            =   120
      TabIndex        =   41
      Top             =   2280
      Width           =   855
   End
   Begin VB.Label lblCity 
      Caption         =   "City:"
      Height          =   255
      Left            =   120
      TabIndex        =   40
      Top             =   1920
      Width           =   855
   End
   Begin VB.Label lblAddress 
      Caption         =   "Address:"
      Height          =   255
      Left            =   120
      TabIndex        =   39
      Top             =   1560
      Width           =   855
   End
   Begin VB.Label lblCompany 
      Caption         =   "Company:"
      Height          =   255
      Left            =   120
      TabIndex        =   38
      Top             =   1200
      Width           =   1095
   End
   Begin VB.Label lblLastName 
      Caption         =   "Last Name:"
      Height          =   255
      Left            =   120
      TabIndex        =   37
      Top             =   840
      Width           =   1095
   End
   Begin VB.Label lblFirstName 
      Caption         =   "First Name:"
      Height          =   255
      Left            =   120
      TabIndex        =   36
      Top             =   480
      Width           =   1095
   End
   Begin VB.Label lblConfNum 
      Caption         =   "Conf Number:"
      Height          =   255
      Left            =   120
      TabIndex        =   35
      Top             =   120
      Width           =   1095
   End
End
Attribute VB_Name = "frmGeneralGuest"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
'CurrRec holds the number of the current record displayed on the screen
Dim CurrRec As Long
Dim SaveRec As Long
Dim NullDateArray()
Dim SetFocusTo As String
Dim OrigFirstName, OrigLastName As String

Private Sub chkRevision_Click(Value As Integer)

  If GetFormMode(Me) = "Find" Then Exit Sub
  
  If chkRevision.Value = CHECKED Then
     txtRevDate.Enabled = True
     If Trim(txtRevDate.Text) = "" Then
        txtRevDate.Text = Format(Now, "m/d/yyyy")
     End If
  Else
     txtRevDate.Enabled = False
     txtRevDate.Text = ""
  End If

End Sub

Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error

   Select Case GetFormMode(Me)
     Case "Insert"
        'Delete must be before CancelUpdate because return to browse mode will reset gConfNum.
        gBNB.Execute "delete * from GuestInsertControl where conf = " & gConfNum & " and ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
        If datBrowse.Recordset.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
        lblRevision.Enabled = True
        lblRevDate.Enabled = True
        chkRevision.Enabled = True
        txtRevDate.Enabled = True
        txtConfNum.Locked = False
        txtConfNum.ForeColor = BLUE
        'MsgBox Str$(gConfNum)
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
     txtConfNum.SetFocus
   End If
   'datBrowse.Refresh

cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume

End Sub

Private Sub cmdCommonText_Click()
 
   frmCommonText.Show 1
   
End Sub

Private Sub cmdCommit_Click()
    
    On Error GoTo cmdCommit_Click_Error
    Dim RetVal As Integer
    Dim SSTemp As Recordset
    
    Screen.MousePointer = HOURGLASS
        
    Select Case GetFormMode(Me)
      Case "Insert"
        'InsertedConfNum holds the conf number for the just-inserted record.
        'Necessary because txtConfNum_Change event will reset it back
        'immediately after the update to the value it had when it was browsing.
        '(This is because the bookmark before the insert is the same as that after the insert.)
        'This only necessary when Insert is clicked from browse mode.
        Dim InsertedConfNum As Long
        'Fillin system Date/User fields
        txtEntryUser.Text = gComputerName
        txtEntryDate.Text = Format(Now, "m/d/yyyy")
        txtUpdateUser.Text = gComputerName
        txtUpdateDate.Text = Format(Now, "m/d/yyyy")
        'Check for valid dates and number formats
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'If number formats are OK, then set currency formats
        SetToCurrencyFormat Me
        'Check for specifics of frmGeneralGuest
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
        'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
        'unbind control's DataField property and commit Null.
        InsertedConfNum = CLng(Trim$(txtConfNum.Text))
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & InsertedConfNum
        If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
        'Do if there was at least one Date or Number was set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        'If successful update, update the GuestInsertControl table
        gBNB.Execute "delete * from GuestInsertControl where conf = " & InsertedConfNum
        'At this point, gConfNum would be reset as noted above, reset it to
        'newly-inserted record.
        'This is the gConfNum assignment that will carry through the data entry process.
        'The others were used to control the GuestInsertControl table.
        gConfNum = InsertedConfNum
        SetToCurrencyFormat Me
      Case "Update"
        'Fillin system Date/User fields
        txtUpdateUser.Text = gComputerName
        txtUpdateDate.Text = Format(Now, "m/d/yyyy")
        'Using RevDate here instead of just using UpdateDate to preserve HBBB
        'historical data. Update and Entry dates will be blank upon conversion.
        'Fillin if user left it blank and chkRevision was checked.
        If chkRevision.Value = CHECKED And Trim(txtRevDate.Text) = "" Then
           txtRevDate.Text = Format(Now, "m/d/yyyy")
        End If
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'If number formats are OK, then set currency formats
        SetToCurrencyFormat Me
        'Check for specifics of frmGeneralGuest
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
        'Update guest first name if changed
        If Trim(txtFirstName.Text) <> OrigFirstName Then
           If Not UpdateGuestName(txtFirstName, "First") Then
              MsgBox gMsg, MB_ICONSTOP, Me.Caption
              GoTo cmdCommit_Click_Resume
           End If
        End If
        'Update guest last name if changed
        If Trim(txtLastName.Text) <> OrigLastName Then
           If Not UpdateGuestName(txtLastName, "Last") Then
              MsgBox gMsg, MB_ICONSTOP, Me.Caption
              GoTo cmdCommit_Click_Resume
           End If
        End If
        'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
        'unbind control's DataField property and commit Null.
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        'Do if there was at least one Date or Number was set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        'Make the current record current again
        datBrowse.UpdateControls
        SetToCurrencyFormat Me
      Case "Delete"
        Dim vPayRecFromGuest, vPayToHost, vPayToTravel As Integer
        'Payments received from guest?
        Set SSTemp = gBNB.OpenRecordset("select conf from PaymentReceived where conf = " & gConfNum, dbOpenSnapshot)
        GetSSRows SSTemp
        If SSTemp.RecordCount > 0 Then
           vPayRecFromGuest = True
        Else
           vPayRecFromGuest = False
        End If
        SSTemp.Close
        'Payments made to host?
        Set SSTemp = gBNB.OpenRecordset("select conf from checktbl where void_chk <> -1 And CheckCategory = 'Host' and conf = " & gConfNum, dbOpenSnapshot)
        GetSSRows SSTemp
        If SSTemp.RecordCount > 0 Then
           vPayToHost = True
        Else
           vPayToHost = False
        End If
        SSTemp.Close
        'Payments made to travel agency?
        Set SSTemp = gBNB.OpenRecordset("select conf from checktbl where void_chk <> -1 And CheckCategory = 'Travel' and  conf = " & gConfNum, dbOpenSnapshot)
        GetSSRows SSTemp
        If SSTemp.RecordCount > 0 Then
           vPayToTravel = True
        Else
           vPayToTravel = False
        End If
        SSTemp.Close
        If vPayRecFromGuest Or vPayToHost Or vPayToTravel Then
           gMsg = "This confirmation has payments received and/or disbursed " & _
                  "against it and cannot be deleted."
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        gMsg = "Deleting this row will result in the removal of all " & _
               "data related to this confirmation (Accommodations, " & _
               "Travel, Car, and Payments). Continue with deletion?"
        If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDYES Then
            gBNB.Execute "delete from payment where conf = " & gConfNum
            gBNB.Execute "delete from tagentbl where conf = " & gConfNum
            gBNB.Execute "delete from cartbl where conf = " & gConfNum
            gBNB.Execute "delete from bbtbl where conf = " & gConfNum
            gBNB.Execute "delete from AccomAudit where conf = " & gConfNum
            datBrowse.Recordset.Delete
            'Reset gConfNum because row we were on has been removed.
            'Any other related reservation forms that were open when
            'this row was deleted now need a valid conf number when
            'user clicks on (activates) them. 0 is a valid conf #as
            'far as system is concerned, setting the form to No Rows mode.
            gConfNum = 0
            'pc
           ' Me.Refresh
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

Private Sub cmdDisplayRows_Click()

    'Warn if more than 500 records
    If datBrowse.Recordset.RecordCount > 300 Then
      gMsg = "You are about to display " & _
             datBrowse.Recordset.RecordCount & _
             " rows to the screen. Continue?"
      If MsgBox(gMsg, MB_ICONQUESTION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then Exit Sub
    End If
    Screen.MousePointer = HOURGLASS
    gCaption = "Guest General Information Listing"
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
      chkRevision.Value = False
      txtRevDate.Enabled = True
      txtRevDate.Locked = False
      cmdFind.DEFAULT = True
      cmdFind.Caption = "&Run Query"
   Else
      cmdFind.Caption = "&Find"
      Criteria = BuildFindCriteria(Me, "conf")
      If Criteria <> "" Then
         datBrowse.UpdateControls
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


Private Sub cmdGoTo_Click()
   
  If txtConfNum.Text <> "" Then gConfNum = CLng(txtConfNum.Text)
  
  mdiBNB.mnuLine1.Visible = True
  mdiBNB.mnuPayToHost.Visible = True
  mdiBNB.mnuAuditTrail.Visible = True
  PopupMenu mdiBNB.mnuGuestData
  mdiBNB.mnuLine1.Visible = False
  mdiBNB.mnuPayToHost.Visible = False
  mdiBNB.mnuAuditTrail.Visible = False
  
End Sub

Private Sub cmdInsert_Click()
    
    On Error GoTo cmdInsert_Click_Error

    Screen.MousePointer = HOURGLASS
    
    If Trim(datBrowse.RecordSource) = "" Then
       datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
       If Not GetDCRows(datBrowse) Then GoTo cmdInsert_Click_Resume
    End If
    SetFormToInsertMode Me
    datBrowse.Recordset.AddNew
    SetZeroLengthString Me
    
    lblRevision.Enabled = False
    lblRevDate.Enabled = False
    chkRevision.Enabled = False
    txtRevDate.Enabled = False
    txtConfNum.Locked = True
    txtConfNum.ForeColor = BLACK
    'Control for Multi-user inserts.
    'Use a conf# control table containing all attempted row inserts.
    'Get next conf#
    Dim MaxRS As Recordset  'Maximum conf number from actual data table (guesttbl)
    Dim ControlRS As Recordset  'conf numbers from GuestInsertControl table.
    Dim MaxConfPlusOne As Long
    Dim MinControlRS As Long
    'Reset global conf number
    gConfNum = 0
    'Get highest conf number from Guesttbl and put it in MaxRS.
    'The following (1) line is for testing when no rows in guesttbl yet.
    'Set MaxRS = gBNB.OpenRecordset("select conf from " & Me.Tag & " where conf in(select max(conf) from " & Me.Tag & " where conf = 0)", dbOpenSnapshot)
    Set MaxRS = gBNB.OpenRecordset("select conf from " & Me.Tag & " where conf = (select max(alias_1.conf) from " & Me.Tag & " AS alias_1)", dbOpenSnapshot)
    GetSSRows MaxRS
    'Check for Demonstration version
    If DEMO Then
       If Not MaxRS.EOF Then
          If MaxRS("conf") > 25 Then
             gMsg = "The maximum number of confirmations (25) for " & _
                    "this demonstration version of BnB has been reached."
             MsgBox gMsg, MB_ICONSTOP, Me.Caption
             MaxRS.Close
             GoTo cmdInsert_Click_Resume
           End If
       End If
    End If
    'The ONLY purpose of the GuestInsertControl table is to get new rows into guesttbl.
    'Any conf numbers already in guesttbl have no reason to be in the GuestInsertControl table.
    'This case could happen due to a power outage (or other abnormal termination) AFTER
    'insert of conf number into guesttbl but BEFORE that conf number's removal from
    'GuestInsertControl table. As such, remove invalid rows from GuestInsertControl to prevent any
    'possible buildup of old conf numbers in GuestInsertControl. Removed conf number will never
    'be used in the database.
    If Not MaxRS.EOF Then gBNB.Execute "delete from GuestInsertControl where conf < " & (MaxRS(0) + 1)
    'Get all conf numbers currently in GuestInsertControl table.
    Set ControlRS = gBNB.OpenRecordset("select conf,ComputerName from GuestInsertControl order by conf ASC", dbOpenDynaset)
    'Make SURE we're at beginning.
    GetSSRows ControlRS
    If Not ControlRS.BOF And Not ControlRS.EOF Then
       MinControlRS = ControlRS("conf")
    Else  'No rows in GuestInsertControl table.
       MinControlRS = 0
    End If
    If MaxRS.BOF And MaxRS.EOF Then  'No rows exist in guesttbl yet.
       'MsgBox "Null"
       MaxConfPlusOne = 1
    Else
       MaxConfPlusOne = (MaxRS("conf") + 1)
    End If
    MaxRS.Close
    If (ControlRS.BOF And ControlRS.EOF) Then  'No rows in GuestInsertControl table.
       GoSub Insert_Control
    ElseIf MaxConfPlusOne < MinControlRS Then  'Conf to be inserted is less than all rows in GuestInsertControl.
       GoSub Insert_Control
    ElseIf MaxConfPlusOne >= MinControlRS Then
       'Equal or greater. Move through recordset to find next available
       'conf number to insert.
       Dim Done As Integer
       Done = False
       For i = 0 To ControlRS.RecordCount - 1
          If MaxConfPlusOne < (ControlRS("conf") - i) Then
            gConfNum = (MaxConfPlusOne + i)
            ControlRS.AddNew
            ControlRS("conf") = (MaxConfPlusOne + i)
            ControlRS("ComputerName") = gComputerName
            ControlRS.Update
            'gConfNum = (MaxConfPlusOne + i)
            Done = True
            Exit For
          End If
          ControlRS.MoveNext
       Next i
       'Conf number to be inserted into GuestInsertControl table will be
       'greater than any of those already existing in the table.
       If Not Done Then
          gConfNum = (MaxConfPlusOne + i)
          ControlRS.AddNew
          ControlRS("conf") = (MaxConfPlusOne + i)
          ControlRS("ComputerName") = gComputerName
          ControlRS.Update
          'gConfNum = (MaxConfPlusOne + i)
       End If
    Else
       'All cases have been accounted for.
    End If
    ControlRS.Close
    txtConfNum.Text = Trim$(gConfNum)
    txtConfNum.Locked = True
    txtConfNum.ForeColor = BLACK
    txtFirstName.SetFocus
    txtDateBooked.Text = Format$(Now, "m/d/yyyy")
    
cmdInsert_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub
    
Insert_Control:
      gConfNum = MaxConfPlusOne
      ControlRS.AddNew
      ControlRS("conf") = MaxConfPlusOne
      ControlRS("ComputerName") = gComputerName
      'gConfNum = MaxConfPlusOne
      ControlRS.Update
      Return
   
cmdInsert_Click_Error:
   'MsgBox Err.Number & " - " & Err.Description
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
   gSQL = "select " & Chr$(34) & gComputerName & Chr$(34) & ",f_name,l_name,busadd,address,city,state,zipcode "
   'Remove * from query and just get rows of interest
   txtFindSQL.Text = Replace_All_In_With("select * ", txtFindSQL.Text, gSQL)
   'Remove Order By clause
   If InStr(1, txtFindSQL.Text, "Order By", 1) > 0 Then
      txtFindSQL.Text = Left(txtFindSQL.Text, InStr(1, txtFindSQL.Text, "Order By", 1) - 1)
   End If
   'Append more criteria to prevent non-mailable and Suppressed labels from being printed
   If InStr(1, txtFindSQL.Text, "where", 1) > 0 Then
      txtFindSQL.Text = txtFindSQL.Text & " And address <> '' And lbl_flag <> -1 And lbl_flag <> 1 "
   Else
      txtFindSQL.Text = txtFindSQL.Text & " Where address <> '' And lbl_flag <> -1 And lbl_flag <> 1 "
   End If
   'MsgBox txtFindSQL.Text
   'pc
   LabelCallingForm = "frmGeneralGuest"
   frmLabelDialog.Show 1
   DoEvents
   If Not FormLoaded(frmLabelDialog) Then GoTo cmdLabels_Click_Resume
   Screen.MousePointer = HOURGLASS
   Dim i As Integer
   'Clear out support table
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
                datBrowse.Recordset("f_name") & "','" & _
                datBrowse.Recordset("l_name") & "','" & _
                datBrowse.Recordset("busadd") & "','" & _
                datBrowse.Recordset("Address") & "','" & _
                datBrowse.Recordset("City") & "','" & _
                datBrowse.Recordset("State") & "','" & _
                datBrowse.Recordset("Zipcode") & "'"
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
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(mdiBNB.Report1.SortFields(vCount)) <> ""
     mdiBNB.Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   mdiBNB.Report1.SelectionFormula = "{LabelSupport.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
   For i = 0 To frmLabelDialog.lstSortOrder.ListCount - 1
      Select Case frmLabelDialog.lstSortOrder.List(i)
        Case "First Name"
           mdiBNB.Report1.SortFields(i) = "+{LabelSupport.f_name}"
        Case "Last Name"
           mdiBNB.Report1.SortFields(i) = "+{LabelSupport.l_name}"
        Case "Company"
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
   MsgBox Err.Description
   Resume cmdLabels_Click_Resume
   

End Sub

Private Sub cmdUpdate_Click()

   On Error GoTo cmdUpdate_Click_Error
   
   'datBrowse.Options = dbConsistent
   'If Not datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then OrigBookmark = datBrowse.Recordset.Bookmark
   Screen.MousePointer = HOURGLASS
   SetFormToUpdateMode Me
   datBrowse.Recordset.Edit
   OrigFirstName = txtFirstName.Text
   OrigLastName = txtLastName.Text
    
   lblRevision.Enabled = True
   lblRevDate.Enabled = True
   chkRevision.Enabled = True
   txtRevDate.Enabled = True

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
  If chkRevision.Value = CHECKED Then
     txtRevDate.Enabled = True
  Else
     txtRevDate.Enabled = False
  End If
  'SetToCurrencyFormat Me
End Sub

Private Sub datdwData1_Click(ByVal nPosition As Integer)

    'On Error GoTo datdwData1_Click_Error
    Screen.MousePointer = HOURGLASS
    Me.SetFocus
    'Dim EntryConfNum As String
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
'If form is only regaining focus then exit
If UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then Exit Sub
'MsgBox "txtConfNum.Text=" & txtConfNum.Text & ", gConf=" & Str$(gConfNum) & ", gPrior=" & Str$(gPriorConfNum) & ", gRowChangeFormName=" & gRowChangeFormName
If TimesActivated < 1 Or (gConfNum <> gPriorConfNum And gRowChangeFormName <> "frmGeneralGuest") _
   Or ((Trim$(txtConfNum.Text) <> Trim$(gConfNum)) And (Trim$(txtConfNum.Text) <> "")) _
   Or gConfNum <> 0 And Trim(txtConfNum.Text) = "" Then
   Screen.MousePointer = HOURGLASS
   'gPriorConfNum = gConfNum
   TimesActivated = TimesActivated + 1
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
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
   'Do this in the event of a name (first,last or both) change on frmGeneralGuest
   txtConfNum.SetFocus
   txtFirstName.SetFocus
   txtConfNum.SetFocus
   Exit Sub

Form_Activate_Error:
   Resume Form_Activate_Resume
  
End Sub



Private Sub Form_Load()
   
   'Screen.MousePointer = HOURGLASS
   On Error GoTo Load_Error
   
   TimesActivated = 0
   If Not OtherGuestFormsInBrowseMode Then gConfNum = 0
   datBrowse.DatabaseName = gDatabaseName
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
   CurrRec = 1
   SaveRec = 0

Load_Resume:
   Exit Sub
   
Load_Error:
   Resume Load_Resume
   
End Sub



Public Function InsertTrigger() As Integer
  
  On Error GoTo InsertTrigger_Error
  
  Dim SSTemp As Recordset
  
  txtConfNum.Text = Trim$(txtConfNum.Text)
  InsertTrigger = True
  SetFocusTo = ""
  If txtConfNum.Text = "0" Or txtConfNum.Text = "" Then
     gMsg = "Confirmation number cannot be zero or blank."
     SetFocusTo = "txtConfNum"
     InsertTrigger = False
     Exit Function
  End If
  'Don't allow insert if Conf Number already exists.
  If GetFormMode(Me) = "Insert" Then
     Set SSTemp = gBNB.OpenRecordset("select conf from guesttbl where conf = " & txtConfNum.Text, dbOpenSnapshot)
     If SSTemp.RecordCount > 0 Then
        gMsg = "An entry already exists for this confirmation number."
        InsertTrigger = False
        SSTemp.Close
        Exit Function
     End If
     SSTemp.Close
  End If

InsertTrigger_Resume:
   Exit Function
   
InsertTrigger_Error:
   Resume InsertTrigger_Resume

End Function

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
   
   'This routine will probably never be fired due to problems listed below.
   'Workaround is to never let this form close while in Insert or Update mode.
   'This is done with API calls which are called from Subroutines
   'DisableSystemMenuClose and RestoreSystemMenu. These calls Disable/Enable
   'the form's ControlBox (upper-left close box and the upper-right 'X'. Also, if attempt
   'is made to close the MDI main form while this form is in Insert or Update mode,
   'Cancel is set to 1 and message sent to user telling them to "Cancel pending operation"
   'through the MDI QueryUnload event.
   Select Case GetFormMode(Me)
     Case "Insert"
         If datBrowse.Recordset.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
         'MsgBox Str$(datBrowse.Recordset.EditMode)
         'Bad Scenario: Hit "Insert" then unload the form. Row is inserted
         'regardless of datBrowse.Recordset.CancelUpdate in this
         'subroutine. In fact CancelUpdate will generate an error
         'because EditMode is now reset to 0. (0=No edit/addnew pending, 1=
         'Edit Pending, 2=AddNew pending).
         
         'CancelUpdate won't work here for some unknown reason. Between
         'the time user hits the 'x' (or upper-left close button) and
         'entry of this Subroutine, the datBrowse control has already
         'performed the insertion of a new row (update event has fired somehow)
         'and EditMode has been returned to 0. Apparently no way to stop it,
         'so the next line removes the entered row from guesttbl.
         gBNB.Execute "delete * from " & Me.Tag & " where conf = " & gConfNum
         'Remove insert attempt from GuestInsertControl table.
         gBNB.Execute "delete * from GuestInsertControl where conf = " & gConfNum
     Case "Update"
         'The above is true also for updates.
         If datBrowse.Recordset.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
     Case Else
   End Select
   
End Sub
Private Sub Form_Unload(Cancel As Integer)
  DoEvents
End Sub

Private Sub txtConfNum_Change()

    If Not IsNumeric(txtConfNum.Text) Then Exit Sub
    If gConfNum = 0 Then
       gPriorConfNum = 0
    Else
       gPriorConfNum = gConfNum
    End If
    If txtConfNum.Text <> "" Then
       gConfNum = CLng(txtConfNum.Text)
       gRowChangeFormName = Me.Name
    Else
       gConfNum = 0
    End If
    'MsgBox "ConfNum=" & Str$(gConfNum) & ", Prior=" & Str$(gPriorConfNum)

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




Public Function UpdateGuestName(TheTextBox As Control, NamePart As String) As Integer

  UpdateGuestName = False
  Screen.MousePointer = HOURGLASS
  On Error GoTo UpdateGuestName_Error
  'Chr$(34) is the double quote character (").
  'Need this in the event of single-quote embedded names (eg, O'Malley)
  If NamePart = "First" Then
     gBNB.Execute "update bbtbl set f_name = " & Chr$(34) & Trim(TheTextBox.Text) & Chr$(34) & " where conf = " & txtConfNum.Text
     gBNB.Execute "update cartbl set f_name = " & Chr$(34) & Trim(TheTextBox.Text) & Chr$(34) & " where conf = " & txtConfNum.Text
     gBNB.Execute "update payment set f_name = " & Chr$(34) & Trim(TheTextBox.Text) & Chr$(34) & " where conf = " & txtConfNum.Text
     gBNB.Execute "update tagentbl set f_name = " & Chr$(34) & Trim(TheTextBox.Text) & Chr$(34) & " where conf = " & txtConfNum.Text
  ElseIf NamePart = "Last" Then
     gBNB.Execute "update bbtbl set l_name = " & Chr$(34) & Trim(TheTextBox.Text) & Chr$(34) & " where conf = " & txtConfNum.Text
     gBNB.Execute "update cartbl set l_name = " & Chr$(34) & Trim(TheTextBox.Text) & Chr$(34) & " where conf = " & txtConfNum.Text
     gBNB.Execute "update payment set l_name = " & Chr$(34) & Trim(TheTextBox.Text) & Chr$(34) & " where conf = " & txtConfNum.Text
     gBNB.Execute "update tagentbl set l_name = " & Chr$(34) & Trim(TheTextBox.Text) & Chr$(34) & " where conf = " & txtConfNum.Text
     gBNB.Execute "update checktbl set l_name = " & Chr$(34) & Trim(TheTextBox.Text) & Chr$(34) & " where conf = " & txtConfNum.Text
  End If
  
  UpdateGuestName = True

UpdateGuestName_Resume:
   Screen.MousePointer = DEFAULT
   Exit Function
   
UpdateGuestName_Error:
   gMsg = Str(Err) & ": " & Err.Description
   UpdateGuestName = False
   GoTo UpdateGuestName_Resume
   
End Function


Public Function UpdateTrigger() As Integer

  On Error GoTo UpdateTrigger_Error
  
  UpdateTrigger = True
  SetFocusTo = ""
  txtConfNum.Text = Trim(txtConfNum.Text)
  If txtConfNum.Text = "0" Or txtConfNum.Text = "" Then
     gMsg = "Confirmation number cannot be zero or blank."
     SetFocusTo = "txtConfNum"
     UpdateTrigger = False
  End If
   
UpdateTrigger_Resume:
   Exit Function

UpdateTrigger_Error:
   Resume UpdateTrigger_Resume
   
End Function
