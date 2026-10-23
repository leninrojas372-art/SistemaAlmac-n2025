''' <summary>
''' Guarda los datos del personal que inició sesión.
''' Se usa para proponer automáticamente quién atiende un préstamo o una salida.
''' </summary>
Public Module ModSesion
    Public DNIPersonal As String = ""
    Public NombrePersonal As String = ""
    Public CargoPersonal As String = ""

    Public ReadOnly Property Iniciada As Boolean
        Get
            Return DNIPersonal <> ""
        End Get
    End Property

    Public Sub Iniciar(ByVal dni As String, ByVal nombre As String, ByVal cargo As String)
        DNIPersonal = dni.Trim()
        NombrePersonal = nombre.Trim()
        CargoPersonal = cargo.Trim()
    End Sub

    Public Sub Cerrar()
        DNIPersonal = ""
        NombrePersonal = ""
        CargoPersonal = ""
    End Sub
End Module
