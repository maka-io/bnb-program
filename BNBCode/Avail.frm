VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{B16553C3-06DB-101B-85B2-0000C009BE81}#1.0#0"; "SPIN32.OCX"
Begin VB.Form frmAvailability 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Availability"
   ClientHeight    =   5145
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   10020
   HelpContextID   =   139
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   ScaleHeight     =   5145
   ScaleWidth      =   10020
   Begin VB.CommandButton cmdPrintAvail 
      Caption         =   "&Booking Report"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   420
      Left            =   4920
      TabIndex        =   14
      Top             =   4680
      Width           =   1515
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
      Left            =   7956
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   5544
      Visible         =   0   'False
      Width           =   2415
   End
   Begin SSDataWidgets_B.SSDBCombo datdwComboRoomType 
      Bindings        =   "Avail.frx":0000
      Height          =   312
      Left            =   6084
      TabIndex        =   11
      Tag             =   "Number"
      Top             =   3996
      Width           =   1572
      DataFieldList   =   "roomtype"
      ListAutoValidate=   0   'False
      _Version        =   131078
      Columns(0).Width=   3200
      _ExtentX        =   2778
      _ExtentY        =   556
      _StockProps     =   93
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "&OK"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   420
      Left            =   8280
      TabIndex        =   8
      Top             =   4680
      Width           =   1515
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
      Height          =   420
      Left            =   6600
      TabIndex        =   7
      Top             =   4680
      Width           =   1515
   End
   Begin VB.Data datProperty 
      Appearance      =   0  'Flat
      Caption         =   "datProperty"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   2820
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   5490
      Visible         =   0   'False
      Width           =   2055
   End
   Begin SSDataWidgets_B.SSDBCombo datdwComboProperty 
      Bindings        =   "Avail.frx":0016
      Height          =   312
      Left            =   1404
      TabIndex        =   1
      Tag             =   "Text"
      Top             =   3996
      Width           =   3192
      DataFieldList   =   "location"
      MaxDropDownItems=   10
      _Version        =   131078
      Columns(0).Width=   3200
      _ExtentX        =   5636
      _ExtentY        =   556
      _StockProps     =   93
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
   End
   Begin Spin.SpinButton SpinButton1 
      Height          =   312
      Left            =   9468
      TabIndex        =   5
      Top             =   3996
      Width           =   312
      _Version        =   65536
      _ExtentX        =   556
      _ExtentY        =   556
      _StockProps     =   73
      Delay           =   150
   End
   Begin Threed.SSPanel pnlMessage 
      Height          =   435
      Left            =   6480
      TabIndex        =   2
      Top             =   5520
      Width           =   1395
      _Version        =   65536
      _ExtentX        =   2461
      _ExtentY        =   767
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
   Begin VB.TextBox txtYear 
      Appearance      =   0  'Flat
      Height          =   315
      Left            =   8748
      TabIndex        =   3
      Tag             =   "Text"
      Top             =   3990
      Width           =   735
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
      Left            =   180
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   ""
      Top             =   5520
      Visible         =   0   'False
      Width           =   2415
   End
   Begin SSDataWidgets_B.SSDBGrid grddwListing 
      Height          =   3735
      Left            =   60
      TabIndex        =   0
      Top             =   90
      Width           =   9900
      _Version        =   131078
      DataMode        =   2
      Cols            =   31
      Col.Count       =   31
      AllowUpdate     =   0   'False
      AllowRowSizing  =   0   'False
      AllowGroupSizing=   0   'False
      AllowColumnSizing=   0   'False
      AllowGroupMoving=   0   'False
      AllowColumnMoving=   0
      AllowGroupSwapping=   0   'False
      AllowColumnSwapping=   0
      AllowGroupShrinking=   0   'False
      AllowColumnShrinking=   0   'False
      AllowDragDrop   =   0   'False
      SelectTypeCol   =   3
      SelectTypeRow   =   3
      MaxSelectedRows =   0
      RowHeight       =   397
      Columns(0).Width=   3200
      _ExtentX        =   17462
      _ExtentY        =   6588
      _StockProps     =   79
      Caption         =   "Nights Available and Booked"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin VB.Label lblUnitNameDesc 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      ForeColor       =   &H80000008&
      Height          =   375
      Left            =   5580
      TabIndex        =   15
      Top             =   5490
      Visible         =   0   'False
      Width           =   375
   End
   Begin VB.Label lblXLabel 
      Caption         =   "X = Invalid date"
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
      Left            =   120
      TabIndex        =   13
      Top             =   4860
      Width           =   2835
   End
   Begin VB.Label lblBlabel 
      Caption         =   "B = Booked"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   225
      Left            =   120
      TabIndex        =   12
      Top             =   4590
      Width           =   2835
   End
   Begin VB.Label lblRoomType 
      Caption         =   "Room Type ID:"
      Height          =   285
      Left            =   4950
      TabIndex        =   10
      Top             =   4050
      Width           =   1155
   End
   Begin VB.Label lblAcctNum 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      ForeColor       =   &H80000008&
      Height          =   345
      Left            =   4980
      TabIndex        =   9
      Top             =   5490
      Visible         =   0   'False
      Width           =   435
   End
   Begin VB.Label lblProperty 
      Caption         =   "Property Name:"
      Height          =   285
      Left            =   120
      TabIndex        =   6
      Top             =   4050
      Width           =   1305
   End
   Begin VB.Label lblYear 
      Caption         =   "Year:"
      Height          =   285
      Left            =   8175
      TabIndex        =   4
      Top             =   4050
      Width           =   555
   End
