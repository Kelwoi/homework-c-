using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        UdpClient server = new UdpClient(9000);
        Console.WriteLine("Сервер запущено на порті 9000...");

        Dictionary<string, string> responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "привіт", "Привіт! Як справи?" },
            { "як справи", "Все чудово! А у тебе?" },
            { "хто ти", "Я — Говорун, твій віртуальний співрозмовник!" },
            { "що робиш", "Спілкуюсь з тобою :)" }
        };

        while (true)
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = server.Receive(ref remoteEP);
            string message = Encoding.UTF8.GetString(data);

            Console.WriteLine($"Отримано: {message}");

            string response = "Цікаво... Розкажи більше.";
            foreach (var pair in responses)
            {
                if (message.ToLower().Contains(pair.Key))
                {
                    response = pair.Value;
                    break;
                }
            }

            byte[] responseData = Encoding.UTF8.GetBytes(response);
            server.Send(responseData, responseData.Length, remoteEP);
        }
    }
}
