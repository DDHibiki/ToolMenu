Public Class 武器组参考表
    Dim CheckHandle As IntPtr = 0
    Private OriginalLocation As Point
    Private MoveToPoint As Point
    Private blnDragging As Boolean = False
    Private Sub 武器组参考表_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If Me.blnDragging Then
            Me.MoveToPoint = Me.PointToScreen(New Point(e.X, e.Y))  '获取鼠标相对于屏幕的位置坐标
            Me.MoveToPoint.Offset(Me.OriginalLocation.X * -1, Me.OriginalLocation.Y * -1)
            Me.Location = Me.MoveToPoint
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        Me.blnDragging = True
        Me.OriginalLocation = New Point(e.X, e.Y)   '获取鼠标按下后在窗体上的位置坐标
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        Me.blnDragging = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (Label1.Visible = True And Label2.Visible = True) Then
            Label1.Visible = False
            Label2.Visible = False
            Label5.Visible = True
            Label4.Visible = True
        ElseIf (Label5.Visible = True And Label4.Visible = True) Then
            Label5.Visible = False
            Label4.Visible = False
            Label7.Visible = True
            Label6.Visible = True
        ElseIf (Label7.Visible = True And Label6.Visible = True) Then
            Label7.Visible = False
            Label6.Visible = False
            Label1.Visible = True
            Label2.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Label1.Visible = True And Label2.Visible = True) Then
            Label1.Visible = False
            Label2.Visible = False
            Label7.Visible = True
            Label6.Visible = True
        ElseIf (Label7.Visible = True And Label6.Visible = True) Then
            Label7.Visible = False
            Label6.Visible = False
            Label4.Visible = True
            Label5.Visible = True
        ElseIf (Label5.Visible = True And Label4.Visible = True) Then
            Label5.Visible = False
            Label4.Visible = False
            Label1.Visible = True
            Label2.Visible = True
        End If
    End Sub
End Class