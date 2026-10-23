''' <summary>
''' 5. REPORTES
''' Un solo formulario para los 5 reportes, con filtro por fechas,
''' vista previa de impresión, exportación a Excel y, en los reportes que ya
''' tenían diseño Crystal (Materiales, Devoluciones, Salidas), botón para verlos en Crystal.
''' </summary>
Public Class FrmReporteListado

    Public Enum TipoReporte
        Materiales
        Prestamos
        Devoluciones
        Salidas
        PrestamosPendientes
    End Enum

    Public Property Tipo As TipoReporte = TipoReporte.Materiales

    Private listo As Boolean = False

    'Abre el reporte como ventana hija del menú principal
    Public Shared Sub Abrir(ByVal padre As Form, ByVal tipo As TipoReporte)
        Dim frm As New FrmReporteListado With {.Tipo = tipo, .MdiParent = padre}
        frm.Show()
        frm.WindowState = FormWindowState.Maximized
    End Sub

    Private Function Titulo() As String
        Select Case Tipo
            Case TipoReporte.Materiales : Return "Reporte de materiales"
            Case TipoReporte.Prestamos : Return "Reporte de préstamos"
            Case TipoReporte.Devoluciones : Return "Reporte de devoluciones"
            Case TipoReporte.Salidas : Return "Reporte de salidas"
            Case Else : Return "Reporte de préstamos pendientes"
        End Select
    End Function

    Private Function Procedimiento() As String
        Select Case Tipo
            Case TipoReporte.Materiales : Return "Reporte_Materiales"
            Case TipoReporte.Prestamos : Return "Reporte_Prestamos"
            Case TipoReporte.Devoluciones : Return "Reporte_Devoluciones"
            Case TipoReporte.Salidas : Return "Reporte_Salidas"
            Case Else : Return "Reporte_PrestamosPendientes"
        End Select
    End Function

    Private Sub FrmReporteListado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Titulo()
        LblTitulo.Text = Titulo().ToUpper()
        ConfigurarGrilla(Dgv)

        DtpDesde.Value = New Date(Date.Today.Year, Date.Today.Month, 1)
        DtpHasta.Value = Date.Today

        'El reporte de materiales no depende de fechas
        Dim usaFechas As Boolean = (Tipo <> TipoReporte.Materiales)
        ChkFechas.Visible = usaFechas
        LblDesde.Visible = usaFechas
        DtpDesde.Visible = usaFechas
        LblHasta.Visible = usaFechas
        DtpHasta.Visible = usaFechas
        ChkFechas.Checked = False
        HabilitarFechas()

        'Solo el reporte de préstamos filtra por estado
        Dim usaEstado As Boolean = (Tipo = TipoReporte.Prestamos)
        LblEstado.Visible = usaEstado
        CmbEstado.Visible = usaEstado
        CmbEstado.Items.AddRange(New Object() {"Todos", "Pendiente", "Devuelto"})
        CmbEstado.SelectedIndex = 0

#If CRYSTAL Then
        BtnCrystal.Visible = (Tipo = TipoReporte.Materiales OrElse Tipo = TipoReporte.Devoluciones OrElse Tipo = TipoReporte.Salidas)
#Else
        BtnCrystal.Visible = False   'Crystal Reports no está instalado
