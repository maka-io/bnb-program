Attribute VB_Name = "modWinApi"
'32-bit APIs used to Disable/Enable form's Control Box.
Declare Function ModifyMenu Lib "user32" Alias "ModifyMenuA" (ByVal hMenu As Long, ByVal nPosition As Long, ByVal wFlags As Long, ByVal wIDNewItem As Long, ByVal lpString As String) As Long
Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Long, ByVal bRevert As Long) As Long
'32-bit API/DLL Declarations for writing/reading INI files, etc.
Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal lSize As Long, ByVal lpFileName As String) As Long
Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As Any, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lplFileName As String) As Long
Declare Function GetWindowsDirectory Lib "kernel32" Alias "GetWindowsDirectoryA" (ByVal lpBuffer As String, ByVal nSize As Long) As Long
Declare Function GetSystemDirectory Lib "kernel32" Alias "GetSystemDirectoryA" (ByVal lpBuffer As String, ByVal nSize As Long) As Long
'32-Bit APIs for getting/setting environment variables (VB environment that is, not system)
Declare Function GetEnvironmentVariable Lib "kernel32" Alias "GetEnvironmentVariableA" (ByVal lpName As String, ByVal lpBuffer As String, ByVal nSize As Long) As Long
Declare Function SetEnvironmentVariable Lib "kernel32" Alias "SetEnvironmentVariableA" (ByVal lpName As String, ByVal lpValue As String) As Long
Declare Function GetComputerName Lib "kernel32" Alias "GetComputerNameA" (ByVal lpBuffer As String, nSize As Long) As Long
'Show window
Declare Function ShowWindow Lib "user32" (ByVal hwnd As Long, ByVal nCmdShow As Long) As Long
'Set Active Window
Declare Function SetActiveWindow Lib "user32" (ByVal hwnd As Long) As Long
'Crystal Reports
Declare Function PEOpenEngine Lib "CRPE32.DLL" () As Integer
Declare Function PEOpenPrintJob Lib "CRPE32.DLL" (ByVal reportFilePath As String) As Integer
Declare Sub PEClosePrintJob Lib "CRPE32.DLL" (ByVal printjob As Integer)
Declare Sub PECloseEngine Lib "CRPE32.DLL" ()
' ShowWindow() Commands
Public Const SW_HIDE = 0
Public Const SW_SHOWNORMAL = 1
Public Const SW_NORMAL = 1
Public Const SW_SHOWMINIMIZED = 2
Public Const SW_SHOWMAXIMIZED = 3
Public Const SW_MAXIMIZE = 3
Public Const SW_SHOWNOACTIVATE = 4
Public Const SW_SHOW = 5
Public Const SW_MINIMIZE = 6
Public Const SW_SHOWMINNOACTIVE = 7
Public Const SW_SHOWNA = 8
Public Const SW_RESTORE = 9
Public Const SW_SHOWDEFAULT = 10
Public Const SW_MAX = 10
'Menu flags for Add/Check/EnableMenuItem()
Public Const MF_INSERT = &H0&
Public Const MF_CHANGE = &H80&
Public Const MF_APPEND = &H100&
Public Const MF_DELETE = &H200&
Public Const MF_REMOVE = &H1000&

Public Const MF_BYCOMMAND = &H0&
Public Const MF_BYPOSITION = &H400&

Public Const MF_SEPARATOR = &H800&

Public Const MF_ENABLED = &H0&
Public Const MF_GRAYED = &H1&
Public Const MF_DISABLED = &H2&

Public Const MF_UNCHECKED = &H0&
Public Const MF_CHECKED = &H8&
Public Const MF_USECHECKBITMAPS = &H200&

Public Const MF_STRING = &H0&
Public Const MF_BITMAP = &H4&
Public Const MF_OWNERDRAW = &H100&

Public Const MF_POPUP = &H10&
Public Const MF_MENUBARBREAK = &H20&
Public Const MF_MENUBREAK = &H40&

Public Const MF_UNHILITE = &H0&
Public Const MF_HILITE = &H80&

Public Const MF_SYSMENU = &H2000&
Public Const MF_HELP = &H4000&
Public Const MF_MOUSESELECT = &H8000&
' System Menu Command Values
Public Const SC_SIZE = &HF000
Public Const SC_MOVE = &HF010
Public Const SC_MINIMIZE = &HF020
Public Const SC_MAXIMIZE = &HF030
Public Const SC_NEXTWINDOW = &HF040
Public Const SC_PREVWINDOW = &HF050
Public Const SC_CLOSE = &HF060
Public Const SC_VSCROLL = &HF070
Public Const SC_HSCROLL = &HF080
Public Const SC_MOUSEMENU = &HF090
Public Const SC_KEYMENU = &HF100
Public Const SC_ARRANGE = &HF110
Public Const SC_RESTORE = &HF120
Public Const SC_TASKLIST = &HF130
Public Const SC_SCREENSAVE = &HF140
Public Const SC_HOTKEY = &HF150



