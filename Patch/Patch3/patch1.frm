VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Patch 3"
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
  'Open database`
  Set gBNB = Workspaces(0).OpenDatabase("C:\program files\bnb\bnb1.mdb", False, False, "")
  '***************************************
  'Patch commands

gBNB.Execute "CREATE INDEX bbtbl_Ind1 ON bbtbl(UnitName);"
gBNB.Execute "CREATE INDEX RoomType_Link_Ind2 ON HostAccount_RoomType_Link(RoomType);"
'  gBNB.Execute "ALTER TABLE cartbl DROP COLUMN phone;"
'  gBNB.Execute "CREATE TABLE SumPayRecSupport" & _
               "(Conf LONG,L_Name TEXT,MinArrivalDate DATE," & _
               "MaxDepartureDate DATE,TotalDue CURRENCY, " & _
               "TotalReceived CURRENCY,ComputerName TEXT);" '

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


