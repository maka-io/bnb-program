VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Patch 8"
   ClientHeight    =   3195
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim i As Long
Private Sub Form_Load()

  On Error GoTo patch_error
  Dim SSTemp As Recordset
  Screen.MousePointer = HOURGLASS
  'Open database`
  Set gBNB = Workspaces(0).OpenDatabase("C:\program files\bnb\bnb1.mdb", False, False, "")
  '***************************************
  Screen.MousePointer = HOURGLASS
  '***Add fields to bbtbl table
  Set tdf1 = gBNB.TableDefs("bbtbl")
  Set fldTemp = tdf1.CreateField("Forfeit", dbInteger)
  fldTemp.DefaultValue = 0
  tdf1.Fields.Append fldTemp
  '***Update forfeit rows
  gBNB.Execute "update bbtbl set forfeit = 0 "
  gBNB.Execute "update bbtbl set forfeit = -1 " & _
               "where nnotes like '*Forf*' " & _
               "or nnotes like '*forf*' " & _
               "or nnotes like '*FF*' " & _
               "or nnotes like '*ff*' " & _
               "or nnotes like '*Ff*' " & _
               "or nnotes like '*XCLD*1NT*' " & _
               "or nnotes like '*Xld*1NT*' " & _
               "or nnotes like '*XL*1NT*' "
  gBNB.Execute "update bbtbl set suppress = -1 " & _
               "where (nnotes like '*Forf*' " & _
               "or nnotes like '*forf*' " & _
               "or nnotes like '*FF*' " & _
               "or nnotes like '*ff*' " & _
               "or nnotes like '*Ff*' " & _
               "or nnotes like '*XCLD*1NT*' " & _
               "or nnotes like '*Xld*1NT*' " & _
               "or nnotes like '*XL*1NT*') " & _
               "And (nnotes like '*Xl*' " & _
               "or nnotes like '*Xcld*' " & _
               "or nnotes like '*Cancel*') "
  gBNB.Execute "update bbtbl set suppress = -1 " & _
               "where forfeit = -1"
  '***************************************
  MsgBox "Patch Complete"
  End
  
patch_resume:
   Screen.MousePointer = Default
   Exit Sub
 
patch_error:
    MsgBox Err.Description & " Enter to continue..."
    Resume Next
  
End Sub


