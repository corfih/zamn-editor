Imports System.IO

Public Class ROM

    Public path As String
    Public regLvlCount As Integer
    Public maxLvlNum As Integer
    Public bonusLvls As New List(Of Integer)
    Public failed As Boolean = False

    Public Sub New(ByVal path As String)
        Try
            Me.path = path
            Dim s As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
            s.Seek(&HF8200, SeekOrigin.Begin)
            regLvlCount = s.ReadByte() + s.ReadByte() * &H100
            maxLvlNum = regLvlCount
            s.Seek(&H1537E, SeekOrigin.Begin)
            Dim num As Integer
            Dim curLvl As Integer = 0
            For l As Integer = 0 To maxLvlNum
                num = s.ReadByte() + s.ReadByte() * &H100
                If num <> 0 Then
                    bonusLvls.Add(num)
                    maxLvlNum = Math.Max(maxLvlNum, num)
                End If
                curLvl += 1
            Next
            s.Close()
        Catch ex As Exception
            failed = True
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Function GetLvlPtr(ByVal num As Integer, ByVal s As Stream) As Integer
        s.Seek(&HF8202 + num * 2, SeekOrigin.Begin)
        Return s.ReadByte() + s.ReadByte * &H100 + &HF0200
    End Function

    Public Function GotoLvlPtr(ByVal num As Integer, ByVal s As Stream) As Integer
        s.Seek(GetLvlPtr(num, s), SeekOrigin.Begin)
    End Function

    Public Function GetLevel(ByVal num As Integer, ByVal name As String) As Level
        Dim s As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
        GotoLvlPtr(num, s)
        Return New Level(s, name)
    End Function
End Class
