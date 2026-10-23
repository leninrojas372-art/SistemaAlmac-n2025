<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReporteListado
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
        Me.ChkFechas = New System.Windows.Forms.CheckBox()
        Me.LblDesde = New System.Windows.Forms.Label()
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblHasta = New System.Windows.Forms.Label()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.BtnGenerar = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.BtnCrystal = New System.Windows.Forms.Button()
        Me.Dgv = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblResumen = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelTop.SuspendLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.LightBlue
        Me.PanelTop.Controls.Add(Me.LblTitulo)
        Me.PanelTop.Controls.Add(Me.ChkFechas)
        Me.PanelTop.Controls.Add(Me.LblDesde)
        Me.PanelTop.Controls.Add(Me.DtpDesde)
        Me.PanelTop.Controls.Add(Me.LblHasta)
        Me.PanelTop.Controls.Add(Me.DtpHasta)
        Me.PanelTop.Controls.Add(Me.LblEstado)
        Me.PanelTop.Controls.Add(Me.CmbEstado)
        Me.PanelTop.Controls.Add(Me.BtnGenerar)
        Me.PanelTop.Controls.Add(Me.BtnImprimir)
        Me.PanelTop.Controls.Add(Me.BtnExportar)
        Me.PanelTop.Controls.Add(Me.BtnCrystal)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1240, 110)
        Me.PanelTop.TabIndex = 2
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitulo.ForeColor = System.Drawing.Color.Black
        Me.LblTitulo.Location = New System.Drawing.Point(14, 8)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(133, 37)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "REPORTE"
        '
        'ChkFechas
        '
        Me.ChkFechas.AutoSize = True
        Me.ChkFechas.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ChkFechas.ForeColor = System.Drawing.Color.Black
        Me.ChkFechas.Location = New System.Drawing.Point(18, 62)
        Me.ChkFechas.Name = "ChkFechas"
        Me.ChkFechas.Size = New System.Drawing.Size(152, 27)
        Me.ChkFechas.TabIndex = 1
        Me.ChkFechas.Text = "Filtrar por fecha"
        Me.ChkFechas.UseVisualStyleBackColor = True
        '
        'LblDesde
        '
        Me.LblDesde.AutoSize = True
        Me.LblDesde.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblDesde.ForeColor = System.Drawing.Color.Black
        Me.LblDesde.Location = New System.Drawing.Point(170, 63)
        Me.LblDesde.Name = "LblDesde"
        Me.LblDesde.Size = New System.Drawing.Size(61, 23)
        Me.LblDesde.TabIndex = 2
        Me.LblDesde.Text = "Desde:"
        '
        'DtpDesde
        '
        Me.DtpDesde.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpDesde.Location = New System.Drawing.Point(230, 59)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(130, 30)
        Me.DtpDesde.TabIndex = 3
        '
        'LblHasta
        '
        Me.LblHasta.AutoSize = True
        Me.LblHasta.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblHasta.ForeColor = System.Drawing.Color.Black
        Me.LblHasta.Location = New System.Drawing.Point(366, 63)
        Me.LblHasta.Name = "LblHasta"
        Me.LblHasta.Size = New System.Drawing.Size(57, 23)
        Me.LblHasta.TabIndex = 4
        Me.LblHasta.Text = "Hasta:"
        '
        'DtpHasta
        '
        Me.DtpHasta.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpHasta.Location = New System.Drawing.Point(420, 59)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(130, 30)
        Me.DtpHasta.TabIndex = 5
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LblEstado.ForeColor = System.Drawing.Color.Black
        Me.LblEstado.Location = New System.Drawing.Point(562, 63)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(65, 23)
        Me.LblEstado.TabIndex = 6
        Me.LblEstado.Text = "Estado:"
        '
        'CmbEstado
        '
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CmbEstado.Location = New System.Drawing.Point(624, 59)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(130, 31)
        Me.CmbEstado.TabIndex = 7
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnGenerar.Location = New System.Drawing.Point(766, 57)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(100, 34)
        Me.BtnGenerar.TabIndex = 8
        Me.BtnGenerar.Text = "GENERAR"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnImprimir.Location = New System.Drawing.Point(872, 57)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(100, 34)
        Me.BtnImprimir.TabIndex = 9
        Me.BtnImprimir.Text = "IMPRIMIR"
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'BtnExportar
        '
        Me.BtnExportar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnExportar.Location = New System.Drawing.Point(978, 57)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(90, 34)
        Me.BtnExportar.TabIndex = 10
        Me.BtnExportar.Text = "EXCEL"
        Me.BtnExportar.UseVisualStyleBackColor = True
        '
        'BtnCrystal
        '
        Me.BtnCrystal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCrystal.Location = New System.Drawing.Point(1074, 57)
        Me.BtnCrystal.Name = "BtnCrystal"
        Me.BtnCrystal.Size = New System.Drawing.Size(150, 34)
        Me.BtnCrystal.TabIndex = 11
        Me.BtnCrystal.Text = "VER EN CRYSTAL"
        Me.BtnCrystal.UseVisualStyleBackColor = True
        '
        'Dgv
        '
        Me.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv.Location = New System.Drawing.Point(0, 110)
        Me.Dgv.Name = "Dgv"
        Me.Dgv.RowHeadersWidth = 51
        Me.Dgv.Size = New System.Drawing.Size(1240, 511)
        Me.Dgv.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblResumen})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 621)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1240, 29)
        Me.StatusStrip1.TabIndex = 1
        '
        'LblResumen
        '
        Me.LblResumen.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblResumen.Name = "LblResumen"
        Me.LblResumen.Size = New System.Drawing.Size(48, 23)
        Me.LblResumen.Text = "Listo"
        '
        'FrmReporteListado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 650)
        Me.Controls.Add(Me.Dgv)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "FrmReporteListado"
        Me.Text = "Reporte"
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        CType(Me.Dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelTop As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents ChkFechas As CheckBox
    Friend WithEvents LblDesde As Label
    Friend WithEvents DtpDesde As DateTimePicker
    Friend WithEvents LblHasta As Label
    Friend WithEvents DtpHasta As DateTimePicker
    Friend WithEvents LblEstado As Label
    Friend WithEvents CmbEstado As ComboBox
    Friend WithEvents BtnGenerar As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents BtnExportar As Button
    Friend WithEvents BtnCrystal As Button
    Friend WithEvents Dgv As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblResumen As ToolStripStatusLabel
End Class
