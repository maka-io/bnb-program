VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{D981334D-B212-11CE-AE8C-0000C0B99395}#2.0#0"; "SSDATA32.OCX"
Begin VB.Form frmProperty 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Host Account"
   ClientHeight    =   8265
   ClientLeft      =   1185
   ClientTop       =   1695
   ClientWidth     =   10125
   HelpContextID   =   108
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   8265
   ScaleWidth      =   10125
   Tag             =   "proptbl"
   Begin VB.CommandButton cmdFactSheet 
      Caption         =   "Fact &Sheet"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   645
      Left            =   8760
      TabIndex        =   78
      Top             =   4875
      Width           =   1335
   End
   Begin VB.CommandButton cmdRoomType 
      Caption         =   "R&oom Types"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   645
      Left            =   8760
      TabIndex        =   77
      Top             =   4200
      Width           =   1335
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
      Height          =   645
      Left            =   8760
      TabIndex        =   41
      Top             =   6225
      Width           =   1335
   End
   Begin VB.Data datTaxList 
      Appearance      =   0  'Flat
      Caption         =   "datTaxList"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   5070
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   8430
      Visible         =   0   'False
      Width           =   2175
   End
   Begin VB.Frame fraFuturePercent 
      Caption         =   "Future Percentage to Host"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1020
      Left            =   4320
      TabIndex        =   70
      Top             =   4650
      Width           =   4335
      Begin VB.TextBox txtFutEffDate 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         DataField       =   "futuredate"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1440
         MaxLength       =   25
         TabIndex        =   28
         Tag             =   "Date"
         Top             =   600
         Width           =   945
      End
      Begin VB.TextBox txtFutPercentToHost 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         DataField       =   "futurepercent"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1440
         TabIndex        =   27
         Tag             =   "Number"
         Top             =   240
         Width           =   945
      End
      Begin VB.Label lblLabel2 
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
         Left            =   2370
         TabIndex        =   73
         Top             =   300
         Width           =   255
      End
      Begin VB.Label lblFutEffDate 
         Caption         =   "Effective Date:"
         Height          =   255
         Left            =   120
         TabIndex        =   72
         Top             =   600
         Width           =   1095
      End
      Begin VB.Label lblFutPercentToHost 
         Caption         =   "Percent To Host:"
         Height          =   255
         Left            =   120
         TabIndex        =   71
         Top             =   240
         Width           =   1215
      End
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
      Height          =   645
      Left            =   8760
      TabIndex        =   38
      Top             =   2835
      Width           =   1335
   End
   Begin VB.Data datDropListing 
      Appearance      =   0  'Flat
      Caption         =   "datDropListing"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   2790
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   8430
      Visible         =   0   'False
      Width           =   2295
   End
   Begin VB.Frame fraGenInfo 
      Caption         =   "General Information"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2415
      Left            =   30
      TabIndex        =   48
      Top             =   120
      Width           =   4215
      Begin VB.TextBox txtGrosRatePercent 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         DataField       =   "GrosRatePercent"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   3180
         TabIndex        =   6
         Tag             =   "Number"
         Top             =   2040
         Width           =   735
      End
      Begin VB.TextBox txtPercentToHost 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         DataField       =   "perdirect"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1560
         TabIndex        =   5
         Tag             =   "Number"
         Top             =   1680
         Width           =   735
      End
      Begin VB.TextBox txtCheckTo 
         Appearance      =   0  'Flat
         DataField       =   "check_to"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1560
         MaxLength       =   40
         TabIndex        =   4
         Tag             =   "Text"
         Top             =   1320
         Width           =   2535
      End
      Begin VB.TextBox txtOwnerName 
         Appearance      =   0  'Flat
         DataField       =   "fullname"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1560
         MaxLength       =   40
         TabIndex        =   3
         Tag             =   "Text"
         Top             =   960
         Width           =   2535
      End
      Begin VB.TextBox txtAccountNum 
         Appearance      =   0  'Flat
         DataField       =   "accountnum"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1560
         TabIndex        =   1
         Tag             =   "Number"
         Top             =   240
         Width           =   1455
      End
      Begin SSDataWidgets_B.SSDBCombo datdwComboPropName 
         Bindings        =   "PROPERTY.frx":0000
         DataField       =   "location"
         DataSource      =   "datBrowse"
         Height          =   315
         Left            =   1560
         TabIndex        =   2
         Tag             =   "Text"
         Top             =   570
         Width           =   2535
         DataFieldList   =   "location"
         ListAutoValidate=   0   'False
         MaxDropDownItems=   16
         BevelType       =   0
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
         BorderStyle     =   0
         ForeColorEven   =   0
         RowHeight       =   423
         Columns(0).Width=   3200
         _ExtentX        =   4471
         _ExtentY        =   556
         _StockProps     =   93
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
      End
      Begin VB.Label Label2 
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
         Height          =   195
         Left            =   3900
         TabIndex        =   80
         Top             =   2070
         Width           =   225
      End
      Begin VB.Label lblGrosRatePercent 
         Caption         =   "Percent of Gross Rate to Travel Agent:"
         Height          =   255
         Left            =   120
         TabIndex        =   79
         Top             =   2040
         Width           =   3045
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
         Left            =   2280
         TabIndex        =   65
         Top             =   1710
         Width           =   255
      End
      Begin VB.Label lblPercentToHost 
         Caption         =   "Percent To Host:"
         Height          =   255
         Left            =   120
         TabIndex        =   64
         Top             =   1680
         Width           =   1455
      End
      Begin VB.Label lblCheckPayableTo 
         Caption         =   "Check Payable To:"
         Height          =   255
         Left            =   120
         TabIndex        =   52
         Top             =   1320
         Width           =   1455
      End
      Begin VB.Label lblOwnerName 
         Caption         =   "Owner/Mngr Name:"
         Height          =   255
         Left            =   120
         TabIndex        =   51
         Top             =   960
         Width           =   1455
      End
      Begin VB.Label lblPropertyName 
         Caption         =   "Property Name:"
         Height          =   255
         Left            =   120
         TabIndex        =   50
         Top             =   570
         Width           =   1335
      End
      Begin VB.Label lblAccountNumber 
         Caption         =   "Account Number:"
         Height          =   255
         Left            =   120
         TabIndex        =   49
         Top             =   240
         Width           =   1335
      End
   End
   Begin VB.Frame fraOptions 
      Caption         =   "Options"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2085
      Left            =   4305
      TabIndex        =   47
      Top             =   5760
      Width           =   4335
      Begin VB.TextBox txtExceptions 
         Appearance      =   0  'Flat
         DataField       =   "exceptions_desc"
         DataSource      =   "datBrowse"
         Height          =   690
         Left            =   75
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   33
         Tag             =   "Text"
         Top             =   1305
         Width           =   4080
      End
      Begin Threed.SSCheck chkPropObsolete 
         DataField       =   "PropObsolete"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   2115
         TabIndex        =   30
         Top             =   240
         Width           =   2190
         _Version        =   65536
         _ExtentX        =   3863
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Property no longer booked"
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
      Begin Threed.SSCheck chkDepositReq 
         DataField       =   "depositreq"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   75
         TabIndex        =   31
         Top             =   525
         Width           =   1725
         _Version        =   65536
         _ExtentX        =   3043
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Deposit Required"
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
         DataField       =   "suppressflag"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   75
         TabIndex        =   29
         Top             =   240
         Width           =   1965
         _Version        =   65536
         _ExtentX        =   3466
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Suppress mailing labels"
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
      Begin Threed.SSCheck chkExceptions 
         DataField       =   "exceptions"
         DataSource      =   "datBrowse"
         Height          =   255
         Left            =   75
         TabIndex        =   32
         Top             =   810
         Width           =   4035
         _Version        =   65536
         _ExtentX        =   7117
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Display Exceptions warning when reserving property"
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
      Begin VB.Label Label1 
         Caption         =   "Special Circumstances/Exceptions Text:"
         Height          =   240
         Left            =   75
         TabIndex        =   83
         Top             =   1110
         Width           =   3105
      End
   End
   Begin VB.Frame fraTaxInfo 
      Caption         =   "Tax Information"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1635
      Left            =   4320
      TabIndex        =   46
      Top             =   2970
      Width           =   4335
      Begin VB.TextBox txtDBA 
         Appearance      =   0  'Flat
         DataField       =   "dba"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1440
         MaxLength       =   50
         TabIndex        =   25
         Tag             =   "Text"
         Top             =   600
         Width           =   2775
      End
      Begin VB.TextBox txtFederalTaxId 
         Appearance      =   0  'Flat
         DataField       =   "federaltaxid"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   1440
         MaxLength       =   50
         TabIndex        =   24
         Tag             =   "Text"
         Top             =   240
         Width           =   2775
      End
      Begin SSDataWidgets_B.SSDBCombo datdwComboTaxPlanCode 
         Bindings        =   "PROPERTY.frx":0019
         DataField       =   "tax_plan_code"
         DataSource      =   "datBrowse"
         Height          =   315
         Left            =   1440
         TabIndex        =   26
         Tag             =   "Text"
         Top             =   960
         Width           =   2775
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
         Columns(0).Width=   3200
         _ExtentX        =   4895
         _ExtentY        =   556
         _StockProps     =   93
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
      End
      Begin VB.Label lblTaxPlan 
         Caption         =   "Tax Plan:"
         Height          =   285
         Left            =   120
         TabIndex        =   75
         Top             =   960
         Width           =   1215
      End
      Begin VB.Label lblDBA 
         Caption         =   "DBA:"
         Height          =   255
         Left            =   120
         TabIndex        =   69
         Top             =   600
         Width           =   855
      End
      Begin VB.Label lblFederalTaxId 
         Caption         =   "Fed Tax Id/SS#:"
         Height          =   255
         Left            =   120
         TabIndex        =   68
         Top             =   240
         Width           =   1335
      End
   End
   Begin VB.Frame fraMailingAddress 
      Caption         =   "Property Owner/Mailing Information"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5265
      Left            =   30
      TabIndex        =   45
      Top             =   2565
      Width           =   4215
      Begin VB.TextBox txtWebURL 
         Appearance      =   0  'Flat
         DataField       =   "WebURL"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   960
         MaxLength       =   120
         TabIndex        =   15
         Tag             =   "Text"
         Top             =   3180
         Width           =   3000
      End
      Begin VB.TextBox txtEmail 
         Appearance      =   0  'Flat
         DataField       =   "Email"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   960
         MaxLength       =   120
         TabIndex        =   14
         Tag             =   "Text"
         Top             =   2820
         Width           =   3000
      End
      Begin VB.TextBox txtBlindComment 
         Appearance      =   0  'Flat
         DataField       =   "comments"
         DataSource      =   "datBrowse"
         Height          =   1410
         Left            =   120
         MaxLength       =   500
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   16
         Tag             =   "Text"
         Top             =   3765
         Width           =   3975
      End
      Begin VB.TextBox txtMailFax 
         Appearance      =   0  'Flat
         DataField       =   "mailfax"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   960
         MaxLength       =   30
         TabIndex        =   13
         Tag             =   "Text"
         Top             =   2460
         Width           =   2055
      End
      Begin VB.TextBox txtMailPhone2 
         Appearance      =   0  'Flat
         DataField       =   "mailphone2"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   960
         MaxLength       =   30
         TabIndex        =   12
         Tag             =   "Text"
         Top             =   2100
         Width           =   2055
      End
      Begin VB.TextBox txtMailPhone1 
         Appearance      =   0  'Flat
         DataField       =   "mailphone1"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   960
         MaxLength       =   30
         TabIndex        =   11
         Tag             =   "Text"
         Top             =   1740
         Width           =   2055
      End
      Begin VB.TextBox txtMailZipcode 
         Appearance      =   0  'Flat
         DataField       =   "mailzipcode"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   960
         MaxLength       =   25
         TabIndex        =   10
         Tag             =   "Text"
         Top             =   1380
         Width           =   2055
      End
      Begin VB.TextBox txtMailState 
         Appearance      =   0  'Flat
         DataField       =   "mailstate"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   960
         MaxLength       =   25
         TabIndex        =   9
         Tag             =   "Text"
         Top             =   1020
         Width           =   2055
      End
      Begin VB.TextBox txtMailCity 
         Appearance      =   0  'Flat
         DataField       =   "mailcity"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   960
         MaxLength       =   30
         TabIndex        =   8
         Tag             =   "Text"
         Top             =   660
         Width           =   3135
      End
      Begin VB.TextBox txtMailAddress 
         Appearance      =   0  'Flat
         DataField       =   "mailaddress"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   960
         MaxLength       =   40
         TabIndex        =   7
         Tag             =   "Text"
         Top             =   300
         Width           =   3135
      End
      Begin VB.Label Label5 
         Caption         =   "Web URL:"
         Height          =   255
         Left            =   120
         TabIndex        =   82
         Top             =   3195
         Width           =   810
      End
      Begin VB.Label Label4 
         Caption         =   "Email:"
         Height          =   255
         Left            =   120
         TabIndex        =   81
         Top             =   2820
         Width           =   735
      End
      Begin VB.Label lblBlindComment 
         Caption         =   "Blind Comment:"
         Height          =   195
         Left            =   105
         TabIndex        =   74
         Top             =   3585
         Width           =   1335
      End
      Begin VB.Label lblMailFax 
         Caption         =   "Fax:"
         Height          =   255
         Left            =   120
         TabIndex        =   63
         Top             =   2460
         Width           =   735
      End
      Begin VB.Label lblMailPhone2 
         Caption         =   "Phone #2:"
         Height          =   255
         Left            =   120
         TabIndex        =   62
         Top             =   2100
         Width           =   855
      End
      Begin VB.Label lblMailPhone1 
         Caption         =   "Phone #1:"
         Height          =   255
         Left            =   120
         TabIndex        =   61
         Top             =   1740
         Width           =   855
      End
      Begin VB.Label lblMailZipCode 
         Caption         =   "Zipcode:"
         Height          =   255
         Left            =   120
         TabIndex        =   56
         Top             =   1380
         Width           =   735
      End
      Begin VB.Label lblMailState 
         Caption         =   "State:"
         Height          =   255
         Left            =   120
         TabIndex        =   55
         Top             =   1020
         Width           =   855
      End
      Begin VB.Label lblMailCity 
         Caption         =   "City:"
         Height          =   255
         Left            =   120
         TabIndex        =   54
         Top             =   660
         Width           =   855
      End
      Begin VB.Label lblMailAddress 
         Caption         =   "Address:"
         Height          =   255
         Left            =   120
         TabIndex        =   53
         Top             =   300
         Width           =   855
      End
   End
   Begin VB.Frame fraPropertyAddress 
      Caption         =   "Property Information"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2775
      Left            =   4320
      TabIndex        =   44
      Top             =   120
      Width           =   4335
      Begin VB.TextBox txtFindSQL 
         Appearance      =   0  'Flat
         Height          =   315
         Left            =   3330
         TabIndex        =   76
         Tag             =   "Text"
         Top             =   1830
         Visible         =   0   'False
         Width           =   885
      End
      Begin VB.TextBox txtPropFax 
         Appearance      =   0  'Flat
         DataField       =   "propfax"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   840
         TabIndex        =   22
         Tag             =   "Text"
         Top             =   2130
         Width           =   2055
      End
      Begin VB.OptionButton optSameAsMailing 
         Caption         =   "Same as Property Owner/Mailing address"
         Height          =   255
         Left            =   120
         TabIndex        =   23
         TabStop         =   0   'False
         Top             =   2490
         Width           =   4065
      End
      Begin VB.TextBox txtPropPhone 
         Appearance      =   0  'Flat
         DataField       =   "propphone"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   840
         MaxLength       =   40
         TabIndex        =   21
         Tag             =   "Text"
         Top             =   1770
         Width           =   2055
      End
      Begin VB.TextBox txtPropZipcode 
         Appearance      =   0  'Flat
         DataField       =   "propzipcode"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   840
         MaxLength       =   25
         TabIndex        =   20
         Tag             =   "Text"
         Top             =   1410
         Width           =   2055
      End
      Begin VB.TextBox txtPropState 
         Appearance      =   0  'Flat
         DataField       =   "propstate"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   840
         MaxLength       =   25
         TabIndex        =   19
         Tag             =   "Text"
         Top             =   1050
         Width           =   2055
      End
      Begin VB.TextBox txtPropCity 
         Appearance      =   0  'Flat
         DataField       =   "propcity"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   840
         MaxLength       =   30
         TabIndex        =   18
         Tag             =   "Text"
         Top             =   690
         Width           =   2775
      End
      Begin VB.TextBox txtPropAddress 
         Appearance      =   0  'Flat
         DataField       =   "propaddress"
         DataSource      =   "datBrowse"
         Height          =   285
         Left            =   840
         MaxLength       =   40
         TabIndex        =   17
         Tag             =   "Text"
         Top             =   330
         Width           =   2775
      End
      Begin VB.Label lblPropFax 
         Caption         =   "Fax:"
         Height          =   255
         Left            =   120
         TabIndex        =   67
         Top             =   2130
         Width           =   735
      End
      Begin VB.Label lblPropPhone 
         Caption         =   "Phone:"
         Height          =   255
         Left            =   120
         TabIndex        =   66
         Top             =   1770
         Width           =   735
      End
      Begin VB.Label lblPropZipcode 
         Caption         =   "Zipcode:"
         Height          =   255
         Left            =   120
         TabIndex        =   60
         Top             =   1410
         Width           =   735
      End
      Begin VB.Label lblPropState 
         Caption         =   "State:"
         Height          =   255
         Left            =   120
         TabIndex        =   59
         Top             =   1050
         Width           =   735
      End
      Begin VB.Label lblPropCity 
         Caption         =   "City:"
         Height          =   255
         Left            =   120
         TabIndex        =   58
         Top             =   690
         Width           =   735
      End
      Begin VB.Label lblPropAddress 
         Caption         =   "Address:"
         Height          =   255
         Left            =   120
         TabIndex        =   57
         Top             =   330
         Width           =   735
      End
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
      Height          =   645
      Left            =   8760
      TabIndex        =   43
      Top             =   7590
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
      Height          =   645
      Left            =   8760
      TabIndex        =   40
      Top             =   5535
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
      Height          =   645
      Left            =   8760
      TabIndex        =   39
      Top             =   3510
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
      Height          =   645
      Left            =   8760
      TabIndex        =   37
      Top             =   2175
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
      Height          =   645
      Left            =   8760
      TabIndex        =   36
      Top             =   1515
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
      Height          =   645
      Left            =   8760
      TabIndex        =   35
      Top             =   840
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
      Height          =   645
      Left            =   8760
      TabIndex        =   42
      Top             =   6915
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
      Height          =   315
      Left            =   810
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   8430
      Visible         =   0   'False
      Width           =   2055
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
      Height          =   645
      Left            =   8760
      TabIndex        =   34
      Top             =   165
      Width           =   1335
   End
   Begin SSDataWidgets_A.SSDBData datdwData1 
      Bindings        =   "PROPERTY.frx":002E
      Height          =   330
      Left            =   30
      TabIndex        =   0
      Top             =   7905
      Width           =   8625
      _Version        =   131075
      _ExtentX        =   15214
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
End
Attribute VB_Name = "frmProperty"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
'CurrRec holds the number of the current record displayed on the screen
Dim CurrRec As Long
Dim SaveRec As Long
Dim v_AccountNum As Long
Dim SetFocusTo As String
Dim OrigPropName As String
Dim OrigPropCity As String
Dim OrigPropState As String
Dim OrigPropZipcode As String


