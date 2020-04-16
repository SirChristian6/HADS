
Public Class Coordinador
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("../../default.aspx")
            ''ElseIf Session("tipo") = "Alumno" Then
            ''Response.Redirect("../Alumno/Alumno.aspx")
        End If
        Email.Text = Session("user")
    End Sub
    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        System.Web.Security.FormsAuthentication.SignOut()
        Application.Lock()

        Dim myPr As New ArrayList()
        myPr = Application.Contents("Profesores")
        Dim numPr As Integer = Application.Contents("NumProfesores")
        myPr.Remove(Session("user"))
        Application.Contents("Profesores") = myPr
        Application.Contents("NumProfesores") = numPr - 1

        Application.UnLock()
        Session.Abandon()
        Response.Redirect("../../default.aspx")
    End Sub

    Protected Sub Profesor_Click(sender As Object, e As EventArgs) Handles Profesor.Click
        Response.Redirect("../Profesor.aspx")
    End Sub

    Protected Sub DropDownList1_Loaded(sender As Object, e As EventArgs) Handles DropDownList1.DataBound
        Dim hm As New HorasMedias.HorasMediasClient
        Respuesta.Text = "El numero de horas medias para la asignatura " & DropDownList1.SelectedValue & " es de " & hm.HorasMedias(DropDownList1.SelectedValue)
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim hm As New HorasMedias.HorasMediasClient
        Respuesta.Text = "El numero de horas medias para la asignatura " & DropDownList1.SelectedValue & " es de " & hm.HorasMedias(DropDownList1.SelectedValue)
    End Sub
End Class