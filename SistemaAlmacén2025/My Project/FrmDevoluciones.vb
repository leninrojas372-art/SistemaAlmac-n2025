''' <summary>
''' 2. OPERACIONES > Devolución
''' Registrar la devolución cambia el préstamo de "Pendiente" a "Devuelto"
''' y regresa al stock todos sus materiales (lo hace la base de datos en una transacción).
''' </summary>
Public Class FrmDevoluciones
    Dim CDevoluciones As New ClsDevoluciones

    Private Sub FrmDevoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MiDataSet As New DataSet
        Try
            MiDataSet = CDevoluciones.CargarDevoluciones()
            DataGridView4.DataSource = MiDataSet.Tables(0)
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
            Exit Sub
        End Try

        DataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView4.AutoResizeColumns()
        DataGridView4.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        DataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        DataGridView4.AllowUserToAddRows = False
        DataGridView4.ReadOnly = True
        DataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    'Lo usan Control > Préstamos pendientes y Consultas > Buscar préstamo
    Public Sub CargarPrestamoParaDevolver(ByVal idPrestamo As String)
        LimpiarCampos()
        TxtIDPrestamo.Text = idPrestamo
        DtpFecha.Value = Date.Today
        TxtCondicion.Focus()
    End Sub

    'Texto con los materiales del préstamo, para confirmar antes de registrar
    Private Function ResumenPrestamo(ByVal idPrestamo As Integer) As String
        Dim det As DataTable = ClsControl.DetallePrestamo(idPrestamo)
        If det.Rows.Count = 0 Then Return "(sin materiales registrados)"
        Dim sb As New System.Text.StringBuilder
        For Each fila As DataRow In det.Rows
            sb.AppendLine("   • " & fila("Cantidad").ToString() & "  " & fila("Material").ToString())
        Next
        Return sb.ToString()
    End Function

    Private Sub BtnRegistrar01_Click(sender As Object, e As EventArgs) Handles BtnRegistrar01.Click
        Dim idPrestamo As Integer
        If Not EsEnteroPositivo(TxtIDPrestamo.Text, idPrestamo) Then
            MsgBox("Seleccione el préstamo a devolver (haga clic en ID Préstamo).", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim resumen As String
        Try
            resumen = ResumenPrestamo(idPrestamo)
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
            Exit Sub
        End Try

        If MsgBox("Se registrará la devolución del préstamo N° " & idPrestamo & ":" & vbCrLf & vbCrLf &
                  resumen & vbCrLf & "Todo este material volverá al stock. ¿Continuar?",
                  MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Confirmar devolución") = MsgBoxResult.No Then Exit Sub

        Dim Fecha As String = DtpFecha.Value.ToString("yyyyMMdd")
        Dim nuevoId As Integer = CDevoluciones.RegistrarDevoluciones(idPrestamo, Fecha, TxtCondicion.Text, TxtObservacion.Text)
        If nuevoId > 0 Then
            TxtIDDevoluciones.Text = nuevoId.ToString()
            MsgBox("Devolución N° " & nuevoId & " registrada correctamente." & vbCrLf &
                   "El préstamo quedó en estado DEVUELTO.", MsgBoxStyle.Information)
            FrmDevoluciones_Load(sender, e)
        End If
    End Sub

    Private Sub DataGridView4_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim fila As DataGridViewRow = DataGridView4.Rows(e.RowIndex)

        Try
            TxtIDDevoluciones.Text = fila.Cells(0).Value.ToString()
            TxtIDPrestamo.Text = fila.Cells(1).Value.ToString()
            If Not IsDBNull(fila.Cells(2).Value) Then DtpFecha.Value = Convert.ToDateTime(fila.Cells(2).Value)
            TxtCondicion.Text = fila.Cells(3).Value.ToString().Trim()
            TxtObservacion.Text = fila.Cells(4).Value.ToString().Trim()
        Catch ex As Exception
            ' Evita que falle si alguna celda viene vacía o fuera de rango
        End Try
    End Sub

    Private Sub BtnModificar01_Click(sender As Object, e As EventArgs) Handles BtnModificar01.Click
        If TxtIDDevoluciones.Text.Trim() = "" Then
            MsgBox("Seleccione una devolución de la lista.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim Fecha As String = DtpFecha.Value.ToString("yyyyMMdd")
        If CDevoluciones.ModificarDevoluciones(TxtIDDevoluciones.Text.Trim, TxtIDPrestamo.Text.Trim, Fecha, TxtCondicion.Text, TxtObservacion.Text) Then
            MsgBox("La devolución ha sido modificada correctamente", MsgBoxStyle.Information)
            FrmDevoluciones_Load(sender, e)
        End If
    End Sub

    Private Sub BtnEliminar01_Click(sender As Object, e As EventArgs) Handles BtnEliminar01.Click
        If TxtIDDevoluciones.Text.Trim() = "" Then
            MsgBox("Seleccione una devolución de la lista.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("¿Eliminar la devolución N° " & TxtIDDevoluciones.Text & "?" & vbCrLf &
                  "El préstamo volverá a quedar PENDIENTE y el material se descontará otra vez del stock.",
                  MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation) = MsgBoxResult.No Then Exit Sub

        If CDevoluciones.EliminarDevoluciones(TxtIDDevoluciones.Text.Trim) Then
            MsgBox("La devolución ha sido eliminada correctamente", MsgBoxStyle.Information)
            LimpiarCampos()
            FrmDevoluciones_Load(sender, e)
        End If
    End Sub

    Private Sub LimpiarCampos()
        TxtIDDevoluciones.Text = ""
        TxtIDPrestamo.Text = ""
        TxtCondicion.Text = ""
        TxtObservacion.Text = ""
        DtpFecha.Value = Date.Today
    End Sub

    Private Sub BtnNuevo01_Click(sender As Object, e As EventArgs) Handles BtnNuevo01.Click
        LimpiarCampos()
        TxtIDPrestamo.Focus()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Limpiamos los campos de texto directamente
        'boton cancelar

        LimpiarCampos()

    End Sub

    Private Sub Numeros(e)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtIDDevoluciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtIDDevoluciones.KeyPress
        Numeros(e)
    End Sub
    Private Sub TxtIDPrestamo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtIDPrestamo.KeyPress
        Numeros(e)
    End Sub
    Private Sub Letras(e As KeyPressEventArgs)
        If Char.IsPunctuation(e.KeyChar) AndAlso e.KeyChar <> "."c AndAlso e.KeyChar <> ","c Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtCondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCondicion.KeyPress
        Letras(e)
    End Sub
    Private Sub TxtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObservacion.KeyPress
        Letras(e)
    End Sub

    Private Sub TxtIDPrestamo_Click(sender As Object, e As EventArgs) Handles TxtIDPrestamo.Click
        FrmBuscarPrestamoParaDevoluciones.Show()
        FrmBuscarPrestamoParaDevoluciones.Activate()
    End Sub
End Class