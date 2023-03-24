
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Security.Application;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ShopBanHangHS.Help
{
    public static class HelpMail
    {
        public static void SendMail(string toEmail, string subject, string content)
        {
            var confi = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.js").Build();
            string username = confi.GetValue<string>("Mail:Username");
            string password = confi.GetValue<string>("Mail:Password");
            string host = confi.GetValue<string>("Mail:host");
            int port = confi.GetValue<int>("Mail:port");
            try
            {
                using(var smtpClient =new SmtpClient())
                {
                 smtpClient.EnableSsl = true;
                    smtpClient.Host=host;
                    smtpClient.Port=port;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(username, password);
                    var smg = new MailMessage()
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        Subject = subject,
                        From = new MailAddress(username),
                        Priority = MailPriority.Normal
                    };

                    smtpClient.Send(smg);

                }
                    
            }
            catch(Exception ) 
            {

                throw;
            }

        }
    }
}
