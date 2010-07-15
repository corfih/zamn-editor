Public Class Tileset

    Public images(&HFF) As Bitmap
    Public priorityImages(&HFF) As Bitmap
    Public address As Integer

    Public Sub New(ByVal s As IO.Stream)
        Dim levelStartPos As Long = s.Position
        'Load pallette
        s.Seek(16, IO.SeekOrigin.Current)
        Shrd.GoToPointer(s)
        Dim plt As Color() = Shrd.ReadPalette(s, &H80, False)
        'Load graphics data
        s.Seek(levelStartPos + 12, IO.SeekOrigin.Begin)
        Shrd.GoToPointer(s)
        Dim gfx(&H3FFF) As Byte
        s.Read(gfx, 0, &H4000)
        'Load map16 data
        s.Seek(levelStartPos, IO.SeekOrigin.Begin)
        Shrd.GoToPointer(s)
        address = s.Position
        Dim map16 As Byte() = DecompressMap16(s)
        'Copy to bitmaps
        For i As Integer = 0 To &HFF 'Current image
            Dim CurBmp As New Bitmap(64, 64)
            Dim CurPBmp As New Bitmap(64, 64)
            Dim x As Integer = 0, y As Integer = 0
            Dim m As Integer = i * &H80
            For m = m To m + &H7F Step 2 'Current position in map16
                Dim g As Integer = map16(m) * &H20
                If (map16(m + 1) And 1) = 1 Then
                    g += &H2000
                End If
                Shrd.DrawTile(CurBmp, x, y, gfx, g, plt, &H10 * ((map16(m + 1) \ 4) And 7), (map16(m + 1) And &H40) > 1, (map16(m + 1) And &H80) > 1)
                x += 8
                If x = &H40 Then
                    x = 0
                    y += 8
                End If
            Next
            images(i) = CurBmp
            priorityImages(i) = CurPBmp
        Next
        s.Seek(levelStartPos, IO.SeekOrigin.Begin)
    End Sub

    Public Shared Function DecompressMap16(ByVal s As IO.Stream) As Byte()
        Dim result(&H7FFF) As Byte
        Dim dict(&HFFF) As Byte
        Dim writeDictPos As Integer = &HFEE
        Dim readDictPos As Integer
        Dim bytesLeft As Integer = s.ReadByte + s.ReadByte * &H100
        Dim bitsLeft As Integer = 0
        Dim writeByte As Byte
        Dim curByte As Byte
        Dim writeIndex As Integer
        Do
            If bitsLeft = 0 Then
                bitsLeft = 8
                If ReadNext(s, writeByte, bytesLeft) Then Exit Do
            End If
            bitsLeft -= 1
            If (writeByte And 1) = 1 Then
                If ReadNext(s, curByte, bytesLeft) Then Exit Do
                WriteNext(result, writeIndex, curByte)
                dict(writeDictPos) = curByte
                writeDictPos = (writeDictPos + 1) And &HFFF
            Else
                If ReadNext(s, readDictPos, bytesLeft) OrElse ReadNext(s, curByte, bytesLeft) Then Exit Do
                readDictPos = ((curByte And &HF0) * 16) Or readDictPos
                For l As Integer = 0 To (curByte And &HF) + 2
                    curByte = dict(readDictPos)
                    dict(writeDictPos) = curByte
                    WriteNext(result, writeIndex, curByte)
                    writeDictPos = (writeDictPos + 1) And &HFFF
                    readDictPos = (readDictPos + 1) And &HFFF
                Next
            End If
            writeByte = writeByte \ 2
        Loop
        Return result
    End Function

    Private Shared Function ReadNext(ByVal s As IO.Stream, ByRef result As Integer, ByRef bytesLeft As Integer) As Boolean
        If bytesLeft = 0 Then Return True
        bytesLeft -= 1
        result = s.ReadByte()
        Return False
    End Function

    Private Shared Sub WriteNext(ByRef result As Byte(), ByRef writeindex As Integer, ByVal value As Integer)
        result(writeindex) = CByte(value)
        writeindex += 1
    End Sub
End Class
