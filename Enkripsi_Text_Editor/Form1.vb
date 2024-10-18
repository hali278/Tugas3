Imports System.IO

Public Class Form1
    Private Function Transform(ByVal text As String) As String
        Dim result As New System.Text.StringBuilder()
        For Each c As Char In text
            ' Geser semua karakter maju 3
            result.Append(Chr(Asc(c) + 3))
        Next
        Return result.ToString()
    End Function

    Private Sub btnBuka_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuka.Click
        Using dialog As New OpenFileDialog() With {.Filter = "Text Files (*.txt)|*.txt"}
            If dialog.ShowDialog() = DialogResult.OK Then txtIsi.Text = File.ReadAllText(dialog.FileName)
        End Using
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSimpan.Click
        Using dialog As New SaveFileDialog() With {.Filter = "Text Files (*.txt)|*.txt"}
            If dialog.ShowDialog() = DialogResult.OK Then File.WriteAllText(dialog.FileName, Transform(txtIsi.Text))
        End Using
    End Sub

    Private Sub btnHapus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHapus.Click
        If File.Exists(txtCari.Text) Then
            File.Delete(txtCari.Text)
            MessageBox.Show("File berhasil dihapus.")
        Else
            MessageBox.Show("File tidak ditemukan.")
        End If
    End Sub

    Private Sub btnCari_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCari.Click
        If File.Exists(txtCari.Text) Then
            txtIsi.Text = File.ReadAllText(txtCari.Text)
        Else
            MessageBox.Show("File tidak ditemukan.")
        End If
    End Sub
End Class
