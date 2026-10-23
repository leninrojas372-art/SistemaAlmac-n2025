''' <summary>
''' 2. OPERACIONES > Solicitud de material
''' El usuario pide uno o varios materiales. La solicitud queda "Pendiente" hasta que
''' se atiende con un Préstamo o una Salida (entonces pasa a "Atendida").
''' La solicitud NO descuenta stock: solo registra el pedido.
''' </summary>
Public Class FrmSolicitud
    Dim CSolicitud As New ClsSolicitud
    Dim dtDetalle As DataTable            'materiales de la solicitud que se está editando
    Dim estadoActual As String = ""       '"" = solicitud nueva

    Private Sub FrmSolicitud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarSolicitudes()
        CargarMateriales()
        PrepararDetalle()
        If TxtFecha.Text.Trim() = "" Then TxtFecha.Text = Date.Today.ToString("dd/MM/yyyy")
    End Sub

    Private Sub CargarSolicitudes()
        Try
            Dim MiDataSet As DataSet = CSolicitud.CargarSolicitud()
            DataGridView1.DataSource = MiDataSet.Tables(0)
            DataGridView1.ReadOnly = True
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            If DataGridView1.Columns.Contains("Fecha") Then DataGridView1.Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    'Llena el combo de materiales mostrando el stock disponible
    Private Sub CargarMateriales()
        Try
            Dim dt As DataTable = ClsControl.ListaMateriales()
            dt.Columns.Add("Texto", GetType(String))
            For Each fila As DataRow In dt.Rows
                fila("Texto") = fila("Nombre").ToString().Trim() & "  (stock: " & fila("Stock").ToString() & ")"
            Next
            dt.DefaultView.Sort = "Texto"
            CmbMaterial.DataSource = dt.DefaultView
            CmbMaterial.DisplayMember = "Texto"
            CmbMaterial.ValueMember = "IDMaterial"
            CmbMaterial.SelectedIndex = -1
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub PrepararDetalle()
        dtDetalle = New DataTable()
        dtDetalle.Columns.Add("IDMaterial", GetType(Integer))
        dtDetalle.Columns.Add("Material", GetType(String))
        dtDetalle.Columns.Add("Cantidad", GetType(Integer))
        dtDetalle.Columns.Add("Stock", GetType(Integer))
        DgvDetalleSol.DataSource = dtDetalle
        DgvDetalleSol.ReadOnly = True
        DgvDetalleSol.AllowUserToAddRows = False
        DgvDetalleSol.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DgvDetalleSol.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DgvDetalleSol.Columns("Stock").HeaderText = "Stock actual"
        estadoActual = ""
        HabilitarEdicion(True)
    End Sub

    'Una solicitud Atendida o Anulada ya no se puede cambiar
    Private Sub HabilitarEdicion(ByVal editable As Boolean)
        CmbMaterial.Enabled = editable
        TxtCantidadSol.Enabled = editable
        BtnAgregarMat.Enabled = editable
        BtnQuitarMat.Enabled = editable
        Button_Modificar.Enabled = editable AndAlso estadoActual = "Pendiente"
        BtnAnular.Enabled = editable AndAlso estadoActual = "Pendiente"
        BtnRegistrar1.Enabled = (estadoActual = "")
        GroupBox4.Text = "Materiales solicitados:" &
            If(estadoActual = "" OrElse estadoActual = "Pendiente", "", "   (solicitud " & estadoActual.ToUpper() & " – solo lectura)")
    End Sub

    Private Function DetalleComoLista() As List(Of ClsItemDetalle)
        Dim lista As New List(Of ClsItemDetalle)
        For Each fila As DataRow In dtDetalle.Rows
            lista.Add(New ClsItemDetalle(CInt(fila("IDMaterial")), CInt(fila("Cantidad"))))
        Next
        Return lista
    End Function

    '---------------- Materiales de la solicitud ----------------
    Private Sub BtnAgregarMat_Click(sender As Object, e As EventArgs) Handles BtnAgregarMat.Click
        If CmbMaterial.SelectedIndex < 0 Then
            MsgBox("Seleccione un material.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim cantidad As Integer
        If Not EsEnteroPositivo(TxtCantidadSol.Text, cantidad) Then
            MsgBox("Ingrese una cantidad mayor a 0.", MsgBoxStyle.Exclamation)
            TxtCantidadSol.Focus()
            Exit Sub
        End If

        Dim sel As DataRowView = CType(CmbMaterial.SelectedItem, DataRowView)
        Dim idMaterial As Integer = CInt(sel("IDMaterial"))
        Dim nombre As String = sel("Nombre").ToString().Trim()
        Dim stock As Integer = CInt(sel("Stock"))

        Dim existente As DataRow = dtDetalle.Select("IDMaterial = " & idMaterial).FirstOrDefault()
        Dim total As Integer = cantidad + If(existente Is Nothing, 0, CInt(existente("Cantidad")))

        'Se permite pedir más de lo que hay (es solo un pedido), pero se avisa
        If total > stock Then
            If MsgBox("Actualmente solo hay " & stock & " unidad(es) de " & nombre & " en stock." & vbCrLf &
                      "¿Registrar el pedido de " & total & " de todos modos?",
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        End If

        If existente IsNot Nothing Then
            existente("Cantidad") = total
        Else
            dtDetalle.Rows.Add(idMaterial, nombre, cantidad, stock)
        End If
        TxtCantidadSol.Text = ""
        CmbMaterial.SelectedIndex = -1
        CmbMaterial.Focus()
    End Sub

    Private Sub BtnQuitarMat_Click(sender As Object, e As EventArgs) Handles BtnQuitarMat.Click
        If DgvDetalleSol.CurrentRow Is Nothing Then
            MsgBox("Seleccione el material que desea quitar de la lista.", MsgBoxStyle.Information)
            Exit Sub
        End If
        DgvDetalleSol.Rows.Remove(DgvDetalleSol.CurrentRow)
    End Sub

    '---------------- Botones principales ----------------
    Private Sub BtnRegistrar1_Click(sender As Object, e As EventArgs) Handles BtnRegistrar1.Click
        Dim fecha As Date
        If Not ValidarDatos(fecha) Then Exit Sub
        Try
            Dim nuevoId As Integer = CSolicitud.RegistrarSolicitudCompleta(TxtDNI_Usuario.Text.Trim(), fecha, DetalleComoLista())
            MsgBox("Solicitud N° " & nuevoId & " registrada correctamente." & vbCrLf &
                   "Estado: PENDIENTE (se atenderá con un préstamo o una salida).", MsgBoxStyle.Information)
            LimpiarTodo()
            CargarSolicitudes()
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub Button_Modificar_Click(sender As Object, e As EventArgs) Handles Button_Modificar.Click
        Dim id As Integer
        If Not EsEnteroPositivo(TxtIDSolicitud.Text, id) Then
            MsgBox("Seleccione una solicitud de la lista.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim fecha As Date
        If Not ValidarDatos(fecha) Then Exit Sub
        Try
            CSolicitud.ActualizarSolicitudCompleta(id, TxtDNI_Usuario.Text.Trim(), fecha, DetalleComoLista())
            MsgBox("La solicitud ha sido modificada correctamente.", MsgBoxStyle.Information)
            CargarSolicitudes()
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub BtnAnular_Click(sender As Object, e As EventArgs) Handles BtnAnular.Click
        Dim id As Integer
        If Not EsEnteroPositivo(TxtIDSolicitud.Text, id) Then
            MsgBox("Seleccione una solicitud de la lista.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("¿Anular la solicitud N° " & id & "? Ya no podrá atenderse.",
                  MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation) = MsgBoxResult.No Then Exit Sub
        If CSolicitud.AnularSolicitud(id) Then
            MsgBox("La solicitud fue anulada.", MsgBoxStyle.Information)
            LimpiarTodo()
            CargarSolicitudes()
        End If
    End Sub

    Private Sub Button_Eliminar_Click(sender As Object, e As EventArgs) Handles Button_Eliminar.Click
        If TxtIDSolicitud.Text.Trim() = "" Then
            MsgBox("Seleccione una solicitud de la lista.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If MsgBox("¿Eliminar la solicitud N° " & TxtIDSolicitud.Text & " y sus materiales?",
                  MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation) = MsgBoxResult.No Then Exit Sub
        If CSolicitud.EliminarSolicitud(TxtIDSolicitud.Text.Trim()) Then
            MsgBox("La solicitud ha sido eliminada correctamente.", MsgBoxStyle.Information)
            LimpiarTodo()
            CargarSolicitudes()
        End If
    End Sub

    Private Sub ButtonNuevo01_Click(sender As Object, e As EventArgs) Handles ButtonNuevo01.Click
        LimpiarTodo()
        TxtDNI_Usuario.Focus()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Limpiamos los campos de texto directamente
        LimpiarTodo()
    End Sub

    Private Sub LimpiarTodo()
        TxtIDSolicitud.Text = ""
        TxtDNI_Usuario.Text = ""
        TxtFecha.Text = Date.Today.ToString("dd/MM/yyyy")
        TxtCantidadSol.Text = ""
        CmbMaterial.SelectedIndex = -1
        PrepararDetalle()
    End Sub

    'Al elegir una solicitud de la lista se cargan sus datos y sus materiales
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim id As Integer = CInt(fila.Cells("IDSolicitud").Value)
        TxtIDSolicitud.Text = id.ToString()
        TxtDNI_Usuario.Text = fila.Cells("DNIUsuario").Value.ToString().Trim()
        If Not IsDBNull(fila.Cells("Fecha").Value) Then TxtFecha.Text = CDate(fila.Cells("Fecha").Value).ToString("dd/MM/yyyy")

        Try
            PrepararDetalle()
            For Each d As DataRow In ClsControl.DetalleSolicitud(id).Rows
                dtDetalle.Rows.Add(CInt(d("IDMaterial")), d("Material").ToString(), CInt(d("Cantidad")), CInt(d("Stock")))
            Next
            estadoActual = fila.Cells("Estado").Value.ToString()
            HabilitarEdicion(estadoActual = "Pendiente")
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub TxtDNI_Usuario_Click(sender As Object, e As EventArgs) Handles TxtDNI_Usuario.Click
        FrmBuscarUsuarioParaSolicutud1.Show()
    End Sub

    Private Function ValidarDatos(ByRef fecha As Date) As Boolean
        If TxtDNI_Usuario.Text.Trim() = "" Then
            MsgBox("Seleccione el usuario que solicita (haga clic en DNI Usuario).", MsgBoxStyle.Exclamation)
            Return False
        End If
        If Not Date.TryParse(TxtFecha.Text.Trim(), fecha) Then
            MsgBox("Fecha no válida. Use el formato dd/mm/aaaa.", MsgBoxStyle.Exclamation)
            TxtFecha.Focus()
            Return False
        End If
        If dtDetalle.Rows.Count = 0 Then
            MsgBox("Agregue al menos un material a la solicitud.", MsgBoxStyle.Exclamation)
            CmbMaterial.Focus()
            Return False
        End If
        Return True
    End Function

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

    Private Sub TxtDNI_Usuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDNI_Usuario.KeyPress
        Numeros(e)
    End Sub

    Private Sub TxtCantidadSol_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidadSol.KeyPress
        Numeros(e)
    End Sub

End Class
