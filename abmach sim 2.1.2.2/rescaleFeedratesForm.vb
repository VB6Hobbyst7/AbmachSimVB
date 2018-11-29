Public Class rescaleFeedratesForm

    
    Property changeRange As Boolean
    Property firstLine As Integer
    Property lastLine As Integer
    Property scaleFactor As Double
    Dim newFeedrate As Double

    Private Sub RadioButtonAllLines_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAllLines.CheckedChanged
        If RadioButtonAllLines.Checked Then
            changeRange = False
            TextBoxEndLineNum.Enabled = False
            TextBoxStartLineNum.Enabled = False
        End If


    End Sub

    Private Sub RadioButtonRange_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonRange.CheckedChanged
        If RadioButtonRange.Checked Then
            changeRange = True
            TextBoxEndLineNum.Enabled = True
            TextBoxStartLineNum.Enabled = True
        End If
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        If RadioButtonRange.Checked Then
            firstLine = CInt(TextBoxStartLineNum.Text)
            lastLine = CInt(TextBoxEndLineNum.Text)
        End If

        scaleFactor = CDbl(TextBoxScaleFactor.Text)

        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.Close()

    End Sub
End Class