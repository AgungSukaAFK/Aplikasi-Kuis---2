<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KuisForm
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
        Me.labIndex = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.boxPertanyaan = New System.Windows.Forms.RichTextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnSelesai = New System.Windows.Forms.Button()
        Me.opsiA = New System.Windows.Forms.RadioButton()
        Me.opsiB = New System.Windows.Forms.RadioButton()
        Me.opsiC = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'labIndex
        '
        Me.labIndex.AutoSize = True
        Me.labIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labIndex.Location = New System.Drawing.Point(316, 39)
        Me.labIndex.Name = "labIndex"
        Me.labIndex.Size = New System.Drawing.Size(58, 25)
        Me.labIndex.TabIndex = 0
        Me.labIndex.Text = "1/10"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(71, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 38)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Sebelumnya"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(441, 39)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(152, 38)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Selanjutnya"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'boxPertanyaan
        '
        Me.boxPertanyaan.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxPertanyaan.Location = New System.Drawing.Point(71, 99)
        Me.boxPertanyaan.Name = "boxPertanyaan"
        Me.boxPertanyaan.ReadOnly = True
        Me.boxPertanyaan.Size = New System.Drawing.Size(522, 228)
        Me.boxPertanyaan.TabIndex = 3
        Me.boxPertanyaan.Text = ""
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(71, 348)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(45, 38)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "A"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(71, 461)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(45, 38)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "B"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(71, 565)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(45, 38)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "C"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.Control
        Me.Button6.Location = New System.Drawing.Point(674, 41)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(106, 38)
        Me.Button6.TabIndex = 7
        Me.Button6.Text = "Batalkan"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'btnSelesai
        '
        Me.btnSelesai.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSelesai.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelesai.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSelesai.Location = New System.Drawing.Point(599, 269)
        Me.btnSelesai.Name = "btnSelesai"
        Me.btnSelesai.Size = New System.Drawing.Size(181, 58)
        Me.btnSelesai.TabIndex = 8
        Me.btnSelesai.Text = "Selesai"
        Me.btnSelesai.UseVisualStyleBackColor = False
        Me.btnSelesai.Visible = False
        '
        'opsiA
        '
        Me.opsiA.AutoSize = True
        Me.opsiA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opsiA.Location = New System.Drawing.Point(122, 354)
        Me.opsiA.Name = "opsiA"
        Me.opsiA.Size = New System.Drawing.Size(140, 28)
        Me.opsiA.TabIndex = 9
        Me.opsiA.TabStop = True
        Me.opsiA.Text = "RadioButton1"
        Me.opsiA.UseVisualStyleBackColor = True
        '
        'opsiB
        '
        Me.opsiB.AutoSize = True
        Me.opsiB.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opsiB.Location = New System.Drawing.Point(122, 467)
        Me.opsiB.Name = "opsiB"
        Me.opsiB.Size = New System.Drawing.Size(140, 28)
        Me.opsiB.TabIndex = 10
        Me.opsiB.TabStop = True
        Me.opsiB.Text = "RadioButton1"
        Me.opsiB.UseVisualStyleBackColor = True
        '
        'opsiC
        '
        Me.opsiC.AutoSize = True
        Me.opsiC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opsiC.Location = New System.Drawing.Point(122, 571)
        Me.opsiC.Name = "opsiC"
        Me.opsiC.Size = New System.Drawing.Size(140, 28)
        Me.opsiC.TabIndex = 11
        Me.opsiC.TabStop = True
        Me.opsiC.Text = "RadioButton1"
        Me.opsiC.UseVisualStyleBackColor = True
        '
        'KuisForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 661)
        Me.Controls.Add(Me.opsiC)
        Me.Controls.Add(Me.opsiB)
        Me.Controls.Add(Me.opsiA)
        Me.Controls.Add(Me.btnSelesai)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.boxPertanyaan)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.labIndex)
        Me.Name = "KuisForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KuisForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents labIndex As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents boxPertanyaan As RichTextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents btnSelesai As Button
    Friend WithEvents opsiA As RadioButton
    Friend WithEvents opsiB As RadioButton
    Friend WithEvents opsiC As RadioButton
End Class
