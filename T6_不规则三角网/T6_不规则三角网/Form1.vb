Public Class Form1
    Private Sub 导入数据ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导入数据ToolStripMenuItem.Click， ToolStripButton1.Click
        InputDataFile(New OpenFileDialog)
        If DataStr Is Nothing Then
            Exit Sub
        End If
        DataGridView1.DataSource = DataGrid1(TinDatas)
        ToolStripStatusLabel1.Text = "数据导入完成，请点击开始计算"
    End Sub

    Private Sub 计算ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 计算ToolStripMenuItem.Click， ToolStripButton7.Click
        If DataStr Is Nothing Then
            MsgBox("未导入数据,请导入后重试", 64, "警告")
            Exit Sub
        End If
        If Not TextBox1.Text = "" Then
            MsgBox("请勿重复计算")
            Exit Sub
        End If
        Run()
        V_()
        TextBox1.Text = Report()
        TabControl1.SelectedTab = TabPage3
        ToolStripStatusLabel1.Text = "数据计算完成"
        DrawOut()
    End Sub

    Private Sub 导出数据ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导出数据ToolStripMenuItem.Click, ToolStripButton2.Click
        If TextBox1.Text = "" Then
            MsgBox("未计算,请计算后后重试", 64, "警告")
            Exit Sub
        End If
        CmputRes = TextBox1.Text
        Call OutputRstuFile(New SaveFileDialog)
    End Sub

    Private Sub 刷新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新ToolStripMenuItem.Click
        Application.Restart()
    End Sub

    Private Sub 帮助ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 帮助ToolStripMenuItem.Click
        MsgBox("未更新", 64, "帮助")
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem.Click, 退出ToolStripMenuItem1.Click
        If MsgBox("确定退出程序吗？", vbYesNo + vbQuestion, "警告") = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click, 数据视图ToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click, 绘图视图ToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click, 报告视图ToolStripMenuItem.Click
        TabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub DXFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DXFToolStripMenuItem.Click
        If TextBox1.Text = "" Then
            MsgBox("未计算,请计算后后重试", 64, "警告")
            Exit Sub
        End If
        OutPutDXF()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click, BMPToolStripMenuItem.Click
        If TextBox1.Text = "" Then
            MsgBox("未计算,请计算后后重试", 64, "警告")
            Exit Sub
        End If
        SavePic()
    End Sub
    '绘制图形过程
    Public Sub DrawOut()    '绘图
        Dim DRAW_BITMAP As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim PenPoint As New Pen(Color.Red, 4)
        Dim b As New SolidBrush(Color.Black)
        Dim f As New Font("宋体", 10)
        Using g As Graphics = Graphics.FromImage(DRAW_BITMAP)
            For i = 0 To Tri1.Count - 1
                g.DrawLine(PenPoint, CInt((Tri1(i).P1.X - Xmin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((Tri1(i).P1.Y - Ymin()) / YHeight() * (PictureBox1.Height - 200)), CInt((Tri1(i).P2.X - Xmin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((Tri1(i).P2.Y - Ymin()) / YHeight() * (PictureBox1.Height - 200)))
                g.DrawLine(PenPoint, CInt((Tri1(i).P1.X - Xmin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((Tri1(i).P1.Y - Ymin()) / YHeight() * (PictureBox1.Height - 200)), CInt((Tri1(i).P3.X - Xmin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((Tri1(i).P3.Y - Ymin()) / YHeight() * (PictureBox1.Height - 200)))
                g.DrawLine(PenPoint, CInt((Tri1(i).P3.X - Xmin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((Tri1(i).P3.Y - Ymin()) / YHeight() * (PictureBox1.Height - 200)), CInt((Tri1(i).P2.X - Xmin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((Tri1(i).P2.Y - Ymin()) / YHeight() * (PictureBox1.Height - 200)))
            Next
            For i = 0 To TinDatas.Length - 1
                DrawPoint(g, PenPoint, CInt((TinDatas(i).X - Xmin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((TinDatas(i).Y - Ymin()) / YHeight() * (PictureBox1.Height - 200)))
                g.DrawString(TinDatas(i).Name, f, b, CInt((TinDatas(i).X - Xmin()) / XWidth() * (PictureBox1.Width - 200)) + 100, CInt((TinDatas(i).Y - Ymin()) / YHeight() * (PictureBox1.Height - 200)))
            Next
            PictureBox1.Image = DRAW_BITMAP
        End Using

        PenPoint.Dispose()

    End Sub
    '保存BPM
    Sub SavePic()
        Dim SFD As New SaveFileDialog
        SFD.Filter = "BMP格式(*.bmp)|*.bmp"
        If SFD.ShowDialog = DialogResult.OK Then
            PictureBox1.Image.Save(SFD.FileName)
            MsgBox("图片保存完成！", MsgBoxStyle.Information, "提示")
        End If
    End Sub

End Class
