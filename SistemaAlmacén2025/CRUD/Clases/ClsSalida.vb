Imports System.Data.SqlClient

Public Class ClsSalida
    Dim conexionBD As New ClsConexion

    ''' <summary>
    ''' Registra la salida definitiva y sus materiales en UNA transacción.
    ''' Cada material se descuenta del stock; si no alcanza, se deshace todo.
    ''' Devuelve el N° de salida creado.
    ''' </summary>
    Public Function RegistrarSalidaCompleta(ByVal DNIPersonal As String,
                                            ByVal IDSolicitud As Integer,
                                            ByVal Fecha As Date,
                                            ByVal Detalles As List(Of ClsItemDetalle)) As Integer
        Using cn As New SqlConnection(ClsConexion.Cadena)
            cn.Open()
            Using tr As SqlTransaction = cn.BeginTransaction()
                Try
                    Dim cmd As New SqlCommand("RegistrarSalidas", cn, tr)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DNIPersonal", DNIPersonal)
                    cmd.Parameters.AddWithValue("@IDSolicitud", IDSolicitud)
                    cmd.Parameters.AddWithValue("@Fecha", Fecha)
                    Dim pSalida As SqlParameter = cmd.Parameters.Add("@NuevoId", SqlDbType.Int)
                    pSalida.Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    Dim nuevoId As Integer = CInt(pSalida.Value)

                    For Each item As ClsItemDetalle In Detalles
                        Dim cmdDet As New SqlCommand("RegistrarDetalleSalidas", cn, tr)
                        cmdDet.CommandType = CommandType.StoredProcedure
                        cmdDet.Parameters.AddWithValue("@IDSalidas", nuevoId)
                        cmdDet.Parameters.AddWithValue("@IDMaterial", item.IDMaterial)
                        cmdDet.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                        cmdDet.ExecuteNonQuery()
                    Next

                    tr.Commit()
                    Return nuevoId
                Catch ex As Exception
                    ' Validamos si la transacción sigue activa antes de hacer Rollback
                    Try
                        If tr.Connection IsNot Nothing Then
                            tr.Rollback()
                        End If
                    Catch
                        ' Ignoramos si ya estaba cerrada para evitar excepciones adicionales
                    End Try

                    ' Lanzamos la excepción con el mensaje real de SQL Server
                    Throw New Exception("Error al registrar la salida completa: " & ex.Message)
                End Try
            End Using
        End Using
    End Function

    ' Se mantienen los métodos originales por compatibilidad
    Public Function RegistrarSalidas(ByVal IdSalidas, ByVal DNIPersonal, ByVal IDSolicitud, ByVal Fecha)
        conexionBD.NCampo(1) = "@IdSalidas"
        conexionBD.NCampo(2) = "@DNIPersonal"
        conexionBD.NCampo(3) = "@IDSolicitud"
        conexionBD.NCampo(4) = "@Fecha"

        conexionBD.NValor(1) = IdSalidas
        conexionBD.NValor(2) = DNIPersonal
        conexionBD.NValor(3) = IDSolicitud
        conexionBD.NValor(4) = Fecha

        conexionBD.NCampoSalida(1) = "@NuevoId"
        conexionBD.NValorSalida(1) = 0

        Dim resultado As ArrayList
        Dim ultimoId As Integer = 0
        resultado = conexionBD.ProcedimientoConSalida("RegistrarSalidas", 4, 1)
        If resultado.Count > 0 Then
            ultimoId = CInt(resultado(0).ToString)
        End If
        Return ultimoId
    End Function

    Public Sub RegistrarDetalleSalidas(ByVal IDDetalleSalidas, ByVal IDSalidas, ByVal IDmaterial, ByVal Cantidad)
        conexionBD.NCampo(1) = "@IDDetalleSalidas"
        conexionBD.NCampo(2) = "@IdSalidas"
        conexionBD.NCampo(3) = "@IDmaterial"
        conexionBD.NCampo(4) = "@Cantidad"

        conexionBD.NValor(1) = IDDetalleSalidas
        conexionBD.NValor(2) = IDSalidas
        conexionBD.NValor(3) = IDmaterial
        conexionBD.NValor(4) = Cantidad

        conexionBD.Procedimiento("RegistrarDetalleSalidas", 4)
    End Sub

    Public Function CargarSalidas()
        Return conexionBD.Cargar("CargarSalidas")
    End Function

End Class