Public Class LevelGFX

    Public Shared ItemImages As New List(Of Bitmap)
    Public Shared VictimImages As New List(Of Bitmap)
    Public Shared ptrs As Integer() = {&H1A1E2, &H19976, &H19E6D, &H1A015, &H19F00, &H19899, &H19B3D, &H19A43, &H19C89, &H1A0BE, &H19DAD, _
                                       &H17136, &H9A3A, &HA655, &H1745D, &HD4F1, &HD4F9, &H1B75E, &H1B9F6}
    Public Shared offsets As Integer() = {0, 0, 24, 47, 17, 29, 13, 38, 17, 38, 29, 40, 31, 63, 16, 47, 16, 29, 14, 32, 16, 37, 28, 44, _
                                          15, 48, 14, 46, 24, 63, 9, 31, 21, 31, 18, 42, 16, 48}
    'Tourist, Baby, Teacher, Explorer, Pool, Barbeque, Army, Trampoline, Dog, Cheerleader, Dr. Bug
    'Dracula, Chainsaw, Frankenstein, Fire, Plant, Dr. Tongue, Credit Level enemy head

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
        VictimImages.Add(My.Resources.UnknownVictim)
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
                                Shrd.DrawTile(img, x * 8 + s2.ReadSByte, y * 8 + s2.ReadSByte, s, plt, s2.ReadByte * 16, s2.ReadByte > 0, s2.ReadByte > 0)
                                'Hardcoded override for army guys face pallette
                                If VictimImages.Count = 7 And y = 1 And (x = 0 Or x = 1) Then
                                    DrawArmyOverride(s, plt)
                                    If x = 1 Then ApplyOverride(img)
                                End If
                            Else
                                s2.BaseStream.Seek(5, IO.SeekOrigin.Current)
                            End If
                        End If
                    Next
                Next
                If p = 0 Then s2.BaseStream.Seek(pos, IO.SeekOrigin.Begin)
            Next
            If VictimImages.Count = 16 Then
                VictimImages.Add(img)
            End If
            VictimImages.Add(img)
        Loop
        s.Close()
        s2.Close()
    End Sub

    Private Shared OverrideNum As Integer = 0
    Private Shared OverrideBmp As Bitmap = New Bitmap(16, 8)
    Private Shared NewPallette As Color()

    Private Shared Sub DrawArmyOverride(ByVal s As IO.FileStream, ByVal plt As Color())
        If OverrideNum = 0 Then
            NewPallette = plt.Clone()
            NewPallette(20) = plt(4)
            NewPallette(22) = plt(6)
        End If
        s.Seek(-&H20, IO.SeekOrigin.Current)
        Shrd.DrawTile(OverrideBmp, OverrideNum * 8, 0, s, NewPallette, 16, False, False)
        OverrideNum += 1
    End Sub

    Private Shared Sub ApplyOverride(ByVal bmp As Bitmap)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.DrawImage(OverrideBmp.Clone(New Rectangle(7, 1, 8, 5), OverrideBmp.PixelFormat), 7, 9, 8, 5)
        End Using
        OverrideNum = 0
        OverrideBmp = New Bitmap(16, 8)
    End Sub
End Class
