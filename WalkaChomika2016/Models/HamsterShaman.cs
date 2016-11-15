using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    class HamsterShaman : MagicAnimal
    {
        public HamsterShaman(string name)
        {
            Name = name;
            HP = 10;
            Damage = 1;
            Mana = 10;
        }
    }
}
