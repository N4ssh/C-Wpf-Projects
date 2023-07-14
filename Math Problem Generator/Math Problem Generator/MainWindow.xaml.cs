using System;
using System.Collections.Generic;
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

namespace Math_Problem_Generator
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

        public int randomNumber1 { get; set; }
        public int randomNumber2 { get; set; }
        public int randomWording { get; set; }
        public int score { get; set; }
        public int QuestionNumber { get; set; }

        public int Mode { get; set; }

        private void Addition_click(object sender, RoutedEventArgs e)
        {
            QuestionsMenu.Visibility = Visibility.Visible;
            Mode = 1;
            QuestionNumber = 1;
            score = 0;
            RandomNumberManager_Add();
            QuestionLableManager_Add();
            QuestionCount.Content = "QUESTION " + QuestionNumber;
            ScoreLabel.Content = "Score: " + score;
            AnswerTextbox.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9\\-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Answer_click(object sender, RoutedEventArgs e)
        {
            Answer();
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            PlayAgain();
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            Done();
        }

        private void Multiplication_click(object sender, RoutedEventArgs e)
        {
            QuestionsMenu.Visibility = Visibility.Visible;
            Mode = 2;
            QuestionNumber = 1;
            score = 0;
            RandomNumberManager_Multiply();
            QuestionLableManager_Multiply();
            QuestionCount.Content = "QUESTION " + QuestionNumber;
            ScoreLabel.Content = "Score: " + score;
            AnswerTextbox.Text = "";
        }

        private void RandomNumberManager_Multiply()
        {
            Random rnd = new Random();
            randomNumber1 = rnd.Next(0, 11);
            randomNumber2 = rnd.Next(0, 21);
            randomWording = rnd.Next(1, 3);
        }

        private void QuestionLableManager_Multiply()
        {
            if (randomWording == 1)
            {
                QuestionLabel.Content = randomNumber1 + "x" + randomNumber2 + "=?";
            }
            else
            {
                QuestionLabel.Content = "Multiply: " + randomNumber1 + "x" + randomNumber2;
            }
        }


        private void RandomNumberManager_Add()
        {
            Random rnd = new Random();
            randomNumber1 = rnd.Next(-1, 100);
            randomNumber2 = rnd.Next(-1, 100);
            randomWording = rnd.Next(1, 3);
        }

        private void QuestionLableManager_Add()
        {
            if (randomWording == 1)
            {
                QuestionLabel.Content = randomNumber1 + "+" + randomNumber2 + "=?";
            }
            else
            {
                QuestionLabel.Content = "What is " + randomNumber1 + " plus " + randomNumber2 + "?";
            }
        }


        private void RandomNumberManager_Subtract()
        {
            Random rnd = new Random();
            randomNumber1 = rnd.Next(-1, 100);
            randomNumber2 = rnd.Next(-1, 100);
            randomWording = rnd.Next(1, 3);
        }

        private void QuestionLableManager_Subtract()
        {
            if (randomWording == 3)
            {
                QuestionLabel.Content = randomNumber1 + "-" + randomNumber2 + "=?";
            }
            else
            {
                QuestionLabel.Content = "What is " + randomNumber1 + " minus " + randomNumber2 + "?";
            }
        }

        private void Subtraction_click(object sender, RoutedEventArgs e)
        {
            QuestionsMenu.Visibility = Visibility.Visible;
            Mode = 3;
            QuestionNumber = 1;
            score = 0;
            RandomNumberManager_Subtract();
            QuestionLableManager_Subtract();
            QuestionCount.Content = "QUESTION " + QuestionNumber;
            ScoreLabel.Content = "Score: " + score;
            AnswerTextbox.Text = "";
        }

        private void Division_click(object sender, RoutedEventArgs e)
        {
            QuestionsMenu.Visibility = Visibility.Visible;
            Mode = 4;
            QuestionNumber = 1;
            score = 0;
            RandomNumberManager_Divide();
            QuestionLableManager_Divide();
            QuestionCount.Content = "QUESTION " + QuestionNumber;
            ScoreLabel.Content = "Score: " + score;
            AnswerTextbox.Text = "";
        }


        private void RandomNumberManager_Divide()
        {
            Random rnd = new Random();
            randomNumber2 = rnd.Next(1, 10);
            int temp = (rnd.Next(-20, 20));
            randomNumber1 = temp*randomNumber2;
            randomWording = rnd.Next(1, 3);
        }

        private void QuestionLableManager_Divide()
        {
            if (randomWording == 3)
            {
                QuestionLabel.Content = randomNumber1 + "÷" + randomNumber2 + "=?";
            }
            else
            {
                QuestionLabel.Content = "What is " + randomNumber1 + " divided by " + randomNumber2 + "?";
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(QuestionsMenu.Visibility == Visibility.Visible && Keyboard.IsKeyDown(Key.Enter) && EndGameMenu.Visibility == Visibility.Hidden)
            {
                Answer();
            }
            else if (EndGameMenu.Visibility == Visibility.Visible && Keyboard.IsKeyDown(Key.Enter))
            {
                PlayAgain();
            }
            else if (EndGameMenu.Visibility == Visibility.Visible && Keyboard.IsKeyDown(Key.Escape))
            {
                Done();
            }
            else if(QuestionsMenu.Visibility == Visibility.Visible && Keyboard.IsKeyDown(Key.Escape) && EndGameMenu.Visibility == Visibility.Hidden)
            {
                EndScore.Content = "Score: " + score;
                EndGameMenu.Visibility = Visibility.Visible;
            }
        }

        private void Answer()
        {
            if (Mode == 1)
            {
                if (AnswerTextbox.Text != "")
                {
                    try
                    {
                        if (randomNumber1 + randomNumber2 == int.Parse(AnswerTextbox.Text))
                        {
                            score++;
                            ScoreLabel.Content = "Score: " + score;
                            AnswerTextbox.Text = "";
                            RandomNumberManager_Add();
                            QuestionLableManager_Add();
                            QuestionNumber++;
                            QuestionCount.Content = "QUESTION " + QuestionNumber;
                        }
                        else
                        {
                            EndScore.Content = "Score: " + score;
                            EndGameMenu.Visibility = Visibility.Visible;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill the Box!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else if (Mode == 2)
            {
                if (AnswerTextbox.Text != "")
                {
                    try
                    {
                        if (randomNumber1 * randomNumber2 == int.Parse(AnswerTextbox.Text))
                        {
                            score++;
                            ScoreLabel.Content = "Score: " + score;
                            AnswerTextbox.Text = "";
                            RandomNumberManager_Multiply();
                            QuestionLableManager_Multiply();
                            QuestionNumber++;
                            QuestionCount.Content = "QUESTION " + QuestionNumber;
                        }
                        else
                        {
                            EndScore.Content = "Score: " + score;
                            EndGameMenu.Visibility = Visibility.Visible;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill the Box!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else if (Mode == 3)
            {
                if (AnswerTextbox.Text != "")
                {
                    try
                    {
                        if (randomNumber1 - randomNumber2 == int.Parse(AnswerTextbox.Text))
                        {
                            score++;
                            ScoreLabel.Content = "Score: " + score;
                            AnswerTextbox.Text = "";
                            RandomNumberManager_Subtract();
                            QuestionLableManager_Subtract();
                            QuestionNumber++;
                            QuestionCount.Content = "QUESTION " + QuestionNumber;
                        }
                        else
                        {
                            EndScore.Content = "Score: " + score;
                            EndGameMenu.Visibility = Visibility.Visible;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill the Box!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else if (Mode == 4)
            {
                if (AnswerTextbox.Text != "")
                {
                    try
                    {
                        if (randomNumber1 / randomNumber2 == int.Parse(AnswerTextbox.Text))
                        {
                            score++;
                            ScoreLabel.Content = "Score: " + score;
                            AnswerTextbox.Text = "";
                            RandomNumberManager_Divide();
                            QuestionLableManager_Divide();
                            QuestionNumber++;
                            QuestionCount.Content = "QUESTION " + QuestionNumber;
                        }
                        else
                        {
                            EndScore.Content = "Score: " + score;
                            EndGameMenu.Visibility = Visibility.Visible;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please fill the Box!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
        private void PlayAgain()
        {
            if (Mode == 1)
            {
                score = 0;
                ScoreLabel.Content = "Score: " + score;
                AnswerTextbox.Text = "";
                RandomNumberManager_Add();
                QuestionLableManager_Add();
                QuestionNumber = 1;
                QuestionCount.Content = "QUESTION " + QuestionNumber;
                EndGameMenu.Visibility = Visibility.Hidden;
            }
            else if (Mode == 2)
            {
                score = 0;
                ScoreLabel.Content = "Score: " + score;
                AnswerTextbox.Text = "";
                RandomNumberManager_Multiply();
                QuestionLableManager_Multiply();
                QuestionNumber = 1;
                QuestionCount.Content = "QUESTION " + QuestionNumber;
                EndGameMenu.Visibility = Visibility.Hidden;
            }
            else if (Mode == 3)
            {
                score = 0;
                ScoreLabel.Content = "Score: " + score;
                AnswerTextbox.Text = "";
                RandomNumberManager_Subtract();
                QuestionLableManager_Subtract();
                QuestionNumber = 1;
                QuestionCount.Content = "QUESTION " + QuestionNumber;
                EndGameMenu.Visibility = Visibility.Hidden;
            }
            else if (Mode == 4)
            {
                score = 0;
                ScoreLabel.Content = "Score: " + score;
                AnswerTextbox.Text = "";
                RandomNumberManager_Divide();
                QuestionLableManager_Divide();
                QuestionNumber = 1;
                QuestionCount.Content = "QUESTION " + QuestionNumber;
                EndGameMenu.Visibility = Visibility.Hidden;
            }
        }

        private void Done()
        {
            QuestionsMenu.Visibility = Visibility.Hidden;
            EndGameMenu.Visibility = Visibility.Hidden;
        }
    }
}
