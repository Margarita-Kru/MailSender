using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var from = new MailAddress(SenderEdit.Text);
            var to = new MailAddress(AddresseeEdit.Text);

            var message = new MailMessage(from, to);
            message.Subject = ItemEdit.Text;
            message.Body = MailEdit.Text;

            var client = new SmtpClient(AddressComboBox.Text, Convert.ToInt32(PortEdit.Text));
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential
            {
                UserName = TextEdit.Text,
                SecurePassword =PasswordEdit.SecurePassword
            };

            EmailSendServiceClass E = new EmailSendServiceClass(client, message);
            E.SendMail();
        }
    }
}
