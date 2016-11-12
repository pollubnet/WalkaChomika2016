using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ktos.Aisle.Engine.Areas
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
        static bool CanIGo(Neswdu Neswdu, Neswdu Course)
        {
            return Neswdu.HasFlag(Course);
        }
    }
}
