Attribute VB_Name = "modBNB1"
'Global (Public) declarations
Public DEMO As Integer  'Set this to True in mdiBNB_Load if compiling as a Demo
Public gVersion As String  'eg, 01.00.00
Public gDatabaseName As String
Public gDBDirectory As String 'Same as above, but without DB name (ie, C:\Program Files\BNB\)
Public gSetupDirectory As String
Public gBNB As Database
Public gComputerName As String
Public gTableName As String  'Holds name for temp tables created by user
Public gReportNumber As Integer
Public gCaption As String   'Title of the Listing Report
Public gSQL As String
Public LabelCallingForm As String  'Form which calls frmLabelDialog
'For wildcard date Find
Public gDay, gMonth, gYear As String
Public gWCardDateCase As Integer
'Size Grid Cells routine Option constants.
Public Const SGC_VISIBLE = 0
Public Const SGC_ALL = 1
Public Const SGC_CURRENT = 2
Public Const SGC_SELECTED = 3
Public gMsg As String
Public gConfNum As Long
Public gPriorConfNum As Long
Public gFirstName As String
Public gLastName As String
'Public gSummReportName As String
'gRowChangeFormName Controls Activate event so won't requery when changing
'focus between same-form related screens (ie, frmGeneralGuest and
'its "Display Rows" grid. Applies only to forms containing conf number.
Public gRowChangeFormName As String
Public ConfArray(300) As Long 'Holds confs for manual conf# entries in check printing.
'Status of Manual Check print dialog box.
Public ManConfDlgContinue As Integer
Public ManConfDlgBack As Integer
Public ManConfDlgCancel As Integer
Public Function IncrementReportNo(ByVal AutoInc As Integer)
    '  The parameter AutoInc is a True/False flag whether or not to automatically
    '  increment the global sequencial report number and append it to the global caption.
    'Increment the global report number counter.
    If AutoInc Then
        gReportNumber = gReportNumber + 1
        gCaption = gCaption & " (" & gReportNumber & ")"
    End If

End Function

Public Sub SizeGridCells(TheForm As Form, TheGrid As Control, Method As Integer)
    'This routine will size grid cells (column width & height) to fit the
    'data displayed in the grid cells.  For a data grid, this routine will
    'only size cells for rows currently displayed on the screen.

    'Note: if this is called during a DataGrid's InitColProp event procedure, then
    'the grid columns will be sized to match the displayed column headers
    'because data has not yet been loaded into grid cells at
    'the time that the event occurs.

    'Method (Option) Constant Declarations:
    '  SGC_VISIBLE  - Size cells of visible rows only.
    '  SGC_ALL      - Size cells of all rows.
    '  SGC_CURRENT  - Size cells of only the current row.
    '  SGC_SELECTED - Size cells of only the selected RANGE of row.

    On Error Resume Next    'Handles harmless error caused by call during InitColProp event.
    Dim h, r As Long     'c=column, h=header column, r=row
    Dim c As Integer
    Dim OriginalRowPosition As Long    'The selected grid row when this routine was called.
    Dim GridCell As String  'Used to hold the text/header/fieldname of cell.
    Dim CellTextWidth, CellTextHeight As Long   'Used to store each cell's minimum size.
    Dim HideTheGrid As Integer  'True if grid was visible upon procedure call.
    Dim OrigFontName As String
    Dim OrigFontSize As Single
    Dim OrigFontBold, OrigFontItalic, OrigFontStrikethru, OrigFontUnderline As Integer
    Dim FirstRow, LastRow As Long   'The inclusive range of row numbers to resize. (0 based)

    'Is grid visible?
    HideTheGrid = TheGrid.Visible

    'Perform the following if the Grid is a Sheridan Software DataGrid
    If TypeOf TheGrid Is SSDBGrid Then
        'Remember the original row position so that you can return there.
        OriginalRowPosition = TheGrid.AddItemRowIndex(TheGrid.Bookmark)
        'Don't redraw the grid until this routine has completed.
        TheGrid.Redraw = False
        'Hide the grid because displaying this process is slow & ugly.
        If HideTheGrid Then TheGrid.Visible = False
        DoEvents
        'Record the original state of the form's font properties so that we can reset the form later.
        OrigFontName = TheForm.Font
        OrigFontSize = TheForm.Font.Size
        OrigFontBold = TheForm.Font.Bold
        OrigFontItalic = TheForm.Font.Italic
        OrigFontStrikethru = TheForm.Font.Strikethru
        OrigFontUnderline = TheForm.Font.Underline
        'Temporarily set the form's font properties equal to the grid's font properties.
        TheForm.FontName = TheGrid.Font
        TheForm.FontSize = TheGrid.Font.Size
        TheForm.FontBold = TheGrid.Font.Bold
        TheForm.FontItalic = TheGrid.Font.Italic
        TheForm.FontStrikethru = TheGrid.Font.Strikethru
        TheForm.FontUnderline = TheGrid.Font.Underline

        'Size Grid Column Widths and Row Heights for all visible rows.
        'Note that VisibleRows property of the DataGrid refers to the
        'number of rows that "could be" displayed in the grid given the grids
        'height and RowHeight.
        If TheGrid.Rows > 0 And TheGrid.Cols > 0 Then
            'Set the range of rows whose cells are to be resized based on the value of Method (option).
            If Method = SGC_CURRENT Then
                FirstRow = TheGrid.AddItemRowIndex(TheGrid.Bookmark)
                LastRow = TheGrid.AddItemRowIndex(TheGrid.Bookmark)
            ElseIf Method = SGC_ALL Then
                FirstRow = 0
                LastRow = TheGrid.Rows
            ElseIf Method = SGC_SELECTED Then
                FirstRow = CLng(PrintSelRowStart)
                LastRow = CLng(PrintSelRowEnd)
            Else    'default is SGC_VISIBLE
                FirstRow = TheGrid.TopRow
                LastRow = TheGrid.TopRow + TheGrid.VisibleRows - 1
            End If
            'Adjust the last row, if necessary, to fit physical constraints.  (see remarks above)
            If LastRow > (TheGrid.Rows - 1) Then LastRow = (TheGrid.Rows - 1)
            'Do the following for each row.
            For r = FirstRow To LastRow
                DoEvents    'Let other operations catch up.
                TheGrid.Bookmark = TheGrid.AddItemBookmark(r)
                '1st size cells so that headers are completely displayed.
                'Also, use this opportunity to set the column widths
                'to their minimum sized (header widths or 100 twips).  They
                'are currently at default widths if this routine has not
                'been run earlier.
                If r = 0 Then
                    For h = 0 To (TheGrid.Cols - 1)
                        If TheGrid.Columns(h).Caption <> "" Then GridCell = Format$(TheGrid.Columns(h).Caption) Else: GridCell = Format$(TheGrid.Columns(h).Caption)
                        CellTextWidth = TheForm.TextWidth(GridCell) + 100    'Note that + 100 set minimum width to 100 twips.
                        CellTextHeight = TheForm.TextHeight(GridCell) + 50   'Note that + 50 set minimum height to 50 twips.
                        TheGrid.DefColWidth(h) = CellTextWidth
                        TheGrid.RowHeight = CellTextHeight
                    Next h
                End If
                'Size cells so that all data in visible cells is completely displayed.
                For c = 0 To (TheGrid.Cols - 1)
                    GridCell = RTrim$(TheGrid.Columns(c).Text)
         '           If TheGrid.ColDropDownHwnd(c) = 0 Then  'No drop down button.
         '               ExtraWidth = 100   'Note that + 100 set minimum width to 100 twips.
         '           Else    'Column has a drop down button, so make extra room for it.
         '               ExtraWidth = 400   'Note: 400 is used instead of 100 (above) in order to provide room for the data drop down button.  Every 120 twips corresponds to approximately 1 characters.
         '           End If
                    If TheForm.TextWidth(GridCell) > TheGrid.Columns(c).Width Then
                       TheGrid.Columns(c).Width = 1.2 * TheForm.TextWidth(GridCell)
                    End If
         '           CellTextWidth = TheForm.TextWidth(GridCell) + ExtraWidth
                    CellTextHeight = TheForm.TextHeight(GridCell) + 50   'Note that + 50 set minimum height to 50 twips.
         '           If CellTextWidth > TheGrid.DefColWidth(c) Then TheGrid.Width(c) = CellTextWidth * 1.2
                    If CellTextHeight > TheGrid.RowHeight Then TheGrid.RowHeight = CellTextHeight
                Next c
            Next r
        End If
        'Reset the form's font properties to their original values.
        TheForm.Font = OrigFontName
        TheForm.Font.Size = OrigFontSize
        TheForm.Font.Bold = OrigFontBold
        TheForm.Font.Italic = OrigFontItalic
        TheForm.Font.Strikethru = OrigFontStrikethru
        TheForm.Font.Underline = OrigFontUnderline
        'Now redraw & redisplay the grid.
        TheGrid.Redraw = True
        TheGrid.Bookmark = TheGrid.AddItemBookmark(OriginalRowPosition)
        If HideTheGrid Then TheGrid.Visible = True
    End If

