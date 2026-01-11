VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{BC496AED-9B4E-11CE-A6D5-0000C0BE9395}#2.0#0"; "SSDATB32.OCX"
Object = "{00025600-0000-0000-C000-000000000046}#5.1#0"; "CRYSTL32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmCommissionDlg 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Commission Report Dialog Box"
   ClientHeight    =   4725
   ClientLeft      =   1770
   ClientTop       =   2280
   ClientWidth     =   4890
   HelpContextID   =   118
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4725
   ScaleWidth      =   4890
   Tag             =   "checktbl"
   Begin VB.Data datPropertyName 
      Appearance      =   0  'Flat
      Caption         =   "datPropertyName"
      Connect         =   "Access"
      DatabaseName    =   ""
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   315
      Left            =   1320
      Options         =   0
      ReadOnly        =   -1  'True
      RecordsetType   =   2  'Snapshot
      RecordSource    =   ""
      Top             =   4920
      Visible         =   0   'False
      Width           =   3075
   End
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   195
      Left            =   60
      TabIndex        =   11
      Top             =   3990
      Width           =   2355
      _Version        =   65536
      _ExtentX        =   4154
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "Sa&ve settings on Exit"
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
   Begin Threed.SSCheck chkDisplayOnly 
      Height          =   195
      Left            =   60
      TabIndex        =   10
      Top             =   3690
      Width           =   2355
      _Version        =   65536
      _ExtentX        =   4154
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "&Display report to screen only"
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
   Begin VB.Frame fraShow 
      Caption         =   "Show Payments"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2055
      Left            =   1620
      TabIndex        =   16
      Top             =   120
      Width           =   3135
      Begin VB.OptionButton optDueAndRec 
         Caption         =   "Due and Received"
         Height          =   255
         Left            =   120
         TabIndex        =   5
         Top             =   720
         Width           =   2715
      End
      Begin VB.OptionButton optDueOnly 
         Caption         =   "Due Only"
         Height          =   195
         Left            =   120
         TabIndex        =   4
         Top             =   360
         Width           =   2715
      End
      Begin SSDataWidgets_B.SSDBCombo datdwComboProperty 
         Bindings        =   "Commish.frx":0000
         Height          =   315
         Left            =   120
         TabIndex        =   19
         Tag             =   "Text"
         Top             =   1440
         Width           =   2295
         DataFieldList   =   "location"
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
         _ExtentX        =   4048
         _ExtentY        =   556
         _StockProps     =   93
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         DataFieldToDisplay=   "location"
      End
      Begin VB.Label lblSelAccount 
         Caption         =   "For an individual account:"
         Height          =   195
         Left            =   120
         TabIndex        =   22
         Top             =   1200
         Width           =   2835
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
      Height          =   345
      Left            =   120
      TabIndex        =   12
      Top             =   4350
      Width           =   1215
   End
   Begin VB.CommandButton cmdPrinterSetup 
      Caption         =   "P&rinter..."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      Left            =   1800
      TabIndex        =   13
      Top             =   4350
      Width           =   1215
   End
   Begin VB.CommandButton cmdPrint 
      Caption         =   "&Print"
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
      Height          =   345
      Left            =   3480
      TabIndex        =   14
      Top             =   4350
      Width           =   1215
   End
   Begin Crystal.CrystalReport CommishReport1 
      Left            =   660
      Top             =   4830
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   348160
      WindowMaxButton =   0   'False
      WindowState     =   2
      PrintFileLinesPerPage=   60
      WindowShowCloseBtn=   -1  'True
      WindowShowSearchBtn=   -1  'True
      WindowShowPrintSetupBtn=   -1  'True
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   180
      Top             =   4830
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Frame fraDateRange 
      Caption         =   "Date Range"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1275
      Left            =   60
      TabIndex        =   15
      Top             =   2280
      Width           =   4695
      Begin VB.OptionButton optDepartureDate 
         Caption         =   "Departure Date"
         Height          =   195
         Left            =   120
         TabIndex        =   9
         Top             =   960
         Width           =   2055
      End
      Begin VB.OptionButton optArrivalDate 
         Caption         =   "Arrival Date"
         Height          =   195
         Left            =   120
         TabIndex        =   8
         Top             =   660
         Width           =   2115
      End
      Begin VB.TextBox txtEndDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2760
         TabIndex        =   7
         Tag             =   "Date"
         Top             =   300
         Width           =   1035
      End
      Begin VB.TextBox txtStartDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   6
         Tag             =   "Date"
         Top             =   300
         Width           =   1035
      End
      Begin VB.Label lblEndDate 
         Caption         =   "through"
         Height          =   195
         Left            =   2160
         TabIndex        =   18
         Top             =   360
         Width           =   555
      End
      Begin VB.Label lblStartDate 
         Caption         =   "Start Date:"
         Height          =   195
         Left            =   180
         TabIndex        =   17
         Top             =   360
         Width           =   795
      End
   End
   Begin VB.Frame fraCategory 
      Caption         =   "Category"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2055
      Left            =   60
      TabIndex        =   0
      Top             =   120
      Width           =   1455
      Begin VB.OptionButton optCar 
         Caption         =   "Car"
         Height          =   225
         Left            =   120
         TabIndex        =   3
         Top             =   1320
         Width           =   1095
      End
      Begin VB.OptionButton optTravel 
         Caption         =   "Travel"
         Height          =   195
         Left            =   120
         TabIndex        =   2
         Top             =   840
         Width           =   1095
      End
      Begin VB.OptionButton optHost 
         Caption         =   "Host"
         Height          =   195
         Left            =   120
         TabIndex        =   1
         Top             =   360
         Width           =   1095
      End
   End
   Begin VB.Label Label2 
      Caption         =   "Label2"
      Height          =   495
      Left            =   1800
      TabIndex        =   21
      Top             =   2520
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "Label1"
      Height          =   495
      Left            =   1800
      TabIndex        =   20
      Top             =   2520
      Width           =   1215
   End
