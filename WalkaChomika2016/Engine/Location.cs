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

using System.Collections.Generic;
using WalkaChomika.Models;

namespace WalkaChomika.Engine
{
    /// <summary>
    /// Klasa określająca pojedynczą lokację (komnatę) w grze
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Współrzędne lokacji z trójwymiarowej przestrzeni
        /// </summary>
        public Point3 Coordinates { get; set; }

        /// <summary>
        /// Nazwa lokacji
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Dozwolone kierunki poruszania się (wyświetlane)
        /// </summary>
        public Neswdu Neswdu { get; set; }

        /// <summary>
        /// Dozwolone kierunki poruszania się - nie są wyświetlane, ale
        /// wobec nich wykonywane jest sprawdzanie. Daje to możliwość
        /// "oszukania" gracza, który może pójść w stronę, której nie
        /// pokazuje interfejs gry.
        /// </summary>
        public Neswdu HiddenNeswdu { get; set; }

        /// <summary>
        /// Opis lokacji
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Lista zwierząt, które obecne są (poza graczem) w danej lokacji
        /// </summary>
        public List<Animal> Enemies { get; set; }

        /// <summary>
        /// Bazowy konstruktor
        /// </summary>
        public Location()
        {
        }

        /// <summary>
        /// Skrócony konstruktor ustawiający najważniejsze elementy lokacji
        /// </summary>
        /// <param name="x">Pozycja w osi X</param>
        /// <param name="y">Pozycja w osi Y</param>
        /// <param name="z">Pozycja w osi Z</param>
        /// <param name="name">Nazwa lokacji</param>
        /// <param name="desc">Opis lokacji</param>
        /// <param name="neswdu">Dozwolone kierunki poruszania się</param>
        public Location(int x, int y, int z, string name, string desc, Neswdu neswdu)
        {
            Coordinates = new Point3 { X = x, Y = y, Z = z };
            Name = name;
            Description = desc;
            Neswdu = neswdu;
            HiddenNeswdu = neswdu;
            Enemies = null;
        }
    }
}