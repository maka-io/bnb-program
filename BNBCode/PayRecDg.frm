VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Begin VB.Form frmPayRecDlg 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Payments Received Dialog Box"
   ClientHeight    =   4944
   ClientLeft      =   3372
   ClientTop       =   1488
   ClientWidth     =   3984
   HelpContextID   =   127
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4944
   ScaleWidth      =   3984
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   195
      Left            =   60
      TabIndex        =   8
      Top             =   4140
      Width           =   1935
      _Version        =   65536
      _ExtentX        =   3413
      _ExtentY        =   344
      _StockProps     =   78
      Caption         =   "&Save settings on Exit"
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   7.92
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
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
      Height          =   435
      Left            =   60
      TabIndex        =   9
      Top             =   4500
      Width           =   1755
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "&OK"
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
      Height          =   435
      Left            =   2160
      TabIndex        =   10
      Top             =   4500
      Width           =   1755
   End
   Begin VB.Frame fraDateOptions 
      Caption         =   "Show Payments Received"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1725
      Left            =   60
      TabIndex        =   11
      Top             =   2340
      Width           =   3855
      Begin VB.TextBox txtEndDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2220
         TabIndex        =   7
         Tag             =   "Date"
         Top             =   1320
         Width           =   975
      End
      Begin VB.TextBox txtStartDate 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   600
         TabIndex        =   6
         Tag             =   "Date"
         Top             =   1320
         Width           =   975
      End
      Begin VB.OptionButton optFullConfirmation 
         Caption         =   "Summed for each confirmation by arrival date"
         Height          =   255
         Left            =   120
         TabIndex        =   12
         Top             =   1620
         Visible         =   0   'False
         Width           =   3615
      End
      Begin VB.OptionButton optArrDate 
         Caption         =   "For guests arriving within Date Range"
         Height          =   255
         Left            =   120
         TabIndex        =   5
         Top             =   600
         Width           =   3555
      End
      Begin VB.OptionButton optDateRec 
         Caption         =   "By date payment was received"
         Height          =   225
         Left            =   120
         TabIndex        =   4
         Top             =   300
         Width           =   3555
      End
      Begin VB.Label lblEndDate 
         Caption         =   "through"
         Height          =   225
         Left            =   1620
         TabIndex        =   15
         Top             =   1380
         Width           =   555
      End
      Begin VB.Label lblStartDate 
         Caption         =   "Start:"
         Height          =   225
         Left            =   120
         TabIndex        =   14
         Top             =   1350
         Width           =   435
      End
      Begin VB.Label lblRange 
         Caption         =   "Date Range:"
         Height          =   255
         Left            =   120
         TabIndex        =   13
         Top             =   1050
         Width           =   1695
      End
   End
   Begin VB.Frame fraSortOrder 
      Caption         =   "Sort Order"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   7.8
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2145
      Left            =   60
      TabIndex        =   0
      Top             =   90
      Width           =   3855
      Begin VB.CommandButton cmdSortMoveDown 
         Caption         =   "Move &Down"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   2220
         TabIndex        =   3
         Top             =   1170
         Width           =   1215
      End
      Begin VB.CommandButton cmdSortMoveUp 
         Caption         =   "Move  &Up"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   7.8
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   435
         Left            =   2220
         TabIndex        =   2
         Top             =   540
         Width           =   1215
      End
      Begin VB.ListBox lstSortOrder 
         Appearance      =   0  'Flat
         Height          =   1560
         ItemData        =   "PayRecDg.frx":0000
         Left            =   120
         List            =   "PayRecDg.frx":0002
         TabIndex        =   1
         Top             =   270
         Width           =   1815
      End
   End
End
Attribute VB_Name = "frmPayRecDlg"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim vTotDue, vTotReceived As Currency
Private Sub cmdExit_Click()
   Unload Me
End Sub

