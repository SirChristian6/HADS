Imports System.Net.Mail
Imports System.Net.NetworkCredentials
Public Class Solicitud

    Sub sendEmail(ByVal destination As String, ByVal subject As String, ByVal body As String)
        Dim msg = New MailMessage()
        msg.To.Add(New MailAddress(destination, "HADS"))
        msg.From = New MailAddress("chernandez018@ikasle.ehu.eus", "HADS")
        msg.Subject = subject
        msg.Body = "<html><head></head><body>" + body + "</body></html>"
        msg.IsBodyHtml = True
        Dim client = New SmtpClient()
        client.UseDefaultCredentials = False
        client.Credentials = New System.Net.NetworkCredential("829928", "sCsW9h18")
        client.Port = 587
        client.Host = "smtp.ehu.eus"
        client.DeliveryMethod = SmtpDeliveryMethod.Network
        client.EnableSsl = True
        client.Send(msg)
    End Sub
End Class
