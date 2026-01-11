VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Patch - Ver 02.00.00 to 02.01.00"
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
  'Run patch
  gBNB.Execute "ALTER TABLE bbtbl DROP COLUMN xld;"
  gBNB.Execute "ALTER TABLE proptbl DROP COLUMN dep_req;"
  gBNB.Execute "ALTER TABLE bbtbl ADD COLUMN Notified INTEGER;"
  gBNB.Execute "UPDATE bbtbl SET Notified=0;"
  gBNB.Execute "UPDATE DBVersion SET DBVersion='02.01.00';"
  gBNB.Execute "ALTER TABLE tagentbl ADD COLUMN DefCom INTEGER;"
  gBNB.Execute "ALTER TABLE payment ADD COLUMN OtherCredit CURRENCY;"
  
  gBNB.Execute "ALTER TABLE payment DROP COLUMN refdate;"
  
  gBNB.Execute "ALTER TABLE RefundReportSupport ADD COLUMN l_name TEXT;"
  gBNB.Execute "ALTER TABLE RefundReportSupport ADD COLUMN DateBkd DATETIME;"
  gBNB.Execute "ALTER TABLE RefundReportSupport ADD COLUMN RefOwed CURRENCY;"
  gBNB.Execute "ALTER TABLE RefundReportSupport ADD COLUMN RefundDate DATE;"
  gBNB.Execute "ALTER TABLE RefundReportSupport ADD COLUMN PayMethod TEXT;"
  gBNB.Execute "ALTER TABLE RefundReportSupport ADD COLUMN Void INTEGER;"
  gBNB.Execute "ALTER TABLE RefundReportSupport ADD COLUMN Comments TEXT;"
  
  gBNB.Execute "CREATE TABLE RefundByCCTbl" & _
               "(Conf LONG, F_Name TEXT, L_Name TEXT, AmtDue CURRENCY, " & _
               "AmtPaid CURRENCY, DatePaid DATE," & _
               "PaymentMethod TEXT, Comments MEMO);"
  MsgBox "Patch Complete"
  End
  
patch_resume:
   Screen.MousePointer = Default
   Exit Sub
 
patch_error:
    MsgBox Err.Description & " Enter to continue..."
    Resume Next
  
End Sub


