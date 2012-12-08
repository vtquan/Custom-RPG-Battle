using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_RPG_Battle.Common.RPG
{
    public class Spell : Item
    {
        private int mpCost; //how much mp to use spell
        private int hpCost; //how much hp to use spell

        //Constructors
        public Spell()
            : base()
        {
            mpCost = 0;
            hpCost = 0;
        }

        public Spell(int MPCost)
            : base()
        {
            mpCost = MPCost;
            hpCost = 0;
        }

        public Spell(int MPCost, int HPCost)
            : base()
        {
            mpCost = MPCost;
            hpCost = HPCost;
        }

        public Spell(string Name, int CritPercent, double MinDamage, double MaxDamage, int MPCost)
            : base(Name, CritPercent, MinDamage, MaxDamage)
        {
            mpCost = MPCost;
        }

        public Spell(string Name, int CritPercent, double MinDamage, double MaxDamage, int MPCost, int HPCost)
            : base(Name, CritPercent, MinDamage, MaxDamage)
        {
            mpCost = MPCost;
            hpCost = HPCost;
        }

        public Spell(string Name, int CritPercent, double MinDamage, double MaxDamage, int MPCost, int HPCost, int MinHeal, int MaxHeal, int HealCritPercent)
            : base(Name, CritPercent, MinDamage, MaxDamage, MinHeal, MaxHeal, HealCritPercent)
        {
            mpCost = MPCost;
            hpCost = HPCost;
        }

        public Spell(string Name, int CritPercent, double MinDamage, double MaxDamage, int MPCost, int HPCost, int MinHeal, int MaxHeal, int HealCritPercent, int PoisonStrength, int ParalyzeStrength)
            : base(Name, CritPercent, MinDamage, MaxDamage, MinHeal, MaxHeal, HealCritPercent, PoisonStrength, ParalyzeStrength)
        {
            mpCost = MPCost;
            hpCost = HPCost;
        }

        //Get Methods

        public int getMPCost()
        {
            return mpCost;
        }
    }
}
