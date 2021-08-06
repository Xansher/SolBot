using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolBot.Objects
{
    public class Rune
    {
        public Rune(string shortName, string name, string spell, int manaLow, int manaHigh, int soul)
        {
            this.ShortName = shortName;
            this.Name = name;
            this.Spell = spell;
            this.ManaLow = manaLow;
            this.ManaHigh = manaHigh;
            this.Soul = soul;
        }

        public string ShortName { get; set; }
       
        public string Name { get; set; }
        public string Spell { get; set; }
        public int ManaLow { get; set; }
        public int ManaHigh { get; set; }
        public int Soul { get; set; }
    }
}
