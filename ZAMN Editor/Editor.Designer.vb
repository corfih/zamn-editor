﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Editor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Editor))
        Me.TSContainer = New System.Windows.Forms.ToolStripContainer()
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileOpenLevel = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSelectNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditLevelSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewGrid = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewPriority = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.View100P = New System.Windows.Forms.ToolStripMenuItem()
        Me.View75P = New System.Windows.Forms.ToolStripMenuItem()
        Me.View50P = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsDropper = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsTileSuggest = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsRectangleSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsPencilSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsTileSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsVictims = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsNRMonsters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMonsters = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tools = New System.Windows.Forms.ToolStrip()
        Me.OpenTool = New System.Windows.Forms.ToolStripButton()
        Me.OpenLevelTool = New System.Windows.Forms.ToolStripButton()
        Me.SaveTool = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CutTool = New System.Windows.Forms.ToolStripButton()
        Me.CopyTool = New System.Windows.Forms.ToolStripButton()
        Me.PasteTool = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Zoom = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Zoom100Tool = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom75Tool = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom50Tool = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BrushTool = New System.Windows.Forms.ToolStripButton()
        Me.DropperTool = New System.Windows.Forms.ToolStripButton()
        Me.TileSgstTool = New System.Windows.Forms.ToolStripButton()
        Me.RectangleTool = New System.Windows.Forms.ToolStripButton()
        Me.PencilTool = New System.Windows.Forms.ToolStripButton()
        Me.TileSlctTool = New System.Windows.Forms.ToolStripButton()
        Me.ItemTool = New System.Windows.Forms.ToolStripButton()
        Me.VictimTool = New System.Windows.Forms.ToolStripButton()
        Me.NRMTool = New System.Windows.Forms.ToolStripButton()
        Me.MonTool = New System.Windows.Forms.ToolStripButton()
        Me.OpenROM = New System.Windows.Forms.OpenFileDialog()
        Me.Tabs = New ZAMNEditor.Tabs()
        Me.RecentROMs = New ZAMNEditor.RecentFilesList()
        Me.BMonTool = New System.Windows.Forms.ToolStripButton()
        Me.ToolsBossMonsters = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSContainer.ContentPanel.SuspendLayout()
        Me.TSContainer.TopToolStripPanel.SuspendLayout()
        Me.TSContainer.SuspendLayout()
        Me.MainMenu.SuspendLayout()
        Me.Tools.SuspendLayout()
        Me.SuspendLayout()
        '
        'TSContainer
        '
        '
        'TSContainer.BottomToolStripPanel
        '
        Me.TSContainer.BottomToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        '
        'TSContainer.ContentPanel
        '
        Me.TSContainer.ContentPanel.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.TSContainer.ContentPanel.Controls.Add(Me.Tabs)
        Me.TSContainer.ContentPanel.Size = New System.Drawing.Size(625, 386)
        Me.TSContainer.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'TSContainer.LeftToolStripPanel
        '
        Me.TSContainer.LeftToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TSContainer.Location = New System.Drawing.Point(0, 0)
        Me.TSContainer.Name = "TSContainer"
        '
        'TSContainer.RightToolStripPanel
        '
        Me.TSContainer.RightToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TSContainer.Size = New System.Drawing.Size(625, 435)
        Me.TSContainer.TabIndex = 0
        Me.TSContainer.Text = "ToolStripContainer1"
        '
        'TSContainer.TopToolStripPanel
        '
        Me.TSContainer.TopToolStripPanel.Controls.Add(Me.MainMenu)
        Me.TSContainer.TopToolStripPanel.Controls.Add(Me.Tools)
        Me.TSContainer.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        '
        'MainMenu
        '
        Me.MainMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EditMenu, Me.ViewMenu, Me.ToolsMenu})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MainMenu.Size = New System.Drawing.Size(625, 24)
        Me.MainMenu.TabIndex = 0
        Me.MainMenu.Text = "MenuStrip1"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileOpen, Me.RecentROMs, Me.FileOpenLevel, Me.toolStripSeparator2, Me.FileSave, Me.toolStripSeparator4, Me.FileExit})
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMenu.Text = "&File"
        '
        'FileOpen
        '
        Me.FileOpen.Image = Global.ZAMNEditor.My.Resources.Resources.Folder
        Me.FileOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FileOpen.Name = "FileOpen"
        Me.FileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.FileOpen.Size = New System.Drawing.Size(173, 22)
        Me.FileOpen.Text = "&Open"
        '
        'FileOpenLevel
        '
        Me.FileOpenLevel.Enabled = False
        Me.FileOpenLevel.Image = Global.ZAMNEditor.My.Resources.Resources.BlueFolder
        Me.FileOpenLevel.Name = "FileOpenLevel"
        Me.FileOpenLevel.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.FileOpenLevel.Size = New System.Drawing.Size(173, 22)
        Me.FileOpenLevel.Text = "Open Level"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(170, 6)
        '
        'FileSave
        '
        Me.FileSave.Enabled = False
        Me.FileSave.Image = Global.ZAMNEditor.My.Resources.Resources.Save
        Me.FileSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FileSave.Name = "FileSave"
        Me.FileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.FileSave.Size = New System.Drawing.Size(173, 22)
        Me.FileSave.Text = "&Save"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(170, 6)
        '
        'FileExit
        '
        Me.FileExit.Name = "FileExit"
        Me.FileExit.Size = New System.Drawing.Size(173, 22)
        Me.FileExit.Text = "E&xit"
        '
        'EditMenu
        '
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditUndo, Me.EditRedo, Me.toolStripSeparator5, Me.EditCut, Me.EditCopy, Me.EditPaste, Me.toolStripSeparator6, Me.EditSelectAll, Me.EditSelectNone, Me.toolStripSeparator9, Me.EditLevelSettings})
        Me.EditMenu.Name = "EditMenu"
        Me.EditMenu.Size = New System.Drawing.Size(39, 20)
        Me.EditMenu.Text = "&Edit"
        '
        'EditUndo
        '
        Me.EditUndo.Enabled = False
        Me.EditUndo.Name = "EditUndo"
        Me.EditUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.EditUndo.Size = New System.Drawing.Size(164, 22)
        Me.EditUndo.Text = "&Undo"
        '
        'EditRedo
        '
        Me.EditRedo.Enabled = False
        Me.EditRedo.Name = "EditRedo"
        Me.EditRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.EditRedo.Size = New System.Drawing.Size(164, 22)
        Me.EditRedo.Text = "&Redo"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(161, 6)
        '
        'EditCut
        '
        Me.EditCut.Enabled = False
        Me.EditCut.Image = Global.ZAMNEditor.My.Resources.Resources.Cut
        Me.EditCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditCut.Name = "EditCut"
        Me.EditCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.EditCut.Size = New System.Drawing.Size(164, 22)
        Me.EditCut.Text = "Cu&t"
        '
        'EditCopy
        '
        Me.EditCopy.Enabled = False
        Me.EditCopy.Image = Global.ZAMNEditor.My.Resources.Resources.Copy
        Me.EditCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditCopy.Name = "EditCopy"
        Me.EditCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.EditCopy.Size = New System.Drawing.Size(164, 22)
        Me.EditCopy.Text = "&Copy"
        '
        'EditPaste
        '
        Me.EditPaste.Enabled = False
        Me.EditPaste.Image = Global.ZAMNEditor.My.Resources.Resources.Paste
        Me.EditPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditPaste.Name = "EditPaste"
        Me.EditPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.EditPaste.Size = New System.Drawing.Size(164, 22)
        Me.EditPaste.Text = "&Paste"
        '
        'toolStripSeparator6
        '
        Me.toolStripSeparator6.Name = "toolStripSeparator6"
        Me.toolStripSeparator6.Size = New System.Drawing.Size(161, 6)
        '
        'EditSelectAll
        '
        Me.EditSelectAll.Enabled = False
        Me.EditSelectAll.Name = "EditSelectAll"
        Me.EditSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.EditSelectAll.Size = New System.Drawing.Size(164, 22)
        Me.EditSelectAll.Text = "Select &All"
        '
        'EditSelectNone
        '
        Me.EditSelectNone.Enabled = False
        Me.EditSelectNone.Name = "EditSelectNone"
        Me.EditSelectNone.Size = New System.Drawing.Size(164, 22)
        Me.EditSelectNone.Text = "Select &None"
        '
        'toolStripSeparator9
        '
        Me.toolStripSeparator9.Name = "toolStripSeparator9"
        Me.toolStripSeparator9.Size = New System.Drawing.Size(161, 6)
        '
        'EditLevelSettings
        '
        Me.EditLevelSettings.Enabled = False
        Me.EditLevelSettings.Name = "EditLevelSettings"
        Me.EditLevelSettings.Size = New System.Drawing.Size(164, 22)
        Me.EditLevelSettings.Text = "Level Settings"
        '
        'ViewMenu
        '
        Me.ViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewGrid, Me.ViewPriority, Me.toolStripSeparator7, Me.View100P, Me.View75P, Me.View50P})
        Me.ViewMenu.Name = "ViewMenu"
        Me.ViewMenu.Size = New System.Drawing.Size(44, 20)
        Me.ViewMenu.Text = "&View"
        '
        'ViewGrid
        '
        Me.ViewGrid.CheckOnClick = True
        Me.ViewGrid.Enabled = False
        Me.ViewGrid.Name = "ViewGrid"
        Me.ViewGrid.Size = New System.Drawing.Size(134, 22)
        Me.ViewGrid.Text = "&Grid"
        '
        'ViewPriority
        '
        Me.ViewPriority.CheckOnClick = True
        Me.ViewPriority.Enabled = False
        Me.ViewPriority.Name = "ViewPriority"
        Me.ViewPriority.Size = New System.Drawing.Size(134, 22)
        Me.ViewPriority.Text = "Tile Priority"
        '
        'toolStripSeparator7
        '
        Me.toolStripSeparator7.Name = "toolStripSeparator7"
        Me.toolStripSeparator7.Size = New System.Drawing.Size(131, 6)
        '
        'View100P
        '
        Me.View100P.Name = "View100P"
        Me.View100P.Size = New System.Drawing.Size(134, 22)
        Me.View100P.Text = "100%"
        '
        'View75P
        '
        Me.View75P.Name = "View75P"
        Me.View75P.Size = New System.Drawing.Size(134, 22)
        Me.View75P.Text = "75%"
        '
        'View50P
        '
        Me.View50P.Name = "View50P"
        Me.View50P.Size = New System.Drawing.Size(134, 22)
        Me.View50P.Text = "50%"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolsDropper, Me.ToolsTileSuggest, Me.ToolsRectangleSelect, Me.ToolsPencilSelect, Me.ToolsTileSelect, Me.ToolsItem, Me.ToolsVictims, Me.ToolsNRMonsters, Me.ToolsMonsters, Me.ToolsBossMonsters})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(48, 20)
        Me.ToolsMenu.Text = "&Tools"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.ZAMNEditor.My.Resources.Resources.Brush
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(218, 22)
        Me.ToolStripMenuItem2.Text = "Paint Brush"
        '
        'ToolsDropper
        '
        Me.ToolsDropper.Image = Global.ZAMNEditor.My.Resources.Resources.Dropper
        Me.ToolsDropper.Name = "ToolsDropper"
        Me.ToolsDropper.Size = New System.Drawing.Size(218, 22)
        Me.ToolsDropper.Text = "&Dropper"
        '
        'ToolsTileSuggest
        '
        Me.ToolsTileSuggest.Name = "ToolsTileSuggest"
        Me.ToolsTileSuggest.Size = New System.Drawing.Size(218, 22)
        Me.ToolsTileSuggest.Text = "Tile &Suggest"
        '
        'ToolsRectangleSelect
        '
        Me.ToolsRectangleSelect.Image = Global.ZAMNEditor.My.Resources.Resources.Selection
        Me.ToolsRectangleSelect.Name = "ToolsRectangleSelect"
        Me.ToolsRectangleSelect.Size = New System.Drawing.Size(218, 22)
        Me.ToolsRectangleSelect.Text = "&Rectangle Select"
        '
        'ToolsPencilSelect
        '
        Me.ToolsPencilSelect.Image = Global.ZAMNEditor.My.Resources.Resources.PencilSelect
        Me.ToolsPencilSelect.Name = "ToolsPencilSelect"
        Me.ToolsPencilSelect.Size = New System.Drawing.Size(218, 22)
        Me.ToolsPencilSelect.Text = "&Pencil Select"
        '
        'ToolsTileSelect
        '
        Me.ToolsTileSelect.Image = Global.ZAMNEditor.My.Resources.Resources.TileSelect
        Me.ToolsTileSelect.Name = "ToolsTileSelect"
        Me.ToolsTileSelect.Size = New System.Drawing.Size(218, 22)
        Me.ToolsTileSelect.Text = "&Tile Select"
        '
        'ToolsItem
        '
        Me.ToolsItem.Image = Global.ZAMNEditor.My.Resources.Resources.FirstAidKit
        Me.ToolsItem.Name = "ToolsItem"
        Me.ToolsItem.Size = New System.Drawing.Size(218, 22)
        Me.ToolsItem.Text = "&Items"
        '
        'ToolsVictims
        '
        Me.ToolsVictims.Image = Global.ZAMNEditor.My.Resources.Resources.Dog
        Me.ToolsVictims.Name = "ToolsVictims"
        Me.ToolsVictims.Size = New System.Drawing.Size(218, 22)
        Me.ToolsVictims.Text = "&Victims"
        '
        'ToolsNRMonsters
        '
        Me.ToolsNRMonsters.Image = Global.ZAMNEditor.My.Resources.Resources.Chainsaw
        Me.ToolsNRMonsters.Name = "ToolsNRMonsters"
        Me.ToolsNRMonsters.Size = New System.Drawing.Size(218, 22)
        Me.ToolsNRMonsters.Text = "&Non-Respawning Monsters"
        '
        'ToolsMonsters
        '
        Me.ToolsMonsters.Name = "ToolsMonsters"
        Me.ToolsMonsters.Size = New System.Drawing.Size(218, 22)
        Me.ToolsMonsters.Text = "&Monsters"
        '
        'Tools
        '
        Me.Tools.Dock = System.Windows.Forms.DockStyle.None
        Me.Tools.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenTool, Me.OpenLevelTool, Me.SaveTool, Me.toolStripSeparator, Me.CutTool, Me.CopyTool, Me.PasteTool, Me.toolStripSeparator1, Me.Zoom, Me.toolStripSeparator8, Me.BrushTool, Me.DropperTool, Me.TileSgstTool, Me.RectangleTool, Me.PencilTool, Me.TileSlctTool, Me.ItemTool, Me.VictimTool, Me.NRMTool, Me.MonTool, Me.BMonTool})
        Me.Tools.Location = New System.Drawing.Point(3, 24)
        Me.Tools.Name = "Tools"
        Me.Tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Tools.Size = New System.Drawing.Size(450, 25)
        Me.Tools.TabIndex = 1
        '
        'OpenTool
        '
        Me.OpenTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenTool.Image = Global.ZAMNEditor.My.Resources.Resources.Folder
        Me.OpenTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenTool.Name = "OpenTool"
        Me.OpenTool.Size = New System.Drawing.Size(23, 22)
        Me.OpenTool.Text = "&Open"
        '
        'OpenLevelTool
        '
        Me.OpenLevelTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenLevelTool.Enabled = False
        Me.OpenLevelTool.Image = Global.ZAMNEditor.My.Resources.Resources.BlueFolder
        Me.OpenLevelTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenLevelTool.Name = "OpenLevelTool"
        Me.OpenLevelTool.Size = New System.Drawing.Size(23, 22)
        Me.OpenLevelTool.Text = "Open Level"
        '
        'SaveTool
        '
        Me.SaveTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveTool.Enabled = False
        Me.SaveTool.Image = Global.ZAMNEditor.My.Resources.Resources.Save
        Me.SaveTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveTool.Name = "SaveTool"
        Me.SaveTool.Size = New System.Drawing.Size(23, 22)
        Me.SaveTool.Text = "&Save"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'CutTool
        '
        Me.CutTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutTool.Enabled = False
        Me.CutTool.Image = Global.ZAMNEditor.My.Resources.Resources.Cut
        Me.CutTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutTool.Name = "CutTool"
        Me.CutTool.Size = New System.Drawing.Size(23, 22)
        Me.CutTool.Text = "C&ut"
        '
        'CopyTool
        '
        Me.CopyTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyTool.Enabled = False
        Me.CopyTool.Image = Global.ZAMNEditor.My.Resources.Resources.Copy
        Me.CopyTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyTool.Name = "CopyTool"
        Me.CopyTool.Size = New System.Drawing.Size(23, 22)
        Me.CopyTool.Text = "&Copy"
        '
        'PasteTool
        '
        Me.PasteTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteTool.Enabled = False
        Me.PasteTool.Image = Global.ZAMNEditor.My.Resources.Resources.Paste
        Me.PasteTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteTool.Name = "PasteTool"
        Me.PasteTool.Size = New System.Drawing.Size(23, 22)
        Me.PasteTool.Text = "&Paste"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Zoom
        '
        Me.Zoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Zoom.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Zoom100Tool, Me.Zoom75Tool, Me.Zoom50Tool})
        Me.Zoom.Image = Global.ZAMNEditor.My.Resources.Resources.MagnifyingGlass
        Me.Zoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Zoom.Name = "Zoom"
        Me.Zoom.Size = New System.Drawing.Size(29, 22)
        Me.Zoom.Text = "Zoom Level"
        '
        'Zoom100Tool
        '
        Me.Zoom100Tool.Name = "Zoom100Tool"
        Me.Zoom100Tool.Size = New System.Drawing.Size(102, 22)
        Me.Zoom100Tool.Text = "100%"
        '
        'Zoom75Tool
        '
        Me.Zoom75Tool.Name = "Zoom75Tool"
        Me.Zoom75Tool.Size = New System.Drawing.Size(102, 22)
        Me.Zoom75Tool.Text = "75%"
        '
        'Zoom50Tool
        '
        Me.Zoom50Tool.Name = "Zoom50Tool"
        Me.Zoom50Tool.Size = New System.Drawing.Size(102, 22)
        Me.Zoom50Tool.Text = "50%"
        '
        'toolStripSeparator8
        '
        Me.toolStripSeparator8.Name = "toolStripSeparator8"
        Me.toolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'BrushTool
        '
        Me.BrushTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BrushTool.Image = Global.ZAMNEditor.My.Resources.Resources.Brush
        Me.BrushTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BrushTool.Name = "BrushTool"
        Me.BrushTool.Size = New System.Drawing.Size(23, 22)
        Me.BrushTool.Text = "Paint Brush"
        '
        'DropperTool
        '
        Me.DropperTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DropperTool.Image = Global.ZAMNEditor.My.Resources.Resources.Dropper
        Me.DropperTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DropperTool.Name = "DropperTool"
        Me.DropperTool.Size = New System.Drawing.Size(23, 22)
        Me.DropperTool.Text = "Dropper"
        '
        'TileSgstTool
        '
        Me.TileSgstTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TileSgstTool.Image = CType(resources.GetObject("TileSgstTool.Image"), System.Drawing.Image)
        Me.TileSgstTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TileSgstTool.Name = "TileSgstTool"
        Me.TileSgstTool.Size = New System.Drawing.Size(23, 22)
        Me.TileSgstTool.Text = "Tile Suggest"
        '
        'RectangleTool
        '
        Me.RectangleTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RectangleTool.Image = Global.ZAMNEditor.My.Resources.Resources.Selection
        Me.RectangleTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RectangleTool.Name = "RectangleTool"
        Me.RectangleTool.Size = New System.Drawing.Size(23, 22)
        Me.RectangleTool.Text = "Rectangle Select"
        '
        'PencilTool
        '
        Me.PencilTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PencilTool.Image = Global.ZAMNEditor.My.Resources.Resources.PencilSelect
        Me.PencilTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PencilTool.Name = "PencilTool"
        Me.PencilTool.Size = New System.Drawing.Size(23, 22)
        Me.PencilTool.Text = "Pencil Select"
        '
        'TileSlctTool
        '
        Me.TileSlctTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TileSlctTool.Image = Global.ZAMNEditor.My.Resources.Resources.TileSelect
        Me.TileSlctTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TileSlctTool.Name = "TileSlctTool"
        Me.TileSlctTool.Size = New System.Drawing.Size(23, 22)
        Me.TileSlctTool.Text = "Tile Select"
        '
        'ItemTool
        '
        Me.ItemTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ItemTool.Image = Global.ZAMNEditor.My.Resources.Resources.FirstAidKit
        Me.ItemTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ItemTool.Name = "ItemTool"
        Me.ItemTool.Size = New System.Drawing.Size(23, 22)
        Me.ItemTool.Text = "Item Tool"
        '
        'VictimTool
        '
        Me.VictimTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.VictimTool.Image = Global.ZAMNEditor.My.Resources.Resources.Dog
        Me.VictimTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.VictimTool.Name = "VictimTool"
        Me.VictimTool.Size = New System.Drawing.Size(23, 22)
        Me.VictimTool.Text = "Victim Tool"
        '
        'NRMTool
        '
        Me.NRMTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NRMTool.Image = Global.ZAMNEditor.My.Resources.Resources.Chainsaw
        Me.NRMTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NRMTool.Name = "NRMTool"
        Me.NRMTool.Size = New System.Drawing.Size(23, 22)
        Me.NRMTool.Text = "Non-Respawning Monster Tool"
        '
        'MonTool
        '
        Me.MonTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MonTool.Image = CType(resources.GetObject("MonTool.Image"), System.Drawing.Image)
        Me.MonTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MonTool.Name = "MonTool"
        Me.MonTool.Size = New System.Drawing.Size(23, 22)
        Me.MonTool.Text = "Monster Tool"
        '
        'OpenROM
        '
        Me.OpenROM.DefaultExt = "smc"
        Me.OpenROM.Filter = "SNES ROM Files (*.smc)|*.smc|All Files (*.*)|*.*"
        '
        'Tabs
        '
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(0, 0)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.Size = New System.Drawing.Size(625, 386)
        Me.Tabs.TabIndex = 1
        Me.Tabs.Text = "Tabs1"
        Me.Tabs.Visible = False
        '
        'RecentROMs
        '
        Me.RecentROMs.Enabled = False
        Me.RecentROMs.Items = CType(resources.GetObject("RecentROMs.Items"), System.Collections.Generic.List(Of String))
        Me.RecentROMs.MaxItems = 5
        Me.RecentROMs.MaxLength = 60
        Me.RecentROMs.Name = "RecentROMs"
        Me.RecentROMs.Size = New System.Drawing.Size(173, 22)
        Me.RecentROMs.Text = "Recent ROMs"
        '
        'BMonTool
        '
        Me.BMonTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BMonTool.Image = CType(resources.GetObject("BMonTool.Image"), System.Drawing.Image)
        Me.BMonTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BMonTool.Name = "BMonTool"
        Me.BMonTool.Size = New System.Drawing.Size(23, 22)
        Me.BMonTool.Text = "Boss Monsters"
        '
        'ToolsBossMonsters
        '
        Me.ToolsBossMonsters.Name = "ToolsBossMonsters"
        Me.ToolsBossMonsters.Size = New System.Drawing.Size(218, 22)
        Me.ToolsBossMonsters.Text = "&Boss Monsters"
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 435)
        Me.Controls.Add(Me.TSContainer)
        Me.Name = "Editor"
        Me.Text = "ZAMN Level Editor"
        Me.TSContainer.ContentPanel.ResumeLayout(False)
        Me.TSContainer.TopToolStripPanel.ResumeLayout(False)
        Me.TSContainer.TopToolStripPanel.PerformLayout()
        Me.TSContainer.ResumeLayout(False)
        Me.TSContainer.PerformLayout()
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.Tools.ResumeLayout(False)
        Me.Tools.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TSContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditRedo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tools As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileOpenLevel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenROM As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BrushTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewGrid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsDropper As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DropperTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tabs As ZAMNEditor.Tabs
    Friend WithEvents ToolsRectangleSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RectangleTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsPencilSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PencilTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents TileSlctTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsTileSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSelectNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsTileSuggest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileSgstTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ItemTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VictimTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsVictims As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewPriority As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenLevelTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents NRMTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolsNRMonsters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents View100P As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents View75P As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents View50P As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Zoom As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Zoom100Tool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Zoom75Tool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Zoom50Tool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecentROMs As ZAMNEditor.RecentFilesList
    Friend WithEvents ToolsMonsters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditLevelSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsBossMonsters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BMonTool As System.Windows.Forms.ToolStripButton

End Class