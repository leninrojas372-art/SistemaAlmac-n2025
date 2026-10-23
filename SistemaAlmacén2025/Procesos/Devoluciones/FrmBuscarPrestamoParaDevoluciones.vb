''' <summary>
''' Buscador para Devoluciones: muestra SOLO los préstamos pendientes,
''' con el usuario y los materiales que tiene.
''' </summary>
Public Class FrmBuscarPrestamoParaDevoluciones

    Private Sub FrmBuscarIPPrestamoPara(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarGrilla(DataGridView1)
        Cargar()
    End Sub

    Private Sub Cargar()
        Try
            MostrarEnGrilla(DataGridView1, ClsControl.PrestamosPendientes(TxtID_Prestamo.Text.Trim()))
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub TxtID_Material_TextChanged(sender As Object, e As EventArgs) Handles TxtID_Prestamo.TextChanged
        Cargar()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then

            FrmDevoluciones.CargarPrestamoParaDevolver(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
            Me.Close()
        End If
    End Sub
End Class