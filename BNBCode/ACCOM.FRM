VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmAccommodations 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Guest Accommodations"
   ClientHeight    =   6015
   ClientLeft      =   495
   ClientTop       =   1020
   ClientWidth     =   9375
   HelpContextID   =   101
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   6015
   ScaleWidth      =   9375
   Tag             =   "bbtbl"
   Begin SSDataWidgets_B.SSDBCombo datdwComboRoomType 
      Bindings        =   "ACCOM.frx":0000
      DataField       =   "UnitName"
      DataSource      =   "datBrowse"
      Height          =   312
      Left            =   1440
      TabIndex        =   5
      Tag             =   "Text"
      Top             =   1536
      Width           =   720
      ListAutoValidate=   0   'False
      MaxDropDownItems=   10
      AutoRestore     =   0   'False
      _Version        =   131078
      Columns(0).Width=   3200
      _ExtentX        =   1270
      _ExtentY        =   550
      _StockProps     =   93
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
   End
   Begin VB.Data datRoomType 
      Appearance      =   0  'Flat
      Caption         =   "datRoomType"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   120
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   6480
      Visible         =   0   'False
      Width           =   1875
   End
   Begin VB.TextBox txtRevisionDate 
      Appearance      =   0  'Flat
      DataField       =   "rev_date"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      TabIndex        =   13
      Tag             =   "Date"
      Top             =   4470
      Width           =   2415
   End
   Begin VB.TextBox txtNumNites 
      Appearance      =   0  'Flat
      DataField       =   "NumNites"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      TabIndex        =   12
      Tag             =   "Number"
      Top             =   4110
      Width           =   1455
   End
   Begin VB.TextBox txtUpdateDate 
      Appearance      =   0  'Flat
      DataField       =   "UpdateDate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   3300
      TabIndex        =   77
      TabStop         =   0   'False
      Tag             =   "Date"
      Top             =   4680
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.TextBox txtUpdateUser 
      Appearance      =   0  'Flat
      DataField       =   "UpdateUser"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   3000
      TabIndex        =   76
      TabStop         =   0   'False
      Tag             =   "Text"
      Top             =   4680
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.TextBox txtEntryDate 
      Appearance      =   0  'Flat
      DataField       =   "EntryDate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   3300
      TabIndex        =   75
      TabStop         =   0   'False
      Tag             =   "Date"
      Top             =   4080
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.TextBox txtEntryUser 
      Appearance      =   0  'Flat
      DataField       =   "EntryUser"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   3000
      TabIndex        =   74
      TabStop         =   0   'False
      Tag             =   "Text"
      Top             =   4080
      Visible         =   0   'False
      Width           =   255
   End
   Begin VB.TextBox txtDepDate 
      Appearance      =   0  'Flat
      DataField       =   "depdate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   25
      TabIndex        =   8
      Tag             =   "Date"
      Top             =   2640
      Width           =   1455
   End
   Begin VB.TextBox txtArrDate 
      Appearance      =   0  'Flat
      DataField       =   "arrdate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   25
      TabIndex        =   7
      Tag             =   "Date"
      Top             =   2280
      Width           =   1455
   End
   Begin VB.TextBox txtBlindComment 
      Appearance      =   0  'Flat
      DataField       =   "cmmnts"
      DataSource      =   "datBrowse"
      Height          =   615
      Left            =   120
      MaxLength       =   255
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   14
      Tag             =   "Text"
      Top             =   5010
      Width           =   3735
   End
   Begin VB.Data datTaxList 
      Caption         =   "datTaxList"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   345
      Left            =   6600
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   6120
      Visible         =   0   'False
      Width           =   2055
   End
   Begin VB.Data datTypeList 
      Caption         =   "datTypeList"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   345
      Left            =   4320
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   6120
      Visible         =   0   'False
      Width           =   2295
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
      Height          =   600
      Left            =   8040
      TabIndex        =   40
      Top             =   5400
      Width           =   1335
   End
   Begin VB.Frame fraOptions 
      Caption         =   "Options (These apply to current row only)"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2025
      Left            =   3960
      TabIndex        =   62
      Top             =   3600
      Width           =   3975
      Begin Threed.SSCheck chkForfeit 
         DataField       =   "Forfeit"
         DataSource      =   "datBrowse"
         Height          =   252
         Left            =   120
         TabIndex        =   28
         Top             =   780
         Width           =   3732
         _Version        =   65536
         _ExtentX        =   6588
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Cancelled with forfeiture of Calculated Amounts"
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
      Begin Threed.SSCheck chkNotified 
         DataField       =   "Notified"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   120
         TabIndex        =   29
         Top             =   1050
         Width           =   3720
         _Version        =   65536
         _ExtentX        =   6562
         _ExtentY        =   444
         _StockProps     =   78
         Caption         =   "Host Notification report printed"
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
      Begin VB.TextBox txtPercent 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         DataField       =   "percnt"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   2820
         TabIndex        =   31
         Tag             =   "Number"
         Top             =   1680
         Width           =   855
      End
      Begin Threed.SSCheck chkFillCalcAmounts 
         DataField       =   "FillinCalcAmounts"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   120
         TabIndex        =   26
         Top             =   240
         Width           =   3735
         _Version        =   65536
         _ExtentX        =   6588
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Use manually entered Calculated Amounts"
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
      Begin Threed.SSCheck chkSuppress 
         DataField       =   "suppress"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   120
         TabIndex        =   27
         Top             =   510
         Width           =   3735
         _Version        =   65536
         _ExtentX        =   6588
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Cancel this accommodation reservation"
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
      Begin SSDataWidgets_B.SSDBCombo datdwComboTaxPlanCode 
         Bindings        =   "ACCOM.frx":0016
         DataField       =   "tax_plan_code"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   2820
         TabIndex        =   30
         Tag             =   "Text"
         Top             =   1350
         Width           =   1095
         ListAutoValidate=   0   'False
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
         _ExtentX        =   1931
         _ExtentY        =   450
         _StockProps     =   93
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
      End
      Begin VB.Label lblChangePercent 
         Caption         =   "Over-ride preset Percentage to Host:"
         Height          =   255
         Left            =   120
         TabIndex        =   69
         Top             =   1710
         Width           =   2655
      End
      Begin VB.Label lblLabel1 
         Caption         =   "%"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   3660
         TabIndex        =   65
         Top             =   1710
         Width           =   195
      End
      Begin VB.Label lblChangeTaxPlan 
         Caption         =   "Over-ride Host's preset Tax Plan:"
         Height          =   255
         Left            =   120
         TabIndex        =   64
         Top             =   1380
         Width           =   2595
      End
   End
   Begin VB.Frame fraCommDueFromHost 
      Caption         =   "Commission Due from Host"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1335
      Left            =   3960
      TabIndex        =   58
      Top             =   2220
      Width           =   3975
      Begin VB.TextBox txtCommishRecDate 
         Appearance      =   0  'Flat
         DataField       =   "com_rcvd"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1200
         MaxLength       =   25
         TabIndex        =   25
         Tag             =   "Date"
         Top             =   960
         Width           =   1335
      End
      Begin VB.TextBox txtCommishPaid 
         Appearance      =   0  'Flat
         DataField       =   "comm_paid"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1200
         TabIndex        =   24
         Tag             =   "Currency"
         Top             =   600
         Width           =   1335
      End
      Begin VB.TextBox txtCommishDue 
         Appearance      =   0  'Flat
         DataField       =   "commish"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1200
         TabIndex        =   23
         Tag             =   "Currency"
         Top             =   240
         Width           =   1335
      End
      Begin VB.Label lblCommishDatePaid 
         Caption         =   "Date Paid:"
         Height          =   255
         Left            =   120
         TabIndex        =   61
         Top             =   990
         Width           =   975
      End
      Begin VB.Label lblCommishPaid 
         Caption         =   "Amount Paid:"
         Height          =   255
         Left            =   120
         TabIndex        =   60
         Top             =   630
         Width           =   975
      End
      Begin VB.Label lblCommishDue 
         Caption         =   "Amount Due:"
         Height          =   255
         Left            =   120
         TabIndex        =   59
         Top             =   270
         Width           =   975
      End
   End
   Begin VB.Frame fraCalcAmounts 
      Caption         =   "Calculated Amounts"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2115
      Left            =   3960
      TabIndex        =   51
      Top             =   60
      Width           =   3975
      Begin VB.TextBox txtTax3 
         Appearance      =   0  'Flat
         DataField       =   "tax3"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   3000
         TabIndex        =   22
         TabStop         =   0   'False
         Tag             =   "Currency"
         Top             =   1350
         Width           =   855
      End
      Begin VB.TextBox txtTax2 
         Appearance      =   0  'Flat
         DataField       =   "tax2"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   3000
         TabIndex        =   21
         TabStop         =   0   'False
         Tag             =   "Currency"
         Top             =   990
         Width           =   855
      End
      Begin VB.TextBox txtTax1 
         Appearance      =   0  'Flat
         DataField       =   "tax1"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   3000
         TabIndex        =   20
         TabStop         =   0   'False
         Tag             =   "Currency"
         Top             =   630
         Width           =   855
      End
      Begin VB.TextBox txtServiceFee 
         Appearance      =   0  'Flat
         DataField       =   "svcharge"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1320
         TabIndex        =   19
         Tag             =   "Currency"
         Top             =   1680
         Width           =   1035
      End
      Begin VB.TextBox txtTotNetWithTax 
         Appearance      =   0  'Flat
         DataField       =   "nwtax"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1320
         TabIndex        =   18
         Tag             =   "Currency"
         Top             =   1320
         Width           =   1035
      End
      Begin VB.TextBox txtTotGrossWithTax 
         Appearance      =   0  'Flat
         DataField       =   "gwtax"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1320
         TabIndex        =   17
         Tag             =   "Currency"
         Top             =   960
         Width           =   1035
      End
      Begin VB.TextBox txtTotTax 
         Appearance      =   0  'Flat
         DataField       =   "tax"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1320
         TabIndex        =   16
         Tag             =   "Currency"
         Top             =   600
         Width           =   1035
      End
      Begin VB.TextBox txtDailyNetRate 
         Appearance      =   0  'Flat
         DataField       =   "netrate"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1320
         TabIndex        =   15
         Tag             =   "Currency"
         Top             =   240
         Width           =   1035
      End
      Begin VB.Label lblNetTaxAmounts 
         Caption         =   "Tax Breakout:"
         Enabled         =   0   'False
         Height          =   225
         Left            =   2520
         TabIndex        =   73
         Top             =   330
         Width           =   1155
      End
      Begin VB.Label lblTax3 
         Caption         =   "Tax3:"
         Height          =   255
         Left            =   2520
         TabIndex        =   72
         Top             =   1380
         Width           =   495
      End
      Begin VB.Label lblTax2 
         Caption         =   "Tax2:"
         Height          =   255
         Left            =   2520
         TabIndex        =   71
         Top             =   1020
         Width           =   495
      End
      Begin VB.Label lblTax1 
         Caption         =   "Tax1:"
         Height          =   255
         Left            =   2520
         TabIndex        =   70
         Top             =   660
         Width           =   495
      End
      Begin VB.Label lblServiceFee 
         Caption         =   "Service Fee:"
         Height          =   255
         Left            =   120
         TabIndex        =   56
         Top             =   1680
         Width           =   1215
      End
      Begin VB.Label lblTotTax 
         Caption         =   "Gross Tax:"
         Height          =   255
         Left            =   120
         TabIndex        =   55
         Top             =   600
         Width           =   1215
      End
      Begin VB.Label lblTotNetWithTax 
         Caption         =   "Net with Tax:"
         Height          =   255
         Left            =   120
         TabIndex        =   54
         Top             =   1320
         Width           =   1215
      End
      Begin VB.Label lblTotGrossWithTax 
         Caption         =   "Gross with Tax:"
         Height          =   255
         Left            =   120
         TabIndex        =   53
         Top             =   960
         Width           =   1215
      End
      Begin VB.Label lblDailyNetRate 
         Caption         =   "Daily Net Rate:"
         Height          =   255
         Left            =   120
         TabIndex        =   52
         Top             =   270
         Width           =   1215
      End
   End
   Begin VB.TextBox txtNetNotes 
      Appearance      =   0  'Flat
      DataField       =   "nnotes"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   27
      TabIndex        =   11
      Tag             =   "Text"
      Top             =   3750
      Width           =   2415
   End
   Begin VB.TextBox txtNumPersons 
      Appearance      =   0  'Flat
      DataField       =   "numpty"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      TabIndex        =   6
      Tag             =   "Number"
      Top             =   1920
      Width           =   1455
   End
   Begin VB.TextBox txtDailyGrossRate 
      Appearance      =   0  'Flat
      DataField       =   "grosrate"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      TabIndex        =   10
      Tag             =   "Currency"
      Top             =   3390
      Width           =   1455
   End
   Begin VB.Data datPropList 
      Appearance      =   0  'Flat
      Caption         =   "datPropList"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   2040
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   6120
      Visible         =   0   'False
      Width           =   2295
   End
   Begin VB.TextBox txtLastName 
      Appearance      =   0  'Flat
      DataField       =   "l_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   30
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   780
      Width           =   2415
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
      Left            =   8040
      TabIndex        =   39
      Top             =   4740
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
      Left            =   8040
      TabIndex        =   38
      Top             =   4080
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
      Height          =   600
      Left            =   8040
      TabIndex        =   37
      Top             =   3420
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
      Left            =   8040
      TabIndex        =   36
      Top             =   2760
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
      Left            =   8040
      TabIndex        =   34
      Top             =   1440
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
      Left            =   8040
      TabIndex        =   33
      Top             =   780
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
      Left            =   8040
      TabIndex        =   32
      Top             =   120
      Width           =   1335
   End
   Begin VB.TextBox txtFirstName 
      Appearance      =   0  'Flat
      DataField       =   "f_name"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   30
      TabIndex        =   2
      Tag             =   "Text"
      Top             =   420
      Width           =   2415
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
      Left            =   8040
      TabIndex        =   35
      Top             =   2100
      Width           =   1335
   End
   Begin VB.TextBox txtConfNum 
      Appearance      =   0  'Flat
      DataField       =   "conf"
      DataSource      =   "datBrowse"
      Height          =   285
      Left            =   1440
      MaxLength       =   9
      TabIndex        =   1
      Tag             =   "Number"
      Top             =   60
      Width           =   1215
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
      Left            =   0
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   6120
      Visible         =   0   'False
      Width           =   2055
   End
   Begin SSDataWidgets_B.SSDBCombo datdwComboProperty 
      Bindings        =   "ACCOM.frx":002B
      DataField       =   "location"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1440
      TabIndex        =   4
      Tag             =   "Text"
      Top             =   1140
      Width           =   2415
      ListAutoValidate=   0   'False
      MaxDropDownItems=   15
      AutoRestore     =   0   'False
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
      _ExtentX        =   4260
      _ExtentY        =   556
      _StockProps     =   93
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
   End
   Begin SSDataWidgets_B.SSDBCombo datdwComboPaymentType 
      Bindings        =   "ACCOM.frx":0041
      DataField       =   "pymttype"
      DataSource      =   "datBrowse"
      Height          =   315
      Left            =   1440
      TabIndex        =   9
      Tag             =   "Text"
      Top             =   3000
      Width           =   1455
      ListAutoValidate=   0   'False
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
      _ExtentX        =   2566
      _ExtentY        =   556
      _StockProps     =   93
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "ACCOM.frx":0057
      Height          =   330
      Left            =   120
      TabIndex        =   0
      Top             =   5670
      Width           =   7815
      _Version        =   131075
      _ExtentX        =   13785
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
   Begin VB.Label lblRoomTypeDesc 
      DataField       =   "UnitNameDesc"
      DataSource      =   "datBrowse"
      Enabled         =   0   'False
      Height          =   288
      Left            =   2232
      TabIndex        =   78
      Top             =   1620
      Width           =   1704
   End
   Begin VB.Label lblAcctNum 
      Alignment       =   1  'Right Justify
      Caption         =   "lblAcctNum"
      DataField       =   "accountnum"
      DataSource      =   "datBrowse"
      Height          =   255
      Left            =   3000
      TabIndex        =   68
      Top             =   1950
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.Label lblBlindComment 
      Caption         =   "Blind Comment:"
      Height          =   255
      Left            =   120
      TabIndex        =   67
      Top             =   4800
      Width           =   1215
   End
   Begin VB.Label lblUnitName 
      Caption         =   "Room Type ID:"
      Height          =   255
      Left            =   120
      TabIndex        =   66
      Top             =   1560
      Width           =   1215
   End
   Begin VB.Label lblPaymentType 
      Caption         =   "Payment Type:"
      Height          =   255
      Left            =   120
      TabIndex        =   63
      Top             =   3030
      Width           =   1215
   End
   Begin VB.Label lblEntryDate 
      Caption         =   "Last Modified:"
      Height          =   255
      Left            =   120
      TabIndex        =   57
      Top             =   4470
      Width           =   1215
   End
   Begin VB.Label lblNetNotes 
      Caption         =   "Net Notes:"
      Height          =   255
      Left            =   120
      TabIndex        =   50
      Top             =   3750
      Width           =   1215
   End
   Begin VB.Label lblNumPersons 
      Caption         =   "Num Persons:"
      Height          =   255
      Left            =   120
      TabIndex        =   49
      Top             =   1950
      Width           =   1215
   End
   Begin VB.Label lblDailyGrossRate 
      Caption         =   "Daily Gross Rate:"
      Height          =   255
      Left            =   120
      TabIndex        =   48
      Top             =   3390
      Width           =   1275
   End
   Begin VB.Label lblLblNumNights 
      Caption         =   "Num Nights:"
      Height          =   255
      Left            =   120
      TabIndex        =   47
      Top             =   4110
      Width           =   1215
   End
   Begin VB.Label lblDepartureDate 
      Caption         =   "Depart Date:"
      Height          =   255
      Left            =   120
      TabIndex        =   46
      Top             =   2670
      Width           =   1215
   End
   Begin VB.Label lblArrivalDate 
      Caption         =   "Arrival Date:"
      Height          =   255
      Left            =   120
      TabIndex        =   45
      Top             =   2310
      Width           =   1215
   End
   Begin VB.Label lblProperty 
      Caption         =   "Property:"
      Height          =   255
      Left            =   120
      TabIndex        =   44
      Top             =   1170
      Width           =   1215
   End
   Begin VB.Label lblLastName 
      Caption         =   "Last Name:"
      Height          =   255
      Left            =   120
      TabIndex        =   43
      Top             =   810
      Width           =   1215
   End
   Begin VB.Label lblFirstName 
      Caption         =   "First Name:"
      Height          =   255
      Left            =   120
      TabIndex        =   42
      Top             =   420
      Width           =   1215
   End
   Begin VB.Label lblConfNum 
      Caption         =   "Conf Number:"
      Height          =   255
      Left            =   120
      TabIndex        =   41
      Top             =   60
      Width           =   1215
   End
