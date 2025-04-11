using System;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncFactorialApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputTextBox.Text, out int number) && number >= 0)
            {
                BigInteger factorial = await CalculateFactorialAsync(number);
                ResultsListBox.Items.Add($"Factorial of {number} = {factorial}");
            }
            else
            {
                MessageBox.Show("Please enter a valid non-negative integer.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async Task<BigInteger> CalculateFactorialAsync(int number)
        {
            await Task.Delay(100);
            BigInteger result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}