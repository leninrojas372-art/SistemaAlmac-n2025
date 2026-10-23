Imports System.Drawing.Printing

''' <summary>
''' Imprime cualquier DataGridView con vista previa (horizontal, con título,
''' fecha de impresión, número de página y cortes de página automáticos).
''' Uso:  ClsImpresionGrid.Imprimir(DataGridView1, "Préstamos pendientes", "Filtro: todos")
''' </summary>
Public Class ClsImpresionGrid

    Private ReadOnly grilla As DataGridView
    Private ReadOnly titulo As String
    Private ReadOnly subtitulo As String
    Private columnas As List(Of DataGridViewColumn)
    Private filaActual As Integer
    Private pagina As Integer
    Private WithEvents documento As New PrintDocument

    Private Sub New(ByVal dgv As DataGridView, ByVal tit As String, ByVal subt As String)
        grilla = dgv
        titulo = tit
        subtitulo = subt
    End Sub

    Public Shared Sub Imprimir(ByVal dgv As DataGridView, ByVal titulo As String, Optional ByVal subtitulo As String = "")
        If dgv.Rows.Count = 0 Then
            MsgBox("No hay datos para imprimir.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim imp As New ClsImpresionGrid(dgv, titulo, subtitulo)
        imp.documento.DocumentName = titulo
        imp.documento.DefaultPageSettings.Landscape = True
        imp.documento.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)

        Using vista As New PrintPreviewDialog
            vista.Document = imp.documento
            vista.WindowState = FormWindowState.Maximized
            vista.ShowDialog()
        End Using
    End Sub

    Private Sub documento_BeginPrint(sender As Object, e As PrintEventArgs) Handles documento.BeginPrint
        filaActual = 0
        pagina = 0
        columnas = New List(Of DataGridViewColumn)
        For Each col As DataGridViewColumn In grilla.Columns
            If col.Visible Then columnas.Add(col)
        Next
        columnas.Sort(Function(a, b) a.DisplayIndex.CompareTo(b.DisplayIndex))
    End Sub

    Private Sub documento_PrintPage(sender As Object, e As PrintPageEventArgs) Handles documento.PrintPage
        pagina += 1
        Dim g As Graphics = e.Graphics
        Dim area As Rectangle = e.MarginBounds
        Dim y As Single = area.Top

        Using fTitulo As New Font("Segoe UI", 14, FontStyle.Bold),
              fSub As New Font("Segoe UI", 9),
              fCab As New Font("Segoe UI", 8, FontStyle.Bold),
              fCelda As New Font("Segoe UI", 8),
              formato As New StringFormat With {.Trimming = StringTrimming.EllipsisCharacter,
                                                .FormatFlags = StringFormatFlags.NoWrap,
                                                .LineAlignment = StringAlignment.Center}

            'Encabezado
            g.DrawString("SISTEMA ALMACÉN - " & titulo.ToUpper(), fTitulo, Brushes.Black, area.Left, y)
            y += fTitulo.GetHeight(g) + 2
            Dim info As String = "Impreso: " & Date.Now.ToString("dd/MM/yyyy HH:mm")
            If ModSesion.Iniciada Then info &= "   |   Por: " & ModSesion.NombrePersonal
            If subtitulo <> "" Then info = subtitulo & "   |   " & info
            g.DrawString(info, fSub, Brushes.DimGray, area.Left, y)
            g.DrawString("Página " & pagina, fSub, Brushes.DimGray, area.Right - 70, y)
            y += fSub.GetHeight(g) + 8

            'Anchos proporcionales al ancho de la hoja
            Dim anchoTotal As Single = 0
            For Each col In columnas
                anchoTotal += col.Width
            Next
            Dim escala As Single = area.Width / Math.Max(anchoTotal, 1)
            Dim altoFila As Single = fCelda.GetHeight(g) + 6

            'Cabecera de columnas
            Dim x As Single = area.Left
            For Each col In columnas
                Dim ancho As Single = col.Width * escala
                Dim r As New RectangleF(x, y, ancho, altoFila)
                g.FillRectangle(Brushes.Gainsboro, r)
                g.DrawRectangle(Pens.Gray, r.X, r.Y, r.Width, r.Height)
                g.DrawString(col.HeaderText, fCab, Brushes.Black, New RectangleF(r.X + 2, r.Y, r.Width - 4, r.Height), formato)
                x += ancho
            Next
            y += altoFila

            'Filas
            While filaActual < grilla.Rows.Count
                Dim fila As DataGridViewRow = grilla.Rows(filaActual)
                If fila.IsNewRow Then
                    filaActual += 1
                    Continue While
                End If
                If y + altoFila > area.Bottom Then
                    e.HasMorePages = True
                    Return
                End If

                x = area.Left
                For Each col In columnas
                    Dim ancho As Single = col.Width * escala
                    Dim r As New RectangleF(x, y, ancho, altoFila)
                    g.DrawRectangle(Pens.LightGray, r.X, r.Y, r.Width, r.Height)
                    Dim v As Object = fila.Cells(col.Index).FormattedValue
                    Dim texto As String = If(v Is Nothing, "", v.ToString().Trim())
                    g.DrawString(texto, fCelda, Brushes.Black, New RectangleF(r.X + 2, r.Y, r.Width - 4, r.Height), formato)
                    x += ancho
                Next
                y += altoFila
                filaActual += 1
            End While

            'Pie con total de registros en la última página
            y += 6
            g.DrawString("Total de registros: " & grilla.Rows.Count, fCab, Brushes.Black, area.Left, y)
        End Using
        e.HasMorePages = False
    End Sub

End Class
