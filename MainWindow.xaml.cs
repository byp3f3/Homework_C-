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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Button[] buttons;
        int UserWin = 0;
        int RobotWin = 0;
        int count;
        string user = "X";
        string robot = "O";
        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[9] { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
            StartScreen();
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }
        }
        public void StartScreen()
        {
            results.Text = UserWin.ToString() + " : " + RobotWin.ToString();
            count = 0;
            XorO();
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button button in buttons) { button.IsEnabled = true; button.Content = null; }
            start.IsEnabled = false;
            resulOfRound.Text = "";
            StartScreen();
        }
        private void _1_Click(object sender, RoutedEventArgs e)
        {   
             
            (sender as Button).Content = user;
            (sender as Button).IsEnabled = false;
            count++;
            int win = WinCheck();
            if (win == 1)
                {
                    start.IsEnabled = true;
                    foreach (Button button in buttons)
                    {
                        button.IsEnabled = false;
                    }
                    resulOfRound.Text = "Вы победили!";
                    UserWin++;
                return;
                }

            if (count != 9)
            {
                Random random = new Random();
                int buttonNum = random.Next(0, 9);
                while (buttons[buttonNum].IsEnabled == false)
                    buttonNum = random.Next(0, 9);

                buttons[buttonNum].Content = robot;
                buttons[buttonNum].IsEnabled = false;
                win = WinCheck();
                if (win == 1)
                {
                    resulOfRound.Text = "Вы проиграли(";
                    RobotWin++;
                    start.IsEnabled = true;
                    foreach (Button button in buttons)
                    {
                        button.IsEnabled = false;
                    }
                    return;
                }
                count++;
            }
            else {
                resulOfRound.Text = "Ничья";
                start.IsEnabled = true;
                foreach (Button button in buttons)
                {
                    button.IsEnabled = false;
                }
            }
            
        }

        
        public void XorO()
        {
            if (user == "X")
            {
                user = "O";
                robot = "X";
            }
            else
            {
                user = "X";
                robot = "O";
            }

        }
        private int WinCheck()
        {
            if (buttons[0].Content == buttons[1].Content && buttons[1].Content == buttons[2].Content && buttons[0].Content is not null)
                return 1;
            else if (buttons[0].Content == buttons[3].Content && buttons[3].Content == buttons[6].Content && buttons[0].Content is not null)
                return 1;
            else if (buttons[0].Content == buttons[4].Content && buttons[4].Content == buttons[8].Content && buttons[0].Content is not null)
                return 1;
            else if (buttons[1].Content == buttons[4].Content && buttons[4].Content == buttons[7].Content && buttons[1].Content is not null)
                return 1;
            else if (buttons[2].Content == buttons[5].Content && buttons[5].Content == buttons[8].Content && buttons[2].Content is not null)
                return 1;
            else if (buttons[3].Content == buttons[4].Content && buttons[4].Content == buttons[5].Content && buttons[3].Content is not null)
                return 1;
            else if (buttons[6].Content == buttons[7].Content && buttons[7].Content == buttons[8].Content && buttons[6].Content is not null)
                return 1;
            else if (buttons[2].Content == buttons[4].Content && buttons[4].Content == buttons[6].Content && buttons[2].Content is not null)
                return 1;
            else return 0;
        }
    }
}
