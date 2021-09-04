using GalaSoft.MvvmLight.Command;
using RememberIt.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RememberIt.Models
{
    public class Deck
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        [JsonIgnore]
        public int RememberedCardsCount { get { return Cards.FindAll(card => card.IsRemembered).Count; } }

        [JsonIgnore]
        public bool IsRemembered
        {
            get
            {
                if (RememberedCardsCount == Cards.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ICommand Refresh
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (MessageBox.Show((string)Application.Current.Resources["WDeckRefresh"], (string)Application.Current.Resources["WarningCaption"], MessageBoxButton.YesNo, MessageBoxImage.Warning).Equals(MessageBoxResult.Yes))
                    {
                        for (int i = 0; i < Cards.Count; i++)
                        {
                            Cards[i].IsRemembered = false;
                        }
                        DecksHandler.Save();
                    }
                });
            }
        }

    }
}
