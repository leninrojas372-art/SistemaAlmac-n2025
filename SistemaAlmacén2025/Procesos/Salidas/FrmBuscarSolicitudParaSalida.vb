Public Class FrmBuscarSolicitudParaSalida
    Dim CSolicitud As New ClsSolicitud
    Dim MiDataSet As New DataSet
    Dim MiBindingSource As New BindingSource

    Private Sub FrmBuscarSolicitudParaSalida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MiDataSet = New DataSet()
        MiDataSet.Tables.Add(ClsControl.Solicitudes())   'solicitudes con nombre del usuario y si ya fueron atendidas
        If MiDataSet.Tables.Count > 0 Then
            MiBindingSource.DataSource = MiDataSet.Tables(0).DefaultView
            DataGridView1.DataSource = MiBindingSource
            DataGridView1.AutoResizeColumns()
        End If
    End Sub

    Private Sub TxtDni_Usuario_1_TextChanged(sender As Object, e As EventArgs) Handles TxtDni_Usuario_1.TextChanged
        Dim txt As String = TxtDni_Usuario_1.Text.Trim()
        If txt = "" Then
            CType(MiBindingSource.DataSource, DataView).RowFilter = ""
            Exit Sub
        End If
        CType(MiBindingSource.DataSource, DataView).RowFilter =
            "Convert(DNIUsuario, 'System.String') LIKE '" & txt.Replace("'", "''") & "%' OR Usuario LIKE '%" & txt.Replace("'", "''") & "%'"
        DataGridView1.AutoResizeColumns()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim id As String = DataGridView1.Rows(e.RowIndex).Cells("IDSolicitud").Value.ToString()
        FrmSalidas.txtid_solicitud.Text = id
        Me.Close()
    End Sub
End Class
