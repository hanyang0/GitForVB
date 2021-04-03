<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导入数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.导出报告ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导出绘图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BMPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DXFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.刷新ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.计算ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.刷新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帮助ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.数据视图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.绘图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.报告视图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帮助ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 662)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1237, 36)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(62, 31)
        Me.ToolStripStatusLabel1.Text = "欢迎"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.计算ToolStripMenuItem, Me.刷新ToolStripMenuItem, Me.帮助ToolStripMenuItem, Me.帮助ToolStripMenuItem1, Me.退出ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1237, 42)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.导入数据ToolStripMenuItem, Me.ToolStripSeparator2, Me.导出报告ToolStripMenuItem, Me.导出绘图ToolStripMenuItem, Me.ToolStripSeparator3, Me.刷新ToolStripMenuItem1, Me.退出ToolStripMenuItem1})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(74, 38)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '导入数据ToolStripMenuItem
        '
        Me.导入数据ToolStripMenuItem.Name = "导入数据ToolStripMenuItem"
        Me.导入数据ToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.导入数据ToolStripMenuItem.Text = "导入数据"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(205, 6)
        '
        '导出报告ToolStripMenuItem
        '
        Me.导出报告ToolStripMenuItem.Name = "导出报告ToolStripMenuItem"
        Me.导出报告ToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.导出报告ToolStripMenuItem.Text = "导出报告"
        '
        '导出绘图ToolStripMenuItem
        '
        Me.导出绘图ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BMPToolStripMenuItem, Me.DXFToolStripMenuItem})
        Me.导出绘图ToolStripMenuItem.Name = "导出绘图ToolStripMenuItem"
        Me.导出绘图ToolStripMenuItem.Size = New System.Drawing.Size(268, 38)
        Me.导出绘图ToolStripMenuItem.Text = "导出绘图"
        '
        'BMPToolStripMenuItem
        '
        Me.BMPToolStripMenuItem.Name = "BMPToolStripMenuItem"
        Me.BMPToolStripMenuItem.Size = New System.Drawing.Size(268, 38)
        Me.BMPToolStripMenuItem.Text = "BMP"
        '
        'DXFToolStripMenuItem
        '
        Me.DXFToolStripMenuItem.Name = "DXFToolStripMenuItem"
        Me.DXFToolStripMenuItem.Size = New System.Drawing.Size(165, 38)
        Me.DXFToolStripMenuItem.Text = "DXF"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(205, 6)
        '
        '刷新ToolStripMenuItem1
        '
        Me.刷新ToolStripMenuItem1.Name = "刷新ToolStripMenuItem1"
        Me.刷新ToolStripMenuItem1.Size = New System.Drawing.Size(208, 38)
        Me.刷新ToolStripMenuItem1.Text = "刷新"
        '
        '退出ToolStripMenuItem1
        '
        Me.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1"
        Me.退出ToolStripMenuItem1.Size = New System.Drawing.Size(208, 38)
        Me.退出ToolStripMenuItem1.Text = "退出"
        '
        '计算ToolStripMenuItem
        '
        Me.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem"
        Me.计算ToolStripMenuItem.Size = New System.Drawing.Size(74, 35)
        Me.计算ToolStripMenuItem.Text = "计算"
        '
        '刷新ToolStripMenuItem
        '
        Me.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem"
        Me.刷新ToolStripMenuItem.Size = New System.Drawing.Size(74, 35)
        Me.刷新ToolStripMenuItem.Text = "刷新"
        '
        '帮助ToolStripMenuItem
        '
        Me.帮助ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.数据视图ToolStripMenuItem, Me.绘图ToolStripMenuItem, Me.报告视图ToolStripMenuItem})
        Me.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem"
        Me.帮助ToolStripMenuItem.Size = New System.Drawing.Size(74, 35)
        Me.帮助ToolStripMenuItem.Text = "视图"
        '
        '数据视图ToolStripMenuItem
        '
        Me.数据视图ToolStripMenuItem.Name = "数据视图ToolStripMenuItem"
        Me.数据视图ToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.数据视图ToolStripMenuItem.Text = "数据视图"
        '
        '绘图ToolStripMenuItem
        '
        Me.绘图ToolStripMenuItem.Name = "绘图ToolStripMenuItem"
        Me.绘图ToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.绘图ToolStripMenuItem.Text = "绘图视图"
        '
        '报告视图ToolStripMenuItem
        '
        Me.报告视图ToolStripMenuItem.Name = "报告视图ToolStripMenuItem"
        Me.报告视图ToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.报告视图ToolStripMenuItem.Text = "报告视图"
        '
        '帮助ToolStripMenuItem1
        '
        Me.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1"
        Me.帮助ToolStripMenuItem1.Size = New System.Drawing.Size(74, 35)
        Me.帮助ToolStripMenuItem1.Text = "帮助"
        '
        '退出ToolStripMenuItem
        '
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(74, 35)
        Me.退出ToolStripMenuItem.Text = "退出"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator4, Me.ToolStripButton7, Me.ToolStripSeparator1, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 42)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1237, 39)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.T7_线路曲线要素.My.Resources.Resources.打开1
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton1.Text = "打开"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.T7_线路曲线要素.My.Resources.Resources.T
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(146, 36)
        Me.ToolStripButton2.Text = "保存报告"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.T7_线路曲线要素.My.Resources.Resources.pic
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(146, 36)
        Me.ToolStripButton3.Text = "保存图片"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Image = Global.T7_线路曲线要素.My.Resources.Resources.计算
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton7.Text = "计算"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.T7_线路曲线要素.My.Resources.Resources.Table
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton4.Text = "数据"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.T7_线路曲线要素.My.Resources.Resources.pic
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton5.Text = "绘图"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = Global.T7_线路曲线要素.My.Resources.Resources.rep
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton6.Text = "报告"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 81)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1213, 578)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(8, 39)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1197, 531)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "数据"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(17, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 37
        Me.DataGridView1.Size = New System.Drawing.Size(1166, 498)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PictureBox1)
        Me.TabPage2.Location = New System.Drawing.Point(8, 39)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1197, 531)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "绘图"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(24, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1135, 484)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TextBox1)
        Me.TabPage3.Location = New System.Drawing.Point(8, 39)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1197, 531)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "报告"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(20, 18)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(1158, 485)
        Me.TextBox1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1237, 698)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "T7_线路曲线要素计算"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 计算ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 刷新ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 帮助ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 数据视图ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 绘图ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 帮助ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 退出ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents 导入数据ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents 导出报告ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 导出绘图ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BMPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DXFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents 刷新ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 退出ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 报告视图ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripButton7 As ToolStripButton
End Class
