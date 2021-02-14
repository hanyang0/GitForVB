Public Class ModeSetedEvent
    Event ModeSeted1()
    Event ModeSeted2()
    Event ModeSeted3()
    Event ModeSeted4()
    Public Sub StartEvent()
        Select Case MainForm.ModeSet
            Case 1
                RaiseEvent ModeSeted1()
            Case 2
                RaiseEvent ModeSeted2()
            Case 3
                RaiseEvent ModeSeted3()
            Case 4
                RaiseEvent ModeSeted4()
        End Select

    End Sub

End Class