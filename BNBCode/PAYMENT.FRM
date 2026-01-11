VERSION 5.00
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmPayment 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Guest Payments"
   ClientHeight    =   5790
   ClientLeft      =   1545
   ClientTop       =   1920
   ClientWidth     =   8790
   HelpContextID   =   107
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   5790
   ScaleWidth      =   8790
   Tag             =   "payment"
   Begin VB.Data datBrowse 
      Appearance      =   0  'Flat
      Caption         =   "datBrowse"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   180
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   5868
      Visible         =   0   'False
      Width           =   2235
   End
   Begin VB.PictureBox Picture1 
      Height          =   30
      Left            =   2700
      ScaleHeight     =   30
      ScaleWidth      =   75
      TabIndex        =   54
      Top             =   0
      Width           =   75
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
      Height          =   600
      Left            =   7440
      TabIndex        =   26
      Top             =   3270
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
      Height          =   600
      Left            =   7440
      TabIndex        =   24
      Top             =   2010
      Width           =   1335
   End
   Begin VB.Data datPaymentAppliedTo 
      Appearance      =   0  'Flat
      Caption         =   "datPaymentAppliedTo"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   5160
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   5850
      Visible         =   0   'False
      Width           =   2415
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
      Height          =   630
      Left            =   7440
      TabIndex        =   29
      Top             =   5160
      Width           =   1335
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
      Height          =   600
      Left            =   7440
      TabIndex        =   28
      Top             =   4530
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
      Height          =   600
      Left            =   7440
      TabIndex        =   27
      Top             =   3900
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
      Height          =   600
      Left            =   7440
      TabIndex        =   25
      Top             =   2640
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
      Height          =   600
      Left            =   7440
      TabIndex        =   23
      Top             =   1380
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
      Height          =   600
      Left            =   7440
      TabIndex        =   22
      Top             =   750
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
      Height          =   600
      Left            =   7440
      TabIndex        =   21
      Top             =   120
      Width           =   1335
   End
   Begin VB.Data datPaymentReceived 
      Appearance      =   0  'Flat
      Caption         =   "datPaymentReceived"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   2400
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   5850
      Visible         =   0   'False
      Width           =   2775
   End
   Begin VB.TextBox txtLastName 
      Appearance      =   0  'Flat
      DataField       =   "l_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1248
      MaxLength       =   25
      TabIndex        =   4
      Tag             =   "Text"
      Top             =   990
      Width           =   1404
   End
   Begin VB.TextBox txtFirstName 
      Appearance      =   0  'Flat
      DataField       =   "f_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1248
      MaxLength       =   25
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   570
      Width           =   1404
   End
   Begin VB.TextBox txtConfNum 
      Appearance      =   0  'Flat
      DataField       =   "conf"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1248
      MaxLength       =   9
      TabIndex        =   2
      Tag             =   "Number"
      Top             =   150
      Width           =   1404
   End
   Begin VB.Frame fraOtherCredits 
      Caption         =   "Other Guest Credits"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1425
      Left            =   5400
      TabIndex        =   45
      Top             =   60
      Width           =   1935
      Begin VB.TextBox txtOtherCredit 
         Appearance      =   0  'Flat
         DataField       =   "OtherCredit"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1140
         TabIndex        =   20
         Tag             =   "Currency"
         Top             =   840
         Width           =   735
      End
      Begin VB.TextBox txtDeferredComm 
         Appearance      =   0  'Flat
         DataField       =   "defcom"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1140
         TabIndex        =   19
         Tag             =   "Currency"
         Top             =   450
         Width           =   735
      End
      Begin VB.Label lblOtherCredit 
         Caption         =   "Other:"
         Height          =   255
         Left            =   120
         TabIndex        =   58
         Top             =   900
         Width           =   915
      End
      Begin VB.Label lblDeferredComm 
         Caption         =   "Deferred Commission:"
         Height          =   465
         Left            =   120
         TabIndex        =   46
         Top             =   360
         Width           =   975
      End
   End
   Begin VB.Frame fraPaymentReceived 
      Caption         =   "Payments Received from Guest"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1755
      Left            =   48
      TabIndex        =   39
      Top             =   3720
      Width           =   7284
      Begin VB.TextBox txtRecFrom 
         Appearance      =   0  'Flat
         DataField       =   "ReceivedFrom"
         DataSource      =   "datPaymentReceived"
         Height          =   285
         Left            =   4920
         TabIndex        =   16
         Tag             =   "Text"
         Top             =   270
         Width           =   2265
      End
      Begin VB.TextBox txtReceivedComments 
         Appearance      =   0  'Flat
         DataField       =   "Comments"
         DataSource      =   "datPaymentReceived"
         Height          =   735
         Left            =   3720
         MaxLength       =   255
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   17
         Tag             =   "Text"
         Top             =   930
         Width           =   3465
      End
      Begin VB.TextBox txtPaymentCheckNum 
         Appearance      =   0  'Flat
         DataField       =   "CheckNumber"
         DataSource      =   "datPaymentReceived"
         Height          =   285
         Left            =   1680
         MaxLength       =   40
         TabIndex        =   14
         Tag             =   "Text"
         Top             =   990
         Width           =   1815
      End
      Begin VB.TextBox txtPaymentRcvdDate 
         Appearance      =   0  'Flat
         DataField       =   "DateReceived"
         DataSource      =   "datPaymentReceived"
         Height          =   285
         Left            =   1680
         MaxLength       =   25
         TabIndex        =   13
         Tag             =   "Date"
         Top             =   630
         Width           =   1815
      End
      Begin VB.TextBox txtPaymentAmtRcvd 
         Appearance      =   0  'Flat
         DataField       =   "AmountReceived"
         DataSource      =   "datPaymentReceived"
         Height          =   285
         Left            =   1680
         TabIndex        =   12
         Tag             =   "Currency"
         Top             =   270
         Width           =   1815
      End
      Begin SSDataWidgets_B.SSDBCombo datdwComboPaymentAppliedTo 
         Bindings        =   "PAYMENT.frx":0000
         DataField       =   "AppliedTo"
         DataSource      =   "datPaymentReceived"
         Height          =   315
         Left            =   1680
         TabIndex        =   15
         Tag             =   "Text"
         Top             =   1350
         Width           =   1815
         ListAutoValidate=   0   'False
         ListWidthAutoSize=   0   'False
         _Version        =   131078
         BeginProperty HeadFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColorEven   =   0
         Columns(0).Width=   3200
         _ExtentX        =   3201
         _ExtentY        =   556
         _StockProps     =   93
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
      End
      Begin VB.Label lblRecFrom 
         Caption         =   "Received From:"
         Height          =   225
         Left            =   3720
         TabIndex        =   55
         Top             =   300
         Width           =   1155
      End
      Begin VB.Label lblPaymentAppliedTo 
         Caption         =   "Applied To:"
         Height          =   255
         Left            =   120
         TabIndex        =   50
         Top             =   1350
         Width           =   1095
      End
      Begin VB.Label lblRcvdComments 
         Caption         =   "Comment:"
         Height          =   255
         Left            =   3720
         TabIndex        =   48
         Top             =   750
         Width           =   1335
      End
      Begin VB.Label lblPaymentCheckNum 
         Caption         =   "Check Num/CC:"
         Height          =   255
         Left            =   120
         TabIndex        =   43
         Top             =   1020
         Width           =   1575
      End
      Begin VB.Label lblPaymentRcvdDate 
         Caption         =   "Date Received:"
         Height          =   255
         Left            =   120
         TabIndex        =   41
         Top             =   660
         Width           =   1575
      End
      Begin VB.Label lblPaymentAmtRcvd 
         Caption         =   "Payment Amount:"
         Height          =   255
         Left            =   120
         TabIndex        =   40
         Top             =   300
         Width           =   1575
      End
   End
   Begin VB.Frame fraRefundDue 
      Caption         =   "Refund Due to Guest"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1425
      Left            =   2760
      TabIndex        =   31
      Top             =   60
      Width           =   2595
      Begin VB.CommandButton cmdRefunds 
         Caption         =   "Insert/Update Refunds"
         Height          =   345
         Left            =   420
         TabIndex        =   61
         Top             =   1020
         Width           =   2055
      End
      Begin VB.OptionButton optRefByCC 
         Caption         =   "Refund by Credit Card/Other"
         Height          =   195
         Left            =   120
         TabIndex        =   60
         Top             =   780
         Width           =   2415
      End
      Begin VB.OptionButton optRefByCheck 
         Caption         =   "Refund by Check"
         Height          =   195
         Left            =   120
         TabIndex        =   59
         Top             =   240
         Width           =   2355
      End
      Begin VB.TextBox txtRefundOwed 
         Appearance      =   0  'Flat
         DataField       =   "RefundOwed"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   1500
         TabIndex        =   18
         Tag             =   "Currency"
         Top             =   450
         Width           =   975
      End
      Begin VB.Label lblRefundAmtDue 
         Caption         =   "Amount Due:"
         Height          =   255
         Left            =   420
         TabIndex        =   44
         Top             =   510
         Width           =   975
      End
   End
   Begin VB.Frame fraPaymentsDue 
      Caption         =   "Payments Due from Guest"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1815
      Left            =   60
      TabIndex        =   30
      Top             =   1530
      Width           =   7284
      Begin VB.TextBox txtDueComments 
         Appearance      =   0  'Flat
         DataField       =   "cmmnts"
         DataSource      =   "datBrowse"
         Height          =   675
         Left            =   3030
         MaxLength       =   255
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   11
         Tag             =   "Text"
         Top             =   1050
         Width           =   4155
      End
      Begin VB.TextBox txtCancelFeeDateRcvd 
         Appearance      =   0  'Flat
         DataField       =   "canclfeedatedue"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   5940
         MaxLength       =   25
         TabIndex        =   10
         Tag             =   "Date"
         Top             =   600
         Visible         =   0   'False
         Width           =   1095
      End
      Begin VB.TextBox txtCancelFee 
         Appearance      =   0  'Flat
         DataField       =   "canclfee"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   5940
         TabIndex        =   9
         Tag             =   "Currency"
         Top             =   240
         Visible         =   0   'False
         Width           =   1095
      End
      Begin VB.TextBox txtPrepayDueDate 
         Appearance      =   0  'Flat
         DataField       =   "predate"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1680
         MaxLength       =   25
         TabIndex        =   8
         Tag             =   "Date"
         Top             =   1440
         Width           =   1095
      End
      Begin VB.TextBox txtPrepayAmtDue 
         Appearance      =   0  'Flat
         DataField       =   "predue"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1680
         TabIndex        =   7
         Tag             =   "Currency"
         Top             =   1080
         Width           =   1095
      End
      Begin VB.TextBox txtDepositDueDate 
         Appearance      =   0  'Flat
         DataField       =   "depdate"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1680
         MaxLength       =   25
         TabIndex        =   6
         Tag             =   "Date"
         Top             =   600
         Width           =   1095
      End
      Begin VB.TextBox txtDepositAmtDue 
         Appearance      =   0  'Flat
         DataField       =   "depdue"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1680
         TabIndex        =   5
         Tag             =   "Currency"
         Top             =   240
         Width           =   1095
      End
      Begin VB.Label lblTotalCredit 
         Alignment       =   1  'Right Justify
         Caption         =   "yyyyy"
         BeginProperty Font 
            Name            =   "MS Serif"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   225
         Left            =   4650
         TabIndex        =   57
         Top             =   600
         Width           =   885
      End
      Begin VB.Label lblLabel2 
         Caption         =   "Total Guest Credit:"
         Height          =   225
         Left            =   3015
         TabIndex        =   56
         Top             =   570
         Width           =   1575
      End
      Begin VB.Label lblCalcAmtDue 
         Alignment       =   1  'Right Justify
         Caption         =   "xxxxx"
         BeginProperty Font 
            Name            =   "MS Serif"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   225
         Left            =   4710
         TabIndex        =   53
         Top             =   270
         Width           =   825
      End
      Begin VB.Label lblLabel1 
         Caption         =   "Total Due From Guest:"
         Height          =   240
         Left            =   3015
         TabIndex        =   52
         Top             =   240
         Width           =   1680
      End
      Begin VB.Label lblDueComments 
         Caption         =   "Blind Comment:"
         Height          =   225
         Left            =   3030
         TabIndex        =   49
         Top             =   870
         Width           =   1425
      End
      Begin VB.Label lblCancelDueDate 
         Caption         =   "Date Due:"
         Height          =   255
         Left            =   5865
         TabIndex        =   42
         Top             =   630
         Visible         =   0   'False
         Width           =   1335
      End
      Begin VB.Label lblCancelFeeAmtDue 
         Caption         =   "Cancellation Fee:"
         Height          =   255
         Left            =   5865
         TabIndex        =   38
         Top             =   270
         Visible         =   0   'False
         Width           =   1335
      End
      Begin VB.Label lblPrepayDueDate 
         Caption         =   "Date Due:"
         Height          =   255
         Left            =   120
         TabIndex        =   37
         Top             =   1470
         Width           =   1575
      End
      Begin VB.Label lblDepositDueDate 
         Caption         =   "Date Due:"
         Height          =   255
         Left            =   120
         TabIndex        =   36
         Top             =   630
         Width           =   1575
      End
      Begin VB.Label lblPrepayAmtDue 
         Caption         =   "Prepayment Amount:"
         Height          =   255
         Left            =   120
         TabIndex        =   35
         Top             =   1110
         Width           =   1575
      End
      Begin VB.Label lblDepositAmtDue 
         Caption         =   "Deposit Amount:"
         Height          =   255
         Left            =   120
         TabIndex        =   34
         Top             =   270
         Width           =   1575
      End
   End
   Begin SSDataWidgets_A.SSDBData datdwData2 
      Bindings        =   "PAYMENT.frx":001E
      Height          =   336
      Left            =   72
      TabIndex        =   0
      Top             =   3336
      Width           =   7284
      _Version        =   131075
      _ExtentX        =   12859
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
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "PAYMENT.frx":0032
      Height          =   336
      Left            =   48
      TabIndex        =   1
      Top             =   5460
      Width           =   7284
      _Version        =   131075
      _ExtentX        =   12859
      _ExtentY        =   582
      _StockProps     =   79
      ShowAddButton   =   0   'False
      ShowCancelButton=   0   'False
      ShowDelButton   =   0   'False
      ShowUpdateButton=   0   'False
      BevelOuter      =   0
      ShowBookmarkButtons=   0
      ShowFindButtons =   0
   End
   Begin VB.Label lblReceivedConf 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      DataField       =   "conf"
      DataSource      =   "datPaymentReceived"
      ForeColor       =   &H80000008&
      Height          =   255
      Left            =   180
      TabIndex        =   51
      Top             =   6150
      Visible         =   0   'False
      Width           =   975
   End
   Begin VB.Label lblFirstName 
      Caption         =   "First Name:"
      Height          =   252
      Left            =   48
      TabIndex        =   47
      Top             =   600
      Width           =   1092
   End
   Begin VB.Label lblLastName 
      Caption         =   "Last Name:"
      Height          =   252
      Left            =   48
      TabIndex        =   33
      Top             =   1020
      Width           =   1092
   End
   Begin VB.Label lblConfNum 
      Caption         =   "Conf Number:"
      Height          =   252
      Left            =   48
      TabIndex        =   32
      Top             =   180
      Width           =   1092
   End
