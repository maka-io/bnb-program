VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmPrintDialog 
   Appearance      =   0  'Flat
   BackColor       =   &H80000005&
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Print Dialog"
   ClientHeight    =   2835
   ClientLeft      =   1920
   ClientTop       =   3060
   ClientWidth     =   8340
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   2835
   ScaleWidth      =   8340
   ShowInTaskbar   =   0   'False
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
      Height          =   495
      Left            =   6960
      TabIndex        =   4
      Top             =   660
      Width           =   1335
   End
   Begin VB.CommandButton cmdFonts 
      Caption         =   "&Fonts..."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   5520
      TabIndex        =   3
      Top             =   660
      Width           =   1335
   End
   Begin VB.OptionButton optCancelled 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Cancelled"
      Height          =   195
      Left            =   5040
      TabIndex        =   20
      Top             =   3180
      Width           =   1215
   End
   Begin VB.TextBox txtHeaderLines 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   2640
      TabIndex        =   19
      Tag             =   "Text"
      Text            =   "txtHeaderLines"
      Top             =   3720
      Width           =   2295
   End
   Begin VB.TextBox txtPrintLinesPerPage 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   2640
      TabIndex        =   17
      Tag             =   "Text"
      Text            =   "txtPrintLinesPerPage"
      Top             =   3420
      Width           =   2295
   End
   Begin VB.TextBox txtCallingFormCaption 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   2640
      TabIndex        =   15
      Tag             =   "Text"
      Text            =   "txtCallingFormCaption"
      Top             =   3120
      Width           =   2295
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
      Height          =   495
      Left            =   6960
      TabIndex        =   2
      Top             =   60
      Width           =   1335
   End
   Begin VB.Frame fra3dRange 
      Caption         =   "Range"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1515
      Left            =   4200
      TabIndex        =   13
      Top             =   1320
      Width           =   4095
      Begin VB.TextBox txtLastCol 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2880
         MaxLength       =   4
         TabIndex        =   29
         Tag             =   "Text"
         Top             =   600
         Width           =   855
      End
      Begin VB.TextBox txtLastRow 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   2880
         MaxLength       =   4
         TabIndex        =   11
         Tag             =   "Text"
         Top             =   240
         Width           =   855
      End
      Begin VB.TextBox txtFirstCol 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         MaxLength       =   4
         TabIndex        =   12
         Tag             =   "Text"
         Top             =   600
         Width           =   975
      End
      Begin VB.TextBox txtFirstRow 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         MaxLength       =   4
         TabIndex        =   10
         Tag             =   "Text"
         Top             =   240
         Width           =   975
      End
      Begin VB.Label lblThru 
         Caption         =   "through"
         Height          =   255
         Index           =   1
         Left            =   2160
         TabIndex        =   28
         Top             =   600
         Width           =   735
      End
      Begin VB.Label lblThru 
         Caption         =   "through"
         Height          =   255
         Index           =   0
         Left            =   2160
         TabIndex        =   27
         Top             =   300
         Width           =   735
      End
      Begin VB.Label lblColumns 
         Caption         =   "Columns:"
         Height          =   255
         Left            =   240
         TabIndex        =   26
         Top             =   660
         Width           =   735
      End
      Begin VB.Label lblRows 
         Caption         =   "Rows:"
         Height          =   255
         Left            =   240
         TabIndex        =   25
         Top             =   300
         Width           =   735
      End
      Begin VB.Label Label1 
         Caption         =   "Note:  Row and Column ranges will not be saved on Exit regardless of Save Setting."
         Height          =   435
         Left            =   120
         TabIndex        =   24
         Top             =   1020
         Width           =   3855
      End
   End
   Begin VB.Frame fra3dPrintDlg 
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
      Height          =   1515
      Left            =   60
      TabIndex        =   1
      Top             =   1320
      Width           =   4155
      Begin Threed.SSCheck chkSaveSettings 
         Height          =   255
         Left            =   120
         TabIndex        =   7
         Top             =   1080
         Width           =   1935
         _Version        =   65536
         _ExtentX        =   3413
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
      Begin Threed.SSCheck chk3dChartBorder 
         Height          =   255
         Left            =   2040
         TabIndex        =   9
         Top             =   720
         Width           =   1335
         _Version        =   65536
         _ExtentX        =   2355
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Chart Border"
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
      Begin Threed.SSCheck chk3dColor 
         Height          =   255
         Left            =   2040
         TabIndex        =   8
         Top             =   360
         Width           =   1695
         _Version        =   65536
         _ExtentX        =   2990
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Color"
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
      Begin Threed.SSCheck chk3dCellOutlines 
         Height          =   255
         Left            =   120
         TabIndex        =   6
         Top             =   720
         Width           =   1335
         _Version        =   65536
         _ExtentX        =   2355
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Cell Outlines"
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
      Begin Threed.SSCheck chk3dAutoScale 
         Height          =   255
         Left            =   120
         TabIndex        =   5
         Top             =   360
         Width           =   1575
         _Version        =   65536
         _ExtentX        =   2778
         _ExtentY        =   450
         _StockProps     =   78
         Caption         =   "Auto Scale"
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
   End
   Begin VB.CommandButton cmdPrinter 
      Caption         =   "&Printer..."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   5520
      TabIndex        =   0
      Top             =   60
      Width           =   1335
   End
   Begin MSComDlg.CommonDialog CMDialog1 
      Left            =   240
      Top             =   3180
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Label lblFontData 
      BackColor       =   &H00FFFFFF&
      Height          =   255
      Left            =   960
      TabIndex        =   31
      Top             =   600
      Width           =   3975
   End
   Begin VB.Label lblPagesData 
      BackColor       =   &H00FFFFFF&
      Height          =   315
      Left            =   960
      TabIndex        =   30
      Top             =   120
      Width           =   615
   End
   Begin VB.Label lblPageCountWarning 
      BackColor       =   &H00FFFFFF&
      Caption         =   "(estimate subject to auto-scaling)"
      Height          =   255
      Left            =   2040
      TabIndex        =   23
      Top             =   120
      Width           =   2535
   End
   Begin VB.Label lblFont 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Font:"
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
      Left            =   120
      TabIndex        =   22
      Top             =   600
      Width           =   735
   End
   Begin VB.Label lblPages 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Pages:"
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
      Left            =   120
      TabIndex        =   21
      Top             =   120
      Width           =   855
   End
   Begin VB.Label lblHeaderLines 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Header Lines:"
      Height          =   255
      Left            =   960
      TabIndex        =   18
      Top             =   3720
      Width           =   1695
   End
   Begin VB.Label lblPrintLinesPerPage 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Print Lines Per Page:"
      Height          =   255
      Left            =   960
      TabIndex        =   16
      Top             =   3420
      Width           =   1695
   End
   Begin VB.Label lblCallingFormCaption 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Calling Form Caption:"
      ForeColor       =   &H00000000&
      Height          =   255
      Left            =   960
      TabIndex        =   14
      Top             =   3120
      Width           =   1695
   End
