<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MENUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LAPORANToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KELUARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DATAGEJALAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DATAPENYAKITToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DATARULEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(1, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(638, 76)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SistemPakarMata.My.Resources.Resources.mata81
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MENUToolStripMenuItem, Me.LAPORANToolStripMenuItem, Me.KELUARToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(651, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MENUToolStripMenuItem
        '
        Me.MENUToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DATAGEJALAToolStripMenuItem, Me.DATAPENYAKITToolStripMenuItem, Me.DATARULEToolStripMenuItem})
        Me.MENUToolStripMenuItem.Name = "MENUToolStripMenuItem"
        Me.MENUToolStripMenuItem.Size = New System.Drawing.Size(96, 20)
        Me.MENUToolStripMenuItem.Text = "DATA MASTER"
        '
        'LAPORANToolStripMenuItem
        '
        Me.LAPORANToolStripMenuItem.Name = "LAPORANToolStripMenuItem"
        Me.LAPORANToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.LAPORANToolStripMenuItem.Text = "LAPORAN"
        '
        'KELUARToolStripMenuItem
        '
        Me.KELUARToolStripMenuItem.Name = "KELUARToolStripMenuItem"
        Me.KELUARToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.KELUARToolStripMenuItem.Text = "KELUAR"
        '
        'DATAGEJALAToolStripMenuItem
        '
        Me.DATAGEJALAToolStripMenuItem.Name = "DATAGEJALAToolStripMenuItem"
        Me.DATAGEJALAToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DATAGEJALAToolStripMenuItem.Text = "DATA GEJALA"
        '
        'DATAPENYAKITToolStripMenuItem
        '
        Me.DATAPENYAKITToolStripMenuItem.Name = "DATAPENYAKITToolStripMenuItem"
        Me.DATAPENYAKITToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DATAPENYAKITToolStripMenuItem.Text = "DATA PENYAKIT"
        '
        'DATARULEToolStripMenuItem
        '
        Me.DATARULEToolStripMenuItem.Name = "DATARULEToolStripMenuItem"
        Me.DATARULEToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DATARULEToolStripMenuItem.Text = "DATA RULE"
        '
        'FormMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 411)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Menu"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MENUToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DATAGEJALAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DATAPENYAKITToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DATARULEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LAPORANToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KELUARToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
