Imports System.Xml
Imports System.IO
Namespace abmach
    Public Class preferences

        Inherits System.Windows.Forms.Form



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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btn_OK As System.Windows.Forms.Button
        Friend WithEvents chk_dxfpref As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents chk_csvpref As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents chk_mipref As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents chk_strpref As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents chk_targpref As System.Windows.Forms.CheckBox
        Friend WithEvents trk_filesize As System.Windows.Forms.TrackBar
        Friend WithEvents txt_schannelmrr As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txt_rchannelmrr As System.Windows.Forms.TextBox
        Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
        Friend WithEvents txt_milltheta As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txt_rchanneltheta As System.Windows.Forms.TextBox
        Friend WithEvents txt_schanneltheta As System.Windows.Forms.TextBox
        Friend WithEvents txt_surfacemesh As System.Windows.Forms.TextBox
        Friend WithEvents txt_frfootprint As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txt_millmrr As System.Windows.Forms.TextBox
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents chk_clipfr As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
        Friend WithEvents pref_maxdepth As System.Windows.Forms.RadioButton
        Friend WithEvents pref_footprint As System.Windows.Forms.RadioButton
        Friend WithEvents modelSpeedTrackBar As System.Windows.Forms.TrackBar
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents txt_startingFeedRate As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.trk_filesize = New System.Windows.Forms.TrackBar
            Me.Label1 = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.btn_OK = New System.Windows.Forms.Button
            Me.chk_dxfpref = New System.Windows.Forms.CheckBox
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.chk_csvpref = New System.Windows.Forms.CheckBox
            Me.GroupBox2 = New System.Windows.Forms.GroupBox
            Me.chk_mipref = New System.Windows.Forms.CheckBox
            Me.GroupBox3 = New System.Windows.Forms.GroupBox
            Me.chk_strpref = New System.Windows.Forms.CheckBox
            Me.GroupBox4 = New System.Windows.Forms.GroupBox
            Me.chk_targpref = New System.Windows.Forms.CheckBox
            Me.txt_schannelmrr = New System.Windows.Forms.TextBox
            Me.Label4 = New System.Windows.Forms.Label
            Me.Label5 = New System.Windows.Forms.Label
            Me.Label6 = New System.Windows.Forms.Label
            Me.txt_millmrr = New System.Windows.Forms.TextBox
            Me.txt_rchannelmrr = New System.Windows.Forms.TextBox
            Me.GroupBox5 = New System.Windows.Forms.GroupBox
            Me.chk_clipfr = New System.Windows.Forms.CheckBox
            Me.txt_milltheta = New System.Windows.Forms.TextBox
            Me.Label7 = New System.Windows.Forms.Label
            Me.Label8 = New System.Windows.Forms.Label
            Me.Label9 = New System.Windows.Forms.Label
            Me.txt_rchanneltheta = New System.Windows.Forms.TextBox
            Me.txt_schanneltheta = New System.Windows.Forms.TextBox
            Me.txt_surfacemesh = New System.Windows.Forms.TextBox
            Me.txt_frfootprint = New System.Windows.Forms.TextBox
            Me.Label10 = New System.Windows.Forms.Label
            Me.Label11 = New System.Windows.Forms.Label
            Me.Label15 = New System.Windows.Forms.Label
            Me.txt_startingFeedRate = New System.Windows.Forms.TextBox
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.GroupBox6 = New System.Windows.Forms.GroupBox
            Me.pref_footprint = New System.Windows.Forms.RadioButton
            Me.pref_maxdepth = New System.Windows.Forms.RadioButton
            Me.modelSpeedTrackBar = New System.Windows.Forms.TrackBar
            Me.Label12 = New System.Windows.Forms.Label
            Me.Label13 = New System.Windows.Forms.Label
            Me.Label14 = New System.Windows.Forms.Label
            CType(Me.trk_filesize, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.GroupBox5.SuspendLayout()
            Me.GroupBox6.SuspendLayout()
            CType(Me.modelSpeedTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'trk_filesize
            '
            Me.trk_filesize.Location = New System.Drawing.Point(136, 8)
            Me.trk_filesize.Name = "trk_filesize"
            Me.trk_filesize.Size = New System.Drawing.Size(128, 50)
            Me.trk_filesize.TabIndex = 0
            Me.trk_filesize.Tag = "trk_filesize"
            Me.trk_filesize.Value = 7
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(56, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 23)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "DXF File Size"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(128, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(24, 23)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Min"
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(248, 48)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(32, 23)
            Me.Label3.TabIndex = 3
            Me.Label3.Text = "Max"
            '
            'btn_OK
            '
            Me.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btn_OK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn_OK.Location = New System.Drawing.Point(240, 368)
            Me.btn_OK.Name = "btn_OK"
            Me.btn_OK.Size = New System.Drawing.Size(64, 40)
            Me.btn_OK.TabIndex = 4
            Me.btn_OK.Text = "OK"
            '
            'chk_dxfpref
            '
            Me.chk_dxfpref.Location = New System.Drawing.Point(24, 16)
            Me.chk_dxfpref.Name = "chk_dxfpref"
            Me.chk_dxfpref.Size = New System.Drawing.Size(128, 32)
            Me.chk_dxfpref.TabIndex = 5
            Me.chk_dxfpref.Tag = "chk_dxfpref"
            Me.chk_dxfpref.Text = "Save surface as DXF after run"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.chk_dxfpref)
            Me.GroupBox1.Controls.Add(Me.chk_csvpref)
            Me.GroupBox1.Location = New System.Drawing.Point(40, 208)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(160, 88)
            Me.GroupBox1.TabIndex = 6
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Model Output"
            '
            'chk_csvpref
            '
            Me.chk_csvpref.Location = New System.Drawing.Point(24, 48)
            Me.chk_csvpref.Name = "chk_csvpref"
            Me.chk_csvpref.Size = New System.Drawing.Size(128, 32)
            Me.chk_csvpref.TabIndex = 5
            Me.chk_csvpref.Tag = "chk_csvpref"
            Me.chk_csvpref.Text = "Save surface as CSV file after run"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.chk_mipref)
            Me.GroupBox2.Location = New System.Drawing.Point(40, 304)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(160, 56)
            Me.GroupBox2.TabIndex = 6
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Machinability index"
            '
            'chk_mipref
            '
            Me.chk_mipref.Location = New System.Drawing.Point(24, 16)
            Me.chk_mipref.Name = "chk_mipref"
            Me.chk_mipref.Size = New System.Drawing.Size(128, 32)
            Me.chk_mipref.TabIndex = 5
            Me.chk_mipref.Tag = "chk_mipref"
            Me.chk_mipref.Text = "Save surface as DXF after run"
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.chk_strpref)
            Me.GroupBox3.Location = New System.Drawing.Point(208, 152)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(160, 56)
            Me.GroupBox3.TabIndex = 6
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Starting Surface"
            '
            'chk_strpref
            '
            Me.chk_strpref.Location = New System.Drawing.Point(16, 16)
            Me.chk_strpref.Name = "chk_strpref"
            Me.chk_strpref.Size = New System.Drawing.Size(128, 32)
            Me.chk_strpref.TabIndex = 5
            Me.chk_strpref.Tag = "chk_strpref"
            Me.chk_strpref.Text = "Save surface as DXF after run"
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.chk_targpref)
            Me.GroupBox4.Location = New System.Drawing.Point(208, 216)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(160, 56)
            Me.GroupBox4.TabIndex = 6
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Target Surface"
            '
            'chk_targpref
            '
            Me.chk_targpref.Location = New System.Drawing.Point(24, 16)
            Me.chk_targpref.Name = "chk_targpref"
            Me.chk_targpref.Size = New System.Drawing.Size(128, 32)
            Me.chk_targpref.TabIndex = 5
            Me.chk_targpref.Tag = "chk_targpref"
            Me.chk_targpref.Text = "Save surface as DXF after run"
            '
            'txt_schannelmrr
            '
            Me.txt_schannelmrr.Location = New System.Drawing.Point(128, 32)
            Me.txt_schannelmrr.Name = "txt_schannelmrr"
            Me.txt_schannelmrr.Size = New System.Drawing.Size(32, 20)
            Me.txt_schannelmrr.TabIndex = 7
            Me.txt_schannelmrr.Tag = "txt_schannelmrr"
            Me.txt_schannelmrr.Text = ""
            Me.ToolTip1.SetToolTip(Me.txt_schannelmrr, "mrr specified in mrrcoeffcientsl.xml")
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(16, 32)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 16)
            Me.Label4.TabIndex = 8
            Me.Label4.Text = "S-channel MRR type"
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(16, 56)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(112, 16)
            Me.Label5.TabIndex = 8
            Me.Label5.Text = "R-channel MRR type"
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(32, 80)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(96, 16)
            Me.Label6.TabIndex = 8
            Me.Label6.Text = "Milling MRR type"
            '
            'txt_millmrr
            '
            Me.txt_millmrr.Location = New System.Drawing.Point(128, 80)
            Me.txt_millmrr.Name = "txt_millmrr"
            Me.txt_millmrr.Size = New System.Drawing.Size(32, 20)
            Me.txt_millmrr.TabIndex = 9
            Me.txt_millmrr.Tag = "txt_millmrr"
            Me.txt_millmrr.Text = ""
            Me.ToolTip1.SetToolTip(Me.txt_millmrr, "mrr specified in mrrcoeffcientsl.xml")
            '
            'txt_rchannelmrr
            '
            Me.txt_rchannelmrr.Location = New System.Drawing.Point(128, 56)
            Me.txt_rchannelmrr.Name = "txt_rchannelmrr"
            Me.txt_rchannelmrr.Size = New System.Drawing.Size(32, 20)
            Me.txt_rchannelmrr.TabIndex = 8
            Me.txt_rchannelmrr.Tag = "txt_rchannelmrr"
            Me.txt_rchannelmrr.Text = ""
            Me.ToolTip1.SetToolTip(Me.txt_rchannelmrr, "mrr specified in mrrcoeffcientsl.xml")
            '
            'GroupBox5
            '
            Me.GroupBox5.Controls.Add(Me.chk_clipfr)
            Me.GroupBox5.Controls.Add(Me.txt_schannelmrr)
            Me.GroupBox5.Controls.Add(Me.txt_rchannelmrr)
            Me.GroupBox5.Controls.Add(Me.Label6)
            Me.GroupBox5.Controls.Add(Me.txt_millmrr)
            Me.GroupBox5.Controls.Add(Me.Label4)
            Me.GroupBox5.Controls.Add(Me.Label5)
            Me.GroupBox5.Controls.Add(Me.txt_milltheta)
            Me.GroupBox5.Controls.Add(Me.Label7)
            Me.GroupBox5.Controls.Add(Me.Label8)
            Me.GroupBox5.Controls.Add(Me.Label9)
            Me.GroupBox5.Controls.Add(Me.txt_rchanneltheta)
            Me.GroupBox5.Controls.Add(Me.txt_schanneltheta)
            Me.GroupBox5.Controls.Add(Me.txt_surfacemesh)
            Me.GroupBox5.Controls.Add(Me.txt_frfootprint)
            Me.GroupBox5.Controls.Add(Me.Label10)
            Me.GroupBox5.Controls.Add(Me.Label11)
            Me.GroupBox5.Controls.Add(Me.Label15)
            Me.GroupBox5.Controls.Add(Me.txt_startingFeedRate)
            Me.GroupBox5.Location = New System.Drawing.Point(392, 48)
            Me.GroupBox5.Name = "GroupBox5"
            Me.GroupBox5.Size = New System.Drawing.Size(184, 352)
            Me.GroupBox5.TabIndex = 9
            Me.GroupBox5.TabStop = False
            Me.GroupBox5.Text = "Model Preferences"
            '
            'chk_clipfr
            '
            Me.chk_clipfr.Location = New System.Drawing.Point(24, 304)
            Me.chk_clipfr.Name = "chk_clipfr"
            Me.chk_clipfr.Size = New System.Drawing.Size(144, 32)
            Me.chk_clipfr.TabIndex = 15
            Me.chk_clipfr.Tag = "chk_clipfr"
            Me.chk_clipfr.Text = "Clip Feed rates to maximum"
            '
            'txt_milltheta
            '
            Me.txt_milltheta.Location = New System.Drawing.Point(128, 168)
            Me.txt_milltheta.Name = "txt_milltheta"
            Me.txt_milltheta.Size = New System.Drawing.Size(32, 20)
            Me.txt_milltheta.TabIndex = 12
            Me.txt_milltheta.Tag = "txt_milltheta"
            Me.txt_milltheta.Text = ""
            Me.ToolTip1.SetToolTip(Me.txt_milltheta, "45<tc<85")
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(16, 120)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(112, 16)
            Me.Label7.TabIndex = 8
            Me.Label7.Text = "S-channel theta crit"
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(40, 208)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(80, 16)
            Me.Label8.TabIndex = 8
            Me.Label8.Text = "Surface mesh "
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(32, 168)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(96, 16)
            Me.Label9.TabIndex = 8
            Me.Label9.Text = "Milling theta crit"
            '
            'txt_rchanneltheta
            '
            Me.txt_rchanneltheta.Location = New System.Drawing.Point(128, 144)
            Me.txt_rchanneltheta.Name = "txt_rchanneltheta"
            Me.txt_rchanneltheta.Size = New System.Drawing.Size(32, 20)
            Me.txt_rchanneltheta.TabIndex = 11
            Me.txt_rchanneltheta.Tag = "txt_rchanneltheta"
            Me.txt_rchanneltheta.Text = ""
            Me.ToolTip1.SetToolTip(Me.txt_rchanneltheta, "45<tc<85")
            '
            'txt_schanneltheta
            '
            Me.txt_schanneltheta.Location = New System.Drawing.Point(128, 120)
            Me.txt_schanneltheta.Name = "txt_schanneltheta"
            Me.txt_schanneltheta.Size = New System.Drawing.Size(32, 20)
            Me.txt_schanneltheta.TabIndex = 10
            Me.txt_schanneltheta.Tag = "txt_schanneltheta"
            Me.txt_schanneltheta.Text = ""
            Me.ToolTip1.SetToolTip(Me.txt_schanneltheta, "45<tc<85")
            '
            'txt_surfacemesh
            '
            Me.txt_surfacemesh.Location = New System.Drawing.Point(128, 208)
            Me.txt_surfacemesh.Name = "txt_surfacemesh"
            Me.txt_surfacemesh.Size = New System.Drawing.Size(32, 20)
            Me.txt_surfacemesh.TabIndex = 13
            Me.txt_surfacemesh.Tag = "txt_surfacemesh"
            Me.txt_surfacemesh.Text = ""
            Me.ToolTip1.SetToolTip(Me.txt_surfacemesh, "10<sm<31")
            '
            'txt_frfootprint
            '
            Me.txt_frfootprint.Location = New System.Drawing.Point(128, 232)
            Me.txt_frfootprint.Name = "txt_frfootprint"
            Me.txt_frfootprint.Size = New System.Drawing.Size(32, 20)
            Me.txt_frfootprint.TabIndex = 14
            Me.txt_frfootprint.Tag = "txt_frfootprint"
            Me.txt_frfootprint.Text = ""
            Me.ToolTip1.SetToolTip(Me.txt_frfootprint, "<surfacemesh/2")
            '
            'Label10
            '
            Me.Label10.Location = New System.Drawing.Point(32, 232)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(96, 16)
            Me.Label10.TabIndex = 8
            Me.Label10.Text = "Feedrate footprint"
            '
            'Label11
            '
            Me.Label11.Location = New System.Drawing.Point(16, 144)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(112, 16)
            Me.Label11.TabIndex = 8
            Me.Label11.Text = "R-channel theta crit"
            '
            'Label15
            '
            Me.Label15.Location = New System.Drawing.Point(32, 256)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(96, 16)
            Me.Label15.TabIndex = 8
            Me.Label15.Text = "Default Feedrate"
            '
            'txt_startingFeedRate
            '
            Me.txt_startingFeedRate.Location = New System.Drawing.Point(128, 256)
            Me.txt_startingFeedRate.Name = "txt_startingFeedRate"
            Me.txt_startingFeedRate.Size = New System.Drawing.Size(32, 20)
            Me.txt_startingFeedRate.TabIndex = 14
            Me.txt_startingFeedRate.Tag = "txt_startingFeedRate"
            Me.txt_startingFeedRate.Text = ""
            Me.ToolTip1.SetToolTip(Me.txt_startingFeedRate, "<surfacemesh/2")
            '
            'GroupBox6
            '
            Me.GroupBox6.Controls.Add(Me.pref_footprint)
            Me.GroupBox6.Controls.Add(Me.pref_maxdepth)
            Me.GroupBox6.Location = New System.Drawing.Point(208, 280)
            Me.GroupBox6.Name = "GroupBox6"
            Me.GroupBox6.Size = New System.Drawing.Size(160, 80)
            Me.GroupBox6.TabIndex = 10
            Me.GroupBox6.TabStop = False
            Me.GroupBox6.Text = "Feedrate Calc"
            '
            'pref_footprint
            '
            Me.pref_footprint.Location = New System.Drawing.Point(16, 48)
            Me.pref_footprint.Name = "pref_footprint"
            Me.pref_footprint.Size = New System.Drawing.Size(128, 24)
            Me.pref_footprint.TabIndex = 1
            Me.pref_footprint.Tag = "pref_footprint"
            Me.pref_footprint.Text = "Use Footprint Calc"
            '
            'pref_maxdepth
            '
            Me.pref_maxdepth.Location = New System.Drawing.Point(16, 24)
            Me.pref_maxdepth.Name = "pref_maxdepth"
            Me.pref_maxdepth.Size = New System.Drawing.Size(136, 24)
            Me.pref_maxdepth.TabIndex = 0
            Me.pref_maxdepth.Tag = "pref_maxdepth"
            Me.pref_maxdepth.Text = "Use Max depth Calc"
            '
            'modelSpeedTrackBar
            '
            Me.modelSpeedTrackBar.LargeChange = 1
            Me.modelSpeedTrackBar.Location = New System.Drawing.Point(136, 72)
            Me.modelSpeedTrackBar.Maximum = 5
            Me.modelSpeedTrackBar.Minimum = 1
            Me.modelSpeedTrackBar.Name = "modelSpeedTrackBar"
            Me.modelSpeedTrackBar.Size = New System.Drawing.Size(128, 50)
            Me.modelSpeedTrackBar.TabIndex = 11
            Me.modelSpeedTrackBar.Tag = "modelSpeedTrackBar"
            Me.modelSpeedTrackBar.Value = 3
            '
            'Label12
            '
            Me.Label12.Location = New System.Drawing.Point(56, 80)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(80, 23)
            Me.Label12.TabIndex = 1
            Me.Label12.Text = "Model Speed"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label13
            '
            Me.Label13.Location = New System.Drawing.Point(248, 112)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(40, 16)
            Me.Label13.TabIndex = 3
            Me.Label13.Text = "Speed"
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(112, 112)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(56, 16)
            Me.Label14.TabIndex = 3
            Me.Label14.Text = "Accuracy"
            '
            'preferences
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(592, 420)
            Me.ControlBox = False
            Me.Controls.Add(Me.Label13)
            Me.Controls.Add(Me.Label14)
            Me.Controls.Add(Me.modelSpeedTrackBar)
            Me.Controls.Add(Me.GroupBox6)
            Me.Controls.Add(Me.GroupBox5)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.btn_OK)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.trk_filesize)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox3)
            Me.Controls.Add(Me.GroupBox4)
            Me.Controls.Add(Me.Label12)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "preferences"
            Me.Text = "Preferences"
            CType(Me.trk_filesize, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox4.ResumeLayout(False)
            Me.GroupBox5.ResumeLayout(False)
            Me.GroupBox6.ResumeLayout(False)
            CType(Me.modelSpeedTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub preferences_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            loadpreferences()
        End Sub 'preferences_Load
        Public Sub loadpreferences()
            Try
                If File.Exists(PrefXmlFile) Then
                    Dim xmlDoc As XmlDocument = New XmlDocument
                    xmlDoc.Load(PrefXmlFile)
                    Dim root As XmlNode = xmlDoc.FirstChild
                    If root Is Nothing Then
                        Throw New Exception("Root node cannot be found in the XML file ")
                    End If

                    'Skip the XML document header.
                    If root.Name = "xml" Then
                        'The root node should be next.
                        root = root.NextSibling
                    End If
                    If LCase(root.Name) = cspreferences Then
                        Dim child As Xml.XmlNode

                        For Each child In root.ChildNodes
                            'Build a version data structure from the  info contained within the XML file.
                            'Select Case LCase(child.Name)
                            Select Case child.Name
                                Case Me.trk_filesize.Name
                                    Me.trk_filesize.Value = child.InnerXml
                                Case Me.modelSpeedTrackBar.Name
                                    Me.modelSpeedTrackBar.Value = child.InnerXml
                                Case Me.chk_csvpref.Name
                                    Me.chk_csvpref.Checked = CBool(child.InnerXml)
                                Case Me.chk_dxfpref.Name
                                    Me.chk_dxfpref.Checked = CBool(child.InnerXml)
                                Case Me.chk_mipref.Name
                                    Me.chk_mipref.Checked = CBool(child.InnerXml)
                                Case Me.chk_strpref.Name
                                    Me.chk_strpref.Checked = CBool(child.InnerXml)
                                Case Me.chk_targpref.Name
                                    Me.chk_targpref.Checked = CBool(child.InnerXml)
                                Case Me.chk_clipfr.Name
                                    Me.chk_clipfr.Checked = CBool(child.InnerXml)

                                Case Me.pref_footprint.Name
                                    Me.pref_footprint.Checked = CBool(child.InnerXml)
                                Case Me.pref_maxdepth.Name
                                    Me.pref_maxdepth.Checked = CBool(child.InnerXml)

                                Case Me.txt_milltheta.Name
                                    Me.txt_milltheta.Text = CStr(child.InnerXml)
                                Case Me.txt_schanneltheta.Name
                                    Me.txt_schanneltheta.Text = CStr(child.InnerXml)
                                Case Me.txt_rchanneltheta.Name
                                    Me.txt_rchanneltheta.Text = CStr(child.InnerXml)
                                Case Me.txt_millmrr.Name
                                    Me.txt_millmrr.Text = CStr(child.InnerXml)
                                Case Me.txt_schannelmrr.Name
                                    Me.txt_schannelmrr.Text = CStr(child.InnerXml)
                                Case Me.txt_rchannelmrr.Name
                                    Me.txt_rchannelmrr.Text = CStr(child.InnerXml)
                                Case Me.txt_surfacemesh.Name
                                    Me.txt_surfacemesh.Text = CStr(child.InnerXml)
                                Case Me.txt_frfootprint.Name
                                    Me.txt_frfootprint.Text = CStr(child.InnerXml)
                                Case Me.txt_startingFeedRate.Name
                                    Me.txt_startingFeedRate.Text = CStr(child.InnerXml)

                            End Select
                        Next
                        modelspeed = Me.modelSpeedTrackBar.Value
                        outputmesh = 11 - CInt(Me.trk_filesize.Value)
                        csvpref = Me.chk_csvpref.Checked
                        dxfpref = Me.chk_dxfpref.Checked
                        mipref = Me.chk_mipref.Checked
                        strpref = Me.chk_strpref.Checked
                        targpref = Me.chk_targpref.Checked
                        clipfrpref = Me.chk_clipfr.Checked
                        footprintcalcpref = Me.pref_footprint.Checked
                        maxdepthcalcpref = Me.pref_maxdepth.Checked

                        If IsNumeric(Me.txt_schanneltheta.Text) Then
                            thetacrit_schannel = CInt(Me.txt_schanneltheta.Text)
                        Else
                            thetacrit_schannel = 70
                        End If

                        If IsNumeric(Me.txt_rchanneltheta.Text) Then
                            thetacrit_rchannel = CInt(Me.txt_rchanneltheta.Text)
                        Else
                            thetacrit_rchannel = 64

                        End If

                        If IsNumeric(Me.txt_milltheta.Text) Then
                            thetacrit_mill = CInt(Me.txt_milltheta.Text)
                        Else
                            thetacrit_mill = 70
                        End If
                        If IsNumeric(Me.txt_millmrr.Text) Then
                            mrrtype_mill = CInt(Me.txt_millmrr.Text)
                        Else
                            mrrtype_mill = 6
                        End If
                        If IsNumeric(Me.txt_rchannelmrr.Text) Then
                            mrrtype_rchannel = CInt(Me.txt_rchannelmrr.Text)
                        Else
                            mrrtype_rchannel = 3
                        End If
                        If IsNumeric(Me.txt_schannelmrr.Text) Then
                            mrrtype_schannel = CInt(Me.txt_schannelmrr.Text)
                        Else
                            mrrtype_schannel = 13
                        End If

                        If IsNumeric(Me.txt_surfacemesh.Text) Then
                            surfacemesh = CInt(Me.txt_surfacemesh.Text)
                            If surfacemesh < 10 Or surfacemesh > 50 Then
                                surfacemesh = 19
                            End If
                        Else
                            surfacemesh = 19
                        End If
                        If IsNumeric(Me.txt_startingFeedRate.Text) Then
                            startingFeedRate = CDbl(Me.txt_startingFeedRate.Text)
                        Else
                            startingFeedRate = 20
                        End If
                        frfootprint = 1
                        'If IsNumeric(Me.txt_frfootprint.Text) Then
                        '    frfootprint = CInt(Me.txt_frfootprint.Text)
                        '    If frfootprint < 1 Or frfootprint > surfacemesh / 2 Then
                        '        frfootprint = 2
                        '    End If
                        'Else
                        '    frfootprint = 2
                        'End If

                    End If
                Else

                    Me.trk_filesize.Value = 7
                    Me.modelSpeedTrackBar.Value = 3
                    Me.pref_footprint.Checked = True
                    Me.chk_csvpref.Checked = False
                    Me.chk_dxfpref.Checked = False
                    Me.chk_mipref.Checked = False
                    Me.chk_strpref.Checked = False
                    Me.chk_clipfr.Checked = True
                    Me.chk_targpref.Checked = False
                    Me.txt_schannelmrr.Text = 13
                    Me.txt_schanneltheta.Text = 70
                    Me.txt_rchannelmrr.Text = 3
                    Me.txt_rchanneltheta.Text = 64
                    Me.txt_millmrr.Text = 6
                    Me.txt_milltheta.Text = 70
                    Me.txt_surfacemesh.Text = 19
                    Me.txt_frfootprint.Text = 2
                    Me.txt_startingFeedRate.Text = 20

                End If
                startSurfaceOK = False
                targetSurfaceOK = False
                surfaceOK = False

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & " sub preferences:loadpreferences")
            End Try
        End Sub 'loadpreferences
        Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
            Try
                'load values into variables
                'model speed is toolsegment length multiplier
                modelspeed = Me.modelSpeedTrackBar.Value
                outputmesh = 11 - CInt(Me.trk_filesize.Value)
                surfacemesh = CInt(Me.txt_surfacemesh.Text)
                frfootprint = CInt(Me.txt_frfootprint.Text)
                startingFeedRate = CDbl(Me.txt_startingFeedRate.Text)
                csvpref = Me.chk_csvpref.Checked
                dxfpref = Me.chk_dxfpref.Checked
                mipref = Me.chk_mipref.Checked
                strpref = Me.chk_strpref.Checked
                targpref = Me.chk_targpref.Checked
                clipfrpref = Me.chk_clipfr.Checked
                footprintcalcpref = Me.pref_footprint.Checked
                maxdepthcalcpref = Me.pref_maxdepth.Checked

                startSurfaceOK = False
                targetSurfaceOK = False
                surfaceOK = False
                Dim xmlwriter As New XmlTextWriter(PrefXmlFile, Nothing)
                xmlwriter.Formatting = Formatting.Indented
                xmlwriter.WriteStartDocument()
                xmlwriter.WriteStartElement(cspreferences)
                xmlwriter.WriteElementString(CStr(Me.trk_filesize.Name), CStr(Me.trk_filesize.Value))
                xmlwriter.WriteElementString(CStr(Me.modelSpeedTrackBar.Name), CStr(Me.modelSpeedTrackBar.Value))
                xmlwriter.WriteElementString(CStr(Me.chk_csvpref.Name), CStr(Me.chk_csvpref.Checked))
                xmlwriter.WriteElementString(CStr(Me.chk_dxfpref.Name), CStr(Me.chk_dxfpref.Checked))
                xmlwriter.WriteElementString(CStr(Me.chk_mipref.Name), CStr(Me.chk_mipref.Checked))
                xmlwriter.WriteElementString(CStr(Me.chk_strpref.Name), CStr(Me.chk_strpref.Checked))
                xmlwriter.WriteElementString(CStr(Me.chk_targpref.Name), CStr(Me.chk_targpref.Checked))
                xmlwriter.WriteElementString(CStr(Me.chk_clipfr.Name), CStr(Me.chk_clipfr.Checked))
                xmlwriter.WriteElementString(CStr(Me.pref_footprint.Name), CStr(Me.pref_footprint.Checked))
                xmlwriter.WriteElementString(CStr(Me.pref_maxdepth.Name), CStr(Me.pref_maxdepth.Checked))

                xmlwriter.WriteElementString(CStr(Me.txt_frfootprint.Name), CStr(Me.txt_frfootprint.Text))
                xmlwriter.WriteElementString(CStr(Me.txt_milltheta.Name), CStr(Me.txt_milltheta.Text))
                xmlwriter.WriteElementString(CStr(Me.txt_millmrr.Name), CStr(Me.txt_millmrr.Text))
                xmlwriter.WriteElementString(CStr(Me.txt_rchannelmrr.Name), CStr(Me.txt_rchannelmrr.Text))
                xmlwriter.WriteElementString(CStr(Me.txt_rchanneltheta.Name), CStr(Me.txt_rchanneltheta.Text))
                xmlwriter.WriteElementString(CStr(Me.txt_schannelmrr.Name), CStr(Me.txt_schannelmrr.Text))
                xmlwriter.WriteElementString(CStr(Me.txt_schanneltheta.Name), CStr(Me.txt_schanneltheta.Text))
                xmlwriter.WriteElementString(CStr(Me.txt_surfacemesh.Name), CStr(Me.txt_surfacemesh.Text))
                xmlwriter.WriteElementString(CStr(Me.txt_startingFeedRate.Name), CStr(Me.txt_startingFeedRate.Text))
                xmlwriter.WriteEndElement()
                xmlwriter.Close()
                Me.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & " sub preferences:btn_OK_Click")
            End Try

        End Sub 'btn_OK_Click

    End Class
End Namespace