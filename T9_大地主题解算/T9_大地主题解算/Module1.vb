Imports System.IO
Imports System.Math
Imports T9_大地主题解算.AngConver
Module Module1
    Public DataStream As String
    Public DataStr() As String
    Public CmputRst As String
    Public a, f, b, e1, e2 As Double
    Public DataFile() As EarthData

    Structure EarthData
        Dim StPoint As String
        Dim B1 As Double
        Dim L1 As Double
        Dim EnPoint As String
        Dim B2 As Double
        Dim L2 As Double
        Dim Azmiuth1 As Double
        Dim Azmiuth2 As Double
        Dim S As Double
    End Structure

    Public Sub InputDataFile(OpenFile As OpenFileDialog, IsBack As Boolean)
        OpenFile.Filter = "Text Files|*.txt|All Files|*.*"
        OpenFile.FilterIndex = 0
        If OpenFile.ShowDialog = DialogResult.OK Then
            Try
                Dim StrmR As New System.IO.StreamReader(OpenFile.FileName)
                DataStream = StrmR.ReadToEnd
                StrmR.Close()
                DataStream = DataStream.Replace(vbCrLf, ",")
                DataStr = DataStream.Split(",")
                a = DataStr(0)
                f = 1 / DataStr(1)
                b = a - f * a
                e1 = Sqrt((a ^ 2 - b ^ 2) / a ^ 2)
                e2 = Sqrt((a ^ 2 - b ^ 2) / b ^ 2)
                ReDim Preserve DataFile((DataStr.Length - 2) / 6 - 1)
                If IsBack Then
                    For i = 0 To DataFile.Length - 1
                        DataFile(i).StPoint = DataStr(2 + i * 6)
                        DataFile(i).B1 = CRad(DataStr(3 + i * 6))
                        DataFile(i).L1 = CRad(DataStr(4 + i * 6))
                        DataFile(i).EnPoint = DataStr(5 + i * 6)
                        DataFile(i).B2 = CRad(DataStr(6 + i * 6))
                        DataFile(i).L2 = CRad(DataStr(7 + i * 6))
                    Next
                    MsgBox("反算数据导入成功", 64, "提示")

                Else
                    For i = 0 To DataFile.Length - 1
                        DataFile(i).StPoint = DataStr(2 + i * 6)
                        DataFile(i).B1 = CRad(DataStr(3 + i * 6))
                        DataFile(i).L1 = CRad(DataStr(4 + i * 6))
                        DataFile(i).Azmiuth1 = CRad(DataStr(5 + i * 6))
                        DataFile(i).S = DataStr(6 + i * 6)
                        DataFile(i).EnPoint = DataStr(7 + i * 6)
                    Next
                    MsgBox("正算数据导入成功", 64, "提示")

                End If
            Catch ex As Exception
                MsgBox("数据格式错误"， 64， “警告”)
                Exit Sub
            End Try
        Else
                Exit Sub

        End If


    End Sub
    Public Sub OutputRsutFile(SaveFile As SaveFileDialog)
        SaveFile.Filter = "Text Files|*.txt|All Files|*.*"
        SaveFile.FilterIndex = 0
        If SaveFile.ShowDialog = DialogResult.OK Then
            Dim StrmW As New System.IO.StreamWriter(SaveFile.OpenFile())
            StrmW.Write(CmputRst)
            StrmW.Close()
        Else
            Exit Sub
        End If
    End Sub

    Function DataGird(ByVal data() As EarthData, Is_Z As Boolean)
        Dim DT As New DataTable
        For i = 0 To 8
            DT.Columns.Add()
        Next
        For i = 0 To data.Length - 1
            DT.Rows.Add()
        Next
        DT.Columns(0).ColumnName = "起点"
        DT.Columns(1).ColumnName = "B1"
        DT.Columns(2).ColumnName = "L1"
        DT.Columns(3).ColumnName = "A1"
        DT.Columns(4).ColumnName = "S"
        DT.Columns(5).ColumnName = "终点"
        DT.Columns(6).ColumnName = "B2"
        DT.Columns(7).ColumnName = "L2"
        DT.Columns(8).ColumnName = "A2"

        If Is_Z = False Then
            For i = 0 To DataFile.Length - 1
                DT(i)(0) = DataFile(i).StPoint
                DT(i)(1) = RadToDMSstr(DataFile(i).B1)
                DT(i)(2) = RadToDMSstr(DataFile(i).L1)
                DT(i)(3) = RadToDMSstr(DataFile(i).Azmiuth1)
                DT(i)(4) = DataFile(i).S
                DT(i)(5) = DataFile(i).EnPoint
                DT(i)(6) = RadToDMSstr(DataFile(i).B2)
                DT(i)(7) = RadToDMSstr(DataFile(i).L2)
                DT(i)(8) = RadToDMSstr(DataFile(i).Azmiuth2)
            Next
        Else
            For i = 0 To DataFile.Length - 1
                DT(i)(0) = DataFile(i).StPoint
                DT(i)(1) = RadToDMSstr(DataFile(i).B1)
                DT(i)(2) = RadToDMSstr(DataFile(i).L1)
                DT(i)(3) = RadToDMSstr(DataFile(i).Azmiuth1)
                DT(i)(4) = DataFile(i).S
                DT(i)(5) = DataFile(i).EnPoint
                DT(i)(6) = RadToDMSstr(DataFile(i).B2)
                DT(i)(7) = RadToDMSstr(DataFile(i).L2)
                DT(i)(8) = RadToDMSstr(DataFile(i).Azmiuth2)
            Next
        End If

        Return DT
    End Function

    Function Z_Calculate(ByVal B1 As Double, ByVal L1 As Double, ByVal A1 As Double, ByVal S As Double)
        Dim W1, Sinu1, Cosu1 As Double
        W1 = Sqrt(1 - e1 ^ 2 * Sin((B1)) ^ 2)
        Sinu1 = Sin((B1)) * Sqrt(1 - e1 ^ 2) / W1
        Cosu1 = Cos((B1)) / W1

        Dim sinAo, cotO1, O1 As Double
        sinAo = Cosu1 * Sin((A1))
        cotO1 = Cosu1 * Cos((A1)) / Sinu1
        O1 = Atan(1 / cotO1)

        Dim α, β, γ As Double
        α = (e1 ^ 2 / 2 + e1 ^ 4 / 8 + e1 ^ 6 / 16) - (e1 ^ 4 / 16 + e1 ^ 6 / 16) * (1 - sinAo ^ 2) + (3 * e1 ^ 6 / 128) * (1 - sinAo ^ 2) ^ 2
        β = (e1 ^ 4 / 16 + e1 ^ 6 / 16) * (1 - sinAo ^ 2) - (e1 ^ 6 / 32) * (1 - sinAo ^ 2) ^ 2
        γ = (e1 ^ 6 / 256) * (1 - sinAo ^ 2) ^ 2

        Dim AA, BB, CC, k2 As Double
        k2 = e2 ^ 2 * (1 - sinAo ^ 2)
        AA = (1 - k2 / 4 + 7 * k2 ^ 2 / 64 - 15 * k2 ^ 3 / 256) / b
        BB = (k2 / 4 - k2 ^ 2 / 8 + 37 * k2 ^ 3 / 512)
        CC = (k2 ^ 2 / 128 - k2 ^ 3 / 128)


        Dim O, O0 As Double
        O = AA * S
        Do
            O0 = O
            O = AA * S + BB * Sin(O) * Cos(2 * O1 + O) + CC * Sin(2 * O) * Cos(4 * O1 + 2 * O)

        Loop Until (Abs(O - O0) <= 10 ^ (-10))

        Dim g As Double
        g = (α * O + β * Sin(O) * Cos(2 * O1 + O) + γ * Sin(2 * O) * Cos(4 * O1 + 2 * O)) * sinAo

        Dim sinu2, B2, r As Double
        sinu2 = Sinu1 * Cos(O) + Cosu1 * Cos((A1)) * Sin(O)
        B2 = Atan(sinu2 / ((Sqrt(1 - e1 ^ 2)) * (Sqrt(1 - sinu2 ^ 2))))
        r = Atan(Sin((A1)) * Sin(O) / (Cosu1 * Cos(O) - Sinu1 * Sin(O) * Cos((A1))))
        If Sin((A1)) > 0 Then
            If Tan(r) > 0 Then
                r = Abs(r)
            Else
                r = PI - Abs(r)
            End If
        Else
            If Tan(r) > 0 Then
                r = Abs(r) - PI
            Else
                r = -Abs(r)
            End If
        End If

        Dim L2 As Double
        L2 = (L1) + r - g
        Dim A2 As Double
        A2 = Atan(Cosu1 * Sin((A1)) / (Cosu1 * Cos(O) * Cos((A1)) - Sinu1 * Sin(O)))


        If Sin((A1)) > 0 Then
            If Tan(A2) > 0 Then
                A2 = PI + Abs(A2)
            Else
                A2 = PI * 2 - Abs(A2)
            End If
        Else
            If Tan(A2) > 0 Then
                A2 = Abs(A2)
            Else
                A2 = PI - Abs(A2)
            End If
        End If
        Return B2 & "," & L2 & "," & A2
    End Function

    Function F_calculate(ByVal B1 As Double, ByVal B2 As Double, ByVal L1 As Double, ByVal L2 As Double)
        Dim u1, u2 As Double
        u1 = Atan(Sqrt(1 - e1 ^ 2) * Tan((B1)))
        u2 = Atan(Sqrt(1 - e1 ^ 2) * Tan((B2)))
        Dim aa1, aa2, bb1, bb2 As Double
        aa1 = Sin(u1) * Sin(u2)
        aa2 = Cos(u1) * Cos(u2)
        bb1 = Cos(u1) * Sin(u2)
        bb2 = Sin(u1) * Cos(u2)
        Dim DL As Double
        DL = (L2) - （L1）

        Dim g, g0 As Double
        Dim r, r0, p, q, A1, sinO, cosO, O, O1, sin_Ao, α, β, γ As Double
        r = DL
        g = 0
        Do
            r0 = r

            p = Cos(u2) * Sin(r)
            q = bb1 - bb2 * Cos(r)
            A1 = Atan(p / q)
            If p > 0 Then
                If q > 0 Then
                    A1 = Abs(A1)
                Else
                    A1 = PI - Abs(A1)
                End If
            Else
                If q > 0 Then
                    A1 = PI * 2 - Abs(A1)
                Else
                    A1 = PI + Abs(A1)
                End If
            End If
            If A1 < 0 Then
                A1 = A1 + PI * 2
            End If
            If A1 > PI * 2 Then
                A1 = A1 - 2 * PI
            End If

            sinO = p * Sin(A1) + q * Cos(A1)
            cosO = aa1 + aa2 * Cos(r)
            O = Atan(sinO / cosO)
            If cosO > 0 Then
                O = Abs(O)
            Else
                O = PI - Abs(O)
            End If

            sin_Ao = Cos(u1) * Sin(A1)

            O1 = Atan(Tan(u1) / Cos(A1))


            α = (e1 ^ 2 / 2 + e1 ^ 4 / 8 + e1 ^ 6 / 16) - (e1 ^ 4 / 16 + e1 ^ 6 / 16) * (1 - sin_Ao ^ 2) + (3 * e1 ^ 6 / 128) * (1 - sin_Ao ^ 2) ^ 2
            β = (e1 ^ 4 / 16 + e1 ^ 6 / 16) * (1 - sin_Ao ^ 2) - (e1 ^ 6 / 32) * (1 - sin_Ao ^ 2) ^ 2
            γ = (e1 ^ 6 / 256) * (1 - sin_Ao ^ 2) ^ 2

            g0 = g
            g = (α * O + β * Cos(2 * O1 + O) * Sin(O) + γ * Sin(2 * O) * Cos(4 * O1 + 2 * O)) * sin_Ao

            r = g + DL

        Loop While Abs(r - r0) <= 10 ^ (-10)

        Dim Xs As Double
        Dim AA, BB, CC, k2 As Double
        k2 = e2 ^ 2 * (1 - sin_Ao ^ 2)
        AA = (1 - k2 / 4 + 7 * k2 ^ 2 / 64 - 15 * k2 ^ 3 / 256) / b
        BB = (k2 / 4 - k2 ^ 2 / 8 + 37 * k2 ^ 3 / 512)
        CC = (k2 ^ 2 / 128 - k2 ^ 3 / 128)

        Xs = CC * Sin(2 * O) * Cos(4 * O1 + 2 * O)
        Dim S As Double
        S = (O - BB * Sin(O) * Cos(2 * O1 + O) - Xs) / AA

        Dim A2 As Double
        Dim Sin_A2, Cos_A2 As Double
        Sin_A2 = Cos(u1) * Sin(A1)
        Cos_A2 = Cos(u1) * Cos(O) * Cos(A1) - Sin(u1) * Sin(O)
        A2 = Atan(Sin_A2 / Cos_A2)
        ' A2 = Atan(Cos(u1) * Sin(r) / (bb1 * Cos(r) - bb2))
        If A2 < 0 Then
            A2 = A2 + 2 * PI
        End If
        If A2 > 2 * PI Then
            A2 = A2 - 2 * PI
        End If
        If A1 < PI Then
            If A2 < PI Then
                A2 = A2 + PI
            End If
        End If
        If A1 > PI Then
            If A2 > PI Then
                A2 = A2 - PI
            End If
        End If
        Return A1 & "," & A2 & "," & S
    End Function

    Sub ReportText（txtbox As TextBox, IsZ As Boolean）


        txtbox.Text &= vbCrLf & vbCrLf & Space(17) & "*******************************大地解算主题报告*******************************" & vbCrLf & vbCrLf
        txtbox.Text &= Space(28) & "————————————数据统计————————————" & vbCrLf
        txtbox.Text &= Space(32) & "数据点对总数：" & DataFile.Length & vbCrLf & vbCrLf
        txtbox.Text &= Space(32) & "椭球长半轴：" & a & vbCrLf & vbCrLf
        txtbox.Text &= Space(32) & "椭球扁率：“ & f & vbCrLf & vbCrLf
        If IsZ = True Then
            txtbox.Text &= Space(32) & "计算类型：" & "大地主题正算" & vbCrLf & vbCrLf
        Else
            txtbox.Text &= Space(32) & "计算类型：" & "大地主题反算" & vbCrLf & vbCrLf
        End If





        txtbox.Text &= Space(28) & “————————————计算结果————————————” & vbCrLf & vbCrLf
        txtbox.Text &= Space(15) & "点名" & Space(6) & "纬度（B）" & Space(10) & “经度（L）” & Space(10) & "大地方位角（A）" & Space(10) & "大地线（S）" & vbCrLf
        If IsZ = False Then
            For i = 0 To DataFile.Length - 1
                txtbox.Text &= Space(15) & DataFile(i).StPoint & Space(10 - DataFile(i).StPoint.Count) & RadToDMSstr(DataFile(i).B1) &
                Space(16 - RadToDMSstr(DataFile(i).B1).ToString.Count) & RadToDMSstr(DataFile(i).L1) &
                Space(16 - RadToDMSstr(DataFile(i).L1).ToString.Count) & RadToDMSstr(DataFile(i).Azmiuth1) &
                Space(22 - RadToDMSstr(DataFile(i).Azmiuth1).ToString.Count) & DataFile(i).S & vbCrLf &
            Space(15) & DataFile(i).EnPoint & Space(10 - DataFile(i).EnPoint.Count) & RadToDMSstr(DataFile(i).B2) &
                Space(16 - RadToDMSstr(DataFile(i).B2).ToString.Count) & RadToDMSstr(DataFile(i).L2) &
                Space(16 - RadToDMSstr(DataFile(i).L2).ToString.Count) & RadToDMSstr(DataFile(i).Azmiuth2) &
                Space(22 - RadToDMSstr(DataFile(i).Azmiuth2).ToString.Count) & DataFile(i).S & vbCrLf

            Next
        Else
            For i = 0 To DataFile.Length - 1
                txtbox.Text &= Space(15) & DataFile(i).StPoint & Space(10 - DataFile(i).StPoint.Count) & RadToDMSstr(DataFile(i).B1) &
                Space(16 - RadToDMSstr(DataFile(i).B1).ToString.Count) & RadToDMSstr(DataFile(i).L1) &
                Space(16 - RadToDMSstr(DataFile(i).L1).ToString.Count) & RadToDMSstr(DataFile(i).Azmiuth1) &
                Space(22 - RadToDMSstr(DataFile(i).Azmiuth1).ToString.Count) & DataFile(i).S & vbCrLf &
            Space(15) & DataFile(i).EnPoint & Space(10 - DataFile(i).EnPoint.Count) & RadToDMSstr(DataFile(i).B2) &
                Space(16 - RadToDMSstr(DataFile(i).B2).ToString.Count) & RadToDMSstr(DataFile(i).L2) &
                Space(16 - RadToDMSstr(DataFile(i).L2).ToString.Count) & RadToDMSstr(DataFile(i).Azmiuth2) &
                Space(22 - RadToDMSstr(DataFile(i).Azmiuth2).ToString.Count) & DataFile(i).S & vbCrLf

            Next




        End If

    End Sub

End Module
