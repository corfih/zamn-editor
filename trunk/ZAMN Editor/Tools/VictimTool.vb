Public Class VictimTool
    Inherits Tool

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        Me.SidePanel = SideContentType.Victims
    End Sub
End Class