Private Sub cmdOK_Click()
    
  'This Sub will drive the Crystal report PayRec1.rpt based upon
  'user settings on the frmPayRecDlg dialog box form.
  On Error GoTo cmdOK_Click_Error

  Screen.MousePointer = HOURGLASS
  'Validate date and number formats here
  If Not VerifyUpdate() Then
     MsgBox gMsg, MB_ICONSTOP, Me.Caption
     GoTo cmdOK_Click_Resume
  End If
  
  Dim vStartDate, vEndDate, vSelectBy As String
  Dim vSYear, vSMonth, vSDay As String
  Dim vEYear, vEMonth, vEDay As String
  
  'Get Select By option
  If optDateRec.Value = CHECKED Then
     vSelectBy = "DateReceived"
  ElseIf optArrDate.Value = CHECKED Then
     vSelectBy = "ArrDate"
  Else
     MsgBox "'Select By' has not been chosen.", MB_ICONSTOP, Me.Caption
     GoTo cmdOK_Click_Resume
  End If
  If Trim(txtEndDate.Text) <> "" Then
     If Trim(txtStartDate.Text) = "" Then
        MsgBox "Starting Date cannot be blank.", MB_ICONSTOP, Me.Caption
        GoTo cmdOK_Click_Resume
     End If
     If CDate(txtStartDate.Text) > CDate(txtEndDate.Text) Then
        MsgBox "Starting Date cannot be greater than ending date.", MB_ICONSTOP, Me.Caption
        GoTo cmdOK_Click_Resume
     End If
     vEndDate = Format(Trim(txtEndDate.Text), "mm/dd/yyyy")
     vEYear = DatePart("yyyy", Format(vEndDate, "mm/dd/yyyy"))
     vEMonth = DatePart("m", Format(vEndDate, "mm/dd/yyyy"))
     vEDay = DatePart("d", Format(vEndDate, "mm/dd/yyyy"))
  End If
  If Trim(txtStartDate.Text) <> "" Then
     vStartDate = Format(Trim(txtStartDate.Text), "mm/dd/yyyy")
     vSYear = DatePart("yyyy", Format(vStartDate, "mm/dd/yyyy"))
     vSMonth = DatePart("m", Format(vStartDate, "mm/dd/yyyy"))
     vSDay = DatePart("d", Format(vStartDate, "mm/dd/yyyy"))
  End If
  'Dont allow users to click anything
  'Me.Enabled = False
  Screen.MousePointer = HOURGLASS
  'Clear out support tables
  gBNB.Execute "delete from PaymentRecRpt where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
 ' gBNB.Execute "delete from SumPayRecSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
  If vStartDate = "" Then 'No date range has been set
     gSQL = "insert into PaymentRecRpt(conf,ComputerName) " & _
            "select distinct conf," & Chr$(34) & gComputerName & Chr$(34) & " From PaymentReceived " & _
            "where conf > 0" 'Getting GPF here when WHERE clause is omitted, so using dummy WHERE clause.
     mdiBNB.Report1.SelectionFormula = "{PaymentRecRpt.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
  ElseIf vStartDate <> "" And vEndDate = "" Then  'Only start date is set
     If vSelectBy = "DateReceived" Then
        gSQL = "insert into PaymentRecRpt(conf,ComputerName) " & _
           "select distinct conf," & Chr$(34) & gComputerName & Chr$(34) & " From PaymentReceived " & _
           "Where DateReceived >= #" & vStartDate & "#"
        mdiBNB.Report1.SelectionFormula = "{PaymentRecRpt.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34) & _
           " And {PaymentReceived.DateReceived} >= Date(" & _
           vSYear & "," & vSMonth & "," & vSDay & ")"
     ElseIf vSelectBy = "ArrDate" Then
        gSQL = "insert into PaymentRecRpt(conf,ComputerName) " & _
           "select distinct bbtbl.conf," & Chr$(34) & gComputerName & Chr$(34) & " From PaymentReceived " & _
           "INNER JOIN bbtbl ON bbtbl.conf=PaymentReceived.conf " & _
           "Where bbtbl.arrdate >= #" & vStartDate & "#"
        mdiBNB.Report1.SelectionFormula = "{PaymentRecRpt.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
     End If
  Else 'Both Start and End dates have been set
     If vSelectBy = "DateReceived" Then
        gSQL = "insert into PaymentRecRpt(conf,ComputerName) " & _
            "select distinct conf," & Chr$(34) & gComputerName & Chr$(34) & " From PaymentReceived " & _
            "Where DateReceived >= #" & vStartDate & "# " & _
            "And DateReceived <= #" & vEndDate & "#;"
        mdiBNB.Report1.SelectionFormula = "{PaymentRecRpt.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34) & _
           " And {PaymentReceived.DateReceived} >= Date(" & _
           vSYear & "," & vSMonth & "," & vSDay & ")" & _
           " And {PaymentReceived.DateReceived} <= Date(" & _
           vEYear & "," & vEMonth & "," & vEDay & ")"
     ElseIf vSelectBy = "ArrDate" Then
        gSQL = "insert into PaymentRecRpt(conf,ComputerName) " & _
            "select distinct bbtbl.conf," & Chr$(34) & gComputerName & Chr$(34) & " From PaymentReceived " & _
            "INNER JOIN bbtbl ON bbtbl.conf=PaymentReceived.conf " & _
            "Where bbtbl.arrdate >= #" & vStartDate & "# " & _
            "And bbtbl.arrdate <= #" & vEndDate & "#;"
        mdiBNB.Report1.SelectionFormula = "{PaymentRecRpt.ComputerName}=" & Chr$(34) & gComputerName & Chr$(34)
     End If
  End If
  gBNB.Execute gSQL
  mdiBNB.Report1.DataFiles(0) = gDatabaseName
  mdiBNB.Report1.ReportFileName = gDBDirectory & "PayRec1.rpt"
  'Since several reports are sharing the mdiBNB.Report1 control, the sort
  'array MUST be cleared out or values from previous report will be saved in the
  'array causing 'Unknown Field Name' error
  Dim vCount As Integer
  vCount = 0
  While Trim(mdiBNB.Report1.SortFields(vCount)) <> ""
    mdiBNB.Report1.SortFields(vCount) = ""
    vCount = vCount + 1
  Wend
  'mdiBNB.Report1.SelectionFormula = "{PaymentRecRpt.ComputerName}='" & gComputerName & "'"
  'mdiBNB.Report1.WindowMinButton = False
  mdiBNB.Report1.Destination = 0
  'Set report sort order
  For i = 0 To lstSortOrder.ListCount - 1
     mdiBNB.Report1.SortFields(i) = "+{PaymentReceived." & lstSortOrder.List(i) & "}"
  Next i
  mdiBNB.Report1.Action = 1
  