End
Attribute VB_Name = "frmAvailability"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim SSTemp As Recordset
Dim TimesActivated As Integer
Dim SAW As Long
Dim QueryWithOKButton As Integer
Dim PrevPropName As String
Dim PrevRoomType As String
Dim PrevYear As String
Dim FailedOK As Integer




Private Sub cmdExit_Click()
   Unload Me
End Sub

Private Sub cmdOK_Click()

   On Error GoTo cmdOK_Click_Error

   Dim SSTemp As Recordset
   Dim v_IsValid As Integer
   FailedOK = False
   If Trim(datdwComboProperty.Text) = "" Then
     If Trim(datdwComboRoomType.Text) <> "" Then
       gMsg = "Select a Property Name from the dropdown list before selecting Room Type."
       datdwComboRoomType.Text = ""
       MsgBox gMsg, MB_ICONSTOP, Me.Caption
       datdwComboProperty.SetFocus
       FailedOK = True
       GoTo cmdOK_Click_Resume
     Else
       gMsg = "Select Property Name from the dropdown list."
       datdwComboProperty.Text = ""
       MsgBox gMsg, MB_ICONSTOP, Me.Caption
       datdwComboProperty.SetFocus
       FailedOK = True
       GoTo cmdOK_Click_Resume
     End If
   Else
      Set SSTemp = gBNB.OpenRecordset("select accountnum from proptbl where PropObsolete<>-1 And location = " & Chr$(34) & datdwComboProperty.Text & Chr$(34), dbOpenSnapshot)
      GetSSRows SSTemp
      If SSTemp.RecordCount = 0 Then
         gMsg = "Property Name was entered incorrectly. Select a property name from the dropdown list."
         MsgBox gMsg, MB_ICONSTOP, Me.Caption
         SSTemp.Close
         datdwComboProperty.SetFocus
         FailedOK = True
         GoTo cmdOK_Click_Resume
      Else
         lblAcctNum.Caption = Trim(SSTemp("accountnum"))
      End If
      SSTemp.Close
   End If
   'Validate Year value
   txtYear.Text = Trim(txtYear.Text)
   If Trim(txtYear.Text) = "" Then
      'gMsg = "Enter a valid 4-digit year."
      'MsgBox gMsg, MB_ICONSTOP, Me.Caption
      'txtYear.SetFocus
      If Trim(txtYear.Text) = "" Then txtYear.Text = Trim$(DatePart("yyyy", Now))
      'GoTo cmdOK_Click_Resume
   ElseIf Len(txtYear.Text) <> 4 Then
         gMsg = "Enter a valid 4-digit year."
         MsgBox gMsg, MB_ICONSTOP, Me.Caption
         txtYear.SetFocus
         FailedOK = True
         GoTo cmdOK_Click_Resume
   Else
      If Not IsDate("1/1/" & txtYear.Text) Then
         gMsg = "Enter a valid 4-digit year."
         MsgBox gMsg, MB_ICONSTOP, Me.Caption
         txtYear.SetFocus
         FailedOK = True
         GoTo cmdOK_Click_Resume
      End If
   End If
   'If there are more than 0 entries in the HostAccount_RoomType_Link table for
   'the current property accountnum, then RoomType must be specified.
   Set SSTemp = gBNB.OpenRecordset("select RoomType,RoomType_Desc from HostAccount_RoomType_Link where accountnum = " & lblAcctNum.Caption, dbOpenSnapshot)
   GetSSRows SSTemp
   If SSTemp.RecordCount > 0 Then 'If room type exists, must specify it.
      If Trim(datdwComboRoomType.Text) = "" Then
         gMsg = "Select a Room Type from the dropdown list."
         MsgBox gMsg, MB_ICONSTOP, Me.Caption
         datdwComboRoomType.SetFocus
         SSTemp.Close
         FailedOK = True
         GoTo cmdOK_Click_Resume
      Else ' Make sure it's a valid entry for Room Type
         datdwComboRoomType.Text = Trim(datdwComboRoomType.Text)
         v_IsValid = False
         For i = 0 To SSTemp.RecordCount - 1
           If SSTemp("RoomType") = datdwComboRoomType.Text Then
              v_IsValid = True
              lblUnitNameDesc.Caption = SSTemp("RoomType_Desc")
              Exit For
           End If
           SSTemp.MoveNext
         Next i
         If Not v_IsValid Then
            lblUnitNameDesc.Caption = ""
            gMsg = "Invalid Room Type. Select a Room Type from the dropdown list."
            MsgBox gMsg, MB_ICONSTOP, Me.Caption
            datdwComboRoomType.SetFocus
            SSTemp.Close
            FailedOK = True
            GoTo cmdOK_Click_Resume
         End If
         SSTemp.Close
      End If
   Else
      datdwComboRoomType.Text = ""
      lblUnitNameDesc.Caption = ""
   End If

   QueryWithOKButton = True
   
   PrevPropName = datdwComboProperty.Text
   PrevRoomType = datdwComboRoomType.Text
   PrevYear = txtYear.Text
   
   Call Form_Activate
   
