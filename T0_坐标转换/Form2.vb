Public Class Form2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedIndex + 1 <> 0 Then
            MainForm.ModeSet = ListBox1.SelectedIndex + 1
            MainForm.ModeSetName = ListBox1.SelectedItem.ToString
            MainForm.ToolStripStatusLabel1.Text = "模式选择完成请单击导入按钮开始导入数据"
            MainForm.ToolStripStatusLabel3.Text = MainForm.ModeSetName & "模式"
            Me.Hide()
            MainForm.ModeEvent1.StartEvent()
        End If
    End Sub
End Class
