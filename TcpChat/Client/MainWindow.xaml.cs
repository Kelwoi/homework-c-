using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Client
{
    public partial class MainWindow : Window
    {
        TcpClient client;
        NetworkStream stream;
        Thread receiveThread;
        bool connected = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (connected) return;

            try
            {
                client = new TcpClient("127.0.0.1", 8888);
                stream = client.GetStream();
                connected = true;

                byte[] nameData = Encoding.UTF8.GetBytes(NameBox.Text);
                stream.Write(nameData, 0, nameData.Length);

                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                AppendText("connected to the server.");
            }
            catch (Exception ex)
            {
                AppendText("error: " + ex.Message);
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void MessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
                e.Handled = true;
            }
        }

        private void SendMessage()
        {
            if (!connected || string.IsNullOrWhiteSpace(MessageBox.Text)) return;

            string msg = MessageBox.Text.Trim();
            byte[] data = Encoding.UTF8.GetBytes(msg);
            stream.Write(data, 0, data.Length);
            MessageBox.Clear();
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    if (bytes == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytes);
                    Dispatcher.Invoke(() => AppendText(msg));
                }
            }
            catch
            {
                Dispatcher.Invoke(() => AppendText("lost connection."));
            }
        }

        private void AppendText(string text)
        {
            ChatBox.AppendText(text + "\n");
            ChatBox.ScrollToEnd();
        }
    }
}
