Public Class FrmUsuario
    Dim CUsuario As New ClsUsuarios
    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MiDataSet As New DataSet
        MiDataSet = CUsuario.CargarUsuarios()
        DataGridView2.DataSource = MiDataSet.Tables(0)
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub
    Private Sub ButtonRegistrar_Click(sender As Object, e As EventArgs) Handles ButtonRegistrar.Click
        If CUsuario.RegistrarUsuarios(TxtDNIUsuario.Text.Trim, TxtApellidosNombres.Text, TxtProgramaEstudios.Text, TxtTipoUsuario.Text, TxtCiclo.Text, Txt_Telefono.Text) Then
            MsgBox(“El usuario ha sido registrado correctamente”)
            FrmUsuario_Load(sender, e)
        End If
    End Sub
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        TxtDNIUsuario.Text = DataGridView2.CurrentRow.Cells(0).Value
        TxtApellidosNombres.Text = DataGridView2.CurrentRow.Cells(1).Value
        TxtProgramaEstudios.Text = DataGridView2.CurrentRow.Cells(2).Value
        TxtTipoUsuario.Text = DataGridView2.CurrentRow.Cells(3).Value
        TxtCiclo.Text = DataGridView2.CurrentRow.Cells(4).Value
        Txt_Telefono.Text = DataGridView2.CurrentRow.Cells(5).Value
    End Sub
    Private Sub Btn_Modificar_Click(sender As Object, e As EventArgs) Handles Btn_Modificar.Click
        If CUsuario.ModificarUsuarios(TxtDNIUsuario.Text.Trim, TxtApellidosNombres.Text, TxtProgramaEstudios.Text, TxtTipoUsuario.Text, TxtCiclo.Text, Txt_Telefono.Text) Then
            MsgBox(“El usuario ha sido modificado correctamente”)
            FrmUsuario_Load(sender, e)
        End If
    End Sub
    Private Sub Btn_Eliminar_Click(sender As Object, e As EventArgs) Handles Btn_Eliminar.Click
        If CUsuario.EliminarUsuarios(TxtDNIUsuario.Text) Then
            MsgBox(“El usuario ha sido eliminado correctamente”)
            FrmUsuario_Load(sender, e)
        End If
    End Sub
    Private Sub Btn_nuevo_Click(sender As Object, e As EventArgs) Handles Btn_nuevo.Click
        TxtApellidosNombres.Text = ""
        TxtCiclo.Text = ""
        TxtDNIUsuario.Text = ""
        TxtProgramaEstudios.Text = ""
        TxtTipoUsuario.Text = ""
        Txt_Telefono.Text = ""
        TxtDNIUsuario.Focus()
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
    Private Sub TxtDNIUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDNIUsuario.KeyPress
        Numeros(e)
    End Sub

    Private Sub Txt_Telefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Telefono.KeyPress
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
    Private Sub TxtApellidosNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtApellidosNombres.KeyPress
        Letras(e)
    End Sub
    Private Sub TxtProgramaEstudios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtProgramaEstudios.KeyPress
        Letras(e)
    End Sub
    Private Sub TxtTipoUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTipoUsuario.KeyPress
        Letras(e)
    End Sub
    Private Sub TxtCiclo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCiclo.KeyPress
        Letras(e)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ' Limpiamos los campos de texto directamente
        TxtApellidosNombres.Text = ""
        TxtCiclo.Text = ""
        TxtDNIUsuario.Text = ""
        TxtProgramaEstudios.Text = ""
        TxtTipoUsuario.Text = ""
        Txt_Telefono.Text = ""
        ' Devolvemos el foco al primer campo
        TxtDNIUsuario.Focus()
    End Sub
End Class