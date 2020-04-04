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

        Application.Lock()

        Dim myAL As New ArrayList()
        myAL = Application.Contents("Alumnos")
        Dim numAl As Integer = Application.Contents("NumAlumnos")
        myAL.Remove(Session("user"))
        Application.Contents("Alumnos") = myAL
        Application.Contents("NumAlumnos") = numAl - 1

        Application.UnLock()

        Session.Abandon()

        Response.Redirect("../default.aspx")
    End Sub

    Protected Sub Update(sender As Object, e As EventArgs) Handles UpdatePanel1.Load
        Threading.Thread.Sleep(2000)
        Application.Lock()
        Dim myPr As New ArrayList()
        myPr = Application.Contents("Profesores")
        Dim myAl As New ArrayList()
        myAl = Application.Contents("Alumnos")
        Dim numAl As Integer = Application.Contents("NumAlumnos")
        Dim numPr As Integer = Application.Contents("NumProfesores")
        Count.Text = "Nº Alumnos conectados= " & numAl & " / Nº Profesores conectados= " & numPr
        Profesores.Items.Clear()
        For i As Integer = 0 To numPr - 1

            Profesores.Items.Add(myPr.Item(i))
        Next

        Alumnos.Items.Clear()
        For i As Integer = 0 To numAl - 1

            Alumnos.Items.Add(myAl.Item(i))
        Next
        Application.UnLock()
    End Sub
End Class