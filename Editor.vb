Imports System.ComponentModel
Imports System.IO
Imports System.Text

Public Class Editor
    Private Sub Play_Music(ByVal Mname As String)
        Dim res As IO.Stream = Reflection.Assembly.GetEntryAssembly.GetManifestResourceStream("抢劫差事编辑器." & Mname) '
        Dim bytes(res.Length - 1) As Byte
        res.Read(bytes, 0, bytes.Length)
        My.Computer.Audio.Play(bytes, AudioPlayMode.Background)
    End Sub
    Private Function Boo_FileExist(ByVal Str_File As String) As Boolean

        Boo_FileExist = System.IO.File.Exists(Str_File)

    End Function
    Private Declare Auto Function FindWindow Lib "user32" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Private Declare Function SetWindowTextA Lib "user32" (ByVal hwnd As Integer, ByVal lpString As String) As Integer
    Private Declare Function GetDlgItem Lib "user32" Alias "GetDlgItem" (ByVal hDlg As Integer, ByVal nIDDlgItem As Integer) As Integer
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As String) As Integer
    Declare Function ShowWindowAsync Lib "user32" Alias "ShowWindowAsync" (ByVal hWnd As Integer, ByVal nCmdShow As Boolean) As Integer
    Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, ByVal lpszOp As String, ByVal lpszFile As String, ByVal lpszParams As String,
                                                                           ByVal LpszDir As String, ByVal FsShowCmd As Integer) As Integer
    Function FHC()
        Dim FHB() As Byte
        FHB = My.Resources.一次性全局作弊
        Dim FH As New IO.FileStream(Application.StartupPath & "\Tool\FH.exe", IO.FileMode.Create)
        FH.Write(FHB, 0, FHB.Length)
        FH.Dispose()
    End Function

    Function haxc()
        Dim b() As Byte
        b = My.Resources.GTAHaXUI
        Dim fs As New IO.FileStream(Application.StartupPath & "\Tool\hax.exe", IO.FileMode.Create)
        fs.Write(b, 0, b.Length)
        fs.Close()
    End Function

    Public Declare Auto Function RegisterHotKey Lib "user32.dll" Alias "RegisterHotKey" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Boolean
    Public Declare Auto Function UnRegisterHotKey Lib "user32.dll" Alias "UnregisterHotKey" (ByVal hwnd As IntPtr, ByVal id As Integer) As Boolean
    Public hash As Integer = GetHashCode()
    Public marsPID As Integer = 0
    Public noclipPID As Integer = 0
    Public antiafkPID As Integer = 0
    Public otrPID As Integer = 0
    Public DSPID As Integer = 0
    Public godPID As Integer = 0
    Public dgodPID As Integer = 0
    Private sr As StreamReader
    Private sw As StreamWriter
    Public strRead As String
    Private OriginalLocation As Point
    Private MoveToPoint As Point
    Dim hWnd As Integer
    Dim ptrtext1 As Integer
    Dim ptrtext2 As Integer
    Dim ptrtext3 As Integer
    Dim ptrtext4 As Integer
    Dim ptrtext5 As Integer
    Dim ptrtext6 As Integer
    Dim valtext As Integer
    Dim text1 As Integer
    Dim text2 As Integer
    Dim button_1 As Integer
    Dim button_2 As Integer
    Dim button_3 As Integer
    Const BM_CLICK = &HF5
    Private blnDragging As Boolean = False
    Public CheckCE As Integer = 0
    Public Checkteach As Boolean = False
    Public CQ As Boolean = False
    Public tell As Boolean = False
    Public sound As Boolean = True
    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Directory.CreateDirectory(Application.StartupPath & "\Tool")
        FHC()
        System.Threading.Thread.Sleep(1500)
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" 1 """ & Label1.Text & """", 0)
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 25 0", 0)
        If Boo_FileExist("C:/license.lic") Then '判断验证文件的存在
            '存在的情况
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 25 0", 0)
            System.Threading.Thread.Sleep(1500)
            If Boo_FileExist(Application.StartupPath & "\Tool\FH.exe") Then '文件存在
                haxc()
                GoTo run '进入主程序
            End If
            Dim cdkeys As String '新建接收输入的密码变量
trya:
            cdkeys = InputBox("本版本序列号为：" & hash & "输入你的注册码", "注册") '输入框接收数据
            If String.Compare(cdkeys, "") = 0 Then '为空则退出
                Close()
            End If
            sw = New StreamWriter("C:/license.lic", False) '保存至文件
            sw.WriteLine(cdkeys) '保存密码
            sw.Close() '关闭
            FHC()
            System.Threading.Thread.Sleep(10)
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 25 0", 0)
            System.Threading.Thread.Sleep(1500)
            If Boo_FileExist(Application.StartupPath & "\Tool\FH.exe") Then '成功的话
                haxc()
                GoTo run '进入
            Else
                MsgBox("无效注册码") '错误
                GoTo trya '返回
            End If

            '不存在的情况

        Else '初次启动无验证文件
            File.Create("C:\license.lic").Close() '新建文件
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 25 0", 0)
            Dim cdkeys As String
trya2:
            cdkeys = InputBox("本版本序列号为:" & hash & ". 输入你的注册码", "注册")
            If String.Compare(cdkeys, "") = 0 Then
                Close()
            End If
            sw = New StreamWriter("C:/license.lic", False)
            sw.WriteLine(cdkeys)
            sw.Close()
            FHC()
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 25 0", 0)
            System.Threading.Thread.Sleep(1500)
            If Boo_FileExist(Application.StartupPath & "\Tool\FH.exe") Then
                haxc()
                GoTo run

            Else
                MsgBox("无效注册码")
                GoTo trya2
            End If
        End If
run:
        If System.Diagnostics.Process.GetProcessesByName("gta5").Length = 0 Then
            CheckGames.Enabled = False
            Enabled = False
            MsgBox("请先开游戏")
            Close()
        Else
            CheckGames.Enabled = True
            Shell(Application.StartupPath & "\Tool\hax.exe")
            hWnd = FindWindow(vbNullString, "type sneed in gtahax thread ***now***")
            text1 = GetDlgItem(hWnd, 1011)
            text2 = GetDlgItem(hWnd, 1012)
            ptrtext1 = GetDlgItem(hWnd, 1000)
            ptrtext2 = GetDlgItem(hWnd, 1001)
            ptrtext3 = GetDlgItem(hWnd, 1006)
            ptrtext4 = GetDlgItem(hWnd, 1008)
            ptrtext5 = GetDlgItem(hWnd, 1007)
            ptrtext6 = GetDlgItem(hWnd, 1009)
            valtext = GetDlgItem(hWnd, 1004)
            button_1 = GetDlgItem(hWnd, 129)
            button_2 = GetDlgItem(hWnd, 131)
            button_3 = GetDlgItem(hWnd, 128)
            ShowWindowAsync(hWnd, False)
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 30")
            Play_Music("start.wav")
            RegisterHotKey(Handle, 0, 0, Keys.F7)
            RegisterHotKey(Handle, 1, 0, Keys.F8)
            RegisterHotKey(Handle, 2, 0, Keys.F6)
        End If
    End Sub
    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        If Me.blnDragging Then
            Me.MoveToPoint = Me.PointToScreen(New Point(e.X, e.Y))  '获取鼠标相对于屏幕的位置坐标
            Me.MoveToPoint.Offset(Me.OriginalLocation.X * -1, Me.OriginalLocation.Y * -1)
            Me.Location = Me.MoveToPoint
        End If
    End Sub
    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        Me.blnDragging = False
    End Sub
    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        Me.blnDragging = True
        Me.OriginalLocation = New Point(e.X, e.Y)   '获取鼠标按下后在窗体上的位置坐标
    End Sub
    Private Sub CheckGames_Tick(sender As Object, e As EventArgs) Handles CheckGames.Tick
        If System.Diagnostics.Process.GetProcessesByName("gta5").Length = 0 Then
            Close()
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedItem
            Case "卡尔·阿卜拉季"
                ComboBox4.Items.Clear()
                ComboBox4.Items.Add("武器A1")
                ComboBox4.Items.Add("武器A2")
            Case "古斯塔沃·莫塔"
                ComboBox4.Items.Clear()
                ComboBox4.Items.Add("武器B1")
                ComboBox4.Items.Add("武器B2")
            Case "查理·里德"
                ComboBox4.Items.Clear()
                ComboBox4.Items.Add("武器C1")
                ComboBox4.Items.Add("武器C2")
            Case "切斯特·麦考伊"
                ComboBox4.Items.Clear()
                ComboBox4.Items.Add("武器D1")
                ComboBox4.Items.Add("武器D2")
            Case "帕特里克·麦克瑞利"
                ComboBox4.Items.Clear()
                ComboBox4.Items.Add("武器E1")
                ComboBox4.Items.Add("武器E2")
            Case "枪决枪手！"
                ComboBox4.Items.Clear()
        End Select
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Select Case ComboBox2.SelectedItem
            Case "卡里姆·登茨"
                ComboBox5.Items.Clear()
                ComboBox5.Items.Add("威尼 天威经典版")
                ComboBox5.Items.Add("麦克斯韦 反社会")
                ComboBox5.Items.Add("丁卡 旅行家羽黑")
                ComboBox5.Items.Add("绝品 卫士经典版")
            Case "塔利亚纳·马丁内斯"
                ComboBox5.Items.Clear()
                ComboBox5.Items.Add("威皮 随行者 Mk.II")
                ComboBox5.Items.Add("绝致 漂移约塞米蒂")
                ComboBox5.Items.Add("丁卡 斯国一")
                ComboBox5.Items.Add("欧斯洛 扼喉")
            Case "陶艾迪"
                ComboBox5.Items.Clear()
                ComboBox5.Items.Add("卡林 王者经典版")
                ComboBox5.Items.Add("铁腕经典版")
                ComboBox5.Items.Add("威皮 爱利")
                ComboBox5.Items.Add("兰帕达缇 科莫达")
            Case "扎克·内尔森"
                ComboBox5.Items.Clear()
                ComboBox5.Items.Add("麦霸子 曼切兹")
                ComboBox5.Items.Add("长崎 斯特德")
                ComboBox5.Items.Add("诗津 亵渎者")
                ComboBox5.Items.Add("准则 雷克托")
            Case "切斯特·麦克雷"
                ComboBox5.Items.Clear()
                ComboBox5.Items.Add("卢恩 炸吧")
                ComboBox5.Items.Add("麦克斯韦 流浪者")
                ComboBox5.Items.Add("长崎 不法之徒")
                ComboBox5.Items.Add("卡林 艾弗伦")
            Case "枪决车手！"
                ComboBox5.Items.Clear()
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SendMessage(text1, 12, 0, "$MPx_H3OPT_TARGET")
        If (RadioButton1.Checked = True) Then
            SendMessage(text2, 12, 0, "0")
        ElseIf (RadioButton2.Checked = True) Then
            SendMessage(text2, 12, 0, "2")
        ElseIf (RadioButton3.Checked = True) Then
            SendMessage(text2, 12, 0, "1")
        ElseIf (RadioButton4.Checked = True) Then
            SendMessage(text2, 12, 0, "3")
        End If
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SendMessage(text1, 12, 0, "$MPx_H3OPT_APPROACH")
        If (RadioButton5.Checked = True) Then
            SendMessage(text2, 12, 0, "1")
            SendMessage(button_1, BM_CLICK, 0, 0)
            If (CheckBox1.Checked = True) Then
                SendMessage(text1, 12, 0, "$MPx_H3_HARD_APPROACH")
                SendMessage(text2, 12, 0, "1")
                SendMessage(button_1, BM_CLICK, 0, 0)
                SendMessage(text1, 12, 0, "$MPx_H3_LAST_APPROACH")
                SendMessage(text2, 12, 0, "0")
                SendMessage(button_1, BM_CLICK, 0, 0)
            End If
        ElseIf (RadioButton6.Checked = True) Then
            SendMessage(text2, 12, 0, "2")
            SendMessage(button_1, BM_CLICK, 0, 0)
            If (CheckBox1.Checked = True) Then
                SendMessage(text1, 12, 0, "$MPx_H3_HARD_APPROACH")
                SendMessage(text2, 12, 0, "2")
                SendMessage(button_1, BM_CLICK, 0, 0)
                SendMessage(text1, 12, 0, "$MPx_H3_LAST_APPROACH")
                SendMessage(text2, 12, 0, "0")
                SendMessage(button_1, BM_CLICK, 0, 0)
            End If
        ElseIf (RadioButton7.Checked = True) Then
            SendMessage(text2, 12, 0, "3")
            SendMessage(button_1, BM_CLICK, 0, 0)
            If (CheckBox1.Checked = True) Then
                SendMessage(text1, 12, 0, "$MPx_H3_HARD_APPROACH")
                SendMessage(text2, 12, 0, "3")
                SendMessage(button_1, BM_CLICK, 0, 0)
                SendMessage(text1, 12, 0, "$MPx_H3_LAST_APPROACH")
                SendMessage(text2, 12, 0, "0")
                SendMessage(button_1, BM_CLICK, 0, 0)
            End If
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        SendMessage(text1, 12, 0, "$MPx_H3OPT_KEYLEVELS")
        If (RadioButton8.Checked = True) Then
            SendMessage(text2, 12, 0, "1")
        ElseIf (RadioButton9.Checked = True) Then
            SendMessage(text2, 12, 0, "2")
        End If
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        SendMessage(text1, 12, 0, "$MPx_H3OPT_DISRUPTSHIP")
        If (RadioButton10.Checked = True) Then
            SendMessage(text2, 12, 0, "3")
        ElseIf (RadioButton11.Checked = True) Then
            SendMessage(text2, 12, 0, "2")
        ElseIf (RadioButton12.Checked = True) Then
            SendMessage(text2, 12, 0, "1")
        End If
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SendMessage(text1, 12, 0, "$MPx_H3OPT_BITSET1")
        SendMessage(text2, 12, 0, "-1")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (CheckBox2.Checked = False And CheckBox3.Checked = False) Then
            SendMessage(text1, 12, 0, "$MPx_H3OPT_BITSET0")
            SendMessage(text2, 12, 0, "-193")
            SendMessage(button_1, BM_CLICK, 0, 0)
        ElseIf (CheckBox2.Checked = True And CheckBox3.Checked = False) Then
            SendMessage(text1, 12, 0, "$MPx_H3OPT_BITSET0")
            SendMessage(text2, 12, 0, "-129")
            SendMessage(button_1, BM_CLICK, 0, 0)
        ElseIf (CheckBox2.Checked = False And CheckBox3.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_H3OPT_BITSET0")
            SendMessage(text2, 12, 0, "-65")
            SendMessage(button_1, BM_CLICK, 0, 0)
        Else
            SendMessage(text1, 12, 0, "$MPx_H3OPT_BITSET0")
            SendMessage(text2, 12, 0, "-1")
            SendMessage(button_1, BM_CLICK, 0, 0)
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SendMessage(text1, 12, 0, "$MPx_H3OPT_BITSET1")
        SendMessage(text2, 12, 0, "0")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        SendMessage(text1, 12, 0, "$MPx_H3OPT_BITSET0")
        SendMessage(text2, 12, 0, "0")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MsgBox("警告！此功能将解锁所有侦查点！如需重置请点击 ""重置所有侦查点兴趣点"".")
        SendMessage(text1, 12, 0, "$MPx_H3OPT_ACCESSPOINTS")
        SendMessage(text2, 12, 0, "-1")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MsgBox("警告！此功能将解锁所有兴趣点！如需重置请点击 ""重置所有侦查点兴趣点"".")
        SendMessage(text1, 12, 0, "$MPx_H3OPT_POI")
        SendMessage(text2, 12, 0, "-1")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox("警告！如果是初次执行赌场抢劫，禁止枪决任何NPC！否则任务将会无法进行！")
        If (ComboBox1.Text <> "") Then
            If (ComboBox1.Text <> "处决枪手" And ComboBox4.Text <> "") Then
                If (ComboBox1.Text = "卡尔·阿卜拉季") Then
                    SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWWEAP")
                    SendMessage(text2, 12, 0, "1")
                    SendMessage(button_1, BM_CLICK, 0, 0)
                    If (ComboBox4.Text = "武器A1") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_WEAPS")
                        SendMessage(text2, 12, 0, "0")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox4.Text = "武器A2") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_WEAPS")
                        SendMessage(text2, 12, 0, "1")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                End If
                If (ComboBox1.Text = "古斯塔沃·莫塔") Then
                    SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWWEAP")
                    SendMessage(text2, 12, 0, "2")
                    SendMessage(button_1, BM_CLICK, 0, 0)
                    If (ComboBox4.Text = "武器B1") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_WEAPS")
                        SendMessage(text2, 12, 0, "0")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox4.Text = "武器B2") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_WEAPS")
                        SendMessage(text2, 12, 0, "1")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                End If
                If (ComboBox1.Text = "查理·里德") Then
                    SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWWEAP")
                    SendMessage(text2, 12, 0, "3")
                    SendMessage(button_1, BM_CLICK, 0, 0)
                    If (ComboBox4.Text = "武器C1") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_WEAPS")
                        SendMessage(text2, 12, 0, "0")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox4.Text = "武器C2") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_WEAPS")
                        SendMessage(text2, 12, 0, "1")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                End If
                If (ComboBox1.Text = "切斯特·麦考伊") Then
                    SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWWEAP")
                    SendMessage(text2, 12, 0, "4")
                    SendMessage(button_1, BM_CLICK, 0, 0)
                    If (ComboBox4.Text = "武器D1") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_WEAPS")
                        SendMessage(text2, 12, 0, "0")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox4.Text = "武器D2") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_WEAPS")
                        SendMessage(text2, 12, 0, "1")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                End If
                If (ComboBox1.Text = "帕特里克·麦克瑞利") Then
                    SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWWEAP")
                    SendMessage(text2, 12, 0, "5")
                    SendMessage(button_1, BM_CLICK, 0, 0)
                    If (ComboBox4.Text = "武器E1") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_WEAPS")
                        SendMessage(text2, 12, 0, "0")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox4.Text = "武器E2") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_WEAPS")
                        SendMessage(text2, 12, 0, "1")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                End If
            ElseIf (ComboBox1.Text = "枪决枪手！") Then
                SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWWEAP")
                SendMessage(text2, 12, 0, "6")
                SendMessage(button_1, BM_CLICK, 0, 0)
            Else
                MsgBox("请选择武器，不需要可以枪决枪手")
                GoTo stop1
            End If
        Else
            MsgBox("请选择枪手")
            GoTo stop1
        End If
        If (ComboBox2.Text <> "") Then
            If (ComboBox2.Text <> "枪决车手！" And ComboBox5.Text <> "") Then
                If (ComboBox2.Text = "卡里姆·登茨") Then
                    SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWDRIVER")
                    SendMessage(text2, 12, 0, "1")
                    SendMessage(button_1, BM_CLICK, 0, 0)
                    If (ComboBox5.Text = "威尼 天威经典版") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "0")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "麦克斯韦 反社会") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "1")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "丁卡 旅行家羽黑") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "2")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "绝品 卫士经典版") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "3")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                End If
                If (ComboBox2.Text = "塔利亚纳·马丁内斯") Then
                    SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWDRIVER")
                    SendMessage(text2, 12, 0, "2")
                    SendMessage(button_1, BM_CLICK, 0, 0)
                    If (ComboBox5.Text = "威皮 随行者 Mk.II") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "0")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "绝致 漂移约塞米蒂") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "1")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "丁卡 斯国一") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "2")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "欧斯洛 扼喉") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "3")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                End If
                If (ComboBox2.Text = "陶艾迪") Then
                    SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWDRIVER")
                    SendMessage(text2, 12, 0, "3")
                    SendMessage(button_1, BM_CLICK, 0, 0)
                    If (ComboBox5.Text = "卡林 王者经典版") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "0")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "铁腕经典版") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "1")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "威皮 爱利") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "2")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "兰帕达缇 科莫达") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "3")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                End If
                If (ComboBox2.Text = "扎克·内尔森") Then
                    SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWDRIVER")
                    SendMessage(text2, 12, 0, "4")
                    SendMessage(button_1, BM_CLICK, 0, 0)
                    If (ComboBox5.Text = "麦霸子 曼切兹") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "0")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "长崎 斯特德") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "1")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "诗津 亵渎者") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "2")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "准则 雷克托") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "3")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                End If
                If (ComboBox2.Text = "切斯特·麦克雷") Then
                    SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWDRIVER")
                    SendMessage(text2, 12, 0, "5")
                    SendMessage(button_1, BM_CLICK, 0, 0)
                    If (ComboBox5.Text = "卢恩 炸吧") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "0")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "麦克斯韦 流浪者") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "1")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "长崎 不法之徒") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "2")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                    If (ComboBox5.Text = "卡林 艾弗伦") Then
                        SendMessage(text1, 12, 0, "$MPx_H3OPT_VEHS")
                        SendMessage(text2, 12, 0, "3")
                        SendMessage(button_1, BM_CLICK, 0, 0)
                    End If
                End If
            ElseIf (ComboBox2.Text = "枪决车手！") Then
                SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWDRIVER")
                SendMessage(text2, 12, 0, "6")
                SendMessage(button_1, BM_CLICK, 0, 0)
            Else
                MsgBox("如果不需要载具，请枪决车手")
                GoTo stop1
            End If
        Else
            MsgBox("请选择车手")
            GoTo stop1
        End If
        If (ComboBox3.Text <> "") Then
            If (ComboBox3.Text = "里奇·卢肯斯") Then
                SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWHACKER")
                SendMessage(text2, 12, 0, "1")
                SendMessage(button_1, BM_CLICK, 0, 0)
            End If
            If (ComboBox3.Text = "克里斯蒂安·费尔茨") Then
                SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWHACKER")
                SendMessage(text2, 12, 0, "2")
                SendMessage(button_1, BM_CLICK, 0, 0)
            End If
            If (ComboBox3.Text = "约翰·布莱尔") Then
                SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWHACKER")
                SendMessage(text2, 12, 0, "3")
                SendMessage(button_1, BM_CLICK, 0, 0)
            End If
            If (ComboBox3.Text = "阿维·施瓦茨曼") Then
                SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWHACKER")
                SendMessage(text2, 12, 0, "4")
                SendMessage(button_1, BM_CLICK, 0, 0)
            End If
            If (ComboBox3.Text = "佩奇·哈里斯") Then
                SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWHACKER")
                SendMessage(text2, 12, 0, "5")
                SendMessage(button_1, BM_CLICK, 0, 0)
            End If
            If (ComboBox3.Text = "枪决黑客！") Then

                SendMessage(text1, 12, 0, "$MPx_H3OPT_CREWHACKER")
                SendMessage(text2, 12, 0, "6")
                SendMessage(button_1, BM_CLICK, 0, 0)
                MsgBox("警告！你只有1分钟时间取钱！"）
            End If
        Else
            MsgBox("请选择黑客")
            GoTo stop1
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
stop1:
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        武器组参考表.Show()
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Close()
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If (TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 1 " & TextBox1.Text & " " & TextBox2.Text & " " & TextBox3.Text & " " & TextBox4.Text, 0)
        Else
            MsgBox("你必须设置所有人的分红，没有的空位用0代替。")
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        MsgBox("此操作将重置所有的侦查点与兴趣点侦查情况！")
        SendMessage(text1, 12, 0, "$MPx_H3OPT_ACCESSPOINTS")
        SendMessage(text2, 12, 0, "0")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_H3OPT_POI")
        SendMessage(text2, 12, 0, "0")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        SendMessage(text1, 12, 0, "$MPx_NO_BOUGHT_YUM_SNACKS")
        SendMessage(text2, 12, 0, "30")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_NO_BOUGHT_HEALTH_SNACKS")
        SendMessage(text2, 12, 0, "15")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_NO_BOUGHT_EPIC_SNACKS")
        SendMessage(text2, 12, 0, "5")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_NUMBER_OF_ORANGE_BOUGHT")
        SendMessage(text2, 12, 0, "10")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_NUMBER_OF_BOURGE_BOUGHT")
        SendMessage(text2, 12, 0, "10")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_CIGARETTES_BOUGHT")
        SendMessage(text2, 12, 0, "20")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_NUMBER_OF_CHAMP_BOUGHT")
        SendMessage(text2, 12, 0, "5")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles CQSET.Click
        Try
            Dim intPtr = Process.GetProcessById(noclipPID).Handle
        Catch ex As Exception
            noclipPID = Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 19", 0)
            CQSET.Text = "幽灵模式-开(F8)"
            GoTo fin
        End Try
        CQSET.Text = "幽灵模式-关(F8)"
        Shell("cmd.exe /c taskkill /f /pid " & noclipPID, 0)
        noclipPID = 0
fin:
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 5 " & TextBox5.Text, 0)
        Play_Music("click.wav")
    End Sub
    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 10", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
err2:
    End Sub
    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        If (ZLXL.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_GANGOPS_FLOW_MISSION_PROG")
            SendMessage(text2, 12, 0, "503")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_GANGOPS_HEIST_STATUS")
            SendMessage(text2, 12, 0, "-229383")
            SendMessage(button_1, BM_CLICK, 0, 0)

            GoTo fin
        End If
        If (BGD.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_GANGOPS_FLOW_MISSION_PROG")
            SendMessage(text2, 12, 0, "240")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_GANGOPS_HEIST_STATUS")
            SendMessage(text2, 12, 0, "-229378")
            SendMessage(button_1, BM_CLICK, 0, 0)

            GoTo fin
        End If
        If (MR.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_GANGOPS_FLOW_MISSION_PROG")
            SendMessage(text2, 12, 0, "16368")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_GANGOPS_HEIST_STATUS")
            SendMessage(text2, 12, 0, "-229380")
            SendMessage(button_1, BM_CLICK, 0, 0)

            GoTo fin
        End If
        MsgBox("Oops，你还没有选择任何一个模块")
fin:
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        If (TextBox10.Text <> "" And TextBox9.Text <> "" And TextBox8.Text <> "" And TextBox7.Text <> "") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 2 " & TextBox10.Text & " " & TextBox9.Text & " " & TextBox8.Text & " " & TextBox7.Text, 0)
        Else
            MsgBox("你必须设置所有人的分红，没有的空位用0代替。")
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Teleport.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 27", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        SendMessage(text1, 12, 0, "$MPx_HEIST_PLANNING_STAGE")
        SendMessage(text2, 12, 0, "-1")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Mars_Click(sender As Object, e As EventArgs) Handles Mars.Click
        Try
            Dim intPtr = Process.GetProcessById(marsPID).Handle
        Catch ex As Exception
            marsPID = Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 20", 0)
            GoTo fin
        End Try
        Shell("cmd.exe /c taskkill /f /pid " & marsPID, 0)
        marsPID = 0
fin:
        If sound = True Then
            Play_Music("click.wav")
        End If
        MsgBox("禁止用于PVP")
err1:
    End Sub
    Private Sub Editor_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If sound = True Then
            Play_Music("bye.wav")
        End If
    End Sub
    Private Sub Editor_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        UnRegisterHotKey(Handle, 0)
        UnRegisterHotKey(Handle, 1)
        UnRegisterHotKey(Handle, 2)
        System.Threading.Thread.Sleep(150)
        Shell("cmd.exe /c taskkill /f /im hax.exe", 0)
        Shell("cmd.exe /c taskkill /f /im FH.exe", 0)
        System.Threading.Thread.Sleep(1000)
        Shell("cmd.exe /c del """ & Application.StartupPath & "\Tool\*.*"" /q", 0)
        System.Threading.Thread.Sleep(100)
        Shell("cmd.exe /c del """ & Application.StartupPath & "\zw.exe"" /q", 0)
        Shell("cmd.exe /c rd """ & Application.StartupPath & "\Tool"" /S /Q", 0)
        End
    End Sub
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = 786 Then
            Select Case m.WParam
                Case 0
                    Button24.PerformClick()
                Case 1
                    CQSET.PerformClick()
                Case 2
                    Teleport.PerformClick()
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 3 " & TextBox14.Text & " 0 0 0", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        If (TextBox18.Text <> "" And TextBox17.Text <> "" And TextBox16.Text <> "" And TextBox15.Text <> "") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 4 " & TextBox18.Text & " " & TextBox17.Text & " " & TextBox16.Text & " " & TextBox15.Text, 0)
        Else
            MsgBox("你必须设置所有人的分红，没有的空位用0代替。")
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        If (lsl.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_H4CNF_TARGET")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
        End If
        If (bs.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_H4CNF_TARGET")
            SendMessage(text2, 12, 0, "1")
            SendMessage(button_1, BM_CLICK, 0, 0)
        End If
        If (zj.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_H4CNF_TARGET")
            SendMessage(text2, 12, 0, "2")
            SendMessage(button_1, BM_CLICK, 0, 0)
        End If
        If (fz.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_H4CNF_TARGET")
            SendMessage(text2, 12, 0, "3")
            SendMessage(button_1, BM_CLICK, 0, 0)
        End If
        If (lc.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_H4CNF_TARGET")
            SendMessage(text2, 12, 0, "4")
            SendMessage(button_1, BM_CLICK, 0, 0)
        End If
        If (hb.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_H4CNF_TARGET")
            SendMessage(text2, 12, 0, "5")
            SendMessage(button_1, BM_CLICK, 0, 0)
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button33_Click_1(sender As Object, e As EventArgs) Handles Button33.Click
        If (CheckBox5.Checked = False) Then
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_CASH_I_SCOPED")
            SendMessage(text2, 12, 0, "12640827")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_CASH_C_SCOPED")
            SendMessage(text2, 12, 0, "52")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_WEED_I_SCOPED")
            SendMessage(text2, 12, 0, "1052800")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_WEED_C_SCOPED")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_COKE_I_SCOPED")
            SendMessage(text2, 12, 0, "235926")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_COKE_C_SCOPED")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_GOLD_I_SCOPED")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_GOLD_C_SCOPED")
            SendMessage(text2, 12, 0, "65")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_PAINT_SCOPED")
            SendMessage(text2, 12, 0, "178600")
            SendMessage(button_1, BM_CLICK, 0, 0)
        Else
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_CASH_I")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_CASH_C")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_WEED_I")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_WEED_C")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_COKE_I")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_COKE_C")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_GOLD_I")
            SendMessage(text2, 12, 0, "-1")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_GOLD_C")
            SendMessage(text2, 12, 0, "-1")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_PAINT")
            SendMessage(text2, 12, 0, "-1")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_CASH_I_SCOPED")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_CASH_C_SCOPED")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_WEED_I_SCOPED")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_WEED_C_SCOPED")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_COKE_I_SCOPED")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_COKE_C_SCOPED")
            SendMessage(text2, 12, 0, "0")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_GOLD_I_SCOPED")
            SendMessage(text2, 12, 0, "-1")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_GOLD_C_SCOPED")
            SendMessage(text2, 12, 0, "-1")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPx_H4LOOT_PAINT_SCOPED")
            SendMessage(text2, 12, 0, "-1")
            SendMessage(button_1, BM_CLICK, 0, 0)
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        SendMessage(text1, 12, 0, "$MPx_H4_MISSIONS")
        SendMessage(text2, 12, 0, "65535")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        SendMessage(text1, 12, 0, "$MPx_H4CNF_BS_GEN")
        SendMessage(text2, 12, 0, "-1")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        SendMessage(text1, 12, 0, "$MPx_H4CNF_BS_ENTR")
        SendMessage(text2, 12, 0, "63")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        antiafkPID = Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 22", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
        Button40.Text = "Enable"
        Button40.Enabled = False
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        Select Case ComboBox7.Text
            Case "侵略者"
                SendMessage(text1, 12, 0, "$MPx_H4CNF_WEAPONS")
                SendMessage(text2, 12, 0, "1")
                SendMessage(button_1, BM_CLICK, 0, 0)
            Case "阴谋者"
                SendMessage(text1, 12, 0, "$MPx_H4CNF_WEAPONS")
                SendMessage(text2, 12, 0, "2")
                SendMessage(button_1, BM_CLICK, 0, 0)
            Case "神枪手"
                SendMessage(text1, 12, 0, "$MPx_H4CNF_WEAPONS")
                SendMessage(text2, 12, 0, "3")
                SendMessage(button_1, BM_CLICK, 0, 0)
            Case "破坏者"
                SendMessage(text1, 12, 0, "$MPx_H4CNF_WEAPONS")
                SendMessage(text2, 12, 0, "4")
                SendMessage(button_1, BM_CLICK, 0, 0)
            Case "神射手"
                SendMessage(text1, 12, 0, "$MPx_H4CNF_WEAPONS")
                SendMessage(text2, 12, 0, "5")
                SendMessage(button_1, BM_CLICK, 0, 0)
        End Select
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button22_Click_1(sender As Object, e As EventArgs) Handles Button22.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 7 " & TextBox19.Text, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button28_Click_1(sender As Object, e As EventArgs) Handles Button28.Click
        If (Button28.Text = "Sound:ON") Then
            Play_Music("click.wav")
            Button28.Text = "Sound:Off"
            sound = False
        Else
            Play_Music("logo.wav")
            Button28.Text = "Sound:ON"
            sound = True
        End If
    End Sub

    Private Sub Button25_Click_1(sender As Object, e As EventArgs) Handles Button25.Click
        SendMessage(text1, 12, 0, "$MPx_H4CNF_APPROACH")
        SendMessage(text2, 12, 0, "65535")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        If (Button46.Text = "更改为：困难") Then
            SendMessage(text1, 12, 0, "$MPx_H4_PROGRESS")
            SendMessage(text2, 12, 0, "130435")
            SendMessage(button_1, BM_CLICK, 0, 0)
            Button46.Text = "更改为：普通"
        Else
            SendMessage(text1, 12, 0, "$MPx_H4_PROGRESS")
            SendMessage(text2, 12, 0, "124271")
            SendMessage(button_1, BM_CLICK, 0, 0)
            Button46.Text = "更改为：困难"
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        SendMessage(text1, 12, 0, "$MPx_H4CNF_BS_ABIL")
        SendMessage(text2, 12, 0, "63")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        SendMessage(text1, 12, 0, "$MPx_H4LOOT_CASH_V")
        SendMessage(text2, 12, 0, XJD.Text)
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_H4LOOT_WEED_V")
        SendMessage(text2, 12, 0, DMD.Text)
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_H4LOOT_COKE_V")
        SendMessage(text2, 12, 0, KKY.Text)
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_H4LOOT_GOLD_V")
        SendMessage(text2, 12, 0, HJD.Text)
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_H4LOOT_PAINT_V")
        SendMessage(text2, 12, 0, MH2.Text)
        SendMessage(button_1, BM_CLICK, 0, 0)
        MsgBox("可能存在10%的误差")
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        If (Button43.Text = "Hotkey:ON") Then
            UnRegisterHotKey(Handle, 0)
            UnRegisterHotKey(Handle, 1)
            UnRegisterHotKey(Handle, 2)
            Button43.Text = "Hotkey:OFF"
        Else
            RegisterHotKey(Handle, 0, 0, Keys.F7)
            RegisterHotKey(Handle, 1, 0, Keys.F8)
            RegisterHotKey(Handle, 2, 0, Keys.F6)
            Button43.Text = "Hotkey:ON"
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        WindowState = System.Windows.Forms.FormWindowState.Minimized
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        If Button45.Text = "Close BG-Image" Then
            Me.BackgroundImage = Nothing
            Button45.Text = "Open BG-Image"
        Else
            Me.BackgroundImage = 抢劫差事编辑器.My.Resources._11111
            Button45.Text = "Close BG-Image"
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        SendMessage(text1, 12, 0, "$MPx_ARENAWARS_AP_TIER")
        SendMessage(text2, 12, 0, TextBox11.Text)
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click
        SendMessage(text1, 12, 0, "$MPx_ARENAWARS_AP_LIFETIME")
        SendMessage(text2, 12, 0, TextBox12.Text)
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button51_Click(sender As Object, e As EventArgs) Handles Button51.Click
        SendMessage(text1, 12, 0, "$MPx_ARENAWARS_AP")
        SendMessage(text2, 12, 0, TextBox13.Text)
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button52_Click(sender As Object, e As EventArgs) Handles Button52.Click
        SendMessage(text1, 12, 0, "$MPx_ARENAWARS_SKILL_LEVEL")
        SendMessage(text2, 12, 0, TextBox14.Text)
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles Button53.Click
        MsgBox("如果你已经完成所有的赌场任务，你可以跳过 ""解锁任务"" .只需点击 ""贝克女士想让你取车""." & vbCrLf & "否则你需要先解锁任务后，从线上-差事-执行差事-Rockstar制作-任务-金盆洗手。完成后,
即可得到载具。")
    End Sub
    Private Sub Button54_Click(sender As Object, e As EventArgs) Handles Button54.Click
        If MessageBox.Show("你戴了带遮阳板的头盔了么？", "检查", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
            SendMessage(text1, 12, 0, "$MPx_VCM_FLOW_CS_RSC_SEEN")
            SendMessage(button_2, BM_CLICK, 0, 0)
            If MessageBox.Show("遮阳板升起了么（F11或者互动菜单设置）", "检查", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                SendMessage(text1, 12, 0, "$MPx_VCM_FLOW_CS_BWL_SEEN")
                SendMessage(button_2, BM_CLICK, 0, 0)
                If MessageBox.Show("遮阳板升起了么（F11或者互动菜单设置）", "检查", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                    SendMessage(text1, 12, 0, "$MPx_VCM_FLOW_CS_MTG_SEEN")
                    SendMessage(button_2, BM_CLICK, 0, 0)
                    If MessageBox.Show("遮阳板升起了么（F11或者互动菜单设置）", "检查", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                        SendMessage(text1, 12, 0, "$MPx_VCM_FLOW_CS_OIL_SEEN")
                        SendMessage(button_2, BM_CLICK, 0, 0)
                        If MessageBox.Show("遮阳板升起了么（F11或者互动菜单设置）", "检查", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                            SendMessage(text1, 12, 0, "$MPx_VCM_FLOW_CS_DEF_SEEN")
                            SendMessage(button_2, BM_CLICK, 0, 0)
                            If MessageBox.Show("遮阳板升起了么（F11或者互动菜单设置）", "检查", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                                SendMessage(text1, 12, 0, "$MPx_VCM_FLOW_CS_FIN_SEEN")
                                SendMessage(button_2, BM_CLICK, 0, 0)
                                If MessageBox.Show("遮阳板升起了么（F11或者互动菜单设置）", "检查", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) Then
                                    MsgBox("完成，请切换战局并完成最后一个任务。")
                                Else
                                    GoTo break
                                End If
                            Else
                                GoTo break
                            End If
                        Else
                            GoTo break
                        End If
                    Else
                        GoTo break
                    End If
                Else
                    GoTo break
                End If
            Else
                GoTo break
            End If
        Else
            GoTo break
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
break:
    End Sub
    Private Sub Button55_Click(sender As Object, e As EventArgs) Handles Button55.Click
        SendMessage(text1, 12, 0, "$MPx_CAS_VEHICLE_REWARD")
        SendMessage(button_2, BM_CLICK, 0, 0)
        MsgBox("遮阳板降下了么（F11或者互动菜单设置）")
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        SendMessage(text1, 12, 0, "$MPx_CLUB_POPULARITY")
        SendMessage(text2, 12, 0, "1000")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        SendMessage(text1, 12, 0, "$MPx_SCRIPT_INCREASE_STAM")
        SendMessage(text2, 12, 0, "100")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_SCRIPT_INCREASE_STRN")
        SendMessage(text2, 12, 0, "100")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_SCRIPT_INCREASE_LUNG")
        SendMessage(text2, 12, 0, "100")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_SCRIPT_INCREASE_DRIV")
        SendMessage(text2, 12, 0, "100")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_SCRIPT_INCREASE_FLY")
        SendMessage(text2, 12, 0, "100")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_SCRIPT_INCREASE_SHO")
        SendMessage(text2, 12, 0, "100")
        SendMessage(button_1, BM_CLICK, 0, 0)
        SendMessage(text1, 12, 0, "$MPx_SCRIPT_INCREASE_STL")
        SendMessage(text2, 12, 0, "100")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If (CheckBox4.Checked = True) Then
            SendMessage(text1, 12, 0, "$MPx_CHAR_SET_RP_GIFT_ADMIN")
            SendMessage(text2, 12, 0, "2165850")
            SendMessage(button_1, BM_CLICK, 0, 0)
            SendMessage(text1, 12, 0, "$MPPLY_GLOBALXP")
            SendMessage(text2, 12, 0, "2165850")
            SendMessage(button_1, BM_CLICK, 0, 0)
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button48_Click(sender As Object, e As EventArgs) Handles Button48.Click
        SendMessage(text1, 12, 0, "$MPPLY_CHIPS_COL_TIME")
        SendMessage(text2, 12, 0, "0")
        SendMessage(button_1, BM_CLICK, 0, 0)
        MsgBox("你需要切换战局")
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button49_Click(sender As Object, e As EventArgs) Handles Button49.Click
        SendMessage(text1, 12, 0, "$MPPLY_CASINO_CHIPS_PUR_GD")
        SendMessage(text2, 12, 0, "0")
        SendMessage(button_1, BM_CLICK, 0, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click
        If (RadioButton13.Checked = True) Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 8 1" & TextBox19.Text, 0)
        End If
        If (RadioButton14.Checked = True) Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 8 11" & TextBox19.Text, 0)
        End If
        If (RadioButton15.Checked = True) Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 8 6" & TextBox19.Text, 0)
        End If
        If (RadioButton17.Checked = True) Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 8 3" & TextBox19.Text, 0)
        End If
        If (RadioButton18.Checked = True) Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 8 2" & TextBox19.Text, 0)
        End If
        If (RadioButton16.Checked = True) Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 8 10" & TextBox19.Text, 0)
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 6 " & TextBox21.Text, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button56_Click(sender As Object, e As EventArgs) Handles Button56.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 15", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button58_Click(sender As Object, e As EventArgs) Handles Button58.Click
        System.Diagnostics.Process.Start("https://wiki.rage.mp/index.php?title=Vehicles")
    End Sub

    Private Sub Button57_Click(sender As Object, e As EventArgs) Handles Button57.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 9 " & Val("&H" & TextBox22.Text), 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 16 " & TextBox23.Text, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
err1:
    End Sub

    Private Sub Button59_Click(sender As Object, e As EventArgs) Handles Button59.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 17 " & TextBox24.Text, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
err1:
    End Sub

    Private Sub Button60_Click(sender As Object, e As EventArgs) Handles Button60.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 18 " & TextBox25.Text, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
err1:
    End Sub

    Private Sub Button61_Click(sender As Object, e As EventArgs) Handles Button61.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 12", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button62_Click(sender As Object, e As EventArgs) Handles Button62.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 11", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button63_Click(sender As Object, e As EventArgs) Handles Button63.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 13", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If (Button13.Text = "GPS定位屏蔽") Then
            otrPID = Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 21", 0)
            Button13.Text = "GPS定位屏蔽取消"
        Else
            Shell("cmd.exe /c taskkill /f /pid " & otrPID）
            otrPID = 0
            Button13.Text = "GPS定位屏蔽"
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 14", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub


    Private Sub Button64_Click(sender As Object, e As EventArgs) Handles Button64.Click
        If (Button64.Text = "精神威慑") Then
            DSPID = Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 24", 0)
            Button64.Text = "气场收回"
        Else
            Shell("cmd.exe /c taskkill /f /pid " & DSPID）
            DSPID = 0
            Button64.Text = "精神威慑"
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button66_Click(sender As Object, e As EventArgs) Handles Button66.Click
        If (ComboBox1.Text = "卡尔·阿卜拉季") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 1 1 " & TextBox26.Text, 0)
        End If
        If (ComboBox1.Text = "古斯塔沃·莫塔") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 1 2 " & TextBox26.Text, 0)
        End If
        If (ComboBox1.Text = "查理·里德") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 1 3 " & TextBox26.Text, 0)
        End If
        If (ComboBox1.Text = "切斯特·麦考伊") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 1 4 " & TextBox26.Text, 0)
        End If
        If (ComboBox1.Text = "帕特里克·麦克瑞利") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 1 5 " & TextBox26.Text, 0)
        End If

        If (ComboBox2.Text = "卡里姆·登茨") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 2 1 " & TextBox27.Text, 0)
        End If
        If (ComboBox2.Text = "塔利亚纳·马丁内斯") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 2 2 " & TextBox27.Text, 0)
        End If
        If (ComboBox2.Text = "陶艾迪") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 2 3 " & TextBox27.Text, 0)
        End If
        If (ComboBox2.Text = "扎克·内尔森") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 2 4 " & TextBox27.Text, 0)
        End If
        If (ComboBox2.Text = "切斯特·麦克雷") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 2 5 " & TextBox27.Text, 0)
        End If

        If (ComboBox3.Text = "里奇·卢肯斯") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 3 1 " & TextBox28.Text, 0)
        End If
        If (ComboBox3.Text = "克里斯蒂安·费尔茨") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 3 2 " & TextBox28.Text, 0)
        End If
        If (ComboBox3.Text = "约翰·布莱尔") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 3 3 " & TextBox28.Text, 0)
        End If
        If (ComboBox3.Text = "阿维·施瓦茨曼") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 3 4 " & TextBox28.Text, 0)
        End If
        If (ComboBox3.Text = "佩奇·哈里斯") Then
            Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 3 5 " & TextBox28.Text, 0)
        End If
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 0 1 " & TextBox29.Text, 0)
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 0 2 " & TextBox30.Text, 0)
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 0 3 " & TextBox30.Text, 0)
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 23 0 4 " & TextBox30.Text, 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button65_Click(sender As Object, e As EventArgs) Handles Button65.Click
        Try
            Dim intPtr = Process.GetProcessById(godPID).Handle
        Catch ex As Exception
            godPID = Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 26", 0)
            Button65.Text = "隐世入凡"
            GoTo fin
        End Try
        Button65.Text = "天堂俱乐部VIP"
        Shell("cmd.exe /c taskkill /f /pid " & godPID, 0)
        godPID = 0
fin:
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button68_Click(sender As Object, e As EventArgs) Handles Button68.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 28", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button67_Click(sender As Object, e As EventArgs) Handles Button67.Click
        Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 29", 0)
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub

    Private Sub Button69_Click(sender As Object, e As EventArgs) Handles Button69.Click
        If (Button69.Text = "死神化身") Then
            dgodPID = Shell("""" & Application.StartupPath & "\Tool\FH.exe"" " & hash & " 31", 0)
            Button69.Text = "炼狱终结"
        Else
            Shell("cmd.exe /c taskkill /f /pid " & dgodPID）
            dgodPID = 0
            Button69.Text = "死神化身"
        End If
        If sound = True Then
            Play_Music("click.wav")
        End If
    End Sub
End Class