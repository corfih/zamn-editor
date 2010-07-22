Public Class Victim
    Public x As Integer
    Public y As Integer
    Public num As Integer
    Public vicnum As Integer
    Public unknown As Integer

    Public Sub New()

    End Sub

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal unknown As Integer, ByVal num As Integer, ByVal ptr As Integer)
        Me.x = x
        Me.y = y
        Me.unknown = unknown
        Me.num = num
        If num = 16 Then
            Me.num = 10
        End If
        Me.vicnum = 1 + Array.IndexOf(LevelGFX.ptrs, ptr)
    End Sub

    Public Sub New(ByVal v As Victim)
        Me.x = v.x
        Me.y = v.y
        Me.unknown = v.unknown
        Me.num = v.num
        Me.vicnum = v.vicnum
    End Sub

    Public Function GetRect() As Rectangle
        Return New Rectangle(New Point(Me.x, Me.y), LevelGFX.VictimImages(vicnum).Size)
    End Function
End Class
