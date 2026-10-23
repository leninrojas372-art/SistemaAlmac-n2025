Public Class ClsUsuarios
    Dim conexionBD As New ClsConexion

    Public Function RegistrarUsuarios(ByVal DNIUSuario, ByVal ApellidosNombres, ByVal ProgramaEstudios, ByVal TipoUsuarios, ByVal Ciclo, ByVal Telefono) As Boolean
        conexionBD.NCampo(1) = "@DNIUsuario"
        conexionBD.NCampo(2) = "@ApellidosNombres"
        conexionBD.NCampo(3) = "@ProgramaEstudios"
        conexionBD.NCampo(4) = "@TipoUsuarios"
        conexionBD.NCampo(5) = "@Ciclo"
        conexionBD.NCampo(6) = "@Telefono"

        conexionBD.NValor(1) = DNIUSuario
        conexionBD.NValor(2) = ApellidosNombres
        conexionBD.NValor(3) = ProgramaEstudios
        conexionBD.NValor(4) = TipoUsuarios
        conexionBD.NValor(5) = Ciclo
        conexionBD.NValor(6) = Telefono

        Return conexionBD.Procedimiento("RegistrarUsuarios", 6)
    End Function

    Public Function ModificarUsuarios(ByVal DNIUSuario, ByVal ApellidosNombres, ByVal ProgramaEstudios, ByVal TipoUsuarios, ByVal Ciclo, ByVal Telefono) As Boolean
        conexionBD.NCampo(1) = "@DNIUsuario"
        conexionBD.NCampo(2) = "@ApellidosNombres"
        conexionBD.NCampo(3) = "@ProgramaEstudios"
        conexionBD.NCampo(4) = "@TipoUsuarios"
        conexionBD.NCampo(5) = "@Ciclo"
        conexionBD.NCampo(6) = "@Telefono"

        conexionBD.NValor(1) = DNIUSuario
        conexionBD.NValor(2) = ApellidosNombres
        conexionBD.NValor(3) = ProgramaEstudios
        conexionBD.NValor(4) = TipoUsuarios
        conexionBD.NValor(5) = Ciclo
        conexionBD.NValor(6) = Telefono

        Return conexionBD.Procedimiento("ModificarUsuarios", 6)
    End Function
    Public Function EliminarUsuarios(ByVal DNIUSuario) As Boolean
        conexionBD.NCampo(1) = "@DNIUsuario"

        conexionBD.NValor(1) = DNIUSuario

        Return conexionBD.Procedimiento("EliminarUsuarios", 1)
    End Function
    Public Function CargarUsuarios()
        Return conexionBD.Cargar("CargarUsuarios")
    End Function
End Class
