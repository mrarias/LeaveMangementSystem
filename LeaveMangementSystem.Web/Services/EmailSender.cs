
using System.Net;
using System.Net.Mail;

namespace LeaveMangementSystem.Web.Services
{
    public class EmailSender(IConfiguration _configuration) : IEmailSender
    {

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // EmailSettings - is the section and DefaultEmailAddress - is the key [section:key]
            var fromAddress = _configuration["EmailSettings:DefaultEmailAddress"];
            var smtpServer = _configuration["EmailSettings:Host"];
            var smtpPort = Convert.ToInt32(_configuration["EmailSettings:Port"]);
            var smtpPassword = _configuration["EmailSettings:Password"];
            var message = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
            };

            //using (MailMessage message = new (fromAddress, email))
            //{
            //    //message.From = new MailAddress(fromAddress);
            //    message.Subject = subject;
            //    message.Body = htmlMessage;
            //    message.IsBodyHtml = true;
            //    SmtpClient client = new SmtpClient();
            //    client.Host = smtpServer;
            //    client.EnableSsl = true;
            //    client.UseDefaultCredentials = false;
            //    client.Port = smtpPort;
            //    client.Credentials = new NetworkCredential("agentsupport@benlife.com.ph", smtpPassword);
            //    //client.Send(message);
            //};

            message.To.Add(new MailAddress(email));            
            using var client = new SmtpClient(smtpServer, smtpPort);
            client.Credentials = new NetworkCredential(fromAddress, smtpPassword);
            //client.Credentials = new NetworkCredential("servicemail@benlife.com.ph", "S37v!ceM@il"); 
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            //client.Host = smtpServer;
            //client.Port = smtpPort;

            //client.Credentials = new NetworkCredential("agentsupport@benlife.com.ph", smtpPassword);
            //using var client = new SmtpClient
            //{
            //    Port = smtpPort,
            //    Host = smtpServer,
            //    //EnableSsl = true,
            //    //DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential("agentsupport@benlife.com.ph", smtpPassword)
            //};
            await client.SendMailAsync(message);
            //client.Dispose();
        }
    }
}
