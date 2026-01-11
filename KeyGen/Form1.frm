VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   2496
   ClientLeft      =   48
   ClientTop       =   336
   ClientWidth     =   3744
   LinkTopic       =   "Form1"
   ScaleHeight     =   2496
   ScaleWidth      =   3744
   StartUpPosition =   3  'Windows Default
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()

  Dim MyValue
  Dim StrResult As String
  ' Generate  six random values between 1 and 6.
  Randomize
  MyValue = Int((6 * Rnd) + 1)
  StrResult = StrResult & Str(MyValue)
  MyValue = Int((6 * Rnd) + 1)
  StrResult = StrResult & Str(MyValue)
  MyValue = Int((6 * Rnd) + 1)
  StrResult = StrResult & Str(MyValue)
  MyValue = Int((6 * Rnd) + 1)
  StrResult = StrResult & Str(MyValue)
  MyValue = Int((6 * Rnd) + 1)
  StrResult = StrResult & Str(MyValue)
  MyValue = Int((6 * Rnd) + 1)
  StrResult = StrResult & Str(MyValue)
  
  MsgBox StrResult
  End

End Sub


