
Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") IsNot Nothing Then
            MyBase.Response.Redirect("~/" & Session("tipo") & ".aspx")
        End If
        AccesoBD.AccesoBD.ConectarBD()
    End Sub

    Protected Sub SignUp_Click(sender As Object, e As EventArgs) Handles SignUp.Click
        Dim BD As New AccesoBD.AccesoBD
        Dim emaillib As New EmailLibrary.Solicitud
        Randomize()
        Dim numconfir As Integer = CInt(Int((10000 * Rnd()) + 1))
        Respuesta.Text = numconfir
        Dim passCod As String = MD5.MD5.Encode(Pass1.Text)
        Dim cm As New ComprobarMatricula.Matriculas
        Dim ps As New Pass.PasswordClient

        If cm.comprobar(Email.Text) = "SI" Then
            If ps.esSegura(Pass1.Text) = "valida" Then

                If (AccesoBD.AccesoBD.InsertarUsuario(Email.Text, Name.Text, LastName.Text, numconfir, Role.SelectedValue, passCod)) Then
                    Respuesta.Text = "Usuario registrado correctamente; en breve se le enviara un email de activacion."
                    Dim body As String = "<a href='https://" + HttpContext.Current.Request.Url.Host + ":55409/ActivarCuenta.aspx?email=" + Email.Text + "&cnf=" & numconfir & "'>Pulsa Aqui para activar tu cuenta!</a>"
                    emaillib.sendEmail(Email.Text, "Activacion de cuenta ", body)

                End If
            Else
                Respuesta.Text = "La contraseña no es segura :("
            End If
        Else
            Respuesta.Text = "Usted no está matriculado, matricúlese :)"

        End If
    End Sub

    Protected Sub LogIn_Click(sender As Object, e As EventArgs) Handles LogIn.Click
        MyBase.Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoBD.AccesoBD.cerrarBD()
    End Sub

    Protected Sub Email_TextChanged(sender As Object, e As EventArgs) Handles Email.TextChanged
        Dim cm As New ComprobarMatricula.Matriculas
        If cm.comprobar(Email.Text) = "SI" Then
            Matriculado.Text = "Puede registrarse tranquilamente :)"

            Dim ps As New Pass.PasswordClient
            If ps.esSegura(Pass1.Text) = "valida" Then
                SignUp.Enabled = True
            Else
                SignUp.Enabled = False
            End If

        Else
            Matriculado.Text = "Usted no está matriculado"
            SignUp.Enabled = False
        End If
    End Sub

    Protected Sub Pass1_TextChanged(sender As Object, e As EventArgs) Handles Pass1.TextChanged
        Dim ps As New Pass.PasswordClient
        If ps.esSegura(Pass1.Text) = "valida" Then
            Valida.Text = "La contraseña es segura :)"
            Dim cm As New ComprobarMatricula.Matriculas
            If cm.comprobar(Email.Text) = "SI" Then
                SignUp.Enabled = True
            Else
                SignUp.Enabled = False
            End If
        Else
            Valida.Text = "La contraseña no es segura :("
            SignUp.Enabled = False
        End If
    End Sub
End Class