using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class MailSender
    {
        static string login;
        static string password;
        
            

            MailMessage mm = new MailMessage("ds0090@yandex.ru", "dmitriy.fateyev86@gmail.com");
            mm.Subject = "Заголовок письма";
            mm.Body = "Содержимое письма";
            mm.IsBodyHtml = false;

            SmtpClient sc = new SmtpClient("smtp.yandex.ru", 567);
            sc.EnableSsl = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.UseDefaultCredentials = false;
            sc.Credentials = new NetworkCredential(login, password);
            try
            {
                sc.Send(mm);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot send e-mail! Error: {ex.Message}");
                Console.ReadLine();
            }
        }
    

