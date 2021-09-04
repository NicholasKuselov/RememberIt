using RememberIt.Models;
using RememberIt.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RememberIt.Controllers
{
    public class DecksHandler
    {
        private const string DECKS_FILE_PATH = "data/decks.dck";

        public static List<Deck> Decks { get; set; }

        static DecksHandler()
        {
            Load();
        }

        private static void Load()
        {
            try
            {
                Decks = JsonSerializer.Deserialize<List<Deck>>(File.ReadAllText(DECKS_FILE_PATH));
                if (Decks == null)
                {
                    Decks = new List<Deck>();
                }
            }
            catch
            {
                Decks = new List<Deck>();
                WriteFile();
            }
        }

        public static void Save()
        {
            WriteFile();
            ((MenuPageVM)((MainViewModel)App.Current.MainWindow.DataContext)?.menuPage.DataContext).Update();
        }

        private static void WriteFile()
        {
            File.WriteAllText(DECKS_FILE_PATH, JsonSerializer.Serialize(Decks));
        }

        public static void AddDeck(Deck deck)
        {
            Decks.Add(deck);
            Save();
        }

        public static bool IsNameAlredyExist(string name)
        {
            if (Decks.FindAll(deck => deck.Name.ToLower().Equals(name.ToLower())).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
