Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class FrmConsulta_Material
    Dim CMaterial As New Clsmaterial
    Dim MiDataSet As New DataSet
    Private Sub FrmConsulta_Material_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MiDataSet = CMaterial.CargarMaterial()
        DataGridView1.DataSource = MiDataSet.Tables(0)
        DataGridView2.DataSource = MiDataSet.Tables(0)
    End Sub
    Dim Consulta As New ClsConsultas
    Dim MiDataTable As New DataTable
    Dim MiBindingSource As Windows.Forms.BindingSource = New BindingSource
    Private Sub txtidmaterial_TextChanged(sender As Object, e As EventArgs) Handles txtidmaterial.TextChanged
        Consulta.ConsultaBuscarMaterialPorID(txtidmaterial.Text)
        MiDataTable = Consulta.DSet.Tables(0)
        MiBindingSource.DataSource = MiDataTable
        DataGridView1.DataSource = MiBindingSource.DataSource
        DataGridView1.AutoResizeColumns()
    End Sub
    Private Sub txtnombrematerial_TextChanged(sender As Object, e As EventArgs) Handles txtnombrematerial.TextChanged
        Consulta.ConsultaBuscarMaterialPorNombre(txtnombrematerial.Text)
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
        Dim parametros As New Dictionary(Of String, Object) From {{"@IDMaterial", txtidmaterial.Text.Trim}}
        Rep.GeneraReporte("select * from VistaConsulta_Material where IDMaterial like @IDMaterial + '%'", dset, "VistaConsulta_Material", parametros)
        Dim Cr As New CrMateriales
        Cr.SetDataSource(dset)
        Dim FormReporte As New FrmReportes
        'Muestra el reporte.
        FormReporte.Text = "REPORTE VistaConsulta_Material"
        FormReporte.CrystalReportViewer1.ReportSource = Cr
        FormReporte.Show()
        FormReporte.WindowState = FormWindowState.Maximized
#Else
        'Sin Crystal Reports: se imprime la grilla con vista previa
        ClsImpresionGrid.Imprimir(DataGridView1, "Materiales por ID")
#End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
#If CRYSTAL Then
        Dim dset As New BD_Almacén2025DataSet
        'Llamamos al Comando Imprimir para reportar los datos encontrados.
        Dim parametros As New Dictionary(Of String, Object) From {{"@Nombre", txtnombrematerial.Text.Trim}}
        Rep.GeneraReporte("select * from VistaConsulta_Material where Nombre like @Nombre + '%'", dset, "VistaConsulta_Material", parametros)
        Dim Cr As New CrMateriales
        Cr.SetDataSource(dset)
        Dim FormReporte As New FrmReportes
        'Muestra el reporte.
        FormReporte.Text = "REPORTE VistaConsulta_Material"
        FormReporte.CrystalReportViewer1.ReportSource = Cr
        FormReporte.Show()
        FormReporte.WindowState = FormWindowState.Maximized
#Else
        'Sin Crystal Reports: se imprime la grilla con vista previa
        ClsImpresionGrid.Imprimir(DataGridView2, "Materiales por nombre")
#End If
    End Sub
End Class