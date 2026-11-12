using System.Windows;

namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tab.SelectedItem = tabItem;
        }
    }
}
