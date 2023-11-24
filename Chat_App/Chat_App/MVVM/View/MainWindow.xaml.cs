using Chat_App.MVVM.Core;
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

namespace Chat_App
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

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void FullSreen_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Name_Change(object sender, TextChangedEventArgs e)
        {
            if (Username_TextBox.Text != "")
            {
                Fake_Connect_Button.Visibility = Visibility.Hidden;
            }
            else
            {
                Fake_Connect_Button.Visibility = Visibility.Visible;
            }
        }

        private void Message_Change(object sender, TextChangedEventArgs e)
        {
            if (Message_TextBox.Text != "") 
            {
                Fake_Message_Button.Visibility = Visibility.Hidden;
                Real_Message_Button.Visibility = Visibility.Visible;
            }
            else
            {
                Fake_Message_Button.Visibility = Visibility.Visible;
                Real_Message_Button.Visibility = Visibility.Hidden;
            }
        }
    }
}
