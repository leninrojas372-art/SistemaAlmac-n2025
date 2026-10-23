<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConsulta_Prestamo
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
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.BtnDevolver = New System.Windows.Forms.Button()
        Me.LblAyuda = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DgvPrestamos = New System.Windows.Forms.DataGridView()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.DgvDetalle = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblResumen = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelTop.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgvPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.DgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.LightBlue
        Me.PanelTop.Controls.Add(Me.LblTitulo)
        Me.PanelTop.Controls.Add(Me.LblBuscar)
        Me.PanelTop.Controls.Add(Me.TxtBuscar)
        Me.PanelTop.Controls.Add(Me.LblEstado)
        Me.PanelTop.Controls.Add(Me.CmbEstado)
        Me.PanelTop.Controls.Add(Me.BtnImprimir)
        Me.PanelTop.Controls.Add(Me.BtnExportar)
        Me.PanelTop.Controls.Add(Me.BtnDevolver)
        Me.PanelTop.Controls.Add(Me.LblAyuda)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1100, 103)
        Me.PanelTop.TabIndex = 2
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitulo.ForeColor = System.Drawing.Color.Black
        Me.LblTitulo.Location = New System.Drawing.Point(14, 8)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(273, 37)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "BUSCAR PRÉSTAMO"
        '
        'LblBuscar
        '
        Me.LblBuscar.AutoSize = True
        Me.LblBuscar.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblBuscar.ForeColor = System.Drawing.Color.Black
        Me.LblBuscar.Location = New System.Drawing.Point(16, 56)
        Me.LblBuscar.Name = "LblBuscar"
        Me.LblBuscar.Size = New System.Drawing.Size(64, 23)
        Me.LblBuscar.TabIndex = 1
        Me.LblBuscar.Text = "Buscar:"
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.TxtBuscar.Location = New System.Drawing.Point(84, 52)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(300, 32)
        Me.TxtBuscar.TabIndex = 2
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblEstado.ForeColor = System.Drawing.Color.Black
        Me.LblEstado.Location = New System.Drawing.Point(396, 56)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(65, 23)
        Me.LblEstado.TabIndex = 3
        Me.LblEstado.Text = "Estado:"
        '
        'CmbEstado
        '
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.CmbEstado.Location = New System.Drawing.Point(460, 52)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(140, 33)
        Me.CmbEstado.TabIndex = 4
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnImprimir.Location = New System.Drawing.Point(612, 51)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(120, 34)
        Me.BtnImprimir.TabIndex = 5
        Me.BtnImprimir.Text = "IMPRIMIR"
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'BtnExportar
        '
        Me.BtnExportar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnExportar.Location = New System.Drawing.Point(738, 51)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(120, 34)
        Me.BtnExportar.TabIndex = 6
        Me.BtnExportar.Text = "EXCEL"
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'BtnDevolver
        '
        Me.BtnDevolver.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnDevolver.Location = New System.Drawing.Point(864, 51)
        Me.BtnDevolver.Name = "BtnDevolver"
        Me.BtnDevolver.Size = New System.Drawing.Size(200, 34)
        Me.BtnDevolver.TabIndex = 7
        Me.BtnDevolver.Text = "REGISTRAR DEVOLUCIÓN"
        Me.BtnDevolver.UseVisualStyleBackColor = True
        '
        'LblAyuda
        '
        Me.LblAyuda.AutoSize = True
        Me.LblAyuda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.LblAyuda.ForeColor = System.Drawing.Color.Black
        Me.LblAyuda.Location = New System.Drawing.Point(80, 80)
        Me.LblAyuda.Name = "LblAyuda"
        Me.LblAyuda.Size = New System.Drawing.Size(496, 20)
        Me.LblAyuda.TabIndex = 8
        Me.LblAyuda.Text = "Busque por N° de préstamo, DNI, nombre del usuario o nombre del material."
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 103)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvPrestamos)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GrpDetalle)
        Me.SplitContainer1.Size = New System.Drawing.Size(1100, 518)
        Me.SplitContainer1.SplitterDistance = 296
        Me.SplitContainer1.TabIndex = 0
        '
        'DgvPrestamos
        '
        Me.DgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPrestamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPrestamos.Location = New System.Drawing.Point(0, 0)
        Me.DgvPrestamos.Name = "DgvPrestamos"
        Me.DgvPrestamos.RowHeadersWidth = 51
        Me.DgvPrestamos.Size = New System.Drawing.Size(1100, 296)
        Me.DgvPrestamos.TabIndex = 0
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Controls.Add(Me.DgvDetalle)
        Me.GrpDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpDetalle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GrpDetalle.Location = New System.Drawing.Point(0, 0)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(1100, 218)
        Me.GrpDetalle.TabIndex = 0
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Materiales del préstamo seleccionado"
        '
        'DgvDetalle
        '
        Me.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDetalle.Location = New System.Drawing.Point(3, 26)
        Me.DgvDetalle.Name = "DgvDetalle"
        Me.DgvDetalle.RowHeadersWidth = 51
        Me.DgvDetalle.Size = New System.Drawing.Size(1094, 189)
        Me.DgvDetalle.TabIndex = 0
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
        'FrmConsulta_Prestamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 650)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "FrmConsulta_Prestamo"
        Me.Text = "Buscar préstamo"
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgvPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.DgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelTop As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents LblBuscar As Label
    Friend WithEvents TxtBuscar As TextBox
    Friend WithEvents LblEstado As Label
    Friend WithEvents CmbEstado As ComboBox
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents BtnExportar As Button
    Friend WithEvents BtnDevolver As Button
    Friend WithEvents LblAyuda As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DgvPrestamos As DataGridView
    Friend WithEvents GrpDetalle As GroupBox
    Friend WithEvents DgvDetalle As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblResumen As ToolStripStatusLabel
End Class