End
Attribute VB_Name = "frmPayment"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
Dim CurrRec1 As Long
Dim CurrRec2 As Long
Dim SaveRec1 As Long
Dim SaveRec2 As Long
Dim InsertingFromBrowseMode As Integer
Dim InsertingFromNoRowsMode As Integer
Dim NullDateArray()
Dim FailedLostFocus As Integer
Dim SetFocusTo As String
Dim OrigAppliedTo As String


Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error
   
   Select Case GetFormMode(Me)
     Case "Insert"
        If datBrowse.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
        If datPaymentReceived.EditMode = dbEditAdd Then datPaymentReceived.Recordset.CancelUpdate
        PaymentsReceivedMode ("Enabled")
        'MsgBox Str$(gConfNum)
     Case "Update"
        If datBrowse.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
        If datPaymentReceived.EditMode = dbEditInProgress Then datPaymentReceived.Recordset.CancelUpdate
        PaymentsReceivedMode ("Enabled")
     Case "Find"
        cmdFind.Caption = "&Find"
     Case Else
        'do nothing
   End Select
   datBrowse.UpdateControls
   datPaymentReceived.UpdateControls
   If datBrowse.Recordset.RecordCount = 0 Then
     SetFormToNoRowsMode Me
     lblCalcAmtDue.Caption = ""
     lblTotalCredit.Caption = ""
     cmdInsert.SetFocus
   Else
     SetFormToBrowseMode Me
     CurrRec2 = GetCurrentRowNumber(datBrowse)
     datdwData2.Caption = "[Payments Due] Row " & CurrRec2 & " of " & datBrowse.Recordset.RecordCount
     CurrRec1 = GetCurrentRowNumber(datPaymentReceived)
     datdwData1.Caption = "[Payments Received] Row " & CurrRec1 & " of " & datPaymentReceived.Recordset.RecordCount
     txtConfNum.SetFocus
   End If
   If Not OtherGuestFormsInBrowseMode And GetFormMode(Me) = "No Rows" Then gConfNum = 0
   InsertingFromNoRowsMode = False
   InsertingFromBrowseMode = False
   SetRefundButtons
   'Get payment received info for current conf.
   If GetFormMode(Me) = "Browse" And Trim(txtConfNum.Text) <> "" Then
      Screen.MousePointer = HOURGLASS
      datPaymentReceived.RecordSource = "select * from paymentreceived where conf = " & CLng(txtConfNum.Text)
      If Not GetDCRows(datPaymentReceived) Then GoTo cmdCancel_Click_Resume
      CurrRec1 = GetCurrentRowNumber(datPaymentReceived)
      datdwData1.Caption = "[Payments Received] Row " & CurrRec1 & " of " & datPaymentReceived.Recordset.RecordCount
      'Get Calculated total due and display on form
      GetCalcTotalDue
      If Not VerifyTotalDue Then GoTo cmdCancel_Click_Resume
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
    Dim SSTemp As Recordset
    Dim TempBook As Variant
    Dim RetVal, i As Integer
    Screen.MousePointer = HOURGLASS
    lblReceivedConf.Caption = txtConfNum.Text  'Update conf number in copy buffer for datPaymentReceived
    
    Select Case GetFormMode(Me)
      Case "Insert"
        'Check for valid dates and number formats
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Fillin Received From if user entered received info
        If Trim(txtPaymentAmtRcvd.Text) <> "" Then
           If Trim(txtRecFrom.Text) = "" Then txtRecFrom.Text = Trim(txtLastName.Text)
        End If
        'Check for specifics of frmPayment
        If Not InsertTrigger() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'If number formats are OK, then set currency formats
        SetToCurrencyFormat Me
        'Warn user if they are atempting to update a record to be applied to prepayment,
        'and there is already a payment received which has been applied to prepayment.
        'Service Fee may need to be adjusted because guest has revised reservations, and a
        'service fee has already been taken from the original prepayment.
        If datdwComboPaymentAppliedTo.Text = "Prepayment" Then
           Set SSTemp = gBNB.OpenRecordset("select count(*) from paymentreceived where conf = " & txtConfNum.Text & " and AppliedTo = 'Prepayment'", dbOpenSnapshot)
           GetSSRows SSTemp
           If IsNull(SSTemp(0)) Or SSTemp(0) = 0 Then
              'No previously entered prepayments - allow entry of prepayment.
           ElseIf SSTemp(0) > 1 Then
              gMsg = "Previous payments received have already been applied to Prepayment. " & _
                     "Service fee for this confirmation may need adjustment if this payment " & _
                     "is also entered as a Prepayment. Continue with entry?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, "Payments Received") = IDNO Then
                 GoTo cmdCommit_Click_Resume
              End If
           Else
              gMsg = "A previous payment received has already been applied to Prepayment. " & _
                     "Service fee for this confirmation may need adjustment if this payment " & _
                     "is also entered as a Prepayment. Continue with entry?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, "Payments Received") = IDNO Then
                 GoTo cmdCommit_Click_Resume
              End If
           End If
        End If
        If NoReceivedFieldsEntered() Then datPaymentReceived.Recordset.CancelUpdate
        'If new record is being added
        If datBrowse.EditMode = dbEditAdd Then
           'Check if any Date, Currency or Number fields were set to blank (0
           'length string); if so, unbind control's DataField property and commit Null.
           RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
           datBrowse.Recordset.Update
           datBrowse.RecordSource = "select * from payment where conf = " & gConfNum
           If Not GetDCRows(datBrowse) Then Exit Sub
           'Do if there was at least one Date or Number set to null
           If RetVal Then BindNullDateControl Me, NullDateArray
        End If
        'If new payment received record is being added
        If datPaymentReceived.EditMode = dbEditAdd Then
           'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
           'unbind control's DataField property and commit Null.
           RetVal = UnbindNullDateControl(Me, datPaymentReceived, NullDateArray)
           datPaymentReceived.Recordset.Update
           'getting No Current Record here. Put next (1) line in to correct.
           datPaymentReceived.Recordset.Bookmark = datPaymentReceived.Recordset.LastModified
           'Do if there was at least one Date or Number set to null
           If RetVal Then BindNullDateControl Me, NullDateArray
           'When gConfNum is not set, Recordsource for datPaymentReceived is
           'set to ...where gConfNum=0 upon insert_click. Now we have a valid
           'conf num to work with; so, reset it.
           datPaymentReceived.RecordSource = "select * from paymentreceived where conf = " & gConfNum
           If Not GetDCRows(datPaymentReceived) Then Exit Sub
           If Not datPaymentReceived.Recordset.EOF And Not datPaymentReceived.Recordset.BOF Then datPaymentReceived.Recordset.MoveLast
           'datPaymentReceived.Recordset.Bookmark = datPaymentReceived.Recordset.LastModified
        End If
        'Get Calculated total due and display on form
        GetCalcTotalDue
        For i = 1 To 5
           DoEvents
        Next i
        SetToCurrencyFormat Me
        'Update Deferred Commission checkbox in Guest Travel Agency.
        If Trim(txtDeferredComm.Text) <> "" Then
           If CCur(Trim(txtDeferredComm.Text)) > 0 Then
             gBNB.Execute "UPDATE tagentbl SET DefCom = -1 " & _
             " WHERE conf = " & txtConfNum.Text & ";"
           End If
        Else
           gBNB.Execute "UPDATE tagentbl SET DefCom = 0 " & _
           " WHERE conf = " & txtConfNum.Text & ";"
        End If
        'Compare total user entered with system-determined total.
        If Not VerifyTotalDue() Then MsgBox gMsg, MB_ICONEXCLAMATION, Me.Caption
      Case "Update"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Fillin Received From if user entered received info
        If Trim(txtPaymentAmtRcvd.Text) <> "" Then
           If Trim(txtRecFrom.Text) = "" Then txtRecFrom.Text = Trim(txtLastName.Text)
        End If
        'Check for specifics of frmPayment
        If Not InsertTrigger() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'If number formats are OK, then set currency formats
        SetToCurrencyFormat Me
        'Warn user if they are atempting to update a record to be applied to prepayment,
        'and there is already a payment received which has been applied to prepayment.
        'Service Fee may need to be adjusted because guest has revised reservations, and a
        'service fee has already been taken from the original prepayment.
        If datdwComboPaymentAppliedTo.Text = "Prepayment" And OrigAppliedTo <> "Prepayment" Then
           Set SSTemp = gBNB.OpenRecordset("select count(*) from paymentreceived where conf = " & txtConfNum.Text & " and AppliedTo = 'Prepayment'", dbOpenSnapshot)
           GetSSRows SSTemp
           If IsNull(SSTemp(0)) Or SSTemp(0) = 0 Then
              'No previously entered prepayments - allow entry of prepayment.
           ElseIf SSTemp(0) > 1 Then
              gMsg = "Previous payments received have already been applied to Prepayment. " & _
                     "Service fee for this confirmation may need adjustment if this payment " & _
                     "is also entered as a Prepayment. Continue with entry?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, "Payments Received") = IDNO Then
                 GoTo cmdCommit_Click_Resume
              End If
           Else
              gMsg = "A previous payment received has already been applied to Prepayment. " & _
                     "Service fee for this confirmation may need adjustment if this payment " & _
                     "is also entered as a Prepayment. Continue with entry?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, "Payments Received") = IDNO Then
                 GoTo cmdCommit_Click_Resume
              End If
           End If
        End If
        If datBrowse.EditMode = dbEditInProgress Then
           'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
           'unbind control's DataField property and commit Null.
           RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
           datBrowse.Recordset.Update
           'Do if there was at least one Date or Number was set to null
           If RetVal Then BindNullDateControl Me, NullDateArray
           'Make the current record current again. There will only be
           'one record in the datBrowse control for frmPayment(one per conf num)
           'so don't need to look for LastModified.
           datBrowse.UpdateControls
        End If
        If datPaymentReceived.EditMode = dbEditInProgress Then
           'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
           'unbind control's DataField property and commit Null.
           RetVal = UnbindNullDateControl(Me, datPaymentReceived, NullDateArray)
           datPaymentReceived.Recordset.Update
           'Do if there was at least one Date or Number set to null
           If RetVal Then BindNullDateControl Me, NullDateArray
           'Make the current record current again
           datPaymentReceived.UpdateControls
           'datPaymentReceived.Recordset.Bookmark = datPaymentReceived.Recordset.LastModified
        End If
        'Get Calculated total due and display on form
        GetCalcTotalDue
        SetToCurrencyFormat Me
        'Update Deferred Commission checkbox in Guest Travel Agency.
        If Trim(txtDeferredComm.Text) <> "" Then
           If CCur(Trim(txtDeferredComm.Text)) > 0 Then
             gBNB.Execute "UPDATE tagentbl SET DefCom = -1 " & _
             " WHERE conf = " & txtConfNum.Text & ";"
           End If
        Else
           gBNB.Execute "UPDATE tagentbl SET DefCom = 0 " & _
           " WHERE conf = " & txtConfNum.Text & ";"
        End If
        'Compare total user entered with system-determined total.
        If Not VerifyTotalDue() Then MsgBox gMsg, MB_ICONEXCLAMATION, Me.Caption
      Case "Delete"
        If datPaymentReceived.Recordset.RecordCount > 0 Then
           gMsg = "Delete the current Payment Received record?"
           If MsgBox(gMsg, MB_ICONQUESTION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDYES Then
               datPaymentReceived.Recordset.Delete
               datPaymentReceived.Refresh
               'Position to the next remaining row in the recordset.
               If datPaymentReceived.Recordset.RecordCount > 1 Then
                   datPaymentReceived.Recordset.MoveNext
                   'If there is no next row to position to, move to the last remaining row (if any).
                   If datPaymentReceived.Recordset.EOF And Not datPaymentReceived.Recordset.BOF Then
                      datPaymentReceived.Recordset.MoveLast
                   ElseIf Not datPaymentReceived.Recordset.EOF And datPaymentReceived.Recordset.BOF Then
                      datPaymentReceived.Recordset.MoveFirst
                   End If
               ElseIf datPaymentReceived.Recordset.RecordCount = 1 Then
                   datPaymentReceived.Recordset.MoveLast
               Else
                  'All rows have been removed. If AddNew is invoked (Insert is clicked)
                  'at this point, error will occur if data control is not Refreshed.
                  datPaymentReceived.Refresh
                  'no movement
               End If
               'Get Calculated total due and display on form
               GetCalcTotalDue
           End If
        Else
           gMsg = "Delete this guest's Payment Due information?"
           If MsgBox(gMsg, MB_ICONQUESTION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDYES Then
               gBNB.Execute "UPDATE tagentbl SET DefCom = 0 WHERE conf = " & gConfNum
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
        End If
      Case Else
    End Select
    If datBrowse.Recordset.RecordCount = 0 Then
      SetFormToNoRowsMode Me
      lblCalcAmtDue.Caption = ""
      lblTotalCredit.Caption = ""
    Else
      SetFormToBrowseMode Me
      CurrRec2 = GetCurrentRowNumber(datBrowse)
      datdwData2.Caption = "[Payments Due] Row " & CurrRec2 & " of " & datBrowse.Recordset.RecordCount
      CurrRec1 = GetCurrentRowNumber(datPaymentReceived)
      datdwData1.Caption = "[Payments Received] Row " & CurrRec1 & " of " & datPaymentReceived.Recordset.RecordCount
    End If
    InsertingFromNoRowsMode = False
    InsertingFromBrowseMode = False
   
cmdCommit_Click_Resume:
    'Return mousepointer to its original state.
    Screen.MousePointer = DEFAULT
    SetRefundButtons
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
    gCaption = "Guest Payments Due Listing"
    gSQL = datBrowse.RecordSource
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
   
   Dim Criteria, DueStr, FinalStr As String
   If cmdFind.Caption = "&Find" Then
      SetFormToFindMode Me
      cmdFind.DEFAULT = True
      lblCalcAmtDue.Caption = ""
      lblTotalCredit.Caption = ""
      optRefByCheck.Value = CHECKED
      cmdRefunds.Enabled = False
      txtConfNum.SetFocus
      cmdFind.Caption = "&Run Query"
   Else
      cmdFind.Caption = "&Find"
      If NoReceivedFieldsEntered() Then
         Criteria = BuildFindCriteria(Me, "")
         If Criteria <> "" Then
            datBrowse.UpdateControls
            datBrowse.RecordSource = Criteria
            Screen.MousePointer = HOURGLASS
            If Not GetDCRows(datBrowse) Then GoTo cmdFind_Click_Resume
            'Screen.MousePointer = DEFAULT
            If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
               SetFormToNoRowsMode Me
               lblCalcAmtDue.Caption = ""
               lblTotalCredit.Caption = ""
            Else
               SetFormToBrowseMode Me
               'Setup Payment Due control
               CurrRec2 = GetCurrentRowNumber(datBrowse)
               datdwData2.Caption = "[Payments Due] Row " & CurrRec2 & " of " & datBrowse.Recordset.RecordCount
               'Setup Payment Received control
               datPaymentReceived.RecordSource = "select * from paymentreceived where conf = " & CLng(txtConfNum.Text)
               Screen.MousePointer = HOURGLASS
               If Not GetDCRows(datPaymentReceived) Then GoTo cmdFind_Click_Resume
               If datPaymentReceived.Recordset.EOF And datPaymentReceived.Recordset.BOF Then
                  datdwData1.Caption = "No payments received"
               Else
                  CurrRec1 = GetCurrentRowNumber(datPaymentReceived)
                  datdwData1.Caption = "[Payments Received] Row " & CurrRec1 & " of " & datPaymentReceived.Recordset.RecordCount
               End If
               'Screen.MousePointer = DEFAULT
            End If
         Else
            SetFormToNoRowsMode Me
            lblCalcAmtDue.Caption = ""
            lblTotalCredit.Caption = ""
         End If
         txtConfNum.SetFocus
         'Screen.MousePointer = DEFAULT
      Else
         'Table join needed.
         'Build query for DUE section.
         Dim TempStr As String
         Dim LenTempStr
         Dim Counter As Integer
         Counter = 0
         TempStr = "select * from " & Me.Tag & " where "
         LenTempStr = Len(TempStr)
         For i = 0 To Me.Controls.Count - 1
           If Me.Controls(i).Name <> "txtPaymentAmtRcvd" _
           And Me.Controls(i).Name <> "txtPaymentRcvdDate" _
           And Me.Controls(i).Name <> "txtPaymentCheckNum" _
           And Me.Controls(i).Name <> "txtRecFrom" _
           And Me.Controls(i).Name <> "datdwComboPaymentAppliedTo" _
           And Me.Controls(i).Name <> "txtReceivedComments" Then
            If Me.Controls(i).Name Like "txt*" Or Me.Controls(i).Name Like "datdwCombo*" Then
              If Trim$(Me.Controls(i).Text) <> "" Then
                 If Counter > 0 Then
                   TempStr = TempStr & " and "
                 End If
                 Counter = Counter + 1
                 If Me.Controls(i).Tag = "Number" Or Me.Controls(i).Tag = "Currency" Then
                    If Not IsNumeric(Me.Controls(i).Text) Then
                      gMsg = "'" & Me.Controls(i).Text & "' was entered into a number field. Only numbers can be entered into these fields."
                      GoTo BuildFindCriteria_Invalid_Characters
                    Else
                      TempStr = TempStr & Me.Controls(i).DataField & " = " & Me.Controls(i).Text
                    End If
                 Else
                   If Me.Controls(i).Text Like "*[']*" Then 'Single quote symbol needs to be removed.
                      Me.Controls(i).Text = Replace_All_In_With("'", Me.Controls(i).Text, "*")
                      'gMsg = "Single quote (') not allowed in Find criteria."
                      'GoTo BuildFindCriteria_Invalid_Characters
                   End If
                   If Me.Controls(i).Tag = "Date" Then
                      If Me.Controls(i).Text Like "*[*]*" Then
                         'Ensure valid date format for wildcard date.
                         If Not GetWildcardDate(Me.Controls(i).Text) Then
                           'gMsg has just been set in GetWildcardDate().
                           GoTo BuildFindCriteria_Invalid_Characters
                         End If
                         Select Case gWCardDateCase
                           Case 0
                              'gMsg = "Need to supply at least one date part (month, day, or year) for wildcard find (eg, 1/*/98)"
                              'GoTo BuildFindCriteria_Invalid_Characters
                           Case 1
                              TempStr = TempStr & " DatePart('yyyy'," & Me.Controls(i).DataField & ") = " & CInt(gYear)
                           Case 2
                              TempStr = TempStr & " DatePart('d'," & Me.Controls(i).DataField & ") = " & CInt(gDay)
                           Case 3
                              TempStr = TempStr & " DatePart('d'," & Me.Controls(i).DataField & ") = " & CInt(gDay)
                              TempStr = TempStr & " And DatePart('yyyy'," & Me.Controls(i).DataField & ") = " & CInt(gYear)
                           Case 4
                              TempStr = TempStr & " DatePart('m'," & Me.Controls(i).DataField & ") = " & CInt(gMonth)
                           Case 5
                              TempStr = TempStr & " DatePart('m'," & Me.Controls(i).DataField & ") = " & CInt(gMonth)
                              TempStr = TempStr & " And DatePart('yyyy'," & Me.Controls(i).DataField & ") = " & CInt(gYear)
                           Case 6
                              TempStr = TempStr & " DatePart('m'," & Me.Controls(i).DataField & ") = " & CInt(gMonth)
                              TempStr = TempStr & " And DatePart('d'," & Me.Controls(i).DataField & ") = " & CInt(gDay)
                           Case 7
                              'Not a wildcard date.
                           Case Else
                              '
                         End Select
                      'Ensure valid date format if not using wildcards
                      ElseIf Not DateFormatOk(Me.Controls(i)) Then
                         gMsg = "Invalid date. Use mm/dd/yy format."
                         GoTo BuildFindCriteria_Invalid_Characters
                      Else
                         'MS Access requires pound signs (#) around date values (literals) in select queries.
                         TempStr = TempStr & Me.Controls(i).DataField & " = #" & Trim$(Me.Controls(i).Text) & "#"
                      End If
                   Else
                      If Me.Controls(i).Text Like "*[*]*" Then
                         TempStr = TempStr & Me.Controls(i).DataField & " Like '" & Me.Controls(i).Text & "'"
                      Else
                         TempStr = TempStr & Me.Controls(i).DataField & " = '" & Me.Controls(i).Text & "'"
                      End If
                   End If
                 End If
              End If
            End If
           End If  'Not Pay Rec field
         Next i
         If LenTempStr = Len(TempStr) Then
            TempStr = TempStr & " conf in("
         Else
            TempStr = TempStr & " And conf in("
         End If
         DueStr = TempStr
        'Build query for RECEIVED section
         Counter = 0
         TempStr = "select conf from paymentreceived where "
         LenTempStr = Len(TempStr)
         For i = 0 To Me.Controls.Count - 1
           If Me.Controls(i).Name = "txtPaymentAmtRcvd" _
           Or Me.Controls(i).Name = "txtPaymentRcvdDate" _
           Or Me.Controls(i).Name = "txtPaymentCheckNum" _
           Or Me.Controls(i).Name = "txtRecFrom" _
           Or Me.Controls(i).Name = "datdwComboPaymentAppliedTo" _
           Or Me.Controls(i).Name = "txtReceivedComments" Then
            If Me.Controls(i).Name Like "txt*" Or Me.Controls(i).Name Like "datdwCombo*" Then
              If Trim$(Me.Controls(i).Text) <> "" Then
                 If Counter > 0 Then
                   TempStr = TempStr & " and "
                 End If
                 Counter = Counter + 1
                 If Me.Controls(i).Tag = "Number" Or Me.Controls(i).Tag = "Currency" Then
                    If Not IsNumeric(Me.Controls(i).Text) Then
                      gMsg = "'" & Me.Controls(i).Text & "' was entered into a number field. Only numbers can be entered into these fields."
                      GoTo BuildFindCriteria_Invalid_Characters
                    Else
                      TempStr = TempStr & Me.Controls(i).DataField & " = " & Me.Controls(i).Text
                    End If
                 Else
                   If Me.Controls(i).Text Like "*[']*" Then 'Single quote symbol needs to be removed.
                      Me.Controls(i).Text = Replace_All_In_With("'", Me.Controls(i).Text, "*")
                      'gMsg = "Single quote (') not allowed in Find criteria."
                      'GoTo BuildFindCriteria_Invalid_Characters
                   End If
                   If Me.Controls(i).Tag = "Date" Then
                      If Me.Controls(i).Text Like "*[*]*" Then
                         'Ensure valid date format for wildcard date.
                         If Not GetWildcardDate(Me.Controls(i).Text) Then
                           'gMsg has just been set in GetWildcardDate().
                           GoTo BuildFindCriteria_Invalid_Characters
                         End If
                         Select Case gWCardDateCase
                           Case 0
                              'gMsg = "Need to supply at least one date part (month, day, or year) for wildcard find (eg, 1/*/98)"
                              'GoTo BuildFindCriteria_Invalid_Characters
                           Case 1
                              TempStr = TempStr & " DatePart('yyyy'," & Me.Controls(i).DataField & ") = " & CInt(gYear)
                           Case 2
                              TempStr = TempStr & " DatePart('d'," & Me.Controls(i).DataField & ") = " & CInt(gDay)
                           Case 3
                              TempStr = TempStr & " DatePart('d'," & Me.Controls(i).DataField & ") = " & CInt(gDay)
                              TempStr = TempStr & " And DatePart('yyyy'," & Me.Controls(i).DataField & ") = " & CInt(gYear)
                           Case 4
                              TempStr = TempStr & " DatePart('m'," & Me.Controls(i).DataField & ") = " & CInt(gMonth)
                           Case 5
                              TempStr = TempStr & " DatePart('m'," & Me.Controls(i).DataField & ") = " & CInt(gMonth)
                              TempStr = TempStr & " And DatePart('yyyy'," & Me.Controls(i).DataField & ") = " & CInt(gYear)
                           Case 6
                              TempStr = TempStr & " DatePart('m'," & Me.Controls(i).DataField & ") = " & CInt(gMonth)
                              TempStr = TempStr & " And DatePart('d'," & Me.Controls(i).DataField & ") = " & CInt(gDay)
                           Case 7
                              'Not a wildcard date.
                           Case Else
                              '
                         End Select
                      'Ensure valid date format if not using wildcards
                      ElseIf Not DateFormatOk(Me.Controls(i)) Then
                         gMsg = "Invalid date. Use mm/dd/yy format."
                         GoTo BuildFindCriteria_Invalid_Characters
                      Else
                         'MS Access requires pound signs (#) around date values (literals) in select queries.
                         TempStr = TempStr & Me.Controls(i).DataField & " = #" & Trim$(Me.Controls(i).Text) & "#"
                      End If
                   Else
                      If Me.Controls(i).Text Like "*[*]*" Then
                         TempStr = TempStr & Me.Controls(i).DataField & " Like '" & Me.Controls(i).Text & "'"
                      Else
                         TempStr = TempStr & Me.Controls(i).DataField & " = '" & Me.Controls(i).Text & "'"
                      End If
                   End If
                 End If
              End If
            End If
           End If  'Not Pay Rec field
         Next i
         FinalStr = DueStr & TempStr & ") order by conf"
         datBrowse.RecordSource = FinalStr
         Screen.MousePointer = HOURGLASS
         If Not GetDCRows(datBrowse) Then GoTo cmdFind_Click_Resume
         'Screen.MousePointer = DEFAULT
         DoEvents
         If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
            SetFormToNoRowsMode Me
            lblCalcAmtDue.Caption = ""
            lblTotalCredit.Caption = ""
         Else
            SetFormToBrowseMode Me
            'Setup Payment Due control
            CurrRec2 = GetCurrentRowNumber(datBrowse)
            datdwData2.Caption = "[Payments Due] Row " & CurrRec2 & " of " & datBrowse.Recordset.RecordCount
            'Setup Payment Received control
            datPaymentReceived.RecordSource = "select * from paymentreceived where conf = " & CLng(txtConfNum.Text)
            Screen.MousePointer = HOURGLASS
            If Not GetDCRows(datPaymentReceived) Then GoTo cmdFind_Click_Resume
            If datPaymentReceived.Recordset.EOF And datPaymentReceived.Recordset.BOF Then
               datdwData1.Caption = "No payments received"
            Else
               CurrRec1 = GetCurrentRowNumber(datPaymentReceived)
               datdwData1.Caption = "[Payments Received] Row " & CurrRec1 & " of " & datPaymentReceived.Recordset.RecordCount
            End If
            'Screen.MousePointer = DEFAULT
         End If
      End If
      SetRefundButtons
      'Display calculated total due on form
      GetCalcTotalDue
      If Not VerifyTotalDue Then GoTo cmdFind_Click_Resume
   End If
   