cmdOK_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
cmdOK_Click_Error:
   MsgBox Err.Description
   
End Sub

Private Sub cmdPrintAvail_Click()

   On Error GoTo cmdPrintAvail_Error
   
   If datdwComboProperty.Text <> PrevPropName Or _
      datdwComboRoomType.Text <> PrevRoomType Or _
      txtYear.Text <> PrevYear Then
      Call cmdOK_Click
      If FailedOK Then GoTo cmdPrintAvail_Resume
   End If

   If datListing.Recordset.RecordCount = 0 Then 'precautionary
      gMsg = "No data exists for the selected property and year."
      MsgBox gMsg, MB_ICONSTOP, Me.Caption
      GoTo cmdPrintAvail_Resume
   End If
   Screen.MousePointer = HOURGLASS
   Dim i, j, k As Integer
   Dim vMonth, vDay As Integer
   Dim CurrMonth As Integer
   'Clear out support table.
   gBNB.Execute "delete from AvailSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   datListing.Recordset.MoveFirst
   'Insert Booked dates into AvailSupport table.
   For j = 0 To datListing.Recordset.RecordCount - 1
      If DatePart("yyyy", datListing.Recordset("arrdate")) = txtYear.Text And DatePart("yyyy", datListing.Recordset("depdate")) = txtYear.Text Then
         'Fill grid for rows where arrival and departure dates are both in selected year.
         'Position to correct month in grid
         CurrMonth = DatePart("m", datListing.Recordset("arrdate"))
         'MsgBox CurrMonth
      '  grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
         'Find the arrival day
         vDay = DatePart("d", datListing.Recordset("arrdate"))
         'Fillin the columns from arrival date to depart date
         k = 0
         For i = 0 To datListing.Recordset("numnites") - 1
            If IsDate(CurrMonth & "/" & vDay + k & "/" & txtYear.Text) Then
       '        grddwListing.Columns(vDay + k).Text = "B"
               gSQL = "INSERT INTO AvailSupport (Conf,F_Name,L_Name,Month,BookDate,Year," & _
               "Location,Unitname,UnitnameDesc,ComputerName) VALUES (" & _
               datListing.Recordset("Conf") & "," & _
               Chr$(34) & datListing.Recordset("F_Name") & Chr$(34) & "," & _
               Chr$(34) & datListing.Recordset("L_Name") & Chr$(34) & "," & _
               CurrMonth & ",#" & _
               CurrMonth & "/" & vDay + k & "/" & txtYear.Text & "#," & _
               Chr$(34) & txtYear.Text & Chr$(34) & "," & _
               Chr$(34) & datListing.Recordset("Location") & Chr$(34) & "," & _
               Chr$(34) & datListing.Recordset("UnitName") & Chr$(34) & "," & _
               Chr$(34) & datListing.Recordset("UnitNameDesc") & Chr$(34) & "," & _
               Chr$(34) & gComputerName & Chr$(34) & ");"
               gBNB.Execute gSQL
               k = k + 1
            Else
               CurrMonth = CurrMonth + 1
         '      grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
               vDay = 1
               k = 0
         '      grddwListing.Columns(vDay + k).Text = "B"
               gSQL = "INSERT INTO AvailSupport (Conf,F_Name,L_Name,Month,BookDate,Year," & _
               "Location,Unitname,UnitnameDesc,ComputerName) VALUES (" & _
               datListing.Recordset("Conf") & "," & _
               Chr$(34) & datListing.Recordset("F_Name") & Chr$(34) & "," & _
               Chr$(34) & datListing.Recordset("L_Name") & Chr$(34) & "," & _
               CurrMonth & ",#" & _
               CurrMonth & "/" & vDay + k & "/" & txtYear.Text & "#," & _
               Chr$(34) & txtYear.Text & Chr$(34) & "," & _
               Chr$(34) & datListing.Recordset("Location") & Chr$(34) & "," & _
               Chr$(34) & datListing.Recordset("UnitName") & Chr$(34) & "," & _
               Chr$(34) & datListing.Recordset("UnitNameDesc") & Chr$(34) & "," & _
               Chr$(34) & gComputerName & Chr$(34) & ");"
               gBNB.Execute gSQL
               k = 1
            End If
         Next i
      ElseIf DatePart("yyyy", datListing.Recordset("arrdate")) < txtYear.Text And DatePart("yyyy", datListing.Recordset("depdate")) = txtYear.Text Then
         'Fill grid for rows where arrival is in previous year and departure is in selected year...
         'Position to correct month in grid (January)
         CurrMonth = 1 'DatePart("m", datListing.Recordset("arrdate"))
         'MsgBox CurrMonth
       '  grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
         'Set to first day in January
         vDay = 1 'DatePart("d", datListing.Recordset("arrdate"))
         'Fillin the grid from first day in January of selected year to depart date
         k = 0
         For i = 0 To datListing.Recordset("numnites") - 1
            If DatePart("yyyy", DateAdd("d", i, datListing.Recordset("arrdate"))) = txtYear.Text Then
               If IsDate(CurrMonth & "/" & vDay + k & "/" & txtYear.Text) Then
            '      grddwListing.Columns(vDay + k).Text = "B"
                  gSQL = "INSERT INTO AvailSupport (Conf,F_Name,L_Name,Month,BookDate,Year," & _
                  "Location,Unitname,UnitnameDesc,ComputerName) VALUES (" & _
                  datListing.Recordset("Conf") & "," & _
                  Chr$(34) & datListing.Recordset("F_Name") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("L_Name") & Chr$(34) & "," & _
                  CurrMonth & ",#" & _
                  CurrMonth & "/" & vDay + k & "/" & txtYear.Text & "#," & _
                  Chr$(34) & txtYear.Text & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("Location") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("UnitName") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("UnitNameDesc") & Chr$(34) & "," & _
                  Chr$(34) & gComputerName & Chr$(34) & ");"
                  gBNB.Execute gSQL
                  k = k + 1
               Else
                  CurrMonth = CurrMonth + 1
              '    grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
                  vDay = 1
                  k = 0
             '     grddwListing.Columns(vDay + k).Text = "B"
                  gSQL = "INSERT INTO AvailSupport (Conf,F_Name,L_Name,Month,BookDate,Year," & _
                  "Location,Unitname,UnitnameDesc,ComputerName) VALUES (" & _
                  datListing.Recordset("Conf") & "," & _
                  Chr$(34) & datListing.Recordset("F_Name") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("L_Name") & Chr$(34) & "," & _
                  CurrMonth & ",#" & _
                  CurrMonth & "/" & vDay + k & "/" & txtYear.Text & "#," & _
                  Chr$(34) & txtYear.Text & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("Location") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("UnitName") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("UnitNameDesc") & Chr$(34) & "," & _
                  Chr$(34) & gComputerName & Chr$(34) & ");"
                  gBNB.Execute gSQL
                  k = 1
               End If
           End If
         Next i
      ElseIf DatePart("yyyy", datListing.Recordset("arrdate")) = txtYear.Text And DatePart("yyyy", datListing.Recordset("depdate")) > txtYear.Text Then
         'Fill grid for rows where arrival is in selected year and departure is in next year...
         'Position to correct month in grid (January)
         CurrMonth = DatePart("m", datListing.Recordset("arrdate"))
         'MsgBox CurrMonth
       '  grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
         'Get arrival day
         vDay = DatePart("d", datListing.Recordset("arrdate"))
         'Fillin the grid from arrival day to end of selected year
         k = 0
         For i = 0 To datListing.Recordset("numnites") - 1
            If DatePart("yyyy", DateAdd("d", i, datListing.Recordset("arrdate"))) = txtYear.Text Then
               If IsDate(CurrMonth & "/" & vDay + k & "/" & txtYear.Text) Then
            '      grddwListing.Columns(vDay + k).Text = "B"
                  gSQL = "INSERT INTO AvailSupport (Conf,F_Name,L_Name,Month,BookDate,Year," & _
                  "Location,Unitname,UnitnameDesc,ComputerName) VALUES (" & _
                  datListing.Recordset("Conf") & "," & _
                  Chr$(34) & datListing.Recordset("F_Name") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("L_Name") & Chr$(34) & "," & _
                  CurrMonth & ",#" & _
                  CurrMonth & "/" & vDay + k & "/" & txtYear.Text & "#," & _
                  Chr$(34) & txtYear.Text & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("Location") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("UnitName") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("UnitNameDesc") & Chr$(34) & "," & _
                  Chr$(34) & gComputerName & Chr$(34) & ");"
                 gBNB.Execute gSQL
                  k = k + 1
               Else
                  CurrMonth = CurrMonth + 1
             '     grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
                  vDay = 1
                  k = 0
             '     grddwListing.Columns(vDay + k).Text = "B"
                  gSQL = "INSERT INTO AvailSupport (Conf,F_Name,L_Name,Month,BookDate,Year," & _
                  "Location,Unitname,UnitnameDesc,ComputerName) VALUES (" & _
                  datListing.Recordset("Conf") & "," & _
                  Chr$(34) & datListing.Recordset("F_Name") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("L_Name") & Chr$(34) & "," & _
                  CurrMonth & ",#" & _
                  CurrMonth & "/" & vDay + k & "/" & txtYear.Text & "#," & _
                  Chr$(34) & txtYear.Text & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("Location") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("UnitName") & Chr$(34) & "," & _
                  Chr$(34) & datListing.Recordset("UnitNameDesc") & Chr$(34) & "," & _
                  Chr$(34) & gComputerName & Chr$(34) & ");"
                  gBNB.Execute gSQL
                  k = 1
               End If
           End If
         Next i
      End If
      'MsgBox Str(datListing.Recordset("arrdate")) & ", " & datListing.Recordset("depdate")
      datListing.Recordset.MoveNext
   Next j
   'Insert unbooked dates into AvailSupport table
   For vMonth = 1 To 12
      grddwListing.Bookmark = grddwListing.AddItemBookmark(vMonth - 1)
      For vDay = 1 To 31
         If IsDate(vMonth & "/" & vDay & "/" & txtYear.Text) Then
            If grddwListing.Columns(vDay).Text = "" Then
               gSQL = "INSERT INTO AvailSupport (Conf,F_Name,L_Name,Month,BookDate,Year," & _
               "Location,UnitName,UnitNameDesc,ComputerName) VALUES (" & _
               "Null,'',''," & vMonth & ",#" & vMonth & "/" & vDay & "/" & txtYear.Text & "#,'" & txtYear.Text & _
               "'," & Chr$(34) & Trim(datdwComboProperty.Text) & Chr$(34) & ",'" & _
               Trim(datdwComboRoomType.Text) & "'," & Chr$(34) & lblUnitNameDesc.Caption & Chr$(34) & "," & Chr$(34) & gComputerName & Chr$(34) & ");"
               gBNB.Execute gSQL
            End If
         End If
      Next vDay
   Next vMonth
   mdiBNB.Report1.ReportFileName = gDBDirectory & "Avail1.rpt"
   'Since several reports are sharing the mdiBNB.Report1 control, the sort
   'array MUST be cleared out or values from previous report will be saved in the
   'array causing 'Unknown Field Name' error
   Dim vCount As Integer
   vCount = 0
   While Trim(mdiBNB.Report1.SortFields(vCount)) <> ""
     mdiBNB.Report1.SortFields(vCount) = ""
     vCount = vCount + 1
   Wend
   mdiBNB.Report1.SelectionFormula = "{AvailSupport.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
   mdiBNB.Report1.WindowMaxButton = True
   mdiBNB.Report1.Destination = 0
   mdiBNB.Report1.Action = 1
   
