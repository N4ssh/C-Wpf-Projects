using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.IO;
using System.Windows.Threading;

namespace Basic_Audio_Recorder
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

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string ipstrCommand, string ipstrReturnString, int uReturnLenth, int hwndCallback);

        System.Media.SoundPlayer player = new System.Media.SoundPlayer("mic.wav");
        DispatcherTimer disTick = new DispatcherTimer();
        public int secondsCount { get; set; } = 0;

        bool running {  get; set; } = false;
        bool recording { get; set; } = false;



        private void Record_Click(object sender, RoutedEventArgs e)
        {
            if(recording == false)
            {
                record("open new Type waveaudio Alias recSound", "", 0, 0);
                record("record recsound", "", 0, 0);

                running = true;
                recording = true;
                secondsCount = 0;
                Timer();

                LabelTimer.Content = "0";
                LabelTimer.Visibility = Visibility.Visible;
                RecordingPanel.Visibility = Visibility.Visible;
                PlayMenu.Visibility = Visibility.Hidden;
                Record_Button_Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/stopRec.png"));
            }
            else
            {
                disTick.Tick -= new EventHandler(disTick_Tick);
                PlayMenu.Visibility = Visibility.Visible;

                record("save recsound mic.wav", "", 0, 0);
                record("close recsound", "", 0, 0);

                running = false;
                recording = false;
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
            if(running == true)
            {
                secondsCount++;
                LabelTimer.Content = secondsCount.ToString();
            }
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            if(running == true)
            {
                record("pause recsound", "", 0, 0);
                running = false;
                Pause_Button_Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/start.png"));
            }
            else
            {
                record("resume recsound", "", 0, 0);
                running = true;
                Pause_Button_Image.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Pictures/pause.png"));
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            player.Play();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileSave = new SaveFileDialog();
            fileSave.Filter = "WAV File (.wav)|*.wav|All *.*|(*.*)";
            fileSave.ShowDialog();

            if (fileSave.FileName != "")
            {
                string filePath = fileSave.FileName;
                File.Copy("mic.wav", filePath);
            }
        }

        private void Nothing_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button does not do anything", "Ligma", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
    }
}
