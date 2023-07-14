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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Password_Generator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AlowNumbersChecked = false;
            AlowUppercaseChecked = false;
            AlowLowercaseChecked = false;
            AlowSymbols1Checked = false;
            AlowSymbols2Checked = false;
            ExcludeDuplicatesChecked = false;
            PasswordLenght();
        }

        bool AlowNumbersChecked { get; set; }
        bool AlowUppercaseChecked { get; set; }
        bool AlowLowercaseChecked { get; set; }
        bool AlowSymbols1Checked { get; set; }
        bool AlowSymbols2Checked { get; set; }
        bool ExcludeDuplicatesChecked { get; set; }

        private void PasswordGenerator_click(object sender, RoutedEventArgs e)
        {
            Random character = new Random();
            string allCharacters = "";
            string NumberCharacters = "1234567890";
            string UpperCaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string LowerCaseCharecters = "abcdefghijklmnopqrstuvwxyz";
            string Symbols1 = "!@#%^&$*";
            string Symbols2 = "~`[];?,(){}<>";
            string randomPassword = "";

            if(AlowNumbersChecked == true)
            {
                allCharacters += NumberCharacters;
            }

            if(AlowUppercaseChecked == true)
            {
                allCharacters += UpperCaseCharacters;
            }

            if (AlowLowercaseChecked == true)
            {
                allCharacters += LowerCaseCharecters;
            }

            if (AlowSymbols1Checked == true)
            {
                allCharacters += Symbols1;
            }

            if (AlowSymbols2Checked == true)
            {
                allCharacters += Symbols2;
            }

            if (OtherSymbols.Text != "")
            {
                allCharacters += OtherSymbols.Text;
            }

            if (allCharacters == "")
            {
                GeneratedPassword.Text = "Not enough characters to create a password";
                GeneratedPassword.Foreground = new SolidColorBrush(Colors.LightGray);
                GeneratedPassword.IsReadOnly = true;
            }
            else if(ExcludeDuplicatesChecked == true)
            {
                int count = 0;

                if(allCharacters.Length >= int.Parse(LenghtComboBox.Text))
                {
                    while (count < int.Parse(LenghtComboBox.Text))
                    {
                        int randomNum = character.Next(0, allCharacters.Length);
                        List<char> Duplicates = randomPassword.ToList();
                        if (Duplicates.Contains(allCharacters[randomNum]))
                        {
                            continue;
                        }
                        else
                        {
                            randomPassword += allCharacters[randomNum];
                            count++;
                        }
                    }
                    GeneratedPassword.Foreground = new SolidColorBrush(Colors.Black);
                    GeneratedPassword.Text = randomPassword;
                    GeneratedPassword.IsReadOnly = false;
                    allCharacters = "";
                }
                else
                {
                    for (int i = 0; i < int.Parse(LenghtComboBox.Text); i++)
                    {
                        int randomNum = character.Next(0, allCharacters.Length);
                        randomPassword += allCharacters[randomNum];
                    }
                    GeneratedPassword.Foreground = new SolidColorBrush(Colors.Black);
                    GeneratedPassword.Text = randomPassword;
                    GeneratedPassword.IsReadOnly = false;
                    allCharacters = "";
                }
            }
            else
            {
                for (int i = 0; i < int.Parse(LenghtComboBox.Text); i++)
                {
                    int randomNum = character.Next(0, allCharacters.Length);
                    randomPassword += allCharacters[randomNum];
                }
                GeneratedPassword.Foreground = new SolidColorBrush(Colors.Black);
                GeneratedPassword.Text = randomPassword;
                GeneratedPassword.IsReadOnly = false;
                allCharacters = "";
            }
        }
        private void PasswordLenght()
        {
            DataTable dtLeghts = new DataTable();
            dtLeghts.Columns.Add("Text");

            dtLeghts.Rows.Add("4");
            dtLeghts.Rows.Add("6");
            dtLeghts.Rows.Add("7");
            dtLeghts.Rows.Add("8");
            dtLeghts.Rows.Add("9");
            dtLeghts.Rows.Add("10");
            dtLeghts.Rows.Add("11");
            dtLeghts.Rows.Add("12");
            dtLeghts.Rows.Add("13");
            dtLeghts.Rows.Add("14");
            dtLeghts.Rows.Add("15");
            dtLeghts.Rows.Add("16");


            LenghtComboBox.ItemsSource = dtLeghts.DefaultView;
            LenghtComboBox.DisplayMemberPath = "Text";
            LenghtComboBox.SelectedIndex = 0;
        }

        private void AlowNumbers_Click(object sender, RoutedEventArgs e)
        {
            if(AlowNumbersChecked == false)
            {
                AlowNumbersChecked = true;
                AlowNumbersCheckmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox1.png"));
            }
            else if(AlowNumbersChecked == true)
            {
                AlowNumbersChecked = false;
                AlowNumbersCheckmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox2.png"));
            }
        }

        private void AlowUppercase_Click(object sender, RoutedEventArgs e)
        {
            if (AlowUppercaseChecked == false)
            {
                AlowUppercaseChecked = true;
                AlowUppercaseCheckmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox1.png"));
            }
            else if (AlowUppercaseChecked == true)
            {
                AlowUppercaseChecked = false;
                AlowUppercaseCheckmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox2.png"));
            }
        }

        private void AlowLowercase_Click(object sender, RoutedEventArgs e)
        {
            if (AlowLowercaseChecked == false)
            {
                AlowLowercaseChecked = true;
                AlowLowercaseCheckmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox1.png"));
            }
            else if (AlowLowercaseChecked == true)
            {
                AlowLowercaseChecked = false;
                AlowLowercaseCheckmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox2.png"));
            }
        }

        private void AlowSymbols1_Click(object sender, RoutedEventArgs e)
        {
            if (AlowSymbols1Checked == false)
            {
                AlowSymbols1Checked = true;
                AlowSymbols1Checkmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox1.png"));
            }
            else if (AlowSymbols1Checked == true)
            {
                AlowSymbols1Checked = false;
                AlowSymbols1Checkmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox2.png"));
            }

        }

        private void AlowSymbols2_Click(object sender, RoutedEventArgs e)
        {
            if (AlowSymbols2Checked == false)
            {
                AlowSymbols2Checked = true;
                AlowSymbols2Checkmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox1.png"));
            }
            else if (AlowSymbols2Checked == true)
            {
                AlowSymbols2Checked = false;
                AlowSymbols2Checkmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox2.png"));
            }
        }

        private void ExcludeDuplicates_Click(object sender, RoutedEventArgs e)
        {
            if (ExcludeDuplicatesChecked == false)
            {
                ExcludeDuplicatesChecked = true;
                ExcludeDuplicatesCheckmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox1.png"));
            }
            else if (ExcludeDuplicatesChecked == true)
            {
                ExcludeDuplicatesChecked = false;
                ExcludeDuplicatesCheckmark.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Checkbox2.png"));
            }
        }
    }
}
