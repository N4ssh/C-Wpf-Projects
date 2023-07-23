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

namespace Ohms_Law
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

        public double Resistance { get; set; } = 500;
        public double Voltage { get; set; } = 4.5;
        public double Current { get; set; }

        private void Voltage_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Voltage = Voltage_Slider.Value;
            Current = (Voltage / Resistance) * 1000;
            Current_TextBlock.Text = "current  =   " + Current.ToString("N1") + " mA";
        }

        private void Resistance_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Resistance = Resistance_Slider.Value;
            Current = (Voltage / Resistance) * 1000;
            Current_TextBlock.Text = "current  =   " + Current.ToString("N1") + " mA";
        }

        private void Reset_Values(object sender, RoutedEventArgs e)
        {
            Resistance_Slider.Value = 500;
            Voltage_Slider.Value = 4.5;
        }
    }
}
