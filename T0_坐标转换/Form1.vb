Imports System.Math
Imports T0_坐标转换_1.AngConver
Public Class MainForm
    Dim a, mf, L0, B As Double
    Dim f, e2, e02, W, n1, t, N, M, M0 As Double
    Dim dt As New DataTable
    Dim mpoint() As Point
    Public WithEvents ModeEvent1 As New ModeSetedEvent
    Public ModeSet As Integer
    Public ModeSetName As String

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

    Private Sub ModeEvent_ModeSeted2() Handles ModeEvent1.ModeSeted2
        dt.Columns.Clear()
        dt.Columns.Add(New DataColumn("椭圆参数名称"))
        dt.Columns.Add(New DataColumn("数值"))
        dt.Columns.Add(New DataColumn("点号"))
        dt.Columns.Add(New DataColumn("空间坐标X"))
        dt.Columns.Add(New DataColumn("空间坐标Y"))
        dt.Columns.Add(New DataColumn("空间坐标Z"))
        DataGridView1.DataSource = dt
        DataGridView1.Columns(0).HeaderText = "椭圆参数名称"
        DataGridView1.Columns(1).HeaderText = "数值"
        DataGridView1.Columns(2).HeaderText = "点号"
        DataGridView1.Columns(3).HeaderText = "空间坐标X"
        DataGridView1.Columns(4).HeaderText = "空间坐标Y"
        DataGridView1.Columns(5).HeaderText = "空间坐标Z"
    End Sub

    Private Sub ModeEvent_ModeSeted1() Handles ModeEvent1.ModeSeted1
        dt.Columns.Clear()
        dt.Columns.Add(New DataColumn("椭圆参数名称"))
        dt.Columns.Add(New DataColumn("数值"))
        dt.Columns.Add(New DataColumn("点号"))
        dt.Columns.Add(New DataColumn("大地坐标经度B"))
        dt.Columns.Add(New DataColumn("大地坐标纬度L"))
        dt.Columns.Add(New DataColumn("大地坐标高H"))
        DataGridView1.DataSource = dt
        DataGridView1.Columns(0).HeaderText = "椭圆参数名称"
        DataGridView1.Columns(1).HeaderText = "数值"
        DataGridView1.Columns(2).HeaderText = "点号"
        DataGridView1.Columns(3).HeaderText = "大地坐标经度B"
        DataGridView1.Columns(4).HeaderText = "大地坐标纬度L"
        DataGridView1.Columns(5).HeaderText = "大地坐标高H"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If a = Nothing Then
            MsgBox("请在导入数据后再开始计算")
            Button1.PerformClick()
        Else
            EllipoidCalc()
            'TabControl1.SelectedTab = TabPage3
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
            TextBox1.Text &= "点名            B            L            H            X            Y            Z" & vbCrLf
            For i As Integer = 0 To mpoint.Length - 1
                TextBox1.Text &= String.Format("{0:f4}          ", mpoint(i).Name)
                TextBox1.Text &= String.Format("{0:f4}      ", mpoint(i).YB)
                TextBox1.Text &= String.Format("{0:f4}    ", mpoint(i).XL)
                TextBox1.Text &= String.Format("{0:f4}    ", mpoint(i).ZH)
                TextBox1.Text &= String.Format("{0:f4}  ", mpoint(i).X(N))
                TextBox1.Text &= String.Format("{0:f4}  ", mpoint(i).Y(N))
                TextBox1.Text &= String.Format("{0:f4}  ", mpoint(i).Z(N, e2))
                TextBox1.Text &= vbCrLf
            Next
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ToolStripStatusLabel1.Text = "请选择坐标转换模式"
        'Form2.Show()
        ModeSet = 1
        ModeSetName = "计算"
        ToolStripStatusLabel1.Text = "模式选择完成请单击导入按钮开始导入数据"
        ToolStripStatusLabel3.Text = ModeSetName & "模式"
        ModeEvent1.StartEvent()
        Form2.ListBox1.Items.Clear()
        Form2.ListBox1.Items.Add("大地坐标（BLH）转换为空间坐标（XYZ）")
        Form2.ListBox1.Items.Add("空间坐标（XYZ）转换为大地坐标（BLH）")
        Form2.ListBox1.Items.Add("高斯正算计算")
        Form2.ListBox1.Items.Add("高斯投影反算")
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolStripStatusLabel1.Text = "单击模式选择按钮选择坐标转换模式"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ModeSet = Nothing Then
            MsgBox("请先选择坐标转换模式")
            Button2.PerformClick()
            Exit Sub
        End If
        Call InputDataFile(New OpenFileDialog)
        If DataStream = Nothing Then
            Exit Sub
        End If
        If (DataStr.Length - 9) Mod 4 = 0 Then
            dt.Clear()
            a = Val(DataStr$(1))
            mf = Val(DataStr$(3))
            L0 = Val(DataStr$(5))
            B = Val(DataStr$(7))
            For i As Integer = 1 To 4
                dt.Rows.Add()
                DataGridView1("椭圆参数名称", i - 1).Value = DataStr$(2 * i - 2)
                If i = 3 Or i = 4 Then
                    DataGridView1("数值", i - 1).Value = DMSToDMSstr(Val(DataStr$(2 * i - 1)))
                Else
                    DataGridView1("数值", i - 1).Value = Val(DataStr$(2 * i - 1))
                End If
                DataGridView1("椭圆参数名称", i - 1).Style.BackColor = Color.Linen
                DataGridView1("数值", i - 1).Style.BackColor = Color.LightYellow
            Next
            ReDim mpoint((DataStr.Length - 9) / 4 - 1)
            For i As Integer = 1 To (DataStr.Length - 9) / 4
                If i > 4 Then
                    dt.Rows.Add()
                End If
                mpoint(i - 1) = New Point With {
                    .Name = DataStr$(5 + 4 * i),
                    .YB = Val(DataStr$(6 + 4 * i)),
                    .XL = Val(DataStr$(7 + 4 * i)),
                    .ZH = Val(DataStr$(8 + 4 * i))
                    }
                DataGridView1("点号", i - 1).Value = mpoint(i - 1).Name
                DataGridView1("大地坐标经度B", i - 1).Value = DMSToDMSstr(mpoint(i - 1).YB)
                DataGridView1("大地坐标纬度L", i - 1).Value = DMSToDMSstr(mpoint(i - 1).XL)
                DataGridView1("大地坐标高H", i - 1).Value = String.Format("{0:f4}", mpoint(i - 1).ZH)
                DataGridView1("点号", i - 1).Style.BackColor = Color.Linen
                DataGridView1("大地坐标经度B", i - 1).Style.BackColor = Color.LightYellow
                DataGridView1("大地坐标纬度L", i - 1).Style.BackColor = Color.LightYellow
                DataGridView1("大地坐标高H", i - 1).Style.BackColor = Color.LightYellow
            Next
        Else MsgBox("数据文件格式错误")
            Exit Sub
        End If
        ToolStripStatusLabel1.Text = "数据导入成功，共" & (DataStr.Length - 9) / 4 & "个点，请检查无误后单击计算开始坐标转换"
    End Sub
