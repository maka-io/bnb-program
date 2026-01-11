VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Patch 9"
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

  gBNB.Execute "update cartbl set AccountNum = 6 " & _
               "where AccountNum = 1"
  gBNB.Execute "update cartbl set AgencyName = 'Dollar' " & _
               "where AccountNum = 6"
  gBNB.Execute "update cartbl set AccountNum = 6 " & _
               "where AgencyName = 'Dollar'"
  gBNB.Execute "delete from CarMaster where AccountNum = 1"
  gBNB.Execute "delete from cartbl where conf = NULL"
  gBNB.Execute "update cartbl set AccountNum = 4 " & _
               "where ucase(AgencyName)= 'BUDGET'"
  gBNB.Execute "update cartbl set AccountNum = 2 " & _
               "where ucase(AgencyName)= 'AVIS'"
  
  gBNB.Execute "update tagentbl set AccountNum = 606 " & _
               "where accountnum = 607"
  gBNB.Execute "delete from tamaster where accountnum = 607"
  
    gBNB.Execute "update tagentbl set AccountNum = 50 " & _
               "where accountnum = 369"
  gBNB.Execute "delete from tamaster where accountnum = 369"
  
    gBNB.Execute "update tagentbl set AccountNum = 64 " & _
               "where accountnum = 368"
  gBNB.Execute "delete from tamaster where accountnum = 368"
  
    gBNB.Execute "update tagentbl set AccountNum = 295 " & _
               "where accountnum = 296"
  gBNB.Execute "delete from tamaster where accountnum = 296"
  
    gBNB.Execute "update tagentbl set AccountNum = 637 " & _
               "where accountnum = 611"
  gBNB.Execute "delete from tamaster where accountnum = 611"
  
    gBNB.Execute "update tagentbl set AccountNum = 681 " & _
               "where accountnum = 669"
  gBNB.Execute "delete from tamaster where accountnum = 669"
  
    gBNB.Execute "update tagentbl set AccountNum = 557 " & _
               "where accountnum = 230"
  gBNB.Execute "delete from tamaster where accountnum = 230"
  
    gBNB.Execute "update tagentbl set AccountNum = 173 " & _
               "where accountnum = 324"
  gBNB.Execute "delete from tamaster where accountnum = 324"
  
    gBNB.Execute "update tagentbl set AccountNum = 350 " & _
               "where accountnum = 658"
  gBNB.Execute "delete from tamaster where accountnum = 658"
  
    gBNB.Execute "update tagentbl set AccountNum = 599 " & _
               "where accountnum = 227"
  gBNB.Execute "delete from tamaster where accountnum = 227"
  
    gBNB.Execute "update tagentbl set AccountNum = 331 " & _
               "where accountnum = 237"
  gBNB.Execute "delete from tamaster where accountnum = 237"

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