End Sub


Public Sub StatusMessage(TheForm As Form, Message As String, Display As Integer)
    On Error Resume Next
    'This routine will set the caption of the form's 3D Panel pnlMessage,
    'and either display or hide the message and panel.
    '
    '   Parameters:
    '       Message - The message to be displayed in the panel's caption.
    '       Display - The visible state of the panel (& therefore message).
    '                 Visible states are False (hide) or True (show).
    '                 Any value other than True reverts to False
    '
    If Display Then
        TheForm.pnlMessage.Visible = True
    Else
        TheForm.pnlMessage.Visible = False
    End If
    TheForm.pnlMessage.Font.Size = 1
    TheForm.pnlMessage.Caption = Message
    'Ensure that status message is displayed.
    DoEvents
    TheForm.Refresh

End Sub

Public Function GetDCRows(DC As Data) As Integer
    
    On Error GoTo GetDCRows_Error
    
    GetDCRows = False
    If DC.RecordSource <> "" Then
        DC.Refresh
        If Not DC.Recordset.BOF And Not DC.Recordset.EOF Then
            Dim MyClone As Dynaset
            Set MyClone = DC.Recordset.Clone()
            MyClone.MoveLast
            MyClone.MoveFirst
            MyClone.Close
           ' DC.Recordset.MoveLast
           ' DC.Recordset.MoveFirst
        End If
        GetDCRows = True
    End If

GetDCRows_Resume:
   Exit Function
   
GetDCRows_Error:
   GetDCRows = False
   Resume GetDCRows_Resume
   
End Function

Public Function GetCurrentRowNumber(DC As Data) As Long

    'On Error GoTo GetCurrentRowNumber_Error

    'Declare variables.
    Dim X As Long, OrigMousePointer As Integer
    Dim RowNum As Long
    Dim MyClone As Dynaset
    Dim CloneBook As String, DCBook As String
    'Initialize variables.
    RowNum = 0
    OrigMousePointer = Screen.MousePointer
    'Indicate delay.
    Screen.MousePointer = HOURGLASS
    'Create a clone of the result set and make sure the record count is current.
    Set MyClone = DC.Recordset.Clone()
    If Not MyClone.BOF And Not MyClone.EOF Then
        MyClone.MoveLast
        MyClone.MoveFirst
    Else
        GoTo GetCurrentRowNumber_Resume
    End If
    'Move through rows of the clone while counting them until we find the
    'row currently displayed.
    CloneBook = MyClone.Bookmark
    DCBook = DC.Recordset.Bookmark
    For X = 0 To MyClone.RecordCount - 1
        RowNum = X + 1
        If CloneBook = DCBook Then
            Exit For
        Else
            'MsgBox "MyClone=" & MyClone("f_name") & ", DC=" & DC.Recordset("f_name")
            MyClone.MoveNext
            CloneBook = MyClone.Bookmark
        End If
    Next

GetCurrentRowNumber_Resume:
    On Error Resume Next
    GetCurrentRowNumber = RowNum
    MyClone.Close
    Screen.MousePointer = OrigMousePointer

End Function



Public Sub DisableCommandButtons(AnyForm As Form)
    'This routine will disable all command button controls
    'on the specified form.  This routine is applicable for
    'the following object types:
    '
    '   CommandButton - the standard VB command button
    '   SSCommand     - the Sheridan Software 3D command button which ships with VB3 professional.
    Dim i As Integer
    For i = 0 To AnyForm.Controls.Count - 1
        If TypeOf AnyForm.Controls(i) Is CommandButton Then
            AnyForm.Controls(i).Enabled = False
        'ElseIf TypeOf AnyForm.Controls(i) Is SSCommand Then: AnyForm.Controls(i).Enabled = False
        End If
    Next

End Sub

Public Sub EnableCommandButtons(AnyForm As Form)
    'This routine will enable all command button controls
    'on the specified form.  This routine is applicable for
    'the following object types:
    '
    '   CommandButton - the standard VB command button
    '   SSCommand     - the Sheridan Software 3D command button which ships with VB3 professional.

    Dim i As Integer
    For i = 0 To AnyForm.Controls.Count - 1
        If TypeOf AnyForm.Controls(i) Is CommandButton Then
            AnyForm.Controls(i).Enabled = True
        'ElseIf TypeOf AnyForm.Controls(i) Is SSCommand Then: AnyForm.Controls(i).Enabled = True
        End If
    Next

End Sub

Public Function FormLoaded(TheForm As Form) As Integer

    'This function returns True if the specified form is loaded into memory
    'and False if not.  The function searches for Forms array looking for the specified
    'form.

    On Error GoTo FormLoaded_Error

    'Initialize return value.
    FormLoaded = False
    'Declare variables.
    Dim OrigMousePointer As Integer
    Dim i As Integer
    'Initialize variables.
    OrigMousePointer = Screen.MousePointer
    'Indicate delay.
    Screen.MousePointer = HOURGLASS

    For i = 0 To 200 'Forms.Count - 1 'insurance to make sure loop ends
        If Forms(i) Is TheForm Then
            FormLoaded = True
            Exit For
        End If
    Next i

FormLoaded_Resume:
    'Return mousepointer to its original state.
    Screen.MousePointer = OrigMousePointer

Exit Function

FormLoaded_Error:
    If IsError("FormLoaded") Then
        Resume FormLoaded_Resume
    Else
        Resume FormLoaded_Resume
'        Resume Next
    End If


End Function



Public Function DateFormatOk(ByVal TheControl As Control) As Integer
      
    DateFormatOk = True
    Dim Bad_AM_PM As Integer
    'check for valid AM or PM
    If TheControl.Text Like "*[a-z]*" Or TheControl.Text Like "*[A-Z]*" Then
      If InStr(1, TheControl.Text, " AM", 1) > 0 Or InStr(1, TheControl.Text, " PM", 1) > 0 Then
         Bad_AM_PM = False
       Else
         Bad_AM_PM = True
       End If
    Else
       Bad_AM_PM = False
    End If

    If TheControl.Text <> "" Then
        'Check to see if what they entered is a valid date
        If IsDate(TheControl.Text) And Bad_AM_PM = False And (TheControl.Text Like "#/#/##*" Or TheControl.Text Like "#/##/##*" Or TheControl.Text Like "##/#/##*" Or TheControl.Text Like "##/##/##*") Then
        Else
            DateFormatOk = False
        End If
    End If

End Function

Public Function OtherGuestFormsInBrowseMode() As Integer
  
  Dim TempStr As String
  OtherGuestFormsInBrowseMode = False
  For i = 0 To Forms.Count - 1
     TempStr = Forms(i).Name
     If TempStr = "frmAccommodations" Or _
        TempStr = "frmGeneralGuest" Or _
        TempStr = "frmPayment" Or _
        TempStr = "frmGuestTravel" Or _
        TempStr = "frmGuestCar" Then
       If GetFormMode(Forms(i)) = "Browse" Then
          OtherGuestFormsInBrowseMode = True
          Exit For
       End If
     End If
  Next i

End Function

Public Function GetWindowsDir() As String
    
    Temp$ = String$(145, 0)              ' Size Buffer
    X = GetWindowsDirectory(Temp$, 145)  ' Make API Call
    Temp$ = Left$(Temp$, X)              ' Trim Buffer

    If Right$(Temp$, 1) <> "\" Then      ' Add \ if necessary
        GetWindowsDir$ = Temp$ + "\"
    Else
        GetWindowsDir$ = Temp$
    End If

End Function

Public Function CurrencyToText(TheValue As String) As String
'*(chk_text.rmd - Sets variable prnt_text for longhand check amount.)
'SELECT SUM(trueamt) INTO truetmp FROM checktmp
'SET VAR numtmp TEXT = (CTXT(.truetmp))
'SET VAR ten_thou = NULL
'SET VAR thou = NULL
'SET VAR hundreds = NULL
'SET VAR tens = NULL
'SET VAR ones = NULL

'********** Use this method to call this function !! **
'String to be processed must be of the form: ...##.##
'with any number of DIGITS to left of decimal and two
'DIGITS to right of decimal. Function will strip all non-
'digit text from string except the decimal point before
'processing number into text.
'******************************************************
'*  Dim x, y, z As String                             *
'*  z = "25275"                                       *
'*  x = Format(z, CURRENCYFORMAT)                     *
'*  y = CurrencyToText(CStr(x))                       *
'******************************************************

Dim numtmp, hundred_thou, ten_thou, thou, hundreds, tens, ones, txt2, chk_text, v_cents, prnt_text As String
Dim Criteria As String