cmdFind_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdFind_Click_Error:
    'MsgBox Err.Description
    If IsError("cmdFind_Click") Then
        Resume cmdFind_Click_Resume
    Else
        Resume cmdFind_Click_Resume
        'Resume Next
    End If
    
BuildFindCriteria_Invalid_Characters:
  MsgBox gMsg, MB_ICONSTOP, Me.Caption
  Screen.MousePointer = DEFAULT
  GoTo cmdFind_Click_Resume
  
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
    
    PaymentsReceivedMode ("Enabled")
    datPaymentReceived.RecordSource = "select * from paymentreceived where conf = " & gConfNum
     
    If GetFormMode(Me) = "Browse" Then
       InsertingFromBrowseMode = True
       InsertingFromNoRowsMode = False
       datPaymentReceived.RecordSource = "select * from paymentreceived where conf = " & gConfNum
       If Not GetDCRows(datPaymentReceived) Then GoTo cmdInsert_Click_Resume
       datPaymentReceived.Recordset.AddNew
       SetFormToInsertMode Me
       'Disable all but Payments Received section
       SetPaymentToReceiveInsertMode Me
       txtPaymentAmtRcvd.SetFocus
    Else 'In No Rows mode
       InsertingFromNoRowsMode = True
       InsertingFromBrowseMode = False
       If Trim(datBrowse.RecordSource) = "" Then
          datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = 0"
          If Not GetDCRows(datBrowse) Then GoTo cmdInsert_Click_Resume
       End If
       datPaymentReceived.RecordSource = "select * from paymentreceived where conf = 0"
       If Not GetDCRows(datPaymentReceived) Then GoTo cmdInsert_Click_Resume
       datBrowse.Recordset.AddNew
       datPaymentReceived.Recordset.AddNew
       SetZeroLengthString Me
       SetFormToInsertMode Me
       txtFirstName.Locked = True
       txtLastName.Locked = True
       txtFirstName.ForeColor = BLACK
       txtLastName.ForeColor = BLACK
       txtDepositAmtDue.SetFocus
    End If
    txtRecFrom.ForeColor = BLUE
    txtRecFrom.Locked = False
    'Get first and last name if gConfNum is set.
    If gConfNum <> 0 Then
       Dim SSTemp As Recordset
       txtConfNum.Locked = True
       txtConfNum.ForeColor = BLACK
       Set SSTemp = gBNB.OpenRecordset("select f_name,l_name from guesttbl where conf = " & gConfNum, dbOpenSnapshot)
       GetSSRows SSTemp
       If SSTemp.RecordCount > 0 Then
          txtConfNum.Text = gConfNum
          If Not IsNull(SSTemp("f_name")) Then txtFirstName.Text = SSTemp("f_name")
          If Not IsNull(SSTemp("l_name")) Then
             txtLastName.Text = SSTemp("l_name")
             'Fillin the Received From text box if blank.
             If InsertingFromBrowseMode Then
                If Trim(txtRecFrom.Text) = "" Then txtRecFrom.Text = SSTemp("l_name")
                txtPaymentRcvdDate = Format$(Now, "m/d/yyyy")
             End If
          End If
          'Get Calculated total due and display on form
          GetCalcTotalDue
       End If
       SSTemp.Close
    Else
       txtConfNum.Locked = False
       txtConfNum.ForeColor = BLUE
    End If
    'Put cursor in correct box
    If InsertingFromBrowseMode Then
       txtPaymentAmtRcvd.SetFocus
    ElseIf InsertingFromNoRowsMode And txtConfNum.Text = "" Then
       txtConfNum.SetFocus
    ElseIf InsertingFromNoRowsMode Then
       txtDepositAmtDue.SetFocus
    End If
    SetRefundButtons
    
