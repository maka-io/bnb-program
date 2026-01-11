VERSION 5.00
Object = "{0BA686C6-F7D3-101A-993E-0000C0EF6F5E}#1.0#0"; "THREED32.OCX"
Begin VB.Form frmLabelDialog 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Mailing Label Dialog Box"
   ClientHeight    =   4425
   ClientLeft      =   2715
   ClientTop       =   3105
   ClientWidth     =   3390
   HelpContextID   =   137
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4425
   ScaleWidth      =   3390
   Begin VB.TextBox txtNumLabels 
      Appearance      =   0  'Flat
      Height          =   285
      Left            =   780
      MaxLength       =   3
      TabIndex        =   6
      Tag             =   "Number"
      Text            =   "2"
      Top             =   3240
      Width           =   435
   End
   Begin Threed.SSCheck chkMultiLabel 
      Height          =   255
      Left            =   60
      TabIndex        =   5
      Top             =   3240
      Width           =   255
      _Version        =   65536
      _ExtentX        =   450
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
   Begin Threed.SSCheck chkSaveSettings 
      Height          =   225
      Left            =   60
      TabIndex        =   7
      Top             =   3600
      Width           =   1875
      _Version        =   65536
      _ExtentX        =   3307
      _ExtentY        =   397
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
   End
   Begin VB.Frame fraFormat 
      Caption         =   "Select Print Format"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   975
      Left            =   60
      TabIndex        =   10
      Top             =   2100
      Width           =   3255
      Begin VB.ComboBox txtComboFormat 
         Appearance      =   0  'Flat
         Height          =   315
         ItemData        =   "LabelDlg.frx":0000
         Left            =   120
         List            =   "LabelDlg.frx":0002
         TabIndex        =   4
         Tag             =   "Text"
         Top             =   360
         Width           =   3015
      End
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "&OK"
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
      Height          =   435
      Left            =   1800
      TabIndex        =   9
      Top             =   3960
      Width           =   1515
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
      Height          =   435
      Left            =   60
      TabIndex        =   8
      Top             =   3960
      Width           =   1515
   End
   Begin VB.Frame fraOrder 
      Caption         =   "Order By"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1935
      Left            =   60
      TabIndex        =   0
      Top             =   90
      Width           =   3255
      Begin VB.CommandButton cmdSortMoveDown 
         Caption         =   "Move Down"
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
         Left            =   1920
         TabIndex        =   3
         Top             =   1140
         Width           =   1215
      End
      Begin VB.CommandButton cmdSortMoveUp 
         Caption         =   "Move Up"
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
         Left            =   1920
         TabIndex        =   2
         Top             =   540
         Width           =   1215
      End
      Begin VB.ListBox lstSortOrder 
         Appearance      =   0  'Flat
         Height          =   1590
         ItemData        =   "LabelDlg.frx":0004
         Left            =   120
         List            =   "LabelDlg.frx":0006
         TabIndex        =   1
         Top             =   270
         Width           =   1695
      End
   End
   Begin VB.Label lblLabel2 
      Caption         =   "labels for current row"
      Height          =   195
      Left            =   1320
      TabIndex        =   12
      Top             =   3300
      Width           =   1755
   End
   Begin VB.Label lblLabel1 
      Caption         =   "&Print"
      Height          =   195
      Left            =   300
      TabIndex        =   11
      Top             =   3300
      Width           =   375
   End
End
Attribute VB_Name = "frmLabelDialog"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False



Private Sub chkMultiLabel_Click(Value As Integer)

   If chkMultiLabel.Value = CHECKED Then
      'lblLabel1.Enabled = True
      'lblLabel2.Enabled = True
      txtNumLabels.Enabled = True
   Else
      'lblLabel1.Enabled = False
      'lblLabel2.Enabled = False
      txtNumLabels.Enabled = False
   End If
   
End Sub

Private Sub cmdCancel_Click()
   
  On Error GoTo cmdCancel_Click_Error
  
  Unload Me

