using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Threads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

        public partial class MainWindow : Window
        {
            private Thread leftThread;
            private Thread rightThread;
            

            private bool leftRunning = true;
            private bool rightRunning = true;

            public MainWindow()
            {
                InitializeComponent();

            }


            private void StartThreads()
            {
                string minimum_txt = minimum.Text;
                int minimum_int = Convert.ToInt32(minimum_txt);
                string maximum_txt = maximum.Text;
                int maximum_int = Convert.ToInt32(maximum_txt);
                leftThread = new Thread(() =>
                {
                    while (leftRunning)
                    {
                        for (int i = minimum_int; i < maximum_int; i++)
                        {
                            if (IsPrime(i))
                            {
                                Dispatcher.Invoke(() => LeftNumbers.Items.Add(i));
                            }
                            
                            Thread.Sleep(10);
                        }
                    }
                });
                leftThread.Start();


                rightThread = new Thread(() =>
                {
                    long a = 0, b = 1;
                    for (int i = 0; rightRunning; i++)
                    {
                        Dispatcher.Invoke(() => RightNumbers.Items.Add(a));
                        long temp = a;
                        a = b;
                        b = temp + b;
                        Thread.Sleep(100);
                    }
                });
                rightThread.Start();
            }


            private bool IsPrime(int number)
            {
                if (number < 2) return false;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                        return false;
                }
                return true;
            }


            private void StopLeft_Click(object sender, RoutedEventArgs e)
            {
                leftRunning = false;
                leftThread.Join();
            }


            private void StopRight_Click(object sender, RoutedEventArgs e)
            {
                rightRunning = false;
                rightThread.Join();
            }

        private void Start (object sender, RoutedEventArgs e)
        {
            StartThreads();
        }
    }
    

}