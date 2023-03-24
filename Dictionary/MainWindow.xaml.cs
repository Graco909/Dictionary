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

namespace Dictionary
{
    //<summary>
    //Interaction logic for MainWindow.xaml
    //</summary>
    public partial class MainWindow : Window
    {
        SqlConnector connector;

        List<Word_class> AllWordsList = new List<Word_class>();
        List<Word_class> searchedWordsList = new List<Word_class>();
        List<Word_class> TranslatedWordsList = new List<Word_class>();
        List<Word_class> AllWords2langList = new List<Word_class>();

        List<translation_class> TranslationList = new List<translation_class>();

        Word_class temp = new Word_class();
        Word_class selectedItem;
        string searched_word = "";
        bool lang_selected = true; // true - polski false - angilski jako język z którego się tłumaczy
        public MainWindow()
        {
            InitializeComponent();

            connector = new SqlConnector();
            TranslationList = connector.Get_Translation_List();

            if (lang_selected)
            {
                AllWordsList = connector.GetPerson_All();
                AllWords2langList = connector.GetPerson_All_eng();
            }
            else
            {
                AllWords2langList = connector.GetPerson_All();
                AllWordsList = connector.GetPerson_All_eng();
            }

            matchingWords.ItemsSource = AllWordsList;
        }




        private void search_bar_TextChanged(object sender, TextChangedEventArgs e) //wyszukiwanie słów 
        {
            searched_word = search_bar.Text.ToString();

            matchingWords.ItemsSource = AllWordsList;
            searchedWordsList.Clear();

            foreach (Word_class word in AllWordsList)
            {
                if (word.Word.Contains(searched_word) || (word.Description.Contains(searched_word)))
                {
                    searchedWordsList.Add(word);
                }
            }
            matchingWords.ItemsSource = searchedWordsList;
        }




        private void matchingWords_SelectionChanged(object sender, SelectionChangedEventArgs e) // znajdowanie dopasowanych przetłumaczonych słów
        {
            try
            {
                selectedItem = (Word_class)matchingWords.Items.GetItemAt(matchingWords.SelectedIndex);  // zrobić tak ęzby przy zmianie wyszukiwania niewywalało programu bez użyczia tego try / catch
                translated_words.ItemsSource = AllWords2langList;
                TranslatedWordsList.Clear();
                foreach (translation_class trans in TranslationList)
                {
                    if (lang_selected)
                    {
                        if (trans.Pl_Word_Id == selectedItem.Id)
                        {

                            temp = (Word_class)AllWords2langList.Find(x => x.Id == trans.Eng_Word_Id);
                            TranslatedWordsList.Add(temp);
                        }
                    }
                    else
                    {
                        if (trans.Eng_Word_Id == selectedItem.Id)
                        {

                            temp = (Word_class)AllWords2langList.Find(x => x.Id == trans.Pl_Word_Id);
                            TranslatedWordsList.Add(temp);
                        }

                    }
                }
                translated_words.ItemsSource = TranslatedWordsList;
                selected_word_and_desc.Content = selectedItem.Word;
            }
            catch { }
        }



        private void Button_Click(object sender, RoutedEventArgs e) //guzik do zmiany języka z turego i na ktury się tłumaczy 
        {
            if (!lang_selected)
            {
                ImgP.Source = new BitmapImage(new Uri("./../../Eng_flag.png", UriKind.Relative));
                ImgL.Source = new BitmapImage(new Uri("./../../Pl_flag.png", UriKind.Relative));

                AllWordsList = connector.GetPerson_All();
                AllWords2langList = connector.GetPerson_All_eng();// można użyć zamiany list zamiast sczytywania z bazy ale tak jest prosciej i bezpieczniej ale niekoniecznie szybciej

                search_bar_label.Content = "Wyszukaj słowo:";
                lang_switch.Content = "Zmiana Języka";
            }
            else
            {
                AllWords2langList = connector.GetPerson_All();
                AllWordsList = connector.GetPerson_All_eng();

                ImgL.Source = new BitmapImage(new Uri("./../../Eng_flag.png", UriKind.Relative));
                ImgP.Source = new BitmapImage(new Uri("./../../Pl_flag.png", UriKind.Relative));

                search_bar_label.Content = "Search a word:";
                lang_switch.Content = "Change Language";
            }

            TranslatedWordsList.Clear();
            translated_words.ItemsSource = AllWordsList;
            translated_words.ItemsSource = TranslatedWordsList;

            matchingWords.ItemsSource = AllWordsList;


            selected_word_and_desc.Content = "";
            lang_selected = !lang_selected;
            search_bar.Text = "";
        }

        private void translated_words_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedItem = (Word_class)translated_words.Items.GetItemAt(translated_words.SelectedIndex);
                string target;
                if (!lang_selected)
                {
                    target = $"https://dictionary.cambridge.org/dictionary/polish-english/{selectedItem.Word}";
                }
                else
                {
                    target = $"https://dictionary.cambridge.org/dictionary/english-polish/{selectedItem.Word}";
                }
                System.Diagnostics.Process.Start(target);
                translated_words.UnselectAll();
            }
            catch{ }
        }
    }
}