End
Attribute VB_Name = "frmPrintDialog"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim LastErr As Long     'The last error number returned by VB.
Dim CallingForm As Form
Dim CallingControl As Control
Dim FailedLostFocus As Integer
Dim msg As String
Dim SAW As Long

Private Sub chk3dAutoScale_Click(Value As Integer)
   lblPageCountWarning.Visible = Value
End Sub

Private Sub cmdCancel_Click()
    
    On Error GoTo cmdCancel_Click_Error
    
    optCancelled.Value = True
    cmdOK.SetFocus
    frmPrintDialog.Hide
    DoEvents

cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume

End Sub

Private Sub cmdFonts_Click()

    On Error GoTo cmdFont_Err

    Dim OrigPageCount As Integer
    Dim msg As String

    'Initailize Variables.
    OrigPageCount = Print_PageCount(CallingControl)
    
    'Set Common Dialog Font Properites
    CMDialog1.Flags = CF_PRINTERFONTS
    CMDialog1.CancelError = True
    CMDialog1.Max = 72  'Pertains to font size now, page # other times.
    
    'Activate Font Dialog Box
    CMDialog1.ShowFont

    'Set Printer Font Properites
    InitializePrinter
    
    'Reset Common Dialog Print Properites
    CMDialog1.Max = Str$(Print_PageCount(CallingControl))    'New page count.
    If Val(CMDialog1.Max) <> OrigPageCount Then CMDialog1.ToPage = CMDialog1.Max    'If page count has changed then reset the ending page #.
    
    UpdateDisplay
    
cmdFont_Resume:
    cmdOK.SetFocus
    Exit Sub
    