cmdOK_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdOK_Click_Error:
   'MsgBox Err.Description
   GoTo cmdOK_Click_Resume
   
End Sub

Private Sub cmdSortMoveDown_Click()

    On Error GoTo cmdSortMoveDown_Error
    
    If lstSortOrder.SelCount = 0 Then
       gMsg = "Select an item in the Sort Order list, then click " & _
              "the Move Up/Move Down button to change its order " & _
              "in the list."
       MsgBox gMsg, MB_ICONINFORMATION, Me.Caption
       GoTo cmdSortMoveDown_Resume
    End If
    'This routine will move the selected list item up one position in the list box.
    ChangeSortListPosition 1
    
cmdSortMoveDown_Resume:
    Exit Sub
    
cmdSortMoveDown_Error:
    Resume cmdSortMoveDown_Resume
    
End Sub

Private Sub cmdSortMoveUp_Click()
    
    On Error GoTo cmdSortMoveUp_Error
    
    If lstSortOrder.SelCount = 0 Then
       gMsg = "Select an item in the Sort Order list, then click " & _
              "the Move Up/Move Down button to change its order " & _
              "in the list."
       MsgBox gMsg, MB_ICONINFORMATION, Me.Caption
       GoTo cmdSortMoveUp_Resume
    End If
    'This routine will move the selected list item up one position in the list box.
    ChangeSortListPosition -1

cmdSortMoveUp_Resume:
    Exit Sub
    
cmdSortMoveUp_Error:
    Resume cmdSortMoveUp_Resume
    
End Sub

Private Sub Form_Activate()

     On Error GoTo Form_Activate_Error

     'If this form is in the background (does not have focus) and the
     'Minimize button is clicked on this form that does not yet have the focus,
     'an endless loop of Minimizing and Activating will occur. The following
     'line prevents this interesting problem.
     If Me.WindowState = MINIMIZED Then Exit Sub
     
     GetIniSettings
     
     If lstSortOrder.List(0) = "" Or chkSaveSettings.Value = UNCHECKED Then
        'Load column names from data source
        lstSortOrder.Clear
        Dim SSTemp As Recordset
        Dim i As Integer
        gSQL = "select * from PaymentReceived where conf = 0"
        Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
        GetSSRows SSTemp
        For i = 0 To SSTemp.Fields.Count - 1
           If SSTemp.Fields(i).Name <> "ID" Then lstSortOrder.AddItem SSTemp.Fields(i).Name
        Next i
     End If
     'Enable/Disable sort order list for the 'Sum of Payments Received per Conf Number' option.
