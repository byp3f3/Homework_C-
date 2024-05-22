using System;
using System.Collections.Generic;
using System.Linq;
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

namespace messenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nicknameTbx.Text != "" && !string.IsNullOrWhiteSpace(nicknameTbx.Text))
                {
                    AdminWindow window = new AdminWindow();
                    window.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Введите имя пользователя");
                }
            }
            catch
            {
                MessageBox.Show("Не удалось создать чат");
            }
        }

        private void connectBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nicknameTbx.Text != "" && ipTbx.Text != "" && !string.IsNullOrWhiteSpace(nicknameTbx.Text) && !string.IsNullOrWhiteSpace(ipTbx.Text))
                {
                    UserWindow window = new UserWindow(nicknameTbx.Text, ipTbx.Text);
                    window.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Убедитесь что все поля заполнены");
                }
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться");
            }
            
        }
    }
}
