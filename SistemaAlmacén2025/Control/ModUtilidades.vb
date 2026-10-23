Imports System.IO
Imports System.Text
Imports System.Globalization

''' <summary>
''' Utilidades comunes para las grillas de Control, Consultas y Reportes.
''' </summary>
Public Module ModUtilidades

    'Días a partir de los cuales un préstamo pendiente se resalta en rojo
    Public Const DiasAlertaPrestamo As Integer = 7

    'Deja la grilla en modo solo lectura, con selección de fila completa y fechas legibles
    Public Sub ConfigurarGrilla(ByVal dgv As DataGridView)
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.MultiSelect = False
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.RowHeadersVisible = False
        dgv.BackgroundColor = Color.White
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250)
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
    End Sub

    'Asigna los datos y da formato a las columnas de fecha
    Public Sub MostrarEnGrilla(ByVal dgv As DataGridView, ByVal datos As DataTable)
        dgv.DataSource = datos
        For Each col As DataGridViewColumn In dgv.Columns
            If col.ValueType Is GetType(DateTime) Then
                col.DefaultCellStyle.Format = "dd/MM/yyyy"
            End If
        Next
        dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
    End Sub

    'Suma una columna numérica (si existe) de la tabla
    Public Function SumarColumna(ByVal datos As DataTable, ByVal columna As String) As Integer
        If datos Is Nothing OrElse Not datos.Columns.Contains(columna) Then Return 0
        Dim total As Integer = 0
        For Each fila As DataRow In datos.Rows
            If Not IsDBNull(fila(columna)) Then total += CInt(fila(columna))
        Next
        Return total
    End Function

    'Resalta en rojo las filas con más días que DiasAlertaPrestamo (columna "Días")
    Public Sub ResaltarAtrasados(ByVal dgv As DataGridView, ByVal e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse Not dgv.Columns.Contains("Días") Then Exit Sub
        Dim fila As DataGridViewRow = dgv.Rows(e.RowIndex)
        Dim valor As Object = fila.Cells("Días").Value
        If valor IsNot Nothing AndAlso Not IsDBNull(valor) AndAlso CInt(valor) > DiasAlertaPrestamo Then
            If dgv.Columns.Contains("Estado") Then
                Dim est As Object = fila.Cells("Estado").Value
                If est IsNot Nothing AndAlso est.ToString() <> "Pendiente" Then Exit Sub
            End If
            e.CellStyle.BackColor = Color.MistyRose
            e.CellStyle.ForeColor = Color.DarkRed
        End If
    End Sub

    'Exporta la grilla a un archivo CSV que Excel abre directamente
    Public Sub ExportarExcel(ByVal dgv As DataGridView, ByVal nombreSugerido As String)
        If dgv.Rows.Count = 0 Then
            MsgBox("No hay datos para exportar.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Using dlg As New SaveFileDialog
            dlg.Filter = "Archivo para Excel (*.csv)|*.csv"
            dlg.FileName = nombreSugerido & "_" & Date.Now.ToString("yyyyMMdd_HHmm") & ".csv"
            If dlg.ShowDialog() <> DialogResult.OK Then Exit Sub

            Dim sep As String = CultureInfo.CurrentCulture.TextInfo.ListSeparator
            Dim sb As New StringBuilder()
            Dim columnas As New List(Of DataGridViewColumn)
            For Each col As DataGridViewColumn In dgv.Columns
                If col.Visible Then columnas.Add(col)
            Next
            columnas.Sort(Function(a, b) a.DisplayIndex.CompareTo(b.DisplayIndex))

            sb.AppendLine(String.Join(sep, columnas.Select(Function(c) CampoCsv(c.HeaderText, sep))))
            For Each fila As DataGridViewRow In dgv.Rows
                If fila.IsNewRow Then Continue For
                Dim valores As New List(Of String)
                For Each col As DataGridViewColumn In columnas
                    Dim v As Object = fila.Cells(col.Index).FormattedValue
                    valores.Add(CampoCsv(If(v Is Nothing, "", v.ToString()), sep))
                Next
                sb.AppendLine(String.Join(sep, valores))
            Next

            Try
                File.WriteAllText(dlg.FileName, sb.ToString(), New UTF8Encoding(True))
                If MsgBox("Archivo exportado correctamente." & vbCrLf & "¿Desea abrirlo ahora?",
                          MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    Process.Start(dlg.FileName)
                End If
            Catch ex As Exception
                MsgBox("No se pudo guardar el archivo: " & ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End Using
    End Sub

    Private Function CampoCsv(ByVal texto As String, ByVal sep As String) As String
        texto = texto.Trim()
        If texto.Contains(sep) OrElse texto.Contains("""") OrElse texto.Contains(vbCr) OrElse texto.Contains(vbLf) Then
            Return """" & texto.Replace("""", """""") & """"
        End If
        Return texto
    End Function

    'Valida que el texto sea un entero positivo
    Public Function EsEnteroPositivo(ByVal texto As String, ByRef valor As Integer) As Boolean
        Return Integer.TryParse(texto.Trim(), valor) AndAlso valor > 0
    End Function

End Module