'Strip all non-numeric characters (ie: '$',',', etc) from string EXCEPT the decimal (.)
For i = 1 To Len(TheValue)
  If IsNumeric(Mid(TheValue, i, 1)) Or Mid(TheValue, i, 1) = "." Then
     numtmp = numtmp & Mid(TheValue, i, 1)
  End If
Next i

Dim SSMath As Recordset
Set SSMath = gBNB.OpenRecordset("select * from math_tbl", dbOpenSnapshot)
GetSSRows SSMath
If SSMath.EOF And SSMath.BOF Then
  MsgBox "Currency to Text conversion table (math_tbl) is empty!"
  Exit Function
End If
Select Case (Len(numtmp))
  Case 9
      '**** calculate hundred-thousands value
      Criteria = "numval = '" & Mid(numtmp, 1, 1) & "'"
      SSMath.FindFirst Criteria
      hundred_thou = SSMath("txtval")
      hundred_thou = hundred_thou & " HUNDRED "
      If Mid(numtmp, 2, 2) = "00" Then
         ten_thou = ""
      ElseIf Mid(numtmp, 2, 1) = "0" Then
         ten_thou = ""
         Criteria = "numval = '" & Mid(numtmp, 3, 1) & "'"
         SSMath.FindFirst Criteria
         hundred_thou = hundred_thou & SSMath("txtval")
      Else
         '**** calculate ten-thousands value
         Criteria = "numval = '" & Mid(numtmp, 2, 2) & "'"
         SSMath.FindFirst Criteria
         If SSMath.NoMatch Then
            Criteria = "numval = '" & Mid(numtmp, 2, 1) & "0'"
            SSMath.FindFirst Criteria
            ten_thou = SSMath("txtval")
            Criteria = "numval = '" & Mid(numtmp, 3, 1) & "'"
            SSMath.FindFirst Criteria
            txt2 = SSMath("txtval")
            ten_thou = ten_thou & " " & txt2
         Else
            ten_thou = SSMath("txtval")
         End If
      End If
      hundred_thou = hundred_thou & ten_thou & " THOUSAND "
      '**** calculate hundreds value
      If Mid(numtmp, 4, 1) = "0" Then
         hundreds = ""
      Else
        Criteria = "numval = '" & Mid(numtmp, 4, 1) & "'"
        SSMath.FindFirst Criteria
        hundreds = SSMath("txtval")
        hundreds = hundreds & " " & "HUNDRED "
      End If
      '**** calculate tens value
      If Mid(numtmp, 5, 1) = "0" Then
         tens = ""
      Else
         Criteria = "numval = '" & Mid(numtmp, 5, 2) & "'"
         SSMath.FindFirst Criteria
         If SSMath.NoMatch Then
           Criteria = "numval = '" & Mid(numtmp, 5, 1) & "0'"
           SSMath.FindFirst Criteria
         End If
         tens = SSMath("txtval") & " "
      End If
      '**** Calculate ones value. First, check for ten, eleven, twelve or teens
      'because these are already done in tens section.
      If Mid(numtmp, 5, 1) <> "1" Then
          If Mid(numtmp, 6, 1) = "0" Then
             ones = ""
          Else
            Criteria = "numval = '" & Mid(numtmp, 6, 1) & "'"
            SSMath.FindFirst Criteria
            ones = SSMath("txtval") & " "
          End If
      Else
         ones = ""
      End If
      If tens <> "" And ones <> "" Then
        chk_text = hundred_thou & hundreds & RTrim(tens) & "-" & LTrim(ones)
      Else
        chk_text = hundred_thou & hundreds & tens & ones
      End If
  Case 8
      '**** calculate ten-thousands value
      Criteria = "numval = '" & Mid(numtmp, 1, 2) & "'"
      SSMath.FindFirst Criteria
      If SSMath.NoMatch Then
        Criteria = "numval = '" & Mid(numtmp, 1, 1) & "0'"
        SSMath.FindFirst Criteria
        ten_thou = SSMath("txtval")
        Criteria = "numval = '" & Mid(numtmp, 2, 1) & "'"
        SSMath.FindFirst Criteria
        txt2 = SSMath("txtval")
        ten_thou = ten_thou & " " & txt2
      Else
         ten_thou = SSMath("txtval")
      End If
      ten_thou = ten_thou & " THOUSAND "
      '**** calculate hundreds value
      If Mid(numtmp, 3, 1) = "0" Then
         hundreds = ""
      Else
        Criteria = "numval = '" & Mid(numtmp, 3, 1) & "'"
        SSMath.FindFirst Criteria
        hundreds = SSMath("txtval")
        hundreds = hundreds & " " & "HUNDRED "
      End If
      '**** calculate tens value
      If Mid(numtmp, 4, 1) = "0" Then
         tens = ""
      Else
         Criteria = "numval = '" & Mid(numtmp, 4, 2) & "'"
         SSMath.FindFirst Criteria
         If SSMath.NoMatch Then
           Criteria = "numval = '" & Mid(numtmp, 4, 1) & "0'"
           SSMath.FindFirst Criteria
         End If
         tens = SSMath("txtval") & " "
      End If
      '**** Calculate ones value. First, check for ten, eleven, twelve or teens
      'because these are already done in tens section.
      If Mid(numtmp, 4, 1) <> "1" Then
          If Mid(numtmp, 5, 1) = "0" Then
             ones = ""
          Else
            Criteria = "numval = '" & Mid(numtmp, 5, 1) & "'"
            SSMath.FindFirst Criteria
            ones = SSMath("txtval") & " "
          End If
      Else
         ones = ""
      End If
      If tens <> "" And ones <> "" Then
        chk_text = ten_thou & hundreds & RTrim(tens) & "-" & LTrim(ones)
      Else
        chk_text = ten_thou & hundreds & tens & ones
      End If
  Case 7
'*(thousands)
      Criteria = "numval = '" & Mid(numtmp, 1, 1) & "'"
      SSMath.FindFirst Criteria
      thou = SSMath("txtval")
      thou = thou & " THOUSAND "
'*(hundreds)
      If Mid(numtmp, 2, 1) = "0" Then
         hundreds = ""
      Else
        Criteria = "numval = '" & Mid(numtmp, 2, 1) & "'"
        SSMath.FindFirst Criteria
        hundreds = SSMath("txtval")
        hundreds = hundreds & " HUNDRED "
      End If
'*(tens)
      If Mid(numtmp, 3, 1) = "0" Then
         tens = ""
      Else
        Criteria = "numval = '" & Mid(numtmp, 3, 2) & "'"
        SSMath.FindFirst Criteria
        If SSMath.NoMatch Then
          Criteria = "numval = '" & Mid(numtmp, 3, 1) & "0'"
          SSMath.FindFirst Criteria
        End If
        tens = SSMath("txtval") & " "
      End If
'*(ones)
      If Mid(numtmp, 3, 1) <> "1" Then
        If Mid(numtmp, 4, 1) = "0" Then
           ones = ""
        Else
          Criteria = "numval = '" & Mid(numtmp, 4, 1) & "'"
          SSMath.FindFirst Criteria
          ones = SSMath("txtval") & " "
        End If
      Else
        ones = ""
      End If

      If tens <> "" And ones <> "" Then
         chk_text = thou & hundreds & RTrim(tens) & "-" & LTrim(ones)
      Else
         chk_text = thou & hundreds & tens & ones
      End If
  Case 6
'*(hundreds)
      Criteria = "numval = '" & Mid(numtmp, 1, 1) & "'"
      SSMath.FindFirst Criteria
      hundreds = SSMath("txtval")
      hundreds = hundreds & " HUNDRED "
'*(tens)
      If Mid(numtmp, 2, 1) = "0" Then
        tens = ""
      Else
        Criteria = "numval = '" & Mid(numtmp, 2, 2) & "'"
        SSMath.FindFirst Criteria
        If SSMath.NoMatch Then
          Criteria = "numval = '" & Mid(numtmp, 2, 1) & "0'"
          SSMath.FindFirst Criteria
        End If
        tens = SSMath("txtval") & " "
     End If
'*(ones)
      If Mid(numtmp, 2, 1) <> "1" Then
        If Mid(numtmp, 3, 1) = "0" Then
           ones = ""
        Else
          Criteria = "numval = '" & Mid(numtmp, 3, 1) & "'"
          SSMath.FindFirst Criteria
          ones = SSMath("txtval") & " "
        End If
      End If
      If tens <> "" And ones <> "" Then
         chk_text = hundreds & RTrim(tens) & "-" & LTrim(ones)
      Else
         chk_text = hundreds & tens & ones
      End If
  Case 5
'*(tens)
      Criteria = "numval = '" & Mid(numtmp, 1, 2) & "'"
      SSMath.FindFirst Criteria
      If SSMath.NoMatch Then
        Criteria = "numval = '" & Mid(numtmp, 1, 1) & "0'"
        SSMath.FindFirst Criteria
      End If
      tens = SSMath("txtval") & " "
