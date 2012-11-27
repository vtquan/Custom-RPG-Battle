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
            : base()
        {
            heal = 0;
        }

        public Item(string Name, int Heal)
            : base()
        {
            heal = Heal;
        }

        //Get Methods

        public int getHeal()
        {
            return heal;
        }
    }
}