cmdPrintAvail_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdPrintAvail_Error:
   MsgBox Err.Description
   Resume cmdPrintAvail_Resume
   
End Sub

Private Sub datdwComboProperty_CloseUp()

   lblAcctNum.Caption = datdwComboProperty.Columns("accountnum").Text
   
End Sub

Private Sub datdwComboRoomType_Change()

   On Error GoTo datdwComboRoomType_Error
   
   Dim SSTemp As Recordset
  
   If Trim(datdwComboProperty.Text) = "" Then
     If Trim(datdwComboRoomType.Text) <> "" Then
       gMsg = "Select Property Name from the dropdown list before selecting Room Type."
       datdwComboRoomType.Text = ""
       MsgBox gMsg, MB_ICONSTOP, Me.Caption
       SSTemp.Close
       GoTo datdwComboRoomType_Resume
     End If
   Else
      Set SSTemp = gBNB.OpenRecordset("select accountnum from proptbl where PropObsolete<>-1 And location = " & Chr$(34) & datdwComboProperty.Text & Chr$(34), dbOpenSnapshot)
      GetSSRows SSTemp
      If SSTemp.RecordCount = 0 Then
         gMsg = "Property Name was entered incorrectly. Select a property name from the dropdown list."
         MsgBox gMsg, MB_ICONSTOP, Me.Caption
         SSTemp.Close
         GoTo datdwComboRoomType_Resume
      Else
         lblAcctNum.Caption = Trim(SSTemp("accountnum"))
      End If
      SSTemp.Close
  End If

