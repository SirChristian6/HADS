Public Class WebForm9
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("~/default.aspx")
        ElseIf Session("tipo") = "Alumno" Then
            Response.Redirect("~/Alumno.aspx")
        End If
        Email.Text = Session("user")
    End Sub

    Protected Sub Grupos_Click(sender As Object, e As EventArgs) Handles Grupos.Click
        Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub Exportar_Click(sender As Object, e As EventArgs) Handles Exportar.Click
        Response.Redirect("~/Exportar.aspx")
    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        Session.Abandon()
        Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub Asignaturas_Click(sender As Object, e As EventArgs) Handles Asignaturas.Click
        Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub Tareas_Click(sender As Object, e As EventArgs) Handles Tareas.Click
        Response.Redirect("~/TareasProfesor.aspx")
    End Sub

    Protected Sub XML_Click(sender As Object, e As EventArgs) Handles XML.Click
        Response.Redirect("~/ImportarXML.aspx")
    End Sub

    Protected Sub DataSet_Click(sender As Object, e As EventArgs) Handles DataSet.Click
        Response.Redirect("~/ImportarDataSet.aspx")
    End Sub

    Protected Sub Estadisticas_Click(sender As Object, e As EventArgs) Handles Estadisticas.Click
        Response.Redirect("~/Estadisticas.aspx")
    End Sub
End Class