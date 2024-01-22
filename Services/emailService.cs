using System;
using System.Net;
using System.Net.Mail;
namespace WebApplication2.Services;

public class EmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        try
        {
            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("gppproyect@gmail.com", "cxod chlo ojhh tjjw");//
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("gppproyect@gmail.com");
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                smtpClient.Send(mailMessage);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al enviar el correo: {ex.Message}");
        }
    }
}
