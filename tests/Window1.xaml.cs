using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace tests
{
    public partial class Window1 : Window
    {
        List<Test> ques = Converter.Deserialize<List<Test>>();
        public Window1()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void changeTest_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page3();
        }

        private void takeTest_Click(object sender, RoutedEventArgs e)
        {
            if(ques.Count > 0)
            {
                PageFrame.Content = new Page2();
            }
            else PageFrame.Content = new Page1();
            
        }
    }
}
