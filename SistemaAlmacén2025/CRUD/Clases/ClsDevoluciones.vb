Public Class ClsDevoluciones
    Dim conexionBD As New ClsConexion
    Public Function RegistrarDevoluciones(ByVal IDPrestamo, ByVal Fecha, ByVal Condicion, ByVal Observacion) As Integer
        conexionBD.NCampo(1) = "@IDPrestamo"
        conexionBD.NCampo(2) = "@Fecha"
        conexionBD.NCampo(3) = "@Condicion"
        conexionBD.NCampo(4) = "@Observacion"

        conexionBD.NValor(1) = IDPrestamo
        conexionBD.NValor(2) = Fecha
        conexionBD.NValor(3) = Condicion
        conexionBD.NValor(4) = Observacion

        conexionBD.NCampoSalida(1) = "@NuevoId"

        Dim resultado As ArrayList = conexionBD.ProcedimientoConSalida("RegistrarDevoluciones", 4, 1)
        Dim nuevoId As Integer = 0
        If resultado.Count > 0 Then
            nuevoId = CInt(resultado(0).ToString)
        End If
        Return nuevoId
    End Function
    Public Function ModificarDevoluciones(ByVal IDDevoluciones, ByVal IDPrestamo, ByVal Fecha, ByVal Condicion, ByVal Observacion) As Boolean
        conexionBD.NCampo(1) = "@IDDevoluciones"
        conexionBD.NCampo(2) = "@IDPrestamo"
        conexionBD.NCampo(3) = "@Fecha"
        conexionBD.NCampo(4) = "@Condicion"
        conexionBD.NCampo(5) = "@Observacion"

        conexionBD.NValor(1) = IDDevoluciones
        conexionBD.NValor(2) = IDPrestamo
        conexionBD.NValor(3) = Fecha
        conexionBD.NValor(4) = Condicion
        conexionBD.NValor(5) = Observacion

        Return conexionBD.Procedimiento("ModificarDevoluciones", 5)
    End Function
    Public Function EliminarDevoluciones(ByVal IDDevoluciones) As Boolean

        conexionBD.NCampo(1) = "@IDDevoluciones"

        conexionBD.NValor(1) = IDDevoluciones

        Return conexionBD.Procedimiento("EliminarDevoluciones", 1)
    End Function
    Public Function CargarDevoluciones()
        Return conexionBD.Cargar("CargarDevoluciones")
    End Function
End Class
