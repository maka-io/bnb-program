VERSION 5.00
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmGuestCar 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Guest Car Reservations"
   ClientHeight    =   5736
   ClientLeft      =   1008
   ClientTop       =   1560
   ClientWidth     =   8124
   HelpContextID   =   106
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   5736
   ScaleWidth      =   8124
   Tag             =   "cartbl"
   Begin VB.TextBox txtNumDays 
      Appearance      =   0  'Flat
      DataField       =   "Days"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   4740
      TabIndex        =   15
      Tag             =   "Number"
      Top             =   2280
      Width           =   1875
   End
   Begin VB.Frame fraCommReceived 
      Caption         =   "Commission Received from Rental Agency"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1095
      Left            =   60
      TabIndex        =   49
      Top             =   4230
      Width           =   6555
      Begin VB.TextBox txtDateCommPaid 
         Appearance      =   0  'Flat
         DataField       =   "DateReceived"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1500
         TabIndex        =   20
         Tag             =   "Date"
         Top             =   720
         Width           =   1215
      End
      Begin VB.TextBox txtCommPaid 
         Appearance      =   0  'Flat
         DataField       =   "AmountReceived"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1500
         TabIndex        =   19
         Tag             =   "Currency"
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label lblDateRec 
         Caption         =   "Date Received:"
         Height          =   225
         Left            =   120
         TabIndex        =   51
         Top             =   720
         Width           =   1215
      End
      Begin VB.Label lblAmtRec 
         Caption         =   "Amount Received:"
         Height          =   225
         Left            =   120
         TabIndex        =   50
         Top             =   420
         Width           =   1395
      End
   End
   Begin VB.TextBox txtTotal 
      Appearance      =   0  'Flat
      DataField       =   "Total"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   4740
      TabIndex        =   16
      Tag             =   "Currency"
      Top             =   2640
      Width           =   1875
   End
   Begin VB.TextBox txtCarConfNumber 
      Appearance      =   0  'Flat
      DataField       =   "CarConfNumber"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   4740
      TabIndex        =   14
      Tag             =   "Text"
      Top             =   1920
      Width           =   1875
   End
   Begin VB.TextBox txtDropCharge 
      Appearance      =   0  'Flat
      DataField       =   "DropCharge"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   4740
      TabIndex        =   13
      Tag             =   "Currency"
      Top             =   1560
      Width           =   1875
   End
   Begin VB.TextBox txtWeeklyRate 
      Appearance      =   0  'Flat
      DataField       =   "WeeklyRate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   8
      Tag             =   "Currency"
      Top             =   2640
      Width           =   1935
   End
   Begin VB.TextBox txtDailyRate 
      Appearance      =   0  'Flat
      DataField       =   "DailyRate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   7
      Tag             =   "Currency"
      Top             =   2280
      Width           =   1935
   End
   Begin VB.TextBox txtDropLoc 
      Appearance      =   0  'Flat
      DataField       =   "DropLocation"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   4740
      TabIndex        =   12
      Tag             =   "Text"
      Top             =   1200
      Width           =   1875
   End
   Begin VB.TextBox txtPickupLoc 
      Appearance      =   0  'Flat
      DataField       =   "PULocation"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   4740
      TabIndex        =   11
      Tag             =   "Text"
      Top             =   840
      Width           =   1875
   End
   Begin VB.TextBox txtDropDate 
      Appearance      =   0  'Flat
      DataField       =   "DropDate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   4740
      TabIndex        =   10
      Tag             =   "Date"
      Top             =   480
      Width           =   1875
   End
   Begin VB.TextBox txtPickupDate 
      Appearance      =   0  'Flat
      DataField       =   "PUDate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   4740
      TabIndex        =   9
      Tag             =   "Date"
      Top             =   120
      Width           =   1875
   End
   Begin VB.TextBox txtCarModel 
      Appearance      =   0  'Flat
      DataField       =   "Model"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   6
      Tag             =   "Text"
      Top             =   1920
      Width           =   1935
   End
   Begin VB.TextBox txtComment 
      Appearance      =   0  'Flat
      DataField       =   "comments"
      DataSource      =   "datBrowse"
      Height          =   465
      Left            =   1260
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   17
      Tag             =   "Text"
      Top             =   3000
      Width           =   5355
   End
   Begin VB.CommandButton cmdGoTo 
      Caption         =   "&Go to..."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   585
      Left            =   6780
      TabIndex        =   29
      Top             =   5130
      Width           =   1335
   End
   Begin VB.Frame fraCommDue 
      Caption         =   "Commission Due from Rental Agency"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   645
      Left            =   60
      TabIndex        =   36
      Top             =   3540
      Width           =   6555
      Begin VB.TextBox txtCommDue 
         Appearance      =   0  'Flat
         DataField       =   "CommishDue"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1200
         MaxLength       =   30
         TabIndex        =   18
         Tag             =   "Currency"
         Top             =   300
         Width           =   1215
      End
      Begin VB.Label lblSuggCommAmt 
         Caption         =   "xxxxxxxxx"
         Height          =   228
         Left            =   4968
         TabIndex        =   54
         Top             =   360
         Width           =   1164
      End
      Begin VB.Label lblLabel1 
         Caption         =   "Suggested Commission:"
         Height          =   192
         Left            =   2736
         TabIndex        =   53
         Top             =   360
         Width           =   1920
      End
      Begin VB.Label lblAmtDue 
         Caption         =   "Amount Due:"
         Height          =   255
         Left            =   180
         TabIndex        =   37
         Top             =   360
         Width           =   1035
      End
   End
   Begin VB.TextBox txtAgentName 
      Appearance      =   0  'Flat
      DataField       =   "agentname"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   5
      Tag             =   "Text"
      Top             =   1560
      Width           =   1935
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
      Height          =   585
      Left            =   6780
      TabIndex        =   28
      Top             =   4500
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
      Height          =   585
      Left            =   6780
      TabIndex        =   26
      Top             =   3240
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
      Height          =   585
      Left            =   6780
      TabIndex        =   25
      Top             =   2610
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
      Height          =   555
      Left            =   6780
      TabIndex        =   24
      Top             =   2010
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
      Height          =   585
      Left            =   6780
      TabIndex        =   23
      Top             =   1380
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
      Height          =   585
      Left            =   6780
      TabIndex        =   21
      Top             =   120
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
      Height          =   585
      Left            =   6780
      TabIndex        =   27
      Top             =   3870
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
      Height          =   585
      Left            =   6780
      TabIndex        =   22
      Top             =   750
      Width           =   1335
   End
   Begin VB.Data datAgencyList 
      Appearance      =   0  'Flat
      Caption         =   "datAgencyList"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   1920
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   5820
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
      Left            =   60
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   5820
      Visible         =   0   'False
      Width           =   1875
   End
   Begin VB.TextBox txtLastName 
      Appearance      =   0  'Flat
      DataField       =   "l_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      MaxLength       =   50
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   840
      Width           =   1935
   End
   Begin VB.TextBox txtFirstName 
      Appearance      =   0  'Flat
      DataField       =   "f_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      MaxLength       =   50
      TabIndex        =   2
      Tag             =   "Text"
      Top             =   480
      Width           =   1935
   End
   Begin VB.TextBox txtConfNum 
      Appearance      =   0  'Flat
      DataField       =   "conf"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      MaxLength       =   9
      TabIndex        =   1
      Tag             =   "Number"
      Top             =   120
      Width           =   1035
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "Car.frx":0000
      Height          =   330
      Left            =   60
      TabIndex        =   0
      Tag             =   "tagentbl"
      Top             =   5400
      Width           =   6555
      _Version        =   131075
      _ExtentX        =   11557
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
      Bindings        =   "Car.frx":0014
      DataField       =   "AgencyName"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1260
      TabIndex        =   4
      Tag             =   "Text"
      Top             =   1200
      Width           =   1935
      ListAutoValidate=   0   'False
      ListAutoPosition=   0   'False
      MaxDropDownItems=   12
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
      _ExtentX        =   3413
      _ExtentY        =   503
      _StockProps     =   93
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
   End
   Begin VB.Label lblLblNumDays 
      Caption         =   "Days:"
      Height          =   255
      Left            =   3420
      TabIndex        =   52
      Top             =   2340
      Width           =   1215
   End
   Begin VB.Label lblTotal 
      Caption         =   "Total Due:"
      Height          =   255
      Left            =   3420
      TabIndex        =   48
      Top             =   2700
      Width           =   1155
   End
   Begin VB.Label lblCarConf 
      Caption         =   "Car Conf Number:"
      Height          =   255
      Left            =   3420
      TabIndex        =   47
      Top             =   1980
      Width           =   1275
   End
   Begin VB.Label lblDropCharge 
      Caption         =   "Drop Charge:"
      Height          =   255
      Left            =   3420
      TabIndex        =   46
      Top             =   1620
      Width           =   1275
   End
   Begin VB.Label lblDailyRate 
      Caption         =   "Daily Rate:"
      Height          =   255
      Left            =   60
      TabIndex        =   45
      Top             =   2340
      Width           =   1155
   End
   Begin VB.Label lblWeeklyRate 
      Caption         =   "Weekly Rate:"
      Height          =   255
      Left            =   60
      TabIndex        =   44
      Top             =   2700
      Width           =   1215
   End
   Begin VB.Label lblCarModel 
      Caption         =   "Car Model:"
      Height          =   255
      Left            =   60
      TabIndex        =   43
      Top             =   1980
      Width           =   1215
   End
   Begin VB.Label lblDropLoc 
      Caption         =   "Dropoff Location:"
      Height          =   255
      Left            =   3420
      TabIndex        =   42
      Top             =   1260
      Width           =   1275
   End
   Begin VB.Label lblPickupLoc 
      Caption         =   "Pickup Location:"
      Height          =   255
      Left            =   3420
      TabIndex        =   41
      Top             =   900
      Width           =   1275
   End
   Begin VB.Label lblDropDate 
      Caption         =   "Dropoff Date:"
      Height          =   255
      Left            =   3420
      TabIndex        =   40
      Top             =   540
      Width           =   1155
   End
   Begin VB.Label lblPickupDate 
      Caption         =   "Pickup Date:"
      Height          =   255
      Left            =   3420
      TabIndex        =   39
      Top             =   180
      Width           =   1275
   End
   Begin VB.Label lblComment 
      Caption         =   "Blind Comment:"
      Height          =   255
      Left            =   60
      TabIndex        =   38
      Top             =   3060
      Width           =   1155
   End
   Begin VB.Label lblLastName 
      Caption         =   "Last Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   35
      Top             =   900
      Width           =   1095
   End
   Begin VB.Label lblFirstName 
      Caption         =   "First Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   34
      Top             =   540
      Width           =   1095
   End
   Begin VB.Label lblConfNum 
      Caption         =   "Conf Number:"
      Height          =   255
      Left            =   60
      TabIndex        =   33
      Top             =   180
      Width           =   1095
   End
   Begin VB.Label lblAgentName 
      Caption         =   "Agent Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   32
      Top             =   1620
      Width           =   1095
   End
   Begin VB.Label lblAgencyName 
      Caption         =   "Agency Name:"
      Height          =   255
      Left            =   60
      TabIndex        =   31
      Top             =   1260
      Width           =   1095
   End
   Begin VB.Label lblAcctNum 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      Caption         =   "AcctNum"
      DataField       =   "accountnum"
      DataSource      =   "datBrowse"
      ForeColor       =   &H80000008&
      Height          =   228
      Left            =   4140
      TabIndex        =   30
      Top             =   5868
      Width           =   732
   End