End
Attribute VB_Name = "frmAccommodations"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim CurrRec As Long
Dim i As Integer
Dim TimesActivated As Integer
Dim NullDateArray()
Dim SetFocusTo As String
'Holds original values of fields which determine update of the revision date.
Dim KeyFields(12)
'Used to validate Host property change in Insert/Update trigger
Dim OrigProperty As String
Dim OrigAcctNum As String
Dim OrigArrDate As Date
Dim OrigDepDate As Date
Dim CancelClicked As Integer
Private Sub chkFillCalcAmounts_Click(Value As Integer)
  
  If chkFillCalcAmounts.Value = CHECKED Then
     lblDailyNetRate.Enabled = True
     lblTotTax.Enabled = True
     lblTotGrossWithTax.Enabled = True
     lblTotNetWithTax.Enabled = True
     lblServiceFee.Enabled = True
     txtDailyNetRate.Enabled = True
     txtTotTax.Enabled = True
     txtTotGrossWithTax.Enabled = True
     txtTotNetWithTax.Enabled = True
     txtServiceFee.Enabled = True
     txtTax1.Enabled = True
     txtTax2.Enabled = True
     txtTax3.Enabled = True
    ' txtTax1.Locked = True
    ' txtTax2.Locked = True
    ' txtTax3.Locked = True
     lblTax1.Enabled = True
     lblTax2.Enabled = True
     lblTax3.Enabled = True
     lblNetTaxAmounts.Enabled = True
  Else
     lblDailyNetRate.Enabled = False
     lblTotTax.Enabled = False
     lblTotGrossWithTax.Enabled = False
     lblTotNetWithTax.Enabled = False
     lblServiceFee.Enabled = False
     txtDailyNetRate.Enabled = False
     txtTotTax.Enabled = False
     txtTotGrossWithTax.Enabled = False
     txtTotNetWithTax.Enabled = False
     txtServiceFee.Enabled = False
     txtTax1.Enabled = False
     txtTax2.Enabled = False
     txtTax3.Enabled = False
    ' txtTax1.Locked = True
    ' txtTax2.Locked = True
    ' txtTax3.Locked = True
     lblTax1.Enabled = False
     lblTax2.Enabled = False
     lblTax3.Enabled = False
     lblNetTaxAmounts.Enabled = False
  End If
   
