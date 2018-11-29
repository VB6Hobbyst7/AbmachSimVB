Public Class RenumberForm
    Inherits System.Windows.Forms.Form
    Public lineNumberStart, lineNumberIncrement As Integer
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents startValue As System.Windows.Forms.TextBox
    Friend WithEvents incrementValue As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents okButton2 As System.Windows.Forms.Button
    Friend WithEvents cancelButton2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.startValue = New System.Windows.Forms.TextBox
        Me.incrementValue = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.okButton2 = New System.Windows.Forms.Button
        Me.cancelButton2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'startValue
        '
        Me.startValue.Location = New System.Drawing.Point(104, 24)
        Me.startValue.Name = "startValue"
        Me.startValue.Size = New System.Drawing.Size(40, 20)
        Me.startValue.TabIndex = 0
        Me.startValue.Text = "100"
        '
        'incrementValue
        '
        Me.incrementValue.Location = New System.Drawing.Point(104, 48)
        Me.incrementValue.Name = "incrementValue"
        Me.incrementValue.Size = New System.Drawing.Size(40, 20)
        Me.incrementValue.TabIndex = 1
        Me.incrementValue.Text = "10"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Starting Value"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Increment"
        '
        'okButton2
        '
        Me.okButton2.Location = New System.Drawing.Point(24, 80)
        Me.okButton2.Name = "okButton2"
        Me.okButton2.Size = New System.Drawing.Size(48, 23)
        Me.okButton2.TabIndex = 3
        Me.okButton2.Text = "OK"
        '
        'cancelButton2
        '
        Me.cancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancelButton2.Location = New System.Drawing.Point(104, 80)
        Me.cancelButton2.Name = "cancelButton2"
        Me.cancelButton2.Size = New System.Drawing.Size(48, 23)
        Me.cancelButton2.TabIndex = 3
        Me.cancelButton2.Text = "Cancel"
        '
        'RenumberForm
        '
        Me.AcceptButton = Me.okButton2
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cancelButton2
        Me.ClientSize = New System.Drawing.Size(184, 138)
        Me.ControlBox = False
        Me.Controls.Add(Me.okButton2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.incrementValue)
        Me.Controls.Add(Me.startValue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cancelButton2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "RenumberForm"
        Me.Text = "Renumber"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okButton2.Click

        lineNumberStart = CInt(Me.startValue.Text)
        lineNumberIncrement = CInt(Me.incrementValue.Text)

        Me.Close()

    End Sub

    Private Sub cancelButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton2.Click
        Me.Close()
    End Sub
End Class