Private Sub cmdCancel_Click()

   On Error GoTo cmdCancel_Click_Error
   
   optSameAsMailing.Caption = "Same as Property Owner/Mailing address"
   Select Case GetFormMode(Me)
     Case "Insert"
        If datBrowse.Recordset.EditMode = dbEditAdd Then datBrowse.Recordset.CancelUpdate
        'MsgBox Str$(v_AccountNum)
        gBNB.Execute "delete * from HostInsertControl where accountnum = " & v_AccountNum & " and ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
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
     txtAccountNum.SetFocus
   End If
   
cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
  MsgBox Err.Description
  Resume cmdCancel_Click_Resume

End Sub


Private Sub cmdCommit_Click()
    
    On Error GoTo cmdCommit_Click_Error
    
    Dim TempVal As Variant 'Used when controls are unbound
    Dim TempSS As Recordset
    
    Screen.MousePointer = HOURGLASS
        
    optSameAsMailing.Caption = "Same as Property Owner/Mailing address"
    
    Select Case GetFormMode(Me)
      Case "Insert"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmProperty
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
        'Warn if actual property location (not mailing address) is not filled in.
        If Trim(txtPropCity.Text) = "" Then
           gMsg = "It is suggested that at least the 'City' field be filled " & _
                  "in under the 'Property Information' section. This " & _
                  "field is printed on the guest's Confirmation report as the " & _
                  "city or town of the host property at which they will be residing. " & _
                  "Would you like to enter this field now?"
           If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON1, Me.Caption) = IDYES Then
              txtPropCity.SetFocus
              GoTo cmdCommit_Click_Resume
           End If
        End If
        SetToCurrencyFormat Me
        'Check if any Date, Currency or Number fields were set to blank (0
        'length string); if so, unbind control's DataField property and commit Null.
        TempVal = Trim$(txtAccountNum.Text)
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        datBrowse.RecordSource = "select * from " & Me.Tag & " where AccountNum = " & CLng(TempVal)
        If Not GetDCRows(datBrowse) Then GoTo cmdCommit_Click_Resume
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        'If successful update, update the HostInsertControl table
        gBNB.Execute "delete * from HostInsertControl where AccountNum = " & CLng(TempVal)
        'If Not datBrowse.Recordset.EOF And Not datBrowse.Recordset.BOF Then datBrowse.Recordset.MoveLast
        SetToCurrencyFormat Me
      Case "Update"
        If Not VerifyUpdate() Then
           MsgBox gMsg, MB_ICONSTOP, Me.Caption
           GoTo cmdCommit_Click_Resume
        End If
        'Check for specifics of frmProperty
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
        'Warn if actual property location (not mailing address) is not filled in.
        If Trim(txtPropCity.Text) = "" Then
           gMsg = "It is suggested that at least the 'City' field be filled " & _
                  "in under the 'Property Information' section. This " & _
                  "field is printed on the guest's Confirmation report as the " & _
                  "city or town of the host property at which they will be residing. " & _
                  "Would you like to enter this field now?"
           If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON1, Me.Caption) = IDYES Then
              txtPropCity.SetFocus
              GoTo cmdCommit_Click_Resume
           End If
        End If
        SetToCurrencyFormat Me
        'Check if any Date, Currency or Number fields were set to blank (0 length string); if so,
        'unbind control's DataField property and commit Null.
        RetVal = UnbindNullDateControl(Me, datBrowse, NullDateArray)
        datBrowse.Recordset.Update
        'Do if there was at least one Date or Number set to null
        If RetVal Then BindNullDateControl Me, NullDateArray
        'Make the current record current again
        datBrowse.UpdateControls
        SetToCurrencyFormat Me
      Case "Delete"
        'Cannot delete if Property AccountNum exists in Guest Accomodations (bbtbl).
        gSQL = "SELECT COUNT(AccountNum) FROM bbtbl WHERE AccountNum = " & txtAccountNum.Text
        Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
        GetSSRows TempSS
        If TempSS(0) > 0 And Not IsNull(TempSS(0)) Then
           MsgBox "This property is currently linked to guest reservations and cannot be deleted.", MB_ICONSTOP, Me.Caption
           TempSS.Close
           GoTo cmdCommit_Click_Resume
        End If
        TempSS.Close
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
    gCaption = "Host Account Listing"
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

