using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace pr9
{
    /// <summary>
    /// Логика взаимодействия для SendWindow.xaml
    /// </summary>
    public partial class SendWordWindow : Window
    {
        public SendWordWindow()
        {
            InitializeComponent();
            var textRange = new TextRange(MyRtbx.Document.ContentStart, MyRtbx.Document.ContentEnd);
            var fileStream = new FileStream("rtf_version.rtf", FileMode.OpenOrCreate);
            textRange.Load(fileStream, DataFormats.Rtf);
            fileStream.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var textRange = new TextRange(MyRtbx.Document.ContentStart, MyRtbx.Document.ContentEnd);
            MailMessage message = new MailMessage(from.Text, to.Text, theme.Text, null);
            message.IsBodyHtml = true;
            var fileStream = new FileStream("rtf_version.rtf", FileMode.Create);
            textRange.Save(fileStream, DataFormats.Rtf);
            fileStream.Close();
            Document doc = new Document();
            doc.LoadFromFile("rtf_version.rtf");
            doc.SaveToFile("file.docx", FileFormat.Docx);
            message.Attachments.Add(new Attachment("file.docx"));
            SmtpClient client = new SmtpClient("smtp.mail.ru");
            client.Credentials = new NetworkCredential(from.Text, password.Text);
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
