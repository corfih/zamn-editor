Public Class ItemTool
    Inherits Tool

    Public selectedItems As List(Of Item)
    Public selectedItem As Item
    Public allSelectedItems As New Dictionary(Of LvlEdCtrl, List(Of Item))
    Public XStart As Integer
    Public YStart As Integer
    Public width As Integer
    Public height As Integer

    Private createItem As Boolean = False
    Private curSelItems As New List(Of Item)
    Private selecting As Boolean = False
    Private curX As Integer
    Private curY As Integer
    Private dragXOff As Integer
    Private dragYOff As Integer
    Private borderPen As New Pen(Color.Black)
    Private darkBrush As New SolidBrush(Color.FromArgb(92, 0, 0, 0))

    Public Sub New(ByVal ed As Editor)
        MyBase.New(ed)
        Me.SidePanel = SideContentType.Items
        borderPen.DashPattern = New Single() {4, 4}
    End Sub

    Public Overrides Sub Refresh()
        If Not allSelectedItems.ContainsKey(ed.EdControl) Then
            allSelectedItems.Add(ed.EdControl, New List(Of Item))
        End If
        selectedItems = allSelectedItems(ed.EdControl)
    End Sub

    Public Overrides Sub MouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim additem As Boolean = False
        Dim dontClear As Boolean = False
        For l As Integer = ed.EdControl.lvl.items.Count - 1 To 0 Step -1
            Dim i As Item = ed.EdControl.lvl.items(l)
            If i.GetRect.Contains(e.Location) Then
                If Not selectedItems.Contains(i) Then
                    selectedItems.Add(i)
                End If
                selectedItem = i
                dragXOff = e.X - i.x
                dragYOff = e.Y - i.y
                additem = True
                Exit For
            End If
        Next
        curSelItems.Clear()
        If additem Then
            selecting = False
        Else
            If Control.ModifierKeys <> Keys.Shift Then
                selectedItems.Clear()
            End If
            selecting = True
            XStart = e.X
            YStart = e.Y
            curX = e.X
            curY = e.Y
            width = 0
            height = 0
        End If
        Repaint()
    End Sub

    Public Overrides Sub MouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If selecting Then
                width = Math.Abs(e.X - XStart)
                height = Math.Abs(e.Y - YStart)
                If e.X < XStart Then
                    curX = XStart - width
                Else
                    curX = XStart
                End If
                If e.Y < YStart Then
                    curY = YStart - height
                Else
                    curY = YStart
                End If
                Dim selRect As New Rectangle(curX, curY, width, height)
                curSelItems.Clear()
                For Each i As Item In ed.EdControl.lvl.items
                    If selRect.IntersectsWith(i.GetRect) Then
                        curSelItems.Add(i)
                    End If
                Next
            Else
                Dim minX As Integer = Integer.MaxValue
                Dim minY As Integer = Integer.MaxValue
                Dim stp As Integer = 1
                If Control.ModifierKeys = Keys.Shift Then
                    stp = 8
                End If
                For Each i As Item In selectedItems
                    If i.x < minX Then minX = i.x
                    If i.y < minY Then minY = i.y
                Next
                Dim XDelta As Integer = Math.Max(-minX, e.X - (selectedItem.x + dragXOff))
                Dim YDelta As Integer = Math.Max(-minY, e.Y - (selectedItem.y + dragYOff))
                For Each i As Item In selectedItems
                    i.x = ((i.x + XDelta) \ stp) * stp
                    i.y = ((i.y + YDelta) \ stp) * stp
                Next
            End If
            Repaint()
        End If
    End Sub

    Public Overrides Sub MouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        For Each i As Item In curSelItems
            If Not selectedItems.Contains(i) Then
                selectedItems.Add(i)
            End If
        Next
        curSelItems.Clear()
        selecting = False
        Repaint()
    End Sub

    Public Overrides Sub Paint(ByVal g As System.Drawing.Graphics)
        If selecting Then
            g.DrawRectangle(Pens.White, curX, curY, width, height)
            g.DrawRectangle(borderPen, curX, curY, width, height)
        End If
        For Each i As Item In selectedItems
            g.FillRectangle(darkBrush, i.GetRect)
            g.DrawRectangle(Pens.White, i.GetRect)
        Next
        For Each i As Item In curSelItems
            g.FillRectangle(darkBrush, i.GetRect)
            g.DrawRectangle(Pens.White, i.GetRect)
        Next
    End Sub
End Class
