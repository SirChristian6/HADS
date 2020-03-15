Imports System.Data.SqlClient

Public Class WebForm8
    Inherits System.Web.UI.Page
    Private Shared conClsf As New SqlConnection
    Private Shared dstTrs As New DataSet
    Private Shared tblTrs As New DataTable
    Private Shared dapTrs As New SqlDataAdapter()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("~/default.aspx")
        ElseIf Session("tipo") = "Profesor" Then
            Response.Redirect("~/Profesor.aspx")
        End If

        If Not (Request("tarea") Is Nothing And Request("hest") Is Nothing) Then
            User.Text = Session("user")
            tarea.Text = Request("tarea")
            hest.Text = Request("hest")
            If IsPostBack Then
                dstTrs = Session("datos")
                tblTrs = dstTrs.Tables("tareas")
                GridView1.DataSource = tblTrs
                GridView1.DataBind()
            Else
                conClsf = New SqlConnection("Server=tcp:hads.database.windows.net,1433;Initial Catalog=Amigos;Persist Security Info=False;User ID=vadillo@ehu.es@hads;Password=curso19-20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                dapTrs = New SqlDataAdapter("SELECT * FROM EstudiantesTareas WHERE email='" & Session("user") & "'", conClsf)
                dstTrs = New DataSet()

                Dim bldMbrs As New SqlCommandBuilder(dapTrs)
                'dstMbrs
                dapTrs.Fill(dstTrs, "tareas")
                tblTrs = dstTrs.Tables("tareas")
                GridView1.DataSource = tblTrs
                GridView1.DataBind()
                Session("datos") = dstTrs
                Session("adaptador") = dapTrs
            End If


        Else
            Response.Redirect("~/TareasAlumno.aspx")
        End If

    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        Session.Abandon()
        Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        conClsf.Close()
    End Sub

    Protected Sub Task_Click(sender As Object, e As EventArgs) Handles Task.Click
        'Dim dstTrs2 = dstTrs.Copy()
        Try
            tblTrs = dstTrs.Tables("tareas")
            Dim rowMbrs As DataRow = tblTrs.NewRow()
            rowMbrs("email") = User.Text
            rowMbrs("codtarea") = tarea.Text
            rowMbrs("hestimadas") = hest.Text
            rowMbrs("hreales") = Hreales.Text
            tblTrs.Rows.Add(rowMbrs)

            dapTrs.Update(dstTrs, "tareas")
            dstTrs.AcceptChanges()
            GridView1.DataSource = tblTrs
            GridView1.DataBind()
            Respuesta.Text = "Se ha añadido la tarea: " & tarea.Text
            Session("datos") = dstTrs

        Catch ex As Exception
            dapTrs = Session("adaptador")
            dapTrs.Fill(dstTrs, "tareas")
            Respuesta.Text = "No se ha podido añadir la tarea"
        End Try

    End Sub

    Protected Sub Inicio_Click(sender As Object, e As EventArgs) Handles Inicio.Click
        Response.Redirect("~/Alumno.aspx")
    End Sub

    Protected Sub Tareas_Click(sender As Object, e As EventArgs) Handles Tareas.Click
        Response.Redirect("~/TareasAlumno.aspx")
    End Sub
End Class