Imports System.Data
Imports System.Data.SqlClient

''' <summary>
''' Acceso a datos de los módulos Control, Consultas y Reportes.
''' Cada método llama a un procedimiento almacenado del script 01_ActualizarBD_ControlPrestamos.sql
''' Los errores se lanzan (Throw) para que el formulario decida cómo mostrarlos.
''' </summary>
Public Class ClsControl

    'Ejecuta un procedimiento que devuelve filas.
    'parametros = pares nombre/valor:  Ejecutar("Proc", "@Texto", "abc", "@Estado", "Pendiente")
    Public Shared Function Ejecutar(ByVal nombreProc As String, ByVal ParamArray parametros() As Object) As DataTable
        Dim dt As New DataTable(nombreProc)
        Using cn As New SqlConnection(ClsConexion.Cadena)
            Using cmd As New SqlCommand(nombreProc, cn)
                cmd.CommandType = CommandType.StoredProcedure
                For i As Integer = 0 To parametros.Length - 2 Step 2
                    Dim valor As Object = parametros(i + 1)
                    If valor Is Nothing Then valor = DBNull.Value
                    cmd.Parameters.AddWithValue(CStr(parametros(i)), valor)
                Next
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    '=============== 3. CONTROL ===============
    Public Shared Function MaterialesDisponibles(Optional ByVal texto As String = "") As DataTable
        Return Ejecutar("Control_MaterialesDisponibles", "@Texto", texto)
    End Function

    '¿Quién tiene este material?
    Public Shared Function MaterialesPrestados(Optional ByVal texto As String = "") As DataTable
        Return Ejecutar("Control_MaterialesPrestados", "@Texto", texto)
    End Function

    '¿Quién todavía no ha devuelto?
    Public Shared Function PrestamosPendientes(Optional ByVal texto As String = "") As DataTable
        Return Ejecutar("Control_PrestamosPendientes", "@Texto", texto)
    End Function

    Public Shared Function Devoluciones(Optional ByVal texto As String = "") As DataTable
        Return Ejecutar("Control_Devoluciones", "@Texto", texto)
    End Function

    Public Shared Function HistorialUsuario(ByVal dniONombre As String) As DataTable
        Return Ejecutar("Control_HistorialUsuario", "@Texto", dniONombre)
    End Function

    '=============== 4. CONSULTAS ===============
    Public Shared Function BuscarUsuario(Optional ByVal texto As String = "") As DataTable
        Return Ejecutar("Consulta_BuscarUsuario", "@Texto", texto)
    End Function

    '¿Qué materiales tiene esta persona?
    Public Shared Function MaterialesDeUsuario(ByVal dniUsuario As String) As DataTable
        Return Ejecutar("Consulta_MaterialesDeUsuario", "@DNIUsuario", dniUsuario)
    End Function

    Public Shared Function BuscarPrestamo(ByVal texto As String, ByVal estado As String) As DataTable
        Return Ejecutar("Consulta_BuscarPrestamo", "@Texto", texto, "@Estado", estado)
    End Function

    Public Shared Function DetallePrestamo(ByVal idPrestamo As Integer) As DataTable
        Return Ejecutar("Consulta_DetallePrestamo", "@IDPrestamo", idPrestamo)
    End Function

    'Cabecera de una solicitud (IDSolicitud, DNIUsuario, Usuario, Fecha, Estado) o Nothing
    Public Shared Function ObtenerSolicitud(ByVal idSolicitud As Integer) As DataRow
        Dim dt As DataTable = Ejecutar("Consulta_Solicitud", "@IDSolicitud", idSolicitud)
        If dt.Rows.Count = 0 Then Return Nothing
        Return dt.Rows(0)
    End Function

    'Materiales pedidos en la solicitud (IDMaterial, Material, EstadoMaterial, Cantidad, Stock)
    Public Shared Function DetalleSolicitud(ByVal idSolicitud As Integer) As DataTable
        Return Ejecutar("Consulta_DetalleSolicitud", "@IDSolicitud", idSolicitud)
    End Function

    'Solicitudes que todavía no se atienden
    Public Shared Function SolicitudesPendientes(Optional ByVal texto As String = "") As DataTable
        Return Ejecutar("Control_SolicitudesPendientes", "@Texto", texto)
    End Function

    'Lista de materiales para elegir en un ComboBox
    Public Shared Function ListaMateriales() As DataTable
        Return Ejecutar("CargarMaterial")
    End Function

    Public Shared Function Solicitudes() As DataTable
        Return Ejecutar("Consulta_Solicitudes")
    End Function

    'Devuelve la fila del material (IDMaterial, Nombre, Tipo, Estado, Stock) o Nothing si no existe
    Public Shared Function ObtenerMaterial(ByVal idMaterial As Integer) As DataRow
        Dim dt As DataTable = Ejecutar("Consulta_StockMaterial", "@IDMaterial", idMaterial)
        If dt.Rows.Count = 0 Then Return Nothing
        Return dt.Rows(0)
    End Function

    '=============== 5. REPORTES ===============
    Public Shared Function Reporte(ByVal nombreProc As String, ByVal desde As Object, ByVal hasta As Object,
                                   Optional ByVal estado As String = Nothing) As DataTable
        If estado Is Nothing Then
            Return Ejecutar(nombreProc, "@Desde", desde, "@Hasta", hasta)
        End If
        Return Ejecutar(nombreProc, "@Desde", desde, "@Hasta", hasta, "@Estado", estado)
    End Function

End Class
