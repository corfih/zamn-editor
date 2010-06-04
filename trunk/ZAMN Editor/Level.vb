Public Class Level

    Public tileset As Tileset
    Public Tiles As Integer(,)
    Public Width As Integer
    Public Height As Integer

    Public Sub New(ByVal s As IO.Stream)
        tileset = New Tileset(s)
        s.Seek(&H22, IO.SeekOrigin.Current)
        Width = s.ReadByte() + s.ReadByte() * &H100
        Height = s.ReadByte() + s.ReadByte() * &H100
        ReDim Tiles(Width - 1, Height - 1)
        s.Seek(-&H22, IO.SeekOrigin.Current)
        s.Seek(SharedFuncs.ReadFileAddr(s), IO.SeekOrigin.Begin)
        For l As Integer = 0 To Width * Height - 1
            Tiles(l Mod Width, l \ Width) = s.ReadByte() + s.ReadByte() * &H100
        Next
    End Sub
End Class
