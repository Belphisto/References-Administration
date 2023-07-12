using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace References_Administration
{
    public class EmailSender : IEmailSender
    {
        private string senderPassword;
        private string senderEmail;
        
        public EmailSender(string email, string pass)
        {
            senderEmail = email;
            senderPassword = pass;
        }
        public void SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                SmtpClient smtpClient = CreateSmtpClient();

                MailMessage mailMessage = CreateMailMessage(recipientEmail, subject, body);

                smtpClient.Send(mailMessage);

                mailMessage.Dispose();
                smtpClient.Dispose();

                Log.WriteLog("Письмо успешно отправлено.");
            }
            catch (Exception ex)
            {
                Log.WriteLog($"Ошибка отправки письма по адресу {senderEmail}: " + ex.Message);
            }
        }

        private SmtpClient CreateSmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            return smtpClient;
        }

        private MailMessage CreateMailMessage(string recipientEmail, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail);
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            return mailMessage;
        }
    }
}
