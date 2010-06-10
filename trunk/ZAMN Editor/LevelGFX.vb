Public Class LevelGFX

    Public Shared ItemImages As New List(Of Bitmap)
    Private Shared ItemPalettes As Integer() = {0, 0, 0, 4, 0, 4, 3, 4, 3, 2, 0, 0, 0, 0, 0, 0, 0, 4, 0, 4, 0, 3, 0, 1, 0, 0, 3, 3, 3, 3}
    Private Shared ItemIndexes As Integer() = {0, 4, 8, 52, 12, 16, 20, 20, 28, 20, 92, 24, 44, 56, 56, 40, 36, 48, 32, 76, 60, 64, 68, 72, 80, 84, 88, 96, 100, 104}

    Public Shared Sub Load(ByVal r As ROM)
        Dim s As New IO.FileStream(r.path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
        s.Seek(&H32600, IO.SeekOrigin.Begin)
        Dim gfx(3455) As Byte
        s.Read(gfx, 0, 3456)
        s.Seek(&HF1176, IO.SeekOrigin.Begin)
        Dim plt As Color() = SharedFuncs.ReadPalette(s, 80, True)
        ItemImages.Clear()
        For l As Integer = 0 To ItemPalettes.Length - 1
            Dim bmp As New Bitmap(16, 16)
            Dim gfxIndex As Integer = ItemIndexes(l) * &H20
            Dim pltIndex As Integer = ItemPalettes(l) * &H10
            SharedFuncs.DrawTile(bmp, 0, 0, gfx, gfxIndex, plt, pltIndex, False, False)
            SharedFuncs.DrawTile(bmp, 8, 0, gfx, gfxIndex + &H20, plt, pltIndex, False, False)
            SharedFuncs.DrawTile(bmp, 0, 8, gfx, gfxIndex + &H40, plt, pltIndex, False, False)
            SharedFuncs.DrawTile(bmp, 8, 8, gfx, gfxIndex + &H60, plt, pltIndex, False, False)
            ItemImages.Add(bmp)
        Next
    End Sub
End Class
