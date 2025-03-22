using MailKit.Net.Smtp;
using MimeKit;

namespace Api.Services
{
    public class EmailService
    {
        private static readonly string from = "no-reply.cellsius@abv.bg";
        private static readonly string pwd = "cellsius.shop";

        private static MimeMessage ConfigureEmail(MimeMessage mimeMessage, string to, string subject, string body)
        {
            mimeMessage.From.Add(MailboxAddress.Parse(from));
            mimeMessage.To.Add(MailboxAddress.Parse(to));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("html") { Text = body };

            return mimeMessage;
        }

        private static async Task<SmtpClient> SetupSmtpClient()
        {
            var smtp = new SmtpClient();

            await smtp.ConnectAsync("smtp.abv.bg", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
            await smtp.AuthenticateAsync(from, pwd);

            return smtp;
        }

        public static async Task SendEmailAsync(string to, string subject, string body)
        {
            var email = ConfigureEmail(new MimeMessage(), to, subject, body);
            var smtp = await SetupSmtpClient();

            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        } 
    }
}
