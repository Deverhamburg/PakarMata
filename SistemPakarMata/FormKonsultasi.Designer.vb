<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKonsultasi
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnama = New System.Windows.Forms.TextBox()
        Me.dgkonsultasi = New System.Windows.Forms.DataGridView()
        Me.btnproses = New System.Windows.Forms.Button()
        CType(Me.dgkonsultasi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nama"
        '
        'txtnama
        '
        Me.txtnama.Location = New System.Drawing.Point(77, 13)
        Me.txtnama.Name = "txtnama"
        Me.txtnama.Size = New System.Drawing.Size(333, 20)
        Me.txtnama.TabIndex = 1
        '
        'dgkonsultasi
        '
        Me.dgkonsultasi.AllowUserToAddRows = False
        Me.dgkonsultasi.AllowUserToDeleteRows = False
        Me.dgkonsultasi.AllowUserToResizeColumns = False
        Me.dgkonsultasi.AllowUserToResizeRows = False
        Me.dgkonsultasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgkonsultasi.Location = New System.Drawing.Point(12, 53)
        Me.dgkonsultasi.Name = "dgkonsultasi"
        Me.dgkonsultasi.Size = New System.Drawing.Size(598, 308)
        Me.dgkonsultasi.TabIndex = 2
        '
        'btnproses
        '
        Me.btnproses.Location = New System.Drawing.Point(15, 376)
        Me.btnproses.Name = "btnproses"
        Me.btnproses.Size = New System.Drawing.Size(75, 23)
        Me.btnproses.TabIndex = 3
        Me.btnproses.Text = "Proses"
        Me.btnproses.UseVisualStyleBackColor = True
        '
        'FormKonsultasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 411)
        Me.Controls.Add(Me.btnproses)
        Me.Controls.Add(Me.dgkonsultasi)
        Me.Controls.Add(Me.txtnama)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormKonsultasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Konsultasi"
        CType(Me.dgkonsultasi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtnama As System.Windows.Forms.TextBox
    Friend WithEvents dgkonsultasi As System.Windows.Forms.DataGridView
    Friend WithEvents btnproses As System.Windows.Forms.Button
End Class
