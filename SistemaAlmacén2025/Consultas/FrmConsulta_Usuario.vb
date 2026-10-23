''' <summary>
''' 4. CONSULTAS > Buscar usuario
''' Responde: "¿Qué materiales tiene esta persona?" (pestaña "Materiales que tiene ahora")
''' y muestra todo su historial de préstamos y salidas.
''' </summary>
Public Class FrmConsulta_Usuario

    Private Sub FrmConsulta_Usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarGrilla(DgvUsuarios)
        ConfigurarGrilla(DgvTiene)
        ConfigurarGrilla(DgvHistorial)
        BuscarUsuarios()
    End Sub

    Private Sub BuscarUsuarios()
        Try
            Dim datos As DataTable = ClsControl.BuscarUsuario(TxtBuscar.Text.Trim())
            MostrarEnGrilla(DgvUsuarios, datos)
            LblResumen.Text = datos.Rows.Count & " usuarios encontrados"
            If datos.Rows.Count = 0 Then LimpiarDetalle()
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub LimpiarDetalle()
        DgvTiene.DataSource = Nothing
        DgvHistorial.DataSource = Nothing
        TabTiene.Text = "Materiales que tiene ahora"
        TabHistorial.Text = "Historial completo"
    End Sub

    Private Sub CargarDetalleUsuario()
        If DgvUsuarios.CurrentRow Is Nothing Then
            LimpiarDetalle()
            Exit Sub
        End If
        Try
            Dim dni As String = DgvUsuarios.CurrentRow.Cells("DNI").Value.ToString().Trim()
            Dim nombre As String = DgvUsuarios.CurrentRow.Cells("Apellidos y nombres").Value.ToString().Trim()
            Dim tiene As DataTable = ClsControl.MaterialesDeUsuario(dni)
            MostrarEnGrilla(DgvTiene, tiene)
            TabTiene.Text = "Materiales que tiene ahora (" & SumarColumna(tiene, "Cantidad") & ")"

            Dim historial As DataTable = ClsControl.HistorialUsuario(dni)
            MostrarEnGrilla(DgvHistorial, historial)
            TabHistorial.Text = "Historial completo (" & historial.Rows.Count & ")"

            If tiene.Rows.Count = 0 Then
                LblResumen.Text = nombre & " no tiene materiales pendientes de devolución."
            Else
                ' CORREGIDO: Se reemplazó el filtro por "Préstamo" para usar directamente el conteo de registros (tiene.Rows.Count)
                LblResumen.Text = nombre & " tiene " & SumarColumna(tiene, "Cantidad") & " unidad(es) sin devolver en " &
                                  tiene.Rows.Count & " registro(s)."
            End If
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        BuscarUsuarios()
    End Sub

    Private Sub DgvUsuarios_SelectionChanged(sender As Object, e As EventArgs) Handles DgvUsuarios.SelectionChanged
        CargarDetalleUsuario()
    End Sub

    Private Sub Grillas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvTiene.CellFormatting, DgvHistorial.CellFormatting
        ResaltarAtrasados(CType(sender, DataGridView), e)
    End Sub

    'Imprime/exporta lo que se esté viendo en la pestaña inferior (o la lista de usuarios si no hay selección)
    Private Function GrillaParaImprimir(ByRef titulo As String) As DataGridView
        If DgvUsuarios.CurrentRow Is Nothing Then
            titulo = "Usuarios"
            Return DgvUsuarios
        End If
        Dim nombre As String = DgvUsuarios.CurrentRow.Cells("Apellidos y nombres").Value.ToString().Trim()
        If TabControl1.SelectedTab Is TabTiene Then
            titulo = "Materiales en poder de " & nombre
            Return DgvTiene
        End If
        titulo = "Historial de " & nombre
        Return DgvHistorial
    End Function

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Dim titulo As String = ""
        Dim dgv As DataGridView = GrillaParaImprimir(titulo)
        Dim subt As String = ""
        If DgvUsuarios.CurrentRow IsNot Nothing Then subt = "DNI: " & DgvUsuarios.CurrentRow.Cells("DNI").Value.ToString()
        ClsImpresionGrid.Imprimir(dgv, titulo, subt)
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Dim titulo As String = ""
        Dim dgv As DataGridView = GrillaParaImprimir(titulo)
        ExportarExcel(dgv, titulo.Replace(" ", "_"))
    End Sub

End Class