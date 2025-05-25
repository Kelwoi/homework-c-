using System;
using System.Net;
using System.Net.Sockets;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{
    public partial class MainWindow : Window
    {
        UdpClient client;
        IPEndPoint serverEndPoint;

        public MainWindow()
        {
            InitializeComponent();
            client = new UdpClient();
            serverEndPoint = new IPEndPoint(IPAddress.Loopback, 9000);
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string message = InputBox.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            ChatBox.AppendText($"Я: {message}\n");
            InputBox.Clear();

            byte[] data = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(data, data.Length, serverEndPoint);

            var result = await client.ReceiveAsync();
            string response = Encoding.UTF8.GetString(result.Buffer);

            ChatBox.AppendText($"Говорун: {response}\n");
            ChatBox.ScrollToEnd();
        }
    }
}
