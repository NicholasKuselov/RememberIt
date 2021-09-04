using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RememberIt.Controllers;
using RememberIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RememberIt.ViewModels
{
    class DeckPageVM : ViewModelBase
    {
        private int _currentCardIndex = 0;
        public int CurrentCardIndex
        {
            get
            {
                return _currentCardIndex;
            }
            set
            {
                _currentCardIndex = value;
                CurrentCard = Cards[_currentCardIndex];
            }
        }
        public Deck Deck { get; set; }
        public BindingList<Card> Cards { get; set; }
        public Visibility RememberButtonsVisibility { get; set; } = Visibility.Hidden;
        public Visibility ShowButtonVivsibility { get; set; } = Visibility.Visible;
        public Card CurrentCard { get; set; }

        private Random random;

        private ProgressHandler progress = new ProgressHandler();
        public DeckPageVM(Deck deck, int needCardCount)
        {
            random = new Random();
            Deck = deck;
            Cards = new BindingList<Card>(Deck.Cards.FindAll(card => !card.IsRemembered).OrderBy(item => random.Next()).ToList().Take(needCardCount).ToList());
            CurrentCard = Cards[CurrentCardIndex];
        }

        public DeckPageVM() { }

        private void ShowNextCard()
        {
            if (CurrentCardIndex < Cards.Count - 1)
            {
                RememberButtonsVisibility = Visibility.Hidden;
                ShowButtonVivsibility = Visibility.Visible;
                CurrentCardIndex++;
            }
            else
            {
                MessageBox.Show((string)Application.Current.Resources["lEndMessage"], (string)Application.Current.Resources["lMessage"], MessageBoxButton.OK, MessageBoxImage.Information);
                Exit();
            }

        }

        private void Exit()
        {
            ((MainViewModel)App.Current.MainWindow.DataContext).CurrentPage = ((MainViewModel)App.Current.MainWindow.DataContext).menuPage;
        }

        public ICommand ShowBackFront
        {
            get
            {
                return new RelayCommand(() =>
                {
                    progress.Check();
                    RememberButtonsVisibility = Visibility.Visible;
                    ShowButtonVivsibility = Visibility.Hidden;
                });
            }
        }

        public ICommand OpenNextCard
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ShowNextCard();
                });
            }
        }

        public ICommand ExitCard
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Exit();
                });
            }
        }

        public ICommand Remember
        {
            get
            {
                return new RelayCommand(() =>
                {
                    progress.Remember();
                    Cards[CurrentCardIndex].IsRemembered = true;
                    DecksHandler.Save();
                    ShowNextCard();
                });
            }
        }

        public ICommand NotRemember
        {
            get
            {
                return new RelayCommand(() =>
                {
                    ShowNextCard();
                });
            }
        }
    }
}
