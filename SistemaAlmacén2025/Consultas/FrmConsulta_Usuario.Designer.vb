<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConsulta_Usuario
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
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.LblBuscar = New System.Windows.Forms.Label()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.LblAyuda = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabTiene = New System.Windows.Forms.TabPage()
        Me.DgvTiene = New System.Windows.Forms.DataGridView()
        Me.TabHistorial = New System.Windows.Forms.TabPage()
        Me.DgvHistorial = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblResumen = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelTop.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabTiene.SuspendLayout()
        CType(Me.DgvTiene, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabHistorial.SuspendLayout()
        CType(Me.DgvHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.LightBlue
        Me.PanelTop.Controls.Add(Me.LblTitulo)
        Me.PanelTop.Controls.Add(Me.LblBuscar)
        Me.PanelTop.Controls.Add(Me.TxtBuscar)
        Me.PanelTop.Controls.Add(Me.BtnImprimir)
        Me.PanelTop.Controls.Add(Me.BtnExportar)
        Me.PanelTop.Controls.Add(Me.LblAyuda)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1100, 100)
        Me.PanelTop.TabIndex = 2
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitulo.ForeColor = System.Drawing.Color.Black
        Me.LblTitulo.Location = New System.Drawing.Point(14, 8)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(250, 37)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "BUSCAR USUARIO"
        '
        'LblBuscar
        '
        Me.LblBuscar.AutoSize = True
        Me.LblBuscar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblBuscar.ForeColor = System.Drawing.Color.Black
        Me.LblBuscar.Location = New System.Drawing.Point(16, 56)
        Me.LblBuscar.Name = "LblBuscar"
        Me.LblBuscar.Size = New System.Drawing.Size(124, 23)
        Me.LblBuscar.TabIndex = 1
        Me.LblBuscar.Text = "DNI o nombre:"
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.TxtBuscar.Location = New System.Drawing.Point(146, 51)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(330, 32)
        Me.TxtBuscar.TabIndex = 2
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnImprimir.Location = New System.Drawing.Point(495, 51)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(120, 34)
        Me.BtnImprimir.TabIndex = 3
        Me.BtnImprimir.Text = "IMPRIMIR"
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'BtnExportar
        '
        Me.BtnExportar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnExportar.Location = New System.Drawing.Point(621, 51)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(120, 34)
        Me.BtnExportar.TabIndex = 4
        Me.BtnExportar.Text = "EXCEL"
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'LblAyuda
        '
        Me.LblAyuda.AutoSize = True
        Me.LblAyuda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.LblAyuda.ForeColor = System.Drawing.Color.Black
        Me.LblAyuda.Location = New System.Drawing.Point(130, 80)
        Me.LblAyuda.Name = "LblAyuda"
        Me.LblAyuda.Size = New System.Drawing.Size(497, 20)
        Me.LblAyuda.TabIndex = 5
        Me.LblAyuda.Text = "Seleccione un usuario para ver qué materiales tiene ahora y todo su historial."
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 100)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvUsuarios)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1100, 521)
        Me.SplitContainer1.SplitterDistance = 218
        Me.SplitContainer1.TabIndex = 0
        '
        'DgvUsuarios
        '
        Me.DgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvUsuarios.Location = New System.Drawing.Point(0, 0)
        Me.DgvUsuarios.Name = "DgvUsuarios"
        Me.DgvUsuarios.RowHeadersWidth = 51
        Me.DgvUsuarios.Size = New System.Drawing.Size(1100, 218)
        Me.DgvUsuarios.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabTiene)
        Me.TabControl1.Controls.Add(Me.TabHistorial)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1100, 299)
        Me.TabControl1.TabIndex = 0
        '
        'TabTiene
        '
        Me.TabTiene.Controls.Add(Me.DgvTiene)
        Me.TabTiene.Location = New System.Drawing.Point(4, 32)
        Me.TabTiene.Name = "TabTiene"
        Me.TabTiene.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTiene.Size = New System.Drawing.Size(1092, 263)
        Me.TabTiene.TabIndex = 0
        Me.TabTiene.Text = "Materiales que tiene ahora"
        Me.TabTiene.UseVisualStyleBackColor = True
        '
        'DgvTiene
        '
        Me.DgvTiene.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTiene.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTiene.Location = New System.Drawing.Point(3, 3)
        Me.DgvTiene.Name = "DgvTiene"
        Me.DgvTiene.RowHeadersWidth = 51
        Me.DgvTiene.Size = New System.Drawing.Size(1086, 257)
        Me.DgvTiene.TabIndex = 0
        '
        'TabHistorial
        '
        Me.TabHistorial.Controls.Add(Me.DgvHistorial)
        Me.TabHistorial.Location = New System.Drawing.Point(4, 32)
        Me.TabHistorial.Name = "TabHistorial"
        Me.TabHistorial.Padding = New System.Windows.Forms.Padding(3)
        Me.TabHistorial.Size = New System.Drawing.Size(1092, 264)
        Me.TabHistorial.TabIndex = 1
        Me.TabHistorial.Text = "Historial completo"
        Me.TabHistorial.UseVisualStyleBackColor = True
        '
        'DgvHistorial
        '
        Me.DgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvHistorial.Location = New System.Drawing.Point(3, 3)
        Me.DgvHistorial.Name = "DgvHistorial"
        Me.DgvHistorial.RowHeadersWidth = 51
        Me.DgvHistorial.Size = New System.Drawing.Size(1086, 258)
        Me.DgvHistorial.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblResumen})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 621)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1100, 29)
        Me.StatusStrip1.TabIndex = 1
        '
        'LblResumen
        '
        Me.LblResumen.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblResumen.Name = "LblResumen"
        Me.LblResumen.Size = New System.Drawing.Size(48, 23)
        Me.LblResumen.Text = "Listo"
        '
        'FrmConsulta_Usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "FrmConsulta_Usuario"
        Me.Text = "Buscar usuario"
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabTiene.ResumeLayout(False)
        CType(Me.DgvTiene, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabHistorial.ResumeLayout(False)
        CType(Me.DgvHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelTop As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents LblBuscar As Label
    Friend WithEvents TxtBuscar As TextBox
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents BtnExportar As Button
    Friend WithEvents LblAyuda As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DgvUsuarios As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabTiene As TabPage
    Friend WithEvents DgvTiene As DataGridView
    Friend WithEvents TabHistorial As TabPage
    Friend WithEvents DgvHistorial As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblResumen As ToolStripStatusLabel
End Class
