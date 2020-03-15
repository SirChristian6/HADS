Imports System.Data.SqlClient
Public Class InsertarTarea
    Inherits System.Web.UI.Page
    Private Shared conClsf As New SqlConnection
    Private Shared dstMbrs As New DataSet
    Private Shared tblMbrs As New DataTable
    Private Shared dapMbrs As New SqlDataAdapter()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("~/default.aspx")
        ElseIf Session("tipo") = "Alumno" Then
            Response.Redirect("~/Alumno.aspx")
        End If
        Email.Text = Session("user")

        If IsPostBack Then
            dstMbrs = Session("datos")
        Else
            conClsf = New SqlConnection("Server=tcp:hads.database.windows.net,1433;Initial Catalog=Amigos;Persist Security Info=False;User ID=vadillo@ehu.es@hads;Password=curso19-20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            dapMbrs = New SqlDataAdapter("SELECT * FROM TareasGenericas", conClsf)
            Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
            dapMbrs.Fill(dstMbrs, "tareas")
            Session("datos") = dstMbrs
        End If

    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        Session.Abandon()
        Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub AddTask_Click(sender As Object, e As EventArgs) Handles AddTask.Click
        Dim dstMbrs2 = dstMbrs.Copy()
        Try
            tblMbrs = dstMbrs.Tables("tareas")
            Dim rowMbrs As DataRow = tblMbrs.NewRow()
            rowMbrs("codigo") = Code.Text
            rowMbrs("descripcion") = Description.Text
            rowMbrs("codasig") = Asignatura.Text
            rowMbrs("hestimadas") = Hest.Text
            rowMbrs("explotacion") = "True"
            rowMbrs("tipotarea") = Ttarea.Text
            tblMbrs.Rows.Add(rowMbrs)
            dapMbrs.Update(dstMbrs, "tareas")
            dstMbrs.AcceptChanges()
            Session("datos") = dstMbrs
            Respuesta.Text = "Se ha añadido la tarea correctamente"
        Catch ex As Exception

            dstMbrs = dstMbrs2.Copy()
            Respuesta.Text = "No se ha podido añadir la tarea"
        End Try

    End Sub

    Protected Sub ShowTasks_Click(sender As Object, e As EventArgs) Handles ShowTasks.Click
        Response.Redirect("~/TareasProfesor.aspx")
    End Sub

    Protected Sub Inicio_Click(sender As Object, e As EventArgs) Handles Inicio.Click
        Response.Redirect("~/Profesor.aspx")
    End Sub

    Protected Sub Tareas_Click(sender As Object, e As EventArgs) Handles Tareas.Click
        Response.Redirect("~/TareasProfesor.aspx")
    End Sub
End Class