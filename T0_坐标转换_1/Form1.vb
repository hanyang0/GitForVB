Imports System.Math
Imports T0_坐标转换.AngConver
Public Class MainForm
    Dim mf, L0, B As Double
    Public a, f, e2, e02, W, n1, t, N, M, M0 As Double



    Dim dt As New DataTable
    Dim mpoint() As mPoint
    Public ModeSetName As String

    Public Sub TableLoad()
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

    Public Sub EllipoidCalc()
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

    Public Sub PrintOut()
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




        TextBox1.Text &= "2:" & ModeSetName & vbCrLf
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




        TextBox1.Text &= "3:" & ModeSetName & vbCrLf
        TextBox1.Text &= "--------------------------------------" & vbCrLf
        TextBox1.Text &= String.Format("{0,-5}   {1,-14} {2,-14}{3,-14}  {4,-17}   {5,-17}   {6,-8}{7}", "点名", "B", "L", "H", "X", "Y", "Z", vbCrLf)
        For i As Integer = 0 To mpoint.Length - 1
            TextBox1.Text &= String.Format("{0,-5:f4}", mpoint(i).Name)
            TextBox1.Text &= String.Format("{0,-14:f4}", mpoint(i).X(a, e2) + 2018)
            TextBox1.Text &= String.Format("{0,-14:f4}", mpoint(i).Y(a, e2) + 2018)
            TextBox1.Text &= String.Format("{0,-14:f4}", mpoint(i).Z(a, e2) + 2018)
            TextBox1.Text &= String.Format("{0,-17:f4}", RadToDMSstr(mpoint(i).B(a, e2)))
            TextBox1.Text &= String.Format("{0,-17:f4}", RadToDMSstr(mpoint(i).L(a, e2)))
            TextBox1.Text &= String.Format("{0,-8:f4}", mpoint(i).H(a, e2))
            TextBox1.Text &= vbCrLf
        Next
    End Sub

    Public Sub DrawPoint(a As Graphics, b As Pen, x As Integer, y As Integer)
        a.DrawLine(b, x - 5, y - 5, x + 5, y + 5)
        a.DrawLine(b, x + 5, y - 5, x - 5, y + 5)
    End Sub

    Public Sub DrawAxis(a As Graphics, b As Pen, c As SolidBrush, d As Font, x As Integer, y As Integer)
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

    Public Sub DrawOut()
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
        'PictureBox1.Refresh()
        'g.Dispose()
        PictureBox2.Image.Save("ckk.dxf")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If a = Nothing Then
            MsgBox("请在导入数据后再开始计算")
            Button1.PerformClick()
        Else
            EllipoidCalc()
            TabControl1.SelectedTab = TabPage2
            PrintOut()
            DrawOut()
        End If

    End Sub
    Function XMin() As Double
        Dim X(mpoint.Length - 1)
        For i As Integer = 0 To mpoint.Length - 1
            X(i) = mpoint(i).X(a, e2)
        Next
        Return X.Min
    End Function

    Function YMin() As Double
        Dim Y(mpoint.Length - 1)
        For i As Integer = 0 To mpoint.Length - 1
            Y(i) = mpoint(i).Y(a, e2)
        Next
        Return Y.Min
    End Function

    Function XWidth() As Double
        Dim X(mpoint.Length - 1)
        For i As Integer = 0 To mpoint.Length - 1
            X(i) = mpoint(i).X(a, e2)
        Next
        Return X.Max - X.Min
    End Function

    Function YHeight() As Double
        Dim Y(mpoint.Length - 1)
        For i As Integer = 0 To mpoint.Length - 1
            Y(i) = mpoint(i).Y(a, e2)
        Next
        Return Y.Max - Y.Min
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ToolStripStatusLabel1.Text = "请选择坐标转换模式"
        ModeSetName = "计算"
        ToolStripStatusLabel1.Text = "模式选择完成请单击导入按钮开始导入数据"
        ToolStripStatusLabel3.Text = ModeSetName & "模式"
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolStripStatusLabel1.Text = "单击导入按钮开始导入数据"


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
