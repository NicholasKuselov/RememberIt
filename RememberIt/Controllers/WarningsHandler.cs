using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RememberIt.Controllers
{
    class WarningsHandler
    {
        public static MessageBoxResult NO_CARD_FRONT_TEXT()
        {
            return MessageBox.Show((string)Application.Current.Resources["WNoFrontText"], (string)Application.Current.Resources["WarningCaption"], MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static MessageBoxResult NO_CARD_BACK_TEXT()
        {
            return MessageBox.Show((string)Application.Current.Resources["WNoBacktext"], (string)Application.Current.Resources["WarningCaption"], MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static MessageBoxResult DECK_NAME_ALREADY_EXIST()
        {
            return MessageBox.Show((string)Application.Current.Resources["WDeckNameExist"], (string)Application.Current.Resources["WarningCaption"], MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static MessageBoxResult LOW_CARDS_COUNT()
        {
            return MessageBox.Show((string)Application.Current.Resources["WLowCardsCount"], (string)Application.Current.Resources["WarningCaption"], MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static MessageBoxResult DECK_NAME_TOO_SHORT()
        {
            return MessageBox.Show((string)Application.Current.Resources["WToShortDeckName"], (string)Application.Current.Resources["WarningCaption"], MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static MessageBoxResult SELECTED_DECK_ALL_REMEMBERED()
        {
            return MessageBox.Show((string)Application.Current.Resources["WSelectedDeckAllRemembered"], (string)Application.Current.Resources["WarningCaption"], MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static MessageBoxResult NO_SELECTED_DECK()
        {
            return MessageBox.Show((string)Application.Current.Resources["WNoSelectedDeck"], (string)Application.Current.Resources["WarningCaption"], MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