'*(ones)
      If Mid(numtmp, 1, 1) <> "1" Then
        If Mid(numtmp, 2, 1) = "0" Then
          ones = ""
        Else
          Criteria = "numval = '" & Mid(numtmp, 2, 1) & "'"
          SSMath.FindFirst Criteria
          ones = SSMath("txtval") & " "
        End If
      Else
        ones = ""
      End If
      If tens <> "" And ones <> "" Then
        chk_text = RTrim(tens) + "-" & LTrim(ones)
      Else
        chk_text = tens & " " & ones
      End If
  Case 4
'*(ones)
      If Mid(numtmp, 1, 1) = "0" Then
        ones = ""
      Else
        Criteria = "numval = '" & Mid(numtmp, 1, 1) & "'"
        SSMath.FindFirst Criteria
        ones = SSMath("txtval") & " "
      End If
      chk_text = ones
  Case Else
      chk_text = ""
End Select
CurrencyToText = chk_text
If chk_text = "" Then chk_text = "ZERO "
v_cents = Mid(numtmp, (Len(numtmp) - 1), 2)
prnt_text = chk_text & "and " & v_cents & "/100"

CurrencyToText = prnt_text

End Function

Public Function Replace_All_In_With(v_all As String, ByVal v_in As String, v_with As String) As String
'This function will replace all instances of the string "v_All"
'contained in the string "v_In" with the string "v_With".
    Dim start, AllLength As Integer
    Dim LeftHalf, RightHalf As String
    start = 1
    AllLength = Len(v_all)
    'Do while the string we are looking for (All) is in the string we are searching (In).
    Do While InStr(1, v_in, v_all, 1)
        'Determine where in string "All" starts.
        'Begin search where "All" was last found to start.
        start = InStr(start, v_in, v_all, 1)
        LeftHalf = Left$(v_in, start - 1)
        RightHalf = Right$(v_in, Len(v_in) - start - AllLength + 1)
        v_in = LeftHalf & v_with & RightHalf
    Loop
    Replace_All_In_With = v_in
    
End Function



Public Sub SetToCurrencyFormat(TheForm As Form)

    For i = 0 To TheForm.Controls.Count - 1
       If TheForm.Controls(i).Tag = "Currency" Then
         If TheForm.Controls(i).Text <> "" Then
           'TempStr = Format(TheForm.Controls(i).Text, CURRENCYFORMAT)
           TheForm.Controls(i).Text = Format(TheForm.Controls(i).Text, CURRENCYFORMAT)
         End If
       End If
    Next i
    
End Sub



Public Sub CheckForNullDates(TheForm As Form, TheControl As Data)

  For i = 0 To TheForm.Controls.Count - 1
    If TheForm.Controls(i).Name Like "txt*" Then
      If TheForm.Controls(i).Tag = "Date" Then
         If Trim(TheForm.Controls(i).Text) = "" Then
            TheForm.datBrowse.Recordset.Fields(TheForm.Controls(i).DataField) = Null
         End If
      End If
    End If
  Next i
  
End Sub

Public Function UnbindNullDateControl(TheForm As Form, TheDataControl As Data, NullDateArray) As Integer
  
  UnbindNullDateControl = False

  Dim NumFields, i, j, k, l, m, IsAMemberOfSet As Integer
  NumFields = 0
  For i = 0 To TheForm.Controls.Count - 1
    If TheForm.Controls(i).Name Like "txt*" Then
      If TheForm.Controls(i).Tag = "Date" Or TheForm.Controls(i).Tag = "Number" Or TheForm.Controls(i).Tag = "Currency" Then
         If Trim(TheForm.Controls(i).Text) = "" Then
            'Now that all other conditions have been met, make sure the control we're looking at
            'is a member of the recordset passed in TheDataControl.
            IsAMemberOfSet = False
            'This will need to be changed. Possible to have 2 or more controls on form with same datafields.
            For l = 0 To TheDataControl.Recordset.Fields.Count - 1
               If TheForm.Controls(i).DataField = TheDataControl.Recordset.Fields(l).Name Then
                 IsAMemberOfSet = True
                 Exit For
               End If
            Next l
            If IsAMemberOfSet Then NumFields = NumFields + 1
         End If
      End If
    End If
  Next i
  
  If NumFields = 0 Then Exit Function
  'MsgBox Str(NumFields)
  UnbindNullDateControl = True
  
  ReDim NullDateArray(NumFields - 1, 1)
  j = -1
  For i = 0 To TheForm.Controls.Count - 1
  If TheForm.Controls(i).Name Like "txt*" Then
    If TheForm.Controls(i).Tag = "Date" Or TheForm.Controls(i).Tag = "Number" Or TheForm.Controls(i).Tag = "Currency" Then
       If Trim(TheForm.Controls(i).Text) = "" Then
         'Now that all other conditions have been met, make sure the control we're looking at
         'is a member of the recordset passed in TheDataControl.
         IsAMemberOfSet = False
         'This will need to be changed. Possible to have 2 or more controls on form with same datafields.
         For l = 0 To TheDataControl.Recordset.Fields.Count - 1
            If TheForm.Controls(i).DataField = TheDataControl.Recordset.Fields(l).Name Then
              IsAMemberOfSet = True
              Exit For
            End If
         Next l
         If IsAMemberOfSet Then
           NumFields = NumFields + 1
           j = j + 1
           For k = 0 To 1
             If k = 0 Then
               NullDateArray(j, k) = TheForm.Controls(i).Name
             Else
               NullDateArray(j, k) = TheForm.Controls(i).DataField
               'MsgBox NullDateArray(j, k)
             End If
           Next k
           TheDataControl.Recordset.Fields(TheForm.Controls(i).DataField).Value = Null
           TheForm.Controls(i).DataField = ""
         End If
       End If
    End If
  End If
Next i
   
End Function

Public Sub BindNullDateControl(TheForm, NullDateArray)

   Dim i, j, k As Integer
   For j = 0 To UBound(NullDateArray)
     For i = 0 To TheForm.Controls.Count - 1
        If TheForm.Controls(i).Name = NullDateArray(j, 0) Then
           TheForm.Controls(i).DataField = NullDateArray(j, 1)
           Exit For
        End If
     Next i
   Next j

End Sub

Public Sub TrendsReport()

    Screen.MousePointer = HOURGLASS

    Dim i As Integer
    gCaption = "Trends Report"
    If frmTrendsDialog.optRoomNights.Value Then
        Dim frmRoomNights As New frmTrendsGraph  'Declare a new instance.
        frmRoomNights.graBarChart.LeftTitle = "Room Nights"
        Call IncrementReportNo(True)
        frmRoomNights.Show
        'Allow screen painting to catch up.
        For i = 1 To 5
            DoEvents
        Next i
        frmRoomNights.Caption = gCaption
    ElseIf frmTrendsDialog.optServiceFee.Value Then
        Dim frmServiceFee As New frmTrendsGraph  'Declare a new instance.
        frmServiceFee.graBarChart.LeftTitle = "Service Fee"
        Call IncrementReportNo(True)
        frmServiceFee.Show
        'Allow screen painting to catch up.
        For i = 1 To 5
            DoEvents
        Next i
        frmServiceFee.Caption = gCaption
    ElseIf frmTrendsDialog.optReservationFee.Value Then
        Dim frmResFee As New frmTrendsGraph  'Declare a new instance.
        frmResFee.graBarChart.LeftTitle = "Reservation Fee"
        Call IncrementReportNo(True)
        frmResFee.Show
        'Allow screen painting to catch up.
        For i = 1 To 5
            DoEvents
        Next i
        frmResFee.Caption = gCaption
    ElseIf frmTrendsDialog.optBookings.Value Then
        Dim frmBookings As New frmTrendsGraph  'Declare a new instance.
        frmBookings.graBarChart.LeftTitle = "Bookings"
        Call IncrementReportNo(True)
        frmBookings.Show
        'Allow screen painting to catch up.
        For i = 1 To 5
            DoEvents
        Next i
        frmBookings.Caption = gCaption
    End If

    Screen.MousePointer = DEFAULT

End Sub

Public Function GetNextTableName() As Integer
          
   Dim SSTemp As Recordset
   GetNextTableName = True
