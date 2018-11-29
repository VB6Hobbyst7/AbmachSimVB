Namespace abmach
    Public Class Help
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()
            Me.txtbx_help.Text = "Help is available by clicking on a control and pressing F1"
            Me.btn_help_ok.Focus()
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
        Friend WithEvents txtbx_help As System.Windows.Forms.TextBox
        Friend WithEvents btn_help_ok As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Help))
            Me.txtbx_help = New System.Windows.Forms.TextBox
            Me.btn_help_ok = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'txtbx_help
            '
            Me.txtbx_help.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.txtbx_help.Location = New System.Drawing.Point(0, 0)
            Me.txtbx_help.Multiline = True
            Me.txtbx_help.Name = "txtbx_help"
            Me.txtbx_help.ReadOnly = True
            Me.txtbx_help.Size = New System.Drawing.Size(288, 184)
            Me.txtbx_help.TabIndex = 0
            Me.txtbx_help.Text = ""
            '
            'btn_help_ok
            '
            Me.btn_help_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_help_ok.Location = New System.Drawing.Point(120, 208)
            Me.btn_help_ok.Name = "btn_help_ok"
            Me.btn_help_ok.Size = New System.Drawing.Size(56, 32)
            Me.btn_help_ok.TabIndex = 1
            Me.btn_help_ok.Text = "&OK"
            '
            'Help
            '
            Me.AcceptButton = Me.btn_help_ok
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 265)
            Me.ControlBox = False
            Me.Controls.Add(Me.btn_help_ok)
            Me.Controls.Add(Me.txtbx_help)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Help"
            Me.Text = "Help"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub btn_help_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_help_ok.Click
            Me.Close()
        End Sub
    End Class
End Namespace