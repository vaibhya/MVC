using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace GmailSMTPConsoleApp.Model
{
    class GmailSmtp
    {
        public void SendEmail(string emailaddress,string subject,string body)
        {
            using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], emailaddress))
            {
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                //smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;

                NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                Console.WriteLine("Sending Email......");
                smtp.Send(mm);
                Console.WriteLine("Email Sent.");
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
    }
}
