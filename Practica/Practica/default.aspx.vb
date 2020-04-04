Imports System.Collections
Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("user") IsNot Nothing Then
        'MyBase.Response.Redirect("~/" & Session("tipo") & "/" & Session("tipo") & ".aspx")
        'End If
        AccesoBD.AccesoBD.ConectarBD()
    End Sub

    Protected Sub LogIn_Click(sender As Object, e As EventArgs) Handles LogIn.Click
        Dim BD As New AccesoBD.AccesoBD
        Dim passCod As String = MD5.MD5.Encode(Pass.Text)

        Dim tipo = AccesoBD.AccesoBD.LogIn(Email.Text, passCod)
        If Not (tipo = "hacker") Then
            Session("user") = Email.Text
            Session("tipo") = tipo
            If (Email.Text = "vadillo@ehu.es") Then
                System.Web.Security.FormsAuthentication.SetAuthCookie("DaBoss", False)
            Else
                System.Web.Security.FormsAuthentication.SetAuthCookie(tipo, False)
            End If

            Application.Lock()

            If tipo = "Alumno" Then
                Dim myAL As New ArrayList()
                Dim numAl As Integer = Application.Contents("NumAlumnos")
                If Application.Contents("Alumnos") IsNot Nothing Then
                    myAL = Application.Contents("Alumnos")
                End If
                myAL.Add(Email.Text)
                Application.Contents("Alumnos") = myAL
                Application.Contents("NumAlumnos") = numAl + 1
            ElseIf tipo = "Profesor" Then
                Dim myPr As New ArrayList()
                Dim numPr As Integer = Application.Contents("NumProfesores")
                If Application.Contents("Profesores") IsNot Nothing Then
                    myPr = Application.Contents("Profesores")
                End If
                myPr.Add(Email.Text)
                Application.Contents("Profesores") = myPr
                Application.Contents("NumProfesores") = numPr + 1
            End If
            Application.UnLock()
            MyBase.Response.Redirect("~/" & tipo & "/" & tipo & ".aspx")
        Else
            Response.Text = "Una cuenta con ese usuario y contraseña no existe o no esta activada."
        End If
    End Sub

    Protected Sub SignUp_Click(sender As Object, e As EventArgs) Handles SignUp.Click
        MyBase.Response.Redirect("~/Registro.aspx")
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        AccesoBD.AccesoBD.CerrarBD()
    End Sub

    Protected Sub ChangeRequest_Click(sender As Object, e As EventArgs) Handles ChangeRequest.Click
        MyBase.Response.Redirect("~/Recuperacion.aspx")
    End Sub
End Class