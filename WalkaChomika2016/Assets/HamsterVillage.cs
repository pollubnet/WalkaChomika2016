using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ktos.Aisle.Engine.Areas;

namespace WalkaChomika2016.Assets
{
    class HamsterVillage
    {
        private Area village;

        public HamsterVillage()
        {
            village = new Area { Id = 1, Name = "Hamster Village", StartingPoint = new Point3 { X = 0, Y = 0, Z = 0 } };
            village.Locations = new List<Location>();

            village.Locations.Add(new Location { Coordinates = new Point3 { X = 0, Y = 0, Z = 0 }, Description = "Brama wioski chomików jest bardzo zakurzona, bo dawno tutaj nikt nie sprzątał.", Name = "Brama Wioski Chomików", Neswdu = Neswdu.None });
        }

        public Area GetArea()
        {
            return village;
        }
    }
}
