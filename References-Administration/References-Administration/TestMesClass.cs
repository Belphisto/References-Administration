using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace References_Administration
{
    public interface IEmailSender
    {
        void SendEmail(string senderEmail, string senderPassword, string recipientEmail, string subject, string body);
    }

    public class EmailSender : IEmailSender
    {
        public void SendEmail(string senderEmail, string senderPassword, string recipientEmail, string subject, string body)
        {
            try
            {
                SmtpClient smtpClient = CreateSmtpClient(senderEmail, senderPassword);

                MailMessage mailMessage = CreateMailMessage(senderEmail, recipientEmail, subject, body);

                smtpClient.Send(mailMessage);

                mailMessage.Dispose();
                smtpClient.Dispose();

                Console.WriteLine("Письмо успешно отправлено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка отправки письма: " + ex.Message);
            }
        }

        private SmtpClient CreateSmtpClient(string senderEmail, string senderPassword)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            return smtpClient;
        }

        private MailMessage CreateMailMessage(string senderEmail, string recipientEmail, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail);
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            return mailMessage;
        }
    }

    public class EmailSenderForm
    {
        private IEmailSender _emailSender;

        public EmailSenderForm(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendEmail(string senderEmail, string senderPassword, string recipientEmail, string subject, string body)
        {
            _emailSender.SendEmail(senderEmail, senderPassword, recipientEmail, subject, body);
        }
    }

}
