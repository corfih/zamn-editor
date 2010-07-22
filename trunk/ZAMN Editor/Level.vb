Public Class Level

    Public tileset As Tileset
    Public Tiles As Integer(,)
    Public Width As Integer
    Public Height As Integer
    Public items As List(Of Item)
    Public victims As List(Of Victim)

    Public Sub New(ByVal s As IO.Stream)
        Dim startAddr As Long = s.Position
        tileset = New Tileset(s)
        s.Seek(&H22, IO.SeekOrigin.Current)
        Width = s.ReadByte() + s.ReadByte() * &H100
        Height = s.ReadByte() + s.ReadByte() * &H100
        ReDim Tiles(Width - 1, Height - 1)
        s.Seek(-&H6, IO.SeekOrigin.Current)
        Shrd.GoToRelativePointer(s, &H9F)
        items = New List(Of Item)
        Do
            Dim v As Integer = s.ReadByte + s.ReadByte * &H100
            If v = 0 Then Exit Do
            items.Add(New Item(v - 8, s.ReadByte + s.ReadByte * &H100 - 8, s.ReadByte \ 2))
        Loop
        s.Seek(startAddr + &H1E, IO.SeekOrigin.Begin)
        Shrd.GoToRelativePointer(s, &H9F)
        victims = New List(Of Victim)
        For n As Integer = 1 To 10
            Dim vic As Victim = New Victim(s.ReadByte + s.ReadByte * &H100, s.ReadByte + s.ReadByte * &H100, s.ReadByte + s.ReadByte * &H100, _
                                   s.ReadByte + s.ReadByte * &H100, Shrd.ReadFileAddr(s))
            vic.x -= LevelGFX.offsets(vic.vicnum * 2)
            vic.y -= LevelGFX.offsets(vic.vicnum * 2 + 1)
            victims.Add(vic)
        Next
        s.Seek(startAddr + 4, IO.SeekOrigin.Begin)
        Shrd.GoToPointer(s)
        For l As Integer = 0 To Width * Height - 1
            Tiles(l Mod Width, l \ Width) = s.ReadByte() + s.ReadByte() * &H100
        Next
    End Sub
End Class
