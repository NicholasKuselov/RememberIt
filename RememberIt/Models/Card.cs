using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberIt.Models
{
    public class Card
    {
        public string FrontName { get; set; } = "";
        public string BackName { get; set; } = "";
        public bool IsRemembered { get; set; } = false;
    }
}
