using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;
using System.Xml.Linq;

namespace Chemical_Equations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DispatcherTimer disTick = new DispatcherTimer();

        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5 };
        public int level { get; set; }
        public int qNum { get; set; } = 0;
        public int score { get; set; }
        public int i { get; set; }
        public bool TimerSwitch { get; set; } = true;
        public bool SoundSwitch { get; set; } = true;
        public bool WrongAnswer { get; set; } = false;
        public int secondsCount { get; set; } = 0;
        public int index1 { get; set; }
        public int index2 { get; set; }
        public int index3 { get; set; }
        public int index4 { get; set; }


        private void NextQuestion()
        {
            if (qNum < questionNumbers.Count)
            {
                i = questionNumbers[qNum];
            }
            else
            {

            }

            if (level == 1)
            {
                switch (i)
                {
                    case 1:
                        Chem1.Content = "H2";
                        index1 = 2;
                        Chem2.Content = "O2";
                        index2 = 1;
                        Chem3.Content = "H2O";
                        index3 = 2;

                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;

                        break;

                    case 2:
                        Chem1.Content = "N2";
                        index1 = 1;
                        Chem2.Content = "H2";
                        index2 = 3;
                        Chem3.Content = "NH3";
                        index3 = 2;

                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;

                    case 3:
                        Chem1.Content = "Sn";
                        index1 = 1;
                        Chem2.Content = "Cl2";
                        index2 = 2;
                        Chem3.Content = "SnCl4";
                        index3 = 1;

                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;

                    case 4:
                        Chem1.Content = "N2";
                        index1 = 2;
                        Chem2.Content = "O2";
                        index2 = 1;
                        Chem3.Content = "N2O";
                        index3 = 2;

                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;

                    case 5:
                        Chem1.Content = "Li";
                        index1 = 4;
                        Chem2.Content = "O2";
                        index2 = 1;
                        Chem3.Content = "Li2O";
                        index3 = 2;

                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;
                }
            }

            else if(level == 2)
            {
                switch (i)
                {
                    case 1:
                        Chem1.Content = "HCl";
                        index1 = 2;
                        Chem2.Content = "Na";
                        index2 = 2;
                        Chem3.Content = "NaCl";
                        index3 = 2;
                        Chem4.Content = "H2";
                        index4 = 1;
                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";
                        Index4_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;

                        break;

                    case 2:
                        Chem1.Content = "Zn";
                        index1 = 1;
                        Chem2.Content = "HCl";
                        index2 = 2;
                        Chem3.Content = "ZnCl2";
                        index3 = 1;
                        Chem4.Content = "H2";
                        index4 = 1;
                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";
                        Index4_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;

                    case 3:
                        Chem1.Content = "CH4";
                        index1 = 1;
                        Chem2.Content = "O2";
                        index2 = 2;
                        Chem3.Content = "CO2";
                        index3 = 1;
                        Chem4.Content = "H2O";
                        index4 = 2;
                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";
                        Index4_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;

                    case 4:
                        Chem1.Content = "LiH";
                        index1 = 1;
                        Chem2.Content = "H2O";
                        index2 = 1;
                        Chem3.Content = "LiOH";
                        index3 = 1;
                        Chem4.Content = "H2";
                        index4 = 1;
                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";
                        Index4_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;

                    case 5:
                        Chem1.Content = "ZnO";
                        index1 = 1;
                        Chem2.Content = "C";
                        index2 = 1;
                        Chem3.Content = "Zn";
                        index3 = 1;
                        Chem4.Content = "CO";
                        index4 = 1;
                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";
                        Index4_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;
                }
            }

            else if (level == 3)
            {
                switch (i)
                {
                    case 1:
                        Chem1.Content = "C2H6";
                        index1 = 2;
                        Chem2.Content = "O2";
                        index2 = 7;
                        Chem3.Content = "CO2";
                        index3 = 4;
                        Chem4.Content = "H2O";
                        index4 = 6;
                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";
                        Index4_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;

                        break;

                    case 2:
                        Chem1.Content = "Al";
                        index1 = 2;
                        Chem2.Content = "NH3";
                        index2 = 2;
                        Chem3.Content = "AlN";
                        index3 = 2;
                        Chem4.Content = "H2";
                        index4 = 3;
                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";
                        Index4_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;

                    case 3:
                        Chem1.Content = "NH3";
                        index1 = 4;
                        Chem2.Content = "O2";
                        index2 = 5;
                        Chem3.Content = "NO";
                        index3 = 4;
                        Chem4.Content = "H2O";
                        index4 = 6;
                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";
                        Index4_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;

                    case 4:
                        Chem1.Content = "HI";
                        index1 = 4;
                        Chem2.Content = "O2";
                        index2 = 1;
                        Chem3.Content = "I2";
                        index3 = 2;
                        Chem4.Content = "H2O";
                        index4 = 2;
                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";
                        Index4_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;

                    case 5:
                        Chem1.Content = "H2S";
                        index1 = 2;
                        Chem2.Content = "SO2";
                        index2 = 1;
                        Chem3.Content = "S";
                        index3 = 3;
                        Chem4.Content = "H2O";
                        index4 = 2;
                        Index1_TextBox.Text = "";
                        Index2_TextBox.Text = "";
                        Index3_TextBox.Text = "";
                        Index4_TextBox.Text = "";

                        Level_Label.Content = "Level " + level;
                        Question_Label.Content = ($"Question {qNum + 1} out of 5");
                        Score_Label.Content = "Score: " + score;
                        break;
                }
            }

        }

        private void CheckAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (level == 1)
            {
                try
                {
                    if (int.Parse(Index1_TextBox.Text) == index1 && int.Parse(Index2_TextBox.Text) == index2 && int.Parse(Index3_TextBox.Text) == index3)
                    {
                        qNum++;

                        if (WrongAnswer == false)
                        {
                            score += 2;
                        }
                        else
                        {
                            score++;
                        }

                        if (qNum < questionNumbers.Count)
                        {
                            NextQuestion_Menu.Visibility = Visibility.Visible;
                            NextQuestion_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/right.png"));
                            NextQuestion_Button.Content = "Continue";
                            NextQuestion_Label.Content = "Correct!";
                        }
                        else
                        {

                            if (TimerSwitch == true)
                            {
                                FinalTime_Label.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                FinalTime_Label.Visibility = Visibility.Hidden;
                            }

                            NextQuestion_Menu.Visibility = Visibility.Visible;
                            NextQuestion_Button.Content = "Continue";
                            GradeManager();
                            disTick.Stop();
                            NextQuestion_Label.Content = " Score: " + score;
                        }
                    }
                    else
                    {
                        NextQuestion_Menu.Visibility = Visibility.Visible;
                        NextQuestion_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/wrong.png"));
                        NextQuestion_Button.Content = "Retry";
                        NextQuestion_Label.Content = "Wrong!";
                    }
                }
                catch
                {
                    MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }


            else if (level == 2 || level == 3)
            {
                try
                {
                    if (int.Parse(Index1_TextBox.Text) == index1 && int.Parse(Index2_TextBox.Text) == index2 && int.Parse(Index3_TextBox.Text) == index3 && int.Parse(Index4_TextBox.Text) == index4)
                    {
                        qNum++;

                        if (WrongAnswer == false)
                        {
                            score += 2;
                        }
                        else
                        {
                            score++;
                        }

                        if (qNum < questionNumbers.Count)
                        {
                            NextQuestion_Menu.Visibility = Visibility.Visible;
                            NextQuestion_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/right.png"));
                            NextQuestion_Button.Content = "Continue";
                            NextQuestion_Label.Content = "Correct!";
                        }
                        else
                        {
                            if (TimerSwitch == true)
                            {
                                FinalTime_Label.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                FinalTime_Label.Visibility = Visibility.Hidden;
                            }

                            NextQuestion_Menu.Visibility = Visibility.Visible;
                            NextQuestion_Button.Content = "Continue";
                            GradeManager();
                            disTick.Stop();
                            NextQuestion_Label.Content = " Score: " + score;
                        }
                    }
                    else
                    {
                        NextQuestion_Menu.Visibility = Visibility.Visible;
                        NextQuestion_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/wrong.png"));
                        NextQuestion_Button.Content = "Retry";
                        NextQuestion_Label.Content = "Wrong!";
                    }
                }
                catch
                {
                    MessageBox.Show("Please fill all the boxes!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
        }

        private void StartGameOnHard_Click(object sender, RoutedEventArgs e)
        {
            level = 3;
            Time_Label.Content = "Time: " + secondsCount.ToString();
            StartGame();
            NextQuestion();
            Timer();

            if (TimerSwitch == true)
            {
                Time_Label.Visibility = Visibility.Visible;
            }
            else
            {
                Time_Label.Visibility = Visibility.Hidden;
            }

            GameMenu.Visibility = Visibility.Visible;
        }

        private void StartGameOnMedium_Click(object sender, RoutedEventArgs e)
        {
            level = 2;
            Time_Label.Content = "Time: " + secondsCount.ToString();
            StartGame();
            NextQuestion();
            Timer();

            if (TimerSwitch == true)
            {
                Time_Label.Visibility = Visibility.Visible;
            }
            else
            {
                Time_Label.Visibility = Visibility.Hidden;
            }

            GameMenu.Visibility = Visibility.Visible;
        }

        private void StartGameOnEasy_Click(object sender, RoutedEventArgs e)
        {
            level = 1;
            Time_Label.Content = "Time: " + secondsCount.ToString();
            StartGame();
            NextQuestion();
            Timer();

            if(TimerSwitch == true)
            {
                Time_Label.Visibility = Visibility.Visible;
            }
            else
            {
                Time_Label.Visibility = Visibility.Hidden;
            }

            Plus_Label.Visibility = Visibility.Hidden;
            Chem4.Visibility = Visibility.Hidden;
            Index4_TextBox.Visibility = Visibility.Hidden;
            GameMenu.Visibility = Visibility.Visible;

            molecule14.Visibility = Visibility.Hidden;
            molecule24.Visibility = Visibility.Hidden;
            molecule34.Visibility = Visibility.Hidden;
            molecule44.Visibility = Visibility.Hidden;
            molecule54.Visibility = Visibility.Hidden;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ExitGame();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (level == 1)
            {
                try
                {
                    if (int.Parse(Index1_TextBox.Text) == index1 && int.Parse(Index2_TextBox.Text) == index2 && int.Parse(Index3_TextBox.Text) == index3)
                    {

                        if (qNum < questionNumbers.Count)
                        {
                            NextQuestion();
                            NextQuestion_Menu.Visibility = Visibility.Hidden;
                            WrongAnswer = false;
                        }
                        else
                        {
                            ExitGame();
                        }
                    }
                    else
                    {
                        NextQuestion_Menu.Visibility = Visibility.Hidden;
                        WrongAnswer = true;
                    }
                }
                catch
                {
                    return;
                }
            }


            else if (level == 2 || level == 3)
            {
                try
                {
                    if (int.Parse(Index1_TextBox.Text) == index1 && int.Parse(Index2_TextBox.Text) == index2 && int.Parse(Index3_TextBox.Text) == index3 && int.Parse(Index4_TextBox.Text) == index4)
                    {
                       
                        if(qNum < questionNumbers.Count)
                        {
                            NextQuestion();
                            NextQuestion_Menu.Visibility = Visibility.Hidden;
                            WrongAnswer = false;
                        }
                        else
                        {
                            ExitGame();
                        }
                    }
                    else
                    {
                        NextQuestion_Menu.Visibility = Visibility.Hidden;
                        WrongAnswer = true;
                    }
                }
                catch
                {
                    return;
                }
            }
            
        }


        private void GradeManager()
        {
            if (score < 11 && score > 8)
            {
                NextQuestion_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/gradeA.png"));
            }
            else if (score < 9 && score > 7)
            {
                NextQuestion_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/gradeB.png"));
            }
            else if (score < 8 && score > 5)
            {
                NextQuestion_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/gradeD.png"));
            }
            else if (score < 6 && score > 3)
            {
                NextQuestion_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/gradeC.png"));
            }
            else
            {
                NextQuestion_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/gradeF.png"));
            }
        }

        private void Timer()
        {
            disTick.Tick += new EventHandler(disTick_Tick);
            disTick.Interval = new TimeSpan(0, 0, 1);
            disTick.Start();
        }

        private void disTick_Tick(object sender, EventArgs e)
        {
            secondsCount++;
            Time_Label.Content = "Time: " + secondsCount.ToString();
            FinalTime_Label.Content = "Time: " + secondsCount.ToString();
        }

        private void ExitGame()
        {
            score = 0;
            qNum = 0;
            secondsCount = 0;
            disTick.Tick -= new EventHandler(disTick_Tick);
            GameMenu.Visibility = Visibility.Hidden;
            NextQuestion_Menu.Visibility = Visibility.Hidden;
            Plus_Label.Visibility = Visibility.Visible;
            Chem4.Visibility = Visibility.Visible;
            Index4_TextBox.Visibility = Visibility.Visible;
            FinalTime_Label.Visibility = Visibility.Hidden;
        }
        private void StartGame()
        {
            var randomList = questionNumbers.OrderBy(a => Guid.NewGuid()).ToList();
            questionNumbers = randomList;
        }

        private void TimerSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (TimerSwitch == false)
            {
                TimerSwitch = true;
                TimerSwitch_Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/ClockButton1.png"));
            }
            else
            {
                TimerSwitch = false;
                TimerSwitch_Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/ClockButton2.png"));
            }
        }

        private void SoundSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (SoundSwitch == false)
            {
                SoundSwitch = true;
                SoundSwitch_Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/SoundButton1.png"));
            }
            else
            {
                SoundSwitch = false;
                SoundSwitch_Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/SoundButton2.png"));
            }
        }

        private void TextChanged1(object sender, TextChangedEventArgs e)
        {
            if(Index1_TextBox.Text != "")
            {
                if(int.Parse(Index1_TextBox.Text) > 0)
                {
                    molecule51.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule51.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule51.Visibility = Visibility.Hidden;
            }

            if (Index1_TextBox.Text != "")
            {
                if (int.Parse(Index1_TextBox.Text) > 1)
                {
                    molecule41.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule41.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule41.Visibility = Visibility.Hidden;
            }

            if (Index1_TextBox.Text != "")
            {
                if (int.Parse(Index1_TextBox.Text) > 2)
                {
                    molecule31.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule31.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule31.Visibility = Visibility.Hidden;
            }

            if (Index1_TextBox.Text != "")
            {
                if (int.Parse(Index1_TextBox.Text) > 3)
                {
                    molecule21.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule21.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule21.Visibility = Visibility.Hidden;
            }

            if (Index1_TextBox.Text != "")
            {
                if (int.Parse(Index1_TextBox.Text) > 4)
                {
                    molecule11.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule11.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule11.Visibility = Visibility.Hidden;
            }
        }

        private void TextChanged2(object sender, TextChangedEventArgs e)
        {
            if (Index2_TextBox.Text != "")
            {
                if (int.Parse(Index2_TextBox.Text) > 0)
                {
                    molecule52.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule52.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule52.Visibility = Visibility.Hidden;
            }

            if (Index2_TextBox.Text != "")
            {
                if (int.Parse(Index2_TextBox.Text) > 1)
                {
                    molecule42.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule42.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule42.Visibility = Visibility.Hidden;
            }

            if (Index2_TextBox.Text != "")
            {
                if (int.Parse(Index2_TextBox.Text) > 2)
                {
                    molecule32.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule32.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule32.Visibility = Visibility.Hidden;
            }

            if (Index2_TextBox.Text != "")
            {
                if (int.Parse(Index2_TextBox.Text) > 3)
                {
                    molecule22.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule22.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule22.Visibility = Visibility.Hidden;
            }

            if (Index2_TextBox.Text != "")
            {
                if (int.Parse(Index2_TextBox.Text) > 4)
                {
                    molecule12.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule12.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule12.Visibility = Visibility.Hidden;
            }
        }

        private void TextChanged3(object sender, TextChangedEventArgs e)
        {
            if (Index3_TextBox.Text != "")
            {
                if (int.Parse(Index3_TextBox.Text) > 0)
                {
                    molecule53.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule53.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule53.Visibility = Visibility.Hidden;
            }

            if (Index3_TextBox.Text != "")
            {
                if (int.Parse(Index3_TextBox.Text) > 1)
                {
                    molecule43.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule43.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule43.Visibility = Visibility.Hidden;
            }

            if (Index3_TextBox.Text != "")
            {
                if (int.Parse(Index3_TextBox.Text) > 2)
                {
                    molecule33.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule33.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule33.Visibility = Visibility.Hidden;
            }

            if (Index3_TextBox.Text != "")
            {
                if (int.Parse(Index3_TextBox.Text) > 3)
                {
                    molecule23.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule23.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule23.Visibility = Visibility.Hidden;
            }

            if (Index3_TextBox.Text != "")
            {
                if (int.Parse(Index3_TextBox.Text) > 4)
                {
                    molecule13.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule13.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule13.Visibility = Visibility.Hidden;
            }
        }

        private void TextChanged4(object sender, TextChangedEventArgs e)
        {
            if (Index4_TextBox.Text != "")
            {
                if (int.Parse(Index4_TextBox.Text) > 0)
                {
                    molecule54.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule54.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule54.Visibility = Visibility.Hidden;
            }

            if (Index4_TextBox.Text != "")
            {
                if (int.Parse(Index4_TextBox.Text) > 1)
                {
                    molecule44.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule44.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule44.Visibility = Visibility.Hidden;
            }

            if (Index4_TextBox.Text != "")
            {
                if (int.Parse(Index4_TextBox.Text) > 2)
                {
                    molecule34.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule34.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule34.Visibility = Visibility.Hidden;
            }

            if (Index4_TextBox.Text != "")
            {
                if (int.Parse(Index4_TextBox.Text) > 3)
                {
                    molecule24.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule24.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule24.Visibility = Visibility.Hidden;
            }

            if (Index4_TextBox.Text != "")
            {
                if (int.Parse(Index4_TextBox.Text) > 4)
                {
                    molecule14.Visibility = Visibility.Visible;
                }
                else
                {
                    molecule14.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                molecule14.Visibility = Visibility.Hidden;
            }
        }
    }
}
