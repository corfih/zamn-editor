Public Class Editor

    Public r As ROM
    Public EdControl As LvlEdCtrl
    Public CurTool As Tool
    Private updateTab As Boolean = True
    Private EditingTools As Tool()
    Private LevelItems As ToolStripItem()

    Private Sub Editor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Settings.Initialized Then
            Me.Location = My.Settings.Location
            Me.Size = My.Settings.Size
            If My.Settings.Maximized Then
                Me.WindowState = FormWindowState.Maximized
            End If
        End If
        EditingTools = New Tool() {New PaintbrushTool(Me), New DropperTool(Me), New TileSuggestTool(Me), New RectangleSelectTool(Me), _
                                   New PencilSelectTool(Me), New TileSelectTool(Me), New ItemTool(Me), New VictimTool(Me), New NRMonsterTool(Me)}
        LevelItems = New ToolStripItem() {FileSave, SaveTool, EditPaste, PasteTool, EditSelectAll, EditSelectNone, ViewGrid, ViewPriority, ToolStripButton1}
        TileSuggestList.LoadAll()
    End Sub

    Private Sub Editor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Settings.Initialized = True
        My.Settings.Maximized = Me.WindowState = FormWindowState.Maximized
        Me.WindowState = FormWindowState.Normal
        My.Settings.Location = Me.Location
        My.Settings.Size = Me.Size
    End Sub

    Private Sub FileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileOpen.Click, OpenTool.Click
        If OpenROM.ShowDialog = DialogResult.OK Then
            r = New ROM(OpenROM.FileName)
            If r.failed Then Return
            FileOpenLevel.Enabled = True
            OpenLevelTool.Enabled = True
            LevelGFX.Load(r)
            OpenLevel.LoadROM(r)
        End If
    End Sub

    Private Sub FileOpenLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileOpenLevel.Click, OpenLevelTool.Click
        If OpenLevel.ShowDialog = DialogResult.OK Then
            Try
                For l As Integer = 0 To OpenLevel.LevelNames.Length - 1
                    Dim lvl As Level = r.GetLevel(OpenLevel.levelNums(l))
                    EdControl = New LvlEdCtrl()
                    updateTab = False
                    Dim tp As TabPage = Tabs.AddXPage(OpenLevel.LevelNames(l))
                    tp.Controls.Add(EdControl)
                    EdControl.Dock = DockStyle.Fill
                    EdControl.LoadLevel(lvl)
                Next
                SetTool(CurTool)
                UpdateEdControl()
                updateTab = True
                TSContainer.ContentPanel.BackColor = SystemColors.Control
                For Each item As ToolStripItem In LevelItems
                    item.Enabled = True
                Next
                Tabs.Visible = True
                EdControl.Focus()
            Catch ex As Exception
                MsgBox("The level file was corrupt.", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub EditSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSelectAll.Click
        If CurTool Is Nothing Then Return
        If CurTool.SelectAll(True) Then
            SelectAll(True)
        End If
        EdControl.Repaint()
    End Sub

    Private Sub EditSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSelectNone.Click
        If CurTool Is Nothing Then Return
        If CurTool.SelectAll(False) Then
            SelectAll(False)
        End If
        EdControl.Repaint()
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

    Private Sub ViewGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewGrid.Click
        UpdateEdControl()
    End Sub

    Private Sub CollisionDataTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewPriority.Click
        UpdateEdControl()
    End Sub

    Private Sub Tools_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Tools.ItemClicked
        Dim indx As Integer = Tools.Items.IndexOf(e.ClickedItem)
        Dim indx2 As Integer = Tools.Items.IndexOf(BrushTool)
        If indx >= indx2 Then
            indx2 = indx - indx2
            SwitchToTool(ToolsMenu.DropDownItems(indx2), e.ClickedItem, EditingTools(indx2))
        End If
    End Sub

    Private Sub ToolsMenu_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolsMenu.DropDownItemClicked
        Dim indx As Integer = ToolsMenu.DropDownItems.IndexOf(e.ClickedItem)
        Dim indx2 As Integer = indx + Tools.Items.IndexOf(BrushTool)
        SwitchToTool(e.ClickedItem, Tools.Items(indx2), EditingTools(indx))
    End Sub

    Private Sub UncheckTools()
        For Each Item As ToolStripMenuItem In ToolsMenu.DropDownItems
            Item.Checked = False
        Next
        For l As Integer = Tools.Items.IndexOf(BrushTool) To Tools.Items.Count - 1
            CType(Tools.Items(l), ToolStripButton).Checked = False
        Next
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
            Case SideContentType.Victims
                t.VictimPicker = EdControl.VictimPicker
                EdControl.SetSidePanel(EdControl.VictimPicker)
            Case SideContentType.NRMonsters
                t.NRMPicker = EdControl.NRMPicker
                EdControl.SetSidePanel(EdControl.NRMPicker)
        End Select
        CurTool = t
        EdControl.t = t
        EdControl.SetStatusText(t.Status)
        t.Refresh()
        EdControl.Repaint()
    End Sub

    Public Sub UpdateEdControl()
        If EdControl Is Nothing Then Return
        EdControl.Grid = ViewGrid.Checked
        EdControl.priority = ViewPriority.Checked
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

    Private Sub Tabs_TabClosed(ByVal sender As Object, ByVal e As TabEventArgs) Handles Tabs.TabClosed
        For Each t As Tool In EditingTools
            t.RemoveEdCtrl(e.Tab.Controls(0))
        Next
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
