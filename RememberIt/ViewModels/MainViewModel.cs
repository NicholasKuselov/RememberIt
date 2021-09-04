using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RememberIt.Controllers;
using RememberIt.Models;
using RememberIt.Pages;
using RememberIt.Properties;
using RememberIt.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Resources;

namespace RememberIt.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public Page menuPage;
        public Page deckPage;

        public Page CurrentPage { get; set; }

        public Window CreatingDeckWindow;



        public MainViewModel()
        {
            menuPage = new MenuPage();

            CurrentPage = menuPage;
        }

        public void OpenDeckPage(Deck deck,int needCardCount)
        {
            deckPage = new DeckPage(deck,needCardCount);
            CurrentPage = deckPage;
        }


        public ICommand CreateNewDeck
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CreatingDeckWindow = new DeckCreatingWIndow();
                    CreatingDeckWindow.Show();
                });
            }
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.Shutdown();
                    Application.Current.MainWindow.Close();
                });
            }
        }

        public ICommand MaximizeWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    }
                    else
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    }

                });
            }
        }
        
        public ICommand MinimizeWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                });
            }
        }
    }
}
