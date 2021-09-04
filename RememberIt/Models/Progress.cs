using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberIt.Models
{
    class Progress
    {
        public int RememberedCardsCount { get; set; }
        public int RememberedCardsCountAtLastDay { get; set; }
        public string LastDay { get; set; }
        public int TodayCardsChecked { get; set; }
        public Progress()
        {
            RememberedCardsCount = 0;
            RememberedCardsCountAtLastDay = 0;
            TodayCardsChecked = 0;
            LastDay = DateTime.Now.ToShortDateString().ToString();
        }
    }
}
