using ArchExample.Common.Interfaces.Helpers;

namespace ArchExample.Mail
{
    public class MailHelper : IMailHelper
    {
        public void SendMail(string email, string subject, string body)
        {
            // Here comes example code to send email. For example, it could use twilio
        }
    }
}