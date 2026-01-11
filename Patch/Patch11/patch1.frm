VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Patch 10"
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
  Set tdf1 = gBNB.TableDefs("proptbl")
  Set fldTemp = tdf1.CreateField("PropObsolete", dbInteger)
  fldTemp.DefaultValue = 0
  tdf1.Fields.Append fldTemp
  
  gBNB.Execute "update proptbl set PropObsolete=0"
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


