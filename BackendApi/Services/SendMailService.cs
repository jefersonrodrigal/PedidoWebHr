using BackendApi.Interfaces;
using BackendApi.Settings;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BackendApi.Services
{
    public class SendMailService : ISendEmailService
    {
        private readonly ILogger<SendMailService> _logger;
        private readonly SmtpSettings _smtpSettings;


        public SendMailService(IOptions<SmtpSettings> smtpOptions, ILogger<SendMailService> logger)
        {
            _logger = logger;
            _smtpSettings = smtpOptions.Value;
        }

        public void SendMail(string from, string to, string subject, string body, Attachment? attachments = null)
        {
            try
            {
                if(from == "")
                {
                    from = _smtpSettings.DefaultAddress;
                }

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                // Attachment
                // Attachment attachments = new Attachment(Path.Combine("", ""));
                // mail.Attachments.Add(attachments);

                SmtpClient smtp = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port);
                smtp.Credentials = new NetworkCredential(_smtpSettings.User, _smtpSettings.Password);
                smtp.EnableSsl = _smtpSettings.Ssl;

                smtp.Send(mail);

                _logger.LogInformation($"Email enviado para {to}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao enviar e-mail para {Destinatario}", to);
            }
        }
    }
}
