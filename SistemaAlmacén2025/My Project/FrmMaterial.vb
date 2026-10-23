Public Class FrmMaterial
    Dim CMaterial As New Clsmaterial

    Private Sub FrmMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MiDataSet As New DataSet
        Try
            MiDataSet = CMaterial.CargarMaterial()
            DataGridView3.DataSource = MiDataSet.Tables(0)
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
            Exit Sub
        End Try

        DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        DataGridView3.AllowUserToAddRows = False
        DataGridView3.ReadOnly = True
        DataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub Btn_Registrar_Click(sender As Object, e As EventArgs) Handles Btn_Registrar.Click
        If TxtNombre.Text.Trim() = "" Then
            MsgBox("Ingrese el nombre del material.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If CMaterial.RegistrarMaterial(TxtNombre.Text.Trim(), TxtDescripcion.Text.Trim(), cmbtipo.Text, cmbestado.Text, TxtStock.Text.Trim()) Then
            MsgBox("El material ha sido registrado correctamente", MsgBoxStyle.Information)
            FrmMaterial_Load(sender, e)
            ButtonNuevo_Click(sender, e)
        End If
    End Sub

    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim fila As DataGridViewRow = DataGridView3.Rows(e.RowIndex)

        Try
            TxtIDMaterial.Text = If(IsDBNull(fila.Cells(0).Value), "", fila.Cells(0).Value.ToString())
            TxtNombre.Text = If(IsDBNull(fila.Cells(1).Value), "", fila.Cells(1).Value.ToString())
            TxtDescripcion.Text = If(IsDBNull(fila.Cells(2).Value), "", fila.Cells(2).Value.ToString())
            cmbtipo.Text = If(IsDBNull(fila.Cells(3).Value), "", fila.Cells(3).Value.ToString())
            cmbestado.Text = If(IsDBNull(fila.Cells(4).Value), "", fila.Cells(4).Value.ToString())
            TxtStock.Text = If(IsDBNull(fila.Cells(5).Value), "", fila.Cells(5).Value.ToString())
        Catch ex As Exception
            ' Previene errores si el índice de columna varía
        End Try
    End Sub

    Private Sub ButtonModificar_Click(sender As Object, e As EventArgs) Handles ButtonModificar.Click
        If TxtIDMaterial.Text.Trim() = "" Then
            MsgBox("Seleccione un material de la lista para modificar.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If CMaterial.ModificarMaterial(TxtIDMaterial.Text.Trim(), TxtNombre.Text.Trim(), TxtDescripcion.Text.Trim(), cmbtipo.Text, cmbestado.Text, TxtStock.Text.Trim()) Then
            MsgBox("El material ha sido modificado correctamente", MsgBoxStyle.Information)
            FrmMaterial_Load(sender, e)
        End If
    End Sub

    Private Sub ButtonEliminar_Click(sender As Object, e As EventArgs) Handles ButtonEliminar.Click
        If TxtIDMaterial.Text.Trim() = "" Then
            MsgBox("Seleccione un material de la lista para eliminar.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If MsgBox("¿Está seguro de eliminar este material?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Confirmar eliminación") = MsgBoxResult.No Then Exit Sub

        If CMaterial.EliminarMaterial(TxtIDMaterial.Text.Trim()) Then
            MsgBox("El material ha sido eliminado correctamente", MsgBoxStyle.Information)
            ButtonNuevo_Click(sender, e)
            FrmMaterial_Load(sender, e)
        End If
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        TxtIDMaterial.Text = ""
        TxtNombre.Text = ""
        TxtDescripcion.Text = ""
        cmbtipo.SelectedIndex = -1
        cmbestado.SelectedIndex = -1
        TxtStock.Text = ""
        TxtNombre.Focus()
    End Sub

    Private Sub Letras(e As KeyPressEventArgs)
        If Char.IsPunctuation(e.KeyChar) AndAlso e.KeyChar <> "."c AndAlso e.KeyChar <> ","c Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDescripcion.KeyPress
        Letras(e)
    End Sub

    Private Sub TxtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNombre.KeyPress
        Letras(e)
    End Sub

    Private Sub Numeros(e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) OrElse Char.IsPunctuation(e.KeyChar) OrElse Char.IsSymbol(e.KeyChar) OrElse Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtStock.KeyPress
        Numeros(e)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ' Limpiamos los campos de texto directamente
        TxtIDMaterial.Text = ""
        TxtNombre.Text = ""
        TxtDescripcion.Text = ""
        cmbtipo.SelectedIndex = -1
        cmbestado.SelectedIndex = -1
        TxtStock.Text = ""
        TxtNombre.Focus()
    End Sub
End Class