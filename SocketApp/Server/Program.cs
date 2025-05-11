using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;
using System.Linq;

class Program
{
    static void Main()
    {
        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        listener.Bind(new IPEndPoint(IPAddress.Any, 9000));
        listener.Listen(10);

        Console.WriteLine("server started.");

        while (true)
        {
            Socket handler = listener.Accept();

            byte[] buffer = new byte[256];
            int bytesRead = handler.Receive(buffer);
            string index = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"received index: {index}");

            var doc = XDocument.Load("streets.xml");
            var streets = doc.Descendants("Entry")
                .Where(e => e.Element("Index")?.Value == index)
                .Select(e => e.Element("Street")?.Value)
                .ToList();

            string response = streets.Count > 0 ? string.Join(",", streets) : "nothing found";
            byte[] data = Encoding.UTF8.GetBytes(response);
            handler.Send(data);

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}
