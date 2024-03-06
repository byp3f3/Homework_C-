using Microsoft.WindowsAPICodePack.Dialogs;
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

namespace audioplayer
{
    public partial class MainWindow : Window
{       bool repeat = false;
        bool mix = false;
        public MainWindow()
        {
            InitializeComponent();
            media.Volume = 0.7;
            songlist.DisplayMemberPath = "Name";
            
        }

        List<FileInfo> histlist = new List<FileInfo>();
        private void history_Click(object sender, RoutedEventArgs e)
        {
            int i =0;
            HistoryWindow window = new HistoryWindow(histlist);
            bool? result = window.ShowDialog();
            if (result == true) 
            {
                foreach (FileInfo song in songlist.ItemsSource)
                {
                    if(window.choose == song)
                    {
                        songlist.SelectedItem = song;
                        musicplay(i);
                    }
                    i++; 
                }
            }

        }

        public void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            pos.Maximum = media.NaturalDuration.TimeSpan.Ticks;
            timemax.Text = media.NaturalDuration.TimeSpan.ToString();
            timecount.Text = media.Position.ToString();

        }

        private void pos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = new TimeSpan(Convert.ToInt64(pos.Value));
        }

        List<FileInfo> songs = new List<FileInfo>();
        CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true};
        private void openfolder_Click(object sender, RoutedEventArgs e)
        {

            var result = dialog.ShowDialog();
            if(result == CommonFileDialogResult.Ok)
            {
                foreach(var song in Directory.GetFiles(dialog.FileName))
                {
                    if (song.EndsWith(".mp3") || song.EndsWith(".m4a") || song.EndsWith("wav")) { 
                        songs.Add(new FileInfo(song));
                    }
                }
                songlist.ItemsSource = songs;
                songlist.SelectedIndex = 0;
                musicplay(0);
            }
        }

        private void musicplay(int i)
        {
                songlist.SelectedIndex = i;
                pos.Value = 0;
                media.Source = new Uri(songs[i].ToString());
                media.Play();
            histAdd(songs[i]);
        }


        int count = 0;
        private void pause_Click(object sender, RoutedEventArgs e)
        {
            if(count == 0)
            {
                media.Pause();
                count++;
            }
            else if (count == 1)
            {
                media.Play();
                count--;
            }
        }

        private void songlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            musicplay(songlist.SelectedIndex);
        }
        
        private void histAdd(FileInfo history)
        {
            foreach(FileInfo h in histlist.ToList())
            {
                if (h.Name == history.Name)
                {   
                    histlist.Remove(h);
                }
            }
            histlist.Add(history);
        }

        int next = 0;
        private void forward_Click(object sender, RoutedEventArgs e)
        {
            
            next = songlist.SelectedIndex + 1;
            if (next < songs.Count)
            {
                songlist.SelectedIndex = next;
                musicplay(next);
            }
            else
            {
                songlist.SelectedIndex = 0;
                musicplay(0);
            }
        }

        private void backward_Click(object sender, RoutedEventArgs e)
        {
            next = songlist.SelectedIndex - 1;
            if (next >= 0) 
            { 
                songlist.SelectedIndex = next;
                musicplay(next);
            }
            else 
            {
                songlist.SelectedIndex = songs.Count - 1;
                musicplay(songs.Count - 1);
            }
        }

        private void repeat_but_Click(object sender, RoutedEventArgs e)
        {
            if(repeat == false)
            {
                repeat = true;
            }
            else { repeat = false; }
        }

        Random rand = new Random();
        private void mix_but_Click(object sender, RoutedEventArgs e)
        {
            songlist.DisplayMemberPath = string.Empty;
            if (mix == false)
            {   
                mix = true;
                for (int i = songs.Count - 1; i >= 1; i--)
                {
                    int j = rand.Next(i + 1);
                    FileInfo tmp = songs[j];
                    songs[j] = songs[i];
                    songs[i] = tmp;
                }
                songlist.ItemsSource = songs;
                songlist.DisplayMemberPath = "Name";
                musicplay(0);
            }
            else if (mix == true)
            {   
                songlist.DisplayMemberPath = string.Empty;
                mix = false;
                songs = songs.OrderBy(w => w.Name).ToList();
                songlist.ItemsSource = songs;
                songlist.DisplayMemberPath = "Name";
                musicplay(0);
            }
        }
    }
}
