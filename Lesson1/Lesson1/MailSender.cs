using System;
using System.Net.Mail;

namespace Lesson1
{
    class MailSender
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Sender { get; private set; }
        public string Recipient { get; private set; }
        public MailMessage MM { get; set; }

        public MailSender(string sender, string recipient, string login, string password)
        {
            Login = login;
            Password = password;
            Sender = sender;
            Recipient = recipient;
        }

        public static void SendMail(string subject, string message)
        {
            MM = new MailMessage(Sender, Recipient);
            MM.Subject = subject;
            MM.Body = message;
            MM.IsBodyHtml = false;

            using SmtpClient sc = new SmtpClient("smtp.yandex.ru", 587);
            sc.EnableSsl = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.UseDefaultCredentials = false;
            sc.Credentials = new System.Net.NetworkCredential(Login, Password);

            try
            {
                Console.WriteLine($"Sending mail..." + Environment.NewLine);
                sc.Send(MM);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot send e-mail! Error: {ex.Message}");
                Console.ReadLine();
            }
        }
    }
}
