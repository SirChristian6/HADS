Imports System.Data.SqlClient
Imports System.Xml
Public Class ImportarDataSetaspx
    Inherits System.Web.UI.Page
    Private Shared conClsf As New SqlConnection

    Private Shared dapTrs As New SqlDataAdapter()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("../../default.aspx")
            ''ElseIf Session("tipo") = "Alumno" Then
            ''Response.Redirect("../Alumno/Alumno.aspx")
        End If
        Email.Text = Session("user")
        Dim dstTrs As New DataSet
        'Dim tblTrs As New DataTable
        If Page.IsPostBack Then
            Dim dstXML As New DataSet
            Dim tblXML As New DataTable
            Try

                dstXML.ReadXml(Server.MapPath("../../App_Data/" & Asignatura.SelectedValue & ".xml"))
                tblXML = dstXML.Tables(0)
                Session("xml") = dstXML.Copy()
            Catch ex As Exception
                Session("xml") = 0
            End Try
            GridView1.DataSource = tblXML
            GridView1.DataBind()

        Else
            conClsf = New SqlConnection("Server=tcp:hads.database.windows.net,1433;Initial Catalog=Amigos;Persist Security Info=False;User ID=vadillo@ehu.es@hads;Password=curso19-20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            dapTrs = New SqlDataAdapter("SELECT * FROM TareasGenericas", conClsf)
            Dim bldTrs As New SqlCommandBuilder(dapTrs)
            dapTrs.Fill(dstTrs, "tareas")
            Session("datos") = dstTrs
        End If
    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs) Handles LogOut.Click
        System.Web.Security.FormsAuthentication.SignOut()
        Session.Abandon()
        Response.Redirect("../../default.aspx")
    End Sub

    Protected Sub Inicio_Click(sender As Object, e As EventArgs) Handles Inicio.Click
        Response.Redirect("../Profesor.aspx")
    End Sub

    Protected Sub Profesor_Click(sender As Object, e As EventArgs) Handles Profesor.Click
        Response.Redirect("../Profesor.aspx")
    End Sub

    Protected Sub Importar_Click(sender As Object, e As EventArgs) Handles Importar.Click
        Try
            Dim dstTrs = Session("datos").Copy()
            Dim tblTrs As New DataTable
            tblTrs = dstTrs.Tables("tareas")
            Dim rowTrs As DataRow

            Dim dstTrsXML = Session("xml").Copy()

            For Each dr As DataRow In dstTrsXML.Tables(0).Rows

                rowTrs = tblTrs.NewRow()
                rowTrs("codigo") = dr.Item("codigo")
                rowTrs("descripcion") = dr.Item("descripcion")
                rowTrs("codasig") = Request("Asignatura")
                rowTrs("hestimadas") = dr.Item("hestimadas")
                rowTrs("explotacion") = dr.Item("explotacion")
                rowTrs("tipotarea") = dr.Item("tipotarea")
                tblTrs.Rows.Add(rowTrs)

            Next

            dapTrs.Update(dstTrs, "tareas")
            dstTrs.AcceptChanges()
            Session("datos") = dstTrs
            Respuesta.Text = "Se han añadido las tareas correctamente"
        Catch ex As Exception
            Respuesta.Text = "No se han podido añadir las tareas"
        End Try
    End Sub

    Protected Sub Asignatura_Loaded(sender As Object, e As EventArgs) Handles Asignatura.DataBound
        Try
            Dim dstTrs As New DataSet
            Dim tblTrs As New DataTable
            dstTrs.ReadXml(Server.MapPath("../../App_Data/" & Asignatura.SelectedValue & ".xml"))
            tblTrs = dstTrs.Tables(0)
            GridView1.DataSource = tblTrs
            GridView1.DataBind()
            Session("xml") = dstTrs.Copy()
            Session("xml") = dstTrs.Copy()
            Session("tablaxml") = dstTrs.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Asignatura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Asignatura.SelectedIndexChanged
        Respuesta.Text = ""
    End Sub
End Class