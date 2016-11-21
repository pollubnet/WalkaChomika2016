using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    class Pegasus : Animal, IMagicAnimal, IFlying
    {
        public Pegasus(string name)
        {
            Name = name;
            HP = 20;
            Damage = 5;
            Mana = 5;
        }

        public override int Fight()
        {
            if (HP < HP / 2)
            {
                Fly();
                return 0;
            }
            else
            {
                Random r = new Random();
                if (r.NextDouble() > 0.5)
                {
                    return MagicAttack();
                }
                else
                {
                    return Attack();
                }
            }
        }

        public void Fly()
        {
            Agility = 7;
        }

        public int MagicAttack()
        {
            Random r = new Random();
            if (Mana > 0)
            {
                Mana--;
                return r.Next(Damage * 2);
            }
            else
            {
                return 0;
            }
        }
    }
}
