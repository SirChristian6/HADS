Imports System.Data.SqlClient
Imports System.Xml
Imports Newtonsoft.Json

Public Class ExportarXML
    Inherits System.Web.UI.Page
    Private Shared conClsf As New SqlConnection
    Private Shared dapTrs As New SqlDataAdapter()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("../../default.aspx")
            ''ElseIf Session("tipo") = "Alumno" Then
            ''Response.Redirect("../Alumno/Alumno.aspx")
        End If
        Dim dstTrs As New DataSet
        Dim tblTrs As New DataTable
        Email.Text = Session("user")
        If Page.IsPostBack Then
            dstTrs = Session("datos")
            tblTrs = dstTrs.Tables("tareas")

            Dim dv = New DataView(tblTrs)

            dv.RowFilter = "codasig='" & Asignatura.SelectedValue & "'"

            GridView1.DataSource = dv
            GridView1.DataBind()

            dstTrs = Session("datos")
        Else
            conClsf = New SqlConnection("Server=tcp:hads.database.windows.net,1433;Initial Catalog=Amigos;Persist Security Info=False;User ID=vadillo@ehu.es@hads;Password=curso19-20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            dapTrs = New SqlDataAdapter("SELECT * FROM TareasGenericas", conClsf)
            Dim bldTrs As New SqlCommandBuilder(dapTrs)

            dapTrs.Fill(dstTrs, "tareas")
            tblTrs = dstTrs.Tables("tareas")
            Session("datos") = dstTrs

        End If
    End Sub

    Protected Sub Inicio_Click(sender As Object, e As EventArgs) Handles Inicio.Click
        Response.Redirect("../Profesor.aspx")
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

    Protected Sub EXPXML_Click(sender As Object, e As EventArgs) Handles EXPXML.Click
        Try
            Dim dstTrs As DataSet = Session("datos")
            Dim str As String = "<?xml version='1.0' ?> <tareas></tareas>"
            Dim docxml As New XmlDocument
            docxml.LoadXml(str)
            Dim xt As XmlText
            Dim tarea As XmlElement
            Dim descripcion As XmlElement
            Dim hestimadas As XmlElement
            Dim explotacion As XmlElement
            Dim tipotarea As XmlElement
            Dim at As XmlAttribute
            at = docxml.CreateAttribute("xmlns:has")
            xt = docxml.CreateTextNode("http://ji.ehu.es/has")
            at.AppendChild(xt)
            docxml.DocumentElement.Attributes.Append(at)
            For Each dr As DataRow In dstTrs.Tables("tareas").Rows

                If dr.Item("codasig") = Asignatura.SelectedValue Then
                    tarea = docxml.CreateElement("tarea")
                    at = docxml.CreateAttribute("codigo")
                    xt = docxml.CreateTextNode(dr.Item("codigo"))
                    at.AppendChild(xt)
                    tarea.Attributes.Append(at)
                    docxml.DocumentElement.AppendChild(tarea)

                    descripcion = docxml.CreateElement("descripcion")
                    xt = docxml.CreateTextNode(dr.Item("descripcion"))
                    descripcion.AppendChild(xt)
                    tarea.AppendChild(descripcion)

                    hestimadas = docxml.CreateElement("hestimadas")
                    xt = docxml.CreateTextNode(dr.Item("hestimadas"))
                    hestimadas.AppendChild(xt)
                    tarea.AppendChild(hestimadas)

                    explotacion = docxml.CreateElement("explotacion")
                    xt = docxml.CreateTextNode(dr.Item("explotacion"))
                    explotacion.AppendChild(xt)
                    tarea.AppendChild(explotacion)

                    tipotarea = docxml.CreateElement("tipotarea")
                    xt = docxml.CreateTextNode(dr.Item("tipotarea"))
                    tipotarea.AppendChild(xt)
                    tarea.AppendChild(tipotarea)
                End If

            Next
            docxml.Save(Server.MapPath("../../App_Data/" & Asignatura.SelectedValue & ".xml"))
            Respuesta.Text = "Se han añadido las tareas correctamente en " & Asignatura.SelectedValue & ".xml"

        Catch ex As Exception
            Respuesta.Text = "No se han podido añadir las tareas"
        End Try
    End Sub

    Protected Sub Profesor_Click(sender As Object, e As EventArgs) Handles Profesor.Click
        Response.Redirect("../Profesor.aspx")
    End Sub
    Protected Sub Asignatura_DataBound(sender As Object, e As EventArgs) Handles Asignatura.DataBound
        Dim tblTrs As New DataTable
        Dim dstTrs As DataSet = Session("datos")
        tblTrs = dstTrs.Tables("tareas")
        Dim dv = New DataView(tblTrs)
        dv.RowFilter = "codasig='" & Asignatura.SelectedValue & "'"
        GridView1.DataSource = dv
        GridView1.DataBind()
    End Sub
    Protected Sub Asignatura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Asignatura.SelectedIndexChanged
        Respuesta.Text = ""
    End Sub

    Protected Sub EXPJSON_Click(sender As Object, e As EventArgs) Handles EXPJSON.Click
        Try
            Dim dstTrs As DataSet = Session("datos")
            Dim tblMbrs As DataTable = dstTrs.Tables("tareas")

            Dim dv = New DataView(tblMbrs)

            dv.RowFilter = "codasig='" & Request("asignatura") & "'"
            Dim newTable As DataTable = dv.ToTable()
            Dim json As String = JsonConvert.SerializeObject(newTable, Newtonsoft.Json.Formatting.Indented)
            My.Computer.FileSystem.WriteAllText(Server.MapPath("../../App_Data/" & Asignatura.SelectedValue & ".json"), json, False)
            Respuesta.Text = "Se han añadido las tareas correctamente en " & Asignatura.SelectedValue & ".json"
        Catch ex As Exception
            Respuesta.Text = "No se han podido añadir las tareas"
        End Try
    End Sub
End Class