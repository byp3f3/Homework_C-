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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tests
{
    public partial class MainWindow : Window
    {
        List<Test> questions = Converter.Deserialize<List<Test>>();
        
        public MainWindow()
        {
            InitializeComponent();
            password.IsEnabled = false;
            password.Visibility = Visibility.Collapsed;  
        }
        
        

        private void change_Click(object sender, RoutedEventArgs e)
        {
            password.IsEnabled = true;
            password.Visibility = Visibility.Visible;
        }


        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (password.Text == "cot")
                {
                Window1 window1 = new Window1();
                window1.Show();
                Close();
            }

        }

        private void take_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(questions.Count !=0) { 
                Window1 window1 = new Window1();
                window1.PageFrame.Content = new Page2();
                window1.changeTest.IsEnabled = false;
                window1.Show();
                Close();}
            }
            catch{ 
            Window1 window1 = new Window1();
            window1.PageFrame.Content = new Page1();
            window1.changeTest.IsEnabled = false;
            window1.Show();
            Close();
            }
        }
    }
}
