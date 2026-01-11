Attribute VB_Name = "modMode"
Option Explicit

Dim i As Integer
' Colors
'Public Const BLACK = &H0&
'Public Const RED = &HFF&
'Public Const GREEN = &HFF00&
'Public Const YELLOW = &HFFFF&
'Public Const BLUE = &HFF0000
'Public Const MAGENTA = &HFF00FF
'Public Const CYAN = &HFFFF00
'Public Const WHITE = &HFFFFFF

Function GetFormMode(TheForm As Form) As String
    'This function will return the mode of the specified
    'form, "TheForm".  Convention requires that the form's
    'mode be positioned to the right of the default caption,
    'and that the mode be encapsulated in "[]".
    'For example: Where TheForm.Caption = "Test [Browse]",
    '             then the mode is "Browse"
    '
    'If an error occurs, the function is return the string
    '"ERROR in GetFormMode!"
    '
    'If the form has no mode, then the function returns "Modeless".

    On Error GoTo GetFormMode_Error:

    Dim Temp As String
    Dim start, Finish As Long

    Temp = Format$(TheForm.Caption)
    start = InStr(1, Temp, "[")
    If start > 0 Then
        Finish = InStr(start, Temp, "]")
        If Finish > start Then
            Temp = Trim$(Mid$(Temp, start + 1, (Finish - start - 1)))
        Else
            Temp = "Modeless"
        End If
    Else
        Temp = "Modeless"
    End If
    GetFormMode = Temp
Exit Function

GetFormMode_Error:
    Resume GetFormMode_Resume
    
GetFormMode_Resume:
    GetFormMode = "ERROR in GetFormMode!"

End Function

Function IsCommandButton(TheControl As Control) As Integer
    'This function will return True (-1) if the control
    'is a command button or 3D command button, and False (0)
    'if it is neither.  Should an error occur, the function
    'will return the Visual Basic error number associated
    'with the error.

    'TheControl = The name of the control in question.

    On Error GoTo IsCommandButton_Error
    If TypeOf TheControl Is CommandButton Then
        IsCommandButton = True
    ElseIf TypeOf TheControl Is CommandButton Then
        IsCommandButton = True
    Else
        IsCommandButton = False
    End If
Exit Function

IsCommandButton_Error:
    IsCommandButton = Err
End Function

Function IsDataEntryBox(TheControl As Control) As Integer
    'This function will return True (-1) if the control
    'is a text box, masked edit box, combo box, or Data Widget
    'combo box. If the control none of those the function will
    'return False (0)
    '
    'Should an error occur, the function will return the
    'Visual Basic error number associated with the error.

    'TheControl = The name of the control in question.

    On Error GoTo IsDataEntryBox_Error
    If TypeOf TheControl Is ComboBox Then
        IsDataEntryBox = True
    ElseIf TypeOf TheControl Is TextBox Then
        IsDataEntryBox = True
    'ElseIf TypeOf TheControl Is MaskEdBox Then
    '    IsDataEntryBox = True
    ElseIf TypeOf TheControl Is ComboBox Then
        IsDataEntryBox = True
    Else
        IsDataEntryBox = False
    End If
Exit Function

IsDataEntryBox_Error:
    IsDataEntryBox = Err
End Function

