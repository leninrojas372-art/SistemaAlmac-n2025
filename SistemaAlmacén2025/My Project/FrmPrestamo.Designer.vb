<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrestamo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnRegistrarPrestamo = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DataGridView_01 = New System.Windows.Forms.DataGridView()
        Me.IdDetallePrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnSiguiente = New System.Windows.Forms.Button()
        Me.btnCargarLista = New System.Windows.Forms.Button()
        Me.TxtCantidad = New System.Windows.Forms.TextBox()
        Me.TxtIdMaterial = New System.Windows.Forms.TextBox()
        Me.TxtId_Prestamo = New System.Windows.Forms.TextBox()
        Me.TxtIdDetallePrestamo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.BtnAgregarDetalle = New System.Windows.Forms.Button()
        Me.TxtId_Solicitud = New System.Windows.Forms.TextBox()
        Me.TxtDNI_Usuario = New System.Windows.Forms.TextBox()
        Me.TxtIdPrestamo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView_01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1175, 798)
        Me.Panel1.TabIndex = 18
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1175, 798)
        Me.Panel2.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox4.Controls.Add(Me.BtnRegistrarPrestamo)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 708)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(1175, 90)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        '
        'BtnRegistrarPrestamo
        '
        Me.BtnRegistrarPrestamo.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnRegistrarPrestamo.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegistrarPrestamo.Location = New System.Drawing.Point(373, 12)
        Me.BtnRegistrarPrestamo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnRegistrarPrestamo.Name = "BtnRegistrarPrestamo"
        Me.BtnRegistrarPrestamo.Size = New System.Drawing.Size(392, 63)
        Me.BtnRegistrarPrestamo.TabIndex = 17
        Me.BtnRegistrarPrestamo.Text = "REGISTRAR PRÉSTAMO"
        Me.BtnRegistrarPrestamo.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox3.Controls.Add(Me.DataGridView_01)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Palatino Linotype", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 362)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(1175, 436)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle del Préstamo:"
        '
        'DataGridView_01
        '
        Me.DataGridView_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_01.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDetallePrestamo, Me.IdPrestamo, Me.IdMaterial, Me.Cantidad})
        Me.DataGridView_01.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_01.Location = New System.Drawing.Point(3, 34)
        Me.DataGridView_01.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView_01.Name = "DataGridView_01"
        Me.DataGridView_01.RowHeadersWidth = 51
        Me.DataGridView_01.RowTemplate.Height = 24
        Me.DataGridView_01.Size = New System.Drawing.Size(1169, 400)
        Me.DataGridView_01.TabIndex = 0
        '
        'IdDetallePrestamo
        '
        Me.IdDetallePrestamo.HeaderText = "IdDetallePrestamo"
        Me.IdDetallePrestamo.MinimumWidth = 6
        Me.IdDetallePrestamo.Name = "IdDetallePrestamo"
        Me.IdDetallePrestamo.Width = 125
        '
        'IdPrestamo
        '
        Me.IdPrestamo.HeaderText = "IdPrestamo"
        Me.IdPrestamo.MinimumWidth = 6
        Me.IdPrestamo.Name = "IdPrestamo"
        Me.IdPrestamo.Width = 125
        '
        'IdMaterial
        '
        Me.IdMaterial.HeaderText = "IdMaterial"
        Me.IdMaterial.MinimumWidth = 6
        Me.IdMaterial.Name = "IdMaterial"
        Me.IdMaterial.Width = 125
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.MinimumWidth = 6
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 125
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox2.Controls.Add(Me.BtnSiguiente)
        Me.GroupBox2.Controls.Add(Me.btnCargarLista)
        Me.GroupBox2.Controls.Add(Me.TxtCantidad)
        Me.GroupBox2.Controls.Add(Me.TxtIdMaterial)
        Me.GroupBox2.Controls.Add(Me.TxtId_Prestamo)
        Me.GroupBox2.Controls.Add(Me.TxtIdDetallePrestamo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 187)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(1175, 175)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Detalle Préstamo:"
        '
        'BtnSiguiente
        '
        Me.BtnSiguiente.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnSiguiente.Location = New System.Drawing.Point(889, 103)
        Me.BtnSiguiente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSiguiente.Name = "BtnSiguiente"
        Me.BtnSiguiente.Size = New System.Drawing.Size(193, 65)
        Me.BtnSiguiente.TabIndex = 17
        Me.BtnSiguiente.Text = "->"
        Me.BtnSiguiente.UseVisualStyleBackColor = False
        '
        'btnCargarLista
        '
        Me.btnCargarLista.BackColor = System.Drawing.Color.SkyBlue
        Me.btnCargarLista.Location = New System.Drawing.Point(853, 15)
        Me.btnCargarLista.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCargarLista.Name = "btnCargarLista"
        Me.btnCargarLista.Size = New System.Drawing.Size(268, 86)
        Me.btnCargarLista.TabIndex = 16
        Me.btnCargarLista.Text = "CARGAR A LA LISTA"
        Me.btnCargarLista.UseVisualStyleBackColor = False
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(675, 113)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(141, 44)
        Me.TxtCantidad.TabIndex = 16
        '
        'TxtIdMaterial
        '
        Me.TxtIdMaterial.Location = New System.Drawing.Point(675, 39)
        Me.TxtIdMaterial.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtIdMaterial.Name = "TxtIdMaterial"
        Me.TxtIdMaterial.Size = New System.Drawing.Size(141, 44)
        Me.TxtIdMaterial.TabIndex = 15
        '
        'TxtId_Prestamo
        '
        Me.TxtId_Prestamo.Location = New System.Drawing.Point(309, 113)
        Me.TxtId_Prestamo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtId_Prestamo.Name = "TxtId_Prestamo"
        Me.TxtId_Prestamo.Size = New System.Drawing.Size(141, 44)
        Me.TxtId_Prestamo.TabIndex = 14
        '
        'TxtIdDetallePrestamo
        '
        Me.TxtIdDetallePrestamo.Enabled = False
        Me.TxtIdDetallePrestamo.Location = New System.Drawing.Point(309, 39)
        Me.TxtIdDetallePrestamo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtIdDetallePrestamo.Name = "TxtIdDetallePrestamo"
        Me.TxtIdDetallePrestamo.Size = New System.Drawing.Size(141, 44)
        Me.TxtIdDetallePrestamo.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.SkyBlue
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(516, 113)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 38)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Cantidad:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.SkyBlue
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(484, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(173, 38)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "ID Material:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(115, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 38)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ID Préstamo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.SkyBlue
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(16, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(282, 38)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "ID Detalle Préstamo:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.BtnAgregarDetalle)
        Me.GroupBox1.Controls.Add(Me.TxtId_Solicitud)
        Me.GroupBox1.Controls.Add(Me.TxtDNI_Usuario)
        Me.GroupBox1.Controls.Add(Me.TxtIdPrestamo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(1175, 187)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(621, 118)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(203, 44)
        Me.DateTimePicker1.TabIndex = 16
        '
        'BtnAgregarDetalle
        '
        Me.BtnAgregarDetalle.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnAgregarDetalle.Location = New System.Drawing.Point(889, 55)
        Me.BtnAgregarDetalle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnAgregarDetalle.Name = "BtnAgregarDetalle"
        Me.BtnAgregarDetalle.Size = New System.Drawing.Size(213, 96)
        Me.BtnAgregarDetalle.TabIndex = 15
        Me.BtnAgregarDetalle.Text = "AGREGAR DETALLE"
        Me.BtnAgregarDetalle.UseVisualStyleBackColor = False
        '
        'TxtId_Solicitud
        '
        Me.TxtId_Solicitud.Location = New System.Drawing.Point(621, 38)
        Me.TxtId_Solicitud.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtId_Solicitud.Name = "TxtId_Solicitud"
        Me.TxtId_Solicitud.Size = New System.Drawing.Size(167, 44)
        Me.TxtId_Solicitud.TabIndex = 13
        '
        'TxtDNI_Usuario
        '
        Me.TxtDNI_Usuario.Location = New System.Drawing.Point(220, 121)
        Me.TxtDNI_Usuario.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtDNI_Usuario.Name = "TxtDNI_Usuario"
        Me.TxtDNI_Usuario.Size = New System.Drawing.Size(167, 44)
        Me.TxtDNI_Usuario.TabIndex = 12
        '
        'TxtIdPrestamo
        '
        Me.TxtIdPrestamo.Location = New System.Drawing.Point(219, 38)
        Me.TxtIdPrestamo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtIdPrestamo.Name = "TxtIdPrestamo"
        Me.TxtIdPrestamo.Size = New System.Drawing.Size(167, 44)
        Me.TxtIdPrestamo.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Location = New System.Drawing.Point(419, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(180, 38)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ID Solicitud:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(502, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 38)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(75, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 38)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Personal:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(24, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 38)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "ID Préstamo:"
        '
        'FrmPrestamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 798)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FrmPrestamo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPrestamo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGridView_01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BtnRegistrarPrestamo As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DataGridView_01 As DataGridView
    Friend WithEvents IdDetallePrestamo As DataGridViewTextBoxColumn
    Friend WithEvents IdPrestamo As DataGridViewTextBoxColumn
    Friend WithEvents IdMaterial As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnSiguiente As Button
    Friend WithEvents btnCargarLista As Button
    Friend WithEvents TxtCantidad As TextBox
    Friend WithEvents TxtIdMaterial As TextBox
    Friend WithEvents TxtId_Prestamo As TextBox
    Friend WithEvents TxtIdDetallePrestamo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents BtnAgregarDetalle As Button
    Friend WithEvents TxtId_Solicitud As TextBox
    Friend WithEvents TxtDNI_Usuario As TextBox
    Friend WithEvents TxtIdPrestamo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
