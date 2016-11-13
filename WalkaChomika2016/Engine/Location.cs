using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkaChomika.Models;
using Windows.Foundation;

namespace WalkaChomika.Engine
{
    public class Location
    {
        public Point3 Coordinates { get; set; }

        public string Name { get; set; }

        public Neswdu Neswdu { get; set; }

        public Neswdu HiddenNeswdu { get; set; }

        public string Description { get; set; }

        public List<Animal> Enemies { get; set; }

        public Location()
        {

        }

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
