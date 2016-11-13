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
using System.Linq;

namespace WalkaChomika.Engine
{
    /// <summary>
    /// Klasa określająca krainę (obszar) dla gry
    /// </summary>
    public class Area
    {
        /// <summary>
        /// Identyfikator krainy
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nazwa krainy
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Lista wszystkich lokacji w danej krainie
        /// </summary>
        public IList<Location> Locations { get; set; }

        /// <summary>
        /// Punkt startowy, w którym gracz zostanie umieszczony
        /// </summary>
        public Point3 StartingPoint { get; set; }

        /// <summary>
        /// Zwraca lokację z danej krainy pod danymi współrzędnymi
        /// </summary>
        /// <param name="point">Współrzędne w przestrzeni trójwymiarowej</param>
        /// <returns>
        /// Lokacja, która znajdowała się pod danymi współrzędnymi lub
        /// null jeśli taka nie istnieje
        /// </returns>
        public Location GetLocation(Point3 point)
        {
            return Locations.Where(x => x.Coordinates == point).FirstOrDefault();
        }
    }
}