Imports System.Data
Imports System.Data.SqlClient

Public Class ClsReportes
    Dim ConexionR As New ClsConexion

    Public Sub GeneraReporte(ByVal Consulta As String, ByVal NombreDset As DataSet, ByVal NombreTabla As String, Optional ByVal Parametros As Dictionary(Of String, Object) = Nothing)
        ConexionR.Imprimir(Consulta, NombreDset, NombreTabla, Parametros)

    End Sub

End Class