'MsgBox Trim(Str(CInt(Right(gTableName, 2) + 1)))
   'Global Temp Table variable gTableName is set to <YOURCOMPUTERNAME>_10
   '(eg, WORKSTATION1_10) in mdiBNB_Load, so the first table actually
   'used will be WORKSTATION1_10 + 1 (or, WORKSTATION1_11). Numbers can go
   'up to 99, then all temp tables will be dropped,user will be notified
   'that system has resolved itself, and that they need to repeat their
   'last command. This whole scenario should rarely (if ever) occur, and then
   'only when user never exits the program (tables are dropped upon entry and exit).
   'These would need to occur for this routine to fire:
   '1.Leave computer on always and never exit program.
   '3.AND/OR Run LOTS of travel commission reports, etc. w/out exiting.
   If Val(Trim(Right(gTableName, 2) + 1)) > 99 Then
      'Drop any temporary tables created during this session.
      '(Tables are of the form: MYCOMPUTERNAME_XX). And
      'reset global gTableName to original state (MYCOMPUTERNAME_11).
      gSQL = "select name from MSysObjects where name like " & Chr$(34) & gComputerName & "_*" & Chr$(34)
      Set SSTemp = gBNB.OpenRecordset(gSQL, dbOpenSnapshot)
      If SSTemp.RecordCount > 0 Then
        GetSSRows SSTemp
        'Drop tables
        For i = 0 To SSTemp.RecordCount - 1
'MsgBox SSTemp("name")
          gBNB.Execute "DROP TABLE " & SSTemp("name") & ";"
          SSTemp.MoveNext
        Next i
      End If
      SSTemp.Close
      'Reset global TableName variable
      gTableName = gComputerName & "_10"
      gMsg = "The maximum number of temporary tables per session has been " & _
             "exceeded. The system has resolved this for you, but your last command " & _
             "will need to be re-executed."
      GetNextTableName = False
   Else
      gTableName = (Left(gTableName, Len(gTableName) - 2)) & Trim(Str(CInt(Right(gTableName, 2) + 1)))
   End If
   
End Function



Public Function ExportDialog(TheForm As Form, TheDS As Recordset) As Integer

    'Displays and set the properites of the Export Data Dialog box (i.e., frmExportDialog)

    'Parameters:
    '   TheForm is the name of the form calling the export dialog box.
    '   TheDS is the name of the dynaset from which data is to be exported.

    'Return values:
    '   True (-1) if no errors and user did not cancel.
    '   False (0) if an error occurred or the user cancelled export in the dialog box.


    On Error GoTo ExportDialog_Error
    
    'Declare variables.
    Dim TheDG As Control
    Dim i As Integer

    'Set export dialog box properties...
    Load frmExportDialog
    frmExportDialog.txtCallingFormCaption.Text = TheForm.Caption
    'Record row column values in the tag property and use those values to enforce range limits.
    'First, set row range limits
    If TheDS.RecordCount = 0 Then
        frmExportDialog.txtFirstRow.Tag = 0
        frmExportDialog.txtLastRow.Tag = 0
    Else
        frmExportDialog.txtFirstRow.Tag = 1
        frmExportDialog.txtLastRow.Tag = TheDS.RecordCount
    End If
    'Next, set column range limits
    frmExportDialog.txtFirstCol.Tag = 1
    frmExportDialog.txtLastCol.Tag = TheDS.Fields.Count
    'Set displayed range (text) values based on range limits set forth in tag properties.
    frmExportDialog.txtFirstRow.Text = frmExportDialog.txtFirstRow.Tag
    frmExportDialog.txtLastRow.Text = frmExportDialog.txtLastRow.Tag
    frmExportDialog.txtFirstCol.Text = frmExportDialog.txtFirstCol.Tag
    frmExportDialog.txtLastCol.Text = frmExportDialog.txtLastCol.Tag

    'Now adjust values to reflect selected rows or columns, if any.
    For i = 0 To TheForm.Controls.Count - 1
        'Examine all controls on the form and see if any is a DataGrid.
        If TypeOf TheForm.Controls(i) Is SSDBGrid Then   'DataGrid exists on calling form.
            Set TheDG = TheForm.Controls(i)
            Dim j As Integer
            If TheDG.SelBookmarks.Count > 0 Then
              TheDG.Visible = False
              'Find selected ROWS
              j = TheDG.SelBookmarks.Count
              TheDG.Bookmark = TheDG.SelBookmarks(0)
              frmExportDialog.txtFirstRow.Text = TheDG.AddItemRowIndex(TheDG.Bookmark) + 1
              'MsgBox frmPrintDialog.txtFirstRow.Text
              TheDG.Bookmark = TheDG.SelBookmarks(j - 1)
              frmExportDialog.txtLastRow.Text = TheDG.AddItemRowIndex(TheDG.Bookmark) + 1
              'MsgBox frmPrintDialog.txtLastRow.Text
              TheDG.Visible = True
            Else
              frmExportDialog.txtFirstRow.Text = 1
              frmExportDialog.txtLastRow.Text = TheDG.Rows
            End If
            'Find selected COLS
            Dim FirstCol, LastCol, X, y As Integer
            FirstCol = -1
            LastCol = -1
            For X = 0 To TheDG.Cols - 1
               For y = 0 To TheDG.Cols - 1
                 If TheDG.Columns(y).TagVariant = X Then
                    If TheDG.Columns(y).Selected Then
                       If FirstCol = -1 Then FirstCol = X
                       LastCol = X
                    End If
                 End If
               Next y
            Next X
            If FirstCol > -1 Then
               frmExportDialog.txtFirstCol.Text = FirstCol + 1
               frmExportDialog.txtLastCol.Text = LastCol + 1
            Else
               frmExportDialog.txtFirstCol.Text = 1
               frmExportDialog.txtLastCol.Text = TheDG.Cols
            End If
            'paultest - Fix col
            'ElseIf TheDG.Selbook > -1 Then
            '    frmExportDialog.txtFirstCol.Text = TheDG.SelStartCol + 1
            '    frmExportDialog.txtLastCol.Text = TheDG.SelEndCol + 1
            'End If
            'No need to look further.
            Exit For
        End If
    Next i

    'Transfer control to dialog box.
    frmExportDialog.Show 1  'Modal
    
    'If the export dialog was cancelled, then don't export (i.e., Save)
    'and return form to normal in calling routine.
    If frmExportDialog.optCancelled Then
        ExportDialog = False
    Else
        ExportDialog = True
    End If


Exit Function

ExportDialog_Error:
    'User pressed common dialog box's cancel button is Err# 32755
    If Err <> 32755 Then i = IsError("ExportDialog")   'If not intentional, display message.
    Resume ExportDialog_Resume
Exit Function

ExportDialog_Resume:
    ExportDialog = False

End Function

Public Function ExportData(MyForm As Form, MyDS As Recordset) As Integer

    'Exports data from a Dynaset to a local file.
    'Makes use of export dialog box (i.e.,frmExportDialog)

    'Parameters:
    '   MyDS is the name of the dynaset from which data is to be exported.

    'Return values:
    '   True (-1) if no errors and data was successfully exported to file.
    '   False (0) if an error occurred and export was unsuccessful.

    On Error GoTo ExportData_Error

    'Declare variables.
    Dim i, X, y As Integer
    Dim OrigMousePointer As Integer

    'Initialize variables.
    OrigMousePointer = Screen.MousePointer

    'Change Screen's mousepointer to HOURGLASS to indicate delay.
    Screen.MousePointer = HOURGLASS

    'Declare export variables
    Dim FNum    'File number
    Dim FirstRow, LastRow, FirstCol, LastCol As Long    'range of data to save
    Dim FldValue As Variant     'a not Null value in the result set, or the string "NULL"
    Dim Delimiter As String     'the character of the delimiter used in the text file output.
    Dim Segment As String       'Code Segment identifier for error message.

    'Set start and end positions based on dialog box.
    Segment = "Part 1"
    FirstRow = CLng(frmExportDialog.txtFirstRow.Text) - 1   'remember: row numbers are zero based.
    LastRow = CLng(frmExportDialog.txtLastRow.Text) - 1
    FirstCol = CLng(frmExportDialog.txtFirstCol.Text) - 1
    LastCol = CLng(frmExportDialog.txtLastCol.Text) - 1
    ReDim ColOutputLength(FirstCol To LastCol) As Integer

    'Set column delimiter   (row delimiter is always carriage return + line feed)
    Segment = "Part 2"
    If frmExportDialog.txtComboFormat.Text = "Pipe Delimited" Then
        'Windows Pipe delimited text file
        Delimiter = "|"
    ElseIf frmExportDialog.txtComboFormat.Text = "Comma Delimited" Then
        'Windows comma delimited text file
        Delimiter = ","
    ElseIf frmExportDialog.txtComboFormat.Text = "Space Delimited" Then
        'Windows space delimited text file
        Delimiter = " "
    Else    'frmExportDialog.txtComboFormat.Text = "Tab Delimited"
        'Windows tab delimited text file
        Delimiter = Chr$(9)
    End If

    'If Space Delimited then set the fixed Column Output Lengths
    Segment = "Part 3"
    If Delimiter = " " Then
        'Position cursor at first row to be saved, in order to read cell values later.
        If Not MyDS.BOF And Not MyDS.EOF Then   'Rows exist
            'Position at first row
            MyDS.MoveFirst
            'Now position to first row to be saved.
            If FirstRow > 0 Then    'remember: row numbers are zero based.
                For X = 0 To FirstRow - 1
                    MyDS.MoveNext
                Next X
            End If
        End If
        For y = FirstCol To LastCol 'range of columns
