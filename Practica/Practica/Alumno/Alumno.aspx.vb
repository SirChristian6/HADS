Public Class WebForm6
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("../default.aspx")
            ''ElseIf Session("tipo") = "Profesor" Then
            ''Response.Redirect("../Profesor/Profesor.aspx")
        End If
        Email.Text = Session("user")
    End Sub

    Protected Sub Tasks_Click(sender As Object, e As EventArgs) Handles Tasks.Click
        Response.Redirect("TareasAlumno.aspx")
    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        System.Web.Security.FormsAuthentication.SignOut()
        Session.Abandon()
        Response.Redirect("../default.aspx")
    End Sub


End Class