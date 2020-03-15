Public Class Estadisticas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("~/default.aspx")
        ElseIf Session("tipo") = "Alumno" Then
            Response.Redirect("~/Alumno.aspx")
        End If
        Email.Text = Session("user")
    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        Session.Abandon()
        Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub Inicio_Click(sender As Object, e As EventArgs) Handles Inicio.Click
        Response.Redirect("~/Profesor.aspx")
    End Sub

    Protected Sub alumno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles alumno.SelectedIndexChanged

    End Sub
End Class