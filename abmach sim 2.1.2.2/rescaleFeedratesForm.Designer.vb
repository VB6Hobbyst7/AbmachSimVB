<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rescaleFeedratesForm
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
        Me.TextBoxStartLineNum = New System.Windows.Forms.TextBox()
        Me.TextBoxEndLineNum = New System.Windows.Forms.TextBox()
        Me.TextBoxScaleFactor = New System.Windows.Forms.TextBox()
        Me.RadioButtonAllLines = New System.Windows.Forms.RadioButton()
        Me.RadioButtonRange = New System.Windows.Forms.RadioButton()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.LabelFirstLine = New System.Windows.Forms.Label()
        Me.LabelLastLine = New System.Windows.Forms.Label()
        Me.LabelFactor = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBoxStartLineNum
        '
        Me.TextBoxStartLineNum.Location = New System.Drawing.Point(155, 75)
        Me.TextBoxStartLineNum.Name = "TextBoxStartLineNum"
        Me.TextBoxStartLineNum.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxStartLineNum.TabIndex = 1
        '
        'TextBoxEndLineNum
        '
        Me.TextBoxEndLineNum.Location = New System.Drawing.Point(155, 101)
        Me.TextBoxEndLineNum.Name = "TextBoxEndLineNum"
        Me.TextBoxEndLineNum.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxEndLineNum.TabIndex = 2
        '
        'TextBoxScaleFactor
        '
        Me.TextBoxScaleFactor.Location = New System.Drawing.Point(155, 146)
        Me.TextBoxScaleFactor.Name = "TextBoxScaleFactor"
        Me.TextBoxScaleFactor.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxScaleFactor.TabIndex = 3
        '
        'RadioButtonAllLines
        '
        Me.RadioButtonAllLines.AutoSize = True
        Me.RadioButtonAllLines.Checked = True
        Me.RadioButtonAllLines.Location = New System.Drawing.Point(34, 21)
        Me.RadioButtonAllLines.Name = "RadioButtonAllLines"
        Me.RadioButtonAllLines.Size = New System.Drawing.Size(64, 17)
        Me.RadioButtonAllLines.TabIndex = 4
        Me.RadioButtonAllLines.TabStop = True
        Me.RadioButtonAllLines.Text = "All Lines"
        Me.RadioButtonAllLines.UseVisualStyleBackColor = True
        '
        'RadioButtonRange
        '
        Me.RadioButtonRange.AutoSize = True
        Me.RadioButtonRange.Location = New System.Drawing.Point(34, 44)
        Me.RadioButtonRange.Name = "RadioButtonRange"
        Me.RadioButtonRange.Size = New System.Drawing.Size(57, 17)
        Me.RadioButtonRange.TabIndex = 5
        Me.RadioButtonRange.TabStop = True
        Me.RadioButtonRange.Text = "Range"
        Me.RadioButtonRange.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Location = New System.Drawing.Point(34, 207)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 6
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(164, 207)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 6
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'LabelFirstLine
        '
        Me.LabelFirstLine.AutoSize = True
        Me.LabelFirstLine.Location = New System.Drawing.Point(60, 78)
        Me.LabelFirstLine.Name = "LabelFirstLine"
        Me.LabelFirstLine.Size = New System.Drawing.Size(49, 13)
        Me.LabelFirstLine.TabIndex = 7
        Me.LabelFirstLine.Text = "First Line"
        '
        'LabelLastLine
        '
        Me.LabelLastLine.AutoSize = True
        Me.LabelLastLine.Location = New System.Drawing.Point(60, 104)
        Me.LabelLastLine.Name = "LabelLastLine"
        Me.LabelLastLine.Size = New System.Drawing.Size(50, 13)
        Me.LabelLastLine.TabIndex = 7
        Me.LabelLastLine.Text = "Last Line"
        '
        'LabelFactor
        '
        Me.LabelFactor.AutoSize = True
        Me.LabelFactor.Location = New System.Drawing.Point(60, 149)
        Me.LabelFactor.Name = "LabelFactor"
        Me.LabelFactor.Size = New System.Drawing.Size(67, 13)
        Me.LabelFactor.TabIndex = 7
        Me.LabelFactor.Text = "Scale Factor"
        '
        'rescaleFeedratesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.LabelFactor)
        Me.Controls.Add(Me.LabelLastLine)
        Me.Controls.Add(Me.LabelFirstLine)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.RadioButtonRange)
        Me.Controls.Add(Me.RadioButtonAllLines)
        Me.Controls.Add(Me.TextBoxScaleFactor)
        Me.Controls.Add(Me.TextBoxEndLineNum)
        Me.Controls.Add(Me.TextBoxStartLineNum)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "rescaleFeedratesForm"
        Me.Text = "Rescale Feedrates"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxStartLineNum As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEndLineNum As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxScaleFactor As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonAllLines As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonRange As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents LabelFirstLine As System.Windows.Forms.Label
    Friend WithEvents LabelLastLine As System.Windows.Forms.Label
    Friend WithEvents LabelFactor As System.Windows.Forms.Label
End Class