cmdFont_Err:
    'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
    If Err = cdlCancel Then
       'This will keep background screens from other applications
       'gaining focus mysteriously upon closure of common dialog.
       SAW = SetActiveWindow(mdiBNB.hwnd)
    Else
       MsgBox Err.Description
    End If
    Resume cmdFont_Resume

End Sub


Private Sub cmdOK_Click()

  If (Trim(txtLastRow.Text) = "" _
  Or Trim(txtFirstRow.Text) = "" _
  Or Trim(txtLastCol.Text) = "" _
  Or Trim(txtFirstCol.Text) = "") And txtCallingFormCaption.Text Like "*Listing*" Then
    gMsg = "Row and Column range values cannot be blank."
    MsgBox gMsg, MB_ICONSTOP, Me.Caption
    Exit Sub
  End If
  If txtLastRow.Text <> "" And txtFirstRow.Text <> "" Then
    If (CLng(txtLastRow.Text) > CLng(txtLastRow.Tag)) Or CLng(txtLastRow.Text) < CLng(txtFirstRow.Text) Then
        msg = "Row range is incorrect."
        MsgBox msg, MB_ICONEXCLAMATION, Me.Caption & " Print"
        Exit Sub
    End If
  End If
  If txtLastCol.Text <> "" And txtFirstCol.Text <> "" Then
    If (CLng(txtLastCol.Text) > CLng(txtLastCol.Tag)) Or CLng(txtLastCol.Text) < CLng(txtFirstCol.Text) Then
        msg = "Column range is incorrect."
        MsgBox msg, MB_ICONEXCLAMATION, Me.Caption & " Print"
        Exit Sub
    End If
  End If
  WriteIniSettings
  optCancelled = False
  Me.Hide
  DoEvents

End Sub

Private Sub cmdPrinter_Click()
    
    On Error GoTo cmdPrint_Err
    
    Dim OrigPageCount As Integer
    Dim msg As String

    'Initailize Variables.
    OrigPageCount = Print_PageCount(CallingControl)
    'Set Common Dialog Print Properites
    CMDialog1.Flags = PD_HIDEPRINTTOFILE Or PD_USEDEVMODECOPIES Or PD_COLLATE
    CMDialog1.CancelError = True
    CMDialog1.DialogTitle = txtCallingFormCaption.Text & " Printout"
    CMDialog1.Max = Str$(OrigPageCount)
    If OrigPageCount > Val(CMDialog1.ToPage) Then CMDialog1.ToPage = Str$(OrigPageCount)
    
    'Activate Printer Dialog Box
    CMDialog1.ShowPrinter
    Printer.EndDoc  'Invoke changes on printer object.
    InitializePrinter

    'Reset Common Dialog Print Properites
    GetDefaultPrinter
    CMDialog1.Max = Str$(Print_PageCount(CallingControl))    'New page count.
    If Val(CMDialog1.Max) <> OrigPageCount Then CMDialog1.ToPage = CMDialog1.Max    'If page count has changed then reset the ending page #.
    
    UpdateDisplay
    
cmdPrint_Resume:
    cmdOK.SetFocus
    Exit Sub
    
cmdPrint_Err:
    'User pressed cancel button is Err 32755 (CancelError = cdlCancel = 32755)
    If Err = cdlCancel Then
       'This will keep background screens from other applications
       'gaining focus mysteriously upon closure of common dialog.
       SAW = SetActiveWindow(mdiBNB.hwnd)
    Else
       MsgBox Err.Description
    End If
    Resume cmdPrint_Resume

End Sub


Private Sub Form_Activate()

    On Error GoTo Form_Activate_Error

    'If this form is in the background (does not have focus) and the
    'Minimize button is clicked on this form that does not yet have the focus,
    'an endless loop of Minimizing and Activating will occur. The following
    'line prevents this interesting problem.
    If Me.WindowState = MINIMIZED Then Exit Sub

    'Declare variables
    Dim X As Integer
    Static TimesActivated As Integer

    'Count number of dialog activations
    TimesActivated = TimesActivated + 1
    GetDefaultPrinter
    GetIniSettings
    InitializePrinter
    If TimesActivated = 1 Then
        InitializeCommonDialogBox
    Else
        CMDialog1.Max = Str$(Print_PageCount(CallingControl))
        CMDialog1.FromPage = 1
        CMDialog1.ToPage = CMDialog1.Max
    End If
    UpdateDisplay
    Me.Refresh

Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

