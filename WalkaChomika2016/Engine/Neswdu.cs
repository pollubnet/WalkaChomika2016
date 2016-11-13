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
using System.Text;

namespace WalkaChomika.Engine
{
    /// <summary>
    /// Enum określający możliwe kierunki chodzenia w lokacjach
    /// </summary>
    [Flags]
    public enum Neswdu
    {
        None = 0,
        North = 2,
        East = 4,
        South = 8,
        West = 16,
        Down = 32,
        Up = 64
    }

    /// <summary>
    /// Pomocnicza klasa dla enuma Neswdu
    /// </summary>
    public static class NeswduHelper
    {
        /// <summary>
        /// Zwraca punkt, który jest w stosunku do obecnego punktu w
        /// określonym kierunku
        /// </summary>
        /// <param name="current">Obecna pozycja</param>
        /// <param name="course">Kurs</param>
        /// <returns>Obliczona pozycja na zadanym kursie</returns>
        public static Point3 ToRelativePoint3(Point3 current, Neswdu course)
        {
            if (course.HasFlag(Neswdu.North))
                return new Point3(current, 0, -1, 0);

            if (course.HasFlag(Neswdu.East))
                return new Point3(current, 1, 0, 0);

            if (course.HasFlag(Neswdu.South))
                return new Point3(current, 0, 1, 0);

            if (course.HasFlag(Neswdu.West))
                return new Point3(current, -1, 0, 0);

            if (course.HasFlag(Neswdu.Down))
                return new Point3(current, 0, 0, -1);

            if (course.HasFlag(Neswdu.Up))
                return new Point3(current, 0, 0, 1);

            return current;
        }

        /// <summary>
        /// Sprawdza, czy możliwe jest przesunięcie się na kurs kiedy
        /// zmienna lokacji jest ustawiona w dany sposób
        /// </summary>
        /// <param name="neswdu">Zmienna określająca dozwolone kierunki</param>
        /// <param name="course">Zadany kurs</param>
        /// <returns>
        /// Zwraca true jeśli jest możliwe przesunięcie się w danym kierunku
        /// </returns>
        public static bool CanIGo(Neswdu neswdu, Neswdu course)
        {
            return neswdu.HasFlag(course);
        }

        /// <summary>
        /// Przekształca zmienną typu Neswdu na łańcuch znaków w języku
        /// polskim. W przypadku jeżeli Neswdu określa więcej niż jeden
        /// dozwolony kierunek, zmienna wynikowa będzie zawierać
        /// wszystkie, oddzielone spacją.
        /// </summary>
        /// <param name="course">Zmienna z kierunkami</param>
        /// <returns>Łańcuch znaków w języku polskim</returns>
        public static string ToNaturalLanguage(Neswdu course)
        {
            StringBuilder sb = new StringBuilder();

            if (course.HasFlag(Neswdu.North))
            {
                sb.Append("północ");
                sb.Append(" ");
            }

            if (course.HasFlag(Neswdu.East))
            {
                sb.Append("wschód");
                sb.Append(" ");
            }

            if (course.HasFlag(Neswdu.South))
            {
                sb.Append("południe");
                sb.Append(" ");
            }

            if (course.HasFlag(Neswdu.West))
            {
                sb.Append("zachód");
                sb.Append(" ");
            }

            if (course.HasFlag(Neswdu.Down))
            {
                sb.Append("dół");
                sb.Append(" ");
            }

            if (course.HasFlag(Neswdu.Up))
            {
                sb.Append("góra");
                sb.Append(" ");
            }

            return sb.ToString().Trim();
        }
    }
}