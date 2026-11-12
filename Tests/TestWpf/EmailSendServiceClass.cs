using System;
using System.Net.Mail;

namespace TestWpf
{
    public class EmailSendServiceClass
    {
        private SmtpClient client;
        private MailMessage message;

        public EmailSendServiceClass(SmtpClient client, MailMessage message)
        {
            this.client = client;
            this.message = message;

        }
        public void SendMail()
        {
            try
            {
                client.Send(message);

                SendEndWindow sew = new SendEndWindow();
                sew.IsSendOK.Text="Почта успешно доставлена!";
                sew.IsSendOK.Foreground = System.Windows.Media.Brushes.Green;
                sew.ShowDialog();
                
            }
            catch (SmtpException)
            {
                SendEndWindow sew = new SendEndWindow();
                sew.IsSendOK.Text = "Ошибка авторизации";
                sew.IsSendOK.Foreground = System.Windows.Media.Brushes.Red;
                sew.ShowDialog();
                
            }
            catch (TimeoutException)
            {
                SendEndWindow sew = new SendEndWindow();
                sew.IsSendOK.Text = "Ошибка адреса сервера";
                sew.IsSendOK.Foreground = System.Windows.Media.Brushes.Red;
                sew.ShowDialog();
                
            }
        }
    }
}
