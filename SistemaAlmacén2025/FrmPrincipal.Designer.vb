<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonRegistrarMaterial = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonRegistrarPersonal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonRegistrarUsuario = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSolicitud = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDevoluciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCerrarSesion = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSalir = New System.Windows.Forms.ToolStripButton()
        Me.MantenimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSesionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaestrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarMaterialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarPersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarSolicitudToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarPrestamoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarSalidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarDevoluciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CtrlSolicitudesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CtrlDisponiblesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CtrlPrestadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CtrlPendientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CtrlDevolucionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CtrlHistorialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CONSULTASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaterialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarPrestamoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevolucionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevolucionesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepMaterialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepPrestamosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepDevolucionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepSalidasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RepPendientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SesionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(70, 70)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonRegistrarMaterial, Me.ToolStripButtonRegistrarPersonal, Me.ToolStripButtonRegistrarUsuario, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButtonSolicitud, Me.ToolStripButtonDevoluciones, Me.ToolStripButtonCerrarSesion, Me.ToolStripButtonSalir})
        Me.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip.Location = New System.Drawing.Point(0, 45)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Padding = New System.Windows.Forms.Padding(0, 62, 1, 1)
        Me.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip.Size = New System.Drawing.Size(75, 785)
        Me.ToolStrip.TabIndex = 6
        '
        'ToolStripButtonRegistrarMaterial
        '
        Me.ToolStripButtonRegistrarMaterial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStripButtonRegistrarMaterial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRegistrarMaterial.Font = New System.Drawing.Font("Segoe UI", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButtonRegistrarMaterial.Image = CType(resources.GetObject("ToolStripButtonRegistrarMaterial.Image"), System.Drawing.Image)
        Me.ToolStripButtonRegistrarMaterial.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolStripButtonRegistrarMaterial.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRegistrarMaterial.Name = "ToolStripButtonRegistrarMaterial"
        Me.ToolStripButtonRegistrarMaterial.Size = New System.Drawing.Size(72, 74)
        Me.ToolStripButtonRegistrarMaterial.Text = "Registrar Material"
        '
        'ToolStripButtonRegistrarPersonal
        '
        Me.ToolStripButtonRegistrarPersonal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRegistrarPersonal.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButtonRegistrarPersonal.Image = CType(resources.GetObject("ToolStripButtonRegistrarPersonal.Image"), System.Drawing.Image)
        Me.ToolStripButtonRegistrarPersonal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButtonRegistrarPersonal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRegistrarPersonal.Name = "ToolStripButtonRegistrarPersonal"
        Me.ToolStripButtonRegistrarPersonal.Size = New System.Drawing.Size(72, 74)
        Me.ToolStripButtonRegistrarPersonal.Text = "Registrar Personal"
        '
        'ToolStripButtonRegistrarUsuario
        '
        Me.ToolStripButtonRegistrarUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRegistrarUsuario.Image = CType(resources.GetObject("ToolStripButtonRegistrarUsuario.Image"), System.Drawing.Image)
        Me.ToolStripButtonRegistrarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButtonRegistrarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRegistrarUsuario.Name = "ToolStripButtonRegistrarUsuario"
        Me.ToolStripButtonRegistrarUsuario.Size = New System.Drawing.Size(72, 74)
        Me.ToolStripButtonRegistrarUsuario.Text = "Registrar Usuario"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 74)
        Me.ToolStripButton1.Text = "Registrar Prestamo"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(72, 74)
        Me.ToolStripButton2.Text = "Registrar Salidas"
        '
        'ToolStripButtonSolicitud
        '
        Me.ToolStripButtonSolicitud.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSolicitud.Image = CType(resources.GetObject("ToolStripButtonSolicitud.Image"), System.Drawing.Image)
        Me.ToolStripButtonSolicitud.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButtonSolicitud.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSolicitud.Name = "ToolStripButtonSolicitud"
        Me.ToolStripButtonSolicitud.Size = New System.Drawing.Size(72, 74)
        Me.ToolStripButtonSolicitud.Text = "Registrar Solicitud"
        '
        'ToolStripButtonDevoluciones
        '
        Me.ToolStripButtonDevoluciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDevoluciones.Image = CType(resources.GetObject("ToolStripButtonDevoluciones.Image"), System.Drawing.Image)
        Me.ToolStripButtonDevoluciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButtonDevoluciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDevoluciones.Name = "ToolStripButtonDevoluciones"
        Me.ToolStripButtonDevoluciones.Size = New System.Drawing.Size(72, 74)
        Me.ToolStripButtonDevoluciones.Text = "Registrar Devolución"
        '
        'ToolStripButtonCerrarSesion
        '
        Me.ToolStripButtonCerrarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonCerrarSesion.Image = CType(resources.GetObject("ToolStripButtonCerrarSesion.Image"), System.Drawing.Image)
        Me.ToolStripButtonCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolStripButtonCerrarSesion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCerrarSesion.Name = "ToolStripButtonCerrarSesion"
        Me.ToolStripButtonCerrarSesion.Size = New System.Drawing.Size(72, 74)
        Me.ToolStripButtonCerrarSesion.Text = "Cerrar Sesión"
        '
        'ToolStripButtonSalir
        '
        Me.ToolStripButtonSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSalir.Image = CType(resources.GetObject("ToolStripButtonSalir.Image"), System.Drawing.Image)
        Me.ToolStripButtonSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButtonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSalir.Name = "ToolStripButtonSalir"
        Me.ToolStripButtonSalir.Size = New System.Drawing.Size(72, 74)
        Me.ToolStripButtonSalir.Text = "Salir"
        '
        'MantenimientoToolStripMenuItem
        '
        Me.MantenimientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarSesionToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MantenimientoToolStripMenuItem.Name = "MantenimientoToolStripMenuItem"
        Me.MantenimientoToolStripMenuItem.Size = New System.Drawing.Size(130, 41)
        Me.MantenimientoToolStripMenuItem.Text = "Archivo"
        '
        'CerrarSesionToolStripMenuItem
        '
        Me.CerrarSesionToolStripMenuItem.Name = "CerrarSesionToolStripMenuItem"
        Me.CerrarSesionToolStripMenuItem.Size = New System.Drawing.Size(278, 42)
        Me.CerrarSesionToolStripMenuItem.Text = "Cerrar Sesión"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(278, 42)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'MaestrosToolStripMenuItem
        '
        Me.MaestrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarMaterialToolStripMenuItem, Me.RegistrarUsuarioToolStripMenuItem, Me.RegistrarPersonalToolStripMenuItem})
        Me.MaestrosToolStripMenuItem.Name = "MaestrosToolStripMenuItem"
        Me.MaestrosToolStripMenuItem.Size = New System.Drawing.Size(180, 41)
        Me.MaestrosToolStripMenuItem.Text = "1. Maestros"
        '
        'RegistrarMaterialToolStripMenuItem
        '
        Me.RegistrarMaterialToolStripMenuItem.Name = "RegistrarMaterialToolStripMenuItem"
        Me.RegistrarMaterialToolStripMenuItem.Size = New System.Drawing.Size(244, 42)
        Me.RegistrarMaterialToolStripMenuItem.Text = "Materiales"
        '
        'RegistrarUsuarioToolStripMenuItem
        '
        Me.RegistrarUsuarioToolStripMenuItem.Name = "RegistrarUsuarioToolStripMenuItem"
        Me.RegistrarUsuarioToolStripMenuItem.Size = New System.Drawing.Size(244, 42)
        Me.RegistrarUsuarioToolStripMenuItem.Text = "Usuarios"
        '
        'RegistrarPersonalToolStripMenuItem
        '
        Me.RegistrarPersonalToolStripMenuItem.Name = "RegistrarPersonalToolStripMenuItem"
        Me.RegistrarPersonalToolStripMenuItem.Size = New System.Drawing.Size(244, 42)
        Me.RegistrarPersonalToolStripMenuItem.Text = "Personal"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarSolicitudToolStripMenuItem, Me.RegistrarPrestamoToolStripMenuItem, Me.RegistrarSalidaToolStripMenuItem, Me.RegistrarDevoluciónToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(220, 41)
        Me.ProcesosToolStripMenuItem.Text = "2. Operaciones"
        '
        'RegistrarSolicitudToolStripMenuItem
        '
        Me.RegistrarSolicitudToolStripMenuItem.Name = "RegistrarSolicitudToolStripMenuItem"
        Me.RegistrarSolicitudToolStripMenuItem.Size = New System.Drawing.Size(375, 42)
        Me.RegistrarSolicitudToolStripMenuItem.Text = "Solicitud de material"
        '
        'RegistrarPrestamoToolStripMenuItem
        '
        Me.RegistrarPrestamoToolStripMenuItem.Name = "RegistrarPrestamoToolStripMenuItem"
        Me.RegistrarPrestamoToolStripMenuItem.Size = New System.Drawing.Size(375, 42)
        Me.RegistrarPrestamoToolStripMenuItem.Text = "Préstamo"
        '
        'RegistrarSalidaToolStripMenuItem
        '
        Me.RegistrarSalidaToolStripMenuItem.Name = "RegistrarSalidaToolStripMenuItem"
        Me.RegistrarSalidaToolStripMenuItem.Size = New System.Drawing.Size(375, 42)
        Me.RegistrarSalidaToolStripMenuItem.Text = "Salida"
        '
        'RegistrarDevoluciónToolStripMenuItem
        '
        Me.RegistrarDevoluciónToolStripMenuItem.Name = "RegistrarDevoluciónToolStripMenuItem"
        Me.RegistrarDevoluciónToolStripMenuItem.Size = New System.Drawing.Size(375, 42)
        Me.RegistrarDevoluciónToolStripMenuItem.Text = "Devolución"
        '
        'ControlToolStripMenuItem
        '
        Me.ControlToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CtrlSolicitudesToolStripMenuItem, Me.CtrlDisponiblesToolStripMenuItem, Me.CtrlPrestadosToolStripMenuItem, Me.CtrlPendientesToolStripMenuItem, Me.CtrlDevolucionesToolStripMenuItem, Me.CtrlHistorialToolStripMenuItem})
        Me.ControlToolStripMenuItem.Name = "ControlToolStripMenuItem"
        Me.ControlToolStripMenuItem.Size = New System.Drawing.Size(158, 41)
        Me.ControlToolStripMenuItem.Text = "3. Control"
        '
        'CtrlSolicitudesToolStripMenuItem
        '
        Me.CtrlSolicitudesToolStripMenuItem.Name = "CtrlSolicitudesToolStripMenuItem"
        Me.CtrlSolicitudesToolStripMenuItem.Size = New System.Drawing.Size(674, 42)
        Me.CtrlSolicitudesToolStripMenuItem.Text = "Solicitudes pendientes de atender"
        '
        'CtrlDisponiblesToolStripMenuItem
        '
        Me.CtrlDisponiblesToolStripMenuItem.Name = "CtrlDisponiblesToolStripMenuItem"
        Me.CtrlDisponiblesToolStripMenuItem.Size = New System.Drawing.Size(674, 42)
        Me.CtrlDisponiblesToolStripMenuItem.Text = "Materiales disponibles"
        '
        'CtrlPrestadosToolStripMenuItem
        '
        Me.CtrlPrestadosToolStripMenuItem.Name = "CtrlPrestadosToolStripMenuItem"
        Me.CtrlPrestadosToolStripMenuItem.Size = New System.Drawing.Size(674, 42)
        Me.CtrlPrestadosToolStripMenuItem.Text = "Materiales prestados (¿quién lo tiene?)"
        '
        'CtrlPendientesToolStripMenuItem
        '
        Me.CtrlPendientesToolStripMenuItem.Name = "CtrlPendientesToolStripMenuItem"
        Me.CtrlPendientesToolStripMenuItem.Size = New System.Drawing.Size(674, 42)
        Me.CtrlPendientesToolStripMenuItem.Text = "Préstamos pendientes (¿quién no devolvió?)"
        '
        'CtrlDevolucionesToolStripMenuItem
        '
        Me.CtrlDevolucionesToolStripMenuItem.Name = "CtrlDevolucionesToolStripMenuItem"
        Me.CtrlDevolucionesToolStripMenuItem.Size = New System.Drawing.Size(674, 42)
        Me.CtrlDevolucionesToolStripMenuItem.Text = "Devoluciones"
        '
        'CtrlHistorialToolStripMenuItem
        '
        Me.CtrlHistorialToolStripMenuItem.Name = "CtrlHistorialToolStripMenuItem"
        Me.CtrlHistorialToolStripMenuItem.Size = New System.Drawing.Size(674, 42)
        Me.CtrlHistorialToolStripMenuItem.Text = "Historial por usuario"
        '
        'CONSULTASToolStripMenuItem
        '
        Me.CONSULTASToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaterialToolStripMenuItem, Me.BuscarUsuarioToolStripMenuItem, Me.BuscarPrestamoToolStripMenuItem, Me.DevolucionesToolStripMenuItem, Me.DevolucionesToolStripMenuItem1})
        Me.CONSULTASToolStripMenuItem.Name = "CONSULTASToolStripMenuItem"
        Me.CONSULTASToolStripMenuItem.Size = New System.Drawing.Size(185, 41)
        Me.CONSULTASToolStripMenuItem.Text = "4. Consultas"
        '
        'MaterialToolStripMenuItem
        '
        Me.MaterialToolStripMenuItem.Name = "MaterialToolStripMenuItem"
        Me.MaterialToolStripMenuItem.Size = New System.Drawing.Size(341, 42)
        Me.MaterialToolStripMenuItem.Text = "Buscar material"
        '
        'BuscarUsuarioToolStripMenuItem
        '
        Me.BuscarUsuarioToolStripMenuItem.Name = "BuscarUsuarioToolStripMenuItem"
        Me.BuscarUsuarioToolStripMenuItem.Size = New System.Drawing.Size(341, 42)
        Me.BuscarUsuarioToolStripMenuItem.Text = "Buscar usuario"
        '
        'BuscarPrestamoToolStripMenuItem
        '
        Me.BuscarPrestamoToolStripMenuItem.Name = "BuscarPrestamoToolStripMenuItem"
        Me.BuscarPrestamoToolStripMenuItem.Size = New System.Drawing.Size(341, 42)
        Me.BuscarPrestamoToolStripMenuItem.Text = "Buscar préstamo"
        '
        'DevolucionesToolStripMenuItem
        '
        Me.DevolucionesToolStripMenuItem.Name = "DevolucionesToolStripMenuItem"
        Me.DevolucionesToolStripMenuItem.Size = New System.Drawing.Size(341, 42)
        Me.DevolucionesToolStripMenuItem.Text = "Buscar salida"
        '
        'DevolucionesToolStripMenuItem1
        '
        Me.DevolucionesToolStripMenuItem1.Name = "DevolucionesToolStripMenuItem1"
        Me.DevolucionesToolStripMenuItem1.Size = New System.Drawing.Size(341, 42)
        Me.DevolucionesToolStripMenuItem1.Text = "Buscar devolución"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RepMaterialesToolStripMenuItem, Me.RepPrestamosToolStripMenuItem, Me.RepDevolucionesToolStripMenuItem, Me.RepSalidasToolStripMenuItem, Me.RepPendientesToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(177, 41)
        Me.ReportesToolStripMenuItem.Text = "5. Reportes"
        '
        'RepMaterialesToolStripMenuItem
        '
        Me.RepMaterialesToolStripMenuItem.Name = "RepMaterialesToolStripMenuItem"
        Me.RepMaterialesToolStripMenuItem.Size = New System.Drawing.Size(542, 42)
        Me.RepMaterialesToolStripMenuItem.Text = "Reporte de materiales"
        '
        'RepPrestamosToolStripMenuItem
        '
        Me.RepPrestamosToolStripMenuItem.Name = "RepPrestamosToolStripMenuItem"
        Me.RepPrestamosToolStripMenuItem.Size = New System.Drawing.Size(542, 42)
        Me.RepPrestamosToolStripMenuItem.Text = "Reporte de préstamos"
        '
        'RepDevolucionesToolStripMenuItem
        '
        Me.RepDevolucionesToolStripMenuItem.Name = "RepDevolucionesToolStripMenuItem"
        Me.RepDevolucionesToolStripMenuItem.Size = New System.Drawing.Size(542, 42)
        Me.RepDevolucionesToolStripMenuItem.Text = "Reporte de devoluciones"
        '
        'RepSalidasToolStripMenuItem
        '
        Me.RepSalidasToolStripMenuItem.Name = "RepSalidasToolStripMenuItem"
        Me.RepSalidasToolStripMenuItem.Size = New System.Drawing.Size(542, 42)
        Me.RepSalidasToolStripMenuItem.Text = "Reporte de salidas"
        '
        'RepPendientesToolStripMenuItem
        '
        Me.RepPendientesToolStripMenuItem.Name = "RepPendientesToolStripMenuItem"
        Me.RepPendientesToolStripMenuItem.Size = New System.Drawing.Size(542, 42)
        Me.RepPendientesToolStripMenuItem.Text = "Reporte de préstamos pendientes"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcercaDeToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(112, 41)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(346, 42)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca del sistema"
        '
        'SesionToolStripMenuItem
        '
        Me.SesionToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.SesionToolStripMenuItem.Enabled = False
        Me.SesionToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.SesionToolStripMenuItem.Name = "SesionToolStripMenuItem"
        Me.SesionToolStripMenuItem.Size = New System.Drawing.Size(73, 41)
        Me.SesionToolStripMenuItem.Text = "Sesión"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenimientoToolStripMenuItem, Me.MaestrosToolStripMenuItem, Me.ProcesosToolStripMenuItem, Me.ControlToolStripMenuItem, Me.CONSULTASToolStripMenuItem, Me.ReportesToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.SesionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1474, 45)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1474, 830)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripButtonRegistrarMaterial As ToolStripButton
    Friend WithEvents ToolStripButtonRegistrarPersonal As ToolStripButton
    Friend WithEvents ToolStripButtonRegistrarUsuario As ToolStripButton
    Friend WithEvents ToolStripButtonCerrarSesion As ToolStripButton
    Friend WithEvents ToolStripButtonSalir As ToolStripButton
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripButtonSolicitud As ToolStripButton
    Friend WithEvents ToolStripButtonDevoluciones As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents MantenimientoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CerrarSesionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MaestrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarMaterialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarUsuarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarPersonalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarSolicitudToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarPrestamoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarSalidaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarDevoluciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ControlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CtrlSolicitudesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CtrlDisponiblesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CtrlPrestadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CtrlPendientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CtrlDevolucionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CtrlHistorialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CONSULTASToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MaterialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuscarUsuarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuscarPrestamoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DevolucionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DevolucionesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RepMaterialesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RepPrestamosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RepDevolucionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RepSalidasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RepPendientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SesionToolStripMenuItem As ToolStripMenuItem
End Class
