using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_RPG_Battle.Common.RPG
{
    public class Item : Attack
    {
        private int heal;   //how much hp the item heal

        //Constructors
        public Item()   
            : base("Item")      //default name is Item instead of Attack
        {
            heal = 0;
        }

        public Item(string Name, int Heal)
            : base(Name)
        {
            heal = Heal;
        }

        public Item(int CritPercent, double MinDamage, double MaxDamage, int Heal)
            : base(CritPercent, MinDamage, MaxDamage)
        {
            heal = Heal;
        }

        public Item(string Name, int CritPercent, double MinDamage, double MaxDamage, int Heal)
            : base(Name, CritPercent, MinDamage, MaxDamage)
        {
            heal = Heal;
        }

        public Item(string Name, int CritPercent, double MinDamage, double MaxDamage, bool Warning, int Heal)
            : base(Name, CritPercent, MinDamage, MaxDamage, Warning)
        {
            heal = Heal;
        }

        public Item(string Name, int CritPercent, double MinDamage, double MaxDamage, bool Warning, string WarningMessage, int Heal)
            : base(Name, CritPercent, MinDamage, MaxDamage, Warning, WarningMessage)
        {
            heal = Heal;
        }

        //Get Methods
        public int getHeal()
        {
            return heal;
        }

        //Set Methods
        public void setHeal(int Heal)
        {
            heal = Heal;
        }
    }
}
