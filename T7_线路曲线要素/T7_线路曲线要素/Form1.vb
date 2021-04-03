Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolStripStatusLabel1.Text = "欢迎使用，请开始导入数据"
    End Sub

    Private Sub 导入数据ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导入数据ToolStripMenuItem.Click， ToolStripButton1.Click
        InputDataFile(New OpenFileDialog)
        If DataStr Is Nothing Then
            Exit Sub
        End If
        DataGridView1.DataSource = DataGird1(RodeData)
        ToolStripStatusLabel1.Text = "数据导入完成，请点击开始计算"
    End Sub

    Private Sub 计算ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 计算ToolStripMenuItem.Click， ToolStripButton7.Click
        If DataStr Is Nothing Then
            MsgBox("未导入数据,请导入后重试", 64, "警告")
            Exit Sub
        End If
        AllCal()
        TextBox1.Text = ReportText()
        TabControl1.SelectedTab = TabPage3
        DrawOut()
        ToolStripStatusLabel1.Text = "数据计算完成,可导出"
    End Sub

    Private Sub 导出报告ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导出报告ToolStripMenuItem.Click， ToolStripButton2.Click
        If TextBox1.Text Is Nothing Then
            MsgBox("未计算,请计算后重试", 64, "警告")
            Exit Sub
        End If
        ComputRst = TextBox1.Text
        Call OutputRsutFile(New SaveFileDialog)
    End Sub



    Private Sub 刷新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新ToolStripMenuItem.Click, 刷新ToolStripMenuItem1.Click
        Application.Restart()
    End Sub

    Private Sub 退出ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem1.Click, 退出ToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub 数据视图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 数据视图ToolStripMenuItem.Click, ToolStripButton4.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub 绘图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 绘图ToolStripMenuItem.Click, ToolStripButton5.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub 报告视图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 报告视图ToolStripMenuItem.Click, ToolStripButton6.Click
        TabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub 帮助ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 帮助ToolStripMenuItem1.Click
        MsgBox("未更新")
    End Sub

    Public Sub DrawOut()    '绘图
        Dim DRAW_BITMAP As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim PenPoint As New Pen(Color.Red, 4)
        Dim b As New SolidBrush(Color.Black)
        Dim f As New Font("宋体", 10)
        Using g As Graphics = Graphics.FromImage(DRAW_BITMAP)
            For i = 0 To ValZPoint.Length - 1
                DrawZPoint(g, PenPoint, CInt((ValZPoint(i).X - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, PictureBox1.Height - 100 - CInt((ValZPoint(i).Y - YMin()) / YHeight() * (PictureBox1.Height - 200)))
            Next
            For i = 0 To RodeCurData.Length - 1
                DrawMPoint(g, PenPoint, CInt((ValMPCoor(i).P1CooX - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, PictureBox1.Height - 100 - CInt((ValMPCoor(i).P1CooY - YMin()) / YHeight() * (PictureBox1.Height - 200)))
                DrawMPoint(g, PenPoint, CInt((CalCurRPCoorK(i, ValCirCurMK(i).Kyz - ValCirCur(i).L / 2, True).X - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, PictureBox1.Height - 300 - CInt((CalCurRPCoorK(i, ValCirCurMK(i).Kyz - ValCirCur(i).L / 2, True).Y - YMin()) / YHeight() * (PictureBox1.Height - 200)))
                DrawMPoint(g, PenPoint, CInt((ValMPCoor(i).P2CooX - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, PictureBox1.Height - 100 - CInt((ValMPCoor(i).P2CooY - YMin()) / YHeight() * (PictureBox1.Height - 200)))
                DrawMPoint(g, PenPoint, CInt((RodeCurData(i).CoorX - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, PictureBox1.Height - 100 - CInt((RodeCurData(i).CoorY - YMin()) / YHeight() * (PictureBox1.Height - 200)))
            Next
            For i = 0 To RodeHData.Length - 1
                DrawMPoint(g, PenPoint, CInt((ValHMPCoor(i).P1CoorX - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, PictureBox1.Height - 100 - CInt((ValHMPCoor(i).P1CoorY - YMin()) / YHeight() * (PictureBox1.Height - 200)))
                DrawMPoint(g, PenPoint, CInt((Coorval.X - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, PictureBox1.Height - 100 - CInt((Coorval.Y - YMin()) / YHeight() * (PictureBox1.Height - 200)))
                DrawMPoint(g, PenPoint, CInt((ValHMPCoor(i).P2CoorX - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, PictureBox1.Height - 100 - CInt((ValHMPCoor(i).P2CoorY - YMin()) / YHeight() * (PictureBox1.Height - 200)))
                DrawMPoint(g, PenPoint, CInt((RodeHData(i).CoorX - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, PictureBox1.Height - 100 - CInt((RodeHData(i).CoorY - YMin()) / YHeight() * (PictureBox1.Height - 200)))
            Next
            PictureBox1.Image = DRAW_BITMAP
        End Using

        PenPoint.Dispose()

    End Sub
    Sub SavePic()
        Dim SFD As New SaveFileDialog
        SFD.Filter = "BMP格式(*.bmp)|*.bmp"
        If SFD.ShowDialog = DialogResult.OK Then
            PictureBox1.Image.Save(SFD.FileName)
            MsgBox("图片保存完成！", MsgBoxStyle.Information, "提示")
        End If
    End Sub
    Public Sub DrawZPoint(a As Graphics, b As Pen, x As Integer, y As Integer)   '绘制点
        a.DrawEllipse(b, x - 1, y - 1, 2, 2)
    End Sub
    Public Sub DrawMPoint(a As Graphics, b As Pen, x As Integer, y As Integer)   '绘制点
        a.DrawEllipse(b, x - 3, y - 3, 6, 6)
    End Sub

    Function XMin() As Double  '坐标点x最小值
        Dim X(ValZPoint.Length - 1)
        For i As Integer = 0 To ValZPoint.Length - 1
            X(i) = ValZPoint(i).X
        Next
        Return X.Min
    End Function

    Function YMin() As Double '坐标点y最小值
        Dim Y(ValZPoint.Length - 1)
        For i As Integer = 0 To ValZPoint.Length - 1
            Y(i) = ValZPoint(i).Y
        Next
        Return Y.Min
    End Function

    Function XWidth() As Double '坐标点x最大间距
        Dim X(ValZPoint.Length - 1)
        For i As Integer = 0 To ValZPoint.Length - 1
            X(i) = ValZPoint(i).X
        Next
        Return X.Max - X.Min
    End Function

    Function YHeight() As Double '坐标点y最大间距
        Dim Y(ValZPoint.Length - 1)
        For i As Integer = 0 To ValZPoint.Length - 1
            Y(i) = ValZPoint(i).Y
        Next
        Return Y.Max - Y.Min
    End Function

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click, BMPToolStripMenuItem.Click
        SavePic()
    End Sub
    Private Sub DXFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DXFToolStripMenuItem.Click
        Dim SFD As New SaveFileDialog
        SFD.Filter = "DXF文件(*.dxf)|*.dxf"
        SFD.FilterIndex = 0
        If SFD.ShowDialog = DialogResult.OK Then
            FileOpen(1, SFD.FileName, OpenMode.Output)
            DXF_strat()

            For i = 0 To ValZPoint.Length - 1
                DXF_ZPoint(ValZPoint(i).X * 10 ^ 6, ValZPoint(i).Y * 10 ^ 6)
            Next
            For i = 0 To RodeCurData.Length - 1
                DXF_MPoint(ValMPCoor(i).P1CooX * 10 ^ 6, ValMPCoor(i).P1CooY * 10 ^ 6)
                DXF_MPoint(CalCurRPCoorK(i, ValCirCurMK(i).Kyz - ValCirCur(i).L / 2, True).X * 10 ^ 6, CalCurRPCoorK(i, ValCirCurMK(i).Kyz - ValCirCur(i).L / 2, True).Y * 10 ^ 6)
                DXF_MPoint(ValMPCoor(i).P2CooX * 10 ^ 6, ValMPCoor(i).P2CooY * 10 ^ 6)
                DXF_MPoint(RodeCurData(i).CoorX * 10 ^ 6, RodeCurData(i).CoorY * 10 ^ 6)
            Next
            For i = 0 To RodeHData.Length - 1
                DXF_MPoint(ValHMPCoor(i).P1CoorX * 10 ^ 6, ValHMPCoor(i).P1CoorY * 10 ^ 6)
                DXF_MPoint(Coorval.X * 10 ^ 6, Coorval.Y * 10 ^ 6)
                DXF_MPoint(ValHMPCoor(i).P2CoorX * 10 ^ 6, ValHMPCoor(i).P2CoorY * 10 ^ 6)
                DXF_MPoint(RodeHData(i).CoorX * 10 ^ 6, RodeHData(i).CoorY * 10 ^ 6)
            Next

            DXF_End()
            FileClose(1)
            MsgBox("输出DXF文件完成！", MsgBoxStyle.Information, "警告")
        End If
    End Sub


    Sub DXF_strat()
        PrintLine(1, 0)
        PrintLine(1, "SECTION")
        PrintLine(1, 2)
        PrintLine(1, "ENTITIES")
    End Sub
    'DXF数据画圆函数  参数为圆心点
    Sub DXF_ZPoint(ByVal x As Double, y As Double)
        PrintLine(1, 0)
        PrintLine(1, "POINT")
        PrintLine(1, 8)
        PrintLine(1, "0")
        PrintLine(1, 62)
        PrintLine(1, "1")
        PrintLine(1, 10)
        PrintLine(1, x)
        PrintLine(1, 20)
        PrintLine(1, y)
        PrintLine(1, 30)
        PrintLine(1, "0.0")
    End Sub
    Sub DXF_MPoint(ByVal x As Double, y As Double)
        PrintLine(1, 0)
        PrintLine(1, "POINT")
        PrintLine(1, 8)
        PrintLine(1, "M")
        PrintLine(1, 62)
        PrintLine(1, "1")
        PrintLine(1, 10)
        PrintLine(1, x)
        PrintLine(1, 20)
        PrintLine(1, y)
        PrintLine(1, 30)
        PrintLine(1, "0.0")
    End Sub

    Sub Circle(ByVal x As Double, y As Double)
        Dim r As Integer
        PrintLine(1, 0)
        PrintLine(1, "CIRCLE")
        PrintLine(1, 8)
        PrintLine(1, "0")
        PrintLine(1, 62)
        PrintLine(1, "1")
        PrintLine(1, 10)
        PrintLine(1, x)
        PrintLine(1, 20)
        PrintLine(1, y)
        PrintLine(1, 30)
        PrintLine(1, "0.0")
        PrintLine(1, 40)
        PrintLine(1, r)
    End Sub
    'DXF数据文本显示函数    参数为点
    Sub DXF_TEXT(ByVal X As Double, Y As Double, ID As String)
        Dim r As Integer = 20
        PrintLine(1, 0)
        PrintLine(1, "TEXT")
        PrintLine(1, 8)
        PrintLine(1, "Ptnum")
        PrintLine(1, 62)
        PrintLine(1, 4)
        PrintLine(1, 100)
        PrintLine(1, "ACDBTEXT")
        PrintLine(1, 10)
        PrintLine(1, X - 15)
        PrintLine(1, 20)
        PrintLine(1, Y - 20)
        PrintLine(1, 30)
        PrintLine(1, "0.0")
        PrintLine(1, 40)
        PrintLine(1, 2)
        PrintLine(1, 1)
        PrintLine(1, ID)
        PrintLine(1, 7)
        PrintLine(1, "宋体")
    End Sub
    'DXF数据画线函数    参数为起点和终点
    Sub DXF_LINE(ByVal PsX As Double, PsY As Double, PeX As Double, PeY As Double)
        PrintLine(1, 0)
        PrintLine(1, "LINE")
        PrintLine(1, 8)
        PrintLine(1, "Polygon")
        PrintLine(1, 62)
        PrintLine(1, "1")
        PrintLine(1, 10)
        PrintLine(1, PsX)
        PrintLine(1, 20)
        PrintLine(1, PsY)
        PrintLine(1, 11)
        PrintLine(1, PeX)
        PrintLine(1, 21)
        PrintLine(1, PeY)
    End Sub
    'DXF数据终止函数
    Sub DXF_End()
        PrintLine(1, 0)
        PrintLine(1, "ENDSEC")
        PrintLine(1, 0)
        PrintLine(1, "EOF")
    End Sub
End Class
