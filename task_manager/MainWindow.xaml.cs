using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Threading;

namespace task_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer = null;
        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 20);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            Refresh(sender, null);
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = Process.GetProcesses();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).Content.ToString() == "stop")
            {
                _timer.Interval = new TimeSpan(24, 0, 0);
            }
            else
            {
                string choice = (sender as RadioButton).Content.ToString();
                int choice_int = Convert.ToInt32(choice);
                _timer.Interval = new TimeSpan(0, 0, choice_int);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (grid.SelectedItem as Process).Kill();
        }

        private void Start_procces(object sender, RoutedEventArgs e)
        {

            try
            {
                Process.Start(Text_user.Text);
            }
            catch (Exception ex)

            {
                MessageBox.Show($"{ex.Message}");
            }

        }
        private void Button_Click_detail(object sender, RoutedEventArgs e)
        {
            try
            {
                Process current = (grid.SelectedItem as Process);
                MessageBox.Show($"----------- Current proccess info ------------\n" +
                    $"Priority class: {current.PriorityClass}" +
                    $"\nName:  {current.ProcessName}" +
                    $"\nId: {current.Id}\n" +
                    $"MachineName: {current.MachineName}\n" +
                    $"PrivateMemorySize (KB): {current.PrivateMemorySize64 / 1024}\n" +
                    $"StartTime: {current.StartTime}" +
                    $"\nTotalProcessorTime: {current.TotalProcessorTime}\n" +
                    $"UserProcessorTime: {current.UserProcessorTime}\n");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message );
            }

        }
    }
}