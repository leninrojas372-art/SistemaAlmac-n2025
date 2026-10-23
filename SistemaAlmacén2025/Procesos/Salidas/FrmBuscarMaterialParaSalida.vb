Public Class FrmBuscarMaterialParaSalida

    Dim CMaterial As New Clsmaterial
    Dim MiDataSet As New DataSet

    Private Sub FrmBuscarMaterialParaSalida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MiDataSet = CMaterial.CargarMaterial
        DataGridView1.DataSource = MiDataSet.Tables(0)
    End Sub

    Dim Consulta As New ClsConsultas
    Dim MidataTable As New DataTable
    Dim MiBindingSource As Windows.Forms.BindingSource = New BindingSource

    Private Sub TxtIDMaterial_TextChanged(sender As Object, e As EventArgs) Handles TxtIDMaterial.TextChanged
        Consulta.BuscarMaterialParaSalidas(TxtIDMaterial.Text)
        MidataTable = Consulta.DSet.Tables(0)
        MiBindingSource.DataSource = MidataTable
        DataGridView1.DataSource = MiBindingSource.DataSource
    End Sub

    ' *** CORREGIDO → SE USA CellDoubleClick ***
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex >= 0 Then
            FrmSalidas.TxtIdMaterial_1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
            Me.Close()
        End If
    End Sub

End Class
