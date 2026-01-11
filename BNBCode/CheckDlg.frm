VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{00025600-0000-0000-C000-000000000046}#5.1#0"; "CRYSTL32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmCheckDlg 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Check Printing Dialog Box"
   ClientHeight    =   6660
   ClientLeft      =   1380
   ClientTop       =   1260
   ClientWidth     =   9000
   HelpContextID   =   129
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   6660
   ScaleWidth      =   9000
   Begin VB.CommandButton cmdGoBack 
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
      Height          =   435
      Left            =   7380
      TabIndex        =   14
      Top             =   5700
      Width           =   1575
   End
   Begin VB.CommandButton cmdClear 
      Caption         =   "Clear &Selections"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   7380
      TabIndex        =   12
      Top             =   4740
      Width           =   1575
   End
   Begin VB.CommandButton cmdPrinter 
      Caption         =   "P&rinter Setup..."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   7380
      TabIndex        =   11
      Top             =   4260
      Width           =   1575
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
      Height          =   2445
      Left            =   60
      TabIndex        =   17
      Top             =   4170
      Width           =   7155
      Begin VB.Frame fraHostOptions 
         BorderStyle     =   0  'None
         Height          =   765
         Left            =   360
         TabIndex        =   22
         Top             =   900
         Width           =   2475
         Begin VB.OptionButton optGuestRefund 
            Caption         =   "Guest Refunds"
            Height          =   255
            Left            =   420
            TabIndex        =   3
            Top             =   480
            Width           =   1635
         End
         Begin VB.OptionButton optHostPayment 
            Caption         =   "Host Payments"
            Height          =   195
            Left            =   420
            TabIndex        =   2
            Top             =   150
            Width           =   1635
         End
         Begin VB.Line Line3 
            X1              =   180
            X2              =   360
            Y1              =   240
            Y2              =   240
         End
         Begin VB.Line Line2 
            X1              =   180
            X2              =   360
            Y1              =   600
            Y2              =   600
         End
         Begin VB.Line Line1 
            BorderColor     =   &H00000000&
            X1              =   180
            X2              =   180
            Y1              =   30
            Y2              =   600
         End
      End
      Begin Threed.SSCheck chkManualConf 
         Height          =   195
         Left            =   3000
         TabIndex        =   8
         Top             =   1380
         Width           =   2595
         _Version        =   65536
         _ExtentX        =   4577
         _ExtentY        =   344
         _StockProps     =   78
         Caption         =   "Enter Conf numbers manually"
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
      Begin VB.ComboBox txtComboPageSize 
         Appearance      =   0  'Flat
         Height          =   315
         ItemData        =   "CHECKDLG.frx":0000
         Left            =   4140
         List            =   "CHECKDLG.frx":0002
         TabIndex        =   7
         Tag             =   "Text"
         Top             =   690
         Width           =   2595
      End
      Begin VB.OptionButton optManualCheck 
         Caption         =   "Miscellaneous"
         Height          =   195
         Left            =   120
         TabIndex        =   5
         Top             =   2100
         Width           =   1695
      End
      Begin VB.OptionButton optTravelAgency 
         Caption         =   "Travel Commission"
         Height          =   195
         Left            =   120
         TabIndex        =   4
         Top             =   1710
         Width           =   2055
      End
      Begin VB.OptionButton optHostProperty 
         Caption         =   "Host (Client Trust account)"
         Height          =   195
         Left            =   120
         TabIndex        =   1
         Top             =   660
         Width           =   2295
      End
      Begin VB.TextBox txtShowTop 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   3840
         TabIndex        =   6
         Tag             =   "Number"
         Text            =   "100"
         Top             =   240
         Width           =   495
      End
      Begin Threed.SSCheck chkDisplayOnly 
         Height          =   195
         Left            =   3000
         TabIndex        =   9
         Top             =   1740
         Width           =   2595
         _Version        =   65536
         _ExtentX        =   4577
         _ExtentY        =   344
         _StockProps     =   78
         Caption         =   "Display check to screen only"
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
      Begin Threed.SSCheck chkSaveSettings 
         Height          =   255
         Left            =   3000
         TabIndex        =   10
         Top             =   2040
         Width           =   2595
         _Version        =   65536
         _ExtentX        =   4577
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "&Save settings on Exit"
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Value           =   -1  'True
      End
      Begin VB.Label lblCategory 
         Caption         =   "Check Category"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   -1  'True
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   120
         TabIndex        =   21
         Top             =   300
         Width           =   1635
      End
      Begin VB.Label lblPageSize 
         Caption         =   "Check Size:"
         Height          =   255
         Left            =   3000
         TabIndex        =   20
         Top             =   780
         Width           =   1035
      End
      Begin VB.Label lblConfirm 
         Caption         =   "Confirmations"
         Height          =   225
         Left            =   4440
         TabIndex        =   19
         Top             =   300
         Width           =   1035
      End
      Begin VB.Label lblShowTop 
         Caption         =   "Show Top"
         Height          =   225
         Left            =   3000
         TabIndex        =   18
         Top             =   300
         Width           =   795
      End
   End
   Begin VB.CommandButton cmdContinue 
      Caption         =   "&Continue..."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   435
      Left            =   7380
      TabIndex        =   15
      Top             =   6180
      Width           =   1575
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
      Height          =   435
      Left            =   7380
      TabIndex        =   13
      Top             =   5220
      Width           =   1575
   End
   Begin VB.Data datListing 
      Appearance      =   0  'Flat
      Caption         =   "datListing"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   60
      MousePointer    =   1  'Arrow
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   6780
      Visible         =   0   'False
      Width           =   1935
   End
   Begin Threed.SSPanel pnlMessage 
      Height          =   495
      Left            =   1980
      TabIndex        =   16
      Top             =   6810
      Width           =   1275
      _Version        =   65536
      _ExtentX        =   2249
      _ExtentY        =   873
      _StockProps     =   15
      Caption         =   "pnlMessage"
      BackColor       =   12632256
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
   Begin Crystal.CrystalReport CheckReport 
      Left            =   3780
      Top             =   6810
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   348160
      WindowControlBox=   -1  'True
      WindowMaxButton =   0   'False
      WindowMinButton =   -1  'True
      WindowState     =   2
      PrintFileLinesPerPage=   60
      WindowShowPrintBtn=   0   'False
      WindowShowExportBtn=   0   'False
      WindowShowCloseBtn=   -1  'True
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   3300
      Top             =   6810
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin SSDataWidgets_B.SSDBGrid grddwListing 
      Height          =   4065
      Left            =   60
      TabIndex        =   0
      Top             =   30
      Width           =   8895
      _Version        =   131078
      DataMode        =   2
      Col.Count       =   0
      AllowUpdate     =   0   'False
      MultiLine       =   0   'False
      AllowRowSizing  =   0   'False
      AllowGroupSizing=   0   'False
      AllowGroupMoving=   0   'False
      AllowColumnMoving=   0
      AllowGroupSwapping=   0   'False
      AllowColumnSwapping=   0
      AllowGroupShrinking=   0   'False
      AllowColumnShrinking=   0   'False
      AllowDragDrop   =   0   'False
      SelectTypeCol   =   0
      MaxSelectedRows =   1000
      ForeColorEven   =   0
      RowHeight       =   423
      Columns(0).Width=   3200
      _ExtentX        =   15690
      _ExtentY        =   7170
      _StockProps     =   79
      Caption         =   "Select Confirmations"
   End
End
Attribute VB_Name = "frmCheckDlg"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TimesActivated As Integer
'Dim ConfArray() As Long
Dim SavedGrid() As Variant
Dim FailedArrayRoutines As Integer
Dim OriginalRowPosition As Long
Dim NL As String
Dim SAW As Long
Dim gMiscCheckNum, gHostCheckNum, gTravelCheckNum As Long
Dim gCheckNum As Long
Dim gCategory As String
Dim bkmrk As Variant
Dim TempStr As String

Private Sub chkManualConf_Click(Value As Integer)

   If chkManualConf.Value = CHECKED Then
      grddwListing.Enabled = False
      Erase ConfArray
   Else
      grddwListing.Enabled = True
   End If
   
End Sub



Private Sub cmdClear_Click()
   grddwListing.SelBookmarks.RemoveAll
End Sub

