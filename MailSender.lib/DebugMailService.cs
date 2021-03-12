using MailSender.lib.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.lib
{
    public class DebugMailService : IMailService
    {
        public IMailSender GetSender(string Server, int Port, bool SSL, string Login, string Password)
        {
            return new DebugMailSender(Server, Port, SSL, Login, Password);
        }
    }
    internal class DebugMailSender : IMailSender
    {
        public DebugMailSender(string Server, int Port, bool SSL, string Login, string Password)
        {
            _Server = Server;
            _Port = Port;
            _SSL = SSL;
            _Login = Login;
            _Password = Password;
        }

        public readonly string _Server;
        public readonly int _Port;
        public readonly bool _SSL;
        public readonly string _Login;
        public readonly string _Password;

        public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            Debug.WriteLine("Отправка почты");
        }
        public void Send(string SenderAddress, IEnumerable<string> RecipientAddresses, string Subject, string Body)
        {
            foreach (var address in RecipientAddresses)
                Send(SenderAddress, address, Subject, Body);
        }
        public void SendParallel(string SenderAddress, IEnumerable<string> RecipientAddresses, string Subject, string Body)
        {
            foreach (var address in RecipientAddresses)
                Send(SenderAddress, address, Subject, Body);
        }

        public Task SendAsync(string SenderAddress, IEnumerable<string> RecipientAddresses, string Subject, string Body, CancellationToken Cancel = default)
        {
            Debug.WriteLine("Отправка почты асинхронно");
            return Task.CompletedTask;
        }

        public Task SendParallelAsync(string SenderAddress, IEnumerable<string> RecipientAddresses, string Subject, string Body, CancellationToken Cancel = default)
        {
            Debug.WriteLine("Отправка почты асинхронно");
            return Task.CompletedTask;
        }
    }
}
