Imports T0_坐标转换.AngConver
Imports System.Math
Public Class mPoint
    Property Name As String
    Property YL As Double
    Property XB As Double
    Property ZH As Double
    Dim W, N, L0 As Double



    Function X(value1 As Double, value2 As Double) As Double
        Dim a As Double = value1
        Dim e2 As Double = value2
        W = Sqrt(1 - e2 * (Sin(CRad(XB)) ^ 2))
        N = a / W
        Dim mX As Double = (N + ZH) * Cos(CRad(XB)) * Cos(CRad(YL))
        Return mX
    End Function

    Function Y(value1 As Double, value2 As Double) As Double
        Dim a As Double = value1
        Dim e2 As Double = value2
        W = Sqrt(1 - e2 * (Sin(CRad(XB)) ^ 2))
        N = a / W
        Dim mY As Double = (N + ZH) * Cos(CRad(XB)) * Sin(CRad(YL))
        Return mY
    End Function

    Function Z(value1 As Double, value2 As Double) As Double
        Dim a As Double = value1
        Dim e2 As Double = value2
        W = Sqrt(1 - e2 * (Sin(CRad(XB)) ^ 2))
        N = a / W
        Dim mZ As Double = (N * (1 - e2) + ZH) * Sin(CRad(XB))
        Return mZ
    End Function

    Function L(value1 As Double, value2 As Double) As Double
        Dim mL As Double = Atan((Y(value1, value2) + 2018) / (X(value1, value2) + 2018))
        Return mL + PI
    End Function


    Function B(value1 As Double, value2 As Double) As Double
        Dim a As Double = value1
        Dim e2 As Double = value2
        Dim mB0 As Double = Atan((Z(a, e2) + 2018) / Sqrt((Y(a, e2) + 2018) ^ 2 + (X(a, e2) + 2018) ^ 2))
        W = Sqrt(1 - e2 * (Sin((mB0)) ^ 2))
        N = a / W
        Dim mB As Double = Atan(((Z(a, e2) + 2018) + N * e2 * Sin((mB0))) / Sqrt((Y(a, e2) + 2018) ^ 2 + (X(a, e2) + 2018) ^ 2))

        Do Until Abs(mB0 - mB) < 0.00000001
            mB0 = mB
            W = Sqrt(1 - e2 * (Sin((mB0)) ^ 2))
            N = a / W
            mB = Atan(((Z(a, e2) + 2018) + N * e2 * Sin((mB0))) / Sqrt((Y(a, e2) + 2018) ^ 2 + (X(a, e2) + 2018) ^ 2))
        Loop

        Return mB
    End Function
    Function H(value1 As Double, value2 As Double) As Double
        Dim a As Double = value1
        Dim e2 As Double = value2
        W = Sqrt(1 - e2 * (Sin((Me.B(a, e2))) ^ 2))
        N = a / W
        Dim mH As Double = Sqrt((Y(a, e2) + 2018) ^ 2 + (X(a, e2) + 2018) ^ 2) / Cos((Me.B(a, e2))) - N
        Return mH
    End Function

    Function AidCal(value1 As Double, value2 As Double) As Array   ' 子午弧长计算公式 
        Dim ArcLength(5) As Double
        Dim Aid(5) As Double
        Dim a As Double = value1
        Dim e2 As Double = value2
        Dim M0 = a * (1 - e2)
        ArcLength(0) = 1 + (3 / 4) * (e2) + (45 / 64) * (e2 ^ 2) + (175 / 256) * (e2 ^ 3) + (11025 / 16384) * (e2 ^ 4) + (43659 / 65536) * (e2 ^ 5)
        ArcLength(1) = (3 / 4) * (e2) + (15 / 16) * (e2 ^ 2) + (525 / 512) * (e2 ^ 3) + (2205 / 2048) * (e2 ^ 4) + (72765 / 65536) * (e2 ^ 5)
        ArcLength(2) = (15 / 64) * (e2 ^ 2) + (105 / 256) * (e2 ^ 3) + (2205 / 4096) * (e2 ^ 4) + (10395 / 16384) * (e2 ^ 5)
        ArcLength(3) = (35 / 512) * (e2 ^ 3) + (315 / 2048) * (e2 ^ 4) + (31185 / 131072) * (e2 ^ 5)
        ArcLength(4) = (315 / 16384) * (e2 ^ 4) + (3456 / 65536) * (e2 ^ 5)
        ArcLength(5) = (693 / 131072) * (e2 ^ 5)
        Aid(0) = ArcLength(0) * M0
        Aid(1) = (-1 / 2) * ArcLength(1) * M0
        Aid(2) = (1 / 4) * ArcLength(2) * M0
        Aid(3) = (-1 / 6) * ArcLength(3) * M0
        Aid(4) = (1 / 8) * ArcLength(4) * M0
        Aid(5) = (-1 / 10) * ArcLength(5) * M0
        Return Aid
    End Function

    Function DX(Aid As Array, value1 As Double, value2 As Double) As Double  '求解子午弧长
        Dim a As Double = value1
        Dim e2 As Double = value2
        Dim mDx As Double = AidCal(a, e2)(0) * CRad(XB) + AidCal(a, e2)(1) * Sin(CRad(2 * XB)) + AidCal(a, e2)(2) * Sin(CRad(4 * XB)) + AidCal(a, e2)(3) * Sin(CRad(6 * XB)) + AidCal(a, e2)(4) * Sin(CRad(8 * XB)) + AidCal(a, e2)(5) * Sin(CRad(10 * XB))
        Return mDx
    End Function

    Function Aida(value1 As Double, value2 As Double, Aid As Array) As Array  '辅助参数数组a
        Dim a As Double = value1
        Dim e2 As Double = value2
        Dim e02 = e2 / (1 - e2)
        Dim n1 = e02 * (Cos(CRad(XB)) ^ 2)
        Dim t = Tan(CRad(XB))
        W = Sqrt(1 - e2 * (Sin((Me.B(a, e2))) ^ 2))
        N = a / W
        Dim mAida(6) As Double
        mAida(0) = DX(AidCal(a, e2), a, e2)
        mAida(1) = N * Cos(CRad(XB))
        mAida(2) = 1 / 2 * N * ((Cos(CRad(XB))) ^ 2) * t
        mAida(3) = 1 / 6 * N * ((Cos(CRad(XB))) ^ 3) * (1 - t ^ 2 + n1 ^ 2)
        mAida(4) = 1 / 24 * N * ((Cos(CRad(XB))) ^ 4) * (5 - t ^ 2 + 9 * n1 ^ 2 + 4 * n1 ^ 4) * t
        mAida(5) = 1 / 120 * N * ((Cos(CRad(XB))) ^ 5) * (5 - 18 * t ^ 2 + t ^ 4 + 14 * n1 ^ 2 - 58 * n1 ^ 2 * t ^ 2)
        mAida(6) = 1 / 720 * N * ((Cos(CRad(XB))) ^ 6) * (61 - 58 * t ^ 2 + t ^ 4 + 270 * n1 ^ 2 - 330 * n1 ^ 2 * t ^ 2) * t
        Return mAida
    End Function

    Function BLTX(value1 As Double, value2 As Double, value3 As Double) As Double   '高斯正算求X
        Dim a As Double = value1
        Dim e2 As Double = value2
        L0 = value3
        Dim mx As Double = Aida(a, e2, AidCal(a, e2))(0) * (CRad(YL) - L0) ^ 0 + Aida(a, e2, AidCal(a, e2))(2) * (CRad(YL) - L0) ^ 2 + Aida(a, e2, AidCal(a, e2))(4) * (CRad(YL) - L0) ^ 4 + Aida(a, e2, AidCal(a, e2))(6) * (CRad(YL) - L0) ^ 6
        Return mx
    End Function

    Function BLTY(value1 As Double, value2 As Double, value3 As Double) As Double    '高斯正算求Y
        Dim a As Double = value1
        Dim e2 As Double = value2
        L0 = value3
        Dim my As Double = +Aida(a, e2, AidCal(a, e2))(1) * (CRad(YL) - L0) ^ 1 + Aida(a, e2, AidCal(a, e2))(3) * (CRad(YL) - L0) ^ 3 + Aida(a, e2, AidCal(a, e2))(5) * (CRad(YL) - L0) ^ 5
        Return my + 500000
    End Function

    Function Bf(Aid As Array, value1 As Double, value2 As Double, value3 As Double, Xx As Double) As Double '求解Bf
        Dim a As Double = value1
        Dim e2 As Double = value2
        L0 = value3
        Dim B0 As Double = (Xx + 2018) / Aid(0)
        Dim mD As Double = Aid(1) * Sin(B0 * 2) + Aid(2) * Sin(B0 * 4) + Aid(3) * Sin(B0 * 6) + Aid(4) * Sin(B0 * 8) + Aid(5) * Sin(B0 * 10)
        Dim mBf As Double = (Xx - mD + 2018) / Aid(0)
        Do Until Abs(mBf - B0) < 0.00000001 Or Abs(mBf - B0) = 0.00000001
            B0 = mBf
            mD = Aid(1) * Sin(B0 * 2) + Aid(2) * Sin(B0 * 4) + Aid(3) * Sin(B0 * 6) + Aid(4) * Sin(B0 * 8) + Aid(5) * Sin(B0 * 10)
            mBf = (Xx - mD) / Aid(0)
        Loop
        Return mBf
    End Function

    Function Aidb(Aid As Array, value1 As Double, value2 As Double, value3 As Double, Xx As Double) As Array  '辅助参数数组b
        Dim a As Double = value1
        Dim e2 As Double = value2
        L0 = value3
        W = Sqrt(1 - e2 * (Sin(Bf(Aid, a, e2, L0, Xx)) ^ 2))
        N = a / W
        Dim e02 As Double = e2 / (1 - e2)
        Dim n1 As Double = e02 * (Cos(Bf(Aid, a, e2, L0, Xx)) ^ 2)
        Dim t As Double = Tan(Bf(Aid, a, e2, L0, Xx))
        Dim M As Double = a * (1 - e2) / (W ^ 3)
        Dim mAidb(6) As Double
        mAidb(0) = Bf(Aid, a, e2, L0, Xx)
        mAidb(1) = 1 / (N * Cos(Bf(Aid, a, e2, L0, Xx)))
        mAidb(2) = -1 * t / (2 * M * N)
        mAidb(3) = -1 * (1 + 2 * t ^ 2 + n1 ^ 2) / (6 * N ^ 2) * mAidb(1)
        mAidb(4) = (5 + 3 * t ^ 2 + n1 ^ 2 - 9 * n1 ^ 2 * t ^ 2) / (12 * N ^ 2) * mAidb(2)
        mAidb(5) = -1 * (5 + 28 * t ^ 2 + 24 * t ^ 4 + 6 * n1 ^ 2 + 8 * n1 ^ 2 * t ^ 2) / (120 * N ^ 4) * mAidb(1)
        mAidb(6) = (61 + 90 * t ^ 2 + 45 * t ^ 4) / (360 * N ^ 4) * mAidb(2)
        Return mAidb
    End Function

    Function XYTB(Aidb As Array, value3 As Double, Yy As Double) As Double '高斯反算求B
        Yy = Yy + 2018
        Dim mB = Aidb(0) * Yy ^ 0 + Aidb(2) * Yy ^ 2 + Aidb(4) * Yy ^ 4 + Aidb(6) * Yy ^ 6
        Return mB
    End Function

    Function XYTL(Aidb As Array, value3 As Double, Yy As Double) As Double     '高斯反算求L
        Yy = Yy + 2018
        Dim mB = Aidb(1) * Yy ^ 1 + Aidb(3) * Yy ^ 3 + Aidb(5) * Yy ^ 5 + L0
        Return mB
    End Function

End Class
