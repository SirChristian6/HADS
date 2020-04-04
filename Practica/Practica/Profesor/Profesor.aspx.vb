Public Class WebForm9
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("../default.aspx")
            ''ElseIf Session("tipo") = "Alumno" Then
            ''Response.Redirect("../Alumno/Alumno.aspx")
        End If
        Email.Text = Session("user")
    End Sub

    Protected Sub Grupos_Click(sender As Object, e As EventArgs) Handles Grupos.Click
        Response.Redirect("../default.aspx")
    End Sub

    Protected Sub Exportar_Click(sender As Object, e As EventArgs) Handles Exportar.Click
        Response.Redirect("DaBoss/Exportar.aspx")
    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        System.Web.Security.FormsAuthentication.SignOut()
        Session.Abandon()

        Application.Lock()
        Dim myPr As New ArrayList()
        Dim numPr As Integer = Application.Contents("NumProfesores")
        myPr = Application.Contents("Profesores")

        myPr.Remove(Session("user"))
        Application.Contents("Profesores") = myPr
        Application.Contents("NumProfesores") = numPr - 1
        Application.UnLock()

        Response.Redirect("../default.aspx")
    End Sub

    Protected Sub Asignaturas_Click(sender As Object, e As EventArgs) Handles Asignaturas.Click
        Response.Redirect("../default.aspx")
    End Sub

    Protected Sub Tareas_Click(sender As Object, e As EventArgs) Handles Tareas.Click
        Response.Redirect("TareasProfesor.aspx")
    End Sub

    Protected Sub XML_Click(sender As Object, e As EventArgs) Handles XML.Click
        Response.Redirect("DaBoss/ImportarXML.aspx")
    End Sub

    Protected Sub DataSet_Click(sender As Object, e As EventArgs) Handles DataSet.Click
        Response.Redirect("DaBoss/ImportarDataSet.aspx")
    End Sub

    Protected Sub Estadisticas_Click(sender As Object, e As EventArgs) Handles Estadisticas.Click
        Response.Redirect("Estadisticas.aspx")
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