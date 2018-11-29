Imports System.Xml
Imports System.IO
Namespace abmach

    Public Class parminput

        Inherits System.Windows.Forms.Form
        Dim sdir As String = Path.GetDirectoryName(Application.ExecutablePath)

        Dim oldparmfile As String = "old" & parminputxmlfile
        Dim sparmxmlfilepath As String = sdir & System.IO.Path.DirectorySeparatorChar & parminputxmlfile
        Dim oldparmxmlfilepath As String = sdir & Path.DirectorySeparatorChar & oldparmfile
        Dim newparameter As Boolean

        Dim test_depth As Double = 0
        Dim test_speed As Double = 0
        Dim test_passes As Integer = 0


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
        Friend WithEvents nomdepth As System.Windows.Forms.TextBox
        Friend WithEvents matthickness As System.Windows.Forms.TextBox
        Friend WithEvents defjetdiam As System.Windows.Forms.TextBox
        Friend WithEvents depthperrun As System.Windows.Forms.TextBox
        Friend WithEvents nomfeedrate As System.Windows.Forms.TextBox
        Friend WithEvents number_of_runs As System.Windows.Forms.TextBox
        Friend WithEvents thetacrit As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents load_parms As System.Windows.Forms.Button
        Friend WithEvents cancel_load As System.Windows.Forms.Button
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents depthtolerance As System.Windows.Forms.TextBox
        Friend WithEvents Groovedir As System.Windows.Forms.ListBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents testdepth As System.Windows.Forms.TextBox
        Friend WithEvents testspeed As System.Windows.Forms.TextBox
        Friend WithEvents testpasses As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents mrr_type As System.Windows.Forms.TextBox
        Friend WithEvents armradius As System.Windows.Forms.TextBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents lstbxoperation As System.Windows.Forms.ListBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents txtmtlength As System.Windows.Forms.TextBox
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents txtjeweldiameter As System.Windows.Forms.TextBox
        Friend WithEvents txtabflow As System.Windows.Forms.TextBox
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents txtmtdiameter As System.Windows.Forms.TextBox
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents txtpressure As System.Windows.Forms.TextBox
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents Label25 As System.Windows.Forms.Label
        Friend WithEvents Label26 As System.Windows.Forms.Label
        Friend WithEvents txtsod As System.Windows.Forms.TextBox
        Friend WithEvents cbo_pump As System.Windows.Forms.ComboBox
        Friend WithEvents cbo_abrasivetype As System.Windows.Forms.ComboBox
        Friend WithEvents cbo_machine As System.Windows.Forms.ComboBox
        Friend WithEvents cbo_nozzletype As System.Windows.Forms.ComboBox
        Friend WithEvents cbo_jeweltype As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(parminput))
            Me.nomdepth = New System.Windows.Forms.TextBox
            Me.matthickness = New System.Windows.Forms.TextBox
            Me.defjetdiam = New System.Windows.Forms.TextBox
            Me.depthperrun = New System.Windows.Forms.TextBox
            Me.nomfeedrate = New System.Windows.Forms.TextBox
            Me.number_of_runs = New System.Windows.Forms.TextBox
            Me.thetacrit = New System.Windows.Forms.TextBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.Label4 = New System.Windows.Forms.Label
            Me.Label5 = New System.Windows.Forms.Label
            Me.Label6 = New System.Windows.Forms.Label
            Me.Label7 = New System.Windows.Forms.Label
            Me.Label8 = New System.Windows.Forms.Label
            Me.load_parms = New System.Windows.Forms.Button
            Me.cancel_load = New System.Windows.Forms.Button
            Me.depthtolerance = New System.Windows.Forms.TextBox
            Me.Label9 = New System.Windows.Forms.Label
            Me.Groovedir = New System.Windows.Forms.ListBox
            Me.Label10 = New System.Windows.Forms.Label
            Me.testdepth = New System.Windows.Forms.TextBox
            Me.testspeed = New System.Windows.Forms.TextBox
            Me.testpasses = New System.Windows.Forms.TextBox
            Me.Label11 = New System.Windows.Forms.Label
            Me.Label12 = New System.Windows.Forms.Label
            Me.Label13 = New System.Windows.Forms.Label
            Me.mrr_type = New System.Windows.Forms.TextBox
            Me.armradius = New System.Windows.Forms.TextBox
            Me.Label14 = New System.Windows.Forms.Label
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.lstbxoperation = New System.Windows.Forms.ListBox
            Me.Label15 = New System.Windows.Forms.Label
            Me.txtmtlength = New System.Windows.Forms.TextBox
            Me.Label16 = New System.Windows.Forms.Label
            Me.txtjeweldiameter = New System.Windows.Forms.TextBox
            Me.txtabflow = New System.Windows.Forms.TextBox
            Me.Label17 = New System.Windows.Forms.Label
            Me.Label18 = New System.Windows.Forms.Label
            Me.txtmtdiameter = New System.Windows.Forms.TextBox
            Me.Label19 = New System.Windows.Forms.Label
            Me.Label20 = New System.Windows.Forms.Label
            Me.Label21 = New System.Windows.Forms.Label
            Me.Label22 = New System.Windows.Forms.Label
            Me.txtpressure = New System.Windows.Forms.TextBox
            Me.Label23 = New System.Windows.Forms.Label
            Me.Label24 = New System.Windows.Forms.Label
            Me.Label25 = New System.Windows.Forms.Label
            Me.Label26 = New System.Windows.Forms.Label
            Me.txtsod = New System.Windows.Forms.TextBox
            Me.cbo_pump = New System.Windows.Forms.ComboBox
            Me.cbo_abrasivetype = New System.Windows.Forms.ComboBox
            Me.cbo_machine = New System.Windows.Forms.ComboBox
            Me.cbo_nozzletype = New System.Windows.Forms.ComboBox
            Me.cbo_jeweltype = New System.Windows.Forms.ComboBox
            Me.SuspendLayout()
            '
            'nomdepth
            '
            Me.nomdepth.AccessibleDescription = resources.GetString("nomdepth.AccessibleDescription")
            Me.nomdepth.AccessibleName = resources.GetString("nomdepth.AccessibleName")
            Me.nomdepth.Anchor = CType(resources.GetObject("nomdepth.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.nomdepth.AutoSize = CType(resources.GetObject("nomdepth.AutoSize"), Boolean)
            Me.nomdepth.BackgroundImage = CType(resources.GetObject("nomdepth.BackgroundImage"), System.Drawing.Image)
            Me.nomdepth.Dock = CType(resources.GetObject("nomdepth.Dock"), System.Windows.Forms.DockStyle)
            Me.nomdepth.Enabled = CType(resources.GetObject("nomdepth.Enabled"), Boolean)
            Me.nomdepth.Font = CType(resources.GetObject("nomdepth.Font"), System.Drawing.Font)
            Me.nomdepth.ImeMode = CType(resources.GetObject("nomdepth.ImeMode"), System.Windows.Forms.ImeMode)
            Me.nomdepth.Location = CType(resources.GetObject("nomdepth.Location"), System.Drawing.Point)
            Me.nomdepth.MaxLength = CType(resources.GetObject("nomdepth.MaxLength"), Integer)
            Me.nomdepth.Multiline = CType(resources.GetObject("nomdepth.Multiline"), Boolean)
            Me.nomdepth.Name = "nomdepth"
            Me.nomdepth.PasswordChar = CType(resources.GetObject("nomdepth.PasswordChar"), Char)
            Me.nomdepth.RightToLeft = CType(resources.GetObject("nomdepth.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.nomdepth.ScrollBars = CType(resources.GetObject("nomdepth.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.nomdepth.Size = CType(resources.GetObject("nomdepth.Size"), System.Drawing.Size)
            Me.nomdepth.TabIndex = CType(resources.GetObject("nomdepth.TabIndex"), Integer)
            Me.nomdepth.Text = resources.GetString("nomdepth.Text")
            Me.nomdepth.TextAlign = CType(resources.GetObject("nomdepth.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.nomdepth, resources.GetString("nomdepth.ToolTip"))
            Me.nomdepth.Visible = CType(resources.GetObject("nomdepth.Visible"), Boolean)
            Me.nomdepth.WordWrap = CType(resources.GetObject("nomdepth.WordWrap"), Boolean)
            '
            'matthickness
            '
            Me.matthickness.AccessibleDescription = resources.GetString("matthickness.AccessibleDescription")
            Me.matthickness.AccessibleName = resources.GetString("matthickness.AccessibleName")
            Me.matthickness.Anchor = CType(resources.GetObject("matthickness.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.matthickness.AutoSize = CType(resources.GetObject("matthickness.AutoSize"), Boolean)
            Me.matthickness.BackgroundImage = CType(resources.GetObject("matthickness.BackgroundImage"), System.Drawing.Image)
            Me.matthickness.Dock = CType(resources.GetObject("matthickness.Dock"), System.Windows.Forms.DockStyle)
            Me.matthickness.Enabled = CType(resources.GetObject("matthickness.Enabled"), Boolean)
            Me.matthickness.Font = CType(resources.GetObject("matthickness.Font"), System.Drawing.Font)
            Me.matthickness.ImeMode = CType(resources.GetObject("matthickness.ImeMode"), System.Windows.Forms.ImeMode)
            Me.matthickness.Location = CType(resources.GetObject("matthickness.Location"), System.Drawing.Point)
            Me.matthickness.MaxLength = CType(resources.GetObject("matthickness.MaxLength"), Integer)
            Me.matthickness.Multiline = CType(resources.GetObject("matthickness.Multiline"), Boolean)
            Me.matthickness.Name = "matthickness"
            Me.matthickness.PasswordChar = CType(resources.GetObject("matthickness.PasswordChar"), Char)
            Me.matthickness.RightToLeft = CType(resources.GetObject("matthickness.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.matthickness.ScrollBars = CType(resources.GetObject("matthickness.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.matthickness.Size = CType(resources.GetObject("matthickness.Size"), System.Drawing.Size)
            Me.matthickness.TabIndex = CType(resources.GetObject("matthickness.TabIndex"), Integer)
            Me.matthickness.Text = resources.GetString("matthickness.Text")
            Me.matthickness.TextAlign = CType(resources.GetObject("matthickness.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.matthickness, resources.GetString("matthickness.ToolTip"))
            Me.matthickness.Visible = CType(resources.GetObject("matthickness.Visible"), Boolean)
            Me.matthickness.WordWrap = CType(resources.GetObject("matthickness.WordWrap"), Boolean)
            '
            'defjetdiam
            '
            Me.defjetdiam.AccessibleDescription = resources.GetString("defjetdiam.AccessibleDescription")
            Me.defjetdiam.AccessibleName = resources.GetString("defjetdiam.AccessibleName")
            Me.defjetdiam.Anchor = CType(resources.GetObject("defjetdiam.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.defjetdiam.AutoSize = CType(resources.GetObject("defjetdiam.AutoSize"), Boolean)
            Me.defjetdiam.BackgroundImage = CType(resources.GetObject("defjetdiam.BackgroundImage"), System.Drawing.Image)
            Me.defjetdiam.Dock = CType(resources.GetObject("defjetdiam.Dock"), System.Windows.Forms.DockStyle)
            Me.defjetdiam.Enabled = CType(resources.GetObject("defjetdiam.Enabled"), Boolean)
            Me.defjetdiam.Font = CType(resources.GetObject("defjetdiam.Font"), System.Drawing.Font)
            Me.defjetdiam.ImeMode = CType(resources.GetObject("defjetdiam.ImeMode"), System.Windows.Forms.ImeMode)
            Me.defjetdiam.Location = CType(resources.GetObject("defjetdiam.Location"), System.Drawing.Point)
            Me.defjetdiam.MaxLength = CType(resources.GetObject("defjetdiam.MaxLength"), Integer)
            Me.defjetdiam.Multiline = CType(resources.GetObject("defjetdiam.Multiline"), Boolean)
            Me.defjetdiam.Name = "defjetdiam"
            Me.defjetdiam.PasswordChar = CType(resources.GetObject("defjetdiam.PasswordChar"), Char)
            Me.defjetdiam.RightToLeft = CType(resources.GetObject("defjetdiam.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.defjetdiam.ScrollBars = CType(resources.GetObject("defjetdiam.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.defjetdiam.Size = CType(resources.GetObject("defjetdiam.Size"), System.Drawing.Size)
            Me.defjetdiam.TabIndex = CType(resources.GetObject("defjetdiam.TabIndex"), Integer)
            Me.defjetdiam.Text = resources.GetString("defjetdiam.Text")
            Me.defjetdiam.TextAlign = CType(resources.GetObject("defjetdiam.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.defjetdiam, resources.GetString("defjetdiam.ToolTip"))
            Me.defjetdiam.Visible = CType(resources.GetObject("defjetdiam.Visible"), Boolean)
            Me.defjetdiam.WordWrap = CType(resources.GetObject("defjetdiam.WordWrap"), Boolean)
            '
            'depthperrun
            '
            Me.depthperrun.AccessibleDescription = resources.GetString("depthperrun.AccessibleDescription")
            Me.depthperrun.AccessibleName = resources.GetString("depthperrun.AccessibleName")
            Me.depthperrun.Anchor = CType(resources.GetObject("depthperrun.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.depthperrun.AutoSize = CType(resources.GetObject("depthperrun.AutoSize"), Boolean)
            Me.depthperrun.BackgroundImage = CType(resources.GetObject("depthperrun.BackgroundImage"), System.Drawing.Image)
            Me.depthperrun.Dock = CType(resources.GetObject("depthperrun.Dock"), System.Windows.Forms.DockStyle)
            Me.depthperrun.Enabled = CType(resources.GetObject("depthperrun.Enabled"), Boolean)
            Me.depthperrun.Font = CType(resources.GetObject("depthperrun.Font"), System.Drawing.Font)
            Me.depthperrun.ImeMode = CType(resources.GetObject("depthperrun.ImeMode"), System.Windows.Forms.ImeMode)
            Me.depthperrun.Location = CType(resources.GetObject("depthperrun.Location"), System.Drawing.Point)
            Me.depthperrun.MaxLength = CType(resources.GetObject("depthperrun.MaxLength"), Integer)
            Me.depthperrun.Multiline = CType(resources.GetObject("depthperrun.Multiline"), Boolean)
            Me.depthperrun.Name = "depthperrun"
            Me.depthperrun.PasswordChar = CType(resources.GetObject("depthperrun.PasswordChar"), Char)
            Me.depthperrun.RightToLeft = CType(resources.GetObject("depthperrun.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.depthperrun.ScrollBars = CType(resources.GetObject("depthperrun.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.depthperrun.Size = CType(resources.GetObject("depthperrun.Size"), System.Drawing.Size)
            Me.depthperrun.TabIndex = CType(resources.GetObject("depthperrun.TabIndex"), Integer)
            Me.depthperrun.Text = resources.GetString("depthperrun.Text")
            Me.depthperrun.TextAlign = CType(resources.GetObject("depthperrun.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.depthperrun, resources.GetString("depthperrun.ToolTip"))
            Me.depthperrun.Visible = CType(resources.GetObject("depthperrun.Visible"), Boolean)
            Me.depthperrun.WordWrap = CType(resources.GetObject("depthperrun.WordWrap"), Boolean)
            '
            'nomfeedrate
            '
            Me.nomfeedrate.AccessibleDescription = resources.GetString("nomfeedrate.AccessibleDescription")
            Me.nomfeedrate.AccessibleName = resources.GetString("nomfeedrate.AccessibleName")
            Me.nomfeedrate.Anchor = CType(resources.GetObject("nomfeedrate.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.nomfeedrate.AutoSize = CType(resources.GetObject("nomfeedrate.AutoSize"), Boolean)
            Me.nomfeedrate.BackgroundImage = CType(resources.GetObject("nomfeedrate.BackgroundImage"), System.Drawing.Image)
            Me.nomfeedrate.Dock = CType(resources.GetObject("nomfeedrate.Dock"), System.Windows.Forms.DockStyle)
            Me.nomfeedrate.Enabled = CType(resources.GetObject("nomfeedrate.Enabled"), Boolean)
            Me.nomfeedrate.Font = CType(resources.GetObject("nomfeedrate.Font"), System.Drawing.Font)
            Me.nomfeedrate.ImeMode = CType(resources.GetObject("nomfeedrate.ImeMode"), System.Windows.Forms.ImeMode)
            Me.nomfeedrate.Location = CType(resources.GetObject("nomfeedrate.Location"), System.Drawing.Point)
            Me.nomfeedrate.MaxLength = CType(resources.GetObject("nomfeedrate.MaxLength"), Integer)
            Me.nomfeedrate.Multiline = CType(resources.GetObject("nomfeedrate.Multiline"), Boolean)
            Me.nomfeedrate.Name = "nomfeedrate"
            Me.nomfeedrate.PasswordChar = CType(resources.GetObject("nomfeedrate.PasswordChar"), Char)
            Me.nomfeedrate.RightToLeft = CType(resources.GetObject("nomfeedrate.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.nomfeedrate.ScrollBars = CType(resources.GetObject("nomfeedrate.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.nomfeedrate.Size = CType(resources.GetObject("nomfeedrate.Size"), System.Drawing.Size)
            Me.nomfeedrate.TabIndex = CType(resources.GetObject("nomfeedrate.TabIndex"), Integer)
            Me.nomfeedrate.Text = resources.GetString("nomfeedrate.Text")
            Me.nomfeedrate.TextAlign = CType(resources.GetObject("nomfeedrate.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.nomfeedrate, resources.GetString("nomfeedrate.ToolTip"))
            Me.nomfeedrate.Visible = CType(resources.GetObject("nomfeedrate.Visible"), Boolean)
            Me.nomfeedrate.WordWrap = CType(resources.GetObject("nomfeedrate.WordWrap"), Boolean)
            '
            'number_of_runs
            '
            Me.number_of_runs.AccessibleDescription = resources.GetString("number_of_runs.AccessibleDescription")
            Me.number_of_runs.AccessibleName = resources.GetString("number_of_runs.AccessibleName")
            Me.number_of_runs.Anchor = CType(resources.GetObject("number_of_runs.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.number_of_runs.AutoSize = CType(resources.GetObject("number_of_runs.AutoSize"), Boolean)
            Me.number_of_runs.BackgroundImage = CType(resources.GetObject("number_of_runs.BackgroundImage"), System.Drawing.Image)
            Me.number_of_runs.Dock = CType(resources.GetObject("number_of_runs.Dock"), System.Windows.Forms.DockStyle)
            Me.number_of_runs.Enabled = CType(resources.GetObject("number_of_runs.Enabled"), Boolean)
            Me.number_of_runs.Font = CType(resources.GetObject("number_of_runs.Font"), System.Drawing.Font)
            Me.number_of_runs.ImeMode = CType(resources.GetObject("number_of_runs.ImeMode"), System.Windows.Forms.ImeMode)
            Me.number_of_runs.Location = CType(resources.GetObject("number_of_runs.Location"), System.Drawing.Point)
            Me.number_of_runs.MaxLength = CType(resources.GetObject("number_of_runs.MaxLength"), Integer)
            Me.number_of_runs.Multiline = CType(resources.GetObject("number_of_runs.Multiline"), Boolean)
            Me.number_of_runs.Name = "number_of_runs"
            Me.number_of_runs.PasswordChar = CType(resources.GetObject("number_of_runs.PasswordChar"), Char)
            Me.number_of_runs.RightToLeft = CType(resources.GetObject("number_of_runs.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.number_of_runs.ScrollBars = CType(resources.GetObject("number_of_runs.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.number_of_runs.Size = CType(resources.GetObject("number_of_runs.Size"), System.Drawing.Size)
            Me.number_of_runs.TabIndex = CType(resources.GetObject("number_of_runs.TabIndex"), Integer)
            Me.number_of_runs.Text = resources.GetString("number_of_runs.Text")
            Me.number_of_runs.TextAlign = CType(resources.GetObject("number_of_runs.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.number_of_runs, resources.GetString("number_of_runs.ToolTip"))
            Me.number_of_runs.Visible = CType(resources.GetObject("number_of_runs.Visible"), Boolean)
            Me.number_of_runs.WordWrap = CType(resources.GetObject("number_of_runs.WordWrap"), Boolean)
            '
            'thetacrit
            '
            Me.thetacrit.AccessibleDescription = resources.GetString("thetacrit.AccessibleDescription")
            Me.thetacrit.AccessibleName = resources.GetString("thetacrit.AccessibleName")
            Me.thetacrit.Anchor = CType(resources.GetObject("thetacrit.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.thetacrit.AutoSize = CType(resources.GetObject("thetacrit.AutoSize"), Boolean)
            Me.thetacrit.BackgroundImage = CType(resources.GetObject("thetacrit.BackgroundImage"), System.Drawing.Image)
            Me.thetacrit.Dock = CType(resources.GetObject("thetacrit.Dock"), System.Windows.Forms.DockStyle)
            Me.thetacrit.Enabled = CType(resources.GetObject("thetacrit.Enabled"), Boolean)
            Me.thetacrit.Font = CType(resources.GetObject("thetacrit.Font"), System.Drawing.Font)
            Me.thetacrit.ImeMode = CType(resources.GetObject("thetacrit.ImeMode"), System.Windows.Forms.ImeMode)
            Me.thetacrit.Location = CType(resources.GetObject("thetacrit.Location"), System.Drawing.Point)
            Me.thetacrit.MaxLength = CType(resources.GetObject("thetacrit.MaxLength"), Integer)
            Me.thetacrit.Multiline = CType(resources.GetObject("thetacrit.Multiline"), Boolean)
            Me.thetacrit.Name = "thetacrit"
            Me.thetacrit.PasswordChar = CType(resources.GetObject("thetacrit.PasswordChar"), Char)
            Me.thetacrit.RightToLeft = CType(resources.GetObject("thetacrit.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.thetacrit.ScrollBars = CType(resources.GetObject("thetacrit.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.thetacrit.Size = CType(resources.GetObject("thetacrit.Size"), System.Drawing.Size)
            Me.thetacrit.TabIndex = CType(resources.GetObject("thetacrit.TabIndex"), Integer)
            Me.thetacrit.Text = resources.GetString("thetacrit.Text")
            Me.thetacrit.TextAlign = CType(resources.GetObject("thetacrit.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.thetacrit, resources.GetString("thetacrit.ToolTip"))
            Me.thetacrit.Visible = CType(resources.GetObject("thetacrit.Visible"), Boolean)
            Me.thetacrit.WordWrap = CType(resources.GetObject("thetacrit.WordWrap"), Boolean)
            '
            'Label1
            '
            Me.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription")
            Me.Label1.AccessibleName = resources.GetString("Label1.AccessibleName")
            Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
            Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
            Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
            Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
            Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
            Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
            Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
            Me.Label1.Name = "Label1"
            Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
            Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
            Me.Label1.Text = resources.GetString("Label1.Text")
            Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
            Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
            '
            'Label2
            '
            Me.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription")
            Me.Label2.AccessibleName = resources.GetString("Label2.AccessibleName")
            Me.Label2.Anchor = CType(resources.GetObject("Label2.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label2.AutoSize = CType(resources.GetObject("Label2.AutoSize"), Boolean)
            Me.Label2.Dock = CType(resources.GetObject("Label2.Dock"), System.Windows.Forms.DockStyle)
            Me.Label2.Enabled = CType(resources.GetObject("Label2.Enabled"), Boolean)
            Me.Label2.Font = CType(resources.GetObject("Label2.Font"), System.Drawing.Font)
            Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
            Me.Label2.ImageAlign = CType(resources.GetObject("Label2.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label2.ImageIndex = CType(resources.GetObject("Label2.ImageIndex"), Integer)
            Me.Label2.ImeMode = CType(resources.GetObject("Label2.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label2.Location = CType(resources.GetObject("Label2.Location"), System.Drawing.Point)
            Me.Label2.Name = "Label2"
            Me.Label2.RightToLeft = CType(resources.GetObject("Label2.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label2.Size = CType(resources.GetObject("Label2.Size"), System.Drawing.Size)
            Me.Label2.TabIndex = CType(resources.GetObject("Label2.TabIndex"), Integer)
            Me.Label2.Text = resources.GetString("Label2.Text")
            Me.Label2.TextAlign = CType(resources.GetObject("Label2.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
            Me.Label2.Visible = CType(resources.GetObject("Label2.Visible"), Boolean)
            '
            'Label3
            '
            Me.Label3.AccessibleDescription = resources.GetString("Label3.AccessibleDescription")
            Me.Label3.AccessibleName = resources.GetString("Label3.AccessibleName")
            Me.Label3.Anchor = CType(resources.GetObject("Label3.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label3.AutoSize = CType(resources.GetObject("Label3.AutoSize"), Boolean)
            Me.Label3.Dock = CType(resources.GetObject("Label3.Dock"), System.Windows.Forms.DockStyle)
            Me.Label3.Enabled = CType(resources.GetObject("Label3.Enabled"), Boolean)
            Me.Label3.Font = CType(resources.GetObject("Label3.Font"), System.Drawing.Font)
            Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
            Me.Label3.ImageAlign = CType(resources.GetObject("Label3.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label3.ImageIndex = CType(resources.GetObject("Label3.ImageIndex"), Integer)
            Me.Label3.ImeMode = CType(resources.GetObject("Label3.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label3.Location = CType(resources.GetObject("Label3.Location"), System.Drawing.Point)
            Me.Label3.Name = "Label3"
            Me.Label3.RightToLeft = CType(resources.GetObject("Label3.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label3.Size = CType(resources.GetObject("Label3.Size"), System.Drawing.Size)
            Me.Label3.TabIndex = CType(resources.GetObject("Label3.TabIndex"), Integer)
            Me.Label3.Text = resources.GetString("Label3.Text")
            Me.Label3.TextAlign = CType(resources.GetObject("Label3.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
            Me.Label3.Visible = CType(resources.GetObject("Label3.Visible"), Boolean)
            '
            'Label4
            '
            Me.Label4.AccessibleDescription = resources.GetString("Label4.AccessibleDescription")
            Me.Label4.AccessibleName = resources.GetString("Label4.AccessibleName")
            Me.Label4.Anchor = CType(resources.GetObject("Label4.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label4.AutoSize = CType(resources.GetObject("Label4.AutoSize"), Boolean)
            Me.Label4.Dock = CType(resources.GetObject("Label4.Dock"), System.Windows.Forms.DockStyle)
            Me.Label4.Enabled = CType(resources.GetObject("Label4.Enabled"), Boolean)
            Me.Label4.Font = CType(resources.GetObject("Label4.Font"), System.Drawing.Font)
            Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
            Me.Label4.ImageAlign = CType(resources.GetObject("Label4.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label4.ImageIndex = CType(resources.GetObject("Label4.ImageIndex"), Integer)
            Me.Label4.ImeMode = CType(resources.GetObject("Label4.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label4.Location = CType(resources.GetObject("Label4.Location"), System.Drawing.Point)
            Me.Label4.Name = "Label4"
            Me.Label4.RightToLeft = CType(resources.GetObject("Label4.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label4.Size = CType(resources.GetObject("Label4.Size"), System.Drawing.Size)
            Me.Label4.TabIndex = CType(resources.GetObject("Label4.TabIndex"), Integer)
            Me.Label4.Text = resources.GetString("Label4.Text")
            Me.Label4.TextAlign = CType(resources.GetObject("Label4.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label4, resources.GetString("Label4.ToolTip"))
            Me.Label4.Visible = CType(resources.GetObject("Label4.Visible"), Boolean)
            '
            'Label5
            '
            Me.Label5.AccessibleDescription = resources.GetString("Label5.AccessibleDescription")
            Me.Label5.AccessibleName = resources.GetString("Label5.AccessibleName")
            Me.Label5.Anchor = CType(resources.GetObject("Label5.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label5.AutoSize = CType(resources.GetObject("Label5.AutoSize"), Boolean)
            Me.Label5.Dock = CType(resources.GetObject("Label5.Dock"), System.Windows.Forms.DockStyle)
            Me.Label5.Enabled = CType(resources.GetObject("Label5.Enabled"), Boolean)
            Me.Label5.Font = CType(resources.GetObject("Label5.Font"), System.Drawing.Font)
            Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
            Me.Label5.ImageAlign = CType(resources.GetObject("Label5.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label5.ImageIndex = CType(resources.GetObject("Label5.ImageIndex"), Integer)
            Me.Label5.ImeMode = CType(resources.GetObject("Label5.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label5.Location = CType(resources.GetObject("Label5.Location"), System.Drawing.Point)
            Me.Label5.Name = "Label5"
            Me.Label5.RightToLeft = CType(resources.GetObject("Label5.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label5.Size = CType(resources.GetObject("Label5.Size"), System.Drawing.Size)
            Me.Label5.TabIndex = CType(resources.GetObject("Label5.TabIndex"), Integer)
            Me.Label5.Text = resources.GetString("Label5.Text")
            Me.Label5.TextAlign = CType(resources.GetObject("Label5.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label5, resources.GetString("Label5.ToolTip"))
            Me.Label5.Visible = CType(resources.GetObject("Label5.Visible"), Boolean)
            '
            'Label6
            '
            Me.Label6.AccessibleDescription = resources.GetString("Label6.AccessibleDescription")
            Me.Label6.AccessibleName = resources.GetString("Label6.AccessibleName")
            Me.Label6.Anchor = CType(resources.GetObject("Label6.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label6.AutoSize = CType(resources.GetObject("Label6.AutoSize"), Boolean)
            Me.Label6.Dock = CType(resources.GetObject("Label6.Dock"), System.Windows.Forms.DockStyle)
            Me.Label6.Enabled = CType(resources.GetObject("Label6.Enabled"), Boolean)
            Me.Label6.Font = CType(resources.GetObject("Label6.Font"), System.Drawing.Font)
            Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
            Me.Label6.ImageAlign = CType(resources.GetObject("Label6.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label6.ImageIndex = CType(resources.GetObject("Label6.ImageIndex"), Integer)
            Me.Label6.ImeMode = CType(resources.GetObject("Label6.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label6.Location = CType(resources.GetObject("Label6.Location"), System.Drawing.Point)
            Me.Label6.Name = "Label6"
            Me.Label6.RightToLeft = CType(resources.GetObject("Label6.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label6.Size = CType(resources.GetObject("Label6.Size"), System.Drawing.Size)
            Me.Label6.TabIndex = CType(resources.GetObject("Label6.TabIndex"), Integer)
            Me.Label6.Text = resources.GetString("Label6.Text")
            Me.Label6.TextAlign = CType(resources.GetObject("Label6.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label6, resources.GetString("Label6.ToolTip"))
            Me.Label6.Visible = CType(resources.GetObject("Label6.Visible"), Boolean)
            '
            'Label7
            '
            Me.Label7.AccessibleDescription = resources.GetString("Label7.AccessibleDescription")
            Me.Label7.AccessibleName = resources.GetString("Label7.AccessibleName")
            Me.Label7.Anchor = CType(resources.GetObject("Label7.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label7.AutoSize = CType(resources.GetObject("Label7.AutoSize"), Boolean)
            Me.Label7.Dock = CType(resources.GetObject("Label7.Dock"), System.Windows.Forms.DockStyle)
            Me.Label7.Enabled = CType(resources.GetObject("Label7.Enabled"), Boolean)
            Me.Label7.Font = CType(resources.GetObject("Label7.Font"), System.Drawing.Font)
            Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
            Me.Label7.ImageAlign = CType(resources.GetObject("Label7.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label7.ImageIndex = CType(resources.GetObject("Label7.ImageIndex"), Integer)
            Me.Label7.ImeMode = CType(resources.GetObject("Label7.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label7.Location = CType(resources.GetObject("Label7.Location"), System.Drawing.Point)
            Me.Label7.Name = "Label7"
            Me.Label7.RightToLeft = CType(resources.GetObject("Label7.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label7.Size = CType(resources.GetObject("Label7.Size"), System.Drawing.Size)
            Me.Label7.TabIndex = CType(resources.GetObject("Label7.TabIndex"), Integer)
            Me.Label7.Text = resources.GetString("Label7.Text")
            Me.Label7.TextAlign = CType(resources.GetObject("Label7.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label7, resources.GetString("Label7.ToolTip"))
            Me.Label7.Visible = CType(resources.GetObject("Label7.Visible"), Boolean)
            '
            'Label8
            '
            Me.Label8.AccessibleDescription = resources.GetString("Label8.AccessibleDescription")
            Me.Label8.AccessibleName = resources.GetString("Label8.AccessibleName")
            Me.Label8.Anchor = CType(resources.GetObject("Label8.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label8.AutoSize = CType(resources.GetObject("Label8.AutoSize"), Boolean)
            Me.Label8.Dock = CType(resources.GetObject("Label8.Dock"), System.Windows.Forms.DockStyle)
            Me.Label8.Enabled = CType(resources.GetObject("Label8.Enabled"), Boolean)
            Me.Label8.Font = CType(resources.GetObject("Label8.Font"), System.Drawing.Font)
            Me.Label8.Image = CType(resources.GetObject("Label8.Image"), System.Drawing.Image)
            Me.Label8.ImageAlign = CType(resources.GetObject("Label8.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label8.ImageIndex = CType(resources.GetObject("Label8.ImageIndex"), Integer)
            Me.Label8.ImeMode = CType(resources.GetObject("Label8.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label8.Location = CType(resources.GetObject("Label8.Location"), System.Drawing.Point)
            Me.Label8.Name = "Label8"
            Me.Label8.RightToLeft = CType(resources.GetObject("Label8.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label8.Size = CType(resources.GetObject("Label8.Size"), System.Drawing.Size)
            Me.Label8.TabIndex = CType(resources.GetObject("Label8.TabIndex"), Integer)
            Me.Label8.Text = resources.GetString("Label8.Text")
            Me.Label8.TextAlign = CType(resources.GetObject("Label8.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label8, resources.GetString("Label8.ToolTip"))
            Me.Label8.Visible = CType(resources.GetObject("Label8.Visible"), Boolean)
            '
            'load_parms
            '
            Me.load_parms.AccessibleDescription = resources.GetString("load_parms.AccessibleDescription")
            Me.load_parms.AccessibleName = resources.GetString("load_parms.AccessibleName")
            Me.load_parms.Anchor = CType(resources.GetObject("load_parms.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.load_parms.BackgroundImage = CType(resources.GetObject("load_parms.BackgroundImage"), System.Drawing.Image)
            Me.load_parms.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.load_parms.Dock = CType(resources.GetObject("load_parms.Dock"), System.Windows.Forms.DockStyle)
            Me.load_parms.Enabled = CType(resources.GetObject("load_parms.Enabled"), Boolean)
            Me.load_parms.FlatStyle = CType(resources.GetObject("load_parms.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.load_parms.Font = CType(resources.GetObject("load_parms.Font"), System.Drawing.Font)
            Me.load_parms.Image = CType(resources.GetObject("load_parms.Image"), System.Drawing.Image)
            Me.load_parms.ImageAlign = CType(resources.GetObject("load_parms.ImageAlign"), System.Drawing.ContentAlignment)
            Me.load_parms.ImageIndex = CType(resources.GetObject("load_parms.ImageIndex"), Integer)
            Me.load_parms.ImeMode = CType(resources.GetObject("load_parms.ImeMode"), System.Windows.Forms.ImeMode)
            Me.load_parms.Location = CType(resources.GetObject("load_parms.Location"), System.Drawing.Point)
            Me.load_parms.Name = "load_parms"
            Me.load_parms.RightToLeft = CType(resources.GetObject("load_parms.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.load_parms.Size = CType(resources.GetObject("load_parms.Size"), System.Drawing.Size)
            Me.load_parms.TabIndex = CType(resources.GetObject("load_parms.TabIndex"), Integer)
            Me.load_parms.Text = resources.GetString("load_parms.Text")
            Me.load_parms.TextAlign = CType(resources.GetObject("load_parms.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.load_parms, resources.GetString("load_parms.ToolTip"))
            Me.load_parms.Visible = CType(resources.GetObject("load_parms.Visible"), Boolean)
            '
            'cancel_load
            '
            Me.cancel_load.AccessibleDescription = resources.GetString("cancel_load.AccessibleDescription")
            Me.cancel_load.AccessibleName = resources.GetString("cancel_load.AccessibleName")
            Me.cancel_load.Anchor = CType(resources.GetObject("cancel_load.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.cancel_load.BackgroundImage = CType(resources.GetObject("cancel_load.BackgroundImage"), System.Drawing.Image)
            Me.cancel_load.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.cancel_load.Dock = CType(resources.GetObject("cancel_load.Dock"), System.Windows.Forms.DockStyle)
            Me.cancel_load.Enabled = CType(resources.GetObject("cancel_load.Enabled"), Boolean)
            Me.cancel_load.FlatStyle = CType(resources.GetObject("cancel_load.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.cancel_load.Font = CType(resources.GetObject("cancel_load.Font"), System.Drawing.Font)
            Me.cancel_load.Image = CType(resources.GetObject("cancel_load.Image"), System.Drawing.Image)
            Me.cancel_load.ImageAlign = CType(resources.GetObject("cancel_load.ImageAlign"), System.Drawing.ContentAlignment)
            Me.cancel_load.ImageIndex = CType(resources.GetObject("cancel_load.ImageIndex"), Integer)
            Me.cancel_load.ImeMode = CType(resources.GetObject("cancel_load.ImeMode"), System.Windows.Forms.ImeMode)
            Me.cancel_load.Location = CType(resources.GetObject("cancel_load.Location"), System.Drawing.Point)
            Me.cancel_load.Name = "cancel_load"
            Me.cancel_load.RightToLeft = CType(resources.GetObject("cancel_load.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.cancel_load.Size = CType(resources.GetObject("cancel_load.Size"), System.Drawing.Size)
            Me.cancel_load.TabIndex = CType(resources.GetObject("cancel_load.TabIndex"), Integer)
            Me.cancel_load.Text = resources.GetString("cancel_load.Text")
            Me.cancel_load.TextAlign = CType(resources.GetObject("cancel_load.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.cancel_load, resources.GetString("cancel_load.ToolTip"))
            Me.cancel_load.Visible = CType(resources.GetObject("cancel_load.Visible"), Boolean)
            '
            'depthtolerance
            '
            Me.depthtolerance.AccessibleDescription = resources.GetString("depthtolerance.AccessibleDescription")
            Me.depthtolerance.AccessibleName = resources.GetString("depthtolerance.AccessibleName")
            Me.depthtolerance.Anchor = CType(resources.GetObject("depthtolerance.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.depthtolerance.AutoSize = CType(resources.GetObject("depthtolerance.AutoSize"), Boolean)
            Me.depthtolerance.BackgroundImage = CType(resources.GetObject("depthtolerance.BackgroundImage"), System.Drawing.Image)
            Me.depthtolerance.Dock = CType(resources.GetObject("depthtolerance.Dock"), System.Windows.Forms.DockStyle)
            Me.depthtolerance.Enabled = CType(resources.GetObject("depthtolerance.Enabled"), Boolean)
            Me.depthtolerance.Font = CType(resources.GetObject("depthtolerance.Font"), System.Drawing.Font)
            Me.depthtolerance.ImeMode = CType(resources.GetObject("depthtolerance.ImeMode"), System.Windows.Forms.ImeMode)
            Me.depthtolerance.Location = CType(resources.GetObject("depthtolerance.Location"), System.Drawing.Point)
            Me.depthtolerance.MaxLength = CType(resources.GetObject("depthtolerance.MaxLength"), Integer)
            Me.depthtolerance.Multiline = CType(resources.GetObject("depthtolerance.Multiline"), Boolean)
            Me.depthtolerance.Name = "depthtolerance"
            Me.depthtolerance.PasswordChar = CType(resources.GetObject("depthtolerance.PasswordChar"), Char)
            Me.depthtolerance.RightToLeft = CType(resources.GetObject("depthtolerance.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.depthtolerance.ScrollBars = CType(resources.GetObject("depthtolerance.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.depthtolerance.Size = CType(resources.GetObject("depthtolerance.Size"), System.Drawing.Size)
            Me.depthtolerance.TabIndex = CType(resources.GetObject("depthtolerance.TabIndex"), Integer)
            Me.depthtolerance.Text = resources.GetString("depthtolerance.Text")
            Me.depthtolerance.TextAlign = CType(resources.GetObject("depthtolerance.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.depthtolerance, resources.GetString("depthtolerance.ToolTip"))
            Me.depthtolerance.Visible = CType(resources.GetObject("depthtolerance.Visible"), Boolean)
            Me.depthtolerance.WordWrap = CType(resources.GetObject("depthtolerance.WordWrap"), Boolean)
            '
            'Label9
            '
            Me.Label9.AccessibleDescription = resources.GetString("Label9.AccessibleDescription")
            Me.Label9.AccessibleName = resources.GetString("Label9.AccessibleName")
            Me.Label9.Anchor = CType(resources.GetObject("Label9.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label9.AutoSize = CType(resources.GetObject("Label9.AutoSize"), Boolean)
            Me.Label9.Dock = CType(resources.GetObject("Label9.Dock"), System.Windows.Forms.DockStyle)
            Me.Label9.Enabled = CType(resources.GetObject("Label9.Enabled"), Boolean)
            Me.Label9.Font = CType(resources.GetObject("Label9.Font"), System.Drawing.Font)
            Me.Label9.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
            Me.Label9.ImageAlign = CType(resources.GetObject("Label9.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label9.ImageIndex = CType(resources.GetObject("Label9.ImageIndex"), Integer)
            Me.Label9.ImeMode = CType(resources.GetObject("Label9.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label9.Location = CType(resources.GetObject("Label9.Location"), System.Drawing.Point)
            Me.Label9.Name = "Label9"
            Me.Label9.RightToLeft = CType(resources.GetObject("Label9.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label9.Size = CType(resources.GetObject("Label9.Size"), System.Drawing.Size)
            Me.Label9.TabIndex = CType(resources.GetObject("Label9.TabIndex"), Integer)
            Me.Label9.Text = resources.GetString("Label9.Text")
            Me.Label9.TextAlign = CType(resources.GetObject("Label9.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label9, resources.GetString("Label9.ToolTip"))
            Me.Label9.Visible = CType(resources.GetObject("Label9.Visible"), Boolean)
            '
            'Groovedir
            '
            Me.Groovedir.AccessibleDescription = resources.GetString("Groovedir.AccessibleDescription")
            Me.Groovedir.AccessibleName = resources.GetString("Groovedir.AccessibleName")
            Me.Groovedir.Anchor = CType(resources.GetObject("Groovedir.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Groovedir.BackgroundImage = CType(resources.GetObject("Groovedir.BackgroundImage"), System.Drawing.Image)
            Me.Groovedir.ColumnWidth = CType(resources.GetObject("Groovedir.ColumnWidth"), Integer)
            Me.Groovedir.Dock = CType(resources.GetObject("Groovedir.Dock"), System.Windows.Forms.DockStyle)
            Me.Groovedir.Enabled = CType(resources.GetObject("Groovedir.Enabled"), Boolean)
            Me.Groovedir.Font = CType(resources.GetObject("Groovedir.Font"), System.Drawing.Font)
            Me.Groovedir.HorizontalExtent = CType(resources.GetObject("Groovedir.HorizontalExtent"), Integer)
            Me.Groovedir.HorizontalScrollbar = CType(resources.GetObject("Groovedir.HorizontalScrollbar"), Boolean)
            Me.Groovedir.ImeMode = CType(resources.GetObject("Groovedir.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Groovedir.IntegralHeight = CType(resources.GetObject("Groovedir.IntegralHeight"), Boolean)
            Me.Groovedir.ItemHeight = CType(resources.GetObject("Groovedir.ItemHeight"), Integer)
            Me.Groovedir.Items.AddRange(New Object() {resources.GetString("Groovedir.Items"), resources.GetString("Groovedir.Items1"), resources.GetString("Groovedir.Items2")})
            Me.Groovedir.Location = CType(resources.GetObject("Groovedir.Location"), System.Drawing.Point)
            Me.Groovedir.Name = "Groovedir"
            Me.Groovedir.RightToLeft = CType(resources.GetObject("Groovedir.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Groovedir.ScrollAlwaysVisible = CType(resources.GetObject("Groovedir.ScrollAlwaysVisible"), Boolean)
            Me.Groovedir.Size = CType(resources.GetObject("Groovedir.Size"), System.Drawing.Size)
            Me.Groovedir.TabIndex = CType(resources.GetObject("Groovedir.TabIndex"), Integer)
            Me.ToolTip1.SetToolTip(Me.Groovedir, resources.GetString("Groovedir.ToolTip"))
            Me.Groovedir.Visible = CType(resources.GetObject("Groovedir.Visible"), Boolean)
            '
            'Label10
            '
            Me.Label10.AccessibleDescription = resources.GetString("Label10.AccessibleDescription")
            Me.Label10.AccessibleName = resources.GetString("Label10.AccessibleName")
            Me.Label10.Anchor = CType(resources.GetObject("Label10.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label10.AutoSize = CType(resources.GetObject("Label10.AutoSize"), Boolean)
            Me.Label10.Dock = CType(resources.GetObject("Label10.Dock"), System.Windows.Forms.DockStyle)
            Me.Label10.Enabled = CType(resources.GetObject("Label10.Enabled"), Boolean)
            Me.Label10.Font = CType(resources.GetObject("Label10.Font"), System.Drawing.Font)
            Me.Label10.Image = CType(resources.GetObject("Label10.Image"), System.Drawing.Image)
            Me.Label10.ImageAlign = CType(resources.GetObject("Label10.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label10.ImageIndex = CType(resources.GetObject("Label10.ImageIndex"), Integer)
            Me.Label10.ImeMode = CType(resources.GetObject("Label10.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label10.Location = CType(resources.GetObject("Label10.Location"), System.Drawing.Point)
            Me.Label10.Name = "Label10"
            Me.Label10.RightToLeft = CType(resources.GetObject("Label10.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label10.Size = CType(resources.GetObject("Label10.Size"), System.Drawing.Size)
            Me.Label10.TabIndex = CType(resources.GetObject("Label10.TabIndex"), Integer)
            Me.Label10.Text = resources.GetString("Label10.Text")
            Me.Label10.TextAlign = CType(resources.GetObject("Label10.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label10, resources.GetString("Label10.ToolTip"))
            Me.Label10.Visible = CType(resources.GetObject("Label10.Visible"), Boolean)
            '
            'testdepth
            '
            Me.testdepth.AccessibleDescription = resources.GetString("testdepth.AccessibleDescription")
            Me.testdepth.AccessibleName = resources.GetString("testdepth.AccessibleName")
            Me.testdepth.Anchor = CType(resources.GetObject("testdepth.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.testdepth.AutoSize = CType(resources.GetObject("testdepth.AutoSize"), Boolean)
            Me.testdepth.BackgroundImage = CType(resources.GetObject("testdepth.BackgroundImage"), System.Drawing.Image)
            Me.testdepth.Dock = CType(resources.GetObject("testdepth.Dock"), System.Windows.Forms.DockStyle)
            Me.testdepth.Enabled = CType(resources.GetObject("testdepth.Enabled"), Boolean)
            Me.testdepth.Font = CType(resources.GetObject("testdepth.Font"), System.Drawing.Font)
            Me.testdepth.ImeMode = CType(resources.GetObject("testdepth.ImeMode"), System.Windows.Forms.ImeMode)
            Me.testdepth.Location = CType(resources.GetObject("testdepth.Location"), System.Drawing.Point)
            Me.testdepth.MaxLength = CType(resources.GetObject("testdepth.MaxLength"), Integer)
            Me.testdepth.Multiline = CType(resources.GetObject("testdepth.Multiline"), Boolean)
            Me.testdepth.Name = "testdepth"
            Me.testdepth.PasswordChar = CType(resources.GetObject("testdepth.PasswordChar"), Char)
            Me.testdepth.RightToLeft = CType(resources.GetObject("testdepth.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.testdepth.ScrollBars = CType(resources.GetObject("testdepth.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.testdepth.Size = CType(resources.GetObject("testdepth.Size"), System.Drawing.Size)
            Me.testdepth.TabIndex = CType(resources.GetObject("testdepth.TabIndex"), Integer)
            Me.testdepth.Text = resources.GetString("testdepth.Text")
            Me.testdepth.TextAlign = CType(resources.GetObject("testdepth.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.testdepth, resources.GetString("testdepth.ToolTip"))
            Me.testdepth.Visible = CType(resources.GetObject("testdepth.Visible"), Boolean)
            Me.testdepth.WordWrap = CType(resources.GetObject("testdepth.WordWrap"), Boolean)
            '
            'testspeed
            '
            Me.testspeed.AccessibleDescription = resources.GetString("testspeed.AccessibleDescription")
            Me.testspeed.AccessibleName = resources.GetString("testspeed.AccessibleName")
            Me.testspeed.Anchor = CType(resources.GetObject("testspeed.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.testspeed.AutoSize = CType(resources.GetObject("testspeed.AutoSize"), Boolean)
            Me.testspeed.BackgroundImage = CType(resources.GetObject("testspeed.BackgroundImage"), System.Drawing.Image)
            Me.testspeed.Dock = CType(resources.GetObject("testspeed.Dock"), System.Windows.Forms.DockStyle)
            Me.testspeed.Enabled = CType(resources.GetObject("testspeed.Enabled"), Boolean)
            Me.testspeed.Font = CType(resources.GetObject("testspeed.Font"), System.Drawing.Font)
            Me.testspeed.ImeMode = CType(resources.GetObject("testspeed.ImeMode"), System.Windows.Forms.ImeMode)
            Me.testspeed.Location = CType(resources.GetObject("testspeed.Location"), System.Drawing.Point)
            Me.testspeed.MaxLength = CType(resources.GetObject("testspeed.MaxLength"), Integer)
            Me.testspeed.Multiline = CType(resources.GetObject("testspeed.Multiline"), Boolean)
            Me.testspeed.Name = "testspeed"
            Me.testspeed.PasswordChar = CType(resources.GetObject("testspeed.PasswordChar"), Char)
            Me.testspeed.RightToLeft = CType(resources.GetObject("testspeed.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.testspeed.ScrollBars = CType(resources.GetObject("testspeed.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.testspeed.Size = CType(resources.GetObject("testspeed.Size"), System.Drawing.Size)
            Me.testspeed.TabIndex = CType(resources.GetObject("testspeed.TabIndex"), Integer)
            Me.testspeed.Text = resources.GetString("testspeed.Text")
            Me.testspeed.TextAlign = CType(resources.GetObject("testspeed.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.testspeed, resources.GetString("testspeed.ToolTip"))
            Me.testspeed.Visible = CType(resources.GetObject("testspeed.Visible"), Boolean)
            Me.testspeed.WordWrap = CType(resources.GetObject("testspeed.WordWrap"), Boolean)
            '
            'testpasses
            '
            Me.testpasses.AccessibleDescription = resources.GetString("testpasses.AccessibleDescription")
            Me.testpasses.AccessibleName = resources.GetString("testpasses.AccessibleName")
            Me.testpasses.Anchor = CType(resources.GetObject("testpasses.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.testpasses.AutoSize = CType(resources.GetObject("testpasses.AutoSize"), Boolean)
            Me.testpasses.BackgroundImage = CType(resources.GetObject("testpasses.BackgroundImage"), System.Drawing.Image)
            Me.testpasses.Dock = CType(resources.GetObject("testpasses.Dock"), System.Windows.Forms.DockStyle)
            Me.testpasses.Enabled = CType(resources.GetObject("testpasses.Enabled"), Boolean)
            Me.testpasses.Font = CType(resources.GetObject("testpasses.Font"), System.Drawing.Font)
            Me.testpasses.ImeMode = CType(resources.GetObject("testpasses.ImeMode"), System.Windows.Forms.ImeMode)
            Me.testpasses.Location = CType(resources.GetObject("testpasses.Location"), System.Drawing.Point)
            Me.testpasses.MaxLength = CType(resources.GetObject("testpasses.MaxLength"), Integer)
            Me.testpasses.Multiline = CType(resources.GetObject("testpasses.Multiline"), Boolean)
            Me.testpasses.Name = "testpasses"
            Me.testpasses.PasswordChar = CType(resources.GetObject("testpasses.PasswordChar"), Char)
            Me.testpasses.RightToLeft = CType(resources.GetObject("testpasses.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.testpasses.ScrollBars = CType(resources.GetObject("testpasses.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.testpasses.Size = CType(resources.GetObject("testpasses.Size"), System.Drawing.Size)
            Me.testpasses.TabIndex = CType(resources.GetObject("testpasses.TabIndex"), Integer)
            Me.testpasses.Text = resources.GetString("testpasses.Text")
            Me.testpasses.TextAlign = CType(resources.GetObject("testpasses.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.testpasses, resources.GetString("testpasses.ToolTip"))
            Me.testpasses.Visible = CType(resources.GetObject("testpasses.Visible"), Boolean)
            Me.testpasses.WordWrap = CType(resources.GetObject("testpasses.WordWrap"), Boolean)
            '
            'Label11
            '
            Me.Label11.AccessibleDescription = resources.GetString("Label11.AccessibleDescription")
            Me.Label11.AccessibleName = resources.GetString("Label11.AccessibleName")
            Me.Label11.Anchor = CType(resources.GetObject("Label11.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label11.AutoSize = CType(resources.GetObject("Label11.AutoSize"), Boolean)
            Me.Label11.Dock = CType(resources.GetObject("Label11.Dock"), System.Windows.Forms.DockStyle)
            Me.Label11.Enabled = CType(resources.GetObject("Label11.Enabled"), Boolean)
            Me.Label11.Font = CType(resources.GetObject("Label11.Font"), System.Drawing.Font)
            Me.Label11.Image = CType(resources.GetObject("Label11.Image"), System.Drawing.Image)
            Me.Label11.ImageAlign = CType(resources.GetObject("Label11.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label11.ImageIndex = CType(resources.GetObject("Label11.ImageIndex"), Integer)
            Me.Label11.ImeMode = CType(resources.GetObject("Label11.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label11.Location = CType(resources.GetObject("Label11.Location"), System.Drawing.Point)
            Me.Label11.Name = "Label11"
            Me.Label11.RightToLeft = CType(resources.GetObject("Label11.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label11.Size = CType(resources.GetObject("Label11.Size"), System.Drawing.Size)
            Me.Label11.TabIndex = CType(resources.GetObject("Label11.TabIndex"), Integer)
            Me.Label11.Text = resources.GetString("Label11.Text")
            Me.Label11.TextAlign = CType(resources.GetObject("Label11.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label11, resources.GetString("Label11.ToolTip"))
            Me.Label11.Visible = CType(resources.GetObject("Label11.Visible"), Boolean)
            '
            'Label12
            '
            Me.Label12.AccessibleDescription = resources.GetString("Label12.AccessibleDescription")
            Me.Label12.AccessibleName = resources.GetString("Label12.AccessibleName")
            Me.Label12.Anchor = CType(resources.GetObject("Label12.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label12.AutoSize = CType(resources.GetObject("Label12.AutoSize"), Boolean)
            Me.Label12.Dock = CType(resources.GetObject("Label12.Dock"), System.Windows.Forms.DockStyle)
            Me.Label12.Enabled = CType(resources.GetObject("Label12.Enabled"), Boolean)
            Me.Label12.Font = CType(resources.GetObject("Label12.Font"), System.Drawing.Font)
            Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
            Me.Label12.ImageAlign = CType(resources.GetObject("Label12.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label12.ImageIndex = CType(resources.GetObject("Label12.ImageIndex"), Integer)
            Me.Label12.ImeMode = CType(resources.GetObject("Label12.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label12.Location = CType(resources.GetObject("Label12.Location"), System.Drawing.Point)
            Me.Label12.Name = "Label12"
            Me.Label12.RightToLeft = CType(resources.GetObject("Label12.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label12.Size = CType(resources.GetObject("Label12.Size"), System.Drawing.Size)
            Me.Label12.TabIndex = CType(resources.GetObject("Label12.TabIndex"), Integer)
            Me.Label12.Text = resources.GetString("Label12.Text")
            Me.Label12.TextAlign = CType(resources.GetObject("Label12.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label12, resources.GetString("Label12.ToolTip"))
            Me.Label12.Visible = CType(resources.GetObject("Label12.Visible"), Boolean)
            '
            'Label13
            '
            Me.Label13.AccessibleDescription = resources.GetString("Label13.AccessibleDescription")
            Me.Label13.AccessibleName = resources.GetString("Label13.AccessibleName")
            Me.Label13.Anchor = CType(resources.GetObject("Label13.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label13.AutoSize = CType(resources.GetObject("Label13.AutoSize"), Boolean)
            Me.Label13.Dock = CType(resources.GetObject("Label13.Dock"), System.Windows.Forms.DockStyle)
            Me.Label13.Enabled = CType(resources.GetObject("Label13.Enabled"), Boolean)
            Me.Label13.Font = CType(resources.GetObject("Label13.Font"), System.Drawing.Font)
            Me.Label13.Image = CType(resources.GetObject("Label13.Image"), System.Drawing.Image)
            Me.Label13.ImageAlign = CType(resources.GetObject("Label13.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label13.ImageIndex = CType(resources.GetObject("Label13.ImageIndex"), Integer)
            Me.Label13.ImeMode = CType(resources.GetObject("Label13.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label13.Location = CType(resources.GetObject("Label13.Location"), System.Drawing.Point)
            Me.Label13.Name = "Label13"
            Me.Label13.RightToLeft = CType(resources.GetObject("Label13.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label13.Size = CType(resources.GetObject("Label13.Size"), System.Drawing.Size)
            Me.Label13.TabIndex = CType(resources.GetObject("Label13.TabIndex"), Integer)
            Me.Label13.Text = resources.GetString("Label13.Text")
            Me.Label13.TextAlign = CType(resources.GetObject("Label13.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label13, resources.GetString("Label13.ToolTip"))
            Me.Label13.Visible = CType(resources.GetObject("Label13.Visible"), Boolean)
            '
            'mrr_type
            '
            Me.mrr_type.AccessibleDescription = resources.GetString("mrr_type.AccessibleDescription")
            Me.mrr_type.AccessibleName = resources.GetString("mrr_type.AccessibleName")
            Me.mrr_type.Anchor = CType(resources.GetObject("mrr_type.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.mrr_type.AutoSize = CType(resources.GetObject("mrr_type.AutoSize"), Boolean)
            Me.mrr_type.BackgroundImage = CType(resources.GetObject("mrr_type.BackgroundImage"), System.Drawing.Image)
            Me.mrr_type.Dock = CType(resources.GetObject("mrr_type.Dock"), System.Windows.Forms.DockStyle)
            Me.mrr_type.Enabled = CType(resources.GetObject("mrr_type.Enabled"), Boolean)
            Me.mrr_type.Font = CType(resources.GetObject("mrr_type.Font"), System.Drawing.Font)
            Me.mrr_type.ImeMode = CType(resources.GetObject("mrr_type.ImeMode"), System.Windows.Forms.ImeMode)
            Me.mrr_type.Location = CType(resources.GetObject("mrr_type.Location"), System.Drawing.Point)
            Me.mrr_type.MaxLength = CType(resources.GetObject("mrr_type.MaxLength"), Integer)
            Me.mrr_type.Multiline = CType(resources.GetObject("mrr_type.Multiline"), Boolean)
            Me.mrr_type.Name = "mrr_type"
            Me.mrr_type.PasswordChar = CType(resources.GetObject("mrr_type.PasswordChar"), Char)
            Me.mrr_type.RightToLeft = CType(resources.GetObject("mrr_type.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.mrr_type.ScrollBars = CType(resources.GetObject("mrr_type.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.mrr_type.Size = CType(resources.GetObject("mrr_type.Size"), System.Drawing.Size)
            Me.mrr_type.TabIndex = CType(resources.GetObject("mrr_type.TabIndex"), Integer)
            Me.mrr_type.Text = resources.GetString("mrr_type.Text")
            Me.mrr_type.TextAlign = CType(resources.GetObject("mrr_type.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.mrr_type, resources.GetString("mrr_type.ToolTip"))
            Me.mrr_type.Visible = CType(resources.GetObject("mrr_type.Visible"), Boolean)
            Me.mrr_type.WordWrap = CType(resources.GetObject("mrr_type.WordWrap"), Boolean)
            '
            'armradius
            '
            Me.armradius.AccessibleDescription = resources.GetString("armradius.AccessibleDescription")
            Me.armradius.AccessibleName = resources.GetString("armradius.AccessibleName")
            Me.armradius.Anchor = CType(resources.GetObject("armradius.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.armradius.AutoSize = CType(resources.GetObject("armradius.AutoSize"), Boolean)
            Me.armradius.BackgroundImage = CType(resources.GetObject("armradius.BackgroundImage"), System.Drawing.Image)
            Me.armradius.Dock = CType(resources.GetObject("armradius.Dock"), System.Windows.Forms.DockStyle)
            Me.armradius.Enabled = CType(resources.GetObject("armradius.Enabled"), Boolean)
            Me.armradius.Font = CType(resources.GetObject("armradius.Font"), System.Drawing.Font)
            Me.armradius.ImeMode = CType(resources.GetObject("armradius.ImeMode"), System.Windows.Forms.ImeMode)
            Me.armradius.Location = CType(resources.GetObject("armradius.Location"), System.Drawing.Point)
            Me.armradius.MaxLength = CType(resources.GetObject("armradius.MaxLength"), Integer)
            Me.armradius.Multiline = CType(resources.GetObject("armradius.Multiline"), Boolean)
            Me.armradius.Name = "armradius"
            Me.armradius.PasswordChar = CType(resources.GetObject("armradius.PasswordChar"), Char)
            Me.armradius.RightToLeft = CType(resources.GetObject("armradius.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.armradius.ScrollBars = CType(resources.GetObject("armradius.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.armradius.Size = CType(resources.GetObject("armradius.Size"), System.Drawing.Size)
            Me.armradius.TabIndex = CType(resources.GetObject("armradius.TabIndex"), Integer)
            Me.armradius.Text = resources.GetString("armradius.Text")
            Me.armradius.TextAlign = CType(resources.GetObject("armradius.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.armradius, resources.GetString("armradius.ToolTip"))
            Me.armradius.Visible = CType(resources.GetObject("armradius.Visible"), Boolean)
            Me.armradius.WordWrap = CType(resources.GetObject("armradius.WordWrap"), Boolean)
            '
            'Label14
            '
            Me.Label14.AccessibleDescription = resources.GetString("Label14.AccessibleDescription")
            Me.Label14.AccessibleName = resources.GetString("Label14.AccessibleName")
            Me.Label14.Anchor = CType(resources.GetObject("Label14.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label14.AutoSize = CType(resources.GetObject("Label14.AutoSize"), Boolean)
            Me.Label14.Dock = CType(resources.GetObject("Label14.Dock"), System.Windows.Forms.DockStyle)
            Me.Label14.Enabled = CType(resources.GetObject("Label14.Enabled"), Boolean)
            Me.Label14.Font = CType(resources.GetObject("Label14.Font"), System.Drawing.Font)
            Me.Label14.Image = CType(resources.GetObject("Label14.Image"), System.Drawing.Image)
            Me.Label14.ImageAlign = CType(resources.GetObject("Label14.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label14.ImageIndex = CType(resources.GetObject("Label14.ImageIndex"), Integer)
            Me.Label14.ImeMode = CType(resources.GetObject("Label14.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label14.Location = CType(resources.GetObject("Label14.Location"), System.Drawing.Point)
            Me.Label14.Name = "Label14"
            Me.Label14.RightToLeft = CType(resources.GetObject("Label14.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label14.Size = CType(resources.GetObject("Label14.Size"), System.Drawing.Size)
            Me.Label14.TabIndex = CType(resources.GetObject("Label14.TabIndex"), Integer)
            Me.Label14.Text = resources.GetString("Label14.Text")
            Me.Label14.TextAlign = CType(resources.GetObject("Label14.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label14, resources.GetString("Label14.ToolTip"))
            Me.Label14.Visible = CType(resources.GetObject("Label14.Visible"), Boolean)
            '
            'lstbxoperation
            '
            Me.lstbxoperation.AccessibleDescription = resources.GetString("lstbxoperation.AccessibleDescription")
            Me.lstbxoperation.AccessibleName = resources.GetString("lstbxoperation.AccessibleName")
            Me.lstbxoperation.Anchor = CType(resources.GetObject("lstbxoperation.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.lstbxoperation.BackgroundImage = CType(resources.GetObject("lstbxoperation.BackgroundImage"), System.Drawing.Image)
            Me.lstbxoperation.ColumnWidth = CType(resources.GetObject("lstbxoperation.ColumnWidth"), Integer)
            Me.lstbxoperation.Dock = CType(resources.GetObject("lstbxoperation.Dock"), System.Windows.Forms.DockStyle)
            Me.lstbxoperation.Enabled = CType(resources.GetObject("lstbxoperation.Enabled"), Boolean)
            Me.lstbxoperation.Font = CType(resources.GetObject("lstbxoperation.Font"), System.Drawing.Font)
            Me.lstbxoperation.HorizontalExtent = CType(resources.GetObject("lstbxoperation.HorizontalExtent"), Integer)
            Me.lstbxoperation.HorizontalScrollbar = CType(resources.GetObject("lstbxoperation.HorizontalScrollbar"), Boolean)
            Me.lstbxoperation.ImeMode = CType(resources.GetObject("lstbxoperation.ImeMode"), System.Windows.Forms.ImeMode)
            Me.lstbxoperation.IntegralHeight = CType(resources.GetObject("lstbxoperation.IntegralHeight"), Boolean)
            Me.lstbxoperation.ItemHeight = CType(resources.GetObject("lstbxoperation.ItemHeight"), Integer)
            Me.lstbxoperation.Items.AddRange(New Object() {resources.GetString("lstbxoperation.Items"), resources.GetString("lstbxoperation.Items1"), resources.GetString("lstbxoperation.Items2"), resources.GetString("lstbxoperation.Items3")})
            Me.lstbxoperation.Location = CType(resources.GetObject("lstbxoperation.Location"), System.Drawing.Point)
            Me.lstbxoperation.Name = "lstbxoperation"
            Me.lstbxoperation.RightToLeft = CType(resources.GetObject("lstbxoperation.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.lstbxoperation.ScrollAlwaysVisible = CType(resources.GetObject("lstbxoperation.ScrollAlwaysVisible"), Boolean)
            Me.lstbxoperation.Size = CType(resources.GetObject("lstbxoperation.Size"), System.Drawing.Size)
            Me.lstbxoperation.TabIndex = CType(resources.GetObject("lstbxoperation.TabIndex"), Integer)
            Me.ToolTip1.SetToolTip(Me.lstbxoperation, resources.GetString("lstbxoperation.ToolTip"))
            Me.lstbxoperation.Visible = CType(resources.GetObject("lstbxoperation.Visible"), Boolean)
            '
            'Label15
            '
            Me.Label15.AccessibleDescription = resources.GetString("Label15.AccessibleDescription")
            Me.Label15.AccessibleName = resources.GetString("Label15.AccessibleName")
            Me.Label15.Anchor = CType(resources.GetObject("Label15.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label15.AutoSize = CType(resources.GetObject("Label15.AutoSize"), Boolean)
            Me.Label15.Dock = CType(resources.GetObject("Label15.Dock"), System.Windows.Forms.DockStyle)
            Me.Label15.Enabled = CType(resources.GetObject("Label15.Enabled"), Boolean)
            Me.Label15.Font = CType(resources.GetObject("Label15.Font"), System.Drawing.Font)
            Me.Label15.Image = CType(resources.GetObject("Label15.Image"), System.Drawing.Image)
            Me.Label15.ImageAlign = CType(resources.GetObject("Label15.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label15.ImageIndex = CType(resources.GetObject("Label15.ImageIndex"), Integer)
            Me.Label15.ImeMode = CType(resources.GetObject("Label15.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label15.Location = CType(resources.GetObject("Label15.Location"), System.Drawing.Point)
            Me.Label15.Name = "Label15"
            Me.Label15.RightToLeft = CType(resources.GetObject("Label15.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label15.Size = CType(resources.GetObject("Label15.Size"), System.Drawing.Size)
            Me.Label15.TabIndex = CType(resources.GetObject("Label15.TabIndex"), Integer)
            Me.Label15.Text = resources.GetString("Label15.Text")
            Me.Label15.TextAlign = CType(resources.GetObject("Label15.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label15, resources.GetString("Label15.ToolTip"))
            Me.Label15.Visible = CType(resources.GetObject("Label15.Visible"), Boolean)
            '
            'txtmtlength
            '
            Me.txtmtlength.AccessibleDescription = resources.GetString("txtmtlength.AccessibleDescription")
            Me.txtmtlength.AccessibleName = resources.GetString("txtmtlength.AccessibleName")
            Me.txtmtlength.Anchor = CType(resources.GetObject("txtmtlength.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.txtmtlength.AutoSize = CType(resources.GetObject("txtmtlength.AutoSize"), Boolean)
            Me.txtmtlength.BackgroundImage = CType(resources.GetObject("txtmtlength.BackgroundImage"), System.Drawing.Image)
            Me.txtmtlength.Dock = CType(resources.GetObject("txtmtlength.Dock"), System.Windows.Forms.DockStyle)
            Me.txtmtlength.Enabled = CType(resources.GetObject("txtmtlength.Enabled"), Boolean)
            Me.txtmtlength.Font = CType(resources.GetObject("txtmtlength.Font"), System.Drawing.Font)
            Me.txtmtlength.ImeMode = CType(resources.GetObject("txtmtlength.ImeMode"), System.Windows.Forms.ImeMode)
            Me.txtmtlength.Location = CType(resources.GetObject("txtmtlength.Location"), System.Drawing.Point)
            Me.txtmtlength.MaxLength = CType(resources.GetObject("txtmtlength.MaxLength"), Integer)
            Me.txtmtlength.Multiline = CType(resources.GetObject("txtmtlength.Multiline"), Boolean)
            Me.txtmtlength.Name = "txtmtlength"
            Me.txtmtlength.PasswordChar = CType(resources.GetObject("txtmtlength.PasswordChar"), Char)
            Me.txtmtlength.RightToLeft = CType(resources.GetObject("txtmtlength.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.txtmtlength.ScrollBars = CType(resources.GetObject("txtmtlength.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.txtmtlength.Size = CType(resources.GetObject("txtmtlength.Size"), System.Drawing.Size)
            Me.txtmtlength.TabIndex = CType(resources.GetObject("txtmtlength.TabIndex"), Integer)
            Me.txtmtlength.Text = resources.GetString("txtmtlength.Text")
            Me.txtmtlength.TextAlign = CType(resources.GetObject("txtmtlength.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.txtmtlength, resources.GetString("txtmtlength.ToolTip"))
            Me.txtmtlength.Visible = CType(resources.GetObject("txtmtlength.Visible"), Boolean)
            Me.txtmtlength.WordWrap = CType(resources.GetObject("txtmtlength.WordWrap"), Boolean)
            '
            'Label16
            '
            Me.Label16.AccessibleDescription = resources.GetString("Label16.AccessibleDescription")
            Me.Label16.AccessibleName = resources.GetString("Label16.AccessibleName")
            Me.Label16.Anchor = CType(resources.GetObject("Label16.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label16.AutoSize = CType(resources.GetObject("Label16.AutoSize"), Boolean)
            Me.Label16.Dock = CType(resources.GetObject("Label16.Dock"), System.Windows.Forms.DockStyle)
            Me.Label16.Enabled = CType(resources.GetObject("Label16.Enabled"), Boolean)
            Me.Label16.Font = CType(resources.GetObject("Label16.Font"), System.Drawing.Font)
            Me.Label16.Image = CType(resources.GetObject("Label16.Image"), System.Drawing.Image)
            Me.Label16.ImageAlign = CType(resources.GetObject("Label16.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label16.ImageIndex = CType(resources.GetObject("Label16.ImageIndex"), Integer)
            Me.Label16.ImeMode = CType(resources.GetObject("Label16.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label16.Location = CType(resources.GetObject("Label16.Location"), System.Drawing.Point)
            Me.Label16.Name = "Label16"
            Me.Label16.RightToLeft = CType(resources.GetObject("Label16.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label16.Size = CType(resources.GetObject("Label16.Size"), System.Drawing.Size)
            Me.Label16.TabIndex = CType(resources.GetObject("Label16.TabIndex"), Integer)
            Me.Label16.Text = resources.GetString("Label16.Text")
            Me.Label16.TextAlign = CType(resources.GetObject("Label16.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label16, resources.GetString("Label16.ToolTip"))
            Me.Label16.Visible = CType(resources.GetObject("Label16.Visible"), Boolean)
            '
            'txtjeweldiameter
            '
            Me.txtjeweldiameter.AccessibleDescription = resources.GetString("txtjeweldiameter.AccessibleDescription")
            Me.txtjeweldiameter.AccessibleName = resources.GetString("txtjeweldiameter.AccessibleName")
            Me.txtjeweldiameter.Anchor = CType(resources.GetObject("txtjeweldiameter.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.txtjeweldiameter.AutoSize = CType(resources.GetObject("txtjeweldiameter.AutoSize"), Boolean)
            Me.txtjeweldiameter.BackgroundImage = CType(resources.GetObject("txtjeweldiameter.BackgroundImage"), System.Drawing.Image)
            Me.txtjeweldiameter.Dock = CType(resources.GetObject("txtjeweldiameter.Dock"), System.Windows.Forms.DockStyle)
            Me.txtjeweldiameter.Enabled = CType(resources.GetObject("txtjeweldiameter.Enabled"), Boolean)
            Me.txtjeweldiameter.Font = CType(resources.GetObject("txtjeweldiameter.Font"), System.Drawing.Font)
            Me.txtjeweldiameter.ImeMode = CType(resources.GetObject("txtjeweldiameter.ImeMode"), System.Windows.Forms.ImeMode)
            Me.txtjeweldiameter.Location = CType(resources.GetObject("txtjeweldiameter.Location"), System.Drawing.Point)
            Me.txtjeweldiameter.MaxLength = CType(resources.GetObject("txtjeweldiameter.MaxLength"), Integer)
            Me.txtjeweldiameter.Multiline = CType(resources.GetObject("txtjeweldiameter.Multiline"), Boolean)
            Me.txtjeweldiameter.Name = "txtjeweldiameter"
            Me.txtjeweldiameter.PasswordChar = CType(resources.GetObject("txtjeweldiameter.PasswordChar"), Char)
            Me.txtjeweldiameter.RightToLeft = CType(resources.GetObject("txtjeweldiameter.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.txtjeweldiameter.ScrollBars = CType(resources.GetObject("txtjeweldiameter.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.txtjeweldiameter.Size = CType(resources.GetObject("txtjeweldiameter.Size"), System.Drawing.Size)
            Me.txtjeweldiameter.TabIndex = CType(resources.GetObject("txtjeweldiameter.TabIndex"), Integer)
            Me.txtjeweldiameter.Text = resources.GetString("txtjeweldiameter.Text")
            Me.txtjeweldiameter.TextAlign = CType(resources.GetObject("txtjeweldiameter.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.txtjeweldiameter, resources.GetString("txtjeweldiameter.ToolTip"))
            Me.txtjeweldiameter.Visible = CType(resources.GetObject("txtjeweldiameter.Visible"), Boolean)
            Me.txtjeweldiameter.WordWrap = CType(resources.GetObject("txtjeweldiameter.WordWrap"), Boolean)
            '
            'txtabflow
            '
            Me.txtabflow.AccessibleDescription = resources.GetString("txtabflow.AccessibleDescription")
            Me.txtabflow.AccessibleName = resources.GetString("txtabflow.AccessibleName")
            Me.txtabflow.Anchor = CType(resources.GetObject("txtabflow.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.txtabflow.AutoSize = CType(resources.GetObject("txtabflow.AutoSize"), Boolean)
            Me.txtabflow.BackgroundImage = CType(resources.GetObject("txtabflow.BackgroundImage"), System.Drawing.Image)
            Me.txtabflow.Dock = CType(resources.GetObject("txtabflow.Dock"), System.Windows.Forms.DockStyle)
            Me.txtabflow.Enabled = CType(resources.GetObject("txtabflow.Enabled"), Boolean)
            Me.txtabflow.Font = CType(resources.GetObject("txtabflow.Font"), System.Drawing.Font)
            Me.txtabflow.ImeMode = CType(resources.GetObject("txtabflow.ImeMode"), System.Windows.Forms.ImeMode)
            Me.txtabflow.Location = CType(resources.GetObject("txtabflow.Location"), System.Drawing.Point)
            Me.txtabflow.MaxLength = CType(resources.GetObject("txtabflow.MaxLength"), Integer)
            Me.txtabflow.Multiline = CType(resources.GetObject("txtabflow.Multiline"), Boolean)
            Me.txtabflow.Name = "txtabflow"
            Me.txtabflow.PasswordChar = CType(resources.GetObject("txtabflow.PasswordChar"), Char)
            Me.txtabflow.RightToLeft = CType(resources.GetObject("txtabflow.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.txtabflow.ScrollBars = CType(resources.GetObject("txtabflow.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.txtabflow.Size = CType(resources.GetObject("txtabflow.Size"), System.Drawing.Size)
            Me.txtabflow.TabIndex = CType(resources.GetObject("txtabflow.TabIndex"), Integer)
            Me.txtabflow.Text = resources.GetString("txtabflow.Text")
            Me.txtabflow.TextAlign = CType(resources.GetObject("txtabflow.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.txtabflow, resources.GetString("txtabflow.ToolTip"))
            Me.txtabflow.Visible = CType(resources.GetObject("txtabflow.Visible"), Boolean)
            Me.txtabflow.WordWrap = CType(resources.GetObject("txtabflow.WordWrap"), Boolean)
            '
            'Label17
            '
            Me.Label17.AccessibleDescription = resources.GetString("Label17.AccessibleDescription")
            Me.Label17.AccessibleName = resources.GetString("Label17.AccessibleName")
            Me.Label17.Anchor = CType(resources.GetObject("Label17.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label17.AutoSize = CType(resources.GetObject("Label17.AutoSize"), Boolean)
            Me.Label17.Dock = CType(resources.GetObject("Label17.Dock"), System.Windows.Forms.DockStyle)
            Me.Label17.Enabled = CType(resources.GetObject("Label17.Enabled"), Boolean)
            Me.Label17.Font = CType(resources.GetObject("Label17.Font"), System.Drawing.Font)
            Me.Label17.Image = CType(resources.GetObject("Label17.Image"), System.Drawing.Image)
            Me.Label17.ImageAlign = CType(resources.GetObject("Label17.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label17.ImageIndex = CType(resources.GetObject("Label17.ImageIndex"), Integer)
            Me.Label17.ImeMode = CType(resources.GetObject("Label17.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label17.Location = CType(resources.GetObject("Label17.Location"), System.Drawing.Point)
            Me.Label17.Name = "Label17"
            Me.Label17.RightToLeft = CType(resources.GetObject("Label17.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label17.Size = CType(resources.GetObject("Label17.Size"), System.Drawing.Size)
            Me.Label17.TabIndex = CType(resources.GetObject("Label17.TabIndex"), Integer)
            Me.Label17.Text = resources.GetString("Label17.Text")
            Me.Label17.TextAlign = CType(resources.GetObject("Label17.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label17, resources.GetString("Label17.ToolTip"))
            Me.Label17.Visible = CType(resources.GetObject("Label17.Visible"), Boolean)
            '
            'Label18
            '
            Me.Label18.AccessibleDescription = resources.GetString("Label18.AccessibleDescription")
            Me.Label18.AccessibleName = resources.GetString("Label18.AccessibleName")
            Me.Label18.Anchor = CType(resources.GetObject("Label18.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label18.AutoSize = CType(resources.GetObject("Label18.AutoSize"), Boolean)
            Me.Label18.Dock = CType(resources.GetObject("Label18.Dock"), System.Windows.Forms.DockStyle)
            Me.Label18.Enabled = CType(resources.GetObject("Label18.Enabled"), Boolean)
            Me.Label18.Font = CType(resources.GetObject("Label18.Font"), System.Drawing.Font)
            Me.Label18.Image = CType(resources.GetObject("Label18.Image"), System.Drawing.Image)
            Me.Label18.ImageAlign = CType(resources.GetObject("Label18.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label18.ImageIndex = CType(resources.GetObject("Label18.ImageIndex"), Integer)
            Me.Label18.ImeMode = CType(resources.GetObject("Label18.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label18.Location = CType(resources.GetObject("Label18.Location"), System.Drawing.Point)
            Me.Label18.Name = "Label18"
            Me.Label18.RightToLeft = CType(resources.GetObject("Label18.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label18.Size = CType(resources.GetObject("Label18.Size"), System.Drawing.Size)
            Me.Label18.TabIndex = CType(resources.GetObject("Label18.TabIndex"), Integer)
            Me.Label18.Text = resources.GetString("Label18.Text")
            Me.Label18.TextAlign = CType(resources.GetObject("Label18.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label18, resources.GetString("Label18.ToolTip"))
            Me.Label18.Visible = CType(resources.GetObject("Label18.Visible"), Boolean)
            '
            'txtmtdiameter
            '
            Me.txtmtdiameter.AccessibleDescription = resources.GetString("txtmtdiameter.AccessibleDescription")
            Me.txtmtdiameter.AccessibleName = resources.GetString("txtmtdiameter.AccessibleName")
            Me.txtmtdiameter.Anchor = CType(resources.GetObject("txtmtdiameter.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.txtmtdiameter.AutoSize = CType(resources.GetObject("txtmtdiameter.AutoSize"), Boolean)
            Me.txtmtdiameter.BackgroundImage = CType(resources.GetObject("txtmtdiameter.BackgroundImage"), System.Drawing.Image)
            Me.txtmtdiameter.Dock = CType(resources.GetObject("txtmtdiameter.Dock"), System.Windows.Forms.DockStyle)
            Me.txtmtdiameter.Enabled = CType(resources.GetObject("txtmtdiameter.Enabled"), Boolean)
            Me.txtmtdiameter.Font = CType(resources.GetObject("txtmtdiameter.Font"), System.Drawing.Font)
            Me.txtmtdiameter.ImeMode = CType(resources.GetObject("txtmtdiameter.ImeMode"), System.Windows.Forms.ImeMode)
            Me.txtmtdiameter.Location = CType(resources.GetObject("txtmtdiameter.Location"), System.Drawing.Point)
            Me.txtmtdiameter.MaxLength = CType(resources.GetObject("txtmtdiameter.MaxLength"), Integer)
            Me.txtmtdiameter.Multiline = CType(resources.GetObject("txtmtdiameter.Multiline"), Boolean)
            Me.txtmtdiameter.Name = "txtmtdiameter"
            Me.txtmtdiameter.PasswordChar = CType(resources.GetObject("txtmtdiameter.PasswordChar"), Char)
            Me.txtmtdiameter.RightToLeft = CType(resources.GetObject("txtmtdiameter.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.txtmtdiameter.ScrollBars = CType(resources.GetObject("txtmtdiameter.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.txtmtdiameter.Size = CType(resources.GetObject("txtmtdiameter.Size"), System.Drawing.Size)
            Me.txtmtdiameter.TabIndex = CType(resources.GetObject("txtmtdiameter.TabIndex"), Integer)
            Me.txtmtdiameter.Text = resources.GetString("txtmtdiameter.Text")
            Me.txtmtdiameter.TextAlign = CType(resources.GetObject("txtmtdiameter.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.txtmtdiameter, resources.GetString("txtmtdiameter.ToolTip"))
            Me.txtmtdiameter.Visible = CType(resources.GetObject("txtmtdiameter.Visible"), Boolean)
            Me.txtmtdiameter.WordWrap = CType(resources.GetObject("txtmtdiameter.WordWrap"), Boolean)
            '
            'Label19
            '
            Me.Label19.AccessibleDescription = resources.GetString("Label19.AccessibleDescription")
            Me.Label19.AccessibleName = resources.GetString("Label19.AccessibleName")
            Me.Label19.Anchor = CType(resources.GetObject("Label19.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label19.AutoSize = CType(resources.GetObject("Label19.AutoSize"), Boolean)
            Me.Label19.Dock = CType(resources.GetObject("Label19.Dock"), System.Windows.Forms.DockStyle)
            Me.Label19.Enabled = CType(resources.GetObject("Label19.Enabled"), Boolean)
            Me.Label19.Font = CType(resources.GetObject("Label19.Font"), System.Drawing.Font)
            Me.Label19.Image = CType(resources.GetObject("Label19.Image"), System.Drawing.Image)
            Me.Label19.ImageAlign = CType(resources.GetObject("Label19.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label19.ImageIndex = CType(resources.GetObject("Label19.ImageIndex"), Integer)
            Me.Label19.ImeMode = CType(resources.GetObject("Label19.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label19.Location = CType(resources.GetObject("Label19.Location"), System.Drawing.Point)
            Me.Label19.Name = "Label19"
            Me.Label19.RightToLeft = CType(resources.GetObject("Label19.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label19.Size = CType(resources.GetObject("Label19.Size"), System.Drawing.Size)
            Me.Label19.TabIndex = CType(resources.GetObject("Label19.TabIndex"), Integer)
            Me.Label19.Text = resources.GetString("Label19.Text")
            Me.Label19.TextAlign = CType(resources.GetObject("Label19.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label19, resources.GetString("Label19.ToolTip"))
            Me.Label19.Visible = CType(resources.GetObject("Label19.Visible"), Boolean)
            '
            'Label20
            '
            Me.Label20.AccessibleDescription = resources.GetString("Label20.AccessibleDescription")
            Me.Label20.AccessibleName = resources.GetString("Label20.AccessibleName")
            Me.Label20.Anchor = CType(resources.GetObject("Label20.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label20.AutoSize = CType(resources.GetObject("Label20.AutoSize"), Boolean)
            Me.Label20.Dock = CType(resources.GetObject("Label20.Dock"), System.Windows.Forms.DockStyle)
            Me.Label20.Enabled = CType(resources.GetObject("Label20.Enabled"), Boolean)
            Me.Label20.Font = CType(resources.GetObject("Label20.Font"), System.Drawing.Font)
            Me.Label20.Image = CType(resources.GetObject("Label20.Image"), System.Drawing.Image)
            Me.Label20.ImageAlign = CType(resources.GetObject("Label20.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label20.ImageIndex = CType(resources.GetObject("Label20.ImageIndex"), Integer)
            Me.Label20.ImeMode = CType(resources.GetObject("Label20.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label20.Location = CType(resources.GetObject("Label20.Location"), System.Drawing.Point)
            Me.Label20.Name = "Label20"
            Me.Label20.RightToLeft = CType(resources.GetObject("Label20.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label20.Size = CType(resources.GetObject("Label20.Size"), System.Drawing.Size)
            Me.Label20.TabIndex = CType(resources.GetObject("Label20.TabIndex"), Integer)
            Me.Label20.Text = resources.GetString("Label20.Text")
            Me.Label20.TextAlign = CType(resources.GetObject("Label20.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label20, resources.GetString("Label20.ToolTip"))
            Me.Label20.Visible = CType(resources.GetObject("Label20.Visible"), Boolean)
            '
            'Label21
            '
            Me.Label21.AccessibleDescription = resources.GetString("Label21.AccessibleDescription")
            Me.Label21.AccessibleName = resources.GetString("Label21.AccessibleName")
            Me.Label21.Anchor = CType(resources.GetObject("Label21.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label21.AutoSize = CType(resources.GetObject("Label21.AutoSize"), Boolean)
            Me.Label21.Dock = CType(resources.GetObject("Label21.Dock"), System.Windows.Forms.DockStyle)
            Me.Label21.Enabled = CType(resources.GetObject("Label21.Enabled"), Boolean)
            Me.Label21.Font = CType(resources.GetObject("Label21.Font"), System.Drawing.Font)
            Me.Label21.Image = CType(resources.GetObject("Label21.Image"), System.Drawing.Image)
            Me.Label21.ImageAlign = CType(resources.GetObject("Label21.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label21.ImageIndex = CType(resources.GetObject("Label21.ImageIndex"), Integer)
            Me.Label21.ImeMode = CType(resources.GetObject("Label21.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label21.Location = CType(resources.GetObject("Label21.Location"), System.Drawing.Point)
            Me.Label21.Name = "Label21"
            Me.Label21.RightToLeft = CType(resources.GetObject("Label21.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label21.Size = CType(resources.GetObject("Label21.Size"), System.Drawing.Size)
            Me.Label21.TabIndex = CType(resources.GetObject("Label21.TabIndex"), Integer)
            Me.Label21.Text = resources.GetString("Label21.Text")
            Me.Label21.TextAlign = CType(resources.GetObject("Label21.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label21, resources.GetString("Label21.ToolTip"))
            Me.Label21.Visible = CType(resources.GetObject("Label21.Visible"), Boolean)
            '
            'Label22
            '
            Me.Label22.AccessibleDescription = resources.GetString("Label22.AccessibleDescription")
            Me.Label22.AccessibleName = resources.GetString("Label22.AccessibleName")
            Me.Label22.Anchor = CType(resources.GetObject("Label22.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label22.AutoSize = CType(resources.GetObject("Label22.AutoSize"), Boolean)
            Me.Label22.Dock = CType(resources.GetObject("Label22.Dock"), System.Windows.Forms.DockStyle)
            Me.Label22.Enabled = CType(resources.GetObject("Label22.Enabled"), Boolean)
            Me.Label22.Font = CType(resources.GetObject("Label22.Font"), System.Drawing.Font)
            Me.Label22.Image = CType(resources.GetObject("Label22.Image"), System.Drawing.Image)
            Me.Label22.ImageAlign = CType(resources.GetObject("Label22.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label22.ImageIndex = CType(resources.GetObject("Label22.ImageIndex"), Integer)
            Me.Label22.ImeMode = CType(resources.GetObject("Label22.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label22.Location = CType(resources.GetObject("Label22.Location"), System.Drawing.Point)
            Me.Label22.Name = "Label22"
            Me.Label22.RightToLeft = CType(resources.GetObject("Label22.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label22.Size = CType(resources.GetObject("Label22.Size"), System.Drawing.Size)
            Me.Label22.TabIndex = CType(resources.GetObject("Label22.TabIndex"), Integer)
            Me.Label22.Text = resources.GetString("Label22.Text")
            Me.Label22.TextAlign = CType(resources.GetObject("Label22.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label22, resources.GetString("Label22.ToolTip"))
            Me.Label22.Visible = CType(resources.GetObject("Label22.Visible"), Boolean)
            '
            'txtpressure
            '
            Me.txtpressure.AccessibleDescription = resources.GetString("txtpressure.AccessibleDescription")
            Me.txtpressure.AccessibleName = resources.GetString("txtpressure.AccessibleName")
            Me.txtpressure.Anchor = CType(resources.GetObject("txtpressure.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.txtpressure.AutoSize = CType(resources.GetObject("txtpressure.AutoSize"), Boolean)
            Me.txtpressure.BackgroundImage = CType(resources.GetObject("txtpressure.BackgroundImage"), System.Drawing.Image)
            Me.txtpressure.Dock = CType(resources.GetObject("txtpressure.Dock"), System.Windows.Forms.DockStyle)
            Me.txtpressure.Enabled = CType(resources.GetObject("txtpressure.Enabled"), Boolean)
            Me.txtpressure.Font = CType(resources.GetObject("txtpressure.Font"), System.Drawing.Font)
            Me.txtpressure.ImeMode = CType(resources.GetObject("txtpressure.ImeMode"), System.Windows.Forms.ImeMode)
            Me.txtpressure.Location = CType(resources.GetObject("txtpressure.Location"), System.Drawing.Point)
            Me.txtpressure.MaxLength = CType(resources.GetObject("txtpressure.MaxLength"), Integer)
            Me.txtpressure.Multiline = CType(resources.GetObject("txtpressure.Multiline"), Boolean)
            Me.txtpressure.Name = "txtpressure"
            Me.txtpressure.PasswordChar = CType(resources.GetObject("txtpressure.PasswordChar"), Char)
            Me.txtpressure.RightToLeft = CType(resources.GetObject("txtpressure.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.txtpressure.ScrollBars = CType(resources.GetObject("txtpressure.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.txtpressure.Size = CType(resources.GetObject("txtpressure.Size"), System.Drawing.Size)
            Me.txtpressure.TabIndex = CType(resources.GetObject("txtpressure.TabIndex"), Integer)
            Me.txtpressure.Text = resources.GetString("txtpressure.Text")
            Me.txtpressure.TextAlign = CType(resources.GetObject("txtpressure.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.txtpressure, resources.GetString("txtpressure.ToolTip"))
            Me.txtpressure.Visible = CType(resources.GetObject("txtpressure.Visible"), Boolean)
            Me.txtpressure.WordWrap = CType(resources.GetObject("txtpressure.WordWrap"), Boolean)
            '
            'Label23
            '
            Me.Label23.AccessibleDescription = resources.GetString("Label23.AccessibleDescription")
            Me.Label23.AccessibleName = resources.GetString("Label23.AccessibleName")
            Me.Label23.Anchor = CType(resources.GetObject("Label23.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label23.AutoSize = CType(resources.GetObject("Label23.AutoSize"), Boolean)
            Me.Label23.Dock = CType(resources.GetObject("Label23.Dock"), System.Windows.Forms.DockStyle)
            Me.Label23.Enabled = CType(resources.GetObject("Label23.Enabled"), Boolean)
            Me.Label23.Font = CType(resources.GetObject("Label23.Font"), System.Drawing.Font)
            Me.Label23.Image = CType(resources.GetObject("Label23.Image"), System.Drawing.Image)
            Me.Label23.ImageAlign = CType(resources.GetObject("Label23.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label23.ImageIndex = CType(resources.GetObject("Label23.ImageIndex"), Integer)
            Me.Label23.ImeMode = CType(resources.GetObject("Label23.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label23.Location = CType(resources.GetObject("Label23.Location"), System.Drawing.Point)
            Me.Label23.Name = "Label23"
            Me.Label23.RightToLeft = CType(resources.GetObject("Label23.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label23.Size = CType(resources.GetObject("Label23.Size"), System.Drawing.Size)
            Me.Label23.TabIndex = CType(resources.GetObject("Label23.TabIndex"), Integer)
            Me.Label23.Text = resources.GetString("Label23.Text")
            Me.Label23.TextAlign = CType(resources.GetObject("Label23.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label23, resources.GetString("Label23.ToolTip"))
            Me.Label23.Visible = CType(resources.GetObject("Label23.Visible"), Boolean)
            '
            'Label24
            '
            Me.Label24.AccessibleDescription = resources.GetString("Label24.AccessibleDescription")
            Me.Label24.AccessibleName = resources.GetString("Label24.AccessibleName")
            Me.Label24.Anchor = CType(resources.GetObject("Label24.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label24.AutoSize = CType(resources.GetObject("Label24.AutoSize"), Boolean)
            Me.Label24.Dock = CType(resources.GetObject("Label24.Dock"), System.Windows.Forms.DockStyle)
            Me.Label24.Enabled = CType(resources.GetObject("Label24.Enabled"), Boolean)
            Me.Label24.Font = CType(resources.GetObject("Label24.Font"), System.Drawing.Font)
            Me.Label24.Image = CType(resources.GetObject("Label24.Image"), System.Drawing.Image)
            Me.Label24.ImageAlign = CType(resources.GetObject("Label24.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label24.ImageIndex = CType(resources.GetObject("Label24.ImageIndex"), Integer)
            Me.Label24.ImeMode = CType(resources.GetObject("Label24.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label24.Location = CType(resources.GetObject("Label24.Location"), System.Drawing.Point)
            Me.Label24.Name = "Label24"
            Me.Label24.RightToLeft = CType(resources.GetObject("Label24.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label24.Size = CType(resources.GetObject("Label24.Size"), System.Drawing.Size)
            Me.Label24.TabIndex = CType(resources.GetObject("Label24.TabIndex"), Integer)
            Me.Label24.Text = resources.GetString("Label24.Text")
            Me.Label24.TextAlign = CType(resources.GetObject("Label24.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label24, resources.GetString("Label24.ToolTip"))
            Me.Label24.Visible = CType(resources.GetObject("Label24.Visible"), Boolean)
            '
            'Label25
            '
            Me.Label25.AccessibleDescription = resources.GetString("Label25.AccessibleDescription")
            Me.Label25.AccessibleName = resources.GetString("Label25.AccessibleName")
            Me.Label25.Anchor = CType(resources.GetObject("Label25.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label25.AutoSize = CType(resources.GetObject("Label25.AutoSize"), Boolean)
            Me.Label25.Dock = CType(resources.GetObject("Label25.Dock"), System.Windows.Forms.DockStyle)
            Me.Label25.Enabled = CType(resources.GetObject("Label25.Enabled"), Boolean)
            Me.Label25.Font = CType(resources.GetObject("Label25.Font"), System.Drawing.Font)
            Me.Label25.Image = CType(resources.GetObject("Label25.Image"), System.Drawing.Image)
            Me.Label25.ImageAlign = CType(resources.GetObject("Label25.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label25.ImageIndex = CType(resources.GetObject("Label25.ImageIndex"), Integer)
            Me.Label25.ImeMode = CType(resources.GetObject("Label25.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label25.Location = CType(resources.GetObject("Label25.Location"), System.Drawing.Point)
            Me.Label25.Name = "Label25"
            Me.Label25.RightToLeft = CType(resources.GetObject("Label25.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label25.Size = CType(resources.GetObject("Label25.Size"), System.Drawing.Size)
            Me.Label25.TabIndex = CType(resources.GetObject("Label25.TabIndex"), Integer)
            Me.Label25.Text = resources.GetString("Label25.Text")
            Me.Label25.TextAlign = CType(resources.GetObject("Label25.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label25, resources.GetString("Label25.ToolTip"))
            Me.Label25.Visible = CType(resources.GetObject("Label25.Visible"), Boolean)
            '
            'Label26
            '
            Me.Label26.AccessibleDescription = resources.GetString("Label26.AccessibleDescription")
            Me.Label26.AccessibleName = resources.GetString("Label26.AccessibleName")
            Me.Label26.Anchor = CType(resources.GetObject("Label26.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.Label26.AutoSize = CType(resources.GetObject("Label26.AutoSize"), Boolean)
            Me.Label26.Dock = CType(resources.GetObject("Label26.Dock"), System.Windows.Forms.DockStyle)
            Me.Label26.Enabled = CType(resources.GetObject("Label26.Enabled"), Boolean)
            Me.Label26.Font = CType(resources.GetObject("Label26.Font"), System.Drawing.Font)
            Me.Label26.Image = CType(resources.GetObject("Label26.Image"), System.Drawing.Image)
            Me.Label26.ImageAlign = CType(resources.GetObject("Label26.ImageAlign"), System.Drawing.ContentAlignment)
            Me.Label26.ImageIndex = CType(resources.GetObject("Label26.ImageIndex"), Integer)
            Me.Label26.ImeMode = CType(resources.GetObject("Label26.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Label26.Location = CType(resources.GetObject("Label26.Location"), System.Drawing.Point)
            Me.Label26.Name = "Label26"
            Me.Label26.RightToLeft = CType(resources.GetObject("Label26.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.Label26.Size = CType(resources.GetObject("Label26.Size"), System.Drawing.Size)
            Me.Label26.TabIndex = CType(resources.GetObject("Label26.TabIndex"), Integer)
            Me.Label26.Text = resources.GetString("Label26.Text")
            Me.Label26.TextAlign = CType(resources.GetObject("Label26.TextAlign"), System.Drawing.ContentAlignment)
            Me.ToolTip1.SetToolTip(Me.Label26, resources.GetString("Label26.ToolTip"))
            Me.Label26.Visible = CType(resources.GetObject("Label26.Visible"), Boolean)
            '
            'txtsod
            '
            Me.txtsod.AccessibleDescription = resources.GetString("txtsod.AccessibleDescription")
            Me.txtsod.AccessibleName = resources.GetString("txtsod.AccessibleName")
            Me.txtsod.Anchor = CType(resources.GetObject("txtsod.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.txtsod.AutoSize = CType(resources.GetObject("txtsod.AutoSize"), Boolean)
            Me.txtsod.BackgroundImage = CType(resources.GetObject("txtsod.BackgroundImage"), System.Drawing.Image)
            Me.txtsod.Dock = CType(resources.GetObject("txtsod.Dock"), System.Windows.Forms.DockStyle)
            Me.txtsod.Enabled = CType(resources.GetObject("txtsod.Enabled"), Boolean)
            Me.txtsod.Font = CType(resources.GetObject("txtsod.Font"), System.Drawing.Font)
            Me.txtsod.ImeMode = CType(resources.GetObject("txtsod.ImeMode"), System.Windows.Forms.ImeMode)
            Me.txtsod.Location = CType(resources.GetObject("txtsod.Location"), System.Drawing.Point)
            Me.txtsod.MaxLength = CType(resources.GetObject("txtsod.MaxLength"), Integer)
            Me.txtsod.Multiline = CType(resources.GetObject("txtsod.Multiline"), Boolean)
            Me.txtsod.Name = "txtsod"
            Me.txtsod.PasswordChar = CType(resources.GetObject("txtsod.PasswordChar"), Char)
            Me.txtsod.RightToLeft = CType(resources.GetObject("txtsod.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.txtsod.ScrollBars = CType(resources.GetObject("txtsod.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.txtsod.Size = CType(resources.GetObject("txtsod.Size"), System.Drawing.Size)
            Me.txtsod.TabIndex = CType(resources.GetObject("txtsod.TabIndex"), Integer)
            Me.txtsod.Text = resources.GetString("txtsod.Text")
            Me.txtsod.TextAlign = CType(resources.GetObject("txtsod.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.ToolTip1.SetToolTip(Me.txtsod, resources.GetString("txtsod.ToolTip"))
            Me.txtsod.Visible = CType(resources.GetObject("txtsod.Visible"), Boolean)
            Me.txtsod.WordWrap = CType(resources.GetObject("txtsod.WordWrap"), Boolean)
            '
            'cbo_pump
            '
            Me.cbo_pump.AccessibleDescription = resources.GetString("cbo_pump.AccessibleDescription")
            Me.cbo_pump.AccessibleName = resources.GetString("cbo_pump.AccessibleName")
            Me.cbo_pump.Anchor = CType(resources.GetObject("cbo_pump.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.cbo_pump.BackgroundImage = CType(resources.GetObject("cbo_pump.BackgroundImage"), System.Drawing.Image)
            Me.cbo_pump.Dock = CType(resources.GetObject("cbo_pump.Dock"), System.Windows.Forms.DockStyle)
            Me.cbo_pump.Enabled = CType(resources.GetObject("cbo_pump.Enabled"), Boolean)
            Me.cbo_pump.Font = CType(resources.GetObject("cbo_pump.Font"), System.Drawing.Font)
            Me.cbo_pump.ImeMode = CType(resources.GetObject("cbo_pump.ImeMode"), System.Windows.Forms.ImeMode)
            Me.cbo_pump.IntegralHeight = CType(resources.GetObject("cbo_pump.IntegralHeight"), Boolean)
            Me.cbo_pump.ItemHeight = CType(resources.GetObject("cbo_pump.ItemHeight"), Integer)
            Me.cbo_pump.Location = CType(resources.GetObject("cbo_pump.Location"), System.Drawing.Point)
            Me.cbo_pump.MaxDropDownItems = CType(resources.GetObject("cbo_pump.MaxDropDownItems"), Integer)
            Me.cbo_pump.MaxLength = CType(resources.GetObject("cbo_pump.MaxLength"), Integer)
            Me.cbo_pump.Name = "cbo_pump"
            Me.cbo_pump.RightToLeft = CType(resources.GetObject("cbo_pump.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.cbo_pump.Size = CType(resources.GetObject("cbo_pump.Size"), System.Drawing.Size)
            Me.cbo_pump.TabIndex = CType(resources.GetObject("cbo_pump.TabIndex"), Integer)
            Me.cbo_pump.Text = resources.GetString("cbo_pump.Text")
            Me.ToolTip1.SetToolTip(Me.cbo_pump, resources.GetString("cbo_pump.ToolTip"))
            Me.cbo_pump.Visible = CType(resources.GetObject("cbo_pump.Visible"), Boolean)
            '
            'cbo_abrasivetype
            '
            Me.cbo_abrasivetype.AccessibleDescription = resources.GetString("cbo_abrasivetype.AccessibleDescription")
            Me.cbo_abrasivetype.AccessibleName = resources.GetString("cbo_abrasivetype.AccessibleName")
            Me.cbo_abrasivetype.Anchor = CType(resources.GetObject("cbo_abrasivetype.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.cbo_abrasivetype.BackgroundImage = CType(resources.GetObject("cbo_abrasivetype.BackgroundImage"), System.Drawing.Image)
            Me.cbo_abrasivetype.Dock = CType(resources.GetObject("cbo_abrasivetype.Dock"), System.Windows.Forms.DockStyle)
            Me.cbo_abrasivetype.Enabled = CType(resources.GetObject("cbo_abrasivetype.Enabled"), Boolean)
            Me.cbo_abrasivetype.Font = CType(resources.GetObject("cbo_abrasivetype.Font"), System.Drawing.Font)
            Me.cbo_abrasivetype.ImeMode = CType(resources.GetObject("cbo_abrasivetype.ImeMode"), System.Windows.Forms.ImeMode)
            Me.cbo_abrasivetype.IntegralHeight = CType(resources.GetObject("cbo_abrasivetype.IntegralHeight"), Boolean)
            Me.cbo_abrasivetype.ItemHeight = CType(resources.GetObject("cbo_abrasivetype.ItemHeight"), Integer)
            Me.cbo_abrasivetype.Location = CType(resources.GetObject("cbo_abrasivetype.Location"), System.Drawing.Point)
            Me.cbo_abrasivetype.MaxDropDownItems = CType(resources.GetObject("cbo_abrasivetype.MaxDropDownItems"), Integer)
            Me.cbo_abrasivetype.MaxLength = CType(resources.GetObject("cbo_abrasivetype.MaxLength"), Integer)
            Me.cbo_abrasivetype.Name = "cbo_abrasivetype"
            Me.cbo_abrasivetype.RightToLeft = CType(resources.GetObject("cbo_abrasivetype.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.cbo_abrasivetype.Size = CType(resources.GetObject("cbo_abrasivetype.Size"), System.Drawing.Size)
            Me.cbo_abrasivetype.TabIndex = CType(resources.GetObject("cbo_abrasivetype.TabIndex"), Integer)
            Me.cbo_abrasivetype.Text = resources.GetString("cbo_abrasivetype.Text")
            Me.ToolTip1.SetToolTip(Me.cbo_abrasivetype, resources.GetString("cbo_abrasivetype.ToolTip"))
            Me.cbo_abrasivetype.Visible = CType(resources.GetObject("cbo_abrasivetype.Visible"), Boolean)
            '
            'cbo_machine
            '
            Me.cbo_machine.AccessibleDescription = resources.GetString("cbo_machine.AccessibleDescription")
            Me.cbo_machine.AccessibleName = resources.GetString("cbo_machine.AccessibleName")
            Me.cbo_machine.Anchor = CType(resources.GetObject("cbo_machine.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.cbo_machine.BackgroundImage = CType(resources.GetObject("cbo_machine.BackgroundImage"), System.Drawing.Image)
            Me.cbo_machine.Dock = CType(resources.GetObject("cbo_machine.Dock"), System.Windows.Forms.DockStyle)
            Me.cbo_machine.Enabled = CType(resources.GetObject("cbo_machine.Enabled"), Boolean)
            Me.cbo_machine.Font = CType(resources.GetObject("cbo_machine.Font"), System.Drawing.Font)
            Me.cbo_machine.ImeMode = CType(resources.GetObject("cbo_machine.ImeMode"), System.Windows.Forms.ImeMode)
            Me.cbo_machine.IntegralHeight = CType(resources.GetObject("cbo_machine.IntegralHeight"), Boolean)
            Me.cbo_machine.ItemHeight = CType(resources.GetObject("cbo_machine.ItemHeight"), Integer)
            Me.cbo_machine.Location = CType(resources.GetObject("cbo_machine.Location"), System.Drawing.Point)
            Me.cbo_machine.MaxDropDownItems = CType(resources.GetObject("cbo_machine.MaxDropDownItems"), Integer)
            Me.cbo_machine.MaxLength = CType(resources.GetObject("cbo_machine.MaxLength"), Integer)
            Me.cbo_machine.Name = "cbo_machine"
            Me.cbo_machine.RightToLeft = CType(resources.GetObject("cbo_machine.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.cbo_machine.Size = CType(resources.GetObject("cbo_machine.Size"), System.Drawing.Size)
            Me.cbo_machine.TabIndex = CType(resources.GetObject("cbo_machine.TabIndex"), Integer)
            Me.cbo_machine.Text = resources.GetString("cbo_machine.Text")
            Me.ToolTip1.SetToolTip(Me.cbo_machine, resources.GetString("cbo_machine.ToolTip"))
            Me.cbo_machine.Visible = CType(resources.GetObject("cbo_machine.Visible"), Boolean)
            '
            'cbo_nozzletype
            '
            Me.cbo_nozzletype.AccessibleDescription = resources.GetString("cbo_nozzletype.AccessibleDescription")
            Me.cbo_nozzletype.AccessibleName = resources.GetString("cbo_nozzletype.AccessibleName")
            Me.cbo_nozzletype.Anchor = CType(resources.GetObject("cbo_nozzletype.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.cbo_nozzletype.BackgroundImage = CType(resources.GetObject("cbo_nozzletype.BackgroundImage"), System.Drawing.Image)
            Me.cbo_nozzletype.Dock = CType(resources.GetObject("cbo_nozzletype.Dock"), System.Windows.Forms.DockStyle)
            Me.cbo_nozzletype.Enabled = CType(resources.GetObject("cbo_nozzletype.Enabled"), Boolean)
            Me.cbo_nozzletype.Font = CType(resources.GetObject("cbo_nozzletype.Font"), System.Drawing.Font)
            Me.cbo_nozzletype.ImeMode = CType(resources.GetObject("cbo_nozzletype.ImeMode"), System.Windows.Forms.ImeMode)
            Me.cbo_nozzletype.IntegralHeight = CType(resources.GetObject("cbo_nozzletype.IntegralHeight"), Boolean)
            Me.cbo_nozzletype.ItemHeight = CType(resources.GetObject("cbo_nozzletype.ItemHeight"), Integer)
            Me.cbo_nozzletype.Location = CType(resources.GetObject("cbo_nozzletype.Location"), System.Drawing.Point)
            Me.cbo_nozzletype.MaxDropDownItems = CType(resources.GetObject("cbo_nozzletype.MaxDropDownItems"), Integer)
            Me.cbo_nozzletype.MaxLength = CType(resources.GetObject("cbo_nozzletype.MaxLength"), Integer)
            Me.cbo_nozzletype.Name = "cbo_nozzletype"
            Me.cbo_nozzletype.RightToLeft = CType(resources.GetObject("cbo_nozzletype.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.cbo_nozzletype.Size = CType(resources.GetObject("cbo_nozzletype.Size"), System.Drawing.Size)
            Me.cbo_nozzletype.TabIndex = CType(resources.GetObject("cbo_nozzletype.TabIndex"), Integer)
            Me.cbo_nozzletype.Text = resources.GetString("cbo_nozzletype.Text")
            Me.ToolTip1.SetToolTip(Me.cbo_nozzletype, resources.GetString("cbo_nozzletype.ToolTip"))
            Me.cbo_nozzletype.Visible = CType(resources.GetObject("cbo_nozzletype.Visible"), Boolean)
            '
            'cbo_jeweltype
            '
            Me.cbo_jeweltype.AccessibleDescription = resources.GetString("cbo_jeweltype.AccessibleDescription")
            Me.cbo_jeweltype.AccessibleName = resources.GetString("cbo_jeweltype.AccessibleName")
            Me.cbo_jeweltype.Anchor = CType(resources.GetObject("cbo_jeweltype.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.cbo_jeweltype.BackgroundImage = CType(resources.GetObject("cbo_jeweltype.BackgroundImage"), System.Drawing.Image)
            Me.cbo_jeweltype.Dock = CType(resources.GetObject("cbo_jeweltype.Dock"), System.Windows.Forms.DockStyle)
            Me.cbo_jeweltype.Enabled = CType(resources.GetObject("cbo_jeweltype.Enabled"), Boolean)
            Me.cbo_jeweltype.Font = CType(resources.GetObject("cbo_jeweltype.Font"), System.Drawing.Font)
            Me.cbo_jeweltype.ImeMode = CType(resources.GetObject("cbo_jeweltype.ImeMode"), System.Windows.Forms.ImeMode)
            Me.cbo_jeweltype.IntegralHeight = CType(resources.GetObject("cbo_jeweltype.IntegralHeight"), Boolean)
            Me.cbo_jeweltype.ItemHeight = CType(resources.GetObject("cbo_jeweltype.ItemHeight"), Integer)
            Me.cbo_jeweltype.Location = CType(resources.GetObject("cbo_jeweltype.Location"), System.Drawing.Point)
            Me.cbo_jeweltype.MaxDropDownItems = CType(resources.GetObject("cbo_jeweltype.MaxDropDownItems"), Integer)
            Me.cbo_jeweltype.MaxLength = CType(resources.GetObject("cbo_jeweltype.MaxLength"), Integer)
            Me.cbo_jeweltype.Name = "cbo_jeweltype"
            Me.cbo_jeweltype.RightToLeft = CType(resources.GetObject("cbo_jeweltype.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.cbo_jeweltype.Size = CType(resources.GetObject("cbo_jeweltype.Size"), System.Drawing.Size)
            Me.cbo_jeweltype.TabIndex = CType(resources.GetObject("cbo_jeweltype.TabIndex"), Integer)
            Me.cbo_jeweltype.Text = resources.GetString("cbo_jeweltype.Text")
            Me.ToolTip1.SetToolTip(Me.cbo_jeweltype, resources.GetString("cbo_jeweltype.ToolTip"))
            Me.cbo_jeweltype.Visible = CType(resources.GetObject("cbo_jeweltype.Visible"), Boolean)
            '
            'parminput
            '
            Me.AcceptButton = Me.load_parms
            Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
            Me.AccessibleName = resources.GetString("$this.AccessibleName")
            Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
            Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.CancelButton = Me.cancel_load
            Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
            Me.ControlBox = False
            Me.Controls.Add(Me.cbo_pump)
            Me.Controls.Add(Me.Groovedir)
            Me.Controls.Add(Me.load_parms)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.nomdepth)
            Me.Controls.Add(Me.matthickness)
            Me.Controls.Add(Me.defjetdiam)
            Me.Controls.Add(Me.depthperrun)
            Me.Controls.Add(Me.nomfeedrate)
            Me.Controls.Add(Me.number_of_runs)
            Me.Controls.Add(Me.thetacrit)
            Me.Controls.Add(Me.depthtolerance)
            Me.Controls.Add(Me.testdepth)
            Me.Controls.Add(Me.testspeed)
            Me.Controls.Add(Me.testpasses)
            Me.Controls.Add(Me.mrr_type)
            Me.Controls.Add(Me.armradius)
            Me.Controls.Add(Me.txtmtlength)
            Me.Controls.Add(Me.txtjeweldiameter)
            Me.Controls.Add(Me.txtabflow)
            Me.Controls.Add(Me.txtmtdiameter)
            Me.Controls.Add(Me.txtpressure)
            Me.Controls.Add(Me.txtsod)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.Label8)
            Me.Controls.Add(Me.cancel_load)
            Me.Controls.Add(Me.Label9)
            Me.Controls.Add(Me.Label10)
            Me.Controls.Add(Me.Label11)
            Me.Controls.Add(Me.Label12)
            Me.Controls.Add(Me.Label13)
            Me.Controls.Add(Me.Label14)
            Me.Controls.Add(Me.lstbxoperation)
            Me.Controls.Add(Me.Label15)
            Me.Controls.Add(Me.Label16)
            Me.Controls.Add(Me.Label17)
            Me.Controls.Add(Me.Label18)
            Me.Controls.Add(Me.Label19)
            Me.Controls.Add(Me.Label20)
            Me.Controls.Add(Me.Label21)
            Me.Controls.Add(Me.Label22)
            Me.Controls.Add(Me.Label23)
            Me.Controls.Add(Me.Label24)
            Me.Controls.Add(Me.Label25)
            Me.Controls.Add(Me.Label26)
            Me.Controls.Add(Me.cbo_abrasivetype)
            Me.Controls.Add(Me.cbo_machine)
            Me.Controls.Add(Me.cbo_nozzletype)
            Me.Controls.Add(Me.cbo_jeweltype)
            Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.MaximizeBox = False
            Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
            Me.MinimizeBox = False
            Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
            Me.Name = "parminput"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
            Me.Text = resources.GetString("$this.Text")
            Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub load_parms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load_parms.Click


            Dim validentry As Boolean
            Dim validdata As Boolean = True

            checkdbl(matthickness.Text, material_thickness, validentry)
            validdata = validdata And validentry

            checkdbl(nomdepth.Text, nom_depth, 0, material_thickness, validentry)
            validdata = validdata And validentry
            checkdbl(depthtolerance.Text, depth_tolerance, 0, nom_depth, validentry)
            validdata = validdata And validentry
            checkdbl(defjetdiam.Text, defccomp, 0, 1.0E+30, validentry)
            validdata = validdata And validentry
            checkdbl(depthperrun.Text, depth_per_run, 0, 10, validentry)
            validdata = validdata And validentry
            checkdbl(nomfeedrate.Text, nom_feedrate, 0, 1.0E+30, validentry)
            validdata = validdata And validentry
            checkshort(number_of_runs.Text, numberruns, 0, 30000, validentry)
            validdata = validdata And validentry
            checkdbl(thetacrit.Text, crit_angle_1, 0, 90, validentry)
            validdata = validdata And validentry
            checkint(mrr_type.Text, mrrtype, 0, 10000, validentry)
            validdata = validdata And validentry
            validdata = parameters_loaded
            strgroovedir = CStr(Groovedir.SelectedItem)
            grvedir = CType(Groovedir.SelectedIndex, WindowsApplication1.abmach.mdmodel.groovedirection)
            checktextinput(str_abrasiveflow, Me.txtabflow.Text)
            checktextinput(str_jeweldiameter, Me.txtjeweldiameter.Text)
            checktextinput(str_sod, Me.txtsod.Text)
            checktextinput(str_mixingtlength, Me.txtmtlength.Text)
            checktextinput(str_pressure, Me.txtpressure.Text)
            checktextinput(str_mixingtdiameter, Me.txtmtdiameter.Text)
            checktextinput(str_machinename, Me.cbo_machine.Text)
            checktextinput(str_pumpname, Me.cbo_pump.Text)
            checktextinput(str_nozzle, Me.cbo_nozzletype.Text)
            checktextinput(str_jeweltype, Me.cbo_jeweltype.Text)
            checktextinput(str_abrasivetype, Me.cbo_abrasivetype.Text)

            'Dim a As Integer = lstbxoperation.SelectedIndex()
            'Select Case a
            '    Case 0 's-channel 
            '        surfacemesh = 19
            '        frfootprint = 2
            '    Case 1 'r-channel
            '        surfacemesh = 19
            '        frfootprint = 2
            '    Case 2 'mill
            '        surfacemesh = 19
            '        frfootprint = 2
            '    Case 3 'other
            '        surfacemesh = 19
            '        frfootprint = 2
            'End Select

            If testpasses.Visible = True Then
                test_passes = CInt(testpasses.Text)
                test_depth = CDbl(testdepth.Text)
                test_speed = CDbl(testspeed.Text)
                depth_per_run = CDec((test_speed / nom_feedrate) * test_depth / test_passes)
            End If
            If newparameter Then
                saveparminput()

            End If

            Me.Close()

        End Sub
        Function validdata(ByVal entry As Boolean) As Boolean

        End Function
        Sub checkdbl(ByVal inputstring As String, ByRef outputvariable As Double, ByVal min As Double, ByVal max As Double, ByRef convsuccess As Boolean)
            If IsNumeric(inputstring) Then
                outputvariable = CDbl(inputstring)
            Else
                convsuccess = False
                Exit Sub
            End If
            If outputvariable > min And outputvariable < max Then
                convsuccess = True
            Else
                convsuccess = False
                Exit Sub
            End If
        End Sub
        Sub checkdbl(ByVal inputstring As String, ByRef outputvariable As Double, ByRef convsuccess As Boolean)
            If IsNumeric(inputstring) Then
                outputvariable = CDbl(inputstring)
                convsuccess = True
            Else
                convsuccess = False
                Exit Sub
            End If
        End Sub
        Sub checkdec(ByVal inputstring As String, ByRef outputvariable As Decimal, ByVal min As Double, ByVal max As Double, ByRef convsuccess As Boolean)
            If IsNumeric(inputstring) Then
                outputvariable = CDec(inputstring)
            Else
                convsuccess = False
                Exit Sub
            End If
            If outputvariable > min And outputvariable < max Then
                convsuccess = True
            Else
                convsuccess = False
                Exit Sub
            End If
        End Sub
        Sub checkdec(ByVal inputstring As String, ByRef outputvariable As Decimal, ByRef convsuccess As Boolean)
            If IsNumeric(inputstring) Then
                outputvariable = CDec(inputstring)
                convsuccess = True
            Else
                convsuccess = False
                Exit Sub
            End If
        End Sub
        Sub checkshort(ByVal inputstring As String, ByRef outputvariable As Short, ByVal min As Double, ByVal max As Double, ByRef convsuccess As Boolean)
            If IsNumeric(inputstring) Then
                outputvariable = CShort(inputstring)
            Else
                convsuccess = False
                Exit Sub
            End If
            If outputvariable > min And outputvariable < max Then
                convsuccess = True
            Else
                convsuccess = False
                Exit Sub
            End If
        End Sub
        Sub checkshort(ByVal inputstring As String, ByRef outputvariable As Short, ByRef convsuccess As Boolean)
            If IsNumeric(inputstring) Then
                outputvariable = CShort(inputstring)
                convsuccess = True
            Else
                convsuccess = False
                Exit Sub
            End If
        End Sub
        Sub checkint(ByVal inputstring As String, ByRef outputvariable As Integer, ByVal min As Double, ByVal max As Double, ByRef convsuccess As Boolean)
            If IsNumeric(inputstring) Then
                outputvariable = CInt(inputstring)
            Else
                convsuccess = False
                Exit Sub
            End If
            If outputvariable > min And outputvariable < max Then
                convsuccess = True
            Else
                convsuccess = False
                Exit Sub
            End If
        End Sub
        Sub checkint(ByVal inputstring As String, ByRef outputvariable As Integer, ByRef convsuccess As Boolean)
            If IsNumeric(inputstring) Then
                outputvariable = CInt(inputstring)
                convsuccess = True
            Else
                convsuccess = False
                Exit Sub
            End If
        End Sub
        Sub saveparminput()
            Dim items As ComboBox.ObjectCollection
            Dim name, value As String
            Dim machinecount As Integer = Me.cbo_machine.Items.Count
            Dim nozzlecount As Integer = Me.cbo_nozzletype.Items.Count
            Dim abrcount As Integer = Me.cbo_abrasivetype.Items.Count
            Dim jewelcount As Integer = Me.cbo_jeweltype.Items.Count
            Dim pumpcount As Integer = Me.cbo_pump.Items.Count
            Dim i As Integer
            File.Copy(sparmxmlfilepath, oldparmxmlfilepath, True)
            Try
                Dim xmlwriter As New XmlTextWriter(sparmxmlfilepath, Nothing)
                xmlwriter.Formatting = Formatting.Indented
                xmlwriter.WriteStartDocument()
                xmlwriter.WriteStartElement(csparminput)

                If machinecount <> 0 Then
                    xmlwriter.WriteStartElement(csmachine)
                    For i = 0 To machinecount - 1
                        name = csmachine & CStr(i)
                        value = Me.cbo_machine.Items.Item(i)
                        If value <> "" Then xmlwriter.WriteElementString(name, value)
                    Next
                    xmlwriter.WriteEndElement()
                End If

                If nozzlecount <> 0 Then
                    xmlwriter.WriteStartElement(csnozzle)
                    For i = 0 To nozzlecount - 1
                        name = csnozzle & CStr(i)
                        value = Me.cbo_nozzletype.Items.Item(i)
                        If value <> "" Then xmlwriter.WriteElementString(name, value)
                    Next
                    xmlwriter.WriteEndElement()
                End If

                If abrcount <> 0 Then
                    xmlwriter.WriteStartElement(csabrasivetype)
                    For i = 0 To abrcount - 1
                        name = csabrasivetype & CStr(i)
                        value = Me.cbo_abrasivetype.Items.Item(i)
                        If value <> "" Then xmlwriter.WriteElementString(name, value)
                    Next
                    xmlwriter.WriteEndElement()
                End If
                If jewelcount <> 0 Then
                    xmlwriter.WriteStartElement(csjeweltype)
                    For i = 0 To jewelcount - 1
                        name = csjeweltype & CStr(i)
                        value = Me.cbo_jeweltype.Items.Item(i)
                        If value <> "" Then xmlwriter.WriteElementString(name, value)
                    Next
                    xmlwriter.WriteEndElement()
                End If
                If pumpcount <> 0 Then
                    xmlwriter.WriteStartElement(cspump)
                    For i = 0 To pumpcount - 1
                        name = cspump & CStr(i)
                        value = Me.cbo_pump.Items.Item(i)
                        If value <> "" Then xmlwriter.WriteElementString(name, value)
                    Next
                    xmlwriter.WriteEndElement()
                End If

                xmlwriter.WriteEndElement()
                xmlwriter.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & " sub:saveparminput")
            End Try
        End Sub 'saveparminput

        Private Sub checktextinput(ByRef var As String, ByVal value As String)
            If value = "" Then
                var = "unknown"
            Else
                var = value
            End If
        End Sub
        Private Sub cancel_load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel_load.Click
            Me.Close()

        End Sub

        Private Sub testdepth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles testdepth.TextChanged
            If IsNumeric(testdepth.Text) Then
                test_depth = CDbl(testdepth.Text)
                Me.calc_test_mrr(test_depth, test_speed, test_passes)
            End If

        End Sub

        Private Sub testspeed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles testspeed.TextChanged
            If IsNumeric(testspeed.Text) Then
                test_speed = CDbl(testspeed.Text)
                Me.calc_test_mrr(test_depth, test_speed, test_passes)
            End If

        End Sub

        Private Sub testpasses_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles testpasses.TextChanged
            If IsNumeric(testpasses.Text) Then
                test_passes = CInt(testpasses.Text)
                Me.calc_test_mrr(test_depth, test_speed, test_passes)
            End If

        End Sub
        Sub calc_test_mrr(ByVal td As Double, ByVal ts As Double, ByVal tp As Integer)
            Dim nomf As Double = CDbl(nomfeedrate.Text)
            If td <> 0 And ts <> 0 And tp <> 0 Then
                'Me.depthperrun.Font = System.Drawing.Font


                Me.depthperrun.Text = CStr(Math.Round((ts / nomf) * td / tp, 5))
            End If

        End Sub

        Private Sub lstbxoperation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbxoperation.SelectedIndexChanged
            Dim a As Integer = lstbxoperation.SelectedIndex()

            Select Case a
                Case 0 : mrr_type.Text = CStr(mrrtype_schannel) : thetacrit.Text = CStr(thetacrit_schannel) : mrr_type.ReadOnly = True : thetacrit.ReadOnly = True 'schannel
                Case 1 : mrr_type.Text = CStr(mrrtype_rchannel) : thetacrit.Text = CStr(thetacrit_rchannel) : mrr_type.ReadOnly = True : thetacrit.ReadOnly = True 'rchannel
                Case 2 : mrr_type.Text = CStr(mrrtype_mill) : thetacrit.Text = CStr(thetacrit_mill) : mrr_type.ReadOnly = True : thetacrit.ReadOnly = True 'milling
                Case 3 : mrr_type.ReadOnly = False : thetacrit.ReadOnly = False 'other
            End Select

        End Sub

        Private Sub parminput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strvalue As String


            If CDbl(mrr_type.Text) = mrrtype_schannel And CDbl(thetacrit.Text) = thetacrit_schannel Then 's-channel 
                mrr_type.ReadOnly = True
                thetacrit.ReadOnly = True
                lstbxoperation.SelectedIndex = 0
            ElseIf CDbl(mrr_type.Text) = mrrtype_rchannel And CDbl(thetacrit.Text) = thetacrit_rchannel Then 'r-channel 
                mrr_type.ReadOnly = True
                thetacrit.ReadOnly = True
                lstbxoperation.SelectedIndex = 1
            ElseIf CDbl(mrr_type.Text) = mrrtype_mill And CDbl(thetacrit.Text) = thetacrit_mill Then 'milling
                mrr_type.ReadOnly = True
                thetacrit.ReadOnly = True
                lstbxoperation.SelectedIndex = 2
            Else 'user defined 
                mrr_type.ReadOnly = False
                thetacrit.ReadOnly = False
                lstbxoperation.SelectedIndex = 3
            End If
            Try
                Dim xmlDoc As XmlDocument = New XmlDocument
                xmlDoc.Load(sparmxmlfilepath)
                Dim root As XmlNode = xmlDoc.FirstChild
                If root Is Nothing Then
                    Throw New Exception("Root node cannot be found in the XML file ")
                End If

                'Skip the XML document header.
                If root.Name = "xml" Then
                    'The root node should be next.
                    root = root.NextSibling
                End If

                If LCase(root.Name) = csparminput Then
                    Dim child As Xml.XmlNode
                    Dim node As Xml.XmlNode
                    For Each child In root.ChildNodes
                        'Build a version data structure from the  info contained within the XML file.
                        Select Case LCase(child.Name)
                            Case csmachine
                                For Each node In child.ChildNodes
                                    strvalue = node.InnerXml.Trim
                                    If Not (Me.cbo_machine.Items.Contains(strvalue)) Then
                                        Me.cbo_machine.Items.Add(strvalue)
                                    End If
                                Next
                            Case cspump
                                For Each node In child.ChildNodes
                                    strvalue = node.InnerXml.Trim
                                    If Not (Me.cbo_pump.Items.Contains(strvalue)) Then
                                        Me.cbo_pump.Items.Add(strvalue)
                                    End If
                                Next
                            Case csabrasivetype
                                For Each node In child.ChildNodes
                                    strvalue = node.InnerXml.Trim
                                    If Not (Me.cbo_abrasivetype.Items.Contains(strvalue)) Then
                                        Me.cbo_abrasivetype.Items.Add(strvalue)
                                    End If

                                Next
                            Case csjeweltype
                                For Each node In child.ChildNodes
                                    strvalue = node.InnerXml.Trim
                                    If Not (Me.cbo_jeweltype.Items.Contains(strvalue)) Then
                                        Me.cbo_jeweltype.Items.Add(strvalue)
                                    End If
                                Next
                            Case csnozzle
                                For Each node In child.ChildNodes
                                    strvalue = node.InnerXml.Trim
                                    If Not (Me.cbo_nozzletype.Items.Contains(strvalue)) Then
                                        Me.cbo_nozzletype.Items.Add(strvalue)
                                    End If
                                Next
                        End Select
                    Next
                End If

            Catch ex As Exception

            End Try

        End Sub 'parminput_Load

        Private Sub nomdepth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nomdepth.TextChanged
            targetSurfaceOK = False
        End Sub

        Private Sub defjetdiam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles defjetdiam.TextChanged
            targetSurfaceOK = False
        End Sub
        Private Sub cbo_nozzletype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_nozzletype.TextChanged
            newparameter = True
        End Sub

        Private Sub cbo_nozzletype_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_nozzletype.LostFocus, cbo_nozzletype.DisplayMemberChanged
            Dim strvalue = Me.cbo_nozzletype.Text
            If Not (Me.cbo_nozzletype.Items.Contains(strvalue)) Then
                newparameter = True
            End If
        End Sub
        Private Sub cbo_machine_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_machine.LostFocus, cbo_machine.DisplayMemberChanged
            Dim strvalue = Me.cbo_pump.Text
            If Not (Me.cbo_pump.Items.Contains(strvalue)) Then
                Me.cbo_pump.Items.Add(strvalue)
                newparameter = True
            End If
        End Sub
        Private Sub cbo_machine_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_machine.TextChanged
            newparameter = True
        End Sub
        Private Sub cbo_pump_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_pump.LostFocus, cbo_pump.DisplayMemberChanged
            Dim strvalue = Me.cbo_pump.Text
            If Not (Me.cbo_pump.Items.Contains(strvalue)) Then
                Me.cbo_pump.Items.Add(strvalue)
                newparameter = True
            End If
        End Sub

        Private Sub cbo_jeweltype_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_jeweltype.LostFocus, cbo_jeweltype.DisplayMemberChanged
            Dim strvalue = Me.cbo_jeweltype.Text
            If Not (Me.cbo_jeweltype.Items.Contains(strvalue)) Then
                Me.cbo_jeweltype.Items.Add(strvalue)
                newparameter = True
            End If
        End Sub
        Private Sub cbo_jeweltype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_jeweltype.TextChanged
            newparameter = True
        End Sub
        Private Sub cbo_abrasivetype_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_abrasivetype.LostFocus, cbo_abrasivetype.DisplayMemberChanged
            Dim strvalue = Me.cbo_abrasivetype.Text
            If Not (Me.cbo_abrasivetype.Items.Contains(strvalue)) Then
                Me.cbo_abrasivetype.Items.Add(strvalue)
                newparameter = True
            End If
        End Sub
        Private Sub cbo_abrasivetype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_abrasivetype.TextChanged
            newparameter = True
        End Sub

    End Class
End Namespace
