using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public interface IEmailSender
    {
        void SendEmail(string recipientEmail, string subject, string body);
    }
}
