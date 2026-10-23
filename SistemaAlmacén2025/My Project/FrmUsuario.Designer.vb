<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUsuario
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
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Btn_Eliminar = New System.Windows.Forms.Button()
        Me.Btn_Modificar = New System.Windows.Forms.Button()
        Me.Btn_nuevo = New System.Windows.Forms.Button()
        Me.ButtonRegistrar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtTipoUsuario = New System.Windows.Forms.TextBox()
        Me.TxtCiclo = New System.Windows.Forms.TextBox()
        Me.TxtProgramaEstudios = New System.Windows.Forms.TextBox()
        Me.Txt_Telefono = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtApellidosNombres = New System.Windows.Forms.TextBox()
        Me.TxtDNIUsuario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1187, 782)
        Me.Panel1.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox3.Controls.Add(Me.btnCancelar)
        Me.GroupBox3.Controls.Add(Me.Btn_Eliminar)
        Me.GroupBox3.Controls.Add(Me.Btn_Modificar)
        Me.GroupBox3.Controls.Add(Me.Btn_nuevo)
        Me.GroupBox3.Controls.Add(Me.ButtonRegistrar)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 664)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1187, 118)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.SkyBlue
        Me.btnCancelar.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(927, 34)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(214, 63)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.BackColor = System.Drawing.Color.SkyBlue
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Eliminar.Location = New System.Drawing.Point(717, 34)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(204, 63)
        Me.Btn_Eliminar.TabIndex = 3
        Me.Btn_Eliminar.Text = "ELIMINAR"
        Me.Btn_Eliminar.UseVisualStyleBackColor = False
        '
        'Btn_Modificar
        '
        Me.Btn_Modificar.BackColor = System.Drawing.Color.SkyBlue
        Me.Btn_Modificar.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Modificar.Location = New System.Drawing.Point(482, 33)
        Me.Btn_Modificar.Name = "Btn_Modificar"
        Me.Btn_Modificar.Size = New System.Drawing.Size(229, 64)
        Me.Btn_Modificar.TabIndex = 2
        Me.Btn_Modificar.Text = "MODIFICAR"
        Me.Btn_Modificar.UseVisualStyleBackColor = False
        '
        'Btn_nuevo
        '
        Me.Btn_nuevo.BackColor = System.Drawing.Color.SkyBlue
        Me.Btn_nuevo.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_nuevo.Location = New System.Drawing.Point(234, 33)
        Me.Btn_nuevo.Name = "Btn_nuevo"
        Me.Btn_nuevo.Size = New System.Drawing.Size(242, 63)
        Me.Btn_nuevo.TabIndex = 1
        Me.Btn_nuevo.Text = "NUEVO"
        Me.Btn_nuevo.UseVisualStyleBackColor = False
        '
        'ButtonRegistrar
        '
        Me.ButtonRegistrar.BackColor = System.Drawing.Color.SkyBlue
        Me.ButtonRegistrar.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRegistrar.Location = New System.Drawing.Point(23, 34)
        Me.ButtonRegistrar.Name = "ButtonRegistrar"
        Me.ButtonRegistrar.Size = New System.Drawing.Size(205, 63)
        Me.ButtonRegistrar.TabIndex = 0
        Me.ButtonRegistrar.Text = "REGISTRAR"
        Me.ButtonRegistrar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox2.Controls.Add(Me.DataGridView2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 363)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1187, 419)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Usuarios Registrados:"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 40)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(1181, 376)
        Me.DataGridView2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox1.Controls.Add(Me.TxtTipoUsuario)
        Me.GroupBox1.Controls.Add(Me.TxtCiclo)
        Me.GroupBox1.Controls.Add(Me.TxtProgramaEstudios)
        Me.GroupBox1.Controls.Add(Me.Txt_Telefono)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtApellidosNombres)
        Me.GroupBox1.Controls.Add(Me.TxtDNIUsuario)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Palatino Linotype", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1187, 305)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos:"
        '
        'TxtTipoUsuario
        '
        Me.TxtTipoUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTipoUsuario.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTipoUsuario.Location = New System.Drawing.Point(655, 82)
        Me.TxtTipoUsuario.Name = "TxtTipoUsuario"
        Me.TxtTipoUsuario.Size = New System.Drawing.Size(198, 34)
        Me.TxtTipoUsuario.TabIndex = 14
        '
        'TxtCiclo
        '
        Me.TxtCiclo.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCiclo.Location = New System.Drawing.Point(655, 172)
        Me.TxtCiclo.Name = "TxtCiclo"
        Me.TxtCiclo.Size = New System.Drawing.Size(198, 34)
        Me.TxtCiclo.TabIndex = 13
        '
        'TxtProgramaEstudios
        '
        Me.TxtProgramaEstudios.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProgramaEstudios.Location = New System.Drawing.Point(126, 256)
        Me.TxtProgramaEstudios.Name = "TxtProgramaEstudios"
        Me.TxtProgramaEstudios.Size = New System.Drawing.Size(389, 34)
        Me.TxtProgramaEstudios.TabIndex = 12
        '
        'Txt_Telefono
        '
        Me.Txt_Telefono.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Telefono.Location = New System.Drawing.Point(655, 256)
        Me.Txt_Telefono.Name = "Txt_Telefono"
        Me.Txt_Telefono.Size = New System.Drawing.Size(198, 34)
        Me.Txt_Telefono.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.SkyBlue
        Me.Label7.Location = New System.Drawing.Point(571, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 38)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Teléfono:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.SkyBlue
        Me.Label6.Location = New System.Drawing.Point(571, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 38)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Ciclo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Location = New System.Drawing.Point(571, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(231, 38)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Tipo de Usuario:"
        '
        'TxtApellidosNombres
        '
        Me.TxtApellidosNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApellidosNombres.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApellidosNombres.Location = New System.Drawing.Point(127, 172)
        Me.TxtApellidosNombres.Name = "TxtApellidosNombres"
        Me.TxtApellidosNombres.Size = New System.Drawing.Size(388, 34)
        Me.TxtApellidosNombres.TabIndex = 4
        '
        'TxtDNIUsuario
        '
        Me.TxtDNIUsuario.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDNIUsuario.Location = New System.Drawing.Point(127, 82)
        Me.TxtDNIUsuario.Name = "TxtDNIUsuario"
        Me.TxtDNIUsuario.Size = New System.Drawing.Size(197, 34)
        Me.TxtDNIUsuario.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.SkyBlue
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(27, 213)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(302, 38)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Programa de Estudios:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(27, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(297, 38)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Apellidos y Nombres:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SkyBlue
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(27, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(189, 38)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DNI Usuario:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(382, 58)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Registrar Usuario:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'FrmUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1187, 782)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Usuario"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Btn_Eliminar As Button
    Friend WithEvents Btn_Modificar As Button
    Friend WithEvents Btn_nuevo As Button
    Friend WithEvents ButtonRegistrar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtTipoUsuario As TextBox
    Friend WithEvents TxtCiclo As TextBox
    Friend WithEvents TxtProgramaEstudios As TextBox
    Friend WithEvents Txt_Telefono As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtApellidosNombres As TextBox
    Friend WithEvents TxtDNIUsuario As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
