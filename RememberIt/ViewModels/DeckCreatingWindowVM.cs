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
using System.Windows.Input;

namespace RememberIt.ViewModels
{
    class DeckCreatingWindowVM : ViewModelBase
    {
        public string DeckName { get; set; } = "";

        public string FrontName { get; set; } = "";
        public string BackName { get; set; } = "";

        public BindingList<Card> Cards { get; set; } = new BindingList<Card>();
        public Card SelectedCard { get; set; }


        public ICommand AddCard
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (FrontName.Length == 0)
                    {
                        WarningsHandler.NO_CARD_FRONT_TEXT();
                    }
                    else if (BackName.Length == 0)
                    {
                        WarningsHandler.NO_CARD_BACK_TEXT();
                    }
                    else
                    {
                        Cards.Add(new Card()
                        {
                            FrontName = FrontName,
                            BackName = BackName,
                            IsRemembered = false
                        });
                        FrontName = "";
                        BackName = "";

                    }
                });
            }
        }

        public ICommand DeleteCard
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (SelectedCard != null)
                    {
                        Cards.Remove(SelectedCard);
                    }
                });
            }
        }

        public ICommand CreateDeck
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (DeckName.Length < 3)
                    {
                        WarningsHandler.DECK_NAME_TOO_SHORT();
                    }
                    else if (DecksHandler.IsNameAlredyExist(DeckName))
                    {
                        WarningsHandler.DECK_NAME_ALREADY_EXIST();
                    }
                    else if (Cards.Count < 2)
                    {
                        WarningsHandler.LOW_CARDS_COUNT();
                    }
                    else
                    {
                        DecksHandler.AddDeck(new Deck()
                        {
                            Name = DeckName,
                            Cards = Cards.ToList()
                        });
                        ((MainViewModel)App.Current.MainWindow.DataContext).CreatingDeckWindow?.Close();
                    }
                });
            }
        }

    }
}