Sub SetFormToBrowseMode(TheForm As Form)
  
    On Error Resume Next

    Dim Result&
    Screen.MousePointer = HOURGLASS
    'Change the form's caption to indicate the current mode of the form.
    TheForm.Caption = TrimModeFromCaption(TheForm) & "  [ Browse ]"
    'Do the following for all controls on the form.
    For i = 0 To TheForm.Controls.Count - 1
        If TheForm.Controls(i).Name Like "lbl*" Then
            'Go to next control.
        ElseIf TheForm.Controls(i).Name Like "cmd*" Then
            Select Case (TheForm.Controls(i).Caption)
             Case "&Update", "&Delete", "&Insert"
                 TheForm.Controls(i).Enabled = True
             Case "Co&mmit"
                 TheForm.Controls(i).DEFAULT = False
                 TheForm.Controls(i).Enabled = False
             Case "&Cancel"
                 TheForm.Controls(i).Enabled = False
             Case "&Run Query"
                 TheForm.Controls(i).Enabled = True
                 TheForm.Controls(i).Caption = "&Find"
             Case "&Room Types"
                 TheForm.Controls(i).Enabled = True
             Case "Display &Rows"
                 TheForm.Controls(i).Enabled = True
             Case "Print &Labels"
                 TheForm.Controls(i).Enabled = True
             Case "E&xit"
                 TheForm.Controls(i).Enabled = True
             Case "Common &Text"
                 TheForm.Controls(i).Enabled = False
             Case "R&efresh"
                 TheForm.Controls(i).Enabled = True
             Case "&Go to..."
                 TheForm.Controls(i).Enabled = True
             Case Else
                 TheForm.Controls(i).Enabled = True
             End Select
            'Enable the Tabstop
            TheForm.Controls(i).TabStop = True
        ElseIf TheForm.Controls(i).Name Like "out*" Then    'Outline control.
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "datdwData*" Then
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "opt*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "chk*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "datdwCombo*" Then
            'Turn the text color Black to indicate non-editable text.
             TheForm.Controls(i).ForeColor = BLACK
             TheForm.Controls(i).AllowInput = False
        ElseIf TheForm.Controls(i).Name Like "txt*" Then
            'Turn the text color Black to indicate non-editable text.
             TheForm.Controls(i).ForeColor = BLACK
             TheForm.Controls(i).Locked = True
        End If
    Next i

    'Enable the mdiForm's menu Exit option
    mdiBNB.mnuExit.Enabled = True
    'Re-enable the Close option on the form's system menu.
    RestoreSystemMenu TheForm
    Screen.MousePointer = DEFAULT

End Sub


Sub SetFormToDeleteMode(TheForm As Form)
    
    On Error Resume Next

    Dim Result&
    Screen.MousePointer = HOURGLASS
    'Change the form's caption to indicate the current mode of the form.
    TheForm.Caption = TrimModeFromCaption(TheForm) & "  [ Delete ]"
    'Do the following for all controls on the form.
    For i = 0 To TheForm.Controls.Count - 1
        If TheForm.Controls(i).Name Like "lbl*" Then
            'Go to next control.
        ElseIf TheForm.Controls(i).Name Like "cmd*" Then
            Select Case (TheForm.Controls(i).Caption)
             Case "&Update", "&Delete", "&Insert"
                 TheForm.Controls(i).Enabled = False
             Case "Co&mmit"
                 TheForm.Controls(i).Enabled = True
             Case "&Cancel"
                 TheForm.Controls(i).Enabled = True
             Case "Display &Rows"
                 TheForm.Controls(i).Enabled = False
             Case "&Room Types"
                 TheForm.Controls(i).Enabled = False
             Case "Print &Labels"
                 TheForm.Controls(i).Enabled = False
             Case "E&xit"
                 TheForm.Controls(i).Enabled = False
             Case "Common &Text"
                 TheForm.Controls(i).Enabled = False
             Case "R&efresh"
                 TheForm.Controls(i).Enabled = False
             Case "&Go to..."
                 TheForm.Controls(i).Enabled = False
             Case Else
                 TheForm.Controls(i).Enabled = False
             End Select
            'Enable the Tabstop
            TheForm.Controls(i).TabStop = True
        ElseIf TheForm.Controls(i).Name Like "out*" Then    'Outline control.
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "datdwData*" Then
             TheForm.Controls(i).Caption = "Disabled"
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "opt*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "chk*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "datdwCombo*" Then
            'Turn the text color Black to indicate non-editable text.
             TheForm.Controls(i).ForeColor = BLACK
             TheForm.Controls(i).AllowInput = False
        ElseIf TheForm.Controls(i).Name Like "txt*" Then
            'Turn the text color Black to indicate non-editable text.
             TheForm.Controls(i).ForeColor = BLACK
             TheForm.Controls(i).Locked = True
        End If
    Next i

    'Disable the mdiForm's menu Exit option to prevent the user from closing the application.
    mdiBNB.mnuExit.Enabled = True
    'Disable the form's system menu Close option.
    'RestoreSystemMenu TheForm
    DisableSystemMenuClose TheForm
    Screen.MousePointer = DEFAULT

