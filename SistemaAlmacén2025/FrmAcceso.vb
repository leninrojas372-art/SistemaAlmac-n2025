Public Class FrmAcceso

    Private Sub FrmAcceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmBienvenida.Timer1.Enabled = False
        FrmBienvenida.Hide()
        Me.AcceptButton = BtnIngresar   'Enter = Ingresar
    End Sub

    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        If Txtusuario.Text.Trim = "" OrElse Txtcontraseña.Text.Trim = "" Then
            MsgBox("Ingrese usuario y contraseña.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim CPersonal As New ClsPersonal
        Try
            Dim datos As DataTable = CPersonal.ObtenerAcceso(Txtusuario.Text.Trim, Txtcontraseña.Text.Trim)
            If datos.Rows.Count > 0 Then
                Dim fila As DataRow = datos.Rows(0)
                'Se guarda quién inició sesión (se usa como "atendido por" en préstamos y salidas)
                ModSesion.Iniciar(fila("DNIPersonal").ToString(), fila("ApellidosNombres").ToString(), fila("Cargo").ToString())
                Txtcontraseña.Text = ""
                Me.Hide()
                FrmPrincipal.Show()
            Else
                MsgBox("Datos incorrectos", MsgBoxStyle.Exclamation)
                Txtcontraseña.Focus()
            End If
        Catch ex As Exception
            ClsConexion.MostrarError(ex)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        End
    End Sub
End Class
