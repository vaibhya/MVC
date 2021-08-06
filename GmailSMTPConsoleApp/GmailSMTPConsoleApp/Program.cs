using GmailSMTPConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailSMTPConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter email of receiver: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter subject:");
            string subject = Console.ReadLine();
            Console.WriteLine("Enter Body:");
            String body = Console.ReadLine();
            GmailSmtp smtp = new GmailSmtp();
            smtp.SendEmail(email, subject, body);
        }
    }
}