'MsgBox "SourceTable: " & MyDS.Fields(y).SourceTable
'MsgBox "SourceField: " & MyDS.Fields(y).SourceField
'msg = "Name is " & MyDS.Fields(y).Name & Chr$(13) & Chr$(10) & "Type is " & MyDS.Fields(y).Type & Chr$(13) & Chr$(10) & "Size is " & MyDS.Fields(y).Size & Chr$(13) & Chr$(10) ' & Chr$(13) & Chr$(10) & "GetFieldSize is " & GetFieldSize(MyDS.Fields(y).SourceTable, MyDS.Fields(y).SourceField)
'MsgBox "Name is " & MyDS.Fields(y).Name & Chr$(13) & Chr$(10) & "Type is " & MyDS.Fields(y).Type & Chr$(13) & Chr$(10) & "Size is " & MyDS.Fields(y).Size & Chr$(13) & Chr$(10)  ' & Chr$(13) & Chr$(10) & "GetFieldSize is " & GetFieldSize(MyDS.Fields(y).SourceTable, MyDS.Fields(y).SourceField)
'If MyDS.Fields(y).Type = 10 Or MyDS.Fields(y).Type = 11 Or MyDS.Fields(y).Type = 12 Then msg = msg & Chr$(13) & Chr$(10) & "Field Size is " & MyDS.Fields(y).FieldSize()
'MsgBox msg
            ColOutputLength(y) = 4  'Minimum output length
            'Use the field size instead if the field size is greater than the minimum output length.
            If MyDS.Fields(y).Size > 4 Then ColOutputLength(y) = MyDS.Fields(y).Size
            'Use the FieldSize() method as well (good for long binary & memo fields).  Use this if larger than field size property.
            If MyDS.Fields(y).Type = 10 Or MyDS.Fields(y).Type = 11 Or MyDS.Fields(y).Type = 12 Then If MyDS.Fields(y).FieldSize() > ColOutputLength(y) Then ColOutputLength(y) = MyDS.Fields(y).FieldSize()
            'Use the column header size if the column header is greater in length than the field size,
            'and the column headers are to be included.
            If frmExportDialog.chkHeaders Then
                If Len(RTrim$(MyDS.Fields(y).Name)) > ColOutputLength(y) Then ColOutputLength(y) = Len(RTrim$(MyDS.Fields(y).Name))
            End If
            'Evaluate the data in the first row, if exists, and use the output length of the cell
            'value if it is greater than the previously calculated column output length.
            'Programmers note:  Formating of dates and numeric values may result in data values
            'whos output length is greater than any of the previously calculated values.
            If Not MyDS.BOF And Not MyDS.EOF Then   'Rows exist
                'Record the value for this cell.  Replace the Null value with the string "NULL"
                If IsNull(MyDS.Fields(y).Value) Then
                    FldValue = ""
                 Else
                    FldValue = RTrim(MyDS.Fields(y).Value)
                End If
                'Compare the length of the cell value versus the Column Output Length and adjust as necessary.
                If Len(FldValue) > ColOutputLength(y) Then ColOutputLength(y) = Len(FldValue)
            End If
            'Now that we have determined the largest possible output column length such that
            'data shall not overflow into another column's range of output,
            'Add one extra space as a seperator between output columns.
            ColOutputLength(y) = ColOutputLength(y) + 1
        Next y
    End If  '... End Space Delimited fixed output column length calculations.
    'Save data into delimited ASCII file ...
    Segment = "Part 4"
    FNum = FreeFile
    'Open file on client.
    If frmExportDialog.chkAppend Then
        'Append output to existing file, if any
        Open frmExportDialog.CMDialog1.filename For Append As FNum
    Else
        'Overwrite existing file, if any
        Open frmExportDialog.CMDialog1.filename For Output As FNum
    End If
    'Output Caption if requested.
    Segment = "Part 5"
    If frmExportDialog.chkCaption Then Print #FNum, MyForm.Caption & Chr$(13) & Chr$(10);
    'Output Column Headers if requested.
    Segment = "Part 6"
    If frmExportDialog.chkHeaders Then
        For y = FirstCol To LastCol 'range of columns
            If y = LastCol Then     'end with hard return
                Print #FNum, MyDS.Fields(y).Name & Chr$(13) & Chr$(10);
            Else
                If Delimiter = " " Then
                    'space delimited
                    Print #FNum, RFill(RTrim$(MyDS.Fields(y).Name), " ", ColOutputLength(y)); 'Print header padded with trailing blanks (if any).
                Else
                    'character delimited
                    Print #FNum, MyDS.Fields(y).Name & Delimiter;
                End If
            End If
        Next y
    End If
    'OUTPUT DATA ...
    Segment = "Part 7"
    'First verify that there is data to be saved.  Any rows?
    If MyDS.BOF And MyDS.EOF Then GoTo ExportData_Resume    'No rows.  Note that a file will be saved at this point with caption and column headers if requested.

    'Position at first row
    MyDS.MoveFirst
    'Now position to first row to be saved.
    If FirstRow > 0 Then    'remember: row numbers are zero based.
        For X = 0 To FirstRow - 1
            MyDS.MoveNext
        Next X
    End If
    For X = FirstRow To LastRow
        For y = FirstCol To LastCol
            'Record the value for this cell.  Replace the Null value with the string "NULL"
            If IsNull(MyDS.Fields(y).Value) Then
                FldValue = ""
            Else
                FldValue = RTrim(MyDS.Fields(y).Value)
            End If
            'Date type = 8
            If MyDS.Fields(y).Type = 8 And FldValue <> "" Then
                FldValue = Format$(MyDS.Fields(y), frmListDialog.txtComboDateFormat.Text)
            End If
            'Write data value to file ...
            If y = LastCol Then     'this is the last data value for row x.
                Print #FNum, FldValue;
            Else
                If Delimiter = " " Then
                'space delimited
                    Print #FNum, RFill(FldValue, " ", ColOutputLength(y)); 'Print header padded with trailing blanks (if any).
                Else
                    'character delimited
                    Print #FNum, FldValue & Delimiter;
                End If
            End If
        Next y
        Print #FNum, Chr$(13) & Chr$(10);   'hard return at end of each row (record)
        MyDS.MoveNext
    Next X
    'Close the output file
    Segment = "Part 8"
    Close #FNum

    'Reset Screen's mousepointer to original state.
    Screen.MousePointer = OrigMousePointer

    'Set successful export return value
    ExportData = True

Exit Function

ExportData_Error:
    i = IsError("BNB1.BAS: ExportData - " & Segment)
    Resume ExportData_Resume
Exit Function

ExportData_Resume:
    Segment = "Part 9"
    'Close the output file
    Close #FNum
    'Reset Screen's mousepointer to original state.
    Screen.MousePointer = OrigMousePointer
    'Set unsuccessful export return value
    ExportData = False

End Function



Public Function RFill(ByVal s As String, ByVal c As String, ByVal N As Integer) As String

    'This function appends trailing character C to a string S until the length of string S equals N.

    'If the passed C value is a zero length string then replace with a single blank.
    If c = "" Then c = " "
    'Only use the first character if more than one provided.
    c = Left$(c, 1)

    'Append C to S until Length of S = N
    Do While Len(s) < N
        s = s & c
    Loop

    'Return right filled string value
    RFill = s

End Function

'----------------------------------------------------------
' Check for the existence of a file by attempting an OPEN.
'----------------------------------------------------------
Public Function FileExists(ByVal path As String) As Integer

    'Function returns:
    '   True (-1) if file exists,
    '   False (0) if file does not exit,
    '   1 if unexpected error occurred.

    On Error GoTo FileExists_Error

    Dim i, X As Integer

    X = FreeFile
    
    Open path For Input As X
    FileExists = True
    Close X

FileExists_Resume:

Exit Function

FileExists_Error:
    If Err = 52 Or Err = 53 Or Err = 68 Or Err = 70 Or Err = 71 Or Err = 75 Or Err = 76 Then     'Bad File Name or Number, or File not found, or Device not available, or Permission Denied, or Disk Not Ready, or Path/File Access Error, or Path not found.
        FileExists = False
        Resume FileExists_Resume
    Else    'Unexpected error!
        FileExists = 1  'Error
        i = IsError("BNB1.BAS - FileExists (" & path & ")")
        Resume FileExists_Resume
    End If

End Function


Public Function GetWildcardDate(TheDate As String) As Integer

   GetWildcardDate = False
   Dim TempVal As String
   NL$ = Chr$(13) & Chr$(10)   'New Line of text.
   'Verify TheDate format
   If Not TheDate Like "*/*/*" Then GoTo Invalid_Date
   TempVal = TheDate
   gMonth = Mid(TempVal, 1, InStr(1, TempVal, "/") - 1)
   If gMonth Like "*[*]*" Then gMonth = "0"
   If Not IsNumeric(gMonth) Then GoTo Invalid_Date
   TempVal = Right(TempVal, Len(TempVal) - InStr(1, TempVal, "/"))
