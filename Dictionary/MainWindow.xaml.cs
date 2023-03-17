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

        List<PolishWord> allPolishWordsList = new List<PolishWord>();
        List<PolishWord> searchedWordsList = new List<PolishWord>();
        List<PolishWord> searchedWordsListList = new List<PolishWord>();

        List<EnglishWord> allEnglishWordsList = new List<EnglishWord>();

        PolishWord selectedItem;
        string wyszukane_slowo = "";
        public MainWindow()
        {
            InitializeComponent();

            connector= new SqlConnector();
            allPolishWordsList = connector.GetPerson_All();
            allEnglishWordsList = connector.GetPerson_All_eng();

            matchingWords.ItemsSource= allPolishWordsList;
            

        }


        private void search_bar_TextChanged(object sender, TextChangedEventArgs e)
        {
            wyszukane_slowo = search_bar.Text.ToString();

            matchingWords.ItemsSource = allPolishWordsList;
            searchedWordsList.Clear();

            foreach (PolishWord word in allPolishWordsList)
            {
                if (word.Word.Contains(wyszukane_slowo) || (word.Description.Contains(wyszukane_slowo)))
                {
                    searchedWordsList.Add(word);
                }
            }
            matchingWords.ItemsSource = searchedWordsList;


        }


        private void matchingWords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try { selectedItem = (PolishWord)matchingWords.Items.GetItemAt(matchingWords.SelectedIndex); }catch{} // zrobić tak ęzby przy zmianie wyszukiwania niewywalało programu bez użyczia tego try / catch
            translated_words.ItemsSource = allPolishWordsList;
            searchedWordsListList.Clear();
            foreach (EnglishWord word in allEnglishWordsList)
            {
                if (word.Id == selectedItem.Id)
                {
                    searchedWordsListList.Add(word);
                }
            }
            translated_words.ItemsSource = searchedWordsListList;
            selected_word_and_desc.Content = selectedItem.Word + "   opis: " +selectedItem.Description;
        }
    }   
}
