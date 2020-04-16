' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "Password" en el código, en svc y en el archivo de configuración a la vez.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Password.svc o Password.svc.vb en el Explorador de soluciones e inicie la depuración.
Public Class Password
    Implements IPassword

    Public Sub New()

    End Sub
    Public Function esSegura(ByVal pass As String) As String Implements IPassword.esSegura
        Try
            Dim fs, f
            fs = CreateObject("Scripting.FileSystemObject")
            f = fs.OpenTextFile("C:\Users\Christian\source\repos\Practica\Practica\App_Data\toppasswords.txt", 1, -2)

            Dim line

            While Not f.AtEndOfStream
                line = f.ReadLine
                If pass = line Then
                    f.Close
                    Return "invalida"
                End If
            End While
            f.Close
            Return "valida"
        Catch ex As Exception
            Return "error"
        End Try
    End Function
End Class