cmdCancel_Click_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

cmdCancel_Click_Error:
   Resume cmdCancel_Click_Resume
   
End Sub

Private Sub cmdOK_Click()
   If Not IsNumeric(txtNumLabels.Text) Then txtNumLabels.Text = "2"
   Me.Hide
End Sub


Private Sub cmdSortMoveDown_Click()
    'This routine will move the selected list item up one position in the list box.
    ChangeSortListPosition 1
    'It is recommended to resize the columns after reordering the columns
End Sub

Private Sub cmdSortMoveUp_Click()
    'This routine will move the selected list item up one position in the list box.
    ChangeSortListPosition -1
    'It is recommended to resize the columns after reordering the columns
End Sub

Private Sub Form_Activate()
   
   On Error GoTo Form_Activate_Error

   'If this form is in the background (does not have focus) and the
   'Minimize button is clicked on this form that does not yet have the focus,
   'an endless loop of Minimizing and Activating will occur. The following
   'line prevents this interesting problem.
   If Me.WindowState = MINIMIZED Then Exit Sub
   
   txtComboFormat.AddItem "3-Column Sheet (Avery 5160 Laser)"
   txtComboFormat.AddItem "Single-Column (Avery 4145 Dot Matrix)"
   GetIniSettings
   
   If chkMultiLabel.Value = CHECKED Then
      txtNumLabels.Enabled = True
   Else
      txtNumLabels.Enabled = False
   End If
   
   If lstSortOrder.List(0) = "" Then LoadDefaultSortOrder
   
Form_Activate_Resume:
   Screen.MousePointer = DEFAULT
   cmdOK.SetFocus
   Exit Sub
   
Form_Activate_Error:
   Resume Form_Activate_Resume
   
End Sub

Private Sub Form_Load()

   cmdSortMoveUp.Enabled = False
   cmdSortMoveDown.Enabled = False
   
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
   
   WriteIniSettings

Form_Unload_Resume:
   Screen.MousePointer = DEFAULT
   Dim X&
   X& = SetActiveWindow(mdiBNB.hwnd)
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
    X = GetPrivateProfileString("Label Report", "MultiLabel", "False", Rs, Len(Rs), iniFile)
    If X > 0 Then chkMultiLabel.Value = Left$(Rs, X)    ' Trim Buffer 'a string was returned.
    X = GetPrivateProfileString("Label Report", "NumLabels", "2", Rs, Len(Rs), iniFile)
    If X > 0 Then txtNumLabels.Text = CDbl(Left$(Rs, X))     ' Trim Buffer. a string was returned.
    'Dim i As Integer
    If LabelCallingForm = "frmGeneralGuest" Then
       X = GetPrivateProfileString("Label Report", "GuestLabelSortOrder", "", Rs, Len(Rs), iniFile)
    ElseIf LabelCallingForm = "frmTravelAccount" Then
       X = GetPrivateProfileString("Label Report", "TravelLabelSortOrder", "", Rs, Len(Rs), iniFile)
    ElseIf LabelCallingForm = "frmProperty" Then
       X = GetPrivateProfileString("Label Report", "PropertyLabelSortOrder", "", Rs, Len(Rs), iniFile)
    ElseIf LabelCallingForm = "frmCarAccount" Then
       X = GetPrivateProfileString("Label Report", "CarLabelSortOrder", "", Rs, Len(Rs), iniFile)
    End If
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
    X = GetPrivateProfileString("Label Report", "Format", "Single-Column (Avery 4145 Dot Matrix)", Rs, Len(Rs), iniFile)
    If X > 0 Then txtComboFormat.Text = Left$(Rs, X)     ' Trim Buffer. a string was returned.
