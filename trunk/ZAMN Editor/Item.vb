Public Class Item
    Public x As Integer
    Public y As Integer
    Public type As Integer

    Public Sub New()

    End Sub

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal type As Integer)
        Me.x = x
        Me.y = y
        Me.type = type
    End Sub

    Public Sub New(ByVal i As Item)
        Me.x = i.x
        Me.y = i.y
        Me.type = i.type
    End Sub

    Public Function GetRect() As Rectangle
        Return New Rectangle(x, y, 15, 15)
    End Function
End Class
