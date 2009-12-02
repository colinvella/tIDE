using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    public struct Location
    {
        private static Location s_origin = new Location(0, 0);

        public static Location Origin { get { return s_origin; } }

        public int X;
        public int Y;

        public static Location operator +(Location location1, Location location2)
        {
            return new Location(location1.X + location2.X, location1.Y + location2.Y);
        }

        public static Location operator -(Location location1, Location location2)
        {
            return new Location(location1.X - location2.X, location1.Y - location2.Y);
        }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "[" + X + ", " + Y + "]";
        }
    }
}
