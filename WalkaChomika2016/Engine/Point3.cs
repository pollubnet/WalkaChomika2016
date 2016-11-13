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

namespace WalkaChomika.Engine
{
    /// <summary>
    /// Struktura reprezentująca pozycję w świecie trójwymiarowym
    /// </summary>
    public struct Point3
    {
        /// <summary>
        /// Pozycja na osi X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Pozycja na osi Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Pozycja na osi Z
        /// </summary>
        public int Z { get; set; }

        /// <summary>
        /// Podstawowy kontruktor
        /// </summary>
        /// <param name="x">Pozycja na osi X</param>
        /// <param name="y">Pozycja na osi Y</param>
        /// <param name="z">Pozycja na osi Z</param>
        public Point3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Konstruktor tworzący nowy punkt na podstawie już
        /// istniejącego punktu, wprowadzając pewne modyfikacje
        /// </summary>
        /// <param name="p">Podstawowy punkt</param>
        /// <param name="x">Różnica pozycji na osi X (dodawana)</param>
        /// <param name="y">Różnica pozycji na osi Y (dodawana)</param>
        /// <param name="z">Różnica pozycji na osi Z (dodawana)</param>
        public Point3(Point3 p, int x, int y, int z)
        {
            X = p.X + x;
            Y = p.Y + y;
            Z = p.Z + z;
        }

        /// <summary>
        /// Sprawdza czy punkt jest równy innemu punktowi lub innemu
        /// obiektowi. W przypadku porównywania dwóch punktów są one
        /// traktowane jak równe kiedy wszystkie wartości X, Y i Z są
        /// sobie równe.
        /// </summary>
        /// <param name="obj">Inny punkt do porównania</param>
        /// <returns>
        /// Zwraca czy punkt jest równy innemu punktowi lub obiektowi
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Point3))
            {
                var o = (Point3)obj;
                return o.X == X && o.Y == Y && o.Z == Z;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// Operator do sprawdzania równości punktów. Są one traktowane
        /// jak równe kiedy wszystkie wartości X, Y i Z są sobie równe.
        /// </summary>
        /// <param name="obj1">Pierwszy punkt do porównania</param>
        /// <param name="obj2">Drugi punkt do porównania</param>
        /// <returns>Zwraca czy punkty są sobie równe</returns>
        public static bool operator ==(Point3 obj1, Point3 obj2)
        {
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Operator do sprawdzania nierówności punktów. Są one
        /// traktowane jako nierówne kiedy którakolwiek z wartości X, Y
        /// i Z nie jest taka sama w obu.
        /// </summary>
        /// <param name="obj1">Pierwszy punkt do porównania</param>
        /// <param name="obj2">Drugi punkt do porównania</param>
        /// <returns>wraca czy punkty nie są sobie równe</returns>
        public static bool operator !=(Point3 obj1, Point3 obj2)
        {
            return !obj1.Equals(obj2);
        }

        /// <summary>
        /// Przelicza obiekt na liczbę, możliwie niepowtarzalną
        /// </summary>
        /// <returns>Liczba określająca obiekt</returns>
        public override int GetHashCode()
        {
            return X * 3 + Y * 7 + Z * 9;
        }
    }
}