End Sub


Sub SetFormToFindMode(TheForm As Form)
    
    On Error Resume Next

    Dim Result&
    Screen.MousePointer = HOURGLASS
    'Change the form's caption to indicate the current mode of the form.
    TheForm.Caption = TrimModeFromCaption(TheForm) & "  [ Find ]"
    'Do the following for all controls on the form.
    For i = 0 To TheForm.Controls.Count - 1
        If TheForm.Controls(i).Name Like "lbl*" Then
           TheForm.Controls(i).Enabled = True
            'Go to next control.
        ElseIf TheForm.Controls(i).Name Like "cmd*" Then
            Select Case (TheForm.Controls(i).Caption)
             Case "&Update", "&Delete", "&Insert"
                 TheForm.Controls(i).Enabled = False
             Case "Co&mmit"
                 TheForm.Controls(i).Enabled = False
             Case "&Cancel"
                 TheForm.Controls(i).Enabled = True
             Case "&Find"
                 TheForm.Controls(i).Enabled = True
                 TheForm.Controls(i).Caption = "&Run Query"
             Case "Display &Rows"
                 TheForm.Controls(i).Enabled = False
             Case "&Room Types"
                 TheForm.Controls(i).Enabled = False
             Case "Print &Labels"
                 TheForm.Controls(i).Enabled = False
             Case "E&xit"
                 TheForm.Controls(i).Enabled = False
             Case "Common &Text"
                 TheForm.Controls(i).Enabled = False
             Case "R&efresh"
                 TheForm.Controls(i).Enabled = False
             Case "&Go to..."
                 TheForm.Controls(i).Enabled = False
             Case Else
                 TheForm.Controls(i).Enabled = True
             End Select
            'Enaable the Tabstop
            TheForm.Controls(i).TabStop = True
        ElseIf TheForm.Controls(i).Name Like "out*" Then    'Outline control.
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "datdwData*" Then
             TheForm.Controls(i).Caption = "Disabled"
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "datdwCombo*" Then
            'Turn the text color Black to indicate non-editable text.
             TheForm.Controls(i).Text = ""
             TheForm.Controls(i).ForeColor = BLACK
             TheForm.Controls(i).AllowInput = True
        ElseIf TheForm.Controls(i).Name Like "opt*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "chk*" Then
             TheForm.Controls(i).Enabled = True
             TheForm.Controls(i).Value = UNCHECKED
        ElseIf TheForm.Controls(i).Name Like "txt*" Then
            'Turn the text color Black to indicate non-editable text.
             'TheForm.Controls(i).ForeColor = BLUE
             TheForm.Controls(i).Text = ""
             TheForm.Controls(i).Locked = False
             TheForm.Controls(i).Enabled = True
        End If
    Next i

    'Disable the mdiForm's menu Exit option to prevent the user from closing the application.
    mdiBNB.mnuExit.Enabled = True
    RestoreSystemMenu TheForm
    Screen.MousePointer = DEFAULT
    
End Sub

