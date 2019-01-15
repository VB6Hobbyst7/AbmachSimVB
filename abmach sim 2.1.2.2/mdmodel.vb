Imports System.Xml
Imports System.IO
Imports System.Collections.Generic

Namespace abmach
    Public Module mdmodel
        'start model declarations
        'dxf input points
        Public Structure ddepthpoint
            Dim x1 As Double
            Dim y1 As Double
            Dim z1 As Double
            Dim x2 As Double
            Dim y2 As Double
            Dim z2 As Double
        End Structure
        'surface input points
        Public Structure dsurfpoint
            Dim x As Double
            Dim y As Double
            Dim z As Double
            Dim depth As Double
            Dim mask As Integer
            Dim mi As Double
        End Structure
        'dxf regions from dxf input points
        Public Structure dregion
            Dim max_x As Double
            Dim max_y As Double
            Dim min_x As Double
            Dim min_y As Double
            Dim z As Double
        End Structure
        Public Structure dArrayExtents
            Dim max_x As Double
            Dim max_y As Double
            Dim min_x As Double
            Dim min_y As Double
            Dim max_z As Double
            Dim min_z As Double
            Dim xmeshsize As Double
            Dim ymeshsize As Double
            Dim rows As Integer
            Dim columns As Integer
            Dim size As Integer
        End Structure
        Public Structure dtoolpath
            Dim x As Double
            Dim y As Double
            Dim z As Double
            Dim c As Double
            Dim b As Double
            Dim f As Double
            Dim mf As Double
            Dim segmentdepth As Double
            Dim n As Integer
            Dim jeton As Boolean
            Dim abron As Boolean
            Dim mi As Double
        End Structure
        'all data related to nc lines of program
        Public Structure dnccodes
            Dim line As String
            Dim n As Integer
            Dim gcode As Integer
            Dim x As Double
            Dim y As Double
            Dim z As Double
            Dim bvalue As Double
            Dim cvalue As Double
            Dim ivalue As Double
            Dim jvalue As Double
            Dim xydist As Double
            Dim f As Double
            Dim npos, gpos, xpos, ypos, zpos, bpos, cpos, ipos, jpos, fpos As Integer
            Dim nlen, glen, xlen, ylen, zlen, blen, clen, ilen, jlen, flen As Integer
            Dim fline As Integer
            Dim newf As Double
            Dim modelf As Double
            Dim minsegmentdepth As Double
            Dim maxsegmentdepth As Double
            Dim nominalsurface As Double
            Dim mi As Double
            Dim mask As Integer
            Dim depth As Double
            Dim jeton As Boolean
            Dim abron As Boolean
            Dim isComment As Boolean
            Dim fScaled As Boolean
            Dim l As Integer
        End Structure
        Public Structure smachine
            Dim name As String
            Dim machinecomment As String
            Dim machinecommentend As String
            Dim maxacceln As Double
            Dim maxaccelt As Double
            Dim c0 As Double
            Dim b0 As Double
            Dim jetonstring As String
            Dim startstring As String
            Dim endstring As String
            Dim vscalingstring As String
            Dim firstrowoffset As Integer
            Dim maxspeed As Double
            Dim ccompstring As String
            Dim dynjeton As String
            Dim abrasiveOnMcode As String
            Dim jetOnMcode As String
            Dim abrasiveOffMcode As String
            Dim jetOffMcode As String
            Dim dynjetoff As String
            Dim repeatstart As String
            Dim repeatstop As String
            Dim dyntag As String
            Dim machinetag As String
            Dim arctype As Integer
            Dim toolstring As String
        End Structure
        Public Structure modelParms
            Dim runs As Integer
            Dim iterations As Integer
            Dim opt As modelOutputOptions
            Dim depthX As Double
            Dim depthY As Double
        End Structure
        Public Structure Curve
            Dim X As Double
            Dim Fx As Double
        End Structure
        Public Enum modelOutputOptions
            runAsIs
            newFeedrates
            adjustMRR
            stopAtNominalDepth
            newMISurface
        End Enum
        Public Enum surfacetype
            constant
            xprofile
            yprofile
            linear
            dxfregions
            dxfpoints
            csvpoints
            equation
        End Enum

        Public Enum groovedirection
            MULTI
            X
            Y
        End Enum

        Public debugdataList As Generic.List(Of String)
        Dim xlength, tdef, typdef(), td1() As Short
        Dim m1, yt, xt As Double
        Dim yd1(), xd1() As Double
        Public str_abrasiveflow, str_jeweldiameter, str_sod, str_mixingtlength, str_pressure, str_mixingtdiameter As String
        Public str_machinename, str_pumpname, str_nozzle, str_jeweltype, str_abrasivetype As String
        Public targpref, strpref, mipref, dxfpref, csvpref, clipfrpref, footprintcalcpref, maxdepthcalcpref As Boolean

        Dim defval As Double
        Dim input_min_y, input_max_y, input_max_x, input_min_x As Double
        Public crit_angle_1, ccomp, ccomp_old, defccomp, nom_feedrate, nom_depth, material_thickness, depth_tolerance As Double
        Public mrrvalue(,), depth_per_run As Double
        Public outputmesh, mrrtype, numberruns, depthcheckxindex, depthcheckyindex As Integer
        Public ncmachine, dxfmodelfilename, infomodelfilename As String
        Public grvedir As groovedirection
        Public strgroovedir As String
        Public parameters_loaded, surfaceOK, targetSurfaceOK, startSurfaceOK, miSurfaceOK, maskSurfaceOK, clipfrflag As Boolean
        Public rjet, vjetx, vjety, vjetz, crit_angle_1_rad, max_depth, min_depth As Double
        Public mesh_size, mesh_size2, meshsquared, toolsegmentl As Double
        Public armradius, maxaccelt, maxacceln As Double
        Public size_yarray, size_xarray, jetradius, tot_path_pts, total_segments, jetradius2 As Integer
        Public frfootprint, surfacemesh, modelspeed As Integer
        Public thetacrit_schannel, thetacrit_rchannel, thetacrit_mill, mrrtype_mill, mrrtype_rchannel, mrrtype_schannel As Integer
        Public startingFeedRate As Double

        Public mdepthx, mdepthy, depth_display() As Double
        Public pathmax_y, pathmin_y, pathmin_x, pathmax_x As Double
        Public maxsegmentdepthj, minsegmentdepthj As Double
        Public nc_line As Integer
        Public nc_code As String
        Dim depth_ok As Boolean

        Public Const pi As Double = Math.PI
        Public machine, machinedata(20) As smachine
        Public targetExtents, startExtents, miExtents, maskExtents As dArrayExtents
        Public regionpoint(), startregionpoint(), targetregionpoint() As ddepthpoint
        Public surfpoint() As dsurfpoint
        Public rectregion() As dregion
        Public nc() As dnccodes
        Public toolpath() As dtoolpath
        Public machinemax, machinenumber As Integer
        Public Const eps As Double = 0.002

        Public deltaxsrf() As Double
        Public deltaysrf() As Double
        Public pointcount, regioncount As Integer

        Dim min_y, max_z, max_x, max_y, min_x, min_z As Double
        Dim cdist, startx, starty, startz As Double
        Dim lastgoodx, lastgoody As Double
        Dim newxydist, tot_path_l As Double
        Dim flag() As Boolean

        Dim size_y, size_x As Double
        Dim s1z, s2z As Double
        Dim depth_scale_factor As Double
        'general counters
        Dim aa, ba, temp, b1, a1 As Long

        Dim c, a, j, i, k, b, d As Integer
        Dim lastrow, firstrow, startlocation As Integer
        Public lineNumberStart, lineNumberIncrement As Integer
        Dim deltac, deltax, deltay, deltaz, deltab As Double

        Dim num_seg, checklocation As Integer
        Dim feedratescale, seg_cur As Double
        Dim factor As Double
        Dim gaussWidth, cutoffAngle As Double
        Dim g1, gb As Double
        ' Public debugData() As String
        'surface definition variables
        'change the following 3 lines to single to make single precision version 9/10/2007
        'Public surface(,), mrr_coeff(8), integral_mrr1, tempsurface(,), segmentdepth() As Single
        ' Public target_surface(,), ttargetsurface(,), start_surface(,), mi_surface(,) As Single
        'Public tmisurface(,), tsurface(,), tstartsurface(,), targetmeshsize As Single
        Public surface(,), mrr_coeff(8), integral_mrr1, tempsurface(,), segmentdepth() As Double
        Public target_surface(,), ttargetsurface(,), start_surface(,), mi_surface(,) As Double
        Public tmisurface(,), tsurface(,), tstartsurface(,), targetmeshsize As Double
        Public targetCurve() As Curve
        Public tMaskSurface(,), maskSurface(,), row, column As Integer
        Dim vmagcp, cpvny, cpvnx, cpvnz, vdnmag As Double
        Public inputsurfacetype, targetsurfacetype, startsurfacetype, maskSurfaceType, miSurfaceType As surfacetype
        Public miMax As Double = 2
        Public miMin As Double = 0.2
        'acceldecel
        Dim accel As Double
        Dim deltaf As Double
        Dim fb, f0, f1, fb0 As Double

        Public Sub initialize(ByVal runs As Integer)
            Dim i, a, b As Integer
            Dim checklocation As Double
            ReDim depth_display(runs)
            'jet vector definition
            vjetx = 0
            vjety = 0
            vjetz = 1
            'surfacemesh =mesh count per cutter set at parameter load
            'outputmesh=dxf mesh count per surface mesh

            crit_angle_1_rad = crit_angle_1 * pi / 180
            max_depth = Math.Abs(nom_depth) + depth_tolerance
            min_depth = Math.Abs(nom_depth) - depth_tolerance
            total_segments = 0

            If material_thickness < Math.Abs(max_depth) Then material_thickness = System.Math.Abs(max_depth) * 2
            ' If ccomp = 0 Then ccomp = defccomp
            ccomp = defccomp

            'changed 11/24/14 
            mesh_size = ccomp / surfacemesh
            'mesh_size = 0.001 'ccomp / 30.0
            mesh_size2 = mesh_size * 2
            meshsquared = mesh_size2 * mesh_size2
            'toolsegmentl = mesh_size * 3
            'toolsegmentl = mesh_size * modelspeed
            'changed ll/24/14
            toolsegmentl = mesh_size * 3




            rjet = ccomp / 2
            If rjet >= mesh_size Then
                jetradius = CInt(rjet / mesh_size)
            Else
                jetradius = CInt(mesh_size)
            End If
            Dim jetradius2 As Integer = CInt(jetradius ^ 2)
            'integrate and normalize mrr
            integral_mrr1 = 0
            For i = 0 To depth_display.GetUpperBound(0)
                depth_display(i) = 0
            Next
            gb = mrr_coeff(0)
            If mrrtype = 6 Then
                For i = 1 To jetradius
                    integral_mrr1 = 0.25 * (gaussian(1, gb, i / jetradius) + gaussian(1, gb, (i - 1) / jetradius)) + integral_mrr1
                Next i
            Else
                For i = 1 To jetradius
                    integral_mrr1 = 0.5 * (mrr(i / jetradius) + mrr((i - 1) / jetradius)) + integral_mrr1
                Next i
                integral_mrr1 = mrr_coeff(7) * integral_mrr1
            End If

            factor = nom_feedrate / (integral_mrr1 * jetfactor(ccomp))
            ReDim mrrvalue(1 + jetradius * 2, 1 + jetradius * 2)
            For a = 0 To jetradius * 2
                For b = 0 To jetradius * 2
                    checklocation = Math.Sqrt((a - jetradius) ^ 2 + (b - jetradius) ^ 2) / jetradius

                    If mrrtype = 6 Then
                        If checklocation <= 1.0 Then
                            mrrvalue(a, b) = factor * gaussian(1, gb, checklocation)
                        Else
                            mrrvalue(a, b) = 0
                        End If
                    Else
                        If checklocation <= 1.0 Then
                            mrrvalue(a, b) = factor * mrr(checklocation)
                        Else
                            mrrvalue(a, b) = 0
                        End If
                    End If

                Next
            Next
        End Sub 'initialize
        Function jetfactor(ByVal c As Double) As Decimal 'corrects for change in mrr when ccomp is changed
            jetfactor = CDec(0.5896 * c ^ -0.23)
        End Function 'jetfactor
        Function gaussian(ByVal a As Double, ByVal b As Double, ByVal x As Double) As Decimal
            gaussian = CDec(a * Math.Exp(-1 * b * x * x))
        End Function
        Public Function calcpathl(ByVal length As Integer) As Double
            Dim i As Integer
            Dim tot_path_l As Double
            For i = 1 To length - 1
                tot_path_l = tot_path_l + System.Math.Sqrt((nc(i - 1).x - nc(i).x) ^ 2 + ((nc(i - 1).y - nc(i).y) ^ 2) + ((nc(i - 1).z - nc(i).z) ^ 2))
            Next i

            'calc size of toolpath array required

            Return tot_path_l

        End Function 'calcpathl
        Public Sub findArrayExtents(ByVal array() As mdmodel.dsurfpoint, ByRef extents As mdmodel.dArrayExtents)
            Dim a As Integer
            Dim mindeltax, mindeltay As Double
            extents.max_x = -9.99999999E+28
            extents.max_y = -9.99999999E+28
            extents.max_z = -9.99999999E+28

            extents.min_x = 9.99999999E+28
            extents.min_y = 9.99999999E+28
            extents.min_z = 9.99999999E+28

            mindeltax = 9.99999999E+28
            mindeltay = 9.99999999E+28

            'find array extents
            For a = 0 To extents.size - 1

                If array(a).x > extents.max_x Then extents.max_x = array(a).x
                If array(a).y > extents.max_y Then extents.max_y = array(a).y
                If array(a).z > extents.max_z Then extents.max_z = array(a).z

                If array(a).x < extents.min_x Then extents.min_x = array(a).x
                If array(a).y < extents.min_y Then extents.min_y = array(a).y
                If array(a).z < extents.min_z Then extents.min_z = array(a).z
            Next a
            deltax = Math.Abs(array(1).x - array(0).x)
            deltay = Math.Abs(array(1).y - array(0).y)

            'find number of rows and columns and mesh size
            extents.xmeshsize = Math.Max(deltax, deltay)
            extents.ymeshsize = extents.xmeshsize
            extents.rows = CInt(1 + ((extents.max_y - extents.min_y) / extents.ymeshsize))
            extents.columns = CInt(1 + ((extents.max_x - extents.min_x) / extents.xmeshsize))

        End Sub
        Public Sub calc_arrray_size()
            Dim i As Integer
            pathmax_x = -9.999999E+16
            pathmax_y = -9.999999E+16
            pathmin_x = 9.999999E+16
            pathmin_y = 9.999999E+16

            'find min and max x,y in toolpath
            For i = 0 To total_segments - 1
                If toolpath(i).x > pathmax_x Then pathmax_x = toolpath(i).x
                If toolpath(i).y > pathmax_y Then pathmax_y = toolpath(i).y
                If toolpath(i).x < pathmin_x Then pathmin_x = toolpath(i).x
                If toolpath(i).y < pathmin_y Then pathmin_y = toolpath(i).y
            Next i
            size_xarray = CInt(((pathmax_x - pathmin_x) + (3 * ccomp)) / mesh_size)
            size_yarray = CInt(((pathmax_y - pathmin_y) + (3 * ccomp)) / mesh_size)

        End Sub 'calc_arrray_size
        Sub fillarrays(ByVal length As Integer)

            'fill toolpath array with x,y and f,b,c,z
            Dim i, segment As Integer
            segment = 0
            For i = 1 To length

                If Not (nc(i).isComment) Then
                    If nc(i).gcode = 1 Then straight(i, segment)

                    If nc(i).gcode = 2 Or nc(i).gcode = 3 Then arc(i, segment)
                End If
            Next i
            total_segments = segment - 1
            ReDim Preserve toolpath(total_segments)
        End Sub 'fill arrays
        Public Sub straight(ByVal a As Integer, ByRef b As Integer)
            'straight lines in nc code
            Dim deltax, deltay, deltaz, dist As Double
            Dim num_seg, d As Integer
            deltay = nc(a).y - nc(a - 1).y
            deltax = nc(a).x - nc(a - 1).x
            deltaz = nc(a).z - nc(a - 1).z
            dist = Math.Sqrt(deltay ^ 2 + deltax ^ 2)
            num_seg = CInt(dist / toolsegmentl)
            If num_seg = 0 Then num_seg = 1
            d = 0
            If num_seg > 1 Then
                Do While d < num_seg
                    toolpath(b).x = (d * (deltax / num_seg)) + nc(a - 1).x
                    toolpath(b).y = (d * (deltay / num_seg)) + nc(a - 1).y
                    toolpath(b).f = nc(a).f
                    toolpath(b).mf = nc(a).f
                    toolpath(b).z = (d * (deltaz / num_seg)) + nc(a - 1).z
                    toolpath(b).c = (d * (deltac / num_seg)) + nc(a - 1).cvalue
                    toolpath(b).b = (d * (deltab / num_seg)) + nc(a - 1).bvalue
                    toolpath(b).n = nc(a).n
                    b = b + 1
                    d = d + 1
                Loop
            Else
                toolpath(b).x = nc(a).x
                toolpath(b).y = nc(a).y
                toolpath(b).f = nc(a).f
                toolpath(b).mf = nc(a).f
                toolpath(b).z = nc(a).z
                toolpath(b).c = nc(a).cvalue
                toolpath(b).b = nc(a).bvalue
                toolpath(b).n = nc(a).n
                b = b + 1
                d = d + 1
            End If
        End Sub 'straight
        Public Sub arc(ByVal a As Integer, ByRef b As Integer)
            'arcs in nc code
            Dim rad, cdist, theta1, xtemp, theta_t, arc_l As Double
            Dim deltatheta, theta_cur As Double
            Dim num_seg, d As Integer

            'calc radius, chord length,starting angle
            rad = Math.Sqrt((nc(a).ivalue - nc(a).x) ^ 2 + (nc(a).jvalue - nc(a).y) ^ 2)
            cdist = Math.Sqrt((nc(a).x - nc(a - 1).x) ^ 2 + (nc(a).y - nc(a - 1).y) ^ 2)
            theta1 = Math.Atan2(nc(a - 1).y - nc(a).jvalue, nc(a - 1).x - nc(a).ivalue)

            'calc total arc sweep,arc length, number of segments to generate
            xtemp = (1 - ((cdist ^ 2) / (2 * (rad ^ 2))))
            If xtemp < -1 Then xtemp = -1
            If xtemp > 1 Then xtemp = 1
            theta_t = Math.Acos(xtemp)
            arc_l = rad * Math.Abs(theta_t)
            num_seg = CInt(arc_l / toolsegmentl)
            If num_seg <= 0 Then num_seg = 1
            deltatheta = Math.Abs(theta_t / num_seg)
            d = 0
            If num_seg > 1 Then
                'arc broken into multiple segments
                Do While d < num_seg
                    'check for ccw or cw arc
                    If nc(a).gcode = 2 Then theta_cur = theta1 - (deltatheta * d)
                    If nc(a).gcode = 3 Then theta_cur = theta1 + (deltatheta * d)
                    toolpath(b).x = (rad * Math.Cos(theta_cur)) + nc(a).ivalue
                    toolpath(b).y = (rad * Math.Sin(theta_cur)) + nc(a).jvalue
                    toolpath(b).f = nc(a).f
                    toolpath(b).mf = nc(a).f
                    toolpath(b).z = nc(a).z
                    toolpath(b).c = nc(a).cvalue
                    toolpath(b).b = nc(a).bvalue
                    toolpath(b).n = nc(a).n
                    b = b + 1
                    d = d + 1
                Loop
            Else
                'only one segment
                toolpath(b).x = nc(a).x
                toolpath(b).y = nc(a).y
                toolpath(b).f = nc(a).f
                toolpath(b).mf = nc(a).f
                toolpath(b).z = nc(a).z
                toolpath(b).c = nc(a).cvalue
                toolpath(b).b = nc(a).bvalue
                toolpath(b).n = nc(a).n
                b = b + 1
                d = d + 1
            End If
        End Sub 'arc
        Public Sub axis5nc(ByVal a As Integer, ByRef b As Integer)
            'straight lines in nc code
            Dim deltax, deltay, deltaz, deltac, deltab, dist As Double
            Dim num_seg, d As Integer
            deltax = nc(a).x - nc(a - 1).x
            deltay = nc(a).y - nc(a - 1).y
            deltac = nc(a).cvalue - nc(a - 1).cvalue
            deltab = nc(a).bvalue - nc(a - 1).bvalue
            deltaz = nc(a).z - nc(a - 1).z
            dist = Math.Sqrt(deltay ^ 2 + deltax ^ 2)
            num_seg = CInt(dist / toolsegmentl)
            If num_seg = 0 Then num_seg = 1
            d = 0
            If num_seg > 1 Then
                Do While d < num_seg
                    toolpath(b).x = (d * (deltax / num_seg)) + nc(a - 1).x
                    toolpath(b).y = (d * (deltay / num_seg)) + nc(a - 1).y
                    toolpath(b).f = nc(a).f
                    toolpath(b).mf = nc(a).f
                    toolpath(b).z = (d * (deltaz / num_seg)) + nc(a - 1).z
                    toolpath(b).c = (d * (deltac / num_seg)) + nc(a - 1).cvalue
                    toolpath(b).b = (d * (deltab / num_seg)) + nc(a - 1).bvalue
                    toolpath(b).n = nc(a).n
                    b = b + 1
                    d = d + 1
                Loop
            Else
                toolpath(b).x = nc(a).x
                toolpath(b).y = nc(a).y
                toolpath(b).f = nc(a).f
                toolpath(b).mf = nc(a).f
                toolpath(b).z = nc(a).z
                toolpath(b).c = nc(a).cvalue
                toolpath(b).b = nc(a).bvalue
                toolpath(b).n = nc(a).n
                b = b + 1
                d = d + 1
            End If
        End Sub 'axis5nc
        Function direction(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double,
                            ByVal y2 As Double) As Double
            If x2 - x1 = 0 And y2 - y1 = 0 Then
                direction = 0
            Else
                direction = Math.Atan2(y2 - y1, x2 - x1)
            End If

        End Function 'direction

        Function deltabfactor(ByVal depth As Double, ByVal deltab As Double, ByVal deltal As Double, ByVal deltal3d As Double) As Double
            Dim deltalprime As Double
            'calculate change in feed rate due to b axis change and depth

            'calc y prime
            If Math.Sign(deltab) = Math.Sign(deltal) Then
                deltalprime = deltal3d - Math.Abs(depth * deltab * pi / 180)
            Else
                deltalprime = deltal3d + Math.Abs(depth * deltab * pi / 180)
            End If

            'calc deltabfactor as ratio of y and y prime
            deltabfactor = Math.Abs(deltalprime / deltal3d)
            'If IsNumeric(deltabfactor) Then
            'Debug.WriteLine(deltab & "|" & deltal & "|" & deltabfactor)
            'End If
        End Function 'deltabfactor
        Function timetomachine() As Double
            Dim i As Integer
            Dim time As Double
            time = 0

            For i = 1 To toolpath.GetUpperBound(0)
                If toolpath(i).f <> 0 Then
                    time = time + (Math.Sqrt((toolpath(i).x - toolpath(i - 1).x) ^ 2 + (toolpath(i).y - toolpath(i - 1).y) ^ 2 + (toolpath(i).z - toolpath(i - 1).z) ^ 2) / toolpath(i).f)
                End If
            Next
            Return time
        End Function

        Public Sub depthxylocation(ByVal arrayxsize As Integer, ByVal arrayysize As Integer, ByRef xl As Double, ByRef yl As Double, ByVal length As Integer)

            Dim i As Integer
            Dim goodxylocation As Boolean = True
            i = 1
            If Not (xl >= pathmin_x - (ccomp / 2) And xl <= pathmax_x + (ccomp / 2) And yl >= pathmin_y - (ccomp / 2) And yl <= pathmax_y + (ccomp / 2)) Then
                Do
                    xl = (nc(i).x + nc(i - 1).x) / 2
                    yl = (nc(i).y + nc(i - 1).y) / 2
                    i += 1
                Loop Until (i = length Or nc(i - 1).gcode = 1)

            End If

            mdepthx = xl
            mdepthy = yl
        End Sub 'depthlocation
        Public Sub depthnlocation(ByVal nline As Integer, ByRef xl As Double, ByRef yl As Double, ByVal length As Integer)
            Dim i As Integer
            Dim nlinefound As Boolean = False
            i = 1
            Do Until i = length
                If nc(i).n = nline Then
                    xl = (nc(i).x + nc(i - 1).x) / 2
                    yl = (nc(i).y + nc(i - 1).y) / 2
                    nlinefound = True
                End If
                i += 1
            Loop
            If Not (nlinefound) Then
                i = 1
                Do
                    xl = (nc(i).x + nc(i - 1).x) / 2
                    yl = (nc(i).y + nc(i - 1).y) / 2
                    i += 1
                Loop Until (i = length Or nc(i - 1).gcode = 1)

            End If
        End Sub

        Function depthmonitor(ByVal depth As Double) As Boolean

            'outputs depth at depth check location for each run while the program is running

            If Math.Abs(depth) > Math.Abs(nom_depth) Then '7/10
                depthmonitor = False
            Else
                depthmonitor = True
            End If

        End Function 'depthmonitor
        Sub adjustMiArray()
            Dim i, j As Integer
            Dim miTemp, modelDeltaDepth, actualDeltaDepth As Double

            Dim iMax As Integer = surface.GetUpperBound(0)
            Dim jMax As Integer = surface.GetUpperBound(1)

            For i = 0 To iMax
                For j = 0 To jMax
                    If maskSurface(i, j) <> 0 Then
                        modelDeltaDepth = start_surface(i, j) - surface(i, j)
                        actualDeltaDepth = start_surface(i, j) - target_surface(i, j)
                        If modelDeltaDepth <> 0 And actualDeltaDepth <> 0 Then
                            miTemp = mi_surface(i, j) * Math.Abs(actualDeltaDepth / modelDeltaDepth)
                            If miTemp > miMax Then
                                mi_surface(i, j) = miMax
                            ElseIf miTemp < miMin Then
                                mi_surface(i, j) = miMin
                            Else
                                mi_surface(i, j) = miTemp
                            End If

                        End If
                    Else
                        mi_surface(i, j) = 1
                    End If



                Next
            Next

        End Sub
        Sub depthadjust(ByVal c As Integer, ByVal currentmrr As Decimal, ByRef newmrr As Decimal)
            Dim mrr_nom As Decimal
            'outputs depth at depth check location for each run while the program is running
            depth_display(c) = avedepth(mdepthx, mdepthy, 2)
            mrr_nom = CDec(Math.Abs(nom_depth) / numberruns)
            If c <> 0 And Math.Abs(depth_display(c)) < Math.Abs(nom_depth) Then '7/10
                If depth_display(c) - depth_display(c - 1) <> 0 Then
                    newmrr = CDec(Math.Abs(currentmrr * mrr_nom / (depth_display(c) - depth_display(c - 1))))
                End If
            End If

            If newmrr <> 0 Then depth_per_run = newmrr
        End Sub 'depthadjust
        Function mrr(ByVal dxr As Double) As Double
            'material removal rate polynomial evaluatio
            Dim c As Integer
            mrr = mrr_coeff(6)
            For c = 5 To 0 Step -1
                mrr = mrr * dxr + mrr_coeff(c)

            Next c
            'Return mrr
        End Function 'mrr
        Public Sub mrrxmlselect(ByVal type As Integer)

            Dim testarray(8) As Double

            Try
                Dim xmlreader As New XmlTextReader(MrrCoeffsXmlFile)
                xmlreader.WhitespaceHandling = WhitespaceHandling.None
                Do Until type = xmlreader.Item("type") Or xmlreader.EOF
                    xmlreader.Read()
                Loop
                If Not xmlreader.EOF Then
                    xmlreader.ReadStartElement("coeffs")
                    For i = 0 To 7
                        mrr_coeff(i) = xmlreader.ReadElementString("value" & i)
                    Next
                    xmlreader.ReadEndElement()
                Else
                    MessageBox.Show("MRR coefficient set " & type & " not found")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "mdmodel:mrrxmlselect")

            End Try
        End Sub 'mrrxmlselect
        Sub arrayStats(ByVal arr(,) As Double, ByRef localAve As Double, ByRef localStdDev As Double,
                       ByRef min As Double, ByRef max As Double)

            Dim iMax As Integer = surface.GetUpperBound(0)
            Dim jMax As Integer = surface.GetUpperBound(1)
            Dim minTemp As Double = 9.0E+30
            Dim maxTemp As Double = -9.0E+30
            localStdDev = 0
            localAve = 0
            For i = 0 To iMax
                For j = 0 To jMax
                    localAve = arr(i, j) + localAve
                    If arr(i, j) < minTemp Then minTemp = arr(i, j)
                    If arr(i, j) > maxTemp Then maxTemp = arr(i, j)
                Next
            Next
            localAve = localAve / ((iMax + 1) * (1 + jMax))
            min = minTemp
            max = maxTemp

            For i = 0 To iMax
                For j = 0 To jMax
                    localStdDev = localStdDev + (arr(i, j) - localAve) ^ 2
                Next
            Next
            localStdDev = Math.Sqrt(localStdDev / ((iMax + 1) * (1 + jMax)))
        End Sub ' arrayStats Double version
        Sub arrayStats(ByVal arr(,) As Single, ByRef localAve As Double, ByRef localStdDev As Double,
                       ByRef min As Double, ByRef max As Double)

            Dim iMax As Integer = surface.GetUpperBound(0)
            Dim jMax As Integer = surface.GetUpperBound(1)
            Dim minTemp As Double = 9.0E+30
            Dim maxTemp As Double = -9.0E+30
            localStdDev = 0
            localAve = 0
            For i = 0 To iMax
                For j = 0 To jMax
                    localAve = arr(i, j) + localAve
                    If arr(i, j) < minTemp Then minTemp = arr(i, j)
                    If arr(i, j) > maxTemp Then maxTemp = arr(i, j)
                Next
            Next
            localAve = localAve / ((iMax + 1) * (1 + jMax))
            min = minTemp
            max = maxTemp

            For i = 0 To iMax
                For j = 0 To jMax
                    localStdDev = localStdDev + (arr(i, j) - localAve) ^ 2
                Next
            Next
            localStdDev = Math.Sqrt(localStdDev / ((iMax + 1) * (1 + jMax)))
        End Sub 'arrayStats Single version
        Function maxFootprintDepth(ByVal x As Double, ByVal y As Double, ByVal halfWidth As Integer) As Double
            Dim ya, xIndex, xa, yIndex As Integer
            Dim pointcount As Integer = 0
            Dim temp As Double = 0

            xIndex = getxindex(x, mesh_size, ccomp, pathmin_x)
            yIndex = getyindex(y, mesh_size, ccomp, pathmin_y)
            For ya = yIndex - halfWidth To yIndex + halfWidth
                For xa = xIndex - halfWidth To xIndex + halfWidth
                    If xa >= 0 And xa <= surface.GetUpperBound(0) And ya >= 0 And ya <= surface.GetUpperBound(1) Then
                        If (Math.Abs(surface(xa, ya)) > Math.Abs(temp)) Then
                            temp = surface(xa, ya)
                            pointcount = pointcount + 1
                        End If
                    End If

                Next xa
            Next ya
            maxFootprintDepth = temp

        End Function
        Function maxFootprintDepth2(ByVal x As Double, ByVal y As Double, ByVal halfWidth As Integer) As Double
            Dim ya, xIndex, xa, yIndex As Integer
            Dim pointcount As Integer = 0
            Dim temp As Double = 0
            Dim pointList As New List(Of Double)

            xIndex = getxindex(x, mesh_size, ccomp, pathmin_x)
            yIndex = getyindex(y, mesh_size, ccomp, pathmin_y)
            For ya = yIndex - halfWidth To yIndex + halfWidth
                For xa = xIndex - halfWidth To xIndex + halfWidth
                    If xa >= 0 And xa <= surface.GetUpperBound(0) And ya >= 0 And ya <= surface.GetUpperBound(1) Then

                        If (Math.Abs(surface(xa, ya)) > 0) Then
                            pointList.Add(surface(xa, ya))
                        End If
                    End If

                Next xa
            Next ya
            pointList.Sort()
            pointcount = pointList.Count
            Dim aveCount As Integer = 0
            Dim upperAve As Double = 0
            Dim upperQuart As Integer = pointcount * 0.75
            For i As Integer = upperQuart To pointcount - 1
                upperAve += pointList(i)
                aveCount += 1
            Next

            maxFootprintDepth2 = upperAve / aveCount

        End Function
        Function maxFootprintDepth3(ByVal x As Double, ByVal y As Double, ByVal halfWidth As Integer) As Double
            Dim ya, xIndex, xa, yIndex As Integer
            Dim pointcount As Integer = 0
            Dim temp As Double = 0
            Dim pointList As New List(Of Double)
            Dim maxAngle As Double = Math.PI / 8.0
            xIndex = getxindex(x, mesh_size, ccomp, pathmin_x)
            yIndex = getyindex(y, mesh_size, ccomp, pathmin_y)
            For ya = yIndex - halfWidth To yIndex + halfWidth
                For xa = xIndex - halfWidth To xIndex + halfWidth
                    If xa >= 0 And xa <= surface.GetUpperBound(0) And ya >= 0 And ya <= surface.GetUpperBound(1) Then
                        Dim angle As Double = incidentAngle(xa, ya)
                        If Math.Abs(surface(xa, ya)) > 0 And angle < maxAngle Then
                            pointList.Add(surface(xa, ya))
                        End If
                    End If

                Next xa
            Next ya
            pointList.Sort()
            pointcount = pointList.Count
            Dim aveCount As Integer = 0
            Dim upperAve As Double = 0
            Dim upperQuart As Integer = pointcount * 0.95
            For i As Integer = upperQuart To pointcount - 1
                upperAve += pointList(i)
                aveCount += 1
            Next

            maxFootprintDepth3 = upperAve / aveCount

        End Function
        Function avedepth(ByVal x As Double, ByVal y As Double, ByVal halfWidth As Integer) As Double

            'calc average depth across a square region 2*halfWidth in width centered at x,y

            Dim ya, xIndex, xa, yIndex As Integer
            Dim pointcount As Integer = 0
            Dim temp As Double = 0

            xIndex = getxindex(x, mesh_size, ccomp, pathmin_x)
            yIndex = getyindex(y, mesh_size, ccomp, pathmin_y)

            For ya = yIndex - halfWidth To yIndex + halfWidth
                For xa = xIndex - halfWidth To xIndex + halfWidth
                    If xa >= 0 And xa <= surface.GetUpperBound(0) And ya >= 0 And ya <= surface.GetUpperBound(1) Then
                        temp = surface(xa, ya) + temp
                        pointcount = pointcount + 1
                    End If
                Next xa
            Next ya
            avedepth = temp / pointcount
        End Function 'avedepth
        Function maxdepth(ByVal x As Double, ByVal y As Double, ByVal direction As groovedirection) As Double
            Dim wflag As Boolean
            Dim wi, wy1, wy2, wy3, wx1, wx2, wx3 As Integer ' find maximum depth in a band
            Dim aa, xIndex, yIndex, ba As Integer
            Dim temp As Double
            'x: x location to start search
            'y: y location to start search

            'dir: direction of groove
            ' search is at right angle to direction of groove from min to max of array
            Try
                'xIndex: x index on surface
                'yIndex: y index on surface
                xIndex = getxindex(x, mesh_size, ccomp, pathmin_x)
                yIndex = getyindex(y, mesh_size, ccomp, pathmin_y)
                If direction = groovedirection.X Then
                    wflag = True
                    wi = yIndex
                    wy1 = 0
                    'start at toolpath y index and move across surface in -Y direction 
                    'find where surface=0
                    'store location of channel edge at wy1
                    Do While wflag And wi > 0
                        If surface(xIndex, wi) = start_surface(xIndex, wi) Then '7/10
                            wy1 = wi
                            wflag = False
                        End If
                        wi = wi - 1
                    Loop
                    'start at toolpath y index and move across surface in +Y direction 
                    'find where surface=0
                    'store location of channel edge at wy2
                    wflag = True
                    wi = yIndex
                    wy2 = getyindex(pathmax_y, mesh_size, ccomp, pathmin_y)
                    wy3 = wy2
                    Do While wflag And wi < wy3
                        If surface(xIndex, wi) = start_surface(xIndex, wi) Then '7/10
                            wy2 = wi
                            wflag = False
                        End If
                        wi = wi + 1
                    Loop
                    'find max depth between wy1 and wy2 at xIndex

                    temp = 0
                    For ba = wy1 To wy2

                        If surface(xIndex, ba) < temp Then temp = surface(xIndex, ba) '7/10
                    Next ba
                    maxdepth = temp
                End If

                If direction = groovedirection.Y Then

                    wflag = True
                    wi = xIndex
                    wx1 = 0
                    Do While wflag And wi > 0
                        If surface(wi, yIndex) = 0 Then
                            wx1 = wi
                            wflag = False
                        End If
                        wi = wi - 1
                    Loop

                    wflag = True
                    wi = xIndex
                    wx2 = getxindex(pathmax_x, mesh_size, ccomp, pathmin_x)
                    wx3 = wx2
                    'Do While wflag And wi < getxindex(pathmax_x, mesh_size, ccomp, pathmin_x)
                    Do While wflag And wi < wx3
                        If surface(wi, yIndex) = 0 Then
                            wx2 = wi
                            wflag = False
                        End If
                        wi = wi + 1
                    Loop
                    temp = 0
                    For aa = wx1 To wx2

                        If surface(aa, yIndex) < temp Then temp = surface(aa, yIndex) '7/10
                    Next aa
                    maxdepth = temp
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & " mdmodel:function-maxdepth")
            End Try

        End Function 'maxdepth
        Sub segmentdepthcalc()
            Dim j As Integer
            For j = 0 To total_segments - 1

                toolpath(j).segmentdepth = avedepth(toolpath(j).x, toolpath(j).y, frfootprint)
            Next


        End Sub
        Public Sub OpenXML(ByVal filename As String)
            ' Open the XML Documentation file, find the root node and start the
            ' parse for machine tags.

            If filename = "" Then Throw New Exception("The file name is not valid.")

            Dim xmlDoc As XmlDocument = New XmlDocument

            xmlDoc.Load(filename)

            Dim root As XmlNode = xmlDoc.FirstChild

            If root Is Nothing Then
                Throw New Exception("Root node cannot be found in the XML Documentation file '" & filename & "'.")
            End If

            'Skip the XML document header.
            If root.Name = "xml" Then
                'The root node should be next.
                root = root.NextSibling
            End If

            If LCase(root.Name) = "machinetags" Then
                'Begin the import.
                ParsemachinetagsXML(root)
            Else
                Throw New Exception(root.Name & " node cannot be found.")
            End If
            Try

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)

            End Try
        End Sub

        Private Sub ParsemachinetagsXML(ByVal root As Xml.XmlNode)

            Dim child As Xml.XmlNode
            Dim node As Xml.XmlNode
            Dim imax As Integer = machinedata.GetUpperBound(0)
            Dim i As Integer = 0
            For Each child In root.ChildNodes

                'Build a  data structure from the  info contained within the XML file.
                'machinedata is array structure.  
                'each element is a structure containing strings and parameters for one machine
                With machinedata(i)
                    For Each node In child.ChildNodes
                        Select Case LCase(node.Name) 'case names to lower case load array from xml file
                            Case "jetonmcode"
                                .jetOnMcode = node.InnerXml.Trim
                            Case "jetoffmcode"
                                .jetOffMcode = node.InnerXml.Trim
                            Case "abrasiveonmcode"
                                .abrasiveOnMcode = node.InnerXml.Trim
                            Case "abrasiveoffmcode"
                                .abrasiveOffMcode = node.InnerXml.Trim
                            Case "ccompstring"
                                .ccompstring = node.InnerXml.Trim
                            Case "dynjetoff"
                                .dynjetoff = node.InnerXml.Trim
                            Case "dynjeton"
                                .dynjeton = node.InnerXml.Trim
                            Case "dyntag"
                                .dyntag = node.InnerXml.Trim
                            Case "endstring"
                                .endstring = node.InnerXml.Trim
                            Case "firstrowoffset"
                                .firstrowoffset = CInt(node.InnerXml.Trim)
                            Case "jetonstring"
                                .jetonstring = node.InnerXml.Trim
                            Case "machinecomment"
                                .machinecomment = node.InnerXml.Trim
                            Case "machinecommentend"
                                .machinecommentend = node.InnerXml.Trim
                            Case "machinetag"
                                .machinetag = node.InnerXml.Trim
                            Case "maxacceln"
                                .maxacceln = CDbl(node.InnerXml.Trim)
                            Case "maxaccelt"
                                .maxaccelt = CDbl(node.InnerXml.Trim)
                            Case "maxspeed"
                                .maxspeed = CDbl(node.InnerXml.Trim)
                            Case "name"
                                .name = node.InnerXml.Trim
                            Case "repeatstart"
                                .repeatstart = node.InnerXml.Trim
                            Case "repeatstop"
                                .repeatstop = node.InnerXml.Trim
                            Case "startstring"
                                .startstring = node.InnerXml.Trim
                            Case "vscalingstring"
                                .vscalingstring = node.InnerXml.Trim
                            Case "arctype"
                                .arctype = CInt(node.InnerXml.Trim)
                        End Select
                    Next
                End With
                i += 1

                If i > imax Then
                    MessageBox.Show("Machine list full (maximum number=" & imax & ")")
                    Exit For
                End If
            Next

            machinemax = i - 1
        End Sub 'ParsemachinetagsXML
        Sub loadxmlmachineinfo()

            Dim sheaderpath As String = MachineTagsXmlFile
            OpenXML(sheaderpath)

        End Sub 'loadxmlmachineinfo
        ' dxf_to_target_surface
        Sub xydistance()
            Try

                For i = 1 To nc.GetUpperBound(0)
                    nc(i).xydist = Math.Sqrt((nc(i).x - nc(i - 1).x) ^ 2 + (nc(i).y - nc(i - 1).y) ^ 2)
                Next
                nc(0).xydist = nc(1).xydist
            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & "sub:xydistance")
            End Try

        End Sub 'xydistance
        Function distance(ByVal x1 As Double, ByVal y1 As Double, ByVal z1 As Double,
                            ByVal x2 As Double _
                            , ByVal y2 As Double, ByVal z2 As Double) As Double
            distance = Math.Sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2 + (z2 - z1) ^ 2)
        End Function 'distance


        Function aequal(ByVal x1 As Double, ByVal x2 As Double, ByVal e As Double) As Boolean
            'returns true if values are equal within error e
            If Math.Abs(x2 - x1) <= e Then
                aequal = True
            Else
                aequal = False
            End If
        End Function 'aequal

        Function getyindex(ByVal yi As Double, ByVal meshsize As Double, ByVal pad As Double,
                            ByRef miny As Double) As Integer
            'convert Y location to array index
            getyindex = CInt(Math.Round(((yi - miny) + pad) / meshsize, 0))

            If getyindex < 0 Then getyindex = 0
            If getyindex > size_yarray - 1 Then getyindex = size_yarray - 1
        End Function 'getyindex

        Function getylocation(ByVal yi As Long, ByVal meshsize As Double, ByVal pad As Double,
                                ByRef miny As Double) As Double
            'convert Y array index to location
            getylocation = ((yi * meshsize) - pad) + miny
        End Function

        Function getxindex(ByVal xi As Double, ByVal meshsize As Double, ByVal pad As Double,
                            ByVal minx As Double) As Integer
            'convert X location to array index
            getxindex = CInt(Math.Round(((xi - minx) + pad) / meshsize, 0))
            If getxindex < 0 Then getxindex = 0
            If getxindex > size_xarray - 1 Then getxindex = size_xarray - 1
        End Function

        Function getxlocation(ByVal xi As Integer, ByVal meshsize As Double, ByVal pad As Double, ByVal minx As Double) As Double
            'convert X array index to location
            getxlocation = ((xi * meshsize) - pad) + minx
        End Function


        Function subtract_surface(ByVal r As Integer) As Boolean
            Dim a, b, yindex, xindex, prev_yindex, prev_xindex As Integer
            Dim dbf, fr, vjetmag As Double
            Dim deltax, deltay, deltaz, deltal3d, deltab, delta_index, feedrate As Double

            'surface modeling subroutine
            'subtract jet impact from surface array
            'check to see if radius of jet is small compared to mesh_size

            'if it is reset to 0

            'vjetmag = vector_mag(vjetx, vjety, vjetz)
            vjetmag = 1
            'start through toolpath array
            'DEBUG.writeline(r)
            Try

                prev_xindex = getxindex(toolpath(0).x, mesh_size, ccomp, pathmin_x)
                prev_yindex = getyindex(toolpath(0).y, mesh_size, ccomp, pathmin_y)
                For i = 1 To total_segments - 1
                    ' Parallel.For(1, total_segments - 1, Sub(i)


                    'Dim deltal As Double = Math.Sqrt(deltax * deltax + deltay * deltay)

                    deltab = toolpath(i).b - toolpath(i - 1).b
                    If deltab <> 0 Then
                        'find position and feedrate in array of toolpath
                        deltal3d = Math.Sqrt(deltax ^ 2 + deltay ^ 2 + deltaz ^ 2)
                        deltax = toolpath(i).x - toolpath(i - 1).x
                        deltay = toolpath(i).y - toolpath(i - 1).y
                        deltaz = toolpath(i).z - toolpath(i - 1).z
                    End If

                    xindex = getxindex(toolpath(i).x, mesh_size, ccomp, pathmin_x)
                    yindex = getyindex(toolpath(i).y, mesh_size, ccomp, pathmin_y)
                    delta_index = Math.Sqrt((xindex - prev_xindex) ^ 2 + (yindex - prev_yindex) ^ 2)

                    prev_xindex = xindex
                    prev_yindex = yindex

                    If delta_index <> 0 Then

                        feedrate = toolpath(i).mf
                        If feedrate = 0 Then feedrate = toolpath(i + 1).mf

                        If deltab <> 0 And deltal3d <> 0 And surface(xindex, yindex) < 0 Then
                            If grvedir = groovedirection.Y Then
                                dbf = deltabfactor(surface(xindex, yindex), deltab, deltay, deltal3d)
                            ElseIf grvedir = groovedirection.X Then
                                dbf = deltabfactor(surface(xindex, yindex), deltab, deltax, deltal3d)
                            Else
                                If Math.Abs(deltax) >= Math.Abs(deltay) Then
                                    dbf = deltabfactor(surface(xindex, yindex), deltab, deltax, deltal3d)
                                ElseIf Math.Abs(deltax) < Math.Abs(deltay) Then
                                    dbf = deltabfactor(surface(xindex, yindex), deltab, deltay, deltal3d)
                                End If
                            End If
                        Else
                            dbf = 1
                        End If

                        'fr is constant for each toolpath segment
                        fr = (delta_index * depth_per_run / (dbf * feedrate))


                        'Debug.WriteLine(toolpath(i).x.ToString() + ";" + toolpath(i).y.ToString() + ";" + delta_index.ToString() + ";" + fr.ToString())
                        'scan across jet at index location and calculate jet footprint
                        For a = xindex - jetradius To xindex + jetradius
                            For b = yindex - jetradius To yindex + jetradius

                                Dim jfactor As Double
                                jfactor = mrrvalue(a - xindex + jetradius, b - yindex + jetradius)
                                If jfactor <> 0 Then
                                    '6/22/2007 added mi to calc for variable mi
                                    '5/28/14 added depth factor to adjust removal rate down as groove gets deeper
                                    If maskSurface(a, b) <> 0 Then
                                        'tempsurface(a, b) = fr * depthFactor(a, b) * slopefactor3(a, b) * mi_surface(a, b) * mrrvalue(a - xindex + jetradius, b - yindex + jetradius)
                                        Dim slfactor As Double
                                        Dim angle As Double = incidentAngle(a, b)
                                        slfactor = slopefactor3(angle)
                                        tempsurface(a, b) = fr * slfactor * mi_surface(a, b) * jfactor
                                    Else
                                        tempsurface(a, b) = 0
                                    End If
                                Else
                                    tempsurface(a, b) = 0
                                End If

                            Next b
                        Next a


                        'replace surface with new surface after scanning
                        For a = xindex - jetradius To xindex + jetradius
                            For b = yindex - jetradius To yindex + jetradius
                                surface(a, b) = surface(a, b) - tempsurface(a, b)
                            Next b
                        Next a

                        'check for spikes and pits in surface reuse tempsurface
                        For a = xindex - jetradius To xindex + jetradius
                            For b = yindex - jetradius To yindex + jetradius
                                If (surface(a, b) < surface(a + 1, b) And surface(a, b) < surface(a - 1, b) And
                                    surface(a, b) < surface(a, b + 1) And surface(a, b) < surface(a, b - 1)) Or
                                    (surface(a, b) > surface(a + 1, b) And surface(a, b) > surface(a - 1, b) And
                                    surface(a, b) > surface(a, b + 1) And surface(a, b) > surface(a, b - 1)) Then
                                    tempsurface(a, b) = (surface(a, b) + surface(a - 1, b) + surface(a + 1, b) + surface(a, b - 1) + surface(a, b + 1)) / 5
                                Else
                                    tempsurface(a, b) = surface(a, b)
                                End If

                            Next b
                        Next a

                        'replace surface with smoothed tempsurface
                        For a = xindex - jetradius To xindex + jetradius
                            For b = yindex - jetradius To yindex + jetradius
                                surface(a, b) = tempsurface(a, b)
                            Next b
                        Next a

                    End If
                    'next toolpath segment
                    'End Sub)
                Next i
                Return True
            Catch ex As Exception
                ' MessageBox.Show("Model runtime error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Debug.WriteLine(ex.Message.ToString & "| sub:subtract surface run:" & i)
                Return False
            End Try

        End Function 'subtract surface          



        Function newfeedout(ByVal targsurface As surfacetype, ByVal newfeed As Boolean) As Boolean

            'calc new feed rates for each nc line based on depth and nominal depth
            Dim i, j, a, masktemp, clipFlagCount As Integer
            'If strgroovedir = "MULTI" Then

            Try

                j = 0
                For i = 1 To nc.GetUpperBound(0) - 1

                    a = 0
                    nc(i).depth = 0
                    nc(i).minsegmentdepth = Double.MinValue
                    minsegmentdepthj = Double.MaxValue
                    nc(i).maxsegmentdepth = Double.MinValue
                    maxsegmentdepthj = Double.MinValue
                    nc(i).nominalsurface = 0
                    nc(i).modelf = 0
                    nc(i).newf = nc(i).f
                    nc(i).mi = 0
                    nc(i).mask = 0
                    masktemp = 0
                    If (Not nc(i).isComment) Then
                        Do While toolpath(j).n = nc(i).n And j < toolpath.GetUpperBound(0)

                            If maxdepthcalcpref Then
                                'changed depth calc to max depth from avedepth to use in rocket type grooves
                                'toolpath(j).segmentdepth = maxdepth(toolpath(j).x, toolpath(j).y, grvedir)
                                'toolpath(j).segmentdepth = maxFootprintDepth(toolpath(j).x, toolpath(j).y, frfootprint)
                                toolpath(j).segmentdepth = maxFootprintDepth3(toolpath(j).x, toolpath(j).y, frfootprint)
                                nc(i).depth = nc(i).depth + toolpath(j).segmentdepth
                            Else
                                toolpath(j).segmentdepth = avedepth(toolpath(j).x, toolpath(j).y, frfootprint)
                                'toolpath(j).segmentdepth = maxFootprintDepth(toolpath(j).x, toolpath(j).y, frfootprint)
                                nc(i).depth = nc(i).depth + toolpath(j).segmentdepth
                            End If
                            '6/22/07 changed mi to double from integer to allow for variable mi
                            'nc(i).mi = nc(i).mi + mi_surface(getxindex(toolpath(j).x, mesh_size, ccomp, pathmin_x), getyindex(toolpath(j).y, mesh_size, ccomp, pathmin_y))

                            'If Math.Abs(surface(getxindex(toolpath(j).x, mesh_size, ccomp, pathmin_x), getyindex(toolpath(j).y, mesh_size, ccomp, pathmin_y))) > System.Math.Abs(maxsegmentdepthj) Then
                            '    maxsegmentdepthj = surface(getxindex(toolpath(j).x, mesh_size, ccomp, pathmin_x), getyindex(toolpath(j).y, mesh_size, ccomp, pathmin_y))
                            'End If

                            'If Math.Abs(surface(getxindex(toolpath(j).x, mesh_size, ccomp, pathmin_x), getyindex(toolpath(j).y, mesh_size, ccomp, pathmin_y))) < Math.Abs(minsegmentdepthj) Then
                            '    minsegmentdepthj = surface(getxindex(toolpath(j).x, mesh_size, ccomp, pathmin_x), getyindex(toolpath(j).y, mesh_size, ccomp, pathmin_y))
                            'End If
                            nc(i).nominalsurface = nc(i).nominalsurface + target_surface(getxindex(toolpath(j).x, mesh_size, ccomp, pathmin_x), getyindex(toolpath(j).y, mesh_size, ccomp, pathmin_y))

                            nc(i).modelf = nc(i).modelf + toolpath(j).mf
                            a = a + 1 ' count of model segment per nc line segment
                            j = j + 1 'increment through tool path
                        Loop 'loop through toolpath 
                        If a = 0 Then a = 1
                        'find average min and max depth for each cnc line
                        'nc(i).minsegmentdepth = minsegmentdepthj
                        'nc(i).maxsegmentdepth = maxsegmentdepthj
                        nc(i).depth = nc(i).depth / a
                        nc(i).modelf = nc(i).modelf / a
                        nc(i).nominalsurface = nc(i).nominalsurface / a
                        'nc(i).mi = nc(i).mi / a
                        'calc new feed rates
                        If newfeed Then

                            If nc(i).depth = 0 Then
                                nc(i).depth = nom_depth
                                Debug.WriteLine("model depth=0 at  x" + nc(i).x.ToString() + ", y" + nc(i).y.ToString())
                            End If

                            If (nom_depth = 0) Then
                                Throw New Exception("Target Depth cannot equal zero.")
                            End If

                            If (nc(i).nominalsurface = 0) Then
                                nc(i).nominalsurface = nom_depth
                            End If
                            nc(i).newf = nc(i).modelf * Math.Abs(nc(i).depth / nc(i).nominalsurface)
                            If Not (IsNumeric(nc(i).newf)) Then nc(i).newf = machine.maxspeed
                            'If clipfrpref Then
                            '    If nc(i).f > machine.maxspeed Or nc(i).newf > machine.maxspeed Or Not (IsNumeric(nc(i).newf)) Then
                            '        nc(i).newf = machine.maxspeed
                            '        clipfrflag = True
                            '        clipFlagCount = clipFlagCount + 1
                            '    End If
                            'End If

                            If nc(i).newf = 0 Then
                                nc(i).newf = nc(i).f
                                'Throw New Exception("New Feed rate equals zero at: " & nc(i).line)
                            End If

                        End If 'newfeed 
                    End If 'not comment

                Next i

            Catch ex As Exception
                'Debug.WriteLine(ex.Message.ToString & "i:" & i & " j:" & j & " sub:newfeedout")
                MessageBox.Show(ex.Message.ToString & " sub:newfeedout", "Error")
                Return False
            End Try
            Return True
        End Function 'newfeedout
        Function depthFactor(a As Integer, b As Integer) As Double
            Dim d As Double = Math.Abs(surface(a, b))
            Dim depthF As Double = 1
            If (d > 0) Then
                depthF = -0.0277 * (d / (rjet * 2)) + 1.0623
            End If

            Return depthF

        End Function
        Private Function incidentAngle(ByVal a As Integer, ByVal b As Integer) As Double
            Dim dza As Double = surface(a + 1, b) - surface(a - 1, b)
            Dim dzb As Double = surface(a, b + 1) - surface(a, b - 1)
            Dim s1 As vector = New vector(mesh_size2, 0, dza)
            Dim s2 As vector = New vector(0, mesh_size2, dzb)
            Dim normal As vector = s1.cross(s2)
            incidentAngle = Math.Abs(Math.Acos(normal.z / normal.mag))
        End Function
        Private Function slopefactor3(incAngle As Double) As Double


            slopefactor3 = Math.Abs(Math.Cos(incAngle - crit_angle_1_rad))

        End Function 'slopefactor


    End Module
End Namespace