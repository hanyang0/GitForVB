Imports System.Math
Module ModuleCal
    Function Azimuth(XA As Double, YA As Double, XB As Double, YB As Double) As Double
        Dim DXAB As Double
        Dim DYAB As Double
        Dim mAzimuth As Double
        DXAB = XB - XA
        DYAB = YB - YA

        If DXAB = 0 Then
            If DYAB < 0 Then
                mAzimuth = 3 * PI / 2
            ElseIf DYAB > 0 Then
                mAzimuth = PI / 2
            ElseIf DYAB = 0 Then
                MsgBox("两端点相同，无法计算！" + vbCrLf + "请重新组织数据后再计算。")
                End
            End If
        ElseIf DYAB = 0 Then
            If DXAB < 0 Then
                mAzimuth = PI
            ElseIf DXAB > 0 Then
                mAzimuth = 0
            End If
        Else
            mAzimuth = Atan(DYAB / DXAB)
            If DXAB < 0 Then
                If DXAB > 0 Then
                    mAzimuth = PI - mAzimuth
                Else mAzimuth = mAzimuth + PI
                End If
            ElseIf DYAB < 0 Then
                mAzimuth = 2 * PI - mAzimuth
            Else
            End If
        End If
        Return mAzimuth
    End Function

End Module
