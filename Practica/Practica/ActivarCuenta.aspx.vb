Imports AccesoBD
Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = AccesoBD.AccesoBD.conectarBD()
        Dim email = Request("email")
        Dim conf = Request("cnf")
        Response.Text = AccesoBD.AccesoBD.activarCuenta(email, conf)
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoBD.AccesoBD.cerrarBD()
    End Sub

    Protected Sub LogIn_Click(sender As Object, e As EventArgs) Handles LogIn.Click
        MyBase.Response.Redirect("~/default.aspx")
    End Sub
End Class