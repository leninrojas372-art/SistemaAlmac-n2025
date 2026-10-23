''' <summary>
''' 3. CONTROL
'''   Pestaña 0: Materiales disponibles
'''   Pestaña 1: Materiales prestados   -> "¿Quién tiene este material?"
'''   Pestaña 2: Préstamos pendientes   -> "¿Quién todavía no ha devuelto?"
'''   Pestaña 3: Devoluciones
'''   Pestaña 4: Historial por usuario  -> "¿Qué materiales tiene/tuvo esta persona?"
'''   Pestaña 5: Solicitudes pendientes -> pedidos que todavía no se atienden
''' </summary>
Public Class FrmControl

    Public Const TabDisponiblesIdx As Integer = 0
    Public Const TabPrestadosIdx As Integer = 1
    Public Const TabPendientesIdx As Integer = 2
    Public Const TabDevolucionesIdx As Integer = 3
    Public Const TabHistorialIdx As Integer = 4
    Public Const TabSolicitudesIdx As Integer = 5

    Private cargando As Boolean = False

    'Abre (o activa si ya está abierto) el formulario en la pestaña indicada
    Public Shared Sub Abrir(ByVal padre As Form, ByVal pestaña As Integer)
        Dim frm As FrmControl = Nothing
        For Each hijo As Form In padre.MdiChildren
            If TypeOf hijo Is FrmControl Then frm = CType(hijo, FrmControl)
        Next
        If frm Is Nothing Then
            frm = New FrmControl()
            frm.MdiParent = padre
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If
        frm.IrAPestaña(pestaña)
        frm.Activate()
    End Sub

    Public Sub IrAPestaña(ByVal pestaña As Integer)
        If TabControl1.SelectedIndex = pestaña Then
            Cargar()
        Else
            TabControl1.SelectedIndex = pestaña   'dispara SelectedIndexChanged -> Cargar
        End If
    End Sub

    Private Sub FrmControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each dgv As DataGridView In {DgvDisponibles, DgvPrestados, DgvPendientes, DgvDevoluciones, DgvHistorial, DgvSolicitudes}
            ConfigurarGrilla(dgv)
        Next
        Cargar()
    End Sub

    Private Function GrillaActual() As DataGridView
        Select Case TabControl1.SelectedIndex
            Case TabDisponiblesIdx : Return DgvDisponibles
            Case TabPrestadosIdx : Return DgvPrestados
            Case TabPendientesIdx : Return DgvPendientes
            Case TabDevolucionesIdx : Return DgvDevoluciones
            Case TabSolicitudesIdx : Return DgvSolicitudes
            Case Else : Return DgvHistorial
        End Select
    End Function

    Private Sub Cargar()
        If cargando Then Exit Sub
        cargando = True
        Try
            Dim filtro As String = TxtFiltro.Text.Trim()
            Dim datos As DataTable
            Select Case TabControl1.SelectedIndex
                Case TabDisponiblesIdx
                    LblAyuda.Text = "Filtrar por nombre o ID de material. Solo se muestran materiales con stock y no obsoletos."
                    datos = ClsControl.MaterialesDisponibles(filtro)
                    MostrarEnGrilla(DgvDisponibles, datos)
                    LblResumen.Text = datos.Rows.Count & " materiales disponibles  |  Unidades en almacén: " & SumarColumna(datos, "Disponible")

                Case TabPrestadosIdx
                    LblAyuda.Text = "¿Quién tiene este material? Escriba el nombre o ID del material."
                    datos = ClsControl.MaterialesPrestados(filtro)
                    MostrarEnGrilla(DgvPrestados, datos)
                    LblResumen.Text = datos.Rows.Count & " registros  |  Unidades prestadas: " & SumarColumna(datos, "Cantidad") &
                                      "  |  En rojo: más de " & DiasAlertaPrestamo & " días"

                Case TabPendientesIdx
                    LblAyuda.Text = "¿Quién no ha devuelto? Filtrar por DNI, nombre o N° de préstamo. Doble clic para registrar la devolución."
                    datos = ClsControl.PrestamosPendientes(filtro)
                    MostrarEnGrilla(DgvPendientes, datos)
                    LblResumen.Text = datos.Rows.Count & " préstamos pendientes  |  En rojo: más de " & DiasAlertaPrestamo & " días"

                Case TabDevolucionesIdx
                    LblAyuda.Text = "Filtrar por DNI, usuario, material o N° de préstamo."
                    datos = ClsControl.Devoluciones(filtro)
                    MostrarEnGrilla(DgvDevoluciones, datos)
                    LblResumen.Text = datos.Rows.Count & " registros de devolución"

                Case TabSolicitudesIdx
                    LblAyuda.Text = "Pedidos sin atender. Filtrar por DNI, nombre o N° de solicitud. Doble clic para atenderla con un préstamo o una salida."
                    datos = ClsControl.SolicitudesPendientes(filtro)
                    MostrarEnGrilla(DgvSolicitudes, datos)
                    Dim sinStock As Integer = datos.Select("Disponibilidad = 'Falta stock'").Length
                    LblResumen.Text = datos.Rows.Count & " solicitudes pendientes de atender  |  Con falta de stock: " & sinStock

                Case Else
                    LblAyuda.Text = "Escriba el DNI (completo) o parte del nombre del usuario para ver su historial."
                    If filtro = "" Then
                        DgvHistorial.DataSource = Nothing
                        LblResumen.Text = "Ingrese un DNI o nombre de usuario"
                    Else
                        datos = ClsControl.HistorialUsuario(filtro)
                        MostrarEnGrilla(DgvHistorial, datos)
                        Dim pendientes As Integer = datos.Select("Estado = 'Pendiente'").Length
                        LblResumen.Text = datos.Rows.Count & " movimientos  |  Materiales aún sin devolver: " & pendientes
                    End If
            End Select
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        Finally
            cargando = False
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Cargar()
    End Sub

    Private Sub TxtFiltro_TextChanged(sender As Object, e As EventArgs) Handles TxtFiltro.TextChanged
        'El historial se consulta al presionar Enter o ACTUALIZAR (necesita el DNI completo o un nombre)
        If TabControl1.SelectedIndex <> TabHistorialIdx Then Cargar()
    End Sub

    Private Sub TxtFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Cargar()
        End If
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        Cargar()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Dim subt As String = If(TxtFiltro.Text.Trim() = "", "Todos los registros", "Filtro: " & TxtFiltro.Text.Trim())
        ClsImpresionGrid.Imprimir(GrillaActual(), TabControl1.SelectedTab.Text, subt)
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        ExportarExcel(GrillaActual(), TabControl1.SelectedTab.Text.Replace(" ", "_"))
    End Sub

    'Resalta en rojo los préstamos con muchos días
    Private Sub Grillas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvPrestados.CellFormatting, DgvPendientes.CellFormatting, DgvHistorial.CellFormatting
        ResaltarAtrasados(CType(sender, DataGridView), e)
    End Sub

    'Resalta las solicitudes que no se pueden atender completas por falta de stock
    Private Sub DgvSolicitudes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvSolicitudes.CellFormatting
        If e.RowIndex < 0 OrElse Not DgvSolicitudes.Columns.Contains("Disponibilidad") Then Exit Sub
        Dim v As Object = DgvSolicitudes.Rows(e.RowIndex).Cells("Disponibilidad").Value
        If v IsNot Nothing AndAlso v.ToString() = "Falta stock" Then
            e.CellStyle.BackColor = Color.LightYellow
            e.CellStyle.ForeColor = Color.DarkOrange
        End If
    End Sub

    'Doble clic en una solicitud pendiente -> atenderla con un Préstamo (Sí) o una Salida (No)
    Private Sub DgvSolicitudes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSolicitudes.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim id As String = DgvSolicitudes.Rows(e.RowIndex).Cells("Solicitud").Value.ToString()
        Dim r As MsgBoxResult = MsgBox("¿Cómo desea atender la solicitud N° " & id & "?" & vbCrLf & vbCrLf &
                                       "Sí = PRÉSTAMO (el material se devuelve)" & vbCrLf &
                                       "No = SALIDA definitiva (el material se consume)",
                                       MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question, "Atender solicitud")
        If r = MsgBoxResult.Yes Then
            FrmPrestamo.MdiParent = Me.MdiParent
            FrmPrestamo.Show()
            FrmPrestamo.TxtId_Solicitud.Text = id     'carga automáticamente los materiales pedidos
            FrmPrestamo.Activate()
        ElseIf r = MsgBoxResult.No Then
            FrmSalidas.MdiParent = Me.MdiParent
            FrmSalidas.Show()
            FrmSalidas.txtid_solicitud.Text = id
            FrmSalidas.Activate()
        End If
    End Sub

    'Al volver a esta ventana se refresca (por ejemplo, después de atender una solicitud)
    Private Sub FrmControl_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If TabControl1.SelectedIndex = TabSolicitudesIdx OrElse TabControl1.SelectedIndex = TabPendientesIdx Then Cargar()
    End Sub

    'Doble clic en un préstamo pendiente -> abre Devoluciones con el préstamo cargado
    Private Sub DgvPendientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPendientes.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim id As String = DgvPendientes.Rows(e.RowIndex).Cells("Préstamo").Value.ToString()
        FrmDevoluciones.MdiParent = Me.MdiParent
        FrmDevoluciones.Show()
        FrmDevoluciones.CargarPrestamoParaDevolver(id)
        FrmDevoluciones.Activate()
    End Sub

End Class
