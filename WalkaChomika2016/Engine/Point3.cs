namespace Ktos.Aisle.Engine.Areas
{
    public struct Point3
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3(Point3 p, int x, int y, int z)
        {
            X = p.X + x;
            Y = p.Y + y;
            Z = p.Z + z;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Point3))
            {
                var o = (Point3)obj;
                return o.X == this.X && o.Y == this.Y && o.Z == this.Z;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public static bool operator==(Point3 obj1, Point3 obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Point3 obj1, Point3 obj2)
        {
            return !obj1.Equals(obj2);
        }

        public override int GetHashCode()
        {
            return X * 3 + Y * 7 + Z * 9;
        }
    }
}