cmdInsert_Click_Resume:
   Exit Sub
   
cmdInsert_Click_Error:
   MsgBox Err.Description
   Resume cmdInsert_Click_Resume
    
End Sub


Private Sub cmdRefunds_Click()

   On Error GoTo cmdRefunds_Click_Error
   If Trim(txtConfNum.Text) <> "" Then
      Dim SSTemp As Recordset
      Set SSTemp = gBNB.OpenRecordset("select conf from payment where conf = " & txtConfNum.Text, dbOpenSnapshot)
      GetSSRows SSTemp
      If SSTemp.RecordCount = 0 Then
         SSTemp.Close
         gMsg = "Confirmation number " & txtConfNum.Text & " does not exist in Guest Payments. It must be Committed to the database before refunds can be entered."
         MsgBox gMsg, MB_ICONSTOP, Me.Caption
      Else
         SSTemp.Close
         frmRefundByCC.Show 1
         DoEvents
         Dim X&
         frmPayment.SetFocus
         X& = ShowWindow(frmPayment.hwnd, SW_SHOWNORMAL)
         DoEvents
         GetCalcTotalDue
      End If
   Else
      gMsg = "A row must be showing in the Guest Payments screen before refunds can be entered."
      MsgBox gMsg, MB_ICONSTOP, Me.Caption
   End If
   
