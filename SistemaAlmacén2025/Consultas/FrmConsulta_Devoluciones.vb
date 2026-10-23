Public Class FrmConsulta_Devoluciones
    Dim CDevoluciones As New ClsDevoluciones
    Dim MiDataSet As New DataSet
    Private Sub FrmConsulta_Devoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MiDataSet = CDevoluciones.CargarDevoluciones()
        DataGridView1.DataSource = MiDataSet.Tables(0)
        DataGridView2.DataSource = MiDataSet.Tables(0)
    End Sub
    Dim Consulta As New ClsConsultas
    Dim MiDataTable As New DataTable
    Dim MiBindingSource As Windows.Forms.BindingSource = New BindingSource
    Private Sub txtiddevoluciones_TextChanged(sender As Object, e As EventArgs) Handles txtiddevoluciones.TextChanged
        Consulta.ConsultaBuscarDevolucionPorID(txtiddevoluciones.Text)
        MiDataTable = Consulta.DSet.Tables(0)
        MiBindingSource.DataSource = MiDataTable
        DataGridView1.DataSource = MiBindingSource.DataSource
        DataGridView1.AutoResizeColumns()
    End Sub
    Private Sub txtnombredemataerial_TextChanged(sender As Object, e As EventArgs) Handles txtnombredematerial.TextChanged
        Consulta.ConsultaBuscarDevolucionPorNombreMaterial(txtnombredematerial.Text)
        MiDataTable = Consulta.DSet.Tables(0)
        MiBindingSource.DataSource = MiDataTable
        DataGridView2.DataSource = MiBindingSource.DataSource
        DataGridView2.AutoResizeColumns()
    End Sub
    Dim Rep As New ClsReportes
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
#If CRYSTAL Then
        Dim dset As New BD_Almacén2025DataSet
        'Llamamos al Comando Imprimir para reportar los datos encontrados.
        Dim parametros As New Dictionary(Of String, Object) From {{"@IDDevoluciones", txtiddevoluciones.Text.Trim}}
        Rep.GeneraReporte("select * from VistaConsulta_Devoluciones where IDDevoluciones like @IDDevoluciones + '%'", dset, "VistaConsulta_Devoluciones", parametros)
        Dim Cr As New CrDevolucionesrpt
        Cr.SetDataSource(dset)
        Dim FormReporte As New FrmReportes
        'Muestra el reporte.
        FormReporte.Text = "REPORTE VistaConsulta_Devoluciones"
        FormReporte.CrystalReportViewer1.ReportSource = Cr
        FormReporte.Show()
        FormReporte.WindowState = FormWindowState.Maximized
#Else
        'Sin Crystal Reports: se imprime la grilla con vista previa
        ClsImpresionGrid.Imprimir(DataGridView1, "Devoluciones por ID")
#End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
#If CRYSTAL Then
        Dim dset As New BD_Almacén2025DataSet
        'Llamamos al Comando Imprimir para reportar los datos encontrados.
        Dim parametros As New Dictionary(Of String, Object) From {{"@Nombre", txtnombredematerial.Text.Trim}}
        Rep.GeneraReporte("select * from VistaConsulta_Devoluciones where Nombre like @Nombre + '%'", dset, "VistaConsulta_Devoluciones", parametros)
        Dim Cr As New CrDevolucionesrpt
        Cr.SetDataSource(dset)
        Dim FormReporte As New FrmReportes
        'Muestra el reporte.
        FormReporte.Text = "REPORTE VistaConsulta_Devoluciones"
        FormReporte.CrystalReportViewer1.ReportSource = Cr
        FormReporte.Show()
        FormReporte.WindowState = FormWindowState.Maximized
#Else
        'Sin Crystal Reports: se imprime la grilla con vista previa
        ClsImpresionGrid.Imprimir(DataGridView2, "Devoluciones por material")
#End If
    End Sub
End Class