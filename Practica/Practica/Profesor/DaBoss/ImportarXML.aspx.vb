Imports System.Data.SqlClient
Imports System.Xml

Public Class ImportarXML
    Inherits System.Web.UI.Page
    Private Shared conClsf As New SqlConnection
    Private Shared dstTrs As New DataSet
    Private Shared tblTrs As New DataTable
    Private Shared dapTrs As New SqlDataAdapter()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("../../default.aspx")
            ''ElseIf Session("tipo") = "Alumno" Then
            ''Response.Redirect("../Alumno/Alumno.aspx")
        End If
        Email.Text = Session("user")

        If Page.IsPostBack Then
            dstTrs = Session("datos")
            Try
                If My.Computer.FileSystem.FileExists(Server.MapPath("../../App_Data/" & Asignatura.SelectedValue & ".xml")) Then
                    Xml1.DocumentSource = Server.MapPath("../../App_Data/" & Asignatura.SelectedValue & ".xml")
                    Xml1.TransformSource = Server.MapPath("../../App_Data/" & Session("xslt"))
                End If
                Respuesta.Text = ""
            Catch ex As Exception
                Respuesta.Text = "No existe el archivo al que se desea acceder"
            End Try
        Else
            conClsf = New SqlConnection("Server=tcp:hads.database.windows.net,1433;Initial Catalog=Amigos;Persist Security Info=False;User ID=vadillo@ehu.es@hads;Password=curso19-20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            dapTrs = New SqlDataAdapter("SELECT * FROM TareasGenericas", conClsf)
            Dim bldTrs As New SqlCommandBuilder(dapTrs)
            dapTrs.Fill(dstTrs, "tareas")
            Session("datos") = dstTrs
            Session("xslt") = "XSLTFile.xsl"
        End If

    End Sub
    Protected Sub Asignatura_Loaded(sender As Object, e As EventArgs) Handles Asignatura.DataBound
        Try
            If My.Computer.FileSystem.FileExists(Server.MapPath("../../App_Data/" & Asignatura.SelectedValue & ".xml")) Then
                Xml1.DocumentSource = Server.MapPath("../../App_Data/" & Asignatura.SelectedValue & ".xml")
                Xml1.TransformSource = Server.MapPath("../../App_Data/" & Session("xslt"))
            End If
        Catch ex As Exception
            Respuesta.Text = "No existe el archivo al que se desea acceder"
        End Try
    End Sub



    Protected Sub Importar_Click(sender As Object, e As EventArgs) Handles Importar.Click
        Dim dstTrs2 = dstTrs.Copy()
        Try
            Dim docxml As New XmlDocument
            docxml.Load(Server.MapPath("../../App_Data/" & Asignatura.SelectedValue & ".xml"))
            Dim doc As XmlNode = docxml.DocumentElement

            Dim tarea As XmlNodeList
            Dim descripcion As XmlNodeList
            Dim hestimadas As XmlNodeList
            Dim explotacion As XmlNodeList
            Dim tipotarea As XmlNodeList

            tarea = docxml.GetElementsByTagName("tarea")
            descripcion = docxml.GetElementsByTagName("descripcion")
            hestimadas = docxml.GetElementsByTagName("hestimadas")
            explotacion = docxml.GetElementsByTagName("explotacion")
            tipotarea = docxml.GetElementsByTagName("tipotarea")
            tblTrs = dstTrs.Tables("tareas")
            Dim rowTrs As DataRow
            Dim i As Integer
            For i = 0 To tarea.Count - 1
                rowTrs = tblTrs.NewRow()
                rowTrs("codigo") = tarea(i).Attributes("codigo").Value
                rowTrs("descripcion") = descripcion(i).ChildNodes(0).Value
                rowTrs("codasig") = Asignatura.SelectedValue
                rowTrs("hestimadas") = hestimadas(i).ChildNodes(0).Value
                rowTrs("explotacion") = explotacion(i).ChildNodes(0).Value
                rowTrs("tipotarea") = tipotarea(i).ChildNodes(0).Value
                tblTrs.Rows.Add(rowTrs)
            Next
            dapTrs.Update(dstTrs, "tareas")
            dstTrs.AcceptChanges()
            Session("datos") = dstTrs
            Respuesta.Text = "Se han añadido las tareas correctamente"

        Catch ex As Exception
            dstTrs = dstTrs2.Copy()
            Respuesta.Text = "No se han podido añadir las tareas"
        End Try

    End Sub

    Protected Sub Inicio_Click(sender As Object, e As EventArgs) Handles Inicio.Click
        Response.Redirect("../Profesor.aspx")
    End Sub

    Protected Sub Profesor_Click(sender As Object, e As EventArgs) Handles Profesor.Click
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

    Protected Sub codigo_Click(sender As Object, e As EventArgs) Handles codigo.Click
        Session("xslt") = "XSLTFileCodigo.xsl"

        Xml1.TransformSource = Server.MapPath("../../App_Data/" & Session("xslt"))
    End Sub

    Protected Sub descripcion_Click(sender As Object, e As EventArgs) Handles descripcion.Click
        Session("xslt") = "XSLTFileDescripcion.xsl"

        Xml1.TransformSource = Server.MapPath("../../App_Data/" & Session("xslt"))
    End Sub

    Protected Sub hestimadas_Click(sender As Object, e As EventArgs) Handles hestimadas.Click
        Session("xslt") = "XSLTFileHEstimadas.xsl"

        Xml1.TransformSource = Server.MapPath("../../App_Data/" & Session("xslt"))
    End Sub
End Class