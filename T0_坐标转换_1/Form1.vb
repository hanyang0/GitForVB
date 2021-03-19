Imports System.Math
Imports System.IO
Imports T0_坐标转换.AngConver

Public Class MainForm
    Public mf, L0, B As Double
    Public a, f, e2, e02, W, n1, t, N, M, M0 As Double
    Dim dt As New DataTable
    Dim mpoint() As mPoint


    Public Sub TableLoad()     '表格初始化
        dt.Columns.Clear()
        dt.Rows.Clear()
        For i As Integer = 1 To 9
            dt.Columns.Add(New DataColumn(CStr(i)))
        Next
        DataGridView1.DataSource = dt
        dt.Rows.Add()
        DataGridView1("1", 0).Value = "椭圆参数名称"
        DataGridView1("2", 0).Value = "数值"
        DataGridView1("3", 0).Value = "点号"
        DataGridView1("4", 0).Value = "大地坐标经度B"
        DataGridView1("5", 0).Value = "大地坐标纬度L"
        DataGridView1("6", 0).Value = "大地坐标高H"
        DataGridView1("7", 0).Value = "空间坐标X"
        DataGridView1("8", 0).Value = "空间坐标Y"
        DataGridView1("9", 0).Value = "空间坐标Z"
        For i As Integer = 1 To 9
            DataGridView1(CStr(i), 0).Style.BackColor = Color.Linen
        Next
    End Sub

    Public Sub EllipoidCalc()     '椭圆参数计算
        f = 1 / mf
        e2 = 2 * f - f * f
        e02 = e2 / (1 - e2)
        W = Sqrt(1 - e2 * (Sin(CRad(B)) ^ 2))
        n1 = e02 * (Cos(CRad(B)) ^ 2)
        t = Tan(CRad(B))
        N = a / W
        M = a * (1 - e2) / (W ^ 3)
        M0 = a * (1 - e2)
    End Sub

    Public Sub PrintOut()       '文本框输出
        TextBox1.Text = "1.椭球相关参数计算：" & vbCrLf
        TextBox1.Text &= String.Format("f={0:f6}", f) & vbCrLf
        TextBox1.Text &= String.Format("e^2={0:f6}", e2) & vbCrLf
        TextBox1.Text &= String.Format("e'^2={0:f6}", e02) & vbCrLf
        TextBox1.Text &= String.Format("W={0:f6}", W) & vbCrLf
        TextBox1.Text &= String.Format("n={0:f6}", n1) & vbCrLf
        TextBox1.Text &= String.Format("t={0:f6}", t) & vbCrLf
        TextBox1.Text &= String.Format("N={0:f6}", N) & vbCrLf
        TextBox1.Text &= String.Format("M={0:f6}", M) & vbCrLf
        TextBox1.Text &= String.Format("M0={0:f6}", M0) & vbCrLf
        TextBox1.Text &= vbCrLf




        TextBox1.Text &= "2:" & "大地坐标（BLH）转空间坐标（XYZ）" & vbCrLf
        TextBox1.Text &= "--------------------------------------" & vbCrLf
        TextBox1.Text &= String.Format("{0,-5}    {1,-17}    {2,-17}{3,-8}  {4,-14}{5,-14}{6,-14}{7}", "点名", "B", "L", "H", "X", "Y", "Z", vbCrLf)
        For i As Integer = 0 To mpoint.Length - 1
            TextBox1.Text &= String.Format("{0,-5}", mpoint(i).Name)
            TextBox1.Text &= String.Format("{0,-17}", DMSToDMSstr(mpoint(i).XB))
            TextBox1.Text &= String.Format("{0,-17}", DMSToDMSstr(mpoint(i).YL))
            TextBox1.Text &= String.Format("{0,-8:f4}", mpoint(i).ZH)
            TextBox1.Text &= String.Format("{0,-14:f4}", mpoint(i).X(a, e2))
            TextBox1.Text &= String.Format("{0,-14:f4}", mpoint(i).Y(a, e2))
            TextBox1.Text &= String.Format("{0,-14:f4}", mpoint(i).Z(a, e2))
            TextBox1.Text &= vbCrLf
        Next
        TextBox1.Text &= vbCrLf




        For i As Integer = 0 To mpoint.Length - 1
            DataGridView1("7", i + 1).Value = String.Format("{0:f4}  ", mpoint(i).X(a, e2))
            DataGridView1("8", i + 1).Value = String.Format("{0:f4}  ", mpoint(i).Y(a, e2))
            DataGridView1("9", i + 1).Value = String.Format("{0:f4}  ", mpoint(i).Z(a, e2))
            For j As Integer = 7 To 9
                DataGridView1(CStr(j), i + 1).Style.BackColor = Color.LightYellow
            Next
        Next
        dt.Rows.Add()
        DataGridView1("3", mpoint.Length + 1).Value = "点号"
        DataGridView1("4", mpoint.Length + 1).Value = "空间坐标X"
        DataGridView1("5", mpoint.Length + 1).Value = "空间坐标Y"
        DataGridView1("6", mpoint.Length + 1).Value = "空间坐标Z"
        DataGridView1("7", mpoint.Length + 1).Value = "大地坐标经度B"
        DataGridView1("8", mpoint.Length + 1).Value = "大地坐标纬度L"
        DataGridView1("9", mpoint.Length + 1).Value = "大地坐标高H"
        For i As Integer = 3 To 9
            DataGridView1(CStr(i), mpoint.Length + 1).Style.BackColor = Color.Linen
        Next
        For i As Integer = 0 To mpoint.Length - 1
            dt.Rows.Add()
            DataGridView1("3", i + 2 + mpoint.Length).Value = mpoint(i).Name
            DataGridView1("3", i + 2 + mpoint.Length).Style.BackColor = Color.Linen
            DataGridView1("4", i + 2 + mpoint.Length).Value = String.Format("{0:f4}  ", mpoint(i).X(a, e2) + 2018)
            DataGridView1("5", i + 2 + mpoint.Length).Value = String.Format("{0:f4}  ", mpoint(i).Y(a, e2) + 2018)
            DataGridView1("6", i + 2 + mpoint.Length).Value = String.Format("{0:f4}  ", mpoint(i).Z(a, e2) + 2018)
            DataGridView1("7", i + 2 + mpoint.Length).Value = String.Format("{0,-17:f4}", RadToDMSstr(mpoint(i).B(a, e2)))
            DataGridView1("8", i + 2 + mpoint.Length).Value = String.Format("{0,-17:f4}", RadToDMSstr(mpoint(i).L(a, e2)))
            DataGridView1("9", i + 2 + mpoint.Length).Value = String.Format("{0,-8:f4}", mpoint(i).H(a, e2))
            For j As Integer = 4 To 9
                DataGridView1(CStr(j), i + 2 + mpoint.Length).Style.BackColor = Color.LightYellow
            Next
        Next



        TextBox1.Text &= "3:" & "空间坐标（XYZ）转大地坐标（BLH）" & vbCrLf
        TextBox1.Text &= "--------------------------------------" & vbCrLf
        TextBox1.Text &= String.Format("{0,-5}   {1,-14} {2,-14}{3,-14}  {4,-17}   {5,-17}   {6,-4}{7}", "点名", "X", "Y", "Z", "B", "L", "H", vbCrLf)
        For i As Integer = 0 To mpoint.Length - 1
            TextBox1.Text &= String.Format("{0,-5:f4}", mpoint(i).Name)
            TextBox1.Text &= String.Format("{0,-14:f4}", mpoint(i).X(a, e2) + 2018)
            TextBox1.Text &= String.Format("{0,-14:f4}", mpoint(i).Y(a, e2) + 2018)
            TextBox1.Text &= String.Format("{0,-14:f4}", mpoint(i).Z(a, e2) + 2018)
            TextBox1.Text &= String.Format("{0,-17:f4}", RadToDMSstr(mpoint(i).B(a, e2)))
            TextBox1.Text &= String.Format("{0,-17:f4}", RadToDMSstr(mpoint(i).L(a, e2)))
            TextBox1.Text &= String.Format("{0,-4:f4}", mpoint(i).H(a, e2))
            TextBox1.Text &= vbCrLf
        Next
        TextBox1.Text &= vbCrLf
        TextBox1.Text &= "4.1:" & "高斯正算（BL--XY）" & vbCrLf
        TextBox1.Text &= "--------------------------------------" & vbCrLf
        TextBox1.Text &= String.Format("{0,-5}    {1,-17}    {2,-17} {3,-14}{4,-14}{5}", "点名", "B", "L", "X", "Y", vbCrLf)
        For i As Integer = 0 To mpoint.Length - 1
            TextBox1.Text &= String.Format("{0,-5:f4}", mpoint(i).Name)
            TextBox1.Text &= String.Format("{0,-17}", DMSToDMSstr(mpoint(i).XB))
            TextBox1.Text &= String.Format("{0,-17}", DMSToDMSstr(mpoint(i).YL))
            TextBox1.Text &= String.Format("{0,-17:f4}", mpoint(i).BLTX(a, e2, CRad(L0)))
            TextBox1.Text &= String.Format("{0,-17:f4}", mpoint(i).BLTY(a, e2, CRad(L0)))
            TextBox1.Text &= vbCrLf
        Next
        TextBox1.Text &= vbCrLf
        TextBox1.Text &= "4.2:" & "公式（7）计算结果" & vbCrLf
        TextBox1.Text &= String.Format("α：{0}", mpoint(0).AidCal(a, e2)(0)) & vbCrLf
        TextBox1.Text &= String.Format("β：{0}", mpoint(0).AidCal(a, e2)(1)) & vbCrLf
        TextBox1.Text &= String.Format("γ：{0}", mpoint(0).AidCal(a, e2)(2)) & vbCrLf
        TextBox1.Text &= String.Format("δ：{0}", mpoint(0).AidCal(a, e2)(3)) & vbCrLf
        TextBox1.Text &= String.Format("ε：{0}", mpoint(0).AidCal(a, e2)(4)) & vbCrLf
        TextBox1.Text &= String.Format("ζ：{0}", mpoint(0).AidCal(a, e2)(5)) & vbCrLf

        TextBox1.Text &= vbCrLf
        TextBox1.Text &= "4.3:" & "公式（10）计算结果" & vbCrLf
        For i As Integer = 0 To mpoint.Length - 1
            TextBox1.Text &= String.Format("{0} a0:{1:f6} a1:{2:f6} a2:{3:f6} a3:{4:f6} a4:{5:f6} a5:{6:f6}{7}", mpoint(i).Name, mpoint(i).Aida(a, e2, mpoint(0).AidCal(a, e2))(0), mpoint(i).Aida(a, e2, mpoint(0).AidCal(a, e2))(1), mpoint(i).Aida(a, e2, mpoint(0).AidCal(a, e2))(2), mpoint(i).Aida(a, e2, mpoint(0).AidCal(a, e2))(3), mpoint(i).Aida(a, e2, mpoint(0).AidCal(a, e2))(4), mpoint(i).Aida(a, e2, mpoint(0).AidCal(a, e2))(5), vbCrLf)
        Next
        TextBox1.Text &= vbCrLf

        TextBox1.Text &= "5.1:" & "高斯反算（XY--BL）" & vbCrLf
        TextBox1.Text &= "--------------------------------------" & vbCrLf
        TextBox1.Text &= String.Format("{0,-5}    {1,-17}    {2,-17} {3,-14}{4,-14}{5}", "点名", "X", "Y", "B", "L", vbCrLf)
        For i As Integer = 0 To mpoint.Length - 1
            TextBox1.Text &= String.Format("{0,-5:f4}", mpoint(i).Name)
            TextBox1.Text &= String.Format("{0,-17}", mpoint(i).BLTX(a, e2, CRad(L0)))
            TextBox1.Text &= String.Format("{0,-17}", mpoint(i).BLTY(a, e2, CRad(L0)))
            TextBox1.Text &= String.Format("{0,-17:f4}", RadToDMSstr(mpoint(i).XYTB(mpoint(i).Aidb(mpoint(0).AidCal(a, e2), a, e2, L0, mpoint(i).BLTX(a, e2, CRad(L0))), L0, mpoint(i).BLTY(a, e2, CRad(L0)))))
            TextBox1.Text &= String.Format("{0,-17:f4}", RadToDMSstr(mpoint(i).XYTL(mpoint(i).Aidb(mpoint(0).AidCal(a, e2), a, e2, L0, mpoint(i).BLTX(a, e2, CRad(L0))), L0, mpoint(i).BLTY(a, e2, CRad(L0)))))
            TextBox1.Text &= vbCrLf
        Next

        TextBox1.Text &= vbCrLf
        TextBox1.Text &= "5.2:" & "公式（13）计算结果" & vbCrLf
        For i As Integer = 0 To mpoint.Length - 1
            TextBox1.Text &= String.Format("{0} a0:{1} a1:{2} a2:{3} a3:{4} a4:{5} a5:{6} a6:{7} {8}", mpoint(i).Name, mpoint(i).Aidb(mpoint(0).AidCal(a, e2), a, e2, L0, mpoint(i).BLTX(a, e2, CRad(L0)))(0), mpoint(i).Aidb(mpoint(0).AidCal(a, e2), a, e2, L0, mpoint(i).BLTX(a, e2, CRad(L0)))(1), mpoint(i).Aidb(mpoint(0).AidCal(a, e2), a, e2, L0, mpoint(i).BLTX(a, e2, CRad(L0)))(2), mpoint(i).Aidb(mpoint(0).AidCal(a, e2), a, e2, L0, mpoint(i).BLTX(a, e2, CRad(L0)))(3), mpoint(i).Aidb(mpoint(0).AidCal(a, e2), a, e2, L0, mpoint(i).BLTX(a, e2, CRad(L0)))(4), mpoint(i).Aidb(mpoint(0).AidCal(a, e2), a, e2, L0, mpoint(i).BLTX(a, e2, CRad(L0)))(5), mpoint(i).Aidb(mpoint(0).AidCal(a, e2), a, e2, L0, mpoint(i).BLTX(a, e2, CRad(L0)))(6), vbCrLf)
        Next
        ToolStripStatusLabel1.Text = "计算结束"



    End Sub


    Public Sub DrawPoint(a As Graphics, b As Pen, x As Integer, y As Integer)   '绘制点
        a.DrawLine(b, x - 5, y - 5, x + 5, y + 5)
        a.DrawLine(b, x + 5, y - 5, x - 5, y + 5)
    End Sub

    Public Sub DrawAxis(a As Graphics, b As Pen, c As SolidBrush, d As Font, x As Integer, y As Integer)  '绘制坐标轴
        a.DrawLine(b, 100, y, x, y)
        a.DrawLine(b, 100, 100, 100, y)
        For i As Integer = 0 To 5
            a.DrawLine(b, 100, CInt(100 + (y - 100) / 5 * i), 90, CInt(100 + (y - 100) / 5 * i))
            a.DrawString(CInt(YHeight() / 5 * i + YMin()), d, c, 0, CInt(100 + (y - 100) / 5 * i) - 5)
        Next
        For i As Integer = 0 To 9
            a.DrawLine(b, CInt(100 + (x - 100) / 9 * i), y, CInt(100 + (x - 100) / 9 * i), y + 10)
            a.DrawString(CInt(XWidth() / 5 * i + XMin()), d, c, CInt(100 + (x - 100) / 9 * i) - 20, y + 10)
        Next

    End Sub

    Public Sub DrawOut()    '绘图
        Dim DRAW_BITMAP As New Bitmap(PictureBox2.Width, PictureBox2.Height)
        Dim PenPoint As New Pen(Color.Red, 4)
        Dim PenAxis As New Pen(Color.Black, 2)
        Dim b As New SolidBrush(Color.Black)
        Dim f As New Font("宋体", 10)
        Using g As Graphics = Graphics.FromImage(DRAW_BITMAP)
            For i As Integer = 0 To mpoint.Length - 1
                DrawPoint(g, PenPoint, CInt((mpoint(i).X(a, e2) - XMin()) / XWidth() * (PictureBox2.Width - 200)) + 100, CInt((mpoint(i).Y(a, e2) - YMin()) / YHeight() * (PictureBox2.Height - 200)) + 100)
                g.DrawString(mpoint(i).Name, f, b, CInt((mpoint(i).X(a, e2) - XMin()) / XWidth() * (PictureBox2.Width - 200)) + 90, CInt((mpoint(i).Y(a, e2) - YMin()) / YHeight() * (PictureBox2.Height - 200)) + 80)
                DrawAxis(g, PenAxis, b, f, PictureBox2.Width - 50, PictureBox2.Height - 50)
            Next
            PictureBox2.Image = DRAW_BITMAP
        End Using

        PenPoint.Dispose()
        PenAxis.Dispose()

    End Sub

    Public Sub PutIN()    '手动输入数据存储
        a = Val(DataGridView1("2", 1).Value)
        mf = Val(DataGridView1("2", 2).Value)
        L0 = Val(DataGridView1("2", 3).Value)
        B = Val(DataGridView1("2", 4).Value)
        ReDim mpoint(dt.Rows.Count - 2)
        For i As Integer = 1 To dt.Rows.Count - 1
            mpoint(i - 1) = New mPoint With {
            .Name = DataGridView1("3", i).Value.ToString,
            .XB = Val(DataGridView1("4", i).Value),
            .YL = Val(DataGridView1("5", i).Value),
            .ZH = Val(DataGridView1("6", i).Value)
            }
        Next
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click   '计算

        If DataGridView1("2", 1).Value.ToString = "" Or DataGridView1("2", 2).Value.ToString = "" Or DataGridView1("2", 3).Value.ToString = "" Or DataGridView1("2", 4).Value.ToString = "" Then
            MsgBox("请在导入数据或输入完整后开始计算")
            Exit Sub
        End If
        For i = 1 To dt.Rows.Count - 2
            If DataGridView1("3", i).Value.ToString = "" Or DataGridView1("4", i).Value.ToString = "" Or DataGridView1("5", i).Value.ToString = "" Or DataGridView1("6", i).Value.ToString = "" Then
                MsgBox("请在导入数据或输入完整后开始计算")
                Exit Sub
            End If
        Next
        If DataStr.ToString = "" Then
            PutIN()
        End If

        EllipoidCalc()
        TabControl1.SelectedTab = TabPage3
        PrintOut()
        DrawOut()

    End Sub



    Function XMin() As Double  '坐标点x最小值
        Dim X(mpoint.Length - 1)
        For i As Integer = 0 To mpoint.Length - 1
            X(i) = mpoint(i).X(a, e2)
        Next
        Return X.Min
    End Function

    Function YMin() As Double '坐标点y最小值
        Dim Y(mpoint.Length - 1)
        For i As Integer = 0 To mpoint.Length - 1
            Y(i) = mpoint(i).Y(a, e2)
        Next
        Return Y.Min
    End Function

    Function XWidth() As Double '坐标点x最大间距
        Dim X(mpoint.Length - 1)
        For i As Integer = 0 To mpoint.Length - 1
            X(i) = mpoint(i).X(a, e2)
        Next
        Return X.Max - X.Min
    End Function

    Function YHeight() As Double '坐标点y最大间距
        Dim Y(mpoint.Length - 1)
        For i As Integer = 0 To mpoint.Length - 1
            Y(i) = mpoint(i).Y(a, e2)
        Next
        Return Y.Max - Y.Min
    End Function

    Private Sub 退出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub 帮助ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 帮助ToolStripMenuItem.Click
        MsgBox("参考状态栏提示")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click '手动输入添加行
        dt.Rows.Add()
        DataGridView1("3", dt.Rows.Count - 1).Style.BackColor = Color.Linen
        DataGridView1("4", dt.Rows.Count - 1).Style.BackColor = Color.LightYellow
        DataGridView1("5", dt.Rows.Count - 1).Style.BackColor = Color.LightYellow
        DataGridView1("6", dt.Rows.Count - 1).Style.BackColor = Color.LightYellow
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click '手动输入删除行
        If dt.Rows.Count > 5 Then
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        End If

    End Sub

    Sub SavePic()
        Dim SFD As New SaveFileDialog
        SFD.Filter = "BMP格式(*.bmp)|*.bmp"
        If SFD.ShowDialog = DialogResult.OK Then
            PictureBox2.Image.Save(SFD.FileName)
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

            For i As Integer = 0 To mpoint.Length - 1
                DXF_Point(mpoint(i).X(a, e2), mpoint(i).Y(a, e2))
                DXF_TEXT(mpoint(i).X(a, e2), mpoint(i).Y(a, e2), mpoint(i).Name)
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


    Private Sub 导出计算结果TXTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导出计算结果TXTToolStripMenuItem.Click
        CmputRst = TextBox1.Text
        OutputRsutFile(New SaveFileDialog)
    End Sub

    Private Sub 重新导入ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重新导入ToolStripMenuItem.Click
        Button1.PerformClick()
    End Sub

    Private Sub 计算ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 计算ToolStripMenuItem.Click
        Button3.PerformClick()
    End Sub

    Private Sub 退出程序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出程序ToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Button1.PerformClick()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        导出计算结果TXTToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        TabControl1.SelectedTab = TabPage3
    End Sub


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load   '程序初始化
        ToolStripStatusLabel1.Text = "单击导入按钮开始导入数据或在表格中输入数据"
        dt.Columns.Clear()
        dt.Rows.Clear()
        For i As Integer = 1 To 9
            dt.Columns.Add(New DataColumn(CStr(i)))
        Next
        DataGridView1.DataSource = dt
        dt.Rows.Add()
        DataGridView1("1", 0).Value = "椭圆参数名称"
        DataGridView1("2", 0).Value = "数值"
        DataGridView1("3", 0).Value = "点号"
        DataGridView1("4", 0).Value = "大地坐标经度B"
        DataGridView1("5", 0).Value = "大地坐标纬度L"
        DataGridView1("6", 0).Value = "大地坐标高H"
        DataGridView1("7", 0).Value = "空间坐标X"
        DataGridView1("8", 0).Value = "空间坐标Y"
        DataGridView1("9", 0).Value = "空间坐标Z"
        For i As Integer = 1 To 9
            DataGridView1(CStr(i), 0).Style.BackColor = Color.Linen
        Next
        dt.Rows.Add()
        dt.Rows.Add()
        dt.Rows.Add()
        dt.Rows.Add()
        DataGridView1("1", 1).Value = "a"
        DataGridView1("1", 2).Value = "mf"
        DataGridView1("1", 3).Value = "L0"
        DataGridView1("1", 4).Value = "B"
        For i As Integer = 1 To 4
            DataGridView1("1", i).Style.BackColor = Color.Linen
        Next
        For i As Integer = 1 To 4
            DataGridView1("2", i).Style.BackColor = Color.LightYellow
        Next
        For i As Integer = 1 To 4
            DataGridView1("3", i).Style.BackColor = Color.Linen
        Next
        For j As Integer = 4 To 6
            For i As Integer = 1 To 4
                DataGridView1(CStr(j), i).Style.BackColor = Color.LightYellow
            Next
        Next





    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click   '导入数据
        Call InputDataFile(New OpenFileDialog)
        If DataStream = Nothing Then
            MsgBox("导入失败")
            Exit Sub
        End If
        If (DataStr.Length - 9) Mod 4 = 0 Then
            TableLoad()
            a = Val(DataStr$(1))
            mf = Val(DataStr$(3))
            L0 = Val(DataStr$(5))
            B = Val(DataStr$(7))
            For i As Integer = 1 To 4
                dt.Rows.Add()
                DataGridView1("1", i).Value = DataStr$(2 * i - 2)
                If i = 3 Or i = 4 Then
                    DataGridView1("2", i).Value = DMSToDMSstr(Val(DataStr$(2 * i - 1)))
                Else
                    DataGridView1("2", i).Value = Val(DataStr$(2 * i - 1))
                End If
                DataGridView1("1", i).Style.BackColor = Color.Linen
                DataGridView1("2", i).Style.BackColor = Color.LightYellow
            Next
            ReDim mpoint((DataStr.Length - 9) / 4 - 1)
            For i As Integer = 1 To (DataStr.Length - 9) / 4
                If i > 4 Then
                    dt.Rows.Add()
                End If
                mpoint(i - 1) = New mPoint With {
                    .Name = DataStr$(5 + 4 * i),
                    .XB = Val(DataStr$(6 + 4 * i)),
                    .YL = Val(DataStr$(7 + 4 * i)),
                    .ZH = Val(DataStr$(8 + 4 * i))
                    }
                DataGridView1("3", i).Value = mpoint(i - 1).Name
                DataGridView1("4", i).Value = DMSToDMSstr(mpoint(i - 1).XB)
                DataGridView1("5", i).Value = DMSToDMSstr(mpoint(i - 1).YL)
                DataGridView1("6", i).Value = String.Format("{0:f4}", mpoint(i - 1).ZH)
                DataGridView1("3", i).Style.BackColor = Color.Linen
                DataGridView1("4", i).Style.BackColor = Color.LightYellow
                DataGridView1("5", i).Style.BackColor = Color.LightYellow
                DataGridView1("6", i).Style.BackColor = Color.LightYellow
            Next
            DataStream = Nothing
        Else MsgBox("数据文件格式错误")
            Exit Sub
        End If
        ToolStripStatusLabel1.Text = "数据导入成功，共" & (DataStr.Length - 9) / 4 & "个点，请检查无误后单击计算开始坐标转换"
    End Sub
End Class
