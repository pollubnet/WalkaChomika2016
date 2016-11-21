using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    class HamsterShaman : Hamster, IMagicAnimal
    {
        public HamsterShaman(string name) : base(name)
        {
            HP = 10;
            Damage = 1;
            Mana = 10;
        }

        public int MagicAttack()
        {
            Random r = new Random();
            if (Mana > 0)
            {
                Mana--;
                return r.Next(Damage * 10);
            }
            else
            {
                return 0;
            }
           
        }
    }
}
