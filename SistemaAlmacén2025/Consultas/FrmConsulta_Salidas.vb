Public Class FrmConsulta_Salidas
    Dim CSalidas As New ClsSalida
    Dim MiDataSet As New DataSet
    Private Sub FrmConsulta_Salidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MiDataSet = CSalidas.CargarSalidas()
        DataGridView1.DataSource = MiDataSet.Tables(0)
        DataGridView2.DataSource = MiDataSet.Tables(0)
    End Sub
    Dim Consulta As New ClsConsultas
    Dim MiDataTable As New DataTable
    Dim MiBindingSource As Windows.Forms.BindingSource = New BindingSource
    Private Sub txtidsalida_TextChanged(sender As Object, e As EventArgs) Handles txtidsalida.TextChanged
        Consulta.ConsultaBuscarSalidaPorID(txtidsalida.Text)
        MiDataTable = Consulta.DSet.Tables(0)
        MiBindingSource.DataSource = MiDataTable
        DataGridView1.DataSource = MiBindingSource.DataSource
        DataGridView1.AutoResizeColumns()
    End Sub

    Private Sub txtnombre_material_TextChanged(sender As Object, e As EventArgs) Handles txtnombre_material.TextChanged
        Consulta.ConsultaBuscarSalidaPorNombreMaterial(txtnombre_material.Text)
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
        Dim parametros As New Dictionary(Of String, Object) From {{"@Nombre", txtnombre_material.Text.Trim}}
        Rep.GeneraReporte("select * from VistaConsulta_Salidas where Nombre like @Nombre + '%'", dset, "VistaConsulta_Salidas", parametros)
        Dim Cr As New CrSalidas
        Cr.SetDataSource(dset)
        Dim FormReporte As New FrmReportes
        'Muestra el reporte.
        FormReporte.Text = "REPORTE VistaConsulta_Salidas"
        FormReporte.CrystalReportViewer1.ReportSource = Cr
        FormReporte.Show()
        FormReporte.WindowState = FormWindowState.Maximized

#Else
        'Sin Crystal Reports: se imprime la grilla con vista previa
        ClsImpresionGrid.Imprimir(DataGridView2, "Salidas por material")
#End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
#If CRYSTAL Then
        Dim dset As New BD_Almacén2025DataSet
        'Llamamos al Comando Imprimir para reportar los datos encontrados.
        Dim parametros As New Dictionary(Of String, Object) From {{"@IDSalidas", txtidsalida.Text.Trim}}
        Rep.GeneraReporte("select * from VistaConsulta_Salidas where IDSalidas like @IDSalidas + '%'", dset, "VistaConsulta_Salidas", parametros)
        Dim Cr As New CrSalidas
        Cr.SetDataSource(dset)
        Dim FormReporte As New FrmReportes
        'Muestra el reporte.
        FormReporte.Text = "REPORTE VistaConsulta_Salidas"
        FormReporte.CrystalReportViewer1.ReportSource = Cr
        FormReporte.Show()
        FormReporte.WindowState = FormWindowState.Maximized
#Else
        'Sin Crystal Reports: se imprime la grilla con vista previa
        ClsImpresionGrid.Imprimir(DataGridView1, "Salidas por ID")
#End If
    End Sub
End Class