Sub SetFormToInsertMode(TheForm As Form)
    
    On Error Resume Next
    Dim Result&
    Screen.MousePointer = HOURGLASS
    'Change the form's caption to indicate the current mode of the form.
    TheForm.Caption = TrimModeFromCaption(TheForm) & "  [ Insert ]"
    'Do the following for all controls on the form.
    For i = 0 To TheForm.Controls.Count - 1
        If TheForm.Controls(i).Name Like "lbl*" Then
            'Go to next control.
        ElseIf TheForm.Controls(i).Name Like "cmd*" Then
            Select Case (TheForm.Controls(i).Caption)
             Case "&Update", "&Delete", "&Insert"
                 TheForm.Controls(i).Enabled = False
             Case "Co&mmit"
                 TheForm.Controls(i).Enabled = True
             Case "&Cancel"
                 TheForm.Controls(i).Enabled = True
             Case "Display &Rows"
                 TheForm.Controls(i).Enabled = False
             Case "&Room Types"
                 TheForm.Controls(i).Enabled = False
             Case "Print &Labels"
                 TheForm.Controls(i).Enabled = False
             Case "E&xit"
                 TheForm.Controls(i).Enabled = False
             Case "Common &Text"
                 TheForm.Controls(i).Enabled = True
             Case "R&efresh"
                 TheForm.Controls(i).Enabled = False
             Case "&Go to..."
                 TheForm.Controls(i).Enabled = False
             Case "&Find"
                 TheForm.Controls(i).Enabled = False
             Case Else
                 TheForm.Controls(i).Enabled = True
             End Select
            'Disable the Tabstop
            TheForm.Controls(i).TabStop = False
        ElseIf TheForm.Controls(i).Name Like "out*" Then    'Outline control.
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "datdwData*" Then
             TheForm.Controls(i).Caption = "Disabled"
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "datdwCombo*" Then
             TheForm.Controls(i).ForeColor = BLUE
             'The next line will give error for for DB fields with AllowZeroLengthString = False
             'The AddNew will blank out the fields anyway.
             'TheForm.Controls(i).Text = ""
             TheForm.Controls(i).AllowInput = True
        ElseIf TheForm.Controls(i).Name Like "opt*" Then
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "chk*" Then
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "txt*" Then
             'Also disallow insert of Account Number in all forms.
             If TheForm.Controls(i).Name = "txtAccountNum" Then
                TheForm.Controls(i).ForeColor = BLACK
                TheForm.Controls(i).Locked = True
             Else
               'Turn the text color Blue to indicate editable text.
                TheForm.Controls(i).ForeColor = BLUE
                TheForm.Controls(i).Locked = False
                'TheForm.Controls(i).Text = ""
             End If
        End If
    Next i

    'Enable the mdiForm's menu Exit option
    mdiBNB.mnuExit.Enabled = False
    'Disable the Close option on the form's system menu.
    DisableSystemMenuClose TheForm
    Screen.MousePointer = DEFAULT
   
End Sub

