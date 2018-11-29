Imports System.IO
Namespace abmach
    Module constants
        Public appDir As String = Path.GetDirectoryName(Application.StartupPath)
        Public exeDir As String = Path.GetDirectoryName(Application.ExecutablePath)

        ' Public sheaderfile As String = "infofileheader.txt"
        Public ParmInputXmlFile As String = "parameterinputs.xml"
        Public MrrCoeffsXmlFile As String = "MRRcoefficients.xml"
        Public MachineTagsXmlFile As String = "machinetags.xml"
        Public PrefXmlFile As String = "preferences.xml"

        Public Const csheader As String = "header"
        Public Const csfilename As String = "info_filename"
        Public Const cscuttercomp As String = "cutter_comp"
        Public Const csnumber_of_runs As String = "number_of_runs"
        Public Const csnominaldepth As String = "nom_depth"
        Public Const csdepth_per_run As String = "depth_per_run"
        Public Const csdepth_tolerance As String = "depth_tolerance"
        Public Const csnom_feedrate As String = "nom_feedrate"
        Public Const csarmradius As String = "arm_radius"
        Public Const csmaterial_thickness As String = "material_thickness"
        Public Const csnom_depth As String = "nom_depth"
        Public Const csdepthy As String = "depth_y"
        Public Const csmrrtype As String = "mrr_type"
        Public Const cscrit_angle_1 As String = "crit_angle"
        Public Const csgroovedir As String = "groove_dir"
        Public Const csdepthx As String = "depth_x"
        Public Const cssod As String = "sod"
        Public Const csjeweldiameter As String = "jewel_diameter"
        Public Const csjeweltype As String = "jewel_type"
        Public Const csmixingtlength As String = "mixing_tube_length"
        Public Const csnozzle As String = "nozzle"
        Public Const cspressure As String = "pressure"
        Public Const cspump As String = "pump"
        Public Const csabrasiveflow As String = "abrasive_flow"
        Public Const csabrasivetype As String = "abrasive_type"
        Public Const csmixingtdiameter As String = "mixing_tube_diameter"
        Public Const csmachine As String = "machine"
        Public Const csparminput As String = "parameterinput"
        Public Const cspreferences As String = "preferences"

    End Module
End Namespace