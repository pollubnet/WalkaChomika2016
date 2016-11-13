using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace WalkaChomika.Engine
{
    public class Area
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Location> Locations { get; set; }

        public Point3 StartingPoint { get; set; }

        public Location GetLocation(Point3 point)
        {
            return Locations.Where(x => x.Coordinates == point).FirstOrDefault();
        }
    }
}
