using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
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
using static System.Net.Mime.MediaTypeNames;

namespace Quiz_App
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (QuizMenu.Visibility == Visibility.Hidden)
            {
                QuizMenu.Visibility = Visibility.Visible;
                StartGame();
                NextQuestion();
            }
        }

        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5 };

        public int qNum { get; set; }
        public int score { get; set; }
        public int i { get; set; }

        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            
            if(QuizMenu.Visibility == Visibility.Visible)
            {
                if (senderButton.Tag.ToString() == "1")
                {
                    score++;
                }

                if (qNum < 0)
                {
                    qNum = 0;
                }
                else
                {

                    qNum++;
                }

                NextQuestion();
            }
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            if (EndGameMenu.Visibility == Visibility.Visible)
            {
                RestartGame();
                NextQuestion();
                EndGameMenu.Visibility = Visibility.Hidden;
                QuizMenu.Visibility = Visibility.Visible;
            }
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void RestartGame()
        {
            score = 0;
            qNum = 0;
            i = 1; 
            StartGame();
        }

        private void NextQuestion()
        {
            if (qNum < questionNumbers.Count)
            {
                i = questionNumbers[qNum];
            }
            else
            {
                GameOver();
            }
         
            foreach (var x in QuizMenu.Children.OfType<Button>())
            {
                x.Tag = "0";
            }


            switch (i)
            {
                case 1:
                    QuizMenu.Background = new SolidColorBrush(Colors.LightPink);
                    QuestionText.Foreground = new SolidColorBrush(Colors.DeepPink);
                    QuestionText.Text = "What mathematical function can be defined as multiplying a number with all integers less than or equal to that number?";

                    ans1.Content = "Square root";
                    ans2.Content = "Kronecker delta";
                    ans3.Content = "Riemann zeta function";
                    ans4.Content = "Factorial";

                    imageBrush1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button1.png"));
                    imageBrush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button1.png"));
                    imageBrush3.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button1.png"));
                    imageBrush4.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button1.png"));
                    QuestionImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/1.png"));
                    ans4.Tag = "1";
                    break; 
                case 2:
                    QuizMenu.Background = new SolidColorBrush(Colors.BurlyWood);
                    QuestionText.Foreground = new SolidColorBrush(Colors.SaddleBrown);
                    QuestionText.Text = "What metal is the best conductor of electricity?";

                    ans1.Content = "Silver";
                    ans2.Content = "Gold";
                    ans3.Content = "Tungsten";
                    ans4.Content = "Copper";

                    imageBrush1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button3.png"));
                    imageBrush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button3.png"));
                    imageBrush3.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button3.png"));
                    imageBrush4.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button3.png"));
                    QuestionImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/2.jpg"));
                    ans1.Tag = "1";
                    break;
                case 3:
                    QuizMenu.Background = new SolidColorBrush(Colors.BurlyWood);
                    QuestionText.Foreground = new SolidColorBrush(Colors.SaddleBrown);
                    QuestionText.Text = "What is the only letter not to appear on the periodic table?";

                    ans1.Content = "W";
                    ans2.Content = "J";
                    ans3.Content = "M";
                    ans4.Content = "H";

                    imageBrush1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button3.png"));
                    imageBrush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button3.png"));
                    imageBrush3.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button3.png"));
                    imageBrush4.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button3.png"));
                    QuestionImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/3.jpg"));
                    ans2.Tag = "1";
                    break;
                case 4:
                    QuizMenu.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    QuestionText.Foreground = new SolidColorBrush(Colors.Blue);
                    QuestionText.Text = "How many brains and how many hearts does an octopus have?";

                    ans1.Content = "9 Brains, 3 Hearts";
                    ans2.Content = "16 Brains, 1 Heart";
                    ans3.Content = "1 Brain, 2 Hearts";
                    ans4.Content = "No Brain, 1 Heart";

                    imageBrush1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button.png"));
                    imageBrush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button.png"));
                    imageBrush3.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button.png"));
                    imageBrush4.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button.png"));
                    QuestionImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/4.jpg"));
                    ans1.Tag = "1";
                    break;
                case 5:
                    QuizMenu.Background = new SolidColorBrush(Colors.LightPink);
                    QuestionText.Foreground = new SolidColorBrush(Colors.DeepPink);
                    QuestionText.Text = "What is the heaviest organ in the human body?";

                    ans1.Content = "Liver";
                    ans2.Content = "Testicles";
                    ans3.Content = "Heart";
                    ans4.Content = "Brain";

                    imageBrush1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button1.png"));
                    imageBrush2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button1.png"));
                    imageBrush3.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button1.png"));
                    imageBrush4.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Button1.png"));
                    QuestionImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/5.jpg"));
                    ans1.Tag = "1";
                    break;

            }

        }
        private void StartGame()
        {
            var randomList = questionNumbers.OrderBy(a => Guid.NewGuid()).ToList();
            questionNumbers = randomList;
        }

        private void GradeManager()
        {
            if (score == 5)
            {
                Grade.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/gradeA.png"));
            }
            else if (score == 4)
            {
                Grade.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/gradeB.png"));
            }
            else if (score == 3)
            {
                Grade.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/gradeD.png"));
            }
            else if (score == 2)
            {
                Grade.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/gradeC.png"));
            }
            else
            {
                Grade.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/gradeF.png"));
            }
        }

        private void GameOver()
        {
            QuizMenu.Visibility = Visibility.Hidden;
            EndGameMenu.Visibility = Visibility.Visible;
            Score.Content = "Your score " + score + "/5";
            GradeManager();
        }

    }
}