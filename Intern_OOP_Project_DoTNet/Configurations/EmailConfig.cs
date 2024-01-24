using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Intern_OOP_Project_DoTNet.Configurations
{
    internal class EmailConfig
    {
        private readonly string to;
        private readonly string subject;
        private readonly string text;

        public EmailConfig(string to, string subject, string text)
        {
            this.to = to;
            this.subject = subject;
            this.text = text;
        }

        public void SendActualEmail()
        {
            // Your email credentials
            string from = "nuswarwick@gmail.com";
            string password = "xpbpjfnqjkzlqmzy";

            // SMTP server details for Gmail
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587;

            using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(from, password);
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage(from, to, subject, text);

                try
                {
                    smtpClient.Send(mailMessage);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            }
        }
    }
}
