﻿Public Class Tool

    Public ed As Editor
    Public SidePanel As SideContentType
    Public WithEvents TilePicker As TilesetBrowser
    Public WithEvents ItemPicker As ItemBrowser
    Public WithEvents VictimPicker As VictimBrowser
    Public Status As String

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
    Public Overridable Sub KeyUp(ByVal e As KeyEventArgs)

    End Sub
    Public Overridable Sub TileChanged()

    End Sub
    Public Overridable Sub ItemChanged()

    End Sub
    Public Overridable Sub VictimChanged()

    End Sub
    Public Overridable Sub Refresh()

    End Sub
    Public Overridable Sub RemoveEdCtrl(ByVal e As LvlEdCtrl)

    End Sub
    Public Overridable Function SelectAll(ByVal selected As Boolean) As Boolean
        Return True
    End Function

    Private Sub TilePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TilePicker.ValueChanged
        TileChanged()
    End Sub
    Private Sub ItemPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemPicker.ValueChanged
        ItemChanged()
    End Sub
    Private Sub VictimPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VictimPicker.ValueChanged
        VictimChanged()
    End Sub

    Public Sub Repaint()
        ed.EdControl.Repaint()
    End Sub
    Public Sub UpdateStatus()
        If ed.EdControl Is Nothing Then Return
        ed.EdControl.SetStatusText(Status)
    End Sub
End Class

Public Enum SideContentType
    Tiles
    Items
    Victims
End Enum