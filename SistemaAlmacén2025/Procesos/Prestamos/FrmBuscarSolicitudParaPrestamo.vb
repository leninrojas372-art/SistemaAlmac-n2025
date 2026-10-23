Public Class FrmBuscarSolicitudParaPrestamo

    Dim CSolicitud As New ClsSolicitud
    Dim MiDataSet As New DataSet
    Dim MiBindingSource As New BindingSource

    Private Sub FrmBuscarSolicitudParaPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MiDataSet = New DataSet()
        MiDataSet.Tables.Add(ClsControl.Solicitudes())   'solicitudes con nombre del usuario y si ya fueron atendidas
        MiBindingSource.DataSource = MiDataSet.Tables(0).DefaultView
        DataGridView1.DataSource = MiBindingSource
        DataGridView1.AutoResizeColumns()
    End Sub

    Private Sub TxtDni_Usuario__TextChanged(sender As Object, e As EventArgs) Handles TxtDni_Usuario_.TextChanged
        Dim txt As String = TxtDni_Usuario_.Text.Trim()

        If txt = "" Then
            MiBindingSource.RemoveFilter()
        Else
            MiBindingSource.Filter = "Convert(DNIUsuario, 'System.String') LIKE '" & txt.Replace("'", "''") & "%' OR Usuario LIKE '%" & txt.Replace("'", "''") & "%'"
        End If

        DataGridView1.AutoResizeColumns()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim dni As String = DataGridView1.Rows(e.RowIndex).Cells("IDSolicitud").Value.ToString()
        FrmPrestamo.TxtId_Solicitud.Text = dni
        Me.Close()
    End Sub

End Class
