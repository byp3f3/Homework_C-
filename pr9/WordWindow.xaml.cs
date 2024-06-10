using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Spire.Doc;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Document = Spire.Doc.Document;

namespace pr9
{
    /// <summary>
    /// Логика взаимодействия для WordWindow.xaml
    /// </summary>
    public partial class WordWindow : Window
    {
        public WordWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        void SaveFile(string fileName)
        {
            var textRange =  new TextRange(MyRtbx.Document.ContentStart, MyRtbx.Document.ContentEnd);
            var fileStream = new FileStream("rtf_version.rtf", FileMode.Create);
            textRange.Save(fileStream, DataFormats.Rtf);
            fileStream.Close();
            Document doc = new Document();
            doc.LoadFromFile("rtf_version.rtf");
            doc.SaveToFile("fff", FileFormat.Docx);
        }
           
        public void LoadFile(string fileName)
        {
            Document doc = new Document();
            doc.LoadFromFile(fileName);
            doc.SaveToFile("rtf_version.rtf", FileFormat.Rtf);
            var textRange = new TextRange(MyRtbx.Document.ContentStart, MyRtbx.Document.ContentEnd);
            var fileStream = new FileStream("rtf_version.rtf", FileMode.OpenOrCreate);
            textRange.Load(fileStream, DataFormats.Rtf);
            fileStream.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
            {
                var textRange = new TextRange(MyRtbx.Document.ContentStart, MyRtbx.Document.ContentEnd);
                var fileStream = new FileStream("rtf_version.rtf", FileMode.Create);
                textRange.Save(fileStream, DataFormats.Rtf);
                fileStream.Close();
                Document doc = new Document();
                doc.LoadFromFile("rtf_version.rtf");
                doc.SaveToFile(@$"{dialog.FileName}", FileFormat.Docx);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var textRange = new TextRange(MyRtbx.Document.ContentStart, MyRtbx.Document.ContentEnd);
            var fileStream = new FileStream("rtf_version.rtf", FileMode.Create);
            textRange.Save(fileStream, DataFormats.Rtf);
            fileStream.Close();
            SendWordWindow sendWindow = new SendWordWindow();
            sendWindow.Show();
        }
    }
}
