Public Class Tool

    Public ed As Editor
    Public SidePanel As SideContentType
    Public WithEvents TilePicker As TilesetBrowser
    Public WithEvents ItemPicker As ItemBrowser

    Public Sub New(ByVal ed As Editor)
        Me.ed = ed
    End Sub
    Public Overridable Sub Paint(ByVal g As Graphics)

    End Sub
    Public Overridable Sub MouseDown(ByVal e As MouseEventArgs)

    End Sub
    Public Overridable Sub MouseUp(ByVal e As MouseEventArgs)

    End Sub
    Public Overridable Sub MouseMove(ByVal e As MouseEventArgs)

    End Sub
    Public Overridable Sub KeyDown(ByVal e As KeyEventArgs)

    End Sub
    Public Overridable Sub TileChanged()

    End Sub
    Public Overridable Sub ItemChanged()

    End Sub
    Public Overridable Sub Refresh()

    End Sub

    Private Sub TilePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TilePicker.ValueChanged
        TileChanged()
    End Sub
    Private Sub ItemPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemPicker.ValueChanged
        ItemChanged()
    End Sub

    Public Sub Repaint()
        ed.EdControl.Repaint()
    End Sub
End Class

Public Enum SideContentType
    Tiles
    Items
End Enum