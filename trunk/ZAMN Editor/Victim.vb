Public Class Victim
    Public x As Integer
    Public y As Integer
    Public num As Integer
    Public ptr As Integer
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
        Me.ptr = ptr
    End Sub

    Public Sub New(ByVal v As Victim)
        Me.x = v.x
        Me.y = v.y
        Me.unknown = v.unknown
        Me.num = v.num
        Me.ptr = v.ptr
    End Sub
End Class
