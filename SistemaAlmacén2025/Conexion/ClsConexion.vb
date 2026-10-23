Imports System.Data
Imports System.Data.SqlClient
Public Class ClsConexion
    'Cadena de conexión única para todo el sistema (antes estaba repetida en varias clases)
    ' Public Shared ReadOnly Cadena As String = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Almacén2025;Integrated Security=True;Encrypt=False"
    Public Shared ReadOnly Cadena As String = "Data Source=localhost;Initial Catalog=BD_Almacén2025;Integrated Security=True;Encrypt=False"
    Dim Conexion As New SqlConnection(Cadena)

    Public NCampo(100) As String
    Public NValor(100) As String
    Public NCampoSalida(100) As String
    Public NValorSalida(100) As String

    Dim cmd As SqlCommand

    'Muestra el error de forma entendible. Los errores lanzados desde los procedimientos
    '(THROW 50000+) traen un mensaje pensado para el usuario.
    Public Shared Sub MostrarError(ByVal ex As Exception)
        If TypeOf ex Is SqlException Then
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Almacén")
        Else
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    'Devuelve True si el procedimiento se ejecutó sin errores
    Public Function Procedimiento(ByVal NombreProc, ByVal xParam) As Boolean
        Dim i As Integer
        Try
            Conexion.Open()
            cmd = New SqlCommand(NombreProc, Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            For i = 1 To xParam
                cmd.Parameters.AddWithValue(NCampo(i), NValor(i))
            Next

            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MostrarError(ex)
            Return False
        Finally
            Conexion.Close()
        End Try
    End Function

    Public Function ProcedimientoConSalida(ByVal NombreProc, ByVal xParam, Optional ByVal xParamSalida = 0) As ArrayList
        Dim i As Integer
        Dim lista As New ArrayList
        Try
            Conexion.Open()
            cmd = New SqlCommand(NombreProc, Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            'Parámetros de entrada
            For i = 1 To xParam
                cmd.Parameters.AddWithValue(NCampo(i), NValor(i))
            Next

            'Parámetros de salida
            For i = 1 To xParamSalida
                Dim paramSalida As New SqlParameter()
                paramSalida.ParameterName = NCampoSalida(i)
                paramSalida.SqlDbType = SqlDbType.Int
                paramSalida.Direction = ParameterDirection.Output
                cmd.Parameters.Add(paramSalida)
            Next
            cmd.ExecuteNonQuery()

            'Obtener los valores de salida de la ejecución
            For i = 1 To xParamSalida
                lista.Add(cmd.Parameters(NCampoSalida(i)).Value)
            Next

        Catch ex As Exception
            MostrarError(ex)
        Finally
            Conexion.Close()
        End Try
        Return lista
    End Function
    Dim Dset As DataSet
    Dim Adap As SqlDataAdapter
    Public Function Cargar(ByVal NombreProc) As DataSet
        Dset = New DataSet
        Try
            Conexion.Open()
            cmd = New SqlCommand(NombreProc, Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            Adap = New SqlDataAdapter(cmd)
            Adap.Fill(Dset, NombreProc)
        Finally
            Conexion.Close()
        End Try
        Return Dset
    End Function

    Public Sub Imprimir(ByVal Cadena As String, ByVal NombreDset As DataSet,
ByVal NombreTabla As String, Optional ByVal Parametros As Dictionary(Of String, Object) = Nothing)
        Try
            Conexion.Open()
            cmd = New SqlCommand(Cadena, Conexion)
            If Parametros IsNot Nothing Then
                For Each kv In Parametros
                    cmd.Parameters.AddWithValue(kv.Key, kv.Value)
                Next
            End If
            Adap = New SqlDataAdapter(cmd)
            Adap.Fill(NombreDset, NombreTabla)
        Finally
            Conexion.Close()
        End Try
    End Sub

    Public Function CargarConParametros(ByVal NombreProc, ByVal xParam) As DataSet
        Dim i As Integer
        Dset = New DataSet
        Try
            Conexion.Open()
            cmd = New SqlCommand(NombreProc, Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            For i = 1 To xParam
                cmd.Parameters.AddWithValue(NCampo(i), NValor(i))
            Next
            Adap = New SqlDataAdapter(cmd)
            Adap.Fill(Dset, NombreProc)
        Finally
            Conexion.Close()
        End Try
        Return Dset
    End Function
End Class
