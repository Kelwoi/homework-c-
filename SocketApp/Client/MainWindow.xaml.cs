using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private async void Find_Click(object sender, RoutedEventArgs e)
        {
            StreetsList.Items.Clear();
            string index = IndexBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(index)) return;

            var result = await Task.Run(() => SendIndex(index));
            foreach (var street in result.Split(','))
                StreetsList.Items.Add(street);
        }

        private string SendIndex(string index)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(IPAddress.Loopback, 9000);

            byte[] data = Encoding.UTF8.GetBytes(index);
            socket.Send(data);

            byte[] buffer = new byte[1024];
            int bytesRead = socket.Receive(buffer);
            string result = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

            return result;
        }
    }
}
