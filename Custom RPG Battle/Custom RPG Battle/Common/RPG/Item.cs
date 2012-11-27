using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_RPG_Battle.Common.RPG
{
    public class Item : Attack
    {
        string name;
        private int heal;   //how much hp the item heal

        //Constructors
        public Item()
        {
            name = "Item";
            heal = 0;
        }

        public Item(string Name, int Heal)
        {
            name = Name;
            heal = Heal;
        }

        //Get Methods
        public string getName()
        {
            return name;
        }

        public int getHeal()
        {
            return heal;
        }
    }
}