datdwComboRoomType_Resume:
   Exit Sub
   
datdwComboRoomType_Error:
   Resume datdwComboRoomType_Resume

End Sub

Private Sub datdwComboRoomType_DropDown()

  If lblAcctNum.Caption = "" Then Exit Sub
  datRoomType.RecordSource = "select roomtype,roomtype_desc from HostAccount_RoomType_Link where accountnum = " & lblAcctNum.Caption
  GetDCRows datRoomType
  
End Sub

Private Sub datdwComboRoomType_InitColumnProps()
  datdwComboRoomType.Columns(0).Width = Me.TextWidth("XXXXXXXXXX")
  datdwComboRoomType.Columns(1).Width = Me.TextWidth("XXXXXXXXXXXXXXXXXXXXXXX")
End Sub

Private Sub Form_Activate()

  On Error GoTo Form_Activate_Error
  
  Dim vRoomTypeQuery As String
  Dim vWidth As Double
  Dim vHeight As Double
  'If this form is in the background (does not have focus) and the
  'Minimize button is clicked on this form that does not yet have the focus,
  'an endless loop of Minimizing and Activating will occur. The following
  'line prevents this interesting problem.
  If Me.WindowState = MINIMIZED Then Exit Sub

  If lblAcctNum.Caption = "" Then lblAcctNum.Caption = "0"
  TimesActivated = TimesActivated + 1
  If TimesActivated > 1 And Not QueryWithOKButton Then GoTo Form_Activate_Resume
  QueryWithOKButton = False
  Screen.MousePointer = HOURGLASS
  If Trim(txtYear.Text) = "" Then txtYear.Text = Trim$(DatePart("yyyy", Now))
  datProperty.RecordSource = "select location,accountnum from proptbl where PropObsolete<>-1 order by location"
  GetDCRows datProperty
  If datProperty.Recordset.RecordCount = 0 Then
     gMsg = "Cannot generate availability. Host property accounts have not been entered."
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo Form_Activate_Resume
  End If
  datdwComboProperty.Columns(0).Width = Me.TextWidth("XXXXXXXXXXXXXXXXXXXXXXXXXXX")
  datdwComboProperty.Columns(1).Width = Me.TextWidth("XXXXXXXXXXXX")
  If Trim(datdwComboRoomType.Text) = "" Then
     vRoomTypeQuery = " "
  Else
     vRoomTypeQuery = " And bbtbl.UnitName = '" & datdwComboRoomType.Text & "'"
  End If
