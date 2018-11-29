Imports System.IO 'For file handling
Namespace abmach
    Public Class surfacefile
        Public Sub filesave(ByVal fileHeader As String, ByVal FileName As String, ByVal surf(,) As Double, _
                            ByVal meshstep As Integer, ByVal meshsize As Double)
            Try
                ' get the file name  in from the standard save dialog
                ' open a stream for writing and create a StreamWriter to use to implement the stream
                Dim fs As New FileStream(FileName, FileMode.Create, FileAccess.Write)
                Dim m_streamWriter As New StreamWriter(fs)
                Dim i, j, sizexarray, sizeyarray As Integer
                ' Write to the file using StreamWriter class
                m_streamWriter.WriteLine(fileHeader)
                For i = 1 To surf.GetUpperBound(0) - 1 Step meshstep
                    For j = 1 To surf.GetUpperBound(1) - 1 Step meshstep
                        m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, ccomp, pathmin_x), 3) & "," & Math.Round(getylocation(j, meshsize, ccomp, pathmin_y), 3) & "," & Math.Round(surf(i, j), 3))
                    Next j
                Next i
                m_streamWriter.WriteLine("EOF")

                ' Close the file
                m_streamWriter.Flush()
                m_streamWriter.Close()
            Catch em As Exception
                Debug.WriteLine(em.Message.ToString() & "sub:infofile.filesave")
            End Try

        End Sub 'filesave
        Public Sub filesave(ByVal fileHeader As String, ByVal FileName As String, ByVal surf(,) As Single, _
                    ByVal meshstep As Integer, ByVal meshsize As Double)
            Try
                ' get the file name  in from the standard save dialog
                ' open a stream for writing and create a StreamWriter to use to implement the stream
                Dim fs As New FileStream(FileName, FileMode.Create, FileAccess.Write)
                Dim m_streamWriter As New StreamWriter(fs)
                Dim i, j, sizexarray, sizeyarray As Integer
                ' Write to the file using StreamWriter class
                m_streamWriter.WriteLine(fileHeader)
                For i = 1 To surf.GetUpperBound(0) - 1 Step meshstep
                    For j = 1 To surf.GetUpperBound(1) - 1 Step meshstep
                        m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, ccomp, pathmin_x), 3) & "," & Math.Round(getylocation(j, meshsize, ccomp, pathmin_y), 3) & "," & Math.Round(surf(i, j), 3))
                    Next j
                Next i
                m_streamWriter.WriteLine("EOF")

                ' Close the file
                m_streamWriter.Flush()
                m_streamWriter.Close()
            Catch em As Exception
                Debug.WriteLine(em.Message.ToString() & "sub:infofile.filesave")
            End Try

        End Sub 'filesave
        Function readcsvsurffile(ByVal input As Form1.fileType, ByVal surfinptfilename As String) As Boolean
            Dim strLine, tempString As String
            Dim a, yindex, zindex, miindex, length, filetype As Integer
            Dim fileok, surfaceok, headersloaded As Boolean
            Dim i, j, k As Integer
            Dim testx, testy, deltay, deltax, mindeltax, mindeltay As Double
            Dim tempcolumn(), temprow(), temp_targetprofile(), tmi As Double
            Dim index1 As Integer = 1
            Dim index2 As Integer = 1
            fileok = True
            Dim csvPoint() As mdmodel.dsurfpoint
            Dim csvExtents As mdmodel.dArrayExtents
            Try
                Dim fs As New FileStream(surfinptfilename, FileMode.Open, FileAccess.Read)
                Dim m_streamReader As New StreamReader(fs)

                ' Read to the file using StreamReader  class find length of file
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin)
                a = 0
                strLine = m_streamReader.ReadLine()
                While Not (strLine Is Nothing) And strLine <> "EOF"
                    strLine = m_streamReader.ReadLine()
                    a += 1
                End While
                ' Read  each line of the stream 
                csvExtents.size = a - 1
                ReDim csvPoint(csvExtents.size)

                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin)
                strLine = m_streamReader.ReadLine()
                a = 0
                While Not (strLine Is Nothing)

                    strLine = strLine.Trim
                    strLine = strLine.ToUpper
                    If Not headersloaded Then
                        If strLine = "X,Y,Z" Then
                            filetype = 1
                            headersloaded = True

                        ElseIf strLine = "X,Y,Z,MI" Then
                            filetype = 2
                            headersloaded = True

                        ElseIf strLine = "X,Y,MI" Then
                            filetype = 3
                            headersloaded = True

                        End If
                    End If

                    If filetype = 1 And headersloaded Then
                        'startSurfaceOK = False
                        If IsNumeric(strLine.Substring(0, 2)) Then
                            yindex = strLine.IndexOf(",") + 1
                            zindex = strLine.IndexOf(",", yindex) + 1
                            length = strLine.Length
                            csvPoint(a).x = CDbl(strLine.Substring(0, yindex - 1))
                            csvPoint(a).y = CDbl(strLine.Substring(yindex, zindex - yindex - 1))
                            csvPoint(a).z = CDbl(strLine.Substring(zindex))
                            csvPoint(a).mi = 1
                            a += 1

                        End If
                    ElseIf filetype = 2 And headersloaded Then
                        'startSurfaceOK = False
                        miSurfaceOK = False
                        If IsNumeric(strLine.Substring(0, 2)) Then
                            yindex = strLine.IndexOf(",") + 1
                            zindex = strLine.IndexOf(",", yindex) + 1
                            miindex = strLine.IndexOf(",", zindex) + 1
                            length = strLine.Length
                            csvPoint(a).x = CDbl(strLine.Substring(0, yindex - 1))
                            csvPoint(a).y = CDbl(strLine.Substring(yindex, zindex - yindex - 1))
                            csvPoint(a).z = CDbl(strLine.Substring(zindex, miindex - zindex - 1))
                            csvPoint(a).mi = CDbl(strLine.Substring(miindex))
                            a += 1
                        End If
                    ElseIf filetype = 3 And headersloaded Then
                        ' startSurfaceOK = False
                        miSurfaceOK = False
                        If IsNumeric(strLine.Substring(0, 2)) Then
                            yindex = strLine.IndexOf(",") + 1
                            zindex = strLine.IndexOf(",", yindex) + 1
                            length = strLine.Length
                            csvPoint(a).x = CDbl(strLine.Substring(0, yindex - 1))
                            csvPoint(a).y = CDbl(strLine.Substring(yindex, zindex - yindex - 1))
                            csvPoint(a).mi = CDbl(strLine.Substring(zindex))
                            a += 1

                        End If
                    Else
                        Return False
                    End If
                    strLine = m_streamReader.ReadLine()

                End While

                ' Close the stream
                m_streamReader.Close()




                csvExtents.max_x = -9.99999999E+28
                csvExtents.max_y = -9.99999999E+28
                csvExtents.max_z = -9.99999999E+28

                csvExtents.min_x = 9.99999999E+28
                csvExtents.min_y = 9.99999999E+28
                csvExtents.min_z = 9.99999999E+28

                mindeltax = 9.99999999E+28
                mindeltay = 9.99999999E+28

                'find csvPoint extents
                For a = 0 To csvExtents.size '- 1

                    If csvPoint(a).x > csvExtents.max_x Then csvExtents.max_x = csvPoint(a).x
                    If csvPoint(a).y > csvExtents.max_y Then csvExtents.max_y = csvPoint(a).y
                    If csvPoint(a).z > csvExtents.max_z Then csvExtents.max_z = csvPoint(a).z

                    If csvPoint(a).x < csvExtents.min_x Then csvExtents.min_x = csvPoint(a).x
                    If csvPoint(a).y < csvExtents.min_y Then csvExtents.min_y = csvPoint(a).y
                    If csvPoint(a).z < csvExtents.min_z Then csvExtents.min_z = csvPoint(a).z

                Next

                If csvExtents.max_z > 0 Then
                    For a = 0 To csvExtents.size '- 1
                        csvPoint(a).z = csvPoint(a).z - csvExtents.max_z
                    Next a
                End If

                'deltax or deltay will be 0 
                'assume mesh spacing is equal to biggest of the two
                deltax = Math.Abs(csvPoint(1).x - csvPoint(0).x)
                deltay = Math.Abs(csvPoint(1).y - csvPoint(0).y)

                'find number of rows and columns and mesh size
                csvExtents.xmeshsize = Math.Max(deltax, deltay)
                csvExtents.ymeshsize = csvExtents.xmeshsize
                csvExtents.rows = CInt(1 + ((csvExtents.max_y - csvExtents.min_y) / csvExtents.ymeshsize))
                csvExtents.columns = CInt(1 + ((csvExtents.max_x - csvExtents.min_x) / csvExtents.xmeshsize))
                a = 0
                'load array with surface data
                'determine if csvExtents is 1d or 2d
                With csvExtents
                    'redimension array
                    If input = Form1.fileType.mi Then
                        ReDim tmisurface(.columns, .rows)
                    ElseIf input = Form1.fileType.mask Then
                        ReDim tMaskSurface(.columns, .rows)
                    Else
                        ReDim tsurface(.columns, .rows)
                    End If


                    For a = 0 To .size - 1
                        column = CInt((csvPoint(a).x - .min_x) / .xmeshsize)
                        row = CInt((csvPoint(a).y - .min_y) / .ymeshsize)
                        'If row >= 0 And row <= .rows And column >= 0 And column <= .columns Then

                        If input = Form1.fileType.mi Then
                            tmisurface(column, row) = csvPoint(a).mi
                        ElseIf input = Form1.fileType.mask Then
                            tMaskSurface(column, row) = csvPoint(a).mask
                        Else
                            tsurface(column, row) = csvPoint(a).z
                        End If

                        'End If
                    Next

                End With



                If input = Form1.fileType.mask Then
                    maskExtents = csvExtents
                ElseIf input = Form1.fileType.mi Then
                    miExtents = csvExtents
                ElseIf input = Form1.fileType.startDepth Then
                    startExtents = csvExtents
                ElseIf input = Form1.fileType.targetDepth Then
                    targetExtents = csvExtents
                End If
                Return True

            Catch em As Exception
                MessageBox.Show(em.Message.ToString() & " funct:infofile.readcsvsurffile")
                Return False
            End Try
        End Function

        Function readDxfSurfFile(ByVal input As Form1.fileType, ByVal dxfinptfilename As String) As Boolean
            pointcount = 0
            Dim a, b, filelength, mask As Integer
            Dim strLine, strline1, strline2 As String
            Dim fileok, surfaceok As Boolean
            Dim temp As Double
            Dim i, j, k As Integer
            Dim testx, testy, deltay, deltax, mindeltax, mindeltay As Double
            Dim tempcolumn(), temprow(), temp_targetprofile(), tmi As Double
            Dim index1 As Integer = 1
            Dim index2 As Integer = 1
            Dim dxfPoint() As mdmodel.dsurfpoint
            Dim dxfExtents As mdmodel.dArrayExtents

            Try
                Dim fs As New FileStream(dxfinptfilename, FileMode.Open, FileAccess.Read)
                Dim m_streamReader As New StreamReader(fs)
                b = 0
                a = 0
                fileok = True
                ' find length of file 
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin)
                strLine = m_streamReader.ReadLine()
                Dim l As Integer = strLine.Length
                If l > 14 Then
                    If strLine.Substring(0, 14).ToLower = "autocad binary" Then
                        Return False
                        Throw New Exception("DXF binary file not compatible")
                    End If
                End If
                'find number of point entities in file
                'by counting keywords
                While Not (strLine Is Nothing) And strLine <> "EOF"
                    strLine = m_streamReader.ReadLine()
                    If strLine.Trim.ToLower = "acdbpoint" Then
                        b += 1
                    End If
                    If strLine.Trim.ToLower = "point" Then
                        a += 1
                    End If
                End While
                'redim based on number of points
                dxfExtents.size = Math.Max(a, b)
                If dxfExtents.size = 0 Then
                    Return False
                    Throw New Exception("DXF points not found")
                End If
                ReDim dxfPoint(dxfExtents.size)

                ' Read  each line of the stream 
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin)
                strLine = m_streamReader.ReadLine()
                While Not (strLine Is Nothing) And strLine <> "EOF"
                    strLine = m_streamReader.ReadLine()
                    If b > 0 Then ' primary DXF file format
                        If strLine.Trim.ToLower = "point" Then
                            strLine = m_streamReader.ReadLine() '5
                            strLine = m_streamReader.ReadLine() '30e
                            strLine = m_streamReader.ReadLine() '100
                            strLine = m_streamReader.ReadLine() 'acdbentity
                            strLine = m_streamReader.ReadLine() '8
                            strLine = m_streamReader.ReadLine() '3
                            strLine = m_streamReader.ReadLine() '6
                            strLine = m_streamReader.ReadLine() 'solid
                            strLine = m_streamReader.ReadLine() '62
                            strline1 = m_streamReader.ReadLine() 'color
                            strLine = m_streamReader.ReadLine() '100
                            strLine = m_streamReader.ReadLine() 'acdbpoint
                            If strLine.Trim.ToLower = "acdbpoint" Then

                                mask = CInt(strline1)

                                If IsNumeric(mask) Then

                                    If mask = 1 Then
                                        temp = 0
                                    Else
                                        temp = 1
                                    End If
                                Else
                                    temp = 1
                                End If
                                If input = Form1.fileType.mask Then
                                    dxfPoint(pointcount).mask = CInt(temp)
                                ElseIf input = Form1.fileType.mi Then
                                    dxfPoint(pointcount).mi = temp
                                End If

                            End If
                            strLine = m_streamReader.ReadLine() '10
                            strLine = m_streamReader.ReadLine() 'X
                            dxfPoint(pointcount).x = CDbl(strLine)
                            strLine = m_streamReader.ReadLine() '20
                            strLine = m_streamReader.ReadLine() 'Y
                            dxfPoint(pointcount).y = CDbl(strLine)
                            strLine = m_streamReader.ReadLine() '30
                            strLine = m_streamReader.ReadLine() 'Z
                            dxfPoint(pointcount).z = CDbl(strLine)
                            pointcount += 1
                        End If
                    ElseIf b = 0 And a > 0 Then ' alternate DXF file format
                        If strLine.Trim.ToLower = "point" Then
                            strLine = m_streamReader.ReadLine() '8
                            strLine = m_streamReader.ReadLine() '7
                            strLine = m_streamReader.ReadLine() '62
                            strLine = m_streamReader.ReadLine() 'color

                            mask = CInt(strLine)

                            If IsNumeric(mask) Then

                                If mask = 1 Then
                                    temp = 0
                                Else
                                    temp = 1
                                End If
                            Else
                                temp = 1
                            End If
                            If input = Form1.fileType.mask Then
                                dxfPoint(pointcount).mask = CInt(temp)
                            ElseIf input = Form1.fileType.mi Then
                                dxfPoint(pointcount).mi = temp
                            End If

                            strLine = m_streamReader.ReadLine() '10
                            strLine = m_streamReader.ReadLine() 'X
                            dxfPoint(pointcount).x = CDbl(strLine)
                            strLine = m_streamReader.ReadLine() '20
                            strLine = m_streamReader.ReadLine() 'Y
                            dxfPoint(pointcount).y = CDbl(strLine)
                            strLine = m_streamReader.ReadLine() '30
                            strLine = m_streamReader.ReadLine() 'Z
                            dxfPoint(pointcount).z = CDbl(strLine)
                            pointcount += 1
                        End If
                    End If


                End While

                ' Close the stream


                m_streamReader.Close()
                'find limits of array


                inputsurfacetype = surfacetype.dxfpoints
                'call examinesurffile and check if file can be parsed into array

                dxfExtents.max_x = -9.99999999E+28
                dxfExtents.max_y = -9.99999999E+28
                dxfExtents.max_z = -9.99999999E+28

                dxfExtents.min_x = 9.99999999E+28
                dxfExtents.min_y = 9.99999999E+28
                dxfExtents.min_z = 9.99999999E+28

                mindeltax = 9.99999999E+28
                mindeltay = 9.99999999E+28

                'find dxfPoint extents
                For a = 0 To dxfExtents.size - 1

                    If dxfPoint(a).x > dxfExtents.max_x Then dxfExtents.max_x = dxfPoint(a).x
                    If dxfPoint(a).y > dxfExtents.max_y Then dxfExtents.max_y = dxfPoint(a).y
                    If dxfPoint(a).z > dxfExtents.max_z Then dxfExtents.max_z = dxfPoint(a).z

                    If dxfPoint(a).x < dxfExtents.min_x Then dxfExtents.min_x = dxfPoint(a).x
                    If dxfPoint(a).y < dxfExtents.min_y Then dxfExtents.min_y = dxfPoint(a).y
                    If dxfPoint(a).z < dxfExtents.min_z Then dxfExtents.min_z = dxfPoint(a).z

                Next
                findArrayExtents(dxfPoint, dxfExtents)

                If dxfExtents.max_z > 0 Then
                    For a = 0 To dxfExtents.size - 1
                        dxfPoint(a).z = dxfPoint(a).z - dxfExtents.max_z
                    Next a
                End If
                'deltax or deltay will be 0 
                'assume mesh spacing is equal to biggest of the two
                deltax = Math.Abs(dxfPoint(1).x - dxfPoint(0).x)
                deltay = Math.Abs(dxfPoint(1).y - dxfPoint(0).y)

                'find number of rows and columns and mesh size
                dxfExtents.xmeshsize = Math.Max(deltax, deltay)
                dxfExtents.ymeshsize = dxfExtents.xmeshsize
                dxfExtents.rows = CInt(1 + ((dxfExtents.max_y - dxfExtents.min_y) / dxfExtents.ymeshsize))
                dxfExtents.columns = CInt(1 + ((dxfExtents.max_x - dxfExtents.min_x) / dxfExtents.xmeshsize))
                a = 0
                'load array with surface data
                With dxfExtents
                    'redimension array
                    If input = Form1.fileType.mask Then
                        ReDim tMaskSurface(.columns, .rows)
                    ElseIf input = Form1.fileType.mi Then
                        ReDim tmisurface(.columns, .rows)
                    Else
                        ReDim tsurface(.columns, .rows)
                    End If

                    'Debug.WriteLine(tsurface.Length)
                    'load input surface into array and mask array
                    'machininability value is based on z value of dxf entities
                    'green is machinable
                    'red is  mask
                    For a = 0 To .size - 1
                        column = CInt((dxfPoint(a).x - .min_x) / .xmeshsize)
                        row = CInt((dxfPoint(a).y - .min_y) / .ymeshsize)
                        If row >= 0 And row <= .rows And column >= 0 And column <= .columns Then

                            If input = Form1.fileType.mask Then
                                tMaskSurface(column, row) = dxfPoint(a).mask ' color value of dxf point
                            ElseIf input = Form1.fileType.mi Then
                                tmisurface(column, row) = dxfPoint(a).z ' z value of dxf point is machinibility
                            Else
                                tsurface(column, row) = dxfPoint(a).z
                            End If


                        End If
                    Next

                End With



                If input = Form1.fileType.mask Then
                    maskExtents = dxfExtents
                ElseIf input = Form1.fileType.mi Then
                    miExtents = dxfExtents
                ElseIf input = Form1.fileType.startDepth Then
                    startExtents = dxfExtents
                ElseIf input = Form1.fileType.targetDepth Then
                    targetExtents = dxfExtents
                End If

                Return True

            Catch em As Exception
                MessageBox.Show(em.Message.ToString() & " function:surface.readdxfsurffile")
                Return False
            End Try


        End Function 'dxfsurfinput

        Function dxfregioninput(ByVal dxfinptfilename As String, ByRef pointcount As Integer, _
                                ByRef regioncount As Integer) As Boolean
            pointcount = 0
            Dim b, filelength As Integer
            Dim strLine As String
            'read in DXF release 13 text file with rectangular regions defined 
            'store xyz values in structure depthpoint()
            Try


                Dim fs As New FileStream(dxfinptfilename, FileMode.Open, FileAccess.Read)
                Dim m_streamReader As New StreamReader(fs)
                b = 0
                ' find length of file 
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin)
                strLine = m_streamReader.ReadLine()
                Dim l As Integer = strLine.Length
                If l > 14 Then
                    If strLine.Substring(0, 14).ToLower = "autocad binary" Then
                        Return False
                        Throw New Exception("DXF binary file not compatible")
                    End If
                End If
                'find length of dxf file
                'and use length to redim array
                While Not (strLine Is Nothing) And strLine <> "EOF"
                    strLine = m_streamReader.ReadLine()

                    If strLine = "AcDbLine" Then
                        b += 1
                    End If
                End While
                ReDim regionpoint(b)

                ' Read  each line of the stream 
                'assume all lines are part of region rectangles
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin)
                strLine = m_streamReader.ReadLine()
                While Not (strLine Is Nothing) And strLine <> "EOF"


                    strLine = m_streamReader.ReadLine()
                    If strLine = "AcDbLine" Then
                        strLine = m_streamReader.ReadLine() '10
                        strLine = m_streamReader.ReadLine() 'x
                        regionpoint(pointcount).x1 = CDbl(strLine)
                        strLine = m_streamReader.ReadLine() '20
                        strLine = m_streamReader.ReadLine() 'y
                        regionpoint(pointcount).y1 = CDbl(strLine)
                        strLine = m_streamReader.ReadLine() '30
                        strLine = m_streamReader.ReadLine() 'z
                        regionpoint(pointcount).z1 = CDbl(strLine)
                        strLine = m_streamReader.ReadLine() '11
                        strLine = m_streamReader.ReadLine() 'x2
                        regionpoint(pointcount).x2 = CDbl(strLine)
                        strLine = m_streamReader.ReadLine() '21
                        strLine = m_streamReader.ReadLine() 'y2
                        regionpoint(pointcount).y2 = CDbl(strLine)
                        strLine = m_streamReader.ReadLine() '31
                        strLine = m_streamReader.ReadLine() 'z2
                        regionpoint(pointcount).z2 = CDbl(strLine)
                        strLine = m_streamReader.ReadLine() '0
                        strLine = m_streamReader.ReadLine() 'LINE
                        pointcount += 1
                    End If
                End While
                'calc regions and points assume 4 points per region
                regioncount = CInt((pointcount / 4) - 1)
                pointcount = pointcount - 1
                ' Close the stream


                m_streamReader.Close()

                Return True
            Catch em As Exception

                Debug.WriteLine(em.Message.ToString() & "sub:dxfinput")
                Return False
            End Try


        End Function 'dxfregioninput
    End Class 'surfacefile
End Namespace 'abmach
