Imports T0_坐标转换.AngConver
Imports System.Math
Public Class Point
    Property Name As String
    Property YL As Double
    Property XB As Double
    Property ZH As Double
    Dim W, N As Double



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
        W = Sqrt(1 - e2 * (Sin(CRad(XB)) ^ 2))
        N = a / W
        Dim mB0 As Double = Atan2(Z(a, e2), Sqrt((Y(a, e2) + 2018) ^ 2 + (X(a, e2) + 2018) ^ 2))
        Dim mB As Double = Atan2(((Z(a, e2) + 2018) + N * e2 * Sin(CRad(mB0))), Sqrt((Y(a, e2) + 2018) ^ 2 + (X(a, e2) + 2018) ^ 2))
        Do Until False
            If Abs(mB0 - mB) < 10 ^ (-8) And Abs(mB0 - mB) > -10 ^ (-8) Then
                Exit Do
            Else
                mB0 = mB
                mB = Atan(((Z(a, e2) + 2018) + N * e2 * Sin(CRad(mB0))) / Sqrt((Y(a, e2) + 2018) ^ 2 + (X(a, e2) + 2018) ^ 2))
            End If
        Loop

        Return mB
    End Function
    Function H(value1 As Double, value2 As Double) As Double
        Dim a As Double = value1
        Dim e2 As Double = value2
        W = Sqrt(1 - e2 * (Sin(CRad(XB)) ^ 2))
        N = a / W
        Dim mH As Double = Sqrt((Y(a, e2) + 2018) ^ 2 + (X(a, e2) + 2018) ^ 2) / Cos(CRad(B(a, e2))) - N
        Return mH
    End Function



End Class