End
Attribute VB_Name = "frmGuestCar"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim i As Integer
Dim TimesActivated As Integer
Dim CurrRec1 As Long
Dim SaveRec1 As Long
Dim NullDateArray()
Dim FailedLostFocus As Integer
Dim SetFocusTo As String
'Dim UserClickedAgency As Integer
Dim lblAcctNumOK As Integer


Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error
   
   Select Case GetFormMode(Me)
     Case "Insert"
        If datBrowse.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
        'MsgBox Str$(gConfNum)
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
     txtConfNum.SetFocus
   End If
   GetSuggestedComm
   If Not OtherGuestFormsInBrowseMode And GetFormMode(Me) = "No Rows" Then gConfNum = 0

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
    Screen.MousePointer = HOURGLASS
    Select Case GetFormMode(Me)
      Case "Insert"
        'Check for valid dates and number formats
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Ensure number of days is filled in (this is also done by
        'LostFocus on PU and Drop dates, but it's possible for user
        'to use Alt+Key to Commit without ever losing focus.)
        If Not GetNumDays() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmGuestCar
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
        'If number formats are OK, then set currency formats
        SetToCurrencyFormat Me
        'If new record is being added
        If datBrowse.EditMode = dbEditAdd Then
           'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
           'unbind control's DataField property and commit Null.
           RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
           datBrowse.Recordset.Update
           datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
           If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
           'Do if there was at least one Date or Number set to null
           If RetVal Then BindNullDateControl Me, NullDateArray
           If Not datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then datBrowse.Recordset.MoveLast
        End If
        GetSuggestedComm
        SetToCurrencyFormat Me
      Case "Update"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Ensure number of days is filled in (this is also done by
        'LostFocus on PU and Drop dates, but it's possible for user
        'to use Alt+Key to Commit without ever losing focus.)
        If Not GetNumDays() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmGuestCar
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
        'If number formats are OK, then set currency formats
        SetToCurrencyFormat Me
        If datBrowse.EditMode = dbEditInProgress Then
           'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
           'unbind control's DataField property and commit Null.
           RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
           datBrowse.Recordset.Update
           'getting No Current Record here. Put next (1) line in to correct.
           datBrowse.Recordset.Bookmark = datBrowse.Recordset.LastModified
           'Do if there was at least one Date or Number was set to null
           If RetVal Then BindNullDateControl Me, NullDateArray
           'Make the current record current again.
           datBrowse.UpdateControls
        End If
        GetSuggestedComm
        SetToCurrencyFormat Me
      Case "Delete"
           gMsg = "Delete this guest's car rental information?"
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
    gCaption = "Guest Car Rental Listing"
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
   Screen.MousePointer = HOURGLASS
   Dim Criteria As String
   If cmdFind.Caption = "&Find" Then
      SetFormToFindMode Me
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
            CurrRec1 = GetCurrentRowNumber(datBrowse)
            datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount
         End If
      Else
         SetFormToNoRowsMode Me
      End If
   End If
   GetSuggestedComm
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
    
    If Trim(datBrowse.RecordSource) = "" Then
       datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
       If Not GetDCRows(datBrowse) Then Exit Sub
    End If
    SetFormToInsertMode Me
    txtFirstName.Locked = True
    txtLastName.Locked = True
    txtFirstName.ForeColor = BLACK
    txtLastName.ForeColor = BLACK
    datBrowse.Recordset.AddNew
    SetZeroLengthString Me
    
    If gConfNum <> 0 Then
       'Get first and last name if gConfNum is set. Also disallow edit of conf number.
       Dim SSTemp As Recordset
       txtConfNum.Locked = True
       txtConfNum.ForeColor = BLACK
       Set SSTemp = gBNB.OpenRecordset("select f_name,l_name from guesttbl where conf = " & gConfNum, dbOpenSnapshot)
       GetSSRows SSTemp
       If SSTemp.RecordCount > 0 Then
          txtConfNum.Text = gConfNum
          If Not IsNull(SSTemp("f_name")) Then txtFirstName.Text = SSTemp("f_name")
          If Not IsNull(SSTemp("l_name")) Then txtLastName.Text = SSTemp("l_name")
          datdwComboAgency.SetFocus
       End If
       SSTemp.Close
    Else
       txtConfNum.Locked = False
       txtConfNum.ForeColor = BLUE
       txtConfNum.SetFocus
    End If
    
cmdInsert_Click_Resume:
   Exit Sub
   
cmdInsert_Click_Error:
   MsgBox Err.Description
   Resume cmdInsert_Click_Resume
   
End Sub

Private Sub cmdUpdate_Click()

   On Error GoTo cmdUpdate_Click_Error
   
   SetFormToUpdateMode Me
   'Safe to assume that if record has been previously entered, agency
   'accountnum is OK.
   lblAcctNumOK = True
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


Private Sub datBrowse_Reposition()
   'SetToCurrencyFormat Me
   GetSuggestedComm
End Sub

Private Sub datdwComboAgency_Change()

   If GetFormMode(Me) <> "Insert" And GetFormMode(Me) <> "Update" Then Exit Sub
    
   Dim SSTemp As Recordset
   If lblAcctNumOK = False Then 'User TYPED name into field instead of selecting
      Set SSTemp = gBNB.OpenRecordset("select accountnum,agencyname from carmaster where agencyname = " & Chr$(34) & Trim(datdwComboAgency.Text) & Chr$(34), dbOpenSnapshot)
      GetSSRows SSTemp
      If SSTemp.RecordCount > 1 Then
         gMsg = "There are multiple car rental agency accounts with this agency name. " & _
                "Please select the appropriate agency name from the dropdown list."
         datdwComboAgency.SetFocus
         SSTemp.Close
         Exit Sub
      ElseIf SSTemp.RecordCount = 1 Then
         lblAcctNum.Caption = SSTemp(0)
         datdwComboAgency.Text = SSTemp(1)
      Else
         lblAcctNum.Caption = ""
         lblSuggCommAmt.Caption = ""
      End If
      SSTemp.Close
   End If
    
   If Trim(txtTotal.Text) <> "" And lblAcctNum.Caption <> "" Then
      If IsNumeric(txtTotal.Text) Then
          GetSuggestedComm
      End If
   Else
      lblSuggCommAmt.Caption = ""
   End If
   
End Sub

Private Sub datdwComboAgency_CloseUp()
   
   On Error GoTo Closeup_Error
   'Set account number.
   lblAcctNum.Caption = datdwComboAgency.Columns("accountnum").CellValue(datdwComboAgency.SelBookmarks(0))
   'UserClickedAgency = True
   lblAcctNumOK = True
   'Fix for unknown bug. Symptoms:
   '1. Click Insert button.
   '2. TYPE a agency name EXACTLY (including case) as it exists in the database.
   '3. Hit dropdown for agency name and select same agency previously typed in.
   '4. Continue with entry of other fields
   '5. On Commit, agency name field is blanked and Null agency name is saved to Database.
   datdwComboAgency.Text = ""
   datdwComboAgency.Refresh
   If Not datAgencyList.Recordset.BOF And Not datAgencyList.Recordset.EOF Then
      datdwComboAgency.Text = datdwComboAgency.Columns("agencyname").Text
   End If
   datdwComboAgency.Refresh
   cmdFind.DEFAULT = True
   
Closeup_Resume:
   Exit Sub

Closeup_Error:
   Resume Closeup_Resume

End Sub


Private Sub datdwComboAgency_DropDown()

   On Error GoTo datdwComboAgency_Error
   
   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        datdwComboAgency.DataFieldList = ""
        Exit Sub
     Case Else
        datdwComboAgency.DefColWidth = datdwComboAgency.Width
        datdwComboAgency.DataFieldList = "agencyname"
   End Select
   
   'datDropListing.DatabaseName = gDatabaseName
   datAgencyList.RecordSource = "select agencyname,accountnum,address,city,state " & _
                                "from carmaster " & _
                                "order by agencyname"
   If Not GetDCRows(datAgencyList) Then Exit Sub
   'Size columns
   datdwComboAgency.Columns(0).Width = Me.TextWidth("XXXXXXXXXXXXXXXXXXXX")
   datdwComboAgency.Columns(1).Width = Me.TextWidth("XXXXXXXXXX")
   datdwComboAgency.Columns(2).Width = Me.TextWidth("XXXXXXXXXXXXXXXXXXXX")
   datdwComboAgency.Columns(3).Width = Me.TextWidth("XXXXXXXXXXXXXXXXXXXX")
   datdwComboAgency.Columns(4).Width = Me.TextWidth("XXXXXXXXXX")
   'Select the appropriate agency in the dropdown list.
   'ListAutoPosition property must be set to False!
   If Trim(lblAcctNum.Caption) <> "" Then
      datdwComboAgency.ListAutoPosition = False
      datdwComboAgency.SelBookmarks.RemoveAll
      datdwComboAgency.MoveFirst
      For j = 0 To datdwComboAgency.Rows - 1
         If lblAcctNum.Caption = datdwComboAgency.Columns("accountnum").CellValue(datdwComboAgency.Bookmark) Then
            'MsgBox "Found It: J=" & Str(j) & ", " & datdwComboAgency.Columns("accountnum").CellValue(datdwComboAgency.Bookmark)
            datdwComboAgency.SelBookmarks.Add (datdwComboAgency.Bookmark)
            Exit For
         End If
         datdwComboAgency.MoveNext
      Next j
     ' MsgBox datdwComboAgency.Columns("accountnum").CellValue(datdwComboAgency.Bookmark)
   End If
   cmdFind.DEFAULT = False

datdwComboAgency_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
datdwComboAgency_Error:
  GoTo datdwComboAgency_Resume

End Sub

Private Sub datdwComboAgency_KeyPress(KeyAscii As Integer)
   
   'Need this because it is set to False in dropdown to locate proper row.
   'This allows users to press a key to goto a row in dropdown list.
   datdwComboAgency.ListAutoPosition = True
   
   If UCase(GetFormMode(Me)) = "FIND" Or UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then

   Else
      KeyAscii = False
   End If
   
   'UserClickedAgency = False
   lblAcctNumOK = False
   
End Sub


Private Sub datdwComboAgency_LostFocus()

   If GetFormMode(Me) <> "Insert" And GetFormMode(Me) <> "Update" Then Exit Sub
   If Trim(txtTotal.Text) <> "" And lblAcctNum.Caption <> "" Then
      If IsNumeric(txtTotal.Text) Then
          GetSuggestedComm
      End If
   Else
      lblSuggCommAmt.Caption = ""
   End If
   'If GetFormMode(Me) = "Insert" Then
   '   txtCommDue.Text = lblSuggCommAmt.Caption
   'End If
   
End Sub

Private Sub datdwData1_Click(ByVal nPosition As Integer)
    
    'On Error GoTo datdwData1_Click_Error
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
For i = 1 To 5
   DoEvents
Next i
'MsgBox "gConf=" & Str$(gConfNum) & ", gPrior=" & Str$(gPriorConfNum) & ", gRowChangeFormName=" & gRowChangeFormName
If TimesActivated < 1 Or (gConfNum <> gPriorConfNum And gRowChangeFormName <> Me.Name) _
   Or ((Trim$(txtConfNum.Text) <> Trim$(gConfNum)) And (Trim$(txtConfNum.Text) <> "")) _
   Or (gConfNum <> 0 And Trim(txtConfNum.Text) = "") Then
   Screen.MousePointer = HOURGLASS
   TimesActivated = TimesActivated + 1
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
   If Not GetDCRows(datBrowse) Then GoTo Form_Activate_Resume
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
   Else
      SetFormToBrowseMode Me
      CurrRec1 = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec1 & " of " & datBrowse.Recordset.RecordCount
   End If
   GetSuggestedComm
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
   
   lblSuggCommAmt.Caption = ""
   TimesActivated = 0
   If Not OtherGuestFormsInBrowseMode Then gConfNum = 0
   datBrowse.DatabaseName = gDatabaseName
   datAgencyList.DatabaseName = gDatabaseName
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
   CurrRec1 = 1
   SaveRec1 = 0

Load_Resume:
   Exit Sub
   
Load_Error:
   Resume Load_Resume
   
End Sub


Private Sub Form_Unload(Cancel As Integer)
   DoEvents
End Sub



Private Sub txtConfNum_Change()
    
    If Not IsNumeric(txtConfNum.Text) Then GoTo txtConfNum_Resume
    
    Screen.MousePointer = HOURGLASS
    
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
    
txtConfNum_Resume:
  Screen.MousePointer = DEFAULT
    
End Sub


Private Sub txtConfNum_LostFocus()

  Dim SSTemp As Recordset
  If Not IsNumeric(txtConfNum.Text) Or txtConfNum.Text = "" Or GetFormMode(Me) <> "Insert" Then Exit Sub
  Set SSTemp = gBNB.OpenRecordset("select f_name,l_name from guesttbl where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount > 0 Then
    If Not IsNull(SSTemp("f_name")) Then txtFirstName.Text = SSTemp("f_name")
    If Not IsNull(SSTemp("l_name")) Then txtLastName.Text = SSTemp("l_name")
     'datdwComboAgency.SetFocus
  End If
  SSTemp.Close
  
End Sub



Public Function InsertTrigger() As Integer

  On Error GoTo InsertTrigger_Error
  
  Dim SSTemp As Recordset
  InsertTrigger = True
  
  SetFocusTo = ""
  txtConfNum.Text = Trim(txtConfNum.Text)
  datdwComboAgency.Text = Trim$(datdwComboAgency.Text)
  'Check for confirmation number equal to zero
  If txtConfNum.Text = "0" Or txtConfNum.Text = "" Then
     gMsg = "Confirmation number cannot be zero or blank."
     InsertTrigger = False
     SetFocusTo = "txtConfNum"
     Exit Function
  End If
  'Conf number must exist in guesttbl
  Set SSTemp = gBNB.OpenRecordset("select conf from guesttbl where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Confirmation number must exist in General Guest Information before car rental information can be entered."
     InsertTrigger = False
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close
  'Agency name must exist in car account table (carmaster)
  Set SSTemp = gBNB.OpenRecordset("select agencyname from carmaster where agencyname = " & Chr$(34) & datdwComboAgency.Text & Chr$(34), dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Agency name does not exist in Car Rental Agency Accounts. Select an agency from the dropdown list."
     InsertTrigger = False
     SetFocusTo = "datdwComboAgency"
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close
  'The lblAcctNum field must be filled in. If user types agency name in manually,
  'lblAcctNum will be blank. If blank, need to get acct number for the
  'Agency Name. If agency name exists more than once in CarMaster,
  'then force user to select agency name from the dropdown list, otherwise
  'fillin lblAcctNum with the Agency's account number.
  If lblAcctNumOK = False Then
     Set SSTemp = gBNB.OpenRecordset("select accountnum from carmaster where agencyname = " & Chr$(34) & datdwComboAgency.Text & Chr$(34), dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount > 1 Then
        gMsg = "There are multiple car rental agency accounts with this agency name. " & _
               "Please select the appropriate agency name from the dropdown list."
        InsertTrigger = False
        SetFocusTo = "datdwComboAgency"
        SSTemp.Close
        Exit Function
     Else
        lblAcctNum.Caption = SSTemp(0)
     End If
     SSTemp.Close
  End If
  'Commission due from rental agency must be filled in
  If Trim(txtCommDue.Text) = "" Then
     gMsg = "Commission due from rental agency cannot be blank. If no commission is " & _
            "due, enter 0"
     InsertTrigger = False
     SetFocusTo = "txtCommDue"
     Exit Function
  End If
  If txtCommDue.Text > 0 Then
     'Get number of non-cancelled accomodation rows for this conf.
     gSQL = "select count(*) from bbtbl " & _
            "where conf = " & CLng(txtConfNum.Text) & _
            " And suppress<>-1"
     Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp(0) = 0 Then
        gMsg = "At least one non-cancelled " & _
               "accommodation row must exist in Guest Accommodations if " & _
               "a guest retains a commissionable car reservation. If guest is " & _
               "requesting car reservations only, enter the 'Car Only' host property " & _
               "account into the Guest Accommodations scren, then " & _
               "cancel or delete all other guest accommodations."
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



Private Sub txtDropDate_LostFocus()

   If Not GetNumDays() Then Exit Sub

End Sub


Private Sub txtPickupDate_LostFocus()

   If Not GetNumDays() Then Exit Sub

End Sub



Public Function GetNumDays() As Integer
  
  GetNumDays = False
  
  If Not (GetFormMode(Me) = "Insert" Or GetFormMode(Me) = "Update") Then
     GetNumDays = True
     Exit Function
  End If
  'Calculate number of days
  If Trim(txtDropDate.Text) <> "" And Trim(txtPickupDate.Text) <> "" Then
    If DateFormatOk(Me.txtPickupDate) And DateFormatOk(Me.txtDropDate) Then
       txtNumDays.Text = DateDiff("d", Format(txtPickupDate.Text, "mm/dd/yyyy"), Format(txtDropDate.Text, "mm/dd/yyyy"))
    Else
       txtNumDays.Text = ""
       Exit Function
    End If
  Else
     txtNumDays.Text = ""
  End If
  
  GetNumDays = True
  
End Function

Public Sub GetSuggestedComm()

   On Error GoTo Comm_Error

   Dim SSTemp As Recordset
   Dim vPercent As Single
   
   If lblAcctNum.Caption = "" Then
      lblSuggCommAmt.Caption = ""
      GoTo Comm_Resume
   End If
   gSQL = "select CommPercent from CarMaster " & _
          "Where AccountNum=" & lblAcctNum.Caption
   Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
   GetSSRows SSTemp
   If IsNull(SSTemp(0)) Then
      lblSuggCommAmt.Caption = ""
      SSTemp.Close
      GoTo Comm_Resume
   End If
   If SSTemp.RecordCount > 0 Then
      If Trim(txtTotal.Text) <> "" And IsNumeric(Trim(txtTotal.Text)) Then
         lblSuggCommAmt.Caption = Format((SSTemp(0) / 100 * CDbl(txtTotal.Text)), CURRENCYFORMAT)
      Else
         lblSuggCommAmt.Caption = ""
      End If
   Else
      lblSuggCommAmt.Caption = ""
   End If
   SSTemp.Close
   
Comm_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
Comm_Error:
   Resume Comm_Resume

End Sub

Private Sub txtTotal_Change()

   If GetFormMode(Me) <> "Insert" And GetFormMode(Me) <> "Update" Then Exit Sub
   If Trim(txtTotal.Text) <> "" And lblAcctNum.Caption <> "" Then
      If IsNumeric(txtTotal.Text) Then
          GetSuggestedComm
      End If
   Else
      lblSuggCommAmt.Caption = ""
   End If

End Sub

Private Sub txtTotal_LostFocus()

   If GetFormMode(Me) <> "Insert" And GetFormMode(Me) <> "Update" Then Exit Sub
   If Trim(txtTotal.Text) <> "" And lblAcctNum.Caption <> "" Then
      If IsNumeric(txtTotal.Text) Then
          GetSuggestedComm
      End If
   Else
      lblSuggCommAmt.Caption = ""
   End If
   
End Sub