#End If

        listo = True
        Generar()
    End Sub

    Private Sub HabilitarFechas()
        DtpDesde.Enabled = ChkFechas.Checked
        DtpHasta.Enabled = ChkFechas.Checked
    End Sub

    Private Sub Generar()
        If Not listo Then Exit Sub
        If ChkFechas.Checked AndAlso DtpDesde.Value.Date > DtpHasta.Value.Date Then
            MsgBox("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim desde As Object = Nothing
        Dim hasta As Object = Nothing
        If ChkFechas.Checked AndAlso ChkFechas.Visible Then
            desde = DtpDesde.Value.Date
            hasta = DtpHasta.Value.Date
        End If

        Try
            Dim datos As DataTable
            If Tipo = TipoReporte.Prestamos Then
                Dim estado As String = If(CmbEstado.SelectedIndex <= 0, "", CmbEstado.Text)
                datos = ClsControl.Reporte(Procedimiento(), desde, hasta, estado)
            Else
                datos = ClsControl.Reporte(Procedimiento(), desde, hasta)
            End If
            MostrarEnGrilla(Dgv, datos)

            Dim resumen As String = datos.Rows.Count & " registros"
            If datos.Columns.Contains("Cantidad") Then resumen &= "  |  Unidades: " & SumarColumna(datos, "Cantidad")
            If datos.Columns.Contains("Disponible") Then resumen &= "  |  Disponible: " & SumarColumna(datos, "Disponible") &
                                                                   "  |  Prestado: " & SumarColumna(datos, "Prestado")
            LblResumen.Text = resumen
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Function Subtitulo() As String
        Dim s As String = ""
        If ChkFechas.Visible AndAlso ChkFechas.Checked Then
            s = "Del " & DtpDesde.Value.ToString("dd/MM/yyyy") & " al " & DtpHasta.Value.ToString("dd/MM/yyyy")
        ElseIf ChkFechas.Visible Then
            s = "Todas las fechas"
        End If
        If CmbEstado.Visible Then s &= "   |   Estado: " & CmbEstado.Text
        Return s
    End Function

    Private Sub BtnGenerar_Click(sender As Object, e As EventArgs) Handles BtnGenerar.Click
        Generar()
    End Sub

    Private Sub ChkFechas_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFechas.CheckedChanged
        HabilitarFechas()
        Generar()
    End Sub

    Private Sub CmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEstado.SelectedIndexChanged
        Generar()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        ClsImpresionGrid.Imprimir(Dgv, Titulo(), Subtitulo())
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        ExportarExcel(Dgv, Titulo().Replace(" ", "_"))
    End Sub

    Private Sub Dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Dgv.CellFormatting
        ResaltarAtrasados(Dgv, e)
    End Sub

    'Reutiliza los reportes Crystal que ya existían (CrMateriales, CrDevolucionesrpt, CrSalidas)
    Private Sub BtnCrystal_Click(sender As Object, e As EventArgs) Handles BtnCrystal.Click
#If CRYSTAL Then
        Try
            Dim dset As New BD_Almacén2025DataSet
            Dim rep As New ClsReportes
            Dim parametros As New Dictionary(Of String, Object)
            Dim filtroFecha As String = ""
            If ChkFechas.Visible AndAlso ChkFechas.Checked Then
                filtroFecha = " where Fecha >= @Desde and Fecha < @Hasta"
                parametros.Add("@Desde", DtpDesde.Value.Date)
                parametros.Add("@Hasta", DtpHasta.Value.Date.AddDays(1))
            End If

            Dim FormReporte As New FrmReportes
            Select Case Tipo
                Case TipoReporte.Materiales
                    rep.GeneraReporte("select * from VistaConsulta_Material", dset, "VistaConsulta_Material", parametros)
                    Dim Cr As New CrMateriales
                    Cr.SetDataSource(dset)
                    FormReporte.CrystalReportViewer1.ReportSource = Cr
                Case TipoReporte.Devoluciones
                    rep.GeneraReporte("select * from VistaConsulta_Devoluciones" & filtroFecha, dset, "VistaConsulta_Devoluciones", parametros)
                    Dim Cr As New CrDevolucionesrpt
                    Cr.SetDataSource(dset)
                    FormReporte.CrystalReportViewer1.ReportSource = Cr
                Case TipoReporte.Salidas
                    rep.GeneraReporte("select * from VistaConsulta_Salidas" & filtroFecha, dset, "VistaConsulta_Salidas", parametros)
                    Dim Cr As New CrSalidas
                    Cr.SetDataSource(dset)
                    FormReporte.CrystalReportViewer1.ReportSource = Cr
                Case Else
                    Exit Sub
            End Select
            FormReporte.Text = Titulo().ToUpper()
            FormReporte.Show()
            FormReporte.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
#End If
    End Sub

End Class
