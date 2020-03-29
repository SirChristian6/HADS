Imports System.Text

Public Class MD5
    Public Shared Function Encode(ByVal pass As String) As String
        Dim hash As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim data As Byte() = hash.ComputeHash(Encoding.Default.GetBytes(pass))
        Dim sBuilder As New StringBuilder()

        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        Return sBuilder.ToString()
    End Function
End Class
