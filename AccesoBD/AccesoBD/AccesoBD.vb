Imports System.Data.SqlClient

Public Class AccesoBD
    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand
    Public Shared Function conectarBD() As String
        Try
            conexion.ConnectionString = "Server=tcp:hadsg-11.database.windows.net,1433;Initial Catalog=HADS-G11;Persist Security Info=False;User ID=chernandez018@ikasle.ehu.es@hadsg-11;Password=sCsW9h18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function


    Public Shared Sub cerrarBD()
        conexion.Close()
    End Sub

    Public Shared Function insertarUsuario(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal numconfir As Integer, ByVal tipo As String, ByVal pass As String) As Boolean
        Dim st = "insert into Usuarios (email,nombre,apellidos,numconfir,confirmado,tipo,pass,codpass) values ('" & email & " ','" & nombre & " ','" & apellidos & " '," & numconfir & " ,0,'" & tipo & " ','" & pass & " ',0)"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Shared Function activarCuenta(ByVal email As String, ByVal numconfir As Integer) As String
        Dim st = "select count(*) from Usuarios where email='" + email + "' and numconfir=" & numconfir & " and confirmado='False'"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteScalar()
            If numregs = 1 Then
                Dim rt = "update Usuarios set confirmado='True' where email='" + email + "'"
                comando = New SqlCommand(rt, conexion)
                Try
                    numregs = comando.ExecuteNonQuery()
                Catch ex As Exception
                    Return ex.Message
                End Try
            Else
                Return ("No intente hackearnos por favor, gracias.")
            End If
        Catch ex As Exception
            Return ex.Message

        End Try
        Return ("Cuenta validada correctamente.")
    End Function

    Public Shared Function logIn(ByVal email As String, ByVal pass As String) As Boolean

        Dim st = "select count(*) from Usuarios where email='" & email & "' and pass=" & pass & " and confirmado=1"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteScalar()
            If numregs = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Shared Function anadirSolicitudCambioPass(ByVal email As String, ByVal codpass As Integer) As Boolean

        Dim st = "update Usuarios set codpass=" & codpass & " where email='" & email & "'"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
            If numregs = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Shared Function cambiarPass(ByVal email As String, ByVal pass As String, ByVal codpass As Integer) As Boolean

        Dim st = "update Usuarios set pass='" & pass & "' where email='" & email & "' and codpass=" & codpass & ""
        'MsgBox(st)
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
            If numregs = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception

            Return False
        End Try
        Return False
    End Function
End Class
