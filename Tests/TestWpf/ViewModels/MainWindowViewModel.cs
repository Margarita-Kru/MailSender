using MailSender.lib.ViewModels.Base;

namespace TestWpf.ViewModels
{
    class MainWindowViewModel:ViewModel
    {
        private string _Title = "Test111";
        public string Title { get=> _Title;
            //set
            //{
            //    if (Equals(_Title, value)) return;
            //    _Title = value;
            //    OnPropertyChanged();
            //}
            set => Set(ref _Title,value);
        }
    }
}
