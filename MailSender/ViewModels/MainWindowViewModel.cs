﻿using MailSender.Infrastructure;
using MailSender.lib.Commands;
using MailSender.lib.ViewModels.Base;
using MailSender.Models;
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

        public ObservableCollection<Server> Servers { get; } = new ();

        #region Команды
        private ICommand _LoadServersCommand;
        public ICommand LoadServersCommand => _LoadServersCommand ??= new LambdaCommand(OnLoadServersCommandExecuted,CanLoadServersCommandExecute);
        #endregion
        private bool CanLoadServersCommandExecute(object p) => Servers.Count==0;
        private void OnLoadServersCommandExecuted(object p)
        {
            LoadServers();
        }
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