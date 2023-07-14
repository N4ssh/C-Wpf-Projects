using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace Notepad_Clone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Mach = true;
            titleName = "Untitled";
            filePath = "";
            fileContent = "";
            CheckTitleName();

        }

        public string filePath { get; set; }
        public string titleName { get; set; }
        public string fileContent { get; set; }

        public bool Mach { get; set; }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.Add))
            {
                ZoomIn();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.Subtract))
            {
                ZoomOut();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.D0))
            {
                RestoreFontSize();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.O))
            {
                OpenFile();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.N))
            {
                New();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.S))
            {
                Save();
            }
            else if (Keyboard.IsKeyDown(Key.F5))
            {
                MainTextBox.Text = MainTextBox.Text.Insert(MainTextBox.CaretIndex, DateTime.Now.ToString());
            }
            else if(Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.X))
            {
                OpenFind();
            }
        }



        private void Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            ZoomIn();
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            ZoomOut();
        }

        private void RestoreFontSize_Click(object sender, RoutedEventArgs e)
        {
            RestoreFontSize();
        }

        private void Open_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        private void SaveAs_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private void Save_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (MainTextBox.Text != fileContent)
            {
                Mach = false;
            }
            else
            {
                Mach = true;
            }

            EnibleFind();
            Line_Column_Count();
            CheckTitleName();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Mach)
            {
                e.Cancel = true;
                var result = MessageBox.Show("Do you want to save changes to " + titleName + "?", "NoteBook", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                {
                    Save();
                    Environment.Exit(0);
                }
                else if (result == MessageBoxResult.No)
                {
                    Environment.Exit(0);
                }
                else
                {

                }
            }
        }

        private void New_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            New();
        }

        private void NewWindow_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad_Clone");
        }

        private void Undo_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (MainTextBox.CanUndo)
            {
                MainTextBox.Undo();
            }
        }

        private void Cut_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Cut();
        }

        private void Copy_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Copy();
        }

        private void Paste_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Paste();
        }

        private void Delete_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text = MainTextBox.Text.Remove(MainTextBox.SelectionStart, MainTextBox.SelectionLength);
        }

        private void StatusBar_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (StatusBar_MenuItem.IsChecked == true)
            {
                StatusBar.Visibility = Visibility.Visible;
                StatusBar_Rectangle.Visibility = Visibility.Visible;
            }
            else
            {
                StatusBar.Visibility = Visibility.Hidden;
                StatusBar_Rectangle.Visibility = Visibility.Hidden;
            }
        }

        private void SelectAll_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.SelectAll();
        }

        private void TimeDate_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text = MainTextBox.Text.Insert(MainTextBox.CaretIndex, DateTime.Now.ToString());
        }

        private void Fint_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFind();
        }




        //Functionalities...


        private void New()
        {
            if (!Mach)
            {
                var result = MessageBox.Show("Do you want to save changes to " + titleName + "?", "NoteBook", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                {
                    Save();
                    MainTextBox.Text = "";
                    filePath = "";
                    fileContent = "";
                    titleName = "Untitled";
                }
                else if (result == MessageBoxResult.No)
                {
                    MainTextBox.Text = "";
                    filePath = "";
                    fileContent = "";
                    titleName = "Untitled";
                    Mach = true;
                }
                else
                {

                }
            }

            else
            {
                MainTextBox.Text = "";
                filePath = "";
                fileContent = "";
                titleName = "Untitled";
                Mach = true;
            }

            CheckTitleName();
        }

        private void RestoreFontSize()
        {
            MainTextBox.FontSize = 16;
            ZoomPercentage.Text = "100%";
        }

        private void ZoomIn()
        {
            MainTextBox.FontSize += 2;
            string zoom = ZoomPercentage.Text.Remove(ZoomPercentage.Text.Length - 1);
            int percentage = int.Parse(zoom) + 10;
            ZoomPercentage.Text = percentage.ToString() + "%";
        }

        private void ZoomOut()
        {
            MainTextBox.FontSize -= 2;
            string zoom = ZoomPercentage.Text.Remove(ZoomPercentage.Text.Length - 1);
            int percentage = int.Parse(zoom) - 10;
            ZoomPercentage.Text = percentage.ToString() + "%";
        }

        private void OpenFile()
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.ShowDialog();
            string savetitle = titleName;

            try
            {
                filePath = fileOpen.FileName;
                titleName = fileOpen.SafeFileName;
                Mach = true;

                StreamReader fileReader = new StreamReader(filePath);
                fileContent = fileReader.ReadToEnd();
                MainTextBox.Text = fileContent;
                fileReader.Close();
            }
            catch
            {
                titleName = savetitle;
            }
        }

        private void CheckTitleName()
        {
            if (Mach)
            {
                Title = titleName + " - " + "NoteBook";
            }
            else
            {
                Title = "*" + titleName + " - " + "NoteBook";
            }
        }

        private void Save()
        {
            if (filePath != "")
            {
                StreamWriter fileWriter = new StreamWriter(filePath);
                fileContent = MainTextBox.Text;
                fileWriter.Write(fileContent);
                fileWriter.Close();
                Mach = true;
            }
            else
            {
                titleName = "Untitled";
                SaveAs();
            }
        }

        private void SaveAs()
        {
            SaveFileDialog fileSave = new SaveFileDialog();
            fileSave.Filter = "Text File (.txt)|*.txt|All *.*|(*.*)";
            fileSave.ShowDialog();

            if (fileSave.FileName != "")
            {
                filePath = fileSave.FileName;
                StreamWriter fileWriter = new StreamWriter(filePath);
                fileContent = MainTextBox.Text;
                fileWriter.Write(fileContent);
                fileWriter.Close();
                Mach = true;
            }

            CheckTitleName();
        }

        private void WordWrap_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (WordWrap_MenuItem.IsChecked == true)
            {
                MainTextBox.TextWrapping = TextWrapping.Wrap;
            }
            else
            {
                MainTextBox.TextWrapping = TextWrapping.NoWrap;
            }
        }

        private void Font_MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Line_Column_Count()
        {

                int index = MainTextBox.SelectionStart;
                int Columns = 1 + MainTextBox.GetLineIndexFromCharacterIndex(index);
                int Line = 1 + MainTextBox.SelectionStart - MainTextBox.GetFirstVisibleLineIndex();
                ColumCount.Text = Columns.ToString();
                LineCount.Text = Line.ToString();
        }

        private void EnibleFind()
        {
            if(MainTextBox.Text != "")
            {
                Find_MenuItem.IsEnabled = true;
            }
            else
            {
                Find_MenuItem.IsEnabled = false;
            }
        }

        private void OpenFind()
        {
            FindForm findForm = new FindForm();
            findForm.ShowDialog();
        }
    }
}
