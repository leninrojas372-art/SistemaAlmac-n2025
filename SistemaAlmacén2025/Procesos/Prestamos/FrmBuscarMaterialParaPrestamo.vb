Public Class FrmBuscarMaterialParaPrestamo

    Dim CMaterial As New Clsmaterial
    Dim MiDataSet As New DataSet

    Private Sub FrmBuscarMaterialParaPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MiDataSet = CMaterial.CargarMaterial
        DataGridView1.DataSource = MiDataSet.Tables(0)
    End Sub

    Dim Consulta As New ClsConsultas
    Dim MidataTable As New DataTable
    Dim MiBindingSource As New BindingSource

    Private Sub TxtIDMaterial_TextChanged(sender As Object, e As EventArgs) Handles TxtID_Material.TextChanged
        Consulta.BuscarMaterialParaPrestamo(TxtID_Material.Text)
        MidataTable = Consulta.DSet.Tables(0)
        MiBindingSource.DataSource = MidataTable
        DataGridView1.DataSource = MiBindingSource
    End Sub

    ' ✔ CORREGIDO — Usamos CellDoubleClick
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex >= 0 Then
            FrmPrestamo.TxtIdMaterial.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            Me.Close()
        End If
    End Sub

End Class
