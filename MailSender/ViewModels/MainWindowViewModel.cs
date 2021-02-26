using MailSender.Infrastructure;
using MailSender.lib.ViewModels.Base;
using MailSender.Models;
using System.Collections.ObjectModel;

namespace MailSender.ViewModels
{
    internal class MainWindowViewModel:ViewModel
    {
        private string _Title = "Рассыльщик";
        public string Title{get => _Title; set => Set(ref _Title, value);}
        public string _Status = "Готов!";
        public string Status { get=> _Status; set =>Set(ref _Status,value); }
        private readonly ServersRepository _Servers;

        public ObservableCollection<Server> Servers { get; } = new ();
        public MainWindowViewModel(ServersRepository Servers)
        {
            _Servers = Servers;
        }
        private void LoadServers()
        {
            foreach (var server in _Servers.GetAll())
                Servers.Add(server);
        }
    }
}
