Imports System.Data.SqlClient

''' <summary>
''' 2. OPERACIONES > Préstamo
''' Usuario → Solicitud → Préstamo. El préstamo queda en estado "Pendiente" y cada
''' material se descuenta del stock hasta que se registre la devolución.
''' </summary>
Public Class FrmPrestamo

    Dim CPrestamo As New ClsPrestamo

    Private Sub BtnCargarLista_Click(sender As Object, e As EventArgs) Handles btnCargarLista.Click
        Dim idMaterial, cantidad As Integer
        If Not EsEnteroPositivo(TxtIdMaterial.Text, idMaterial) Then
            MsgBox("Seleccione un material (haga clic en ID Material).", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Not EsEnteroPositivo(TxtCantidad.Text, cantidad) Then
            MsgBox("Ingrese una cantidad mayor a 0.", MsgBoxStyle.Exclamation)
            TxtCantidad.Focus()
            Exit Sub
        End If

        Dim material As DataRow
        Try
            material = ClsControl.ObtenerMaterial(idMaterial)
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
            Exit Sub
        End Try
        If material Is Nothing Then
            MsgBox("El material con ID " & idMaterial & " no existe.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'Cantidad que ya está en la lista para este material
        Dim filaExistente As DataGridViewRow = Nothing
        Dim yaEnLista As Integer = 0
        For Each row As DataGridViewRow In DataGridView_01.Rows
            If row.IsNewRow Then Continue For
            If CInt(row.Cells(2).Value) = idMaterial Then
                filaExistente = row
                yaEnLista = CInt(row.Cells(3).Value)
            End If
        Next

        Dim stock As Integer = CInt(material("Stock"))
        If yaEnLista + cantidad > stock Then
            MsgBox("Stock insuficiente para " & material("Nombre").ToString() & "." & vbCrLf &
                   "Disponible: " & stock & "   |   Ya en la lista: " & yaEnLista & "   |   Solicitado: " & cantidad,
                   MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'Los materiales fungibles se consumen: normalmente van por Salida, no por Préstamo
        If material("Estado").ToString().ToUpper() = "FUNGIBLES" AndAlso filaExistente Is Nothing Then
            If MsgBox(material("Nombre").ToString() & " es un material FUNGIBLE (se consume)." & vbCrLf &
                      "Normalmente debería registrarse como SALIDA." & vbCrLf & vbCrLf &
                      "¿Desea agregarlo al préstamo de todos modos?",
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        End If

        If filaExistente IsNot Nothing Then
            filaExistente.Cells(3).Value = yaEnLista + cantidad
        Else
            DataGridView_01.Rows.Add(
                (DataGridView_01.Rows.Count + 1).ToString(),
                TxtId_Prestamo.Text,
                idMaterial.ToString(),
                cantidad.ToString())
        End If
        Limpiar()
    End Sub

    Private Sub BtnAgregarDetalle_Click(sender As Object, e As EventArgs) Handles BtnAgregarDetalle.Click
        TxtId_Prestamo.Text = TxtIdPrestamo.Text
        TxtIdDetallePrestamo.Text = DataGridView_01.RowCount.ToString

        GroupBox1.Enabled = False
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        TxtIdDetallePrestamo.Text = DataGridView_01.RowCount.ToString()
        Limpiar()
    End Sub

    Public Sub Limpiar()
        TxtIdMaterial.Text = ""
        TxtCantidad.Text = ""
    End Sub

    Private Sub TxtId_Solicitud_Click(sender As Object, e As EventArgs) Handles TxtId_Solicitud.Click
        FrmBuscarSolicitudParaPrestamo.MdiParent = FrmPrincipal
        FrmBuscarSolicitudParaPrestamo.Show()
    End Sub

    Private Sub BtnRegistrarPrestamo_Click(sender As Object, e As EventArgs) Handles BtnRegistrarPrestamo.Click
        Dim idSolicitud As Integer
        If Not EsEnteroPositivo(TxtId_Solicitud.Text, idSolicitud) Then
            MsgBox("Seleccione la solicitud del usuario (haga clic en ID Solicitud).", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If TxtDNI_Usuario.Text.Trim() = "" Then
            MsgBox("Seleccione el personal que atiende el préstamo.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim detalles As New List(Of ClsItemDetalle)
        For Each row As DataGridViewRow In DataGridView_01.Rows
            If row.IsNewRow Then Continue For
            detalles.Add(New ClsItemDetalle(CInt(row.Cells(2).Value), CInt(row.Cells(3).Value)))
        Next
        If detalles.Count = 0 Then
            MsgBox("Agregue al menos un material a la lista.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            Dim nuevoId As Integer = CPrestamo.RegistrarPrestamoCompleto(
                TxtDNI_Usuario.Text.Trim(), idSolicitud, DateTimePicker1.Value.Date, detalles)

            MsgBox("Préstamo N° " & nuevoId & " registrado exitosamente." & vbCrLf &
                   "Estado: PENDIENTE (hasta que se registre la devolución)." & vbCrLf &
                   "El stock de los materiales fue actualizado.", MsgBoxStyle.Information)
            FrmPrestamo_Load(sender, e)
        Catch ex As Exception
            'Si falla (por ejemplo, sin stock) no se guarda nada
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub LimpiarControles()
        TxtIdPrestamo.Text = ""
        TxtId_Solicitud.Text = ""
        TxtDNI_Usuario.Text = ModSesion.DNIPersonal   'por defecto atiende quien inició sesión
        TxtIdDetallePrestamo.Text = ""
        TxtIdMaterial.Text = ""
        TxtId_Prestamo.Text = ""
        TxtCantidad.Text = ""
        DataGridView_01.Rows.Clear()
        DateTimePicker1.Value = Date.Today
        GroupBox1.Enabled = True
    End Sub
    Private Sub FrmPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LimpiarControles()
        DataGridView_01.AllowUserToAddRows = False
    End Sub

    Private Sub TxtDNI_Usuario_Click(sender As Object, e As EventArgs) Handles TxtDNI_Usuario.Click
        FrmBuscarPersonalParaPrestamo.Show()
    End Sub

    Private Sub TxtIdMaterial_Click(sender As Object, e As EventArgs) Handles TxtIdMaterial.Click
        FrmBuscarMaterialParaPrestamo.Show()
    End Sub

    'Quitar un material de la lista con la tecla Supr
    Private Sub DataGridView_01_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView_01.KeyDown
        If e.KeyCode = Keys.Delete AndAlso DataGridView_01.CurrentRow IsNot Nothing Then
            DataGridView_01.Rows.Remove(DataGridView_01.CurrentRow)
            e.Handled = True
        End If
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
    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidad.KeyPress
        Numeros(e)
    End Sub

    '---------------- Cargar los materiales pedidos en la solicitud ----------------
    Private Sub TxtId_Solicitud_TextChanged(sender As Object, e As EventArgs) Handles TxtId_Solicitud.TextChanged
        CargarDesdeSolicitud()
    End Sub

    Private Sub CargarDesdeSolicitud()
        Dim idSol As Integer
        If Not EsEnteroPositivo(TxtId_Solicitud.Text, idSol) Then Exit Sub
        Try
            Dim sol As DataRow = ClsControl.ObtenerSolicitud(idSol)
            If sol Is Nothing Then Exit Sub
            Dim estado As String = sol("Estado").ToString()
            Dim usuario As String = sol("Usuario").ToString()

            If estado = "Anulada" Then
                MsgBox("La solicitud N° " & idSol & " está ANULADA y no se puede atender.", MsgBoxStyle.Exclamation)
                TxtId_Solicitud.Text = ""
                Exit Sub
            End If
            If estado = "Atendida" Then
                If MsgBox("La solicitud N° " & idSol & " ya fue ATENDIDA." & vbCrLf & "¿Desea registrar un préstamo adicional para esta solicitud?",
                          MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then
                    TxtId_Solicitud.Text = ""
                    Exit Sub
                End If
            End If

            Dim det As DataTable = ClsControl.DetalleSolicitud(idSol)
            If det.Rows.Count = 0 Then Exit Sub   'solicitud antigua sin detalle: se agregan los materiales a mano

            If DataGridView_01.Rows.Count > 0 AndAlso
               MsgBox("¿Reemplazar la lista actual con los materiales de la solicitud N° " & idSol & "?",
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub

            DataGridView_01.Rows.Clear()
            Dim avisos As New List(Of String)
            For Each d As DataRow In det.Rows
                Dim pedido As Integer = CInt(d("Cantidad"))
                Dim stock As Integer = CInt(d("Stock"))
                Dim aEntregar As Integer = Math.Min(pedido, stock)
                If aEntregar < pedido Then
                    avisos.Add("• " & d("Material").ToString() & ": pidió " & pedido & ", hay " & stock)
                End If
                If aEntregar > 0 Then
                    DataGridView_01.Rows.Add((DataGridView_01.Rows.Count + 1).ToString(), TxtId_Prestamo.Text, d("IDMaterial").ToString(), aEntregar.ToString())
                End If
            Next

            Dim msg As String = "Se cargaron los materiales de la solicitud N° " & idSol & " (" & usuario & ")." & vbCrLf &
                                "Puede quitar materiales (tecla Supr) o agregar otros antes de registrar."
            If avisos.Count > 0 Then
                msg &= vbCrLf & vbCrLf & "Stock insuficiente, se cargó solo lo disponible:" & vbCrLf & String.Join(vbCrLf, avisos)
            End If
            MsgBox(msg, If(avisos.Count > 0, MsgBoxStyle.Exclamation, MsgBoxStyle.Information))
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

End Class
