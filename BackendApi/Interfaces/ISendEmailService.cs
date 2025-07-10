using System.Net.Mail;

namespace BackendApi.Interfaces
{
    public interface ISendEmailService
    {
        void SendMail(string from, string to, string subject, string body, Attachment? attachments=null);
    }
}
