using System;
using System.Collections.Generic;
using System.Globalization;
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
   
    public partial class Page2 : Page
    {
        List<Test> ques = Converter.Deserialize<List<Test>>();
        int i = 0;
         public int point_count = 0;
        public Page2()
        {
            InitializeComponent();
            display_question(i);
            Win.Visibility = Visibility.Collapsed;
            pic.Visibility = Visibility.Collapsed;
        }

        private void display_question(int num)
        {
            if (ques != null)
            {
                Name.Text = ques[num].Name;
                Desc.Text = ques[num].Description;
                _1.Content = ques[num].FirstAnswer;
                _2.Content = ques[num].SecondAnswer;
                _3.Content = ques[num].ThirdAnswer;
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (i < ques.Count-1)
                {
                    if ((_1.IsChecked == true && ques[i].RightAnswer == 0) || (_2.IsChecked == true && (int)ques[i].RightAnswer == 1) || (_3.IsChecked == true && (int)ques[i].RightAnswer == 2))
                    {
                        point_count++;
                    }
                    i++;
                    display_question(i);
                    _1.IsChecked = false;
                    _2.IsChecked = false;
                    _3.IsChecked = false;
                }
            else 
                {
                    if ((_1.IsChecked == true && ques[i].RightAnswer == 0) || (_2.IsChecked == true && (int)ques[i].RightAnswer == 1) || (_3.IsChecked == true && (int)ques[i].RightAnswer == 2))
                    {
                        point_count++;
                    }
                    next.Visibility = Visibility.Collapsed;
                    Name.Visibility = Visibility.Collapsed;
                    Desc.Visibility = Visibility.Collapsed;
                    _1.Visibility = Visibility.Collapsed;
                    _2.Visibility = Visibility.Collapsed;
                    _3.Visibility = Visibility.Collapsed;
                    Win.Visibility = Visibility.Visible;
                    Win.Text = "Ваш результат: " + point_count.ToString() + "/" + ques.Count;
                    pic.Visibility = Visibility.Visible;
                }
        }
    }
}
