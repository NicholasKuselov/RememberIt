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
    class MenuPageVM : ViewModelBase
    {
        public BindingList<Deck> Decks { get; set; }
        public int AllCardsCount { get; set; }
        private Deck _selectedDeck;
        public Deck SelectedDeck
        {
            get
            {
                return _selectedDeck;
            }
            set
            {
                _selectedDeck = value;
                NeedCardCount = _selectedDeck.Cards.FindAll(card => !card.IsRemembered).Count;
            }
        }
        public ProgressHandler ProgressHandler { get; set; } = new ProgressHandler();
        public int NeedCardCount { get; set; } = 0;
        public MenuPageVM()
        {
            Decks = new BindingList<Deck>(DecksHandler.Decks);
            AllCardsCount = Decks.Sum(deck => deck.Cards.Count);
        }

        public void Update()
        {
            Decks = new BindingList<Deck>(DecksHandler.Decks);
            AllCardsCount = Decks.Sum(deck => deck.Cards.Count);
            ProgressHandler = new ProgressHandler();
        }


        public ICommand OpenDeck
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (SelectedDeck == null)
                    {
                        WarningsHandler.NO_SELECTED_DECK();
                    }
                    else if (SelectedDeck.RememberedCardsCount == SelectedDeck.Cards.Count)
                    {
                        WarningsHandler.SELECTED_DECK_ALL_REMEMBERED();
                    }
                    else
                    {
                        ((MainViewModel)App.Current.MainWindow.DataContext).OpenDeckPage(SelectedDeck, NeedCardCount);
                    }
                });
            }
        }

        public ICommand DeleteDeck
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (SelectedDeck != null)
                    {
                        if (MessageBox.Show((string)Application.Current.Resources["WDeleteDeck"] + SelectedDeck.Name + " ?", (string)Application.Current.Resources["WarningCaption"], MessageBoxButton.YesNo, MessageBoxImage.Warning).Equals(MessageBoxResult.Yes))
                        {
                            DecksHandler.Decks.Remove(SelectedDeck);
                            DecksHandler.Save();
                        }
                    }
                });
            }
        }

        public ICommand AddNeedCardCount
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (SelectedDeck != null)
                    {
                        if (NeedCardCount < SelectedDeck.Cards.FindAll(card => !card.IsRemembered).Count)
                        {
                            NeedCardCount++;
                        }
                    }
                });
            }
        }

        public ICommand DecreaseNeedCardCount
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (SelectedDeck != null)
                    {
                        if (NeedCardCount > 1)
                        {
                            NeedCardCount--;
                        }

                    }
                });
            }
        }
    }
}