'     If optFullConfirmation.Value = CHECKED Then
'        EnableSortList ("Disable")
'     Else
        EnableSortList ("Enable")
'     End If
   
Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

Form_Activate_Error:
   Resume Form_Activate_Resume
     
End Sub




Private Sub Form_Load()

   On Error GoTo Load_Error

   cmdSortMoveUp.Enabled = False
   cmdSortMoveDown.Enabled = False
   
Load_Resume:
   Exit Sub

Load_Error:
   Resume Load_Resume
   
End Sub



Public Sub ChangeSortListPosition(Delta As Integer)

    'This routine will move the selected list item up or down Delta position(s) in the list box.
    'An upward move is a negative delta, whereas a downward move is a positive delta.
    'Note that this routine does not work for a multi-select list box.

    'If no item is current then exit.
    If lstSortOrder.ListIndex < 0 Then Exit Sub

    'Declare variables.
    Dim Temp$, ID%, OldIndex%

    'Record ListIndex, List and ItemData for current row prior to removing it.
    OldIndex% = lstSortOrder.ListIndex
    Temp$ = lstSortOrder.List(lstSortOrder.ListIndex)
    ID% = lstSortOrder.ItemData(lstSortOrder.ListIndex)

    'First remove the item from its current position in the list.
    lstSortOrder.RemoveItem lstSortOrder.ListIndex
'MsgBox "Removed ListIndex# " & OldIndex% & ", " & Temp$ & " , representing result set column " & ID% & "."

    'Next, insert the item in its new position in the list.
    lstSortOrder.AddItem Temp$, OldIndex% + Delta
    lstSortOrder.ItemData(lstSortOrder.NewIndex) = ID%
    lstSortOrder.Selected(lstSortOrder.NewIndex) = True

End Sub

Private Sub Form_Unload(Cancel As Integer)

   On Error GoTo Form_Unload_Error
   
   Screen.MousePointer = HOURGLASS
   'Clear out support table
   gBNB.Execute "delete from PaymentRecRpt where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
'   gBNB.Execute "delete from SumPayRecSupport where ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
   WriteIniSettings
   
Form_Unload_Resume:
   Dim X&
   X& = SetActiveWindow(mdiBNB.hwnd)
   Screen.MousePointer = DEFAULT
   Exit Sub
   
Form_Unload_Error:
   Resume Form_Unload_Resume
   
End Sub

Private Sub lstSortOrder_Click()
    'Disable/Enable the Move Up (Down) command buttons if the selected
    'item in the list is the first (last) item in the list.
    If lstSortOrder.ListIndex = 0 Then
        cmdSortMoveUp.Enabled = False
        cmdSortMoveDown.Enabled = True
    ElseIf lstSortOrder.ListIndex = lstSortOrder.ListCount - 1 Then
        'The last item in the list box.
        cmdSortMoveUp.Enabled = True
        cmdSortMoveDown.Enabled = False
    Else
        'Any other item in the list.
        cmdSortMoveUp.Enabled = True
        cmdSortMoveDown.Enabled = True
    End If
End Sub



Public Function VerifyUpdate()

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
    Dim winDir, iniFile, TempStr As String
    'Get the directory in which the Windows and the .INI files reside.
    'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())
    'Detemine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"
'SAVE SETTINGS (always save this)
    'Write the Save Settings check box setting to the .INI file.
