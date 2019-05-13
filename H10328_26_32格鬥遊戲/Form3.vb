Public Class Form3
    Dim a As String = "你好!!!" & vbNewLine & "歡迎來到「H10328_26_32格鬥遊戲」"
    Dim c1 As Integer = 0

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        c1 += 1
        If c1 <= Len(a) Then
            Label1.Text &= Mid(a, c1, 1)
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Form3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Enabled = True
        Label1.Text = ""
    End Sub
End Class