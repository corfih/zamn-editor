Public Class LvlEdCtrl
    Public lvl As Level
    Public t As Tool
    Public TilePicker As New TilesetBrowser
    Public Grid As Boolean
    Public selection As Selection

    Private fillBrush As SolidBrush
    Private eraserBrush As SolidBrush
    Private borderPen As Pen
    Private selectionGP As Drawing2D.GraphicsPath
    Private eraserRect As Rectangle
    Private WithEvents borderTimer As Timer

    Public Sub New()
        InitializeComponent()
        fillBrush = New SolidBrush(Color.FromArgb(96, 0, 0, 0))
        eraserBrush = New SolidBrush(Color.FromArgb(128, 255, 255, 255))
        borderPen = New Pen(Color.Black)
        borderPen.DashOffset = 0
        borderPen.DashPattern = New Single() {4, 4}
        borderTimer = New Timer()
        borderTimer.Interval = 100
        borderTimer.Enabled = True
    End Sub

    Public Sub LoadLevel(ByVal lvl As Level)
        Me.lvl = lvl
        selection = New Selection(lvl.Width, lvl.Height)
        TilePicker.LoadTileset(lvl.tileset)
        UpdateScrollBars()
    End Sub

    Public Sub SetSidePanel(ByVal ctrl As Control)
        SideContent.Controls.Clear()
        SideContent.Controls.Add(ctrl)
        ctrl.Dock = DockStyle.Fill
    End Sub

    Public Sub Repaint()
        Me.Invalidate(True)
    End Sub

    Public Sub UpdateSelection()
        selectionGP = selection.ToGP
        eraserRect = selection.GetEraserRect
        Repaint()
    End Sub

    Public Sub SetCursor(ByVal c As Cursor)
        canvas.Cursor = c
    End Sub

    Public Sub FillSelection()
        For m As Integer = 0 To lvl.Height - 1
            For l As Integer = 0 To lvl.Width - 1
                If selection.selectPts(l, m) Then
                    lvl.Tiles(l, m) = TilePicker.SelectedTile
                End If
            Next
        Next
        Repaint()
    End Sub

    Private Sub UpdateScrollBars()
        If lvl Is Nothing Then Return
        HScrl.Maximum = lvl.Width * 64
        VScrl.Maximum = lvl.Height * 64
        HScrl.LargeChange = canvas.Width
        VScrl.LargeChange = canvas.Height
        HScrl.Value = Math.Min(HScrl.Value, Math.Max(0, HScrl.Maximum - HScrl.LargeChange))
        VScrl.Value = Math.Min(VScrl.Value, Math.Max(0, VScrl.Maximum - VScrl.LargeChange))
        HScrl.Enabled = (HScrl.Maximum > HScrl.LargeChange)
        VScrl.Enabled = (VScrl.Maximum > VScrl.LargeChange)
        canvas.Invalidate()
    End Sub

    Private Sub canvas_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles canvas.Paint
        If lvl Is Nothing Then Return
        e.Graphics.TranslateTransform(-HScrl.Value, -VScrl.Value)
        For l As Integer = HScrl.Value \ 64 To Math.Min(lvl.Width - 1, (HScrl.Value + canvas.Width) \ 64 + 1)
            For m As Integer = VScrl.Value \ 64 To Math.Min(lvl.Height - 1, (VScrl.Value + canvas.Height) \ 64 + 1)
                e.Graphics.DrawImage(lvl.tileset.images(lvl.Tiles(l, m)), l * 64, m * 64)
            Next
        Next
        If Grid Then
            For l As Integer = HScrl.Value \ 64 To (HScrl.Value + HScrl.LargeChange) \ 64
                e.Graphics.DrawLine(Pens.White, l * 64, VScrl.Value, l * 64, VScrl.Value + VScrl.LargeChange)
            Next
            For l As Integer = VScrl.Value \ 64 To (VScrl.Value + VScrl.LargeChange) \ 64
                e.Graphics.DrawLine(Pens.White, HScrl.Value, l * 64, HScrl.Value + HScrl.LargeChange, l * 64)
            Next
        End If
        If selectionGP IsNot Nothing And selection.exists Then
            e.Graphics.FillPath(fillBrush, selectionGP)
            e.Graphics.DrawPath(Pens.White, selectionGP)
            e.Graphics.DrawPath(borderPen, selectionGP)
        End If
        If eraserRect <> Rectangle.Empty Then
            e.Graphics.FillRectangle(eraserBrush, eraserRect)
            e.Graphics.DrawRectangle(Pens.White, eraserRect)
            e.Graphics.DrawRectangle(borderPen, eraserRect)
        End If
        If t IsNot Nothing Then
            t.Paint(e.Graphics)
        End If
    End Sub

    Private Sub LvlEdCtrl_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged, Me.DockChanged
        If lvl Is Nothing Then Return
        UpdateScrollBars()
    End Sub

    Private Sub Scrolled(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrl.ValueChanged, VScrl.ValueChanged
        canvas.Invalidate()
    End Sub

    Private Sub LvlEdCtrl_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If VScrl.Enabled Then
            VScrl.Value = Math.Max(0, Math.Min(VScrl.Maximum - VScrl.LargeChange + 1, VScrl.Value - e.Delta \ 2))
        ElseIf HScrl.Enabled Then
            HScrl.Value = Math.Max(0, Math.Min(HScrl.Maximum - HScrl.LargeChange + 1, HScrl.Value - e.Delta \ 2))
        End If
    End Sub

    Private Sub canvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseDown
        If t Is Nothing Then Return
        t.MouseDown(CreateMouseEventArgs(e))
    End Sub

    Private Sub canvas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseUp
        If t Is Nothing Then Return
        t.MouseUp(CreateMouseEventArgs(e))
    End Sub

    Private Sub canvas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles canvas.MouseMove
        If t Is Nothing Then Return
        t.MouseMove(CreateMouseEventArgs(e))
    End Sub

    Private Function CreateMouseEventArgs(ByVal e As MouseEventArgs)
        Return New MouseEventArgs(e.Button, e.Clicks, e.X + HScrl.Value, e.Y + VScrl.Value, e.Delta)
    End Function

    Private Sub borderTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles borderTimer.Tick
        If selection.exists Then
            borderPen.DashOffset += 1
            If borderPen.DashOffset = 8 Then
                borderPen.DashOffset = 0
            End If
            canvas.Invalidate()
        End If
    End Sub
End Class
