Public Class ByteArrayStream
    Inherits IO.Stream

    Private array As Byte()
    Private pos As Long

    Public Sub New(ByVal array As Byte())
        Me.array = array
        pos = 0
    End Sub

    Public Overrides ReadOnly Property CanRead() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property CanSeek() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property CanWrite() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Flush()

    End Sub

    Public Overrides ReadOnly Property Length() As Long
        Get
            Return array.Count()
        End Get
    End Property

    Public Overrides Property Position() As Long
        Get
            Return pos
        End Get
        Set(ByVal value As Long)
            pos = value
        End Set
    End Property

    Public Overrides Function Read(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer) As Integer
        Dim nC As Integer = Math.Min(pos + count, array.Length - 1) - pos
        If nC > 0 Then
            System.Array.Copy(array, pos, buffer, offset, nC)
            pos += count
            Return nC
        Else
            Return 1
        End If
    End Function

    Public Overrides Function Seek(ByVal offset As Long, ByVal origin As System.IO.SeekOrigin) As Long
        Select Case origin
            Case IO.SeekOrigin.Begin
                pos = offset
            Case IO.SeekOrigin.Current
                pos += offset
            Case IO.SeekOrigin.End
                pos = Me.Length - pos - 1
        End Select
        Return pos
    End Function

    Public Overrides Sub SetLength(ByVal value As Long)
        ReDim Preserve array(value)
    End Sub

    Public Overrides Sub Write(ByVal buffer() As Byte, ByVal offset As Integer, ByVal count As Integer)
        System.Array.Copy(buffer, offset, array, pos, count)
        pos += count
    End Sub

    Public Overrides Function ReadByte() As Integer
        ReadByte = array(pos)
        pos += 1
    End Function

    Public Overrides Sub WriteByte(ByVal value As Byte)
        array(pos) = value
        pos += 1
    End Sub
End Class
