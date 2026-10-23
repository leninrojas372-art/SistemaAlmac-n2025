<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitud
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.BtnAnular = New System.Windows.Forms.Button()
        Me.Button_Eliminar = New System.Windows.Forms.Button()
        Me.Button_Modificar = New System.Windows.Forms.Button()
        Me.ButtonNuevo01 = New System.Windows.Forms.Button()
        Me.BtnRegistrar1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DgvDetalleSol = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtFecha = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbMaterial = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtCantidadSol = New System.Windows.Forms.TextBox()
        Me.BtnAgregarMat = New System.Windows.Forms.Button()
        Me.BtnQuitarMat = New System.Windows.Forms.Button()
        Me.TxtDNI_Usuario = New System.Windows.Forms.TextBox()
        Me.TxtIDSolicitud = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgvDetalleSol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1199, 781)
        Me.Panel1.TabIndex = 8
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.BtnAnular)
        Me.GroupBox3.Controls.Add(Me.Button_Eliminar)
        Me.GroupBox3.Controls.Add(Me.Button_Modificar)
        Me.GroupBox3.Controls.Add(Me.ButtonNuevo01)
        Me.GroupBox3.Controls.Add(Me.BtnRegistrar1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 663)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1199, 118)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.SkyBlue
        Me.Button5.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(971, 33)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(180, 63)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "CANCELAR"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'BtnAnular
        '
        Me.BtnAnular.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnAnular.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAnular.Location = New System.Drawing.Point(591, 33)
        Me.BtnAnular.Name = "BtnAnular"
        Me.BtnAnular.Size = New System.Drawing.Size(180, 63)
        Me.BtnAnular.TabIndex = 5
        Me.BtnAnular.Text = "ANULAR"
        Me.BtnAnular.UseVisualStyleBackColor = False
        '
        'Button_Eliminar
        '
        Me.Button_Eliminar.BackColor = System.Drawing.Color.SkyBlue
        Me.Button_Eliminar.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Eliminar.Location = New System.Drawing.Point(781, 33)
        Me.Button_Eliminar.Name = "Button_Eliminar"
        Me.Button_Eliminar.Size = New System.Drawing.Size(180, 63)
        Me.Button_Eliminar.TabIndex = 3
        Me.Button_Eliminar.Text = "ELIMINAR"
        Me.Button_Eliminar.UseVisualStyleBackColor = False
        '
        'Button_Modificar
        '
        Me.Button_Modificar.BackColor = System.Drawing.Color.SkyBlue
        Me.Button_Modificar.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Modificar.Location = New System.Drawing.Point(401, 33)
        Me.Button_Modificar.Name = "Button_Modificar"
        Me.Button_Modificar.Size = New System.Drawing.Size(180, 63)
        Me.Button_Modificar.TabIndex = 2
        Me.Button_Modificar.Text = "MODIFICAR"
        Me.Button_Modificar.UseVisualStyleBackColor = False
        '
        'ButtonNuevo01
        '
        Me.ButtonNuevo01.BackColor = System.Drawing.Color.SkyBlue
        Me.ButtonNuevo01.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNuevo01.Location = New System.Drawing.Point(211, 33)
        Me.ButtonNuevo01.Name = "ButtonNuevo01"
        Me.ButtonNuevo01.Size = New System.Drawing.Size(180, 63)
        Me.ButtonNuevo01.TabIndex = 1
        Me.ButtonNuevo01.Text = "NUEVO"
        Me.ButtonNuevo01.UseVisualStyleBackColor = False
        '
        'BtnRegistrar1
        '
        Me.BtnRegistrar1.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnRegistrar1.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegistrar1.Location = New System.Drawing.Point(21, 33)
        Me.BtnRegistrar1.Name = "BtnRegistrar1"
        Me.BtnRegistrar1.Size = New System.Drawing.Size(180, 63)
        Me.BtnRegistrar1.TabIndex = 0
        Me.BtnRegistrar1.Text = "REGISTRAR"
        Me.BtnRegistrar1.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 518)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1199, 263)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Solicitudes Registradas:"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 40)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1193, 220)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox4.Controls.Add(Me.DgvDetalleSol)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(0, 308)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1199, 210)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Materiales solicitados:"
        '
        'DgvDetalleSol
        '
        Me.DgvDetalleSol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetalleSol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDetalleSol.Location = New System.Drawing.Point(3, 40)
        Me.DgvDetalleSol.Name = "DgvDetalleSol"
        Me.DgvDetalleSol.RowHeadersWidth = 51
        Me.DgvDetalleSol.RowTemplate.Height = 24
        Me.DgvDetalleSol.Size = New System.Drawing.Size(1193, 167)
        Me.DgvDetalleSol.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox1.Controls.Add(Me.TxtFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CmbMaterial)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtCantidadSol)
        Me.GroupBox1.Controls.Add(Me.BtnAgregarMat)
        Me.GroupBox1.Controls.Add(Me.BtnQuitarMat)
        Me.GroupBox1.Controls.Add(Me.TxtDNI_Usuario)
        Me.GroupBox1.Controls.Add(Me.TxtIDSolicitud)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1199, 250)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos:"
        '
        'TxtFecha
        '
        Me.TxtFecha.Location = New System.Drawing.Point(265, 110)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.Size = New System.Drawing.Size(284, 44)
        Me.TxtFecha.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Location = New System.Drawing.Point(115, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 38)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Material:"
        '
        'CmbMaterial
        '
        Me.CmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbMaterial.FormattingEnabled = True
        Me.CmbMaterial.Location = New System.Drawing.Point(265, 175)
        Me.CmbMaterial.Name = "CmbMaterial"
        Me.CmbMaterial.Size = New System.Drawing.Size(470, 45)
        Me.CmbMaterial.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.SkyBlue
        Me.Label6.Location = New System.Drawing.Point(745, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 38)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Cantidad:"
        '
        'TxtCantidadSol
        '
        Me.TxtCantidadSol.Location = New System.Drawing.Point(895, 175)
        Me.TxtCantidadSol.MaxLength = 4
        Me.TxtCantidadSol.Name = "TxtCantidadSol"
        Me.TxtCantidadSol.Size = New System.Drawing.Size(100, 44)
        Me.TxtCantidadSol.TabIndex = 9
        '
        'BtnAgregarMat
        '
        Me.BtnAgregarMat.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnAgregarMat.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregarMat.Location = New System.Drawing.Point(1005, 172)
        Me.BtnAgregarMat.Name = "BtnAgregarMat"
        Me.BtnAgregarMat.Size = New System.Drawing.Size(180, 50)
        Me.BtnAgregarMat.TabIndex = 10
        Me.BtnAgregarMat.Text = "AGREGAR"
        Me.BtnAgregarMat.UseVisualStyleBackColor = False
        '
        'BtnQuitarMat
        '
        Me.BtnQuitarMat.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnQuitarMat.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQuitarMat.Location = New System.Drawing.Point(1005, 108)
        Me.BtnQuitarMat.Name = "BtnQuitarMat"
        Me.BtnQuitarMat.Size = New System.Drawing.Size(180, 50)
        Me.BtnQuitarMat.TabIndex = 11
        Me.BtnQuitarMat.Text = "QUITAR"
        Me.BtnQuitarMat.UseVisualStyleBackColor = False
        '
        'TxtDNI_Usuario
        '
        Me.TxtDNI_Usuario.Location = New System.Drawing.Point(813, 49)
        Me.TxtDNI_Usuario.MaxLength = 8
        Me.TxtDNI_Usuario.Name = "TxtDNI_Usuario"
        Me.TxtDNI_Usuario.Size = New System.Drawing.Size(284, 44)
        Me.TxtDNI_Usuario.TabIndex = 4
        '
        'TxtIDSolicitud
        '
        Me.TxtIDSolicitud.Location = New System.Drawing.Point(265, 49)
        Me.TxtIDSolicitud.Name = "TxtIDSolicitud"
        Me.TxtIDSolicitud.Size = New System.Drawing.Size(284, 44)
        Me.TxtIDSolicitud.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.Location = New System.Drawing.Point(615, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(182, 38)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "DNIUsuario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Location = New System.Drawing.Point(154, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 38)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.Location = New System.Drawing.Point(78, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 38)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "IDSolicitud:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(393, 58)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Registrar Solicitud"
        '
        'FrmSolicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1199, 781)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmSolicitud"
        Me.Text = "FrmSolicitud"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DgvDetalleSol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button_Eliminar As Button
    Friend WithEvents Button_Modificar As Button
    Friend WithEvents ButtonNuevo01 As Button
    Friend WithEvents BtnRegistrar1 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtFecha As TextBox
    Friend WithEvents TxtDNI_Usuario As TextBox
    Friend WithEvents TxtIDSolicitud As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents DgvDetalleSol As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents CmbMaterial As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtCantidadSol As TextBox
    Friend WithEvents BtnAgregarMat As Button
    Friend WithEvents BtnQuitarMat As Button
    Friend WithEvents BtnAnular As Button
End Class