Private Sub cmdContinue_Click()
    
    On Error GoTo cmdContinue_Error

    '*****Perform validity checks before printing.*****
    'A Check Number value must exist in CheckNum table for Category user selects
    Dim TempSS As Recordset
    Dim i, j As Integer
    Dim vPropertyName As String
    Dim vSumPaid, vRefOwed, vCheckAmt, vNetWTax As Currency
    Dim vConf, vAccountNum As Long
    Dim vInputCheckNum, vCurrentCheckNum As Variant
    Dim PromptedForSeqNo As Integer
    Dim OK_To_Print As Integer
    PromptedForSeqNo = False
    'Ensure check numbers have been set
    Set TempSS = gBNB.OpenRecordset("select * from CheckNum", dbOpenSnapshot)
    GetSSRows TempSS
    If TempSS.RecordCount = 0 Then
       MsgBox "Check numbers must be set through the 'Accounting','Checks' menu selection.", MB_ICONSTOP, Me.Caption
       TempSS.Close
       GoTo cmdContinue_Resume
    Else
       If optHostProperty.Value = CHECKED Then
          If IsNull(TempSS("HostCheckNum")) Then
             MsgBox "Check number for Host category must be set through the 'Accounting','Checks' menu selection.", MB_ICONSTOP, Me.Caption
             TempSS.Close
             GoTo cmdContinue_Resume
          End If
       ElseIf optTravelAgency.Value = CHECKED Then
          If IsNull(TempSS("TravelCheckNum")) Then
             MsgBox "Check number for Travel category must be set through the 'Accounting','Checks' menu selection.", MB_ICONSTOP, Me.Caption
             TempSS.Close
             GoTo cmdContinue_Resume
          End If
       ElseIf optManualCheck.Value = CHECKED Then
          If IsNull(TempSS("MiscCheckNum")) Then
             MsgBox "Check number for Miscellaneous category must be set through the 'Accounting','Checks' menu selection.", MB_ICONSTOP, Me.Caption
             TempSS.Close
             GoTo cmdContinue_Resume
          End If
       End If
    End If
    TempSS.Close
    'Show Top must not be zero
    If Trim(txtShowTop.Text) <> "" Then
       If IsNumeric(txtShowTop.Text) Then
          If CInt(Trim(txtShowTop.Text)) <= 0 Then
             MsgBox "Show Top Confirmations field value must be greater than zero.", MB_ICONSTOP, Me.Caption
             GoTo cmdContinue_Resume
          End If
       Else
          MsgBox "Invalid number value in Show Top Confirmations field.", MB_ICONSTOP, Me.Caption
          GoTo cmdContinue_Resume
       End If
    Else
       txtShowTop.Text = "100"
    End If
    'Force to Portrait mode
    While Printer.Orientation <> 1
       GoSub SetToPortrait
    Wend
    WriteIniSettings
    '*****End validity checks.*****
    Screen.MousePointer = HOURGLASS
    If cmdContinue.Caption = "&Continue..." Then
       If grddwListing.SelBookmarks.Count = 0 And chkManualConf.Value = UNCHECKED And optManualCheck.Value = UNCHECKED Then
          MsgBox "No confirmations have been selected.", MB_ICONSTOP, Me.Caption
          GoTo cmdContinue_Resume
       End If
       'Allow user to go back to Conf selection screen
       cmdGoBack.Enabled = True
       'Disable 'Print To' options
       DisablePrintToOptions
       gSQL = BuildContinueQuery()
       If optManualCheck.Value = UNCHECKED Then
          If chkManualConf.Value = CHECKED Then
             TempStr = GetConfNumString()
          Else
             'Get conf#'s selected
             'ReDim ConfArray(grddwListing.SelBookmarks.Count)
             Erase ConfArray
             For i = 0 To grddwListing.SelBookmarks.Count - 1
                bkmrk = grddwListing.SelBookmarks(i)
                ConfArray(i) = grddwListing.Columns("Conf Num").CellValue(bkmrk)
                'MsgBox Str(ConfArray(i))
             Next i
             TempStr = ""
             For i = 0 To grddwListing.SelBookmarks.Count - 1
               TempStr = TempStr & Str(ConfArray(i)) & ","
             Next i
          End If
          'User cancelled before any Conf#'s were entered.
          If Len(TempStr) = 0 Then
             optHostProperty.Enabled = True
             optTravelAgency.Enabled = True
             optManualCheck.Enabled = True
             chkManualConf.Enabled = True
             cmdContinue.Caption = "&Continue..."
            ' cmdPrinter.Visible = False
             cmdPrinter.Enabled = False
             cmdGoBack.Enabled = False
             EnablePrintToOptions
             grddwListing.Caption = "Select Confirmations"
             'cmdClear.Visible = False
             GoTo cmdContinue_Resume
          End If
          TempStr = Left(TempStr, Len(TempStr) - 1)
          gSQL = gSQL & TempStr & ")"
          If optHostProperty.Value = CHECKED And optGuestRefund.Value = CHECKED Then
             gSQL = gSQL & " order by pmt.conf"
          ElseIf optHostProperty.Value = CHECKED Then
             gSQL = gSQL & " order by b.location"
          ElseIf optTravelAgency.Value = CHECKED Then
             gSQL = gSQL & " order by agencyname"
          End If
          'MsgBox gSQL
          'grddwListing.DefColWidth = grddwListing.Columns(0).Width
          datListing.RecordSource = gSQL
          StatusMessage Me, "Querying the database...", True
          grddwListing.Reset
          If Not GetDCRows(datListing) Then Exit Sub
          If datListing.Recordset.RecordCount = 0 Then
             If optHostProperty.Value = CHECKED And optGuestRefund.Value = CHECKED Then
                gMsg = "Guest Payments shows no refunds due to guests for selected rows."
                StatusMessage Me, gMsg, True
                'cmdClose.Enabled = True
                GoTo cmdContinue_Resume
             ElseIf optHostProperty.Value = CHECKED Then
                gMsg = "No accommodations exist for selected rows. Cannot print check to host."
                StatusMessage Me, gMsg, True
                'cmdClose.Enabled = True
                GoTo cmdContinue_Resume
             ElseIf optTravelAgency.Value = CHECKED Then
                gMsg = "No travel agency information exists for selected rows. Cannot print commission check to agency."
                StatusMessage Me, gMsg, True
                'cmdClose.Enabled = True
                GoTo cmdContinue_Resume
             End If
          End If
          LoadGridRows
          StatusMessage Me, "", False
          grddwListing.Visible = False
          If optHostProperty.Value = CHECKED And optGuestRefund.Value = CHECKED Then
             'Allow edit on all columns but Conf Number and Guest Name
             AllowEdit ""
             DisAllowEdit "Conf Num"
             DisAllowEdit "Guest Name"
             DisAllowEdit "Host Property"
             DisAllowEdit "Account Num"
          ElseIf optHostProperty.Value = CHECKED Then
             'Allow edit on all columns but Conf Number, Guest Name, and Row_ID
             AllowEdit ""
             DisAllowEdit "Conf Num"
             DisAllowEdit "Guest Name"
             DisAllowEdit "Host Property"
             DisAllowEdit "Account Num"
             DisAllowEdit "Row ID"
             For i = 0 To 11
               grddwListing.Columns(i).Width = Me.TextWidth("XXXXXXXX")
             Next i
             grddwListing.Columns(0).Width = Me.TextWidth("XXXXXXXXX")
             grddwListing.Columns(1).Width = Me.TextWidth("XXXXXXXXXXX")
             grddwListing.Columns(2).Width = Me.TextWidth("XXXXXXXXXXXXXXX")
             grddwListing.Columns(6).Width = Me.TextWidth("XXXXXX")
             grddwListing.Columns(7).Width = Me.TextWidth("XXXXXXXX")
             grddwListing.Columns(8).Width = Me.TextWidth("XXXXXXXX")
             grddwListing.Columns(9).Width = Me.TextWidth("XXXXXXXXXXXXXXXXXX")
             grddwListing.Columns(10).Width = Me.TextWidth("XXXXXXXXXX")
          ElseIf optTravelAgency.Value = CHECKED Then
             'Allow edit on all columns but Conf Number and Guest Name, etc.
             AllowEdit ""
             DisAllowEdit "Conf Num"
             DisAllowEdit "Guest Name"
             'DisAllowEdit "Print Check To"
             DisAllowEdit "Account Num"
             DisAllowEdit "Row ID"
             grddwListing.Columns(0).Width = Me.TextWidth("XXXXXXXXX")
             grddwListing.Columns(1).Width = Me.TextWidth("XXXXXXXXXXX")
             grddwListing.Columns(2).Width = Me.TextWidth("XXXXXXXXXX")
             grddwListing.Columns(3).Width = Me.TextWidth("XXXXXXXXXXXXXXXXXXXX")
             grddwListing.Columns(4).Width = Me.TextWidth("XXXXXXXXX")
             grddwListing.Columns(5).Width = Me.TextWidth("XXXXXXXXXXXXXXX")
             grddwListing.Columns(6).Width = Me.TextWidth("XXXXXXXXX")
          ElseIf optManualCheck.Value = CHECKED Then
             'Allow edit on all columns
             AllowEdit ""
          End If
          'Enable grid if chkManualConf_Click disabled it
          grddwListing.Visible = True
          grddwListing.Enabled = True
          Screen.MousePointer = DEFAULT
       End If
       GoTo cmdContinue_Resume
    Else 'Print
       If grddwListing.SelBookmarks.Count = 0 And optManualCheck.Value = UNCHECKED Then
          MsgBox "Rows to include in check have not been selected.", MB_ICONSTOP, Me.Caption
          GoTo cmdContinue_Resume
       End If
       'Check size option cannot be blank.
       Dim InList As Integer
       For i = 0 To txtComboPageSize.ListCount - 1   ' Loop through list.
         If txtComboPageSize.Text = txtComboPageSize.List(i) Then
            InList = True
            Exit For
         End If
       Next i
       If Not InList Then
          MsgBox "Check size is not valid. Choose a check size from the dropdown list.", MB_ICONSTOP, Me.Caption
          GoTo cmdContinue_Resume
       End If
       'If Host or Travel check type (or, NOT Miscellaneous type):
       If optManualCheck.Value = UNCHECKED Then
          If Not CheckAmtOK("Check Amt") Then
             MsgBox "Format error in Check Amount", MB_ICONSTOP, Me.Caption
             grddwListing.Visible = True
             StatusMessage Me, "", False
             GoTo cmdContinue_Resume
          End If
          If Not CheckAmtOK("Net w/Tax") Then
             MsgBox "Format error in Net With Tax", MB_ICONSTOP, Me.Caption
             grddwListing.Visible = True
             StatusMessage Me, "", False
             GoTo cmdContinue_Resume
          End If
          If Not CheckAmtOK("Nights") Then
             MsgBox "Format error in number of Nights", MB_ICONSTOP, Me.Caption
             grddwListing.Visible = True
             StatusMessage Me, "", False
             GoTo cmdContinue_Resume
          End If
          'If Refund check:
          If optHostProperty.Value = CHECKED And optGuestRefund.Value = CHECKED Then
             For j = 0 To grddwListing.SelBookmarks.Count - 1
                grddwListing.Bookmark = grddwListing.SelBookmarks(j)
                For i = 0 To grddwListing.Columns.Count - 1
                   If grddwListing.Columns(i).Caption = "Conf Num" Then
                      vConf = CLng(grddwListing.Columns(i).Text)
                      Exit For
                   End If
                Next i
                'If not prompted already, prompt for first check number in sequence
                If Not PromptedForSeqNo Then
                   gSQL = "SELECT HostCheckNum " & _
                          "FROM checknum "
                   Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
                   GetSSRows TempSS
                   vCurrentCheckNum = TempSS(0)
                   TempSS.Close
                   vInputCheckNum = InputBox("The first check number to be printed in this sequence " & _
                                    "is " & vCurrentCheckNum & ". Change it below if this " & _
                                    "is not correct.", "Refund Check Printing", vCurrentCheckNum)
                   If Trim(vInputCheckNum) = "" Then GoTo cmdContinue_Resume
                   If IsNumeric(vInputCheckNum) Then
                      PromptedForSeqNo = True
                      If vInputCheckNum <> vCurrentCheckNum Then
                         gBNB.Execute "UPDATE checknum SET HostCheckNum = " & vInputCheckNum
                      End If
                   Else
                      gMsg = "Check number must be numeric."
                      MsgBox gMsg, MB_ICONSTOP, Me.Caption
                      GoTo cmdContinue_Resume
                   End If
                End If
                'Determine total amount (if any) of refund already paid on current conf#
                gSQL = "SELECT SUM(trueamt) FROM checktbl " & _
                       " WHERE conf = " & vConf & _
                       " AND CheckCategory = 'Host' AND SubCategory = 'Guest Refund' " & _
                       " AND void_chk = 0"
                Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
                GetSSRows TempSS
                vSumPaid = TempSS(0)
                TempSS.Close
                gSQL = "SELECT refundowed FROM payment WHERE conf=" & vConf
                Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
                GetSSRows TempSS
                vRefOwed = TempSS(0)
                TempSS.Close
                OK_To_Print = True
                'Dont need this. Wont show in grid if Amount is blank or 0 anyway.
                'If IsNull(vRefOwed) Or vRefOwed = 0 Then
                '   gMsg = "Amount Due must be set in the Refund section of guest's Payment " & _
                '          "History before a refund check can be printed."
                '   MsgBox gMsg, MB_ICONSTOP, Me.Caption
                '   OK_To_Print = False
                '   grddwListing.Visible = True
                '   StatusMessage Me, "", False
                'End If
                
                'If a refund check has already been printed on this confirmation...
                If Not IsNull(vSumPaid) Then
                   If vSumPaid > 0 Then
                      gMsg = "Total refund to be paid out for confirmation " & _
                             vConf & " is $" & vRefOwed & ". Refund check(s) " & _
                             "totaling $" & vSumPaid & " have already been printed. " & _
                             "Continue with check printing for this confirmation?"
                      If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then
                         OK_To_Print = False
                         grddwListing.Visible = True
                         StatusMessage Me, "", False
                      End If
                   End If
                End If
                'End refund warning.
                'Print check.
                If OK_To_Print Then BeginPrintProcess
             Next j
          ElseIf optHostProperty.Value = CHECKED Then
             'Must print Host checks individually. Allow multiple check
             'printing only for Travel Agency Commissions and Refund checks
             If Not AllSamePayee And optTravelAgency.Value = UNCHECKED Then
                MsgBox "Selected rows include different host properties. Accommodations to include in the next check must be for the same property.", MB_ICONSTOP, Me.Caption
                grddwListing.Visible = True
                StatusMessage Me, "", False
                GoTo cmdContinue_Resume
             End If
             'Prompt for next check number
             gSQL = "SELECT HostCheckNum " & _
                    "FROM checknum "
             Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
             GetSSRows TempSS
             vCurrentCheckNum = TempSS(0)
             TempSS.Close
             vInputCheckNum = InputBox("The next check number to be printed " & _
                              "is " & vCurrentCheckNum & ". Change it below if this " & _
                              "is not correct.", "Host Check Printing", vCurrentCheckNum)
             If Trim(vInputCheckNum) = "" Then GoTo cmdContinue_Resume
             If IsNumeric(vInputCheckNum) Then
                If vInputCheckNum <> vCurrentCheckNum Then
                   gBNB.Execute "UPDATE checknum SET HostCheckNum = " & vInputCheckNum
                End If
             Else
                gMsg = "Check number must be numeric."
                MsgBox gMsg, MB_ICONSTOP, Me.Caption
                GoTo cmdContinue_Resume
             End If
             'end prompt for next check number
             For j = 0 To grddwListing.SelBookmarks.Count - 1
                grddwListing.Bookmark = grddwListing.SelBookmarks(j)
                For i = 0 To grddwListing.Columns.Count - 1
                   If grddwListing.Columns(i).Caption = "Conf Num" Then
                      vConf = CLng(grddwListing.Columns(i).Text)
                      Exit For
                   End If
                Next i
                For i = 0 To grddwListing.Columns.Count - 1
                   If grddwListing.Columns(i).Caption = "Account Num" Then
                      vAccountNum = CLng(grddwListing.Columns(i).Text)
                      If Not IsNull(vAccountNum) Then
                         gSQL = "SELECT location FROM proptbl WHERE AccountNum = " & vAccountNum
                         Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
                         GetSSRows TempSS
                         vPropertyName = TempSS(0)
                         TempSS.Close
                      Else
                         vPropertyName = "host"
                      End If
                      Exit For
                   End If
                Next i
                For i = 0 To grddwListing.Columns.Count - 1
                   If grddwListing.Columns(i).Caption = "Check Amt" Then
                      vCheckAmt = CCur(grddwListing.Columns(i).Text)
                      Exit For
                   End If
                Next i
                For i = 0 To grddwListing.Columns.Count - 1
                   If grddwListing.Columns(i).Caption = "Net w/Tax" Then
                      vNetWTax = CCur(grddwListing.Columns(i).Text)
                      Exit For
                   End If
                Next i
                If Not IsNull(vConf) And Not IsNull(vAccountNum) And Not IsNull(vCheckAmt) Then
                   gSQL = "SELECT SUM(trueamt) FROM checktbl " & _
                          " WHERE conf = " & vConf & _
                          " AND CheckCategory = 'Host' " & _
                          " AND AccountNum = " & vAccountNum & _
                          "AND void_chk = 0"
                   Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
                   GetSSRows TempSS
                   vSumPaid = TempSS(0)
                   TempSS.Close
                   If Not IsNull(vSumPaid) Then