Private Sub cmdFactSheet_Click()

   Screen.MousePointer = HOURGLASS
   If frmPropertyFacts.WindowState = MINIMIZED Then
      Dim X&
      frmPropertyFacts.SetFocus
      X& = ShowWindow(frmPropertyFacts.hwnd, SW_SHOWNORMAL)
   Else
      frmPropertyFacts.Show
      frmPropertyFacts.SetFocus
   End If
   Screen.MousePointer = DEFAULT

End Sub

Private Sub cmdFind_Click()
   
   On Error GoTo cmdFind_Click_Error
   Screen.MousePointer = HOURGLASS
   Dim Criteria As String
   If cmdFind.Caption = "&Find" Then
      SetFormToFindMode Me
      cmdFactSheet.Enabled = False
      cmdRoomType.Enabled = False
      cmdFind.Caption = "&Run Query"
   Else
      cmdFind.Caption = "&Find"
      Criteria = BuildFindCriteria(Me, "location")
      If Criteria <> "" Then
         datBrowse.UpdateControls
         datBrowse.RecordSource = Criteria
         If Not GetDCRows(datBrowse) Then GoTo cmdFind_Click_Resume
         If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
            SetFormToNoRowsMode Me
         Else
            SetFormToBrowseMode Me
            cmdFactSheet.Enabled = True
            cmdRoomType.Enabled = True
            CurrRec = GetCurrentRowNumber(datBrowse)
            datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
         End If
      Else
         SetFormToNoRowsMode Me
      End If
   End If
   txtAccountNum.SetFocus

