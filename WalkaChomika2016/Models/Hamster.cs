using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    class Hamster : Animal
    {
        public Hamster(string name)
        {
            Name = name;
            HP = 10;
            Damage = 1;
            Mana = 0;
        }

        public override int Fight()
        {
            return Attack();
        }
    }
}
