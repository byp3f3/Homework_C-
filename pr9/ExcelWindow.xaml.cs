using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace pr9
{
    /// <summary>
    /// Логика взаимодействия для ExcelWindow.xaml
    /// </summary>
    public partial class ExcelWindow : Window
    {
        DataTable dataTable = new DataTable();
        public ExcelWindow()
        {
            InitializeComponent();
        }

        public void LoadFile(string fileNmae)
        {
            Workbook wb = new Workbook();
            wb.LoadFromFile(fileNmae);
            Worksheet worksheet = wb.Worksheets[0];
            CellRange xLs = worksheet.AllocatedRange;
            dataTable = worksheet.ExportDataTable(xLs, true);
            grid.ItemsSource = dataTable.DefaultView;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = dataTable.DefaultView;
            Workbook wb = new Workbook();
            wb.Worksheets.Clear();
            Worksheet worksheet = wb.Worksheets.Add("Лист 1");
            worksheet.InsertDataView(data, true, 1, 1);
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
            {
                wb.SaveToFile($"{dialog.FileName}.xlsx", Spire.Xls.FileFormat.Version2013);
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var data = dataTable.DefaultView;
            Workbook wb = new Workbook();
            wb.Worksheets.Clear();
            Worksheet worksheet = wb.Worksheets.Add("Лист 1");
            worksheet.InsertDataView(data, true, 1, 1);
            wb.SaveToFile("file2.xlsx", Spire.Xls.FileFormat.Version2013);
            SendExcelWindow sendExcelWindow = new SendExcelWindow();
            sendExcelWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataTable.Columns.Add(columnName.Text);
            grid.ItemsSource = dataTable.AsDataView();
            columnName.Clear();
        }
    }
}
