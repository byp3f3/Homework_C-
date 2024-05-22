using MaterialDesignThemes.Wpf.Converters.CircularProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace messenger
{
    internal class TcpServer
    {
        public Socket socket;
        List<Socket> clients = new List<Socket>();
        public IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
        public ListBox messageLbx;
        public void Start(ListBox messag)
        {
            messageLbx = messag;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            socket.Listen(1000);
            ListenToClient();
            
        }
        private async Task ListenToClient()
        {
            while (true)
            {
                Socket client = await socket.AcceptAsync();
                clients.Add(client);
                ReceiveMessage(client);
            }
        }

        private async Task ReceiveMessage(Socket client)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                messageLbx.Items.Add($"[{DateTime.Now}] {message}");

                foreach (var item in clients)
                {
                    SendMessage(item, message);
                }
            }
        }

        private async Task SendMessage(Socket client, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(bytes, SocketFlags.None);
        }

        private async Task SendServerMessage(string message)
        {
            foreach (var item in clients)
            {
                SendMessage(item, message);
            }
        }


        public int Sending(string message)
        {
            if (message != "/disconnect")
            {
                SendServerMessage(message);
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