cmdFind_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
    
cmdFind_Click_Error:
   Resume cmdFind_Click_Resume

End Sub

Private Sub cmdInsert_Click()

    On Error GoTo cmdInsert_Click_Error
    
    Screen.MousePointer = HOURGLASS
    SetFormToInsertMode Me
    optSameAsMailing.TabStop = False
    optSameAsMailing.Caption = "Same as Property Owner/Mailing address"
    If Trim(datBrowse.RecordSource) = "" Then
       datBrowse.RecordSource = "select * from " & Me.Tag & " order by PropObsolete desc,location"
       If Not GetDCRows(datBrowse) Then Exit Sub
    End If
    datBrowse.Recordset.AddNew
    SetZeroLengthString Me
      
    'Control for Multi-user inserts.
    'Use a accountnum control table containing all attempted row inserts.
    'Get next accountnum
    Dim MaxRS As Recordset  'Maximum accountnum from actual data table (proptbl)
    Dim ControlRS As Recordset  'accountnum numbers from HostInsertControl table.
    Dim MaxAccountNumPlusOne As Long
    Dim MinControlRS As Long
    txtAccountNum.Locked = True
    txtAccountNum.ForeColor = BLACK
    'Get highest accountnum from proptbl and put it in MaxRS.
    'The following line is for testing when no rows in proptbl yet.
    'Set MaxRS = gBNB.OpenRecordset("select accountnum from " & Me.Tag & " where accountnum in(select max(accountnum) from " & Me.Tag & " where accountnum = 0)", dbOpenSnapshot)
    Set MaxRS = gBNB.OpenRecordset("select accountnum from " & Me.Tag & " where accountnum in(select max(alias_1.accountnum) from " & Me.Tag & " AS alias_1)", dbOpenSnapshot)
    GetSSRows MaxRS
    'The ONLY purpose of the HostInsertControl table is to get new rows into proptbl.
    'Any accountnum numbers already in proptbl have no reason to be in the HostInsertControl table.
    'This case could happen due to a power outage (or other abnormal termination) AFTER
    'insert of accountnum into proptbl but BEFORE that accountnum's removal from
    'HostInsertControl table. As such, remove invalid rows from HostInsertControl to prevent any
    'possible buildup of old accountnum numbers in HostInsertControl. Removed accountnum will never
    'be used in the database.
    If Not MaxRS.EOF Then gBNB.Execute "delete from HostInsertControl where accountnum < " & (MaxRS(0) + 1)
    'Get all accountnum numbers currently in HostInsertControl table.
    Set ControlRS = gBNB.OpenRecordset("select accountnum,ComputerName from HostInsertControl order by accountnum ASC", dbOpenDynaset)
    'Make SURE we're at beginning.
    GetSSRows ControlRS
    If Not ControlRS.BOF And Not ControlRS.EOF Then
       MinControlRS = ControlRS("accountnum")
    Else  'No rows in HostInsertControl table.
       MinControlRS = 0
    End If
    If MaxRS.BOF And MaxRS.EOF Then  'No rows exist in proptbl yet.
       'MsgBox "Null"
       MaxAccountNumPlusOne = 1
    Else
       MaxAccountNumPlusOne = (MaxRS("accountnum") + 1)
    End If
    MaxRS.Close
    If (ControlRS.BOF And ControlRS.EOF) Then  'No rows in HostInsertControl table.
       GoSub Insert_Control
    ElseIf MaxAccountNumPlusOne < MinControlRS Then  'accountnum to be inserted is less than all rows in HostInsertControl.
       GoSub Insert_Control
    ElseIf MaxAccountNumPlusOne >= MinControlRS Then
       'Equal or greater. Move through recordset to find next available
       'accountnum to insert.
       Dim Done As Integer
       Done = False
       For i = 0 To ControlRS.RecordCount - 1
          If MaxAccountNumPlusOne < (ControlRS("accountnum") - i) Then
            v_AccountNum = (MaxAccountNumPlusOne + i)
            ControlRS.AddNew
            ControlRS("accountnum") = (MaxAccountNumPlusOne + i)
            ControlRS("ComputerName") = gComputerName
            ControlRS.Update
            'v_AccountNum = (MaxAccountNumPlusOne + i)
            Done = True
            Exit For
          End If
          ControlRS.MoveNext
       Next i
       'accountnum to be inserted into HostInsertControl table will be
       'greater than any of those already existing in the table.
       If Not Done Then
          v_AccountNum = (MaxAccountNumPlusOne + i)
          ControlRS.AddNew
          ControlRS("accountnum") = (MaxAccountNumPlusOne + i)
          ControlRS("ComputerName") = gComputerName
          ControlRS.Update
          'v_AccountNum = (MaxAccountNumPlusOne + i)
       End If
    Else
       'All cases have been accounted for.
    End If
    ControlRS.Close
    txtAccountNum.Text = Trim$(v_AccountNum)
    txtAccountNum.Locked = True
    txtAccountNum.ForeColor = BLACK
    datdwComboPropName.SetFocus
    'txtDateBooked.Text = Format$(Now, "m/d/yyyy")
    
