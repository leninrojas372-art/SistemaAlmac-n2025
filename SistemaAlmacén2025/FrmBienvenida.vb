Public Class FrmBienvenida
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Me.Hide()
        FrmAcceso.Show()
    End Sub
End Class
