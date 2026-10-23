<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSalidas
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnregistrar_salida = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DataGridView02 = New System.Windows.Forms.DataGridView()
        Me.IDDetalleSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btncargar_salida = New System.Windows.Forms.Button()
        Me.Btn_siguiente = New System.Windows.Forms.Button()
        Me.TxtCantidad1 = New System.Windows.Forms.TextBox()
        Me.Txt_Salida = New System.Windows.Forms.TextBox()
        Me.TxtIdMaterial_1 = New System.Windows.Forms.TextBox()
        Me.TxtIdDetalleSalida = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtid_solicitud = New System.Windows.Forms.TextBox()
        Me.btnagregar_detallesalida = New System.Windows.Forms.Button()
        Me.Txtdni_personal = New System.Windows.Forms.TextBox()
        Me.txtsalida = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1305, 807)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox4.Controls.Add(Me.btnregistrar_salida)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 717)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(1305, 90)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        '
        'btnregistrar_salida
        '
        Me.btnregistrar_salida.BackColor = System.Drawing.Color.SkyBlue
        Me.btnregistrar_salida.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnregistrar_salida.Location = New System.Drawing.Point(481, 21)
        Me.btnregistrar_salida.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnregistrar_salida.Name = "btnregistrar_salida"
        Me.btnregistrar_salida.Size = New System.Drawing.Size(392, 63)
        Me.btnregistrar_salida.TabIndex = 17
        Me.btnregistrar_salida.Text = "REGISTRAR SALIDA"
        Me.btnregistrar_salida.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox3.Controls.Add(Me.DataGridView02)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Palatino Linotype", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 365)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(1305, 442)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle del Salida :"
        '
        'DataGridView02
        '
        Me.DataGridView02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView02.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDetalleSalida, Me.IDSalida, Me.IDMaterial, Me.Cantidad})
        Me.DataGridView02.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView02.Location = New System.Drawing.Point(3, 34)
        Me.DataGridView02.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView02.Name = "DataGridView02"
        Me.DataGridView02.RowHeadersWidth = 51
        Me.DataGridView02.RowTemplate.Height = 24
        Me.DataGridView02.Size = New System.Drawing.Size(1299, 406)
        Me.DataGridView02.TabIndex = 0
        '
        'IDDetalleSalida
        '
        Me.IDDetalleSalida.HeaderText = "IDDetalleSalida"
        Me.IDDetalleSalida.MinimumWidth = 6
        Me.IDDetalleSalida.Name = "IDDetalleSalida"
        Me.IDDetalleSalida.Width = 125
        '
        'IDSalida
        '
        Me.IDSalida.HeaderText = "IDSalida"
        Me.IDSalida.MinimumWidth = 6
        Me.IDSalida.Name = "IDSalida"
        Me.IDSalida.Width = 125
        '
        'IDMaterial
        '
        Me.IDMaterial.HeaderText = "IDMaterial"
        Me.IDMaterial.MinimumWidth = 6
        Me.IDMaterial.Name = "IDMaterial"
        Me.IDMaterial.Width = 125
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
        Me.GroupBox2.Controls.Add(Me.btncargar_salida)
        Me.GroupBox2.Controls.Add(Me.Btn_siguiente)
        Me.GroupBox2.Controls.Add(Me.TxtCantidad1)
        Me.GroupBox2.Controls.Add(Me.Txt_Salida)
        Me.GroupBox2.Controls.Add(Me.TxtIdMaterial_1)
        Me.GroupBox2.Controls.Add(Me.TxtIdDetalleSalida)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 190)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(1305, 175)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Detalle Salida :"
        '
        'btncargar_salida
        '
        Me.btncargar_salida.BackColor = System.Drawing.Color.SkyBlue
        Me.btncargar_salida.Location = New System.Drawing.Point(927, 26)
        Me.btncargar_salida.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btncargar_salida.Name = "btncargar_salida"
        Me.btncargar_salida.Size = New System.Drawing.Size(317, 76)
        Me.btncargar_salida.TabIndex = 16
        Me.btncargar_salida.Text = "CARGAR A LA LISTA"
        Me.btncargar_salida.UseVisualStyleBackColor = False
        '
        'Btn_siguiente
        '
        Me.Btn_siguiente.BackColor = System.Drawing.Color.SkyBlue
        Me.Btn_siguiente.Location = New System.Drawing.Point(1019, 103)
        Me.Btn_siguiente.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Btn_siguiente.Name = "Btn_siguiente"
        Me.Btn_siguiente.Size = New System.Drawing.Size(129, 66)
        Me.Btn_siguiente.TabIndex = 17
        Me.Btn_siguiente.Text = "->"
        Me.Btn_siguiente.UseVisualStyleBackColor = False
        '
        'TxtCantidad1
        '
        Me.TxtCantidad1.Location = New System.Drawing.Point(675, 113)
        Me.TxtCantidad1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCantidad1.Name = "TxtCantidad1"
        Me.TxtCantidad1.Size = New System.Drawing.Size(141, 44)
        Me.TxtCantidad1.TabIndex = 16
        '
        'Txt_Salida
        '
        Me.Txt_Salida.Location = New System.Drawing.Point(675, 39)
        Me.Txt_Salida.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Txt_Salida.Name = "Txt_Salida"
        Me.Txt_Salida.Size = New System.Drawing.Size(141, 44)
        Me.Txt_Salida.TabIndex = 15
        '
        'TxtIdMaterial_1
        '
        Me.TxtIdMaterial_1.Location = New System.Drawing.Point(309, 113)
        Me.TxtIdMaterial_1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtIdMaterial_1.Name = "TxtIdMaterial_1"
        Me.TxtIdMaterial_1.Size = New System.Drawing.Size(141, 44)
        Me.TxtIdMaterial_1.TabIndex = 14
        '
        'TxtIdDetalleSalida
        '
        Me.TxtIdDetalleSalida.Enabled = False
        Me.TxtIdDetalleSalida.Location = New System.Drawing.Point(309, 39)
        Me.TxtIdDetalleSalida.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtIdDetalleSalida.Name = "TxtIdDetalleSalida"
        Me.TxtIdDetalleSalida.Size = New System.Drawing.Size(141, 44)
        Me.TxtIdDetalleSalida.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.SkyBlue
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(495, 113)
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
        Me.Label7.Size = New System.Drawing.Size(152, 38)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "ID Salida :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.SkyBlue
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(87, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 38)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ID Material :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.SkyBlue
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(16, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(251, 38)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "ID Detalle Salida :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.txtid_solicitud)
        Me.GroupBox1.Controls.Add(Me.btnagregar_detallesalida)
        Me.GroupBox1.Controls.Add(Me.Txtdni_personal)
        Me.GroupBox1.Controls.Add(Me.txtsalida)
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
        Me.GroupBox1.Size = New System.Drawing.Size(1305, 190)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(581, 112)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(167, 44)
        Me.DateTimePicker1.TabIndex = 18
        '
        'txtid_solicitud
        '
        Me.txtid_solicitud.Location = New System.Drawing.Point(581, 32)
        Me.txtid_solicitud.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtid_solicitud.Name = "txtid_solicitud"
        Me.txtid_solicitud.Size = New System.Drawing.Size(167, 44)
        Me.txtid_solicitud.TabIndex = 13
        '
        'btnagregar_detallesalida
        '
        Me.btnagregar_detallesalida.BackColor = System.Drawing.Color.SkyBlue
        Me.btnagregar_detallesalida.Location = New System.Drawing.Point(859, 71)
        Me.btnagregar_detallesalida.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnagregar_detallesalida.Name = "btnagregar_detallesalida"
        Me.btnagregar_detallesalida.Size = New System.Drawing.Size(347, 66)
        Me.btnagregar_detallesalida.TabIndex = 15
        Me.btnagregar_detallesalida.Text = "AGREGAR DETALLE"
        Me.btnagregar_detallesalida.UseVisualStyleBackColor = False
        '
        'Txtdni_personal
        '
        Me.Txtdni_personal.Location = New System.Drawing.Point(219, 121)
        Me.Txtdni_personal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Txtdni_personal.MaxLength = 8
        Me.Txtdni_personal.Name = "Txtdni_personal"
        Me.Txtdni_personal.Size = New System.Drawing.Size(167, 44)
        Me.Txtdni_personal.TabIndex = 12
        '
        'txtsalida
        '
        Me.txtsalida.Location = New System.Drawing.Point(196, 34)
        Me.txtsalida.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtsalida.Name = "txtsalida"
        Me.txtsalida.Size = New System.Drawing.Size(167, 44)
        Me.txtsalida.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Location = New System.Drawing.Point(384, 34)
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
        Me.Label4.Location = New System.Drawing.Point(439, 118)
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
        Me.Label3.Location = New System.Drawing.Point(8, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(204, 38)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "DNI Personal :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(24, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 38)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "ID Salida :"
        '
        'FrmSalidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1305, 807)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FrmSalidas"
        Me.Text = "FrmSalidas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGridView02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnregistrar_salida As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DataGridView02 As DataGridView
    Friend WithEvents IDDetalleSalida As DataGridViewTextBoxColumn
    Friend WithEvents IDSalida As DataGridViewTextBoxColumn
    Friend WithEvents IDMaterial As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Btn_siguiente As Button
    Friend WithEvents TxtCantidad1 As TextBox
    Friend WithEvents Txt_Salida As TextBox
    Friend WithEvents btnagregar_detallesalida As Button
    Friend WithEvents TxtIdMaterial_1 As TextBox
    Friend WithEvents TxtIdDetalleSalida As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btncargar_salida As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents txtid_solicitud As TextBox
    Friend WithEvents Txtdni_personal As TextBox
    Friend WithEvents txtsalida As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
