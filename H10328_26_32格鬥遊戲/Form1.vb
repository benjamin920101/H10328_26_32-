Public Class Form1
    Dim index As Integer
    Dim player1 As New WMPLib.WindowsMediaPlayer
    Dim player2 As New WMPLib.WindowsMediaPlayer
    Dim muda As New WMPLib.WindowsMediaPlayer
    Dim replay As Integer
    Dim name_in1, name_in2 As String
    Dim jump As Single = 10 : Dim jump2 As Single = 10
    Dim attack As Single = 5 : Dim attack2 As Single = 5
    Dim a As Boolean = True : Dim b As Boolean = True
    Dim index_hit1 As Integer = 0 : Dim index_hit2 As Integer = 0
    Dim index_bighit1 As Integer = 0 : Dim index_bighit2 As Integer = 0

    Sub hit_sound() '攻擊時的聲音的副程式
        player2.URL = My.Application.Info.DirectoryPath & "\hit.mp3"
        player2.settings.setMode("loop", False)
        player2.controls.play()
    End Sub
    Sub muda_sound() '攻擊時的聲音的副程式
        muda.URL = My.Application.Info.DirectoryPath & "\dio-brando-muda-muda_3.mp3"
        muda.settings.setMode("loop", False)
        muda.controls.play()
    End Sub

    Sub die_show_do()   '你輸了!重玩嗎?的副程式
        player1.controls.stop()
        Timer2.Enabled = False
        replay = MsgBox(name_in1 & ", 你輸了!重玩嗎?" & vbNewLine & name_in2 & ", 你贏了!重玩嗎?", 4 + 32, "時間到GameOver")
        If replay = 6 Then
            ProgressBar1.Value = ProgressBar1.Maximum
            ProgressBar2.Value = ProgressBar2.Maximum
            ProgressBar3.Value = ProgressBar3.Minimum
            ProgressBar4.Value = ProgressBar4.Minimum
            player1.controls.play()
        Else
            player1.close()
            Me.Close()
        End If
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        player1.controls.stop()
        player2.controls.stop()
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Timer1.Enabled = False
        'Timer1.Enabled = True
        Timer2.Enabled = True
        If e.KeyCode = Keys.J And a = True Then   '按J(P1攻擊P2)鍵
            Timer1.Enabled = False
            Timer7.Enabled = True
            a = False
            If PictureBox2.Left < PictureBox1.Left + PictureBox1.Width And PictureBox1.Left < PictureBox2.Left + PictureBox2.Width And PictureBox2.Top < PictureBox1.Top + PictureBox1.Height And PictureBox1.Top < PictureBox2.Top + PictureBox2.Height Then
                'Label1.Text = "1.(dio尾)" & PictureBox1.Top + PictureBox1.Height & "[>]2.(k_top)" & PictureBox2.Top
                'Label2.Text = "1.(dio_top)" & PictureBox1.Top & "[<]2.(k尾)" & PictureBox2.Top + PictureBox2.Height


                If ProgressBar2.Value > 5 Then
                    ProgressBar2.Value -= attack

                    If ProgressBar3.Value >= 100 Then
                        ProgressBar3.Value = 100
                    Else
                        ProgressBar3.Value += 10
                    End If


                    Call hit_sound()    '呼叫攻擊時的聲音的副程式
                Else
                    ProgressBar2.Value = 0
                    name_in1 = name2
                    name_in2 = name1
                    Call die_show_do()  '呼叫你死了!重玩嗎?的副程式
                End If
            End If


            Label3.Text &= attack & ", a:" & Str(a) & "(j_P1攻擊P2),"

        End If

        If e.KeyCode = Keys.M And b = True Then   '按M(P2攻擊P1)鍵
            Timer1.Enabled = False
            Timer8.Enabled = True
            b = False
            If PictureBox2.Left < PictureBox1.Left + PictureBox1.Width And PictureBox1.Left < PictureBox2.Left + PictureBox2.Width And PictureBox2.Top < PictureBox1.Top + PictureBox1.Height And PictureBox1.Top < PictureBox2.Top + PictureBox2.Height Then
                If ProgressBar1.Value > 5 Then


                    If ProgressBar4.Value >= 100 Then
                        ProgressBar4.Value = 100
                    Else
                        ProgressBar4.Value += 10
                    End If

                    ProgressBar1.Value -= attack2
                    Call hit_sound()    '呼叫攻擊時的聲音的副程式
                Else
                    ProgressBar1.Value = 0
                    name_in1 = name1
                    name_in2 = name2
                    Call die_show_do()  '呼叫你死了!重玩嗎?的副程式
                End If
            End If

            Label4.Text &= attack2 & ", b:" & Str(b) & "(M(P2攻擊P1)),"

        End If

        If e.KeyCode = Keys.Left Then   '按左鍵
            Timer1.Enabled = True
            PictureBox2.Left -= 10
            If PictureBox2.Left < 0 Then    '擋左牆
                PictureBox2.Left = 0
            End If
        End If

        If e.KeyCode = Keys.Right Then   '按右鍵
            Timer1.Enabled = True
            PictureBox2.Left += 10
            If PictureBox2.Left > Me.Width - 20 - PictureBox2.Width Then    '擋右牆
                PictureBox2.Left = Me.Width - 20 - PictureBox2.Width
            End If
        End If

        If e.KeyCode = Keys.Up Then   '按上鍵
            Timer1.Enabled = True
            Timer4.Enabled = True
        End If

        If e.KeyCode = Keys.Down Then   '按下鍵
            PictureBox2.Top += 10
            If PictureBox2.Top > Me.Height - 40 - PictureBox2.Height Then    '擋下牆
                PictureBox2.Top = Me.Height - 40 - PictureBox2.Height
            End If
        End If

        If e.KeyCode = Keys.A Then   '按A左鍵
            Timer1.Enabled = True
            PictureBox1.Left -= 10
            If PictureBox1.Left < 0 Then    '擋左牆
                PictureBox1.Left = 0
            End If
        End If

        If e.KeyCode = Keys.D Then   '按D右鍵
            Timer1.Enabled = True
            PictureBox1.Left += 10
            If PictureBox1.Left > Me.Width - 20 - PictureBox1.Width Then    '擋右牆
                PictureBox1.Left = Me.Width - 20 - PictureBox1.Width
            End If
        End If

        If e.KeyCode = Keys.W Then   '按W上鍵
            Timer1.Enabled = True
            Timer3.Enabled = True
        End If

        If e.KeyCode = Keys.S Then   '按S下鍵
            PictureBox1.Top += 10
            If PictureBox1.Top > Me.Height - 40 - PictureBox1.Height Then    '擋下牆
                PictureBox1.Top = Me.Height - 40 - PictureBox1.Height
            End If
        End If

        If e.KeyCode = Keys.K Then   '按K(防禦)鍵
            PictureBox1.Image = ImageList5.Images(0)
            attack2 = 0
            Timer5.Enabled = True

            Label4.Text &= attack2 & "(k),"

        End If

        If e.KeyCode = Keys.Oemcomma Then   '按<(防禦)鍵
            PictureBox2.Image = ImageList6.Images(0)
            attack = 0
            Timer6.Enabled = True

            Label3.Text &= attack & "(<),"

        End If

        If e.KeyCode = Keys.OemQuestion And ProgressBar4.Value = 100 Then   'P2打P1
            Timer10.Enabled = True
            If ProgressBar4.Value = 100 Then
                ProgressBar4.Value -= 100
            End If

            If PictureBox2.Left < PictureBox1.Left + PictureBox1.Width And PictureBox1.Left < PictureBox2.Left + PictureBox2.Width Then
                If ProgressBar1.Value > 30 Then
                    ProgressBar1.Value -= 30
                    Call hit_sound()    '呼叫攻擊時的聲音的副程式
                Else
                    ProgressBar1.Value = 0
                    name_in1 = name1
                    name_in2 = name2
                    Call die_show_do()  '呼叫你死了!重玩嗎?的副程式
                End If
            End If
        End If

        If e.KeyCode = Keys.L And ProgressBar3.Value = 100 Then 'P1打P2
            Timer9.Enabled = True
            If ProgressBar3.Value = 100 Then
                ProgressBar3.Value -= 100
            End If

            If PictureBox2.Left < PictureBox1.Left + PictureBox1.Width And PictureBox1.Left < PictureBox2.Left + PictureBox2.Width Then
                If ProgressBar2.Value > 30 Then
                    ProgressBar2.Value -= 30
                    Call hit_sound()    '呼叫攻擊時的聲音的副程式
                    Call muda_sound()
                Else
                    ProgressBar2.Value = 0
                    name_in1 = name1
                    name_in2 = name2
                    Call die_show_do()  '呼叫你死了!重玩嗎?的副程式
                End If
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        player1.settings.setMode("loop", True)  '開啟循環播放
        player1.URL = My.Application.Info.DirectoryPath & "\BackSound.mp3"  '播放背景音樂
        player1.controls.play() '開始播放
        Label1.Text = name1
        Label2.Text = name2
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PictureBox1.Image = ImageList1.Images(index)
        PictureBox2.Image = ImageList2.Images(index)
        index += 1
        If index > 3 Then
            index = 0
        End If
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        If PictureBox1.Top > Me.Height - 40 - PictureBox1.Height Then    '擋下牆
            PictureBox1.Top = Me.Height - 41 - PictureBox1.Height
            Timer3.Enabled = False
            jump = 10
        Else
            jump -= 0.5
            PictureBox1.Top -= jump ^ 2 - (jump - 2) ^ 2
        End If
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        If PictureBox2.Top > Me.Height - 40 - PictureBox2.Height Then    '擋下牆
            PictureBox2.Top = Me.Height - 41 - PictureBox2.Height
            Timer4.Enabled = False
            jump2 = 10
        Else
            jump2 -= 0.5
            PictureBox2.Top -= jump2 ^ 2 - (jump2 - 2) ^ 2
        End If
    End Sub

    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        attack2 = 0 '1P防禦時間限制
        Timer5.Enabled = False
        If Timer5.Enabled = False Then
            attack2 = 5
        End If

    End Sub

    Private Sub Timer6_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer6.Tick
        attack = 0 '2P防禦時間限制
        Timer6.Enabled = False
        If Timer6.Enabled = False Then
            attack = 5
        End If
    End Sub

    Private Sub Timer7_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer7.Tick
        PictureBox1.Image = ImageList3.Images(index_hit1)
        If index_hit1 < 1 Then
            index_hit1 += 1
        Else
            index_hit1 = 0
            Timer7.Enabled = False
        End If
        If Timer7.Enabled = False Then '1P攻擊間隔時間
            a = True
        End If
    End Sub

    Private Sub Timer8_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer8.Tick
        PictureBox2.Image = ImageList4.Images(index_hit2)
        If index_hit2 < 1 Then
            index_hit2 += 1
        Else
            index_hit2 = 0
            Timer8.Enabled = False
        End If
        If Timer8.Enabled = False Then '2P攻擊間隔時間
            b = True
        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Label3.Text &= attack & ","
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Label4.Text &= attack2 & "," & "b:" & str(b)
    End Sub

    Private Sub Timer9_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer9.Tick
        PictureBox1.Image = ImageList7.Images(index_bighit1)
        If index_bighit1 < 1 Then
            index_bighit1 += 1
        Else
            index_bighit1 = 0
            Timer9.Enabled = False
        End If
    End Sub

    Private Sub Timer10_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer10.Tick
        PictureBox2.Image = ImageList8.Images(index_bighit2)
        If index_bighit2 < 1 Then
            index_bighit2 += 1
        Else
            index_bighit2 = 0
            Timer10.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick

    End Sub
End Class
    '5/21[bug]按住不放會一直對對方減血, 攻擊時換圖片太快
    '解決方法(尚未解決)By陳秉昊(for 攻擊時換圖片太快)(5/21_16:07完成):
        'Timer1_Tick:
        'timer1.enabled=false
        'timer5.enabled=true
        '[add] Timer5
        'Timer5_Tick:
        'timer1.false
        'timer6依此類推
    '草稿By陳秉昊_16:09:
        '[add] Timer7
        'hit = true}
    '5/21_17:14由胡豐禾和陳秉昊討論:
        '1P=J攻擊{5_22_09:09_OK}
        '1P=K防禦{5_22_09:09_OK}
        '1P=L必殺{5_22_09:09_not_yet}
        '2P=M攻擊{5_22_09:09_OK}
        '2P=<防禦{5_22_09:09_OK}
        '2P=?必殺{5_22_09:09_not_yet}
        'Q:attack用幾次