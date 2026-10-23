<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDevoluciones
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.BtnEliminar01 = New System.Windows.Forms.Button()
        Me.BtnModificar01 = New System.Windows.Forms.Button()
        Me.BtnNuevo01 = New System.Windows.Forms.Button()
        Me.BtnRegistrar01 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.TxtObservacion = New System.Windows.Forms.TextBox()
        Me.TxtCondicion = New System.Windows.Forms.TextBox()
        Me.TxtIDPrestamo = New System.Windows.Forms.TextBox()
        Me.TxtIDDevoluciones = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1105, 743)
        Me.Panel1.TabIndex = 9
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.BtnEliminar01)
        Me.GroupBox3.Controls.Add(Me.BtnModificar01)
        Me.GroupBox3.Controls.Add(Me.BtnNuevo01)
        Me.GroupBox3.Controls.Add(Me.BtnRegistrar01)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 625)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(1105, 118)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.SkyBlue
        Me.Button5.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(857, 33)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(213, 63)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "CANCELAR"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'BtnEliminar01
        '
        Me.BtnEliminar01.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnEliminar01.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar01.Location = New System.Drawing.Point(647, 34)
        Me.BtnEliminar01.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnEliminar01.Name = "BtnEliminar01"
        Me.BtnEliminar01.Size = New System.Drawing.Size(204, 63)
        Me.BtnEliminar01.TabIndex = 3
        Me.BtnEliminar01.Text = "ELIMINAR"
        Me.BtnEliminar01.UseVisualStyleBackColor = False
        '
        'BtnModificar01
        '
        Me.BtnModificar01.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnModificar01.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnModificar01.Location = New System.Drawing.Point(412, 32)
        Me.BtnModificar01.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnModificar01.Name = "BtnModificar01"
        Me.BtnModificar01.Size = New System.Drawing.Size(229, 64)
        Me.BtnModificar01.TabIndex = 2
        Me.BtnModificar01.Text = "MODIFICAR"
        Me.BtnModificar01.UseVisualStyleBackColor = False
        '
        'BtnNuevo01
        '
        Me.BtnNuevo01.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnNuevo01.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo01.Location = New System.Drawing.Point(219, 33)
        Me.BtnNuevo01.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnNuevo01.Name = "BtnNuevo01"
        Me.BtnNuevo01.Size = New System.Drawing.Size(187, 63)
        Me.BtnNuevo01.TabIndex = 1
        Me.BtnNuevo01.Text = "NUEVO"
        Me.BtnNuevo01.UseVisualStyleBackColor = False
        '
        'BtnRegistrar01
        '
        Me.BtnRegistrar01.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnRegistrar01.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegistrar01.Location = New System.Drawing.Point(5, 33)
        Me.BtnRegistrar01.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnRegistrar01.Name = "BtnRegistrar01"
        Me.BtnRegistrar01.Size = New System.Drawing.Size(207, 63)
        Me.BtnRegistrar01.TabIndex = 0
        Me.BtnRegistrar01.Text = "REGISTRAR"
        Me.BtnRegistrar01.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox2.Controls.Add(Me.DataGridView4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 307)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(1105, 436)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Devoluciones Registradas:"
        '
        'DataGridView4
        '
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView4.Location = New System.Drawing.Point(3, 39)
        Me.DataGridView4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.RowHeadersWidth = 51
        Me.DataGridView4.RowTemplate.Height = 24
        Me.DataGridView4.Size = New System.Drawing.Size(1099, 395)
        Me.DataGridView4.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox1.Controls.Add(Me.DtpFecha)
        Me.GroupBox1.Controls.Add(Me.TxtObservacion)
        Me.GroupBox1.Controls.Add(Me.TxtCondicion)
        Me.GroupBox1.Controls.Add(Me.TxtIDPrestamo)
        Me.GroupBox1.Controls.Add(Me.TxtIDDevoluciones)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 58)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(1105, 249)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS:"
        '
        'DtpFecha
        '
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(296, 182)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(190, 44)
        Me.DtpFecha.TabIndex = 10
        '
        'TxtObservacion
        '
        Me.TxtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObservacion.Location = New System.Drawing.Point(767, 119)
        Me.TxtObservacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(205, 44)
        Me.TxtObservacion.TabIndex = 9
        '
        'TxtCondicion
        '
        Me.TxtCondicion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCondicion.Location = New System.Drawing.Point(767, 54)
        Me.TxtCondicion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtCondicion.Name = "TxtCondicion"
        Me.TxtCondicion.Size = New System.Drawing.Size(205, 44)
        Me.TxtCondicion.TabIndex = 8
        '
        'TxtIDPrestamo
        '
        Me.TxtIDPrestamo.Location = New System.Drawing.Point(296, 119)
        Me.TxtIDPrestamo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtIDPrestamo.Name = "TxtIDPrestamo"
        Me.TxtIDPrestamo.Size = New System.Drawing.Size(137, 44)
        Me.TxtIDPrestamo.TabIndex = 6
        '
        'TxtIDDevoluciones
        '
        Me.TxtIDDevoluciones.Location = New System.Drawing.Point(296, 54)
        Me.TxtIDDevoluciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtIDDevoluciones.Name = "TxtIDDevoluciones"
        Me.TxtIDDevoluciones.ReadOnly = True
        Me.TxtIDDevoluciones.Size = New System.Drawing.Size(137, 44)
        Me.TxtIDDevoluciones.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.SkyBlue
        Me.Label6.Location = New System.Drawing.Point(572, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(184, 38)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Observación:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Location = New System.Drawing.Point(599, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 38)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Condición:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.Location = New System.Drawing.Point(187, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 38)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Location = New System.Drawing.Point(101, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 38)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "ID Prestamo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Location = New System.Drawing.Point(44, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 38)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "ID Devoluciones:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(486, 58)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Registrar Devoluciones"
        '
        'FrmDevoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1105, 743)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FrmDevoluciones"
        Me.Text = "FrmDevoluciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button5 As Button
    Friend WithEvents BtnEliminar01 As Button
    Friend WithEvents BtnModificar01 As Button
    Friend WithEvents BtnNuevo01 As Button
    Friend WithEvents BtnRegistrar01 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtObservacion As TextBox
    Friend WithEvents TxtCondicion As TextBox
    Friend WithEvents TxtIDPrestamo As TextBox
    Friend WithEvents TxtIDDevoluciones As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DtpFecha As DateTimePicker
End Class
