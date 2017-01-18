#region License

/*
 * Written in 2016/2017 by pollub.net members
 *
 * To the extent possible under law, the author(s) have dedicated
 * all copyright and related and neighboring rights to this
 * software to the public domain worldwide. This software is
 * distributed without any warranty.
 *
 * You should have received a copy of the CC0 Public Domain
 * Dedication along with this software. If not, see
 * <http://creativecommons.org/publicdomain/zero/1.0/>.
 */

#endregion License

using System;
using System.ComponentModel;

namespace WalkaChomika.Models
{
    public abstract class Animal : INotifyPropertyChanged
    {
        /// <summary>
        /// Poziom życia.
        /// </summary>
        public int HP;

        /// <summary>
        /// Imię zwierzęcia.
        /// </summary>

        private string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (this.name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Even run when databound property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Handles when property is changed raising <see cref="PropertyChanged"/>
        /// event.
        /// 
        /// Part of <see cref="INotifyPropertyChanged"/> implementation.
        /// </summary>
        /// <param name="name">Name of a changed property</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Mana zierzęcia
        /// </summary>
        public int Mana;

        /// <summary>
        /// Maksymalny poziom obrażeń jakie może zadań zwierzę
        /// </summary>
        public int Damage;

        public int Agility;

        /// <summary>
        /// Metoda okresla czy zwierzę nadla żuję
        /// </summary>
        /// <returns>True - jeżeli żyje, w przeciwym wypadku false</returns>
        public bool IsAlive()
        {
            // Gdy HP jest większe od 0 to zwracamy true, poniewaz
            // nadal żyje
            if (HP > 0)
                return true;
            else
                // gdy HP mniejsze od 0 to zwracamy false, czyli nie żyje
                return false;
        }

        /// <summary>
        /// Podstawowy atak zwierzęcia.
        /// </summary>
        /// <param name="animalToAttack">
        /// Obiekt zwierzęcia któego ma zaatakować
        /// </param>
        public int Attack()
        {
            // tworzymy obiekt generatora liczb losowych
            Random generator = new Random();

            // Ustawiamy poziom mocy z jaką uderzymy, czyli
            // genererujemy losową liczbę od 0 do maksymalnego poziomu
            // obrażeń zwierzęcia.
            int strength = generator.Next(Damage + 1);

            return strength;
        }

        public abstract int Fight();

        public override string ToString()
        {
            var desc = new string[] { "stoi tutaj", "rozgląda się nerwowo", "szuka zaczepki" };
            Random r = new Random();
            var d = desc[r.Next(desc.Length)];

            return $"{Name} {d}.";
        }
    }
}