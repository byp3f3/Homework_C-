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

namespace DailyPlanner
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            datefield.SelectedDate = DateTime.Now;
            datefield.Text = datefield.SelectedDate.ToString();
            Screen();

        }

        static List<Note> tasks = Converter.Deserialize<List<Note>>();
        static List<Note> selectedTasks = new List<Note>();

        public void Screen()
        {

            del.IsEnabled = false;
            save.IsEnabled = false;
            create.IsEnabled = true;
            selectedTasks.Clear();
            notename.Text = string.Empty;
            notedescription.Text = string.Empty;
            datefield.Text = datefield.SelectedDate.ToString();
            planlist.DisplayMemberPath = string.Empty;
            try 
            { 
                foreach (Note note in tasks)
                {
                    if (note.NoteDate == datefield.Text)
                    {
                        selectedTasks.Add(note);
                    }

                }
            }
            catch
            {
                tasks = new List<Note>();
            }
            planlist.ItemsSource = selectedTasks;
            planlist.DisplayMemberPath = "Name";
        }

        private void datefield_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Screen();
            return;
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            if (notename.Text == string.Empty || notedescription.Text == string.Empty)
            {
                MessageBox.Show("Убедитесь, что все поля заполнены");
                return;
            }
            else
            {
                CreateNote();
                Screen();
                return;
            }
        }

        public void CreateNote()
        {
            string newnotename = notename.Text;
            string newnotedescription = notedescription.Text;
            Note note = new Note(newnotename, newnotedescription, datefield.Text);
            tasks.Add(note);
            Converter.Serialize(tasks);
            return;
        }

        private void planlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            while (true)
            {
                Note selected;
                create.IsEnabled = false;
                save.IsEnabled = true;
                del.IsEnabled = true;
                selected = (Note)planlist.Items[planlist.SelectedIndex];
                notename.Text = selected.Name;
                notedescription.Text = selected.Description;
                break;
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (notename.Text == string.Empty || notedescription.Text == string.Empty)
            {
                MessageBox.Show("Убедитесь, что все поля заполнены");
                return;
            }
            else
            {
                UpdateNote();
                Screen();
            }
        }

        public void UpdateNote()
        {
            Note selected = (Note)planlist.SelectedItem;
            selected.Name = notename.Text;
            selected.Description = notedescription.Text;
            Converter.Serialize(tasks);
            return;

        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            Note selected = (Note)planlist.Items[planlist.SelectedIndex];
            tasks.Remove(selected);
            Converter.Serialize(tasks);
            Screen();
        }
    }

    internal class Converter
    {
        public static void Serialize<T>(T tasks)
        {
            string json = JsonConvert.SerializeObject(tasks);
            File.WriteAllText("C:\\Users\\HP\\Desktop\\Tasks.json", json);

        }
        public static T Deserialize<T>()
        {
            if (File.Exists("C:\\Users\\HP\\Desktop\\Tasks.json")) 
            { 
                string text = File.ReadAllText("C:\\Users\\HP\\Desktop\\Tasks.json");
                T tasks = JsonConvert.DeserializeObject<T>(text);
                return tasks;
            }
            else
            {
                File.Create("C:\\Users\\HP\\Desktop\\Tasks.json");
                string text = File.ReadAllText("C:\\Users\\HP\\Desktop\\Tasks.json");
                T tasks = JsonConvert.DeserializeObject<T>(text);
                return tasks;
            }
            
        }
    }

    internal class Note
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string NoteDate { get; set; }

        public Note(string name, string description, string date)
        {
            Name = name;
            Description = description;
            NoteDate = date;
        }
    }
}
