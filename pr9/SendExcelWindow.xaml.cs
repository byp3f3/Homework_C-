using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для SendExcelWindow.xaml
    /// </summary>
    public partial class SendExcelWindow : Window
    {
        public SendExcelWindow()
        {
            InitializeComponent();
            Workbook wb = new Workbook();
            wb.LoadFromFile("file2.xlsx");
            Worksheet worksheet = wb.Worksheets[0];
            CellRange xLs = worksheet.AllocatedRange;
            var dataTable = worksheet.ExportDataTable(xLs, true);
            grid.ItemsSource = dataTable.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage message = new MailMessage(from.Text, to.Text, theme.Text, null);
            message.IsBodyHtml = true;
            var dataTable = grid.ItemsSource as DataView;
            Workbook wb = new Workbook();
            wb.Worksheets.Clear();
            Worksheet worksheet = wb.Worksheets.Add("Лист 1");
            worksheet.InsertDataView(dataTable, true, 1, 1);
            wb.SaveToFile("file2.xlsx", Spire.Xls.FileFormat.Version2013);
            message.Attachments.Add(new Attachment("file2.xlsx"));
            SmtpClient client = new SmtpClient("smtp.mail.ru");
            client.Credentials = new NetworkCredential(from.Text, password.Text);
            client.EnableSsl = true;
            client.Send(message);
        }
    }
    
}