cmdRefunds_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdRefunds_Click_Error:
   Resume cmdRefunds_Click_Resume
   
End Sub

Private Sub cmdUpdate_Click()

   On Error GoTo cmdUpdate_Click_Error
   
   OrigAppliedTo = Trim(datdwComboPaymentAppliedTo.Text)
   SetFormToUpdateMode Me
   datBrowse.Recordset.Edit
   If datPaymentReceived.Recordset.RecordCount > 0 Then
     PaymentsReceivedMode ("Enabled")
     datPaymentReceived.Recordset.Edit
   Else
     PaymentsReceivedMode ("Disabled")
   End If
   txtDepositAmtDue.SetFocus
   SetRefundButtons
   
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
    'Get payment received info for current conf.
    If GetFormMode(Me) = "Browse" And Trim(txtConfNum.Text) <> "" Then
       Screen.MousePointer = HOURGLASS
       datPaymentReceived.RecordSource = "select * from paymentreceived where conf = " & CLng(txtConfNum.Text)
       If Not GetDCRows(datPaymentReceived) Then GoTo datBrowse_Reposition_Resume
       CurrRec1 = GetCurrentRowNumber(datPaymentReceived)
       datdwData1.Caption = "[Payments Received] Row " & CurrRec1 & " of " & datPaymentReceived.Recordset.RecordCount
       'Get Calculated total due and display on form
       GetCalcTotalDue
       'Set the refund buttons.
       SetRefundButtons
       If Not VerifyTotalDue Then GoTo datBrowse_Reposition_Resume
       'SetToCurrencyFormat Me
    End If

datBrowse_Reposition_Resume:
  Screen.MousePointer = DEFAULT
  Exit Sub
  
datBrowse_Reposition_Error:
  Resume datBrowse_Reposition_Resume
  
End Sub

