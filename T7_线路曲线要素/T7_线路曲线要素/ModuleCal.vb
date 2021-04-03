Imports System.IO
Imports System.Math
Imports T7_线路曲线要素.AngConver
Module ModuleCal
    Public DataStream As String
    Public DataStr() As String
    Public ComputRst As String
    Public RodeData() As RodeCur
    Public RodeCurData() As RodeCur
    Public RodeHData() As RodeCur
    Public i, j As Integer
    Public ValCurA() As AngA
    Public ValHA() As AngA
    Public ValCirCur() As CirCur
    Public ValCirCurMK() As CirCurK
    Public ValMPCoor() As CurMKCoor
    Public Ls As Double
    Public ValHCur() As HCur
    Public ValAllCur() As AllCur
    Public ValHMPK() As HMPK
    Public ValHMPCoor() As HMPCoor
    Public PointKCoor() As Pt
    Public Coorval As Pt
    Public ValZPoint() As ZPoint
    Structure Pt
        Dim X, Y As Double
    End Structure
    Structure RodeCur
        Dim PointName As String
        Dim CoorX, CoorY As Double
        Dim CirR As Double
        Dim CurL As Double
        Dim Id As Integer
    End Structure
    Structure CirCurK
        Dim Kjd, Kzy, Kqz, Kyz As Double
    End Structure
    Structure CirCur
        Dim T, L, E, q As Double
    End Structure
    Structure CurMKCoor
        Dim P1CooX, P1CooY, P2CooX, P2CooY As Double
    End Structure
    Structure AngA
        Dim A1 As Double
        Dim A2 As Double
        Dim A As Double
    End Structure
    Structure HCur
        Dim m, p, B0 As Double
    End Structure
    Structure AllCur
        Dim TH, LH, EH, q As Double
    End Structure
    Structure HMPK
        Dim KJD, KZH, KHY, KQZ, KYH, KHZ As Double
    End Structure
    Structure HMPCoor
        Dim P1CoorX, P1CoorY, P2CoorX, P2CoorY As Double
    End Structure
    Structure ZPoint
        Dim Name, Type As String
        Dim K, X, Y As Double
    End Structure

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
                ReDim Preserve RodeData((DataStr.Length) / 5 - 1)
                For i = 0 To RodeData.Length - 1
                    RodeData(i).PointName = DataStr(i * 5)
                    RodeData(i).CoorX = DataStr(i * 5 + 1)
                    RodeData(i).CoorY = DataStr(i * 5 + 2)
                    RodeData(i).CirR = DataStr(i * 5 + 3)
                    RodeData(i).CurL = DataStr(i * 5 + 4)
                    RodeData(i).Id = i
                Next
            Catch ex As Exception
                MsgBox("导入失败请检查数据文件后重试", 64, "提示")
            End Try
        Else
            MsgBox("未选择文件", 64, "提示")
            Exit Sub
        End If
    End Sub
    Public Sub OutputRsutFile(SaveFile As SaveFileDialog)
        SaveFile.Filter = "Text Files|*.txt|All Files|*.*"
        SaveFile.FilterIndex = 0
        If SaveFile.ShowDialog = DialogResult.OK Then
            Dim StrmW As New System.IO.StreamWriter(SaveFile.OpenFile())
            StrmW.Write(ComputRst)
            StrmW.Close()
        Else
            MsgBox("未保存", 64, "提示")
            Exit Sub
        End If
    End Sub
    Public Function DataGird1(ByVal data() As RodeCur)
        Dim DT As New DataTable
        For i = 0 To 4
            DT.Columns.Add()
        Next
        For i = 0 To RodeData.Length - 1
            DT.Rows.Add()
        Next
        DT.Columns(0).ColumnName = "点名"
        DT.Columns(1).ColumnName = "X坐标"
        DT.Columns(2).ColumnName = "Y坐标"
        DT.Columns(3).ColumnName = "圆曲线半径"
        DT.Columns(4).ColumnName = "缓曲线长"
        For i = 0 To RodeData.Length - 1
            DT(i)(0) = data(i).PointName
            DT(i)(1) = data(i).CoorX
            DT(i)(2) = data(i).CoorY
            DT(i)(3) = data(i).CirR
            DT(i)(4) = data(i).CurL
        Next
        Return DT
    End Function

    Sub AllCal()
        CheckForCurData()
        ReDim ValCurA(RodeCurData.Length - 1)
        ValCurA = CalCurAng()
        ReDim ValHA(RodeHData.Length - 1)
        ValHA = CalHAng()
        ReDim ValCirCur(RodeCurData.Length - 1)
        ValCirCur = CalCirCur()
        ReDim ValCirCurMK(RodeCurData.Length - 1)
        ValCirCurMK = CalCirCurMK()
        ReDim ValMPCoor(RodeCurData.Length - 1)
        ValMPCoor = CalMPCoor()
        ReDim ValHCur(RodeHData.Length - 1)
        ValHCur = CalHCur()
        ReDim ValAllCur(RodeHData.Length - 1)
        ValAllCur = CalAllCur()
        ReDim ValHMPK(RodeHData.Length - 1)
        ValHMPK = CallHMPK()
        ReDim ValHMPCoor(RodeHData.Length - 1)
        ValHMPCoor = CallHMpCoor()
        Coorval = CalCurHRPCoorK(0, ValHMPK(0).KHZ - ValAllCur(0).LH / 2, False, 0)
        ReDim ValZPoint(CalK(RodeData.Length - 1) \ 10 - 1)
        ValZPoint = CalZPoint()
    End Sub
    Sub CheckForCurData()
        Dim CurNum As Integer
        Dim HNum As Integer
        For i = 1 To RodeData.Length - 2
            If RodeData(i).CurL = 0 Then
                CurNum += 1
                ReDim Preserve RodeCurData(CurNum - 1)
                RodeCurData(CurNum - 1) = RodeData(i)
            ElseIf RodeData(i).CurL > 0 Then
                HNum += 1
                ReDim Preserve RodeHData(HNum - 1)
                RodeHData(HNum - 1) = RodeData(i)
            End If
        Next
    End Sub


    Function Azimuth(ByVal data1 As RodeCur, ByVal data2 As RodeCur) As Double
        Dim Dx As Double
        Dx = data2.CoorX - data1.CoorX
        Dim Dy As Double
        Dy = data2.CoorY - data1.CoorY
        Dim ang As Double
        If Dx = 0 Then
            If Dy > 0 Then
                ang = PI / 2
            Else
                ang = PI * 3 / 2
            End If
        ElseIf Dx < 0 Then
            ang = Atan2(Dy, Dx) + PI
        Else
            ang = Atan2(Dy, Dx)
        End If
        If ang < 0 Then
            ang = ang + 2 * PI
        End If
        Return ang
    End Function
    Function CalCurAng() As AngA()
        Dim A(RodeCurData.Length - 1) As AngA
        For i = 0 To RodeCurData.Length - 1
            A(i).A1 = Azimuth(RodeData(RodeCurData(i).Id - 1), RodeData(RodeCurData(i).Id))
            A(i).A2 = Azimuth(RodeData(RodeCurData(i).Id + 1), RodeData(RodeCurData(i).Id))
            A(i).A = A(i).A2 - A(i).A1
            If A(i).A > PI Then
                A(i).A = 2 * PI - A(i).A
            ElseIf A(i).A < -PI Then
                A(i).A = A(i).A + 2 * PI
            End If
        Next
        Return A
    End Function
    Function CalHAng() As AngA()
        Dim A(RodeHData.Length - 1) As AngA
        For i = 0 To RodeHData.Length - 1
            A(i).A1 = Azimuth(RodeData(RodeHData(i).Id - 1), RodeData(RodeHData(i).Id))
            A(i).A2 = Azimuth(RodeData(RodeHData(i).Id + 1), RodeData(RodeHData(i).Id))
            A(i).A = A(i).A2 - A(i).A1
            If A(i).A > PI Then
                A(i).A = 2 * PI - A(i).A
            ElseIf A(i).A < -PI Then
                A(i).A = A(i).A + 2 * PI
            End If
        Next
        Return A
    End Function
    Function CalCirCur() As CirCur()
        Dim MainVal(RodeCurData.Length - 1) As CirCur
        For i = 0 To RodeCurData.Length - 1
            MainVal(i).T = RodeCurData(i).CirR * Tan(ValCurA(i).A / 2)
            MainVal(i).L = RodeCurData(i).CirR * ValCurA(i).A
            MainVal(i).E = RodeCurData(i).CirR * (1 / Cos(ValCurA(i).A / 2) - 1)
            MainVal(i).q = 2 * MainVal(i).T - MainVal(i).L
        Next
        Return MainVal
    End Function
    Function CalK(ByVal Id As Integer)
        Dim CK As Double = 0
        If Id <> 0 Then
            For j = 0 To Id - 1
                CK += Sqrt((RodeData(j + 1).CoorX - RodeData(j).CoorX) ^ 2 + (RodeData(j + 1).CoorY - RodeData(j).CoorY) ^ 2)
            Next
        Else
            CK = 0
        End If
        Return CK
    End Function
    Function CalCirCurMK() As CirCurK()
        Dim K(RodeCurData.Length - 1) As CirCurK
        For i = 0 To RodeCurData.Length - 1
            K(i).Kjd = CalK(RodeCurData(i).Id)
            K(i).Kzy = K(i).Kjd - ValCirCur(i).T
            K(i).Kqz = K(i).Kzy + ValCirCur(i).L / 2
            K(i).Kyz = K(i).Kzy + ValCirCur(i).L
        Next
        Return K
    End Function
    Function CalMPCoor() As CurMKCoor()
        Dim MP(RodeCurData.Length - 1) As CurMKCoor
        For i = 0 To RodeCurData.Length - 1
            MP(i).P1CooX = RodeCurData(i).CoorX - ValCirCur(i).T * Cos(ValCurA(i).A1)
            MP(i).P1CooY = RodeCurData(i).CoorY - ValCirCur(i).T * Sin(ValCurA(i).A1)
            MP(i).P2CooX = RodeCurData(i).CoorX + ValCirCur(i).T * Cos(ValCurA(i).A2)
            MP(i).P2CooY = RodeCurData(i).CoorY + ValCirCur(i).T * Sin(ValCurA(i).A2)
        Next
        Return MP
    End Function
    Function CheckLeft(ByVal AngeA As AngA) As Boolean
        If AngeA.A2 - AngeA.A1 > 0 Then
            Return False
        Else Return True
        End If
    End Function
    Function CalMidPointCoor(ByVal x As Integer, ByVal Ki As Double, ByVal IsFirst As Boolean) As Pt
        Dim Li, CG As Double
        Dim Coor As Pt
        If IsFirst Then
            Li = Ki - ValCirCurMK(x).Kzy
        Else
            Li = ValCirCurMK(x).Kyz - Ki
        End If
        CG = Li / RodeCurData(x).CirR
        Coor.X = RodeCurData(x).CirR * Sin(CG)
        Coor.Y = RodeCurData(x).CirR * (1 - Cos(CG))
        Return Coor
    End Function
    Function CalRoadCoor(ByVal index As Integer, ByVal IsLeft As Boolean, ByVal IsFirst As Boolean, ByVal Vall As Double, ByVal booll As Boolean) As Pt
        Dim CoorRes As Pt
        If Not IsLeft Then
            If IsFirst Then
                CoorRes.X = ValMPCoor(index).P1CooX + CalCurRPCoor(index, Vall, booll).X * Cos(ValCurA(index).A1) + CalCurRPCoor(index, Vall, booll).Y * Sin(ValCurA(index).A1)
                CoorRes.Y = ValMPCoor(index).P1CooY + CalCurRPCoor(index, Vall, booll).X * Sin(ValCurA(index).A1) - CalCurRPCoor(index, Vall, booll).Y * Cos(ValCurA(index).A1)
            Else
                CoorRes.X = ValMPCoor(index).P2CooX + CalCurRPCoor(index, Vall, booll).X * Cos(ValCurA(index).A2) - CalCurRPCoor(index, Vall, booll).Y * Sin(ValCurA(index).A2)
                CoorRes.Y = ValMPCoor(index).P2CooY + CalCurRPCoor(index, Vall, booll).X * Sin(ValCurA(index).A2) + CalCurRPCoor(index, Vall, booll).Y * Cos(ValCurA(index).A2)
            End If
        Else
            If IsFirst Then
                CoorRes.X = ValMPCoor(index).P1CooX + CalCurRPCoor(index, Vall, booll).X * Cos(ValCurA(index).A1) - CalCurRPCoor(index, Vall, booll).Y * Sin(ValCurA(index).A1)
                CoorRes.Y = ValMPCoor(index).P1CooY + CalCurRPCoor(index, Vall, booll).X * Sin(ValCurA(index).A1) + CalCurRPCoor(index, Vall, booll).Y * Cos(ValCurA(index).A1)
            Else
                CoorRes.X = ValMPCoor(index).P2CooX + CalCurRPCoor(index, Vall, booll).X * Cos(ValCurA(index).A2) + CalCurRPCoor(index, Vall, booll).Y * Sin(ValCurA(index).A2)
                CoorRes.Y = ValMPCoor(index).P2CooY + CalCurRPCoor(index, Vall, booll).X * Sin(ValCurA(index).A2) - CalCurRPCoor(index, Vall, booll).Y * Cos(ValCurA(index).A2)
            End If
        End If
        Return CoorRes
    End Function
    Function CalCurRPCoor(Index_i As Integer, ByVal Valll As Double, ByVal boole As Boolean) As Pt
        Dim CalCoor As Pt
        CalCoor = CalMidPointCoor(Index_i, Valll, boole)
        Return CalCoor
    End Function
    Function CalCurRPCoorK(in_i As Integer, ByVal Val As Double, ByVal bool As Boolean) As Pt
        Dim Valcoor As Pt
        Valcoor = CalRoadCoor(in_i, CheckLeft(ValCurA(in_i)), True, Val, bool)
        Return Valcoor
    End Function
    Function CalHCur() As HCur()
        Dim MainVal(RodeHData.Length - 1) As HCur
        For i = 0 To RodeHData.Length - 1
            Ls = RodeHData(i).CurL
            MainVal(i).m = Ls / 2 - Ls ^ 3 / (240 * RodeHData(i).CirR ^ 2)
            MainVal(i).p = Ls ^ 2 / (24 * RodeHData(i).CirR)
            MainVal(i).B0 = Ls / (2 * RodeHData(i).CirR)
        Next
        Return MainVal
    End Function
    Function CalAllCur() As AllCur()
        Dim MainVal(RodeHData.Length - 1) As AllCur
        For i = 0 To RodeHData.Length - 1
            MainVal(i).TH = ValHCur(i).m + (RodeHData(i).CirR + ValHCur(i).p) * Tan(ValHA(i).A / 2)
            MainVal(i).LH = RodeHData(i).CirR * (ValHA(i).A - 2 * ValHCur(i).B0) + 2 * RodeHData(i).CurL
            MainVal(i).EH = (RodeHData(i).CirR + ValHCur(i).p) * (1 / Cos(ValHA(i).A / 2)) - RodeHData(i).CirR
            MainVal(i).q = 2 * MainVal(i).TH - MainVal(i).LH
        Next
        Return MainVal
    End Function
    Function CallHMPK() As HMPK()
        Dim MainVal(RodeHData.Length - 1) As HMPK
        For i = 0 To RodeHData.Length - 1
            MainVal(i).KJD = CalK(RodeHData(i).Id)
            MainVal(i).KZH = MainVal(i).KJD - ValAllCur(i).TH
            MainVal(i).KHY = MainVal(i).KZH + Ls
            MainVal(i).KQZ = MainVal(i).KZH + ValAllCur(i).LH / 2
            MainVal(i).KYH = MainVal(i).KZH + ValAllCur(i).LH - Ls
            MainVal(i).KHZ = MainVal(i).KYH + Ls
        Next
        Return MainVal
    End Function
    Function CallHMpCoor() As HMPCoor()
        Dim PointCoor(RodeHData.Length - 1) As HMPCoor
        For i = 0 To RodeHData.Length - 1
            PointCoor(i).P1CoorX = RodeHData(i).CoorX - ValAllCur(i).TH * Cos(ValHA(i).A1)
            PointCoor(i).P1CoorY = RodeHData(i).CoorY - ValAllCur(i).TH * Sin(ValHA(i).A1)
            PointCoor(i).P2CoorX = RodeHData(i).CoorX + ValAllCur(i).TH * Cos(ValHA(i).A2)
            PointCoor(i).P2CoorY = RodeHData(i).CoorY + ValAllCur(i).TH * Sin(ValHA(i).A2)
        Next
        Return PointCoor
    End Function
    Function CalHMidPointCoor(ByVal x As Integer, ByVal Ki As Double, ByVal Location As Integer, ByVal ISZHY As Boolean) As Pt
        Dim Li, CG As Double
        Dim Coor As Pt
        If Location = -1 Then
            Li = Ki - ValHMPK(x).KZH
        ElseIf Location = 1 Then
            Li = ValHMPK(x).KHZ - Ki
        ElseIf Location = 0 Then
            Li = Ki - ValHMPK(x).KZH
        End If
        If Not Location = 0 Then
            Coor.X = Li - Li ^ 5 / (40 * RodeHData(x).CirR ^ 2 * Ls ^ 2)
            Coor.Y = Li / (6 * RodeHData(x).CirR * Ls)
        Else
            CG = (Li - Ls * 0.5) / (RodeHData(x).CirR)
            Coor.X = ValHCur(x).m + RodeHData(x).CirR * Sin(CG)
            Coor.Y = ValHCur(x).p + RodeHData(x).CirR * (1 - Cos(CG))
        End If
        Return Coor
    End Function
    Function CAlHRoadCoor(ByVal index As Integer, ByVal IsLeft As Boolean, ByVal Valll As Double, ByVal bool1 As Boolean, ByVal booll2 As Integer) As Pt
        Dim CoorRes As Pt
        If Not IsLeft Then
            If Not booll2 = 1 Then
                CoorRes.X = ValHMPCoor(index).P1CoorX + CalCurHRPCoor(index, Valll, bool1, booll2).X * Cos(ValHA(index).A1) + CalCurHRPCoor(index, Valll, bool1, booll2).Y * Sin(ValHA(index).A1)
                CoorRes.Y = ValHMPCoor(index).P1CoorY + CalCurHRPCoor(index, Valll, bool1, booll2).X * Sin(ValHA(index).A1) - CalCurHRPCoor(index, Valll, bool1, booll2).Y * Cos(ValHA(index).A1)
            Else
                CoorRes.X = ValHMPCoor(index).P2CoorX + CalCurHRPCoor(index, Valll, bool1, booll2).X * Cos(ValHA(index).A2) - CalCurHRPCoor(index, Valll, bool1, booll2).Y * Sin(ValHA(index).A2)
                CoorRes.Y = ValHMPCoor(index).P2CoorY + CalCurHRPCoor(index, Valll, bool1, booll2).X * Sin(ValHA(index).A2) + CalCurHRPCoor(index, Valll, bool1, booll2).Y * Cos(ValHA(index).A2)
            End If
        Else
            If Not booll2 = 1 Then
                CoorRes.X = ValHMPCoor(index).P1CoorX + CalCurHRPCoor(index, Valll, bool1, booll2).X * Cos(ValHA(index).A1) - CalCurHRPCoor(index, Valll, bool1, booll2).Y * Sin(ValHA(index).A1)
                CoorRes.Y = ValHMPCoor(index).P1CoorY + CalCurHRPCoor(index, Valll, bool1, booll2).X * Sin(ValHA(index).A1) + CalCurHRPCoor(index, Valll, bool1, booll2).Y * Cos(ValHA(index).A1)
            Else
                CoorRes.X = ValHMPCoor(index).P2CoorX - CalCurHRPCoor(index, Valll, bool1, booll2).X * Cos(ValHA(index).A2) + CalCurHRPCoor(index, Valll, bool1, booll2).Y * Sin(ValHA(index).A2)
                CoorRes.Y = ValHMPCoor(index).P2CoorY - CalCurHRPCoor(index, Valll, bool1, booll2).X * Sin(ValHA(index).A2) + CalCurHRPCoor(index, Valll, bool1, booll2).Y * Cos(ValHA(index).A2)
            End If
        End If
        Return CoorRes
    End Function
    Function CalCurHRPCoor(ByVal Index_i As Integer, ByVal vall As Double, ByVal bool As Boolean, ByVal bool2 As Integer) As Pt
        Dim CalCoor As Pt
        CalCoor = CalHMidPointCoor(Index_i, vall, bool2, bool)
        Return CalCoor
    End Function
    Function CalCurHRPCoorK(ByVal in_i As Integer, ByVal Val As Double, ByVal boo As Boolean, ByVal boo2 As Integer) As Pt
        Dim Valcoor As Pt
        Valcoor = CAlHRoadCoor(in_i, CheckLeft(ValHA(in_i)), Val, boo, boo2)
        Return Valcoor
    End Function

    Function CalZPoint()
        Dim ValmZPoint(CalK(RodeData.Length - 1) \ 10 - 1) As ZPoint
        Dim Location1 As Integer
        For i = 0 To CalK(RodeData.Length - 1) \ 10 - 1
            ValmZPoint(i).Name = "Stake" & CStr(i + 1)
            ValmZPoint(i).K = i * 10 + 10
            If ValmZPoint(i).K >= 0 And ValmZPoint(i).K < ValCirCurMK(0).Kzy Then
                ValmZPoint(i).Type = "Line"
                ValmZPoint(i).X = RodeData(0).CoorX + ValmZPoint(i).K * Cos(ValCurA(0).A1)
                ValmZPoint(i).Y = RodeData(0).CoorY + ValmZPoint(i).K * Sin(ValCurA(0).A1)
            ElseIf ValmZPoint(i).K > ValCirCurMK(0).Kzy And ValmZPoint(i).K < ValCirCurMK(0).Kyz Then
                ValmZPoint(i).Type = "YQX"
                ValmZPoint(i).X = CalCurRPCoorK(0, ValmZPoint(i).K, ValmZPoint(i).K - ValCirCurMK(0).Kzy < ValCirCurMK(0).Kqz).X
                ValmZPoint(i).Y = CalCurRPCoorK(0, ValmZPoint(i).K, ValmZPoint(i).K - ValCirCurMK(0).Kzy < ValCirCurMK(0).Kqz).Y
            ElseIf ValmZPoint(i).K < ValHMPK(0).KZH And ValmZPoint(i).K > ValCirCurMK(0).Kyz Then
                ValmZPoint(i).Type = "Line"
                ValmZPoint(i).X = ValMPCoor(0).P2CooX + (ValmZPoint(i).K - ValCirCurMK(0).Kyz) * Cos(ValHA(0).A1)
                ValmZPoint(i).Y = ValMPCoor(0).P2CooY + (ValmZPoint(i).K - ValCirCurMK(0).Kyz) * Sin(ValHA(0).A1)
            ElseIf ValmZPoint(i).K > ValHMPK(0).KZH And ValmZPoint(i).K < ValhMpK(0).Khz Then
                ValmZPoint(i).Type = "HQX"
                If ValmZPoint(i).K < ValHMPK(0).KHY Then
                    Location1 = -1
                ElseIf ValmZPoint(i).K > ValHMPK(0).KHY And ValmZPoint(i).K < ValHMPK(0).KYH Then
                    Location1 = 0
                ElseIf ValmZPoint(i).K > ValHMPK(0).KYH Then
                    Location1 = 1
                End If
                ValmZPoint(i).X = CalCurHRPCoorK(0, ValmZPoint(i).K, ValmZPoint(i).K < ValHMPK(0).KHY Or ValmZPoint(i).K > ValHMPK(0).KYH, Location1).X
                ValmZPoint(i).Y = CalCurHRPCoorK(0, ValmZPoint(i).K, ValmZPoint(i).K < ValHMPK(0).KHY Or ValmZPoint(i).K > ValHMPK(0).KYH, Location1).Y
            ElseIf ValmZPoint(i).K > ValHMPK(0).KHZ And ValmZPoint(i).K < CalK(3) Then
                ValmZPoint(i).Type = "Line"
                ValmZPoint(i).X = ValHMPCoor(0).P2CoorX + (ValmZPoint(i).K - ValHMPK(0).KHZ) * Cos(ValHA(0).A2)
                ValmZPoint(i).Y = ValHMPCoor(0).P2CoorY + (ValmZPoint(i).K - ValHMPK(0).KHZ) * Sin(ValHA(0).A2)

            End If
        Next
        Return ValmZPoint
    End Function


    Function ReportText()
        Dim ReportStr As String
        ReportStr = "--------------统计信息-----------------------" & vbCrLf
        ReportStr &= String.Format("道路总长：{0}", String.Format("{0:f3}", CalK(3))) & vbCrLf
        ReportStr &= String.Format("圆曲线数目：{0}", RodeCurData.Length) & vbCrLf
        ReportStr &= String.Format("缓曲线数目：{0}", RodeHData.Length) & vbCrLf
        ReportStr &= "--------------圆曲线数据-----------------------" & vbCrLf
        For i = 0 To RodeCurData.Length - 1
            ReportStr &= String.Format("缓曲线名：HQX-{0}", RodeCurData(i).PointName) & vbCrLf
            ReportStr &= String.Format("线路转向角：{0}", RadToDmsStr(ValCurA(i).A)) & vbCrLf
            ReportStr &= String.Format("圆曲线半径：{0:f2}", RodeCurData(i).CirR) & vbCrLf
            ReportStr &= String.Format("曲线长：{0:f4}", ValCirCur(i).L) & vbCrLf
            ReportStr &= String.Format("外矢距：{0:f4}", ValCirCur(i).E) & vbCrLf
            ReportStr &= String.Format("切曲差：{0:f4}", ValCirCur(i).q) & vbCrLf & vbCrLf
            ReportStr &= Space(15) & "点名" & Space(6) & "X坐标" & Space(10) & “Y坐标” & Space(10) & "里程" & vbCrLf
            ReportStr &= Space(15) & "ZY" & Space(8) & String.Format("{0:f3}", ValMPCoor(i).P1CooX) & Space(15 - String.Format("{0:f3}", ValMPCoor(i).P1CooX).Count) &
                String.Format("{0:f3}", ValMPCoor(i).P1CooY) & Space(15 - String.Format("{0:f3}", ValMPCoor(i).P1CooY).Count) &
                String.Format("{0:f3}", ValCirCurMK(i).Kzy) & vbCrLf
            ReportStr &= Space(15) & "QZ" & Space(8) & String.Format("{0:f3}", CalCurRPCoorK(i, ValCirCurMK(i).Kyz - ValCirCur(i).L / 2, True).X) & Space(15 - String.Format("{0:f3}", CalCurRPCoorK(i, ValCirCurMK(i).Kyz - ValCirCur(i).L / 2, True).X).Count) &
                String.Format("{0:f3}", CalCurRPCoorK(i, ValCirCurMK(i).Kyz - ValCirCur(i).L / 2, True).Y) & Space(15 - String.Format("{0:f3}", CalCurRPCoorK(i, ValCirCurMK(i).Kyz - ValCirCur(i).L / 2, True).Y).Count) &
                String.Format("{0:f3}", ValCirCurMK(i).Kqz) & vbCrLf
            ReportStr &= Space(15) & "YZ" & Space(8) & String.Format("{0:f3}", ValMPCoor(i).P2CooX) & Space(15 - String.Format("{0:f3}", ValMPCoor(i).P2CooX).Count) &
                String.Format("{0:f3}", ValMPCoor(i).P2CooY) & Space(15 - String.Format("{0:f3}", ValMPCoor(i).P2CooY).Count) &
                String.Format("{0:f3}", ValCirCurMK(i).Kyz) & vbCrLf & vbCrLf & vbCrLf

        Next
        ReportStr &= "--------------缓曲线数据-----------------------" & vbCrLf
        For i = 0 To RodeHData.Length - 1
            ReportStr &= String.Format("缓曲线名：HQX-{0}", RodeHData(i).PointName) & vbCrLf
            ReportStr &= String.Format("线路转向角：{0}", RadToDmsStr(ValHA(i).A)) & vbCrLf
            ReportStr &= String.Format("圆曲线半径：{0:f2}", RodeHData(i).CirR) & vbCrLf
            ReportStr &= String.Format("曲线长：{0:f4}", ValAllCur(i).LH) & vbCrLf
            ReportStr &= String.Format("外矢距：{0:f4}", ValAllCur(i).EH) & vbCrLf
            ReportStr &= String.Format("切曲差：{0:f4}", ValAllCur(i).q) & vbCrLf
            ReportStr &= String.Format("切垂距：{0:f4}", ValHCur(i).m) & vbCrLf
            ReportStr &= String.Format("缓曲线内移量：{0:f4}", ValHCur(i).p) & vbCrLf & vbCrLf
            ReportStr &= Space(15) & "点名" & Space(6) & "X坐标" & Space(10) & “Y坐标” & Space(10) & "里程" & vbCrLf
            ReportStr &= Space(15) & "ZH" & Space(8) & String.Format("{0:f3}", ValHMPCoor(i).P1CoorX) & Space(15 - String.Format("{0:f3}", ValHMPCoor(i).P1CoorX).Count) &
                String.Format("{0:f3}", ValHMPCoor(i).P1CoorY) & Space(15 - String.Format("{0:f3}", ValHMPCoor(i).P1CoorY).Count) &
                String.Format("{0:f3}", ValHMPK(i).KZH) & vbCrLf
            ReportStr &= Space(15) & "QZ" & Space(8) & String.Format("{0:f3}", Coorval.X) & Space(15 - String.Format("{0:f3}", Coorval.X).Count) &
                String.Format("{0:f3}", Coorval.Y) & Space(15 - String.Format("{0:f3}", Coorval.Y).Count) &
                String.Format("{0:f3}", ValHMPK(i).KQZ) & vbCrLf
            ReportStr &= Space(15) & "HZ" & Space(8) & String.Format("{0:f3}", ValHMPCoor(i).P2CoorX) & Space(15 - String.Format("{0:f3}", ValHMPCoor(i).P2CoorX).Count) &
                String.Format("{0:f3}", ValHMPCoor(i).P2CoorY) & Space(15 - String.Format("{0:f3}", ValHMPCoor(i).P2CoorY).Count) &
                String.Format("{0:f3}", ValHMPK(i).KHZ) & vbCrLf & vbCrLf & vbCrLf
        Next

        ReportStr &= "--------------定桩数据-----------------------" & vbCrLf
        ReportStr &= Space(15) & "点名" & Space(6) & "X坐标" & Space(10) & “Y坐标” & Space(10) & "里程" & Space(10) & "类型" & vbCrLf
        For i = 0 To CalK(RodeData.Length - 1) \ 10 - 1
            ReportStr &= Space(15) & ValZPoint(i).Name & Space(8) & String.Format("{0:f3}", ValZPoint(i).X) & Space(15 - String.Format("{0:f3}", ValZPoint(i).X).Count) &
                String.Format("{0:f3}", ValZPoint(i).Y) & Space(15 - String.Format("{0:f3}", ValZPoint(i).Y).Count) &
                String.Format("K0+{0:f3}", ValZPoint(i).K) & Space(15 - String.Format("K0+{0:f3}", ValZPoint(i).K).Count) & ValZPoint(i).Type & vbCrLf
        Next



        Return ReportStr
    End Function

End Module
