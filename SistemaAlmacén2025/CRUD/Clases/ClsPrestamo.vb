Imports System.Data.SqlClient

Public Class ClsPrestamo

    Dim conexionBD As New ClsConexion

    ''' <summary>
    ''' Registra el préstamo y todos sus materiales en UNA sola transacción.
    ''' Si algún material no tiene stock suficiente, la base de datos lanza un error,
    ''' se deshace todo (no queda un préstamo a medias) y el error llega al formulario.
    ''' Devuelve el N° del préstamo creado. Cada material se descuenta del stock.
    ''' </summary>
    Public Function RegistrarPrestamoCompleto(ByVal DNIPersonal As String,
                                              ByVal IDSolicitud As Integer,
                                              ByVal Fecha As Date,
                                              ByVal Detalles As List(Of ClsItemDetalle)) As Integer
        Using cn As New SqlConnection(ClsConexion.Cadena)
            cn.Open()
            Using tr As SqlTransaction = cn.BeginTransaction()
                Try
                    Dim cmd As New SqlCommand("RegistrarPrestamo", cn, tr)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DNIPersonal", DNIPersonal)
                    cmd.Parameters.AddWithValue("@IDSolicitud", IDSolicitud)
                    cmd.Parameters.AddWithValue("@Fecha", Fecha)
                    Dim pSalida As SqlParameter = cmd.Parameters.Add("@NuevoId", SqlDbType.Int)
                    pSalida.Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    Dim nuevoId As Integer = CInt(pSalida.Value)

                    For Each item As ClsItemDetalle In Detalles
                        Dim cmdDet As New SqlCommand("RegistrarDetallePrestamo", cn, tr)
                        cmdDet.CommandType = CommandType.StoredProcedure
                        cmdDet.Parameters.AddWithValue("@IDPrestamo", nuevoId)
                        cmdDet.Parameters.AddWithValue("@IDMaterial", item.IDMaterial)
                        cmdDet.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                        cmdDet.ExecuteNonQuery()
                    Next

                    tr.Commit()
                    Return nuevoId
                Catch
                    tr.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Function

    'Se mantienen los métodos originales por compatibilidad
    Public Function RegistrarPrestamo(ByVal IdPrestamo As Integer,
                                 ByVal DNIPersonal As String,
                                 ByVal IDSolicitud As Integer,
                                 ByVal Fecha As String) As Integer

        conexionBD.NCampo(1) = "@IdPrestamo"
        conexionBD.NCampo(2) = "@DNIPersonal"
        conexionBD.NCampo(3) = "@IDSolicitud"
        conexionBD.NCampo(4) = "@Fecha"

        conexionBD.NValor(1) = IdPrestamo
        conexionBD.NValor(2) = DNIPersonal
        conexionBD.NValor(3) = IDSolicitud
        conexionBD.NValor(4) = Fecha

        conexionBD.NCampoSalida(1) = "@NuevoId"
        conexionBD.NValorSalida(1) = 0

        Dim resultado As ArrayList
        Dim ultimoId As Integer = 0
        resultado = conexionBD.ProcedimientoConSalida("RegistrarPrestamo", 4, 1)
        If resultado.Count > 0 Then
            ultimoId = CInt(resultado(0).ToString)
        End If
        Return ultimoId
    End Function

    Public Sub RegistrarDetallePrestamo(ByVal IDDetallePrestamo As Integer,
                                        ByVal IDPrestamo As Integer,
                                        ByVal IDMaterial As Integer,
                                        ByVal Cantidad As Integer)

        conexionBD.NCampo(1) = "@IDDetallePrestamo"
        conexionBD.NCampo(2) = "@IDPrestamo"
        conexionBD.NCampo(3) = "@IDMaterial"
        conexionBD.NCampo(4) = "@Cantidad"

        conexionBD.NValor(1) = IDDetallePrestamo
        conexionBD.NValor(2) = IDPrestamo
        conexionBD.NValor(3) = IDMaterial
        conexionBD.NValor(4) = Cantidad

        conexionBD.Procedimiento("RegistrarDetallePrestamo", 4)
    End Sub

    Public Function CargarPrestamo()
        Return conexionBD.Cargar("CargarPrestamo")
    End Function

    Public Function EliminarPrestamo(ByVal IDPrestamo As Integer) As Boolean
        conexionBD.NCampo(1) = "@IDPrestamo"
        conexionBD.NValor(1) = IDPrestamo
        Return conexionBD.Procedimiento("EliminarPrestamo", 1)
    End Function

End Class
