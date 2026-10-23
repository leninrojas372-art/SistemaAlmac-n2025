Public Class Clsmaterial
    Dim conexionBD As New ClsConexion

    Public Function RegistrarMaterial(ByVal Nombre, ByVal Descripcion, ByVal Tipo, ByVal Estado, ByVal Stock) As Boolean
        conexionBD.NCampo(1) = "@Nombre"
        conexionBD.NCampo(2) = "@Descripcion"
        conexionBD.NCampo(3) = "@Tipo"
        conexionBD.NCampo(4) = "@Estado"
        conexionBD.NCampo(5) = "@Stock"

        conexionBD.NValor(1) = Nombre
        conexionBD.NValor(2) = Descripcion
        conexionBD.NValor(3) = Tipo
        conexionBD.NValor(4) = Estado
        conexionBD.NValor(5) = Stock

        Return conexionBD.Procedimiento("RegistrarMaterial", 5)
    End Function

    Public Function ModificarMaterial(ByVal IDMaterial, ByVal Nombre, ByVal Descripcion, ByVal Tipo, ByVal Estado, ByVal Stock) As Boolean
        conexionBD.NCampo(1) = "@IDMaterial"
        conexionBD.NCampo(2) = "@Nombre"
        conexionBD.NCampo(3) = "@Descripcion"
        conexionBD.NCampo(4) = "@Tipo"
        conexionBD.NCampo(5) = "@Estado"
        conexionBD.NCampo(6) = "@Stock"

        conexionBD.NValor(1) = IDMaterial
        conexionBD.NValor(2) = Nombre
        conexionBD.NValor(3) = Descripcion
        conexionBD.NValor(4) = Tipo
        conexionBD.NValor(5) = Estado
        conexionBD.NValor(6) = Stock

        Return conexionBD.Procedimiento("ModificarMaterial", 6)
    End Function
    Public Function EliminarMaterial(ByVal IDMaterial) As Boolean
        conexionBD.NCampo(1) = "@IDMaterial"

        conexionBD.NValor(1) = IDMaterial

        Return conexionBD.Procedimiento("EliminarMaterial", 1)
    End Function
    Public Function CargarMaterial()
        Return conexionBD.Cargar("CargarMaterial")
    End Function
End Class
