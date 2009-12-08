using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiling
{
    [Serializable]
    public struct Location
    {
        private static Location s_origin = new Location(0, 0);

        public static Location Origin { get { return s_origin; } }

        public int X;
        public int Y;

        public static bool operator ==(Location location1, Location location2)
        {
            return location1.X == location2.X && location1.Y == location2.Y;
        }

        public static bool operator !=(Location location1, Location location2)
        {
            return location1.X != location2.X || location1.Y != location2.Y;
        }

        public static Location operator -(Location location)
        {
            return new Location(-location.X, -location.Y);
        }

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

        public override int GetHashCode()
        {
            return X + Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Location))
                return false;

            Location location = (Location) obj;
            return X == location.X && Y == location.Y;
        }

        public override string ToString()
        {
            return "[" + X + ", " + Y + "]";
        }
    }
}
