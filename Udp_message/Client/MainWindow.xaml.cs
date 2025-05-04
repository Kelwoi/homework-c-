using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string serverAddress = "127.0.0.1";
        const int port = 4040;
        IPEndPoint server;
        UdpClient client;
        ObservableCollection<MessageInfo> messages;
        private bool isListening = false;

        public MainWindow()
        {
            InitializeComponent();
            server = new IPEndPoint(IPAddress.Parse(serverAddress), port);
            messages = new ObservableCollection<MessageInfo>();
            client = new UdpClient();
            this.DataContext = messages;
        }

        private void SendBtn(object sender, RoutedEventArgs e)
        {
            string message = msgTextBox.Text;
            msgTextBox.Text = "";
            if (string.IsNullOrWhiteSpace(message)) { MessageBox.Show("your text is empty"); return;  }
            SendMessage(message);
        }

        private void msgTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendBtn(sender, e);
            }
        }

        private void JoinBtn(object sender, RoutedEventArgs e)
        {
            JoinButton.IsEnabled = false;
            SendMessage("$<join>");
            Listener();
        }
        private async void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            await client.SendAsync(data, data.Length, server);
        }
        private async void Listener()
        {
            isListening = true;
            while (isListening)
            {
                var data = await client.ReceiveAsync();
                string message = Encoding.Unicode.GetString(data.Buffer);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    messages.Add(new MessageInfo(msgNameBox.Text, message));
                });
            }
        }

        private void ClearBtn(object sender, RoutedEventArgs e)
        {
            messages.Clear();
        }

        private void LeaveBtn(object sender, RoutedEventArgs e)
        {
            JoinButton.IsEnabled = true;
            isListening = false;
            SendMessage("$<leave>");
        }
    }


    public class MessageInfo
    {
        public string Name { get; set; }
        public string Message { get; set; }
        private DateTime time;
        public string Time => time.ToLongTimeString();
        public MessageInfo(string name, string message)
        {
            time = DateTime.Now;
            if (name == "") 
            {
                Name = "Unknown";
                Message = message;
            }
            else
            {
                Name = name;
                Message = message;
            }
        
        }
        public override string ToString()
        {
            return $"{Message,-20}  {Time} ";
        }
    }


}