'MsgBox "gMonth=" & gMonth & ", TempVal=" & TempVal
   gDay = Mid(TempVal, 1, InStr(1, TempVal, "/") - 1)
   If gDay Like "*[*]*" Then gDay = "0"
   If Not IsNumeric(gDay) Then GoTo Invalid_Date
   TempVal = Right(TempVal, Len(TempVal) - InStr(1, TempVal, "/"))
'MsgBox "gDay=" & gDay & ", TempVal=" & TempVal
   gYear = TempVal
   If gYear Like "*[*]*" Then
      gYear = "0"
   Else
      'Make sure we have a 4-digit year. VB will force it to correct century
      If Not IsNumeric(gYear) Then GoTo Invalid_Date
      Dim TempDate As String
      TempDate = "1/1/" & gYear
      gYear = DatePart("yyyy", TempDate)
   End If
'MsgBox "gYear=" & gYear & ", TempVal=" & TempVal
   'Determine the 8 combination codes for date values
   If gMonth = "0" And gDay = "0" And gYear = "0" Then
      GoTo Invalid_Date
      'gWCardDateCase = 0
   ElseIf gMonth = "0" And gDay = "0" And gYear <> "0" Then
      gWCardDateCase = 1
   ElseIf gMonth = "0" And gDay <> "0" And gYear = "0" Then
      gWCardDateCase = 2
   ElseIf gMonth = "0" And gDay <> "0" And gYear <> "0" Then
      gWCardDateCase = 3
   ElseIf gMonth <> "0" And gDay = "0" And gYear = "0" Then
      gWCardDateCase = 4
   ElseIf gMonth <> "0" And gDay = "0" And gYear <> "0" Then
      gWCardDateCase = 5
   ElseIf gMonth <> "0" And gDay <> "0" And gYear = "0" Then
      gWCardDateCase = 6
   ElseIf gMonth <> "0" And gDay <> "0" And gYear <> "0" Then
      gWCardDateCase = 7
   End If
   
   GetWildcardDate = True
   Exit Function
   
Invalid_Date:
   gMsg = "Incorrect format for wildcard date. Try any of the " & _
          "following example formats:" & NL$ & _
          "5/*/*   Returns all dates in May for all years." & NL$ & _
          "5/*/99  Returns all dates in May, 1999." & NL & _
          "*/*/99  Returns all dates in 1999." & NL$ & _
          "*/14/99 Returns all dates for the 14th day of each month in 1999." & NL$ & _
          "There can be up to two wildcard characters (*) in any arrangement " & _
          "in a wildcard date. Numeric values cannot be combined with wildcard " & _
          "characters (eg, 5/14/199*)."
   
End Function

Public Function CalculateAmounts(AccomForm As Form) As Integer

   On Error GoTo CalculateAmounts_Error
   'Calculates all amounts upon commit of Accommodations form (frmAccom).
   'NOTE: Null number columns in Access are treated as 0
   CalculateAmounts = False
   Dim SSTemp As Recordset 'Temporary working recordset
   Dim Tax1, Tax2, Tax3, Tax1_2_3, vPercentToHost As Double
   Dim GrossXnites, GrossXpercent, vGrossRate As Currency
   Dim vTaxPlan As String
   Dim vNumNights As Integer
   'Ensure all current tax rates have been updated with the future
   'tax rates if the future tax's effective date <= today's date..
   Set SSTemp = gBNB.OpenRecordset("select * from taxrates", dbOpenSnapshot)
   GetSSRows SSTemp
   If SSTemp.RecordCount = 0 Then
      gMsg = "Tax rates have not been set. Set tax rates through 'Taxes' main menu selection."
      SSTemp.Close
      GoTo CalculateAmounts_Resume
   End If
   If Not IsNull(SSTemp("future_tax_one")) And Not IsNull(SSTemp("future_tax_one_eff_date")) Then
      If SSTemp("future_tax_one") <> SSTemp("tax_one") And SSTemp("future_tax_one_eff_date") <= Now Then
         gBNB.Execute "update taxrates set tax_one = " & SSTemp("future_tax_one")
      End If
   End If
   If Not IsNull(SSTemp("future_tax_two")) And Not IsNull(SSTemp("future_tax_two_eff_date")) Then
      If SSTemp("future_tax_two") <> SSTemp("tax_two") And SSTemp("future_tax_two_eff_date") <= Now Then
         gBNB.Execute "update taxrates set tax_two = " & SSTemp("future_tax_two")
      End If
   End If
   If Not IsNull(SSTemp("future_tax_three")) And Not IsNull(SSTemp("future_tax_three_eff_date")) Then
      If SSTemp("future_tax_three") <> SSTemp("tax_three") And SSTemp("future_tax_three_eff_date") <= Now Then
         gBNB.Execute "update taxrates set tax_three = " & SSTemp("future_tax_three")
      End If
   End If
   SSTemp.Close
   'Get the tax rates we will be working with. Whether we get the future rates or the
   'current rates depends upon the guest's arrival date.
   'Note: Current taxes will never be null. They are always converted (in code)to 0 if null.
   Set SSTemp = gBNB.OpenRecordset("select * from taxrates", dbOpenSnapshot)
   GetSSRows SSTemp
   If SSTemp("tax_one") = 0 Then gBNB.Execute "update taxrates set tax_one_desc = 'N/A'"
   If SSTemp("tax_two") = 0 Then gBNB.Execute "update taxrates set tax_two_desc = 'N/A'"
   If SSTemp("tax_three") = 0 Then gBNB.Execute "update taxrates set tax_three_desc = 'N/A'"
   If Not IsNull(SSTemp("future_tax_one")) Then
      If SSTemp("future_tax_one") <> SSTemp("tax_one") Then
         If CDate(Format(AccomForm.txtArrDate.Text, "m/d/yy")) >= CDate(SSTemp("future_tax_one_eff_date")) Then
            Tax1 = SSTemp("future_tax_one")
         Else
            Tax1 = SSTemp("tax_one")
         End If
      Else
         Tax1 = SSTemp("tax_one")
      End If
   Else
      If Not IsNull(SSTemp("tax_one")) Then
         Tax1 = SSTemp("tax_one")
      Else
         Tax1 = 0
      End If
   End If
   If Not IsNull(SSTemp("future_tax_two")) Then
      If SSTemp("future_tax_two") <> SSTemp("tax_two") Then
         If CDate(Format(AccomForm.txtArrDate.Text, "m/d/yy")) >= CDate(SSTemp("future_tax_two_eff_date")) Then
            Tax2 = SSTemp("future_tax_two")
         Else
            Tax2 = SSTemp("tax_two")
         End If
      Else
         Tax2 = SSTemp("tax_two")
      End If
   Else
      If Not IsNull(SSTemp("tax_two")) Then
         Tax2 = SSTemp("tax_two")
      Else
         Tax2 = 0
      End If
   End If
   If Not IsNull(SSTemp("future_tax_three")) Then
      If SSTemp("future_tax_three") <> SSTemp("tax_three") Then
         If CDate(Format(AccomForm.txtArrDate.Text, "m/d/yy")) >= CDate(SSTemp("future_tax_three_eff_date")) Then
            Tax3 = SSTemp("future_tax_three")
         Else
            Tax3 = SSTemp("tax_three")
         End If
      Else
         Tax3 = SSTemp("tax_three")
      End If
   Else
      If Not IsNull(SSTemp("tax_three")) Then
         Tax3 = SSTemp("tax_three")
      Else
         Tax3 = 0
      End If
   End If
   SSTemp.Close
   'Divide Taxes by 100 to use in calculations.
   Tax1 = Tax1 / 100
   Tax2 = Tax2 / 100
   Tax3 = Tax3 / 100
   'MsgBox Str(Tax1) & "," & Str(Tax2) & "," & Str(Tax3)
   'Get the tax plan to use in calculations.
   'If Change Tax Plan option is chosen on frmAccom, then use THAT plancode.
   If AccomForm.datdwComboTaxPlanCode.Text <> "" Then
      vTaxPlan = Trim(AccomForm.datdwComboTaxPlanCode.Text)
   Else
      Set SSTemp = gBNB.OpenRecordset("select tax_plan_code from proptbl where accountnum = " & Trim(AccomForm.lblAcctNum.Caption), dbOpenSnapshot)
      GetSSRows SSTemp
      If IsNull(SSTemp(0)) Or SSTemp(0) = "" Then
        gMsg = "In order to calculate amounts, a Tax Plan must be set " & _
               "for this property in the 'Host Account' screen. To override calculations " & _
               "and manually fillin amounts, check the 'Use manually entered Calculated Amounts' " & _
               "checkbox on the 'Accommodations' screen."
        SSTemp.Close
        'MsgBox gMsg, MB_ICONSTOP, AccomForm.Caption
        GoTo CalculateAmounts_Resume
      End If
      vTaxPlan = Trim(SSTemp(0))
      SSTemp.Close
   End If
   'Account for future percent to host.
   Set SSTemp = gBNB.OpenRecordset("select perdirect,futurepercent,futuredate from proptbl where accountnum = " & Trim(AccomForm.lblAcctNum.Caption), dbOpenSnapshot)
   GetSSRows SSTemp
   If Not IsNull(SSTemp("futurepercent")) And Not IsNull(SSTemp("futuredate")) Then
      If SSTemp("futurepercent") <> SSTemp("perdirect") And SSTemp("futuredate") <= Now Then
         gBNB.Execute "update proptbl set perdirect = " & SSTemp("futurepercent") & _
                      " where accountnum = " & Trim(AccomForm.lblAcctNum.Caption)
      End If
   End If
   'Get the Percentage Paid to Host from proptbl. The 'Over-ride Default Percentage'
   'option on frmAccom takes first precedence, then future, then default % to host.
   If Trim(AccomForm.txtPercent.Text) <> "" Then
      vPercentToHost = CDbl(Trim(AccomForm.txtPercent.Text)) / 100
   ElseIf Not IsNull(SSTemp("futurepercent")) And Not IsNull(SSTemp("futuredate")) Then
      If SSTemp("futurepercent") <> SSTemp("perdirect") Then
         If CDate(Format(AccomForm.txtArrDate.Text, "m/d/yy")) >= CDate(SSTemp("futuredate")) Then
            vPercentToHost = SSTemp("futurepercent") / 100
         Else
            vPercentToHost = SSTemp("perdirect") / 100
         End If
      Else
         vPercentToHost = SSTemp("perdirect") / 100
      End If
   Else
      If IsNull(SSTemp("perdirect")) Then
         gMsg = "'Percentage Paid to Host' is not set in the 'General Information' section of Host Account Information for this property!"
         SSTemp.Close
         GoTo CalculateAmounts_Resume
      End If
      vPercentToHost = SSTemp("perdirect") / 100
   End If
   SSTemp.Close
   'Set up some variables. Ensure those form fields needed in calculations are not blank.
   If Trim(AccomForm.txtDailyGrossRate.Text) = "" Then
      vGrossRate = 0
   Else
      vGrossRate = CCur(AccomForm.txtDailyGrossRate.Text)
   End If
   If Trim(AccomForm.txtNumNites.Text) = "" Then
      vNumNights = 0
   Else
      vNumNights = CInt(AccomForm.txtNumNites.Text)
   End If
   GrossXnites = vGrossRate * vNumNights
   GrossXpercent = vGrossRate * vPercentToHost

