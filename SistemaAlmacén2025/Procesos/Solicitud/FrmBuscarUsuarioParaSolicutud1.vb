Public Class FrmBuscarUsuarioParaSolicutud1
    Dim CUsuario As New ClsUsuarios
    Dim MiDataSet As New DataSet


    Private Sub FrmBuscarUsuarioParaSolicutud1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MiDataSet = CUsuario.CargarUsuarios
        DataGridView1.DataSource = MiDataSet.Tables(0)
    End Sub
    Dim Consulta As New ClsConsultas
    Dim MidataTable As New DataTable
    Dim MiBindingSource As Windows.Forms.BindingSource = New BindingSource

    Private Sub TxtDNI_Usuario_TextChanged(sender As Object, e As EventArgs) Handles TxtDNI_Usuario.TextChanged
        Consulta.BuscarUsuarioParaSolicitud(TxtDNI_Usuario.Text)
        MidataTable = Consulta.DSet.Tables(0)
        MiBindingSource.DataSource = MidataTable
        DataGridView1.DataSource = MiBindingSource.DataSource
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        FrmSolicitud.TxtDNI_Usuario.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
        Me.Close()
    End Sub
End Class