cmdInsert_Click_Resume:
    Screen.MousePointer = DEFAULT
    Exit Sub
    
Insert_Control:
      v_AccountNum = MaxAccountNumPlusOne
      ControlRS.AddNew
      ControlRS("AccountNum") = MaxAccountNumPlusOne
      ControlRS("ComputerName") = gComputerName
      'v_AccountNum = MaxAccountNumPlusOne
      ControlRS.Update
      Return
      
cmdInsert_Click_Error:
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
   gSQL = "select " & Chr$(34) & gComputerName & Chr$(34) & ",'',fullname,location,mailaddress,mailcity,mailstate,mailzipcode "
   'Remove * from query and just get rows of interest
   txtFindSQL.Text = Replace_All_In_With("select * ", txtFindSQL.Text, gSQL)
   'Remove Order By clause
   If InStr(1, txtFindSQL.Text, "Order By", 1) > 0 Then
      txtFindSQL.Text = Left(txtFindSQL.Text, InStr(1, txtFindSQL.Text, "Order By", 1) - 1)
   End If
   'Append more criteria to prevent non-mailable and Suppressed labels from being printed
   If InStr(1, txtFindSQL.Text, "where", 1) > 0 Then
      txtFindSQL.Text = txtFindSQL.Text & " And mailaddress <> '' And suppressflag <> -1 And suppressflag <> 1 "
   Else
      txtFindSQL.Text = txtFindSQL.Text & " Where mailaddress <> '' And suppressflag <> -1 And suppressflag <> 1 "
   End If

   LabelCallingForm = "frmProperty"
   frmLabelDialog.Show 1
   DoEvents
   If Not FormLoaded(frmLabelDialog) Then Exit Sub
   Screen.MousePointer = HOURGLASS
   Dim i As Integer
   'Clear out temp table
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
                "','" & _
                datBrowse.Recordset("fullname") & "','" & _
                datBrowse.Recordset("location") & "','" & _
                datBrowse.Recordset("mailaddress") & "','" & _
                datBrowse.Recordset("mailcity") & "','" & _
                datBrowse.Recordset("mailstate") & "','" & _
                datBrowse.Recordset("mailzipcode") & "'"
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
   mdiBNB.Report1.SelectionFormula = "{LabelSupport.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(mdiBNB.Report1.SortFields(vCount)) <> ""
     mdiBNB.Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   For i = 0 To frmLabelDialog.lstSortOrder.ListCount - 1
      Select Case frmLabelDialog.lstSortOrder.List(i)
        Case "Manager Name"
           mdiBNB.Report1.SortFields(i) = "+{LabelSupport.l_name}"
        Case "Property Name"
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
   'Clear out temp table
   gBNB.Execute "delete from LabelSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   
