﻿Public Class TitlePageEditor

    Public ed As Editor
    Public curWord As Word
    Public curCtrl As TitlePageEdCtrl
    Public updating As Boolean = False

    Public Overloads Function ShowDialog(ByVal ed As Editor) As DialogResult
        Me.ed = ed
        TitlePageEdCtrl1.LoadTP(New TitlePage(ed.EdControl.lvl.page1), ed.r.TitlePageGFX)
        TitlePageEdCtrl2.LoadTP(New TitlePage(ed.EdControl.lvl.page2), ed.r.TitlePageGFX)
        TitlePageEdCtrl1.SelectNone()
        TitlePageEdCtrl2.SelectNone()
        curWord = Nothing
        curCtrl = Nothing
        AnyWordSelected()
        updating = True
        txtWord.Text = ""
        updating = False
        Return Me.ShowDialog
    End Function

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ed.EdControl.lvl.page1 = TitlePageEdCtrl1.tp
        ed.EdControl.lvl.page1.Sort()
        ed.EdControl.lvl.page2 = TitlePageEdCtrl2.tp
        ed.EdControl.lvl.page2.Sort()
        Me.Close()
    End Sub

    Private Sub TitlePageEdCtrl1_WordSelected(ByVal sender As Object, ByVal w As Word) Handles TitlePageEdCtrl1.WordSelected
        curCtrl = TitlePageEdCtrl1
        TitlePageEdCtrl2.SelectNone()
        curWord = w
        AnyWordSelected()
    End Sub

    Private Sub TitlePageEdCtrl2_WordSelected(ByVal sender As Object, ByVal w As Word) Handles TitlePageEdCtrl2.WordSelected
        curCtrl = TitlePageEdCtrl2
        TitlePageEdCtrl1.SelectNone()
        curWord = w
        AnyWordSelected()
    End Sub

    Private Sub AnyWordSelected()
        Dim enabled As Boolean = curWord IsNot Nothing
        txtWord.Enabled = enabled
        btnDelete.Enabled = enabled
        btnRefresh.Enabled = enabled
        btnAlignCenter.Enabled = enabled
        btnAlignMiddle.Enabled = enabled
        nudPlt.Enabled = enabled Or chkPltAll.Checked
        If curWord IsNot Nothing Then
            updating = True
            txtWord.Text = curWord.ToString
            nudPlt.Value = curWord.font
            updating = False
        End If
    End Sub

    Private Sub chkPltAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPltAll.CheckedChanged
        nudPlt.Enabled = curWord IsNot Nothing Or chkPltAll.Checked
    End Sub

    Private Sub nudPlt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudPlt.ValueChanged
        If nudPlt.Value = 8 Then
            nudPlt.Value = 6
            Return
        End If
        If updating Then Return
        If chkPltAll.Checked Then
            For Each w As Word In TitlePageEdCtrl1.tp.words
                w.font = nudPlt.Value
            Next
            For Each w As Word In TitlePageEdCtrl2.tp.words
                w.font = nudPlt.Value
            Next
        Else
            curWord.font = nudPlt.Value
        End If
        TitlePageEdCtrl1.canvas.Invalidate()
        TitlePageEdCtrl2.canvas.Invalidate()
    End Sub

    Private validChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 !"
    Private pText As String = ""

    Private Sub txtWord_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWord.TextChanged
        If updating Then Return
        Dim pos As Integer = txtWord.SelectionStart
        For l As Integer = 0 To txtWord.Text.Length - 1
            If Not validChars.Contains(txtWord.Text(l)) Then
                txtWord.Text = pText
                txtWord.SelectionStart = pos
                Return
            End If
        Next
        pText = txtWord.Text
        curWord.chars = StrToTitle(txtWord.Text, chkRand.Checked)
        curCtrl.UpdateSelection()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        curWord.chars = StrToTitle(txtWord.Text, chkRand.Checked)
        curCtrl.UpdateSelection()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        curCtrl.Delete()
        curWord = Nothing
        AnyWordSelected()
    End Sub

    Private Sub btnAdd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd1.Click
        TitlePageEdCtrl1.Add(nudPlt.Value * If(chkPltAll.Checked, 1, 0))
    End Sub

    Private Sub btnAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd2.Click
        TitlePageEdCtrl2.Add(nudPlt.Value * If(chkPltAll.Checked, 1, 0))
    End Sub

    Private Sub btnAlignCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignCenter.Click
        curCtrl.AlignCenter()
    End Sub

    Private Sub btnAlignMiddle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignMiddle.Click
        curCtrl.AlignMiddle()
    End Sub


    Public Shared TextTable As String() = {"NT", "TH", "TE", "STE", "IT", "ET", "STI", "STR", "RTI", "RTH", "TO", "NTS", "RTY", "T", "ITA", "NTA", "PTS", _
                                    "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "RO", "Q", _
                                    "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "O", _
                                    "P", "R", "S", "U", "EI", "LI", "X", "Y", "Z", "RE", "RS", "HTM", _
                                    "I", "!", "FE", "FO", "LE", "W", _
                                    "VE", "V", " ", "VEL", "RR", "VEI"}

    Public Shared ByteTable As Integer() = {&H21, &H22, &H23, &H24, &H25, &H26, &H27, &H7127, &H28, &H7228, &H29, &H772A, &H2B6A, &H2D, &H2E, &H2E7B, &H772F, _
                                     &H30, &H31, &H32, &H33, &H34, &H35, &H36, &H37, &H38, &H39, &H3A6A, &H3B, _
                                     &H41, &H42, &H43, &H44, &H45, &H46, &H47, &H48, &H4A, &H4B, &H4C, &H4D, &H4E, &H4F, _
                                     &H50, &H51, &H53, &H55, &H56, &H57, &H58, &H59, &H5A, &H5B6A, &H5C6A, &H5D7473, _
                                     &H64, &H67, &H6968, &H7A68, &H6D6C, &H6F6E, _
                                     &H7675, &H75, &H7D, &H647675, &H5251, &H647675}

    Public Shared TextTableR As String() = {"E", "I", "O", "R", "S"}

    Public Shared ByteTableR As Integer() = {&H456263, &H6470, &H4F65, &H5152, &H5366}

    Public Shared Function StrToTitle(ByVal str As String, ByVal randomize As Boolean) As List(Of Byte)
        Dim chars As New List(Of Byte)
        Dim pos As Integer = 1
        Dim rand As New Random()
        Do Until pos > str.Length
            For l As Integer = Math.Min(3, str.Length - pos + 1) To 1 Step -1
                Dim str2 As String = Mid(str, pos, l)
                If randomize And TextTableR.Contains(str2) Then
                    Dim nums As Byte() = Shrd.GetBytes(ByteTableR(Array.IndexOf(TextTableR, str2)))
                    chars.Add(nums(rand.Next(0, nums.Length)))
                    pos += l
                    Exit For
                ElseIf TextTable.Contains(str2) Then
                    chars.AddRange(Shrd.GetBytes(ByteTable(Array.IndexOf(TextTable, str2))))
                    pos += l
                    Exit For
                End If
            Next
        Loop
        Return chars
    End Function
End Class