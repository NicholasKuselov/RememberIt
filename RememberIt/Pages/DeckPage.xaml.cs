using RememberIt.Models;
using RememberIt.ViewModels;
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

namespace RememberIt.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeckPage.xaml
    /// </summary>
    public partial class DeckPage : Page
    {
        public DeckPage()
        {
            InitializeComponent();
        }

        public DeckPage(Deck deck, int needCardCount)
        {
            InitializeComponent();
            DataContext = new DeckPageVM(deck, needCardCount);
        }
    }
}
