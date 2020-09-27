using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static string login;
        static string password;

        static void Main(string[] args)
        {
            #region CREDENTIALS
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(@"..\..\..\credentials\users.txt", Encoding.Default))
                {
                    var line = sr.ReadLine().Split(':');
                    login = line[0];
                    password = line[1];
                }
            }
            catch
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read");
            }
            #endregion

            new MailSender("diman_f@mail.ru", "ds0090@yandex.ru", login, password);
            MailSender.SendMail("Subject", "TEST MESSAGE");
        }
    }
}
