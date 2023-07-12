using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class EmailSenderForm
    {
        private IEmailSender _emailSender;

        public EmailSenderForm(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendEmail(string recipientEmail, string subject, string body)
        {
            _emailSender.SendEmail(recipientEmail, subject, body);
        }
    }
}
