Imports System.IO 'For file handling
Imports System.xml
Namespace abmach
    Public Class infofile

        Dim sdir As String = Path.GetDirectoryName(Application.ExecutablePath)
        Dim sheaderpath As String = sdir & Path.DirectorySeparatorChar & sheaderfile



        Public Sub loadfile(ByVal filename As String)
            Dim info(50), shortinfofilename, word As String
            Dim a As Integer = 0
            Dim b, filelength As Integer
            Try
                Dim fs As New FileStream(filename, FileMode.Open, FileAccess.Read)
                Dim m_streamReader As New StreamReader(fs)
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin)
                Dim strLine As String = m_streamReader.ReadLine()
                While Not (strLine Is Nothing) And strLine <> "ENDHEADER"
                    info(a) = strLine
                    strLine = m_streamReader.ReadLine()
                    a += 1
                End While
                filelength = a - 1
                m_streamReader.Close()
            Catch em As Exception
                Debug.WriteLine(em.Message.ToString() & "sub:mnuinfo_click read")
            End Try

            Try
                If Not (filename Is Nothing) Then
                    If LCase(info(0)).StartsWith(csheader) Or LCase(info(0)).StartsWith(Chr(34) & csheader) Then
                        For b = 1 To filelength - 1
                            Dim sepindex As Integer = info(b).IndexOf(",")
                            If sepindex > 0 Then
                                Dim currentheader As String = info(b).Substring(0, sepindex).Trim
                                Select Case LCase(currentheader)
                                    Case cscuttercomp
                                        defccomp = CDbl(info(b).Substring(sepindex + 1))
                                    Case csnumber_of_runs
                                        numberruns = CInt(info(b).Substring(sepindex + 1))
                                    Case csdepth_per_run
                                        depth_per_run = CDec(info(b).Substring(sepindex + 1))
                                    Case csnom_feedrate
                                        nom_feedrate = CDbl(info(b).Substring(sepindex + 1))
                                    Case csmaterial_thickness
                                        material_thickness = CDbl(info(b).Substring(sepindex + 1))
                                    Case csnom_depth
                                        nom_depth = CDbl(info(b).Substring(sepindex + 1))
                                    Case csdepth_tolerance
                                        depth_tolerance = CDbl(info(b).Substring(sepindex + 1))
                                    Case csmrrtype
                                        mrrtype = CInt(info(b).Substring(sepindex + 1))
                                    Case cscrit_angle_1
                                        crit_angle_1 = CDbl(info(b).Substring(sepindex + 1))
                                    Case csgroovedir
                                        strgroovedir = info(b).Substring(sepindex + 1)
                                    Case csdepthx
                                        mdepthx = CDbl(info(b).Substring(sepindex + 1))
                                    Case csdepthy
                                        mdepthy = CDbl(info(b).Substring(sepindex + 1))
                                    Case csarmradius
                                        armradius = CDbl(info(b).Substring(sepindex + 1))
                                End Select
                            End If
                        Next
                        parameters_loaded = True
                    Else
                        MessageBox.Show("Unrecognized parameter file header")
                        parameters_loaded = False
                    End If


                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & " sub:mnuinfo_click load")

            End Try
        End Sub
        Public Sub loadxmlinfofile(ByVal filename As String)
            Try
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

                If LCase(root.Name) = csheader Then
                    Dim child As Xml.XmlNode

                    For Each child In root.ChildNodes
                        'Build a version data structure from the  info contained within the XML file.
                        Select Case LCase(child.Name)

                            Case cscuttercomp
                                defccomp = CDbl(child.InnerXml.Trim)
                            Case csnumber_of_runs
                                numberruns = CInt(child.InnerXml.Trim)
                            Case csdepth_per_run
                                depth_per_run = CDec(child.InnerXml.Trim)
                            Case csnom_feedrate
                                nom_feedrate = CDbl(child.InnerXml.Trim)
                            Case csmaterial_thickness
                                material_thickness = CDbl(child.InnerXml.Trim)
                            Case csnom_depth
                                nom_depth = CDbl(child.InnerXml.Trim)
                            Case csdepth_tolerance
                                depth_tolerance = CDbl(child.InnerXml.Trim)
                            Case csmrrtype
                                mrrtype = CInt(child.InnerXml.Trim)
                            Case cscrit_angle_1
                                crit_angle_1 = CDbl(child.InnerXml.Trim)
                            Case csgroovedir
                                strgroovedir = child.InnerXml.Trim
                            Case csdepthx
                                mdepthx = CDbl(child.InnerXml.Trim)
                            Case csdepthy
                                mdepthy = CDbl(child.InnerXml.Trim)
                            Case csarmradius
                                armradius = CDbl(child.InnerXml.Trim)
                            Case csjeweldiameter
                                str_jeweldiameter = child.InnerXml.Trim
                            Case csjeweltype
                                str_jeweltype = child.InnerXml.Trim
                            Case csmixingtdiameter
                                str_mixingtdiameter = child.InnerXml.Trim
                            Case csmixingtlength
                                str_mixingtlength = child.InnerXml.Trim
                            Case cspressure
                                str_pressure = child.InnerXml.Trim
                            Case csnozzle
                                str_nozzle = child.InnerXml.Trim
                            Case csmachine
                                str_machinename = child.InnerXml.Trim
                            Case csabrasiveflow
                                str_abrasiveflow = child.InnerXml.Trim
                            Case csabrasivetype
                                str_abrasivetype = child.InnerXml.Trim
                            Case cspump
                                str_pumpname = child.InnerXml.Trim
                            Case cssod
                                str_sod = child.InnerXml.Trim
                        End Select
                    Next

                End If
                parameters_loaded = True
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & " in sub:loadxmlinfofile")
            End Try
        End Sub 'loadxmlinfofile

        Public Sub infosavexml(ByVal infofilename As String)
            Try
                Dim infowriter As New XmlTextWriter(infofilename, Nothing)
                infowriter.Formatting = Formatting.Indented
                infowriter.WriteStartDocument()
                infowriter.WriteStartElement(csheader)
                infowriter.WriteElementString(csfilename, infofilename)
                infowriter.WriteElementString(cscuttercomp, ccomp)
                infowriter.WriteElementString(csnumber_of_runs, numberruns)
                infowriter.WriteElementString(csdepth_per_run, depth_per_run)
                infowriter.WriteElementString(csnom_feedrate, nom_feedrate)
                infowriter.WriteElementString(csmaterial_thickness, material_thickness)
                infowriter.WriteElementString(csnom_depth, nom_depth)
                infowriter.WriteElementString(csdepth_tolerance, depth_tolerance)
                infowriter.WriteElementString(csmrrtype, mrrtype)
                infowriter.WriteElementString(cscrit_angle_1, crit_angle_1)
                infowriter.WriteElementString(csgroovedir, strgroovedir)
                infowriter.WriteElementString(csdepthx, mdepthx)
                infowriter.WriteElementString(csdepthy, mdepthy)
                infowriter.WriteElementString(csarmradius, armradius)
                infowriter.WriteElementString(csjeweldiameter, str_jeweldiameter)
                infowriter.WriteElementString(csjeweltype, str_jeweltype)
                infowriter.WriteElementString(csmixingtdiameter, str_mixingtdiameter)
                infowriter.WriteElementString(csmixingtlength, str_mixingtlength)
                infowriter.WriteElementString(cspressure, str_pressure)
                infowriter.WriteElementString(csnozzle, str_nozzle)
                infowriter.WriteElementString(csmachine, str_machinename)
                infowriter.WriteElementString(csabrasiveflow, str_abrasiveflow)
                infowriter.WriteElementString(csabrasivetype, str_abrasivetype)
                infowriter.WriteElementString(cspump, str_pumpname)
                infowriter.WriteElementString(cssod, str_sod)
                infowriter.WriteEndElement()
                infowriter.Close()

            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString)
            End Try
        End Sub

    End Class
End Namespace