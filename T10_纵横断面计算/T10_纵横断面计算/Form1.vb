Imports System.Math
Public Class Form1
    Dim dt As New DataTable
    Dim H0 As Double
    Dim K0, K1, K2 As String
    Dim Points() As Point
    Dim i, j As Integer
    Dim PointNum As Integer
    Dim D, D0, D1 As Double
    Dim MainPoint(2) As Point
    Dim MidPoint(1, 1) As Double
    Dim CalMainPoints() As CalMainPoint
    Dim InterPointP() As CalMainPoint
    Dim InterPointQ() As CalMainPoint
    Dim InterPointNum As Integer
    Dim SectAreaTotalValue As Double
    Dim CrossSectAreaTotalValueP As Double
    Dim CrossSectAreaTotalValueQ As Double
    Dim PrintTextValue As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataStr IsNot Nothing Then
            SelectMainPoint()
            SectLong()
            CalInterCoor()
            SectAreaTotal()
            CalMidPoint()
            CalInterPointCoor()
            CalCrossArea()
            PrintText()
            TabControl1.SelectedTab = TabPage3
        Else
            MsgBox("请导入数据后开始计算")
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolStripStatusLabel1.Text = "单击导入按钮开始导入数据或在表格中输入数据"
        dt.Columns.Clear()
        dt.Rows.Clear()
        For i As Integer = 1 To 8
            dt.Columns.Add(New DataColumn(CStr(i)))
        Next
        DataGridView1.DataSource = dt
        dt.Rows.Add()
        DataGridView1("1", 0).Value = "参考面高程"
        DataGridView1("2", 0).Value = "高程值"
        DataGridView1("3", 0).Value = "关键点"
        DataGridView1("4", 0).Value = "点号"
        DataGridView1("5", 0).Value = "X分量"
        DataGridView1("6", 0).Value = "Y分量"
        DataGridView1("7", 0).Value = "高程H"
        DataGridView1("8", 0).Value = "关键点"
        For i As Integer = 1 To 8
            DataGridView1(CStr(i), 0).Style.BackColor = Color.Linen
        Next
        dt.Rows.Add()
        dt.Rows.Add()
        dt.Rows.Add()
        DataGridView1("1", 1).Value = "H0"
        DataGridView1("1", 1).Style.BackColor = Color.Linen
        DataGridView1("2", 1).Style.BackColor = Color.LightYellow
        For i As Integer = 1 To 3
            DataGridView1("3", i).Style.BackColor = Color.Linen
        Next
        For j As Integer = 4 To 8
            For i As Integer = 1 To 3
                DataGridView1(CStr(j), i).Style.BackColor = Color.LightYellow
            Next
        Next
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call InputDataFile(New OpenFileDialog)
        If DataStream = Nothing Then
            MsgBox("导入失败")
            Exit Sub
        End If
        PointNum = (DataStr.Length - 6) / 4
        ReDim Points(PointNum - 1)
        H0 = Val(DataStr$(1))
        K0 = DataStr$(2)
        K1 = DataStr$(3)
        K2 = DataStr$(4)
        For i = 0 To PointNum - 1
            Points(i) = New Point
            Points(i).Name = DataStr(4 * i + 6)
            If Points(i).Name = K0 Or Points(i).Name = K1 Or Points(i).Name = K2 Then
                Points(i).IsMianPoint = True
            End If
            Points(i).CoorX = Val(DataStr$(4 * i + 7))
            Points(i).CoorY = Val(DataStr$(4 * i + 8))
            Points(i).CoorH = Val(DataStr$(4 * i + 9))
        Next
        PutTable()
        ToolStripStatusLabel1.Text = "导入完成，点击计算按钮生成报告"
    End Sub

    Sub PutTable()
        DataGridView1("2", 1).Value = H0
        DataGridView1("3", 1).Value = K0
        DataGridView1("3", 2).Value = K1
        DataGridView1("3", 3).Value = K2
        For i = 0 To PointNum - 1
            If i > 2 Then
                dt.Rows.Add()
            End If
            DataGridView1("4", i + 1).Value = Points(i).Name
            DataGridView1("5", i + 1).Value = Val(Points(i).CoorX)
            DataGridView1("6", i + 1).Value = Val(Points(i).CoorY)
            DataGridView1("7", i + 1).Value = Val(Points(i).CoorH)
            If Points(i).IsMianPoint Then
                DataGridView1("8", i + 1).Value = "是"
            Else
                DataGridView1("8", i + 1).Value = "否"
            End If
            For j = 4 To 8
                DataGridView1(CStr(j), i + 1).Style.BackColor = Color.LightYellow
            Next
        Next
    End Sub

    Sub SelectMainPoint()
        For j = 0 To 2
            MainPoint(j) = New Point
        Next
        For i = 0 To PointNum - 1
            If Points(i).IsMianPoint Then
                For j = 0 To 2
                    If MainPoint(j).Name = Nothing Then
                        MainPoint(j) = Points(i)
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub

    Function InterPoint(IbterX As Double, InterY As Double) As Double
        Dim Dist(PointNum - 1) As Double
        Dim MinDistPoint(4, 1) As Double
        Dim h_d As Double = 0
        Dim _d As Double = 0
        For i = 0 To PointNum - 1
            Dist(i) = Sqrt((Points(i).CoorX - IbterX) ^ 2 + (Points(i).CoorY - InterY) ^ 2)
        Next
        For i = 0 To 4
            MinDistPoint(i, 0) = Dist.Min
            MinDistPoint(i, 1) = Points(Array.IndexOf(Dist, Dist.Min)).CoorH
            Dist(Array.IndexOf(Dist, Dist.Min)) = Dist.Max
        Next
        For i = 0 To 4
            h_d += MinDistPoint(i, 1) / MinDistPoint(i, 0)
            _d += 1 / MinDistPoint(i, 0)
        Next
        Return h_d / _d

    End Function

    Function SectArea(h1 As Double, h2 As Double, dL As Double) As Double
        Return (h1 + h2 - 2 * H0) * dL / 2
    End Function

    Sub SectLong()
        D0 = Sqrt((MainPoint(0).CoorX - MainPoint(1).CoorX) ^ 2 + (MainPoint(0).CoorY - MainPoint(1).CoorY) ^ 2)
        D1 = Sqrt((MainPoint(1).CoorX - MainPoint(2).CoorX) ^ 2 + (MainPoint(1).CoorY - MainPoint(2).CoorY) ^ 2)
        D = D0 + D1
    End Sub

    Sub CalInterCoor()
        InterPointNum = Int(D / 10)
        ReDim CalMainPoints(InterPointNum + 2)
        For i = 0 To InterPointNum + 2
            CalMainPoints(i) = New CalMainPoint
        Next

        CalMainPoints(0).CoorX = MainPoint(0).CoorX
        CalMainPoints(0).CoorY = MainPoint(0).CoorY
        CalMainPoints(0).CoorH = MainPoint(0).CoorH
        CalMainPoints(0).Name = MainPoint(0).Name
        CalMainPoints(0).Dist = 0
        For j = 1 To Int(D0 / 10)
            CalMainPoints(j).Name = "V-" + CStr(j)
            CalMainPoints(j).Dist = 10 * j
            CalMainPoints(j).CoorX = MainPoint(0).CoorX + 10 * (j) * Cos(Azimuth(MainPoint(0).CoorX, MainPoint(0).CoorY, MainPoint(1).CoorX, MainPoint(1).CoorY))
            CalMainPoints(j).CoorY = MainPoint(0).CoorY + 10 * (j) * Sin(Azimuth(MainPoint(0).CoorX, MainPoint(0).CoorY, MainPoint(1).CoorX, MainPoint(1).CoorY))
            CalMainPoints(j).CoorH = InterPoint(CalMainPoints(j).CoorX, CalMainPoints(j).CoorY)
        Next

        CalMainPoints(Int(D0 / 10) + 1).CoorX = MainPoint(1).CoorX
        CalMainPoints(Int(D0 / 10) + 1).CoorY = MainPoint(1).CoorY
        CalMainPoints(Int(D0 / 10) + 1).CoorH = MainPoint(1).CoorH
        CalMainPoints(Int(D0 / 10) + 1).Name = MainPoint(1).Name
        CalMainPoints(Int(D0 / 10) + 1).Dist = D0
        For j = Int(D0 / 10) + 2 To InterPointNum + 1

            CalMainPoints(j).Dist = 10 * j - 10
            CalMainPoints(j).Name = "V-" + CStr(j - 1)
            CalMainPoints(j).CoorX = MainPoint(1).CoorX + (10 * (j - 1) - D0) * Cos(Azimuth(MainPoint(1).CoorX, MainPoint(1).CoorY, MainPoint(2).CoorX, MainPoint(2).CoorY))
            CalMainPoints(j).CoorY = MainPoint(1).CoorY + (10 * (j - 1) - D0) * Sin(Azimuth(MainPoint(1).CoorX, MainPoint(1).CoorY, MainPoint(2).CoorX, MainPoint(2).CoorY))
            CalMainPoints(j).CoorH = InterPoint(CalMainPoints(j).CoorX, CalMainPoints(j).CoorY)
        Next

        CalMainPoints(InterPointNum + 2).CoorX = MainPoint(2).CoorX
        CalMainPoints(InterPointNum + 2).CoorY = MainPoint(2).CoorY
        CalMainPoints(InterPointNum + 2).CoorH = MainPoint(2).CoorH
        CalMainPoints(InterPointNum + 2).Name = MainPoint(2).Name
        CalMainPoints(InterPointNum + 2).Dist = D

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text <> Nothing Then
            Clipboard.SetText(PrintTextValue)
            MsgBox("数据报告已复制到剪切板中")
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text <> Nothing Then
            CmputRst = TextBox1.Text
            OutputRsutFile(New SaveFileDialog)
            MsgBox("数据报告保存完成")
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Button1.PerformClick()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Button4.PerformClick()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Button2.PerformClick()
    End Sub

    Private Sub 导入数据ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导入数据ToolStripMenuItem.Click
        Button1.PerformClick()
    End Sub

    Private Sub 导出报告ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导出报告ToolStripMenuItem.Click
        Button4.PerformClick()
    End Sub

    Private Sub 一键计算ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 一键计算ToolStripMenuItem.Click
        Button2.PerformClick()
    End Sub

    Sub SectAreaTotal()
        SectAreaTotalValue = 0
        For i = 0 To InterPointNum + 1
            SectAreaTotalValue += SectArea(CalMainPoints(i).CoorH, CalMainPoints(i + 1).CoorH, CalMainPoints(i + 1).Dist - CalMainPoints(i).Dist)
        Next
    End Sub

    Sub CalMidPoint()
        MidPoint(0, 0) = (MainPoint(0).CoorX + MainPoint(1).CoorX) / 2
        MidPoint(0, 1) = (MainPoint(0).CoorY + MainPoint(1).CoorY) / 2
        MidPoint(1, 0) = (MainPoint(1).CoorX + MainPoint(2).CoorX) / 2
        MidPoint(1, 1) = (MainPoint(1).CoorY + MainPoint(2).CoorY) / 2
    End Sub

    Sub CalInterPointCoor()
        Dim A_M, A_N As Double
        A_M = Azimuth(MainPoint(0).CoorX, MainPoint(0).CoorY, MainPoint(1).CoorX, MainPoint(1).CoorY) + PI / 2
        A_N = Azimuth(MainPoint(1).CoorX, MainPoint(1).CoorY, MainPoint(2).CoorX, MainPoint(2).CoorY) + PI / 2
        ReDim InterPointP(10), InterPointQ(10)
        For i = 0 To 10
            InterPointP(i) = New CalMainPoint
            InterPointQ(i) = New CalMainPoint

        Next
        For j = 0 To 10
            If j = 5 Then
                InterPointP(j).Name = "M1"
                InterPointQ(j).Name = "M2"
            ElseIf j < 5 Then
                InterPointP(j).Name = "C-" + CStr(5 - j)
                InterPointQ(j).Name = "C-" + CStr(5 - j)
            ElseIf j > 5 Then
                InterPointP(j).Name = "C" + CStr(j - 5)
                InterPointQ(j).Name = "C" + CStr(j - 5)
            End If

            InterPointP(j).CoorX = MidPoint(0, 0) - (j - 5) * 5 * Cos(A_M)
            InterPointP(j).CoorY = MidPoint(0, 1) - (j - 5) * 5 * Sin(A_M)
            InterPointP(j).CoorH = InterPoint(InterPointP(j).CoorX, InterPointP(j).CoorY)
            InterPointP(j).Dist = j * 5
            InterPointQ(j).CoorX = MidPoint(1, 0) - (j - 5) * 5 * Cos(A_N)
            InterPointQ(j).CoorY = MidPoint(1, 1) - (j - 5) * 5 * Sin(A_N)
            InterPointQ(j).CoorH = InterPoint(InterPointQ(j).CoorX, InterPointQ(j).CoorY)
            InterPointP(j).Dist = j * 5
        Next

    End Sub

    Sub CalCrossArea()
        For i = 0 To 9
            CrossSectAreaTotalValueP += SectArea(InterPointP(i).CoorH, InterPointP(i + 1).CoorH, 5)
            CrossSectAreaTotalValueQ += SectArea(InterPointQ(i).CoorH, InterPointQ(i + 1).CoorH, 5)
        Next
    End Sub

    Sub PrintText()
        PrintTextValue = "纵横断面计算报告" & vbCrLf & vbCrLf & vbCrLf
        PrintTextValue += "纵断面信息" & vbCrLf
        PrintTextValue += "- - - - - - - - - - - - - - - - - - - - - - - - - - -" & vbCrLf
        PrintTextValue += String.Format("纵断面面积：{0:f3}", SectAreaTotalValue) & vbCrLf
        PrintTextValue += String.Format("纵断面全长：{0:f3}", D) & vbCrLf
        PrintTextValue += "线路主点:" + vbCrLf
        PrintTextValue += String.Format("{0,-14}{1,-14}{2,-14}{3,-14}{4,-14}{5}", "点名", "里程K(m)", "X坐标(m)", "Y坐标(m)", "H坐标(m)", vbCrLf)
        For i = 0 To 10
            PrintTextValue += String.Format("{0,-16}", CalMainPoints(i).Name)
            PrintTextValue += String.Format("{0,-16:f3}", CalMainPoints(i).Dist)
            PrintTextValue += String.Format("{0,-16:f3}", CalMainPoints(i).CoorX)
            PrintTextValue += String.Format("{0,-16:f3}", CalMainPoints(i).CoorY)
            PrintTextValue += String.Format("{0,-16:f3}", CalMainPoints(i).CoorH)
            PrintTextValue += vbCrLf + vbCrLf
        Next

        PrintTextValue += "横断面信息" & vbCrLf
        PrintTextValue += "- - - - - - - - - - - - - - - - - - - - - - - - - - -" & vbCrLf
        PrintTextValue += "横断面：1" & vbCrLf
        PrintTextValue += "- - - - - - - - - - - - - - - " & vbCrLf
        PrintTextValue += String.Format("横断面面积：{0:f3}", CrossSectAreaTotalValueP) & vbCrLf
        PrintTextValue += String.Format("横断面全长：{0}", 50) & vbCrLf
        PrintTextValue += "线路主点:" + vbCrLf
        PrintTextValue += String.Format("{0,-14}{1,-14}{2,-14}{3,-14}{4,-14}{5}", "点名", "里程K(m)", "X坐标(m)", "Y坐标(m)", "H坐标(m)", vbCrLf)
        For i = 0 To 10
            PrintTextValue += String.Format("{0,-16}", InterPointP(i).Name)
            PrintTextValue += String.Format("{0,-16:f3}", InterPointP(i).Dist)
            PrintTextValue += String.Format("{0,-16:f3}", InterPointP(i).CoorX)
            PrintTextValue += String.Format("{0,-16:f3}", InterPointP(i).CoorY)
            PrintTextValue += String.Format("{0,-16:f3}", InterPointP(i).CoorH)
            PrintTextValue += vbCrLf + vbCrLf
        Next
        PrintTextValue += "横断面：2" & vbCrLf
        PrintTextValue += "- - - - - - - - - - - - - - - " & vbCrLf
        PrintTextValue += String.Format("横断面面积：{0:f3}", CrossSectAreaTotalValueQ) & vbCrLf
        PrintTextValue += String.Format("横断面全长：{0}", 50) & vbCrLf
        PrintTextValue += "线路主点:" + vbCrLf
        PrintTextValue += String.Format("{0,-14}{1,-14}{2,-14}{3,-14}{4,-14}{5}", "点名", "里程K(m)", "X坐标(m)", "Y坐标(m)", "H坐标(m)", vbCrLf)
        For i = 0 To InterPointNum + 2
            PrintTextValue += String.Format("{0,-16}", InterPointQ(i).Name)
            PrintTextValue += String.Format("{0,-16:f3}", InterPointQ(i).Dist)
            PrintTextValue += String.Format("{0,-16:f3}", InterPointQ(i).CoorX)
            PrintTextValue += String.Format("{0,-16:f3}", InterPointQ(i).CoorY)
            PrintTextValue += String.Format("{0,-16:f3}", InterPointQ(i).CoorH)
            PrintTextValue += vbCrLf + vbCrLf
        Next
        TextBox1.Text = PrintTextValue
    End Sub



End Class

