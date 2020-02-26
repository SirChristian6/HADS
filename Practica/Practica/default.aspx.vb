Imports AccesoBD
Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") IsNot Nothing Then
            MyBase.Response.Redirect("~/Menu.aspx")
        End If
        AccesoBD.AccesoBD.conectarBD()
    End Sub

    Protected Sub LogIn_Click(sender As Object, e As EventArgs) Handles LogIn.Click
        Dim BD As New AccesoBD.AccesoBD
        If (AccesoBD.AccesoBD.logIn(Email.Text, Pass.Text)) Then
            Response.Text = "Inicio de sesion realizado correctamente."
            Session("user") = Email.Text
            MyBase.Response.Redirect("~/Menu.aspx")
        Else
            Response.Text = "Una cuenta con ese usuario y contraseña no existe o no esta activada."
        End If
    End Sub

    Protected Sub SignUp_Click(sender As Object, e As EventArgs) Handles SignUp.Click
        MyBase.Response.Redirect("~/Registro.aspx")
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoBD.AccesoBD.cerrarBD()
    End Sub

    Protected Sub ChangeRequest_Click(sender As Object, e As EventArgs) Handles ChangeRequest.Click
        MyBase.Response.Redirect("~/Recuperacion.aspx")
    End Sub
End Class