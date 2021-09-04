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
    class ProgressHandler
    {
        private const string PROGRESS_FILE_PATH = "data/progress.json";
        public static Progress Progress { get; set; }

        static ProgressHandler()
        {
            Load();
            if (!DateTime.Now.ToShortDateString().ToString().Equals(Progress.LastDay))
            {
                Progress.LastDay = DateTime.Now.ToShortDateString().ToString();
                Progress.RememberedCardsCountAtLastDay = 0;
                Progress.TodayCardsChecked = 0;
                WriteFile();
            }
        }

        public void Remember()
        {
            Progress.RememberedCardsCountAtLastDay += 1;
            Progress.RememberedCardsCount += 1;
            Save();
        }
        public void Check()
        {
            Progress.TodayCardsChecked += 1;
            Save();
        }

        private static void Load()
        {
            try
            {
                Progress = JsonSerializer.Deserialize<Progress>(File.ReadAllText(PROGRESS_FILE_PATH));
                if (Progress == null)
                {
                    Progress = new Progress();
                }
            }
            catch
            {
                Progress = new Progress();
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
            File.WriteAllText(PROGRESS_FILE_PATH, JsonSerializer.Serialize(Progress));
        }
    }
}