Sub SetFormToNoRowsMode(TheForm As Form)

    On Error Resume Next

    Dim Result&
    Screen.MousePointer = HOURGLASS
    'Change the form's caption to indicate the current mode of the form.
    TheForm.Caption = TrimModeFromCaption(TheForm) & "  [ No Rows ]"
    'Do the following for all controls on the form.
    For i = 0 To TheForm.Controls.Count - 1
        If TheForm.Controls(i).Name Like "lbl*" Then
            'Go to next control.
        ElseIf TheForm.Controls(i).Name Like "cmd*" Then
            Select Case (TheForm.Controls(i).Caption)
             Case "&Insert"
                 TheForm.Controls(i).Enabled = True
             Case "&Update"
                 TheForm.Controls(i).Enabled = False
             Case "&Delete"
                 TheForm.Controls(i).Enabled = False
             Case "Co&mmit"
                 TheForm.Controls(i).Enabled = False
             Case "&Run Query"
                 TheForm.Controls(i).Enabled = True
                 TheForm.Controls(i).Caption = "&Find"
             Case "E&xit"
                 TheForm.Controls(i).Enabled = True
             Case "Common &Text"
                 TheForm.Controls(i).Enabled = False
             Case "R&efresh"
                 TheForm.Controls(i).Enabled = True
             Case "&Go to..."
                 TheForm.Controls(i).Enabled = False
             Case "&Find"
                 TheForm.Controls(i).Enabled = True
             Case "&Cancel"
                 TheForm.Controls(i).Enabled = False
             Case "Display &Rows"
                 TheForm.Controls(i).Enabled = False
             Case "&Room Types"
                 TheForm.Controls(i).Enabled = False
             Case "Print &Labels"
                 TheForm.Controls(i).Enabled = False
             Case Else
                 TheForm.Controls(i).Enabled = False
             End Select
            'Enable the Tabstop
            TheForm.Controls(i).TabStop = True
        ElseIf TheForm.Controls(i).Name Like "datdwData*" Then
             TheForm.Controls(i).Enabled = False
             TheForm.Controls(i).Caption = "Disabled"
        ElseIf TheForm.Controls(i).Name Like "datdwCombo*" Then
            'Turn the text color Black to indicate non-editable text.
             TheForm.Controls(i).Text = ""
             TheForm.Controls(i).ForeColor = BLACK
             TheForm.Controls(i).AllowInput = False
        ElseIf TheForm.Controls(i).Name Like "out*" Then    'Outline control.
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "opt*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "chk*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "txt*" Then
            'Turn the text color Black to indicate non-editable text.
             TheForm.Controls(i).Text = ""
             TheForm.Controls(i).ForeColor = BLACK
             TheForm.Controls(i).Locked = True
        End If
    Next i

    'Enable the mdiForm's menu Exit option
    mdiBNB.mnuExit.Enabled = True
    'Re-enable the Close option on the form's system menu.
    RestoreSystemMenu TheForm
    Screen.MousePointer = DEFAULT

End Sub


Sub SetFormToUpdateMode(TheForm As Form)

    On Error Resume Next

    Dim Result&
    Screen.MousePointer = HOURGLASS
    'Change the form's caption to indicate the current mode of the form.
    TheForm.Caption = TrimModeFromCaption(TheForm) & "  [ Update ]"
    'Do the following for all controls on the form.
    For i = 0 To TheForm.Controls.Count - 1
        If TheForm.Controls(i).Name Like "lbl*" Then
            'Go to next control.
        ElseIf TheForm.Controls(i).Name Like "cmd*" Then
            Select Case (TheForm.Controls(i).Caption)
             Case "&Update", "&Delete", "&Insert"
                 TheForm.Controls(i).Enabled = False
             Case "Co&mmit"
                 TheForm.Controls(i).Enabled = True
             Case "&Cancel"
                 TheForm.Controls(i).Enabled = True
             Case "Display &Rows"
                 TheForm.Controls(i).Enabled = False
             Case "&Room Types"
                 TheForm.Controls(i).Enabled = False
             Case "Print &Labels"
                 TheForm.Controls(i).Enabled = False
             Case "E&xit"
                 TheForm.Controls(i).Enabled = False
             Case "Common &Text"
                 TheForm.Controls(i).Enabled = True
             Case "R&efresh"
                 TheForm.Controls(i).Enabled = False
             Case "&Go to..."
                 TheForm.Controls(i).Enabled = False
             Case "&Find"
                 TheForm.Controls(i).Enabled = False
             Case Else
                 TheForm.Controls(i).Enabled = True
             End Select
            'Disable the Tabstop
            TheForm.Controls(i).TabStop = False
        ElseIf TheForm.Controls(i).Name Like "out*" Then    'Outline control.
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "datdwData*" Then
             TheForm.Controls(i).Caption = "Disabled"
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "datdwCombo*" Then
            'Turn the text color Blue to indicate editable text.
             TheForm.Controls(i).ForeColor = BLUE
             TheForm.Controls(i).AllowInput = True
        ElseIf TheForm.Controls(i).Name Like "opt*" Then
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "chk*" Then
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "txt*" Then
            'Turn the text color Blue to indicate editable text.
             TheForm.Controls(i).ForeColor = BLUE
             TheForm.Controls(i).Locked = False
             'Also disallow update of Account number in all forms.
             If TheForm.Controls(i).Name = "txtAccountNum" Then
                TheForm.Controls(i).ForeColor = BLACK
                TheForm.Controls(i).Locked = True
             End If
             'Also disallow update of Confirmation number in all forms.
             If TheForm.Controls(i).Name = "txtConfNum" Then
                TheForm.Controls(i).ForeColor = BLACK
                TheForm.Controls(i).Locked = True
             End If
             'Special case for Guest form. Allow update of first and last names, which
             'will cascade through all tables.
             If TheForm.Name = "frmGeneralGuest" Then
                'Do nothing
             Else
                If TheForm.Controls(i).Name = "txtFirstName" Or TheForm.Controls(i).Name = "txtLastName" Then
                   TheForm.Controls(i).ForeColor = BLACK
                   TheForm.Controls(i).Locked = True
                End If
             End If
        End If
    Next
    
    'Disable the mdiForm's menu Exit option to prevent the user from closing the application.
    mdiBNB.mnuExit.Enabled = False
    'Disable the form's system menu Close option.
    DisableSystemMenuClose TheForm
    Screen.MousePointer = DEFAULT

