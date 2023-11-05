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

namespace Ideal_Weight_Calculator
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

        public int gen1 { get; set; } = 0;
        public int gen2 { get; set; } = 0;

        private void Gen1_Male_Click(object sender, RoutedEventArgs e)
        {
            if(gen1 == 1)
            {
                gen1 = 0;
                gen1_image1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/Checkbox1.png"));
                gen1_image2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/Checkbox2.png"));
            }
        }

        private void Gen1_Female_Click(object sender, RoutedEventArgs e)
        {
            if (gen1 == 0)
            {
                gen1 = 1;
                gen1_image1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/Checkbox2.png"));
                gen1_image2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/Checkbox1.png"));
            }
        }


        private void Calculate_US_Click(object sender, RoutedEventArgs e)
        {
            if (Age_TextBox_US.Text == "" || inches_TextBox.Text == "" || feet_TextBox.Text == "")
            {
                MessageBox.Show("Please enter all the required information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(int.Parse(Age_TextBox_US.Text) < 2 || int.Parse(feet_TextBox.Text) < 4)
            {
                MessageBox.Show("Please enter a valid information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (gen1 == 0)
                {
                    Robinson_Label.Content = (((((int.Parse(feet_TextBox.Text) * 12 + int.Parse(inches_TextBox.Text)) - 60) * 1.9) + 52) * 2.205).ToString("N1") + " lbs";
                    Miller_Label.Content = (((((int.Parse(feet_TextBox.Text) * 12 + int.Parse(inches_TextBox.Text)) - 60) * 1.41) + 56.2) * 2.205).ToString("N1") + " lbs";
                    Devine_Label.Content = (((((int.Parse(feet_TextBox.Text) * 12 + int.Parse(inches_TextBox.Text)) - 60) * 2.3) + 50) * 2.205).ToString("N1") + " lbs";
                    Hamwi_Label.Content = (((((int.Parse(feet_TextBox.Text) * 12 + int.Parse(inches_TextBox.Text)) - 60) * 2.7) + 48) * 2.205).ToString("N1") + " lbs";
                }
                else
                {
                    Robinson_Label.Content = (((((int.Parse(feet_TextBox.Text) * 12 + int.Parse(inches_TextBox.Text)) - 60) * 1.7) + 49) * 2.205).ToString("N1") + " lbs";
                    Miller_Label.Content = (((((int.Parse(feet_TextBox.Text) * 12 + int.Parse(inches_TextBox.Text)) - 60) * 1.36) + 53.1) * 2.205).ToString("N1") + " lbs";
                    Devine_Label.Content = (((((int.Parse(feet_TextBox.Text) * 12 + int.Parse(inches_TextBox.Text)) - 60) * 2.3) + 45.5) * 2.205).ToString("N1") + " lbs";
                    Hamwi_Label.Content = (((((int.Parse(feet_TextBox.Text) * 12 + int.Parse(inches_TextBox.Text)) - 60) * 2.2) + 45.5) * 2.205).ToString("N1") + " lbs";
                }
            }
        }

        private void Clear_US_Click(object sender, RoutedEventArgs e)
        {
            Age_TextBox_US.Text = string.Empty;
            feet_TextBox.Text = string.Empty;
            inches_TextBox.Text = string.Empty;

            Robinson_Label.Content = string.Empty;
            Miller_Label.Content = string.Empty;
            Devine_Label.Content = string.Empty;
            Hamwi_Label.Content = string.Empty;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Gen2_Male_Click(object sender, RoutedEventArgs e)
        {
            if (gen2 == 1)
            {
                gen2 = 0;
                gen2_image1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/Checkbox1.png"));
                gen2_image2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/Checkbox2.png"));
            }
        }

        private void Gen2_Female_Click(object sender, RoutedEventArgs e)
        {
            if (gen2 == 0)
            {
                gen2 = 1;
                gen2_image1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/Checkbox2.png"));
                gen2_image2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/Checkbox1.png"));
            }
        }

        private void Calculate_Metric_Click(object sender, RoutedEventArgs e)
        {
            if (Age_TextBox_Metric.Text == "" || cm_TextBox.Text == "")
            {
                MessageBox.Show("Please enter all the required information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (int.Parse(Age_TextBox_Metric.Text) < 2 || int.Parse(cm_TextBox.Text) < 100)
            {
                MessageBox.Show("Please enter a valid information", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (gen2 == 0)
                {
                    Robinson_Label.Content = (((((int.Parse(cm_TextBox.Text) / 2.54) - 60) * 1.9) + 52)).ToString("N1") + " kg";
                    Miller_Label.Content = (((((int.Parse(cm_TextBox.Text) / 2.54) - 60) * 1.41) + 56.2)).ToString("N1") + " kg";
                    Devine_Label.Content = (((((int.Parse(cm_TextBox.Text) / 2.54) - 60) * 2.3) + 50)).ToString("N1") + " kg";
                    Hamwi_Label.Content = (((((int.Parse(cm_TextBox.Text) / 2.54) - 60) * 2.7) + 48)).ToString("N1") + " kg";
                }
                else
                {
                    Robinson_Label.Content = (((((int.Parse(cm_TextBox.Text) / 2.54) - 60) * 1.7) + 49)).ToString("N1") + " kg";
                    Miller_Label.Content = (((((int.Parse(cm_TextBox.Text) / 2.54) - 60) * 1.36) + 53.1)).ToString("N1") + " kg";
                    Devine_Label.Content = (((((int.Parse(cm_TextBox.Text) / 2.54) - 60) * 2.3) + 45.5)).ToString("N1") + " kg";
                    Hamwi_Label.Content = (((((int.Parse(cm_TextBox.Text) / 2.54) - 60) * 2.2) + 45.5)).ToString("N1") + " kg";
                }
            }
        }

        private void Clear_Metric_Click(object sender, RoutedEventArgs e)
        {
            Age_TextBox_Metric.Text = string.Empty;
            cm_TextBox.Text = string.Empty;

            Robinson_Label.Content = string.Empty;
            Miller_Label.Content = string.Empty;
            Devine_Label.Content = string.Empty;
            Hamwi_Label.Content = string.Empty;
        }
    }
}