End Sub


Private Sub chkForfeit_Click(Value As Integer)

'If Value = CHECKED Then
'  If (GetFormMode(Me) = "Insert" Or GetFormMode(Me) = "Update") And chkSuppress.Value = CHECKED And Not CancelClicked Then
'    gMsg = "Cannot mark this accommodation reservation as both a forfeiture and a cancellation."
'    MsgBox gMsg, MB_ICONSTOP, Me.Caption
'    chkForfeit.Value = UNCHECKED
'    Exit Sub
'  End If
'End If

End Sub

Private Sub chkSuppress_Click(Value As Integer)

  If GetFormMode(Me) <> "Insert" And GetFormMode(Me) <> "Update" Then Exit Sub
  If Value = CHECKED Then
     chkForfeit.Enabled = True
  Else
     chkForfeit.Enabled = False
     chkForfeit.Value = False
  End If
  
End Sub

Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error
   
   CancelClicked = True

   Select Case GetFormMode(Me)
     Case "Insert", "Update"
        If datBrowse.Recordset.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
        If datBrowse.Recordset.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
        txtNumNites.Locked = True
        txtNumNites.ForeColor = BLACK
        txtRevisionDate.Locked = True
        txtRevisionDate.ForeColor = BLACK
     Case "Find"
        cmdFind.Caption = "&Find"
        txtTax1.ForeColor = BLACK
        txtTax2.ForeColor = BLACK
        txtTax3.ForeColor = BLACK
        Call chkFillCalcAmounts_Click(False)
     Case Else
        'Do nothing
   End Select
   datBrowse.UpdateControls
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
     SetFormToNoRowsMode Me
     cmdInsert.SetFocus
   Else
     SetFormToBrowseMode Me
     CurrRec = GetCurrentRowNumber(datBrowse)
     datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
'     SetToCurrencyFormat Me
     txtConfNum.SetFocus
   End If
   If Not OtherGuestFormsInBrowseMode And GetFormMode(Me) = "No Rows" Then gConfNum = 0
   
cmdCancel_Click_Resume:
   CancelClicked = False
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume

End Sub


Private Sub cmdCommit_Click()

    On Error GoTo cmdCommit_Click_Error
    
    Screen.MousePointer = HOURGLASS
    Dim TempID As Long
    Dim SSTemp As Recordset
    Dim CarOrTravelExists As Integer
    Screen.MousePointer = HOURGLASS
    
    Select Case GetFormMode(Me)
      Case "Insert"
        'Fillin system Date/User fields
        txtEntryUser.Text = gComputerName
        txtEntryDate.Text = Format(Now, "m/d/yyyy")
        txtUpdateUser.Text = gComputerName
        txtUpdateDate.Text = Format(Now, "m/d/yyyy")
        'Check for valid dates and number formats
        If Not VerifyUpdate() Then
          ' MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Ensure number of nights is filled in (this is also done by
        'LostFocus on Arrive and Depart dates, but it's possible for user
        'to use Alt+Key to Commit without ever losing focus.)
        If Not GetNumNights() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmAccommodations
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
        'Warn if there are Special Circumstances/Exceptions when booking this property.
        Set SSTemp = gBNB.OpenRecordset("select Exceptions,Exceptions_Desc from proptbl where accountnum = " & lblAcctNum.Caption, dbOpenSnapshot)
        GetSSRows SSTemp
        If Not SSTemp.EOF Then
           If SSTemp(0) = -1 Then 'If checked to display message then...
              gMsg = "There are special considerations for this property: " & Chr$(10) & Chr$(10) & SSTemp(1) & Chr$(10) & Chr$(10) & _
                     "Continue with the commit of this record?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) <> IDYES Then GoTo cmdCommit_Click_Resume
           End If
        End If
        'Warn if entering a past arrival or departure date
        If CDate(Format(txtArrDate.Text, "m/d/yyyy")) < CDate(Format(Now, "m/d/yyyy")) And CDate(Format(txtDepDate.Text, "m/d/yyyy")) < CDate(Format(Now, "m/d/yyyy")) Then
           gMsg = "Past dates have been entered into the Arrival and Departure Date fields. Are you sure you want to continue entering past dates?"
           If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) <> IDYES Then GoTo cmdCommit_Click_Resume
        ElseIf CDate(Format(txtArrDate.Text, "m/d/yyyy")) < CDate(Format(Now, "m/d/yyyy")) Then
           gMsg = "A past date has been entered into the Arrival Date field. Are you sure you want to continue entering a past date?"
           If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) <> IDYES Then GoTo cmdCommit_Click_Resume
        ElseIf CDate(Format(txtDepDate.Text, "m/d/yyyy")) < CDate(Format(Now, "m/d/yyyy")) Then
           gMsg = "A past date has been entered into the Departure Date field. Are you sure you want to continue entering a past date?"
           If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) <> IDYES Then GoTo cmdCommit_Click_Resume
        End If
        'Warn that Commission due from Host should be blank or zero if Prepay or Comp payment type
        If Trim(txtCommishDue.Text) <> "" Then
           If (UCase(Trim(datdwComboPaymentType.Text)) = "PREPAY" Or UCase(Trim(datdwComboPaymentType.Text)) = "COMP") And (Trim(txtCommishDue.Text) <> 0 And Trim(txtCommishDue.Text) <> "") Then
              gMsg = "A commission has been entered, but the payment type is Prepay or Comp. Typically, " & _
                     "a commission is paid only when the payment type is 'Direct'.  Continue entering " & _
                     "non-zero commission?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) <> IDYES Then GoTo cmdCommit_Click_Resume
           End If
        End If
        'Determine values for Calculated Amounts section
        If chkFillCalcAmounts.Value = UNCHECKED Then
          If Not CalculateAmounts(Me) Then
             MsgBox gMsg, MB_ICONSTOP, Me.Caption
             GoTo cmdCommit_Click_Resume
          End If
        End If
        'Set currency formats
        SetToCurrencyFormat Me
        'Update row
        'Check if any Date, Currency or Number fields were set to blank (0
        'length string); if so, unbind control's DataField property and commit Null.
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
'    TempProp = datdwComboProperty.Text
        datBrowse.Recordset.Update
