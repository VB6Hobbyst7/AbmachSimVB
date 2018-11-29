Public Class ShiftProgForm
    Public xshift As Double
    Public yshift As Double
    Public zshift As Double
    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        xshift = CDbl(TextBoxX.Text)
        yshift = CDbl(TextBoxY.Text)
        zshift = CDbl(TextBoxZ.Text)
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
End Class