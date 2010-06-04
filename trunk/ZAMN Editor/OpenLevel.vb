Public Class OpenLevel

    Public levelNum As Integer
    Public LevelName As String
    Private r As ROM

    Public Overloads Function ShowDialog(ByVal r As ROM) As DialogResult
        Me.r = r
        levels.Items.Clear()
        For l As Integer = 0 To r.regLvlCount - 2
            levels.Items.Add("Level " & l.ToString())
        Next
        levels.Items.Add("Credit Level")
        For l As Integer = 0 To r.bonusLvls.Count - 1
            levels.Items.Add("Bonus Level " & l.ToString())
        Next
        Return Me.ShowDialog()
    End Function

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If levels.SelectedIndex = -1 Then
            MsgBox("Select a level", MsgBoxStyle.Information, "Select a level")
            Return
        End If
        If levels.SelectedIndex < r.regLvlCount Then
            levelNum = levels.SelectedIndex
        Else
            levelNum = r.bonusLvls(levels.SelectedIndex - r.regLvlCount)
        End If
        LevelName = levels.SelectedItem.ToString()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class