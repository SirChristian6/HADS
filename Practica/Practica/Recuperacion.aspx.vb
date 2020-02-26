Imports AccesoBD
Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AccesoBD.AccesoBD.conectarBD()
        If Not Page.IsPostBack Then
            If Request IsNot Nothing Then
                Email.Text = Request.Params("correo")
                NumConfirmacion.Text = Request.Params("cnf")
            End If
        End If
    End Sub

    Protected Sub Change_Click(sender As Object, e As EventArgs) Handles Change.Click
        Dim numconfir As Integer = NumConfirmacion.Text
        If (AccesoBD.AccesoBD.cambiarPass(Email.Text, Pass1.Text, numconfir)) Then
            Response2.Text = "Contraseña cambiada correctamente."
        Else Response2.Text = "Datos incorrectos."
        End If
    End Sub

    Protected Sub ChangeRequest_Click(sender As Object, e As EventArgs) Handles ChangeRequest.Click
        Randomize()
        Dim numconfir As Integer = CInt(Int((10000000 * Rnd()) + 1))
        If (AccesoBD.AccesoBD.anadirSolicitudCambioPass(Email.Text, numconfir)) Then
            Response1.Text = "En breve recibirá un email con el código de validación, introduzcalo a continuación para cambiarlo por la contraseña deseada"
            Dim body As String = "<a href='https://" + HttpContext.Current.Request.Url.Host + ":55409/Recuperacion.aspx?correo=" + Email.Text + "&cnf=" & numconfir & "'>Pulsa Aqui para cambiar tu contraseña </a> o copia el codigo:" & numconfir
            Dim emaillib As New EmailLibrary.Solicitud
            emaillib.sendEmail(Email.Text, "Cambio de contraseña ", body)
        Else Response1.Text = "No se ha encontrado el email en nuestra base de usuarios, por favor compruebe que sea correcto."
        End If
    End Sub

    Protected Sub LogIn_Click(sender As Object, e As EventArgs) Handles LogIn.Click
        Response.Redirect("~/default.aspx")
    End Sub
End Class