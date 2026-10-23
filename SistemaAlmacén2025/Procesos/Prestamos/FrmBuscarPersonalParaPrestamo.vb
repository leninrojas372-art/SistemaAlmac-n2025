Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class FrmBuscarPersonalParaPrestamo
    Dim CPrestamo As New ClsPersonal
    Dim MiDataSet As New DataSet
    Private Sub FrmBuscarPersonalParaPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consulta.BuscarPersonalParaPrestamo("")   'lista el personal sin la contraseña
        DataGridView1.DataSource = Consulta.DSet.Tables(0)
    End Sub
    Dim Consulta As New ClsConsultas
    Dim MidataTable As New DataTable
    Dim MiBindingSource As Windows.Forms.BindingSource = New BindingSource

    Private Sub TxtDNIPersonal_TextChanged(sender As Object, e As EventArgs) Handles TxtDNIPersonal.TextChanged
        Consulta.BuscarPersonalParaPrestamo(TxtDNIPersonal.Text)
        MidataTable = Consulta.DSet.Tables(0)
        MiBindingSource.DataSource = MidataTable
        DataGridView1.DataSource = MiBindingSource.DataSource

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        FrmPrestamo.TxtDNI_Usuario.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString().Trim()
        Me.Close()
    End Sub


End Class