End Sub

Function TrimModeFromCaption(TheForm As Form) As String
    'This function will return the caption of the specified
    'form, "TheForm", with the mode removed.  Convention
    'requires that the form's mode be positioned to the
    'right of the default caption, and that the mode be
    'encapsulated in "[]".  For example: "Guest Data [ Browse ]'
    '
    'If an error occurs, the function returns the string
    '"ERROR in TrimModeFromCaption!"

    On Error GoTo TrimModeFromCaption_Error:

    Dim Temp As String
    Dim Where As Long

    Temp = Format$(TheForm.Caption)
    Where = InStr(1, Temp, "[")
    If Where > 0 Then
        If InStr(Where, Temp, "]") > 0 Then Temp = RTrim$(Mid$(Temp, 1, Where - 1))
    End If
    TrimModeFromCaption = Temp
Exit Function

TrimModeFromCaption_Error:
    Resume TrimModeFromCaption_Resume
TrimModeFromCaption_Resume:
    TrimModeFromCaption = "ERROR in TrimModeFromCaption!"
End Function






Public Function BuildFindCriteria(TheForm As Form, OrderBy As String) As String
   
   Dim TempStr As String
   Dim LenTempStr
   Dim Counter As Integer
   Counter = 0
   TempStr = "select * from " & TheForm.Tag & " where "
   LenTempStr = Len(TempStr)
   For i = 0 To TheForm.Controls.Count - 1
      If TheForm.Controls(i).Name Like "txt*" Or TheForm.Controls(i).Name Like "datdwCombo*" Then
        If Trim$(TheForm.Controls(i).Text) <> "" Then
           If Counter > 0 Then
             TempStr = TempStr & " and "
           End If
           Counter = Counter + 1
           If TheForm.Controls(i).Tag = "Number" Or TheForm.Controls(i).Tag = "Currency" Then
              If Not IsNumeric(TheForm.Controls(i).Text) Then
                gMsg = "'" & TheForm.Controls(i).Text & "' was entered into a number field. Only numbers can be entered into these fields."
                GoTo BuildFindCriteria_Invalid_Characters
              Else
                TempStr = TempStr & TheForm.Controls(i).DataField & " = " & TheForm.Controls(i).Text
              End If
           Else
          '   If TheForm.Controls(i).Text Like "*[']*" Then 'Single quote symbol needs to be removed.
          '      TheForm.Controls(i).Text = Replace_All_In_With("'", TheForm.Controls(i).Text, "*")
          '      'gMsg = "Single quote (') not allowed in Find criteria."
          '      'GoTo BuildFindCriteria_Invalid_Characters
          '   End If
             If TheForm.Controls(i).Tag = "Date" Then
                If TheForm.Controls(i).Text Like "*[*]*" Then
                   'Ensure valid date format for wildcard date.
                   If Not GetWildcardDate(TheForm.Controls(i).Text) Then
                      'gMsg has just been set in GetWildcardDate().
                      GoTo BuildFindCriteria_Invalid_Characters
                   End If
                   Select Case gWCardDateCase
                     Case 0
                        'gMsg = "Need to supply at least one date part (month, day, or year) for wildcard find (eg, 1/*/98)"
                        'GoTo BuildFindCriteria_Invalid_Characters
                     Case 1
                        TempStr = TempStr & " DatePart('yyyy'," & TheForm.Controls(i).DataField & ") = " & CInt(gYear)
                     Case 2
                        TempStr = TempStr & " DatePart('d'," & TheForm.Controls(i).DataField & ") = " & CInt(gDay)
                     Case 3
                        TempStr = TempStr & " DatePart('d'," & TheForm.Controls(i).DataField & ") = " & CInt(gDay)
                        TempStr = TempStr & " And DatePart('yyyy'," & TheForm.Controls(i).DataField & ") = " & CInt(gYear)
                     Case 4
                        TempStr = TempStr & " DatePart('m'," & TheForm.Controls(i).DataField & ") = " & CInt(gMonth)
                     Case 5
                        TempStr = TempStr & " DatePart('m'," & TheForm.Controls(i).DataField & ") = " & CInt(gMonth)
                        TempStr = TempStr & " And DatePart('yyyy'," & TheForm.Controls(i).DataField & ") = " & CInt(gYear)
                     Case 6
                        TempStr = TempStr & " DatePart('m'," & TheForm.Controls(i).DataField & ") = " & CInt(gMonth)
                        TempStr = TempStr & " And DatePart('d'," & TheForm.Controls(i).DataField & ") = " & CInt(gDay)
                     Case 7
                        'Not a wildcard date.
                     Case Else
                        '
                   End Select
                'Ensure valid date format if not using wildcards
                ElseIf Not DateFormatOk(TheForm.Controls(i)) Then
                   gMsg = "Invalid date. Use mm/dd/yy format."
                   GoTo BuildFindCriteria_Invalid_Characters
                Else
                   'MS Access requires pound signs (#) around date values (literals) in select queries.
                   TempStr = TempStr & TheForm.Controls(i).DataField & " = #" & Trim$(TheForm.Controls(i).Text) & "#"
                End If
             Else
                If TheForm.Controls(i).Text Like "*[*]*" Then
                   'TempStr = TempStr & TheForm.Controls(i).DataField & " Like '" & TheForm.Controls(i).Text & "'"
                   TempStr = TempStr & TheForm.Controls(i).DataField & " Like " & Chr$(34) & TheForm.Controls(i).Text & Chr$(34)
                Else
                   'TempStr = TempStr & TheForm.Controls(i).DataField & " = '" & TheForm.Controls(i).Text & "'"
                   TempStr = TempStr & TheForm.Controls(i).DataField & " = " & Chr$(34) & TheForm.Controls(i).Text & Chr$(34)
                End If
             End If
           End If
        End If
      ElseIf TheForm.Controls(i).Name Like "chk*" Then
        If TheForm.Controls(i).Value = CHECKED Then
           If Counter > 0 Then
             TempStr = TempStr & " and "
           End If
           Counter = Counter + 1
           TempStr = TempStr & TheForm.Controls(i).DataField & "=-1 "
        End If
      End If
   Next i
   If LenTempStr < Len(TempStr) Then
      If OrderBy <> "" Then
         BuildFindCriteria = TempStr & " order by " & OrderBy
      Else
         BuildFindCriteria = TempStr
      End If
   Else
      BuildFindCriteria = ""
   End If
   
