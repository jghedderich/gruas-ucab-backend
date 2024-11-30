using System.Net;
using System.Net.Mail;

namespace BuildingBlocks.Emails
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string body)
        {
            var user = "MS_10ZBJP@trial-3vz9dlez807lkj50.mlsender.net";
            var password = "Ry2eCMdorsu6frS2";

            var client = new SmtpClient("smtp.mailersend.net", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(user, password)
            };

            return client.SendMailAsync(
                new MailMessage(from: user, to: email, subject, body));
        }
    }
}
