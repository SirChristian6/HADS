Imports System.Data.SqlClient

Public Class WebForm7
    Inherits System.Web.UI.Page
    Private Shared conClsf As New SqlConnection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("../default.aspx")
            ''ElseIf Session("tipo") = "Profesor" Then
            ''Response.Redirect("../Profesor/Profesor.aspx")
        End If
        email.Text = Session("user")


        conClsf = New SqlConnection("Server=tcp:hads.database.windows.net,1433;Initial Catalog=Amigos;Persist Security Info=False;User ID=vadillo@ehu.es@hads;Password=curso19-20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        Dim dapMbrs As New SqlDataAdapter()
        Dim dstMbrs As New DataSet
        Dim tblMbrs As New DataTable
        Dim dv As DataView


        'Dim rowMbrs As DataRow

        If Page.IsPostBack Then

            dstMbrs = Session("datos")
            tblMbrs = dstMbrs.Tables("tareas")

            dv = New DataView(tblMbrs)

            dv.RowFilter = "codasig='" & Request("asignatura") & "'"

            GridView1.DataSource = dv
            GridView1.DataBind()

            dstMbrs = Session("datos")
        Else

            dapMbrs = New SqlDataAdapter("select TareasGenericas.codigo, TareasGenericas.descripcion, TareasGenericas.hestimadas, TareasGenericas.tipotarea, TareasGenericas.codasig 
            From TareasGenericas LEFT Join ( SELECT* FROM EstudiantesTareas WHERE EstudiantesTareas.email='" & Session("user") & "')AS T1 On TareasGenericas.codigo=T1.codtarea Where email is NULL And TareasGenericas.explotacion ='True'", conClsf)

            Dim bldMbrs As New SqlCommandBuilder(dapMbrs)
            dapMbrs.Fill(dstMbrs, "tareas")

            Session("datos") = dstMbrs
        End If
    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        System.Web.Security.FormsAuthentication.SignOut()

        Session.Abandon()
        Response.Redirect("../default.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.Rows(GridView1.SelectedIndex)

        Response.Redirect("InstanciarTarea.aspx?tarea=" & row.Cells(1).Text & "&hest=" & row.Cells(3).Text)
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        conClsf.Close()
    End Sub

    Protected Sub Inicio_Click(sender As Object, e As EventArgs) Handles Inicio.Click
        Response.Redirect("Alumno.aspx")
    End Sub
End Class