Imports System.Data.SqlClient

''' <summary>
''' 2. OPERACIONES > Salida
''' Usuario/Área → Solicitud → Salida. Es una entrega definitiva:
''' se descuenta del stock y no se espera devolución.
''' </summary>
Public Class FrmSalidas

    Dim CSalidas As New ClsSalida

    Private Sub btncargar_salida_Click(sender As Object, e As EventArgs) Handles btncargar_salida.Click
        Dim idMaterial, cantidad As Integer
        If Not EsEnteroPositivo(TxtIdMaterial_1.Text, idMaterial) Then
            MsgBox("Seleccione un material (haga clic en ID Material).", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Not EsEnteroPositivo(TxtCantidad1.Text, cantidad) Then
            MsgBox("Ingrese una cantidad mayor a 0.", MsgBoxStyle.Exclamation)
            TxtCantidad1.Focus()
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

        Dim filaExistente As DataGridViewRow = Nothing
        Dim yaEnLista As Integer = 0
        For Each row As DataGridViewRow In DataGridView02.Rows
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

        'Las herramientas (no fungibles) normalmente se prestan, no se entregan definitivamente
        If material("Estado").ToString().ToUpper() = "NO FUNGIBLES" AndAlso filaExistente Is Nothing Then
            If MsgBox(material("Nombre").ToString() & " es un material NO FUNGIBLE." & vbCrLf &
                      "Normalmente debería registrarse como PRÉSTAMO (para que sea devuelto)." & vbCrLf & vbCrLf &
                      "¿Desea registrarlo como salida definitiva de todos modos?",
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        End If

        If filaExistente IsNot Nothing Then
            filaExistente.Cells(3).Value = yaEnLista + cantidad
        Else
            DataGridView02.Rows.Add((DataGridView02.Rows.Count + 1).ToString(),
                                    Txt_Salida.Text,
                                    idMaterial.ToString(),
                                    cantidad.ToString())
        End If
        Limpiar()
    End Sub

    Private Sub btnagregar_detallesalida_Click(sender As Object, e As EventArgs) Handles btnagregar_detallesalida.Click
        Txt_Salida.Text = txtsalida.Text
        TxtIdDetalleSalida.Text = (DataGridView02.RowCount + 1).ToString()
        GroupBox1.Enabled = False
    End Sub

    Private Sub Btn_siguiente_Click(sender As Object, e As EventArgs) Handles Btn_siguiente.Click
        TxtIdDetalleSalida.Text = (DataGridView02.RowCount + 1).ToString()
        Limpiar()
    End Sub

    Public Sub Limpiar()
        TxtIdMaterial_1.Text = ""
        TxtCantidad1.Text = ""
    End Sub

    Private Sub txtid_solicitud_Click(sender As Object, e As EventArgs) Handles txtid_solicitud.Click
        FrmBuscarSolicitudParaSalida.MdiParent = FrmPrincipal
        FrmBuscarSolicitudParaSalida.Show()
    End Sub

    Private Sub btnregistrar_salida_Click(sender As Object, e As EventArgs) Handles btnregistrar_salida.Click
        Dim idSolicitud As Integer
        If Not EsEnteroPositivo(txtid_solicitud.Text, idSolicitud) Then
            MsgBox("Seleccione la solicitud del usuario/área (haga clic en ID Solicitud).", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Txtdni_personal.Text.Trim() = "" Then
            MsgBox("Seleccione el personal que entrega el material.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim detalles As New List(Of ClsItemDetalle)
        For Each row As DataGridViewRow In DataGridView02.Rows
            If row.IsNewRow Then Continue For
            detalles.Add(New ClsItemDetalle(CInt(row.Cells(2).Value), CInt(row.Cells(3).Value)))
        Next
        If detalles.Count = 0 Then
            MsgBox("Agregue al menos un material a la lista.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            Dim nuevoId As Integer = CSalidas.RegistrarSalidaCompleta(
                Txtdni_personal.Text.Trim(), idSolicitud, DateTimePicker1.Value.Date, detalles)

            MsgBox("Salida N° " & nuevoId & " registrada exitosamente." & vbCrLf &
                   "El material fue descontado del stock.", MsgBoxStyle.Information)
            FrmSalidas_Load(sender, e)
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub FrmSalidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
        DataGridView02.AllowUserToAddRows = False
        DataGridView02.Rows.Clear()
        txtsalida.Text = ""
        txtid_solicitud.Text = ""
        Txt_Salida.Text = ""
        TxtIdDetalleSalida.Text = ""
        Txtdni_personal.Text = ModSesion.DNIPersonal   'por defecto entrega quien inició sesión
        DateTimePicker1.Value = Date.Today
        GroupBox1.Enabled = True
    End Sub

    Private Sub Txtdni_personal_Click(sender As Object, e As EventArgs) Handles Txtdni_personal.Click
        FrmBuscarPersonalParaSalida.Show()
    End Sub

    Private Sub TxtIdMaterial_1_Click(sender As Object, e As EventArgs) Handles TxtIdMaterial_1.Click
        FrmBuscarMaterialParaSalida.Show()
    End Sub

    'Quitar un material de la lista con la tecla Supr
    Private Sub DataGridView02_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView02.KeyDown
        If e.KeyCode = Keys.Delete AndAlso DataGridView02.CurrentRow IsNot Nothing Then
            DataGridView02.Rows.Remove(DataGridView02.CurrentRow)
            e.Handled = True
        End If
    End Sub

    Private Sub Numeros(ByVal e As KeyPressEventArgs)
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

    Private Sub TxtCantidad1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidad1.KeyPress
        Numeros(e)
    End Sub

    '---------------- Cargar los materiales pedidos en la solicitud ----------------
    Private Sub txtid_solicitud_TextChanged(sender As Object, e As EventArgs) Handles txtid_solicitud.TextChanged
        CargarDesdeSolicitud()
    End Sub

    Private Sub CargarDesdeSolicitud()
        Dim idSol As Integer
        If Not EsEnteroPositivo(txtid_solicitud.Text, idSol) Then Exit Sub
        Try
            Dim sol As DataRow = ClsControl.ObtenerSolicitud(idSol)
            If sol Is Nothing Then Exit Sub
            Dim estado As String = sol("Estado").ToString()
            Dim usuario As String = sol("Usuario").ToString()

            If estado = "Anulada" Then
                MsgBox("La solicitud N° " & idSol & " está ANULADA y no se puede atender.", MsgBoxStyle.Exclamation)
                txtid_solicitud.Text = ""
                Exit Sub
            End If
            If estado = "Atendida" Then
                If MsgBox("La solicitud N° " & idSol & " ya fue ATENDIDA." & vbCrLf & "¿Desea registrar una salida adicional para esta solicitud?",
                          MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then
                    txtid_solicitud.Text = ""
                    Exit Sub
                End If
            End If

            Dim det As DataTable = ClsControl.DetalleSolicitud(idSol)
            If det.Rows.Count = 0 Then Exit Sub   'solicitud antigua sin detalle: se agregan los materiales a mano

            If DataGridView02.Rows.Count > 0 AndAlso
               MsgBox("¿Reemplazar la lista actual con los materiales de la solicitud N° " & idSol & "?",
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub

            DataGridView02.Rows.Clear()
            Dim avisos As New List(Of String)

            ' Cargar todos los ítems a la tabla
            For Each d As DataRow In det.Rows
                Dim pedido As Integer = CInt(d("Cantidad"))
                Dim stock As Integer = CInt(d("Stock"))
                Dim aEntregar As Integer = Math.Min(pedido, stock)
                If aEntregar < pedido Then
                    avisos.Add("• " & d("Material").ToString() & ": pidió " & pedido & ", hay " & stock)
                End If
                If aEntregar > 0 Then
                    DataGridView02.Rows.Add((DataGridView02.Rows.Count + 1).ToString(), Txt_Salida.Text, d("IDMaterial").ToString(), aEntregar.ToString())
                End If
            Next

            ' Asignar el primer material encontrado a las cajas superiores para vista rápida/edición
            If det.Rows.Count > 0 Then
                TxtIdMaterial_1.Text = det.Rows(0)("IDMaterial").ToString()
                TxtCantidad1.Text = det.Rows(0)("Cantidad").ToString()
            End If

            ' Actualizar número de detalle actual
            TxtIdDetalleSalida.Text = (DataGridView02.RowCount + 1).ToString()

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