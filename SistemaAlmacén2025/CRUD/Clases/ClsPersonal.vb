Public Class ClsPersonal
    Dim conexionBD As New ClsConexion
    Public Function RegistrarPersonal(ByVal DNIPersonal, ByVal ApellidosNombres, ByVal Cargo, ByVal Telefono, ByVal Usuario, ByVal Contraseña) As Boolean
        conexionBD.NCampo(1) = "@DNIPersonal"
        conexionBD.NCampo(2) = "@ApellidosNombres"
        conexionBD.NCampo(3) = "@Cargo"
        conexionBD.NCampo(4) = "@Telefono"
        conexionBD.NCampo(5) = "@USuario"
        conexionBD.NCampo(6) = "@Contraseña"

        conexionBD.NValor(1) = DNIPersonal
        conexionBD.NValor(2) = ApellidosNombres
        conexionBD.NValor(3) = Cargo
        conexionBD.NValor(4) = Telefono
        conexionBD.NValor(5) = Usuario
        conexionBD.NValor(6) = Contraseña

        Return conexionBD.Procedimiento("RegistrarPersonal", 6)
    End Function
    Public Function ModificarPersonal(ByVal DNIPersonal, ByVal ApellidosNombres, ByVal Cargo, ByVal Telefono, ByVal Usuario, ByVal Contraseña) As Boolean
        conexionBD.NCampo(1) = "@DNIPersonal"
        conexionBD.NCampo(2) = "@ApellidosNombres"
        conexionBD.NCampo(3) = "@Cargo"
        conexionBD.NCampo(4) = "@Telefono"
        conexionBD.NCampo(5) = "@USuario"
        conexionBD.NCampo(6) = "@Contraseña"

        conexionBD.NValor(1) = DNIPersonal
        conexionBD.NValor(2) = ApellidosNombres
        conexionBD.NValor(3) = Cargo
        conexionBD.NValor(4) = Telefono
        conexionBD.NValor(5) = Usuario
        conexionBD.NValor(6) = Contraseña

        Return conexionBD.Procedimiento("ModificarPersonal", 6)
    End Function
    Public Function EliminarPersonal(ByVal DNIPersonal) As Boolean
        conexionBD.NCampo(1) = "@DNIPersonal"

        conexionBD.NValor(1) = DNIPersonal

        Return conexionBD.Procedimiento("EliminarPersonal", 1)
    End Function
    Public Function CargarPersonal()
        Return conexionBD.Cargar("CargarPersonal")
    End Function

    Public Function ValidarAcceso(ByVal Usuario As String, ByVal Contraseña As String) As Boolean
        conexionBD.NCampo(1) = "@Usuario"
        conexionBD.NCampo(2) = "@Contraseña"

        conexionBD.NValor(1) = Usuario
        conexionBD.NValor(2) = Contraseña

        Dim resultado As DataSet = conexionBD.CargarConParametros("ValidarAcceso", 2)
        Return resultado.Tables(0).Rows.Count > 0
    End Function

    'Devuelve los datos del personal (DNIPersonal, ApellidosNombres, Cargo) si usuario y contraseña son correctos
    Public Function ObtenerAcceso(ByVal Usuario As String, ByVal Contraseña As String) As DataTable
        conexionBD.NCampo(1) = "@Usuario"
        conexionBD.NCampo(2) = "@Contraseña"

        conexionBD.NValor(1) = Usuario
        conexionBD.NValor(2) = Contraseña

        Return conexionBD.CargarConParametros("ValidarAcceso", 2).Tables(0)
    End Function
End Class
