Imports System.IO
Public Class logo

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If (Me.Opacity < 1) Then
            Me.Opacity += 0.01
        Else
            Timer2.Enabled = True
            Timer1.Enabled = False
            Play_Music("logo.wav")
        End If
    End Sub
    Private Sub Play_Music(ByVal Mname As String)
        Dim res As IO.Stream = Reflection.Assembly.GetEntryAssembly.GetManifestResourceStream("抢劫差事编辑器." & Mname) '把这里的'宇宙诗集'更改为你的工程名
        Dim bytes(res.Length - 1) As Byte
        res.Read(bytes, 0, bytes.Length)
        My.Computer.Audio.Play(bytes, AudioPlayMode.Background)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer3.Enabled = True
        Timer2.Enabled = False
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If (Me.Opacity > 0) Then
            Me.Opacity -= 0.01
        Else
            Timer3.Enabled = False
            Me.Hide()
            Editor.Show(）
        End If
    End Sub
End Class