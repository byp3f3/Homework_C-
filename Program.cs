using consolearrow;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;

internal class Program{ 
    static void Drives() {
        while (true) 
        {
            Console.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.WriteLine("Выберите диск");
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("  " + $"{drive.Name}\t" + $"Свободное пространство: {drive.TotalFreeSpace}");
            }
            int pos = arrow.Show(1, drives.Length);
            if (pos == -90)
                return;
            ShowFolder(Convert.ToString(drives[pos-1]));
        } 
    }
    static void ShowFolder(string s)
    {
        while (true)
        {
            Console.Clear();
            Console.SetCursorPosition(2, 0);
            Console.WriteLine("{0,-50}{1,-30}{2,-20}", "Название", "Дата создания", "Тип");
            string[] paths =  Directory.GetDirectories(s);
            string[] files = Directory.GetFiles(s);
            string[] lines = paths.Concat(files).ToArray();
            
            foreach (string line in lines) 
            {
                string date = Convert.ToString(File.GetCreationTime(line));
                string type = Path.GetExtension(line);
                string name = Path.GetFileName(line);
                Console.WriteLine("  " + "{0,-50}{1,-30}{2,-20}", $"{name}", $"{date}", $"{type}");
            }
            int pos = arrow.Show(1, lines.Length);
            if (pos == -90)
                return;  
            if (paths.Contains(lines[pos-1]))
            {
                ShowFolder(lines[pos-1]);
            }
            else if (files.Contains(lines[pos - 1]))
            {
                Process.Start(new ProcessStartInfo { FileName = lines[pos-1], UseShellExecute = true });
            }
            
        }
    }
    static void Main()
    {
        Drives();
    }

}