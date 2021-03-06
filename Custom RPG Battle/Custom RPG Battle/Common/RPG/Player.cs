﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_RPG_Battle.Common.RPG
{
    public class Player : Character
    {
        Attack defaultAttack;   //default attack when pressing the attack button

        //Constructors
        public Player()
            : base()
        {
            defaultAttack = new Attack(1, 1, 15);
        }

        public Player(string Name, int HP, int MP)
            : base(Name, HP, MP)
        {
            defaultAttack = new Attack(1, 1, 15);
        }

        public Player(string Name, int HP, int MP, Attack DefaultAttack)
            : base(Name, HP, MP)
        {
            defaultAttack = DefaultAttack;
        }

        public Player(string Name, int HP, int MP, int PoisonResist, int ParalyzeResist)
            : base(Name, HP, MP, PoisonResist, ParalyzeResist)
        {
            defaultAttack = new Attack(1, 1, 15);
        }

        public Player(string Name, int HP, int MP, int PoisonResist, int ParalyzeResist, Attack DefaultAttack)
            : base(Name, HP, MP, PoisonResist, ParalyzeResist)
        {
            defaultAttack = DefaultAttack;
        }

        //Get Methods

        //Set Methods
        public void setDefaultAttack(Attack DefaultAttack)
        {
            defaultAttack = DefaultAttack;
        }

        //Action Methods
        public double attackObject(ref Monster Target)
        {
            Random random = new Random();

            //Calculate Initial Damage
            double damage = random.Next((int)defaultAttack.getMinDamage(), (int)defaultAttack.getMaxDamage() + 1);

            //Crit or not
            bool crit;
            crit = (defaultAttack.getCritPercent() >= random.Next(1, 11));

            //Calculate final damage
            if (crit)
            {
                damage = damage * 1.5;
            }

            Target.testParalyzed();
            Target.testPoisoned();

            Target.setHP(Target.getHP() - (int)damage);

            return damage;
        }
    }
}
