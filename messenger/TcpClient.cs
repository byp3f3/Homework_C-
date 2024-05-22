using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace messenger
{
    internal class TcpClient
    {
        private Socket server;
        List<Socket> clients = new List<Socket>();
        public ListBox messageLbx;
        public void Start(string nickname, string ip, ListBox message)
        {
            messageLbx = message;
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(ip, 8888);
            Socket client = server;
            clients.Add(client);
            ListenToClient();
            ReceiveMessage(messageLbx);
        }

        private async Task ListenToClient()
        {
            while (true)
            {
                Socket client = await server.AcceptAsync();
                clients.Add(client);
                ReceiveMessage(messageLbx);
            }
        }

        private async Task ReceiveMessage(ListBox messageLbx)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await server.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                messageLbx.Items.Add($"[{DateTime.Now}]{message}");
            }
        }

        private async Task SendMessage(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await server.SendAsync(bytes, SocketFlags.None);
        }

        public int Sending(string message)
        {
            if (message != "/disconnect")
            {
                SendMessage(message);
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
