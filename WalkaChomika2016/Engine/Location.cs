using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkaChomika.Models;
using Windows.Foundation;

namespace Ktos.Aisle.Engine.Areas
{
    public class Location
    {
        public Point3 Coordinates { get; set; }

        public string Name { get; set; }

        public Neswdu Neswdu { get; set; }

        public Neswdu HiddenNeswdu { get; set; }

        public string Description { get; set; }

        public List<Animal> Enemies { get; set; }
    }
}
