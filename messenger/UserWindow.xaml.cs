using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace messenger
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        TcpClient tcpClient = new TcpClient();

        public UserWindow(string nickname, string ip)
        {
            InitializeComponent();
            tcpClient.Start(nickname, ip, messageLbx);
        }

        private void sendBut_Click(object sender, RoutedEventArgs e)
        {
            if (tcpClient.Sending(messageTbx.Text) == 1) { 
                messageTbx.Text = null;
            }
            else if(tcpClient.Sending(messageTbx.Text) == 0)
            {
                Close();
            }
        }

        private void exitBut_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