'    datdwComboProperty.Text = TempProp
        datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
        If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        datBrowse.Recordset.MoveLast
        SetToCurrencyFormat Me
        
        'Warning that travel commission needs to be updated if adding a new accommodation
        'and travel already exists.
        Set SSTemp = gBNB.OpenRecordset("select conf from TAGENTBL where conf = " & txtConfNum.Text, dbOpenSnapshot)
        GetSSRows SSTemp
        If SSTemp.RecordCount > 0 Then
           gMsg = "Travel agency commission must be updated for this guest when adding a new accommodation. " & _
                  "Proceed to the Travel Agency screen by clicking the 'GoTo...' button when entry of accommodation(s) is complete."
           MsgBox gMsg, MB_ICONEXCLAMATION, Me.Caption
        End If
        SSTemp.Close
      Case "Update"
        'Fillin system Date/User fields
        txtUpdateUser.Text = gComputerName
        txtUpdateDate.Text = Format(Now, "m/d/yyyy")
        'Check for valid dates and number formats
        If Not VerifyUpdate() Then
           'MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Ensure number of nights is filled in (this is also done by
        'LostFocus on Arrive and Depart dates, but it's possible for user
        'to use Alt+Key to Commit without ever losing focus.)
        If Not GetNumNights() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmAccommodations
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
        'Warn if there are Special Circumstances/Exceptions when booking this property.
        Set SSTemp = gBNB.OpenRecordset("select Exceptions,Exceptions_Desc from proptbl where accountnum = " & lblAcctNum.Caption, dbOpenSnapshot)
        GetSSRows SSTemp
        If Not SSTemp.EOF Then
           If SSTemp(0) = -1 Then 'If checked to display message then...
              gMsg = "There are special considerations for this property: " & Chr$(10) & Chr$(10) & SSTemp(1) & Chr$(10) & Chr$(10) & _
                     "Continue with the commit of this record?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) <> IDYES Then GoTo cmdCommit_Click_Resume
           End If
        End If
        'Warn if entering a past arrival or departure date (only if dates have changed)
        If txtArrDate.Text <> OrigArrDate Or txtDepDate.Text <> OrigDepDate Then
           If CDate(Format(txtArrDate.Text, "m/d/yyyy")) < CDate(Format(Now, "m/d/yyyy")) And CDate(Format(txtDepDate.Text, "m/d/yyyy")) < CDate(Format(Now, "m/d/yyyy")) Then
              gMsg = "Past dates have been entered into the Arrival and Departure Date fields. Are you sure you want to continue entering past dates?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) <> IDYES Then GoTo cmdCommit_Click_Resume
           ElseIf CDate(Format(txtArrDate.Text, "m/d/yyyy")) < CDate(Format(Now, "m/d/yyyy")) Then
              gMsg = "A past date has been entered into the Arrival Date field. Are you sure you want to continue entering a past date?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) <> IDYES Then GoTo cmdCommit_Click_Resume
           ElseIf CDate(Format(txtDepDate.Text, "m/d/yyyy")) < CDate(Format(Now, "m/d/yyyy")) Then
              gMsg = "A past date has been entered into the Departure Date field. Are you sure you want to continue entering a past date?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) <> IDYES Then GoTo cmdCommit_Click_Resume
           End If
        End If
        'Warn that Commission due from Host should be blank or zero if Prepay or Comp payment type
        If Trim(txtCommishDue.Text) <> "" Then
           If (UCase(Trim(datdwComboPaymentType.Text)) = "PREPAY" Or UCase(Trim(datdwComboPaymentType.Text)) = "COMP") And Trim(txtCommishDue.Text) <> 0 Then
              gMsg = "A commission has been entered, but the payment type is Prepay or Comp. Typically, " & _
                     "a commission is paid only when the payment type is 'Direct'.  Continue entering " & _
                     "non-zero commission?"
              If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) <> IDYES Then GoTo cmdCommit_Click_Resume
           End If
        End If
        'Determine values for Calculated Amounts section
        If chkFillCalcAmounts.Value = UNCHECKED Then
          If Not CalculateAmounts(Me) Then
             MsgBox gMsg, MB_ICONSTOP, Me.Caption
             GoTo cmdCommit_Click_Resume
          End If
        End If
        'Update revision date if key fields changed. This is different than
        'update date in that update date is updated when ANY commit occurs.
        'Revision date is used to locate rows for Daily Booking and Host
        'Notification reports.
        If KeyFieldsUpdated() Then
           Dim OrigExists As Integer
           Dim AccomRowID As Long
           Dim RevText As String
           'Set to non-comma format, otherwise commas (eg: 1,021.25) may
           'appear in following INSERT INTO query, causing SQL error when executed.
           'SetToCurrencyFormat2 Me
           'Insert ORIGINAL data (for this row) into audit table if not there already.
           RevText = ""
           OrigExists = False
           AccomRowID = datBrowse.Recordset("ID")
           gSQL = "select * from AccomAudit where Accom_RowID  = " & _
           AccomRowID & " AND Action = '(ORIGINAL)' AND ActionDate IS NULL"
           Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
           GetSSRows SSTemp
           If SSTemp.RecordCount > 0 Then OrigExists = True
           If Not OrigExists Then
              If KeyFields(3) = "" Then
                 KeyFields(3) = "NULL"
              Else
                 If Mid(KeyFields(3), 1, 1) <> "#" Then KeyFields(3) = "#" & KeyFields(3) & "#"
              End If
              If KeyFields(4) = "" Then
                 KeyFields(4) = "NULL"
              Else
                 If Mid(KeyFields(4), 1, 1) <> "#" Then KeyFields(4) = "#" & KeyFields(4) & "#"
              End If
              If KeyFields(2) = "" Or IsNull(KeyFields(2)) Then KeyFields(2) = "0"
              If KeyFields(6) = "" Or IsNull(KeyFields(6)) Then KeyFields(6) = "0"
              gSQL = "INSERT INTO AccomAudit (Conf,Action,ActionDate," & _
              "Location,UnitName,NumPty,ArrDate,DepDate," & _
              "PymtType,GrosRate,Suppress,ComputerName,Accom_RowID) " & _
              " VALUES (" & gConfNum & ",'(ORIGINAL)',NULL," & Chr$(34) & KeyFields(0) & Chr$(34) & ",'" & _
              KeyFields(1) & "'," & KeyFields(2) & "," & KeyFields(3) & "," & _
              KeyFields(4) & ",'" & KeyFields(5) & "'," & Format(KeyFields(6), CURRENCYFORMAT2) & "," & _
              KeyFields(12) & "," & Chr$(34) & gComputerName & Chr$(34) & "," & AccomRowID & ");"
              'MsgBox gSQL
              gBNB.Execute gSQL
           End If
           If KeyFields(12) = 0 And chkSuppress.Value = CHECKED Then
              RevText = "CANCELED"
           ElseIf KeyFields(12) = -1 And chkSuppress.Value = UNCHECKED Then
              RevText = "REINSTATED"
           Else
              RevText = "REVISED"
           End If
           'Insert REVISION/CANCELATION data into audit table
           gSQL = "INSERT INTO AccomAudit (Conf,Action,ActionDate," & _
           "Location,UnitName," & _
           "NumPty,ArrDate,DepDate, " & _
           "PymtType,GrosRate,Suppress,ComputerName,Accom_RowID) " & _
           " VALUES (" & gConfNum & ",'" & RevText & "',#" & Format(Now, "m/d/yyyy h:mm:ss") & "#," & Chr$(34) & datdwComboProperty.Text & Chr$(34) & ",'" & _
           datdwComboRoomType.Text & "'," & txtNumPersons.Text & ",#" & txtArrDate.Text & "#,#" & _
           txtDepDate.Text & "#,'" & datdwComboPaymentType.Text & "'," & Format(txtDailyGrossRate.Text, CURRENCYFORMAT2) & "," & _
           chkSuppress.Value & "," & Chr$(34) & gComputerName & Chr$(34) & "," & AccomRowID & ");"
           'MsgBox gSQL
           gBNB.Execute gSQL
           'Clear the 'Host Notified' checkbox on Accomodation form.
           chkNotified.Value = UNCHECKED
           txtRevisionDate.Text = Format(Now, "m/d/yyyy")
        End If
        'Set currency formats back to comma-type (eg: 1,025.25)
        SetToCurrencyFormat Me
        'Update row
        'datBrowse.Recordset.Update
        'Check if any Date, Currency or Number fields were set to blank (0
        'length string); if so, unbind control's DataField property and commit Null.
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        'getting No Current Record here. Put next (1) line in to correct.
        datBrowse.Recordset.Bookmark = datBrowse.Recordset.LastModified
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        datBrowse.Recordset.Bookmark = datBrowse.Recordset.LastModified
        datBrowse.UpdateControls
        SetToCurrencyFormat Me
        'Warning that car and/or travel commissions need to be updated if dates change
        If txtArrDate.Text <> OrigArrDate Or txtDepDate.Text <> OrigDepDate Then
           'Check for car reservation
           CarOrTravelExists = 0
           Set SSTemp = gBNB.OpenRecordset("select conf from cartbl where conf = " & txtConfNum.Text, dbOpenSnapshot)
           GetSSRows SSTemp
           If SSTemp.RecordCount > 0 Then CarOrTravelExists = 1
           SSTemp.Close
           'Check for travel agent
           Set SSTemp = gBNB.OpenRecordset("select conf from TAGENTBL where conf = " & txtConfNum.Text, dbOpenSnapshot)
           GetSSRows SSTemp
           If SSTemp.RecordCount > 0 Then CarOrTravelExists = CarOrTravelExists + 2
           SSTemp.Close
            Select Case CarOrTravelExists
              Case 0
              Case 1
                 gMsg = "Car rental agency commission must be updated for this guest. " & _
                        "Proceed to the Car Reservation screen by clicking the 'GoTo...' button."
                        MsgBox gMsg, MB_ICONEXCLAMATION, Me.Caption
              Case 2
                 gMsg = "Travel agency commission must be updated for this guest. " & _
                        "Proceed to the Travel Agency screen by clicking the 'GoTo...' button."
                        MsgBox gMsg, MB_ICONEXCLAMATION, Me.Caption
              Case 3
                 gMsg = "Both travel agency and car rental commissions must be updated for this guest. " & _
                        "Proceed to those screens by clicking the 'GoTo...' button."
                        MsgBox gMsg, MB_ICONEXCLAMATION, Me.Caption
           End Select
        End If
      Case "Delete"
        'Cannot delete if Payment has been made against this accommodation row
        Set SSTemp = gBNB.OpenRecordset("select checknum from checktbl where void_chk <> -1 And Accom_RowId = " & datBrowse.Recordset("ID"), dbOpenSnapshot)
        GetSSRows SSTemp
        If SSTemp.RecordCount > 0 Then
           gMsg = "Cannot delete. A payment has been made to Host on this accommodation."
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
    Screen.MousePointer = DEFAULT
    Exit Sub

