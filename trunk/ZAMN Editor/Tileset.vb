Public Class Tileset

    Public images(&HFF) As Bitmap

    Public Sub New(ByVal s As IO.Stream)
        Dim levelStartPos As Long = s.Position
        'Load pallette
        s.Seek(16, IO.SeekOrigin.Current)
        SharedFuncs.GoToPointer(s)
        Dim plt(&H7F) As Color
        For l As Integer = 0 To &H7F
            plt(l) = SharedFuncs.SNEStoRGB(s.ReadByte(), s.ReadByte())
        Next
        'Load graphics data
        s.Seek(levelStartPos + 12, IO.SeekOrigin.Begin)
        SharedFuncs.GoToPointer(s)
        Dim gfx(&H3FFF) As Byte
        s.Read(gfx, 0, &H4000)
        'Load map16 data
        s.Seek(levelStartPos, IO.SeekOrigin.Begin)
        SharedFuncs.GoToPointer(s)
        Dim map16 As Byte() = DecompressMap16(s)
        'Copy to bitmaps
        For i As Integer = 0 To &HFF 'Current image
            Dim CurBmp As New Bitmap(&H40, &H40)
            Dim x As Integer = 0, y As Integer = 0
            Dim m As Integer = i * &H80
            For m = m To m + &H7F Step 2 'Current position in map16
                Dim g As Integer = map16(m) * &H20
                If (map16(m + 1) And 1) = 1 Then
                    g += &H2000
                End If
                SharedFuncs.DrawTile(CurBmp, x, y, gfx, g, plt, &H10 * ((map16(m + 1) \ 4) And 7), (map16(m + 1) And &H40) > 1, (map16(m + 1) And &H80) > 1)
                x += 8
                If x = &H40 Then
                    x = 0
                    y += 8
                End If
            Next
            images(i) = CurBmp
        Next
        s.Seek(levelStartPos, IO.SeekOrigin.Begin)
    End Sub

    'Directly ripped from the subroutine at $80:CD20 and converted to work on a stream
    Private Function DecompressMap16(ByVal s As IO.Stream) As Byte()
        Dim result(&H7FFF) As Byte
        Dim writeindex As Integer = 0
        Dim dict(&HFFF) As Byte, dictindex As Integer = 0
        Dim bytesLeft As Integer = s.ReadByte() + s.ReadByte() * &H100
        Dim r3A As Integer = &HFEE, r3C As Integer = 0, r3E As Integer = 0
        Dim y As Integer = 0
        Dim a As Integer = bytesLeft
        Dim temp As Integer, temp2 As Integer
        Do
            dictindex = y
            If y = 0 Then
                y = 8
                If ReadNext(s, a, bytesLeft) Then Exit Do
            End If
            y -= 1
            temp = a
            a = a >> 1
            If (temp And 1) = 1 Then
                temp = a
                If ReadNext(s, a, bytesLeft) Then Exit Do
                WriteNext(result, writeindex, a)
                dictindex = r3A
                dict(dictindex) = CByte(a)
                dictindex += 1
                r3A = dictindex And &HFFF
                a = temp
            Else
                temp = a
                temp2 = y
                If ReadNext(s, a, bytesLeft) Then Exit Do
                r3C = a
                If ReadNext(s, a, bytesLeft) Then Exit Do
                r3C = (((a << 4) And &HF00) Or r3C)
                r3E = (a And &HF) + 2
                dictindex = r3C
                y = r3A
                For l As Integer = 0 To r3E
                    a = dict(dictindex)
                    dict(y) = a
                    WriteNext(result, writeindex, a)
                    y = (y + 1) And &HFFF
                    dictindex = (dictindex + 1) And &HFFF
                Next
                r3A = y
                y = temp2
                a = temp
            End If
        Loop
        Return result
    End Function

    Private Function ReadNext(ByVal s As IO.Stream, ByRef result As Integer, ByRef bytesLeft As Integer) As Boolean
        If bytesLeft = 0 Then Return True
        bytesLeft -= 1
        result = s.ReadByte()
        Return False
    End Function

    Private Sub WriteNext(ByRef result As Byte(), ByRef writeindex As Integer, ByVal value As Integer)
        result(writeindex) = CByte(value)
        writeindex += 1
    End Sub
End Class
