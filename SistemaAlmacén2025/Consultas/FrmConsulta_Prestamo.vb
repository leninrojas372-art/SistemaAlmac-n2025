''' <summary>
''' 4. CONSULTAS > Buscar préstamo
''' Busca por N° de préstamo, DNI, nombre del usuario o nombre de material,
''' con filtro de estado (Todos / Pendiente / Devuelto).
''' Buscando un material con estado "Pendiente" se responde: "¿Quién tiene este material?"
''' </summary>
Public Class FrmConsulta_Prestamo

    Private listo As Boolean = False

    Private Sub FrmConsulta_Prestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarGrilla(DgvPrestamos)
        ConfigurarGrilla(DgvDetalle)
        CmbEstado.Items.AddRange(New Object() {"Todos", "Pendiente", "Devuelto"})
        CmbEstado.SelectedIndex = 0
        listo = True
        Buscar()
    End Sub

    Private Function EstadoSeleccionado() As String
        If CmbEstado.SelectedIndex <= 0 Then Return ""
        Return CmbEstado.Text
    End Function

    Private Sub Buscar()
        If Not listo Then Exit Sub
        Try
            Dim datos As DataTable = ClsControl.BuscarPrestamo(TxtBuscar.Text.Trim(), EstadoSeleccionado())
            MostrarEnGrilla(DgvPrestamos, datos)
            Dim pendientes As Integer = datos.Select("Estado = 'Pendiente'").Length
            LblResumen.Text = datos.Rows.Count & " préstamos  |  Pendientes: " & pendientes &
                              "  |  Devueltos: " & (datos.Rows.Count - pendientes)
            If datos.Rows.Count = 0 Then DgvDetalle.DataSource = Nothing
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Function PrestamoSeleccionado() As Integer
        If DgvPrestamos.CurrentRow Is Nothing OrElse Not DgvPrestamos.Columns.Contains("Préstamo") Then Return 0
        Dim v As Object = DgvPrestamos.CurrentRow.Cells("Préstamo").Value
        If v Is Nothing OrElse IsDBNull(v) Then Return 0
        Return CInt(v)
    End Function

    Private Sub DgvPrestamos_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPrestamos.SelectionChanged
        Dim id As Integer = PrestamoSeleccionado()
        If id = 0 Then
            DgvDetalle.DataSource = Nothing
            Exit Sub
        End If
        Try
            MostrarEnGrilla(DgvDetalle, ClsControl.DetallePrestamo(id))
            Dim estado As String = DgvPrestamos.CurrentRow.Cells("Estado").Value.ToString()
            GrpDetalle.Text = "Materiales del préstamo N° " & id & "  (" & estado & ")"
            BtnDevolver.Enabled = (estado = "Pendiente")
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        Buscar()
    End Sub

    Private Sub CmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEstado.SelectedIndexChanged
        Buscar()
    End Sub

    Private Sub DgvPrestamos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvPrestamos.CellFormatting
        If e.RowIndex < 0 OrElse Not DgvPrestamos.Columns.Contains("Estado") Then Exit Sub
        Dim est As Object = DgvPrestamos.Rows(e.RowIndex).Cells("Estado").Value
        If est IsNot Nothing AndAlso est.ToString() = "Pendiente" Then
            e.CellStyle.ForeColor = Color.DarkRed
        End If
    End Sub

    Private Sub BtnDevolver_Click(sender As Object, e As EventArgs) Handles BtnDevolver.Click
        Dim id As Integer = PrestamoSeleccionado()
        If id = 0 Then
            MsgBox("Seleccione un préstamo pendiente.", MsgBoxStyle.Information)
            Exit Sub
        End If
        FrmDevoluciones.MdiParent = Me.MdiParent
        FrmDevoluciones.Show()
        FrmDevoluciones.CargarPrestamoParaDevolver(id.ToString())
        FrmDevoluciones.Activate()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Dim subt As String = "Estado: " & CmbEstado.Text
        If TxtBuscar.Text.Trim() <> "" Then subt &= "   |   Búsqueda: " & TxtBuscar.Text.Trim()
        ClsImpresionGrid.Imprimir(DgvPrestamos, "Préstamos", subt)
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        ExportarExcel(DgvPrestamos, "Prestamos")
    End Sub

    'Al volver a esta ventana (por ejemplo, después de registrar una devolución) se refresca
    Private Sub FrmConsulta_Prestamo_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Buscar()
    End Sub

End Class
