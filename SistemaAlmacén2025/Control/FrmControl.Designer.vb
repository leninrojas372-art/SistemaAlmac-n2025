<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControl
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.LblAyuda = New System.Windows.Forms.Label()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnActualizar = New System.Windows.Forms.Button()
        Me.TxtFiltro = New System.Windows.Forms.TextBox()
        Me.LblBuscar = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabDisponibles = New System.Windows.Forms.TabPage()
        Me.DgvDisponibles = New System.Windows.Forms.DataGridView()
        Me.TabPrestados = New System.Windows.Forms.TabPage()
        Me.DgvPrestados = New System.Windows.Forms.DataGridView()
        Me.TabPendientes = New System.Windows.Forms.TabPage()
        Me.DgvPendientes = New System.Windows.Forms.DataGridView()
        Me.TabDevoluciones = New System.Windows.Forms.TabPage()
        Me.DgvDevoluciones = New System.Windows.Forms.DataGridView()
        Me.TabHistorial = New System.Windows.Forms.TabPage()
        Me.DgvHistorial = New System.Windows.Forms.DataGridView()
        Me.TabSolicitudes = New System.Windows.Forms.TabPage()
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblResumen = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelTop.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabDisponibles.SuspendLayout()
        CType(Me.DgvDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPrestados.SuspendLayout()
        CType(Me.DgvPrestados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPendientes.SuspendLayout()
        CType(Me.DgvPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDevoluciones.SuspendLayout()
        CType(Me.DgvDevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabHistorial.SuspendLayout()
        CType(Me.DgvHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSolicitudes.SuspendLayout()
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.LightBlue
        Me.PanelTop.Controls.Add(Me.LblAyuda)
        Me.PanelTop.Controls.Add(Me.BtnExportar)
        Me.PanelTop.Controls.Add(Me.BtnImprimir)
        Me.PanelTop.Controls.Add(Me.BtnActualizar)
        Me.PanelTop.Controls.Add(Me.TxtFiltro)
        Me.PanelTop.Controls.Add(Me.LblBuscar)
        Me.PanelTop.Controls.Add(Me.LblTitulo)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1100, 110)
        Me.PanelTop.TabIndex = 0
        '
        'LblAyuda
        '
        Me.LblAyuda.AutoSize = True
        Me.LblAyuda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.LblAyuda.ForeColor = System.Drawing.Color.Black
        Me.LblAyuda.Location = New System.Drawing.Point(84, 89)
        Me.LblAyuda.Name = "LblAyuda"
        Me.LblAyuda.Size = New System.Drawing.Size(126, 20)
        Me.LblAyuda.TabIndex = 6
        Me.LblAyuda.Text = "Escriba para filtrar"
        '
        'BtnExportar
        '
        Me.BtnExportar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnExportar.Location = New System.Drawing.Point(678, 53)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(120, 34)
        Me.BtnExportar.TabIndex = 5
        Me.BtnExportar.Text = "EXCEL"
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnImprimir.Location = New System.Drawing.Point(552, 53)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(120, 34)
        Me.BtnImprimir.TabIndex = 4
        Me.BtnImprimir.Text = "IMPRIMIR"
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnActualizar.Location = New System.Drawing.Point(426, 53)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(120, 34)
        Me.BtnActualizar.TabIndex = 3
        Me.BtnActualizar.Text = "ACTUALIZAR"
        Me.BtnActualizar.UseVisualStyleBackColor = True
        '
        'TxtFiltro
        '
        Me.TxtFiltro.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.TxtFiltro.Location = New System.Drawing.Point(84, 54)
        Me.TxtFiltro.Name = "TxtFiltro"
        Me.TxtFiltro.Size = New System.Drawing.Size(330, 32)
        Me.TxtFiltro.TabIndex = 2
        '
        'LblBuscar
        '
        Me.LblBuscar.AutoSize = True
        Me.LblBuscar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblBuscar.ForeColor = System.Drawing.Color.Black
        Me.LblBuscar.Location = New System.Drawing.Point(16, 58)
        Me.LblBuscar.Name = "LblBuscar"
        Me.LblBuscar.Size = New System.Drawing.Size(64, 23)
        Me.LblBuscar.TabIndex = 1
        Me.LblBuscar.Text = "Buscar:"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitulo.ForeColor = System.Drawing.Color.Black
        Me.LblTitulo.Location = New System.Drawing.Point(14, 8)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(321, 37)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "CONTROL DE ALMACÉN"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabDisponibles)
        Me.TabControl1.Controls.Add(Me.TabPrestados)
        Me.TabControl1.Controls.Add(Me.TabPendientes)
        Me.TabControl1.Controls.Add(Me.TabDevoluciones)
        Me.TabControl1.Controls.Add(Me.TabHistorial)
        Me.TabControl1.Controls.Add(Me.TabSolicitudes)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 110)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1100, 461)
        Me.TabControl1.TabIndex = 1
        '
        'TabDisponibles
        '
        Me.TabDisponibles.Controls.Add(Me.DgvDisponibles)
        Me.TabDisponibles.Location = New System.Drawing.Point(4, 32)
        Me.TabDisponibles.Name = "TabDisponibles"
        Me.TabDisponibles.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDisponibles.Size = New System.Drawing.Size(1092, 425)
        Me.TabDisponibles.TabIndex = 0
        Me.TabDisponibles.Text = "Materiales disponibles"
        Me.TabDisponibles.UseVisualStyleBackColor = True
        '
        'DgvDisponibles
        '
        Me.DgvDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDisponibles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDisponibles.Location = New System.Drawing.Point(3, 3)
        Me.DgvDisponibles.Name = "DgvDisponibles"
        Me.DgvDisponibles.RowHeadersWidth = 51
        Me.DgvDisponibles.Size = New System.Drawing.Size(1086, 419)
        Me.DgvDisponibles.TabIndex = 0
        '
        'TabPrestados
        '
        Me.TabPrestados.Controls.Add(Me.DgvPrestados)
        Me.TabPrestados.Location = New System.Drawing.Point(4, 32)
        Me.TabPrestados.Name = "TabPrestados"
        Me.TabPrestados.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPrestados.Size = New System.Drawing.Size(1092, 428)
        Me.TabPrestados.TabIndex = 1
        Me.TabPrestados.Text = "Materiales prestados"
        Me.TabPrestados.UseVisualStyleBackColor = True
        '
        'DgvPrestados
        '
        Me.DgvPrestados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPrestados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPrestados.Location = New System.Drawing.Point(3, 3)
        Me.DgvPrestados.Name = "DgvPrestados"
        Me.DgvPrestados.RowHeadersWidth = 51
        Me.DgvPrestados.Size = New System.Drawing.Size(1086, 422)
        Me.DgvPrestados.TabIndex = 0
        '
        'TabPendientes
        '
        Me.TabPendientes.Controls.Add(Me.DgvPendientes)
        Me.TabPendientes.Location = New System.Drawing.Point(4, 32)
        Me.TabPendientes.Name = "TabPendientes"
        Me.TabPendientes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPendientes.Size = New System.Drawing.Size(1092, 428)
        Me.TabPendientes.TabIndex = 2
        Me.TabPendientes.Text = "Préstamos pendientes"
        Me.TabPendientes.UseVisualStyleBackColor = True
        '
        'DgvPendientes
        '
        Me.DgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPendientes.Location = New System.Drawing.Point(3, 3)
        Me.DgvPendientes.Name = "DgvPendientes"
        Me.DgvPendientes.RowHeadersWidth = 51
        Me.DgvPendientes.Size = New System.Drawing.Size(1086, 422)
        Me.DgvPendientes.TabIndex = 0
        '
        'TabDevoluciones
        '
        Me.TabDevoluciones.Controls.Add(Me.DgvDevoluciones)
        Me.TabDevoluciones.Location = New System.Drawing.Point(4, 32)
        Me.TabDevoluciones.Name = "TabDevoluciones"
        Me.TabDevoluciones.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDevoluciones.Size = New System.Drawing.Size(1092, 428)
        Me.TabDevoluciones.TabIndex = 3
        Me.TabDevoluciones.Text = "Devoluciones"
        Me.TabDevoluciones.UseVisualStyleBackColor = True
        '
        'DgvDevoluciones
        '
        Me.DgvDevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDevoluciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDevoluciones.Location = New System.Drawing.Point(3, 3)
        Me.DgvDevoluciones.Name = "DgvDevoluciones"
        Me.DgvDevoluciones.RowHeadersWidth = 51
        Me.DgvDevoluciones.Size = New System.Drawing.Size(1086, 422)
        Me.DgvDevoluciones.TabIndex = 0
        '
        'TabHistorial
        '
        Me.TabHistorial.Controls.Add(Me.DgvHistorial)
        Me.TabHistorial.Location = New System.Drawing.Point(4, 32)
        Me.TabHistorial.Name = "TabHistorial"
        Me.TabHistorial.Padding = New System.Windows.Forms.Padding(3)
        Me.TabHistorial.Size = New System.Drawing.Size(1092, 428)
        Me.TabHistorial.TabIndex = 4
        Me.TabHistorial.Text = "Historial por usuario"
        Me.TabHistorial.UseVisualStyleBackColor = True
        '
        'DgvHistorial
        '
        Me.DgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvHistorial.Location = New System.Drawing.Point(3, 3)
        Me.DgvHistorial.Name = "DgvHistorial"
        Me.DgvHistorial.RowHeadersWidth = 51
        Me.DgvHistorial.Size = New System.Drawing.Size(1086, 422)
        Me.DgvHistorial.TabIndex = 0
        '
        'TabSolicitudes
        '
        Me.TabSolicitudes.Controls.Add(Me.DgvSolicitudes)
        Me.TabSolicitudes.Location = New System.Drawing.Point(4, 32)
        Me.TabSolicitudes.Name = "TabSolicitudes"
        Me.TabSolicitudes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSolicitudes.Size = New System.Drawing.Size(1092, 428)
        Me.TabSolicitudes.TabIndex = 5
        Me.TabSolicitudes.Text = "Solicitudes pendientes"
        Me.TabSolicitudes.UseVisualStyleBackColor = True
        '
        'DgvSolicitudes
        '
        Me.DgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvSolicitudes.Location = New System.Drawing.Point(3, 3)
        Me.DgvSolicitudes.Name = "DgvSolicitudes"
        Me.DgvSolicitudes.RowHeadersWidth = 51
        Me.DgvSolicitudes.Size = New System.Drawing.Size(1086, 422)
        Me.DgvSolicitudes.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblResumen})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 571)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1100, 29)
        Me.StatusStrip1.TabIndex = 2
        '
        'LblResumen
        '
        Me.LblResumen.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblResumen.Name = "LblResumen"
        Me.LblResumen.Size = New System.Drawing.Size(48, 23)
        Me.LblResumen.Text = "Listo"
        '
        'FrmControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 600)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "FrmControl"
        Me.Text = "Control de almacén"
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabDisponibles.ResumeLayout(False)
        CType(Me.DgvDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPrestados.ResumeLayout(False)
        CType(Me.DgvPrestados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPendientes.ResumeLayout(False)
        CType(Me.DgvPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDevoluciones.ResumeLayout(False)
        CType(Me.DgvDevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabHistorial.ResumeLayout(False)
        CType(Me.DgvHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSolicitudes.ResumeLayout(False)
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelTop As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents LblBuscar As Label
    Friend WithEvents TxtFiltro As TextBox
    Friend WithEvents BtnActualizar As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents BtnExportar As Button
    Friend WithEvents LblAyuda As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabDisponibles As TabPage
    Friend WithEvents DgvDisponibles As DataGridView
    Friend WithEvents TabPrestados As TabPage
    Friend WithEvents DgvPrestados As DataGridView
    Friend WithEvents TabPendientes As TabPage
    Friend WithEvents DgvPendientes As DataGridView
    Friend WithEvents TabDevoluciones As TabPage
    Friend WithEvents DgvDevoluciones As DataGridView
    Friend WithEvents TabHistorial As TabPage
    Friend WithEvents DgvHistorial As DataGridView
    Friend WithEvents TabSolicitudes As TabPage
    Friend WithEvents DgvSolicitudes As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblResumen As ToolStripStatusLabel
End Class