Exit Function

BuildFindCriteria_Invalid_Characters:
  MsgBox gMsg, MB_ICONSTOP, TheForm.Caption
  Screen.MousePointer = DEFAULT
  BuildFindCriteria = ""
  
End Function

Public Sub DisableSystemMenuClose(TheForm As Form)
    Dim hMenu&, wFlags&, Result&
    hMenu& = GetSystemMenu&(TheForm.hwnd, 0)
    wFlags& = MF_BYCOMMAND Or MF_GRAYED
    Result& = ModifyMenu&(hMenu&, SC_CLOSE, wFlags&, 0, "&Close")
End Sub

Public Sub RestoreSystemMenu(TheForm As Form)
    Dim hMenu&
    hMenu& = GetSystemMenu&(TheForm.hwnd, 1)
End Sub

Public Sub SetPaymentToReceiveInsertMode(TheForm As Form)

    Screen.MousePointer = HOURGLASS
    'Do the following for all controls on the form.
    For i = 0 To TheForm.Controls.Count - 1
        If TheForm.Controls(i).Name Like "lbl*" Then
            'Go to next control.
        ElseIf TheForm.Controls(i).Name Like "cmd*" Then
             'do nothing
        ElseIf TheForm.Controls(i).Name Like "out*" Then    'Outline control.
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "datdwData*" Then
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "opt*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "chk*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "datdwCombo*" Then
            'Turn the text color Black to indicate non-editable text.
            If TheForm.Controls(i).Name <> "datdwComboPaymentAppliedTo" Then
               TheForm.Controls(i).ForeColor = BLACK
               TheForm.Controls(i).AllowInput = False
            End If
        ElseIf TheForm.Controls(i).Name Like "txt*" Then
            If TheForm.Controls(i).Name <> "txtPaymentAmtRcvd" _
              And TheForm.Controls(i).Name <> "txtPaymentRcvdDate" _
              And TheForm.Controls(i).Name <> "txtPaymentCheckNum" _
              And TheForm.Controls(i).Name <> "txtRecFrom" _
              And TheForm.Controls(i).Name <> "txtReceivedComments" Then
                'Turn the text color Black to indicate non-editable text.
                TheForm.Controls(i).ForeColor = BLACK
                TheForm.Controls(i).Locked = True
            End If
        End If
    Next i

    'Enable the mdiForm's menu Exit option
    mdiBNB.mnuExit.Enabled = True
    'Re-enable the Close option on the form's system menu.
    RestoreSystemMenu TheForm
    Screen.MousePointer = DEFAULT
    