' GetIniSettings
  gSQL = "SELECT bbtbl.conf, bbtbl.f_name, bbtbl.l_name, bbtbl.location, " & _
  "bbtbl.UnitName, bbtbl.UnitNameDesc, arrdate, depdate, numnites, " & _
  "bbtbl.accountnum " & _
  "From bbtbl, proptbl " & _
  "Where proptbl.accountnum = bbtbl.accountnum " & _
  "AND proptbl.accountnum = " & lblAcctNum.Caption & _
  "AND bbtbl.suppress <> -1 " & _
  "AND bbtbl.numnites > 0 " & _
  vRoomTypeQuery & _
  " AND " & _
  "((DatePart('yyyy',arrdate) < " & txtYear.Text & " AND DatePart('yyyy',depdate) > " & txtYear.Text & ") " & _
  "OR (DatePart('yyyy',arrdate) = " & txtYear.Text & " AND DatePart('yyyy',depdate) > " & txtYear.Text & ") " & _
  "OR (DatePart('yyyy',arrdate) < " & txtYear.Text & " AND DatePart('yyyy',depdate) = " & txtYear.Text & ") " & _
  "OR (DatePart('yyyy',arrdate) = " & txtYear.Text & " AND DatePart('yyyy',depdate) = " & txtYear.Text & ")) " & _
  " ORDER BY arrdate, depdate; "
  grddwListing.Visible = False
  'grddwListing.Enabled = False
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
  StatusMessage Me, "Loading data grid...", True
  LoadGridRows
  StatusMessage Me, "", False
  
  vWidth = 0
  vHeight = 0
  For i = 0 To grddwListing.Cols - 1
    vWidth = vWidth + grddwListing.Columns(i).Width
  Next i
  grddwListing.Width = vWidth + grddwListing.Columns(0).Width
  frmAvailability.Width = vWidth + grddwListing.Columns(0).Width * 1.5
  DoEvents

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
  
