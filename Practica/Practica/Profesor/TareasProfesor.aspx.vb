﻿Public Class TareasProfesor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("../default.aspx")
            ''ElseIf Session("tipo") = "Alumno" Then
            ''Response.Redirect("../Alumno/Alumno.aspx")
        End If
        Email.Text = Session("user")
    End Sub

    Protected Sub NewTask_Click(sender As Object, e As EventArgs) Handles NewTask.Click
        Response.Redirect("InsertarTarea.aspx")
    End Sub

    Protected Sub Inicio_Click(sender As Object, e As EventArgs) Handles Inicio.Click
        Response.Redirect("Profesor.aspx")
    End Sub



    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        System.Web.Security.FormsAuthentication.SignOut()        Application.Lock()

        Dim myPr As New ArrayList()
        myPr = Application.Contents("Profesores")
        Dim numPr As Integer = Application.Contents("NumProfesores")
        myPr.Remove(Session("user"))
        Application.Contents("Profesores") = myPr
        Application.Contents("NumProfesores") = numPr - 1

        Application.UnLock()
        Session.Abandon()
        Response.Redirect("../default.aspx")
    End Sub

    Protected Sub asignatura_Bound(sender As Object, e As EventArgs) Handles asignatura.DataBound

    End Sub

    Protected Sub Update(sender As Object, e As EventArgs) Handles UpdatePanel1.Load
        Threading.Thread.Sleep(2000)
    End Sub

End Class