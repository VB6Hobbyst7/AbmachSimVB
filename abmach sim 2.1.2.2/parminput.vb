Imports System.Xml
Imports System.IO
Namespace abmach

    Public Class parminput

        Inherits System.Windows.Forms.Form

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(parminput))
            Me.nomdepth = New System.Windows.Forms.TextBox()
            Me.matthickness = New System.Windows.Forms.TextBox()
            Me.defjetdiam = New System.Windows.Forms.TextBox()
            Me.depthperrun = New System.Windows.Forms.TextBox()
            Me.nomfeedrate = New System.Windows.Forms.TextBox()
            Me.number_of_runs = New System.Windows.Forms.TextBox()
            Me.thetacrit = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.load_parms = New System.Windows.Forms.Button()
            Me.cancel_load = New System.Windows.Forms.Button()
            Me.depthtolerance = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Groovedir = New System.Windows.Forms.ListBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.testdepth = New System.Windows.Forms.TextBox()
            Me.testspeed = New System.Windows.Forms.TextBox()
            Me.testpasses = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.mrr_type = New System.Windows.Forms.TextBox()
            Me.armradius = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.lstbxoperation = New System.Windows.Forms.ListBox()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtmtlength = New System.Windows.Forms.TextBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.txtjeweldiameter = New System.Windows.Forms.TextBox()
            Me.txtabflow = New System.Windows.Forms.TextBox()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.txtmtdiameter = New System.Windows.Forms.TextBox()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.txtpressure = New System.Windows.Forms.TextBox()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.txtsod = New System.Windows.Forms.TextBox()
            Me.cbo_pump = New System.Windows.Forms.ComboBox()
            Me.cbo_abrasivetype = New System.Windows.Forms.ComboBox()
            Me.cbo_machine = New System.Windows.Forms.ComboBox()
            Me.cbo_nozzletype = New System.Windows.Forms.ComboBox()
            Me.cbo_jeweltype = New System.Windows.Forms.ComboBox()
            Me.SuspendLayout()
            '
            'nomdepth
            '
            resources.ApplyResources(Me.nomdepth, "nomdepth")
            Me.nomdepth.Name = "nomdepth"
            Me.ToolTip1.SetToolTip(Me.nomdepth, resources.GetString("nomdepth.ToolTip"))
            '
            'matthickness
            '
            resources.ApplyResources(Me.matthickness, "matthickness")
            Me.matthickness.Name = "matthickness"
            Me.ToolTip1.SetToolTip(Me.matthickness, resources.GetString("matthickness.ToolTip"))
            '
            'defjetdiam
            '
            resources.ApplyResources(Me.defjetdiam, "defjetdiam")
            Me.defjetdiam.Name = "defjetdiam"
            Me.ToolTip1.SetToolTip(Me.defjetdiam, resources.GetString("defjetdiam.ToolTip"))
            '
            'depthperrun
            '
            resources.ApplyResources(Me.depthperrun, "depthperrun")
            Me.depthperrun.Name = "depthperrun"
            Me.ToolTip1.SetToolTip(Me.depthperrun, resources.GetString("depthperrun.ToolTip"))
            '
            'nomfeedrate
            '
            resources.ApplyResources(Me.nomfeedrate, "nomfeedrate")
            Me.nomfeedrate.Name = "nomfeedrate"
            Me.ToolTip1.SetToolTip(Me.nomfeedrate, resources.GetString("nomfeedrate.ToolTip"))
            '
            'number_of_runs
            '
            resources.ApplyResources(Me.number_of_runs, "number_of_runs")
            Me.number_of_runs.Name = "number_of_runs"
            Me.ToolTip1.SetToolTip(Me.number_of_runs, resources.GetString("number_of_runs.ToolTip"))
            '
            'thetacrit
            '
            resources.ApplyResources(Me.thetacrit, "thetacrit")
            Me.thetacrit.Name = "thetacrit"
            Me.ToolTip1.SetToolTip(Me.thetacrit, resources.GetString("thetacrit.ToolTip"))
            '
            'Label1
            '
            resources.ApplyResources(Me.Label1, "Label1")
            Me.Label1.Name = "Label1"
            '
            'Label2
            '
            resources.ApplyResources(Me.Label2, "Label2")
            Me.Label2.Name = "Label2"
            '
            'Label3
            '
            resources.ApplyResources(Me.Label3, "Label3")
            Me.Label3.Name = "Label3"
            '
            'Label4
            '
            resources.ApplyResources(Me.Label4, "Label4")
            Me.Label4.Name = "Label4"
            '
            'Label5
            '
            resources.ApplyResources(Me.Label5, "Label5")
            Me.Label5.Name = "Label5"
            '
            'Label6
            '
            resources.ApplyResources(Me.Label6, "Label6")
            Me.Label6.Name = "Label6"
            '
            'Label7
            '
            resources.ApplyResources(Me.Label7, "Label7")
            Me.Label7.Name = "Label7"
            '
            'Label8
            '
            resources.ApplyResources(Me.Label8, "Label8")
            Me.Label8.Name = "Label8"
            '
            'load_parms
            '
            resources.ApplyResources(Me.load_parms, "load_parms")
            Me.load_parms.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.load_parms.Name = "load_parms"
            '
            'cancel_load
            '
            resources.ApplyResources(Me.cancel_load, "cancel_load")
            Me.cancel_load.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.cancel_load.Name = "cancel_load"
            '
            'depthtolerance
            '
            resources.ApplyResources(Me.depthtolerance, "depthtolerance")
            Me.depthtolerance.Name = "depthtolerance"
            '
            'Label9
            '
            resources.ApplyResources(Me.Label9, "Label9")
            Me.Label9.Name = "Label9"
            '
            'Groovedir
            '
            Me.Groovedir.Items.AddRange(New Object() {resources.GetString("Groovedir.Items"), resources.GetString("Groovedir.Items1"), resources.GetString("Groovedir.Items2")})
            resources.ApplyResources(Me.Groovedir, "Groovedir")
            Me.Groovedir.Name = "Groovedir"
            '
            'Label10
            '
            resources.ApplyResources(Me.Label10, "Label10")
            Me.Label10.Name = "Label10"
            '
            'testdepth
            '
            resources.ApplyResources(Me.testdepth, "testdepth")
            Me.testdepth.Name = "testdepth"
            '
            'testspeed
            '
            resources.ApplyResources(Me.testspeed, "testspeed")
            Me.testspeed.Name = "testspeed"
            '
            'testpasses
            '
            resources.ApplyResources(Me.testpasses, "testpasses")
            Me.testpasses.Name = "testpasses"
            Me.ToolTip1.SetToolTip(Me.testpasses, resources.GetString("testpasses.ToolTip"))
            '
            'Label11
            '
            resources.ApplyResources(Me.Label11, "Label11")
            Me.Label11.Name = "Label11"
            '
            'Label12
            '
            resources.ApplyResources(Me.Label12, "Label12")
            Me.Label12.Name = "Label12"
            '
            'Label13
            '
            resources.ApplyResources(Me.Label13, "Label13")
            Me.Label13.Name = "Label13"
            '
            'mrr_type
            '
            resources.ApplyResources(Me.mrr_type, "mrr_type")
            Me.mrr_type.Name = "mrr_type"
            Me.ToolTip1.SetToolTip(Me.mrr_type, resources.GetString("mrr_type.ToolTip"))
            '
            'armradius
            '
            resources.ApplyResources(Me.armradius, "armradius")
            Me.armradius.Name = "armradius"
            '
            'Label14
            '
            resources.ApplyResources(Me.Label14, "Label14")
            Me.Label14.Name = "Label14"
            '
            'lstbxoperation
            '
            Me.lstbxoperation.Items.AddRange(New Object() {resources.GetString("lstbxoperation.Items"), resources.GetString("lstbxoperation.Items1"), resources.GetString("lstbxoperation.Items2"), resources.GetString("lstbxoperation.Items3")})
            resources.ApplyResources(Me.lstbxoperation, "lstbxoperation")
            Me.lstbxoperation.Name = "lstbxoperation"
            '
            'Label15
            '
            resources.ApplyResources(Me.Label15, "Label15")
            Me.Label15.Name = "Label15"
            '
            'txtmtlength
            '
            resources.ApplyResources(Me.txtmtlength, "txtmtlength")
            Me.txtmtlength.Name = "txtmtlength"
            Me.ToolTip1.SetToolTip(Me.txtmtlength, resources.GetString("txtmtlength.ToolTip"))
            '
            'Label16
            '
            resources.ApplyResources(Me.Label16, "Label16")
            Me.Label16.Name = "Label16"
            '
            'txtjeweldiameter
            '
            resources.ApplyResources(Me.txtjeweldiameter, "txtjeweldiameter")
            Me.txtjeweldiameter.Name = "txtjeweldiameter"
            Me.ToolTip1.SetToolTip(Me.txtjeweldiameter, resources.GetString("txtjeweldiameter.ToolTip"))
            '
            'txtabflow
            '
            resources.ApplyResources(Me.txtabflow, "txtabflow")
            Me.txtabflow.Name = "txtabflow"
            Me.ToolTip1.SetToolTip(Me.txtabflow, resources.GetString("txtabflow.ToolTip"))
            '
            'Label17
            '
            resources.ApplyResources(Me.Label17, "Label17")
            Me.Label17.Name = "Label17"
            '
            'Label18
            '
            resources.ApplyResources(Me.Label18, "Label18")
            Me.Label18.Name = "Label18"
            '
            'txtmtdiameter
            '
            resources.ApplyResources(Me.txtmtdiameter, "txtmtdiameter")
            Me.txtmtdiameter.Name = "txtmtdiameter"
            Me.ToolTip1.SetToolTip(Me.txtmtdiameter, resources.GetString("txtmtdiameter.ToolTip"))
            '
            'Label19
            '
            resources.ApplyResources(Me.Label19, "Label19")
            Me.Label19.Name = "Label19"
            '
            'Label20
            '
            resources.ApplyResources(Me.Label20, "Label20")
            Me.Label20.Name = "Label20"
            '
            'Label21
            '
            resources.ApplyResources(Me.Label21, "Label21")
            Me.Label21.Name = "Label21"
            '
            'Label22
            '
            resources.ApplyResources(Me.Label22, "Label22")
            Me.Label22.Name = "Label22"
            '
            'txtpressure
            '
            resources.ApplyResources(Me.txtpressure, "txtpressure")
            Me.txtpressure.Name = "txtpressure"
            Me.ToolTip1.SetToolTip(Me.txtpressure, resources.GetString("txtpressure.ToolTip"))
            '
            'Label23
            '
            resources.ApplyResources(Me.Label23, "Label23")
            Me.Label23.Name = "Label23"
            '
            'Label24
            '
            resources.ApplyResources(Me.Label24, "Label24")
            Me.Label24.Name = "Label24"
            '
            'Label25
            '
            resources.ApplyResources(Me.Label25, "Label25")
            Me.Label25.Name = "Label25"
            '
            'Label26
            '
            resources.ApplyResources(Me.Label26, "Label26")
            Me.Label26.Name = "Label26"
            '
            'txtsod
            '
            resources.ApplyResources(Me.txtsod, "txtsod")
            Me.txtsod.Name = "txtsod"
            '
            'cbo_pump
            '
            resources.ApplyResources(Me.cbo_pump, "cbo_pump")
            Me.cbo_pump.Name = "cbo_pump"
            '
            'cbo_abrasivetype
            '
            resources.ApplyResources(Me.cbo_abrasivetype, "cbo_abrasivetype")
            Me.cbo_abrasivetype.Name = "cbo_abrasivetype"
            '
            'cbo_machine
            '
            resources.ApplyResources(Me.cbo_machine, "cbo_machine")
            Me.cbo_machine.Name = "cbo_machine"
            '
            'cbo_nozzletype
            '
            resources.ApplyResources(Me.cbo_nozzletype, "cbo_nozzletype")
            Me.cbo_nozzletype.Name = "cbo_nozzletype"
            '
            'cbo_jeweltype
            '
            resources.ApplyResources(Me.cbo_jeweltype, "cbo_jeweltype")
            Me.cbo_jeweltype.Name = "cbo_jeweltype"
            '
            'parminput
            '
            Me.AcceptButton = Me.load_parms
            resources.ApplyResources(Me, "$this")
            Me.CancelButton = Me.cancel_load
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
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "parminput"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private Sub load_parms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load_parms.Click

            Try
                Dim validentry As Boolean
                Dim validdata As Boolean = True

                checkdbl(matthickness.Text, material_thickness, validentry)
                validdata = validdata And validentry
                checkdbl(defjetdiam.Text, ccomp, validentry)
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
            Catch ex As Exception
                Throw

            End Try


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

            Dim name, value As String
            Dim machinecount As Integer = Me.cbo_machine.Items.Count
            Dim nozzlecount As Integer = Me.cbo_nozzletype.Items.Count
            Dim abrcount As Integer = Me.cbo_abrasivetype.Items.Count
            Dim jewelcount As Integer = Me.cbo_jeweltype.Items.Count
            Dim pumpcount As Integer = Me.cbo_pump.Items.Count
            Dim i As Integer
            'File.Copy(sparmxmlfilepath, oldparmxmlfilepath, True)
            Try
                Dim xmlwriter As New XmlTextWriter(parmInputXmlFile, Nothing)
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
                Throw
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
                xmlDoc.Load(parmInputXmlFile)
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
                Throw
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
            Dim strvalue As String = Me.cbo_nozzletype.Text
            If Not (Me.cbo_nozzletype.Items.Contains(strvalue)) Then
                newparameter = True
            End If
        End Sub
        Private Sub cbo_machine_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_machine.LostFocus, cbo_machine.DisplayMemberChanged
            Dim strvalue As String = Me.cbo_pump.Text
            If Not (Me.cbo_pump.Items.Contains(strvalue)) Then
                Me.cbo_pump.Items.Add(strvalue)
                newparameter = True
            End If
        End Sub
        Private Sub cbo_machine_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_machine.TextChanged
            newparameter = True
        End Sub
        Private Sub cbo_pump_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_pump.LostFocus, cbo_pump.DisplayMemberChanged
            Dim strvalue As String = Me.cbo_pump.Text
            If Not (Me.cbo_pump.Items.Contains(strvalue)) Then
                Me.cbo_pump.Items.Add(strvalue)
                newparameter = True
            End If
        End Sub

        Private Sub cbo_jeweltype_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_jeweltype.LostFocus, cbo_jeweltype.DisplayMemberChanged
            Dim strvalue As String = Me.cbo_jeweltype.Text
            If Not (Me.cbo_jeweltype.Items.Contains(strvalue)) Then
                Me.cbo_jeweltype.Items.Add(strvalue)
                newparameter = True
            End If
        End Sub
        Private Sub cbo_jeweltype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_jeweltype.TextChanged
            newparameter = True
        End Sub
        Private Sub cbo_abrasivetype_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_abrasivetype.LostFocus, cbo_abrasivetype.DisplayMemberChanged
            Dim strvalue As String = Me.cbo_abrasivetype.Text
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
