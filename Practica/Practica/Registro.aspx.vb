
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
        Response.Text = numconfir
        Dim passCod As String = MD5.MD5.Encode(Pass1.Text)

        If (AccesoBD.AccesoBD.InsertarUsuario(Email.Text, Name.Text, LastName.Text, numconfir, Role.SelectedValue, passCod)) Then
            Response.Text = "Usuario registrado correctamente; en breve se le enviara un email de activacion."
            Dim body As String = "<a href='https://" + HttpContext.Current.Request.Url.Host + ":55409/ActivarCuenta.aspx?email=" + Email.Text + "&cnf=" & numconfir & "'>Pulsa Aqui para activar tu cuenta!</a>"
            emaillib.sendEmail(Email.Text, "Activacion de cuenta ", body)

        End If
    End Sub

    Protected Sub LogIn_Click(sender As Object, e As EventArgs) Handles LogIn.Click
        MyBase.Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoBD.AccesoBD.cerrarBD()
    End Sub
End Class