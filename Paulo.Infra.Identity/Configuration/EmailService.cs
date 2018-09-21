using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Paulo.Infra.Identity.Configuration
{
    public class EmailService : IIdentityMessageService
    {
        public string SmtpHost { get; private set; }
        public int SmtpPort { get; private set; }
        public string MailAddress { get; private set; }
        public string MailDisplayName { get; private set; }

        public EmailService()
        {
            SmtpHost = ConfigurationManager.AppSettings["SmtpHost"];
            SmtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            MailAddress = ConfigurationManager.AppSettings["MailAddress"];
            MailDisplayName = ConfigurationManager.AppSettings["MailDisplayName"];
        }

        public Task SendAsync(IdentityMessage message)
        {
            var smtpClient = new SmtpClient(SmtpHost, SmtpPort) {
                EnableSsl = true,
            };

            smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["LoginDoEmail"],
                ConfigurationManager.AppSettings["SenhaDoEmail"]);

            var msg = new MailMessage
            {
                From = new MailAddress(MailAddress, MailDisplayName)
            };

            msg.To.Add(message.Destination);
            msg.Subject = message.Subject;
            msg.Body = message.Body;
            msg.IsBodyHtml = true;

            return smtpClient.SendMailAsync(msg);
        }
    }
}