End Class

'-		DataStr	{Length=29}	String()
'		(0)	"a"	String
'		(1)	"6378140.000"	String
'		(2)	"1/f"	String
'		(3)	"298.257"	String
'		(4)	"L0"	String
'		(5)	"93.00"	String
'		(6)	"B"	String
'		(7)	"36.59482249"	String
'		(8)	""	String
'		(9)	"Q52"	String
'		(10)	"39.20626102"	String
'		(11)	"100.77798392"	String
'		(12)	"76.246"	String
'		(13)	"A36"	String
'		(14)	"36.56609010"	String
'		(15)	"101.28743549"	String
'		(16)	"72.874"	String
'		(17)	"P09"	String
'		(18)	"41.52652310"	String
'		(19)	"100.09809531"	String
'		(20)	"69.501"	String
'		(21)	"Q60"	String
'		(22)	"42.43293847"	String
'		(23)	"101.83848587"	String
'		(24)	"62.738"	String
'		(25)	"P69"	String
'		(26)	"40.38246672"	String
'		(27)	"100.42994053"	String
'		(28)	"66.994"	String
'		DataStream  "a,6378140.000,1/f,298.257,L0,93.00,B,36.59482249,,Q52,39.20626102,100.77798392,76.246,A36,36.56609010,101.28743549,72.874,P09,41.52652310,100.09809531,69.501,Q60,42.43293847,101.83848587,62.738,P69,40.38246672,100.42994053,66.994"	String
'+		OpenFile	{System.Windows.Forms.OpenFileDialog: Title :  , FileName: C : \Users\hanya\OneDrive - stu.ncwu.edu.cn\桌面\竞赛相关文件\Survey-And-Mapping-Contest-master\0.国赛样题-坐标转换\附件2-样例数据（坐标转换）.txt}	System.Windows.Forms.OpenFileDialog
