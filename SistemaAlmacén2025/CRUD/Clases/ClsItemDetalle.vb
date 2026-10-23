''' <summary>
''' Un renglón del detalle de un préstamo o de una salida (material + cantidad).
''' </summary>
Public Class ClsItemDetalle
    Public Property IDMaterial As Integer
    Public Property Cantidad As Integer

    Public Sub New(ByVal idMaterial As Integer, ByVal cantidad As Integer)
        Me.IDMaterial = idMaterial
        Me.Cantidad = cantidad
    End Sub
End Class