End
Attribute VB_Name = "frmCommissionDlg"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim SAW As Long
Private Sub cmdExit_Click()
   Unload Me
End Sub

Private Sub cmdPrint_Click()
    
  'This Sub will drive the Crystal report Commish1.rpt based upon
  'user settings on the frmCheckLedger dialog box form.
  On Error GoTo cmdPrint_Click_Error

  Screen.MousePointer = HOURGLASS
  'Validate date and number formats here
  If Not VerifyUpdate() Then
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  End If
  
  Dim SSTemp As Recordset
  Dim SSTemp2 As Recordset
  Dim SSTemp3 As Recordset
  Dim vTempSum As Currency
  Dim vNowTemp As Date
  Dim vNumMonths As Integer
  Dim vSYear, vSMonth, vSDay As String
  Dim vEYear, vEMonth, vEDay As String
  Dim vStartDate, vEndDate, vCategory As String
  Dim QueryTemp As String
  Dim vSelectConfs, vSelectConfsForRpt As String
  
  If Trim(txtStartDate.Text) = "" Then
     MsgBox "Starting Date cannot be blank.", MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  End If
  'Get category option
  If optHost.Value = CHECKED Then
     vCategory = "Host"
  ElseIf optTravel.Value = CHECKED Then
     vCategory = "Travel"
  ElseIf optCar.Value = CHECKED Then
     vCategory = "Car"
  Else
     MsgBox "Category has not been selected.", MB_ICONSTOP, Me.Caption
     GoTo cmdPrint_Click_Resume
  End If

  If Trim(txtEndDate.Text) <> "" Then
     If CDate(txtStartDate.Text) > CDate(txtEndDate.Text) Then
        MsgBox "Starting Date cannot be greater than ending date.", MB_ICONSTOP, Me.Caption
        GoTo cmdPrint_Click_Resume
     End If
     vEndDate = Format(Trim(txtEndDate.Text), "mm/dd/yyyy")
     vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
     vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
     vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
  End If
  'Dont allow users to click anything
  'Me.Enabled = False
  Screen.MousePointer = HOURGLASS
  vStartDate = Format(Trim(txtStartDate.Text), "mm/dd/yyyy")
  'Set start year values
  vSYear = DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy"))
  vSMonth = DatePart("m", Format(vStartDate, "mm/dd/yyyy"))
  vSDay = DatePart("d", Format(vStartDate, "mm/dd/yyyy"))
  'Clear out support table
  gBNB.Execute "delete from TACommReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34) & ";"
  datdwComboProperty.Text = Trim(datdwComboProperty.Text)
  If optHost.Value = CHECKED Then
     If optDueOnly.Value = CHECKED Then
        QueryTemp = "And {bbtbl.commish} <> 0 And (IsNull({bbtbl.comm_paid}) Or {bbtbl.commish} <> {bbtbl.comm_paid}) "
     ElseIf optDueAndRec.Value = CHECKED Then
        QueryTemp = "And {bbtbl.commish} <> 0 "
     End If
     If vEndDate <> "" Then
        If optArrivalDate.Value = CHECKED Then
           'Use the support table just to hold the conf numbers of interest.
           gSQL = "insert into TACommReportSupport(conf, SumTACommish,MinArrDate,MaxDepDate,ComputerName) " & _
               "select distinct bbtbl.conf,Null,Null,Null," & Chr$(34) & gComputerName & Chr$(34) & _
               " from bbtbl where arrdate >= #" & vStartDate & "# and arrdate <= #" & vEndDate & "# " & _
               "And bbtbl.commish <> 0 "
        ElseIf optDepartureDate.Value = CHECKED Then
           'Use the support table just to hold the conf numbers of interest.
           gSQL = "insert into TACommReportSupport(conf, SumTACommish,MinArrDate,MaxDepDate,ComputerName) " & _
               "select distinct bbtbl.conf,Null,Null,Null," & Chr$(34) & gComputerName & Chr$(34) & _
               " from bbtbl where depdate >= #" & vStartDate & "# and depdate <= #" & vEndDate & "# " & _
               "And bbtbl.commish <> 0 "
        End If
     Else  'Ending date is blank
        If optArrivalDate.Value = CHECKED Then
           'Use the support table just to hold the conf numbers of interest.
           gSQL = "insert into TACommReportSupport(conf, SumTACommish,MinArrDate,MaxDepDate,ComputerName) " & _
               "select distinct bbtbl.conf,Null,Null,Null," & Chr$(34) & gComputerName & Chr$(34) & _
               " from bbtbl where arrdate >= #" & vStartDate & "# " & _
               "And bbtbl.commish <> 0 "
        ElseIf optDepartureDate.Value = CHECKED Then
           'Use the support table just to hold the conf numbers of interest.
           gSQL = "insert into TACommReportSupport(conf, SumTACommish,MinArrDate,MaxDepDate,ComputerName) " & _
               "select distinct bbtbl.conf,Null,Null,Null," & Chr$(34) & gComputerName & Chr$(34) & _
               " from bbtbl where depdate >= #" & vStartDate & "# " & _
               "And bbtbl.commish <> 0 "
        End If
     End If
     
     If datdwComboProperty.Text <> "" Then
        gSQL = gSQL & " And bbtbl.accountnum=" & datdwComboProperty.Columns(1).Value & " "
     End If
     
     gBNB.Execute gSQL
     CommishReport1.SelectionFormula = "{TACommReportSupport.conf}={bbtbl.conf} " & _
                      " And ({bbtbl.suppress}<>-1 or ({bbtbl.suppress}=-1 And {bbtbl.forfeit}=-1)) " & _
                      " And {TACommReportSupport.ComputerName} = '" & _
                       gComputerName & "' " & QueryTemp
  ElseIf optTravel.Value = CHECKED Then
     'Comm due from Host and Comm Received from Host are all in the same
     'table (bbtbl) for Host payments. This is not so with T/A payments.
     'T/A payments are in checktbl and for each conf, they must be summed and
     'compared with Commdue in tagentbl. This is done with the help of a support
     'table (TACommReportSupport) and a Temp (GetNextTableName()) table below.
     If vEndDate <> "" Then
        If optArrivalDate.Value = CHECKED Then
           vSelectConfs = "SELECT DISTINCT conf FROM bbtbl " & _
                          "WHERE [bbtbl].[arrdate] >= #" & vStartDate & "# " & _
                          "and [bbtbl].[arrdate] <= #" & vEndDate & "#"
        ElseIf optDepartureDate.Value = CHECKED Then
           vSelectConfs = "SELECT DISTINCT conf FROM bbtbl " & _
                          "WHERE [bbtbl].[depdate] >= #" & vStartDate & "# " & _
                          "and [bbtbl].[depdate] <= #" & vEndDate & "#"
        End If
     Else 'Ending date is blank
        If optArrivalDate.Value = CHECKED Then
           vSelectConfs = "SELECT DISTINCT conf FROM bbtbl " & _
                          "WHERE [bbtbl].[arrdate] >= #" & vStartDate & "#"
        ElseIf optDepartureDate.Value = CHECKED Then
           vSelectConfs = "SELECT DISTINCT conf FROM bbtbl " & _
                          "WHERE [bbtbl].[depdate] >= #" & vStartDate & "#"
        End If
     End If
     'Temp table to hold CONF and SUM(trueamt)
     If GetNextTableName() Then
        Dim TableSum As String
        TableSum = gTableName
     Else
        MsgBox gMsg
        GoTo cmdPrint_Click_Resume
     End If
     'Temp table to hold CONF's of interest
     If GetNextTableName() Then
        Dim TableSum2 As String
        TableSum2 = gTableName
     Else
        MsgBox gMsg
        GoTo cmdPrint_Click_Resume
     End If
     gBNB.Execute "CREATE TABLE " & TableSum2 & " (conf LONG);"
     gSQL = "insert into " & TableSum2 & "(conf) " & vSelectConfs
     gBNB.Execute gSQL
     gBNB.Execute "CREATE TABLE " & TableSum & " (conf LONG, SumAmt CURRENCY);"
     gSQL = "insert into " & TableSum & "(conf, SumAmt) " & _
            "select distinct [tagentbl].[conf],sum([checktbl].[trueamt]) " & _
            "from tagentbl,checktbl," & TableSum2 & " " & _
            "WHERE tagentbl.conf=checktbl.conf " & _
            "and [tagentbl].[conf] = " & TableSum2 & ".conf " & _
            "and [checktbl].[CheckCategory]='Travel' " & _
            "and [checktbl].[void_chk]<>-1 "
     If datdwComboProperty.Text <> "" Then
        gSQL = gSQL & " And [tagentbl].[accountnum]=" & datdwComboProperty.Columns(1).Value & " "
     End If
     gSQL = gSQL & "group by [tagentbl].[conf];"
     gBNB.Execute gSQL
     gSQL = "insert into TACommReportSupport(conf, SumTACommish,MinArrDate,MaxDepDate,ComputerName) " & _
            "select tagentbl.conf," & TableSum & ".SumAmt,Null,Null," & Chr$(34) & gComputerName & Chr$(34) & _
            " from bbtbl INNER JOIN (" & TableSum2 & " INNER JOIN (tagentbl " & _
            "LEFT JOIN " & TableSum & " ON tagentbl.conf=" & TableSum & ".conf) " & _
            "ON " & TableSum2 & ".conf=tagentbl.conf) " & _
            "ON  bbtbl.conf=" & TableSum2 & ".conf " & _
            "group by tagentbl.conf," & TableSum & ".SumAmt;"
            '!!!Aggregates must be in group
     gBNB.Execute gSQL
     'Update Commissionable field with sum of (GrosRate*NumNites)*GrosRatePercent
     'for each valid (non-cancel OR cancel w/ forfeit) accommodation row.
     gSQL = "select conf from TACommReportSupport where not isnull(conf)"
     Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
     GetSSRows SSTemp
     If SSTemp.RecordCount > 0 Then
        SSTemp.MoveFirst
        While Not SSTemp.EOF
           gSQL = "select GrosRate,NumNites,GrosRatePercent " & _
                  "From bbtbl INNER JOIN proptbl ON bbtbl.accountnum=proptbl.accountnum " & _
                  "Where bbtbl.conf=" & SSTemp("conf") & _
                  " And (bbtbl.suppress<>-1 Or (bbtbl.suppress=-1 And bbtbl.forfeit=-1))"
           Set SSTemp2 = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
           GetSSRows SSTemp2
           If SSTemp2.RecordCount > 0 Then
              vTempSum = 0
              SSTemp2.MoveFirst
              While Not SSTemp2.EOF
                 If Not IsNull(SSTemp2("GrosRate")) And Not IsNull(SSTemp2("NumNites")) And Not IsNull(SSTemp2("GrosRatePercent")) Then
                    vTempSum = vTempSum + (SSTemp2("GrosRate") * SSTemp2("NumNites") * (SSTemp2("GrosRatePercent") / 100))
                 End If
                 SSTemp2.MoveNext
              Wend
              'Update TACommReportSupport with Commissionable amount.
              gSQL = "update TACommReportSupport " & _
                     "set Commissionable = " & vTempSum & _
                     " where conf = " & SSTemp("conf") & _
                     " And ComputerName=" & Chr$(34) & gComputerName & Chr$(34)
              gBNB.Execute gSQL
           Else
              gSQL = "update TACommReportSupport set Commissionable = 0 " & _
                     "where conf = " & SSTemp("conf") & _
                     " And ComputerName=" & Chr$(34) & gComputerName & Chr$(34)
           End If
           'Update the Min Arrival and Max Departure dates for this conf#
           gSQL = "select Min(ArrDate),Max(DepDate) " & _
                  "from bbtbl " & _
                  "where conf=" & SSTemp("conf") & _
                  " And (bbtbl.suppress<>-1 Or (bbtbl.suppress=-1 And bbtbl.forfeit=-1)) "
           Set SSTemp3 = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
           GetSSRows SSTemp3
           If SSTemp3.RecordCount > 0 Then
              If Not IsNull(SSTemp3(0)) And Not IsNull(SSTemp3(1)) Then
                 gSQL = "update TACommReportSupport " & _
                        "set MinArrDate=#" & SSTemp3(0) & _
                        "#,MaxDepDate=#" & SSTemp3(1) & _
                        "# where conf = " & SSTemp("conf") & _
                        " And ComputerName=" & Chr$(34) & gComputerName & Chr$(34)
                 gBNB.Execute gSQL
              End If
           End If
           SSTemp3.Close
           SSTemp2.Close
           SSTemp.MoveNext
        Wend
     End If
     SSTemp.Close
     If optDueOnly.Value = CHECKED Then
        CommishReport1.SelectionFormula = _
        "{TACommReportSupport.Conf}={tagentbl.conf} " & _
        "And {payment.conf}={tagentbl.conf} " & _
        "And {TACommReportSupport.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34) & _
        " And {tagentbl.commdue}<>0 " & _
        "And ((IsNull({TACommReportSupport.SumTACommish}) And Not IsNull({payment.defcom}) " & _
        "And {payment.defcom}<>{tagentbl.commdue}) " & _
        "Or (Not IsNull({TACommReportSupport.SumTACommish}) And Not IsNull({payment.defcom}) " & _
        "And {TACommReportSupport.SumTACommish}+{payment.defcom}<>{tagentbl.commdue}) " & _
        "Or (Not IsNull({TACommReportSupport.SumTACommish}) And IsNull({payment.defcom}) " & _
        "And {TACommReportSupport.SumTACommish}<>{tagentbl.commdue}) " & _
        "Or (IsNull({TACommReportSupport.SumTACommish}) And IsNull({payment.defcom})))"
     ElseIf optDueAndRec.Value = CHECKED Then
        CommishReport1.SelectionFormula = "{tagentbl.commdue} <> 0 " & _
                    "And {tagentbl.conf} = {TACommReportSupport.Conf} " & _
                    "And {TACommReportSupport.ComputerName} = " & Chr$(34) & gComputerName & Chr$(34)
     End If
     If datdwComboProperty.Text <> "" Then
        CommishReport1.SelectionFormula = CommishReport1.SelectionFormula & " And {tagentbl.accountnum}=" & datdwComboProperty.Columns(1).Value & " "
     End If
     'MsgBox CommishReport1.SelectionFormula
  ElseIf optCar.Value = CHECKED Then
     If optDueOnly.Value = CHECKED Then
        QueryTemp = "And {cartbl.commishdue} <> 0 And (IsNull({cartbl.AmountReceived}) Or {cartbl.commishdue} <> {cartbl.AmountReceived}) "
     ElseIf optDueAndRec.Value = CHECKED Then
        QueryTemp = "And {cartbl.commishdue} <> 0 "
     End If
     If datdwComboProperty.Text <> "" Then
        QueryTemp = QueryTemp & " And {cartbl.accountnum}=" & datdwComboProperty.Columns(1).Value & " "
     End If
     
     If vEndDate <> "" Then
        If optArrivalDate.Value = CHECKED Then
           vSelectConfs = "where [cartbl].[pudate] >= #" & vStartDate & "# " & _
                          "and [cartbl].[pudate] <= #" & vEndDate & "#"
           vSelectConfsForRpt = " And {cartbl.PUDate} >= Date(" & _
                                 DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("m", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("d", Format(vStartDate, "mm/dd/yyyy")) & ") " & _
                                 "And {cartbl.PUDate} <= Date(" & _
                                 DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("m", Format(vEndDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("d", Format(vEndDate, "mm/dd/yyyy")) & ")"
        ElseIf optDepartureDate.Value = CHECKED Then
           vSelectConfs = "where [cartbl].[dropdate] >= #" & vStartDate & "# " & _
                          "and [cartbl].[dropdate] <= #" & vEndDate & "#"
           vSelectConfsForRpt = " And {cartbl.DropDate} >= Date(" & _
                                 DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("m", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("d", Format(vStartDate, "mm/dd/yyyy")) & ") " & _
                                 "And {cartbl.DropDate} <= Date(" & _
                                 DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("m", Format(vEndDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("d", Format(vEndDate, "mm/dd/yyyy")) & ")"
        End If
     Else 'Ending date is blank
        If optArrivalDate.Value = CHECKED Then
           vSelectConfs = "where [cartbl].[pudate] >= #" & vStartDate & "#"
           vSelectConfsForRpt = " And {cartbl.PUDate} >= Date(" & _
                                 DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("m", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("d", Format(vStartDate, "mm/dd/yyyy")) & ") "
        ElseIf optDepartureDate.Value = CHECKED Then
           vSelectConfs = "where [cartbl].[dropdate] >= #" & vStartDate & "#"
           vSelectConfsForRpt = " And {cartbl.DropDate} >= Date(" & _
                                 DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("m", Format(vStartDate, "mm/dd/yyyy")) & "," & _
                                 DatePart("d", Format(vStartDate, "mm/dd/yyyy")) & ")"
        End If
     End If
     gSQL = "insert into TACommReportSupport(conf, SumTACommish,MinArrDate,MaxDepDate,ComputerName) " & _
            "select [cartbl].[conf],Null,min(cartbl.pudate),max(cartbl.dropdate)," & Chr$(34) & gComputerName & Chr$(34) & _
            " from cartbl " & _
            vSelectConfs & " group by [cartbl].[conf];"
            '!!!Aggregates must be in group
     gBNB.Execute gSQL
     CommishReport1.SelectionFormula = "{TACommReportSupport.conf}={cartbl.conf} " & _
                       " And {TACommReportSupport.ComputerName} = '" & _
                       gComputerName & "' " & QueryTemp & vSelectConfsForRpt
     'MsgBox CommishReport1.SelectionFormula
  End If
  'Setup report options
  'CommishReport1.WindowMinButton = False
  'Set Sort order
  'Since several reports are sharing the mdiBNB.Report1 control, the sort
  'array MUST be cleared out or values from previous report will be saved in the
  'array causing 'Unknown Field Name' error
  Dim vCount As Integer
  vCount = 0
  While Trim(CommishReport1.SortFields(vCount)) <> ""
    CommishReport1.SortFields(vCount) = ""
    vCount = vCount + 1
  Wend
  If optArrivalDate.Value = CHECKED Then
    If optHost.Value = CHECKED Then
      CommishReport1.SortFields(0) = "+{bbtbl.arrdate}"
    ElseIf optCar.Value = CHECKED Then
      CommishReport1.SortFields(0) = "+{cartbl.accountnum}"
      CommishReport1.SortFields(1) = "+{cartbl.PUDate}"
      CommishReport1.SortFields(2) = "+{cartbl.conf}"
    Else
      CommishReport1.SortFields(0) = "+{TACommReportSupport.MinArrDate}"
    End If
  ElseIf optDepartureDate.Value = CHECKED Then
    If optHost.Value = CHECKED Then
      CommishReport1.SortFields(0) = "+{bbtbl.depdate}"
    ElseIf optCar.Value = CHECKED Then
      CommishReport1.SortFields(0) = "+{cartbl.accountnum}"
      CommishReport1.SortFields(1) = "+{cartbl.DropDate}"
      'CommishReport1.SortFields(1) = "+{TACommReportSupport.MaxDepDate}"
    Else
      CommishReport1.SortFields(0) = "+{TACommReportSupport.MaxDepDate}"
    End If
  End If
  
  If optHost.Value = CHECKED Then
     CommishReport1.ReportFileName = gDBDirectory & "Commish1.rpt"
  ElseIf optTravel.Value = CHECKED Then
     CommishReport1.ReportFileName = gDBDirectory & "Commish2.rpt"
  ElseIf optCar.Value = CHECKED Then
     CommishReport1.ReportFileName = gDBDirectory & "Commish3.rpt"
  End If
  CommishReport1.DataFiles(0) = gDatabaseName
  If chkDisplayOnly.Value = CHECKED Then
     CommishReport1.Destination = 0
  Else
     CommishReport1.Destination = 1
  End If
  'Print report for current Account Num.
  CommishReport1.Action = 1
  'Clear out support table
  gBNB.Execute "delete from TACommReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34) & ";"

cmdPrint_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdPrint_Click_Error:
   MsgBox Err.Description
   GoTo cmdPrint_Click_Resume
   
End Sub

Private Sub cmdPrinterSetup_Click()
   
   On Error GoTo cmdPrint_Error
   
   'Generate error if use clicks on Cancel.
   CMDialog1.CancelError = True
   'Show printer setup box instead of printer dialog box.
   CMDialog1.Flags = cdlPDPrintSetup
   'Activate Printer Dialog Box
   CMDialog1.ShowPrinter
   'Invoke changes on printer object.
   Printer.EndDoc
 
cmdPrinterSetup_Click_Resume:
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
    Resume cmdPrinterSetup_Click_Resume
   
End Sub

Private Sub datdwComboProperty_DropDown()

datdwComboProperty.DefColWidth = datdwComboProperty.Width * 1.2
If optCar.Value = True Then
   datPropertyName.RecordSource = "select agencyname as location,AccountNum from CarMaster order by agencyname"
End If
If optHost.Value = True Then
   datPropertyName.RecordSource = "select location,AccountNum from proptbl where PropObsolete<>-1 order by location"
End If
If optTravel.Value = True Then
   datPropertyName.RecordSource = "select agencyname as location,AccountNum,address,city,state from TAMASTER order by agencyname"
End If
If Not GetDCRows(datPropertyName) Then Exit Sub

End Sub

Private Sub Form_Activate()
   
'If this form is in the background (does not have focus) and the
'Minimize button is clicked on this form that does not yet have the focus,
'an endless loop of Minimizing and Activating will occur. The following
'line prevents this interesting problem.
If Me.WindowState = MINIMIZED Then Exit Sub

GetIniSettings
Screen.MousePointer = DEFAULT
   
End Sub

Private Sub Form_Load()
   datPropertyName.DatabaseName = gDatabaseName
   Screen.MousePointer = HOURGLASS
End Sub


Private Sub Form_Unload(Cancel As Integer)
   
   On Error GoTo Form_Unload_Error
   
   Screen.MousePointer = HOURGLASS
   'Clear out support table
   gBNB.Execute "delete from TACommReportSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34) & ";"
   WriteIniSettings

Form_Unload_Resume:
   Screen.MousePointer = DEFAULT
   Dim X&
   X& = SetActiveWindow(mdiBNB.hwnd)
   Exit Sub
   
Form_Unload_Error:
  GoTo Form_Unload_Resume
  
End Sub

Private Sub optCar_Click()
   optDueOnly.Caption = "Due from Rental Agency Only"
   optDueAndRec.Caption = "Due and Received from Agency"
   datdwComboProperty.Text = ""
End Sub

Private Sub optHost_Click()
   optDueOnly.Caption = "Due from Host Only"
   optDueAndRec.Caption = "Due and Received from Host"
   datdwComboProperty.Text = ""
End Sub

Private Sub optTravel_Click()
   optDueOnly.Caption = "Due to Travel Agency Only"
   optDueAndRec.Caption = "Due and Paid to Agency"
   datdwComboProperty.Text = ""
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

Public Sub WriteIniSettings()

    'Declare variables
    Dim X As Integer        'Return Value
    Dim winDir, iniFile, Temp As String
    'Get the directory in which the Windows and the .INI files reside.
    'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())
    'Determine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"
'SAVE SETTINGS (always save this)
    'Write the Save Settings check box setting to the .INI file.
'MsgBox Str(chkSaveSettings.Value)
    If chkSaveSettings.Value = CHECKED Then
        X = WritePrivateProfileString("Commission Report", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Commission Report", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Commission Report", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub
   ' X = WritePrivateProfileString("Net Summary Report", "ShowTop", Format$(txtShowTop.Text), iniFile)
    X = WritePrivateProfileString("Commission Report", "Host", Format$(optHost.Value), iniFile)
    X = WritePrivateProfileString("Commission Report", "Travel", Format$(optTravel.Value), iniFile)
    X = WritePrivateProfileString("Commission Report", "Car", Format$(optCar.Value), iniFile)
    X = WritePrivateProfileString("Commission Report", "DueOnly", Format$(optDueOnly), iniFile)
    X = WritePrivateProfileString("Commission Report", "DueAndRec", Format$(optDueAndRec.Value), iniFile)
    X = WritePrivateProfileString("Commission Report", "ArrivalDate", Format$(optArrivalDate.Value), iniFile)
    X = WritePrivateProfileString("Commission Report", "DepartureDate", Format$(optDepartureDate.Value), iniFile)
    X = WritePrivateProfileString("Commission Report", "DisplayOnly", Format$(chkDisplayOnly.Value), iniFile)
    X = WritePrivateProfileString("Commission Report", "StartDate", txtStartDate.Text, iniFile)
    X = WritePrivateProfileString("Commission Report", "EndDate", txtEndDate.Text, iniFile)
   ' x = WritePrivateProfileString("Confirmation Report", "ConfirmToOther", Format$(optOther.Value), iniFile)

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
    'Determine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"

   ' X = GetPrivateProfileString("Commission Report", "ShowTop", "100", Rs, Len(Rs), iniFile)
   ' If X > 0 Then txtShowTop.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Commission Report", "Host", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optHost.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Commission Report", "Travel", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optTravel.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Commission Report", "Car", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optCar.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Commission Report", "DueOnly", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optDueOnly.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Commission Report", "DueAndRec", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optDueAndRec.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Commission Report", "ArrivalDate", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optArrivalDate.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Commission Report", "DepartureDate", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optDepartureDate.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Commission Report", "StartDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtStartDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Commission Report", "EndDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtEndDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Commission Report", "DisplayOnly", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then chkDisplayOnly.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
      
   ' x = GetPrivateProfileString("Confirmation Report", "ConfirmToOther", "False", Rs, Len(Rs), iniFile)
   ' If x > 0 Then optOther.Value = Left$(Rs, x)     ' Trim Buffer. a string was returned.
'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Commission Report", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
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

