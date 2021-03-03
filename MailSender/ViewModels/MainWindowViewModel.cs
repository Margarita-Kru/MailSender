using MailSender.Infrastructure.Services;
using MailSender.Infrastructure.Services.InMemory;
using MailSender.lib.Commands;
using MailSender.lib.Interfaces;
using MailSender.lib.ViewModels.Base;
using MailSender.Models;
using MailSender.Models.Base;
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

        private readonly IRepository<Server> _Servers;
        private readonly IRepository<Sender> _Senders;
        private readonly IRepository<Recipient> _Recipients;
        private readonly IRepository<Message> _Messages;

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
        public MainWindowViewModel(
            IRepository<Server> Servers, 
            IRepository<Sender> Senders, 
            IRepository<Recipient> Recipients, 
            IRepository<Message> Messages, 
            IMailService MailService)
        {
            _Servers = Servers;
            _Senders = Senders;
            _Recipients = Recipients;
            _Messages = Messages;
            _MailService = MailService;
        }
        private static void Load<T>(ObservableCollection<T> collection, IRepository<T> rep)where T : Entity
        {
            collection.Clear();
            foreach (var item in rep.GetAll())
                collection.Add(item);
        }
        private void LoadServers()
        {
            Load(Servers, _Servers);
            Load(Senders, _Senders);
            Load(Recipients, _Recipients);
            Load(Messages, _Messages);
        }
    }
}
