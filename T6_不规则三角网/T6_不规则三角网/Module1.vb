Imports System.IO
Imports System.Math
Imports T6_不规则三角网

Module Module1
    '输入输出变量
    Public DataStream As String
    Public DataStr() As String
    Public CmputRes As String
    '离散点集合
    Public TinDatas() As TinData
    'T1
    Public Tri1 As New List(Of Tin1)
    'T2
    Public Sid1 As New List(Of Side)
    '四个顶点
    Dim P1, P2, P3, P4 As New TinData
    '循环用变量
    Dim i, j As Integer
    '基准高程
    Public H0 As Double = 9
    '各个体积
    Public V As New List(Of Double)
    '总体积
    Public VV As Double
    '外接圆结构
    Structure Circle
        Dim R As Double
        Dim X As Double
        Dim Y As Double
    End Structure
    '离散点结构
    Structure TinData
        Dim Name As String
        Dim X, Y, H As Double
    End Structure
    'T1存储结构
    Structure Tin1
        Dim P1, P2, P3 As TinData
    End Structure
    '边的存储结构
    Structure Side
        Dim P1, P2 As TinData
    End Structure
    '打开数据文件并存入变量
    Public Sub InputDataFile(OpenFile As OpenFileDialog)
        OpenFile.Filter = "Text File|*.txt|All Files|*.*"
        OpenFile.FilterIndex = 0
        If OpenFile.ShowDialog = DialogResult.OK Then
            Try
                Dim StrmR As New System.IO.StreamReader(OpenFile.FileName)
                DataStream = StrmR.ReadToEnd
                StrmR.Close()
                DataStream = DataStream.Replace(vbCrLf, ",")
                DataStream = DataStream.Trim(",")
                DataStr = DataStream.Split(",")
                ReDim Preserve TinDatas(DataStr.Length / 4 - 1)
                For i = 0 To TinDatas.Length - 1
                    TinDatas(i).Name = DataStr(4 * i)
                    TinDatas(i).X = DataStr(4 * i + 1)
                    TinDatas(i).Y = DataStr(4 * i + 2)
                    TinDatas(i).H = DataStr(4 * i + 3)
                Next
            Catch ex As Exception
                MsgBox("导入数据失败，请检查数据文件后重试", 64, "提示")
            End Try
        Else
            MsgBox("未选择文件"， 64, "提示")
            Exit Sub
        End If
    End Sub
    '文本导出为txt
    Public Sub OutputRstuFile(SaveFile As SaveFileDialog)
        SaveFile.Filter = "Text Lile|*.txt|All Files|*.*"
        SaveFile.FilterIndex = 0
        If SaveFile.ShowDialog = DialogResult.OK Then
            Dim StrmW As New System.IO.StreamWriter(SaveFile.OpenFile())
            StrmW.Write(CmputRes)
            StrmW.Close()
        Else
            MsgBox("未保存", 64, "提示")
            Exit Sub
        End If
    End Sub
    '数据绑定到DataGridView
    Public Function DataGrid1(ByVal Data() As TinData)
        Dim Dt As New DataTable
        For i = 0 To 3
            Dt.Columns.Add()
        Next
        Dt.Columns(0).ColumnName = "点名"
        Dt.Columns(1).ColumnName = "X坐标"
        Dt.Columns(2).ColumnName = "Y坐标"
        Dt.Columns(3).ColumnName = "H"
        For i = 0 To TinDatas.Length - 1
            Dt.Rows.Add()
            Dt(i)(0) = Data(i).Name
            Dt(i)(1) = Data(i).X
            Dt(i)(2) = Data(i).Y
            Dt(i)(3) = Data(i).H
        Next
        Return Dt
    End Function
    '寻找最值点坐标
    Function Xmax()
        Dim X(TinDatas.Length - 1) As Double
        For i = 0 To TinDatas.Length - 1
            X(i) = TinDatas(i).X
        Next
        Return X.Max
    End Function
    Function Xmin()
        Dim X(TinDatas.Length - 1) As Double
        For i = 0 To TinDatas.Length - 1
            X(i) = TinDatas(i).X
        Next
        Return X.Min
    End Function
    Function Ymax()
        Dim Y(TinDatas.Length - 1) As Double
        For i = 0 To TinDatas.Length - 1
            Y(i) = TinDatas(i).Y
        Next
        Return Y.Max
    End Function
    Function Ymin()
        Dim Y(TinDatas.Length - 1) As Double
        For i = 0 To TinDatas.Length - 1
            Y(i) = TinDatas(i).Y
        Next
        Return Y.Min
    End Function
    Function XWidth() As Double '坐标点x最大间距
        Dim X(TinDatas.Length - 1)
        For i As Integer = 0 To TinDatas.Length - 1
            X(i) = TinDatas(i).X
        Next
        Return X.Max - X.Min
    End Function
    Function YHeight() As Double '坐标点y最大间距
        Dim Y(TinDatas.Length - 1)
        For i As Integer = 0 To TinDatas.Length - 1
            Y(i) = TinDatas(i).Y
        Next
        Return Y.Max - Y.Min
    End Function
    '记录四角坐标并将形成的三角形加入T1
    Sub LoadTin()
        Dim X_max, X_min, Y_max, Y_min As Double
        X_min = Xmin()
        X_max = Xmax()
        Y_min = Ymin()
        Y_max = Ymax()
        P1.Name = "P1"
        P1.X = X_min - 1
        P1.Y = Y_min - 1
        P2.Name = "P2"
        P2.X = X_min - 1
        P2.Y = Y_max + 1
        P3.Name = "P3"
        P3.X = X_max + 1
        P3.Y = Y_max + 1
        P4.Name = "P4"
        P4.X = X_max + 1
        P4.Y = Y_min - 1
        Dim T1, T2 As New Tin1
        T1.P1 = P1
        T1.P2 = P2
        T1.P3 = P3
        T2.P1 = P1
        T2.P2 = P3
        T2.P3 = P4
        Tri1.Add(T1)
        Tri1.Add(T2)
    End Sub
    '检查离散点是否在外接圆内
    Function Circum(ByVal P As TinData, ByVal T As Tin1) As Boolean
        Dim Check As Boolean
        Dim C As New Circle
        C = Circle_P(T)
        If Distance(P.X, P.Y, C.X, C.Y) < C.R Then
            Check = True
        Else Check = False
        End If
        Return Check
    End Function
    '计算两点坐标
    Function Distance(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double) As Double
        Distance = Sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2)
    End Function
    '计算三角形外接圆圆心及坐标
    Function Circle_P(ByVal triangle1 As Tin1) As Circle
        Dim Circle1 As New Circle
        Circle1.X = ((triangle1.P2.Y - triangle1.P1.Y) * (triangle1.P3.Y ^ 2 - triangle1.P1.Y ^ 2 + triangle1.P3.X ^ 2 - triangle1.P1.X ^ 2) - (triangle1.P3.Y - triangle1.P1.Y) * (triangle1.P2.Y ^ 2 - triangle1.P1.Y ^ 2 + triangle1.P2.X ^ 2 - triangle1.P1.X ^ 2)) /
            (2 * (triangle1.P3.X - triangle1.P1.X) * (triangle1.P2.Y - triangle1.P1.Y) - 2 * (triangle1.P2.X - triangle1.P1.X) * (triangle1.P3.Y - triangle1.P1.Y))
        Circle1.Y = ((triangle1.P2.X - triangle1.P1.X) * (triangle1.P3.X ^ 2 - triangle1.P1.X ^ 2 + triangle1.P3.Y ^ 2 - triangle1.P1.Y ^ 2) - (triangle1.P3.X - triangle1.P1.X) * (triangle1.P2.X ^ 2 - triangle1.P1.X ^ 2 + triangle1.P2.Y ^ 2 - triangle1.P1.Y ^ 2)) /
            (2 * (triangle1.P3.Y - triangle1.P1.Y) * (triangle1.P2.X - triangle1.P1.X) - 2 * (triangle1.P2.Y - triangle1.P1.Y) * (triangle1.P3.X - triangle1.P1.X))
        Circle1.R = Sqrt((Circle1.X - triangle1.P1.X) ^ 2 + (Circle1.Y - triangle1.P1.Y) ^ 2)
        Return Circle1
    End Function
    '计算不规则格网过程
    Sub Run()
        Tri1.Clear()
        LoadTin() 'P1,P2,P3,P4及其构成的三角形
        Dim Tri2 As New List(Of Tin1) 'T1中需要剪切的三角形列表
        Dim Side2 As New List(Of Side)
        Dim Side3 As New List(Of Side)
        Dim Side4 As New List(Of Side) '重复边
        For i = 0 To TinDatas.Length - 1
            For j = 0 To Tri1.Count - 1
                If Circum(TinDatas(i), Tri1(j)) Then
                    Tri2.Add(Tri1(j)) '加入待剪切列表
                End If
            Next
            For Each t As Tin1 In Tri2
                Tri1.Remove(t) '从T1中剪切
                Dim s1, s2, s3 As New Side
                s1.P1 = t.P1
                s1.P2 = t.P2
                s2.P1 = t.P1
                s2.P2 = t.P3
                s3.P1 = t.P2
                s3.P2 = t.P3
                Side2.Add(s1)
                Side2.Add(s2)
                Side2.Add(s3) '边加入边列表
            Next
            For Each s1 As Side In Side2
                If Side3.Count = 0 Then
                    Side3.Add(s1)
                Else
                    If CheckHave(s1, Side3) Then   '检查边是否重复
                        Side4.Add(s1)
                    Else
                        Side3.Add(s1)
                    End If
                End If
            Next
            For Each s As Side In Side4 'side4重复边，在side中删除重复边
                Dim re_s As New Side
                re_s.P2 = s.P1
                re_s.P1 = s.P2
                Side3.Remove(re_s)
                Side3.Remove(s)
            Next
            For Each s As Side In Side3 '将边传到side1结果边
                Sid1.Add(s)
            Next
            Side2.Clear()
            Side3.Clear()
            Side4.Clear()
            Tri2.Clear()
            For Each ss1 As Side In Sid1 '将离散点与各个边组成三角形，加入T1
                Dim t As New Tin1
                t.P1 = TinDatas(i)
                t.P2 = ss1.P2
                t.P3 = ss1.P1
                Tri1.Add(t)
            Next
            Sid1.Clear()
        Next
        Dim t3 As New List(Of Tin1) '删除带有P1,P2,P3,P4的三角形
        For k As Integer = 0 To Tri1.Count - 1
            If Tri1(k).P1.Name = P1.Name Or Tri1(k).P1.Name = P2.Name Or Tri1(k).P1.Name = P3.Name Or Tri1(k).P1.Name = P4.Name Then

                t3.Add(Tri1(k))
            ElseIf Tri1(k).P2.Name = P1.Name Or Tri1(k).P2.Name = P2.Name Or Tri1(k).P2.Name = P3.Name Or Tri1(k).P2.Name = P4.Name Then

                t3.Add(Tri1(k))
            ElseIf Tri1(k).P3.Name = P1.Name Or Tri1(k).P3.Name = P2.Name Or Tri1(k).P3.Name = P3.Name Or Tri1(k).P3.Name = P4.Name Then

                t3.Add(Tri1(k))
            End If
        Next
        For Each t As Tin1 In t3
            Tri1.Remove(t)
        Next
    End Sub
    '检查边是否重复
    Private Function CheckHave(sop As Side, sideop As List(Of Side)) As Boolean
        Dim check As Boolean
        For Each s As Side In sideop
            If (sop.P2.Name = s.P2.Name And sop.P1.Name = s.P1.Name) Or (sop.P1.Name = s.P2.Name And sop.P2.Name = s.P1.Name) Then
                check = True
                Exit For
            Else check = False
            End If
        Next
        Return check
    End Function
    Sub V_() '计算体积
        For i = 0 To Tri1.Count - 1
            V.Add(Count_V(Tri1(i).P1, Tri1(i).P2, Tri1(i).P3))
            VV += Count_V(Tri1(i).P1, Tri1(i).P2, Tri1(i).P3)
        Next
    End Sub
    Function Count_V(ByVal P1 As TinData, ByVal P2 As TinData, ByVal P3 As TinData)
        Dim V As Double
        Dim S, H_ As Double
        S = Abs((P2.X - P1.X) * (P3.Y - P1.Y) - (P3.X - P1.X) * (P2.Y - P1.Y)) / 2
        H_ = (P1.H + P2.H + P3.H) / 3 - H0
        V = S * H_
        Return V
    End Function
    '报告
    Function Report()
        Dim Textout As String = ""
        Textout &= Space(5) & "————————————基本信息————————————" & vbCrLf & vbCrLf
        Textout &= Space(5) & "基准高程：" & H0 & “  m” & vbCrLf
        Textout &= Space(5) & “三角形个数：” & Tri1.Count & vbCrLf
        Textout &= Space(5) & “体积：” & String.Format("{0:f3}", VV) & "  m^3" & vbCrLf & vbCrLf
        Textout &= Space(5) & ”——————————20个三角形说明——————————" & vbCrLf
        Textout &= Space(5) & "序号         三个顶点" & vbCrLf & vbCrLf
        For i = 0 To Tri1.Count - 1
            Textout &= Space(5) & i + 1 & Space(13 - (i + 1).ToString.Count) & Tri1(i).P1.Name &
                Space(6 - Tri1(i).P1.Name.Count) & Tri1(i).P2.Name & Space(6 - Tri1(i).P2.Name.Count) _
                & Tri1(i).P3.Name & vbCrLf
        Next
        Textout += vbCrLf
        V.Sort()
        Textout += Space(5) & "—————体积最大的5个三棱柱体积—————" & vbCrLf & vbCrLf
        For i = 0 To 4
            Textout += Space(5) & Format(V(V.Count - 1 - i), "0.000") & vbCrLf
        Next
        Textout += vbCrLf
        Textout += Space(5) & "—————体积最小的5个三棱柱体积—————" & vbCrLf & vbCrLf
        For i = 0 To 4
            Textout += Space(5) & Format（V(i), "0.000") & vbCrLf
        Next
        Return Textout
    End Function
    'DXF数据开始函数
    Sub DXF_strat()
        PrintLine(1, 0)
        PrintLine(1, "SECTION")
        PrintLine(1, 2)
        PrintLine(1, "ENTITIES")
    End Sub
    'DXF数据画点函数  参数点
    Sub DXF_Point(ByVal x As Double, y As Double)
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
    'DXF数据画圆函数  参数为圆心点
    Sub DXF_Circle(ByVal x As Double, y As Double)
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
        PrintLine(1, X)
        PrintLine(1, 20)
        PrintLine(1, Y)
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
    'DXF输出过程
    Sub OutPutDXF()
        Dim SFD As New SaveFileDialog
        SFD.Filter = "DXF文件(*.dxf)|*.dxf"
        SFD.FilterIndex = 0
        If SFD.ShowDialog = DialogResult.OK Then
            FileOpen(1, SFD.FileName, OpenMode.Output)
            DXF_strat()

            For i = 0 To TinDatas.Length - 1
                DXF_Point(TinDatas(i).X, TinDatas(i).Y)
                DXF_TEXT(TinDatas(i).X, TinDatas(i).Y, TinDatas(i).Name)
            Next
            For i = 0 To Tri1.Count - 1
                DXF_LINE(Tri1(i).P1.X, Tri1(i).P1.Y, Tri1(i).P2.X, Tri1(i).P2.Y)
                DXF_LINE(Tri1(i).P1.X, Tri1(i).P1.Y, Tri1(i).P3.X, Tri1(i).P3.Y)
                DXF_LINE(Tri1(i).P3.X, Tri1(i).P3.Y, Tri1(i).P2.X, Tri1(i).P2.Y)
            Next

            DXF_End()
            FileClose(1)
            MsgBox("输出DXF文件完成！", MsgBoxStyle.Information, "警告")
        End If
    End Sub

    Public Sub DrawPoint(a As Graphics, b As Pen, x As Integer, y As Integer)   'BMP绘制点
        a.DrawEllipse(b, x - 3, y - 3, 6, 6)
    End Sub


End Module
