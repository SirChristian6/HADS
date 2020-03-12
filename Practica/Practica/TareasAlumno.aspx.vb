Imports System.Data.SqlClient

Public Class WebForm7
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("~/default.aspx")
        End If
        email.Text = Session("user")

        Dim conClsf As SqlConnection
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
        Session.Abandon()
        Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

        Dim row As GridViewRow = GridView1.SelectedRow
        Dim n As Integer = 1
        row.Cells(3, 0)
        Response.Redirect("~/InstanciarTarea.aspx?asig=" & Request("asignatura") & "&&row=" & GridView1.SelectedIndex)
    End Sub
End Class