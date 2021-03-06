using System;
using System.Windows;
using System.Threading;

namespace FactorialOfNumber
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        static int Sum(int n)
        {
            int sum = 0;
            for(int i=0;i<=n;i++)
                sum += i;
            return sum;
        }
        static long Factorial(long x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
        private void Decide_Click(object sender, RoutedEventArgs e)
        {
            int number = Convert.ToInt32(number_TextBlock.Text);
            Factorial_TextBox.Text = (Factorial(number)).ToString();
            Sum_TextBox.Text = (Sum(number)).ToString();
        }
    }
}
