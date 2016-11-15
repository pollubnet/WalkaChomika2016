using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    class MagicAnimal : Animal
    {
        public int MagicAttack()
        {
            int damage = 0;

            if (Mana > 0)
            {
                damage = 4; // TODO: poprawić ataki magiczne!
                Mana--;
            }

            return damage;
        }
    }
}