Private Sub datdwComboPaymentAppliedTo_Change()
  
  If Trim(datdwComboPaymentAppliedTo.Text) = "" Then Exit Sub
  Dim SSTemp As Recordset

  Set SSTemp = gBNB.OpenRecordset("select AppliedTo from PaymentAppliedTo Where AppliedTo Like '" & datdwComboPaymentAppliedTo.Text & "*'", dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount > 0 Then datdwComboPaymentAppliedTo.Text = SSTemp(0)
  SSTemp.Close
  
End Sub

Private Sub datdwComboPaymentAppliedTo_CloseUp()

   cmdFind.DEFAULT = True
   
End Sub


Private Sub datdwComboPaymentAppliedTo_DropDown()

   On Error GoTo DropDown_Error
   
   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        datdwComboPaymentAppliedTo.DataFieldList = ""
        Exit Sub
     Case Else
        datdwComboPaymentAppliedTo.DefColWidth = datdwComboPaymentAppliedTo.Width * 1.5
        datdwComboPaymentAppliedTo.DataFieldList = "appliedto"
   End Select
   datPaymentAppliedTo.RecordSource = "select * from paymentappliedto Where Trim(AppliedTo) <> ''"
   If Not GetDCRows(datPaymentAppliedTo) Then Exit Sub
   cmdFind.DEFAULT = False

DropDown_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

DropDown_Error:
   Resume DropDown_Resume
   
End Sub

Private Sub datdwComboPaymentAppliedTo_KeyPress(KeyAscii As Integer)
   
   If UCase(GetFormMode(Me)) = "FIND" Or UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then

   Else
      KeyAscii = False
   End If

End Sub

Private Sub datdwData1_Click(ByVal nPosition As Integer)
    'On Error GoTo datdwData1_Click_Error
    
    Screen.MousePointer = HOURGLASS
    Me.SetFocus
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
        SaveRec1 = CurrRec
    'case5: goto saved bookmark
    ElseIf nPosition = 18 Then
        If SaveRec1 > 0 Then CurrRec1 = SaveRec1
    'case6: next row button
    ElseIf nPosition = 8 Then
        If CurrRec1 < Me.datPaymentReceived.Recordset.RecordCount Then
            CurrRec1 = CurrRec1 + 1
        Else
            CurrRec1 = Me.datPaymentReceived.Recordset.RecordCount
        End If
    'case7: next page button
    ElseIf nPosition = 6 Then
        If CurrRec1 < Me.datPaymentReceived.Recordset.RecordCount - datdwData1.PageValue Then
            CurrRec1 = CurrRec1 + datdwData1.PageValue
        Else
            CurrRec1 = Me.datPaymentReceived.Recordset.RecordCount
        End If
    'case8: last row button
    ElseIf nPosition = 4 Then
        CurrRec1 = Me.datPaymentReceived.Recordset.RecordCount
    End If
    datdwData1.Caption = "[Payments Received] Row " & CurrRec1 & " of " & datPaymentReceived.Recordset.RecordCount

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


Private Sub datdwData2_Click(ByVal nPosition As Integer)
    
    On Error GoTo datdwData2_Click_Error
    
    Screen.MousePointer = HOURGLASS
    Me.SetFocus
    'case1: first row button
    If nPosition = 3 Then
        CurrRec2 = 1
    'case2: previous page button
    ElseIf nPosition = 5 Then
        If CurrRec2 > datdwData2.PageValue Then
            CurrRec2 = CurrRec2 - datdwData2.PageValue
        Else
            CurrRec2 = 1
        End If
    'case3: previous row button
    ElseIf nPosition = 7 Then
        If CurrRec2 > 1 Then
            CurrRec2 = CurrRec2 - 1
        Else
            CurrRec2 = 1
        End If
    'case4: save bookmark button
    ElseIf nPosition = 16 Then
        SaveRec2 = CurrRec
    'case5: goto saved bookmark
    ElseIf nPosition = 18 Then
        If SaveRec2 > 0 Then CurrRec2 = SaveRec2
    'case6: next row button
    ElseIf nPosition = 8 Then
        If CurrRec2 < Me.datBrowse.Recordset.RecordCount Then
            CurrRec2 = CurrRec2 + 1
        Else
            CurrRec2 = Me.datBrowse.Recordset.RecordCount
        End If
    'case7: next page button
    ElseIf nPosition = 6 Then
        If CurrRec2 < Me.datBrowse.Recordset.RecordCount - datdwData2.PageValue Then
            CurrRec2 = CurrRec2 + datdwData2.PageValue
        Else
            CurrRec2 = Me.datBrowse.Recordset.RecordCount
        End If
    'case8: last row button
    ElseIf nPosition = 4 Then
        CurrRec2 = Me.datBrowse.Recordset.RecordCount
    End If
    datdwData2.Caption = "[Payments Due] Row " & CurrRec2 & " of " & datBrowse.Recordset.RecordCount

datdwData2_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

datdwData2_Click_Error:
    Resume datdwData2_Click_Resume

End Sub

Private Sub datPaymentReceived_Reposition()
   'SetToCurrencyFormat Me
End Sub

Private Sub Form_Activate()

On Error GoTo Form_Activate_Error

'Following DoEvent is necessary. When a Refund by CC is deleted, a warning
'dialog is issued, casing frmPayment to lose focus. Upon exit from frmRefundByCC,
'focus is set randomly to other background forms. This form needs to paint fully
'otherwise endless loop of activation between all forms occurs.
For i = 1 To 10
   DoEvents
Next i
'If this form is in the background (does not have focus) and the
'Minimize button is clicked on this form that does not yet have the focus,
'an endless loop of Minimizing and Activating will occur. The following
'line prevents this interesting problem.
If Me.WindowState = MINIMIZED Then Exit Sub
'If form is only regaining focus then exit
If UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then Exit Sub
'MsgBox "gConf=" & Str$(gConfNum) & ", gPrior=" & Str$(gPriorConfNum) & ", gRowChangeFormName=" & gRowChangeFormName
If TimesActivated < 1 Or (gConfNum <> gPriorConfNum And gRowChangeFormName <> Me.Name) _
   Or ((Trim$(txtConfNum.Text) <> Trim$(gConfNum)) And (Trim$(txtConfNum.Text) <> "")) _
   Or gConfNum <> 0 And Trim(txtConfNum.Text) = "" Then
   Screen.MousePointer = HOURGLASS
   TimesActivated = TimesActivated + 1
  ' InsertingFromNoRowsMode = False
  ' InsertingFromBrowseMode = False
   If Not GetDCRows(datPaymentAppliedTo) Then GoTo Form_Activate_Resume
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
   datPaymentReceived.RecordSource = "select * from paymentreceived where conf = " & gConfNum
   If Not GetDCRows(datBrowse) Then GoTo Form_Activate_Resume
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
      lblCalcAmtDue.Caption = ""
      lblTotalCredit.Caption = ""
   Else
      SetFormToBrowseMode Me
      If Not GetDCRows(datPaymentReceived) Then GoTo Form_Activate_Resume
      CurrRec2 = GetCurrentRowNumber(datBrowse)
      datdwData2.Caption = "[Payments Due] Row " & CurrRec2 & " of " & datBrowse.Recordset.RecordCount
      CurrRec1 = GetCurrentRowNumber(datPaymentReceived)
      datdwData1.Caption = "[Payments Received] Row " & CurrRec1 & " of " & datPaymentReceived.Recordset.RecordCount
   End If
   SetRefundButtons
End If
'User may have updated Guest Info (resfee) or BBTBL (canceled a reservation,
'changed amounts, etc) so we always need to get calculated total due and display on form
If GetFormMode(Me) = "Browse" Then GetCalcTotalDue

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

   On Error GoTo Load_Error
   
   TimesActivated = 0
   If Not OtherGuestFormsInBrowseMode Then gConfNum = 0
   datBrowse.DatabaseName = gDatabaseName
   datPaymentReceived.DatabaseName = gDatabaseName
   datPaymentAppliedTo.DatabaseName = gDatabaseName
   datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
   datPaymentReceived.RecordSource = "select * from paymentreceived where conf = " & gConfNum
   If Not GetDCRows(datBrowse) Then GoTo Load_Resume
   datPaymentAppliedTo.RecordSource = "select * from paymentappliedto"
   If Not GetDCRows(datPaymentAppliedTo) Then GoTo Load_Resume
   'For datdwData1 (datPaymentReceived)
   CurrRec1 = 1
   SaveRec1 = 0
   'For datdwData2 (datBrowse)
   CurrRec2 = 1
   SaveRec2 = 0

Load_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

Load_Error:
   Resume Load_Resume

End Sub

Private Sub Form_Paint()

   If UCase(GetFormMode(Me)) = "BROWSE" Then
      GetCalcTotalDue 'in case returning from refund check print.
   End If
   
End Sub

Private Sub Form_Unload(Cancel As Integer)
  If FormLoaded(frmRefundByCC) Then
     If UCase(GetFormMode(frmRefundByCC)) = "INSERT" Or UCase(GetFormMode(frmRefundByCC)) = "UPDATE" Then
        gMsg = "Cancel pending Insert or Update of Refunds before exiting."
        MsgBox gMsg, MB_ICONSTOP, Me.Caption
        Cancel = True
        If frmRefundByCC.WindowState = MINIMIZED Then
           Dim X&
           frmRefundByCC.SetFocus
           X& = ShowWindow(frmRefundByCC.hwnd, SW_SHOWNORMAL)
        Else
           frmRefundByCC.Show
           frmRefundByCC.SetFocus
        End If
     Else
        Unload frmRefundByCC
     End If
  End If
  DoEvents
  
End Sub


Private Sub optRefByCC_Click()

  ' If UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then
  '    txtRefundOwed.Text = ""
  ' End If
   txtRefundOwed.Enabled = False
   cmdRefunds.Enabled = True
   lblRefundAmtDue.Enabled = False

End Sub


Private Sub optRefByCheck_Click()

   txtRefundOwed.Enabled = True
   cmdRefunds.Enabled = False
   lblRefundAmtDue.Enabled = True
   
End Sub

Private Sub txtConfNum_Change()

    On Error GoTo txtConfNum_Change_Error
    
    If Not IsNumeric(txtConfNum.Text) Then GoTo txtConfNum_Change_Resume
    
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

txtConfNum_Change_Resume:
  Screen.MousePointer = DEFAULT
  Exit Sub
  
txtConfNum_Change_Error:
   'MsgBox Err.Description
   Resume txtConfNum_Change_Resume

End Sub


Private Sub txtConfNum_LostFocus()
     
  'Fillin name info if conf not blank
  If Not IsNumeric(txtConfNum.Text) Or Trim(txtConfNum.Text) = "" Then Exit Sub
    
  Dim SSTemp As Recordset
  
  Set SSTemp = gBNB.OpenRecordset("select f_name,l_name from guesttbl where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount > 0 Then
    If Not IsNull(SSTemp("f_name")) Then txtFirstName.Text = SSTemp("f_name")
    If Not IsNull(SSTemp("l_name")) Then
       txtLastName.Text = SSTemp("l_name")
    End If
  End If
  SSTemp.Close
  'Get Calculated total due and display on form
  GetCalcTotalDue
  
End Sub





Public Function VerifyUpdate() As Integer
   
   Dim i As Integer
   VerifyUpdate = True
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
   DoEvents
End Function


Public Function NoReceivedFieldsEntered() As Integer
      
   NoReceivedFieldsEntered = False
   If Trim$(txtPaymentAmtRcvd.Text) = "" _
      And Trim$(txtPaymentRcvdDate.Text) = "" _
      And Trim$(txtPaymentCheckNum.Text) = "" _
      And Trim$(datdwComboPaymentAppliedTo.Text) = "" _
      And Trim$(txtRecFrom.Text) = "" _
      And Trim$(txtReceivedComments.Text) = "" Then NoReceivedFieldsEntered = True
      
End Function


Public Function InsertTrigger() As Integer

  On Error GoTo InsertTrigger_Error
  
  Dim SSTemp As Recordset
  Dim i, j As Integer
  InsertTrigger = True
  SetFocusTo = ""
  txtConfNum.Text = Trim(txtConfNum.Text)
  'Check for confirmation number equal to zero
  If txtConfNum.Text = "0" Or txtConfNum.Text = "" Then
     gMsg = "Confirmation number cannot be zero or blank."
     txtConfNum.SetFocus
     InsertTrigger = False
     GoTo InsertTrigger_Resume
  End If
  txtConfNum.Text = Trim$(txtConfNum.Text)
  'New Payment record is being inserted, rather than adding a
  'received payment to existing payment history.
  If InsertingFromNoRowsMode Then
    ' If Not IsNumeric(txtConfNum.Text) Or txtConfNum.Text = "" Or GetFormMode(Me) <> "Insert" Then Exit Function
     'Check if row already exists in Payment table for this Conf Number.
     Set SSTemp = gBNB.OpenRecordset("select conf from payment where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount > 0 Then
        gMsg = "A Payment Due row already exists for this confirmation number."
        txtConfNum.SetFocus
        InsertTrigger = False
        SSTemp.Close
        GoTo InsertTrigger_Resume
     End If
     SSTemp.Close
  End If
  'Conf number must exist in guesttbl
  Set SSTemp = gBNB.OpenRecordset("select conf from guesttbl where conf = " & txtConfNum.Text, dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Confirmation number must exist in General Guest Information before payment information can be entered."
     txtConfNum.SetFocus
     InsertTrigger = False
     SSTemp.Close
     GoTo InsertTrigger_Resume
  End If
  SSTemp.Close
  'If Amount Received is filled in then Date Received and Applied To
  'must also be filled in, and vice versa (all 3 ways).
  '#1
  txtPaymentAmtRcvd.Text = Trim(txtPaymentAmtRcvd.Text)
  txtPaymentRcvdDate.Text = Trim(txtPaymentRcvdDate.Text)
  txtReceivedComments.Text = Trim(txtReceivedComments.Text)
  txtPaymentCheckNum.Text = Trim(txtPaymentCheckNum.Text)
  txtRecFrom.Text = Trim(txtRecFrom.Text)
  datdwComboPaymentAppliedTo.Text = Trim(datdwComboPaymentAppliedTo.Text)
  If txtPaymentAmtRcvd.Text <> "" Then
     'Amount Received cannot be zero or negative.
     If CDbl(txtPaymentAmtRcvd.Text) < 0 Then
        gMsg = "Payment Amount cannot be negative. To enter guest refunds, " & _
               "go to the 'Refund Due to Guest' section and enter the refund amount " & _
               "according to the method of disbursement (by Check or by Credit Card/Other)."
        txtPaymentAmtRcvd.SetFocus
        InsertTrigger = False
        GoTo InsertTrigger_Resume
     ElseIf CDbl(txtPaymentAmtRcvd.Text) = 0 Then
        gMsg = "Payment Amount cannot equal zero."
        txtPaymentAmtRcvd.SetFocus
        InsertTrigger = False
        GoTo InsertTrigger_Resume
     End If
     If txtPaymentRcvdDate.Text = "" Then
        gMsg = "Date Received must be filled in."
        txtPaymentRcvdDate.SetFocus
        InsertTrigger = False
     ElseIf datdwComboPaymentAppliedTo.Text = "" Then
        gMsg = "Payment Applied To must be filled in."
        datdwComboPaymentAppliedTo.SetFocus
        InsertTrigger = False
     ElseIf txtPaymentCheckNum.Text = "" Then
        gMsg = "Check Number/Credit Card description (eg, VS, MC, AMEX, etc.) must be entered to identify guest payment."
        txtPaymentCheckNum.SetFocus
        InsertTrigger = False
     End If
  ElseIf txtPaymentRcvdDate.Text <> "" Then
     If txtPaymentAmtRcvd.Text = "" Then
        gMsg = "Payment Amount must be filled in."
        txtPaymentAmtRcvd.SetFocus
        InsertTrigger = False
     ElseIf datdwComboPaymentAppliedTo.Text = "" Then
        gMsg = "Payment Applied To must be filled in."
        datdwComboPaymentAppliedTo.SetFocus
        InsertTrigger = False
     End If
  ElseIf datdwComboPaymentAppliedTo.Text <> "" Then
     If txtPaymentAmtRcvd.Text = "" Then
        gMsg = "Payment Amount must be filled in."
        txtPaymentAmtRcvd.SetFocus
        InsertTrigger = False
     ElseIf txtPaymentRcvdDate.Text = "" Then
        gMsg = "Date Received must be filled in."
        txtPaymentRcvdDate.SetFocus
        InsertTrigger = False
     End If
  End If
  If Trim(txtPaymentAmtRcvd.Text) = "" And _
     (txtReceivedComments.Text <> "" Or _
      txtPaymentCheckNum.Text <> "" Or _
      txtRecFrom.Text <> "" Or _
      txtPaymentCheckNum.Text <> "") Then
      gMsg = "Payment Amount must be filled in."
      txtPaymentAmtRcvd.SetFocus
      InsertTrigger = False
  End If
  'Validate 'Applied To' value
  If datdwComboPaymentAppliedTo.Text <> "" Then
     Set SSTemp = gBNB.OpenRecordset("select AppliedTo from paymentappliedto", dbOpenSnapshot)
     GetSSRows SSTemp
     j = 0
     For i = 0 To SSTemp.RecordCount - 1
       'MsgBox SSTemp("AppliedTo")
       If UCase(SSTemp("AppliedTo")) = UCase(datdwComboPaymentAppliedTo.Text) Then
          j = 1
          Exit For
       End If
       SSTemp.MoveNext
     Next i
     If j = 0 Then
        gMsg = "Invalid 'Applied To' value. Please select from the dropdown list."
        datdwComboPaymentAppliedTo.SetFocus
        InsertTrigger = False
        SSTemp.Close
        GoTo InsertTrigger_Resume
     End If
     SSTemp.Close
  End If
  'Validate Deferred Commission. Commission amount in Guest Travel
  'Agency must be non-null AND greater than or equal to Deferred Commission
  'entered here.
  If Trim(txtDeferredComm.Text) <> "" Then
   If CCur(Trim(txtDeferredComm.Text)) > 0 Then
     Set SSTemp = gBNB.OpenRecordset("select commdue from tagentbl where conf = " & txtConfNum.Text, dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount = 0 Then
        'No travel agency exists for this confirmation, so cannot enter def com.
     '   If Trim(txtCommDue.Text) <> "" Then
           gMsg = "Cannot defer travel agency commission. A travel agency is not " & _
                  "associated with this confirmation."
           txtDeferredComm.SetFocus
           InsertTrigger = False
           SSTemp.Close
           GoTo InsertTrigger_Resume
     '   End If
     Else
        If IsNull(SSTemp(0)) Or SSTemp(0) = 0 Then
           gMsg = "Cannot defer travel agency commission. A Commission Due amount " & _
                  "has not been entered in this guest's travel agency screen."
           txtDeferredComm.SetFocus
           InsertTrigger = False
           SSTemp.Close
           GoTo InsertTrigger_Resume
        ElseIf CCur(txtDeferredComm.Text) > SSTemp(0) Then
           gMsg = "Deferred amount cannot be greater than the Commission " & _
                  "Due amount (" & Str(SSTemp(0)) & ") set in the guest's travel " & _
                  "agency screen."
           txtDeferredComm.SetFocus
           InsertTrigger = False
           SSTemp.Close
           GoTo InsertTrigger_Resume
        End If
     End If
     SSTemp.Close
   End If
  End If
  
InsertTrigger_Resume:
   Exit Function
   
InsertTrigger_Error:
   Resume InsertTrigger_Resume
  
End Function



Public Function BuildPayFindCriteria() As String

   Dim TempStr As String
   Dim LenTempStr
   Dim Counter As Integer
   Counter = 0
   TempStr = ""
   LenTempStr = Len(TempStr)
   For i = 0 To Me.Controls.Count - 1
      If Me.Controls(i).Name <> "txtPaymentAmtRcvd" _
      And Me.Controls(i).Name <> "txtPaymentRcvdDate" _
      And Me.Controls(i).Name <> "txtPaymentCheckNum" _
      And Me.Controls(i).Name <> "txtRecFrom" _
      And Me.Controls(i).Name <> "datdwComboPaymentAppliedTo" _
      And Me.Controls(i).Name <> "txtReceivedComments" Then
         'Make query for Payment Due section
         If TempStr = "" Then TempStr = "select * from " & Me.Tag & " where "
         If Me.Controls(i).Name Like "txt*" Or Me.Controls(i).Name Like "datdwCombo*" Then
           If Trim$(Me.Controls(i).Text) <> "" Then
              If Counter > 0 Then TempStr = TempStr & " and "
              Counter = Counter + 1
              If Me.Controls(i).Tag = "Number" Or Me.Controls(i).Tag = "Currency" Then
                 If Not IsNumeric(Me.Controls(i).Text) Then
                   gMsg = "'" & Me.Controls(i).Text & "' was entered into a number field. Only numbers can be entered into these fields."
                   GoTo BuildPayFindCriteria_Invalid_Characters
                 Else
                   TempStr = TempStr & Me.Controls(i).DataField & " = " & Me.Controls(i).Text
                 End If
              Else
                If Me.Controls(i).Text Like "*[']*" Then 'Single quote symbol needs to be removed.
                   Me.Controls(i).Text = Replace_All_In_With("'", Me.Controls(i).Text, "*")
                End If
                If Me.Controls(i).Tag = "Date" Then
                   'Ensure valid date format
                   If Not DateFormatOk(Me.Controls(i)) Then
                      gMsg = "Invalid date. Use mm/dd/yy format."
                      GoTo BuildPayFindCriteria_Invalid_Characters
                   Else
                      'MS Access requires pound signs (#) around date values (literals) in select queries.
                      TempStr = TempStr & Me.Controls(i).DataField & " = #" & Trim$(Me.Controls(i).Text) & "#"
                   End If
                Else
                   If Me.Controls(i).Text Like "*[*]*" Then
                      TempStr = TempStr & Me.Controls(i).DataField & " Like '" & Me.Controls(i).Text & "'"
                   Else
                      TempStr = TempStr & Me.Controls(i).DataField & " = '" & Me.Controls(i).Text & "'"
                   End If
                End If
              End If
           End If
         End If
      Else  'Querying on Payments Received section
        ''
      End If
   Next i
   If LenTempStr < Len(TempStr) Then
      If OrderBy <> "" Then
         BuildPayFindCriteria = TempStr & " order by " & OrderBy
      Else
         BuildPayFindCriteria = TempStr
      End If
   Else
      BuildPayFindCriteria = ""
   End If
Exit Function

BuildPayFindCriteria_Invalid_Characters:
  MsgBox gMsg, MB_ICONSTOP, Me.Caption
  Screen.MousePointer = DEFAULT
  BuildPayFindCriteria = ""
End Function


Public Sub GetCalcTotalDue()
    
    On Error GoTo GetCalcTotalDue_Error
    
    Dim SSTemp As Recordset
    Dim vTotalRefunded As Currency
    
    'Get calculated total due for current conf.
    gSQL = "select sum(gwtax) from bbtbl where conf = " & CLng(txtConfNum.Text) & _
           " And (suppress<>-1 Or (suppress=-1 And forfeit=-1))"
    Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
    GetSSRows SSTemp
    If Not IsNull(SSTemp(0)) Then
       TempTotal = SSTemp(0)
    Else
       TempTotal = 0
    End If
    SSTemp.Close
    Set SSTemp = gBNB.OpenRecordset("select resfee from guesttbl where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
    GetSSRows SSTemp
    If Not IsNull(SSTemp(0)) Then TempTotal = TempTotal + SSTemp(0)
    SSTemp.Close
    lblCalcAmtDue.Caption = Format(Str(TempTotal), CURRENCYFORMAT)
    'Get calculated total credit for current conf.
    Set SSTemp = gBNB.OpenRecordset("select sum(AmountReceived) from paymentreceived where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
    GetSSRows SSTemp
    If Not IsNull(SSTemp(0)) Then
       TempTotal = SSTemp(0)
    Else
       TempTotal = 0
    End If
    SSTemp.Close
    'Add 'Deferred Commission' and 'Other Guest Credits' fields to total guest credit.
    Set SSTemp = gBNB.OpenRecordset("select defcom,OtherCredit from payment where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
    GetSSRows SSTemp
    If Not SSTemp.EOF And Not SSTemp.BOF Then
       If Not IsNull(SSTemp(0)) Then TempTotal = TempTotal + SSTemp(0)
       If Not IsNull(SSTemp(1)) Then TempTotal = TempTotal + SSTemp(1)
    End If
    SSTemp.Close
    'Reduce total credit by total refund amount.
    'Initialize total refunded variable.
    vTotalRefunded = 0
    'Get total refunded by check.
    Set SSTemp = gBNB.OpenRecordset("select sum(trueamt) from CheckTbl where conf = " & CLng(txtConfNum.Text) & " and Void_Chk <> -1 and CheckCategory = 'Host' and SubCategory = 'Guest Refund'", dbOpenSnapshot)
    GetSSRows SSTemp
    If Not IsNull(SSTemp(0)) Then vTotalRefunded = vTotalRefunded + SSTemp(0)
    SSTemp.Close
    'Get total refunded by credit card or cash and add it to amount refunded by check.
    Set SSTemp = gBNB.OpenRecordset("select sum(AmtPaid) from RefundByCCTbl where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
    GetSSRows SSTemp
    If Not IsNull(SSTemp(0)) Then vTotalRefunded = vTotalRefunded + SSTemp(0)
    SSTemp.Close
    TempTotal = TempTotal - vTotalRefunded
    lblTotalCredit.Caption = Format(Str(TempTotal), CURRENCYFORMAT)

GetCalcTotalDue_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
GetCalcTotalDue_Error:
   Resume GetCalcTotalDue_Resume
   
End Sub


Public Function VerifyTotalDue() As Integer

    VerifyTotalDue = True
    Dim vTot As Currency
    vTot = 0
    If txtDepositAmtDue.Text <> "" Then vTot = CCur(txtDepositAmtDue.Text)
    If txtPrepayAmtDue.Text <> "" Then vTot = vTot + CCur(txtPrepayAmtDue.Text)
    If Format(Str(vTot), CURRENCYFORMAT) <> lblCalcAmtDue.Caption Then
       VerifyTotalDue = False
       lblCalcAmtDue.ForeColor = RED
    Else
       lblCalcAmtDue.ForeColor = BLACK
    End If
    'MsgBox Format(Str(vTot), CURRENCYFORMAT) & ", " & lblCalcAmtDue.Caption
    gMsg = "Sum of Deposit and Prepayment Due does not match calculated Total Due."
    
End Function

Public Sub PaymentsReceivedMode(TheMode As String)

   If TheMode = "Disabled" Then
      fraPaymentReceived.Enabled = False
      txtPaymentAmtRcvd.Enabled = False
      txtPaymentRcvdDate.Enabled = False
      txtPaymentCheckNum.Enabled = False
      datdwComboPaymentAppliedTo.Enabled = False
      txtReceivedComments.Enabled = False
   Else
      fraPaymentReceived.Enabled = True
      txtPaymentAmtRcvd.Enabled = True
      txtPaymentRcvdDate.Enabled = True
      txtPaymentCheckNum.Enabled = True
      datdwComboPaymentAppliedTo.Enabled = True
      txtReceivedComments.Enabled = True
   End If
   
End Sub

Private Sub txtPaymentAmtRcvd_LostFocus()
  
  If GetFormMode(Me) = "Insert" Then
     If Trim(txtRecFrom.Text) = "" Then
        If Trim(txtPaymentAmtRcvd.Text) <> "" Then
           If Trim(txtLastName.Text) <> "" And GetFormMode(Me) = "Insert" Then txtRecFrom.Text = Trim(txtLastName.Text)
        End If
     End If
  End If
  
End Sub



Public Sub SetRefundButtons()

   On Error GoTo SetRefundButtons_Error
   
   Dim SSTemp As Recordset
   Dim vByCCExists, vByCheckExists As Integer
   
   vByCCExists = False
   vByCheckExists = False
   optRefByCheck.Enabled = True
   optRefByCC.Enabled = True
   
  'See if a Credit card/cash refund exists.
  If Trim(txtConfNum.Text) <> "" Then
     Set SSTemp = gBNB.OpenRecordset("select conf from RefundByCCTbl where conf = " & txtConfNum.Text, dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount > 0 Then vByCCExists = True
     SSTemp.Close
  End If
  'See if a refund is to be printed by check.
  If Trim(txtRefundOwed.Text) <> "" Then vByCheckExists = True
  'Set the buttons - A credit card refund will have precidence over a check refund
  'simply because the check-type refund can be seen on the Payment screen.
  If vByCCExists And vByCheckExists Then
     optRefByCC.Value = CHECKED
     cmdRefunds.Enabled = True
  ElseIf vByCCExists And Not vByCheckExists Then
     optRefByCC.Value = CHECKED
     cmdRefunds.Enabled = True
  ElseIf Not vByCCExists And vByCheckExists Then
     optRefByCheck.Value = CHECKED
     cmdRefunds.Enabled = False
  ElseIf Not vByCCExists And Not vByCheckExists Then
     optRefByCheck.Value = CHECKED
     cmdRefunds.Enabled = False
  End If

SetRefundButtons_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
SetRefundButtons_Error:
MsgBox Err.Description
   Resume SetRefundButtons_Resume
    
End Sub

