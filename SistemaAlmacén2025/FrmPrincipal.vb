Imports System.Windows.Forms

''' <summary>
''' Menú principal organizado en 5 módulos:
'''   1. Maestros     2. Operaciones     3. Control     4. Consultas     5. Reportes
''' </summary>
Public Class FrmPrincipal

    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarSesion()
    End Sub

    Private Sub FrmPrincipal_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then MostrarSesion()
    End Sub

    Private Sub MostrarSesion()
        If ModSesion.Iniciada Then
            SesionToolStripMenuItem.Text = "Sesión: " & ModSesion.NombrePersonal & " (" & ModSesion.CargoPersonal & ")"
        Else
            SesionToolStripMenuItem.Text = ""
        End If
    End Sub

    'Abre un formulario (instancia por defecto) dentro del menú principal
    Private Sub AbrirHijo(ByVal frm As Form)
        frm.MdiParent = Me
        frm.Show()
        frm.Activate()
    End Sub

    '================= ARCHIVO =================
    Private Sub CerrarSesion()
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
        ModSesion.Cerrar()
        Me.Hide()
        FrmAcceso.Txtusuario.Text = ""
        FrmAcceso.Txtcontraseña.Text = ""
        FrmAcceso.Show()
        FrmAcceso.Txtusuario.Focus()
    End Sub
    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        CerrarSesion()
    End Sub
    Private Sub ToolStripButtonCerrarSesion_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCerrarSesion.Click
        CerrarSesion()
    End Sub
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Application.Exit()
    End Sub
    Private Sub ToolStripButtonSalir_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSalir.Click
        Application.Exit()
    End Sub

    '================= 1. MAESTROS =================
    Private Sub RegistrarMaterialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarMaterialToolStripMenuItem.Click, ToolStripButtonRegistrarMaterial.Click
        AbrirHijo(FrmMaterial)
    End Sub
    Private Sub RegistrarUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarUsuarioToolStripMenuItem.Click, ToolStripButtonRegistrarUsuario.Click
        AbrirHijo(FrmUsuario)
    End Sub
    Private Sub RegistrarPersonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarPersonalToolStripMenuItem.Click, ToolStripButtonRegistrarPersonal.Click
        AbrirHijo(FrmPersonal)
    End Sub

    '================= 2. OPERACIONES =================
    Private Sub RegistrarSolicitudToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarSolicitudToolStripMenuItem.Click, ToolStripButtonSolicitud.Click
        AbrirHijo(FrmSolicitud)
    End Sub
    Private Sub RegistrarPrestamoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarPrestamoToolStripMenuItem.Click, ToolStripButton1.Click
        AbrirHijo(FrmPrestamo)
    End Sub
    Private Sub RegistrarSalidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarSalidaToolStripMenuItem.Click, ToolStripButton2.Click
        AbrirHijo(FrmSalidas)
    End Sub
    Private Sub RegistrarDevoluciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarDevoluciónToolStripMenuItem.Click, ToolStripButtonDevoluciones.Click
        AbrirHijo(FrmDevoluciones)
    End Sub

    '================= 3. CONTROL =================
    Private Sub CtrlSolicitudesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CtrlSolicitudesToolStripMenuItem.Click
        FrmControl.Abrir(Me, FrmControl.TabSolicitudesIdx)
    End Sub
    Private Sub CtrlDisponiblesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CtrlDisponiblesToolStripMenuItem.Click
        FrmControl.Abrir(Me, FrmControl.TabDisponiblesIdx)
    End Sub
    Private Sub CtrlPrestadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CtrlPrestadosToolStripMenuItem.Click
        FrmControl.Abrir(Me, FrmControl.TabPrestadosIdx)
    End Sub
    Private Sub CtrlPendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CtrlPendientesToolStripMenuItem.Click
        FrmControl.Abrir(Me, FrmControl.TabPendientesIdx)
    End Sub
    Private Sub CtrlDevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CtrlDevolucionesToolStripMenuItem.Click
        FrmControl.Abrir(Me, FrmControl.TabDevolucionesIdx)
    End Sub
    Private Sub CtrlHistorialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CtrlHistorialToolStripMenuItem.Click
        FrmControl.Abrir(Me, FrmControl.TabHistorialIdx)
    End Sub

    '================= 4. CONSULTAS =================
    Private Sub MaterialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialToolStripMenuItem.Click
        AbrirHijo(FrmConsulta_Material)
    End Sub
    Private Sub BuscarUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarUsuarioToolStripMenuItem.Click
        AbrirHijo(FrmConsulta_Usuario)
    End Sub
    Private Sub BuscarPrestamoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarPrestamoToolStripMenuItem.Click
        AbrirHijo(FrmConsulta_Prestamo)
    End Sub
    Private Sub DevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionesToolStripMenuItem.Click
        AbrirHijo(FrmConsulta_Salidas)
    End Sub
    Private Sub DevolucionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DevolucionesToolStripMenuItem1.Click
        AbrirHijo(FrmConsulta_Devoluciones)
    End Sub

    '================= 5. REPORTES =================
    Private Sub RepMaterialesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepMaterialesToolStripMenuItem.Click
        FrmReporteListado.Abrir(Me, FrmReporteListado.TipoReporte.Materiales)
    End Sub
    Private Sub RepPrestamosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepPrestamosToolStripMenuItem.Click
        FrmReporteListado.Abrir(Me, FrmReporteListado.TipoReporte.Prestamos)
    End Sub
    Private Sub RepDevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepDevolucionesToolStripMenuItem.Click
        FrmReporteListado.Abrir(Me, FrmReporteListado.TipoReporte.Devoluciones)
    End Sub
    Private Sub RepSalidasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepSalidasToolStripMenuItem.Click
        FrmReporteListado.Abrir(Me, FrmReporteListado.TipoReporte.Salidas)
    End Sub
    Private Sub RepPendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RepPendientesToolStripMenuItem.Click
        FrmReporteListado.Abrir(Me, FrmReporteListado.TipoReporte.PrestamosPendientes)
    End Sub

    '================= AYUDA =================
    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        MsgBox("SISTEMA DE ALMACÉN 2025" & vbCrLf & vbCrLf &
               "Flujo de préstamo:" & vbCrLf &
               "  Usuario → Solicitud → Préstamo (Pendiente) → Devolución (Devuelto)" & vbCrLf & vbCrLf &
               "Flujo de salida definitiva:" & vbCrLf &
               "  Usuario/Área → Solicitud → Salida (se descuenta del stock)" & vbCrLf & vbCrLf &
               "Preguntas frecuentes:" & vbCrLf &
               "  ¿Quién tiene este material?  → Control > Materiales prestados" & vbCrLf &
               "  ¿Qué materiales tiene esta persona?  → Consultas > Buscar usuario" & vbCrLf &
               "  ¿Quién todavía no ha devuelto?  → Control > Préstamos pendientes",
               MsgBoxStyle.Information, "Acerca del sistema")
    End Sub

End Class