'MsgBox Str(chkSaveSettings.Value)
    If chkSaveSettings.Value = CHECKED Then
        X = WritePrivateProfileString("Payments Received Report", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Payments Received Report", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Payments Received Report", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub
   ' X = WritePrivateProfileString("Payments Received Report", "ShowTop", Format$(txtShowTop.Text), iniFile)
    For X = 0 To lstSortOrder.ListCount - 1
       TempStr = TempStr & lstSortOrder.List(X) & ","
    Next X
    TempStr = Left(TempStr, Len(TempStr) - 1)
    X = WritePrivateProfileString("Payments Received Report", "SortOrder", "", iniFile)
    X = WritePrivateProfileString("Payments Received Report", "SortOrder", TempStr, iniFile)
    X = WritePrivateProfileString("Payments Received Report", "DateReceived", Format$(optDateRec.Value), iniFile)
    X = WritePrivateProfileString("Payments Received Report", "ArrivalDate", Format$(optArrDate.Value), iniFile)
'    X = WritePrivateProfileString("Payments Received Report", "FullConfirmation", Format$(optFullConfirmation.Value), iniFile)
    X = WritePrivateProfileString("Payments Received Report", "StartDate", txtStartDate.Text, iniFile)
    X = WritePrivateProfileString("Payments Received Report", "EndDate", txtEndDate.Text, iniFile)
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
    'Detemine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"

    Dim TempStr, TempField As String
    'Dim i As Integer
    X = GetPrivateProfileString("Payments Received Report", "SortOrder", "", Rs, Len(Rs), iniFile)
    If X > 0 Then   ' Trim Buffer. a string was returned.
       'i = 0
       TempStr = Left$(Rs, X)
       'Extract fields from string and fill list box with them.
       While InStr(1, TempStr, ",") > 0
          TempField = Left(TempStr, InStr(1, TempStr, ",") - 1)
          TempStr = Right(TempStr, Len(TempStr) - InStr(1, TempStr, ","))
          lstSortOrder.AddItem TempField
       Wend
       'Add the last field to list box
       lstSortOrder.AddItem TempStr
    End If
    X = GetPrivateProfileString("Payments Received Report", "DateReceived", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then optDateRec.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Payments Received Report", "ArrivalDate", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then optArrDate.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
  '  X = GetPrivateProfileString("Payments Received Report", "FullConfirmation", "False", Rs, Len(Rs), iniFile)
  '  If X > 0 Then optFullConfirmation.Value = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Payments Received Report", "StartDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtStartDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    X = GetPrivateProfileString("Payments Received Report", "EndDate", "", Rs, Len(Rs), iniFile)
    If X > 0 Then txtEndDate.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
   ' x = GetPrivateProfileString("Confirmation Report", "ConfirmToOther", "False", Rs, Len(Rs), iniFile)
   ' If x > 0 Then optOther.Value = Left$(Rs, x)     ' Trim Buffer. a string was returned.
'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Payments Received Report", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
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



Private Sub optArrDate_Click()

   If optArrDate.Value = CHECKED Then
      EnableSortList ("Enable")
   Else
      EnableSortList ("Disable")
   End If
   
End Sub

Private Sub optDateRec_Click()

   If optDateRec.Value = CHECKED Then
      EnableSortList ("Enable")
   Else
      EnableSortList ("Disable")
   End If
   
End Sub


Private Sub optFullConfirmation_Click()

'   If optFullConfirmation.Value = CHECKED Then
'      EnableSortList ("Disable")
'   Else
'      EnableSortList ("Enable")
'   End If
   
End Sub



Public Sub EnableSortList(vMode As String)

   If vMode = "Enable" Then
      cmdSortMoveUp.Enabled = True
      cmdSortMoveDown.Enabled = True
      lstSortOrder.Enabled = True
   Else
      cmdSortMoveUp.Enabled = False
      cmdSortMoveDown.Enabled = False
      lstSortOrder.Enabled = False
   End If
   
End Sub

Public Function GetTotalDueAndReceived() As Integer
    
    On Error GoTo GetTotalDueAndReceived_Error
    
    Dim i As Integer
    Dim SSHoldConfs As Recordset
    Dim SSTemp As Recordset
    Dim vMinArrDate, vMaxDepDate As Date
    Dim TempTotal, vTotalDue, vTotalReceived, vTotalRefunded As Currency
    
    GetTotalDueAndReceived = False
    
    'Get list of conf numbers.
    gSQL = "select conf from SumPayRecSupport where ComputerName=" & Chr$(34) & gComputerName & Chr$(34)
    Set SSHoldConfs = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
    GetSSRows SSHoldConfs
    If SSHoldConfs.RecordCount < 1 Then
       gMsg = "No rows exist for the supplied Date Range."
       SSHoldConfs.Close
       GoTo GetTotalDueAndReceived_Resume
    End If
    SSHoldConfs.MoveFirst
    For i = 0 To SSHoldConfs.RecordCount - 1
       'Get next conf number
       vConfNum = SSHoldConfs(0)
       'Get Min Arrive Date
       gSQL = "select Min(ArrDate) from bbtbl where conf = " & vConfNum & _
              " And (suppress<>-1 Or (suppress=-1 And forfeit=-1))"
       Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
       GetSSRows SSTemp
       If SSTemp.RecordCount = 0 Then
          vMinArrDate = Null
       Else
          vMinArrDate = SSTemp(0)
       End If
       SSTemp.Close
       'Get Max Depart Date
       gSQL = "select Max(DepDate) from bbtbl where conf = " & vConfNum & _
              " And (suppress<>-1 Or (suppress=-1 And forfeit=-1))"
       Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
       GetSSRows SSTemp
       If SSTemp.RecordCount = 0 Then
          vMaxDepDate = Null
       Else
          vMaxDepDate = SSTemp(0)
       End If
       SSTemp.Close
       'Get calculated total due for current conf and put it in TempTotal.
       gSQL = "select sum(gwtax) from bbtbl where conf = " & vConfNum & _
              " And (suppress<>-1 Or (suppress=-1 And forfeit=-1))"
       Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
       GetSSRows SSTemp
       If Not IsNull(SSTemp(0)) Then
          TempTotal = SSTemp(0)
       Else
          TempTotal = 0
       End If
       SSTemp.Close
       'Add Res Fee to total due
       Set SSTemp = gBNB.OpenRecordset("select resfee from guesttbl where conf = " & vConfNum, dbOpenSnapshot)
       GetSSRows SSTemp
       If Not IsNull(SSTemp(0)) Then TempTotal = TempTotal + SSTemp(0)
       SSTemp.Close
       'Initialize total refunded variable.
       vTotalRefunded = 0
       'Get total refunded by check.
       Set SSTemp = gBNB.OpenRecordset("select sum(trueamt) from CheckTbl where conf = " & vConfNum & " and Void_Chk <> -1 and CheckCategory = 'Host' and SubCategory = 'Guest Refund'", dbOpenSnapshot)
       GetSSRows SSTemp
       If Not IsNull(SSTemp(0)) Then vTotalRefunded = vTotalRefunded + SSTemp(0)
       SSTemp.Close
       'Get total refunded by credit card or cash.
       Set SSTemp = gBNB.OpenRecordset("select sum(AmtPaid) from RefundByCCTbl where conf = " & vConfNum, dbOpenSnapshot)
       GetSSRows SSTemp
       If Not IsNull(SSTemp(0)) Then vTotalRefunded = vTotalRefunded + SSTemp(0)
       SSTemp.Close
    'endpaul
       'Assign the total due to its own variable.
       vTotalDue = TempTotal
     '********
       'Get calculated total credit for current conf.
       Set SSTemp = gBNB.OpenRecordset("select sum(AmountReceived) from paymentreceived where conf = " & vConfNum, dbOpenSnapshot)
       GetSSRows SSTemp
       If Not IsNull(SSTemp(0)) Then
          TempTotal = SSTemp(0)
       Else
          TempTotal = 0
       End If
       SSTemp.Close
       Set SSTemp = gBNB.OpenRecordset("select defcom,OtherCredit from payment where conf = " & vConfNum, dbOpenSnapshot)
       GetSSRows SSTemp
       If Not SSTemp.EOF And Not SSTemp.BOF Then
          If Not IsNull(SSTemp(0)) Then TempTotal = TempTotal + SSTemp(0)
          If Not IsNull(SSTemp(1)) Then TempTotal = TempTotal + SSTemp(1)
       End If
     '  lblTotalCredit.Caption = Format(Str(TempTotal), CURRENCYFORMAT)
       SSTemp.Close
       'Assign the total received to its own variable.
       vTotalReceived = TempTotal
       'Update row in SumPayRecSupport table
'MsgBox Str(vMinArrDate) & ", " & Str(vMaxDepDate) & ", " & Str(vTotalDue) & ", " & Str(vTotalReceived)
       gBNB.Execute "UPDATE SumPayRecSupport " & _
                    "SET MinArrivalDate=#" & vMinArrDate & _
                    "#,MaxDepartureDate=#" & vMaxDepDate & _
                    "#,TotalDue=" & vTotalDue & _
                    ",TotalReceived=" & vTotalReceived & _
                    ",TotalRefunded=" & vTotalRefunded & " WHERE conf=" & vConfNum & _
                    " And ComputerName = " & Chr$(34) & gComputerName & Chr$(34)
       SSHoldConfs.MoveNext
    Next i
    GetTotalDueAndReceived = True

GetTotalDueAndReceived_Resume:
   Screen.MousePointer = DEFAULT
   Exit Function
   
GetTotalDueAndReceived_Error:
   'MsgBox Err.Description
   Resume GetTotalDueAndReceived_Resume

End Function
