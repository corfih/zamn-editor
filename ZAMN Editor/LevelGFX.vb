Public Class LevelGFX

    Public Shared ItemImages As New List(Of Bitmap)
    Public Shared VictimImages As New List(Of Bitmap)
    Public Shared ptrs As Integer() = {&H1A1E2, &H19976, &H19E6D, &H1A015, &H19F00, &H19899, &H19B3D, &H19A43, &H19C89, &H1A0BE, &H19DAD}
    Public Shared offsets As Integer() = {0, 0, 20, 48, 13, 30, 17, 44, 16, 42, 23, 41, 32, 64, 15, 48, 16, 31, 16, 31, 15, 42, 25, 49}

    Public Shared Sub Load(ByVal r As ROM)
        Dim s As New IO.FileStream(r.path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
        s.Seek(&H32600, IO.SeekOrigin.Begin)
        Dim gfx(3455) As Byte
        s.Read(gfx, 0, 3456)
        s.Seek(&HF1176, IO.SeekOrigin.Begin)
        Dim plt As Color() = Shrd.ReadPalette(s, 80, True)
        ItemImages.Clear()
        For l As Integer = 0 To My.Resources.ItemPallettes.Length - 1
            Dim bmp As New Bitmap(16, 16)
            Dim gfxIndex As Integer = My.Resources.ItemIndexes(l) * &H20
            Dim pltIndex As Integer = My.Resources.ItemPallettes(l) * &H10
            Shrd.DrawTile(bmp, 0, 0, gfx, gfxIndex, plt, pltIndex, False, False)
            Shrd.DrawTile(bmp, 8, 0, gfx, gfxIndex + &H20, plt, pltIndex, False, False)
            Shrd.DrawTile(bmp, 0, 8, gfx, gfxIndex + &H40, plt, pltIndex, False, False)
            Shrd.DrawTile(bmp, 8, 8, gfx, gfxIndex + &H60, plt, pltIndex, False, False)
            ItemImages.Add(bmp)
        Next
        VictimImages.Clear()
        VictimImages.Add(New Bitmap(1, 1))
        Dim s2 As New IO.BinaryReader(New ByteArrayStream(My.Resources.VictimGFX))
        Do Until s2.BaseStream.Position >= s2.BaseStream.Length - 1
            Dim width As Integer = s2.ReadByte, height As Integer = s2.ReadByte
            Dim img As New Bitmap(width * 8, height * 8)
            Dim pos As Integer = s2.BaseStream.Position
            For p As Byte = 0 To 1
                For y As Integer = 0 To height - 1
                    For x As Integer = 0 To width - 1
                        Dim indx As Integer = s2.ReadInt32
                        If indx > 0 Then
                            If s2.ReadByte = p Then
                                s.Seek(indx, IO.SeekOrigin.Begin)
                                Shrd.DrawTile(s, img, x * 8 + s2.ReadSByte, y * 8 + s2.ReadSByte, plt, s2.ReadByte * 16, s2.ReadByte > 0, s2.ReadByte > 0)
                            Else
                                s2.BaseStream.Seek(5, IO.SeekOrigin.Current)
                            End If
                        End If
                    Next
                Next
                If p = 0 Then s2.BaseStream.Seek(pos, IO.SeekOrigin.Begin)
            Next
            VictimImages.Add(img)
        Loop
        s.Close()
        s2.Close()
    End Sub
End Class