Form_Activate_Error:
MsgBox Err.Description
   Resume Form_Activate_Resume
    
    
End Sub


Public Sub LoadGridRows()

   On Error GoTo LoadGridRows_Error
   
   Dim i, j, k As Integer
   Dim TempStr As String
   Dim vMonth, vDay, vDaysInYear As Integer
   Dim CurrMonth As Integer

   For i = 0 To 31
      grddwListing.Columns(i).Caption = i
      grddwListing.Columns(i).Width = Me.TextWidth("XXX")
   Next i
   grddwListing.Columns(0).Width = Me.TextWidth("XXXXX")
   grddwListing.Columns(0).Caption = ""
   'grddwListing.Redraw = False
  ' grddwListing.Visible = False
   'Initialize grid
   grddwListing.AddItem "JAN"
   grddwListing.AddItem "FEB"
   grddwListing.AddItem "MAR"
   grddwListing.AddItem "APR"
   grddwListing.AddItem "MAY"
   grddwListing.AddItem "JUN"
   grddwListing.AddItem "JUL"
   grddwListing.AddItem "AUG"
   grddwListing.AddItem "SEP"
   grddwListing.AddItem "OCT"
   grddwListing.AddItem "NOV"
   grddwListing.AddItem "DEC"
   'Initialize grid to blank, also mark invalid dates with 'X'
   vDaysInYear = 0
   For vMonth = 1 To 12
      grddwListing.Bookmark = grddwListing.AddItemBookmark(vMonth - 1)
      For vDay = 1 To 31
         grddwListing.Font.Bold = True
         If IsDate(vMonth & "/" & vDay & "/" & txtYear.Text) Then
            vDaysInYear = vDaysInYear + 1
            grddwListing.Columns(vDay).Text = ""
         Else
            grddwListing.Columns(vDay).Text = "X"
         End If
      Next vDay
   Next vMonth
   'MsgBox Str(vDaysInYear)
   'Position to first month in grid
   grddwListing.Bookmark = grddwListing.AddItemBookmark(0)
   If datListing.Recordset.RecordCount = 0 Then
      cmdPrintAvail.Enabled = False
   Else
      cmdPrintAvail.Enabled = True
   End If
   For j = 0 To datListing.Recordset.RecordCount - 1
      If DatePart("yyyy", datListing.Recordset("arrdate")) = txtYear.Text And DatePart("yyyy", datListing.Recordset("depdate")) = txtYear.Text Then
         'Fill grid for rows where arrival and departure dates are both in selected year.
         'Position to correct month in grid
         CurrMonth = DatePart("m", datListing.Recordset("arrdate"))
         'MsgBox CurrMonth
         grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
         'Find the arrival day
         vDay = DatePart("d", datListing.Recordset("arrdate"))
         'Fillin the columns from arrival date to depart date
         k = 0
         For i = 0 To datListing.Recordset("numnites") - 1
            If IsDate(CurrMonth & "/" & vDay + k & "/" & txtYear.Text) Then
               grddwListing.Columns(vDay + k).Text = "B"
               k = k + 1
            Else
               CurrMonth = CurrMonth + 1
               grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
               vDay = 1
               k = 0
               grddwListing.Columns(vDay + k).Text = "B"
               k = 1
            End If
         Next i
      ElseIf DatePart("yyyy", datListing.Recordset("arrdate")) < txtYear.Text And DatePart("yyyy", datListing.Recordset("depdate")) = txtYear.Text Then
         'Fill grid for rows where arrival is in previous year and departure is in selected year...
         'Position to correct month in grid (January)
         CurrMonth = 1 'DatePart("m", datListing.Recordset("arrdate"))
         'MsgBox CurrMonth
         grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
         'Set to first day in January
         vDay = 1 'DatePart("d", datListing.Recordset("arrdate"))
         'Fillin the grid from first day in January of selected year to depart date
         k = 0
         For i = 0 To datListing.Recordset("numnites") - 1
            If DatePart("yyyy", DateAdd("d", i, datListing.Recordset("arrdate"))) = txtYear.Text Then
               If IsDate(CurrMonth & "/" & vDay + k & "/" & txtYear.Text) Then
                  grddwListing.Columns(vDay + k).Text = "B"
                  k = k + 1
               Else
                  CurrMonth = CurrMonth + 1
                  grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
                  vDay = 1
                  k = 0
                  grddwListing.Columns(vDay + k).Text = "B"
                  k = 1
               End If
           End If
         Next i
      ElseIf DatePart("yyyy", datListing.Recordset("arrdate")) = txtYear.Text And DatePart("yyyy", datListing.Recordset("depdate")) > txtYear.Text Then
         'Fill grid for rows where arrival is in selected year and departure is in next year...
         'Position to correct month in grid (January)
         CurrMonth = DatePart("m", datListing.Recordset("arrdate"))
         'MsgBox CurrMonth
         grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
         'Get arrival day
         vDay = DatePart("d", datListing.Recordset("arrdate"))
         'Fillin the grid from arrival day to end of selected year
         k = 0
         For i = 0 To datListing.Recordset("numnites") - 1
            If DatePart("yyyy", DateAdd("d", i, datListing.Recordset("arrdate"))) = txtYear.Text Then
               If IsDate(CurrMonth & "/" & vDay + k & "/" & txtYear.Text) Then
                  grddwListing.Columns(vDay + k).Text = "B"
                  k = k + 1
               Else
                  CurrMonth = CurrMonth + 1
                  grddwListing.Bookmark = grddwListing.AddItemBookmark(CurrMonth - 1)
                  vDay = 1
                  k = 0
                  grddwListing.Columns(vDay + k).Text = "B"
                  k = 1
               End If
           End If
         Next i
      End If
      'MsgBox Str(datListing.Recordset("arrdate")) & ", " & datListing.Recordset("depdate")
      datListing.Recordset.MoveNext
   Next j
   grddwListing.Bookmark = grddwListing.AddItemBookmark(0)
   grddwListing.MoveFirst
   grddwListing.Redraw = True
   grddwListing.Visible = True
   