'MsgBox "GrossXnites=" & Str(GrossXnites) & ", GrossXpercent=" & Str(GrossXpercent)
   'Find how Tax#1 applies
   Select Case Mid(vTaxPlan, 1, 1)
      Case 0
         'Tax1 applies to Net
         T1@ = (GrossXpercent * vNumNights) * Tax1
'MsgBox Str(T1A_1@) & ", " & Str(T1A_2@) & ", " & Str(T1A_3@) & ", " & Str(T1A_4@)
      Case 1
         'Tax1 applies to Gross
         T1@ = GrossXnites * Tax1
      Case 2
         'Tax1 is not applied.
         T1@ = 0
         Tax1 = 0
      Case Else
   End Select
   'Find how Tax#2 applies
   Select Case Mid(vTaxPlan, 2, 1)
      Case 3
         'Tax2 applies to Net
         T2@ = (GrossXpercent * vNumNights) * Tax2
      Case 4
         'Tax2 applies to Gross
         T2@ = GrossXnites * Tax2
      Case 5
         'Tax2 is not applied.
         T2@ = 0
         Tax2 = 0
      Case Else
   End Select
   'Find how Tax#3 applies
   Select Case Mid(vTaxPlan, 3, 1)
      Case 6
         'Tax3 applies to Net
         T3@ = (GrossXpercent * vNumNights) * Tax3
      Case 7
         'Tax3 applies to Gross
         T3@ = GrossXnites * Tax3
      Case 8
         'Tax3 is not applied.
         T3@ = 0
         Tax3 = 0
      Case Else
   End Select
   Tax1_2_3 = Tax1 + Tax2 + Tax3
   T1@ = Format(T1@, CURRENCYFORMAT)
   T2@ = Format(T2@, CURRENCYFORMAT)
   T3@ = Format(T3@, CURRENCYFORMAT)
   If StrComp(Trim(AccomForm.datdwComboPaymentType.Text), "Prepay", 1) = 0 Then
      GwTax@ = Format(GrossXnites + (GrossXnites * Tax1_2_3), CURRENCYFORMAT)
      NwTax@ = Format((GrossXpercent * vNumNights) + T1@ + T2@ + T3@, CURRENCYFORMAT)
      TotTax@ = Format(GrossXnites * Tax1_2_3, CURRENCYFORMAT)
      'Set form values
      AccomForm.txtTax1.Text = T1@
      AccomForm.txtTax2.Text = T2@
      AccomForm.txtTax3.Text = T3@
      AccomForm.txtDailyNetRate.Text = Str(Format(GrossXpercent, CURRENCYFORMAT))
      AccomForm.txtTotTax.Text = Str(Format(TotTax@, CURRENCYFORMAT))
      AccomForm.txtTotGrossWithTax.Text = Str(Format(GrossXnites + TotTax@, CURRENCYFORMAT))
      AccomForm.txtTotNetWithTax.Text = Str(Format(NwTax@, CURRENCYFORMAT))
      AccomForm.txtServiceFee.Text = Str(Format(GwTax@ - NwTax@, CURRENCYFORMAT))
      'MsgBox Str(T1@) & ", " & Str(T2@) & ", " & Str(T3@)
      'MsgBox "GwTax=" & Str(GwTax@) & ", NwTax=" & Str(NwTax@) & ", TotTax=" & Str(TotTax@)
   ElseIf StrComp(Trim(AccomForm.datdwComboPaymentType.Text), "Direct", 1) = 0 Or _
          StrComp(Trim(AccomForm.datdwComboPaymentType.Text), "Comp", 1) = 0 Then
      'Set form values
      AccomForm.txtTax1.Text = 0
      AccomForm.txtTax2.Text = 0
      AccomForm.txtTax3.Text = 0
      AccomForm.txtDailyNetRate.Text = 0
      AccomForm.txtTotTax.Text = 0
      AccomForm.txtTotGrossWithTax.Text = 0
      AccomForm.txtTotNetWithTax.Text = 0
      AccomForm.txtServiceFee.Text = 0
   End If
   CalculateAmounts = True

CalculateAmounts_Resume:
   Exit Function
   
CalculateAmounts_Error:
   Resume CalculateAmounts_Resume
   
End Function

Public Sub GetSSRows(TheSS As Recordset)

    On Error GoTo GetSSRows_Error

    If Not TheSS.BOF And Not TheSS.EOF Then
       TheSS.MoveLast
       TheSS.MoveFirst
    End If
    
GetSSRows_Resume:
   Exit Sub
   
GetSSRows_Error:
   Resume GetSSRows_Resume

End Sub



Public Sub CloseHelpApp()

On Error GoTo CloseHelpApp_Error

'Activate help if it exists. If is is not running,
'AppActivate will generate an error.
'Since there is no need to close it
'if it is not running, just exit.
AppActivate "BNB Help", True
 
SendKeys "%{F4}", True

CloseHelpApp_Resume:
   Screen.MousePointer = DEFAULT
   Exit Sub

CloseHelpApp_Error:
   Resume CloseHelpApp_Resume

End Sub

Public Sub SetZeroLengthString(TheForm As Form)

   On Error GoTo SetZeroLengthString_Error
   
   Dim i As Integer
   For i = 0 To TheForm.Controls.Count - 1
      If TheForm.Controls(i).Name Like "txt*" Or TheForm.Controls(i).Name Like "datdwCombo*" Then
        If TheForm.Controls(i).Tag = "Text" Then
            TheForm.Controls(i).Text = " "
            TheForm.Controls(i).Text = ""
        End If
      End If
   Next i

SetZeroLengthString_Resume:
   Exit Sub
   
SetZeroLengthString_Error:
   Resume SetZeroLengthString_Resume
  
End Sub

Public Sub SetToCurrencyFormat2(TheForm As Form)

    For i = 0 To TheForm.Controls.Count - 1
       If TheForm.Controls(i).Tag = "Currency" Then
         If TheForm.Controls(i).Text <> "" Then
           'TempStr = Format(TheForm.Controls(i).Text, CURRENCYFORMAT)
           TheForm.Controls(i).Text = Format(TheForm.Controls(i).Text, CURRENCYFORMAT2)
         End If
       End If
    Next i
 
End Sub
