Public Class RectangleSelectTool
    Inherits Tool

    Private selection As Selection
    Public pX As Integer = -1
    Public pY As Integer = -1

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        Me.SidePanel = SideContentType.Tiles
    End Sub

    Public Overrides Sub MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim nx As Integer = e.X \ 64
        Dim ny As Integer = e.Y \ 64
        If e.Button = MouseButtons.Left And nx < ed.EdControl.lvl.Width _
        And ny < ed.EdControl.lvl.Height And nx >= 0 And ny >= 0 Then
            If Control.ModifierKeys <> Keys.Shift And Control.ModifierKeys <> Keys.Alt Then
                selection.Clear()
                ed.SetCopy(False)
            End If
            selection.StartRect(nx, ny, (Control.ModifierKeys And Keys.Alt) <> Keys.None)
            ed.EdControl.UpdateSelection()
        End If
    End Sub

    Public Overrides Sub MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim nx As Integer = e.X \ 64
        Dim ny As Integer = e.Y \ 64
        If e.Button = MouseButtons.Left And nx < ed.EdControl.lvl.Width _
        And ny < ed.EdControl.lvl.Height And nx >= 0 And ny >= 0 And (pX <> nx Or pY <> ny) Then
            selection.MoveTo(nx, ny)
            pX = nx
            pY = ny
            TilePicker.SelectedIndex = -1
            TilePicker.Invalidate()
            ed.EdControl.UpdateSelection()
            If selection.erasing Then
                ed.CheckCopy()
            Else
                ed.SetCopy(True)
            End If
        End If
    End Sub

    Public Overrides Sub MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        pX = -1
        pY = -1
        selection.ApplySelection()
        ed.EdControl.UpdateSelection()
    End Sub

    Public Overrides Sub Refresh()
        selection = ed.EdControl.selection
    End Sub

    Public Overrides Sub TileChanged()
        ed.EdControl.FillSelection()
    End Sub
End Class