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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导入数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导出报告ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导出图像ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.计算ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.横断面ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.纵断面ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.一键计算ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.绘图ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.帮助ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.计算ToolStripMenuItem, Me.绘图ToolStripMenuItem, Me.帮助ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1329, 42)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.导入数据ToolStripMenuItem, Me.导出报告ToolStripMenuItem, Me.导出图像ToolStripMenuItem, Me.ToolStripSeparator1, Me.退出ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(74, 38)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '导入数据ToolStripMenuItem
        '
        Me.导入数据ToolStripMenuItem.Name = "导入数据ToolStripMenuItem"
        Me.导入数据ToolStripMenuItem.Size = New System.Drawing.Size(268, 38)
        Me.导入数据ToolStripMenuItem.Text = "导入数据"
        '
        '导出报告ToolStripMenuItem
        '
        Me.导出报告ToolStripMenuItem.Name = "导出报告ToolStripMenuItem"
        Me.导出报告ToolStripMenuItem.Size = New System.Drawing.Size(268, 38)
        Me.导出报告ToolStripMenuItem.Text = "导出报告"
        '
        '导出图像ToolStripMenuItem
        '
        Me.导出图像ToolStripMenuItem.Name = "导出图像ToolStripMenuItem"
        Me.导出图像ToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.导出图像ToolStripMenuItem.Text = "导出图像"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(205, 6)
        '
        '退出ToolStripMenuItem
        '
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.退出ToolStripMenuItem.Text = "退出"
        '
        '计算ToolStripMenuItem
        '
        Me.计算ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.横断面ToolStripMenuItem, Me.纵断面ToolStripMenuItem, Me.一键计算ToolStripMenuItem})
        Me.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem"
        Me.计算ToolStripMenuItem.Size = New System.Drawing.Size(74, 38)
        Me.计算ToolStripMenuItem.Text = "计算"
        '
        '横断面ToolStripMenuItem
        '
        Me.横断面ToolStripMenuItem.Name = "横断面ToolStripMenuItem"
        Me.横断面ToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.横断面ToolStripMenuItem.Text = "横断面"
        '
        '纵断面ToolStripMenuItem
        '
        Me.纵断面ToolStripMenuItem.Name = "纵断面ToolStripMenuItem"
        Me.纵断面ToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.纵断面ToolStripMenuItem.Text = "纵断面"
        '
        '一键计算ToolStripMenuItem
        '
        Me.一键计算ToolStripMenuItem.Name = "一键计算ToolStripMenuItem"
        Me.一键计算ToolStripMenuItem.Size = New System.Drawing.Size(268, 38)
        Me.一键计算ToolStripMenuItem.Text = "一键计算"
        '
        '绘图ToolStripMenuItem
        '
        Me.绘图ToolStripMenuItem.Name = "绘图ToolStripMenuItem"
        Me.绘图ToolStripMenuItem.Size = New System.Drawing.Size(74, 35)
        Me.绘图ToolStripMenuItem.Text = "绘图"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 666)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1329, 36)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(110, 31)
        Me.ToolStripStatusLabel1.Text = "欢迎使用"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 42)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1329, 39)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.T10_纵横断面计算.My.Resources.Resources.打开
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton1.Text = "打开"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.T10_纵横断面计算.My.Resources.Resources.保存
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton2.Text = "保存"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Image = Global.T10_纵横断面计算.My.Resources.Resources.计算
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton3.Text = "计算"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.T10_纵横断面计算.My.Resources.Resources.绘图
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton4.Text = "绘图"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = Global.T10_纵横断面计算.My.Resources.Resources.放大
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton5.Text = "放大"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = Global.T10_纵横断面计算.My.Resources.Resources.缩小
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButton6.Text = "缩小"
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 81)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1312, 586)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(8, 8)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1296, 539)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "数据"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1140, 287)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(141, 82)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "计算"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1140, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(141, 82)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "导入"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(7, 7)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 37
        Me.DataGridView1.Size = New System.Drawing.Size(1108, 525)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Location = New System.Drawing.Point(8, 8)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1296, 539)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "绘图"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Location = New System.Drawing.Point(6, 6)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1284, 525)
        Me.TabControl2.TabIndex = 2
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(8, 39)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1268, 478)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "散点图"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(8, 39)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1445, 586)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "纵断面图"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(8, 39)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(1445, 586)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "横断面图"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button5)
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.TextBox1)
        Me.TabPage3.Location = New System.Drawing.Point(8, 8)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1296, 539)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "报告"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1130, 143)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(122, 122)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "复制"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1130, 281)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(122, 122)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "导出报告"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 7)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(1108, 525)
        Me.TextBox1.TabIndex = 0
        '
        '帮助ToolStripMenuItem
        '
        Me.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem"
        Me.帮助ToolStripMenuItem.Size = New System.Drawing.Size(74, 35)
        Me.帮助ToolStripMenuItem.Text = "帮助"
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1329, 702)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents 导入数据ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 导出报告ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 导出图像ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents 退出ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents 计算ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 横断面ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 纵断面ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 一键计算ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 绘图ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents 帮助ToolStripMenuItem As ToolStripMenuItem
End Class