Form_Activate_Error:
    'Display and record error message
    If Err.Number = 482 Then
       MsgBox Err.Description & " - a printer has not been installed. Goto 'Start', 'Settings', 'Printers' to add a printer."
    Else
       MsgBox Err.Description
    End If
    Screen.MousePointer = DEFAULT
    Unload Me
    Resume Form_Activate_Resume

End Sub

Public Sub GetDefaultPrinter()

    On Error GoTo GetDefaultPrinter_Error

    'Declare variables
    Dim X As Integer        'Return Value
    Dim Rs As String * 200  'Return String
    Dim winDir, Temp As String

    'Initialize variables
    Rs = Space$(Len(Rs))

    'Get the directory in which the Windows and the .INI files reside.
    'Note that GetPrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())

'PRINTER DEVICE NAME ...
    'Get and display the default printer device name from the win.ini file.
    X = GetPrivateProfileString("windows", "device", "", Rs, Len(Rs), winDir & "WIN.INI")
    If X > 0 Then  'a string was returned.
        Temp = Left$(Rs, X)     ' Trim Buffer
        'Trim default printer name (which includes drive and port) at first comma.
        If InStr(1, Temp, ",") > 1 Then Temp = Left$(Temp, InStr(1, Temp, ",") - 1)
        Me.Caption = "Print Dialog  -  " & Temp
    End If
Exit Sub

GetDefaultPrinter_Error:
    If IsError("GetDefaultPrinter") Then
        Resume GetDefaultPrinter_Resume
    Else
        Resume Next
    End If
    
GetDefaultPrinter_Resume:
    Me.Caption = "Print Dialog"

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

