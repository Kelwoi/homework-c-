using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Server
{
    static TcpListener listener;
    static List<TcpClient> clients = new List<TcpClient>();
    static int CLIENT_LIMIT = 3;

    static void Main()
    {
        listener = new TcpListener(IPAddress.Any, 8888);
        listener.Start();
        Console.WriteLine("Server started...");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            if (clients.Count != CLIENT_LIMIT) 
            {
                clients.Add(client);
                new Thread(() => HandleClient(client)).Start();
            }
            else
            {
                client.Close();
                Console.WriteLine("sorry too much people in chat");
                break;
            }
        }
    }

    static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        string clientName = "";

        try
        {
            int byteCount = stream.Read(buffer, 0, buffer.Length);
            clientName = Encoding.UTF8.GetString(buffer, 0, byteCount);
            Broadcast($"{clientName} connected to the chat", "server");

            while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string msg = Encoding.UTF8.GetString(buffer, 0, byteCount);
                Broadcast(msg, clientName);
            }
        }
        catch { }
        finally
        {
            clients.Remove(client);
            client.Close();
            Broadcast($"{clientName} left the chat", "server");
        }
    }

    static void Broadcast(string message, string sender)
    {
        string fullMessage = $"[{DateTime.Now:HH:mm:ss}] {sender}: {message}";
        byte[] msgBuffer = Encoding.UTF8.GetBytes(fullMessage);

        foreach (var cl in clients.ToArray())
        {
            try
            {
                cl.GetStream().Write(msgBuffer, 0, msgBuffer.Length);
            }
            catch
            {
                clients.Remove(cl);
            }
        }

        Console.WriteLine(fullMessage);
    }
}
