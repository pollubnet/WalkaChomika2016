using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Engine
{
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

    public static class NeswduHelper
    {
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

        public static bool CanIGo(Neswdu neswdu, Neswdu course)
        {
            return neswdu.HasFlag(course);
        }

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
