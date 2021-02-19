using System;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var from = new MailAddress("mymail@yandex.ru", "Rita");
            var to = new MailAddress("mymail@gmail.com");

            var message = new MailMessage(from, to);
            message.Subject = "Заголовок";
            message.Body = "Текст письма";

            var client = new SmtpClient("smtp.yandex.ru");
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential
            {
                UserName = "UserName",
                //SecurePassword = 
                Password = "PAssword!"
            };

            client.Send(message);
        }
    }
}
