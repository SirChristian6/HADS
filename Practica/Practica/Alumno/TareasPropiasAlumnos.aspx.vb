Public Class TareasPropiasAlumnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("../default.aspx")
            ''ElseIf Session("tipo") = "Profesor" Then
            ''Response.Redirect("../Profesor/Profesor.aspx")
        End If
    End Sub

End Class