Imports System.IO 'For file handling
Namespace abmach
    Public Class DXFfile
        Dim header2 As String = "SECTION"
        Dim header4 As String = "ENTITIES"
        Dim footer1 As String = "ENDSEC"
        Dim footer3 As String = "EOF"
        Dim point As String = "POINT"
        Dim line As String = "LINE"
        Dim text As String = "TEXT"
        Dim red As Integer = 1
        Dim yellow As Integer = 2
        Dim green As Integer = 3
        Dim cyan As Integer = 4
        Dim blue As Integer = 5
        Dim magenta As Integer = 6
        Dim grey As Integer = 8





        Public Function absColorSelect(ByVal z As Double, ByVal tz As Double, ByVal dtol As Double, ByVal dmax As Double) As Short
            'called by ylines and xlines
            'color selected based on depth and tolerance

            Dim min_depth2 As Double = -1 * (Math.Abs(tz) - 2 * Math.Abs(dtol))
            Dim min_depth As Double = -1 * (Math.Abs(tz) - Math.Abs(dtol))
            Dim max_depth As Double = -1 * (Math.Abs(tz) + Math.Abs(dtol))
            Dim max_depth2 As Double = -1 * (Math.Abs(tz) + 2 * Math.Abs(dtol))

            If Math.Abs(z) < Math.Abs(min_depth2) Then
                absColorSelect = magenta
            ElseIf Math.Abs(z) > Math.Abs(min_depth2) And Math.Abs(z) < Math.Abs(min_depth) Then
                absColorSelect = cyan
            ElseIf Math.Abs(z) > Math.Abs(min_depth) And Math.Abs(z) < Math.Abs(max_depth) Then
                absColorSelect = green
            ElseIf Math.Abs(z) > Math.Abs(max_depth) And z < dmax Then
                absColorSelect = yellow
            ElseIf Math.Abs(z) > max_depth2 Then
                absColorSelect = red
            Else
                absColorSelect = grey
            End If



        End Function

        Function absColorSelect(ByVal c As Integer) As Integer
            If c = 0 Then
                Return red
            Else
                Return green
            End If
        End Function

        Public Sub dxfsave(ByVal DXFFileName As String, ByVal surf(,) As Double, ByVal targsurf(,) As Double, _
                           ByVal meshstep As Integer, ByVal meshsize As Double, ByVal pad As Double, _
                           ByVal min_x As Double, ByVal min_y As Double, ByVal blankvalue As Double, _
                           ByVal dtol As Double, ByVal dmax As Double)
            Try
                ' get the file name to save the list view information in from the standard save dialog
                ' open a stream for writing and create a StreamWriter to use to implement the stream
                Dim fs As New FileStream(DXFFileName, FileMode.Create, FileAccess.Write)
                Dim m_streamWriter As New StreamWriter(fs)
                Dim i, j, sizexarray, sizeyarray, c As Integer
                Dim x, y, z, xp, yp, zp, xpp, ypp, zpp, tz As Double
                m_streamWriter.Flush()

                ' Write to the file using StreamWriter class

                m_streamWriter.WriteLine("0")
                m_streamWriter.WriteLine(header2)
                m_streamWriter.WriteLine("2")
                m_streamWriter.WriteLine(header4)
                m_streamWriter.WriteLine("0")
                'xline segments

                For j = 0 To surf.GetUpperBound(1) Step meshstep
                    For i = 1 To surf.GetUpperBound(0)
                        If surf(i, j) <> blankvalue Or surf(i - 1, j) <> blankvalue Then

                            m_streamWriter.WriteLine(line)
                            m_streamWriter.WriteLine("8")
                            m_streamWriter.WriteLine("1")
                            m_streamWriter.WriteLine("62")
                            m_streamWriter.WriteLine(absColorSelect(surf(i, j), targsurf(i, j), dtol, dmax))
                            m_streamWriter.WriteLine("10")
                            m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                            m_streamWriter.WriteLine("20")
                            m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                            m_streamWriter.WriteLine("30")
                            m_streamWriter.WriteLine(Math.Round(surf(i, j), 4))
                            m_streamWriter.WriteLine("11")
                            m_streamWriter.WriteLine(Math.Round(getxlocation(i - 1, meshsize, pad, min_x), 4))
                            m_streamWriter.WriteLine("21")
                            m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                            m_streamWriter.WriteLine("31")
                            m_streamWriter.WriteLine(Math.Round(surf(i - 1, j), 4))
                            m_streamWriter.WriteLine("0")
                        End If

                    Next i
                Next j
                For i = 0 To surf.GetUpperBound(0) Step meshstep
                    For j = 1 To surf.GetUpperBound(1)
                        If surf(i, j) <> blankvalue Or surf(i, j - 1) <> blankvalue Then
                            m_streamWriter.WriteLine(line)
                            m_streamWriter.WriteLine("8")
                            m_streamWriter.WriteLine("1")
                            m_streamWriter.WriteLine("62")
                            m_streamWriter.WriteLine(absColorSelect(surf(i, j), targsurf(i, j), dtol, dmax))
                            m_streamWriter.WriteLine("10")
                            m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                            m_streamWriter.WriteLine("20")
                            m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                            m_streamWriter.WriteLine("30")
                            m_streamWriter.WriteLine(Math.Round(surf(i, j), 4))
                            m_streamWriter.WriteLine("11")
                            m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                            m_streamWriter.WriteLine("21")
                            m_streamWriter.WriteLine(Math.Round(getylocation(j - 1, meshsize, pad, min_y), 4))
                            m_streamWriter.WriteLine("31")
                            m_streamWriter.WriteLine(Math.Round(surf(i, j - 1), 4))
                            m_streamWriter.WriteLine("0")

                        End If
                    Next j
                Next i

                m_streamWriter.WriteLine(footer1)
                m_streamWriter.WriteLine("0")
                m_streamWriter.WriteLine(footer3)

                'm_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin)


                ' Close the file
                m_streamWriter.Flush()
                m_streamWriter.Close()
            Catch em As Exception
                MessageBox.Show(em.Message.ToString & " in sub:dxffile.dxfsave1")
            End Try

        End Sub
        Public Sub dxfsave(ByVal DXFFileName As String, ByVal surf(,) As Single, ByVal targsurf(,) As Single, _
                           ByVal meshstep As Integer, ByVal meshsize As Double, ByVal pad As Double, _
                           ByVal min_x As Double, ByVal min_y As Double, ByVal blankvalue As Double, _
                           ByVal dtol As Double, ByVal dmax As Double)
            Try
                ' get the file name to save the list view information in from the standard save dialog
                ' open a stream for writing and create a StreamWriter to use to implement the stream
                Dim fs As New FileStream(DXFFileName, FileMode.Create, FileAccess.Write)
                Dim m_streamWriter As New StreamWriter(fs)
                Dim i, j, sizexarray, sizeyarray, c As Integer
                Dim x, y, z, xp, yp, zp, xpp, ypp, zpp, tz As Double
                m_streamWriter.Flush()

                ' Write to the file using StreamWriter class

                m_streamWriter.WriteLine("0")
                m_streamWriter.WriteLine(header2)
                m_streamWriter.WriteLine("2")
                m_streamWriter.WriteLine(header4)
                m_streamWriter.WriteLine("0")
                'xline segments

                For j = 0 To surf.GetUpperBound(1) Step meshstep
                    For i = 1 To surf.GetUpperBound(0)
                        If surf(i, j) <> blankvalue Or surf(i - 1, j) <> blankvalue Then

                            m_streamWriter.WriteLine(line)
                            m_streamWriter.WriteLine("8")
                            m_streamWriter.WriteLine("1")
                            m_streamWriter.WriteLine("62")
                            m_streamWriter.WriteLine(absColorSelect(surf(i, j), targsurf(i, j), dtol, dmax))
                            m_streamWriter.WriteLine("10")
                            m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                            m_streamWriter.WriteLine("20")
                            m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                            m_streamWriter.WriteLine("30")
                            m_streamWriter.WriteLine(Math.Round(surf(i, j), 4))
                            m_streamWriter.WriteLine("11")
                            m_streamWriter.WriteLine(Math.Round(getxlocation(i - 1, meshsize, pad, min_x), 4))
                            m_streamWriter.WriteLine("21")
                            m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                            m_streamWriter.WriteLine("31")
                            m_streamWriter.WriteLine(Math.Round(surf(i - 1, j), 4))
                            m_streamWriter.WriteLine("0")
                        End If

                    Next i
                Next j
                For i = 0 To surf.GetUpperBound(0) Step meshstep
                    For j = 1 To surf.GetUpperBound(1)
                        If surf(i, j) <> blankvalue Or surf(i, j - 1) <> blankvalue Then
                            m_streamWriter.WriteLine(line)
                            m_streamWriter.WriteLine("8")
                            m_streamWriter.WriteLine("1")
                            m_streamWriter.WriteLine("62")
                            m_streamWriter.WriteLine(absColorSelect(surf(i, j), targsurf(i, j), dtol, dmax))
                            m_streamWriter.WriteLine("10")
                            m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                            m_streamWriter.WriteLine("20")
                            m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                            m_streamWriter.WriteLine("30")
                            m_streamWriter.WriteLine(Math.Round(surf(i, j), 4))
                            m_streamWriter.WriteLine("11")
                            m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                            m_streamWriter.WriteLine("21")
                            m_streamWriter.WriteLine(Math.Round(getylocation(j - 1, meshsize, pad, min_y), 4))
                            m_streamWriter.WriteLine("31")
                            m_streamWriter.WriteLine(Math.Round(surf(i, j - 1), 4))
                            m_streamWriter.WriteLine("0")

                        End If
                    Next j
                Next i

                m_streamWriter.WriteLine(footer1)
                m_streamWriter.WriteLine("0")
                m_streamWriter.WriteLine(footer3)

                'm_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin)


                ' Close the file
                m_streamWriter.Flush()
                m_streamWriter.Close()
            Catch em As Exception
                MessageBox.Show(em.Message.ToString & " in sub:dxffile.dxfsave1")
            End Try

        End Sub
        Function relativeColorSelect(ByVal value As Double, ByVal average As Double, ByVal stdDev As Double _
                                    , ByVal min As Double, ByVal max As Double) As Integer


            Dim colorStepSize As Double = stdDev / 3
            If stdDev = 0 Then relativeColorSelect = green

            If value <= average - 2 * colorStepSize Then
                relativeColorSelect = magenta
            ElseIf average - 2 * colorStepSize < value And value <= average - colorStepSize Then
                relativeColorSelect = blue
            ElseIf average - colorStepSize < value And value <= average Then
                relativeColorSelect = cyan
            ElseIf average < value And value <= average + colorStepSize Then
                relativeColorSelect = green
            ElseIf average + colorStepSize < value And value <= average + 2 * colorStepSize Then
                relativeColorSelect = yellow
            Else
                relativeColorSelect = red
            End If

        End Function
        Public Sub dxfsave(ByVal DXFFileName As String, ByVal surf(,) As Double, _
                           ByVal meshstep As Integer, ByVal meshsize As Double, ByVal pad As Double, _
                           ByVal min_x As Double, ByVal min_y As Double)
            Try
                ' get the file name to save the list view information in from the standard save dialog
                ' open a stream for writing and create a StreamWriter to use to implement the stream
                Dim fs As New FileStream(DXFFileName, FileMode.Create, FileAccess.Write)
                Dim m_streamWriter As New StreamWriter(fs)
                Dim i, j, sizexarray, sizeyarray, c As Integer
                Dim x, y, z, xp, yp, zp, xpp, ypp, zpp, tz As Double
                Dim arrayAverage, arrayStdDev, arrayMin, arrayMax As Double
                arrayStats(surf, arrayAverage, arrayStdDev, arrayMin, arrayMax)
                m_streamWriter.Flush()

                ' Write to the file using StreamWriter class

                m_streamWriter.WriteLine("0")
                m_streamWriter.WriteLine(header2)
                m_streamWriter.WriteLine("2")
                m_streamWriter.WriteLine(header4)
                m_streamWriter.WriteLine("0")
                'xline segments

                For j = 0 To surf.GetUpperBound(1) Step meshstep
                    For i = 1 To surf.GetUpperBound(0)


                        m_streamWriter.WriteLine(line)
                        m_streamWriter.WriteLine("8")
                        m_streamWriter.WriteLine("1")
                        m_streamWriter.WriteLine("62")
                        m_streamWriter.WriteLine(relativeColorSelect(surf(i, j), arrayAverage, arrayStdDev, arrayMin, arrayMax))
                        m_streamWriter.WriteLine("10")
                        m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                        m_streamWriter.WriteLine("20")
                        m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                        m_streamWriter.WriteLine("30")
                        m_streamWriter.WriteLine(Math.Round(surf(i, j), 4))
                        m_streamWriter.WriteLine("11")
                        m_streamWriter.WriteLine(Math.Round(getxlocation(i - 1, meshsize, pad, min_x), 4))
                        m_streamWriter.WriteLine("21")
                        m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                        m_streamWriter.WriteLine("31")
                        m_streamWriter.WriteLine(Math.Round(surf(i - 1, j), 4))
                        m_streamWriter.WriteLine("0")

                    Next i
                Next j
                For i = 0 To surf.GetUpperBound(0) Step meshstep
                    For j = 1 To surf.GetUpperBound(1)
                        m_streamWriter.WriteLine(line)
                        m_streamWriter.WriteLine("8")
                        m_streamWriter.WriteLine("1")
                        m_streamWriter.WriteLine("62")
                        m_streamWriter.WriteLine(relativeColorSelect(surf(i, j), arrayAverage, arrayStdDev, arrayMin, arrayMax))
                        m_streamWriter.WriteLine("10")
                        m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                        m_streamWriter.WriteLine("20")
                        m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                        m_streamWriter.WriteLine("30")
                        m_streamWriter.WriteLine(Math.Round(surf(i, j), 4))
                        m_streamWriter.WriteLine("11")
                        m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                        m_streamWriter.WriteLine("21")
                        m_streamWriter.WriteLine(Math.Round(getylocation(j - 1, meshsize, pad, min_y), 4))
                        m_streamWriter.WriteLine("31")
                        m_streamWriter.WriteLine(Math.Round(surf(i, j - 1), 4))
                        m_streamWriter.WriteLine("0")
                    Next j
                Next i

                m_streamWriter.WriteLine(footer1)
                m_streamWriter.WriteLine("0")
                m_streamWriter.WriteLine(footer3)

                'm_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin)


                ' Close the file
                m_streamWriter.Flush()
                m_streamWriter.Close()
            Catch em As Exception
                MessageBox.Show(em.Message.ToString & " in sub:dxffile.dxfsave2")
            End Try

        End Sub 'dxfsave
        Public Sub dxfsave(ByVal DXFFileName As String, ByVal surf(,) As Single, _
                                   ByVal meshstep As Integer, ByVal meshsize As Double, ByVal pad As Double, _
                                   ByVal min_x As Double, ByVal min_y As Double)
            Try
                ' get the file name to save the list view information in from the standard save dialog
                ' open a stream for writing and create a StreamWriter to use to implement the stream
                Dim fs As New FileStream(DXFFileName, FileMode.Create, FileAccess.Write)
                Dim m_streamWriter As New StreamWriter(fs)
                Dim i, j, sizexarray, sizeyarray, c As Integer
                Dim x, y, z, xp, yp, zp, xpp, ypp, zpp, tz As Double
                Dim arrayAverage, arrayStdDev, arrayMin, arrayMax As Double
                arrayStats(surf, arrayAverage, arrayStdDev, arrayMin, arrayMax)
                m_streamWriter.Flush()

                ' Write to the file using StreamWriter class

                m_streamWriter.WriteLine("0")
                m_streamWriter.WriteLine(header2)
                m_streamWriter.WriteLine("2")
                m_streamWriter.WriteLine(header4)
                m_streamWriter.WriteLine("0")
                'xline segments

                For j = 0 To surf.GetUpperBound(1) Step meshstep
                    For i = 1 To surf.GetUpperBound(0)


                        m_streamWriter.WriteLine(line)
                        m_streamWriter.WriteLine("8")
                        m_streamWriter.WriteLine("1")
                        m_streamWriter.WriteLine("62")
                        m_streamWriter.WriteLine(relativeColorSelect(surf(i, j), arrayAverage, arrayStdDev, arrayMin, arrayMax))
                        m_streamWriter.WriteLine("10")
                        m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                        m_streamWriter.WriteLine("20")
                        m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                        m_streamWriter.WriteLine("30")
                        m_streamWriter.WriteLine(Math.Round(surf(i, j), 4))
                        m_streamWriter.WriteLine("11")
                        m_streamWriter.WriteLine(Math.Round(getxlocation(i - 1, meshsize, pad, min_x), 4))
                        m_streamWriter.WriteLine("21")
                        m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                        m_streamWriter.WriteLine("31")
                        m_streamWriter.WriteLine(Math.Round(surf(i - 1, j), 4))
                        m_streamWriter.WriteLine("0")

                    Next i
                Next j
                For i = 0 To surf.GetUpperBound(0) Step meshstep
                    For j = 1 To surf.GetUpperBound(1)
                        m_streamWriter.WriteLine(line)
                        m_streamWriter.WriteLine("8")
                        m_streamWriter.WriteLine("1")
                        m_streamWriter.WriteLine("62")
                        m_streamWriter.WriteLine(relativeColorSelect(surf(i, j), arrayAverage, arrayStdDev, arrayMin, arrayMax))
                        m_streamWriter.WriteLine("10")
                        m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                        m_streamWriter.WriteLine("20")
                        m_streamWriter.WriteLine(Math.Round(getylocation(j, meshsize, pad, min_y), 4))
                        m_streamWriter.WriteLine("30")
                        m_streamWriter.WriteLine(Math.Round(surf(i, j), 4))
                        m_streamWriter.WriteLine("11")
                        m_streamWriter.WriteLine(Math.Round(getxlocation(i, meshsize, pad, min_x), 4))
                        m_streamWriter.WriteLine("21")
                        m_streamWriter.WriteLine(Math.Round(getylocation(j - 1, meshsize, pad, min_y), 4))
                        m_streamWriter.WriteLine("31")
                        m_streamWriter.WriteLine(Math.Round(surf(i, j - 1), 4))
                        m_streamWriter.WriteLine("0")
                    Next j
                Next i

                m_streamWriter.WriteLine(footer1)
                m_streamWriter.WriteLine("0")
                m_streamWriter.WriteLine(footer3)

                'm_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin)


                ' Close the file
                m_streamWriter.Flush()
                m_streamWriter.Close()
            Catch em As Exception
                MessageBox.Show(em.Message.ToString & " in sub:dxffile.dxfsave2")
            End Try

        End Sub 'dxfsave

        Sub dxflinenumbers(ByVal dxffilename As String)
            Try
                Dim fs As New FileStream(dxffilename, FileMode.Create, FileAccess.Write)
                Dim m_streamWriter As New StreamWriter(fs)
                Dim i, j, textcolor, layer As Integer
                Dim xydist, mindist As Double
                layer = 10
                mindist = 0.005
                m_streamWriter.Flush()
                ' Write to the file using StreamWriter class
                m_streamWriter.WriteLine("0")
                m_streamWriter.WriteLine(header2)
                m_streamWriter.WriteLine("2")
                m_streamWriter.WriteLine(header4)
                m_streamWriter.WriteLine("0")
                For i = 0 To nc.Length - 1
                    If i = 0 Then
                        textcolor = green
                    ElseIf i = nc.Length - 1 Then
                        textcolor = cyan
                    Else
                        textcolor = blue
                    End If

                    If nc(i).xydist >= mindist And nc(i).n <> 0 Then
                        m_streamWriter.WriteLine(text)
                        m_streamWriter.WriteLine("8")
                        m_streamWriter.WriteLine(layer)
                        m_streamWriter.WriteLine("62")
                        m_streamWriter.WriteLine(textcolor)
                        m_streamWriter.WriteLine("10")
                        m_streamWriter.WriteLine(nc(i).x - (ccomp * 0.5))
                        m_streamWriter.WriteLine("20")
                        m_streamWriter.WriteLine(nc(i).y - (ccomp * 0.3))
                        m_streamWriter.WriteLine("30")
                        m_streamWriter.WriteLine("0")
                        m_streamWriter.WriteLine("40")
                        m_streamWriter.WriteLine(ccomp * 0.6)
                        m_streamWriter.WriteLine("1")
                        m_streamWriter.WriteLine("N" & nc(i).n)
                        m_streamWriter.WriteLine("0")
                    End If
                Next i
                m_streamWriter.WriteLine(footer1)
                m_streamWriter.WriteLine("0")
                m_streamWriter.WriteLine(footer3)

                'm_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin)


                ' Close the file
                m_streamWriter.Flush()
                m_streamWriter.Close()
            Catch em As Exception
                MessageBox.Show(em.Message.ToString & " sub:dxflinenumbers")
            End Try
        End Sub 'dxflinenumbers
    End Class 'dxffile
End Namespace