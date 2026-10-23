Imports System.Data.SqlClient

Public Class ClsSolicitud
    Dim conexionBD As New ClsConexion
    Public Function RegistrarSolicitud(ByVal IDSolicitud, ByVal DNIUsuario, ByVal Fecha) As Boolean
        conexionBD.NCampo(1) = "@IDSolicitud"
        conexionBD.NCampo(2) = "@DNIUsuario"
        conexionBD.NCampo(3) = "@Fecha"

        conexionBD.NValor(1) = IDSolicitud
        conexionBD.NValor(2) = DNIUsuario
        conexionBD.NValor(3) = Fecha

        Return conexionBD.Procedimiento("RegistrarSolicitud", 3)
    End Function
    Public Function ModificarSolicitud(ByVal IDSolicitud, ByVal DNIUsuario, ByVal Fecha) As Boolean
        conexionBD.NCampo(1) = "@IDSolicitud"
        conexionBD.NCampo(2) = "@DNIUsuario"
        conexionBD.NCampo(3) = "@Fecha"

        conexionBD.NValor(1) = IDSolicitud
        conexionBD.NValor(2) = DNIUsuario
        conexionBD.NValor(3) = Fecha

        Return conexionBD.Procedimiento("ModificarSolicitud", 3)
    End Function
    Public Function EliminarSolicitud(ByVal IDSolicitud) As Boolean

        conexionBD.NCampo(1) = "@IDSolicitud"

        conexionBD.NValor(1) = IDSolicitud

        Return conexionBD.Procedimiento("EliminarSolicitud", 1)
    End Function
    Public Function CargarSolicitud()
        Return conexionBD.Cargar("CargarSolicitud")
    End Function

    ''' <summary>
    ''' Registra la solicitud y los materiales pedidos en UNA transacción.
    ''' La solicitud queda en estado Pendiente. No descuenta stock (solo es un pedido).
    ''' Devuelve el N° de solicitud creado.
    ''' </summary>
    Public Function RegistrarSolicitudCompleta(ByVal DNIUsuario As String, ByVal Fecha As Date,
                                               ByVal Detalles As List(Of ClsItemDetalle)) As Integer
        Using cn As New SqlConnection(ClsConexion.Cadena)
            cn.Open()
            Using tr As SqlTransaction = cn.BeginTransaction()
                Try
                    Dim cmd As New SqlCommand("RegistrarSolicitud", cn, tr)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DNIUsuario", DNIUsuario)
                    cmd.Parameters.AddWithValue("@Fecha", Fecha)
                    Dim pSalida As SqlParameter = cmd.Parameters.Add("@NuevoId", SqlDbType.Int)
                    pSalida.Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    Dim nuevoId As Integer = CInt(pSalida.Value)

                    GrabarDetalle(cn, tr, nuevoId, Detalles)
                    tr.Commit()
                    Return nuevoId
                Catch
                    tr.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Modifica una solicitud Pendiente: datos de cabecera y lista completa de materiales.
    ''' </summary>
    Public Sub ActualizarSolicitudCompleta(ByVal IDSolicitud As Integer, ByVal DNIUsuario As String, ByVal Fecha As Date,
                                           ByVal Detalles As List(Of ClsItemDetalle))
        Using cn As New SqlConnection(ClsConexion.Cadena)
            cn.Open()
            Using tr As SqlTransaction = cn.BeginTransaction()
                Try
                    Dim cmd As New SqlCommand("ModificarSolicitud", cn, tr)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@IDSolicitud", IDSolicitud)
                    cmd.Parameters.AddWithValue("@DNIUsuario", DNIUsuario)
                    cmd.Parameters.AddWithValue("@Fecha", Fecha)
                    cmd.ExecuteNonQuery()

                    Dim cmdDel As New SqlCommand("EliminarDetallesSolicitud", cn, tr)
                    cmdDel.CommandType = CommandType.StoredProcedure
                    cmdDel.Parameters.AddWithValue("@IDSolicitud", IDSolicitud)
                    cmdDel.ExecuteNonQuery()

                    GrabarDetalle(cn, tr, IDSolicitud, Detalles)
                    tr.Commit()
                Catch
                    tr.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    Private Sub GrabarDetalle(ByVal cn As SqlConnection, ByVal tr As SqlTransaction, ByVal IDSolicitud As Integer,
                              ByVal Detalles As List(Of ClsItemDetalle))
        For Each item As ClsItemDetalle In Detalles
            Dim cmdDet As New SqlCommand("RegistrarDetalleSolicitud", cn, tr)
            cmdDet.CommandType = CommandType.StoredProcedure
            cmdDet.Parameters.AddWithValue("@IDSolicitud", IDSolicitud)
            cmdDet.Parameters.AddWithValue("@IDMaterial", item.IDMaterial)
            cmdDet.Parameters.AddWithValue("@Cantidad", item.Cantidad)
            cmdDet.ExecuteNonQuery()
        Next
    End Sub

    Public Function AnularSolicitud(ByVal IDSolicitud As Integer) As Boolean
        conexionBD.NCampo(1) = "@IDSolicitud"
        conexionBD.NValor(1) = IDSolicitud
        Return conexionBD.Procedimiento("AnularSolicitud", 1)
    End Function
End Class