cmdLabels_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdLabels_Click_Error:
   Resume cmdLabels_Click_Resume
   
End Sub

Private Sub cmdRefresh_Click()

   Screen.MousePointer = HOURGLASS
   datBrowse.RecordSource = "select * from " & Me.Tag & " order by PropObsolete desc,location"
   If Not GetDCRows(datBrowse) Then Exit Sub
   If datBrowse.Recordset.EOF And datBrowse.Recordset.BOF Then
      SetFormToNoRowsMode Me
   Else
      SetFormToBrowseMode Me
      CurrRec = GetCurrentRowNumber(datBrowse)
      datdwData1.Caption = "Row " & CurrRec & " of " & datBrowse.Recordset.RecordCount
   End If
   Screen.MousePointer = DEFAULT

End Sub

Private Sub cmdRoomType_Click()

frmRoomType.Show 1 'make it modal instead

'   Screen.MousePointer = HOURGLASS
'   If frmRoomType.WindowState = MINIMIZED Then
'      Dim X&
'      frmRoomType.SetFocus
'      X& = ShowWindow(frmRoomType.hwnd, SW_SHOWNORMAL)
'   Else
'      frmRoomType.Show
'      frmRoomType.SetFocus
'   End If
'   Screen.MousePointer = DEFAULT
      
End Sub

Private Sub cmdUpdate_Click()

   On Error GoTo cmdUpdate_Click_Error
   
   OrigPropName = datdwComboPropName.Text
   OrigPropCity = txtPropCity.Text
   OrigPropState = txtPropState.Text
   OrigPropZipcode = txtPropZipcode.Text
   SetFormToUpdateMode Me
   optSameAsMailing.Caption = "Same as Property Owner/Mailing address"
   optSameAsMailing.TabStop = False
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
End Sub

Private Sub datdwComboPropName_CloseUp()

   cmdFind.DEFAULT = True
   
End Sub

Private Sub datdwComboPropName_DropDown()

   On Error GoTo DropDown_Error

   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        datdwComboPropName.DataFieldList = ""
        Exit Sub
     Case Else
        datdwComboPropName.DefColWidth = datdwComboPropName.Width * 1.5
        datdwComboPropName.DataFieldList = "location"
   End Select
   
   'datDropListing.DatabaseName = gDatabaseName
   datDropListing.RecordSource = "select location from " & Me.Tag & " order by location"
   If Not GetDCRows(datDropListing) Then Exit Sub
   cmdFind.DEFAULT = False

DropDown_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

DropDown_Error:
   Resume DropDown_Resume
   
End Sub

Private Sub datdwComboPropName_KeyPress(KeyAscii As Integer)
   
   If UCase(GetFormMode(Me)) = "FIND" Or UCase(GetFormMode(Me)) = "INSERT" Or UCase(GetFormMode(Me)) = "UPDATE" Then

   Else
      KeyAscii = False
   End If

End Sub


Private Sub datdwComboTaxPlanCode_CloseUp()

   cmdFind.DEFAULT = True
   
End Sub

Private Sub datdwComboTaxPlanCode_DropDown()

   On Error GoTo DropDown_Error
   
   Select Case GetFormMode(Me)
     Case "Browse", "No Rows", "Delete"
        datdwComboTaxPlanCode.DataFieldList = ""
        Exit Sub
     Case Else
        datdwComboTaxPlanCode.DefColWidth = datdwComboTaxPlanCode.Width
        datdwComboTaxPlanCode.DataFieldList = "plancode"
   End Select
   
   'datDropListing.DatabaseName = gDatabaseName
   datTaxList.RecordSource = "select plan_title, plancode from taxplan order by plan_title"
   If Not GetDCRows(datTaxList) Then Exit Sub
   cmdFind.DEFAULT = False

DropDown_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

DropDown_Error:
   Resume DropDown_Resume

End Sub

Private Sub datdwComboTaxPlanCode_KeyPress(KeyAscii As Integer)
   
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

If TimesActivated < 1 Then
   Screen.MousePointer = HOURGLASS
   TimesActivated = TimesActivated + 1
   gDropSource = ""
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
   txtAccountNum.SetFocus
   Exit Sub

Form_Activate_Error:
   Resume Form_Activate_Resume
  
End Sub

Private Sub Form_Load()
   
   On Error GoTo Load_Error
   
   TimesActivated = 0
   
   datBrowse.DatabaseName = gDatabaseName
   datBrowse.RecordSource = "select * from " & Me.Tag & " order by PropObsolete desc,location"
   
   datDropListing.DatabaseName = gDatabaseName
   datDropListing.RecordSource = ""

   datTaxList.DatabaseName = gDatabaseName
   datTaxList.RecordSource = ""
   
   'datBrowse.Refresh
   CurrRec = 1
   SaveRec = 0

Load_Resume:
   Exit Sub

Load_Error:
   Resume Load_Resume
   
End Sub


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
         gBNB.Execute "delete * from " & Me.Tag & " where accountnum = " & v_AccountNum
         'Remove insert attempt from GuestInsertControl table.
         gBNB.Execute "delete * from GuestInsertControl where accountnum = " & v_AccountNum
     Case "Update"
         'The above is true also for updates.
         If datBrowse.Recordset.EditMode = dbEditInProgress Then datBrowse.Recordset.CancelUpdate
     Case Else
   End Select
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

Private Sub Form_Unload(Cancel As Integer)

  If FormLoaded(frmPropertyFacts) Then
     If UCase(GetFormMode(frmPropertyFacts)) = "INSERT" Or UCase(GetFormMode(frmPropertyFacts)) = "UPDATE" Then
        gMsg = "Cancel pending Insert or Update of Property Facts before exiting."
        MsgBox gMsg, MB_ICONSTOP, Me.Caption
        Cancel = True
        If frmPropertyFacts.WindowState = MINIMIZED Then
           Dim X&
           frmPropertyFacts.SetFocus
           X& = ShowWindow(frmPropertyFacts.hwnd, SW_SHOWNORMAL)
        Else
           frmPropertyFacts.Show
           frmPropertyFacts.SetFocus
        End If
     Else
        Unload frmPropertyFacts
     End If
  End If
  DoEvents
  
End Sub