'MsgBox "SumPaid=" & Str(vSumPaid) & ", AcctNum=" & vAccountNum & ", CheckAmt=" & vCheckAmt
                      gSQL = "SELECT SUM(NWTax) FROM bbtbl " & _
                             " WHERE conf = " & vConf & _
                             " AND AccountNum = " & vAccountNum & _
                             " AND (suppress<>-1 Or (suppress=-1 And forfeit=-1)) "
                      Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
                      GetSSRows TempSS
                      vSumNetWTax = TempSS(0)
                      TempSS.Close
                      If CCur(vSumPaid) + CCur(vCheckAmt) > vSumNetWTax Then
                         If vSumPaid > 0 Then
                            gMsg = "Total payments to " & vPropertyName & " for confirmation " & _
                                   vConf & " will exceed amount due (" & vSumNetWTax & _
                                   ") if this check is " & _
                                   "printed. Continue with check printing anyway?"
                            If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then
                               grddwListing.Visible = True
                               StatusMessage Me, "", False
                               GoTo cmdContinue_Resume
                            End If
                         End If
                      End If
                   Else
                      'No check has been previously printed and NetWTax does not
                      'match check amount to be printed.
                      If vCheckAmt <> vNetWTax Then
                         gMsg = "Total payment to " & vPropertyName & " for confirmation " & _
                                vConf & " will not equal amount due (" & vNetWTax & _
                                ") if this check is printed for " & vCheckAmt & ". Continue with check printing anyway?"
                         If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then
                            grddwListing.Visible = True
                            StatusMessage Me, "", False
                            GoTo cmdContinue_Resume
                         End If
                      End If
                   End If
                   If GetTotalGuestCredit(vConf) <= 0 Then
                      gMsg = "Total guest credit for confirmation " & vConf & " is zero. " & _
                             "Check cannot be printed to host until a guest payment has been recorded."
                      MsgBox gMsg, MB_ICONSTOP, Me.Caption
                      grddwListing.Visible = True
                      StatusMessage Me, "", False
                      GoTo cmdContinue_Resume
                   End If
                End If
             Next j
             'End host overpayment warning
             BeginPrintProcess
          ElseIf optTravelAgency.Value = CHECKED Then
             'Allow multiple selection and looping print on Travel
             'Agency commission checks because there will only be
             'one commission check per conf number (less confusing
             'than the Host checks where one check may include many
             'conf numbers)
             For j = 0 To grddwListing.SelBookmarks.Count - 1
                grddwListing.Bookmark = grddwListing.SelBookmarks(j)
                For i = 0 To grddwListing.Columns.Count - 1
                   If grddwListing.Columns(i).Caption = "Conf Num" Then
                      vConf = CLng(grddwListing.Columns(i).Text)
                      Exit For
                   End If
                Next i
                'If not prompted already, prompt for first check number in sequence
                If Not PromptedForSeqNo Then
                   'Get the next travel check number in sequence
                   gSQL = "SELECT TravelCheckNum " & _
                          "FROM checknum "
                   Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
                   GetSSRows TempSS
                   vCurrentCheckNum = TempSS(0)
                   TempSS.Close
                   vInputCheckNum = InputBox("The first check number to be printed in this sequence " & _
                               "is " & vCurrentCheckNum & ". Change it below if this " & _
                               "is not correct.", "Travel Commission Check Printing", vCurrentCheckNum)
                   If Trim(vInputCheckNum) = "" Then GoTo cmdContinue_Resume
                   If IsNumeric(vInputCheckNum) Then
                      If vInputCheckNum <> vCurrentCheckNum Then
                         PromptedForSeqNo = True
                         gBNB.Execute "UPDATE checknum SET TravelCheckNum = " & vInputCheckNum
                      End If
                   Else
                      gMsg = "Check number must be numeric."
                      MsgBox gMsg, MB_ICONSTOP, Me.Caption
                      GoTo cmdContinue_Resume
                   End If
                End If
                gSQL = "SELECT SUM(trueamt) FROM checktbl " & _
                       " WHERE conf = " & vConf & _
                       " AND CheckCategory = 'Travel' " & _
                       " AND void_chk = 0"
                Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
                GetSSRows TempSS
                vSumPaid = TempSS(0)
                TempSS.Close
                gSQL = "SELECT commdue FROM tagentbl WHERE conf=" & vConf
                Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
                GetSSRows TempSS
                vRefOwed = TempSS(0)
                TempSS.Close
                OK_To_Print = True
                If Not IsNull(vSumPaid) Then
                   If vSumPaid > 0 Then
                      gMsg = "Total travel agency commission to be paid " & _
                             "out for confirmation " & _
                             vConf & " is $" & vRefOwed & ". Commission check(s) " & _
                             "totaling $" & vSumPaid & " have already been printed. " & _
                             "Continue with check printing for this confirmation?"
                      If MsgBox(gMsg, MB_ICONEXCLAMATION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then
                         OK_To_Print = False
                         grddwListing.Visible = True
                         StatusMessage Me, "", False
                      End If
                   End If
                End If
                'End travel agency commission check printing warning.
                If OK_To_Print Then BeginPrintProcess
             Next j
          End If
       Else
          'Miscellaneous check is being printed.
          'Update check num in case another user has printed a check
          'in the meantime.
          gMiscCheckNum = GetNextCheckNum("Miscellaneous")
          'Inspect user's check info entries here...
          If grddwListing.Columns(0).Text = "" Or Not IsNumeric(grddwListing.Columns(0).Text) Then
             MsgBox "Format error in Check Number.", MB_ICONSTOP, Me.Caption
             GoTo cmdContinue_Resume
          ElseIf Not CheckAmtOK("Check Amt") Then
             MsgBox "Format error in Check Amt.", MB_ICONSTOP, Me.Caption
             GoTo cmdContinue_Resume
          Else
             'For Miscellaneous category check entry, see if entered check number
             'matches system check number if not printing to screen.
             If (CLng(grddwListing.Columns(0).Text) <> gMiscCheckNum) And chkDisplayOnly.Value = UNCHECKED Then
                gMsg = "Entered check number of " & grddwListing.Columns(0).Text & " does not equal " & _
                       "system's next check number of " & gMiscCheckNum & ". " & _
                       "Continuing with printing will print check number " & grddwListing.Columns(0).Text & _
                       " and update the system's next check number to be " & _
                       "printed to " & (CLng(grddwListing.Columns(0).Text) + 1) & " . Continue?"
                If MsgBox(gMsg, MB_ICONQUESTION + MB_YESNO + MB_DEFBUTTON2, Me.Caption) = IDNO Then
                'MsgBox gMsg, MB_ICONSTOP, Me.Caption
                   GoTo cmdContinue_Resume
                Else
                   gBNB.Execute "UPDATE checknum SET MiscCheckNum = " & (CLng(grddwListing.Columns(0).Text) + 1)
                End If
             End If
             BeginPrintProcess
          End If
       End If
    End If
    
cmdContinue_Resume:
   'Clear out working table
   gBNB.Execute "delete from checktemp where computername = " & Chr$(34) & gComputerName & Chr$(34)
   Screen.MousePointer = DEFAULT
   Exit Sub
   
SetToPortrait:
   gMsg = "Set Orientation to Portrait mode in the following Printer Setup screen..."
   MsgBox gMsg, MB_ICONSTOP, Me.Caption
   'Generate error if use clicks on Cancel.
   CMDialog1.CancelError = True
   'Show printer setup box instead of printer dialog box.
   CMDialog1.Flags = cdlPDPrintSetup
   'Activate Printer Dialog Box
   CMDialog1.ShowPrinter
   'Invoke changes on printer object.
   Printer.EndDoc
   Return
   
cmdContinue_Error:
    'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
    If Err = cdlCancel Then
       'This will keep background screens from other applications
       'gaining focus mysteriously upon closure of common dialog.
       SAW = SetActiveWindow(mdiBNB.hwnd)
    Else
       MsgBox Err.Description
    End If
    Resume cmdContinue_Resume

End Sub


Private Sub cmdExit_Click()
   Unload Me
End Sub




Private Sub cmdGoBack_Click()

On Error GoTo cmdGoBack_Error

Dim i, j As Integer
Screen.MousePointer = HOURGLASS
If chkManualConf.Value = CHECKED Then
   frmManualConfDlg.grddwListing.Reset
   For i = 0 To UBound(ConfArray) - 1
      If ConfArray(i) > 0 Then frmManualConfDlg.grddwListing.AddItem ConfArray(i)
   Next i
   frmManualConfDlg.Show 1
   If ManConfDlgContinue Then
      Call cmdContinue_Click
   ElseIf ManConfDlgCancel Then
      'Do nothing
   ElseIf ManConfDlgBack Then
      TimesActivated = 0
      Call Form_Activate
   End If
Else
   Screen.MousePointer = HOURGLASS
   TimesActivated = 0
   cmdContinue.Caption = "&Continue..."
   grddwListing.Caption = "Select Confirmations"
   WriteIniSettings
   grddwListing.Reset
   txtComboPageSize.Clear
   Call Form_Activate
   Screen.MousePointer = HOURGLASS
   StatusMessage Me, "Loading data grid...", True
   For j = 0 To grddwListing.Rows - 1
      bkmrk = grddwListing.AddItemBookmark(j)
      For i = 0 To UBound(ConfArray) - 1
         If ConfArray(i) <> 0 And Not IsNull(ConfArray(i)) Then
           If ConfArray(i) = grddwListing.Columns("Conf Num").CellValue(bkmrk) Then
              'The following line has the same effect with 'bkmrk = grddwListing.AddItemBookmark(j)' commented.
              'If ConfArray(i) = grddwListing.Columns("Conf Num").CellValue(j) Then
              grddwListing.SelBookmarks.Add grddwListing.AddItemBookmark(j)
              Exit For
           End If
         End If
      Next i
   Next j
   GetIniSettings
   EnablePrintToOptions
   If optManualCheck.Value = CHECKED Then
      StatusMessage Me, "Press Continue to enter Miscellaneous check information...", True
      grddwListing.Visible = True
   Else
      StatusMessage Me, "", False
      grddwListing.Visible = True
   End If
   If chkManualConf.Value = CHECKED Then
      grddwListing.Enabled = False
   Else
      grddwListing.Enabled = True
   End If
End If


cmdGoBack_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdGoBack_Error:
   Resume cmdGoBack_Resume
   
End Sub

Private Sub cmdPrinter_Click()
   
   On Error GoTo cmdPrint_Error
   
   'Generate error if use clicks on Cancel.
   CMDialog1.CancelError = True
   'Show printer setup box instead of printer dialog box.
   CMDialog1.Flags = cdlPDPrintSetup
   'Activate Printer Dialog Box
   CMDialog1.ShowPrinter
   'Invoke changes on printer object.
   Printer.EndDoc
 
cmdPrinter_Resume:
   Exit Sub
  
cmdPrint_Error:
   'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
   If Err = cdlCancel Then
      'This will keep background screens from other applications
      'gaining focus mysteriously upon closure of common dialog.
      SAW = SetActiveWindow(mdiBNB.hwnd)
   Else
      MsgBox Err.Description
   End If
   Resume cmdPrinter_Resume

End Sub



Private Sub Form_Activate()

  On Error GoTo Form_Activate_Error

  'If this form is in the background (does not have focus) and the
  'Minimize button is clicked on this form that does not yet have the focus,
  'an endless loop of Minimizing and Activating will occur. The following
  'line prevents this interesting problem.
  If Me.WindowState = MINIMIZED Then Exit Sub

  TimesActivated = TimesActivated + 1
  If TimesActivated > 1 Then GoTo Form_Activate_Resume
  Screen.MousePointer = HOURGLASS
  NL = Chr$(13) & Chr$(10)
  Dim TempSS As Recordset
  grddwListing.Caption = "Select Confirmations"
  cmdContinue.Caption = "&Continue..."
  'Load check Size list
  txtComboPageSize.Clear
  txtComboPageSize.AddItem "8.5in x 11in Laser"
  txtComboPageSize.AddItem "8.5in x 7in Dot Matrix"
  cmdGoBack.Enabled = False
  Set TempSS = gBNB.OpenRecordset("select MAX(conf) from guesttbl", dbOpenSnapshot)
  GetSSRows TempSS
  If IsNull(TempSS(0)) Then
     'gMsg = "Cannot print checks. No confirmations have been entered."
     'MsgBox gMsg, MB_ICONSTOP, Me.Caption
     'GoTo Form_Activate_Resume
     GetIniSettings
     optHostProperty.Enabled = False
     optTravelAgency.Enabled = False
     optManualCheck.Value = CHECKED
     optTravelAgency_Click
     optManualCheck_Click
     StatusMessage Me, "", False
     StatusMessage Me, "No guest confirmations have been entered into database yet." & NL & "Press Continue to enter Miscellaneous check information, or Exit to quit.", True
     Me.Refresh
     grddwListing.Visible = True
  Else
     GetIniSettings
     Dim TempVal As Long
     If TempSS(0) <= CInt(Trim(txtShowTop.Text)) Then
        TempVal = 0
     Else
        TempVal = TempSS(0) - CInt(Trim(txtShowTop.Text) - 1)
     End If
     gSQL = "select conf AS [Conf Num],l_name AS [Last Name],f_name AS [First Name]," & _
     "datebkd AS [Date Booked],bookedby as [Booked By] " & _
     "from guesttbl " & _
     "where conf <= " & Str(TempSS(0)) & " And conf >= " & TempVal & _
     " order by conf desc"
     TempSS.Close
     grddwListing.Visible = False
     datListing.Enabled = False
     'Clear grid for possible call from Options. Doesn't hurt otherwise.
     grddwListing.Reset
     'Display status message
     StatusMessage Me, "Querying the database ...", True
     'Set data control's record source equal to SQL statement.
     datListing.RecordSource = gSQL
     'Refresh datacontrol and query the database.
     If Not GetDCRows(datListing) Then GoTo Form_Activate_Resume
     For i = 0 To 5
       DoEvents
     Next i
     'Load data into grid
     If datListing.Recordset.RecordCount > 0 Then
       StatusMessage Me, "Loading data grid...", True
       LoadGridRows
       grddwListing.Visible = False
       StatusMessage Me, "", False
     Else
       StatusMessage Me, "No confirmations returned.", True
       GoTo Form_Activate_Resume
     End If
     If optManualCheck.Value = CHECKED Then
        StatusMessage Me, "Press Continue to enter Miscellaneous check information...", True
        grddwListing.Visible = True
     End If
  End If
  'Disallow edit on all columns
  DisAllowEdit ""
  'Ensure grid is either Enabled or Disabled as selected in control
  chkManualConf_Click False
  'Some quirky display action workarounds here...
  If optManualCheck.Value = CHECKED Then
  Else
     StatusMessage Me, "", False
     grddwListing.Visible = True
  End If
  EnablePrintToOptions

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
  
Form_Activate_Error:
   Resume Form_Activate_Resume
  
End Sub

Private Sub Form_Load()

  TimesActivated = 0
  datListing.DatabaseName = gDatabaseName

End Sub



Public Sub LoadGridRows()

    Dim j As Long
    For i = 0 To datListing.Recordset.Fields.Count - 1
       grddwListing.Columns(i).Caption = datListing.Recordset.Fields(i).Name
    Next i
    '*** Note! If redraw is set to false and there are lots of rows to populate,
    '*** some cells will be left blank! So, don't set it to false.
    'grddwListing.Redraw = False
    grddwListing.Visible = False
    'Initialize grid
    For i = 0 To datListing.Recordset.RecordCount - 1
       grddwListing.AddItem ""
    Next i
    'Load Data
    datListing.Recordset.MoveFirst
    For j = 0 To datListing.Recordset.RecordCount - 1
       grddwListing.Bookmark = grddwListing.AddItemBookmark(j)
       For i = 0 To datListing.Recordset.Fields.Count - 1
         If IsNull(datListing.Recordset.Fields(i).Value) Then
            'Do nothing
         Else
            grddwListing.Columns(i).Text = datListing.Recordset.Fields(i).Value
         End If
       Next i
       datListing.Recordset.MoveNext
    Next j
    'Move the row ID column to end of list (users will never need this
    'and it would be confused with conf#). It should always be at end of list anyway
    'because that's the way it is in the table  (bnb1.mdb file)
 '   For i = 0 To datListing.Recordset.Fields.Count - 1
 '     If grddwListing.Columns(i).Caption = "ID" Then
 '       grddwListing.Columns(i).Position = datListing.Recordset.Fields.Count - 1
 '       Exit For
 '     End If
 '   Next i
    grddwListing.MoveFirst
    'grddwListing.Redraw = True
    'grddwListing.Visible = True
    grddwListing.Refresh
    
End Sub

Private Sub Form_Resize()
   pnlMessage.Move grddwListing.Left, grddwListing.Top, grddwListing.Width, grddwListing.Height
End Sub



Public Sub WriteIniSettings()

    'Declare variables
    Dim X As Integer        'Return Value
    Dim winDir, iniFile, Temp As String
    'Get the directory in which the Windows and the .INI files reside.
    'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())
    'Determine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"
    If CLng(txtShowTop) > 2000 Then txtShowTop.Text = 2000
'SAVE SETTINGS (always save this)
    'Write the Save Settings check box setting to the .INI file.
'MsgBox Str(chkSaveSettings.Value)
    If chkSaveSettings.Value = CHECKED Then
        X = WritePrivateProfileString("Check Print", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Check Print", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Check Print", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub
    X = WritePrivateProfileString("Check Print", "ShowTop", Format$(txtShowTop.Text), iniFile)
    X = WritePrivateProfileString("Check Print", "PrintToHost", Format$(optHostProperty.Value), iniFile)
    X = WritePrivateProfileString("Check Print", "HostPayment", Format$(optHostPayment.Value), iniFile)
    X = WritePrivateProfileString("Check Print", "GuestRefund", Format$(optGuestRefund.Value), iniFile)
    X = WritePrivateProfileString("Check Print", "PrintToAgency", Format$(optTravelAgency.Value), iniFile)
    X = WritePrivateProfileString("Check Print", "ManualCheck", Format$(optManualCheck.Value), iniFile)
    X = WritePrivateProfileString("Check Print", "DisplayOnly", Format$(chkDisplayOnly.Value), iniFile)
    X = WritePrivateProfileString("Check Print", "PageSize", txtComboPageSize.Text, iniFile)
    X = WritePrivateProfileString("Check Print", "ManualConf", Format$(chkManualConf.Value), iniFile)
    
End Sub

Public Sub GetIniSettings()

    'Declare variables
    Dim X As Integer        'Return Value
    Dim Rs As String * 200  'Return String
    Dim winDir, Temp, iniFile As String

    'Initialize variables
    Rs = Space$(Len(Rs))

    'Get the directory in which the Windows and the .INI files reside.
    'Note that GetPrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())
    'Detemine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"

    X = GetPrivateProfileString("Check Print", "ShowTop", "100", Rs, Len(Rs), iniFile)
    If X > 0 Then txtShowTop.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Print", "PrintToHost", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optHostProperty.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Print", "HostPayment", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optHostPayment.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Print", "GuestRefund", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optGuestRefund.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Print", "PrintToAgency", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optTravelAgency.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Print", "ManualCheck", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optManualCheck.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Print", "PageSize", "8.5in x 11in Laser", Rs, Len(Rs), iniFile)
    If X > 0 Then txtComboPageSize.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Print", "DisplayOnly", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then chkDisplayOnly.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Check Print", "ManualConf", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then chkManualConf.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Check Print", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
    If X > 0 Then  'a string was returned.
        Temp = Left$(Rs, X)     ' Trim Buffer
        If Temp = "CHECKED" Then
            chkSaveSettings.Value = CHECKED
        ElseIf Temp = "UNCHECKED" Then
            chkSaveSettings.Value = UNCHECKED
        ElseIf Temp = "GRAYED" Then
            chkSaveSettings.Value = GRAYED
        Else
            'Leave as set in design time.
        End If
    End If
End Sub

Private Sub Form_Unload(Cancel As Integer)

   On Error GoTo Form_Unload_Error
   
   Screen.MousePointer = HOURGLASS
    
   If FormLoaded(frmManualConfDlg) Then Unload frmManualConfDlg

   If Trim(txtShowTop.Text) <> "" Then
       If IsNumeric(txtShowTop.Text) Then
          If CInt(Trim(txtShowTop.Text)) <= 0 Then txtShowTop.Text = "100"
       End If
   Else
       txtShowTop.Text = "100"
   End If
   'Clear out working table
   gBNB.Execute "delete from checktemp where computername = " & Chr$(34) & gComputerName & Chr$(34)
   WriteIniSettings

Form_Unload_Resume:
   Screen.MousePointer = DEFAULT
   Dim X&
   X& = SetActiveWindow(mdiBNB.hwnd)
   Exit Sub
   
Form_Unload_Error:
   Resume Form_Unload_Resume
   
End Sub



Public Sub SaveGridToArray()
    'OBE by discovery of Grid.Locked property. Saved for reference.
    
   ' On Error GoTo SaveGridToArray_Error
    
   ' FailedArrayRoutines = False
   ' ReDim SavedGrid(datListing.Recordset.RecordCount, datListing.Recordset.Fields.Count)
   ' datListing.Recordset.MoveFirst
   ' For j = 0 To datListing.Recordset.RecordCount - 1
   '    grddwListing.Bookmark = grddwListing.AddItemBookmark(j)
   '    For i = 0 To datListing.Recordset.Fields.Count - 1
   '      If IsNull(datListing.Recordset.Fields(i).Value) Then
   '         'Do nothing
   '      Else
   '         SavedGrid(j, i) = datListing.Recordset.Fields(i).Value
   '      End If
   '    Next i
   '    datListing.Recordset.MoveNext
   ' Next j
   ' 'Set Recordset at first row
   ' datListing.Recordset.MoveFirst
   ' 'Set pointer to first grid row
   ' grddwListing.Bookmark = grddwListing.AddItemBookmark(0)
'Exit Sub

'SaveGridToArray_Error:
'   FailedArrayRoutines = True
'   Exit Sub
End Sub

Public Function AllSamePayee() As Integer

    On Error GoTo AllSamePayee_Error
    Dim i, j, vCount As Integer
    Dim vFirstNum, vNextNum As String
    AllSamePayee = True
    OriginalRowPosition = grddwListing.AddItemRowIndex(grddwListing.Bookmark)
    For j = 0 To grddwListing.SelBookmarks.Count - 1
       grddwListing.Bookmark = grddwListing.SelBookmarks(j)
       vCount = j
       For i = 0 To grddwListing.Columns.Count - 1
         If optTravelAgency.Value = CHECKED _
         Or (optHostProperty.Value = CHECKED _
         And Not optGuestRefund.Value = CHECKED) Then
            If grddwListing.Columns(i).Caption = "Account Num" Then
              If vCount = 0 Then
                 vFirstNum = grddwListing.Columns(i).Text
              Else
                 vNextNum = grddwListing.Columns(i).Text
                 If vFirstNum <> vNextNum Then
                   AllSamePayee = False
                   Exit For
                 End If
              End If
            End If
         ElseIf optHostProperty.Value = CHECKED And optGuestRefund.Value = CHECKED Then
            If grddwListing.Columns(i).Caption = "Conf Num" Then
              If vCount = 0 Then
                 vFirstNum = grddwListing.Columns(i).Text
              Else
                 vNextNum = grddwListing.Columns(i).Text
                 If vFirstNum <> vNextNum Then
                   AllSamePayee = False
                   Exit For
                 End If
              End If
            End If
         End If
       Next i
       If Not AllSamePayee Then Exit For
    Next j
    grddwListing.Bookmark = grddwListing.AddItemBookmark(OriginalRowPosition)
Exit Function

AllSamePayee_Error:
   AllSamePayee = False
   Exit Function
   
End Function

Private Sub optHostProperty_Click()
   
   chkManualConf.Enabled = True
   If chkManualConf.Value = CHECKED Then
      grddwListing.Enabled = False
   Else
      grddwListing.Enabled = True
   End If
   StatusMessage Me, "", False
   fraHostOptions.Enabled = True
   optHostPayment.Enabled = True
   optGuestRefund.Enabled = True
   'Enable lines
   Line1.BorderColor = &H80000008
   Line2.BorderColor = &H80000008
   Line3.BorderColor = &H80000008

End Sub

Private Sub optManualCheck_Click()

  If optManualCheck.Value = CHECKED Then
     chkManualConf.Enabled = False
     chkManualConf.Value = UNCHECKED
     StatusMessage Me, "Press Continue to enter Miscellaneous check information...", True
  Else
     chkManualConf.Enabled = True
     StatusMessage Me, "", False
  End If
  fraHostOptions.Enabled = False
  optHostPayment.Enabled = False
  optGuestRefund.Enabled = False
  'Disable lines
  Line1.BorderColor = &HE0E0E0
  Line2.BorderColor = &HE0E0E0
  Line3.BorderColor = &HE0E0E0
  
End Sub


Private Sub optTravelAgency_Click()

   chkManualConf.Enabled = True
   If chkManualConf.Value = CHECKED Then
      grddwListing.Enabled = False
   Else
      grddwListing.Enabled = True
   End If
   StatusMessage Me, "", False
   fraHostOptions.Enabled = False
   optHostPayment.Enabled = False
   optGuestRefund.Enabled = False
   'Disable lines
   Line1.BorderColor = &HE0E0E0
   Line2.BorderColor = &HE0E0E0
   Line3.BorderColor = &HE0E0E0

End Sub



Public Sub AllowEdit(TheColumn As String)

   grddwListing.AllowUpdate = True
   If TheColumn = "" Then
      'Enable edit on all columns
   Else
      'Enable edit on specific column
      For i = 0 To grddwListing.Columns.Count - 1
        If grddwListing.Columns(i).Caption <> TheColumn Then
          grddwListing.Columns(i).Locked = True
        End If
      Next i
   End If
   grddwListing.Refresh
   
End Sub

Public Sub DisAllowEdit(TheColumn As String)

   If TheColumn = "" Then
      'Disable edit on all columns
      grddwListing.AllowUpdate = False
   Else
      'Disable edit on specific column.
      grddwListing.AllowUpdate = True
      For i = 0 To grddwListing.Columns.Count - 1
        If grddwListing.Columns(i).Caption = TheColumn Then
           grddwListing.Columns(i).Locked = True
        End If
     Next i
   End If
   grddwListing.Refresh
   
End Sub

Public Function CheckAmtOK(TheColumn As String) As Integer

   CheckAmtOK = True
   grddwListing.Visible = False
   'Remember the original row position so that we can return there.
   OriginalRowPosition = grddwListing.AddItemRowIndex(grddwListing.Bookmark)
   For j = 0 To grddwListing.Rows - 1
       grddwListing.Bookmark = grddwListing.AddItemBookmark(j)
       For i = 0 To grddwListing.Columns.Count - 1
         If grddwListing.Columns(i).Caption = TheColumn Then
            If grddwListing.Columns(i).Text = "" Then grddwListing.Columns(i).Text = 0
            If IsNumeric(grddwListing.Columns(i).Text) Then
               grddwListing.Columns(i).Text = Format(grddwListing.Columns(i).Text, CURRENCYFORMAT)
            Else
               CheckAmtOK = False
            End If
         End If
       Next i
   Next j
   grddwListing.Bookmark = grddwListing.AddItemBookmark(OriginalRowPosition)
   grddwListing.Visible = True
   StatusMessage Me, "", False
   
End Function

Public Function InsertCheckTemp() As Integer
   
   On Error GoTo InsertCheckTemp_Error
   
   InsertCheckTemp = True
   'Clear out working table
   gBNB.Execute "delete from checktemp where computername = " & Chr$(34) & gComputerName & Chr$(34)
   DoEvents
   'Get total for check so we can convert it to text.
   Dim vTempTotal As Currency
   Dim CheckText As String
   Dim vMinArr, vMaxDep As Variant
   vMinArr = Null
   vMaxDep = Null
   vTempTotal = 0
   vTempTotal = vTempTotal + CCur(grddwListing.Columns("Check Amt").Text)
   CheckText = Str(vTempTotal)
   CheckText = Format(CheckText, CURRENCYFORMAT)
   CheckText = CurrencyToText(CStr(CheckText))
   'Define variables for mailing info from Host/Agency as appropriate.
   Dim vDBA, vAddress, vCityStateZip As Variant
   'Define variables for NetRate,TotalNet(NetRate*NumNights),Tax1,Tax2,Tax3 from bbtbl
   'These will be printed on check stub but not shown in screen grid.
   Dim vNetRate, vTotNet, vTax1, vTax2, vTax3 As Variant
   Dim TempSS As Recordset
   If optHostProperty.Value = CHECKED And optGuestRefund.Value = CHECKED Then
      vDBA = ""
      vAddress = grddwListing.Columns("Address").Text
      vCityStateZip = grddwListing.Columns("City").Text & "  " & grddwListing.Columns("State").Text & " " & grddwListing.Columns("Zipcode").Text
      gHostCheckNum = GetNextCheckNum("Host")
      gSQL = "select checknum from checktemp where checknum = " & gHostCheckNum & _
             " And checkcategory = 'Host' and computername <> " & Chr$(34) & gComputerName & Chr$(34)
      Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
      GetSSRows TempSS
      If TempSS.RecordCount > 0 Then
         gMsg = "Another user has already begun printing the same Host category check number (" & _
                gHostCheckNum & ") that you are attempting to print. Please try to print again in a moment."
         InsertCheckTemp = False
         TempSS.Close
         GoTo InsertCheckTemp_Resume
      End If
      TempSS.Close
      gCheckNum = gHostCheckNum
      gCategory = "Host"
   ElseIf optHostProperty.Value = CHECKED Then
      gSQL = "select dba,mailaddress,mailcity,mailstate,mailzipcode from proptbl where accountnum = " & grddwListing.Columns("Account Num").Text
      Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
      GetSSRows TempSS
      vDBA = TempSS("dba")
      vAddress = TempSS("mailaddress")
      vCityStateZip = TempSS("mailcity") & "  " & TempSS("mailstate") & " " & TempSS("mailzipcode")
      TempSS.Close
      gHostCheckNum = GetNextCheckNum("Host")
      gSQL = "select checknum from checktemp where checknum = " & Trim(Str(gHostCheckNum)) & _
             " And checkcategory = 'Host' and computername <> " & Chr$(34) & gComputerName & Chr$(34)
      Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
      GetSSRows TempSS
      If TempSS.RecordCount > 0 Then
         gMsg = "Another user has already started printing the same Host check number (" & _
                Trim(Str(gHostCheckNum)) & ") that you are attempting to print. Please try to print again in a moment."
         InsertCheckTemp = False
         TempSS.Close
         GoTo InsertCheckTemp_Resume
      End If
      TempSS.Close
      gCheckNum = gHostCheckNum
      gCategory = "Host"
   ElseIf optTravelAgency.Value = CHECKED Then
      gSQL = "select address,city,state,zipcode from tamaster where accountnum = " & grddwListing.Columns("Account Num").Text
      Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
      GetSSRows TempSS
      vDBA = ""
      vAddress = TempSS("address")
      vCityStateZip = TempSS("city") & "  " & TempSS("state") & " " & TempSS("zipcode")
      TempSS.Close
      gTravelCheckNum = GetNextCheckNum("Travel")
      gSQL = "select checknum from checktemp where checknum = " & Str(gTravelCheckNum) & _
             " And checkcategory = 'Travel' and computername <> " & Chr$(34) & gComputerName & Chr$(34)
      Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
      GetSSRows TempSS
      If TempSS.RecordCount > 0 Then
         gMsg = "Another user has already begun printing the same Travel check number (" & _
                Trim(Str(gTravelCheckNum)) & ") that you are attempting to print. Please try to print again in a moment."
         InsertCheckTemp = False
         TempSS.Close
         GoTo InsertCheckTemp_Resume
      End If
      TempSS.Close
      gCheckNum = gTravelCheckNum
      gCategory = "Travel"
   ElseIf optManualCheck.Value = CHECKED Then
      vDBA = ""
      vAddress = grddwListing.Columns("Address").Text
      vCityStateZip = grddwListing.Columns("City").Text & "  " & grddwListing.Columns("State").Text & " " & grddwListing.Columns("Zipcode").Text
      gSQL = "select checknum from checktemp where checknum = " & grddwListing.Columns("Check Num").Text & _
             " And checkcategory = 'Miscellaneous' and computername <> " & Chr$(34) & gComputerName & Chr$(34)
      Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
      GetSSRows TempSS
      If TempSS.RecordCount > 0 Then
         gMsg = "Another user has already begun printing the same Miscellaneous check number (" & _
                grddwListing.Columns("Check Num").Text & ") that you are attempting to print. Please try to print again in a moment."
         InsertCheckTemp = False
         TempSS.Close
         GoTo InsertCheckTemp_Resume
      End If
      TempSS.Close
      gCheckNum = gMiscCheckNum
      gCategory = "Miscellaneous"
   End If
   Dim TempTab As Recordset
   Set TempTab = gBNB.OpenRecordset("checktemp", dbOpenTable, dbDenyWrite + dbDenyRead)
   If optHostProperty.Value = CHECKED And optGuestRefund.Value = CHECKED Then
      'Get the min and max dates for the total guest reservation.
      If grddwListing.Columns("Conf Num").Text <> "" Then
         Set TempSS = gBNB.OpenRecordset("select min(arrdate)from bbtbl where conf = " & grddwListing.Columns("Conf Num").Text, dbOpenSnapshot)
         GetSSRows TempSS
         If TempSS.RecordCount > 0 Then vMinArr = TempSS(0)
         TempSS.Close
         Set TempSS = gBNB.OpenRecordset("select max(depdate)from bbtbl where conf = " & grddwListing.Columns("Conf Num").Text, dbOpenSnapshot)
         GetSSRows TempSS
         If TempSS.RecordCount > 0 Then vMaxDep = TempSS(0)
         TempSS.Close
      End If
      TempTab.AddNew  ' Create new record.
      TempTab("conf") = grddwListing.Columns("Conf Num").Text
      TempTab("location") = ""
      TempTab("dba") = vDBA
      TempTab("address") = vAddress
      TempTab("citystatezip") = vCityStateZip
      TempTab("arrdate") = vMinArr
      TempTab("nwtax") = Null
      If grddwListing.Columns("Check Amt").Text = "" Then
         TempTab("trueamt") = Null
      Else
         TempTab("trueamt") = grddwListing.Columns("Check Amt").Text
      End If
      TempTab("l_name") = grddwListing.Columns("Guest Name").Text
      TempTab("depdate") = vMaxDep
      TempTab("numnites") = Null
      TempTab("checknum") = gHostCheckNum
      TempTab("cnotes") = grddwListing.Columns("Memo").Text
      TempTab("void_chk") = 0
      TempTab("chk_date") = Format(Now, "m/d/yyyy")
      TempTab("print_to") = grddwListing.Columns("Print Check To").Text
      TempTab("accountnum") = Null
      TempTab("text_amt") = CurrencyToText(Format(grddwListing.Columns("Check Amt").Text, CURRENCYFORMAT))
      TempTab("checkcategory") = "Host"
      TempTab("SubCategory") = "Guest Refund"
      TempTab("computername") = gComputerName
      'Save changes.
      TempTab.Update
   ElseIf optHostProperty.Value = CHECKED Then
      For i = 0 To grddwListing.SelBookmarks.Count - 1
         grddwListing.Bookmark = grddwListing.SelBookmarks(i)
         TempTab.AddNew  ' Create new record.
         'Get Rate and Tax values for each selection
         gSQL = "select NetRate,NetRate*numnites,Tax1,Tax2,Tax3 from bbtbl where ID = " & grddwListing.Columns("Row ID").Text
         Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
         GetSSRows TempSS
         vNetRate = TempSS(0)
         vTotNet = TempSS(1)
         vTax1 = TempSS(2)
         vTax2 = TempSS(3)
         vTax3 = TempSS(4)
         TempSS.Close
         If grddwListing.Columns("Conf Num").Text = "" Then
            TempTab("conf") = Null
         Else
            TempTab("conf") = grddwListing.Columns("Conf Num").Text
         End If
         TempTab("location") = grddwListing.Columns("Host Property").Text
         TempTab("dba") = vDBA
         TempTab("address") = vAddress
         TempTab("citystatezip") = vCityStateZip
         If grddwListing.Columns("Arrive").Text = "" Then
            TempTab("arrdate") = Null
         Else
            TempTab("arrdate") = grddwListing.Columns("Arrive").Text
         End If
         If grddwListing.Columns("Net w/Tax").Text = "" Then
            TempTab("nwtax") = Null
         Else
            TempTab("nwtax") = grddwListing.Columns("Net w/Tax").Text
         End If
         If grddwListing.Columns("Check Amt").Text = "" Then
            TempTab("trueamt") = Null
         Else
            TempTab("trueamt") = grddwListing.Columns("Check Amt").Text
            CheckTotal = CheckTotal + CCur(grddwListing.Columns("Check Amt").Text)
         End If
         TempTab("l_name") = grddwListing.Columns("Guest Name").Text
         If grddwListing.Columns("Depart").Text = "" Then
            TempTab("depdate") = Null
         Else
            TempTab("depdate") = grddwListing.Columns("Depart").Text
         End If
         If grddwListing.Columns("Nights").Text = "" Then
            TempTab("numnites") = Null
         Else
            TempTab("numnites") = grddwListing.Columns("Nights").Text
         End If
         TempTab("checknum") = gHostCheckNum
         TempTab("cnotes") = grddwListing.Columns("Comments").Text
         TempTab("void_chk") = 0
         TempTab("chk_date") = Format(Now, "m/d/yyyy")
         TempTab("print_to") = grddwListing.Columns("Print Check To").Text
         If grddwListing.Columns("Account Num").Text = "" Then
            TempTab("accountnum") = Null
         Else
            TempTab("accountnum") = grddwListing.Columns("Account Num").Text
         End If
         TempTab("text_amt") = ""
         TempTab("checkcategory") = "Host"
         If grddwListing.Columns("Row ID").Text = "" Then
            TempTab("Accom_RowId") = Null
         Else
            TempTab("Accom_RowId") = grddwListing.Columns("Row ID").Text
         End If
         TempTab("computername") = gComputerName
         TempTab("NetRate") = vNetRate
         TempTab("TotNet") = vTotNet
         TempTab("Tax1") = vTax1
         TempTab("Tax2") = vTax2
         TempTab("Tax3") = vTax3
         'Save changes.
         TempTab.Update
      Next i
   ElseIf optTravelAgency.Value = CHECKED Then
      'Get the min and max dates for the total guest reservation.
      If grddwListing.Columns("Conf Num").Text <> "" Then
         Set TempSS = gBNB.OpenRecordset("select min(arrdate)from bbtbl where conf = " & grddwListing.Columns("Conf Num").Text, dbOpenSnapshot)
         GetSSRows TempSS
         If TempSS.RecordCount > 0 Then vMinArr = TempSS(0)
         TempSS.Close
         Set TempSS = gBNB.OpenRecordset("select max(depdate)from bbtbl where conf = " & grddwListing.Columns("Conf Num").Text, dbOpenSnapshot)
         GetSSRows TempSS
         If TempSS.RecordCount > 0 Then vMaxDep = TempSS(0)
         TempSS.Close
      End If
      grddwListing.Bookmark = grddwListing.SelBookmarks(i)
      TempTab.AddNew  ' Create new record.
      If grddwListing.Columns("Conf Num").Text = "" Then
         TempTab("conf") = Null
      Else
         TempTab("conf") = grddwListing.Columns("Conf Num").Text
      End If
      TempTab("location") = ""
      TempTab("dba") = vDBA
      TempTab("address") = vAddress
      TempTab("citystatezip") = vCityStateZip
      TempTab("arrdate") = vMinArr 'Null
      TempTab("nwtax") = Null
      If grddwListing.Columns("Check Amt").Text = "" Then
         TempTab("trueamt") = Null
      Else
         TempTab("trueamt") = grddwListing.Columns("Check Amt").Text
      End If
      TempTab("l_name") = grddwListing.Columns("Guest Name").Text
      TempTab("depdate") = vMaxDep
      TempTab("numnites") = Null
      TempTab("checknum") = gTravelCheckNum
      TempTab("cnotes") = grddwListing.Columns("Memo").Text
      TempTab("void_chk") = 0
      TempTab("chk_date") = Format(Now, "m/d/yyyy")
      TempTab("print_to") = grddwListing.Columns("Print Check To").Text
      If grddwListing.Columns("Account Num").Text = "" Then
         TempTab("accountnum") = Null
      Else
         TempTab("accountnum") = grddwListing.Columns("Account Num").Text
      End If
      TempTab("text_amt") = CheckText
      TempTab("checkcategory") = "Travel"
      TempTab("computername") = gComputerName
      'Save changes.
      TempTab.Update
   ElseIf optManualCheck.Value = CHECKED Then
      TempTab.AddNew  ' Create new record.
      TempTab("conf") = Null
      TempTab("location") = ""
      TempTab("dba") = vDBA
      TempTab("address") = vAddress
      TempTab("citystatezip") = vCityStateZip
      TempTab("arrdate") = Null
      TempTab("nwtax") = Null
      If grddwListing.Columns("Check Amt").Text = "" Then
         TempTab("trueamt") = Null
      Else
         TempTab("trueamt") = grddwListing.Columns("Check Amt").Text
      End If
      TempTab("l_name") = ""
      TempTab("depdate") = Null
      TempTab("numnites") = Null
      TempTab("checknum") = grddwListing.Columns("Check Num").Text
      TempTab("cnotes") = grddwListing.Columns("Memo").Text
      TempTab("void_chk") = 0
      TempTab("chk_date") = Format(Now, "m/d/yyyy")
      TempTab("print_to") = grddwListing.Columns("Print Check To").Text
      TempTab("accountnum") = Null
      TempTab("text_amt") = CurrencyToText(Format(grddwListing.Columns("Check Amt").Text, CURRENCYFORMAT))
      TempTab("checkcategory") = "Miscellaneous"
      TempTab("computername") = gComputerName
      'Save changes.
      TempTab.Update
   End If
   TempTab.Close   ' Close Table.
   
InsertCheckTemp_Resume:
   Exit Function

InsertCheckTemp_Error:
   gMsg = Err.Description
   If TempTab.EditMode = dbEditAdd Then TempTab.CancelUpdate
   InsertCheckTemp = False
   Resume InsertCheckTemp_Resume
   
End Function

Public Function GetNextCheckNum(TheAccount As String) As Long

  Dim TempSS As Recordset
  If TheAccount = "Host" Then
     Set TempSS = gBNB.OpenRecordset("select HostCheckNum from CheckNum", dbOpenSnapshot)
     GetSSRows TempSS
     GetNextCheckNum = TempSS(0)
  ElseIf TheAccount = "Travel" Then
     Set TempSS = gBNB.OpenRecordset("select TravelCheckNum from CheckNum", dbOpenSnapshot)
     GetSSRows TempSS
     GetNextCheckNum = TempSS(0)
  Else  'Miscellaneous
     Set TempSS = gBNB.OpenRecordset("select MiscCheckNum from CheckNum", dbOpenSnapshot)
     GetSSRows TempSS
     GetNextCheckNum = TempSS(0)
  End If
  TempSS.Close
  
End Function

Public Function PrintCheck() As Integer
    
    'Print Check report
    On Error GoTo PrintCheck_Error
    Dim Result%
    Screen.MousePointer = HOURGLASS
    PrintCheck = False
    
    If txtComboPageSize.Text Like "8.5in x 11in*" Then
       CheckReport.ReportFileName = gDBDirectory & "HstLngCk.rpt"
    ElseIf txtComboPageSize.Text Like "8.5in x 7in*" Then  'Short format (1/2 sheet, tractor feed, multi-part forms)
       CheckReport.ReportFileName = gDBDirectory & "HstShtCk.rpt"
    End If
    'CheckReport.WindowMinButton = False
    CheckReport.DataFiles(0) = gDatabaseName
    If chkDisplayOnly.Value = CHECKED Then
       CheckReport.Destination = 0
    Else
       CheckReport.Destination = 1
    End If
    CheckReport.SortFields(0) = "+{checktemp.ArrDate}"
    CheckReport.SelectionFormula = "{checktemp.ComputerName} = " & Chr$(34) & gComputerName & Chr$(34)
    'This works OK for printing also:
    'Result% = CheckReport.PrintReport
    CheckReport.Action = 1
    PrintCheck = True
    
PrintCheck_Resume:
   Screen.MousePointer = DEFAULT
   Exit Function

PrintCheck_Error:
  gMsg = Err.Description
  PrintCheck = False
  Resume PrintCheck_Resume
  
End Function
Public Function InsertCheckTable() As Integer
   
   On Error GoTo InsertCheckTable_Error
   
   InsertCheckTable = False

   'Insert into check ledger table
   gSQL = "insert into checktbl (conf,location,arrdate,nwtax,trueamt,l_name,depdate," & _
   "checknum,comments,void_chk,chk_date,print_to,accountnum,checkcategory,SubCategory,Accom_RowId) " & _
   "select conf,location,arrdate,nwtax,trueamt,l_name,depdate,checknum,cnotes,void_chk," & _
   "chk_date,print_to,accountnum,checkcategory,SubCategory,Accom_RowId " & _
   "from checktemp where computername = " & Chr$(34) & gComputerName & Chr$(34)
   gBNB.Execute gSQL
   
   InsertCheckTable = True

InsertCheckTable_Resume:
   Exit Function
   
InsertCheckTable_Error:
   gMsg = Err.Description
   InsertCheckTable = False
   Resume InsertCheckTable_Resume
   
End Function

Public Function IncrementCheckNumber(TheAccount As String) As Integer
 
  On Error GoTo IncrementCheckNumber_Error
  
  IncrementCheckNumber = False
  
  Dim SharedSS As Recordset
  Dim vSharedAccounts As Integer
  Set SharedSS = gBNB.OpenRecordset("select SharedAccounts from CheckNum", dbOpenSnapshot)
  GetSSRows SharedSS
  vSharedAccounts = SharedSS(0)
  'Can't have open recordset (SharedSS)with following TempTab recordset open
  'because TempTab will be exclusive, so close SharedSS.
  SharedSS.Close
  Dim TempTab As Recordset
  Set TempTab = gBNB.OpenRecordset("CheckNum", dbOpenTable, dbDenyWrite + dbDenyRead)
  TempTab.Edit
  If vSharedAccounts = 0 Then     'None
     If TheAccount = "Host" Then
        TempTab("HostCheckNum") = TempTab("HostCheckNum") + 1
     ElseIf TheAccount = "Travel" Then
        TempTab("TravelCheckNum") = TempTab("TravelCheckNum") + 1
     ElseIf TheAccount = "Miscellaneous" Then
        TempTab("MiscCheckNum") = TempTab("MiscCheckNum") + 1
     End If
  ElseIf vSharedAccounts = 1 Then 'Travel/Misc
     If TheAccount = "Host" Then
        TempTab("HostCheckNum") = TempTab("HostCheckNum") + 1
     ElseIf TheAccount = "Travel" Or TheAccount = "Miscellaneous" Then
        TempTab("TravelCheckNum") = TempTab("TravelCheckNum") + 1
        TempTab("MiscCheckNum") = TempTab("MiscCheckNum") + 1
     End If
  ElseIf vSharedAccounts = 2 Then 'Host/Misc
     If TheAccount = "Miscellaneous" Then
        TempTab("MiscCheckNum") = TempTab("MiscCheckNum") + 1
     ElseIf TheAccount = "Host" Or TheAccount = "Miscellaneous" Then
        TempTab("HostCheckNum") = TempTab("HostCheckNum") + 1
        TempTab("MiscCheckNum") = TempTab("MiscCheckNum") + 1
     End If
  ElseIf vSharedAccounts = 3 Then 'Host/Travel
     If TheAccount = "Miscellaneous" Then
        TempTab("MiscCheckNum") = TempTab("MiscCheckNum") + 1
     ElseIf TheAccount = "Host" Or TheAccount = "Travel" Then
        TempTab("HostCheckNum") = TempTab("HostCheckNum") + 1
        TempTab("TravelCheckNum") = TempTab("TravelCheckNum") + 1
     End If
  ElseIf vSharedAccounts = 4 Then 'All
     TempTab("HostCheckNum") = TempTab("HostCheckNum") + 1
     TempTab("TravelCheckNum") = TempTab("TravelCheckNum") + 1
     TempTab("MiscCheckNum") = TempTab("MiscCheckNum") + 1
  End If
  TempTab.Update
  TempTab.Close
  IncrementCheckNumber = True
  
IncrementCheckNumber_Resume:
   Exit Function
  
IncrementCheckNumber_Error:
   If TempTab.EditMode = dbEditInProgress Then TempTab.CancelUpdate
   IncrementCheckNumber = False
   gMsg = Err.Description
   Resume IncrementCheckNumber_Resume
   
End Function

Public Sub DisablePrintToOptions()

   On Error GoTo DisablePrintToOptions_Error
   
    'Disable 'Print To' options
    optHostProperty.Enabled = False
    optHostPayment.Enabled = False
    optGuestRefund.Enabled = False
    'Disable lines
    Line1.BorderColor = &HE0E0E0
    Line2.BorderColor = &HE0E0E0
    Line3.BorderColor = &HE0E0E0
    optTravelAgency.Enabled = False
    optManualCheck.Enabled = False
    cmdContinue.Caption = "&Print"
   ' cmdPrinter.Visible = True
    cmdPrinter.Enabled = True
    'cmdClear.Visible = True
    chkManualConf.Enabled = False

DisablePrintToOptions_Resume:
   Exit Sub
     
DisablePrintToOptions_Error:
   Resume DisablePrintToOptions_Resume
     

End Sub

Public Sub EnablePrintToOptions()

   On Error GoTo EnablePrintToOptions_Error

   'Enable 'Print To' options
   If optHostProperty.Value = CHECKED Then
      optHostProperty.Enabled = True
      optHostPayment.Enabled = True
      optGuestRefund.Enabled = True
      optTravelAgency.Enabled = True
      optManualCheck.Enabled = True
      'Enable lines
      Line1.BorderColor = BLACK
      Line2.BorderColor = BLACK
      Line3.BorderColor = BLACK
      chkManualConf.Enabled = True
   ElseIf optTravelAgency.Value = CHECKED Then
      optTravelAgency.Enabled = True
      optHostProperty.Enabled = True
      optHostPayment.Enabled = False
      optGuestRefund.Enabled = False
      optManualCheck.Enabled = True
      'Disable lines
      Line1.BorderColor = &HE0E0E0
      Line2.BorderColor = &HE0E0E0
      Line3.BorderColor = &HE0E0E0
      chkManualConf.Enabled = True
   ElseIf optManualCheck.Value = CHECKED Then
      optTravelAgency.Enabled = True
      optHostProperty.Enabled = True
      optHostPayment.Enabled = False
      optGuestRefund.Enabled = False
      optManualCheck.Enabled = True
      'Disable lines
      Line1.BorderColor = &HE0E0E0
      Line2.BorderColor = &HE0E0E0
      Line3.BorderColor = &HE0E0E0
      chkManualConf.Enabled = False
   End If
  ' cmdPrinter.Visible = False
   cmdPrinter.Enabled = False
   
EnablePrintToOptions_Resume:
   Exit Sub
     
EnablePrintToOptions_Error:
   Resume EnablePrintToOptions_Resume
     
End Sub

Public Function BuildContinueQuery() As String
       'Build query
       If optHostProperty.Value = CHECKED And optGuestRefund.Value = CHECKED Then
          grddwListing.Caption = "Print refund checks on selected confirmations"
          gSQL = "select pmt.conf AS [Conf Num],pmt.l_name AS [Guest Name],pmt.refundowed AS [Check Amt]," & _
          "pmt.l_name AS [Print Check To],g.Address AS [Address],g.City AS [City], " & _
          "g.State AS [State],g.ZipCode AS [Zipcode],'Guest Refund' AS [Memo] " & _
          "from payment AS pmt,guesttbl AS g " & _
          "Where pmt.conf = g.conf " & _
          "And pmt.refundowed is not null " & _
          "and pmt.conf in ("
       ElseIf optHostProperty.Value = CHECKED Then
          grddwListing.Caption = "Print check to an individual host on selected accommodations"
          gSQL = "select b.conf AS [Conf Num],b.l_name AS [Guest Name],b.location AS [Host Property]," & _
          "b.accountnum AS [Account Num],b.arrdate AS [Arrive],b.depdate AS [Depart]," & _
          "b.numnites AS [Nights],b.nwtax AS [Net w/Tax],b.nwtax AS [Check Amt]," & _
          "p.check_to AS [Print Check To],b.nnotes AS [Comments],b.ID AS [Row ID] " & _
          "from bbtbl AS b,proptbl AS p where p.accountnum=b.accountnum " & _
          "and (b.suppress<>-1 Or (b.suppress=-1 And b.forfeit=-1)) " & _
          "and b.pymttype<>'Direct' " & _
          "and b.conf in ("
       ElseIf optTravelAgency.Value = CHECKED Then
          grddwListing.Caption = "Print travel agency commission checks on selected confirmations"
          gSQL = "select t.conf AS [Conf Num],t.l_name AS [Guest Name],t.commdue AS [Check Amt]," & _
          "t.agencyname AS [Print Check To],accountnum AS [Account Num], " & _
          "' ' AS [Memo],ID AS [Row ID] " & _
          "from tagentbl t where t.conf in ("
       ElseIf optManualCheck.Value = CHECKED Then
         grddwListing.Reset
         For i = 0 To 0
           grddwListing.AddItem ""
         Next i
         grddwListing.DefColWidth = grddwListing.Columns(0).Width * 1.2
         grddwListing.Columns(0).Caption = "Check Num"
         grddwListing.Columns(1).Caption = "Check Amt"
         grddwListing.Columns(2).Caption = "Print Check To"
         grddwListing.Columns(3).Caption = "Address"
         grddwListing.Columns(4).Caption = "City"
         grddwListing.Columns(5).Caption = "State"
         grddwListing.Columns(6).Caption = "Zipcode"
         grddwListing.Columns(7).Caption = "Memo"
         grddwListing.Caption = "Enter information for Miscellaneous check"
         'Allow edit on all columns
         AllowEdit ""
         'Put check number in first column
         grddwListing.Columns(0).Value = GetNextCheckNum("Miscellaneous")
         StatusMessage Me, "", False
       End If
       BuildContinueQuery = gSQL
       
End Function

Public Function GetConfNumString() As String

           TempStr = ""
           If ConfArray(0) <> 0 And Not IsNull(ConfArray(0)) Then
             For i = 0 To UBound(ConfArray) - 1
                If ConfArray(i) <> 0 And Not IsNull(ConfArray(i)) Then
                   TempStr = TempStr & Str(ConfArray(i)) & ","
                Else
                   Exit For
                End If
             Next i
           Else
             Dim vConfInput As Variant
             Dim vCount As Integer
             'ReDim ConfArray(300)
             Erase ConfArray
             vCount = 0
             Do
                If Len(TempStr) = 0 Then
                   vConfInput = InputBox("Enter first confirmation number. Leave blank and click OK when entry of confirmation numbers is complete.", "Check Print")
                Else
                   vConfInput = InputBox("Enter next confirmation number. Leave blank and click OK when entry of confirmation numbers is complete.", "Check Print")
                End If
                If vConfInput <> "" Then
                   If Not IsNumeric(vConfInput) Then
                      MsgBox "Confirmation entered must be numeric.", MB_ICONSTOP, Me.Caption
                      vConfInput = ""
                      'GoTo cmdContinue_Resume
                   Else
                      'Append to string
                      TempStr = TempStr & vConfInput & ","
                      ConfArray(vCount) = vConfInput
                      vCount = vCount + 1
                   End If
                End If
             Loop Until vConfInput = ""
            End If
            GetConfNumString = TempStr
            
End Function

Public Sub BeginPrintProcess()
          
          On Error GoTo BeginPrintProcess_Error
          
          Dim TempSS As Recordset
          If Not InsertCheckTemp() Then
            grddwListing.Visible = True
            StatusMessage Me, "", False
            MsgBox gMsg
            GoTo BeginPrintProcess_Resume
          End If
          grddwListing.Visible = True
          StatusMessage Me, "", False
          gSQL = "select checknum from checktemp where checknum = " & Trim(Str(gCheckNum)) & _
                 " And checkcategory = '" & gCategory & "' and computername <> " & Chr$(34) & gComputerName & Chr$(34)
          Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
          GetSSRows TempSS
          If TempSS.RecordCount > 0 Then
             gMsg = "Another user has already started printing the same " & gCategory & " check number (" & _
                    Trim(Str(gCheckNum)) & ") that you are attempting to print. Please try to print again in a moment."
             'InsertCheckTemp = False
             MsgBox gMsg, MB_ICONSTOP, Me.Caption
             TempSS.Close
             GoTo BeginPrintProcess_Resume
          End If
          TempSS.Close
          'For Host checks only (non-refund):
          'Set text amount for next check. Can't set it during
          'InsertCheckTemp because table is locked
          If optHostProperty.Value = CHECKED And optGuestRefund.Value = UNCHECKED Then
             Dim CheckTotal As Currency
             Dim TextAmt As String
             TextAmt = ""
             CheckTotal = 0
             gSQL = "select sum(trueamt)from checktemp where " & _
                    "ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
             Set TempSS = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
             GetSSRows TempSS
             If TempSS.RecordCount > 0 Then CheckTotal = TempSS(0)
             TextAmt = CurrencyToText(Format(CheckTotal, CURRENCYFORMAT))
             gBNB.Execute "update checktemp set text_amt = '" & TextAmt & "' where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
             TempSS.Close
          End If
          If Not PrintCheck() Then
             MsgBox gMsg
             GoTo BeginPrintProcess_Resume
          End If
          If chkDisplayOnly.Value = CHECKED Then
            'Don't update tables
          Else
            If Not InsertCheckTable() Then
               MsgBox gMsg
               GoTo BeginPrintProcess_Resume
            End If
            Dim TempAcct As String
            If optHostProperty.Value = CHECKED Then
               TempAcct = "Host"
            ElseIf optTravelAgency.Value = CHECKED Then
               TempAcct = "Travel"
            Else  '(this case will never occur here.)
               TempAcct = "Miscellaneous"
            End If
            If Not IncrementCheckNumber(TempAcct) Then
               MsgBox "Check Number Increment Error"
               GoTo BeginPrintProcess_Resume
            End If
          End If
          
BeginPrintProcess_Resume:
   Exit Sub

BeginPrintProcess_Error:
    Resume BeginPrintProcess_Resume
    
End Sub


Public Function GetTotalGuestCredit(ByVal pConf As Long) As Double

    On Error GoTo GetTotalGuestCredit_Error
    Dim SSTemp As Recordset
    Dim TempTotal As Double
    Dim vTotalRefunded As Double
    'Get calculated total credit for current conf.
    GetTotalGuestCredit = 0
    Set SSTemp = gBNB.OpenRecordset("select sum(AmountReceived) from paymentreceived where conf = " & pConf, dbOpenSnapshot)
    GetSSRows SSTemp
    If Not IsNull(SSTemp(0)) Then
       TempTotal = SSTemp(0)
    Else
       TempTotal = 0
    End If
    SSTemp.Close
    'Add 'Deferred Commission' and 'Other Guest Credits' fields to total guest credit.
    Set SSTemp = gBNB.OpenRecordset("select defcom,OtherCredit from payment where conf = " & pConf, dbOpenSnapshot)
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
    Set SSTemp = gBNB.OpenRecordset("select sum(trueamt) from CheckTbl where conf = " & pConf & " and Void_Chk <> -1 and CheckCategory = 'Host' and SubCategory = 'Guest Refund'", dbOpenSnapshot)
    GetSSRows SSTemp
    If Not IsNull(SSTemp(0)) Then vTotalRefunded = vTotalRefunded + SSTemp(0)
    SSTemp.Close
    'Get total refunded by credit card or cash and add it to amount refunded by check.
    Set SSTemp = gBNB.OpenRecordset("select sum(AmtPaid) from RefundByCCTbl where conf = " & pConf, dbOpenSnapshot)
    GetSSRows SSTemp
    If Not IsNull(SSTemp(0)) Then vTotalRefunded = vTotalRefunded + SSTemp(0)
    SSTemp.Close
    TempTotal = TempTotal - vTotalRefunded
    GetTotalGuestCredit = TempTotal
    
GetTotalGuestCredit_Resume:
   Screen.MousePointer = DEFAULT
   Exit Function

GetTotalGuestCredit_Error:
   Resume GetTotalGuestCredit_Resume

End Function
