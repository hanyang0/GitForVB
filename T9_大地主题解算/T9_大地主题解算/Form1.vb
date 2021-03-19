Imports System.Math
Public Class Form1
    Dim IsBack As Boolean


    Private Sub 导入反算数据ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导入反算数据ToolStripMenuItem.Click
        IsBack = True
        PutInDGV()
    End Sub

    Private Sub 导入正算数据ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导入正算数据ToolStripMenuItem.Click
        IsBack = False
        PutInDGV()
    End Sub

    Sub PutInDGV()
        InputDataFile(New OpenFileDialog, IsBack)
        Try
            ToolStripTextBox1.Text = a
            ToolStripTextBox2.Text = b
            DataGridView1.DataSource = DataGird(DataFile, IsBack)
        Catch ex As Exception
            MsgBox("未成功导入数据", 64, "警告")
        End Try
        ToolStripStatusLabel1.Text = "数据导入已完成，请开始计算"
    End Sub

    Private Sub 大地正算ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 大地正算ToolStripMenuItem.Click
        If IsBack = False Then
            For i = 0 To DataFile.Length - 1
                Dim result As String
                result = Z_Calculate(DataFile(i).B1, DataFile(i).L1, DataFile(i).Azmiuth1, DataFile(i).S)
                Dim res() As String = Split(result, ",")
                DataFile(i).B2 = res(0)
                DataFile(i).L2 = res(1)
                DataFile(i).Azmiuth2 = res(2)
            Next
            MsgBox("正算计算已完成", 64, "信息")
            DataGridView1.DataSource = DataGird(DataFile, IsBack)
            ReportText(TextBox1, IsBack)
            ToolStripStatusLabel1.Text = "计算完成"
        Else
            MsgBox("导入数据为反算数据" & vbCrLf & "无法进行正算计算", 64, "信息")
        End If
    End Sub

    Private Sub 大地反算ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 大地反算ToolStripMenuItem.Click
        If IsBack = False Then
            MsgBox("导入数据为正算数据" & vbCrLf & "无法进行反算计算", 64, "信息")
        Else
            For i = 0 To DataFile.Length - 1
                Dim result As String
                result = F_calculate(DataFile(i).B1, DataFile(i).B2, DataFile(i).L1, DataFile(i).L2)
                Dim res() As String = Split(result, ",")
                DataFile(i).Azmiuth1 = res(0)
                DataFile(i).Azmiuth2 = res(1)
                DataFile(i).S = res(2)
            Next
            MsgBox("反算计算已完成", 64, "信息")
            DataGridView1.DataSource = DataGird(DataFile, IsBack)
            ReportText(TextBox1, IsBack)
            ToolStripStatusLabel1.Text = "计算完成"
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click， 数据ToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click， 绘图ToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click， 报告视图ToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem.Click, 退出ToolStripMenuItem1.Click
        Close()
    End Sub

    Private Sub 关于ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关于ToolStripMenuItem.Click
        MsgBox("未更新")
    End Sub

    Private Sub 保存报告ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存报告ToolStripMenuItem.Click, ToolStripButton4.Click
        If TextBox1.Text <> Nothing Then
            CmputRst = TextBox1.Text
            OutputRsutFile(New SaveFileDialog)
            MsgBox("数据报告保存完成")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolStripStatusLabel1.Text = "欢迎使用，请开始导入数据"
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        导入正算数据ToolStripMenuItem.PerformClick()
        大地正算ToolStripMenuItem.PerformClick()
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        导入反算数据ToolStripMenuItem.PerformClick()
        大地反算ToolStripMenuItem.PerformClick()
    End Sub

    Public Sub DrawOut()    '绘图
        Dim DRAW_BITMAP As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim PenPoint As New Pen(Color.Red, 4)
        Dim b As New SolidBrush(Color.Black)
        Dim f As New Font("宋体", 10)
        Using g As Graphics = Graphics.FromImage(DRAW_BITMAP)
            For i As Integer = 0 To DataFile.Length - 1
                DrawPoint(g, PenPoint, CInt((DataFile(i).B1 - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((DataFile(i).L1 - YMin()) / YHeight() * (PictureBox1.Height - 200)) + 100)
                DrawPoint(g, PenPoint, CInt((DataFile(i).B2 - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((DataFile(i).L2 - YMin()) / YHeight() * (PictureBox1.Height - 200)) + 100)
                g.DrawString(DataFile(i).StPoint, f, b, CInt((DataFile(i).B1 - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 90, CInt((DataFile(i).L1 - YMin()) / YHeight() * (PictureBox1.Height - 200)) + 80)
                g.DrawString(DataFile(i).EnPoint, f, b, CInt((DataFile(i).B2 - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 90, CInt((DataFile(i).L2 - YMin()) / YHeight() * (PictureBox1.Height - 200)) + 80)
                g.DrawLine(PenPoint, CInt((DataFile(i).B1 - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((DataFile(i).L1 - YMin()) / YHeight() * (PictureBox1.Height - 200)) + 100, CInt((DataFile(i).B2 - XMin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((DataFile(i).L2 - YMin()) / YHeight() * (PictureBox1.Height - 200)) + 100)
            Next
            PictureBox1.Image = DRAW_BITMAP
        End Using

        PenPoint.Dispose()

    End Sub
    Public Sub DrawPoint(a As Graphics, b As Pen, x As Integer, y As Integer)   '绘制点
        a.DrawEllipse(b, x - 1, y - 1, 2, 2)
    End Sub
    Function XMin() As Double  '坐标点x最小值
        Dim X((DataFile.Length) * 2 - 1)
        For i As Integer = 0 To (DataFile.Length) * 2 - 1 Step 2
            X(i) = DataFile(i / 2).B1
            X(i + 1) = DataFile(i / 2).B2

        Next
        Return X.Min
    End Function

    Function YMin() As Double '坐标点y最小值
        Dim Y((DataFile.Length) * 2 - 1)
        For i As Integer = 0 To (DataFile.Length) * 2 - 1 Step 2
            Y(i) = DataFile(i / 2).L1
            Y(i + 1) = DataFile(i / 2).L2
        Next
        Return Y.Min
    End Function

    Function XWidth() As Double '坐标点x最大间距
        Dim X((DataFile.Length) * 2 - 1)
        For i As Integer = 0 To (DataFile.Length) * 2 - 1 Step 2
            X(i) = DataFile(i / 2).B1
            X(i + 1) = DataFile(i / 2).B2

        Next
        Return X.Max - X.Min
    End Function

    Function YHeight() As Double '坐标点y最大间距
        Dim Y((DataFile.Length) * 2 - 1)
        For i As Integer = 0 To (DataFile.Length) * 2 - 1 Step 2
            Y(i) = DataFile(i / 2).L1
            Y(i + 1) = DataFile(i / 2).L2
        Next
        Return Y.Max - Y.Min
    End Function

    Private Sub 绘图ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 绘图ToolStripMenuItem1.Click
        DrawOut()
    End Sub
    Sub SavePic()
        Dim SFD As New SaveFileDialog
        SFD.Filter = "BMP格式(*.bmp)|*.bmp"
        If SFD.ShowDialog = DialogResult.OK Then
            PictureBox1.Image.Save(SFD.FileName)
            MsgBox("图片保存完成！", MsgBoxStyle.Information, "提示")
        End If
    End Sub

    Private Sub BMPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BMPToolStripMenuItem.Click
        SavePic()
    End Sub

    Private Sub DXFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DXFToolStripMenuItem.Click
        Dim SFD As New SaveFileDialog
        SFD.Filter = "DXF文件(*.dxf)|*.dxf"
        SFD.FilterIndex = 0
        If SFD.ShowDialog = DialogResult.OK Then
            FileOpen(1, SFD.FileName, OpenMode.Output)
            DXF_strat()

            For i As Integer = 0 To DataFile.Length - 1
                DXF_Point(DataFile(i).B1 * 10 ^ 6, DataFile(i).L1 * 10 ^ 6)
                DXF_Point(DataFile(i).B2 * 10 ^ 6, DataFile(i).L2 * 10 ^ 6)
                DXF_TEXT(DataFile(i).B1 * 10 ^ 6, DataFile(i).L1 * 10 ^ 6, DataFile(i).StPoint)
                DXF_TEXT(DataFile(i).B2 * 10 ^ 6, DataFile(i).L2 * 10 ^ 6, DataFile(i).EnPoint)
                DXF_LINE(DataFile(i).B1 * 10 ^ 6, DataFile(i).L1 * 10 ^ 6, DataFile(i).B2 * 10 ^ 6, DataFile(i).L2 * 10 ^ 6)
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
    Sub DXF_Point(ByVal x As Double, y As Double)
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
