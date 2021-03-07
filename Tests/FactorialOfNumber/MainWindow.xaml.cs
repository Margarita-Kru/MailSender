using System;
using System.Windows;
using System.Threading;

namespace FactorialOfNumber
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        private void Sum(int n)
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
                sum += i;
            Sum_TextBox.Dispatcher.Invoke(() => Sum_TextBox.Text = sum.ToString());

        }
        static long Factorial(long x)
        {
            if (x == 0)
                return 1;
            else
                return x * Factorial(x - 1);
        }
        private void Decide_Click(object sender, RoutedEventArgs e)
        {
            int number = Convert.ToInt32(number_TextBox.Text);
            var sum_thread = new Thread(() => Sum(number));
            sum_thread.Start();

            var factorial_return_thread = new Thread(() => FactorialReturn(number));
            factorial_return_thread.Start();
        }
        private void FactorialReturn(int number) => Factorial_TextBox.Dispatcher.Invoke(() => Factorial_TextBox.Text = Factorial(number).ToString());
    }
}
