Imports System.Data
Imports System.Data.SqlClient

Public Class ClsConsultas

    Public conexionConsultas As New SqlConnection(ClsConexion.Cadena)
    Public Adapter As SqlDataAdapter
    Public DSet As New DataSet
    Public Comando As New SqlCommand

    Public Sub BuscarSolicitudParaPrestamo(ByVal IDSolicitud As String)

        Dim sql As String = "SELECT * FROM Prestamo WHERE IDSolicitud = @IDSolicitud"
        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@IDSolicitud", IDSolicitud)

        DSet = New DataSet()
        Adapter.Fill(DSet, "Prestamo")
    End Sub

    Public Sub BuscarPersonalParaSalida(ByVal DNIPersonal As String)

        'CORREGIDO: antes buscaba en la tabla Salidas; ahora busca en Personal (sin mostrar la contraseña)
        Dim sql As String = "SELECT DNIPersonal, Apellidosnombres, Cargo, Telefono FROM Personal " &
                            "WHERE DNIPersonal LIKE @DNIPersonal + '%' OR Apellidosnombres LIKE '%' + @DNIPersonal + '%'"

        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@DNIPersonal", DNIPersonal)

        DSet = New DataSet()
        Adapter.Fill(DSet, "Personal")



    End Sub
    Public Sub BuscarSolicitudParaSalida(ByVal IDSolicitud As String)

        Dim sql As String = "SELECT * FROM Salidas WHERE IDSolicitud = @IDSolicitud"

        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@IDSolicitud", IDSolicitud)

        DSet = New DataSet()
        Adapter.Fill(DSet, "Salidas")
    End Sub

    Public Sub BuscarUsuarioParaSolicitud(ByVal DNIUsuario As String)

        'CORREGIDO: antes buscaba en Solicitud; ahora busca el usuario por DNI o nombre
        Dim sql As String = "SELECT * FROM Usuarios " &
                            "WHERE DNIUsuario LIKE @DNIUsuario + '%' OR ApellidosNombres LIKE '%' + @DNIUsuario + '%'"

        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@DNIUsuario", DNIUsuario)

        DSet = New DataSet()
        Adapter.Fill(DSet, "Usuarios")
    End Sub
    Public Sub BuscarMaterialParaSalidas(ByVal IDMaterial As String)

        'CORREGIDO: la tabla Salidas no tiene IDMaterial (se caía); ahora busca en Material por ID o nombre
        Dim sql As String = "SELECT * FROM Material " &
                            "WHERE CONVERT(varchar, IDMaterial) LIKE @IDMaterial + '%' OR Nombre LIKE '%' + @IDMaterial + '%'"

        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@IDMaterial", IDMaterial)

        DSet = New DataSet()
        Adapter.Fill(DSet, "Material")
    End Sub

    Public Sub BuscarPersonalParaPrestamo(ByVal DNIPersonal As String)

        'CORREGIDO: antes buscaba en Prestamo; ahora busca en Personal (sin mostrar la contraseña)
        Dim sql As String = "SELECT DNIPersonal, Apellidosnombres, Cargo, Telefono FROM Personal " &
                            "WHERE DNIPersonal LIKE @DNIPersonal + '%' OR Apellidosnombres LIKE '%' + @DNIPersonal + '%'"
        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@DNIPersonal", DNIPersonal)

        DSet = New DataSet()
        Adapter.Fill(DSet, "Personal")
    End Sub
    Public Sub BuscarMaterialParaPrestamo(ByVal IDMaterial As String)

        Dim sql As String = "SELECT * FROM Material " &
                            "WHERE CONVERT(varchar, IDMaterial) LIKE @IDMaterial + '%' OR Nombre LIKE '%' + @IDMaterial + '%'"

        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@IDMaterial", IDMaterial)

        DSet = New DataSet()
        Adapter.Fill(DSet, "Material")
    End Sub

    Public Sub ConsultaBuscarMaterialPorID(ByVal IDMaterial As String)
        Dim sql As String = "SELECT * FROM VistaConsulta_Material WHERE IDMaterial LIKE @IDMaterial + '%'"
        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@IDMaterial", IDMaterial)
        DSet = New DataSet
        Adapter.Fill(DSet, "VistaConsulta_Material")
        Comando = New SqlCommand
    End Sub
    Public Sub ConsultaBuscarMaterialPorNombre(ByVal Nombre As String)
        Dim sql As String = "SELECT * FROM VistaConsulta_Material WHERE Nombre LIKE @Nombre + '%'"
        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@Nombre", Nombre)
        DSet = New DataSet
        Adapter.Fill(DSet, "VistaConsulta_Material")
        Comando = New SqlCommand
    End Sub

    Public Sub ConsultaBuscarSalidaPorID(ByVal IDSalida As String)
        Dim sql As String = "SELECT * FROM VistaConsulta_Salidas WHERE IDSalidas LIKE @IDSalidas + '%'"
        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@IDSalidas", IDSalida)
        DSet = New DataSet
        Adapter.Fill(DSet, "VistaConsulta_Salidas")
        Comando = New SqlCommand
    End Sub
    Public Sub ConsultaBuscarSalidaPorNombreMaterial(ByVal Nombre As String)
        Dim sql As String = "SELECT * FROM VistaConsulta_Salidas WHERE Nombre LIKE @Nombre + '%'"
        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@Nombre", Nombre)
        DSet = New DataSet
        Adapter.Fill(DSet, "VistaConsulta_Salidas")
        Comando = New SqlCommand
    End Sub
    Public Sub ConsultaBuscarDevolucionPorID(ByVal IDDevoluciones As String)
        Dim sql As String = "SELECT * FROM VistaConsulta_Devoluciones WHERE IDDevoluciones LIKE @IDDevoluciones + '%'"
        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@IDDevoluciones", IDDevoluciones)
        DSet = New DataSet
        Adapter.Fill(DSet, "VistaConsulta_Devoluciones")
        Comando = New SqlCommand
    End Sub
    Public Sub ConsultaBuscarDevolucionPorNombreMaterial(ByVal Nombre As String)
        Dim sql As String = "SELECT * FROM VistaConsulta_Devoluciones WHERE Nombre LIKE @Nombre + '%'"
        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@Nombre", Nombre)
        DSet = New DataSet
        Adapter.Fill(DSet, "VistaConsulta_Devoluciones")
        Comando = New SqlCommand
    End Sub

    Public Sub ConsultaBuscarIDPrestamoParaDevolucion(ByVal IDPresamo As String)
        Dim sql As String = "SELECT * FROM Prestamo WHERE CONVERT(varchar, IDPrestamo) LIKE @IDPrestamo + '%'"
        Adapter = New SqlDataAdapter(sql, conexionConsultas)
        Adapter.SelectCommand.Parameters.AddWithValue("@IDPrestamo", IDPresamo)
        DSet = New DataSet
        Adapter.Fill(DSet, "Prestamo")
        Comando = New SqlCommand
    End Sub

End Class
