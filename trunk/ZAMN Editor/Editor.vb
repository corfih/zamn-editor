Public Class Editor

    Public r As ROM
    Public EdControl As LvlEdCtrl
    Public CurTool As Tool
    Private PBrushTool As New PaintbrushTool(Me)
    Private Dropper As New DropperTool(Me)
    Private TileSuggest As New TileSuggestTool(Me)
    Private RectSelect As New RectangleSelectTool(Me)
    Private PencilSlct As New PencilSelectTool(Me)
    Private TileSlct As New TileSelectTool(Me)
    Private ItemT As New ItemTool(Me)
    Private updateTab As Boolean = True
    Private LevelItems As ToolStripItem()

    Private Sub Editor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LevelItems = New ToolStripItem() {FileSave, SaveTool, EditPaste, PasteTool, EditSelectAll, EditSelectNone, ViewGrid}
        TileSuggestList.LoadAll()
    End Sub

    Private Sub FileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileOpen.Click, OpenTool.Click
        If OpenROM.ShowDialog = DialogResult.OK Then
            r = New ROM(OpenROM.FileName)
            FileOpenLevel.Enabled = True
            LevelGFX.Load(r)
        End If
    End Sub

    Private Sub FileOpenLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileOpenLevel.Click
        If OpenLevel.ShowDialog(r) = DialogResult.OK Then
            Dim l As Level = r.GetLevel(OpenLevel.levelNum)
            EdControl = New LvlEdCtrl()
            updateTab = False
            Dim tp As TabPage = Tabs.AddXPage(OpenLevel.LevelName)
            tp.Controls.Add(EdControl)
            EdControl.Dock = DockStyle.Fill
            EdControl.LoadLevel(l)
            SetTool(CurTool)
            UpdateEdControl()
            updateTab = True
            For Each item As ToolStripItem In LevelItems
                item.Enabled = True
            Next
            Tabs.Visible = True
            TSContainer.ContentPanel.BackColor = SystemColors.Control
            EdControl.Focus()
        End If
    End Sub

    Private Sub EditSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSelectAll.Click
        SelectAll(True)
    End Sub

    Private Sub EditSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSelectNone.Click
        SelectAll(False)
    End Sub

    Private Sub SelectAll(ByVal selected As Boolean)
        For m As Integer = 0 To EdControl.lvl.Height - 1
            For l As Integer = 0 To EdControl.lvl.Width - 1
                EdControl.selection.selectPts(l, m) = selected
            Next
        Next
        EdControl.selection.exists = selected
        EdControl.selection.Refresh()
        EdControl.UpdateSelection()
        SetCopy(selected)
    End Sub

    Private Sub ViewBlockGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewGrid.Click
        UpdateEdControl()
    End Sub

    Private Sub UncheckTools()
        ToolsPaintBrush.Checked = False
        ToolsDropper.Checked = False
        ToolsTileSuggest.Checked = False
        ToolsRectangleSelect.Checked = False
        ToolsPencilSelect.Checked = False
        ToolsTileSelect.Checked = False
        ToolsItem.Checked = False
        BrushTool.Checked = False
        DropperTool.Checked = False
        TileSgstTool.Checked = False
        RectangleTool.Checked = False
        PencilTool.Checked = False
        TileSlctTool.Checked = False
        ItemTool.Checked = False
    End Sub

    Private Sub ToolsPaintBrush_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsPaintBrush.Click, BrushTool.Click
        SwitchToTool(ToolsPaintBrush, BrushTool, PBrushTool)
    End Sub

    Private Sub ToolsDropper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsDropper.Click, DropperTool.Click
        SwitchToTool(ToolsDropper, DropperTool, Dropper)
    End Sub

    Private Sub ToolsTileSuggest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsTileSuggest.Click, TileSgstTool.Click
        SwitchToTool(ToolsTileSuggest, TileSgstTool, TileSuggest)
    End Sub

    Private Sub ToolsRectangleSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsRectangleSelect.Click, RectangleTool.Click
        SwitchToTool(ToolsRectangleSelect, RectangleTool, RectSelect)
    End Sub

    Private Sub ToolsPencilSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsPencilSelect.Click, PencilTool.Click
        SwitchToTool(ToolsPencilSelect, PencilTool, PencilSlct)
    End Sub

    Private Sub ToolsTileSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsTileSelect.Click, TileSlctTool.Click
        SwitchToTool(ToolsTileSelect, TileSlctTool, TileSlct)
    End Sub

    Private Sub ItemToolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolsItem.Click, ItemTool.Click
        SwitchToTool(ToolsItem, ItemTool, ItemT)
    End Sub

    Private Sub SwitchToTool(ByVal item1 As ToolStripMenuItem, ByVal item2 As ToolStripButton, ByVal t As Tool)
        If Not item1.Checked Then
            UncheckTools()
            item1.Checked = True
            item2.Checked = True
            SetTool(t)
        End If
        EdControl.Focus()
    End Sub

    Public Sub SetTool(ByVal t As Tool)
        If EdControl Is Nothing Or t Is Nothing Then Return
        Select Case t.SidePanel
            Case SideContentType.Tiles
                t.TilePicker = EdControl.TilePicker
                EdControl.SetSidePanel(EdControl.TilePicker)
                EdControl.TilePicker.SetAll()
            Case SideContentType.Items
                t.ItemPicker = EdControl.ItemPicker
                EdControl.SetSidePanel(EdControl.ItemPicker)
        End Select
        CurTool = t
        EdControl.t = t
        t.Refresh()
        EdControl.Repaint()
    End Sub

    Public Sub UpdateEdControl()
        If EdControl Is Nothing Then Return
        EdControl.Grid = ViewGrid.Checked
        EdControl.Repaint()
        EdControl.Focus()
    End Sub

    Public Sub SetCopy(ByVal enabled As Boolean)
        EditCopy.Enabled = enabled
        EditCut.Enabled = enabled
        CopyTool.Enabled = enabled
        CutTool.Enabled = enabled
    End Sub

    Public Sub CheckCopy()
        SetCopy(EdControl.selection.FindVisible())
    End Sub

    Private Sub Tabs_TabSelected(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tabs.TabSelected
        If updateTab Then
            EdControl = Tabs.SelectedTab.Controls(0)
            SetTool(CurTool)
            UpdateEdControl()
        End If
    End Sub

    Private Sub Tabs_TabsClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tabs.TabsClosed
        For Each i As ToolStripItem In LevelItems
            i.Enabled = False
        Next
        Tabs.Visible = False
        TSContainer.ContentPanel.BackColor = SystemColors.AppWorkspace
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim b As New Bitmap(64 * 16, 64 * 16)
        Using g As Graphics = Graphics.FromImage(b)
            For l As Integer = 0 To 255
                g.DrawImage(EdControl.lvl.tileset.images(l), (l Mod 16) * 64, (l \ 16) * 64)
            Next
        End Using
        Clipboard.SetImage(b)
    End Sub
End Class
