using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    public class Animal
    {
        /// <summary>
        /// Poziom życia.
        /// </summary>
        public int HP;
        /// <summary>
        /// Imię zwierzęcia.
        /// </summary>
        public string Name;
        /// <summary>
        /// Mana zierzęcia
        /// </summary>
        public int Mana;
        /// <summary>
        /// Maksymalny poziom obrażeń jakie może zadań zwierzę
        /// </summary>
        public int Damage;

        /// <summary>
        /// Metoda okresla czy zwierzę nadla żuję
        /// </summary>
        /// <returns>True - jeżeli żyje, w przeciwym wypadku false</returns>
        public bool IsAlive()
        {
            // Gdy HP jest większe od 0 to zwracamy true, poniewaz nadal żyje
            if (HP > 0)
                return true;
            else
                // gdy HP mniejsze od 0 to zwracamy false, czyli nie żyje
                return false;
        }


        /// <summary>
        /// Podstawowy atak zwierzęcia.
        /// </summary>
        /// <param name="animalToAttack">Obiekt zwierzęcia któego ma zaatakować</param>
        public void Attack(Animal animalToAttack)
        {
            // tworzymy obiekt generatora liczb losowych
            Random generator = new Random();

            // Ustawiamy poziom mocy z jaką uderzymy, czyli genererujemy losową liczbę od 0 do maksymalnego poziomu obrażeń zwierzęcia.
            int strength = generator.Next(Damage);

            // Zmiejszamy HP atakowanego zwierzęcia o wygenerowaną moc.
            animalToAttack.HP -= strength;
        }
    }
}
