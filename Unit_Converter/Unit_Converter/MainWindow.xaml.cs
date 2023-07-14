using System;
using System.Collections.Generic;
using System.Data;
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

namespace Unit_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Units_Temperature();
            Units_Pressure();
            Units_Length();
            Units_Volume();
        }

        private void Convert_Temperature_Click(object sender, RoutedEventArgs e)
        {
            double ConvertedValue;

            try
            {
                if (txtUnits_Temperature == null || txtUnits_Temperature.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a valid value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    txtUnits_Temperature.Focus();
                    return;
                }

                else if (cmbFromUnits_Temperature == null || cmbFromUnits_Temperature.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select units to convert from!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    cmbFromUnits_Temperature.Focus();
                    return;
                }

                else if (cmbToUnits_Temperature == null || cmbToUnits_Temperature.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select units to convert to!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    cmbToUnits_Temperature.Focus();
                    return;
                }

                else if (cmbFromUnits_Temperature.Text == cmbToUnits_Temperature.Text)
                {
                    ConvertedValue = double.Parse(txtUnits_Temperature.Text);

                    lblUnits_Temperature.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Temperature.Text;

                }

                else if (cmbFromUnits_Temperature.SelectedIndex == 1 && cmbToUnits_Temperature.SelectedIndex == 2)
                {
                    ConvertedValue = double.Parse(txtUnits_Temperature.Text) + 273.15;

                    lblUnits_Temperature.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Temperature.Text;
                }

                else if (cmbFromUnits_Temperature.SelectedIndex == 2 && cmbToUnits_Temperature.SelectedIndex == 1)
                {
                    ConvertedValue = double.Parse(txtUnits_Temperature.Text) - 273.15;

                    lblUnits_Temperature.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Temperature.Text;
                }
                else if (cmbFromUnits_Temperature.SelectedIndex == 1 && cmbToUnits_Temperature.SelectedIndex == 3)
                {
                    ConvertedValue = (double.Parse(txtUnits_Temperature.Text) * 9 / 5) + 32;

                    lblUnits_Temperature.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Temperature.Text;
                }
                else if (cmbFromUnits_Temperature.SelectedIndex == 2 && cmbToUnits_Temperature.SelectedIndex == 3)
                {
                    ConvertedValue = ((double.Parse(txtUnits_Temperature.Text) - 273.15) * 9 / 5) + 32;

                    lblUnits_Temperature.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Temperature.Text;
                }
                else if (cmbFromUnits_Temperature.SelectedIndex == 3 && cmbToUnits_Temperature.SelectedIndex == 1)
                {
                    ConvertedValue = ((double.Parse(txtUnits_Temperature.Text) - 32) * 5 / 9);

                    lblUnits_Temperature.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Temperature.Text;
                }
                else if (cmbFromUnits_Temperature.SelectedIndex == 3 && cmbToUnits_Temperature.SelectedIndex == 2)
                {
                    ConvertedValue = ((double.Parse(txtUnits_Temperature.Text) - 32) * 5 / 9) + 273.15;

                    lblUnits_Temperature.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Temperature.Text;
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void Clear_Temperature_Click(object sender, RoutedEventArgs e)
        {
            lblUnits_Temperature.Content = "";
            txtUnits_Temperature.Text = string.Empty;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9\\-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void Units_Temperature()
        {
            DataTable dtUnits = new DataTable();
            dtUnits.Columns.Add("Text");

            dtUnits.Rows.Add("--Select--");
            dtUnits.Rows.Add("Celsius");
            dtUnits.Rows.Add("Kelvin");
            dtUnits.Rows.Add("Fahrenheit");



            cmbFromUnits_Temperature.ItemsSource = dtUnits.DefaultView;
            cmbFromUnits_Temperature.DisplayMemberPath = "Text";
            cmbFromUnits_Temperature.SelectedIndex = 0;

            cmbToUnits_Temperature.ItemsSource = dtUnits.DefaultView;
            cmbToUnits_Temperature.DisplayMemberPath = "Text";
            cmbToUnits_Temperature.SelectedIndex = 0;
        }

        private void Convert_Pressure_Click(object sender, RoutedEventArgs e)
        {
            double ConvertedValue;

            try
            {
                if (txtUnits_Pressure == null || txtUnits_Pressure.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a valid value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    txtUnits_Pressure.Focus();
                    return;
                }

                else if (cmbFromUnits_Pressure == null || cmbFromUnits_Pressure.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select units to convert from!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    cmbFromUnits_Pressure.Focus();
                    return;
                }

                else if (cmbToUnits_Pressure == null || cmbToUnits_Pressure.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select units to convert to!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    cmbToUnits_Pressure.Focus();
                    return;
                }

                else if (cmbFromUnits_Pressure.Text == cmbToUnits_Pressure.Text)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text);

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Pressure.Text;

                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 1 && cmbToUnits_Pressure.SelectedIndex == 2)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) / 133.3;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 1 && cmbToUnits_Pressure.SelectedIndex == 3)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) / 101300;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N6") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 1 && cmbToUnits_Pressure.SelectedIndex == 4)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) / 100000;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N6") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 2 && cmbToUnits_Pressure.SelectedIndex == 1)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) * 133.3;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 2 && cmbToUnits_Pressure.SelectedIndex == 3)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) / 760;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N5") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 2 && cmbToUnits_Pressure.SelectedIndex == 4)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) / 750.1;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N5") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 3 && cmbToUnits_Pressure.SelectedIndex == 1)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) * 101300;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 3 && cmbToUnits_Pressure.SelectedIndex == 2)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) * 760;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 3 && cmbToUnits_Pressure.SelectedIndex == 4)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) * 1.013;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 4 && cmbToUnits_Pressure.SelectedIndex == 1)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) * 100000;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 4 && cmbToUnits_Pressure.SelectedIndex == 2)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) * 750.1;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Pressure.Text;
                }

                else if (cmbFromUnits_Pressure.SelectedIndex == 4 && cmbToUnits_Pressure.SelectedIndex == 3)
                {
                    ConvertedValue = double.Parse(txtUnits_Pressure.Text) / 1.013;

                    lblUnits_Pressure.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Pressure.Text;
                }

            }
            catch
            {
                MessageBox.Show("Please enter a valid value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Clear_Pressure_Click(object sender, RoutedEventArgs e)
        {
            lblUnits_Pressure.Content = "";
            txtUnits_Pressure.Text = string.Empty;
        }

        public void Units_Pressure()
        {
            DataTable dtUnits = new DataTable();
            dtUnits.Columns.Add("Text");

            dtUnits.Rows.Add("--Select--");
            dtUnits.Rows.Add("Pa");
            dtUnits.Rows.Add("torr");
            dtUnits.Rows.Add("atm");
            dtUnits.Rows.Add("bar");



            cmbFromUnits_Pressure.ItemsSource = dtUnits.DefaultView;
            cmbFromUnits_Pressure.DisplayMemberPath = "Text";
            cmbFromUnits_Pressure.SelectedIndex = 0;

            cmbToUnits_Pressure.ItemsSource = dtUnits.DefaultView;
            cmbToUnits_Pressure.DisplayMemberPath = "Text";
            cmbToUnits_Pressure.SelectedIndex = 0;
        }

        private void Clear_Length_Click(object sender, RoutedEventArgs e)
        {
            lblUnits_Length.Content = "";
            txtUnits_Length.Text = string.Empty;
        }

        private void Convert_Length_Click(object sender, RoutedEventArgs e)
        {
            double ConvertedValue;

            try
            {
                if (txtUnits_Length == null || txtUnits_Length.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a valid value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    txtUnits_Length.Focus();
                    return;
                }

                else if (cmbFromUnits_Length == null || cmbFromUnits_Length.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select units to convert from!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    cmbFromUnits_Length.Focus();
                    return;
                }

                else if (cmbToUnits_Length == null || cmbToUnits_Length.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select units to convert to!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    cmbToUnits_Length.Focus();
                    return;
                }

                else if (cmbFromUnits_Length.Text == cmbToUnits_Length.Text)
                {
                    ConvertedValue = double.Parse(txtUnits_Length.Text);

                    lblUnits_Length.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Length.Text;

                }

                else if (cmbFromUnits_Length.SelectedIndex == 1 && cmbToUnits_Length.SelectedIndex == 2)
                {
                    ConvertedValue = double.Parse(txtUnits_Length.Text) * 3.281;

                    lblUnits_Length.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Length.Text;
                }

                else if (cmbFromUnits_Length.SelectedIndex == 1 && cmbToUnits_Length.SelectedIndex == 3)
                {
                    ConvertedValue = double.Parse(txtUnits_Length.Text) * 39.37;

                    lblUnits_Length.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Length.Text;
                }

                else if (cmbFromUnits_Length.SelectedIndex == 2 && cmbToUnits_Length.SelectedIndex == 1)
                {
                    ConvertedValue = double.Parse(txtUnits_Length.Text) / 3.281;

                    lblUnits_Length.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Length.Text;
                }

                else if (cmbFromUnits_Length.SelectedIndex == 2 && cmbToUnits_Length.SelectedIndex == 3)
                {
                    ConvertedValue = double.Parse(txtUnits_Length.Text) * 12;

                    lblUnits_Length.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Length.Text;
                }

                else if (cmbFromUnits_Length.SelectedIndex == 3 && cmbToUnits_Length.SelectedIndex == 1)
                {
                    ConvertedValue = double.Parse(txtUnits_Length.Text) / 39.37;

                    lblUnits_Length.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Length.Text;
                }

                else if (cmbFromUnits_Length.SelectedIndex == 3 && cmbToUnits_Length.SelectedIndex == 2)
                {
                    ConvertedValue = double.Parse(txtUnits_Length.Text) / 12;

                    lblUnits_Length.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Length.Text;
                }

            }
            catch
            {
                MessageBox.Show("Please enter a valid value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public void Units_Length()
        {
            DataTable dtUnits = new DataTable();
            dtUnits.Columns.Add("Text");

            dtUnits.Rows.Add("--Select--");
            dtUnits.Rows.Add("Meters");
            dtUnits.Rows.Add("Feet");
            dtUnits.Rows.Add("Inches");



            cmbFromUnits_Length.ItemsSource = dtUnits.DefaultView;
            cmbFromUnits_Length.DisplayMemberPath = "Text";
            cmbFromUnits_Length.SelectedIndex = 0;

            cmbToUnits_Length.ItemsSource = dtUnits.DefaultView;
            cmbToUnits_Length.DisplayMemberPath = "Text";
            cmbToUnits_Length.SelectedIndex = 0;
        }

        private void Convert_Volume_Click(object sender, RoutedEventArgs e)
        {
            double ConvertedValue;

            try
            {
                if (txtUnits_Volume == null || txtUnits_Volume.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a valid value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    txtUnits_Volume.Focus();
                    return;
                }

                else if (cmbFromUnits_Volume == null || cmbFromUnits_Volume.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select units to convert from!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    cmbFromUnits_Volume.Focus();
                    return;
                }

                else if (cmbToUnits_Volume == null || cmbToUnits_Volume.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select units to convert to!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    cmbToUnits_Volume.Focus();
                    return;
                }

                else if (cmbFromUnits_Volume.Text == cmbToUnits_Volume.Text)
                {
                    ConvertedValue = double.Parse(txtUnits_Volume.Text);

                    lblUnits_Volume.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Volume.Text;

                }

                else if (cmbFromUnits_Volume.SelectedIndex == 1 && cmbToUnits_Volume.SelectedIndex == 2)
                {
                    ConvertedValue = double.Parse(txtUnits_Volume.Text) * 1000;

                    lblUnits_Volume.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Volume.Text;
                }

                else if (cmbFromUnits_Volume.SelectedIndex == 2 && cmbToUnits_Volume.SelectedIndex == 1)
                {
                    ConvertedValue = double.Parse(txtUnits_Volume.Text) / 1000;

                    lblUnits_Volume.Content = ConvertedValue.ToString("N3") + " " + cmbToUnits_Volume.Text;
                }

            }

            catch
            {
                MessageBox.Show("Please enter a valid value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Clear_Volume_Click(object sender, RoutedEventArgs e)
        {
            lblUnits_Volume.Content = "";
            txtUnits_Volume.Text = string.Empty;
        }

        public void Units_Volume()
        {
            DataTable dtUnits = new DataTable();
            dtUnits.Columns.Add("Text");

            dtUnits.Rows.Add("--Select--");
            dtUnits.Rows.Add("Cubic metres");
            dtUnits.Rows.Add("Liters");



            cmbFromUnits_Volume.ItemsSource = dtUnits.DefaultView;
            cmbFromUnits_Volume.DisplayMemberPath = "Text";
            cmbFromUnits_Volume.SelectedIndex = 0;

            cmbToUnits_Volume.ItemsSource = dtUnits.DefaultView;
            cmbToUnits_Volume.DisplayMemberPath = "Text";
            cmbToUnits_Volume.SelectedIndex = 0;
        }
    }
}
