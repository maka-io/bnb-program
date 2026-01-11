VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Patch - Ver 1 to 2"
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
Private Sub Form_Load()

  On Error GoTo patch_error
  Screen.MousePointer = HOURGLASS
  'Open database
  Set gBNB = Workspaces(0).OpenDatabase("C:\program files\bnb\bnb1.mdb", False, False, "")
  'Run patch
  gBNB.Execute "ALTER TABLE CheckTemp ADD COLUMN NetRate CURRENCY;"
  gBNB.Execute "ALTER TABLE CheckTemp ADD COLUMN TotNet CURRENCY;"
  gBNB.Execute "ALTER TABLE CheckTemp ADD COLUMN Tax1 CURRENCY;"
  gBNB.Execute "ALTER TABLE CheckTemp ADD COLUMN Tax2 CURRENCY;"
  gBNB.Execute "ALTER TABLE CheckTemp ADD COLUMN Tax3 CURRENCY;"
  gBNB.Execute "CREATE TABLE DBVersion(DBVersion TEXT);"
  gBNB.Execute "INSERT INTO DBVersion(DBVersion) values ('02.00.00');"
  MsgBox "Patch Complete"
  End
  
patch_resume:
   Screen.MousePointer = Default
   Exit Sub
 
patch_error:
    MsgBox Str(Err) & ", " & Err.Description
    End
  
End Sub


