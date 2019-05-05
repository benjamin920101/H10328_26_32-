Public Class Form1
    Dim index As Integer
    Dim player1 As New WMPLib.WindowsMediaPlayer
    Dim player2 As New WMPLib.WindowsMediaPlayer
    Dim replay As Integer
    Dim name_in As String = "_"

    Sub hit_sound() '攻擊時的聲音的副程式
        player2.URL = My.Application.Info.DirectoryPath & "\hit.mp3"
        player2.settings.setMode("loop", False)
        player2.controls.play()
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        player1.URL = My.Application.Info.DirectoryPath & "\Alarm7.wav"
    End Sub

    Sub die_show_do()   '你輸了!重玩嗎?的副程式
        player1.controls.stop()
        Timer2.Enabled = False
        replay = MsgBox(name_in & ", 你輸了!重玩嗎?" , 4 + 32, "時間到GameOver")
        If replay = 6 Then
            ProgressBar1.Value = ProgressBar1.Maximum
            ProgressBar2.Value = ProgressBar2.Maximum
            player1.controls.play()
        Else
            player1.close()
            Me.Close()
        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Timer1.Enabled = True
        Timer2.Enabled = True

        If e.KeyCode = Keys.J Then   '按J鍵



            If PictureBox2.Left < PictureBox1.Left + PictureBox1.Width And PictureBox1.Left < PictureBox2.Left + PictureBox2.Width Then
                If ProgressBar2.Value > 10 Then
                    ProgressBar2.Value -= 10
                Else
                    ProgressBar2.Value = 0
                    name_in = name2
                    Call die_show_do()  '呼叫你死了!重玩嗎?的副程式
                End If
                Call hit_sound()    '呼叫攻擊時的聲音的副程式
            End If


        End If

        If e.KeyCode = Keys.M Then   '按M鍵
            If PictureBox2.Left < PictureBox1.Left + PictureBox1.Width And PictureBox1.Left < PictureBox2.Left + PictureBox2.Width Then
                If ProgressBar1.Value > 10 Then
                    ProgressBar1.Value -= 10
                Else
                    ProgressBar1.Value = 0
                    name_in = name1
                    Call die_show_do()  '呼叫你死了!重玩嗎?的副程式
                End If
                Call hit_sound()    '呼叫攻擊時的聲音的副程式
            End If
        End If



        If e.KeyCode = Keys.Left Then   '按左鍵
            PictureBox2.Left -= 10
        End If

        If e.KeyCode = Keys.Right Then   '按右鍵
            PictureBox2.Left += 10
        End If

        If e.KeyCode = Keys.Up Then   '按上鍵
            PictureBox2.Top -= 10
        End If

        If e.KeyCode = Keys.Down Then   '按下鍵
            PictureBox2.Top += 10
        End If

        If e.KeyCode = Keys.A Then   '按左鍵
            PictureBox1.Left -= 10
        End If

        If e.KeyCode = Keys.D Then   '按右鍵
            PictureBox1.Left += 10
        End If

        If e.KeyCode = Keys.W Then   '按上鍵
            PictureBox1.Top -= 10
        End If

        If e.KeyCode = Keys.S Then   '按下鍵
            PictureBox1.Top += 10
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        player1.settings.setMode("loop", True)
        player1.URL = My.Application.Info.DirectoryPath & "\BackSound.mp3"
        player1.controls.play()
        Label1.Text = name1
        Label2.Text = name2
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PictureBox1.Image = ImageList1.Images(index)
        PictureBox2.Image = ImageList1.Images(index)
        index += 1
        If index > 3 Then
            index = 0
        End If
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        'hit_
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        'hit_
    End Sub
End Class