Private Sub optSameAsMailing_Click()
        
   If optSameAsMailing.Caption = "Same as Property Owner/Mailing address" Then
      If txtMailAddress.Text <> "" Then txtPropAddress.Text = txtMailAddress.Text
      If txtMailCity.Text <> "" Then txtPropCity.Text = txtMailCity.Text
      If txtMailState.Text <> "" Then txtPropState.Text = txtMailState.Text
      If txtMailZipcode.Text <> "" Then txtPropZipcode.Text = txtMailZipcode.Text
      optSameAsMailing.Caption = "Clear Property Address Information"
      GoTo optSameAsMailing_Click_Resume
   Else
      txtPropAddress.Text = ""
      txtPropCity.Text = ""
      txtPropState.Text = ""
      txtPropZipcode.Text = ""
      optSameAsMailing.Caption = "Same as Property Owner/Mailing address"
      GoTo optSameAsMailing_Click_Resume
   End If

optSameAsMailing_Click_Resume:
    optSameAsMailing.Value = False
    

End Sub



Public Function InsertTrigger() As Integer

  On Error GoTo InsertTrigger_Error
  
  Dim SSTemp As Recordset
  
  InsertTrigger = True
  SetFocusTo = ""
  
  'Account num cannot be blank
  If txtAccountNum.Text = "0" Or txtAccountNum.Text = "" Then
     gMsg = "Account number cannot be zero or blank."
     SetFocusTo = "txtAccountNum"
     InsertTrigger = False
     Exit Function
  End If
  'Property name must be filled in.
  If Trim(datdwComboPropName.Text) = "" Then
     gMsg = "Property Name must be entered."
     InsertTrigger = False
     SetFocusTo = "datdwComboPropName"
     Exit Function
  End If
  'Property name must not be too similar to others (since property name can contain
  'apostrophe,insert trigger property check in frmAccom needs to return a UNIQUE property name)
  'If datdwComboPropName.Text Like "*[']*" Then
  '   Set SSTemp = gBNB.OpenRecordset("select location from proptbl where location like '" & Replace_All_In_With("'", datdwComboPropName.Text, "*") & "'", dbOpenSnapshot)
  'Else
     Set SSTemp = gBNB.OpenRecordset("select location,accountnum from proptbl where location = " & Chr$(34) & datdwComboPropName.Text & Chr$(34), dbOpenSnapshot)
  'End If
  GetSSRows SSTemp
  If SSTemp.RecordCount > 0 Then
     gMsg = "This property name is already assigned to property account number " & SSTemp(1) & ". Change the property name to make it more distinct."
     InsertTrigger = False
     SetFocusTo = "datdwComboPropName"
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close
  ''Check Payable To' must be filled in.
  If Trim(txtCheckTo.Text) = "" Then
     gMsg = "'Check Payable To' must be entered."
     InsertTrigger = False
     SetFocusTo = "txtCheckTo"
     Exit Function
  End If
  'Percentage to Host must be filled in
  If txtPercentToHost.Text = "" Then
     gMsg = "Percentage To Host must be filled in."
     InsertTrigger = False
     SetFocusTo = "txtPercentToHost"
     Exit Function
  ElseIf Not IsNumeric(txtPercentToHost.Text) Then
     gMsg = "Percentage To Host must be numeric between 0 and 100."
     InsertTrigger = False
     SetFocusTo = "txtPercentToHost"
     Exit Function
  ElseIf Not (CDbl(txtPercentToHost.Text) >= 0 And CDbl(txtPercentToHost.Text) <= 100) Then
     gMsg = "Percentage To Host must be numeric between 0 and 100."
     InsertTrigger = False
     SetFocusTo = "txtPercentToHost"
     Exit Function
  End If
  'Commissionable Percentage of Daily Gross Rate must be filled in
  If txtGrosRatePercent.Text = "" Then
     gMsg = "Commissionable Percent of Daily Rate must be filled in."
     InsertTrigger = False
     SetFocusTo = "txtGrosRatePercent"
     Exit Function
  ElseIf Not IsNumeric(txtGrosRatePercent.Text) Then
     gMsg = "Commissionable Percent of Daily Rate must be numeric between 0 and 100."
     InsertTrigger = False
     SetFocusTo = "txtGrosRatePercent"
     Exit Function
  ElseIf Not (CDbl(txtGrosRatePercent.Text) >= 0 And CDbl(txtGrosRatePercent.Text) <= 100) Then
     gMsg = "Commissionable Percent of Daily Rate must be numeric between 0 and 100."
     InsertTrigger = False
     SetFocusTo = "txtGrosRatePercent"
     Exit Function
  End If
  'Tax plan code must be entered and must exist in taxplan table.
  datdwComboTaxPlanCode.Text = Trim(datdwComboTaxPlanCode.Text)
  Set SSTemp = gBNB.OpenRecordset("select plancode from taxplan where plancode = '" & datdwComboTaxPlanCode.Text & "'", dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Tax Plan Code does not exist in Tax Plans. Select a Tax Plan from the dropdown list."
     InsertTrigger = False
     SetFocusTo = "datdwComboTaxPlanCode"
     SSTemp.Close
     Exit Function
  End If
  SSTemp.Close
  'Future Percentage to Host has been entered...
  If txtFutPercentToHost.Text <> "" Then
     If Not IsNumeric(txtFutPercentToHost.Text) Then
        gMsg = "Future Percentage To Host must be numeric between 0 and 100."
        InsertTrigger = False
        SetFocusTo = "txtFutPercentToHost"
        Exit Function
     ElseIf Not (CDbl(txtFutPercentToHost.Text) >= 0 And CDbl(txtFutPercentToHost.Text) <= 100) Then
        gMsg = "Future Percentage To Host must be numeric between 0 and 100."
        InsertTrigger = False
        SetFocusTo = "txtFutPercentToHost"
        Exit Function
     ElseIf txtFutEffDate.Text = "" Then
        gMsg = "Future Effective Date must be entered if a Future Percentage To Host is specified."
        InsertTrigger = False
        SetFocusTo = "txtFutEffDate"
        Exit Function
     End If
  End If
  'Future percentage cannot be blank if Effective date is filled in.
  If txtFutEffDate.Text <> "" And txtFutPercentToHost.Text = "" Then
        gMsg = "Future Percentage To Host must be entered if a Future Effective Date is specified."
        InsertTrigger = False
        SetFocusTo = "txtFutPercentToHost"
        Exit Function
  End If

InsertTrigger_Resume:
   Exit Function
   
InsertTrigger_Error:
   Resume InsertTrigger_Resume
    
End Function

Public Function UpdateTrigger() As Integer

  On Error GoTo UpdateTrigger_Error
  
  UpdateTrigger = True
  
  Screen.MousePointer = HOURGLASS
  
  datdwComboPropName.Text = Trim(datdwComboPropName.Text)
  'Property name must be filled in.
  If datdwComboPropName.Text = "" Then
     gMsg = "Property Name must be entered."
     UpdateTrigger = False
     SetFocusTo = "datdwComboPropName"
     GoTo UpdateTrigger_Resume
  End If
  'Tax plan code must be entered and must exist in taxplan table.
  datdwComboTaxPlanCode.Text = Trim(datdwComboTaxPlanCode.Text)
  Dim SSTemp As Recordset
  Set SSTemp = gBNB.OpenRecordset("select plancode from taxplan where plancode = '" & datdwComboTaxPlanCode.Text & "'", dbOpenSnapshot)
  GetSSRows SSTemp
  If SSTemp.RecordCount = 0 Then
     gMsg = "Tax Plan Code does not exist in Tax Plans. Select a Tax Plan from the dropdown list."
     UpdateTrigger = False
     SetFocusTo = "datdwComboTaxPlanCode"
     SSTemp.Close
     GoTo UpdateTrigger_Resume
  End If
  SSTemp.Close
  ''Check Payable To' must be filled in.
  If Trim(txtCheckTo.Text) = "" Then
     gMsg = "'Check Payable To' must be entered."
     UpdateTrigger = False
     SetFocusTo = "txtCheckTo"
     GoTo UpdateTrigger_Resume
  End If
  'Percentage to Host must be filled in
  If txtPercentToHost.Text = "" Then
     gMsg = "Percent To Host must be filled in."
     UpdateTrigger = False
     SetFocusTo = "txtPercentToHost"
     GoTo UpdateTrigger_Resume
  ElseIf Not IsNumeric(txtPercentToHost.Text) Then
     gMsg = "Percent To Host must be numeric between 0 and 100."
     UpdateTrigger = False
     SetFocusTo = "txtPercentToHost"
     GoTo UpdateTrigger_Resume
  ElseIf Not (CDbl(txtPercentToHost.Text) >= 0 And CDbl(txtPercentToHost.Text) <= 100) Then
     gMsg = "Percent To Host must be numeric between 0 and 100."
     UpdateTrigger = False
     SetFocusTo = "txtPercentToHost"
     GoTo UpdateTrigger_Resume
  End If
  'Commissionable Percentage of Daily Gross Rate must be filled in
  If txtGrosRatePercent.Text = "" Then
     gMsg = "Commissionable Percent of Daily Rate must be filled in."
     UpdateTrigger = False
     SetFocusTo = "txtGrosRatePercent"
     Exit Function
  ElseIf Not IsNumeric(txtGrosRatePercent.Text) Then
     gMsg = "Commissionable Percent of Daily Rate must be numeric between 0 and 100."
     UpdateTrigger = False
     SetFocusTo = "txtGrosRatePercent"
     Exit Function
  ElseIf Not (CDbl(txtGrosRatePercent.Text) >= 0 And CDbl(txtGrosRatePercent.Text) <= 100) Then
     gMsg = "Commissionable Percent of Daily Rate must be numeric between 0 and 100."
     UpdateTrigger = False
     SetFocusTo = "txtGrosRatePercent"
     Exit Function
  End If
  'Future Percentage to Host has been entered...
  If txtFutPercentToHost.Text <> "" Then
     If Not IsNumeric(txtFutPercentToHost.Text) Then
        gMsg = "Future Percentage To Host must be numeric between 0 and 100."
        UpdateTrigger = False
        SetFocusTo = "txtFutPercentToHost"
        GoTo UpdateTrigger_Resume
     ElseIf Not (CDbl(txtFutPercentToHost.Text) >= 0 And CDbl(txtFutPercentToHost.Text) <= 100) Then
        gMsg = "Future Percentage To Host must be numeric between 0 and 100."
        UpdateTrigger = False
        SetFocusTo = "txtFutPercentToHost"
        GoTo UpdateTrigger_Resume
     ElseIf txtFutEffDate.Text = "" Then
        gMsg = "Future Effective Date must be entered if a Future Percentage To Host is specified."
        UpdateTrigger = False
        SetFocusTo = "txtFutEffDate"
        GoTo UpdateTrigger_Resume
     End If
  End If
  'Future percentage cannot be blank if Effective date is filled in.
  If txtFutEffDate.Text <> "" And txtFutPercentToHost.Text = "" Then
        gMsg = "Future Percentage To Host must be entered if a Future Effective Date is specified."
        UpdateTrigger = False
        SetFocusTo = "txtFutPercentToHost"
        GoTo UpdateTrigger_Resume
  End If
  'Update Property Name in other tables if it has changed. First check if name
  'is already assigned to another account number. If so, trigger fails.
  If datdwComboPropName.Text <> OrigPropName Then
     Set SSTemp = gBNB.OpenRecordset("select location,accountnum from proptbl where location = " & Chr$(34) & datdwComboPropName.Text & Chr$(34), dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount > 0 Then
        gMsg = "This property name is already assigned to property account number " & SSTemp(1) & ". Change the property name to make it more distinct."
        UpdateTrigger = False
        SetFocusTo = "datdwComboPropName"
        SSTemp.Close
        GoTo UpdateTrigger_Resume
     End If
     SSTemp.Close
     gMsg = "Updating Property Name. Please wait..."
     frmStatus.Show
     'Allow status form to paint fully
     For i = 1 To 3
       DoEvents
     Next i
     gBNB.Execute "update bbtbl set location = " & Chr$(34) & datdwComboPropName.Text & Chr$(34) & " where accountnum = " & txtAccountNum.Text
     gBNB.Execute "update checktbl set location = " & Chr$(34) & datdwComboPropName.Text & Chr$(34) & " where accountnum = " & txtAccountNum.Text
     gBNB.Execute "update checktemp set location = " & Chr$(34) & datdwComboPropName.Text & Chr$(34) & " where accountnum = " & txtAccountNum.Text
     gBNB.Execute "update PropertyFacts set Property = " & Chr$(34) & datdwComboPropName.Text & Chr$(34) & " where accountnum = " & txtAccountNum.Text
  End If
  DoEvents
  'Update City, State, Zip in PropertyFacts if any have changed.
  If txtPropCity.Text <> OrigPropCity Or txtPropState.Text <> OrigPropState Or txtPropZipcode.Text <> OrigPropZipcode Then
     gBNB.Execute "update PropertyFacts set City = " & Chr$(34) & txtPropCity.Text & Chr$(34) & _
                  ",State = " & Chr$(34) & txtPropState.Text & Chr$(34) & _
                  ",ZipCode = " & Chr$(34) & txtPropZipcode.Text & Chr$(34) & _
                  " where accountnum = " & txtAccountNum.Text
  End If
  
UpdateTrigger_Resume:
   If FormLoaded(frmStatus) Then Unload frmStatus
   DoEvents
   Screen.MousePointer = DEFAULT
   Exit Function

UpdateTrigger_Error:
   Resume UpdateTrigger_Resume

End Function

