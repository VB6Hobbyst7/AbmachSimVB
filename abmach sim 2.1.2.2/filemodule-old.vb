Namespace abmach
    Module filemodule
        Public Sub fillarray(ByRef arr_out(,) As Single, ByVal val_input(,) As Single, ByRef done As Boolean)
            Dim i, j As Integer
            Try
                If arr_out.GetUpperBound(1) = val_input.GetUpperBound(1) And arr_out.GetUpperBound(0) = val_input.GetUpperBound(0) Then
                    For i = 0 To arr_out.GetUpperBound(0)
                        For j = 0 To arr_out.GetUpperBound(1)
                            arr_out(i, j) = val_input(i, j)
                        Next j
                    Next i
                End If

            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & " sub fillarray w/double arr")
            End Try
            done = True
        End Sub
        Public Sub fillarray(ByRef arr_out(,) As Double, ByVal val_input(,) As Double, ByRef done As Boolean)
            Dim i, j As Integer
            Try
                If arr_out.GetUpperBound(1) = val_input.GetUpperBound(1) And arr_out.GetUpperBound(0) = val_input.GetUpperBound(0) Then
                    For i = 0 To arr_out.GetUpperBound(0)
                        For j = 0 To arr_out.GetUpperBound(1)
                            arr_out(i, j) = val_input(i, j)
                        Next j
                    Next i
                End If

            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & " sub fillarray w/double arr")
            End Try
            done = True
        End Sub
        Public Sub fillarray(ByRef arr_out(,) As Single, ByVal val_input As Double, ByRef done As Boolean)
            Dim i, j As Integer
            Try
                For i = 0 To arr_out.GetUpperBound(0)
                    For j = 0 To arr_out.GetUpperBound(1)
                        arr_out(i, j) = val_input

                    Next j
                Next i
            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & "sub fillarray w/integer const")
            End Try
            done = True
        End Sub
        Public Sub fillarray(ByRef arr_out(,) As Double, ByVal val_input As Double, ByRef done As Boolean)
            Dim i, j As Integer
            Try
                For i = 0 To arr_out.GetUpperBound(0)
                    For j = 0 To arr_out.GetUpperBound(1)
                        arr_out(i, j) = val_input

                    Next j
                Next i
            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & "sub fillarray w/integer const")
            End Try
            done = True
        End Sub
        Public Sub fillarray(ByRef arr_out(,) As Integer, ByVal val_input As Integer, ByRef done As Boolean)
            Dim i, j As Integer
            Try
                For i = 0 To arr_out.GetUpperBound(0)
                    For j = 0 To arr_out.GetUpperBound(1)
                        arr_out(i, j) = val_input

                    Next j
                Next i
            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & "sub fillarray w/integer const")
            End Try
            done = True
        End Sub
        Public Sub fillarray(ByRef arr_out(,) As Integer, ByVal val_input As Integer)
            Dim i, j As Integer
            Try
                For i = 0 To arr_out.GetUpperBound(0)
                    For j = 0 To arr_out.GetUpperBound(1)
                        arr_out(i, j) = val_input
                    Next j
                Next i
            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & "sub fillarray w/integer const")
            End Try
        End Sub
        Public Function minfeedratei(ByVal length As Integer) As Integer
            Dim minfeedrate As Double = 9.0E+20
            Dim i As Integer
            Try
                For i = 1 To length
                    If nc(i).f < minfeedrate Then
                        minfeedratei = i
                        minfeedrate = nc(i).f
                    End If
                Next

            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & "sub:minfeedratei")
            End Try

        End Function 'minfeedratei
        Public Function maxfeedratei(ByVal length As Integer) As Integer
            Dim maxfeedrate As Double = 0
            Dim i As Integer
            Try
                For i = 1 To length
                    If nc(i).f > maxfeedrate Then
                        maxfeedratei = i
                        maxfeedrate = nc(i).f
                    End If
                Next

            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & "sub:maxfeedratei")
            End Try

        End Function 'maxfeedratei

        Public Function maxdeltafeedratei(ByVal length As Integer) As Integer
            Dim maxdeltafeedrate As Double = 0
            Dim deltafeedrate As Double = 0
            Dim deltafound As Boolean = False
            Dim i As Integer
            Try
                For i = 2 To length
                    If nc(i).f <> 0 And nc(i - 1).f <> 0 Then
                        deltafeedrate = Math.Abs(nc(i).f - nc(i - 1).f)

                    Else
                        deltafeedrate = 0
                    End If

                    If deltafeedrate > maxdeltafeedrate Then
                        maxdeltafeedratei = i
                        maxdeltafeedrate = deltafeedrate
                    End If
                Next
                If maxdeltafeedrate = 0 Then maxdeltafeedratei = 0
            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & "sub:maxdeltafeedratei")
            End Try

        End Function 'maxfeedratei
        Public Function getshortfilename(ByVal filename As String) As String
            Dim l As Integer = filename.LastIndexOf("\")
            If l > 0 Then
                getshortfilename = filename.Substring(l + 1)
            Else
                getshortfilename = filename
            End If
        End Function
        Public Sub read_nc(ByRef nclines() As String, ByVal istartrow As Integer, ByVal ifirstrow As Integer, _
                        ByVal ilastrow As Integer, ByVal dynjeton As Boolean, ByRef vscaling As Boolean)        'read in nc file from textbox

            Dim a As Integer
            Dim b As Integer
            Dim comm As Boolean
            Try


                'Loop through the array 
                If dynjeton = False Then
                    parsenc(istartrow, nclines(istartrow), 0, comm, vscaling)
                    b = 1
                Else
                    b = 0
                End If

                comm = True
                For a = ifirstrow To ilastrow

                    parsenc(a, nclines(a), b, comm, vscaling)

                    If comm = False Then b += 1
                Next
                If dynjeton Then
                    parsenc(ifirstrow, nclines(ifirstrow), b, comm, vscaling)
                    If vscaling Then
                        parsenc(ifirstrow + 1, nclines(ifirstrow + 1), b, comm, vscaling)
                    End If
                End If

                ' Me.Richtextbox1.Lines = nclines
                If machinedata(machinenumber).arctype = 2 Then
                    For a = 0 To nc.GetUpperBound(0)
                        If nc(a).gcode = 2 Or nc(a).gcode = 3 Then
                            nc(a).ivalue = nc(a - 1).x + nc(a).ivalue
                            nc(a).jvalue = nc(a - 1).y + nc(a).jvalue
                        End If

                    Next a
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString() & " line:" & a & " sub:readnc")

            End Try

        End Sub
        Sub addspace(ByVal index As Integer, ByRef line As String)
            'fix add space so it doesn't add space to the N in END

            If index > 2 Then
                If line.Chars(index - 1) <> Chr(32) Then
                    line = line.Insert(index, " ")
                End If
            End If
        End Sub
        Private Function isComment(line As String) As Boolean
            Dim commentChars() As Char = {"(", ";", "/"}
            Dim result As Boolean
            For Each c As Char In commentChars
                If line.StartsWith(c) Then
                    result = True
                End If
            Next c

            Return result

        End Function
        ' parses one line of nc code and stores it into arrays
        Public Sub parsenc(ByVal linenumber As Integer, ByRef ncline As String, ByVal line As Integer, ByRef comment As Boolean, ByRef vscaling As Boolean)

            Dim splitncline(20), word As String
            Dim i As Integer
            word = ""

            Dim nindex, gindex, xindex, yindex, zindex, iindex, jindex, bindex, cindex, findex As Integer
            'Dim ncchars() As Char = {"N", "G", "X", "Y", "Z", "I", "J", "B", "C", "F"}
            Try
                If Not (ncline Is Nothing) Then
                    If isComment(ncline) Then
                        comment = True
                        nc(line).isComment = True

                    Else
                        ncline = ncline.Trim
                        ncline = ncline.ToUpper
                        nindex = ncline.IndexOf("N")
                        'addspace(nindex, ncline)
                        gindex = ncline.IndexOf("G")
                        addspace(gindex, ncline)
                        xindex = ncline.IndexOf("X")
                        addspace(xindex, ncline)
                        yindex = ncline.IndexOf("Y")
                        addspace(yindex, ncline)
                        zindex = ncline.IndexOf("Z")
                        addspace(zindex, ncline)
                        iindex = ncline.IndexOf("I")
                        addspace(iindex, ncline)
                        jindex = ncline.IndexOf("J")
                        addspace(jindex, ncline)
                        bindex = ncline.IndexOf("B")
                        addspace(bindex, ncline)
                        cindex = ncline.IndexOf("C")
                        If Not (ncline.Substring(cindex + 1).StartsWith("*")) Then
                            addspace(cindex, ncline)
                        End If

                        findex = ncline.IndexOf("F")
                        addspace(findex, ncline)

                        splitncline = Split(ncline)

                        For i = splitncline.GetLowerBound(0) To splitncline.GetUpperBound(0)
                            word = splitncline(i)
                            word = word.Trim
                            word = word.ToUpper

                            If word <> "" Then
                                nc(line).l = linenumber

                                If word.StartsWith("N") Then
                                    nc(line).n = CInt(word.Substring(word.IndexOf("N") + 1))
                                    nc(line).npos = ncline.IndexOf("N") + 1
                                ElseIf word.StartsWith("G") Then
                                    nc(line).gpos = ncline.IndexOf("G") + 1
                                    nc(line).glen = word.Length
                                    comment = False
                                    If word.Equals("G00") Or word.Equals("G0") Then
                                        nc(line).gcode = 0
                                    ElseIf word.Equals("G01") Or word.Equals("G1") Then
                                        nc(line).gcode = 1
                                    ElseIf word.Equals("G02") Or word.Equals("G2") Then
                                        nc(line).gcode = 2
                                    ElseIf word.Equals("G03") Or word.Equals("G3") Then
                                        nc(line).gcode = 3
                                    End If
                                ElseIf word.StartsWith("X") Then
                                    comment = False
                                    nc(line).x = CDbl(word.Substring(word.IndexOf("X") + 1))
                                    nc(line).xpos = ncline.IndexOf("X") + 1
                                    nc(line).xlen = word.Length
                                ElseIf word.StartsWith("Y") Then
                                    comment = False
                                    nc(line).y = CDbl(word.Substring(word.IndexOf("Y") + 1))
                                    nc(line).ypos = ncline.IndexOf("Y") + 1
                                    nc(line).ylen = word.Length
                                ElseIf word.StartsWith("Z") Then
                                    comment = False
                                    nc(line).z = CDbl(word.Substring(word.IndexOf("Z") + 1))
                                    nc(line).zpos = ncline.IndexOf("Z") + 1
                                    nc(line).zlen = word.Length
                                ElseIf word.StartsWith("B") Then
                                    comment = False
                                    nc(line).bvalue = CDbl(word.Substring(word.IndexOf("B") + 1)) - machinedata(machinenumber).b0
                                    nc(line).bpos = ncline.IndexOf("B") + 1
                                    nc(line).blen = word.Length
                                ElseIf word.StartsWith("C") Then
                                    comment = False
                                    nc(line).cvalue = CDbl(word.Substring(word.IndexOf("C") + 1)) - machinedata(machinenumber).c0
                                    nc(line).cpos = ncline.IndexOf("C") + 1
                                    nc(line).clen = word.Length
                                ElseIf word.StartsWith("I") Then
                                    comment = False
                                    nc(line).ivalue = CDbl(word.Substring(word.IndexOf("I") + 1))
                                    nc(line).ipos = ncline.IndexOf("I") + 1
                                    nc(line).ilen = word.Length
                                ElseIf word.StartsWith("J") Then
                                    comment = False
                                    nc(line).jvalue = CDbl(word.Substring(word.IndexOf("J") + 1))
                                    nc(line).jpos = word.IndexOf("J") + 1
                                    nc(line).jlen = word.Length
                                ElseIf word.StartsWith("F") And Not (word.Equals("F(!V)")) Then
                                    comment = False
                                    nc(line).f = CDbl(word.Substring(word.IndexOf("F") + 1))
                                    nc(line).fpos = ncline.IndexOf("F") + 1
                                    nc(line).fline = linenumber
                                    nc(line).flen = ncline.Substring(ncline.IndexOf("F") + 1).Length

                                ElseIf word.Equals("!V=!VSC*") Or word.StartsWith("!V=!VSC*") Then
                                    Dim tempword As String = ncline.Substring(ncline.IndexOf("*") + 1)
                                    nc(line).f = CDbl(tempword.Trim)
                                    comment = True
                                    nc(line).fpos = ncline.IndexOf("*") + 1
                                    nc(line).fline = linenumber
                                    nc(line).flen = ncline.Substring(ncline.IndexOf("*") + 1).Length
                                    vscaling = True
                                End If
                            End If
                        Next i
                    End If
                End If

            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString() & " ncline:" & line & word & "sub:parsenc")
            End Try

        End Sub
    End Module
End Namespace