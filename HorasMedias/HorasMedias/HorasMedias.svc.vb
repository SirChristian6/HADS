﻿' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.vb en el Explorador de soluciones e inicie la depuración.
Imports System.Data.SqlClient
Public Class Service1
    Implements IHorasMedias

    Public Sub New()
    End Sub


    Public Function HorasMedias(asignatura As String) As Double Implements IHorasMedias.HorasMedias
        Try
            Dim conClsf = New SqlConnection("Server=tcp:hads.database.windows.net,1433;Initial Catalog=Amigos;Persist Security Info=False;User ID=vadillo@ehu.es@hads;Password=curso19-20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")

            Dim dstTrs As New DataSet
            Dim tblTrs As New DataTable
            Dim dapTrs = New SqlDataAdapter("select (CAST(sum(EstudiantesTareas.hreales) AS DECIMAL(5,1))/Count(Distinct EstudiantesTareas.email)) patata from TareasGenericas Inner Join EstudiantesTareas on TareasGenericas.Codigo=EstudiantesTareas.CodTarea Where TareasGenericas.CodAsig='" & asignatura & "'", conClsf)

            Dim bldMbrs As New SqlCommandBuilder(dapTrs)

            dapTrs.Fill(dstTrs, "horas")
            If Not dstTrs.Tables(0).Rows(0).Item(0) Is Nothing Then
                Return dstTrs.Tables(0).Rows(0).Item(0)
            End If
            Return 0
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
