Public Class FrmPersonal
    Dim CPersonal As New ClsPersonal
    Private Sub FrmPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MiDataSet As New DataSet
        MiDataSet = CPersonal.CargarPersonal()
        DataGridView1.DataSource = MiDataSet.Tables(0)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub
    Private Sub BtnRegistrar_Click(sender As Object, e As EventArgs) Handles BtnRegistrar.Click
        If CPersonal.RegistrarPersonal(TxtDNIPersonal.Text.Trim, TxtApeNom.Text, TxtCargo.Text, TxtTelefono.Text.Trim, TxtUsuario.Text.Trim, TxtContraseña.Text.Trim) Then
            MsgBox(“El personal ha sido registrado correctamente”)
            FrmPersonal_Load(sender, e)
        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TxtDNIPersonal.Text = DataGridView1.CurrentRow.Cells(0).Value
        TxtApeNom.Text = DataGridView1.CurrentRow.Cells(1).Value
        TxtCargo.Text = DataGridView1.CurrentRow.Cells(2).Value
        TxtTelefono.Text = DataGridView1.CurrentRow.Cells(3).Value
        TxtUsuario.Text = DataGridView1.CurrentRow.Cells(4).Value
        TxtContraseña.Text = DataGridView1.CurrentRow.Cells(5).Value
    End Sub
    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        If CPersonal.ModificarPersonal(TxtDNIPersonal.Text.Trim, TxtApeNom.Text, TxtCargo.Text, TxtTelefono.Text.Trim, TxtUsuario.Text.Trim, TxtContraseña.Text.Trim) Then
            MsgBox(“El personal ha sido modificado correctamente”)
            FrmPersonal_Load(sender, e)
        End If
    End Sub
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If CPersonal.EliminarPersonal(TxtDNIPersonal.Text) Then
            MsgBox(“El personal ha sido eliminado correctamente”)
            FrmPersonal_Load(sender, e)
        End If
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        TxtApeNom.Text = ""
        TxtCargo.Text = ""
        TxtContraseña.Text = ""
        TxtDNIPersonal.Text = ""
        TxtTelefono.Text = ""
        TxtUsuario.Text = ""
        TxtDNIPersonal.Focus()
    End Sub
    Private Sub Numeros(e)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtDNIPersonal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDNIPersonal.KeyPress
        Numeros(e)
    End Sub
    Private Sub TxtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTelefono.KeyPress
        Numeros(e)
    End Sub

    Private Sub Letras(e As KeyPressEventArgs)
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtApeNom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtApeNom.KeyPress
        Letras(e)
    End Sub
    Private Sub TxtCargo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCargo.KeyPress
        Letras(e)
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click

        ' Limpiamos los campos de texto directamente
        TxtApeNom.Text = ""
        TxtCargo.Text = ""
        TxtContraseña.Text = ""
        TxtDNIPersonal.Text = ""
        TxtTelefono.Text = ""
        TxtUsuario.Text = ""

        ' Devolvemos el foco al primer campo
        TxtDNIPersonal.Focus()

    End Sub

End Class