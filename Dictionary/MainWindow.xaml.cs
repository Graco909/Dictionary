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

        Word_class selectedItem;
        string wyszukane_slowo = "";
        bool lang_selected= true;
        public MainWindow()
        {
            InitializeComponent();

            connector= new SqlConnector();

            if (lang_selected)
            {
                AllWordsList = connector.GetPerson_All();
                AllWords2langList = connector.GetPerson_All_eng();
            }
            else
            {
                AllWords2langList = connector.GetPerson_All();
                AllWordsList  = connector.GetPerson_All_eng();
            }

            matchingWords.ItemsSource= AllWordsList;
        }


        private void search_bar_TextChanged(object sender, TextChangedEventArgs e) //wyszukiwanie słów 
        {
            wyszukane_slowo = search_bar.Text.ToString();

            matchingWords.ItemsSource = AllWordsList;
            searchedWordsList.Clear();

            foreach (Word_class word in AllWordsList)
            {
                if (word.Word.Contains(wyszukane_slowo) || (word.Description.Contains(wyszukane_slowo)))
                {
                    searchedWordsList.Add(word);
                }
            }
            matchingWords.ItemsSource = searchedWordsList;
        }


        private void matchingWords_SelectionChanged(object sender, SelectionChangedEventArgs e) // znajdowanie dopasowanych przetłumaczonych słów
        {
            try { selectedItem = (Word_class)matchingWords.Items.GetItemAt(matchingWords.SelectedIndex); }catch{} // zrobić tak ęzby przy zmianie wyszukiwania niewywalało programu bez użyczia tego try / catch
            translated_words.ItemsSource = AllWordsList;
            TranslatedWordsList.Clear();
            foreach (Word_class word in AllWords2langList)
            {
                if (word.Id == selectedItem.Id)
                {
                    TranslatedWordsList.Add(word);
                }
            }
            translated_words.ItemsSource = TranslatedWordsList;
            selected_word_and_desc.Content = selectedItem.Word;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //guzik do zmiany języka z turego i na ktury się tłumaczy 
        {
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
            TranslatedWordsList.Clear();
            translated_words.ItemsSource = TranslatedWordsList; ;
            matchingWords.ItemsSource = AllWordsList;
            lang_selected = !lang_selected;
        }
    }   
}
