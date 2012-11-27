using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_RPG_Battle.Common.RPG
{
    public class Item : Attack
    {
        private int minHeal;   
        private int maxHeal;
        private int healCritPercent = 0; //value between 0 to 10

        //Constructors
        public Item()   
            : base("Item")      //default name is Item instead of Attack
        {
            minHeal = 0;
        }

        public Item(string Name, int Heal) //for basic healing item
            : base(Name)
        {
            minHeal = Heal;
            maxHeal = Heal;
            healCritPercent = 0;
        }

        public Item(string Name, int MinHeal, int MaxHeal, int HealCritPercent) //for pure healing item
            : base(Name)
        {
            minHeal = MinHeal;
            maxHeal = MaxHeal;
            healCritPercent = HealCritPercent;
        }

        public Item(string Name, int CritPercent, double MinDamage, double MaxDamage)   //for creating spells without healing
            : base(Name, CritPercent, MinDamage, MaxDamage)
        {
            minHeal = 0;
            maxHeal = 0;
        }

        public Item(string Name, int CritPercent, double MinDamage, double MaxDamage, int MinHeal, int MaxHeal, int HealCritPercent)
            : base(Name, CritPercent, MinDamage, MaxDamage)
        {
            minHeal = MinHeal;
            maxHeal = MaxHeal;
            healCritPercent = HealCritPercent;
        }

        public Item(string Name, int CritPercent, double MinDamage, double MaxDamage, bool Warning, int MinHeal, int MaxHeal, int HealCritPercent)
            : base(Name, CritPercent, MinDamage, MaxDamage, Warning)
        {
            minHeal = MinHeal;
            maxHeal = MaxHeal;
            healCritPercent = HealCritPercent;

        }

        public Item(string Name, int CritPercent, double MinDamage, double MaxDamage, bool Warning, string WarningMessage, int MinHeal, int MaxHeal, int HealCritPercent)
            : base(Name, CritPercent, MinDamage, MaxDamage, Warning, WarningMessage)
        {
            minHeal = MinHeal;
            maxHeal = MaxHeal;
            healCritPercent = HealCritPercent;
        }

        //Get Methods
        public int getHeal()
        {
            return minHeal;
        }

        //Set Methods
        public void setHeal(int Heal)
        {
            minHeal = Heal;
        }
    }
}