End Sub

Public Sub SetTravelToCommPaidInsertMode(TheForm As Form)

    Screen.MousePointer = HOURGLASS
    'Do the following for all controls on the form.
    For i = 0 To TheForm.Controls.Count - 1
        If TheForm.Controls(i).Name Like "lbl*" Then
            'Go to next control.
        ElseIf TheForm.Controls(i).Name Like "cmd*" Then
             'do nothing
        ElseIf TheForm.Controls(i).Name Like "out*" Then    'Outline control.
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "datdwData*" Then
             TheForm.Controls(i).Enabled = True
        ElseIf TheForm.Controls(i).Name Like "opt*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "chk*" Then
             TheForm.Controls(i).Enabled = False
        ElseIf TheForm.Controls(i).Name Like "datdwCombo*" Then
            'Turn the text color Black to indicate non-editable text.
            If TheForm.Controls(i).Name <> "datdwComboPaymentAppliedTo" Then
               TheForm.Controls(i).ForeColor = BLACK
               TheForm.Controls(i).AllowInput = False
            End If
        ElseIf TheForm.Controls(i).Name Like "txt*" Then
            If TheForm.Controls(i).Name <> "txtAmountPaid" _
              And TheForm.Controls(i).Name <> "txtDatePaid" _
              And TheForm.Controls(i).Name <> "txtCheckNum" Then
                'Turn the text color Black to indicate non-editable text.
                TheForm.Controls(i).ForeColor = BLACK
                TheForm.Controls(i).Locked = True
            End If
        End If
    Next i

    'Enable the mdiForm's menu Exit option
    mdiBNB.mnuExit.Enabled = True
    'Re-enable the Close option on the form's system menu.
    RestoreSystemMenu TheForm
    Screen.MousePointer = DEFAULT
End Sub
