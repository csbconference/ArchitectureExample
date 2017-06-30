namespace ArchExample.Common.Interfaces.Helpers
{
    public interface IMailHelper
    {
        void SendMail(string email, string subject, string body);
    }
}
