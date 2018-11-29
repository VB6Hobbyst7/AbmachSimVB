<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShiftProgForm
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
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.TextBoxX = New System.Windows.Forms.TextBox()
        Me.TextBoxZ = New System.Windows.Forms.TextBox()
        Me.TextBoxY = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(557, 354)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 0
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(430, 354)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 1
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'TextBoxX
        '
        Me.TextBoxX.Location = New System.Drawing.Point(197, 40)
        Me.TextBoxX.Name = "TextBoxX"
        Me.TextBoxX.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxX.TabIndex = 2
        Me.TextBoxX.Text = "0"
        '
        'TextBoxZ
        '
        Me.TextBoxZ.Location = New System.Drawing.Point(197, 113)
        Me.TextBoxZ.Name = "TextBoxZ"
        Me.TextBoxZ.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxZ.TabIndex = 3
        Me.TextBoxZ.Text = "0"
        '
        'TextBoxY
        '
        Me.TextBoxY.Location = New System.Drawing.Point(197, 77)
        Me.TextBoxY.Name = "TextBoxY"
        Me.TextBoxY.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxY.TabIndex = 4
        Me.TextBoxY.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(152, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "X:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(152, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Z:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(152, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Y:"
        '
        'ShiftProgForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 389)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxY)
        Me.Controls.Add(Me.TextBoxZ)
        Me.Controls.Add(Me.TextBoxX)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Name = "ShiftProgForm"
        Me.Text = "ShiftProgForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents TextBoxX As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxZ As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxY As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
