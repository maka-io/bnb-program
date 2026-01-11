VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Patch 4"
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
  'Patch commands
   gBNB.Execute "UPDATE DBVersion SET DBVersion='2.0';"
   
   gBNB.Execute "CREATE TABLE HostAccount_RoomType_Link" & _
               "(AccountNum LONG,RoomType Integer, RoomType_Desc TEXT);"
   
   gBNB.Execute "CREATE TABLE RoomTypeInsertControl" & _
                "(accountnum LONG,roomtype INTEGER,computername TEXT(50));"
   gBNB.Execute "CREATE TABLE TempTab1" & _
                "(UnitName TEXT,ID LONG,nnotes TEXT);"
   gBNB.Execute "insert into TempTab1 (UnitName,ID,nnotes) select UnitName,ID,nnotes from bbtbl where accountnum = 7"

   gBNB.Execute "Alter Table bbtbl Drop Column UnitName;"
Screen.MousePointer = HOURGLASS
   '***Add UnitName field to bbtbl
   Dim tdf1 As TableDef
   Dim fldTemp As Field
   Set tdf1 = gBNB.TableDefs("bbtbl")
   ' Create a new Field object and append it to the Fields
   ' collection of the bbtbl table.
   Set fldTemp = tdf1.CreateField("UnitName", dbText, 50)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("UnitNameDesc", dbText, 50)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
   
   '***Create Master Property Facts table
   gBNB.Execute "CREATE TABLE MasterPropertyFacts" & _
                "(TempFld1 TEXT);"

   '***Create Property Facts table (holds indivdual property facts)
   gBNB.Execute "CREATE TABLE PropertyFacts" & _
                "(TempFld1 TEXT);"

   '***Create Audit Table for bbtbl
   gBNB.Execute "CREATE TABLE AccomAudit" & _
                "(TempFld1 TEXT);"
   '***Close and reopen database to refresh
   gBNB.Close
   Set gBNB = Workspaces(0).OpenDatabase("C:\program files\bnb\bnb1.mdb", False, False, "")
 Screen.MousePointer = HOURGLASS
   '***Add field to MasterPropertyFacts table
   Set tdf1 = gBNB.TableDefs("MasterPropertyFacts")
   Set fldTemp = tdf1.CreateField("TopicName", dbText, 50)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
   'Remove temp field needed in creation of table
   gBNB.Execute "Alter Table MasterPropertyFacts Drop Column TempFld1;"
   
   '***Add fields to PropertyFacts table
   Set tdf1 = gBNB.TableDefs("PropertyFacts")
   Set fldTemp = tdf1.CreateField("TopicName", dbText, 50)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
  ' Set fldTemp = tdf1.CreateField("Applicable", dbInteger)
  ' tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("TopicDescription", dbText)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("Property", dbText, 50)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("AccountNum", dbLong)
   tdf1.Fields.Append fldTemp
   'Remove temp field needed in creation of table
   gBNB.Execute "Alter Table PropertyFacts Drop Column TempFld1;"
Screen.MousePointer = HOURGLASS
   '***Add all fields to Audit Table
   Set tdf1 = gBNB.TableDefs("AccomAudit")
   ' Create new Field objects and append them to the Fields
   ' collection of the AccomAudit table.
   Set fldTemp = tdf1.CreateField("Conf", dbLong)
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("Action", dbText, 50)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("ActionDate", dbDate)
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("Location", dbText, 255)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("UnitName", dbText, 50)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("NumPty", dbInteger)
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("ArrDate", dbDate)
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("DepDate", dbDate)
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("PymtType", dbText, 255)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("GrosRate", dbCurrency)
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("Suppress", dbInteger)
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("ComputerName", dbText, 75)
   fldTemp.AllowZeroLength = True
   tdf1.Fields.Append fldTemp
   Set fldTemp = tdf1.CreateField("Accom_RowID", dbLong)
   tdf1.Fields.Append fldTemp
   'Remove temp field needed in creation of table
   gBNB.Execute "Alter Table AccomAudit Drop Column TempFld1;"
   gBNB.Execute "CREATE INDEX AccomAudit_Ind1 ON AccomAudit(Conf);"
Screen.MousePointer = HOURGLASS
   Set SSTemp = gBNB.OpenRecordset("select UnitName,ID,nnotes from TempTab1", dbOpenSnapshot)
   SSTemp.MoveLast
   SSTemp.MoveFirst
   For i = 0 To SSTemp.RecordCount - 1
Screen.MousePointer = HOURGLASS
      If (SSTemp("UnitName") Like "*1*" And Not SSTemp("UnitName") Like "*2*") Or SSTemp("UnitName") Like "*Kohala* " _
         Or (SSTemp("nnotes") Like "*[#]1*" And Not SSTemp("nnotes") Like "*[#]2*") Or SSTemp("nnotes") Like "*Kohala*" Then
         gBNB.Execute "update bbtbl set UnitName='1' where ID=" & SSTemp("ID") & ";"
      ElseIf (SSTemp("UnitName") Like "*2*" And Not SSTemp("UnitName") Like "*1*") Or SSTemp("UnitName") Like "*Waimea* " _
             Or (SSTemp("nnotes") Like "*[#]2*" And Not SSTemp("nnotes") Like "*[#]1*") Or SSTemp("nnotes") Like "*Waimea*" Then
         gBNB.Execute "update bbtbl set UnitName='2' where ID=" & SSTemp("ID") & ";"
      Else
         gBNB.Execute "update bbtbl set UnitName='' where ID=" & SSTemp("ID") & ";"
      End If
      SSTemp.MoveNext
   Next i
   SSTemp.Close
   'Populate the UnitNameDesc field. UnitNameDesc='Kohala Wing'
   gBNB.Execute "update bbtbl set UnitNameDesc='Kohala Wing' WHERE UnitName='1' AND AccountNum=7;"
   gBNB.Execute "update bbtbl set UnitNameDesc='Waimea Wing' WHERE UnitName='2' AND AccountNum=7;"
   
   gBNB.Execute "DROP TABLE TempTab1"
   gBNB.Execute "insert into HostAccount_RoomType_Link(AccountNum,RoomType,RoomType_Desc) Values (7,1,'Kohala Wing');"
   gBNB.Execute "insert into HostAccount_RoomType_Link(AccountNum,RoomType,RoomType_Desc) Values (7,2,'Waimea Wing');"
   
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


