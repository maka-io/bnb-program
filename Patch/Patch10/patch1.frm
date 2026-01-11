VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Patch 10"
   ClientHeight    =   3192
   ClientLeft      =   60
   ClientTop       =   348
   ClientWidth     =   4680
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   ScaleHeight     =   3192
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
  Set tdf1 = gBNB.TableDefs("TACommReportSupport")
  Set fldTemp = tdf1.CreateField("Commissionable", dbCurrency)
  fldTemp.DefaultValue = 0
  tdf1.Fields.Append fldTemp
  
  Set tdf1 = gBNB.TableDefs("CarMaster")
  Set fldTemp = tdf1.CreateField("CommPercent", dbDouble)
  tdf1.Fields.Append fldTemp
  
  Set tdf1 = gBNB.TableDefs("proptbl")
  Set fldTemp = tdf1.CreateField("GrosRatePercent", dbDouble)
  tdf1.Fields.Append fldTemp
  
  gBNB.Execute "update proptbl set GrosRatePercent=10"
  gBNB.Execute "update proptbl set GrosRatePercent=7.5 where accountnum=22"
  gBNB.Execute "update proptbl set GrosRatePercent=0 where accountnum=19"
  
  gBNB.Execute "update carmaster set CommPercent=15 where accountnum=2"
  gBNB.Execute "update carmaster set CommPercent=15 where accountnum=3"
  gBNB.Execute "update carmaster set CommPercent=10 where accountnum=4"
  gBNB.Execute "update carmaster set CommPercent=10 where accountnum=5"
  gBNB.Execute "update carmaster set CommPercent=20 where accountnum=6"
  gBNB.Execute "update carmaster set CommPercent=20 where accountnum=7"
  gBNB.Execute "update carmaster set CommPercent=20 where accountnum=8"
  gBNB.Execute "update carmaster set CommPercent=10 where accountnum=9"
  gBNB.Execute "update carmaster set CommPercent=15 where accountnum=10"
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