'FONTS ...
    'Get & Set the Print FontName.
    X = GetPrivateProfileString("Print Setup", "FontName", "Courier", Rs, Len(Rs), iniFile)
    If X > 0 Then CMDialog1.FontName = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    'Get & Set the Print FontSize.
    X = GetPrivateProfileString("Print Setup", "FontSize", "12", Rs, Len(Rs), iniFile)
    If X > 0 Then CMDialog1.FontSize = CDbl(Left$(Rs, X))     ' Trim Buffer. a string was returned.
    'Get & Set the Print FontBold.
    X = GetPrivateProfileString("Print Setup", "FontBold", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then CMDialog1.FontBold = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    'Get & Set the Print FontItalic.
    X = GetPrivateProfileString("Print Setup", "FontItalic", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then CMDialog1.FontItalic = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    'Get & Set the Print FontUnderline.
    X = GetPrivateProfileString("Print Setup", "FontUnderline", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then CMDialog1.FontUnderline = Left$(Rs, X)     ' Trim Buffer. a string was returned.
    'Get & Set the Print FontStrikethru.
    X = GetPrivateProfileString("Print Setup", "FontStrikethru", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then CMDialog1.FontStrikethru = Left$(Rs, X)     ' Trim Buffer. a string was returned.
'OPTIONS ...
    'Get & Set the Auto Scale option.
    X = GetPrivateProfileString("Print Setup", "AutoScale", "True", Rs, Len(Rs), iniFile)
    If X > 0 Then chk3dAutoScale.Value = Left$(Rs, X)    ' Trim Buffer 'a string was returned.
    'Get & Set the Cell Outlines option.
    X = GetPrivateProfileString("Print Setup", "CellOutlines", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then chk3dCellOutlines.Value = Left$(Rs, X)     ' Trim Buffer 'a string was returned.
    'Get & Set the SQL option.
'    x = GetPrivateProfileString("Print Setup", "SQL", "0", Rs, Len(Rs), iniFile)
'    If x > 0 Then chk3dSQL.Value = CInt(Left$(Rs, x))     ' Trim Buffer 'a string was returned.
    'Get & Set the Color option.
    X = GetPrivateProfileString("Print Setup", "Color", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then chk3dColor.Value = Left$(Rs, X)  ' Trim Buffer 'a string was returned.
    'Get & Set the Chart Border option.
    X = GetPrivateProfileString("Print Setup", "ChartBorder", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then chk3dChartBorder.Value = Left$(Rs, X)     ' Trim Buffer 'a string was returned.

'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Print Setup", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
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

Public Sub InitializePrinter()

'    On Error GoTo InitializePrinter_Error

    'Set Printer Font Properites to Common Dialog Font Properites
    
    Printer.FontName = CMDialog1.FontName
    Printer.FontSize = CMDialog1.FontSize
    Printer.FontBold = CMDialog1.FontBold
    Printer.FontItalic = CMDialog1.FontItalic
    Printer.FontStrikethru = CMDialog1.FontStrikethru
    Printer.FontUnderline = CMDialog1.FontUnderline
    
'InitializePrinter_Error:
'   MsgBox "InitPrinter Error"
'   Resume Next
   
End Sub

Public Sub InitializeCommonDialogBox()

    'On Error GoTo InitializeCommonDialogBox_Error

    'Set Common Dialog Font Properites
'    CMDialog1.DialogTitle = Format$(txtCallingFormCaption.Text) & " Printout"
'    CMDialog1.Min = 1
    'Set Common Dialog Print Properites
    CMDialog1.CancelError = True
    CMDialog1.Copies = 1
    CMDialog1.DialogTitle = Format$(txtCallingFormCaption.Text) & " Printout"
    CMDialog1.Min = 1
    CMDialog1.Max = Str$(Print_PageCount(CallingControl))
    CMDialog1.FromPage = 1
    CMDialog1.ToPage = CMDialog1.Max
    'Show the Page Count Warning if Auto-Scale is checked and enabled.
    If chk3dAutoScale.Enabled Then lblPageCountWarning.Visible = chk3dAutoScale.Value
    
'InitializeCommonDialogBox_Error:
 '  MsgBox "InitDialogBox Error"
 '  Resume Next
   
End Sub

Public Function Print_PageCount(TheGrid As Control) As Integer

    On Error GoTo Print_PageCount_Error

    Dim Temp As String
    Dim LinesPerPage, X As Integer
    Dim y As Long
 
    LinesPerPage = Print_LinesPerPage()
    If TypeOf CallingControl Is SSDBGrid Then
        If LinesPerPage > 0 Then
            Print_PageCount = CInt(TheGrid.Rows / (LinesPerPage - Val(txtHeaderLines.Text))) + 1
        Else
            Print_PageCount = 0
        End If
    ElseIf TypeOf CallingControl Is Data Then
        If LinesPerPage > 0 Then
            Print_PageCount = CInt(txtLastRow.Tag)
        Else
            Print_PageCount = 0
        End If
    Else    'Any text box.
        Print_PageCount = 1
    End If
Exit Function

Print_PageCount_Error:
    X = IsError("Print_PageCount")
    Resume Next

End Function

Public Sub WriteIniSettings()

    'Declare variables
    Dim X As Integer        'Return Value
    Dim winDir, iniFile, Temp As String
    'Get the directory in which the Windows and the .INI files reside.
    'Note that WritePrivateProfileString will default to the windows directory if a path for the .ini file is not specified.
    winDir = UCase$(GetWindowsDir())
    'Detemine the target .ini file
    iniFile = winDir & UCase$(App.EXEName) & ".INI"
    
'SAVE SETTINGS (always save this)
    'Write the Save Settings check box setting to the .INI file.
    If chkSaveSettings.Value = CHECKED Then
        X = WritePrivateProfileString("Print Setup", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Print Setup", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Print Setup", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub

'FONTS ...
    'Write the FontName setting to the .INI file.
    X = WritePrivateProfileString("Print Setup", "FontName", Format$(CMDialog1.FontName), iniFile)
    'Write the FontSize setting to the .INI file.
    X = WritePrivateProfileString("Print Setup", "FontSize", Format$(CMDialog1.FontSize), iniFile)
    'Write the FontBold setting to the .INI file.
    X = WritePrivateProfileString("Print Setup", "FontBold", Format$(CMDialog1.FontBold), iniFile)
    'Write the FontItalic setting to the .INI file.
    X = WritePrivateProfileString("Print Setup", "FontItalic", Format$(CMDialog1.FontItalic), iniFile)
    'Write the FontStrikeUnderline setting to the .INI file.
    X = WritePrivateProfileString("Print Setup", "FontUnderline", Format$(CMDialog1.FontUnderline), iniFile)
    'Write the FontStrikeThru setting to the .INI file.
    X = WritePrivateProfileString("Print Setup", "FontStrikethru", Format$(CMDialog1.FontStrikethru), iniFile)

'OPTIONS ...
    'Write the Auto Scale setting to the .INI file.
    X = WritePrivateProfileString("Print Setup", "AutoScale", Format$(chk3dAutoScale.Value), iniFile)
    'Write the Cell Outlines setting to the .INI file.
    X = WritePrivateProfileString("Print Setup", "CellOutlines", Format$(chk3dCellOutlines.Value), iniFile)
    'Write the Color setting to the .INI file.
    X = WritePrivateProfileString("Print Setup", "Color", Format$(chk3dColor.Value), iniFile)
    'Write the Chart Border setting to the .INI file.
    X = WritePrivateProfileString("Print Setup", "ChartBorder", Format$(chk3dChartBorder.Value), iniFile)

End Sub

Public Sub UpdateDisplay()

    txtPrintLinesPerPage.Text = Trim$(Print_LinesPerPage())
    lblFontData.Caption = Printer.FontName & " - " & Printer.FontSize & " pt."
    lblPagesData.Caption = Str$(Val(CMDialog1.ToPage) - Val(CMDialog1.FromPage) + 1)

End Sub

Public Function Print_LinesPerPage() As Integer

    'This function determines how many rows can be printed on a page (within margins).
    'The number of available print lines on a page is a function of the Printer.ScaleHeight,
    'the Printer.FontName, the Printer.FontSize, and the spacing between printed lines.
    'Return value is the maximum rows per printed page.  Should an error occur,
    'the function returns the negative of the VB error number.

    On Error GoTo Print_LinesPerPage_Err

    Dim TempHeight, NewHeight As Single

    'Get largest Printer.TextHeight of sample group and use as row height.
    TempHeight = Printer.TextHeight("test_ing123")
    NewHeight = Printer.TextHeight("BNB_BNBBNB_BN")
    If NewHeight > TempHeight Then TempHeight = NewHeight
    NewHeight = Printer.TextHeight("000000000001111")
    If NewHeight > TempHeight Then TempHeight = NewHeight
    'Note that line spacing between printed rows is accounted for in Printer.TextHeight()
    Print_LinesPerPage = Printer.ScaleHeight / TempHeight
    
Exit Function

Print_LinesPerPage_Err:
    LastErr = Err
    Resume Print_LinesPerPage_Resume

Print_LinesPerPage_Resume:
    Print_LinesPerPage = -LastErr

End Function

Private Sub Form_Load()
   
   On Error GoTo Load_Error
   
Load_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

Load_Error:
   Resume Load_Resume
   
End Sub

Private Sub Form_Unload(Cancel As Integer)
   
   On Error GoTo Form_Unload_Error

Form_Unload_Resume:
   Screen.MousePointer = DEFAULT
   Dim X&
   X& = SetActiveWindow(mdiBNB.hwnd)
   Exit Sub
   
Form_Unload_Error:
   Resume Form_Unload_Resume
   
End Sub

Private Sub txtCallingFormCaption_Change()
    Dim i As Integer
    
    'Run thru the Forms collection and identify the calling form.
    For i = 0 To Forms.Count - 1
        If Forms(i).Caption = txtCallingFormCaption.Text Then
            Set CallingForm = Forms(i)
            Exit For
        End If
    Next

    If txtCallingFormCaption.Text Like "*Listing*" Then
        chk3dAutoScale.Enabled = True
        chk3dCellOutlines.Enabled = True
        'Run thru the Control collection and identify the calling form's grid.
        For i = 0 To CallingForm.Controls.Count - 1
            If TypeOf CallingForm.Controls(i) Is SSDBGrid Then
                Set CallingControl = CallingForm.Controls(i)
                Exit For
            End If
        Next

    ElseIf txtCallingFormCaption.Text Like "*Browse*" Then
        chk3dAutoScale.Enabled = False
        chk3dCellOutlines.Enabled = False
        'Run thru the Control collection and identify the calling form's data control.
        For i = 0 To CallingForm.Controls.Count - 1
            If TypeOf CallingForm.Controls(i) Is Data Then
                Set CallingControl = CallingForm.Controls(i)
                Exit For
            End If
        Next

    Else
        'Run thru the Control collection and identify the calling form's first text box.
        For i = 0 To CallingForm.Controls.Count - 1
            If TypeOf CallingForm.Controls(i) Is TextBox Then
                Set CallingControl = CallingForm.Controls(i)
                Exit For
            End If
        Next
        chk3dAutoScale.Enabled = False
        chk3dCellOutlines.Enabled = False
    End If

End Sub