cmdCommit_Click_Error:
   MsgBox Err.Description
   GoTo cmdCommit_Click_Resume

End Sub


Private Sub cmdDelete_Click()
   
   On Error GoTo cmdDelete_Click_Error
   
   CancelClicked = False
   SetFormToDeleteMode Me

cmdDelete_Click_Resume:
   Exit Sub
   
cmdDelete_Click_Error:
   GoTo cmdDelete_Click_Resume
   
End Sub


Private Sub cmdDisplayRows_Click()
    
    On Error GoTo cmdDisplayRows_Click_Error
    
    'Warn if more than 500 records
    If datBrowse.Recordset.RecordCount > 300 Then
      gMsg = "You are about to display " & _
             datBrowse.Recordset.RecordCount & _
             " rows to the screen. Continue?"
      If MsgBox(gMsg, MB_ICONQUESTION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then Exit Sub
    End If
    Screen.MousePointer = HOURGLASS
    gCaption = "Guest Accommodations Listing"
    gSQL = datBrowse.RecordSource
    'frmBoundListing.Show
    Dim frmNewBoundListing As New frmBoundListing  ' Declare form variable
    frmNewBoundListing.Show     ' Load and display new instance
   ' frmNewBoundListing.txtSQLStatement.Tag = "Write Enabled"
   ' 'Set the HelpContextID for the form ( The F1 Help File Jump ).
   ' frmNewBoundListing.HelpContextID = 410

cmdDisplayRows_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdDisplayRows_Click_Error:
   GoTo cmdDisplayRows_Click_Resume

End Sub


Private Sub cmdExit_Click()
   Unload Me
End Sub

Private Sub cmdFind_Click()
   
   On Error GoTo cmdFind_Click_Error
   
   CancelClicked = False
   Screen.MousePointer = HOURGLASS
   Dim Criteria As String
   If cmdFind.Caption = "&Find" Then
      SetFormToFindMode Me
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

cmdFind_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

cmdFind_Click_Error:
    MsgBox Err.Description
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

    'Screen.MousePointer = HOURGLASS
    On Error GoTo cmdInsert_Click_Error
    
    CancelClicked = False
    SetFormToInsertMode Me
    
    If chkSuppress.Value = CHECKED Then
      chkForfeit.Enabled = True
    Else
      chkForfeit.Enabled = False
      chkForfeit.Value = False
    End If
    'Can edit name only from frmGeneralGuest
    txtFirstName.Locked = True
    txtLastName.Locked = True
    txtFirstName.ForeColor = BLACK
    txtLastName.ForeColor = BLACK
    chkNotified.Enabled = False
    'Insurance
'    If Trim(datBrowse.RecordSource) = "" Then
       datBrowse.RecordSource = "select * from " & Me.Tag & " where conf = " & gConfNum
       If Not GetDCRows(datBrowse) Then Exit Sub
'    End If
    txtNumNites.Locked = True
    txtNumNites.ForeColor = BLACK
    txtRevisionDate.Locked = True
    txtRevisionDate.ForeColor = BLACK
    txtTax1.ForeColor = BLACK
    txtTax2.ForeColor = BLACK
    txtTax3.ForeColor = BLACK
    datBrowse.Recordset.AddNew
    SetZeroLengthString Me
    Call chkFillCalcAmounts_Click(False)
    If gConfNum <> 0 Then
       'Get first and last name if gConfNum is set. Also disallow edit on conf number.
       Dim SSTemp As Recordset
       txtConfNum.Locked = True
       txtConfNum.ForeColor = BLACK
       Set SSTemp = gBNB.OpenRecordset("select f_name,l_name from guesttbl where conf = " & gConfNum, dbOpenSnapshot)
       GetSSRows SSTemp
       If SSTemp.RecordCount > 0 Then
          txtConfNum.Text = gConfNum
          If Not IsNull(SSTemp("f_name")) Then txtFirstName.Text = SSTemp("f_name")
          If Not IsNull(SSTemp("l_name")) Then txtLastName.Text = SSTemp("l_name")
          datdwComboProperty.SetFocus
       End If
       SSTemp.Close
    Else
       txtConfNum.Locked = False
       txtConfNum.ForeColor = BLUE
       txtConfNum.SetFocus
    End If
    txtRevisionDate.Text = Format$(Now, "m/d/yyyy")
    
cmdInsert_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub

cmdInsert_Click_Error:
   MsgBox Err.Description
   GoTo cmdInsert_Click_Resume

End Sub

Private Sub cmdUpdate_Click()
   
   On Error GoTo cmdUpdate_Click_Error
   
   CancelClicked = False
   SetFormToUpdateMode Me
   
   If chkSuppress.Value = CHECKED Then
     chkForfeit.Enabled = True
   Else
     chkForfeit.Enabled = False
     chkForfeit.Value = False
   End If
   
   chkNotified.Enabled = False
   txtNumNites.Locked = True
   txtNumNites.ForeColor = BLACK
   txtRevisionDate.Locked = True
   txtRevisionDate.ForeColor = BLACK
   Call chkFillCalcAmounts_Click(chkFillCalcAmounts.Value)
   FillKeyFields
   OrigProperty = datdwComboProperty.Text
   OrigAcctNum = lblAcctNum.Caption
   OrigArrDate = txtArrDate.Text
   OrigDepDate = txtDepDate.Text
   datBrowse.Recordset.Edit

cmdUpdate_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdUpdate_Click_Error:
    If datBrowse.Recordset.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
    MsgBox Err.Description
    datBrowse.UpdateControls
    If Not GetDCRows(datBrowse) Then Exit Sub
    If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
       SetFormToNoRowsMode Me
    Else
       SetFormToBrowseMode Me
       CurrRec = 1 'GetCurrentRowNumber(datBrowse)
       datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
    End If
    Resume cmdUpdate_Click_Resume
   
End Sub


Private Sub datBrowse_Reposition()
   'SetToCurrencyFormat Me
End Sub

Private Sub datdwComboPaymentType_Change()
  
  If Trim(datdwComboPaymentType.Text) = "" Then Exit Sub
  If Not Trim(datdwComboPaymentType.Text) Like "[A-Z]" _
     And Not Trim(datdwComboPaymentType.Text) Like "[a-z]" Then Exit Sub
  Dim SSTemp As Recordset
  Set SSTemp = gBNB.OpenRecordset("select payment_type from paymenttype where payment_type Like '" & datdwComboPaymentType.Text & "*'", dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount > 0 Then datdwComboPaymentType.Text = SSTemp(0)
  SSTemp.Close
  
End Sub

Private Sub datdwComboPaymentType_CloseUp()

   cmdFind.DEFAULT = True
   
End Sub


Private Sub datdwComboPaymentType_DropDown()

   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        datdwComboPaymentType.DataFieldList = ""
        Exit Sub
     Case Else
        datdwComboPaymentType.DefColWidth = datdwComboPaymentType.Width * 2
        datdwComboPaymentType.DataFieldList = "payment_type"
   End Select
   
   'datDropListing.DatabaseName = gDatabaseName
   datTypeList.RecordSource = "select payment_type, payment_type_desc from paymenttype"
   If Not GetDCRows(datTypeList) Then Exit Sub
   cmdFind.DEFAULT = False
   
End Sub

Private Sub datdwComboPaymentType_KeyPress(KeyAscii As Integer)
   
   If UCase(GetFormMode(Me)) = "FIND" Or UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then

   Else
      KeyAscii = False
   End If


End Sub

Private Sub datdwComboProperty_CloseUp()

   On Error GoTo Closeup_Error
   'Fix for unknown bug. Symptoms:
   '1. Click insert on accommodations form.
   '2. TYPE a property name EXACTLY (including case) as it exists in the database.
   '3. Hit dropdown for property name and select same property previously typed in.
   '4. Continue with entry of other fields
   '5. On Commit, property name field is blanked and Null property name is saved to Database.
   datdwComboProperty.Text = ""
   datdwComboProperty.Refresh
   If Not datPropList.Recordset.BOF And Not datPropList.Recordset.EOF Then
      datdwComboProperty.Text = datdwComboProperty.Columns("location").Text
   End If
   datdwComboProperty.Refresh
   cmdFind.DEFAULT = True
   
Closeup_Resume:
   Exit Sub

Closeup_Error:
   Resume Closeup_Resume

End Sub

Private Sub datdwComboProperty_DropDown()

   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        datdwComboProperty.DataFieldList = ""
        Exit Sub
     Case Else
        datdwComboProperty.DefColWidth = datdwComboProperty.Width * 1.5
        datdwComboProperty.DataFieldList = "location"
   End Select
   
   'datDropListing.DatabaseName = gDatabaseName
   datPropList.RecordSource = "select location,accountnum from proptbl where PropObsolete<>-1 order by location"
   If Not GetDCRows(datPropList) Then Exit Sub
   datdwComboProperty.Columns(1).Width = Me.TextWidth("XXXXXXXXXX")
   cmdFind.DEFAULT = False

End Sub

Private Sub datdwComboProperty_KeyPress(KeyAscii As Integer)
   
   If UCase(GetFormMode(Me)) = "FIND" Or UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then

   Else
      KeyAscii = False
   End If

End Sub


Private Sub datdwComboRoomType_Change()

  Dim SSTemp As Recordset
  
  On Error GoTo Change_Error
  
  If GetFormMode(Me) = "Find" Then
     lblRoomTypeDesc.Caption = ""
     GoTo Change_Resume
  End If
  
  If lblAcctNum.Caption <> "" And datdwComboRoomType.Text <> "" Then
     Set SSTemp = gBNB.OpenRecordset("select RoomType_Desc from HostAccount_RoomType_Link where AccountNum = " & lblAcctNum.Caption & " And RoomType = " & datdwComboRoomType.Text, dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount = 0 Then
        lblRoomTypeDesc.Caption = ""
     Else
        lblRoomTypeDesc.Caption = Trim(SSTemp(0))
     End If
     SSTemp.Close
  Else
     lblRoomTypeDesc.Caption = ""
  End If

Change_Resume:
   Exit Sub

Change_Error:
   Resume Change_Resume

End Sub

Private Sub datdwComboRoomType_CloseUp()

  Dim SSTemp As Recordset
  
  On Error GoTo Closeup_Error
  
  cmdFind.DEFAULT = True
  
  If GetFormMode(Me) = "Find" Then
     lblRoomTypeDesc.Caption = ""
     GoTo Closeup_Resume
  End If
  
  If lblAcctNum.Caption <> "" And datdwComboRoomType.Text <> "" Then
     Set SSTemp = gBNB.OpenRecordset("select RoomType_Desc from HostAccount_RoomType_Link where AccountNum = " & lblAcctNum.Caption & " And RoomType = " & datdwComboRoomType.Text, dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount = 0 Then
        lblRoomTypeDesc.Caption = ""
     Else
        lblRoomTypeDesc.Caption = Trim(SSTemp(0))
     End If
     SSTemp.Close
  Else
     lblRoomTypeDesc.Caption = ""
  End If

Closeup_Resume:
   Exit Sub

Closeup_Error:
   Resume Closeup_Resume

End Sub


Private Sub datdwComboRoomType_DropDown()
 
   On Error GoTo datdwComboRoomType_Error
   
   Dim SSTemp As Recordset
  
   If Trim(datdwComboProperty.Text) = "" Then
      gMsg = "Select Property from the dropdown list before selecting Room Type."
      MsgBox gMsg, MB_ICONSTOP, Me.Caption
      SSTemp.Close
      GoTo datdwComboRoomType_Resume
   Else
      Set SSTemp = gBNB.OpenRecordset("select accountnum from proptbl where location = " & Chr$(34) & datdwComboProperty.Text & Chr$(34), dbOpenSnapshot)
      GetSSRows SSTemp
      If SSTemp.RecordCount = 0 Then
         gMsg = "Account number for this property is not set or Property name was entered incorrectly. Select a property name from the dropdown list."
         MsgBox gMsg, MB_ICONSTOP, Me.Caption
         SSTemp.Close
         GoTo datdwComboRoomType_Resume
      Else
         lblAcctNum.Caption = Trim(SSTemp("accountnum"))
      End If
      SSTemp.Close
   End If
   
   If Trim(lblAcctNum.Caption) = "" Then
      MsgBox "Enter Property name first"
      GoTo datdwComboRoomType_Resume
   End If
   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        datdwComboRoomType.DataFieldList = ""
        GoTo datdwComboRoomType_Resume
     Case Else
        'datdwComboRoomType.Columns(0).Width = Me.TextWidth("XXXXXXXXXX")
        'datdwComboRoomType.Columns(1).Width = Me.TextWidth("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")
        datdwComboRoomType.DataFieldList = "RoomType"
   End Select
   'datDropListing.DatabaseName = gDatabaseName
   datRoomType.RecordSource = "select RoomType,RoomType_Desc from HostAccount_RoomType_Link Where AccountNum = " & lblAcctNum.Caption & " order by RoomType"
   If Not GetDCRows(datRoomType) Then GoTo datdwComboRoomType_Resume
   cmdFind.DEFAULT = False
   
datdwComboRoomType_Resume:
   Exit Sub

datdwComboRoomType_Error:
   Resume datdwComboRoomType_Resume
   
End Sub

Private Sub datdwComboRoomType_InitColumnProps()
   datdwComboRoomType.Columns(0).Width = Me.TextWidth("XXXXXXXXXX")
   datdwComboRoomType.Columns(1).Width = Me.TextWidth("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")
End Sub


Private Sub datdwComboRoomType_KeyPress(KeyAscii As Integer)
   
   If UCase(GetFormMode(Me)) = "FIND" Or UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then

   Else
      KeyAscii = False
   End If

End Sub

Private Sub datdwComboTaxPlanCode_CloseUp()

   cmdFind.DEFAULT = True
   
End Sub

Private Sub datdwComboTaxPlanCode_DropDown()

   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        datdwComboTaxPlanCode.DataFieldList = ""
        Exit Sub
     Case Else
        datdwComboTaxPlanCode.DefColWidth = datdwComboTaxPlanCode.Width * 2
        datdwComboTaxPlanCode.DataFieldList = "plancode"
   End Select
   
   'datDropListing.DatabaseName = gDatabaseName
   datTaxList.RecordSource = "select plan_title, plancode from taxplan order by plan_title"
   If Not GetDCRows(datTaxList) Then Exit Sub
   cmdFind.DEFAULT = False
   
End Sub





Private Sub datdwComboTaxPlanCode_KeyPress(KeyAscii As Integer)
   
   If UCase(GetFormMode(Me)) = "FIND" Or UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then

   Else
      KeyAscii = False
   End If

End Sub


Private Sub datdwData1_Click(ByVal nPosition As Integer)
    
    On Error GoTo datdwData1_Click_Error
    Screen.MousePointer = HOURGLASS
    Me.SetFocus
   ' Dim EntryConfNum As String
   ' EntryConfNum = Trim$(txtConfNum.Text)
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
    MsgBox Err.Description
    GoTo datdwData1_Click_Resume

End Sub



Private Sub Form_Activate()

'MsgBox "gConfNum=" & Str$(gConfNum) & ", Prior=" & Str$(gPriorConfNum) & ", gRowChangeFormName=" & gRowChangeFormName
On Error GoTo Form_Activate_Error

'If this form is in the background (does not have focus) and the
'Minimize button is clicked on this form that does not yet have the focus,
'an endless loop of Minimizing and Activating will occur. The following
'line prevents this interesting problem.
If Me.WindowState = MINIMIZED Then Exit Sub
'If form is only regaining focus then exit
If UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then Exit Sub
If TimesActivated < 1 Or (gConfNum <> gPriorConfNum And gRowChangeFormName <> Me.Name) _
   Or ((Trim$(txtConfNum.Text) <> Trim$(gConfNum)) And (Trim$(txtConfNum.Text) <> "")) _
   Or gConfNum <> 0 And Trim(txtConfNum.Text) = "" Then
   Screen.MousePointer = HOURGLASS
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

Call chkFillCalcAmounts_Click(False)

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
   datPropList.DatabaseName = gDatabaseName
   datTypeList.DatabaseName = gDatabaseName
   datTaxList.DatabaseName = gDatabaseName
   datRoomType.DatabaseName = gDatabaseName
   'datBrowse.Refresh
   CurrRec = 1
   SaveRec = 0

Load_Resume:
   Exit Sub
   
Load_Error:
   Resume Load_Resume

End Sub


Private Sub Form_Resize()

    If Me.WindowState = MINIMIZED Then Exit Sub
    'MsgBox Str$(ScaleWidth)
    Me.Width = cmdCancel.Width * 7.1
    Me.Height = cmdCancel.Height * 10.7

End Sub



Private Sub Form_Unload(Cancel As Integer)
  DoEvents
End Sub




Private Sub txtArrDate_LostFocus()
   
   On Error GoTo txtArrDate_Error
   
   If Trim(txtArrDate.Text) = "" Then Exit Sub
   
   If Not IsDate(txtArrDate.Text) And GetFormMode(Me) <> "Find" Then
      gMsg = "Invalid date. Use mm/dd/yy format."
      MsgBox gMsg, MB_ICONSTOP, Me.Caption
      GoTo txtArrDate_Resume
   End If
      
   If Not GetNumNights() Then Exit Sub
  
txtArrDate_Resume:
   Exit Sub
  
txtArrDate_Error:
   Resume txtArrDate_Resume
  
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

Private Sub txtConfNum_LostFocus()

  Dim SSTemp As Recordset
  If Not IsNumeric(txtConfNum.Text) Or txtConfNum.Text = "" Or GetFormMode(Me) <> "Insert" Then Exit Sub
  Set SSTemp = gBNB.OpenRecordset("select f_name,l_name from guesttbl where conf = " & CLng(txtConfNum.Text), dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount > 0 Then
    If Not IsNull(SSTemp("f_name")) Then txtFirstName.Text = SSTemp("f_name")
    If Not IsNull(SSTemp("l_name")) Then txtLastName.Text = SSTemp("l_name")
  End If
  SSTemp.Close
  
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
                 'Move Msg here because SetFocus is nullified by
                 'MsgBox on SSCombo controls. Msgbox needs to come b/4 setfocus.
                 MsgBox gMsg, MB_ICONSTOP, Me.Caption
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
                 MsgBox gMsg, MB_ICONSTOP, Me.Caption
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
   'User chose to override default percentage paid to host
   If Trim(txtPercent.Text) <> "" Then
     If IsNumeric(txtPercent.Text) Then
       If Not (txtPercent.Text >= 0 And txtPercent.Text <= 100) Then
          gMsg = "Percentage Paid to Host must be between 0 and 100."
          VerifyUpdate = False
          txtPercent.SetFocus
       Else
          txtPercent.Text = Trim(txtPercent.Text)
       End If
     Else
          gMsg = "Percentage Paid to Host must be numeric."
          VerifyUpdate = False
          txtPercent.SetFocus
     End If
   Else
      txtPercent.Text = Trim(txtPercent.Text)
   End If
     
End Function

Public Function InsertTrigger() As Integer
  
  On Error GoTo InsertTrigger_Error
  
  Dim SSTemp As Recordset
  Dim v_IsValid As Integer
  Dim vTempCount As Integer
  
  txtConfNum.Text = Trim$(txtConfNum.Text)
  datdwComboProperty.Text = Trim$(datdwComboProperty.Text)
  If Trim(txtNumPersons.Text) = "" Then txtNumPersons.Text = "0"
  If Trim(txtDailyGrossRate.Text) = "" Then txtDailyGrossRate.Text = "0"
  InsertTrigger = True
  SetFocusTo = ""
  'Check for confirmation number equal to zero
  If txtConfNum.Text = "0" Or txtConfNum.Text = "" Then
     gMsg = "Confirmation number cannot be zero or blank."
     InsertTrigger = False
     SetFocusTo = "txtConfNum"
     Exit Function
  End If
  'Conf number must exist in guesttbl
  Set SSTemp = gBNB.OpenRecordset("select conf from guesttbl where conf = " & txtConfNum.Text, dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Confirmation number must exist in Guest General Information before accommodations can be entered."
     InsertTrigger = False
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close
  
'At least one non-cancelled row needs to exist in bbtbl if car exists.
  gSQL = "select count(*) from cartbl " & _
         "where conf = " & txtConfNum.Text & _
         " And CommishDue>0 and Not IsNull(CommishDue)"
  Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
  GetSSRows SSTemp
  vTempCount = SSTemp(0)
  SSTemp.Close
  If vTempCount > 0 Then
     'Get number of non-cancelled accomodation rows for this conf (excluding current row).
     gSQL = "select count(*) from bbtbl " & _
            "where conf = " & CLng(txtConfNum.Text) & _
            " And suppress<>-1 And ID<>" & datBrowse.Recordset("ID")
     Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
     GetSSRows SSTemp
'MsgBox Str(SSTemp(0))
     If SSTemp(0) = 0 Then
        If chkSuppress.Value = CHECKED Then
           gMsg = "A car reservation with commission due exists for " & _
               "this confirmation. At least one non-cancelled " & _
               "accommodation row must exist in Guest Accommodations if " & _
               "a guest retains a car reservation with a non-zero commission. If guest is " & _
               "requesting car reservations only, enter the 'Car Only' host property " & _
               "account into the Guest Accommodations screen, then " & _
               "cancel or delete all other guest accommodations."
           InsertTrigger = False
           SSTemp.Close
           Exit Function
        End If
     End If
     SSTemp.Close
  End If
  
  'Property name must exist in host account table (proptbl)
  Set SSTemp = gBNB.OpenRecordset("select location from proptbl where location = " & Chr$(34) & datdwComboProperty.Text & Chr$(34), dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Property name does not exist in Host Accounts. Select a property from the dropdown list."
     InsertTrigger = False
     SetFocusTo = "datdwComboProperty"
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close
  'Fillin Property account number (lblAcctNum.Caption)
  'If datdwComboProperty.Text Like "*[']*" Then
  '   Set SSTemp = gBNB.OpenRecordset("select accountnum from proptbl where location like '" & Replace_All_In_With("'", datdwComboProperty.Text, "*") & "'", dbOpenSnapshot)
  'Else
  Set SSTemp = gBNB.OpenRecordset("select accountnum from proptbl where location = " & Chr$(34) & datdwComboProperty.Text & Chr$(34), dbOpenSnapshot)
  'End If
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Account number for this Property is not set."
     InsertTrigger = False
     SSTemp.Close
     Exit Function
  Else
     lblAcctNum.Caption = Trim(SSTemp("accountnum"))
  End If
  SSTemp.Close
  'Arrival Date must be filled in.
  If Trim(txtArrDate.Text) = "" Then
     gMsg = "Arrival Date must be filled in."
     InsertTrigger = False
     SetFocusTo = "txtArrDate"
     Exit Function
  End If
  'Departure Date must be filled in.
  If Trim(txtDepDate.Text) = "" Then
     gMsg = "Depart Date must be filled in."
     InsertTrigger = False
     SetFocusTo = "txtDepDate"
     Exit Function
  End If
  'If there are more than 0 entries in the HostAccount_RoomType_Link table for
  'the current property accountnum, then RoomType must be specified.
  Set SSTemp = gBNB.OpenRecordset("select RoomType from HostAccount_RoomType_Link where accountnum = " & lblAcctNum.Caption, dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount > 0 Then 'If room type exists, must specify it.
     If Trim(datdwComboRoomType.Text) = "" Then
        gMsg = "Select a Room Type from the dropdown list."
        InsertTrigger = False
        SetFocusTo = "datdwComboRoomType"
        SSTemp.Close
        Exit Function
     Else ' Make sure it's a valid entry for Room Type
        datdwComboRoomType.Text = Trim(datdwComboRoomType.Text)
        v_IsValid = False
        For i = 0 To SSTemp.RecordCount - 1
          If SSTemp("RoomType") = datdwComboRoomType.Text Then
             v_IsValid = True
             Exit For
          End If
          SSTemp.MoveNext
        Next i
        If Not v_IsValid Then
           gMsg = "Invalid Room Type. Select a Room Type from the dropdown list."
           InsertTrigger = False
           SetFocusTo = "datdwComboRoomType"
           SSTemp.Close
           Exit Function
        End If
        SSTemp.Close
     End If
  Else
     If Trim(datdwComboRoomType.Text) <> "" Then
        gMsg = "Room types have not been specified for this property. Set room types through the 'Accounts' > 'Host Properties' > 'Room Types' selections."
        InsertTrigger = False
        SetFocusTo = "datdwComboRoomType"
        SSTemp.Close
        Exit Function
     End If
     SSTemp.Close
  End If
  'Fillin UnitNameDesc label
  If lblAcctNum.Caption <> "" And datdwComboRoomType.Text <> "" Then
     Set SSTemp = gBNB.OpenRecordset("select RoomType_Desc from HostAccount_RoomType_Link where AccountNum = " & lblAcctNum.Caption & " And RoomType = " & datdwComboRoomType.Text, dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount = 0 Then
        lblRoomTypeDesc.Caption = ""
     Else
        lblRoomTypeDesc.Caption = Trim(SSTemp(0))
     End If
     SSTemp.Close
  Else
     lblRoomTypeDesc.Caption = ""
  End If
  'Payment type must exist in paymenttype table.
  Set SSTemp = gBNB.OpenRecordset("select payment_type from paymenttype where payment_type = '" & datdwComboPaymentType.Text & "'", dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Payment type is incorrect. Select a payment type from the dropdown list."
     InsertTrigger = False
     SetFocusTo = "datdwComboPaymentType"
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close
  'Tax plan code must exist in taxplan table.
  If Trim(datdwComboTaxPlanCode.Text) <> "" Then
     datdwComboTaxPlanCode.Text = Trim(datdwComboTaxPlanCode.Text)
     Set SSTemp = gBNB.OpenRecordset("select plancode from taxplan where plancode = '" & datdwComboTaxPlanCode.Text & "'", dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount = 0 Then
        gMsg = "Tax Plan Code does not exist in Tax Plans. Select a tax plan from the dropdown list."
        InsertTrigger = False
        SetFocusTo = "datdwComboTaxPlanCode"
        SSTemp.Close
        Exit Function
     End If
     SSTemp.Close
  End If
  'Cannot update Property if Payment has been made against this accommodation row
  If GetFormMode(Me) = "Update" Then
     If OrigProperty <> datdwComboProperty.Text And OrigAcctNum <> lblAcctNum.Caption Then
        Set SSTemp = gBNB.OpenRecordset("select checknum from checktbl where Accom_RowId = " & datBrowse.Recordset("ID"), dbOpenSnapshot)
        GetSSRows SSTemp
        If SSTemp.RecordCount > 0 Then
           gMsg = "Cannot update Property. A payment has been made to Host on this accommodation."
           InsertTrigger = False
           SetFocusTo = "datdwComboProperty"
           SSTemp.Close
           Exit Function
        End If
        SSTemp.Close
     End If
  End If
  'If paid Direct,Commission due from Host must be filled in
  If UCase(Trim(datdwComboPaymentType.Text)) = "DIRECT" And Trim(txtCommishDue.Text) = "" Then
     gMsg = "Commission due from host cannot be blank if payment type is Direct. If no commission is " & _
            "due, enter 0"
     InsertTrigger = False
     SetFocusTo = "txtCommishDue"
     Exit Function
  End If
  
InsertTrigger_Resume:
   Exit Function
   
InsertTrigger_Error:
   Resume InsertTrigger_Resume

End Function


Private Sub txtDepDate_LostFocus()
   
   On Error GoTo txtDepDate_Error
   
   If Trim(txtDepDate.Text) = "" Then Exit Sub
   
   If Not IsDate(txtDepDate.Text) And GetFormMode(Me) <> "Find" Then
      gMsg = "Invalid date. Use mm/dd/yy format."
      MsgBox gMsg, MB_ICONSTOP, Me.Caption
      GoTo txtDepDate_Resume
   End If
      
   If Not GetNumNights() Then Exit Sub
  
txtDepDate_Resume:
   Exit Sub
  
txtDepDate_Error:
   Resume txtDepDate_Resume

End Sub

Public Function GetNumNights() As Integer
  
  On Error GoTo GetNumNights_Error
  
  GetNumNights = False
  
  If Not (GetFormMode(Me) = "Insert" Or GetFormMode(Me) = "Update") Then
     GetNumNights = True
     Exit Function
  End If
  'Calculate number of nights
  If Trim(txtDepDate.Text) <> "" And Trim(txtArrDate.Text) <> "" Then
    If DateFormatOk(txtArrDate) And DateFormatOk(txtDepDate) Then
       txtNumNites.Text = DateDiff("d", Format(txtArrDate.Text, "mm/dd/yyyy"), Format(txtDepDate.Text, "mm/dd/yyyy"))
    Else
       txtNumNites.Text = ""
       Exit Function
    End If
  Else
     txtNumNites.Text = ""
  End If
  
  GetNumNights = True
  
GetNumNights_Resume:
  Exit Function
  
GetNumNights_Error:
   Resume GetNumNights_Resume
  
End Function


Public Sub FillKeyFields()
   
   KeyFields(0) = datdwComboProperty.Text
   KeyFields(1) = datdwComboRoomType.Text
   KeyFields(2) = txtNumPersons.Text
   KeyFields(3) = txtArrDate.Text
   KeyFields(4) = txtDepDate.Text
   KeyFields(5) = datdwComboPaymentType.Text
   KeyFields(6) = txtDailyGrossRate.Text
   KeyFields(7) = txtDailyNetRate.Text
   KeyFields(8) = txtTotTax.Text
   KeyFields(9) = txtTotGrossWithTax.Text
   KeyFields(10) = txtTotNetWithTax.Text
   KeyFields(11) = txtServiceFee.Text
   KeyFields(12) = chkSuppress.Value

End Sub



Public Function KeyFieldsUpdated() As Integer

   If KeyFields(0) = Trim(datdwComboProperty.Text) _
     And KeyFields(1) = Trim(datdwComboRoomType.Text) _
     And KeyFields(2) = Trim(txtNumPersons.Text) _
     And KeyFields(3) = Trim(txtArrDate.Text) _
     And KeyFields(4) = Trim(txtDepDate.Text) _
     And KeyFields(5) = Trim(datdwComboPaymentType.Text) _
     And KeyFields(6) = Trim(txtDailyGrossRate.Text) _
     And KeyFields(12) = chkSuppress.Value Then
     KeyFieldsUpdated = False
     'The following won't trigger a revision
     'And KeyFields(7) = Trim(txtDailyNetRate.Text) _
     And KeyFields(8) = Trim(txtTotTax.Text) _
     And KeyFields(9) = Trim(txtTotGrossWithTax.Text) _
     And KeyFields(10) = Trim(txtTotNetWithTax.Text) _
     And KeyFields(11) = Trim(txtServiceFee.Text)
  Else
     KeyFieldsUpdated = True
  End If
  
End Function