LoadGridRows_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub
   
LoadGridRows_Error:
   Resume LoadGridRows_Resume
    
End Sub

Private Sub Form_Load()

  On Error GoTo Load_Error

  TimesActivated = 0
  datListing.DatabaseName = gDatabaseName
  datProperty.DatabaseName = gDatabaseName
  datRoomType.DatabaseName = gDatabaseName
  
Load_Resume:
   Exit Sub

Load_Error:
   Resume Load_Resume
  
End Sub


Private Sub Form_Resize()
   pnlMessage.Move grddwListing.Left, grddwListing.Top, grddwListing.Width, grddwListing.Height

End Sub




Private Sub Form_Unload(Cancel As Integer)
   gBNB.Execute "delete from AvailSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
End Sub

Private Sub grddwListing_InitColumnProps()

'Dim vWidth As Double
'Dim i As Integer
'vWidth = 0
'For i = 0 To grddwListing.Cols - 1
'  vWidth = vWidth + grddwListing.Columns(i).Width
'Next i
'grddwListing.Width = vWidth


End Sub

Private Sub SpinButton1_SpinDown()

   If txtYear.Text <> "" Then
      txtYear.Text = Trim(CInt(txtYear.Text) - 1)
   Else
      txtYear.Text = CInt(Trim$(DatePart("yyyy", Now))) - 1
   End If

End Sub

Private Sub SpinButton1_SpinUp()

   If txtYear.Text <> "" Then
      txtYear.Text = Trim(CInt(txtYear.Text) + 1)
   Else
      txtYear.Text = CInt(Trim$(DatePart("yyyy", Now))) + 1
   End If
   
End Sub


