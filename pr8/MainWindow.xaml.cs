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
using ConverterLib;

namespace pr8 { 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Cats> cats = new List<Cats>();
            Cats cat = new Cats();
            cats.Add(cat);
            grid.ItemsSource = cats;
        }
        private void ser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Cats> cats = grid.Items.OfType<Cats>().ToList();
                Converter.Serialize(cats, fileName.Text);
            }
            catch { MessageBox.Show("Что-то пошло не так..."); };
        }

        private void deser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Cats> cats = Converter.Deserialize<List<Cats>>(fileName.Text);
                grid.ItemsSource = cats;
                if (cats ==  null || cats.Count == 0)
                {
                    Cats cat = new Cats();
                }
            }
            catch { MessageBox.Show("Что-то пошло не так..."); };
        }

        //pink
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App.Theme = "PinkTheme";
        }

        //green
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            App.Theme = "GreenTheme";
        }
    }
}
