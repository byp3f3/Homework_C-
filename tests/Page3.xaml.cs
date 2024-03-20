using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace tests{

    public partial class Page3 : Page
    {
       
        public Page3()
        {
            InitializeComponent();

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
         
        private ObservableCollection<Test> ques = Converter.Deserialize<ObservableCollection<Test>>();
        
        public ObservableCollection<Test> Tests 
        { 
            get {   return ques; } 
            set { 
                ques = value;
                OnPropertyChanged();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test t = new Test();
            t.Name = " ";
            t.Description = " ";
            t.FirstAnswer = " ";
            t.SecondAnswer = " ";
            t.ThirdAnswer = " ";
            t.RightAnswer = 0;
            Tests.Add(t);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Converter.Serialize(ques);
        }
    }
}
