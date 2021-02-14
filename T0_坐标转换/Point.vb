Imports T0_坐标转换_1.AngConver
Imports System.Math
Public Class Point
    Property Name As String
    Property XL As Double
    Property YB As Double
    Property ZH As Double

    Function X(value As Double) As Double
        Dim N As Double = value
        Dim mX As Double = (N + ZH) * Cos(CRad(YB)) * Cos(CRad(XL))
        Return mX
    End Function
    Function Y(value As Double) As Double
        Dim N As Double = value
        Dim mY As Double = (N + ZH) * Cos(CRad(YB)) * Sin(CRad(XL))
        Return mY
    End Function
    Function Z(value1 As Double, value2 As Double) As Double
        Dim N As Double = value1
        Dim e2 As Double = value2
        Dim mZ As Double = (N * (1 - e2) + ZH) * Sin(CRad(YB))
        Return mZ
    End Function

    Function L(value As Double) As Double
        Dim N As Double = value
        Dim mX As Double = (N + ZH) * Cos(CRad(YB)) * Cos(CRad(XL))
        Return mX
    End Function
    Function B(value As Double) As Double
        Dim N As Double = value
        Dim mX As Double = (N + ZH) * Cos(CRad(YB)) * Cos(CRad(XL))
        Return mX
    End Function
    Function H(value As Double) As Double
        Dim N As Double = value
        Dim mX As Double = (N + ZH) * Cos(CRad(YB)) * Cos(CRad(XL))
        Return mX
    End Function



End Class
