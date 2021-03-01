using MailSender.Infrastructure;
using MailSender.lib.Commands;
using MailSender.lib.Interfaces;
using MailSender.lib.ViewModels.Base;
using MailSender.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MailSender.ViewModels
{
    internal class MainWindowViewModel:ViewModel
    {
        private string _Title = "Рассыльщик";
        public string Title{get => _Title; set => Set(ref _Title, value);}
        public string _Status = "Готов!";
        public string Status { get=> _Status; set =>Set(ref _Status,value); }
        private readonly ServersRepository _Servers;
        private readonly IMailService _MailService;

        public ObservableCollection<Server> Servers { get; } = new ();
        public ObservableCollection<Recipient> Recipients { get; } = new ();
        public ObservableCollection<Sender> Senders { get; } = new ();
        public ObservableCollection<Message> Messages { get; } = new ();

        private Server _SelectedServer;
        public Server SelectedServer 
        { 
            get => _SelectedServer; 
            set => Set(ref _SelectedServer, value); 
        }
        private Sender _SelectedSender; 
        public Sender SelectedSender 
        { 
            get => _SelectedSender; 
            set => Set(ref _SelectedSender, value); 
        }
        #region Команды
        private ICommand _LoadServersCommand;
        public ICommand LoadServersCommand => _LoadServersCommand ??= new LambdaCommand(OnLoadServersCommandExecuted,CanLoadServersCommandExecute);
        
        private bool CanLoadServersCommandExecute(object p) => Servers.Count==0;
        private void OnLoadServersCommandExecuted(object p) => LoadServers();

        private ICommand _SendEmailCommand;
        public ICommand SendEmailCommand => _SendEmailCommand ??= new LambdaCommand(OnSendEmailCommandExecuted, CanSendEmailCommandExecute);

        private bool CanSendEmailCommandExecute(object p) => Servers.Count == 0;
        private void OnSendEmailCommandExecuted(object p)
        {
            _MailService.SendEmail("Иванов", "Петров", "Тема", "Тело письма");
        }
        #endregion
        public MainWindowViewModel(ServersRepository Servers, IMailService MailService)
        {
            _Servers = Servers;
            _MailService = MailService;
        }
        private void LoadServers()
        {
            foreach (var server in _Servers.GetAll())
                Servers.Add(server);
        }
    }
}
