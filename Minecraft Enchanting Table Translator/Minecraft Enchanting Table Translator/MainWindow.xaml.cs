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

namespace Minecraft_Enchanting_Table_Translator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title_TextBlock.Text = "MINECRAFT ENCHANTMENT TABLE TO \n ENGLISH";
        }

        bool LanguageMode { get; set; } = true;

        private void TextChanged_English(object sender, TextChangedEventArgs e)
        {
            if(LanguageMode == true)
            {
                string En = English.Text.ToLower();
                string Et = "";

                Dictionary<char, string> EnchantmentTableDictionary = new Dictionary<char, string>()
            {
                {'a',"ᔑ"},
                {'b',"ʖ"},
                {'c',"ᓵ"},
                {'d',"↸"},
                {'e',"ᒷ"},
                {'f',"⎓"},
                {'g',"⊣"},
                {'h',"⍑"},
                {'i',"╎"},
                {'j',"⋮"},
                {'k',"ꖌ"},
                {'l',"ꖎ"},
                {'m',"ᒲ"},
                {'n',"リ"},
                {'o',"𝙹"},
                {'p',"!¡"},
                {'q',"ᑑ"},
                {'r',"∷"},
                {'s',"ᓭ"},
                {'t',"ℸ."},
                {'u',"⚍"},
                {'v',"⍊"},
                {'w',"∴"},
                {'x',"'/"},
                {'y',"||"},
                {'z',"⨅"},
            };

                for (int i = 0; i < En.Length; i++)
                {
                    if (EnchantmentTableDictionary.ContainsKey(En[i]) == true)
                    {
                        Et += EnchantmentTableDictionary[En[i]];
                    }
                    else
                    {
                        Et += En[i];
                    }
                }

                EnchantingTable.Text = Et;
            }
            else
            {
                string En = English.Text;
                string Et = "";

                Dictionary<string, char> EnglishDictionary = new Dictionary<string, char>()
            {
                {"ᔑ",'a'},
                {"ʖ",'b'},
                {"ᓵ",'c'},
                {"↸",'d'},
                {"ᒷ",'e'},
                {"⎓",'f'},
                {"⊣",'g'},
                {"⍑",'h'},
                {"╎",'i'},
                {"⋮",'j'},
                {"ꖌ",'k'},
                {"ꖎ",'l'},
                {"ᒲ",'m'},
                {"リ",'n'},
                {"𝙹",'o'},
                {"!¡",'p'},
                {"ᑑ",'q'},
                {"∷",'r'},
                {"ᓭ",'s'},
                {"ℸ.",'t'},
                {"⚍",'u'},
                {"⍊",'v'},
                {"∴",'w'},
                {"'/",'x'},
                {"||",'y'},
                {"⨅",'z'},
            };

                for (int i = 0; i < En.Length; i++)
                {
                    if (EnglishDictionary.ContainsKey(En[i].ToString()) == true)
                    {
                        Et += EnglishDictionary[En[i].ToString()];
                    }
                    else if (i + 1 < En.Length)
                    {
                        if(EnglishDictionary.ContainsKey(En[i].ToString() + En[i + 1].ToString()) == true)
                        {
                            Et += EnglishDictionary[En[i].ToString() + En[i + 1].ToString()];
                            i++;
                        }
                        else
                        {
                            Et += En[i];
                        }
                    }
                    else
                    {
                        Et += En[i];
                    }
                }

                EnchantingTable.Text = Et;
            }
        }

        private void GenerateRandomSentence_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<int, string> RandomSentenceDictionary = new Dictionary<int, string>()
            {
                {1,"Try Finger"},
                {2,"Every 60 Seconds In Africa, A Minute Passes.."},
                {3,"Insert Something Here!"},
                {4,"Amogus Sussus Amogus"},
            };

            Random rnd = new Random();
            int sentence = rnd.Next(1, 5);
            English.Text = RandomSentenceDictionary[sentence];
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            if (LanguageMode == true)
            {
                label1.Content = "EnchantingTable";
                label2.Content = "English";
                LanguageMode = false;
            }
            else
            {
                label1.Content = "English";
                label2.Content = "EnchantingTable";
                LanguageMode = true;
            }
        }
    }
}
