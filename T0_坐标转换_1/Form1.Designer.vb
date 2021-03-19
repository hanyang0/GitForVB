<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim MenuStrip1 As System.Windows.Forms.MenuStrip
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.菜单ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导出计算结果TXTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.导出绘图结果DXFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BMPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DXFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出程序ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.编辑ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.重新导入ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.计算ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帮助ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        MenuStrip1 = New System.Windows.Forms.MenuStrip()
        MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        MenuStrip1.AutoSize = False
        MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        MenuStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.菜单ToolStripMenuItem, Me.编辑ToolStripMenuItem, Me.数据ToolStripMenuItem, Me.帮助ToolStripMenuItem, Me.退出ToolStripMenuItem})
        MenuStrip1.Location = New System.Drawing.Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        MenuStrip1.Size = New System.Drawing.Size(1174, 40)
        MenuStrip1.Stretch = False
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        '
        '菜单ToolStripMenuItem
        '
        Me.菜单ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.导出计算结果TXTToolStripMenuItem, Me.导出绘图结果DXFToolStripMenuItem, Me.退出程序ToolStripMenuItem})
        Me.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem"
        Me.菜单ToolStripMenuItem.Size = New System.Drawing.Size(74, 40)
        Me.菜单ToolStripMenuItem.Text = "菜单"
        '
        '导出计算结果TXTToolStripMenuItem
        '
        Me.导出计算结果TXTToolStripMenuItem.Name = "导出计算结果TXTToolStripMenuItem"
        Me.导出计算结果TXTToolStripMenuItem.Size = New System.Drawing.Size(347, 38)
        Me.导出计算结果TXTToolStripMenuItem.Text = "导出计算结果（TXT）"
        '
        '导出绘图结果DXFToolStripMenuItem
        '
        Me.导出绘图结果DXFToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BMPToolStripMenuItem, Me.DXFToolStripMenuItem})
        Me.导出绘图结果DXFToolStripMenuItem.Name = "导出绘图结果DXFToolStripMenuItem"
        Me.导出绘图结果DXFToolStripMenuItem.Size = New System.Drawing.Size(347, 38)
        Me.导出绘图结果DXFToolStripMenuItem.Text = "导出绘图结果"
        '
        'BMPToolStripMenuItem
        '
        Me.BMPToolStripMenuItem.Name = "BMPToolStripMenuItem"
        Me.BMPToolStripMenuItem.Size = New System.Drawing.Size(165, 38)
        Me.BMPToolStripMenuItem.Text = "BMP"
        '
        'DXFToolStripMenuItem
        '
        Me.DXFToolStripMenuItem.Name = "DXFToolStripMenuItem"
        Me.DXFToolStripMenuItem.Size = New System.Drawing.Size(165, 38)
        Me.DXFToolStripMenuItem.Text = "DXF"
        '
        '退出程序ToolStripMenuItem
        '
        Me.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem"
        Me.退出程序ToolStripMenuItem.Size = New System.Drawing.Size(347, 38)
        Me.退出程序ToolStripMenuItem.Text = "退出程序"
        '
        '编辑ToolStripMenuItem
        '
        Me.编辑ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.重新导入ToolStripMenuItem})
        Me.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem"
        Me.编辑ToolStripMenuItem.Size = New System.Drawing.Size(74, 40)
        Me.编辑ToolStripMenuItem.Text = "编辑"
        '
        '重新导入ToolStripMenuItem
        '
        Me.重新导入ToolStripMenuItem.Name = "重新导入ToolStripMenuItem"
        Me.重新导入ToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.重新导入ToolStripMenuItem.Text = "重新导入"
        '
        '数据ToolStripMenuItem
        '
        Me.数据ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.计算ToolStripMenuItem})
        Me.数据ToolStripMenuItem.Name = "数据ToolStripMenuItem"
        Me.数据ToolStripMenuItem.Size = New System.Drawing.Size(74, 40)
        Me.数据ToolStripMenuItem.Text = "数据"
        '
        '计算ToolStripMenuItem
        '
        Me.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem"
        Me.计算ToolStripMenuItem.Size = New System.Drawing.Size(160, 38)
        Me.计算ToolStripMenuItem.Text = "计算"
        '
        '帮助ToolStripMenuItem
        '
        Me.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem"
        Me.帮助ToolStripMenuItem.Size = New System.Drawing.Size(74, 40)
        Me.帮助ToolStripMenuItem.Text = "帮助"
        '
        '退出ToolStripMenuItem
        '
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(74, 40)
        Me.退出ToolStripMenuItem.Text = "退出"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStrip1.CanOverflow = False
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 40)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1174, 30)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Microsoft YaHei UI", 6.0!)
        Me.ToolStripButton1.Image = Global.T0_坐标转换.My.Resources.Resources.打开
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(78, 27)
        Me.ToolStripButton1.Text = "导入"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Microsoft YaHei UI", 6.0!)
        Me.ToolStripButton2.Image = Global.T0_坐标转换.My.Resources.Resources.保存
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripButton2.Size = New System.Drawing.Size(78, 27)
        Me.ToolStripButton2.Text = "导出"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 30)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Microsoft YaHei UI", 6.0!)
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(94, 27)
        Me.ToolStripButton3.Text = "数据视图"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Font = New System.Drawing.Font("Microsoft YaHei UI", 6.0!)
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(94, 27)
        Me.ToolStripButton4.Text = "绘图视图"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Font = New System.Drawing.Font("Microsoft YaHei UI", 6.0!)
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(94, 27)
        Me.ToolStripButton5.Text = "结果视图"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 433)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1100, 114)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(637, 30)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(150, 60)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "计算"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(308, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 60)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "导入"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 73)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1150, 617)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(8, 8)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1134, 570)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "数据"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1060, 240)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(55, 187)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "-"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1060, 25)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 187)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Location = New System.Drawing.Point(15, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 180
        Me.DataGridView1.RowTemplate.Height = 37
        Me.DataGridView1.Size = New System.Drawing.Size(1038, 402)
        Me.DataGridView1.TabIndex = 4
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Location = New System.Drawing.Point(8, 8)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1134, 570)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "绘图"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(44, 30)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1053, 495)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TextBox1)
        Me.TabPage3.Location = New System.Drawing.Point(8, 8)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1134, 570)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "结果"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(23, 23)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(1087, 505)
        Me.TextBox1.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 693)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1174, 36)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 31)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(1159, 31)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = " "
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(0, 31)
        '
        'MainForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1174, 729)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "坐标转换"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 菜单ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 编辑ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 数据ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 帮助ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 退出ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Button3 As Button
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents 重新导入ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 计算ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 导出计算结果TXTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 导出绘图结果DXFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 退出程序ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents BMPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DXFToolStripMenuItem As ToolStripMenuItem
End Class