'SAVE SETTINGS ...
    'Get & Set the Save Settings check box.
    X = GetPrivateProfileString("Label Report", "SaveSettings", "CHECKED", Rs, Len(Rs), iniFile)
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
        X = WritePrivateProfileString("Label Report", "SaveSettings", "CHECKED", iniFile)
    ElseIf chkSaveSettings.Value = UNCHECKED Then
        X = WritePrivateProfileString("Label Report", "SaveSettings", "UNCHECKED", iniFile)
    ElseIf chkSaveSettings.Value = GRAYED Then
        X = WritePrivateProfileString("Label Report", "SaveSettings", "GRAYED", iniFile)
    End If
    'ONLY SAVE THE REST OF THE CHANGES IF SAVE SETTINGS IS CHECKED!
    If chkSaveSettings.Value = UNCHECKED Then Exit Sub
   ' X = WritePrivateProfileString("Label Report", "ShowTop", Format$(txtShowTop.Text), iniFile)
    For X = 0 To lstSortOrder.ListCount - 1
       TempStr = TempStr & lstSortOrder.List(X) & ","
    Next X
    TempStr = Left(TempStr, Len(TempStr) - 1)
    If LabelCallingForm = "frmGeneralGuest" Then
       X = WritePrivateProfileString("Label Report", "GuestLabelSortOrder", "", iniFile)
       X = WritePrivateProfileString("Label Report", "GuestLabelSortOrder", TempStr, iniFile)
    ElseIf LabelCallingForm = "frmTravelAccount" Then
       X = WritePrivateProfileString("Label Report", "TravelLabelSortOrder", "", iniFile)
       X = WritePrivateProfileString("Label Report", "TravelLabelSortOrder", TempStr, iniFile)
    ElseIf LabelCallingForm = "frmProperty" Then
       X = WritePrivateProfileString("Label Report", "PropertyLabelSortOrder", "", iniFile)
       X = WritePrivateProfileString("Label Report", "PropertyLabelSortOrder", TempStr, iniFile)
    ElseIf LabelCallingForm = "frmCarAccount" Then
       X = WritePrivateProfileString("Label Report", "CarLabelSortOrder", "", iniFile)
       X = WritePrivateProfileString("Label Report", "CarLabelSortOrder", TempStr, iniFile)
    End If
    X = WritePrivateProfileString("Label Report", "MultiLabel", Format$(chkMultiLabel.Value), iniFile)
    X = WritePrivateProfileString("Label Report", "NumLabels", txtNumLabels.Text, iniFile)
    X = WritePrivateProfileString("Label Report", "Format", txtComboFormat.Text, iniFile)
    
End Sub

Public Sub LoadDefaultSortOrder()
   
   If LabelCallingForm = "frmGeneralGuest" Then
      lstSortOrder.AddItem "Last Name"
      lstSortOrder.AddItem "First Name"
      lstSortOrder.AddItem "Company"
      lstSortOrder.AddItem "Address"
      lstSortOrder.AddItem "City"
      lstSortOrder.AddItem "State"
      lstSortOrder.AddItem "Zipcode"
   ElseIf LabelCallingForm = "frmProperty" Then
      lstSortOrder.AddItem "Property Name"
      lstSortOrder.AddItem "Manager Name"
      lstSortOrder.AddItem "Address"
      lstSortOrder.AddItem "City"
      lstSortOrder.AddItem "State"
      lstSortOrder.AddItem "Zipcode"
   ElseIf LabelCallingForm = "frmTravelAccount" Then
      lstSortOrder.AddItem "Travel Agency Name"
      lstSortOrder.AddItem "Address"
      lstSortOrder.AddItem "City"
      lstSortOrder.AddItem "State"
      lstSortOrder.AddItem "Zipcode"
   ElseIf LabelCallingForm = "frmCarAccount" Then
      lstSortOrder.AddItem "Rental Agency Name"
      lstSortOrder.AddItem "Address"
      lstSortOrder.AddItem "City"
      lstSortOrder.AddItem "State"
      lstSortOrder.AddItem "Zipcode"
   End If
   
End Sub

